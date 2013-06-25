using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules
{
    /// <summary>
    /// ChecklistRulesAddNewGateway
    /// </summary>
    public class ChecklistRulesAddNewGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChecklistRulesAddNewGateway()
            : base("ChecklistRulesAddNew")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ChecklistRulesAddNewGateway(DataSet data)
            : base(data, "ChecklistRulesAddNew")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new ChecklistRulesAddTDS();
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
            tableMapping.DataSetTable = "ChecklistRulesAddNew";
            tableMapping.ColumnMappings.Add("RuleID", "RuleID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("MTO", "MTO");
            tableMapping.ColumnMappings.Add("Frequency", "Frequency");
            tableMapping.ColumnMappings.Add("Alarm", "Alarm");
            tableMapping.ColumnMappings.Add("AlarmDays", "AlarmDays");
            tableMapping.ColumnMappings.Add("ServiceRequest", "ServiceRequest");
            tableMapping.ColumnMappings.Add("ServiceRequestDays", "ServiceRequestDays");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }



    }
}


