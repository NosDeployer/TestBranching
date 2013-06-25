using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Assets.Assets
{
    /// <summary>AssetSewerSectionListGateway
    /// AssetSewerSectionListGateway
    /// </summary>
    public class AssetSewerSectionListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AssetSewerSectionListGateway()
            : base("AM_ASSET_SEWER_SECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AssetSewerSectionListGateway(DataSet data)
            : base(data, "AM_ASSET_SEWER_SECTION")
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
        /// LoadByProjectIdWorkType
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet LoadByProjectIdWorkType(int projectId, string workType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_ASSET_SEWER_SECTION_LISTGATEWAY_LOADBYPROJECTIDWORKTYPE", new SqlParameter("@projectId", projectId), new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}