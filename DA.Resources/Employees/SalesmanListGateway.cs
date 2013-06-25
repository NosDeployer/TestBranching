using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// SalesmanListGateway
    /// </summary>
    public class SalesmanListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SalesmanListGateway() : base("LFS_SALESMAN")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        public SalesmanListGateway(DataSet data) : base(data, "LFS_SALESMAN")
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
        public DataSet Load()
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_SALESMANLISTGATEWAY_LOAD");
            return Data;
        }



    }
}
