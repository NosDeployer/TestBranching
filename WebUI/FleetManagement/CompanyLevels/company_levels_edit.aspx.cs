using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.FleetManagement.Categories;
using LiquiForce.LFSLive.BL.FleetManagement.Categories;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.BL.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.CompanyLevels
{
    /// <summary>
    /// company_levels_edit
    /// </summary>
    public partial class company_levels_edit : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //
        protected CompanyLevelsAddTDS companyLevelsAddTDS;
        protected CompanyLevelsAddTDS.CompanyLevelManagersDataTable companyLevelManagers;
        protected CompanyLevelsTDS companyLevelsTDS;
        protected ArrayList arrayCompanyLevelsSelected;
        protected ArrayList arrayCompanyLevelsSelected2;






        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfUpdate.Value = "no";

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";

                // Prepare initial data 
                // ... Remove sessions
                Session.Remove("arrayCompanyLevelsSelected");
                Session.Remove("arrayCompanyLevelsSelected2");
                Session.Remove("companyLevelManagersDummy");
                
                companyLevelsAddTDS = new CompanyLevelsAddTDS();

                // ... For team members
                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompanyLevelsAddManagers companyLevelManagers = new CompanyLevelsAddManagers(companyLevelsAddTDS);
                companyLevelManagers.LoadAll(companyId);

                Session["companyLevelsAddTDS"] = companyLevelsAddTDS;
                Session["companyLevelManagers"] = companyLevelsAddTDS.CompanyLevelManagers;

                // ... For Company Levels
                companyLevelsTDS = new CompanyLevelsTDS();
                CompanyLevel companyLevel = new CompanyLevel(companyLevelsTDS);
                companyLevel.Load(int.Parse(hdfCompanyId.Value));
                
                Session["companyLevelsTDS"] = companyLevelsTDS;

                GetNodeForCompanyLevel(tvCompanyLevelsRoot.Nodes, 0);
                GetNodeForCompanyLevel(tvCompanyLevelsRoot2.Nodes, 0);

                arrayCompanyLevelsSelected = new ArrayList();
                arrayCompanyLevelsSelected2 = new ArrayList();
                
                Session["arrayCompanyLevelsSelected"] = arrayCompanyLevelsSelected;
                Session["arrayCompanyLevelsSelected2"] = arrayCompanyLevelsSelected2;

                wzCompanyLevelsAdd.ActiveStepIndex = 0;
                StepOperationIn();
            }
            else
            {
                // Restore tables
                companyLevelsTDS = (CompanyLevelsTDS)Session["companyLevelsTDS"];
                companyLevelsAddTDS = (CompanyLevelsAddTDS)Session["companyLevelsAddTDS"];
                companyLevelManagers = (CompanyLevelsAddTDS.CompanyLevelManagersDataTable)Session["companyLevelManagers"];
                arrayCompanyLevelsSelected = (ArrayList)Session["arrayCompanyLevelsSelected"];
                arrayCompanyLevelsSelected2 = (ArrayList)Session["arrayCompanyLevelsSelected2"];
            }
        }






        #region Wizard navigation events

        // ////////////////////////////////////////////////////////////////////////
        // WIZARD NAVIGATION EVENTS
        //

        protected void Wizard_ActiveStepChanged(object sender, EventArgs e)
        {
            if (ViewState["StepFrom"] != null)
            {
                switch (wzCompanyLevelsAdd.ActiveStep.Name)
                {
                    case "Operation":
                        StepOperationIn();
                        break;

                    case "Company Levels":
                        StepCompanyLevelsIn();
                        break;

                    case "Company Level Managers":
                        StepCompanyLevelManagersIn();
                        break;

                    case "Company level to replace":
                        StepCompanyLevels2In();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    default:
                        throw new Exception("Not exist the option for " + wzCompanyLevelsAdd.ActiveStep.Name + " step in company_levels_edit.Wizard_ActiveStepChanged function");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzCompanyLevelsAdd.ActiveStep.Name)
            {
                case "Operation":
                    e.Cancel = !StepOperationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Operation";
                    }
                    break;

                case "Company Levels":
                    e.Cancel = !StepCompanyLevelsNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Company Levels";

                        if (rbtnDeleteCompanyLevel.Checked)
                        {
                            bool inUse = false;
                            foreach (int companyLevelId in arrayCompanyLevelsSelected)
                            {
                                CompanyLevelsAddNew companyLevelsAddNew = new CompanyLevelsAddNew(null);
                                inUse = companyLevelsAddNew.CompanyLevelIsUsed(companyLevelId, Int32.Parse(hdfCompanyId.Value));
                            }

                            if (inUse)
                            {
                                wzCompanyLevelsAdd.ActiveStepIndex = wzCompanyLevelsAdd.WizardSteps.IndexOf(StepCompanyLevels2);
                            }
                            else
                            {
                                wzCompanyLevelsAdd.ActiveStepIndex = wzCompanyLevelsAdd.WizardSteps.IndexOf(StepSummary);
                            }
                        }
                        else
                        {
                            wzCompanyLevelsAdd.ActiveStepIndex = wzCompanyLevelsAdd.WizardSteps.IndexOf(StepCompanyLevelManagers);
                        }
                    }
                    break;
                    
                case "Company Level Managers":
                    e.Cancel = !StepCompanyLevelManagersNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "CompanyLevelManagers";
                        wzCompanyLevelsAdd.ActiveStepIndex = wzCompanyLevelsAdd.WizardSteps.IndexOf(StepSummary);
                    }
                    break;

                case "Company level to replace":
                    e.Cancel = !StepCompanyLevels2Next();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "CompanyLevels2";
                    }
                    break;

                default:
                    throw new Exception("Not exists the option for " + wzCompanyLevelsAdd.ActiveStep.Name + " step in company_levels_edit.Wizard_NextButtonClick function");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzCompanyLevelsAdd.ActiveStep.Name)
            {
                case "Company Levels":
                    e.Cancel = !StepCompanyLevelsPrevious();
                    break;

                case "Company Level Managers":
                    e.Cancel = !StepCompanyLevelManagersPrevious();
                    break;

                case "Company level to replace":
                    e.Cancel = !StepCompanyLevels2Previous();
                    break;

                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("Not exists the option for " + wzCompanyLevelsAdd.ActiveStep.Name + " step in company_levels_edit.Wizard_PreviousButtonClick function");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzCompanyLevelsAdd.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = !StepSummaryFinish();

            if (!e.Cancel)
            {
                string url = "";
                hdfUpdate.Value = "yes";

                url = "window.opener.location";
                Response.Write("<script language='javascript'> { window.opener.location.href = " + url + "; window.close();}</script>");
            }
        }



        protected void Wizard_CancelButtonClick(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }

        #endregion






        #region STEP1 - OPERATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP1 - OPERATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - OPERATION - METHODS
        //

        private void StepOperationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select an operation";
        }



        private bool StepOperationNext()
        {
            return true;
        }



        #endregion






        #region STEP2 - COMPANY LEVELS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - COMPANY LEVELS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - COMPANY LEVELS - EVENTS
        //

        protected void cvCompanyLevels_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            arrayCompanyLevelsSelected = (ArrayList)Session["arrayCompanyLevelsSelected"];
            arrayCompanyLevelsSelected.Clear();

            foreach (TreeNode nodes in tvCompanyLevelsRoot.Nodes)
            {
                GetCompanyLevelsSelected(nodes);
            }

            if (tvCompanyLevelsRoot.Nodes.Count > 0)
            {
                if (arrayCompanyLevelsSelected.Count > 0)
                {
                    if (arrayCompanyLevelsSelected.Count < 2)
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        cvCompanyLevels.ErrorMessage = "You can select only one company level";
                    }
                }
                else
                {
                    if (!rbtnAddCompanyLevel.Checked)
                    {
                        cvCompanyLevels2.ErrorMessage = "You must select at least one company level";
                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }
            }
            else
            {
                args.IsValid = true;
            }

            Session["arrayCompanyLevelsSelected"] = arrayCompanyLevelsSelected;
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - COMPANY LEVELS - METHODS
        //

        private void StepCompanyLevelsIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");

            if (rbtnAddCompanyLevel.Checked)
            {
                instruction.Text = "Please define the parent company level (optional)";
                lblName.Visible = true;
                tbxName.Visible = true;
            }

            if (rbtnEditCompanyLevel.Checked)
            {
                instruction.Text = "Please define the company level to edit";
                lblName.Visible = true;
                tbxName.Visible = true;
            }

            if (rbtnDeleteCompanyLevel.Checked)
            {
                instruction.Text = "Please define the company level to delete";
                lblName.Visible = false;
                tbxName.Visible = false;
            }

            arrayCompanyLevelsSelected.Clear();
        }



        private bool StepCompanyLevelsNext()
        {
            bool isValid = true;

            Page.Validate("StepCompanyLevels");

            if (Page.IsValid)
            {
                if (!rbtnDeleteCompanyLevel.Checked)
                {
                    Page.Validate("StepCompanyLevelsName");
                }

                isValid = Page.IsValid;
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }



        private bool StepCompanyLevelsPrevious()
        {
            return true;
        }



        private void GetCompanyLevelsSelected(TreeNode node)
        {
            if (node.ChildNodes.Count == 0)
            {
                if (node.Checked)
                {
                    arrayCompanyLevelsSelected.Add(int.Parse(node.Value));
                }
            }
            else
            {
                if (node.Checked)
                {
                    arrayCompanyLevelsSelected.Add(int.Parse(node.Value));
                }

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCompanyLevelsSelected(node2);
                }
            }
        }        

        #endregion






        #region STEP3 - COMPANY LEVEL MANAGERS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP3 - COMPANY LEVEL MANAGERS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - COMPANY LEVEL MANAGERS - AUXILIAR EVENTS
        //

        protected void cvGrdEmployees_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Initialize 
            args.IsValid = false;

            if (grdEmployees.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdEmployees.Rows)
                {
                    if (((CheckBox)row.FindControl("cbxSelected")).Checked)
                    {
                        args.IsValid = true;
                    }
                }
            }            
        } 



        protected void grdEmployees_DataBound(object sender, EventArgs e)
        {
            AddCompanyLevelEmptyFix(grdEmployees);
        }

        



        
        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - PUBLIC METHODS
        //

        public CompanyLevelsAddTDS.CompanyLevelManagersDataTable GetManagers()
        {
            companyLevelManagers = (CompanyLevelsAddTDS.CompanyLevelManagersDataTable)Session["companyLevelManagersDummy"];
            if (companyLevelManagers == null)
            {
                companyLevelManagers = (CompanyLevelsAddTDS.CompanyLevelManagersDataTable)Session["companyLevelManagers"];
            }

            return companyLevelManagers;
        }



        private void StepCompanyLevelManagersIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please define the fleet managers for this company level";

            // Filter grid            
            int companyId = Int32.Parse(hdfCompanyId.Value);
            foreach (int companyLevelIdInArray in arrayCompanyLevelsSelected)
            {
                if (!rbtnAddCompanyLevel.Checked)
                {
                    CompanyLevelsAddManagers companyLevelMangers = new CompanyLevelsAddManagers(companyLevelsAddTDS);
                    companyLevelMangers.UpdateManagers(companyLevelIdInArray, companyId);
                }

                //Tag page
                hdfCompanyLevelId.Value = companyLevelIdInArray.ToString();
            }
            
            Session["companyLevelsAddTDS"] = companyLevelsAddTDS;
            Session["companyLevelManagers"] = companyLevelsAddTDS.CompanyLevelManagers;
            companyLevelManagers = companyLevelsAddTDS.CompanyLevelManagers;
            grdEmployees.DataBind();
        }



        private bool StepCompanyLevelManagersNext()
        {
            bool isValid = true;

            Page.Validate("managers");

            if (!Page.IsValid)
            {
                isValid = false;
            }
            else
            {
                StepCompanyLevelManagersEmployeeProcessGrid();
            }

            return isValid;
        }



        private bool StepCompanyLevelManagersPrevious()
        {
            return true;
        }



        protected void AddCompanyLevelEmptyFix(GridView grdEmployees)
        {
            if (grdEmployees.Rows.Count == 0)
            {
                CompanyLevelsAddTDS.CompanyLevelManagersDataTable dt = new CompanyLevelsAddTDS.CompanyLevelManagersDataTable();
                dt.AddCompanyLevelManagersRow(-1, -1, "", false, false, false);
                Session["companyLevelManagersDummy"] = dt;

                grdEmployees.DataBind();
            }

            // Normally executes at all postbacks
            if (grdEmployees.Rows.Count == 1)
            {
                CompanyLevelsAddTDS.CompanyLevelManagersDataTable dt = (CompanyLevelsAddTDS.CompanyLevelManagersDataTable)Session["companyLevelManagersDummy"];
                if (dt != null)
                {
                    grdEmployees.Rows[0].Visible = false;
                    grdEmployees.Rows[0].Controls.Clear();
                }
            }
        }



        private void StepCompanyLevelManagersEmployeeProcessGrid()
        {
            CompanyLevelsAddManagers model = new CompanyLevelsAddManagers(companyLevelsAddTDS);
            int companyLevelId = Int32.Parse(hdfCompanyLevelId.Value);

            // update rows
            if (Session["companyLevelManagersDummy"] == null)
            {
                foreach (GridViewRow row in grdEmployees.Rows)
                {
                    int employeeId = int.Parse(grdEmployees.DataKeys[row.RowIndex].Values["EmployeeID"].ToString());
                    bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                    if (selected)
                    {
                        model.Update(companyLevelId, employeeId, selected);
                    }
                    else
                    {
                        model.Update(0, employeeId, selected);
                    }
                }

                model.Table.AcceptChanges();

                Session["companyLevelsAddTDS"] = companyLevelsAddTDS;
                Session["companyLevelManagers"] = companyLevelsAddTDS.CompanyLevelManagers;
                companyLevelManagers = companyLevelsAddTDS.CompanyLevelManagers;
            }
        }




        #endregion






        #region STEP4 - COMPANY LEVELS 2

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP4 - COMPANY LEVELS 2
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - COMPANY LEVELS - AUXILIAR EVENTS
        //

        protected void cvCompanyLevels2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            arrayCompanyLevelsSelected2 = (ArrayList)Session["arrayCompanyLevelsSelected2"];
            arrayCompanyLevelsSelected2.Clear();

            foreach (TreeNode nodes in tvCompanyLevelsRoot2.Nodes)
            {
                GetCompanyLevelsSelected2(nodes);
            }

            if (tvCompanyLevelsRoot2.Nodes.Count > 0)
            {
                if (arrayCompanyLevelsSelected2.Count > 0)
                {
                    if (arrayCompanyLevelsSelected2.Count < 2)
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        cvCompanyLevels2.ErrorMessage = "You can select only one company level";
                    }
                }
                else
                {
                    cvCompanyLevels2.ErrorMessage = "You must select at least one company level";
                }
            }
            else
            {
                args.IsValid = true;
            }

            Session["arrayCompanyLevelsSelected2"] = arrayCompanyLevelsSelected2;
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - COMPANY LEVELS 2 - METHODS
        //

        private void StepCompanyLevels2In()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please define the company level to replace";           
        }



        private bool StepCompanyLevels2Next()
        {
            bool isValid = true;

            Page.Validate("StepCompanyLevels2");

            if (!Page.IsValid)
            {
                isValid = false;
            }

            return isValid;
        }



        private bool StepCompanyLevels2Previous()
        {
            return true;
        }



        private void GetCompanyLevelsSelected2(TreeNode node)
        {
            if (node.ChildNodes.Count == 0)
            {
                if (node.Checked)
                {
                    arrayCompanyLevelsSelected2.Add(int.Parse(node.Value));
                }
            }
            else
            {
                if (node.Checked)
                {
                    arrayCompanyLevelsSelected2.Add(int.Parse(node.Value));
                }

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCompanyLevelsSelected2(node2);
                }
            }
        }
        

        #endregion






        #region STEP5 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP5 - SUMMARY
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - SUMMARY - METHODS
        //

        private void StepSummaryIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Summary";
            hdfUpdate.Value = "yes";

            // Operation
            if (rbtnAddCompanyLevel.Checked) tbxSummary.Text = "Operation: Add company level";
            if (rbtnDeleteCompanyLevel.Checked) tbxSummary.Text = "Operation: Delete company level";
            if (rbtnEditCompanyLevel.Checked) tbxSummary.Text = "Operation: Edit company level";

            // Update managers
            int companyId = Int32.Parse(hdfCompanyId.Value);
            foreach (int companyLevelIdInArray in arrayCompanyLevelsSelected)
            {
                if (rbtnDeleteCompanyLevel.Checked)
                {
                    CompanyLevelsAddManagers companyLevelMangers = new CompanyLevelsAddManagers(companyLevelsAddTDS);
                    companyLevelMangers.UpdateManagers(companyLevelIdInArray, companyId);
                }

                //Tag page
                hdfCompanyLevelId.Value = companyLevelIdInArray.ToString();
            }

            Session["companyLevelsAddTDS"] = companyLevelsAddTDS;
            Session["companyLevelManagers"] = companyLevelsAddTDS.CompanyLevelManagers;
            companyLevelManagers = companyLevelsAddTDS.CompanyLevelManagers;


            // Company Levels
            if (!rbtnDeleteCompanyLevel.Checked)
            {
                if (arrayCompanyLevelsSelected.Count > 0)
                {
                    foreach (int companyLevelIdInArray in arrayCompanyLevelsSelected)
                    {
                        CompanyLevelGateway companyLevelGateway = new CompanyLevelGateway();
                        companyLevelGateway.LoadByCompanyLevelId(companyLevelIdInArray, int.Parse(hdfCompanyId.Value));

                        tbxSummary.Text += "\nParent company level: " + companyLevelGateway.GetName(companyLevelIdInArray);
                    }
                }
                else
                {
                    tbxSummary.Text += "\nParent company level: (Empty)";
                }
            }            

            // Name
            if (!rbtnDeleteCompanyLevel.Checked)
            {
                tbxSummary.Text += "\nName: " + tbxName.Text.Trim();
            }
            else
            {
                foreach (int companyLevelIdInArray in arrayCompanyLevelsSelected)
                {
                    CompanyLevelGateway companyLevelGateway = new CompanyLevelGateway();
                    companyLevelGateway.LoadByCompanyLevelId(companyLevelIdInArray, int.Parse(hdfCompanyId.Value));

                    tbxSummary.Text += "\nName: " + companyLevelGateway.GetName(companyLevelIdInArray);
                }
            }

            // Unit Of Measurement
            tbxSummary.Text += "\nUnit Of Measurement: " + tbxUnitsUnitOfMeasurement.Text.Trim();


            // Managers
            CompanyLevelsAddManagers companyLevelManagersForSummary = new CompanyLevelsAddManagers(companyLevelsAddTDS);
            tbxSummary.Text += "\nManagers: " + companyLevelManagersForSummary.GetManagers();
        }



        private bool StepSummaryPrevious()
        {
            return true;
        }



        private bool StepSummaryFinish()
        {
            if (Page.IsValid)
            {
                int companyId = Convert.ToInt32(Session["companyID"]);
                int? companyLevelId = null;

                foreach (int companyLevelIdInArray in arrayCompanyLevelsSelected)
                {
                    companyLevelId = companyLevelIdInArray;
                }

                if (rbtnAddCompanyLevel.Checked)
                {                    
                    CompanyLevelsAddNew companyLevelsAddNew = new CompanyLevelsAddNew(companyLevelsAddTDS);
                    companyLevelsAddNew.Insert(null, null, tbxName.Text.Trim(), companyLevelId, false, companyId, false, tbxUnitsUnitOfMeasurement.Text.Trim());
                }

                if (rbtnEditCompanyLevel.Checked)
                {
                    CompanyLevelsAddNew companyLevelsAddNew = new CompanyLevelsAddNew(companyLevelsAddTDS);
                    companyLevelsAddNew.Insert(companyLevelId, null, tbxName.Text.Trim(), null, false, companyId, true, tbxUnitsUnitOfMeasurement.Text.Trim());
                }

                if (rbtnDeleteCompanyLevel.Checked)
                {
                    int? newCompanyLevelId = null;

                    if (arrayCompanyLevelsSelected2.Count > 0)
                    {
                        foreach (int companyLevelId2 in arrayCompanyLevelsSelected2)
                        {
                            newCompanyLevelId = companyLevelId2;
                        }
                    }

                    CompanyLevelsAddNew companyLevelsAddNew = new CompanyLevelsAddNew(companyLevelsAddTDS);
                    companyLevelsAddNew.Insert(companyLevelId, newCompanyLevelId, tbxName.Text.Trim(), null, true, companyId, true, tbxUnitsUnitOfMeasurement.Text.Trim());

                    // Delete company level managers
                    CompanyLevelsAddManagers companyLevelsAddManagers = new CompanyLevelsAddManagers(companyLevelsAddTDS);
                    companyLevelsAddManagers.DeleteAll();
                }
                
                // Store database
                Session["companyLevelsAddTDS"] = companyLevelsAddTDS;

                // Save
                Save();

                hdfUpdate.Value = "yes";

                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS 
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizard title
            Label title = (Label)this.Master.FindControl("lblTitle");
            title.Text = "Company Levels";
        }



        private void GetNodeForCompanyLevel(TreeNodeCollection nodes, int parentId)
        {
            Int32 thisId;
            String thisName;

            DataRow[] children = companyLevelsTDS.Tables["LFS_FM_COMPANYLEVEL"].Select("ParentID='" + parentId + "'");

            // No child nodes, exit function
            if (children.Length == 0) return;

            foreach (DataRow child in children)
            {
                // Step 1
                thisId = Convert.ToInt32(child.ItemArray[0]);

                // Step 2
                thisName = Convert.ToString(child.ItemArray[1]);

                // Step 3
                TreeNode newNode = new TreeNode(thisName, thisId.ToString());
                newNode.ShowCheckBox = true;
                newNode.SelectAction = TreeNodeSelectAction.None;

                // Step 4
                nodes.Add(newNode);
                newNode.ToggleExpandState();

                // Step 5
                GetNodeForCompanyLevel(newNode.ChildNodes, thisId);
            }
        }



        private void RegisterClientScripts()
        {

            // Register client-side events
            HtmlGenericControl body = (HtmlGenericControl)Page.Master.FindControl("myBody");
            body.Attributes.Add("onunload", "OnUnload();");

            // Register content variables
            string contentVariables = "";
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./company_levels_edit.js");
        }



        private void Save()
        {
            // Save to database
            DB.Open();
            DB.BeginTransaction();
            try
            {
                int newCompanyLevelIdForInsert = 0;

                // Save companyLevels
                CompanyLevelsAddNew companyLevelsAddNew = new CompanyLevelsAddNew(companyLevelsAddTDS);
                newCompanyLevelIdForInsert = companyLevelsAddNew.Save();

                // Save companyLevels managers
                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompanyLevelsAddManagers companyLevelsAddManagers = new CompanyLevelsAddManagers(companyLevelsAddTDS);
                companyLevelsAddManagers.Save(newCompanyLevelIdForInsert, companyId);
                
                // Store datasets
                companyLevelsAddTDS.AcceptChanges();
                Session["companyLevelsAddTDS"] = companyLevelsAddTDS;

                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



    }
}

