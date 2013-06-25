using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Resources.Subcontractors
{
    /// <summary>
    /// SubcontractorsListGateway
    /// </summary>
    public class SubcontractorsListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SubcontractorsListGateway()
            : base("LFS_RESOURCES_SUBCONTRACTORS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SubcontractorsListGateway(DataSet data)
            : base(data, "LFS_RESOURCES_SUBCONTRACTORS")
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
            FillDataWithStoredProcedure("LFS_RESOURCES_SUBCONTRACTORSLISTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}