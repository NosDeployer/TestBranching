using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket;

namespace LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// SupportTicketNavigator
    /// </summary>
    public class SupportTicketNavigator : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SupportTicketNavigator()
            : base("SupportTicketNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SupportTicketNavigator(DataSet data)
            : base(data, "SupportTicketNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SupportTicketNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="whereClause">whereClause</param>
        /// <param name="orderByClause">orderByClause</param>
        /// <param name="conditionValue">conditionValue</param>
        /// <param name="conditionName">conditionName</param>
        /// <param name="textForSearch">textForSearch</param>
        /// <param name="companyId">companyId</param>
        public void Load(string whereClause, string orderByClause, string conditionValue, string conditionName, string textForSearch, int companyId)
        {
            SupportTicketNavigatorGateway supportTicketNavigatorGateway = new SupportTicketNavigatorGateway(Data);
            supportTicketNavigatorGateway.LoadWhereOrderBy(whereClause, orderByClause, conditionValue, conditionName, textForSearch);
        }


       
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="selected">selected</param>
        public void Update(int supportTicketId, bool selected)
        {
            SupportTicketNavigatorTDS.SupportTicketNavigatorRow supportTicketNavigatorRow = GetRow(supportTicketId);
            supportTicketNavigatorRow.Selected = selected;
        }



        /// <summary>
        /// GetPreviousId
        /// </summary>
        /// <param name="SupportTicketNavigatorTDS">SupportTicketNavigatorTDS</param>
        /// <param name="currentSupportTicketId">currentSupportTicketId</param>
        /// <returns>prevsupportTicketId</returns>
        public static int GetPreviousId(SupportTicketNavigatorTDS supportTicketNavigatorTDS, int currentSupportTicketId)
        {
            int prevSupportTicketId = currentSupportTicketId;

            for (int i = 0; i < supportTicketNavigatorTDS.SupportTicketNavigator.DefaultView.Count; i++)
            {
                if ((int)supportTicketNavigatorTDS.SupportTicketNavigator.DefaultView[i]["SupportTicketID"] == currentSupportTicketId)
                {
                    if (i == 0)
                    {
                        prevSupportTicketId = currentSupportTicketId;
                    }
                    else
                    {
                        prevSupportTicketId = (int)supportTicketNavigatorTDS.SupportTicketNavigator.DefaultView[i - 1]["SupportTicketID"];
                    }

                    break;
                }
               
            }

            return prevSupportTicketId;
        }



        /// <summary>
        /// GetNextId
        /// </summary>
        /// <param name="SupportTicketNavigatorTDS">SupportTicketNavigatorTDS</param>
        /// <param name="currentSupportTicketId">currentSupportTicketId</param>
        /// <returns>nextsupportTicketId</returns>
        public static int GetNextId(SupportTicketNavigatorTDS supportTicketNavigatorTDS, int currentSupportTicketId)
        {
            int nextSupportTicketId = currentSupportTicketId;

            for (int i = 0; i < supportTicketNavigatorTDS.SupportTicketNavigator.DefaultView.Count; i++)
            {
                if ((int)supportTicketNavigatorTDS.SupportTicketNavigator.DefaultView[i]["SupportTicketID"] == currentSupportTicketId)
                {
                    if (i == supportTicketNavigatorTDS.SupportTicketNavigator.DefaultView.Count - 1)
                    {
                        nextSupportTicketId = currentSupportTicketId;
                    }
                    else
                    {
                        nextSupportTicketId = (int)supportTicketNavigatorTDS.SupportTicketNavigator.DefaultView[i + 1]["SupportTicketID"];
                    }
                    break;
                }                
            }

            return nextSupportTicketId;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
       
        ///<summary>
        ///Get a single row. If not exists, raise an exception
        ///</summary>
        ///<param name="supportTicketId">supportTicketId</param>
        ///<returns>SupportTicketNavigatorTDS.SupportTicketNavigatorRow</returns>
        private SupportTicketNavigatorTDS.SupportTicketNavigatorRow GetRow(int supportTicketId)
        {
            SupportTicketNavigatorTDS.SupportTicketNavigatorRow row = ((SupportTicketNavigatorTDS.SupportTicketNavigatorDataTable)Table).FindBySupportTicketID(supportTicketId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicketNavigator.GetRow");
            }

            return row;
        }



    }
}