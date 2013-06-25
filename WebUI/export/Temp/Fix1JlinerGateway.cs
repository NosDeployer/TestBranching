using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.WebUI.export.Temp;

namespace LiquiForce.LFSLive.WebUI
{
    /// <summary>
    /// Fix1JlinerGateway
    /// </summary>
    public class Fix1JlinerGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Fix1JlinerGateway()
            : base("LFS_JUNCTION_LINER2")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Fix1JlinerGateway(DataSet data)
            : base(data, "LFS_JUNCTION_LINER2")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new Fix1TDS();
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
            tableMapping.DataSetTable = "LFS_JUNCTION_LINER2";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("DetailID", "DetailID");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("PipeLocated", "PipeLocated");
            tableMapping.ColumnMappings.Add("ServicesLocated", "ServicesLocated");
            tableMapping.ColumnMappings.Add("CoInstalled", "CoInstalled");
            tableMapping.ColumnMappings.Add("BackfilledConcrete", "BackfilledConcrete");
            tableMapping.ColumnMappings.Add("BackfilledSoil", "BackfilledSoil");
            tableMapping.ColumnMappings.Add("Grouted", "Grouted");
            tableMapping.ColumnMappings.Add("Cored", "Cored");
            tableMapping.ColumnMappings.Add("Prepped", "Prepped");
            tableMapping.ColumnMappings.Add("Measured", "Measured");
            tableMapping.ColumnMappings.Add("LinerSize", "LinerSize");
            tableMapping.ColumnMappings.Add("InProcess", "InProcess");
            tableMapping.ColumnMappings.Add("InStock", "InStock");
            tableMapping.ColumnMappings.Add("Delivered", "Delivered");
            tableMapping.ColumnMappings.Add("BuildRebuild", "BuildRebuild");
            tableMapping.ColumnMappings.Add("PreVideo", "PreVideo");
            tableMapping.ColumnMappings.Add("LinerInstalled", "LinerInstalled");
            tableMapping.ColumnMappings.Add("FinalVideo", "FinalVideo");
            tableMapping.ColumnMappings.Add("DistanceFromUSMH", "DistanceFromUSMH");
            tableMapping.ColumnMappings.Add("DistanceFromDSMH", "DistanceFromDSMH");
            tableMapping.ColumnMappings.Add("Map", "Map");
            tableMapping.ColumnMappings.Add("Issue", "Issue");
            tableMapping.ColumnMappings.Add("Cost", "Cost");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("VideoInspection", "VideoInspection");
            tableMapping.ColumnMappings.Add("CoRequired", "CoRequired");
            tableMapping.ColumnMappings.Add("PitRequired", "PitRequired");
            tableMapping.ColumnMappings.Add("CoPitLocation", "CoPitLocation");
            tableMapping.ColumnMappings.Add("PostContractDigRequired", "PostContractDigRequired");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("History", "History");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_JUNCTION_LINER2] WHERE (([ID] = @Original_ID) AND ([RefID]" +
                " = @Original_RefID) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_Deta" +
                "ilID = 1 AND [DetailID] IS NULL) OR ([DetailID] = @Original_DetailID)) AND ((@Is" +
                "Null_Address = 1 AND [Address] IS NULL) OR ([Address] = @Original_Address)) AND " +
                "((@IsNull_PipeLocated = 1 AND [PipeLocated] IS NULL) OR ([PipeLocated] = @Origin" +
                "al_PipeLocated)) AND ((@IsNull_ServicesLocated = 1 AND [ServicesLocated] IS NULL" +
                ") OR ([ServicesLocated] = @Original_ServicesLocated)) AND ((@IsNull_CoInstalled " +
                "= 1 AND [CoInstalled] IS NULL) OR ([CoInstalled] = @Original_CoInstalled)) AND (" +
                "(@IsNull_BackfilledConcrete = 1 AND [BackfilledConcrete] IS NULL) OR ([Backfille" +
                "dConcrete] = @Original_BackfilledConcrete)) AND ((@IsNull_BackfilledSoil = 1 AND" +
                " [BackfilledSoil] IS NULL) OR ([BackfilledSoil] = @Original_BackfilledSoil)) AND" +
                " ((@IsNull_Grouted = 1 AND [Grouted] IS NULL) OR ([Grouted] = @Original_Grouted)" +
                ") AND ((@IsNull_Cored = 1 AND [Cored] IS NULL) OR ([Cored] = @Original_Cored)) A" +
                "ND ((@IsNull_Prepped = 1 AND [Prepped] IS NULL) OR ([Prepped] = @Original_Preppe" +
                "d)) AND ((@IsNull_Measured = 1 AND [Measured] IS NULL) OR ([Measured] = @Origina" +
                "l_Measured)) AND ((@IsNull_LinerSize = 1 AND [LinerSize] IS NULL) OR ([LinerSize" +
                "] = @Original_LinerSize)) AND ((@IsNull_InProcess = 1 AND [InProcess] IS NULL) O" +
                "R ([InProcess] = @Original_InProcess)) AND ((@IsNull_InStock = 1 AND [InStock] I" +
                "S NULL) OR ([InStock] = @Original_InStock)) AND ((@IsNull_Delivered = 1 AND [Del" +
                "ivered] IS NULL) OR ([Delivered] = @Original_Delivered)) AND ((@IsNull_BuildRebu" +
                "ild = 1 AND [BuildRebuild] IS NULL) OR ([BuildRebuild] = @Original_BuildRebuild)" +
                ") AND ((@IsNull_PreVideo = 1 AND [PreVideo] IS NULL) OR ([PreVideo] = @Original_" +
                "PreVideo)) AND ((@IsNull_LinerInstalled = 1 AND [LinerInstalled] IS NULL) OR ([L" +
                "inerInstalled] = @Original_LinerInstalled)) AND ((@IsNull_FinalVideo = 1 AND [Fi" +
                "nalVideo] IS NULL) OR ([FinalVideo] = @Original_FinalVideo)) AND ((@IsNull_Dista" +
                "nceFromUSMH = 1 AND [DistanceFromUSMH] IS NULL) OR ([DistanceFromUSMH] = @Origin" +
                "al_DistanceFromUSMH)) AND ((@IsNull_DistanceFromDSMH = 1 AND [DistanceFromDSMH] " +
                "IS NULL) OR ([DistanceFromDSMH] = @Original_DistanceFromDSMH)) AND ((@IsNull_Map" +
                " = 1 AND [Map] IS NULL) OR ([Map] = @Original_Map)) AND ([Issue] = @Original_Iss" +
                "ue) AND ((@IsNull_Cost = 1 AND [Cost] IS NULL) OR ([Cost] = @Original_Cost)) AND" +
                " ((@IsNull_Deleted = 1 AND [Deleted] IS NULL) OR ([Deleted] = @Original_Deleted)" +
                ") AND ((@IsNull_VideoInspection = 1 AND [VideoInspection] IS NULL) OR ([VideoIns" +
                "pection] = @Original_VideoInspection)) AND ([CoRequired] = @Original_CoRequired)" +
                " AND ([PitRequired] = @Original_PitRequired) AND ((@IsNull_CoPitLocation = 1 AND" +
                " [CoPitLocation] IS NULL) OR ([CoPitLocation] = @Original_CoPitLocation)) AND ([" +
                "PostContractDigRequired] = @Original_PostContractDigRequired))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DetailID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DetailID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DetailID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DetailID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Address", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Address", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Address", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PipeLocated", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeLocated", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PipeLocated", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeLocated", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ServicesLocated", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ServicesLocated", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ServicesLocated", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "ServicesLocated", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CoInstalled", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CoInstalled", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CoInstalled", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "CoInstalled", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BackfilledConcrete", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BackfilledConcrete", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BackfilledConcrete", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "BackfilledConcrete", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BackfilledSoil", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BackfilledSoil", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BackfilledSoil", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "BackfilledSoil", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Grouted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Grouted", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Cored", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Cored", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cored", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Cored", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Prepped", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Prepped", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Prepped", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Prepped", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Measured", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Measured", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Measured", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Measured", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerSize", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerSize", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerSize", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InProcess", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InProcess", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InProcess", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InProcess", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InStock", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InStock", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InStock", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InStock", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Delivered", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Delivered", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Delivered", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Delivered", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BuildRebuild", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BuildRebuild", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BuildRebuild", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BuildRebuild", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PreVideo", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideo", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PreVideo", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideo", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerInstalled", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerInstalled", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FinalVideo", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FinalVideo", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DistanceFromUSMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceFromUSMH", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DistanceFromDSMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceFromDSMH", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Map", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Map", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Map", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Map", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Issue", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Issue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Cost", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Cost", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cost", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "Cost", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Deleted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_VideoInspection", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoInspection", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VideoInspection", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoInspection", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CoRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CoRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PitRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PitRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CoPitLocation", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CoPitLocation", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CoPitLocation", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CoPitLocation", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PostContractDigRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PostContractDigRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_JUNCTION_LINER2] ([ID], [RefID], [COMPANY_ID], [DetailID], [Address], [PipeLocated], [ServicesLocated], [CoInstalled], [BackfilledConcrete], [BackfilledSoil], [Grouted], [Cored], [Prepped], [Measured], [LinerSize], [InProcess], [InStock], [Delivered], [BuildRebuild], [PreVideo], [LinerInstalled], [FinalVideo], [DistanceFromUSMH], [DistanceFromDSMH], [Map], [Issue], [Cost], [Deleted], [VideoInspection], [CoRequired], [PitRequired], [CoPitLocation], [PostContractDigRequired], [Comments], [History]) VALUES (@ID, @RefID, @COMPANY_ID, @DetailID, @Address, @PipeLocated, @ServicesLocated, @CoInstalled, @BackfilledConcrete, @BackfilledSoil, @Grouted, @Cored, @Prepped, @Measured, @LinerSize, @InProcess, @InStock, @Delivered, @BuildRebuild, @PreVideo, @LinerInstalled, @FinalVideo, @DistanceFromUSMH, @DistanceFromDSMH, @Map, @Issue, @Cost, @Deleted, @VideoInspection, @CoRequired, @PitRequired, @CoPitLocation, @PostContractDigRequired, @Comments, @History);
SELECT ID, RefID, COMPANY_ID, DetailID, Address, PipeLocated, ServicesLocated, CoInstalled, BackfilledConcrete, BackfilledSoil, Grouted, Cored, Prepped, Measured, LinerSize, InProcess, InStock, Delivered, BuildRebuild, PreVideo, LinerInstalled, FinalVideo, DistanceFromUSMH, DistanceFromDSMH, Map, Issue, Cost, Deleted, VideoInspection, CoRequired, PitRequired, CoPitLocation, PostContractDigRequired, Comments, History FROM LFS_JUNCTION_LINER2 WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RefID = @RefID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DetailID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DetailID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Address", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PipeLocated", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeLocated", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServicesLocated", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "ServicesLocated", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CoInstalled", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "CoInstalled", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BackfilledConcrete", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "BackfilledConcrete", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BackfilledSoil", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "BackfilledSoil", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Grouted", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cored", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Cored", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Prepped", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Prepped", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Measured", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Measured", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerSize", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerSize", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InProcess", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InProcess", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InStock", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InStock", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Delivered", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Delivered", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BuildRebuild", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BuildRebuild", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PreVideo", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideo", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerInstalled", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FinalVideo", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceFromUSMH", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceFromDSMH", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Map", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Map", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Issue", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Issue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cost", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "Cost", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VideoInspection", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoInspection", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CoRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CoRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PitRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PitRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CoPitLocation", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CoPitLocation", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PostContractDigRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PostContractDigRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "Comments", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@History", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "History", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_JUNCTION_LINER2] SET [ID] = @ID, [RefID] = @RefID, [COMPANY_ID]" +
                " = @COMPANY_ID, [DetailID] = @DetailID, [Address] = @Address, [PipeLocated] = @P" +
                "ipeLocated, [ServicesLocated] = @ServicesLocated, [CoInstalled] = @CoInstalled, " +
                "[BackfilledConcrete] = @BackfilledConcrete, [BackfilledSoil] = @BackfilledSoil, " +
                "[Grouted] = @Grouted, [Cored] = @Cored, [Prepped] = @Prepped, [Measured] = @Meas" +
                "ured, [LinerSize] = @LinerSize, [InProcess] = @InProcess, [InStock] = @InStock, " +
                "[Delivered] = @Delivered, [BuildRebuild] = @BuildRebuild, [PreVideo] = @PreVideo" +
                ", [LinerInstalled] = @LinerInstalled, [FinalVideo] = @FinalVideo, [DistanceFromU" +
                "SMH] = @DistanceFromUSMH, [DistanceFromDSMH] = @DistanceFromDSMH, [Map] = @Map, " +
                "[Issue] = @Issue, [Cost] = @Cost, [Deleted] = @Deleted, [VideoInspection] = @Vid" +
                "eoInspection, [CoRequired] = @CoRequired, [PitRequired] = @PitRequired, [CoPitLo" +
                "cation] = @CoPitLocation, [PostContractDigRequired] = @PostContractDigRequired, " +
                "[Comments] = @Comments, [History] = @History WHERE (([ID] = @Original_ID) AND ([" +
                "RefID] = @Original_RefID) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNul" +
                "l_DetailID = 1 AND [DetailID] IS NULL) OR ([DetailID] = @Original_DetailID)) AND" +
                " ((@IsNull_Address = 1 AND [Address] IS NULL) OR ([Address] = @Original_Address)" +
                ") AND ((@IsNull_PipeLocated = 1 AND [PipeLocated] IS NULL) OR ([PipeLocated] = @" +
                "Original_PipeLocated)) AND ((@IsNull_ServicesLocated = 1 AND [ServicesLocated] I" +
                "S NULL) OR ([ServicesLocated] = @Original_ServicesLocated)) AND ((@IsNull_CoInst" +
                "alled = 1 AND [CoInstalled] IS NULL) OR ([CoInstalled] = @Original_CoInstalled))" +
                " AND ((@IsNull_BackfilledConcrete = 1 AND [BackfilledConcrete] IS NULL) OR ([Bac" +
                "kfilledConcrete] = @Original_BackfilledConcrete)) AND ((@IsNull_BackfilledSoil =" +
                " 1 AND [BackfilledSoil] IS NULL) OR ([BackfilledSoil] = @Original_BackfilledSoil" +
                ")) AND ((@IsNull_Grouted = 1 AND [Grouted] IS NULL) OR ([Grouted] = @Original_Gr" +
                "outed)) AND ((@IsNull_Cored = 1 AND [Cored] IS NULL) OR ([Cored] = @Original_Cor" +
                "ed)) AND ((@IsNull_Prepped = 1 AND [Prepped] IS NULL) OR ([Prepped] = @Original_" +
                "Prepped)) AND ((@IsNull_Measured = 1 AND [Measured] IS NULL) OR ([Measured] = @O" +
                "riginal_Measured)) AND ((@IsNull_LinerSize = 1 AND [LinerSize] IS NULL) OR ([Lin" +
                "erSize] = @Original_LinerSize)) AND ((@IsNull_InProcess = 1 AND [InProcess] IS N" +
                "ULL) OR ([InProcess] = @Original_InProcess)) AND ((@IsNull_InStock = 1 AND [InSt" +
                "ock] IS NULL) OR ([InStock] = @Original_InStock)) AND ((@IsNull_Delivered = 1 AN" +
                "D [Delivered] IS NULL) OR ([Delivered] = @Original_Delivered)) AND ((@IsNull_Bui" +
                "ldRebuild = 1 AND [BuildRebuild] IS NULL) OR ([BuildRebuild] = @Original_BuildRe" +
                "build)) AND ((@IsNull_PreVideo = 1 AND [PreVideo] IS NULL) OR ([PreVideo] = @Ori" +
                "ginal_PreVideo)) AND ((@IsNull_LinerInstalled = 1 AND [LinerInstalled] IS NULL) " +
                "OR ([LinerInstalled] = @Original_LinerInstalled)) AND ((@IsNull_FinalVideo = 1 A" +
                "ND [FinalVideo] IS NULL) OR ([FinalVideo] = @Original_FinalVideo)) AND ((@IsNull" +
                "_DistanceFromUSMH = 1 AND [DistanceFromUSMH] IS NULL) OR ([DistanceFromUSMH] = @" +
                "Original_DistanceFromUSMH)) AND ((@IsNull_DistanceFromDSMH = 1 AND [DistanceFrom" +
                "DSMH] IS NULL) OR ([DistanceFromDSMH] = @Original_DistanceFromDSMH)) AND ((@IsNu" +
                "ll_Map = 1 AND [Map] IS NULL) OR ([Map] = @Original_Map)) AND ([Issue] = @Origin" +
                "al_Issue) AND ((@IsNull_Cost = 1 AND [Cost] IS NULL) OR ([Cost] = @Original_Cost" +
                ")) AND ((@IsNull_Deleted = 1 AND [Deleted] IS NULL) OR ([Deleted] = @Original_De" +
                "leted)) AND ((@IsNull_VideoInspection = 1 AND [VideoInspection] IS NULL) OR ([Vi" +
                "deoInspection] = @Original_VideoInspection)) AND ([CoRequired] = @Original_CoReq" +
                "uired) AND ([PitRequired] = @Original_PitRequired) AND ((@IsNull_CoPitLocation =" +
                " 1 AND [CoPitLocation] IS NULL) OR ([CoPitLocation] = @Original_CoPitLocation)) " +
                "AND ([PostContractDigRequired] = @Original_PostContractDigRequired));\r\nSELECT ID" +
                ", RefID, COMPANY_ID, DetailID, Address, PipeLocated, ServicesLocated, CoInstalle" +
                "d, BackfilledConcrete, BackfilledSoil, Grouted, Cored, Prepped, Measured, LinerS" +
                "ize, InProcess, InStock, Delivered, BuildRebuild, PreVideo, LinerInstalled, Fina" +
                "lVideo, DistanceFromUSMH, DistanceFromDSMH, Map, Issue, Cost, Deleted, VideoInsp" +
                "ection, CoRequired, PitRequired, CoPitLocation, PostContractDigRequired, Comment" +
                "s, History FROM LFS_JUNCTION_LINER2 WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @" +
                "ID) AND (RefID = @RefID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DetailID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DetailID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Address", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PipeLocated", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeLocated", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServicesLocated", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "ServicesLocated", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CoInstalled", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "CoInstalled", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BackfilledConcrete", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "BackfilledConcrete", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BackfilledSoil", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "BackfilledSoil", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Grouted", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cored", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Cored", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Prepped", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Prepped", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Measured", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Measured", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerSize", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerSize", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InProcess", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InProcess", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InStock", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InStock", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Delivered", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Delivered", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BuildRebuild", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BuildRebuild", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PreVideo", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideo", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerInstalled", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FinalVideo", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceFromUSMH", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceFromDSMH", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Map", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Map", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Issue", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Issue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cost", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "Cost", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VideoInspection", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoInspection", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CoRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CoRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PitRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PitRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CoPitLocation", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CoPitLocation", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PostContractDigRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PostContractDigRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "Comments", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@History", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "History", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DetailID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DetailID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DetailID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DetailID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Address", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Address", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Address", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PipeLocated", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeLocated", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PipeLocated", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeLocated", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ServicesLocated", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ServicesLocated", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ServicesLocated", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "ServicesLocated", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CoInstalled", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CoInstalled", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CoInstalled", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "CoInstalled", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BackfilledConcrete", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BackfilledConcrete", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BackfilledConcrete", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "BackfilledConcrete", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BackfilledSoil", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BackfilledSoil", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BackfilledSoil", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "BackfilledSoil", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Grouted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Grouted", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Cored", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Cored", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cored", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Cored", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Prepped", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Prepped", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Prepped", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Prepped", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Measured", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Measured", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Measured", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Measured", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerSize", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerSize", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerSize", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InProcess", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InProcess", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InProcess", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InProcess", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InStock", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InStock", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InStock", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InStock", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Delivered", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Delivered", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Delivered", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Delivered", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BuildRebuild", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BuildRebuild", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BuildRebuild", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BuildRebuild", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PreVideo", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideo", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PreVideo", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideo", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerInstalled", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerInstalled", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FinalVideo", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FinalVideo", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DistanceFromUSMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceFromUSMH", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DistanceFromDSMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceFromDSMH", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Map", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Map", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Map", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Map", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Issue", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Issue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Cost", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Cost", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cost", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "Cost", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Deleted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_VideoInspection", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoInspection", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VideoInspection", System.Data.SqlDbType.SmallDateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoInspection", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CoRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CoRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PitRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PitRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CoPitLocation", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CoPitLocation", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CoPitLocation", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CoPitLocation", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PostContractDigRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PostContractDigRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }





    
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATSET
        //

        /// <summary>
        /// LoadByIdCompanyId
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        /// <param name="mn">mn</param>
        /// <returns>Data</returns>
        public void LoadByIdCompanyId(Guid id, int companyId)
        {
            string commandText = String.Format("SELECT ID,RefID, COMPANY_ID, DetailID, Address, PipeLocated, ServicesLocated, CoInstalled, BackfilledConcrete, BackfilledSoil, Grouted, Cored, Prepped, Measured, LinerSize, InProcess, InStock, Delivered, BuildRebuild, PreVideo, LinerInstalled, FinalVideo, DistanceFromUSMH, DistanceFromDSMH, Map, Issue,  Cost, Deleted, VideoInspection, CoRequired, PitRequired, CoPitLocation, PostContractDigRequired, Comments, History FROM LFS_JUNCTION_LINER2 WHERE (ID = '{0}') AND (COMPANY_ID = {1})", id, companyId);
            FillData(commandText);
        }



        /// <summary>
        /// LoadByIdCompanyId
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        /// <param name="mn">mn</param>
        /// <returns>Data</returns>
        public void LoadAll()
        {
            string commandText = "SELECT ID,RefID, COMPANY_ID, DetailID, Address, PipeLocated, ServicesLocated, CoInstalled, BackfilledConcrete, BackfilledSoil, Grouted, Cored, Prepped, Measured, LinerSize, InProcess, InStock, Delivered, BuildRebuild, PreVideo, LinerInstalled, FinalVideo, DistanceFromUSMH, DistanceFromDSMH, Map, Issue,  Cost, Deleted, VideoInspection, CoRequired, PitRequired, CoPitLocation, PostContractDigRequired, Comments, History FROM LFS_JUNCTION_LINER2";
            FillData(commandText);
        }



        /// <summary>
        /// Update - JLiner
        /// </summary>
        public void Update()
        {
            DataTable jlinerChanges = Table.GetChanges();

            if (jlinerChanges == null) return;

            try
            {
                DB.Open();
                DB.BeginTransaction();

                Adapter.InsertCommand.Transaction = DB.Transaction;
                Adapter.UpdateCommand.Transaction = DB.Transaction;
                Adapter.DeleteCommand.Transaction = DB.Transaction;

                if ((jlinerChanges != null) && (jlinerChanges.Rows.Count > 0))
                {
                    Adapter.Update(jlinerChanges);
                }

                DB.CommitTransaction();
            }
            catch (DBConcurrencyException dBConcurrencyException)
            {
                DB.RollbackTransaction();
                throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
            }
            catch (SqlException sqlException)
            {
                DB.RollbackTransaction();
                byte severityLevel = sqlException.Class;
                if (severityLevel <= 16)
                {
                    throw new Exception("Low severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
                if ((severityLevel >= 17) && (severityLevel <= 19))
                {
                    throw new Exception("Mid severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
                if (severityLevel >= 20)
                {
                    throw new Exception("High severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
            }
            catch (Exception e)
            {
                DB.RollbackTransaction();
                throw new Exception("Unknow error. Your operation has been cancelled.", e);
            }
            finally
            {
                DB.Close();
            }
        }
    }
}
