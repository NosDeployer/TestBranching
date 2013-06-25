using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Jliner;

namespace LiquiForce.LFSLive.DA.CWP.Section
{
    /// <summary>
    /// SectionGateway
    /// </summary>
    public class SectionGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SectionGateway()
            : base("LFS_MASTER_AREA")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SectionGateway(DataSet data)
            : base(data, "LFS_MASTER_AREA")
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
        /// LoadById
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadById(Guid id, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_SECTIONGATEWAY_LOADBYID", new SqlParameter("@id", id), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_SECTIONGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByRecordId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="recordId">RecordId - ID for users</param>
        /// <returns>Data</returns>
        public DataSet LoadByRecordId(int companyId, string recordId)
        {
            FillDataWithStoredProcedure("LFS_CWP_SECTIONGATEWAY_LOADBYRECORDID", new SqlParameter("@companyId", companyId), new SqlParameter("@recordId", recordId));
            return Data;
        }               
                


        /// <summary>
        ///  Get a single section. If not exists, raise an exception.
        /// </summary>
        /// <param name="recordId">RecordID</param>
        /// <returns>Row obtained</returns>
        public DataRow GetRow(string recordId)
        {
            string filter = string.Format("RecordID = '{0}'", recordId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Section.SectionGateway.GetRow");
            } 
        }



        /// <summary>
        /// Get a single section. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">Guid ID</param>
        /// <returns>Row obtained</returns>
        public DataRow GetRow(Guid id)
        {
            string filter = string.Format("ID = '{0}'", id);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Section.SectionGateway.GetRow");
            }
        }



        /// <summary>
        /// GetID
        /// </summary>
        /// <param name="recordId">RecordID</param>
        /// <returns>ID</returns>
        public Guid GetId(string recordId)
        {
            return (Guid)GetRow(recordId)["ID"];
        }



        /// <summary>
        /// GetRecordId
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <returns>Record Id</returns>
        public string GetRecordId(Guid id)
        {
            return (string)GetRow(id)["RecordID"];
        }



        /// <summary>
        /// GetStreet
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <returns>Street or EMPTY</returns>
        public string GetStreet(Guid id)
        {
            if (GetRow(id).IsNull("Street"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id)["Street"];
            }
        }




