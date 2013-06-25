using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeeCostHistoryExceptionsGateway
    /// </summary>
    public class EmployeeCostHistoryExceptionsGateway: DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeCostHistoryExceptionsGateway()
            : base("LFS_RESOURCES_EMPLOYEE_COST_HISTORY_EXCEPTIONS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeCostHistoryExceptionsGateway(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE_COST_HISTORY_EXCEPTIONS")
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
            tableMapping.DataSetTable = "LFS_RESOURCES_EMPLOYEE_COST_HISTORY_EXCEPTIONS";
            tableMapping.ColumnMappings.Add("CostID", "CostID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("Work_", "Work_");
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
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_RESOURCES_EMPLOYEE_COST_HISTORY_EXCEPTIONS] WHERE (([CostID] = @Original_CostID) AND ([RefID] = @Original_RefID) AND ([EmployeeID] = @Original_EmployeeID) AND ([Work_] = @Original_Work_) AND ([UnitOfMeasurement] = @Original_UnitOfMeasurement) AND ([PayRateCad] = @Original_PayRateCad) AND ([BurdenRateCad] = @Original_BurdenRateCad) AND ([TotalCostCad] = @Original_TotalCostCad) AND ([PayRateUsd] = @Original_PayRateUsd) AND ([BurdenRateUsd] = @Original_BurdenRateUsd) AND ([TotalCostUsd] = @Original_TotalCostUsd) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([BenefitFactorCad] = @Original_BenefitFactorCad) AND ([BenefitFactorUsd] = @Original_BenefitFactorUsd) AND ((@IsNull_HealthBenefitUsd = 1 AND [HealthBenefitUsd] IS NULL) OR ([HealthBenefitUsd] = @Original_HealthBenefitUsd)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_RESOURCES_EMPLOYEE_COST_HISTORY_EXCEPTIONS] ([CostID], [RefID], [EmployeeID], [Work_], [UnitOfMeasurement], [PayRateCad], [BurdenRateCad], [TotalCostCad], [PayRateUsd], [BurdenRateUsd], [TotalCostUsd], [Deleted], [COMPANY_ID], [BenefitFactorCad], [BenefitFactorUsd], [HealthBenefitUsd]) VALUES (@CostID, @RefID, @EmployeeID, @Work_, @UnitOfMeasurement, @PayRateCad, @BurdenRateCad, @TotalCostCad, @PayRateUsd, @BurdenRateUsd, @TotalCostUsd, @Deleted, @COMPANY_ID, @BenefitFactorCad, @BenefitFactorUsd, @HealthBenefitUsd);
SELECT CostID, RefID, EmployeeID, Work_, UnitOfMeasurement, PayRateCad, BurdenRateCad, TotalCostCad, PayRateUsd, BurdenRateUsd, TotalCostUsd, Deleted, COMPANY_ID, BenefitFactorCad, BenefitFactorUsd, HealthBenefitUsd FROM LFS_RESOURCES_EMPLOYEE_COST_HISTORY_EXCEPTIONS WHERE (CostID = @CostID) AND (EmployeeID = @EmployeeID) AND (RefID = @RefID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
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
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE_COST_HISTORY_EXCEPTIONS] SET [CostID] = @Cos" +
                "tID, [RefID] = @RefID, [EmployeeID] = @EmployeeID, [Work_] = @Work_, [UnitOfMeas" +
                "urement] = @UnitOfMeasurement, [PayRateCad] = @PayRateCad, [BurdenRateCad] = @Bu" +
                "rdenRateCad, [TotalCostCad] = @TotalCostCad, [PayRateUsd] = @PayRateUsd, [Burden" +
                "RateUsd] = @BurdenRateUsd, [TotalCostUsd] = @TotalCostUsd, [Deleted] = @Deleted," +
                " [COMPANY_ID] = @COMPANY_ID, [BenefitFactorCad] = @BenefitFactorCad, [BenefitFac" +
                "torUsd] = @BenefitFactorUsd, [HealthBenefitUsd] = @HealthBenefitUsd WHERE (([Cos" +
                "tID] = @Original_CostID) AND ([RefID] = @Original_RefID) AND ([EmployeeID] = @Or" +
                "iginal_EmployeeID) AND ([Work_] = @Original_Work_) AND ([UnitOfMeasurement] = @O" +
                "riginal_UnitOfMeasurement) AND ([PayRateCad] = @Original_PayRateCad) AND ([Burde" +
                "nRateCad] = @Original_BurdenRateCad) AND ([TotalCostCad] = @Original_TotalCostCa" +
                "d) AND ([PayRateUsd] = @Original_PayRateUsd) AND ([BurdenRateUsd] = @Original_Bu" +
                "rdenRateUsd) AND ([TotalCostUsd] = @Original_TotalCostUsd) AND ([Deleted] = @Ori" +
                "ginal_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([BenefitFactorCad]" +
                " = @Original_BenefitFactorCad) AND ([BenefitFactorUsd] = @Original_BenefitFactor" +
                "Usd) AND ((@IsNull_HealthBenefitUsd = 1 AND [HealthBenefitUsd] IS NULL) OR ([Hea" +
                "lthBenefitUsd] = @Original_HealthBenefitUsd)));\r\nSELECT CostID, RefID, EmployeeI" +
                "D, Work_, UnitOfMeasurement, PayRateCad, BurdenRateCad, TotalCostCad, PayRateUsd" +
                ", BurdenRateUsd, TotalCostUsd, Deleted, COMPANY_ID, BenefitFactorCad, BenefitFac" +
                "torUsd, HealthBenefitUsd FROM LFS_RESOURCES_EMPLOYEE_COST_HISTORY_EXCEPTIONS WHE" +
                "RE (CostID = @CostID) AND (EmployeeID = @EmployeeID) AND (RefID = @RefID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
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
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
        /// Insert a employee cost exceptions (direct to DB)
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="work_">work_</param>       
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
        public int Insert(int costId, int refId, int employeeId, string work_, string unitOfMeasurement, decimal payRateCad, decimal burdenRateCad, decimal totalCostCad, decimal payRateUsd, decimal burdenRateUsd, decimal totalCostUsd, bool deleted, int companyId, decimal benefitFactorCad, decimal benefitFactorUsd, decimal healthBenefitUsd)
        {
            SqlParameter costIdParameter = new SqlParameter("CostID", costId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter employeeIdParameter = new SqlParameter("EmployeeID", employeeId);
            SqlParameter workIdParameter = new SqlParameter("Work_", work_);            
            SqlParameter unitOfMeasurementParameter = new SqlParameter("UnitOfMeasurement", unitOfMeasurement); 
            SqlParameter payRateCadParameter = new SqlParameter("PayRateCad", payRateCad); 
            payRateCadParameter.SqlDbType = SqlDbType.Money;  
            SqlParameter burdenRateCadParameter = new SqlParameter("BurdenRateCad", burdenRateCad); 
            burdenRateCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter totalCostCadParameter = new SqlParameter("TotalCostCad", totalCostCad); 
            totalCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter payRateUsdParameter = new SqlParameter("PayRateUsd", payRateUsd); 
            payRateUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter burdenRateUsdParameter = new SqlParameter("BurdenRateUsd", burdenRateUsd); 
            burdenRateUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter totalCostUsdParameter = new SqlParameter("TotalCostUsd", totalCostUsd); 
            totalCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter benefitFactorCadParameter = new SqlParameter("BenefitFactorCad", benefitFactorCad); 
            benefitFactorCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter benefitFactorUsdParameter = new SqlParameter("BenefitFactorUsd", benefitFactorUsd); 
            benefitFactorUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter healthBenefitUsdParameter = new SqlParameter("HealthBenefitUsd", healthBenefitUsd); 
            healthBenefitUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_RESOURCES_EMPLOYEE_COST_HISTORY_EXCEPTIONS] ([CostID], [RefID], [EmployeeID], [Work_], [UnitOfMeasurement], [PayRateCad], [BurdenRateCad], [TotalCostCad], [PayRateUsd], [BurdenRateUsd], [TotalCostUsd], [Deleted], [COMPANY_ID], [BenefitFactorCad], [BenefitFactorUsd], [HealthBenefitUsd]) VALUES (@CostID, @RefID, @EmployeeID, @Work_, @UnitOfMeasurement, @PayRateCad, @BurdenRateCad, @TotalCostCad, @PayRateUsd, @BurdenRateUsd, @TotalCostUsd, @Deleted, @COMPANY_ID, @BenefitFactorCad, @BenefitFactorUsd, @HealthBenefitUsd)";

            int rowsAffected = (int)ExecuteNonQuery(command, costIdParameter, refIdParameter, employeeIdParameter, workIdParameter, unitOfMeasurementParameter, payRateCadParameter, burdenRateCadParameter, totalCostCadParameter, payRateUsdParameter, burdenRateUsdParameter, totalCostUsdParameter, deletedParameter, companyIdParameter, benefitFactorCadParameter, benefitFactorUsdParameter, healthBenefitUsdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update employee cost exceptions (direct to DB)
        /// </summary>
        /// <param name="originalCostId">originalCostId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalWork">originalWork</param>        
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
        /// <param name="newRefId">newRefId</param>
        /// <param name="newEmployeeId">newEmployeeId</param>
        /// <param name="newWork">newWork</param>        
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
        public int Update(int originalCostId, int originalRefId, int originalEmployeeId, string originalWork, string originalUnitOfMeasurement, decimal originalPayRateCad, decimal originalBurdenRateCad, decimal originalTotalCostCad, decimal originalPayRateUsd, decimal originalBurdenRateUsd, decimal originalTotalCostUsd, bool originalDeleted, int originalCompanyId, decimal originalBenefitFactorCad, decimal originalBenefitFactorUsd, decimal originalHealthBenefitUsd, int newCostId, int newRefId, int newEmployeeId, string newWork, string newUnitOfMeasurement, decimal newPayRateCad, decimal newBurdenRateCad, decimal newTotalCostCad, decimal newPayRateUsd, decimal newBurdenRateUsd, decimal newTotalCostUsd, bool newDeleted, int newCompanyId, decimal newBenefitFactorCad, decimal newBenefitFactorUsd, decimal newHealthBenefitUsd)
        {
            SqlParameter originalCostIdParameter = new SqlParameter("Original_CostID", originalCostId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalEmployeeIdParameter = new SqlParameter("Original_EmployeeID", originalEmployeeId);
            SqlParameter originalWorkParameter = new SqlParameter("Original_Work_", originalWork);            
            SqlParameter originalUnitOfMeasurementParameter = new SqlParameter("Original_UnitOfMeasurement", originalUnitOfMeasurement);
            SqlParameter originalPayRateCadParameter = new SqlParameter("Original_PayRateCad", originalPayRateCad);
            originalPayRateCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalBurdenRateCadParameter = new SqlParameter("Original_BurdenRateCad", originalBurdenRateCad);
            originalBurdenRateCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalTotalCostCadParameter = new SqlParameter("Original_TotalCostCad", originalTotalCostCad);
            originalTotalCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalPayRateUsdParameter = new SqlParameter("Original_PayRateUsd", originalPayRateUsd);
            originalPayRateUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalBurdenRateUsdParameter = new SqlParameter("Original_BurdenRateUsd", originalBurdenRateUsd);
            originalBurdenRateUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalTotalCostUsdParameter = new SqlParameter("Original_TotalCostUsd", originalTotalCostUsd);
            originalTotalCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalBenefitFactorCadParameter = new SqlParameter("Original_BenefitFactorCad", originalBenefitFactorCad); 
            originalBenefitFactorCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalBenefitFactorUsdParameter = new SqlParameter("Original_BenefitFactorUsd", originalBenefitFactorUsd); 
            originalBenefitFactorUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalHealthBenefitUsdParameter = new SqlParameter("Original_HealthBenefitUsd", originalHealthBenefitUsd);
            originalHealthBenefitUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newCostIdParameter = new SqlParameter("CostID", newCostId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", newRefId);
            SqlParameter newEmployeeIdParameter = new SqlParameter("EmployeeID", newEmployeeId);
            SqlParameter newWorkParameter = new SqlParameter("Work_", newWork);            
            SqlParameter newUnitOfMeasurementParameter = new SqlParameter("UnitOfMeasurement", newUnitOfMeasurement);
            SqlParameter newPayRateCadParameter = new SqlParameter("PayRateCad", newPayRateCad);
            newPayRateCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newBurdenRateCadParameter = new SqlParameter("BurdenRateCad", newBurdenRateCad);
            newBurdenRateCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newTotalCostCadParameter = new SqlParameter("TotalCostCad", newTotalCostCad);
            newTotalCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newPayRateUsdParameter = new SqlParameter("PayRateUsd", newPayRateUsd);
            newPayRateUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newBurdenRateUsdParameter = new SqlParameter("BurdenRateUsd", newBurdenRateUsd);
            newBurdenRateUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newTotalCostUsdParameter = new SqlParameter("TotalCostUsd", newTotalCostUsd);
            newTotalCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newBenefitFactorCadParameter = new SqlParameter("BenefitFactorCad", newBenefitFactorCad); 
            newBenefitFactorCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newBenefitFactorUsdParameter = new SqlParameter("BenefitFactorUsd", newBenefitFactorUsd);
            newBenefitFactorUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newHealthBenefitUsdParameter = new SqlParameter("HealthBenefitUsd", newHealthBenefitUsd);
            newHealthBenefitUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE_COST_HISTORY_EXCEPTIONS] SET [Work_] = @Work_, [UnitOfMeas" +
                "urement] = @UnitOfMeasurement, [PayRateCad] = @PayRateCad, [BurdenRateCad] = @Bu" +
                "rdenRateCad, [TotalCostCad] = @TotalCostCad, [PayRateUsd] = @PayRateUsd, [Burden" +
                "RateUsd] = @BurdenRateUsd, [TotalCostUsd] = @TotalCostUsd, [Deleted] = @Deleted," +
                " [COMPANY_ID] = @COMPANY_ID, [BenefitFactorCad] = @BenefitFactorCad, [BenefitFac" +
                "torUsd] = @BenefitFactorUsd, [HealthBenefitUsd] = @HealthBenefitUsd " +
                " WHERE (([CostID] = @Original_CostID) AND ([RefID] = @Original_RefID)  AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCostIdParameter, originalRefIdParameter, originalEmployeeIdParameter, originalWorkParameter, originalUnitOfMeasurementParameter, originalPayRateCadParameter, originalBurdenRateCadParameter, originalTotalCostCadParameter, originalPayRateUsdParameter, originalBurdenRateUsdParameter, originalTotalCostUsdParameter, originalDeletedParameter, originalCompanyIdParameter, originalBenefitFactorCadParameter, originalBenefitFactorUsdParameter, originalHealthBenefitUsdParameter, newCostIdParameter, newRefIdParameter, newEmployeeIdParameter, newWorkParameter, newUnitOfMeasurementParameter, newPayRateCadParameter, newBurdenRateCadParameter, newTotalCostCadParameter, newPayRateUsdParameter, newBurdenRateUsdParameter, newTotalCostUsdParameter, newDeletedParameter, newCompanyIdParameter, newBenefitFactorCadParameter, newBenefitFactorUsdParameter, newHealthBenefitUsdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete a employee cost exceptions (direct to DB)
        /// </summary>
        /// <param name="originalCostId">originalCostId</param>
        /// <param name="originalRefId">originalRefId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalCostId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalCostIdParameter = new SqlParameter("@Original_CostID", originalCostId);
            SqlParameter originalRefIdParameter = new SqlParameter("@Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE_COST_HISTORY_EXCEPTIONS] SET  [Deleted] = @Deleted  " +
                             " WHERE (([CostID] = @Original_CostID) AND ([RefID] = @Original_RefID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCostIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete all employees costs exceptions (direct to DB)
        /// </summary>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int DeleteAll(int originalEmployeeId, int originalCompanyId)
        {
            SqlParameter originalEmployeeIdParameter = new SqlParameter("@Original_EmployeeID", originalEmployeeId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE_COST_HISTORY_EXCEPTIONS] SET  [Deleted] = @Deleted  " +
                             " WHERE (([EmployeeID] = @Original_EmployeeID) " +
                             " AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalEmployeeIdParameter, originalCompanyIdParameter, deletedParameter);

            return rowsAffected;
        }



    }
}