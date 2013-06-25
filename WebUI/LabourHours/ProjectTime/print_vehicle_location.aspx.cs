using System;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// print_vehicle_location
    /// </summary>
    public partial class print_vehicle_location : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_REPORTS"]))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();

                // Initialize viewstate variables
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                ViewState["LHMode"] = appSettingReader.GetValue("LABOUR_HOURS_OPERATION_MODE", typeof(System.String)).ToString();

                // Prepare initial data for client
                ddlProjectTimeState.SelectedValue = "Approved";
                tkrdpStartDate.SelectedDate = DateTime.Now;
                tkrdpEndDate.SelectedDate = DateTime.Now;

                // Databind
                ddlUnit.DataBind();

                // Register delegates
                this.RegisterDelegates();
            }
            else
            {
                // Register delegates
                this.RegisterDelegates();
            }
        }

        

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Dialog title
            mReport1 master = (mReport1)this.Master;
            master.Title = "Print Vehicle Location Report";

            master.ShowTitle = true;
            master.ShowToolBar = true;
            master.ShowCriteria = true;
            master.CriteriaWidth = "200px";

            if (!IsPostBack)
            {
                master.PrintDirectly = false;
                master.ExportDirectly = false;
            }
            
            // Access control
            // ... Labour Hours Mode
            if ((string)ViewState["LHMode"] == "Partial")
            {
                lblProjectTimeState.Visible = false;
                ddlProjectTimeState.Visible = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterDelegates()
        {
            mReport1 master = (mReport1)this.Master;
            master.GenerateMethod = new mReport1.ReportMethod(Generate);
        }



        private void Generate()
        {
            mReport1 master = (mReport1)this.Master;

            // Get Data
            string projectTimeState = (ddlProjectTimeState.SelectedValue == "(All)") ? "%" : ddlProjectTimeState.SelectedValue;

            PrintVehicleLocationGateway printVehicleLocationGateway = new PrintVehicleLocationGateway();

            if (ddlCountry.SelectedValue == "(All)")
            {
                if (ddlUnit.SelectedValue == "-1")
                {
                    printVehicleLocationGateway.LoadByStartDateEndDateProjectTimeState(DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString()), DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString()), projectTimeState);
                }
                else
                {
                    printVehicleLocationGateway.LoadByStartDateEndDateUnitIdProjectTimeState(DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString()), DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString()), int.Parse(ddlUnit.SelectedValue), projectTimeState);
                }
            }
            else
            { 
                if (ddlUnit.SelectedValue == "-1")
                {
                    printVehicleLocationGateway.LoadByStartDateEndDateProjectTimeStateCountryId(DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString()), DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString()), projectTimeState, int.Parse(ddlCountry.SelectedValue));
                }
                else
                {
                    printVehicleLocationGateway.LoadByStartDateEndDateUnitIdProjectTimeStateCountryId(DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString()), DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString()), int.Parse(ddlUnit.SelectedValue), projectTimeState, int.Parse(ddlCountry.SelectedValue));
                }
            }

            // ... set properties to master page
            master.Data = printVehicleLocationGateway.Data;
            master.Table = printVehicleLocationGateway.TableName;

            // Get report
            int companyId = Convert.ToInt32(Session["companyID"]);    

            if (printVehicleLocationGateway.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintVehicleLocationReport();
                }
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.PrintVehicleLocationReportExport();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    // ... For report
                    // ... ... project time state
                    if (ddlProjectTimeState.SelectedValue == "(All)")
                    {
                        master.SetParameter("projectTimeState", "All");
                    }
                    else
                    {
                        master.SetParameter("projectTimeState", ddlProjectTimeState.SelectedItem.Text);
                    }

                    // ... ... unit
                    if (ddlUnit.SelectedValue == "-1")
                    {
                        master.SetParameter("unitName", "All");
                    }
                    else
                    {                        
                        int unitId = Int32.Parse(ddlUnit.SelectedValue);                        
                        UnitsGateway unitsGateway = new UnitsGateway();
                        unitsGateway.LoadByUnitId(unitId, companyId);
                        string unitName = "(" + unitsGateway.GetUnitCode(unitId) + ") " + unitsGateway.GetDescription(unitId);

                        master.SetParameter("unitName", unitName);
                    }

                    // ... ...  user
                    int loginId = Convert.ToInt32(Session["loginID"]);                             

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    // ... ...  dates
                    master.SetParameter("dateFrom", tkrdpStartDate.SelectedDate.Value.ToShortDateString());
                    master.SetParameter("dateTo", tkrdpEndDate.SelectedDate.Value.ToShortDateString());

                    // ... ... country
                    if (ddlCountry.SelectedValue == "2")
                    {
                        master.SetParameter("Country", "USA");
                    }
                    else
                    {
                        if (ddlCountry.SelectedValue == "1")
                        {
                            master.SetParameter("Country", "Canada");
                        }
                        else
                        {
                            master.SetParameter("Country", "All");
                        }
                    }
                }
            }
        }



    }
}