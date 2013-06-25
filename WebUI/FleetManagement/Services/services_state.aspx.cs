using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.FleetManagement.Services;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.DA.FleetManagement.Services;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Services
{
    /// <summary>
    /// services_state
    /// </summary>
    public partial class services_state : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ServiceInformationTDS serviceInformationTDS;






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
                if (((string)Request.QueryString["state"] == null) || ((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["service_id"] == null) || ((string)Request.QueryString["active_tab"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in services_state.aspx");
                }

                // Tag page
                TagPage();

                // If coming from services_summary.aspx
                if ((string)Request.QueryString["source_page"] == "services_summary.aspx") 
                {
                    // Store Navigator State and Update control
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Get project record
                    int serviceId = Int32.Parse(hdfServiceId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDS"];
                    ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
                    serviceInformationBasicInformationGateway.LoadByServiceId(serviceId, companyId);

                    if (serviceInformationBasicInformationGateway.GetRuleId(serviceId).HasValue)
                    {
                        RuleGateway ruleGateway = new RuleGateway();
                        int? ruleId = serviceInformationBasicInformationGateway.GetRuleId(serviceId);
                        ruleGateway.LoadAllByRuleId(ruleId.Value, Int32.Parse(hdfCompanyId.Value));
                        int? serviceRequestDays = ruleGateway.GetServiceRequestDays(ruleId.Value);

                        if (serviceRequestDays.HasValue)
                        {
                            DateTime serviceRequestCreationDate = serviceInformationBasicInformationGateway.GetDateTime_(serviceId);
                            tkrdpPnlAssignDeadlineDate.SelectedDate = serviceRequestCreationDate.AddDays(Convert.ToDouble(serviceRequestDays.Value));
                        }
                    }

                    // Store datasets
                    Session["serviceInformationTDS"] = serviceInformationTDS;
                }

                // If coming from wucSRUnassigned.aspx
                if ((string)Request.QueryString["source_page"] == "wucSRUnassigned.ascx")
                {
                    // Store Navigator State and Update control
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Get project record
                    int serviceId = Int32.Parse(hdfServiceId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    serviceInformationTDS = new ServiceInformationTDS();
                    ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
                    serviceInformationBasicInformationGateway.LoadByServiceId(serviceId, companyId);

                    if (serviceInformationBasicInformationGateway.GetRuleId(serviceId).HasValue)
                    {
                        RuleGateway ruleGateway = new RuleGateway();
                        int? ruleId = serviceInformationBasicInformationGateway.GetRuleId(serviceId);
                        ruleGateway.LoadAllByRuleId(ruleId.Value, Int32.Parse(hdfCompanyId.Value));
                        int? serviceRequestDays = ruleGateway.GetServiceRequestDays(ruleId.Value);

                        if (serviceRequestDays.HasValue)
                        {
                            DateTime serviceRequestCreationDate = serviceInformationBasicInformationGateway.GetDateTime_(serviceId);
                            tkrdpPnlAssignDeadlineDate.SelectedDate = serviceRequestCreationDate.AddDays(Convert.ToDouble(serviceRequestDays.Value));
                        }
                    }

                    // Store datasets
                    Session["serviceInformationTDS"] = serviceInformationTDS;
                }

                // Restore dataset
                serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDS"];

                LoadMileage();
            }
            else
            {
                // Restore dataset 
                serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDS"];
            }
        }        



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "FleetManagement";

            // Operation check
            switch ((string)Request.QueryString["state"])
            {
                case "Assigned":                    
                    tkrmTop.Items[0].Visible = true; //Assign
                    tkrmTop.Items[1].Visible = false;//Accept
                    tkrmTop.Items[2].Visible = false;//Reject
                    tkrmTop.Items[3].Visible = false;//Start Work
                    tkrmTop.Items[4].Visible = false;//Complete Work

                    // ... Cancel
                    tkrmTop.Items[5].Visible = true;
                    break;

                case "Accepted":
                    tkrmTop.Items[0].Visible = false; //Assign
                    tkrmTop.Items[1].Visible = true;//Accept
                    tkrmTop.Items[2].Visible = false;//Reject
                    tkrmTop.Items[3].Visible = false;//Start Work
                    tkrmTop.Items[4].Visible = false;//Complete Work

                    // ...Cancel
                    tkrmTop.Items[5].Visible = true;
                    break;

                case "Rejected":
                    tkrmTop.Items[0].Visible = false; //Assign
                    tkrmTop.Items[1].Visible = false;//Accept
                    tkrmTop.Items[2].Visible = true;//Reject
                    tkrmTop.Items[3].Visible = false;//Start Work
                    tkrmTop.Items[4].Visible = false;//Complete Work

                    // ...Cancel
                    tkrmTop.Items[5].Visible = true;
                    break;

                case "StartWork":
                    tkrmTop.Items[0].Visible = false; //Assign
                    tkrmTop.Items[1].Visible = false;//Accept
                    tkrmTop.Items[2].Visible = false;//Reject
                    tkrmTop.Items[3].Visible = true;//Start Work
                    tkrmTop.Items[4].Visible = false;//Complete Work

                    // ...Cancel
                    tkrmTop.Items[5].Visible = true;
                    
                    // ... Static data
                    if (pnlStartWork.Visible)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        int serviceId = Int32.Parse(hdfServiceId.Value);
                        string unitType = hdfUnitType.Value;
                        int companyLevel = Int32.Parse(hdfCompanyLevel.Value);

                        if (unitType != "Vehicle")
                        {
                            lblPnlStartWorkStartMileage.Visible = false;
                            tbxPnlStartWorkStartMileage.Visible = false;
                            lblPnlStartWorkStartMileageUnitOfMeasurement.Visible = false;                            
                        }
                        else
                        {
                            // .. For Vehicles
                            lblPnlStartWorkStartMileage.Visible = true;
                            tbxPnlStartWorkStartMileage.Visible = true;
                            lblPnlStartWorkStartMileageUnitOfMeasurement.Visible = true;                            
                        }
                    }
                    break; 

                case "CompleteWork":
                    tkrmTop.Items[0].Visible = false; //Assign
                    tkrmTop.Items[1].Visible = false;//Accept
                    tkrmTop.Items[2].Visible = false;//Reject
                    tkrmTop.Items[3].Visible = false;//Start Work
                    tkrmTop.Items[4].Visible = true;//Complete Work

                    // ...Cancel
                    tkrmTop.Items[5].Visible = true;
                    
                    // ... Static data
                    if (pnlCompleteWork.Visible)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        int serviceId = Int32.Parse(hdfServiceId.Value);
                        string unitType = hdfUnitType.Value;
                        int companyLevel = Int32.Parse(hdfCompanyLevel.Value);

                        if (unitType != "Vehicle")
                        {
                            lblPnlCompleteWorkCompleteMileage.Visible = false;
                            tbxPnlCompleteWorkCompleteMileage.Visible = false;
                            lblPnlCompleteWorkCompleteMileageUnitOfMeasurement.Visible = false;                                                        
                        }
                        else
                        {
                            lblPnlCompleteWorkCompleteMileage.Visible = true;
                            tbxPnlCompleteWorkCompleteMileage.Visible = true;
                            lblPnlCompleteWorkCompleteMileageUnitOfMeasurement.Visible = true;                                                        
                        }
                    }
                    break;
            }

            // Set instruction
            switch ((string)Request.QueryString["state"])
            {
                case "Assigned":
                    lblState.Text = "Are you sure you want to assign this service request?";
                    pnlAssignment.Visible = true;
                    pnlAssignmentReject.Visible = false;
                    pnlStartWork.Visible = false;
                    pnlCompleteWork.Visible = false;
                    break;

                case "Accepted":
                    lblState.Text = "Are you sure you want to accept this service request?";
                    pnlAssignment.Visible = false;
                    pnlAssignmentReject.Visible = false;
                    pnlStartWork.Visible = false;
                    pnlCompleteWork.Visible = false;
                    break;

                case "Rejected":
                    lblState.Text = "Are you sure you want to reject this service request?";
                    pnlAssignment.Visible = false;
                    pnlAssignmentReject.Visible = true;
                    pnlStartWork.Visible = false;
                    pnlCompleteWork.Visible = false;
                    break;

                case "StartWork":
                    lblState.Text = "Are you sure you want to set this service request as started?";
                    pnlAssignment.Visible = false;
                    pnlAssignmentReject.Visible = false;
                    pnlStartWork.Visible = true;
                    pnlCompleteWork.Visible = false;
                    break;

                case "CompleteWork":
                    lblState.Text = "Are you sure you want to set this service request as completed?";
                    pnlAssignment.Visible = false;
                    pnlAssignmentReject.Visible = false;
                    pnlStartWork.Visible = false;
                    pnlCompleteWork.Visible = true;
                    break;                
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void cvEmpyOutOfService_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if (tbxPnlStartWorkUnitOutOfServiceTime.Text == "")
            {
                args.IsValid = false;
            }
        }

        

        protected void cvEmptyBackInServiceTime_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if (tbxPnlCompleteWorkUnitBackInServiceTime.Text == "")
            {
                args.IsValid = false;
            }
        }



        protected void cvUnitBackInServiceDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if (!tkrdpPnlCompleteWorkUnitBackInServiceDate.SelectedDate.HasValue)
            {
                args.IsValid = false;
            }
        }



        protected void tkrdpPnlStartWorkUnitOutOfServiceDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if (!tkrdpPnlStartWorkUnitOutOfServiceDate.SelectedDate.HasValue)
            {
                args.IsValid = false;
            }
        }



        protected void cvTeamMember_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if ((rbtnPnlAssignToTeamMember.Checked) && (ddlPnlAssignAssignToTeamMember.SelectedValue == "-1"))
            {
                args.IsValid = false;
            }
        }



        protected void cvThirdPartyVendor_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if ((rbtnPnlAssignToThirdPartyVendor.Checked) && (tbxPnlAssignAssignToThirdPartyVendor.Text == ""))
            {
                args.IsValid = false;
            }
        }



        protected void cvUnitOutOfServiceTime_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if ((Time.IsValidTimeInFormatT1(tbxPnlStartWorkUnitOutOfServiceTime.Text)) || (Time.IsValidTimeInFormatT2(tbxPnlStartWorkUnitOutOfServiceTime.Text)))
            {
                args.IsValid = true;
            }
        }



        protected void cvUnitBackInfServiceTime_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if ((Time.IsValidTimeInFormatT1(tbxPnlCompleteWorkUnitBackInServiceTime.Text)) || (Time.IsValidTimeInFormatT2(tbxPnlCompleteWorkUnitBackInServiceTime.Text)))
            {
                args.IsValid = true;
            }
        }



        protected void cvStartMileage_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int serviceId = Int32.Parse(hdfServiceId.Value);

            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGatewayForId = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            int? unitId = serviceInformationBasicInformationGatewayForId.GetUnitID(serviceId);

            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.LoadByUnitId((int)unitId, companyId);
            string unitType = unitsGateway.GetType((int)unitId);

            if (unitType == "Vehicle")
            {
                if (tbxPnlStartWorkStartMileage.Text == "")
                {
                    args.IsValid = false;
                }
            }
        }

        protected void cvCompleteMileage_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int serviceId = Int32.Parse(hdfServiceId.Value);

            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGatewayForId = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            int? unitId = serviceInformationBasicInformationGatewayForId.GetUnitID(serviceId);

            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.LoadByUnitId((int)unitId, companyId);
            string unitType = unitsGateway.GetType((int)unitId);

            if (unitType == "Vehicle")
            {
                if (tbxPnlCompleteWorkCompleteMileage.Text == "")
                {
                    args.IsValid = false;
                }
            }
        }        






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = null;
            bool validData = false;

            if (e.Item.Value == "mCancel")
            {
                if ((string)Request.QueryString["source_page"] == "wucSRUnassigned.ascx")
                {
                    url = "./../Dashboard/dashboard_login.aspx?source_page=out";
                    Response.Redirect(url);
                }
                else
                {
                    url = string.Format("./services_summary.aspx?source_page=services_state.aspx&dashboard=False&service_id=" + hdfServiceId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"]);
                    Response.Redirect(url);
                }
            }
            else
            {
                switch ((string)Request.QueryString["state"])
                {
                    case "Assigned":
                        Page.Validate("assignmentInformation");
                        if (Page.IsValid)
                        {
                            validData = true;
                        }
                        break;

                    case "Accepted":
                        validData = true;
                        break;

                    case "Rejected":
                        validData = true;
                        break;

                    case "StartWork":
                        Page.Validate("startWorkInformation");
                        if (Page.IsValid)
                        {
                            validData = true;
                        }
                        break;

                    case "CompleteWork":
                        Page.Validate("completeWorkInformation");
                        if (Page.IsValid)
                        {
                            validData = true;
                        }
                        break;
                }

                // For valid data
                if (validData)
                {
                    UpdateState();
                    UpdateDatabase();

                    if ((string)Request.QueryString["source_page"] == "wucSRUnassigned.ascx")
                    {
                        url = "./../Dashboard/dashboard_login.aspx?source_page=out";
                    }
                    else
                    {
                        url = string.Format("./services_summary.aspx?source_page=services_state.aspx&dashboard=False&service_id=" + hdfServiceId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=yes");
                    }

                    Response.Redirect(url);
                }
            }
        }



        protected void lkbtnCancel_Click(object sender, EventArgs e)
        {
            string url = string.Format("./services_summary.aspx?source_page=services_state.aspx&services_id=" + hdfServiceId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"]);
            Response.Redirect(url);
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./services_state.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_state=" + Request.QueryString["search_state"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void UpdateState()
        {
            int serviceId = Int32.Parse(hdfServiceId.Value);
            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);

            // General Data
            bool mtoDto = serviceInformationBasicInformationGateway.GetMtoDto(serviceId);
            string serviceDescription = serviceInformationBasicInformationGateway.GetServiceDescription(serviceId);
            string mileage = serviceInformationBasicInformationGateway.GetMileage(serviceId);
            int? libraryCategoriesId = null; if (serviceInformationBasicInformationGateway.GetLibraryCategoriesId(serviceId).HasValue) libraryCategoriesId = serviceInformationBasicInformationGateway.GetLibraryCategoriesId(serviceId).Value;

            // Initialize Data
            // ... Initialize Assigned Data with existent data
            DateTime? newAssignmentDateTime = null; if (serviceInformationBasicInformationGateway.GetAssignmentDateTime(serviceId).HasValue) newAssignmentDateTime = (DateTime)serviceInformationBasicInformationGateway.GetAssignmentDateTime(serviceId);
            DateTime? newDeadlineDate = null; if (serviceInformationBasicInformationGateway.GetAssignedDeadlineDate(serviceId).HasValue) newDeadlineDate = (DateTime)serviceInformationBasicInformationGateway.GetAssignedDeadlineDate(serviceId);
            bool newToTeamMember = serviceInformationBasicInformationGateway.GetToTeamMember(serviceId);
            int? newAssignTeamMemberID = null; if(serviceInformationBasicInformationGateway.GetAssignTeamMemberId(serviceId).HasValue) newAssignTeamMemberID = (int)serviceInformationBasicInformationGateway.GetAssignTeamMemberId(serviceId);
            string newThirdPartyVendor = serviceInformationBasicInformationGateway.GetAssignedThirdPartyVendor(serviceId);

            // ... Initialize Assigned Accepted Data with existent data
            DateTime? newAssignmentAcceptedDateTime = null; if (serviceInformationBasicInformationGateway.GetAcceptedDateTime(serviceId).HasValue) newAssignmentAcceptedDateTime = (DateTime)serviceInformationBasicInformationGateway.GetAcceptedDateTime(serviceId);
            
            // ... Initialize Assigned Rejected Data with existent data
            DateTime? newAssignmentRejectedDateTime = null; if (serviceInformationBasicInformationGateway.GetRejectedDateTime(serviceId).HasValue) newAssignmentRejectedDateTime = (DateTime)serviceInformationBasicInformationGateway.GetRejectedDateTime(serviceId);
            string newAssignmnetRejectedReason = serviceInformationBasicInformationGateway.GetRejectedReason(serviceId);

            // ... Initialize Start Work Data with existent data
            DateTime? newStartWorkDateTime = null; if (serviceInformationBasicInformationGateway.GetStartWorkDateTime(serviceId).HasValue) newStartWorkDateTime = (DateTime)serviceInformationBasicInformationGateway.GetStartWorkDateTime(serviceId);
            DateTime? newUnitOutOfServiceDate = null; if (serviceInformationBasicInformationGateway.GetUnitOutOfServiceDate(serviceId).HasValue) newUnitOutOfServiceDate = (DateTime)serviceInformationBasicInformationGateway.GetUnitOutOfServiceDate(serviceId);
            string newUnitOutOfServiceTime = serviceInformationBasicInformationGateway.GetUnitOutOfServiceTime(serviceId);
            string newStartWorkMileage = serviceInformationBasicInformationGateway.GetStartWorkMileage(serviceId);

            // ... Initialize Complete Work Data with existent data
            DateTime? newCompleteWorkDateTime = null; if (serviceInformationBasicInformationGateway.GetCompleteWorkDateTime(serviceId).HasValue) newCompleteWorkDateTime = (DateTime)serviceInformationBasicInformationGateway.GetCompleteWorkDateTime(serviceId);
            DateTime? newUnitBackInServiceDate = null; if (serviceInformationBasicInformationGateway.GetUnitBackInServiceDate(serviceId).HasValue) newUnitBackInServiceDate = (DateTime)serviceInformationBasicInformationGateway.GetUnitBackInServiceDate(serviceId);
            string newUnitBackInServiceTime = serviceInformationBasicInformationGateway.GetUnitBackInServiceTime(serviceId);
            string newCompleteWorkMileage = serviceInformationBasicInformationGateway.GetCompleteWorkMileage(serviceId);
            string newAssociatedChecklistRuleState = serviceInformationBasicInformationGateway.GetAssociatedChecklistRuleState(serviceId);

            // ... Get new values
            string serviceState = null;
            switch ((string)Request.QueryString["state"])
            {
                case "Assigned":
                    serviceState = "Assigned";
                    newAssignmentDateTime = DateTime.Now;
                    if (tkrdpPnlAssignDeadlineDate.SelectedDate.HasValue) newDeadlineDate = tkrdpPnlAssignDeadlineDate.SelectedDate.Value;
                    newToTeamMember = rbtnPnlAssignToTeamMember.Checked;
                    newAssignTeamMemberID = null; if (newToTeamMember) newAssignTeamMemberID = Int32.Parse(ddlPnlAssignAssignToTeamMember.SelectedValue);
                    newThirdPartyVendor = tbxPnlAssignAssignToThirdPartyVendor.Text.Trim();
                    break;

                case "Accepted":
                    serviceState = "Accepted";
                    newAssignmentAcceptedDateTime = DateTime.Now;
                    break;

                case "Rejected":
                    serviceState = "Rejected";
                    newAssignmentRejectedDateTime = DateTime.Now;
                    newAssignmnetRejectedReason = tbxPnlAssignmentRejectDataRejectedReason.Text.Trim();
                    break;

                case "StartWork":
                    serviceState = "In Progress";
                    newStartWorkDateTime = DateTime.Now;
                    newUnitOutOfServiceDate = null; if (tkrdpPnlStartWorkUnitOutOfServiceDate.SelectedDate.HasValue) newUnitOutOfServiceDate = tkrdpPnlStartWorkUnitOutOfServiceDate.SelectedDate.Value;
                    newUnitOutOfServiceTime = DateTime.Now.ToShortTimeString();
                    newStartWorkMileage = tbxPnlStartWorkStartMileage.Text.Trim();
                    break;

                case "CompleteWork":
                    serviceState = "Completed";
                    newCompleteWorkDateTime = DateTime.Now;
                    newUnitBackInServiceDate = null; if (tkrdpPnlCompleteWorkUnitBackInServiceDate.SelectedDate.HasValue) newUnitBackInServiceDate = tkrdpPnlCompleteWorkUnitBackInServiceDate.SelectedDate.Value;
                    newUnitBackInServiceTime = DateTime.Now.ToShortTimeString();
                    newCompleteWorkMileage = tbxPnlCompleteWorkCompleteMileage.Text.Trim();
                    newAssociatedChecklistRuleState = "Healthy";
                    break;
            }

            // Update service data
            ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation(serviceInformationTDS);
            serviceInformationBasicInformation.Update(serviceId, serviceState, mtoDto, serviceDescription, mileage, newAssignmentDateTime, newDeadlineDate, newToTeamMember, newAssignTeamMemberID, newThirdPartyVendor, newAssignmentAcceptedDateTime, newAssignmentRejectedDateTime, newAssignmnetRejectedReason, newStartWorkDateTime, newUnitOutOfServiceDate, newUnitOutOfServiceTime, newStartWorkMileage, newCompleteWorkDateTime, newUnitBackInServiceDate, newUnitBackInServiceTime, newCompleteWorkMileage, "", false, null, "", null, newAssociatedChecklistRuleState, libraryCategoriesId);
        }



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                ServiceInformationBasicInformation serviceInformationBasicInformation = new ServiceInformationBasicInformation(serviceInformationTDS);
                serviceInformationBasicInformation.Save(companyId);
                string subject = "";
                string title = "";

                // Send Mails
                switch ((string)Request.QueryString["state"])
                {
                    case "Assigned":
                        // ... If there is an assignation send mail to Assigned Personal
                        if (rbtnPnlAssignToTeamMember.Checked)
                        {
                            SendMailTeamMember();
                        }

                        // ... Send  mail to fleet manager
                        subject = "New service request has been registered.";
                        title = "The following service request has been assigned.";
                        SendMailFleetManager (subject, title);                                                
                        break;

                    case "Accepted":
                        subject = "A service request has been accepted.";
                        title = "The following service request has been accepted.";
                        SendMailFleetManagerAcceptRejectCompleted(subject, title);
                        break;

                    case "Rejected":
                        subject = "A service request has been rejected.";
                        title = "The following service request has been rejected.";
                        SendMailFleetManagerAcceptRejectCompleted(subject, title);
                        break;

                    case "CompleteWork":
                        subject = "A service request has been completed.";
                        title = "The following service request has been completed.";
                        SendMailFleetManagerAcceptRejectCompleted(subject, title);
                        break;
                }

                DB.CommitTransaction();

                // Store datasets
                serviceInformationTDS.AcceptChanges();
                Session["serviceInformationTDS"] = serviceInformationTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void LoadMileage()
        {
            int serviceId = Int32.Parse(hdfServiceId.Value);

            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGatewayForId = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            
            // Operation check
            switch ((string)Request.QueryString["state"])
            {
                case "StartWork":
                    string generalMileage = serviceInformationBasicInformationGatewayForId.GetMileage(serviceId);

                    if (tbxPnlStartWorkStartMileage.Text == "" && generalMileage != "")
                    {
                        tbxPnlStartWorkStartMileage.Text = generalMileage;
                    }
                    break;

                case "CompleteWork":
                    string startWorkMileage = serviceInformationBasicInformationGatewayForId.GetStartWorkMileage(serviceId);

                    if (tbxPnlCompleteWorkCompleteMileage.Text == "" && startWorkMileage != "")
                    {
                        tbxPnlCompleteWorkCompleteMileage.Text = startWorkMileage;
                    }
                    break;
            }
        }



        private void TagPage()
        {
            hdfCompanyId.Value = Session["companyID"].ToString();
            hdfServiceId.Value = Request.QueryString["service_id"];
            hdfActiveTab.Value = Request.QueryString["active_tab"].ToString();

            int companyId = Int32.Parse(hdfCompanyId.Value);
            int serviceId = Int32.Parse(hdfServiceId.Value);

            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGatewayForId = new ServiceInformationBasicInformationGateway();
            serviceInformationBasicInformationGatewayForId.LoadByServiceId(serviceId, companyId);
            int? unitId = serviceInformationBasicInformationGatewayForId.GetUnitID(serviceId);

            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.LoadByUnitId((int)unitId, companyId);
            hdfUnitType.Value = unitsGateway.GetType((int)unitId);
            hdfCompanyLevel.Value = unitsGateway.GetCompanyLevelId((int)unitId).ToString();
            
            int companyLevel = Int32.Parse(hdfCompanyLevel.Value);
            CompanyLevelGateway companyLevelGateway = new CompanyLevelGateway();
            companyLevelGateway.LoadByCompanyLevelId(companyLevel, companyId);
            hdfMileageUnitOfMeasurement.Value = companyLevelGateway.GetUnitsUnitOfMeasurement(companyLevel);
            lblPnlStartWorkStartMileageUnitOfMeasurement.Text = hdfMileageUnitOfMeasurement.Value;
            lblPnlCompleteWorkCompleteMileageUnitOfMeasurement.Text = hdfMileageUnitOfMeasurement.Value;
        }



        private void SendMailTeamMember()
        {
            // Get mail information
            string mailTo = "";
            string nameTo = "";
            string subject = "You have assigned service requests.";
            string body = "";

            int employeeId = Int32.Parse(ddlPnlAssignAssignToTeamMember.SelectedValue);
            EmployeeGateway employeesGateway = new EmployeeGateway();
            employeesGateway.LoadForMailsByEmployeeId(employeeId);

            if (employeesGateway.Table.Rows.Count > 0)
            {
                // Assigned TeamMember
                mailTo = employeesGateway.GetEMail(employeeId);
                nameTo = employeesGateway.GetFirstName(employeeId) + " " + employeesGateway.GetLastName(employeeId);
            }

            int serviceId = Int32.Parse(hdfServiceId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int companyLevel = Int32.Parse(hdfCompanyLevel.Value); 

            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            serviceInformationBasicInformationGateway.LoadByServiceId(serviceId, companyId);

            // Mails body
            body = body + "\nHi " + nameTo + ",\n\nThe following service request has been assigned to you. \n";
            body = body + "\n Unit: " + serviceInformationBasicInformationGateway.GetUnitCode(serviceId) + " - " + serviceInformationBasicInformationGateway.GetUnitDescription(serviceId) + "\n";
            body = body + "\n Fixed Date: ";
            if (serviceInformationBasicInformationGateway.GetMtoDto(serviceId)) body = body + "Yes "; else body = body + "No ";

            string unitType = hdfUnitType.Value;
            if (unitType == "Vehicle")
            {
                body = body + "\n Mileage: " + serviceInformationBasicInformationGateway.GetMileage(serviceId) + " " + hdfMileageUnitOfMeasurement.Value;
            }

            body = body + "\n Problem Description: " + serviceInformationBasicInformationGateway.GetServiceDescription(serviceId);

            if (tkrdpPnlAssignDeadlineDate.SelectedDate.HasValue)
            {
                DateTime deadlineDate = tkrdpPnlAssignDeadlineDate.SelectedDate.Value;
                string deadlineDateText = deadlineDate.Month.ToString() + "/" + deadlineDate.Day.ToString() + "/" + deadlineDate.Year.ToString();
                body = body + " \n Deadline date: " + deadlineDateText;
            }
            else
            {
                body = body + " \n Deadline date: ";
            }

            int registeredByLoginId = Convert.ToInt32(Session["loginID"]);
            employeesGateway.LoadByLoginId(registeredByLoginId);
            int registeredByEmployeeId = employeesGateway.GetEmployeIdByLoginId(registeredByLoginId);
            if (employeesGateway.Table.Rows.Count > 0)
            {
                body = body + "\n Assigned By: " + employeesGateway.GetFirstName(registeredByEmployeeId) + " " + employeesGateway.GetLastName(registeredByEmployeeId);
            }

            //Send Mail
            SendMail(mailTo, subject, body);
        }



        private void SendMailFleetManager( string subject, string title)
        {
            // Get mail information
            string mailTo = "";
            string nameTo = "";
            string body = "";
            int serviceId = Int32.Parse(hdfServiceId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int companyLevel = Int32.Parse(hdfCompanyLevel.Value); 

            // MailtTo, nameTo
            int companyLevelId = Int32.Parse(hdfCompanyLevel.Value);

            Employee employees = new Employee();
            employees.LoadByFleetManager(companyLevelId);

            mailTo = employees.GetAllFleetManagersEMails();
            nameTo = employees.GetAllFleetManagersNames();                               

            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            serviceInformationBasicInformationGateway.LoadByServiceId(serviceId, companyId);

            // Mails body
            body = body + "\nHi " + nameTo + ",\n\n"+ title + " \n";
            body = body + "\n Unit: " + serviceInformationBasicInformationGateway.GetUnitCode(serviceId) + " - " + serviceInformationBasicInformationGateway.GetUnitDescription(serviceId);
            body = body + "\n Fixed Date: ";
            if (serviceInformationBasicInformationGateway.GetMtoDto(serviceId)) body = body + "Yes "; else body = body + "No ";

            string unitType = hdfUnitType.Value;
            if (unitType == "Vehicle")
            {
                body = body + "\n Mileage: " + serviceInformationBasicInformationGateway.GetMileage(serviceId) + " " + hdfMileageUnitOfMeasurement.Value;
            }

            body = body + "\n Problem Description: " + serviceInformationBasicInformationGateway.GetServiceDescription(serviceId);

            if (tkrdpPnlAssignDeadlineDate.SelectedDate.HasValue)
            {
                DateTime deadlineDate = tkrdpPnlAssignDeadlineDate.SelectedDate.Value;
                string deadlineDateText = deadlineDate.Month.ToString() + "/" + deadlineDate.Day.ToString() + "/" + deadlineDate.Year.ToString();
                body = body + " \n Deadline date: " + deadlineDateText;
            }
            else
            {
                body = body + " \n Deadline date: ";
            }

            if(rbtnPnlAssignToTeamMember.Checked)
            {
                int employeeId = Int32.Parse(ddlPnlAssignAssignToTeamMember.SelectedValue);
                EmployeeGateway employeesGateway = new EmployeeGateway();
                employeesGateway.LoadForMailsByEmployeeId(employeeId);
                string assignedTo = "";
                if (employeesGateway.Table.Rows.Count > 0)
                {
                    // Assigned TeamMember
                    assignedTo = employeesGateway.GetFirstName(employeeId) + " " + employeesGateway.GetLastName(employeeId);
                }

                body = body + "\n Assigned Team Member: " + assignedTo;
            }

            if (rbtnPnlAssignToThirdPartyVendor.Checked)
            {
                body = body + "\n Assigned Third Party Vendor: " + tbxPnlAssignAssignToThirdPartyVendor.Text;
            }

            //Send Mail
            SendMail(mailTo, subject, body);
        }



        private void SendMailFleetManagerAcceptRejectCompleted(string subject, string title)
        {
            // Get mail information
            string mailTo = "";
            string nameTo = "";
            string body = "";
            int serviceId = Int32.Parse(hdfServiceId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int companyLevel = Int32.Parse(hdfCompanyLevel.Value); 

            // MailtTo, nameTo
            int companyLevelId = Int32.Parse(hdfCompanyLevel.Value);

            Employee employees = new Employee();
            employees.LoadByFleetManager(companyLevelId);

            mailTo = employees.GetAllFleetManagersEMails();
            nameTo = employees.GetAllFleetManagersNames();                               

            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway(serviceInformationTDS);
            serviceInformationBasicInformationGateway.LoadByServiceId(serviceId, companyId);          

            // Mails body
            body = body + "\nHi " + nameTo + ",\n\n" + title + " \n";
            body = body + "\n Service: " + serviceInformationBasicInformationGateway.GetServiceNumber(serviceId) + " - " + serviceInformationBasicInformationGateway.GetServiceDescription(serviceId);
            body = body + "\n Unit: " + serviceInformationBasicInformationGateway.GetUnitCode(serviceId) + " - " + serviceInformationBasicInformationGateway.GetUnitDescription(serviceId);
            body = body + "\n Fixed Date: ";
            if (serviceInformationBasicInformationGateway.GetMtoDto(serviceId)) body = body + "Yes "; else body = body + "No ";

            string unitType = hdfUnitType.Value;
            if (unitType == "Vehicle")
            {
                body = body + "\n Mileage: " + serviceInformationBasicInformationGateway.GetMileage(serviceId) + " " + hdfMileageUnitOfMeasurement.Value;
            }

            body = body + "\n Problem Description: " + serviceInformationBasicInformationGateway.GetServiceDescription(serviceId);

            if (serviceInformationBasicInformationGateway.GetAssignedDeadlineDate(serviceId).HasValue)
            {
                DateTime deadlineDate = (DateTime)serviceInformationBasicInformationGateway.GetAssignedDeadlineDate(serviceId);
                string deadlineDateText = deadlineDate.Month.ToString() + "/" + deadlineDate.Day.ToString() + "/" + deadlineDate.Year.ToString();
                body = body + "\n Deadline Date: " + deadlineDateText;
            }

            // Asignation
            if (serviceInformationBasicInformationGateway.GetAssignTeamMemberId(serviceId).HasValue)
            {
                int employeeId = (int)serviceInformationBasicInformationGateway.GetAssignTeamMemberId(serviceId);
                EmployeeGateway employeesGateway = new EmployeeGateway();
                employeesGateway.LoadByEmployeeId(employeeId);

                string assignedTo = "";
                if (employeesGateway.Table.Rows.Count > 0)
                {
                    // Assigned TeamMember
                    assignedTo = employeesGateway.GetFirstName(employeeId) + " " + employeesGateway.GetLastName(employeeId);
                }

                body = body + "\n Assigned Team Member: " + assignedTo;
            }

            // ... Start work information
            if (serviceInformationBasicInformationGateway.GetStartWorkDateTime(serviceId).HasValue)
            {
                DateTime startWorkDate = (DateTime)serviceInformationBasicInformationGateway.GetStartWorkDateTime(serviceId);
                body = body + "\n Start Work Date & Time: " + startWorkDate;
            }

            // ... Complete work information
            if (serviceInformationBasicInformationGateway.GetCompleteWorkDateTime(serviceId).HasValue)
            {
                DateTime completeWorkDate = (DateTime)serviceInformationBasicInformationGateway.GetCompleteWorkDateTime(serviceId);
                body = body + "\n Complete Work Date & Time: " + completeWorkDate;
            }

            //Send Mail
            SendMail(mailTo, subject, body);
        }



        private void SendMail(string mailTo, string subject, string body)
        {
            //SendMailLiveSite(mailTo, subject, body);
            //SendMailTestSite(mailTo, subject, body);
        }



        private void SendMailLiveSite(string mailTo, string subject, string body)
        {
            string error;

            // For live site
            string entireBody = "";

            if ((mailTo != "") && (subject != "") && (body != ""))
            {
                entireBody = entireBody + body + "\n\n\n\n\nRegards,\n\n" + "LFS Admin Team.\n\n";
                LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMail(mailTo, "sussel@nerdsonsite.com", subject, entireBody, false, out error);
            }
        }



        private void SendMailTestSite(string mailTo, string subject, string body)
        {
            string error;

            // For Test Site
            string entireBody = "--- SENT FROM THE TEST SITE --- \n";

            if ((mailTo != "") && (subject != "") && (body != ""))
            {
                entireBody = entireBody + body + "\n\n\n\n\nRegards,\n\n" + "LFS Admin Team.\n\n";
                LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMail("sussel@nerdsonsite.com", "sussel@nerdsonsite.com, humberto@nerdsonsite.com, jacqueline.claure@nerdsonsite.com", subject, entireBody, false, out error);
            }  
        }


      
    }
}