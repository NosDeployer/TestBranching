using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.CWP.Tools;
using LiquiForce.LFSLive.CWP.BL;

namespace LiquiForce.LFSLive.CWP.DatabaseGateway
{
    /// <summary>
    /// LFSRecordGateway
    /// </summary>
	public class LFSRecordGateway
	{
		///////////////////////////////////////////////////////////////////////////
		/// PROPERTIES AND FIELDS
		///
		
		// Connection
		private string ConnectionString;
		protected System.Data.SqlClient.SqlConnection dcConnection;

		// Data access components for LFS_MASTER_AREA		
		protected System.Data.SqlClient.SqlDataAdapter daLFSMasterArea;
		protected System.Data.SqlClient.SqlCommand cmdLFSMasterAreaSelect;
		protected System.Data.SqlClient.SqlCommand cmdLFSMasterAreaInsert;
		protected System.Data.SqlClient.SqlCommand cmdLFSMasterAreaUpdate;
		protected System.Data.SqlClient.SqlCommand cmdLFSMasterAreaDelete;

		// Data access components for LFS_POINT_REPAIRS
		protected System.Data.SqlClient.SqlDataAdapter daLFSPointRepairs;
		protected System.Data.SqlClient.SqlCommand cmdLFSPointRepairsSelect;
		protected System.Data.SqlClient.SqlCommand cmdLFSPointRepairsInsert;
		protected System.Data.SqlClient.SqlCommand cmdLFSPointRepairsUpdate;
		protected System.Data.SqlClient.SqlCommand cmdLFSPointRepairsDelete;

        // Data access components for LFS_M2_TABLES		
		protected System.Data.SqlClient.SqlDataAdapter daLFSM2Tables;
		protected System.Data.SqlClient.SqlCommand cmdLFSM2TablesSelect;
		protected System.Data.SqlClient.SqlCommand cmdLFSM2TablesInsert;
		protected System.Data.SqlClient.SqlCommand cmdLFSM2TablesUpdate;
		protected System.Data.SqlClient.SqlCommand cmdLFSM2TablesDelete;
	
		// Data access components for LFS_JUNCTION_LINER
		protected System.Data.SqlClient.SqlDataAdapter daLFSJunctionLiner;
		protected System.Data.SqlClient.SqlCommand cmdLFSJunctionLinerSelect;
		protected System.Data.SqlClient.SqlCommand cmdLFSJunctionLinerInsert;
		protected System.Data.SqlClient.SqlCommand cmdLFSJunctionLinerUpdate;
		protected System.Data.SqlClient.SqlCommand cmdLFSJunctionLinerDelete;
        
        // Data access components for LFS_JUNCTION_LINER2
        protected System.Data.SqlClient.SqlDataAdapter daLFSJunctionLiner2;
        protected System.Data.SqlClient.SqlCommand cmdLFSJunctionLiner2Select;
        protected System.Data.SqlClient.SqlCommand cmdLFSJunctionLiner2Insert;
        protected System.Data.SqlClient.SqlCommand cmdLFSJunctionLiner2Update;
        protected System.Data.SqlClient.SqlCommand cmdLFSJunctionLiner2Delete;
        
		// Data access components for LFS_MASTER_AREA_RCT
		protected System.Data.SqlClient.SqlDataAdapter daLfsMasterAreaRct;
		protected System.Data.SqlClient.SqlCommand cmdLfsMasterAreaRctSelect;
		protected System.Data.SqlClient.SqlCommand cmdLfsMasterAreaRctInsert;
		protected System.Data.SqlClient.SqlCommand cmdLfsMasterAreaRctUpdate;
		protected System.Data.SqlClient.SqlCommand cmdLfsMasterAreaRctDelete;
		
		// Data access components for LFS_POINT_REPAIRS_RCT		
		protected System.Data.SqlClient.SqlDataAdapter daLfsPointRepairsRct;
		protected System.Data.SqlClient.SqlCommand cmdLfsPointRepairsRctSelect;
		protected System.Data.SqlClient.SqlCommand cmdLfsPointRepairsRctInsert;
		protected System.Data.SqlClient.SqlCommand cmdLfsPointRepairsRctUpdate;
		protected System.Data.SqlClient.SqlCommand cmdLfsPointRepairsRctDelete;
			
		// Data access components for LFS_M2_TABLES_RCT		
		protected System.Data.SqlClient.SqlDataAdapter daLfsM2TablesRct;
		protected System.Data.SqlClient.SqlCommand cmdLfsM2TablesRctSelect;
		protected System.Data.SqlClient.SqlCommand cmdLfsM2TablesRctInsert;
		protected System.Data.SqlClient.SqlCommand cmdLfsM2TablesRctUpdate;
		protected System.Data.SqlClient.SqlCommand cmdLfsM2TablesRctDelete;
		
		// Data access components for LFS_JUNCTION_LINER_RCT
		protected System.Data.SqlClient.SqlDataAdapter daLfsJunctionLinerRct;
		protected System.Data.SqlClient.SqlCommand cmdLfsJunctionLinerRctSelect;
		protected System.Data.SqlClient.SqlCommand cmdLfsJunctionLinerRctInsert;
		protected System.Data.SqlClient.SqlCommand cmdLfsJunctionLinerRctUpdate;
		protected System.Data.SqlClient.SqlCommand cmdLfsJunctionLinerRctDelete;
		





		///////////////////////////////////////////////////////////////////////////
		/// CONSTRUCTORS
		///

		//
		// Default
		//
		public LFSRecordGateway()
		{
			//--- Get the connection string
			AppSettingsReader appSettingReader = new AppSettingsReader();
			ConnectionString = appSettingReader.GetValue("ConnectionString", typeof(System.String)).ToString();

			//--- Initialize data provider
			InitializeDataProvider();
		}

		#region Initialize data provider

