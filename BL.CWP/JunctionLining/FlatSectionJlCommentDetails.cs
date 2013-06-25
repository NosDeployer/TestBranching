using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.JunctionLining
{
    /// <summary>
    /// FlatSectionJlCommentDetails
    /// </summary>
    public class FlatSectionJlCommentDetails : TableModule
    {   
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlatSectionJlCommentDetails()
            : base("FlatSectionJlCommentDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlatSectionJlCommentDetails(DataSet data)
            : base(data, "FlatSectionJlCommentDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlatSectionJlTDS();
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
            FlatSectionJlTDS.FlatSectionJlCommentDetailsRow row = ((FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable)Table).NewFlatSectionJlCommentDetailsRow();

            row.WorkID = workId;
            row.RefID = GetNewRefId();
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

            ((FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable)Table).AddFlatSectionJlCommentDetailsRow(row);
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
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="userFullName">userFullName</param>
        /// <param name="toHistory">toHistory</param>
        public void InsertForBulkFieldUpdate(int workId, string type, string subject, int loginId, DateTime dateTime_, string comment, int? libraryFilesId, bool deleted, int companyId, bool inDatabase, string userFullName, bool toHistory)
        {
            FlatSectionJlTDS.FlatSectionJlCommentDetailsRow row = ((FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable)Table).NewFlatSectionJlCommentDetailsRow();

            row.WorkID = workId;
            row.RefID = GetNewRefId(workId);
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

            ((FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable)Table).AddFlatSectionJlCommentDetailsRow(row);
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
        /// <param name="toHistory">toHistory</param>
        public void Update(int workId, int refId, string type, string subject, int companyId, string comment, int loginId, bool adminPermission, bool toHistory)
        {
            FlatSectionJlTDS.FlatSectionJlCommentDetailsRow row = GetRow(workId, refId);

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
        /// UpdateForProcess. Update the author of each comment
        /// </summary>
        public void UpdateForProcess()
        {
            LoginGateway loginGateway = new LoginGateway();

            foreach (FlatSectionJlTDS.FlatSectionJlCommentDetailsRow row in (FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable)Table)
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
            FlatSectionJlTDS.FlatSectionJlCommentDetailsRow row = GetRow(workId, refId);

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
        /// Save all comments to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            FlatSectionJlTDS flatSectionJlCommentDetailsChanges = (FlatSectionJlTDS)Data.GetChanges();

            if (flatSectionJlCommentDetailsChanges.FlatSectionJlCommentDetails.Rows.Count > 0)
            {
                FlatSectionJlCommentDetailsGateway flatSectionJlCommentDetailsGateway = new FlatSectionJlCommentDetailsGateway(flatSectionJlCommentDetailsChanges);

                foreach (FlatSectionJlTDS.FlatSectionJlCommentDetailsRow row in (FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable)flatSectionJlCommentDetailsChanges.FlatSectionJlCommentDetails)
                {
                    // Insert new comments 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        WorkComments workComments = new WorkComments(null);
                        int? libraryFilesId = null; if (!row.IsLIBRARY_FILES_IDNull()) libraryFilesId = row.LIBRARY_FILES_ID;
                        string workType = ""; if (!row.IsWorkTypeNull()) workType = row.WorkType;

                        workComments.InsertDirect(row.WorkID, row.RefID, row.Type, row.Subject, row.UserID, row.DateTime_, row.Comment, libraryFilesId, row.Deleted, row.COMPANY_ID, workType);
                    }

                    // Update comments
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int workId = row.WorkID;
                        int refId = row.RefID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // original values
                        string originalType = flatSectionJlCommentDetailsGateway.GetTypeOriginal(workId, refId);
                        string originalSubject = flatSectionJlCommentDetailsGateway.GetSubjectOriginal(workId, refId);
                        int originalUserId = flatSectionJlCommentDetailsGateway.GetUserIdOriginal(workId, refId);
                        DateTime? originalDateTime = null; if (flatSectionJlCommentDetailsGateway.GetDateTime_Original(workId, refId) != null) originalDateTime = flatSectionJlCommentDetailsGateway.GetDateTime_Original(workId, refId);
                        string originalComment = flatSectionJlCommentDetailsGateway.GetCommentOriginal(workId, refId);
                        int? originalLibraryFilesId = null; if (flatSectionJlCommentDetailsGateway.GetLIBRARY_FILES_IDOriginal(workId, refId) != null) originalLibraryFilesId = flatSectionJlCommentDetailsGateway.GetLIBRARY_FILES_IDOriginal(workId, refId);
                        string originalWorkType = flatSectionJlCommentDetailsGateway.GetWorkTypeOriginal(workId, refId);

                        // new values
                        string newSubject = flatSectionJlCommentDetailsGateway.GetSubject(workId, refId);
                        string newComment = flatSectionJlCommentDetailsGateway.GetComment(workId, refId);
                        int? newLibraryFilesId = null; if (flatSectionJlCommentDetailsGateway.GetLIBRARY_FILES_IDOriginal(workId, refId) != null) originalLibraryFilesId = flatSectionJlCommentDetailsGateway.GetLIBRARY_FILES_ID(workId, refId);

                        WorkComments workComments = new WorkComments(null);
                        workComments.UpdateDirect(workId, refId, originalType, originalSubject, originalUserId, originalDateTime, originalComment, originalLibraryFilesId, originalDeleted, originalCompanyId, originalWorkType, workId, refId, originalType, newSubject, originalUserId, originalDateTime, newComment, newLibraryFilesId, originalDeleted, originalCompanyId, originalWorkType);
                    }

                    // Deleted comments 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        WorkComments workComments = new WorkComments(null);
                        workComments.DeleteDirect(row.WorkID, row.RefID, row.COMPANY_ID);
                    }
                }
            }
        }



        /// <summary>
        /// Transfer to History
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <param name="adminPermission">admin Permission</param>
        /// <param name="workHistory">workHistory</param>
        public void TransferToHistory(int loginId, bool adminPermission, FlatSectionJlHistoryDetails flatSectionJlHistoryDetails)
        {
            int? libraryFilesId = null;

            foreach (FlatSectionJlTDS.FlatSectionJlCommentDetailsRow commentRow in (FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable)Table)
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
                            string workType = ""; if (!commentRow.IsWorkTypeNull()) workType = commentRow.WorkType;
                            // Insert to history
                            flatSectionJlHistoryDetails.Insert(commentRow.WorkID, commentRow.Type, commentRow.Subject, commentRow.UserID, commentRow.DateTime_, commentRow.Comment, libraryFilesId, commentRow.Deleted, commentRow.COMPANY_ID, false, commentRow.UserFullName, commentRow.ToHistory, workType);

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
                                string workType = ""; if (!commentRow.IsWorkTypeNull()) workType = commentRow.WorkType;
                                // Insert to history
                                flatSectionJlHistoryDetails.Insert(commentRow.WorkID, commentRow.Type, commentRow.Subject, commentRow.UserID, commentRow.DateTime_, commentRow.Comment, libraryFilesId, commentRow.Deleted, commentRow.COMPANY_ID, false, commentRow.UserFullName, false, workType);

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
        private int GetNewRefId()
        {
            int newRefId = 0;

            foreach (FlatSectionJlTDS.FlatSectionJlCommentDetailsRow row in (FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable)Table)
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
        /// GetNewRefId
        /// </summary>
        /// <returns>New ID</returns>
        private int GetNewRefId(int workId)
        {
            int newRefId = 0;

            foreach (FlatSectionJlTDS.FlatSectionJlCommentDetailsRow row in (FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable)Table)
            {
                if (workId == row.WorkID)
                {
                    if (newRefId < row.RefID)
                    {
                        newRefId = row.RefID;
                    }
                }
            }

            newRefId++;

            return newRefId;
        }



        /// <summary>
        /// Get a single comment. If not exists, raise an exception
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refID</param>
        /// <returns>FlatSectionJlTDS.FlatSectionJlCommentDetailsRow</returns>
        private FlatSectionJlTDS.FlatSectionJlCommentDetailsRow GetRow(int workId, int refId)
        {
            FlatSectionJlTDS.FlatSectionJlCommentDetailsRow row = ((FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable)Table).FindByWorkIDRefID(workId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.JunctionLining.FlatSectionJlCommentDetails.GetRow");
            }

            return row;
        }



    }
}