using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Resources.InsuranceCompanies
{
    /// <summary>
    /// InsuranceCompaniesListGateway
    /// </summary>
    public class InsuranceCompaniesListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceCompaniesListGateway()
            : base("LFS_RESOURCES_INSURANCE_COMPANIES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public InsuranceCompaniesListGateway(DataSet data)
            : base(data, "LFS_RESOURCES_INSURANCE_COMPANIES")
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
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_INSURANCECOMPANIESLISTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}