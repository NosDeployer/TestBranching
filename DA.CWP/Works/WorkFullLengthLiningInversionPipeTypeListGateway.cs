using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningInversionPipeTypeGateway
    /// </summary>
    public class WorkFullLengthLiningInversionPipeTypeListGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningInversionPipeTypeListGateway()
            : base("LFS_WORK_FULLLENGTHLINING_INVERSION_PIPETYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningInversionPipeTypeListGateway(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_INVERSION_PIPETYPE")
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
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet Load( int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKFULLLENGTHLININGINVERSIONPIPETYPELISTGATEWAY_LOAD",  new SqlParameter("@companyId", companyId));
            return Data;
        }
    }
}
