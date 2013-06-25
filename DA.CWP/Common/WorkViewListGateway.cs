using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// WorkViewListGateway
    /// </summary>
    public class WorkViewListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkViewListGateway()
            : base("LFS_WORK_VIEW")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkViewListGateway(DataSet data)
            : base(data, "LFS_WORK_VIEW")
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
        /// LoadByWorkTypeGlobalViewType
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="viewType">viewType</param>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet LoadByWorkTypeGlobalViewType(string workType, string viewType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWLISTGATEWAY_LOADBYWORKTYPEGLOGALTYPE", new SqlParameter("@workType", workType), new SqlParameter("@viewType", viewType), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByWorkTypeLoginIdViewType
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="loginId">loginId</param>
        /// <param name="viewType">viewType</param>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet LoadByWorkTypeLoginIdViewType(string workType, int loginId, string viewType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWLISTGATEWAY_LOADBYWORKTYPELOGINIDVIEWTYPE", new SqlParameter("@workType", workType), new SqlParameter("@loginId", loginId), new SqlParameter("@viewType", viewType), new SqlParameter("@companyId", companyId));
            return Data;
        }

    }
}
