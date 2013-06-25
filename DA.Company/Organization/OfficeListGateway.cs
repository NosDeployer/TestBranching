using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Company.Organization
{
    /// <summary>
    /// OfficeListGateway
    /// </summary>
    public class OfficeListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public OfficeListGateway() : base("LFS_OFFICE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public OfficeListGateway(DataSet data) : base(data, "LFS_OFFICE")
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
        /// <param name="CountryId">CountryId</param>
        /// <returns>Data</returns>
        public DataSet LoadByCountryId(int countryId)
        {
            FillDataWithStoredProcedure("LFS_COMPANY_OFFICELISTGATEWAY_LOADBYCOUNTRYID", new SqlParameter("@countryId", countryId));
            return Data;
        }



    }
}
