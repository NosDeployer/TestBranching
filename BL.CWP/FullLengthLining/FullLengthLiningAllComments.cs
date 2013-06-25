using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FullLengthLiningCommentDetails
    /// </summary>
    public class FullLengthLiningAllComments : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FullLengthLiningAllComments()
            : base("AllComments")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FullLengthLiningAllComments(DataSet data)
            : base(data, "AllComments")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FullLengthLiningTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllByFlWorkIdRaWorkId
        /// </summary>
        /// <param name="flWorkId">flWorkId</param>
        /// <param name="raWorkId">raWorkId</param>
        /// <param name="companyId">companyId</param>
        public void LoadAllByFlWorkIdRaWorkId(int flWorkId, int raWorkId, int companyId)
        {
            FullLengthLiningAllCommentsGateway fullLengthLiningAllCommentsGateway = new FullLengthLiningAllCommentsGateway(Data);                     
            fullLengthLiningAllCommentsGateway.LoadAllByJlWorkIdRaWorkId(flWorkId, raWorkId, companyId);
        }

        

        /// <summary>
        /// GetFLAndRAComments. 
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="numberOfComments">numberOfComments</param>
        /// <param name="enterString">enterString</param>
        /// <returns>a string with all comments separeted with  the enterString</returns>
        public string GetFLOrRAComments(int companyId, int numberOfComments, string enterString)
        {
            string comment = "";

            foreach (FullLengthLiningTDS.AllCommentsRow row in (FullLengthLiningTDS.AllCommentsDataTable)Table)
            {                
                // ... Get user name
                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadAllByLoginId(row.UserID, row.COMPANY_ID);
                string user = loginGateway.GetLastName(row.UserID, row.COMPANY_ID) + " " + loginGateway.GetFirstName(row.UserID, row.COMPANY_ID);

                // ... Form the comment string
                string rowComment = ""; if (!row.IsCommentNull()) rowComment = row.Comment; else rowComment = "( None )";
                comment = comment + row.DateTime_ + " (" + user.Trim() + ")";
                if (!row.IsWorkTypeNull()) comment = comment + ", Created At: " + row.WorkType;
                comment = comment + ", Type: " + row.Type;                    
                comment = comment + ", Subject: " + row.Subject + enterString;
                comment = comment + "Comment: " + rowComment;
              

                // Insert enter when correspond
                if (numberOfComments > 1)
                {
                    comment = comment + enterString + enterString;
                    numberOfComments--;
                }
            }
            return (comment);
        }




    }
}


