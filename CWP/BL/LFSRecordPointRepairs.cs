using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.CWP.DatabaseGateway;


namespace LiquiForce.LFSLive.CWP.BL
{    
    /// <summary>
    /// LFSRecordPointRepairs
    /// </summary>
    public class LFSRecordPointRepairs : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LFSRecordPointRepairs()
            : base("LFS_POINT_REPAIRS")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LFSRecordPointRepairs(DataSet data)
            : base(data, "LFS_POINT_REPAIRS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new TDSLFSRecord();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Insert a new repair (direct to DB)
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="detailId">detailId</param>
        /// <param name="repairSize">repairSize</param>
        /// <param name="installDate">installDate</param>
        /// <param name="distance">distance</param>
        /// <param name="cost">cost</param>
        /// <param name="reinstates">reinstates</param>
        /// <param name="LTAtMH">LTAtMH</param>
        /// <param name="VTAtMH">VTAtMH</param>
        /// <param name="linerDistance">linerDistance</param>
        /// <param name="direction">direction</param>
        /// <param name="mhShot">mhShot</param>
        /// <param name="comments">comments</param>
        /// <param name="deleted">deleted</param>
        /// <param name="extraRepair">extraRepair</param>
        /// <param name="cancelled">cancelled</param>
        /// <param name="approved">approved</param>
        /// <param name="notApproved">notApproved</param>
        /// <param name="archived">archived</param>
        public void InsertDirect(Guid id, int refId, int companyId, string detailId, string repairSize, DateTime? installDate, string distance, decimal? cost, int? reinstates, string LTAtMH, string VTAtMH, string linerDistance, string direction, string mhShot, string comments, bool deleted, bool extraRepair, bool cancelled, bool approved, bool notApproved, bool archived)
        {
            LFSRecordPointRepairsGateway lfsRecordPointRepairsGateway = new LFSRecordPointRepairsGateway();
            lfsRecordPointRepairsGateway.Insert(id, refId, companyId, detailId, repairSize, installDate, distance, cost, reinstates, LTAtMH, VTAtMH, linerDistance, direction, mhShot, comments, deleted, extraRepair, cancelled, approved, notApproved, archived);
        }



        /// <summary>
        /// Update a new repair (direct to DB)
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDetailId">originalDetailId</param>
        /// <param name="originalRepairSize">originalRepairSize</param>
        /// <param name="originalInstallDate">originalInstallDate</param>
        /// <param name="originalDistance">originalDistance</param>
        /// <param name="originalCost">originalCost</param>
        /// <param name="originalReinstates">originalReinstates</param>
        /// <param name="originalLTAtMH">originalLTAtMH</param>
        /// <param name="originalVTAtMH">originalVTAtMH</param>
        /// <param name="originalLinerDistance">originalLinerDistance</param>
        /// <param name="originalDirection">originalDirection</param>
        /// <param name="originalMhShot">originalMhShot</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalExtraRepair">originalExtraRepair</param>
        /// <param name="originalCancelled">originalCancelled</param>
        /// <param name="originalApproved">originalApproved</param>
        /// <param name="originalNotApproved">originalNotApproved</param>
        /// <param name="originalArchived">originalArchived</param>
        /// 
        /// <param name="newId">newId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDetailId">newDetailId</param>
        /// <param name="newRepairSize">newRepairSize</param>
        /// <param name="newInstallDate">newInstallDate</param>
        /// <param name="newDistance">newDistance</param>
        /// <param name="newCost">newCost</param>
        /// <param name="newReinstates">newReinstates</param>
        /// <param name="newLTAtMH">newLTAtMH</param>
        /// <param name="newVTAtMH">newVTAtMH</param>
        /// <param name="newLinerDistance">newLinerDistance</param>
        /// <param name="newDirection">newDirection</param>
        /// <param name="newMhShot">newMhShot</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newExtraRepair">newExtraRepair</param>
        /// <param name="newCancelled">newCancelled</param>
        /// <param name="newApproved">newApproved</param>
        /// <param name="newNotApproved">newNotApproved</param>
        /// <param name="newArchived">newArchived</param>
        public void UpdateDirect(Guid originalId, int originalRefId, int originalCompanyId, string originalDetailId, string originalRepairSize, DateTime? originalInstallDate, string originalDistance, decimal? originalCost, int? originalReinstates, string originalLTAtMH, string originalVTAtMH, string originalLinerDistance, string originalDirection, string originalMhShot, string originalComments, bool originalDeleted, bool originalExtraRepair, bool originalCancelled, bool originalApproved, bool originalNotApproved, bool originalArchived, Guid newId, int newRefId, int newCompanyId, string newDetailId, string newRepairSize, DateTime? newInstallDate, string newDistance, decimal? newCost, int? newReinstates, string newLTAtMH, string newVTAtMH, string newLinerDistance, string newDirection, string newMhShot, string newComments, bool newDeleted, bool newExtraRepair, bool newCancelled, bool newApproved, bool newNotApproved, bool newArchived)
        {
            LFSRecordPointRepairsGateway lfsRecordPointRepairsGateway = new LFSRecordPointRepairsGateway();
            lfsRecordPointRepairsGateway.Update(originalId, originalRefId, originalCompanyId, originalDetailId, originalRepairSize, originalInstallDate, originalDistance, originalCost, originalReinstates, originalLTAtMH, originalVTAtMH, originalLinerDistance, originalDirection, originalMhShot, originalComments, originalDeleted, originalExtraRepair, originalCancelled, originalApproved, originalNotApproved, originalArchived, newId, newRefId, newCompanyId,  newDetailId,  newRepairSize, newInstallDate, newDistance, newCost, newReinstates, newLTAtMH, newVTAtMH, newLinerDistance, newDirection, newMhShot, newComments, newDeleted, newExtraRepair, newCancelled, newApproved, newNotApproved, newArchived);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(Guid id, int refId, int companyId)
        {
            LFSRecordPointRepairsGateway lfsRecordPointRepairsGateway = new LFSRecordPointRepairsGateway();
            lfsRecordPointRepairsGateway.Delete(id, refId, companyId);
        }


    }
}
