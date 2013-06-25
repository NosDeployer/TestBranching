using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.WebUI.export.Temp;

namespace LiquiForce.LFSLive.WebUI
{
    /// <summary>
    /// Fix1Section
    /// </summary>
    public class Fix1SectionGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Fix1SectionGateway()
            : base("LFS_MASTER_AREA")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Fix1SectionGateway(DataSet data)
            : base(data, "LFS_MASTER_AREA")
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
            tableMapping.DataSetTable = "LFS_MASTER_AREA";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("RecordID", "RecordID");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("ScaledLength", "ScaledLength");
            tableMapping.ColumnMappings.Add("P1Date", "P1Date");
            tableMapping.ColumnMappings.Add("ActualLength", "ActualLength");
            tableMapping.ColumnMappings.Add("LiveLats", "LiveLats");
            tableMapping.ColumnMappings.Add("CXIsRemoved", "CXIsRemoved");
            tableMapping.ColumnMappings.Add("M1Date", "M1Date");
            tableMapping.ColumnMappings.Add("M2Date", "M2Date");
            tableMapping.ColumnMappings.Add("InstallDate", "InstallDate");
            tableMapping.ColumnMappings.Add("FinalVideo", "FinalVideo");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("IssueIdentified", "IssueIdentified");
            tableMapping.ColumnMappings.Add("IssueResolved", "IssueResolved");
            tableMapping.ColumnMappings.Add("FullLengthLining", "FullLengthLining");
            tableMapping.ColumnMappings.Add("SubcontractorLining", "SubcontractorLining");
            tableMapping.ColumnMappings.Add("OutOfScopeInArea", "OutOfScopeInArea");
            tableMapping.ColumnMappings.Add("IssueGivenToBayCity", "IssueGivenToBayCity");
            tableMapping.ColumnMappings.Add("ConfirmedSize", "ConfirmedSize");
            tableMapping.ColumnMappings.Add("InstallRate", "InstallRate");
            tableMapping.ColumnMappings.Add("DeadlineDate", "DeadlineDate");
            tableMapping.ColumnMappings.Add("ProposedLiningDate", "ProposedLiningDate");
            tableMapping.ColumnMappings.Add("SalesIssue", "SalesIssue");
            tableMapping.ColumnMappings.Add("LFSIssue", "LFSIssue");
            tableMapping.ColumnMappings.Add("ClientIssue", "ClientIssue");
            tableMapping.ColumnMappings.Add("InvestigationIssue", "InvestigationIssue");
            tableMapping.ColumnMappings.Add("PointLining", "PointLining");
            tableMapping.ColumnMappings.Add("Grouting", "Grouting");
            tableMapping.ColumnMappings.Add("LateralLining", "LateralLining");
            tableMapping.ColumnMappings.Add("VacExDate", "VacExDate");
            tableMapping.ColumnMappings.Add("PusherDate", "PusherDate");
            tableMapping.ColumnMappings.Add("LinerOrdered", "LinerOrdered");
            tableMapping.ColumnMappings.Add("Restoration", "Restoration");
            tableMapping.ColumnMappings.Add("GroutDate", "GroutDate");
            tableMapping.ColumnMappings.Add("JLiner", "JLiner");
            tableMapping.ColumnMappings.Add("RehabAssessment", "RehabAssessment");
            tableMapping.ColumnMappings.Add("EstimatedJoints", "EstimatedJoints");
            tableMapping.ColumnMappings.Add("JointsTestSealed", "JointsTestSealed");
            tableMapping.ColumnMappings.Add("PreFlushDate", "PreFlushDate");
            tableMapping.ColumnMappings.Add("PreVideoDate", "PreVideoDate");
            tableMapping.ColumnMappings.Add("USMHMN", "USMHMN");
            tableMapping.ColumnMappings.Add("DSMHMN", "DSMHMN");
            tableMapping.ColumnMappings.Add("USMHDepth", "USMHDepth");
            tableMapping.ColumnMappings.Add("DSMHDepth", "DSMHDepth");
            tableMapping.ColumnMappings.Add("MeasurementsTakenBy", "MeasurementsTakenBy");
            tableMapping.ColumnMappings.Add("SteelTapeThruPipe", "SteelTapeThruPipe");
            tableMapping.ColumnMappings.Add("USMHAtMouth1200", "USMHAtMouth1200");
            tableMapping.ColumnMappings.Add("USMHAtMouth100", "USMHAtMouth100");
            tableMapping.ColumnMappings.Add("USMHAtMouth200", "USMHAtMouth200");
            tableMapping.ColumnMappings.Add("USMHAtMouth300", "USMHAtMouth300");
            tableMapping.ColumnMappings.Add("USMHAtMouth400", "USMHAtMouth400");
            tableMapping.ColumnMappings.Add("USMHAtMouth500", "USMHAtMouth500");
            tableMapping.ColumnMappings.Add("DSMHAtMouth1200", "DSMHAtMouth1200");
            tableMapping.ColumnMappings.Add("DSMHAtMouth100", "DSMHAtMouth100");
            tableMapping.ColumnMappings.Add("DSMHAtMouth200", "DSMHAtMouth200");
            tableMapping.ColumnMappings.Add("DSMHAtMouth300", "DSMHAtMouth300");
            tableMapping.ColumnMappings.Add("DSMHAtMouth400", "DSMHAtMouth400");
            tableMapping.ColumnMappings.Add("DSMHAtMouth500", "DSMHAtMouth500");
            tableMapping.ColumnMappings.Add("HydrantAddress", "HydrantAddress");
            tableMapping.ColumnMappings.Add("DistanceToInversionMH", "DistanceToInversionMH");
            tableMapping.ColumnMappings.Add("RampsRequired", "RampsRequired");
            tableMapping.ColumnMappings.Add("DegreeOfTrafficControl", "DegreeOfTrafficControl");
            tableMapping.ColumnMappings.Add("StandarBypass", "StandarBypass");
            tableMapping.ColumnMappings.Add("HydroWireDetails", "HydroWireDetails");
            tableMapping.ColumnMappings.Add("PipeMaterialType", "PipeMaterialType");
            tableMapping.ColumnMappings.Add("CappedLaterals", "CappedLaterals");
            tableMapping.ColumnMappings.Add("RoboticPrepRequired", "RoboticPrepRequired");
            tableMapping.ColumnMappings.Add("PipeSizeChange", "PipeSizeChange");
            tableMapping.ColumnMappings.Add("M1Comments", "M1Comments");
            tableMapping.ColumnMappings.Add("VideoDoneFrom", "VideoDoneFrom");
            tableMapping.ColumnMappings.Add("ToManhole", "ToManhole");
            tableMapping.ColumnMappings.Add("CutterDescriptionDuringMeasuring", "CutterDescriptionDuringMeasuring");
            tableMapping.ColumnMappings.Add("FullLengthPointLiner", "FullLengthPointLiner");
            tableMapping.ColumnMappings.Add("BypassRequired", "BypassRequired");
            tableMapping.ColumnMappings.Add("RoboticDistances", "RoboticDistances");
            tableMapping.ColumnMappings.Add("TrafficControlDetails", "TrafficControlDetails");
            tableMapping.ColumnMappings.Add("LineWithID", "LineWithID");
            tableMapping.ColumnMappings.Add("SchoolZone", "SchoolZone");
            tableMapping.ColumnMappings.Add("RestaurantArea", "RestaurantArea");
            tableMapping.ColumnMappings.Add("CarwashLaundromat", "CarwashLaundromat");
            tableMapping.ColumnMappings.Add("HydroPulley", "HydroPulley");
            tableMapping.ColumnMappings.Add("FridgeCart", "FridgeCart");
            tableMapping.ColumnMappings.Add("TwoInchPump", "TwoInchPump");
            tableMapping.ColumnMappings.Add("SixInchBypass", "SixInchBypass");
            tableMapping.ColumnMappings.Add("Scaffolding", "Scaffolding");
            tableMapping.ColumnMappings.Add("WinchExtension", "WinchExtension");
            tableMapping.ColumnMappings.Add("ExtraGenerator", "ExtraGenerator");
            tableMapping.ColumnMappings.Add("GreyCableExtension", "GreyCableExtension");
            tableMapping.ColumnMappings.Add("EasementMats", "EasementMats");
            tableMapping.ColumnMappings.Add("MeasurementType", "MeasurementType");
            tableMapping.ColumnMappings.Add("DropPipe", "DropPipe");
            tableMapping.ColumnMappings.Add("DropPipeInvertDepth", "DropPipeInvertDepth");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("MeasuredFromManhole", "MeasuredFromManhole");
            tableMapping.ColumnMappings.Add("MainLined", "MainLined");
            tableMapping.ColumnMappings.Add("BenchingIssue", "BenchingIssue");
            tableMapping.ColumnMappings.Add("Archived", "Archived");
            tableMapping.ColumnMappings.Add("ScaledLength1", "ScaledLength1");
            tableMapping.ColumnMappings.Add("History", "History");
            tableMapping.ColumnMappings.Add("NumLats", "NumLats");
            tableMapping.ColumnMappings.Add("NotLinedYet", "NotLinedYet");
            tableMapping.ColumnMappings.Add("AllMeasured", "AllMeasured");
            tableMapping.ColumnMappings.Add("City", "City");
            tableMapping.ColumnMappings.Add("ProvState", "ProvState");
            tableMapping.ColumnMappings.Add("IssueWithLaterals", "IssueWithLaterals");
            tableMapping.ColumnMappings.Add("NotMeasuredYet", "NotMeasuredYet");
            tableMapping.ColumnMappings.Add("NotDeliveredYet", "NotDeliveredYet");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_MASTER_AREA] WHERE (([ID] = @Original_ID) AND ([COMPANY_ID" +
                "] = @Original_COMPANY_ID) AND ([RecordID] = @Original_RecordID) AND ((@IsNull_Cl" +
                "ientID = 1 AND [ClientID] IS NULL) OR ([ClientID] = @Original_ClientID)) AND ((@" +
                "IsNull_COMPANIES_ID = 1 AND [COMPANIES_ID] IS NULL) OR ([COMPANIES_ID] = @Origin" +
                "al_COMPANIES_ID)) AND ((@IsNull_SubArea = 1 AND [SubArea] IS NULL) OR ([SubArea]" +
                " = @Original_SubArea)) AND ((@IsNull_Street = 1 AND [Street] IS NULL) OR ([Stree" +
                "t] = @Original_Street)) AND ((@IsNull_USMH = 1 AND [USMH] IS NULL) OR ([USMH] = " +
                "@Original_USMH)) AND ((@IsNull_DSMH = 1 AND [DSMH] IS NULL) OR ([DSMH] = @Origin" +
                "al_DSMH)) AND ((@IsNull_Size_ = 1 AND [Size_] IS NULL) OR ([Size_] = @Original_S" +
                "ize_)) AND ((@IsNull_ScaledLength = 1 AND [ScaledLength] IS NULL) OR ([ScaledLen" +
                "gth] = @Original_ScaledLength)) AND ((@IsNull_P1Date = 1 AND [P1Date] IS NULL) O" +
                "R ([P1Date] = @Original_P1Date)) AND ((@IsNull_ActualLength = 1 AND [ActualLengt" +
                "h] IS NULL) OR ([ActualLength] = @Original_ActualLength)) AND ((@IsNull_LiveLats" +
                " = 1 AND [LiveLats] IS NULL) OR ([LiveLats] = @Original_LiveLats)) AND ((@IsNull" +
                "_CXIsRemoved = 1 AND [CXIsRemoved] IS NULL) OR ([CXIsRemoved] = @Original_CXIsRe" +
                "moved)) AND ((@IsNull_M1Date = 1 AND [M1Date] IS NULL) OR ([M1Date] = @Original_" +
                "M1Date)) AND ((@IsNull_M2Date = 1 AND [M2Date] IS NULL) OR ([M2Date] = @Original" +
                "_M2Date)) AND ((@IsNull_InstallDate = 1 AND [InstallDate] IS NULL) OR ([InstallD" +
                "ate] = @Original_InstallDate)) AND ((@IsNull_FinalVideo = 1 AND [FinalVideo] IS " +
                "NULL) OR ([FinalVideo] = @Original_FinalVideo)) AND ((@IsNull_IssueIdentified = " +
                "1 AND [IssueIdentified] IS NULL) OR ([IssueIdentified] = @Original_IssueIdentifi" +
                "ed)) AND ((@IsNull_IssueResolved = 1 AND [IssueResolved] IS NULL) OR ([IssueReso" +
                "lved] = @Original_IssueResolved)) AND ((@IsNull_FullLengthLining = 1 AND [FullLe" +
                "ngthLining] IS NULL) OR ([FullLengthLining] = @Original_FullLengthLining)) AND (" +
                "(@IsNull_SubcontractorLining = 1 AND [SubcontractorLining] IS NULL) OR ([Subcont" +
                "ractorLining] = @Original_SubcontractorLining)) AND ((@IsNull_OutOfScopeInArea =" +
                " 1 AND [OutOfScopeInArea] IS NULL) OR ([OutOfScopeInArea] = @Original_OutOfScope" +
                "InArea)) AND ((@IsNull_IssueGivenToBayCity = 1 AND [IssueGivenToBayCity] IS NULL" +
                ") OR ([IssueGivenToBayCity] = @Original_IssueGivenToBayCity)) AND ((@IsNull_Conf" +
                "irmedSize = 1 AND [ConfirmedSize] IS NULL) OR ([ConfirmedSize] = @Original_Confi" +
                "rmedSize)) AND ((@IsNull_InstallRate = 1 AND [InstallRate] IS NULL) OR ([Install" +
                "Rate] = @Original_InstallRate)) AND ((@IsNull_DeadlineDate = 1 AND [DeadlineDate" +
                "] IS NULL) OR ([DeadlineDate] = @Original_DeadlineDate)) AND ((@IsNull_ProposedL" +
                "iningDate = 1 AND [ProposedLiningDate] IS NULL) OR ([ProposedLiningDate] = @Orig" +
                "inal_ProposedLiningDate)) AND ((@IsNull_SalesIssue = 1 AND [SalesIssue] IS NULL)" +
                " OR ([SalesIssue] = @Original_SalesIssue)) AND ((@IsNull_LFSIssue = 1 AND [LFSIs" +
                "sue] IS NULL) OR ([LFSIssue] = @Original_LFSIssue)) AND ((@IsNull_ClientIssue = " +
                "1 AND [ClientIssue] IS NULL) OR ([ClientIssue] = @Original_ClientIssue)) AND ((@" +
                "IsNull_InvestigationIssue = 1 AND [InvestigationIssue] IS NULL) OR ([Investigati" +
                "onIssue] = @Original_InvestigationIssue)) AND ((@IsNull_PointLining = 1 AND [Poi" +
                "ntLining] IS NULL) OR ([PointLining] = @Original_PointLining)) AND ((@IsNull_Gro" +
                "uting = 1 AND [Grouting] IS NULL) OR ([Grouting] = @Original_Grouting)) AND ((@I" +
                "sNull_LateralLining = 1 AND [LateralLining] IS NULL) OR ([LateralLining] = @Orig" +
                "inal_LateralLining)) AND ((@IsNull_VacExDate = 1 AND [VacExDate] IS NULL) OR ([V" +
                "acExDate] = @Original_VacExDate)) AND ((@IsNull_PusherDate = 1 AND [PusherDate] " +
                "IS NULL) OR ([PusherDate] = @Original_PusherDate)) AND ((@IsNull_LinerOrdered = " +
                "1 AND [LinerOrdered] IS NULL) OR ([LinerOrdered] = @Original_LinerOrdered)) AND " +
                "((@IsNull_Restoration = 1 AND [Restoration] IS NULL) OR ([Restoration] = @Origin" +
                "al_Restoration)) AND ((@IsNull_GroutDate = 1 AND [GroutDate] IS NULL) OR ([Grout" +
                "Date] = @Original_GroutDate)) AND ((@IsNull_JLiner = 1 AND [JLiner] IS NULL) OR " +
                "([JLiner] = @Original_JLiner)) AND ((@IsNull_RehabAssessment = 1 AND [RehabAsses" +
                "sment] IS NULL) OR ([RehabAssessment] = @Original_RehabAssessment)) AND ((@IsNul" +
                "l_EstimatedJoints = 1 AND [EstimatedJoints] IS NULL) OR ([EstimatedJoints] = @Or" +
                "iginal_EstimatedJoints)) AND ((@IsNull_JointsTestSealed = 1 AND [JointsTestSeale" +
                "d] IS NULL) OR ([JointsTestSealed] = @Original_JointsTestSealed)) AND ((@IsNull_" +
                "PreFlushDate = 1 AND [PreFlushDate] IS NULL) OR ([PreFlushDate] = @Original_PreF" +
                "lushDate)) AND ((@IsNull_PreVideoDate = 1 AND [PreVideoDate] IS NULL) OR ([PreVi" +
                "deoDate] = @Original_PreVideoDate)) AND ((@IsNull_USMHMN = 1 AND [USMHMN] IS NUL" +
                "L) OR ([USMHMN] = @Original_USMHMN)) AND ((@IsNull_DSMHMN = 1 AND [DSMHMN] IS NU" +
                "LL) OR ([DSMHMN] = @Original_DSMHMN)) AND ((@IsNull_USMHDepth = 1 AND [USMHDepth" +
                "] IS NULL) OR ([USMHDepth] = @Original_USMHDepth)) AND ((@IsNull_DSMHDepth = 1 A" +
                "ND [DSMHDepth] IS NULL) OR ([DSMHDepth] = @Original_DSMHDepth)) AND ((@IsNull_Me" +
                "asurementsTakenBy = 1 AND [MeasurementsTakenBy] IS NULL) OR ([MeasurementsTakenB" +
                "y] = @Original_MeasurementsTakenBy)) AND ((@IsNull_SteelTapeThruPipe = 1 AND [St" +
                "eelTapeThruPipe] IS NULL) OR ([SteelTapeThruPipe] = @Original_SteelTapeThruPipe)" +
                ") AND ((@IsNull_USMHAtMouth1200 = 1 AND [USMHAtMouth1200] IS NULL) OR ([USMHAtMo" +
                "uth1200] = @Original_USMHAtMouth1200)) AND ((@IsNull_USMHAtMouth100 = 1 AND [USM" +
                "HAtMouth100] IS NULL) OR ([USMHAtMouth100] = @Original_USMHAtMouth100)) AND ((@I" +
                "sNull_USMHAtMouth200 = 1 AND [USMHAtMouth200] IS NULL) OR ([USMHAtMouth200] = @O" +
                "riginal_USMHAtMouth200)) AND ((@IsNull_USMHAtMouth300 = 1 AND [USMHAtMouth300] I" +
                "S NULL) OR ([USMHAtMouth300] = @Original_USMHAtMouth300)) AND ((@IsNull_USMHAtMo" +
                "uth400 = 1 AND [USMHAtMouth400] IS NULL) OR ([USMHAtMouth400] = @Original_USMHAt" +
                "Mouth400)) AND ((@IsNull_USMHAtMouth500 = 1 AND [USMHAtMouth500] IS NULL) OR ([U" +
                "SMHAtMouth500] = @Original_USMHAtMouth500)) AND ((@IsNull_DSMHAtMouth1200 = 1 AN" +
                "D [DSMHAtMouth1200] IS NULL) OR ([DSMHAtMouth1200] = @Original_DSMHAtMouth1200))" +
                " AND ((@IsNull_DSMHAtMouth100 = 1 AND [DSMHAtMouth100] IS NULL) OR ([DSMHAtMouth" +
                "100] = @Original_DSMHAtMouth100)) AND ((@IsNull_DSMHAtMouth200 = 1 AND [DSMHAtMo" +
                "uth200] IS NULL) OR ([DSMHAtMouth200] = @Original_DSMHAtMouth200)) AND ((@IsNull" +
                "_DSMHAtMouth300 = 1 AND [DSMHAtMouth300] IS NULL) OR ([DSMHAtMouth300] = @Origin" +
                "al_DSMHAtMouth300)) AND ((@IsNull_DSMHAtMouth400 = 1 AND [DSMHAtMouth400] IS NUL" +
                "L) OR ([DSMHAtMouth400] = @Original_DSMHAtMouth400)) AND ((@IsNull_DSMHAtMouth50" +
                "0 = 1 AND [DSMHAtMouth500] IS NULL) OR ([DSMHAtMouth500] = @Original_DSMHAtMouth" +
                "500)) AND ((@IsNull_HydrantAddress = 1 AND [HydrantAddress] IS NULL) OR ([Hydran" +
                "tAddress] = @Original_HydrantAddress)) AND ((@IsNull_DistanceToInversionMH = 1 A" +
                "ND [DistanceToInversionMH] IS NULL) OR ([DistanceToInversionMH] = @Original_Dist" +
                "anceToInversionMH)) AND ((@IsNull_RampsRequired = 1 AND [RampsRequired] IS NULL)" +
                " OR ([RampsRequired] = @Original_RampsRequired)) AND ((@IsNull_DegreeOfTrafficCo" +
                "ntrol = 1 AND [DegreeOfTrafficControl] IS NULL) OR ([DegreeOfTrafficControl] = @" +
                "Original_DegreeOfTrafficControl)) AND ((@IsNull_StandarBypass = 1 AND [StandarBy" +
                "pass] IS NULL) OR ([StandarBypass] = @Original_StandarBypass)) AND ((@IsNull_Hyd" +
                "roWireDetails = 1 AND [HydroWireDetails] IS NULL) OR ([HydroWireDetails] = @Orig" +
                "inal_HydroWireDetails)) AND ((@IsNull_PipeMaterialType = 1 AND [PipeMaterialType" +
                "] IS NULL) OR ([PipeMaterialType] = @Original_PipeMaterialType)) AND ((@IsNull_C" +
                "appedLaterals = 1 AND [CappedLaterals] IS NULL) OR ([CappedLaterals] = @Original" +
                "_CappedLaterals)) AND ((@IsNull_RoboticPrepRequired = 1 AND [RoboticPrepRequired" +
                "] IS NULL) OR ([RoboticPrepRequired] = @Original_RoboticPrepRequired)) AND ((@Is" +
                "Null_PipeSizeChange = 1 AND [PipeSizeChange] IS NULL) OR ([PipeSizeChange] = @Or" +
                "iginal_PipeSizeChange)) AND ((@IsNull_VideoDoneFrom = 1 AND [VideoDoneFrom] IS N" +
                "ULL) OR ([VideoDoneFrom] = @Original_VideoDoneFrom)) AND ((@IsNull_ToManhole = 1" +
                " AND [ToManhole] IS NULL) OR ([ToManhole] = @Original_ToManhole)) AND ((@IsNull_" +
                "CutterDescriptionDuringMeasuring = 1 AND [CutterDescriptionDuringMeasuring] IS N" +
                "ULL) OR ([CutterDescriptionDuringMeasuring] = @Original_CutterDescriptionDuringM" +
                "easuring)) AND ((@IsNull_FullLengthPointLiner = 1 AND [FullLengthPointLiner] IS " +
                "NULL) OR ([FullLengthPointLiner] = @Original_FullLengthPointLiner)) AND ((@IsNul" +
                "l_BypassRequired = 1 AND [BypassRequired] IS NULL) OR ([BypassRequired] = @Origi" +
                "nal_BypassRequired)) AND ((@IsNull_RoboticDistances = 1 AND [RoboticDistances] I" +
                "S NULL) OR ([RoboticDistances] = @Original_RoboticDistances)) AND ((@IsNull_Line" +
                "WithID = 1 AND [LineWithID] IS NULL) OR ([LineWithID] = @Original_LineWithID)) A" +
                "ND ((@IsNull_SchoolZone = 1 AND [SchoolZone] IS NULL) OR ([SchoolZone] = @Origin" +
                "al_SchoolZone)) AND ((@IsNull_RestaurantArea = 1 AND [RestaurantArea] IS NULL) O" +
                "R ([RestaurantArea] = @Original_RestaurantArea)) AND ((@IsNull_CarwashLaundromat" +
                " = 1 AND [CarwashLaundromat] IS NULL) OR ([CarwashLaundromat] = @Original_Carwas" +
                "hLaundromat)) AND ((@IsNull_HydroPulley = 1 AND [HydroPulley] IS NULL) OR ([Hydr" +
                "oPulley] = @Original_HydroPulley)) AND ((@IsNull_FridgeCart = 1 AND [FridgeCart]" +
                " IS NULL) OR ([FridgeCart] = @Original_FridgeCart)) AND ((@IsNull_TwoInchPump = " +
                "1 AND [TwoInchPump] IS NULL) OR ([TwoInchPump] = @Original_TwoInchPump)) AND ((@" +
                "IsNull_SixInchBypass = 1 AND [SixInchBypass] IS NULL) OR ([SixInchBypass] = @Ori" +
                "ginal_SixInchBypass)) AND ((@IsNull_Scaffolding = 1 AND [Scaffolding] IS NULL) O" +
                "R ([Scaffolding] = @Original_Scaffolding)) AND ((@IsNull_WinchExtension = 1 AND " +
                "[WinchExtension] IS NULL) OR ([WinchExtension] = @Original_WinchExtension)) AND " +
                "((@IsNull_ExtraGenerator = 1 AND [ExtraGenerator] IS NULL) OR ([ExtraGenerator] " +
                "= @Original_ExtraGenerator)) AND ((@IsNull_GreyCableExtension = 1 AND [GreyCable" +
                "Extension] IS NULL) OR ([GreyCableExtension] = @Original_GreyCableExtension)) AN" +
                "D ((@IsNull_EasementMats = 1 AND [EasementMats] IS NULL) OR ([EasementMats] = @O" +
                "riginal_EasementMats)) AND ((@IsNull_MeasurementType = 1 AND [MeasurementType] I" +
                "S NULL) OR ([MeasurementType] = @Original_MeasurementType)) AND ((@IsNull_DropPi" +
                "pe = 1 AND [DropPipe] IS NULL) OR ([DropPipe] = @Original_DropPipe)) AND ((@IsNu" +
                "ll_DropPipeInvertDepth = 1 AND [DropPipeInvertDepth] IS NULL) OR ([DropPipeInver" +
                "tDepth] = @Original_DropPipeInvertDepth)) AND ((@IsNull_Deleted = 1 AND [Deleted" +
                "] IS NULL) OR ([Deleted] = @Original_Deleted)) AND ((@IsNull_MeasuredFromManhole" +
                " = 1 AND [MeasuredFromManhole] IS NULL) OR ([MeasuredFromManhole] = @Original_Me" +
                "asuredFromManhole)) AND ((@IsNull_MainLined = 1 AND [MainLined] IS NULL) OR ([Ma" +
                "inLined] = @Original_MainLined)) AND ((@IsNull_BenchingIssue = 1 AND [BenchingIs" +
                "sue] IS NULL) OR ([BenchingIssue] = @Original_BenchingIssue)) AND ((@IsNull_Arch" +
                "ived = 1 AND [Archived] IS NULL) OR ([Archived] = @Original_Archived)) AND ((@Is" +
                "Null_ScaledLength1 = 1 AND [ScaledLength1] IS NULL) OR ([ScaledLength1] = @Origi" +
                "nal_ScaledLength1)) AND ((@IsNull_NumLats = 1 AND [NumLats] IS NULL) OR ([NumLat" +
                "s] = @Original_NumLats)) AND ((@IsNull_NotLinedYet = 1 AND [NotLinedYet] IS NULL" +
                ") OR ([NotLinedYet] = @Original_NotLinedYet)) AND ((@IsNull_AllMeasured = 1 AND " +
                "[AllMeasured] IS NULL) OR ([AllMeasured] = @Original_AllMeasured)) AND ((@IsNull" +
                "_City = 1 AND [City] IS NULL) OR ([City] = @Original_City)) AND ((@IsNull_ProvSt" +
                "ate = 1 AND [ProvState] IS NULL) OR ([ProvState] = @Original_ProvState)) AND ([I" +
                "ssueWithLaterals] = @Original_IssueWithLaterals) AND ((@IsNull_NotMeasuredYet = " +
                "1 AND [NotMeasuredYet] IS NULL) OR ([NotMeasuredYet] = @Original_NotMeasuredYet)" +
                ") AND ((@IsNull_NotDeliveredYet = 1 AND [NotDeliveredYet] IS NULL) OR ([NotDeliv" +
                "eredYet] = @Original_NotDeliveredYet)))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RecordID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RecordID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ClientID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_COMPANIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANIES_ID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANIES_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SubArea", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SubArea", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SubArea", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SubArea", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Street", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Street", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Street", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Street", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Size_", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Size_", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Size_", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Size_", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ScaledLength", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ScaledLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_P1Date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "P1Date", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_P1Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "P1Date", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ActualLength", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ActualLength", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ActualLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ActualLength", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LiveLats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveLats", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LiveLats", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveLats", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CXIsRemoved", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CXIsRemoved", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_M1Date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "M1Date", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_M1Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "M1Date", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_M2Date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "M2Date", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_M2Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "M2Date", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InstallDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InstallDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FinalVideo", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FinalVideo", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_IssueIdentified", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IssueIdentified", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_IssueResolved", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IssueResolved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FullLengthLining", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthLining", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FullLengthLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthLining", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SubcontractorLining", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SubcontractorLining", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SubcontractorLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SubcontractorLining", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_OutOfScopeInArea", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "OutOfScopeInArea", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OutOfScopeInArea", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "OutOfScopeInArea", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_IssueGivenToBayCity", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToBayCity", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IssueGivenToBayCity", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToBayCity", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ConfirmedSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedSize", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ConfirmedSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedSize", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InstallRate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallRate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InstallRate", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallRate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DeadlineDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DeadlineDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DeadlineDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DeadlineDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ProposedLiningDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProposedLiningDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SalesIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SalesIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SalesIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SalesIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LFSIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LFSIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LFSIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LFSIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ClientIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InvestigationIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InvestigationIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InvestigationIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "InvestigationIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PointLining", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PointLining", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PointLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PointLining", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Grouting", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouting", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Grouting", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouting", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LateralLining", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralLining", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LateralLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralLining", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_VacExDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "VacExDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VacExDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "VacExDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PusherDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PusherDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PusherDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PusherDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerOrdered", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerOrdered", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Restoration", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Restoration", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Restoration", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Restoration", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_GroutDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "GroutDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GroutDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "GroutDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_JLiner", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "JLiner", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_JLiner", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "JLiner", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RehabAssessment", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RehabAssessment", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RehabAssessment", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RehabAssessment", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_EstimatedJoints", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EstimatedJoints", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_JointsTestSealed", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_JointsTestSealed", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PreFlushDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PreFlushDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PreVideoDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PreVideoDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHMN", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHMN", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHMN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHMN", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHMN", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHMN", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHMN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHMN", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHDepth", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHDepth", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MeasurementsTakenBy", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasurementsTakenBy", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SteelTapeThruPipe", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThruPipe", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SteelTapeThruPipe", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThruPipe", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth1200", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth1200", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth1200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth1200", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth100", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth100", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth100", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth100", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth200", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth200", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth200", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth300", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth300", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth300", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth300", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth400", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth400", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth400", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth400", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth500", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth500", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth500", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth500", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth1200", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth1200", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth1200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth1200", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth100", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth100", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth100", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth100", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth200", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth200", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth200", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth300", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth300", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth300", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth300", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth400", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth400", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth400", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth400", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth500", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth500", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth500", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth500", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_HydrantAddress", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HydrantAddress", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DistanceToInversionMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceToInversionMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RampsRequired", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RampsRequired", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RampsRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RampsRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DegreeOfTrafficControl", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DegreeOfTrafficControl", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DegreeOfTrafficControl", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DegreeOfTrafficControl", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_StandarBypass", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "StandarBypass", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_StandarBypass", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "StandarBypass", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_HydroWireDetails", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroWireDetails", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HydroWireDetails", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroWireDetails", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PipeMaterialType", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeMaterialType", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PipeMaterialType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeMaterialType", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CappedLaterals", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CappedLaterals", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RoboticPrepRequired", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepRequired", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RoboticPrepRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PipeSizeChange", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeSizeChange", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PipeSizeChange", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeSizeChange", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_VideoDoneFrom", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFrom", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VideoDoneFrom", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFrom", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ToManhole", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ToManhole", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ToManhole", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ToManhole", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CutterDescriptionDuringMeasuring", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CutterDescriptionDuringMeasuring", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CutterDescriptionDuringMeasuring", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CutterDescriptionDuringMeasuring", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FullLengthPointLiner", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthPointLiner", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FullLengthPointLiner", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthPointLiner", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BypassRequired", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BypassRequired", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BypassRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "BypassRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RoboticDistances", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RoboticDistances", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LineWithID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LineWithID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LineWithID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LineWithID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SchoolZone", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SchoolZone", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SchoolZone", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SchoolZone", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RestaurantArea", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RestaurantArea", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RestaurantArea", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RestaurantArea", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CarwashLaundromat", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CarwashLaundromat", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CarwashLaundromat", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CarwashLaundromat", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_HydroPulley", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroPulley", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HydroPulley", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroPulley", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FridgeCart", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FridgeCart", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FridgeCart", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FridgeCart", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_TwoInchPump", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "TwoInchPump", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_TwoInchPump", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "TwoInchPump", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SixInchBypass", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SixInchBypass", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SixInchBypass", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SixInchBypass", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Scaffolding", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Scaffolding", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Scaffolding", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Scaffolding", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_WinchExtension", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "WinchExtension", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_WinchExtension", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "WinchExtension", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ExtraGenerator", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraGenerator", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExtraGenerator", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraGenerator", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_GreyCableExtension", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "GreyCableExtension", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GreyCableExtension", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GreyCableExtension", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_EasementMats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EasementMats", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EasementMats", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "EasementMats", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MeasurementType", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasurementType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DropPipe", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipe", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DropPipe", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipe", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DropPipeInvertDepth", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DropPipeInvertDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Deleted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MeasuredFromManhole", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredFromManhole", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasuredFromManhole", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredFromManhole", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MainLined", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MainLined", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MainLined", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MainLined", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BenchingIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BenchingIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BenchingIssue", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BenchingIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Archived", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ScaledLength1", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength1", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ScaledLength1", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength1", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_NumLats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NumLats", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NumLats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NumLats", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_NotLinedYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotLinedYet", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NotLinedYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotLinedYet", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_AllMeasured", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AllMeasured", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AllMeasured", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "AllMeasured", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_City", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "City", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "City", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ProvState", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvState", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProvState", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvState", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IssueWithLaterals", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueWithLaterals", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_NotMeasuredYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotMeasuredYet", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NotMeasuredYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotMeasuredYet", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_NotDeliveredYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotDeliveredYet", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NotDeliveredYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotDeliveredYet", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[LFS_MASTER_AREA] ([ID], [COMPANY_ID], [RecordID], [ClientID], " +
                "[COMPANIES_ID], [SubArea], [Street], [USMH], [DSMH], [Size_], [ScaledLength], [P" +
                "1Date], [ActualLength], [LiveLats], [CXIsRemoved], [M1Date], [M2Date], [InstallD" +
                "ate], [FinalVideo], [Comments], [IssueIdentified], [IssueResolved], [FullLengthL" +
                "ining], [SubcontractorLining], [OutOfScopeInArea], [IssueGivenToBayCity], [Confi" +
                "rmedSize], [InstallRate], [DeadlineDate], [ProposedLiningDate], [SalesIssue], [L" +
                "FSIssue], [ClientIssue], [InvestigationIssue], [PointLining], [Grouting], [Later" +
                "alLining], [VacExDate], [PusherDate], [LinerOrdered], [Restoration], [GroutDate]" +
                ", [JLiner], [RehabAssessment], [EstimatedJoints], [JointsTestSealed], [PreFlushD" +
                "ate], [PreVideoDate], [USMHMN], [DSMHMN], [USMHDepth], [DSMHDepth], [Measurement" +
                "sTakenBy], [SteelTapeThruPipe], [USMHAtMouth1200], [USMHAtMouth100], [USMHAtMout" +
                "h200], [USMHAtMouth300], [USMHAtMouth400], [USMHAtMouth500], [DSMHAtMouth1200], " +
                "[DSMHAtMouth100], [DSMHAtMouth200], [DSMHAtMouth300], [DSMHAtMouth400], [DSMHAtM" +
                "outh500], [HydrantAddress], [DistanceToInversionMH], [RampsRequired], [DegreeOfT" +
                "rafficControl], [StandarBypass], [HydroWireDetails], [PipeMaterialType], [Capped" +
                "Laterals], [RoboticPrepRequired], [PipeSizeChange], [M1Comments], [VideoDoneFrom" +
                "], [ToManhole], [CutterDescriptionDuringMeasuring], [FullLengthPointLiner], [Byp" +
                "assRequired], [RoboticDistances], [TrafficControlDetails], [LineWithID], [School" +
                "Zone], [RestaurantArea], [CarwashLaundromat], [HydroPulley], [FridgeCart], [TwoI" +
                "nchPump], [SixInchBypass], [Scaffolding], [WinchExtension], [ExtraGenerator], [G" +
                "reyCableExtension], [EasementMats], [MeasurementType], [DropPipe], [DropPipeInve" +
                "rtDepth], [Deleted], [MeasuredFromManhole], [MainLined], [BenchingIssue], [Archi" +
                "ved], [ScaledLength1], [History], [NumLats], [NotLinedYet], [AllMeasured], [City" +
                "], [ProvState], [IssueWithLaterals], [NotMeasuredYet], [NotDeliveredYet]) VALUES" +
                " (@ID, @COMPANY_ID, @RecordID, @ClientID, @COMPANIES_ID, @SubArea, @Street, @USM" +
                "H, @DSMH, @Size_, @ScaledLength, @P1Date, @ActualLength, @LiveLats, @CXIsRemoved" +
                ", @M1Date, @M2Date, @InstallDate, @FinalVideo, @Comments, @IssueIdentified, @Iss" +
                "ueResolved, @FullLengthLining, @SubcontractorLining, @OutOfScopeInArea, @IssueGi" +
                "venToBayCity, @ConfirmedSize, @InstallRate, @DeadlineDate, @ProposedLiningDate, " +
                "@SalesIssue, @LFSIssue, @ClientIssue, @InvestigationIssue, @PointLining, @Grouti" +
                "ng, @LateralLining, @VacExDate, @PusherDate, @LinerOrdered, @Restoration, @Grout" +
                "Date, @JLiner, @RehabAssessment, @EstimatedJoints, @JointsTestSealed, @PreFlushD" +
                "ate, @PreVideoDate, @USMHMN, @DSMHMN, @USMHDepth, @DSMHDepth, @MeasurementsTaken" +
                "By, @SteelTapeThruPipe, @USMHAtMouth1200, @USMHAtMouth100, @USMHAtMouth200, @USM" +
                "HAtMouth300, @USMHAtMouth400, @USMHAtMouth500, @DSMHAtMouth1200, @DSMHAtMouth100" +
                ", @DSMHAtMouth200, @DSMHAtMouth300, @DSMHAtMouth400, @DSMHAtMouth500, @HydrantAd" +
                "dress, @DistanceToInversionMH, @RampsRequired, @DegreeOfTrafficControl, @Standar" +
                "Bypass, @HydroWireDetails, @PipeMaterialType, @CappedLaterals, @RoboticPrepRequi" +
                "red, @PipeSizeChange, @M1Comments, @VideoDoneFrom, @ToManhole, @CutterDescriptio" +
                "nDuringMeasuring, @FullLengthPointLiner, @BypassRequired, @RoboticDistances, @Tr" +
                "afficControlDetails, @LineWithID, @SchoolZone, @RestaurantArea, @CarwashLaundrom" +
                "at, @HydroPulley, @FridgeCart, @TwoInchPump, @SixInchBypass, @Scaffolding, @Winc" +
                "hExtension, @ExtraGenerator, @GreyCableExtension, @EasementMats, @MeasurementTyp" +
                "e, @DropPipe, @DropPipeInvertDepth, @Deleted, @MeasuredFromManhole, @MainLined, " +
                "@BenchingIssue, @Archived, @ScaledLength1, @History, @NumLats, @NotLinedYet, @Al" +
                "lMeasured, @City, @ProvState, @IssueWithLaterals, @NotMeasuredYet, @NotDelivered" +
                "Yet);\r\nSELECT ID, COMPANY_ID, RecordID, ClientID, COMPANIES_ID, SubArea, Street," +
                " USMH, DSMH, Size_, ScaledLength, P1Date, ActualLength, LiveLats, CXIsRemoved, M" +
                "1Date, M2Date, InstallDate, FinalVideo, Comments, IssueIdentified, IssueResolved" +
                ", FullLengthLining, SubcontractorLining, OutOfScopeInArea, IssueGivenToBayCity, " +
                "ConfirmedSize, InstallRate, DeadlineDate, ProposedLiningDate, SalesIssue, LFSIss" +
                "ue, ClientIssue, InvestigationIssue, PointLining, Grouting, LateralLining, VacEx" +
                "Date, PusherDate, LinerOrdered, Restoration, GroutDate, JLiner, RehabAssessment," +
                " EstimatedJoints, JointsTestSealed, PreFlushDate, PreVideoDate, USMHMN, DSMHMN, " +
                "USMHDepth, DSMHDepth, MeasurementsTakenBy, SteelTapeThruPipe, USMHAtMouth1200, U" +
                "SMHAtMouth100, USMHAtMouth200, USMHAtMouth300, USMHAtMouth400, USMHAtMouth500, D" +
                "SMHAtMouth1200, DSMHAtMouth100, DSMHAtMouth200, DSMHAtMouth300, DSMHAtMouth400, " +
                "DSMHAtMouth500, HydrantAddress, DistanceToInversionMH, RampsRequired, DegreeOfTr" +
                "afficControl, StandarBypass, HydroWireDetails, PipeMaterialType, CappedLaterals," +
                " RoboticPrepRequired, PipeSizeChange, M1Comments, VideoDoneFrom, ToManhole, Cutt" +
                "erDescriptionDuringMeasuring, FullLengthPointLiner, BypassRequired, RoboticDista" +
                "nces, TrafficControlDetails, LineWithID, SchoolZone, RestaurantArea, CarwashLaun" +
                "dromat, HydroPulley, FridgeCart, TwoInchPump, SixInchBypass, Scaffolding, WinchE" +
                "xtension, ExtraGenerator, GreyCableExtension, EasementMats, MeasurementType, Dro" +
                "pPipe, DropPipeInvertDepth, Deleted, MeasuredFromManhole, MainLined, BenchingIss" +
                "ue, Archived, ScaledLength1, History, NumLats, NotLinedYet, AllMeasured, City, P" +
                "rovState, IssueWithLaterals, NotMeasuredYet, NotDeliveredYet FROM LFS_MASTER_ARE" +
                "A WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RecordID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RecordID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANIES_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SubArea", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SubArea", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Street", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Street", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Size_", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Size_", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ScaledLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@P1Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "P1Date", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ActualLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ActualLength", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LiveLats", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveLats", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CXIsRemoved", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@M1Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "M1Date", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@M2Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "M2Date", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InstallDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FinalVideo", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "Comments", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IssueIdentified", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IssueResolved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FullLengthLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthLining", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SubcontractorLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SubcontractorLining", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OutOfScopeInArea", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "OutOfScopeInArea", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IssueGivenToBayCity", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToBayCity", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ConfirmedSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedSize", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InstallRate", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallRate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DeadlineDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DeadlineDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProposedLiningDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SalesIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SalesIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LFSIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LFSIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InvestigationIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "InvestigationIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PointLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PointLining", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Grouting", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouting", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LateralLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralLining", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VacExDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "VacExDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PusherDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PusherDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerOrdered", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Restoration", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Restoration", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GroutDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "GroutDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JLiner", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "JLiner", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RehabAssessment", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RehabAssessment", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EstimatedJoints", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JointsTestSealed", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PreFlushDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PreVideoDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHMN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHMN", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHMN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHMN", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasurementsTakenBy", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SteelTapeThruPipe", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThruPipe", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth1200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth1200", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth100", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth100", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth200", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth300", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth300", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth400", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth400", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth500", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth500", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth1200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth1200", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth100", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth100", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth200", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth300", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth300", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth400", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth400", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth500", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth500", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HydrantAddress", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceToInversionMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RampsRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RampsRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DegreeOfTrafficControl", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DegreeOfTrafficControl", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StandarBypass", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "StandarBypass", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HydroWireDetails", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroWireDetails", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PipeMaterialType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeMaterialType", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CappedLaterals", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RoboticPrepRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PipeSizeChange", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeSizeChange", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@M1Comments", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "M1Comments", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VideoDoneFrom", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFrom", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ToManhole", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ToManhole", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CutterDescriptionDuringMeasuring", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CutterDescriptionDuringMeasuring", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FullLengthPointLiner", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthPointLiner", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BypassRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "BypassRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RoboticDistances", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TrafficControlDetails", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "TrafficControlDetails", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LineWithID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LineWithID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SchoolZone", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SchoolZone", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RestaurantArea", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RestaurantArea", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CarwashLaundromat", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CarwashLaundromat", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HydroPulley", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroPulley", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FridgeCart", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FridgeCart", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TwoInchPump", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "TwoInchPump", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SixInchBypass", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SixInchBypass", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Scaffolding", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Scaffolding", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@WinchExtension", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "WinchExtension", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExtraGenerator", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraGenerator", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GreyCableExtension", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GreyCableExtension", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EasementMats", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "EasementMats", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasurementType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DropPipe", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipe", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DropPipeInvertDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasuredFromManhole", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredFromManhole", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MainLined", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MainLined", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BenchingIssue", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BenchingIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ScaledLength1", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength1", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@History", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "History", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NumLats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NumLats", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NotLinedYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotLinedYet", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AllMeasured", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "AllMeasured", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "City", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProvState", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvState", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IssueWithLaterals", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueWithLaterals", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NotMeasuredYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotMeasuredYet", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NotDeliveredYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotDeliveredYet", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_MASTER_AREA] SET [ID] = @ID, [COMPANY_ID] = @COMPANY_ID, [Recor" +
                "dID] = @RecordID, [ClientID] = @ClientID, [COMPANIES_ID] = @COMPANIES_ID, [SubAr" +
                "ea] = @SubArea, [Street] = @Street, [USMH] = @USMH, [DSMH] = @DSMH, [Size_] = @S" +
                "ize_, [ScaledLength] = @ScaledLength, [P1Date] = @P1Date, [ActualLength] = @Actu" +
                "alLength, [LiveLats] = @LiveLats, [CXIsRemoved] = @CXIsRemoved, [M1Date] = @M1Da" +
                "te, [M2Date] = @M2Date, [InstallDate] = @InstallDate, [FinalVideo] = @FinalVideo" +
                ", [Comments] = @Comments, [IssueIdentified] = @IssueIdentified, [IssueResolved] " +
                "= @IssueResolved, [FullLengthLining] = @FullLengthLining, [SubcontractorLining] " +
                "= @SubcontractorLining, [OutOfScopeInArea] = @OutOfScopeInArea, [IssueGivenToBay" +
                "City] = @IssueGivenToBayCity, [ConfirmedSize] = @ConfirmedSize, [InstallRate] = " +
                "@InstallRate, [DeadlineDate] = @DeadlineDate, [ProposedLiningDate] = @ProposedLi" +
                "ningDate, [SalesIssue] = @SalesIssue, [LFSIssue] = @LFSIssue, [ClientIssue] = @C" +
                "lientIssue, [InvestigationIssue] = @InvestigationIssue, [PointLining] = @PointLi" +
                "ning, [Grouting] = @Grouting, [LateralLining] = @LateralLining, [VacExDate] = @V" +
                "acExDate, [PusherDate] = @PusherDate, [LinerOrdered] = @LinerOrdered, [Restorati" +
                "on] = @Restoration, [GroutDate] = @GroutDate, [JLiner] = @JLiner, [RehabAssessme" +
                "nt] = @RehabAssessment, [EstimatedJoints] = @EstimatedJoints, [JointsTestSealed]" +
                " = @JointsTestSealed, [PreFlushDate] = @PreFlushDate, [PreVideoDate] = @PreVideo" +
                "Date, [USMHMN] = @USMHMN, [DSMHMN] = @DSMHMN, [USMHDepth] = @USMHDepth, [DSMHDep" +
                "th] = @DSMHDepth, [MeasurementsTakenBy] = @MeasurementsTakenBy, [SteelTapeThruPi" +
                "pe] = @SteelTapeThruPipe, [USMHAtMouth1200] = @USMHAtMouth1200, [USMHAtMouth100]" +
                " = @USMHAtMouth100, [USMHAtMouth200] = @USMHAtMouth200, [USMHAtMouth300] = @USMH" +
                "AtMouth300, [USMHAtMouth400] = @USMHAtMouth400, [USMHAtMouth500] = @USMHAtMouth5" +
                "00, [DSMHAtMouth1200] = @DSMHAtMouth1200, [DSMHAtMouth100] = @DSMHAtMouth100, [D" +
                "SMHAtMouth200] = @DSMHAtMouth200, [DSMHAtMouth300] = @DSMHAtMouth300, [DSMHAtMou" +
                "th400] = @DSMHAtMouth400, [DSMHAtMouth500] = @DSMHAtMouth500, [HydrantAddress] =" +
                " @HydrantAddress, [DistanceToInversionMH] = @DistanceToInversionMH, [RampsRequir" +
                "ed] = @RampsRequired, [DegreeOfTrafficControl] = @DegreeOfTrafficControl, [Stand" +
                "arBypass] = @StandarBypass, [HydroWireDetails] = @HydroWireDetails, [PipeMateria" +
                "lType] = @PipeMaterialType, [CappedLaterals] = @CappedLaterals, [RoboticPrepRequ" +
                "ired] = @RoboticPrepRequired, [PipeSizeChange] = @PipeSizeChange, [M1Comments] =" +
                " @M1Comments, [VideoDoneFrom] = @VideoDoneFrom, [ToManhole] = @ToManhole, [Cutte" +
                "rDescriptionDuringMeasuring] = @CutterDescriptionDuringMeasuring, [FullLengthPoi" +
                "ntLiner] = @FullLengthPointLiner, [BypassRequired] = @BypassRequired, [RoboticDi" +
                "stances] = @RoboticDistances, [TrafficControlDetails] = @TrafficControlDetails, " +
                "[LineWithID] = @LineWithID, [SchoolZone] = @SchoolZone, [RestaurantArea] = @Rest" +
                "aurantArea, [CarwashLaundromat] = @CarwashLaundromat, [HydroPulley] = @HydroPull" +
                "ey, [FridgeCart] = @FridgeCart, [TwoInchPump] = @TwoInchPump, [SixInchBypass] = " +
                "@SixInchBypass, [Scaffolding] = @Scaffolding, [WinchExtension] = @WinchExtension" +
                ", [ExtraGenerator] = @ExtraGenerator, [GreyCableExtension] = @GreyCableExtension" +
                ", [EasementMats] = @EasementMats, [MeasurementType] = @MeasurementType, [DropPip" +
                "e] = @DropPipe, [DropPipeInvertDepth] = @DropPipeInvertDepth, [Deleted] = @Delet" +
                "ed, [MeasuredFromManhole] = @MeasuredFromManhole, [MainLined] = @MainLined, [Ben" +
                "chingIssue] = @BenchingIssue, [Archived] = @Archived, [ScaledLength1] = @ScaledL" +
                "ength1, [History] = @History, [NumLats] = @NumLats, [NotLinedYet] = @NotLinedYet" +
                ", [AllMeasured] = @AllMeasured, [City] = @City, [ProvState] = @ProvState, [Issue" +
                "WithLaterals] = @IssueWithLaterals, [NotMeasuredYet] = @NotMeasuredYet, [NotDeli" +
                "veredYet] = @NotDeliveredYet WHERE (([ID] = @Original_ID) AND ([COMPANY_ID] = @O" +
                "riginal_COMPANY_ID) AND ([RecordID] = @Original_RecordID) AND ((@IsNull_ClientID" +
                " = 1 AND [ClientID] IS NULL) OR ([ClientID] = @Original_ClientID)) AND ((@IsNull" +
                "_COMPANIES_ID = 1 AND [COMPANIES_ID] IS NULL) OR ([COMPANIES_ID] = @Original_COM" +
                "PANIES_ID)) AND ((@IsNull_SubArea = 1 AND [SubArea] IS NULL) OR ([SubArea] = @Or" +
                "iginal_SubArea)) AND ((@IsNull_Street = 1 AND [Street] IS NULL) OR ([Street] = @" +
                "Original_Street)) AND ((@IsNull_USMH = 1 AND [USMH] IS NULL) OR ([USMH] = @Origi" +
                "nal_USMH)) AND ((@IsNull_DSMH = 1 AND [DSMH] IS NULL) OR ([DSMH] = @Original_DSM" +
                "H)) AND ((@IsNull_Size_ = 1 AND [Size_] IS NULL) OR ([Size_] = @Original_Size_))" +
                " AND ((@IsNull_ScaledLength = 1 AND [ScaledLength] IS NULL) OR ([ScaledLength] =" +
                " @Original_ScaledLength)) AND ((@IsNull_P1Date = 1 AND [P1Date] IS NULL) OR ([P1" +
                "Date] = @Original_P1Date)) AND ((@IsNull_ActualLength = 1 AND [ActualLength] IS " +
                "NULL) OR ([ActualLength] = @Original_ActualLength)) AND ((@IsNull_LiveLats = 1 A" +
                "ND [LiveLats] IS NULL) OR ([LiveLats] = @Original_LiveLats)) AND ((@IsNull_CXIsR" +
                "emoved = 1 AND [CXIsRemoved] IS NULL) OR ([CXIsRemoved] = @Original_CXIsRemoved)" +
                ") AND ((@IsNull_M1Date = 1 AND [M1Date] IS NULL) OR ([M1Date] = @Original_M1Date" +
                ")) AND ((@IsNull_M2Date = 1 AND [M2Date] IS NULL) OR ([M2Date] = @Original_M2Dat" +
                "e)) AND ((@IsNull_InstallDate = 1 AND [InstallDate] IS NULL) OR ([InstallDate] =" +
                " @Original_InstallDate)) AND ((@IsNull_FinalVideo = 1 AND [FinalVideo] IS NULL) " +
                "OR ([FinalVideo] = @Original_FinalVideo)) AND ((@IsNull_IssueIdentified = 1 AND " +
                "[IssueIdentified] IS NULL) OR ([IssueIdentified] = @Original_IssueIdentified)) A" +
                "ND ((@IsNull_IssueResolved = 1 AND [IssueResolved] IS NULL) OR ([IssueResolved] " +
                "= @Original_IssueResolved)) AND ((@IsNull_FullLengthLining = 1 AND [FullLengthLi" +
                "ning] IS NULL) OR ([FullLengthLining] = @Original_FullLengthLining)) AND ((@IsNu" +
                "ll_SubcontractorLining = 1 AND [SubcontractorLining] IS NULL) OR ([Subcontractor" +
                "Lining] = @Original_SubcontractorLining)) AND ((@IsNull_OutOfScopeInArea = 1 AND" +
                " [OutOfScopeInArea] IS NULL) OR ([OutOfScopeInArea] = @Original_OutOfScopeInArea" +
                ")) AND ((@IsNull_IssueGivenToBayCity = 1 AND [IssueGivenToBayCity] IS NULL) OR (" +
                "[IssueGivenToBayCity] = @Original_IssueGivenToBayCity)) AND ((@IsNull_ConfirmedS" +
                "ize = 1 AND [ConfirmedSize] IS NULL) OR ([ConfirmedSize] = @Original_ConfirmedSi" +
                "ze)) AND ((@IsNull_InstallRate = 1 AND [InstallRate] IS NULL) OR ([InstallRate] " +
                "= @Original_InstallRate)) AND ((@IsNull_DeadlineDate = 1 AND [DeadlineDate] IS N" +
                "ULL) OR ([DeadlineDate] = @Original_DeadlineDate)) AND ((@IsNull_ProposedLiningD" +
                "ate = 1 AND [ProposedLiningDate] IS NULL) OR ([ProposedLiningDate] = @Original_P" +
                "roposedLiningDate)) AND ((@IsNull_SalesIssue = 1 AND [SalesIssue] IS NULL) OR ([" +
                "SalesIssue] = @Original_SalesIssue)) AND ((@IsNull_LFSIssue = 1 AND [LFSIssue] I" +
                "S NULL) OR ([LFSIssue] = @Original_LFSIssue)) AND ((@IsNull_ClientIssue = 1 AND " +
                "[ClientIssue] IS NULL) OR ([ClientIssue] = @Original_ClientIssue)) AND ((@IsNull" +
                "_InvestigationIssue = 1 AND [InvestigationIssue] IS NULL) OR ([InvestigationIssu" +
                "e] = @Original_InvestigationIssue)) AND ((@IsNull_PointLining = 1 AND [PointLini" +
                "ng] IS NULL) OR ([PointLining] = @Original_PointLining)) AND ((@IsNull_Grouting " +
                "= 1 AND [Grouting] IS NULL) OR ([Grouting] = @Original_Grouting)) AND ((@IsNull_" +
                "LateralLining = 1 AND [LateralLining] IS NULL) OR ([LateralLining] = @Original_L" +
                "ateralLining)) AND ((@IsNull_VacExDate = 1 AND [VacExDate] IS NULL) OR ([VacExDa" +
                "te] = @Original_VacExDate)) AND ((@IsNull_PusherDate = 1 AND [PusherDate] IS NUL" +
                "L) OR ([PusherDate] = @Original_PusherDate)) AND ((@IsNull_LinerOrdered = 1 AND " +
                "[LinerOrdered] IS NULL) OR ([LinerOrdered] = @Original_LinerOrdered)) AND ((@IsN" +
                "ull_Restoration = 1 AND [Restoration] IS NULL) OR ([Restoration] = @Original_Res" +
                "toration)) AND ((@IsNull_GroutDate = 1 AND [GroutDate] IS NULL) OR ([GroutDate] " +
                "= @Original_GroutDate)) AND ((@IsNull_JLiner = 1 AND [JLiner] IS NULL) OR ([JLin" +
                "er] = @Original_JLiner)) AND ((@IsNull_RehabAssessment = 1 AND [RehabAssessment]" +
                " IS NULL) OR ([RehabAssessment] = @Original_RehabAssessment)) AND ((@IsNull_Esti" +
                "matedJoints = 1 AND [EstimatedJoints] IS NULL) OR ([EstimatedJoints] = @Original" +
                "_EstimatedJoints)) AND ((@IsNull_JointsTestSealed = 1 AND [JointsTestSealed] IS " +
                "NULL) OR ([JointsTestSealed] = @Original_JointsTestSealed)) AND ((@IsNull_PreFlu" +
                "shDate = 1 AND [PreFlushDate] IS NULL) OR ([PreFlushDate] = @Original_PreFlushDa" +
                "te)) AND ((@IsNull_PreVideoDate = 1 AND [PreVideoDate] IS NULL) OR ([PreVideoDat" +
                "e] = @Original_PreVideoDate)) AND ((@IsNull_USMHMN = 1 AND [USMHMN] IS NULL) OR " +
                "([USMHMN] = @Original_USMHMN)) AND ((@IsNull_DSMHMN = 1 AND [DSMHMN] IS NULL) OR" +
                " ([DSMHMN] = @Original_DSMHMN)) AND ((@IsNull_USMHDepth = 1 AND [USMHDepth] IS N" +
                "ULL) OR ([USMHDepth] = @Original_USMHDepth)) AND ((@IsNull_DSMHDepth = 1 AND [DS" +
                "MHDepth] IS NULL) OR ([DSMHDepth] = @Original_DSMHDepth)) AND ((@IsNull_Measurem" +
                "entsTakenBy = 1 AND [MeasurementsTakenBy] IS NULL) OR ([MeasurementsTakenBy] = @" +
                "Original_MeasurementsTakenBy)) AND ((@IsNull_SteelTapeThruPipe = 1 AND [SteelTap" +
                "eThruPipe] IS NULL) OR ([SteelTapeThruPipe] = @Original_SteelTapeThruPipe)) AND " +
                "((@IsNull_USMHAtMouth1200 = 1 AND [USMHAtMouth1200] IS NULL) OR ([USMHAtMouth120" +
                "0] = @Original_USMHAtMouth1200)) AND ((@IsNull_USMHAtMouth100 = 1 AND [USMHAtMou" +
                "th100] IS NULL) OR ([USMHAtMouth100] = @Original_USMHAtMouth100)) AND ((@IsNull_" +
                "USMHAtMouth200 = 1 AND [USMHAtMouth200] IS NULL) OR ([USMHAtMouth200] = @Origina" +
                "l_USMHAtMouth200)) AND ((@IsNull_USMHAtMouth300 = 1 AND [USMHAtMouth300] IS NULL" +
                ") OR ([USMHAtMouth300] = @Original_USMHAtMouth300)) AND ((@IsNull_USMHAtMouth400" +
                " = 1 AND [USMHAtMouth400] IS NULL) OR ([USMHAtMouth400] = @Original_USMHAtMouth4" +
                "00)) AND ((@IsNull_USMHAtMouth500 = 1 AND [USMHAtMouth500] IS NULL) OR ([USMHAtM" +
                "outh500] = @Original_USMHAtMouth500)) AND ((@IsNull_DSMHAtMouth1200 = 1 AND [DSM" +
                "HAtMouth1200] IS NULL) OR ([DSMHAtMouth1200] = @Original_DSMHAtMouth1200)) AND (" +
                "(@IsNull_DSMHAtMouth100 = 1 AND [DSMHAtMouth100] IS NULL) OR ([DSMHAtMouth100] =" +
                " @Original_DSMHAtMouth100)) AND ((@IsNull_DSMHAtMouth200 = 1 AND [DSMHAtMouth200" +
                "] IS NULL) OR ([DSMHAtMouth200] = @Original_DSMHAtMouth200)) AND ((@IsNull_DSMHA" +
                "tMouth300 = 1 AND [DSMHAtMouth300] IS NULL) OR ([DSMHAtMouth300] = @Original_DSM" +
                "HAtMouth300)) AND ((@IsNull_DSMHAtMouth400 = 1 AND [DSMHAtMouth400] IS NULL) OR " +
                "([DSMHAtMouth400] = @Original_DSMHAtMouth400)) AND ((@IsNull_DSMHAtMouth500 = 1 " +
                "AND [DSMHAtMouth500] IS NULL) OR ([DSMHAtMouth500] = @Original_DSMHAtMouth500)) " +
                "AND ((@IsNull_HydrantAddress = 1 AND [HydrantAddress] IS NULL) OR ([HydrantAddre" +
                "ss] = @Original_HydrantAddress)) AND ((@IsNull_DistanceToInversionMH = 1 AND [Di" +
                "stanceToInversionMH] IS NULL) OR ([DistanceToInversionMH] = @Original_DistanceTo" +
                "InversionMH)) AND ((@IsNull_RampsRequired = 1 AND [RampsRequired] IS NULL) OR ([" +
                "RampsRequired] = @Original_RampsRequired)) AND ((@IsNull_DegreeOfTrafficControl " +
                "= 1 AND [DegreeOfTrafficControl] IS NULL) OR ([DegreeOfTrafficControl] = @Origin" +
                "al_DegreeOfTrafficControl)) AND ((@IsNull_StandarBypass = 1 AND [StandarBypass] " +
                "IS NULL) OR ([StandarBypass] = @Original_StandarBypass)) AND ((@IsNull_HydroWire" +
                "Details = 1 AND [HydroWireDetails] IS NULL) OR ([HydroWireDetails] = @Original_H" +
                "ydroWireDetails)) AND ((@IsNull_PipeMaterialType = 1 AND [PipeMaterialType] IS N" +
                "ULL) OR ([PipeMaterialType] = @Original_PipeMaterialType)) AND ((@IsNull_CappedL" +
                "aterals = 1 AND [CappedLaterals] IS NULL) OR ([CappedLaterals] = @Original_Cappe" +
                "dLaterals)) AND ((@IsNull_RoboticPrepRequired = 1 AND [RoboticPrepRequired] IS N" +
                "ULL) OR ([RoboticPrepRequired] = @Original_RoboticPrepRequired)) AND ((@IsNull_P" +
                "ipeSizeChange = 1 AND [PipeSizeChange] IS NULL) OR ([PipeSizeChange] = @Original" +
                "_PipeSizeChange)) AND ((@IsNull_VideoDoneFrom = 1 AND [VideoDoneFrom] IS NULL) O" +
                "R ([VideoDoneFrom] = @Original_VideoDoneFrom)) AND ((@IsNull_ToManhole = 1 AND [" +
                "ToManhole] IS NULL) OR ([ToManhole] = @Original_ToManhole)) AND ((@IsNull_Cutter" +
                "DescriptionDuringMeasuring = 1 AND [CutterDescriptionDuringMeasuring] IS NULL) O" +
                "R ([CutterDescriptionDuringMeasuring] = @Original_CutterDescriptionDuringMeasuri" +
                "ng)) AND ((@IsNull_FullLengthPointLiner = 1 AND [FullLengthPointLiner] IS NULL) " +
                "OR ([FullLengthPointLiner] = @Original_FullLengthPointLiner)) AND ((@IsNull_Bypa" +
                "ssRequired = 1 AND [BypassRequired] IS NULL) OR ([BypassRequired] = @Original_By" +
                "passRequired)) AND ((@IsNull_RoboticDistances = 1 AND [RoboticDistances] IS NULL" +
                ") OR ([RoboticDistances] = @Original_RoboticDistances)) AND ((@IsNull_LineWithID" +
                " = 1 AND [LineWithID] IS NULL) OR ([LineWithID] = @Original_LineWithID)) AND ((@" +
                "IsNull_SchoolZone = 1 AND [SchoolZone] IS NULL) OR ([SchoolZone] = @Original_Sch" +
                "oolZone)) AND ((@IsNull_RestaurantArea = 1 AND [RestaurantArea] IS NULL) OR ([Re" +
                "staurantArea] = @Original_RestaurantArea)) AND ((@IsNull_CarwashLaundromat = 1 A" +
                "ND [CarwashLaundromat] IS NULL) OR ([CarwashLaundromat] = @Original_CarwashLaund" +
                "romat)) AND ((@IsNull_HydroPulley = 1 AND [HydroPulley] IS NULL) OR ([HydroPulle" +
                "y] = @Original_HydroPulley)) AND ((@IsNull_FridgeCart = 1 AND [FridgeCart] IS NU" +
                "LL) OR ([FridgeCart] = @Original_FridgeCart)) AND ((@IsNull_TwoInchPump = 1 AND " +
                "[TwoInchPump] IS NULL) OR ([TwoInchPump] = @Original_TwoInchPump)) AND ((@IsNull" +
                "_SixInchBypass = 1 AND [SixInchBypass] IS NULL) OR ([SixInchBypass] = @Original_" +
                "SixInchBypass)) AND ((@IsNull_Scaffolding = 1 AND [Scaffolding] IS NULL) OR ([Sc" +
                "affolding] = @Original_Scaffolding)) AND ((@IsNull_WinchExtension = 1 AND [Winch" +
                "Extension] IS NULL) OR ([WinchExtension] = @Original_WinchExtension)) AND ((@IsN" +
                "ull_ExtraGenerator = 1 AND [ExtraGenerator] IS NULL) OR ([ExtraGenerator] = @Ori" +
                "ginal_ExtraGenerator)) AND ((@IsNull_GreyCableExtension = 1 AND [GreyCableExtens" +
                "ion] IS NULL) OR ([GreyCableExtension] = @Original_GreyCableExtension)) AND ((@I" +
                "sNull_EasementMats = 1 AND [EasementMats] IS NULL) OR ([EasementMats] = @Origina" +
                "l_EasementMats)) AND ((@IsNull_MeasurementType = 1 AND [MeasurementType] IS NULL" +
                ") OR ([MeasurementType] = @Original_MeasurementType)) AND ((@IsNull_DropPipe = 1" +
                " AND [DropPipe] IS NULL) OR ([DropPipe] = @Original_DropPipe)) AND ((@IsNull_Dro" +
                "pPipeInvertDepth = 1 AND [DropPipeInvertDepth] IS NULL) OR ([DropPipeInvertDepth" +
                "] = @Original_DropPipeInvertDepth)) AND ((@IsNull_Deleted = 1 AND [Deleted] IS N" +
                "ULL) OR ([Deleted] = @Original_Deleted)) AND ((@IsNull_MeasuredFromManhole = 1 A" +
                "ND [MeasuredFromManhole] IS NULL) OR ([MeasuredFromManhole] = @Original_Measured" +
                "FromManhole)) AND ((@IsNull_MainLined = 1 AND [MainLined] IS NULL) OR ([MainLine" +
                "d] = @Original_MainLined)) AND ((@IsNull_BenchingIssue = 1 AND [BenchingIssue] I" +
                "S NULL) OR ([BenchingIssue] = @Original_BenchingIssue)) AND ((@IsNull_Archived =" +
                " 1 AND [Archived] IS NULL) OR ([Archived] = @Original_Archived)) AND ((@IsNull_S" +
                "caledLength1 = 1 AND [ScaledLength1] IS NULL) OR ([ScaledLength1] = @Original_Sc" +
                "aledLength1)) AND ((@IsNull_NumLats = 1 AND [NumLats] IS NULL) OR ([NumLats] = @" +
                "Original_NumLats)) AND ((@IsNull_NotLinedYet = 1 AND [NotLinedYet] IS NULL) OR (" +
                "[NotLinedYet] = @Original_NotLinedYet)) AND ((@IsNull_AllMeasured = 1 AND [AllMe" +
                "asured] IS NULL) OR ([AllMeasured] = @Original_AllMeasured)) AND ((@IsNull_City " +
                "= 1 AND [City] IS NULL) OR ([City] = @Original_City)) AND ((@IsNull_ProvState = " +
                "1 AND [ProvState] IS NULL) OR ([ProvState] = @Original_ProvState)) AND ([IssueWi" +
                "thLaterals] = @Original_IssueWithLaterals) AND ((@IsNull_NotMeasuredYet = 1 AND " +
                "[NotMeasuredYet] IS NULL) OR ([NotMeasuredYet] = @Original_NotMeasuredYet)) AND " +
                "((@IsNull_NotDeliveredYet = 1 AND [NotDeliveredYet] IS NULL) OR ([NotDeliveredYe" +
                "t] = @Original_NotDeliveredYet)));\r\nSELECT ID, COMPANY_ID, RecordID, ClientID, C" +
                "OMPANIES_ID, SubArea, Street, USMH, DSMH, Size_, ScaledLength, P1Date, ActualLen" +
                "gth, LiveLats, CXIsRemoved, M1Date, M2Date, InstallDate, FinalVideo, Comments, I" +
                "ssueIdentified, IssueResolved, FullLengthLining, SubcontractorLining, OutOfScope" +
                "InArea, IssueGivenToBayCity, ConfirmedSize, InstallRate, DeadlineDate, ProposedL" +
                "iningDate, SalesIssue, LFSIssue, ClientIssue, InvestigationIssue, PointLining, G" +
                "routing, LateralLining, VacExDate, PusherDate, LinerOrdered, Restoration, GroutD" +
                "ate, JLiner, RehabAssessment, EstimatedJoints, JointsTestSealed, PreFlushDate, P" +
                "reVideoDate, USMHMN, DSMHMN, USMHDepth, DSMHDepth, MeasurementsTakenBy, SteelTap" +
                "eThruPipe, USMHAtMouth1200, USMHAtMouth100, USMHAtMouth200, USMHAtMouth300, USMH" +
                "AtMouth400, USMHAtMouth500, DSMHAtMouth1200, DSMHAtMouth100, DSMHAtMouth200, DSM" +
                "HAtMouth300, DSMHAtMouth400, DSMHAtMouth500, HydrantAddress, DistanceToInversion" +
                "MH, RampsRequired, DegreeOfTrafficControl, StandarBypass, HydroWireDetails, Pipe" +
                "MaterialType, CappedLaterals, RoboticPrepRequired, PipeSizeChange, M1Comments, V" +
                "ideoDoneFrom, ToManhole, CutterDescriptionDuringMeasuring, FullLengthPointLiner," +
                " BypassRequired, RoboticDistances, TrafficControlDetails, LineWithID, SchoolZone" +
                ", RestaurantArea, CarwashLaundromat, HydroPulley, FridgeCart, TwoInchPump, SixIn" +
                "chBypass, Scaffolding, WinchExtension, ExtraGenerator, GreyCableExtension, Easem" +
                "entMats, MeasurementType, DropPipe, DropPipeInvertDepth, Deleted, MeasuredFromMa" +
                "nhole, MainLined, BenchingIssue, Archived, ScaledLength1, History, NumLats, NotL" +
                "inedYet, AllMeasured, City, ProvState, IssueWithLaterals, NotMeasuredYet, NotDel" +
                "iveredYet FROM LFS_MASTER_AREA WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RecordID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RecordID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANIES_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SubArea", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SubArea", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Street", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Street", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Size_", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Size_", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ScaledLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@P1Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "P1Date", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ActualLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ActualLength", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LiveLats", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveLats", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CXIsRemoved", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@M1Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "M1Date", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@M2Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "M2Date", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InstallDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FinalVideo", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "Comments", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IssueIdentified", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IssueResolved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FullLengthLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthLining", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SubcontractorLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SubcontractorLining", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OutOfScopeInArea", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "OutOfScopeInArea", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IssueGivenToBayCity", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToBayCity", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ConfirmedSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedSize", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InstallRate", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallRate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DeadlineDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DeadlineDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProposedLiningDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SalesIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SalesIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LFSIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LFSIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InvestigationIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "InvestigationIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PointLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PointLining", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Grouting", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouting", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LateralLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralLining", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VacExDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "VacExDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PusherDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PusherDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerOrdered", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Restoration", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Restoration", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GroutDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "GroutDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JLiner", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "JLiner", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RehabAssessment", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RehabAssessment", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EstimatedJoints", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JointsTestSealed", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PreFlushDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PreVideoDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHMN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHMN", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHMN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHMN", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasurementsTakenBy", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SteelTapeThruPipe", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThruPipe", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth1200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth1200", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth100", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth100", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth200", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth300", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth300", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth400", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth400", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth500", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth500", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth1200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth1200", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth100", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth100", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth200", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth300", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth300", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth400", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth400", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth500", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth500", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HydrantAddress", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceToInversionMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RampsRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RampsRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DegreeOfTrafficControl", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DegreeOfTrafficControl", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StandarBypass", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "StandarBypass", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HydroWireDetails", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroWireDetails", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PipeMaterialType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeMaterialType", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CappedLaterals", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RoboticPrepRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PipeSizeChange", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeSizeChange", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@M1Comments", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "M1Comments", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VideoDoneFrom", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFrom", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ToManhole", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ToManhole", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CutterDescriptionDuringMeasuring", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CutterDescriptionDuringMeasuring", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FullLengthPointLiner", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthPointLiner", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BypassRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "BypassRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RoboticDistances", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TrafficControlDetails", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "TrafficControlDetails", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LineWithID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LineWithID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SchoolZone", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SchoolZone", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RestaurantArea", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RestaurantArea", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CarwashLaundromat", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CarwashLaundromat", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HydroPulley", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroPulley", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FridgeCart", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FridgeCart", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TwoInchPump", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "TwoInchPump", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SixInchBypass", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SixInchBypass", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Scaffolding", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Scaffolding", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@WinchExtension", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "WinchExtension", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExtraGenerator", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraGenerator", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GreyCableExtension", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GreyCableExtension", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EasementMats", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "EasementMats", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasurementType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DropPipe", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipe", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DropPipeInvertDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasuredFromManhole", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredFromManhole", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MainLined", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MainLined", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BenchingIssue", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BenchingIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ScaledLength1", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength1", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@History", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "History", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NumLats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NumLats", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NotLinedYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotLinedYet", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AllMeasured", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "AllMeasured", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "City", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProvState", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvState", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IssueWithLaterals", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueWithLaterals", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NotMeasuredYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotMeasuredYet", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NotDeliveredYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotDeliveredYet", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RecordID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RecordID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ClientID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_COMPANIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANIES_ID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANIES_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SubArea", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SubArea", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SubArea", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SubArea", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Street", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Street", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Street", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Street", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Size_", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Size_", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Size_", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Size_", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ScaledLength", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ScaledLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_P1Date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "P1Date", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_P1Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "P1Date", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ActualLength", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ActualLength", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ActualLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ActualLength", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LiveLats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveLats", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LiveLats", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveLats", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CXIsRemoved", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CXIsRemoved", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_M1Date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "M1Date", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_M1Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "M1Date", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_M2Date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "M2Date", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_M2Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "M2Date", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InstallDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InstallDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FinalVideo", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FinalVideo", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_IssueIdentified", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IssueIdentified", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_IssueResolved", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IssueResolved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FullLengthLining", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthLining", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FullLengthLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthLining", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SubcontractorLining", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SubcontractorLining", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SubcontractorLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SubcontractorLining", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_OutOfScopeInArea", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "OutOfScopeInArea", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OutOfScopeInArea", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "OutOfScopeInArea", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_IssueGivenToBayCity", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToBayCity", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IssueGivenToBayCity", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToBayCity", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ConfirmedSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedSize", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ConfirmedSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedSize", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InstallRate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallRate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InstallRate", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallRate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DeadlineDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DeadlineDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DeadlineDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DeadlineDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ProposedLiningDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProposedLiningDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SalesIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SalesIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SalesIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SalesIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LFSIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LFSIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LFSIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LFSIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ClientIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InvestigationIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InvestigationIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InvestigationIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "InvestigationIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PointLining", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PointLining", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PointLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PointLining", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Grouting", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouting", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Grouting", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouting", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LateralLining", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralLining", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LateralLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralLining", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_VacExDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "VacExDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VacExDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "VacExDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PusherDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PusherDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PusherDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PusherDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerOrdered", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerOrdered", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Restoration", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Restoration", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Restoration", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Restoration", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_GroutDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "GroutDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GroutDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "GroutDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_JLiner", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "JLiner", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_JLiner", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "JLiner", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RehabAssessment", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RehabAssessment", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RehabAssessment", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RehabAssessment", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_EstimatedJoints", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EstimatedJoints", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_JointsTestSealed", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_JointsTestSealed", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PreFlushDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PreFlushDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PreVideoDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PreVideoDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHMN", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHMN", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHMN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHMN", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHMN", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHMN", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHMN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHMN", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHDepth", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHDepth", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MeasurementsTakenBy", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasurementsTakenBy", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SteelTapeThruPipe", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThruPipe", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SteelTapeThruPipe", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThruPipe", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth1200", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth1200", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth1200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth1200", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth100", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth100", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth100", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth100", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth200", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth200", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth200", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth300", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth300", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth300", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth300", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth400", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth400", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth400", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth400", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth500", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth500", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth500", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth500", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth1200", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth1200", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth1200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth1200", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth100", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth100", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth100", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth100", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth200", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth200", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth200", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth300", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth300", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth300", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth300", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth400", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth400", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth400", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth400", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth500", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth500", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth500", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth500", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_HydrantAddress", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HydrantAddress", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DistanceToInversionMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceToInversionMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RampsRequired", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RampsRequired", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RampsRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RampsRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DegreeOfTrafficControl", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DegreeOfTrafficControl", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DegreeOfTrafficControl", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DegreeOfTrafficControl", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_StandarBypass", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "StandarBypass", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_StandarBypass", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "StandarBypass", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_HydroWireDetails", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroWireDetails", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HydroWireDetails", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroWireDetails", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PipeMaterialType", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeMaterialType", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PipeMaterialType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeMaterialType", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CappedLaterals", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CappedLaterals", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RoboticPrepRequired", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepRequired", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RoboticPrepRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PipeSizeChange", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeSizeChange", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PipeSizeChange", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeSizeChange", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_VideoDoneFrom", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFrom", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VideoDoneFrom", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFrom", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ToManhole", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ToManhole", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ToManhole", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ToManhole", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CutterDescriptionDuringMeasuring", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CutterDescriptionDuringMeasuring", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CutterDescriptionDuringMeasuring", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CutterDescriptionDuringMeasuring", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FullLengthPointLiner", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthPointLiner", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FullLengthPointLiner", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthPointLiner", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BypassRequired", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BypassRequired", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BypassRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "BypassRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RoboticDistances", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RoboticDistances", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LineWithID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LineWithID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LineWithID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LineWithID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SchoolZone", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SchoolZone", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SchoolZone", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SchoolZone", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RestaurantArea", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RestaurantArea", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RestaurantArea", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RestaurantArea", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CarwashLaundromat", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CarwashLaundromat", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CarwashLaundromat", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CarwashLaundromat", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_HydroPulley", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroPulley", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HydroPulley", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroPulley", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FridgeCart", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FridgeCart", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FridgeCart", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FridgeCart", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_TwoInchPump", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "TwoInchPump", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_TwoInchPump", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "TwoInchPump", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SixInchBypass", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SixInchBypass", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SixInchBypass", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SixInchBypass", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Scaffolding", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Scaffolding", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Scaffolding", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Scaffolding", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_WinchExtension", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "WinchExtension", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_WinchExtension", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "WinchExtension", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ExtraGenerator", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraGenerator", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExtraGenerator", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraGenerator", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_GreyCableExtension", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "GreyCableExtension", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GreyCableExtension", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GreyCableExtension", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_EasementMats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EasementMats", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EasementMats", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "EasementMats", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MeasurementType", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasurementType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DropPipe", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipe", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DropPipe", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipe", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DropPipeInvertDepth", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DropPipeInvertDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Deleted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MeasuredFromManhole", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredFromManhole", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasuredFromManhole", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredFromManhole", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MainLined", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MainLined", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MainLined", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MainLined", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BenchingIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BenchingIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BenchingIssue", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BenchingIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Archived", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ScaledLength1", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength1", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ScaledLength1", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength1", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_NumLats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NumLats", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NumLats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NumLats", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_NotLinedYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotLinedYet", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NotLinedYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotLinedYet", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_AllMeasured", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AllMeasured", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AllMeasured", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "AllMeasured", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_City", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "City", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "City", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ProvState", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvState", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProvState", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvState", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IssueWithLaterals", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueWithLaterals", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_NotMeasuredYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotMeasuredYet", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NotMeasuredYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotMeasuredYet", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_NotDeliveredYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotDeliveredYet", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NotDeliveredYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotDeliveredYet", System.Data.DataRowVersion.Original, false, null, "", "", ""));


            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <returns>Data</returns>
        public void Load()
        {
            string commandText = String.Format("SELECT * FROM LFS_MASTER_AREA MA WHERE ((CAST(ID AS nvarchar(50)) + ' - ' + CAST(COMPANY_ID AS nvarchar(4))) IN (SELECT CAST(JL.ID AS nvarchar(50)) + ' - ' + CAST(JL.COMPANY_ID AS nvarchar(4)) FROM LFS_JUNCTION_LINER2 AS JL))");
            FillData(commandText);

        }
        

        
        /// <summary>
        /// Update - JLiner
        /// </summary>
        public void Update()
        {
            Fix1JlinerGateway jlinerGateway = new Fix1JlinerGateway(Data);

            DataTable sectionChanges = Table.GetChanges();

            if (sectionChanges == null ) return;

            try
            {
                DB.Open();
                DB.BeginTransaction();

                Adapter.InsertCommand.Transaction = DB.Transaction;
                Adapter.UpdateCommand.Transaction = DB.Transaction;
                Adapter.DeleteCommand.Transaction = DB.Transaction;

                if ((sectionChanges != null) && (sectionChanges.Rows.Count > 0))
                {
                    Adapter.Update(sectionChanges);
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



        /// <summary>
        /// InitializeAllSections
        /// </summary>
        public void InitializeAllSections()
        {
            string commandText = String.Format("UPDATE LFS_MASTER_AREA SET  NumLats = 0, NotLinedYet = 0, AllMeasured = 0, NotMeasuredYet = 0, NotDeliveredYet = 0");
            FillData(commandText);        
        }


        
    }
}
