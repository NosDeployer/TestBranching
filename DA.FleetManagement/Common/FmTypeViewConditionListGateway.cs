using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.FleetManagement.Common
{
    /// <summary>
    /// FmTypeViewConditionListGateway
    /// </summary>
    public class FmTypeViewConditionListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmTypeViewConditionListGateway()
            : base("LFS_FM_TYPE_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmTypeViewConditionListGateway(DataSet data)
            : base(data, "LFS_FM_TYPE_VIEW_CONDITION")
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
        /// <returns> Data </returns>
        public DataSet LoadByFmTypeInFor(string fmType, int companyId, bool inFor)
        {
            FillDataWithStoredProcedure("LFS_FM_FMTYPEVIEWCONDITIONLISTGATEWAY_LOADBYFMTYPEINFOR", new SqlParameter("@fmType", fmType), new SqlParameter("@companyId", companyId), new SqlParameter("@inFor", inFor));
            return Data;
        }



        /// <summary>
        /// LoadByFmTypeInView
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <returns> Data </returns>
        public DataSet LoadByFmTypeInView(string fmType, int companyId, bool inView)
        {
            FillDataWithStoredProcedure("LFS_FM_FMTYPEVIEWCONDITIONLISTGATEWAY_LOADBYFMTYPEINVIEW", new SqlParameter("@fmType", fmType), new SqlParameter("@companyId", companyId), new SqlParameter("@inView", inView));
            return Data;
        }



    }
}