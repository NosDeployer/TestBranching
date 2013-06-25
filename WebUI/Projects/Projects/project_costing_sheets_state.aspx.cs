using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_costing_sheets_state
    /// </summary>
    public partial class project_costing_sheets_state : System.Web.UI.Page
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
                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_ADMIN"]))
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_EDIT"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["costing_sheet_id"] == null)  || ((string)Request.QueryString["costing_sheet_state"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_costing_sheets_state.aspx");
                }

                // Tag Page
                hdfCostingSheetId.Value = Request.QueryString["costing_sheet_id"].ToString();
                hdfCostingSheetState.Value = Request.QueryString["costing_sheet_state"].ToString();
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfProjectId.Value = Request.QueryString["project_id"];
                hdfDataChanged.Value = Request.QueryString["data_changed"];
                hdfDataChangedMessage.Value = "Changes made to this project will not be saved.";
                ViewState["state"] = Request.QueryString["state"];
                ViewState["active_tab"] = Request.QueryString["active_tab"];
                ViewState["origin"] = Request.QueryString["origin"];
                ViewState["update"] = Request.QueryString["update"];
                int projectId = Int32.Parse(hdfProjectId.Value);

                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];

                // If coming from project_costing_sheets_summary.aspx
                if ((string)Request.QueryString["source_page"] == "project_costing_sheets_summary.aspx")
                {
                    ViewState["update"] = Request.QueryString["update"];

                    int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                    int costingSheetId = Int32.Parse(hdfCostingSheetId.Value.Trim());

                    projectCostingSheetInformationTDS = (ProjectCostingSheetInformationTDS)Session["projectCostingSheetInformationTDS"];
                    ProjectCostingSheetInformationBasicInformationGateway projectCostingSheetInformationBasicInformationGateway = new ProjectCostingSheetInformationBasicInformationGateway(projectCostingSheetInformationTDS);
                    projectCostingSheetInformationBasicInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

                    // Store dataset
                    Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;
                }

                // Restore dataset
                projectCostingSheetInformationTDS = (ProjectCostingSheetInformationTDS)Session["projectCostingSheetInformationTDS"];

                // Costing Sheet state check
                ProjectCostingSheetInformationBasicInformationGateway projectCostingSheetInformationBasicInformationGatewayToValidate = new ProjectCostingSheetInformationBasicInformationGateway(projectCostingSheetInformationTDS);
                
                DateTime startDate = projectCostingSheetInformationBasicInformationGatewayToValidate.GetStartDate(Int32.Parse(hdfCostingSheetId.Value));
                DateTime endDate = projectCostingSheetInformationBasicInformationGatewayToValidate.GetEndDate(Int32.Parse(hdfCostingSheetId.Value));
                
                ProjectCostingSheetGateway projectCostingSheetGateway = new ProjectCostingSheetGateway();                
                if (projectCostingSheetGateway.ExistCostingSheetApproved(projectId, startDate, endDate))
                {
                    string msg = "You cannot approve this costing sheet. There are other costing sheets already approved on the same date range. There is an overlaping issue between yours costing sheets.";
                    Response.Redirect("./../../error_page.aspx?error=" + msg);
                }
            }
            else
            {
                // Restore dataset 
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                projectCostingSheetInformationTDS = (ProjectCostingSheetInformationTDS)Session["projectCostingSheetInformationTDS"];
            }
        }       
        
        
        
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "Projects";

            switch ((string)Request.QueryString["costing_sheet_state"])
            {
                case "In Progress":
                    tkrmTop.Items[0].Visible = true;//In Progress
                    tkrmTop.Items[1].Visible = false;//Approved
                    tkrmTop.Items[2].Visible = true;//Cancel
                    lblState.Text = "Are you sure you want to set in progress this costing sheet?";                   
                    
                    break;

                case "Approved":
                    tkrmTop.Items[0].Visible = false;//In Progress
                    tkrmTop.Items[1].Visible = true;//Approved
                    tkrmTop.Items[2].Visible = true;//Cancel                   
                    lblState.Text = "Are you sure you want to approve this costing sheet?";
                    break;
            }            
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATOR EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = null;

            if (e.Item.Value == "mCancel")
            {
                url = "./project_costing_sheets_summary.aspx?source_page=project_costing_sheets_state.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                Response.Redirect(url);
            }
            else
            {
                UpdateState();
                UpdateDatabase();

                url = "./project_costing_sheets_summary.aspx?source_page=project_costing_sheets_state.aspx&costing_sheet_id=" + hdfCostingSheetId.Value + "&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=yes&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];

                Response.Redirect(url);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_projectnumber=" + Request.QueryString["search_projectnumber"] + "&search_projectname=" + Request.QueryString["search_projectname"] + "&search_client=" + Request.QueryString["search_client"] + "&search_type=" + Request.QueryString["search_type"] + "&search_state=" + Request.QueryString["search_state"];
        }



        private string GetNavigatorState()
        {
            // Return
            return (string)ViewState["navigatorState"];
        }



        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./project_costing_sheets_state.js");
        }



        private void UpdateState()
        {
            int costingSheetId = Int32.Parse(hdfCostingSheetId.Value);
            
            ProjectCostingSheetInformationBasicInformation projectCostingSheetInformationBasicInformation = new ProjectCostingSheetInformationBasicInformation(projectCostingSheetInformationTDS);
            projectCostingSheetInformationBasicInformation.UpdateState(costingSheetId, hdfCostingSheetState.Value);
        }



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                ProjectCostingSheetInformationBasicInformation projectCostingSheetInformationBasicInformation = new ProjectCostingSheetInformationBasicInformation(projectCostingSheetInformationTDS);
                projectCostingSheetInformationBasicInformation.Save(companyId);

                DB.CommitTransaction();

                // Store datasets
                projectCostingSheetInformationTDS.AcceptChanges();
                Session["projectCostingSheetInformationTDS"] = projectCostingSheetInformationTDS;
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