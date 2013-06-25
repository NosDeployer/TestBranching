using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.RAF
{
    /// <summary>
    /// CompaniesListGatewayRAF
    /// </summary>
    public class CompaniesListGatewayRAF : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CompaniesListGatewayRAF()
            : base("COMPANIES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CompaniesListGatewayRAF(DataSet data)
            : base(data, "COMPANIES")
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
        /// Load
        /// </summary>
        /// <returns> Data </returns>
        /// <param name="companyId">companyId</param>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_RAF_COMPANIESLISTGATEWAY_LOAD", new SqlParameter("@companyId", companyId)); 
            return Data;
        }



        /// <summary>
        /// LoadByCountryId
        /// </summary>
        /// <param name="countryId">countryId, new</param>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet LoadByCountryId(int countryId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RAF_COMPANIESLISTGATEWAY_LOADBYCOUNTRYID", new SqlParameter("@companyId", companyId), new SqlParameter("countryId", countryId)); 
            return Data;
        }



    }
}