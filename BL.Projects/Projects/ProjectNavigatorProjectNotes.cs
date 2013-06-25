using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectNotes
    /// </summary>
    public class ProjectNavigatorProjectNotes : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectNotes() : base("ProjectNotes")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectNotes(DataSet data)
            : base(data, "ProjectNotes")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllByProjectId
        /// </summary>
        /// <param name="projectId">projectId</param>              
        public void LoadAllByProjectId(int projectId)
        {
            ProjectNavigatorProjectNotesGateway projectNavigatorProjectNotesGateway = new ProjectNavigatorProjectNotesGateway(Data);
            projectNavigatorProjectNotesGateway.LoadAllByProjectId(projectId);
        }



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
        /// <param name="companyId">companyId</param>
        /// <param name="inNoteDatabase">inNoteDatabase</param>
        public void Insert(int projectId, string subject, DateTime dateTime, int loginId, string note, bool deleted, int? libraryFilesId, int companyId, bool inNoteDatabase)
        {
            ProjectNavigatorTDS.ProjectNotesRow row = ((ProjectNavigatorTDS.ProjectNotesDataTable)Table).NewProjectNotesRow();
            row.ProjectID = projectId;
            row.RefID = GetNewRefId();
            row.Subject = subject;
            row.DateTime = dateTime;
            row.LoginID = loginId;
            if ((note != "") && (note != null)) row.Note = note.Trim(); else row.SetNoteNull();
            row.Deleted = deleted;
            if (libraryFilesId.HasValue) row.LIBRARY_FILES_ID = (int)libraryFilesId; else row.SetLIBRARY_FILES_IDNull();
            row.COMPANY_ID = companyId;
            row.InNoteDatabase = inNoteDatabase;

            ((ProjectNavigatorTDS.ProjectNotesDataTable)Table).AddProjectNotesRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="refId">RefId</param>
        /// <param name="subject">Subject</param>        
        /// <param name="note">Note</param>        
        /// <param name="libraryFilesId">LibraryFilesId</param>        
        public void Update(int projectId, int refId, string subject, string note, int? libraryFilesId)
        {
            ProjectNavigatorTDS.ProjectNotesRow row = GetRow(projectId, refId);

            row.Subject = subject.Trim();
            if ((note != "") && (note != null)) row.Note = note.Trim(); else row.SetNoteNull();
            if (libraryFilesId.HasValue) row.LIBRARY_FILES_ID = (int)libraryFilesId; else row.SetLIBRARY_FILES_IDNull();
        }



        /// <summary>
        /// Delete note
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="refId">RefId</param>
        /// <returns></returns>
        public void Delete(int projectId, int refId)
        {
            ProjectNavigatorTDS.ProjectNotesRow row = GetRow(projectId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// UpdateLibraryFilesId. Update the Library Files Id
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        public void UpdateLibraryFilesId(int projectId, int refId, int? libraryFilesId, string originalFileName, string fileName)
        {
            ProjectNavigatorTDS.ProjectNotesRow row = GetRow(projectId, refId);

            if (libraryFilesId.HasValue) row.LIBRARY_FILES_ID = (int)libraryFilesId; else row.SetLIBRARY_FILES_IDNull();
            row.ORIGINAL_FILENAME = originalFileName;
            row.FILENAME = fileName;
        }



        /// <summary>
        /// Save all notes to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            ProjectNavigatorTDS notesChanges = (ProjectNavigatorTDS)Data.GetChanges();

            if (notesChanges != null)
            {
                if (notesChanges.ProjectNotes.Rows.Count > 0)
                {
                    ProjectNavigatorProjectNotesGateway projectNavigatorProjectNotesGateway = new ProjectNavigatorProjectNotesGateway(notesChanges);

                    foreach (ProjectNavigatorTDS.ProjectNotesRow row in (ProjectNavigatorTDS.ProjectNotesDataTable)notesChanges.ProjectNotes)
                    {
                        // Insert new Notes 
                        if ((!row.Deleted) && (!row.InNoteDatabase))
                        {
                            int? libraryFilesId = null; if (!row.IsLIBRARY_FILES_IDNull()) libraryFilesId = row.LIBRARY_FILES_ID;

                            ProjectNotes projectNotes = new ProjectNotes(null);
                            projectNotes.InsertDirect(row.ProjectID, row.RefID, row.Subject, row.LoginID, row.DateTime, row.Note, row.Deleted, row.COMPANY_ID, libraryFilesId);
                        }

                        // Update Notes
                        if ((!row.Deleted) && (row.InNoteDatabase))
                        {
                            int projectId = row.ProjectID;
                            int refId = row.RefID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            // original values
                            string originalSubject = projectNavigatorProjectNotesGateway.GetSubjectOriginal(projectId, refId);
                            int originalLoginId = projectNavigatorProjectNotesGateway.GetLoginIdOriginal(projectId, refId);
                            DateTime originalDateTime = projectNavigatorProjectNotesGateway.GetDateTimeOriginal(projectId, refId);
                            string originalNote = projectNavigatorProjectNotesGateway.GetNoteOriginal(projectId, refId);
                            int? originalLibraryFilesId = projectNavigatorProjectNotesGateway.GetLibraryFilesIdOriginal(projectId, refId);

                            // new values
                            string newSubject = projectNavigatorProjectNotesGateway.GetSubject(projectId, refId);
                            string newNote = projectNavigatorProjectNotesGateway.GetNote(projectId, refId);
                            int? newLibraryFilesId = projectNavigatorProjectNotesGateway.GetLibraryFilesId(projectId, refId);

                            ProjectNotes projectNotes = new ProjectNotes(null);
                            projectNotes.UpdateDirect(projectId, refId, originalSubject, originalLoginId, originalDateTime, originalNote, originalDeleted, originalCompanyId, originalLibraryFilesId, projectId, refId, newSubject, originalLoginId, originalDateTime, newNote, originalDeleted, originalCompanyId, newLibraryFilesId);
                        }

                        // Deleted notes 
                        if ((row.Deleted) && (row.InNoteDatabase))
                        {
                            ProjectNotes projectNotes = new ProjectNotes(null);
                            projectNotes.DeleteDirect(row.ProjectID, row.RefID, row.COMPANY_ID);
                        }
                    }
                }
            }
        }
      




        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectNavigatorTDS.ProjectNotesRow</returns>
        private ProjectNavigatorTDS.ProjectNotesRow GetRow(int projectId, int refId)
        {
            ProjectNavigatorTDS.ProjectNotesRow row = ((ProjectNavigatorTDS.ProjectNotesDataTable)Table).FindByProjectIDRefID(projectId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectNavigatorProjectNotes.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>New ID</returns>
        public int GetNewRefId()
        {
            int newRefId = 0;

            foreach (ProjectNavigatorTDS.ProjectNotesRow row in (ProjectNavigatorTDS.ProjectNotesDataTable)Table)
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

            foreach (ProjectNavigatorTDS.ProjectNotesRow row in (ProjectNavigatorTDS.ProjectNotesDataTable)Table)
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