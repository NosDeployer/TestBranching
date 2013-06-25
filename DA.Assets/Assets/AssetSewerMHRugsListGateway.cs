using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Assets.Assets
{
    /// <summary> 
    ///   AssetSewerMHRugsListGateway
    /// </summary>
    public class   AssetSewerMHRugsListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public   AssetSewerMHRugsListGateway()
            : base("AM_ASSET_SEWER_MH_RUGS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public   AssetSewerMHRugsListGateway(DataSet data)
            : base(data, "AM_ASSET_SEWER_MH_RUGS")
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
            FillDataWithStoredProcedure("LFS_ASSETS_ASSETSEWERMHRUGSLISTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}