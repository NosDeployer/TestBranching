using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Company.Organization
{
    /// <summary>
    /// CityGateway
    /// </summary>
    public class CityGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CityGateway ()
            : base("LFS_CITY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CityGateway(DataSet data)
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
        /// LoadByCityId
        /// </summary>
        /// <param name="CityId">CityId</param>
        /// <returns>Data</returns>
        public DataSet LoadByCityId(Int64 cityId)
        {
            FillDataWithStoredProcedure("LFS_COMPANY_CITYGATEWAY_LOADBYCITYID", new SqlParameter("@cityId", cityId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="cityId">cityId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(Int64 cityId)
        {
            string filter = string.Format("CityID = {0}", cityId);
            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Company.Organization.CityGateway.GetRow");
            }
        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="cityId">cityId</param>
        /// <returns>Name</returns>
        public string GetName(Int64 cityId)
        {
            return (string)GetRow(cityId)["Name"];
        }


      
    }
}
