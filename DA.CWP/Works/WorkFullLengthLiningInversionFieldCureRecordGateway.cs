using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningInversionFieldCureRecordGateway
    /// </summary>
    public class WorkFullLengthLiningInversionFieldCureRecordGateway: DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningInversionFieldCureRecordGateway()
            : base("LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningInversionFieldCureRecordGateway(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD")
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
            tableMapping.DataSetTable = "LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("ReadingTime", "ReadingTime");
            tableMapping.ColumnMappings.Add("HeadFt", "HeadFt");
            tableMapping.ColumnMappings.Add("BoilerInF", "BoilerInF");
            tableMapping.ColumnMappings.Add("BoilerOutF", "BoilerOutF");
            tableMapping.ColumnMappings.Add("PumpFlow", "PumpFlow");
            tableMapping.ColumnMappings.Add("PumpPsi", "PumpPsi");
            tableMapping.ColumnMappings.Add("MH1Top", "MH1Top");
            tableMapping.ColumnMappings.Add("MH1Bot", "MH1Bot");
            tableMapping.ColumnMappings.Add("MH2Top", "MH2Top");
            tableMapping.ColumnMappings.Add("MH2Bot", "MH2Bot");
            tableMapping.ColumnMappings.Add("MH3Top", "MH3Top");
            tableMapping.ColumnMappings.Add("MH3Bot", "MH3Bot");
            tableMapping.ColumnMappings.Add("MH4Top", "MH4Top");
            tableMapping.ColumnMappings.Add("MH4Bot", "MH4Bot");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD] WHERE (([WorkID] = @Original_WorkID) AND ([RefID] = @Original_RefID) AND ((@IsNull_ReadingTime = 1 AND [ReadingTime] IS NULL) OR ([ReadingTime] = @Original_ReadingTime)) AND ((@IsNull_HeadFt = 1 AND [HeadFt] IS NULL) OR ([HeadFt] = @Original_HeadFt)) AND ((@IsNull_BoilerInF = 1 AND [BoilerInF] IS NULL) OR ([BoilerInF] = @Original_BoilerInF)) AND ((@IsNull_BoilerOutF = 1 AND [BoilerOutF] IS NULL) OR ([BoilerOutF] = @Original_BoilerOutF)) AND ((@IsNull_PumpFlow = 1 AND [PumpFlow] IS NULL) OR ([PumpFlow] = @Original_PumpFlow)) AND ((@IsNull_PumpPsi = 1 AND [PumpPsi] IS NULL) OR ([PumpPsi] = @Original_PumpPsi)) AND ((@IsNull_MH1Top = 1 AND [MH1Top] IS NULL) OR ([MH1Top] = @Original_MH1Top)) AND ((@IsNull_MH1Bot = 1 AND [MH1Bot] IS NULL) OR ([MH1Bot] = @Original_MH1Bot)) AND ((@IsNull_MH2Top = 1 AND [MH2Top] IS NULL) OR ([MH2Top] = @Original_MH2Top)) AND ((@IsNull_MH2Bot = 1 AND [MH2Bot] IS NULL) OR ([MH2Bot] = @Original_MH2Bot)) AND ((@IsNull_MH3Top = 1 AND [MH3Top] IS NULL) OR ([MH3Top] = @Original_MH3Top)) AND ((@IsNull_MH3Bot = 1 AND [MH3Bot] IS NULL) OR ([MH3Bot] = @Original_MH3Bot)) AND ((@IsNull_MH4Top = 1 AND [MH4Top] IS NULL) OR ([MH4Top] = @Original_MH4Top)) AND ((@IsNull_MH4Bot = 1 AND [MH4Bot] IS NULL) OR ([MH4Bot] = @Original_MH4Bot)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ReadingTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReadingTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ReadingTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReadingTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_HeadFt", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HeadFt", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HeadFt", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HeadFt", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BoilerInF", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BoilerInF", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BoilerInF", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BoilerInF", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BoilerOutF", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BoilerOutF", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BoilerOutF", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BoilerOutF", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PumpFlow", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpFlow", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PumpFlow", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpFlow", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PumpPsi", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpPsi", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PumpPsi", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpPsi", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MH1Top", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH1Top", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MH1Top", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH1Top", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MH1Bot", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH1Bot", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MH1Bot", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH1Bot", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MH2Top", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH2Top", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MH2Top", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH2Top", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MH2Bot", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH2Bot", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MH2Bot", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH2Bot", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MH3Top", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH3Top", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MH3Top", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH3Top", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MH3Bot", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH3Bot", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MH3Bot", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH3Bot", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MH4Top", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH4Top", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MH4Top", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH4Top", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MH4Bot", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH4Bot", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MH4Bot", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH4Bot", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD] ([WorkID], [RefID], [ReadingTime], [HeadFt], [BoilerInF], [BoilerOutF], [PumpFlow], [PumpPsi], [MH1Top], [MH1Bot], [MH2Top], [MH2Bot], [MH3Top], [MH3Bot], [MH4Top], [MH4Bot], [Comments], [Deleted], [COMPANY_ID]) VALUES (@WorkID, @RefID, @ReadingTime, @HeadFt, @BoilerInF, @BoilerOutF, @PumpFlow, @PumpPsi, @MH1Top, @MH1Bot, @MH2Top, @MH2Bot, @MH3Top, @MH3Bot, @MH4Top, @MH4Bot, @Comments, @Deleted, @COMPANY_ID);
SELECT WorkID, RefID, ReadingTime, HeadFt, BoilerInF, BoilerOutF, PumpFlow, PumpPsi, MH1Top, MH1Bot, MH2Top, MH2Bot, MH3Top, MH3Bot, MH4Top, MH4Bot, Comments, Deleted, COMPANY_ID FROM LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD WHERE (RefID = @RefID) AND (WorkID = @WorkID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ReadingTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReadingTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HeadFt", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HeadFt", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BoilerInF", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BoilerInF", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BoilerOutF", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BoilerOutF", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PumpFlow", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpFlow", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PumpPsi", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpPsi", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MH1Top", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH1Top", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MH1Bot", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH1Bot", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MH2Top", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH2Top", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MH2Bot", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH2Bot", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MH3Top", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH3Top", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MH3Bot", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH3Bot", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MH4Top", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH4Top", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MH4Bot", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH4Bot", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD] SET [WorkID] " +
                "= @WorkID, [RefID] = @RefID, [ReadingTime] = @ReadingTime, [HeadFt] = @HeadFt, [" +
                "BoilerInF] = @BoilerInF, [BoilerOutF] = @BoilerOutF, [PumpFlow] = @PumpFlow, [Pu" +
                "mpPsi] = @PumpPsi, [MH1Top] = @MH1Top, [MH1Bot] = @MH1Bot, [MH2Top] = @MH2Top, [" +
                "MH2Bot] = @MH2Bot, [MH3Top] = @MH3Top, [MH3Bot] = @MH3Bot, [MH4Top] = @MH4Top, [" +
                "MH4Bot] = @MH4Bot, [Comments] = @Comments, [Deleted] = @Deleted, [COMPANY_ID] = " +
                "@COMPANY_ID WHERE (([WorkID] = @Original_WorkID) AND ([RefID] = @Original_RefID)" +
                " AND ((@IsNull_ReadingTime = 1 AND [ReadingTime] IS NULL) OR ([ReadingTime] = @O" +
                "riginal_ReadingTime)) AND ((@IsNull_HeadFt = 1 AND [HeadFt] IS NULL) OR ([HeadFt" +
                "] = @Original_HeadFt)) AND ((@IsNull_BoilerInF = 1 AND [BoilerInF] IS NULL) OR (" +
                "[BoilerInF] = @Original_BoilerInF)) AND ((@IsNull_BoilerOutF = 1 AND [BoilerOutF" +
                "] IS NULL) OR ([BoilerOutF] = @Original_BoilerOutF)) AND ((@IsNull_PumpFlow = 1 " +
                "AND [PumpFlow] IS NULL) OR ([PumpFlow] = @Original_PumpFlow)) AND ((@IsNull_Pump" +
                "Psi = 1 AND [PumpPsi] IS NULL) OR ([PumpPsi] = @Original_PumpPsi)) AND ((@IsNull" +
                "_MH1Top = 1 AND [MH1Top] IS NULL) OR ([MH1Top] = @Original_MH1Top)) AND ((@IsNul" +
                "l_MH1Bot = 1 AND [MH1Bot] IS NULL) OR ([MH1Bot] = @Original_MH1Bot)) AND ((@IsNu" +
                "ll_MH2Top = 1 AND [MH2Top] IS NULL) OR ([MH2Top] = @Original_MH2Top)) AND ((@IsN" +
                "ull_MH2Bot = 1 AND [MH2Bot] IS NULL) OR ([MH2Bot] = @Original_MH2Bot)) AND ((@Is" +
                "Null_MH3Top = 1 AND [MH3Top] IS NULL) OR ([MH3Top] = @Original_MH3Top)) AND ((@I" +
                "sNull_MH3Bot = 1 AND [MH3Bot] IS NULL) OR ([MH3Bot] = @Original_MH3Bot)) AND ((@" +
                "IsNull_MH4Top = 1 AND [MH4Top] IS NULL) OR ([MH4Top] = @Original_MH4Top)) AND ((" +
                "@IsNull_MH4Bot = 1 AND [MH4Bot] IS NULL) OR ([MH4Bot] = @Original_MH4Bot)) AND (" +
                "[Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));\r\nSELE" +
                "CT WorkID, RefID, ReadingTime, HeadFt, BoilerInF, BoilerOutF, PumpFlow, PumpPsi," +
                " MH1Top, MH1Bot, MH2Top, MH2Bot, MH3Top, MH3Bot, MH4Top, MH4Bot, Comments, Delet" +
                "ed, COMPANY_ID FROM LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD WHERE (" +
                "RefID = @RefID) AND (WorkID = @WorkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ReadingTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReadingTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HeadFt", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HeadFt", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BoilerInF", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BoilerInF", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BoilerOutF", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BoilerOutF", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PumpFlow", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpFlow", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PumpPsi", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpPsi", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MH1Top", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH1Top", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MH1Bot", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH1Bot", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MH2Top", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH2Top", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MH2Bot", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH2Bot", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MH3Top", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH3Top", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MH3Bot", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH3Bot", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MH4Top", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH4Top", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MH4Bot", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH4Bot", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ReadingTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReadingTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ReadingTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ReadingTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_HeadFt", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HeadFt", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HeadFt", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HeadFt", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BoilerInF", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BoilerInF", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BoilerInF", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BoilerInF", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BoilerOutF", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BoilerOutF", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BoilerOutF", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BoilerOutF", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PumpFlow", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpFlow", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PumpFlow", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpFlow", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PumpPsi", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpPsi", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PumpPsi", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PumpPsi", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MH1Top", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH1Top", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MH1Top", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH1Top", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MH1Bot", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH1Bot", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MH1Bot", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH1Bot", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MH2Top", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH2Top", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MH2Top", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH2Top", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MH2Bot", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH2Bot", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MH2Bot", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH2Bot", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MH3Top", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH3Top", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MH3Top", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH3Top", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MH3Bot", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH3Bot", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MH3Bot", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH3Bot", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MH4Top", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH4Top", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MH4Top", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH4Top", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MH4Bot", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH4Bot", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MH4Bot", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MH4Bot", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            FillDataWithStoredProcedure("LFS_CWP_WORKFULLLENGTHLININGINVERSIONFIELDCURERECORDGATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert field cure record info (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="readingTime">readingTime</param>
        /// <param name="headFt">headFt</param>
        /// <param name="boilerInF">boilerInF</param>
        /// <param name="boilerOutF">boilerOutF</param>
        /// <param name="pumpFlow">pumpFlow</param>
        /// <param name="pumpPsi">pumpPsi</param>
        /// <param name="mh1Top">mh1Top</param>
        /// <param name="mh1Bot">mh1Bot</param>
        /// <param name="mh2Top">mh2Top</param>
        /// <param name="mh2Bot">mh2Bot</param>
        /// <param name="mh3Top">mh3Top</param>
        /// <param name="mh3Bot">mh3Bot</param>
        /// <param name="mh4Top">mh4Top</param>
        /// <param name="mh4Bot">mh4Bot</param>
        /// <param name="comments">comments</param>
        /// <param name="deleted">deleted</param>       
        /// <param name="companyId">companyId</param>        
        /// <returns>rowsAffected</returns>
        public int Insert(int workId, int refId, DateTime readingTime, decimal? headFt, decimal? boilerInF, decimal? boilerOutF, decimal? pumpFlow, decimal? pumpPsi, decimal? mh1Top, decimal? mh1Bot, decimal? mh2Top, decimal? mh2Bot, decimal? mh3Top, decimal? mh3Bot, decimal? mh4Top, decimal? mh4Bot, string comments, bool deleted, int companyId)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter readingTimeTubeParameter = new SqlParameter("ReadingTime", readingTime);
            SqlParameter headFtParameter = (headFt.HasValue) ? new SqlParameter("HeadFt", headFt) : new SqlParameter("HeadFt", DBNull.Value);
            SqlParameter boilerInFParameter = (boilerInF.HasValue) ? new SqlParameter("BoilerInF", boilerInF) : new SqlParameter("BoilerInF", DBNull.Value);
            SqlParameter boilerOutFParameter = (boilerOutF.HasValue) ? new SqlParameter("BoilerOutF", boilerOutF) : new SqlParameter("BoilerOutF", DBNull.Value);
            SqlParameter pumpFlowParameter = (pumpFlow.HasValue) ? new SqlParameter("PumpFlow", pumpFlow) : new SqlParameter("PumpFlow", DBNull.Value);
            SqlParameter pumpPsiParameter = (pumpPsi.HasValue) ? new SqlParameter("PumpPsi", pumpPsi) : new SqlParameter("PumpPsi", DBNull.Value);
            SqlParameter mh1TopParameter = (mh1Top.HasValue) ? new SqlParameter("MH1Top", mh1Top) : new SqlParameter("MH1Top", DBNull.Value);
            SqlParameter mh1BotParameter = (mh1Bot.HasValue) ? new SqlParameter("MH1Bot", mh1Bot) : new SqlParameter("MH1Bot", DBNull.Value);
            SqlParameter mh2TopParameter = (mh2Top.HasValue) ? new SqlParameter("MH2Top", mh2Top) : new SqlParameter("MH2Top", DBNull.Value);
            SqlParameter mh2BotParameter = (mh2Bot.HasValue) ? new SqlParameter("MH2Bot", mh2Bot) : new SqlParameter("MH2Bot", DBNull.Value);
            SqlParameter mh3TopParameter = (mh3Top.HasValue) ? new SqlParameter("MH3Top", mh3Top) : new SqlParameter("MH3Top", DBNull.Value);
            SqlParameter mh3BotParameter = (mh3Bot.HasValue) ? new SqlParameter("MH3Bot", mh3Bot) : new SqlParameter("MH3Bot", DBNull.Value);
            SqlParameter mh4TopParameter = (mh4Top.HasValue) ? new SqlParameter("MH4Top", mh4Top) : new SqlParameter("MH4Top", DBNull.Value);
            SqlParameter mh4BotParameter = (mh4Bot.HasValue) ? new SqlParameter("MH4Bot", mh4Bot) : new SqlParameter("MH4Bot", DBNull.Value);
            SqlParameter commentsParameter = (comments.Trim() != "") ? new SqlParameter("Comments", comments.Trim()) : new SqlParameter("Comments", DBNull.Value);            
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD] ([WorkID], [RefID], [ReadingTime], [HeadFt], [BoilerInF], [BoilerOutF], [PumpFlow], [PumpPsi], [MH1Top], [MH1Bot], [MH2Top], [MH2Bot], [MH3Top], [MH3Bot], [MH4Top], [MH4Bot], [Comments], [Deleted], [COMPANY_ID]) VALUES (@WorkID, @RefID, @ReadingTime, @HeadFt, @BoilerInF, @BoilerOutF, @PumpFlow, @PumpPsi, @MH1Top, @MH1Bot, @MH2Top, @MH2Bot, @MH3Top, @MH3Bot, @MH4Top, @MH4Bot, @Comments, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, refIdParameter, readingTimeTubeParameter, headFtParameter, boilerInFParameter, boilerOutFParameter, pumpFlowParameter, pumpPsiParameter, mh1TopParameter, mh1BotParameter, mh2TopParameter, mh2BotParameter, mh3TopParameter, mh3BotParameter, mh4TopParameter, mh4BotParameter, commentsParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update field cure record info (direct to DB)
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalReadingTime">originalReadingTime</param>
        /// <param name="originalHeadFt">originalHeadFt</param>
        /// <param name="originalBoilerInF">originalBboilerInF</param>
        /// <param name="originalBoilerOutF">originalBoilerOutF</param>
        /// <param name="originalPumpFlow">originalPumpFlow</param>
        /// <param name="originalPumpPsi">originalPumpPsi</param>
        /// <param name="originalMh1Top">originalMh1Top</param>
        /// <param name="originalMh1Bot">originalMh1Bot</param>
        /// <param name="originalMh2Top">originalMh2Top</param>
        /// <param name="originalMh2Bot">originalMh2Bot</param>
        /// <param name="originalMh3Top">originalMh3Top</param>
        /// <param name="originalMh3Bot">originalMh3Bot</param>
        /// <param name="originalMh4Top">originalMh4Top</param>
        /// <param name="originalMh4Bot">originalMh4Bot</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newReadingTime">newReadingTime</param>
        /// <param name="newHeadFt">newHeadFt</param>
        /// <param name="newBoilerInF">newBboilerInF</param>
        /// <param name="newBoilerOutF">newBoilerOutF</param>
        /// <param name="newPumpFlow">newPumpFlow</param>
        /// <param name="newPumpPsi">newPumpPsi</param>
        /// <param name="newMh1Top">newMh1Top</param>
        /// <param name="newMh1Bot">newMh1Bot</param>
        /// <param name="newMh2Top">newMh2Top</param>
        /// <param name="newMh2Bot">newMh2Bot</param>
        /// <param name="newMh3Top">newMh3Top</param>
        /// <param name="newMh3Bot">newMh3Bot</param>
        /// <param name="newMh4Top">newMh4Top</param>
        /// <param name="newMh4Bot">newMh4Bot</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalWorkId, int originalRefId, DateTime originalReadingTime, decimal? originalHeadFt, decimal? originalBoilerInF, decimal? originalBoilerOutF, decimal? originalPumpFlow, decimal? originalPumpPsi, decimal? originalMh1Top, decimal? originalMh1Bot, decimal? originalMh2Top, decimal? originalMh2Bot, decimal? originalMh3Top, decimal? originalMh3Bot, decimal? originalMh4Top, decimal? originalMh4Bot, string originalComments, bool originalDeleted, int originalCompanyId, int newWorkId, int newRefId, DateTime newReadingTime, decimal? newHeadFt, decimal? newBoilerInF, decimal? newBoilerOutF, decimal? newPumpFlow, decimal? newPumpPsi, decimal? newMh1Top, decimal? newMh1Bot, decimal? newMh2Top, decimal? newMh2Bot, decimal? newMh3Top, decimal? newMh3Bot, decimal? newMh4Top, decimal? newMh4Bot, string newComments, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", originalWorkId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalReadingTimeParameter = new SqlParameter("Original_ReadingTime", originalReadingTime);
            SqlParameter originalHeadFtParameter = (originalHeadFt.HasValue) ? new SqlParameter("Original_HeadFt", originalHeadFt) : new SqlParameter("Original_HeadFt", DBNull.Value);
            SqlParameter originalBoilerInFParameter = (originalBoilerInF.HasValue) ? new SqlParameter("Original_BoilerInF", originalBoilerInF) : new SqlParameter("Original_BoilerInF", DBNull.Value);
            SqlParameter originalBoilerOutFParameter = (originalBoilerOutF.HasValue) ? new SqlParameter("Original_BoilerOutF", originalBoilerOutF) : new SqlParameter("Original_BoilerOutF", DBNull.Value);
            SqlParameter originalPumpFlowParameter = (originalPumpFlow.HasValue) ? new SqlParameter("Original_PumpFlow", originalPumpFlow) : new SqlParameter("Original_PumpFlow", DBNull.Value);
            SqlParameter originalPumpPsiParameter = (originalPumpPsi.HasValue) ? new SqlParameter("Original_PumpPsi", originalPumpPsi) : new SqlParameter("Original_PumpPsi", DBNull.Value);
            SqlParameter originalMh1TopParameter = (originalMh1Top.HasValue) ? new SqlParameter("Original_MH1Top", originalMh1Top) : new SqlParameter("Original_MH1Top", DBNull.Value);
            SqlParameter originalMh1BotParameter = (originalMh1Bot.HasValue) ? new SqlParameter("Original_MH1Bot", originalMh1Bot) : new SqlParameter("Original_MH1Bot", DBNull.Value);
            SqlParameter originalMh2TopParameter = (originalMh2Top.HasValue) ? new SqlParameter("Original_MH2Top", originalMh2Top) : new SqlParameter("Original_MH2Top", DBNull.Value);
            SqlParameter originalMh2BotParameter = (originalMh2Bot.HasValue) ? new SqlParameter("Original_MH2Bot", originalMh2Bot) : new SqlParameter("Original_MH2Bot", DBNull.Value);
            SqlParameter originalMh3TopParameter = (originalMh3Top.HasValue) ? new SqlParameter("Original_MH3Top", originalMh3Top) : new SqlParameter("Original_MH3Top", DBNull.Value);
            SqlParameter originalMh3BotParameter = (originalMh3Bot.HasValue) ? new SqlParameter("Original_MH3Bot", originalMh3Bot) : new SqlParameter("Original_MH3Bot", DBNull.Value);
            SqlParameter originalMh4TopParameter = (originalMh4Top.HasValue) ? new SqlParameter("Original_MH4Top", originalMh4Top) : new SqlParameter("Original_MH4Top", DBNull.Value);
            SqlParameter originalMh4BotParameter = (originalMh4Bot.HasValue) ? new SqlParameter("Original_MH4Bot", originalMh4Bot) : new SqlParameter("Original_MH4Bot", DBNull.Value);
            SqlParameter originalCommentsParameter = (originalComments.Trim() != "") ? new SqlParameter("Original_Comments", originalComments.Trim()) : new SqlParameter("Original_Comments", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", newWorkId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", newRefId);
            SqlParameter newReadingTimeParameter = new SqlParameter("ReadingTime", newReadingTime);
            SqlParameter newHeadFtParameter = (newHeadFt.HasValue) ? new SqlParameter("HeadFt", newHeadFt) : new SqlParameter("HeadFt", DBNull.Value);
            SqlParameter newBoilerInFParameter = (newBoilerInF.HasValue) ? new SqlParameter("BoilerInF", newBoilerInF) : new SqlParameter("BoilerInF", DBNull.Value);
            SqlParameter newBoilerOutFParameter = (newBoilerOutF.HasValue) ? new SqlParameter("BoilerOutF", newBoilerOutF) : new SqlParameter("BoilerOutF", DBNull.Value);
            SqlParameter newPumpFlowParameter = (newPumpFlow.HasValue) ? new SqlParameter("PumpFlow", newPumpFlow) : new SqlParameter("PumpFlow", DBNull.Value);
            SqlParameter newPumpPsiParameter = (newPumpPsi.HasValue) ? new SqlParameter("PumpPsi", newPumpPsi) : new SqlParameter("PumpPsi", DBNull.Value);
            SqlParameter newMh1TopParameter = (newMh1Top.HasValue) ? new SqlParameter("MH1Top", newMh1Top) : new SqlParameter("MH1Top", DBNull.Value);
            SqlParameter newMh1BotParameter = (newMh1Bot.HasValue) ? new SqlParameter("MH1Bot", newMh1Bot) : new SqlParameter("MH1Bot", DBNull.Value);
            SqlParameter newMh2TopParameter = (newMh2Top.HasValue) ? new SqlParameter("MH2Top", newMh2Top) : new SqlParameter("MH2Top", DBNull.Value);
            SqlParameter newMh2BotParameter = (newMh2Bot.HasValue) ? new SqlParameter("MH2Bot", newMh2Bot) : new SqlParameter("MH2Bot", DBNull.Value);
            SqlParameter newMh3TopParameter = (newMh3Top.HasValue) ? new SqlParameter("MH3Top", newMh3Top) : new SqlParameter("MH3Top", DBNull.Value);
            SqlParameter newMh3BotParameter = (newMh3Bot.HasValue) ? new SqlParameter("MH3Bot", newMh3Bot) : new SqlParameter("MH3Bot", DBNull.Value);
            SqlParameter newMh4TopParameter = (newMh4Top.HasValue) ? new SqlParameter("MH4Top", newMh4Top) : new SqlParameter("MH4Top", DBNull.Value);
            SqlParameter newMh4BotParameter = (newMh4Bot.HasValue) ? new SqlParameter("MH4Bot", newMh4Bot) : new SqlParameter("MH4Bot", DBNull.Value);
            SqlParameter newCommentsParameter = (newComments.Trim() != "") ? new SqlParameter("Comments", newComments.Trim()) : new SqlParameter("Comments", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD] SET [WorkID] " +
                "= @WorkID, [RefID] = @RefID, [ReadingTime] = @ReadingTime, [HeadFt] = @HeadFt, [" +
                "BoilerInF] = @BoilerInF, [BoilerOutF] = @BoilerOutF, [PumpFlow] = @PumpFlow, [Pu" +
                "mpPsi] = @PumpPsi, [MH1Top] = @MH1Top, [MH1Bot] = @MH1Bot, [MH2Top] = @MH2Top, [" +
                "MH2Bot] = @MH2Bot, [MH3Top] = @MH3Top, [MH3Bot] = @MH3Bot, [MH4Top] = @MH4Top, [" +
                "MH4Bot] = @MH4Bot, [Comments] = @Comments, [Deleted] = @Deleted, [COMPANY_ID] = " +
                "@COMPANY_ID " +
                " WHERE (([WorkID] = @Original_WorkID) AND ([RefID] = @Original_RefID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID)) ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalRefIdParameter, originalReadingTimeParameter, originalHeadFtParameter, originalBoilerInFParameter, originalBoilerOutFParameter, originalPumpFlowParameter, originalPumpPsiParameter, originalMh1TopParameter, originalMh1BotParameter, originalMh2TopParameter, originalMh2BotParameter, originalMh3TopParameter, originalMh3BotParameter, originalMh4TopParameter, originalMh4BotParameter, originalCommentsParameter, originalDeletedParameter, originalCompanyIdParameter, newWorkIdParameter, newRefIdParameter, newReadingTimeParameter, newHeadFtParameter, newBoilerInFParameter, newBoilerOutFParameter, newPumpFlowParameter, newPumpPsiParameter, newMh1TopParameter, newMh1BotParameter, newMh2TopParameter, newMh2BotParameter, newMh3TopParameter, newMh3BotParameter, newMh4TopParameter, newMh4BotParameter, newCommentsParameter, newDeletedParameter, newCompanyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete field cure record info (direct to DB)
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalRefId">refId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Delete(int originalWorkId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("@Original_WorkID", originalWorkId);
            SqlParameter originalRefIdParameter = new SqlParameter("@Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD] SET  [Deleted] = @Deleted  " +
                             " WHERE (([WorkID] = @Original_WorkID) AND ([RefID] = @Original_RefID) AND  " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete field cure record info (direct to DB)
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int DeleteAll(int originalWorkId, int originalCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("@Original_WorkID", originalWorkId);            
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD] SET  [Deleted] = @Deleted  " +
                             " WHERE (([WorkID] = @Original_WorkID) AND  " +
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

