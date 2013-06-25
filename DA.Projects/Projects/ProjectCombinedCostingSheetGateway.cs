using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCombinedCostingSheetGateway
    /// </summary>
    public class ProjectCombinedCostingSheetGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCombinedCostingSheetGateway()
            : base("LFS_PROJECT_COMBINED_COSTING_SHEET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCombinedCostingSheetGateway(DataSet data)
            : base(data, "LFS_PROJECT_COMBINED_COSTING_SHEET")
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
            tableMapping.DataSetTable = "LFS_PROJECT_COMBINED_COSTING_SHEET";
            tableMapping.ColumnMappings.Add("CostingSheetID", "CostingSheetID");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("TotalLabourHoursCad", "TotalLabourHoursCad");
            tableMapping.ColumnMappings.Add("TotalLabourHoursUsd", "TotalLabourHoursUsd");
            tableMapping.ColumnMappings.Add("TotalMaterialsCad", "TotalMaterialsCad");
            tableMapping.ColumnMappings.Add("TotalMaterialsUsd", "TotalMaterialsUsd");
            tableMapping.ColumnMappings.Add("TotalUnitsCad", "TotalUnitsCad");
            tableMapping.ColumnMappings.Add("TotalUnitsUsd", "TotalUnitsUsd");
            tableMapping.ColumnMappings.Add("TotalOtherCostsCad", "TotalOtherCostsCad");
            tableMapping.ColumnMappings.Add("TotalOtherCostsUsd", "TotalOtherCostsUsd");
            tableMapping.ColumnMappings.Add("GrandTotalCad", "GrandTotalCad");
            tableMapping.ColumnMappings.Add("GrandTotalUsd", "GrandTotalUsd");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("TotalSubcontractorsCad", "TotalSubcontractorsCad");
            tableMapping.ColumnMappings.Add("TotalSubcontractorsUsd", "TotalSubcontractorsUsd");
            tableMapping.ColumnMappings.Add("GrandRevenue", "GrandRevenue");
            tableMapping.ColumnMappings.Add("GrandProfit", "GrandProfit");
            tableMapping.ColumnMappings.Add("GrandGrossMargin", "GrandGrossMargin");
            tableMapping.ColumnMappings.Add("CombinedProjects", "CombinedProjects");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_PROJECT_COMBINED_COSTING_SHEET] WHERE (([CostingSheetID] = @Original_CostingSheetID) AND ([ClientID] = @Original_ClientID) AND ([Name] = @Original_Name) AND ([StartDate] = @Original_StartDate) AND ([EndDate] = @Original_EndDate) AND ([TotalLabourHoursCad] = @Original_TotalLabourHoursCad) AND ([TotalLabourHoursUsd] = @Original_TotalLabourHoursUsd) AND ([TotalMaterialsCad] = @Original_TotalMaterialsCad) AND ([TotalMaterialsUsd] = @Original_TotalMaterialsUsd) AND ([TotalUnitsCad] = @Original_TotalUnitsCad) AND ([TotalUnitsUsd] = @Original_TotalUnitsUsd) AND ([TotalOtherCostsCad] = @Original_TotalOtherCostsCad) AND ([TotalOtherCostsUsd] = @Original_TotalOtherCostsUsd) AND ([GrandTotalCad] = @Original_GrandTotalCad) AND ([GrandTotalUsd] = @Original_GrandTotalUsd) AND ([State] = @Original_State) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([TotalSubcontractorsCad] = @Original_TotalSubcontractorsCad) AND ([TotalSubcontractorsUsd] = @Original_TotalSubcontractorsUsd) AND ([GrandRevenue] = @Original_GrandRevenue) AND ([GrandProfit] = @Original_GrandProfit) AND ([GrandGrossMargin] = @Original_GrandGrossMargin))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostingSheetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostingSheetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalLabourHoursCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalLabourHoursCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalLabourHoursUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalLabourHoursUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalMaterialsCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMaterialsCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalMaterialsUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMaterialsUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalUnitsCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalUnitsCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalUnitsUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalUnitsUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalOtherCostsCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalOtherCostsCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalOtherCostsUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalOtherCostsUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GrandTotalCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandTotalCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GrandTotalUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandTotalUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalSubcontractorsCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalSubcontractorsCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalSubcontractorsUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalSubcontractorsUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GrandRevenue", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandRevenue", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GrandProfit", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandProfit", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GrandGrossMargin", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandGrossMargin", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT_COMBINED_COSTING_SHEET] ([ClientID], [Name], [StartDate], [EndDate], [TotalLabourHoursCad], [TotalLabourHoursUsd], [TotalMaterialsCad], [TotalMaterialsUsd], [TotalUnitsCad], [TotalUnitsUsd], [TotalOtherCostsCad], [TotalOtherCostsUsd], [GrandTotalCad], [GrandTotalUsd], [State], [Deleted], [COMPANY_ID], [TotalSubcontractorsCad], [TotalSubcontractorsUsd], [GrandRevenue], [GrandProfit], [GrandGrossMargin]) VALUES (@ClientID, @Name, @StartDate, @EndDate, @TotalLabourHoursCad, @TotalLabourHoursUsd, @TotalMaterialsCad, @TotalMaterialsUsd, @TotalUnitsCad, @TotalUnitsUsd, @TotalOtherCostsCad, @TotalOtherCostsUsd, @GrandTotalCad, @GrandTotalUsd, @State, @Deleted, @COMPANY_ID, @TotalSubcontractorsCad, @TotalSubcontractorsUsd, @GrandRevenue, @GrandProfit, @GrandGrossMargin);
