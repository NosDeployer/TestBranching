using System;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.BL.FleetManagement.Services;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.ChecklistRules
{
    /// <summary>
    /// checklist_rules_navigator
    /// </summary>
    public partial class checklist_rules_navigator : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ChecklistRulesNavigatorTDS checklistRulesNavigatorTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_CHECKLISTRULES_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in checklist_rules_navigator.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                
                // If coming from
                // ... Checklist_rules_edit.aspx, checklist_rules_summary.aspx or checkliste_rules_delete.aspx
                if ((Request.QueryString["source_page"] == "checklist_rules_edit.aspx") || (Request.QueryString["source_page"] == "checklist_rules_summary.aspx") || (Request.QueryString["source_page"] == "checkliste_rules_delete.aspx"))
                {
                    if (Request.QueryString["update"] == "no")
                    {
                        checklistRulesNavigatorTDS = (ChecklistRulesNavigatorTDS)Session["checklistRulesNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("checklistRulesNavigatorTDS");

                        // ... Search data with updates
                        checklistRulesNavigatorTDS = SubmitSearch();

                        // ... Store datasets
                        Session["checklistRulesNavigatorTDS"] = checklistRulesNavigatorTDS;
                    }
                }
                else
                {
                    // ... Delete store data
                    Session.Contents.Remove("checklistRulesNavigatorTDS");

                    // ... Search data
                    checklistRulesNavigatorTDS = SubmitSearch();

                    // ... Store datasets
                    Session["checklistRulesNavigatorTDS"] = checklistRulesNavigatorTDS;
                }

                // For the grid
                grdCRNavigator.DataSource = checklistRulesNavigatorTDS.ChecklistRulesNavigator;
                grdCRNavigator.DataBind();

                // ... For the total rows
                if (checklistRulesNavigatorTDS.ChecklistRulesNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + checklistRulesNavigatorTDS.ChecklistRulesNavigator.Rows.Count;
                    lblTotalRows.Visible = true;
                    lblResults.Visible = true;
                    btnOpen.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                }
                else
                {
                    lblTotalRows.Visible = false;
                    lblResults.Visible = false;
                    btnOpen.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

                Session.Remove("arrayCategoriesSelectedForEdit");
                Session.Remove("arrayCompanyLevelsSelectedForEdit");
                Session.Remove("categoriesTDS");
                Session.Remove("companyLevelsTDS");
            }
            else
            {
                // Restore TDS
                checklistRulesNavigatorTDS = (ChecklistRulesNavigatorTDS)Session["checklistRulesNavigatorTDS"];

                // ... For the total rows
                if (checklistRulesNavigatorTDS.ChecklistRulesNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + checklistRulesNavigatorTDS.ChecklistRulesNavigator.Rows.Count;
                    lblTotalRows.Visible = true;
                    lblResults.Visible = true;
                    btnOpen.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                }
                else
                {
                    lblTotalRows.Visible = false;
                    lblResults.Visible = false;
                    btnOpen.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }
            }
        }        



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm7 master = (mForm7)this.Master;
            master.ActiveToolbar = "FleetManagement";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //
                        
        protected void grdCRNavigator_Sorting(object sender, GridViewSortEventArgs e)
        {
            string oldSort = checklistRulesNavigatorTDS.ChecklistRulesNavigator.DefaultView.Sort;
            
            if (!oldSort.Contains(e.SortExpression.ToString()))
            {
                checklistRulesNavigatorTDS.ChecklistRulesNavigator.DefaultView.Sort = e.SortExpression + " ASC";
                grdCRNavigator.DataSource = checklistRulesNavigatorTDS.ChecklistRulesNavigator.DefaultView;
                grdCRNavigator.DataBind();
            }
            else
            {
                if (oldSort.Contains("ASC"))
                {
                    checklistRulesNavigatorTDS.ChecklistRulesNavigator.DefaultView.Sort = e.SortExpression + " DESC";
                    grdCRNavigator.DataSource = checklistRulesNavigatorTDS.ChecklistRulesNavigator.DefaultView;
                    grdCRNavigator.DataBind();
                }
                else
                {
                    checklistRulesNavigatorTDS.ChecklistRulesNavigator.DefaultView.Sort = e.SortExpression + " ASC";
                    grdCRNavigator.DataSource = checklistRulesNavigatorTDS.ChecklistRulesNavigator.DefaultView;
                    grdCRNavigator.DataBind();
                }
            }
        }        






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            int ruleId = GetRuleId();

            if (ruleId > 0)
            {
                // Redirect
                string url = "./checklist_rules_summary.aspx?source_page=checklist_rules_navigator.aspx&rule_id=" + ruleId;
                Response.Redirect(url);
            }
            else
            {
                cvSelection.ErrorMessage = "Please select one checklist rule.";
                cvSelection.IsValid = false;
            }
        }



        protected void btnEdit_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            int ruleId = GetRuleId();

            if (ruleId > 0)
            {
                // Redirect
                string url = "./checklist_rules_edit.aspx?source_page=checklist_rules_navigator.aspx&rule_id=" + ruleId;
                Response.Redirect(url);
            }
            else
            {
                cvSelection.ErrorMessage = "Please select one checklist rule.";
                cvSelection.IsValid = false;
            }
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            int ruleId = GetRuleId();

            if (ruleId > 0)
            {
                ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation();
                serviceInformationBasicInformation.LoadInProgressByRuleId(ruleId, int.Parse(hdfCompanyId.Value));

                if (serviceInformationBasicInformation.Table.Rows.Count > 0)
                {
                    cvSelection.ErrorMessage = "The checklist rule have pending service requests, please complete them before delete checklist.";
                    cvSelection.IsValid = false;
                }
                else
                {
                    // Redirect
                    string url = "./checklist_rules_delete.aspx?source_page=checklist_rules_navigator.aspx&rule_id=" + ruleId;
                    Response.Redirect(url);
                }
            }
            else
            {
                cvSelection.ErrorMessage = "Please select one checklist rule.";
                cvSelection.IsValid = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            /// Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./checklist_rules_navigator.js");
        }



        private ChecklistRulesNavigatorTDS SubmitSearch()
        {
            // ... Load data
            ChecklistRulesNavigator checklistRulesNavigator = new ChecklistRulesNavigator();
            checklistRulesNavigator.Load(Int32.Parse(hdfCompanyId.Value));

            return (ChecklistRulesNavigatorTDS)checklistRulesNavigator.Data;
        }



        private void PostPageChanges()
        {
            ChecklistRulesNavigator checklistRulesNavigator = new ChecklistRulesNavigator(checklistRulesNavigatorTDS);

            // Update rows
            foreach (GridViewRow row in grdCRNavigator.Rows)
            {
                int ruleId = int.Parse(((Label)row.FindControl("lblRuleID")).Text);
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                checklistRulesNavigator.Update(ruleId, selected);
            }

            checklistRulesNavigator.Data.AcceptChanges();

            // Store datasets
            Session["checklistRulesNavigatorTDS"] = checklistRulesNavigatorTDS;
        }



        private int GetRuleId()
        {
            int ruleId = 0;

            foreach (ChecklistRulesNavigatorTDS.ChecklistRulesNavigatorRow checklistRulesNavigatorRow in checklistRulesNavigatorTDS.ChecklistRulesNavigator)
            {
                if (checklistRulesNavigatorRow.Selected)
                {
                    ruleId = checklistRulesNavigatorRow.RuleID;
                }
            }

            return ruleId;
        }      


        
    }
}