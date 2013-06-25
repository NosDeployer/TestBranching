using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.CWP.DatabaseGateway;

namespace LiquiForce.LFSLive.CWP.BL
{
    /// <summary>
    /// LFSRecordJuntionLiner
    /// </summary>
    public class LFSRecordJuntionLiner : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LFSRecordJuntionLiner()
            : base("LFS_JUNCTION_LINER")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LFSRecordJuntionLiner(DataSet data)
            : base(data, "LFS_JUNCTION_LINER")
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
        /// Insert a new row (direct to DB)
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="detailId">detailId</param>
        /// <param name="mn">mn</param>
        /// <param name="distanceFromUSMH">distanceFromUSMH</param>
        /// <param name="confirmedLatSize">confirmedLatSize</param>
        /// <param name="lateralMaterial">lateralMaterial</param>
        /// <param name="sharedLateral">sharedLateral</param>
        /// <param name="cleanoutRequired">cleanoutRequired</param>
        /// <param name="pitRequired">pitRequired</param>
        /// <param name="mhShot">mhShot</param>
        /// <param name="mainConnection">mainConnection</param>
        /// <param name="transition">transition</param>
        /// <param name="cleanoutInstalled">cleanoutInstalled</param>
        /// <param name="pitInstalled">pitInstalled</param>
        /// <param name="cleanoutGrouted">cleanoutGrouted</param>
        /// <param name="cleanoutCored">cleanoutCored</param>
        /// <param name="prepCompleted">prepCompleted</param>
        /// <param name="measuredLatLength">measuredLatLength</param>
        /// <param name="measurementsTakenBy">measurementsTakenBy</param>
        /// <param name="linerInstalled">linerInstalled</param>
        /// <param name="finalVideo">finalVideo</param>
        /// <param name="restorationComplete">restorationComplete</param>
        /// <param name="linerOrdered">linerOrdered</param>
        /// <param name="linerInStock">linerInStock</param>
        /// <param name="deleted">deleted</param>
        /// <param name="linerPrice">linerPrice</param>
        /// <param name="comments">comments</param>
        /// <param name="archived">archived</param>
        public void InsertDirect(Guid id, int refId, int companyId, string detailId, string mn,  double? distanceFromUSMH, string confirmedLatSize, string lateralMaterial, string sharedLateral, bool cleanoutRequired, bool pitRequired, bool mhShot, string mainConnection, string transition,  bool cleanoutInstalled, bool pitInstalled, bool cleanoutGrouted, bool cleanoutCored, DateTime? prepCompleted, string measuredLatLength, string measurementsTakenBy, DateTime? linerInstalled,  DateTime? finalVideo, bool restorationComplete, bool linerOrdered, bool linerInStock, decimal? linerPrice, string comments, bool deleted, bool archived)
        {
            LFSRecordJuntionLinerGateway lfsRecordJuntionLinerGateway = new LFSRecordJuntionLinerGateway();
            lfsRecordJuntionLinerGateway.Insert(id, refId, companyId, detailId, mn, distanceFromUSMH, confirmedLatSize, lateralMaterial, sharedLateral, cleanoutRequired, pitRequired, mhShot, mainConnection, transition, cleanoutInstalled, pitInstalled, cleanoutGrouted, cleanoutCored, prepCompleted, measuredLatLength, measurementsTakenBy, linerInstalled, finalVideo, restorationComplete, linerOrdered, linerInStock, linerPrice, comments, deleted, archived);
        }



