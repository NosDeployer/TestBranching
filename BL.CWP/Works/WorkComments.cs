using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkComments
    /// </summary>
    public class WorkComments : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkComments()
            : base("LFS_WORK_COMMENT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkComments(DataSet data)
            : base(data, "LFS_WORK_COMMENT")
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
        /// LoadByWorkIdCompanyId
        /// </summary>
        /// <param name="workJLId">workJLId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>        
        public void LoadByWorkIdCompanyId(int workJLId, int projectId, int assetId, int companyId)
        {
            WorkCommentsGateway workCommentsGateway = new WorkCommentsGateway(Data);
            workCommentsGateway.ClearBeforeFill = false;
            WorkGateway workGateway = new WorkGateway();

            // Load Junction lining Comments
            workCommentsGateway.LoadByWorkIdWorkType(workJLId, companyId, "Junction Lining Lateral");
            workCommentsGateway.ClearBeforeFill = true;
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
        /// <param name="comment">comment</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns></returns>
        public void InsertDirect(int workId, int refId, string type, string subject, int userId, DateTime? dateTime_, string comment, int? libraryFilesId, bool deleted, int companyId, string workType)
        {
            WorkCommentsGateway workCommentsGateway = new WorkCommentsGateway(null);
            workCommentsGateway.Insert(workId, refId, type, subject, userId, dateTime_, comment, libraryFilesId, deleted, companyId, workType);
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
        /// <param name="comment">comment</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="toHistory">toHistory</param>
        /// <param name="workType">workType</param>
        public void Insert(int workId, int refId, string type ,string subject, int loginId, DateTime dateTime_,  string comment,int? libraryFilesId, bool deleted, int companyId, bool toHistory, string workType)
        {
            WorkTDS.LFS_WORK_COMMENTRow lfsWorkCommentRow = ((WorkTDS.LFS_WORK_COMMENTDataTable)Table).NewLFS_WORK_COMMENTRow();

            lfsWorkCommentRow.WorkID = workId;
            lfsWorkCommentRow.RefID = GetNewRefId(); 
            if (type.Trim() != "") lfsWorkCommentRow.Type = type.Trim(); else lfsWorkCommentRow.SetTypeNull();
            lfsWorkCommentRow.Subject = subject.Trim();
            lfsWorkCommentRow.UserID = loginId;
            lfsWorkCommentRow.DateTime_ = dateTime_;
            if (comment.Trim() != "") lfsWorkCommentRow.Comment = comment.Trim(); else lfsWorkCommentRow.SetCommentNull();
            if (libraryFilesId.HasValue) lfsWorkCommentRow.LIBRARY_FILES_ID = (int)libraryFilesId; else lfsWorkCommentRow.SetLIBRARY_FILES_IDNull();
            lfsWorkCommentRow.Deleted = deleted;
            lfsWorkCommentRow.COMPANY_ID = companyId;
            lfsWorkCommentRow.ToHistory = toHistory;
            if (workType.Trim() != "") lfsWorkCommentRow.WorkType = workType.Trim(); else lfsWorkCommentRow.SetWorkTypeNull();

            ((WorkTDS.LFS_WORK_COMMENTDataTable)Table).AddLFS_WORK_COMMENTRow(lfsWorkCommentRow);
        }



        /// <summary>
        /// Update jliner
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="type">type</param>
        /// <param name="subject">subject</param>
        /// <param name="companyId">companyId</param>
        /// <param name="comment">comment</param>
        /// <param name="loginId">loginId</param>
        /// <param name="adminPermission">add Permission</param>
        public void Update(int workId, int refId,string type, string subject, int companyId, string comment,int loginId, bool adminPermission, bool toHistory)
        {
            WorkTDS.LFS_WORK_COMMENTRow row = GetRow(workId, refId);

            if (adminPermission)
            {
                if (type.Trim() != "") row.Type = type.Trim(); else row.SetTypeNull();
                row.Subject = subject.Trim();
                if (comment.Trim() != "") row.Comment = comment.Trim(); else row.SetCommentNull();
                row.ToHistory = toHistory;
            }
            else
            {
                if (row.UserID == loginId)
                {
                    if (type.Trim() != "") row.Type = type.Trim(); else row.SetTypeNull();
                    row.Subject = subject.Trim();
                    if (comment.Trim() != "") row.Comment = comment.Trim(); else row.SetCommentNull();
                    row.ToHistory = toHistory;
                }
            }
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
        /// <param name="originalComment">originalComment</param>
        /// <param name="originalLibraryFilesId">originalLibraryFilesId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalWorkType">originalWorkType</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newType">newType</param>
        /// <param name="newSubject">newSubject</param>
        /// <param name="newUserId">newUserId</param>
        /// <param name="newDateTime">newDateTime</param>
        /// <param name="newComment">newComment</param>
        /// <param name="newLibraryFilesId">newLibraryFilesId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newWorkType">newWorkType</param>
        public void UpdateDirect(int originalWorkId, int originalRefId, string originalType, string originalSubject, int originalUserId, DateTime? originalDateTime, string originalComment, int? originalLibraryFilesId, bool originalDeleted, int originalCompanyId, string originalWorkType, int newWorkId, int newRefId, string newType, string newSubject, int newUserId, DateTime? newDateTime, string newComment, int? newLibraryFilesId, bool newDeleted, int newCompanyId, string newWorkType)
        {
            WorkCommentsGateway workCommentsGateway = new WorkCommentsGateway();
            workCommentsGateway.Update(originalWorkId, originalRefId, originalType, originalSubject, originalUserId, originalDateTime, originalComment, originalLibraryFilesId, originalDeleted, originalCompanyId, originalWorkType, newWorkId, newRefId, newType, newSubject, newUserId, newDateTime, newComment, newLibraryFilesId, newDeleted, newCompanyId, newWorkType);
        }



        /// <summary>
        /// UpdateForProcess. Update the author of each comment
        /// </summary>
        public void UpdateForProcess()
        {
            LoginGateway loginGateway = new LoginGateway();

            foreach (WorkTDS.LFS_WORK_COMMENTRow row in (WorkTDS.LFS_WORK_COMMENTDataTable)Table)
            {
                loginGateway.LoadByLoginId(row.UserID, row.COMPANY_ID);
                row.UserFullName = loginGateway.GetLastName(row.UserID, row.COMPANY_ID) + " " + loginGateway.GetFirstName(row.UserID, row.COMPANY_ID);
                row.CreationDateTime = row.DateTime_;
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
            WorkTDS.LFS_WORK_COMMENTRow row = GetRow(workId, refId);
            
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
            WorkCommentsGateway workCommentsGateway = new WorkCommentsGateway(null);
            workCommentsGateway.Delete(workId, refId, companyId);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int workId, int companyId)
        {
            WorkCommentsGateway workCommentsGateway = new WorkCommentsGateway(null);
            workCommentsGateway.DeleteAll(workId, companyId);
        }

        

        /// <summary>
        /// GetAllComments. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="numberOfComments">numberOfComments</param>
        /// <param name="enterString">enterString</param>
        /// <returns>a string with all comments separeted with  the enterString</returns>
        public string GetAllComments(int workId, int companyId, int numberOfComments, string enterString)
        {
            string comment = "";

            foreach (WorkTDS.LFS_WORK_COMMENTRow row in (WorkTDS.LFS_WORK_COMMENTDataTable)Table)
            {
                if ((row.WorkID == workId) && (row.COMPANY_ID == companyId) && (!row.Deleted))
                {
                    // ... Get user name
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadAllByLoginId(row.UserID, companyId);
                    string user = loginGateway.GetLastName(row.UserID,companyId) + " " + loginGateway.GetFirstName(row.UserID, companyId);

                    // ... Form the comment string
                    string rowComment = ""; if (!row.IsCommentNull()) rowComment = row.Comment; else rowComment = "( None )";
                    comment = comment + row.DateTime_ + " (" + user.Trim() + ")" ;
                    if (!row.IsWorkTypeNull()) comment = comment + ", Created At: " + row.WorkType;
                    comment = comment + ", Type: " + row.Type;                    
                    comment = comment + ", Subject: " + row.Subject + enterString;
                    comment = comment + "Comment: "+ rowComment;
                }

                // Insert enter when correspond
                if (numberOfComments > 1)
                {
                    comment = comment + enterString + enterString;
                    numberOfComments--;
                }
            }
            return (comment);
        }



        /// <summary>
        /// GetCommentsSummary. 
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="numberOfComments">numberOfComments</param>
        /// <param name="enterString">enterString</param>
        /// <returns>a string with all comments separeted with  the enterString</returns>
        public string GetCommentsSummary( int companyId, int numberOfComments, string enterString)
        {
            string comment = "";

            foreach (WorkTDS.LFS_WORK_COMMENTRow row in (WorkTDS.LFS_WORK_COMMENTDataTable)Table)
            {
                if ((row.COMPANY_ID == companyId) && (!row.Deleted))
                {
                    // ... Get user name                                       
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadAllByLoginId(row.UserID, companyId);
                    string user = loginGateway.GetLastName(row.UserID, companyId) + " " + loginGateway.GetFirstName(row.UserID, companyId);

                    // ... Form the comment string
                    string rowComment = ""; if (!row.IsCommentNull()) rowComment = row.Comment; else rowComment = "(None)";
                    comment = comment + row.DateTime_ + " (" + user.Trim() + ")" ;
                    if (!row.IsWorkTypeNull())  comment = comment + ", Created At: " + row.WorkType ;
                    comment = comment + ", Type: " + row.Type ;
                    comment = comment + ", Subject: " + row.Subject + enterString;
                    comment = comment + "Comment: " + rowComment;
                }

                // Insert enter when correspond
                if (numberOfComments > 1)
                {
                    comment = comment + enterString + enterString;
                    numberOfComments--;
                }
            }
            return (comment);
        }



        /// <summary>
        /// Transfer to History
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <param name="adminPermission">admin Permission</param>
        /// <param name="workHistory">workHistory</param>
        public void TransferToHistory(int loginId, bool adminPermission, WorkHistory workHistory)
        {
            int? libraryFilesId = null;

            foreach (WorkTDS.LFS_WORK_COMMENTRow commentRow in (WorkTDS.LFS_WORK_COMMENTDataTable)Table)
            {
                if (adminPermission)
                {
                    if (!commentRow.IsToHistoryNull())
                    {
                        if ((commentRow.ToHistory) && (!commentRow.Deleted))
                        {
                            if (!commentRow.IsLIBRARY_FILES_IDNull())
                            {
                                libraryFilesId = commentRow.LIBRARY_FILES_ID;
                            }
                            else
                            {
                                libraryFilesId = null;
                            }

                            // Insert to history
                            workHistory.Insert(commentRow.WorkID, commentRow.RefID, commentRow.Type, commentRow.Subject, commentRow.UserID, commentRow.DateTime_, commentRow.Comment, libraryFilesId, commentRow.Deleted, commentRow.COMPANY_ID, false, commentRow.WorkType);

                            // Delete from comments
                            commentRow.Deleted = true;
                        }
                    }
                }
                else
                {
                    if (commentRow.UserID == loginId)
                    {
                        if (!commentRow.IsToHistoryNull())
                        {
                            if ((commentRow.ToHistory) && (!commentRow.Deleted))
                            {
                                if (!commentRow.IsLIBRARY_FILES_IDNull())
                                {
                                    libraryFilesId = commentRow.LIBRARY_FILES_ID;
                                }
                                else
                                {
                                    libraryFilesId = null;
                                }

                                // Insert to history
                                workHistory.Insert(commentRow.WorkID, commentRow.RefID, commentRow.Type, commentRow.Subject, commentRow.UserID, commentRow.DateTime_, commentRow.Comment, libraryFilesId, commentRow.Deleted, commentRow.COMPANY_ID, false, commentRow.WorkType);

                                // Delete from comments
                                commentRow.Deleted = true;
                            }
                        }
                    }
                }

            }
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

            foreach (WorkTDS.LFS_WORK_COMMENTRow row in (WorkTDS.LFS_WORK_COMMENTDataTable)Table)
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
        private WorkTDS.LFS_WORK_COMMENTRow GetRow(int workId, int refId)
        {
            WorkTDS.LFS_WORK_COMMENTRow row = ((WorkTDS.LFS_WORK_COMMENTDataTable)Table).FindByWorkIDRefID(workId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Works.WorkComments.GetRow");
            }

            return row;
        }


    }
}
