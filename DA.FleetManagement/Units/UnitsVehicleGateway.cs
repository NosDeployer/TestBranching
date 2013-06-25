using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Units
{
    /// <summary>
    /// UnitsVehicleGateway
    /// </summary>
    public class UnitsVehicleGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsVehicleGateway()
            : base("LFS_FM_UNIT_VEHICLE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsVehicleGateway(DataSet data)
            : base(data, "LFS_FM_UNIT_VEHICLE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsTDS();
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
            tableMapping.DataSetTable = "LFS_FM_UNIT_VEHICLE";
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("LicenseCountry", "LicenseCountry");
            tableMapping.ColumnMappings.Add("LicenseState", "LicenseState");
            tableMapping.ColumnMappings.Add("LicensePlateNumbver", "LicensePlateNumbver");
            tableMapping.ColumnMappings.Add("AportionedTagNumber", "AportionedTagNumber");
            tableMapping.ColumnMappings.Add("ActualWeight", "ActualWeight");
            tableMapping.ColumnMappings.Add("RegisteredWeight", "RegisteredWeight");
            tableMapping.ColumnMappings.Add("TireSizeFront", "TireSizeFront");
            tableMapping.ColumnMappings.Add("TireSizeBack", "TireSizeBack");
            tableMapping.ColumnMappings.Add("NumberOfAxes", "NumberOfAxes");
            tableMapping.ColumnMappings.Add("FuelType", "FuelType");
            tableMapping.ColumnMappings.Add("BeginningOdometer", "BeginningOdometer");
            tableMapping.ColumnMappings.Add("IsReeferEquipped", "IsReeferEquipped");
            tableMapping.ColumnMappings.Add("IsPTOEquipped", "IsPTOEquipped");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_FM_UNIT_VEHICLE] WHERE (([UnitID] = @Original_UnitID) AND ((@IsNull_LicenseCountry = 1 AND [LicenseCountry] IS NULL) OR ([LicenseCountry] = @Original_LicenseCountry)) AND ((@IsNull_LicenseState = 1 AND [LicenseState] IS NULL) OR ([LicenseState] = @Original_LicenseState)) AND ((@IsNull_LicensePlateNumbver = 1 AND [LicensePlateNumbver] IS NULL) OR ([LicensePlateNumbver] = @Original_LicensePlateNumbver)) AND ((@IsNull_AportionedTagNumber = 1 AND [AportionedTagNumber] IS NULL) OR ([AportionedTagNumber] = @Original_AportionedTagNumber)) AND ((@IsNull_ActualWeight = 1 AND [ActualWeight] IS NULL) OR ([ActualWeight] = @Original_ActualWeight)) AND ((@IsNull_RegisteredWeight = 1 AND [RegisteredWeight] IS NULL) OR ([RegisteredWeight] = @Original_RegisteredWeight)) AND ((@IsNull_TireSizeFront = 1 AND [TireSizeFront] IS NULL) OR ([TireSizeFront] = @Original_TireSizeFront)) AND ((@IsNull_TireSizeBack = 1 AND [TireSizeBack] IS NULL) OR ([TireSizeBack] = @Original_TireSizeBack)) AND ((@IsNull_NumberOfAxes = 1 AND [NumberOfAxes] IS NULL) OR ([NumberOfAxes] = @Original_NumberOfAxes)) AND ((@IsNull_FuelType = 1 AND [FuelType] IS NULL) OR ([FuelType] = @Original_FuelType)) AND ((@IsNull_BeginningOdometer = 1 AND [BeginningOdometer] IS NULL) OR ([BeginningOdometer] = @Original_BeginningOdometer)) AND ([IsReeferEquipped] = @Original_IsReeferEquipped) AND ([IsPTOEquipped] = @Original_IsPTOEquipped) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LicenseCountry", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicenseCountry", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LicenseCountry", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicenseCountry", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LicenseState", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicenseState", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LicenseState", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicenseState", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LicensePlateNumbver", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicensePlateNumbver", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LicensePlateNumbver", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicensePlateNumbver", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AportionedTagNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AportionedTagNumber", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AportionedTagNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AportionedTagNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ActualWeight", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ActualWeight", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ActualWeight", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ActualWeight", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RegisteredWeight", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RegisteredWeight", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RegisteredWeight", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RegisteredWeight", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TireSizeFront", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TireSizeFront", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TireSizeFront", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TireSizeFront", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TireSizeBack", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TireSizeBack", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TireSizeBack", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TireSizeBack", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_NumberOfAxes", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NumberOfAxes", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NumberOfAxes", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NumberOfAxes", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_FuelType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FuelType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FuelType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FuelType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BeginningOdometer", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BeginningOdometer", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BeginningOdometer", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BeginningOdometer", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IsReeferEquipped", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsReeferEquipped", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IsPTOEquipped", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsPTOEquipped", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_UNIT_VEHICLE] ([UnitID], [LicenseCountry], [LicenseState], [LicensePlateNumbver], [AportionedTagNumber], [ActualWeight], [RegisteredWeight], [TireSizeFront], [TireSizeBack], [NumberOfAxes], [FuelType], [BeginningOdometer], [IsReeferEquipped], [IsPTOEquipped], [Deleted], [COMPANY_ID]) VALUES (@UnitID, @LicenseCountry, @LicenseState, @LicensePlateNumbver, @AportionedTagNumber, @ActualWeight, @RegisteredWeight, @TireSizeFront, @TireSizeBack, @NumberOfAxes, @FuelType, @BeginningOdometer, @IsReeferEquipped, @IsPTOEquipped, @Deleted, @COMPANY_ID);
SELECT UnitID, LicenseCountry, LicenseState, LicensePlateNumbver, AportionedTagNumber, ActualWeight, RegisteredWeight, TireSizeFront, TireSizeBack, NumberOfAxes, FuelType, BeginningOdometer, IsReeferEquipped, IsPTOEquipped, Deleted, COMPANY_ID FROM LFS_FM_UNIT_VEHICLE WHERE (UnitID = @UnitID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LicenseCountry", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicenseCountry", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LicenseState", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicenseState", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LicensePlateNumbver", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicensePlateNumbver", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AportionedTagNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AportionedTagNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ActualWeight", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ActualWeight", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RegisteredWeight", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RegisteredWeight", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TireSizeFront", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TireSizeFront", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TireSizeBack", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TireSizeBack", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NumberOfAxes", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NumberOfAxes", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FuelType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FuelType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BeginningOdometer", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BeginningOdometer", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsReeferEquipped", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsReeferEquipped", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsPTOEquipped", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsPTOEquipped", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_FM_UNIT_VEHICLE] SET [UnitID] = @UnitID, [LicenseCountry] = @Li" +
                "censeCountry, [LicenseState] = @LicenseState, [LicensePlateNumbver] = @LicensePl" +
                "ateNumbver, [AportionedTagNumber] = @AportionedTagNumber, [ActualWeight] = @Actu" +
                "alWeight, [RegisteredWeight] = @RegisteredWeight, [TireSizeFront] = @TireSizeFro" +
                "nt, [TireSizeBack] = @TireSizeBack, [NumberOfAxes] = @NumberOfAxes, [FuelType] =" +
                " @FuelType, [BeginningOdometer] = @BeginningOdometer, [IsReeferEquipped] = @IsRe" +
                "eferEquipped, [IsPTOEquipped] = @IsPTOEquipped, [Deleted] = @Deleted, [COMPANY_I" +
                "D] = @COMPANY_ID WHERE (([UnitID] = @Original_UnitID) AND ((@IsNull_LicenseCount" +
                "ry = 1 AND [LicenseCountry] IS NULL) OR ([LicenseCountry] = @Original_LicenseCou" +
                "ntry)) AND ((@IsNull_LicenseState = 1 AND [LicenseState] IS NULL) OR ([LicenseSt" +
                "ate] = @Original_LicenseState)) AND ((@IsNull_LicensePlateNumbver = 1 AND [Licen" +
                "sePlateNumbver] IS NULL) OR ([LicensePlateNumbver] = @Original_LicensePlateNumbv" +
                "er)) AND ((@IsNull_AportionedTagNumber = 1 AND [AportionedTagNumber] IS NULL) OR" +
                " ([AportionedTagNumber] = @Original_AportionedTagNumber)) AND ((@IsNull_ActualWe" +
                "ight = 1 AND [ActualWeight] IS NULL) OR ([ActualWeight] = @Original_ActualWeight" +
                ")) AND ((@IsNull_RegisteredWeight = 1 AND [RegisteredWeight] IS NULL) OR ([Regis" +
                "teredWeight] = @Original_RegisteredWeight)) AND ((@IsNull_TireSizeFront = 1 AND " +
                "[TireSizeFront] IS NULL) OR ([TireSizeFront] = @Original_TireSizeFront)) AND ((@" +
                "IsNull_TireSizeBack = 1 AND [TireSizeBack] IS NULL) OR ([TireSizeBack] = @Origin" +
                "al_TireSizeBack)) AND ((@IsNull_NumberOfAxes = 1 AND [NumberOfAxes] IS NULL) OR " +
                "([NumberOfAxes] = @Original_NumberOfAxes)) AND ((@IsNull_FuelType = 1 AND [FuelT" +
                "ype] IS NULL) OR ([FuelType] = @Original_FuelType)) AND ((@IsNull_BeginningOdome" +
                "ter = 1 AND [BeginningOdometer] IS NULL) OR ([BeginningOdometer] = @Original_Beg" +
                "inningOdometer)) AND ([IsReeferEquipped] = @Original_IsReeferEquipped) AND ([IsP" +
                "TOEquipped] = @Original_IsPTOEquipped) AND ([Deleted] = @Original_Deleted) AND (" +
                "[COMPANY_ID] = @Original_COMPANY_ID));\r\nSELECT UnitID, LicenseCountry, LicenseSt" +
                "ate, LicensePlateNumbver, AportionedTagNumber, ActualWeight, RegisteredWeight, T" +
                "ireSizeFront, TireSizeBack, NumberOfAxes, FuelType, BeginningOdometer, IsReeferE" +
                "quipped, IsPTOEquipped, Deleted, COMPANY_ID FROM LFS_FM_UNIT_VEHICLE WHERE (Unit" +
                "ID = @UnitID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LicenseCountry", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicenseCountry", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LicenseState", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicenseState", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LicensePlateNumbver", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicensePlateNumbver", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AportionedTagNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AportionedTagNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ActualWeight", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ActualWeight", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RegisteredWeight", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RegisteredWeight", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TireSizeFront", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TireSizeFront", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TireSizeBack", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TireSizeBack", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NumberOfAxes", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NumberOfAxes", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FuelType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FuelType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BeginningOdometer", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BeginningOdometer", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsReeferEquipped", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsReeferEquipped", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsPTOEquipped", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsPTOEquipped", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LicenseCountry", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicenseCountry", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LicenseCountry", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicenseCountry", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LicenseState", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicenseState", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LicenseState", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicenseState", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LicensePlateNumbver", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicensePlateNumbver", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LicensePlateNumbver", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LicensePlateNumbver", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AportionedTagNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AportionedTagNumber", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AportionedTagNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AportionedTagNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ActualWeight", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ActualWeight", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ActualWeight", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ActualWeight", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RegisteredWeight", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RegisteredWeight", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RegisteredWeight", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RegisteredWeight", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TireSizeFront", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TireSizeFront", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TireSizeFront", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TireSizeFront", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TireSizeBack", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TireSizeBack", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TireSizeBack", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TireSizeBack", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_NumberOfAxes", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NumberOfAxes", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NumberOfAxes", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NumberOfAxes", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_FuelType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FuelType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FuelType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FuelType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BeginningOdometer", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BeginningOdometer", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BeginningOdometer", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BeginningOdometer", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IsReeferEquipped", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsReeferEquipped", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IsPTOEquipped", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsPTOEquipped", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }





                       
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="licenseCountry">licenseCountry</param>
        /// <param name="licenseState">licenseState</param>
        /// <param name="licensePlateNumbver">licensePlateNumbver</param>
        /// <param name="aportionedTagNumber">aportionedTagNumber</param>
        /// <param name="actualWeight">actualWeight</param>
        /// <param name="registeredWeight">registeredWeight</param>
        /// <param name="tireSizeFront">tireSizeFront</param>
        /// <param name="tireSizeBack">tireSizeBack</param>
        /// <param name="numberOfAxes">numberOfAxes</param>
        /// <param name="fuelType">fuelType</param>
        /// <param name="beginningOdometer">beginningOdometer</param>
        /// <param name="isReeferEquipped">isReeferEquipped</param>
        /// <param name="isPTOEquipped">isPTOEquipped</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int unitId, Int64? licenseCountry, Int64? licenseState, string licensePlateNumbver, string aportionedTagNumber, string actualWeight, string registeredWeight, string tireSizeFront, string tireSizeBack, string numberOfAxes, string fuelType, string beginningOdometer, bool isReeferEquipped, bool isPTOEquipped, bool deleted, int companyId)
        {
            SqlParameter unitIdParameter = new SqlParameter("UnitID", unitId);
            SqlParameter licenseCountryParameter = (licenseCountry.HasValue) ? new SqlParameter("LicenseCountry", (Int64)licenseCountry) : new SqlParameter("LicenseCountry", DBNull.Value);
            SqlParameter licenseStateParameter = (licenseState.HasValue) ? new SqlParameter("LicenseState", (Int64)licenseState) : new SqlParameter("LicenseState", DBNull.Value);
            SqlParameter licensePlateNumbverParameter = (licensePlateNumbver != "") ? new SqlParameter("LicensePlateNumbver", licensePlateNumbver) : new SqlParameter("LicensePlateNumbver", DBNull.Value);
            SqlParameter aportionedTagNumberParameter = (aportionedTagNumber != "") ? new SqlParameter("AportionedTagNumber", aportionedTagNumber) : new SqlParameter("AportionedTagNumber", DBNull.Value);
            SqlParameter actualWeightParameter = (actualWeight != "") ? new SqlParameter("ActualWeight", actualWeight) : new SqlParameter("ActualWeight", DBNull.Value);
            SqlParameter registeredWeightParameter = (registeredWeight != "") ? new SqlParameter("RegisteredWeight", registeredWeight) : new SqlParameter("RegisteredWeight", DBNull.Value);
            SqlParameter tireSizeFrontParameter = (tireSizeFront != "") ? new SqlParameter("TireSizeFront", tireSizeFront) : new SqlParameter("TireSizeFront", DBNull.Value);
            SqlParameter tireSizeBackParameter = (tireSizeBack != "") ? new SqlParameter("TireSizeBack", tireSizeBack) : new SqlParameter("TireSizeBack", DBNull.Value);
            SqlParameter numberOfAxesParameter = (numberOfAxes != "") ? new SqlParameter("NumberOfAxes", numberOfAxes) : new SqlParameter("NumberOfAxes", DBNull.Value);
            SqlParameter fuelTypeParameter = (fuelType != "") ? new SqlParameter("FuelType", fuelType) : new SqlParameter("FuelType", DBNull.Value);
            SqlParameter beginningOdometerParameter = (beginningOdometer != "") ? new SqlParameter("BeginningOdometer", beginningOdometer) : new SqlParameter("BeginningOdometer", DBNull.Value);
            SqlParameter isReeferEquippedParameter = new SqlParameter("IsReeferEquipped", isReeferEquipped);
            SqlParameter isPTOEquippedParameter = new SqlParameter("IsPTOEquipped", isPTOEquipped); 
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
                        
            string command = "INSERT INTO [dbo].[LFS_FM_UNIT_VEHICLE] ([UnitID], [LicenseCountry], [LicenseState], [LicensePlateNumbver], [AportionedTagNumber], [ActualWeight], [RegisteredWeight], [TireSizeFront], [TireSizeBack], [NumberOfAxes], [FuelType], [BeginningOdometer], [IsReeferEquipped], [IsPTOEquipped], [Deleted], [COMPANY_ID]) VALUES (@UnitID, @LicenseCountry, @LicenseState, @LicensePlateNumbver, @AportionedTagNumber, @ActualWeight, @RegisteredWeight, @TireSizeFront, @TireSizeBack, @NumberOfAxes, @FuelType, @BeginningOdometer, @IsReeferEquipped, @IsPTOEquipped, @Deleted, @COMPANY_ID)";

            ExecuteScalar(command, unitIdParameter, licenseCountryParameter, licenseStateParameter, licensePlateNumbverParameter, aportionedTagNumberParameter, actualWeightParameter, registeredWeightParameter, tireSizeFrontParameter, tireSizeBackParameter, numberOfAxesParameter, fuelTypeParameter, beginningOdometerParameter, isReeferEquippedParameter, isPTOEquippedParameter, deletedParameter, companyIdParameter);            
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalLicenseCountry">originalLicenseCountry</param>
        /// <param name="originalLicenseState">originalLicenseState</param>
        /// <param name="originalLicensePlateNumbver">originalLicensePlateNumbver</param>
        /// <param name="originalAportionedTagNumber">originalAportionedTagNumber</param>
        /// <param name="originalActualWeight">originalActualWeight</param>
        /// <param name="originalRegisteredWeight">originalRegisteredWeight</param>
        /// <param name="originalTireSizeFront">originalTireSizeFront</param>
        /// <param name="originalTireSizeBack">originalTireSizeBack</param>
        /// <param name="originalNumberOfAxes">originalNumberOfAxes</param>
        /// <param name="originalFuelType">originalFuelType</param>
        /// <param name="originalBeginningOdometer">originalBeginningOdometer</param>
        /// <param name="originalIsReeferEquipped">originalIsReeferEquipped</param>
        /// <param name="originalIsPTOEquipped">originalIsPTOEquipped</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newUnitId">newUnitId</param>
        /// <param name="newLicenseCountry">newLicenseCountry</param>
        /// <param name="newLicenseState">newLicenseState</param>
        /// <param name="newLicensePlateNumbver">newLicensePlateNumbver</param>
        /// <param name="newAportionedTagNumber">newAportionedTagNumber</param>
        /// <param name="newActualWeight">newActualWeight</param>
        /// <param name="newTireSizeFront">newTireSizeFront</param>
        /// <param name="newTireSizeBack">newTireSizeBack</param>
        /// <param name="newNumberOfAxes">newNumberOfAxes</param>
        /// <param name="newFuelType">newFuelType</param>
        /// <param name="newBeginningOdometer">newBeginningOdometer</param>
        /// <param name="newIsReeferEquipped">newIsReeferEquipped</param>
        /// <param name="newIsPTOEquipped">newIsPTOEquipped</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void Update(int originalUnitId, Int64? originalLicenseCountry, Int64? originalLicenseState, string originalLicensePlateNumbver, string originalAportionedTagNumber, string originalActualWeight, string originalRegisteredWeight, string originalTireSizeFront, string originalTireSizeBack, string originalNumberOfAxes, string originalFuelType, string originalBeginningOdometer, bool originalIsReeferEquipped, bool originalIsPTOEquipped, bool originalDeleted, int originalCompanyId, int newUnitId, Int64? newLicenseCountry, Int64? newLicenseState, string newLicensePlateNumbver, string newAportionedTagNumber, string newActualWeight, string newRegisteredWeight, string newTireSizeFront, string newTireSizeBack, string newNumberOfAxes, string newFuelType, string newBeginningOdometer, bool newIsReeferEquipped, bool newIsPTOEquipped, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalUnitIdParameter = new SqlParameter("Original_UnitID", originalUnitId);
            SqlParameter originalLicenseCountryParameter = (originalLicenseCountry.HasValue) ? new SqlParameter("Original_LicenseCountry", (Int64)originalLicenseCountry) : new SqlParameter("Original_LicenseCountry", DBNull.Value);
            SqlParameter originalLicenseStateParameter = (originalLicenseState.HasValue) ? new SqlParameter("Original_LicenseState", (Int64)originalLicenseState) : new SqlParameter("Original_LicenseState", DBNull.Value);
            SqlParameter originalLicensePlateNumbverParameter = (originalLicensePlateNumbver != "") ? new SqlParameter("Original_LicensePlateNumbver", originalLicensePlateNumbver) : new SqlParameter("Original_LicensePlateNumbver", DBNull.Value);
            SqlParameter originalAportionedTagNumberParameter = (originalAportionedTagNumber != "") ? new SqlParameter("Original_AportionedTagNumber", originalAportionedTagNumber) : new SqlParameter("Original_AportionedTagNumber", DBNull.Value);
            SqlParameter originalActualWeightParameter = (originalActualWeight != "") ? new SqlParameter("Original_ActualWeight", originalActualWeight) : new SqlParameter("Original_ActualWeight", DBNull.Value);
            SqlParameter originalRegisteredWeightParameter = (originalRegisteredWeight != "") ? new SqlParameter("Original_RegisteredWeight", originalRegisteredWeight) : new SqlParameter("Original_RegisteredWeight", DBNull.Value);
            SqlParameter originalTireSizeFrontParameter = (originalTireSizeFront != "") ? new SqlParameter("Original_TireSizeFront", originalTireSizeFront) : new SqlParameter("Original_TireSizeFront", DBNull.Value);
            SqlParameter originalTireSizeBackParameter = (originalTireSizeBack != "") ? new SqlParameter("Original_TireSizeBack", originalTireSizeBack) : new SqlParameter("Original_TireSizeBack", DBNull.Value);
            SqlParameter originalNumberOfAxesParameter = (originalNumberOfAxes != "") ? new SqlParameter("Original_NumberOfAxes", originalNumberOfAxes) : new SqlParameter("Original_NumberOfAxes", DBNull.Value);
            SqlParameter originalFuelTypeParameter = (originalFuelType != "") ? new SqlParameter("Original_FuelType", originalFuelType) : new SqlParameter("Original_FuelType", DBNull.Value);
            SqlParameter originalBeginningOdometerParameter = (originalBeginningOdometer != "") ? new SqlParameter("Original_BeginningOdometer", originalBeginningOdometer) : new SqlParameter("Original_BeginningOdometer", DBNull.Value);
            SqlParameter originalIsReeferEquippedParameter = new SqlParameter("Original_IsReeferEquipped", originalIsReeferEquipped);
            SqlParameter originalIsPTOEquippedParameter = new SqlParameter("Original_IsPTOEquipped", originalIsPTOEquipped);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newUnitIdParameter = new SqlParameter("UnitID", newUnitId);
            SqlParameter newLicenseCountryParameter = (newLicenseCountry.HasValue) ? new SqlParameter("LicenseCountry", (Int64)newLicenseCountry) : new SqlParameter("LicenseCountry", DBNull.Value);
            SqlParameter newLicenseStateParameter = (newLicenseState.HasValue) ? new SqlParameter("LicenseState", (Int64)newLicenseState) : new SqlParameter("LicenseState", DBNull.Value);
            SqlParameter newLicensePlateNumbverParameter = (newLicensePlateNumbver != "") ? new SqlParameter("LicensePlateNumbver", newLicensePlateNumbver) : new SqlParameter("LicensePlateNumbver", DBNull.Value);
            SqlParameter newAportionedTagNumberParameter = (newAportionedTagNumber != "") ? new SqlParameter("AportionedTagNumber", newAportionedTagNumber) : new SqlParameter("AportionedTagNumber", DBNull.Value);
            SqlParameter newActualWeightParameter = (newActualWeight != "") ? new SqlParameter("ActualWeight", newActualWeight) : new SqlParameter("ActualWeight", DBNull.Value);
            SqlParameter newRegisteredWeightParameter = (newRegisteredWeight != "") ? new SqlParameter("RegisteredWeight", newRegisteredWeight) : new SqlParameter("RegisteredWeight", DBNull.Value);
            SqlParameter newTireSizeFrontParameter = (newTireSizeFront != "") ? new SqlParameter("TireSizeFront", newTireSizeFront) : new SqlParameter("TireSizeFront", DBNull.Value);
            SqlParameter newTireSizeBackParameter = (newTireSizeBack != "") ? new SqlParameter("TireSizeBack", newTireSizeBack) : new SqlParameter("TireSizeBack", DBNull.Value);
            SqlParameter newNumberOfAxesParameter = (newNumberOfAxes != "") ? new SqlParameter("NumberOfAxes", newNumberOfAxes) : new SqlParameter("NumberOfAxes", DBNull.Value);
            SqlParameter newFuelTypeParameter = (newFuelType != "") ? new SqlParameter("FuelType", newFuelType) : new SqlParameter("FuelType", DBNull.Value);
            SqlParameter newBeginningOdometerParameter = (newBeginningOdometer != "") ? new SqlParameter("BeginningOdometer", newBeginningOdometer) : new SqlParameter("BeginningOdometer", DBNull.Value);
            SqlParameter newIsReeferEquippedParameter = new SqlParameter("IsReeferEquipped", newIsReeferEquipped);
            SqlParameter newIsPTOEquippedParameter = new SqlParameter("IsPTOEquipped", newIsPTOEquipped);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_FM_UNIT_VEHICLE] SET [UnitID] = @UnitID, [LicenseCountry] = @LicenseCountry, " +
                "[LicenseState] = @LicenseState, [LicensePlateNumbver] = @LicensePlateNumbver, [AportionedTagNumber] = @AportionedTagNumber, " + 
                "[ActualWeight] = @ActualWeight, [RegisteredWeight] = @RegisteredWeight, [TireSizeFront] = @TireSizeFront, " +
                "[TireSizeBack] = @TireSizeBack, [NumberOfAxes] = @NumberOfAxes, [FuelType] = @FuelType, [BeginningOdometer] = @BeginningOdometer, " +
                "[IsReeferEquipped] = @IsReeferEquipped, [IsPTOEquipped] = @IsPTOEquipped, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID " +
                "WHERE (" +
                "([UnitID] = @Original_UnitID) AND ([Deleted] = @Original_Deleted) AND " +
                " ([COMPANY_ID] = @Original_COMPANY_ID)" +
                " )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalUnitIdParameter, originalLicenseCountryParameter, originalLicenseStateParameter, originalLicensePlateNumbverParameter, originalAportionedTagNumberParameter, originalActualWeightParameter, originalRegisteredWeightParameter, originalTireSizeFrontParameter, originalTireSizeBackParameter, originalNumberOfAxesParameter, originalFuelTypeParameter, originalBeginningOdometerParameter, originalIsReeferEquippedParameter, originalIsPTOEquippedParameter, originalDeletedParameter, originalCompanyIdParameter, newUnitIdParameter, newLicenseCountryParameter, newLicenseStateParameter, newLicensePlateNumbverParameter, newAportionedTagNumberParameter, newActualWeightParameter, newRegisteredWeightParameter, newTireSizeFrontParameter, newTireSizeBackParameter, newNumberOfAxesParameter, newFuelTypeParameter, newBeginningOdometerParameter, newIsReeferEquippedParameter, newIsPTOEquippedParameter, newDeletedParameter, newCompanyIdParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// delete
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int unitId, int companyId)
        {
            SqlParameter unitIdParameter = new SqlParameter("UnitID", unitId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_UNIT_VEHICLE] SET  [Deleted] = @Deleted WHERE (([UnitID] = @UnitID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, unitIdParameter, companyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }        

       
 
    }
}




