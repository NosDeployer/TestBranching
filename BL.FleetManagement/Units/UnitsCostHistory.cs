using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitsCostHistory
    /// </summary>
    public class UnitsCostHistory: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsCostHistory()
            : base("LFS_FM_UNIT_COST_HISTORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsCostHistory(DataSet data)
            : base(data, "LFS_FM_UNIT_COST_HISTORY")
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
        /// Insert a new units cost (direct to DB)
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="unitId">unitId</param>
        /// <param name="date">date</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="costCad">costCad</param>
        /// <param name="costUsd">costUsd</param>        
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int costId, int unitId, DateTime date, string unitOfMeasurement, decimal costCad, decimal costUsd, bool deleted, int companyId)
        {
            UnitsCostHistoryGateway unitsCostHistoryGateway = new UnitsCostHistoryGateway(null);
            unitsCostHistoryGateway.Insert(costId, unitId, date, unitOfMeasurement, costCad, costUsd, deleted, companyId);
        }



        /// <summary>
        /// Update units  cost (direct to DB)
        /// </summary>
        /// <param name="originalCostId">originalCostId</param>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalDate">originalDate</param>
        /// <param name="originalUnitOfMeasurement">originalUnitOfMeasurement</param>
        /// <param name="originalCostCad">originalCostCad</param>
        /// <param name="originalCostUsd">originalCostUsd</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>        

        /// <param name="newCostId">newCostId</param>
        /// <param name="newUnitId">newUnitId</param>
        /// <param name="newDate">newDate</param>
        /// <param name="newUnitOfMeasurement">newUnitOfMeasurement</param>
        /// <param name="newCostCad">newCostCad</param>
        /// <param name="newCostUsd">newCostUsd</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalCostId, int originalUnitId, DateTime originalDate, string originalUnitOfMeasurement, decimal originalCostCad, decimal originalCostUsd, bool originalDeleted, int originalCompanyId, int newCostId, int newUnitId, DateTime newDate, string newUnitOfMeasurement, decimal newCostCad, decimal newCostUsd, bool newDeleted, int newCompanyId)
        {
            UnitsCostHistoryGateway unitsCostHistoryGateway = new UnitsCostHistoryGateway(null);
            unitsCostHistoryGateway.Update(originalCostId, originalUnitId, originalDate, originalUnitOfMeasurement, originalCostCad, originalCostUsd, originalDeleted, originalCompanyId, newCostId, newUnitId, newDate, newUnitOfMeasurement, newCostCad, newCostUsd, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="originalCostId">originalCostId</param>    
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        public void DeleteDirect(int originalCostId, int originalUnitId, int originalCompanyId)
        {
            UnitsCostHistoryGateway unitsCostHistoryGateway = new UnitsCostHistoryGateway(null);
            unitsCostHistoryGateway.Delete(originalCostId, originalUnitId, originalCompanyId);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int unitId, int companyId)
        {
            // Delete exceptions           
            UnitsCostHistoryExceptions unitsCostHistoryExceptions = new UnitsCostHistoryExceptions(null);
            unitsCostHistoryExceptions.DeleteAllDirect(unitId, companyId);

            // Delete costs
            UnitsCostHistoryGateway unitsCostHistoryGateway = new UnitsCostHistoryGateway(null);
            unitsCostHistoryGateway.DeleteAll(unitId, companyId);
        }

    }
}
