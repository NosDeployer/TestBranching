using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardMyServiceRequestsGateway
    /// </summary>
    public class DashboardMyServiceRequestsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public DashboardMyServiceRequestsGateway()
            : base("DashboardMyServiceRequests")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public DashboardMyServiceRequestsGateway(DataSet data)
            : base(data, "DashboardMyServiceRequests")
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
            tableMapping.DataSetTable = "DashboardMyServiceRequests";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("MyServicesCompleteName", "MyServicesCompleteName");
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
        /// LoadMyServicesByStateAssignTeamMemberID
        /// </summary>        
        /// <param name="state">state</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadMyServicesByStateAssignTeamMemberID(string state, int assignTeamMemberId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDMYSERVICEREQUESTSGATEWAY_LOADMYSERVICESBYSTATEASSIGNTEAMMEMBERID", new SqlParameter("@state", state), new SqlParameter("@assignTeamMemberId", assignTeamMemberId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadMyServicesByStateAssignTeamMemberIDUnitType
        /// </summary>        
        /// <param name="state">state</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadMyServicesByStateAssignTeamMemberIDUnitType(string state, int assignTeamMemberId, int companyId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDMYSERVICEREQUESTSGATEWAY_LOADMYSERVICESBYSTATEASSIGNTEAMMEMBERIDUNITTYPE", new SqlParameter("@state", state), new SqlParameter("@assignTeamMemberId", assignTeamMemberId), new SqlParameter("@companyId", companyId), new SqlParameter("@unitType", unitType));
            return Data;
        }



        /// <summary>
        /// LoadMyServicesByStateAssignTeamMemberIDCompanyLevelId
        /// </summary>        
        /// <param name="state">state</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadMyServicesByStateAssignTeamMemberIDCompanyLevelId(string state, int assignTeamMemberId, int companyId, int companyLevelId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDMYSERVICEREQUESTSGATEWAY_LOADMYSERVICESBYSTATEASSIGNTEAMMEMBERIDCOMPANYLEVELID", new SqlParameter("@state", state), new SqlParameter("@assignTeamMemberId", assignTeamMemberId), new SqlParameter("@companyId", companyId), new SqlParameter("@companyLevelId", companyLevelId));
            return Data;
        }



        /// <summary>
        /// LoadMyServicesByStateAssignTeamMemberIDCompanyLevelId
        /// </summary>        
        /// <param name="state">state</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadMyServicesByStateAssignTeamMemberIDCompanyLevelIdUnitType(string state, int assignTeamMemberId, int companyId, int companyLevelId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDMYSERVICEREQUESTSGATEWAY_LOADMYSERVICESBYSTATEASSIGNTEAMMEMBERIDCOMPANYLEVELIDUNITTYPE", new SqlParameter("@state", state), new SqlParameter("@assignTeamMemberId", assignTeamMemberId), new SqlParameter("@companyId", companyId), new SqlParameter("@companyLevelId", companyLevelId), new SqlParameter("@unitType", unitType));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Dashboard.DashboardMyServiceRequestsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetMyServicesCompleteName
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>MyServicesCompleteName</returns>
        public string GetMyServicesCompleteName(int serviceId)
        {
            return (string)GetRow(serviceId)["MyServicesCompleteName"];
        }



    }
}