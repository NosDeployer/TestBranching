using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardExpiredServiceRequestsGateway
    /// </summary>
    public class DashboardExpiredServiceRequestsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public DashboardExpiredServiceRequestsGateway()
            : base("DashboardExpiredServiceRequests")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public DashboardExpiredServiceRequestsGateway(DataSet data)
            : base(data, "DashboardExpiredServiceRequests")
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
            tableMapping.DataSetTable = "DashboardExpiredServiceRequests";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("ExpiredServicesCompleteName", "ExpiredServicesCompleteName");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
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
        /// LoadAllExpiredItems
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllExpiredItems(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDEXPIREDSERVICEREQUESTSGATEWAY_LOADALLEXPIREDITEMS", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadAllExpiredItemsByUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllExpiredItemsByUnitType(int companyId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDEXPIREDSERVICEREQUESTSGATEWAY_LOADALLEXPIREDITEMSBYUNITTYPE", new SqlParameter("@companyId", companyId), new SqlParameter("@unitType", unitType));
            return Data;
        }



        /// <summary>
        /// LoadAllExpiredItemsByCompanyLevelId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllExpiredItemsByCompanyLevelId(int companyId, int companyLevelId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDEXPIREDSERVICEREQUESTSGATEWAY_LOADALLEXPIREDITEMSBYCOMPANYLEVELID", new SqlParameter("@companyId", companyId), new SqlParameter("@companyLevelId", companyLevelId));
            return Data;
        }



        /// <summary>
        /// LoadAllExpiredItemsByCompanyLevelIdUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllExpiredItemsByCompanyLevelIdUnitType(int companyId, int companyLevelId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDEXPIREDSERVICEREQUESTSGATEWAY_LOADALLEXPIREDITEMSBYCOMPANYLEVELIDUNITTYPE", new SqlParameter("@companyId", companyId), new SqlParameter("@companyLevelId", companyLevelId), new SqlParameter("@unitType", unitType));
            return Data;
        }



        /// <summary>
        /// LoadAllExpiredItemsByAssignTeamMemberID
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>DataSet</returns>
        public DataSet LoadAllExpiredItemsByAssignTeamMemberID(int assignTeamMemberId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDEXPIREDSERVICEREQUESTSGATEWAY_LOADALLEXPIREDITEMSBYASSIGNTEAMMEMBERID", new SqlParameter("@companyId", companyId), new SqlParameter("@assignTeamMemberId", assignTeamMemberId));
            return Data;
        }



        /// <summary>
        /// LoadAllExpiredItemsByAssignTeamMemberIDUnitType
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllExpiredItemsByAssignTeamMemberIDUnitType(int assignTeamMemberId, int companyId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDEXPIREDSERVICEREQUESTSGATEWAY_LOADALLEXPIREDITEMSBYASSIGNTEAMMEMBERIDUNITTYPE", new SqlParameter("@companyId", companyId), new SqlParameter("@assignTeamMemberId", assignTeamMemberId), new SqlParameter("@unitType", unitType));
            return Data;
        }



        /// <summary>
        /// LoadAllExpiredItemsByAssignTeamMemberIDCompanyLevelId
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllExpiredItemsByAssignTeamMemberIDCompanyLevelId(int assignTeamMemberId, int companyId, int companyLevelId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDEXPIREDSERVICEREQUESTSGATEWAY_LOADALLEXPIREDITEMSBYASSIGNTEAMMEMBERIDCOMPANYLEVELID", new SqlParameter("@companyId", companyId), new SqlParameter("@assignTeamMemberId", assignTeamMemberId), new SqlParameter("@companyLevelId", companyLevelId));
            return Data;
        }



        /// <summary>
        /// LoadAllExpiredItemsByAssignTeamMemberIDCompanyLevelIdUnitType
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllExpiredItemsByAssignTeamMemberIDCompanyLevelIdUnitType(int assignTeamMemberId, int companyId, int companyLevelId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDEXPIREDSERVICEREQUESTSGATEWAY_LOADALLEXPIREDITEMSBYASSIGNTEAMMEMBERIDCOMPANYLEVELIDUNITTYPE", new SqlParameter("@companyId", companyId), new SqlParameter("@assignTeamMemberId", assignTeamMemberId), new SqlParameter("@companyLevelId", companyLevelId), new SqlParameter("@unitType", unitType));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Dashboard.DashboardExpiredServiceRequestsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetExpiredServicesCompleteName
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>ExpiredServicesCompleteName</returns>
        public string GetExpiredServicesCompleteName(int serviceId)
        {
            return (string)GetRow(serviceId)["ExpiredServicesCompleteName"];
        }



    }
}