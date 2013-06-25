using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.FleetManagement.Categories;
using LiquiForce.LFSLive.BL.FleetManagement.Categories;
using LiquiForce.LFSLive.BL.FleetManagement.Units;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.BL.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.ChecklistRules
{
    /// <summary>
    /// checklist_rules_add
    /// </summary>
    public partial class checklist_rules_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ChecklistRulesAddTDS checklistRulesAddTDS;
        protected CategoriesTDS categoriesTDS;
        protected CompanyLevelsTDS companyLevelsTDS;
        protected ArrayList arrayCategoriesSelected;
        protected ArrayList arrayUnitsSelected;
        protected ArrayList arrayCompanyLevelsSelected;





        
        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Security check
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_CHECKLISTRULES_VIEW"]) && Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_CHECKLISTRULES_ADD"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfUpdate.Value = "no";

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";

                // Prepare initial data 
                checklistRulesAddTDS = new ChecklistRulesAddTDS();
                Session["checklistRulesAddTDS"] = checklistRulesAddTDS;

                arrayCategoriesSelected = new ArrayList();
                arrayCompanyLevelsSelected = new ArrayList();
                arrayUnitsSelected = new ArrayList();
                Session["arrayCategoriesSelected"] = arrayCategoriesSelected;
                Session["arrayCompanyLevelsSelected"] = arrayCompanyLevelsSelected;
                Session["arrayUnitsSelected"] = arrayUnitsSelected;

                // ... for frecuency
                RuleFrecuencyList ruleFrecuency = new RuleFrecuencyList();
                ruleFrecuency.LoadAndAddItem("(Select a frequency)", int.Parse(hdfCompanyId.Value));
                ddlFrequency.DataSource = ruleFrecuency.Table;
                ddlFrequency.DataValueField = "Frequency";
                ddlFrequency.DataTextField = "Frequency";
                ddlFrequency.DataBind();

                // ... for Categories
                categoriesTDS = new CategoriesTDS();
                Category category = new Category(categoriesTDS);
                category.Load(int.Parse(hdfCompanyId.Value));
                GetNodeForCategory(tvCategoriesRoot.Nodes, 0);

                // .. for Company Levels
                companyLevelsTDS = new CompanyLevelsTDS();
                CompanyLevel companyLevel = new CompanyLevel(companyLevelsTDS);
                companyLevel.Load(int.Parse(hdfCompanyId.Value));
                GetNodeForCompanyLevels(tvCompanyLevelsRoot.Nodes, 0);

                StepGeneralInformationIn();
            }
            else
            {
                checklistRulesAddTDS = (ChecklistRulesAddTDS)Session["checklistRulesAddTDS"];
                arrayCategoriesSelected = (ArrayList)Session["arrayCategoriesSelected"];
                arrayCompanyLevelsSelected = (ArrayList)Session["arrayCompanyLevelsSelected"];
                arrayUnitsSelected = (ArrayList)Session["arrayUnitsSelected"];
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
                switch (wzChecklistRulesAdd.ActiveStep.Name)
                {
                    case "General Information":
                        StepGeneralInformationIn();
                        break;

                    case "Scheduling Options":
                        StepSchedulingOptionsIn();
                        break;
                    
                    case "Company Levels":
                        StepCompanyLevelsIn();
                        break;

                    case "Categories":
                        StepCategoriesIn();                        
                        break;

                    case "Units":
                        StepUnitsIn();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    case "Final Step":
                        StepFinalStepIn();
                        wzChecklistRulesAdd.ActiveStepIndex = wzChecklistRulesAdd.WizardSteps.IndexOf(StepFinalStep);
                        break;

                    default:
                        throw new Exception("Not exist the option for " + wzChecklistRulesAdd.ActiveStep.Name + " step in checklist_rules_add.Wizard_ActiveStepChanged function");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzChecklistRulesAdd.ActiveStep.Name)
            {
                case "General Information":
                    e.Cancel = !StepGeneralInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "General Information";
                    }
                    break;

                case "Scheduling Options":
                    e.Cancel = !StepSchedulingOptionsNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Scheduling Options";
                    }
                    break;

                case "Company Levels":
                    e.Cancel = !StepCompanyLevelsNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Company Levels";
                    }
                    break; 

                case "Categories":
                    e.Cancel = !StepCategoriesNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Categories";
                    }
                    break;

                case "Units":
                    e.Cancel = !StepUnitsNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Units";
                    }
                    break;              

                default:
                    throw new Exception("Not exists the option for " + wzChecklistRulesAdd.ActiveStep.Name + " step in checklist_rules_add.Wizard_NextButtonClick function");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzChecklistRulesAdd.ActiveStep.Name)
            {
                case "Scheduling Options":
                    e.Cancel = !StepSchedulingOptionsPrevious();
                    break;

                case "Company Levels":
                    e.Cancel = !StepCompanyLevelsPrevious();
                    break;

                case "Categories":
                    e.Cancel = !StepCategoriesPrevious();
                    break;

                case "Units":
                    e.Cancel = !StepUnitsPrevious();
                    break;
                    
                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("Not exists the option for " + wzChecklistRulesAdd.ActiveStep.Name + " step in checklist_rules_add.Wizard_PreviousButtonClick function");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzChecklistRulesAdd.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = !StepSummaryFinish();
        }



        protected void Wizard_CancelButtonClick(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }

        #endregion






        #region STEP1 - GENERAL INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP1 - GENERAL INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - GENERAL INFORMATION - METHODS
        //

        private void StepGeneralInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide general information";
        }



        private bool StepGeneralInformationNext()
        {
            Page.Validate("StepGeneralInformation");

            return (Page.IsValid) ? true : false;
        }

        #endregion






        #region STEP2 - SCHEDULE OPTIONS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP2 - SCHEDULE OPTIONS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - SCHEDULE OPTIONS - AUXILIAR EVENTS
        //

        protected void cvServicesRequestDaysBefore_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Initialize 
            CustomValidator cvServicesRequestDaysBefore = (CustomValidator)source;
           
            if (args.Value.Trim() == "")
            {
                args.IsValid = false;
                cvServicesRequestDaysBefore.ErrorMessage = "Please provide a service request days before data.";
            }
            else
            {
                if (!Validator.IsValidInt32(args.Value.Trim()))
                {
                    args.IsValid = false;
                    cvServicesRequestDaysBefore.ErrorMessage = "Invalid data. (Please use an integer number)";
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - LOCATION - METHODS
        //

        private void StepSchedulingOptionsIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide scheduling options";              
        }



        private bool StepSchedulingOptionsNext()
        {
            Page.Validate("StepSchedulingOptions");

            return (Page.IsValid) ? true : false;
        }



        private bool StepSchedulingOptionsPrevious()
        {
            return true;
        }

        #endregion






        #region STEP3 - COMPANY LEVELS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP3 - COMPANY LEVELS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - COMPANY LEVELS - AUXILIAR EVENTS
        //

        protected void cvCompanyLevels_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            
            foreach (TreeNode nodes in tvCompanyLevelsRoot.Nodes)
            {
                GetCompanyLevelsSelected(nodes);
            }

            if (tvCompanyLevelsRoot.Nodes.Count > 0)
            {
                if (arrayCompanyLevelsSelected.Count > 0)
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = true;
            }

            Session["arrayCompanyLevelsSelected"] = arrayCompanyLevelsSelected;
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - COMPANY LEVELS - METHODS
        //

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


             
        private void StepCompanyLevelsIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please define company levels to which the rule will be applied";
            arrayCompanyLevelsSelected.Clear();
        }



        private bool StepCompanyLevelsNext()
        {
            Page.Validate("StepCompanyLevels");

            if (Page.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }



        private bool StepCompanyLevelsPrevious()
        {
            return true;
        }

        #endregion






        #region STEP4 - CATEGORIES

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP4 - CATEGORIES
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - CATEGORIES - AUXILIAR EVENTS
        //

        protected void cvCategories_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            
            foreach (TreeNode nodes in tvCategoriesRoot.Nodes)
            {
               GetCategoriesSelected(nodes);
            }

            if (tvCategoriesRoot.Nodes.Count > 0)
            {
                if (arrayCategoriesSelected.Count > 0)
                {
                    args.IsValid = true;
                }
            }
            else
            {
                args.IsValid = true;
            }

            Session["arrayCategoriesSelected"] = arrayCategoriesSelected;
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - CATEGORIES - METHODS
        //

        private void GetCategoriesSelected(TreeNode node)
        {
            if (node.ChildNodes.Count == 0)
            {
                if (node.Checked)
                {
                    arrayCategoriesSelected.Add(int.Parse(node.Value));
                }
            }
            else
            {
                if (node.Checked)
                {
                    arrayCategoriesSelected.Add(int.Parse(node.Value));
                }

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCategoriesSelected(node2);
                }
            }
        }



        private void StepCategoriesIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please define categories to which the rule will be applied";
            arrayCategoriesSelected.Clear();           
        }



        private bool StepCategoriesNext()
        {
            Page.Validate("StepCategories");

            return (Page.IsValid) ? true : false;
        }



        private bool StepCategoriesPrevious()
        {
            return true;
        }

        #endregion






        #region STEP5 - UNITS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP5 - UNITS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - UNITS - AUXILIAR EVENTS
        //

        protected void cvUnits_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;

            if (cbxlUnitsSelected.Items.Count > 0)
            {
                foreach (ListItem lst in cbxlUnitsSelected.Items)
                {
                    if (lst.Selected)
                    {
                        args.IsValid = true;
                    }
                }
            }
            else
            {
                args.IsValid = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - UNITS - METHODS
        //        
        
        private void StepUnitsIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select the units to which the rule will be applied";
            
            // Load Units
            int companyId = Int32.Parse(hdfCompanyId.Value);
            string category = "";
            UnitsList unitsList = new UnitsList(new DataSet());

            foreach (int categoryId in arrayCategoriesSelected)
            {
                CategoryGateway categoryGateway = new CategoryGateway();

                //Verify the location of the unit
                foreach (int companyLevelId in arrayCompanyLevelsSelected)
                {              
                    // Load the unit if corresponds
                    categoryGateway.LoadByCategoryId(categoryId, Int32.Parse(hdfCompanyId.Value));
                    category = categoryGateway.GetName(categoryId);
                
                    unitsList.LoadAndAddItemByCategoryCompanyLevelId(category, companyLevelId, companyId);                    
                }
            }
            
            // Select all units by default
            if (unitsList.Table != null)
            {
                cbxlUnitsSelected.DataSource = RemoveDuplicateRows(unitsList.Table, "UnitID");
                cbxlUnitsSelected.DataValueField = "UnitID";
                cbxlUnitsSelected.DataTextField = "UnitCode";
                cbxlUnitsSelected.DataBind();

                foreach (ListItem lst in cbxlUnitsSelected.Items)
                {
                    lst.Selected = true;
                }

                // Total units
                lblTotalUnits.Text = "Total Units: " + cbxlUnitsSelected.Items.Count;

                Session["arrayUnitsSelected"] = arrayUnitsSelected;
            }
            else
            {
                // Total units
                lblTotalUnits.Text = "Total Units: 0";
            }            
        }



        private bool StepUnitsNext()
        {
            Page.Validate("StepUnits");

            if (Page.IsValid)
            {
                // Save all selected units
                if (cbxlUnitsSelected.Items.Count > 0)
                {
                    foreach (ListItem lst in cbxlUnitsSelected.Items)
                    {
                        if (lst.Selected) arrayUnitsSelected.Add(Int32.Parse(lst.Value));
                    }

                    Session["arrayUnitsSelected"] = arrayUnitsSelected;
                }

                return true;
            }
            else
            {
                return false;
            }
        }



        private bool StepUnitsPrevious()
        {
            return true;
        }



        private DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                {
                    duplicateList.Add(drow);
                }
                else
                {
                    hTable.Add(drow[colName], string.Empty);
                }
            }

            foreach (DataRow dRow in duplicateList)
            {
                dTable.Rows.Remove(dRow);
            }

            dTable.DefaultView.Sort = "UnitCode ASC";

            return dTable.DefaultView.Table;
        }

        #endregion





        
        #region STEP6 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP6 - SUMMARY
        //
        
        // ////////////////////////////////////////////////////////////////////////
        // STEP6 - SUMMARY - METHODS
        //

        private void StepSummaryIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Summary";
            hdfUpdate.Value = "yes";

            string mto = "No"; if (cbxMtoDot.Checked) mto = "Yes";
            string generateServiceRequest = tbxServicesRequestDaysBefore.Text + " days before";
            
            string categoriesSelected = "";
            
            foreach (int categoryId in arrayCategoriesSelected)
            {
                CategoryGateway categoryGateway = new CategoryGateway();
                categoryGateway.LoadByCategoryId(categoryId, Int32.Parse(hdfCompanyId.Value));
                categoriesSelected += categoryGateway.GetName(categoryId)+ ", ";
            }

            if (categoriesSelected.Length > 2)
            {
                categoriesSelected = categoriesSelected.Substring(0, categoriesSelected.Length - 2);
            }

            string unitsSelected = "";
            
            foreach (ListItem lst in cbxlUnitsSelected.Items)
            {
                if (lst.Selected)  unitsSelected += lst.Text + ", ";                    
            }

            if (unitsSelected.Length > 2)
            {
                unitsSelected = unitsSelected.Substring(0, unitsSelected.Length - 2);
            }
            
            string companyLevelsSelected = "";
            foreach (int companyLevelId in arrayCompanyLevelsSelected)
            {
                CompanyLevelGateway companyLevelGateway = new CompanyLevelGateway();
                companyLevelGateway.LoadByCompanyLevelId(companyLevelId, Int32.Parse(hdfCompanyId.Value));
                companyLevelsSelected += companyLevelGateway.GetName(companyLevelId) + ", ";
            }

            if (companyLevelsSelected.Length > 2)
            {
                companyLevelsSelected = companyLevelsSelected.Substring(0, companyLevelsSelected.Length - 2);
            }

            tbxSummary.Text = "Name: " + tbxName.Text + "\nFixed Date: " + mto + "\nDescription: " + tbxDescription.Text + "\nFrequency: " + ddlFrequency.SelectedValue + "\nGenerate Service Request?: " + generateServiceRequest + "\nCompany Levels: " + companyLevelsSelected+ "\nCategories: " + categoriesSelected + "\nUnits: " + unitsSelected ;
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

                string name = ""; if (tbxName.Text != "") name = tbxName.Text;
                bool mto = false; if (cbxMtoDot.Checked) mto = true;
                string description = ""; if (tbxDescription.Text != "") description = tbxDescription.Text;
                string frequency = ddlFrequency.SelectedValue;
                bool alarm = false;
                int? alarmDaysBefore = null;
                bool serviceRequest = true;
                int? serviceRequestDaysBefore = null; if (tbxServicesRequestDaysBefore.Text != "") serviceRequestDaysBefore = Convert.ToInt32(tbxServicesRequestDaysBefore.Text);

                ChecklistRulesAddNew checklistRulesAddNew = new ChecklistRulesAddNew(checklistRulesAddTDS);
                checklistRulesAddNew.Insert(name, description, mto, frequency, alarm, alarmDaysBefore, serviceRequest, serviceRequestDaysBefore, false, companyId);

                // Store database
                Session["checklistRulesAddTDS"] = checklistRulesAddTDS;

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






        #region STEP7 - FINISH OPTIONS
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP7 - FINISH OPTIONS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - FINISH OPTIONS - METHODS
        //

        private void StepFinalStepIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardInstruction = "What would you like to do?";

            string url = "";

            RuleGateway ruleGateway = new RuleGateway(null);
            int ruleId = ruleGateway.GetLastRuleId();

            hdfUpdate.Value = "yes";

            url = "./checklist_rules_summary.aspx?source_page=checklist_rules_add.aspx&rule_id=" + ruleId.ToString();
            lkbtnOpenUnit.Attributes.Add("onclick", string.Format("return lkbtnOpenServiceClick('{0}');", url));

            url = "./checklist_rules_edit.aspx?source_page=checklist_rules_add.aspx&rule_id=" + ruleId.ToString();
            lkbtnEditUnit.Attributes.Add("onclick", string.Format("return lkbtnEditServiceClick('{0}');", url));

            lkbtnClose.Attributes.Add("onclick", "return lkbtnCloseClick();");
        }

        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS 
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizard title
            Label title = (Label)this.Master.FindControl("lblTitle");
            title.Text = "Add Checklist Rule";
        }






        // ////////////////////////////////////////////////////////////////////////
        // FINAL METHODS 
        //

        private void GetNodeForCategory(TreeNodeCollection nodes, int parentId)
        {
            Int32 thisId;
            String thisName;

            DataRow[] children = categoriesTDS.Tables["LFS_FM_CATEGORY"].Select("ParentID='" + parentId + "'");

            //no child nodes, exit function
            if (children.Length == 0) return;

            foreach (DataRow child in children)
            {
                // step 1
                thisId = Convert.ToInt32(child.ItemArray[0]);

                // step 2
                thisName = Convert.ToString(child.ItemArray[2]);

                // step 3
                TreeNode newNode = new TreeNode(thisName, thisId.ToString());
                newNode.ShowCheckBox = true;
                newNode.SelectAction = TreeNodeSelectAction.None;

                // step 4
                nodes.Add(newNode);
                newNode.ToggleExpandState();

                // step 5
                GetNodeForCategory(newNode.ChildNodes, thisId);
            }            
        }



        private void GetNodeForCompanyLevels(TreeNodeCollection nodes, int parentId)
        {
            Int32 thisId;
            String thisName;

            DataRow[] children = companyLevelsTDS.Tables["LFS_FM_COMPANYLEVEL"].Select("ParentID='" + parentId + "'");

            //no child nodes, exit function
            if (children.Length == 0) return;

            foreach (DataRow child in children)
            {
                // step 1
                thisId = Convert.ToInt32(child.ItemArray[0]);

                // step 2
                thisName = Convert.ToString(child.ItemArray[1]);

                // step 3
                TreeNode newNode = new TreeNode(thisName, thisId.ToString());
                newNode.ShowCheckBox = true;
                newNode.SelectAction = TreeNodeSelectAction.None;

                // step 4
                nodes.Add(newNode);
                newNode.ToggleExpandState();

                // step 5
                GetNodeForCompanyLevels(newNode.ChildNodes, thisId);
            }
        }



        private void RegisterClientScripts()
        {                       
            // Register content variables
            string contentVariables = "";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./checklist_rules_add.js");
        }



        private void Save()
        {
            // save to database
            DB.Open();
            DB.BeginTransaction();
            try
            {
                ChecklistRulesAddNew checklistRulesAddNew = new ChecklistRulesAddNew(checklistRulesAddTDS);
                checklistRulesAddNew.Save(arrayCategoriesSelected, arrayCompanyLevelsSelected, arrayUnitsSelected);

                // Store datasets
                checklistRulesAddTDS.AcceptChanges();
                Session["checklistRulesAddTDS"] = checklistRulesAddTDS;

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