using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;

namespace LiquiForce.LFSLive.DA.LabourHours.Timesheet
{
    /// <summary>
    /// TimesheetGateway
    /// </summary>
    public class TimesheetGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TimesheetGateway()
            : base("LFS_TIMESHEET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public TimesheetGateway(DataSet data)
            : base(data, "LFS_TIMESHEET")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new TimesheetTDS();
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
            tableMapping.DataSetTable = "LFS_TIMESHEET";
            tableMapping.ColumnMappings.Add("TimesheetID", "TimesheetID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("PayPeriodID", "PayPeriodID");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [LFS_TIMESHEET] WHERE (([TimesheetID] = @Original_TimesheetID) AND ([" +
                "EmployeeID] = @Original_EmployeeID) AND ([PayPeriodID] = @Original_PayPeriodID) " +
                "AND ([State] = @Original_State) AND ([Deleted] = @Original_Deleted))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_TimesheetID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "TimesheetID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PayPeriodID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PayPeriodID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_State", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "State", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [LFS_TIMESHEET] ([EmployeeID], [PayPeriodID], [State], [Deleted]) VAL" +
                "UES (@EmployeeID, @PayPeriodID, @State, @Deleted);\r\nSELECT TimesheetID, Employee" +
                "ID, PayPeriodID, State, Deleted FROM LFS_TIMESHEET WHERE (TimesheetID = SCOPE_ID" +
                "ENTITY())";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PayPeriodID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PayPeriodID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@State", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "State", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [LFS_TIMESHEET] SET [EmployeeID] = @EmployeeID, [PayPeriodID] = @PayPeriodID, [State] = @State, [Deleted] = @Deleted WHERE (([TimesheetID] = @Original_TimesheetID) AND ([EmployeeID] = @Original_EmployeeID) AND ([PayPeriodID] = @Original_PayPeriodID) AND ([State] = @Original_State) AND ([Deleted] = @Original_Deleted));
SELECT TimesheetID, EmployeeID, PayPeriodID, State, Deleted FROM LFS_TIMESHEET WHERE (TimesheetID = @TimesheetID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PayPeriodID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PayPeriodID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@State", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "State", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_TimesheetID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "TimesheetID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PayPeriodID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PayPeriodID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_State", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "State", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TimesheetID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 0, 0, "TimesheetID", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <returns>Data</returns>
        public DataSet Load()
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_TIMESHEETGATEWAY_LOAD");
            return Data;
        }



        /// <summary>
        /// LoadByEmployeeIdPayPeriodId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="payPeriodId">payPeriodId</param>
        /// <returns>Data</returns>
        public DataSet LoadByEmployeeIdPayPeriodId(int employeeId, int payPeriodId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_TIMESHEETGATEWAY_LOADBYEMPLOYEEIDPAYPERIODID", new SqlParameter("@employeeId", employeeId), new SqlParameter("@payPeriodId", payPeriodId));
            return Data;
        }



        /// <summary>
        /// GetRowByEmployeeIdPayPeriodId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="payPeriodId">payPeriodId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRowByEmployeeIdPayPeriodId(int employeeId, int payPeriodId)
        {
            string filter = string.Format("EmployeeID = {0} AND PayPeriodID = {1}", employeeId, payPeriodId);
            return Table.Select(filter)[0];
        }



        /// <summary>
        /// GetStateByEmployeeIdPayPeriodId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="payPeriodId">payPeriodId</param>
        /// <returns>State</returns>
        public string GetStateByEmployeeIdPayPeriodId(int employeeId, int payPeriodId)
        {
            return (string)GetRowByEmployeeIdPayPeriodId(employeeId, payPeriodId)["State"];
        }



        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            DataTable tableChanges = Table.GetChanges();

            if ((tableChanges != null) && (tableChanges.Rows.Count > 0))
            {
                try
                {
                    Adapter.Update(Data, this.TableName);
                }
                catch (DBConcurrencyException dBConcurrencyException)
                {
                    throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
                }
                catch (SqlException sqlException)
                {
                    byte severityLevel = sqlException.Class;
                    if (severityLevel <= 16)
                    {
                        throw new Exception("Low severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                    }
                    if ((severityLevel >= 17) && (severityLevel <= 19))
                    {
                        throw new Exception("Mid severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                    }
                    if (severityLevel >= 20)
                    {
                        throw new Exception("High severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Unknow error. Your operation has been cancelled.", e);
                }
            }
        }



        /// <summary>
        /// Update2
        /// </summary>
        public void Update2()
        {
            ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway(Data);

            DataTable timesheetChanges = Table.GetChanges();
            DataTable projectTimeChanges = projectTimeGateway.Table.GetChanges();

            if ((timesheetChanges == null) && (projectTimeChanges == null)) return;

            try
            {
                DB.Open();
                DB.BeginTransaction();

                Adapter.InsertCommand.Transaction = DB.Transaction;
                Adapter.UpdateCommand.Transaction = DB.Transaction;
                Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectTimeGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectTimeGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectTimeGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                if ((timesheetChanges != null) && (timesheetChanges.Rows.Count > 0))
                {
                    Adapter.Update(timesheetChanges);
                }

                if ((projectTimeChanges != null) && (projectTimeChanges.Rows.Count > 0))
                {
                    projectTimeGateway.Adapter.Update(projectTimeChanges);
                }

                DB.CommitTransaction();
            }
            catch (DBConcurrencyException dBConcurrencyException)
            {
                DB.RollbackTransaction();
                throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
            }
            catch (SqlException sqlException)
            {
                DB.RollbackTransaction();
                byte severityLevel = sqlException.Class;
                if (severityLevel <= 16)
                {
                    throw new Exception("Low severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
                if ((severityLevel >= 17) && (severityLevel <= 19))
                {
                    throw new Exception("Mid severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
                if (severityLevel >= 20)
                {
                    throw new Exception("High severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
            }
            catch (Exception e)
            {
                DB.RollbackTransaction();
                throw new Exception("Unknow error. Your operation has been cancelled.", e);
            }
            finally
            {
                DB.Close();
            }
        }
    }
}
