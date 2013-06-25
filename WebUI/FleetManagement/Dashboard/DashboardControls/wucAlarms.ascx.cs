using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.FleetManagement.Common;
using LiquiForce.LFSLive.BL.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.BL.FleetManagement.Dashboard;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.DA.FleetManagement.Dashboard;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Dashboard.DashboardControls
{
    /// <summary>
    /// wucAlarms
    /// </summar
    public partial class wucAlarms : System.Web.UI.UserControl
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected DashboardTDS dashboardChecklistAlarmsTDS;
        protected DashboardTDS.DashboardChecklistAlarmsDataTable dashboardChecklistAlarms;
        protected CompanyLevelsTDS companyLevelsForAlarmsTDS;
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in wucAlarms.ascx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();

                int loginId = Convert.ToInt32(Session["loginID"]);
                EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                hdfEmployeeId.Value = employeeGateway.GetEmployeIdByLoginId(loginId).ToString();

                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardChecklistAlarmsDummy");

                // If coming from 
                // ... Out
                if (Request.QueryString["source_page"] == "out")
                {
                    CompanyLevelsManagersGateway companyLevelsManagersGateway = new CompanyLevelsManagersGateway();

                    // ... For Grid
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    int companyLevelId = companyLevelsManagersGateway.GetCompanyLevelId(Int32.Parse(hdfEmployeeId.Value), companyId);

                    // ... For ddl working location
                    companyLevelsForAlarmsTDS = new CompanyLevelsTDS();
                    CompanyLevel companyLevel = new CompanyLevel(companyLevelsForAlarmsTDS);
                    companyLevel.LoadNodes(companyId);
                    GetNodeForCompanyLevel(1);
                    ddlWorkingLocation.Items.Insert(0, new ListItem("(All)", "0"));
                    ddlWorkingLocation.SelectedValue = companyLevelId.ToString();
                    
                    dashboardChecklistAlarmsTDS = new DashboardTDS();
                    DashboardChecklistAlarms model = new DashboardChecklistAlarms(dashboardChecklistAlarmsTDS);
                   
                    if (companyLevelId == 0)
                    {
                        if (ddlType.SelectedValue != "(All)")
                        {
                            model.LoadAllByAlarmPeriodUnitType(companyId, ddlType.SelectedValue);
                        }
                        else
                        {
                            model.LoadAllByAlarmPeriod(companyId);
                        }
                    }
                    else
                    {
                        if (ddlType.SelectedValue != "(All)")
                        {
                            model.LoadAllByAlarmPeriodCompanyLevelIdUnitType(companyId, companyLevelId, ddlType.SelectedValue);
                        }
                        else
                        {
                            model.LoadAllByAlarmPeriodCompanyLevelId(companyId, companyLevelId);
                        }
                    }

                    // ... Store datasets
                    HttpContext.Current.Session.Add("dashboardChecklistAlarmsTDS", dashboardChecklistAlarmsTDS);
                    HttpContext.Current.Session.Add("companyLevelsForAlarmsTDS", companyLevelsForAlarmsTDS);
                }
            }
            else
            {
                // Prepare initial data
                HttpContext.Current.Session.Remove("dashboardChecklistAlarmsDummy");

                // Restore datasets
                dashboardChecklistAlarmsTDS = (DashboardTDS)HttpContext.Current.Session["dashboardChecklistAlarmsTDS"];
                companyLevelsForAlarmsTDS = (CompanyLevelsTDS)HttpContext.Current.Session["companyLevelsForAlarmsTDS"];
            }
        }        



        
      
        
        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdChecklistAlarms_DataBound(object sender, EventArgs e)
        {
            ChecklistAlarmsEmptyFix(grdChecklistAlarms);
        }



        protected void grdChecklistAlarms_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AlarmsProcessGrid();
        }       



        protected void lkbtnCreateServiceRequest_Click(object sender, EventArgs e)
        {
            string url = "";

            Page.Validate("alarms");
            if (Page.IsValid)
            {
                AlarmsProcessGrid();

                foreach (GridViewRow row in grdChecklistAlarms.Rows)
                {
                    if (((CheckBox)row.FindControl("cbxSelected")).Checked)
                    {
                        int unitId = Int32.Parse(grdChecklistAlarms.DataKeys[row.RowIndex].Values["UnitID"].ToString());
                        int ruleId = Int32.Parse(grdChecklistAlarms.DataKeys[row.RowIndex].Values["RuleID"].ToString());
                        
                        string script = "<script language='javascript'>";
                        url = "./../Services/services_add_request.aspx?source_page=wucAlarms.ascx.cs&dashboard=True&unit_id=" + unitId.ToString() + "&rule_id=" + ruleId.ToString() ;
                        script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650')", url);
                        script = script + "</script>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Services", script, false);
                    }
                }
            }
        }


                
        protected void grdChecklistAlarms_ServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator cvSelectedServices = (CustomValidator)source;
            args.IsValid = false;

            if (grdChecklistAlarms.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdChecklistAlarms.Rows)
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



        protected void ddlWorkingLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int companyLevelId = Int32.Parse(ddlWorkingLocation.SelectedValue);
            string unitType = ddlType.SelectedValue;

            dashboardChecklistAlarmsTDS = (DashboardTDS)HttpContext.Current.Session["dashboardChecklistAlarmsTDS"];
            DashboardChecklistAlarms model = new DashboardChecklistAlarms(dashboardChecklistAlarmsTDS);

            if (companyLevelId == 0)
            {
                if (unitType != "(All)")
                {
                    model.LoadAllByAlarmPeriodUnitType(companyId, unitType);
                }
                else
                {
                    model.LoadAllByAlarmPeriod(companyId);
                }
            }
            else
            {
                if (unitType != "(All)")
                {
                    model.LoadAllByAlarmPeriodCompanyLevelIdUnitType(companyId, companyLevelId, unitType);
                }
                else
                {
                    model.LoadAllByAlarmPeriodCompanyLevelId(companyId, companyLevelId);
                }
            }

            HttpContext.Current.Session.Add("dashboardChecklistAlarmsTDS", dashboardChecklistAlarmsTDS);

            Page.DataBind();
        }



        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int companyLevelId = Int32.Parse(ddlWorkingLocation.SelectedValue);
            
            dashboardChecklistAlarmsTDS = (DashboardTDS)HttpContext.Current.Session["dashboardChecklistAlarmsTDS"];
            DashboardChecklistAlarms model = new DashboardChecklistAlarms(dashboardChecklistAlarmsTDS);

            if (companyLevelId == 0)
            {
                if (ddlType.SelectedValue != "(All)")
                {
                    model.LoadAllByAlarmPeriodUnitType(companyId, ddlType.SelectedValue);
                }
                else
                {
                    model.LoadAllByAlarmPeriod(companyId);
                }
            }
            else
            {
                if (ddlType.SelectedValue != "(All)")
                {
                    model.LoadAllByAlarmPeriodCompanyLevelIdUnitType(companyId, companyLevelId, ddlType.SelectedValue);
                }
                else
                {
                    model.LoadAllByAlarmPeriodCompanyLevelId(companyId, companyLevelId);
                }
            }

            HttpContext.Current.Session.Add("dashboardChecklistAlarmsTDS", dashboardChecklistAlarmsTDS);

            Page.DataBind();
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Register client-side code
            Page.ClientScript.RegisterClientScriptInclude("clientSideCode", "./dashboard.js");
        }



        public string GetUrl(object str)
        {
            int unitId = Int32.Parse(str.ToString());
            int companyId = Int32.Parse(hdfCompanyId.Value);
            string url = "";

            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.LoadByUnitId(unitId, companyId);
            if (unitsGateway.Table.Rows.Count > 0)
            {
                string unitType = unitsGateway.GetType(unitId);
                string unitState = unitsGateway.GetState(unitId);

                url = "./../../Units/units_summary.aspx?source_page=wucAlarms.ascx&dashboard=True&dashboard=True&unit_id=" + unitId + "&unit_type=" + unitType + "&unit_state=" + unitState + "&active_tab=0" + GetNavigatorState();
            }
            return url;
        }



        private void AlarmsProcessGrid()
        {
            dashboardChecklistAlarmsTDS = (DashboardTDS)HttpContext.Current.Session["dashboardChecklistAlarmsTDS"];
            DashboardChecklistAlarms model = new DashboardChecklistAlarms(dashboardChecklistAlarmsTDS);

            // update rows
            if (Session["dashboardChecklistAlarmsDummy"] == null)
            {
                foreach (GridViewRow row in grdChecklistAlarms.Rows)
                {
                    int unitId = Int32.Parse(grdChecklistAlarms.DataKeys[row.RowIndex].Values["UnitID"].ToString());
                    int ruleId = Int32.Parse(grdChecklistAlarms.DataKeys[row.RowIndex].Values["RuleID"].ToString());
                    bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                    model.Update(unitId, ruleId, int.Parse(hdfCompanyId.Value), selected);
                }

                model.Table.AcceptChanges();

                dashboardChecklistAlarms = (DashboardTDS.DashboardChecklistAlarmsDataTable)model.Table;
                Session["dashboardChecklistAlarms"] = dashboardChecklistAlarms;

                HttpContext.Current.Session.Add("dashboardChecklistAlarmsTDS", dashboardChecklistAlarmsTDS);
            }
        }



        private int GetUnitId()
        {
            int unitId = 0;

            foreach (DashboardTDS.DashboardChecklistAlarmsRow row in dashboardChecklistAlarmsTDS.DashboardChecklistAlarms)
            {
                if (row.Selected)
                {
                    unitId = row.UnitID;
                }
            }

            return unitId;
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

            DataRow[] children = companyLevelsForAlarmsTDS.Tables["LFS_FM_COMPANYLEVEL"].Select("ParentID='" + parentId + "'");

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

            level--;//CHECK
        }



        public DashboardTDS.DashboardChecklistAlarmsDataTable GetDetails()
        {
            dashboardChecklistAlarms = (DashboardTDS.DashboardChecklistAlarmsDataTable)HttpContext.Current.Session["dashboardChecklistAlarmsDummy"];

            if (dashboardChecklistAlarms == null)
            {
                dashboardChecklistAlarms = ((DashboardTDS)HttpContext.Current.Session["dashboardChecklistAlarmsTDS"]).DashboardChecklistAlarms;
            }

            return dashboardChecklistAlarms;
        }



        protected void ChecklistAlarmsEmptyFix(GridView grdView)
        {
            if (grdChecklistAlarms.Rows.Count == 0)
            {
                DashboardTDS.DashboardChecklistAlarmsDataTable dt = new DashboardTDS.DashboardChecklistAlarmsDataTable();
                dt.AddDashboardChecklistAlarmsRow(0, 0, "", false, "");
                Session["dashboardChecklistAlarmsDummy"] = dt;

                grdChecklistAlarms.DataBind();
            }

            // Normally executes at all postbacks
            if (grdChecklistAlarms.Rows.Count == 1)
            {
                DashboardTDS.DashboardChecklistAlarmsDataTable dt = (DashboardTDS.DashboardChecklistAlarmsDataTable)Session["dashboardChecklistAlarmsDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdChecklistAlarms.Rows[0].Visible = false;
                    grdChecklistAlarms.Rows[0].Controls.Clear();
                }
            }
        }
        


    }
}