        /// <summary>
        /// GetUSMH
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <returns>USMH or EMPTY</returns>
        public string GetUSMH(Guid id)
        {
            if (GetRow(id).IsNull("USMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id)["USMH"];
            }
        }




        /// <summary>
        /// GetDSMH
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <returns>DSMH or EMPTY</returns>
        public string GetDSMH(Guid id)
        {
            if (GetRow(id).IsNull("DSMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id)["DSMH"];
            }
        }



        /// <summary>
        /// GetActualLength
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Actual Length or EMPTY</returns>
        public string GetActualLength(Guid id)
        {
            if (GetRow(id).IsNull("ActualLength"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id)["ActualLength"];
            }
        }



        /// <summary>
        /// GetNotLinedYet
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <returns>Not Lined Yet or EMPTY</returns>
        public int? GetNotLinedYet(Guid id)
        {
            if (GetRow(id).IsNull("NotLinedYet"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id)["NotLinedYet"];
            }
        }
        


        /// <summary>
        /// GetNotDeliveredYet
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <returns>Not Delivered Yet or EMPTY</returns>
        public int? GetNotDeliveredYet(Guid id)
        {
            if (GetRow(id).IsNull("NotDeliveredYet"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id)["NotDeliveredYet"];
            }
        }



        /// <summary>
        /// AllMeasured
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <returns>AllMeasured</returns>
        public bool AllMeasured(Guid id)
        {
            return (bool)GetRow(id)["AllMeasured"];
        }



        /// <summary>
        /// Update - JLiner
        /// </summary>
        public void Update()
        {
            JlinerGateway jlinerGateway = new JlinerGateway(Data);
            JlinerCommentGateway jlinerCommentGateway = new JlinerCommentGateway(Data);

            DataTable sectionChanges = Table.GetChanges();
            DataTable jlinerChanges = jlinerGateway.Table.GetChanges();
            DataTable jlinerCommentChanges = jlinerCommentGateway.Table.GetChanges();

            if ((sectionChanges == null) && (jlinerChanges == null) && (jlinerCommentChanges == null)) return;

            try
            {
                DB.Open();
                DB.BeginTransaction();

                Adapter.InsertCommand.Transaction = DB.Transaction;
                Adapter.UpdateCommand.Transaction = DB.Transaction;
                Adapter.DeleteCommand.Transaction = DB.Transaction;

                jlinerGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                jlinerGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                jlinerGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                jlinerCommentGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                jlinerCommentGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                jlinerCommentGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                if ((sectionChanges != null) && (sectionChanges.Rows.Count > 0))
                {
                    Adapter.Update(sectionChanges);
                }

                if ((jlinerChanges != null) && (jlinerChanges.Rows.Count > 0))
                {
                    jlinerGateway.Adapter.Update(jlinerChanges);
                }

                if ((jlinerCommentChanges != null) && (jlinerCommentChanges.Rows.Count > 0))
                {
                    jlinerCommentGateway.Adapter.Update(jlinerCommentChanges);
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
        /// Update - IssueWithLaterals field
        /// </summary>
        public void Update2()
        {
            DataTable sectionChanges = Table.GetChanges();

            if (sectionChanges == null) return;

            try
            {
                if ((sectionChanges != null) && (sectionChanges.Rows.Count > 0))
                {
                    Adapter.Update(sectionChanges);
                }
            }
            catch (DBConcurrencyException dBConcurrencyException)
            {
                DB.RollbackTransaction();
                throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
            }
            catch (SqlException sqlException)
            {
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
                throw new Exception("Unknow error. Your operation has been cancelled.", e);
            }
            finally
            {
                DB.Close();
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Update direct
        /// </summary>
        /// <param name="originalId">originalId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalRecordId">originalRecordId</param>        
        /// <param name="originalClientId">originalClientId</param>        
        /// <param name="originalCompaniesId">originalCompaniesId</param>
        /// <param name="originalSubArea">originalSubArea</param>
        /// <param name="originalStreet">originalStreet</param>
        /// <param name="originalUSMH">originalUSMH</param>
        /// <param name="originalDSMH">originalDSMH</param>
        /// <param name="originalSize_">originalSize_</param>
        /// <param name="originalScaledLength">originalScaledLength</param>
        /// <param name="originalP1Date">originalP1Date</param>
        /// <param name="originalActualLength">originalActualLength</param>
        /// <param name="originalLiveLats">originalLiveLats</param>
        /// <param name="originalCXIsRemoved">originalCXIsRemoved</param>
        /// <param name="originalM1Date">originalM1Date</param>
        /// <param name="originalM2Date">originalM2Date</param>
        /// <param name="originalInstallDate">originalInstallDate</param>
        /// <param name="originalFinalVideo">originalFinalVideo</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalIssueIdentified">originalIssueIdentified</param>
        /// <param name="originalIssueResolved">originalIssueResolved</param>
        /// <param name="originalFullLengthLining">originalFullLengthLining</param>
        /// <param name="originalSubcontractorLining">originalSubcontractorLining</param>
        /// <param name="originalOutOfScopeInArea">originalOutOfScopeInArea</param>
        /// <param name="originalIssueGivenToBayCity">originalIssueGivenToBayCity</param>
        /// <param name="originalConfirmedSize">originalConfirmedSize</param>
        /// <param name="originalInstallRate">originalInstallRate</param>
        /// <param name="originalDeadlineDate">originalDeadlineDate</param>
        /// <param name="originalProposedLiningDate">originalProposedLiningDate</param>
        /// <param name="originalSalesIssue">originalSalesIssue</param>
        /// <param name="originalLFSIssue">originalLFSIssue</param>
        /// <param name="originalClientIssue">originalClientIssue</param>
        /// <param name="originalInvestigationIssue">originalInvestigationIssue</param>
        /// <param name="originalPointLining">originalPointLining</param>
        /// <param name="originalGrouting">originalGrouting</param>
        /// <param name="originalLateralLining">originalLateralLining</param>
        /// <param name="originalVacExDate">originalVacExDateParameter</param>
        /// <param name="originalPusherDate">originalPusherDate</param>
        /// <param name="originalLinerOrdered">originalLinerOrdered</param>
        /// <param name="originalRestoration">originalRestoration</param>
        /// <param name="originalGroutDate">originalGroutDate</param>
        /// <param name="originalJLiner">originalJLiner</param>
        /// <param name="originalRehabAssessment">originalRehabAssessment</param>
        /// <param name="originalEstimatedJoints">originalEstimatedJoints</param>
        /// <param name="originalJointsTestSealed">originalJointsTestSealed</param>
        /// <param name="originalPreFlushDate">originalPreFlushDate</param>
        /// <param name="originalPreVideoDate">originalPreVideoDate</param>
        /// <param name="originalUSMHMN">originalUSMHMN</param>
        /// <param name="originalDSMHMN">originalDSMHMN</param>
        /// <param name="originalUSMHDepth">originalUSMHDepth</param>
        /// <param name="originalDSMHDepth">originalDSMHDepth</param>
        /// <param name="originalMeasurementsTakenBy">originalMeasurementsTakenBy</param>
        /// <param name="originalSteelTapeThruPipe">originalSteelTapeThruPipe</param>
        /// <param name="originalUSMHAtMouth1200">originalUSMHAtMouth1200</param>
        /// <param name="originalUSMHAtMouth100">originalUSMHAtMouth100</param>
        /// <param name="originalUSMHAtMouth200">originalUSMHAtMouth200</param>
        /// <param name="originalUSMHAtMouth300">originalUSMHAtMouth300</param>
        /// <param name="originalUSMHAtMouth400">originalUSMHAtMouth400</param>
        /// <param name="originalUSMHAtMouth500">originalUSMHAtMouth500</param>
        /// <param name="originalDSMHAtMouth1200">originalDSMHAtMouth1200</param>
        /// <param name="originalDSMHAtMouth100">originalDSMHAtMouth100</param>
        /// <param name="originalDSMHAtMouth200">originalDSMHAtMouth200</param>
        /// <param name="originalDSMHAtMouth300">originalDSMHAtMouth300</param>
        /// <param name="originalDSMHAtMouth400">originalDSMHAtMouth400</param>
        /// <param name="originalDSMHAtMouth500">originalDSMHAtMouth500</param>
        /// <param name="originalHydrantAddress">originalHydrantAddress</param>
        /// <param name="originalDistanceToInversionMH">originalDistanceToInversionMH</param>
        /// <param name="originalRampsRequired">originalRampsRequired</param>
        /// <param name="originalDegreeOfTrafficControl">originalDegreeOfTrafficControl</param>
        /// <param name="originalStandarBypass">originalStandarBypass</param>
        /// <param name="originalHydroWireDetails">originalHydroWireDetails</param>
        /// <param name="originalPipeMaterialType">originalPipeMaterialType</param>
        /// <param name="originalCappedLaterals">originalCappedLaterals</param>
        /// <param name="originalRoboticPrepRequired">originalRoboticPrepRequired</param>
        /// <param name="originalPipeSizeChange">originalPipeSizeChange</param>
        /// <param name="originalM1Comments">originalM1Comments</param>
        /// <param name="originalVideoDoneFrom">originalVideoDoneFrom</param>
        /// <param name="originalToManhole">originalToManhole</param>
        /// <param name="originalCutterDescriptionDuringMeasuring">originalCutterDescriptionDuringMeasuring</param>
        /// <param name="originalFullLengthPointLiner">originalFullLengthPointLiner</param>
        /// <param name="originalBypassRequired">originalBypassRequired</param>
        /// <param name="originalRoboticDistances">originalRoboticDistances</param>
        /// <param name="originalTrafficControlDetails">originalTrafficControlDetails</param>
        /// <param name="originalLineWithID">originalLineWithID</param>
        /// <param name="originalSchoolZone">originalSchoolZone</param>
        /// <param name="originalRestaurantArea">originalRestaurantArea</param>
        /// <param name="originalCarwashLaundromat">originalCarwashLaundromat</param>
        /// <param name="originalHydroPulley">originalHydroPulley</param>
        /// <param name="originalFridgeCart">originalFridgeCart</param>
        /// <param name="originalTwoInchPump">originalTwoInchPump</param>
        /// <param name="originalSixInchBypass">originalSixInchBypass</param>
        /// <param name="originalScaffolding">originalScaffolding</param>
        /// <param name="originalWinchExtension">originalWinchExtension</param>
        /// <param name="originalExtraGenerator">originalExtraGenerator</param>
        /// <param name="originalGreyCableExtension">originalGreyCableExtension</param>
        /// <param name="originalEasementMats">originalEasementMats</param>
        /// <param name="originalMeasurementType">originalMeasurementType</param>
        /// <param name="originalDropPipe">originalDropPipe</param>
        /// <param name="originalDropPipeInvertDepth">originalDropPipeInvertDepth</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalMeasuredFromManhole">originalMeasuredFromManhole</param>
        /// <param name="originalMainLined">originalMainLined</param>
        /// <param name="originalBenchingIssue">originalBenchingIssue</param>
        /// <param name="originalArchived">originalArchived</param>
        /// <param name="originalScaledLength1">originalScaledLength1</param>
        /// <param name="originalHistory">originalHistory</param>
        /// <param name="originalNumLats">originalNumLats</param>
        /// <param name="originalNotLinedYet">originalNotLinedYet</param>
        /// <param name="originalAllMeasured">originalAllMeasured</param>
        /// <param name="originalCity">originalCity</param>
        /// <param name="originalProvState">originalProvState</param>
        /// <param name="originalIssueWithLaterals">originalIssueWithLaterals</param>
        /// <param name="originalNotMeasuredYet">originalNotMeasuredYet</param>
        /// <param name="originalNotDeliveredYet">originalNotDeliveredYet</param>
        ///        
        /// <param name="newId">newId</param>        
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newRecordId">newRecordId</param>        
        /// <param name="newClientId">newClientId</param>
        /// <param name="newCompaniesId">newCompaniesId</param> 
        /// <param name="newSubArea">newSubArea</param>
        /// <param name="newStreet">newStreet</param>
        /// <param name="newUSMH">newUSMH</param>
        /// <param name="newDSMH">newDSMH</param>
        /// <param name="newSize_">newSize_</param>
        /// <param name="newScaledLength">newScaledLength</param>
        /// <param name="newP1Date">newP1Date</param>
        /// <param name="newActualLength">newActualLength</param>
        /// <param name="newLiveLats">newLiveLats</param>
        /// <param name="newCXIsRemoved">newCXIsRemoved</param>
        /// <param name="newM1Date">newM1Date</param>
        /// <param name="newM2Date">newM2Date</param>
        /// <param name="newInstallDate">newInstallDate</param>
        /// <param name="newFinalVideo">newFinalVideo</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newIssueIdentified">newIssueIdentified</param>
        /// <param name="newIssueResolved">newIssueResolved</param>
        /// <param name="newFullLengthLining">newFullLengthLining</param>
        /// <param name="newSubcontractorLining">newSubcontractorLining</param>
        /// <param name="newOutOfScopeInArea">newOutOfScopeInArea</param>
        /// <param name="newIssueGivenToBayCity">newIssueGivenToBayCity</param>
        /// <param name="newConfirmedSize">newConfirmedSize</param>
        /// <param name="newInstallRate">newInstallRate</param>
        /// <param name="newDeadlineDate">newDeadlineDate</param>
        /// <param name="newProposedLiningDate">newProposedLiningDate</param>
        /// <param name="newSalesIssue">newSalesIssue</param>
        /// <param name="newLFSIssue">newLFSIssue</param>
        /// <param name="newClientIssue">newClientIssue</param>
        /// <param name="newInvestigationIssue">newInvestigationIssue</param>
        /// <param name="newPointLining">newPointLining</param>
        /// <param name="newGrouting">newGrouting</param>
        /// <param name="newLateralLining">newLateralLining</param>
        /// <param name="newVacExDate">newVacExDateParameter</param>
        /// <param name="newPusherDate">newPusherDate</param>
        /// <param name="newLinerOrdered">newLinerOrdered</param>
        /// <param name="newRestoration">newRestoration</param>
        /// <param name="newGroutDate">newGroutDate</param>
        /// <param name="newJLiner">newJLiner</param>
        /// <param name="newRehabAssessment">newRehabAssessment</param>
        /// <param name="newEstimatedJoints">newEstimatedJoints</param>
        /// <param name="newJointsTestSealed">newJointsTestSealed</param>
        /// <param name="newPreFlushDate">newPreFlushDate</param>
        /// <param name="newPreVideoDate">newPreVideoDate</param>
        /// <param name="newUSMHMN">newUSMHMN</param>
        /// <param name="newDSMHMN">newDSMHMN</param>
        /// <param name="newUSMHDepth">newUSMHDepth</param>
        /// <param name="newDSMHDepth">newDSMHDepth</param>
        /// <param name="newMeasurementsTakenBy">newMeasurementsTakenBy</param>
        /// <param name="newSteelTapeThruPipe">newSteelTapeThruPipe</param>
        /// <param name="newUSMHAtMouth1200">newUSMHAtMouth1200</param>
        /// <param name="newUSMHAtMouth100">newUSMHAtMouth100</param>
        /// <param name="newUSMHAtMouth200">newUSMHAtMouth200</param>
        /// <param name="newUSMHAtMouth300">newUSMHAtMouth300</param>
        /// <param name="newUSMHAtMouth400">newUSMHAtMouth400</param>
        /// <param name="newUSMHAtMouth500">newUSMHAtMouth500</param>
        /// <param name="newDSMHAtMouth1200">newDSMHAtMouth1200</param>
        /// <param name="newDSMHAtMouth100">newDSMHAtMouth100</param>
        /// <param name="newDSMHAtMouth200">newDSMHAtMouth200</param>
        /// <param name="newDSMHAtMouth300">newDSMHAtMouth300</param>
        /// <param name="newDSMHAtMouth400">newDSMHAtMouth400</param>
        /// <param name="newDSMHAtMouth500">newDSMHAtMouth500</param>
        /// <param name="newHydrantAddress">newHydrantAddress</param>
        /// <param name="newDistanceToInversionMH">newDistanceToInversionMH</param>
        /// <param name="newRampsRequired">newRampsRequired</param>
        /// <param name="newDegreeOfTrafficControl">newDegreeOfTrafficControl</param>
        /// <param name="newStandarBypass">newStandarBypass</param>
        /// <param name="newHydroWireDetails">newHydroWireDetails</param>
        /// <param name="newPipeMaterialType">newPipeMaterialType</param>
        /// <param name="newCappedLaterals">newCappedLaterals</param>
        /// <param name="newRoboticPrepRequired">newRoboticPrepRequired</param>
        /// <param name="newPipeSizeChange">newPipeSizeChange</param>
        /// <param name="newM1Comments">newM1Comments</param>
        /// <param name="newVideoDoneFrom">newVideoDoneFrom</param>
        /// <param name="newToManhole">newToManhole</param>
        /// <param name="newCutterDescriptionDuringMeasuring">newCutterDescriptionDuringMeasuring</param>
        /// <param name="newFullLengthPointLiner">newFullLengthPointLiner</param>
        /// <param name="newBypassRequired">newBypassRequired</param>
        /// <param name="newRoboticDistances">newRoboticDistances</param>
        /// <param name="newTrafficControlDetails">newTrafficControlDetails</param>
        /// <param name="newLineWithID">newLineWithID</param>
        /// <param name="newSchoolZone">neSchoolZone</param>
        /// <param name="newRestaurantArea">newRestaurantArea</param>
        /// <param name="newCarwashLaundromat">newCarwashLaundromat</param>
        /// <param name="newHydroPulley">newHydroPulley</param>
        /// <param name="newFridgeCart">FridgeCart</param>
        /// <param name="newTwoInchPump">newTwoInchPump</param>
        /// <param name="newSixInchBypass">newSixInchBypass</param>
        /// <param name="newScaffolding">newScaffolding</param>
        /// <param name="newWinchExtension">WinchExtension</param>
        /// <param name="newExtraGenerator">newExtraGenerator</param>
        /// <param name="newGreyCableExtension">newGreyCableExtension</param>
        /// <param name="newEasementMats">newEasementMats</param>
        /// <param name="newMeasurementType">newMeasurementType</param>
        /// <param name="newDropPipe">newDropPipe</param>
        /// <param name="newDropPipeInvertDepth">newDropPipeInvertDepth</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newMeasuredFromManhole">newMeasuredFromManhole</param>
        /// <param name="newMainLined">newMainLined</param>
        /// <param name="newBenchingIssue">newBenchingIssue</param>
        /// <param name="newArchived">newArchived</param>
        /// <param name="newScaledLength1">newScaledLength1</param>
        /// <param name="newHistory">newHistory</param>
        /// <param name="newNumLats">newNumLats</param>
        /// <param name="newNotLinedYet">newNotLinedYet</param>
        /// <param name="newAllMeasured">newAllMeasured</param>
        /// <param name="newCity">newCity</param>
        /// <param name="newProvState">newProvState</param>
        /// <param name="newIssueWithLaterals">newIssueWithLaterals</param>
        /// <param name="newNotMeasuredYet">newNotMeasuredYet</param>
        /// <param name="newNotDeliveredYet">newNotDeliveredYet</param>
        public int Update(Guid originalId, int originalCompanyId, string originalRecordId, string originalClientId, int? originalCompaniesId, string originalSubArea, string originalStreet, string originalUSMH, string originalDSMH, string originalSize_, string originalScaledLength, DateTime? originalP1Date, string originalActualLength, double? originalLiveLats, string originalCXIsRemoved, DateTime? originalM1Date, DateTime? originalM2Date, DateTime? originalInstallDate, DateTime? originalFinalVideo, string originalComments, bool originalIssueIdentified, bool originalIssueResolved, bool originalFullLengthLining, bool originalSubcontractorLining, bool originalOutOfScopeInArea, bool originalIssueGivenToBayCity, int? originalConfirmedSize, decimal? originalInstallRate, DateTime? originalDeadlineDate, DateTime? originalProposedLiningDate, bool originalSalesIssue, bool originalLFSIssue, bool originalClientIssue, bool originalInvestigationIssue, bool originalPointLining, bool originalGrouting, bool originalLateralLining, DateTime? originalVacExDate, DateTime? originalPusherDate, DateTime? originalLinerOrdered, DateTime? originalRestoration, DateTime? originalGroutDate, bool originalJLiner, bool originalRehabAssessment, int? originalEstimatedJoints, int? originalJointsTestSealed, DateTime? originalPreFlushDate, DateTime? originalPreVideoDate, string originalUSMHMN, string originalDSMHMN, string originalUSMHDepth, string originalDSMHDepth, string originalMeasurementsTakenBy, string originalSteelTapeThruPipe, double? originalUSMHAtMouth1200, double? originalUSMHAtMouth100, double? originalUSMHAtMouth200, double? originalUSMHAtMouth300, double? originalUSMHAtMouth400, double? originalUSMHAtMouth500, double? originalDSMHAtMouth1200, double? originalDSMHAtMouth100, double? originalDSMHAtMouth200, double? originalDSMHAtMouth300, double? originalDSMHAtMouth400, double? originalDSMHAtMouth500, string originalHydrantAddress, string originalDistanceToInversionMH, bool originalRampsRequired, string originalDegreeOfTrafficControl, bool originalStandarBypass, string originalHydroWireDetails, string originalPipeMaterialType, int? originalCappedLaterals, bool originalRoboticPrepRequired, bool originalPipeSizeChange,  string originalM1Comments, string originalVideoDoneFrom, string originalToManhole, string originalCutterDescriptionDuringMeasuring, bool originalFullLengthPointLiner, bool originalBypassRequired, string originalRoboticDistances, string originalTrafficControlDetails, string originalLineWithID, bool originalSchoolZone, bool originalRestaurantArea, bool originalCarwashLaundromat, bool originalHydroPulley, bool originalFridgeCart, bool originalTwoInchPump, bool originalSixInchBypass, bool originalScaffolding, bool originalWinchExtension, bool originalExtraGenerator, bool originalGreyCableExtension, bool originalEasementMats, string originalMeasurementType, bool originalDropPipe, string  originalDropPipeInvertDepth, bool originalDeleted, string originalMeasuredFromManhole, string originalMainLined, string originalBenchingIssue, bool originalArchived, double? originalScaledLength1, string originalHistory, int? originalNumLats, int? originalNotLinedYet, bool originalAllMeasured, string originalCity, string originalProvState, string originalIssueWithLaterals, int? originalNotMeasuredYet, int? originalNotDeliveredYet, Guid newId, int newCompanyId, string newRecordId, string newClientId, int? newCompaniesId, string newSubArea, string newStreet, string newUSMH, string newDSMH, string newSize_, string newScaledLength, DateTime? newP1Date, string newActualLength, double? newLiveLats, string newCXIsRemoved, DateTime? newM1Date, DateTime? newM2Date, DateTime? newInstallDate, DateTime? newFinalVideo, string newComments, bool newIssueIdentified, bool newIssueResolved, bool newFullLengthLining, bool newSubcontractorLining, bool newOutOfScopeInArea, bool newIssueGivenToBayCity, int? newConfirmedSize, decimal? newInstallRate, DateTime? newDeadlineDate, DateTime? newProposedLiningDate, bool newSalesIssue, bool newLFSIssue, bool newClientIssue, bool newInvestigationIssue, bool newPointLining, bool newGrouting, bool newLateralLining, DateTime? newVacExDate, DateTime? newPusherDate, DateTime? newLinerOrdered, DateTime? newRestoration, DateTime? newGroutDate, bool newJLiner, bool newRehabAssessment, int? newEstimatedJoints, int? newJointsTestSealed, DateTime? newPreFlushDate, DateTime? newPreVideoDate, string newUSMHMN, string newDSMHMN, string newUSMHDepth, string newDSMHDepth, string newMeasurementsTakenBy, string newSteelTapeThruPipe, double? newUSMHAtMouth1200, double? newUSMHAtMouth100, double? newUSMHAtMouth200, double? newUSMHAtMouth300, double? newUSMHAtMouth400, double? newUSMHAtMouth500, double? newDSMHAtMouth1200, double? newDSMHAtMouth100, double? newDSMHAtMouth200, double? newDSMHAtMouth300, double? newDSMHAtMouth400, double? newDSMHAtMouth500, string newHydrantAddress, string newDistanceToInversionMH, bool newRampsRequired, string newDegreeOfTrafficControl, bool newStandarBypass, string newHydroWireDetails, string newPipeMaterialType, int? newCappedLaterals, bool newRoboticPrepRequired, bool newPipeSizeChange, string newM1Comments, string newVideoDoneFrom, string newToManhole, string newCutterDescriptionDuringMeasuring, bool newFullLengthPointLiner, bool newBypassRequired, string newRoboticDistances, string newTrafficControlDetails, string newLineWithID, bool newSchoolZone, bool newRestaurantArea, bool newCarwashLaundromat, bool newHydroPulley, bool newFridgeCart, bool newTwoInchPump, bool newSixInchBypass, bool newScaffolding, bool newWinchExtension, bool newExtraGenerator, bool newGreyCableExtension, bool newEasementMats, string newMeasurementType, bool newDropPipe, string newDropPipeInvertDepth, bool newDeleted, string newMeasuredFromManhole, string newMainLined, string newBenchingIssue, bool newArchived, double? newScaledLength1, string newHistory, int? newNumLats, int? newNotLinedYet, bool newAllMeasured, string newCity, string newProvState, string newIssueWithLaterals, int? newNotMeasuredYet, int? newNotDeliveredYet)
        {
            SqlParameter originalIdParameter = new SqlParameter("Original_ID", originalId);            
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalRecordIdParameter = (originalRecordId.Trim() != "") ? new SqlParameter("Original_RecordID", originalRecordId.Trim()) : new SqlParameter("Original_RecordID", DBNull.Value);
            SqlParameter originalClientIdParameter = (originalClientId.Trim() != "") ? new SqlParameter("Original_ClientID", originalClientId.Trim()) : new SqlParameter("Original_ClientID", DBNull.Value);
            SqlParameter originalCompaniesIdParameter = (originalCompaniesId.HasValue) ? new SqlParameter("Original_COMPANIES_ID", originalCompaniesId) : new SqlParameter("Original_COMPANIES_ID", DBNull.Value);
            SqlParameter originalSubAreaParameter = (originalSubArea.Trim() != "") ? new SqlParameter("Original_SubArea", originalSubArea.Trim()) : new SqlParameter("Original_SubArea", DBNull.Value);
            SqlParameter originalStreetParameter = (originalStreet.Trim() != "") ? new SqlParameter("Original_Street", originalStreet.Trim()) : new SqlParameter("Original_Street", DBNull.Value);
            SqlParameter originalUSMHParameter = (originalUSMH.Trim() != "") ? new SqlParameter("Original_USMH", originalUSMH.Trim()) : new SqlParameter("Original_USMH", DBNull.Value);
            SqlParameter originalDSMHParameter = (originalDSMH.Trim() != "") ? new SqlParameter("Original_DSMH", originalDSMH.Trim()) : new SqlParameter("Original_DSMH", DBNull.Value);
            SqlParameter originalSize_Parameter = (originalSize_.Trim() != "") ? new SqlParameter("Original_Size_", originalSize_.Trim()) : new SqlParameter("Original_Size_", DBNull.Value);
            SqlParameter originalScaledLengthParameter = (originalScaledLength.Trim() != "") ? new SqlParameter("Original_ScaledLength", originalScaledLength.Trim()) : new SqlParameter("Original_ScaledLength", DBNull.Value);
            SqlParameter originalP1DateParameter = (originalP1Date.HasValue) ? new SqlParameter("Original_P1Date", originalP1Date) : new SqlParameter("Original_P1Date", DBNull.Value);
            SqlParameter originalActualLengthParameter = (originalActualLength.Trim() != "" ) ? new SqlParameter("Original_ActualLength", originalActualLength.Trim()) : new SqlParameter("Original_ActualLength", DBNull.Value);
            SqlParameter originalLiveLatsParameter = (originalLiveLats.HasValue) ? new SqlParameter("Original_LiveLats", originalLiveLats) : new SqlParameter("Original_LiveLats", DBNull.Value);
            SqlParameter originalCXIsRemovedParameter = (originalCXIsRemoved.Trim() != "") ? new SqlParameter("Original_CXIsRemoved", originalCXIsRemoved.Trim()) : new SqlParameter("Original_CXIsRemoved", DBNull.Value);
            SqlParameter originalM1DateParameter = (originalM1Date.HasValue) ? new SqlParameter("Original_M1Date", originalM1Date) : new SqlParameter("Original_M1Date", DBNull.Value);
            SqlParameter originalM2DateParameter = (originalM2Date.HasValue) ? new SqlParameter("Original_M2Date", originalM2Date) : new SqlParameter("Original_M2Date", DBNull.Value);
            SqlParameter originalInstallDateParameter = (originalInstallDate.HasValue) ? new SqlParameter("Original_InstallDate", originalInstallDate) : new SqlParameter("Original_InstallDate", DBNull.Value);
            SqlParameter originalFinalVideoParameter = (originalFinalVideo.HasValue) ? new SqlParameter("Original_FinalVideo", originalFinalVideo) : new SqlParameter("Original_FinalVideo", DBNull.Value);
            SqlParameter originalCommentsParameter = (originalComments.Trim() != "") ? new SqlParameter("Original_Comments", originalComments.Trim()) : new SqlParameter("Original_Comments", DBNull.Value);
            SqlParameter originalIssueIdentifiedParameter = new SqlParameter("Original_IssueIdentified", originalIssueIdentified);
            SqlParameter originalIssueResolvedParameter = new SqlParameter("Original_IssueResolved", originalIssueResolved);
            SqlParameter originalFullLengthLiningParameter = new SqlParameter("Original_FullLengthLining", originalFullLengthLining);            
            SqlParameter originalSubcontractorLiningParameter = new SqlParameter("Original_SubcontractorLining", originalSubcontractorLining);
            SqlParameter originalOutOfScopeInAreaParameter = new SqlParameter("Original_OutOfScopeInArea", originalOutOfScopeInArea);
            SqlParameter originalIssueGivenToBayCityParameter = new SqlParameter("Original_IssueGivenToBayCity", originalIssueGivenToBayCity);
            SqlParameter originalConfirmedSizeParameter = (originalConfirmedSize.HasValue) ? new SqlParameter("Original_ConfirmedSize", originalConfirmedSize) : new SqlParameter("Original_ConfirmedSize", DBNull.Value);
            SqlParameter originalInstallRateParameter = (originalInstallRate.HasValue) ? new SqlParameter("Original_InstallRate", originalInstallRate) : new SqlParameter("Original_InstallRate", DBNull.Value);
            SqlParameter originalDeadlineDateParameter = (originalDeadlineDate.HasValue) ? new SqlParameter("Original_DeadlineDate", originalDeadlineDate) : new SqlParameter("Original_DeadlineDate", DBNull.Value);
            SqlParameter originalProposedLiningDateParameter = (originalProposedLiningDate.HasValue) ? new SqlParameter("Original_ProposedLiningDate", originalProposedLiningDate) : new SqlParameter("Original_ProposedLiningDate", DBNull.Value);
            SqlParameter originalSalesIssueParameter = new SqlParameter("Original_SalesIssue", originalSalesIssue);
            SqlParameter originalLFSIssueParameter = new SqlParameter("Original_LFSIssue", originalLFSIssue);
            SqlParameter originalClientIssueParameter = new SqlParameter("Original_ClientIssue", originalClientIssue);
            SqlParameter originalInvestigationIssueParameter = new SqlParameter("Original_InvestigationIssue", originalInvestigationIssue);
            SqlParameter originalPointLiningParameter = new SqlParameter("Original_PointLining", originalPointLining);
            SqlParameter originalGroutingParameter = new SqlParameter("Original_Grouting", originalGrouting);
            SqlParameter originalLateralLiningParameter = new SqlParameter("Original_LateralLining", originalLateralLining);
            SqlParameter originalVacExDateParameter = (originalVacExDate.HasValue) ? new SqlParameter("Original_VacExDate", originalVacExDate) : new SqlParameter("Original_VacExDate", DBNull.Value);
            SqlParameter originalPusherDateParameter = (originalPusherDate.HasValue) ? new SqlParameter("Original_PusherDate", originalPusherDate) : new SqlParameter("Original_PusherDate", DBNull.Value);
            SqlParameter originalLinerOrderedParameter = (originalLinerOrdered.HasValue) ? new SqlParameter("Original_LinerOrdered", originalLinerOrdered) : new SqlParameter("Original_LinerOrdered", DBNull.Value);
            SqlParameter originalRestorationParameter = (originalRestoration.HasValue) ? new SqlParameter("Original_Restoration", originalRestoration) : new SqlParameter("Original_Restoration", DBNull.Value);
            SqlParameter originalGroutDateParameter = (originalGroutDate.HasValue) ? new SqlParameter("Original_GroutDate", originalGroutDate) : new SqlParameter("Original_GroutDate", DBNull.Value);
            SqlParameter originalJLinerParameter = new SqlParameter("Original_JLiner", originalJLiner);
            SqlParameter originalRehabAssessmentParameter = new SqlParameter("Original_RehabAssessment", originalRehabAssessment);
            SqlParameter originalEstimatedJointsParameter = (originalEstimatedJoints.HasValue) ? new SqlParameter("Original_EstimatedJoints", originalEstimatedJoints) : new SqlParameter("Original_EstimatedJoints", DBNull.Value);
            SqlParameter originalJointsTestSealedParameter = (originalJointsTestSealed.HasValue) ? new SqlParameter("Original_JointsTestSealed", originalJointsTestSealed) : new SqlParameter("Original_JointsTestSealed", DBNull.Value);
            SqlParameter originalPreFlushDateParameter = (originalPreFlushDate.HasValue) ? new SqlParameter("Original_PreFlushDate", originalPreFlushDate) : new SqlParameter("Original_PreFlushDate", DBNull.Value);
            SqlParameter originalPreVideoDateParameter = (originalPreVideoDate.HasValue) ? new SqlParameter("Original_PreVideoDate", originalPreVideoDate) : new SqlParameter("Original_PreVideoDate", DBNull.Value);
            SqlParameter originalUSMHMNParameter = (originalUSMHMN.Trim() != "") ? new SqlParameter("Original_USMHMN", originalUSMHMN.Trim()) : new SqlParameter("Original_USMHMN", DBNull.Value);
            SqlParameter originalDSMHMNParameter = (originalDSMHMN.Trim() != "") ? new SqlParameter("Original_DSMHMN", originalDSMHMN.Trim()) : new SqlParameter("Original_DSMHMN", DBNull.Value);
            SqlParameter originalUSMHDepthParameter = (originalUSMHDepth.Trim() != "") ? new SqlParameter("Original_USMHDepth", originalUSMHDepth.Trim()) : new SqlParameter("Original_USMHDepth", DBNull.Value);
            SqlParameter originalDSMHDepthParameter = (originalDSMHDepth.Trim() != "") ? new SqlParameter("Original_DSMHDepth", originalDSMHDepth.Trim()) : new SqlParameter("Original_DSMHDepth", DBNull.Value);
            SqlParameter originalMeasurementsTakenByParameter = (originalMeasurementsTakenBy.Trim() != "") ? new SqlParameter("Original_MeasurementsTakenBy", originalMeasurementsTakenBy.Trim()) : new SqlParameter("Original_MeasurementsTakenBy", DBNull.Value);
            SqlParameter originalSteelTapeThruPipeParameter = (originalSteelTapeThruPipe.Trim() != "") ? new SqlParameter("Original_SteelTapeThruPipe", originalSteelTapeThruPipe.Trim()) : new SqlParameter("Original_SteelTapeThruPipe", DBNull.Value);
            SqlParameter originalUSMHAtMouth1200Parameter = (originalUSMHAtMouth1200.HasValue) ? new SqlParameter("Original_USMHAtMouth1200", originalUSMHAtMouth1200) : new SqlParameter("Original_USMHAtMouth1200", DBNull.Value);
            SqlParameter originalUSMHAtMouth100Parameter = (originalUSMHAtMouth100.HasValue) ? new SqlParameter("Original_USMHAtMouth100", originalUSMHAtMouth100) : new SqlParameter("Original_USMHAtMouth100", DBNull.Value);
            SqlParameter originalUSMHAtMouth200Parameter = (originalUSMHAtMouth200.HasValue) ? new SqlParameter("Original_USMHAtMouth200", originalUSMHAtMouth200) : new SqlParameter("Original_USMHAtMouth200", DBNull.Value);
            SqlParameter originalUSMHAtMouth300Parameter = (originalUSMHAtMouth300.HasValue) ? new SqlParameter("Original_USMHAtMouth300", originalUSMHAtMouth300) : new SqlParameter("Original_USMHAtMouth300", DBNull.Value);
            SqlParameter originalUSMHAtMouth400Parameter = (originalUSMHAtMouth400.HasValue) ? new SqlParameter("Original_USMHAtMouth400", originalUSMHAtMouth400) : new SqlParameter("Original_USMHAtMouth400", DBNull.Value);
            SqlParameter originalUSMHAtMouth500Parameter = (originalUSMHAtMouth500.HasValue) ? new SqlParameter("Original_USMHAtMouth500", originalUSMHAtMouth500) : new SqlParameter("Original_USMHAtMouth500", DBNull.Value);
            SqlParameter originalDSMHAtMouth1200Parameter = (originalDSMHAtMouth1200.HasValue) ? new SqlParameter("Original_DSMHAtMouth1200", originalDSMHAtMouth1200) : new SqlParameter("Original_DSMHAtMouth1200", DBNull.Value);
            SqlParameter originalDSMHAtMouth100Parameter = (originalDSMHAtMouth100.HasValue) ? new SqlParameter("Original_DSMHAtMouth100", originalDSMHAtMouth100) : new SqlParameter("Original_DSMHAtMouth100", DBNull.Value);
            SqlParameter originalDSMHAtMouth200Parameter = (originalDSMHAtMouth200.HasValue) ? new SqlParameter("Original_DSMHAtMouth200", originalDSMHAtMouth200) : new SqlParameter("Original_DSMHAtMouth200", DBNull.Value);
            SqlParameter originalDSMHAtMouth300Parameter = (originalDSMHAtMouth300.HasValue) ? new SqlParameter("Original_DSMHAtMouth300", originalDSMHAtMouth300) : new SqlParameter("Original_DSMHAtMouth300", DBNull.Value);
            SqlParameter originalDSMHAtMouth400Parameter = (originalDSMHAtMouth400.HasValue) ? new SqlParameter("Original_DSMHAtMouth400", originalDSMHAtMouth400) : new SqlParameter("Original_DSMHAtMouth400", DBNull.Value);
            SqlParameter originalDSMHAtMouth500Parameter = (originalDSMHAtMouth500.HasValue) ? new SqlParameter("Original_DSMHAtMouth500", originalDSMHAtMouth500) : new SqlParameter("Original_DSMHAtMouth500", DBNull.Value);
            SqlParameter originalHydrantAddressParameter = (originalHydrantAddress.Trim() != "") ? new SqlParameter("Original_HydrantAddress", originalHydrantAddress.Trim()) : new SqlParameter("Original_HydrantAddress", DBNull.Value);
            SqlParameter originalDistanceToInversionMHParameter = (originalDistanceToInversionMH.Trim() != "") ? new SqlParameter("Original_DistanceToInversionMH", originalDistanceToInversionMH.Trim()) : new SqlParameter("Original_DistanceToInversionMH", DBNull.Value);
            SqlParameter originalRampsRequiredParameter = new SqlParameter("Original_RampsRequired", originalRampsRequired);
            SqlParameter originalDegreeOfTrafficControlParameter = (originalDegreeOfTrafficControl.Trim() != "") ? new SqlParameter("Original_DegreeOfTrafficControl", originalDegreeOfTrafficControl.Trim()) : new SqlParameter("Original_DegreeOfTrafficControl", DBNull.Value);
            SqlParameter originalStandarBypassParameter = new SqlParameter("Original_StandarBypass", originalStandarBypass);
            SqlParameter originalHydroWireDetailsParameter = (originalHydroWireDetails.Trim() != "") ? new SqlParameter("Original_HydroWireDetails", originalHydroWireDetails.Trim()) : new SqlParameter("Original_HydroWireDetails", DBNull.Value);
            SqlParameter originalPipeMaterialTypeParameter = (originalPipeMaterialType.Trim() != "") ? new SqlParameter("Original_PipeMaterialType", originalPipeMaterialType.Trim()) : new SqlParameter("Original_PipeMaterialType", DBNull.Value);
            SqlParameter originalCappedLateralsParameter = (originalCappedLaterals.HasValue) ? new SqlParameter("Original_CappedLaterals", originalCappedLaterals) : new SqlParameter("Original_CappedLaterals", DBNull.Value);
            SqlParameter originalRoboticPrepRequiredParameter = new SqlParameter("Original_RoboticPrepRequired", originalRoboticPrepRequired);
            SqlParameter originalPipeSizeChangeParameter = new SqlParameter("Original_PipeSizeChange", originalPipeSizeChange);
            SqlParameter originalM1CommentsParameter = (originalM1Comments.Trim() != "") ? new SqlParameter("Original_M1Comments", originalM1Comments.Trim()) : new SqlParameter("Original_M1Comments", DBNull.Value);
            SqlParameter originalVideoDoneFromParameter = (originalVideoDoneFrom.Trim() != "") ? new SqlParameter("Original_VideoDoneFrom", originalVideoDoneFrom.Trim()) : new SqlParameter("Original_VideoDoneFrom", DBNull.Value);
            SqlParameter originalToManholeParameter = (originalToManhole.Trim() != "") ? new SqlParameter("Original_ToManhole", originalToManhole.Trim()) : new SqlParameter("Original_ToManhole", DBNull.Value);
            SqlParameter originalCutterDescriptionDuringMeasuringParameter = (originalCutterDescriptionDuringMeasuring.Trim() != "") ? new SqlParameter("Original_CutterDescriptionDuringMeasuring", originalCutterDescriptionDuringMeasuring.Trim()) : new SqlParameter("Original_CutterDescriptionDuringMeasuring", DBNull.Value);
            SqlParameter originalFullLengthPointLinerParameter = new SqlParameter("Original_FullLengthPointLiner", originalFullLengthPointLiner);
            SqlParameter originalBypassRequiredParameter = new SqlParameter("Original_BypassRequired", originalBypassRequired);
            SqlParameter originalRoboticDistancesParameter = (originalRoboticDistances.Trim() != "") ? new SqlParameter("Original_RoboticDistances", originalRoboticDistances.Trim()) : new SqlParameter("Original_RoboticDistances", DBNull.Value);
            SqlParameter originalTrafficControlDetailsParameter = (originalTrafficControlDetails.Trim() != "") ? new SqlParameter("Original_TrafficControlDetails", originalTrafficControlDetails.Trim()) : new SqlParameter("Original_TrafficControlDetails", DBNull.Value);
            SqlParameter originalLineWithIDParameter = (originalLineWithID.Trim() != "") ? new SqlParameter("Original_LineWithID", originalLineWithID.Trim()) : new SqlParameter("Original_LineWithID", DBNull.Value);
            SqlParameter originalSchoolZoneParameter = new SqlParameter("Original_SchoolZone", originalSchoolZone);
            SqlParameter originalRestaurantAreaParameter = new SqlParameter("Original_RestaurantArea", originalRestaurantArea);
            SqlParameter originalCarwashLaundromatParameter = new SqlParameter("Original_CarwashLaundromat", originalCarwashLaundromat);
            SqlParameter originalHydroPulleyParameter = new SqlParameter("Original_HydroPulley", originalHydroPulley);
            SqlParameter originalFridgeCartParameter = new SqlParameter("Original_FridgeCart", originalFridgeCart);
            SqlParameter originalTwoInchPumpParameter = new SqlParameter("Original_TwoInchPump", originalTwoInchPump);
            SqlParameter originalSixInchBypassParameter = new SqlParameter("Original_SixInchBypass", originalSixInchBypass);
            SqlParameter originalScaffoldingParameter = new SqlParameter("Original_Scaffolding", originalScaffolding);
            SqlParameter originalWinchExtensionParameter = new SqlParameter("Original_WinchExtension", originalWinchExtension);
            SqlParameter originalExtraGeneratorParameter = new SqlParameter("Original_ExtraGenerator", originalExtraGenerator);
            SqlParameter originalGreyCableExtensionParameter = new SqlParameter("Original_GreyCableExtension", originalGreyCableExtension);
            SqlParameter originalEasementMatsParameter = new SqlParameter("Original_EasementMats", originalEasementMats);
            SqlParameter originalMeasurementTypeParameter = (originalMeasurementType.Trim() != "") ? new SqlParameter("Original_MeasurementType", originalMeasurementType.Trim()) : new SqlParameter("Original_MeasurementType", DBNull.Value);
            SqlParameter originalDropPipeParameter = new SqlParameter("Original_DropPipe", originalDropPipe);
            SqlParameter originalDropPipeInvertDepthParameter = (originalDropPipeInvertDepth.Trim() != "") ? new SqlParameter("Original_DropPipeInvertDepth", originalDropPipeInvertDepth.Trim()) : new SqlParameter("Original_DropPipeInvertDepth", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalMeasuredFromManholeParameter = (originalMeasuredFromManhole.Trim() != "") ? new SqlParameter("Original_MeasuredFromManhole", originalMeasuredFromManhole.Trim()) : new SqlParameter("Original_MeasuredFromManhole", DBNull.Value);
            SqlParameter originalMainLinedParameter = (originalMainLined.Trim() != "") ? new SqlParameter("Original_MainLined", originalMainLined.Trim()) : new SqlParameter("Original_MainLined", DBNull.Value);
            SqlParameter originalBenchingIssueParameter = (originalBenchingIssue.Trim() != "") ? new SqlParameter("Original_BenchingIssue", originalBenchingIssue.Trim()) : new SqlParameter("Original_BenchingIssue", DBNull.Value);
            SqlParameter originalArchivedParameter = new SqlParameter("Original_Archived", originalArchived);
            SqlParameter originalScaledLength1Parameter = (originalScaledLength1.HasValue) ? new SqlParameter("Original_ScaledLength1", originalScaledLength1) : new SqlParameter("Original_ScaledLength1", DBNull.Value);
            SqlParameter originalHistoryParameter = (originalHistory.Trim() != "") ? new SqlParameter("Original_History", originalHistory.Trim()) : new SqlParameter("Original_History", DBNull.Value);
            SqlParameter originalNumLatsParameter = (originalNumLats.HasValue) ? new SqlParameter("Original_NumLats", originalNumLats) : new SqlParameter("Original_NumLats", DBNull.Value);
            SqlParameter originalNotLinedYetParameter = (originalNotLinedYet.HasValue) ? new SqlParameter("Original_NotLinedYet", originalNotLinedYet) : new SqlParameter("Original_NotLinedYet", DBNull.Value);
            SqlParameter originalAllMeasuredParameter = new SqlParameter("Original_AllMeasured", originalAllMeasured);
            SqlParameter originalCityParameter = (originalCity.Trim() != "") ? new SqlParameter("Original_City", originalCity.Trim()) : new SqlParameter("Original_City", DBNull.Value);
            SqlParameter originalProvStateParameter = (originalProvState.Trim() != "") ? new SqlParameter("Original_ProvState", originalProvState.Trim()) : new SqlParameter("Original_ProvState", DBNull.Value);
            SqlParameter originalIssueWithLateralsParameter = (originalIssueWithLaterals.Trim() != "") ? new SqlParameter("Original_IssueWithLaterals", originalIssueWithLaterals.Trim()) : new SqlParameter("Original_IssueWithLaterals", DBNull.Value);
            SqlParameter originalNotMeasuredYetParameter = (originalNotMeasuredYet.HasValue) ? new SqlParameter("Original_NotMeasuredYet", originalNotMeasuredYet) : new SqlParameter("Original_NotMeasuredYet", DBNull.Value);
            SqlParameter originalNotDeliveredYetParameter = (originalNotDeliveredYet.HasValue) ? new SqlParameter("Original_NotDeliveredYet", originalNotDeliveredYet) : new SqlParameter("Original_NotDeliveredYet", DBNull.Value);
            
            SqlParameter newIdParameter = new SqlParameter("ID", newId);            
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newRecordIdParameter = (newRecordId.Trim() != "") ? new SqlParameter("RecordID", newRecordId) : new SqlParameter("RecordID", DBNull.Value);
            SqlParameter newClientIdParameter = (newClientId.Trim() != "") ? new SqlParameter("ClientID", newClientId.Trim()) : new SqlParameter("ClientID", DBNull.Value);
            SqlParameter newCompaniesIdParameter = (newCompaniesId.HasValue) ? new SqlParameter("COMPANIES_ID", newCompaniesId) : new SqlParameter("COMPANIES_ID", DBNull.Value);
            SqlParameter newSubAreaParameter = (newSubArea.Trim() != "") ? new SqlParameter("SubArea", newSubArea.Trim()) : new SqlParameter("SubArea", DBNull.Value);
            SqlParameter newStreetParameter = (newStreet.Trim() != "") ? new SqlParameter("Street", newStreet.Trim()) : new SqlParameter("Street", DBNull.Value);
            SqlParameter newUSMHParameter = (newUSMH.Trim() != "") ? new SqlParameter("USMH", newUSMH.Trim()) : new SqlParameter("USMH", DBNull.Value);
            SqlParameter newDSMHParameter = (newDSMH.Trim() != "") ? new SqlParameter("DSMH", newDSMH.Trim()) : new SqlParameter("DSMH", DBNull.Value);
            SqlParameter newSize_Parameter = (newSize_.Trim() != "") ? new SqlParameter("Size_", newSize_.Trim()) : new SqlParameter("Size_", DBNull.Value);
            SqlParameter newScaledLengthParameter = (newScaledLength.Trim() != "") ? new SqlParameter("ScaledLength", newScaledLength.Trim()) : new SqlParameter("ScaledLength", DBNull.Value);
            SqlParameter newP1DateParameter = (newP1Date.HasValue) ? new SqlParameter("P1Date", newP1Date) : new SqlParameter("P1Date", DBNull.Value);
            SqlParameter newActualLengthParameter = (newActualLength.Trim() != "") ? new SqlParameter("ActualLength", newActualLength.Trim()) : new SqlParameter("ActualLength", DBNull.Value);
            SqlParameter newLiveLatsParameter = (newLiveLats.HasValue) ? new SqlParameter("LiveLats", newLiveLats) : new SqlParameter("LiveLats", DBNull.Value);
            SqlParameter newCXIsRemovedParameter = (newCXIsRemoved.Trim() != "") ? new SqlParameter("CXIsRemoved", newCXIsRemoved.Trim()) : new SqlParameter("CXIsRemoved", DBNull.Value);
            SqlParameter newM1DateParameter = (newM1Date.HasValue) ? new SqlParameter("M1Date", newM1Date) : new SqlParameter("M1Date", DBNull.Value);
            SqlParameter newM2DateParameter = (newM2Date.HasValue) ? new SqlParameter("M2Date", newM2Date) : new SqlParameter("M2Date", DBNull.Value);
            SqlParameter newInstallDateParameter = (newInstallDate.HasValue) ? new SqlParameter("InstallDate", newInstallDate) : new SqlParameter("InstallDate", DBNull.Value);
            SqlParameter newFinalVideoParameter = (newFinalVideo.HasValue) ? new SqlParameter("FinalVideo", newFinalVideo) : new SqlParameter("FinalVideo", DBNull.Value);
            SqlParameter newCommentsParameter = (newComments.Trim() != "") ? new SqlParameter("Comments", newComments.Trim()) : new SqlParameter("Comments", DBNull.Value);
            SqlParameter newIssueIdentifiedParameter = new SqlParameter("IssueIdentified", newIssueIdentified);
            SqlParameter newIssueResolvedParameter = new SqlParameter("IssueResolved", newIssueResolved);
            SqlParameter newFullLengthLiningParameter = new SqlParameter("FullLengthLining", newFullLengthLining);
            SqlParameter newSubcontractorLiningParameter = new SqlParameter("SubcontractorLining", newSubcontractorLining);
            SqlParameter newOutOfScopeInAreaParameter = new SqlParameter("OutOfScopeInArea", newOutOfScopeInArea);
            SqlParameter newIssueGivenToBayCityParameter = new SqlParameter("IssueGivenToBayCity", newIssueGivenToBayCity);
            SqlParameter newConfirmedSizeParameter = (newConfirmedSize.HasValue) ? new SqlParameter("ConfirmedSize", newConfirmedSize) : new SqlParameter("ConfirmedSize", DBNull.Value);
            SqlParameter newInstallRateParameter = (newInstallRate.HasValue) ? new SqlParameter("InstallRate", newInstallRate) : new SqlParameter("InstallRate", DBNull.Value);
            SqlParameter newDeadlineDateParameter = (newDeadlineDate.HasValue) ? new SqlParameter("DeadlineDate", newDeadlineDate) : new SqlParameter("DeadlineDate", DBNull.Value);
            SqlParameter newProposedLiningDateParameter = (newProposedLiningDate.HasValue) ? new SqlParameter("ProposedLiningDate", newProposedLiningDate) : new SqlParameter("ProposedLiningDate", DBNull.Value);
            SqlParameter newSalesIssueParameter = new SqlParameter("SalesIssue", newSalesIssue);
            SqlParameter newLFSIssueParameter = new SqlParameter("LFSIssue", newLFSIssue);
            SqlParameter newClientIssueParameter = new SqlParameter("ClientIssue", newClientIssue);
            SqlParameter newInvestigationIssueParameter = new SqlParameter("InvestigationIssue", newInvestigationIssue);
            SqlParameter newPointLiningParameter = new SqlParameter("PointLining", newPointLining);
            SqlParameter newGroutingParameter = new SqlParameter("Grouting", newGrouting);
            SqlParameter newLateralLiningParameter = new SqlParameter("LateralLining", newLateralLining);            
            SqlParameter newVacExDateParameter = (newVacExDate.HasValue) ? new SqlParameter("VacExDate", newVacExDate) : new SqlParameter("VacExDate", DBNull.Value);
            SqlParameter newPusherDateParameter = (newPusherDate.HasValue) ? new SqlParameter("PusherDate", newPusherDate) : new SqlParameter("PusherDate", DBNull.Value);
            SqlParameter newLinerOrderedParameter = (newLinerOrdered.HasValue) ? new SqlParameter("LinerOrdered", newLinerOrdered) : new SqlParameter("LinerOrdered", DBNull.Value);
            SqlParameter newRestorationParameter = (newRestoration.HasValue) ? new SqlParameter("Restoration", newRestoration) : new SqlParameter("Restoration", DBNull.Value);
            SqlParameter newGroutDateParameter = (newGroutDate.HasValue) ? new SqlParameter("GroutDate", newGroutDate) : new SqlParameter("GroutDate", DBNull.Value);
            SqlParameter newJLinerParameter = new SqlParameter("JLiner", newJLiner);
            SqlParameter newRehabAssessmentParameter = new SqlParameter("RehabAssessment", newRehabAssessment);
            SqlParameter newEstimatedJointsParameter = (newEstimatedJoints.HasValue) ? new SqlParameter("EstimatedJoints", newEstimatedJoints) : new SqlParameter("EstimatedJoints", DBNull.Value);
            SqlParameter newJointsTestSealedParameter = (newJointsTestSealed.HasValue) ? new SqlParameter("JointsTestSealed", newJointsTestSealed) : new SqlParameter("JointsTestSealed", DBNull.Value);
            SqlParameter newPreFlushDateParameter = (newPreFlushDate.HasValue) ? new SqlParameter("PreFlushDate", newPreFlushDate) : new SqlParameter("PreFlushDate", DBNull.Value);
            SqlParameter newPreVideoDateParameter = (newPreVideoDate.HasValue) ? new SqlParameter("PreVideoDate", newPreVideoDate) : new SqlParameter("PreVideoDate", DBNull.Value);
            SqlParameter newUSMHMNParameter = (newUSMHMN.Trim() != "") ? new SqlParameter("USMHMN", newUSMHMN.Trim()) : new SqlParameter("USMHMN", DBNull.Value);
            SqlParameter newDSMHMNParameter = (newDSMHMN.Trim() != "") ? new SqlParameter("DSMHMN", newDSMHMN.Trim()) : new SqlParameter("DSMHMN", DBNull.Value);
            SqlParameter newUSMHDepthParameter = (newUSMHDepth.Trim() != "") ? new SqlParameter("USMHDepth", newUSMHDepth.Trim()) : new SqlParameter("USMHDepth", DBNull.Value);
            SqlParameter newDSMHDepthParameter = (newDSMHDepth.Trim() != "") ? new SqlParameter("DSMHDepth", newDSMHDepth.Trim()) : new SqlParameter("DSMHDepth", DBNull.Value);
            SqlParameter newMeasurementsTakenByParameter = (newMeasurementsTakenBy.Trim() != "") ? new SqlParameter("MeasurementsTakenBy", newMeasurementsTakenBy.Trim()) : new SqlParameter("MeasurementsTakenBy", DBNull.Value);
            SqlParameter newSteelTapeThruPipeParameter = (newSteelTapeThruPipe.Trim() != "") ? new SqlParameter("SteelTapeThruPipe", newSteelTapeThruPipe.Trim()) : new SqlParameter("SteelTapeThruPipe", DBNull.Value);
            SqlParameter newUSMHAtMouth1200Parameter = (newUSMHAtMouth1200.HasValue) ? new SqlParameter("USMHAtMouth1200", newUSMHAtMouth1200) : new SqlParameter("USMHAtMouth1200", DBNull.Value);
            SqlParameter newUSMHAtMouth100Parameter = (newUSMHAtMouth100.HasValue) ? new SqlParameter("USMHAtMouth100", newUSMHAtMouth100) : new SqlParameter("USMHAtMouth100", DBNull.Value);
            SqlParameter newUSMHAtMouth200Parameter = (newUSMHAtMouth200.HasValue) ? new SqlParameter("USMHAtMouth200", newUSMHAtMouth200) : new SqlParameter("USMHAtMouth200", DBNull.Value);
            SqlParameter newUSMHAtMouth300Parameter = (newUSMHAtMouth300.HasValue) ? new SqlParameter("USMHAtMouth300", newUSMHAtMouth300) : new SqlParameter("USMHAtMouth300", DBNull.Value);
            SqlParameter newUSMHAtMouth400Parameter = (newUSMHAtMouth400.HasValue) ? new SqlParameter("USMHAtMouth400", newUSMHAtMouth400) : new SqlParameter("USMHAtMouth400", DBNull.Value);
            SqlParameter newUSMHAtMouth500Parameter = (newUSMHAtMouth500.HasValue) ? new SqlParameter("USMHAtMouth500", newUSMHAtMouth500) : new SqlParameter("USMHAtMouth500", DBNull.Value);
            SqlParameter newDSMHAtMouth1200Parameter = (newDSMHAtMouth1200.HasValue) ? new SqlParameter("DSMHAtMouth1200", newDSMHAtMouth1200) : new SqlParameter("DSMHAtMouth1200", DBNull.Value);
            SqlParameter newDSMHAtMouth100Parameter = (newDSMHAtMouth100.HasValue) ? new SqlParameter("DSMHAtMouth100", newDSMHAtMouth100) : new SqlParameter("DSMHAtMouth100", DBNull.Value);
            SqlParameter newDSMHAtMouth200Parameter = (newDSMHAtMouth200.HasValue) ? new SqlParameter("DSMHAtMouth200", newDSMHAtMouth200) : new SqlParameter("DSMHAtMouth200", DBNull.Value);
            SqlParameter newDSMHAtMouth300Parameter = (newDSMHAtMouth300.HasValue) ? new SqlParameter("DSMHAtMouth300", newDSMHAtMouth300) : new SqlParameter("DSMHAtMouth300", DBNull.Value);
            SqlParameter newDSMHAtMouth400Parameter = (newDSMHAtMouth400.HasValue) ? new SqlParameter("DSMHAtMouth400", newDSMHAtMouth400) : new SqlParameter("DSMHAtMouth400", DBNull.Value);
            SqlParameter newDSMHAtMouth500Parameter = (newDSMHAtMouth500.HasValue) ? new SqlParameter("DSMHAtMouth500", newDSMHAtMouth500) : new SqlParameter("DSMHAtMouth500", DBNull.Value);
            SqlParameter newHydrantAddressParameter = (newHydrantAddress.Trim() != "") ? new SqlParameter("HydrantAddress", newHydrantAddress.Trim()) : new SqlParameter("HydrantAddress", DBNull.Value);
            SqlParameter newDistanceToInversionMHParameter = (newDistanceToInversionMH.Trim() != "") ? new SqlParameter("DistanceToInversionMH", newDistanceToInversionMH.Trim()) : new SqlParameter("DistanceToInversionMH", DBNull.Value);
            SqlParameter newRampsRequiredParameter = new SqlParameter("RampsRequired", newRampsRequired);
            SqlParameter newDegreeOfTrafficControlParameter = (newDegreeOfTrafficControl.Trim() != "") ? new SqlParameter("DegreeOfTrafficControl", newDegreeOfTrafficControl.Trim()) : new SqlParameter("DegreeOfTrafficControl", DBNull.Value);
            SqlParameter newStandarBypassParameter = new SqlParameter("StandarBypass", newStandarBypass);
            SqlParameter newHydroWireDetailsParameter = (newHydroWireDetails.Trim() != "") ? new SqlParameter("HydroWireDetails", newHydroWireDetails.Trim()) : new SqlParameter("HydroWireDetails", DBNull.Value);
            SqlParameter newPipeMaterialTypeParameter = (newPipeMaterialType.Trim() != "") ? new SqlParameter("PipeMaterialType", newPipeMaterialType.Trim()) : new SqlParameter("PipeMaterialType", DBNull.Value);
            SqlParameter newCappedLateralsParameter = (newCappedLaterals.HasValue) ? new SqlParameter("CappedLaterals", newCappedLaterals) : new SqlParameter("CappedLaterals", DBNull.Value);
            SqlParameter newRoboticPrepRequiredParameter = new SqlParameter("RoboticPrepRequired", newRoboticPrepRequired);
            SqlParameter newPipeSizeChangeParameter = new SqlParameter("PipeSizeChange", newPipeSizeChange);
            SqlParameter newM1CommentsParameter = (newM1Comments.Trim() != "") ? new SqlParameter("M1Comments", newM1Comments.Trim()) : new SqlParameter("M1Comments", DBNull.Value);
            SqlParameter newVideoDoneFromParameter = (newVideoDoneFrom.Trim() != "") ? new SqlParameter("VideoDoneFrom", newVideoDoneFrom.Trim()) : new SqlParameter("VideoDoneFrom", DBNull.Value);
            SqlParameter newToManholeParameter = (newToManhole.Trim() != "") ? new SqlParameter("ToManhole", newToManhole.Trim()) : new SqlParameter("ToManhole", DBNull.Value);
            SqlParameter newCutterDescriptionDuringMeasuringParameter = (newCutterDescriptionDuringMeasuring.Trim() != "") ? new SqlParameter("CutterDescriptionDuringMeasuring", newCutterDescriptionDuringMeasuring.Trim()) : new SqlParameter("CutterDescriptionDuringMeasuring", DBNull.Value);
            SqlParameter newFullLengthPointLinerParameter = new SqlParameter("FullLengthPointLiner", newFullLengthPointLiner);
            SqlParameter newBypassRequiredParameter = new SqlParameter("BypassRequired", newBypassRequired);
            SqlParameter newRoboticDistancesParameter = (newRoboticDistances.Trim() != "") ? new SqlParameter("RoboticDistances", newRoboticDistances.Trim()) : new SqlParameter("RoboticDistances", DBNull.Value);
            SqlParameter newTrafficControlDetailsParameter = (newTrafficControlDetails.Trim() != "") ? new SqlParameter("TrafficControlDetails", newTrafficControlDetails.Trim()) : new SqlParameter("TrafficControlDetails", DBNull.Value);
            SqlParameter newLineWithIDParameter = (newLineWithID.Trim() != "") ? new SqlParameter("LineWithID", newLineWithID.Trim()) : new SqlParameter("LineWithID", DBNull.Value);
            SqlParameter newSchoolZoneParameter = new SqlParameter("SchoolZone", newSchoolZone);
            SqlParameter newRestaurantAreaParameter = new SqlParameter("RestaurantArea", newRestaurantArea);
            SqlParameter newCarwashLaundromatParameter = new SqlParameter("CarwashLaundromat", newCarwashLaundromat);
            SqlParameter newHydroPulleyParameter = new SqlParameter("HydroPulley", newHydroPulley);
            SqlParameter newFridgeCartParameter = new SqlParameter("FridgeCart", newFridgeCart);
            SqlParameter newTwoInchPumpParameter = new SqlParameter("TwoInchPump", newTwoInchPump);
            SqlParameter newSixInchBypassParameter = new SqlParameter("SixInchBypass", newSixInchBypass);
            SqlParameter newScaffoldingParameter = new SqlParameter("Scaffolding", newScaffolding);
            SqlParameter newWinchExtensionParameter = new SqlParameter("WinchExtension", newWinchExtension);
            SqlParameter newExtraGeneratorParameter = new SqlParameter("ExtraGenerator", newExtraGenerator);
            SqlParameter newGreyCableExtensionParameter = new SqlParameter("GreyCableExtension", newGreyCableExtension);
            SqlParameter newEasementMatsParameter = new SqlParameter("EasementMats", newEasementMats);
            SqlParameter newMeasurementTypeParameter = (newMeasurementType.Trim() != "") ? new SqlParameter("MeasurementType", newMeasurementType.Trim()) : new SqlParameter("MeasurementType", DBNull.Value);
            SqlParameter newDropPipeParameter = new SqlParameter("DropPipe", newDropPipe);
            SqlParameter newDropPipeInvertDepthParameter = (newDropPipeInvertDepth.Trim() != "") ? new SqlParameter("DropPipeInvertDepth", newDropPipeInvertDepth.Trim()) : new SqlParameter("DropPipeInvertDepth", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newMeasuredFromManholeParameter = (newMeasuredFromManhole.Trim() != "") ? new SqlParameter("MeasuredFromManhole", newMeasuredFromManhole.Trim()) : new SqlParameter("MeasuredFromManhole", DBNull.Value);
            SqlParameter newMainLinedParameter = (newMainLined.Trim() != "") ? new SqlParameter("MainLined", newMainLined.Trim()) : new SqlParameter("MainLined", DBNull.Value);
            SqlParameter newBenchingIssueParameter = (newBenchingIssue.Trim() != "") ? new SqlParameter("BenchingIssue", newBenchingIssue.Trim()) : new SqlParameter("BenchingIssue", DBNull.Value);
            SqlParameter newArchivedParameter = new SqlParameter("Archived", newArchived);
            SqlParameter newScaledLength1Parameter = (newScaledLength1.HasValue) ? new SqlParameter("ScaledLength1", newScaledLength1) : new SqlParameter("ScaledLength1", DBNull.Value);
            SqlParameter newHistoryParameter = (newHistory.Trim() != "") ? new SqlParameter("History", newHistory.Trim()) : new SqlParameter("History", DBNull.Value);
            SqlParameter newNumLatsParameter = (newNumLats.HasValue) ? new SqlParameter("NumLats", newNumLats) : new SqlParameter("NumLats", DBNull.Value);
            SqlParameter newNotLinedYetParameter = (newNotLinedYet.HasValue) ? new SqlParameter("NotLinedYet", newNotLinedYet) : new SqlParameter("NotLinedYet", DBNull.Value);
            SqlParameter newAllMeasuredParameter = new SqlParameter("AllMeasured", newAllMeasured);
            SqlParameter newCityParameter = (newCity.Trim() != "") ? new SqlParameter("City", newCity.Trim()) : new SqlParameter("City", DBNull.Value);
            SqlParameter newProvStateParameter = (newProvState.Trim() != "") ? new SqlParameter("ProvState", newProvState.Trim()) : new SqlParameter("ProvState", DBNull.Value);
            SqlParameter newIssueWithLateralsParameter = (newIssueWithLaterals.Trim() != "") ? new SqlParameter("IssueWithLaterals", newIssueWithLaterals.Trim()) : new SqlParameter("IssueWithLaterals", DBNull.Value);
            SqlParameter newNotMeasuredYetParameter = (newNotMeasuredYet.HasValue) ? new SqlParameter("NotMeasuredYet", newNotMeasuredYet) : new SqlParameter("NotMeasuredYet", DBNull.Value);
            SqlParameter newNotDeliveredYetParameter = (newNotDeliveredYet.HasValue) ? new SqlParameter("NotDeliveredYet", newNotDeliveredYet) : new SqlParameter("NotDeliveredYet", DBNull.Value);
             
            string command = "UPDATE [dbo].[LFS_MASTER_AREA] SET [RecordID] = @RecordID, [ClientID] = @ClientID, "+
                " [COMPANIES_ID] = @COMPANIES_ID, [SubArea] = @SubArea, [Street] = @Street, [USMH] = @USMH, "+
                " [DSMH] = @DSMH, [Size_] = @Size_, [ScaledLength] = @ScaledLength, [P1Date] = @P1Date, "+
                " [ActualLength] = @ActualLength, [LiveLats] = @LiveLats, [CXIsRemoved] = @CXIsRemoved, "+
                " [M1Date] = @M1Date, [M2Date] = @M2Date, [InstallDate] = @InstallDate, [FinalVideo] = @FinalVideo" +
                ", [Comments] = @Comments, [IssueIdentified] = @IssueIdentified, [IssueResolved] = @IssueResolved, "+
                " [FullLengthLining] = @FullLengthLining, [SubcontractorLining] = @SubcontractorLining, "+
                " [OutOfScopeInArea] = @OutOfScopeInArea, [IssueGivenToBayCity] = @IssueGivenToBayCity, "+
                " [ConfirmedSize] = @ConfirmedSize, [InstallRate] = InstallRate, [DeadlineDate] = @DeadlineDate, "+
                " [ProposedLiningDate] = @ProposedLiningDate, [SalesIssue] = @SalesIssue, [LFSIssue] = @LFSIssue, "+
                " [ClientIssue] = @ClientIssue, [InvestigationIssue] = @InvestigationIssue,  [PointLining] = @PointLining, [Grouting] = @Grouting, [LateralLining] = @LateralLining, "+
                " [VacExDate] = @VacExDate, [PusherDate] = @PusherDate, [LinerOrdered] = @LinerOrdered, "+
                " [Restoration] = @Restoration, [GroutDate] = @GroutDate, [JLiner] = @JLiner, "+
                " [RehabAssessment] = @RehabAssessment, [EstimatedJoints] = @EstimatedJoints, "+
                " [JointsTestSealed] = @JointsTestSealed, [PreFlushDate] = @PreFlushDate, [PreVideoDate] = @PreVideoDate, "+
                " [USMHMN] = @USMHMN, [DSMHMN] = @DSMHMN, [USMHDepth] = @USMHDepth, [DSMHDepth] = @DSMHDepth, "+
                " [MeasurementsTakenBy] = @MeasurementsTakenBy, [SteelTapeThruPipe] = @SteelTapeThruPipe, "+
                " [USMHAtMouth1200] = @USMHAtMouth1200, [USMHAtMouth100] = @USMHAtMouth100,  [USMHAtMouth200] = @USMHAtMouth200, [USMHAtMouth300] = @USMHAtMouth300, "+
                " [USMHAtMouth400] = @USMHAtMouth400, [USMHAtMouth500] = @USMHAtMouth500,  [DSMHAtMouth1200] = @DSMHAtMouth1200, [DSMHAtMouth100] = @DSMHAtMouth100, "+
                " [DSMHAtMouth200] = @DSMHAtMouth200, [DSMHAtMouth300] = @DSMHAtMouth300, [DSMHAtMouth400] = @DSMHAtMouth400, [DSMHAtMouth500] = @DSMHAtMouth500, "+
                " [HydrantAddress] = @HydrantAddress, [DistanceToInversionMH] = @DistanceToInversionMH, [RampsRequired] = @RampsRequired, [DegreeOfTrafficControl] = @DegreeOfTrafficControl, "+
                " [StandarBypass] = @StandarBypass, [HydroWireDetails] = @HydroWireDetails, [PipeMaterialType] = @PipeMaterialType, [CappedLaterals] = @CappedLaterals,  [RoboticPrepRequired] = @RoboticPrepRequired, [PipeSizeChange] = @PipeSizeChange,  [M1Comments] = @M1Comments, [VideoDoneFrom] = @VideoDoneFrom, [ToManhole] = @ToManhole, "+
                " [CutterDescriptionDuringMeasuring] = @CutterDescriptionDuringMeasuring, [FullLengthPointLiner] = @FullLengthPointLiner, [BypassRequired] = @BypassRequired, "+
                " [RoboticDistances] = @RoboticDistances, [TrafficControlDetails] = @TrafficControlDetails, [LineWithID] = @LineWithID, [SchoolZone] = @SchoolZone, [RestaurantArea] = @RestaurantArea, "+
                " [CarwashLaundromat] = @CarwashLaundromat, [HydroPulley] = @HydroPulley, [FridgeCart] = @FridgeCart, "+
                " [TwoInchPump] = @TwoInchPump, [SixInchBypass] = @SixInchBypass, [Scaffolding] = @Scaffolding, "+
                " [WinchExtension] = @WinchExtension, [ExtraGenerator] = @ExtraGenerator, [GreyCableExtension] = @GreyCableExtension, [EasementMats] = @EasementMats, "+
                " [MeasurementType] = @MeasurementType, [DropPipe] = @DropPipe, [DropPipeInvertDepth] = @DropPipeInvertDepth, "+
                " [Deleted] = @Deleted, [MeasuredFromManhole] = @MeasuredFromManhole, [MainLined] = @MainLined, "+
                " [BenchingIssue] = @BenchingIssue, [Archived] = @Archived, [ScaledLength1] = @ScaledLength1, "+
                " [History] = @History, [NumLats] = @NumLats, [NotLinedYet] = @NotLinedYet, [AllMeasured] = @AllMeasured, "+
                " [City] = @City, [ProvState] = @ProvState, [IssueWithLaterals] = @IssueWithLaterals,  [NotMeasuredYet] = @NotMeasuredYet, [NotDeliveredYet] = @NotDeliveredYet "+
                " WHERE (([ID] = @Original_ID) AND  ([COMPANY_ID] = @Original_COMPANY_ID)) ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalIdParameter, originalCompanyIdParameter, originalRecordIdParameter, originalClientIdParameter, originalCompaniesIdParameter, originalSubAreaParameter, originalStreetParameter, originalUSMHParameter, originalDSMHParameter, originalSize_Parameter, originalScaledLengthParameter, originalP1DateParameter, originalActualLengthParameter, originalLiveLatsParameter, originalCXIsRemovedParameter, originalM1DateParameter, originalM2DateParameter, originalInstallDateParameter, originalFinalVideoParameter, originalCommentsParameter, originalIssueIdentifiedParameter, originalIssueResolvedParameter, originalFullLengthLiningParameter, originalSubcontractorLiningParameter, originalOutOfScopeInAreaParameter, originalIssueGivenToBayCityParameter, originalConfirmedSizeParameter, originalInstallRateParameter, originalDeadlineDateParameter, originalProposedLiningDateParameter, originalSalesIssueParameter, originalLFSIssueParameter, originalClientIssueParameter, originalInvestigationIssueParameter, originalPointLiningParameter, originalGroutingParameter, originalLateralLiningParameter, originalVacExDateParameter, originalPusherDateParameter, originalLinerOrderedParameter, originalRestorationParameter, originalGroutDateParameter, originalJLinerParameter, originalRehabAssessmentParameter, originalEstimatedJointsParameter, originalJointsTestSealedParameter, originalPreFlushDateParameter, originalPreVideoDateParameter, originalUSMHMNParameter, originalDSMHMNParameter, originalUSMHDepthParameter, originalDSMHDepthParameter, originalMeasurementsTakenByParameter, originalSteelTapeThruPipeParameter, originalUSMHAtMouth1200Parameter, originalUSMHAtMouth100Parameter, originalUSMHAtMouth200Parameter, originalUSMHAtMouth300Parameter, originalUSMHAtMouth400Parameter, originalUSMHAtMouth500Parameter, originalDSMHAtMouth1200Parameter, originalDSMHAtMouth100Parameter, originalDSMHAtMouth200Parameter, originalDSMHAtMouth300Parameter, originalDSMHAtMouth400Parameter, originalDSMHAtMouth500Parameter, originalHydrantAddressParameter, originalDistanceToInversionMHParameter, originalRampsRequiredParameter, originalDegreeOfTrafficControlParameter, originalStandarBypassParameter, originalHydroWireDetailsParameter, originalPipeMaterialTypeParameter, originalCappedLateralsParameter, originalRoboticPrepRequiredParameter, originalPipeSizeChangeParameter, originalM1CommentsParameter, originalVideoDoneFromParameter, originalToManholeParameter, originalCutterDescriptionDuringMeasuringParameter, originalFullLengthPointLinerParameter, originalBypassRequiredParameter, originalRoboticDistancesParameter, originalTrafficControlDetailsParameter, originalLineWithIDParameter, originalSchoolZoneParameter, originalRestaurantAreaParameter, originalCarwashLaundromatParameter, originalHydroPulleyParameter, originalFridgeCartParameter, originalTwoInchPumpParameter, originalSixInchBypassParameter, originalScaffoldingParameter, originalWinchExtensionParameter, originalExtraGeneratorParameter, originalGreyCableExtensionParameter, originalEasementMatsParameter, originalMeasurementTypeParameter, originalDropPipeParameter, originalDropPipeInvertDepthParameter, originalDeletedParameter, originalMeasuredFromManholeParameter, originalMainLinedParameter, originalBenchingIssueParameter, originalArchivedParameter, originalScaledLength1Parameter, originalHistoryParameter, originalNumLatsParameter, originalNotLinedYetParameter, originalAllMeasuredParameter, originalCityParameter, originalProvStateParameter, originalIssueWithLateralsParameter, originalNotMeasuredYetParameter, originalNotDeliveredYetParameter,
                newIdParameter, newCompanyIdParameter, newRecordIdParameter, newClientIdParameter, newCompaniesIdParameter, newSubAreaParameter, newStreetParameter, newUSMHParameter, newDSMHParameter, newSize_Parameter, newScaledLengthParameter, newP1DateParameter, newActualLengthParameter, newLiveLatsParameter, newCXIsRemovedParameter, newM1DateParameter, newM2DateParameter, newInstallDateParameter, newFinalVideoParameter, newCommentsParameter, newIssueIdentifiedParameter, newIssueResolvedParameter, newFullLengthLiningParameter, newSubcontractorLiningParameter, newOutOfScopeInAreaParameter, newIssueGivenToBayCityParameter, newConfirmedSizeParameter, newInstallRateParameter, newDeadlineDateParameter, newProposedLiningDateParameter, newSalesIssueParameter, newLFSIssueParameter, newClientIssueParameter, newInvestigationIssueParameter, newPointLiningParameter, newGroutingParameter, newLateralLiningParameter, newVacExDateParameter, newPusherDateParameter, newLinerOrderedParameter, newRestorationParameter, newGroutDateParameter, newJLinerParameter, newRehabAssessmentParameter, newEstimatedJointsParameter, newJointsTestSealedParameter, newPreFlushDateParameter, newPreVideoDateParameter, newUSMHMNParameter, newDSMHMNParameter, newUSMHDepthParameter, newDSMHDepthParameter, newMeasurementsTakenByParameter, newSteelTapeThruPipeParameter, newUSMHAtMouth1200Parameter, newUSMHAtMouth100Parameter, newUSMHAtMouth200Parameter, newUSMHAtMouth300Parameter, newUSMHAtMouth400Parameter, newUSMHAtMouth500Parameter, newDSMHAtMouth1200Parameter, newDSMHAtMouth100Parameter, newDSMHAtMouth200Parameter, newDSMHAtMouth300Parameter, newDSMHAtMouth400Parameter, newDSMHAtMouth500Parameter, newHydrantAddressParameter, newDistanceToInversionMHParameter, newRampsRequiredParameter, newDegreeOfTrafficControlParameter, newStandarBypassParameter, newHydroWireDetailsParameter, newPipeMaterialTypeParameter, newCappedLateralsParameter, newRoboticPrepRequiredParameter, newPipeSizeChangeParameter, newM1CommentsParameter, newVideoDoneFromParameter, newToManholeParameter, newCutterDescriptionDuringMeasuringParameter, newFullLengthPointLinerParameter, newBypassRequiredParameter, newRoboticDistancesParameter, newTrafficControlDetailsParameter, newLineWithIDParameter, newSchoolZoneParameter, newRestaurantAreaParameter, newCarwashLaundromatParameter, newHydroPulleyParameter, newFridgeCartParameter, newTwoInchPumpParameter, newSixInchBypassParameter, newScaffoldingParameter, newWinchExtensionParameter, newExtraGeneratorParameter, newGreyCableExtensionParameter, newEasementMatsParameter, newMeasurementTypeParameter, newDropPipeParameter, newDropPipeInvertDepthParameter, newDeletedParameter, newMeasuredFromManholeParameter, newMainLinedParameter, newBenchingIssueParameter, newArchivedParameter, newScaledLength1Parameter, newHistoryParameter, newNumLatsParameter, newNotLinedYetParameter, newAllMeasuredParameter, newCityParameter, newProvStateParameter, newIssueWithLateralsParameter, newNotMeasuredYetParameter, newNotDeliveredYetParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }




    }
}
