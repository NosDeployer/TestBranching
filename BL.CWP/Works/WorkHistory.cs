using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkHistory
    /// </summary>
    public class WorkHistory : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkHistory()
            : base("LFS_WORK_HISTORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkHistory(DataSet data)
            : base(data, "LFS_WORK_HISTORY")
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
        /// LoadByWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>        
        public void LoadByWorkId(int workId, int companyId)
        {
            WorkHistoryGateway workHistoryGateway = new WorkHistoryGateway(Data);
            workHistoryGateway.LoadByWorkIdWorkType(workId, companyId, "Junction Lining Lateral");
        }



        /// <summary>
        /// Insert a new comment (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="type">type</param>
        /// <param name="subject">subject</param>
        /// <param name="userId">userId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="history">history</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns></returns>
        public void InsertDirect(int workId, int refId, string type, string subject, int userId, DateTime? dateTime_, string history, int? libraryFilesId, bool deleted, int companyId, string workType)
        {
            WorkHistoryGateway workHistoryGateway = new WorkHistoryGateway(null);
            workHistoryGateway.Insert(workId, refId, type, subject, userId, dateTime_, history, libraryFilesId, deleted, companyId, workType);
        }



        /// <summary>
        /// Insert a new comment
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="type">type</param>
        /// <param name="subject">subject</param>
        /// <param name="loginId">loginId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="history">history</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>  
        /// <param name="toComments">toComments</param>
        /// <param name="workType">workType</param>        
        public void Insert(int workId, int refId, string type, string subject, int loginId, DateTime dateTime_, string history, int? libraryFilesId, bool deleted, int companyId, bool toComments, string workType)
        {
            WorkTDS.LFS_WORK_HISTORYRow lfsWorkHistoryRow = ((WorkTDS.LFS_WORK_HISTORYDataTable)Table).NewLFS_WORK_HISTORYRow();

            lfsWorkHistoryRow.WorkID = workId;
            lfsWorkHistoryRow.RefID = GetNewRefId();
            if (type.Trim() != "") lfsWorkHistoryRow.Type = type.Trim(); else lfsWorkHistoryRow.SetTypeNull();
            lfsWorkHistoryRow.Subject = subject.Trim();
            lfsWorkHistoryRow.UserID = loginId;
            lfsWorkHistoryRow.DateTime_ = dateTime_;
            if (history.Trim() != "") lfsWorkHistoryRow.History = history.Trim(); else lfsWorkHistoryRow.SetHistoryNull();
            if (libraryFilesId.HasValue) lfsWorkHistoryRow.LIBRARY_FILES_ID = (int)libraryFilesId; else lfsWorkHistoryRow.SetLIBRARY_FILES_IDNull();
            lfsWorkHistoryRow.Deleted = deleted;
            lfsWorkHistoryRow.COMPANY_ID = companyId;
            lfsWorkHistoryRow.ToComments = toComments;
            if (workType.Trim() != "") lfsWorkHistoryRow.WorkType = workType.Trim(); else lfsWorkHistoryRow.SetWorkTypeNull();

            ((WorkTDS.LFS_WORK_HISTORYDataTable)Table).AddLFS_WORK_HISTORYRow(lfsWorkHistoryRow);
        }



        /// <summary>
        /// Update direct
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalSubject">originalSubject</param>
        /// <param name="originalUserId">originalUserId</param>
        /// <param name="originalDateTime">originalDateTime</param>
        /// <param name="originalHistory">originalHistory</param>
        /// <param name="originalLibraryFilesId">originalLibraryFilesId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newWorkType">newWorkType</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newType">newType</param>
        /// <param name="newSubject">newSubject</param>
        /// <param name="newUserId">newUserId</param>
        /// <param name="newDateTime">newDateTime</param>
        /// <param name="newHistory">newHistory</param>
        /// <param name="newLibraryFilesId">newLibraryFilesId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="originalWorkType">originalWorkType</param>
        public void UpdateDirect(int originalWorkId, int originalRefId, string originalType, string originalSubject, int originalUserId, DateTime? originalDateTime, string originalHistory, int? originalLibraryFilesId, bool originalDeleted, int originalCompanyId, string originalWorkType, int newWorkId, int newRefId, string newType, string newSubject, int newUserId, DateTime? newDateTime, string newHistory, int? newLibraryFilesId, bool newDeleted, int newCompanyId, string newWorkType)
        {
            WorkHistoryGateway workHistoryGateway = new WorkHistoryGateway();
            workHistoryGateway.Update(originalWorkId, originalRefId, originalType, originalSubject, originalUserId, originalDateTime, originalHistory, originalLibraryFilesId, originalDeleted, originalCompanyId, originalWorkType, newWorkId, newRefId, newType, newSubject, newUserId, newDateTime, newHistory, newLibraryFilesId, newDeleted, newCompanyId, newWorkType);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="type">type</param>
        /// <param name="subject">subject</param>
        /// <param name="companyId">companyId</param>
        /// <param name="comment">comment</param>
        /// <param name="loginId">loginId</param>
        /// <param name="adminPermission">add Permission</param>
        public void Update(int workId, int refId, string type, string subject, int companyId, string history, int loginId, bool adminPermission, bool toComments)
        {
            WorkTDS.LFS_WORK_HISTORYRow row = GetRow(workId, refId);

            if (adminPermission)
            {
                if (type.Trim() != "") row.Type = type.Trim(); else row.SetTypeNull();
                row.Subject = subject.Trim();
                if (history.Trim() != "") row.History = history.Trim(); else row.SetHistoryNull();
                row.ToComments = toComments;
            }
            else
            {
                if (row.UserID == loginId)
                {
                    if (type.Trim() != "") row.Type = type.Trim(); else row.SetTypeNull();
                    row.Subject = subject.Trim();
                    if (history.Trim() != "") row.History = history.Trim(); else row.SetHistoryNull();
                    row.ToComments = toComments;
                }
            }
        }



        /// <summary>
        /// Delete one comment
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="loginId">loginId</param>
        /// <param name="adminPermission">admin Permission</param>
        public void Delete(int workId, int refId, int companyId, int loginId, bool adminPermission)
        {
            WorkTDS.LFS_WORK_HISTORYRow row = GetRow(workId, refId);

            if (adminPermission)
            {
                row.Deleted = true;
            }
            else
            {
                if (row.UserID == loginId)
                {
                    row.Deleted = true;
                }
            }
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, int refId, int companyId)
        {
            WorkHistoryGateway workHistoryGateway = new WorkHistoryGateway(null);
            workHistoryGateway.Delete(workId, refId, companyId);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int workId, int companyId)
        {
            WorkHistoryGateway workHistoryGateway = new WorkHistoryGateway(null);
            workHistoryGateway.DeleteAll(workId, companyId);
        }



        /// <summary>
        /// GetAllComments. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="numberOfComments">numberOfComments</param>
        /// <param name="enterString">enterString</param>
        /// <returns>a string with all comments separeted with  the enterString</returns>
        public string GetAllHistory(int workId, int companyId, int numberOfHistory, string enterString)
        {
            string history = "";

            foreach (WorkTDS.LFS_WORK_HISTORYRow row in (WorkTDS.LFS_WORK_HISTORYDataTable)Table)
            {
                if ((row.WorkID == workId) && (row.COMPANY_ID == companyId))
                {
                    // ... Get user name
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadAllByLoginId(row.UserID, companyId);
                    string user = loginGateway.GetLastName(row.UserID, companyId) + " " + loginGateway.GetFirstName(row.UserID, companyId);

                    // ... Form the comment string
                    string rowHistory = ""; if (!row.IsHistoryNull()) rowHistory = row.History; else rowHistory = "( None )";
                    history = history + row.DateTime_ + " (" + user.Trim() + ")";
                    if (!row.IsWorkTypeNull()) history = history + ", Created At: " + row.WorkType;
                    history = history + ", Type: " + row.Type;                    
                    history = history + ", Subject: " + row.Subject + enterString;
                    history = history + "Comment: " + rowHistory;
                }

                // Insert enter when correspond
                if (numberOfHistory > 1)
                {
                    history = history + enterString + enterString;
                    numberOfHistory--;
                }
            }
            return (history);
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

            foreach (WorkTDS.LFS_WORK_HISTORYRow row in (WorkTDS.LFS_WORK_HISTORYDataTable)Table)
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
        /// Get a single comment. If not exists, raise an exception
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">RefID</param>
        /// <returns>SectionTDS.LFS_JUNCTION_LINER2_COMMENTRow</returns>
        private WorkTDS.LFS_WORK_HISTORYRow GetRow(int workId, int refId)
        {
            WorkTDS.LFS_WORK_HISTORYRow row = ((WorkTDS.LFS_WORK_HISTORYDataTable)Table).FindByWorkIDRefID(workId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Works.WorkHistory.GetRow");
            }

            return row;
        }



    }
}

