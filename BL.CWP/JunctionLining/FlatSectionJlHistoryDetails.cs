using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.JunctionLining
{
    /// <summary>
    /// FlatSectionJlHistoryDetails
    /// </summary>
    public class FlatSectionJlHistoryDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlatSectionJlHistoryDetails()
            : base("FlatSectionJlHistoryDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlatSectionJlHistoryDetails(DataSet data)
            : base(data, "FlatSectionJlHistoryDetails")
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
        /// <param name="history">history</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="userFullName">userFullName</param>
        /// <param name="toComments">toComments</param>
        /// <param name="workType">workType</param>
        public void Insert(int workId, string type, string subject, int loginId, DateTime dateTime_, string history, int? libraryFilesId, bool deleted, int companyId, bool inDatabase, string userFullName, bool toComments, string workType)
        {
            FlatSectionJlTDS.FlatSectionJlHistoryDetailsRow row = ((FlatSectionJlTDS.FlatSectionJlHistoryDetailsDataTable)Table).NewFlatSectionJlHistoryDetailsRow();

            row.WorkID = workId;
            row.RefID = GetNewRefId();
            if (type.Trim() != "") row.Type = type.Trim(); else row.SetTypeNull();
            row.Subject = subject.Trim();
            row.UserID = loginId;
            row.DateTime_ = dateTime_;
            if (history.Trim() != "") row.History = history.Trim(); else row.SetHistoryNull();
            if (libraryFilesId.HasValue) row.LIBRARY_FILES_ID = (int)libraryFilesId; else row.SetLIBRARY_FILES_IDNull();
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.UserFullName = userFullName;
            row.ToComments = toComments;
            if (workType.Trim() != "") row.WorkType = workType; else row.SetWorkTypeNull();

            ((FlatSectionJlTDS.FlatSectionJlHistoryDetailsDataTable)Table).AddFlatSectionJlHistoryDetailsRow(row);
        }



        /// <summary>
        /// Update a comment
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="type">type</param>
        /// <param name="subject">subject</param>
        /// <param name="companyId">companyId</param>
        /// <param name="history">history</param>
        /// <param name="loginId">loginId</param>
        /// <param name="adminPermission">add Permission</param>
        /// <param name="toComments">toComments</param>
        public void Update(int workId, int refId, string type, string subject, int companyId, string history, int loginId, bool adminPermission, bool toComments)
        {
            FlatSectionJlTDS.FlatSectionJlHistoryDetailsRow row = GetRow(workId, refId);

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
        /// UpdateForProcess. Update the author of each comment
        /// </summary>
        public void UpdateForProcess()
        {
            LoginGateway loginGateway = new LoginGateway();

            foreach (FlatSectionJlTDS.FlatSectionJlHistoryDetailsRow row in (FlatSectionJlTDS.FlatSectionJlHistoryDetailsDataTable)Table)
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
            FlatSectionJlTDS.FlatSectionJlHistoryDetailsRow row = GetRow(workId, refId);

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
            FlatSectionJlTDS flatSectionJlHistoryDetailsChanges = (FlatSectionJlTDS)Data.GetChanges();

            if (flatSectionJlHistoryDetailsChanges.FlatSectionJlHistoryDetails.Rows.Count > 0)
            {
                FlatSectionJlHistoryDetailsGateway flatSectionJlHistoryDetailsGateway = new FlatSectionJlHistoryDetailsGateway(flatSectionJlHistoryDetailsChanges);

                foreach (FlatSectionJlTDS.FlatSectionJlHistoryDetailsRow row in (FlatSectionJlTDS.FlatSectionJlHistoryDetailsDataTable)flatSectionJlHistoryDetailsChanges.FlatSectionJlHistoryDetails)
                {
                    // Insert new comments 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        WorkHistory workHistory = new WorkHistory(null);
                        int? libraryFilesId = null; if (!row.IsLIBRARY_FILES_IDNull()) libraryFilesId = row.LIBRARY_FILES_ID;
                        string workType = ""; if (!row.IsWorkTypeNull()) workType = row.WorkType;

                        workHistory.InsertDirect(row.WorkID, row.RefID, row.Type, row.Subject, row.UserID, row.DateTime_, row.History, libraryFilesId, row.Deleted, row.COMPANY_ID, workType);
                    }

                    // Update comments
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int workId = row.WorkID;
                        int refId = row.RefID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // original values
                        string originalType = flatSectionJlHistoryDetailsGateway.GetTypeOriginal(workId, refId);
                        string originalSubject = flatSectionJlHistoryDetailsGateway.GetSubjectOriginal(workId, refId);
                        int originalUserId = flatSectionJlHistoryDetailsGateway.GetUserIdOriginal(workId, refId);
                        DateTime? originalDateTime = null; if (flatSectionJlHistoryDetailsGateway.GetDateTime_Original(workId, refId) != null) originalDateTime = flatSectionJlHistoryDetailsGateway.GetDateTime_Original(workId, refId);
                        string originalComment = flatSectionJlHistoryDetailsGateway.GetCommentOriginal(workId, refId);
                        int? originalLibraryFilesId = null; if (flatSectionJlHistoryDetailsGateway.GetLIBRARY_FILES_IDOriginal(workId, refId) != null) originalLibraryFilesId = flatSectionJlHistoryDetailsGateway.GetLIBRARY_FILES_IDOriginal(workId, refId);
                        string originalWorkType = flatSectionJlHistoryDetailsGateway.GetWorkTypeOriginal(workId, refId);

                        // new values
                        string newSubject = flatSectionJlHistoryDetailsGateway.GetSubject(workId, refId);
                        string newComment = flatSectionJlHistoryDetailsGateway.GetComment(workId, refId);
                        int? newLibraryFilesId = null; if (flatSectionJlHistoryDetailsGateway.GetLIBRARY_FILES_IDOriginal(workId, refId) != null) originalLibraryFilesId = flatSectionJlHistoryDetailsGateway.GetLIBRARY_FILES_ID(workId, refId);

                        WorkHistory workHistory = new WorkHistory(null);
                        workHistory.UpdateDirect(workId, refId, originalType, originalSubject, originalUserId, originalDateTime, originalComment, originalLibraryFilesId, originalDeleted, originalCompanyId, originalWorkType, workId, refId, originalType, newSubject, originalUserId, originalDateTime, newComment, newLibraryFilesId, originalDeleted, originalCompanyId, originalWorkType);
                    }

                    // Deleted comments 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        WorkHistory workHistory = new WorkHistory(null);
                        workHistory.DeleteDirect(row.WorkID, row.RefID, row.COMPANY_ID);
                    }
                }
            }
        }



        /// <summary>
        /// Transfer to Comments
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <param name="adminPermission">admin Permission</param>
        /// <param name="jlinerComments">jlinerComments</param>
        public void TransferToComments(int loginId, bool adminPermission, FlatSectionJlCommentDetails flatSectionJlCommentDetails)
        {
            int? libraryFilesId = null;

            foreach (FlatSectionJlTDS.FlatSectionJlHistoryDetailsRow historyRow in (FlatSectionJlTDS.FlatSectionJlHistoryDetailsDataTable)Table)
            {
                if (adminPermission)
                {
                    if (!historyRow.IsToCommentsNull())
                    {
                        if ((historyRow.ToComments) && (!historyRow.Deleted))
                        {
                            if (!historyRow.IsLIBRARY_FILES_IDNull())
                            {
                                libraryFilesId = historyRow.LIBRARY_FILES_ID;
                            }
                            else
                            {
                                libraryFilesId = null;
                            }
                            string workType = ""; if (!historyRow.IsWorkTypeNull()) workType = historyRow.WorkType;
                            // Insert to comments
                            flatSectionJlCommentDetails.Insert(historyRow.WorkID, historyRow.Type, historyRow.Subject, historyRow.UserID, historyRow.DateTime_, historyRow.History, libraryFilesId, historyRow.Deleted, historyRow.COMPANY_ID, false, historyRow.UserFullName, false, workType);

                            // Delete from History
                            historyRow.Deleted = true;
                        }
                    }
                }
                else
                {
                    if (historyRow.UserID == loginId)
                    {
                        if (!historyRow.IsToCommentsNull())
                        {
                            if ((historyRow.ToComments) && (!historyRow.Deleted))
                            {
                                if (!historyRow.IsLIBRARY_FILES_IDNull())
                                {
                                    libraryFilesId = historyRow.LIBRARY_FILES_ID;
                                }
                                else
                                {
                                    libraryFilesId = null;
                                }
                                string workType = ""; if (!historyRow.IsWorkTypeNull()) workType = historyRow.WorkType;
                                // Insert to comments
                                flatSectionJlCommentDetails.Insert(historyRow.WorkID, historyRow.Type, historyRow.Subject, historyRow.UserID, historyRow.DateTime_, historyRow.History, libraryFilesId, historyRow.Deleted, historyRow.COMPANY_ID, false, historyRow.UserFullName, false, workType);

                                // Delete from History
                                historyRow.Deleted = true;
                            }
                        }
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        ///

        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>New ID</returns>
        private int GetNewRefId()
        {
            int newRefId = 0;

            foreach (FlatSectionJlTDS.FlatSectionJlHistoryDetailsRow row in (FlatSectionJlTDS.FlatSectionJlHistoryDetailsDataTable)Table)
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
        /// <returns>FlatSectionJlTDS.FlatSectionJlHistoryDetailsRow</returns>
        private FlatSectionJlTDS.FlatSectionJlHistoryDetailsRow GetRow(int workId, int refId)
        {
            FlatSectionJlTDS.FlatSectionJlHistoryDetailsRow row = ((FlatSectionJlTDS.FlatSectionJlHistoryDetailsDataTable)Table).FindByWorkIDRefID(workId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.JunctionLining.FlatSectionJlHistoryDetails.GetRow");
            }

            return row;
        }



    }
}