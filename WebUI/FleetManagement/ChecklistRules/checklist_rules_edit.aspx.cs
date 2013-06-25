using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.FleetManagement.Categories;
using LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.BL.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.BL.FleetManagement.Services;
using LiquiForce.LFSLive.BL.FleetManagement.Units;
using LiquiForce.LFSLive.DA.FleetManagement.Categories;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.ChecklistRules
{
    /// <summary>
    /// checklist_rules_edit
    /// </summary>
    public partial class checklist_rules_edit : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected RuleTDS ruleTDS;
        protected CategoriesTDS categoriesTDS;
        protected CompanyLevelsTDS companyLevelsTDS;
        protected ArrayList arrayCategoriesSelectedForEdit;
        protected ArrayList arrayCompanyLevelsSelectedForEdit;
        protected ArrayList arrayUnitsSelectedForEdit;





        
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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_CHECKLISTRULES_VIEW"]) && Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_CHECKLISTRULES_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["rule_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in checklist_rules_edit.aspx");
                }

                // If comming from 
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfRuleId.Value = Request.QueryString["rule_id"].ToString();
                hdfCheckUnitsFlag.Value = "No";

                int companyId = Int32.Parse(hdfCompanyId.Value);
                int ruleId = Int32.Parse(hdfRuleId.Value);

                // ... Checklist_rules_navigator.aspx
                if (Request.QueryString["source_page"] == "checklist_rules_navigator.aspx")
                {
                    ViewState["update"] = "no";

                    arrayCategoriesSelectedForEdit = new ArrayList();
                    arrayCompanyLevelsSelectedForEdit = new ArrayList();
                    arrayUnitsSelectedForEdit = new ArrayList();
                    Session["arrayCategoriesSelectedForEdit"] = arrayCategoriesSelectedForEdit;
                    Session["arrayCompanyLevelsSelectedForEdit"] = arrayCompanyLevelsSelectedForEdit;
                    Session["arrayUnitsSelectedForEdit"] = arrayUnitsSelectedForEdit;

                    // ... ... For rule
                    ruleTDS = new RuleTDS();
                    LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.Rule rule = new LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.Rule(ruleTDS);
                    rule.LoadByRuleId(ruleId, companyId);

                    // ... ... For Categories
                    categoriesTDS = new CategoriesTDS();
                    Category category = new Category(categoriesTDS);
                    category.Load(int.Parse(hdfCompanyId.Value));

                    // ... ... For Company Levels
                    companyLevelsTDS = new CompanyLevelsTDS();
                    CompanyLevel companyLevel = new CompanyLevel(companyLevelsTDS);
                    companyLevel.Load(int.Parse(hdfCompanyId.Value));

                    // Store dataset
                    Session["ruleTDS"] = ruleTDS;
                    Session["categoriesTDSForChecklist"] = categoriesTDS;
                    Session["companyLevelsTDS"] = companyLevelsTDS;
                }

                // ... Checklist_rules_add.aspx
                if (Request.QueryString["source_page"] == "checklist_rules_add.aspx")
                {
                    ViewState["update"] = "yes";

                    arrayCategoriesSelectedForEdit = new ArrayList();
                    arrayCompanyLevelsSelectedForEdit = new ArrayList();
                    arrayUnitsSelectedForEdit = new ArrayList();
                    Session["arrayCategoriesSelectedForEdit"] = arrayCategoriesSelectedForEdit;
                    Session["arrayCompanyLevelsSelectedForEdit"] = arrayCompanyLevelsSelectedForEdit;
                    Session["arrayUnitsSelectedForEdit"] = arrayUnitsSelectedForEdit;

                    // ... ... For rule
                    ruleTDS = new RuleTDS();
                    LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.Rule rule = new LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.Rule(ruleTDS);
                    rule.LoadByRuleId(ruleId, companyId);

                    // ... ... For Categories
                    categoriesTDS = new CategoriesTDS();
                    Category category = new Category(categoriesTDS);
                    category.Load(int.Parse(hdfCompanyId.Value));

                    // ... ... For Company Levels
                    companyLevelsTDS = new CompanyLevelsTDS();
                    CompanyLevel companyLevel = new CompanyLevel(companyLevelsTDS);
                    companyLevel.Load(int.Parse(hdfCompanyId.Value));

                    // Store dataset
                    Session["ruleTDS"] = ruleTDS;
                    Session["categoriesTDSForChecklist"] = categoriesTDS;
                    Session["companyLevelsTDS"] = companyLevelsTDS;
                }

                // ... Checklist_rules_delete.aspx or checklist_rules_summary.aspx 
                if ((Request.QueryString["source_page"] == "checklist_rules_delete.aspx") || (Request.QueryString["source_page"] == "checklist_rules_summary.aspx"))
                {
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    ruleTDS = (RuleTDS)Session["ruleTDS"];
                    categoriesTDS = (CategoriesTDS)Session["categoriesTDSForChecklist"];
                    companyLevelsTDS = (CompanyLevelsTDS)Session["companyLevelsTDS"];

                    arrayCategoriesSelectedForEdit = new ArrayList();
                    arrayCompanyLevelsSelectedForEdit = new ArrayList();
                    arrayUnitsSelectedForEdit = new ArrayList();
                    Session["arrayCategoriesSelectedForEdit"] = arrayCategoriesSelectedForEdit;
                    Session["arrayCompanyLevelsSelectedForEdit"] = arrayCompanyLevelsSelectedForEdit;
                    Session["arrayUnitsSelectedForEdit"] = arrayUnitsSelectedForEdit;
                }

                // Load data for current rule                
                LoadData(ruleId);

                // Databind
                Page.DataBind();               
            }
            else
            {
                // Restore datasets
                ruleTDS = (RuleTDS)Session["ruleTDS"];
                categoriesTDS = (CategoriesTDS)Session["categoriesTDSForChecklist"];
                companyLevelsTDS = (CompanyLevelsTDS)Session["companyLevelsTDS"];

                arrayCategoriesSelectedForEdit = (ArrayList)Session["arrayCategoriesSelectedForEdit"];
                arrayCompanyLevelsSelectedForEdit = (ArrayList)Session["arrayCompanyLevelsSelectedForEdit"];
                arrayUnitsSelectedForEdit = (ArrayList)Session["arrayUnitsSelectedForEdit"];
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "FleetManagement";

            int ruleId = Int32.Parse(hdfRuleId.Value);
            foreach (int categoryId in arrayCategoriesSelectedForEdit)
            {
                // Mark selected units                
                if (cbxlUnitsSelected.Items.Count > 0)
                {
                    RuleCategoryUnitsGateway ruleCategoryUnitsGateway = new RuleCategoryUnitsGateway();
                    foreach (ListItem lst in cbxlUnitsSelected.Items)
                    {
                        if (ruleCategoryUnitsGateway.IsUsedInRuleCategoryUnits(ruleId, categoryId, Int32.Parse(lst.Value)))
                        {
                            lst.Selected = true;
                            arrayUnitsSelectedForEdit.Add(int.Parse(lst.Value));
                            Session["arrayUnitsSelectedForEdit"] = arrayUnitsSelectedForEdit;
                        }
                    }
                }                
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
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



        protected void cvCategories_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;

            if (arrayCategoriesSelectedForEdit.Count>0)
            {
                    args.IsValid = true;             
            }
        }



        protected void cvCompanyLevels_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if (arrayCompanyLevelsSelectedForEdit.Count > 0)
            {
                args.IsValid = true;
            }
        }



        protected void cvUnits_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            StringBuilder errorMessage = new StringBuilder();

            // Validate for save and apply only
            if (hdfCheckUnitsFlag.Value == "Yes")
            {
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
            else
            {
                args.IsValid = true;
            }

            if (args.IsValid)
            {
                foreach (ListItem lst in cbxlUnitsSelected.Items)
                {
                    if (!lst.Selected)
                    {
                        ServiceInformationBasicInformation model = new ServiceInformationBasicInformation();
                        model.LoadInProgressByUnitIdRuleId(Int32.Parse(lst.Value), Int32.Parse(hdfRuleId.Value), int.Parse(hdfCompanyId.Value));

                        if (model.Table.Rows.Count > 0)
                        {                            
                            errorMessage.Append(string.Format("The unit {0} have pending service requests, please complete them before unchecking from checklist</br>", lst.Text));
                        }
                    }
                }
            }

            if (errorMessage.Length > 0)
            {
                args.IsValid = false;
                cvUnits.ErrorMessage = errorMessage.ToString();
            }
        }



        protected void tvCategoriesRoot_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            // Validate to load checked units
            hdfCheckUnitsFlag.Value = "No";

            // Get categories
            arrayCategoriesSelectedForEdit.Clear();
            foreach (TreeNode nodes in tvCategoriesRoot.Nodes)
            {
                GetCategoriesSelected(nodes);
            }

            // Load Units
            int companyId = Int32.Parse(hdfCompanyId.Value);
            string category = "";
            UnitsList unitsList = new UnitsList(new DataSet());

            foreach (int categoryId in arrayCategoriesSelectedForEdit)
            {
                CategoryGateway categoryGateway = new CategoryGateway();

                //Verify the location of the unit
                foreach (int companyLevelId in arrayCompanyLevelsSelectedForEdit)
                {
                    // Load the unit if corresponds
                    categoryGateway.LoadByCategoryId(categoryId, Int32.Parse(hdfCompanyId.Value));
                    category = categoryGateway.GetName(categoryId);

                    unitsList.LoadAndAddItemByCategoryCompanyLevelId(category, companyLevelId, companyId);                    
                }
            }

            if (unitsList.Table != null)
            {
                cbxlUnitsSelected.DataSource = RemoveDuplicateRows(unitsList.Table, "UnitID");
                cbxlUnitsSelected.DataValueField = "UnitID";
                cbxlUnitsSelected.DataTextField = "UnitCode";
                cbxlUnitsSelected.DataBind();

                // Total units
                lblTotalUnits.Text = "Total Units: " + cbxlUnitsSelected.Items.Count;
            }
            else
            {
                // Total units
                lblTotalUnits.Text = "Total Units: 0";
            }
        }
        




        
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mSave":
                    this.Save();
                    break;

                case "mApply":
                    this.Apply();
                    break;

                case "mCancel":
                    string url = "";
                    if (Request.QueryString["source_page"] == "checklist_rules_navigator.aspx" || Request.QueryString["source_page"] == "checklist_rules_add.aspx")
                    {
                        url = "./checklist_rules_navigator.aspx?source_page=checklist_rules_edit.aspx&rule_id=" + hdfRuleId.Value + "&update=" + (string)ViewState["update"];
                    }

                    if (Request.QueryString["source_page"] == "checklist_rules_summary.aspx")
                    {
                        url = "./checklist_rules_summary.aspx?source_page=checklist_rules_edit.aspx&rule_id=" + hdfRuleId.Value + "&update=" + (string)ViewState["update"];
                    }
                    Response.Redirect(url);
                    break;
            }
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mSearch":
                    url = "./checklist_rules_navigator.aspx?source_page=lm";
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfRuleId = '" + hdfRuleId.ClientID + "';";
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';"; 

            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");             

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./checklist_rules_edit.js");
        }



        private void LoadData(int ruleId)
        {
            RuleGateway ruleGateway = new RuleGateway(ruleTDS);

            if (ruleGateway.Table.Rows.Count > 0)
            {
                tbxName.Text = ruleGateway.GetName(ruleId);
                cbxMtoDot.Checked = ruleGateway.GetMto(ruleId);
                tbxDescription.Text = ruleGateway.GetDescription(ruleId);
                tbxFrecuency.Text = ruleGateway.GetFrequency(ruleId);
                tbxServicesRequestDaysBefore.Text = ""; if (ruleGateway.GetServiceRequestDays(ruleId).HasValue) tbxServicesRequestDaysBefore.Text = ((int)(ruleGateway.GetServiceRequestDays(ruleId))).ToString();

                // Load Trees
                GetNodeForCategory(tvCategoriesRoot.Nodes, 0);
                GetNodeForCompanyLevels(tvCompanyLevelsRoot.Nodes, 0);

                // Load Units
                int companyId = Int32.Parse(hdfCompanyId.Value);
                string category = "";
                UnitsList unitsList = new UnitsList(new DataSet());

                foreach (int categoryId in arrayCategoriesSelectedForEdit)
                {
                    CategoryGateway categoryGateway = new CategoryGateway();

                    //Verify the location of the unit
                    foreach (int companyLevelId in arrayCompanyLevelsSelectedForEdit)
                    {
                        // Load the unit if corresponds
                        categoryGateway.LoadByCategoryId(categoryId, Int32.Parse(hdfCompanyId.Value));
                        category = categoryGateway.GetName(categoryId);

                        unitsList.LoadAndAddItemByCategoryCompanyLevelId(category, companyLevelId, companyId);                        
                    }
                }

                if (unitsList.Table != null)
                {
                    cbxlUnitsSelected.DataSource = RemoveDuplicateRows(unitsList.Table, "UnitID");
                    cbxlUnitsSelected.DataValueField = "UnitID";
                    cbxlUnitsSelected.DataTextField = "UnitCode";
                    cbxlUnitsSelected.DataBind();

                    // Total units
                    lblTotalUnits.Text = "Total Units: " + cbxlUnitsSelected.Items.Count;
                }
                else
                {
                    // Total units
                    lblTotalUnits.Text = "Total Units: 0";
                }
            }
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



        private void GetNodeForCategory(TreeNodeCollection nodes, int parentId)
        {
            Int32 thisId;
            String thisName;
            RuleCategoryGateway ruleCategoryGateway = new RuleCategoryGateway(null);

            DataRow[] children = categoriesTDS.Tables["LFS_FM_CATEGORY"].Select("ParentID='" + parentId + "'");

            // No child nodes, exit function
            if (children.Length == 0) return;

            foreach (DataRow child in children)
            {
                // Step 1
                thisId = Convert.ToInt32(child.ItemArray[0]);

                // Step 2
                thisName = Convert.ToString(child.ItemArray[2]);

                // Step 3
                TreeNode newNode = new TreeNode(thisName, thisId.ToString());
                newNode.ShowCheckBox = true;
                newNode.SelectAction = TreeNodeSelectAction.None;

                // Step 4
                if (ruleCategoryGateway.IsUsedInRuleCategory(Int32.Parse(hdfRuleId.Value), thisId))
                {
                    newNode.Checked = true;
                    arrayCategoriesSelectedForEdit.Add(int.Parse(newNode.Value));
                    Session["arrayCategoriesSelectedForEdit"] = arrayCategoriesSelectedForEdit;
                }

                // Step 5
                nodes.Add(newNode);
                newNode.ToggleExpandState();

                // Step 6
                GetNodeForCategory(newNode.ChildNodes, thisId);
            }
        }



        private void GetNodeForCompanyLevels(TreeNodeCollection nodes, int parentId)
        {
            Int32 thisId;
            string thisName;
            RuleCompanyLevelGateway ruleCompanyLevelGateway = new RuleCompanyLevelGateway(null);

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
                if (ruleCompanyLevelGateway.IsUsedInRuleCompanyLevel(Int32.Parse(hdfRuleId.Value), thisId))
                {
                    newNode.Checked = true;
                    arrayCompanyLevelsSelectedForEdit.Add(int.Parse(newNode.Value));
                    Session["arrayCompanyLevelsSelectedForEdit"] = arrayCompanyLevelsSelectedForEdit;
                }

                // Step 5
                nodes.Add(newNode);
                newNode.ToggleExpandState();

                // Step 6
                GetNodeForCompanyLevels(newNode.ChildNodes, thisId);
            }
        }



        private void Save()
        {
            // Validate page
            hdfCheckUnitsFlag.Value = "Yes";
            Page.Validate();
            if (Page.IsValid)
            {
                string url = "";                
                
                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int ruleId = Int32.Parse(hdfRuleId.Value);

                // Get parameters
                string name = ""; if (tbxName.Text != "") name = tbxName.Text;
                bool mto = false; if (cbxMtoDot.Checked) mto = true;
                string description = ""; if (tbxDescription.Text != "") description = tbxDescription.Text;
                string frequency = tbxFrecuency.Text;
                bool alarm = false;
                int? alarmDaysBefore = null;
                bool serviceRequest = true;
                int? serviceRequestDaysBefore = null; if (tbxServicesRequestDaysBefore.Text != "") serviceRequestDaysBefore = Convert.ToInt32(tbxServicesRequestDaysBefore.Text);
                
                // Save last unitsSelected
                arrayUnitsSelectedForEdit.Clear();
                if (cbxlUnitsSelected.Items.Count > 0)
                {
                    foreach (ListItem lst in cbxlUnitsSelected.Items)
                    {
                        if (lst.Selected) arrayUnitsSelectedForEdit.Add(Int32.Parse(lst.Value));
                    }

                    Session["arrayUnitsSelectedForEdit"] = arrayUnitsSelectedForEdit;
                }

                // Save to database
                DB.Open();
                DB.BeginTransaction();
                try
                {                                       
                    // Save Data
                    ChecklistRulesDetails checklistRulesDetails = new ChecklistRulesDetails(ruleTDS);
                    checklistRulesDetails.Save(ruleId, name, description, mto, frequency, alarm, alarmDaysBefore, serviceRequest, serviceRequestDaysBefore, false, companyId, arrayCategoriesSelectedForEdit, arrayCompanyLevelsSelectedForEdit, arrayUnitsSelectedForEdit);
                   
                    DB.CommitTransaction();

                    // Store datasets
                    ruleTDS.AcceptChanges();
                    Session["ruleTDS"] = ruleTDS;
                    Session["categoriesTDSForChecklist"] = categoriesTDS;
                    Session["companyLevelsTDS"] = companyLevelsTDS;
                }
                catch (Exception ex)
                {
                    DB.RollbackTransaction();

                    url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                    Response.Redirect(url);
                }

                // Redirect                
                if (Request.QueryString["source_page"] == "checklist_rules_navigator.aspx" || Request.QueryString["source_page"] == "checklist_rules_add.aspx")
                {
                    url = "./checklist_rules_navigator.aspx?source_page=checklist_rules_edit.aspx&rule_id=" + hdfRuleId.Value + "&update=yes";
                    Response.Redirect(url);
                }

                if (Request.QueryString["source_page"] == "checklist_rules_summary.aspx")
                {
                    url = "./checklist_rules_summary.aspx?source_page=checklist_rules_edit.aspx&rule_id=" + hdfRuleId.Value + "&update=yes";
                    Response.Redirect(url);
                }                
            }
        }



        private void Apply()
        {
            // Validate page
            hdfCheckUnitsFlag.Value = "Yes";
            Page.Validate();
            if (Page.IsValid)
            {
                string url = "";
                
                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int ruleId = Int32.Parse(hdfRuleId.Value);

                // Get parameters
                string name = ""; if (tbxName.Text != "") name = tbxName.Text;
                bool mto = false; if (cbxMtoDot.Checked) mto = true;
                string description = ""; if (tbxDescription.Text != "") description = tbxDescription.Text;
                string frequency = tbxFrecuency.Text;
                bool alarm = false;
                int? alarmDaysBefore = null;
                bool serviceRequest = true;
                int? serviceRequestDaysBefore = null; if (tbxServicesRequestDaysBefore.Text != "") serviceRequestDaysBefore = Convert.ToInt32(tbxServicesRequestDaysBefore.Text);

                // Save last unitsSelected
                arrayUnitsSelectedForEdit.Clear();
                if (cbxlUnitsSelected.Items.Count > 0)
                {
                    foreach (ListItem lst in cbxlUnitsSelected.Items)
                    {
                        if (lst.Selected) arrayUnitsSelectedForEdit.Add(Int32.Parse(lst.Value));
                    }

                    Session["arrayUnitsSelectedForEdit"] = arrayUnitsSelectedForEdit;
                }

                // Save to database
                DB.Open();
                DB.BeginTransaction();

                try
                {
                    ChecklistRulesDetails checklistRulesDetails = new ChecklistRulesDetails(ruleTDS);
                    checklistRulesDetails.Save(ruleId, name, description, mto, frequency, alarm, alarmDaysBefore, serviceRequest, serviceRequestDaysBefore, false, companyId, arrayCategoriesSelectedForEdit, arrayCompanyLevelsSelectedForEdit, arrayUnitsSelectedForEdit);

                    DB.CommitTransaction();
                }
                catch (Exception ex)
                {
                    DB.RollbackTransaction();

                    url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                    Response.Redirect(url);
                }                             
            }
        }

        
        
        private void GetCategoriesSelected(TreeNode node)
        {
            if (node.ChildNodes.Count == 0)
            {
                if (node.Checked)
                {
                    arrayCategoriesSelectedForEdit.Add(int.Parse(node.Value));
                }
            }
            else
            {
                if (node.Checked)
                {
                    arrayCategoriesSelectedForEdit.Add(int.Parse(node.Value));
                }

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCategoriesSelected(node2);
                }
            }
        }

        

    }
}