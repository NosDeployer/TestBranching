using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardInProgressServiceRequestsGateway
    /// </summary>
    public class DashboardInProgressServiceRequestsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public DashboardInProgressServiceRequestsGateway()
            : base("DashboardInProgressServiceRequests")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public DashboardInProgressServiceRequestsGateway(DataSet data)
            : base(data, "DashboardInProgressServiceRequests")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new DashboardTDS();
        }



        /// <summary>
        /// InitAdapter (empty)
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "DashboardInProgressServiceRequests";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("InProgressServicesCompleteName", "InProgressServicesCompleteName");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("ServiceDescription", "ServiceDescription");
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
        /// LoadServicesByState
        /// </summary>        
        /// <param name="state">state</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadServicesByState(string state, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDINPROGRESSSERVICEREQUESTSGATEWAY_LOADSERVICESBYSTATE", new SqlParameter("@state", state),  new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadServicesByStateUnitType
        /// </summary>        
        /// <param name="state">state</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadServicesByStateUnitType(string state, int companyId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDINPROGRESSSERVICEREQUESTSGATEWAY_LOADSERVICESBYSTATEUNITTYPE", new SqlParameter("@state", state), new SqlParameter("@companyId", companyId), new SqlParameter("@unitType", unitType));
            return Data;
        }



        /// <summary>
        /// LoadServicesByStateCompanyLevelId
        /// </summary>        
        /// <param name="state">state</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadServicesByStateCompanyLevelId(string state, int companyId, int companyLevelId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDINPROGRESSSERVICEREQUESTSGATEWAY_LOADSERVICESBYSTATECOMPANYLEVELID", new SqlParameter("@state", state), new SqlParameter("@companyId", companyId), new SqlParameter("@companyLevelId", companyLevelId));
            return Data;
        }



        /// <summary>
        /// LoadServicesByStateCompanyLevelIdUnitType
        /// </summary>        
        /// <param name="state">state</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadServicesByStateCompanyLevelIdUnitType(string state, int companyId, int companyLevelId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDINPROGRESSSERVICEREQUESTSGATEWAY_LOADSERVICESBYSTATECOMPANYLEVELIDUNITTYPE", new SqlParameter("@state", state), new SqlParameter("@companyId", companyId), new SqlParameter("@companyLevelId", companyLevelId), new SqlParameter("@unitType", unitType));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int serviceId)
        {
            string filter = string.Format("(ServiceID = {0})", serviceId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Dashboard.DashboardInProgressServiceRequestsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetInProgressServicesCompleteName
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>InProgressServicesCompleteName</returns>
        public string GetInProgressServicesCompleteName(int serviceId)
        {
            return (string)GetRow(serviceId)["InProgressServicesCompleteName"];
        }



    }
}