using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.Timesheet
{
    /// <summary>
    /// TimesheetWaitingGateway
    /// </summary>
    public class TimesheetWaitingGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TimesheetWaitingGateway()
            : base("TimesheetWaiting")
        {
        }


        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>

        public TimesheetWaitingGateway(DataSet data)
            : base(data, "TimesheetWaiting")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new TimesheetWaitingTDS();
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
            tableMapping.DataSetTable = "TimesheetWaiting";
            tableMapping.ColumnMappings.Add("TimesheetID", "TimesheetID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("FullName", "FullName");
            tableMapping.ColumnMappings.Add("PayPeriodID", "PayPeriodID");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("ProjectTime", "ProjectTime");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        /// <summary>
        /// Load
        /// </summary>
        public DataSet Load()
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_TIMESHEETWAITINGGATEWAY_LOAD");
            return Data;
        }



    }
}