using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetTemplateGateway
    /// </summary>
    public class ProjectCostingSheetTemplateGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetTemplateGateway()
            : base("LFS_PROJECT_COSTING_SHEET_TEMPLATE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetTemplateGateway(DataSet data)
            : base(data, "LFS_PROJECT_COSTING_SHEET_TEMPLATE")
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
            tableMapping.DataSetTable = "LFS_PROJECT_COSTING_SHEET_TEMPLATE";
            tableMapping.ColumnMappings.Add("CostingSheetTemplateID", "CostingSheetTemplateID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("RAData", "RAData");
            tableMapping.ColumnMappings.Add("FLLData", "FLLData");
            tableMapping.ColumnMappings.Add("PRData", "PRData");
            tableMapping.ColumnMappings.Add("JLData", "JLData");
            tableMapping.ColumnMappings.Add("MRData", "MRData");
            tableMapping.ColumnMappings.Add("MOBData", "MOBData");
            tableMapping.ColumnMappings.Add("OtherData", "OtherData");
            tableMapping.ColumnMappings.Add("LabourHourData", "LabourHourData");
            tableMapping.ColumnMappings.Add("UnitData", "UnitData");
            tableMapping.ColumnMappings.Add("MaterialData", "MaterialData");
            tableMapping.ColumnMappings.Add("SubcontractorData", "SubcontractorData");
            tableMapping.ColumnMappings.Add("MiscData", "MiscData");
            tableMapping.ColumnMappings.Add("RevenueIncluded", "RevenueIncluded");
            tableMapping.ColumnMappings.Add("Month", "Month");
            tableMapping.ColumnMappings.Add("Day", "Day");
            tableMapping.ColumnMappings.Add("Year", "Year");
            tableMapping.ColumnMappings.Add("Month2", "Month2");
            tableMapping.ColumnMappings.Add("Day2", "Day2");
            tableMapping.ColumnMappings.Add("Year2", "Year2");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");            
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_PROJECT_COSTING_SHEET_TEMPLATE] WHERE (([CostingSheetTemplateID] = @Original_CostingSheetTemplateID) AND ([Name] = @Original_Name) AND ([RAData] = @Original_RAData) AND ([FLLData] = @Original_FLLData) AND ([PRData] = @Original_PRData) AND ([JLData] = @Original_JLData) AND ([MRData] = @Original_MRData) AND ([MOBData] = @Original_MOBData) AND ([OtherData] = @Original_OtherData) AND ([LabourHourData] = @Original_LabourHourData) AND ([UnitData] = @Original_UnitData) AND ([MaterialData] = @Original_MaterialData) AND ([SubcontractorData] = @Original_SubcontractorData) AND ([MiscData] = @Original_MiscData) AND ([RevenueIncluded] = @Original_RevenueIncluded) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostingSheetTemplateID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostingSheetTemplateID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RAData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RAData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FLLData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FLLData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PRData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PRData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_JLData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JLData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MRData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MRData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MOBData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MOBData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OtherData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OtherData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LabourHourData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LabourHourData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MaterialData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SubcontractorData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SubcontractorData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MiscData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MiscData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RevenueIncluded", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RevenueIncluded", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT_COSTING_SHEET_TEMPLATE] ([Name], [RAData], [FLLData], [PRData], [JLData], [MRData], [MOBData], [OtherData], [LabourHourData], [UnitData], [MaterialData], [SubcontractorData], [MiscData], [RevenueIncluded], [Deleted], [COMPANY_ID]) VALUES (@Name, @RAData, @FLLData, @PRData, @JLData, @MRData, @MOBData, @OtherData, @LabourHourData, @UnitData, @MaterialData, @SubcontractorData, @MiscData, @RevenueIncluded, @Deleted, @COMPANY_ID);
SELECT CostingSheetTemplateID, Name, RAData, FLLData, PRData, JLData, MRData, MOBData, OtherData, LabourHourData, UnitData, MaterialData, SubcontractorData, MiscData, RevenueIncluded, Deleted, COMPANY_ID FROM LFS_PROJECT_COSTING_SHEET_TEMPLATE WHERE (CostingSheetTemplateID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RAData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RAData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FLLData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FLLData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PRData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PRData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@JLData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JLData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MRData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MRData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MOBData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MOBData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OtherData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OtherData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LabourHourData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LabourHourData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MaterialData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SubcontractorData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SubcontractorData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MiscData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MiscData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RevenueIncluded", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RevenueIncluded", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_PROJECT_COSTING_SHEET_TEMPLATE] SET [Name] = @Name, [RAData] = @RAData, [FLLData] = @FLLData, [PRData] = @PRData, [JLData] = @JLData, [MRData] = @MRData, [MOBData] = @MOBData, [OtherData] = @OtherData, [LabourHourData] = @LabourHourData, [UnitData] = @UnitData, [MaterialData] = @MaterialData, [SubcontractorData] = @SubcontractorData, [MiscData] = @MiscData, [RevenueIncluded] = @RevenueIncluded, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([CostingSheetTemplateID] = @Original_CostingSheetTemplateID) AND ([Name] = @Original_Name) AND ([RAData] = @Original_RAData) AND ([FLLData] = @Original_FLLData) AND ([PRData] = @Original_PRData) AND ([JLData] = @Original_JLData) AND ([MRData] = @Original_MRData) AND ([MOBData] = @Original_MOBData) AND ([OtherData] = @Original_OtherData) AND ([LabourHourData] = @Original_LabourHourData) AND ([UnitData] = @Original_UnitData) AND ([MaterialData] = @Original_MaterialData) AND ([SubcontractorData] = @Original_SubcontractorData) AND ([MiscData] = @Original_MiscData) AND ([RevenueIncluded] = @Original_RevenueIncluded) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT CostingSheetTemplateID, Name, RAData, FLLData, PRData, JLData, MRData, MOBData, OtherData, LabourHourData, UnitData, MaterialData, SubcontractorData, MiscData, RevenueIncluded, Deleted, COMPANY_ID FROM LFS_PROJECT_COSTING_SHEET_TEMPLATE WHERE (CostingSheetTemplateID = @CostingSheetTemplateID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RAData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RAData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FLLData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FLLData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PRData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PRData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@JLData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JLData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MRData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MRData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MOBData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MOBData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OtherData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OtherData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LabourHourData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LabourHourData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MaterialData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SubcontractorData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SubcontractorData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MiscData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MiscData", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RevenueIncluded", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RevenueIncluded", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostingSheetTemplateID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostingSheetTemplateID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RAData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RAData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FLLData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FLLData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PRData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PRData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_JLData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JLData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MRData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MRData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MOBData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MOBData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OtherData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OtherData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LabourHourData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LabourHourData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MaterialData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SubcontractorData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SubcontractorData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MiscData", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MiscData", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RevenueIncluded", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RevenueIncluded", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostingSheetTemplateID", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "CostingSheetTemplateID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

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
        /// <param name="refIDRevenue">refIDRevenue</param>
        /// <param name="revenue">revenue</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="comment">comment</param>
        public int Insert(string name, bool raData, bool fllData, bool prData, bool jlData, bool mrData, bool mobData, bool otherData, bool labourHourData, bool unitData, bool materialData, bool subcontractorData, bool miscData, bool revenueIncluded, bool deleted, int companyId, int? month, int? day, int? year, int? month2, int? day2, int? year2)
        {
            SqlParameter nameParameter = new SqlParameter("Name", name);
            SqlParameter raDataParameter = new SqlParameter("RAData", raData);
            SqlParameter fllDataParameter = new SqlParameter("FLLData", fllData);
            SqlParameter prDataParameter = new SqlParameter("PRData", prData);
            SqlParameter jlDataParameter = new SqlParameter("JLData", jlData);
            SqlParameter mrDataParameter = new SqlParameter("MRData", mrData);
            SqlParameter mobDataParameter = new SqlParameter("MOBData", mobData);
            SqlParameter otherDataParameter = new SqlParameter("OtherData", otherData);
            SqlParameter labourHourDataParameter = new SqlParameter("LabourHourData", labourHourData);
            SqlParameter unitDataParameter = new SqlParameter("UnitData", unitData);
            SqlParameter materialDataParameter = new SqlParameter("MaterialData", materialData);
            SqlParameter subcontractorDataParameter = new SqlParameter("SubcontractorData", subcontractorData);
            SqlParameter miscDataParameter = new SqlParameter("MiscData", miscData);
            SqlParameter revenueIncludedParameter = new SqlParameter("RevenueIncluded", revenueIncluded);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter monthParameter = (month.HasValue) ? new SqlParameter("Month", month.Value) : new SqlParameter("Month", DBNull.Value);
            SqlParameter dayParameter = (day.HasValue) ? new SqlParameter("Day", day.Value) : new SqlParameter("Day", DBNull.Value);
            SqlParameter yearParameter = (year.HasValue) ? new SqlParameter("Year", year.Value) : new SqlParameter("Year", DBNull.Value);
            SqlParameter month2Parameter = (month2.HasValue) ? new SqlParameter("Month2", month2.Value) : new SqlParameter("Month2", DBNull.Value);
            SqlParameter day2Parameter = (day2.HasValue) ? new SqlParameter("Day2", day2.Value) : new SqlParameter("Day2", DBNull.Value);
            SqlParameter year2Parameter = (year2.HasValue) ? new SqlParameter("Year2", year2.Value) : new SqlParameter("Year2", DBNull.Value);
            
            string command = "INSERT INTO [dbo].[LFS_PROJECT_COSTING_SHEET_TEMPLATE] ([Name], [RAData], [FLLData], [PRData], [JLData], [MRData], [MOBData], [OtherData], [LabourHourData], [UnitData], [MaterialData], [SubcontractorData], [MiscData], [RevenueIncluded], [Deleted], [COMPANY_ID], [Month], [Day], [Year], [Month2], [Day2], [Year2]) " +
                             " VALUES (@Name, @RAData, @FLLData, @PRData, @JLData, @MRData, @MOBData, @OtherData, @LabourHourData, @UnitData, @MaterialData, @SubcontractorData, @MiscData, @RevenueIncluded, @Deleted, @COMPANY_ID, @Month, @Day, @Year, @Month2, @Day2, @Year2); SELECT CostingSheetTemplateID FROM LFS_PROJECT_COSTING_SHEET_TEMPLATE WHERE (CostingSheetTemplateID = SCOPE_IDENTITY())";
            
            int costingSheetTemplateId = (int)ExecuteScalar(command, nameParameter, raDataParameter, fllDataParameter, prDataParameter, jlDataParameter, mrDataParameter, mobDataParameter, otherDataParameter, labourHourDataParameter, unitDataParameter, materialDataParameter, subcontractorDataParameter, miscDataParameter, revenueIncludedParameter, deletedParameter, companyIdParameter, monthParameter, dayParameter, yearParameter, month2Parameter, day2Parameter, year2Parameter);

            return costingSheetTemplateId;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="refIDRevenue">refIDRevenue</param>
        /// <param name="refId">refId</param>
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
        /// <param name="originalFunction_">originalFunction_</param>
        /// 
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
        /// <param name="newFunction_">newFunction_</param>
        public void Update(int costingSheetTemplateId, string originalName, bool originalRaData, bool originalFllData, bool originalPrData, bool originalJlData, bool originalMrData, bool originalMobData, bool originalOtherData, bool originalLabourHourData, bool originalUnitData, bool originalMaterialData, bool originalSubcontractorData, bool originalMiscData, bool originalRevenueIncluded, bool originalDeleted, int originalCompanyId, int? originalMonth, int? originalDay, int? originalYear, int? originalMonth2, int? originalDay2, int? originalYear2, string newName, bool newRaData, bool newFllData, bool newPrData, bool newJlData, bool newMrData, bool newMobData, bool newOtherData, bool newLabourHourData, bool newUnitData, bool newMaterialData, bool newSubcontractorData, bool newMiscData, bool newRevenueIncluded, bool newDeleted, int newCompanyId, int? newMonth, int? newDay, int? newYear, int? newMonth2, int? newDay2, int? newYear2)
        {
            SqlParameter originalcostingSheetTemplateIdParameter = new SqlParameter("Original_CostingSheetTemplateID", costingSheetTemplateId);
            SqlParameter originalNameParameter = new SqlParameter("Original_Name", originalName);
            SqlParameter originalRaDataParameter = new SqlParameter("Original_RAData", originalRaData);
            SqlParameter originalFllDataParameter = new SqlParameter("Original_FLLData", originalFllData);
            SqlParameter originalPrDataParameter = new SqlParameter("Original_PRData", originalPrData);
            SqlParameter originalJlDataParameter = new SqlParameter("Original_JLData", originalJlData);
            SqlParameter originalMrDataParameter = new SqlParameter("Original_MRData", originalMrData);
            SqlParameter originalMobDataParameter = new SqlParameter("Original_MOBData", originalMobData);
            SqlParameter originalOtherDataParameter = new SqlParameter("Original_OtherData", originalOtherData);
            SqlParameter originalLabourHourDataParameter = new SqlParameter("Original_LabourHourData", originalLabourHourData);
            SqlParameter originalUnitDataParameter = new SqlParameter("Original_UnitData", originalUnitData);
            SqlParameter originalMaterialDataParameter = new SqlParameter("Original_MaterialData", originalMaterialData);
            SqlParameter originalSubcontractorDataParameter = new SqlParameter("Original_SubcontractorData", originalSubcontractorData);
            SqlParameter originalMiscDataParameter = new SqlParameter("Original_MiscData", originalMiscData);
            SqlParameter originalRevenueIncludedParameter = new SqlParameter("Original_RevenueIncluded", originalRevenueIncluded);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalMonthParameter = (originalMonth.HasValue) ? new SqlParameter("Original_Month", originalMonth.Value) : new SqlParameter("Original_Month", DBNull.Value);
            SqlParameter originalDayParameter = (originalDay.HasValue) ? new SqlParameter("Original_Day", originalMonth.Value) : new SqlParameter("Original_Day", DBNull.Value);
            SqlParameter originalYearParameter = (originalYear.HasValue) ? new SqlParameter("Original_Year", originalMonth.Value) : new SqlParameter("Original_Year", DBNull.Value);
            SqlParameter originalMonth2Parameter = (originalMonth2.HasValue) ? new SqlParameter("Original_Month2", originalMonth.Value) : new SqlParameter("Original_Month2", DBNull.Value);
            SqlParameter originalDay2Parameter = (originalDay2.HasValue) ? new SqlParameter("Original_Day2", originalMonth.Value) : new SqlParameter("Original_Day2", DBNull.Value);
            SqlParameter originalYear2Parameter = (originalYear2.HasValue) ? new SqlParameter("Original_Year2", originalMonth.Value) : new SqlParameter("Original_Year2", DBNull.Value);

            SqlParameter newcostingSheetTemplateIdParameter = new SqlParameter("CostingSheetTemplateID", costingSheetTemplateId);
            SqlParameter newNameParameter = new SqlParameter("Name", newName);
            SqlParameter newRaDataParameter = new SqlParameter("RAData", newRaData);
            SqlParameter newFllDataParameter = new SqlParameter("FLLData", newFllData);
            SqlParameter newPrDataParameter = new SqlParameter("PRData", newPrData);
            SqlParameter newJlDataParameter = new SqlParameter("JLData", newJlData);
            SqlParameter newMrDataParameter = new SqlParameter("MRData", newMrData);
            SqlParameter newMobDataParameter = new SqlParameter("MOBData", newMobData);
            SqlParameter newOtherDataParameter = new SqlParameter("OtherData", newOtherData);
            SqlParameter newLabourHourDataParameter = new SqlParameter("LabourHourData", newLabourHourData);
            SqlParameter newUnitDataParameter = new SqlParameter("UnitData", newUnitData);
            SqlParameter newMaterialDataParameter = new SqlParameter("MaterialData", newMaterialData);
            SqlParameter newSubcontractorDataParameter = new SqlParameter("SubcontractorData", newSubcontractorData);
            SqlParameter newMiscDataParameter = new SqlParameter("MiscData", newMiscData);
            SqlParameter newRevenueIncludedParameter = new SqlParameter("RevenueIncluded", newRevenueIncluded);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newMonthParameter = (newMonth.HasValue) ? new SqlParameter("Month", newMonth.Value) : new SqlParameter("Month", DBNull.Value);
            SqlParameter newDayParameter = (newDay.HasValue) ? new SqlParameter("Day", newDay.Value) : new SqlParameter("Day", DBNull.Value);
            SqlParameter newYearParameter = (newYear.HasValue) ? new SqlParameter("Year", newYear.Value) : new SqlParameter("Year", DBNull.Value);
            SqlParameter newMonth2Parameter = (newMonth2.HasValue) ? new SqlParameter("Month2", newMonth2.Value) : new SqlParameter("Month2", DBNull.Value);
            SqlParameter newDay2Parameter = (newDay2.HasValue) ? new SqlParameter("Day2", newDay2.Value) : new SqlParameter("Day2", DBNull.Value);
            SqlParameter newYear2Parameter = (newYear2.HasValue) ? new SqlParameter("Year2", newYear2.Value) : new SqlParameter("Year2", DBNull.Value);

            string command = "UPDATE [dbo].[LFS_PROJECT_COSTING_SHEET_TEMPLATE] SET [Name] = @Name, [RAData] = @RAData, [FLLData] = @FLLData, [PRData] = @PRData, [JLData] = @JLData, [MRData] = @MRData, [MOBData] = @MOBData, [OtherData] = @OtherData, [LabourHourData] = @LabourHourData, [UnitData] = @UnitData, [MaterialData] = @MaterialData, [SubcontractorData] = @SubcontractorData, [MiscData] = @MiscData, [RevenueIncluded] = @RevenueIncluded, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [Month] = @Month, [Day] = @Day, [Year] = @Year, [Month2] = @Month2, [Day2] = @Day2, [Year2] = @Year2 " +
                " WHERE (" +
                " ([CostingSheetTemplateID] = @Original_CostingSheetTemplateID) AND ([COMPANY_ID] = @Original_COMPANY_ID) " +
                " )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalcostingSheetTemplateIdParameter, originalNameParameter, originalRaDataParameter, originalFllDataParameter, originalPrDataParameter, originalJlDataParameter, originalMrDataParameter, originalMobDataParameter, originalOtherDataParameter, originalLabourHourDataParameter, originalUnitDataParameter, originalMaterialDataParameter, originalSubcontractorDataParameter, originalMiscDataParameter, originalRevenueIncludedParameter, originalDeletedParameter, originalCompanyIdParameter, originalMonthParameter, originalDayParameter, originalYearParameter,  originalMonth2Parameter, originalDay2Parameter, originalYear2Parameter, newcostingSheetTemplateIdParameter, newNameParameter, newRaDataParameter, newFllDataParameter, newPrDataParameter, newJlDataParameter, newMrDataParameter, newMobDataParameter, newOtherDataParameter, newLabourHourDataParameter, newUnitDataParameter, newMaterialDataParameter, newSubcontractorDataParameter, newMiscDataParameter, newRevenueIncludedParameter, newDeletedParameter, newCompanyIdParameter, newMonthParameter, newDayParameter, newYearParameter, newMonth2Parameter, newDay2Parameter, newYear2Parameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// Delete a template Costing Sheet
        /// </summary>
        /// <param name="originalCostingSheetId">originalCostingSheetId</param>
        /// <param name="originalWork_">originalWork_</param>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalCostingSheetTemplateId, int originalCompanyId)
        {
            SqlParameter originalcostingSheetTemplateIdParameter = new SqlParameter("Original_CostingSheetTemplateID", originalCostingSheetTemplateId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_PROJECT_COSTING_SHEET_TEMPLATE] SET  [Deleted] = @Deleted " +
                            " WHERE (" +
                            " ([CostingSheetTemplateID] = @Original_CostingSheetTemplateID) AND ([COMPANY_ID] = @Original_COMPANY_ID) " +
                            " )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalcostingSheetTemplateIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}