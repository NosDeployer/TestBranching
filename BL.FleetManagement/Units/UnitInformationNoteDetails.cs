using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitInformationNoteDetails
    /// </summary>
    public class UnitInformationNoteDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitInformationNoteDetails()
            : base("NoteInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitInformationNoteDetails(DataSet data)
            : base(data, "NoteInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadByUnitId(int unitId, int companyId)
        {
            UnitInformationNoteDetailsGateway unitInformationNoteDetailsGateway = new UnitInformationNoteDetailsGateway(Data);
            unitInformationNoteDetailsGateway.LoadAllByUnitId(unitId, companyId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="subject">subject</param>
        /// <param name="userId">userId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="note">note</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        public void Insert(int unitId, string subject, int userId, DateTime dateTime_, string note, bool deleted, int companyId, bool inDatabase, int? libraryFilesId)
        {
            UnitInformationTDS.NoteInformationRow row = ((UnitInformationTDS.NoteInformationDataTable)Table).NewNoteInformationRow();

            row.UnitID = unitId;
            row.RefID = GetNewRefId();
            row.Subject = subject;
            row.UserID = userId;
            row.DateTime_ = dateTime_;
            row.Note = note;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            if (libraryFilesId.HasValue) row.LIBRARY_FILES_ID = libraryFilesId.Value; else row.SetLIBRARY_FILES_IDNull();

            ((UnitInformationTDS.NoteInformationDataTable)Table).AddNoteInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <param name="subject">subject</param>
        /// <param name="note">note</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        public void Update(int unitId, int refId, string subject, string note, int? libraryFilesId)
        {
            UnitInformationTDS.NoteInformationRow row = GetRow(unitId, refId);

            row.Subject = subject;
            row.Note = note;
            if (libraryFilesId.HasValue) row.LIBRARY_FILES_ID = libraryFilesId.Value; else row.SetLIBRARY_FILES_IDNull();
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        public void Delete(int unitId, int refId)
        {
            UnitInformationTDS.NoteInformationRow row = GetRow(unitId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="workId">workId</param>
        public void DeleteAll(int workId)
        {
            foreach (UnitInformationTDS.NoteInformationRow row in (UnitInformationTDS.NoteInformationDataTable)Table)
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
            UnitInformationTDS unitInformationChanges = (UnitInformationTDS)Data.GetChanges();

            if (unitInformationChanges.NoteInformation.Rows.Count > 0)
            {
                UnitInformationNoteDetailsGateway unitInformationNoteDetailsGateway = new UnitInformationNoteDetailsGateway(unitInformationChanges);

                foreach (UnitInformationTDS.NoteInformationRow row in (UnitInformationTDS.NoteInformationDataTable)unitInformationChanges.NoteInformation)
                {
                    // Insert new Notes 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        int? libraryFilesId = null; if (!row.IsLIBRARY_FILES_IDNull()) libraryFilesId = row.LIBRARY_FILES_ID;
                        UnitsNote unitsNote = new UnitsNote(null);
                        unitsNote.InsertDirect(row.UnitID, row.RefID, row.Subject, row.UserID, row.DateTime_, row.Note, row.Deleted, row.COMPANY_ID, libraryFilesId);
                    }
                    
                    // Update Notes
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int unitId = row.UnitID;
                        int refId = row.RefID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // Original values
                        string originalSubject = unitInformationNoteDetailsGateway.GetSubjectOriginal(unitId, refId);
                        int originalUserId = unitInformationNoteDetailsGateway.GetUserIdOriginal(unitId, refId);
                        DateTime originalDateTime_ = unitInformationNoteDetailsGateway.GetDateTime_Original(unitId, refId);
                        string originalNote = unitInformationNoteDetailsGateway.GetNoteOriginal(unitId, refId);
                        int? originalLibraryFilesId = unitInformationNoteDetailsGateway.GetLibraryFilesIdOriginal(unitId, refId);

                        // New values
                        string newSubject = unitInformationNoteDetailsGateway.GetSubject(unitId, refId);
                        string newNote = unitInformationNoteDetailsGateway.GetNote(unitId, refId);
                        int? newLibraryFilesId = unitInformationNoteDetailsGateway.GetLibraryFilesId(unitId, refId);
                        
                        UnitsNote unitsNote = new UnitsNote(null);
                        unitsNote.UpdateDirect(unitId, refId, originalSubject, originalUserId, originalDateTime_, originalNote, originalDeleted, originalCompanyId, originalLibraryFilesId, unitId, refId, newSubject, originalUserId, originalDateTime_, newNote, originalDeleted, originalCompanyId, newLibraryFilesId);
                    }

                    // Delete note 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        UnitsNote unitsNote = new UnitsNote(null);
                        unitsNote.DeleteDirect(row.UnitID, row.RefID, row.COMPANY_ID);
                    }
                }
            }
        }



        /// <summary>
        /// UpdateLibraryFilesId. Update the Library Files Id
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <param name="originalFileName">originalFileName</param>
        /// <param name="fileName">fileName</param>
        public void UpdateLibraryFilesId(int unitId, int refId, int? libraryFilesId, string originalFileName, string fileName)
        {
            UnitInformationTDS.NoteInformationRow row = GetRow(unitId, refId);

            if (libraryFilesId.HasValue) row.LIBRARY_FILES_ID = (int)libraryFilesId; else row.SetLIBRARY_FILES_IDNull();
            row.ORIGINAL_FILENAME = originalFileName;
            row.FILENAME = fileName;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        ///

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private UnitInformationTDS.NoteInformationRow GetRow(int unitId, int refId)
        {
            UnitInformationTDS.NoteInformationRow row = ((UnitInformationTDS.NoteInformationDataTable)Table).FindByUnitIDRefID(unitId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Units.ServiceInformationServiceNote.GetRow");
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

            foreach (UnitInformationTDS.NoteInformationRow row in (UnitInformationTDS.NoteInformationDataTable)Table)
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

            foreach (UnitInformationTDS.NoteInformationRow row in (UnitInformationTDS.NoteInformationDataTable)Table)
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