using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Company.Organization
{
    /// <summary>
    /// CityListGateway
    /// </summary>
    public class CityListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CityListGateway ()
            : base("LFS_CITY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CityListGateway(DataSet data)
            : base(data, "LFS_CITY")
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
            FillDataWithStoredProcedure("LFS_COMPANY_CITYLISTGATEWAY_LOADBYCOUNTYID", new SqlParameter("@countyId", countyId));
            return Data;
        }



    }
}
