using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCombinedCostingSheetLabourHoursGateway
    /// </summary>
    public class ProjectCombinedCostingSheetLabourHoursGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCombinedCostingSheetLabourHoursGateway()
            : base("LFS_PROJECT_COMBINED_COSTING_SHEET_LABOUR_HOURS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCombinedCostingSheetLabourHoursGateway(DataSet data)
            : base(data, "LFS_PROJECT_COMBINED_COSTING_SHEET_LABOUR_HOURS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetTDS();
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
            tableMapping.DataSetTable = "LFS_PROJECT_COMBINED_COSTING_SHEET_LABOUR_HOURS";
            tableMapping.ColumnMappings.Add("CostingSheetID", "CostingSheetID");
            tableMapping.ColumnMappings.Add("Work_", "Work_");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("LHQuantity", "LHQuantity");
            tableMapping.ColumnMappings.Add("LHUnitOfMeasurement", "LHUnitOfMeasurement");
            tableMapping.ColumnMappings.Add("MealsUnitOfMeasurement", "MealsUnitOfMeasurement");
            tableMapping.ColumnMappings.Add("MealsQuantity", "MealsQuantity");
            tableMapping.ColumnMappings.Add("MotelUnitOfMeasurement", "MotelUnitOfMeasurement");
            tableMapping.ColumnMappings.Add("MotelQuantity", "MotelQuantity");
            tableMapping.ColumnMappings.Add("LHCostCad", "LHCostCad");
            tableMapping.ColumnMappings.Add("MealsCostCad", "MealsCostCad");
            tableMapping.ColumnMappings.Add("MotelCostCad", "MotelCostCad");
            tableMapping.ColumnMappings.Add("TotalCostCad", "TotalCostCad");
            tableMapping.ColumnMappings.Add("LHCostUsd", "LHCostUsd");
            tableMapping.ColumnMappings.Add("MealsCostUsd", "MealsCostUsd");
            tableMapping.ColumnMappings.Add("MotelCostUsd", "MotelCostUsd");
            tableMapping.ColumnMappings.Add("TotalCostUsd", "TotalCostUsd");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("Function_", "Function_");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_PROJECT_COMBINED_COSTING_SHEET_LABOUR_HOURS] WHERE (([CostingSheetI" +
                "D] = @Original_CostingSheetID) AND ([Work_] = @Original_Work_) AND ([EmployeeID]" +
                " = @Original_EmployeeID) AND ([RefID] = @Original_RefID) AND ([LHQuantity] = @Or" +
                "iginal_LHQuantity) AND ([LHUnitOfMeasurement] = @Original_LHUnitOfMeasurement) A" +
                "ND ((@IsNull_MealsUnitOfMeasurement = 1 AND [MealsUnitOfMeasurement] IS NULL) OR" +
                " ([MealsUnitOfMeasurement] = @Original_MealsUnitOfMeasurement)) AND ((@IsNull_Me" +
                "alsQuantity = 1 AND [MealsQuantity] IS NULL) OR ([MealsQuantity] = @Original_Mea" +
                "lsQuantity)) AND ((@IsNull_MotelUnitOfMeasurement = 1 AND [MotelUnitOfMeasuremen" +
                "t] IS NULL) OR ([MotelUnitOfMeasurement] = @Original_MotelUnitOfMeasurement)) AN" +
                "D ((@IsNull_MotelQuantity = 1 AND [MotelQuantity] IS NULL) OR ([MotelQuantity] =" +
                " @Original_MotelQuantity)) AND ([LHCostCad] = @Original_LHCostCad) AND ((@IsNull" +
                "_MealsCostCad = 1 AND [MealsCostCad] IS NULL) OR ([MealsCostCad] = @Original_Mea" +
                "lsCostCad)) AND ((@IsNull_MotelCostCad = 1 AND [MotelCostCad] IS NULL) OR ([Mote" +
                "lCostCad] = @Original_MotelCostCad)) AND ([TotalCostCad] = @Original_TotalCostCa" +
                "d) AND ([LHCostUsd] = @Original_LHCostUsd) AND ((@IsNull_MealsCostUsd = 1 AND [M" +
                "ealsCostUsd] IS NULL) OR ([MealsCostUsd] = @Original_MealsCostUsd)) AND ((@IsNul" +
                "l_MotelCostUsd = 1 AND [MotelCostUsd] IS NULL) OR ([MotelCostUsd] = @Original_Mo" +
                "telCostUsd)) AND ([TotalCostUsd] = @Original_TotalCostUsd) AND ([Deleted] = @Ori" +
                "ginal_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_StartDate" +
                " = 1 AND [StartDate] IS NULL) OR ([StartDate] = @Original_StartDate)) AND ((@IsN" +
                "ull_EndDate = 1 AND [EndDate] IS NULL) OR ([EndDate] = @Original_EndDate)) AND (" +
                "(@IsNull_Function_ = 1 AND [Function_] IS NULL) OR ([Function_] = @Original_Func" +
                "tion_)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostingSheetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostingSheetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LHQuantity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LHQuantity", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LHUnitOfMeasurement", global::System.Data.SqlDbType.NChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LHUnitOfMeasurement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MealsUnitOfMeasurement", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsUnitOfMeasurement", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MealsUnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsUnitOfMeasurement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MealsQuantity", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsQuantity", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MealsQuantity", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsQuantity", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MotelUnitOfMeasurement", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelUnitOfMeasurement", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MotelUnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelUnitOfMeasurement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MotelQuantity", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelQuantity", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MotelQuantity", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelQuantity", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LHCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LHCostCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MealsCostCad", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCostCad", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MealsCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCostCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MotelCostCad", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelCostCad", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MotelCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelCostCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LHCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LHCostUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MealsCostUsd", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCostUsd", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MealsCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCostUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MotelCostUsd", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelCostUsd", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MotelCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelCostUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_EndDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Function_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT_COMBINED_COSTING_SHEET_LABOUR_HOURS] ([CostingSheetID], [Work_], [EmployeeID], [RefID], [LHQuantity], [LHUnitOfMeasurement], [MealsUnitOfMeasurement], [MealsQuantity], [MotelUnitOfMeasurement], [MotelQuantity], [LHCostCad], [MealsCostCad], [MotelCostCad], [TotalCostCad], [LHCostUsd], [MealsCostUsd], [MotelCostUsd], [TotalCostUsd], [Deleted], [COMPANY_ID], [StartDate], [EndDate], [Function_]) VALUES (@CostingSheetID, @Work_, @EmployeeID, @RefID, @LHQuantity, @LHUnitOfMeasurement, @MealsUnitOfMeasurement, @MealsQuantity, @MotelUnitOfMeasurement, @MotelQuantity, @LHCostCad, @MealsCostCad, @MotelCostCad, @TotalCostCad, @LHCostUsd, @MealsCostUsd, @MotelCostUsd, @TotalCostUsd, @Deleted, @COMPANY_ID, @StartDate, @EndDate, @Function_);
SELECT CostingSheetID, Work_, EmployeeID, RefID, LHQuantity, LHUnitOfMeasurement, MealsUnitOfMeasurement, MealsQuantity, MotelUnitOfMeasurement, MotelQuantity, LHCostCad, MealsCostCad, MotelCostCad, TotalCostCad, LHCostUsd, MealsCostUsd, MotelCostUsd, TotalCostUsd, Deleted, COMPANY_ID, StartDate, EndDate, Function_ FROM LFS_PROJECT_COMBINED_COSTING_SHEET_LABOUR_HOURS WHERE (CostingSheetID = @CostingSheetID) AND (EmployeeID = @EmployeeID) AND (RefID = @RefID) AND (Work_ = @Work_)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostingSheetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostingSheetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LHQuantity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LHQuantity", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LHUnitOfMeasurement", global::System.Data.SqlDbType.NChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LHUnitOfMeasurement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsUnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsUnitOfMeasurement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsQuantity", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsQuantity", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MotelUnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelUnitOfMeasurement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MotelQuantity", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelQuantity", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LHCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LHCostCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCostCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MotelCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelCostCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LHCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LHCostUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCostUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MotelCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelCostUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_PROJECT_COMBINED_COSTING_SHEET_LABOUR_HOURS] SET [CostingSheetID] = @Cos" +
                "tingSheetID, [Work_] = @Work_, [EmployeeID] = @EmployeeID, [RefID] = @RefID, [LH" +
                "Quantity] = @LHQuantity, [LHUnitOfMeasurement] = @LHUnitOfMeasurement, [MealsUni" +
                "tOfMeasurement] = @MealsUnitOfMeasurement, [MealsQuantity] = @MealsQuantity, [Mo" +
                "telUnitOfMeasurement] = @MotelUnitOfMeasurement, [MotelQuantity] = @MotelQuantit" +
                "y, [LHCostCad] = @LHCostCad, [MealsCostCad] = @MealsCostCad, [MotelCostCad] = @M" +
                "otelCostCad, [TotalCostCad] = @TotalCostCad, [LHCostUsd] = @LHCostUsd, [MealsCos" +
                "tUsd] = @MealsCostUsd, [MotelCostUsd] = @MotelCostUsd, [TotalCostUsd] = @TotalCo" +
                "stUsd, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [StartDate] = @StartDat" +
                "e, [EndDate] = @EndDate, [Function_] = @Function_ WHERE (([CostingSheetID] = @Or" +
                "iginal_CostingSheetID) AND ([Work_] = @Original_Work_) AND ([EmployeeID] = @Orig" +
                "inal_EmployeeID) AND ([RefID] = @Original_RefID) AND ([LHQuantity] = @Original_L" +
                "HQuantity) AND ([LHUnitOfMeasurement] = @Original_LHUnitOfMeasurement) AND ((@Is" +
                "Null_MealsUnitOfMeasurement = 1 AND [MealsUnitOfMeasurement] IS NULL) OR ([Meals" +
                "UnitOfMeasurement] = @Original_MealsUnitOfMeasurement)) AND ((@IsNull_MealsQuant" +
                "ity = 1 AND [MealsQuantity] IS NULL) OR ([MealsQuantity] = @Original_MealsQuanti" +
                "ty)) AND ((@IsNull_MotelUnitOfMeasurement = 1 AND [MotelUnitOfMeasurement] IS NU" +
                "LL) OR ([MotelUnitOfMeasurement] = @Original_MotelUnitOfMeasurement)) AND ((@IsN" +
                "ull_MotelQuantity = 1 AND [MotelQuantity] IS NULL) OR ([MotelQuantity] = @Origin" +
                "al_MotelQuantity)) AND ([LHCostCad] = @Original_LHCostCad) AND ((@IsNull_MealsCo" +
                "stCad = 1 AND [MealsCostCad] IS NULL) OR ([MealsCostCad] = @Original_MealsCostCa" +
                "d)) AND ((@IsNull_MotelCostCad = 1 AND [MotelCostCad] IS NULL) OR ([MotelCostCad" +
                "] = @Original_MotelCostCad)) AND ([TotalCostCad] = @Original_TotalCostCad) AND (" +
                "[LHCostUsd] = @Original_LHCostUsd) AND ((@IsNull_MealsCostUsd = 1 AND [MealsCost" +
                "Usd] IS NULL) OR ([MealsCostUsd] = @Original_MealsCostUsd)) AND ((@IsNull_MotelC" +
                "ostUsd = 1 AND [MotelCostUsd] IS NULL) OR ([MotelCostUsd] = @Original_MotelCostU" +
                "sd)) AND ([TotalCostUsd] = @Original_TotalCostUsd) AND ([Deleted] = @Original_De" +
                "leted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_StartDate = 1 AND" +
                " [StartDate] IS NULL) OR ([StartDate] = @Original_StartDate)) AND ((@IsNull_EndD" +
                "ate = 1 AND [EndDate] IS NULL) OR ([EndDate] = @Original_EndDate)) AND ((@IsNull" +
                "_Function_ = 1 AND [Function_] IS NULL) OR ([Function_] = @Original_Function_)))" +
                ";\r\nSELECT CostingSheetID, Work_, EmployeeID, RefID, LHQuantity, LHUnitOfMeasurem" +
                "ent, MealsUnitOfMeasurement, MealsQuantity, MotelUnitOfMeasurement, MotelQuantit" +
                "y, LHCostCad, MealsCostCad, MotelCostCad, TotalCostCad, LHCostUsd, MealsCostUsd," +
                " MotelCostUsd, TotalCostUsd, Deleted, COMPANY_ID, StartDate, EndDate, Function_ " +
                "FROM LFS_PROJECT_COMBINED_COSTING_SHEET_LABOUR_HOURS WHERE (CostingSheetID = @CostingShee" +
                "tID) AND (EmployeeID = @EmployeeID) AND (RefID = @RefID) AND (Work_ = @Work_)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostingSheetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostingSheetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LHQuantity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LHQuantity", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LHUnitOfMeasurement", global::System.Data.SqlDbType.NChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LHUnitOfMeasurement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsUnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsUnitOfMeasurement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsQuantity", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsQuantity", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MotelUnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelUnitOfMeasurement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MotelQuantity", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelQuantity", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LHCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LHCostCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCostCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MotelCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelCostCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LHCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LHCostUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCostUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MotelCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelCostUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostingSheetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostingSheetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LHQuantity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LHQuantity", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LHUnitOfMeasurement", global::System.Data.SqlDbType.NChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LHUnitOfMeasurement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MealsUnitOfMeasurement", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsUnitOfMeasurement", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MealsUnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsUnitOfMeasurement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MealsQuantity", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsQuantity", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MealsQuantity", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsQuantity", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MotelUnitOfMeasurement", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelUnitOfMeasurement", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MotelUnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelUnitOfMeasurement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MotelQuantity", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelQuantity", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MotelQuantity", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelQuantity", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LHCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LHCostCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MealsCostCad", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCostCad", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MealsCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCostCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MotelCostCad", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelCostCad", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MotelCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelCostCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LHCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LHCostUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MealsCostUsd", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCostUsd", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MealsCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCostUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MotelCostUsd", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelCostUsd", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MotelCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MotelCostUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_EndDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Function_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <param name="lHQuantity">lHQuantity</param>
        /// <param name="lHUnitOfMeasurement">lHUnitOfMeasurement</param>
        /// <param name="mealsUnitOfMeasurement">mealsUnitOfMeasurement</param>
        /// <param name="mealsQuantity">mealsQuantity</param>
        /// <param name="motelUnitOfMeasurement">motelUnitOfMeasurement</param>
        /// <param name="motelQuantity">motelQuantity</param>
        /// <param name="lHCostCad">lHCostCad</param>
        /// <param name="mealsCostCad">mealsCostCad</param>
        /// <param name="motelCostCad">motelCostCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="lHCostUsd">lHCostUsd</param>
        /// <param name="mealsCostUsd">mealsCostUsd</param>
        /// <param name="motelCostUsd">motelCostUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="function">function_</param>
        public void Insert(int costingSheetId, string work_, int employeeId, int refId, double lHQuantity, string lHUnitOfMeasurement, string mealsUnitOfMeasurement, int? mealsQuantity, string motelUnitOfMeasurement, int? motelQuantity, decimal lHCostCad, decimal? mealsCostCad, decimal? motelCostCad, decimal totalCostCad, decimal lHCostUsd, decimal? mealsCostUsd, decimal? motelCostUsd, decimal totalCostUsd, bool deleted, int companyId, DateTime startDate, DateTime endDate, string function_, int projectId)
        {
            SqlParameter costingSheetIdParameter = new SqlParameter("CostingSheetID", costingSheetId);
            SqlParameter work_Parameter = new SqlParameter("Work_", work_);
            SqlParameter employeeIdParameter = new SqlParameter("EmployeeID", employeeId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter lHQuantityParameter = new SqlParameter("LHQuantity", lHQuantity);
            SqlParameter lHUnitOfMeasurementParameter = new SqlParameter("LHUnitOfMeasurement", lHUnitOfMeasurement);
            SqlParameter mealsUnitOfMeasurementParameter = (mealsUnitOfMeasurement != "") ? new SqlParameter("MealsUnitOfMeasurement", mealsUnitOfMeasurement) : new SqlParameter("MealsUnitOfMeasurement", DBNull.Value);
            SqlParameter mealsQuantityParameter = (mealsQuantity.HasValue) ? new SqlParameter("MealsQuantity", mealsQuantity) : new SqlParameter("MealsQuantity", DBNull.Value);
            SqlParameter motelUnitOfMeasurementParameter = (motelUnitOfMeasurement != "") ? new SqlParameter("MotelUnitOfMeasurement", motelUnitOfMeasurement) : new SqlParameter("MotelUnitOfMeasurement", DBNull.Value);
            SqlParameter motelQuantityParameter = (motelQuantity.HasValue) ? new SqlParameter("MotelQuantity", motelQuantity) : new SqlParameter("MotelQuantity", DBNull.Value);
            SqlParameter lHCostCadParameter = new SqlParameter("LHCostCad", lHCostCad); lHCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter mealsCostCadParameter = (mealsCostCad.HasValue) ? new SqlParameter("MealsCostCad", mealsCostCad) : new SqlParameter("MealsCostCad", DBNull.Value); mealsCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter motelCostCadParameter = (motelCostCad.HasValue) ? new SqlParameter("MotelCostCad", motelCostCad) : new SqlParameter("MotelCostCad", DBNull.Value); motelCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter totalCostCadParameter = new SqlParameter("TotalCostCad", totalCostCad); totalCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter lHCostUsdParameter = new SqlParameter("LHCostUsd", lHCostUsd); lHCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter mealsCostUsdParameter = (mealsCostUsd.HasValue) ? new SqlParameter("MealsCostUsd", mealsCostUsd) : new SqlParameter("MealsCostUsd", DBNull.Value); mealsCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter motelCostUsdParameter = (motelCostUsd.HasValue) ? new SqlParameter("MotelCostUsd", motelCostUsd) : new SqlParameter("MotelCostUsd", DBNull.Value); motelCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter totalCostUsdParameter = new SqlParameter("TotalCostUsd", totalCostUsd); totalCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter startDateParameter = new SqlParameter("StartDate", startDate);
            SqlParameter endDateParameter = new SqlParameter("EndDate", endDate);
            SqlParameter function_Parameter = (function_ != "") ? new SqlParameter("Function_", function_) : new SqlParameter("Function_", DBNull.Value);
            SqlParameter projectIdParameter = new SqlParameter("ProjectID", projectId);            

            string command = "INSERT INTO [dbo].[LFS_PROJECT_COMBINED_COSTING_SHEET_LABOUR_HOURS] ([CostingSheetID], [Work_], [EmployeeID], [RefID], [LHQuantity], [LHUnitOfMeasurement], [MealsUnitOfMeasurement], " +
                            " [MealsQuantity], [MotelUnitOfMeasurement], [MotelQuantity], [LHCostCad], [MealsCostCad], [MotelCostCad], [TotalCostCad], [LHCostUsd], [MealsCostUsd], " +
                            " [MotelCostUsd], [TotalCostUsd], [Deleted], [COMPANY_ID], [StartDate], [EndDate], [Function_], [ProjectID]) " +
                             " VALUES (@CostingSheetID, @Work_, @EmployeeID, @RefID, @LHQuantity, @LHUnitOfMeasurement, @MealsUnitOfMeasurement, @MealsQuantity, @MotelUnitOfMeasurement, @MotelQuantity, "+
                             " @LHCostCad, @MealsCostCad, @MotelCostCad, @TotalCostCad, @LHCostUsd, @MealsCostUsd, @MotelCostUsd, @TotalCostUsd, @Deleted, @COMPANY_ID, @StartDate, @EndDate, @Function_, @ProjectID)";
            
            ExecuteScalar(command, costingSheetIdParameter, work_Parameter, employeeIdParameter, refIdParameter, lHQuantityParameter, lHUnitOfMeasurementParameter, mealsUnitOfMeasurementParameter, mealsQuantityParameter, motelUnitOfMeasurementParameter, motelQuantityParameter, lHCostCadParameter, mealsCostCadParameter, motelCostCadParameter, totalCostCadParameter, lHCostUsdParameter, mealsCostUsdParameter, motelCostUsdParameter, totalCostUsdParameter, deletedParameter, companyIdParameter, startDateParameter, endDateParameter, function_Parameter, projectIdParameter);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <param name="originalWork_">originalWork_</param>
        /// <param name="originalLHQuantity">originalLHQuantity</param>
        /// <param name="originalLHUnitOfMeasurement">originalLHUnitOfMeasurement</param>
        /// <param name="originalMealsUnitOfMeasurement">originalMealsUnitOfMeasurement</param>
        /// <param name="originalMealsQuantity">originalMealsQuantity</param>
        /// <param name="originalMotelUnitOfMeasurement">originalMotelUnitOfMeasurement</param>
        /// <param name="originalMotelQuantity">originalMotelQuantity</param>
        /// <param name="originalLHCostCad">originalLHCostCad</param>
        /// <param name="originalMealsCostCad">originalMealsCostCad</param>
        /// <param name="originalMotelCostCad">originalMotelCostCad</param>
        /// <param name="originalTotalCostCad">originalTotalCostCad</param>
        /// <param name="originalLHCostUsd">originalLHCostUsd</param>
        /// <param name="originalMealsCostUsd">originalMealsCostUsd</param>
        /// <param name="originalMotelCostUsd">originalMotelCostUsd</param>
        /// <param name="originalTotalCostUsd">originalTotalCostUsd</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalStartDate">originalStartDate</param>
        /// <param name="originalEndDate">originalEndDate</param>
        /// <param name="originalFunction_">originalFunction_</param>
        /// 
        /// <param name="newWork_">newWork_</param>
        /// <param name="newLHQuantity">newLHQuantity</param>
        /// <param name="newLHUnitOfMeasurement">newLHUnitOfMeasurement</param>
        /// <param name="newMealsUnitOfMeasurement">newMealsUnitOfMeasurement</param>
        /// <param name="newMealsQuantity">newMealsQuantity</param>
        /// <param name="newMotelUnitOfMeasurement">newMotelUnitOfMeasurement</param>
        /// <param name="newMotelQuantity">newMotelQuantity</param>
        /// <param name="newLHCostCad">newLHCostCad</param>
        /// <param name="newMealsCostCad">newMealsCostCad</param>
        /// <param name="newMotelCostCad">newMotelCostCad</param>
        /// <param name="newTotalCostCad">newTotalCostCad</param>
        /// <param name="newLHCostUsd">newLHCostUsd</param>
        /// <param name="newMealsCostUsd">newMealsCostUsd</param>
        /// <param name="newMotelCostUsd">newMotelCostUsd</param>
        /// <param name="newTotalCostUsd">newTotalCostUsd</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newStartDate">newStartDate</param>
        /// <param name="newEndDate">newEndDate</param>
        /// <param name="newFunction_">newFunction_</param>
        public void Update(int costingSheetId, int employeeId, int refId, string originalWork_, double originalLHQuantity, string originalLHUnitOfMeasurement, string originalMealsUnitOfMeasurement, int? originalMealsQuantity, string originalMotelUnitOfMeasurement, int? originalMotelQuantity, decimal originalLHCostCad, decimal? originalMealsCostCad, decimal? originalMotelCostCad, decimal originalTotalCostCad, decimal originalLHCostUsd, decimal? originalMealsCostUsd, decimal? originalMotelCostUsd, decimal originalTotalCostUsd, bool originalDeleted, int originalCompanyId, DateTime originalStartDate, DateTime originalEndDate, string originalFunction_, string newWork_, double newLHQuantity, string newLHUnitOfMeasurement, string newMealsUnitOfMeasurement, int? newMealsQuantity, string newMotelUnitOfMeasurement, int? newMotelQuantity, decimal newLHCostCad, decimal? newMealsCostCad, decimal? newMotelCostCad, decimal newTotalCostCad, decimal newLHCostUsd, decimal? newMealsCostUsd, decimal? newMotelCostUsd, decimal newTotalCostUsd, bool newDeleted, int newCompanyId, DateTime newStartDate, DateTime newEndDate, string newFunction_, int originalProjectId, int newProjectId)
        {
            SqlParameter originalCostingSheetIdParameter = new SqlParameter("Original_CostingSheetID", costingSheetId);
            SqlParameter originalWork_Parameter = new SqlParameter("Original_Work_", originalWork_);
            SqlParameter originalEmployeeIdParameter = new SqlParameter("Original_EmployeeID", employeeId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", refId);
            SqlParameter originalLHQuantityParameter = new SqlParameter("Original_LHQuantity", originalLHQuantity);
            SqlParameter originalLHUnitOfMeasurementParameter = new SqlParameter("Original_LHUnitOfMeasurement", originalLHUnitOfMeasurement);
            SqlParameter originalMealsUnitOfMeasurementParameter = (originalMealsUnitOfMeasurement.Trim() != "") ? new SqlParameter("Original_MealsUnitOfMeasurement", originalMealsUnitOfMeasurement) : new SqlParameter("Original_MealsUnitOfMeasurement", DBNull.Value);
            SqlParameter originalMealsQuantityParameter = (originalMealsQuantity.HasValue) ? new SqlParameter("Original_MealsQuantity", originalMealsQuantity) : new SqlParameter("Original_MealsQuantity", DBNull.Value);
            SqlParameter originalMotelUnitOfMeasurementParameter = (originalMotelUnitOfMeasurement.Trim() != "") ? new SqlParameter("Original_MotelUnitOfMeasurement", originalMotelUnitOfMeasurement) : new SqlParameter("Original_MotelUnitOfMeasurement", DBNull.Value);
            SqlParameter originalMotelQuantityParameter = (originalMotelQuantity.HasValue) ? new SqlParameter("Original_MotelQuantity", originalMotelQuantity) : new SqlParameter("Original_MotelQuantity", DBNull.Value);
            SqlParameter originalLHCostCadParameter = new SqlParameter("Original_LHCostCad", originalLHCostCad); originalLHCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalMealsCostCadParameter = (originalMealsCostCad.HasValue) ? new SqlParameter("Original_MealsCostCad", originalMealsCostCad) : new SqlParameter("Original_MealsCostCad", DBNull.Value); originalMealsCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalMotelCostCadParameter = (originalMotelCostCad.HasValue) ? new SqlParameter("Original_MotelCostCad", originalMotelCostCad) : new SqlParameter("Original_MotelCostCad", DBNull.Value); originalMotelCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalTotalCostCadParameter = new SqlParameter("Original_TotalCostCad", originalTotalCostCad); originalTotalCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalLHCostUsdParameter = new SqlParameter("Original_LHCostUsd", originalLHCostUsd); originalLHCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalMealsCostUsdParameter = (originalMealsCostUsd.HasValue) ? new SqlParameter("Original_MealsCostUsd", originalMealsCostUsd) : new SqlParameter("Original_MealsCostUsd", DBNull.Value); originalMealsCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalMotelCostUsdParameter = (originalMotelCostUsd.HasValue) ? new SqlParameter("Original_MotelCostUsd", originalMotelCostUsd) : new SqlParameter("Original_MotelCostUsd", DBNull.Value); originalMotelCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalTotalCostUsdParameter = new SqlParameter("Original_TotalCostUsd", originalTotalCostUsd); originalTotalCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalStartDateParameter = new SqlParameter("Original_StartDate", originalStartDate);
            SqlParameter originalEndDateParameter = new SqlParameter("Original_EndDate", originalEndDate);
            SqlParameter originalFunction_Parameter = (originalFunction_ != "") ? new SqlParameter("Original_Function_", originalFunction_) : new SqlParameter("Original_Function_", DBNull.Value);
            SqlParameter originalProjectIdParameter = new SqlParameter("Original_ProjectID", originalProjectId);

            SqlParameter newCostingSheetIdParameter = new SqlParameter("CostingSheetID", costingSheetId);
            SqlParameter newWork_Parameter = new SqlParameter("Work_", originalWork_);
            SqlParameter newEmployeeIdParameter = new SqlParameter("EmployeeID", employeeId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", refId);
            SqlParameter newLHQuantityParameter = new SqlParameter("LHQuantity", newLHQuantity);
            SqlParameter newLHUnitOfMeasurementParameter = new SqlParameter("LHUnitOfMeasurement", newLHUnitOfMeasurement);
            SqlParameter newMealsUnitOfMeasurementParameter = (newMealsUnitOfMeasurement.Trim() != "") ? new SqlParameter("MealsUnitOfMeasurement", newMealsUnitOfMeasurement) : new SqlParameter("MealsUnitOfMeasurement", DBNull.Value);
            SqlParameter newMealsQuantityParameter = (newMealsQuantity.HasValue) ? new SqlParameter("MealsQuantity", newMealsQuantity) : new SqlParameter("MealsQuantity", DBNull.Value);
            SqlParameter newMotelUnitOfMeasurementParameter = (newMotelUnitOfMeasurement.Trim() != "") ? new SqlParameter("MotelUnitOfMeasurement", newMotelUnitOfMeasurement) : new SqlParameter("MotelUnitOfMeasurement", DBNull.Value);
            SqlParameter newMotelQuantityParameter = (newMotelQuantity.HasValue) ? new SqlParameter("MotelQuantity", newMotelQuantity) : new SqlParameter("MotelQuantity", DBNull.Value);
            SqlParameter newLHCostCadParameter = new SqlParameter("LHCostCad", newLHCostCad); newLHCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newMealsCostCadParameter = (newMealsCostCad.HasValue) ? new SqlParameter("MealsCostCad", newMealsCostCad) : new SqlParameter("MealsCostCad", DBNull.Value); newMealsCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newMotelCostCadParameter = (newMotelCostCad.HasValue) ? new SqlParameter("MotelCostCad", newMotelCostCad) : new SqlParameter("MotelCostCad", DBNull.Value); newMotelCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newTotalCostCadParameter = new SqlParameter("TotalCostCad", newTotalCostCad); newTotalCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newLHCostUsdParameter = new SqlParameter("LHCostUsd", newLHCostUsd); newLHCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newMealsCostUsdParameter = (newMealsCostUsd.HasValue) ? new SqlParameter("MealsCostUsd", newMealsCostUsd) : new SqlParameter("MealsCostUsd", DBNull.Value); newMealsCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newMotelCostUsdParameter = (newMotelCostUsd.HasValue) ? new SqlParameter("MotelCostUsd", newMotelCostUsd) : new SqlParameter("MotelCostUsd", DBNull.Value); newMotelCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newTotalCostUsdParameter = new SqlParameter("TotalCostUsd", newTotalCostUsd); newTotalCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newStartDateParameter = new SqlParameter("StartDate", newStartDate);
            SqlParameter newEndDateParameter = new SqlParameter("EndDate", newEndDate);
            SqlParameter newFunction_Parameter = (newFunction_ != "") ? new SqlParameter("Function_", newFunction_) : new SqlParameter("Function_", DBNull.Value);
            SqlParameter newProjectIdParameter = new SqlParameter("ProjectID", newProjectId);

            string command = "UPDATE [dbo].[LFS_PROJECT_COMBINED_COSTING_SHEET_LABOUR_HOURS] SET [CostingSheetID] = @CostingSheetID, [Work_] = @Work_, [EmployeeID] = @EmployeeID, [RefID] = @RefID, "+
                             " [LHQuantity] = @LHQuantity, [LHUnitOfMeasurement] = @LHUnitOfMeasurement, [MealsUnitOfMeasurement] = @MealsUnitOfMeasurement, [MealsQuantity] = @MealsQuantity, "+
                             " [MotelUnitOfMeasurement] = @MotelUnitOfMeasurement, [MotelQuantity] = @MotelQuantity, [LHCostCad] = @LHCostCad, [MealsCostCad] = @MealsCostCad, "+
                             " [MotelCostCad] = @MotelCostCad, [TotalCostCad] = @TotalCostCad, [LHCostUsd] = @LHCostUsd, [MealsCostUsd] = @MealsCostUsd, [MotelCostUsd] = @MotelCostUsd, "+
                             " [TotalCostUsd] = @TotalCostUsd, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [StartDate] = @StartDate, [EndDate] = @EndDate, [Function_] = @Function_, [ProjectID] = @ProjectID " +
                " WHERE (" +
                " ([CostingSheetID] = @Original_CostingSheetID) AND ([Work_] = @Original_Work_) AND ([EmployeeID] = @Original_EmployeeID) AND ([RefID] = @Original_RefID) AND ([COMPANY_ID] = @Original_COMPANY_ID)" +
                " )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCostingSheetIdParameter, originalWork_Parameter, originalEmployeeIdParameter, originalRefIdParameter, originalLHQuantityParameter, originalLHUnitOfMeasurementParameter, originalMealsUnitOfMeasurementParameter, originalMealsQuantityParameter, originalMotelUnitOfMeasurementParameter, originalMotelQuantityParameter, originalLHCostCadParameter, originalMealsCostCadParameter, originalMotelCostCadParameter, originalTotalCostCadParameter, originalLHCostUsdParameter, originalMealsCostUsdParameter, originalMotelCostUsdParameter, originalTotalCostUsdParameter, originalDeletedParameter, originalCompanyIdParameter, originalStartDateParameter, originalEndDateParameter, originalFunction_Parameter, newCostingSheetIdParameter, newWork_Parameter, newEmployeeIdParameter, newRefIdParameter, newLHQuantityParameter, newLHUnitOfMeasurementParameter, newMealsUnitOfMeasurementParameter, newMealsQuantityParameter, newMotelUnitOfMeasurementParameter, newMotelQuantityParameter, newLHCostCadParameter, newMealsCostCadParameter, newMotelCostCadParameter, newTotalCostCadParameter, newLHCostUsdParameter, newMealsCostUsdParameter, newMotelCostUsdParameter, newTotalCostUsdParameter, newDeletedParameter, newCompanyIdParameter, newStartDateParameter, newEndDateParameter, newFunction_Parameter, originalProjectIdParameter, newProjectIdParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// Delete all LH Costing Sheet
        /// </summary>
        /// <param name="originalcostingSheetId">originalcostingSheetId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int DeleteAll(int originalCostingSheetId, int originalCompanyId)
        {
            SqlParameter originalCostingSheetIdParameter = new SqlParameter("Original_CostingSheetID", originalCostingSheetId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_PROJECT_COMBINED_COSTING_SHEET_LABOUR_HOURS] SET  [Deleted] = @Deleted  " +
                             " WHERE (([CostingSheetID] = @Original_CostingSheetID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCostingSheetIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete a LH Costing Sheet
        /// </summary>
        /// <param name="originalCostingSheetId">originalCostingSheetId</param>
        /// <param name="originalWork_">originalWork_</param>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalCostingSheetId, string originalWork_, int originalEmployeeId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalCostingSheetIdParameter = new SqlParameter("Original_CostingSheetID", originalCostingSheetId);
            SqlParameter originalWork_Parameter = new SqlParameter("Original_Work_", originalWork_);
            SqlParameter originalEmployeeIdParameter = new SqlParameter("Original_EmployeeID", originalEmployeeId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_PROJECT_COMBINED_COSTING_SHEET_LABOUR_HOURS] SET  [Deleted] = @Deleted " +
                             " WHERE (([CostingSheetID] = @Original_CostingSheetID) AND ([Work_] = @Original_Work_) AND ([EmployeeID] = @Original_EmployeeID) AND ([RefID] = @Original_RefID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCostingSheetIdParameter, originalWork_Parameter, originalEmployeeIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}