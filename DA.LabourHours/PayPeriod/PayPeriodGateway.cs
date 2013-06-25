using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.PayPeriod
{
    /// <summary>
    /// PayPeriodGateway
    /// </summary>
    public class PayPeriodGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PayPeriodGateway()
            : base("LFS_PAY_PERIOD")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PayPeriodGateway(DataSet data)
            : base(data, "LFS_PAY_PERIOD")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DataSet();
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
            tableMapping.DataSetTable = "LFS_PAY_PERIOD";
            tableMapping.ColumnMappings.Add("PayPeriodID", "PayPeriodID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_PAY_PERIOD] WHERE (([PayPeriodID] = @Original_PayPeriodID) AND ([Name] = @Original_Name) AND ([StartDate] = @Original_StartDate) AND ([EndDate] = @Original_EndDate))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PayPeriodID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PayPeriodID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Name", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_StartDate", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "StartDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EndDate", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "EndDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[LFS_PAY_PERIOD] ([Name], [StartDate], [EndDate]) VALUES (@Name, @StartDate, @EndDate);\r\nSELECT PayPeriodID, Name, StartDate, EndDate FROM LFS_PAY_PERIOD WHERE (PayPeriodID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StartDate", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "StartDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EndDate", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "EndDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_PAY_PERIOD] SET [Name] = @Name, [StartDate] = @StartDate, [EndDate] = @EndDate WHERE (([PayPeriodID] = @Original_PayPeriodID) AND ([Name] = @Original_Name) AND ([StartDate] = @Original_StartDate) AND ([EndDate] = @Original_EndDate));SELECT PayPeriodID, Name, StartDate, EndDate FROM LFS_PAY_PERIOD WHERE (PayPeriodID = @PayPeriodID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Name", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StartDate", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "StartDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EndDate", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "EndDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PayPeriodID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PayPeriodID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Name", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Name", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_StartDate", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "StartDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EndDate", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "EndDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PayPeriodID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 0, 0, "PayPeriodID", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByDate
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="month">month</param>
        /// <param name="day">day</param>
        /// <returns>Data</returns>
        public DataSet LoadByDate(int year, int month, int day)
        {
            string date = string.Format("{0}/{1}/{2 }", month, day, year);
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PAYPERIODGATEWAY_LOADBYDATE", new SqlParameter("@date", date));
            return Data;
        }



        /// <summary>
        /// LoadByPayPeriodId
        /// </summary>
        /// <param name="payPeriodId">payPeriodId</param>
        /// <returns>Data</returns>
        public DataSet LoadByPayPeriodId(int payPeriodId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PAYPERIODGATEWAY_LOADBYPAYPERIODID", new SqlParameter("@payPeriodId", payPeriodId));
            return Data;
        }



        /// <summary>
        /// GetNextPayPeriodId
        /// </summary>
        /// <param name="payPeriodId">payPeriodId or 0</param>
        public int GetNextPayPeriodId(int payPeriodId)
        {
            LoadByPayPeriodId(payPeriodId);
            DateTime endDate = GetEndDate(payPeriodId);

            FillDataWithStoredProcedure("LFS_LABOURHOURS_PAYPERIODGATEWAY_GETNEXTPAYPERIODID", new SqlParameter("@endDate", endDate));

            if (Table.Rows.Count > 0)
            {
                return (int)Table.Rows[0]["PayPeriodID"]; ;
            }
            else
            {
                return 0;
            }
        }



        /// <summary>
        /// GetPriorPayPeriodId
        /// </summary>
        /// <param name="payPeriodId">payPeriodId</param>
        /// <returns>Pay Period Id or 0</returns>
        public int GetPriorPayPeriodId(int payPeriodId)
        {
            LoadByPayPeriodId(payPeriodId);
            DateTime startDate = GetStartDate(payPeriodId);

            FillDataWithStoredProcedure("LFS_LABOURHOURS_PAYPERIODGATEWAY_GETPRIORPAYPERIODID", new SqlParameter("@startDate", startDate));

            if (Table.Rows.Count > 0)
            {
                return (int)Table.Rows[0]["PayPeriodID"]; ;
            }
            else
            {
                return 0;
            }
        }



        /// <summary>
        /// GetPayPeriodId
        /// </summary>
        /// <param name="date">date</param>
        /// <returns>Pay Period Id or 0</returns>
        public int GetPayPeriodId(DateTime date)
        {
            LoadByDate(date.Year, date.Month, date.Day);

            if (Table.Rows.Count > 0)
            {
                return (int)Table.Rows[0]["PayPeriodID"]; ;
            }
            else
            {
                return 0;
            }
        }



        /// <summary>
        /// GetCurrent
        /// </summary>
        public int GetCurrent()
        {
            return GetPayPeriodId(DateTime.Now);
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="payPeriodId">payPeriodId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int payPeriodId)
        {
            string filter = string.Format("PayPeriodID = {0}", payPeriodId);
            return Table.Select(filter)[0];
        }



        /// <summary>
        /// GetStartDate
        /// </summary>
        /// <param name="payPeriodId">payPeriodId</param>
        /// <returns>Start Date</returns>
        public DateTime GetStartDate(int payPeriodId)
        {
            return (DateTime)GetRow(payPeriodId)["StartDate"];
        }



        /// <summary>
        /// GetEndDate
        /// </summary>
        /// <param name="payPeriodId">payPeriodId</param>
        /// <returns>End Date</returns>
        public DateTime GetEndDate(int payPeriodId)
        {
            return (DateTime)GetRow(payPeriodId)["EndDate"];
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
    }
}
