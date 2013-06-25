using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkJunctionLiningLateralGateway
    /// </summary>
    public class WorkJunctionLiningLateralGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkJunctionLiningLateralGateway()
            : base("LFS_WORK_JUNCTIONLINING_LATERAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkJunctionLiningLateralGateway(DataSet data)
            : base(data, "LFS_WORK_JUNCTIONLINING_LATERAL")
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
            tableMapping.DataSetTable = "LFS_WORK_JUNCTIONLINING_LATERAL";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("SectionWorkID", "SectionWorkID");
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
            tableMapping.ColumnMappings.Add("Cost", "Cost");
            tableMapping.ColumnMappings.Add("VideoInspection", "VideoInspection");
            tableMapping.ColumnMappings.Add("CoRequired", "CoRequired");
            tableMapping.ColumnMappings.Add("PitRequired", "PitRequired");
            tableMapping.ColumnMappings.Add("CoPitLocation", "CoPitLocation");
            tableMapping.ColumnMappings.Add("PostContractDigRequired", "PostContractDigRequired");
            tableMapping.ColumnMappings.Add("CoCutDown", "CoCutDown");
            tableMapping.ColumnMappings.Add("FinalRestoration", "FinalRestoration");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("VideoLengthToPropertyLine", "VideoLengthToPropertyLine");
            tableMapping.ColumnMappings.Add("LiningThruCo", "LiningThruCo");
            tableMapping.ColumnMappings.Add("NoticeDelivered", "NoticeDelivered");
            tableMapping.ColumnMappings.Add("HamiltonInspectionNumber", "HamiltonInspectionNumber");
            tableMapping.ColumnMappings.Add("Flange", "Flange");
            tableMapping.ColumnMappings.Add("Gasket", "Gasket");
            tableMapping.ColumnMappings.Add("DepthOfLocated", "DepthOfLocated");
            tableMapping.ColumnMappings.Add("DigRequiredPriorToLining", "DigRequiredPriorToLining");
            tableMapping.ColumnMappings.Add("DigRequiredPriorToLiningCompleted", "DigRequiredPriorToLiningCompleted");
            tableMapping.ColumnMappings.Add("DigRequiredAfterLining", "DigRequiredAfterLining");
            tableMapping.ColumnMappings.Add("DigRequiredAfterLiningCompleted", "DigRequiredAfterLiningCompleted");
            tableMapping.ColumnMappings.Add("OutOfScope", "OutOfScope");
            tableMapping.ColumnMappings.Add("HoldClientIssue", "HoldClientIssue");
            tableMapping.ColumnMappings.Add("HoldClientIssueResolved", "HoldClientIssueResolved");
            tableMapping.ColumnMappings.Add("HoldLFSIssue", "HoldLFSIssue");
            tableMapping.ColumnMappings.Add("HoldLFSIssueResolved", "HoldLFSIssueResolved");
            tableMapping.ColumnMappings.Add("LateralRequiresRoboticPrep", "LateralRequiresRoboticPrep");
            tableMapping.ColumnMappings.Add("LateralRequiresRoboticPrepCompleted", "LateralRequiresRoboticPrepCompleted");
            tableMapping.ColumnMappings.Add("LinerType", "LinerType");
            tableMapping.ColumnMappings.Add("PrepType", "PrepType");
            tableMapping.ColumnMappings.Add("DyeTestReq", "DyeTestReq");
            tableMapping.ColumnMappings.Add("DyeTestComplete", "DyeTestComplete");
            tableMapping.ColumnMappings.Add("ContractYear", "ContractYear");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_WORK_JUNCTIONLINING_LATERAL] WHERE (([WorkID] = @Original_" +
                "WorkID) AND ([SectionWorkID] = @Original_SectionWorkID) AND ((@IsNull_PipeLocate" +
                "d = 1 AND [PipeLocated] IS NULL) OR ([PipeLocated] = @Original_PipeLocated)) AND" +
                " ((@IsNull_ServicesLocated = 1 AND [ServicesLocated] IS NULL) OR ([ServicesLocat" +
                "ed] = @Original_ServicesLocated)) AND ((@IsNull_CoInstalled = 1 AND [CoInstalled" +
                "] IS NULL) OR ([CoInstalled] = @Original_CoInstalled)) AND ((@IsNull_BackfilledC" +
                "oncrete = 1 AND [BackfilledConcrete] IS NULL) OR ([BackfilledConcrete] = @Origin" +
                "al_BackfilledConcrete)) AND ((@IsNull_BackfilledSoil = 1 AND [BackfilledSoil] IS" +
                " NULL) OR ([BackfilledSoil] = @Original_BackfilledSoil)) AND ((@IsNull_Grouted =" +
                " 1 AND [Grouted] IS NULL) OR ([Grouted] = @Original_Grouted)) AND ((@IsNull_Core" +
                "d = 1 AND [Cored] IS NULL) OR ([Cored] = @Original_Cored)) AND ((@IsNull_Prepped" +
                " = 1 AND [Prepped] IS NULL) OR ([Prepped] = @Original_Prepped)) AND ((@IsNull_Me" +
                "asured = 1 AND [Measured] IS NULL) OR ([Measured] = @Original_Measured)) AND ((@" +
                "IsNull_LinerSize = 1 AND [LinerSize] IS NULL) OR ([LinerSize] = @Original_LinerS" +
                "ize)) AND ((@IsNull_InProcess = 1 AND [InProcess] IS NULL) OR ([InProcess] = @Or" +
                "iginal_InProcess)) AND ((@IsNull_InStock = 1 AND [InStock] IS NULL) OR ([InStock" +
                "] = @Original_InStock)) AND ((@IsNull_Delivered = 1 AND [Delivered] IS NULL) OR " +
                "([Delivered] = @Original_Delivered)) AND ((@IsNull_BuildRebuild = 1 AND [BuildRe" +
                "build] IS NULL) OR ([BuildRebuild] = @Original_BuildRebuild)) AND ((@IsNull_PreV" +
                "ideo = 1 AND [PreVideo] IS NULL) OR ([PreVideo] = @Original_PreVideo)) AND ((@Is" +
                "Null_LinerInstalled = 1 AND [LinerInstalled] IS NULL) OR ([LinerInstalled] = @Or" +
                "iginal_LinerInstalled)) AND ((@IsNull_FinalVideo = 1 AND [FinalVideo] IS NULL) O" +
                "R ([FinalVideo] = @Original_FinalVideo)) AND ((@IsNull_Cost = 1 AND [Cost] IS NU" +
                "LL) OR ([Cost] = @Original_Cost)) AND ((@IsNull_VideoInspection = 1 AND [VideoIn" +
                "spection] IS NULL) OR ([VideoInspection] = @Original_VideoInspection)) AND ([CoR" +
                "equired] = @Original_CoRequired) AND ([PitRequired] = @Original_PitRequired) AND" +
                " ((@IsNull_CoPitLocation = 1 AND [CoPitLocation] IS NULL) OR ([CoPitLocation] = " +
                "@Original_CoPitLocation)) AND ([PostContractDigRequired] = @Original_PostContrac" +
                "tDigRequired) AND ((@IsNull_CoCutDown = 1 AND [CoCutDown] IS NULL) OR ([CoCutDow" +
                "n] = @Original_CoCutDown)) AND ((@IsNull_FinalRestoration = 1 AND [FinalRestorat" +
                "ion] IS NULL) OR ([FinalRestoration] = @Original_FinalRestoration)) AND ([Delete" +
                "d] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_" +
                "VideoLengthToPropertyLine = 1 AND [VideoLengthToPropertyLine] IS NULL) OR ([Vide" +
                "oLengthToPropertyLine] = @Original_VideoLengthToPropertyLine)) AND ([LiningThruC" +
                "o] = @Original_LiningThruCo) AND ((@IsNull_NoticeDelivered = 1 AND [NoticeDelive" +
                "red] IS NULL) OR ([NoticeDelivered] = @Original_NoticeDelivered)) AND ((@IsNull_" +
                "HamiltonInspectionNumber = 1 AND [HamiltonInspectionNumber] IS NULL) OR ([Hamilt" +
                "onInspectionNumber] = @Original_HamiltonInspectionNumber)) AND ((@IsNull_Flange " +
                "= 1 AND [Flange] IS NULL) OR ([Flange] = @Original_Flange)) AND ((@IsNull_Gasket" +
                " = 1 AND [Gasket] IS NULL) OR ([Gasket] = @Original_Gasket)) AND ((@IsNull_Depth" +
                "OfLocated = 1 AND [DepthOfLocated] IS NULL) OR ([DepthOfLocated] = @Original_Dep" +
                "thOfLocated)) AND ([DigRequiredPriorToLining] = @Original_DigRequiredPriorToLini" +
                "ng) AND ((@IsNull_DigRequiredPriorToLiningCompleted = 1 AND [DigRequiredPriorToL" +
                "iningCompleted] IS NULL) OR ([DigRequiredPriorToLiningCompleted] = @Original_Dig" +
                "RequiredPriorToLiningCompleted)) AND ([DigRequiredAfterLining] = @Original_DigRe" +
                "quiredAfterLining) AND ((@IsNull_DigRequiredAfterLiningCompleted = 1 AND [DigReq" +
                "uiredAfterLiningCompleted] IS NULL) OR ([DigRequiredAfterLiningCompleted] = @Ori" +
                "ginal_DigRequiredAfterLiningCompleted)) AND ([OutOfScope] = @Original_OutOfScope" +
                ") AND ([HoldClientIssue] = @Original_HoldClientIssue) AND ((@IsNull_HoldClientIs" +
                "sueResolved = 1 AND [HoldClientIssueResolved] IS NULL) OR ([HoldClientIssueResol" +
                "ved] = @Original_HoldClientIssueResolved)) AND ([HoldLFSIssue] = @Original_HoldL" +
                "FSIssue) AND ((@IsNull_HoldLFSIssueResolved = 1 AND [HoldLFSIssueResolved] IS NU" +
                "LL) OR ([HoldLFSIssueResolved] = @Original_HoldLFSIssueResolved)) AND ([LateralR" +
                "equiresRoboticPrep] = @Original_LateralRequiresRoboticPrep) AND ((@IsNull_Latera" +
                "lRequiresRoboticPrepCompleted = 1 AND [LateralRequiresRoboticPrepCompleted] IS N" +
                "ULL) OR ([LateralRequiresRoboticPrepCompleted] = @Original_LateralRequiresRoboti" +
                "cPrepCompleted)) AND ((@IsNull_LinerType = 1 AND [LinerType] IS NULL) OR ([Liner" +
                "Type] = @Original_LinerType)) AND ((@IsNull_PrepType = 1 AND [PrepType] IS NULL)" +
                " OR ([PrepType] = @Original_PrepType)) AND ([DyeTestReq] = @Original_DyeTestReq)" +
                " AND ((@IsNull_DyeTestComplete = 1 AND [DyeTestComplete] IS NULL) OR ([DyeTestCo" +
                "mplete] = @Original_DyeTestComplete)) AND ((@IsNull_ContractYear = 1 AND [Contra" +
                "ctYear] IS NULL) OR ([ContractYear] = @Original_ContractYear)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SectionWorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SectionWorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LinerSize", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerSize", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Cost", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Cost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VideoLengthToPropertyLine", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLengthToPropertyLine", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VideoLengthToPropertyLine", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLengthToPropertyLine", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LiningThruCo", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiningThruCo", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_NoticeDelivered", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoticeDelivered", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NoticeDelivered", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoticeDelivered", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_HamiltonInspectionNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HamiltonInspectionNumber", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HamiltonInspectionNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HamiltonInspectionNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Flange", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Flange", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Flange", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Flange", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Gasket", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Gasket", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Gasket", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Gasket", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DepthOfLocated", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DepthOfLocated", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DepthOfLocated", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DepthOfLocated", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DigRequiredPriorToLining", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredPriorToLining", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DigRequiredPriorToLiningCompleted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredPriorToLiningCompleted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DigRequiredPriorToLiningCompleted", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredPriorToLiningCompleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DigRequiredAfterLining", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredAfterLining", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DigRequiredAfterLiningCompleted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredAfterLiningCompleted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DigRequiredAfterLiningCompleted", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredAfterLiningCompleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OutOfScope", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OutOfScope", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoldClientIssue", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldClientIssue", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_HoldClientIssueResolved", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldClientIssueResolved", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoldClientIssueResolved", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldClientIssueResolved", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoldLFSIssue", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldLFSIssue", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_HoldLFSIssueResolved", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldLFSIssueResolved", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoldLFSIssueResolved", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldLFSIssueResolved", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LateralRequiresRoboticPrep", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LateralRequiresRoboticPrep", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LateralRequiresRoboticPrepCompleted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LateralRequiresRoboticPrepCompleted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LateralRequiresRoboticPrepCompleted", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LateralRequiresRoboticPrepCompleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LinerType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LinerType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PrepType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PrepType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PrepType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PrepType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DyeTestReq", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestReq", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DyeTestComplete", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestComplete", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DyeTestComplete", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestComplete", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ContractYear", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContractYear", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ContractYear", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContractYear", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[LFS_WORK_JUNCTIONLINING_LATERAL] ([WorkID], [SectionWorkID], [" +
                "PipeLocated], [ServicesLocated], [CoInstalled], [BackfilledConcrete], [Backfille" +
                "dSoil], [Grouted], [Cored], [Prepped], [Measured], [LinerSize], [InProcess], [In" +
                "Stock], [Delivered], [BuildRebuild], [PreVideo], [LinerInstalled], [FinalVideo]," +
                " [Cost], [VideoInspection], [CoRequired], [PitRequired], [CoPitLocation], [PostC" +
                "ontractDigRequired], [CoCutDown], [FinalRestoration], [Deleted], [COMPANY_ID], [" +
                "VideoLengthToPropertyLine], [LiningThruCo], [NoticeDelivered], [HamiltonInspecti" +
                "onNumber], [Flange], [Gasket], [DepthOfLocated], [DigRequiredPriorToLining], [Di" +
                "gRequiredPriorToLiningCompleted], [DigRequiredAfterLining], [DigRequiredAfterLin" +
                "ingCompleted], [OutOfScope], [HoldClientIssue], [HoldClientIssueResolved], [Hold" +
                "LFSIssue], [HoldLFSIssueResolved], [LateralRequiresRoboticPrep], [LateralRequire" +
                "sRoboticPrepCompleted], [LinerType], [PrepType], [DyeTestReq], [DyeTestComplete]" +
                ", [ContractYear]) VALUES (@WorkID, @SectionWorkID, @PipeLocated, @ServicesLocate" +
                "d, @CoInstalled, @BackfilledConcrete, @BackfilledSoil, @Grouted, @Cored, @Preppe" +
                "d, @Measured, @LinerSize, @InProcess, @InStock, @Delivered, @BuildRebuild, @PreV" +
                "ideo, @LinerInstalled, @FinalVideo, @Cost, @VideoInspection, @CoRequired, @PitRe" +
                "quired, @CoPitLocation, @PostContractDigRequired, @CoCutDown, @FinalRestoration," +
                " @Deleted, @COMPANY_ID, @VideoLengthToPropertyLine, @LiningThruCo, @NoticeDelive" +
                "red, @HamiltonInspectionNumber, @Flange, @Gasket, @DepthOfLocated, @DigRequiredP" +
                "riorToLining, @DigRequiredPriorToLiningCompleted, @DigRequiredAfterLining, @DigR" +
                "equiredAfterLiningCompleted, @OutOfScope, @HoldClientIssue, @HoldClientIssueReso" +
                "lved, @HoldLFSIssue, @HoldLFSIssueResolved, @LateralRequiresRoboticPrep, @Latera" +
                "lRequiresRoboticPrepCompleted, @LinerType, @PrepType, @DyeTestReq, @DyeTestCompl" +
                "ete, @ContractYear);\r\nSELECT WorkID, SectionWorkID, PipeLocated, ServicesLocated" +
                ", CoInstalled, BackfilledConcrete, BackfilledSoil, Grouted, Cored, Prepped, Meas" +
                "ured, LinerSize, InProcess, InStock, Delivered, BuildRebuild, PreVideo, LinerIns" +
                "talled, FinalVideo, Cost, VideoInspection, CoRequired, PitRequired, CoPitLocatio" +
                "n, PostContractDigRequired, CoCutDown, FinalRestoration, Deleted, COMPANY_ID, Vi" +
                "deoLengthToPropertyLine, LiningThruCo, NoticeDelivered, HamiltonInspectionNumber" +
                ", Flange, Gasket, DepthOfLocated, DigRequiredPriorToLining, DigRequiredPriorToLi" +
                "ningCompleted, DigRequiredAfterLining, DigRequiredAfterLiningCompleted, OutOfSco" +
                "pe, HoldClientIssue, HoldClientIssueResolved, HoldLFSIssue, HoldLFSIssueResolved" +
                ", LateralRequiresRoboticPrep, LateralRequiresRoboticPrepCompleted, LinerType, Pr" +
                "epType, DyeTestReq, DyeTestComplete, ContractYear FROM LFS_WORK_JUNCTIONLINING_L" +
                "ATERAL WHERE (WorkID = @WorkID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SectionWorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SectionWorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PipeLocated", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeLocated", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ServicesLocated", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServicesLocated", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoInstalled", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoInstalled", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BackfilledConcrete", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BackfilledConcrete", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BackfilledSoil", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BackfilledSoil", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Grouted", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Grouted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Cored", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cored", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Prepped", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Prepped", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Measured", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Measured", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerSize", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerSize", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InProcess", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InProcess", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InStock", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InStock", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Delivered", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Delivered", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BuildRebuild", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BuildRebuild", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PreVideo", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreVideo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerInstalled", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FinalVideo", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Cost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VideoInspection", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoInspection", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoRequired", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PitRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PitRequired", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoPitLocation", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoPitLocation", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PostContractDigRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PostContractDigRequired", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoCutDown", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoCutDown", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FinalRestoration", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalRestoration", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VideoLengthToPropertyLine", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLengthToPropertyLine", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LiningThruCo", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiningThruCo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NoticeDelivered", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoticeDelivered", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HamiltonInspectionNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HamiltonInspectionNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Flange", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Flange", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Gasket", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Gasket", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DepthOfLocated", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DepthOfLocated", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DigRequiredPriorToLining", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredPriorToLining", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DigRequiredPriorToLiningCompleted", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredPriorToLiningCompleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DigRequiredAfterLining", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredAfterLining", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DigRequiredAfterLiningCompleted", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredAfterLiningCompleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OutOfScope", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OutOfScope", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoldClientIssue", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldClientIssue", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoldClientIssueResolved", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldClientIssueResolved", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoldLFSIssue", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldLFSIssue", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoldLFSIssueResolved", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldLFSIssueResolved", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LateralRequiresRoboticPrep", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LateralRequiresRoboticPrep", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LateralRequiresRoboticPrepCompleted", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LateralRequiresRoboticPrepCompleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PrepType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PrepType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DyeTestReq", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestReq", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DyeTestComplete", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestComplete", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ContractYear", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContractYear", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_WORK_JUNCTIONLINING_LATERAL] SET [WorkID] = @WorkID, [SectionWo" +
                "rkID] = @SectionWorkID, [PipeLocated] = @PipeLocated, [ServicesLocated] = @Servi" +
                "cesLocated, [CoInstalled] = @CoInstalled, [BackfilledConcrete] = @BackfilledConc" +
                "rete, [BackfilledSoil] = @BackfilledSoil, [Grouted] = @Grouted, [Cored] = @Cored" +
                ", [Prepped] = @Prepped, [Measured] = @Measured, [LinerSize] = @LinerSize, [InPro" +
                "cess] = @InProcess, [InStock] = @InStock, [Delivered] = @Delivered, [BuildRebuil" +
                "d] = @BuildRebuild, [PreVideo] = @PreVideo, [LinerInstalled] = @LinerInstalled, " +
                "[FinalVideo] = @FinalVideo, [Cost] = @Cost, [VideoInspection] = @VideoInspection" +
                ", [CoRequired] = @CoRequired, [PitRequired] = @PitRequired, [CoPitLocation] = @C" +
                "oPitLocation, [PostContractDigRequired] = @PostContractDigRequired, [CoCutDown] " +
                "= @CoCutDown, [FinalRestoration] = @FinalRestoration, [Deleted] = @Deleted, [COM" +
                "PANY_ID] = @COMPANY_ID, [VideoLengthToPropertyLine] = @VideoLengthToPropertyLine" +
                ", [LiningThruCo] = @LiningThruCo, [NoticeDelivered] = @NoticeDelivered, [Hamilto" +
                "nInspectionNumber] = @HamiltonInspectionNumber, [Flange] = @Flange, [Gasket] = @" +
                "Gasket, [DepthOfLocated] = @DepthOfLocated, [DigRequiredPriorToLining] = @DigReq" +
                "uiredPriorToLining, [DigRequiredPriorToLiningCompleted] = @DigRequiredPriorToLin" +
                "ingCompleted, [DigRequiredAfterLining] = @DigRequiredAfterLining, [DigRequiredAf" +
                "terLiningCompleted] = @DigRequiredAfterLiningCompleted, [OutOfScope] = @OutOfSco" +
                "pe, [HoldClientIssue] = @HoldClientIssue, [HoldClientIssueResolved] = @HoldClien" +
                "tIssueResolved, [HoldLFSIssue] = @HoldLFSIssue, [HoldLFSIssueResolved] = @HoldLF" +
                "SIssueResolved, [LateralRequiresRoboticPrep] = @LateralRequiresRoboticPrep, [Lat" +
                "eralRequiresRoboticPrepCompleted] = @LateralRequiresRoboticPrepCompleted, [Liner" +
                "Type] = @LinerType, [PrepType] = @PrepType, [DyeTestReq] = @DyeTestReq, [DyeTest" +
                "Complete] = @DyeTestComplete, [ContractYear] = @ContractYear WHERE (([WorkID] = " +
                "@Original_WorkID) AND ([SectionWorkID] = @Original_SectionWorkID) AND ((@IsNull_" +
                "PipeLocated = 1 AND [PipeLocated] IS NULL) OR ([PipeLocated] = @Original_PipeLoc" +
                "ated)) AND ((@IsNull_ServicesLocated = 1 AND [ServicesLocated] IS NULL) OR ([Ser" +
                "vicesLocated] = @Original_ServicesLocated)) AND ((@IsNull_CoInstalled = 1 AND [C" +
                "oInstalled] IS NULL) OR ([CoInstalled] = @Original_CoInstalled)) AND ((@IsNull_B" +
                "ackfilledConcrete = 1 AND [BackfilledConcrete] IS NULL) OR ([BackfilledConcrete]" +
                " = @Original_BackfilledConcrete)) AND ((@IsNull_BackfilledSoil = 1 AND [Backfill" +
                "edSoil] IS NULL) OR ([BackfilledSoil] = @Original_BackfilledSoil)) AND ((@IsNull" +
                "_Grouted = 1 AND [Grouted] IS NULL) OR ([Grouted] = @Original_Grouted)) AND ((@I" +
                "sNull_Cored = 1 AND [Cored] IS NULL) OR ([Cored] = @Original_Cored)) AND ((@IsNu" +
                "ll_Prepped = 1 AND [Prepped] IS NULL) OR ([Prepped] = @Original_Prepped)) AND ((" +
                "@IsNull_Measured = 1 AND [Measured] IS NULL) OR ([Measured] = @Original_Measured" +
                ")) AND ((@IsNull_LinerSize = 1 AND [LinerSize] IS NULL) OR ([LinerSize] = @Origi" +
                "nal_LinerSize)) AND ((@IsNull_InProcess = 1 AND [InProcess] IS NULL) OR ([InProc" +
                "ess] = @Original_InProcess)) AND ((@IsNull_InStock = 1 AND [InStock] IS NULL) OR" +
                " ([InStock] = @Original_InStock)) AND ((@IsNull_Delivered = 1 AND [Delivered] IS" +
                " NULL) OR ([Delivered] = @Original_Delivered)) AND ((@IsNull_BuildRebuild = 1 AN" +
                "D [BuildRebuild] IS NULL) OR ([BuildRebuild] = @Original_BuildRebuild)) AND ((@I" +
                "sNull_PreVideo = 1 AND [PreVideo] IS NULL) OR ([PreVideo] = @Original_PreVideo))" +
                " AND ((@IsNull_LinerInstalled = 1 AND [LinerInstalled] IS NULL) OR ([LinerInstal" +
                "led] = @Original_LinerInstalled)) AND ((@IsNull_FinalVideo = 1 AND [FinalVideo] " +
                "IS NULL) OR ([FinalVideo] = @Original_FinalVideo)) AND ((@IsNull_Cost = 1 AND [C" +
                "ost] IS NULL) OR ([Cost] = @Original_Cost)) AND ((@IsNull_VideoInspection = 1 AN" +
                "D [VideoInspection] IS NULL) OR ([VideoInspection] = @Original_VideoInspection))" +
                " AND ([CoRequired] = @Original_CoRequired) AND ([PitRequired] = @Original_PitReq" +
                "uired) AND ((@IsNull_CoPitLocation = 1 AND [CoPitLocation] IS NULL) OR ([CoPitLo" +
                "cation] = @Original_CoPitLocation)) AND ([PostContractDigRequired] = @Original_P" +
                "ostContractDigRequired) AND ((@IsNull_CoCutDown = 1 AND [CoCutDown] IS NULL) OR " +
                "([CoCutDown] = @Original_CoCutDown)) AND ((@IsNull_FinalRestoration = 1 AND [Fin" +
                "alRestoration] IS NULL) OR ([FinalRestoration] = @Original_FinalRestoration)) AN" +
                "D ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND " +
                "((@IsNull_VideoLengthToPropertyLine = 1 AND [VideoLengthToPropertyLine] IS NULL)" +
                " OR ([VideoLengthToPropertyLine] = @Original_VideoLengthToPropertyLine)) AND ([L" +
                "iningThruCo] = @Original_LiningThruCo) AND ((@IsNull_NoticeDelivered = 1 AND [No" +
                "ticeDelivered] IS NULL) OR ([NoticeDelivered] = @Original_NoticeDelivered)) AND " +
                "((@IsNull_HamiltonInspectionNumber = 1 AND [HamiltonInspectionNumber] IS NULL) O" +
                "R ([HamiltonInspectionNumber] = @Original_HamiltonInspectionNumber)) AND ((@IsNu" +
                "ll_Flange = 1 AND [Flange] IS NULL) OR ([Flange] = @Original_Flange)) AND ((@IsN" +
                "ull_Gasket = 1 AND [Gasket] IS NULL) OR ([Gasket] = @Original_Gasket)) AND ((@Is" +
                "Null_DepthOfLocated = 1 AND [DepthOfLocated] IS NULL) OR ([DepthOfLocated] = @Or" +
                "iginal_DepthOfLocated)) AND ([DigRequiredPriorToLining] = @Original_DigRequiredP" +
                "riorToLining) AND ((@IsNull_DigRequiredPriorToLiningCompleted = 1 AND [DigRequir" +
                "edPriorToLiningCompleted] IS NULL) OR ([DigRequiredPriorToLiningCompleted] = @Or" +
                "iginal_DigRequiredPriorToLiningCompleted)) AND ([DigRequiredAfterLining] = @Orig" +
                "inal_DigRequiredAfterLining) AND ((@IsNull_DigRequiredAfterLiningCompleted = 1 A" +
                "ND [DigRequiredAfterLiningCompleted] IS NULL) OR ([DigRequiredAfterLiningComplet" +
                "ed] = @Original_DigRequiredAfterLiningCompleted)) AND ([OutOfScope] = @Original_" +
                "OutOfScope) AND ([HoldClientIssue] = @Original_HoldClientIssue) AND ((@IsNull_Ho" +
                "ldClientIssueResolved = 1 AND [HoldClientIssueResolved] IS NULL) OR ([HoldClient" +
                "IssueResolved] = @Original_HoldClientIssueResolved)) AND ([HoldLFSIssue] = @Orig" +
                "inal_HoldLFSIssue) AND ((@IsNull_HoldLFSIssueResolved = 1 AND [HoldLFSIssueResol" +
                "ved] IS NULL) OR ([HoldLFSIssueResolved] = @Original_HoldLFSIssueResolved)) AND " +
                "([LateralRequiresRoboticPrep] = @Original_LateralRequiresRoboticPrep) AND ((@IsN" +
                "ull_LateralRequiresRoboticPrepCompleted = 1 AND [LateralRequiresRoboticPrepCompl" +
                "eted] IS NULL) OR ([LateralRequiresRoboticPrepCompleted] = @Original_LateralRequ" +
                "iresRoboticPrepCompleted)) AND ((@IsNull_LinerType = 1 AND [LinerType] IS NULL) " +
                "OR ([LinerType] = @Original_LinerType)) AND ((@IsNull_PrepType = 1 AND [PrepType" +
                "] IS NULL) OR ([PrepType] = @Original_PrepType)) AND ([DyeTestReq] = @Original_D" +
                "yeTestReq) AND ((@IsNull_DyeTestComplete = 1 AND [DyeTestComplete] IS NULL) OR (" +
                "[DyeTestComplete] = @Original_DyeTestComplete)) AND ((@IsNull_ContractYear = 1 A" +
                "ND [ContractYear] IS NULL) OR ([ContractYear] = @Original_ContractYear)));\r\nSELE" +
                "CT WorkID, SectionWorkID, PipeLocated, ServicesLocated, CoInstalled, BackfilledC" +
                "oncrete, BackfilledSoil, Grouted, Cored, Prepped, Measured, LinerSize, InProcess" +
                ", InStock, Delivered, BuildRebuild, PreVideo, LinerInstalled, FinalVideo, Cost, " +
                "VideoInspection, CoRequired, PitRequired, CoPitLocation, PostContractDigRequired" +
                ", CoCutDown, FinalRestoration, Deleted, COMPANY_ID, VideoLengthToPropertyLine, L" +
                "iningThruCo, NoticeDelivered, HamiltonInspectionNumber, Flange, Gasket, DepthOfL" +
                "ocated, DigRequiredPriorToLining, DigRequiredPriorToLiningCompleted, DigRequired" +
                "AfterLining, DigRequiredAfterLiningCompleted, OutOfScope, HoldClientIssue, HoldC" +
                "lientIssueResolved, HoldLFSIssue, HoldLFSIssueResolved, LateralRequiresRoboticPr" +
                "ep, LateralRequiresRoboticPrepCompleted, LinerType, PrepType, DyeTestReq, DyeTes" +
                "tComplete, ContractYear FROM LFS_WORK_JUNCTIONLINING_LATERAL WHERE (WorkID = @Wo" +
                "rkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SectionWorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SectionWorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PipeLocated", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PipeLocated", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ServicesLocated", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServicesLocated", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoInstalled", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoInstalled", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BackfilledConcrete", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BackfilledConcrete", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BackfilledSoil", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BackfilledSoil", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Grouted", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Grouted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Cored", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cored", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Prepped", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Prepped", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Measured", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Measured", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerSize", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerSize", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InProcess", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InProcess", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InStock", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InStock", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Delivered", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Delivered", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BuildRebuild", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BuildRebuild", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PreVideo", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PreVideo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerInstalled", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerInstalled", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FinalVideo", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Cost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VideoInspection", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoInspection", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoRequired", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PitRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PitRequired", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoPitLocation", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoPitLocation", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PostContractDigRequired", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PostContractDigRequired", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CoCutDown", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CoCutDown", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FinalRestoration", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FinalRestoration", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VideoLengthToPropertyLine", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLengthToPropertyLine", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LiningThruCo", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiningThruCo", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NoticeDelivered", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoticeDelivered", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HamiltonInspectionNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HamiltonInspectionNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Flange", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Flange", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Gasket", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Gasket", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DepthOfLocated", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DepthOfLocated", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DigRequiredPriorToLining", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredPriorToLining", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DigRequiredPriorToLiningCompleted", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredPriorToLiningCompleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DigRequiredAfterLining", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredAfterLining", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DigRequiredAfterLiningCompleted", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredAfterLiningCompleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OutOfScope", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OutOfScope", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoldClientIssue", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldClientIssue", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoldClientIssueResolved", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldClientIssueResolved", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoldLFSIssue", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldLFSIssue", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@HoldLFSIssueResolved", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldLFSIssueResolved", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LateralRequiresRoboticPrep", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LateralRequiresRoboticPrep", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LateralRequiresRoboticPrepCompleted", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LateralRequiresRoboticPrepCompleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LinerType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PrepType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PrepType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DyeTestReq", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestReq", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DyeTestComplete", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestComplete", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ContractYear", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContractYear", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SectionWorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SectionWorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LinerSize", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerSize", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Cost", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Cost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VideoLengthToPropertyLine", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLengthToPropertyLine", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VideoLengthToPropertyLine", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VideoLengthToPropertyLine", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LiningThruCo", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiningThruCo", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_NoticeDelivered", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoticeDelivered", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NoticeDelivered", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoticeDelivered", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_HamiltonInspectionNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HamiltonInspectionNumber", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HamiltonInspectionNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HamiltonInspectionNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Flange", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Flange", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Flange", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Flange", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Gasket", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Gasket", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Gasket", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Gasket", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DepthOfLocated", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DepthOfLocated", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DepthOfLocated", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DepthOfLocated", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DigRequiredPriorToLining", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredPriorToLining", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DigRequiredPriorToLiningCompleted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredPriorToLiningCompleted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DigRequiredPriorToLiningCompleted", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredPriorToLiningCompleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DigRequiredAfterLining", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredAfterLining", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DigRequiredAfterLiningCompleted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredAfterLiningCompleted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DigRequiredAfterLiningCompleted", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DigRequiredAfterLiningCompleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OutOfScope", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OutOfScope", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoldClientIssue", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldClientIssue", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_HoldClientIssueResolved", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldClientIssueResolved", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoldClientIssueResolved", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldClientIssueResolved", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoldLFSIssue", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldLFSIssue", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_HoldLFSIssueResolved", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldLFSIssueResolved", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_HoldLFSIssueResolved", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "HoldLFSIssueResolved", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LateralRequiresRoboticPrep", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LateralRequiresRoboticPrep", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LateralRequiresRoboticPrepCompleted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LateralRequiresRoboticPrepCompleted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LateralRequiresRoboticPrepCompleted", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LateralRequiresRoboticPrepCompleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LinerType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LinerType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LinerType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PrepType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PrepType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PrepType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PrepType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DyeTestReq", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestReq", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DyeTestComplete", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestComplete", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DyeTestComplete", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DyeTestComplete", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ContractYear", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContractYear", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ContractYear", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContractYear", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

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
            FillDataWithStoredProcedure("LFS_CWP_WORKJUNCTIONLININGLATERALGATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadBySectionWorkId
        /// </summary>
        /// <param name="sectionWorkId">sectionWorkId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadBySectionWorkId(int sectionWorkId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKJUNCTIONLININGLATERALGATEWAY_LOADBYSECTIONWORKID", new SqlParameter("@sectionWorkId", sectionWorkId.ToString()), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single work
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int workId)
        {
            string filter = string.Format("(WorkID = {0})", workId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Works.JunctionLiningLateralGateway.GetRow");
            }
        }



        /// <summary>
        /// GetSectionWorkID. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>SectionWorkID</returns>
        public int GetSectionWorkID(int workId)
        {
            return (int)GetRow(workId)["SectionWorkID"];            
        }



        /// <summary>
        /// GetPipeLocated. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PipeLocated or null</returns>
        public DateTime? GetPipeLocated(int workId)
        {
            if (GetRow(workId).IsNull("PipeLocated"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PipeLocated"];
            }
        }



        /// <summary>
        /// GetServicesLocated. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ServicesLocated or null</returns>
        public DateTime? GetServicesLocated(int workId)
        {
            if (GetRow(workId).IsNull("ServicesLocated"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["ServicesLocated"];
            }
        }



        /// <summary>
        /// GetCoInstalled. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CoInstalled or null</returns>
        public DateTime? GetCoInstalled(int workId)
        {
            if (GetRow(workId).IsNull("CoInstalled"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["CoInstalled"];
            }
        }



        /// <summary>
        /// GetBackfilledConcrete. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>BackfilledConcrete or null</returns>
        public DateTime? GetBackfilledConcrete(int workId)
        {
            if (GetRow(workId).IsNull("BackfilledConcrete"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["BackfilledConcrete"];
            }
        }



        /// <summary>
        /// GetBackfilledSoil. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>BackfilledSoil or null</returns>
        public DateTime? GetBackfilledSoil(int workId)
        {
            if (GetRow(workId).IsNull("BackfilledSoil"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["BackfilledSoil"];
            }
        }



        /// <summary>
        /// GetGrouted. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Grouted or null</returns>
        public DateTime? GetGrouted(int workId)
        {
            if (GetRow(workId).IsNull("Grouted"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Grouted"];
            }
        }



        /// <summary>
        /// GetCored. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Cored or null</returns>
        public DateTime? GetCored(int workId)
        {
            if (GetRow(workId).IsNull("Cored"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Cored"];
            }
        }



        /// <summary>
        /// GetPrepped. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Prepped or null</returns>
        public DateTime? GetPrepped(int workId)
        {
            if (GetRow(workId).IsNull("Prepped"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Prepped"];
            }
        }



        /// <summary>
        /// GetMeasured. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Measured or null</returns>
        public DateTime? GetMeasured(int workId)
        {
            if (GetRow(workId).IsNull("Measured"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Measured"];
            }
        }



        /// <summary>
        /// GetLinerSize. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LinerSize or EMPTY</returns>
        public string GetLinerSize(int workId)
        {
            if (GetRow(workId).IsNull("LinerSize"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["LinerSize"];
            }
        }



        /// <summary>
        /// GetInProcess. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>InProcess or null</returns>
        public DateTime? GetInProcess(int workId)
        {
            if (GetRow(workId).IsNull("InProcess"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["InProcess"];
            }
        }



        /// <summary>
        /// GetInStock. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>InStock or null</returns>
        public DateTime? GetInStock(int workId)
        {
            if (GetRow(workId).IsNull("InStock"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["InStock"];
            }
        }



        /// <summary>
        /// GetDelivered. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Delivered or null</returns>
        public DateTime? GetDelivered(int workId)
        {
            if (GetRow(workId).IsNull("Delivered"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Delivered"];
            }
        }



        /// <summary>
        /// GetBuildRebuild. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>BuildRebuild or null</returns>
        public int? GetBuildRebuild(int workId)
        {
            if (GetRow(workId).IsNull("BuildRebuild"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["BuildRebuild"];
            }
        }



        /// <summary>
        /// GetPreVideo. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PreVideo or EMPTY</returns>
        public DateTime? GetPreVideo(int workId)
        {
            if (GetRow(workId).IsNull("PreVideo"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PreVideo"];
            }
        }



        /// <summary>
        /// GetLinerInstalled. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LinerInstalled or null</returns>
        public DateTime? GetLinerInstalled(int workId)
        {
            if (GetRow(workId).IsNull("LinerInstalled"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["LinerInstalled"];
            }
        }



        /// <summary>
        /// GetFinalVideo. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>FinalVideo or null</returns>
        public DateTime? GetFinalVideo(int workId)
        {
            if (GetRow(workId).IsNull("FinalVideo"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["FinalVideo"];
            }
        }        



        /// <summary>
        /// GetCost
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Cost or null</returns>
        public decimal? GetCost(int workId)
        {
            if (GetRow(workId).IsNull("Cost"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(workId)["Cost"];
            }
        }



        /// <summary>
        /// GetVideoInspection. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>VideoInspection or null</returns>
        public DateTime? GetVideoInspection(int workId)
        {
            if (GetRow(workId).IsNull("VideoInspection"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["VideoInspection"];
            }
        }



        /// <summary>
        /// GetCoRequiered
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CoRequired</returns>
        public bool GetCoRequired(int workId)
        {
            return (bool)GetRow(workId)["CoRequired"];
        }



        /// <summary>
        /// GetPitRequiered
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PitRequired</returns>
        public bool GetPitRequired(int workId)
        {
            return (bool)GetRow(workId)["PitRequired"];
        }



        /// <summary>
        /// GetCoPitLocation
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CoPitLocation</returns>
        public string GetCoPitLocation(int workId)
        {
            if (GetRow(workId).IsNull("CoPitLocation"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["CoPitLocation"];
            }
        }



        /// <summary>
        /// GetPostContractDigRequiered
        /// </summary>
        /// <param name="workId"></param>
        /// <returns>PostContractDigRequired</returns>
        public bool GetPostContractDigRequired(int workId)
        {
            return (bool)GetRow(workId)["PostContractDigRequired"];
        }



        /// <summary>
        /// GetCoCutDown
        /// </summary>
        /// <param name="workId"></param>
        /// <returns>CoCutDown or null</returns>
        public DateTime? GetCoCutDown(int workId)
        {
            if (GetRow(workId).IsNull("CoCutDown"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["CoCutDown"];
            }
        }



        /// <summary>
        /// GetFinalRestoration
        /// </summary>
        /// <param name="workId"></param>
        /// <returns>FinalRestoration or null</returns>
        public DateTime? GetFinalRestoration(int workId)
        {
            if (GetRow(workId).IsNull("FinalRestoration"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["FinalRestoration"];
            }
        }



        /// <summary>
        /// GetDeleted. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TRUE if project deleted</returns>
        public bool GetDeleted(int workId)
        {
            return (bool)GetRow(workId)["Deleted"];
        }



        /// <summary>
        /// GetCompanyID. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CpmpanyId - CompaniesId</returns>
        public int GetCompanyID(int workId)
        {
            return (int)GetRow(workId)["COMPANY_ID"];
        }



        /// <summary>
        /// GetLiningThruCo. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TRUE or FALSE</returns>
        public bool GetLiningThruCo(int workId)
        {
            return (bool)GetRow(workId)["LiningThruCo"];
        }



        /// <summary>
        /// GetVideoLengthToPropertyLine
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>VideoLengthToPropertyLine or EMPTY</returns>
        public string GetVideoLengthToPropertyLine(int workId)
        {
            if (GetRow(workId).IsNull("VideoLengthToPropertyLine"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoLengthToPropertyLine"];
            }
        }



        /// <summary>
        /// GetNoticeDelivered. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NoticeDelivered or EMPTY</returns>
        public DateTime? GetNoticeDelivered(int workId)
        {
            if (GetRow(workId).IsNull("NoticeDelivered"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["NoticeDelivered"];
            }
        }



        /// <summary>
        /// GetHamiltonInspectionNumber
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HamiltonInspectionNumber or EMPTY</returns>
        public string GetHamiltonInspectionNumber(int workId)
        {
            if (GetRow(workId).IsNull("HamiltonInspectionNumber"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["HamiltonInspectionNumber"];
            }
        }



        /// <summary>
        /// GetFlange. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Flange or EMPTY</returns>
        public string GetFlange(int workId)
        {
            if (GetRow(workId).IsNull("Flange"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Flange"];
            }
        }



        /// <summary>
        /// GetGasket. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Gasket or EMPTY</returns>
        public string GetGasket(int workId)
        {
            if (GetRow(workId).IsNull("Gasket"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Gasket"];
            }
        }



        /// <summary>
        /// GetDepthOfLocated. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DepthOfLocated or EMPTY</returns>
        public string GetDepthOfLocated(int workId)
        {
            if (GetRow(workId).IsNull("DepthOfLocated"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DepthOfLocated"];
            }
        }



        /// <summary>
        /// GetDigRequiredPriorToLining. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TRUE or FALSE</returns>
        public bool GetDigRequiredPriorToLining(int workId)
        {
            return (bool)GetRow(workId)["DigRequiredPriorToLining"];
        }



        /// <summary>
        /// GetDigRequiredAfterLining. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TRUE or FALSE</returns>
        public bool GetDigRequiredAfterLining(int workId)
        {
            return (bool)GetRow(workId)["DigRequiredAfterLining"];
        }



        /// <summary>
        /// GetOutOfScope. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TRUE or FALSE</returns>
        public bool GetOutOfScope(int workId)
        {
            return (bool)GetRow(workId)["OutOfScope"];
        }



        /// <summary>
        /// GetHoldClientIssue. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TRUE or FALSE</returns>
        public bool GetHoldClientIssue(int workId)
        {
            return (bool)GetRow(workId)["HoldClientIssue"];
        }



        /// <summary>
        /// GetHoldLFSIssue. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TRUE or FALSE</returns>
        public bool GetHoldLFSIssue(int workId)
        {
            return (bool)GetRow(workId)["HoldLFSIssue"];
        }



        /// <summary>
        /// GetLateralRequiresRoboticPrep. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TRUE or FALSE</returns>
        public bool GetLateralRequiresRoboticPrep(int workId)
        {
            return (bool)GetRow(workId)["LateralRequiresRoboticPrep"];
        }



        /// <summary>
        /// GetDigRequiredPriorToLiningCompleted. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DigRequiredPriorToLiningCompleted or EMPTY</returns>
        public DateTime? GetDigRequiredPriorToLiningCompleted(int workId)
        {
            if (GetRow(workId).IsNull("DigRequiredPriorToLiningCompleted"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["DigRequiredPriorToLiningCompleted"];
            }
        }



        /// <summary>
        /// GetDigRequiredAfterLiningCompleted. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DigRequiredAfterLiningCompleted or EMPTY</returns>
        public DateTime? GetDigRequiredAfterLiningCompleted(int workId)
        {
            if (GetRow(workId).IsNull("DigRequiredAfterLiningCompleted"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["DigRequiredAfterLiningCompleted"];
            }
        }



        /// <summary>
        /// GetHoldClientIssueResolved. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HoldClientIssueResolved or EMPTY</returns>
        public DateTime? GetHoldClientIssueResolved(int workId)
        {
            if (GetRow(workId).IsNull("HoldClientIssueResolved"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["HoldClientIssueResolved"];
            }
        }



        /// <summary>
        /// GetHoldLFSIssueResolved. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HoldLFSIssueResolved or EMPTY</returns>
        public DateTime? GetHoldLFSIssueResolved(int workId)
        {
            if (GetRow(workId).IsNull("HoldLFSIssueResolved"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["HoldLFSIssueResolved"];
            }
        }



        /// <summary>
        /// GetLateralRequiresRoboticPrepCompleted. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LateralRequiresRoboticPrepCompleted or EMPTY</returns>
        public DateTime? GetLateralRequiresRoboticPrepCompleted(int workId)
        {
            if (GetRow(workId).IsNull("LateralRequiresRoboticPrepCompleted"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["LateralRequiresRoboticPrepCompleted"];
            }
        }



        /// <summary>
        /// GetLinerType. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LinerType or EMPTY</returns>
        public string GetLinerType(int workId)
        {
            if (GetRow(workId).IsNull("LinerType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["LinerType"];
            }
        }



        /// <summary>
        /// GetPrepType. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PrepType or EMPTY</returns>
        public string GetPrepType(int workId)
        {
            if (GetRow(workId).IsNull("PrepType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["PrepType"];
            }
        }



        /// <summary>
        /// GetDyeTestReq
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DyeTestReq</returns>
        public bool GetDyeTestReq(int workId)
        {
            return (bool)GetRow(workId)["DyeTestReq"];
        }



        /// <summary>
        /// GetDyeTestComplete
        /// </summary>
        /// <param name="workId"></param>
        /// <returns>DyeTestComplete or null</returns>
        public DateTime? GetDyeTestComplete(int workId)
        {
            if (GetRow(workId).IsNull("DyeTestComplete"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["DyeTestComplete"];
            }
        }



        /// <summary>
        /// GetContractYear. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PrepType or EMPTY</returns>
        public string GetContractYear(int workId)
        {
            if (GetRow(workId).IsNull("ContractYear"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ContractYear"];
            }
        }




        
                
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="sectionWorkId">sectionWorkId</param>
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
        /// <param name="builRebuild">builRebuild</param>
        /// <param name="preVideo">preVideo</param>
        /// <param name="linerInstalled">linerInstalled</param>
        /// <param name="finalVideo">finalVideo</param>
        /// <param name="cost">cost</param>
        /// <param name="videoInspection">videoInspection</param>
        /// <param name="coRequired">coRequired</param>
        /// <param name="pitRequired">pitRequired</param>
        /// <param name="coPitLocation">coPitLocation</param>
        /// <param name="postContractDigRequired">postContractDigRequired</param>
        /// <param name="coCutDown">coCutDown</param>
        /// <param name="finalRestoration">finalRestoration</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="videoLengthToPropertyLine">videoLengthToPropertyLine</param>
        /// <param name="liningThruCo">liningThruCo</param>
        /// <param name="noticeDelivered">noticeDelivered</param>
        /// <param name="hamiltonInspectionNumber">hamiltonInspectionNumber</param>
        /// <param name="flange">flange</param>
        /// <param name="gasket">gasket</param>
        /// <param name="depthOfLocated">depthOfLocated</param>
        /// <param name="digRequiredPriorToLining">digRequiredPriorToLining</param>
        /// <param name="digRequiredPriorToLiningCompleted">digRequiredPriorToLiningCompleted</param>
        /// <param name="digRequiredAfterLining">digRequiredAfterLining</param>
        /// <param name="digRequiredAfterLiningCompleted">digRequiredAfterLiningCompleted</param>
        /// <param name="outOfScope">outOfScope</param>
        /// <param name="holdClientIssue">holdClientIssue</param>
        /// <param name="holdClientIssueResolved">holdClientIssueResolved</param>
        /// <param name="holdLFSIssue">holdLFSIssue</param>
        /// <param name="holdLFSIssueResolved">holdLFSIssueResolved</param>
        /// <param name="requiresRoboticPrep">requiresRoboticPrep</param>
        /// <param name="requiresRoboticPrepCompleted">requiresRoboticPrepCompleted</param>
        /// <param name="linerType">linerType</param>
        /// <param name="prepType">prepType</param>
        /// <param name="dyeTestReq">dyeTestReq</param>
        /// <param name="dyeTestComplete">dyeTestComplete</param>
        /// <returns>int</returns>
        public int Insert(int workId, int sectionWorkId, DateTime? pipeLocated, DateTime? servicesLocated, DateTime? coInstalled, DateTime? backfilledConcrete, DateTime? backfilledSoil, DateTime? grouted, DateTime? cored, DateTime? prepped, DateTime? measured, string linerSize, DateTime? inProcess, DateTime? inStock, DateTime? delivered, int? builRebuild, DateTime? preVideo, DateTime? linerInstalled, DateTime? finalVideo, decimal? cost, DateTime? videoInspection, bool coRequired, bool pitRequired, string coPitLocation, bool postContractDigRequired, DateTime? coCutDown, DateTime? finalRestoration, bool deleted, int companyId, string videoLengthToPropertyLine, bool liningThruCo, DateTime? noticeDelivered, string hamiltonInspectionNumber, string flange, string gasket, string depthOfLocated, bool digRequiredPriorToLining, DateTime? digRequiredPriorToLiningCompleted, bool digRequiredAfterLining, DateTime? digRequiredAfterLiningCompleted, bool outOfScope, bool holdClientIssue, DateTime? holdClientIssueResolved, bool holdLFSIssue, DateTime? holdLFSIssueResolved, bool requiresRoboticPrep, DateTime? requiresRoboticPrepCompleted, string linerType, string prepType, bool dyeTestReq, DateTime? dyeTestComplete, string contractYear)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter sectionWorkIdParameter = new SqlParameter("SectionWorkID", sectionWorkId);
            SqlParameter pipeLocatedParameter = (pipeLocated.HasValue) ? new SqlParameter("PipeLocated", pipeLocated) : new SqlParameter("PipeLocated", DBNull.Value);
            SqlParameter servicesLocatedParameter = (servicesLocated.HasValue) ? new SqlParameter("ServicesLocated", servicesLocated) : new SqlParameter("ServicesLocated", DBNull.Value);
            SqlParameter coInstalledParameter = (coInstalled.HasValue) ? new SqlParameter("CoInstalled", coInstalled) : new SqlParameter("CoInstalled", DBNull.Value);
            SqlParameter backfilledConcreteParameter = (backfilledConcrete.HasValue) ? new SqlParameter("BackfilledConcrete", backfilledConcrete) : new SqlParameter("BackfilledConcrete", DBNull.Value);
            SqlParameter backfilledSoilParameter = (backfilledSoil.HasValue) ? new SqlParameter("BackfilledSoil", backfilledSoil) : new SqlParameter("BackfilledSoil", DBNull.Value);
            SqlParameter groutedParameter = (grouted.HasValue) ? new SqlParameter("Grouted", grouted) : new SqlParameter("Grouted", DBNull.Value);
            SqlParameter coredParameter = (cored.HasValue) ? new SqlParameter("Cored", cored) : new SqlParameter("Cored", DBNull.Value);
            SqlParameter preppedParameter = (prepped.HasValue) ? new SqlParameter("Prepped", prepped) : new SqlParameter("Prepped", DBNull.Value);
            SqlParameter measuredParameter = (measured.HasValue) ? new SqlParameter("Measured", measured) : new SqlParameter("Measured", DBNull.Value);
            SqlParameter linerSizeParameter = (linerSize.Trim() != "") ? new SqlParameter("LinerSize", linerSize.Trim()) : new SqlParameter("LinerSize", DBNull.Value);
            SqlParameter inProcessParameter = (inProcess.HasValue) ? new SqlParameter("InProcess", inProcess) : new SqlParameter("InProcess", DBNull.Value);
            SqlParameter inStockParameter = (inStock.HasValue) ? new SqlParameter("InStock", inStock) : new SqlParameter("InStock", DBNull.Value);
            SqlParameter deliveredParameter = (delivered.HasValue) ? new SqlParameter("Delivered", delivered) : new SqlParameter("Delivered", DBNull.Value);
            SqlParameter buildRebuildParameter = (builRebuild.HasValue) ? new SqlParameter("BuildRebuild", builRebuild) : new SqlParameter("BuildRebuild", DBNull.Value);
            SqlParameter preVideoParameter = (preVideo.HasValue) ? new SqlParameter("PreVideo", preVideo) : new SqlParameter("PreVideo", DBNull.Value);
            SqlParameter linerInstalledParameter = (linerInstalled.HasValue) ? new SqlParameter("LinerInstalled", linerInstalled) : new SqlParameter("LinerInstalled", DBNull.Value);
            SqlParameter finalVideoParameter = (finalVideo.HasValue) ? new SqlParameter("FinalVideo", finalVideo) : new SqlParameter("FinalVideo", DBNull.Value);
            SqlParameter costParameter = (cost.HasValue) ? new SqlParameter("Cost", cost) : new SqlParameter("Cost", DBNull.Value);
            costParameter.SqlDbType = SqlDbType.Money;
            SqlParameter videoInspectionParameter = (videoInspection.HasValue) ? new SqlParameter("VideoInspection", videoInspection) : new SqlParameter("VideoInspection", DBNull.Value);
            SqlParameter coRequiredParameter = new SqlParameter("CoRequired", coRequired);
            SqlParameter pitRequiredParameter = new SqlParameter("PitRequired", pitRequired);
            SqlParameter coPitLocationParameter = (coPitLocation.Trim() != "") ? new SqlParameter("CoPitLocation", coPitLocation.Trim()) : new SqlParameter("CoPitLocation", DBNull.Value);
            SqlParameter postContractDigRequiredParameter = new SqlParameter("PostContractDigRequired", postContractDigRequired);
            SqlParameter coCutDownParameter = (coCutDown.HasValue) ? new SqlParameter("CoCutDown", coCutDown) : new SqlParameter("CoCutDown", DBNull.Value);
            SqlParameter finalRestorationParameter = (finalRestoration.HasValue) ? new SqlParameter("FinalRestoration", finalRestoration) : new SqlParameter("FinalRestoration", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter videoLengthToPropertyLineParameter = (videoLengthToPropertyLine.Trim() != "") ? new SqlParameter("VideoLengthToPropertyLine", videoLengthToPropertyLine) : new SqlParameter("VideoLengthToPropertyLine", DBNull.Value);
            SqlParameter liningThruCoParameter = new SqlParameter("LiningThruCo", liningThruCo);
            SqlParameter noticeDeliveredParameter = (noticeDelivered.HasValue) ? new SqlParameter("NoticeDelivered", noticeDelivered) : new SqlParameter("NoticeDelivered", DBNull.Value);
            SqlParameter hamiltonInspectionNumberParameter = (hamiltonInspectionNumber.Trim() != "") ? new SqlParameter("HamiltonInspectionNumber", hamiltonInspectionNumber.Trim()) : new SqlParameter("HamiltonInspectionNumber", DBNull.Value);
            SqlParameter flangeParameter = (flange.Trim() != "") ? new SqlParameter("Flange", flange.Trim()) : new SqlParameter("Flange", DBNull.Value);
            SqlParameter gasketParameter = (gasket.Trim() != "") ? new SqlParameter("Gasket", gasket.Trim()) : new SqlParameter("Gasket", DBNull.Value);
            SqlParameter depthOfLocatedParameter = (depthOfLocated.Trim() != "") ? new SqlParameter("DepthOfLocated", depthOfLocated.Trim()) : new SqlParameter("DepthOfLocated", DBNull.Value);
            SqlParameter digRequiredPriorToLiningParameter = new SqlParameter("DigRequiredPriorToLining", digRequiredPriorToLining);
            SqlParameter digRequiredPriorToLiningCompletedParameter = (digRequiredPriorToLiningCompleted.HasValue) ? new SqlParameter("DigRequiredPriorToLiningCompleted", digRequiredPriorToLiningCompleted) : new SqlParameter("DigRequiredPriorToLiningCompleted", DBNull.Value);
            SqlParameter digRequiredAfterLiningParameter = new SqlParameter("DigRequiredAfterLining", digRequiredAfterLining);
            SqlParameter digRequiredAfterLiningCompletedParameter = (digRequiredAfterLiningCompleted.HasValue) ? new SqlParameter("DigRequiredAfterLiningCompleted", digRequiredAfterLiningCompleted) : new SqlParameter("DigRequiredAfterLiningCompleted", DBNull.Value);
            SqlParameter outOfScopeParameter = new SqlParameter("OutOfScope", outOfScope);
            SqlParameter holdClientIssueParameter = new SqlParameter("HoldClientIssue", holdClientIssue);
            SqlParameter holdClientIssueResolvedParameter = (holdClientIssueResolved.HasValue) ? new SqlParameter("HoldClientIssueResolved", holdClientIssueResolved) : new SqlParameter("HoldClientIssueResolved", DBNull.Value);
            SqlParameter holdLFSIssueParameter = new SqlParameter("HoldLFSIssue", holdLFSIssue);
            SqlParameter holdLFSIssueResolvedParameter = (holdLFSIssueResolved.HasValue) ? new SqlParameter("HoldLFSIssueResolved", holdLFSIssueResolved) : new SqlParameter("HoldLFSIssueResolved", DBNull.Value);
            SqlParameter requiresRoboticPrepParameter = new SqlParameter("LateralRequiresRoboticPrep", requiresRoboticPrep);            
            SqlParameter requiresRoboticPrepCompletedParameter = (requiresRoboticPrepCompleted.HasValue) ? new SqlParameter("LateralRequiresRoboticPrepCompleted", requiresRoboticPrepCompleted) : new SqlParameter("LateralRequiresRoboticPrepCompleted", DBNull.Value);
            SqlParameter linerTypeParameter = (linerType.Trim() != "") ? new SqlParameter("LinerType", linerType.Trim()) : new SqlParameter("LinerType", DBNull.Value);
            SqlParameter prepTypeParameter = (prepType.Trim() != "") ? new SqlParameter("PrepType", prepType.Trim()) : new SqlParameter("PrepType", DBNull.Value);
            SqlParameter dyeTestReqParameter = new SqlParameter("DyeTestReq", dyeTestReq);
            SqlParameter dyeTestCompleteParameter = (dyeTestComplete.HasValue) ? new SqlParameter("DyeTestComplete", dyeTestComplete) : new SqlParameter("DyeTestComplete", DBNull.Value);
            SqlParameter contractYearParameter = (contractYear.Trim() != "") ? new SqlParameter("ContractYear", contractYear.Trim()) : new SqlParameter("ContractYear", DBNull.Value);

            string command = "INSERT INTO [dbo].[LFS_WORK_JUNCTIONLINING_LATERAL] ([WorkID], [SectionWorkID], [" +
                "PipeLocated], [ServicesLocated], [CoInstalled], [BackfilledConcrete], [Backfille" +
                "dSoil], [Grouted], [Cored], [Prepped], [Measured], [LinerSize], [InProcess], [In" +
                "Stock], [Delivered], [BuildRebuild], [PreVideo], [LinerInstalled], [FinalVideo]," +
                "  [Cost], [VideoInspection], [CoRequired], [PitRequired], [CoPitLocation" +
                "], [PostContractDigRequired], [CoCutDown], [FinalRestoration], [Deleted], [COMPA" +
                "NY_ID], [VideoLengthToPropertyLine], [LiningThruCo], [NoticeDelivered], [Hamilto" +
                "nInspectionNumber], [Flange], [Gasket], [DepthOfLocated], [DigRequiredPriorToLin" +
                "ing], [DigRequiredPriorToLiningCompleted], [DigRequiredAfterLining], [DigRequire" +
                "dAfterLiningCompleted], [OutOfScope], [HoldClientIssue], [HoldClientIssueResolve" +
                "d], [HoldLFSIssue], [HoldLFSIssueResolved], [LateralRequiresRoboticPrep], [Later" +
                "alRequiresRoboticPrepCompleted], [LinerType], [PrepType], [DyeTestReq], [DyeTestComple" +
                "te], [ContractYear] ) VALUES (@WorkID, @SectionWorkID, @PipeLocated, " +
                "@ServicesLocated, @CoInstalled, @BackfilledConcrete, @BackfilledSoil, @Grouted, " +
                "@Cored, @Prepped, @Measured, @LinerSize, @InProcess, @InStock, @Delivered, @Buil" +
                "dRebuild, @PreVideo, @LinerInstalled, @FinalVideo,  @Cost, @VideoInspecti" +
                "on, @CoRequired, @PitRequired, @CoPitLocation, @PostContractDigRequired, @CoCutD" +
                "own, @FinalRestoration, @Deleted, @COMPANY_ID, @VideoLengthToPropertyLine, @Lini" +
                "ngThruCo, @NoticeDelivered, @HamiltonInspectionNumber, @Flange, @Gasket, @DepthO" +
                "fLocated, @DigRequiredPriorToLining, @DigRequiredPriorToLiningCompleted, @DigReq" +
                "uiredAfterLining, @DigRequiredAfterLiningCompleted, @OutOfScope, @HoldClientIssu" +
                "e, @HoldClientIssueResolved, @HoldLFSIssue, @HoldLFSIssueResolved, @LateralRequi" +
                "resRoboticPrep, @LateralRequiresRoboticPrepCompleted, @LinerType, @PrepType, @DyeTestReq, @DyeTestComplete, @ContractYear)";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, sectionWorkIdParameter, pipeLocatedParameter, servicesLocatedParameter, coInstalledParameter, backfilledConcreteParameter, backfilledSoilParameter, groutedParameter, coredParameter, preppedParameter, measuredParameter, linerSizeParameter, inProcessParameter, inStockParameter, deliveredParameter, buildRebuildParameter, preVideoParameter, linerInstalledParameter, finalVideoParameter, costParameter, videoInspectionParameter, coRequiredParameter, pitRequiredParameter, coPitLocationParameter, postContractDigRequiredParameter, coCutDownParameter, finalRestorationParameter, deletedParameter, companyIdParameter, videoLengthToPropertyLineParameter, liningThruCoParameter, noticeDeliveredParameter, hamiltonInspectionNumberParameter, flangeParameter, gasketParameter, depthOfLocatedParameter, digRequiredPriorToLiningParameter, digRequiredPriorToLiningCompletedParameter, digRequiredAfterLiningParameter, digRequiredAfterLiningCompletedParameter, outOfScopeParameter, holdClientIssueParameter, holdClientIssueResolvedParameter, holdLFSIssueParameter, holdLFSIssueResolvedParameter, requiresRoboticPrepParameter, requiresRoboticPrepCompletedParameter, linerTypeParameter, prepTypeParameter, dyeTestReqParameter, dyeTestCompleteParameter, contractYearParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update a work (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="sectionWorkId">sectionWorkId</param>
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
        /// <param name="originalCost">originalCost</param>
        /// <param name="originalVideoInspection">originalVideoInspection</param>
        /// <param name="originalCoRequired">originalCoRequired</param>
        /// <param name="originalPitRequired">originalPitRequired</param>
        /// <param name="originalCoPitLocation">originalCoPitLocation</param>
        /// <param name="originalPostContractDigRequired">originalPostContractDigRequired</param>
        /// <param name="originalCoCutDown">originalCoCutDown</param>
        /// <param name="originalFinalRestoration">originalFinalRestoration</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalVideoLengthToPropertyLine">originalVideoLengthToPropertyLine</param>
        /// <param name="originalLiningThruCo">originalLiningThruCo</param>
        /// <param name="originalNoticeDelivered">originalNoticeDelivered</param>
        /// <param name="originalHamiltonInspectionNumber">originalHamiltonInspectionNumber</param>
        /// <param name="originalFlange">originalFlange</param>
        /// <param name="originalGasket">originalGasket</param>
        /// <param name="originalDepthOfLocated">originalDepthOfLocated</param>        
        /// <param name="originalDigRequiredPriorToLining">originalDigRequiredPriorToLining</param>
        /// <param name="originalDigRequiredPriorToLiningCompleted">originalDigRequiredPriorToLiningCompleted</param>
        /// <param name="originalDigRequiredAfterLining">originalDigRequiredAfterLining</param>
        /// <param name="originalDigRequiredAfterLiningCompleted">originalDigRequiredAfterLiningCompleted</param>
        /// <param name="originalOutOfScope">originalOutOfScope</param>
        /// <param name="originalHoldClientIssue">originalHoldClientIssue</param>
        /// <param name="originalHoldClientIssueResolved">originalHoldClientIssueResolved</param>
        /// <param name="originalHoldLFSIssue">originalHoldLFSIssue</param>
        /// <param name="originalHoldLFSIssueResolved">originalHoldLFSIssueResolved</param>
        /// <param name="originalRequiresRoboticPrep">originalRequiresRoboticPrep</param>
        /// <param name="originalRequiresRoboticPrepCompleted">originalRequiresRoboticPrepCompleted</param>
        /// <param name="originalLinerType">originalLinerType</param>
        /// <param name="originalPrepType">originalPrepType</param>
        /// <param name="originalDyeTestReq">originalDyeTestReq</param>
        /// <param name="originalDyeTestComplete">originalDyeTestComplete</param>
        /// 
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
        /// <param name="newCost">newCost</param>
        /// <param name="newVideoInspection">newVideoInspection</param>
        /// <param name="newCoRequired">newCoRequired</param>
        /// <param name="newPitRequired">newPitRequired</param>
        /// <param name="newCoPitLocation">newCoPitLocation</param>
        /// <param name="newPostContractDigRequired">newPostContractDigRequired</param>
        /// <param name="newCoCutDown">newCoCutDown</param>
        /// <param name="newFinalRestoration">newFinalRestoration</param>
        /// <param name="newVideoLengthToPropertyLine">newVideoLengthToPropertyLine</param>
        /// <param name="newLiningThruCo">newLiningThruCo</param>
        /// <param name="newNoticeDelivered">newNoticeDelivered</param>
        /// <param name="newHamiltonInspectionNumber">newHamiltonInspectionNumber</param>
        /// <param name="newFlange">newFlange</param>
        /// <param name="newGasket">newGasket</param>
        /// <param name="newDepthOfLocated">newDepthOfLocated</param>
        /// <param name="newDigRequiredPriorToLining">newDigRequiredPriorToLining</param>
        /// <param name="newDigRequiredPriorToLiningCompleted">newDigRequiredPriorToLiningCompleted</param>
        /// <param name="newDigRequiredAfterLining">newDigRequiredAfterLining</param>
        /// <param name="newDigRequiredAfterLiningCompleted">newDigRequiredAfterLiningCompleted</param>        
        /// <param name="newOutOfScope">newOutOfScope</param>
        /// <param name="newHoldClientIssue">newHoldClientIssue</param>
        /// <param name="newHoldClientIssueResolved">newHoldClientIssueResolved</param>
        /// <param name="newHoldLFSIssue">newHoldLFSIssue</param>
        /// <param name="newHoldLFSIssueResolved">newHoldLFSIssueResolved</param>
        /// <param name="newRequiresRoboticPrep">newRequiresRoboticPrep</param>
        /// <param name="newRequiresRoboticPrepCompleted">newRequiresRoboticPrepCompleted</param>
        /// <param name="newLinerType">newLinerType</param>
        /// <param name="newPrepType">newPrepType</param>
        /// <param name="newDyeTestReq">newDyeTestReq</param>
        /// <param name="newDyeTestComplete">newDyeTestComplete</param>
        /// <returns>int</returns>
        public int Update(int workId, int sectionWorkId, DateTime? originalPipeLocated, DateTime? originalServicesLocated, DateTime? originalCoInstalled, DateTime? originalBackfilledConcrete, DateTime? originalBackfilledSoil, DateTime? originalGrouted, DateTime? originalCored, DateTime? originalPrepped, DateTime? originalMeasured, string originalLinerSize, DateTime? originalInProcess, DateTime? originalInStock, DateTime? originalDelivered, int? originalBuildRebuild, DateTime? originalPreVideo, DateTime? originalLinerInstalled, DateTime? originalFinalVideo, decimal? originalCost, DateTime? originalVideoInspection, bool originalCoRequired, bool originalPitRequired, string originalCoPitLocation, bool originalPostContractDigRequired, DateTime? originalCoCutDown, DateTime? originalFinalRestoration, bool originalDeleted, int originalCompanyId, string originalVideoLengthToPropertyLine, bool originalLiningThruCo, DateTime? originalNoticeDelivered, string originalHamiltonInspectionNumber, string originalFlange, string originalGasket, string originalDepthOfLocated, bool originalDigRequiredPriorToLining, DateTime? originalDigRequiredPriorToLiningCompleted, bool originalDigRequiredAfterLining, DateTime? originalDigRequiredAfterLiningCompleted, bool originalOutOfScope, bool originalHoldClientIssue, DateTime? originalHoldClientIssueResolved, bool originalHoldLFSIssue, DateTime? originalHoldLFSIssueResolved, bool originalRequiresRoboticPrep, DateTime? originalRequiresRoboticPrepCompleted, string originalLinerType, string originalPrepType, bool originalDyeTestReq, DateTime? originalDyeTestComplete, DateTime? newPipeLocated, DateTime? newServicesLocated, DateTime? newCoInstalled, DateTime? newBackfilledConcrete, DateTime? newBackfilledSoil, DateTime? newGrouted, DateTime? newCored, DateTime? newPrepped, DateTime? newMeasured, string newLinerSize, DateTime? newInProcess, DateTime? newInStock, DateTime? newDelivered, int? newBuildRebuild, DateTime? newPreVideo, DateTime? newLinerInstalled, DateTime? newFinalVideo, decimal? newCost, DateTime? newVideoInspection, bool newCoRequired, bool newPitRequired, string newCoPitLocation, bool newPostContractDigRequired, DateTime? newCoCutDown, DateTime? newFinalRestoration, string newVideoLengthToPropertyLine, bool newLiningThruCo, DateTime? newNoticeDelivered, string newHamiltonInspectionNumber, string newFlange, string newGasket, string newDepthOfLocated, bool newDigRequiredPriorToLining, DateTime? newDigRequiredPriorToLiningCompleted, bool newDigRequiredAfterLining, DateTime? newDigRequiredAfterLiningCompleted, bool newOutOfScope, bool newHoldClientIssue, DateTime? newHoldClientIssueResolved, bool newHoldLFSIssue, DateTime? newHoldLFSIssueResolved, bool newRequiresRoboticPrep, DateTime? newRequiresRoboticPrepCompleted, string newLinerType, string newPrepType, bool newDyeTestReq, DateTime? newDyeTestComplete, string originalContractYear, string newContractYear)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", workId);
            SqlParameter originalSectionWorkIdParameter = new SqlParameter("Original_SectionWorkID", sectionWorkId);
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
            SqlParameter originalCostParameter = (originalCost.HasValue) ? new SqlParameter("Original_Cost", originalCost) : new SqlParameter("Original_Cost", DBNull.Value);
            originalCostParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalVideoInspectionParameter = (originalVideoInspection.HasValue) ? new SqlParameter("Original_VideoInspection", originalVideoInspection) : new SqlParameter("Original_VideoInspection", DBNull.Value);
            SqlParameter originalCoRequiredParameter = new SqlParameter("Original_CoRequired", originalCoRequired);
            SqlParameter originalPitRequiredParameter = new SqlParameter("Original_PitRequired", originalPitRequired);
            SqlParameter originalCoPitLocationParameter = (originalCoPitLocation.Trim() != "") ? new SqlParameter("Original_CoPitLocation", originalCoPitLocation.Trim()) : new SqlParameter("Original_CoPitLocation", DBNull.Value);
            SqlParameter originalPostContractDigRequiredParameter = new SqlParameter("Original_PostContractDigRequired", originalPostContractDigRequired);
            SqlParameter originalCoCutDownParameter = (originalCoCutDown.HasValue) ? new SqlParameter("Original_CoCutDown", originalCoCutDown) : new SqlParameter("Original_CoCutDown", DBNull.Value);
            SqlParameter originalFinalRestorationParameter = (originalFinalRestoration.HasValue) ? new SqlParameter("Original_FinalRestoration", originalFinalRestoration) : new SqlParameter("Original_FinalRestoration", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalVideoLengthToPropertyLineParameter = (originalVideoLengthToPropertyLine.Trim() != "") ? new SqlParameter("Original_VideoLengthToPropertyLine", originalVideoLengthToPropertyLine) : new SqlParameter("Original_VideoLengthToPropertyLine", DBNull.Value);
            SqlParameter originalLiningThruCoParameter = new SqlParameter("Original_LiningThruCo", originalLiningThruCo);
            SqlParameter originalNoticeDeliveredParameter = (originalNoticeDelivered.HasValue) ? new SqlParameter("Original_NoticeDelivered", originalNoticeDelivered) : new SqlParameter("Original_NoticeDelivered", DBNull.Value);
            SqlParameter originalHamiltonInspectionNumberParameter = (originalHamiltonInspectionNumber.Trim() != "") ? new SqlParameter("Original_HamiltonInspectionNumber", originalHamiltonInspectionNumber) : new SqlParameter("Original_HamiltonInspectionNumber", DBNull.Value);
            SqlParameter originalFlangeParameter = (originalFlange.Trim() != "") ? new SqlParameter("Original_Flange", originalFlange) : new SqlParameter("Original_Flange", DBNull.Value);
            SqlParameter originalGasketParameter = (originalGasket.Trim() != "") ? new SqlParameter("Original_Gasket", originalGasket) : new SqlParameter("Original_Gasket", DBNull.Value);
            SqlParameter originalDepthOfLocatedParameter = (originalDepthOfLocated.Trim() != "") ? new SqlParameter("Original_DepthOfLocated", originalDepthOfLocated) : new SqlParameter("Original_DepthOfLocated", DBNull.Value);
            SqlParameter originalDigRequiredPriorToLiningParameter = new SqlParameter("Original_DigRequiredPriorToLining", originalDigRequiredPriorToLining);
            SqlParameter originalDigRequiredPriorToLiningCompletedParameter = (originalDigRequiredPriorToLiningCompleted.HasValue) ? new SqlParameter("Original_DigRequiredPriorToLiningCompleted", originalDigRequiredPriorToLiningCompleted) : new SqlParameter("Original_DigRequiredPriorToLiningCompleted", DBNull.Value);
            SqlParameter originalDigRequiredAfterLiningParameter = new SqlParameter("Original_DigRequiredAfterLining", originalDigRequiredAfterLining);
            SqlParameter originalDigRequiredAfterLiningCompletedParameter = (originalDigRequiredAfterLiningCompleted.HasValue) ? new SqlParameter("Original_DigRequiredAfterLiningCompleted", originalDigRequiredAfterLiningCompleted) : new SqlParameter("Original_DigRequiredAfterLiningCompleted", DBNull.Value);
            SqlParameter originalOutOfScopeParameter = new SqlParameter("Original_OutOfScope", originalOutOfScope);
            SqlParameter originalHoldClientIssueParameter = new SqlParameter("Original_HoldClientIssue", originalHoldClientIssue);
            SqlParameter originalHoldClientIssueResolvedParameter = (originalHoldClientIssueResolved.HasValue) ? new SqlParameter("Original_HoldClientIssueResolved", originalHoldClientIssueResolved) : new SqlParameter("Original_HoldClientIssueResolved", DBNull.Value);
            SqlParameter originalHoldLFSIssueParameter = new SqlParameter("Original_HoldLFSIssue", originalHoldLFSIssue);
            SqlParameter originalHoldLFSIssueResolvedParameter = (originalHoldLFSIssueResolved.HasValue) ? new SqlParameter("Original_HoldLFSIssueResolved", originalHoldLFSIssueResolved) : new SqlParameter("Original_HoldLFSIssueResolved", DBNull.Value);
            SqlParameter originalRequiresRoboticPrepParameter = new SqlParameter("Original_LateralRequiresRoboticPrep", originalRequiresRoboticPrep);
            SqlParameter originalRequiresRoboticPrepCompletedParameter = (originalRequiresRoboticPrepCompleted.HasValue) ? new SqlParameter("Original_LateralRequiresRoboticPrepCompleted", originalRequiresRoboticPrepCompleted) : new SqlParameter("Original_LateralRequiresRoboticPrepCompleted", DBNull.Value);
            SqlParameter originalLinerTypeParameter = (originalLinerType.Trim() != "") ? new SqlParameter("Original_LinerType", originalLinerType.Trim()) : new SqlParameter("Original_LinerType", DBNull.Value);
            SqlParameter originalPrepTypeParameter = (originalPrepType.Trim() != "") ? new SqlParameter("Original_PrepType", originalPrepType.Trim()) : new SqlParameter("Original_PrepType", DBNull.Value);
            SqlParameter originalDyeTestReqParameter = new SqlParameter("Original_DyeTestReq", originalDyeTestReq);
            SqlParameter originalDyeTestCompleteParameter = (originalDyeTestComplete.HasValue) ? new SqlParameter("Original_DyeTestComplete", originalDyeTestComplete) : new SqlParameter("Original_DyeTestComplete", DBNull.Value);
            SqlParameter originalContractYearParameter = (originalContractYear.Trim() != "") ? new SqlParameter("Original_ContractYear", originalContractYear.Trim()) : new SqlParameter("Original_ContractYear", DBNull.Value);
                        
            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter newSectionWorkIdParameter = new SqlParameter("SectionWorkID", sectionWorkId);
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
            SqlParameter newDeliveredParameter = (newDelivered.HasValue) ? new SqlParameter("Delivered", newDelivered) : new SqlParameter("Delivered", DBNull.Value);
            SqlParameter newBuildRebuildParameter = (newBuildRebuild.HasValue) ? new SqlParameter("BuildRebuild", newBuildRebuild) : new SqlParameter("BuildRebuild", DBNull.Value);
            SqlParameter newPreVideoParameter = (newPreVideo.HasValue) ? new SqlParameter("PreVideo", newPreVideo) : new SqlParameter("PreVideo", DBNull.Value);
            SqlParameter newLinerInstalledParameter = (newLinerInstalled.HasValue) ? new SqlParameter("LinerInstalled", newLinerInstalled) : new SqlParameter("LinerInstalled", DBNull.Value);
            SqlParameter newFinalVideoParameter = (newFinalVideo.HasValue) ? new SqlParameter("FinalVideo", newFinalVideo) : new SqlParameter("FinalVideo", DBNull.Value);
            SqlParameter newCostParameter = (newCost.HasValue) ? new SqlParameter("Cost", newCost) : new SqlParameter("Cost", DBNull.Value);
            newCostParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newVideoInspectionParameter = (newVideoInspection.HasValue) ? new SqlParameter("VideoInspection", newVideoInspection) : new SqlParameter("VideoInspection", DBNull.Value);
            SqlParameter newCoRequiredParameter = new SqlParameter("CoRequired", newCoRequired);
            SqlParameter newPitRequiredParameter = new SqlParameter("PitRequired", newPitRequired);
            SqlParameter newCoPitLocationParameter = (newCoPitLocation.Trim() != "") ? new SqlParameter("CoPitLocation", newCoPitLocation.Trim()) : new SqlParameter("CoPitLocation", DBNull.Value);
            SqlParameter newPostContractDigRequiredParameter = new SqlParameter("PostContractDigRequired", newPostContractDigRequired);
            SqlParameter newCoCutDownParameter = (newCoCutDown.HasValue) ? new SqlParameter("CoCutDown", newCoCutDown) : new SqlParameter("CoCutDown", DBNull.Value);
            SqlParameter newFinalRestorationParameter = (newFinalRestoration.HasValue) ? new SqlParameter("FinalRestoration", newFinalRestoration) : new SqlParameter("FinalRestoration", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", originalDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", originalCompanyId);
            SqlParameter newVideoLengthToPropertyLineParameter = (newVideoLengthToPropertyLine.Trim() != "") ? new SqlParameter("VideoLengthToPropertyLine", newVideoLengthToPropertyLine) : new SqlParameter("VideoLengthToPropertyLine", DBNull.Value);
            SqlParameter newLiningThruCoParameter = new SqlParameter("LiningThruCo", newLiningThruCo);
            SqlParameter newNoticeDeliveredParameter = (newNoticeDelivered.HasValue) ? new SqlParameter("NoticeDelivered", newNoticeDelivered) : new SqlParameter("NoticeDelivered", DBNull.Value);
            SqlParameter newHamiltonInspectionNumberParameter = (newHamiltonInspectionNumber.Trim() != "") ? new SqlParameter("HamiltonInspectionNumber", newHamiltonInspectionNumber) : new SqlParameter("HamiltonInspectionNumber", DBNull.Value);
            SqlParameter newFlangeParameter = (newFlange.Trim() != "") ? new SqlParameter("Flange", newFlange) : new SqlParameter("Flange", DBNull.Value);
            SqlParameter newGasketParameter = (newGasket.Trim() != "") ? new SqlParameter("Gasket", newGasket) : new SqlParameter("Gasket", DBNull.Value);
            SqlParameter newDepthOfLocatedParameter = (newDepthOfLocated.Trim() != "") ? new SqlParameter("DepthOfLocated", newDepthOfLocated) : new SqlParameter("DepthOfLocated", DBNull.Value);
            SqlParameter newDigRequiredPriorToLiningParameter = new SqlParameter("DigRequiredPriorToLining", newDigRequiredPriorToLining);
            SqlParameter newDigRequiredPriorToLiningCompletedParameter = (newDigRequiredPriorToLiningCompleted.HasValue) ? new SqlParameter("DigRequiredPriorToLiningCompleted", newDigRequiredPriorToLiningCompleted) : new SqlParameter("DigRequiredPriorToLiningCompleted", DBNull.Value);
            SqlParameter newDigRequiredAfterLiningParameter = new SqlParameter("DigRequiredAfterLining", newDigRequiredAfterLining);
            SqlParameter newDigRequiredAfterLiningCompletedParameter = (newDigRequiredAfterLiningCompleted.HasValue) ? new SqlParameter("DigRequiredAfterLiningCompleted", newDigRequiredAfterLiningCompleted) : new SqlParameter("DigRequiredAfterLiningCompleted", DBNull.Value);
            SqlParameter newOutOfScopeParameter = new SqlParameter("OutOfScope", newOutOfScope);
            SqlParameter newHoldClientIssueParameter = new SqlParameter("HoldClientIssue", newHoldClientIssue);
            SqlParameter newHoldClientIssueResolvedParameter = (newHoldClientIssueResolved.HasValue) ? new SqlParameter("HoldClientIssueResolved", newHoldClientIssueResolved) : new SqlParameter("HoldClientIssueResolved", DBNull.Value);
            SqlParameter newHoldLFSIssueParameter = new SqlParameter("HoldLFSIssue", newHoldLFSIssue);
            SqlParameter newHoldLFSIssueResolvedParameter = (newHoldLFSIssueResolved.HasValue) ? new SqlParameter("HoldLFSIssueResolved", newHoldLFSIssueResolved) : new SqlParameter("HoldLFSIssueResolved", DBNull.Value);
            SqlParameter newRequiresRoboticPrepParameter = new SqlParameter("LateralRequiresRoboticPrep", newRequiresRoboticPrep);
            SqlParameter newRequiresRoboticPrepCompletedParameter = (newRequiresRoboticPrepCompleted.HasValue) ? new SqlParameter("LateralRequiresRoboticPrepCompleted", newRequiresRoboticPrepCompleted) : new SqlParameter("LateralRequiresRoboticPrepCompleted", DBNull.Value);
            SqlParameter newLinerTypeParameter = (newLinerType.Trim() != "") ? new SqlParameter("LinerType", newLinerType.Trim()) : new SqlParameter("LinerType", DBNull.Value);
            SqlParameter newPrepTypeParameter = (newPrepType.Trim() != "") ? new SqlParameter("PrepType", newPrepType.Trim()) : new SqlParameter("PrepType", DBNull.Value);
            SqlParameter newDyeTestReqParameter = new SqlParameter("DyeTestReq", newDyeTestReq);
            SqlParameter newDyeTestCompleteParameter = (newDyeTestComplete.HasValue) ? new SqlParameter("DyeTestComplete", newDyeTestComplete) : new SqlParameter("DyeTestComplete", DBNull.Value);
            SqlParameter newContractYearParameter = (newContractYear.Trim() != "") ? new SqlParameter("ContractYear", newContractYear.Trim()) : new SqlParameter("ContractYear", DBNull.Value);
            
            string command = "UPDATE [dbo].[LFS_WORK_JUNCTIONLINING_LATERAL] " +
                             "SET [SectionWorkID] = @SectionWorkID, [PipeLocated] = @PipeLocated, [ServicesLocated] = @ServicesLocated, [CoInstalled] = @CoInstalled, " +
                             " [BackfilledConcrete] = @BackfilledConcrete, [BackfilledSoil] = @BackfilledSoil, [Grouted] = @Grouted, [Cored] = @Cored, [Prepped] = @Prepped, " +
                             " [Measured] = @Measured, [LinerSize] = @LinerSize,  [InProcess] = @InProcess, [InStock] = @InStock, [Delivered] = @Delivered, " +
                             " [BuildRebuild] = @BuildRebuild, [PreVideo] = @PreVideo, [LinerInstalled] = @LinerInstalled, [FinalVideo] = @FinalVideo, " +
                             " [Cost] = @Cost, [VideoInspection] = @VideoInspection, [CoRequired] = @CoRequired, [PitRequired] = @PitRequired, " +
                             " [CoPitLocation] = @CoPitLocation, [PostContractDigRequired] = @PostContractDigREquired, [CoCutDown] = @CoCutDown, " +
                             " [FinalRestoration] = @FinalRestoration, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [VideoLengthToPropertyLine] = @VideoLengthToPropertyLine, " +
                             " [LiningThruCo] = @LiningThruCo, [NoticeDelivered] = @NoticeDelivered, [HamiltonInspectionNumber] = @HamiltonInspectionNumber, " +
                             " [Flange] = @Flange, [Gasket] = @Gasket, [DepthOfLocated] = @DepthOfLocated , [DigRequiredPriorToLining] = @DigRequiredPriorToLining, "+
                             " [DigRequiredPriorToLiningCompleted] = @DigRequiredPriorToLiningCompleted, [DigRequiredAfterLining] = @DigRequiredAfterLining, "+
                             " [DigRequiredAfterLiningCompleted] = @DigRequiredAfterLiningCompleted, [OutOfScope] = @OutOfScope, [HoldClientIssue] = @HoldClientIssue, "+
                             " [HoldClientIssueResolved] = @HoldClientIssueResolved, [HoldLFSIssue] = @HoldLFSIssue, [HoldLFSIssueResolved] = @HoldLFSIssueResolved, "+
                             " [LateralRequiresRoboticPrep] = @LateralRequiresRoboticPrep, [LateralRequiresRoboticPrepCompleted] = @LateralRequiresRoboticPrepCompleted, "+
                             " [LinerType] = @LinerType, [PrepType] = @PrepType, [DyeTestReq] = @DyeTestReq, [DyeTestComplete] = @DyeTestComplete, [ContractYear] = @ContractYear " +
                             " "+
                             " WHERE (([WorkID] = @Original_WorkID) AND " +
                             " ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, newWorkIdParameter, newSectionWorkIdParameter, newPipeLocatedParameter, newServicesLocatedParameter, newCoInstalledParameter, newBackfilledConcreteParameter, newBackfilledSoilParameter, newGroutedParameter, newCoredParameter, newPreppedParameter, newMeasuredParameter, newLinerSizeParameter, newInProcessParameter, newInStockParameter, newDeliveredParameter, newBuildRebuildParameter, newPreVideoParameter, newLinerInstalledParameter, newFinalVideoParameter, newCostParameter, newVideoInspectionParameter, newCoRequiredParameter, newPitRequiredParameter, newCoPitLocationParameter, newPostContractDigRequiredParameter, newCoCutDownParameter, newFinalRestorationParameter, newDeletedParameter, newCompanyIdParameter, newVideoLengthToPropertyLineParameter, newLiningThruCoParameter, newNoticeDeliveredParameter, newHamiltonInspectionNumberParameter, newFlangeParameter, newGasketParameter, newDepthOfLocatedParameter, newDigRequiredPriorToLiningParameter, newDigRequiredPriorToLiningCompletedParameter, newDigRequiredAfterLiningParameter, newDigRequiredAfterLiningCompletedParameter, newOutOfScopeParameter, newHoldClientIssueParameter, newHoldClientIssueResolvedParameter, newHoldLFSIssueParameter, newHoldLFSIssueResolvedParameter, newRequiresRoboticPrepParameter, newRequiresRoboticPrepCompletedParameter, newLinerTypeParameter, newPrepTypeParameter, newDyeTestReqParameter, newDyeTestCompleteParameter, originalWorkIdParameter, originalSectionWorkIdParameter, originalPipeLocatedParameter, originalServicesLocatedParameter, originalCoInstalledParameter, originalBackfilledConcreteParameter, originalBackfilledSoilParameter, originalGroutedParameter, originalCoredParameter, originalPreppedParameter, originalMeasuredParameter, originalLinerSizeParameter, originalInProcessParameter, originalInStockParameter, originalDeliveredParameter, originalBuildRebuildParameter, originalPreVideoParameter, originalLinerInstalledParameter, originalFinalVideoParameter, originalCostParameter, originalVideoInspectionParameter, originalCoRequiredParameter, originalPitRequiredParameter, originalCoPitLocationParameter, originalPostContractDigRequiredParameter, originalCoCutDownParameter, originalFinalRestorationParameter, originalDeletedParameter, originalCompanyIdParameter, originalVideoLengthToPropertyLineParameter, originalLiningThruCoParameter, originalNoticeDeliveredParameter, originalHamiltonInspectionNumberParameter, originalFlangeParameter, originalGasketParameter, originalDepthOfLocatedParameter, originalDigRequiredPriorToLiningParameter, originalDigRequiredPriorToLiningCompletedParameter, originalDigRequiredAfterLiningParameter, originalDigRequiredAfterLiningCompletedParameter, originalOutOfScopeParameter, originalHoldClientIssueParameter, originalHoldClientIssueResolvedParameter, originalHoldLFSIssueParameter, originalHoldLFSIssueResolvedParameter, originalRequiresRoboticPrepParameter, originalRequiresRoboticPrepCompletedParameter, originalLinerTypeParameter, originalPrepTypeParameter, originalDyeTestReqParameter, originalDyeTestCompleteParameter, originalContractYearParameter, newContractYearParameter);
                        
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }
        


        /// <summary>
        /// Delete a work (direct to DB)
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalWorkId, int originalCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("@Original_WorkID", originalWorkId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_JUNCTIONLINING_LATERAL] SET  [Deleted] = @Deleted  " +
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