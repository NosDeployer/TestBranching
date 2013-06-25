using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Services
{
    /// <summary>
    /// ServiceNote
    /// </summary>
    public class ServicesNote : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesNote()
            : base("LFS_FM_SERVICE_NOTE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServicesNote(DataSet data)
            : base(data, "LFS_FM_SERVICE_NOTE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new service note (direct to DB)
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <param name="subject">subject</param>
        /// <param name="userId">userId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="note">note</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int serviceId, int refId, string subject, int userId, DateTime dateTime_, string note, int? libraryFilesId, bool deleted, int companyId)
        {
            ServicesNoteGateway servicesNoteGateway = new ServicesNoteGateway(null);
            servicesNoteGateway.Insert( serviceId, refId, subject, userId, dateTime_, note, libraryFilesId, deleted, companyId);
        }



        /// <summary>
        /// Update note (direct to DB)
        /// </summary>
        /// <param name="originalServiceId">originalServiceId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalSubject">originalSubject</param>
        /// <param name="originalUserId">originalUserId</param>
        /// <param name="originalDateTime_">originalDateTime_</param>
        /// <param name="originalNote">originalNote</param>
        /// <param name="originalLibraryFilesId">originalLibraryFilesId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newServiceId">newServiceId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newSubject">newSubject</param>
        /// <param name="newUserId">newUserId</param>
        /// <param name="newDateTime">newDateTime</param>
        /// <param name="newNote">newNote</param>
        /// <param name="newLibraryFilesId">newLibraryFilesId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalServiceId, int originalRefId, string originalSubject, int originalUserId, DateTime originalDateTime_, string originalNote, int? originalLibraryFilesId, bool originalDeleted, int originalCompanyId, int newServiceId, int newRefId, string newSubject, int newUserId, DateTime newDateTime, string newNote, int? newLibraryFilesId, bool newDeleted, int newCompanyId)
        {
            ServicesNoteGateway servicesNoteGateway = new ServicesNoteGateway(null);
            servicesNoteGateway.Update(originalServiceId, originalRefId, originalSubject, originalUserId, originalDateTime_, originalNote, originalLibraryFilesId, originalDeleted, originalCompanyId, newServiceId, newRefId, newSubject, newUserId, newDateTime, newNote, newLibraryFilesId, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int serviceId, int refId, int companyId)
        {
            ServicesNoteGateway servicesNoteGateway = new ServicesNoteGateway(null);
            servicesNoteGateway.Delete(serviceId, refId, companyId);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int serviceId, int companyId)
        {
            ServicesNoteGateway servicesNoteGateway = new ServicesNoteGateway(null);
            servicesNoteGateway.DeleteAll(serviceId, companyId);
        }



    }
}