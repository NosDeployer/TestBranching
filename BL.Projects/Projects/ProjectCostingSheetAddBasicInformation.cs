using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddBasicInformation
    /// </summary>
    public class ProjectCostingSheetAddBasicInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetAddBasicInformation()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetAddBasicInformation(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetAddTDS();
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //
        
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="name">name</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
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
        /// <param name="state">state</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="totalSubcontractorsCad">totalSubcontractorsCad</param>
        /// <param name="totalSubcontractorsUsd">totalSubcontractorsUsd</param>
        public void Insert(int projectId, string name, DateTime startDate, DateTime endDate, decimal totalLabourHoursCad, decimal totalLabourHoursUsd, decimal totalMaterialsCad, decimal totalMaterialsUsd, decimal totalUnitsCad, decimal totalUnitsUsd, decimal totalOtherCostsCad, decimal totalOtherCostsUsd, decimal grandTotalCad, decimal grandTotalUsd, string state, bool deleted, int companyId, decimal totalSubcontractorsCad, decimal totalSubcontractorsUsd, decimal grandRevenue, decimal grandProfit, decimal grandGrossMargin, decimal totalHotels, decimal totalBondings, decimal totalInsurances, decimal totalOtherCategory, string month)
        {
            ProjectCostingSheetAddTDS.BasicInformationRow row = ((ProjectCostingSheetAddTDS.BasicInformationDataTable)Table).NewBasicInformationRow();

            row.CostingSheetID = 0;
            row.ProjectID = projectId;
            row.Name = name;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.TotalLabourHoursCad = totalLabourHoursCad;
            row.TotalLabourHoursUsd = totalLabourHoursUsd;
            row.TotalMaterialsCad = totalMaterialsCad;
            row.TotalMaterialsUsd = totalMaterialsUsd;
            row.TotalUnitsCad = totalUnitsCad;
            row.TotalUnitsUsd = totalUnitsUsd;
            row.TotalOtherCostsCad = totalOtherCostsCad;
            row.TotalOtherCostsUsd = totalOtherCostsUsd;
            row.GrantTotalCostCad = grandTotalCad;
            row.GrantTotalCostUsd = grandTotalUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.TotalSubcontractorsCad = totalSubcontractorsCad;
            row.TotalSubcontractorsUsd = totalSubcontractorsUsd;
            row.TotalHotelCosts = totalHotels;
            row.TotalBondingCosts = totalBondings;
            row.TotalInsuranceCosts = totalInsurances;
            row.TotalOtherCategoryCosts = totalOtherCategory;
            row.GrantTotalCostCad = totalLabourHoursCad + totalUnitsCad + totalMaterialsCad + totalOtherCostsCad + totalSubcontractorsCad + totalHotels + totalBondings + totalInsurances + totalOtherCategory;
            row.GrantTotalCostUsd = totalLabourHoursUsd + totalUnitsUsd + totalMaterialsUsd + totalOtherCostsUsd + totalSubcontractorsUsd + totalHotels + totalBondings + totalInsurances + totalOtherCategory;
            row.State = "In Progress";
            row.GrandRevenue = grandRevenue;
            row.GrandProfit = grandProfit;
            row.GrandGrossMargin = grandGrossMargin;
            row.Month = month;

            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            row.ProjectName = projectGateway.GetName(projectId);

            int clientId = projectGateway.GetClientID(projectId);
            CompaniesGateway companiesGateway = new CompaniesGateway();
            companiesGateway.LoadAllByCompaniesId(clientId, companyId);
            row.ClientName = companiesGateway.GetName(clientId);
            
            ((ProjectCostingSheetAddTDS.BasicInformationDataTable)Table).AddBasicInformationRow(row);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="name">name</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
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
        /// <param name="state">state</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="totalSubcontractorsCad">totalSubcontractorsCad</param>
        /// <param name="totalSubcontractorsUsd">totalSubcontractorsUsd</param>
        public void Insert2(int costingSheetId, int projectId, string name, DateTime startDate, DateTime endDate, decimal totalLabourHoursCad, decimal totalLabourHoursUsd, decimal totalMaterialsCad, decimal totalMaterialsUsd, decimal totalUnitsCad, decimal totalUnitsUsd, decimal totalOtherCostsCad, decimal totalOtherCostsUsd, decimal grandTotalCad, decimal grandTotalUsd, string state, bool deleted, int companyId, decimal totalSubcontractorsCad, decimal totalSubcontractorsUsd, decimal grandRevenue, decimal grandProfit, decimal grandGrossMargin, decimal totalHotels, decimal totalBondings, decimal totalInsurances, decimal totalOtherCategory, string month)
        {
            ProjectCostingSheetAddTDS.BasicInformationRow row = ((ProjectCostingSheetAddTDS.BasicInformationDataTable)Table).NewBasicInformationRow();

            row.CostingSheetID = costingSheetId;
            row.ProjectID = projectId;
            row.Name = name;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.TotalLabourHoursCad = totalLabourHoursCad;
            row.TotalLabourHoursUsd = totalLabourHoursUsd;
            row.TotalMaterialsCad = totalMaterialsCad;
            row.TotalMaterialsUsd = totalMaterialsUsd;
            row.TotalUnitsCad = totalUnitsCad;
            row.TotalUnitsUsd = totalUnitsUsd;
            row.TotalOtherCostsCad = totalOtherCostsCad;
            row.TotalOtherCostsUsd = totalOtherCostsUsd;
            row.GrantTotalCostCad = grandTotalCad;
            row.GrantTotalCostUsd = grandTotalUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.TotalSubcontractorsCad = totalSubcontractorsCad;
            row.TotalSubcontractorsUsd = totalSubcontractorsUsd;
            row.TotalHotelCosts = totalHotels;
            row.TotalBondingCosts = totalBondings;
            row.TotalInsuranceCosts = totalInsurances;
            row.TotalOtherCategoryCosts = totalOtherCategory;
            row.GrantTotalCostCad = totalLabourHoursCad + totalUnitsCad + totalMaterialsCad + totalOtherCostsCad + totalSubcontractorsCad + totalHotels + totalBondings + totalInsurances + totalOtherCategory;
            row.GrantTotalCostUsd = totalLabourHoursUsd + totalUnitsUsd + totalMaterialsUsd + totalOtherCostsUsd + totalSubcontractorsUsd + totalHotels + totalBondings + totalInsurances + totalOtherCategory;
            row.State = "In Progress";
            row.GrandRevenue = grandRevenue;
            row.GrandProfit = grandProfit;
            row.GrandGrossMargin = grandGrossMargin;
            row.Month = month;

            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            row.ProjectName = projectGateway.GetName(projectId);

            int clientId = projectGateway.GetClientID(projectId);
            CompaniesGateway companiesGateway = new CompaniesGateway();
            companiesGateway.LoadAllByCompaniesId(clientId, companyId);
            row.ClientName = companiesGateway.GetName(clientId);

            ((ProjectCostingSheetAddTDS.BasicInformationDataTable)Table).AddBasicInformationRow(row);
        }



        /// <summary>
        /// Save Costing Sheet
        /// </summary>
        /// <param name="companyId">companyId</param>
        public int Save(int companyId)
        {
            int costingSheetId = 0;
            ProjectCostingSheetAddTDS basicInformationChanges = (ProjectCostingSheetAddTDS)Data.GetChanges();

            if (basicInformationChanges.BasicInformation.Rows.Count > 0)
            {
                foreach (ProjectCostingSheetAddTDS.BasicInformationRow row in (ProjectCostingSheetAddTDS.BasicInformationDataTable)basicInformationChanges.BasicInformation)
                {
                    // Insert new costing sheet
                    if (!row.Deleted)
                    {
                        ProjectCostingSheet costingSheet = new ProjectCostingSheet(null);
                        costingSheetId = costingSheet.InsertDirect(row.ProjectID, row.Name, row.StartDate, row.EndDate, row.TotalLabourHoursCad, row.TotalLabourHoursUsd, row.TotalMaterialsCad, row.TotalMaterialsUsd, row.TotalUnitsCad, row.TotalUnitsUsd, row.TotalOtherCostsCad, row.TotalOtherCostsUsd, row.GrantTotalCostCad, row.GrantTotalCostUsd, row.State, false, row.COMPANY_ID, row.TotalSubcontractorsCad, row.TotalSubcontractorsUsd, row.GrandRevenue, row.GrandProfit, row.GrandGrossMargin);
                    }
                }
            }

            return costingSheetId;
        }



    }
}