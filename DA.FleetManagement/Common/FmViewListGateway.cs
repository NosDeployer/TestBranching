using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.FleetManagement.Common
{
    /// <summary>
    /// FmViewListGateway
    /// </summary>
    public class FmViewListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmViewListGateway()
            : base("LFS_FM_VIEW")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public 
            FmViewListGateway(DataSet data)
            : base(data, "LFS_FM_VIEW")
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
        /// LoadByFmTypeGlobalViewType
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="viewType">viewType</param>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet LoadByFmTypeGlobalViewType(string fmType, string viewType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_FMVIEWLISTGATEWAY_LOADBYFMTYPEGLOGALTYPE", new SqlParameter("@fmType", fmType), new SqlParameter("@viewType", viewType), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByFmTypeLoginIdViewType
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="loginId">loginId</param>
        /// <param name="viewType">viewType</param>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet LoadByFmTypeLoginIdViewType(string fmType, int loginId, string viewType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_FMVIEWLISTGATEWAY_LOADBYFMTYPELOGINIDVIEWTYPE", new SqlParameter("@fmType", fmType), new SqlParameter("@loginId", loginId), new SqlParameter("@viewType", viewType), new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}