using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Company.Organization
{
    /// <summary>
    /// CountyGateway
    /// </summary>
    public class CountyGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CountyGateway ()
            : base("LFS_COUNTY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CountyGateway(DataSet data)
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
        /// LoadByCountyId
        /// </summary>
        /// <param name="countyId">countyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByCountyId(Int64 countyId)
        {
            FillDataWithStoredProcedure("LFS_COMPANY_COUNTYGATEWAY_LOADBYCOUNTYID", new SqlParameter("@countyId", countyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="countyId">countyId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(Int64 countyId)
        {
            string filter = string.Format("CountyID = {0}", countyId);
            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Company.Organization.CountyGateway.GetRow");
            }
        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="countyId">countyId</param>
        /// <returns>Name</returns>
        public string GetName(Int64 countyId)
        {
            return (string)GetRow(countyId)["Name"];
        }



    }
}
