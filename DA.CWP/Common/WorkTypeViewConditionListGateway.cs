using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// WorkTypeViewConditionListGateway
    /// </summary>
    public class WorkTypeViewConditionListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkTypeViewConditionListGateway()
            : base("LFS_WORK_TYPE_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkTypeViewConditionListGateway(DataSet data)
            : base(data, "LFS_WORK_TYPE_VIEW_CONDITION")
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
        /// LoadByWorkTypeInFor
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <returns> Data </returns>
        public DataSet LoadByWorkTypeInFor(string workType, int companyId, bool inFor)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKTYPEVIEWCONDITIONLISTGATEWAY_LOADBYWORKTYPEINFOR", new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@inFor", inFor));
            return Data;
        }



        /// <summary>
        /// LoadByWorkTypeInView
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <returns> Data </returns>
        public DataSet LoadByWorkTypeInView(string workType, int companyId, bool inView)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKTYPEVIEWCONDITIONLISTGATEWAY_LOADBYWORKTYPEINVIEW", new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@inView", inView));
            return Data;
        }



    }    
}

