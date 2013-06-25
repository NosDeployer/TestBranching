using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.RehabAssessment;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.BL.CWP.FullLengthLining;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.RehabAssessment
{
    /// <summary>
    /// RehabAssessmentCommentDetails
    /// </summary>
    public class RehabAssessmentCommentDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RehabAssessmentCommentDetails()
            : base("CommentDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RehabAssessmentCommentDetails(DataSet data)
            : base(data, "CommentDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new RehabAssessmentTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

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
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="userFullName">userFullName</param>
        /// <param name="toHistory">toHistory</param>
        /// <param name="workType">workType</param>
        public void Insert(int workId, string type, string subject, int loginId, DateTime dateTime_, string comment, int? libraryFilesId, bool deleted, int companyId, bool inDatabase, string userFullName, bool toHistory, string workType)
        {
            RehabAssessmentTDS.CommentDetailsRow row = ((RehabAssessmentTDS.CommentDetailsDataTable)Table).NewCommentDetailsRow();

            row.WorkID = workId;
            row.RefID = GetNewRefId(type, workId, companyId);            
            if (type.Trim() != "") row.Type = type.Trim(); else row.SetTypeNull();
            row.Subject = subject.Trim();
            row.UserID = loginId;
            row.DateTime_ = dateTime_;
            if (comment.Trim() != "") row.Comment = comment.Trim(); else row.SetCommentNull();
            if (libraryFilesId.HasValue) row.LIBRARY_FILES_ID = (int)libraryFilesId; else row.SetLIBRARY_FILES_IDNull();
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.UserFullName = userFullName;
            row.ToHistory = toHistory;
            if (workType.Trim() != "") row.WorkType = workType; else row.SetWorkTypeNull();

            ((RehabAssessmentTDS.CommentDetailsDataTable)Table).AddCommentDetailsRow(row);
        }



        /// <summary>
        /// Update a comment
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="type">type</param>
        /// <param name="subject">subject</param>
        /// <param name="companyId">companyId</param>
        /// <param name="comment">comment</param>
        /// <param name="loginId">loginId</param>
        /// <param name="adminPermission">add Permission</param>
        public void Update(int workId, int refId, string type, string subject, int companyId, string comment, int loginId, bool adminPermission, bool toHistory, int workIdFll, int workIdRa, string workType)
        {
            RehabAssessmentTDS.CommentDetailsRow row = GetRow(workId, refId);

            if (adminPermission)
            {
                if (type.Trim() != "") row.Type = type.Trim(); else row.SetTypeNull();
                row.Subject = subject.Trim();
                if (comment.Trim() != "") row.Comment = comment.Trim(); else row.SetCommentNull();
                row.ToHistory = toHistory;

                if (type != "Rehab Assessment")
                {
                    if (row.WorkID != workIdFll)
                    {
                        Delete(row.WorkID, refId, companyId, loginId, adminPermission);
                        Insert(workIdFll, type, subject, loginId, DateTime.Now, comment, null, false, companyId, false, row.UserFullName, false, workType);
                    }
                }
                else
                {
                    if (row.WorkID != workIdRa)
                    {
                        Delete(row.WorkID, refId, companyId, loginId, adminPermission);
                        Insert(workIdRa, type, subject, loginId, DateTime.Now, comment, null, false, companyId, false, row.UserFullName, false, workType);
                    }
                }
            }
            else
            {
                if (row.UserID == loginId)
                {
                    if (type.Trim() != "") row.Type = type.Trim(); else row.SetTypeNull();
                    row.Subject = subject.Trim();
                    if (comment.Trim() != "") row.Comment = comment.Trim(); else row.SetCommentNull();
                    row.ToHistory = toHistory;

                    if (type != "Rehab Assessment")
                    {
                        if (row.WorkID != workIdFll)
                        {
                            Delete(row.WorkID, refId, companyId, loginId, adminPermission);
                            Insert(workIdFll, type, subject, loginId, DateTime.Now, comment, null, false, companyId, false, row.UserFullName, false, workType);
                        }
                    }
                    else
                    {
                        if (row.WorkID != workIdRa)
                        {
                            Delete(row.WorkID, refId, companyId, loginId, adminPermission);
                            Insert(workIdRa, type, subject, loginId, DateTime.Now, comment, null, false, companyId, false, row.UserFullName, false, workType);
                        }
                    }
                }
            }            
        }



        /// <summary>
        /// UpdateForProcess. Update the author of each comment
        /// </summary>
        public void UpdateForProcess()
        {
            LoginGateway loginGateway = new LoginGateway();

            foreach (RehabAssessmentTDS.CommentDetailsRow row in (RehabAssessmentTDS.CommentDetailsDataTable)Table)
            {
                loginGateway.LoadByLoginId(row.UserID, row.COMPANY_ID);
                row.UserFullName = loginGateway.GetLastName(row.UserID, row.COMPANY_ID) + " " + loginGateway.GetFirstName(row.UserID, row.COMPANY_ID);
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
            RehabAssessmentTDS.CommentDetailsRow row = GetRow(workId, refId);

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



        public void UpdateDataToCorrectDataSet(int workIdRa, int workIdFll, RehabAssessmentCommentDetails raCommentDetails, FullLengthLiningCommentDetails fllCommentDetails, string workType)
        {
            foreach (RehabAssessmentTDS.CommentDetailsRow row in (RehabAssessmentTDS.CommentDetailsDataTable)Table)
            {
                int workId = row.WorkID;
                string type = row.Type;
                string subject = row.Subject;
                int loginId = row.UserID;
                DateTime dateTime_ = row.DateTime_;
                string comment = row.Comment;
                int? libraryFilesId = null; if (!row.IsLIBRARY_FILES_IDNull() ) libraryFilesId = row.LIBRARY_FILES_ID;
                bool deleted = row.Deleted;
                int companyId = row.COMPANY_ID;
                bool inDatabase = row.InDatabase;
                string userFullName = row.UserFullName;
                bool toHistory = row.ToHistory;

                if (row.WorkID == workIdRa)
                {
                    raCommentDetails.Insert(workId, type, subject, loginId, dateTime_, comment, libraryFilesId, deleted, companyId, inDatabase, userFullName, toHistory, workType);
                }
                else
                {
                    if (row.WorkID == workIdFll)
                    {
                        fllCommentDetails.Insert(workId, type, subject, loginId, dateTime_, comment, libraryFilesId, deleted, companyId, inDatabase, userFullName, toHistory, workType);
                    }
                }
            }
        }



        /// <summary>
        /// Save all comments to database (direct)
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="companyId">companyId</param>        
        public void Save(int originalWorkId, int companyId)
        {
            RehabAssessmentTDS rehabAssessmentCommentDetailsChanges = (RehabAssessmentTDS)Data.GetChanges();

            if (rehabAssessmentCommentDetailsChanges.CommentDetails.Rows.Count > 0)
            {
                RehabAssessmentCommentDetailsGateway rehabAssessmentCommentDetailsGateway = new RehabAssessmentCommentDetailsGateway(rehabAssessmentCommentDetailsChanges);

                foreach (RehabAssessmentTDS.CommentDetailsRow row in (RehabAssessmentTDS.CommentDetailsDataTable)rehabAssessmentCommentDetailsChanges.CommentDetails)
                {
                    // Insert new comment 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        WorkComments workComments = new WorkComments(null);
                        int? libraryFilesId = null; if (!row.IsLIBRARY_FILES_IDNull()) libraryFilesId = row.LIBRARY_FILES_ID;

                        workComments.InsertDirect(row.WorkID, row.RefID, row.Type, row.Subject, row.UserID, row.DateTime_, row.Comment, libraryFilesId, row.Deleted, row.COMPANY_ID, row.WorkType);
                    }

                    // Update comment
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int workId = row.WorkID;
                        int refId = row.RefID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // original values
                        string originalType = rehabAssessmentCommentDetailsGateway.GetTypeOriginal(workId, refId);
                        string originalSubject = rehabAssessmentCommentDetailsGateway.GetSubjectOriginal(workId, refId);
                        int originalUserId = rehabAssessmentCommentDetailsGateway.GetUserIdOriginal(workId, refId);
                        DateTime? originalDateTime = null; if (rehabAssessmentCommentDetailsGateway.GetDateTime_Original(workId, refId) != null) originalDateTime = rehabAssessmentCommentDetailsGateway.GetDateTime_Original(workId, refId);
                        string originalComment = rehabAssessmentCommentDetailsGateway.GetCommentOriginal(workId, refId);
                        int? originalLibraryFilesId = null; if (rehabAssessmentCommentDetailsGateway.GetLIBRARY_FILES_IDOriginal(workId, refId) != null) originalLibraryFilesId = rehabAssessmentCommentDetailsGateway.GetLIBRARY_FILES_IDOriginal(workId, refId);
                        string originalWorkType = rehabAssessmentCommentDetailsGateway.GetWorkTypeOriginal(workId, refId);

                        // new values
                        string newType = rehabAssessmentCommentDetailsGateway.GetType(workId, refId);
                        string newSubject = rehabAssessmentCommentDetailsGateway.GetSubject(workId, refId);
                        string newComment = rehabAssessmentCommentDetailsGateway.GetComment(workId, refId);
                        int? newLibraryFilesId = null; if (rehabAssessmentCommentDetailsGateway.GetLIBRARY_FILES_IDOriginal(workId, refId) != null) originalLibraryFilesId = rehabAssessmentCommentDetailsGateway.GetLIBRARY_FILES_ID(workId, refId);

                        WorkComments workComments = new WorkComments(null);
                        workComments.UpdateDirect(workId, refId, originalType, originalSubject, originalUserId, originalDateTime, originalComment, originalLibraryFilesId, originalDeleted, originalCompanyId, originalWorkType, workId, refId, newType, newSubject, originalUserId, originalDateTime, newComment, newLibraryFilesId, originalDeleted, originalCompanyId, originalWorkType);
                    }

                    // Deleted comment 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        WorkComments workComments = new WorkComments(null);
                        workComments.DeleteDirect(row.WorkID, row.RefID, row.COMPANY_ID);
                    }

                }
            }
        }



        /// <summary>
        /// GetAllRehabAssessmentComments. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="numberOfComments">numberOfComments</param>
        /// <param name="enterString">enterString</param>
        /// <returns>a string with all comments separeted with  the enterString</returns>
        public string GetAllRehabAssessmentComments(int workId, int companyId, int numberOfComments, string enterString)
        {
            string comment = "";

            foreach (RehabAssessmentTDS.CommentDetailsRow row in (RehabAssessmentTDS.CommentDetailsDataTable)Table)
            {
                if ((row.WorkID == workId) && (row.COMPANY_ID == companyId) && (!row.Deleted))
                {
                    // ... Get user name
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadAllByLoginId(row.UserID, companyId);
                    string user = loginGateway.GetLastName(row.UserID, companyId) + " " + loginGateway.GetFirstName(row.UserID, companyId);

                    // ... Form the comment string
                    string rowComment = ""; if (!row.IsCommentNull()) rowComment = row.Comment; else rowComment = "( None )";
                    comment = comment + row.DateTime_ + " (" + user.Trim() + ")";
                    if (!row.IsWorkTypeNull()) comment = comment + ", Created At: " + row.WorkType;
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






        //// ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>New ID</returns>
        private int GetNewRefId(string type, int workId, int companyId)
        {
            int newRefId = 0;

            if (type == "Rehab Assessment")
            {
                foreach (RehabAssessmentTDS.CommentDetailsRow row in (RehabAssessmentTDS.CommentDetailsDataTable)Table)
                {
                    if (newRefId < row.RefID)
                    {
                        newRefId = row.RefID;
                    }
                }
            }
            else
            {
                int maxRefIdFll = 0;
                FullLengthLiningCommentDetailsGateway fullLengthLiningCommentDetailsGateway = new FullLengthLiningCommentDetailsGateway();
                fullLengthLiningCommentDetailsGateway.LoadAllByWorkIdWorkType(workId, companyId, "Full Length Lining");

                foreach (FullLengthLiningTDS.CommentDetailsRow row in (FullLengthLiningTDS.CommentDetailsDataTable)fullLengthLiningCommentDetailsGateway.Table)
                {
                    if (maxRefIdFll < row.RefID)
                    {
                        maxRefIdFll = row.RefID;
                    }
                }

                foreach (RehabAssessmentTDS.CommentDetailsRow row in (RehabAssessmentTDS.CommentDetailsDataTable)Table)
                {
                    if (row.Type != "Rehab Assessment")
                    {
                        if (maxRefIdFll < row.RefID)
                        {
                            maxRefIdFll = row.RefID;
                        }
                    }
                }

                newRefId = maxRefIdFll;
            }

            newRefId++;

            return newRefId;
        }



        /// <summary>
        /// Get a single comment. If not exists, raise an exception
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">RefID</param>
        /// <returns>RehabAssessmentTDS.CommentDetailsRow</returns>
        private RehabAssessmentTDS.CommentDetailsRow GetRow(int workId, int refId)
        {
            RehabAssessmentTDS.CommentDetailsRow row = ((RehabAssessmentTDS.CommentDetailsDataTable)Table).FindByWorkIDRefID(workId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.RehabAssessment.RehabAssessmentCommentDetails.GetRow");
            }

            return row;
        }


    }
}

