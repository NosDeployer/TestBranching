using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServicesSRExpiredReportGateway
    /// </summary>
    public class ServicesSRExpiredReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesSRExpiredReportGateway()
            : base("ExpiredServiceRequests")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public ServicesSRExpiredReportGateway(DataSet data)
            : base(data, "ExpiredServiceRequests")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesSRExpiredReportTDS();
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
            tableMapping.DataSetTable = "ExpiredServiceRequests";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("ServiceNumber", "ServiceNumber");
            tableMapping.ColumnMappings.Add("UnitCode", "UnitCode");
            tableMapping.ColumnMappings.Add("MTO", "MTO");
            tableMapping.ColumnMappings.Add("ServiceDescription", "ServiceDescription");
            tableMapping.ColumnMappings.Add("UnitDescription", "UnitDescription");
            tableMapping.ColumnMappings.Add("RuleName", "RuleName");
            tableMapping.ColumnMappings.Add("RuleDescription", "RuleDescription");
            tableMapping.ColumnMappings.Add("AssignDateTime", "AssignDateTime");
            tableMapping.ColumnMappings.Add("AssignDeadlineDate", "AssignDeadlineDate");
            tableMapping.ColumnMappings.Add("AssignedTeamMember", "AssignedTeamMember");
            tableMapping.ColumnMappings.Add("AssignThirdPartyVendor", "AssignThirdPartyVendor");
            tableMapping.ColumnMappings.Add("CompleteWorkDateTime", "CompleteWorkDateTime");
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
        /// LoadExpiredItems
        /// </summary>
        /// <param name="companyId">companyId</param>        
        /// <returns>DataSet</returns>
        public DataSet LoadExpiredItems(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICESSREXPIREDPORTGATEWAY_LOADEXPIREDITEMS", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadExpiredItemsByAssignTeamMemberID
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadExpiredItemsByAssignTeamMemberID(int assignTeamMemberId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICESSREXPIREDPORTGATEWAY_LOADEXPIREDITEMSBYASSIGNTEAMMEMBERID", new SqlParameter("@assignTeamMemberId", assignTeamMemberId), new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}