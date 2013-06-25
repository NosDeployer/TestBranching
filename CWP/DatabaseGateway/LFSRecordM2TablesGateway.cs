using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.CWP.DatabaseGateway
{
    /// <summary>
    /// LFSRecordM2TablesGateway
    /// </summary>
    public class LFSRecordM2TablesGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LFSRecordM2TablesGateway()
            : base("LFS_M2_TABLES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LFSRecordM2TablesGateway(DataSet data)
            : base(data, "LFS_M2_TABLES")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new TDSLFSRecord();
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
            tableMapping.DataSetTable = "LFS_M2_TABLES";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("VideoDistance", "VideoDistance");
            tableMapping.ColumnMappings.Add("ClockPosition", "ClockPosition");
            tableMapping.ColumnMappings.Add("LiveOrAbandoned", "LiveOrAbandoned");
            tableMapping.ColumnMappings.Add("DistanceToCentreOfLateral", "DistanceToCentreOfLateral");
            tableMapping.ColumnMappings.Add("LateralDiameter", "LateralDiameter");
            tableMapping.ColumnMappings.Add("LateralType", "LateralType");
            tableMapping.ColumnMappings.Add("DateTimeOpened", "DateTimeOpened");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("ReverseSetup", "ReverseSetup");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("Archived", "Archived");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_M2_TABLES] WHERE (([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_VideoDistance = 1 AND [VideoDistance] IS NULL) OR ([VideoDistance] = @Original_VideoDistance)) AND ((@IsNull_ClockPosition = 1 AND [ClockPosition] IS NULL) OR ([ClockPosition] = @Original_ClockPosition)) AND ((@IsNull_LiveOrAbandoned = 1 AND [LiveOrAbandoned] IS NULL) OR ([LiveOrAbandoned] = @Original_LiveOrAbandoned)) AND ((@IsNull_DistanceToCentreOfLateral = 1 AND [DistanceToCentreOfLateral] IS NULL) OR ([DistanceToCentreOfLateral] = @Original_DistanceToCentreOfLateral)) AND ((@IsNull_LateralDiameter = 1 AND [LateralDiameter] IS NULL) OR ([LateralDiameter] = @Original_LateralDiameter)) AND ((@IsNull_LateralType = 1 AND [LateralType] IS NULL) OR ([LateralType] = @Original_LateralType)) AND ((@IsNull_DateTimeOpened = 1 AND [DateTimeOpened] IS NULL) OR ([DateTimeOpened] = @Original_DateTimeOpened)) AND ((@IsNull_ReverseSetup = 1 AND [ReverseSetup] IS NULL) OR ([ReverseSetup] = @Original_ReverseSetup)) AND ((@IsNull_Deleted = 1 AND [Deleted] IS NULL) OR ([Deleted] = @Original_Deleted)) AND ((@IsNull_Archived = 1 AND [Archived] IS NULL) OR ([Archived] = @Original_Archived)))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_VideoDistance", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDistance", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VideoDistance", System.Data.SqlDbType.Real, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDistance", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ClockPosition", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ClockPosition", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClockPosition", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ClockPosition", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LiveOrAbandoned", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveOrAbandoned", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LiveOrAbandoned", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveOrAbandoned", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DistanceToCentreOfLateral", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToCentreOfLateral", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceToCentreOfLateral", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToCentreOfLateral", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LateralDiameter", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralDiameter", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LateralDiameter", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralDiameter", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LateralType", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralType", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LateralType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralType", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DateTimeOpened", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTimeOpened", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DateTimeOpened", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTimeOpened", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ReverseSetup", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ReverseSetup", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReverseSetup", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ReverseSetup", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Deleted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Archived", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_M2_TABLES] ([ID], [RefID], [COMPANY_ID], [VideoDistance], [ClockPosition], [LiveOrAbandoned], [DistanceToCentreOfLateral], [LateralDiameter], [LateralType], [DateTimeOpened], [Comments], [ReverseSetup], [Deleted], [Archived]) VALUES (@ID, @RefID, @COMPANY_ID, @VideoDistance, @ClockPosition, @LiveOrAbandoned, @DistanceToCentreOfLateral, @LateralDiameter, @LateralType, @DateTimeOpened, @Comments, @ReverseSetup, @Deleted, @Archived);
