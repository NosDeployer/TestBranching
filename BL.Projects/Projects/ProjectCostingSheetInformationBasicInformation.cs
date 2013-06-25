using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetInformationBasicInformation
    /// </summary>
    public class ProjectCostingSheetInformationBasicInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetInformationBasicInformation()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetInformationBasicInformation(DataSet data)
            : base(data, "BasicInformation")
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
        /// LoadByCostingSheetId
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCostingSheetId(int costingSheetId, int companyId)
        {
            ProjectCostingSheetInformationBasicInformationGateway projectCostingSheetInformationBasicInformationGateway = new ProjectCostingSheetInformationBasicInformationGateway(Data);
            projectCostingSheetInformationBasicInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

            UpdateForProject();
        }



        /// <summary>
        /// LoadByCostingSheetIdForPreviewReport
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCostingSheetIdForPreviewReport(int costingSheetId, int companyId)
        {
            ProjectCostingSheetInformationBasicInformationGateway projectCostingSheetInformationBasicInformationGateway = new ProjectCostingSheetInformationBasicInformationGateway(Data);
            projectCostingSheetInformationBasicInformationGateway.LoadByCostingSheetId(costingSheetId, companyId);

            UpdateForReport();
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="name">name</param>
        /// <param name="totalLabourHoursCad">totalLabourHoursCad</param>
        /// <param name="totalLabourHoursUsd">totalLabourHoursUsd</param>
        /// <param name="totalMaterialsCad">totalMaterialsCad</param>
        /// <param name="totalMaterialsUsd">totalMaterialsUsd</param>
        /// <param name="totalUnitsCad">totalUnitsCad</param>
        /// <param name="totalUnitsUsd">totalUnitsUsd</param>
        /// <param name="totalOtherCostsCad">totalOtherCostsCad</param>
        /// <param name="totalOtherCostsUsd">totalOtherCostsUsd</param>
        /// <param name="grandTotalCad">grandTotalCad</param>
        /// <param name="grandTotalUsd">grandTotalUsd</param>
        public void Update(int costingSheetId, string name, decimal totalLabourHoursCad, decimal totalLabourHoursUsd, decimal totalMaterialsCad, decimal totalMaterialsUsd, decimal totalUnitsCad, decimal totalUnitsUsd, decimal totalOtherCostsCad, decimal totalOtherCostsUsd, decimal grandTotalCad, decimal grandTotalUsd, decimal totalSubcontractorsCad, decimal totalSubcontractorsUsd, decimal grandRevenue, decimal grandProfit, decimal grandGrossMargin)
        {
            ProjectCostingSheetInformationTDS.BasicInformationRow row = GetRow(costingSheetId);

            // General Data
            row.Name = name.ToString();
            row.TotalLabourHoursCad = totalLabourHoursCad;
            row.TotalLabourHoursUsd = totalLabourHoursUsd;
            row.TotalMaterialsCad = totalMaterialsCad;
            row.TotalMaterialsUsd = totalMaterialsUsd;
            row.TotalUnitsCad = totalUnitsCad;
            row.TotalUnitsUsd = totalUnitsUsd;
            row.TotalOtherCostsCad = totalOtherCostsCad;
            row.TotalOtherCostsUsd = totalOtherCostsUsd;
            row.GrandTotalCad = grandTotalCad;
            row.GrandTotalUsd = grandTotalUsd;
            row.TotalSubcontractorsCad = totalSubcontractorsCad;
            row.TotalSubcontractorsUsd = totalSubcontractorsUsd;
            row.GrandRevenue = grandRevenue;
            row.GrandProfit = grandProfit;
            row.GrandGrossMargin = grandGrossMargin;
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            ProjectCostingSheetInformationTDS projectCostingSheetInformationChanges = (ProjectCostingSheetInformationTDS)Data.GetChanges();

            if (projectCostingSheetInformationChanges.BasicInformation.Rows.Count > 0)
            {
                ProjectCostingSheetInformationBasicInformationGateway projectCostingSheetInformationBasicInformationGateway = new ProjectCostingSheetInformationBasicInformationGateway(projectCostingSheetInformationChanges);

                // Update costing sheet
                foreach (ProjectCostingSheetInformationTDS.BasicInformationRow basicInformationRow in (ProjectCostingSheetInformationTDS.BasicInformationDataTable)projectCostingSheetInformationChanges.BasicInformation)
                {
                    // Unchanged values
                    int costingSheetId = basicInformationRow.CostingSheetID;
                    int projectId = basicInformationRow.ProjectID;
                    DateTime startDate = basicInformationRow.StartDate;
                    DateTime endDate = basicInformationRow.EndDate;

                    // Original values
                    string originalName = projectCostingSheetInformationBasicInformationGateway.GetNameOriginal(costingSheetId);                    
                    decimal originalTotalLabourHoursCad = projectCostingSheetInformationBasicInformationGateway.GetTotalLabourHoursCadOriginal(costingSheetId);
                    decimal originalTotalLabourHoursUsd = projectCostingSheetInformationBasicInformationGateway.GetTotalLabourHoursUsdOriginal(costingSheetId);
                    decimal originalTotalMaterialsCad = projectCostingSheetInformationBasicInformationGateway.GetTotalMaterialsCadOriginal(costingSheetId);
                    decimal originalTotalMaterialsUsd = projectCostingSheetInformationBasicInformationGateway.GetTotalMaterialsUsdOriginal(costingSheetId);
                    decimal originalTotalUnitsCad = projectCostingSheetInformationBasicInformationGateway.GetTotalUnitsCadOriginal(costingSheetId);
                    decimal originalTotalUnitsUsd = projectCostingSheetInformationBasicInformationGateway.GetTotalUnitsUsdOriginal(costingSheetId);
                    decimal originalTotalOtherCostsCad = projectCostingSheetInformationBasicInformationGateway.GetTotalOtherCostsCadOriginal(costingSheetId);
                    decimal originalTotalOtherCostsUsd = projectCostingSheetInformationBasicInformationGateway.GetTotalOtherCostsUsdOriginal(costingSheetId);
                    decimal originalGrandTotalCad = projectCostingSheetInformationBasicInformationGateway.GetGrandTotalCadOriginal(costingSheetId);
                    decimal originalGrandTotalUsd = projectCostingSheetInformationBasicInformationGateway.GetGrandTotalUsdOriginal(costingSheetId);
                    string originalState = projectCostingSheetInformationBasicInformationGateway.GetStateOriginal(costingSheetId);
                    bool originalDeleted = projectCostingSheetInformationBasicInformationGateway.GetDeletedOriginal(costingSheetId);
                    decimal originalTotalSubcontractorsCad = projectCostingSheetInformationBasicInformationGateway.GetTotalSubcontractorsCadOriginal(costingSheetId);
                    decimal originalTotalSubcontractorsUsd = projectCostingSheetInformationBasicInformationGateway.GetTotalSubcontractorsUsdOriginal(costingSheetId);
                    decimal originalGrandRevenue = projectCostingSheetInformationBasicInformationGateway.GetGrandRevenueOriginal(costingSheetId);
                    decimal originalGrandProfit = projectCostingSheetInformationBasicInformationGateway.GetGrandProfitOriginal(costingSheetId);
                    decimal originalGrandGrossMargin = projectCostingSheetInformationBasicInformationGateway.GetGrandGrossMarginOriginal(costingSheetId);

                    // New variables
                    string newName = projectCostingSheetInformationBasicInformationGateway.GetName(costingSheetId);
                    decimal newTotalLabourHoursCad = projectCostingSheetInformationBasicInformationGateway.GetTotalLabourHoursCad(costingSheetId);
                    decimal newTotalLabourHoursUsd = projectCostingSheetInformationBasicInformationGateway.GetTotalLabourHoursUsd(costingSheetId);
                    decimal newTotalMaterialsCad = projectCostingSheetInformationBasicInformationGateway.GetTotalMaterialsCad(costingSheetId);
                    decimal newTotalMaterialsUsd = projectCostingSheetInformationBasicInformationGateway.GetTotalMaterialsUsd(costingSheetId);
                    decimal newTotalUnitsCad = projectCostingSheetInformationBasicInformationGateway.GetTotalUnitsCad(costingSheetId);
                    decimal newTotalUnitsUsd = projectCostingSheetInformationBasicInformationGateway.GetTotalUnitsUsd(costingSheetId);
                    decimal newTotalOtherCostsCad = projectCostingSheetInformationBasicInformationGateway.GetTotalOtherCostsCad(costingSheetId);
                    decimal newTotalOtherCostsUsd = projectCostingSheetInformationBasicInformationGateway.GetTotalOtherCostsUsd(costingSheetId);
                    decimal newGrandTotalCad = projectCostingSheetInformationBasicInformationGateway.GetGrandTotalCad(costingSheetId);
                    decimal newGrandTotalUsd = projectCostingSheetInformationBasicInformationGateway.GetGrandTotalUsd(costingSheetId);
                    string newState = projectCostingSheetInformationBasicInformationGateway.GetState(costingSheetId);
                    bool newDeleted = projectCostingSheetInformationBasicInformationGateway.GetDeleted(costingSheetId);
                    decimal newTotalSubcontractorsCad = projectCostingSheetInformationBasicInformationGateway.GetTotalSubcontractorsCad(costingSheetId);
                    decimal newTotalSubcontractorsUsd = projectCostingSheetInformationBasicInformationGateway.GetTotalSubcontractorsUsd(costingSheetId);
                    decimal newGrandRevenue = projectCostingSheetInformationBasicInformationGateway.GetGrandRevenue(costingSheetId);
                    decimal newGrandProfit = projectCostingSheetInformationBasicInformationGateway.GetGrandProfit(costingSheetId);
                    decimal newGrandGrossMargin = projectCostingSheetInformationBasicInformationGateway.GetGrandGrossMargin(costingSheetId);

                    // ... Update 
                    UpdateCostingSheet(costingSheetId, projectId, originalName, startDate, endDate, originalTotalLabourHoursCad, originalTotalLabourHoursUsd, originalTotalMaterialsCad, originalTotalMaterialsUsd, originalTotalUnitsCad, originalTotalUnitsUsd, originalTotalOtherCostsCad, originalTotalOtherCostsUsd, originalGrandTotalCad, originalGrandTotalUsd, originalState, originalDeleted, companyId, originalTotalSubcontractorsCad, originalTotalSubcontractorsUsd, originalGrandRevenue, originalGrandProfit, originalGrandGrossMargin, projectId, newName, startDate, endDate, newTotalLabourHoursCad, newTotalLabourHoursUsd, newTotalMaterialsCad, newTotalMaterialsUsd, newTotalUnitsCad, newTotalUnitsUsd, newTotalOtherCostsCad, newTotalOtherCostsUsd, newGrandTotalCad, newGrandTotalUsd, newState, newDeleted, companyId, newTotalSubcontractorsCad, newTotalSubcontractorsUsd, newGrandRevenue, newGrandProfit, newGrandGrossMargin);                            
                }
            }
        }

        
        
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Delete(int costingSheetId)
        {
            ProjectCostingSheetInformationTDS.BasicInformationRow row = GetRow(costingSheetId);
            row.Deleted = true;
        }



        /// <summary>
        /// UpdateState
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="state">state</param>
        public void UpdateState(int costingSheetId, string state)
        {
            ProjectCostingSheetInformationTDS.BasicInformationRow row = GetRow(costingSheetId);
            row.State = state;
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int costingSheetId, int companyId)
        {
            // Delete costing sheet
            ProjectCostingSheet projectCostingSheet = new ProjectCostingSheet(null);
            projectCostingSheet.DeleteDirect(costingSheetId, companyId);
        }





                
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateCostingSheet
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalName">originalName</param>
        /// <param name="originalStartDate">originalStartDate</param>
        /// <param name="originalEndDate">originalEndDate</param>
        /// <param name="originalTotalLabourHoursCad">originalTotalLabourHoursCad</param>
        /// <param name="originalTotalLabourHoursUsd">originalTotalLabourHoursUsd</param>
        /// <param name="originalTotalMaterialsCad">originalTotalMaterialsCad</param>
        /// <param name="originalTotalMaterialsUsd">originalTotalMaterialsUsd</param>
        /// <param name="originalTotalUnitsCad">originalTotalUnitsCad</param>
        /// <param name="originalTotalUnitsUsd">originalTotalUnitsUsd</param>
        /// <param name="originalTotalOtherCostsCad">originalTotalOtherCostsCad</param>
        /// <param name="originalTotalOtherCostsUsd">originalTotalOtherCostsUsd</param>
        /// <param name="originalGrandTotalCad">originalGrandTotalCad</param>
        /// <param name="originalGrandTotalUsd">originalGrandTotalUsd</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newName">newName</param>
        /// <param name="newStartDate">newStartDate</param>
        /// <param name="newEndDate">newEndDate</param>
        /// <param name="newTotalLabourHoursCad">newTotalLabourHoursCad</param>
        /// <param name="newTotalLabourHoursUsd">newTotalLabourHoursUsd</param>
        /// <param name="newTotalMaterialsCad">newTotalMaterialsCad</param>
        /// <param name="newTotalMaterialsUsd">newTotalMaterialsUsd</param>
        /// <param name="newTotalUnitsCad">newTotalUnitsCad</param>
        /// <param name="newTotalUnitsUsd">newTotalUnitsUsd</param>
        /// <param name="newTotalOtherCostsCad">newTotalOtherCostsCad</param>
        /// <param name="newTotalOtherCostsUsd">newTotalOtherCostsUsd</param>
        /// <param name="newGrandTotalCad">newGrandTotalCad</param>
        /// <param name="newGrandTotalUsd">newGrandTotalUsd</param>
        /// <param name="newState">newState</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        private void UpdateCostingSheet(int costingSheetId, int originalProjectId, string originalName, DateTime originalStartDate, DateTime originalEndDate, decimal originalTotalLabourHoursCad, decimal originalTotalLabourHoursUsd, decimal originalTotalMaterialsCad, decimal originalTotalMaterialsUsd, decimal originalTotalUnitsCad, decimal originalTotalUnitsUsd, decimal originalTotalOtherCostsCad, decimal originalTotalOtherCostsUsd, decimal originalGrandTotalCad, decimal originalGrandTotalUsd, string originalState, bool originalDeleted, int originalCompanyId, decimal originalTotalSubcontractorsCad, decimal originalTotalSubcontractorsUsd, decimal originalGrandRevenue, decimal originalGrandProfit, decimal originalGrandGrossMargin, int newProjectId, string newName, DateTime newStartDate, DateTime newEndDate, decimal newTotalLabourHoursCad, decimal newTotalLabourHoursUsd, decimal newTotalMaterialsCad, decimal newTotalMaterialsUsd, decimal newTotalUnitsCad, decimal newTotalUnitsUsd, decimal newTotalOtherCostsCad, decimal newTotalOtherCostsUsd, decimal newGrandTotalCad, decimal newGrandTotalUsd, string newState, bool newDeleted, int newCompanyId, decimal newTotalSubcontractorsCad, decimal newTotalSubcontractorsUsd, decimal newGrandRevenue, decimal newGrandProfit, decimal newGrandGrossMargin)
        {
            ProjectCostingSheet projectCostingSheet = new ProjectCostingSheet(null);
            projectCostingSheet.UpdateDirect(costingSheetId, originalProjectId, originalName, originalStartDate, originalEndDate, originalTotalLabourHoursCad, originalTotalLabourHoursUsd, originalTotalMaterialsCad, originalTotalMaterialsUsd, originalTotalUnitsCad, originalTotalUnitsUsd, originalTotalOtherCostsCad, originalTotalOtherCostsUsd, originalGrandTotalCad, originalGrandTotalUsd, originalState, originalDeleted, originalCompanyId, originalTotalSubcontractorsCad, originalTotalSubcontractorsUsd, originalGrandRevenue, originalGrandProfit, originalGrandGrossMargin, newProjectId, newName, newStartDate, newEndDate, newTotalLabourHoursCad, newTotalLabourHoursUsd, newTotalMaterialsCad, newTotalMaterialsUsd, newTotalUnitsCad, newTotalUnitsUsd, newTotalOtherCostsCad, newTotalOtherCostsUsd, newGrandTotalCad, newGrandTotalUsd, newState, newDeleted, newCompanyId, newTotalSubcontractorsCad, newTotalSubcontractorsUsd, newGrandRevenue, newGrandProfit, newGrandGrossMargin);
        }



        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>Obtained row</returns>
        private ProjectCostingSheetInformationTDS.BasicInformationRow GetRow(int costingSheetId)
        {
            ProjectCostingSheetInformationTDS.BasicInformationRow row = ((ProjectCostingSheetInformationTDS.BasicInformationDataTable)Table).FindByCostingSheetID(costingSheetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetInformationBasicInformation.GetRow");
            }

            return row;
        }



        /// <summary>
        /// UpdateForReport
        /// </summary>
        private void UpdateForProject()
        {
            foreach (ProjectCostingSheetInformationTDS.BasicInformationRow row in (ProjectCostingSheetInformationTDS.BasicInformationDataTable)Table)
            {
                if (row.GrandRevenue > 0)
                {
                    row.GrandGrossMargin = (row.GrandProfit / row.GrandRevenue) * 100;
                }
                else
                {
                    row.GrandGrossMargin = 0;
                }
            }
        }



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

            ProjectCostingSheetInformationSubcontractorsInformationGateway projectCostingSheetInformationSubcontractorsInformationGateway = new ProjectCostingSheetInformationSubcontractorsInformationGateway(Data);
            projectCostingSheetInformationSubcontractorsInformationGateway.ClearBeforeFill = false;

            ProjectCostingSheetInformationOtherCostsInformationGateway projectCostingSheetInformationOtherCostsInformationGateway = new ProjectCostingSheetInformationOtherCostsInformationGateway(Data);
            projectCostingSheetInformationOtherCostsInformationGateway.ClearBeforeFill = false;

            projectCostingSheetInformationRevenueInformationGateway projectCostingSheetInformationRevenueInformationGateway = new projectCostingSheetInformationRevenueInformationGateway(Data);
            projectCostingSheetInformationRevenueInformationGateway.ClearBeforeFill = false;

            ProjectCostingSheetInformationHotelsInformationGateway projectCostingSheetInformationHotelsInformationGateway = new ProjectCostingSheetInformationHotelsInformationGateway(Data);
            projectCostingSheetInformationHotelsInformationGateway.ClearBeforeFill = false;

            ProjectCostingSheetInformationBondingsInformationGateway projectCostingSheetInformationBondingsInformationGateway = new ProjectCostingSheetInformationBondingsInformationGateway(Data);
            projectCostingSheetInformationBondingsInformationGateway.ClearBeforeFill = false;

            ProjectCostingSheetInformationInsurancesInformationGateway projectCostingSheetInformationInsurancesInformationGateway = new ProjectCostingSheetInformationInsurancesInformationGateway(Data);
            projectCostingSheetInformationInsurancesInformationGateway.ClearBeforeFill = false;

            ProjectCostingSheetInformationOtherCategoryInformationGateway projectCostingSheetInformationOtherCategoryInformationGateway = new ProjectCostingSheetInformationOtherCategoryInformationGateway(Data);
            projectCostingSheetInformationOtherCategoryInformationGateway.ClearBeforeFill = false;

            foreach (ProjectCostingSheetInformationTDS.BasicInformationRow row in (ProjectCostingSheetInformationTDS.BasicInformationDataTable)Table)
            {
                if (row.GrandRevenue > 0)
                {
                    row.GrandGrossMargin = (row.GrandProfit / row.GrandRevenue) * 100;
                }
                else
                {
                    row.GrandGrossMargin = 0;
                }

                projectCostingSheetInformationLabourHoursInformationGateway.LoadByCostingSheetId(row.CostingSheetID, row.COMPANY_ID);
                projectCostingSheetInformationUnitsInformationGateway.LoadByCostingSheetId(row.CostingSheetID, row.COMPANY_ID);
                projectCostingSheetInformationMaterialsInformationGateway.LoadByCostingSheetId(row.CostingSheetID, row.COMPANY_ID);
                projectCostingSheetInformationSubcontractorsInformationGateway.LoadByCostingSheetId(row.CostingSheetID, row.COMPANY_ID);
                projectCostingSheetInformationOtherCostsInformationGateway.LoadByCostingSheetId(row.CostingSheetID, row.COMPANY_ID);
                projectCostingSheetInformationRevenueInformationGateway.LoadByCostingSheetId(row.CostingSheetID, row.COMPANY_ID);

                projectCostingSheetInformationHotelsInformationGateway.LoadByCostingSheetId(row.CostingSheetID, row.COMPANY_ID);
                projectCostingSheetInformationBondingsInformationGateway.LoadByCostingSheetId(row.CostingSheetID, row.COMPANY_ID);
                projectCostingSheetInformationInsurancesInformationGateway.LoadByCostingSheetId(row.CostingSheetID, row.COMPANY_ID);
                projectCostingSheetInformationOtherCategoryInformationGateway.LoadByCostingSheetId(row.CostingSheetID, row.COMPANY_ID);
            }
        }



    }
}