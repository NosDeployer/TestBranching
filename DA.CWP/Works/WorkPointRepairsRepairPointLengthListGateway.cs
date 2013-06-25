using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkPointRepairsRepairPointLengthListGateway
    /// </summary>
    public class WorkPointRepairsRepairPointLengthListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkPointRepairsRepairPointLengthListGateway()
            : base("LFS_WORK_POINT_REPAIRS_REPAIRPOINT_LENGTH")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkPointRepairsRepairPointLengthListGateway(DataSet data)
            : base(data, "LFS_WORK_POINT_REPAIRS_REPAIRPOINT_LENGTH")
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
        /// <returns>Data</returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKPOINTREPAIRSREPAIRPOINTLENGTHLISTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }
    }

}
