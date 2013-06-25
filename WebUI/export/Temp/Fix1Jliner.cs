using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.WebUI.export.Temp;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.BL.CWP.Jliner;

namespace LiquiForce.LFSLive.WebUI
{
    /// <summary>
    /// Fix1Jliner
    /// </summary>
    public class Fix1Jliner : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Fix1Jliner()
            : base("LFS_JUNCTION_LINER2")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Fix1Jliner(DataSet data)
            : base(data, "LFS_JUNCTION_LINER2")
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
        /// GetNumLats
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        public int GetNumLats(Guid id, int companyId)
        {
            int numLats = 0;

            foreach (Fix1TDS.LFS_JUNCTION_LINER2Row junctionLiner2Row in (Fix1TDS.LFS_JUNCTION_LINER2DataTable)Table)
            {
                if ((!junctionLiner2Row.Deleted) && (junctionLiner2Row.Issue != "Out Of Scope"))
                {
                    numLats++;
                }
            }
            return numLats;
        }



        /// <summary>
        /// GetNotLinedYet
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        public int GetNotLinedYet(Guid id, int companyId)
        {
            int notLinedYet = 0;

            foreach (Fix1TDS.LFS_JUNCTION_LINER2Row junctionLiner2Row in (Fix1TDS.LFS_JUNCTION_LINER2DataTable)Table)
            {
                if ((!junctionLiner2Row.Deleted) && (junctionLiner2Row.Issue != "Out Of Scope"))
                {
                    if (junctionLiner2Row.IsLinerInstalledNull()) notLinedYet++;
                }
            }

            return notLinedYet;
        }



        /// <summary>
        /// GetNotDelieredYet
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        public int GetNotDeliveredYet(Guid id, int companyId)
        {
            int notDeliveredYet = 0;

            foreach (Fix1TDS.LFS_JUNCTION_LINER2Row junctionLiner2Row in (Fix1TDS.LFS_JUNCTION_LINER2DataTable)Table)
            {
                if ((!junctionLiner2Row.Deleted) && (junctionLiner2Row.Issue != "Out Of Scope"))
                {
                    if (junctionLiner2Row.IsDeliveredNull()) notDeliveredYet++;
                }
            }

            return notDeliveredYet;
        }




        /// <summary>
        /// GetAllMeasured
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        public bool GetAllMeasured(Guid id, int companyId)
        {
            bool allMeasured = true;

            foreach (Fix1TDS.LFS_JUNCTION_LINER2Row junctionLiner2Row in (Fix1TDS.LFS_JUNCTION_LINER2DataTable)Table)
            {
                if ((!junctionLiner2Row.Deleted) && (junctionLiner2Row.Issue != "Out Of Scope"))
                {
                    if (junctionLiner2Row.IsMeasuredNull()) allMeasured = false;
                }
            }

            return allMeasured;
        }



        /// <summary>
        /// GetNotMeasuredYet
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        public int GetNotMeasuredYet(Guid id, int companyId)
        {
            int notMeasuredYet = 0;

            foreach (Fix1TDS.LFS_JUNCTION_LINER2Row junctionLiner2Row in (Fix1TDS.LFS_JUNCTION_LINER2DataTable)Table)
            {
                if ((!junctionLiner2Row.Deleted) && (junctionLiner2Row.Issue != "Out Of Scope"))
                {
                    if (junctionLiner2Row.IsMeasuredNull()) notMeasuredYet++;
                }
            }

            return notMeasuredYet;
        }



        /// <summary>
        /// LoadAll
        /// </summary>
        public void LoadAll()
        {
            Fix1JlinerGateway fix1JlinerGateway = new Fix1JlinerGateway(Data);
            fix1JlinerGateway.LoadAll();
            
           //Load comments and History
            UpdateCommentsHistory();
        }



        /// <summary>
        /// UpdateCommentsHistory
        /// </summary>
        public void UpdateCommentsHistory()
        {           
            foreach (Fix1TDS.LFS_JUNCTION_LINER2Row fix1Row in (Fix1TDS.LFS_JUNCTION_LINER2DataTable)Table)
            {
                Fix1JlinerCommentsGateway fix1JlinerCommentsGateway = new Fix1JlinerCommentsGateway();
                fix1JlinerCommentsGateway.LoadByIdRefIdCompanyId(fix1Row.ID, fix1Row.RefID, fix1Row.COMPANY_ID);
                Fix1JlinerComments fix1JlinerComments = new Fix1JlinerComments(fix1JlinerCommentsGateway.Data);

                string comments = fix1JlinerComments.GetAllComments(fix1Row.ID, fix1Row.RefID, fix1Row.COMPANY_ID, fix1JlinerCommentsGateway.Table.Rows.Count, "<br>");
                if (comments.Length > 0)
                {
                    fix1Row.Comments = comments;
                }
                else
                {
                    fix1Row.SetCommentsNull();
                }

                Fix1JlinerHistoryGateway fix1JlinerHistoryGateway = new Fix1JlinerHistoryGateway();
                fix1JlinerHistoryGateway.LoadByIdRefIdCompanyId(fix1Row.ID, fix1Row.RefID, fix1Row.COMPANY_ID);
                Fix1JlinerHistory fix1JlinerHistory = new Fix1JlinerHistory(fix1JlinerHistoryGateway.Data);

                string history = fix1JlinerHistory.GetAllHistory(fix1Row.ID, fix1Row.RefID, fix1Row.COMPANY_ID, fix1JlinerHistoryGateway.Table.Rows.Count, "<br>");
                if (history.Length > 0)
                {
                    fix1Row.History = history;
                }
                else
                {
                    fix1Row.SetHistoryNull();
                }
            }
         }



    }
}