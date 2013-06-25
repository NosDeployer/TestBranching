using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Section;

namespace LiquiForce.LFSLive.DA.CWP.Jliner
{
    /// <summary>
    /// JLinerGateway
    /// </summary>
    public class JlinerGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlinerGateway()
            : base("LFS_JUNCTION_LINER2")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlinerGateway(DataSet data)
            : base(data, "LFS_JUNCTION_LINER2")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SectionTDS();
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
            tableMapping.ColumnMappings.Add("CoCutDown", "CoCutDown");
            tableMapping.ColumnMappings.Add("FinalRestoration", "FinalRestoration");
            tableMapping.ColumnMappings.Add("ClientLateralID", "ClientLateralID");
            tableMapping.ColumnMappings.Add("VideoLengthToPropertyLine", "VideoLengthToPropertyLine");
            tableMapping.ColumnMappings.Add("LiningThruCo", "LiningThruCo");
            tableMapping.ColumnMappings.Add("HamiltonInspectionNumber", "HamiltonInspectionNumber");
            tableMapping.ColumnMappings.Add("NoticeDelivered", "NoticeDelivered");
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
                "PostContractDigRequired] = @Original_PostContractDigRequired) AND ((@IsNull_CoCu" +
                "tDown = 1 AND [CoCutDown] IS NULL) OR ([CoCutDown] = @Original_CoCutDown)) AND (" +
                "(@IsNull_FinalRestoration = 1 AND [FinalRestoration] IS NULL) OR ([FinalRestorat" +
                "ion] = @Original_FinalRestoration)) AND ((@IsNull_ClientLateralID = 1 AND [Clien" +
                "tLateralID] IS NULL) OR ([ClientLateralID] = @Original_ClientLateralID)) AND ((@" +
                "IsNull_VideoLengthToPropertyLine = 1 AND [VideoLengthToPropertyLine] IS NULL) OR" +
                " ([VideoLengthToPropertyLine] = @Original_VideoLengthToPropertyLine)) AND ([Lini" +
                "ngThruCo] = @Original_LiningThruCo) AND ((@IsNull_HamiltonInspectionNumber = 1 A" +
                "ND [HamiltonInspectionNumber] IS NULL) OR ([HamiltonInspectionNumber] = @Origina" +
                "l_HamiltonInspectionNumber)) AND ((@IsNull_NoticeDelivered = 1 AND [NoticeDelive" +
                "red] IS NULL) OR ([NoticeDelivered] = @Original_NoticeDelivered)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ID", global::System.Data.SqlDbType.UniqueIdentifier, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DetailID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DetailID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DetailID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DetailID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Address", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Address", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PipeLocated", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeLocated", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PipeLocated", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeLocated", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ServicesLocated", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServicesLocated", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ServicesLocated", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServicesLocated", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CoInstalled", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoInstalled", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CoInstalled", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoInstalled", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BackfilledConcrete", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BackfilledConcrete", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BackfilledConcrete", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BackfilledConcrete", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BackfilledSoil", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BackfilledSoil", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BackfilledSoil", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BackfilledSoil", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Grouted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Grouted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Grouted", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Grouted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Cored", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cored", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Cored", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cored", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Prepped", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Prepped", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Prepped", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Prepped", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Measured", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Measured", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Measured", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Measured", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LinerSize", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerSize", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LinerSize", global::System.Data.SqlDbType.VarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerSize", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_InProcess", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InProcess", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InProcess", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InProcess", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_InStock", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InStock", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InStock", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InStock", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Delivered", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Delivered", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Delivered", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Delivered", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BuildRebuild", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BuildRebuild", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BuildRebuild", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BuildRebuild", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PreVideo", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreVideo", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PreVideo", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreVideo", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LinerInstalled", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LinerInstalled", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_FinalVideo", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FinalVideo", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DistanceFromUSMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DistanceFromUSMH", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DistanceFromDSMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DistanceFromDSMH", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Map", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Map", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Map", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Map", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Issue", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Issue", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Cost", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Cost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Deleted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VideoInspection", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoInspection", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VideoInspection", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoInspection", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CoRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoRequired", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PitRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PitRequired", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CoPitLocation", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoPitLocation", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CoPitLocation", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoPitLocation", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PostContractDigRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PostContractDigRequired", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CoCutDown", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoCutDown", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CoCutDown", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoCutDown", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_FinalRestoration", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalRestoration", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FinalRestoration", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalRestoration", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClientLateralID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientLateralID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientLateralID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientLateralID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VideoLengthToPropertyLine", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLengthToPropertyLine", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VideoLengthToPropertyLine", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLengthToPropertyLine", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LiningThruCo", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiningThruCo", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_HamiltonInspectionNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HamiltonInspectionNumber", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HamiltonInspectionNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HamiltonInspectionNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_NoticeDelivered", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoticeDelivered", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NoticeDelivered", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoticeDelivered", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[LFS_JUNCTION_LINER2] ([ID], [RefID], [COMPANY_ID], [DetailID]," +
                " [Address], [PipeLocated], [ServicesLocated], [CoInstalled], [BackfilledConcrete" +
                "], [BackfilledSoil], [Grouted], [Cored], [Prepped], [Measured], [LinerSize], [In" +
                "Process], [InStock], [Delivered], [BuildRebuild], [PreVideo], [LinerInstalled], " +
                "[FinalVideo], [DistanceFromUSMH], [DistanceFromDSMH], [Map], [Issue], [Cost], [D" +
                "eleted], [VideoInspection], [CoRequired], [PitRequired], [CoPitLocation], [PostC" +
                "ontractDigRequired], [Comments], [History], [CoCutDown], [FinalRestoration], [Cl" +
                "ientLateralID], [VideoLengthToPropertyLine], [LiningThruCo], [HamiltonInspection" +
                "Number], [NoticeDelivered]) VALUES (@ID, @RefID, @COMPANY_ID, @DetailID, @Addres" +
                "s, @PipeLocated, @ServicesLocated, @CoInstalled, @BackfilledConcrete, @Backfille" +
                "dSoil, @Grouted, @Cored, @Prepped, @Measured, @LinerSize, @InProcess, @InStock, " +
                "@Delivered, @BuildRebuild, @PreVideo, @LinerInstalled, @FinalVideo, @DistanceFro" +
                "mUSMH, @DistanceFromDSMH, @Map, @Issue, @Cost, @Deleted, @VideoInspection, @CoRe" +
                "quired, @PitRequired, @CoPitLocation, @PostContractDigRequired, @Comments, @Hist" +
                "ory, @CoCutDown, @FinalRestoration, @ClientLateralID, @VideoLengthToPropertyLine" +
                ", @LiningThruCo, @HamiltonInspectionNumber, @NoticeDelivered);\r\nSELECT ID, RefID" +
                ", COMPANY_ID, DetailID, Address, PipeLocated, ServicesLocated, CoInstalled, Back" +
                "filledConcrete, BackfilledSoil, Grouted, Cored, Prepped, Measured, LinerSize, In" +
                "Process, InStock, Delivered, BuildRebuild, PreVideo, LinerInstalled, FinalVideo," +
                " DistanceFromUSMH, DistanceFromDSMH, Map, Issue, Cost, Deleted, VideoInspection," +
                " CoRequired, PitRequired, CoPitLocation, PostContractDigRequired, Comments, Hist" +
                "ory, CoCutDown, FinalRestoration, ClientLateralID, VideoLengthToPropertyLine, Li" +
                "ningThruCo, HamiltonInspectionNumber, NoticeDelivered FROM LFS_JUNCTION_LINER2 W" +
                "HERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RefID = @RefID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ID", global::System.Data.SqlDbType.UniqueIdentifier, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DetailID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DetailID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Address", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PipeLocated", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeLocated", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ServicesLocated", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServicesLocated", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoInstalled", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoInstalled", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BackfilledConcrete", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BackfilledConcrete", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BackfilledSoil", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BackfilledSoil", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Grouted", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Grouted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Cored", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cored", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Prepped", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Prepped", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Measured", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Measured", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerSize", global::System.Data.SqlDbType.VarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerSize", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InProcess", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InProcess", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InStock", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InStock", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Delivered", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Delivered", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BuildRebuild", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BuildRebuild", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PreVideo", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreVideo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerInstalled", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FinalVideo", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DistanceFromUSMH", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DistanceFromDSMH", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Map", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Map", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Issue", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Issue", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Cost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VideoInspection", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoInspection", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoRequired", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PitRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PitRequired", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoPitLocation", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoPitLocation", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PostContractDigRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PostContractDigRequired", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@History", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "History", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoCutDown", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoCutDown", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FinalRestoration", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalRestoration", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientLateralID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientLateralID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VideoLengthToPropertyLine", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLengthToPropertyLine", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LiningThruCo", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiningThruCo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HamiltonInspectionNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HamiltonInspectionNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NoticeDelivered", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoticeDelivered", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

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
                "[Comments] = @Comments, [History] = @History, [CoCutDown] = @CoCutDown, [FinalRe" +
                "storation] = @FinalRestoration, [ClientLateralID] = @ClientLateralID, [VideoLeng" +
                "thToPropertyLine] = @VideoLengthToPropertyLine, [LiningThruCo] = @LiningThruCo, " +
                "[HamiltonInspectionNumber] = @HamiltonInspectionNumber, [NoticeDelivered] = @Not" +
                "iceDelivered WHERE (([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND ([" +
                "COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_DetailID = 1 AND [DetailID] IS" +
                " NULL) OR ([DetailID] = @Original_DetailID)) AND ((@IsNull_Address = 1 AND [Addr" +
                "ess] IS NULL) OR ([Address] = @Original_Address)) AND ((@IsNull_PipeLocated = 1 " +
                "AND [PipeLocated] IS NULL) OR ([PipeLocated] = @Original_PipeLocated)) AND ((@Is" +
                "Null_ServicesLocated = 1 AND [ServicesLocated] IS NULL) OR ([ServicesLocated] = " +
                "@Original_ServicesLocated)) AND ((@IsNull_CoInstalled = 1 AND [CoInstalled] IS N" +
                "ULL) OR ([CoInstalled] = @Original_CoInstalled)) AND ((@IsNull_BackfilledConcret" +
                "e = 1 AND [BackfilledConcrete] IS NULL) OR ([BackfilledConcrete] = @Original_Bac" +
                "kfilledConcrete)) AND ((@IsNull_BackfilledSoil = 1 AND [BackfilledSoil] IS NULL)" +
                " OR ([BackfilledSoil] = @Original_BackfilledSoil)) AND ((@IsNull_Grouted = 1 AND" +
                " [Grouted] IS NULL) OR ([Grouted] = @Original_Grouted)) AND ((@IsNull_Cored = 1 " +
                "AND [Cored] IS NULL) OR ([Cored] = @Original_Cored)) AND ((@IsNull_Prepped = 1 A" +
                "ND [Prepped] IS NULL) OR ([Prepped] = @Original_Prepped)) AND ((@IsNull_Measured" +
                " = 1 AND [Measured] IS NULL) OR ([Measured] = @Original_Measured)) AND ((@IsNull" +
                "_LinerSize = 1 AND [LinerSize] IS NULL) OR ([LinerSize] = @Original_LinerSize)) " +
                "AND ((@IsNull_InProcess = 1 AND [InProcess] IS NULL) OR ([InProcess] = @Original" +
                "_InProcess)) AND ((@IsNull_InStock = 1 AND [InStock] IS NULL) OR ([InStock] = @O" +
                "riginal_InStock)) AND ((@IsNull_Delivered = 1 AND [Delivered] IS NULL) OR ([Deli" +
                "vered] = @Original_Delivered)) AND ((@IsNull_BuildRebuild = 1 AND [BuildRebuild]" +
                " IS NULL) OR ([BuildRebuild] = @Original_BuildRebuild)) AND ((@IsNull_PreVideo =" +
                " 1 AND [PreVideo] IS NULL) OR ([PreVideo] = @Original_PreVideo)) AND ((@IsNull_L" +
                "inerInstalled = 1 AND [LinerInstalled] IS NULL) OR ([LinerInstalled] = @Original" +
                "_LinerInstalled)) AND ((@IsNull_FinalVideo = 1 AND [FinalVideo] IS NULL) OR ([Fi" +
                "nalVideo] = @Original_FinalVideo)) AND ((@IsNull_DistanceFromUSMH = 1 AND [Dista" +
                "nceFromUSMH] IS NULL) OR ([DistanceFromUSMH] = @Original_DistanceFromUSMH)) AND " +
                "((@IsNull_DistanceFromDSMH = 1 AND [DistanceFromDSMH] IS NULL) OR ([DistanceFrom" +
                "DSMH] = @Original_DistanceFromDSMH)) AND ((@IsNull_Map = 1 AND [Map] IS NULL) OR" +
                " ([Map] = @Original_Map)) AND ([Issue] = @Original_Issue) AND ((@IsNull_Cost = 1" +
                " AND [Cost] IS NULL) OR ([Cost] = @Original_Cost)) AND ((@IsNull_Deleted = 1 AND" +
                " [Deleted] IS NULL) OR ([Deleted] = @Original_Deleted)) AND ((@IsNull_VideoInspe" +
                "ction = 1 AND [VideoInspection] IS NULL) OR ([VideoInspection] = @Original_Video" +
                "Inspection)) AND ([CoRequired] = @Original_CoRequired) AND ([PitRequired] = @Ori" +
                "ginal_PitRequired) AND ((@IsNull_CoPitLocation = 1 AND [CoPitLocation] IS NULL) " +
                "OR ([CoPitLocation] = @Original_CoPitLocation)) AND ([PostContractDigRequired] =" +
                " @Original_PostContractDigRequired) AND ((@IsNull_CoCutDown = 1 AND [CoCutDown] " +
                "IS NULL) OR ([CoCutDown] = @Original_CoCutDown)) AND ((@IsNull_FinalRestoration " +
                "= 1 AND [FinalRestoration] IS NULL) OR ([FinalRestoration] = @Original_FinalRest" +
                "oration)) AND ((@IsNull_ClientLateralID = 1 AND [ClientLateralID] IS NULL) OR ([" +
                "ClientLateralID] = @Original_ClientLateralID)) AND ((@IsNull_VideoLengthToProper" +
                "tyLine = 1 AND [VideoLengthToPropertyLine] IS NULL) OR ([VideoLengthToPropertyLi" +
                "ne] = @Original_VideoLengthToPropertyLine)) AND ([LiningThruCo] = @Original_Lini" +
                "ngThruCo) AND ((@IsNull_HamiltonInspectionNumber = 1 AND [HamiltonInspectionNumb" +
                "er] IS NULL) OR ([HamiltonInspectionNumber] = @Original_HamiltonInspectionNumber" +
                ")) AND ((@IsNull_NoticeDelivered = 1 AND [NoticeDelivered] IS NULL) OR ([NoticeD" +
                "elivered] = @Original_NoticeDelivered)));\r\nSELECT ID, RefID, COMPANY_ID, DetailI" +
                "D, Address, PipeLocated, ServicesLocated, CoInstalled, BackfilledConcrete, Backf" +
                "illedSoil, Grouted, Cored, Prepped, Measured, LinerSize, InProcess, InStock, Del" +
                "ivered, BuildRebuild, PreVideo, LinerInstalled, FinalVideo, DistanceFromUSMH, Di" +
                "stanceFromDSMH, Map, Issue, Cost, Deleted, VideoInspection, CoRequired, PitRequi" +
                "red, CoPitLocation, PostContractDigRequired, Comments, History, CoCutDown, Final" +
                "Restoration, ClientLateralID, VideoLengthToPropertyLine, LiningThruCo, HamiltonI" +
                "nspectionNumber, NoticeDelivered FROM LFS_JUNCTION_LINER2 WHERE (COMPANY_ID = @C" +
                "OMPANY_ID) AND (ID = @ID) AND (RefID = @RefID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ID", global::System.Data.SqlDbType.UniqueIdentifier, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DetailID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DetailID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Address", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PipeLocated", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeLocated", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ServicesLocated", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServicesLocated", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoInstalled", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoInstalled", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BackfilledConcrete", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BackfilledConcrete", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BackfilledSoil", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BackfilledSoil", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Grouted", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Grouted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Cored", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cored", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Prepped", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Prepped", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Measured", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Measured", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerSize", global::System.Data.SqlDbType.VarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerSize", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InProcess", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InProcess", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InStock", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InStock", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Delivered", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Delivered", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BuildRebuild", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BuildRebuild", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PreVideo", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreVideo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerInstalled", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FinalVideo", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DistanceFromUSMH", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DistanceFromDSMH", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Map", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Map", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Issue", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Issue", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Cost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VideoInspection", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoInspection", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoRequired", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PitRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PitRequired", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoPitLocation", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoPitLocation", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PostContractDigRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PostContractDigRequired", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@History", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "History", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoCutDown", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoCutDown", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FinalRestoration", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalRestoration", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientLateralID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientLateralID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VideoLengthToPropertyLine", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLengthToPropertyLine", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LiningThruCo", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiningThruCo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HamiltonInspectionNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HamiltonInspectionNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NoticeDelivered", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoticeDelivered", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ID", global::System.Data.SqlDbType.UniqueIdentifier, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DetailID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DetailID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DetailID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DetailID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Address", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Address", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Address", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PipeLocated", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeLocated", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PipeLocated", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeLocated", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ServicesLocated", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServicesLocated", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ServicesLocated", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServicesLocated", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CoInstalled", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoInstalled", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CoInstalled", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoInstalled", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BackfilledConcrete", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BackfilledConcrete", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BackfilledConcrete", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BackfilledConcrete", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BackfilledSoil", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BackfilledSoil", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BackfilledSoil", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BackfilledSoil", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Grouted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Grouted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Grouted", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Grouted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Cored", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cored", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Cored", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cored", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Prepped", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Prepped", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Prepped", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Prepped", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Measured", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Measured", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Measured", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Measured", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LinerSize", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerSize", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LinerSize", global::System.Data.SqlDbType.VarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerSize", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_InProcess", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InProcess", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InProcess", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InProcess", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_InStock", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InStock", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InStock", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InStock", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Delivered", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Delivered", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Delivered", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Delivered", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BuildRebuild", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BuildRebuild", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BuildRebuild", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BuildRebuild", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PreVideo", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreVideo", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PreVideo", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreVideo", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LinerInstalled", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LinerInstalled", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_FinalVideo", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FinalVideo", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DistanceFromUSMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DistanceFromUSMH", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromUSMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DistanceFromDSMH", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DistanceFromDSMH", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DistanceFromDSMH", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Map", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Map", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Map", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Map", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Issue", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Issue", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Cost", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Cost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Deleted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VideoInspection", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoInspection", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VideoInspection", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoInspection", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CoRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoRequired", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PitRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PitRequired", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CoPitLocation", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoPitLocation", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CoPitLocation", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoPitLocation", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PostContractDigRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PostContractDigRequired", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CoCutDown", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoCutDown", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CoCutDown", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoCutDown", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_FinalRestoration", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalRestoration", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FinalRestoration", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalRestoration", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClientLateralID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientLateralID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientLateralID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientLateralID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VideoLengthToPropertyLine", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLengthToPropertyLine", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VideoLengthToPropertyLine", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLengthToPropertyLine", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LiningThruCo", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiningThruCo", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_HamiltonInspectionNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HamiltonInspectionNumber", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HamiltonInspectionNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HamiltonInspectionNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_NoticeDelivered", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoticeDelivered", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NoticeDelivered", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoticeDelivered", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATSET
        //

        /// <summary>
        /// LoadByIdCompanyId
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByIdCompanyId(Guid id, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINERGATEWAY_LOADBYIDCOMPANYID", new SqlParameter("@id", id), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByIdCompanyId
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByIdCompanyIdRefId(Guid id, int companyId, int refId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINERGATEWAY_LOADBYIDCOMPANYIDREFID", new SqlParameter("@id", id), new SqlParameter("@companyId", companyId), new SqlParameter("@refId", refId));
            return Data;
        }       



        /// <summary>
        ///  Get a single jliner. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <returns>Row obtained</returns>
        public DataRow GetRow(Guid id, int refId)
        {
            string filter = string.Format("(ID = '{0}') AND (RefId = {1})", id, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Jliner.JlinerGateway.GetRow");
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// GetLastRefId from one section
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public int GetLastRefId(Guid id, int companyId)
        {
            string commandText = "SELECT MAX(RefID) FROM LFS_JUNCTION_LINER2 WHERE (ID = @id) AND (COMPANY_ID = @companyId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));

            object lastRefId = ExecuteScalar(command);

            return (lastRefId != DBNull.Value) ? (int)lastRefId : 0;
        }



        /// <summary>
        /// Verify is DetailId is used in section's jliner
        /// </summary>
        /// <param name="id">GUIS ID</param>
        /// <param name="companyId">companyId</param>
        /// <param name="detalId">DetailID</param>
        /// <returns></returns>
        public bool InUseDetailId(Guid id, int companyId, string detalId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_JUNCTION_LINER2 WHERE (ID = @id) AND (COMPANY_ID = @companyId) AND (DetailID = @detailId)  AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));
            command.Parameters.Add(new SqlParameter("@detailId", detalId));

            int count = (int)ExecuteScalar(command);

            return (count > 0) ? true : false;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="detailId">detailId</param>
        /// <param name="address">address</param>
        /// <param name="pipeLocated">pipeLocated</param>
        /// <param name="servicesLocated">servicesLocated</param>
        /// <param name="coInstalled">coInstalled</param>
        /// <param name="backfilledConcrete">backfilledConcrete</param>
        /// <param name="backfilledSoil">backfilledSoil</param>
        /// <param name="grouted">grouted</param>
        /// <param name="cored">cored</param>
        /// <param name="prepped">prepped</param>
        /// <param name="measured">measured</param>
        /// <param name="linerSize">linerSize</param>
        /// <param name="inProcess">inProcess</param>
        /// <param name="inStock">inStock</param>
        /// <param name="delivered">delivered</param>
        /// <param name="buildRebuild">buildRebuild</param>
        /// <param name="preVideo">preVideo</param>        
        /// <param name="linerInstalled">linerInstalled</param>
        /// <param name="finalVideo">finalVideo</param>
        /// <param name="distanceFromUSMH">distanceFromUSMH</param>
        /// <param name="distanceFromDSMH">distanceFromDSMH</param>
        /// <param name="map">map</param>
        /// <param name="issue">issue</param>
        /// <param name="cost">cost</param>
        /// <param name="deleted">deleted</param>
        /// <param name="videoInspection">videoInspection</param>
        /// <param name="coRequired">coRequired</param>
        /// <param name="pitRequired">pitRequired</param>
        /// <param name="coPitLocation">coPitLocation</param>
        /// <param name="postContractDigRequired">postContractDigRequired</param>
        /// <param name="comments">comments</param>
        /// <param name="history">history</param>
        /// <param name="coCutDown">coCutDown</param>
        /// <param name="finalRestoration">finalRestoration</param>
        /// <param name="clientLateralID">clientLateralID</param>
        /// <param name="videoLengthToPropertyLine">videoLengthToPropertyLine</param>
        /// <param name="liningThruCo">liningThruCo</param>
        /// <param name="hamiltonInspectionNumber">hamiltonInspectionNumber</param>
        /// <param name="noticeDelivered">noticeDelivered</param>                
        /// <returns></returns>
        public int Insert(Guid id, int refId, int companyId, string detailId, string address, DateTime? pipeLocated, DateTime? servicesLocated, DateTime? coInstalled, DateTime? backfilledConcrete, DateTime? backfilledSoil, DateTime? grouted, DateTime? cored, DateTime? prepped, DateTime? measured, string linerSize, DateTime? inProcess, DateTime? inStock, DateTime? delivered, int? buildRebuild, DateTime? preVideo, DateTime? linerInstalled, DateTime? finalVideo, double? distanceFromUSMH, double? distanceFromDSMH, string map, string issue, decimal? cost, bool deleted, DateTime? videoInspection, bool coRequired, bool pitRequired, string coPitLocation, bool postContractDigRequired, string comments, string history, DateTime? coCutDown, DateTime? finalRestoration, string clientLateralID, string videoLengthToPropertyLine, bool liningThruCo, string hamiltonInspectionNumber, DateTime? noticeDelivered)
        {
            SqlParameter idParameter = new SqlParameter("ID", id);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter detailIdParameter = (detailId.Trim() != "") ? new SqlParameter("DetailID", detailId.Trim()) : new SqlParameter("DetailID", DBNull.Value);
            SqlParameter addressParameter = (address.Trim() != "") ? new SqlParameter("Address", address.Trim()) : new SqlParameter("Address", DBNull.Value);
            SqlParameter pipeLocatedParameter = (pipeLocated.HasValue) ? new SqlParameter("PipeLocated", pipeLocated) : new SqlParameter("PipeLocated", DBNull.Value);
            SqlParameter servicesLocatedParameter = (servicesLocated.HasValue) ? new SqlParameter("ServicesLocated", servicesLocated) : new SqlParameter("ServicesLocated", DBNull.Value);
            SqlParameter coInstalledParameter = (coInstalled.HasValue) ? new SqlParameter("CoInstalled", coInstalled) : new SqlParameter("CoInstalled", DBNull.Value);
            SqlParameter backfilledConcreteParameter = (backfilledConcrete.HasValue) ? new SqlParameter("BackfilledConcrete", backfilledConcrete.ToString().Trim()) : new SqlParameter("BackfilledConcrete", DBNull.Value);
            SqlParameter backfilledSoilParameter = (backfilledSoil.HasValue) ? new SqlParameter("BackfilledSoil", backfilledSoil.ToString().Trim()) : new SqlParameter("BackfilledSoil", DBNull.Value);            
            SqlParameter groutedParameter = (grouted.HasValue) ? new SqlParameter("Grouted", grouted.ToString().Trim()) : new SqlParameter("Grouted", DBNull.Value);
            SqlParameter coredParameter = (cored.HasValue) ? new SqlParameter("Cored", cored) : new SqlParameter("Cored", DBNull.Value);
            SqlParameter preppedParameter = (prepped.HasValue) ? new SqlParameter("Prepped", prepped) : new SqlParameter("Prepped", DBNull.Value);
            SqlParameter measuredParameter = (measured.HasValue) ? new SqlParameter("Measured", measured) : new SqlParameter("Measured", DBNull.Value);
            SqlParameter linerSizeParameter = (linerSize.Trim() != "") ? new SqlParameter("LinerSize", linerSize.Trim()) : new SqlParameter("LinerSize", DBNull.Value);
            SqlParameter inProcessParameter = (inProcess.HasValue) ? new SqlParameter("InProcess", inProcess) : new SqlParameter("InProcess", DBNull.Value);
            SqlParameter inStockParameter = (inStock.HasValue) ? new SqlParameter("InStock", inStock) : new SqlParameter("InStock", DBNull.Value);
            SqlParameter deliveredParameter = (delivered.HasValue) ? new SqlParameter("Delivered", delivered) : new SqlParameter("Delivered", DBNull.Value);
            SqlParameter buildRebuildParameter = (buildRebuild.HasValue) ? new SqlParameter("BuildRebuild", buildRebuild) : new SqlParameter("BuildRebuild", DBNull.Value);
            SqlParameter preVideoParameter = (preVideo.HasValue) ? new SqlParameter("PreVideo", preVideo) : new SqlParameter("PreVideo", DBNull.Value);
            SqlParameter linerInstalledParameter = (linerInstalled.HasValue) ? new SqlParameter("LinerInstalled", linerInstalled) : new SqlParameter("LinerInstalled", DBNull.Value);
            SqlParameter finalVideoParameter = (finalVideo.HasValue) ? new SqlParameter("FinalVideo", finalVideo) : new SqlParameter("FinalVideo", DBNull.Value);
            SqlParameter distanceFromUSMHParameter = (distanceFromUSMH.HasValue ) ? new SqlParameter("DistanceFromUSMH", distanceFromUSMH) : new SqlParameter("DistanceFromUSMH", DBNull.Value);
            SqlParameter distanceFromDSMHParameter = (distanceFromDSMH.HasValue) ? new SqlParameter("DistanceFromDSMH", distanceFromDSMH) : new SqlParameter("DistanceFromDSMH", DBNull.Value);
            SqlParameter mapParameter = (map.Trim() != "") ? new SqlParameter("Map", map.Trim()) : new SqlParameter("Map", DBNull.Value);
            SqlParameter issueParameter = (issue.Trim() != "") ? new SqlParameter("Issue", issue.Trim()) : new SqlParameter("Issue", DBNull.Value);
            SqlParameter costParameter = (cost.HasValue) ? new SqlParameter("Cost", cost) : new SqlParameter("Cost", DBNull.Value);
            costParameter.SqlDbType = SqlDbType.Money;
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter videoInspectionParameter = (videoInspection.HasValue) ? new SqlParameter("VideoInspection", videoInspection) : new SqlParameter("VideoInspection", DBNull.Value);
            SqlParameter coRequiredParameter = new SqlParameter("CoRequired", coRequired);
            SqlParameter pitRequiredParameter = new SqlParameter("PitRequired", pitRequired);
            SqlParameter coPitLocationParameter = (coPitLocation.Trim() != "") ? new SqlParameter("CoPitLocation", coPitLocation.Trim()) : new SqlParameter("CoPitLocation", DBNull.Value);
            SqlParameter postContractDigRequiredParameter = new SqlParameter("PostContractDigRequired", postContractDigRequired);
            SqlParameter commentsParameter = (comments.Trim() != "") ? new SqlParameter("Comments", comments.Trim()) : new SqlParameter("Comments", DBNull.Value);
            SqlParameter historyParameter = (history.Trim() != "") ? new SqlParameter("History", history.Trim()) : new SqlParameter("History", DBNull.Value);
            SqlParameter coCutDownParameter = (coCutDown.HasValue) ? new SqlParameter("CoCutDown", coCutDown) : new SqlParameter("CoCutDown", DBNull.Value);
            SqlParameter finalRestorationParameter = (finalRestoration.HasValue) ? new SqlParameter("FinalRestoration", finalRestoration) : new SqlParameter("FinalRestoration", DBNull.Value);
            SqlParameter clientLateralIDParameter = (clientLateralID.Trim() != "") ? new SqlParameter("ClientLateralID", clientLateralID.Trim()) : new SqlParameter("ClientLateralID", DBNull.Value);
            SqlParameter videoLengthToPropertyLineParameter = (videoLengthToPropertyLine.Trim() != "") ? new SqlParameter("VideoLengthToPropertyLine", videoLengthToPropertyLine.Trim()) : new SqlParameter("VideoLengthToPropertyLine", DBNull.Value);
            SqlParameter liningThruCoParameter = new SqlParameter("LiningThruCo", liningThruCo);
            SqlParameter hamiltonInspectionNumberParameter = (hamiltonInspectionNumber.Trim() != "") ? new SqlParameter("HamiltonInspectionNumber", hamiltonInspectionNumber.Trim()) : new SqlParameter("HamiltonInspectionNumber", DBNull.Value);
            SqlParameter noticeDeliveredParameter = (noticeDelivered.HasValue) ? new SqlParameter("NoticeDelivered", noticeDelivered) : new SqlParameter("NoticeDelivered", DBNull.Value);

            string command = "INSERT INTO [dbo].[LFS_JUNCTION_LINER2] ([ID], [RefID], [COMPANY_ID], [DetailID]," +
                " [Address], [PipeLocated], [ServicesLocated], [CoInstalled], [BackfilledConcrete" +
                "], [BackfilledSoil], [Grouted], [Cored], [Prepped], [Measured], [LinerSize], [InProcess], [InStock], [Delivered], [BuildRebuild], [PreVideo], [LinerInstalled], " +
                "[FinalVideo], [DistanceFromUSMH], [DistanceFromDSMH], [Map], [Issue], [Cost], [Deleted], [VideoInspection], [CoRequired], [PitRequired], [CoPitLocation], [PostC" +
                "ontractDigRequired], [Comments], [History], [CoCutDown], [FinalRestoration], [ClientLateralID], [VideoLengthToPropertyLine], [LiningThruCo], [HamiltonInspection" +
                "Number], [NoticeDelivered]) VALUES (@ID, @RefID, @COMPANY_ID, @DetailID, @Address, @PipeLocated, @ServicesLocated, @CoInstalled, @BackfilledConcrete, @Backfille" +
                "dSoil, @Grouted, @Cored, @Prepped, @Measured, @LinerSize, @InProcess, @InStock, @Delivered, @BuildRebuild, @PreVideo, @LinerInstalled, @FinalVideo, @DistanceFro" +
                "mUSMH, @DistanceFromDSMH, @Map, @Issue, @Cost, @Deleted, @VideoInspection, @CoRequired, @PitRequired, @CoPitLocation, @PostContractDigRequired, @Comments, @Hist" +
                "ory, @CoCutDown, @FinalRestoration, @ClientLateralID, @VideoLengthToPropertyLine, @LiningThruCo, @HamiltonInspectionNumber, @NoticeDelivered)";

            int rowsAffected = (int)ExecuteNonQuery(command, idParameter, refIdParameter, companyIdParameter, detailIdParameter, addressParameter, pipeLocatedParameter, servicesLocatedParameter, coInstalledParameter, backfilledConcreteParameter, backfilledSoilParameter, groutedParameter, coredParameter, preppedParameter, measuredParameter, linerSizeParameter, inProcessParameter, inStockParameter, deliveredParameter, buildRebuildParameter, preVideoParameter, linerInstalledParameter, finalVideoParameter, distanceFromUSMHParameter, distanceFromDSMHParameter, mapParameter, issueParameter, costParameter, deletedParameter, videoInspectionParameter, coRequiredParameter, pitRequiredParameter, coPitLocationParameter, postContractDigRequiredParameter, commentsParameter, historyParameter, coCutDownParameter, finalRestorationParameter, clientLateralIDParameter, videoLengthToPropertyLineParameter, liningThruCoParameter, hamiltonInspectionNumberParameter, noticeDeliveredParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update direct
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDetailId">originalDetailId</param>
        /// <param name="originalAddress">originalAddress</param>
        /// <param name="originalPipeLocated">originalPipeLocated</param>
        /// <param name="originalServicesLocated">originalServicesLocated</param>
        /// <param name="originalCoInstalled">originalCoInstalled</param>
        /// <param name="originalBackfilledConcrete">originalBackfilledConcrete</param>
        /// <param name="originalBackfilledSoil">originalBackfilledSoil</param>
        /// <param name="originalGrouted">originalGrouted</param>
        /// <param name="originalCored">originalCored</param>
        /// <param name="originalPrepped">originalPrepped</param>
        /// <param name="originalMeasured">originalMeasured</param>
        /// <param name="originalLinerSize">originalLinerSize</param>
        /// <param name="originalInProcess">originalInProcess</param>
        /// <param name="originalInStock">originalInStock</param>
        /// <param name="originalDelivered">originalDelivered</param>
        /// <param name="originalBuildRebuild">originalBuildRebuild</param>
        /// <param name="originalPreVideo">originalPreVideo</param>        
        /// <param name="originalLinerInstalled">originalLinerInstalled</param>
        /// <param name="originalFinalVideo">originalFinalVideo</param>
        /// <param name="originalDistanceFromUSMH">originalDistanceFromUSMH</param>
        /// <param name="originalDistanceFromDSMH">originalDistanceFromDSMH</param>
        /// <param name="originalMap">originalMap</param>
        /// <param name="originalIssue">originalIssue</param>
        /// <param name="originalCost">originalCost</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalVideoInspection">originalVideoInspection</param>
        /// <param name="originalCoRequired">originalCoRequired</param>
        /// <param name="originalPitRequired">originalPitRequired</param>
        /// <param name="originalCoPitLocation">originalCoPitLocation</param>
        /// <param name="originalPostContractDigRequired">originalPostContractDigRequired</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalHistory">originalHistory</param>
        /// <param name="originalCoCutDown">originalCoCutDown</param>
        /// <param name="originalFinalRestoration">originalFinalRestoration</param>
        /// <param name="originalClientLateralID">originalClientLateralID</param>
        /// <param name="originalVideoLengthToPropertyLine">originalVideoLengthToPropertyLine</param>
        /// <param name="originalLiningThruCo">originalLiningThruCo</param>
        /// <param name="originalHamiltonInspectionNumber">originalHamiltonInspectionNumber</param>
        /// <param name="originalNoticeDelivered">originalNoticeDelivered</param>
        ///
        /// <param name="newId">newId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDetailId">newDetailId</param>
        /// <param name="newAddress">newAddress</param>
        /// <param name="newPipeLocated">newPipeLocated</param>
        /// <param name="newServicesLocated">newServicesLocated</param>
        /// <param name="newCoInstalled">newCoInstalled</param>
        /// <param name="newBackfilledConcrete">newBackfilledConcrete</param>
        /// <param name="newBackfilledSoil">newBackfilledSoil</param>
        /// <param name="newGrouted">newGrouted</param>
        /// <param name="newCored">newCored</param>
        /// <param name="newPrepped">newPrepped</param>
        /// <param name="newMeasured">newMeasured</param>
        /// <param name="newLinerSize">newLinerSize</param>
        /// <param name="newInProcess">newInProcess</param>
        /// <param name="newInStock">newInStock</param>
        /// <param name="newDelivered">newDelivered</param>
        /// <param name="newBuildRebuild">newBuildRebuild</param>
        /// <param name="newPreVideo">newPreVideo</param>        
        /// <param name="newLinerInstalled">newLinerInstalled</param>
        /// <param name="newFinalVideo">newFinalVideo</param>
        /// <param name="newDistanceFromUSMH">newDistanceFromUSMH</param>
        /// <param name="newDistanceFromDSMH">newDistanceFromDSMH</param>
        /// <param name="newMap">newMap</param>
        /// <param name="newIssue">newIssue</param>
        /// <param name="newCost">newCost</param>
        /// <param name="newDeleted">newDeleted</param>        
        /// <param name="newVideoInspection">newVideoInspection</param>
        /// <param name="newCoRequired">newCoRequired</param>
        /// <param name="newPitRequired">newPitRequired</param>
        /// <param name="newCoPitLocation">newCoPitLocation</param>
        /// <param name="newPostContractDigRequired">newPostContractDigRequired</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newHistory">newHistory</param>
        /// <param name="newCoCutDown">newCoCutDown</param>
        /// <param name="newFinalRestoration">newFinalRestoration</param>
        /// <param name="newClientLateralID">newClientLateralID</param>
        /// <param name="newVideoLengthToPropertyLine">newVideoLengthToPropertyLine</param>
        /// <param name="newLiningThruCo">newLiningThruCo</param>
        /// <param name="newHamiltonInspectionNumber">newHamiltonInspectionNumber</param>
        /// <param name="newNoticeDelivered">newNoticeDelivered</param>
        public int Update(Guid originalId, int originalRefId, int originalCompanyId, string originalDetailId, string originalAddress, DateTime? originalPipeLocated, DateTime? originalServicesLocated, DateTime? originalCoInstalled, DateTime? originalBackfilledConcrete, DateTime? originalBackfilledSoil, DateTime? originalGrouted, DateTime? originalCored, DateTime? originalPrepped, DateTime? originalMeasured, string originalLinerSize, DateTime? originalInProcess, DateTime? originalInStock, DateTime? originalDelivered, int? originalBuildRebuild, DateTime? originalPreVideo, DateTime? originalLinerInstalled, DateTime? originalFinalVideo, double? originalDistanceFromUSMH, double? originalDistanceFromDSMH, string originalMap, string originalIssue, decimal? originalCost, bool originalDeleted, DateTime? originalVideoInspection, bool originalCoRequired, bool originalPitRequired, string originalCoPitLocation, bool originalPostContractDigRequired, string originalComments, string originalHistory, DateTime? originalCoCutDown, DateTime? originalFinalRestoration, string originalClientLateralID, string originalVideoLengthToPropertyLine, bool originalLiningThruCo, string originalHamiltonInspectionNumber, DateTime? originalNoticeDelivered, Guid newId, int newRefId, int newCompanyId, string newDetailId, string newAddress, DateTime? newPipeLocated, DateTime? newServicesLocated, DateTime? newCoInstalled, DateTime? newBackfilledConcrete, DateTime? newBackfilledSoil, DateTime? newGrouted, DateTime? newCored, DateTime? newPrepped, DateTime? newMeasured, string newLinerSize, DateTime? newInProcess, DateTime? newInStock, DateTime? newDelivered, int? newBuildRebuild, DateTime? newPreVideo, DateTime? newLinerInstalled, DateTime? newFinalVideo, double? newDistanceFromUSMH, double? newDistanceFromDSMH, string newMap, string newIssue, decimal? newCost, bool newDeleted, DateTime? newVideoInspection, bool newCoRequired, bool newPitRequired, string newCoPitLocation, bool newPostContractDigRequired, string newComments, string newHistory, DateTime? newCoCutDown, DateTime? newFinalRestoration, string newClientLateralID, string newVideoLengthToPropertyLine, bool newLiningThruCo, string newHamiltonInspectionNumber, DateTime? newNoticeDelivered)
        {
            SqlParameter originalIdParameter = new SqlParameter("Original_ID", originalId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalDetailIdParameter = (originalDetailId.Trim() != "") ? new SqlParameter("Original_DetailID", originalDetailId.Trim()) : new SqlParameter("Original_DetailID", DBNull.Value);
            SqlParameter originalAddressParameter = (originalAddress.Trim() != "") ? new SqlParameter("Original_Address", originalAddress.Trim()) : new SqlParameter("Original_Address", DBNull.Value);
            SqlParameter originalPipeLocatedParameter = (originalPipeLocated.HasValue) ? new SqlParameter("Original_PipeLocated", originalPipeLocated) : new SqlParameter("Original_PipeLocated", DBNull.Value);
            SqlParameter originalServicesLocatedParameter = (originalServicesLocated.HasValue) ? new SqlParameter("Original_ServicesLocated", originalServicesLocated) : new SqlParameter("Original_ServicesLocated", DBNull.Value);
            SqlParameter originalCoInstalledParameter = (originalCoInstalled.HasValue) ? new SqlParameter("Original_CoInstalled", originalCoInstalled) : new SqlParameter("Original_CoInstalled", DBNull.Value);
            SqlParameter originalBackfilledConcreteParameter = (originalBackfilledConcrete.HasValue) ? new SqlParameter("Original_BackfilledConcrete", originalBackfilledConcrete) : new SqlParameter("Original_BackfilledConcrete", DBNull.Value);
            SqlParameter originalBackfilledSoilParameter = (originalBackfilledSoil.HasValue) ? new SqlParameter("Original_BackfilledSoil", originalBackfilledSoil) : new SqlParameter("Original_BackfilledSoil", DBNull.Value);
            SqlParameter originalGroutedParameter = (originalGrouted.HasValue) ? new SqlParameter("Original_Grouted", originalGrouted) : new SqlParameter("Original_Grouted", DBNull.Value);
            SqlParameter originalCoredParameter = (originalCored.HasValue) ? new SqlParameter("Original_Cored", originalCored) : new SqlParameter("Original_Cored", DBNull.Value);
            SqlParameter originalPreppedParameter = (originalPrepped.HasValue) ? new SqlParameter("Original_Prepped", originalPrepped) : new SqlParameter("Original_Prepped", DBNull.Value);
            SqlParameter originalMeasuredParameter = (originalMeasured.HasValue) ? new SqlParameter("Original_Measured", originalMeasured) : new SqlParameter("Original_Measured", DBNull.Value);
            SqlParameter originalLinerSizeParameter = (originalLinerSize.Trim() != "") ? new SqlParameter("Original_LinerSize", originalLinerSize.Trim()) : new SqlParameter("Original_LinerSize", DBNull.Value);
            SqlParameter originalInProcessParameter = (originalInProcess.HasValue) ? new SqlParameter("Original_InProcess", originalInProcess) : new SqlParameter("Original_InProcess", DBNull.Value);
            SqlParameter originalInStockParameter = (originalInStock.HasValue) ? new SqlParameter("Original_InStock", originalInStock) : new SqlParameter("Original_InStock", DBNull.Value);
            SqlParameter originalDeliveredParameter = (originalDelivered.HasValue) ? new SqlParameter("Original_Delivered", originalDelivered) : new SqlParameter("Original_Delivered", DBNull.Value);
            SqlParameter originalBuildRebuildParameter = (originalBuildRebuild.HasValue) ? new SqlParameter("Original_BuildRebuild", originalBuildRebuild) : new SqlParameter("Original_BuildRebuild", DBNull.Value);
            SqlParameter originalPreVideoParameter = (originalPreVideo.HasValue) ? new SqlParameter("Original_PreVideo", originalPreVideo) : new SqlParameter("Original_PreVideo", DBNull.Value);
            SqlParameter originalLinerInstalledParameter = (originalLinerInstalled.HasValue) ? new SqlParameter("Original_LinerInstalled", originalLinerInstalled) : new SqlParameter("Original_LinerInstalled", DBNull.Value);
            SqlParameter originalFinalVideoParameter = (originalFinalVideo.HasValue) ? new SqlParameter("Original_FinalVideo", originalFinalVideo) : new SqlParameter("Original_FinalVideo", DBNull.Value);
            SqlParameter originalDistanceFromUSMHParameter = (originalDistanceFromUSMH.HasValue) ? new SqlParameter("Original_DistanceFromUSMH", originalDistanceFromUSMH) : new SqlParameter("Original_DistanceFromUSMH", DBNull.Value);
            SqlParameter originalDistanceFromDSMHParameter = (originalDistanceFromDSMH.HasValue) ? new SqlParameter("Original_DistanceFromDSMH", originalDistanceFromDSMH) : new SqlParameter("Original_DistanceFromDSMH", DBNull.Value);
            SqlParameter originalMapParameter = (originalMap.Trim() != "") ? new SqlParameter("Original_Map", originalMap.Trim()) : new SqlParameter("Original_Map", DBNull.Value);
            SqlParameter originalIssueParameter = (originalIssue.Trim() != "") ? new SqlParameter("Original_Issue", originalIssue.Trim()) : new SqlParameter("Original_Issue", DBNull.Value);
            SqlParameter originalCostParameter = (originalCost.HasValue) ? new SqlParameter("Original_Cost", originalCost) : new SqlParameter("Original_Cost", DBNull.Value);
            originalCostParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalVideoInspectionParameter = (originalVideoInspection.HasValue) ? new SqlParameter("Original_VideoInspection", originalVideoInspection) : new SqlParameter("Original_VideoInspection", DBNull.Value);
            SqlParameter originalCoRequiredParameter = new SqlParameter("Original_CoRequired", originalCoRequired);
            SqlParameter originalPitRequiredParameter = new SqlParameter("Original_PitRequired", originalPitRequired);            
            SqlParameter originalCoPitLocationParameter = (originalCoPitLocation.Trim() != "") ? new SqlParameter("Original_CoPitLocation", originalCoPitLocation.Trim()) : new SqlParameter("Original_CoPitLocation", DBNull.Value);
            SqlParameter originalPostContractDigRequiredParameter = new SqlParameter("Original_PostContractDigRequired", originalPostContractDigRequired);
            SqlParameter originalCommentsParameter = (originalComments.Trim() != "") ? new SqlParameter("Original_Comments", originalComments.Trim()) : new SqlParameter("Original_Comments", DBNull.Value);
            SqlParameter originalHistoryParameter = (originalHistory.Trim() != "") ? new SqlParameter("Original_History", originalHistory.Trim()) : new SqlParameter("Original_History", DBNull.Value);
            SqlParameter originalCoCutDownParameter = (originalCoCutDown.HasValue) ? new SqlParameter("Original_CoCutDown", originalCoCutDown) : new SqlParameter("Original_CoCutDown", DBNull.Value);
            SqlParameter originalFinalRestorationParameter = (originalFinalRestoration.HasValue) ? new SqlParameter("Original_FinalRestoration", originalFinalRestoration) : new SqlParameter("Original_FinalRestoration", DBNull.Value);
            SqlParameter originalClientLateralIDParameter = (originalClientLateralID.Trim() != "") ? new SqlParameter("Original_ClientLateralID", originalClientLateralID.Trim()) : new SqlParameter("Original_ClientLateralID", DBNull.Value);
            SqlParameter originalVideoLengthToPropertyLineParameter = (originalVideoLengthToPropertyLine.Trim() != "") ? new SqlParameter("Original_VideoLengthToPropertyLine", originalVideoLengthToPropertyLine.Trim()) : new SqlParameter("Original_VideoLengthToPropertyLine", DBNull.Value);
            SqlParameter originalLiningThruCoParameter = new SqlParameter("Original_LiningThruCo", originalLiningThruCo);
            SqlParameter originalHamiltonInspectionNumberParameter = (originalHamiltonInspectionNumber.Trim() != "") ? new SqlParameter("Original_HamiltonInspectionNumber", originalHamiltonInspectionNumber.Trim()) : new SqlParameter("Original_HamiltonInspectionNumber", DBNull.Value);
            SqlParameter originalNoticeDeliveredParameter = (originalNoticeDelivered.HasValue) ? new SqlParameter("Original_NoticeDelivered", originalNoticeDelivered) : new SqlParameter("Original_NoticeDelivered", DBNull.Value);

            SqlParameter newIdParameter = new SqlParameter("ID", newId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", newRefId);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newDetailIdParameter = (newDetailId.Trim() != "") ? new SqlParameter("DetailID", newDetailId) : new SqlParameter("DetailID", DBNull.Value);
            SqlParameter newAddressParameter = (newAddress.Trim() != "") ? new SqlParameter("Address", newAddress.Trim()) : new SqlParameter("Address", DBNull.Value);
            SqlParameter newPipeLocatedParameter = (newPipeLocated.HasValue) ? new SqlParameter("PipeLocated", newPipeLocated) : new SqlParameter("PipeLocated", DBNull.Value);
            SqlParameter newServicesLocatedParameter = (newServicesLocated.HasValue) ? new SqlParameter("ServicesLocated", newServicesLocated) : new SqlParameter("ServicesLocated", DBNull.Value);
            SqlParameter newCoInstalledParameter = (newCoInstalled.HasValue) ? new SqlParameter("CoInstalled", newCoInstalled) : new SqlParameter("CoInstalled", DBNull.Value);
            SqlParameter newBackfilledConcreteParameter = (newBackfilledConcrete.HasValue) ? new SqlParameter("BackfilledConcrete", newBackfilledConcrete) : new SqlParameter("BackfilledConcrete", DBNull.Value);
            SqlParameter newBackfilledSoilParameter = (newBackfilledSoil.HasValue) ? new SqlParameter("BackfilledSoil", newBackfilledSoil) : new SqlParameter("BackfilledSoil", DBNull.Value);
            SqlParameter newGroutedParameter = (newGrouted.HasValue) ? new SqlParameter("Grouted", newGrouted) : new SqlParameter("Grouted", DBNull.Value);
            SqlParameter newCoredParameter = (newCored.HasValue) ? new SqlParameter("Cored", newCored) : new SqlParameter("Cored", DBNull.Value);
            SqlParameter newPreppedParameter = (newPrepped.HasValue) ? new SqlParameter("Prepped", newPrepped) : new SqlParameter("Prepped", DBNull.Value);
            SqlParameter newMeasuredParameter = (newMeasured.HasValue) ? new SqlParameter("Measured", newMeasured) : new SqlParameter("Measured", DBNull.Value);
            SqlParameter newLinerSizeParameter = (newLinerSize.Trim() != "") ? new SqlParameter("LinerSize", newLinerSize.Trim()) : new SqlParameter("LinerSize", DBNull.Value);
            SqlParameter newInProcessParameter = (newInProcess.HasValue) ? new SqlParameter("InProcess", newInProcess) : new SqlParameter("InProcess", DBNull.Value);
            SqlParameter newInStockParameter = (newInStock.HasValue) ? new SqlParameter("InStock", newInStock) : new SqlParameter("InStock", DBNull.Value);
            SqlParameter newDeliveredParameter = (newDelivered.HasValue) ? new SqlParameter("Delivered", newDelivered.ToString().Trim()) : new SqlParameter("Delivered", DBNull.Value);
            SqlParameter newBuildRebuildParameter = (newBuildRebuild.HasValue) ? new SqlParameter("BuildRebuild", newBuildRebuild) : new SqlParameter("BuildRebuild", DBNull.Value);
            SqlParameter newPreVideoParameter = (newPreVideo.HasValue) ? new SqlParameter("PreVideo", newPreVideo.ToString().Trim()) : new SqlParameter("PreVideo", DBNull.Value);
            SqlParameter newLinerInstalledParameter = (newLinerInstalled.HasValue) ? new SqlParameter("LinerInstalled", newLinerInstalled.ToString().Trim()) : new SqlParameter("LinerInstalled", DBNull.Value);
            SqlParameter newFinalVideoParameter = (newFinalVideo.HasValue) ? new SqlParameter("FinalVideo", newFinalVideo) : new SqlParameter("FinalVideo", DBNull.Value);
            SqlParameter newDistanceFromUSMHParameter = (newDistanceFromUSMH.HasValue) ? new SqlParameter("DistanceFromUSMH", newDistanceFromUSMH) : new SqlParameter("DistanceFromUSMH", DBNull.Value);
            SqlParameter newDistanceFromDSMHParameter = (newDistanceFromDSMH.HasValue ) ? new SqlParameter("DistanceFromDSMH", newDistanceFromDSMH) : new SqlParameter("DistanceFromDSMH", DBNull.Value);
            SqlParameter newMapParameter = (newMap.Trim() != "") ? new SqlParameter("Map", newMap.Trim()) : new SqlParameter("Map", DBNull.Value);
            SqlParameter newIssueParameter = (newIssue.Trim() != "") ? new SqlParameter("Issue", newIssue.Trim()) : new SqlParameter("Issue", DBNull.Value);
            SqlParameter newCostParameter = (newCost.HasValue) ? new SqlParameter("Cost", newCost) : new SqlParameter("Cost", DBNull.Value);
            newCostParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newVideoInspectionParameter = (newVideoInspection.HasValue) ? new SqlParameter("VideoInspection", newVideoInspection.ToString().Trim()) : new SqlParameter("VideoInspection", DBNull.Value);
            SqlParameter newCoRequiredParameter = new SqlParameter("CoRequired", newCoRequired);
            SqlParameter newPitRequiredParameter = new SqlParameter("PitRequired", newPitRequired);            
            SqlParameter newCoPitLocationParameter = (newCoPitLocation.Trim() != "") ? new SqlParameter("CoPitLocation", newCoPitLocation.Trim()) : new SqlParameter("CoPitLocation", DBNull.Value);
            SqlParameter newPostContractDigRequiredParameter = new SqlParameter("PostContractDigRequired", newPostContractDigRequired);
            SqlParameter newCommentsParameter = (newComments.Trim() != "") ? new SqlParameter("Comments", newComments.Trim()) : new SqlParameter("Comments", DBNull.Value);
            SqlParameter newHistoryParameter = (newHistory.Trim() != "") ? new SqlParameter("History", newHistory.Trim()) : new SqlParameter("History", DBNull.Value);
            SqlParameter newCoCutDownParameter = (newCoCutDown.HasValue) ? new SqlParameter("CoCutDown", newCoCutDown.ToString().Trim()) : new SqlParameter("CoCutDown", DBNull.Value);
            SqlParameter newFinalRestorationParameter = (newFinalRestoration.HasValue) ? new SqlParameter("FinalRestoration", newFinalRestoration.ToString().Trim()) : new SqlParameter("FinalRestoration", DBNull.Value);
            SqlParameter newClientLateralIDParameter = (newClientLateralID.Trim() != "") ? new SqlParameter("ClientLateralID", newClientLateralID.Trim()) : new SqlParameter("ClientLateralID", DBNull.Value);
            SqlParameter newVideoLengthToPropertyLineParameter = (newVideoLengthToPropertyLine.Trim() != "") ? new SqlParameter("VideoLengthToPropertyLine", newVideoLengthToPropertyLine.Trim()) : new SqlParameter("VideoLengthToPropertyLine", DBNull.Value);
            SqlParameter newLiningThruCoParameter = new SqlParameter("LiningThruCo", newLiningThruCo);
            SqlParameter newHamiltonInspectionNumberParameter = (newHamiltonInspectionNumber.Trim() != "") ? new SqlParameter("HamiltonInspectionNumber", newHamiltonInspectionNumber.Trim()) : new SqlParameter("HamiltonInspectionNumber", DBNull.Value);
            SqlParameter newNoticeDeliveredParameter = (newNoticeDelivered.HasValue) ? new SqlParameter("NoticeDelivered", newNoticeDelivered.ToString().Trim()) : new SqlParameter("NoticeDelivered", DBNull.Value);

            string command = "UPDATE [dbo].[LFS_JUNCTION_LINER2] SET " +
                "[DetailID] = @DetailID, [Address] = @Address, [PipeLocated] = @P" +
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
                "[Comments] = @Comments, [History] = @History, [CoCutDown] = @CoCutDown, [FinalRe" +
                "storation] = @FinalRestoration, [ClientLateralID] = @ClientLateralID, [VideoLeng" +
                "thToPropertyLine] = @VideoLengthToPropertyLine, [LiningThruCo] = @LiningThruCo, " +
                "[HamiltonInspectionNumber] = @HamiltonInspectionNumber, [NoticeDelivered] = @Not" +
                "iceDelivered "+
                " WHERE (([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalIdParameter, originalRefIdParameter, originalCompanyIdParameter, originalDetailIdParameter, originalAddressParameter, originalPipeLocatedParameter, originalServicesLocatedParameter, originalCoInstalledParameter, originalBackfilledConcreteParameter, originalBackfilledSoilParameter, originalGroutedParameter, originalCoredParameter, originalPreppedParameter, originalMeasuredParameter, originalLinerSizeParameter, originalInProcessParameter, originalInStockParameter, originalDeliveredParameter, originalBuildRebuildParameter, originalPreVideoParameter, originalLinerInstalledParameter, originalFinalVideoParameter, originalDistanceFromUSMHParameter, originalDistanceFromDSMHParameter, originalMapParameter, originalIssueParameter, originalCostParameter, originalDeletedParameter, originalVideoInspectionParameter, originalCoRequiredParameter, originalPitRequiredParameter, originalCoPitLocationParameter, originalPostContractDigRequiredParameter, originalCommentsParameter, originalHistoryParameter, originalCoCutDownParameter, originalFinalRestorationParameter, originalClientLateralIDParameter, originalVideoLengthToPropertyLineParameter, originalLiningThruCoParameter, originalHamiltonInspectionNumberParameter, originalNoticeDeliveredParameter, newIdParameter, newRefIdParameter, newCompanyIdParameter, newDetailIdParameter, newAddressParameter, newPipeLocatedParameter, newServicesLocatedParameter, newCoInstalledParameter, newBackfilledConcreteParameter, newBackfilledSoilParameter, newGroutedParameter, newCoredParameter, newPreppedParameter, newMeasuredParameter, newLinerSizeParameter, newInProcessParameter, newInStockParameter, newDeliveredParameter, newBuildRebuildParameter, newPreVideoParameter, newLinerInstalledParameter, newFinalVideoParameter, newDistanceFromUSMHParameter, newDistanceFromDSMHParameter, newMapParameter, newIssueParameter, newCostParameter, newDeletedParameter, newVideoInspectionParameter, newCoRequiredParameter, newPitRequiredParameter, newCoPitLocationParameter, newPostContractDigRequiredParameter, newCommentsParameter, newHistoryParameter, newCoCutDownParameter, newFinalRestorationParameter, newClientLateralIDParameter, newVideoLengthToPropertyLineParameter, newLiningThruCoParameter, newHamiltonInspectionNumberParameter, newNoticeDeliveredParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(Guid originalId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalIdParameter = new SqlParameter("@Original_ID", originalId);
            SqlParameter originalRefIdParameter = new SqlParameter("@Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);            
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_JUNCTION_LINER2] SET  [Deleted] = @Deleted  " +
                " WHERE (([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND " +
                "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            return rowsAffected;
        }



    }
}