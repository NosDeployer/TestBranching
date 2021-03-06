using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.RAF
{
    /// <summary>
    /// CompaniesGatewayRAF
    /// </summary>
    public class CompaniesGatewayRAF : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CompaniesGatewayRAF()
            : base("COMPANIES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CompaniesGatewayRAF(DataSet data)
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
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByCompaniesId(int companiesId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RAF_COMPANIESGATEWAY_LOADBYCOMPANIESID", new SqlParameter("@companiesId", companiesId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadAllByCompaniesId
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAllByCompaniesId(int companiesId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RAF_COMPANIESGATEWAY_LOADALLBYCOMPANIESID", new SqlParameter("@companiesId", companiesId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int companiesId)
        {
            string filter = string.Format("COMPANIES_ID = {0}", companiesId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];

                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.RAF.CompaniesGateway.GetRow");
            }
        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <returns>Name</returns>
        public string GetName(int companiesId)
        {
            return (string)GetRow(companiesId)["NAME"];
        }



        /// <summary>
        /// GetActive
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <returns>Active</returns>
        public bool GetActive(int companiesId)
        {
            return (bool)GetRow(companiesId)["ACTIVE"];
        }



    }
}
