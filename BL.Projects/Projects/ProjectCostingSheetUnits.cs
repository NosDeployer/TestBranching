using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetUnits
    /// </summary>
    public class ProjectCostingSheetUnits : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetUnits()
            : base("LFS_PROJECT_COSTING_SHEET_UNITS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetUnits(DataSet data)
            : base(data, "LFS_PROJECT_COSTING_SHEET_UNITS")
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
        /// <param name="work_">work_</param>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
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
        /// <param name="function_">function_</param>
        public void InsertDirect(int costingSheetId, string work_, int unitId, int refId, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, DateTime startDate, DateTime endDate, string function_)
        {
            // Insert costing sheet Units
            ProjectCostingSheetUnitsGateway projectCostingSheetUnitsGateway = new ProjectCostingSheetUnitsGateway(null);
            projectCostingSheetUnitsGateway.Insert(costingSheetId, work_, unitId, refId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, deleted, companyId, startDate, endDate, function_);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
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
        /// <param name="originalFunction_">originalFunction_</param>
        ///  
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
        /// <param name="newFunction_">newFunction_</param>
        public void UpdateDirect(int costingSheetId, string work_, int unitId, int refId, string originalUnitOfMeasurement, double originalQuantity, decimal originalCostCad, decimal originalTotalCostCad, decimal originalCostUsd, decimal originalTotalCostUsd, bool originalDeleted, int originalCompanyId, DateTime originalStartDate, DateTime originalEndDate, string originalFunction_, string newUnitOfMeasurement, double newQuantity, decimal newCostCad, decimal newTotalCostCad, decimal newCostUsd, decimal newTotalCostUsd, bool newDeleted, int newCompanyId, DateTime newStartDate, DateTime newEndDate, string newFunction_)
        {
            ProjectCostingSheetUnitsGateway projectCostingSheetUnitsGateway = new ProjectCostingSheetUnitsGateway(null);
            projectCostingSheetUnitsGateway.Update(costingSheetId, work_, unitId, refId, originalUnitOfMeasurement, originalQuantity, originalCostCad, originalTotalCostCad, originalCostUsd, originalTotalCostUsd, originalDeleted, originalCompanyId, originalStartDate, originalEndDate, originalFunction_, newUnitOfMeasurement, newQuantity, newCostCad, newTotalCostCad, newCostUsd, newTotalCostUsd, newDeleted, newCompanyId, newStartDate, newEndDate, newFunction_);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int costingSheetId, int companyId)
        {
            ProjectCostingSheetUnitsGateway projectCostingSheetUnitsGateway = new ProjectCostingSheetUnitsGateway(null);
            projectCostingSheetUnitsGateway.DeleteAll(costingSheetId, companyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int costingSheetId, string work_, int unitId, int refId, int companyId)
        {
            ProjectCostingSheetUnitsGateway projectCostingSheetUnitsGateway = new ProjectCostingSheetUnitsGateway(null);
            projectCostingSheetUnitsGateway.Delete(costingSheetId, work_, unitId, refId, companyId);
        }



    }
}