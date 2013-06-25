using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.WebUI.export.Temp;

namespace LiquiForce.LFSLive.WebUI
{
    /// <summary>
    /// Fix1JlinerComments
    /// </summary>
    public class Fix1JlinerComments : TableModule
    {
    // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Fix1JlinerComments()
            : base("LFS_JUNCTION_LINER2_COMMENT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Fix1JlinerComments(DataSet data)
            : base(data, "LFS_JUNCTION_LINER2_COMMENT")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new Fix1TDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

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

            foreach (Fix1TDS.LFS_JUNCTION_LINER2_COMMENTRow row in (Fix1TDS.LFS_JUNCTION_LINER2_COMMENTDataTable)Table)
            {
                if ((row.ID == id) && (row.RefID == refId) && (row.COMPANY_ID == companyId))
                {
                    // ... Get user name
                    Fix1UserGateway fix1UserGateway = new Fix1UserGateway();
                    fix1UserGateway.LoadByLoginId(row.LoginID);
                    string user = fix1UserGateway.GetLastName(row.LoginID) + " " + fix1UserGateway.GetFirstName(row.LoginID);

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






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
        
        /// <summary>
        /// Get a single jliner. If not exists, raise an exception
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="refId">RefID</param>
        /// <param name="companyId">companyId</param>
        /// <param name="commentId"></param>
        /// <returns>Fix1TDS.LFS_JUNCTION_LINER2_COMMENTRow</returns>
        private Fix1TDS.LFS_JUNCTION_LINER2_COMMENTRow GetRow(Guid id, int refId, int companyId, int commentId)
        {
            Fix1TDS.LFS_JUNCTION_LINER2_COMMENTRow row = ((Fix1TDS.LFS_JUNCTION_LINER2_COMMENTDataTable)Table).FindByIDRefIDCOMPANY_IDCommentID(id, refId, companyId, commentId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Jliner.Jliner.GetRow");
            }

            return row;
        }



    }
}

