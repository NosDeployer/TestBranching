using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.WebUI.export.Temp;

namespace LiquiForce.LFSLive.WebUI
{
    /// <summary>
    /// Fix1JlinerHistory
    /// </summary>
    public class Fix1JlinerHistory : TableModule
    {
    // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Fix1JlinerHistory()
            : base("LFS_JUNCTION_LINER2_HISTORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Fix1JlinerHistory(DataSet data)
            : base(data, "LFS_JUNCTION_LINER2_HISTORY")
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
        /// GetAllHistory. 
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="numberOfComments">numberOfComments</param>
        /// <param name="enterString">enterString</param>
        /// <returns>a string with all comments at history separeted with  the enterString</returns>
        public string GetAllHistory(Guid id, int refId, int companyId, int numberOfComments, string enterString)
        {
            string history = "";

            foreach (Fix1TDS.LFS_JUNCTION_LINER2_HISTORYRow row in (Fix1TDS.LFS_JUNCTION_LINER2_HISTORYDataTable)Table)
            {
                if ((row.ID == id) && (row.RefID == refId) && (row.COMPANY_ID == companyId))
                {
                    // ... Get user name
                    Fix1UserGateway fix1UserGateway = new Fix1UserGateway();
                    fix1UserGateway.LoadByLoginId(row.LoginID);
                    string user = fix1UserGateway.GetLastName(row.LoginID) + " " + fix1UserGateway.GetFirstName(row.LoginID);

                    // ... Form the comment string
                    history = history + row.DateTime_ + "  ( " + user.Trim() + " )" + enterString + row.History;
                }

                // Insert enter when correspond
                if (numberOfComments > 1)
                {
                    history = history + enterString + enterString;
                    numberOfComments--;
                }
            }
            return (history);
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
        /// <param name="historyId">historyId</param>
        /// <returns>Fix1TDS.LFS_JUNCTION_LINER2_HISTORYRow</returns>
        private Fix1TDS.LFS_JUNCTION_LINER2_HISTORYRow GetRow(Guid id, int refId, int companyId, int historyId)
        {
            Fix1TDS.LFS_JUNCTION_LINER2_HISTORYRow row = ((Fix1TDS.LFS_JUNCTION_LINER2_HISTORYDataTable)Table).FindByIDRefIDCOMPANY_IDHistoryID(id, refId, companyId, historyId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Jliner.JlinerHistory.GetRow");
            }

            return row;
        }



    }
}


