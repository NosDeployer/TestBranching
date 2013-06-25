using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.Jliner
{
    /// <summary>
    /// FlatSectionJlinerJuntionLiner2History
    /// </summary>
    public class FlatSectionJlinerJuntionLiner2History : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlatSectionJlinerJuntionLiner2History()
            : base("JuntionLiner2History")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlatSectionJlinerJuntionLiner2History(DataSet data)
            : base(data, "JuntionLiner2History")
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
        /// Insert a new comment to History
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="loginId">loginId</param>
        /// <param name="history">history</param>
        /// <param name="deleted">deleted</param>
        /// <param name="toComments">toComments</param>
        /// <param name="adminPermission">adminPermission</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(Guid id, int refId, int companyId, DateTime dateTime_, int loginId, string history, bool deleted, bool toComments, bool inDatabase)
        {
            FlatSectionJlinerTDS.JuntionLiner2HistoryRow historyRow = ((FlatSectionJlinerTDS.JuntionLiner2HistoryDataTable)Table).NewJuntionLiner2HistoryRow();

            historyRow.ID = id;
            historyRow.RefID = refId;
            historyRow.COMPANY_ID = companyId;
            historyRow.HistoryID = GetNewHistoryId();
            historyRow.DateTime_ = dateTime_;
            historyRow.LoginID = loginId;
            historyRow.History = history.Trim();
            historyRow.Deleted = deleted;
            historyRow.toComments = toComments;
            historyRow.InDatabase = inDatabase;

            ((FlatSectionJlinerTDS.JuntionLiner2HistoryDataTable)Table).AddJuntionLiner2HistoryRow(historyRow);
        }


        
        /// <summary>
        /// Update jliner
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="historyId">historyId</param>        
        /// <param name="loginId">loginId</param>
        /// <param name="history">history</param>
        /// <param name="deleted">deleted</param>
        /// <param name="adminPermission">adminPermission</param>
        /// <param name="toComments"> to comments</param>
        public void Update(Guid id, int refId, int companyId, int historyId, int loginId, string history, bool deleted, bool adminPermission, bool toComments)
        {
            FlatSectionJlinerTDS.JuntionLiner2HistoryRow historyRow = GetRow(id, refId, companyId, historyId);

            if (adminPermission)
            {
                historyRow.History = history.Trim();
                historyRow.toComments = toComments;
            }
            else
            {
                if (historyRow.LoginID == loginId)
                {
                    historyRow.History = history.Trim();
                    historyRow.toComments = toComments;
                }
            }
        }



        /// <summary>
        /// UpdateForProcess. Update the author, and date of each comment at history
        /// </summary>
        public void UpdateForProcess()
        {
            LoginGateway loginGateway = new LoginGateway();

            foreach (FlatSectionJlinerTDS.JuntionLiner2HistoryRow row in (FlatSectionJlinerTDS.JuntionLiner2HistoryDataTable)Table)
            {
                loginGateway.LoadByLoginId(row.LoginID, row.COMPANY_ID);
                row.UserFullName = loginGateway.GetLastName(row.LoginID, row.COMPANY_ID) + " " + loginGateway.GetFirstName(row.LoginID, row.COMPANY_ID);
            }
        }



        /// <summary>
        /// Delete one history
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="commentId">historyId</param>
        /// <param name="loginId">loginId</param>
        /// <param name="adminPermission">adminPermission</param>
        public void Delete(Guid id, int refId, int companyId, int historyId, int loginId, bool adminPermission)
        {
            FlatSectionJlinerTDS.JuntionLiner2HistoryRow historyRow = GetRow(id, refId, companyId, historyId);

            if (adminPermission)
            {
                historyRow.Deleted = true;
            }
            else
            {
                if (historyRow.LoginID == loginId)
                {
                    historyRow.Deleted = true;
                }
            }
        }



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

            foreach (FlatSectionJlinerTDS.JuntionLiner2HistoryRow row in (FlatSectionJlinerTDS.JuntionLiner2HistoryDataTable)Table)
            {
                if ((row.ID == id) && (row.RefID == refId) && (row.COMPANY_ID == companyId))
                {
                    // ... Get user name
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(row.LoginID, companyId);
                    string user = loginGateway.GetLastName(row.LoginID, companyId) + " " + loginGateway.GetFirstName(row.LoginID, companyId);

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



        /// <summary>
        /// Transfer to Comments
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <param name="adminPermission">admin Permission</param>
        /// <param name="jlinerComments">jlinerComments</param>
        public void transferToComments(int loginId, bool adminPermission, FlatSectionJlinerJuntionLiner2Comment jlinerComments)
        {
            foreach (FlatSectionJlinerTDS.JuntionLiner2HistoryRow historyRow in (FlatSectionJlinerTDS.JuntionLiner2HistoryDataTable)Table)
            {
                if (adminPermission)
                {
                    if ((historyRow.toComments) && (!historyRow.Deleted))
                    {
                        // Insert to comments
                        jlinerComments.Insert(historyRow.ID, historyRow.RefID, historyRow.COMPANY_ID, historyRow.DateTime_, historyRow.LoginID, historyRow.History, historyRow.Deleted, false, false);

                        // Delete from History
                        historyRow.Deleted = true;
                    }
                }
                else
                {
                    if (historyRow.LoginID == loginId)
                    {
                        if ((historyRow.toComments) && (!historyRow.Deleted))
                        {
                            // Insert to comments
                            jlinerComments.Insert(historyRow.ID, historyRow.RefID, historyRow.COMPANY_ID, historyRow.DateTime_, historyRow.LoginID, historyRow.History, historyRow.Deleted, false, false);

                            // Delete from History
                            historyRow.Deleted = true;
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

            if (jlinerChanges.JuntionLiner2History.Rows.Count > 0)
            {
                FlatSectionJlinerJuntionLiner2HistoryGateway flatSectionJlinerJuntionLiner2HistoryGateway = new FlatSectionJlinerJuntionLiner2HistoryGateway(jlinerChanges);

                foreach (FlatSectionJlinerTDS.JuntionLiner2HistoryRow row in (FlatSectionJlinerTDS.JuntionLiner2HistoryDataTable)jlinerChanges.JuntionLiner2History)
                {
                    // Insert new comments 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        JlinerHistory jlinerHistory = new JlinerHistory(null);
                        jlinerHistory.InsertDirect(row.ID, row.RefID, companyId, row.HistoryID, row.DateTime_, row.LoginID, row.History, row.Deleted);
                    }
                    
                    // Update comments
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int refId = row.RefID;
                        int historyId = row.HistoryID;

                        // original values
                        int originalLoginId = flatSectionJlinerJuntionLiner2HistoryGateway.GetLoginIDOriginal(id, refId, companyId, historyId);
                        DateTime? originalDateTime = null; if (flatSectionJlinerJuntionLiner2HistoryGateway.GetDateTime_Original(id, refId, companyId, historyId) != null) originalDateTime = flatSectionJlinerJuntionLiner2HistoryGateway.GetDateTime_Original(id, refId, companyId, historyId);
                        string originalHistory = flatSectionJlinerJuntionLiner2HistoryGateway.GetHistoryOriginal(id, refId, companyId, historyId);

                        // new values
                        string newHistory = flatSectionJlinerJuntionLiner2HistoryGateway.GetComment(id, refId, companyId, historyId);

                        JlinerHistory jlinerHistory = new JlinerHistory(null);
                        jlinerHistory.UpdateDirect(id, refId, companyId, historyId, originalDateTime, originalLoginId, originalHistory, false, id, refId, companyId, historyId, originalDateTime, originalLoginId, newHistory, false);
                    }
                    
                    // Deleted lateral comments
                    if (row.Deleted)
                    {
                        JlinerHistory jlinerHistory = new JlinerHistory(null);
                        jlinerHistory.DeleteDirect(row.ID, row.RefID, companyId, row.HistoryID);
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetNewHistoryId
        /// </summary>
        /// <returns>New ID</returns>
        private int GetNewHistoryId()
        {
            int newHistoryId = 0;

            foreach (FlatSectionJlinerTDS.JuntionLiner2HistoryRow row in (FlatSectionJlinerTDS.JuntionLiner2HistoryDataTable)Table)
            {
                if (newHistoryId < row.HistoryID)
                {
                    newHistoryId = row.HistoryID;
                }
            }

            newHistoryId++;

            return newHistoryId;
        }



        /// <summary>
        /// Get a single jliner. If not exists, raise an exception
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="refId">RefID</param>
        /// <param name="companyId">companyId</param>
        /// <param name="historyId">historyId</param>
        /// <returns>FlatSectionJlinerTDS.LFS_JUNCTION_LINER2_HISTORYRow</returns>
        private FlatSectionJlinerTDS.JuntionLiner2HistoryRow GetRow(Guid id, int refId, int companyId, int historyId)
        {
            FlatSectionJlinerTDS.JuntionLiner2HistoryRow row = ((FlatSectionJlinerTDS.JuntionLiner2HistoryDataTable)Table).FindByIDRefIDCOMPANY_IDHistoryID(id, refId, companyId, historyId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Jliner.FlatSectionJlinerJunctionLiner2History.GetRow");
            }

            return row;
        }
    }
}
