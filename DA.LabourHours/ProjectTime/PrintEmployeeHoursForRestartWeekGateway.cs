using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintEmployeeHoursForRestartWeekGateway
    /// </summary
    public class PrintEmployeeHoursForRestartWeekGateway : DataTableGateway
    {
        /// <summary>
        /// Constructor
        /// </summary>     
        public PrintEmployeeHoursForRestartWeekGateway()
            : base("PrintEmployeeHoursForRestartWeek")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PrintEmployeeHoursForRestartWeekGateway(DataSet data)
            : base(data, "PrintEmployeeHoursForRestartWeek")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PrintEmployeeHoursForRestartWeekTDS();
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
            tableMapping.DataSetTable = "PrintEmployeeHoursForRestartWeek";
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("NameEmployee", "NameEmployee");
            tableMapping.ColumnMappings.Add("NameCountry", "NameCountry");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("StartTime", "StartTime");
            tableMapping.ColumnMappings.Add("EndTime", "EndTime");
            tableMapping.ColumnMappings.Add("Offset", "Offset");
            tableMapping.ColumnMappings.Add("ProjectTime", "ProjectTime");
            tableMapping.ColumnMappings.Add("Location", "Location");
            tableMapping.ColumnMappings.Add("MAUS", "MAUS");
            tableMapping.ColumnMappings.Add("MACA", "MACA");
            tableMapping.ColumnMappings.Add("WorkingDetails", "WorkingDetails");
            tableMapping.ColumnMappings.Add("ProjectTimeState", "ProjectTimeState");
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
        /// LoadByEmployeeTypeStartDateEndDateProjectTimeState
        /// </summary>
        /// <returns>Data</returns>        
        public DataSet LoadByEmployeeTypeStartDateEndDateProjectTimeState(string employeeType, DateTime startDate, DateTime endDate, string projectTimeState)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTEMPLOYEEHOURSFORRESTARTWEEKGATEWAY_LOADBYEMPLOYEETYPESTARTDATEENDDATEPROJECTTIMESTATE", new SqlParameter("@employeeType", employeeType), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState));
            return Data;
        }



    }
}