        /// <summary>
        /// Update a new repair (direct to DB)
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCOMPANY_ID</param>        
        /// <param name="originalDetailId">originalDetailId</param>
        /// <param name="originalMn">originalMn</param>
        /// <param name="originalDistanceFromUSMH">originalDistanceFromUSMH</param>
        /// <param name="originalConfirmedLatSize">originalConfirmedLatSize</param>
        /// <param name="originalLateralMaterial">originalLateralMaterial</param>
        /// <param name="originalSharedLateral">originalSharedLateral</param>
        /// <param name="originalCleanoutRequired">originalCleanoutRequired</param>
        /// <param name="originalPitRequired">originalPitRequired</param>
        /// <param name="originalMHShot">originalMHShot</param>
        /// <param name="originalMainConnection">originalMainConnection</param>
        /// <param name="originalTransition">originalTransition</param>
        /// <param name="originalCleanoutInstalled">originalCleanoutInstalled</param>
        /// <param name="originalPitInstalled">originalPitInstalled</param>
        /// <param name="originalCleanoutGrouted">originalCleanoutGrouted</param>
        /// <param name="originalCleanoutCored">originalCleanoutCored</param>
        /// <param name="originalPrepCompleted">originalPrepCompleted</param>
        /// <param name="originalMeasuredLatLength">originalMeasuredLatLength</param>
        /// <param name="originalMeasurementsTakenBy">originalMeasurementsTakenBy</param>
        /// <param name="originalLinerInstalled">originalLinerInstalled</param>
        /// <param name="originalFinalVideo">originalFinalVideo</param>
        /// <param name="originalRestorationComplete">originalRestorationComplete</param>
        /// <param name="originalLinerOrdered">originalLinerOrdered</param>
        /// <param name="originalLinerInStock">originalLinerInStock</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalLinerPrice">originalLinerPrice</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalArchived">originaArchived</param>
        ///  
        /// <param name="newId">newId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newCompanyId">newCompanyId</param>        
        /// <param name="newDetailId">newDetailId</param>
        /// <param name="newMn">newMn</param>
        /// <param name="newDistanceFromUSMH">newDistanceFromUSMH</param>
        /// <param name="newConfirmedLatSize">newConfirmedLatSize</param>
        /// <param name="newLateralMaterial">newLateralMaterial</param>
        /// <param name="newSharedLateral">newSharedLateral</param>
        /// <param name="newCleanoutRequired">newCleanoutRequired</param>
        /// <param name="newPitRequired">newPitRequired</param>
        /// <param name="newMHShot">newMHShot</param>
        /// <param name="newMainConnection">newMainConnection</param>
        /// <param name="newTransition">newTransition</param>
        /// <param name="newCleanoutInstalled">newCleanoutInstalled</param>
        /// <param name="newPitInstalled">newPitInstalled</param>
        /// <param name="newCleanoutGrouted">newCleanoutGrouted</param>
        /// <param name="newCleanoutCored">newCleanoutCored</param>
        /// <param name="newPrepCompleted">newPrepCompleted</param>
        /// <param name="newMeasuredLatLength">newMeasuredLatLength</param>
        /// <param name="newMeasurementsTakenBy">newMeasurementsTakenBy</param>
        /// <param name="newLinerInstalled">newLinerInstalled</param>
        /// <param name="newFinalVideo">newFinalVideo</param>
        /// <param name="newRestorationComplete">newRestorationComplete</param>
        /// <param name="newLinerOrdered">newLinerOrdered</param>
        /// <param name="newLinerInStock">newLinerInStock</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newLinerPrice">newLinerPrice</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newArchived">newArchived</param>
        public void UpdateDirect(Guid originalId, int originalRefId, int originalCompanyId, string originalDetailId, string originalMn, double? originalDistanceFromUSMH, string originalConfirmedLatSize, string originalLateralMaterial, string originalSharedLateral, bool originalCleanoutRequired, bool originalPitRequired, bool originalMHShot, string originalMainConnection, string originalTransition, bool originalCleanoutInstalled, bool originalPitInstalled, bool originalCleanoutGrouted, bool originalCleanoutCored, DateTime? originalPrepCompleted, string originalMeasuredLatLength, string originalMeasurementsTakenBy, DateTime? originalLinerInstalled, DateTime? originalFinalVideo, bool originalRestorationComplete, bool originalLinerOrdered, bool originalLinerInStock, decimal? originalLinerPrice, string originalComments, bool originalDeleted, bool originalArchived, Guid newId, int newRefId, int newCompanyId, string newDetailId, string newMn, double? newDistanceFromUSMH, string newConfirmedLatSize, string newLateralMaterial, string newSharedLateral, bool newCleanoutRequired, bool newPitRequired, bool newMHShot, string newMainConnection, string newTransition, bool newCleanoutInstalled, bool newPitInstalled, bool newCleanoutGrouted, bool newCleanoutCored, DateTime? newPrepCompleted, string newMeasuredLatLength, string newMeasurementsTakenBy, DateTime? newLinerInstalled, DateTime? newFinalVideo, bool newRestorationComplete, bool newLinerOrdered, bool newLinerInStock, decimal? newLinerPrice, string newComments, bool newDeleted, bool newArchived)
        {
            LFSRecordJuntionLinerGateway lfsRecordJuntionLinerGateway = new LFSRecordJuntionLinerGateway();
            lfsRecordJuntionLinerGateway.Update(originalId, originalRefId, originalCompanyId, originalDetailId, originalMn, originalDistanceFromUSMH, originalConfirmedLatSize, originalLateralMaterial, originalSharedLateral, originalCleanoutRequired, originalPitRequired, originalMHShot, originalMainConnection, originalTransition, originalCleanoutInstalled, originalPitInstalled, originalCleanoutGrouted, originalCleanoutCored, originalPrepCompleted, originalMeasuredLatLength, originalMeasurementsTakenBy, originalLinerInstalled, originalFinalVideo, originalRestorationComplete, originalLinerOrdered, originalLinerInStock, originalLinerPrice, originalComments, originalDeleted, originalArchived, newId, newRefId, newCompanyId, newDetailId, newMn, newDistanceFromUSMH, newConfirmedLatSize, newLateralMaterial, newSharedLateral, newCleanoutRequired, newPitRequired, newMHShot, newMainConnection, newTransition, newCleanoutInstalled, newPitInstalled, newCleanoutGrouted, newCleanoutCored, newPrepCompleted, newMeasuredLatLength, newMeasurementsTakenBy, newLinerInstalled, newFinalVideo, newRestorationComplete, newLinerOrdered, newLinerInStock, newLinerPrice, newComments, newDeleted, newArchived);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(Guid id, int refId, int companyId)
        {
            LFSRecordJuntionLinerGateway lfsRecordJuntionLinerGateway = new LFSRecordJuntionLinerGateway();
            lfsRecordJuntionLinerGateway.Delete(id, refId, companyId);
        }

        

    }
}
