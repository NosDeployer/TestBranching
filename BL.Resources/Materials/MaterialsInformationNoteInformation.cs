using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Materials;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.Resources.Materials
{
    /// <summary>
    /// MaterialsInformationNoteInformation
    /// </summary>
    public class MaterialsInformationNoteInformation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsInformationNoteInformation()
            : base("NoteInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsInformationNoteInformation(DataSet data)
            : base(data, "NoteInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MaterialsInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllByMaterialId
        /// </summary>
        /// <param name="materialId">materialId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadAllByMaterialId(int materialId, int companyId)
        {
            MaterialsInformationNoteInformationGateway materialsInformationNoteInformationGateway = new MaterialsInformationNoteInformationGateway(Data);
            materialsInformationNoteInformationGateway.LoadAllByMaterialId(materialId, companyId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="subject">subject</param>
        /// <param name="userId">userId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="note">note</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(int materialId, string subject, int userId, DateTime dateTime_, string note, bool deleted, int companyId, bool inDatabase)
        {
            MaterialsInformationTDS.NoteInformationRow row = ((MaterialsInformationTDS.NoteInformationDataTable)Table).NewNoteInformationRow();

            row.MaterialID = materialId;
            row.RefID = GetNewRefId();
            row.Subject = subject;
            row.UserID = userId;
            row.DateTime_ = dateTime_;
            row.Note = note;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;

            ((MaterialsInformationTDS.NoteInformationDataTable)Table).AddNoteInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        /// <param name="subject">subject</param>
        /// <param name="note">note</param>
        public void Update(int materialId, int refId, string subject, string note)
        {
            MaterialsInformationTDS.NoteInformationRow row = GetRow(materialId, refId);

            row.Subject = subject;
            row.Note = note;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        public void Delete(int materialId, int refId)
        {
            MaterialsInformationTDS.NoteInformationRow row = GetRow(materialId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="materialId">materialId</param>
        public void DeleteAll(int materialId)
        {
            foreach (MaterialsInformationTDS.NoteInformationRow row in (MaterialsInformationTDS.NoteInformationDataTable)Table)
            {
                row.Deleted = true;
            }
        }



        /// <summary>
        /// Save all materials to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            MaterialsInformationTDS materialInformationChanges = (MaterialsInformationTDS)Data.GetChanges();

            if (materialInformationChanges.NoteInformation.Rows.Count > 0)
            {
                MaterialsInformationNoteInformationGateway materialsInformationNoteInformationGateway = new MaterialsInformationNoteInformationGateway(materialInformationChanges);

                foreach (MaterialsInformationTDS.NoteInformationRow row in (MaterialsInformationTDS.NoteInformationDataTable)materialInformationChanges.NoteInformation)
                {
                    // Insert new Notes 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        MaterialsNotes materialsNotes = new MaterialsNotes(null);
                        materialsNotes.InsertDirect(row.MaterialID, row.RefID, row.Subject, row.UserID, row.DateTime_, row.Note, row.Deleted, row.COMPANY_ID);
                    }

                    // Update Notes
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int materialId = row.MaterialID;
                        int refId = row.RefID;
                        bool originalDeleted = row.Deleted;
                        int originalCompanyId = companyId;

                        // original values
                        string originalSubject = materialsInformationNoteInformationGateway.GetSubjectOriginal(materialId, refId);
                        int originalUserId = materialsInformationNoteInformationGateway.GetUserIdOriginal(materialId, refId);
                        DateTime originalDateTime_ = materialsInformationNoteInformationGateway.GetDateTime_Original(materialId, refId);
                        string originalNote = materialsInformationNoteInformationGateway.GetNoteOriginal(materialId, refId);

                        // new values
                        string newSubject = materialsInformationNoteInformationGateway.GetSubject(materialId, refId);
                        string newNote = materialsInformationNoteInformationGateway.GetNote(materialId, refId);

                        MaterialsNotes materialsNotes = new MaterialsNotes(null);
                        materialsNotes.UpdateDirect(materialId, refId, originalSubject, originalUserId, originalDateTime_, originalNote, originalDeleted, originalCompanyId, materialId, refId, newSubject, originalUserId, originalDateTime_, newNote, originalDeleted, originalCompanyId);
                    }

                    // Deleted notes 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        MaterialsNotes materialsNotes = new MaterialsNotes(null);
                        materialsNotes.DeleteDirect(row.MaterialID, row.RefID, row.COMPANY_ID);
                    }
                }
            }
        }






        //// ////////////////////////////////////////////////////////////////////////
        //// PRIVATE METHODS
        ////

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private MaterialsInformationTDS.NoteInformationRow GetRow(int materialId, int refId)
        {
            MaterialsInformationTDS.NoteInformationRow row = ((MaterialsInformationTDS.NoteInformationDataTable)Table).FindByMaterialIDRefID(materialId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Resources.MaterialInformationNoteInformation.GetRow");
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

            foreach (MaterialsInformationTDS.NoteInformationRow row in (MaterialsInformationTDS.NoteInformationDataTable)Table)
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
        /// GetAllNotes. 
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="companyId">COMPANY_UD</param>
        /// <param name="numberOfNotes">numberOfNotes</param>
        /// <param name="enterString">enterString</param>
        /// <returns>a string with all comments at history separeted with  the enterString</returns>
        public string GetAllNotes(int materialId, int companyId, int numberOfNotes, string enterString)
        {
            string note = "";

            foreach (MaterialsInformationTDS.NoteInformationRow row in (MaterialsInformationTDS.NoteInformationDataTable)Table)
            {
                if ((row.MaterialID == materialId) && (row.COMPANY_ID == companyId))
                {
                    // ... Get user name
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(row.UserID, row.COMPANY_ID);
                    string user = loginGateway.GetLastName(row.UserID, row.COMPANY_ID) + " " + loginGateway.GetFirstName(row.UserID, row.COMPANY_ID);

                    // ... Form the comment string
                    note = note + row.DateTime_ + "  ( " + user.Trim() + " )" + enterString + row.Note;
                }

                // Insert enter when correspond
                if (numberOfNotes > 1)
                {
                    note = note + enterString + enterString;
                    numberOfNotes--;
                }
            }
            return (note);
        }



    }
}