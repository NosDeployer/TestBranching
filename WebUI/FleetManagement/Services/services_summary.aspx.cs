using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.FleetManagement.Services;
using LiquiForce.LFSLive.BL.FleetManagement.Services;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Services
{
    /// <summary>
    /// services_summary
    /// </summar
    public partial class services_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ServiceInformationTDS serviceInformationTDS;
        protected ServiceInformationTDS.CostInformationDataTable serviceInformationServiceCost;
        protected ServiceInformationTDS.NoteInformationDataTable serviceInformationServiceNote;
        





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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_VIEW"]) && Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["service_id"] == null) || ((string)Request.QueryString["active_tab"] == null) || ((string)Request.QueryString["dashboard"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in services_summary.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfFmType.Value = "Services";
                hdfServiceId.Value = Request.QueryString["service_id"].ToString();
                hdfActiveTab.Value = Request.QueryString["active_tab"].ToString();
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();
                hdfDashboard.Value = Request.QueryString["dashboard"].ToString();

                // Prepare initial data
                Session.Remove("serviceCostsDummy");
                Session.Remove("serviceNotesDummy");

                // If comming from 
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int serviceId = Int32.Parse(hdfServiceId.Value.Trim());
                string fmType = hdfFmType.Value;

                // ... services_navigator2.aspx, add_service_request.aspx, wucSRUnassigned.ascx, wucSRMyServiceRequest.ascx, wucItemsAboutToExpire.ascx, wucExpiredItems.ascx, wucAlarms.ascx, wucSRInProgress.ascx, services_manager_tool.aspx
                if ((Request.QueryString["source_page"] == "services_navigator2.aspx") || (Request.QueryString["source_page"] == "services_add_request.aspx") || (Request.QueryString["source_page"] == "wucSRUnassigned.ascx") || (Request.QueryString["source_page"] == "wucSRMyServiceRequest.ascx") || (Request.QueryString["source_page"] == "wucItemsAboutToExpire.ascx") || (Request.QueryString["source_page"] == "wucExpiredItems.ascx") || (Request.QueryString["source_page"] == "wucAlarms.ascx") || (Request.QueryString["source_page"] == "wucSRInProgress.ascx") || (Request.QueryString["source_page"] == "services_manager_tool.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = "yes";

                    // ... ... Set initial tab
                    if ((string)Session["dialogOpenedServices"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];

                        serviceInformationTDS = new ServiceInformationTDS();

                        ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation(serviceInformationTDS);
                        serviceInformationBasicInformation.LoadByServiceId(serviceId, companyId);

                        ServiceInformationServiceCost serviceInformationServiceCostForEdit = new ServiceInformationServiceCost(serviceInformationTDS);
                        serviceInformationServiceCostForEdit.LoadByServiceId(serviceId, companyId);
                        tbxTotalCost.Text = Decimal.Round(serviceInformationServiceCostForEdit.GetTotalCost(serviceId, companyId), 2).ToString();

                        ServiceInformationServiceNote serviceInformationServiceNoteForEdit = new ServiceInformationServiceNote(serviceInformationTDS);
                        serviceInformationServiceNoteForEdit.LoadByServiceId(serviceId, companyId);
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabServices"];

                        // Restore datasets
                        serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDS"];
                    }

                    tcDetailedInformation.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);

                    // Store dataset
                    Session["serviceInformationTDS"] = serviceInformationTDS;
                }

                // ... services_delete.aspx or services_edit.aspx 
                if ((Request.QueryString["source_page"] == "services_delete.aspx") || (Request.QueryString["source_page"] == "services_edit.aspx") || (Request.QueryString["source_page"] == "services_state.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDS"];

                    ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation(serviceInformationTDS);
                    serviceInformationBasicInformation.LoadByServiceId(serviceId, companyId);

                    ServiceInformationServiceCost serviceInformationServiceCostForEdit = new ServiceInformationServiceCost(serviceInformationTDS);
                    serviceInformationServiceCostForEdit.LoadByServiceId(serviceId, companyId);
                    tbxTotalCost.Text = Decimal.Round(serviceInformationServiceCostForEdit.GetTotalCost(serviceId, companyId), 2).ToString();

                    ServiceInformationServiceNote serviceInformationServiceNoteForEdit = new ServiceInformationServiceNote(serviceInformationTDS);
                    serviceInformationServiceNoteForEdit.LoadByServiceId(serviceId, companyId);

                    // ... Set initial tab
                    if ((string)Session["dialogOpenedServices"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabServices"];
                    }

                    tcDetailedInformation.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);

                    // Store dataset
                    Session["serviceInformationTDS"] = serviceInformationTDS;
                }
                               
                // Prepare initial data
                // ... Data for current service               
                LoadServiceData(companyId);

                // ... For total cost
                ServiceInformationServiceCost serviceInformationServiceCostForTotalCost = new ServiceInformationServiceCost(serviceInformationTDS);
                tbxTotalCost.Text = Decimal.Round(serviceInformationServiceCostForTotalCost.GetTotalCost(serviceId, companyId), 2).ToString();

                // Databind
                Page.DataBind();
            }
            else
            {
                // Restore datasets
                serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDS"];

                // Set initial tab
                int activeTab = Int32.Parse(hdfActiveTab.Value);
                tcDetailedInformation.ActiveTabIndex = activeTab;
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "FleetManagement";

            // Validate left menu if the user has admin permission
            if (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]))
            {
                tkrpbLeftMenuAllServiceRequests.Visible = true;
                tkrpbLeftMenuMyServiceRequests.Visible = false;
                tkrpbLeftMenuTools.Visible = true;
            }
            else
            {
                tkrpbLeftMenuAllServiceRequests.Visible = false;
                tkrpbLeftMenuMyServiceRequests.Visible = true;
                tkrpbLeftMenuTools.Visible = false;
            }

            // Tabs validation
            // ... Validate vehicle info
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int serviceId = Int32.Parse(hdfServiceId.Value);

            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGatewayForId = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            int? unitId = serviceInformationBasicInformationGatewayForId.GetUnitID(serviceId);

            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.LoadByUnitId((int)unitId, companyId);
            string unitType = unitsGateway.GetType((int)unitId);
            int companyLevel = unitsGateway.GetCompanyLevelId((int)unitId);

            if (unitType != "Vehicle")
            {
                lblGeneralMileage.Visible = false;
                tbxGeneralMileage.Visible = false;
                lblGeneralMileageUnitOfMeasurement.Visible = false;
                lblStartWorkDataStartMileage.Visible = false;
                tbxStartWorkDataStartMileage.Visible = false;
                lblStartWorkDataMileageUnitOfMeasurement.Visible = false;
                lblCompleteWorkDataCompleteMileage.Visible = false;
                tbxCompleteWorkDataCompleteMileage.Visible = false;
                lblCompleteWorkDataMileageUnitOfMeasurement.Visible = false;
            }
            else
            {
                lblGeneralMileage.Visible = true;
                tbxGeneralMileage.Visible = true;
                lblStartWorkDataStartMileage.Visible = true;
                tbxStartWorkDataStartMileage.Visible = true;
                lblCompleteWorkDataCompleteMileage.Visible = true;
                tbxCompleteWorkDataCompleteMileage.Visible = true;
                lblGeneralMileageUnitOfMeasurement.Visible = true;
                lblStartWorkDataMileageUnitOfMeasurement.Visible = true;
                lblCompleteWorkDataMileageUnitOfMeasurement.Visible = true;
            }
            
            // ... Validate Assignation result
            hdfServiceState.Value = serviceInformationBasicInformationGatewayForId.GetServiceState(serviceId);
            string state = hdfServiceState.Value;

            if ((state == "Accepted") || (state == "In Progress") || (state == "Completed"))
            {
                pnlAssignmentAccept.Visible = true;
                pnlAssignmentReject.Visible = false;
            }
            else
            {
                if (state == "Rejected")
                {
                    pnlAssignmentAccept.Visible = false;
                    pnlAssignmentReject.Visible = true;
                }
                else
                {
                    pnlAssignmentAccept.Visible = false;
                    pnlAssignmentReject.Visible = false;
                }
            }

            // ... Validate for assignated person
            if (serviceInformationBasicInformationGatewayForId.GetToTeamMember(serviceId))
            {
                pnlTeamMemberAssigned.Visible = true;
                pnlThirdPartyVendorAssigned.Visible = false;
            }
            else
            {
                pnlTeamMemberAssigned.Visible = false;
                pnlThirdPartyVendorAssigned.Visible = true;
            }
            
            // Validations for Top Menu
            // ... Get user and service data
            // ... ... Get logged employeeId
            int loginId = Int32.Parse(hdfLoginId.Value);
            bool serviceAdmin = Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]);
            EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
            int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);
            
            // ... ... Get ownerId,  assignTeamMemberId
            int ownerId = serviceInformationBasicInformationGatewayForId.GetOwnerID(serviceId);
            int? assignTeamMemberId = null; if (serviceInformationBasicInformationGatewayForId.GetAssignTeamMemberId(serviceId).HasValue) assignTeamMemberId = (int)serviceInformationBasicInformationGatewayForId.GetAssignTeamMemberId(serviceId);

            // ... Delete option
            if (((employeeId == ownerId) || (serviceAdmin)) && (IsDeletedSR(serviceId)))
            {
                tkrmTop.Items[1].Visible = true;
            }
            else
            {
                tkrmTop.Items[1].Visible = false;
            }

            // ... Assign option
            if ((serviceAdmin) && ((state == "Unassigned") || (state == "Rejected")))
            {
                tkrmTop.Items[2].Visible = true;
            }
            else
            {
                tkrmTop.Items[2].Visible = false;
            }

            // ... User options
            tkrmTop.Items[3].Visible = false; // Accept
            tkrmTop.Items[4].Visible = false; // Reject
            tkrmTop.Items[5].Visible = false; // Start Work
            tkrmTop.Items[6].Visible = false; // Complete Work

            // ... Accept/Reject options
            if (((employeeId == assignTeamMemberId)|| (serviceAdmin)) && (state == "Assigned"))
            {
                tkrmTop.Items[3].Visible = true;
                tkrmTop.Items[4].Visible = true;
                tkrmTop.Items[5].Visible = false;
                tkrmTop.Items[6].Visible = false;
            }

            // ... Start work option
            if (((employeeId == assignTeamMemberId)|| (serviceAdmin)) && (state == "Accepted"))
            {
                tkrmTop.Items[3].Visible = false;
                tkrmTop.Items[4].Visible = false;
                tkrmTop.Items[5].Visible = true;
                tkrmTop.Items[6].Visible = false;
            }

            // ... Start work option
            if (((employeeId == assignTeamMemberId) || (serviceAdmin)) && (state == "In Progress")) 
            {
                tkrmTop.Items[3].Visible = false;
                tkrmTop.Items[4].Visible = false;
                tkrmTop.Items[5].Visible = false;
                tkrmTop.Items[6].Visible = true;
            }

            // ... Last Search or Dashboard
            tkrmTopNavigation.Items[2].Visible = true; // Last search
            tkrmTopNavigation.Items[3].Visible = false; // Dashboard

            if (hdfDashboard.Value == "True")
            {
                tkrmTopNavigation.Items[2].Visible = false; // Last search
                tkrmTopNavigation.Items[3].Visible = true; // Dashboard
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdCosts_DataBound(object sender, EventArgs e)
        {
            AddCostsNewEmptyFix(grdCosts);
        }



        protected void grdNotes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DownloadAttachment":
                    GridViewRow rowDonwload = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    string originalFileName = ((TextBox)rowDonwload.FindControl("tbxNoteAttachment")).Text;
                    string fileName = ((Label)rowDonwload.FindControl("lblFileName")).Text;
                    GrdNotesOpenAttachment(originalFileName, fileName);
                    break;
            }
        }



        protected void grdCosts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DownloadAttachment":
                    GridViewRow rowDonwload = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    string originalFileName = ((TextBox)rowDonwload.FindControl("tbxNoteAttachment")).Text;
                    string fileName = ((Label)rowDonwload.FindControl("lblFileName")).Text;
                    GrdNotesOpenAttachment(originalFileName, fileName);
                    break;
            }
        }



        private void GrdNotesOpenAttachment(string originalFileName, string fileName)
        {
            // Button download functionality
            if ((originalFileName != "") && (fileName != ""))
            {
                // Escape single quote
                originalFileName = originalFileName.Replace("'", "%27");
                fileName = fileName.Replace("'", "%27");

                string script = "<script language='javascript'>";
                string url = "./services_download_attachment.aspx?original_filename=" + Server.UrlEncode(originalFileName) + "&filename=" + Server.UrlEncode(fileName);
                script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=0, height=0')", url);
                script = script + "</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "DownloadAttachment", script, false);
            }
        }



        protected void grdNotes_DataBound(object sender, EventArgs e)
        {
            AddNotesNewEmptyFix(grdNotes);
        }



        protected void grdNotes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Normal items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                string originalFileName = ((TextBox)e.Row.FindControl("tbxNoteAttachment")).Text;
                string fileName = ((Label)e.Row.FindControl("lblFileName")).Text;
                int libraryFileId = 0; if (((Label)e.Row.FindControl("lblLibraryFileId")).Text != "") libraryFileId = Int32.Parse(((Label)e.Row.FindControl("lblLibraryFileId")).Text);

                // Button visibility
                if (originalFileName == "")
                {
                    ((Button)e.Row.FindControl("btnNoteDownload")).Visible = false;
                }
                else
                {
                    ((Button)e.Row.FindControl("btnNoteDownload")).Visible = true;
                }
            }
        }



        protected void grdCosts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Normal items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                string originalFileName = ((TextBox)e.Row.FindControl("tbxNoteAttachment")).Text;
                string fileName = ((Label)e.Row.FindControl("lblFileName")).Text;
                int libraryFileId = 0; if (((Label)e.Row.FindControl("lblLibraryFileId")).Text != "") libraryFileId = Int32.Parse(((Label)e.Row.FindControl("lblLibraryFileId")).Text);

                // Button visibility
                if (originalFileName == "")
                {
                    ((Button)e.Row.FindControl("btnNoteDownload")).Visible = false;
                }
                else
                {
                    ((Button)e.Row.FindControl("btnNoteDownload")).Visible = true;
                }
            }
        }



        protected string GetNoteCreatedBy(object userId)
        {
            if (userId != DBNull.Value)
            {
                if (Convert.ToInt32(userId) != -1)
                {
                    try
                    {
                        // Created By                        
                        int companyId = Int32.Parse(hdfCompanyId.Value);

                        LoginGateway loginGateway = new LoginGateway();
                        loginGateway.LoadByLoginId(Convert.ToInt32(userId), companyId);
                        string userName = loginGateway.GetLastName(Convert.ToInt32(userId), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(userId),companyId);

                        return userName.ToString();
                    }
                    catch
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabServices"] = "0";
            Session["dialogOpenedServices"] = "0";
            
            string activeTab = hdfActiveTab.Value;
            string url = "";

            switch (e.Item.Value)
            {
                case "mEdit":                    
                    url = "./services_edit.aspx?source_page=services_summary.aspx&dashboard=" + hdfDashboard.Value + "&service_id=" + hdfServiceId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value;
                    break;

                case "mDelete":
                    url = "./services_delete.aspx?source_page=services_summary.aspx&dashboard=" + hdfDashboard.Value+ "&service_id=" + hdfServiceId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value;
                    break;

                case "mAssign":
                    url = "./services_state.aspx?source_page=services_summary.aspx&service_id=" + hdfServiceId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value + "&state=Assigned";
                    break;

                case "mAccept":
                    url = "./services_state.aspx?source_page=services_summary.aspx&service_id=" + hdfServiceId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value + "&state=Accepted";
                    break;

                case "mReject":
                    url = "./services_state.aspx?source_page=services_summary.aspx&service_id=" + hdfServiceId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value + "&state=Rejected";
                    break;

                case "mStartWork":
                    url = "./services_state.aspx?source_page=services_summary.aspx&service_id=" + hdfServiceId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value + "&state=StartWork";
                    break;

                case "mCompleteWork":
                    url = "./services_state.aspx?source_page=services_summary.aspx&service_id=" + hdfServiceId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value + "&state=CompleteWork";
                    break;

                case "mLastSearch":
                    url = "./services_navigator2.aspx?source_page=services_summary.aspx&service_id=" + hdfServiceId.Value +  GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mDashboard":
                    url = "./../../FleetManagement/Dashboard/dashboard_login.aspx?source_page=out";
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = ServicesNavigator.GetPreviousId((ServicesNavigatorTDS)Session["servicesNavigatorTDS"], Int32.Parse(hdfServiceId.Value));
                    if (previousId != Int32.Parse(hdfServiceId.Value))
                    {
                        // ... Redirect
                        url = "./services_summary.aspx?source_page=services_navigator2.aspx&dashboard=" + hdfDashboard.Value + "&service_id=" + previousId + GetNavigatorState() + "&update=yes" + "&active_tab=" + activeTab;
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = ServicesNavigator.GetNextId((ServicesNavigatorTDS)Session["servicesNavigatorTDS"], Int32.Parse(hdfServiceId.Value));
                    if (nextId != Int32.Parse(hdfServiceId.Value))
                    {
                        // ... Redirect
                        url = "./services_summary.aspx?source_page=services_navigator2.aspx&dashboard=" + hdfDashboard.Value + "&service_id=" + nextId + GetNavigatorState() + "&update=yes" + "&active_tab=" + activeTab;
                    }
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabServices"] = "0";
            Session["dialogOpenedServices"] = "0";
            Session.Remove("libraryTDSForServices");

            string url = "";

            switch (e.Item.Value)
            {
                case "mSearch":
                    url = "./services_navigator.aspx?source_page=lm&fm_type=" + hdfFmType.Value;
                    break;
            }

            if (url != "") Response.Redirect(url);
        }




        

        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        public ServiceInformationTDS.CostInformationDataTable GetCostsNew()
        {
            serviceInformationServiceCost = (ServiceInformationTDS.CostInformationDataTable)Session["serviceCostsDummy"];
            if (serviceInformationServiceCost == null)
            {
                serviceInformationServiceCost = ((ServiceInformationTDS)Session["serviceInformationTDS"]).CostInformation;
            }

            return serviceInformationServiceCost;
        }



        public ServiceInformationTDS.NoteInformationDataTable GetNotesNew()
        {
            serviceInformationServiceNote = (ServiceInformationTDS.NoteInformationDataTable)Session["serviceNotesDummy"];
            if (serviceInformationServiceNote == null)
            {
                serviceInformationServiceNote = ((ServiceInformationTDS)Session["serviceInformationTDS"]).NoteInformation;
            }

            return serviceInformationServiceNote;
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
            contentVariables += "var hdfServiceIdId = '" + hdfServiceId.ClientID + "';";
            contentVariables += "var hdfFmTypeId = '" + hdfFmType.ClientID + "';";
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";
            contentVariables += "var hdfDashboardId = '" + hdfDashboard.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./services_summary.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_state=" + Request.QueryString["search_state"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private bool IsDeletedSR(int serviceId)
        {
            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            if (serviceInformationBasicInformationGateway.Table.Rows.Count > 0)
            {
                if (serviceInformationBasicInformationGateway.GetRuleId(serviceId).HasValue)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }



        #region Load Functions

        private void LoadServiceData(int companyId)
        {
            // Get FmId
            string fmType = hdfFmType.Value.Trim();
            int serviceId = Int32.Parse(hdfServiceId.Value);

            // Load Data
            LoadBasicData(serviceId);
            LoadDetailedData(serviceId);
            LoadNotes(companyId);
        }



        private void LoadBasicData(int serviceId)
        {
            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            if (serviceInformationBasicInformationGateway.Table.Rows.Count > 0)
            {
                // Load service basic data
                tbxServiceState.Text = serviceInformationBasicInformationGateway.GetServiceState(serviceId);
                tbxServiceNumber.Text = serviceInformationBasicInformationGateway.GetServiceNumber(serviceId);
                tbxDateTime.Text = serviceInformationBasicInformationGateway.GetDateTime_(serviceId).ToString();
                ckbxMtoDto.Checked = serviceInformationBasicInformationGateway.GetMtoDto(serviceId);
                tbxServiceDescription.Text = serviceInformationBasicInformationGateway.GetServiceDescription(serviceId);

                // Load unit basic data
                tbxUnitCode.Text = serviceInformationBasicInformationGateway.GetUnitCode(serviceId);
                tbxUnitDescription.Text = serviceInformationBasicInformationGateway.GetUnitDescription(serviceId);
                tbxVinSn.Text = serviceInformationBasicInformationGateway.GetVinSn(serviceId);
                tbxUnitState.Text = serviceInformationBasicInformationGateway.GetUnitState(serviceId);

                // Load checklist data
                tbxAssociatedChecklistRule.Text = serviceInformationBasicInformationGateway.GetAssociatedChecklistRule(serviceId);
                tbxChecklistState.Text = serviceInformationBasicInformationGateway.GetAssociatedChecklistRuleState(serviceId);

                if (serviceInformationBasicInformationGateway.GetRuleId(serviceId).HasValue)
                {
                    RuleGateway ruleGateway = new RuleGateway();
                    int? ruleId = serviceInformationBasicInformationGateway.GetRuleId(serviceId);
                    ruleGateway.LoadAllByRuleId(ruleId.Value, Int32.Parse(hdfCompanyId.Value));
                    int? serviceRequestDays = ruleGateway.GetServiceRequestDays(ruleId.Value);

                    if (ruleGateway.GetMto(ruleId.Value) && serviceInformationBasicInformationGateway.GetAssociatedChecklistLastService(serviceId).HasValue)
                    {
                        tbxChecklistNextDueDate.Text = serviceInformationBasicInformationGateway.GetAssociatedChecklistLastService(serviceId).Value.ToShortDateString();
                    }
                    else
                    {
                        if (serviceRequestDays.HasValue)
                        {
                            int negValue = -1;
                            serviceRequestDays = serviceRequestDays.Value * negValue;
                            DateTime serviceRequestCreationDate = serviceInformationBasicInformationGateway.GetDateTime_(serviceId);
                            tbxChecklistNextDueDate.Text = serviceInformationBasicInformationGateway.GetAssociatedChecklistNextDue(serviceId).Value.AddDays(Convert.ToDouble(serviceRequestDays.Value)).ToShortDateString();
                        }
                    }
                }
            }
        }



        private void LoadDetailedData(int serviceId)
        {
            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            if (serviceInformationBasicInformationGateway.Table.Rows.Count > 0)
            {
                // Load for General Tab
                tbxGeneralCreatedBy.Text = serviceInformationBasicInformationGateway.GetCreatedBy(serviceId);
                tbxGeneralMileage.Text = serviceInformationBasicInformationGateway.GetMileage(serviceId);
                lblGeneralMileageUnitOfMeasurement.Text = serviceInformationBasicInformationGateway.GetMileageUnitOfMeasurement(serviceId);

                // Load for Assginment Tab
                tbxAssignmentDataAssignmentDateTime.Text = serviceInformationBasicInformationGateway.GetAssignmentDateTime(serviceId).ToString();

                tbxAssignmentDataAssignedDeadlineDate.Text = "";
                if (serviceInformationBasicInformationGateway.GetAssignedDeadlineDate(serviceId).HasValue)
                {
                    DateTime deadlineDate = (DateTime)serviceInformationBasicInformationGateway.GetAssignedDeadlineDate(serviceId);
                    tbxAssignmentDataAssignedDeadlineDate.Text = deadlineDate.Month.ToString() + "/" + deadlineDate.Day.ToString() + "/" + deadlineDate.Year.ToString();
                }

                if ((serviceInformationBasicInformationGateway.GetToTeamMember(serviceId)) && (serviceInformationBasicInformationGateway.GetAssignedThirdPartyVendor(serviceId)) == "")
                {
                    // ... For team member
                    rbtnAssignmentDataToTeamMember.Checked = true;
                    if (serviceInformationBasicInformationGateway.GetAssignTeamMemberId(serviceId).HasValue)
                    {
                        int teamMemberId = (int)serviceInformationBasicInformationGateway.GetAssignTeamMemberId(serviceId);
                        EmployeeGateway employeeGateway = new EmployeeGateway();
                        employeeGateway.LoadByEmployeeId(teamMemberId);

                        tbxAssigmentDataToTeamMemberName.Text = employeeGateway.GetLastName(teamMemberId) + " " + employeeGateway.GetFirstName(teamMemberId);
                    }

                    // ... For third party vendor
                    rbtnAssignmentDataToThirdPartyVendor.Checked = false;
                }
                else
                {
                    if ((!serviceInformationBasicInformationGateway.GetToTeamMember(serviceId)) && (serviceInformationBasicInformationGateway.GetAssignedThirdPartyVendor(serviceId)) != "")
                    {
                        // ... For team member
                        rbtnAssignmentDataToTeamMember.Checked = false;

                        // ... For third party vendor
                        rbtnAssignmentDataToThirdPartyVendor.Checked = true;
                        tbxAssignmentDataAssignToThirdPartyVendor.Text = serviceInformationBasicInformationGateway.GetAssignedThirdPartyVendor(serviceId);
                    }
                    else
                    {
                        rbtnAssignmentDataToTeamMember.Checked = false;
                        rbtnAssignmentDataToThirdPartyVendor.Checked = false;
                    }
                }

                tbxAssignmentDataAcceptedDateTime.Text = serviceInformationBasicInformationGateway.GetAcceptedDateTime(serviceId).ToString();
                
                DateTime? acceptedDateTime = serviceInformationBasicInformationGateway.GetAcceptedDateTime(serviceId);
                if (acceptedDateTime.HasValue) tbxAssignmentDataAcceptedDateTime.Text = acceptedDateTime.ToString();

                DateTime? rejectedDateTime = serviceInformationBasicInformationGateway.GetRejectedDateTime(serviceId);
                if (rejectedDateTime.HasValue) tbxAssignmentDataRejectedDateTime.Text = rejectedDateTime.ToString();
                tbxAssignmentDataRejectedReason.Text = serviceInformationBasicInformationGateway.GetRejectedReason(serviceId);

                // Load for StartWork Tab
                tbxStartWorkDataWorkStartDateTime.Text = serviceInformationBasicInformationGateway.GetStartWorkDateTime(serviceId).ToString();
                
                tbxStartWorkDataUnitOutOfServiceDate.Text = "";
                if (serviceInformationBasicInformationGateway.GetUnitOutOfServiceDate(serviceId).HasValue)
                {
                    DateTime outOfServiceDate = (DateTime)serviceInformationBasicInformationGateway.GetUnitOutOfServiceDate(serviceId);
                    tbxStartWorkDataUnitOutOfServiceDate.Text = outOfServiceDate.Month.ToString() + "/" + outOfServiceDate.Day.ToString() + "/" + outOfServiceDate.Year.ToString();
                }

                tbxStartWorkDataStartMileage.Text = serviceInformationBasicInformationGateway.GetStartWorkMileage(serviceId);
                lblStartWorkDataMileageUnitOfMeasurement.Text = serviceInformationBasicInformationGateway.GetMileageUnitOfMeasurement(serviceId);

                // Load for Complete Work Tab
                tbxCompleteWorkDataCompleteWorkDateTime.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDateTime(serviceId).ToString();

                tbxCompleteWorkDataUnitBackInServiceDate.Text = "";
                if (serviceInformationBasicInformationGateway.GetUnitBackInServiceDate(serviceId).HasValue)
                {
                    DateTime backInServiceDate = (DateTime)serviceInformationBasicInformationGateway.GetUnitBackInServiceDate(serviceId);
                    tbxCompleteWorkDataUnitBackInServiceDate.Text = backInServiceDate.Month.ToString() + "/" + backInServiceDate.Day.ToString() + "/" + backInServiceDate.Year.ToString();
                }

                tbxCompleteWorkDataCompleteMileage.Text = serviceInformationBasicInformationGateway.GetCompleteWorkMileage(serviceId);
                lblCompleteWorkDataMileageUnitOfMeasurement.Text = serviceInformationBasicInformationGateway.GetMileageUnitOfMeasurement(serviceId);

                // ... For team member
                tbxCompleteWorkDataDescription.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDetailDescription(serviceId);
                ckbxCompleteWorkDataPreventable.Checked = serviceInformationBasicInformationGateway.GetCompleteWorkDetailPreventable(serviceId);
                tbxCompleteWorkDataLabourHours.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDetailTMLabourHours(serviceId).ToString();

                // ... For third party vendor
                tbxCompleteWorkDataDescriptionThirdPartyVendor.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDetailDescription(serviceId);
                ckbxCompleteWorkDataPreventableThirdPartyVendor.Checked = serviceInformationBasicInformationGateway.GetCompleteWorkDetailPreventable(serviceId);
                tbxCompleteWorkDataInvoiceNumberThirdPartyVendor.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceNumber(serviceId);
                tbxCompleteWorkDataInvoiceAmountThirdPartyVendor.Text = serviceInformationBasicInformationGateway.GetCompleteWorkDetailTPVInvoiceAmout(serviceId).ToString();
            }
        }



        private void LoadNotes(int companyId)
        {
            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);

            int? libraryCategoriesId = null; if (serviceInformationBasicInformationGateway.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value)).HasValue) libraryCategoriesId = (int)serviceInformationBasicInformationGateway.GetLibraryCategoriesId(int.Parse(hdfServiceId.Value));

            if (libraryCategoriesId.HasValue)
            {
                ViewState["libraryCategoriesId"] = (int)libraryCategoriesId;
                tbxCategoryAssocited.Text = GetFullCategoryName((int)libraryCategoriesId, companyId);
            }
            else
            {
                tbxCategoryAssocited.Text = "";
            }
        }

        #endregion



        protected void AddCostsNewEmptyFix(GridView grdView)
        {
            if (grdCosts.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ServiceInformationTDS.CostInformationDataTable dt = new ServiceInformationTDS.CostInformationDataTable();
                dt.AddCostInformationRow(-1, -1, "", "", "", -1, false, companyId, false, 0, 0, "", "");
                Session["serviceCostsDummy"] = dt;

                grdCosts.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCosts.Rows.Count == 1)
            {
                ServiceInformationTDS.CostInformationDataTable dt = (ServiceInformationTDS.CostInformationDataTable)Session["serviceCostsDummy"];
                if (dt != null)
                {
                    grdCosts.Rows[0].Visible = false;
                    grdCosts.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddNotesNewEmptyFix(GridView grdView)
        {
            if (grdNotes.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ServiceInformationTDS.NoteInformationDataTable dt = new ServiceInformationTDS.NoteInformationDataTable();
                dt.AddNoteInformationRow(-1, -1, "", -1, DateTime.Now, "", 0, "", "", false, companyId, false);
                Session["serviceNotesDummy"] = dt;

                grdNotes.DataBind();
            }

            // Normally executes at all postbacks
            if (grdNotes.Rows.Count == 1)
            {
                ServiceInformationTDS.NoteInformationDataTable dt = (ServiceInformationTDS.NoteInformationDataTable)Session["serviceNotesDummy"];
                if (dt != null)
                {
                    grdNotes.Rows[0].Visible = false;
                    grdNotes.Rows[0].Controls.Clear();
                }
            }
        }



        private string GetFullCategoryName(int libraryCategoryId, int companyId)
        {
            int[] libraryArray = new int[100];
            int maxDeep = 0;
            for (int index = 0; index < libraryArray.Length; index++)
            {
                libraryArray[index] = -1;
            }

            string fullCategoryName = "";
            libraryArray = GetDeepParent(libraryCategoryId, 0, maxDeep, libraryArray, companyId);

            for (int index = 0; index < 100; index++)
            {
                if (libraryArray[index] > 0)
                {
                    if (index > 0)
                    {
                        fullCategoryName = fullCategoryName + "/";
                    }
                    LibraryCategoriesGateway libraryCategoriesGateway = new LibraryCategoriesGateway();
                    libraryCategoriesGateway.LoadAllByLibraryCategoriesId(libraryArray[index], companyId);
                    fullCategoryName = fullCategoryName + libraryCategoriesGateway.GetCategoryName(libraryArray[index]);

                }
            }

            return fullCategoryName;
        }



        private int[] GetDeepParent(int currentId, int deep, int maxDeep, int[] currentLibraryArray, int companyId)
        {
            int[] libraryArray = currentLibraryArray;
            ViewState["currentmaxDeep"] = maxDeep;

            LibraryCategoriesGateway libraryCategoriesGateway = new LibraryCategoriesGateway();
            libraryCategoriesGateway.LoadAllByLibraryCategoriesId(currentId, companyId);

            if (libraryCategoriesGateway.Table.Rows.Count > 0)
            {
                if (libraryCategoriesGateway.GetParentId(currentId) == 0)
                {
                    libraryArray[0] = currentId;
                    ViewState["currentmaxDeep"] = deep;
                    return libraryArray;
                }
                else
                {

                    libraryArray = GetDeepParent(libraryCategoriesGateway.GetParentId(currentId), deep + 1, (int)ViewState["currentmaxDeep"], libraryArray, companyId);
                    libraryArray[(int)ViewState["currentmaxDeep"] - deep] = currentId;
                    return libraryArray;
                }
            }
            else
            {
                return libraryArray;
            }
        }

        

    }
}
