using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningWetOutGateway
    /// </summary>
    public class WorkFullLengthLiningWetOutGateway: DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningWetOutGateway()
            : base("LFS_WORK_FULLLENGTHLINING_WETOUT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningWetOutGateway(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_WETOUT")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WorkTDS();
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
            tableMapping.DataSetTable = "LFS_WORK_FULLLENGTHLINING_WETOUT";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("LinerTube", "LinerTube");
            tableMapping.ColumnMappings.Add("ResinID", "ResinID");
            tableMapping.ColumnMappings.Add("ExcessResin", "ExcessResin");
            tableMapping.ColumnMappings.Add("PoundsDrums", "PoundsDrums");
            tableMapping.ColumnMappings.Add("DrumDiameter", "DrumDiameter");
            tableMapping.ColumnMappings.Add("HoistMaximumHeight", "HoistMaximumHeight");
            tableMapping.ColumnMappings.Add("HoistMinimumHeight", "HoistMinimumHeight");
            tableMapping.ColumnMappings.Add("DownDropTubeLenght", "DownDropTubeLenght");
            tableMapping.ColumnMappings.Add("PumpHeightAboveGround", "PumpHeightAboveGround");
            tableMapping.ColumnMappings.Add("TubeResinToFeltFactor", "TubeResinToFeltFactor");
            tableMapping.ColumnMappings.Add("DateOfSheet", "DateOfSheet");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("RunDetails", "RunDetails");
            tableMapping.ColumnMappings.Add("RunDetails2", "RunDetails2");
            tableMapping.ColumnMappings.Add("WetOutDate", "WetOutDate");
            tableMapping.ColumnMappings.Add("InstallDate", "InstallDate");
            tableMapping.ColumnMappings.Add("Thickness", "Thickness");
            tableMapping.ColumnMappings.Add("LengthToLine", "LengthToLine");
            tableMapping.ColumnMappings.Add("PlusExtra", "PlusExtra");
            tableMapping.ColumnMappings.Add("ForTurnOffset", "ForTurnOffset");
            tableMapping.ColumnMappings.Add("LengthToWetOut", "LengthToWetOut");
            tableMapping.ColumnMappings.Add("TubeMaxColdHead", "TubeMaxColdHead");
            tableMapping.ColumnMappings.Add("TubeMaxColdHeadPsi", "TubeMaxColdHeadPsi");
            tableMapping.ColumnMappings.Add("TubeMaxHotHead", "TubeMaxHotHead");
            tableMapping.ColumnMappings.Add("TubeMaxHotHeadPsi", "TubeMaxHotHeadPsi");
            tableMapping.ColumnMappings.Add("TubeIdealHead", "TubeIdealHead");
            tableMapping.ColumnMappings.Add("TubeIdealHeadPsi", "TubeIdealHeadPsi");
            tableMapping.ColumnMappings.Add("NetResinForTube", "NetResinForTube");
            tableMapping.ColumnMappings.Add("NetResinForTubeUsgals", "NetResinForTubeUsgals");
            tableMapping.ColumnMappings.Add("NetResinForTubeDrumsIns", "NetResinForTubeDrumsIns");
            tableMapping.ColumnMappings.Add("NetResinForTubeLbsFt", "NetResinForTubeLbsFt");
            tableMapping.ColumnMappings.Add("NetResinForTubeUsgFt", "NetResinForTubeUsgFt");
            tableMapping.ColumnMappings.Add("ExtraResinForMix", "ExtraResinForMix");
            tableMapping.ColumnMappings.Add("ExtraLbsForMix", "ExtraLbsForMix");
            tableMapping.ColumnMappings.Add("TotalMixQuantity", "TotalMixQuantity");
            tableMapping.ColumnMappings.Add("TotalMixQuantityUsgals", "TotalMixQuantityUsgals");
            tableMapping.ColumnMappings.Add("TotalMixQuantityDrumsIns", "TotalMixQuantityDrumsIns");
            tableMapping.ColumnMappings.Add("InversionType", "InversionType");
            tableMapping.ColumnMappings.Add("DepthOfInversionMH", "DepthOfInversionMH");
            tableMapping.ColumnMappings.Add("TubeForColumn", "TubeForColumn");
            tableMapping.ColumnMappings.Add("TubeForStartDry", "TubeForStartDry");
            tableMapping.ColumnMappings.Add("TotalTube", "TotalTube");
            tableMapping.ColumnMappings.Add("DropTubeConnects", "DropTubeConnects");
            tableMapping.ColumnMappings.Add("AllowsHeadTo", "AllowsHeadTo");
            tableMapping.ColumnMappings.Add("RollerGap", "RollerGap");
            tableMapping.ColumnMappings.Add("HeightNeeded", "HeightNeeded");
            tableMapping.ColumnMappings.Add("Available", "Available");
            tableMapping.ColumnMappings.Add("HoistHeight", "HoistHeight");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("ResinsLabel", "ResinsLabel");
            tableMapping.ColumnMappings.Add("DrumContainsLabel", "DrumContainsLabel");
            tableMapping.ColumnMappings.Add("LinerTubeLabel", "LinerTubeLabel");
            tableMapping.ColumnMappings.Add("ForLbDrumsLabel", "ForLbDrumsLabel");
            tableMapping.ColumnMappings.Add("NetResinLabel", "NetResinLabel");
            tableMapping.ColumnMappings.Add("CatalystLabel", "CatalystLabel");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_WORK_FULLLENGTHLINING_WETOUT] WHERE (([WorkID] = @Original" +
                "_WorkID) AND ([LinerTube] = @Original_LinerTube) AND ([ResinID] = @Original_Resi" +
                "nID) AND ([ExcessResin] = @Original_ExcessResin) AND ([PoundsDrums] = @Original_" +
                "PoundsDrums) AND ([DrumDiameter] = @Original_DrumDiameter) AND ([HoistMaximumHei" +
                "ght] = @Original_HoistMaximumHeight) AND ([HoistMinimumHeight] = @Original_Hoist" +
                "MinimumHeight) AND ([DownDropTubeLenght] = @Original_DownDropTubeLenght) AND ([P" +
                "umpHeightAboveGround] = @Original_PumpHeightAboveGround) AND ([TubeResinToFeltFa" +
                "ctor] = @Original_TubeResinToFeltFactor) AND ([DateOfSheet] = @Original_DateOfSh" +
                "eet) AND ([EmployeeID] = @Original_EmployeeID) AND ([RunDetails2] = @Original_Ru" +
                "nDetails2) AND ([WetOutDate] = @Original_WetOutDate) AND ((@IsNull_InstallDate =" +
                " 1 AND [InstallDate] IS NULL) OR ([InstallDate] = @Original_InstallDate)) AND ([" +
                "Thickness] = @Original_Thickness) AND ([LengthToLine] = @Original_LengthToLine) " +
                "AND ([PlusExtra] = @Original_PlusExtra) AND ([ForTurnOffset] = @Original_ForTurn" +
                "Offset) AND ([LengthToWetOut] = @Original_LengthToWetOut) AND ([TubeMaxColdHead]" +
                " = @Original_TubeMaxColdHead) AND ([TubeMaxColdHeadPsi] = @Original_TubeMaxColdH" +
                "eadPsi) AND ([TubeMaxHotHead] = @Original_TubeMaxHotHead) AND ([TubeMaxHotHeadPs" +
                "i] = @Original_TubeMaxHotHeadPsi) AND ([TubeIdealHead] = @Original_TubeIdealHead" +
                ") AND ([TubeIdealHeadPsi] = @Original_TubeIdealHeadPsi) AND ([NetResinForTube] =" +
                " @Original_NetResinForTube) AND ([NetResinForTubeUsgals] = @Original_NetResinFor" +
                "TubeUsgals) AND ([NetResinForTubeDrumsIns] = @Original_NetResinForTubeDrumsIns) " +
                "AND ([NetResinForTubeLbsFt] = @Original_NetResinForTubeLbsFt) AND ([NetResinForT" +
                "ubeUsgFt] = @Original_NetResinForTubeUsgFt) AND ([ExtraResinForMix] = @Original_" +
                "ExtraResinForMix) AND ([ExtraLbsForMix] = @Original_ExtraLbsForMix) AND ([TotalM" +
                "ixQuantity] = @Original_TotalMixQuantity) AND ([TotalMixQuantityUsgals] = @Origi" +
                "nal_TotalMixQuantityUsgals) AND ([TotalMixQuantityDrumsIns] = @Original_TotalMix" +
                "QuantityDrumsIns) AND ([InversionType] = @Original_InversionType) AND ([DepthOfI" +
                "nversionMH] = @Original_DepthOfInversionMH) AND ([TubeForColumn] = @Original_Tub" +
                "eForColumn) AND ([TubeForStartDry] = @Original_TubeForStartDry) AND ([TotalTube]" +
                " = @Original_TotalTube) AND ([DropTubeConnects] = @Original_DropTubeConnects) AN" +
                "D ([AllowsHeadTo] = @Original_AllowsHeadTo) AND ([RollerGap] = @Original_RollerG" +
                "ap) AND ([HeightNeeded] = @Original_HeightNeeded) AND ([Available] = @Original_A" +
                "vailable) AND ([HoistHeight] = @Original_HoistHeight) AND ([ResinsLabel] = @Orig" +
                "inal_ResinsLabel) AND ([DrumContainsLabel] = @Original_DrumContainsLabel) AND ([" +
                "LinerTubeLabel] = @Original_LinerTubeLabel) AND ([ForLbDrumsLabel] = @Original_F" +
                "orLbDrumsLabel) AND ([NetResinLabel] = @Original_NetResinLabel) AND ([CatalystLa" +
                "bel] = @Original_CatalystLabel) AND ([Deleted] = @Original_Deleted) AND ([COMPAN" +
                "Y_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LinerTube", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerTube", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ResinID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ExcessResin", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExcessResin", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PoundsDrums", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PoundsDrums", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DrumDiameter", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DrumDiameter", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoistMaximumHeight", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoistMaximumHeight", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoistMinimumHeight", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoistMinimumHeight", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DownDropTubeLenght", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownDropTubeLenght", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PumpHeightAboveGround", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpHeightAboveGround", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeResinToFeltFactor", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeResinToFeltFactor", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DateOfSheet", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateOfSheet", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RunDetails2", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RunDetails2", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WetOutDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WetOutDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_InstallDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InstallDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Thickness", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Thickness", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LengthToLine", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LengthToLine", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PlusExtra", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PlusExtra", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ForTurnOffset", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ForTurnOffset", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LengthToWetOut", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LengthToWetOut", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeMaxColdHead", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeMaxColdHead", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeMaxColdHeadPsi", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeMaxColdHeadPsi", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeMaxHotHead", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeMaxHotHead", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeMaxHotHeadPsi", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeMaxHotHeadPsi", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeIdealHead", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeIdealHead", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeIdealHeadPsi", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeIdealHeadPsi", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NetResinForTube", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTube", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NetResinForTubeUsgals", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTubeUsgals", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NetResinForTubeDrumsIns", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTubeDrumsIns", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NetResinForTubeLbsFt", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTubeLbsFt", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NetResinForTubeUsgFt", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTubeUsgFt", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ExtraResinForMix", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExtraResinForMix", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ExtraLbsForMix", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExtraLbsForMix", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalMixQuantity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMixQuantity", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalMixQuantityUsgals", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMixQuantityUsgals", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalMixQuantityDrumsIns", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMixQuantityDrumsIns", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InversionType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InversionType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DepthOfInversionMH", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DepthOfInversionMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeForColumn", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeForColumn", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeForStartDry", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeForStartDry", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalTube", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalTube", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DropTubeConnects", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropTubeConnects", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AllowsHeadTo", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AllowsHeadTo", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RollerGap", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RollerGap", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HeightNeeded", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HeightNeeded", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Available", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Available", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoistHeight", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoistHeight", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ResinsLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinsLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DrumContainsLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DrumContainsLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LinerTubeLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerTubeLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ForLbDrumsLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ForLbDrumsLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NetResinLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CatalystLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CatalystLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_WETOUT] ([WorkID], [LinerTube], [Res" +
                "inID], [ExcessResin], [PoundsDrums], [DrumDiameter], [HoistMaximumHeight], [Hois" +
                "tMinimumHeight], [DownDropTubeLenght], [PumpHeightAboveGround], [TubeResinToFelt" +
                "Factor], [DateOfSheet], [EmployeeID], [RunDetails], [RunDetails2], [WetOutDate]," +
                " [InstallDate], [Thickness], [LengthToLine], [PlusExtra], [ForTurnOffset], [Leng" +
                "thToWetOut], [TubeMaxColdHead], [TubeMaxColdHeadPsi], [TubeMaxHotHead], [TubeMax" +
                "HotHeadPsi], [TubeIdealHead], [TubeIdealHeadPsi], [NetResinForTube], [NetResinFo" +
                "rTubeUsgals], [NetResinForTubeDrumsIns], [NetResinForTubeLbsFt], [NetResinForTub" +
                "eUsgFt], [ExtraResinForMix], [ExtraLbsForMix], [TotalMixQuantity], [TotalMixQuan" +
                "tityUsgals], [TotalMixQuantityDrumsIns], [InversionType], [DepthOfInversionMH], " +
                "[TubeForColumn], [TubeForStartDry], [TotalTube], [DropTubeConnects], [AllowsHead" +
                "To], [RollerGap], [HeightNeeded], [Available], [HoistHeight], [Comments], [Resin" +
                "sLabel], [DrumContainsLabel], [LinerTubeLabel], [ForLbDrumsLabel], [NetResinLabe" +
                "l], [CatalystLabel], [Deleted], [COMPANY_ID]) VALUES (@WorkID, @LinerTube, @Resi" +
                "nID, @ExcessResin, @PoundsDrums, @DrumDiameter, @HoistMaximumHeight, @HoistMinim" +
                "umHeight, @DownDropTubeLenght, @PumpHeightAboveGround, @TubeResinToFeltFactor, @" +
                "DateOfSheet, @EmployeeID, @RunDetails, @RunDetails2, @WetOutDate, @InstallDate, " +
                "@Thickness, @LengthToLine, @PlusExtra, @ForTurnOffset, @LengthToWetOut, @TubeMax" +
                "ColdHead, @TubeMaxColdHeadPsi, @TubeMaxHotHead, @TubeMaxHotHeadPsi, @TubeIdealHe" +
                "ad, @TubeIdealHeadPsi, @NetResinForTube, @NetResinForTubeUsgals, @NetResinForTub" +
                "eDrumsIns, @NetResinForTubeLbsFt, @NetResinForTubeUsgFt, @ExtraResinForMix, @Ext" +
                "raLbsForMix, @TotalMixQuantity, @TotalMixQuantityUsgals, @TotalMixQuantityDrumsI" +
                "ns, @InversionType, @DepthOfInversionMH, @TubeForColumn, @TubeForStartDry, @Tota" +
                "lTube, @DropTubeConnects, @AllowsHeadTo, @RollerGap, @HeightNeeded, @Available, " +
                "@HoistHeight, @Comments, @ResinsLabel, @DrumContainsLabel, @LinerTubeLabel, @For" +
                "LbDrumsLabel, @NetResinLabel, @CatalystLabel, @Deleted, @COMPANY_ID);\r\nSELECT Wo" +
                "rkID, LinerTube, ResinID, ExcessResin, PoundsDrums, DrumDiameter, HoistMaximumHe" +
                "ight, HoistMinimumHeight, DownDropTubeLenght, PumpHeightAboveGround, TubeResinTo" +
                "FeltFactor, DateOfSheet, EmployeeID, RunDetails, RunDetails2, WetOutDate, Instal" +
                "lDate, Thickness, LengthToLine, PlusExtra, ForTurnOffset, LengthToWetOut, TubeMa" +
                "xColdHead, TubeMaxColdHeadPsi, TubeMaxHotHead, TubeMaxHotHeadPsi, TubeIdealHead," +
                " TubeIdealHeadPsi, NetResinForTube, NetResinForTubeUsgals, NetResinForTubeDrumsI" +
                "ns, NetResinForTubeLbsFt, NetResinForTubeUsgFt, ExtraResinForMix, ExtraLbsForMix" +
                ", TotalMixQuantity, TotalMixQuantityUsgals, TotalMixQuantityDrumsIns, InversionT" +
                "ype, DepthOfInversionMH, TubeForColumn, TubeForStartDry, TotalTube, DropTubeConn" +
                "ects, AllowsHeadTo, RollerGap, HeightNeeded, Available, HoistHeight, Comments, R" +
                "esinsLabel, DrumContainsLabel, LinerTubeLabel, ForLbDrumsLabel, NetResinLabel, C" +
                "atalystLabel, Deleted, COMPANY_ID FROM LFS_WORK_FULLLENGTHLINING_WETOUT WHERE (W" +
                "orkID = @WorkID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerTube", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerTube", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ResinID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ExcessResin", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExcessResin", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PoundsDrums", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PoundsDrums", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DrumDiameter", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DrumDiameter", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoistMaximumHeight", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoistMaximumHeight", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoistMinimumHeight", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoistMinimumHeight", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DownDropTubeLenght", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownDropTubeLenght", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PumpHeightAboveGround", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpHeightAboveGround", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeResinToFeltFactor", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeResinToFeltFactor", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DateOfSheet", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateOfSheet", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RunDetails", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RunDetails", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RunDetails2", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RunDetails2", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WetOutDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WetOutDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InstallDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Thickness", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Thickness", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LengthToLine", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LengthToLine", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PlusExtra", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PlusExtra", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ForTurnOffset", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ForTurnOffset", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LengthToWetOut", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LengthToWetOut", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeMaxColdHead", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeMaxColdHead", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeMaxColdHeadPsi", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeMaxColdHeadPsi", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeMaxHotHead", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeMaxHotHead", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeMaxHotHeadPsi", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeMaxHotHeadPsi", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeIdealHead", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeIdealHead", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeIdealHeadPsi", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeIdealHeadPsi", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NetResinForTube", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTube", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NetResinForTubeUsgals", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTubeUsgals", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NetResinForTubeDrumsIns", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTubeDrumsIns", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NetResinForTubeLbsFt", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTubeLbsFt", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NetResinForTubeUsgFt", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTubeUsgFt", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ExtraResinForMix", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExtraResinForMix", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ExtraLbsForMix", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExtraLbsForMix", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalMixQuantity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMixQuantity", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalMixQuantityUsgals", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMixQuantityUsgals", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalMixQuantityDrumsIns", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMixQuantityDrumsIns", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InversionType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InversionType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DepthOfInversionMH", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DepthOfInversionMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeForColumn", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeForColumn", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeForStartDry", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeForStartDry", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalTube", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalTube", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DropTubeConnects", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropTubeConnects", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AllowsHeadTo", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AllowsHeadTo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RollerGap", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RollerGap", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HeightNeeded", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HeightNeeded", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Available", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Available", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoistHeight", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoistHeight", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ResinsLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinsLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DrumContainsLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DrumContainsLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerTubeLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerTubeLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ForLbDrumsLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ForLbDrumsLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NetResinLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CatalystLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CatalystLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_WETOUT] SET [WorkID] = @WorkID, [LinerTub" +
                "e] = @LinerTube, [ResinID] = @ResinID, [ExcessResin] = @ExcessResin, [PoundsDrum" +
                "s] = @PoundsDrums, [DrumDiameter] = @DrumDiameter, [HoistMaximumHeight] = @Hoist" +
                "MaximumHeight, [HoistMinimumHeight] = @HoistMinimumHeight, [DownDropTubeLenght] " +
                "= @DownDropTubeLenght, [PumpHeightAboveGround] = @PumpHeightAboveGround, [TubeRe" +
                "sinToFeltFactor] = @TubeResinToFeltFactor, [DateOfSheet] = @DateOfSheet, [Employ" +
                "eeID] = @EmployeeID, [RunDetails] = @RunDetails, [RunDetails2] = @RunDetails2, [" +
                "WetOutDate] = @WetOutDate, [InstallDate] = @InstallDate, [Thickness] = @Thicknes" +
                "s, [LengthToLine] = @LengthToLine, [PlusExtra] = @PlusExtra, [ForTurnOffset] = @" +
                "ForTurnOffset, [LengthToWetOut] = @LengthToWetOut, [TubeMaxColdHead] = @TubeMaxC" +
                "oldHead, [TubeMaxColdHeadPsi] = @TubeMaxColdHeadPsi, [TubeMaxHotHead] = @TubeMax" +
                "HotHead, [TubeMaxHotHeadPsi] = @TubeMaxHotHeadPsi, [TubeIdealHead] = @TubeIdealH" +
                "ead, [TubeIdealHeadPsi] = @TubeIdealHeadPsi, [NetResinForTube] = @NetResinForTub" +
                "e, [NetResinForTubeUsgals] = @NetResinForTubeUsgals, [NetResinForTubeDrumsIns] =" +
                " @NetResinForTubeDrumsIns, [NetResinForTubeLbsFt] = @NetResinForTubeLbsFt, [NetR" +
                "esinForTubeUsgFt] = @NetResinForTubeUsgFt, [ExtraResinForMix] = @ExtraResinForMi" +
                "x, [ExtraLbsForMix] = @ExtraLbsForMix, [TotalMixQuantity] = @TotalMixQuantity, [" +
                "TotalMixQuantityUsgals] = @TotalMixQuantityUsgals, [TotalMixQuantityDrumsIns] = " +
                "@TotalMixQuantityDrumsIns, [InversionType] = @InversionType, [DepthOfInversionMH" +
                "] = @DepthOfInversionMH, [TubeForColumn] = @TubeForColumn, [TubeForStartDry] = @" +
                "TubeForStartDry, [TotalTube] = @TotalTube, [DropTubeConnects] = @DropTubeConnect" +
                "s, [AllowsHeadTo] = @AllowsHeadTo, [RollerGap] = @RollerGap, [HeightNeeded] = @H" +
                "eightNeeded, [Available] = @Available, [HoistHeight] = @HoistHeight, [Comments] " +
                "= @Comments, [ResinsLabel] = @ResinsLabel, [DrumContainsLabel] = @DrumContainsLa" +
                "bel, [LinerTubeLabel] = @LinerTubeLabel, [ForLbDrumsLabel] = @ForLbDrumsLabel, [" +
                "NetResinLabel] = @NetResinLabel, [CatalystLabel] = @CatalystLabel, [Deleted] = @" +
                "Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([WorkID] = @Original_WorkID) AND ([L" +
                "inerTube] = @Original_LinerTube) AND ([ResinID] = @Original_ResinID) AND ([Exces" +
                "sResin] = @Original_ExcessResin) AND ([PoundsDrums] = @Original_PoundsDrums) AND" +
                " ([DrumDiameter] = @Original_DrumDiameter) AND ([HoistMaximumHeight] = @Original" +
                "_HoistMaximumHeight) AND ([HoistMinimumHeight] = @Original_HoistMinimumHeight) A" +
                "ND ([DownDropTubeLenght] = @Original_DownDropTubeLenght) AND ([PumpHeightAboveGr" +
                "ound] = @Original_PumpHeightAboveGround) AND ([TubeResinToFeltFactor] = @Origina" +
                "l_TubeResinToFeltFactor) AND ([DateOfSheet] = @Original_DateOfSheet) AND ([Emplo" +
                "yeeID] = @Original_EmployeeID) AND ([RunDetails2] = @Original_RunDetails2) AND (" +
                "[WetOutDate] = @Original_WetOutDate) AND ((@IsNull_InstallDate = 1 AND [InstallD" +
                "ate] IS NULL) OR ([InstallDate] = @Original_InstallDate)) AND ([Thickness] = @Or" +
                "iginal_Thickness) AND ([LengthToLine] = @Original_LengthToLine) AND ([PlusExtra]" +
                " = @Original_PlusExtra) AND ([ForTurnOffset] = @Original_ForTurnOffset) AND ([Le" +
                "ngthToWetOut] = @Original_LengthToWetOut) AND ([TubeMaxColdHead] = @Original_Tub" +
                "eMaxColdHead) AND ([TubeMaxColdHeadPsi] = @Original_TubeMaxColdHeadPsi) AND ([Tu" +
                "beMaxHotHead] = @Original_TubeMaxHotHead) AND ([TubeMaxHotHeadPsi] = @Original_T" +
                "ubeMaxHotHeadPsi) AND ([TubeIdealHead] = @Original_TubeIdealHead) AND ([TubeIdea" +
                "lHeadPsi] = @Original_TubeIdealHeadPsi) AND ([NetResinForTube] = @Original_NetRe" +
                "sinForTube) AND ([NetResinForTubeUsgals] = @Original_NetResinForTubeUsgals) AND " +
                "([NetResinForTubeDrumsIns] = @Original_NetResinForTubeDrumsIns) AND ([NetResinFo" +
                "rTubeLbsFt] = @Original_NetResinForTubeLbsFt) AND ([NetResinForTubeUsgFt] = @Ori" +
                "ginal_NetResinForTubeUsgFt) AND ([ExtraResinForMix] = @Original_ExtraResinForMix" +
                ") AND ([ExtraLbsForMix] = @Original_ExtraLbsForMix) AND ([TotalMixQuantity] = @O" +
                "riginal_TotalMixQuantity) AND ([TotalMixQuantityUsgals] = @Original_TotalMixQuan" +
                "tityUsgals) AND ([TotalMixQuantityDrumsIns] = @Original_TotalMixQuantityDrumsIns" +
                ") AND ([InversionType] = @Original_InversionType) AND ([DepthOfInversionMH] = @O" +
                "riginal_DepthOfInversionMH) AND ([TubeForColumn] = @Original_TubeForColumn) AND " +
                "([TubeForStartDry] = @Original_TubeForStartDry) AND ([TotalTube] = @Original_Tot" +
                "alTube) AND ([DropTubeConnects] = @Original_DropTubeConnects) AND ([AllowsHeadTo" +
                "] = @Original_AllowsHeadTo) AND ([RollerGap] = @Original_RollerGap) AND ([Height" +
                "Needed] = @Original_HeightNeeded) AND ([Available] = @Original_Available) AND ([" +
                "HoistHeight] = @Original_HoistHeight) AND ([ResinsLabel] = @Original_ResinsLabel" +
                ") AND ([DrumContainsLabel] = @Original_DrumContainsLabel) AND ([LinerTubeLabel] " +
                "= @Original_LinerTubeLabel) AND ([ForLbDrumsLabel] = @Original_ForLbDrumsLabel) " +
                "AND ([NetResinLabel] = @Original_NetResinLabel) AND ([CatalystLabel] = @Original" +
                "_CatalystLabel) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Origina" +
                "l_COMPANY_ID));\r\nSELECT WorkID, LinerTube, ResinID, ExcessResin, PoundsDrums, Dr" +
                "umDiameter, HoistMaximumHeight, HoistMinimumHeight, DownDropTubeLenght, PumpHeig" +
                "htAboveGround, TubeResinToFeltFactor, DateOfSheet, EmployeeID, RunDetails, RunDe" +
                "tails2, WetOutDate, InstallDate, Thickness, LengthToLine, PlusExtra, ForTurnOffs" +
                "et, LengthToWetOut, TubeMaxColdHead, TubeMaxColdHeadPsi, TubeMaxHotHead, TubeMax" +
                "HotHeadPsi, TubeIdealHead, TubeIdealHeadPsi, NetResinForTube, NetResinForTubeUsg" +
                "als, NetResinForTubeDrumsIns, NetResinForTubeLbsFt, NetResinForTubeUsgFt, ExtraR" +
                "esinForMix, ExtraLbsForMix, TotalMixQuantity, TotalMixQuantityUsgals, TotalMixQu" +
                "antityDrumsIns, InversionType, DepthOfInversionMH, TubeForColumn, TubeForStartDr" +
                "y, TotalTube, DropTubeConnects, AllowsHeadTo, RollerGap, HeightNeeded, Available" +
                ", HoistHeight, Comments, ResinsLabel, DrumContainsLabel, LinerTubeLabel, ForLbDr" +
                "umsLabel, NetResinLabel, CatalystLabel, Deleted, COMPANY_ID FROM LFS_WORK_FULLLE" +
                "NGTHLINING_WETOUT WHERE (WorkID = @WorkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerTube", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerTube", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ResinID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ExcessResin", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExcessResin", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PoundsDrums", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PoundsDrums", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DrumDiameter", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DrumDiameter", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoistMaximumHeight", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoistMaximumHeight", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoistMinimumHeight", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoistMinimumHeight", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DownDropTubeLenght", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownDropTubeLenght", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PumpHeightAboveGround", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpHeightAboveGround", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeResinToFeltFactor", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeResinToFeltFactor", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DateOfSheet", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateOfSheet", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RunDetails", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RunDetails", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RunDetails2", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RunDetails2", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WetOutDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WetOutDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InstallDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Thickness", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Thickness", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LengthToLine", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LengthToLine", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PlusExtra", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PlusExtra", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ForTurnOffset", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ForTurnOffset", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LengthToWetOut", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LengthToWetOut", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeMaxColdHead", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeMaxColdHead", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeMaxColdHeadPsi", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeMaxColdHeadPsi", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeMaxHotHead", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeMaxHotHead", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeMaxHotHeadPsi", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeMaxHotHeadPsi", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeIdealHead", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeIdealHead", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeIdealHeadPsi", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeIdealHeadPsi", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NetResinForTube", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTube", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NetResinForTubeUsgals", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTubeUsgals", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NetResinForTubeDrumsIns", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTubeDrumsIns", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NetResinForTubeLbsFt", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTubeLbsFt", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NetResinForTubeUsgFt", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTubeUsgFt", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ExtraResinForMix", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExtraResinForMix", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ExtraLbsForMix", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExtraLbsForMix", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalMixQuantity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMixQuantity", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalMixQuantityUsgals", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMixQuantityUsgals", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalMixQuantityDrumsIns", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMixQuantityDrumsIns", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InversionType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InversionType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DepthOfInversionMH", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DepthOfInversionMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeForColumn", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeForColumn", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TubeForStartDry", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeForStartDry", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TotalTube", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalTube", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DropTubeConnects", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropTubeConnects", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AllowsHeadTo", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AllowsHeadTo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RollerGap", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RollerGap", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HeightNeeded", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HeightNeeded", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Available", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Available", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoistHeight", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoistHeight", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ResinsLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinsLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DrumContainsLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DrumContainsLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerTubeLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerTubeLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ForLbDrumsLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ForLbDrumsLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NetResinLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CatalystLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CatalystLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LinerTube", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerTube", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ResinID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ExcessResin", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExcessResin", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PoundsDrums", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PoundsDrums", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DrumDiameter", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DrumDiameter", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoistMaximumHeight", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoistMaximumHeight", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoistMinimumHeight", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoistMinimumHeight", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DownDropTubeLenght", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DownDropTubeLenght", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PumpHeightAboveGround", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpHeightAboveGround", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeResinToFeltFactor", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeResinToFeltFactor", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DateOfSheet", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateOfSheet", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RunDetails2", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RunDetails2", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WetOutDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WetOutDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_InstallDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InstallDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Thickness", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Thickness", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LengthToLine", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LengthToLine", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PlusExtra", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PlusExtra", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ForTurnOffset", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ForTurnOffset", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LengthToWetOut", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LengthToWetOut", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeMaxColdHead", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeMaxColdHead", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeMaxColdHeadPsi", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeMaxColdHeadPsi", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeMaxHotHead", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeMaxHotHead", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeMaxHotHeadPsi", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeMaxHotHeadPsi", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeIdealHead", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeIdealHead", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeIdealHeadPsi", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeIdealHeadPsi", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NetResinForTube", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTube", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NetResinForTubeUsgals", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTubeUsgals", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NetResinForTubeDrumsIns", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTubeDrumsIns", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NetResinForTubeLbsFt", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTubeLbsFt", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NetResinForTubeUsgFt", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinForTubeUsgFt", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ExtraResinForMix", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExtraResinForMix", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ExtraLbsForMix", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ExtraLbsForMix", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalMixQuantity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMixQuantity", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalMixQuantityUsgals", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMixQuantityUsgals", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalMixQuantityDrumsIns", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalMixQuantityDrumsIns", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InversionType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InversionType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DepthOfInversionMH", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DepthOfInversionMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeForColumn", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeForColumn", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TubeForStartDry", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TubeForStartDry", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TotalTube", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TotalTube", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DropTubeConnects", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropTubeConnects", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AllowsHeadTo", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AllowsHeadTo", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RollerGap", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RollerGap", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HeightNeeded", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HeightNeeded", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Available", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Available", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoistHeight", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoistHeight", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ResinsLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ResinsLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DrumContainsLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DrumContainsLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LinerTubeLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerTubeLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ForLbDrumsLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ForLbDrumsLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NetResinLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NetResinLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CatalystLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CatalystLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByWorkId(int workId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKFULLLENGTHLININGWETOUTGATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert  wet out info (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="linerTube">linerTube</param>
        /// <param name="resinId">resinId</param>
        /// <param name="excessResin">excessResin</param>
        /// <param name="poundsDrums">poundsDrums</param>
        /// <param name="drumDiameter">drumDiameter</param>
        /// <param name="hoistMaximumHeight">hoistMaximumHeight</param>
        /// <param name="hoistMinimumHeight">hoistMinimumHeight</param>
        /// <param name="downDropTubeLenght">downDropTubeLenght</param>
        /// <param name="pumpHeightAboveGround">pumpHeightAboveGround</param>
        /// <param name="tubeResinToFeltFactor">tubeResinToFeltFactor</param>
        /// <param name="dateOfSheet">dateOfSheet</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="runDetails">runDetails</param>
        /// <param name="runDetails2">runDetails2</param>
        /// <param name="wetOutDate">wetOutDate</param>
        /// <param name="installDate">installDate</param>
        /// <param name="thickness">thickness</param>
        /// <param name="lengthToLine">lengthToLine</param>
        /// <param name="plusExtra">plusExtra</param>
        /// <param name="forTurnOffset">forTurnOffset</param>
        /// <param name="lengthToWetOut">lengthToWetOut</param>
        /// <param name="tubeMaxColdHead">tubeMaxColdHead</param>
        /// <param name="tubeMaxColdHeadPsi">tubeMaxColdHeadPsi</param>
        /// <param name="tubeMaxHotHead">tubeMaxHotHead</param>
        /// <param name="tubeMaxHotHeadPsi">tubeMaxHotHeadPsi</param>
        /// <param name="tubeIdealHead">tubeIdealHead</param>
        /// <param name="tubeIdealHeadPsi">tubeIdealHeadPsi</param>
        /// <param name="netResinForTube">netResinForTube</param>
        /// <param name="netResinForTubeUsgals">netResinForTubeUsgals</param>
        /// <param name="netResinForTubeDrumsIns">netResinForTubeDrumsIns</param>
        /// <param name="netResinForTubeLbsFt">netResinForTubeLbsFt</param>
        /// <param name="netResinForTubeUsgFt">netResinForTubeUsgFt</param>
        /// <param name="extraResinForMix">extraResinForMix</param>
        /// <param name="extraLbsForMix">extraLbsForMix</param>
        /// <param name="totalMixQuantity">totalMixQuantity</param>
        /// <param name="totalMixQuantityUsgals">totalMixQuantityUsgals</param>
        /// <param name="totalMixQuantityDrumsIns">totalMixQuantityDrumsIns</param>
        /// <param name="inversionType">inversionType</param>
        /// <param name="depthOfInversionMH">depthOfInversionMH</param>
        /// <param name="tubeForColumn">tubeForColumn</param>
        /// <param name="tubeForStartDry">tubeForStartDry</param>
        /// <param name="totalTube">totalTube</param>
        /// <param name="dropTubeConnects">dropTubeConnects</param>
        /// <param name="allowsHeadTo">allowsHeadTo</param>
        /// <param name="rollerGap">rollerGap</param>
        /// <param name="heightNeeded">heightNeeded</param>
        /// <param name="available">available</param>
        /// <param name="hoistHeight">hoistHeight</param>
        /// <param name="comments">comments</param>
        /// <param name="netResinLabel">netResinLabel</param>
        /// <param name="drumContainsLabel">drumContainsLabel</param>
        /// <param name="linerTubeLabel">linerTubeLabel</param>
        /// <param name="forLbDrumsLabel">forLbDrumsLabel</param>
        /// <param name="netResinLabel">netResinLabel</param>
        /// <param name="catalystLabel">catalystLabel</param>         
        /// <param name="deleted">deleted</param>       
        /// <param name="companyId">companyId</param>        
        /// <returns>rowsAffected</returns>
        public int Insert(int workId, string linerTube, int resinId, decimal excessResin, string poundsDrums, decimal drumDiameter, decimal hoistMaximumHeight, decimal hoistMinimumHeight, decimal downDropTubeLenght, decimal pumpHeightAboveGround, int tubeResinToFeltFactor, DateTime dateOfSheet, int employeeId, string runDetails, string runDetails2, DateTime wetOutDate, DateTime? installDate, string thickness, decimal lengthToLine, decimal plusExtra, decimal forTurnOffset, decimal lengthToWetOut, decimal tubeMaxColdHead, decimal tubeMaxColdHeadPsi, decimal tubeMaxHotHead, decimal tubeMaxHotHeadPsi, decimal tubeIdealHead, decimal tubeIdealHeadPsi, decimal netResinForTube, decimal netResinForTubeUsgals, string netResinForTubeDrumsIns, decimal netResinForTubeLbsFt, decimal netResinForTubeUsgFt, int extraResinForMix, decimal extraLbsForMix, decimal totalMixQuantity, decimal totalMixQuantityUsgals, string totalMixQuantityDrumsIns, string inversionType, decimal depthOfInversionMH, decimal tubeForColumn, decimal tubeForStartDry, decimal totalTube, string dropTubeConnects, decimal allowsHeadTo, decimal rollerGap, decimal heightNeeded, string available, string hoistHeight, string comments, string resinsLabel, string drumContainsLabel, string linerTubeLabel, string forLbDrumsLabel, string netResinLabel, string catalystLabel, bool deleted, int companyId)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter linerTubeParameter = new SqlParameter("LinerTube", linerTube.Trim());
            SqlParameter resinIdParameter = new SqlParameter("ResinID", resinId);
            SqlParameter excessResinParameter = new SqlParameter("ExcessResin", excessResin);
            SqlParameter poundsDrumsParameter = new SqlParameter("PoundsDrums", poundsDrums);
            SqlParameter drumDiameterParameter = new SqlParameter("DrumDiameter", drumDiameter);
            SqlParameter hoistMaximumHeightParameter = new SqlParameter("HoistMaximumHeight", hoistMaximumHeight);
            SqlParameter hoistMinimumHeightParameter = new SqlParameter("HoistMinimumHeight", hoistMinimumHeight);
            SqlParameter downDropTubeLenghtParameter = new SqlParameter("DownDropTubeLenght", downDropTubeLenght);
            SqlParameter pumpHeightAboveGroundParameter = new SqlParameter("PumpHeightAboveGround", pumpHeightAboveGround);
            SqlParameter tubeResinToFeltFactorParameter = new SqlParameter("TubeResinToFeltFactor", tubeResinToFeltFactor);
            SqlParameter dateOfSheetParameter = new SqlParameter("DateOfSheet", dateOfSheet);
            SqlParameter employeeIdParameter = new SqlParameter("EmployeeID", employeeId);
            SqlParameter runDetailsParameter = new SqlParameter("RunDetails", runDetails.Trim());
            SqlParameter runDetails2Parameter = new SqlParameter("RunDetails2", runDetails2.Trim());
            SqlParameter wetOutDateParameter = new SqlParameter("WetOutDate", wetOutDate);
            SqlParameter installDateParameter = (installDate.HasValue) ? new SqlParameter("InstallDate", installDate) : new SqlParameter("InstallDate", DBNull.Value);            
            SqlParameter thicknessParameter = new SqlParameter("Thickness", thickness.Trim());
            SqlParameter lengthToLineParameter = new SqlParameter("LengthToLine", lengthToLine);
            SqlParameter plusExtraParameter = new SqlParameter("PlusExtra", plusExtra);
            SqlParameter forTurnOffsetParameter = new SqlParameter("ForTurnOffset", forTurnOffset);
            SqlParameter lengthToWetOutParameter = new SqlParameter("LengthToWetOut", lengthToWetOut);
            SqlParameter tubeMaxColdHeadParameter = new SqlParameter("TubeMaxColdHead", tubeMaxColdHead);
            SqlParameter tubeMaxColdHeadPsiParameter = new SqlParameter("TubeMaxColdHeadPsi", tubeMaxColdHeadPsi);
            SqlParameter tubeMaxHotHeadParameter = new SqlParameter("TubeMaxHotHead", tubeMaxHotHead);
            SqlParameter tubeMaxHotHeadPsiParameter = new SqlParameter("TubeMaxHotHeadPsi", tubeMaxHotHeadPsi);
            SqlParameter tubeIdealHeadParameter = new SqlParameter("TubeIdealHead", tubeIdealHead);
            SqlParameter tubeIdealHeadPsiParameter = new SqlParameter("TubeIdealHeadPsi", tubeIdealHeadPsi);
            SqlParameter netResinForTubeParameter = new SqlParameter("NetResinForTube", netResinForTube);
            SqlParameter netResinForTubeUsgalsParameter = new SqlParameter("NetResinForTubeUsgals", netResinForTubeUsgals);
            SqlParameter netResinForTubeDrumsInsParameter = new SqlParameter("NetResinForTubeDrumsIns", netResinForTubeDrumsIns.Trim());
            SqlParameter netResinForTubeLbsFtParameter = new SqlParameter("NetResinForTubeLbsFt", netResinForTubeLbsFt);
            SqlParameter netResinForTubeUsgFtParameter = new SqlParameter("NetResinForTubeUsgFt", netResinForTubeUsgFt);
            SqlParameter extraResinForMixParameter = new SqlParameter("ExtraResinForMix", extraResinForMix);
            SqlParameter extraLbsForMixParameter = new SqlParameter("ExtraLbsForMix", extraLbsForMix);
            SqlParameter totalMixQuantityParameter = new SqlParameter("TotalMixQuantity", totalMixQuantity);
            SqlParameter totalMixQuantityUsgalsParameter = new SqlParameter("TotalMixQuantityUsgals", totalMixQuantityUsgals);
            SqlParameter totalMixQuantityDrumsInsParameter = new SqlParameter("TotalMixQuantityDrumsIns", totalMixQuantityDrumsIns.Trim());
            SqlParameter inversionTypeParameter = new SqlParameter("InversionType", inversionType.Trim());
            SqlParameter depthOfInversionMHParameter = new SqlParameter("DepthOfInversionMH", depthOfInversionMH);
            SqlParameter tubeForColumnParameter = new SqlParameter("TubeForColumn", tubeForColumn);
            SqlParameter tubeForStartDryParameter = new SqlParameter("TubeForStartDry", tubeForStartDry);
            SqlParameter totalTubeParameter = new SqlParameter("TotalTube", totalTube);
            SqlParameter dropTubeConnectsParameter = new SqlParameter("DropTubeConnects", dropTubeConnects.Trim());
            SqlParameter allowsHeadToParameter = new SqlParameter("AllowsHeadTo", allowsHeadTo);
            SqlParameter rollerGapParameter = new SqlParameter("RollerGap", rollerGap);
            SqlParameter heightNeededParameter = new SqlParameter("HeightNeeded", heightNeeded);
            SqlParameter availableParameter = new SqlParameter("Available", available.Trim());
            SqlParameter hoistHeightParameter = new SqlParameter("HoistHeight", hoistHeight.Trim());            
            SqlParameter commentsParameter = (comments.Trim() != "") ? new SqlParameter("Comments", comments.Trim()) : new SqlParameter("Comments", DBNull.Value);            
            SqlParameter resinsLabelParameter = new SqlParameter("ResinsLabel", resinsLabel.Trim());
            SqlParameter drumContainsLabelParameter = new SqlParameter("DrumContainsLabel", drumContainsLabel.Trim());
            SqlParameter linerTubeLabelParameter = new SqlParameter("LinerTubeLabel", linerTubeLabel.Trim());
            SqlParameter forLbDrumsLabelParameter = new SqlParameter("ForLbDrumsLabel", forLbDrumsLabel.Trim());
            SqlParameter netResinLabelParameter = new SqlParameter("NetResinLabel", netResinLabel.Trim());
            SqlParameter catalystLabelParameter = new SqlParameter("CatalystLabel", catalystLabel.Trim());                                 
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_WETOUT] ([WorkID], [LinerTube], [Res" +
                "inID], [ExcessResin], [PoundsDrums], [DrumDiameter], [HoistMaximumHeight], [Hois" +
                "tMinimumHeight], [DownDropTubeLenght], [PumpHeightAboveGround], [TubeResinToFelt" +
                "Factor], [DateOfSheet], [EmployeeID], [RunDetails], [RunDetails2], [WetOutDate]," +
                " [InstallDate], [Thickness], [LengthToLine], [PlusExtra], [ForTurnOffset], [Leng" +
                "thToWetOut], [TubeMaxColdHead], [TubeMaxColdHeadPsi], [TubeMaxHotHead], [TubeMax" +
                "HotHeadPsi], [TubeIdealHead], [TubeIdealHeadPsi], [NetResinForTube], [NetResinFo" +
                "rTubeUsgals], [NetResinForTubeDrumsIns], [NetResinForTubeLbsFt], [NetResinForTub" +
                "eUsgFt], [ExtraResinForMix], [ExtraLbsForMix], [TotalMixQuantity], [TotalMixQuan" +
                "tityUsgals], [TotalMixQuantityDrumsIns], [InversionType], [DepthOfInversionMH], " +
                "[TubeForColumn], [TubeForStartDry], [TotalTube], [DropTubeConnects], [AllowsHead" +
                "To], [RollerGap], [HeightNeeded], [Available], [HoistHeight], [Comments], [Resin" +
                "sLabel], [DrumContainsLabel], [LinerTubeLabel], [ForLbDrumsLabel], [NetResinLabe" +
                "l], [CatalystLabel], [Deleted], [COMPANY_ID]) VALUES (@WorkID, @LinerTube, @Resi" +
                "nID, @ExcessResin, @PoundsDrums, @DrumDiameter, @HoistMaximumHeight, @HoistMinim" +
                "umHeight, @DownDropTubeLenght, @PumpHeightAboveGround, @TubeResinToFeltFactor, @" +
                "DateOfSheet, @EmployeeID, @RunDetails, @RunDetails2, @WetOutDate, @InstallDate, " +
                "@Thickness, @LengthToLine, @PlusExtra, @ForTurnOffset, @LengthToWetOut, @TubeMax" +
                "ColdHead, @TubeMaxColdHeadPsi, @TubeMaxHotHead, @TubeMaxHotHeadPsi, @TubeIdealHe" +
                "ad, @TubeIdealHeadPsi, @NetResinForTube, @NetResinForTubeUsgals, @NetResinForTub" +
                "eDrumsIns, @NetResinForTubeLbsFt, @NetResinForTubeUsgFt, @ExtraResinForMix, @Ext" +
                "raLbsForMix, @TotalMixQuantity, @TotalMixQuantityUsgals, @TotalMixQuantityDrumsI" +
                "ns, @InversionType, @DepthOfInversionMH, @TubeForColumn, @TubeForStartDry, @Tota" +
                "lTube, @DropTubeConnects, @AllowsHeadTo, @RollerGap, @HeightNeeded, @Available, " +
                "@HoistHeight, @Comments, @ResinsLabel, @DrumContainsLabel, @LinerTubeLabel, @For" +
                "LbDrumsLabel, @NetResinLabel, @CatalystLabel, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, linerTubeParameter, resinIdParameter, excessResinParameter, poundsDrumsParameter, drumDiameterParameter, hoistMaximumHeightParameter, hoistMinimumHeightParameter, downDropTubeLenghtParameter, pumpHeightAboveGroundParameter, tubeResinToFeltFactorParameter, dateOfSheetParameter, employeeIdParameter, runDetailsParameter, runDetails2Parameter, wetOutDateParameter, installDateParameter, thicknessParameter, lengthToLineParameter, plusExtraParameter, forTurnOffsetParameter, lengthToWetOutParameter, tubeMaxColdHeadParameter, tubeMaxColdHeadPsiParameter, tubeMaxHotHeadParameter, tubeMaxHotHeadPsiParameter, tubeIdealHeadParameter, tubeIdealHeadPsiParameter, netResinForTubeParameter, netResinForTubeUsgalsParameter, netResinForTubeDrumsInsParameter, netResinForTubeLbsFtParameter, netResinForTubeUsgFtParameter, extraResinForMixParameter, extraLbsForMixParameter, totalMixQuantityParameter, totalMixQuantityUsgalsParameter, totalMixQuantityDrumsInsParameter, inversionTypeParameter, depthOfInversionMHParameter, tubeForColumnParameter, tubeForStartDryParameter, totalTubeParameter, dropTubeConnectsParameter, allowsHeadToParameter, rollerGapParameter, heightNeededParameter, availableParameter, hoistHeightParameter, commentsParameter, resinsLabelParameter, drumContainsLabelParameter, linerTubeLabelParameter, forLbDrumsLabelParameter, netResinLabelParameter, catalystLabelParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update wet out info (direct to DB)
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalLinerTube">originalLinerTube</param>
        /// <param name="originalResinId">originalResinId</param>
        /// <param name="originalExcessResin">originalExcessResin</param>
        /// <param name="originalPoundsDrums">originalPoundsDrums</param>
        /// <param name="originalDrumDiameter">originalDrumDiameter</param>
        /// <param name="originalHoistMaximumHeight">originalHoistMaximumHeight</param>
        /// <param name="originalHoistMinimumHeight">originalHoistMinimumHeight</param>
        /// <param name="originalDownDropTubeLenght">originalDownDropTubeLenght</param>
        /// <param name="originalPumpHeightAboveGround">originalPumpHeightAboveGround</param>
        /// <param name="originalTubeResinToFeltFactor">originalTubeResinToFeltFactor</param>
        /// <param name="originalDateOfSheet">originalDateOfSheet</param>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalRunDetails">originalRunDetails</param>
        /// <param name="originalRunDetails2">originalRunDetails2</param>
        /// <param name="originalWetOutDate">originalWetOutDate</param>
        /// <param name="originalInstallDate">originalInstallDate</param>
        /// <param name="originalThickness">originalThickness</param>
        /// <param name="originalLengthToLine">originalLengthToLine</param>
        /// <param name="originalPlusExtra">originalPlusExtra</param>
        /// <param name="originalForTurnOffset">originalForTurnOffset</param>
        /// <param name="originalLengthToWetOut">originalLengthToWetOut</param>
        /// <param name="originalTubeMaxColdHead">originalTubeMaxColdHead</param>
        /// <param name="originalTubeMaxColdHeadPsi">originalTubeMaxColdHeadPsi</param>
        /// <param name="originalTubeMaxHotHead">originalTubeMaxHotHead</param>
        /// <param name="originalTubeMaxHotHeadPsi">originalTubeMaxHotHeadPsi</param>
        /// <param name="originalTubeIdealHead">originalTubeIdealHead</param>
        /// <param name="originalTubeIdealHeadPsi">originalTubeIdealHeadPsi</param>
        /// <param name="originalNetResinForTube">originalNetResinForTube</param>
        /// <param name="originalNetResinForTubeUsgals">originalNetResinForTubeUsgals</param>
        /// <param name="originalNetResinForTubeDrumsIns">originalNetResinForTubeDrumsIns</param>
        /// <param name="originalNetResinForTubeLbsFt">originalNetResinForTubeLbsFt</param>
        /// <param name="originalNetResinForTubeUsgFt">originalNetResinForTubeUsgFt>
        /// <param name="originalExtraResinForMix">originalExtraResinForMix</param>
        /// <param name="originalExtraLbsForMix">originalExtraLbsForMix</param>
        /// <param name="originalTotalMixQuantity">originalTotalMixQuantity</param>
        /// <param name="originalTotalMixQuantityUsgals">originalTotalMixQuantityUsgals</param>
        /// <param name="originalTotalMixQuantityDrumsIns">originalTotalMixQuantityDrumsIns</param>
        /// <param name="originalInversionType">originalInversionType>
        /// <param name="originalDepthOfInversionMH">originalDepthOfInversionMH</param>
        /// <param name="originalTubeForColumn">originalTubeForColumn</param>
        /// <param name="originalTubeForStartDry">originalTubeForStartDry</param>
        /// <param name="originalTotalTube">originalTotalTube</param>
        /// <param name="originalDropTubeConnects">originalDropTubeConnects</param>
        /// <param name="originalAllowsHeadTo">originalAllowsHeadTo</param>
        /// <param name="originalRollerGap">originalRollerGap</param>
        /// <param name="originalHeightNeeded">originalHeightNeeded</param>
        /// <param name="originalAvailable">originalAvailable</param>
        /// <param name="originalHoistHeight">originalHoistHeight</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalResinsLabel">originalResinsLabel</param>
        /// <param name="originalDrumContainsLabel">originalDrumContainsLabel</param>
        /// <param name="originalLinerTubeLabel">originalLinerTubeLabel</param>
        /// <param name="originalForLbDrumsLabel">originalForLbDrumsLabel</param>
        /// <param name="originalNetResinLabel">originalNetResinLabel</param>
        /// <param name="originalCatalystLabel">originalCatalystLabel</param>        
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newLinerTube">newLinerTube</param>
        /// <param name="newResinId">newResinId</param>
        /// <param name="newExcessResin">newExcessResin</param>
        /// <param name="newPoundsDrums">newPoundsDrums</param>
        /// <param name="newDrumDiameter">newDrumDiameter</param>
        /// <param name="newHoistMaximumHeight">newHoistMaximumHeight</param>
        /// <param name="newHoistMinimumHeight">newHoistMinimumHeight</param>
        /// <param name="newDownDropTubeLenght">newDownDropTubeLenght</param>
        /// <param name="newPumpHeightAboveGround">newPumpHeightAboveGround</param>
        /// <param name="newTubeResinToFeltFactor">newTubeResinToFeltFactor</param>
        /// <param name="newDateOfSheet">newDateOfSheet</param>
        /// <param name="newEmployeeId">newEmployeeId</param>
        /// <param name="newRunDetails">newRunDetails</param>
        /// <param name="newRunDetails2">newRunDetails2</param>
        /// <param name="newWetOutDate">newWetOutDate</param>
        /// <param name="newInstallDate">newInstallDate</param>
        /// <param name="newThickness">newThickness</param>
        /// <param name="newLengthToLine">newLengthToLine</param>
        /// <param name="newPlusExtra">newPlusExtra</param>
        /// <param name="newForTurnOffset">newForTurnOffset</param>
        /// <param name="newLengthToWetOut">newLengthToWetOut</param>
        /// <param name="newTubeMaxColdHead">newTubeMaxColdHead</param>
        /// <param name="newTubeMaxColdHeadPsi">newTubeMaxColdHeadPsi</param>
        /// <param name="newTubeMaxHotHead">newTubeMaxHotHead</param>
        /// <param name="newTubeMaxHotHeadPsi">newTubeMaxHotHeadPsi</param>
        /// <param name="newTubeIdealHead">newTubeIdealHead</param>
        /// <param name="newTubeIdealHeadPsi">newTubeIdealHeadPsi</param>
        /// <param name="newNetResinForTube">newNetResinForTube</param>
        /// <param name="newNetResinForTubeUsgals">newNetResinForTubeUsgals</param>
        /// <param name="newNetResinForTubeDrumsIns">newNetResinForTubeDrumsIns</param>
        /// <param name="newNetResinForTubeLbsFt">newNetResinForTubeLbsFt</param>
        /// <param name="newNetResinForTubeUsgFt">newNetResinForTubeUsgFt>
        /// <param name="newExtraResinForMix">newExtraResinForMix</param>
        /// <param name="newExtraLbsForMix">newExtraLbsForMix</param>
        /// <param name="newTotalMixQuantity">newTotalMixQuantity</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityDrumsIns">newTotalMixQuantityDrumsIns</param>
        /// <param name="newInversionType">newInversionType>
        /// <param name="newDepthOfInversionMH">newDepthOfInversionMH</param>
        /// <param name="newTubeForColumn">newTubeForColumn</param>
        /// <param name="newTubeForStartDry">newTubeForStartDry</param>
        /// <param name="newTotalTube">newTotalTube</param>
        /// <param name="newDropTubeConnects">newDropTubeConnects</param>
        /// <param name="newAllowsHeadTo">newAllowsHeadTo</param>
        /// <param name="newRollerGap">newRollerGap</param>
        /// <param name="newHeightNeeded">newHeightNeeded</param>
        /// <param name="newAvailable">newAvailable</param>
        /// <param name="newHoistHeight">newHoistHeight</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newResinsLabel">newResinsLabel</param>
        /// <param name="newDrumContainsLabel">newDrumContainsLabel</param>
        /// <param name="newLinerTubeLabel">newLinerTubeLabel</param>
        /// <param name="newForLbDrumsLabel">newForLbDrumsLabel</param>
        /// <param name="newNetResinLabel">newNetResinLabel</param>
        /// <param name="newCatalystLabel">newCatalystLabel</param> 
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalWorkId, string originalLinerTube, int originalResinId, decimal originalExcessResin, string originalPoundsDrums, decimal originalDrumDiameter, decimal originalHoistMaximumHeight, decimal originalHoistMinimumHeight, decimal originalDownDropTubeLenght, decimal originalPumpHeightAboveGround, int originalTubeResinToFeltFactor, DateTime originalDateOfSheet, int originalEmployeeId, string originalRunDetails, string originalRunDetails2, DateTime originalWetOutDate, DateTime? originalInstallDate, string originalThickness, decimal originalLengthToLine, decimal originalPlusExtra, decimal originalForTurnOffset, decimal originalLengthToWetOut, decimal originalTubeMaxColdHead, decimal originalTubeMaxColdHeadPsi, decimal originalTubeMaxHotHead, decimal originalTubeMaxHotHeadPsi, decimal originalTubeIdealHead, decimal originalTubeIdealHeadPsi, decimal originalNetResinForTube, decimal originalNetResinForTubeUsgals, string  originalNetResinForTubeDrumsIns, decimal originalNetResinForTubeLbsFt, decimal originalNetResinForTubeUsgFt, int originalExtraResinForMix, decimal originalExtraLbsForMix, decimal originalTotalMixQuantity, decimal originalTotalMixQuantityUsgals,  string originalTotalMixQuantityDrumsIns, string originalInversionType, decimal originalDepthOfInversionMH, decimal originalTubeForColumn, decimal originalTubeForStartDry, decimal originalTotalTube, string originalDropTubeConnects, decimal originalAllowsHeadTo, decimal originalRollerGap, decimal originalHeightNeeded, string originalAvailable, string originalHoistHeight, string originalComments, string originalResinsLabel, string originalDrumContainsLabel, string originalLinerTubeLabel, string originalForLbDrumsLabel, string originalNetResinLabel, string originalCatalystLabel,  bool originalDeleted, int originalCompanyId, int newWorkId,  string newLinerTube, int newResinId, decimal newExcessResin, string newPoundsDrums, decimal newDrumDiameter, decimal newHoistMaximumHeight, decimal newHoistMinimumHeight, decimal newDownDropTubeLenght, decimal newPumpHeightAboveGround, int newTubeResinToFeltFactor, DateTime newDateOfSheet, int newEmployeeId, string newRunDetails, string newRunDetails2, DateTime newWetOutDate, DateTime? newInstallDate, string newThickness, decimal newLengthToLine, decimal newPlusExtra, decimal newForTurnOffset, decimal newLengthToWetOut, decimal newTubeMaxColdHead, decimal newTubeMaxColdHeadPsi, decimal newTubeMaxHotHead, decimal newTubeMaxHotHeadPsi, decimal newTubeIdealHead, decimal newTubeIdealHeadPsi, decimal newNetResinForTube, decimal newNetResinForTubeUsgals, string  newNetResinForTubeDrumsIns, decimal newNetResinForTubeLbsFt, decimal newNetResinForTubeUsgFt, int newExtraResinForMix, decimal newExtraLbsForMix, decimal newTotalMixQuantity, decimal newTotalMixQuantityUsgals,  string newTotalMixQuantityDrumsIns, string newInversionType, decimal newDepthOfInversionMH, decimal newTubeForColumn, decimal newTubeForStartDry, decimal newTotalTube, string newDropTubeConnects, decimal newAllowsHeadTo, decimal newRollerGap, decimal newHeightNeeded, string newAvailable, string newHoistHeight, string newComments,  string newResinsLabel, string newDrumContainsLabel, string newLinerTubeLabel, string newForLbDrumsLabel, string newNetResinLabel, string newCatalystLabel,  bool newDeleted, int newCompanyId)                                                  
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", originalWorkId);
            SqlParameter originalLinerTubeParameter = new SqlParameter("Original_LinerTube", originalLinerTube.Trim());
            SqlParameter originalResinIdParameter = new SqlParameter("Original_ResinID", originalResinId);
            SqlParameter originalExcessResinParameter = new SqlParameter("Original_ExcessResin", originalExcessResin);
            SqlParameter originalPoundsDrumsParameter = new SqlParameter("Original_PoundsDrums", originalPoundsDrums);
            SqlParameter originalDrumDiameterParameter = new SqlParameter("Original_DrumDiameter", originalDrumDiameter);
            SqlParameter originalHoistMaximumHeightParameter = new SqlParameter("Original_HoistMaximumHeight", originalHoistMaximumHeight);
            SqlParameter originalHoistMinimumHeightParameter = new SqlParameter("Original_HoistMinimumHeight", originalHoistMinimumHeight);
            SqlParameter originalDownDropTubeLenghtParameter = new SqlParameter("Original_DownDropTubeLenght", originalDownDropTubeLenght);
            SqlParameter originalPumpHeightAboveGroundParameter = new SqlParameter("Original_PumpHeightAboveGround", originalPumpHeightAboveGround);
            SqlParameter originalTubeResinToFeltFactorParameter = new SqlParameter("Original_TubeResinToFeltFactor", originalTubeResinToFeltFactor);
            SqlParameter originalDateOfSheetParameter = new SqlParameter("Original_DateOfSheet", originalDateOfSheet);
            SqlParameter originalEmployeeIdParameter = new SqlParameter("Original_EmployeeID", originalEmployeeId);
            SqlParameter originalRunDetailsParameter = new SqlParameter("Original_RunDetails", originalRunDetails.Trim());
            SqlParameter originalRunDetails2Parameter = new SqlParameter("Original_RunDetails2", originalRunDetails2.Trim());
            SqlParameter originalWetOutDateParameter = new SqlParameter("Original_WetOutDate", originalWetOutDate);
            SqlParameter originalInstallDateParameter = (originalInstallDate.HasValue) ? new SqlParameter("Original_InstallDate", originalInstallDate) : new SqlParameter("Original_InstallDate", DBNull.Value);            
            SqlParameter originalThicknessParameter = new SqlParameter("Original_Thickness", originalThickness.Trim());
            SqlParameter originalLengthToLineParameter = new SqlParameter("Original_LengthToLine", originalLengthToLine);
            SqlParameter originalPlusExtraParameter = new SqlParameter("Original_PlusExtra", originalPlusExtra);
            SqlParameter originalForTurnOffsetParameter = new SqlParameter("Original_ForTurnOffset", originalForTurnOffset);
            SqlParameter originalLengthToWetOutParameter = new SqlParameter("Original_LengthToWetOut", originalLengthToWetOut);
            SqlParameter originalTubeMaxColdHeadParameter = new SqlParameter("Original_TubeMaxColdHead", originalTubeMaxColdHead);
            SqlParameter originalTubeMaxColdHeadPsiParameter = new SqlParameter("Original_TubeMaxColdHeadPsi", originalTubeMaxColdHeadPsi);
            SqlParameter originalTubeMaxHotHeadParameter = new SqlParameter("Original_TubeMaxHotHead", originalTubeMaxHotHead);
            SqlParameter originalTubeMaxHotHeadPsiParameter = new SqlParameter("Original_TubeMaxHotHeadPsi", originalTubeMaxHotHeadPsi);
            SqlParameter originalTubeIdealHeadParameter = new SqlParameter("Original_TubeIdealHead", originalTubeIdealHead);
            SqlParameter originalTubeIdealHeadPsiParameter = new SqlParameter("Original_TubeIdealHeadPsi", originalTubeIdealHeadPsi);
            SqlParameter originalNetResinForTubeParameter = new SqlParameter("Original_NetResinForTube", originalNetResinForTube);
            SqlParameter originalNetResinForTubeUsgalsParameter = new SqlParameter("Original_NetResinForTubeUsgals", originalNetResinForTubeUsgals);
            SqlParameter originalNetResinForTubeDrumsInsParameter = new SqlParameter("Original_NetResinForTubeDrumsIns", originalNetResinForTubeDrumsIns.Trim());
            SqlParameter originalNetResinForTubeLbsFtParameter = new SqlParameter("Original_NetResinForTubeLbsFt", originalNetResinForTubeLbsFt);
            SqlParameter originalNetResinForTubeUsgFtParameter = new SqlParameter("Original_NetResinForTubeUsgFt", originalNetResinForTubeUsgFt);
            SqlParameter originalExtraResinForMixParameter = new SqlParameter("Original_ExtraResinForMix", originalExtraResinForMix);
            SqlParameter originalExtraLbsForMixParameter = new SqlParameter("Original_ExtraLbsForMix", originalExtraLbsForMix);
            SqlParameter originalTotalMixQuantityParameter = new SqlParameter("Original_TotalMixQuantity", originalTotalMixQuantity);
            SqlParameter originalTotalMixQuantityUsgalsParameter = new SqlParameter("Original_TotalMixQuantityUsgals", originalTotalMixQuantityUsgals);
            SqlParameter originalTotalMixQuantityDrumsInsParameter = new SqlParameter("Original_TotalMixQuantityDrumsIns", originalTotalMixQuantityDrumsIns.Trim());
            SqlParameter originalInversionTypeParameter = new SqlParameter("Original_InversionType", originalInversionType.Trim());
            SqlParameter originalDepthOfInversionMHParameter = new SqlParameter("Original_DepthOfInversionMH", originalDepthOfInversionMH);
            SqlParameter originalTubeForColumnParameter = new SqlParameter("Original_TubeForColumn", originalTubeForColumn);
            SqlParameter originalTubeForStartDryParameter = new SqlParameter("Original_TubeForStartDry", originalTubeForStartDry);
            SqlParameter originalTotalTubeParameter = new SqlParameter("Original_TotalTube", originalTotalTube);
            SqlParameter originalDropTubeConnectsParameter = new SqlParameter("Original_DropTubeConnects", originalDropTubeConnects.Trim());
            SqlParameter originalAllowsHeadToParameter = new SqlParameter("Original_AllowsHeadTo", originalAllowsHeadTo);
            SqlParameter originalRollerGapParameter = new SqlParameter("Original_RollerGap", originalRollerGap);
            SqlParameter originalHeightNeededParameter = new SqlParameter("Original_HeightNeeded", originalHeightNeeded);
            SqlParameter originalAvailableParameter = new SqlParameter("Original_Available", originalAvailable.Trim());
            SqlParameter originalHoistHeightParameter = new SqlParameter("Original_HoistHeight", originalHoistHeight.Trim());            
            SqlParameter originalCommentsParameter = (originalComments.Trim() != "") ? new SqlParameter("Original_Comments", originalComments.Trim()) : new SqlParameter("Original_Comments", DBNull.Value);
            SqlParameter originalResinsLabelParameter = new SqlParameter("Original_ResinsLabel", originalResinsLabel.Trim());
            SqlParameter originalDrumContainsLabelParameter = new SqlParameter("Original_DrumContainsLabel", originalDrumContainsLabel.Trim());
            SqlParameter originalLinerTubeLabelParameter = new SqlParameter("Original_LinerTubeLabel", originalLinerTubeLabel.Trim());
            SqlParameter originalForLbDrumsLabelParameter = new SqlParameter("Original_ForLbDrumsLabel", originalForLbDrumsLabel.Trim());
            SqlParameter originalNetResinLabelParameter = new SqlParameter("Original_NetResinLabel", originalNetResinLabel.Trim());
            SqlParameter originalCatalystLabelParameter = new SqlParameter("Original_CatalystLabel", originalCatalystLabel.Trim());                                     
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", newWorkId);
            SqlParameter newLinerTubeParameter = new SqlParameter("LinerTube", newLinerTube.Trim());
            SqlParameter newResinIdParameter = new SqlParameter("ResinID", newResinId);
            SqlParameter newExcessResinParameter = new SqlParameter("ExcessResin", newExcessResin);
            SqlParameter newPoundsDrumsParameter = new SqlParameter("PoundsDrums", newPoundsDrums);
            SqlParameter newDrumDiameterParameter = new SqlParameter("DrumDiameter", newDrumDiameter);
            SqlParameter newHoistMaximumHeightParameter = new SqlParameter("HoistMaximumHeight", newHoistMaximumHeight);
            SqlParameter newHoistMinimumHeightParameter = new SqlParameter("HoistMinimumHeight", newHoistMinimumHeight);
            SqlParameter newDownDropTubeLenghtParameter = new SqlParameter("DownDropTubeLenght", newDownDropTubeLenght);
            SqlParameter newPumpHeightAboveGroundParameter = new SqlParameter("PumpHeightAboveGround", newPumpHeightAboveGround);
            SqlParameter newTubeResinToFeltFactorParameter = new SqlParameter("TubeResinToFeltFactor", newTubeResinToFeltFactor);
            SqlParameter newDateOfSheetParameter = new SqlParameter("DateOfSheet", newDateOfSheet);
            SqlParameter newEmployeeIdParameter = new SqlParameter("EmployeeID", newEmployeeId);
            SqlParameter newRunDetailsParameter = new SqlParameter("RunDetails", newRunDetails.Trim());
            SqlParameter newRunDetails2Parameter = new SqlParameter("RunDetails2", newRunDetails2.Trim());
            SqlParameter newWetOutDateParameter = new SqlParameter("WetOutDate", newWetOutDate);
            SqlParameter newInstallDateParameter = (newInstallDate.HasValue) ? new SqlParameter("InstallDate", newInstallDate) : new SqlParameter("InstallDate", DBNull.Value);            
            SqlParameter newThicknessParameter = new SqlParameter("Thickness", newThickness.Trim());
            SqlParameter newLengthToLineParameter = new SqlParameter("LengthToLine", newLengthToLine);
            SqlParameter newPlusExtraParameter = new SqlParameter("PlusExtra", newPlusExtra);
            SqlParameter newForTurnOffsetParameter = new SqlParameter("ForTurnOffset", newForTurnOffset);
            SqlParameter newLengthToWetOutParameter = new SqlParameter("LengthToWetOut", newLengthToWetOut);
            SqlParameter newTubeMaxColdHeadParameter = new SqlParameter("TubeMaxColdHead", newTubeMaxColdHead);
            SqlParameter newTubeMaxColdHeadPsiParameter = new SqlParameter("TubeMaxColdHeadPsi", newTubeMaxColdHeadPsi);
            SqlParameter newTubeMaxHotHeadParameter = new SqlParameter("TubeMaxHotHead", newTubeMaxHotHead);
            SqlParameter newTubeMaxHotHeadPsiParameter = new SqlParameter("TubeMaxHotHeadPsi", newTubeMaxHotHeadPsi);
            SqlParameter newTubeIdealHeadParameter = new SqlParameter("TubeIdealHead", newTubeIdealHead);
            SqlParameter newTubeIdealHeadPsiParameter = new SqlParameter("TubeIdealHeadPsi", newTubeIdealHeadPsi);
            SqlParameter newNetResinForTubeParameter = new SqlParameter("NetResinForTube", newNetResinForTube);
            SqlParameter newNetResinForTubeUsgalsParameter = new SqlParameter("NetResinForTubeUsgals", newNetResinForTubeUsgals);
            SqlParameter newNetResinForTubeDrumsInsParameter = new SqlParameter("NetResinForTubeDrumsIns", newNetResinForTubeDrumsIns.Trim());
            SqlParameter newNetResinForTubeLbsFtParameter = new SqlParameter("NetResinForTubeLbsFt", newNetResinForTubeLbsFt);
            SqlParameter newNetResinForTubeUsgFtParameter = new SqlParameter("NetResinForTubeUsgFt", newNetResinForTubeUsgFt);
            SqlParameter newExtraResinForMixParameter = new SqlParameter("ExtraResinForMix", newExtraResinForMix);
            SqlParameter newExtraLbsForMixParameter = new SqlParameter("ExtraLbsForMix", newExtraLbsForMix);
            SqlParameter newTotalMixQuantityParameter = new SqlParameter("TotalMixQuantity", newTotalMixQuantity);
            SqlParameter newTotalMixQuantityUsgalsParameter = new SqlParameter("TotalMixQuantityUsgals", newTotalMixQuantityUsgals);
            SqlParameter newTotalMixQuantityDrumsInsParameter = new SqlParameter("TotalMixQuantityDrumsIns", newTotalMixQuantityDrumsIns.Trim());
            SqlParameter newInversionTypeParameter = new SqlParameter("InversionType", newInversionType.Trim());
            SqlParameter newDepthOfInversionMHParameter = new SqlParameter("DepthOfInversionMH", newDepthOfInversionMH);
            SqlParameter newTubeForColumnParameter = new SqlParameter("TubeForColumn", newTubeForColumn);
            SqlParameter newTubeForStartDryParameter = new SqlParameter("TubeForStartDry", newTubeForStartDry);
            SqlParameter newTotalTubeParameter = new SqlParameter("TotalTube", newTotalTube);
            SqlParameter newDropTubeConnectsParameter = new SqlParameter("DropTubeConnects", newDropTubeConnects.Trim());
            SqlParameter newAllowsHeadToParameter = new SqlParameter("AllowsHeadTo", newAllowsHeadTo);
            SqlParameter newRollerGapParameter = new SqlParameter("RollerGap", newRollerGap);
            SqlParameter newHeightNeededParameter = new SqlParameter("HeightNeeded", newHeightNeeded);
            SqlParameter newAvailableParameter = new SqlParameter("Available", newAvailable.Trim());
            SqlParameter newHoistHeightParameter = new SqlParameter("HoistHeight", newHoistHeight.Trim());            
            SqlParameter newCommentsParameter = (newComments.Trim() != "") ? new SqlParameter("Comments", newComments.Trim()) : new SqlParameter("Comments", DBNull.Value);

            SqlParameter newResinsLabelParameter = new SqlParameter("ResinsLabel", newResinsLabel.Trim());
            SqlParameter newDrumContainsLabelParameter = new SqlParameter("DrumContainsLabel", newDrumContainsLabel.Trim());
            SqlParameter newLinerTubeLabelParameter = new SqlParameter("LinerTubeLabel", newLinerTubeLabel.Trim());
            SqlParameter newForLbDrumsLabelParameter = new SqlParameter("ForLbDrumsLabel", newForLbDrumsLabel.Trim());
            SqlParameter newNetResinLabelParameter = new SqlParameter("NetResinLabel", newNetResinLabel.Trim());
            SqlParameter newCatalystLabelParameter = new SqlParameter("CatalystLabel", newCatalystLabel.Trim());                                     
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_WETOUT] SET [WorkID] = @WorkID, [LinerTub" +
                "e] = @LinerTube, [ResinID] = @ResinID, [ExcessResin] = @ExcessResin, [PoundsDrum" +
                "s] = @PoundsDrums, [DrumDiameter] = @DrumDiameter, [HoistMaximumHeight] = @Hoist" +
                "MaximumHeight, [HoistMinimumHeight] = @HoistMinimumHeight, [DownDropTubeLenght] " +
                "= @DownDropTubeLenght, [PumpHeightAboveGround] = @PumpHeightAboveGround, [TubeRe" +
                "sinToFeltFactor] = @TubeResinToFeltFactor, [DateOfSheet] = @DateOfSheet, [Employ" +
                "eeID] = @EmployeeID, [RunDetails] = @RunDetails, [RunDetails2] = @RunDetails2, [" +
                "WetOutDate] = @WetOutDate, [InstallDate] = @InstallDate, [Thickness] = @Thicknes" +
                "s, [LengthToLine] = @LengthToLine, [PlusExtra] = @PlusExtra, [ForTurnOffset] = @" +
                "ForTurnOffset, [LengthToWetOut] = @LengthToWetOut, [TubeMaxColdHead] = @TubeMaxC" +
                "oldHead, [TubeMaxColdHeadPsi] = @TubeMaxColdHeadPsi, [TubeMaxHotHead] = @TubeMax" +
                "HotHead, [TubeMaxHotHeadPsi] = @TubeMaxHotHeadPsi, [TubeIdealHead] = @TubeIdealH" +
                "ead, [TubeIdealHeadPsi] = @TubeIdealHeadPsi, [NetResinForTube] = @NetResinForTub" +
                "e, [NetResinForTubeUsgals] = @NetResinForTubeUsgals, [NetResinForTubeDrumsIns] =" +
                " @NetResinForTubeDrumsIns, [NetResinForTubeLbsFt] = @NetResinForTubeLbsFt, [NetR" +
                "esinForTubeUsgFt] = @NetResinForTubeUsgFt, [ExtraResinForMix] = @ExtraResinForMi" +
                "x, [ExtraLbsForMix] = @ExtraLbsForMix, [TotalMixQuantity] = @TotalMixQuantity, [" +
                "TotalMixQuantityUsgals] = @TotalMixQuantityUsgals, [TotalMixQuantityDrumsIns] = " +
                "@TotalMixQuantityDrumsIns, [InversionType] = @InversionType, [DepthOfInversionMH" +
                "] = @DepthOfInversionMH, [TubeForColumn] = @TubeForColumn, [TubeForStartDry] = @" +
                "TubeForStartDry, [TotalTube] = @TotalTube, [DropTubeConnects] = @DropTubeConnect" +
                "s, [AllowsHeadTo] = @AllowsHeadTo, [RollerGap] = @RollerGap, [HeightNeeded] = @H" +
                "eightNeeded, [Available] = @Available, [HoistHeight] = @HoistHeight, [Comments] " +
                "= @Comments, [ResinsLabel] = @ResinsLabel, [DrumContainsLabel] = @DrumContainsLa" +
                "bel, [LinerTubeLabel] = @LinerTubeLabel, [ForLbDrumsLabel] = @ForLbDrumsLabel, [" +
                "NetResinLabel] = @NetResinLabel, [CatalystLabel] = @CatalystLabel " +
                " WHERE (([WorkID] = @Original_WorkID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID)) ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalLinerTubeParameter, originalResinIdParameter, originalExcessResinParameter, originalPoundsDrumsParameter, originalDrumDiameterParameter, originalHoistMaximumHeightParameter, originalHoistMinimumHeightParameter, originalDownDropTubeLenghtParameter, originalPumpHeightAboveGroundParameter, originalTubeResinToFeltFactorParameter, originalDateOfSheetParameter, originalEmployeeIdParameter, originalRunDetailsParameter, originalRunDetails2Parameter, originalWetOutDateParameter, originalInstallDateParameter, originalThicknessParameter, originalLengthToLineParameter, originalPlusExtraParameter, originalForTurnOffsetParameter, originalLengthToWetOutParameter, originalTubeMaxColdHeadParameter, originalTubeMaxColdHeadPsiParameter, originalTubeMaxHotHeadParameter, originalTubeMaxHotHeadPsiParameter, originalTubeIdealHeadParameter, originalTubeIdealHeadPsiParameter, originalNetResinForTubeParameter, originalNetResinForTubeUsgalsParameter, originalNetResinForTubeDrumsInsParameter, originalNetResinForTubeLbsFtParameter, originalNetResinForTubeUsgFtParameter, originalExtraResinForMixParameter, originalExtraLbsForMixParameter, originalTotalMixQuantityParameter, originalTotalMixQuantityUsgalsParameter, originalTotalMixQuantityDrumsInsParameter, originalInversionTypeParameter, originalDepthOfInversionMHParameter, originalTubeForColumnParameter, originalTubeForStartDryParameter, originalTotalTubeParameter, originalDropTubeConnectsParameter, originalAllowsHeadToParameter, originalRollerGapParameter, originalHeightNeededParameter, originalAvailableParameter, originalHoistHeightParameter, originalCommentsParameter, originalResinsLabelParameter, originalDrumContainsLabelParameter, originalLinerTubeLabelParameter, originalForLbDrumsLabelParameter, originalNetResinLabelParameter, originalCatalystLabelParameter, originalDeletedParameter, originalCompanyIdParameter, newWorkIdParameter, newLinerTubeParameter, newResinIdParameter, newExcessResinParameter, newPoundsDrumsParameter, newDrumDiameterParameter, newHoistMaximumHeightParameter, newHoistMinimumHeightParameter, newDownDropTubeLenghtParameter, newPumpHeightAboveGroundParameter, newTubeResinToFeltFactorParameter, newDateOfSheetParameter, newEmployeeIdParameter, newRunDetailsParameter, newRunDetails2Parameter, newWetOutDateParameter, newInstallDateParameter, newThicknessParameter, newLengthToLineParameter, newPlusExtraParameter, newForTurnOffsetParameter, newLengthToWetOutParameter, newTubeMaxColdHeadParameter, newTubeMaxColdHeadPsiParameter, newTubeMaxHotHeadParameter, newTubeMaxHotHeadPsiParameter, newTubeIdealHeadParameter, newTubeIdealHeadPsiParameter, newNetResinForTubeParameter, newNetResinForTubeUsgalsParameter, newNetResinForTubeDrumsInsParameter, newNetResinForTubeLbsFtParameter, newNetResinForTubeUsgFtParameter, newExtraResinForMixParameter, newExtraLbsForMixParameter, newTotalMixQuantityParameter, newTotalMixQuantityUsgalsParameter, newTotalMixQuantityDrumsInsParameter, newInversionTypeParameter, newDepthOfInversionMHParameter, newTubeForColumnParameter, newTubeForStartDryParameter, newTotalTubeParameter, newDropTubeConnectsParameter, newAllowsHeadToParameter, newRollerGapParameter, newHeightNeededParameter, newAvailableParameter, newHoistHeightParameter, newCommentsParameter, newResinsLabelParameter, newDrumContainsLabelParameter, newLinerTubeLabelParameter, newForLbDrumsLabelParameter, newNetResinLabelParameter, newCatalystLabelParameter, newDeletedParameter, newCompanyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete wet out info (direct to DB)
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Delete(int originalWorkId, int originalCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("@Original_WorkID", originalWorkId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_WETOUT] SET  [Deleted] = @Deleted  " +
                             " WHERE (([WorkID] = @Original_WorkID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }




    }
}
