using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.Jliner
{
    /// <summary>
    /// FlatSectionJlinerJuntionLiner2Comment
    /// </summary>
    public class FlatSectionJlinerJuntionLiner2Comment : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlatSectionJlinerJuntionLiner2Comment()
            : base("JuntionLiner2Comment")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlatSectionJlinerJuntionLiner2Comment(DataSet data)
            : base(data, "JuntionLiner2Comment")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlatSectionJlinerTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new comment
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="loginId">loginId</param>
        /// <param name="comment">comment</param>
        /// <param name="deleted">deleted</param>
        /// <param name="toHistory">toHistory</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(Guid id, int refId, int companyId, DateTime dateTime_, int loginId, string comment, bool deleted, bool toHistory, bool inDatabase)
        {
            FlatSectionJlinerTDS.JuntionLiner2CommentRow commentRow = ((FlatSectionJlinerTDS.JuntionLiner2CommentDataTable)Table).NewJuntionLiner2CommentRow();

            commentRow.ID = id;
            commentRow.RefID = refId;
            commentRow.COMPANY_ID = companyId;
            commentRow.CommentID = GetNewCommentId();
            commentRow.DateTime_ = dateTime_;
            commentRow.LoginID = loginId;
            commentRow.Comment = comment.Trim();
            commentRow.Deleted = deleted;
            commentRow.toHistory = toHistory;
            commentRow.InDatabase = inDatabase;

            ((FlatSectionJlinerTDS.JuntionLiner2CommentDataTable)Table).AddJuntionLiner2CommentRow(commentRow);
        }



        /// <summary>
        /// Insert a new comment (direct to DB)
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="commentId">commentId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="loginId">loginId</param>
        /// <param name="comment">comment</param>        
        /// <param name="deleted">deleted</param>        
        /// <returns></returns>
        public void InsertDirect(Guid id, int refId, int companyId, int commentId, DateTime? dateTime_, int loginId, string comment, bool deleted)
        {
            JlinerCommentGateway jlinerCommentGateway = new JlinerCommentGateway(null);
            jlinerCommentGateway.Insert(id, refId, companyId, commentId, dateTime_, loginId, comment, deleted);
        }



        /// <summary>
        /// Update jliner
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="commentId">commentId</param>        
        /// <param name="loginId">loginId</param>
        /// <param name="comment">comment</param>
        /// <param name="deleted">deleted</param>
        /// <param name="adminPermission">add Permission</param>
        /// <param name="toHistory">toHistory</param>
        public void Update(Guid id, int refId, int companyId, int commentId, int loginId, string comment, bool deleted, bool adminPermission, bool toHistory)
        {
            FlatSectionJlinerTDS.JuntionLiner2CommentRow commentRow = GetRow(id, refId, companyId, commentId);

            if (adminPermission)
            {
                commentRow.Comment = comment.Trim();
                commentRow.toHistory = toHistory;
            }
            else
            {
                if (commentRow.LoginID == loginId)
                {
                    commentRow.Comment = comment.Trim();
                    commentRow.toHistory = toHistory;
                }
            }
        }



        /// <summary>
        /// Update direct
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalCommentId">originalCommentId</param>
        /// <param name="originalDateTime">originalDateTime</param>
        /// <param name="originalLoginId">originalLoginId</param>        
        /// <param name="originalComment">originalComment</param>        
        /// <param name="originalDeleted">originalDeleted</param>
        ///
        /// <param name="newId">newId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="originalCommentId">originalCommentId</param>
        /// <param name="newDateTime">newDateTime</param>
        /// <param name="newLoginId">newLoginId</param>                                
        /// <param name="newComment">newComment</param>       
        /// <param name="newDeleted">newDeleted</param>        
        public void UpdateDirect(Guid originalId, int originalRefId,  int originalCompanyId, int originalCommentId, DateTime? originalDateTime, int originalLoginId, string originalComment, bool originalDeleted,  Guid newId, int newRefId, int newCompanyId, int newCommentId, DateTime? newDateTime, int newLoginId, string newComment,  bool newDeleted)
        {
            JlinerCommentGateway jlinerCommentGateway = new JlinerCommentGateway(null);
            jlinerCommentGateway.Update(originalId, originalRefId, originalCompanyId, originalCommentId, originalDateTime, originalLoginId, originalComment, originalDeleted, newId, newRefId, newCompanyId, newCommentId, newDateTime, newLoginId, newComment, newDeleted);
        }



        /// <summary>
        /// UpdateForProcess. Update the author of each comment
        /// </summary>
        public void UpdateForProcess()
        {
            LoginGateway loginGateway = new LoginGateway();

            foreach (FlatSectionJlinerTDS.JuntionLiner2CommentRow row in (FlatSectionJlinerTDS.JuntionLiner2CommentDataTable)Table)
            {
                loginGateway.LoadByLoginId(row.LoginID, row.COMPANY_ID);
                row.UserFullName = loginGateway.GetLastName(row.LoginID, row.COMPANY_ID) + " " + loginGateway.GetFirstName(row.LoginID, row.COMPANY_ID);
            }
        }



        /// <summary>
        /// Delete one comment
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="commentId">commentId</param>
        /// <param name="loginId">loginId</param>
        /// <param name="adminPermission">admin Permission</param>
        public void Delete(Guid id, int refId, int companyId, int commentId, int loginId, bool adminPermission)
        {
            FlatSectionJlinerTDS.JuntionLiner2CommentRow commentRow = GetRow(id, refId, companyId, commentId);
            
            if (adminPermission)
            {
                commentRow.Deleted = true;
            }
            else
            {
                if (commentRow.LoginID == loginId)
                {
                    commentRow.Deleted = true;
                }
            }
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="commentId">commentId</param>
        public void DeleteDirect(Guid id, int refId, int companyId, int commentId)
        {
            JlinerCommentGateway jlinerCommentGateway = new JlinerCommentGateway(null);
            jlinerCommentGateway.Delete(id, refId, companyId, commentId);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>        
        public void DeleteAllDirect(Guid id, int refId, int companyId)
        {
            JlinerCommentGateway jlinerCommentGateway = new JlinerCommentGateway(null);
            jlinerCommentGateway.DeleteAll(id, refId, companyId);
        }



        /// <summary>
        /// GetAllComments. 
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="numberOfComments">numberOfComments</param>
        /// <param name="enterString">enterString</param>
        /// <returns>a string with all comments separeted with  the enterString</returns>
        public string GetAllComments(Guid id, int refId, int companyId, int numberOfComments, string enterString)
        {
            string comment = "";

            foreach (FlatSectionJlinerTDS.JuntionLiner2CommentRow row in (FlatSectionJlinerTDS.JuntionLiner2CommentDataTable)Table)
            {
                if ((row.ID == id) && (row.RefID == refId) && (row.COMPANY_ID == companyId))
                {
                    // ... Get user name                    
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(row.LoginID, companyId );
                    string user = loginGateway.GetLastName(row.LoginID, companyId) + " " + loginGateway.GetFirstName(row.LoginID, companyId);

                    // ... Form the comment string
                    comment = comment + row.DateTime_ + "  ( " + user.Trim() + " )" + enterString + row.Comment;
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
        /// <param name="jlinerHistory">jlinerHistory</param>
        public void transferToHistory(int loginId, bool adminPermission, FlatSectionJlinerJuntionLiner2History jlinerHistory)
        {
            foreach (FlatSectionJlinerTDS.JuntionLiner2CommentRow commentRow in (FlatSectionJlinerTDS.JuntionLiner2CommentDataTable)Table)
            {
                if (adminPermission)
                {
                    if ((commentRow.toHistory) && (!commentRow.Deleted))
                    {
                        // Insert to history
                        jlinerHistory.Insert(commentRow.ID, commentRow.RefID, commentRow.COMPANY_ID, commentRow.DateTime_, commentRow.LoginID, commentRow.Comment, commentRow.Deleted, false, false);

                        // Delete from comments
                        commentRow.Deleted = true;
                    }
                }
                else
                {
                    if (commentRow.LoginID == loginId)
                    {
                        if ((commentRow.toHistory) && (!commentRow.Deleted))
                        {
                            // Insert to history
                            jlinerHistory.Insert(commentRow.ID, commentRow.RefID, commentRow.COMPANY_ID, commentRow.DateTime_, commentRow.LoginID, commentRow.Comment, commentRow.Deleted, false, false);

                            // Delete from comments
                            commentRow.Deleted = true;
                        }
                    }
                }
            }
        }



        /// <summary>
        /// Save all sections & works to database (direct)
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        public void Save(Guid id, int companyId)
        {
            FlatSectionJlinerTDS jlinerChanges = (FlatSectionJlinerTDS)Data.GetChanges();

            if (jlinerChanges.JuntionLiner2Comment.Rows.Count > 0)
            {
                FlatSectionJlinerJuntionLiner2CommentGateway flatSectionJlinerJuntionLiner2CommentGateway = new FlatSectionJlinerJuntionLiner2CommentGateway(jlinerChanges);

                foreach (FlatSectionJlinerTDS.JuntionLiner2CommentRow row in (FlatSectionJlinerTDS.JuntionLiner2CommentDataTable)jlinerChanges.JuntionLiner2Comment)
                {
                    // Insert new comments 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        JlinerComments jlinerComments = new JlinerComments(null);
                        jlinerComments.InsertDirect(row.ID, row.RefID, row.COMPANY_ID, row.CommentID, row.DateTime_, row.LoginID, row.Comment, row.Deleted);
                    }

                    // Update comments
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int refId = row.RefID;
                        int commentId = row.CommentID;

                        // original values
                        int originalLoginId = flatSectionJlinerJuntionLiner2CommentGateway.GetLoginIDOriginal(id, refId, companyId, commentId);
                        DateTime? originalDateTime = null; if (flatSectionJlinerJuntionLiner2CommentGateway.GetDateTime_Original(id, refId, companyId, commentId) != null) originalDateTime = flatSectionJlinerJuntionLiner2CommentGateway.GetDateTime_Original(id, refId, companyId, commentId);
                        string originalComment = flatSectionJlinerJuntionLiner2CommentGateway.GetCommentOriginal(id, refId, companyId, commentId);

                        // new values
                        string newComment = flatSectionJlinerJuntionLiner2CommentGateway.GetComment(id, refId, companyId, commentId);

                        JlinerComments jlinerComments = new JlinerComments(null);
                        jlinerComments.UpdateDirect(id, refId, companyId, commentId, originalDateTime, originalLoginId, originalComment, false, id, refId, companyId, commentId, originalDateTime, originalLoginId, newComment, false);
                    }

                    // Deleted lateral comments
                    if ((row.Deleted)&& (row.InDatabase))
                    {
                        JlinerComments jlinerComments = new JlinerComments(null);
                        jlinerComments.DeleteDirect(row.ID, row.RefID, companyId, row.CommentID);
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetNewCommentId
        /// </summary>
        /// <returns>New ID</returns>
        private int GetNewCommentId()
        {
            int newCommentId = 0;

            foreach (FlatSectionJlinerTDS.JuntionLiner2CommentRow row in (FlatSectionJlinerTDS.JuntionLiner2CommentDataTable)Table)
            {
                if (newCommentId < row.CommentID)
                {
                    newCommentId = row.CommentID;
                }
            }

            newCommentId++;

            return newCommentId;
        }



        /// <summary>
        /// Get a single jliner. If not exists, raise an exception
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="refId">RefID</param>
        /// <param name="companyId">companyId</param>
        /// <param name="commentId"></param>
        /// <returns>FlatSectionJlinerTDS.JuntionLiner2CommentRow</returns>
        private FlatSectionJlinerTDS.JuntionLiner2CommentRow GetRow(Guid id, int refId, int companyId, int commentId)
        {
            FlatSectionJlinerTDS.JuntionLiner2CommentRow row = ((FlatSectionJlinerTDS.JuntionLiner2CommentDataTable)Table).FindByIDRefIDCOMPANY_IDCommentID(id, refId, companyId, commentId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Jliner.FlatSectinJlinerJuntinLiner2Comment.GetRow");
            }

            return row;
        }



    }
}
