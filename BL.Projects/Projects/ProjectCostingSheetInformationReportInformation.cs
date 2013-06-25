using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetInformationReportInformation
    /// </summary>
    public class ProjectCostingSheetInformationReportInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetInformationReportInformation()
            : base("ReportInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetInformationReportInformation(DataSet data)
            : base(data, "ReportInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Load(int companyId)
        {
            ProjectCostingSheetInformationReportInformationGateway projectCostingSheetInformationReportInformationGateway = new ProjectCostingSheetInformationReportInformationGateway(Data);
            projectCostingSheetInformationReportInformationGateway.Load(companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesId(int companiesId, int companyId)
        {
            ProjectCostingSheetInformationReportInformationGateway projectCostingSheetInformationReportInformationGateway = new ProjectCostingSheetInformationReportInformationGateway(Data);
            projectCostingSheetInformationReportInformationGateway.LoadByCompaniesId(companiesId, companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdProjectId(int companiesId, int projectId, int companyId)
        {
            ProjectCostingSheetInformationReportInformationGateway projectCostingSheetInformationReportInformationGateway = new ProjectCostingSheetInformationReportInformationGateway(Data);
            projectCostingSheetInformationReportInformationGateway.LoadByCompaniesIdProjectId(companiesId, projectId, companyId);

            UpdateForReport();
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        private void UpdateForReport()
        {
            ProjectCostingSheetInformationLabourHoursInformationGateway projectCostingSheetInformationLabourHoursInformationGateway = new ProjectCostingSheetInformationLabourHoursInformationGateway(Data);
            projectCostingSheetInformationLabourHoursInformationGateway.ClearBeforeFill = false;

            ProjectCostingSheetInformationUnitsInformationGateway projectCostingSheetInformationUnitsInformationGateway = new ProjectCostingSheetInformationUnitsInformationGateway(Data);
            projectCostingSheetInformationUnitsInformationGateway.ClearBeforeFill = false;

            ProjectCostingSheetInformationMaterialsInformationGateway projectCostingSheetInformationMaterialsInformationGateway = new ProjectCostingSheetInformationMaterialsInformationGateway(Data);
            projectCostingSheetInformationMaterialsInformationGateway.ClearBeforeFill = false;

            ProjectCostingSheetInformationOtherCostsInformationGateway projectCostingSheetInformationOtherCostsInformationGateway = new ProjectCostingSheetInformationOtherCostsInformationGateway(Data);
            projectCostingSheetInformationOtherCostsInformationGateway.ClearBeforeFill = false;

            projectCostingSheetInformationRevenueInformationGateway projectCostingSheetInformationRevenueInformationGateway = new projectCostingSheetInformationRevenueInformationGateway(Data);
            projectCostingSheetInformationRevenueInformationGateway.ClearBeforeFill = false;

            foreach (ProjectCostingSheetInformationTDS.ReportInformationRow row in (ProjectCostingSheetInformationTDS.ReportInformationDataTable)Table)
            {
                projectCostingSheetInformationLabourHoursInformationGateway.LoadByCostingSheetId(row.CostingSheetID, row.COMPANY_ID);
                projectCostingSheetInformationUnitsInformationGateway.LoadByCostingSheetId(row.CostingSheetID, row.COMPANY_ID);
                projectCostingSheetInformationMaterialsInformationGateway.LoadByCostingSheetId(row.CostingSheetID, row.COMPANY_ID);
                projectCostingSheetInformationOtherCostsInformationGateway.LoadByCostingSheetId(row.CostingSheetID, row.COMPANY_ID);
                projectCostingSheetInformationRevenueInformationGateway.LoadByCostingSheetId(row.CostingSheetID, row.COMPANY_ID);
            }
        }



    }
}