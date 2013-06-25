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
    /// wucSRInProgress
    /// </summary>
    public partial class wucSRInProgress : System.Web.UI.UserControl
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected DashboardTDS dashboardInProgressServiceRequestsTDS;
        protected DashboardTDS.DashboardInProgressServiceRequestsDataTable dashboardInProgressServiceRequests;
        protected CompanyLevelsTDS companyLevelsForSRInProgressTDS;
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in wucSRInProgress.ascx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();

                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardInProgressServiceRequestsDummy");
                ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["srInProgressWidget"];

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
                    companyLevelsForSRInProgressTDS = new CompanyLevelsTDS();

                    CompanyLevel companyLevel = new CompanyLevel(companyLevelsForSRInProgressTDS);
                    companyLevel.LoadNodes(companyId);
                    
                    GetNodeForCompanyLevel(1);
                    
                    ddlWorkingLocation.Items.Insert(0, new ListItem("(All)", "0"));

                    if (HttpContext.Current.Session["srInProgressWidget"] != null)
                    {
                        ddlWorkingLocation.SelectedIndex = Convert.ToInt32(arrayListWidgetData[0].ToString());
                        ddlType.SelectedIndex = Convert.ToInt32(arrayListWidgetData[1].ToString());

                        companyLevelId = Convert.ToInt32(ddlWorkingLocation.SelectedValue);
                    }
                    else
                    {
                        ddlWorkingLocation.SelectedValue = companyLevelId.ToString();
                    }

                    dashboardInProgressServiceRequestsTDS = new DashboardTDS();
                    DashboardInProgressServiceRequests model = new DashboardInProgressServiceRequests(dashboardInProgressServiceRequestsTDS);

                    if (companyLevelId == 0)
                    {
                        if (ddlType.SelectedValue != "(All)")
                        {
                            model.LoadInProgressServicesByUnitType(companyId, ddlType.SelectedValue);
                        }
                        else
                        {
                            // ... Load
                            model.LoadInProgressServices(companyId);
                        }
                    }
                    else
                    {
                        if (ddlType.SelectedValue != "(All)")
                        {
                            model.LoadInProgressServicesByCompanyLevelIdUnitType(companyId, companyLevelId, ddlType.SelectedValue);
                        }
                        else
                        {
                            model.LoadInProgressServicesByCompanyLevelId(companyId, companyLevelId);
                        }
                    }

                    model.UpdateForDashboard(companyId);

                    // ... Store datasets
                    HttpContext.Current.Session.Add("dashboardInProgressServiceRequestsTDS", dashboardInProgressServiceRequestsTDS);
                    HttpContext.Current.Session.Add("companyLevelsForSRInProgressTDS", companyLevelsForSRInProgressTDS);
                }
            }
            else
            {
                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardInProgressServiceRequestsDummy");

                dashboardInProgressServiceRequestsTDS = (DashboardTDS)HttpContext.Current.Session["dashboardInProgressServiceRequestsTDS"];
                companyLevelsForSRInProgressTDS = (CompanyLevelsTDS)HttpContext.Current.Session["companyLevelsForSRInProgressTDS"];                
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

        protected void grdServiceRequestsInProgress_DataBound(object sender, EventArgs e)
        {
            InProgressServiceRequestsEmptyFix(grdServiceRequestsInProgress);

            if (!IsPostBack) 
            {
                if (HttpContext.Current.Session["srInProgressWidget"] != null)
                {
                    ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["srInProgressWidget"];
                    int pageIndex = Convert.ToInt32(arrayListWidgetData[2].ToString());

                    if (grdServiceRequestsInProgress.PageCount > pageIndex)
                    {
                        grdServiceRequestsInProgress.PageIndex = pageIndex;
                    }
                    else
                    {
                        grdServiceRequestsInProgress.PageIndex = grdServiceRequestsInProgress.PageCount - 1;
                    }
                }
            }
        }



        protected void grdServiceRequestsInProgress_RowDataBound(object sender, GridViewRowEventArgs e)
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



        protected void grdServiceRequestsInProgress_PageIndexChanged(object sender, EventArgs e)
        {
            StoreWidgetsState();
        }



        protected void lkbtnServiceRequestManager_Click(object sender, EventArgs e)
        {
            hdfOriginBtn.Value = "Manager";

            Page.Validate("inProgress");
            if (Page.IsValid)
            {
                PostPageChanges();

                foreach (GridViewRow row in grdServiceRequestsInProgress.Rows)
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



        protected void cvGrdServiceRequestsInProgress_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((hdfOriginBtn.Value == "Assign") || (hdfOriginBtn.Value == "Manager"))
            {
                CustomValidator cvSelectedServices = (CustomValidator)source;
                args.IsValid = false;

                if (grdServiceRequestsInProgress.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdServiceRequestsInProgress.Rows)
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
            arrayListWidgetData.Insert(2, grdServiceRequestsInProgress.PageIndex);

            HttpContext.Current.Session.Add("srInProgressWidget", arrayListWidgetData);
        }



        private void StoreWidgetsStateByDdl()
        {
            ArrayList arrayListWidgetData = new ArrayList();
            arrayListWidgetData.Insert(0, ddlWorkingLocation.SelectedIndex);
            arrayListWidgetData.Insert(1, ddlType.SelectedIndex);
            arrayListWidgetData.Insert(2, 0);

            HttpContext.Current.Session.Add("srInProgressWidget", arrayListWidgetData);
        }



        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";

            Page.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            Page.ClientScript.RegisterClientScriptInclude("clientSideCode", "./dashboard.js");
        }



        private void LoadData()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int companyLevelId = Int32.Parse(ddlWorkingLocation.SelectedValue);

            dashboardInProgressServiceRequestsTDS = (DashboardTDS)HttpContext.Current.Session["dashboardInProgressServiceRequestsTDS"];
            DashboardInProgressServiceRequests model = new DashboardInProgressServiceRequests(dashboardInProgressServiceRequestsTDS);

            if (companyLevelId == 0)
            {
                if (ddlType.SelectedValue != "(All)")
                {
                    model.LoadInProgressServicesByUnitType(companyId, ddlType.SelectedValue);
                }
                else
                {
                    // ... Load
                    model.LoadInProgressServices(companyId);
                }
            }
            else
            {
                if (ddlType.SelectedValue != "(All)")
                {
                    model.LoadInProgressServicesByCompanyLevelIdUnitType(companyId, companyLevelId, ddlType.SelectedValue);
                }
                else
                {
                    model.LoadInProgressServicesByCompanyLevelId(companyId, companyLevelId);
                }
            }

            model.UpdateForDashboard(companyId);

            HttpContext.Current.Session.Add("dashboardInProgressServiceRequestsTDS", dashboardInProgressServiceRequestsTDS);

            Page.DataBind();
        }



        public string GetUrl(object str)
        {
            int serviceId = Int32.Parse(str.ToString());

            string url = "./../../Services/services_summary.aspx?source_page=wucSRInProgress.ascx&dashboard=True&service_id=" + serviceId + "&active_tab=0" + GetNavigatorState();
            return url;
        }



        public DashboardTDS.DashboardInProgressServiceRequestsDataTable GetDetails()
        {
            dashboardInProgressServiceRequests = (DashboardTDS.DashboardInProgressServiceRequestsDataTable)HttpContext.Current.Session["dashboardInProgressServiceRequestsDummy"];

            if (dashboardInProgressServiceRequests == null)
            {
                dashboardInProgressServiceRequests = ((DashboardTDS)HttpContext.Current.Session["dashboardInProgressServiceRequestsTDS"]).DashboardInProgressServiceRequests;
            }

            return dashboardInProgressServiceRequests;
        }



        protected void InProgressServiceRequestsEmptyFix(GridView grdView)
        {
            if (grdServiceRequestsInProgress.Rows.Count == 0)
            {
                DashboardTDS.DashboardInProgressServiceRequestsDataTable dt = new DashboardTDS.DashboardInProgressServiceRequestsDataTable();
                dt.AddDashboardInProgressServiceRequestsRow(0, "", false, "", "");
                Session["dashboardInProgressServiceRequestsDummy"] = dt;

                grdServiceRequestsInProgress.DataBind();
            }

            // Normally executes at all postbacks
            if (grdServiceRequestsInProgress.Rows.Count == 1)
            {
                DashboardTDS.DashboardInProgressServiceRequestsDataTable dt = (DashboardTDS.DashboardInProgressServiceRequestsDataTable)Session["dashboardInProgressServiceRequestsDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdServiceRequestsInProgress.Rows[0].Visible = false;
                    grdServiceRequestsInProgress.Rows[0].Controls.Clear();
                }
            }
        }



        private void PostPageChanges()
        {
            DashboardInProgressServiceRequests dashboardInProgressServiceRequests = new DashboardInProgressServiceRequests(dashboardInProgressServiceRequestsTDS);

            // Update jlinernavigator rows
            foreach (GridViewRow row in grdServiceRequestsInProgress.Rows)
            {
                string serviceIdLabel = ((Label)row.FindControl("lblServiceID")).Text.Trim();
                int serviceId = Int32.Parse(serviceIdLabel.ToString().Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                int companyId = Int32.Parse(hdfCompanyId.Value);

                dashboardInProgressServiceRequests.Update(serviceId, companyId, selected);
            }

            dashboardInProgressServiceRequests.Data.AcceptChanges();

            // Store datasets
            Session["dashboardInProgressServiceRequestsTDS"] = dashboardInProgressServiceRequestsTDS;
        }



        private int GetServiceId()
        {
            int serviceId = 0;

            foreach (DashboardTDS.DashboardInProgressServiceRequestsRow row in dashboardInProgressServiceRequestsTDS.DashboardInProgressServiceRequests)
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

            DataRow[] children = companyLevelsForSRInProgressTDS.Tables["LFS_FM_COMPANYLEVEL"].Select("ParentID='" + parentId + "'");

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