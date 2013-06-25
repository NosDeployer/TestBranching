using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Company.Organization
{
    // ////////////////////////////////////////////////////////////////////////
    // CONSTRUCTORS
    //
    public class CountyListGateway : DataTableGateway
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CountyListGateway()
            : base("LFS_COUNTY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CountyListGateway(DataSet data)
            : base(data, "LFS_COUNTY")
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
        /// LoadByProvinceId
        /// </summary>
        /// <param name="provinceId">provinceId</param>
        /// <returns>Data</returns>
        public DataSet LoadByProvinceId(int provinceId)
        {
            FillDataWithStoredProcedure("LFS_COMPANY_COUNTYLISTGATEWAY_LOADBYPROVINCEID", new SqlParameter("@provinceId", provinceId));
            return Data;
        }
    
    
    
    }
}
