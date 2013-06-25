using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCombinedCostingSheetOtherCosts
    /// </summary>
    public class ProjectCombinedCostingSheetOtherCosts : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCombinedCostingSheetOtherCosts()
            : base("LFS_PROJECT_COMBINED_COSTING_SHEET_OTHER_COSTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCombinedCostingSheetOtherCosts(DataSet data)
            : base(data, "LFS_PROJECT_COMBINED_COSTING_SHEET_OTHER_COSTS")
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
        /// InsertDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="description">description</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void InsertDirect(int costingSheetId, int refId, string work_, string function_, string description, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, DateTime startDate, DateTime endDate, int projectId)
        {
            // Insert costing sheet Other Costs
            ProjectCombinedCostingSheetOtherCostsGateway projectCostingSheetOtherCostsGateway = new ProjectCombinedCostingSheetOtherCostsGateway(null);
            projectCostingSheetOtherCostsGateway.Insert(costingSheetId, refId, work_, function_, description, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, deleted, companyId, startDate, endDate, projectId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <param name="originalWork_">originalWork_</param>
        /// <param name="originalFunction_">originalFunction_</param>
        /// <param name="originalDescription">originalDescription</param>
        /// <param name="originalUnitOfMeasurement">originalUnitOfMeasurement</param>
        /// <param name="originalQuantity">originalQuantity</param>
        /// <param name="originalCostCad">originalCostCad</param>
        /// <param name="originalTotalCostCad">originalTotalCostCad</param>
        /// <param name="originalCostUsd">originalCostUsd</param>
        /// <param name="originalTotalCostUsd">originalTotalCostUsd</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalStartDate">originalStartDate</param>
        /// <param name="originalEndDate">originalEndDate</param>
        /// 
        /// <param name="newWork_">newWork_</param>
        /// <param name="newFunction_">newFunction_</param>
        /// <param name="newDescription">newDescription</param>
        /// <param name="newUnitOfMeasurement">newUnitOfMeasurement</param>
        /// <param name="newQuantity">newQuantity</param>
        /// <param name="newCostCad">newCostCad</param>
        /// <param name="newTotalCostCad">newTotalCostCad</param>
        /// <param name="newCostUsd">newCostUsd</param>
        /// <param name="newTotalCostUsd">newTotalCostUsd</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newStartDate">newStartDate</param>
        /// <param name="newEndDate">newEndDate</param>
        public void UpdateDirect(int costingSheetId, int refId, string originalWork_, string originalFunction_, string originalDescription, string originalUnitOfMeasurement, double originalQuantity, decimal originalCostCad, decimal originalTotalCostCad, decimal originalCostUsd, decimal originalTotalCostUsd, bool originalDeleted, int originalCompanyId, DateTime originalStartDate, DateTime originalEndDate, string newWork_, string newFunction_, string newDescription, string newUnitOfMeasurement, double newQuantity, decimal newCostCad, decimal newTotalCostCad, decimal newCostUsd, decimal newTotalCostUsd, bool newDeleted, int newCompanyId, DateTime newStartDate, DateTime newEndDate)
        {
            ProjectCombinedCostingSheetOtherCostsGateway projectCostingSheetOtherCostsGateway = new ProjectCombinedCostingSheetOtherCostsGateway(null);
            projectCostingSheetOtherCostsGateway.Update(costingSheetId, refId, originalWork_, originalFunction_, originalDescription, originalUnitOfMeasurement, originalQuantity, originalCostCad, originalTotalCostCad, originalCostUsd, originalTotalCostUsd, originalDeleted, originalCompanyId, originalStartDate, originalEndDate, newWork_, newFunction_, newDescription, newUnitOfMeasurement, newQuantity, newCostCad, newTotalCostCad, newCostUsd, newTotalCostUsd, newDeleted, newCompanyId, newStartDate, newEndDate);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int costingSheetId, int companyId)
        {
            ProjectCombinedCostingSheetOtherCostsGateway projectCostingSheetOtherCostsGateway = new ProjectCombinedCostingSheetOtherCostsGateway(null);
            projectCostingSheetOtherCostsGateway.DeleteAll(costingSheetId, companyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int costingSheetId, int refId, int companyId)
        {
            ProjectCombinedCostingSheetOtherCostsGateway projectCostingSheetOtherCostsGateway = new ProjectCombinedCostingSheetOtherCostsGateway(null);
            projectCostingSheetOtherCostsGateway.Delete(costingSheetId, refId, companyId);
        }



    }
}