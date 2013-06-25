using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.Jliner
{
    /// <summary>
    /// JlinerComments
    /// </summary>
    public class JlinerComments : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlinerComments()
            : base("LFS_JUNCTION_LINER2_COMMENT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlinerComments(DataSet data)
            : base(data, "LFS_JUNCTION_LINER2_COMMENT")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SectionTDS();
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
        public void Insert(Guid id, int refId, int companyId, DateTime dateTime_, int loginId, string comment, bool deleted, bool toHistory)
        {
            SectionTDS.LFS_JUNCTION_LINER2_COMMENTRow lfsJunctionLiner2CommentRow = ((SectionTDS.LFS_JUNCTION_LINER2_COMMENTDataTable)Table).NewLFS_JUNCTION_LINER2_COMMENTRow();

            lfsJunctionLiner2CommentRow.ID = id;
            lfsJunctionLiner2CommentRow.RefID = refId;
            lfsJunctionLiner2CommentRow.COMPANY_ID = companyId;
            lfsJunctionLiner2CommentRow.CommentID = GetNewCommentId();
            lfsJunctionLiner2CommentRow.DateTime_ = dateTime_;
            lfsJunctionLiner2CommentRow.LoginID = loginId;
            lfsJunctionLiner2CommentRow.Comment = comment.Trim();
            lfsJunctionLiner2CommentRow.Deleted = deleted;
            lfsJunctionLiner2CommentRow.ToHistory = toHistory;

            ((SectionTDS.LFS_JUNCTION_LINER2_COMMENTDataTable)Table).AddLFS_JUNCTION_LINER2_COMMENTRow(lfsJunctionLiner2CommentRow);
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
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="loginId">loginId</param>
        /// <param name="comment">comment</param>
        /// <param name="deleted">deleted</param>
        /// <param name="adminPermission">add Permission</param>
        /// <param name="toHistory">toHistory</param>
        public void Update(Guid id, int refId, int companyId, int commentId, DateTime dateTime_, int loginId, string comment, bool deleted, bool adminPermission, bool toHistory)
        {
            SectionTDS.LFS_JUNCTION_LINER2_COMMENTRow lfsJunctionLiner2CommentRow = GetRow(id, refId, companyId, commentId);

            if (adminPermission)
            {
                lfsJunctionLiner2CommentRow.Comment = comment.Trim();
                lfsJunctionLiner2CommentRow.ToHistory = toHistory;
            }
            else
            {
                if (lfsJunctionLiner2CommentRow.LoginID == loginId)
                {
                    lfsJunctionLiner2CommentRow.Comment = comment.Trim();
                    lfsJunctionLiner2CommentRow.ToHistory = toHistory;
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

            foreach (SectionTDS.LFS_JUNCTION_LINER2_COMMENTRow row in (SectionTDS.LFS_JUNCTION_LINER2_COMMENTDataTable)Table)
            {
                loginGateway.LoadByLoginId(row.LoginID, row.COMPANY_ID);
                row.UserFullName = loginGateway.GetLastName(row.LoginID, row.COMPANY_ID) + " " + loginGateway.GetFirstName(row.LoginID, row.COMPANY_ID);
                row.CreationDateTime = row.DateTime_.ToString();
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
            SectionTDS.LFS_JUNCTION_LINER2_COMMENTRow lfsJunctionLiner2CommentRow = GetRow(id, refId, companyId, commentId);
            
            if (adminPermission)
            {
                lfsJunctionLiner2CommentRow.Deleted = true;
            }
            else
            {
                if (lfsJunctionLiner2CommentRow.LoginID == loginId)
                {
                    lfsJunctionLiner2CommentRow.Deleted = true;
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
        /// Delete all comments for  a jliner
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllCommentsForAJliner(Guid id, int refId, int companyId)
        {
            foreach (SectionTDS.LFS_JUNCTION_LINER2_COMMENTRow row in (SectionTDS.LFS_JUNCTION_LINER2_COMMENTDataTable)Table)
            {
                if ((row.ID == id) && (row.RefID == refId) && (row.COMPANY_ID == companyId))
                {
                    row.Deleted = true;
                }
            }
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

            foreach (SectionTDS.LFS_JUNCTION_LINER2_COMMENTRow row in (SectionTDS.LFS_JUNCTION_LINER2_COMMENTDataTable)Table)
            {
                if ((row.ID == id) && (row.RefID == refId) && (row.COMPANY_ID == companyId))
                {
                    // ... Get user name
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(row.LoginID, row.COMPANY_ID);
                    string user = loginGateway.GetLastName(row.LoginID, row.COMPANY_ID) + " " + loginGateway.GetFirstName(row.LoginID, row.COMPANY_ID);

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
        public void transferToHistory(int loginId, bool adminPermission, JlinerHistory jlinerHistory)
        {
            foreach (SectionTDS.LFS_JUNCTION_LINER2_COMMENTRow commentRow in (SectionTDS.LFS_JUNCTION_LINER2_COMMENTDataTable)Table)
            {
                if (adminPermission)
                {
                    if ((commentRow.ToHistory) && (!commentRow.Deleted))
                    {
                        // Insert to history
                        jlinerHistory.Insert(commentRow.ID, commentRow.RefID, commentRow.COMPANY_ID, commentRow.DateTime_, commentRow.LoginID, commentRow.Comment, commentRow.Deleted, false);

                        // Delete from comments
                        commentRow.Deleted = true;
                    }
                }
                else
                {
                    if (commentRow.LoginID == loginId)
                    {
                        if ((commentRow.ToHistory) && (!commentRow.Deleted))
                        {
                            // Insert to history
                            jlinerHistory.Insert(commentRow.ID, commentRow.RefID, commentRow.COMPANY_ID, commentRow.DateTime_, commentRow.LoginID, commentRow.Comment, commentRow.Deleted, false);

                            // Delete from comments
                            commentRow.Deleted = true;
                        }
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

            foreach (SectionTDS.LFS_JUNCTION_LINER2_COMMENTRow row in (SectionTDS.LFS_JUNCTION_LINER2_COMMENTDataTable)Table)
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
        /// <returns>SectionTDS.LFS_JUNCTION_LINER2_COMMENTRow</returns>
        private SectionTDS.LFS_JUNCTION_LINER2_COMMENTRow GetRow(Guid id, int refId, int companyId, int commentId)
        {
            SectionTDS.LFS_JUNCTION_LINER2_COMMENTRow row = ((SectionTDS.LFS_JUNCTION_LINER2_COMMENTDataTable)Table).FindByIDRefIDCOMPANY_IDCommentID(id, refId, companyId, commentId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Jliner.Jliner.GetRow");
            }

            return row;
        }



    }
}
