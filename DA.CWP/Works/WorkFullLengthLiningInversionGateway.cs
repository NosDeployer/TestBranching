using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningInversionGateway
    /// </summary>
    public class WorkFullLengthLiningInversionGateway: DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningInversionGateway()
            : base("LFS_WORK_FULLLENGTHLINING_INVERSION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningInversionGateway(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_INVERSION")
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
            tableMapping.DataSetTable = "LFS_WORK_FULLLENGTHLINING_INVERSION";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("PipeType", "PipeType");
            tableMapping.ColumnMappings.Add("PipeCondition", "PipeCondition");
            tableMapping.ColumnMappings.Add("GroundMoisture", "GroundMoisture");
            tableMapping.ColumnMappings.Add("BoilerSize", "BoilerSize");
            tableMapping.ColumnMappings.Add("PumpTotalCapacity", "PumpTotalCapacity");
            tableMapping.ColumnMappings.Add("LayFlatSize", "LayFlatSize");
            tableMapping.ColumnMappings.Add("LayFlatQuantityTotal", "LayFlatQuantityTotal");
            tableMapping.ColumnMappings.Add("WaterStartTemp", "WaterStartTemp");
            tableMapping.ColumnMappings.Add("Temp1", "Temp1");
            tableMapping.ColumnMappings.Add("HoldAtT1", "HoldAtT1");
            tableMapping.ColumnMappings.Add("TempT2", "TempT2");
            tableMapping.ColumnMappings.Add("CookAtT2", "CookAtT2");
            tableMapping.ColumnMappings.Add("CoolDownFor", "CoolDownFor");
            tableMapping.ColumnMappings.Add("CoolToTemp", "CoolToTemp");
            tableMapping.ColumnMappings.Add("DropInPipeRun", "DropInPipeRun");
            tableMapping.ColumnMappings.Add("PipeSlopOf", "PipeSlopOf");
            tableMapping.ColumnMappings.Add("F45F120", "F45F120");
            tableMapping.ColumnMappings.Add("Hold", "Hold");
            tableMapping.ColumnMappings.Add("F120F185", "F120F185");
            tableMapping.ColumnMappings.Add("CookTime", "CookTime");
            tableMapping.ColumnMappings.Add("CoolTime", "CoolTime");
            tableMapping.ColumnMappings.Add("AproxTotal", "AproxTotal");
            tableMapping.ColumnMappings.Add("WaterChangesPerHour", "WaterChangesPerHour");
            tableMapping.ColumnMappings.Add("ReturnWaterVelocity", "ReturnWaterVelocity");
            tableMapping.ColumnMappings.Add("LayflatBackPressure", "LayflatBackPressure");
            tableMapping.ColumnMappings.Add("PumpLiftAtIdealHead", "PumpLiftAtIdealHead");
            tableMapping.ColumnMappings.Add("WaterToFillLinerColumn", "WaterToFillLinerColumn");
            tableMapping.ColumnMappings.Add("WaterPerFit", "WaterPerFit");
            tableMapping.ColumnMappings.Add("InstallationResults", "InstallationResults");
            tableMapping.ColumnMappings.Add("LinerTubeLabel", "LinerTubeLabel");
            tableMapping.ColumnMappings.Add("HeadsIdealLabel", "HeadsIdealLabel");
            tableMapping.ColumnMappings.Add("PumpingAndCirculationLabel", "PumpingAndCirculationLabel");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_WORK_FULLLENGTHLINING_INVERSION] WHERE (([WorkID] = @Origi" +
                "nal_WorkID) AND ([PipeType] = @Original_PipeType) AND ([PipeCondition] = @Origin" +
                "al_PipeCondition) AND ([GroundMoisture] = @Original_GroundMoisture) AND ([Boiler" +
                "Size] = @Original_BoilerSize) AND ([PumpTotalCapacity] = @Original_PumpTotalCapa" +
                "city) AND ([LayFlatSize] = @Original_LayFlatSize) AND ([LayFlatQuantityTotal] = " +
                "@Original_LayFlatQuantityTotal) AND ([WaterStartTemp] = @Original_WaterStartTemp" +
                ") AND ([Temp1] = @Original_Temp1) AND ([HoldAtT1] = @Original_HoldAtT1) AND ([Te" +
                "mpT2] = @Original_TempT2) AND ([CookAtT2] = @Original_CookAtT2) AND ([CoolDownFo" +
                "r] = @Original_CoolDownFor) AND ([CoolToTemp] = @Original_CoolToTemp) AND ([Drop" +
                "InPipeRun] = @Original_DropInPipeRun) AND ([PipeSlopOf] = @Original_PipeSlopOf) " +
                "AND ([F45F120] = @Original_F45F120) AND ([Hold] = @Original_Hold) AND ([F120F185" +
                "] = @Original_F120F185) AND ([CookTime] = @Original_CookTime) AND ([CoolTime] = " +
                "@Original_CoolTime) AND ([AproxTotal] = @Original_AproxTotal) AND ([WaterChanges" +
                "PerHour] = @Original_WaterChangesPerHour) AND ([ReturnWaterVelocity] = @Original" +
                "_ReturnWaterVelocity) AND ([LayflatBackPressure] = @Original_LayflatBackPressure" +
                ") AND ([PumpLiftAtIdealHead] = @Original_PumpLiftAtIdealHead) AND ([WaterToFillL" +
                "inerColumn] = @Original_WaterToFillLinerColumn) AND ([WaterPerFit] = @Original_W" +
                "aterPerFit) AND ([LinerTubeLabel] = @Original_LinerTubeLabel) AND ([HeadsIdealLa" +
                "bel] = @Original_HeadsIdealLabel) AND ([PumpingAndCirculationLabel] = @Original_" +
                "PumpingAndCirculationLabel) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID" +
                "] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PipeType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PipeCondition", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeCondition", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GroundMoisture", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroundMoisture", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BoilerSize", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BoilerSize", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PumpTotalCapacity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpTotalCapacity", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LayFlatSize", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LayFlatSize", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LayFlatQuantityTotal", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LayFlatQuantityTotal", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WaterStartTemp", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WaterStartTemp", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Temp1", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Temp1", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoldAtT1", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldAtT1", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TempT2", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TempT2", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CookAtT2", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CookAtT2", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CoolDownFor", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoolDownFor", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CoolToTemp", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoolToTemp", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DropInPipeRun", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropInPipeRun", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PipeSlopOf", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeSlopOf", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_F45F120", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "F45F120", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Hold", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Hold", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_F120F185", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "F120F185", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CookTime", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CookTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CoolTime", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoolTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AproxTotal", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AproxTotal", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WaterChangesPerHour", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WaterChangesPerHour", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ReturnWaterVelocity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReturnWaterVelocity", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LayflatBackPressure", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LayflatBackPressure", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PumpLiftAtIdealHead", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpLiftAtIdealHead", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WaterToFillLinerColumn", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WaterToFillLinerColumn", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WaterPerFit", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WaterPerFit", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LinerTubeLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerTubeLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HeadsIdealLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HeadsIdealLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PumpingAndCirculationLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpingAndCirculationLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_INVERSION] ([WorkID], [Comment], [Pi" +
                "peType], [PipeCondition], [GroundMoisture], [BoilerSize], [PumpTotalCapacity], [" +
                "LayFlatSize], [LayFlatQuantityTotal], [WaterStartTemp], [Temp1], [HoldAtT1], [Te" +
                "mpT2], [CookAtT2], [CoolDownFor], [CoolToTemp], [DropInPipeRun], [PipeSlopOf], [" +
                "F45F120], [Hold], [F120F185], [CookTime], [CoolTime], [AproxTotal], [WaterChange" +
                "sPerHour], [ReturnWaterVelocity], [LayflatBackPressure], [PumpLiftAtIdealHead], " +
                "[WaterToFillLinerColumn], [WaterPerFit], [InstallationResults], [LinerTubeLabel]" +
                ", [HeadsIdealLabel], [PumpingAndCirculationLabel], [Deleted], [COMPANY_ID]) VALU" +
                "ES (@WorkID, @Comment, @PipeType, @PipeCondition, @GroundMoisture, @BoilerSize, " +
                "@PumpTotalCapacity, @LayFlatSize, @LayFlatQuantityTotal, @WaterStartTemp, @Temp1" +
                ", @HoldAtT1, @TempT2, @CookAtT2, @CoolDownFor, @CoolToTemp, @DropInPipeRun, @Pip" +
                "eSlopOf, @F45F120, @Hold, @F120F185, @CookTime, @CoolTime, @AproxTotal, @WaterCh" +
                "angesPerHour, @ReturnWaterVelocity, @LayflatBackPressure, @PumpLiftAtIdealHead, " +
                "@WaterToFillLinerColumn, @WaterPerFit, @InstallationResults, @LinerTubeLabel, @H" +
                "eadsIdealLabel, @PumpingAndCirculationLabel, @Deleted, @COMPANY_ID);\r\nSELECT Wor" +
                "kID, Comment, PipeType, PipeCondition, GroundMoisture, BoilerSize, PumpTotalCapa" +
                "city, LayFlatSize, LayFlatQuantityTotal, WaterStartTemp, Temp1, HoldAtT1, TempT2" +
                ", CookAtT2, CoolDownFor, CoolToTemp, DropInPipeRun, PipeSlopOf, F45F120, Hold, F" +
                "120F185, CookTime, CoolTime, AproxTotal, WaterChangesPerHour, ReturnWaterVelocit" +
                "y, LayflatBackPressure, PumpLiftAtIdealHead, WaterToFillLinerColumn, WaterPerFit" +
                ", InstallationResults, LinerTubeLabel, HeadsIdealLabel, PumpingAndCirculationLab" +
                "el, Deleted, COMPANY_ID FROM LFS_WORK_FULLLENGTHLINING_INVERSION WHERE (WorkID =" +
                " @WorkID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comment", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comment", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PipeType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PipeCondition", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeCondition", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GroundMoisture", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroundMoisture", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BoilerSize", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BoilerSize", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PumpTotalCapacity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpTotalCapacity", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LayFlatSize", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LayFlatSize", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LayFlatQuantityTotal", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LayFlatQuantityTotal", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WaterStartTemp", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WaterStartTemp", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Temp1", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Temp1", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoldAtT1", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldAtT1", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TempT2", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TempT2", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CookAtT2", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CookAtT2", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoolDownFor", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoolDownFor", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoolToTemp", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoolToTemp", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DropInPipeRun", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropInPipeRun", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PipeSlopOf", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeSlopOf", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@F45F120", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "F45F120", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Hold", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Hold", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@F120F185", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "F120F185", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CookTime", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CookTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoolTime", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoolTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AproxTotal", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AproxTotal", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WaterChangesPerHour", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WaterChangesPerHour", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ReturnWaterVelocity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReturnWaterVelocity", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LayflatBackPressure", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LayflatBackPressure", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PumpLiftAtIdealHead", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpLiftAtIdealHead", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WaterToFillLinerColumn", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WaterToFillLinerColumn", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WaterPerFit", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WaterPerFit", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InstallationResults", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallationResults", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerTubeLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerTubeLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HeadsIdealLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HeadsIdealLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PumpingAndCirculationLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpingAndCirculationLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_INVERSION] SET [WorkID] = @WorkID, [Comme" +
                "nt] = @Comment, [PipeType] = @PipeType, [PipeCondition] = @PipeCondition, [Groun" +
                "dMoisture] = @GroundMoisture, [BoilerSize] = @BoilerSize, [PumpTotalCapacity] = " +
                "@PumpTotalCapacity, [LayFlatSize] = @LayFlatSize, [LayFlatQuantityTotal] = @LayF" +
                "latQuantityTotal, [WaterStartTemp] = @WaterStartTemp, [Temp1] = @Temp1, [HoldAtT" +
                "1] = @HoldAtT1, [TempT2] = @TempT2, [CookAtT2] = @CookAtT2, [CoolDownFor] = @Coo" +
                "lDownFor, [CoolToTemp] = @CoolToTemp, [DropInPipeRun] = @DropInPipeRun, [PipeSlo" +
                "pOf] = @PipeSlopOf, [F45F120] = @F45F120, [Hold] = @Hold, [F120F185] = @F120F185" +
                ", [CookTime] = @CookTime, [CoolTime] = @CoolTime, [AproxTotal] = @AproxTotal, [W" +
                "aterChangesPerHour] = @WaterChangesPerHour, [ReturnWaterVelocity] = @ReturnWater" +
                "Velocity, [LayflatBackPressure] = @LayflatBackPressure, [PumpLiftAtIdealHead] = " +
                "@PumpLiftAtIdealHead, [WaterToFillLinerColumn] = @WaterToFillLinerColumn, [Water" +
                "PerFit] = @WaterPerFit, [InstallationResults] = @InstallationResults, [LinerTube" +
                "Label] = @LinerTubeLabel, [HeadsIdealLabel] = @HeadsIdealLabel, [PumpingAndCircu" +
                "lationLabel] = @PumpingAndCirculationLabel, [Deleted] = @Deleted, [COMPANY_ID] =" +
                " @COMPANY_ID WHERE (([WorkID] = @Original_WorkID) AND ([PipeType] = @Original_Pi" +
                "peType) AND ([PipeCondition] = @Original_PipeCondition) AND ([GroundMoisture] = " +
                "@Original_GroundMoisture) AND ([BoilerSize] = @Original_BoilerSize) AND ([PumpTo" +
                "talCapacity] = @Original_PumpTotalCapacity) AND ([LayFlatSize] = @Original_LayFl" +
                "atSize) AND ([LayFlatQuantityTotal] = @Original_LayFlatQuantityTotal) AND ([Wate" +
                "rStartTemp] = @Original_WaterStartTemp) AND ([Temp1] = @Original_Temp1) AND ([Ho" +
                "ldAtT1] = @Original_HoldAtT1) AND ([TempT2] = @Original_TempT2) AND ([CookAtT2] " +
                "= @Original_CookAtT2) AND ([CoolDownFor] = @Original_CoolDownFor) AND ([CoolToTe" +
                "mp] = @Original_CoolToTemp) AND ([DropInPipeRun] = @Original_DropInPipeRun) AND " +
                "([PipeSlopOf] = @Original_PipeSlopOf) AND ([F45F120] = @Original_F45F120) AND ([" +
                "Hold] = @Original_Hold) AND ([F120F185] = @Original_F120F185) AND ([CookTime] = " +
                "@Original_CookTime) AND ([CoolTime] = @Original_CoolTime) AND ([AproxTotal] = @O" +
                "riginal_AproxTotal) AND ([WaterChangesPerHour] = @Original_WaterChangesPerHour) " +
                "AND ([ReturnWaterVelocity] = @Original_ReturnWaterVelocity) AND ([LayflatBackPre" +
                "ssure] = @Original_LayflatBackPressure) AND ([PumpLiftAtIdealHead] = @Original_P" +
                "umpLiftAtIdealHead) AND ([WaterToFillLinerColumn] = @Original_WaterToFillLinerCo" +
                "lumn) AND ([WaterPerFit] = @Original_WaterPerFit) AND ([LinerTubeLabel] = @Origi" +
                "nal_LinerTubeLabel) AND ([HeadsIdealLabel] = @Original_HeadsIdealLabel) AND ([Pu" +
                "mpingAndCirculationLabel] = @Original_PumpingAndCirculationLabel) AND ([Deleted]" +
                " = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));\r\nSELECT WorkID" +
                ", Comment, PipeType, PipeCondition, GroundMoisture, BoilerSize, PumpTotalCapacit" +
                "y, LayFlatSize, LayFlatQuantityTotal, WaterStartTemp, Temp1, HoldAtT1, TempT2, C" +
                "ookAtT2, CoolDownFor, CoolToTemp, DropInPipeRun, PipeSlopOf, F45F120, Hold, F120" +
                "F185, CookTime, CoolTime, AproxTotal, WaterChangesPerHour, ReturnWaterVelocity, " +
                "LayflatBackPressure, PumpLiftAtIdealHead, WaterToFillLinerColumn, WaterPerFit, I" +
                "nstallationResults, LinerTubeLabel, HeadsIdealLabel, PumpingAndCirculationLabel," +
                " Deleted, COMPANY_ID FROM LFS_WORK_FULLLENGTHLINING_INVERSION WHERE (WorkID = @W" +
                "orkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comment", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comment", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PipeType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PipeCondition", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeCondition", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GroundMoisture", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroundMoisture", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BoilerSize", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BoilerSize", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PumpTotalCapacity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpTotalCapacity", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LayFlatSize", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LayFlatSize", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LayFlatQuantityTotal", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LayFlatQuantityTotal", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WaterStartTemp", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WaterStartTemp", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Temp1", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Temp1", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoldAtT1", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldAtT1", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TempT2", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TempT2", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CookAtT2", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CookAtT2", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoolDownFor", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoolDownFor", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoolToTemp", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoolToTemp", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DropInPipeRun", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropInPipeRun", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PipeSlopOf", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeSlopOf", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@F45F120", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "F45F120", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Hold", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Hold", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@F120F185", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "F120F185", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CookTime", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CookTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoolTime", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoolTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AproxTotal", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AproxTotal", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WaterChangesPerHour", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WaterChangesPerHour", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ReturnWaterVelocity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReturnWaterVelocity", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LayflatBackPressure", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LayflatBackPressure", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PumpLiftAtIdealHead", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpLiftAtIdealHead", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WaterToFillLinerColumn", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WaterToFillLinerColumn", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WaterPerFit", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WaterPerFit", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InstallationResults", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InstallationResults", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerTubeLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerTubeLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HeadsIdealLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HeadsIdealLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PumpingAndCirculationLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpingAndCirculationLabel", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PipeType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PipeCondition", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeCondition", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GroundMoisture", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroundMoisture", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BoilerSize", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BoilerSize", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PumpTotalCapacity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpTotalCapacity", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LayFlatSize", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LayFlatSize", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LayFlatQuantityTotal", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LayFlatQuantityTotal", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WaterStartTemp", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WaterStartTemp", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Temp1", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Temp1", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoldAtT1", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldAtT1", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TempT2", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TempT2", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CookAtT2", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CookAtT2", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CoolDownFor", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoolDownFor", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CoolToTemp", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoolToTemp", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DropInPipeRun", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DropInPipeRun", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PipeSlopOf", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeSlopOf", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_F45F120", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "F45F120", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Hold", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Hold", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_F120F185", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "F120F185", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CookTime", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CookTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CoolTime", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoolTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AproxTotal", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AproxTotal", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WaterChangesPerHour", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WaterChangesPerHour", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ReturnWaterVelocity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReturnWaterVelocity", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LayflatBackPressure", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LayflatBackPressure", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PumpLiftAtIdealHead", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpLiftAtIdealHead", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WaterToFillLinerColumn", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WaterToFillLinerColumn", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WaterPerFit", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WaterPerFit", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LinerTubeLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerTubeLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HeadsIdealLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HeadsIdealLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PumpingAndCirculationLabel", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpingAndCirculationLabel", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            FillDataWithStoredProcedure("LFS_CWP_WORKFULLLENGTHLININGINVERSIONGATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert  inversion info (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="comment">comment</param>
        /// <param name="pipeType">pipeType</param>
        /// <param name="pipeCondition">pipeCondition</param>
        /// <param name="groundMoisture">groundMoisture</param>
        /// <param name="boilerSize">boilerSize</param>
        /// <param name="pumpTotalCapacity">pumpTotalCapacity</param>
        /// <param name="layFlatSize">layFlatSize</param>
        /// <param name="layFlatQuantityTotal">layFlatQuantityTotal</param>
        /// <param name="waterStartTemp">waterStartTemp</param>
        /// <param name="temp1">temp1</param>
        /// <param name="holdAtT1">holdAtT1</param>
        /// <param name="tempT2">tempT2</param>
        /// <param name="cookAt2">cookAt2</param>
        /// <param name="coolDownFor">coolDownFor</param>
        /// <param name="coolToTemp">coolToTemp</param>
        /// <param name="dropInPipeRun">dropInPipeRun</param>
        /// <param name="pipeSlopOf">pipeSlopOf</param>
        /// <param name="f45F120">f45F120</param>
        /// <param name="hold">hold</param>
        /// <param name="f120F185">f120F185</param>
        /// <param name="cookTime">cookTime</param>
        /// <param name="coolTime">coolTime</param>
        /// <param name="aproxTotal">aproxTotal</param>
        /// <param name="waterChangesPerHour">waterChangesPerHour</param>
        /// <param name="returnWaterVelocity">returnWaterVelocity</param>
        /// <param name="layflatBackPressure">layflatBackPressure</param>
        /// <param name="pumpLiftAtIdealHead">pumpLiftAtIdealHead</param>
        /// <param name="waterToFillLinerColumn">waterToFillLinerColumn</param>
        /// <param name="waterPerFit">waterPerFit</param>
        /// <param name="installationResults">installationResults</param>
        /// <param name="linerTubeLabel">linerTubeLabel</param>
        /// <param name="headsIdealLabel">headsIdealLabel</param>
        /// <param name="pumpingAndCirculationLabel">pumpingAndCirculationLabel</param>
        /// <param name="deleted">deleted</param>       
        /// <param name="companyId">companyId</param>        
        /// <returns>rowsAffected</returns>
        public int Insert(int workId, string comment, string pipeType, string pipeCondition, string groundMoisture, decimal boilerSize, decimal pumpTotalCapacity, decimal layFlatSize, decimal layFlatQuantityTotal, decimal waterStartTemp, decimal temp1, decimal holdAtT1, decimal tempT2, decimal cookAt2, decimal coolDownFor, decimal coolToTemp, decimal dropInPipeRun, decimal pipeSlopOf, decimal f45F120, decimal hold, decimal f120F185, decimal cookTime, decimal coolTime, decimal aproxTotal, decimal waterChangesPerHour, decimal returnWaterVelocity, decimal layflatBackPressure, decimal pumpLiftAtIdealHead, decimal waterToFillLinerColumn, decimal waterPerFit, string installationResults, string linerTubeLabel, string headsIdealLabel, string pumpingAndCirculationLabel, bool deleted, int companyId)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);            
            SqlParameter commentParameter = (comment.Trim() != "") ? new SqlParameter("Comment", comment.Trim()) : new SqlParameter("Comment", DBNull.Value);            
            SqlParameter pipeTypeParameter = new SqlParameter("PipeType", pipeType);
            SqlParameter pipeConditionParameter = new SqlParameter("PipeCondition", pipeCondition);
            SqlParameter groundMoistureParameter = new SqlParameter("GroundMoisture", groundMoisture);
            SqlParameter boilerSizeParameter = new SqlParameter("BoilerSize", boilerSize);
            SqlParameter pumpTotalCapacityParameter = new SqlParameter("PumpTotalCapacity", pumpTotalCapacity);
            SqlParameter layFlatSizeParameter = new SqlParameter("LayFlatSize", layFlatSize);
            SqlParameter layFlatQuantityTotalParameter = new SqlParameter("LayFlatQuantityTotal", layFlatQuantityTotal);
            SqlParameter waterStartTempParameter = new SqlParameter("WaterStartTemp", waterStartTemp);
            SqlParameter temp1Parameter = new SqlParameter("Temp1", temp1);
            SqlParameter holdAtT1Parameter = new SqlParameter("HoldAtT1", holdAtT1);
            SqlParameter tempT2Parameter = new SqlParameter("TempT2", tempT2);
            SqlParameter cookAt2Parameter = new SqlParameter("CookAtT2", cookAt2);
            SqlParameter coolDownForParameter = new SqlParameter("CoolDownFor", coolDownFor);
            SqlParameter coolToTempParameter = new SqlParameter("CoolToTemp", coolToTemp);
            SqlParameter dropInPipeRunParameter = new SqlParameter("DropInPipeRun", dropInPipeRun);
            SqlParameter pipeSlopOfParameter = new SqlParameter("PipeSlopOf", pipeSlopOf);
            SqlParameter f45F120Parameter = new SqlParameter("F45F120", f45F120);
            SqlParameter holdParameter = new SqlParameter("Hold", hold);
            SqlParameter f120F185Parameter = new SqlParameter("F120F185", f120F185);
            SqlParameter cookTimeParameter = new SqlParameter("CookTime", cookTime);
            SqlParameter coolTimeParameter = new SqlParameter("CoolTime", coolTime);
            SqlParameter aproxTotalParameter = new SqlParameter("AproxTotal", aproxTotal);
            SqlParameter waterChangesPerHourParameter = new SqlParameter("WaterChangesPerHour", waterChangesPerHour);
            SqlParameter returnWaterVelocityParameter = new SqlParameter("ReturnWaterVelocity", returnWaterVelocity);
            SqlParameter layflatBackPressureParameter = new SqlParameter("LayflatBackPressure", layflatBackPressure);
            SqlParameter pumpLiftAtIdealHeadParameter = new SqlParameter("PumpLiftAtIdealHead", pumpLiftAtIdealHead);
            SqlParameter waterToFillLinerColumnParameter = new SqlParameter("WaterToFillLinerColumn", waterToFillLinerColumn);
            SqlParameter waterPerFitParameter = new SqlParameter("WaterPerFit", waterPerFit);            
            SqlParameter installationResultsParameter = (installationResults.Trim() != "") ? new SqlParameter("InstallationResults", installationResults.Trim()) : new SqlParameter("InstallationResults", DBNull.Value);
            SqlParameter linerTubeLabelParameter = new SqlParameter("LinerTubeLabel ", linerTubeLabel);
            SqlParameter headsIdealLabelParameter = new SqlParameter("HeadsIdealLabel ", headsIdealLabel);
            SqlParameter pumpingAndCirculationLabelParameter = new SqlParameter("PumpingAndCirculationLabel ", pumpingAndCirculationLabel);            
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_INVERSION] ([WorkID], [Comment], [Pi" +
                "peType], [PipeCondition], [GroundMoisture], [BoilerSize], [PumpTotalCapacity], [" +
                "LayFlatSize], [LayFlatQuantityTotal], [WaterStartTemp], [Temp1], [HoldAtT1], [Te" +
                "mpT2], [CookAtT2], [CoolDownFor], [CoolToTemp], [DropInPipeRun], [PipeSlopOf], [" +
                "F45F120], [Hold], [F120F185], [CookTime], [CoolTime], [AproxTotal], [WaterChange" +
                "sPerHour], [ReturnWaterVelocity], [LayflatBackPressure], [PumpLiftAtIdealHead], " +
                "[WaterToFillLinerColumn], [WaterPerFit], [InstallationResults], [LinerTubeLabel]" +
                ", [HeadsIdealLabel], [PumpingAndCirculationLabel], [Deleted], [COMPANY_ID]) VALU" +
                "ES (@WorkID, @Comment, @PipeType, @PipeCondition, @GroundMoisture, @BoilerSize, " +
                "@PumpTotalCapacity, @LayFlatSize, @LayFlatQuantityTotal, @WaterStartTemp, @Temp1" +
                ", @HoldAtT1, @TempT2, @CookAtT2, @CoolDownFor, @CoolToTemp, @DropInPipeRun, @Pip" +
                "eSlopOf, @F45F120, @Hold, @F120F185, @CookTime, @CoolTime, @AproxTotal, @WaterCh" +
                "angesPerHour, @ReturnWaterVelocity, @LayflatBackPressure, @PumpLiftAtIdealHead, " +
                "@WaterToFillLinerColumn, @WaterPerFit, @InstallationResults, @LinerTubeLabel, @H" +
                "eadsIdealLabel, @PumpingAndCirculationLabel, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, commentParameter, pipeTypeParameter, pipeConditionParameter, groundMoistureParameter, boilerSizeParameter, pumpTotalCapacityParameter, layFlatSizeParameter, layFlatQuantityTotalParameter, waterStartTempParameter, temp1Parameter, holdAtT1Parameter, tempT2Parameter, cookAt2Parameter, coolDownForParameter, coolToTempParameter, dropInPipeRunParameter, pipeSlopOfParameter, f45F120Parameter, holdParameter, f120F185Parameter, cookTimeParameter, coolTimeParameter, aproxTotalParameter, waterChangesPerHourParameter, returnWaterVelocityParameter, layflatBackPressureParameter,  pumpLiftAtIdealHeadParameter, waterToFillLinerColumnParameter, waterPerFitParameter, installationResultsParameter, linerTubeLabelParameter, headsIdealLabelParameter, pumpingAndCirculationLabelParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update inversion info (direct to DB)
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalComment">originalComment</param>
        /// <param name="originalPipeType">originalPipeType</param>
        /// <param name="originalPipeCondition">originalPipeCondition</param>
        /// <param name="originalGroundMoisture">originalGroundMoisture</param>
        /// <param name="originalBoilerSize">originalBoilerSize</param>
        /// <param name="originalPumpTotalCapacity">originalPumpTotalCapacity</param>
        /// <param name="originalLayFlatSize">originalLayFlatSize</param>
        /// <param name="originalLayFlatQuantityTotal">originalLayFlatQuantityTotal</param>
        /// <param name="originalWaterStartTemp">originalWaterStartTemp</param>
        /// <param name="originalTemp1">originalTemp1</param>
        /// <param name="originalHoldAtT1">originalHoldAtT1</param>
        /// <param name="originalTempT2">originalTempT2</param>
        /// <param name="originalCookAtT2">originalCookAtT2</param>        
        /// <param name="originalCoolDownFor">originalCoolDownFor</param>
        /// <param name="originalCoolToTemp">originalCoolToTemp</param>
        /// <param name="originalDropInPipeRun">originalDropInPipeRun</param>
        /// <param name="originalPipeSlopOf">originalPipeSlopOf</param>
        /// <param name="originalF45F120">originalF45F120</param>
        /// <param name="originalHold">originalHold</param>
        /// <param name="originalF120F185">originalF120F185</param>
        /// <param name="originalCookTime">originalCookTime</param>
        /// <param name="originalCoolTime">originalCoolTime</param>
        /// <param name="originalAproxTotal">originalAproxTotal</param>
        /// <param name="originalWaterChangesPerHour">originalWaterChangesPerHour</param>
        /// <param name="originalReturnWaterVelocity">originalReturnWaterVelocity</param>
        /// <param name="originalLayflatBackPressure">originalLayflatBackPressure</param>
        /// <param name="originalPumpLiftAtIdealHead">originalPumpLiftAtIdealHead</param>
        /// <param name="originalWaterToFillLinerColumn">originalWaterToFillLinerColumn</param>
        /// <param name="originalWaterPerFit">originalWaterPerFit</param>
        /// <param name="originalInstallationResults">originalInstallationResults</param>
        /// <param name="originalLinerTubeLabel">originalLinerTubeLabel</param>
        /// <param name="originalHeadsIdealLabel">originalHeadsIdealLabel</param>
        /// <param name="originalPumpingAndCirculationLabel">originalPumpingAndCirculationLabel</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newComment">newComment</param>
        /// <param name="newPipeType">newPipeType</param>
        /// <param name="newPipeCondition">newPipeCondition</param>
        /// <param name="newGroundMoisture">newGroundMoisture</param>
        /// <param name="newBoilerSize">newBoilerSize</param>
        /// <param name="newPumpTotalCapacity">newPumpTotalCapacity</param>
        /// <param name="newLayFlatSize">newLayFlatSize</param>
        /// <param name="newLayFlatQuantityTotal">newLayFlatQuantityTotal</param>
        /// <param name="newWaterStartTemp">newWaterStartTemp</param>
        /// <param name="newTemp1">newTemp1</param>
        /// <param name="newHoldAtT1">newHoldAtT1</param>
        /// <param name="newTempT2">newTem2</param>
        /// <param name="newCookAtT2">newCookAtT2</param>        
        /// <param name="newCoolDownFor">newCoolDownFor</param>
        /// <param name="newCoolToTemp">newCoolToTemp</param>
        /// <param name="newDropInPipeRun">newDropInPipeRun</param>
        /// <param name="newPipeSlopOf">newPipeSlopOf</param>
        /// <param name="newF45F120">newF45F120</param>
        /// <param name="newHold">newHold</param>
        /// <param name="newF120F185">newF120F185</param>
        /// <param name="newCookTime">newCookTime</param>
        /// <param name="newCoolTime">newCoolTime</param>
        /// <param name="newAproxTotal">newAproxTotal</param>
        /// <param name="newWaterChangesPerHour">newWaterChangesPerHour</param>
        /// <param name="newReturnWaterVelocity">newReturnWaterVelocity</param>
        /// <param name="newLayflatBackPressure">newLayflatBackPressure</param>
        /// <param name="newPumpLiftAtIdealHead">newPumpLiftAtIdealHead</param>
        /// <param name="newWaterToFillLinerColumn">newWaterToFillLinerColumn</param>
        /// <param name="newWaterPerFit">newWaterPerFit</param>
        /// <param name="newInstallationResults">newInstallationResults</param>
        /// <param name="newLinerTubeLabel">newLinerTubeLabel</param>
        /// <param name="newHeadsIdealLabel">newHeadsIdealLabel</param>
        /// <param name="newPumpingAndCirculationLabel">newPumpingAndCirculationLabel</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalWorkId, string originalComment, string originalPipeType, string originalPipeCondition, string originalGroundMoisture, decimal originalBoilerSize, decimal originalPumpTotalCapacity, decimal originalLayFlatSize, decimal originalLayFlatQuantityTotal, decimal originalWaterStartTemp, decimal originalTemp1, decimal originalHoldAtT1, decimal originalTempT2, decimal originalCookAtT2, decimal originalCoolDownFor, decimal originalCoolToTemp, decimal originalDropInPipeRun, decimal originalPipeSlopOf, decimal originalF45F120, decimal originalHold, decimal originalF120F185, decimal originalCookTime, decimal originalCoolTime, decimal originalAproxTotal, decimal originalWaterChangesPerHour, decimal originalReturnWaterVelocity, decimal originalLayflatBackPressure, decimal originalPumpLiftAtIdealHead, decimal originalWaterToFillLinerColumn, decimal originalWaterPerFit, string originalInstallationResults, string originalLinerTubeLabel, string originalHeadsIdealLabel, string originalPumpingAndCirculationLabel, bool originalDeleted, int originalCompanyId, int newWorkId, string newComment, string newPipeType, string newPipeCondition, string newGroundMoisture, decimal newBoilerSize, decimal newPumpTotalCapacity, decimal newLayFlatSize, decimal newLayFlatQuantityTotal, decimal newWaterStartTemp, decimal newTemp1, decimal newHoldAtT1, decimal newTempT2, decimal newCookAtT2, decimal newCoolDownFor, decimal newCoolToTemp, decimal newDropInPipeRun, decimal newPipeSlopOf, decimal newF45F120, decimal newHold, decimal newF120F185, decimal newCookTime, decimal newCoolTime, decimal newAproxTotal, decimal newWaterChangesPerHour, decimal newReturnWaterVelocity, decimal newLayflatBackPressure, decimal newPumpLiftAtIdealHead, decimal newWaterToFillLinerColumn, decimal newWaterPerFit, string newInstallationResults, string newLinerTubeLabel, string newHeadsIdealLabel, string newPumpingAndCirculationLabel, bool newDeleted, int newCompanyId)
                                                  
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", originalWorkId);            
            SqlParameter originalCommentParameter = (originalComment.Trim() != "") ? new SqlParameter("Original_Comment", originalComment.Trim()) : new SqlParameter("Original_Comment", DBNull.Value);            
            SqlParameter originalPipeTypeParameter = new SqlParameter("Original_PipeType", originalPipeType);
            SqlParameter originalPipeConditionParameter = new SqlParameter("Original_PipeCondition", originalPipeCondition);
            SqlParameter originalGroundMoistureParameter = new SqlParameter("Original_GroundMoisture", originalGroundMoisture);
            SqlParameter originalBoilerSizeParameter = new SqlParameter("Original_BoilerSize", originalBoilerSize);
            SqlParameter originalPumpTotalCapacityParameter = new SqlParameter("Original_PumpTotalCapacity", originalPumpTotalCapacity);
            SqlParameter originalLayFlatSizeParameter = new SqlParameter("Original_LayFlatSize", originalLayFlatSize);
            SqlParameter originalLayFlatQuantityTotalParameter = new SqlParameter("Original_LayFlatQuantityTotal", originalLayFlatQuantityTotal);
            SqlParameter originalWaterStartTempParameter = new SqlParameter("Original_WaterStartTemp", originalWaterStartTemp);
            SqlParameter originalTemp1Parameter = new SqlParameter("Original_Temp1", originalTemp1);
            SqlParameter originalHoldAtT1Parameter = new SqlParameter("Original_HoldAtT1", originalHoldAtT1);
            SqlParameter originalTempT2Parameter = new SqlParameter("Original_TempT2", originalTempT2);
            SqlParameter originalCookAtT2Parameter = new SqlParameter("Original_CookAtT2", originalCookAtT2);                        
            SqlParameter originalCoolDownForParameter = new SqlParameter("Original_CoolDownFor", originalCoolDownFor);
            SqlParameter originalCoolToTempParameter = new SqlParameter("Original_CoolToTemp", originalCoolToTemp);
            SqlParameter originalDropInPipeRunParameter = new SqlParameter("Original_DropInPipeRun", originalDropInPipeRun);
            SqlParameter originalPipeSlopOfParameter = new SqlParameter("Original_PipeSlopOf", originalPipeSlopOf);
            SqlParameter originalF45F120Parameter = new SqlParameter("Original_F45F120", originalF45F120);
            SqlParameter originalHoldParameter = new SqlParameter("Original_Hold", originalHold);
            SqlParameter originalF120F185Parameter = new SqlParameter("Original_F120F185", originalF120F185);
            SqlParameter originalCookTimeParameter = new SqlParameter("Original_CookTime", originalCookTime);
            SqlParameter originalCoolTimeParameter = new SqlParameter("Original_CoolTime", originalCoolTime);
            SqlParameter originalAproxTotalParameter = new SqlParameter("Original_AproxTotal", originalAproxTotal);
            SqlParameter originalWaterChangesPerHourParameter = new SqlParameter("Original_WaterChangesPerHour", originalWaterChangesPerHour);
            SqlParameter originalReturnWaterVelocityParameter = new SqlParameter("Original_ReturnWaterVelocity", originalReturnWaterVelocity);
            SqlParameter originalLayflatBackPressureParameter = new SqlParameter("Original_LayflatBackPressure", originalLayflatBackPressure);
            SqlParameter originalPumpLiftAtIdealHeadParameter = new SqlParameter("Original_PumpLiftAtIdealHead", originalPumpLiftAtIdealHead);
            SqlParameter originalWaterToFillLinerColumnParameter = new SqlParameter("Original_WaterToFillLinerColumn", originalWaterToFillLinerColumn);
            SqlParameter originalWaterPerFitParameter = new SqlParameter("Original_WaterPerFit", originalWaterPerFit);            
            SqlParameter originalInstallationResultsParameter = (originalInstallationResults.Trim() != "") ? new SqlParameter("Original_InstallationResults", originalInstallationResults.Trim()) : new SqlParameter("Original_InstallationResults", DBNull.Value);
            SqlParameter originalLinerTubeLabelParameter = new SqlParameter("Original_LinerTubeLabel ", originalLinerTubeLabel);
            SqlParameter originalHeadsIdealLabelParameter = new SqlParameter("Original_HeadsIdealLabel ", originalHeadsIdealLabel);
            SqlParameter originalPumpingAndCirculationLabelParameter = new SqlParameter("Original_PumpingAndCirculationLabel ", originalPumpingAndCirculationLabel);                        
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", newWorkId);            
            SqlParameter newCommentParameter = (newComment.Trim() != "") ? new SqlParameter("Comment", newComment.Trim()) : new SqlParameter("Comment", DBNull.Value);            
            SqlParameter newPipeTypeParameter = new SqlParameter("PipeType", newPipeType);
            SqlParameter newPipeConditionParameter = new SqlParameter("PipeCondition", newPipeCondition);
            SqlParameter newGroundMoistureParameter = new SqlParameter("GroundMoisture", newGroundMoisture);
            SqlParameter newBoilerSizeParameter = new SqlParameter("BoilerSize", newBoilerSize);
            SqlParameter newPumpTotalCapacityParameter = new SqlParameter("PumpTotalCapacity", newPumpTotalCapacity);
            SqlParameter newLayFlatSizeParameter = new SqlParameter("LayFlatSize", newLayFlatSize);
            SqlParameter newLayFlatQuantityTotalParameter = new SqlParameter("LayFlatQuantityTotal", newLayFlatQuantityTotal);
            SqlParameter newWaterStartTempParameter = new SqlParameter("WaterStartTemp", newWaterStartTemp);
            SqlParameter newTemp1Parameter = new SqlParameter("Temp1", newTemp1);
            SqlParameter newHoldAtT1Parameter = new SqlParameter("HoldAtT1", newHoldAtT1);
            SqlParameter newTempT2Parameter = new SqlParameter("TempT2", newTempT2);
            SqlParameter newCookAtT2Parameter = new SqlParameter("CookAtT2", originalCookAtT2);   
            SqlParameter newCoolDownForParameter = new SqlParameter("CoolDownFor", newCoolDownFor);
            SqlParameter newCoolToTempParameter = new SqlParameter("CoolToTemp", newCoolToTemp);
            SqlParameter newDropInPipeRunParameter = new SqlParameter("DropInPipeRun", newDropInPipeRun);
            SqlParameter newPipeSlopOfParameter = new SqlParameter("PipeSlopOf", newPipeSlopOf);
            SqlParameter newF45F120Parameter = new SqlParameter("F45F120", newF45F120);
            SqlParameter newHoldParameter = new SqlParameter("Hold", newHold);
            SqlParameter newF120F185Parameter = new SqlParameter("F120F185", newF120F185);
            SqlParameter newCookTimeParameter = new SqlParameter("CookTime", newCookTime);
            SqlParameter newCoolTimeParameter = new SqlParameter("CoolTime", newCoolTime);
            SqlParameter newAproxTotalParameter = new SqlParameter("AproxTotal", newAproxTotal);
            SqlParameter newWaterChangesPerHourParameter = new SqlParameter("WaterChangesPerHour", newWaterChangesPerHour);
            SqlParameter newReturnWaterVelocityParameter = new SqlParameter("ReturnWaterVelocity", newReturnWaterVelocity);
            SqlParameter newLayflatBackPressureParameter = new SqlParameter("LayflatBackPressure", newLayflatBackPressure);
            SqlParameter newPumpLiftAtIdealHeadParameter = new SqlParameter("PumpLiftAtIdealHead", newPumpLiftAtIdealHead);
            SqlParameter newWaterToFillLinerColumnParameter = new SqlParameter("WaterToFillLinerColumn", newWaterToFillLinerColumn);
            SqlParameter newWaterPerFitParameter = new SqlParameter("WaterPerFit", newWaterPerFit);            
            SqlParameter newInstallationResultsParameter = (newInstallationResults.Trim() != "") ? new SqlParameter("InstallationResults", newInstallationResults.Trim()) : new SqlParameter("InstallationResults", DBNull.Value);

            SqlParameter newLinerTubeLabelParameter = new SqlParameter("LinerTubeLabel ", newLinerTubeLabel);
            SqlParameter newHeadsIdealLabelParameter = new SqlParameter("HeadsIdealLabel ", newHeadsIdealLabel);
            SqlParameter newPumpingAndCirculationLabelParameter = new SqlParameter("PumpingAndCirculationLabel ", newPumpingAndCirculationLabel);            


            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_INVERSION] SET [WorkID] = @WorkID, [Comme" +
                "nt] = @Comment, [PipeType] = @PipeType, [PipeCondition] = @PipeCondition, [Groun" +
                "dMoisture] = @GroundMoisture, [BoilerSize] = @BoilerSize, [PumpTotalCapacity] = " +
                "@PumpTotalCapacity, [LayFlatSize] = @LayFlatSize, [LayFlatQuantityTotal] = @LayF" +
                "latQuantityTotal, [WaterStartTemp] = @WaterStartTemp, [Temp1] = @Temp1, [HoldAtT" +
                "1] = @HoldAtT1, [TempT2] = @TempT2, [CookAtT2] = @CookAtT2, [CoolDownFor] = @Coo" +
                "lDownFor, [CoolToTemp] = @CoolToTemp, [DropInPipeRun] = @DropInPipeRun, [PipeSlo" +
                "pOf] = @PipeSlopOf, [F45F120] = @F45F120, [Hold] = @Hold, [F120F185] = @F120F185" +
                ", [CookTime] = @CookTime, [CoolTime] = @CoolTime, [AproxTotal] = @AproxTotal, [W" +
                "aterChangesPerHour] = @WaterChangesPerHour, [ReturnWaterVelocity] = @ReturnWater" +
                "Velocity, [LayflatBackPressure] = @LayflatBackPressure, [PumpLiftAtIdealHead] = " +
                "@PumpLiftAtIdealHead, [WaterToFillLinerColumn] = @WaterToFillLinerColumn, [Water" +
                "PerFit] = @WaterPerFit, [InstallationResults] = @InstallationResults, [LinerTube" +
                "Label] = @LinerTubeLabel, [HeadsIdealLabel] = @HeadsIdealLabel, [PumpingAndCircu" +
                "lationLabel] = @PumpingAndCirculationLabel " +
                " WHERE (([WorkID] = @Original_WorkID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID)) ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalCommentParameter, originalPipeTypeParameter, originalPipeConditionParameter, originalGroundMoistureParameter, originalBoilerSizeParameter, originalPumpTotalCapacityParameter, originalLayFlatSizeParameter, originalLayFlatQuantityTotalParameter, originalWaterStartTempParameter, originalTemp1Parameter, originalHoldAtT1Parameter, originalTempT2Parameter, originalCookAtT2Parameter, originalCoolDownForParameter, originalCoolToTempParameter, originalDropInPipeRunParameter, originalPipeSlopOfParameter, originalF45F120Parameter, originalHoldParameter, originalF120F185Parameter, originalCookTimeParameter, originalCoolTimeParameter, originalAproxTotalParameter, originalWaterChangesPerHourParameter, originalReturnWaterVelocityParameter, originalLayflatBackPressureParameter, originalPumpLiftAtIdealHeadParameter, originalWaterToFillLinerColumnParameter, originalWaterPerFitParameter, originalInstallationResultsParameter, originalLinerTubeLabelParameter, originalHeadsIdealLabelParameter, originalPumpingAndCirculationLabelParameter, originalDeletedParameter, originalCompanyIdParameter, newWorkIdParameter, newCommentParameter, newPipeTypeParameter, newPipeConditionParameter, newGroundMoistureParameter, newBoilerSizeParameter, newPumpTotalCapacityParameter, newLayFlatSizeParameter, newLayFlatQuantityTotalParameter, newWaterStartTempParameter, newTemp1Parameter, newHoldAtT1Parameter, newTempT2Parameter, newCookAtT2Parameter, newCoolDownForParameter, newCoolToTempParameter, newDropInPipeRunParameter, newPipeSlopOfParameter, newF45F120Parameter, newHoldParameter, newF120F185Parameter, newCookTimeParameter, newCoolTimeParameter, newAproxTotalParameter, newWaterChangesPerHourParameter, newReturnWaterVelocityParameter, newLayflatBackPressureParameter, newPumpLiftAtIdealHeadParameter, newWaterToFillLinerColumnParameter, newWaterPerFitParameter, newInstallationResultsParameter, newLinerTubeLabelParameter, newHeadsIdealLabelParameter, newPumpingAndCirculationLabelParameter, newDeletedParameter, newCompanyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete inversion info (direct to DB)
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Delete(int originalWorkId, int originalCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("@Original_WorkID", originalWorkId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_INVERSION] SET  [Deleted] = @Deleted  " +
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
