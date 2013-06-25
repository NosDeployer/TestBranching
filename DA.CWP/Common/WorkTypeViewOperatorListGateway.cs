using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// WorkTypeViewOperatorListGateway
    /// </summary>
    public class WorkTypeViewOperatorListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkTypeViewOperatorListGateway()
            : base("LFS_WORK_TYPE_VIEW_OPERATOR")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkTypeViewOperatorListGateway(DataSet data)
            : base(data, "LFS_WORK_TYPE_VIEW_OPERATOR")
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
        /// LoadByType
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <returns> Data </returns>
        public DataSet LoadByType(string type, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKTYPEVIEWOPERATORLISTGATEWAY_LOADBYTYPE", new SqlParameter("@type", type), new SqlParameter("@companyId", companyId));
            return Data;
        }        



    }    
}


