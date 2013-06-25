using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitsCostHistoryExceptions
    /// </summary>
    public class UnitsCostHistoryExceptions: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsCostHistoryExceptions()
            : base("LFS_FM_UNIT_COST_HISTORY_EXCEPTIONS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsCostHistoryExceptions(DataSet data)
            : base(data, "LFS_FM_UNIT_COST_HISTORY_EXCEPTIONS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new units (direct to DB)
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <param name="unitId">unitId</param>
        /// <param name="work_">work_</param>        
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="costCad">costCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int costId, int refId, int unitId, string work_, string unitOfMeasurement, decimal costCad, decimal costUsd, bool deleted, int companyId)
        {
            UnitsCostHistoryExceptionsGateway unitsCostHistoryExceptionsGateway = new UnitsCostHistoryExceptionsGateway(null);
            unitsCostHistoryExceptionsGateway.Insert(costId, refId, unitId, work_,  unitOfMeasurement, costCad, costUsd, deleted, companyId);
        }



        /// <summary>
        /// Update units  cost(direct to DB)
        /// </summary>
        /// <param name="originalCostId">originalCostId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalMaterialId">originalMaterialId</param>
        /// <param name="originalWork">originalWork</param>        
        /// <param name="originalUnitOfMeasurement">originalUnitOfMeasurement</param>
        /// <param name="originalCostCad">originalCostCad</param>
        /// <param name="originalCostUsd">originalCostUsd</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>        

        /// <param name="newCostId">newCostId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newMaterialId">newMaterialId</param>
        /// <param name="newWork">newWork</param>        
        /// <param name="newUnitOfMeasurement">newUnitOfMeasurement</param>
        /// <param name="newCostCad">newCostCad</param>
        /// <param name="newCostUsd">newCostUsd</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalCostId, int originalRefId, int originalMaterialId, string originalWork, string originalUnitOfMeasurement, decimal originalCostCad, decimal originalCostUsd, bool originalDeleted, int originalCompanyId, int newCostId, int newRefId, int newMaterialId, string newWork, string newUnitOfMeasurement, decimal newCostCad, decimal newCostUsd, bool newDeleted, int newCompanyId)
        {
            UnitsCostHistoryExceptionsGateway unitsCostHistoryExceptionsGateway = new UnitsCostHistoryExceptionsGateway(null);
            unitsCostHistoryExceptionsGateway.Update(originalCostId, originalRefId, originalMaterialId, originalWork, originalUnitOfMeasurement, originalCostCad, originalCostUsd, originalDeleted, originalCompanyId, newCostId, newRefId, newMaterialId, newWork, newUnitOfMeasurement, newCostCad, newCostUsd, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int costId, int refId, int companyId)
        {
            UnitsCostHistoryExceptionsGateway unitsCostHistoryExceptionsGateway = new UnitsCostHistoryExceptionsGateway(null);
            unitsCostHistoryExceptionsGateway.Delete(costId, refId,  companyId);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int unitId, int companyId)
        {
            UnitsCostHistoryExceptionsGateway unitsCostHistoryExceptionsGateway = new UnitsCostHistoryExceptionsGateway(null);
            unitsCostHistoryExceptionsGateway.DeleteAll(unitId,  companyId);
        }

    }
}

