using System;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Units
{
    /// <summary>
    /// units_checklists_report
    /// </summary>
    public partial class units_checklists_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Security check
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in units_checklists_report.aspx");
                }

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
            // Set title & criteria width
            mReport1 master = (mReport1)this.Master;
            master.Title = "Units Checklists Report";

            master.ShowTitle = true;
            master.ShowToolBar = true;
            master.ShowCriteria = true;
            master.CriteriaWidth = "200px";

            if (!IsPostBack)
            {
                master.PrintDirectly = false;
                master.ExportDirectly = false;
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
            int companyId = Convert.ToInt32(Session["companyID"]);
            string checklistState = ddlChecklistState.SelectedValue;
            string mtoDotRules = ddlMtoDotRule.SelectedValue;
            string frequency = ddlFrequency.SelectedValue;
            string workingLocation = ddlWorkingLocation.SelectedValue;

            // Get Data
            LiquiForce.LFSLive.BL.FleetManagement.Units.UnitChecklistsReportUnitDetails unitChecklistsReportUnitDetails = new LiquiForce.LFSLive.BL.FleetManagement.Units.UnitChecklistsReportUnitDetails();

            // ... Load data by unit
            if (rbtnByUnit.Checked)
            {                              
                unitChecklistsReportUnitDetails.LoadByUnitId(Int32.Parse(ddlUnits.SelectedValue), mtoDotRules, frequency, checklistState, companyId);                
            }

            // ... Load data by unit type
            bool allUnits = ckbxAllUnits.Checked;
            if (rbtnByUnitType.Checked)
            {
                if (ddlUnitType.SelectedValue == "All")
                {
                    if (ddlWorkingLocation.SelectedValue == "All")
                    {
                        unitChecklistsReportUnitDetails.Load(mtoDotRules, frequency, checklistState, companyId, allUnits);
                    }
                    else
                    {
                        unitChecklistsReportUnitDetails.LoadByWorkingLocation(workingLocation, mtoDotRules, frequency, checklistState, companyId, allUnits);
                    }
                }
                else
                {
                    if (ddlWorkingLocation.SelectedValue == "All")
                    {
                        unitChecklistsReportUnitDetails.LoadByUnitType(ddlUnitType.SelectedValue, mtoDotRules, frequency, checklistState, companyId, allUnits);
                    }
                    else
                    {
                        unitChecklistsReportUnitDetails.LoadByUnitTypeWorkingLocation(ddlUnitType.SelectedValue, workingLocation, mtoDotRules, frequency, checklistState, companyId, allUnits);
                    }
                }
            }

            // ... set properties to master page
            master.Data = unitChecklistsReportUnitDetails.Data;
            master.Table = unitChecklistsReportUnitDetails.TableName;

            // Get report
            if (unitChecklistsReportUnitDetails.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new UnitsChecklistsReport();
                    
                    int loginId = Convert.ToInt32(Session["loginID"]);                    

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());                    

                    // For unit code
                    if (rbtnByUnit.Checked)
                    {                        
                        int unitId = Int32.Parse(ddlUnits.SelectedValue);
                        UnitsGateway unitsGateway = new UnitsGateway();
                        unitsGateway.LoadByUnitId(unitId, companyId);
                        string unitCode = unitsGateway.GetUnitCode(unitId);
                        master.SetParameter("Unit", unitCode);
                    }
                    else
                    {
                        master.SetParameter("Unit", "");
                    }

                    // For Unit Type
                    if (rbtnByUnitType.Checked)
                    {
                        if (ddlUnitType.SelectedValue == "All")
                        {
                            master.SetParameter("UnitType", "All");
                        }
                        else
                        {
                            master.SetParameter("UnitType", ddlUnitType.SelectedValue);
                        }
                    }
                    else
                    {
                        master.SetParameter("UnitType", "");
                    }

                    // For Working Location
                    if (ddlWorkingLocation.SelectedValue == "All")
                    {
                        master.SetParameter("WorkingLocation", "All");
                    }
                    else
                    {
                        if (ddlWorkingLocation.SelectedValue == "3")
                        {
                            master.SetParameter("WorkingLocation", "LFS USA");
                        }
                        else
                        {
                            master.SetParameter("WorkingLocation", "LFS Canada");
                        }
                    }

                    // For MTO/DOT Rules
                    if (ddlMtoDotRule.SelectedValue == "All")
                    {
                        master.SetParameter("MTO", "All");
                    }
                    else
                    {
                        master.SetParameter("MTO", ddlMtoDotRule.SelectedValue);
                    }

                    // For Frequency
                    if (ddlFrequency.SelectedValue == "(All)")
                    {
                        master.SetParameter("Frequency", "All");
                    }
                    else
                    {
                        master.SetParameter("Frequency", ddlFrequency.SelectedValue);
                    }

                    // For Checklist State
                    if (ddlChecklistState.SelectedValue == "All")
                    {
                        master.SetParameter("State", "All");
                    }
                    else
                    {
                        master.SetParameter("State", ddlChecklistState.SelectedValue);
                    }
                }
                else
                {
                    master.Report = new UnitsChecklistsReportExport();
                }
            }
        }



    }
}