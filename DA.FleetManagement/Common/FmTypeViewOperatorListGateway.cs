using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.FleetManagement.Common
{
    /// <summary>
    /// FmTypeViewOperatorListGateway
    /// </summary>
    public class FmTypeViewOperatorListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmTypeViewOperatorListGateway()
            : base("LFS_FM_TYPE_VIEW_CONDITION_OPERATOR")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmTypeViewOperatorListGateway(DataSet data)
            : base(data, "LFS_FM_TYPE_VIEW_CONDITION_OPERATOR")
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
        /// LoadByType
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet LoadByType(string type, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_FMTYPEVIEWOPERATORLISTGATEWAY_LOADBYTYPE", new SqlParameter("@type", type), new SqlParameter("@companyId", companyId));
            return Data;
        }        



    }    
}