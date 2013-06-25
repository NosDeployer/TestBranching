using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Company.Organization
{
    /// <summary>
    /// CountryGateway
    /// </summary>
    public class CountryGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CountryGateway()
            : base("LFS_COUNTRY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CountryGateway(DataSet data)
            : base(data, "LFS_COUNTRY")
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
        public DataSet LoadByCountryId(Int64 countryId)
        {
            FillDataWithStoredProcedure("LFS_COMPANY_COUNTRYGATEWAY_LOADBYCOUNTRYID", new SqlParameter("@countryId", countryId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(Int64 countryId)
        {
            string filter = string.Format("CountryID = {0}", countryId);
            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Company.Organization.CountryGateway.GetRow");
            }
        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <returns>Name</returns>
        public string GetName(Int64 countryId)
        {
            return (string)GetRow(countryId)["Name"];
        }



        /// <summary>
        /// GetIdForProjects
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <returns>idForProjects or EMPTY</returns>
        public string GetIdForProjects(Int64 countryId)
        {
            if (GetRow(countryId).IsNull("IdForProjects"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(countryId)["IdForProjects"];
            }
        }



    }
}
