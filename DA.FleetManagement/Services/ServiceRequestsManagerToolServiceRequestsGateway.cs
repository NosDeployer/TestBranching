using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServiceRequestsManagerToolServiceRequestsGateway
    /// </summary>
    public class ServiceRequestsManagerToolServiceRequestsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceRequestsManagerToolServiceRequestsGateway()
            : base("ServiceRequests")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServiceRequestsManagerToolServiceRequestsGateway(DataSet data)
            : base(data, "ServiceRequests")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServiceRequestsManagerToolTDS();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "ServiceRequests";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("Number", "Number");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadAll
        /// </summary>       
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAll(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICEREQUESTSMANAGERTOOLSERVICEREQUESTS_LOADALL",  new SqlParameter("@companyId", companyId));
            return Data;
        }


    }
}
