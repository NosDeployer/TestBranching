using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Services.Services
{
    /// <summary>
    /// ServiceGateway
    /// </summary>
    public class ServiceGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceGateway()
            : base("LFS_SERVICE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServiceGateway(DataSet data)
            : base(data, "LFS_SERVICE")
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
        /// <returns>Data</returns>
        /// <param name="companyId">companyId</param>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_SERVICES_SERVICEGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByServiceId
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>        
        public DataSet LoadByServiceId(int serviceId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_SERVICES_SERVICEGATEWAY_LOADBYSERVICEID", new SqlParameter("@serviceId", serviceId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow. If not exist, raise an exception.
        /// </summary>
        /// <param name="ServiceId">serviceId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int serviceId)
        {
            string filter = string.Format("ServiceID = {0}", serviceId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];

                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Services.Services.ServiceGateway.GetRow");
            }
        }



        /// <summary>
        /// GetName. If row not exist, raise an exception.
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>Name</returns>
        public string GetName(int serviceId)
        {
            return (string)GetRow(serviceId)["Name"];
        }



    }
}
