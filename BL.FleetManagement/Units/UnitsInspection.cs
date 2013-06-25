using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitsInspection
    /// </summary>
    public class UnitsInspection : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsInspection()
            : base("LFS_FM_UNIT_INSPECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsInspection(DataSet data)
            : base(data, "LFS_FM_UNIT_INSPECTION")
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
        /// InsertDirect
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="inspectionId">inspectionId</param>
        /// <param name="date_">date_</param>
        /// <param name="country">country</param>
        /// <param name="state">state</param>
        /// <param name="type">type</param>
        /// <param name="result">result</param>
        /// <param name="cost">cost</param>
        /// <param name="notes">notes</param>
        /// <param name="inspectedBy">inspectedBy</param>
        /// <param name="attach">attach</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int unitId, int inspectionId, DateTime date_, Int64 country, Int64 state, string type, string result, decimal? cost, string notes, string inspectedBy, string attach, bool deleted, int companyId)
        {
            UnitsInspectionGateway unitsInspectionGateway = new UnitsInspectionGateway(null);
            unitsInspectionGateway.Insert(unitId, inspectionId, date_, country, state, type, result, cost, notes, inspectedBy, attach, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalInspectionId">originalInspectionId</param>
        /// <param name="originalDate_">originalDate_</param>
        /// <param name="originalCountry">originalCountry</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalResult">originalResult</param>
        /// <param name="originalCost">originalCost</param>
        /// <param name="originalNotes">originalNotes</param>
        /// <param name="originalInspectedBy">originalInspectedBy</param>
        /// <param name="originalAttach">originalAttach</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newUnitId">newUnitId</param>
        /// <param name="newInspectionId">newInspectionId</param>
        /// <param name="newDate_">newDate_</param>
        /// <param name="newCountry">newCountry</param>
        /// <param name="newState">newState</param>
        /// <param name="newType">newType</param>
        /// <param name="newResult">newResult</param>
        /// <param name="newCost">newCost</param>
        /// <param name="newNotes">newNotes</param>
        /// <param name="newInspectedBy">newInspectedBy</param>
        /// <param name="newAttach">newAttach</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalUnitId, int originalInspectionId, DateTime originalDate_, Int64 originalCountry, Int64 originalState, string originalType, string originalResult, decimal? originalCost, string originalNotes, string originalInspectedBy, string originalAttach, bool originalDeleted, int originalCompanyId, int newUnitId, int newInspectionId, DateTime newDate_, Int64 newCountry, Int64 newState, string newType, string newResult, decimal? newCost, string newNotes, string newInspectedBy, string newAttach, bool newDeleted, int newCompanyId)
        {
            UnitsInspectionGateway unitsInspectionGateway = new UnitsInspectionGateway(null);
            unitsInspectionGateway.Update(originalUnitId, originalInspectionId, originalDate_, originalCountry, originalState, originalType, originalResult, originalCost, originalNotes, originalInspectedBy, originalAttach, originalDeleted, originalCompanyId, newUnitId, newInspectionId, newDate_, newCountry, newState, newType, newResult, newCost, newNotes, newInspectedBy, newAttach, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeletedDirect
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="inspectionId">inspectionId</param>
        /// <param name="companyId">companyId</param>
        public void DeletedDirect(int unitId, int inspectionId, int companyId)
        {
            UnitsInspectionGateway unitsInspectionGateway = new UnitsInspectionGateway(null);
            unitsInspectionGateway.Delete(unitId, inspectionId, companyId);
        }

        

    }
}



