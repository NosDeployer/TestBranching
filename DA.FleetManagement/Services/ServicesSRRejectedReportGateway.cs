using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServicesSRRejectedReportGateway
    /// </summar
    public class ServicesSRRejectedReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesSRRejectedReportGateway()
            : base("RejectedServiceRequests")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public ServicesSRRejectedReportGateway(DataSet data)
            : base(data, "RejectedServiceRequests")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesSRRejectedReportTDS();
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
            tableMapping.ColumnMappings.Add("UnitIDescription", "UnitIDescription");
            tableMapping.ColumnMappings.Add("AssignDateTime", "AssignDateTime");
            tableMapping.ColumnMappings.Add("AssignDeadlineDate", "AssignDeadlineDate");
            tableMapping.ColumnMappings.Add("AssignedTeamMember", "AssignedTeamMember");
            tableMapping.ColumnMappings.Add("AssignThirdPartyVendor", "AssignThirdPartyVendor");
            tableMapping.ColumnMappings.Add("RejectDateTime", "RejectDateTime");
            tableMapping.ColumnMappings.Add("RejectReason", "RejectReason");

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
        /// LoadRejectedServices
        /// </summary>
        /// <param name="companyId">companyId</param>
        public DataSet LoadRejectedServices(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICESSRREJECTEDREPORTGATEWAY_LOADREJECTEDSERVICES", new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}