SELECT ID, RefID, COMPANY_ID, VideoDistance, ClockPosition, LiveOrAbandoned, DistanceToCentreOfLateral, LateralDiameter, LateralType, DateTimeOpened, Comments, ReverseSetup, Deleted, Archived FROM LFS_M2_TABLES WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RefID = @RefID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VideoDistance", System.Data.SqlDbType.Real, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDistance", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClockPosition", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ClockPosition", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LiveOrAbandoned", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveOrAbandoned", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceToCentreOfLateral", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToCentreOfLateral", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LateralDiameter", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralDiameter", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LateralType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralType", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTimeOpened", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTimeOpened", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "Comments", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReverseSetup", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ReverseSetup", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_M2_TABLES] SET [ID] = @ID, [RefID] = @RefID, [COMPANY_ID] = @CO" +
                "MPANY_ID, [VideoDistance] = @VideoDistance, [ClockPosition] = @ClockPosition, [L" +
                "iveOrAbandoned] = @LiveOrAbandoned, [DistanceToCentreOfLateral] = @DistanceToCen" +
                "treOfLateral, [LateralDiameter] = @LateralDiameter, [LateralType] = @LateralType" +
                ", [DateTimeOpened] = @DateTimeOpened, [Comments] = @Comments, [ReverseSetup] = @" +
                "ReverseSetup, [Deleted] = @Deleted, [Archived] = @Archived WHERE (([ID] = @Origi" +
                "nal_ID) AND ([RefID] = @Original_RefID) AND ([COMPANY_ID] = @Original_COMPANY_ID" +
                ") AND ((@IsNull_VideoDistance = 1 AND [VideoDistance] IS NULL) OR ([VideoDistanc" +
                "e] = @Original_VideoDistance)) AND ((@IsNull_ClockPosition = 1 AND [ClockPositio" +
                "n] IS NULL) OR ([ClockPosition] = @Original_ClockPosition)) AND ((@IsNull_LiveOr" +
                "Abandoned = 1 AND [LiveOrAbandoned] IS NULL) OR ([LiveOrAbandoned] = @Original_L" +
                "iveOrAbandoned)) AND ((@IsNull_DistanceToCentreOfLateral = 1 AND [DistanceToCent" +
                "reOfLateral] IS NULL) OR ([DistanceToCentreOfLateral] = @Original_DistanceToCent" +
                "reOfLateral)) AND ((@IsNull_LateralDiameter = 1 AND [LateralDiameter] IS NULL) O" +
                "R ([LateralDiameter] = @Original_LateralDiameter)) AND ((@IsNull_LateralType = 1" +
                " AND [LateralType] IS NULL) OR ([LateralType] = @Original_LateralType)) AND ((@I" +
                "sNull_DateTimeOpened = 1 AND [DateTimeOpened] IS NULL) OR ([DateTimeOpened] = @O" +
                "riginal_DateTimeOpened)) AND ((@IsNull_ReverseSetup = 1 AND [ReverseSetup] IS NU" +
                "LL) OR ([ReverseSetup] = @Original_ReverseSetup)) AND ((@IsNull_Deleted = 1 AND " +
                "[Deleted] IS NULL) OR ([Deleted] = @Original_Deleted)) AND ((@IsNull_Archived = " +
                "1 AND [Archived] IS NULL) OR ([Archived] = @Original_Archived)));\r\nSELECT ID, Re" +
                "fID, COMPANY_ID, VideoDistance, ClockPosition, LiveOrAbandoned, DistanceToCentre" +
                "OfLateral, LateralDiameter, LateralType, DateTimeOpened, Comments, ReverseSetup," +
                " Deleted, Archived FROM LFS_M2_TABLES WHERE (COMPANY_ID = @COMPANY_ID) AND (ID =" +
                " @ID) AND (RefID = @RefID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VideoDistance", System.Data.SqlDbType.Real, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDistance", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClockPosition", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ClockPosition", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LiveOrAbandoned", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveOrAbandoned", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceToCentreOfLateral", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToCentreOfLateral", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LateralDiameter", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralDiameter", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LateralType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralType", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTimeOpened", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTimeOpened", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "Comments", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReverseSetup", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ReverseSetup", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_VideoDistance", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDistance", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VideoDistance", System.Data.SqlDbType.Real, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDistance", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ClockPosition", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ClockPosition", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClockPosition", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ClockPosition", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LiveOrAbandoned", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveOrAbandoned", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LiveOrAbandoned", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveOrAbandoned", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DistanceToCentreOfLateral", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToCentreOfLateral", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceToCentreOfLateral", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToCentreOfLateral", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LateralDiameter", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralDiameter", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LateralDiameter", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralDiameter", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LateralType", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralType", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LateralType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralType", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DateTimeOpened", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTimeOpened", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DateTimeOpened", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DateTimeOpened", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ReverseSetup", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ReverseSetup", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReverseSetup", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ReverseSetup", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Deleted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Archived", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert  (direct to DB)
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="videoDistance">videoDistance</param>
        /// <param name="clockPosition">clockPosition</param>
        /// <param name="liveOrAbandoned">liveOrAbandoned</param>
        /// <param name="distanceToCentreOfLateral">distanceToCentreOfLateral</param>
        /// <param name="lateralDiameter">lateralDiameter</param>
        /// <param name="lateralType">lateralType</param>
        /// <param name="dateTimeOpened">dateTimeOpened</param>
        /// <param name="comments">comments</param>
        /// <param name="reverseSetup">reverseSetup</param>
        /// <param name="deleted">deleted</param>
        /// <param name="archived">archived</param>
        /// <returns>rowsAffected</returns>
        public int Insert(Guid id, int refId, int companyId, float? videoDistance, string clockPosition, string liveOrAbandoned, string distanceToCentreOfLateral, string lateralDiameter, string lateralType, string dateTimeOpened, string comments, string reverseSetup, bool deleted, bool archived)
        {
            SqlParameter idParameter = new SqlParameter("ID", id);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter videoDistanceParameter = (videoDistance.HasValue) ? new SqlParameter("VideoDistance", videoDistance) : new SqlParameter("VideoDistance", DBNull.Value);
            SqlParameter clockPositionParameter = (clockPosition.Trim() != "") ? new SqlParameter("ClockPosition", clockPosition.Trim()) : new SqlParameter("ClockPosition", DBNull.Value);
            SqlParameter liveOrAbandonedParameter = (liveOrAbandoned.Trim() != "") ? new SqlParameter("LiveOrAbandoned", liveOrAbandoned.Trim()) : new SqlParameter("LiveOrAbandoned", DBNull.Value);
            SqlParameter distanceToCentreOfLateralParameter = (distanceToCentreOfLateral.Trim() != "") ? new SqlParameter("DistanceToCentreOfLateral", distanceToCentreOfLateral.Trim()) : new SqlParameter("DistanceToCentreOfLateral", DBNull.Value);
            SqlParameter lateralDiameterParameter = (lateralDiameter.Trim() != "") ? new SqlParameter("LateralDiameter", lateralDiameter.Trim()) : new SqlParameter("LateralDiameter", DBNull.Value);
            SqlParameter lateralTypeParameter = (lateralType.Trim() != "") ? new SqlParameter("LateralType", lateralType.Trim()) : new SqlParameter("LateralType", DBNull.Value);
            SqlParameter dateTimeOpenedParameter = (dateTimeOpened.Trim() != "") ? new SqlParameter("DateTimeOpened", dateTimeOpened.Trim()) : new SqlParameter("DateTimeOpened", DBNull.Value);
            SqlParameter commentsParameter = (comments.Trim() != "") ? new SqlParameter("Comments", comments) : new SqlParameter("Comments", DBNull.Value);
            SqlParameter reverseSetupParameter = (reverseSetup.Trim() != "") ? new SqlParameter("ReverseSetup", reverseSetup) : new SqlParameter("ReverseSetup", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter archivedParameter = new SqlParameter("Archived", archived);           
            
            string command = "INSERT INTO [dbo].[LFS_M2_TABLES] ([ID], [RefID], [COMPANY_ID], [VideoDistance], "+
                " [ClockPosition], [LiveOrAbandoned], [DistanceToCentreOfLateral], [LateralDiameter], "+
                " [LateralType], [DateTimeOpened], [Comments], [ReverseSetup], [Deleted], [Archived])"+
                " VALUES (@ID, @RefID, @COMPANY_ID, @VideoDistance, @ClockPosition, @LiveOrAbandoned, "+
                " @DistanceToCentreOfLateral, @LateralDiameter, @LateralType, @DateTimeOpened, @Comments, "+
                " @ReverseSetup, @Deleted, @Archived)";

            int rowsAffected = (int)ExecuteNonQuery(command, idParameter, refIdParameter, companyIdParameter, videoDistanceParameter, clockPositionParameter, liveOrAbandonedParameter, distanceToCentreOfLateralParameter, lateralDiameterParameter, lateralTypeParameter, dateTimeOpenedParameter, commentsParameter, reverseSetupParameter, deletedParameter, archivedParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update work (direct to DB)
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>     
        /// <param name="originalVideoDistance">originalVideoDistance</param>
        /// <param name="originalClockPosition">originalClockPosition</param>
        /// <param name="originalLiveOrAbandoned">originalLiveOrAbandoned</param>
        /// <param name="originalDistanceToCentreOfLateral">originalDistanceToCentreOfLateral</param>
        /// <param name="originalLateralDiameter">originalLateralDiameter</param>
        /// <param name="originalLateralType">originalLateralType</param>
        /// <param name="originalDateTimeOpened">originalDateTimeOpened</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalReverseSetup">originalReverseSetup</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalArchived">originalArchived</param>
        /// 
        /// <param name="newId">newId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newCompanyId">newCompanyId</param> 
        /// <param name="newVideoDistance">newVideoDistance</param>
        /// <param name="newClockPosition">newClockPosition</param>
        /// <param name="newLiveOrAbandoned">newLiveOrAbandoned</param>
        /// <param name="newDistanceToCentreOfLateral">newDistanceToCentreOfLateral</param>
        /// <param name="newLateralDiameter">newLateralDiameter</param>
        /// <param name="newLateralType">newLateralType</param>
        /// <param name="newDateTimeOpened">newDateTimeOpened</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newReverseSetup">newReverseSetup</param>  
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newArchived">newArchived</param>
        public int Update(Guid originalId, int originalRefId, int originalCompanyId, float? originalVideoDistance, string originalClockPosition, string originalLiveOrAbandoned, string originalDistanceToCentreOfLateral, string originalLateralDiameter, string originalLateralType, string originalDateTimeOpened, string originalComments, string originalReverseSetup, bool originalDeleted, bool originalArchived, Guid newId, int newRefId, int newCompanyId, float? newVideoDistance, string newClockPosition, string newLiveOrAbandoned, string newDistanceToCentreOfLateral, string newLateralDiameter, string newLateralType, string newDateTimeOpened, string newComments, string newReverseSetup, bool newDeleted, bool newArchived)
        {
            SqlParameter originalIdParameter = new SqlParameter("Original_ID", originalId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalVideoDistanceParameter = (originalVideoDistance.HasValue) ? new SqlParameter("Original_VideoDistance", originalVideoDistance) : new SqlParameter("Original_VideoDistance", DBNull.Value);
            SqlParameter originalClockPositionParameter = (originalClockPosition.Trim() != "") ? new SqlParameter("Original_ClockPosition", originalClockPosition.Trim()) : new SqlParameter("Original_ClockPosition", DBNull.Value);
            SqlParameter originalLiveOrAbandonedParameter = (originalLiveOrAbandoned.Trim() != "") ? new SqlParameter("Original_LiveOrAbandoned", originalLiveOrAbandoned.Trim()) : new SqlParameter("Original_LiveOrAbandoned", DBNull.Value);
            SqlParameter originalDistanceToCentreOfLateralParameter = (originalDistanceToCentreOfLateral.Trim() != "") ? new SqlParameter("Original_DistanceToCentreOfLateral", originalDistanceToCentreOfLateral.Trim()) : new SqlParameter("Original_DistanceToCentreOfLateral", DBNull.Value);
            SqlParameter originalLateralDiameterParameter = (originalLateralDiameter.Trim() != "") ? new SqlParameter("Original_LateralDiameter", originalLateralDiameter.Trim()) : new SqlParameter("Original_LateralDiameter", DBNull.Value);
            SqlParameter originalLateralTypeParameter = (originalLateralType.Trim() != "") ? new SqlParameter("Original_LateralType", originalLateralType.Trim()) : new SqlParameter("Original_LateralType", DBNull.Value);
            SqlParameter originalDateTimeOpenedParameter = (originalDateTimeOpened.Trim() != "") ? new SqlParameter("Original_DateTimeOpened", originalDateTimeOpened.Trim()) : new SqlParameter("Original_DateTimeOpened", DBNull.Value);
            SqlParameter originalCommentsParameter = (originalComments.Trim() != "") ? new SqlParameter("Original_Comments", originalComments) : new SqlParameter("Original_Comments", DBNull.Value);
            SqlParameter originalReverseSetupParameter = (originalReverseSetup.Trim() != "") ? new SqlParameter("Original_ReverseSetup", originalReverseSetup) : new SqlParameter("Original_ReverseSetup", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalArchivedParameter = new SqlParameter("Original_Archived", originalArchived);

            SqlParameter newIdParameter = new SqlParameter("ID", newId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", newRefId);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newVideoDistanceParameter = (newVideoDistance.HasValue) ? new SqlParameter("VideoDistance", newVideoDistance) : new SqlParameter("VideoDistance", DBNull.Value);
            SqlParameter newClockPositionParameter = (newClockPosition.Trim() != "") ? new SqlParameter("ClockPosition", newClockPosition.Trim()) : new SqlParameter("ClockPosition", DBNull.Value);
            SqlParameter newLiveOrAbandonedParameter = (newLiveOrAbandoned.Trim() != "") ? new SqlParameter("LiveOrAbandoned", newLiveOrAbandoned.Trim()) : new SqlParameter("LiveOrAbandoned", DBNull.Value);
            SqlParameter newDistanceToCentreOfLateralParameter = (newDistanceToCentreOfLateral.Trim() != "") ? new SqlParameter("DistanceToCentreOfLateral", newDistanceToCentreOfLateral.Trim()) : new SqlParameter("DistanceToCentreOfLateral", DBNull.Value);
            SqlParameter newLateralDiameterParameter = (newLateralDiameter.Trim() != "") ? new SqlParameter("LateralDiameter", newLateralDiameter.Trim()) : new SqlParameter("LateralDiameter", DBNull.Value);
            SqlParameter newLateralTypeParameter = (newLateralType.Trim() != "") ? new SqlParameter("LateralType", newLateralType.Trim()) : new SqlParameter("LateralType", DBNull.Value);
            SqlParameter newDateTimeOpenedParameter = (newDateTimeOpened.Trim() != "") ? new SqlParameter("DateTimeOpened", newDateTimeOpened.Trim()) : new SqlParameter("DateTimeOpened", DBNull.Value);
            SqlParameter newCommentsParameter = (newComments.Trim() != "") ? new SqlParameter("Comments", newComments) : new SqlParameter("Comments", DBNull.Value);
            SqlParameter newReverseSetupParameter = (newReverseSetup.Trim() != "") ? new SqlParameter("ReverseSetup", newReverseSetup) : new SqlParameter("ReverseSetup", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);            
            SqlParameter newArchivedParameter = new SqlParameter("Archived", newArchived);


            string command = "UPDATE [dbo].[LFS_M2_TABLES] SET " +
                "[VideoDistance] = @VideoDistance, [ClockPosition] = @ClockPosition, [L" +
                "iveOrAbandoned] = @LiveOrAbandoned, [DistanceToCentreOfLateral] = @DistanceToCen" +
                "treOfLateral, [LateralDiameter] = @LateralDiameter, [LateralType] = @LateralType" +
                ", [DateTimeOpened] = @DateTimeOpened, [Comments] = @Comments, [ReverseSetup] = @" +
                "ReverseSetup, [Deleted] = @Deleted, [Archived] = @Archived "+
                "WHERE (" +
                "([RefID] = @Original_RefID) AND ([ID] = @Original_ID) AND " +
                " ([COMPANY_ID] = @Original_COMPANY_ID)" +
                " )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalIdParameter, originalRefIdParameter, originalCompanyIdParameter, originalVideoDistanceParameter, originalClockPositionParameter, originalLiveOrAbandonedParameter, originalDistanceToCentreOfLateralParameter, originalLateralDiameterParameter, originalLateralTypeParameter, originalDateTimeOpenedParameter, originalCommentsParameter, originalReverseSetupParameter, originalDeletedParameter, originalArchivedParameter, newIdParameter, newRefIdParameter, newCompanyIdParameter, newVideoDistanceParameter, newClockPositionParameter, newLiveOrAbandonedParameter, newDistanceToCentreOfLateralParameter, newLateralDiameterParameter, newLateralTypeParameter, newDateTimeOpenedParameter, newCommentsParameter, newReverseSetupParameter, newDeletedParameter, newArchivedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete (direct to DB)
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(Guid originalId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalIdParameter = new SqlParameter("Original_ID", originalId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_M2_TABLES] SET  [Deleted] = @Deleted  " +
                             " WHERE ( ([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }
    }
}
