using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.FleetManagement.Common
{
    /// <summary>
    /// FmTypeViewConditionItemListGateway
    /// </summary>
    public class FmTypeViewConditionItemListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmTypeViewConditionItemListGateway()
            : base("LFS_FM_TYPE_VIEW_CONDITION_ITEM")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmTypeViewConditionItemListGateway(DataSet data)
            : base(data, "LFS_FM_TYPE_VIEW_CONDITION_ITEM")
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
        /// LoadByFmTypeConditionId
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns> Data </returns>
        public DataSet LoadByFmTypeConditionId(string fmType, int companyId, int conditionId)
        {
            FillDataWithStoredProcedure("LFS_FM_FMTYPEVIEWCONDITIONITEMLISTGATEWAY_LOADBYFMTYPECONDITIONID", new SqlParameter("@fmType", fmType), new SqlParameter("@companyId", companyId), new SqlParameter("@conditionId", conditionId));
            return Data;
        }        



    }    
}