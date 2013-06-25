using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// WorkTypeViewSubAreaListGateway
    /// </summary>
    public class WorkTypeViewSubAreaListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkTypeViewSubAreaListGateway()
            : base("LFS_WORK_TYPE_VIEW_SUBAREA")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkTypeViewSubAreaListGateway(DataSet data)
            : base(data, "LFS_WORK_TYPE_VIEW_SUBAREA")
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
        /// LoadByWorkTypeProjectId
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="projectId">projectId</param>
        /// <returns></returns>
        public DataSet LoadByWorkTypeProjectId(string workType, int companyId, int projectId)
        {
            if (workType == "Junction Lining")
            {
                FillDataWithStoredProcedure("LFS_CWP_WORKTYPEVIEWSUBAREALISTGATEWAY_LOADSUBAREABYWORKTYPEPROJECTID", new SqlParameter("@workType", "Junction Lining Section"), new SqlParameter("@companyId", companyId), new SqlParameter("@projectId", projectId));
            }
            else
            {
                FillDataWithStoredProcedure("LFS_CWP_WORKTYPEVIEWSUBAREALISTGATEWAY_LOADSUBAREABYWORKTYPEPROJECTID", new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId), new SqlParameter("@projectId", projectId));
            }
            
            return Data;
        }



    }
}


