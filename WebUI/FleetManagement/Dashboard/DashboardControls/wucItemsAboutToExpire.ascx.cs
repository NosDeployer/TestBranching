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
    /// wucItemsAboutToExpire
    /// </summar
    public partial class wucItemsAboutToExpire : System.Web.UI.UserControl
    {        
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected DashboardTDS dashboardItemsAboutToExpireTDS;
        protected DashboardTDS.DashboardItemsAboutToExpireDataTable dashboardItemsAboutToExpire;
        protected CompanyLevelsTDS companyLevelsItemsAboutToExpiredTDS;
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in wucItemsAboutToExpire.ascx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();

                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardItemsAboutToExpireDummy");
                ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["itemsAboutToExpireWidget"];

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
                    string period = "0 days";

                    // ... For ddl working location
                    companyLevelsItemsAboutToExpiredTDS = new CompanyLevelsTDS();
                   
                    CompanyLevel companyLevel = new CompanyLevel(companyLevelsItemsAboutToExpiredTDS);
                    companyLevel.LoadNodes(companyId);
                    
                    GetNodeForCompanyLevel(1);
                    
                    ddlWorkingLocation.Items.Insert(0, new ListItem("(All)", "0"));

                    if (HttpContext.Current.Session["itemsAboutToExpireWidget"] != null)
                    {
                        ddlWorkingLocation.SelectedIndex = Convert.ToInt32(arrayListWidgetData[0].ToString());
                        ddlType.SelectedIndex = Convert.ToInt32(arrayListWidgetData[1].ToString());
                        ddlPeriod.SelectedIndex = Convert.ToInt32(arrayListWidgetData[3].ToString());

                        companyLevelId = Convert.ToInt32(ddlWorkingLocation.SelectedValue);
                        period = ddlPeriod.SelectedValue;
                    }
                    else
                    {
                        ddlWorkingLocation.SelectedValue = companyLevelId.ToString();
                        ddlPeriod.SelectedValue = period;
                    }

                    dashboardItemsAboutToExpireTDS = new DashboardTDS();
                    DashboardItemsAboutToExpire model = new DashboardItemsAboutToExpire(dashboardItemsAboutToExpireTDS);

                    // ... Load for admin
                    if (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]))
                    {
                        if (companyLevelId == 0)
                        {
                            if (ddlType.SelectedValue != "(All)")
                            {
                                model.LoadAllItemsAboutToExpireByUnitType(period, companyId, ddlType.SelectedValue);
                            }
                            else
                            {
                                model.LoadAllItemsAboutToExpire(period, companyId);
                            }
                        }
                        else
                        {
                            if (ddlType.SelectedValue != "(All)")
                            {
                                model.LoadAllItemsAboutToExpireByCompanyLevelIdUnitType(period, companyId, companyLevelId, ddlType.SelectedValue);
                            }
                            else
                            {
                                model.LoadAllItemsAboutToExpireByCompanyLevelId(period, companyId, companyLevelId);
                            }
                        }
                    }
                    else
                    {
                        if (companyLevelId == 0)
                        {
                            if (ddlType.SelectedValue != "(All)")
                            {
                                model.LoadAllItemsAboutToExpireByAssignTeamMemberIDUnitType(period, employeeId, companyId, ddlType.SelectedValue);
                            }
                            else
                            {
                                // ... Load for assigned employee
                                model.LoadAllItemsAboutToExpireByAssignTeamMemberID(period, employeeId, companyId);
                            }
                        }
                        else
                        {
                            if (ddlType.SelectedValue != "(All)")
                            {
                                model.LoadAllItemsAboutToExpireByAssignTeamMemberIDCompanyLevelIdUnitType(period, employeeId, companyId, companyLevelId, ddlType.SelectedValue);
                            }
                            else
                            {
                                model.LoadAllItemsAboutToExpireByAssignTeamMemberIDCompanyLevelId(period, employeeId, companyId, companyLevelId);
                            }
                        }
                    }

                    model.UpdateForDashboard(companyId);

                    // ... Store datasets
                    HttpContext.Current.Session.Add("dashboardItemsAboutToExpireTDS", dashboardItemsAboutToExpireTDS);
                    HttpContext.Current.Session.Add("companyLevelsItemsAboutToExpiredTDS", companyLevelsItemsAboutToExpiredTDS);
                }
            }
            else
            {
                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardItemsAboutToExpireDummy");  

                // Restore dataset
                dashboardItemsAboutToExpireTDS = (DashboardTDS)HttpContext.Current.Session["dashboardItemsAboutToExpireTDS"];
                companyLevelsItemsAboutToExpiredTDS = (CompanyLevelsTDS)HttpContext.Current.Session["companyLevelsItemsAboutToExpiredTDS"];
            }
        }       


       
        
         
       
        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdItemsAboutToExpire_DataBound(object sender, EventArgs e)
        {
            ItemsAboutToExpireEmptyFix(grdItemsAboutToExpire);

            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["itemsAboutToExpireWidget"] != null)
                {
                    ArrayList arrayListWidgetData = (ArrayList)HttpContext.Current.Session["itemsAboutToExpireWidget"];
                    int pageIndex = Convert.ToInt32(arrayListWidgetData[2].ToString());

                    if (grdItemsAboutToExpire.PageCount > pageIndex)
                    {
                        grdItemsAboutToExpire.PageIndex = pageIndex;
                    }
                    else
                    {
                        grdItemsAboutToExpire.PageIndex = grdItemsAboutToExpire.PageCount - 1;
                    }
                }
            }
        }



        protected void grdItemsAboutToExpire_PageIndexChanged(object sender, EventArgs e)
        {
            StoreWidgetsState();
        }
              

        
        protected void ddlPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            StoreWidgetsStateByDdl();
            LoadData();
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



        protected void cvGrdItemsAboutToExpire_ServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator cvSelectedServices = (CustomValidator)source;
            args.IsValid = false;

            if (grdItemsAboutToExpire.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdItemsAboutToExpire.Rows)
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






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void StoreWidgetsState()
        {
            ArrayList arrayListWidgetData = new ArrayList();
            arrayListWidgetData.Insert(0, ddlWorkingLocation.SelectedIndex);
            arrayListWidgetData.Insert(1, ddlType.SelectedIndex);
            arrayListWidgetData.Insert(2, grdItemsAboutToExpire.PageIndex);
            arrayListWidgetData.Insert(3, ddlPeriod.SelectedIndex);

            HttpContext.Current.Session.Add("itemsAboutToExpireWidget", arrayListWidgetData);
        }



        private void StoreWidgetsStateByDdl()
        {
            ArrayList arrayListWidgetData = new ArrayList();
            arrayListWidgetData.Insert(0, ddlWorkingLocation.SelectedIndex);
            arrayListWidgetData.Insert(1, ddlType.SelectedIndex);
            arrayListWidgetData.Insert(2, 0);
            arrayListWidgetData.Insert(3, ddlPeriod.SelectedIndex);

            HttpContext.Current.Session.Add("itemsAboutToExpireWidget", arrayListWidgetData);
        }



        private void LoadData()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int loginId = Convert.ToInt32(Session["loginID"]);
            EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
            int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);
            string period = ddlPeriod.SelectedItem.Value.ToString();
            int companyLevelId = Int32.Parse(ddlWorkingLocation.SelectedValue);

            dashboardItemsAboutToExpireTDS = (DashboardTDS)HttpContext.Current.Session["dashboardItemsAboutToExpireTDS"];
            DashboardItemsAboutToExpire model = new DashboardItemsAboutToExpire(dashboardItemsAboutToExpireTDS);

            if (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]))
            {
                if (companyLevelId == 0)
                {
                    if (ddlType.SelectedValue != "(All)")
                    {
                        model.LoadAllItemsAboutToExpireByUnitType(period, companyId, ddlType.SelectedValue);
                    }
                    else
                    {
                        model.LoadAllItemsAboutToExpire(period, companyId);
                    }
                }
                else
                {
                    if (ddlType.SelectedValue != "(All)")
                    {
                        model.LoadAllItemsAboutToExpireByCompanyLevelIdUnitType(period, companyId, companyLevelId, ddlType.SelectedValue);
                    }
                    else
                    {
                        model.LoadAllItemsAboutToExpireByCompanyLevelId(period, companyId, companyLevelId);
                    }
                }
            }
            else
            {
                if (companyLevelId == 0)
                {
                    if (ddlType.SelectedValue != "(All)")
                    {
                        model.LoadAllItemsAboutToExpireByAssignTeamMemberIDUnitType(period, employeeId, companyId, ddlType.SelectedValue);
                    }
                    else
                    {
                        // ... Load for assigned employee
                        model.LoadAllItemsAboutToExpireByAssignTeamMemberID(period, employeeId, companyId);
                    }
                }
                else
                {
                    if (ddlType.SelectedValue != "(All)")
                    {
                        model.LoadAllItemsAboutToExpireByAssignTeamMemberIDCompanyLevelIdUnitType(period, employeeId, companyId, companyLevelId, ddlType.SelectedValue);
                    }
                    else
                    {
                        model.LoadAllItemsAboutToExpireByAssignTeamMemberIDCompanyLevelId(period, employeeId, companyId, companyLevelId);
                    }
                }
            }

            model.UpdateForDashboard(companyId);

            HttpContext.Current.Session.Add("dashboardItemsAboutToExpireTDS", dashboardItemsAboutToExpireTDS);

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

            string url = "./../../Services/services_summary.aspx?source_page=wucItemsAboutToExpire.ascx&dashboard=True&service_id=" + serviceId + "&active_tab=0" + GetNavigatorState();
            return url;
        }



        public DashboardTDS.DashboardItemsAboutToExpireDataTable GetDetails()
        {
            dashboardItemsAboutToExpire = (DashboardTDS.DashboardItemsAboutToExpireDataTable)HttpContext.Current.Session["dashboardItemsAboutToExpireDummy"];

            if (dashboardItemsAboutToExpire == null)
            {
                dashboardItemsAboutToExpire = ((DashboardTDS)HttpContext.Current.Session["dashboardItemsAboutToExpireTDS"]).DashboardItemsAboutToExpire;
            }

            return dashboardItemsAboutToExpire;
        }



        protected void ItemsAboutToExpireEmptyFix(GridView grdView)
        {
            if (grdItemsAboutToExpire.Rows.Count == 0)
            {
                DashboardTDS.DashboardItemsAboutToExpireDataTable dt = new DashboardTDS.DashboardItemsAboutToExpireDataTable();
                dt.AddDashboardItemsAboutToExpireRow(0, "", false, "");
                Session["dashboardItemsAboutToExpireDummy"] = dt;

                grdItemsAboutToExpire.DataBind();
            }

            // Normally executes at all postbacks
            if (grdItemsAboutToExpire.Rows.Count == 1)
            {
                DashboardTDS.DashboardItemsAboutToExpireDataTable dt = (DashboardTDS.DashboardItemsAboutToExpireDataTable)Session["dashboardItemsAboutToExpireDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdItemsAboutToExpire.Rows[0].Visible = false;
                    grdItemsAboutToExpire.Rows[0].Controls.Clear();
                }
            }
        }


                
        private void PostPageChanges()
        {
            DashboardItemsAboutToExpire dashboardItemsAboutToExpire = new DashboardItemsAboutToExpire(dashboardItemsAboutToExpireTDS);

            // Update grd Items About To Expire rows
            foreach (GridViewRow row in grdItemsAboutToExpire.Rows)
            {
                string serviceIdLabel = ((Label)row.FindControl("lblServiceID")).Text.Trim();
                int serviceId = Int32.Parse(serviceIdLabel.ToString().Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                int companyId = Int32.Parse(hdfCompanyId.Value);

                dashboardItemsAboutToExpire.Update(serviceId, companyId, selected);
            }

            dashboardItemsAboutToExpire.Data.AcceptChanges();

            // Store datasets
            Session["dashboardItemsAboutToExpireTDS"] = dashboardItemsAboutToExpireTDS;
        }



        private int GetServiceId()
        {
            int serviceId = 0;

            foreach (DashboardTDS.DashboardItemsAboutToExpireRow row in dashboardItemsAboutToExpireTDS.DashboardItemsAboutToExpire)
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

            DataRow[] children = companyLevelsItemsAboutToExpiredTDS.Tables["LFS_FM_COMPANYLEVEL"].Select("ParentID='" + parentId + "'");

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