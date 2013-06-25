using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.Vacations
{
    /// <summary>
    /// VacationsAddBasicInformationGateway
    /// </summary>
    public class VacationsAddBasicInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsAddBasicInformationGateway()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsAddBasicInformationGateway(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new VacationsAddTDS();
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
            tableMapping.DataSetTable = "BasicInformation";
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("EmployeeName", "EmployeeName");
            tableMapping.ColumnMappings.Add("TotalVacationDays", "TotalVacationDays");
            tableMapping.ColumnMappings.Add("RemainingPayVacationDays", "RemainingPayVacationDays");
            tableMapping.ColumnMappings.Add("Year", "Year");
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
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByEmployeeIdYear(int employeeId, int year, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSADDBASICINFORMATIONGATEWAY_LOADBYEMPLOYEEIDYEAR", new SqlParameter("employeeId", employeeId), new SqlParameter("year", year), new SqlParameter("@companyId", companyId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.LabourHours.Vacations.VacationsAddBasicInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetTotalVacationDays
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="year">year</param>
        /// <returns>VacationDays</returns>
        public double GetTotalVacationDays(int employeeId, int year)
        {
            return (double)GetRow(employeeId, year)["TotalVacationDays"];
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
        /// GetEmployeeName
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="year">year</param>
        /// <returns>EmployeeName</returns>
        public string GetEmployeeName(int employeeId, int year)
        {
            return (string)GetRow(employeeId, year)["EmployeeName"];
        }


                
    }
}