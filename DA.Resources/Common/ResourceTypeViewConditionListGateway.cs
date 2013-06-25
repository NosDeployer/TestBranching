using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Common
{
    /// <summary>
    /// ResourceTypeViewConditionListGateway
    /// </summary>
    public class ResourceTypeViewConditionListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceTypeViewConditionListGateway()
            : base("LFS_RESOURCES_TYPE_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ResourceTypeViewConditionListGateway(DataSet data)
            : base(data, "LFS_RESOURCES_TYPE_VIEW_CONDITION")
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
        /// LoadByResourceTypeInFor
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <returns> Data </returns>
        public DataSet LoadByResourceTypeInFor(string resourceType, int companyId, bool inFor)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_RESOURCETYPEVIEWCONDITIONLISTGATEWAY_LOADBYRESOURCETYPEINFOR", new SqlParameter("@resourceType", resourceType), new SqlParameter("@companyId", companyId), new SqlParameter("@inFor", inFor));
            return Data;
        }



        /// <summary>
        /// LoadByResourceTypeInForNoAdmin
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <returns> Data </returns>
        public DataSet LoadByResourceTypeInForNoAdmin(string resourceType, int companyId, bool inFor)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_RESOURCETYPEVIEWCONDITIONLISTGATEWAY_LOADBYRESOURCETYPEINFORNOADMIN", new SqlParameter("@resourceType", resourceType), new SqlParameter("@companyId", companyId), new SqlParameter("@inFor", inFor));
            return Data;
        }



        
    }    
}

