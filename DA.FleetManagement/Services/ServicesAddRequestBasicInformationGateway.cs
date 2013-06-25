using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServicesAddRequestBasicInformationGateway
    /// </summary>
    public class ServicesAddRequestBasicInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ServicesAddRequestBasicInformationGateway()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ServicesAddRequestBasicInformationGateway(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesAddRequestTDS();
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
            tableMapping.DataSetTable = "BasicInformation";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("ServiceState", "ServiceState");
            tableMapping.ColumnMappings.Add("MtoDot", "MtoDot");
            tableMapping.ColumnMappings.Add("ServiceDescription", "ServiceDescription");
            tableMapping.ColumnMappings.Add("AssignedDeadlineDate", "AssignedDeadlineDate");
            tableMapping.ColumnMappings.Add("AssignDateTime", "AssignDateTime");
            tableMapping.ColumnMappings.Add("AcceptDatetime", "AcceptDatetime");
            tableMapping.ColumnMappings.Add("UnitOutOfServiceDate", "UnitOutOfServiceDate");
            tableMapping.ColumnMappings.Add("UnitOutOfServiceTime", "UnitOutOfServiceTime");
            tableMapping.ColumnMappings.Add("CompleteWorkDateTime", "CompleteWorkDateTime");
            tableMapping.ColumnMappings.Add("UnitBackInServiceDate", "UnitBackInServiceDate");
            tableMapping.ColumnMappings.Add("UnitBackInServiceTime", "UnitBackInServiceTime");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailDescription", "CompleteWorkDetailDescription");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailPreventable", "CompleteWorkDetailPreventable");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTMLabourHours", "CompleteWorkDetailTMLabourHours");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTMCost", "CompleteWorkDetailTMCost");
            tableMapping.ColumnMappings.Add("CompleteWorkInvoiceNumber", "CompleteWorkInvoiceNumber");
            tableMapping.ColumnMappings.Add("CompleteWorkInvoiceAmount", "CompleteWorkInvoiceAmount");
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("Mileage", "Mileage");
            tableMapping.ColumnMappings.Add("StartWorkMileage", "StartWorkMileage");
            tableMapping.ColumnMappings.Add("CompleteWorkMileage", "CompleteWorkMileage");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("RuleID", "RuleID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }



    }
}
