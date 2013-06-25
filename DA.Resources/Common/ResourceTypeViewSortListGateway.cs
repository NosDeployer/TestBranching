using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Common
{
    /// <summary>
    /// ResourceTypeViewSortListGateway
    /// </summary>
    public class ResourceTypeViewSortListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceTypeViewSortListGateway()
            : base("LFS_RESOURCES_TYPE_VIEW_SORT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ResourceTypeViewSortListGateway(DataSet data)
            : base(data, "LFS_RESOURCES_TYPE_VIEW_SORT")
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
        /// LoadByResourceTypeCompanyId
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <returns></returns>
        public DataSet LoadByResourceTypeInFor(string resourceType, int companyId, bool inFor)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_RESOURCETYPEVIEWSORTLISTGATEWAY_LOADBYRESOURCETYPEINFOR", new SqlParameter("@resourceType", resourceType), new SqlParameter("@companyId", companyId), new SqlParameter("@inFor", inFor));
            return Data;
        }



    }
}