using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Materials;

namespace LiquiForce.LFSLive.BL.Resources.Materials
{
    /// <summary>
    /// MaterialsCostHistoryExceptions
    /// </summary>
    public class MaterialsCostHistoryExceptions: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsCostHistoryExceptions()
            : base("LFS_RESOURCES_MATERIAL_COST_HISTORY_EXCEPTIONS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsCostHistoryExceptions(DataSet data)
            : base(data, "LFS_RESOURCES_MATERIAL_COST_HISTORY_EXCEPTIONS")
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
        /// Insert a new materials (direct to DB)
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <param name="materialId">materialId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="costCad">costCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int costId, int refId, int materialId, string work_, string function_, string unitOfMeasurement, decimal costCad, decimal costUsd, bool deleted, int companyId)
        {
            MaterialsCostHistoryExceptionsGateway materialsCostHistoryExceptionsGateway = new MaterialsCostHistoryExceptionsGateway(null);
            materialsCostHistoryExceptionsGateway.Insert(costId, refId, materialId, work_, function_, unitOfMeasurement, costCad, costUsd, deleted, companyId);
        }



        /// <summary>
        /// Update materials  cost(direct to DB)
        /// </summary>
        /// <param name="originalCostId">originalCostId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalMaterialId">originalMaterialId</param>
        /// <param name="originalWork">originalWork</param>
        /// <param name="originalFunction">originalFunction</param>
        /// <param name="originalUnitOfMeasurement">originalUnitOfMeasurement</param>
        /// <param name="originalCostCad">originalCostCad</param>
        /// <param name="originalCostUsd">originalCostUsd</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>        

        /// <param name="newCostId">newCostId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newMaterialId">newMaterialId</param>
        /// <param name="newWork">newWork</param>
        /// <param name="newFunction">newFunction</param>
        /// <param name="newUnitOfMeasurement">newUnitOfMeasurement</param>
        /// <param name="newCostCad">newCostCad</param>
        /// <param name="newCostUsd">newCostUsd</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalCostId, int originalRefId, int originalMaterialId, string originalWork, string originalFunction, string originalUnitOfMeasurement, decimal originalCostCad, decimal originalCostUsd, bool originalDeleted, int originalCompanyId, int newCostId, int newRefId, int newMaterialId, string newWork, string newFunction, string newUnitOfMeasurement, decimal newCostCad, decimal newCostUsd, bool newDeleted, int newCompanyId)
        {
            MaterialsCostHistoryExceptionsGateway materialsCostHistoryExceptionsGateway = new MaterialsCostHistoryExceptionsGateway(null);
            materialsCostHistoryExceptionsGateway.Update(originalCostId, originalRefId, originalMaterialId, originalWork, originalFunction, originalUnitOfMeasurement, originalCostCad, originalCostUsd, originalDeleted, originalCompanyId, newCostId, newRefId, newMaterialId, newWork, newFunction, newUnitOfMeasurement, newCostCad, newCostUsd, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int costId, int refId, int companyId)
        {
            MaterialsCostHistoryExceptionsGateway materialsCostHistoryExceptionsGateway = new MaterialsCostHistoryExceptionsGateway(null);
            materialsCostHistoryExceptionsGateway.Delete(costId, refId,  companyId);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int materialId, int companyId)
        {
            MaterialsCostHistoryExceptionsGateway materialsCostHistoryExceptionsGateway = new MaterialsCostHistoryExceptionsGateway(null);
            materialsCostHistoryExceptionsGateway.DeleteAll(materialId,  companyId);
        }

    }
}
