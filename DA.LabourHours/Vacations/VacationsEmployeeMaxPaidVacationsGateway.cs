using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.Vacations
{
    /// <summary>
    /// VacationsEmployeeMaxPaidVacationsGateway
    /// </summary>
    public class VacationsEmployeeMaxPaidVacationsGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsEmployeeMaxPaidVacationsGateway()
            : base("LFS_VACATION_EMPLOYEE_MAX_PAID_VACATIONS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsEmployeeMaxPaidVacationsGateway(DataSet data)
            : base(data, "LFS_VACATION_EMPLOYEE_MAX_PAID_VACATIONS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new VacationsTDS();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.DataSetTable = "LFS_VACATION_EMPLOYEE_MAX_PAID_VACATIONS";
            tableMapping.ColumnMappings.Add("Year", "Year");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("VacationDays", "VacationDays");
            tableMapping.ColumnMappings.Add("TotalTakenVacationDays", "TotalTakenVacationDays");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("CarryOverDays", "CarryOverDays");
            tableMapping.ColumnMappings.Add("TotalVacationDays", "TotalVacationDays");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_VACATION_EMPLOYEE_MAX_PAID_VACATIONS] WHERE (([Year] = @Original_Year) AND ([EmployeeID] = @Original_EmployeeID) AND ([VacationDays] = @Original_VacationDays) AND ([TotalTakenVacationDays] = @Original_TotalTakenVacationDays) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([CarryOverDays] = @Original_CarryOverDays) AND ([TotalVacationDays] = @Original_TotalVacationDays))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Year", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Year", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VacationDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VacationDays", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalTakenVacationDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalTakenVacationDays", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CarryOverDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CarryOverDays", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalVacationDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalVacationDays", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_VACATION_EMPLOYEE_MAX_PAID_VACATIONS] ([Year], [EmployeeID], [VacationDays], [TotalTakenVacationDays], [Deleted], [COMPANY_ID], [CarryOverDays], [TotalVacationDays]) VALUES (@Year, @EmployeeID, @VacationDays, @TotalTakenVacationDays, @Deleted, @COMPANY_ID, @CarryOverDays, @TotalVacationDays);
SELECT Year, EmployeeID, VacationDays, TotalTakenVacationDays, Deleted, COMPANY_ID, CarryOverDays, TotalVacationDays FROM LFS_VACATION_EMPLOYEE_MAX_PAID_VACATIONS WHERE (EmployeeID = @EmployeeID) AND (Year = @Year)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Year", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Year", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VacationDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VacationDays", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalTakenVacationDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalTakenVacationDays", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CarryOverDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CarryOverDays", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalVacationDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalVacationDays", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_VACATION_EMPLOYEE_MAX_PAID_VACATIONS] SET [Year] = @Year, [EmployeeID] = @EmployeeID, [VacationDays] = @VacationDays, [TotalTakenVacationDays] = @TotalTakenVacationDays, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [CarryOverDays] = @CarryOverDays, [TotalVacationDays] = @TotalVacationDays WHERE (([Year] = @Original_Year) AND ([EmployeeID] = @Original_EmployeeID) AND ([VacationDays] = @Original_VacationDays) AND ([TotalTakenVacationDays] = @Original_TotalTakenVacationDays) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([CarryOverDays] = @Original_CarryOverDays) AND ([TotalVacationDays] = @Original_TotalVacationDays));
SELECT Year, EmployeeID, VacationDays, TotalTakenVacationDays, Deleted, COMPANY_ID, CarryOverDays, TotalVacationDays FROM LFS_VACATION_EMPLOYEE_MAX_PAID_VACATIONS WHERE (EmployeeID = @EmployeeID) AND (Year = @Year)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Year", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Year", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VacationDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VacationDays", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalTakenVacationDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalTakenVacationDays", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CarryOverDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CarryOverDays", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalVacationDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalVacationDays", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Year", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Year", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VacationDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VacationDays", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalTakenVacationDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalTakenVacationDays", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CarryOverDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CarryOverDays", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalVacationDays", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalVacationDays", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert Vacation Setup (direct to DB)
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="vacationDays">vacationDays</param>
        /// <param name="totalTakenVacationDays">totalTakenVacationDays</param>
        /// <param name="carryOverDays">carryOverDays</param>
        /// <param name="totalVacationDays">totalVacationDays</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>

        public void Insert(int year, int employeeId, double vacationDays, double totalTakenVacationDays, double carryOverDays, double totalVacationDays, bool deleted, int companyId)
        {
            SqlParameter yearParameter = new SqlParameter("Year", year);
            SqlParameter employeeIdParameter = new SqlParameter("EmployeeID", employeeId);
            SqlParameter vacationDaysParameter = new SqlParameter("VacationDays", vacationDays);
            SqlParameter totalTakenVacationDaysParameter = new SqlParameter("TotalTakenVacationDays", totalTakenVacationDays);
            SqlParameter carryOverDaysParameter = new SqlParameter("CarryOverDays", carryOverDays);
            SqlParameter totalVacationDaysParameter = new SqlParameter("TotalVacationDays", totalVacationDays);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_VACATION_EMPLOYEE_MAX_PAID_VACATIONS] ([Year], [EmployeeID], [VacationDays], [TotalTakenVacationDays], [Deleted], [COMPANY_ID], [CarryOverDays], [TotalVacationDays]) VALUES (@Year, @EmployeeID, @VacationDays, @TotalTakenVacationDays, @Deleted, @COMPANY_ID, @CarryOverDays, @TotalVacationDays)";

            ExecuteScalar(command, yearParameter, employeeIdParameter, vacationDaysParameter, totalTakenVacationDaysParameter, carryOverDaysParameter, totalVacationDaysParameter, deletedParameter, companyIdParameter);
        }



        /// <summary>
        /// Update Vacation Setup (direct to DB)
        /// </summary>
        /// <param name="originalYear">originalYear</param>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalVacationDays">originalVacationDays</param>
        /// <param name="originalTotalTakenVacationDays">originalTotalTakenVacationDays</param>
        /// <param name="originalCarryOverDays">originalCarryOverDays</param>
        /// <param name="originalTotalVacationDays">originalTotalVacationDays</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newYear">newYear</param>
        /// <param name="newEmployeeId">newEmployeeId</param>
        /// <param name="newVacationDays">newVacationDays</param>
        /// <param name="newTotalTakenVacationDays">newTotalTakenVacationDays</param>
        /// <param name="newCarryOverDays">newCarryOverDays</param>
        /// <param name="newTotalVacationDays">newTotalVacationDays</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void Update(int originalYear, int originalEmployeeId, double originalVacationDays, double originalTotalTakenVacationDays, double originalCarryOverDays, double originalTotalVacationDays, bool originalDeleted, int originalCompanyId, int newYear, int newEmployeeId, double newVacationDays, double newTotalTakenVacationDays, double newCarryOverDays, double newTotalVacationDays, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalYearParameter = new SqlParameter("Original_Year", originalYear);
            SqlParameter originalEmployeeIdParameter = new SqlParameter("Original_EmployeeID", originalEmployeeId);
            SqlParameter originalVacationDaysParameter = new SqlParameter("Original_VacationDays", originalVacationDays);
            SqlParameter originalTotalTakenVacationDaysParameter = new SqlParameter("Original_TotalTakenVacationDays", originalTotalTakenVacationDays);
            SqlParameter originalCarryOverDaysParameter = new SqlParameter("Original_CarryOverDays", originalCarryOverDays);
            SqlParameter originalTotalVacationDaysParameter = new SqlParameter("Original_TotalVacationDays", originalTotalVacationDays);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newYearParameter = new SqlParameter("Year", newYear);
            SqlParameter newEmployeeIdParameter = new SqlParameter("EmployeeID", newEmployeeId);
            SqlParameter newVacationDaysParameter = new SqlParameter("VacationDays", newVacationDays);
            SqlParameter newTotalTakenVacationDaysParameter = new SqlParameter("TotalTakenVacationDays", newTotalTakenVacationDays);
            SqlParameter newCarryOverDaysParameter = new SqlParameter("CarryOverDays", newCarryOverDays);
            SqlParameter newTotalVacationDaysParameter = new SqlParameter("TotalVacationDays", newTotalVacationDays);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_VACATION_EMPLOYEE_MAX_PAID_VACATIONS] " +
                "SET [Year] = @Year, [EmployeeID] = @EmployeeID, [VacationDays] = @VacationDays, [TotalTakenVacationDays] = @TotalTakenVacationDays, [CarryOverDays] = @CarryOverDays, [TotalVacationDays] = @TotalVacationDays, " +
                " [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID " +
                "WHERE (" +
                "([Year] = @Original_Year) AND ([EmployeeID] = @Original_EmployeeID) AND ([Deleted] = @Original_Deleted) AND " +
                " ([COMPANY_ID] = @Original_COMPANY_ID)" +
                " )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalYearParameter, originalEmployeeIdParameter, originalVacationDaysParameter, originalTotalTakenVacationDaysParameter, originalCarryOverDaysParameter, originalTotalVacationDaysParameter, originalDeletedParameter, originalCompanyIdParameter, newYearParameter, newEmployeeIdParameter, newVacationDaysParameter, newTotalTakenVacationDaysParameter, newCarryOverDaysParameter, newTotalVacationDaysParameter, newDeletedParameter, newCompanyIdParameter);
            
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// UpdateTotalTakenVacationDays
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="newTotalTakenVacationDays">newTotalTakenVacationDays</param>
        public void UpdateTotalTakenVacationDays(int year, int employeeId, double newTotalTakenVacationDays)
        {
            SqlParameter originalYearParameter = new SqlParameter("Original_Year", year);
            SqlParameter originalEmployeeIdParameter = new SqlParameter("Original_EmployeeID", employeeId);
            SqlParameter totalTakenVacationDaysParameter = new SqlParameter("TotalTakenVacationDays", newTotalTakenVacationDays);

            string command = "UPDATE [dbo].[LFS_VACATION_EMPLOYEE_MAX_PAID_VACATIONS] SET [TotalTakenVacationDays] = @TotalTakenVacationDays " +
                             " WHERE ([Year] = @Original_Year) AND ([EmployeeID] = @Original_EmployeeID)";

            ExecuteNonQuery(command, originalYearParameter, originalEmployeeIdParameter, totalTakenVacationDaysParameter);
        }



    }
}