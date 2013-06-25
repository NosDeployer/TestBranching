using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.DA.RAF;


namespace LiquiForce.LFSLive.BL.CWP.Jliner
{
    /// <summary>
    /// JlinerHistory
    /// </summary>
    public class JlinerHistory : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlinerHistory()
            : base("LFS_JUNCTION_LINER2_HISTORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlinerHistory(DataSet data)
            : base(data, "LFS_JUNCTION_LINER2_HISTORY")
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
        public void Insert(Guid id, int refId, int companyId, DateTime dateTime_, int loginId, string history, bool deleted, bool toComments)
        {
            SectionTDS.LFS_JUNCTION_LINER2_HISTORYRow lfsJunctionLiner2HistoryRow = ((SectionTDS.LFS_JUNCTION_LINER2_HISTORYDataTable)Table).NewLFS_JUNCTION_LINER2_HISTORYRow();

            lfsJunctionLiner2HistoryRow.ID = id;
            lfsJunctionLiner2HistoryRow.RefID = refId;
            lfsJunctionLiner2HistoryRow.COMPANY_ID = companyId;
            lfsJunctionLiner2HistoryRow.HistoryID = GetNewHistoryId();
            lfsJunctionLiner2HistoryRow.DateTime_ = dateTime_;
            lfsJunctionLiner2HistoryRow.LoginID = loginId;
            lfsJunctionLiner2HistoryRow.History = history.Trim();
            lfsJunctionLiner2HistoryRow.Deleted = deleted;
            lfsJunctionLiner2HistoryRow.ToComments = toComments;

            ((SectionTDS.LFS_JUNCTION_LINER2_HISTORYDataTable)Table).AddLFS_JUNCTION_LINER2_HISTORYRow(lfsJunctionLiner2HistoryRow);

        }



        /// <summary>
        /// Insert a new comment to history (direct to DB)
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="historyId">historyId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="loginId">loginId</param>
        /// <param name="history">history</param>        
        /// <param name="deleted">deleted</param>        
        /// <returns></returns>
        public void InsertDirect(Guid id, int refId, int companyId, int historyId, DateTime? dateTime_, int loginId, string history, bool deleted)
        {
            JlinerHistoryGateway jlinerHistoryGateway = new JlinerHistoryGateway(null);
            jlinerHistoryGateway.Insert(id, refId, companyId, historyId, dateTime_, loginId, history, deleted);
        }



        /// <summary>
        /// Update jliner
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="historyId">historyId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="loginId">loginId</param>
        /// <param name="history">history</param>
        /// <param name="deleted">deleted</param>
        /// <param name="adminPermission">adminPermission</param>
        /// <param name="toComments"> to comments</param>
        public void Update(Guid id, int refId, int companyId, int historyId, DateTime dateTime_, int loginId, string history, bool deleted, bool adminPermission, bool toComments)
        {
            SectionTDS.LFS_JUNCTION_LINER2_HISTORYRow lfsJunctionLiner2HistoryRow = GetRow(id, refId, companyId, historyId);

            if (adminPermission)
            {
                lfsJunctionLiner2HistoryRow.History = history.Trim();
                lfsJunctionLiner2HistoryRow.ToComments = toComments;
            }
            else
            {
                if (lfsJunctionLiner2HistoryRow.LoginID == loginId)
                {
                    lfsJunctionLiner2HistoryRow.History = history.Trim();
                    lfsJunctionLiner2HistoryRow.ToComments = toComments;
                }
            }
        }



        /// <summary>
        /// Update direct
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalHistoryId">originalHistoryId</param>
        /// <param name="originalDateTime">originalDateTime</param>
        /// <param name="originalLoginId">originalLoginId</param>        
        /// <param name="originalHistory">originalHistory</param>        
        /// <param name="originalDeleted">originalDeleted</param>
        ///
        /// <param name="newId">newId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="originalHistoryId">originalHistoryId</param>
        /// <param name="newDateTime">newDateTime</param>
        /// <param name="newLoginId">newLoginId</param>                                
        /// <param name="newHistory">newHistory</param>       
        /// <param name="newDeleted">newDeleted</param>        
        public void UpdateDirect(Guid originalId, int originalRefId, int originalCompanyId, int originalHistoryId, DateTime? originalDateTime, int originalLoginId, string originalHistory, bool originalDeleted, Guid newId, int newRefId, int newCompanyId, int newHistoryId, DateTime? newDateTime, int newLoginId, string newHistory, bool newDeleted)
        {
            JlinerHistoryGateway jlinerHistoryGateway = new JlinerHistoryGateway(null);
            jlinerHistoryGateway.Update(originalId, originalRefId, originalCompanyId, originalHistoryId, originalDateTime, originalLoginId, originalHistory, originalDeleted, newId, newRefId, newCompanyId, newHistoryId, newDateTime, newLoginId, newHistory, newDeleted);
        }



        /// <summary>
        /// UpdateForProcess. Update the author, and date of each comment at history
        /// </summary>
        public void UpdateForProcess()
        {
            LoginGateway loginGateway = new LoginGateway();

            foreach (SectionTDS.LFS_JUNCTION_LINER2_HISTORYRow row in (SectionTDS.LFS_JUNCTION_LINER2_HISTORYDataTable)Table)
            {
                loginGateway.LoadByLoginId(row.LoginID, row.COMPANY_ID);
                row.UserFullName = loginGateway.GetLastName(row.LoginID, row.COMPANY_ID) + " " + loginGateway.GetFirstName(row.LoginID, row.COMPANY_ID);
                row.CreationDateTime = row.DateTime_.ToString();
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
            SectionTDS.LFS_JUNCTION_LINER2_HISTORYRow lfsJunctionLiner2HistoryRow = GetRow(id, refId, companyId, historyId);

            if (adminPermission)
            {
                lfsJunctionLiner2HistoryRow.Deleted = true;
            }
            else
            {
                if (lfsJunctionLiner2HistoryRow.LoginID == loginId)
                {
                    lfsJunctionLiner2HistoryRow.Deleted = true;
                }
            }
        }



        /// <summary>
        /// Delete all History for  a jliner
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllHistoryForAJliner(Guid id, int refId, int companyId)
        {
            foreach (SectionTDS.LFS_JUNCTION_LINER2_HISTORYRow row in (SectionTDS.LFS_JUNCTION_LINER2_HISTORYDataTable)Table)
            {
                if ((row.ID == id) && (row.RefID == refId) && (row.COMPANY_ID == companyId))
                {
                    row.Deleted = true;
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

            foreach (SectionTDS.LFS_JUNCTION_LINER2_HISTORYRow row in (SectionTDS.LFS_JUNCTION_LINER2_HISTORYDataTable)Table)
            {
                if ((row.ID == id) && (row.RefID == refId) && (row.COMPANY_ID == companyId))
                {
                    // ... Get user name
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(row.LoginID, row.COMPANY_ID);
                    string user = loginGateway.GetLastName(row.LoginID, row.COMPANY_ID) + " " + loginGateway.GetFirstName(row.LoginID, row.COMPANY_ID);

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
        /// DeleteDirect
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="historyId">historyId</param>
        public void DeleteDirect(Guid id, int refId, int companyId, int historyId)
        {
            JlinerHistoryGateway jlinerHistoryGateway = new JlinerHistoryGateway(null);
            jlinerHistoryGateway.Delete(id, refId, companyId, historyId);
        }



        /// <summary>
        /// Transfer to Comments
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <param name="adminPermission">admin Permission</param>
        /// <param name="jlinerComments">jlinerComments</param>
        public void transferToComments(int loginId, bool adminPermission, JlinerComments jlinerComments)
        {
            foreach (SectionTDS.LFS_JUNCTION_LINER2_HISTORYRow historyRow in (SectionTDS.LFS_JUNCTION_LINER2_HISTORYDataTable)Table)
            {
                if (adminPermission)
                {
                    if ((historyRow.ToComments) && (!historyRow.Deleted))
                    {                        
                        // Insert to comments
                        jlinerComments.Insert(historyRow.ID, historyRow.RefID, historyRow.COMPANY_ID, historyRow.DateTime_, historyRow.LoginID, historyRow.History, historyRow.Deleted, false);

                        // Delete from History
                        historyRow.Deleted = true;
                    }
                }
                else
                {
                    if (historyRow.LoginID == loginId)
                    {
                        if ((historyRow.ToComments) && (!historyRow.Deleted))
                        {
                            // Insert to comments
                            jlinerComments.Insert(historyRow.ID, historyRow.RefID, historyRow.COMPANY_ID, historyRow.DateTime_, historyRow.LoginID, historyRow.History, historyRow.Deleted, false);

                            // Delete from History
                            historyRow.Deleted = true;
                        }
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

            foreach (SectionTDS.LFS_JUNCTION_LINER2_HISTORYRow row in (SectionTDS.LFS_JUNCTION_LINER2_HISTORYDataTable)Table)
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
        /// <returns>SectionTDS.LFS_JUNCTION_LINER2_HISTORYRow</returns>
        private SectionTDS.LFS_JUNCTION_LINER2_HISTORYRow GetRow(Guid id, int refId, int companyId, int historyId)
        {
            SectionTDS.LFS_JUNCTION_LINER2_HISTORYRow row = ((SectionTDS.LFS_JUNCTION_LINER2_HISTORYDataTable)Table).FindByIDRefIDCOMPANY_IDHistoryID(id, refId, companyId, historyId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Jliner.JlinerHistory.GetRow");
            }

            return row;
        }



    }
}

