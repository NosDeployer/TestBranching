using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.FleetManagement.Common;
using LiquiForce.LFSLive.BL.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.BL.FleetManagement.Dashboard;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.DA.FleetManagement.Dashboard;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls
{
    /// <summary>
    /// wucSRUnassigned
    /// </summary>
    public partial class wucSRUnassigned : System.Web.UI.UserControl
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected DashboardTDS dashboardUnassignedServiceRequestsTDS;
        protected DashboardTDS.DashboardUnassignedServiceRequestsDataTable dashboardUnassignedServiceRequests;
        protected CompanyLevelsTDS companyLevelsForSRUnassignedTDS;
        protected int level = -1;





        
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
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in wucSRUnassigned.ascx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                
                int loginId = Convert.ToInt32(Session["loginID"]);
                EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                hdfEmployeeId.Value = employeeGateway.GetEmployeIdByLoginId(loginId).ToString();
                
                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardUnassignedServiceRequestsDummy");
                ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["unassignedSRWidget"];

                // If coming from 
                // ... Out
                if (Request.QueryString["source_page"] == "out")
                {
                    CompanyLevelsManagersGateway companyLevelsManagersGateway = new CompanyLevelsManagersGateway();

                    // ... For Grid
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    int employeeId = Convert.ToInt32(hdfEmployeeId.Value);
                    int companyLevelId = companyLevelsManagersGateway.GetCompanyLevelId(employeeId, companyId);

                    // ... For ddl working location
                    companyLevelsForSRUnassignedTDS = new CompanyLevelsTDS();

                    CompanyLevel companyLevel = new CompanyLevel(companyLevelsForSRUnassignedTDS);
                    companyLevel.LoadNodes(companyId);

                    GetNodeForCompanyLevel(1);

                    ddlWorkingLocation.Items.Insert(0, new ListItem("(All)", "0"));

                    if (HttpContext.Current.Session["unassignedSRWidget"] != null)
                    {
                        ddlWorkingLocation.SelectedIndex = Convert.ToInt32(arrayListWidgetData[0].ToString());
                        ddlType.SelectedIndex = Convert.ToInt32(arrayListWidgetData[1].ToString());

                        companyLevelId = Convert.ToInt32(ddlWorkingLocation.SelectedValue);
                    }
                    else
                    {
                        ddlWorkingLocation.SelectedValue = companyLevelId.ToString();
                    }

                    dashboardUnassignedServiceRequestsTDS = new DashboardTDS();
                    DashboardUnassignedServiceRequests model = new DashboardUnassignedServiceRequests(dashboardUnassignedServiceRequestsTDS);
                    
                    // ... Load for admin
                    if (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]))
                    {
                        if (companyLevelId == 0)
                        {
                            if (ddlType.SelectedValue != "(All)")
                            {
                                model.LoadAllUnassignedServicesByUnitType(companyId, ddlType.SelectedValue);
                            }
                            else
                            {
                                model.LoadAllUnassignedServices(companyId);
                            }
                        }
                        else
                        {
                            if (ddlType.SelectedValue != "(All)")
                            {
                                model.LoadAllUnassignedServicesByCompanyLevelIdUnitType(companyId, companyLevelId, ddlType.SelectedValue);
                            }
                            else
                            {
                                model.LoadAllUnassignedServicesByCompanyLevelId(companyId, companyLevelId);
                            }
                        }
                    }
                    else
                    {
                        if (companyLevelId == 0)
                        {
                            if (ddlType.SelectedValue != "(All)")
                            {
                                model.LoadAllUnassignedServicesByAssignTeamMemberIDUnitType(employeeId, companyId, ddlType.SelectedValue);
                            }
                            else
                            {
                                // ... Load for assigned employee                            
                                model.LoadAllUnassignedServicesByAssignTeamMemberID(employeeId, companyId);
                            }
                        }
                        else
                        {
                            if (ddlType.SelectedValue != "(All)")
                            {
                                model.LoadAllUnassignedServicesByAssignTeamMemberIDCompanyLevelIdUnitType(employeeId, companyId, companyLevelId, ddlType.SelectedValue);
                            }
                            else
                            {
                                model.LoadAllUnassignedServicesByAssignTeamMemberIDCompanyLevelId(employeeId, companyId, companyLevelId);
                            }
                        }
                    }

                    model.UpdateForDashboard(companyId);

                    // ... Store datasets
                    HttpContext.Current.Session.Add("dashboardUnassignedServiceRequestsTDS", dashboardUnassignedServiceRequestsTDS);
                    HttpContext.Current.Session.Add("companyLevelsForSRUnassignedTDS", companyLevelsForSRUnassignedTDS);
                }
            }
            else
            {
                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardUnassignedServiceRequestsDummy");

                // Restore datasets
                dashboardUnassignedServiceRequestsTDS = (DashboardTDS)HttpContext.Current.Session["dashboardUnassignedServiceRequestsTDS"];
                companyLevelsForSRUnassignedTDS = (CompanyLevelsTDS)HttpContext.Current.Session["companyLevelsForSRUnassignedTDS"];
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Initialize links for service request tools
            lkbtnAddServiceRequest.Attributes.Add("onclick", string.Format("return LkbtnAddServiceRequestClik();"));

            if (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]))
            {
                lkbtnServiceRequestManager.Visible = true;
            }
            else
            {
                lkbtnServiceRequestManager.Visible = false;
            }

            // Initialize reminder links
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int employeeId = Convert.ToInt32(hdfEmployeeId.Value);
            int companyLevelId = Int32.Parse(ddlWorkingLocation.SelectedValue);

            dashboardUnassignedServiceRequestsTDS = (DashboardTDS)HttpContext.Current.Session["dashboardUnassignedServiceRequestsTDS"];
            DashboardUnassignedServiceRequestsGateway dashboardUnassignedServiceRequestsGateway = new DashboardUnassignedServiceRequestsGateway(dashboardUnassignedServiceRequestsTDS);

            if (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]))
            {
                if (companyLevelId == 0)
                {
                    if (ddlType.SelectedValue != "(All)")
                    {
                        // ... For unassigned service requests            
                        int countUnassignedSR = dashboardUnassignedServiceRequestsGateway.CountUnassignedServiceRequestsByUnitType(companyId, ddlType.SelectedValue);
                        lkbtnUnassignedServiceRequests.Text = countUnassignedSR.ToString() + " Unassigned Services Requests";

                        // ... For rejected service requests
                        int countRejectedSR = dashboardUnassignedServiceRequestsGateway.CountRejectedServiceRequestsByUnitType(companyId, ddlType.SelectedValue);
                        lkbtnRejectedServiceRequests.Text = countRejectedSR.ToString() + " Rejected Services Requests";
                    }
                    else
                    {
                        // ... For unassigned service requests            
                        int countUnassignedSR = dashboardUnassignedServiceRequestsGateway.CountUnassignedServiceRequests(companyId);
                        lkbtnUnassignedServiceRequests.Text = countUnassignedSR.ToString() + " Unassigned Services Requests";

                        // ... For rejected service requests
                        int countRejectedSR = dashboardUnassignedServiceRequestsGateway.CountRejectedServiceRequests(companyId);
                        lkbtnRejectedServiceRequests.Text = countRejectedSR.ToString() + " Rejected Services Requests";
                    }
                }
                else
                {
                    if (ddlType.SelectedValue != "(All)")
                    {
                        // ... For unassigned service requests            
                        int countUnassignedSR = dashboardUnassignedServiceRequestsGateway.CountUnassignedServiceRequestsByCompanyLevelIdUnitType(companyId, companyLevelId, ddlType.SelectedValue);
                        lkbtnUnassignedServiceRequests.Text = countUnassignedSR.ToString() + " Unassigned Services Requests";

                        // ... For rejected service requests
                        int countRejectedSR = dashboardUnassignedServiceRequestsGateway.CountRejectedServiceRequestsByCompanyLevelIdUnitType(companyId, companyLevelId, ddlType.SelectedValue);
                        lkbtnRejectedServiceRequests.Text = countRejectedSR.ToString() + " Rejected Services Requests";
                    }
                    else
                    {
                        // ... For unassigned service requests            
                        int countUnassignedSR = dashboardUnassignedServiceRequestsGateway.CountUnassignedServiceRequestsByCompanyLevelId(companyId, companyLevelId);
                        lkbtnUnassignedServiceRequests.Text = countUnassignedSR.ToString() + " Unassigned Services Requests";

                        // ... For rejected service requests
                        int countRejectedSR = dashboardUnassignedServiceRequestsGateway.CountRejectedServiceRequestsByCompanyLevelId(companyId, companyLevelId);
                        lkbtnRejectedServiceRequests.Text = countRejectedSR.ToString() + " Rejected Services Requests";
                    }
                }
            }
            else
            {
                if (companyLevelId == 0)
                {
                    if (ddlType.SelectedValue != "(All)")
                    {
                        // ... For unassigned service requests            
                        int countUnassignedSR = dashboardUnassignedServiceRequestsGateway.CountUnassignedServiceRequestsByAssignTeamMemberIDUnitType(employeeId, companyId, ddlType.SelectedValue);
                        lkbtnUnassignedServiceRequests.Text = countUnassignedSR.ToString() + " Unassigned Services Requests";

                        // ... For rejected service requests
                        int countRejectedSR = dashboardUnassignedServiceRequestsGateway.CountRejectedServiceRequestsByAssignTeamMemberIDUnitType(employeeId, companyId, ddlType.SelectedValue);
                        lkbtnRejectedServiceRequests.Text = countRejectedSR.ToString() + " Rejected Services Requests";
                    }
                    else
                    {
                        // ... For unassigned service requests            
                        int countUnassignedSR = dashboardUnassignedServiceRequestsGateway.CountUnassignedServiceRequestsByAssignTeamMemberID(employeeId, companyId);
                        lkbtnUnassignedServiceRequests.Text = countUnassignedSR.ToString() + " Unassigned Services Requests";

                        // ... For rejected service requests
                        int countRejectedSR = dashboardUnassignedServiceRequestsGateway.CountRejectedServiceRequestsByAssignTeamMemberID(employeeId, companyId);
                        lkbtnRejectedServiceRequests.Text = countRejectedSR.ToString() + " Rejected Services Requests";
                    }
                }
                else
                {
                    if (ddlType.SelectedValue != "(All)")
                    {
                        // ... For unassigned service requests            
                        int countUnassignedSR = dashboardUnassignedServiceRequestsGateway.CountUnassignedServiceRequestsByAssignTeamMemberIDCompanyLevelIdUnitType(employeeId, companyId, companyLevelId, ddlType.SelectedValue);
                        lkbtnUnassignedServiceRequests.Text = countUnassignedSR.ToString() + " Unassigned Services Requests";

                        // ... For rejected service requests
                        int countRejectedSR = dashboardUnassignedServiceRequestsGateway.CountRejectedServiceRequestsByAssignTeamMemberIDCompanyLevelIdUnitType(employeeId, companyId, companyLevelId, ddlType.SelectedValue);
                        lkbtnRejectedServiceRequests.Text = countRejectedSR.ToString() + " Rejected Services Requests";
                    }
                    else
                    {
                        // ... For unassigned service requests            
                        int countUnassignedSR = dashboardUnassignedServiceRequestsGateway.CountUnassignedServiceRequestsByAssignTeamMemberIDCompanyLevelId(employeeId, companyId, companyLevelId);
                        lkbtnUnassignedServiceRequests.Text = countUnassignedSR.ToString() + " Unassigned Services Requests";

                        // ... For rejected service requests
                        int countRejectedSR = dashboardUnassignedServiceRequestsGateway.CountRejectedServiceRequestsByAssignTeamMemberIDCompanyLevelId(employeeId, companyId, companyLevelId);
                        lkbtnRejectedServiceRequests.Text = countRejectedSR.ToString() + " Rejected Services Requests";
                    }
                }
            }
        }           


               
             
        
        
        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdUnassignedServiceRequests_DataBound(object sender, EventArgs e)
        {
            UnassignedServiceRequestsEmptyFix(grdUnassignedServiceRequests);

            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["unassignedSRWidget"] != null)
                {
                    ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["unassignedSRWidget"];
                    int pageIndex = Convert.ToInt32(arrayListWidgetData[2].ToString());

                    if (grdUnassignedServiceRequests.PageCount > pageIndex)
                    {
                        grdUnassignedServiceRequests.PageIndex = pageIndex;
                    }
                    else
                    {
                        grdUnassignedServiceRequests.PageIndex = grdUnassignedServiceRequests.PageCount - 1;
                    }
                }
            }
        }




        protected void grdUnassignedServiceRequests_PageIndexChanged(object sender, EventArgs e)
        {
            StoreWidgetsState();
        }



        protected void grdUnassignedServiceRequests_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            UnassignedServiceRequestsProcessGrid();
        }

        

        protected void lkbtnServiceRequestManager_Click(object sender, EventArgs e)
        {
            hdfOriginBtn.Value = "Manager";            

            Page.Validate("unassigned");
            if (Page.IsValid)
            {
                PostPageChanges();

                foreach (GridViewRow row in grdUnassignedServiceRequests.Rows)
                {
                    if (((CheckBox)row.FindControl("cbxSelected")).Checked)
                    {
                        string serviceIdLabel = ((Label)row.FindControl("lblServiceID")).Text.Trim();
                        int serviceId = Int32.Parse(serviceIdLabel.ToString().Trim());

                        string script = "<script language='javascript'>";
                        string url = "./../../FleetManagement/Services/services_manager_tool.aspx?source_page=services_navigator.aspx&service_id=" + serviceId + "&dashboard=True&unit_id=none";
                        script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650')", url);
                        script = script + "</script>";
                        Response.Write(script);
                    }
                }
            }
        }



        protected void lkbtnAssignServiceRequest_Click(object sender, EventArgs e)
        {
            string url = "";
            hdfOriginBtn.Value = "Assign";

            Page.Validate("unassigned");
            if (Page.IsValid)
            {
                PostPageChanges();

                foreach (GridViewRow row in grdUnassignedServiceRequests.Rows)
                {
                    if (((CheckBox)row.FindControl("cbxSelected")).Checked)
                    {
                        string serviceIdLabel = ((Label)row.FindControl("lblServiceID")).Text.Trim();
                        int serviceId = Int32.Parse(serviceIdLabel.ToString().Trim());

                        url = "./../../FleetManagement/Services/services_state.aspx?source_page=wucSRUnassigned.ascx&service_id=" + serviceId + "&active_tab=0&state=Assigned" + GetNavigatorState();
                    }
                }
            }

            if (url != "") Response.Redirect(url);
        }



        protected void lkbtnUnassignServiceRequests_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> {window.open('./wucSRUnassigned_unassigned_report.aspx?&format=pdf', '_blank', 'toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
        }



        protected void lkbtnRejectedServiceRequests_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> {window.open('./wucSRUnassigned_rejected_report.aspx?&format=pdf', '_blank', 'toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
        }

        

        protected void cvGrdUnassignedServiceRequests_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((hdfOriginBtn.Value == "Assign") || (hdfOriginBtn.Value == "Manager"))
            {
                CustomValidator cvSelectedServices = (CustomValidator)source;
                args.IsValid = false;

                if (grdUnassignedServiceRequests.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdUnassignedServiceRequests.Rows)
                    {
                        if (((CheckBox)row.FindControl("cbxSelected")).Checked)
                        {
                            args.IsValid = true;
                        }
                    }

                    if (!args.IsValid)
                    {
                        cvSelectedServices.ErrorMessage = "At least one item must be selected.";
                    }
                }
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void ddlWorkingLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            StoreWidgetsStateByDdl();
            LoadData();
        }



        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            StoreWidgetsStateByDdl();
            LoadData();
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void StoreWidgetsState()
        {
            ArrayList arrayListWidgetData = new ArrayList();
            arrayListWidgetData.Insert(0, ddlWorkingLocation.SelectedIndex);
            arrayListWidgetData.Insert(1, ddlType.SelectedIndex);
            arrayListWidgetData.Insert(2, grdUnassignedServiceRequests.PageIndex);

            HttpContext.Current.Session.Add("unassignedSRWidget", arrayListWidgetData);
        }



        private void StoreWidgetsStateByDdl()
        {
            ArrayList arrayListWidgetData = new ArrayList();
            arrayListWidgetData.Insert(0, ddlWorkingLocation.SelectedIndex);
            arrayListWidgetData.Insert(1, ddlType.SelectedIndex);
            arrayListWidgetData.Insert(2, 0);

            HttpContext.Current.Session.Add("unassignedSRWidget", arrayListWidgetData);
        }



        private void LoadData()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int companyLevelId = Int32.Parse(ddlWorkingLocation.SelectedValue);

            dashboardUnassignedServiceRequestsTDS = (DashboardTDS)HttpContext.Current.Session["dashboardUnassignedServiceRequestsTDS"];
            DashboardUnassignedServiceRequests model = new DashboardUnassignedServiceRequests(dashboardUnassignedServiceRequestsTDS);

            // ... Load for admin
            if (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]))
            {
                if (companyLevelId == 0)
                {
                    if (ddlType.SelectedValue != "(All)")
                    {
                        model.LoadAllUnassignedServicesByUnitType(companyId, ddlType.SelectedValue);
                    }
                    else
                    {
                        model.LoadAllUnassignedServices(companyId);
                    }
                }
                else
                {
                    if (ddlType.SelectedValue != "(All)")
                    {
                        model.LoadAllUnassignedServicesByCompanyLevelIdUnitType(companyId, companyLevelId, ddlType.SelectedValue);
                    }
                    else
                    {
                        model.LoadAllUnassignedServicesByCompanyLevelId(companyId, companyLevelId);
                    }
                }
            }
            else
            {
                int employeeId = Convert.ToInt32(hdfEmployeeId.Value);

                if (companyLevelId == 0)
                {
                    if (ddlType.SelectedValue != "(All)")
                    {
                        model.LoadAllUnassignedServicesByAssignTeamMemberIDUnitType(employeeId, companyId, ddlType.SelectedValue);
                    }
                    else
                    {
                        // ... Load for assigned employee                    
                        model.LoadAllUnassignedServicesByAssignTeamMemberID(employeeId, companyId);
                    }
                }
                else
                {
                    if (ddlType.SelectedValue != "(All)")
                    {
                        model.LoadAllUnassignedServicesByAssignTeamMemberIDCompanyLevelIdUnitType(employeeId, companyId, companyLevelId, ddlType.SelectedValue);
                    }
                    else
                    {
                        // ... Load for assigned employee                    
                        model.LoadAllUnassignedServicesByAssignTeamMemberIDCompanyLevelId(employeeId, companyId, companyLevelId);
                    }
                }
            }

            model.UpdateForDashboard(companyId);

            HttpContext.Current.Session.Add("dashboardUnassignedServiceRequestsTDS", dashboardUnassignedServiceRequestsTDS);

            Page.DataBind();
        }



        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";

            Page.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            Page.ClientScript.RegisterClientScriptInclude("clientSideCode", "./dashboard.js");
        }



        public string GetUrl(object str)
        {
            int serviceId = Int32.Parse(str.ToString());

            string url = "./../../Services/services_summary.aspx?source_page=wucSRUnassigned.ascx&dashboard=True&service_id=" + serviceId + "&active_tab=0" + GetNavigatorState();
            return url;
        }



        public DashboardTDS.DashboardUnassignedServiceRequestsDataTable GetDetails()
        {
            dashboardUnassignedServiceRequests = (DashboardTDS.DashboardUnassignedServiceRequestsDataTable)HttpContext.Current.Session["dashboardUnassignedServiceRequestsDummy"];

            if (dashboardUnassignedServiceRequests == null)
            {
                dashboardUnassignedServiceRequests = ((DashboardTDS)HttpContext.Current.Session["dashboardUnassignedServiceRequestsTDS"]).DashboardUnassignedServiceRequests;

            }

            return dashboardUnassignedServiceRequests;
        }



        protected void UnassignedServiceRequestsEmptyFix(GridView grdView)
        {
            if (grdUnassignedServiceRequests.Rows.Count == 0)
            {
                DashboardTDS.DashboardUnassignedServiceRequestsDataTable dt = new DashboardTDS.DashboardUnassignedServiceRequestsDataTable();
                dt.AddDashboardUnassignedServiceRequestsRow(0, "", false, "");
                Session["dashboardUnassignedServiceRequestsDummy"] = dt;

                grdUnassignedServiceRequests.DataBind();
            }

            // Normally executes at all postbacks
            if (grdUnassignedServiceRequests.Rows.Count == 1)
            {
                DashboardTDS.DashboardUnassignedServiceRequestsDataTable dt = (DashboardTDS.DashboardUnassignedServiceRequestsDataTable)Session["dashboardUnassignedServiceRequestsDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdUnassignedServiceRequests.Rows[0].Visible = false;
                    grdUnassignedServiceRequests.Rows[0].Controls.Clear();
                }
            }
        }



        private void UnassignedServiceRequestsProcessGrid()
        {
            dashboardUnassignedServiceRequestsTDS = (DashboardTDS)HttpContext.Current.Session["dashboardUnassignedServiceRequestsTDS"];
            DashboardUnassignedServiceRequests model = new DashboardUnassignedServiceRequests(dashboardUnassignedServiceRequestsTDS);

            // update rows
            if (Session["dashboardUnassignedServiceRequestsDummy"] == null)
            {
                foreach (GridViewRow row in grdUnassignedServiceRequests.Rows)
                {
                    int serviceId = int.Parse(grdUnassignedServiceRequests.DataKeys[row.RowIndex].Values["ServiceID"].ToString());
                    bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                    model.Update( serviceId, int.Parse(hdfCompanyId.Value), selected);
                }

                model.Table.AcceptChanges();

                dashboardUnassignedServiceRequests = (DashboardTDS.DashboardUnassignedServiceRequestsDataTable)model.Table;
                Session["dashboardUnassignedServiceRequests"] = dashboardUnassignedServiceRequests;

                HttpContext.Current.Session.Add("dashboardUnassignedServiceRequestsTDS", dashboardUnassignedServiceRequestsTDS);
            }
        }



        private void PostPageChanges()
        {
            DashboardUnassignedServiceRequests dashboardUnassignedServiceRequests = new DashboardUnassignedServiceRequests(dashboardUnassignedServiceRequestsTDS);

            // Update Grid SR Unassigned rows
            foreach (GridViewRow row in grdUnassignedServiceRequests.Rows)
            {
                string serviceIdLabel = ((Label)row.FindControl("lblServiceID")).Text.Trim();
                int serviceId = Int32.Parse(serviceIdLabel.ToString().Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                int companyId = Int32.Parse(hdfCompanyId.Value);

                dashboardUnassignedServiceRequests.Update(serviceId, companyId, selected);
            }

            dashboardUnassignedServiceRequests.Data.AcceptChanges();

            // Store datasets
            Session["dashboardUnassignedServiceRequestsTDS"] = dashboardUnassignedServiceRequestsTDS;
        }



        private int GetServiceId()
        {
            int serviceId = 0;

            foreach (DashboardTDS.DashboardUnassignedServiceRequestsRow row in dashboardUnassignedServiceRequestsTDS.DashboardUnassignedServiceRequests)
            {
                if (row.Selected)
                {
                    serviceId = row.ServiceID;
                }
            }

            return serviceId;
        }



        private string GetNavigatorState()
        {
            // Columns to display
            int companyId = Int32.Parse(Session["companyID"].ToString());
            string fmType = "Services";
            string columnsToDisplay = "&columns_to_display=";

            FmTypeViewDisplay fmTypeViewDisplay = new FmTypeViewDisplay();
            columnsToDisplay = columnsToDisplay + fmTypeViewDisplay.GetColumnsByDefault(fmType, companyId, true);

            // SearchOptions for condition 1
            string searchOptions = "";
            searchOptions = searchOptions + "&search_ddlCondition1=1";
            searchOptions = searchOptions + "&search_tbxCondition1=%";

            // For Views
            searchOptions = searchOptions + "&search_ddlView=-2";

            // Other values
            searchOptions = searchOptions + "&search_state=1";
            searchOptions = searchOptions + "&search_sort_by=1";
            searchOptions = searchOptions + "&btn_origin=Search";

            // Return
            return columnsToDisplay + searchOptions;
        }
                              

        
        private void GetNodeForCompanyLevel(int parentId)
        {
            level++;
            System.Text.StringBuilder levelString = new System.Text.StringBuilder();
            for (int j = 0; j < level; j++)
            {
                levelString.Append("&nbsp;&nbsp;&nbsp;&nbsp;");
            }
            if (level > 0)
            {
                levelString.Append("-");
            }

            Int32 thisId;
            String thisName;

            DataRow[] children = companyLevelsForSRUnassignedTDS.Tables["LFS_FM_COMPANYLEVEL"].Select("ParentID='" + parentId + "'");

            // No child nodes, exit function
            if (children.Length > 0)
            {
                foreach (DataRow child in children)
                {
                    // Step 1
                    thisId = Convert.ToInt32(child.ItemArray[0]);

                    // Step 2
                    thisName = Convert.ToString(child.ItemArray[1]);

                    // Step 3
                    ListItem listItem = new ListItem(Server.HtmlDecode(levelString.ToString() + thisName), thisId.ToString());
                    ddlWorkingLocation.Items.Add(listItem);

                    // Step 4
                    GetNodeForCompanyLevel(thisId);
                }
            }

            level--;
        }

       

    }
}