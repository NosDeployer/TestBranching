using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// WorkTypeViewConditionItemListGateway
    /// </summary>
    public class WorkTypeViewConditionItemListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkTypeViewConditionItemListGateway()
            : base("LFS_WORK_TYPE_VIEW_CONDITION_ITEM")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkTypeViewConditionItemListGateway(DataSet data)
            : base(data, "LFS_WORK_TYPE_VIEW_CONDITION_ITEM")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DataSet();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            _adapter = new SqlDataAdapter("", DB.Connection);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByWorkTypeConditionId
        /// </summary>
        /// <param name="workType">workType</param>        
        /// <param name="conditionId">conditionId</param>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet LoadByWorkTypeConditionId(string workType, int conditionId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKTYPEVIEWCONDITIONITEMLISTGATEWAY_LOADBYWORKTYPECONDITIONID", new SqlParameter("@workType", workType), new SqlParameter("@conditionId", conditionId), new SqlParameter("@companyId", companyId));
            return Data;
        }        



    }    
}


