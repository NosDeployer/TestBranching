using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Assets.Assets
{
    /// <summary>
    /// MaterialTypeListGateway
    /// </summary>
    public class MaterialTypeListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialTypeListGateway() : base("AM_MATERIAL_TYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialTypeListGateway(DataSet data) : base(data, "AM_MATERIAL_TYPE")
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
            FillDataWithStoredProcedure("LFS_ASSETS_MATERIALTYPELISTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }

    }
}
