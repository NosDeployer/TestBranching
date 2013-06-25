using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.JunctionLining
{
    /// <summary>
    /// FlatSectionJLAllComments
    /// </summary>
    public class FlatSectionJLAllComments: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlatSectionJLAllComments()
            : base("AllComments")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlatSectionJLAllComments(DataSet data)
            : base(data, "AllComments")
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
        /// LoadAllByJlWorkIdFlWorkIdRaWorkId
        /// </summary>
        /// <param name="jlWorkId">jlWorkId</param>
        /// <param name="flWorkId">flWorkId</param>
        /// <param name="raWorkId">raWorkId</param>
        /// <param name="companyId">companyId</param>
        public void LoadAllByJlWorkIdFlWorkIdRaWorkId(int jlWorkId, int flWorkId, int raWorkId, int companyId)
        {
            FlatSectionJLAllCommentsGateway flatSectionJLAllCommentsGateway = new FlatSectionJLAllCommentsGateway(Data);
            flatSectionJLAllCommentsGateway.LoadAllByJlWorkIdFlWorkIdRaWorkId(jlWorkId, flWorkId, raWorkId, companyId);
        }

        

        /// <summary>
        /// GetFLAndRAComments. 
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="numberOfComments">numberOfComments</param>
        /// <param name="enterString">enterString</param>
        /// <returns>a string with all comments separeted with  the enterString</returns>
        public string GetJLOrFLOrRAComments(int companyId, int numberOfComments, string enterString)
        {
            string comment = "";

            foreach (FlatSectionJlTDS.AllCommentsRow row in (FlatSectionJlTDS.AllCommentsDataTable)Table)
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


