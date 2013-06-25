using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkCommentTypeListGateway
    /// </summary>
    public class WorkCommentTypeListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkCommentTypeListGateway()
            : base("LFS_WORK_COMMENT_TYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkCommentTypeListGateway(DataSet data)
            : base(data, "LFS_WORK_COMMENT_TYPE")
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
        /// LoadByWorkType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns> Data </returns>
        public DataSet LoadByWorkType( int companyId, string workType)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKCOMMENTTYPELISTGATEWAY_LOADBYWORKTYPE",  new SqlParameter("@companyId", companyId), new SqlParameter("@workType", workType));
            return Data;
        }

    }
}
