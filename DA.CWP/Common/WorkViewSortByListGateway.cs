using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// WorkViewSortByListGateway
    /// </summary>
    public class WorkViewSortByListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkViewSortByListGateway()
            : base("LFS_WORK_VIEW_FOR_DISPLAY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkViewSortByListGateway(DataSet data)
            : base(data, "LFS_WORK_VIEW_FOR_DISPLAY")
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
        /// LoadByWorkTypeInSortBy
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inSortBy">inSortBy</param>
        /// <returns> Data </returns>
        public DataSet LoadByWorkTypeInSortBy(string workType, int companyId, bool inSortBy)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWTYPELISTGATEWAY_LOADBYWORKTYPEINSORTBY", new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@inSortBy", inSortBy));
            return Data;
        }

    }
}
