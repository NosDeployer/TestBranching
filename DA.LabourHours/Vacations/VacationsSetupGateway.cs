using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using System;

namespace LiquiForce.LFSLive.DA.LabourHours.Vacations
{
    /// <summary>
    /// VacationsSetupGateway
    /// </summary>
    public class VacationsSetupGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsSetupGateway()
            : base("VacationsSetup")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsSetupGateway(DataSet data)
            : base(data, "VacationsSetup")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new VacationsSetupTDS();
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
            tableMapping.DataSetTable = "VacationsSetup";
            tableMapping.ColumnMappings.Add("Year", "Year");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("EmployeeName", "EmployeeName");
            tableMapping.ColumnMappings.Add("VacationDays", "VacationDays");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("TotalTakenVacationDays", "TotalTakenVacationDays");
            tableMapping.ColumnMappings.Add("CarryOverDays", "CarryOverDays");
            tableMapping.ColumnMappings.Add("TotalVacationDays", "TotalVacationDays");            
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
        /// <param name="year">year</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByYear(int year, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSSETUPGATEWAY_LOADBYYEAR", new SqlParameter("year", year), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByYearEmployeeType
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeType">employeeType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByYearEmployeeType(int year, string employeeType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSSETUPGATEWAY_LOADBYYEAREMPLOYEETYPE", new SqlParameter("year", year), new SqlParameter("employeeType", employeeType), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int year, int employeeId)
        {
            string filter = string.Format("Year = {0} AND EmployeeID = {1} ", year, employeeId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.LabourHours.Vacations.VacationsSetupGateway.GetRow");
            }
        }



        /// <summary>
        /// GetCarryOverDays
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>CarryOverDays</returns>
        public double GetCarryOverDays(int year, int employeeId)
        {
            return (double)GetRow(year, employeeId)["CarryOverDays"];
        }



        /// <summary>
        /// GetCarryOverDays Original
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original CarryOverDays</returns>
        public double GetCarryOverDaysOriginal(int year, int employeeId)
        {
            return (double)GetRow(year, employeeId)["CarryOverDays", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalVacationDays
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>TotalDays</returns>
        public double GetTotalVacationDays(int year, int employeeId)
        {
            return (double)GetRow(year, employeeId)["TotalVacationDays"];
        }



        /// <summary>
        /// GetTotalVacationDays Original
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original TotalDays</returns>
        public double GetTotalVacationDaysOriginal(int year, int employeeId)
        {
            return (double)GetRow(year, employeeId)["TotalVacationDays", DataRowVersion.Original];
        }



        /// <summary>
        /// GetVacationDays
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>VacationDays</returns>
        public double GetVacationDays(int year, int employeeId)
        {
            return (double)GetRow(year, employeeId)["VacationDays"];
        }



        /// <summary>
        /// GetVacationDays Original
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original VacationDays</returns>
        public double GetVacationDaysOriginal(int year, int employeeId)
        {
            return (double)GetRow(year, employeeId)["VacationDays", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalTakenVacationDays
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>TotalTakenVacationDays</returns>
        public double GetTotalTakenVacationDays(int year, int employeeId)
        {
            return (double)GetRow(year, employeeId)["TotalTakenVacationDays"];
        }
          
        

    }
}