using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.FleetManagement.Common
{
    /// <summary>
    /// FmViewTypeListGateway
    /// </summary>
    public class FmViewTypeListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmViewTypeListGateway()
            : base("LFS_FM_VIEW_TYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmViewTypeListGateway(DataSet data)
            : base(data, "LFS_FM_VIEW_TYPE")
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
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_FMVIEWTYPELISTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}