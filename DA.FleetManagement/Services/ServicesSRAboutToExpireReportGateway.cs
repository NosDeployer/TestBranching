using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServicesSRAboutToExpireReprotGateway
    /// </summar
    public class ServicesSRAboutToExpireReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesSRAboutToExpireReportGateway()
            : base("AboutToExpireServiceRequests")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public ServicesSRAboutToExpireReportGateway(DataSet data)
            : base(data, "AboutToExpireServiceRequests")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesSRAboutToExpireReportTDS();
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
            tableMapping.DataSetTable = "UnassignedServiceRequests";
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
        /// LoadItemsAboutToExpire
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>DataSet</returns>
        public DataSet LoadItemsAboutToExpire(string period, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICESSRABOUTTOEXPIREREPORTGATEWAY_LOADITEMSABOUTTOEXPIRE", new SqlParameter("@period", period), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadItemsAboutToExpireByAssignTeamMemberID
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadItemsAboutToExpireByAssignTeamMemberID(string period, int assignTeamMemberId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICESSRABOUTTOEXPIREREPORTGATEWAY_LOADITEMSABOUTTOEXPIREBYASSIGNTEAMMEMBERID", new SqlParameter("@period", period), new SqlParameter("@assignTeamMemberId", assignTeamMemberId), new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}






