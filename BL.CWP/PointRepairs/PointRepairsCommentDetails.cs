using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.PointRepairs;
using LiquiForce.LFSLive.BL.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.PointRepairs
{
    /// <summary>
    /// PointRepairsCommentDetails
    /// </summary>
    public class PointRepairsCommentDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PointRepairsCommentDetails()
            : base("CommentDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PointRepairsCommentDetails(DataSet data)
            : base(data, "CommentDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PointRepairsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllByWorkIdWorkType
        /// </summary>
        /// <param name="workId">workId</param>              
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        public void LoadAllByWorkIdWorkType(int workId, int companyId, string workType)
        {
            PointRepairsCommentDetailsGateway pointRepairsCommentDetailsGateway = new PointRepairsCommentDetailsGateway(Data);
            pointRepairsCommentDetailsGateway.LoadAllByWorkIdWorkType(workId, companyId, workType);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="type">type</param>
        /// <param name="subject">subject</param>
        /// <param name="userId">userId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="comment">comment</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="workType">workType</param>
        public void Insert(int workId, string type, string subject, int userId, DateTime dateTime_, string comment, int? libraryFilesId, bool deleted, int companyId, bool inDatabase, string workType)
        {
            PointRepairsTDS.CommentDetailsRow row = ((PointRepairsTDS.CommentDetailsDataTable)Table).NewCommentDetailsRow();

            row.WorkID = workId;
            row.RefID = GetNewRefId();
            row.Type = type;
            row.Subject = subject;
            row.UserID = userId;
            row.DateTime_ = dateTime_;
            row.Comment = comment;
            if (libraryFilesId.HasValue) row.LIBRARY_FILES_ID = (int)libraryFilesId; else row.SetLIBRARY_FILES_IDNull();
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            if (workType.Trim() != "") row.WorkType = workType; else row.SetWorkTypeNull();

            ((PointRepairsTDS.CommentDetailsDataTable)Table).AddCommentDetailsRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="subject">subject</param>
        /// <param name="comment">comment</param>
        public void Update(int workId, int refId, string subject, string comment)
        {
            PointRepairsTDS.CommentDetailsRow row = GetRow(workId, refId);

            row.Subject = subject;
            row.Comment = comment;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        public void Delete(int workId, int refId)
        {
            PointRepairsTDS.CommentDetailsRow row = GetRow(workId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="workId">workId</param>
        public void DeleteAll(int workId)
        {
            foreach (PointRepairsTDS.CommentDetailsRow row in (PointRepairsTDS.CommentDetailsDataTable)Table)
            {
                row.Deleted = true;
            }
        }



        /// <summary>
        /// Save all comments to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            PointRepairsTDS pointRepairsChanges = (PointRepairsTDS)Data.GetChanges();

            if (pointRepairsChanges.CommentDetails.Rows.Count > 0)
            {
                PointRepairsCommentDetailsGateway pointRepairsCommentDetailsGateway = new PointRepairsCommentDetailsGateway(pointRepairsChanges);

                foreach (PointRepairsTDS.CommentDetailsRow row in (PointRepairsTDS.CommentDetailsDataTable)pointRepairsChanges.CommentDetails)
                {
                    // Insert new comment 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        int workId = row.WorkID;
                        int refId = row.RefID;                        
                        int? libraryFilesId = null; if (!row.IsLIBRARY_FILES_IDNull()) libraryFilesId = row.LIBRARY_FILES_ID;

                        WorkComments workComments = new WorkComments(null);
                        workComments.InsertDirect(workId, refId, row.Type, row.Subject, row.UserID, row.DateTime_, row.Comment, libraryFilesId, row.Deleted, row.COMPANY_ID, row.WorkType);
                    }

                    // Update comment
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int workId = row.WorkID;
                        int refId = row.RefID;
                        int originalCompanyId = companyId;
                        string type = row.Type;
                        int? libraryFilesId = null; if (!row.IsLIBRARY_FILES_IDNull()) libraryFilesId = row.LIBRARY_FILES_ID;
                        string workType = row.WorkType;
                        
                        // Original values
                        string originalSubject = pointRepairsCommentDetailsGateway.GetSubjectOriginal(workId, refId);
                        int originalUserId = pointRepairsCommentDetailsGateway.GetUserIdOriginal(workId, refId);
                        DateTime originalDateTime_ = pointRepairsCommentDetailsGateway.GetDateTime_Original(workId, refId);
                        string originalComment = pointRepairsCommentDetailsGateway.GetCommentOriginal(workId, refId);
                        bool originalDeleted = pointRepairsCommentDetailsGateway.GetDeletedOriginal(workId, refId);

                        // New values
                        string newSubject = pointRepairsCommentDetailsGateway.GetSubject(workId, refId);
                        string newComment = pointRepairsCommentDetailsGateway.GetComment(workId, refId);

                        WorkComments workComments = new WorkComments(null);
                        workComments.UpdateDirect(workId, refId, type, originalSubject, originalUserId, originalDateTime_, originalComment, libraryFilesId, originalDeleted, originalCompanyId, workType,  workId, refId, type, newSubject, originalUserId, originalDateTime_, newComment, libraryFilesId, originalDeleted, companyId, workType);
                    }

                    // Delete comment
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        int workId = row.WorkID;
                        int refId = row.RefID;

                        WorkComments workComments = new WorkComments(null);
                        workComments.DeleteDirect(workId, refId, row.COMPANY_ID);
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
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private PointRepairsTDS.CommentDetailsRow GetRow(int workId, int refId)
        {
            PointRepairsTDS.CommentDetailsRow row = ((PointRepairsTDS.CommentDetailsDataTable)Table).FindByWorkIDRefID(workId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.PointRepairs.PointRepairsCommentDetails.GetRow");
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

            foreach (PointRepairsTDS.CommentDetailsRow row in (PointRepairsTDS.CommentDetailsDataTable)Table)
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