using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.JunctionLining
{
    /// <summary>
    /// FlatSectionJLAllHistory
    /// </summary>
    public class FlatSectionJLAllHistory: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlatSectionJLAllHistory()
            : base("AllHistory")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlatSectionJLAllHistory(DataSet data)
            : base(data, "AllHistory")
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
            FlatSectionJLAllHistoryGateway flatSectionJLAllHistoryGateway = new FlatSectionJLAllHistoryGateway(Data);
            flatSectionJLAllHistoryGateway.LoadAllByJlWorkIdFlWorkIdRaWorkId(jlWorkId, flWorkId, raWorkId, companyId);
        }

        

        /// <summary>
        /// GetFLAndRAHistory. 
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="numberOfHistory">numberOfHistory</param>
        /// <param name="enterString">enterString</param>
        /// <returns>a string with all historys separeted with  the enterString</returns>
        public string GetJLOrFLOrRAHistory(int companyId, int numberOfHistory, string enterString)
        {
            string history = "";

            foreach (FlatSectionJlTDS.AllHistoryRow row in (FlatSectionJlTDS.AllHistoryDataTable)Table)
            {                
                // ... Get user name
                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadAllByLoginId(row.UserID, row.COMPANY_ID);
                string user = loginGateway.GetLastName(row.UserID, row.COMPANY_ID) + " " + loginGateway.GetFirstName(row.UserID, row.COMPANY_ID);

                // ... Form the history string
                string rowHistory = ""; if (!row.IsHistoryNull()) rowHistory = row.History; else rowHistory = "( None )";
                history = history + row.DateTime_ + " (" + user.Trim() + ")";
                if (!row.IsWorkTypeNull()) history = history + ", Created At: " + row.WorkType;
                history = history + ", Type: " + row.Type;                    
                history = history + ", Subject: " + row.Subject + enterString;
                history = history + "Comment: " + rowHistory;
              

                // Insert enter when correspond
                if (numberOfHistory > 1)
                {
                    history = history + enterString + enterString;
                    numberOfHistory--;
                }
            }
            return (history);
        }




    }
}


