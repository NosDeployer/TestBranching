using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Company.Organization
{
    /// <summary>
    /// ProvinceGateway
    /// </summary>
    public class ProvinceGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProvinceGateway()
            : base("LFS_PROVINCE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProvinceGateway(DataSet data)
            : base(data, "LFS_PROVINCE")
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
        /// <param name="ProvinceId">ProvinceId</param>
        /// <returns>Data</returns>
        public DataSet LoadByProvinceId(Int64 provinceId)
        {
            FillDataWithStoredProcedure("LFS_COMPANY_PROVINCEGATEWAY_LOADBYPROVINCEID", new SqlParameter("@provinceId", provinceId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(Int64 provinceId)
        {
            string filter = string.Format("ProvinceID = {0}", provinceId);
            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Company.Organization.ProvinceGateway.GetRow");
            }
        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="provinceId">provinceId</param>
        /// <returns>Name</returns>
        public string GetName(Int64 provinceId)
        {
            return (string)GetRow(provinceId)["Name"];
        }



    }
}
