using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// WorkTypeViewSortListGateway
    /// </summary>
    public class WorkTypeViewSortListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkTypeViewSortListGateway()
            : base("LFS_WORK_TYPE_VIEW_SORT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkTypeViewSortListGateway(DataSet data)
            : base(data, "LFS_WORK_TYPE_VIEW_SORT")
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
        /// <returns></returns>
        public DataSet LoadByWorkTypeInFor(string workType, int companyId, bool inFor)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKTYPEVIEWSORTLISTGATEWAY_LOADBYWORKTYPEINFOR", new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@inFor", inFor));
            return Data;
        }



    }
}

