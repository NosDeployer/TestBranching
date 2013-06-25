using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkPointRepairsRepair
    /// </summary>
    public class WorkPointRepairsRepair : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkPointRepairsRepair()
            : base("LFS_WORK_POINTREPAIRS_REPAIR")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkPointRepairsRepair(DataSet data)
            : base(data, "LFS_WORK_POINTREPAIRS_REPAIR")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WorkTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <param name="type">type</param>
        /// <param name="reamDistance">reamDistance</param>
        /// <param name="reamDate">reamDate</param>
        /// <param name="linerDistance">linerDistance</param>
        /// <param name="direction">direction</param>
        /// <param name="reinstates">reinstates</param>
        /// <param name="ltmh">ltmh</param>
        /// <param name="vtmh">vtmh</param>
        /// <param name="distance">distance</param>
        /// <param name="size_">size_</param>
        /// <param name="installDate">installDate</param>
        /// <param name="mhShot">mhShot</param>
        /// <param name="groutDistance">groutDistance</param>
        /// <param name="groutDate">groutDate</param>
        /// <param name="approval">approval</param>
        /// <param name="extraRepair">extraRepair</param>
        /// <param name="cancelled">cancelled</param>
        /// <param name="comments">comments</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="defectQualifier">defectQualifer</param>
        /// <param name="defectDetails">defectDetails</param>
        /// <param name="length">length</param>
        public void InsertDirect(int workId, string repairPointId, string type, string reamDistance, DateTime? reamDate, string linerDistance, string direction, int? reinstates, string ltmh, string vtmh, string distance, string size_, DateTime? installDate, string mhShot, string groutDistance, DateTime? groutDate, string approval, bool extraRepair, bool cancelled, string comments, bool deleted, int companyId, string defectQualifier, string defectDetails, string length, DateTime? reinstateDate)
        {
            WorkPointRepairsRepairGateway workPointRepairsRepairGateway = new WorkPointRepairsRepairGateway(Data);
            workPointRepairsRepairGateway.Insert(workId, repairPointId, type, reamDistance, reamDate, linerDistance, direction, reinstates, ltmh, vtmh, distance, size_, installDate, mhShot, groutDistance, groutDate, approval, extraRepair, cancelled, comments, deleted, companyId, defectQualifier, defectDetails, length, reinstateDate);
        }



        /// <summary>
        /// Updatedirect
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalRepairPointId">originalRepairPointId</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalReamDistance">originalReamDistance</param>
        /// <param name="originalReamDate">originalReamDate</param>
        /// <param name="originalLinerDistance">originalLinerDistance</param>
        /// <param name="originalDirection">originalDirection</param>
        /// <param name="originalReinstates">originalReinstates</param>
        /// <param name="originalLtmh">originalLtmh</param>
        /// <param name="originalVtmh">originalVtmh</param>
        /// <param name="originalDistance">originalDistance</param>
        /// <param name="originalSize_">originalSize_</param>
        /// <param name="originalInstallDate">originalInstallDate</param>
        /// <param name="originalMhShot">originalMhShot</param>
        /// <param name="originalGroutDistance">originalGroutDistance</param>
        /// <param name="originalGroutDate">originalGroutDate</param>
        /// <param name="originalApproval">originalApproval</param>
        /// <param name="originalExtraRepair">originalExtraRepair</param>
        /// <param name="originalCancelled">originalCancelled</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDefectQualifier">originalDefectQualifier</param>
        /// <param name="originalDefectDetails">originalDefetDetails</param>
        /// <param name="originalLength">originalLength</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newRepairPointId">newRepairPointId</param>
        /// <param name="newType">newType</param>
        /// <param name="newReamDistance">newReamDistance</param>
        /// <param name="newReamDate">newReamDate</param>
        /// <param name="newLinerDistance">newLinerDistance</param>
        /// <param name="newDirection">newDirection</param>
        /// <param name="newReinstates">newReinstates</param>
        /// <param name="newLtmh">newLtmh</param>
        /// <param name="newVtmh">newVtmh</param>
        /// <param name="newDistance">newDistance</param>
        /// <param name="newSize_">newSize_</param>
        /// <param name="newInstallDate">newInstallDate</param>
        /// <param name="newMhShot">newMhShot</param>
        /// <param name="newGroutDistance">newGroutDistance</param>
        /// <param name="newGroutDate">newGroutDate</param>
        /// <param name="newApproval">newApproval</param>
        /// <param name="newExtraRepair">newExtraRepair</param>
        /// <param name="newCancelled">newCancelled</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDefectQualifierf">newDefectQualifier</param>
        /// <param name="newDefectDetails">newDefectDetails</param>
        /// <param name="newLength">newLength</param>
        public void Updatedirect(int originalWorkId, string originalRepairPointId, string originalType, string originalReamDistance, DateTime? originalReamDate, string originalLinerDistance, string originalDirection, int? originalReinstates, string originalLtmh, string originalVtmh, string originalDistance, string originalSize_, DateTime? originalInstallDate, string originalMhShot, string originalGroutDistance, DateTime? originalGroutDate, string originalApproval, bool originalExtraRepair, bool originalCancelled, string originalComments, bool originalDeleted, int originalCompanyId, string originalDefectQualifier, string originalDefectDetails, string originalLength, int newWorkId, string newRepairPointId, string newType, string newReamDistance, DateTime? newReamDate, string newLinerDistance, string newDirection, int? newReinstates, string newLtmh, string newVtmh, string newDistance, string newSize_, DateTime? newInstallDate, string newMhShot, string newGroutDistance, DateTime? newGroutDate, string newApproval, bool newExtraRepair, bool newCancelled, string newComments, bool newDeleted, int newCompanyId, string newDefectQualifierf, string newDefectDetails, string newLength, DateTime? originalReinstateDate, DateTime? newReinstateDate)
        {
            WorkPointRepairsRepairGateway workPointRepairsRepairGateway = new WorkPointRepairsRepairGateway(Data);
            workPointRepairsRepairGateway.Update(originalWorkId, originalRepairPointId, originalType, originalReamDistance, originalReamDate, originalLinerDistance, originalDirection, originalReinstates, originalLtmh, originalVtmh, originalDistance, originalSize_, originalInstallDate, originalMhShot, originalGroutDistance, originalGroutDate, originalApproval, originalExtraRepair, originalCancelled, originalComments, originalDeleted, originalCompanyId, originalDefectQualifier, originalDefectDetails, originalLength, newWorkId, newRepairPointId, newType, newReamDistance, newReamDate, newLinerDistance, newDirection, newReinstates, newLtmh, newVtmh, newDistance, newSize_, newInstallDate, newMhShot, newGroutDistance, newGroutDate, newApproval, newExtraRepair, newCancelled, newComments, newDeleted, newCompanyId, newDefectQualifierf, newDefectDetails, newLength, originalReinstateDate, newReinstateDate);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, string repairPointId, int companyId)
        {
            WorkPointRepairsRepairGateway workPointRepairsRepairGateway = new WorkPointRepairsRepairGateway(null);
            workPointRepairsRepairGateway.Delete(workId, repairPointId, companyId);
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int workId, int companyId)
        {
            WorkPointRepairsRepairGateway workPointRepairsRepairGateway = new WorkPointRepairsRepairGateway();
            workPointRepairsRepairGateway.LoadByWorkId(workId, companyId);

            foreach (WorkTDS.LFS_WORK_POINT_REPAIRS_REPAIRRow row in (WorkTDS.LFS_WORK_POINT_REPAIRS_REPAIRDataTable)workPointRepairsRepairGateway.Table)
            {
                workPointRepairsRepairGateway.Delete(workId, row.RepairPointID, companyId);
            }
        }        



    }
}