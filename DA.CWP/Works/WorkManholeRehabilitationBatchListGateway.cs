using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    ///  WorkManholeRehabilitationBatchListGateway
    /// </summary>
    public class  WorkManholeRehabilitationBatchListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public  WorkManholeRehabilitationBatchListGateway()
            : base("LFS_WORK_MANHOLE_REHABILITATION_BATCH")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkManholeRehabilitationBatchListGateway(DataSet data)
            : base(data, "LFS_WORK_MANHOLE_REHABILITATION_BATCH")
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
            FillDataWithStoredProcedure("LFS_CWP_WORKMANHOLEREHABILITATIONBATCHLISTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



    }    
}