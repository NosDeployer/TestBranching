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
    /// wucMyServiceRequest
    /// </summary>
    public partial class wucMyServiceRequest : System.Web.UI.UserControl
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected DashboardTDS dashboardMyServiceRequestsTDS;
        protected DashboardTDS.DashboardMyServiceRequestsDataTable dashboardMyServiceRequests;
        protected CompanyLevelsTDS companyLevelsForMySRTDS;
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in wucMyServiceRequest.ascx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();

                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardMyServiceRequestsDummy");
                ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["mySRWidget"];

                // If coming from 
                // ... Out
                if (Request.QueryString["source_page"] == "out")
                {
                    CompanyLevelsManagersGateway companyLevelsManagersGateway = new CompanyLevelsManagersGateway();

                    int loginId = Convert.ToInt32(Session["loginID"]);
                    EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                    int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);

                    // ... For Grid
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    int companyLevelId = companyLevelsManagersGateway.GetCompanyLevelId(employeeId, companyId);

                    // ... For ddl working location
                    companyLevelsForMySRTDS = new CompanyLevelsTDS();

                    CompanyLevel companyLevel = new CompanyLevel(companyLevelsForMySRTDS);
                    companyLevel.LoadNodes(companyId);

                    GetNodeForCompanyLevel(1);

                    ddlWorkingLocation.Items.Insert(0, new ListItem("(All)", "0"));

                    if (HttpContext.Current.Session["mySRWidget"] != null)
                    {
                        ddlWorkingLocation.SelectedIndex = Convert.ToInt32(arrayListWidgetData[0].ToString());
                        ddlType.SelectedIndex = Convert.ToInt32(arrayListWidgetData[1].ToString());

                        companyLevelId = Convert.ToInt32(ddlWorkingLocation.SelectedValue);
                    }
                    else
                    {
                        ddlWorkingLocation.SelectedValue = companyLevelId.ToString();
                    }

                    dashboardMyServiceRequestsTDS = new DashboardTDS();
                    DashboardMyServiceRequests model = new DashboardMyServiceRequests(dashboardMyServiceRequestsTDS);

                    if (companyLevelId == 0)
                    {
                        if (ddlType.SelectedValue != "(All)")
                        {
                            model.LoadMyServicesByAssignTeamMemberIDUnitType(employeeId, companyId, ddlType.SelectedValue);
                        }
                        else
                        {
                            // ... Load
                            model.LoadMyServicesByAssignTeamMemberID(employeeId, companyId);
                        }
                    }
                    else
                    {
                        if (ddlType.SelectedValue != "(All)")
                        {
                            model.LoadMyServicesByAssignTeamMemberIDCompanyLevelIdUnitType(employeeId, companyId, companyLevelId, ddlType.SelectedValue);
                        }
                        else
                        {
                            model.LoadMyServicesByAssignTeamMemberIDCompanyLevelId(employeeId, companyId, companyLevelId);
                        }
                    }

                    model.UpdateForDashboard(companyId);

                    // ... Store datasets
                    HttpContext.Current.Session.Add("dashboardMyServiceRequestsTDS", dashboardMyServiceRequestsTDS);
                    HttpContext.Current.Session.Add("companyLevelsForMySRTDS", companyLevelsForMySRTDS);
                }
            }
            else
            {
                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardMyServiceRequestsDummy");

                dashboardMyServiceRequestsTDS = (DashboardTDS)HttpContext.Current.Session["dashboardMyServiceRequestsTDS"];
                companyLevelsForMySRTDS = (CompanyLevelsTDS)HttpContext.Current.Session["companyLevelsForMySRTDS"];
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
        }

        



                
        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdMyServiceRequests_DataBound(object sender, EventArgs e)
        {
            MyServiceRequestsEmptyFix(grdMyServiceRequests);

            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["mySRWidget"] != null)
                {
                    ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["mySRWidget"];
                    int pageIndex = Convert.ToInt32(arrayListWidgetData[2].ToString());

                    if (grdMyServiceRequests.PageCount > pageIndex)
                    {
                        grdMyServiceRequests.PageIndex = pageIndex;
                    }
                    else
                    {
                        grdMyServiceRequests.PageIndex = grdMyServiceRequests.PageCount - 1;
                    }
                }
            }
        }




        protected void grdMyServiceRequests_PageIndexChanged(object sender, EventArgs e)
        {
            StoreWidgetsState();
        }



        protected void grdMyServiceRequests_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Normal items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                if (!Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]))
                {
                    ((CheckBox)e.Row.FindControl("cbxSelected")).Visible = false;
                }
            }
        }        



        protected void lkbtnServiceRequestManager_Click(object sender, EventArgs e)
        {
            hdfOriginBtn.Value = "Manager";

            Page.Validate("mysr");
            if (Page.IsValid)
            {
                PostPageChanges();

                foreach (GridViewRow row in grdMyServiceRequests.Rows)
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

            Page.Validate("mysr");
            if (Page.IsValid)
            {
                PostPageChanges();

                foreach (GridViewRow row in grdMyServiceRequests.Rows)
                {
                    if (((CheckBox)row.FindControl("cbxSelected")).Checked)
                    {
                        string serviceIdLabel = ((Label)row.FindControl("lblServiceID")).Text.Trim();
                        int serviceId = Int32.Parse(serviceIdLabel.ToString().Trim());

                        url = "./../../FleetManagement/Services/services_state.aspx?source_page=wucSRMy.ascx&service_id=" + serviceId + "&active_tab=0&state=Assigned" + GetNavigatorState();
                    }
                }
            }

            if (url != "") Response.Redirect(url);
        }        



        protected void cvGrdMyServiceRequests_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((hdfOriginBtn.Value == "Assign") || (hdfOriginBtn.Value == "Manager"))
            {
                CustomValidator cvSelectedServices = (CustomValidator)source;
                args.IsValid = false;

                if (grdMyServiceRequests.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdMyServiceRequests.Rows)
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
            arrayListWidgetData.Insert(2, grdMyServiceRequests.PageIndex);

            HttpContext.Current.Session.Add("mySRWidget", arrayListWidgetData);
        }



        private void StoreWidgetsStateByDdl()
        {
            ArrayList arrayListWidgetData = new ArrayList();
            arrayListWidgetData.Insert(0, ddlWorkingLocation.SelectedIndex);
            arrayListWidgetData.Insert(1, ddlType.SelectedIndex);
            arrayListWidgetData.Insert(2, 0);

            HttpContext.Current.Session.Add("mySRWidget", arrayListWidgetData);
        }



        private void LoadData()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int companyLevelId = Int32.Parse(ddlWorkingLocation.SelectedValue);

            dashboardMyServiceRequestsTDS = (DashboardTDS)HttpContext.Current.Session["dashboardMyServiceRequestsTDS"];
            DashboardMyServiceRequests model = new DashboardMyServiceRequests(dashboardMyServiceRequestsTDS);

            // ... Load
            int loginId = Convert.ToInt32(Session["loginID"]);
            EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
            int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);

            if (companyLevelId == 0)
            {
                if (ddlType.SelectedValue != "(All)")
                {
                    model.LoadMyServicesByAssignTeamMemberIDUnitType(employeeId, companyId, ddlType.SelectedValue);
                }
                else
                {
                    model.LoadMyServicesByAssignTeamMemberID(employeeId, companyId);
                }
            }
            else
            {
                if (ddlType.SelectedValue != "(All)")
                {
                    model.LoadMyServicesByAssignTeamMemberIDCompanyLevelIdUnitType(employeeId, companyId, companyLevelId, ddlType.SelectedValue);
                }
                else
                {
                    model.LoadMyServicesByAssignTeamMemberIDCompanyLevelId(employeeId, companyId, companyLevelId);
                }
            }

            model.UpdateForDashboard(companyId);

            HttpContext.Current.Session.Add("dashboardMyServiceRequestsTDS", dashboardMyServiceRequestsTDS);

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

            string url = "./../../Services/services_summary.aspx?source_page=wucSRMyServiceRequest.ascx&dashboard=True&service_id=" + serviceId + "&active_tab=0" + GetNavigatorState();
            return url;
        }



        public DashboardTDS.DashboardMyServiceRequestsDataTable GetDetails()
        {
            dashboardMyServiceRequests = (DashboardTDS.DashboardMyServiceRequestsDataTable)HttpContext.Current.Session["dashboardMyServiceRequestsDummy"];

            if (dashboardMyServiceRequests == null)
            {
                dashboardMyServiceRequests = ((DashboardTDS)HttpContext.Current.Session["dashboardMyServiceRequestsTDS"]).DashboardMyServiceRequests;
            }

            return dashboardMyServiceRequests;
        }



        protected void MyServiceRequestsEmptyFix(GridView grdView)
        {
            if (grdMyServiceRequests.Rows.Count == 0)
            {
                DashboardTDS.DashboardMyServiceRequestsDataTable dt = new DashboardTDS.DashboardMyServiceRequestsDataTable();
                dt.AddDashboardMyServiceRequestsRow(0, "", false, "", "");
                Session["dashboardMyServiceRequestsDummy"] = dt;

                grdMyServiceRequests.DataBind();
            }

            // Normally executes at all postbacks
            if (grdMyServiceRequests.Rows.Count == 1)
            {
                DashboardTDS.DashboardMyServiceRequestsDataTable dt = (DashboardTDS.DashboardMyServiceRequestsDataTable)Session["dashboardMyServiceRequestsDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdMyServiceRequests.Rows[0].Visible = false;
                    grdMyServiceRequests.Rows[0].Controls.Clear();
                }
            }
        }


                
        private void PostPageChanges()
        {
            DashboardMyServiceRequests dashboardMyServiceRequests = new DashboardMyServiceRequests(dashboardMyServiceRequestsTDS);

            // Update grdMyServiceRequests rows
            foreach (GridViewRow row in grdMyServiceRequests.Rows)
            {
                string serviceIdLabel = ((Label)row.FindControl("lblServiceID")).Text.Trim();
                int serviceId = Int32.Parse(serviceIdLabel.ToString().Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                int companyId = Int32.Parse(hdfCompanyId.Value);

                dashboardMyServiceRequests.Update(serviceId, companyId, selected);
            }

            dashboardMyServiceRequests.Data.AcceptChanges();

            // Store datasets
            Session["dashboardMyServiceRequestsTDS"] = dashboardMyServiceRequestsTDS;
        }



        private int GetServiceId()
        {
            int serviceId = 0;

            foreach (DashboardTDS.DashboardMyServiceRequestsRow row in dashboardMyServiceRequestsTDS.DashboardMyServiceRequests)
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

            DataRow[] children = companyLevelsForMySRTDS.Tables["LFS_FM_COMPANYLEVEL"].Select("ParentID='" + parentId + "'");

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