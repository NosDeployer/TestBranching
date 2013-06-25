using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeeCostHistoryGateway
    /// </summary>
    public class EmployeeCostHistoryGateway: DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeCostHistoryGateway()
            : base("LFS_RESOURCES_EMPLOYEE_COST_HISTORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeCostHistoryGateway(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE_COST_HISTORY")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeTDS();
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
            tableMapping.DataSetTable = "LFS_RESOURCES_EMPLOYEE_COST_HISTORY";
            tableMapping.ColumnMappings.Add("CostID", "CostID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("UnitOfMeasurement", "UnitOfMeasurement");
            tableMapping.ColumnMappings.Add("PayRateCad", "PayRateCad");
            tableMapping.ColumnMappings.Add("BurdenRateCad", "BurdenRateCad");
            tableMapping.ColumnMappings.Add("TotalCostCad", "TotalCostCad");
            tableMapping.ColumnMappings.Add("PayRateUsd", "PayRateUsd");
            tableMapping.ColumnMappings.Add("BurdenRateUsd", "BurdenRateUsd");
            tableMapping.ColumnMappings.Add("TotalCostUsd", "TotalCostUsd");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("BenefitFactorCad", "BenefitFactorCad");
            tableMapping.ColumnMappings.Add("BenefitFactorUsd", "BenefitFactorUsd");
            tableMapping.ColumnMappings.Add("HealthBenefitUsd", "HealthBenefitUsd");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_RESOURCES_EMPLOYEE_COST_HISTORY] WHERE (([CostID] = @Original_CostID) AND ([EmployeeID] = @Original_EmployeeID) AND ([Date] = @Original_Date) AND ([UnitOfMeasurement] = @Original_UnitOfMeasurement) AND ([PayRateCad] = @Original_PayRateCad) AND ([BurdenRateCad] = @Original_BurdenRateCad) AND ([TotalCostCad] = @Original_TotalCostCad) AND ([PayRateUsd] = @Original_PayRateUsd) AND ([BurdenRateUsd] = @Original_BurdenRateUsd) AND ([TotalCostUsd] = @Original_TotalCostUsd) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([BenefitFactorCad] = @Original_BenefitFactorCad) AND ([BenefitFactorUsd] = @Original_BenefitFactorUsd) AND ((@IsNull_HealthBenefitUsd = 1 AND [HealthBenefitUsd] IS NULL) OR ([HealthBenefitUsd] = @Original_HealthBenefitUsd)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PayRateCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PayRateCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BurdenRateCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BurdenRateCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PayRateUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PayRateUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BurdenRateUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BurdenRateUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BenefitFactorCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BenefitFactorUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_HealthBenefitUsd", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HealthBenefitUsd", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HealthBenefitUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HealthBenefitUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_RESOURCES_EMPLOYEE_COST_HISTORY] ([CostID], [EmployeeID], [Date], [UnitOfMeasurement], [PayRateCad], [BurdenRateCad], [TotalCostCad], [PayRateUsd], [BurdenRateUsd], [TotalCostUsd], [Deleted], [COMPANY_ID], [BenefitFactorCad], [BenefitFactorUsd], [HealthBenefitUsd]) VALUES (@CostID, @EmployeeID, @Date, @UnitOfMeasurement, @PayRateCad, @BurdenRateCad, @TotalCostCad, @PayRateUsd, @BurdenRateUsd, @TotalCostUsd, @Deleted, @COMPANY_ID, @BenefitFactorCad, @BenefitFactorUsd, @HealthBenefitUsd);
SELECT CostID, EmployeeID, Date, UnitOfMeasurement, PayRateCad, BurdenRateCad, TotalCostCad, PayRateUsd, BurdenRateUsd, TotalCostUsd, Deleted, COMPANY_ID, BenefitFactorCad, BenefitFactorUsd, HealthBenefitUsd FROM LFS_RESOURCES_EMPLOYEE_COST_HISTORY WHERE (CostID = @CostID) AND (EmployeeID = @EmployeeID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PayRateCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PayRateCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BurdenRateCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BurdenRateCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PayRateUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PayRateUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BurdenRateUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BurdenRateUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BenefitFactorCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BenefitFactorUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HealthBenefitUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HealthBenefitUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE_COST_HISTORY] SET [CostID] = @CostID, [Emplo" +
                "yeeID] = @EmployeeID, [Date] = @Date, [UnitOfMeasurement] = @UnitOfMeasurement, " +
                "[PayRateCad] = @PayRateCad, [BurdenRateCad] = @BurdenRateCad, [TotalCostCad] = @" +
                "TotalCostCad, [PayRateUsd] = @PayRateUsd, [BurdenRateUsd] = @BurdenRateUsd, [Tot" +
                "alCostUsd] = @TotalCostUsd, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [B" +
                "enefitFactorCad] = @BenefitFactorCad, [BenefitFactorUsd] = @BenefitFactorUsd, [H" +
                "ealthBenefitUsd] = @HealthBenefitUsd WHERE (([CostID] = @Original_CostID) AND ([" +
                "EmployeeID] = @Original_EmployeeID) AND ([Date] = @Original_Date) AND ([UnitOfMe" +
                "asurement] = @Original_UnitOfMeasurement) AND ([PayRateCad] = @Original_PayRateC" +
                "ad) AND ([BurdenRateCad] = @Original_BurdenRateCad) AND ([TotalCostCad] = @Origi" +
                "nal_TotalCostCad) AND ([PayRateUsd] = @Original_PayRateUsd) AND ([BurdenRateUsd]" +
                " = @Original_BurdenRateUsd) AND ([TotalCostUsd] = @Original_TotalCostUsd) AND ([" +
                "Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([Be" +
                "nefitFactorCad] = @Original_BenefitFactorCad) AND ([BenefitFactorUsd] = @Origina" +
                "l_BenefitFactorUsd) AND ((@IsNull_HealthBenefitUsd = 1 AND [HealthBenefitUsd] IS" +
                " NULL) OR ([HealthBenefitUsd] = @Original_HealthBenefitUsd)));\r\nSELECT CostID, E" +
                "mployeeID, Date, UnitOfMeasurement, PayRateCad, BurdenRateCad, TotalCostCad, Pay" +
                "RateUsd, BurdenRateUsd, TotalCostUsd, Deleted, COMPANY_ID, BenefitFactorCad, Ben" +
                "efitFactorUsd, HealthBenefitUsd FROM LFS_RESOURCES_EMPLOYEE_COST_HISTORY WHERE (" +
                "CostID = @CostID) AND (EmployeeID = @EmployeeID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PayRateCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PayRateCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BurdenRateCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BurdenRateCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PayRateUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PayRateUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BurdenRateUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BurdenRateUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BenefitFactorCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BenefitFactorUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HealthBenefitUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HealthBenefitUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PayRateCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PayRateCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BurdenRateCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BurdenRateCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PayRateUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PayRateUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BurdenRateUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BurdenRateUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BenefitFactorCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BenefitFactorUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_HealthBenefitUsd", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HealthBenefitUsd", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HealthBenefitUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HealthBenefitUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }

        



        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a employee cost (direct to DB)
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="date">date</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="payRateCad">payRateCad</param>
        /// <param name="burdenRateCad">burdenRateCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="payRateUsd">payRateUsd</param>
        /// <param name="burdenRateUsd">burdenRateUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>        
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="benefitFactorCad">benefitFactorCad</param>
        /// <param name="benefitFactorUsd">benefitFactorUsd</param>
        /// <param name="healthBenefitUsd">healthBenefitUsd</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int costId, int employeeId, DateTime date, string unitOfMeasurement, decimal payRateCad, decimal burdenRateCad, decimal totalCostCad, decimal payRateUsd, decimal burdenRateUsd, decimal totalCostUsd, bool deleted, int companyId, decimal benefitFactorCad, decimal benefitFactorUsd, decimal healthBenefitUsd)
        {
            SqlParameter costIdParameter = new SqlParameter("CostID", costId);
            SqlParameter employeeIdParameter = new SqlParameter("EmployeeID", employeeId);
            SqlParameter dateParameter = new SqlParameter("Date", date);
            SqlParameter unitOfMeasurementParameter = new SqlParameter("UnitOfMeasurement", unitOfMeasurement);            
            SqlParameter payRateCadParameter = new SqlParameter("PayRateCad", payRateCad); payRateCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter burdenRateCadParameter = new SqlParameter("BurdenRateCad", burdenRateCad); burdenRateCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter totalCostCadParameter = new SqlParameter("TotalCostCad", totalCostCad); totalCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter payRateUsdParameter = new SqlParameter("PayRateUsd", payRateUsd); payRateUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter burdenRateUsdParameter = new SqlParameter("BurdenRateUsd", burdenRateUsd); burdenRateUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter totalCostUsdParameter = new SqlParameter("TotalCostUsd", totalCostUsd); totalCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter benefitFactorCadParameter = new SqlParameter("BenefitFactorCad", benefitFactorCad); benefitFactorCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter benefitFactorUsdParameter = new SqlParameter("BenefitFactorUsd", benefitFactorUsd); benefitFactorUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter healthBenefitUsdParameter = new SqlParameter("HealthBenefitUsd", healthBenefitUsd);
            healthBenefitUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_RESOURCES_EMPLOYEE_COST_HISTORY] ([CostID], [EmployeeID], [Date], [UnitOfMeasurement], [PayRateCad], [BurdenRateCad], [TotalCostCad], [PayRateUsd], [BurdenRateUsd], [TotalCostUsd], [Deleted], [COMPANY_ID], [BenefitFactorCad], [BenefitFactorUsd], [HealthBenefitUsd]) VALUES (@CostID, @EmployeeID, @Date, @UnitOfMeasurement, @PayRateCad, @BurdenRateCad, @TotalCostCad, @PayRateUsd, @BurdenRateUsd, @TotalCostUsd, @Deleted, @COMPANY_ID, @BenefitFactorCad, @BenefitFactorUsd, @HealthBenefitUsd)";

            int rowsAffected = (int)ExecuteNonQuery(command, costIdParameter, employeeIdParameter, dateParameter, unitOfMeasurementParameter, payRateCadParameter, burdenRateCadParameter, totalCostCadParameter, payRateUsdParameter, burdenRateUsdParameter, totalCostUsdParameter, deletedParameter, companyIdParameter, benefitFactorCadParameter, benefitFactorUsdParameter, healthBenefitUsdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update employee cost (direct to DB)
        /// </summary>
        /// <param name="originalCostId">originalCostId</param>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalDate">originalDate</param>
        /// <param name="originalUnitOfMeasurement">originalUnitOfMeasurement</param>
        /// <param name="originalPayRateCad">originalPayRateCad</param>
        /// <param name="originalBurdenRateCad">originalBurdenRateCad</param>
        /// <param name="originalTotalCostCad">originalTotalCostCad</param>
        /// <param name="originalPayRateUsd">originalPayRateUsd</param>
        /// <param name="originalBurdenRateUsd">originalBurdenRateUsd</param>
        /// <param name="originalTotalCostUsd">originalTotalCostUsd</param>        
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalBenefitFactorCad">originalBenefitFactorCad</param>
        /// <param name="originalBenefitFactorUsd">originalBenefitFactorUsd</param>
        /// <param name="originalHealthBenefitUsd">originalHealthBenefitUsd</param>
        ///
        /// <param name="newCostId">newCostId</param>
        /// <param name="newEmployeeId">newEmployeeId</param>
        /// <param name="newDate">newDate</param>
        /// <param name="newUnitOfMeasurement">newUnitOfMeasurement</param>
        /// <param name="newPayRateCad">newPayRateCad</param>
        /// <param name="newBurdenRateCad">newBurdenRateCad</param>
        /// <param name="newTotalCostCad">newTotalCostCad</param>
        /// <param name="newPayRateUsd">newPayRateUsd</param>
        /// <param name="newBurdenRateUsd">newBurdenRateUsd</param>
        /// <param name="newTotalCostUsd">newTotalCostUsd</param>        
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newBenefitFactorCad">newBenefitFactorCad</param>
        /// <param name="newBenefitFactorUsd">newBenefitFactorUsd</param>
        /// <param name="newHealthBenefitUsd">newHealthBenefitUsd</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalCostId, int originalEmployeeId, DateTime originalDate, string originalUnitOfMeasurement, decimal originalPayRateCad, decimal originalBurdenRateCad, decimal originalTotalCostCad, decimal originalPayRateUsd, decimal originalBurdenRateUsd, decimal originalTotalCostUsd, bool originalDeleted, int originalCompanyId, decimal originalBenefitFactorCad, decimal originalBenefitFactorUsd, decimal originalHealthBenefitUsd, int newCostId, int newEmployeeId, DateTime newDate, string newUnitOfMeasurement, decimal newPayRateCad, decimal newBurdenRateCad, decimal newTotalCostCad, decimal newPayRateUsd, decimal newBurdenRateUsd, decimal newTotalCostUsd, bool newDeleted, int newCompanyId, decimal newBenefitFactorCad, decimal newBenefitFactorUsd, decimal newHealthBenefitUsd)
        {
            SqlParameter originalCostIdParameter = new SqlParameter("Original_CostID", originalCostId);
            SqlParameter originalEmployeeIdParameter = new SqlParameter("Original_EmployeeID", originalEmployeeId);
            SqlParameter originalDateParameter = new SqlParameter("Original_Date", originalDate);
            SqlParameter originalUnitOfMeasurmentParameter = new SqlParameter("Original_UnitOfMeasurement", originalUnitOfMeasurement);
            SqlParameter originalPayRateCadParameter = new SqlParameter("Original_PayRateCad", originalPayRateCad); originalPayRateCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalBurdenRateCadParameter = new SqlParameter("Original_BurdenRateCad", originalBurdenRateCad); originalBurdenRateCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalTotalCostCadParameter = new SqlParameter("Original_TotalCostCad", originalTotalCostCad);originalTotalCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalPayRateUsdParameter = new SqlParameter("Original_PayRateUsd", originalPayRateUsd); originalPayRateUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalBurdenRateUsdParameter = new SqlParameter("Original_BurdenRateUsd", originalBurdenRateUsd); originalBurdenRateUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalTotalCostUsdParameter = new SqlParameter("Original_TotalCostUsd", originalTotalCostUsd); originalTotalCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalBenefitFactorCadParameter = new SqlParameter("Original_BenefitFactorCad", originalBenefitFactorCad); originalBenefitFactorCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalBenefitFactorUsdParameter = new SqlParameter("Original_BenefitFactorUsd", originalBenefitFactorUsd); originalBenefitFactorUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalHealthBenefitUsdParameter = new SqlParameter("Original_HealthBenefitUsd", originalHealthBenefitUsd);
            originalHealthBenefitUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);            

            SqlParameter newCostIdParameter = new SqlParameter("CostID", newCostId);
            SqlParameter newEmployeeIdParameter = new SqlParameter("EmployeeID", newEmployeeId);
            SqlParameter newDateParameter = new SqlParameter("Date", newDate);
            SqlParameter newUnitOfMeasurmentParameter = new SqlParameter("UnitOfMeasurement", newUnitOfMeasurement);
            SqlParameter newPayRateCadParameter = new SqlParameter("PayRateCad", newPayRateCad); newPayRateCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newBurdenRateCadParameter = new SqlParameter("BurdenRateCad", newBurdenRateCad); newBurdenRateCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newTotalCostCadParameter = new SqlParameter("TotalCostCad", newTotalCostCad); newTotalCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newPayRateUsdParameter = new SqlParameter("PayRateUsd", newPayRateUsd); newPayRateUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newBurdenRateUsdParameter = new SqlParameter("BurdenRateUsd", newBurdenRateUsd); newBurdenRateUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newTotalCostUsdParameter = new SqlParameter("TotalCostUsd", newTotalCostUsd); newTotalCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newBenefitFactorCadParameter = new SqlParameter("BenefitFactorCad", newBenefitFactorCad); newBenefitFactorCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newBenefitFactorUsdParameter = new SqlParameter("BenefitFactorUsd", newBenefitFactorUsd); newBenefitFactorUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newHealthBenefitUsdParameter = new SqlParameter("HealthBenefitUsd", newHealthBenefitUsd);
            newHealthBenefitUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE_COST_HISTORY] SET  [Date] = @Date, [UnitOfMeasurement] = @UnitOfMeasurement, " +
                "[PayRateCad] = @PayRateCad, [BurdenRateCad] = @BurdenRateCad, [TotalCostCad] = @" +
                "TotalCostCad, [PayRateUsd] = @PayRateUsd, [BurdenRateUsd] = @BurdenRateUsd, [Tot" +
                "alCostUsd] = @TotalCostUsd, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [B" +
                "enefitFactorCad] = @BenefitFactorCad, [BenefitFactorUsd] = @BenefitFactorUsd, [H" +
                "ealthBenefitUsd] = @HealthBenefitUsd " +
            " WHERE (([CostID] = @Original_CostID) AND ([EmployeeID] = @Original_EmployeeID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCostIdParameter, originalEmployeeIdParameter, originalDateParameter, originalUnitOfMeasurmentParameter, originalPayRateCadParameter, originalBurdenRateCadParameter, originalTotalCostCadParameter, originalPayRateUsdParameter, originalBurdenRateUsdParameter, originalTotalCostUsdParameter, originalDeletedParameter, originalCompanyIdParameter, originalBenefitFactorCadParameter, originalBenefitFactorUsdParameter, originalHealthBenefitUsdParameter, newCostIdParameter, newEmployeeIdParameter, newDateParameter, newUnitOfMeasurmentParameter, newPayRateCadParameter, newBurdenRateCadParameter, newTotalCostCadParameter, newPayRateUsdParameter, newBurdenRateUsdParameter, newTotalCostUsdParameter, newDeletedParameter, newCompanyIdParameter, newBenefitFactorCadParameter, newBenefitFactorUsdParameter, newHealthBenefitUsdParameter); 

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }


        
        /// <summary>
        /// Delete a employee cost (direct to DB)
        /// </summary>
        /// <param name="originalCostId">originalCostId</param>
        /// <param name="originalEmployeeId">originalEmployeeId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalCostId, int originalEmployeeId, int originalCompanyId)
        {
            SqlParameter originalCostIdParameter = new SqlParameter("@Original_CostID", originalCostId);
            SqlParameter originalEmployeeIdParameter = new SqlParameter("@Original_EmployeeID", originalEmployeeId);            
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = " UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE_COST_HISTORY] SET  [Deleted] = @Deleted  " +
                             " WHERE (([CostID] = @Original_CostID) AND ([EmployeeID] = @Original_EmployeeID)  " +
                             " AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCostIdParameter, originalEmployeeIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete all employees costs (direct to DB)
        /// </summary>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int DeleteAll(int originalEmployeeId, int originalCompanyId)
        {
            SqlParameter originalEmployeeIdParameter = new SqlParameter("@Original_EmployeeID", originalEmployeeId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE_COST_HISTORY] SET  [Deleted] = @Deleted  " +
                             " WHERE (([EmployeeID] = @Original_EmployeeID) AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalEmployeeIdParameter, originalCompanyIdParameter, deletedParameter);

            return rowsAffected;
        }



    }
}