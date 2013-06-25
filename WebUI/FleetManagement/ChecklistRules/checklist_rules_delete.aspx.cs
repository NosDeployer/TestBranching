using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.ChecklistRules
{
    /// <summary>
    /// checklist_rules_delete
    /// </summary>
    public partial class checklist_rules_delete : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected RuleTDS ruleTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_CHECKLISTRULES_VIEW"]) && Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_CHECKLISTRULES_DELETE"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["rule_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in checklist_rules_delete.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfRuleId.Value = Request.QueryString["rule_id"].ToString();
                
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int ruleId = Int32.Parse(hdfRuleId.Value.Trim());

                // If coming from 
                // ... checklist_rules_navigator.aspx
                if (Request.QueryString["source_page"] == "checklist_rules_navigator.aspx")
                {
                    ViewState["update"] = "no";

                    ruleTDS = new RuleTDS();
                    LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.Rule rule = new LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.Rule(ruleTDS);
                    rule.LoadByRuleId(ruleId, companyId);  

                    // Store dataset
                    Session["ruleTDS"] = ruleTDS;
                }

                // ... checklist_rules_summary.aspx
                if (Request.QueryString["source_page"] == "checklist_rules_summary.aspx")
                {
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore datasets
                    ruleTDS = (RuleTDS)Session["ruleTDS"];
                }
            }
            else
            {
                // Restore datasets
                ruleTDS = (RuleTDS)Session["ruleTDS"];
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "FleetManagement";
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mDelete":
                    this.Delete();
                    break;

                case "mCancel":
                    string url = "";
                    if (Request.QueryString["source_page"] == "checklist_rules_navigator.aspx")
                    {
                        url = "./checklist_rules_navigator.aspx?source_page=checklist_rules_delete.aspx";
                    }

                    if (Request.QueryString["source_page"] == "checklist_rules_summary.aspx")
                    {
                        url = "./checklist_rules_summary.aspx?source_page=&checklist_rules_delete.aspx";
                    }
                    Response.Redirect(url);
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./checklist_rules_delete.js");
        }



        private void Delete()
        {
            Page.Validate();

            if (Page.IsValid)
            {
                // Update databse
                UpdateDatabase();

                // Store datasets
                Session["ruleTDS"] = ruleTDS;

                // Redirect
                string url = "";
                url = "./checklist_rules_navigator.aspx?source_page=checklist_rules_delete.aspx&update=yes";
                Response.Redirect(url);
            }
        }



        private void UpdateDatabase()
        {
            // Delete
            int ruleId = Int32.Parse(hdfRuleId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // Delete
            DB.Open();
            DB.BeginTransaction();
            try
            {
                ChecklistRulesDetails checklistRulesDetails = new ChecklistRulesDetails(ruleTDS);
                checklistRulesDetails.Delete(ruleId, companyId);

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