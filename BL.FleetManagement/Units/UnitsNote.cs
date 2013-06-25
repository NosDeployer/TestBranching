using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitsNote
    /// </summary>
    public class UnitsNote : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsNote()
            : base("LFS_FM_UNIT_NOTE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsNote(DataSet data)
            : base(data, "LFS_FM_UNIT_NOTE")
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
        /// Insert a new unit (direct to DB)
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <param name="subject">subject</param>
        /// <param name="userId">userId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="note">note</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        public void InsertDirect(int unitId, int refId, string subject, int userId, DateTime dateTime_, string note, bool deleted, int companyId, int? libraryFilesId)
        {
            UnitsNoteGateway unitsNoteGateway = new UnitsNoteGateway(null);
            unitsNoteGateway.Insert(unitId, refId, subject, userId, dateTime_, note, deleted, companyId, libraryFilesId);
        }



        /// <summary>
        /// Update unit note (direct to DB)
        /// </summary>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalSubject">originalSubject</param>
        /// <param name="originalUserId">originalUserId</param>
        /// <param name="originalDateTime_">originalDateTime_</param>
        /// <param name="originalNote">originalNote</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalLibraryFilesId">originalLibraryFilesId</param>
        /// 
        /// <param name="newUnitId">newUnitId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newSubject">newSubject</param>
        /// <param name="newUserId">newUserId</param>
        /// <param name="newDateTime">newDateTime</param>
        /// <param name="newNote">newNote</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newLibraryFilesId">newLibraryFilesId</param>
        public void UpdateDirect(int originalUnitId, int originalRefId, string originalSubject, int originalUserId, DateTime originalDateTime_, string originalNote, bool originalDeleted, int originalCompanyId, int? originalLibraryFilesId, int newUnitId, int newRefId, string newSubject, int newUserId, DateTime newDateTime, string newNote, bool newDeleted, int newCompanyId, int? newLibraryFilesId)
        {
            UnitsNoteGateway unitsNoteGateway = new UnitsNoteGateway(null);
            unitsNoteGateway.Update(originalUnitId, originalRefId, originalSubject, originalUserId, originalDateTime_, originalNote, originalDeleted, originalCompanyId, originalLibraryFilesId, newUnitId, newRefId, newSubject, newUserId, newDateTime, newNote, newDeleted, newCompanyId, newLibraryFilesId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int unitId, int refId, int companyId)
        {
            UnitsNoteGateway unitsNoteGateway = new UnitsNoteGateway(null);
            unitsNoteGateway.Delete(unitId, refId, companyId);
        }



    }
}