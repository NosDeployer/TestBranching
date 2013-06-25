using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeeInformationPayVacationDaysInformationGateway
    /// </summary>
    public class EmployeeInformationPayVacationDaysInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeInformationPayVacationDaysInformationGateway()
            : base("PayVacationDaysInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeInformationPayVacationDaysInformationGateway(DataSet data)
            : base(data, "PayVacationDaysInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeInformationTDS();
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
            tableMapping.DataSetTable = "PayVacationDaysInformation";
            tableMapping.ColumnMappings.Add("Year", "Year");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("VacationDays", "VacationDays");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("RemainingPayVacationDays", "RemainingPayVacationDays");
            tableMapping.ColumnMappings.Add("TotalApprovedVacations", "TotalApprovedVacations");
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
        /// LoadByEmployeeIdYear
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="year">year</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByEmployeeIdYear(int employeeId, int year)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEINFORMATIONPAYVACATIONDAYSINFORMATIONGATEWAY_LOADBYEMPLOYEEIDYEAR", new SqlParameter("@employeeId", employeeId), new SqlParameter("@year", year));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int employeeId, int year)
        {
            string filter = string.Format("EmployeeID = {0} AND Year = {1}", employeeId, year);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Employees.EmployeesInformationPayVacationDaysInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetVacationDays
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="year">year</param>
        /// <returns>VacationDays</returns>
        public double GetVacationDays(int employeeId, int year)
        {
            return (double)GetRow(employeeId, year)["VacationDays"];
        }



        /// <summary>
        /// GetRemainingPayVacationDays
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="year">year</param>
        /// <returns>RemainingPayVacationDays</returns>
        public double GetRemainingPayVacationDays(int employeeId, int year)
        {
            return (double)GetRow(employeeId, year)["RemainingPayVacationDays"];
        }



        /// <summary>
        /// GetTotalApprovedVacations
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="year">year</param>
        /// <returns>TotalApprovedVacations</returns>
        public double GetTotalApprovedVacations(int employeeId, int year)
        {
            return (double)GetRow(employeeId, year)["TotalApprovedVacations"];
        }



    }
}