		//
		// InitializeDataProvider
		//
		private void InitializeDataProvider()
		{
			//--- Instantiate components
			this.dcConnection = new System.Data.SqlClient.SqlConnection();

			this.daLFSMasterArea = new System.Data.SqlClient.SqlDataAdapter();
			this.cmdLFSMasterAreaDelete = new System.Data.SqlClient.SqlCommand();
			this.cmdLFSMasterAreaInsert = new System.Data.SqlClient.SqlCommand();
			this.cmdLFSMasterAreaSelect = new System.Data.SqlClient.SqlCommand();
			this.cmdLFSMasterAreaUpdate = new System.Data.SqlClient.SqlCommand();

			this.daLFSPointRepairs = new System.Data.SqlClient.SqlDataAdapter();
			this.cmdLFSPointRepairsSelect = new System.Data.SqlClient.SqlCommand();
			this.cmdLFSPointRepairsInsert = new System.Data.SqlClient.SqlCommand();
			this.cmdLFSPointRepairsUpdate = new System.Data.SqlClient.SqlCommand();
			this.cmdLFSPointRepairsDelete = new System.Data.SqlClient.SqlCommand();

			this.daLFSM2Tables = new System.Data.SqlClient.SqlDataAdapter();
			this.cmdLFSM2TablesSelect = new System.Data.SqlClient.SqlCommand();
			this.cmdLFSM2TablesInsert = new System.Data.SqlClient.SqlCommand();
			this.cmdLFSM2TablesUpdate = new System.Data.SqlClient.SqlCommand();
			this.cmdLFSM2TablesDelete = new System.Data.SqlClient.SqlCommand();

			this.daLFSJunctionLiner = new System.Data.SqlClient.SqlDataAdapter();
			this.cmdLFSJunctionLinerSelect = new System.Data.SqlClient.SqlCommand();
			this.cmdLFSJunctionLinerInsert = new System.Data.SqlClient.SqlCommand();
			this.cmdLFSJunctionLinerUpdate = new System.Data.SqlClient.SqlCommand();
			this.cmdLFSJunctionLinerDelete = new System.Data.SqlClient.SqlCommand();

            this.daLFSJunctionLiner2 = new System.Data.SqlClient.SqlDataAdapter();
            this.cmdLFSJunctionLiner2Select = new System.Data.SqlClient.SqlCommand();
            this.cmdLFSJunctionLiner2Insert = new System.Data.SqlClient.SqlCommand();
            this.cmdLFSJunctionLiner2Update = new System.Data.SqlClient.SqlCommand();
            this.cmdLFSJunctionLiner2Delete = new System.Data.SqlClient.SqlCommand();

            this.daLfsMasterAreaRct = new System.Data.SqlClient.SqlDataAdapter();
			this.cmdLfsMasterAreaRctSelect = new System.Data.SqlClient.SqlCommand();
			this.cmdLfsMasterAreaRctInsert = new System.Data.SqlClient.SqlCommand();
			this.cmdLfsMasterAreaRctUpdate = new System.Data.SqlClient.SqlCommand();
			this.cmdLfsMasterAreaRctDelete = new System.Data.SqlClient.SqlCommand();

			this.daLfsPointRepairsRct = new System.Data.SqlClient.SqlDataAdapter();
			this.cmdLfsPointRepairsRctSelect = new System.Data.SqlClient.SqlCommand();
			this.cmdLfsPointRepairsRctInsert = new System.Data.SqlClient.SqlCommand();
			this.cmdLfsPointRepairsRctUpdate = new System.Data.SqlClient.SqlCommand();
			this.cmdLfsPointRepairsRctDelete = new System.Data.SqlClient.SqlCommand();

			this.daLfsM2TablesRct = new System.Data.SqlClient.SqlDataAdapter();
			this.cmdLfsM2TablesRctSelect = new System.Data.SqlClient.SqlCommand();
			this.cmdLfsM2TablesRctInsert = new System.Data.SqlClient.SqlCommand();
			this.cmdLfsM2TablesRctUpdate = new System.Data.SqlClient.SqlCommand();
			this.cmdLfsM2TablesRctDelete = new System.Data.SqlClient.SqlCommand();

			this.daLfsJunctionLinerRct = new System.Data.SqlClient.SqlDataAdapter();
			this.cmdLfsJunctionLinerRctSelect = new System.Data.SqlClient.SqlCommand();
			this.cmdLfsJunctionLinerRctInsert = new System.Data.SqlClient.SqlCommand();
			this.cmdLfsJunctionLinerRctUpdate = new System.Data.SqlClient.SqlCommand();
			this.cmdLfsJunctionLinerRctDelete = new System.Data.SqlClient.SqlCommand();

			//--- dcConnection
			this.dcConnection.ConnectionString = ConnectionString;

			//--- daLFSMasterArea ******************************************************************************
            this.daLFSMasterArea.SelectCommand = this.cmdLFSMasterAreaSelect;
            this.daLFSMasterArea.InsertCommand = this.cmdLFSMasterAreaInsert;
            this.daLFSMasterArea.UpdateCommand = this.cmdLFSMasterAreaUpdate;
            this.daLFSMasterArea.DeleteCommand = this.cmdLFSMasterAreaDelete;

            //--- ... TableMappings
            System.Data.Common.DataTableMapping lfsMasterAreaTableMapping = new System.Data.Common.DataTableMapping();
            lfsMasterAreaTableMapping.SourceTable = "Table";
            lfsMasterAreaTableMapping.DataSetTable = "LFS_MASTER_AREA";
            lfsMasterAreaTableMapping.ColumnMappings.Add("ID", "ID");
            lfsMasterAreaTableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            lfsMasterAreaTableMapping.ColumnMappings.Add("RecordID", "RecordID");
            lfsMasterAreaTableMapping.ColumnMappings.Add("ClientID", "ClientID");
            lfsMasterAreaTableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            lfsMasterAreaTableMapping.ColumnMappings.Add("SubArea", "SubArea");
            lfsMasterAreaTableMapping.ColumnMappings.Add("Street", "Street");
            lfsMasterAreaTableMapping.ColumnMappings.Add("USMH", "USMH");
            lfsMasterAreaTableMapping.ColumnMappings.Add("DSMH", "DSMH");
            lfsMasterAreaTableMapping.ColumnMappings.Add("Size_", "Size_");
            lfsMasterAreaTableMapping.ColumnMappings.Add("ScaledLength", "ScaledLength");
            lfsMasterAreaTableMapping.ColumnMappings.Add("P1Date", "P1Date");
            lfsMasterAreaTableMapping.ColumnMappings.Add("ActualLength", "ActualLength");
            lfsMasterAreaTableMapping.ColumnMappings.Add("LiveLats", "LiveLats");
            lfsMasterAreaTableMapping.ColumnMappings.Add("CXIsRemoved", "CXIsRemoved");
            lfsMasterAreaTableMapping.ColumnMappings.Add("M1Date", "M1Date");
            lfsMasterAreaTableMapping.ColumnMappings.Add("M2Date", "M2Date");
            lfsMasterAreaTableMapping.ColumnMappings.Add("InstallDate", "InstallDate");
            lfsMasterAreaTableMapping.ColumnMappings.Add("FinalVideo", "FinalVideo");
            lfsMasterAreaTableMapping.ColumnMappings.Add("Comments", "Comments");
            lfsMasterAreaTableMapping.ColumnMappings.Add("IssueIdentified", "IssueIdentified");
            lfsMasterAreaTableMapping.ColumnMappings.Add("IssueResolved", "IssueResolved");
            lfsMasterAreaTableMapping.ColumnMappings.Add("FullLengthLining", "FullLengthLining");
            lfsMasterAreaTableMapping.ColumnMappings.Add("SubcontractorLining", "SubcontractorLining");
            lfsMasterAreaTableMapping.ColumnMappings.Add("OutOfScopeInArea", "OutOfScopeInArea");
            lfsMasterAreaTableMapping.ColumnMappings.Add("IssueGivenToBayCity", "IssueGivenToBayCity");
            lfsMasterAreaTableMapping.ColumnMappings.Add("ConfirmedSize", "ConfirmedSize");
            lfsMasterAreaTableMapping.ColumnMappings.Add("InstallRate", "InstallRate");
            lfsMasterAreaTableMapping.ColumnMappings.Add("DeadlineDate", "DeadlineDate");
            lfsMasterAreaTableMapping.ColumnMappings.Add("ProposedLiningDate", "ProposedLiningDate");
            lfsMasterAreaTableMapping.ColumnMappings.Add("SalesIssue", "SalesIssue");
            lfsMasterAreaTableMapping.ColumnMappings.Add("LFSIssue", "LFSIssue");
            lfsMasterAreaTableMapping.ColumnMappings.Add("ClientIssue", "ClientIssue");
            lfsMasterAreaTableMapping.ColumnMappings.Add("InvestigationIssue", "InvestigationIssue");
            lfsMasterAreaTableMapping.ColumnMappings.Add("PointLining", "PointLining");
            lfsMasterAreaTableMapping.ColumnMappings.Add("Grouting", "Grouting");
            lfsMasterAreaTableMapping.ColumnMappings.Add("LateralLining", "LateralLining");
            lfsMasterAreaTableMapping.ColumnMappings.Add("VacExDate", "VacExDate");
            lfsMasterAreaTableMapping.ColumnMappings.Add("PusherDate", "PusherDate");
            lfsMasterAreaTableMapping.ColumnMappings.Add("LinerOrdered", "LinerOrdered");
            lfsMasterAreaTableMapping.ColumnMappings.Add("Restoration", "Restoration");
            lfsMasterAreaTableMapping.ColumnMappings.Add("GroutDate", "GroutDate");
            lfsMasterAreaTableMapping.ColumnMappings.Add("JLiner", "JLiner");
            lfsMasterAreaTableMapping.ColumnMappings.Add("RehabAssessment", "RehabAssessment");
            lfsMasterAreaTableMapping.ColumnMappings.Add("EstimatedJoints", "EstimatedJoints");
            lfsMasterAreaTableMapping.ColumnMappings.Add("JointsTestSealed", "JointsTestSealed");
            lfsMasterAreaTableMapping.ColumnMappings.Add("PreFlushDate", "PreFlushDate");
            lfsMasterAreaTableMapping.ColumnMappings.Add("PreVideoDate", "PreVideoDate");
            lfsMasterAreaTableMapping.ColumnMappings.Add("USMHMN", "USMHMN");
            lfsMasterAreaTableMapping.ColumnMappings.Add("DSMHMN", "DSMHMN");
            lfsMasterAreaTableMapping.ColumnMappings.Add("USMHDepth", "USMHDepth");
            lfsMasterAreaTableMapping.ColumnMappings.Add("DSMHDepth", "DSMHDepth");
            lfsMasterAreaTableMapping.ColumnMappings.Add("MeasurementsTakenBy", "MeasurementsTakenBy");
            lfsMasterAreaTableMapping.ColumnMappings.Add("SteelTapeThruPipe", "SteelTapeThruPipe");
            lfsMasterAreaTableMapping.ColumnMappings.Add("USMHAtMouth1200", "USMHAtMouth1200");
            lfsMasterAreaTableMapping.ColumnMappings.Add("USMHAtMouth100", "USMHAtMouth100");
            lfsMasterAreaTableMapping.ColumnMappings.Add("USMHAtMouth200", "USMHAtMouth200");
            lfsMasterAreaTableMapping.ColumnMappings.Add("USMHAtMouth300", "USMHAtMouth300");
            lfsMasterAreaTableMapping.ColumnMappings.Add("USMHAtMouth400", "USMHAtMouth400");
            lfsMasterAreaTableMapping.ColumnMappings.Add("USMHAtMouth500", "USMHAtMouth500");
            lfsMasterAreaTableMapping.ColumnMappings.Add("DSMHAtMouth1200", "DSMHAtMouth1200");
            lfsMasterAreaTableMapping.ColumnMappings.Add("DSMHAtMouth100", "DSMHAtMouth100");
            lfsMasterAreaTableMapping.ColumnMappings.Add("DSMHAtMouth200", "DSMHAtMouth200");
            lfsMasterAreaTableMapping.ColumnMappings.Add("DSMHAtMouth300", "DSMHAtMouth300");
            lfsMasterAreaTableMapping.ColumnMappings.Add("DSMHAtMouth400", "DSMHAtMouth400");
            lfsMasterAreaTableMapping.ColumnMappings.Add("DSMHAtMouth500", "DSMHAtMouth500");
            lfsMasterAreaTableMapping.ColumnMappings.Add("HydrantAddress", "HydrantAddress");
            lfsMasterAreaTableMapping.ColumnMappings.Add("DistanceToInversionMH", "DistanceToInversionMH");
            lfsMasterAreaTableMapping.ColumnMappings.Add("RampsRequired", "RampsRequired");
            lfsMasterAreaTableMapping.ColumnMappings.Add("DegreeOfTrafficControl", "DegreeOfTrafficControl");
            lfsMasterAreaTableMapping.ColumnMappings.Add("StandarBypass", "StandarBypass");
            lfsMasterAreaTableMapping.ColumnMappings.Add("HydroWireDetails", "HydroWireDetails");
            lfsMasterAreaTableMapping.ColumnMappings.Add("PipeMaterialType", "PipeMaterialType");
            lfsMasterAreaTableMapping.ColumnMappings.Add("CappedLaterals", "CappedLaterals");
            lfsMasterAreaTableMapping.ColumnMappings.Add("RoboticPrepRequired", "RoboticPrepRequired");
            lfsMasterAreaTableMapping.ColumnMappings.Add("PipeSizeChange", "PipeSizeChange");
            lfsMasterAreaTableMapping.ColumnMappings.Add("M1Comments", "M1Comments");
            lfsMasterAreaTableMapping.ColumnMappings.Add("VideoDoneFrom", "VideoDoneFrom");
            lfsMasterAreaTableMapping.ColumnMappings.Add("ToManhole", "ToManhole");
            lfsMasterAreaTableMapping.ColumnMappings.Add("CutterDescriptionDuringMeasuring", "CutterDescriptionDuringMeasuring");
            lfsMasterAreaTableMapping.ColumnMappings.Add("FullLengthPointLiner", "FullLengthPointLiner");
            lfsMasterAreaTableMapping.ColumnMappings.Add("BypassRequired", "BypassRequired");
            lfsMasterAreaTableMapping.ColumnMappings.Add("RoboticDistances", "RoboticDistances");
            lfsMasterAreaTableMapping.ColumnMappings.Add("TrafficControlDetails", "TrafficControlDetails");
            lfsMasterAreaTableMapping.ColumnMappings.Add("LineWithID", "LineWithID");
            lfsMasterAreaTableMapping.ColumnMappings.Add("SchoolZone", "SchoolZone");
            lfsMasterAreaTableMapping.ColumnMappings.Add("RestaurantArea", "RestaurantArea");
            lfsMasterAreaTableMapping.ColumnMappings.Add("CarwashLaundromat", "CarwashLaundromat");
            lfsMasterAreaTableMapping.ColumnMappings.Add("HydroPulley", "HydroPulley");
            lfsMasterAreaTableMapping.ColumnMappings.Add("FridgeCart", "FridgeCart");
            lfsMasterAreaTableMapping.ColumnMappings.Add("TwoInchPump", "TwoInchPump");
            lfsMasterAreaTableMapping.ColumnMappings.Add("SixInchBypass", "SixInchBypass");
            lfsMasterAreaTableMapping.ColumnMappings.Add("Scaffolding", "Scaffolding");
            lfsMasterAreaTableMapping.ColumnMappings.Add("WinchExtension", "WinchExtension");
            lfsMasterAreaTableMapping.ColumnMappings.Add("ExtraGenerator", "ExtraGenerator");
            lfsMasterAreaTableMapping.ColumnMappings.Add("GreyCableExtension", "GreyCableExtension");
            lfsMasterAreaTableMapping.ColumnMappings.Add("EasementMats", "EasementMats");
            lfsMasterAreaTableMapping.ColumnMappings.Add("MeasurementType", "MeasurementType");
            lfsMasterAreaTableMapping.ColumnMappings.Add("DropPipe", "DropPipe");
            lfsMasterAreaTableMapping.ColumnMappings.Add("DropPipeInvertDepth", "DropPipeInvertDepth");
            lfsMasterAreaTableMapping.ColumnMappings.Add("Deleted", "Deleted");
            lfsMasterAreaTableMapping.ColumnMappings.Add("MeasuredFromManhole", "MeasuredFromManhole");
            lfsMasterAreaTableMapping.ColumnMappings.Add("MainLined", "MainLined");
            lfsMasterAreaTableMapping.ColumnMappings.Add("BenchingIssue", "BenchingIssue");
            lfsMasterAreaTableMapping.ColumnMappings.Add("Archived", "Archived");
            lfsMasterAreaTableMapping.ColumnMappings.Add("ScaledLength1", "ScaledLength1");
            lfsMasterAreaTableMapping.ColumnMappings.Add("History", "History");
            lfsMasterAreaTableMapping.ColumnMappings.Add("NumLats", "NumLats");
            lfsMasterAreaTableMapping.ColumnMappings.Add("NotLinedYet", "NotLinedYet");
            lfsMasterAreaTableMapping.ColumnMappings.Add("AllMeasured", "AllMeasured");
            lfsMasterAreaTableMapping.ColumnMappings.Add("City", "City");
            lfsMasterAreaTableMapping.ColumnMappings.Add("ProvState", "ProvState");
            this.daLFSMasterArea.TableMappings.Add(lfsMasterAreaTableMapping);
            			
			//--- ... cmdLFSMasterAreaSelect
            this.cmdLFSMasterAreaSelect.Connection = this.dcConnection;
            this.cmdLFSMasterAreaSelect.CommandText = @"SELECT ID, COMPANY_ID, RecordID, ClientID, COMPANIES_ID, SubArea, Street, USMH, DSMH, Size_, ScaledLength, P1Date, ActualLength, LiveLats, CXIsRemoved, M1Date, M2Date, InstallDate, FinalVideo, Comments, IssueIdentified, IssueResolved, FullLengthLining, SubcontractorLining, OutOfScopeInArea, IssueGivenToBayCity, ConfirmedSize, InstallRate, DeadlineDate, ProposedLiningDate, SalesIssue, LFSIssue, ClientIssue, InvestigationIssue, PointLining, Grouting, LateralLining, VacExDate, PusherDate, LinerOrdered, Restoration, GroutDate, JLiner, RehabAssessment, EstimatedJoints, JointsTestSealed, PreFlushDate, PreVideoDate, USMHMN, DSMHMN, USMHDepth, DSMHDepth, MeasurementsTakenBy, SteelTapeThruPipe, USMHAtMouth1200, USMHAtMouth100, USMHAtMouth200, USMHAtMouth300, USMHAtMouth400, USMHAtMouth500, DSMHAtMouth1200, DSMHAtMouth100, DSMHAtMouth200, DSMHAtMouth300, DSMHAtMouth400, DSMHAtMouth500, HydrantAddress, DistanceToInversionMH, RampsRequired, DegreeOfTrafficControl, StandarBypass, HydroWireDetails, PipeMaterialType, CappedLaterals, RoboticPrepRequired, PipeSizeChange, M1Comments, VideoDoneFrom, ToManhole, CutterDescriptionDuringMeasuring, FullLengthPointLiner, BypassRequired, RoboticDistances, TrafficControlDetails, LineWithID, SchoolZone, RestaurantArea, CarwashLaundromat, HydroPulley, FridgeCart, TwoInchPump, SixInchBypass, Scaffolding, WinchExtension, ExtraGenerator, GreyCableExtension, EasementMats, MeasurementType, DropPipe, DropPipeInvertDepth, Deleted, MeasuredFromManhole, MainLined, BenchingIssue, Archived, ScaledLength1, History, NumLats, NotLinedYet, AllMeasured, City, ProvState FROM LFS_MASTER_AREA";
			
			//--- ... cmdLFSMasterAreaInsert
            this.cmdLFSMasterAreaInsert.Connection = this.dcConnection;
            this.cmdLFSMasterAreaInsert.CommandText = "INSERT INTO [dbo].[LFS_MASTER_AREA] ([ID], [COMPANY_ID], [RecordID], [ClientID], " +
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
                "], [ProvState]) VALUES (@ID, @COMPANY_ID, @RecordID, @ClientID, @COMPANIES_ID, @" +
                "SubArea, @Street, @USMH, @DSMH, @Size_, @ScaledLength, @P1Date, @ActualLength, @" +
                "LiveLats, @CXIsRemoved, @M1Date, @M2Date, @InstallDate, @FinalVideo, @Comments, " +
                "@IssueIdentified, @IssueResolved, @FullLengthLining, @SubcontractorLining, @OutO" +
                "fScopeInArea, @IssueGivenToBayCity, @ConfirmedSize, @InstallRate, @DeadlineDate," +
                " @ProposedLiningDate, @SalesIssue, @LFSIssue, @ClientIssue, @InvestigationIssue," +
                " @PointLining, @Grouting, @LateralLining, @VacExDate, @PusherDate, @LinerOrdered" +
                ", @Restoration, @GroutDate, @JLiner, @RehabAssessment, @EstimatedJoints, @Joints" +
                "TestSealed, @PreFlushDate, @PreVideoDate, @USMHMN, @DSMHMN, @USMHDepth, @DSMHDep" +
                "th, @MeasurementsTakenBy, @SteelTapeThruPipe, @USMHAtMouth1200, @USMHAtMouth100," +
                " @USMHAtMouth200, @USMHAtMouth300, @USMHAtMouth400, @USMHAtMouth500, @DSMHAtMout" +
                "h1200, @DSMHAtMouth100, @DSMHAtMouth200, @DSMHAtMouth300, @DSMHAtMouth400, @DSMH" +
                "AtMouth500, @HydrantAddress, @DistanceToInversionMH, @RampsRequired, @DegreeOfTr" +
                "afficControl, @StandarBypass, @HydroWireDetails, @PipeMaterialType, @CappedLater" +
                "als, @RoboticPrepRequired, @PipeSizeChange, @M1Comments, @VideoDoneFrom, @ToManh" +
                "ole, @CutterDescriptionDuringMeasuring, @FullLengthPointLiner, @BypassRequired, " +
                "@RoboticDistances, @TrafficControlDetails, @LineWithID, @SchoolZone, @Restaurant" +
                "Area, @CarwashLaundromat, @HydroPulley, @FridgeCart, @TwoInchPump, @SixInchBypas" +
                "s, @Scaffolding, @WinchExtension, @ExtraGenerator, @GreyCableExtension, @Easemen" +
                "tMats, @MeasurementType, @DropPipe, @DropPipeInvertDepth, @Deleted, @MeasuredFro" +
                "mManhole, @MainLined, @BenchingIssue, @Archived, @ScaledLength1, @History, @NumL" +
                "ats, @NotLinedYet, @AllMeasured, @City, @ProvState);\r\nSELECT ID, COMPANY_ID, Rec" +
                "ordID, ClientID, COMPANIES_ID, SubArea, Street, USMH, DSMH, Size_, ScaledLength," +
                " P1Date, ActualLength, LiveLats, CXIsRemoved, M1Date, M2Date, InstallDate, Final" +
                "Video, Comments, IssueIdentified, IssueResolved, FullLengthLining, Subcontractor" +
                "Lining, OutOfScopeInArea, IssueGivenToBayCity, ConfirmedSize, InstallRate, Deadl" +
                "ineDate, ProposedLiningDate, SalesIssue, LFSIssue, ClientIssue, InvestigationIss" +
                "ue, PointLining, Grouting, LateralLining, VacExDate, PusherDate, LinerOrdered, R" +
                "estoration, GroutDate, JLiner, RehabAssessment, EstimatedJoints, JointsTestSeale" +
                "d, PreFlushDate, PreVideoDate, USMHMN, DSMHMN, USMHDepth, DSMHDepth, Measurement" +
                "sTakenBy, SteelTapeThruPipe, USMHAtMouth1200, USMHAtMouth100, USMHAtMouth200, US" +
                "MHAtMouth300, USMHAtMouth400, USMHAtMouth500, DSMHAtMouth1200, DSMHAtMouth100, D" +
                "SMHAtMouth200, DSMHAtMouth300, DSMHAtMouth400, DSMHAtMouth500, HydrantAddress, D" +
                "istanceToInversionMH, RampsRequired, DegreeOfTrafficControl, StandarBypass, Hydr" +
                "oWireDetails, PipeMaterialType, CappedLaterals, RoboticPrepRequired, PipeSizeCha" +
                "nge, M1Comments, VideoDoneFrom, ToManhole, CutterDescriptionDuringMeasuring, Ful" +
                "lLengthPointLiner, BypassRequired, RoboticDistances, TrafficControlDetails, Line" +
                "WithID, SchoolZone, RestaurantArea, CarwashLaundromat, HydroPulley, FridgeCart, " +
                "TwoInchPump, SixInchBypass, Scaffolding, WinchExtension, ExtraGenerator, GreyCab" +
                "leExtension, EasementMats, MeasurementType, DropPipe, DropPipeInvertDepth, Delet" +
                "ed, MeasuredFromManhole, MainLined, BenchingIssue, Archived, ScaledLength1, Hist" +
                "ory, NumLats, NotLinedYet, AllMeasured, City, ProvState FROM LFS_MASTER_AREA WHE" +
                "RE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID)";
            this.cmdLFSMasterAreaInsert.CommandType = System.Data.CommandType.Text;
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RecordID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RecordID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANIES_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SubArea", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SubArea", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Street", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Street", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Size_", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Size_", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ScaledLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@P1Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "P1Date", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ActualLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ActualLength", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LiveLats", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveLats", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CXIsRemoved", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@M1Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "M1Date", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@M2Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "M2Date", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InstallDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FinalVideo", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "Comments", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IssueIdentified", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IssueResolved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FullLengthLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthLining", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SubcontractorLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SubcontractorLining", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OutOfScopeInArea", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "OutOfScopeInArea", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IssueGivenToBayCity", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToBayCity", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ConfirmedSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedSize", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InstallRate", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallRate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DeadlineDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DeadlineDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProposedLiningDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SalesIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SalesIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LFSIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LFSIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InvestigationIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "InvestigationIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PointLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PointLining", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Grouting", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouting", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LateralLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralLining", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VacExDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "VacExDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PusherDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PusherDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerOrdered", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Restoration", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Restoration", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GroutDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "GroutDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JLiner", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "JLiner", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RehabAssessment", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RehabAssessment", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EstimatedJoints", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JointsTestSealed", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PreFlushDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PreVideoDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHMN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHMN", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHMN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHMN", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasurementsTakenBy", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SteelTapeThruPipe", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThruPipe", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth1200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth1200", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth100", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth100", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth200", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth300", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth300", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth400", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth400", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth500", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth500", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth1200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth1200", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth100", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth100", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth200", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth300", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth300", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth400", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth400", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth500", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth500", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HydrantAddress", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceToInversionMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RampsRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RampsRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DegreeOfTrafficControl", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DegreeOfTrafficControl", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StandarBypass", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "StandarBypass", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HydroWireDetails", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroWireDetails", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PipeMaterialType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeMaterialType", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CappedLaterals", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RoboticPrepRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PipeSizeChange", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeSizeChange", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@M1Comments", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "M1Comments", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VideoDoneFrom", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFrom", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ToManhole", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ToManhole", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CutterDescriptionDuringMeasuring", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CutterDescriptionDuringMeasuring", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FullLengthPointLiner", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthPointLiner", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BypassRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "BypassRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RoboticDistances", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TrafficControlDetails", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "TrafficControlDetails", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LineWithID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LineWithID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SchoolZone", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SchoolZone", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RestaurantArea", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RestaurantArea", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CarwashLaundromat", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CarwashLaundromat", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HydroPulley", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroPulley", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FridgeCart", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FridgeCart", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TwoInchPump", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "TwoInchPump", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SixInchBypass", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SixInchBypass", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Scaffolding", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Scaffolding", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@WinchExtension", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "WinchExtension", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExtraGenerator", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraGenerator", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GreyCableExtension", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GreyCableExtension", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EasementMats", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "EasementMats", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasurementType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DropPipe", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipe", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DropPipeInvertDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasuredFromManhole", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredFromManhole", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MainLined", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MainLined", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BenchingIssue", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BenchingIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ScaledLength1", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength1", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@History", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "History", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NumLats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NumLats", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NotLinedYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotLinedYet", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AllMeasured", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "AllMeasured", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "City", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProvState", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvState", System.Data.DataRowVersion.Current, false, null, "", "", ""));

			//--- ... cmdLFSMasterAreaUpdate
            this.cmdLFSMasterAreaUpdate.Connection = this.dcConnection;
            this.cmdLFSMasterAreaUpdate.CommandText = "UPDATE [dbo].[LFS_MASTER_AREA] SET [ID] = @ID, [COMPANY_ID] = @COMPANY_ID, [Recor" +
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
                ", [AllMeasured] = @AllMeasured, [City] = @City, [ProvState] = @ProvState WHERE (" +
                "([ID] = @Original_ID) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([RecordID] " +
                "= @Original_RecordID) AND ((@IsNull_ClientID = 1 AND [ClientID] IS NULL) OR ([Cl" +
                "ientID] = @Original_ClientID)) AND ((@IsNull_COMPANIES_ID = 1 AND [COMPANIES_ID]" +
                " IS NULL) OR ([COMPANIES_ID] = @Original_COMPANIES_ID)) AND ((@IsNull_SubArea = " +
                "1 AND [SubArea] IS NULL) OR ([SubArea] = @Original_SubArea)) AND ((@IsNull_Stree" +
                "t = 1 AND [Street] IS NULL) OR ([Street] = @Original_Street)) AND ((@IsNull_USMH" +
                " = 1 AND [USMH] IS NULL) OR ([USMH] = @Original_USMH)) AND ((@IsNull_DSMH = 1 AN" +
                "D [DSMH] IS NULL) OR ([DSMH] = @Original_DSMH)) AND ((@IsNull_Size_ = 1 AND [Siz" +
                "e_] IS NULL) OR ([Size_] = @Original_Size_)) AND ((@IsNull_ScaledLength = 1 AND " +
                "[ScaledLength] IS NULL) OR ([ScaledLength] = @Original_ScaledLength)) AND ((@IsN" +
                "ull_P1Date = 1 AND [P1Date] IS NULL) OR ([P1Date] = @Original_P1Date)) AND ((@Is" +
                "Null_ActualLength = 1 AND [ActualLength] IS NULL) OR ([ActualLength] = @Original" +
                "_ActualLength)) AND ((@IsNull_LiveLats = 1 AND [LiveLats] IS NULL) OR ([LiveLats" +
                "] = @Original_LiveLats)) AND ((@IsNull_CXIsRemoved = 1 AND [CXIsRemoved] IS NULL" +
                ") OR ([CXIsRemoved] = @Original_CXIsRemoved)) AND ((@IsNull_M1Date = 1 AND [M1Da" +
                "te] IS NULL) OR ([M1Date] = @Original_M1Date)) AND ((@IsNull_M2Date = 1 AND [M2D" +
                "ate] IS NULL) OR ([M2Date] = @Original_M2Date)) AND ((@IsNull_InstallDate = 1 AN" +
                "D [InstallDate] IS NULL) OR ([InstallDate] = @Original_InstallDate)) AND ((@IsNu" +
                "ll_FinalVideo = 1 AND [FinalVideo] IS NULL) OR ([FinalVideo] = @Original_FinalVi" +
                "deo)) AND ((@IsNull_IssueIdentified = 1 AND [IssueIdentified] IS NULL) OR ([Issu" +
                "eIdentified] = @Original_IssueIdentified)) AND ((@IsNull_IssueResolved = 1 AND [" +
                "IssueResolved] IS NULL) OR ([IssueResolved] = @Original_IssueResolved)) AND ((@I" +
                "sNull_FullLengthLining = 1 AND [FullLengthLining] IS NULL) OR ([FullLengthLining" +
                "] = @Original_FullLengthLining)) AND ((@IsNull_SubcontractorLining = 1 AND [Subc" +
                "ontractorLining] IS NULL) OR ([SubcontractorLining] = @Original_SubcontractorLin" +
                "ing)) AND ((@IsNull_OutOfScopeInArea = 1 AND [OutOfScopeInArea] IS NULL) OR ([Ou" +
                "tOfScopeInArea] = @Original_OutOfScopeInArea)) AND ((@IsNull_IssueGivenToBayCity" +
                " = 1 AND [IssueGivenToBayCity] IS NULL) OR ([IssueGivenToBayCity] = @Original_Is" +
                "sueGivenToBayCity)) AND ((@IsNull_ConfirmedSize = 1 AND [ConfirmedSize] IS NULL)" +
                " OR ([ConfirmedSize] = @Original_ConfirmedSize)) AND ((@IsNull_InstallRate = 1 A" +
                "ND [InstallRate] IS NULL) OR ([InstallRate] = @Original_InstallRate)) AND ((@IsN" +
                "ull_DeadlineDate = 1 AND [DeadlineDate] IS NULL) OR ([DeadlineDate] = @Original_" +
                "DeadlineDate)) AND ((@IsNull_ProposedLiningDate = 1 AND [ProposedLiningDate] IS " +
                "NULL) OR ([ProposedLiningDate] = @Original_ProposedLiningDate)) AND ((@IsNull_Sa" +
                "lesIssue = 1 AND [SalesIssue] IS NULL) OR ([SalesIssue] = @Original_SalesIssue))" +
                " AND ((@IsNull_LFSIssue = 1 AND [LFSIssue] IS NULL) OR ([LFSIssue] = @Original_L" +
                "FSIssue)) AND ((@IsNull_ClientIssue = 1 AND [ClientIssue] IS NULL) OR ([ClientIs" +
                "sue] = @Original_ClientIssue)) AND ((@IsNull_InvestigationIssue = 1 AND [Investi" +
                "gationIssue] IS NULL) OR ([InvestigationIssue] = @Original_InvestigationIssue)) " +
                "AND ((@IsNull_PointLining = 1 AND [PointLining] IS NULL) OR ([PointLining] = @Or" +
                "iginal_PointLining)) AND ((@IsNull_Grouting = 1 AND [Grouting] IS NULL) OR ([Gro" +
                "uting] = @Original_Grouting)) AND ((@IsNull_LateralLining = 1 AND [LateralLining" +
                "] IS NULL) OR ([LateralLining] = @Original_LateralLining)) AND ((@IsNull_VacExDa" +
                "te = 1 AND [VacExDate] IS NULL) OR ([VacExDate] = @Original_VacExDate)) AND ((@I" +
                "sNull_PusherDate = 1 AND [PusherDate] IS NULL) OR ([PusherDate] = @Original_Push" +
                "erDate)) AND ((@IsNull_LinerOrdered = 1 AND [LinerOrdered] IS NULL) OR ([LinerOr" +
                "dered] = @Original_LinerOrdered)) AND ((@IsNull_Restoration = 1 AND [Restoration" +
                "] IS NULL) OR ([Restoration] = @Original_Restoration)) AND ((@IsNull_GroutDate =" +
                " 1 AND [GroutDate] IS NULL) OR ([GroutDate] = @Original_GroutDate)) AND ((@IsNul" +
                "l_JLiner = 1 AND [JLiner] IS NULL) OR ([JLiner] = @Original_JLiner)) AND ((@IsNu" +
                "ll_RehabAssessment = 1 AND [RehabAssessment] IS NULL) OR ([RehabAssessment] = @O" +
                "riginal_RehabAssessment)) AND ((@IsNull_EstimatedJoints = 1 AND [EstimatedJoints" +
                "] IS NULL) OR ([EstimatedJoints] = @Original_EstimatedJoints)) AND ((@IsNull_Joi" +
                "ntsTestSealed = 1 AND [JointsTestSealed] IS NULL) OR ([JointsTestSealed] = @Orig" +
                "inal_JointsTestSealed)) AND ((@IsNull_PreFlushDate = 1 AND [PreFlushDate] IS NUL" +
                "L) OR ([PreFlushDate] = @Original_PreFlushDate)) AND ((@IsNull_PreVideoDate = 1 " +
                "AND [PreVideoDate] IS NULL) OR ([PreVideoDate] = @Original_PreVideoDate)) AND ((" +
                "@IsNull_USMHMN = 1 AND [USMHMN] IS NULL) OR ([USMHMN] = @Original_USMHMN)) AND (" +
                "(@IsNull_DSMHMN = 1 AND [DSMHMN] IS NULL) OR ([DSMHMN] = @Original_DSMHMN)) AND " +
                "((@IsNull_USMHDepth = 1 AND [USMHDepth] IS NULL) OR ([USMHDepth] = @Original_USM" +
                "HDepth)) AND ((@IsNull_DSMHDepth = 1 AND [DSMHDepth] IS NULL) OR ([DSMHDepth] = " +
                "@Original_DSMHDepth)) AND ((@IsNull_MeasurementsTakenBy = 1 AND [MeasurementsTak" +
                "enBy] IS NULL) OR ([MeasurementsTakenBy] = @Original_MeasurementsTakenBy)) AND (" +
                "(@IsNull_SteelTapeThruPipe = 1 AND [SteelTapeThruPipe] IS NULL) OR ([SteelTapeTh" +
                "ruPipe] = @Original_SteelTapeThruPipe)) AND ((@IsNull_USMHAtMouth1200 = 1 AND [U" +
                "SMHAtMouth1200] IS NULL) OR ([USMHAtMouth1200] = @Original_USMHAtMouth1200)) AND" +
                " ((@IsNull_USMHAtMouth100 = 1 AND [USMHAtMouth100] IS NULL) OR ([USMHAtMouth100]" +
                " = @Original_USMHAtMouth100)) AND ((@IsNull_USMHAtMouth200 = 1 AND [USMHAtMouth2" +
                "00] IS NULL) OR ([USMHAtMouth200] = @Original_USMHAtMouth200)) AND ((@IsNull_USM" +
                "HAtMouth300 = 1 AND [USMHAtMouth300] IS NULL) OR ([USMHAtMouth300] = @Original_U" +
                "SMHAtMouth300)) AND ((@IsNull_USMHAtMouth400 = 1 AND [USMHAtMouth400] IS NULL) O" +
                "R ([USMHAtMouth400] = @Original_USMHAtMouth400)) AND ((@IsNull_USMHAtMouth500 = " +
                "1 AND [USMHAtMouth500] IS NULL) OR ([USMHAtMouth500] = @Original_USMHAtMouth500)" +
                ") AND ((@IsNull_DSMHAtMouth1200 = 1 AND [DSMHAtMouth1200] IS NULL) OR ([DSMHAtMo" +
                "uth1200] = @Original_DSMHAtMouth1200)) AND ((@IsNull_DSMHAtMouth100 = 1 AND [DSM" +
                "HAtMouth100] IS NULL) OR ([DSMHAtMouth100] = @Original_DSMHAtMouth100)) AND ((@I" +
                "sNull_DSMHAtMouth200 = 1 AND [DSMHAtMouth200] IS NULL) OR ([DSMHAtMouth200] = @O" +
                "riginal_DSMHAtMouth200)) AND ((@IsNull_DSMHAtMouth300 = 1 AND [DSMHAtMouth300] I" +
                "S NULL) OR ([DSMHAtMouth300] = @Original_DSMHAtMouth300)) AND ((@IsNull_DSMHAtMo" +
                "uth400 = 1 AND [DSMHAtMouth400] IS NULL) OR ([DSMHAtMouth400] = @Original_DSMHAt" +
                "Mouth400)) AND ((@IsNull_DSMHAtMouth500 = 1 AND [DSMHAtMouth500] IS NULL) OR ([D" +
                "SMHAtMouth500] = @Original_DSMHAtMouth500)) AND ((@IsNull_HydrantAddress = 1 AND" +
                " [HydrantAddress] IS NULL) OR ([HydrantAddress] = @Original_HydrantAddress)) AND" +
                " ((@IsNull_DistanceToInversionMH = 1 AND [DistanceToInversionMH] IS NULL) OR ([D" +
                "istanceToInversionMH] = @Original_DistanceToInversionMH)) AND ((@IsNull_RampsReq" +
                "uired = 1 AND [RampsRequired] IS NULL) OR ([RampsRequired] = @Original_RampsRequ" +
                "ired)) AND ((@IsNull_DegreeOfTrafficControl = 1 AND [DegreeOfTrafficControl] IS " +
                "NULL) OR ([DegreeOfTrafficControl] = @Original_DegreeOfTrafficControl)) AND ((@I" +
                "sNull_StandarBypass = 1 AND [StandarBypass] IS NULL) OR ([StandarBypass] = @Orig" +
                "inal_StandarBypass)) AND ((@IsNull_HydroWireDetails = 1 AND [HydroWireDetails] I" +
                "S NULL) OR ([HydroWireDetails] = @Original_HydroWireDetails)) AND ((@IsNull_Pipe" +
                "MaterialType = 1 AND [PipeMaterialType] IS NULL) OR ([PipeMaterialType] = @Origi" +
                "nal_PipeMaterialType)) AND ((@IsNull_CappedLaterals = 1 AND [CappedLaterals] IS " +
                "NULL) OR ([CappedLaterals] = @Original_CappedLaterals)) AND ((@IsNull_RoboticPre" +
                "pRequired = 1 AND [RoboticPrepRequired] IS NULL) OR ([RoboticPrepRequired] = @Or" +
                "iginal_RoboticPrepRequired)) AND ((@IsNull_PipeSizeChange = 1 AND [PipeSizeChang" +
                "e] IS NULL) OR ([PipeSizeChange] = @Original_PipeSizeChange)) AND ((@IsNull_Vide" +
                "oDoneFrom = 1 AND [VideoDoneFrom] IS NULL) OR ([VideoDoneFrom] = @Original_Video" +
                "DoneFrom)) AND ((@IsNull_ToManhole = 1 AND [ToManhole] IS NULL) OR ([ToManhole] " +
                "= @Original_ToManhole)) AND ((@IsNull_CutterDescriptionDuringMeasuring = 1 AND [" +
                "CutterDescriptionDuringMeasuring] IS NULL) OR ([CutterDescriptionDuringMeasuring" +
                "] = @Original_CutterDescriptionDuringMeasuring)) AND ((@IsNull_FullLengthPointLi" +
                "ner = 1 AND [FullLengthPointLiner] IS NULL) OR ([FullLengthPointLiner] = @Origin" +
                "al_FullLengthPointLiner)) AND ((@IsNull_BypassRequired = 1 AND [BypassRequired] " +
                "IS NULL) OR ([BypassRequired] = @Original_BypassRequired)) AND ((@IsNull_Robotic" +
                "Distances = 1 AND [RoboticDistances] IS NULL) OR ([RoboticDistances] = @Original" +
                "_RoboticDistances)) AND ((@IsNull_LineWithID = 1 AND [LineWithID] IS NULL) OR ([" +
                "LineWithID] = @Original_LineWithID)) AND ((@IsNull_SchoolZone = 1 AND [SchoolZon" +
                "e] IS NULL) OR ([SchoolZone] = @Original_SchoolZone)) AND ((@IsNull_RestaurantAr" +
                "ea = 1 AND [RestaurantArea] IS NULL) OR ([RestaurantArea] = @Original_Restaurant" +
                "Area)) AND ((@IsNull_CarwashLaundromat = 1 AND [CarwashLaundromat] IS NULL) OR (" +
                "[CarwashLaundromat] = @Original_CarwashLaundromat)) AND ((@IsNull_HydroPulley = " +
                "1 AND [HydroPulley] IS NULL) OR ([HydroPulley] = @Original_HydroPulley)) AND ((@" +
                "IsNull_FridgeCart = 1 AND [FridgeCart] IS NULL) OR ([FridgeCart] = @Original_Fri" +
                "dgeCart)) AND ((@IsNull_TwoInchPump = 1 AND [TwoInchPump] IS NULL) OR ([TwoInchP" +
                "ump] = @Original_TwoInchPump)) AND ((@IsNull_SixInchBypass = 1 AND [SixInchBypas" +
                "s] IS NULL) OR ([SixInchBypass] = @Original_SixInchBypass)) AND ((@IsNull_Scaffo" +
                "lding = 1 AND [Scaffolding] IS NULL) OR ([Scaffolding] = @Original_Scaffolding))" +
                " AND ((@IsNull_WinchExtension = 1 AND [WinchExtension] IS NULL) OR ([WinchExtens" +
                "ion] = @Original_WinchExtension)) AND ((@IsNull_ExtraGenerator = 1 AND [ExtraGen" +
                "erator] IS NULL) OR ([ExtraGenerator] = @Original_ExtraGenerator)) AND ((@IsNull" +
                "_GreyCableExtension = 1 AND [GreyCableExtension] IS NULL) OR ([GreyCableExtensio" +
                "n] = @Original_GreyCableExtension)) AND ((@IsNull_EasementMats = 1 AND [Easement" +
                "Mats] IS NULL) OR ([EasementMats] = @Original_EasementMats)) AND ((@IsNull_Measu" +
                "rementType = 1 AND [MeasurementType] IS NULL) OR ([MeasurementType] = @Original_" +
                "MeasurementType)) AND ((@IsNull_DropPipe = 1 AND [DropPipe] IS NULL) OR ([DropPi" +
                "pe] = @Original_DropPipe)) AND ((@IsNull_DropPipeInvertDepth = 1 AND [DropPipeIn" +
                "vertDepth] IS NULL) OR ([DropPipeInvertDepth] = @Original_DropPipeInvertDepth)) " +
                "AND ((@IsNull_Deleted = 1 AND [Deleted] IS NULL) OR ([Deleted] = @Original_Delet" +
                "ed)) AND ((@IsNull_MeasuredFromManhole = 1 AND [MeasuredFromManhole] IS NULL) OR" +
                " ([MeasuredFromManhole] = @Original_MeasuredFromManhole)) AND ((@IsNull_MainLine" +
                "d = 1 AND [MainLined] IS NULL) OR ([MainLined] = @Original_MainLined)) AND ((@Is" +
                "Null_BenchingIssue = 1 AND [BenchingIssue] IS NULL) OR ([BenchingIssue] = @Origi" +
                "nal_BenchingIssue)) AND ((@IsNull_Archived = 1 AND [Archived] IS NULL) OR ([Arch" +
                "ived] = @Original_Archived)) AND ((@IsNull_ScaledLength1 = 1 AND [ScaledLength1]" +
                " IS NULL) OR ([ScaledLength1] = @Original_ScaledLength1)) AND ((@IsNull_NumLats " +
                "= 1 AND [NumLats] IS NULL) OR ([NumLats] = @Original_NumLats)) AND ((@IsNull_Not" +
                "LinedYet = 1 AND [NotLinedYet] IS NULL) OR ([NotLinedYet] = @Original_NotLinedYe" +
                "t)) AND ((@IsNull_AllMeasured = 1 AND [AllMeasured] IS NULL) OR ([AllMeasured] =" +
                " @Original_AllMeasured)) AND ((@IsNull_City = 1 AND [City] IS NULL) OR ([City] =" +
                " @Original_City)) AND ((@IsNull_ProvState = 1 AND [ProvState] IS NULL) OR ([Prov" +
                "State] = @Original_ProvState)));\r\nSELECT ID, COMPANY_ID, RecordID, ClientID, COM" +
                "PANIES_ID, SubArea, Street, USMH, DSMH, Size_, ScaledLength, P1Date, ActualLengt" +
                "h, LiveLats, CXIsRemoved, M1Date, M2Date, InstallDate, FinalVideo, Comments, Iss" +
                "ueIdentified, IssueResolved, FullLengthLining, SubcontractorLining, OutOfScopeIn" +
                "Area, IssueGivenToBayCity, ConfirmedSize, InstallRate, DeadlineDate, ProposedLin" +
                "ingDate, SalesIssue, LFSIssue, ClientIssue, InvestigationIssue, PointLining, Gro" +
                "uting, LateralLining, VacExDate, PusherDate, LinerOrdered, Restoration, GroutDat" +
                "e, JLiner, RehabAssessment, EstimatedJoints, JointsTestSealed, PreFlushDate, Pre" +
                "VideoDate, USMHMN, DSMHMN, USMHDepth, DSMHDepth, MeasurementsTakenBy, SteelTapeT" +
                "hruPipe, USMHAtMouth1200, USMHAtMouth100, USMHAtMouth200, USMHAtMouth300, USMHAt" +
                "Mouth400, USMHAtMouth500, DSMHAtMouth1200, DSMHAtMouth100, DSMHAtMouth200, DSMHA" +
                "tMouth300, DSMHAtMouth400, DSMHAtMouth500, HydrantAddress, DistanceToInversionMH" +
                ", RampsRequired, DegreeOfTrafficControl, StandarBypass, HydroWireDetails, PipeMa" +
                "terialType, CappedLaterals, RoboticPrepRequired, PipeSizeChange, M1Comments, Vid" +
                "eoDoneFrom, ToManhole, CutterDescriptionDuringMeasuring, FullLengthPointLiner, B" +
                "ypassRequired, RoboticDistances, TrafficControlDetails, LineWithID, SchoolZone, " +
                "RestaurantArea, CarwashLaundromat, HydroPulley, FridgeCart, TwoInchPump, SixInch" +
                "Bypass, Scaffolding, WinchExtension, ExtraGenerator, GreyCableExtension, Easemen" +
                "tMats, MeasurementType, DropPipe, DropPipeInvertDepth, Deleted, MeasuredFromManh" +
                "ole, MainLined, BenchingIssue, Archived, ScaledLength1, History, NumLats, NotLin" +
                "edYet, AllMeasured, City, ProvState FROM LFS_MASTER_AREA WHERE (COMPANY_ID = @CO" +
                "MPANY_ID) AND (ID = @ID)";
            this.cmdLFSMasterAreaUpdate.CommandType = System.Data.CommandType.Text;
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RecordID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RecordID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANIES_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SubArea", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SubArea", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Street", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Street", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Size_", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Size_", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ScaledLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@P1Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "P1Date", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ActualLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ActualLength", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LiveLats", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveLats", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CXIsRemoved", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@M1Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "M1Date", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@M2Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "M2Date", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InstallDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FinalVideo", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "Comments", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IssueIdentified", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IssueResolved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FullLengthLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthLining", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SubcontractorLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SubcontractorLining", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OutOfScopeInArea", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "OutOfScopeInArea", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IssueGivenToBayCity", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToBayCity", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ConfirmedSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedSize", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InstallRate", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallRate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DeadlineDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DeadlineDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProposedLiningDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SalesIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SalesIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LFSIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LFSIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InvestigationIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "InvestigationIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PointLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PointLining", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Grouting", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouting", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LateralLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralLining", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VacExDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "VacExDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PusherDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PusherDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerOrdered", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Restoration", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Restoration", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GroutDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "GroutDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JLiner", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "JLiner", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RehabAssessment", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RehabAssessment", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EstimatedJoints", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JointsTestSealed", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PreFlushDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PreVideoDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHMN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHMN", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHMN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHMN", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasurementsTakenBy", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SteelTapeThruPipe", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThruPipe", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth1200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth1200", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth100", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth100", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth200", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth300", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth300", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth400", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth400", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@USMHAtMouth500", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth500", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth1200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth1200", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth100", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth100", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth200", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth300", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth300", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth400", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth400", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DSMHAtMouth500", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth500", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HydrantAddress", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceToInversionMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RampsRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RampsRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DegreeOfTrafficControl", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DegreeOfTrafficControl", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StandarBypass", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "StandarBypass", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HydroWireDetails", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroWireDetails", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PipeMaterialType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeMaterialType", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CappedLaterals", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RoboticPrepRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PipeSizeChange", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeSizeChange", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@M1Comments", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "M1Comments", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VideoDoneFrom", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFrom", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ToManhole", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ToManhole", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CutterDescriptionDuringMeasuring", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CutterDescriptionDuringMeasuring", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FullLengthPointLiner", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthPointLiner", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BypassRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "BypassRequired", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RoboticDistances", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TrafficControlDetails", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "TrafficControlDetails", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LineWithID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LineWithID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SchoolZone", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SchoolZone", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RestaurantArea", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RestaurantArea", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CarwashLaundromat", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CarwashLaundromat", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HydroPulley", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroPulley", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FridgeCart", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FridgeCart", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TwoInchPump", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "TwoInchPump", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SixInchBypass", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SixInchBypass", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Scaffolding", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Scaffolding", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@WinchExtension", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "WinchExtension", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExtraGenerator", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraGenerator", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GreyCableExtension", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GreyCableExtension", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EasementMats", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "EasementMats", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasurementType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DropPipe", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipe", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DropPipeInvertDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasuredFromManhole", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredFromManhole", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MainLined", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MainLined", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BenchingIssue", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BenchingIssue", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ScaledLength1", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength1", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@History", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "History", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NumLats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NumLats", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NotLinedYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotLinedYet", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AllMeasured", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "AllMeasured", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "City", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProvState", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvState", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RecordID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RecordID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ClientID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_COMPANIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANIES_ID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANIES_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SubArea", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SubArea", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SubArea", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SubArea", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Street", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Street", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Street", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Street", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Size_", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Size_", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Size_", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Size_", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ScaledLength", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ScaledLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_P1Date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "P1Date", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_P1Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "P1Date", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ActualLength", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ActualLength", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ActualLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ActualLength", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LiveLats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveLats", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LiveLats", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveLats", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CXIsRemoved", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CXIsRemoved", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_M1Date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "M1Date", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_M1Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "M1Date", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_M2Date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "M2Date", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_M2Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "M2Date", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InstallDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InstallDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FinalVideo", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FinalVideo", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_IssueIdentified", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IssueIdentified", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_IssueResolved", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IssueResolved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FullLengthLining", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthLining", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FullLengthLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthLining", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SubcontractorLining", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SubcontractorLining", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SubcontractorLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SubcontractorLining", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_OutOfScopeInArea", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "OutOfScopeInArea", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OutOfScopeInArea", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "OutOfScopeInArea", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_IssueGivenToBayCity", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToBayCity", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IssueGivenToBayCity", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToBayCity", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ConfirmedSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedSize", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ConfirmedSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedSize", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InstallRate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallRate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InstallRate", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallRate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DeadlineDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DeadlineDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DeadlineDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DeadlineDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ProposedLiningDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProposedLiningDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SalesIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SalesIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SalesIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SalesIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LFSIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LFSIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LFSIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LFSIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ClientIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InvestigationIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InvestigationIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InvestigationIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "InvestigationIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PointLining", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PointLining", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PointLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PointLining", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Grouting", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouting", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Grouting", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouting", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LateralLining", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralLining", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LateralLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralLining", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_VacExDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "VacExDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VacExDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "VacExDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PusherDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PusherDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PusherDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PusherDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerOrdered", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerOrdered", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Restoration", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Restoration", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Restoration", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Restoration", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_GroutDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "GroutDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GroutDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "GroutDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_JLiner", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "JLiner", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_JLiner", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "JLiner", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RehabAssessment", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RehabAssessment", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RehabAssessment", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RehabAssessment", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_EstimatedJoints", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EstimatedJoints", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_JointsTestSealed", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_JointsTestSealed", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PreFlushDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PreFlushDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PreVideoDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PreVideoDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHMN", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHMN", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHMN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHMN", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHMN", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHMN", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHMN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHMN", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHDepth", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHDepth", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MeasurementsTakenBy", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasurementsTakenBy", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SteelTapeThruPipe", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThruPipe", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SteelTapeThruPipe", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThruPipe", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth1200", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth1200", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth1200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth1200", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth100", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth100", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth100", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth100", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth200", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth200", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth200", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth300", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth300", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth300", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth300", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth400", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth400", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth400", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth400", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth500", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth500", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth500", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth500", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth1200", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth1200", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth1200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth1200", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth100", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth100", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth100", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth100", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth200", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth200", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth200", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth300", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth300", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth300", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth300", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth400", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth400", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth400", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth400", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth500", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth500", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth500", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth500", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_HydrantAddress", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HydrantAddress", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DistanceToInversionMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceToInversionMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RampsRequired", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RampsRequired", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RampsRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RampsRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DegreeOfTrafficControl", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DegreeOfTrafficControl", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DegreeOfTrafficControl", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DegreeOfTrafficControl", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_StandarBypass", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "StandarBypass", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_StandarBypass", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "StandarBypass", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_HydroWireDetails", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroWireDetails", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HydroWireDetails", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroWireDetails", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PipeMaterialType", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeMaterialType", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PipeMaterialType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeMaterialType", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CappedLaterals", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CappedLaterals", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RoboticPrepRequired", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepRequired", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RoboticPrepRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PipeSizeChange", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeSizeChange", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PipeSizeChange", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeSizeChange", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_VideoDoneFrom", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFrom", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VideoDoneFrom", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFrom", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ToManhole", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ToManhole", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ToManhole", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ToManhole", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CutterDescriptionDuringMeasuring", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CutterDescriptionDuringMeasuring", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CutterDescriptionDuringMeasuring", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CutterDescriptionDuringMeasuring", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FullLengthPointLiner", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthPointLiner", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FullLengthPointLiner", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthPointLiner", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BypassRequired", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BypassRequired", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BypassRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "BypassRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RoboticDistances", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RoboticDistances", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LineWithID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LineWithID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LineWithID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LineWithID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SchoolZone", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SchoolZone", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SchoolZone", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SchoolZone", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RestaurantArea", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RestaurantArea", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RestaurantArea", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RestaurantArea", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CarwashLaundromat", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CarwashLaundromat", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CarwashLaundromat", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CarwashLaundromat", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_HydroPulley", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroPulley", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HydroPulley", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroPulley", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FridgeCart", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FridgeCart", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FridgeCart", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FridgeCart", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_TwoInchPump", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "TwoInchPump", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_TwoInchPump", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "TwoInchPump", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SixInchBypass", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SixInchBypass", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SixInchBypass", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SixInchBypass", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Scaffolding", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Scaffolding", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Scaffolding", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Scaffolding", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_WinchExtension", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "WinchExtension", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_WinchExtension", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "WinchExtension", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ExtraGenerator", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraGenerator", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExtraGenerator", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraGenerator", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_GreyCableExtension", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "GreyCableExtension", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GreyCableExtension", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GreyCableExtension", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_EasementMats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EasementMats", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EasementMats", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "EasementMats", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MeasurementType", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasurementType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DropPipe", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipe", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DropPipe", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipe", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DropPipeInvertDepth", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DropPipeInvertDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Deleted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MeasuredFromManhole", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredFromManhole", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasuredFromManhole", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredFromManhole", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MainLined", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MainLined", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MainLined", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MainLined", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BenchingIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BenchingIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BenchingIssue", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BenchingIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Archived", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ScaledLength1", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength1", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ScaledLength1", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength1", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_NumLats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NumLats", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NumLats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NumLats", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_NotLinedYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotLinedYet", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NotLinedYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotLinedYet", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_AllMeasured", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AllMeasured", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AllMeasured", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "AllMeasured", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_City", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "City", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "City", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ProvState", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvState", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProvState", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvState", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
			//--- ... cmdLFSMasterAreaDelete
            this.cmdLFSMasterAreaDelete.Connection = this.dcConnection;
            this.cmdLFSMasterAreaDelete.CommandText = "DELETE FROM [dbo].[LFS_MASTER_AREA] WHERE (([ID] = @Original_ID) AND ([COMPANY_ID" +
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
                "ate = 1 AND [ProvState] IS NULL) OR ([ProvState] = @Original_ProvState)))";
            this.cmdLFSMasterAreaDelete.CommandType = System.Data.CommandType.Text;
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RecordID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RecordID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ClientID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_COMPANIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANIES_ID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANIES_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SubArea", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SubArea", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SubArea", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SubArea", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Street", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Street", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Street", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Street", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Size_", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Size_", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Size_", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Size_", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ScaledLength", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ScaledLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_P1Date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "P1Date", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_P1Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "P1Date", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ActualLength", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ActualLength", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ActualLength", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ActualLength", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LiveLats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveLats", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LiveLats", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "LiveLats", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CXIsRemoved", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CXIsRemoved", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CXIsRemoved", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_M1Date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "M1Date", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_M1Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "M1Date", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_M2Date", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "M2Date", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_M2Date", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "M2Date", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InstallDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InstallDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FinalVideo", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FinalVideo", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FinalVideo", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_IssueIdentified", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IssueIdentified", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueIdentified", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_IssueResolved", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IssueResolved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueResolved", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FullLengthLining", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthLining", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FullLengthLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthLining", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SubcontractorLining", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SubcontractorLining", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SubcontractorLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SubcontractorLining", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_OutOfScopeInArea", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "OutOfScopeInArea", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OutOfScopeInArea", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "OutOfScopeInArea", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_IssueGivenToBayCity", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToBayCity", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IssueGivenToBayCity", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IssueGivenToBayCity", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ConfirmedSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedSize", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ConfirmedSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ConfirmedSize", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InstallRate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallRate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InstallRate", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallRate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DeadlineDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DeadlineDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DeadlineDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DeadlineDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ProposedLiningDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProposedLiningDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "ProposedLiningDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SalesIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SalesIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SalesIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SalesIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LFSIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LFSIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LFSIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LFSIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ClientIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ClientIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InvestigationIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InvestigationIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InvestigationIssue", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "InvestigationIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PointLining", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PointLining", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PointLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PointLining", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Grouting", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouting", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Grouting", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Grouting", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LateralLining", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralLining", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LateralLining", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "LateralLining", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_VacExDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "VacExDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VacExDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "VacExDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PusherDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PusherDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PusherDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PusherDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerOrdered", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerOrdered", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerOrdered", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Restoration", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Restoration", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Restoration", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "Restoration", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_GroutDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "GroutDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GroutDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "GroutDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_JLiner", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "JLiner", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_JLiner", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "JLiner", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RehabAssessment", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RehabAssessment", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RehabAssessment", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RehabAssessment", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_EstimatedJoints", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EstimatedJoints", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EstimatedJoints", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_JointsTestSealed", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_JointsTestSealed", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "JointsTestSealed", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PreFlushDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PreFlushDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreFlushDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PreVideoDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PreVideoDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "PreVideoDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHMN", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHMN", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHMN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHMN", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHMN", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHMN", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHMN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHMN", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHDepth", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHDepth", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHDepth", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHDepth", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MeasurementsTakenBy", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasurementsTakenBy", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementsTakenBy", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SteelTapeThruPipe", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThruPipe", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SteelTapeThruPipe", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "SteelTapeThruPipe", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth1200", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth1200", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth1200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth1200", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth100", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth100", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth100", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth100", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth200", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth200", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth200", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth300", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth300", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth300", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth300", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth400", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth400", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth400", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth400", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_USMHAtMouth500", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth500", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_USMHAtMouth500", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "USMHAtMouth500", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth1200", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth1200", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth1200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth1200", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth100", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth100", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth100", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth100", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth200", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth200", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth200", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth200", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth300", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth300", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth300", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth300", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth400", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth400", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth400", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth400", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DSMHAtMouth500", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth500", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DSMHAtMouth500", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "DSMHAtMouth500", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_HydrantAddress", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HydrantAddress", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "HydrantAddress", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DistanceToInversionMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceToInversionMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DistanceToInversionMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RampsRequired", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RampsRequired", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RampsRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RampsRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DegreeOfTrafficControl", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DegreeOfTrafficControl", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DegreeOfTrafficControl", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DegreeOfTrafficControl", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_StandarBypass", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "StandarBypass", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_StandarBypass", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "StandarBypass", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_HydroWireDetails", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroWireDetails", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HydroWireDetails", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroWireDetails", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PipeMaterialType", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeMaterialType", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PipeMaterialType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeMaterialType", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CappedLaterals", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CappedLaterals", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CappedLaterals", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RoboticPrepRequired", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepRequired", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RoboticPrepRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticPrepRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PipeSizeChange", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeSizeChange", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PipeSizeChange", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "PipeSizeChange", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_VideoDoneFrom", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFrom", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VideoDoneFrom", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "VideoDoneFrom", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ToManhole", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ToManhole", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ToManhole", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ToManhole", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CutterDescriptionDuringMeasuring", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CutterDescriptionDuringMeasuring", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CutterDescriptionDuringMeasuring", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CutterDescriptionDuringMeasuring", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FullLengthPointLiner", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthPointLiner", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FullLengthPointLiner", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FullLengthPointLiner", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BypassRequired", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BypassRequired", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BypassRequired", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "BypassRequired", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RoboticDistances", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RoboticDistances", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RoboticDistances", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LineWithID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LineWithID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LineWithID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LineWithID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SchoolZone", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SchoolZone", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SchoolZone", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SchoolZone", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RestaurantArea", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RestaurantArea", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RestaurantArea", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "RestaurantArea", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CarwashLaundromat", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CarwashLaundromat", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CarwashLaundromat", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "CarwashLaundromat", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_HydroPulley", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroPulley", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_HydroPulley", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "HydroPulley", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FridgeCart", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FridgeCart", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FridgeCart", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "FridgeCart", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_TwoInchPump", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "TwoInchPump", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_TwoInchPump", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "TwoInchPump", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_SixInchBypass", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "SixInchBypass", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SixInchBypass", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "SixInchBypass", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Scaffolding", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Scaffolding", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Scaffolding", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Scaffolding", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_WinchExtension", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "WinchExtension", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_WinchExtension", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "WinchExtension", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ExtraGenerator", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraGenerator", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExtraGenerator", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraGenerator", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_GreyCableExtension", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "GreyCableExtension", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GreyCableExtension", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GreyCableExtension", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_EasementMats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EasementMats", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EasementMats", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "EasementMats", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MeasurementType", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasurementType", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasurementType", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DropPipe", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipe", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DropPipe", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipe", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DropPipeInvertDepth", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DropPipeInvertDepth", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DropPipeInvertDepth", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Deleted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MeasuredFromManhole", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredFromManhole", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasuredFromManhole", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MeasuredFromManhole", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MainLined", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MainLined", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MainLined", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MainLined", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_BenchingIssue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "BenchingIssue", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BenchingIssue", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "BenchingIssue", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Archived", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ScaledLength1", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength1", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ScaledLength1", System.Data.SqlDbType.Float, 0, System.Data.ParameterDirection.Input, 0, 0, "ScaledLength1", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_NumLats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NumLats", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NumLats", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NumLats", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_NotLinedYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotLinedYet", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NotLinedYet", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotLinedYet", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_AllMeasured", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AllMeasured", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AllMeasured", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "AllMeasured", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_City", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "City", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "City", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ProvState", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvState", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this.cmdLFSMasterAreaDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProvState", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ProvState", System.Data.DataRowVersion.Original, false, null, "", "", ""));

			//--- daLFSPointRepairs ******************************************************************************
			this.daLFSPointRepairs.DeleteCommand = this.cmdLFSPointRepairsDelete;
			this.daLFSPointRepairs.InsertCommand = this.cmdLFSPointRepairsInsert;
			this.daLFSPointRepairs.SelectCommand = this.cmdLFSPointRepairsSelect;
			this.daLFSPointRepairs.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "LFS_POINT_REPAIRS", new System.Data.Common.DataColumnMapping[] {
																																																							 new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																							 new System.Data.Common.DataColumnMapping("RefID", "RefID"),
																																																							 new System.Data.Common.DataColumnMapping("COMPANY_ID", "COMPANY_ID"),
																																																							 new System.Data.Common.DataColumnMapping("DetailID", "DetailID"),
																																																							 new System.Data.Common.DataColumnMapping("RepairSize", "RepairSize"),
																																																							 new System.Data.Common.DataColumnMapping("InstallDate", "InstallDate"),
																																																							 new System.Data.Common.DataColumnMapping("Distance", "Distance"),
																																																							 new System.Data.Common.DataColumnMapping("Cost", "Cost"),
																																																							 new System.Data.Common.DataColumnMapping("Reinstates", "Reinstates"),
																																																							 new System.Data.Common.DataColumnMapping("LTAtMH", "LTAtMH"),
																																																							 new System.Data.Common.DataColumnMapping("VTAtMH", "VTAtMH"),
																																																							 new System.Data.Common.DataColumnMapping("LinerDistance", "LinerDistance"),
																																																							 new System.Data.Common.DataColumnMapping("Direction", "Direction"),
																																																							 new System.Data.Common.DataColumnMapping("MHShot", "MHShot"),
																																																							 new System.Data.Common.DataColumnMapping("Comments", "Comments"),
																																																							 new System.Data.Common.DataColumnMapping("Deleted", "Deleted"),
																																																							 new System.Data.Common.DataColumnMapping("ExtraRepair", "ExtraRepair"),
																																																							 new System.Data.Common.DataColumnMapping("Cancelled", "Cancelled"),
																																																							 new System.Data.Common.DataColumnMapping("Approved", "Approved"),
																																																							 new System.Data.Common.DataColumnMapping("NotApproved", "NotApproved"),
																																																							 new System.Data.Common.DataColumnMapping("Archived", "Archived")})});
			this.daLFSPointRepairs.UpdateCommand = this.cmdLFSPointRepairsUpdate;

			//--- ... cmdLFSPointRepairsSelect
			this.cmdLFSPointRepairsSelect.CommandText = "SELECT ID, RefID, COMPANY_ID, DetailID, RepairSize, InstallDate, Distance, Cost, Reinstates, LTAtMH, VTAtMH, LinerDistance, Direction, MHShot, Comments, Deleted, ExtraRepair, Cancelled, Approved, NotApproved, Archived FROM LFS_POINT_REPAIRS";
			this.cmdLFSPointRepairsSelect.Connection = this.dcConnection;

			//--- ... cmdLFSPointRepairsInsert
			this.cmdLFSPointRepairsInsert.CommandText = @"INSERT INTO LFS_POINT_REPAIRS(ID, RefID, COMPANY_ID, DetailID, RepairSize, InstallDate, Distance, Cost, Reinstates, LTAtMH, VTAtMH, LinerDistance, Direction, MHShot, Comments, Deleted, ExtraRepair, Cancelled, Approved, NotApproved, Archived) VALUES (@ID, @RefID, @COMPANY_ID, @DetailID, @RepairSize, @InstallDate, @Distance, @Cost, @Reinstates, @LTAtMH, @VTAtMH, @LinerDistance, @Direction, @MHShot, @Comments, @Deleted, @ExtraRepair, @Cancelled, @Approved, @NotApproved, @Archived); SELECT ID, RefID, COMPANY_ID, DetailID, RepairSize, InstallDate, Distance, Cost, Reinstates, LTAtMH, VTAtMH, LinerDistance, Direction, MHShot, Comments, Deleted, ExtraRepair, Cancelled, Approved, NotApproved, Archived FROM LFS_POINT_REPAIRS WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RefID = @RefID)";
			this.cmdLFSPointRepairsInsert.Connection = this.dcConnection;
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 4, "RefID"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 4, "COMPANY_ID"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DetailID", System.Data.SqlDbType.NVarChar, 50, "DetailID"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RepairSize", System.Data.SqlDbType.NVarChar, 50, "RepairSize"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InstallDate", System.Data.SqlDbType.DateTime, 8, "InstallDate"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Distance", System.Data.SqlDbType.NVarChar, 50, "Distance"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cost", System.Data.SqlDbType.Money, 8, "Cost"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Reinstates", System.Data.SqlDbType.Int, 4, "Reinstates"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LTAtMH", System.Data.SqlDbType.NVarChar, 50, "LTAtMH"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VTAtMH", System.Data.SqlDbType.NVarChar, 50, "VTAtMH"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerDistance", System.Data.SqlDbType.NVarChar, 50, "LinerDistance"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Direction", System.Data.SqlDbType.NVarChar, 50, "Direction"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MHShot", System.Data.SqlDbType.NVarChar, 50, "MHShot"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NVarChar, 150, "Comments"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 1, "Deleted"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExtraRepair", System.Data.SqlDbType.Bit, 1, "ExtraRepair"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cancelled", System.Data.SqlDbType.Bit, 1, "Cancelled"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Approved", System.Data.SqlDbType.Bit, 1, "Approved"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NotApproved", System.Data.SqlDbType.Bit, 1, "NotApproved"));
			this.cmdLFSPointRepairsInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Archived", System.Data.SqlDbType.Bit, 1, "Archived"));

			//--- ... cmdLFSPointRepairsUpdate
			this.cmdLFSPointRepairsUpdate.CommandText = "UPDATE LFS_POINT_REPAIRS SET ID = @ID, RefID = @RefID, COMPANY_ID = @COMPANY_ID, " +
				"DetailID = @DetailID, RepairSize = @RepairSize, InstallDate = @InstallDate, Dist" +
				"ance = @Distance, Cost = @Cost, Reinstates = @Reinstates, LTAtMH = @LTAtMH, VTAt" +
				"MH = @VTAtMH, LinerDistance = @LinerDistance, Direction = @Direction, MHShot = @" +
				"MHShot, Comments = @Comments, Deleted = @Deleted, ExtraRepair = @ExtraRepair, Ca" +
				"ncelled = @Cancelled, Approved = @Approved, NotApproved = @NotApproved, Archived" +
				" = @Archived WHERE (COMPANY_ID = @Original_COMPANY_ID) AND (ID = @Original_ID) A" +
				"ND (RefID = @Original_RefID) AND (Approved = @Original_Approved OR @Original_App" +
				"roved IS NULL AND Approved IS NULL) AND (Archived = @Original_Archived OR @Origi" +
				"nal_Archived IS NULL AND Archived IS NULL) AND (Cancelled = @Original_Cancelled " +
				"OR @Original_Cancelled IS NULL AND Cancelled IS NULL) AND (Comments = @Original_" +
				"Comments OR @Original_Comments IS NULL AND Comments IS NULL) AND (Cost = @Origin" +
				"al_Cost OR @Original_Cost IS NULL AND Cost IS NULL) AND (Deleted = @Original_Del" +
				"eted OR @Original_Deleted IS NULL AND Deleted IS NULL) AND (DetailID = @Original" +
				"_DetailID) AND (Direction = @Original_Direction OR @Original_Direction IS NULL A" +
				"ND Direction IS NULL) AND (Distance = @Original_Distance OR @Original_Distance I" +
				"S NULL AND Distance IS NULL) AND (ExtraRepair = @Original_ExtraRepair OR @Origin" +
				"al_ExtraRepair IS NULL AND ExtraRepair IS NULL) AND (InstallDate = @Original_Ins" +
				"tallDate OR @Original_InstallDate IS NULL AND InstallDate IS NULL) AND (LTAtMH =" +
				" @Original_LTAtMH OR @Original_LTAtMH IS NULL AND LTAtMH IS NULL) AND (LinerDist" +
				"ance = @Original_LinerDistance OR @Original_LinerDistance IS NULL AND LinerDista" +
				"nce IS NULL) AND (MHShot = @Original_MHShot OR @Original_MHShot IS NULL AND MHSh" +
				"ot IS NULL) AND (NotApproved = @Original_NotApproved OR @Original_NotApproved IS" +
				" NULL AND NotApproved IS NULL) AND (Reinstates = @Original_Reinstates OR @Origin" +
				"al_Reinstates IS NULL AND Reinstates IS NULL) AND (RepairSize = @Original_Repair" +
				"Size OR @Original_RepairSize IS NULL AND RepairSize IS NULL) AND (VTAtMH = @Orig" +
				"inal_VTAtMH OR @Original_VTAtMH IS NULL AND VTAtMH IS NULL); SELECT ID, RefID, C" +
				"OMPANY_ID, DetailID, RepairSize, InstallDate, Distance, Cost, Reinstates, LTAtMH" +
				", VTAtMH, LinerDistance, Direction, MHShot, Comments, Deleted, ExtraRepair, Canc" +
				"elled, Approved, NotApproved, Archived FROM LFS_POINT_REPAIRS WHERE (COMPANY_ID " +
				"= @COMPANY_ID) AND (ID = @ID) AND (RefID = @RefID)";
			this.cmdLFSPointRepairsUpdate.Connection = this.dcConnection;
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 4, "RefID"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 4, "COMPANY_ID"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DetailID", System.Data.SqlDbType.NVarChar, 50, "DetailID"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RepairSize", System.Data.SqlDbType.NVarChar, 50, "RepairSize"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InstallDate", System.Data.SqlDbType.DateTime, 8, "InstallDate"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Distance", System.Data.SqlDbType.NVarChar, 50, "Distance"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cost", System.Data.SqlDbType.Money, 8, "Cost"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Reinstates", System.Data.SqlDbType.Int, 4, "Reinstates"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LTAtMH", System.Data.SqlDbType.NVarChar, 50, "LTAtMH"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VTAtMH", System.Data.SqlDbType.NVarChar, 50, "VTAtMH"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerDistance", System.Data.SqlDbType.NVarChar, 50, "LinerDistance"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Direction", System.Data.SqlDbType.NVarChar, 50, "Direction"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MHShot", System.Data.SqlDbType.NVarChar, 50, "MHShot"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NVarChar, 150, "Comments"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 1, "Deleted"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExtraRepair", System.Data.SqlDbType.Bit, 1, "ExtraRepair"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cancelled", System.Data.SqlDbType.Bit, 1, "Cancelled"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Approved", System.Data.SqlDbType.Bit, 1, "Approved"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NotApproved", System.Data.SqlDbType.Bit, 1, "NotApproved"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Archived", System.Data.SqlDbType.Bit, 1, "Archived"));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "COMPANY_ID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RefID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Approved", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Approved", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Archived", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Archived", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cancelled", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Cancelled", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Comments", System.Data.SqlDbType.NVarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Comments", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cost", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Cost", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Deleted", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DetailID", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DetailID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Direction", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Direction", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Distance", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Distance", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExtraRepair", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ExtraRepair", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InstallDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InstallDate", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LTAtMH", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LTAtMH", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerDistance", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinerDistance", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MHShot", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MHShot", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NotApproved", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NotApproved", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Reinstates", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Reinstates", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RepairSize", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RepairSize", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VTAtMH", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "VTAtMH", System.Data.DataRowVersion.Original, null));
			
			//--- ... cmdLFSPointRepairsDelete
			this.cmdLFSPointRepairsDelete.CommandText = "DELETE FROM LFS_POINT_REPAIRS WHERE (COMPANY_ID = @Original_COMPANY_ID) AND (ID =" +
				" @Original_ID) AND (RefID = @Original_RefID) AND (Approved = @Original_Approved " +
				"OR @Original_Approved IS NULL AND Approved IS NULL) AND (Archived = @Original_Ar" +
				"chived OR @Original_Archived IS NULL AND Archived IS NULL) AND (Cancelled = @Ori" +
				"ginal_Cancelled OR @Original_Cancelled IS NULL AND Cancelled IS NULL) AND (Comme" +
				"nts = @Original_Comments OR @Original_Comments IS NULL AND Comments IS NULL) AND" +
				" (Cost = @Original_Cost OR @Original_Cost IS NULL AND Cost IS NULL) AND (Deleted" +
				" = @Original_Deleted OR @Original_Deleted IS NULL AND Deleted IS NULL) AND (Deta" +
				"ilID = @Original_DetailID) AND (Direction = @Original_Direction OR @Original_Dir" +
				"ection IS NULL AND Direction IS NULL) AND (Distance = @Original_Distance OR @Ori" +
				"ginal_Distance IS NULL AND Distance IS NULL) AND (ExtraRepair = @Original_ExtraR" +
				"epair OR @Original_ExtraRepair IS NULL AND ExtraRepair IS NULL) AND (InstallDate" +
				" = @Original_InstallDate OR @Original_InstallDate IS NULL AND InstallDate IS NUL" +
				"L) AND (LTAtMH = @Original_LTAtMH OR @Original_LTAtMH IS NULL AND LTAtMH IS NULL" +
				") AND (LinerDistance = @Original_LinerDistance OR @Original_LinerDistance IS NUL" +
				"L AND LinerDistance IS NULL) AND (MHShot = @Original_MHShot OR @Original_MHShot " +
				"IS NULL AND MHShot IS NULL) AND (NotApproved = @Original_NotApproved OR @Origina" +
				"l_NotApproved IS NULL AND NotApproved IS NULL) AND (Reinstates = @Original_Reins" +
				"tates OR @Original_Reinstates IS NULL AND Reinstates IS NULL) AND (RepairSize = " +
				"@Original_RepairSize OR @Original_RepairSize IS NULL AND RepairSize IS NULL) AND" +
				" (VTAtMH = @Original_VTAtMH OR @Original_VTAtMH IS NULL AND VTAtMH IS NULL)";
			this.cmdLFSPointRepairsDelete.Connection = this.dcConnection;
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "COMPANY_ID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RefID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Approved", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Approved", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Archived", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Archived", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cancelled", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Cancelled", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Comments", System.Data.SqlDbType.NVarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Comments", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cost", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Cost", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Deleted", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DetailID", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DetailID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Direction", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Direction", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Distance", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Distance", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExtraRepair", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ExtraRepair", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InstallDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "InstallDate", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LTAtMH", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LTAtMH", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerDistance", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinerDistance", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MHShot", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MHShot", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NotApproved", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "NotApproved", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Reinstates", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Reinstates", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RepairSize", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RepairSize", System.Data.DataRowVersion.Original, null));
			this.cmdLFSPointRepairsDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VTAtMH", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "VTAtMH", System.Data.DataRowVersion.Original, null));
			
			//--- daLFSM2Tables ******************************************************************************
			this.daLFSM2Tables.DeleteCommand = this.cmdLFSM2TablesDelete;
			this.daLFSM2Tables.InsertCommand = this.cmdLFSM2TablesInsert;
			this.daLFSM2Tables.SelectCommand = this.cmdLFSM2TablesSelect;
			this.daLFSM2Tables.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "LFS_M2_TABLES", new System.Data.Common.DataColumnMapping[] {
																																																					 new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																					 new System.Data.Common.DataColumnMapping("RefID", "RefID"),
																																																					 new System.Data.Common.DataColumnMapping("COMPANY_ID", "COMPANY_ID"),
																																																					 new System.Data.Common.DataColumnMapping("VideoDistance", "VideoDistance"),
																																																					 new System.Data.Common.DataColumnMapping("ClockPosition", "ClockPosition"),
																																																					 new System.Data.Common.DataColumnMapping("LiveOrAbandoned", "LiveOrAbandoned"),
																																																					 new System.Data.Common.DataColumnMapping("DistanceToCentreOfLateral", "DistanceToCentreOfLateral"),
																																																					 new System.Data.Common.DataColumnMapping("LateralDiameter", "LateralDiameter"),
																																																					 new System.Data.Common.DataColumnMapping("LateralType", "LateralType"),
																																																					 new System.Data.Common.DataColumnMapping("DateTimeOpened", "DateTimeOpened"),
																																																					 new System.Data.Common.DataColumnMapping("Comments", "Comments"),
																																																					 new System.Data.Common.DataColumnMapping("ReverseSetup", "ReverseSetup"),
																																																					 new System.Data.Common.DataColumnMapping("Deleted", "Deleted"),
																																																					 new System.Data.Common.DataColumnMapping("Archived", "Archived")})});
			this.daLFSM2Tables.UpdateCommand = this.cmdLFSM2TablesUpdate;

			//--- ... cmdLFSM2TablesSelect
			this.cmdLFSM2TablesSelect.CommandText = "SELECT ID, RefID, COMPANY_ID, VideoDistance, ClockPosition, LiveOrAbandoned, DistanceToCentreOfLateral, LateralDiameter, LateralType, DateTimeOpened, Comments, ReverseSetup, Deleted, Archived FROM LFS_M2_TABLES";
			this.cmdLFSM2TablesSelect.Connection = this.dcConnection;

			//--- ... cmdLFSM2TablesInsert
			this.cmdLFSM2TablesInsert.CommandText = @"INSERT INTO LFS_M2_TABLES(ID, RefID, COMPANY_ID, VideoDistance, ClockPosition, LiveOrAbandoned, DistanceToCentreOfLateral, LateralDiameter, LateralType, DateTimeOpened, Comments, ReverseSetup, Deleted, Archived) VALUES (@ID, @RefID, @COMPANY_ID, @VideoDistance, @ClockPosition, @LiveOrAbandoned, @DistanceToCentreOfLateral, @LateralDiameter, @LateralType, @DateTimeOpened, @Comments, @ReverseSetup, @Deleted, @Archived); SELECT ID, RefID, COMPANY_ID, VideoDistance, ClockPosition, LiveOrAbandoned, DistanceToCentreOfLateral, LateralDiameter, LateralType, DateTimeOpened, Comments, ReverseSetup, Deleted, Archived FROM LFS_M2_TABLES WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RefID = @RefID)";
			this.cmdLFSM2TablesInsert.Connection = this.dcConnection;
			this.cmdLFSM2TablesInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
			this.cmdLFSM2TablesInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 4, "RefID"));
			this.cmdLFSM2TablesInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 4, "COMPANY_ID"));
			this.cmdLFSM2TablesInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VideoDistance", System.Data.SqlDbType.Real, 4, "VideoDistance"));
			this.cmdLFSM2TablesInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClockPosition", System.Data.SqlDbType.NVarChar, 50, "ClockPosition"));
			this.cmdLFSM2TablesInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LiveOrAbandoned", System.Data.SqlDbType.NVarChar, 50, "LiveOrAbandoned"));
			this.cmdLFSM2TablesInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceToCentreOfLateral", System.Data.SqlDbType.NVarChar, 50, "DistanceToCentreOfLateral"));
			this.cmdLFSM2TablesInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LateralDiameter", System.Data.SqlDbType.NVarChar, 50, "LateralDiameter"));
			this.cmdLFSM2TablesInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LateralType", System.Data.SqlDbType.NVarChar, 50, "LateralType"));
			this.cmdLFSM2TablesInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTimeOpened", System.Data.SqlDbType.NVarChar, 50, "DateTimeOpened"));
			this.cmdLFSM2TablesInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NVarChar, 1073741823, "Comments"));
			this.cmdLFSM2TablesInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReverseSetup", System.Data.SqlDbType.NVarChar, 50, "ReverseSetup"));
			this.cmdLFSM2TablesInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 1, "Deleted"));
			this.cmdLFSM2TablesInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Archived", System.Data.SqlDbType.Bit, 1, "Archived"));

			//--- ... cmdLFSM2TablesUpdate
			this.cmdLFSM2TablesUpdate.CommandText = "UPDATE LFS_M2_TABLES SET ID = @ID, RefID = @RefID, COMPANY_ID = @COMPANY_ID, Vide" +
				"oDistance = @VideoDistance, ClockPosition = @ClockPosition, LiveOrAbandoned = @L" +
				"iveOrAbandoned, DistanceToCentreOfLateral = @DistanceToCentreOfLateral, LateralD" +
				"iameter = @LateralDiameter, LateralType = @LateralType, DateTimeOpened = @DateTi" +
				"meOpened, Comments = @Comments, ReverseSetup = @ReverseSetup, Deleted = @Deleted" +
				", Archived = @Archived WHERE (COMPANY_ID = @Original_COMPANY_ID) AND (ID = @Orig" +
				"inal_ID) AND (RefID = @Original_RefID) AND (Archived = @Original_Archived OR @Or" +
				"iginal_Archived IS NULL AND Archived IS NULL) AND (ClockPosition = @Original_Clo" +
				"ckPosition OR @Original_ClockPosition IS NULL AND ClockPosition IS NULL) AND (Da" +
				"teTimeOpened = @Original_DateTimeOpened OR @Original_DateTimeOpened IS NULL AND " +
				"DateTimeOpened IS NULL) AND (Deleted = @Original_Deleted OR @Original_Deleted IS" +
				" NULL AND Deleted IS NULL) AND (DistanceToCentreOfLateral = @Original_DistanceTo" +
				"CentreOfLateral OR @Original_DistanceToCentreOfLateral IS NULL AND DistanceToCen" +
				"treOfLateral IS NULL) AND (LateralDiameter = @Original_LateralDiameter OR @Origi" +
				"nal_LateralDiameter IS NULL AND LateralDiameter IS NULL) AND (LateralType = @Ori" +
				"ginal_LateralType OR @Original_LateralType IS NULL AND LateralType IS NULL) AND " +
				"(LiveOrAbandoned = @Original_LiveOrAbandoned OR @Original_LiveOrAbandoned IS NUL" +
				"L AND LiveOrAbandoned IS NULL) AND (ReverseSetup = @Original_ReverseSetup OR @Or" +
				"iginal_ReverseSetup IS NULL AND ReverseSetup IS NULL) AND (VideoDistance = @Orig" +
				"inal_VideoDistance OR @Original_VideoDistance IS NULL AND VideoDistance IS NULL)" +
				"; SELECT ID, RefID, COMPANY_ID, VideoDistance, ClockPosition, LiveOrAbandoned, D" +
				"istanceToCentreOfLateral, LateralDiameter, LateralType, DateTimeOpened, Comments" +
				", ReverseSetup, Deleted, Archived FROM LFS_M2_TABLES WHERE (COMPANY_ID = @COMPAN" +
				"Y_ID) AND (ID = @ID) AND (RefID = @RefID)";
			this.cmdLFSM2TablesUpdate.Connection = this.dcConnection;
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 4, "RefID"));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 4, "COMPANY_ID"));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VideoDistance", System.Data.SqlDbType.Real, 4, "VideoDistance"));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClockPosition", System.Data.SqlDbType.NVarChar, 50, "ClockPosition"));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LiveOrAbandoned", System.Data.SqlDbType.NVarChar, 50, "LiveOrAbandoned"));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceToCentreOfLateral", System.Data.SqlDbType.NVarChar, 50, "DistanceToCentreOfLateral"));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LateralDiameter", System.Data.SqlDbType.NVarChar, 50, "LateralDiameter"));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LateralType", System.Data.SqlDbType.NVarChar, 50, "LateralType"));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTimeOpened", System.Data.SqlDbType.NVarChar, 50, "DateTimeOpened"));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NVarChar, 1073741823, "Comments"));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReverseSetup", System.Data.SqlDbType.NVarChar, 50, "ReverseSetup"));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 1, "Deleted"));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Archived", System.Data.SqlDbType.Bit, 1, "Archived"));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "COMPANY_ID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RefID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Archived", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Archived", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClockPosition", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ClockPosition", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DateTimeOpened", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateTimeOpened", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Deleted", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceToCentreOfLateral", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceToCentreOfLateral", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LateralDiameter", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LateralDiameter", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LateralType", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LateralType", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LiveOrAbandoned", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LiveOrAbandoned", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReverseSetup", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReverseSetup", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VideoDistance", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "VideoDistance", System.Data.DataRowVersion.Original, null));
			
			//--- ... cmdLFSM2TablesDelete
			this.cmdLFSM2TablesDelete.CommandText = @"DELETE FROM LFS_M2_TABLES WHERE (COMPANY_ID = @Original_COMPANY_ID) AND (ID = @Original_ID) AND (RefID = @Original_RefID) AND (Archived = @Original_Archived OR @Original_Archived IS NULL AND Archived IS NULL) AND (ClockPosition = @Original_ClockPosition OR @Original_ClockPosition IS NULL AND ClockPosition IS NULL) AND (DateTimeOpened = @Original_DateTimeOpened OR @Original_DateTimeOpened IS NULL AND DateTimeOpened IS NULL) AND (Deleted = @Original_Deleted OR @Original_Deleted IS NULL AND Deleted IS NULL) AND (DistanceToCentreOfLateral = @Original_DistanceToCentreOfLateral OR @Original_DistanceToCentreOfLateral IS NULL AND DistanceToCentreOfLateral IS NULL) AND (LateralDiameter = @Original_LateralDiameter OR @Original_LateralDiameter IS NULL AND LateralDiameter IS NULL) AND (LateralType = @Original_LateralType OR @Original_LateralType IS NULL AND LateralType IS NULL) AND (LiveOrAbandoned = @Original_LiveOrAbandoned OR @Original_LiveOrAbandoned IS NULL AND LiveOrAbandoned IS NULL) AND (ReverseSetup = @Original_ReverseSetup OR @Original_ReverseSetup IS NULL AND ReverseSetup IS NULL) AND (VideoDistance = @Original_VideoDistance OR @Original_VideoDistance IS NULL AND VideoDistance IS NULL)";
			this.cmdLFSM2TablesDelete.Connection = this.dcConnection;
			this.cmdLFSM2TablesDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "COMPANY_ID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RefID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Archived", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Archived", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClockPosition", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ClockPosition", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DateTimeOpened", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DateTimeOpened", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Deleted", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceToCentreOfLateral", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceToCentreOfLateral", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LateralDiameter", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LateralDiameter", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LateralType", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LateralType", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LiveOrAbandoned", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LiveOrAbandoned", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReverseSetup", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ReverseSetup", System.Data.DataRowVersion.Original, null));
			this.cmdLFSM2TablesDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VideoDistance", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "VideoDistance", System.Data.DataRowVersion.Original, null));
			
			//--- daLFSJunctionLiner ******************************************************************************
			this.daLFSJunctionLiner.DeleteCommand = this.cmdLFSJunctionLinerDelete;
			this.daLFSJunctionLiner.InsertCommand = this.cmdLFSJunctionLinerInsert;
			this.daLFSJunctionLiner.SelectCommand = this.cmdLFSJunctionLinerSelect;
			this.daLFSJunctionLiner.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										 new System.Data.Common.DataTableMapping("Table", "LFS_JUNCTION_LINER", new System.Data.Common.DataColumnMapping[] {
																																																							   new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																							   new System.Data.Common.DataColumnMapping("RefID", "RefID"),
																																																							   new System.Data.Common.DataColumnMapping("COMPANY_ID", "COMPANY_ID"),
																																																							   new System.Data.Common.DataColumnMapping("DetailID", "DetailID"),
																																																							   new System.Data.Common.DataColumnMapping("MN", "MN"),
																																																							   new System.Data.Common.DataColumnMapping("DistanceFromUSMH", "DistanceFromUSMH"),
																																																							   new System.Data.Common.DataColumnMapping("ConfirmedLatSize", "ConfirmedLatSize"),
																																																							   new System.Data.Common.DataColumnMapping("LateralMaterial", "LateralMaterial"),
																																																							   new System.Data.Common.DataColumnMapping("SharedLateral", "SharedLateral"),
																																																							   new System.Data.Common.DataColumnMapping("CleanoutRequired", "CleanoutRequired"),
																																																							   new System.Data.Common.DataColumnMapping("PitRequired", "PitRequired"),
																																																							   new System.Data.Common.DataColumnMapping("MHShot", "MHShot"),
																																																							   new System.Data.Common.DataColumnMapping("MainConnection", "MainConnection"),
																																																							   new System.Data.Common.DataColumnMapping("Transition", "Transition"),
																																																							   new System.Data.Common.DataColumnMapping("CleanoutInstalled", "CleanoutInstalled"),
																																																							   new System.Data.Common.DataColumnMapping("PitInstalled", "PitInstalled"),
																																																							   new System.Data.Common.DataColumnMapping("CleanoutGrouted", "CleanoutGrouted"),
																																																							   new System.Data.Common.DataColumnMapping("CleanoutCored", "CleanoutCored"),
																																																							   new System.Data.Common.DataColumnMapping("PrepCompleted", "PrepCompleted"),
																																																							   new System.Data.Common.DataColumnMapping("MeasuredLatLength", "MeasuredLatLength"),
																																																							   new System.Data.Common.DataColumnMapping("MeasurementsTakenBy", "MeasurementsTakenBy"),
																																																							   new System.Data.Common.DataColumnMapping("LinerInstalled", "LinerInstalled"),
																																																							   new System.Data.Common.DataColumnMapping("FinalVideo", "FinalVideo"),
																																																							   new System.Data.Common.DataColumnMapping("RestorationComplete", "RestorationComplete"),
																																																							   new System.Data.Common.DataColumnMapping("LinerOrdered", "LinerOrdered"),
																																																							   new System.Data.Common.DataColumnMapping("LinerInStock", "LinerInStock"),
																																																							   new System.Data.Common.DataColumnMapping("LinerPrice", "LinerPrice"),
																																																							   new System.Data.Common.DataColumnMapping("Comments", "Comments"),
																																																							   new System.Data.Common.DataColumnMapping("Deleted", "Deleted"),
																																																							   new System.Data.Common.DataColumnMapping("Archived", "Archived")})});
			this.daLFSJunctionLiner.UpdateCommand = this.cmdLFSJunctionLinerUpdate;

			//--- ... cmdLfsJunctionLinerSelect
			this.cmdLFSJunctionLinerSelect.CommandText = @"SELECT ID, RefID, COMPANY_ID, DetailID, MN, DistanceFromUSMH, ConfirmedLatSize, LateralMaterial, SharedLateral, CleanoutRequired, PitRequired, MHShot, MainConnection, Transition, CleanoutInstalled, PitInstalled, CleanoutGrouted, CleanoutCored, PrepCompleted, MeasuredLatLength, MeasurementsTakenBy, LinerInstalled, FinalVideo, RestorationComplete, LinerOrdered, LinerInStock, LinerPrice, Comments, Deleted, Archived FROM LFS_JUNCTION_LINER";
			this.cmdLFSJunctionLinerSelect.Connection = this.dcConnection;

			//--- ... cmdLfsJunctionLinerInsert
			this.cmdLFSJunctionLinerInsert.CommandText = @"INSERT INTO LFS_JUNCTION_LINER(ID, RefID, COMPANY_ID, DetailID, MN, DistanceFromUSMH, ConfirmedLatSize, LateralMaterial, SharedLateral, CleanoutRequired, PitRequired, MHShot, MainConnection, Transition, CleanoutInstalled, PitInstalled, CleanoutGrouted, CleanoutCored, PrepCompleted, MeasuredLatLength, MeasurementsTakenBy, LinerInstalled, FinalVideo, RestorationComplete, LinerOrdered, LinerInStock, LinerPrice, Comments, Deleted, Archived) VALUES (@ID, @RefID, @COMPANY_ID, @DetailID, @MN, @DistanceFromUSMH, @ConfirmedLatSize, @LateralMaterial, @SharedLateral, @CleanoutRequired, @PitRequired, @MHShot, @MainConnection, @Transition, @CleanoutInstalled, @PitInstalled, @CleanoutGrouted, @CleanoutCored, @PrepCompleted, @MeasuredLatLength, @MeasurementsTakenBy, @LinerInstalled, @FinalVideo, @RestorationComplete, @LinerOrdered, @LinerInStock, @LinerPrice, @Comments, @Deleted, @Archived); SELECT ID, RefID, COMPANY_ID, DetailID, MN, DistanceFromUSMH, ConfirmedLatSize, LateralMaterial, SharedLateral, CleanoutRequired, PitRequired, MHShot, MainConnection, Transition, CleanoutInstalled, PitInstalled, CleanoutGrouted, CleanoutCored, PrepCompleted, MeasuredLatLength, MeasurementsTakenBy, LinerInstalled, FinalVideo, RestorationComplete, LinerOrdered, LinerInStock, LinerPrice, Comments, Deleted, Archived FROM LFS_JUNCTION_LINER WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RefID = @RefID)";
			this.cmdLFSJunctionLinerInsert.Connection = this.dcConnection;
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 4, "RefID"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 4, "COMPANY_ID"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DetailID", System.Data.SqlDbType.NVarChar, 50, "DetailID"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MN", System.Data.SqlDbType.NVarChar, 50, "MN"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceFromUSMH", System.Data.SqlDbType.Float, 8, "DistanceFromUSMH"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ConfirmedLatSize", System.Data.SqlDbType.NVarChar, 50, "ConfirmedLatSize"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LateralMaterial", System.Data.SqlDbType.NVarChar, 50, "LateralMaterial"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SharedLateral", System.Data.SqlDbType.NVarChar, 10, "SharedLateral"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CleanoutRequired", System.Data.SqlDbType.Bit, 1, "CleanoutRequired"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PitRequired", System.Data.SqlDbType.Bit, 1, "PitRequired"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MHShot", System.Data.SqlDbType.Bit, 1, "MHShot"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MainConnection", System.Data.SqlDbType.NVarChar, 10, "MainConnection"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Transition", System.Data.SqlDbType.NVarChar, 10, "Transition"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CleanoutInstalled", System.Data.SqlDbType.Bit, 1, "CleanoutInstalled"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PitInstalled", System.Data.SqlDbType.Bit, 1, "PitInstalled"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CleanoutGrouted", System.Data.SqlDbType.Bit, 1, "CleanoutGrouted"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CleanoutCored", System.Data.SqlDbType.Bit, 1, "CleanoutCored"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PrepCompleted", System.Data.SqlDbType.DateTime, 8, "PrepCompleted"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasuredLatLength", System.Data.SqlDbType.NVarChar, 50, "MeasuredLatLength"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasurementsTakenBy", System.Data.SqlDbType.NVarChar, 50, "MeasurementsTakenBy"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerInstalled", System.Data.SqlDbType.DateTime, 8, "LinerInstalled"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FinalVideo", System.Data.SqlDbType.DateTime, 8, "FinalVideo"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RestorationComplete", System.Data.SqlDbType.Bit, 1, "RestorationComplete"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerOrdered", System.Data.SqlDbType.Bit, 1, "LinerOrdered"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerInStock", System.Data.SqlDbType.Bit, 1, "LinerInStock"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerPrice", System.Data.SqlDbType.Money, 8, "LinerPrice"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NVarChar, 1073741823, "Comments"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 1, "Deleted"));
			this.cmdLFSJunctionLinerInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Archived", System.Data.SqlDbType.Bit, 1, "Archived"));
			
			//--- ... cmdLfsJunctionLinerUpdate
			this.cmdLFSJunctionLinerUpdate.CommandText = "UPDATE LFS_JUNCTION_LINER SET ID = @ID, RefID = @RefID, COMPANY_ID = @COMPANY_ID," +
				" DetailID = @DetailID, MN = @MN, DistanceFromUSMH = @DistanceFromUSMH, Confirmed" +
				"LatSize = @ConfirmedLatSize, LateralMaterial = @LateralMaterial, SharedLateral =" +
				" @SharedLateral, CleanoutRequired = @CleanoutRequired, PitRequired = @PitRequire" +
				"d, MHShot = @MHShot, MainConnection = @MainConnection, Transition = @Transition," +
				" CleanoutInstalled = @CleanoutInstalled, PitInstalled = @PitInstalled, CleanoutG" +
				"routed = @CleanoutGrouted, CleanoutCored = @CleanoutCored, PrepCompleted = @Prep" +
				"Completed, MeasuredLatLength = @MeasuredLatLength, MeasurementsTakenBy = @Measur" +
				"ementsTakenBy, LinerInstalled = @LinerInstalled, FinalVideo = @FinalVideo, Resto" +
				"rationComplete = @RestorationComplete, LinerOrdered = @LinerOrdered, LinerInStoc" +
				"k = @LinerInStock, LinerPrice = @LinerPrice, Comments = @Comments, Deleted = @De" +
				"leted, Archived = @Archived WHERE (COMPANY_ID = @Original_COMPANY_ID) AND (ID = " +
				"@Original_ID) AND (RefID = @Original_RefID) AND (Archived = @Original_Archived O" +
				"R @Original_Archived IS NULL AND Archived IS NULL) AND (CleanoutCored = @Origina" +
				"l_CleanoutCored OR @Original_CleanoutCored IS NULL AND CleanoutCored IS NULL) AN" +
				"D (CleanoutGrouted = @Original_CleanoutGrouted OR @Original_CleanoutGrouted IS N" +
				"ULL AND CleanoutGrouted IS NULL) AND (CleanoutInstalled = @Original_CleanoutInst" +
				"alled OR @Original_CleanoutInstalled IS NULL AND CleanoutInstalled IS NULL) AND " +
				"(CleanoutRequired = @Original_CleanoutRequired OR @Original_CleanoutRequired IS " +
				"NULL AND CleanoutRequired IS NULL) AND (ConfirmedLatSize = @Original_ConfirmedLa" +
				"tSize OR @Original_ConfirmedLatSize IS NULL AND ConfirmedLatSize IS NULL) AND (D" +
				"eleted = @Original_Deleted OR @Original_Deleted IS NULL AND Deleted IS NULL) AND" +
				" (DetailID = @Original_DetailID) AND (DistanceFromUSMH = @Original_DistanceFromU" +
				"SMH OR @Original_DistanceFromUSMH IS NULL AND DistanceFromUSMH IS NULL) AND (Fin" +
				"alVideo = @Original_FinalVideo OR @Original_FinalVideo IS NULL AND FinalVideo IS" +
				" NULL) AND (LateralMaterial = @Original_LateralMaterial OR @Original_LateralMate" +
				"rial IS NULL AND LateralMaterial IS NULL) AND (LinerInStock = @Original_LinerInS" +
				"tock OR @Original_LinerInStock IS NULL AND LinerInStock IS NULL) AND (LinerInsta" +
				"lled = @Original_LinerInstalled OR @Original_LinerInstalled IS NULL AND LinerIns" +
				"talled IS NULL) AND (LinerOrdered = @Original_LinerOrdered OR @Original_LinerOrd" +
				"ered IS NULL AND LinerOrdered IS NULL) AND (LinerPrice = @Original_LinerPrice OR" +
				" @Original_LinerPrice IS NULL AND LinerPrice IS NULL) AND (MHShot = @Original_MH" +
				"Shot OR @Original_MHShot IS NULL AND MHShot IS NULL) AND (MN = @Original_MN OR @" +
				"Original_MN IS NULL AND MN IS NULL) AND (MainConnection = @Original_MainConnecti" +
				"on OR @Original_MainConnection IS NULL AND MainConnection IS NULL) AND (Measured" +
				"LatLength = @Original_MeasuredLatLength OR @Original_MeasuredLatLength IS NULL A" +
				"ND MeasuredLatLength IS NULL) AND (MeasurementsTakenBy = @Original_MeasurementsT" +
				"akenBy OR @Original_MeasurementsTakenBy IS NULL AND MeasurementsTakenBy IS NULL)" +
				" AND (PitInstalled = @Original_PitInstalled OR @Original_PitInstalled IS NULL AN" +
				"D PitInstalled IS NULL) AND (PitRequired = @Original_PitRequired OR @Original_Pi" +
				"tRequired IS NULL AND PitRequired IS NULL) AND (PrepCompleted = @Original_PrepCo" +
				"mpleted OR @Original_PrepCompleted IS NULL AND PrepCompleted IS NULL) AND (Resto" +
				"rationComplete = @Original_RestorationComplete OR @Original_RestorationComplete " +
				"IS NULL AND RestorationComplete IS NULL) AND (SharedLateral = @Original_SharedLa" +
				"teral OR @Original_SharedLateral IS NULL AND SharedLateral IS NULL) AND (Transit" +
				"ion = @Original_Transition OR @Original_Transition IS NULL AND Transition IS NUL" +
				"L); SELECT ID, RefID, COMPANY_ID, DetailID, MN, DistanceFromUSMH, ConfirmedLatSi" +
				"ze, LateralMaterial, SharedLateral, CleanoutRequired, PitRequired, MHShot, MainC" +
				"onnection, Transition, CleanoutInstalled, PitInstalled, CleanoutGrouted, Cleanou" +
				"tCored, PrepCompleted, MeasuredLatLength, MeasurementsTakenBy, LinerInstalled, F" +
				"inalVideo, RestorationComplete, LinerOrdered, LinerInStock, LinerPrice, Comments" +
				", Deleted, Archived FROM LFS_JUNCTION_LINER WHERE (COMPANY_ID = @COMPANY_ID) AND" +
				" (ID = @ID) AND (RefID = @RefID)";
			this.cmdLFSJunctionLinerUpdate.Connection = this.dcConnection;
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 4, "RefID"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 4, "COMPANY_ID"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DetailID", System.Data.SqlDbType.NVarChar, 50, "DetailID"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MN", System.Data.SqlDbType.NVarChar, 50, "MN"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceFromUSMH", System.Data.SqlDbType.Float, 8, "DistanceFromUSMH"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ConfirmedLatSize", System.Data.SqlDbType.NVarChar, 50, "ConfirmedLatSize"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LateralMaterial", System.Data.SqlDbType.NVarChar, 50, "LateralMaterial"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SharedLateral", System.Data.SqlDbType.NVarChar, 10, "SharedLateral"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CleanoutRequired", System.Data.SqlDbType.Bit, 1, "CleanoutRequired"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PitRequired", System.Data.SqlDbType.Bit, 1, "PitRequired"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MHShot", System.Data.SqlDbType.Bit, 1, "MHShot"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MainConnection", System.Data.SqlDbType.NVarChar, 10, "MainConnection"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Transition", System.Data.SqlDbType.NVarChar, 10, "Transition"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CleanoutInstalled", System.Data.SqlDbType.Bit, 1, "CleanoutInstalled"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PitInstalled", System.Data.SqlDbType.Bit, 1, "PitInstalled"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CleanoutGrouted", System.Data.SqlDbType.Bit, 1, "CleanoutGrouted"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CleanoutCored", System.Data.SqlDbType.Bit, 1, "CleanoutCored"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PrepCompleted", System.Data.SqlDbType.DateTime, 8, "PrepCompleted"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasuredLatLength", System.Data.SqlDbType.NVarChar, 50, "MeasuredLatLength"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MeasurementsTakenBy", System.Data.SqlDbType.NVarChar, 50, "MeasurementsTakenBy"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerInstalled", System.Data.SqlDbType.DateTime, 8, "LinerInstalled"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FinalVideo", System.Data.SqlDbType.DateTime, 8, "FinalVideo"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RestorationComplete", System.Data.SqlDbType.Bit, 1, "RestorationComplete"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerOrdered", System.Data.SqlDbType.Bit, 1, "LinerOrdered"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerInStock", System.Data.SqlDbType.Bit, 1, "LinerInStock"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerPrice", System.Data.SqlDbType.Money, 8, "LinerPrice"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NVarChar, 1073741823, "Comments"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 1, "Deleted"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Archived", System.Data.SqlDbType.Bit, 1, "Archived"));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "COMPANY_ID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RefID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Archived", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Archived", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CleanoutCored", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CleanoutCored", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CleanoutGrouted", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CleanoutGrouted", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CleanoutInstalled", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CleanoutInstalled", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CleanoutRequired", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CleanoutRequired", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ConfirmedLatSize", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ConfirmedLatSize", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Deleted", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DetailID", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DetailID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceFromUSMH", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromUSMH", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FinalVideo", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FinalVideo", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LateralMaterial", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LateralMaterial", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerInStock", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinerInStock", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerInstalled", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinerInstalled", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerOrdered", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinerOrdered", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinerPrice", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MHShot", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MHShot", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MN", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MN", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MainConnection", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MainConnection", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasuredLatLength", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MeasuredLatLength", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasurementsTakenBy", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MeasurementsTakenBy", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PitInstalled", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PitInstalled", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PitRequired", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PitRequired", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PrepCompleted", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrepCompleted", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RestorationComplete", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RestorationComplete", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SharedLateral", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SharedLateral", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Transition", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Transition", System.Data.DataRowVersion.Original, null));
			
			//--- ... cmdLfsJunctionLinerDelete
			this.cmdLFSJunctionLinerDelete.CommandText = "DELETE FROM LFS_JUNCTION_LINER WHERE (COMPANY_ID = @Original_COMPANY_ID) AND (ID " +
				"= @Original_ID) AND (RefID = @Original_RefID) AND (Archived = @Original_Archived" +
				" OR @Original_Archived IS NULL AND Archived IS NULL) AND (CleanoutCored = @Origi" +
				"nal_CleanoutCored OR @Original_CleanoutCored IS NULL AND CleanoutCored IS NULL) " +
				"AND (CleanoutGrouted = @Original_CleanoutGrouted OR @Original_CleanoutGrouted IS" +
				" NULL AND CleanoutGrouted IS NULL) AND (CleanoutInstalled = @Original_CleanoutIn" +
				"stalled OR @Original_CleanoutInstalled IS NULL AND CleanoutInstalled IS NULL) AN" +
				"D (CleanoutRequired = @Original_CleanoutRequired OR @Original_CleanoutRequired I" +
				"S NULL AND CleanoutRequired IS NULL) AND (ConfirmedLatSize = @Original_Confirmed" +
				"LatSize OR @Original_ConfirmedLatSize IS NULL AND ConfirmedLatSize IS NULL) AND " +
				"(Deleted = @Original_Deleted OR @Original_Deleted IS NULL AND Deleted IS NULL) A" +
				"ND (DetailID = @Original_DetailID) AND (DistanceFromUSMH = @Original_DistanceFro" +
				"mUSMH OR @Original_DistanceFromUSMH IS NULL AND DistanceFromUSMH IS NULL) AND (F" +
				"inalVideo = @Original_FinalVideo OR @Original_FinalVideo IS NULL AND FinalVideo " +
				"IS NULL) AND (LateralMaterial = @Original_LateralMaterial OR @Original_LateralMa" +
				"terial IS NULL AND LateralMaterial IS NULL) AND (LinerInStock = @Original_LinerI" +
				"nStock OR @Original_LinerInStock IS NULL AND LinerInStock IS NULL) AND (LinerIns" +
				"talled = @Original_LinerInstalled OR @Original_LinerInstalled IS NULL AND LinerI" +
				"nstalled IS NULL) AND (LinerOrdered = @Original_LinerOrdered OR @Original_LinerO" +
				"rdered IS NULL AND LinerOrdered IS NULL) AND (LinerPrice = @Original_LinerPrice " +
				"OR @Original_LinerPrice IS NULL AND LinerPrice IS NULL) AND (MHShot = @Original_" +
				"MHShot OR @Original_MHShot IS NULL AND MHShot IS NULL) AND (MN = @Original_MN OR" +
				" @Original_MN IS NULL AND MN IS NULL) AND (MainConnection = @Original_MainConnec" +
				"tion OR @Original_MainConnection IS NULL AND MainConnection IS NULL) AND (Measur" +
				"edLatLength = @Original_MeasuredLatLength OR @Original_MeasuredLatLength IS NULL" +
				" AND MeasuredLatLength IS NULL) AND (MeasurementsTakenBy = @Original_Measurement" +
				"sTakenBy OR @Original_MeasurementsTakenBy IS NULL AND MeasurementsTakenBy IS NUL" +
				"L) AND (PitInstalled = @Original_PitInstalled OR @Original_PitInstalled IS NULL " +
				"AND PitInstalled IS NULL) AND (PitRequired = @Original_PitRequired OR @Original_" +
				"PitRequired IS NULL AND PitRequired IS NULL) AND (PrepCompleted = @Original_Prep" +
				"Completed OR @Original_PrepCompleted IS NULL AND PrepCompleted IS NULL) AND (Res" +
				"torationComplete = @Original_RestorationComplete OR @Original_RestorationComplet" +
				"e IS NULL AND RestorationComplete IS NULL) AND (SharedLateral = @Original_Shared" +
				"Lateral OR @Original_SharedLateral IS NULL AND SharedLateral IS NULL) AND (Trans" +
				"ition = @Original_Transition OR @Original_Transition IS NULL AND Transition IS N" +
				"ULL)";
			this.cmdLFSJunctionLinerDelete.Connection = this.dcConnection;
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "COMPANY_ID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RefID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Archived", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Archived", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CleanoutCored", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CleanoutCored", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CleanoutGrouted", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CleanoutGrouted", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CleanoutInstalled", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CleanoutInstalled", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CleanoutRequired", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CleanoutRequired", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ConfirmedLatSize", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ConfirmedLatSize", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Deleted", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DetailID", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DetailID", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceFromUSMH", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromUSMH", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FinalVideo", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FinalVideo", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LateralMaterial", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LateralMaterial", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerInStock", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinerInStock", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerInstalled", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinerInstalled", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerOrdered", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinerOrdered", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinerPrice", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MHShot", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MHShot", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MN", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MN", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MainConnection", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MainConnection", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasuredLatLength", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MeasuredLatLength", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MeasurementsTakenBy", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MeasurementsTakenBy", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PitInstalled", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PitInstalled", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PitRequired", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PitRequired", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PrepCompleted", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PrepCompleted", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RestorationComplete", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RestorationComplete", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_SharedLateral", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SharedLateral", System.Data.DataRowVersion.Original, null));
			this.cmdLFSJunctionLinerDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Transition", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Transition", System.Data.DataRowVersion.Original, null));

            //--- daLFSJunctionLiner ******************************************************************************
            this.daLFSJunctionLiner2.DeleteCommand = this.cmdLFSJunctionLiner2Delete;
            this.daLFSJunctionLiner2.InsertCommand = this.cmdLFSJunctionLiner2Insert;
            this.daLFSJunctionLiner2.SelectCommand = this.cmdLFSJunctionLiner2Select;
            this.daLFSJunctionLiner2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										 new System.Data.Common.DataTableMapping("Table", "LFS_JUNCTION_LINER2", new System.Data.Common.DataColumnMapping[] {
																																																							   new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																							   new System.Data.Common.DataColumnMapping("RefID", "RefID"),
																																																							   new System.Data.Common.DataColumnMapping("COMPANY_ID", "COMPANY_ID"),
																																																							   new System.Data.Common.DataColumnMapping("DetailID", "DetailID"),
																																																							   new System.Data.Common.DataColumnMapping("Address", "Address"),
                                                                                                                                                                                                                               new System.Data.Common.DataColumnMapping("PipeLocated", "PipeLocated"),
																																																							   new System.Data.Common.DataColumnMapping("ServicesLocated", "ServicesLocated"),
                                                                                                                                                                                                                               new System.Data.Common.DataColumnMapping("CoInstalled", "CoInstalled"),
                                                                                                                                                                                                                               new System.Data.Common.DataColumnMapping("BackfilledConcrete", "BackfilledConcrete"),
                                                                                                                                                                                                                               new System.Data.Common.DataColumnMapping("BackfilledSoil", "BackfilledSoil"),
                                                                                                                                                                                                                               new System.Data.Common.DataColumnMapping("Grouted", "Grouted"),
                                                                                                                                                                                                                               new System.Data.Common.DataColumnMapping("Cored", "Cored"),
                                                                                                                                                                                                                               new System.Data.Common.DataColumnMapping("Prepped", "Prepped"),
                                                                                                                                                                                                                               new System.Data.Common.DataColumnMapping("Measured", "Measured"),
                                                                                                                                                                                                                               new System.Data.Common.DataColumnMapping("LinerSize", "LinerSize"),
                                                                                                                                                                                                                               new System.Data.Common.DataColumnMapping("PreVideo", "PreVideo"),
                                                                                                                                                                                                                               new System.Data.Common.DataColumnMapping("FinalVideo", "FinalVideo"),
                                                                                                                                                                                                                               new System.Data.Common.DataColumnMapping("DistanceFromDSMH", "DistanceFromDSMH"),
                                                                                                                                                                                                                               new System.Data.Common.DataColumnMapping("DistanceFromUSMH", "DistanceFromUSMH"),
																																																							   new System.Data.Common.DataColumnMapping("LinerInstalled", "LinerInstalled"),
																																																							   new System.Data.Common.DataColumnMapping("Map", "Map"),
                                                                                                                                                                                                                               new System.Data.Common.DataColumnMapping("Deleted", "Deleted")})});
            this.daLFSJunctionLiner2.UpdateCommand = this.cmdLFSJunctionLiner2Update;

            //--- ... cmdLfsJunctionLinerSelect
            this.cmdLFSJunctionLiner2Select.CommandText = @"SELECT ID, RefID, COMPANY_ID, DetailID, Address, PipeLocated, ServicesLocated, CoInstalled, BackfilledConcrete, BackfilledSoil, Grouted, Cored, Prepped, Measured, LinerSize, PreVideo, FinalVideo, DistanceFromDSMH, DistanceFromUSMH, LinerInstalled, Map, Deleted FROM LFS_JUNCTION_LINER2";
            this.cmdLFSJunctionLiner2Select.Connection = this.dcConnection;

            //--- ... cmdLfsJunctionLinerInsert
            this.cmdLFSJunctionLiner2Insert.CommandText = @"INSERT INTO LFS_JUNCTION_LINER2(ID, RefID, COMPANY_ID, DetailID, Address, PipeLocated, ServicesLocated, CoInstalled, BackfilledConcrete, BackfilledSoil, Grouted, Cored, Prepped, Measured, LinerSize, PreVideo, FinalVideo, DistanceFromDSMH, DistanceFromUSMH, LinerInstalled, Map, Deleted) VALUES (@ID, @RefID, @COMPANY_ID, @DetailID, @Address, @PipeLocated, @ServicesLocated, @CoInstalled, @BackfilledConcrete, @BackfilledSoil, @Grouted, @Cored, @Prepped, @Measured, @LinerSize, @PreVideo, @FinalVideo, @DistanceFromDSMH, @DistanceFromUSMH, @LinerInstalled, @Map, @Deleted); SELECT ID, RefID, COMPANY_ID, DetailID, Address, PipeLocated, ServicesLocated, CoInstalled, BackfilledConcrete, BackfilledSoil, Grouted, Cored, Prepped, Measured, LinerSize, PreVideo, FinalVideo, DistanceFromDSMH, DistanceFromUSMH, LinerInstalled, Map, Deleted FROM LFS_JUNCTION_LINER2 WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RefID = @RefID)";
            this.cmdLFSJunctionLiner2Insert.Connection = this.dcConnection;
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 4, "RefID"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 4, "COMPANY_ID"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DetailID", System.Data.SqlDbType.NVarChar, 50, "DetailID"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 50, "Address"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PipeLocated", System.Data.SqlDbType.DateTime, 8, "PipeLocated"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServicesLocated", System.Data.SqlDbType.DateTime, 8, "ServicesLocated"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CoInstalled", System.Data.SqlDbType.DateTime, 8, "CoInstalled"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BackfilledConcrete", System.Data.SqlDbType.DateTime, 8, "BackfilledConcrete"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BackfilledSoil", System.Data.SqlDbType.DateTime, 8, "BackfilledSoil"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Grouted", System.Data.SqlDbType.DateTime, 8, "Grouted"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Prepped", System.Data.SqlDbType.DateTime, 8, "Prepped"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cored", System.Data.SqlDbType.DateTime, 8, "Cored"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Measured", System.Data.SqlDbType.DateTime, 8, "Measured"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerSize", System.Data.SqlDbType.VarChar, 40, "LinerSize"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PreVideo", System.Data.SqlDbType.DateTime, 8, "PreVideo"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerInstalled", System.Data.SqlDbType.DateTime, 8, "LinerInstalled"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FinalVideo", System.Data.SqlDbType.DateTime, 8, "FinalVideo"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 1, "Deleted"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceFromUSMH", System.Data.SqlDbType.Float, 8, "DistanceFromUSMH"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceFromDSMH", System.Data.SqlDbType.Float, 8, "DistanceFromDSMH"));
            this.cmdLFSJunctionLiner2Insert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Map", System.Data.SqlDbType.NVarChar, 50, "Map"));

            //--- ... cmdLfsJunctionLinerUpdate
            this.cmdLFSJunctionLiner2Update.CommandText = "UPDATE LFS_JUNCTION_LINER2 SET ID = @ID, RefID = @RefID, COMPANY_ID = @COMPANY_ID," +
                " DetailID = @DetailID, Address = @Address, PipeLocated = @PipeLocated, ServicesLocated" +
                " = @ServicesLocated, CoInstalled = @CoInstalled, BackfilledConcrete =" +
                " @BackfilledConcrete, BackfilledSoil = @BackfilledSoil, Grouted = @Grouted" +
                ", Prepped = @Prepped, Measured = @Measured, Cored = @Cored, LinerSize = @LinerSize," +
                " PreVideo = @PreVideo, LinerInstalled = @LinerInstalled, FinalVideo" +
                " = @FinalVideo, Deleted = @Deleted, DistanceFromUSMH = @DistanceFromUSMH" +
                ", DistanceFromDSMH = @DistanceFromDSMH, Map = @Map" +
                " WHERE (COMPANY_ID = @Original_COMPANY_ID) AND (ID = " +
                "@Original_ID) AND (RefID = @Original_RefID) AND (Address = @Original_Address O" +
                "R @Original_Address IS NULL AND Address IS NULL) AND (PipeLocated = @Origina" +
                "l_PipeLocated OR @Original_PipeLocated IS NULL AND PipeLocated IS NULL) AN" +
                "D (ServicesLocated = @Original_ServicesLocated OR @Original_ServicesLocated IS N" +
                "ULL AND ServicesLocated IS NULL) AND (CoInstalled = @Original_CoInstalled" +
                " OR @Original_CoInstalled IS NULL AND CoInstalled IS NULL) AND " +
                "(BackfilledConcrete = @Original_BackfilledConcrete OR @Original_BackfilledConcrete IS " +
                "NULL AND BackfilledConcrete IS NULL) AND (BackfilledSoil = @Original_BackfilledSoil" +
                " OR @Original_BackfilledSoil IS NULL AND BackfilledSoil IS NULL) AND (D" +
                "eleted = @Original_Deleted OR @Original_Deleted IS NULL AND Deleted IS NULL) AND" +
                " (DetailID = @Original_DetailID OR @Original_DetailID IS NULL AND DetailID IS NULL) AND (DistanceFromUSMH = @Original_DistanceFromU" +
                "SMH OR @Original_DistanceFromUSMH IS NULL AND DistanceFromUSMH IS NULL) AND (Fin" +
                "alVideo = @Original_FinalVideo OR @Original_FinalVideo IS NULL AND FinalVideo IS" +
                " NULL) AND (Grouted = @Original_Grouted OR @Original_Grouted" +
                " IS NULL AND Grouted IS NULL) AND (Cored = @Original_Cored" +
                " OR @Original_Cored IS NULL AND Cored IS NULL) AND (LinerInsta" +
                "lled = @Original_LinerInstalled OR @Original_LinerInstalled IS NULL AND LinerIns" +
                "talled IS NULL) AND (Prepped = @Original_Prepped OR @Original_Prepped" +
                " IS NULL AND Prepped IS NULL) AND (Measured = @Original_Measured OR" +
                " @Original_Measured IS NULL AND Measured IS NULL) AND (LinerSize = @Original_LinerSize" +
                " OR @Original_LinerSize IS NULL AND LinerSize IS NULL) AND (PreVideo" +
                " = @Original_PreVideo OR @Original_PreVideo IS NULL AND PreVideo IS NUL" +
                "L) AND (DistanceFromDSMH = @Original_DistanceFromD" +
                "SMH OR @Original_DistanceFromDSMH IS NULL AND DistanceFromDSMH IS NULL); SELECT ID, RefID, COMPANY_ID, DetailID, Address, DistanceFromUSMH, DistanceFromDSMH" +
                " , PipeLocated, ServicesLocated, BackfilledConcrete, BackfilledSoil," +
                " CoInstalled, Grouted, LinerSize, PreVideo, Cored, Prepped, Measured, Map, LinerInstalled, " +
                "FinalVideo, Deleted FROM LFS_JUNCTION_LINER2 WHERE (COMPANY_ID = @COMPANY_ID) AND" +
                " (ID = @ID) AND (RefID = @RefID)";
            this.cmdLFSJunctionLiner2Update.Connection = this.dcConnection;
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 4, "RefID"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 4, "COMPANY_ID"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DetailID", System.Data.SqlDbType.NVarChar, 50, "DetailID"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 50, "Address"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceFromUSMH", System.Data.SqlDbType.Float, 8, "DistanceFromUSMH"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DistanceFromDSMH", System.Data.SqlDbType.Float, 8, "DistanceFromDSMH"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PipeLocated", System.Data.SqlDbType.DateTime, 8, "PipeLocated"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServicesLocated", System.Data.SqlDbType.DateTime, 8, "ServicesLocated"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CoInstalled", System.Data.SqlDbType.DateTime, 8, "CoInstalled"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BackfilledConcrete", System.Data.SqlDbType.DateTime, 8, "BackfilledConcrete"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BackfilledSoil", System.Data.SqlDbType.DateTime, 8, "BackfilledSoil"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Grouted", System.Data.SqlDbType.DateTime, 8, "Grouted"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Prepped", System.Data.SqlDbType.DateTime, 8, "Prepped"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cored", System.Data.SqlDbType.DateTime, 8, "Cored"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Measured", System.Data.SqlDbType.DateTime, 8, "Measured"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PreVideo", System.Data.SqlDbType.DateTime, 8, "PreVideo"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerSize", System.Data.SqlDbType.VarChar, 40, "LinerSize"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Map", System.Data.SqlDbType.NVarChar, 50, "Map"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerInstalled", System.Data.SqlDbType.DateTime, 8, "LinerInstalled"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FinalVideo", System.Data.SqlDbType.DateTime, 8, "FinalVideo"));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 1, "Deleted"));
            
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "COMPANY_ID", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RefID", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Address", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PipeLocated", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PipeLocated", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ServicesLocated", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ServicesLocated", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CoInstalled", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoInstalled", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BackfilledConcrete", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BackfilledConcrete", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BackfilledSoil", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BackfilledSoil", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Deleted", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DetailID", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DetailID", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceFromUSMH", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromUSMH", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceFromDSMH", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromDSMH", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FinalVideo", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FinalVideo", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Grouted", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Grouted", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cored", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Cored", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Prepped", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Prepped", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerInstalled", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinerInstalled", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Measured", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Measured", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerSize", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinerSize", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PreVideo", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PreVideo", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Update.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Map", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Map", System.Data.DataRowVersion.Original, null));
            
            //--- ... cmdLfsJunctionLinerDelete
            this.cmdLFSJunctionLiner2Delete.CommandText = "DELETE FROM LFS_JUNCTION_LINER2 WHERE (COMPANY_ID = @Original_COMPANY_ID) AND (ID " +
                "= @Original_ID) AND (RefID = @Original_RefID) AND (Address = @Original_Address" +
                " OR @Original_Address IS NULL AND Address IS NULL) AND (PipeLocated = @Origi" +
                "nal_PipeLocated OR @Original_PipeLocated IS NULL AND PipeLocated IS NULL) " +
                "AND (ServicesLocated = @Original_ServicesLocated OR @Original_ServicesLocated IS" +
                " NULL AND ServicesLocated IS NULL) AND (CoInstalled = @Original_CoInstalled" +
                " OR @Original_CoInstalled IS NULL AND CoInstalled IS NULL) AND" +
                " (BackfilledConcrete = @Original_BackfilledConcrete OR @Original_BackfilledConcrete I" +
                "S NULL AND BackfilledConcrete IS NULL) AND (BackfilledSoil = @Original_BackfilledSoil" +
                " OR @Original_BackfilledSoil IS NULL AND BackfilledSoil IS NULL) AND " +
                "(Deleted = @Original_Deleted OR @Original_Deleted IS NULL AND Deleted IS NULL) A" +
                "ND (DetailID = @Original_DetailID OR @Original_DetailID IS NULL AND DetailID IS NULL) AND (DistanceFromUSMH = @Original_DistanceFro" +
                "mUSMH OR @Original_DistanceFromUSMH IS NULL AND DistanceFromUSMH IS NULL) AND (F" +
                "inalVideo = @Original_FinalVideo OR @Original_FinalVideo IS NULL AND FinalVideo " +
                "IS NULL) AND (DistanceFromDSMH = @Original_DistanceFromDSMH OR @Original_DistanceFromDSMH" +
                " IS NULL AND DistanceFromDSMH IS NULL) AND (Grouted = @Original_Grouted" +
                " OR @Original_Grouted IS NULL AND Grouted IS NULL) AND (LinerIns" +
                "talled = @Original_LinerInstalled OR @Original_LinerInstalled IS NULL AND LinerI" +
                "nstalled IS NULL) AND (Cored = @Original_Cored OR @Original_Co" +
                "red IS NULL AND Cored IS NULL) AND (Prepped = @Original_Prepped " +
                "OR @Original_Prepped IS NULL AND Prepped IS NULL) AND (Measured = @Original_" +
                "Measured OR @Original_Measured IS NULL AND Measured IS NULL) AND (LinerSize = @Original_LinerSize OR" +
                " @Original_LinerSize IS NULL AND LinerSize IS NULL) AND (PreVideo = @Original_Pre" +
                "Video OR @Original_PreVideo IS NULL AND PreVideo IS NULL) AND (Map" +
                " = @Original_Map OR @Original_Map IS NULL AND Map IS N" +
                "ULL)";
            this.cmdLFSJunctionLiner2Delete.Connection = this.dcConnection;
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "COMPANY_ID", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RefID", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Address", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PipeLocated", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PipeLocated", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ServicesLocated", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ServicesLocated", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CoInstalled", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CoInstalled", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BackfilledConcrete", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BackfilledConcrete", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BackfilledSoil", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BackfilledSoil", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Deleted", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DetailID", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DetailID", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceFromUSMH", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromUSMH", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DistanceFromDSMH", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "DistanceFromDSMH", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FinalVideo", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FinalVideo", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Grouted", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Grouted", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cored", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Cored", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Prepped", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Prepped", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerInstalled", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinerInstalled", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Measured", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Measured", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerSize", System.Data.SqlDbType.VarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "LinerSize", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PreVideo", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "PreVideo", System.Data.DataRowVersion.Original, null));
            this.cmdLFSJunctionLiner2Delete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Map", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Map", System.Data.DataRowVersion.Original, null));

			//--- daLFSMasterAreaRct ******************************************************************************
			this.daLfsMasterAreaRct.DeleteCommand = this.cmdLfsMasterAreaRctDelete;
			this.daLfsMasterAreaRct.InsertCommand = this.cmdLfsMasterAreaRctInsert;
			this.daLfsMasterAreaRct.SelectCommand = this.cmdLfsMasterAreaRctSelect;
			this.daLfsMasterAreaRct.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										 new System.Data.Common.DataTableMapping("Table", "LFS_MASTER_AREA_RCT", new System.Data.Common.DataColumnMapping[] {
																																																								new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																								new System.Data.Common.DataColumnMapping("COMPANY_ID", "COMPANY_ID"),
																																																								new System.Data.Common.DataColumnMapping("RctID", "RctID"),
																																																								new System.Data.Common.DataColumnMapping("Changes", "Changes"),
																																																								new System.Data.Common.DataColumnMapping("Operation", "Operation"),
																																																								new System.Data.Common.DataColumnMapping("ChangedBy", "ChangedBy"),
																																																								new System.Data.Common.DataColumnMapping("Changed", "Changed")})});
			this.daLfsMasterAreaRct.UpdateCommand = this.cmdLfsMasterAreaRctUpdate;

			//--- ... cmdLfsMasterAreaRctSelect
			this.cmdLfsMasterAreaRctSelect.CommandText = "SELECT ID, COMPANY_ID, RctID, Changes, Operation, ChangedBy, Changed FROM LFS_MASTER_AREA_RCT";
			this.cmdLfsMasterAreaRctSelect.Connection = this.dcConnection;

			//--- ... cmdLfsMasterAreaRctInsert
			this.cmdLfsMasterAreaRctInsert.CommandText = @"INSERT INTO LFS_MASTER_AREA_RCT(ID, COMPANY_ID, Changes, Operation, ChangedBy, Changed) VALUES (@ID, @COMPANY_ID, @Changes, @Operation, @ChangedBy, @Changed); SELECT ID, COMPANY_ID, RctID, Changes, Operation, ChangedBy, Changed FROM LFS_MASTER_AREA_RCT WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RctID = @@IDENTITY)";
			this.cmdLfsMasterAreaRctInsert.Connection = this.dcConnection;
			this.cmdLfsMasterAreaRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
			this.cmdLfsMasterAreaRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 4, "COMPANY_ID"));
			this.cmdLfsMasterAreaRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Changes", System.Data.SqlDbType.NVarChar, 1073741823, "Changes"));
			this.cmdLfsMasterAreaRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Operation", System.Data.SqlDbType.NVarChar, 10, "Operation"));
			this.cmdLfsMasterAreaRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ChangedBy", System.Data.SqlDbType.Int, 4, "ChangedBy"));
			this.cmdLfsMasterAreaRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Changed", System.Data.SqlDbType.DateTime, 4, "Changed"));

			//--- ... cmdLfsMasterAreaRctUpdate
			this.cmdLfsMasterAreaRctUpdate.CommandText = @"UPDATE LFS_MASTER_AREA_RCT SET ID = @ID, COMPANY_ID = @COMPANY_ID, Changes = @Changes, Operation = @Operation, ChangedBy = @ChangedBy, Changed = @Changed WHERE (COMPANY_ID = @Original_COMPANY_ID) AND (ID = @Original_ID) AND (RctID = @Original_RctID) AND (Changed = @Original_Changed OR @Original_Changed IS NULL AND Changed IS NULL) AND (ChangedBy = @Original_ChangedBy OR @Original_ChangedBy IS NULL AND ChangedBy IS NULL) AND (Operation = @Original_Operation OR @Original_Operation IS NULL AND Operation IS NULL); SELECT ID, COMPANY_ID, RctID, Changes, Operation, ChangedBy, Changed FROM LFS_MASTER_AREA_RCT WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RctID = @RctID)";
			this.cmdLfsMasterAreaRctUpdate.Connection = this.dcConnection;
			this.cmdLfsMasterAreaRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
			this.cmdLfsMasterAreaRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 4, "COMPANY_ID"));
			this.cmdLfsMasterAreaRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Changes", System.Data.SqlDbType.NVarChar, 1073741823, "Changes"));
			this.cmdLfsMasterAreaRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Operation", System.Data.SqlDbType.NVarChar, 10, "Operation"));
			this.cmdLfsMasterAreaRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ChangedBy", System.Data.SqlDbType.Int, 4, "ChangedBy"));
			this.cmdLfsMasterAreaRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Changed", System.Data.SqlDbType.DateTime, 4, "Changed"));
			this.cmdLfsMasterAreaRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "COMPANY_ID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsMasterAreaRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsMasterAreaRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RctID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RctID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsMasterAreaRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Changed", System.Data.SqlDbType.DateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Changed", System.Data.DataRowVersion.Original, null));
			this.cmdLfsMasterAreaRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ChangedBy", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChangedBy", System.Data.DataRowVersion.Original, null));
			this.cmdLfsMasterAreaRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Operation", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Operation", System.Data.DataRowVersion.Original, null));
			this.cmdLfsMasterAreaRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RctID", System.Data.SqlDbType.Int, 4, "RctID"));

			//--- ... cmdLfsMasterAreaRctDelete
			this.cmdLfsMasterAreaRctDelete.CommandText = @"DELETE FROM LFS_MASTER_AREA_RCT WHERE (COMPANY_ID = @Original_COMPANY_ID) AND (ID = @Original_ID) AND (RctID = @Original_RctID) AND (Changed = @Original_Changed OR @Original_Changed IS NULL AND Changed IS NULL) AND (ChangedBy = @Original_ChangedBy OR @Original_ChangedBy IS NULL AND ChangedBy IS NULL) AND (Operation = @Original_Operation OR @Original_Operation IS NULL AND Operation IS NULL)";
			this.cmdLfsMasterAreaRctDelete.Connection = this.dcConnection;
			this.cmdLfsMasterAreaRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "COMPANY_ID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsMasterAreaRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsMasterAreaRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RctID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RctID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsMasterAreaRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Changed", System.Data.SqlDbType.DateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Changed", System.Data.DataRowVersion.Original, null));
			this.cmdLfsMasterAreaRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ChangedBy", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChangedBy", System.Data.DataRowVersion.Original, null));
			this.cmdLfsMasterAreaRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Operation", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Operation", System.Data.DataRowVersion.Original, null));

			//--- daLfsPointRepairsRct ******************************************************************************
			this.daLfsPointRepairsRct.DeleteCommand = this.cmdLfsPointRepairsRctDelete;
			this.daLfsPointRepairsRct.InsertCommand = this.cmdLfsPointRepairsRctInsert;
			this.daLfsPointRepairsRct.SelectCommand = this.cmdLfsPointRepairsRctSelect;
			this.daLfsPointRepairsRct.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										   new System.Data.Common.DataTableMapping("Table", "LFS_POINT_REPAIRS_RCT", new System.Data.Common.DataColumnMapping[] {
																																																									new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																									new System.Data.Common.DataColumnMapping("RefID", "RefID"),
																																																									new System.Data.Common.DataColumnMapping("COMPANY_ID", "COMPANY_ID"),
																																																									new System.Data.Common.DataColumnMapping("RctID", "RctID"),
																																																									new System.Data.Common.DataColumnMapping("Changes", "Changes"),
																																																									new System.Data.Common.DataColumnMapping("Operation", "Operation"),
																																																									new System.Data.Common.DataColumnMapping("ChangedBy", "ChangedBy"),
																																																									new System.Data.Common.DataColumnMapping("Changed", "Changed")})});
			this.daLfsPointRepairsRct.UpdateCommand = this.cmdLfsPointRepairsRctUpdate;

			//--- ... cmdLfsPointRepairsRctSelect
			this.cmdLfsPointRepairsRctSelect.CommandText = "SELECT ID, RefID, COMPANY_ID, RctID, Changes, Operation, ChangedBy, Changed FROM LFS_POINT_REPAIRS_RCT";
			this.cmdLfsPointRepairsRctSelect.Connection = this.dcConnection;

			//--- ... cmdLfsPointRepairsRctInsert
			this.cmdLfsPointRepairsRctInsert.CommandText = @"INSERT INTO LFS_POINT_REPAIRS_RCT(ID, RefID, COMPANY_ID, Changes, Operation, ChangedBy, Changed) VALUES (@ID, @RefID, @COMPANY_ID, @Changes, @Operation, @ChangedBy, @Changed); SELECT ID, RefID, COMPANY_ID, RctID, Changes, Operation, ChangedBy, Changed FROM LFS_POINT_REPAIRS_RCT WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RctID = @@IDENTITY) AND (RefID = @RefID)";
			this.cmdLfsPointRepairsRctInsert.Connection = this.dcConnection;
			this.cmdLfsPointRepairsRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
			this.cmdLfsPointRepairsRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 4, "RefID"));
			this.cmdLfsPointRepairsRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 4, "COMPANY_ID"));
			this.cmdLfsPointRepairsRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Changes", System.Data.SqlDbType.NVarChar, 1073741823, "Changes"));
			this.cmdLfsPointRepairsRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Operation", System.Data.SqlDbType.NVarChar, 10, "Operation"));
			this.cmdLfsPointRepairsRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ChangedBy", System.Data.SqlDbType.Int, 4, "ChangedBy"));
			this.cmdLfsPointRepairsRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Changed", System.Data.SqlDbType.DateTime, 4, "Changed"));

			//--- ... cmdLfsPointRepairsRctUpdate
			this.cmdLfsPointRepairsRctUpdate.CommandText = @"UPDATE LFS_POINT_REPAIRS_RCT SET ID = @ID, RefID = @RefID, COMPANY_ID = @COMPANY_ID, Changes = @Changes, Operation = @Operation, ChangedBy = @ChangedBy, Changed = @Changed WHERE (COMPANY_ID = @Original_COMPANY_ID) AND (ID = @Original_ID) AND (RctID = @Original_RctID) AND (RefID = @Original_RefID) AND (Changed = @Original_Changed OR @Original_Changed IS NULL AND Changed IS NULL) AND (ChangedBy = @Original_ChangedBy OR @Original_ChangedBy IS NULL AND ChangedBy IS NULL) AND (Operation = @Original_Operation OR @Original_Operation IS NULL AND Operation IS NULL); SELECT ID, RefID, COMPANY_ID, RctID, Changes, Operation, ChangedBy, Changed FROM LFS_POINT_REPAIRS_RCT WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RctID = @RctID) AND (RefID = @RefID)";
			this.cmdLfsPointRepairsRctUpdate.Connection = this.dcConnection;
			this.cmdLfsPointRepairsRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
			this.cmdLfsPointRepairsRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 4, "RefID"));
			this.cmdLfsPointRepairsRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 4, "COMPANY_ID"));
			this.cmdLfsPointRepairsRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Changes", System.Data.SqlDbType.NVarChar, 1073741823, "Changes"));
			this.cmdLfsPointRepairsRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Operation", System.Data.SqlDbType.NVarChar, 10, "Operation"));
			this.cmdLfsPointRepairsRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ChangedBy", System.Data.SqlDbType.Int, 4, "ChangedBy"));
			this.cmdLfsPointRepairsRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Changed", System.Data.SqlDbType.DateTime, 4, "Changed"));
			this.cmdLfsPointRepairsRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "COMPANY_ID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsPointRepairsRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsPointRepairsRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RctID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RctID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsPointRepairsRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RefID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsPointRepairsRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Changed", System.Data.SqlDbType.DateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Changed", System.Data.DataRowVersion.Original, null));
			this.cmdLfsPointRepairsRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ChangedBy", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChangedBy", System.Data.DataRowVersion.Original, null));
			this.cmdLfsPointRepairsRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Operation", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Operation", System.Data.DataRowVersion.Original, null));
			this.cmdLfsPointRepairsRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RctID", System.Data.SqlDbType.Int, 4, "RctID"));

			//--- ... cmdLfsPointRepairsRctDelete
			this.cmdLfsPointRepairsRctDelete.CommandText = @"DELETE FROM LFS_POINT_REPAIRS_RCT WHERE (COMPANY_ID = @Original_COMPANY_ID) AND (ID = @Original_ID) AND (RctID = @Original_RctID) AND (RefID = @Original_RefID) AND (Changed = @Original_Changed OR @Original_Changed IS NULL AND Changed IS NULL) AND (ChangedBy = @Original_ChangedBy OR @Original_ChangedBy IS NULL AND ChangedBy IS NULL) AND (Operation = @Original_Operation OR @Original_Operation IS NULL AND Operation IS NULL)";
			this.cmdLfsPointRepairsRctDelete.Connection = this.dcConnection;
			this.cmdLfsPointRepairsRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "COMPANY_ID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsPointRepairsRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsPointRepairsRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RctID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RctID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsPointRepairsRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RefID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsPointRepairsRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Changed", System.Data.SqlDbType.DateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Changed", System.Data.DataRowVersion.Original, null));
			this.cmdLfsPointRepairsRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ChangedBy", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChangedBy", System.Data.DataRowVersion.Original, null));
			this.cmdLfsPointRepairsRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Operation", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Operation", System.Data.DataRowVersion.Original, null));

			//--- daLfsM2TablesRct ******************************************************************************
			this.daLfsM2TablesRct.DeleteCommand = this.cmdLfsM2TablesRctDelete;
			this.daLfsM2TablesRct.InsertCommand = this.cmdLfsM2TablesRctInsert;
			this.daLfsM2TablesRct.SelectCommand = this.cmdLfsM2TablesRctSelect;
			this.daLfsM2TablesRct.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "LFS_M2_TABLES_RCT", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																							new System.Data.Common.DataColumnMapping("RefID", "RefID"),
																																																							new System.Data.Common.DataColumnMapping("COMPANY_ID", "COMPANY_ID"),
																																																							new System.Data.Common.DataColumnMapping("RctID", "RctID"),
																																																							new System.Data.Common.DataColumnMapping("Changes", "Changes"),
																																																							new System.Data.Common.DataColumnMapping("Operation", "Operation"),
																																																							new System.Data.Common.DataColumnMapping("ChangedBy", "ChangedBy"),
																																																							new System.Data.Common.DataColumnMapping("Changed", "Changed")})});
			this.daLfsM2TablesRct.UpdateCommand = this.cmdLfsM2TablesRctUpdate;

			//--- ... cmdLfsM2TablesRctSelect
			this.cmdLfsM2TablesRctSelect.CommandText = "SELECT ID, RefID, COMPANY_ID, RctID, Changes, Operation, ChangedBy, Changed FROM LFS_M2_TABLES_RCT";
			this.cmdLfsM2TablesRctSelect.Connection = this.dcConnection;

			//--- ... cmdLfsM2TablesRctInsert
			this.cmdLfsM2TablesRctInsert.CommandText = @"INSERT INTO LFS_M2_TABLES_RCT(ID, RefID, COMPANY_ID, Changes, Operation, ChangedBy, Changed) VALUES (@ID, @RefID, @COMPANY_ID, @Changes, @Operation, @ChangedBy, @Changed); SELECT ID, RefID, COMPANY_ID, RctID, Changes, Operation, ChangedBy, Changed FROM LFS_M2_TABLES_RCT WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RctID = @@IDENTITY) AND (RefID = @RefID)";
			this.cmdLfsM2TablesRctInsert.Connection = this.dcConnection;
			this.cmdLfsM2TablesRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
			this.cmdLfsM2TablesRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 4, "RefID"));
			this.cmdLfsM2TablesRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 4, "COMPANY_ID"));
			this.cmdLfsM2TablesRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Changes", System.Data.SqlDbType.NVarChar, 1073741823, "Changes"));
			this.cmdLfsM2TablesRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Operation", System.Data.SqlDbType.NVarChar, 10, "Operation"));
			this.cmdLfsM2TablesRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ChangedBy", System.Data.SqlDbType.Int, 4, "ChangedBy"));
			this.cmdLfsM2TablesRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Changed", System.Data.SqlDbType.DateTime, 4, "Changed"));

			//--- ... cmdLfsM2TablesRctUpdate
			this.cmdLfsM2TablesRctUpdate.CommandText = @"UPDATE LFS_M2_TABLES_RCT SET ID = @ID, RefID = @RefID, COMPANY_ID = @COMPANY_ID, Changes = @Changes, Operation = @Operation, ChangedBy = @ChangedBy, Changed = @Changed WHERE (COMPANY_ID = @Original_COMPANY_ID) AND (ID = @Original_ID) AND (RctID = @Original_RctID) AND (RefID = @Original_RefID) AND (Changed = @Original_Changed OR @Original_Changed IS NULL AND Changed IS NULL) AND (ChangedBy = @Original_ChangedBy OR @Original_ChangedBy IS NULL AND ChangedBy IS NULL) AND (Operation = @Original_Operation OR @Original_Operation IS NULL AND Operation IS NULL); SELECT ID, RefID, COMPANY_ID, RctID, Changes, Operation, ChangedBy, Changed FROM LFS_M2_TABLES_RCT WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RctID = @RctID) AND (RefID = @RefID)";
			this.cmdLfsM2TablesRctUpdate.Connection = this.dcConnection;
			this.cmdLfsM2TablesRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
			this.cmdLfsM2TablesRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 4, "RefID"));
			this.cmdLfsM2TablesRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 4, "COMPANY_ID"));
			this.cmdLfsM2TablesRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Changes", System.Data.SqlDbType.NVarChar, 1073741823, "Changes"));
			this.cmdLfsM2TablesRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Operation", System.Data.SqlDbType.NVarChar, 10, "Operation"));
			this.cmdLfsM2TablesRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ChangedBy", System.Data.SqlDbType.Int, 4, "ChangedBy"));
			this.cmdLfsM2TablesRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Changed", System.Data.SqlDbType.DateTime, 4, "Changed"));
			this.cmdLfsM2TablesRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "COMPANY_ID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsM2TablesRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsM2TablesRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RctID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RctID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsM2TablesRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RefID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsM2TablesRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Changed", System.Data.SqlDbType.DateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Changed", System.Data.DataRowVersion.Original, null));
			this.cmdLfsM2TablesRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ChangedBy", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChangedBy", System.Data.DataRowVersion.Original, null));
			this.cmdLfsM2TablesRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Operation", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Operation", System.Data.DataRowVersion.Original, null));
			this.cmdLfsM2TablesRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RctID", System.Data.SqlDbType.Int, 4, "RctID"));

			//--- ... cmdLfsM2TablesRctDelete
			this.cmdLfsM2TablesRctDelete.CommandText = @"DELETE FROM LFS_M2_TABLES_RCT WHERE (COMPANY_ID = @Original_COMPANY_ID) AND (ID = @Original_ID) AND (RctID = @Original_RctID) AND (RefID = @Original_RefID) AND (Changed = @Original_Changed OR @Original_Changed IS NULL AND Changed IS NULL) AND (ChangedBy = @Original_ChangedBy OR @Original_ChangedBy IS NULL AND ChangedBy IS NULL) AND (Operation = @Original_Operation OR @Original_Operation IS NULL AND Operation IS NULL)";
			this.cmdLfsM2TablesRctDelete.Connection = this.dcConnection;
			this.cmdLfsM2TablesRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "COMPANY_ID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsM2TablesRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsM2TablesRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RctID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RctID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsM2TablesRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RefID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsM2TablesRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Changed", System.Data.SqlDbType.DateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Changed", System.Data.DataRowVersion.Original, null));
			this.cmdLfsM2TablesRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ChangedBy", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChangedBy", System.Data.DataRowVersion.Original, null));
			this.cmdLfsM2TablesRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Operation", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Operation", System.Data.DataRowVersion.Original, null));

			//--- daLfsJunctionLinerRct ******************************************************************************
			this.daLfsJunctionLinerRct.DeleteCommand = this.cmdLfsJunctionLinerRctDelete;
			this.daLfsJunctionLinerRct.InsertCommand = this.cmdLfsJunctionLinerRctInsert;
			this.daLfsJunctionLinerRct.SelectCommand = this.cmdLfsJunctionLinerRctSelect;
			this.daLfsJunctionLinerRct.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "LFS_JUNCTION_LINER_RCT", new System.Data.Common.DataColumnMapping[] {
																																																									  new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																									  new System.Data.Common.DataColumnMapping("RefID", "RefID"),
																																																									  new System.Data.Common.DataColumnMapping("COMPANY_ID", "COMPANY_ID"),
																																																									  new System.Data.Common.DataColumnMapping("RctID", "RctID"),
																																																									  new System.Data.Common.DataColumnMapping("Changes", "Changes"),
																																																									  new System.Data.Common.DataColumnMapping("Operation", "Operation"),
																																																									  new System.Data.Common.DataColumnMapping("ChangedBy", "ChangedBy"),
																																																									  new System.Data.Common.DataColumnMapping("Changed", "Changed")})});
			this.daLfsJunctionLinerRct.UpdateCommand = this.cmdLfsJunctionLinerRctUpdate;

			//--- ... cmdLfsJunctionLinerRctSelect
			this.cmdLfsJunctionLinerRctSelect.CommandText = "SELECT ID, RefID, COMPANY_ID, RctID, Changes, Operation, ChangedBy, Changed FROM LFS_JUNCTION_LINER_RCT";
			this.cmdLfsJunctionLinerRctSelect.Connection = this.dcConnection;

			//--- ... cmdLfsJunctionLinerRctInsert
			this.cmdLfsJunctionLinerRctInsert.CommandText = @"INSERT INTO LFS_JUNCTION_LINER_RCT(ID, RefID, COMPANY_ID, Changes, Operation, ChangedBy, Changed) VALUES (@ID, @RefID, @COMPANY_ID, @Changes, @Operation, @ChangedBy, @Changed); SELECT ID, RefID, COMPANY_ID, RctID, Changes, Operation, ChangedBy, Changed FROM LFS_JUNCTION_LINER_RCT WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RctID = @@IDENTITY) AND (RefID = @RefID)";
			this.cmdLfsJunctionLinerRctInsert.Connection = this.dcConnection;
			this.cmdLfsJunctionLinerRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
			this.cmdLfsJunctionLinerRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 4, "RefID"));
			this.cmdLfsJunctionLinerRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 4, "COMPANY_ID"));
			this.cmdLfsJunctionLinerRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Changes", System.Data.SqlDbType.NVarChar, 1073741823, "Changes"));
			this.cmdLfsJunctionLinerRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Operation", System.Data.SqlDbType.NVarChar, 10, "Operation"));
			this.cmdLfsJunctionLinerRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ChangedBy", System.Data.SqlDbType.Int, 4, "ChangedBy"));
			this.cmdLfsJunctionLinerRctInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Changed", System.Data.SqlDbType.DateTime, 4, "Changed"));

			//--- ... cmdLfsJunctionLinerRctUpdate
			this.cmdLfsJunctionLinerRctUpdate.CommandText = @"UPDATE LFS_JUNCTION_LINER_RCT SET ID = @ID, RefID = @RefID, COMPANY_ID = @COMPANY_ID, Changes = @Changes, Operation = @Operation, ChangedBy = @ChangedBy, Changed = @Changed WHERE (COMPANY_ID = @Original_COMPANY_ID) AND (ID = @Original_ID) AND (RctID = @Original_RctID) AND (RefID = @Original_RefID) AND (Changed = @Original_Changed OR @Original_Changed IS NULL AND Changed IS NULL) AND (ChangedBy = @Original_ChangedBy OR @Original_ChangedBy IS NULL AND ChangedBy IS NULL) AND (Operation = @Original_Operation OR @Original_Operation IS NULL AND Operation IS NULL); SELECT ID, RefID, COMPANY_ID, RctID, Changes, Operation, ChangedBy, Changed FROM LFS_JUNCTION_LINER_RCT WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RctID = @RctID) AND (RefID = @RefID)";
			this.cmdLfsJunctionLinerRctUpdate.Connection = this.dcConnection;
			this.cmdLfsJunctionLinerRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 16, "ID"));
			this.cmdLfsJunctionLinerRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 4, "RefID"));
			this.cmdLfsJunctionLinerRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 4, "COMPANY_ID"));
			this.cmdLfsJunctionLinerRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Changes", System.Data.SqlDbType.NVarChar, 1073741823, "Changes"));
			this.cmdLfsJunctionLinerRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Operation", System.Data.SqlDbType.NVarChar, 10, "Operation"));
			this.cmdLfsJunctionLinerRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ChangedBy", System.Data.SqlDbType.Int, 4, "ChangedBy"));
			this.cmdLfsJunctionLinerRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Changed", System.Data.SqlDbType.DateTime, 4, "Changed"));
			this.cmdLfsJunctionLinerRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "COMPANY_ID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsJunctionLinerRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsJunctionLinerRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RctID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RctID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsJunctionLinerRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RefID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsJunctionLinerRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Changed", System.Data.SqlDbType.DateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Changed", System.Data.DataRowVersion.Original, null));
			this.cmdLfsJunctionLinerRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ChangedBy", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChangedBy", System.Data.DataRowVersion.Original, null));
			this.cmdLfsJunctionLinerRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Operation", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Operation", System.Data.DataRowVersion.Original, null));
			this.cmdLfsJunctionLinerRctUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RctID", System.Data.SqlDbType.Int, 4, "RctID"));

			//--- ... cmdLfsJunctionLinerRctDelete
			this.cmdLfsJunctionLinerRctDelete.CommandText = @"DELETE FROM LFS_JUNCTION_LINER_RCT WHERE (COMPANY_ID = @Original_COMPANY_ID) AND (ID = @Original_ID) AND (RctID = @Original_RctID) AND (RefID = @Original_RefID) AND (Changed = @Original_Changed OR @Original_Changed IS NULL AND Changed IS NULL) AND (ChangedBy = @Original_ChangedBy OR @Original_ChangedBy IS NULL AND ChangedBy IS NULL) AND (Operation = @Original_Operation OR @Original_Operation IS NULL AND Operation IS NULL)";
			this.cmdLfsJunctionLinerRctDelete.Connection = this.dcConnection;
			this.cmdLfsJunctionLinerRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "COMPANY_ID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsJunctionLinerRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsJunctionLinerRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RctID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RctID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsJunctionLinerRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RefID", System.Data.DataRowVersion.Original, null));
			this.cmdLfsJunctionLinerRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Changed", System.Data.SqlDbType.DateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Changed", System.Data.DataRowVersion.Original, null));
			this.cmdLfsJunctionLinerRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ChangedBy", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ChangedBy", System.Data.DataRowVersion.Original, null));
			this.cmdLfsJunctionLinerRctDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Operation", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Operation", System.Data.DataRowVersion.Original, null));
		}
		#endregion






		///////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// GetRecordByIdCompanyId
		//
		// Returns a typed dataset containing a record. The dataset contains 
		// one row for LFS_MASTER_AREA, zero or more rows for LFS_POINT_REPAIRS, 
		// zero or more rows for LFS_M2_TABLES, and zero or more rows for 
		// LFS_JUNCTION_LINER.
		//
		public TDSLFSRecord GetRecordByIdCompanyId(Guid id, int companyId)
		{
			TDSLFSRecord dataSet = new TDSLFSRecord();

			//--- Get LFS_MASTER_AREA row
			daLFSMasterArea.SelectCommand.CommandText = @"SELECT ID, COMPANY_ID, RecordID, ClientID, COMPANIES_ID, SubArea, Street, USMH, DSMH, Size_, ScaledLength, P1Date, ActualLength, LiveLats, CXIsRemoved, M1Date, M2Date, InstallDate, FinalVideo, Comments, IssueIdentified, IssueResolved, FullLengthLining, SubcontractorLining, OutOfScopeInArea, IssueGivenToBayCity, ConfirmedSize, InstallRate, DeadlineDate, ProposedLiningDate, SalesIssue, LFSIssue, ClientIssue, InvestigationIssue, PointLining, Grouting, LateralLining, VacExDate, PusherDate, LinerOrdered, Restoration, GroutDate, JLiner, RehabAssessment, EstimatedJoints, JointsTestSealed, PreFlushDate, PreVideoDate, USMHMN, DSMHMN, USMHDepth, DSMHDepth, MeasurementsTakenBy, SteelTapeThruPipe, USMHAtMouth1200, USMHAtMouth100, USMHAtMouth200, USMHAtMouth300, USMHAtMouth400, USMHAtMouth500, DSMHAtMouth1200, DSMHAtMouth100, DSMHAtMouth200, DSMHAtMouth300, DSMHAtMouth400, DSMHAtMouth500, HydrantAddress, DistanceToInversionMH, RampsRequired, DegreeOfTrafficControl, StandarBypass, HydroWireDetails, PipeMaterialType, CappedLaterals, RoboticPrepRequired, PipeSizeChange, M1Comments, VideoDoneFrom, ToManhole, CutterDescriptionDuringMeasuring, FullLengthPointLiner, BypassRequired, RoboticDistances, TrafficControlDetails, LineWithID, SchoolZone, RestaurantArea, CarwashLaundromat, HydroPulley, FridgeCart, TwoInchPump, SixInchBypass, Scaffolding, WinchExtension, ExtraGenerator, GreyCableExtension, EasementMats, MeasurementType, DropPipe, DropPipeInvertDepth, Deleted, MeasuredFromManhole, MainLined, BenchingIssue, Archived, ScaledLength1, History, NumLats, NotLinedYet, AllMeasured, City, ProvState FROM LFS_MASTER_AREA WHERE (ID = @id) AND (COMPANY_ID = @companyId)";
			daLFSMasterArea.SelectCommand.Parameters.Clear();
			daLFSMasterArea.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
			daLFSMasterArea.SelectCommand.Parameters.Add(new SqlParameter("@companyId", companyId));
			daLFSMasterArea.Fill(dataSet, "LFS_MASTER_AREA");

			//--- Get LFS_POINT_REPAIRS rows
			daLFSPointRepairs.SelectCommand.CommandText = @"SELECT LFS_POINT_REPAIRS.ID, LFS_POINT_REPAIRS.RefID, LFS_POINT_REPAIRS.COMPANY_ID, LFS_POINT_REPAIRS.DetailID, LFS_POINT_REPAIRS.RepairSize, LFS_POINT_REPAIRS.InstallDate, LFS_POINT_REPAIRS.Distance, LFS_POINT_REPAIRS.Cost, LFS_POINT_REPAIRS.Reinstates, LFS_POINT_REPAIRS.LTAtMH, LFS_POINT_REPAIRS.VTAtMH, LFS_POINT_REPAIRS.LinerDistance, LFS_POINT_REPAIRS.Direction, LFS_POINT_REPAIRS.MHShot, LFS_POINT_REPAIRS.Comments, LFS_POINT_REPAIRS.Deleted, LFS_POINT_REPAIRS.ExtraRepair, LFS_POINT_REPAIRS.Cancelled, LFS_POINT_REPAIRS.Approved, LFS_POINT_REPAIRS.NotApproved, LFS_POINT_REPAIRS.Archived FROM LFS_MASTER_AREA INNER JOIN LFS_POINT_REPAIRS ON (LFS_MASTER_AREA.ID = LFS_POINT_REPAIRS.ID) AND (LFS_MASTER_AREA.COMPANY_ID = LFS_POINT_REPAIRS.COMPANY_ID) WHERE (LFS_MASTER_AREA.ID = @id) AND (LFS_MASTER_AREA.COMPANY_ID = @companyId)";
			daLFSPointRepairs.SelectCommand.Parameters.Clear();
			daLFSPointRepairs.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
			daLFSPointRepairs.SelectCommand.Parameters.Add(new SqlParameter("@companyId", companyId));
			daLFSPointRepairs.Fill(dataSet, "LFS_POINT_REPAIRS");

			//--- Get LFS_M2_TABLES rows
			daLFSM2Tables.SelectCommand.CommandText = @"SELECT LFS_M2_TABLES.ID, LFS_M2_TABLES.RefID, LFS_M2_TABLES.COMPANY_ID, LFS_M2_TABLES.VideoDistance, LFS_M2_TABLES.ClockPosition, LFS_M2_TABLES.LiveOrAbandoned, LFS_M2_TABLES.DistanceToCentreOfLateral, LFS_M2_TABLES.LateralDiameter, LFS_M2_TABLES.LateralType, LFS_M2_TABLES.DateTimeOpened, LFS_M2_TABLES.Comments, LFS_M2_TABLES.ReverseSetup, LFS_M2_TABLES.Deleted, LFS_M2_TABLES.Archived FROM LFS_MASTER_AREA INNER JOIN LFS_M2_TABLES ON (LFS_MASTER_AREA.ID = LFS_M2_TABLES.ID) AND (LFS_MASTER_AREA.COMPANY_ID = LFS_M2_TABLES.COMPANY_ID) WHERE (LFS_MASTER_AREA.ID = @id) AND (LFS_MASTER_AREA.COMPANY_ID = @companyId)";
			daLFSM2Tables.SelectCommand.Parameters.Clear();
			daLFSM2Tables.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
			daLFSM2Tables.SelectCommand.Parameters.Add(new SqlParameter("@companyId", companyId));
			daLFSM2Tables.Fill(dataSet, "LFS_M2_TABLES");

			//--- Get LFS_JUNCTION_LINER rows
			daLFSJunctionLiner.SelectCommand.CommandText = @"SELECT LFS_JUNCTION_LINER.ID, LFS_JUNCTION_LINER.RefID, LFS_JUNCTION_LINER.COMPANY_ID, LFS_JUNCTION_LINER.DetailID, LFS_JUNCTION_LINER.MN, LFS_JUNCTION_LINER.DistanceFromUSMH, LFS_JUNCTION_LINER.ConfirmedLatSize, LFS_JUNCTION_LINER.LateralMaterial, LFS_JUNCTION_LINER.SharedLateral, LFS_JUNCTION_LINER.CleanoutRequired, LFS_JUNCTION_LINER.PitRequired, LFS_JUNCTION_LINER.MHShot, LFS_JUNCTION_LINER.MainConnection, LFS_JUNCTION_LINER.Transition, LFS_JUNCTION_LINER.CleanoutInstalled, LFS_JUNCTION_LINER.PitInstalled, LFS_JUNCTION_LINER.CleanoutGrouted, LFS_JUNCTION_LINER.CleanoutCored, LFS_JUNCTION_LINER.PrepCompleted, LFS_JUNCTION_LINER.MeasuredLatLength, LFS_JUNCTION_LINER.MeasurementsTakenBy, LFS_JUNCTION_LINER.LinerInstalled, LFS_JUNCTION_LINER.FinalVideo, LFS_JUNCTION_LINER.RestorationComplete, LFS_JUNCTION_LINER.LinerOrdered, LFS_JUNCTION_LINER.LinerInStock, LFS_JUNCTION_LINER.LinerPrice, LFS_JUNCTION_LINER.Comments, LFS_JUNCTION_LINER.Deleted, LFS_JUNCTION_LINER.Archived FROM LFS_MASTER_AREA INNER JOIN LFS_JUNCTION_LINER ON (LFS_MASTER_AREA.ID = LFS_JUNCTION_LINER.ID) AND (LFS_MASTER_AREA.COMPANY_ID = LFS_JUNCTION_LINER.COMPANY_ID) WHERE (LFS_MASTER_AREA.ID = @id) AND (LFS_MASTER_AREA.COMPANY_ID = @companyId)";
			daLFSJunctionLiner.SelectCommand.Parameters.Clear();
			daLFSJunctionLiner.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
			daLFSJunctionLiner.SelectCommand.Parameters.Add(new SqlParameter("@companyId", companyId));
			daLFSJunctionLiner.Fill(dataSet, "LFS_JUNCTION_LINER");

            //--- Get LFS_JUNCTION_LINER2 rows
            daLFSJunctionLiner2.SelectCommand.CommandText = @"SELECT LFS_JUNCTION_LINER2.ID, LFS_JUNCTION_LINER2.RefID, LFS_JUNCTION_LINER2.COMPANY_ID, LFS_JUNCTION_LINER2.DetailID, LFS_JUNCTION_LINER2.Address, LFS_JUNCTION_LINER2.DistanceFromUSMH, LFS_JUNCTION_LINER2.DistanceFromDSMH, LFS_JUNCTION_LINER2.PipeLocated, LFS_JUNCTION_LINER2.ServicesLocated, LFS_JUNCTION_LINER2.CoInstalled, LFS_JUNCTION_LINER2.BackfilledConcrete, LFS_JUNCTION_LINER2.BackfilledSoil, LFS_JUNCTION_LINER2.Grouted, LFS_JUNCTION_LINER2.Cored, LFS_JUNCTION_LINER2.Prepped, LFS_JUNCTION_LINER2.Measured, LFS_JUNCTION_LINER2.LinerSize, LFS_JUNCTION_LINER2.PreVideo, LFS_JUNCTION_LINER2.FinalVideo, LFS_JUNCTION_LINER2.LinerInstalled, LFS_JUNCTION_LINER2.Map, LFS_JUNCTION_LINER2.Deleted FROM LFS_MASTER_AREA INNER JOIN LFS_JUNCTION_LINER2 ON (LFS_MASTER_AREA.ID = LFS_JUNCTION_LINER2.ID) AND (LFS_MASTER_AREA.COMPANY_ID = LFS_JUNCTION_LINER2.COMPANY_ID) WHERE (LFS_MASTER_AREA.ID = @id) AND (LFS_MASTER_AREA.COMPANY_ID = @companyId) AND (LFS_JUNCTION_LINER2.Deleted = 0)";
            daLFSJunctionLiner2.SelectCommand.Parameters.Clear();
            daLFSJunctionLiner2.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
            daLFSJunctionLiner2.SelectCommand.Parameters.Add(new SqlParameter("@companyId", companyId));
            daLFSJunctionLiner2.Fill(dataSet, "LFS_JUNCTION_LINER2");

			//--- Return TDSLFSRecord
			return dataSet;
		}



		//
		// GetRecordAndRCTByIdCompanyId
		//
		// Returns a typed dataset containing a record. The dataset contains 
		// one row for LFS_MASTER_AREA, zero or more rows for LFS_POINT_REPAIRS, 
		// zero or more rows for LFS_M2_TABLES, and zero or more tables for
		// LFS_JUNCTION_LINER. It also returns LFS_MASTER_AREA_RCT,
		// LFS_POINT_REPAIRS_RCT, LFS_M2_TABLES_RCT, and LFS_JUNCTION_LINER.
		//
		public TDSLFSRecord GetRecordAndRCTByIdCompanyId(Guid id, int companyId)
		{
			TDSLFSRecord dataSet = new TDSLFSRecord();

			//--- Get LFS_MASTER_AREA row
			daLFSMasterArea.SelectCommand.CommandText = @"SELECT ID, COMPANY_ID, RecordID, ClientID, COMPANIES_ID, SubArea, Street, USMH, DSMH, Size_, ScaledLength, P1Date, ActualLength, LiveLats, CXIsRemoved, M1Date, M2Date, InstallDate, FinalVideo, Comments, IssueIdentified, IssueResolved, FullLengthLining, SubcontractorLining, OutOfScopeInArea, IssueGivenToBayCity, ConfirmedSize, InstallRate, DeadlineDate, ProposedLiningDate, SalesIssue, LFSIssue, ClientIssue, InvestigationIssue, PointLining, Grouting, LateralLining, VacExDate, PusherDate, LinerOrdered, Restoration, GroutDate, JLiner, RehabAssessment, EstimatedJoints, JointsTestSealed, PreFlushDate, PreVideoDate, USMHMN, DSMHMN, USMHDepth, DSMHDepth, MeasurementsTakenBy, SteelTapeThruPipe, USMHAtMouth1200, USMHAtMouth100, USMHAtMouth200, USMHAtMouth300, USMHAtMouth400, USMHAtMouth500, DSMHAtMouth1200, DSMHAtMouth100, DSMHAtMouth200, DSMHAtMouth300, DSMHAtMouth400, DSMHAtMouth500, HydrantAddress, DistanceToInversionMH, RampsRequired, DegreeOfTrafficControl, StandarBypass, HydroWireDetails, PipeMaterialType, CappedLaterals, RoboticPrepRequired, PipeSizeChange, M1Comments, VideoDoneFrom, ToManhole, CutterDescriptionDuringMeasuring, FullLengthPointLiner, BypassRequired, RoboticDistances, TrafficControlDetails, LineWithID, SchoolZone, RestaurantArea, CarwashLaundromat, HydroPulley, FridgeCart, TwoInchPump, SixInchBypass, Scaffolding, WinchExtension, ExtraGenerator, GreyCableExtension, EasementMats, MeasurementType, DropPipe, DropPipeInvertDepth, Deleted, MeasuredFromManhole, MainLined, BenchingIssue, Archived, ScaledLength1, History, NumLats, NotLinedYet, AllMeasured, City, ProvState FROM LFS_MASTER_AREA WHERE (ID = @id) AND (COMPANY_ID = @companyId)";
			daLFSMasterArea.SelectCommand.Parameters.Clear();
			daLFSMasterArea.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
			daLFSMasterArea.SelectCommand.Parameters.Add(new SqlParameter("@companyId", companyId));
			daLFSMasterArea.Fill(dataSet, "LFS_MASTER_AREA");

			//--- Get LFS_POINT_REPAIRS rows
			daLFSPointRepairs.SelectCommand.CommandText = @"SELECT LFS_POINT_REPAIRS.ID, LFS_POINT_REPAIRS.RefID, LFS_POINT_REPAIRS.COMPANY_ID, LFS_POINT_REPAIRS.DetailID, LFS_POINT_REPAIRS.RepairSize, LFS_POINT_REPAIRS.InstallDate, LFS_POINT_REPAIRS.Distance, LFS_POINT_REPAIRS.Cost, LFS_POINT_REPAIRS.Reinstates, LFS_POINT_REPAIRS.LTAtMH, LFS_POINT_REPAIRS.VTAtMH, LFS_POINT_REPAIRS.LinerDistance, LFS_POINT_REPAIRS.Direction, LFS_POINT_REPAIRS.MHShot, LFS_POINT_REPAIRS.Comments, LFS_POINT_REPAIRS.Deleted, LFS_POINT_REPAIRS.ExtraRepair, LFS_POINT_REPAIRS.Cancelled, LFS_POINT_REPAIRS.Approved, LFS_POINT_REPAIRS.NotApproved, LFS_POINT_REPAIRS.Archived FROM LFS_MASTER_AREA INNER JOIN LFS_POINT_REPAIRS ON (LFS_MASTER_AREA.ID = LFS_POINT_REPAIRS.ID) AND (LFS_MASTER_AREA.COMPANY_ID = LFS_POINT_REPAIRS.COMPANY_ID) WHERE (LFS_MASTER_AREA.ID = @id) AND (LFS_MASTER_AREA.COMPANY_ID = @companyId)";
			daLFSPointRepairs.SelectCommand.Parameters.Clear();
			daLFSPointRepairs.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
			daLFSPointRepairs.SelectCommand.Parameters.Add(new SqlParameter("@companyId", companyId));
			daLFSPointRepairs.Fill(dataSet, "LFS_POINT_REPAIRS");

			//--- Get LFS_M2_TABLES rows
			daLFSM2Tables.SelectCommand.CommandText = @"SELECT LFS_M2_TABLES.ID, LFS_M2_TABLES.RefID, LFS_M2_TABLES.COMPANY_ID, LFS_M2_TABLES.VideoDistance, LFS_M2_TABLES.ClockPosition, LFS_M2_TABLES.LiveOrAbandoned, LFS_M2_TABLES.DistanceToCentreOfLateral, LFS_M2_TABLES.LateralDiameter, LFS_M2_TABLES.LateralType, LFS_M2_TABLES.DateTimeOpened, LFS_M2_TABLES.Comments, LFS_M2_TABLES.ReverseSetup, LFS_M2_TABLES.Deleted, LFS_M2_TABLES.Archived FROM LFS_MASTER_AREA INNER JOIN LFS_M2_TABLES ON (LFS_MASTER_AREA.ID = LFS_M2_TABLES.ID) AND (LFS_MASTER_AREA.COMPANY_ID = LFS_M2_TABLES.COMPANY_ID) WHERE (LFS_MASTER_AREA.ID = @id) AND (LFS_MASTER_AREA.COMPANY_ID = @companyId)";
			daLFSM2Tables.SelectCommand.Parameters.Clear();
			daLFSM2Tables.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
			daLFSM2Tables.SelectCommand.Parameters.Add(new SqlParameter("@companyId", companyId));
			daLFSM2Tables.Fill(dataSet, "LFS_M2_TABLES");

			//--- Get LFS_JUNCTION_LINER rows
			daLFSJunctionLiner.SelectCommand.CommandText = @"SELECT LFS_JUNCTION_LINER.ID, LFS_JUNCTION_LINER.RefID, LFS_JUNCTION_LINER.COMPANY_ID, LFS_JUNCTION_LINER.DetailID, LFS_JUNCTION_LINER.MN, LFS_JUNCTION_LINER.DistanceFromUSMH, LFS_JUNCTION_LINER.ConfirmedLatSize, LFS_JUNCTION_LINER.LateralMaterial, LFS_JUNCTION_LINER.SharedLateral, LFS_JUNCTION_LINER.CleanoutRequired, LFS_JUNCTION_LINER.PitRequired, LFS_JUNCTION_LINER.MHShot, LFS_JUNCTION_LINER.MainConnection, LFS_JUNCTION_LINER.Transition, LFS_JUNCTION_LINER.CleanoutInstalled, LFS_JUNCTION_LINER.PitInstalled, LFS_JUNCTION_LINER.CleanoutGrouted, LFS_JUNCTION_LINER.CleanoutCored, LFS_JUNCTION_LINER.PrepCompleted, LFS_JUNCTION_LINER.MeasuredLatLength, LFS_JUNCTION_LINER.MeasurementsTakenBy, LFS_JUNCTION_LINER.LinerInstalled, LFS_JUNCTION_LINER.FinalVideo, LFS_JUNCTION_LINER.RestorationComplete, LFS_JUNCTION_LINER.LinerOrdered, LFS_JUNCTION_LINER.LinerInStock, LFS_JUNCTION_LINER.LinerPrice, LFS_JUNCTION_LINER.Comments, LFS_JUNCTION_LINER.Deleted, LFS_JUNCTION_LINER.Archived FROM LFS_MASTER_AREA INNER JOIN LFS_JUNCTION_LINER ON (LFS_MASTER_AREA.ID = LFS_JUNCTION_LINER.ID) AND (LFS_MASTER_AREA.COMPANY_ID = LFS_JUNCTION_LINER.COMPANY_ID) WHERE (LFS_MASTER_AREA.ID = @id) AND (LFS_MASTER_AREA.COMPANY_ID = @companyId)";
			daLFSJunctionLiner.SelectCommand.Parameters.Clear();
			daLFSJunctionLiner.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
			daLFSJunctionLiner.SelectCommand.Parameters.Add(new SqlParameter("@companyId", companyId));
			daLFSJunctionLiner.Fill(dataSet, "LFS_JUNCTION_LINER");

			//--- Get LFS_MASTER_AREA_RCT rows
			daLfsMasterAreaRct.SelectCommand.CommandText = @"SELECT LFS_MASTER_AREA_RCT.ID, LFS_MASTER_AREA_RCT.COMPANY_ID, LFS_MASTER_AREA_RCT.RctID, LFS_MASTER_AREA_RCT.Changes, LFS_MASTER_AREA_RCT.Operation, LFS_MASTER_AREA_RCT.ChangedBy, LFS_MASTER_AREA_RCT.Changed FROM LFS_MASTER_AREA INNER JOIN LFS_MASTER_AREA_RCT ON (LFS_MASTER_AREA.ID = LFS_MASTER_AREA_RCT.ID) AND (LFS_MASTER_AREA.COMPANY_ID = LFS_MASTER_AREA_RCT.COMPANY_ID) WHERE (LFS_MASTER_AREA.ID = @id) AND (LFS_MASTER_AREA.COMPANY_ID = @companyId)";
			daLfsMasterAreaRct.SelectCommand.Parameters.Clear();
			daLfsMasterAreaRct.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
			daLfsMasterAreaRct.SelectCommand.Parameters.Add(new SqlParameter("@companyId", companyId));
			daLfsMasterAreaRct.Fill(dataSet, "LFS_MASTER_AREA_RCT");

			//--- Get LFS_POINT_REPAIRS_RCT rows
			daLfsPointRepairsRct.SelectCommand.CommandText = @"SELECT LFS_POINT_REPAIRS_RCT.ID, LFS_POINT_REPAIRS_RCT.RefID, LFS_POINT_REPAIRS_RCT.COMPANY_ID, LFS_POINT_REPAIRS_RCT.RctID, LFS_POINT_REPAIRS_RCT.Changes, LFS_POINT_REPAIRS_RCT.Operation, LFS_POINT_REPAIRS_RCT.ChangedBy, LFS_POINT_REPAIRS_RCT.Changed FROM LFS_MASTER_AREA INNER JOIN LFS_POINT_REPAIRS_RCT ON (LFS_MASTER_AREA.ID = LFS_POINT_REPAIRS_RCT.ID) AND (LFS_MASTER_AREA.COMPANY_ID = LFS_POINT_REPAIRS_RCT.COMPANY_ID) WHERE (LFS_MASTER_AREA.ID = @id) AND (LFS_MASTER_AREA.COMPANY_ID = @companyId)";
			daLfsPointRepairsRct.SelectCommand.Parameters.Clear();
			daLfsPointRepairsRct.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
			daLfsPointRepairsRct.SelectCommand.Parameters.Add(new SqlParameter("@companyId", companyId));
			daLfsPointRepairsRct.Fill(dataSet, "LFS_POINT_REPAIRS_RCT");

			//--- Get LFS_M2_TABLES_RCT rows
			daLfsM2TablesRct.SelectCommand.CommandText = @"SELECT LFS_M2_TABLES_RCT.ID, LFS_M2_TABLES_RCT.RefID, LFS_M2_TABLES_RCT.COMPANY_ID, LFS_M2_TABLES_RCT.RctID, LFS_M2_TABLES_RCT.Changes, LFS_M2_TABLES_RCT.Operation, LFS_M2_TABLES_RCT.ChangedBy, LFS_M2_TABLES_RCT.Changed FROM LFS_MASTER_AREA INNER JOIN LFS_M2_TABLES_RCT ON (LFS_MASTER_AREA.ID = LFS_M2_TABLES_RCT.ID) AND (LFS_MASTER_AREA.COMPANY_ID = LFS_M2_TABLES_RCT.COMPANY_ID) WHERE (LFS_MASTER_AREA.ID = @id) AND (LFS_MASTER_AREA.COMPANY_ID = @companyId)";
			daLfsM2TablesRct.SelectCommand.Parameters.Clear();
			daLfsM2TablesRct.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
			daLfsM2TablesRct.SelectCommand.Parameters.Add(new SqlParameter("@companyId", companyId));
			daLfsM2TablesRct.Fill(dataSet, "LFS_M2_TABLES_RCT");

			//--- Get LFS_JUNCTION_LINER_RCT rows
			daLfsJunctionLinerRct.SelectCommand.CommandText = @"SELECT LFS_JUNCTION_LINER_RCT.ID, LFS_JUNCTION_LINER_RCT.RefID, LFS_JUNCTION_LINER_RCT.COMPANY_ID, LFS_JUNCTION_LINER_RCT.RctID, LFS_JUNCTION_LINER_RCT.Changes, LFS_JUNCTION_LINER_RCT.Operation, LFS_JUNCTION_LINER_RCT.ChangedBy, LFS_JUNCTION_LINER_RCT.Changed FROM LFS_MASTER_AREA INNER JOIN LFS_JUNCTION_LINER_RCT ON (LFS_MASTER_AREA.ID = LFS_JUNCTION_LINER_RCT.ID) AND (LFS_MASTER_AREA.COMPANY_ID = LFS_JUNCTION_LINER_RCT.COMPANY_ID) WHERE (LFS_MASTER_AREA.ID = @id) AND (LFS_MASTER_AREA.COMPANY_ID = @companyId)";
			daLfsJunctionLinerRct.SelectCommand.Parameters.Clear();
			daLfsJunctionLinerRct.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
			daLfsJunctionLinerRct.SelectCommand.Parameters.Add(new SqlParameter("@companyId", companyId));
			daLfsJunctionLinerRct.Fill(dataSet, "LFS_JUNCTION_LINER_RCT");

			//--- Return TDSLFSRecord
			return dataSet;
		}



		//
		// GetRecordRCTAndExpandedRecordsByIdCompanyId
		//
		// Returns a typed dataset containing a record. The dataset contains 
		// one row for LFS_MASTER_AREA, zero or more rows for LFS_POINT_REPAIRS, 
		// zero or more rows for LFS_M2_TABLES, and zero or more tables for
		// LFS_JUNCTION_LINER. It also returns LFS_MASTER_AREA_RCT,
		// LFS_POINT_REPAIRS_RCT, LFS_M2_TABLES_RCT, and LFS_JUNCTION_LINER_RCT. 
		// Besides it expands LFS_MASTER_AREA_RCT, LFS_POINT_REPAIRS_RCT, 
		// LFS_M2_TABLES_RCT, and LFS_JUNCTION_LINER.
		//
		// This method is intended to be used in the Record Change Tracking tool.
		//
		public TDSLFSRecordForRCT GetRecordRCTAndExpandedRecordsByIdCompanyId(string id, int companyId)
		{
			TDSLFSRecordForRCT result = new TDSLFSRecordForRCT();
			TDSLFSRecordForRCT auxiliar = new TDSLFSRecordForRCT();

			LoginGateway loginGateway = new LoginGateway();
			CompaniesGateway companiesGateway = new CompaniesGateway();
			
			//--- Get lfs record and rct records
			TDSLFSRecord tdsLfsRecord = this.GetRecordAndRCTByIdCompanyId(new Guid(id), companyId);
			result.Merge(tdsLfsRecord, true, System.Data.MissingSchemaAction.Ignore);

			//--- Prepare master area 2
			TDSLFSRecord.LFS_MASTER_AREARow lfsMasterAreaRow = tdsLfsRecord.LFS_MASTER_AREA.FindByIDCOMPANY_ID(new Guid(id), companyId);
			TDSLFSRecordForRCT.LFS_MASTER_AREA2Row lfsMasterArea2Row = result.LFS_MASTER_AREA2.NewLFS_MASTER_AREA2Row();
			
			for (int i = 0; i < tdsLfsRecord.LFS_MASTER_AREA.Columns.Count; i++)
			{
				lfsMasterArea2Row[i] = lfsMasterAreaRow[i];
			}
			lfsMasterArea2Row.NAME = companiesGateway.GetName(lfsMasterAreaRow.COMPANIES_ID, companyId);

			result.LFS_MASTER_AREA2.AddLFS_MASTER_AREA2Row(lfsMasterArea2Row);

			//--- Expand master area rct
			TDSLFSRecordForRCT.LFS_MASTER_AREA_RCT_EXPANDEDRow prevLfsMasterAreaRctExpandedRow = null;

			foreach(TDSLFSRecord.LFS_MASTER_AREA_RCTRow lfsMasterAreaRctRow in tdsLfsRecord.LFS_MASTER_AREA_RCT)
			{
				//--- ... Create current record
				TDSLFSRecordForRCT.LFS_MASTER_AREA_RCT_EXPANDEDRow lfsMasterAreaRctExpandedRow = result.LFS_MASTER_AREA_RCT_EXPANDED.NewLFS_MASTER_AREA_RCT_EXPANDEDRow();

				//--- ... Copy data from previous record to current record (if previous record exists)
				if (prevLfsMasterAreaRctExpandedRow != null)
				{
					for (int i = 0; i < result.LFS_MASTER_AREA_RCT_EXPANDED.Columns.Count; i++)
					{
						if (result.LFS_MASTER_AREA_RCT_EXPANDED.Columns[i].ColumnName != "RctID")
						{
							lfsMasterAreaRctExpandedRow[i] = prevLfsMasterAreaRctExpandedRow[i];
						}
					}
				}

				//--- ... Expand current record
				lfsMasterAreaRctExpandedRow.ID = lfsMasterAreaRctRow.ID;
				lfsMasterAreaRctExpandedRow.COMPANY_ID = lfsMasterAreaRctRow.COMPANY_ID;

				#region Expand changes
				
				foreach (string columnValueItem in RecordChangeTracking.Split(lfsMasterAreaRctRow.Changes))
				{
					switch (RecordChangeTracking.GetColumnName(columnValueItem))
					{
						case "ID":
							break;							
						case "COMPANY_ID":
							break;							
						case "RecordID":
							lfsMasterAreaRctExpandedRow.RecordID = RecordChangeTracking.GetValue(columnValueItem);
							break;							
						case "ClientID":
							lfsMasterAreaRctExpandedRow.ClientID = RecordChangeTracking.GetValue(columnValueItem);
							break;							
						case "COMPANIES_ID":
							lfsMasterAreaRctExpandedRow.COMPANIES_ID = Convert.ToInt32(RecordChangeTracking.GetValue(columnValueItem));
							lfsMasterAreaRctExpandedRow.NAME = companiesGateway.GetName(lfsMasterAreaRctExpandedRow.COMPANIES_ID, companyId);
							break;							
						case "SubArea":
							lfsMasterAreaRctExpandedRow.SubArea = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "Street":
							lfsMasterAreaRctExpandedRow.Street = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "USMH":
							lfsMasterAreaRctExpandedRow.USMH = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "DSMH":
							lfsMasterAreaRctExpandedRow.DSMH = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "Size_":
							lfsMasterAreaRctExpandedRow.Size_ = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "ScaledLength":
							lfsMasterAreaRctExpandedRow.ScaledLength = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "P1Date":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.P1Date = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetP1DateNull();
							break;
						case "ActualLength":
							lfsMasterAreaRctExpandedRow.ActualLength = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "LiveLats":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.LiveLats = Convert.ToDouble(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetLiveLatsNull();
							break;
						case "CXIsRemoved":
							lfsMasterAreaRctExpandedRow.CXIsRemoved = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "M1Date":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.M1Date = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetM1DateNull();
							break;
						case "M2Date":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.M2Date = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetM2DateNull();
							break;
						case "InstallDate":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.InstallDate = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetInstallDateNull();
							break;
						case "FinalVideo":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.FinalVideo = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetFinalVideoNull();
							break;
						case "Comments":
							lfsMasterAreaRctExpandedRow.Comments = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "IssueIdentified":
							lfsMasterAreaRctExpandedRow.IssueIdentified = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "IssueResolved":
							lfsMasterAreaRctExpandedRow.IssueResolved = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "FullLengthLining":
							lfsMasterAreaRctExpandedRow.FullLengthLining = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "SubcontractorLining":
							lfsMasterAreaRctExpandedRow.SubcontractorLining = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "OutOfScopeInArea":
							lfsMasterAreaRctExpandedRow.OutOfScopeInArea = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "IssueGivenToBayCity":
							lfsMasterAreaRctExpandedRow.IssueGivenToBayCity = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "ConfirmedSize":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.ConfirmedSize = Convert.ToInt32(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetConfirmedSizeNull();
							break;
						case "InstallRate":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.InstallRate = Convert.ToDecimal(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetInstallRateNull();
							break;
						case "DeadlineDate":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.DeadlineDate = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetDeadlineDateNull();
							break;
						case "ProposedLiningDate":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.ProposedLiningDate = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetProposedLiningDateNull();
							break;
						case "SalesIssue":
							lfsMasterAreaRctExpandedRow.SalesIssue = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "LFSIssue":
							lfsMasterAreaRctExpandedRow.LFSIssue = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "ClientIssue":
							lfsMasterAreaRctExpandedRow.ClientIssue = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "InvestigationIssue":
							lfsMasterAreaRctExpandedRow.InvestigationIssue = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "PointLining":
							lfsMasterAreaRctExpandedRow.PointLining = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "Grouting":
							lfsMasterAreaRctExpandedRow.Grouting = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "LateralLining":
							lfsMasterAreaRctExpandedRow.LateralLining = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "VacExDate":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.VacExDate = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetVacExDateNull();
							break;
						case "PusherDate":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.PusherDate = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetPusherDateNull();
							break;
						case "LinerOrdered":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.LinerOrdered = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetLinerOrderedNull();
							break;
						case "Restoration":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.Restoration = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetRestorationNull();
							break;
						case "GroutDate":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.GroutDate = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetGroutDateNull();
							break;
						case "JLiner":
							lfsMasterAreaRctExpandedRow.JLiner = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "RehabAssessment":
							lfsMasterAreaRctExpandedRow.RehabAssessment = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "EstimatedJoints":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.EstimatedJoints = Convert.ToInt32(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetEstimatedJointsNull();
							break;
						case "JointsTestSealed":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.JointsTestSealed = Convert.ToInt32(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetJointsTestSealedNull();
							break;
						case "PreFlushDate":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.PreFlushDate = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetPreFlushDateNull();
							break;
						case "PreVideoDate":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.PreVideoDate = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetPreVideoDateNull();
							break;
						case "USMHMN":
							lfsMasterAreaRctExpandedRow.USMHMN = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "DSMHMN":
							lfsMasterAreaRctExpandedRow.DSMHMN = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "USMHDepth":
							lfsMasterAreaRctExpandedRow.USMHDepth = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "DSMHDepth":
							lfsMasterAreaRctExpandedRow.DSMHDepth = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "MeasurementsTakenBy":
							lfsMasterAreaRctExpandedRow.MeasurementsTakenBy = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "SteelTapeThruPipe":
							lfsMasterAreaRctExpandedRow.SteelTapeThruPipe = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "USMHAtMouth1200":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.USMHAtMouth1200 = Convert.ToDouble(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetUSMHAtMouth1200Null();
							break;
						case "USMHAtMouth100":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.USMHAtMouth100 = Convert.ToDouble(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetUSMHAtMouth100Null();
							break;
						case "USMHAtMouth200":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.USMHAtMouth200 = Convert.ToDouble(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetUSMHAtMouth200Null();
							break;
						case "USMHAtMouth300":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.USMHAtMouth300 = Convert.ToDouble(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetUSMHAtMouth300Null();
							break;
						case "USMHAtMouth400":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.USMHAtMouth400 = Convert.ToDouble(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetUSMHAtMouth400Null();
							break;
						case "USMHAtMouth500":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.USMHAtMouth500 = Convert.ToDouble(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetUSMHAtMouth500Null();
							break;
						case "DSMHAtMouth1200":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.DSMHAtMouth1200 = Convert.ToDouble(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetDSMHAtMouth1200Null();
							break;
						case "DSMHAtMouth100":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.DSMHAtMouth100 = Convert.ToDouble(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetDSMHAtMouth100Null();
							break;
						case "DSMHAtMouth200":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.DSMHAtMouth200 = Convert.ToDouble(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetDSMHAtMouth200Null();
							break;
						case "DSMHAtMouth300":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.DSMHAtMouth300 = Convert.ToDouble(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetDSMHAtMouth300Null();
							break;
						case "DSMHAtMouth400":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.DSMHAtMouth400 = Convert.ToDouble(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetDSMHAtMouth400Null();
							break;
						case "DSMHAtMouth500":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.DSMHAtMouth500 = Convert.ToDouble(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetDSMHAtMouth500Null();
							break;
						case "HydrantAddress":
							lfsMasterAreaRctExpandedRow.HydrantAddress = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "DistanceToInversionMH":
							lfsMasterAreaRctExpandedRow.DistanceToInversionMH = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "RampsRequired":
							lfsMasterAreaRctExpandedRow.RampsRequired = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "DegreeOfTrafficControl":
							lfsMasterAreaRctExpandedRow.DegreeOfTrafficControl = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "StandarBypass":
							lfsMasterAreaRctExpandedRow.StandarBypass = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "HydroWireDetails":
							lfsMasterAreaRctExpandedRow.HydroWireDetails = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "PipeMaterialType":
							lfsMasterAreaRctExpandedRow.PipeMaterialType = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "CappedLaterals":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.CappedLaterals = Convert.ToInt32(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetCappedLateralsNull();
							break;
						case "RoboticPrepRequired":
							lfsMasterAreaRctExpandedRow.RoboticPrepRequired = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "PipeSizeChange":
							lfsMasterAreaRctExpandedRow.PipeSizeChange = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "M1Comments":
							lfsMasterAreaRctExpandedRow.M1Comments = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "VideoDoneFrom":
							lfsMasterAreaRctExpandedRow.VideoDoneFrom = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "ToManhole":
							lfsMasterAreaRctExpandedRow.ToManhole = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "CutterDescriptionDuringMeasuring":
							lfsMasterAreaRctExpandedRow.CutterDescriptionDuringMeasuring = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "FullLengthPointLiner":
							lfsMasterAreaRctExpandedRow.FullLengthPointLiner = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "BypassRequired":
							lfsMasterAreaRctExpandedRow.BypassRequired = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "RoboticDistances":
							lfsMasterAreaRctExpandedRow.RoboticDistances = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "TrafficControlDetails":
							lfsMasterAreaRctExpandedRow.TrafficControlDetails = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "LineWithID":
							lfsMasterAreaRctExpandedRow.LineWithID = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "SchoolZone":
							lfsMasterAreaRctExpandedRow.SchoolZone = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "RestaurantArea":
							lfsMasterAreaRctExpandedRow.RestaurantArea = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "CarwashLaundromat":
							lfsMasterAreaRctExpandedRow.CarwashLaundromat = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "HydroPulley":
							lfsMasterAreaRctExpandedRow.HydroPulley = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "FridgeCart":
							lfsMasterAreaRctExpandedRow.FridgeCart = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "TwoInchPump":
							lfsMasterAreaRctExpandedRow.TwoInchPump = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "SixInchBypass":
							lfsMasterAreaRctExpandedRow.SixInchBypass = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "Scaffolding":
							lfsMasterAreaRctExpandedRow.Scaffolding = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "WinchExtension":
							lfsMasterAreaRctExpandedRow.WinchExtension = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "ExtraGenerator":
							lfsMasterAreaRctExpandedRow.ExtraGenerator = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "GreyCableExtension":
							lfsMasterAreaRctExpandedRow.GreyCableExtension = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "EasementMats":
							lfsMasterAreaRctExpandedRow.EasementMats = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "MeasurementType":
							lfsMasterAreaRctExpandedRow.MeasurementType = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "DropPipe":
							lfsMasterAreaRctExpandedRow.DropPipe = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "DropPipeInvertDepth":
							lfsMasterAreaRctExpandedRow.DropPipeInvertDepth = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "Deleted":
							lfsMasterAreaRctExpandedRow.Deleted = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;	
						case "MeasuredFromManhole":
							lfsMasterAreaRctExpandedRow.MeasuredFromManhole = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "MainLined":
							lfsMasterAreaRctExpandedRow.MainLined = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "BenchingIssue":
							lfsMasterAreaRctExpandedRow.BenchingIssue = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "Archived":
							lfsMasterAreaRctExpandedRow.Archived = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;	
						case "ScaledLength1":
							break;
                        case "History":
                            lfsMasterAreaRctExpandedRow.History = RecordChangeTracking.GetValue(columnValueItem);
                            break;
                        case "NumLats":
                            if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.NumLats = Convert.ToInt32(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetNumLatsNull();
                            break;
                        case "NotLinedYet":
                            if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsMasterAreaRctExpandedRow.NotLinedYet = Convert.ToInt32(RecordChangeTracking.GetValue(columnValueItem)); else lfsMasterAreaRctExpandedRow.SetNotLinedYetNull();
                            break;
                        case "AllMeasured":
                            lfsMasterAreaRctExpandedRow.AllMeasured = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
                            break;
                        case "City":
                            lfsMasterAreaRctExpandedRow.City = RecordChangeTracking.GetValue(columnValueItem);
                            break;
                        case "ProvState":
                            lfsMasterAreaRctExpandedRow.ProvState = RecordChangeTracking.GetValue(columnValueItem);
                            break;
                        default:
							throw new Exception ("Invalid column in LFS_MASTER_AREA_RCT_EXPANDED.");
					}							
				}
						
				#endregion

				lfsMasterAreaRctExpandedRow.Operation = lfsMasterAreaRctRow.Operation;
				lfsMasterAreaRctExpandedRow.ChangedBy = lfsMasterAreaRctRow.ChangedBy;
				lfsMasterAreaRctExpandedRow.USERNAME = loginGateway.GetUsername(lfsMasterAreaRctRow.ChangedBy, companyId);
				lfsMasterAreaRctExpandedRow.Changed = lfsMasterAreaRctRow.Changed;

				//--- ... Make a copy of current record as previous record
				prevLfsMasterAreaRctExpandedRow = auxiliar.LFS_MASTER_AREA_RCT_EXPANDED.NewLFS_MASTER_AREA_RCT_EXPANDEDRow();

				for (int i = 0; i < result.LFS_MASTER_AREA_RCT_EXPANDED.Columns.Count; i++)
				{
					if (result.LFS_MASTER_AREA_RCT_EXPANDED.Columns[i].ColumnName != "RctID")
					{
						prevLfsMasterAreaRctExpandedRow[i] = lfsMasterAreaRctExpandedRow[i];
					}
				}

				//--- ... Add current record to result
				result.LFS_MASTER_AREA_RCT_EXPANDED.AddLFS_MASTER_AREA_RCT_EXPANDEDRow(lfsMasterAreaRctExpandedRow);
			}

			//--- Expand point repairs rct
			TDSLFSRecordForRCT.LFS_POINT_REPAIRS_RCT_EXPANDEDRow prevLfsPointRepairsRctExpandedRow = null;

			foreach(TDSLFSRecord.LFS_POINT_REPAIRS_RCTRow lfsPointRepairsRctRow in tdsLfsRecord.LFS_POINT_REPAIRS_RCT)
			{
				//--- ... Create current record
				TDSLFSRecordForRCT.LFS_POINT_REPAIRS_RCT_EXPANDEDRow lfsPointRepairsRctExpandedRow = result.LFS_POINT_REPAIRS_RCT_EXPANDED.NewLFS_POINT_REPAIRS_RCT_EXPANDEDRow();

				//--- ... Copy data from previous record to current record (if previous record exists)
				if ((prevLfsPointRepairsRctExpandedRow != null) && (prevLfsPointRepairsRctExpandedRow.RefID == lfsPointRepairsRctRow.RefID))
				{
					for (int i = 0; i < result.LFS_POINT_REPAIRS_RCT_EXPANDED.Columns.Count; i++)
					{
						if (result.LFS_POINT_REPAIRS_RCT_EXPANDED.Columns[i].ColumnName != "RctID")
						{
							lfsPointRepairsRctExpandedRow[i] = prevLfsPointRepairsRctExpandedRow[i];
						}
					}
				}

				//--- ... Expand current record
				lfsPointRepairsRctExpandedRow.ID = lfsPointRepairsRctRow.ID;
				lfsPointRepairsRctExpandedRow.RefID = lfsPointRepairsRctRow.RefID;
				lfsPointRepairsRctExpandedRow.COMPANY_ID = lfsPointRepairsRctRow.COMPANY_ID;

				#region Expand changes
				
				foreach (string columnValueItem in RecordChangeTracking.Split(lfsPointRepairsRctRow.Changes))
				{
					switch (RecordChangeTracking.GetColumnName(columnValueItem))
					{
						case "ID":
							break;
						case "RefID":
							break;
						case "COMPANY_ID":
							break;
						case "DetailID":
							lfsPointRepairsRctExpandedRow.DetailID = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "RepairSize":
							lfsPointRepairsRctExpandedRow.RepairSize = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "InstallDate":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsPointRepairsRctExpandedRow.InstallDate = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsPointRepairsRctExpandedRow.SetInstallDateNull();
							break;
						case "Distance":
							lfsPointRepairsRctExpandedRow.Distance = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "Cost":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsPointRepairsRctExpandedRow.Cost = Convert.ToDecimal(RecordChangeTracking.GetValue(columnValueItem)); else lfsPointRepairsRctExpandedRow.SetCostNull();
							break;
						case "Reinstates":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsPointRepairsRctExpandedRow.Reinstates = Convert.ToInt32(RecordChangeTracking.GetValue(columnValueItem)); else lfsPointRepairsRctExpandedRow.SetReinstatesNull();
							break;
						case "LTAtMH":
							lfsPointRepairsRctExpandedRow.LTAtMH = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "VTAtMH":
							lfsPointRepairsRctExpandedRow.VTAtMH = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "LinerDistance":
							lfsPointRepairsRctExpandedRow.LinerDistance = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "Direction":
							lfsPointRepairsRctExpandedRow.Direction = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "MHShot":
							lfsPointRepairsRctExpandedRow.MHShot = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "Comments":
							lfsPointRepairsRctExpandedRow.Comments = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "Deleted":
							lfsPointRepairsRctExpandedRow.Deleted = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "ExtraRepair":
							lfsPointRepairsRctExpandedRow.ExtraRepair = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "Cancelled":
							lfsPointRepairsRctExpandedRow.Cancelled = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "Approved":
							lfsPointRepairsRctExpandedRow.Approved = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "NotApproved":
							lfsPointRepairsRctExpandedRow.NotApproved = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "Archived":
							lfsPointRepairsRctExpandedRow.Archived = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						default:
							throw new Exception ("Invalid column in LFS_POINT_REPAIRS_RCT_EXPANDED.");
					}
				}
						
				#endregion

				lfsPointRepairsRctExpandedRow.Operation = lfsPointRepairsRctRow.Operation;
				lfsPointRepairsRctExpandedRow.ChangedBy = lfsPointRepairsRctRow.ChangedBy;
				lfsPointRepairsRctExpandedRow.USERNAME = loginGateway.GetUsername(lfsPointRepairsRctRow.ChangedBy, companyId);
				lfsPointRepairsRctExpandedRow.Changed = lfsPointRepairsRctRow.Changed;

				//--- ... Make a copy of current record as previous record
				prevLfsPointRepairsRctExpandedRow = auxiliar.LFS_POINT_REPAIRS_RCT_EXPANDED.NewLFS_POINT_REPAIRS_RCT_EXPANDEDRow();

				for (int i = 0; i < result.LFS_POINT_REPAIRS_RCT_EXPANDED.Columns.Count; i++)
				{
					if (result.LFS_POINT_REPAIRS_RCT_EXPANDED.Columns[i].ColumnName != "RctID")
					{
						prevLfsPointRepairsRctExpandedRow[i] = lfsPointRepairsRctExpandedRow[i];
					}
				}

				//--- ... Add current record to result
				result.LFS_POINT_REPAIRS_RCT_EXPANDED.AddLFS_POINT_REPAIRS_RCT_EXPANDEDRow(lfsPointRepairsRctExpandedRow);
			}
			
			//--- Expand m2 tables rct
			TDSLFSRecordForRCT.LFS_M2_TABLES_RCT_EXPANDEDRow prevLfsM2TablesRctExpandedRow = null;

			foreach(TDSLFSRecord.LFS_M2_TABLES_RCTRow lfsM2TablesRctRow in tdsLfsRecord.LFS_M2_TABLES_RCT)
			{
				//--- ... Create current record
				TDSLFSRecordForRCT.LFS_M2_TABLES_RCT_EXPANDEDRow lfsM2TablesRctExpandedRow = result.LFS_M2_TABLES_RCT_EXPANDED.NewLFS_M2_TABLES_RCT_EXPANDEDRow();

				//--- ... Copy data from previous record to current record (if previous record exists)
				if ((prevLfsM2TablesRctExpandedRow != null) && (prevLfsM2TablesRctExpandedRow.RefID == lfsM2TablesRctRow.RefID))
				{
					for (int i = 0; i < result.LFS_M2_TABLES_RCT_EXPANDED.Columns.Count; i++)
					{
						if (result.LFS_M2_TABLES_RCT_EXPANDED.Columns[i].ColumnName != "RctID")
						{
							lfsM2TablesRctExpandedRow[i] = prevLfsM2TablesRctExpandedRow[i];
						}
					}
				}

				//--- ... Expand current record
				lfsM2TablesRctExpandedRow.ID = lfsM2TablesRctRow.ID;
				lfsM2TablesRctExpandedRow.RefID = lfsM2TablesRctRow.RefID;
				lfsM2TablesRctExpandedRow.COMPANY_ID = lfsM2TablesRctRow.COMPANY_ID;

				#region Expand changes
				
				foreach (string columnValueItem in RecordChangeTracking.Split(lfsM2TablesRctRow.Changes))
				{
					switch (RecordChangeTracking.GetColumnName(columnValueItem))
					{
						case "ID":
							break;
						case "RefID":
							break;
						case "COMPANY_ID":
							break;
						case "VideoDistance":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsM2TablesRctExpandedRow.VideoDistance = Convert.ToSingle(RecordChangeTracking.GetValue(columnValueItem)); else lfsM2TablesRctExpandedRow.SetVideoDistanceNull();
							break;
						case "ClockPosition":
							lfsM2TablesRctExpandedRow.ClockPosition = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "LiveOrAbandoned":
							lfsM2TablesRctExpandedRow.LiveOrAbandoned = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "DistanceToCentreOfLateral":
							lfsM2TablesRctExpandedRow.DistanceToCentreOfLateral = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "LateralDiameter":
							lfsM2TablesRctExpandedRow.LateralDiameter = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "LateralType":
							lfsM2TablesRctExpandedRow.LateralType = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "DateTimeOpened":
							lfsM2TablesRctExpandedRow.DateTimeOpened = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "Comments":
							lfsM2TablesRctExpandedRow.Comments = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "ReverseSetup":
							lfsM2TablesRctExpandedRow.ReverseSetup = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "Deleted":
							lfsM2TablesRctExpandedRow.Deleted = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "Archived":
							lfsM2TablesRctExpandedRow.Archived = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						default:
							throw new Exception ("Invalid column in LFS_POINT_REPAIRS_RCT_EXPANDED.");
					}
				}
						
				#endregion

				lfsM2TablesRctExpandedRow.Operation = lfsM2TablesRctRow.Operation;
				lfsM2TablesRctExpandedRow.ChangedBy = lfsM2TablesRctRow.ChangedBy;
				lfsM2TablesRctExpandedRow.USERNAME = loginGateway.GetUsername(lfsM2TablesRctRow.ChangedBy, companyId);
				lfsM2TablesRctExpandedRow.Changed = lfsM2TablesRctRow.Changed;

				//--- ... Make a copy of current record as previous record
				prevLfsM2TablesRctExpandedRow = auxiliar.LFS_M2_TABLES_RCT_EXPANDED.NewLFS_M2_TABLES_RCT_EXPANDEDRow();

				for (int i = 0; i < result.LFS_M2_TABLES_RCT_EXPANDED.Columns.Count; i++)
				{
					if (result.LFS_M2_TABLES_RCT_EXPANDED.Columns[i].ColumnName != "RctID")
					{
						prevLfsM2TablesRctExpandedRow[i] = lfsM2TablesRctExpandedRow[i];
					}
				}

				//--- ... Add current record to result
				result.LFS_M2_TABLES_RCT_EXPANDED.AddLFS_M2_TABLES_RCT_EXPANDEDRow(lfsM2TablesRctExpandedRow);
			}

			//--- Expand junction liners rct
			TDSLFSRecordForRCT.LFS_JUNCTION_LINER_RCT_EXPANDEDRow prevLfsJunctionLinerRctExpandedRow = null;

			foreach(TDSLFSRecord.LFS_JUNCTION_LINER_RCTRow lfsJunctionLinerRctRow in tdsLfsRecord.LFS_JUNCTION_LINER_RCT)
			{
				//--- ... Create current record
				TDSLFSRecordForRCT.LFS_JUNCTION_LINER_RCT_EXPANDEDRow lfsJunctionLinerRctExpandedRow = result.LFS_JUNCTION_LINER_RCT_EXPANDED.NewLFS_JUNCTION_LINER_RCT_EXPANDEDRow();

				//--- ... Copy data from previous record to current record (if previous record exists)
				if ((prevLfsJunctionLinerRctExpandedRow != null) && (prevLfsJunctionLinerRctExpandedRow.RefID == lfsJunctionLinerRctRow.RefID))
				{
					for (int i = 0; i < result.LFS_JUNCTION_LINER_RCT_EXPANDED.Columns.Count; i++)
					{
						if (result.LFS_JUNCTION_LINER_RCT_EXPANDED.Columns[i].ColumnName != "RctID")
						{
							lfsJunctionLinerRctExpandedRow[i] = prevLfsJunctionLinerRctExpandedRow[i];
						}
					}
				}

				//--- ... Expand current record
				lfsJunctionLinerRctExpandedRow.ID = lfsJunctionLinerRctRow.ID;
				lfsJunctionLinerRctExpandedRow.RefID = lfsJunctionLinerRctRow.RefID;
				lfsJunctionLinerRctExpandedRow.COMPANY_ID = lfsJunctionLinerRctRow.COMPANY_ID;

				#region Expand changes
				
				foreach (string columnValueItem in RecordChangeTracking.Split(lfsJunctionLinerRctRow.Changes))
				{
					switch (RecordChangeTracking.GetColumnName(columnValueItem))
					{
						case "ID":
							break;
						case "RefID":
							break;
						case "COMPANY_ID":
							break;
						case "DetailID":
							lfsJunctionLinerRctExpandedRow.DetailID = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "MN":
							lfsJunctionLinerRctExpandedRow.MN = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "DistanceFromUSMH":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsJunctionLinerRctExpandedRow.DistanceFromUSMH = Convert.ToDouble(RecordChangeTracking.GetValue(columnValueItem)); else lfsJunctionLinerRctExpandedRow.SetDistanceFromUSMHNull();
							break;
						case "ConfirmedLatSize":
							lfsJunctionLinerRctExpandedRow.ConfirmedLatSize = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "LateralMaterial":
							lfsJunctionLinerRctExpandedRow.LateralMaterial = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "SharedLateral":
							lfsJunctionLinerRctExpandedRow.SharedLateral = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "CleanoutRequired":
							lfsJunctionLinerRctExpandedRow.CleanoutRequired = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "PitRequired":
							lfsJunctionLinerRctExpandedRow.PitRequired = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "MHShot":
							lfsJunctionLinerRctExpandedRow.MHShot = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "MainConnection":
							lfsJunctionLinerRctExpandedRow.MainConnection = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "Transition":
							lfsJunctionLinerRctExpandedRow.Transition = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "CleanoutInstalled":
							lfsJunctionLinerRctExpandedRow.CleanoutInstalled = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "PitInstalled":
							lfsJunctionLinerRctExpandedRow.PitInstalled = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "CleanoutGrouted":
							lfsJunctionLinerRctExpandedRow.CleanoutGrouted = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "CleanoutCored":
							lfsJunctionLinerRctExpandedRow.CleanoutCored = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "PrepCompleted":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsJunctionLinerRctExpandedRow.PrepCompleted = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsJunctionLinerRctExpandedRow.SetPrepCompletedNull();
							break;
						case "MeasuredLatLength":
							lfsJunctionLinerRctExpandedRow.MeasuredLatLength = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "MeasurementsTakenBy":
							lfsJunctionLinerRctExpandedRow.MeasurementsTakenBy = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "LinerInstalled":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsJunctionLinerRctExpandedRow.LinerInstalled = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsJunctionLinerRctExpandedRow.SetLinerInstalledNull();
							break;
						case "FinalVideo":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsJunctionLinerRctExpandedRow.FinalVideo = Convert.ToDateTime(RecordChangeTracking.GetValue(columnValueItem)); else lfsJunctionLinerRctExpandedRow.SetFinalVideoNull();
							break;
						case "RestorationComplete":
							lfsJunctionLinerRctExpandedRow.RestorationComplete = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "LinerOrdered":
							lfsJunctionLinerRctExpandedRow.LinerOrdered = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "LinerInStock":
							lfsJunctionLinerRctExpandedRow.LinerInStock = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "LinerPrice":
							if (RecordChangeTracking.GetValue(columnValueItem) != "") lfsJunctionLinerRctExpandedRow.LinerPrice = Convert.ToDecimal(RecordChangeTracking.GetValue(columnValueItem)); else lfsJunctionLinerRctExpandedRow.SetLinerPriceNull();
							break;
						case "Comments":
							lfsJunctionLinerRctExpandedRow.Comments = RecordChangeTracking.GetValue(columnValueItem);
							break;
						case "Deleted":
							lfsJunctionLinerRctExpandedRow.Deleted = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						case "Archived":
							lfsJunctionLinerRctExpandedRow.Deleted = Convert.ToBoolean(RecordChangeTracking.GetValue(columnValueItem));
							break;
						default:
							throw new Exception ("Invalid column in LFS_JUNCTION_LINER_RCT_EXPANDED.");
					}
				}
						
				#endregion

				lfsJunctionLinerRctExpandedRow.Operation = lfsJunctionLinerRctRow.Operation;
				lfsJunctionLinerRctExpandedRow.ChangedBy = lfsJunctionLinerRctRow.ChangedBy;
				lfsJunctionLinerRctExpandedRow.USERNAME = loginGateway.GetUsername(lfsJunctionLinerRctRow.ChangedBy, companyId);
				lfsJunctionLinerRctExpandedRow.Changed = lfsJunctionLinerRctRow.Changed;

				//--- ... Make a copy of current record as previous record
				prevLfsJunctionLinerRctExpandedRow = auxiliar.LFS_JUNCTION_LINER_RCT_EXPANDED.NewLFS_JUNCTION_LINER_RCT_EXPANDEDRow();

				for (int i = 0; i < result.LFS_JUNCTION_LINER_RCT_EXPANDED.Columns.Count; i++)
				{
					if (result.LFS_JUNCTION_LINER_RCT_EXPANDED.Columns[i].ColumnName != "RctID")
					{
						prevLfsJunctionLinerRctExpandedRow[i] = lfsJunctionLinerRctExpandedRow[i];
					}
				}

				//--- ... Add current record to result
				result.LFS_JUNCTION_LINER_RCT_EXPANDED.AddLFS_JUNCTION_LINER_RCT_EXPANDEDRow(lfsJunctionLinerRctExpandedRow);
			}

			return result;
		}



		//
		// UpdateRecord
		//
		// Updates the database from a typed dataset containing a row for LFS_MASTER_AREA,
		// zero or more rows for LFS_POINT_REPAIRS, and zero or more rows for LFS_M2_TABLES.
		//
		public void UpdateRecord(TDSLFSRecord dataSet)
		{
			//--- Prepare transaction

			//--- ... Open connection and start transaction
			dcConnection.Open();
			SqlTransaction transaction = dcConnection.BeginTransaction();

			//--- ... Assign transaction to data adapters
			this.daLFSMasterArea.InsertCommand.Transaction = transaction;
			this.daLFSMasterArea.UpdateCommand.Transaction = transaction;
			this.daLFSMasterArea.DeleteCommand.Transaction = transaction;

			this.daLFSPointRepairs.InsertCommand.Transaction = transaction;
			this.daLFSPointRepairs.UpdateCommand.Transaction = transaction;
			this.daLFSPointRepairs.DeleteCommand.Transaction = transaction;

			this.daLFSM2Tables.InsertCommand.Transaction = transaction;
			this.daLFSM2Tables.UpdateCommand.Transaction = transaction;
			this.daLFSM2Tables.DeleteCommand.Transaction = transaction;

			this.daLFSJunctionLiner.InsertCommand.Transaction = transaction;
			this.daLFSJunctionLiner.UpdateCommand.Transaction = transaction;
			this.daLFSJunctionLiner.DeleteCommand.Transaction = transaction;

            this.daLFSJunctionLiner2.InsertCommand.Transaction = transaction;
            this.daLFSJunctionLiner2.UpdateCommand.Transaction = transaction;
            this.daLFSJunctionLiner2.DeleteCommand.Transaction = transaction;

			this.daLfsMasterAreaRct.InsertCommand.Transaction = transaction;
			this.daLfsMasterAreaRct.UpdateCommand.Transaction = transaction;
			this.daLfsMasterAreaRct.DeleteCommand.Transaction = transaction;

			this.daLfsPointRepairsRct.InsertCommand.Transaction = transaction;
			this.daLfsPointRepairsRct.UpdateCommand.Transaction = transaction;
			this.daLfsPointRepairsRct.DeleteCommand.Transaction = transaction;

			this.daLfsM2TablesRct.InsertCommand.Transaction = transaction;
			this.daLfsM2TablesRct.UpdateCommand.Transaction = transaction;
			this.daLfsM2TablesRct.DeleteCommand.Transaction = transaction;

			this.daLfsJunctionLinerRct.InsertCommand.Transaction = transaction;
			this.daLfsJunctionLinerRct.UpdateCommand.Transaction = transaction;
			this.daLfsJunctionLinerRct.DeleteCommand.Transaction = transaction;

			try
			{
				//--- Update database

				//--- ... deletes
				daLFSJunctionLiner.Update(dataSet.LFS_JUNCTION_LINER.Select("", "", DataViewRowState.Deleted));
                daLFSJunctionLiner2.Update(dataSet.LFS_JUNCTION_LINER2.Select("", "", DataViewRowState.Deleted));
				daLFSM2Tables.Update(dataSet.LFS_M2_TABLES.Select("", "", DataViewRowState.Deleted));
				daLFSPointRepairs.Update(dataSet.LFS_POINT_REPAIRS.Select("", "", DataViewRowState.Deleted));
				daLFSMasterArea.Update(dataSet.LFS_MASTER_AREA.Select("", "", DataViewRowState.Deleted));

				//--- ... updates
                daLFSJunctionLiner2.Update(dataSet.LFS_JUNCTION_LINER2.Select("", "", DataViewRowState.ModifiedCurrent));
                daLFSMasterArea.Update(dataSet.LFS_MASTER_AREA.Select("", "", DataViewRowState.ModifiedCurrent));
				daLFSPointRepairs.Update(dataSet.LFS_POINT_REPAIRS.Select("", "", DataViewRowState.ModifiedCurrent));
				daLFSM2Tables.Update(dataSet.LFS_M2_TABLES.Select("", "", DataViewRowState.ModifiedCurrent));
				daLFSJunctionLiner.Update(dataSet.LFS_JUNCTION_LINER.Select("", "", DataViewRowState.ModifiedCurrent));
                

				//--- ... inserts
				daLFSMasterArea.Update(dataSet.LFS_MASTER_AREA.Select("", "", DataViewRowState.Added));
				daLFSPointRepairs.Update(dataSet.LFS_POINT_REPAIRS.Select("", "", DataViewRowState.Added));
				daLFSM2Tables.Update(dataSet.LFS_M2_TABLES.Select("", "", DataViewRowState.Added));
				daLFSJunctionLiner.Update(dataSet.LFS_JUNCTION_LINER.Select("", "", DataViewRowState.Added));
                daLFSJunctionLiner2.Update(dataSet.LFS_JUNCTION_LINER2.Select("", "", DataViewRowState.Added));

				//--- ... record change tracking records
				daLfsMasterAreaRct.Update(dataSet);
				daLfsPointRepairsRct.Update(dataSet);
				daLfsM2TablesRct.Update(dataSet);
				daLfsJunctionLinerRct.Update(dataSet);

				//--- Commit transaction
				transaction.Commit();
			}
			catch(DBConcurrencyException dBConcurrencyException)
			{
				//--- Rollback transaction
				transaction.Rollback();

				//--- Throw exception
				throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
			}
			catch(SqlException sqlException)
			{
				//--- Rollback transaction
				transaction.Rollback();

				//--- Throw exception
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
			catch(Exception e)
			{
				//--- Rollback transaction
				transaction.Rollback();

				//--- Throw exception
				throw new Exception("Unknow error.  Your operation has been cancelled.", e);
			}
			finally
			{
				//--- Close connection
				if (dcConnection.State == System.Data.ConnectionState.Open)
				{
					dcConnection.Close();
				}
			}
		}




        //
        // UpdateRecord2
        //
        // Updates the database from a typed dataset containing a row for LFS_MASTER_AREA,
        // and zero or more rows for LFS_M2_TABLES.
        // 
        public void UpdateRecord2(TDSLFSRecord dataSet, int companyId, AddRecordTDS addRecordTDS, ViewFullLengthLiningTDS viewFullLengthLiningTDS, ViewJLinersheetTDS viewJLinersheetTDS, string tdsToWork)
        {
            //--- Prepare transaction
            //--- ... Open connection and start transaction
            dcConnection.Open();
            SqlTransaction transaction2 = dcConnection.BeginTransaction();

            //... Assign transaction to data adapters
            this.daLFSMasterArea.InsertCommand.Transaction = transaction2;
            this.daLFSMasterArea.UpdateCommand.Transaction = transaction2;
            this.daLFSMasterArea.DeleteCommand.Transaction = transaction2;

            this.daLFSJunctionLiner2.InsertCommand.Transaction = transaction2;
            this.daLFSJunctionLiner2.UpdateCommand.Transaction = transaction2;
            this.daLFSJunctionLiner2.DeleteCommand.Transaction = transaction2;

            this.daLfsMasterAreaRct.InsertCommand.Transaction = transaction2;
            this.daLfsMasterAreaRct.UpdateCommand.Transaction = transaction2;
            this.daLfsMasterAreaRct.DeleteCommand.Transaction = transaction2;

            this.daLfsJunctionLinerRct.InsertCommand.Transaction = transaction2;
            this.daLfsJunctionLinerRct.UpdateCommand.Transaction = transaction2;
            this.daLfsJunctionLinerRct.DeleteCommand.Transaction = transaction2;

            try
            {
                //Update database

                //... deletes
                daLFSJunctionLiner2.Update(dataSet.LFS_JUNCTION_LINER2.Select("", "", DataViewRowState.Deleted));
                daLFSMasterArea.Update(dataSet.LFS_MASTER_AREA.Select("", "", DataViewRowState.Deleted));

                //... updates
                daLFSJunctionLiner2.Update(dataSet.LFS_JUNCTION_LINER2.Select("", "", DataViewRowState.ModifiedCurrent));
                daLFSMasterArea.Update(dataSet.LFS_MASTER_AREA.Select("", "", DataViewRowState.ModifiedCurrent));

                //... inserts
                // Point Repairs
                daLFSMasterArea.Update(dataSet.LFS_MASTER_AREA.Select("", "", DataViewRowState.Added));                
                daLFSJunctionLiner2.Update(dataSet.LFS_JUNCTION_LINER2.Select("", "", DataViewRowState.Added));

                //... record change tracking records
                daLfsMasterAreaRct.Update(dataSet);               
                
                //--- Commit transaction
                transaction2.Commit();
                                
            }
            catch (DBConcurrencyException dBConcurrencyException)
            {
                //--- Rollback transaction
                transaction2.Rollback();

                //--- Throw exception
                throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
            }
            catch (SqlException sqlException)
            {
                //--- Rollback transaction
                transaction2.Rollback();

                //--- Throw exception
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
                //--- Rollback transaction
                transaction2.Rollback();

                //--- Throw exception
                throw new Exception("Unknow error.  Your operation has been cancelled.", e);
            }
            finally
            {
                //--- Close connection
                if (dcConnection.State == System.Data.ConnectionState.Open)
                {
                    dcConnection.Close();
                }

                object[] array = dataSet.LFS_MASTER_AREA.Rows[0].ItemArray;
                Guid newId = (Guid)array.GetValue(0);

                if (tdsToWork == "addRecord")
                {
                    AddRecordPointRepairs addRecordPointRepairs = new AddRecordPointRepairs(addRecordTDS);
                    addRecordPointRepairs.Save(companyId, newId);
                }

                if (tdsToWork == "viewFullLengthLining")
                {
                    ViewFullLengthLiningLfsM2Tables viewFullLengthLiningLfsM2Tables = new ViewFullLengthLiningLfsM2Tables(viewFullLengthLiningTDS);
                    viewFullLengthLiningLfsM2Tables.Save(companyId, newId);
                }

                if (tdsToWork == "viewJLinersheet")
                {
                    ViewJLinersheetJunctionLiner viewJLinersheetJunctionLiner = new ViewJLinersheetJunctionLiner(viewJLinersheetTDS);
                    viewJLinersheetJunctionLiner.Save(companyId, newId);
                }
            }
        }



		//
		// DeleteRecordByIdCompanyId
		//
//		public void DeleteRecordByIdCompanyId(Guid id, int companyId)
//		{
//			SqlConnection connection = new SqlConnection(ConnectionString);
//
//			connection.Open();
//			SqlTransaction transaction = connection.BeginTransaction();
//
//			try
//			{
//				string commandText = "UPDATE LFS_M2_TABLES SET Deleted = 1 WHERE (ID = @id) AND (COMPANY_ID = @companyId)" +
//					                 "UPDATE LFS_POINT_REPAIRS SET Deleted = 1 WHERE (ID = @id) AND (COMPANY_ID = @companyId)" +
//					                 "UPDATE LFS_MASTER_AREA SET Deleted = 1 WHERE (ID = @id) AND (COMPANY_ID = @companyId)";
//				SqlCommand command = new SqlCommand(commandText, connection, transaction);
//				command.Parameters.Add(new SqlParameter("@id", id));
//				command.Parameters.Add(new SqlParameter("@companyId", companyId));
//				command.ExecuteNonQuery();
//
//				transaction.Commit();
//			}
//			catch(System.Exception ex)
//			{
//				transaction.Rollback();
//				throw ex;
//			}
//			finally
//			{
//				connection.Close();
//			}
//		}
            

	}
}
