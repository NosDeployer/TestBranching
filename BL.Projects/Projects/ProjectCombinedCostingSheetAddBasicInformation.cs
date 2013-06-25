using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCombinedCostingSheetAddBasicInformation
    /// </summary>
    public class ProjectCombinedCostingSheetAddBasicInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCombinedCostingSheetAddBasicInformation()
            : base("CombinedBasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCombinedCostingSheetAddBasicInformation(DataSet data)
            : base(data, "CombinedBasicInformation")
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
        /// <param name="clientId">clientId</param>
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
        public void Insert(int clientId, string name, DateTime startDate, DateTime endDate, decimal totalLabourHoursCad, decimal totalLabourHoursUsd, decimal totalMaterialsCad, decimal totalMaterialsUsd, decimal totalUnitsCad, decimal totalUnitsUsd, decimal totalOtherCostsCad, decimal totalOtherCostsUsd, decimal grandTotalCad, decimal grandTotalUsd, string state, bool deleted, int companyId, decimal totalSubcontractorsCad, decimal totalSubcontractorsUsd, decimal grandRevenue, decimal grandProfit, decimal grandGrossMargin, string combinedProjects)
        {
            ProjectCostingSheetAddTDS.CombinedBasicInformationRow row = ((ProjectCostingSheetAddTDS.CombinedBasicInformationDataTable)Table).NewCombinedBasicInformationRow();

            row.CostingSheetID = 0;
            row.ClientID = clientId;
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
            row.GrantTotalCostCad = totalLabourHoursCad + totalUnitsCad + totalMaterialsCad + totalOtherCostsCad + totalSubcontractorsCad;
            row.GrantTotalCostUsd = totalLabourHoursUsd + totalUnitsUsd + totalMaterialsUsd + totalOtherCostsUsd + totalSubcontractorsUsd;
            row.State = "In Progress";
            row.GrandRevenue = grandRevenue;
            row.GrandProfit = grandProfit;
            row.GrandGrossMargin = grandGrossMargin;
            row.CombinedProjects = combinedProjects;
            
            ((ProjectCostingSheetAddTDS.CombinedBasicInformationDataTable)Table).AddCombinedBasicInformationRow(row);
        }



        /// <summary>
        /// Save Costing Sheet
        /// </summary>
        /// <param name="companyId">companyId</param>
        public int Save(int companyId)
        {
            int costingSheetId = 0;
            ProjectCostingSheetAddTDS basicInformationChanges = (ProjectCostingSheetAddTDS)Data.GetChanges();

            if (basicInformationChanges.CombinedBasicInformation.Rows.Count > 0)
            {
                foreach (ProjectCostingSheetAddTDS.CombinedBasicInformationRow row in (ProjectCostingSheetAddTDS.CombinedBasicInformationDataTable)basicInformationChanges.CombinedBasicInformation)
                {
                    // Insert new costing sheet
                    if (!row.Deleted)
                    {
                        ProjectCombinedCostingSheet costingSheet = new ProjectCombinedCostingSheet(null);
                        costingSheetId = costingSheet.InsertDirect(row.ClientID, row.Name, row.StartDate, row.EndDate, row.TotalLabourHoursCad, row.TotalLabourHoursUsd, row.TotalMaterialsCad, row.TotalMaterialsUsd, row.TotalUnitsCad, row.TotalUnitsUsd, row.TotalOtherCostsCad, row.TotalOtherCostsUsd, row.GrantTotalCostCad, row.GrantTotalCostUsd, row.State, false, row.COMPANY_ID, row.TotalSubcontractorsCad, row.TotalSubcontractorsUsd, row.GrandRevenue, row.GrandProfit, row.GrandGrossMargin, row.CombinedProjects);
                    }
                }
            }

            return costingSheetId;
        }



    }
}