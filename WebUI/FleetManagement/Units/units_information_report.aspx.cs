using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.RAF;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.BL.FleetManagement.Units;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Units
{
    /// <summary>
    /// units_information_report
    /// </summary>
    public partial class units_information_report : System.Web.UI.Page
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in units_information_report.aspx");
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
            master.Title = "Units Information Report";

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

            // Get Data
            LiquiForce.LFSLive.BL.FleetManagement.Units.UnitInformationReport unitInformationReport = new LiquiForce.LFSLive.BL.FleetManagement.Units.UnitInformationReport();

            if (rbtnByUnit.Checked)
            {
                if (ddlUnits.SelectedValue == "-1")
                {
                    unitInformationReport.Load(companyId);
                }
                else
                {
                    int unitId = Int32.Parse(ddlUnits.SelectedValue);
                    unitInformationReport.LoadByUnitId(unitId, companyId);
                }
            }

            if (rbtnByUnitType.Checked)
            {
                unitInformationReport.LoadByUnitType(ddlUnitType.SelectedValue, companyId);
            }

            // ... set properties to master page
            master.Data = unitInformationReport.Data;
            master.Table = unitInformationReport.TableName;

            // Get report
            if (unitInformationReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new UnitsInformationReport();
                    int loginId = Convert.ToInt32(Session["loginID"]);                    
                    
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    if (rbtnByUnit.Checked)
                    {
                        if (ddlUnits.SelectedValue != "-1")
                        {
                            // For unit code
                            int unitId = Int32.Parse(ddlUnits.SelectedValue);
                            UnitsGateway unitsGateway = new UnitsGateway();
                            unitsGateway.LoadByUnitId(unitId, companyId);
                            string unitCode = unitsGateway.GetUnitCode(unitId);
                            master.SetParameter("Unit", unitCode);
                        }
                        else
                        {
                            master.SetParameter("Unit", "All");
                        }
                    }
                    else
                    {
                        master.SetParameter("Unit", "All");
                    }
                }
                else
                {
                    master.Report = new UnitsInformationReportExport();
                }               
            }
        }



    }
}