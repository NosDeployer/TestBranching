using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeInformationNoteInformation
    /// </summary>
    public class EmployeeInformationNoteInformation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeInformationNoteInformation()
            : base("NoteInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeInformationNoteInformation(DataSet data)
            : base(data, "NoteInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadAllByEmployeeId(int employeeId, int companyId)
        {
            EmployeeInformationNoteInformationGateway employeeInformationNoteInformationGateway = new EmployeeInformationNoteInformationGateway(Data);
            employeeInformationNoteInformationGateway.LoadAllByEmployeeId(employeeId, companyId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="subject">subject</param>
        /// <param name="userId">userId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="note">note</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(int employeeId, string subject, int userId, DateTime dateTime_, string note, bool deleted, int companyId, bool inDatabase)
        {
            EmployeeInformationTDS.NoteInformationRow row = ((EmployeeInformationTDS.NoteInformationDataTable)Table).NewNoteInformationRow();

            row.EmployeeID = employeeId;
            row.RefID = GetNewRefId();
            row.Subject = subject;
            row.UserID = userId;
            row.DateTime_ = dateTime_;
            row.Note = note;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;

            ((EmployeeInformationTDS.NoteInformationDataTable)Table).AddNoteInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <param name="subject">subject</param>
        /// <param name="note">note</param>
        public void Update(int employeeId, int refId, string subject, string note)
        {
            EmployeeInformationTDS.NoteInformationRow row = GetRow(employeeId, refId);

            row.Subject = subject;
            row.Note = note;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        public void Delete(int employeeId, int refId)
        {
            EmployeeInformationTDS.NoteInformationRow row = GetRow(employeeId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        public void DeleteAll(int employeeId)
        {
            foreach (EmployeeInformationTDS.NoteInformationRow row in (EmployeeInformationTDS.NoteInformationDataTable)Table)
            {
                row.Deleted = true;
            }
        }



        /// <summary>
        /// Save all employee notes to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            EmployeeInformationTDS employeeInformationChanges = (EmployeeInformationTDS)Data.GetChanges();

            if (employeeInformationChanges.NoteInformation.Rows.Count > 0)
            {
                EmployeeInformationNoteInformationGateway employeeInformationNoteInformationGateway = new EmployeeInformationNoteInformationGateway(employeeInformationChanges);

                foreach (EmployeeInformationTDS.NoteInformationRow row in (EmployeeInformationTDS.NoteInformationDataTable)employeeInformationChanges.NoteInformation)
                {
                    // Insert new Notes 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        EmployeeNotes employeeNotes = new EmployeeNotes(null);
                        employeeNotes.InsertDirect(row.EmployeeID, row.RefID, row.Subject, row.UserID, row.DateTime_, row.Note, row.Deleted, row.COMPANY_ID);
                    }

                    // Update Notes
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int employeeId = row.EmployeeID;
                        int refId = row.RefID;
                        bool originalDeleted = row.Deleted;
                        int originalCompanyId = companyId;

                        // original values
                        string originalSubject = employeeInformationNoteInformationGateway.GetSubjectOriginal(employeeId, refId);
                        int originalUserId = employeeInformationNoteInformationGateway.GetUserIdOriginal(employeeId, refId);
                        DateTime originalDateTime_ = employeeInformationNoteInformationGateway.GetDateTime_Original(employeeId, refId);
                        string originalNote = employeeInformationNoteInformationGateway.GetNoteOriginal(employeeId, refId);

                        // new values
                        string newSubject = employeeInformationNoteInformationGateway.GetSubject(employeeId, refId);
                        string newNote = employeeInformationNoteInformationGateway.GetNote(employeeId, refId);

                        EmployeeNotes employeeNote = new EmployeeNotes(null);
                        employeeNote.UpdateDirect(employeeId, refId, originalSubject, originalUserId, originalDateTime_, originalNote, originalDeleted, originalCompanyId, employeeId, refId, newSubject, originalUserId, originalDateTime_, newNote, originalDeleted, originalCompanyId);
                    }

                    // Deleted notes 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        EmployeeNotes employeeNote = new EmployeeNotes(null);
                        employeeNote.DeleteDirect(row.EmployeeID, row.RefID, row.COMPANY_ID);
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private EmployeeInformationTDS.NoteInformationRow GetRow(int employeeId, int refId)
        {
            EmployeeInformationTDS.NoteInformationRow row = ((EmployeeInformationTDS.NoteInformationDataTable)Table).FindByEmployeeIDRefID(employeeId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.Employees.EmployeeInformationNoteInformation.GetRow");
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

            foreach (EmployeeInformationTDS.NoteInformationRow row in (EmployeeInformationTDS.NoteInformationDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }



    }
}