using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningWetOutComments
    /// </summary>
    public class WorkFullLengthLiningWetOutComments: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningWetOutComments()
            : base("LFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningWetOutComments(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTS")
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
            WorkFullLengthLiningWetOutCommentsGateway workFullLengthLiningWetOutCommentsGateway = new WorkFullLengthLiningWetOutCommentsGateway(null);
            workFullLengthLiningWetOutCommentsGateway.Insert(workId, refId, type, subject, userId, dateTime_, comment, libraryFilesId, deleted, companyId, workType);
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
            WorkTDS.LFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTSRow lfsWorkCommentRow = ((WorkTDS.LFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTSDataTable)Table).NewLFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTSRow();

            lfsWorkCommentRow.WorkID = workId;
            lfsWorkCommentRow.RefID = GetNewRefId(); 
            lfsWorkCommentRow.Type = type.Trim(); 
            lfsWorkCommentRow.Subject = subject.Trim();
            lfsWorkCommentRow.UserID = loginId;
            lfsWorkCommentRow.DateTime_ = dateTime_;
            lfsWorkCommentRow.Comment = comment.Trim();
            if (libraryFilesId.HasValue) lfsWorkCommentRow.LIBRARY_FILES_ID = (int)libraryFilesId; else lfsWorkCommentRow.SetLIBRARY_FILES_IDNull();
            lfsWorkCommentRow.Deleted = deleted;
            lfsWorkCommentRow.COMPANY_ID = companyId;            
            if (workType.Trim() != "") lfsWorkCommentRow.WorkType = workType.Trim(); else lfsWorkCommentRow.SetWorkTypeNull();

            ((WorkTDS.LFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTSDataTable)Table).AddLFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTSRow(lfsWorkCommentRow);
        }



        /// <summary>
        /// Update jliner
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>        
        /// <param name="subject">subject</param>
        /// <param name="companyId">companyId</param>
        /// <param name="comment">comment</param>
        /// <param name="loginId">loginId</param>
        /// <param name="adminPermission">add Permission</param>
        public void Update(int workId, int refId, string subject, int companyId, string comment,int loginId, bool adminPermission)
        {
            WorkTDS.LFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTSRow row = GetRow(workId, refId);

            if (adminPermission)
            {             
                row.Subject = subject.Trim();
                row.Comment = comment.Trim();                
            }
            else
            {
                if (row.UserID == loginId)
                {                    
                    row.Subject = subject.Trim();
                    row.Comment = comment.Trim();                 
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
            WorkFullLengthLiningWetOutCommentsGateway workFullLengthLiningWetOutCommentsGateway = new WorkFullLengthLiningWetOutCommentsGateway();
            workFullLengthLiningWetOutCommentsGateway.Update(originalWorkId, originalRefId, originalType, originalSubject, originalUserId, originalDateTime, originalComment, originalLibraryFilesId, originalDeleted, originalCompanyId, originalWorkType, newWorkId, newRefId, newType, newSubject, newUserId, newDateTime, newComment, newLibraryFilesId, newDeleted, newCompanyId, newWorkType);
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
            WorkTDS.LFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTSRow row = GetRow(workId, refId);
            
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
            WorkFullLengthLiningWetOutCommentsGateway workFullLengthLiningWetOutCommentsGateway = new WorkFullLengthLiningWetOutCommentsGateway(null);
            workFullLengthLiningWetOutCommentsGateway.Delete(workId, refId, companyId);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int workId, int companyId)
        {
            WorkFullLengthLiningWetOutCommentsGateway workFullLengthLiningWetOutCommentsGateway = new WorkFullLengthLiningWetOutCommentsGateway(null);
            workFullLengthLiningWetOutCommentsGateway.DeleteAll(workId, companyId);
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

            foreach (WorkTDS.LFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTSRow row in (WorkTDS.LFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTSDataTable)Table)
            {
                if ((row.WorkID == workId)  && (row.COMPANY_ID == companyId) && (!row.Deleted))
                {
                    // ... Get user name
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadAllByLoginId(row.UserID, row.COMPANY_ID);
                    string user = loginGateway.GetLastName(row.UserID, row.COMPANY_ID) + " " + loginGateway.GetFirstName(row.UserID, row.COMPANY_ID);

                    // ... Form the comment string
                    string rowComment =  row.Comment;
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

            foreach (WorkTDS.LFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTSRow row in (WorkTDS.LFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTSDataTable)Table)
            {
                if ((row.COMPANY_ID == companyId) && (!row.Deleted))
                {
                    // ... Get user name
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadAllByLoginId(row.UserID, companyId);
                    string user = loginGateway.GetLastName(row.UserID, companyId) + " " + loginGateway.GetFirstName(row.UserID, companyId);

                    // ... Form the comment string
                    string rowComment = row.Comment;
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

            foreach (WorkTDS.LFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTSRow row in (WorkTDS.LFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTSDataTable)Table)
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
        private WorkTDS.LFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTSRow GetRow(int workId, int refId)
        {
            WorkTDS.LFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTSRow row = ((WorkTDS.LFS_WORK_FULLLENGTHLINING_WETOUT_COMMENTSDataTable)Table).FindByWorkIDRefID(workId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Works.WorkFullLengthLiningWetOutComments.GetRow");
            }

            return row;
        }

    }
}
