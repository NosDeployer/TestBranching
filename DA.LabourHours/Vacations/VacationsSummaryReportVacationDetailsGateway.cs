using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.Vacations
{
    /// <summary>
    /// VacationsSummaryReportVacationDetailsGateway
    /// </summary>
    public class VacationsSummaryReportVacationDetailsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsSummaryReportVacationDetailsGateway()
            : base("VacationDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public VacationsSummaryReportVacationDetailsGateway(DataSet data)
            : base(data, "VacationDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new VacationsSummaryReportTDS();
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
            tableMapping.DataSetTable = "VacationDetails";
            tableMapping.ColumnMappings.Add("RequestID", "RequestID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("TotalDays", "TotalDays");
            tableMapping.ColumnMappings.Add("TotalPaidVacationDays", "TotalPaidVacationDays");
            tableMapping.ColumnMappings.Add("TotalNoPaidVacationDays", "TotalNoPaidVacationDays");
            tableMapping.ColumnMappings.Add("Details", "Details");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
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
        /// LoadByEmployeeIdStartDateEndDate
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByEmployeeIdStartDateEndDate(int employeeId, DateTime startDate, DateTime endDate, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSSUMMARYREPORTVACATIONDETAILSGATEWAY_LOADBYEMPLOYEEIDSTARTDATEENDDATE", new SqlParameter("@employeeId", employeeId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}