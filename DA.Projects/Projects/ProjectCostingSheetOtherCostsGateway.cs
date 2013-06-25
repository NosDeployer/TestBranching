using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetOtherCostsGateway
    /// </summary>
    public class ProjectCostingSheetOtherCostsGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetOtherCostsGateway()
            : base("LFS_PROJECT_COSTING_SHEET_OTHER_COSTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetOtherCostsGateway(DataSet data)
            : base(data, "LFS_PROJECT_COSTING_SHEET_OTHER_COSTS")
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
            tableMapping.DataSetTable = "LFS_PROJECT_COSTING_SHEET_OTHER_COSTS";
            tableMapping.ColumnMappings.Add("CostingSheetID", "CostingSheetID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Work_", "Work_");
            tableMapping.ColumnMappings.Add("Function_", "Function_");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("UnitOfMeasurement", "UnitOfMeasurement");
            tableMapping.ColumnMappings.Add("Quantity", "Quantity");
            tableMapping.ColumnMappings.Add("CostCad", "CostCad");
            tableMapping.ColumnMappings.Add("TotalCostCad", "TotalCostCad");
            tableMapping.ColumnMappings.Add("CostUsd", "CostUsd");
            tableMapping.ColumnMappings.Add("TotalCostUsd", "TotalCostUsd");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_PROJECT_COSTING_SHEET_OTHER_COSTS] WHERE (([CostingSheetID] = @Original_CostingSheetID) AND ([RefID] = @Original_RefID) AND ((@IsNull_Work_ = 1 AND [Work_] IS NULL) OR ([Work_] = @Original_Work_)) AND ((@IsNull_Function_ = 1 AND [Function_] IS NULL) OR ([Function_] = @Original_Function_)) AND ([Description] = @Original_Description) AND ([UnitOfMeasurement] = @Original_UnitOfMeasurement) AND ([Quantity] = @Original_Quantity) AND ([CostCad] = @Original_CostCad) AND ([TotalCostCad] = @Original_TotalCostCad) AND ([CostUsd] = @Original_CostUsd) AND ([TotalCostUsd] = @Original_TotalCostUsd) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_StartDate = 1 AND [StartDate] IS NULL) OR ([StartDate] = @Original_StartDate)) AND ((@IsNull_EndDate = 1 AND [EndDate] IS NULL) OR ([EndDate] = @Original_EndDate)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostingSheetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostingSheetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Work_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Function_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Quantity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Quantity", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_EndDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT_COSTING_SHEET_OTHER_COSTS] ([CostingSheetID], [RefID], [Work_], [Function_], [Description], [UnitOfMeasurement], [Quantity], [CostCad], [TotalCostCad], [CostUsd], [TotalCostUsd], [Deleted], [COMPANY_ID], [StartDate], [EndDate]) VALUES (@CostingSheetID, @RefID, @Work_, @Function_, @Description, @UnitOfMeasurement, @Quantity, @CostCad, @TotalCostCad, @CostUsd, @TotalCostUsd, @Deleted, @COMPANY_ID, @StartDate, @EndDate);
SELECT CostingSheetID, RefID, Work_, Function_, Description, UnitOfMeasurement, Quantity, CostCad, TotalCostCad, CostUsd, TotalCostUsd, Deleted, COMPANY_ID, StartDate, EndDate FROM LFS_PROJECT_COSTING_SHEET_OTHER_COSTS WHERE (CostingSheetID = @CostingSheetID) AND (RefID = @RefID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostingSheetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostingSheetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Quantity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Quantity", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_PROJECT_COSTING_SHEET_OTHER_COSTS] SET [CostingSheetID] = @Cost" +
                "ingSheetID, [RefID] = @RefID, [Work_] = @Work_, [Function_] = @Function_, [Descr" +
                "iption] = @Description, [UnitOfMeasurement] = @UnitOfMeasurement, [Quantity] = @" +
                "Quantity, [CostCad] = @CostCad, [TotalCostCad] = @TotalCostCad, [CostUsd] = @Cos" +
                "tUsd, [TotalCostUsd] = @TotalCostUsd, [Deleted] = @Deleted, [COMPANY_ID] = @COMP" +
                "ANY_ID, [StartDate] = @StartDate, [EndDate] = @EndDate WHERE (([CostingSheetID] " +
                "= @Original_CostingSheetID) AND ([RefID] = @Original_RefID) AND ((@IsNull_Work_ " +
                "= 1 AND [Work_] IS NULL) OR ([Work_] = @Original_Work_)) AND ((@IsNull_Function_" +
                " = 1 AND [Function_] IS NULL) OR ([Function_] = @Original_Function_)) AND ([Desc" +
                "ription] = @Original_Description) AND ([UnitOfMeasurement] = @Original_UnitOfMea" +
                "surement) AND ([Quantity] = @Original_Quantity) AND ([CostCad] = @Original_CostC" +
                "ad) AND ([TotalCostCad] = @Original_TotalCostCad) AND ([CostUsd] = @Original_Cos" +
                "tUsd) AND ([TotalCostUsd] = @Original_TotalCostUsd) AND ([Deleted] = @Original_D" +
                "eleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_StartDate = 1 AN" +
                "D [StartDate] IS NULL) OR ([StartDate] = @Original_StartDate)) AND ((@IsNull_End" +
                "Date = 1 AND [EndDate] IS NULL) OR ([EndDate] = @Original_EndDate)));\r\nSELECT Co" +
                "stingSheetID, RefID, Work_, Function_, Description, UnitOfMeasurement, Quantity," +
                " CostCad, TotalCostCad, CostUsd, TotalCostUsd, Deleted, COMPANY_ID, StartDate, E" +
                "ndDate FROM LFS_PROJECT_COSTING_SHEET_OTHER_COSTS WHERE (CostingSheetID = @Costi" +
                "ngSheetID) AND (RefID = @RefID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostingSheetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostingSheetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Quantity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Quantity", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostingSheetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostingSheetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Work_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Function_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Quantity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Quantity", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalCostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalCostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalCostUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_EndDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="description">description</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalUsd">totalUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        public void Insert(int costingSheetId, int refId, string work_, string function_, string description, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, DateTime startDate, DateTime endDate)
        {
            SqlParameter costingSheetIdParameter = new SqlParameter("CostingSheetID", costingSheetId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter work_Parameter = (work_ != "") ? new SqlParameter("Work_", work_) : new SqlParameter("Work_", DBNull.Value);
            SqlParameter function_Parameter = (function_ != "") ? new SqlParameter("Function_", function_) : new SqlParameter("Function_", DBNull.Value);
            SqlParameter descriptionParameter = new SqlParameter("Description", description);
            SqlParameter unitOfMeasurementParameter = new SqlParameter("UnitOfMeasurement", unitOfMeasurement);
            SqlParameter quantityParameter = new SqlParameter("Quantity", quantity);
            SqlParameter costCadParameter = new SqlParameter("CostCad", costCad); costCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter totalCostCadParameter = new SqlParameter("TotalCostCad", totalCostCad); totalCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter costUsdParameter = new SqlParameter("CostUsd", costUsd); costUsdParameter.SqlDbType = SqlDbType.Money;            
            SqlParameter totalCostUsdParameter = new SqlParameter("TotalCostUsd", totalCostUsd); totalCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter startDateParameter = new SqlParameter("StartDate", startDate);
            SqlParameter endDateParameter = new SqlParameter("EndDate", endDate);

            string command = "INSERT INTO [dbo].[LFS_PROJECT_COSTING_SHEET_OTHER_COSTS] ([CostingSheetID], [RefID], [Work_], [Function_], [Description], [UnitOfMeasurement], "+
                             " [Quantity], [CostCad], [TotalCostCad], [CostUsd], [TotalCostUsd], [Deleted], [COMPANY_ID], [StartDate], [EndDate]) "+
                             " VALUES (@CostingSheetID, @RefID, @Work_, @Function_, @Description, @UnitOfMeasurement, @Quantity, @CostCad, @TotalCostCad, @CostUsd, @TotalCostUsd, @Deleted, @COMPANY_ID, @StartDate, @EndDate)";
            
            ExecuteScalar(command, costingSheetIdParameter, refIdParameter, work_Parameter, function_Parameter, descriptionParameter, unitOfMeasurementParameter, quantityParameter, costCadParameter, totalCostCadParameter, costUsdParameter, totalCostUsdParameter, deletedParameter, companyIdParameter, startDateParameter, endDateParameter);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <param name="originalWork_">originalWork_</param>
        /// <param name="originalFunction_">originalFunction_</param>
        /// <param name="originalDescription">originalDescription</param>
        /// <param name="originalUnitOfMeasurement">originalUnitOfMeasurement</param>
        /// <param name="originalQuantity">originalQuantity</param>
        /// <param name="originalCostCad">originalCostCad</param>
        /// <param name="originalTotalCostCad">originalTotalCostCad</param>
        /// <param name="originalCostUsd">originalCostUsd</param>
        /// <param name="originalTotalCostUsd">originalTotalCostUsd</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalStartDate">originalStartDate</param>
        /// <param name="originalEndDate">originalEndDate</param>
        /// 
        /// <param name="newWork_">newWork_</param>
        /// <param name="newFunction_">newFunction_</param>
        /// <param name="newDescription">newDescription</param>
        /// <param name="newUnitOfMeasurement">newUnitOfMeasurement</param>
        /// <param name="newQuantity">newQuantity</param>
        /// <param name="newCostCad">newCostCad</param>
        /// <param name="newTotalCostCad">newTotalCostCad</param>
        /// <param name="newCostUsd">newCostUsd</param>
        /// <param name="newTotalCostUsd">newTotalCostUsd</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newStartDate">newStartDate</param>
        /// <param name="newEndDate">newEndDate</param>
        public void Update(int costingSheetId, int refId, string originalWork_, string originalFunction_, string originalDescription, string originalUnitOfMeasurement, double originalQuantity, decimal originalCostCad, decimal originalTotalCostCad, decimal originalCostUsd, decimal originalTotalCostUsd, bool originalDeleted, int originalCompanyId, DateTime originalStartDate, DateTime originalEndDate, string newWork_, string newFunction_, string newDescription, string newUnitOfMeasurement, double newQuantity, decimal newCostCad, decimal newTotalCostCad, decimal newCostUsd, decimal newTotalCostUsd, bool newDeleted, int newCompanyId, DateTime newStartDate, DateTime newEndDate)
        {
            SqlParameter originalCostingSheetIdParameter = new SqlParameter("Original_CostingSheetID", costingSheetId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", refId);
            SqlParameter originalWork_Parameter = (originalWork_.Trim() != "") ? new SqlParameter("Original_Work_", originalWork_.Trim()) : new SqlParameter("Original_Work_", DBNull.Value);
            SqlParameter originalFunction_Parameter = (originalFunction_.Trim() != "") ? new SqlParameter("Original_Function_", originalFunction_.Trim()) : new SqlParameter("Original_Function_", DBNull.Value);
            SqlParameter originalDescriptionParameter = new SqlParameter("Original_Description", originalDescription);
            SqlParameter originalUnitOfMeasurementParameter = new SqlParameter("Original_UnitOfMeasurement", originalUnitOfMeasurement);
            SqlParameter originalQuantityParameter = new SqlParameter("Original_Quantity", originalQuantity);
            SqlParameter originalCostCadParameter = new SqlParameter("Original_CostCad", originalCostCad); originalCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalTotalCostCadParameter = new SqlParameter("Original_TotalCostCad", originalTotalCostCad); originalTotalCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalCostUsdParameter = new SqlParameter("Original_CostUsd", originalCostUsd); originalCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalTotalCostUsdParameter = new SqlParameter("Original_TotalCostUsd", originalTotalCostUsd); originalTotalCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalStartDateParameter = new SqlParameter("Original_StartDate", originalStartDate);
            SqlParameter originalEndDateParameter = new SqlParameter("Original_EndDate", originalEndDate);

            SqlParameter newCostingSheetIdParameter = new SqlParameter("CostingSheetID", costingSheetId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", refId);
            SqlParameter newWork_Parameter = (newWork_.Trim() != "") ? new SqlParameter("Work_", newWork_.Trim()) : new SqlParameter("Work_", DBNull.Value);
            SqlParameter newFunction_Parameter = (newFunction_.Trim() != "") ? new SqlParameter("Function_", newFunction_.Trim()) : new SqlParameter("Function_", DBNull.Value);
            SqlParameter newDescriptionParameter = new SqlParameter("Description", newDescription);
            SqlParameter newUnitOfMeasurementParameter = new SqlParameter("UnitOfMeasurement", newUnitOfMeasurement);
            SqlParameter newQuantityParameter = new SqlParameter("Quantity", newQuantity);
            SqlParameter newCostCadParameter = new SqlParameter("CostCad", newCostCad); newCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newTotalCostCadParameter = new SqlParameter("TotalCostCad", newTotalCostCad); newTotalCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newCostUsdParameter = new SqlParameter("CostUsd", newCostUsd); newCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newTotalCostUsdParameter = new SqlParameter("TotalCostUsd", newTotalCostUsd); newTotalCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newStartDateParameter = new SqlParameter("StartDate", newStartDate);
            SqlParameter newEndDateParameter = new SqlParameter("EndDate", newEndDate);

            string command = "UPDATE [dbo].[LFS_PROJECT_COSTING_SHEET_OTHER_COSTS] SET [CostingSheetID] = @CostingSheetID, [RefID] = @RefID, [Work_] = @Work_, [Function_] = @Function_, "+
                             " [Description] = @Description, [UnitOfMeasurement] = @UnitOfMeasurement, [Quantity] = @Quantity, [CostCad] = @CostCad, [TotalCostCad] = @TotalCostCad, "+
                             " [CostUsd] = @CostUsd, [TotalCostUsd] = @TotalCostUsd, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [StartDate] = @StartDate, [EndDate] = @EndDate " +
                " WHERE (" +
                " ([CostingSheetID] = @Original_CostingSheetID) AND ([RefID] = @Original_RefID) AND ([COMPANY_ID] = @Original_COMPANY_ID)" +
                " )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCostingSheetIdParameter, originalRefIdParameter, originalWork_Parameter, originalFunction_Parameter, originalDescriptionParameter, originalUnitOfMeasurementParameter, originalQuantityParameter, originalCostCadParameter, originalTotalCostCadParameter, originalCostUsdParameter, originalTotalCostUsdParameter, originalDeletedParameter, originalCompanyIdParameter, originalStartDateParameter, originalEndDateParameter, newCostingSheetIdParameter, newRefIdParameter, newWork_Parameter, newFunction_Parameter, newDescriptionParameter, newUnitOfMeasurementParameter, newQuantityParameter, newCostCadParameter, newTotalCostCadParameter, newCostUsdParameter, newTotalCostUsdParameter, newDeletedParameter, newCompanyIdParameter, newStartDateParameter, newEndDateParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// Delete all Other Costs Costing Sheets
        /// </summary>
        /// <param name="originalcostingSheetId">originalcostingSheetId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int DeleteAll(int originalCostingSheetId, int originalCompanyId)
        {
            SqlParameter originalCostingSheetIdParameter = new SqlParameter("Original_CostingSheetID", originalCostingSheetId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_PROJECT_COSTING_SHEET_OTHER_COSTS] SET  [Deleted] = @Deleted  " +
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
        /// Delete a Other Costs Costing Sheet (direct to DB)
        /// </summary>
        /// <param name="originalcostingSheetId">originalcostingSheetId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalCostingSheetId,int originalRefId, int originalCompanyId)
        {
            SqlParameter originalCostingSheetIdParameter = new SqlParameter("Original_CostingSheetID", originalCostingSheetId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_PROJECT_COSTING_SHEET_OTHER_COSTS] SET  [Deleted] = @Deleted  " +
                             " WHERE (([CostingSheetID] = @Original_CostingSheetID) AND ([RefID] = @Original_RefID)  AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCostingSheetIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}