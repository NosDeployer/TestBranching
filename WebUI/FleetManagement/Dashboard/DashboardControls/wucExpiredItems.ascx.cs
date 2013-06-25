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
    /// wucExpiredItems
    /// </summar
    public partial class wucExpiredItems : System.Web.UI.UserControl
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected DashboardTDS dashboardExpiredServiceRequestsTDS;
        protected DashboardTDS.DashboardExpiredServiceRequestsDataTable dashboardExpiredServiceRequests;
        protected CompanyLevelsTDS companyLevelsForExpiredItemsTDS;
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in wucExpiredItems.ascx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();                

                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardExpiredServiceRequestsDummy");
                ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["expiredItemsWidget"];

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
                    companyLevelsForExpiredItemsTDS = new CompanyLevelsTDS();

                    CompanyLevel companyLevel = new CompanyLevel(companyLevelsForExpiredItemsTDS);
                    companyLevel.LoadNodes(companyId);

                    GetNodeForCompanyLevel(1);

                    ddlWorkingLocation.Items.Insert(0, new ListItem("(All)", "0"));

                    if (HttpContext.Current.Session["expiredItemsWidget"] != null)
                    {
                        ddlWorkingLocation.SelectedIndex = Convert.ToInt32(arrayListWidgetData[0].ToString());
                        ddlType.SelectedIndex = Convert.ToInt32(arrayListWidgetData[1].ToString());

                        companyLevelId = Convert.ToInt32(ddlWorkingLocation.SelectedValue);
                    }
                    else
                    {
                        ddlWorkingLocation.SelectedValue = companyLevelId.ToString();
                    }
                    
                    dashboardExpiredServiceRequestsTDS = new DashboardTDS();
                    DashboardExpiredServiceRequests model = new DashboardExpiredServiceRequests(dashboardExpiredServiceRequestsTDS);
                    
                    // ... Load for admin
                    if (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]))
                    {
                        if (companyLevelId == 0)
                        {
                            if (ddlType.SelectedValue != "(All)")
                            {
                                model.LoadAllExpiredItemsByUnitType(companyId, ddlType.SelectedValue);
                            }
                            else
                            {
                                model.LoadAllExpiredItems(companyId);
                            }
                        }
                        else
                        {
                            if (ddlType.SelectedValue != "(All)")
                            {
                                model.LoadAllExpiredItemsByCompanyLevelIdUnitType(companyId, companyLevelId, ddlType.SelectedValue);
                            }
                            else
                            {
                                model.LoadAllExpiredItemsByCompanyLevelId(companyId, companyLevelId);
                            }                            
                        }
                    }
                    else
                    {
                        if (companyLevelId == 0)
                        {
                            if (ddlType.SelectedValue != "(All)")
                            {
                                model.LoadAllExpiredItemsByAssignTeamMemberIDUnitType(employeeId, companyId, ddlType.SelectedValue);
                            }
                            else
                            {
                                // ... Load for assigned employee
                                model.LoadAllExpiredItemsByAssignTeamMemberID(employeeId, companyId);
                            }
                        }
                        else
                        {
                            if (ddlType.SelectedValue != "(All)")
                            {
                                model.LoadAllExpiredItemsByAssignTeamMemberIDCompanyLevelIdUnitType(employeeId, companyId, companyLevelId, ddlType.SelectedValue);
                            }
                            else
                            {
                                model.LoadAllExpiredItemsByAssignTeamMemberIDCompanyLevelId(employeeId, companyId, companyLevelId);
                            }
                        }
                    }

                    model.UpdateForDashboard(companyId);

                    // ... Store datasets
                    HttpContext.Current.Session.Add("dashboardExpiredServiceRequestsTDS", dashboardExpiredServiceRequestsTDS);
                    HttpContext.Current.Session.Add("companyLevelsForExpiredItemsTDS", companyLevelsForExpiredItemsTDS);
                }
            }
            else
            {
                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardExpiredServiceRequestsDummy");

                dashboardExpiredServiceRequestsTDS = (DashboardTDS)HttpContext.Current.Session["dashboardExpiredServiceRequestsTDS"];
                companyLevelsForExpiredItemsTDS = (CompanyLevelsTDS)HttpContext.Current.Session["companyLevelsForExpiredItemsTDS"];
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Initialize links for service request tools
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

        protected void grdExpiredServiceRequests_DataBound(object sender, EventArgs e)
        {
            ExpiredServiceRequestsEmptyFix(grdExpiredServiceRequests);

            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["expiredItemsWidget"] != null)
                {
                    ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["expiredItemsWidget"];
                    int pageIndex = Convert.ToInt32(arrayListWidgetData[2].ToString());

                    if (grdExpiredServiceRequests.PageCount > pageIndex)
                    {
                        grdExpiredServiceRequests.PageIndex = pageIndex;
                    }
                    else
                    {
                        grdExpiredServiceRequests.PageIndex = grdExpiredServiceRequests.PageCount - 1;
                    }
                }
            }
        }
        


        protected void grdExpiredServiceRequests_PageIndexChanged(object sender, EventArgs e)
        {
            StoreWidgetsState();
        }



        protected void grdExpiredServiceRequests_RowDataBound(object sender, GridViewRowEventArgs e)
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

            Page.Validate("expired");
            if (Page.IsValid)
            {
                PostPageChanges();

                foreach (GridViewRow row in grdExpiredServiceRequests.Rows)
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
                


        protected void cvGrdExpiredServiceRequests_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (hdfOriginBtn.Value == "Manager")
            {

                CustomValidator cvSelectedServices = (CustomValidator)source;
                args.IsValid = false;

                if (grdExpiredServiceRequests.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdExpiredServiceRequests.Rows)
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
            arrayListWidgetData.Insert(2, grdExpiredServiceRequests.PageIndex);

            HttpContext.Current.Session.Add("expiredItemsWidget", arrayListWidgetData);
        }



        private void StoreWidgetsStateByDdl()
        {
            ArrayList arrayListWidgetData = new ArrayList();
            arrayListWidgetData.Insert(0, ddlWorkingLocation.SelectedIndex);
            arrayListWidgetData.Insert(1, ddlType.SelectedIndex);
            arrayListWidgetData.Insert(2, 0);

            HttpContext.Current.Session.Add("expiredItemsWidget", arrayListWidgetData);
        }



        private void LoadData()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int companyLevelId = Int32.Parse(ddlWorkingLocation.SelectedValue);

            dashboardExpiredServiceRequestsTDS = (DashboardTDS)HttpContext.Current.Session["dashboardExpiredServiceRequestsTDS"];
            DashboardExpiredServiceRequests model = new DashboardExpiredServiceRequests(dashboardExpiredServiceRequestsTDS);

            // ... Load for admin
            if (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]))
            {
                if (companyLevelId == 0)
                {
                    if (ddlType.SelectedValue != "(All)")
                    {
                        model.LoadAllExpiredItemsByUnitType(companyId, ddlType.SelectedValue);
                    }
                    else
                    {
                        model.LoadAllExpiredItems(companyId);
                    }
                }
                else
                {
                    if (ddlType.SelectedValue != "(All)")
                    {
                        model.LoadAllExpiredItemsByCompanyLevelIdUnitType(companyId, companyLevelId, ddlType.SelectedValue);
                    }
                    else
                    {
                        model.LoadAllExpiredItemsByCompanyLevelId(companyId, companyLevelId);
                    }
                }
            }
            else
            {
                // ... Load for assigned employee
                int loginId = Convert.ToInt32(Session["loginID"]);
                EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);

                if (companyLevelId == 0)
                {
                    if (ddlType.SelectedValue != "(All)")
                    {
                        model.LoadAllExpiredItemsByAssignTeamMemberIDUnitType(employeeId, companyId, ddlType.SelectedValue);
                    }
                    else
                    {
                        model.LoadAllExpiredItemsByAssignTeamMemberID(employeeId, companyId);
                    }
                }
                else
                {
                    if (ddlType.SelectedValue != "(All)")
                    {
                        model.LoadAllExpiredItemsByAssignTeamMemberIDCompanyLevelIdUnitType(employeeId, companyId, companyLevelId, ddlType.SelectedValue);
                    }
                    else
                    {
                        model.LoadAllExpiredItemsByAssignTeamMemberIDCompanyLevelId(employeeId, companyId, companyLevelId);
                    }
                }
            }

            model.UpdateForDashboard(companyId);

            HttpContext.Current.Session.Add("dashboardExpiredServiceRequestsTDS", dashboardExpiredServiceRequestsTDS);
            Page.DataBind();
        }



        private void RegisterClientScripts()
        {
            // Register client-side code
            Page.ClientScript.RegisterClientScriptInclude("clientSideCode", "./dashboard.js");
        }



        public string GetUrl(object str)
        {
            int serviceId = Int32.Parse(str.ToString());

            string url = "./../../Services/services_summary.aspx?source_page=wucExpiredItems.ascx&dashboard=True&service_id=" + serviceId + "&active_tab=0" + GetNavigatorState();
            return url;
        }



        public DashboardTDS.DashboardExpiredServiceRequestsDataTable GetDetails()
        {
            dashboardExpiredServiceRequests = (DashboardTDS.DashboardExpiredServiceRequestsDataTable)HttpContext.Current.Session["dashboardExpiredServiceRequestsDummy"];

            if (dashboardExpiredServiceRequests == null)
            {
                dashboardExpiredServiceRequests = ((DashboardTDS)HttpContext.Current.Session["dashboardExpiredServiceRequestsTDS"]).DashboardExpiredServiceRequests;
            }

            return dashboardExpiredServiceRequests;
        }



        protected void ExpiredServiceRequestsEmptyFix(GridView grdView)
        {
            if (grdExpiredServiceRequests.Rows.Count == 0)
            {
                DashboardTDS.DashboardExpiredServiceRequestsDataTable dt = new DashboardTDS.DashboardExpiredServiceRequestsDataTable();
                dt.AddDashboardExpiredServiceRequestsRow(0, "", false, "");
                Session["dashboardExpiredServiceRequestsDummy"] = dt;

                grdExpiredServiceRequests.DataBind();
            }

            // Normally executes at all postbacks
            if (grdExpiredServiceRequests.Rows.Count == 1)
            {
                DashboardTDS.DashboardExpiredServiceRequestsDataTable dt = (DashboardTDS.DashboardExpiredServiceRequestsDataTable)Session["dashboardExpiredServiceRequestsDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdExpiredServiceRequests.Rows[0].Visible = false;
                    grdExpiredServiceRequests.Rows[0].Controls.Clear();
                }
            }
        }


                
        private void PostPageChanges()
        {
            DashboardExpiredServiceRequests dashboardExpiredServiceRequests = new DashboardExpiredServiceRequests(dashboardExpiredServiceRequestsTDS);

            // Update grdExpiredServiceRequests rows
            foreach (GridViewRow row in grdExpiredServiceRequests.Rows)
            {
                string serviceIdLabel = ((Label)row.FindControl("lblServiceID")).Text.Trim();
                int serviceId = Int32.Parse(serviceIdLabel.ToString().Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                int companyId = Int32.Parse(hdfCompanyId.Value);

                dashboardExpiredServiceRequests.Update(serviceId, companyId, selected);
            }

            dashboardExpiredServiceRequests.Data.AcceptChanges();

            // Store datasets
            Session["dashboardExpiredServiceRequestsTDS"] = dashboardExpiredServiceRequestsTDS;
        }



        private int GetServiceId()
        {
            int serviceId = 0;

            foreach (DashboardTDS.DashboardExpiredServiceRequestsRow row in dashboardExpiredServiceRequestsTDS.DashboardExpiredServiceRequests)
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

            DataRow[] children = companyLevelsForExpiredItemsTDS.Tables["LFS_FM_COMPANYLEVEL"].Select("ParentID='" + parentId + "'");

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