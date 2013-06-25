using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Materials;

namespace LiquiForce.LFSLive.BL.Resources.Materials
{
    /// <summary>
    /// MaterialsCostHistory
    /// </summary>
    public class MaterialsCostHistory: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsCostHistory()
            : base("LFS_RESOURCES_MATERIAL_COST_HISTORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsCostHistory(DataSet data)
            : base(data, "LFS_RESOURCES_MATERIAL_COST_HISTORY")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MaterialsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new materials cost (direct to DB)
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="materialId">materialId</param>
        /// <param name="date">date</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="costCad">costCad</param>
        /// <param name="costUsd">costUsd</param>        
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int costId, int materialId, DateTime date, string unitOfMeasurement, decimal costCad, decimal costUsd, bool deleted, int companyId)
        {
            MaterialsCostHistoryGateway materialsCostHistoryGateway = new MaterialsCostHistoryGateway(null);
            materialsCostHistoryGateway.Insert(costId, materialId, date, unitOfMeasurement, costCad, costUsd, deleted, companyId);
        }



        /// <summary>
        /// Update materials  cost (direct to DB)
        /// </summary>
        /// <param name="originalCostId">originalCostId</param>
        /// <param name="originalMaterialId">originalMaterialId</param>
        /// <param name="originalDate">originalDate</param>
        /// <param name="originalUnitOfMeasurement">originalUnitOfMeasurement</param>
        /// <param name="originalCostCad">originalCostCad</param>
        /// <param name="originalCostUsd">originalCostUsd</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>        

        /// <param name="newCostId">newCostId</param>
        /// <param name="newMaterialId">newMaterialId</param>
        /// <param name="newDate">newDate</param>
        /// <param name="newUnitOfMeasurement">newUnitOfMeasurement</param>
        /// <param name="newCostCad">newCostCad</param>
        /// <param name="newCostUsd">newCostUsd</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalCostId, int originalMaterialId, DateTime originalDate, string originalUnitOfMeasurement, decimal originalCostCad, decimal originalCostUsd, bool originalDeleted, int originalCompanyId, int newCostId, int newMaterialId, DateTime newDate, string newUnitOfMeasurement, decimal newCostCad, decimal newCostUsd, bool newDeleted, int newCompanyId)
        {
            MaterialsCostHistoryGateway materialsCostHistoryGateway = new MaterialsCostHistoryGateway(null);
            materialsCostHistoryGateway.Update(originalCostId, originalMaterialId, originalDate, originalUnitOfMeasurement, originalCostCad, originalCostUsd, originalDeleted, originalCompanyId, newCostId, newMaterialId, newDate, newUnitOfMeasurement, newCostCad, newCostUsd, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="originalCostId">originalCostId</param>
        /// <param name="originalMaterialId">originalMaterialId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        public void DeleteDirect(int originalCostId, int originalMaterialId, int originalCompanyId)
        {
            MaterialsCostHistoryGateway materialsCostHistoryGateway = new MaterialsCostHistoryGateway(null);
            materialsCostHistoryGateway.Delete(originalCostId, originalMaterialId, originalCompanyId);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int materialId, int companyId)
        {
            // Delete exceptions           
            MaterialsCostHistoryExceptions materialsCostHistoryExceptions = new MaterialsCostHistoryExceptions(null);
            materialsCostHistoryExceptions.DeleteAllDirect(materialId, companyId);

            // Delete costs
            MaterialsCostHistoryGateway materialsCostHistoryGateway = new MaterialsCostHistoryGateway(null);
            materialsCostHistoryGateway.DeleteAll(materialId, companyId);
        }

    }
}
