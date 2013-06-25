using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Company.Organization
{
    /// <summary>
    /// ProvinceListGateway
    /// </summary>
    public class ProvinceListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProvinceListGateway() : base("LFS_PROVINCE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProvinceListGateway(DataSet data) : base(data, "LFS_PROVINCE")
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
        /// LoadByCountryId
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <returns>Data</returns>
        public DataSet LoadByCountryId(Int64 countryId)
        {
            FillDataWithStoredProcedure("LFS_COMPANY_PROVINCELISTGATEWAY_LOADBYCOUNTRYID", new SqlParameter("@countryId", countryId));
            return Data;
        }



    }
}
