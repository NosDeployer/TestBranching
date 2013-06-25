using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_combined_costing_sheets_delete
    /// </summary>
    public partial class project_combined_costing_sheets_delete : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectCostingSheetInformationTDS projectCostingSheetInformationTDS;
        protected ProjectTDS projectTDS;






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
                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_ADMIN"]))
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_DELETE"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["costing_sheet_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_combined_costing_sheets_delete.aspx");
                }

                // Tag Page
                hdfCostingSheetId.Value = Request.QueryString["costing_sheet_id"].ToString();
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfProjectId.Value = Request.QueryString["project_id"];
                hdfDataChanged.Value = Request.QueryString["data_changed"];
                hdfDataChangedMessage.Value = "Changes made to this project will not be saved.";

                ViewState["state"] = Request.QueryString["state"];
                ViewState["active_tab"] = Request.QueryString["active_tab"];
                ViewState["origin"] = Request.QueryString["origin"];
                ViewState["update"] = Request.QueryString["update"];

                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];

                // If coming from 
                // ... project_combined_costing_sheets_navigator2.aspx
                if (Request.QueryString["source_page"] == "project_costing_sheets_navigator.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    projectCostingSheetInformationTDS = new ProjectCostingSheetInformationTDS();

                    int costingSheetId = Int32.Parse(hdfCostingSheetId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    ProjectCombinedCostingSheetInformationBasicInformationGateway projectCostingSheetInformationBasicInformationGateway = new ProjectCombinedCostingSheetInformationBasicInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationBasicInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_ADMIN"]))
                    {
                        string state = projectCostingSheetInformationBasicInformationGateway.GetState(costingSheetId);
                        if (state == "Approved")
                        {
                            Response.Redirect("./../../error_page.aspx?error=" + "This costing sheet is approved, you can not delete it.");
                        }
                    }

                    // Store dataset
                    Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;
                }

                // ... project_combined_costing_sheets_summary.aspx
                if (Request.QueryString["source_page"] == "project_combined_costing_sheets_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    projectCostingSheetInformationTDS = (ProjectCostingSheetInformationTDS)Session["projectCostingSheetInformationTDS"];

                    if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_ADMIN"]))
                    {
                        // Costing Sheet state check
                        ProjectCombinedCostingSheetInformationBasicInformationGateway projectCostingSheetInformationBasicInformationGatewayForValidate = new ProjectCombinedCostingSheetInformationBasicInformationGateway(projectCostingSheetInformationTDS);
                        string state = projectCostingSheetInformationBasicInformationGatewayForValidate.GetState(Int32.Parse(hdfCostingSheetId.Value));
                        if (state == "Approved")
                        {
                            Response.Redirect("./../../error_page.aspx?error=" + "This costing sheet is approved, you can not delete it.");
                        }
                    }
                }
            }
            else
            {
                // Restore datasets
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                projectCostingSheetInformationTDS = (ProjectCostingSheetInformationTDS)Session["projectCostingSheetInformationTDS"];
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "Projects";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
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
                    if (Request.QueryString["source_page"] == "project_costing_sheets_navigator.aspx")
                    {
                        url = "./project_costing_sheets_navigator.aspx?source_page=project_combined_costing_sheets_delete.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    }

                    if (Request.QueryString["source_page"] == "project_combined_costing_sheets_summary.aspx")
                    {
                        url = "./project_combined_costing_sheets_summary.aspx?source_page=project_combined_costing_sheets_delete.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./project_combined_costing_sheets_delete.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_projectnumber=" + Request.QueryString["search_projectnumber"] + "&search_projectname=" + Request.QueryString["search_projectname"] + "&search_client=" + Request.QueryString["search_client"] + "&search_type=" + Request.QueryString["search_type"] + "&search_state=" + Request.QueryString["search_state"];
        }



        private string GetNavigatorState()
        {
            // Return
            return (string)ViewState["navigatorState"];
        }



        private void Delete()
        {
            Page.Validate();

            if (Page.IsValid)
            {
                // Delete all data for service
                int costingSheetId = Int32.Parse(hdfCostingSheetId.Value);

                ProjectCombinedCostingSheetInformationBasicInformation projectCostingSheetInformationBasicInformation = new ProjectCombinedCostingSheetInformationBasicInformation(projectCostingSheetInformationTDS);
                projectCostingSheetInformationBasicInformation.Delete(costingSheetId);

                // Update databse
                UpdateDatabase();

                // Store datasets
                Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;

                // Redirect
                string url = "";

                url = "./project_costing_sheets_navigator.aspx?source_page=project_combined_costing_sheets_delete.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=yes&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];

                Response.Redirect(url);
            }
        }



        private void UpdateDatabase()
        {
            // Get ids
            int costingSheetId = Int32.Parse(hdfCostingSheetId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // Delete
            DB.Open();
            DB.BeginTransaction();
            try
            {
                ProjectCombinedCostingSheetInformationBasicInformation projectCostingSheetInformationBasicInformation = new ProjectCombinedCostingSheetInformationBasicInformation(projectCostingSheetInformationTDS);
                projectCostingSheetInformationBasicInformation.DeleteDirect(costingSheetId, companyId);

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