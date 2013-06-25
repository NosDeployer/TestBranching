using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.FleetManagement.Categories;
using LiquiForce.LFSLive.BL.FleetManagement.Categories;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.BL.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.BL.FleetManagement.Units;
using LiquiForce.LFSLive.BL.FleetManagement.Services;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.ChecklistRules
{
    /// <summary>
    /// checklist_rules_summary
    /// </summary>
    public partial class checklist_rules_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected RuleTDS ruleTDS;
        protected CategoriesTDS categoriesTDS;
        protected CompanyLevelsTDS companyLevelsTDS;
        protected ArrayList arrayCategoriesSelected;
        protected ArrayList arrayCompanyLevelsSelected;

        



       
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in checklist_rules_summary.aspx");
                }

                // If coming from 
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfRuleId.Value = Request.QueryString["rule_id"].ToString();
                arrayCategoriesSelected = new ArrayList();
                arrayCompanyLevelsSelected = new ArrayList();

                int companyId = Int32.Parse(hdfCompanyId.Value);
                int ruleId = Int32.Parse(hdfRuleId.Value);
                                                
                // ... checklist_rules_navigator.aspx
                if (Request.QueryString["source_page"] == "checklist_rules_navigator.aspx")
                {
                    ViewState["update"] = "no";
                    
                    // ... For rule
                    ruleTDS = new RuleTDS();
                    LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.Rule rule = new LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.Rule(ruleTDS);
                    rule.LoadByRuleId(ruleId, companyId);                    

                    // ... For Categories
                    categoriesTDS = new CategoriesTDS();
                    Category category = new Category(categoriesTDS);
                    category.Load(companyId);
                    
                    // .. For Company Levels
                    companyLevelsTDS = new CompanyLevelsTDS();
                    CompanyLevel companyLevel = new CompanyLevel(companyLevelsTDS);
                    companyLevel.Load(companyId);
                    
                    // Store dataset
                    Session["ruleTDS"] = ruleTDS;
                    Session["categoriesTDSForChecklist"] = categoriesTDS;
                    Session["companyLevelsTDS"] = companyLevelsTDS;                    
                }

                // ... checklist_rules_add.aspx
                if (Request.QueryString["source_page"] == "checklist_rules_add.aspx")
                {
                    ViewState["update"] = "yes";
                    
                    // ... For rule
                    ruleTDS = new RuleTDS();
                    LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.Rule rule = new LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.Rule(ruleTDS);
                    rule.LoadByRuleId(ruleId, companyId);

                    // ... For Categories
                    categoriesTDS = new CategoriesTDS();
                    Category category = new Category(categoriesTDS);
                    category.Load(companyId);

                    // ... For Company Levels
                    companyLevelsTDS = new CompanyLevelsTDS();
                    CompanyLevel companyLevel = new CompanyLevel(companyLevelsTDS);
                    companyLevel.Load(companyId);

                    // Store dataset
                    Session["ruleTDS"] = ruleTDS;
                    Session["categoriesTDSForChecklist"] = categoriesTDS;
                    Session["companyLevelsTDS"] = companyLevelsTDS;
                }

                // ... checklist_rules_delete.aspx or checklist_rules_edit.aspx 
                if ((Request.QueryString["source_page"] == "checklist_rules_delete.aspx") || (Request.QueryString["source_page"] == "checklist_rules_edit.aspx"))
                {
                    ViewState["update"] = Request.QueryString["update"];

                    // ... For rule
                    ruleTDS = new RuleTDS();
                    LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.Rule rule = new LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.Rule(ruleTDS);
                    rule.LoadByRuleId(ruleId, companyId);

                    // ... For Categories
                    categoriesTDS = new CategoriesTDS();
                    Category category = new Category(categoriesTDS);
                    category.Load(companyId);

                    // ... For Company Levels
                    companyLevelsTDS = new CompanyLevelsTDS();
                    CompanyLevel companyLevel = new CompanyLevel(companyLevelsTDS);
                    companyLevel.Load(companyId);

                    // Store dataset
                    Session["ruleTDS"] = ruleTDS;
                    Session["categoriesTDSForChecklist"] = categoriesTDS;
                    Session["companyLevelsTDS"] = companyLevelsTDS;  
                }

                // Load Data for current rule                
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
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "FleetManagement";

            int ruleId = Int32.Parse(hdfRuleId.Value);

            foreach (int categoryId in arrayCategoriesSelected)
            {
                // Mark selected units
                RuleCategoryUnitsGateway ruleCategoryUnitsGateway = new RuleCategoryUnitsGateway();

                if (cbxlUnitsSelected.Items.Count > 0)
                {
                    foreach (ListItem lst in cbxlUnitsSelected.Items)
                    {
                        if (ruleCategoryUnitsGateway.IsUsedInRuleCategoryUnits(ruleId, categoryId, Int32.Parse(lst.Value)))
                        {
                            lst.Selected = true;
                        }
                    }
                }
            }

            ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation();
            serviceInformationBasicInformation.LoadInProgressByRuleId(ruleId, int.Parse(hdfCompanyId.Value));

            if (serviceInformationBasicInformation.Table.Rows.Count > 0)
            {
                tkrmTop.Items[1].Visible = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mEdit":
                    url = "./checklist_rules_edit.aspx?source_page=checklist_rules_summary.aspx&rule_id=" + hdfRuleId.Value + "&update=" + (string)ViewState["update"];
                    break;

                case "mDelete":
                    url = "./checklist_rules_delete.aspx?source_page=checklist_rules_summary.aspx&rule_id=" + hdfRuleId.Value + "&update=" + (string)ViewState["update"];
                    break;

                case "mLastSearch":
                    url = "./checklist_rules_navigator.aspx?source_page=checklist_rules_summary.aspx&rule_id=" + hdfRuleId.Value + "&update=" + (string)ViewState["update"];
                    break;
            }

            if (url != "") Response.Redirect(url);
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
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfRuleId = '" + hdfRuleId.ClientID + "';";
            
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./checklist_rules_summary.js");
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
                    arrayCategoriesSelected.Add(int.Parse(newNode.Value));
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
                    arrayCompanyLevelsSelected.Add(int.Parse(newNode.Value));
                }

                // Step 5
                nodes.Add(newNode);
                newNode.ToggleExpandState();

                // Step 6
                GetNodeForCompanyLevels(newNode.ChildNodes, thisId);
            }
        }



    }
}