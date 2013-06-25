using System;
using CrystalDecisions.CrystalReports.Engine;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_costing_sheets_preview
    /// </summary>
    public partial class project_costing_sheets_preview : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_ADMIN"]))
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_EDIT"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
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
            string type = Request.QueryString["type"].ToString();

            if (type == "resume")
            {
                master.Title = "Preview Resume";
            }
            else
            {
                master.Title = "Preview Detailed";
            }
            master.ShowTitle = false;
            master.ShowToolBar = false;
            master.ShowCriteria = false;
            master.CriteriaWidth = "0px";

            if (!IsPostBack)
            {
                master.PrintDirectly = true;
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
            int costingSheetId = Convert.ToInt32(Request.QueryString["costing_sheet_id"].ToString());
            int projectId = Convert.ToInt32(Request.QueryString["project_id"].ToString());
            string type = Request.QueryString["type"].ToString();

            // Get Data
            ProjectCostingSheetInformationBasicInformation projectCostingSheetInformationBasicInformation = new ProjectCostingSheetInformationBasicInformation();
            projectCostingSheetInformationBasicInformation.LoadByCostingSheetIdForPreviewReport(costingSheetId, companyId);

            // ... set properties to master page
            master.Data = projectCostingSheetInformationBasicInformation.Data;
            master.Table = projectCostingSheetInformationBasicInformation.TableName;
            master.Report = new ProjectCostingSheetsPreview();

            // Get report
            if (projectCostingSheetInformationBasicInformation.Table.Rows.Count > 0)
            {
                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(Convert.ToInt32(Session["loginID"]), companyId);
                string user = loginGateway.GetLastName(Convert.ToInt32(Session["loginID"]), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(Session["loginID"]), companyId);
                master.SetParameter("User", user.Trim());

                // For process code
                ProjectCostingSheetInformationBasicInformationGateway projectCostingSheetInformationBasicInformationGateway = new ProjectCostingSheetInformationBasicInformationGateway(projectCostingSheetInformationBasicInformation.Data);
                master.SetParameter("CostingSheet", projectCostingSheetInformationBasicInformationGateway.GetName(costingSheetId));

                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);

                int clientId = projectGateway.GetClientID(projectId);

                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadByCompaniesId(clientId, companyId);

                master.SetParameter("Client", companiesGateway.GetName(clientId));

                string name = projectGateway.GetName(projectId);
                master.SetParameter("Project", name);

                if (type == "resume")
                {
                    ((Section)master.Report.ReportDefinition.Sections["detailsLabourHours"]).SectionFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["detailsLabourHours2"]).SectionFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["detailsUnits"]).SectionFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["detailsUnits2"]).SectionFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["detailsMaterials"]).SectionFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["detailsMaterials2"]).SectionFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["detailsOtherCosts"]).SectionFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["detailsOtherCosts2"]).SectionFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["detailsSubcontractors"]).SectionFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["detailsSubcontractors2"]).SectionFormat.EnableSuppress = true;
                }
                else
                {
                    ((Section)master.Report.ReportDefinition.Sections["detailsLabourHours"]).SectionFormat.EnableSuppress = false;
                    ((Section)master.Report.ReportDefinition.Sections["detailsLabourHours2"]).SectionFormat.EnableSuppress = false;
                    ((Section)master.Report.ReportDefinition.Sections["detailsUnits"]).SectionFormat.EnableSuppress = false;
                    ((Section)master.Report.ReportDefinition.Sections["detailsUnits2"]).SectionFormat.EnableSuppress = false;
                    ((Section)master.Report.ReportDefinition.Sections["detailsMaterials"]).SectionFormat.EnableSuppress = false;
                    ((Section)master.Report.ReportDefinition.Sections["detailsMaterials2"]).SectionFormat.EnableSuppress = false;
                    ((Section)master.Report.ReportDefinition.Sections["detailsOtherCosts"]).SectionFormat.EnableSuppress = false;
                    ((Section)master.Report.ReportDefinition.Sections["detailsOtherCosts2"]).SectionFormat.EnableSuppress = false;
                    ((Section)master.Report.ReportDefinition.Sections["detailsSubcontractors"]).SectionFormat.EnableSuppress = false;
                    ((Section)master.Report.ReportDefinition.Sections["detailsSubcontractors2"]).SectionFormat.EnableSuppress = false;
                }

                if (projectGateway.GetCountryID(projectId) == 1)//Canada
                {
                    // General
                    ((Section)master.Report.ReportDefinition.Sections["GroupHeaderSection1"]).ReportObjects["Text32"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["GroupHeaderSection1"]).ReportObjects["Text34"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["GroupHeaderSection1"]).ReportObjects["Text36"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["GroupHeaderSection1"]).ReportObjects["Text38"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["GroupHeaderSection1"]).ReportObjects["Text2"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["GroupHeaderSection1"]).ReportObjects["headerTotalSubcontractorsUsd"].ObjectFormat.EnableSuppress = true;

                    ((Section)master.Report.ReportDefinition.Sections["Section3"]).ReportObjects["TotalLabourHoursUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["Section3"]).ReportObjects["TotalUnitsUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["Section3"]).ReportObjects["TotalMaterialsUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["Section3"]).ReportObjects["TotalOtherCostsUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["Section3"]).ReportObjects["GrandTotalUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["Section3"]).ReportObjects["TotalSubcontractorsUsd1"].ObjectFormat.EnableSuppress = true;

                    ((Section)master.Report.ReportDefinition.Sections["GroupFooterSection1"]).ReportObjects["Text5"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["GroupFooterSection1"]).ReportObjects["GrandTotalUsd2"].ObjectFormat.EnableSuppress = true;

                    // Labour Hours
                    ReportDocument rpLabourHoursDetails = master.Report.OpenSubreport("LabourHoursDetails");
                    ReportDocument rpLabourHoursResume = master.Report.OpenSubreport("LabourHoursResume");

                    ((Section)rpLabourHoursDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text5"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpLabourHoursDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text2"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpLabourHoursDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["LHCostUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpLabourHoursDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["TotalCostUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpLabourHoursDetails.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostUsd2"].ObjectFormat.EnableSuppress = true;
                    
                    ((Section)rpLabourHoursResume.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text2"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpLabourHoursResume.ReportDefinition.Sections["GroupFooterSection1"]).ReportObjects["SumofTotalCostUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpLabourHoursResume.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostUsd2"].ObjectFormat.EnableSuppress = true;

                    // Units
                    ReportDocument rpUnitsDetails = master.Report.OpenSubreport("UnitsDetails");
                    ReportDocument rpUnitsResume = master.Report.OpenSubreport("UnitsResume");

                    ((Section)rpUnitsDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text3"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpUnitsDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text2"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpUnitsDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["CostUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpUnitsDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["TotalCostUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpUnitsDetails.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostUsd2"].ObjectFormat.EnableSuppress = true;
                    
                    ((Section)rpUnitsResume.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text6"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpUnitsResume.ReportDefinition.Sections["GroupFooterSection1"]).ReportObjects["SumofTotalCostUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpUnitsResume.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostUsd2"].ObjectFormat.EnableSuppress = true;

                    // Materials
                    ReportDocument rpMaterialsDetails = master.Report.OpenSubreport("MaterialsDetails");
                    ReportDocument rpMaterialsResune = master.Report.OpenSubreport("MaterialsResume");

                    ((Section)rpMaterialsDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text3"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpMaterialsDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text2"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpMaterialsDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["CostUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpMaterialsDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["TotalCostUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpMaterialsDetails.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostUsd2"].ObjectFormat.EnableSuppress = true;

                    ((Section)rpMaterialsResune.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text6"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpMaterialsResune.ReportDefinition.Sections["GroupFooterSection1"]).ReportObjects["SumofTotalCostUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpMaterialsResune.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostUsd2"].ObjectFormat.EnableSuppress = true;

                    // Subcontractors
                    ReportDocument rpSubcontractorsDetails = master.Report.OpenSubreport("SubcontractorsDetails");
                    ReportDocument rpSubcontractorsResune = master.Report.OpenSubreport("SubcontractorsResume");

                    ((Section)rpSubcontractorsDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text3"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpSubcontractorsDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text2"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpSubcontractorsDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["CostUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpSubcontractorsDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["TotalCostUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpSubcontractorsDetails.ReportDefinition.Sections["GroupFooterSection1"]).ReportObjects["SumofSubTotalCostUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpSubcontractorsDetails.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostUsd1"].ObjectFormat.EnableSuppress = true;

                    ((Section)rpSubcontractorsResune.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["lblTotalCostUsd"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpSubcontractorsResune.ReportDefinition.Sections["GroupFooterSection1"]).ReportObjects["SumofTotalCostUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpSubcontractorsResune.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostUsd2"].ObjectFormat.EnableSuppress = true;

                    // Other Costs
                    ReportDocument rpOtherCostsDetails = master.Report.OpenSubreport("OtherCostsDetails");
                    ReportDocument rpOtherCostsResume = master.Report.OpenSubreport("OtherCostsResume");

                    ((Section)rpOtherCostsDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text3"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpOtherCostsDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text2"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpOtherCostsDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["CostUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpOtherCostsDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["TotalCostUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpOtherCostsDetails.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostUsd2"].ObjectFormat.EnableSuppress = true;

                    ((Section)rpOtherCostsResume.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text6"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpOtherCostsResume.ReportDefinition.Sections["GroupFooterSection1"]).ReportObjects["SumofTotalCostUsd1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpOtherCostsResume.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostUsd2"].ObjectFormat.EnableSuppress = true;
                }
                else//USA
                {
                    // General
                    ((Section)master.Report.ReportDefinition.Sections["GroupHeaderSection1"]).ReportObjects["Text31"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["GroupHeaderSection1"]).ReportObjects["Text33"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["GroupHeaderSection1"]).ReportObjects["Text35"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["GroupHeaderSection1"]).ReportObjects["Text37"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["GroupHeaderSection1"]).ReportObjects["Text1"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["GroupHeaderSection1"]).ReportObjects["headerTotalSubcontractorsCad"].ObjectFormat.EnableSuppress = true;

                    ((Section)master.Report.ReportDefinition.Sections["Section3"]).ReportObjects["TotalLabourHoursCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["Section3"]).ReportObjects["TotalUnitsCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["Section3"]).ReportObjects["TotalMaterialsCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["Section3"]).ReportObjects["TotalOtherCostsCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["Section3"]).ReportObjects["GrandTotalCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["Section3"]).ReportObjects["TotalSubcontractorsCad1"].ObjectFormat.EnableSuppress = true;

                    ((Section)master.Report.ReportDefinition.Sections["GroupFooterSection1"]).ReportObjects["Text4"].ObjectFormat.EnableSuppress = true;
                    ((Section)master.Report.ReportDefinition.Sections["GroupFooterSection1"]).ReportObjects["GrandTotalCad2"].ObjectFormat.EnableSuppress = true;

                    // Labour Hours
                    ReportDocument rpLabourHoursDetails = master.Report.OpenSubreport("LabourHoursDetails");
                    ReportDocument rpLabourHoursResume = master.Report.OpenSubreport("LabourHoursResume");

                    ((Section)rpLabourHoursDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text9"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpLabourHoursDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text6"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpLabourHoursDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["LHCostCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpLabourHoursDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["TotalCostCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpLabourHoursDetails.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostCad2"].ObjectFormat.EnableSuppress = true;

                    ((Section)rpLabourHoursResume.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text4"].ObjectFormat.EnableSuppress = true;                    
                    ((Section)rpLabourHoursResume.ReportDefinition.Sections["GroupFooterSection1"]).ReportObjects["SumofTotalCostCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpLabourHoursResume.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostCad2"].ObjectFormat.EnableSuppress = true;

                    // Units
                    ReportDocument rpUnitsDetails = master.Report.OpenSubreport("UnitsDetails");
                    ReportDocument rpUnitsResume = master.Report.OpenSubreport("UnitsResume");

                    ((Section)rpUnitsDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text5"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpUnitsDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text4"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpUnitsDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["CostCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpUnitsDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["TotalCostCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpUnitsDetails.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostCad2"].ObjectFormat.EnableSuppress = true;

                    ((Section)rpUnitsResume.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text4"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpUnitsResume.ReportDefinition.Sections["GroupFooterSection1"]).ReportObjects["SumofTotalCostCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpUnitsResume.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostCad2"].ObjectFormat.EnableSuppress = true;

                    // Materials
                    ReportDocument rpMaterialsDetails = master.Report.OpenSubreport("MaterialsDetails");
                    ReportDocument rpMaterialsResune = master.Report.OpenSubreport("MaterialsResume");

                    ((Section)rpMaterialsDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text5"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpMaterialsDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text4"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpMaterialsDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["CostCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpMaterialsDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["TotalCostCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpMaterialsDetails.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostCad2"].ObjectFormat.EnableSuppress = true;

                    ((Section)rpMaterialsResune.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text4"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpMaterialsResune.ReportDefinition.Sections["GroupFooterSection1"]).ReportObjects["SumofTotalCostCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpMaterialsResune.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostCad2"].ObjectFormat.EnableSuppress = true;

                    // Subcontractors
                    ReportDocument rpSubcontractorsDetails = master.Report.OpenSubreport("SubcontractorsDetails");
                    ReportDocument rpSubcontractorsResune = master.Report.OpenSubreport("SubcontractorsResume");

                    ((Section)rpSubcontractorsDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text5"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpSubcontractorsDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text4"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpSubcontractorsDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["CostCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpSubcontractorsDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["TotalCostCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpSubcontractorsDetails.ReportDefinition.Sections["GroupFooterSection1"]).ReportObjects["SumofSubTotalCostCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpSubcontractorsDetails.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostCad1"].ObjectFormat.EnableSuppress = true;

                    ((Section)rpSubcontractorsResune.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["lblTotalCostCad"].ObjectFormat.EnableSuppress = true;                    
                    ((Section)rpSubcontractorsResune.ReportDefinition.Sections["GroupFooterSection1"]).ReportObjects["SumofTotalCostCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpSubcontractorsResune.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostCad2"].ObjectFormat.EnableSuppress = true;

                    // Other Costs
                    ReportDocument rpOtherCostsDetails = master.Report.OpenSubreport("OtherCostsDetails");
                    ReportDocument rpOtherCostsResume = master.Report.OpenSubreport("OtherCostsResume");

                    ((Section)rpOtherCostsDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text5"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpOtherCostsDetails.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text4"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpOtherCostsDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["CostCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpOtherCostsDetails.ReportDefinition.Sections["DetailSection1"]).ReportObjects["TotalCostCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpOtherCostsDetails.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostCad2"].ObjectFormat.EnableSuppress = true;

                    ((Section)rpOtherCostsResume.ReportDefinition.Sections["ReportHeaderSection2"]).ReportObjects["Text4"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpOtherCostsResume.ReportDefinition.Sections["GroupFooterSection1"]).ReportObjects["SumofTotalCostCad1"].ObjectFormat.EnableSuppress = true;
                    ((Section)rpOtherCostsResume.ReportDefinition.Sections["ReportFooterSection1"]).ReportObjects["SumofTotalCostCad2"].ObjectFormat.EnableSuppress = true;
                }
            }
        }



    }
}