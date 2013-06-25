using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Services
{
    /// <summary>
    /// ServiceInformationServiceNote
    /// </summary>
    public class ServiceInformationServiceNote : TableModule
    {
       // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceInformationServiceNote()
            : base("NoteInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServiceInformationServiceNote(DataSet data)
            : base(data, "NoteInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServiceInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByServiceId
        /// </summary>
        /// <param name="serviceId">serviceId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadByServiceId(int serviceId, int companyId)
        {
            ServiceInformationServiceNoteGateway serviceInformationServiceNoteGateway = new ServiceInformationServiceNoteGateway(Data);
            serviceInformationServiceNoteGateway.LoadAllByServiceId(serviceId, companyId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="subject">subject</param>
        /// <param name="userId">userId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="note">note</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inServiceNoteDatabase">inServiceNoteDatabase</param>
        public void Insert(int serviceId, string subject, int userId, DateTime dateTime_, string note, int? libraryFilesId, bool deleted, int companyId, bool inServiceNoteDatabase)
        {
            ServiceInformationTDS.NoteInformationRow row = ((ServiceInformationTDS.NoteInformationDataTable)Table).NewNoteInformationRow();

            row.ServiceID = serviceId;
            row.RefID = GetNewRefId();
            row.Subject = subject;
            row.UserID = userId;
            row.DateTime_ = dateTime_;
            row.Note = note;
            if (libraryFilesId.HasValue) row.LIBRARY_FILES_ID = (int)libraryFilesId; else row.SetLIBRARY_FILES_IDNull();
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InServiceNoteDatabase = inServiceNoteDatabase;

            ((ServiceInformationTDS.NoteInformationDataTable)Table).AddNoteInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <param name="subject">subject</param>
        /// <param name="note">note</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        public void Update(int serviceId, int refId, string subject, string note, int? libraryFilesId)
        {
            ServiceInformationTDS.NoteInformationRow row = GetRow(serviceId, refId);

            row.Subject = subject;
            row.Note = note;
            if (libraryFilesId.HasValue) row.LIBRARY_FILES_ID = (int)libraryFilesId; else row.SetLIBRARY_FILES_IDNull();
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        public void Delete(int serviceId, int refId)
        {
            ServiceInformationTDS.NoteInformationRow row = GetRow(serviceId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        public void DeleteAll(int serviceId)
        {
            foreach (ServiceInformationTDS.NoteInformationRow row in (ServiceInformationTDS.NoteInformationDataTable)Table)
            {
                row.Deleted = true;
            }
        }



        /// <summary>
        /// Save all notes to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            ServiceInformationTDS serviceInformationChanges = (ServiceInformationTDS)Data.GetChanges();

            if (serviceInformationChanges != null)
            {
                if (serviceInformationChanges.NoteInformation.Rows.Count > 0)
                {
                    ServiceInformationServiceNoteGateway serviceInformationServiceNoteGateway = new ServiceInformationServiceNoteGateway(serviceInformationChanges);

                    foreach (ServiceInformationTDS.NoteInformationRow row in (ServiceInformationTDS.NoteInformationDataTable)serviceInformationChanges.NoteInformation)
                    {
                        // Insert new notes 
                        if ((!row.Deleted) && (!row.InServiceNoteDatabase))
                        {
                            int? libraryFilesId = null; if (!row.IsLIBRARY_FILES_IDNull()) libraryFilesId = row.LIBRARY_FILES_ID;
                            ServicesNote servicesNote = new ServicesNote(null);
                            servicesNote.InsertDirect(row.ServiceID, row.RefID, row.Subject, row.UserID, row.DateTime_, row.Note, libraryFilesId, row.Deleted, row.COMPANY_ID);
                        }

                        // Update notes
                        if ((!row.Deleted) && (row.InServiceNoteDatabase))
                        {
                            int serviceId = row.ServiceID;
                            int refId = row.RefID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            // original values
                            string originalSubject = serviceInformationServiceNoteGateway.GetSubjectOriginal(serviceId, refId);
                            int originalUserId = serviceInformationServiceNoteGateway.GetUserIdOriginal(serviceId, refId);
                            DateTime originalDateTime_ = serviceInformationServiceNoteGateway.GetDateTime_Original(serviceId, refId);
                            string originalNote = serviceInformationServiceNoteGateway.GetNoteOriginal(serviceId, refId);
                            int? originalLibraryFilesId = null; if (serviceInformationServiceNoteGateway.GetLibraryFilesIdOriginal(serviceId, refId).HasValue) originalLibraryFilesId = serviceInformationServiceNoteGateway.GetLibraryFilesIdOriginal(serviceId, refId);

                            // new values
                            string newSubject = serviceInformationServiceNoteGateway.GetSubject(serviceId, refId);
                            string newNote = serviceInformationServiceNoteGateway.GetNote(serviceId, refId);
                            int? newLibraryFilesId = null; if (serviceInformationServiceNoteGateway.GetLibraryFilesId(serviceId, refId).HasValue) newLibraryFilesId = serviceInformationServiceNoteGateway.GetLibraryFilesId(serviceId, refId);

                            ServicesNote servicesNote = new ServicesNote(null);
                            servicesNote.UpdateDirect(serviceId, refId, originalSubject, originalUserId, originalDateTime_, originalNote, originalLibraryFilesId, originalDeleted, originalCompanyId, serviceId, refId, newSubject, originalUserId, originalDateTime_, newNote, newLibraryFilesId, originalDeleted, originalCompanyId);
                        }

                        // Deleted notes 
                        if ((row.Deleted) && (row.InServiceNoteDatabase))
                        {
                            ServicesNote servicesNote = new ServicesNote(null);
                            servicesNote.DeleteDirect(row.ServiceID, row.RefID, row.COMPANY_ID);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// UpdateLibraryFilesId. Update the Library Files Id
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <param name="originalFileName">originalFileName</param>
        /// <param name="fileName">fileName</param>
        public void UpdateLibraryFilesId(int serviceId, int refId, int? libraryFilesId, string originalFileName, string fileName)
        {
            ServiceInformationTDS.NoteInformationRow row = GetRow(serviceId, refId);

            if (libraryFilesId.HasValue) row.LIBRARY_FILES_ID = (int)libraryFilesId; else row.SetLIBRARY_FILES_IDNull();
            row.ORIGINAL_FILENAME = originalFileName;
            row.FILENAME = fileName;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private ServiceInformationTDS.NoteInformationRow GetRow(int serviceId, int refId)
        {
            ServiceInformationTDS.NoteInformationRow row = ((ServiceInformationTDS.NoteInformationDataTable)Table).FindByServiceIDRefID(serviceId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Services.ServiceInformationServiceNote.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>RefID</returns>
        private int GetNewRefId()
        {
            int newRefId = 0;

            foreach (ServiceInformationTDS.NoteInformationRow row in (ServiceInformationTDS.NoteInformationDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }



        /// <summary>
        /// GetLastRefId
        /// </summary>
        /// <returns>Last ID</returns>
        public int GetLastRefId()
        {
            int newRefId = 1;

            foreach (ServiceInformationTDS.NoteInformationRow row in (ServiceInformationTDS.NoteInformationDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            return newRefId;
        }



    }
}