SELECT CostingSheetID, ClientID, Name, StartDate, EndDate, TotalLabourHoursCad, TotalLabourHoursUsd, TotalMaterialsCad, TotalMaterialsUsd, TotalUnitsCad, TotalUnitsUsd, TotalOtherCostsCad, TotalOtherCostsUsd, GrandTotalCad, GrandTotalUsd, State, Deleted, COMPANY_ID, TotalSubcontractorsCad, TotalSubcontractorsUsd, GrandRevenue, GrandProfit, GrandGrossMargin FROM LFS_PROJECT_COMBINED_COSTING_SHEET WHERE (CostingSheetID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalLabourHoursCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalLabourHoursCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalLabourHoursUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalLabourHoursUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalMaterialsCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMaterialsCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalMaterialsUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMaterialsUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalUnitsCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalUnitsCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalUnitsUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalUnitsUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalOtherCostsCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalOtherCostsCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalOtherCostsUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalOtherCostsUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GrandTotalCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandTotalCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GrandTotalUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandTotalUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalSubcontractorsCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalSubcontractorsCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalSubcontractorsUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalSubcontractorsUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GrandRevenue", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandRevenue", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GrandProfit", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandProfit", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GrandGrossMargin", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandGrossMargin", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_PROJECT_COMBINED_COSTING_SHEET] SET [ClientID] = @ClientID, [Name] = @" +
                "Name, [StartDate] = @StartDate, [EndDate] = @EndDate, [TotalLabourHoursCad] = @T" +
                "otalLabourHoursCad, [TotalLabourHoursUsd] = @TotalLabourHoursUsd, [TotalMaterial" +
                "sCad] = @TotalMaterialsCad, [TotalMaterialsUsd] = @TotalMaterialsUsd, [TotalUnit" +
                "sCad] = @TotalUnitsCad, [TotalUnitsUsd] = @TotalUnitsUsd, [TotalOtherCostsCad] =" +
                " @TotalOtherCostsCad, [TotalOtherCostsUsd] = @TotalOtherCostsUsd, [GrandTotalCad" +
                "] = @GrandTotalCad, [GrandTotalUsd] = @GrandTotalUsd, [State] = @State, [Deleted" +
                "] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [TotalSubcontractorsCad] = @TotalSubco" +
                "ntractorsCad, [TotalSubcontractorsUsd] = @TotalSubcontractorsUsd, [GrandRevenue]" +
                " = @GrandRevenue, [GrandProfit] = @GrandProfit, [GrandGrossMargin] = @GrandGross" +
                "Margin WHERE (([CostingSheetID] = @Original_CostingSheetID) AND ([ClientID] = @" +
                "Original_ClientID) AND ([Name] = @Original_Name) AND ([StartDate] = @Original_S" +
                "tartDate) AND ([EndDate] = @Original_EndDate) AND ([TotalLabourHoursCad] = @Orig" +
                "inal_TotalLabourHoursCad) AND ([TotalLabourHoursUsd] = @Original_TotalLabourHour" +
                "sUsd) AND ([TotalMaterialsCad] = @Original_TotalMaterialsCad) AND ([TotalMateria" +
                "lsUsd] = @Original_TotalMaterialsUsd) AND ([TotalUnitsCad] = @Original_TotalUnit" +
                "sCad) AND ([TotalUnitsUsd] = @Original_TotalUnitsUsd) AND ([TotalOtherCostsCad] " +
                "= @Original_TotalOtherCostsCad) AND ([TotalOtherCostsUsd] = @Original_TotalOther" +
                "CostsUsd) AND ([GrandTotalCad] = @Original_GrandTotalCad) AND ([GrandTotalUsd] =" +
                " @Original_GrandTotalUsd) AND ([State] = @Original_State) AND ([Deleted] = @Orig" +
                "inal_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([TotalSubcontractor" +
                "sCad] = @Original_TotalSubcontractorsCad) AND ([TotalSubcontractorsUsd] = @Origi" +
                "nal_TotalSubcontractorsUsd) AND ([GrandRevenue] = @Original_GrandRevenue) AND ([" +
                "GrandProfit] = @Original_GrandProfit) AND ([GrandGrossMargin] = @Original_GrandG" +
                "rossMargin));\r\nSELECT CostingSheetID, ClientID, Name, StartDate, EndDate, Total" +
                "LabourHoursCad, TotalLabourHoursUsd, TotalMaterialsCad, TotalMaterialsUsd, Total" +
                "UnitsCad, TotalUnitsUsd, TotalOtherCostsCad, TotalOtherCostsUsd, GrandTotalCad, " +
                "GrandTotalUsd, State, Deleted, COMPANY_ID, TotalSubcontractorsCad, TotalSubcontr" +
                "actorsUsd, GrandRevenue, GrandProfit, GrandGrossMargin FROM LFS_PROJECT_COSTING_" +
                "SHEET WHERE (CostingSheetID = @CostingSheetID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalLabourHoursCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalLabourHoursCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalLabourHoursUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalLabourHoursUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalMaterialsCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMaterialsCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalMaterialsUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMaterialsUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalUnitsCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalUnitsCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalUnitsUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalUnitsUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalOtherCostsCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalOtherCostsCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalOtherCostsUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalOtherCostsUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GrandTotalCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandTotalCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GrandTotalUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandTotalUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalSubcontractorsCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalSubcontractorsCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalSubcontractorsUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalSubcontractorsUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GrandRevenue", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandRevenue", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GrandProfit", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandProfit", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GrandGrossMargin", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandGrossMargin", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostingSheetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostingSheetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalLabourHoursCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalLabourHoursCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalLabourHoursUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalLabourHoursUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalMaterialsCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMaterialsCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalMaterialsUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMaterialsUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalUnitsCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalUnitsCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalUnitsUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalUnitsUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalOtherCostsCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalOtherCostsCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalOtherCostsUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalOtherCostsUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GrandTotalCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandTotalCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GrandTotalUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandTotalUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalSubcontractorsCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalSubcontractorsCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalSubcontractorsUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalSubcontractorsUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GrandRevenue", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandRevenue", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GrandProfit", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandProfit", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GrandGrossMargin", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrandGrossMargin", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostingSheetID", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "CostingSheetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a costing sheet (direct to DB)
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="name">name</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="totalLabourHoursCad">totalLabourHoursCad</param>
        /// <param name="totalLabourHoursUsd">totalLabourHoursUsd</param>
        /// <param name="totalMaterialsCad">totalMaterialsCad</param>
        /// <param name="totalMaterialsUsd">totalMaterialsUsd</param>
        /// <param name="totalUnitsCad">totalUnitsCad</param>
        /// <param name="totalUnitsUsd">totalUnitsUsd</param>
        /// <param name="totalOtherCostsCad">totalOtherCostsCad</param>
        /// <param name="totalOtherCostsUsd">totalOtherCostsUsd</param>
        /// <param name="grandTotalCad">grandTotalCad</param>
        /// <param name="grandTotalUsd">grandTotalUsd</param>
        /// <param name="state">state</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="totalSubcontractorsCad">totalSubcontractorsCad</param>
        /// <param name="totalSubcontractorsUsd">totalSubcontractorsUsd</param>
        /// <returns>CostingSheetID</returns>
        public int Insert(int clientId, string name, DateTime startDate, DateTime endDate, decimal totalLabourHoursCad, decimal totalLabourHoursUsd, decimal totalMaterialsCad, decimal totalMaterialsUsd, decimal totalUnitsCad, decimal totalUnitsUsd, decimal totalOtherCostsCad, decimal totalOtherCostsUsd, decimal grandTotalCad, decimal grandTotalUsd, string state, bool deleted, int companyId, decimal totalSubcontractorsCad, decimal totalSubcontractorsUsd, decimal grandRevenue, decimal grandProfit, decimal grandGrossMargin, string combinedProjects)
        {
            SqlParameter clientIdParameter = new SqlParameter("ClientID", clientId);
            SqlParameter nameParameter = new SqlParameter("Name", name);
            SqlParameter startDateParameter = new SqlParameter("StartDate", startDate);
            SqlParameter endDateParameter = new SqlParameter("EndDate", endDate);
            SqlParameter totalLabourHoursCadParameter = new SqlParameter("TotalLabourHoursCad", totalLabourHoursCad);totalLabourHoursCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter totalLabourHoursUsdParameter = new SqlParameter("TotalLabourHoursUsd", totalLabourHoursUsd);totalLabourHoursUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter totalMaterialsCadParameter = new SqlParameter("TotalMaterialsCad", totalMaterialsCad);totalMaterialsCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter totalMaterialsUsdParameter = new SqlParameter("TotalMaterialsUsd", totalMaterialsUsd);totalMaterialsUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter totalUnitsCadParameter = new SqlParameter("TotalUnitsCad", totalUnitsCad);totalUnitsCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter totalUnitsUsdParameter = new SqlParameter("TotalUnitsUsd", totalUnitsUsd);totalUnitsUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter totalOtherCostsCadParameter = new SqlParameter("TotalOtherCostsCad", totalOtherCostsCad);totalOtherCostsCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter totalOtherCostsUsdParameter = new SqlParameter("TotalOtherCostsUsd", totalOtherCostsUsd);totalOtherCostsUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter grandTotalCadParameter = new SqlParameter("GrandTotalCad", grandTotalCad);grandTotalCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter grandTotalUsdParameter = new SqlParameter("GrandTotalUsd", grandTotalUsd);grandTotalUsdParameter.SqlDbType = SqlDbType.Money;            
            SqlParameter stateParameter = new SqlParameter("State", state);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter totalSubcontractorsCadParameter = new SqlParameter("TotalSubcontractorsCad", totalSubcontractorsCad); totalSubcontractorsCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter totalSubcontractorsUsdParameter = new SqlParameter("TotalSubcontractorsUsd", totalSubcontractorsUsd); totalSubcontractorsUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter grandRevenueParameter = new SqlParameter("GrandRevenue", grandRevenue); grandRevenueParameter.SqlDbType = SqlDbType.Money;
            SqlParameter grandProfitParameter = new SqlParameter("GrandProfit", grandProfit); grandProfitParameter.SqlDbType = SqlDbType.Money;
            SqlParameter grandGrossMarginParameter = new SqlParameter("GrandGrossMargin", grandGrossMargin); grandGrossMarginParameter.SqlDbType = SqlDbType.Money;
            SqlParameter combinedProjectsParameter = new SqlParameter("CombinedProjects", combinedProjects);

            string command = "INSERT INTO [dbo].[LFS_PROJECT_COMBINED_COSTING_SHEET] ([ClientID], [Name], [StartDate], [EndDate], [TotalLabourHoursCad], [TotalLabourHoursUsd], [TotalMaterialsCad], "+
                            " [TotalMaterialsUsd], [TotalUnitsCad], [TotalUnitsUsd], [TotalOtherCostsCad], [TotalOtherCostsUsd], [GrandTotalCad], [GrandTotalUsd], [State], [Deleted], [COMPANY_ID], "+
                            " [TotalSubcontractorsCad], [TotalSubcontractorsUsd], [GrandRevenue], [GrandProfit], [GrandGrossMargin], [CombinedProjects]) " +
                             " VALUES (@ClientID, @Name, @StartDate, @EndDate, @TotalLabourHoursCad, @TotalLabourHoursUsd, @TotalMaterialsCad, "+
                             " @TotalMaterialsUsd, @TotalUnitsCad, @TotalUnitsUsd, @TotalOtherCostsCad, @TotalOtherCostsUsd, @GrandTotalCad, @GrandTotalUsd, @State, @Deleted, @COMPANY_ID, @TotalSubcontractorsCad, "+
                             " @TotalSubcontractorsUsd, @GrandRevenue, @GrandProfit, @GrandGrossMargin, @CombinedProjects); SELECT CostingSheetID FROM LFS_PROJECT_COMBINED_COSTING_SHEET WHERE (CostingSheetID = SCOPE_IDENTITY())";

            int costingSheetId = (int)ExecuteScalar(command, clientIdParameter, nameParameter, startDateParameter, endDateParameter, totalLabourHoursCadParameter, totalLabourHoursUsdParameter, totalMaterialsCadParameter, totalMaterialsUsdParameter, totalUnitsCadParameter, totalUnitsUsdParameter, totalOtherCostsCadParameter, totalOtherCostsUsdParameter, grandTotalCadParameter, grandTotalUsdParameter, stateParameter, deletedParameter, companyIdParameter, totalSubcontractorsCadParameter, totalSubcontractorsUsdParameter, grandRevenueParameter, grandProfitParameter, grandGrossMarginParameter, combinedProjectsParameter);

            return costingSheetId;
        }



        /// <summary>
        /// Update costing sheet (Direct to DB)
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="originalClientId">originalClientId</param>
        /// <param name="originalName">originalName</param>
        /// <param name="originalStartDate">originalStartDate</param>
        /// <param name="originalEndDate">originalEndDate</param>
        /// <param name="originalTotalLabourHoursCad">originalTotalLabourHoursCad</param>
        /// <param name="originalTotalLabourHoursUsd">originalTotalLabourHoursUsd</param>
        /// <param name="originalTotalMaterialsCad">originalTotalMaterialsCad</param>
        /// <param name="originalTotalMaterialsUsd">originalTotalMaterialsUsd</param>
        /// <param name="originalTotalUnitsCad">originalTotalUnitsCad</param>
        /// <param name="originalTotalUnitsUsd">originalTotalUnitsUsd</param>
        /// <param name="originalTotalOtherCostsCad">originalTotalOtherCostsCad</param>
        /// <param name="originalTotalOtherCostsUsd">originalTotalOtherCostsUsd</param>
        /// <param name="originalGrandTotalCad">originalGrandTotalCad</param>
        /// <param name="originalGrandTotalUsd">originalGrandTotalUsd</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalTotalSubcontractorsCad">originalTotalSubcontractorsCad</param>
        /// <param name="originalTotalSubcontractorsUsd">originalTotalSubcontractorsUsd</param>
        /// 
        /// <param name="newClientId">newClientId</param>
        /// <param name="newName">newName</param>
        /// <param name="newStartDate">newStartDate</param>
        /// <param name="newEndDate">newEndDate</param>
        /// <param name="newTotalLabourHoursCad">newTotalLabourHoursCad</param>
        /// <param name="newTotalLabourHoursUsd">newTotalLabourHoursUsd</param>
        /// <param name="newTotalMaterialsCad">newTotalMaterialsCad</param>
        /// <param name="newTotalMaterialsUsd">newTotalMaterialsUsd</param>
        /// <param name="newTotalUnitsCad">newTotalUnitsCad</param>
        /// <param name="newTotalUnitsUsd">newTotalUnitsUsd</param>
        /// <param name="newTotalOtherCostsCad">newTotalOtherCostsCad</param>
        /// <param name="newTotalOtherCostsUsd">newTotalOtherCostsUsd</param>
        /// <param name="newGrandTotalCad">newGrandTotalCad</param>
        /// <param name="newGrandTotalUsd">newGrandTotalUsd</param>
        /// <param name="newState">newState</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newTotalSubcontractorsCad">newTotalSubcontractorsCad</param>
        /// <param name="newTotalSubcontractorsUsd">newTotalSubcontractorsUsd</param>
        public void Update(int costingSheetId, int originalClientId, string originalName, DateTime originalStartDate, DateTime originalEndDate, decimal originalTotalLabourHoursCad, decimal originalTotalLabourHoursUsd, decimal originalTotalMaterialsCad, decimal originalTotalMaterialsUsd, decimal originalTotalUnitsCad, decimal originalTotalUnitsUsd, decimal originalTotalOtherCostsCad, decimal originalTotalOtherCostsUsd, decimal originalGrandTotalCad, decimal originalGrandTotalUsd, string originalState, bool originalDeleted, int originalCompanyId, decimal originalTotalSubcontractorsCad, decimal originalTotalSubcontractorsUsd, decimal originalGrandRevenue, decimal originalGrandProfit, decimal originalGrandGrossMargin, int newClientId, string newName, DateTime newStartDate, DateTime newEndDate, decimal newTotalLabourHoursCad, decimal newTotalLabourHoursUsd, decimal newTotalMaterialsCad, decimal newTotalMaterialsUsd, decimal newTotalUnitsCad, decimal newTotalUnitsUsd, decimal newTotalOtherCostsCad, decimal newTotalOtherCostsUsd, decimal newGrandTotalCad, decimal newGrandTotalUsd, string newState, bool newDeleted, int newCompanyId, decimal newTotalSubcontractorsCad, decimal newTotalSubcontractorsUsd, decimal newGrandRevenue, decimal newGrandProfit, decimal newGrandGrossMargin, string originalCombinedProjects, string newCombinedProjets)
        {
            SqlParameter originalCostingSheetIdParameter = new SqlParameter("Original_CostingSheetID", costingSheetId);
            SqlParameter originalClientIdParameter = new SqlParameter("Original_ClientID", originalClientId);
            SqlParameter originalStartDateParameter = new SqlParameter("Original_StartDate", originalStartDate);
            SqlParameter originalEndDateParameter = new SqlParameter("Original_EndDate", originalEndDate);
            SqlParameter originalTotalLabourHoursCadParameter = new SqlParameter("Original_TotalLabourHoursCad", originalTotalLabourHoursCad); originalTotalLabourHoursCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalTotalLabourHoursUsdParameter = new SqlParameter("Original_TotalLabourHoursUsd", originalTotalLabourHoursUsd); originalTotalLabourHoursUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalTotalMaterialsCadParameter = new SqlParameter("Original_TotalMaterialsCad", originalTotalMaterialsCad); originalTotalMaterialsCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalTotalMaterialsUsdParameter = new SqlParameter("Original_TotalMaterialsUsd", originalTotalMaterialsUsd); originalTotalMaterialsUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalTotalUnitsCadParameter = new SqlParameter("Original_TotalUnitsCad", originalTotalUnitsCad); originalTotalUnitsCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalTotalUnitsUsdParameter = new SqlParameter("Original_TotalUnitsUsd", originalTotalUnitsUsd); originalTotalUnitsUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalTotalOtherCostsCadParameter = new SqlParameter("Original_TotalOtherCostsCad", originalTotalOtherCostsCad); originalTotalOtherCostsCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalTotalOtherCostsUsdParameter = new SqlParameter("Original_TotalOtherCostsUsd", originalTotalOtherCostsUsd); originalTotalOtherCostsUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalGrandTotalCadParameter = new SqlParameter("Original_GrandTotalCad", originalGrandTotalCad); originalGrandTotalCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalGrandTotalUsdParameter = new SqlParameter("Original_GrandTotalUsd", originalGrandTotalUsd); originalGrandTotalUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalStateParameter = new SqlParameter("Original_State", originalState);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalTotalSubcontractorsCadParameter = new SqlParameter("Original_TotalSubcontractorsCad", originalTotalSubcontractorsCad); originalTotalSubcontractorsCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalTotalSubcontractorsUsdParameter = new SqlParameter("Original_TotalSubcontractorsUsd", originalTotalSubcontractorsUsd); originalTotalSubcontractorsUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalGrandRevenueParameter = new SqlParameter("Original_GrandRevenue", originalGrandRevenue); originalGrandRevenueParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalGrandProfitParameter = new SqlParameter("Original_GrandProfit", originalGrandProfit); originalGrandProfitParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalGrandGrossMarginParameter = new SqlParameter("Original_GrandGrossMargin", originalGrandGrossMargin); originalGrandGrossMarginParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalCombinedProjectsParameter = new SqlParameter("Original_CombinedProjects", originalCombinedProjects);

            SqlParameter newCostingSheetIdParameter = new SqlParameter("CostingSheetID", costingSheetId);
            SqlParameter newClientIdParameter = new SqlParameter("ClientID", newClientId);
            SqlParameter newStartDateParameter = new SqlParameter("StartDate", newStartDate);
            SqlParameter newEndDateParameter = new SqlParameter("EndDate", newEndDate);
            SqlParameter newTotalLabourHoursCadParameter = new SqlParameter("TotalLabourHoursCad", newTotalLabourHoursCad); newTotalLabourHoursCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newTotalLabourHoursUsdParameter = new SqlParameter("TotalLabourHoursUsd", newTotalLabourHoursUsd); newTotalLabourHoursUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newTotalMaterialsCadParameter = new SqlParameter("TotalMaterialsCad", newTotalMaterialsCad); newTotalMaterialsCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newTotalMaterialsUsdParameter = new SqlParameter("TotalMaterialsUsd", newTotalMaterialsUsd); newTotalMaterialsUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newTotalUnitsCadParameter = new SqlParameter("TotalUnitsCad", newTotalUnitsCad); newTotalUnitsCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newTotalUnitsUsdParameter = new SqlParameter("TotalUnitsUsd", newTotalUnitsUsd); newTotalUnitsUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newTotalOtherCostsCadParameter = new SqlParameter("TotalOtherCostsCad", newTotalOtherCostsCad); newTotalOtherCostsCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newTotalOtherCostsUsdParameter = new SqlParameter("TotalOtherCostsUsd", newTotalOtherCostsUsd); newTotalOtherCostsUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newGrandTotalCadParameter = new SqlParameter("GrandTotalCad", newGrandTotalCad); newGrandTotalCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newGrandTotalUsdParameter = new SqlParameter("GrandTotalUsd", newGrandTotalUsd); newGrandTotalUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newStateParameter = new SqlParameter("State", newState);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newTotalSubcontractorsCadParameter = new SqlParameter("TotalSubcontractorsCad", newTotalSubcontractorsCad); newTotalSubcontractorsCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newTotalSubcontractorsUsdParameter = new SqlParameter("TotalSubcontractorsUsd", newTotalSubcontractorsUsd); newTotalSubcontractorsUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newGrandRevenueParameter = new SqlParameter("GrandRevenue", originalGrandRevenue); newGrandRevenueParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newGrandProfitParameter = new SqlParameter("GrandProfit", originalGrandProfit); newGrandProfitParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newGrandGrossMarginParameter = new SqlParameter("GrandGrossMargin", newGrandGrossMargin); newGrandGrossMarginParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newCombinedProjectsParameter = new SqlParameter("CombinedProjects", newCombinedProjets);

            string command = "UPDATE [dbo].[LFS_PROJECT_COMBINED_COSTING_SHEET] " +
                " SET [ClientID] = @ClientID, [StartDate] = @StartDate, [EndDate] = @EndDate, " +
                " [TotalLabourHoursCad] = @TotalLabourHoursCad, [TotalLabourHoursUsd] = @TotalLabourHoursUsd, [TotalMaterialsCad] = @TotalMaterialsCad, [TotalMaterialsUsd] = @TotalMaterialsUsd, " +
                " [TotalUnitsCad] = @TotalUnitsCad, [TotalUnitsUsd] = @TotalUnitsUsd, [TotalOtherCostsCad] = @TotalOtherCostsCad, [TotalOtherCostsUsd] = @TotalOtherCostsUsd, " +
                " [GrandTotalCad] = @GrandTotalCad, [GrandTotalUsd] = @GrandTotalUsd, [State] = @State, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [TotalSubcontractorsCad] = @TotalSubcontractorsCad, "+
                " [TotalSubcontractorsUsd] = @TotalSubcontractorsUsd, [GrandRevenue] = @GrandRevenue, [GrandProfit] = @GrandProfit, [GrandGrossMargin] = @GrandGrossMargin " +
                " WHERE (" +
                " ([CostingSheetID] = @Original_CostingSheetID) AND ([COMPANY_ID] = @Original_COMPANY_ID)" +
                " )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCostingSheetIdParameter, originalClientIdParameter, originalStartDateParameter, originalEndDateParameter, originalTotalLabourHoursCadParameter, originalTotalLabourHoursUsdParameter, originalTotalMaterialsCadParameter, originalTotalMaterialsUsdParameter, originalTotalUnitsCadParameter, originalTotalUnitsUsdParameter, originalTotalOtherCostsCadParameter, originalTotalOtherCostsUsdParameter, originalGrandTotalCadParameter, originalGrandTotalUsdParameter, originalStateParameter, originalDeletedParameter, originalCompanyIdParameter, originalTotalSubcontractorsCadParameter, originalTotalSubcontractorsUsdParameter, originalGrandRevenueParameter, originalGrandProfitParameter, originalGrandGrossMarginParameter, newCostingSheetIdParameter, newClientIdParameter, newStartDateParameter, newEndDateParameter, newTotalLabourHoursCadParameter, newTotalLabourHoursUsdParameter, newTotalMaterialsCadParameter, newTotalMaterialsUsdParameter, newTotalUnitsCadParameter, newTotalUnitsUsdParameter, newTotalOtherCostsCadParameter, newTotalOtherCostsUsdParameter, newGrandTotalCadParameter, newGrandTotalUsdParameter, newStateParameter, newDeletedParameter, newCompanyIdParameter, newTotalSubcontractorsCadParameter, newTotalSubcontractorsUsdParameter, newGrandRevenueParameter, newGrandProfitParameter, newGrandGrossMarginParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// Delete a costing sheet (direct to DB)
        /// </summary>
        /// <param name="originalcostingSheetId">originalcostingSheetId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalCostingSheetId, int originalCompanyId)
        {
            SqlParameter originalCostingSheetIdParameter = new SqlParameter("Original_CostingSheetID", originalCostingSheetId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_PROJECT_COMBINED_COSTING_SHEET] SET  [Deleted] = @Deleted  " +
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
        /// UpdateState
        /// </summary>
        /// <param name="originalcostingSheetId">originalcostingSheetId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newState">newState</param>
        public void UpdateState(int originalCostingSheetId, int originalCompanyId, string newState)
        {
            SqlParameter originalCostingSheetIdParameter = new SqlParameter("Original_CostingSheetID", originalCostingSheetId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter newStateParameter = new SqlParameter("State", newState);

            string command = "UPDATE [dbo].[LFS_PROJECT_COMBINED_COSTING_SHEET] " +
                " SET [State] = @State " +
                " WHERE (" +
                " ([CostingSheetID] = @Original_CostingSheetID) AND " +
                " ([COMPANY_ID] = @Original_COMPANY_ID)" +
                " )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCostingSheetIdParameter, originalCompanyIdParameter, newStateParameter);
            
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// ExistCostingSheetApproved
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <returns>TRUE if is used</returns>
        public bool ExistCostingSheetApproved(int clientId, DateTime startDate, DateTime endDate)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_PROJECT_COMBINED_COSTING_SHEET WHERE (ClientID = @clientId) AND ((StartDate BETWEEN @startDate AND @endDate) OR (EndDate BETWEEN @startDate AND @endDate)) AND (State = 'Approved') AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@clientId", clientId));
            command.Parameters.Add(new SqlParameter("@startDate", startDate));
            command.Parameters.Add(new SqlParameter("@endDate", endDate));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



    }
}