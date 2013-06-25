using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectNotes
    /// </summary>
    public class ProjectNotes : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNotes() : base("LFS_PROJECT_NOTE")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNotes(DataSet data)
            : base(data, "LFS_PROJECT_NOTE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadAllByProjectId
        /// </summary>
        /// <param name="projectId">ProjectId filter</param>
        public void LoadAllByProjectId(int projectId)
        {
            ProjectNotesGateway projectNotesGateway = new ProjectNotesGateway(Data);
            projectNotesGateway.LoadAllByProjectId(projectId);            
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //
        
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="subject">Subject</param>
        /// <param name="dateTime">dateTime</param>
        /// <param name="loginId">LoginId</param>
        /// <param name="note">Note</param>
        /// <param name="deleted">Deleted</param>
        /// <param name="libraryFilesId">LibraryFilesId</param>
        /// <param name="companyId">CompanyId</param>
        public void Insert(int projectId, string subject, DateTime dateTime, int loginId, string note, bool deleted, int? libraryFilesId, int companyId)
        {
            ProjectTDS.LFS_PROJECT_NOTERow lfsProjectNoteRow = ((ProjectTDS.LFS_PROJECT_NOTEDataTable)Table).NewLFS_PROJECT_NOTERow();
            lfsProjectNoteRow.ProjectID = projectId;
            lfsProjectNoteRow.RefID = GetNewRefId();
            lfsProjectNoteRow.Subject = subject;
            lfsProjectNoteRow.DateTime = dateTime;
            lfsProjectNoteRow.LoginID = loginId;
            if ((note != "") && (note != null)) lfsProjectNoteRow.Note = note.Trim(); else lfsProjectNoteRow.SetNoteNull();
            lfsProjectNoteRow.Deleted = deleted;
            if (libraryFilesId.HasValue) lfsProjectNoteRow.LIBRARY_FILES_ID = (int)libraryFilesId; else lfsProjectNoteRow.SetLIBRARY_FILES_IDNull();
            lfsProjectNoteRow.COMPANY_ID = companyId;

            ((ProjectTDS.LFS_PROJECT_NOTEDataTable)Table).AddLFS_PROJECT_NOTERow(lfsProjectNoteRow);
        }



        /// <summary>
        /// Insert a new note (direct to DB)
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="subject">subject</param>
        /// <param name="loginId">loginId</param>
        /// <param name="dateTime">dateTime</param>
        /// <param name="note">note</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="LIBRARY_FILES_ID">LIBRARY_FILES_ID</param>
        public void InsertDirect(int projectId, int refId, string subject, int loginId, DateTime dateTime, string note, bool deleted, int companyId, int? LIBRARY_FILES_ID)
        {
            ProjectNotesGateway projectNotesGateway = new ProjectNotesGateway(null);
            projectNotesGateway.Insert(projectId, refId, subject, loginId, dateTime, note, deleted, companyId, LIBRARY_FILES_ID);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="refId">RefId</param>
        /// <param name="subject">Subject</param>
        /// <param name="dateTime">dateTime</param>
        /// <param name="loginId">LoginId</param>
        /// <param name="note">Note</param>
        /// <param name="deleted">Deleted</param>
        /// <param name="libraryFilesId">LibraryFilesId</param>
        /// <param name="companyId">CompanyId</param>
        public void Update(int projectId, int refId, string subject, DateTime dateTime, int loginId, string note, bool deleted, int? libraryFilesId, int companyId)
        {
            ProjectTDS.LFS_PROJECT_NOTERow lfsProjectNoteRow = GetRow(projectId, refId);

            lfsProjectNoteRow.ProjectID = projectId;
            lfsProjectNoteRow.RefID = refId;
            lfsProjectNoteRow.Subject = subject.Trim();
            lfsProjectNoteRow.DateTime = dateTime;
            lfsProjectNoteRow.LoginID = loginId;
            if ((note != "") && (note != null)) lfsProjectNoteRow.Note = note.Trim(); else lfsProjectNoteRow.SetNoteNull();
            if (libraryFilesId.HasValue) lfsProjectNoteRow.LIBRARY_FILES_ID = (int)libraryFilesId; else lfsProjectNoteRow.SetLIBRARY_FILES_IDNull();
            lfsProjectNoteRow.Deleted = deleted;
            lfsProjectNoteRow.COMPANY_ID = companyId;
        }



        /// <summary>
        /// Update cost (direct to DB)
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalSubject">originalSubject</param>
        /// <param name="originalLoginId">originalLoginId</param>
        /// <param name="originalDateTime_">originalDateTime_</param>
        /// <param name="originalNote">originalNote</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalLIBRARY_FILES_ID">originalLIBRARY_FILES_ID</param>
        /// 
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newSubject">newSubject</param>
        /// <param name="newLoginId">newLoginId</param>
        /// <param name="newDateTime">newDateTime</param>
        /// <param name="newNote">newNote</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newLIBRARY_FILES_ID">newLIBRARY_FILES_ID</param>
        public void UpdateDirect(int originalProjectId, int originalRefId, string originalSubject, int originalLoginId, DateTime originalDateTime, string originalNote, bool originalDeleted, int originalCompanyId, int? originalLIBRARY_FILES_ID, int newProjectId, int newRefId, string newSubject, int newLoginId, DateTime newDateTime, string newNote, bool newDeleted, int newCompanyId, int? newLIBRARY_FILES_ID)
        {
            ProjectNotesGateway projectNotesGateway = new ProjectNotesGateway(null);
            projectNotesGateway.Update(originalProjectId, originalRefId, originalSubject, originalLoginId, originalDateTime, originalNote, originalDeleted, originalCompanyId, originalLIBRARY_FILES_ID, newProjectId, newRefId, newSubject, newLoginId, newDateTime, newNote, newDeleted, newCompanyId, newLIBRARY_FILES_ID);
        }



        /// <summary>
        /// UpdateLibraryFilesId. Update the Library Files Id
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="refId"></param>
        /// <param name="libraryFilesId"></param>
        public void UpdateLibraryFilesId(int projectId, int refId, int? libraryFilesId, string originalFileName, string fileName)
        {
            ProjectTDS.LFS_PROJECT_NOTERow lfsProjectNoteRow = GetRow(projectId, refId);

            if (libraryFilesId.HasValue) lfsProjectNoteRow.LIBRARY_FILES_ID = (int)libraryFilesId; else lfsProjectNoteRow.SetLIBRARY_FILES_IDNull();
            lfsProjectNoteRow.ORIGINAL_FILENAME = originalFileName;
            lfsProjectNoteRow.FILENAME = fileName;
        }



        /// <summary>
        /// UpdateForProcess. Update the author of each Note
        /// </summary>
        public void UpdateForProcess()
        {
            LoginGateway loginGateway = new LoginGateway();
            LibraryFilesGateway libraryFilesGateway = new LibraryFilesGateway();
            
            foreach (ProjectTDS.LFS_PROJECT_NOTERow row in (ProjectTDS.LFS_PROJECT_NOTEDataTable)Table)
            {
                loginGateway.LoadByLoginId(row.LoginID, row.COMPANY_ID);
                row.UserFullName = loginGateway.GetLastName(row.LoginID, row.COMPANY_ID) + " " + loginGateway.GetFirstName(row.LoginID, row.COMPANY_ID);
                row.CreationDateTime = row.DateTime.ToString();
                if (!row.IsLIBRARY_FILES_IDNull())
                {
                    try
                    {
                        libraryFilesGateway.LoadByLibraryFilesId(row.LIBRARY_FILES_ID);
                        row.ORIGINAL_FILENAME = libraryFilesGateway.GetOriginalFileName(row.LIBRARY_FILES_ID);
                        row.FILENAME = libraryFilesGateway.GetFileName(row.LIBRARY_FILES_ID);
                    }
                    catch { }
                }
            }
        }



        /// <summary>
        /// Delete project
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="refId">RefId</param>
        /// <returns></returns>
        public void Delete(int projectId, int refId)
        {
            ProjectTDS.LFS_PROJECT_NOTERow lfsProjectNoteRow = GetRow(projectId, refId);
            lfsProjectNoteRow.Deleted = true;
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int projectId, int refId, int companyId)
        {
            ProjectNotesGateway projectNotesGateway = new ProjectNotesGateway(null);
            projectNotesGateway.Delete(projectId, refId, companyId);
        }



        /// <summary>
        /// GetAllProjectNotes. 
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="numberOfNotes">numberOfNotes</param>
        /// <param name="enterString">enterString</param>
        /// <returns>a string with all Notes separeted with  the enterString</returns>
        public string GetAllProjectNotes(int projectId, int companyId, int numberOfNotes, string enterString)
        {
            string note = "";

            foreach (ProjectTDS.LFS_PROJECT_NOTERow row in (ProjectTDS.LFS_PROJECT_NOTEDataTable)Table)
            {
                if ((row.ProjectID == projectId) && (row.COMPANY_ID == companyId) && (!row.Deleted))
                {
                    // ... Get user name
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadAllByLoginId(row.LoginID, companyId);
                    string user = loginGateway.GetLastName(row.LoginID, companyId) + " " + loginGateway.GetFirstName(row.LoginID, companyId);

                    // ... Form the note string
                    string rowNote = ""; if (!row.IsNoteNull()) rowNote = row.Note; else rowNote = "( None )";
                    note = note + row.DateTime + " (" + user.Trim() + ")";                                        
                    note = note + ", Subject: " + row.Subject + enterString;
                    note = note + "note: " + rowNote;                

                    // Insert enter when correspond
                    if (numberOfNotes > 1)
                    {
                        note = note + enterString + enterString;
                        numberOfNotes--;
                    }
                }
            }
            return (note);
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>New ID</returns>
        public int GetNewRefId()
        {
            int newRefId = 0;

            foreach (ProjectTDS.LFS_PROJECT_NOTERow row in (ProjectTDS.LFS_PROJECT_NOTEDataTable)Table)
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
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectTDS.LFS_PROJECT_NOTERow</returns>
        private ProjectTDS.LFS_PROJECT_NOTERow GetRow(int projectId, int refId)
        {
            ProjectTDS.LFS_PROJECT_NOTERow row = ((ProjectTDS.LFS_PROJECT_NOTEDataTable)Table).FindByProjectIDRefID(projectId,refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectSaleBillingPricing.GetRow");
            }

            return row;
        }



    }
}
