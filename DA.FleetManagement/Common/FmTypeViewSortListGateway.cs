using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.FleetManagement.Common
{
    /// <summary>
    /// FmTypeViewSortListGateway
    /// </summary>
    public class FmTypeViewSortListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmTypeViewSortListGateway()
            : base("LFS_FM_TYPE_VIEW_SORT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmTypeViewSortListGateway(DataSet data)
            : base(data, "LFS_FM_TYPE_VIEW_SORT")
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
        /// LoadByFmTypeInFor
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByFmTypeInFor(string fmType, int companyId, bool inFor)
        {
            FillDataWithStoredProcedure("LFS_FM_FMTYPEVIEWSORTLISTGATEWAY_LOADBYFMTYPEINFOR", new SqlParameter("@fmType", fmType), new SqlParameter("@companyId", companyId), new SqlParameter("@inFor", inFor));
            return Data;
        }



    }
}