using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardItemsAboutToExpireGateway
    /// </summary>
    public class DashboardItemsAboutToExpireGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public DashboardItemsAboutToExpireGateway()
            : base("DashboardItemsAboutToExpire")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public DashboardItemsAboutToExpireGateway(DataSet data)
            : base(data, "DashboardItemsAboutToExpire")
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
            tableMapping.DataSetTable = "DashboardItemsAboutToExpire";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("ItemsAboutToExpireCompleteName", "ItemsAboutToExpireCompleteName");
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
        /// LoadAllItemsAboutToExpire
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>DataSet</returns>
        public DataSet LoadAllItemsAboutToExpire(string period, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDITEMSABOUTTOEXPIREGATEWAY_LOADALLITEMSABOUTTOEXPIRE", new SqlParameter("@companyId", companyId), new SqlParameter("@period", period));
            return Data;
        }



        /// <summary>
        /// LoadAllItemsAboutToExpireByUnitType
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="unitType">unitType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllItemsAboutToExpireByUnitType(string period, int companyId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDITEMSABOUTTOEXPIREGATEWAY_LOADALLITEMSABOUTTOEXPIREBYUNITTYPE", new SqlParameter("@companyId", companyId), new SqlParameter("@period", period), new SqlParameter("@unitType", unitType));
            return Data;
        }



        /// <summary>
        /// LoadAllItemsAboutToExpireByCompanyLevelId
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="companyId">companyId</param>   
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllItemsAboutToExpireByCompanyLevelId(string period, int companyId, int companyLevelId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDITEMSABOUTTOEXPIREGATEWAY_LOADALLITEMSABOUTTOEXPIREBYCOMPANYLEVELID", new SqlParameter("@companyId", companyId), new SqlParameter("@period", period), new SqlParameter("@companyLevelId", companyLevelId));
            return Data;
        }



        /// <summary>
        /// LoadAllItemsAboutToExpireByCompanyLevelIdUnitType
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="companyId">companyId</param>   
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitTyep</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllItemsAboutToExpireByCompanyLevelIdUnitType(string period, int companyId, int companyLevelId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDITEMSABOUTTOEXPIREGATEWAY_LOADALLITEMSABOUTTOEXPIREBYCOMPANYLEVELIDUNITTYPE", new SqlParameter("@companyId", companyId), new SqlParameter("@period", period), new SqlParameter("@companyLevelId", companyLevelId), new SqlParameter("@unitType", unitType));
            return Data;
        }



        /// <summary>
        /// LoadAllItemsAboutToExpireByAssignTeamMemberID
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllItemsAboutToExpireByAssignTeamMemberID(string period, int assignTeamMemberId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDITEMSABOUTTOEXPIREGATEWAY_LOADALLITEMSABOUTTOEXPIREBYASSIGNTEAMMEMBERID", new SqlParameter("@companyId", companyId), new SqlParameter("@period", period), new SqlParameter("@assignTeamMemberId", assignTeamMemberId));
            return Data;
        }



        /// <summary>
        /// LoadAllItemsAboutToExpireByAssignTeamMemberIDUnitType
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllItemsAboutToExpireByAssignTeamMemberIDUnitType(string period, int assignTeamMemberId, int companyId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDITEMSABOUTTOEXPIREGATEWAY_LOADALLITEMSABOUTTOEXPIREBYASSIGNTEAMMEMBERIDUNITTYPE", new SqlParameter("@companyId", companyId), new SqlParameter("@period", period), new SqlParameter("@assignTeamMemberId", assignTeamMemberId), new SqlParameter("@unitType", unitType));
            return Data;
        }



        /// <summary>
        /// LoadAllItemsAboutToExpireByAssignTeamMemberIDCompanyLevelId
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllItemsAboutToExpireByAssignTeamMemberIDCompanyLevelId(string period, int assignTeamMemberId, int companyId, int companyLevelId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDITEMSABOUTTOEXPIREGATEWAY_LOADALLITEMSABOUTTOEXPIREBYASSIGNTEAMMEMBERIDCOMPANYLEVELID", new SqlParameter("@companyId", companyId), new SqlParameter("@period", period), new SqlParameter("@assignTeamMemberId", assignTeamMemberId), new SqlParameter("@companyLevelId", companyLevelId));
            return Data;
        }



        /// <summary>
        /// LoadAllItemsAboutToExpireByAssignTeamMemberIDCompanyLevelIdUnitType
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllItemsAboutToExpireByAssignTeamMemberIDCompanyLevelIdUnitType(string period, int assignTeamMemberId, int companyId, int companyLevelId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDITEMSABOUTTOEXPIREGATEWAY_LOADALLITEMSABOUTTOEXPIREBYASSIGNTEAMMEMBERIDCOMPANYLEVELIDUNITTYPE", new SqlParameter("@companyId", companyId), new SqlParameter("@period", period), new SqlParameter("@assignTeamMemberId", assignTeamMemberId), new SqlParameter("@companyLevelId", companyLevelId), new SqlParameter("@unitType", unitType));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Dashboard.DashboardItemsAboutToExpireGateway.GetRow");
            }
        }



        /// <summary>
        /// GetItemsAboutToExpireCompleteName
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>ItemsAboutToExpireCompleteName</returns>
        public string GetItemsAboutToExpireCompleteName(int serviceId)
        {
            return (string)GetRow(serviceId)["ItemsAboutToExpireCompleteName"];
        }



    }
}