using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheet
    /// </summary>
    public class ProjectCostingSheet : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheet()
            : base("LFS_PROJECT_COSTING_SHEET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheet(DataSet data)
            : base(data, "LFS_PROJECT_COSTING_SHEET")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert costing sheet
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
        /// <returns>CostingSheetID</returns>
        public int InsertDirect(int projectId, string name, DateTime startDate, DateTime endDate, decimal totalLabourHoursCad, decimal totalLabourHoursUsd, decimal totalMaterialsCad, decimal totalMaterialsUsd, decimal totalUnitsCad, decimal totalUnitsUsd, decimal totalOtherCostsCad, decimal totalOtherCostsUsd, decimal grandTotalCad, decimal grandTotalUsd, string state, bool deleted, int companyId, decimal totalSubcontractorsCad, decimal totalSubcontractorsUsd, decimal grandRevenue, decimal grandProfit, decimal grandGrossMargin)
        {
            // Insert costing sheet and get costing sheet ID
            ProjectCostingSheetGateway projectCostingSheetGateway = new ProjectCostingSheetGateway(null);
            int costingSheetId = projectCostingSheetGateway.Insert(projectId, name, startDate, endDate, totalLabourHoursCad, totalLabourHoursUsd, totalMaterialsCad, totalMaterialsUsd, totalUnitsCad, totalUnitsUsd, totalOtherCostsCad, totalOtherCostsUsd, grandTotalCad, grandTotalUsd, state, deleted, companyId, totalSubcontractorsCad, totalSubcontractorsUsd, grandRevenue, grandProfit, grandGrossMargin);

            return costingSheetId;
        }



        /// <summary>
        /// Update costing sheet
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
        /// <param name="originalTotalSubcontractorsCad">originalTotalSubcontractorsCad</param>
        /// <param name="originalTotalSubcontractorsUsd">originalTotalSubcontractorsUsd</param>
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
        /// <param name="newTotalSubcontractorsCad">newTotalSubcontractorsCad</param>
        /// <param name="newTotalSubcontractorsUsd">newTotalSubcontractorsUsd</param>
        public void UpdateDirect(int costingSheetId, int originalProjectId, string originalName, DateTime originalStartDate, DateTime originalEndDate, decimal originalTotalLabourHoursCad, decimal originalTotalLabourHoursUsd, decimal originalTotalMaterialsCad, decimal originalTotalMaterialsUsd, decimal originalTotalUnitsCad, decimal originalTotalUnitsUsd, decimal originalTotalOtherCostsCad, decimal originalTotalOtherCostsUsd, decimal originalGrandTotalCad, decimal originalGrandTotalUsd, string originalState, bool originalDeleted, int originalCompanyId, decimal originalTotalSubcontractorsCad, decimal originalTotalSubcontractorsUsd, decimal originalGrandRevenue, decimal originalGrandProfit, decimal originalGrandGrossMargin, int newProjectId, string newName, DateTime newStartDate, DateTime newEndDate, decimal newTotalLabourHoursCad, decimal newTotalLabourHoursUsd, decimal newTotalMaterialsCad, decimal newTotalMaterialsUsd, decimal newTotalUnitsCad, decimal newTotalUnitsUsd, decimal newTotalOtherCostsCad, decimal newTotalOtherCostsUsd, decimal newGrandTotalCad, decimal newGrandTotalUsd, string newState, bool newDeleted, int newCompanyId, decimal newTotalSubcontractorsCad, decimal newTotalSubcontractorsUsd, decimal newGrandRevenue, decimal newGrandProfit, decimal newGrandGrossMargin)
        {
            ProjectCostingSheetGateway projectCostingSheetGateway = new ProjectCostingSheetGateway(null);
            projectCostingSheetGateway.Update(costingSheetId, originalProjectId, originalName, originalStartDate, originalEndDate, originalTotalLabourHoursCad, originalTotalLabourHoursUsd, originalTotalMaterialsCad, originalTotalMaterialsUsd, originalTotalUnitsCad, originalTotalUnitsUsd, originalTotalOtherCostsCad, originalTotalOtherCostsUsd, originalGrandTotalCad, originalGrandTotalUsd, originalState, originalDeleted, originalCompanyId, originalTotalSubcontractorsCad, originalTotalSubcontractorsUsd, originalGrandRevenue, originalGrandProfit, originalGrandGrossMargin, newProjectId, newName, newStartDate, newEndDate, newTotalLabourHoursCad, newTotalLabourHoursUsd, newTotalMaterialsCad, newTotalMaterialsUsd, newTotalUnitsCad, newTotalUnitsUsd, newTotalOtherCostsCad, newTotalOtherCostsUsd, newGrandTotalCad, newGrandTotalUsd, newState, newDeleted, newCompanyId, newTotalSubcontractorsCad, newTotalSubcontractorsUsd, newGrandRevenue, newGrandProfit, newGrandGrossMargin);
        }



        /// <summary>
        /// UpdateStateDirect
        /// </summary>
        /// <param name="originalcostingSheetId">originalcostingSheetId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newState">newState</param>
        public void UpdateStateDirect(int originalcostingSheetId, int originalCompanyId, string newState)
        {
            ProjectCostingSheetGateway projectCostingSheetGateway = new ProjectCostingSheetGateway(null);
            projectCostingSheetGateway.UpdateState(originalcostingSheetId, originalCompanyId, newState);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int costingSheetId, int companyId)
        {
            ProjectCostingSheetGateway projectCostingSheetGateway = new ProjectCostingSheetGateway(null);
            projectCostingSheetGateway.Delete(costingSheetId, companyId);            
        }

        

    }
}