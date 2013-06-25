using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.Vacations
{
    /// <summary>
    /// VacationsSummaryReportEmployeeDetailsGateway
    /// </summary>
    public class VacationsSummaryReportEmployeeDetailsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsSummaryReportEmployeeDetailsGateway()
            : base("EmployeeDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public VacationsSummaryReportEmployeeDetailsGateway(DataSet data)
            : base(data, "EmployeeDetails")
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
            tableMapping.DataSetTable = "EmployeeDetails";
            tableMapping.ColumnMappings.Add("Year", "Year");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("VacationDays", "VacationDays");
            tableMapping.ColumnMappings.Add("RemainingPayVacationDays", "RemainingPayVacationDays");
            tableMapping.ColumnMappings.Add("TotalApprovedVacations", "TotalApprovedVacations");
            tableMapping.ColumnMappings.Add("EmployeeName", "EmployeeName");
            tableMapping.ColumnMappings.Add("EmployeeType", "EmployeeType");
            tableMapping.ColumnMappings.Add("TotalVacationDays", "TotalVacationDays");
            tableMapping.ColumnMappings.Add("CarryOverDays", "CarryOverDays");
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
        /// LoadByYear
        /// </summary>
        /// <param name="year"></param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByYear(int year, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSSUMMARYREPORTEMPLOYEEDETAILSGATEWAY_LOADBYYEAR", new SqlParameter("@year", year), new SqlParameter("@companyId", companyId));
            return Data;
        }

        

        /// <summary>
        /// LoadByYearEmployeeId
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByYearEmployeeId(int year, int employeeId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSSUMMARYREPORTEMPLOYEEDETAILSGATEWAY_LOADBYYEAREMPLOYEEID", new SqlParameter("@year", year), new SqlParameter("@employeeId", employeeId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByYearEmployeeType
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="location">location</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByYearEmployeeType(int year, string location, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSSUMMARYREPORTEMPLOYEEDETAILSGATEWAY_LOADBYYEAREMPLOYEETYPE", new SqlParameter("@year", year), new SqlParameter("@employeeType", location), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByYearEmployeeTypeEmployeeId
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="location">location</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByYearEmployeeTypeEmployeeId(int year, string location, int employeeId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSSUMMARYREPORTEMPLOYEEDETAILSGATEWAY_LOADBYYEAREMPLOYEETYPEEMPLOYEEID", new SqlParameter("@year", year), new SqlParameter("@employeeType", location), new SqlParameter("@employeeId", employeeId), new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}