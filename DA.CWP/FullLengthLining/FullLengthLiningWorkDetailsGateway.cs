using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FullLengthLiningWorkDetailsGateway
    /// </summary>
    public class FullLengthLiningWorkDetailsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FullLengthLiningWorkDetailsGateway()
            : base("WorkDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FullLengthLiningWorkDetailsGateway(DataSet data)
            : base(data, "WorkDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FullLengthLiningTDS();
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
            tableMapping.DataSetTable = "WorkDetails";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("ProposedLiningDate", "ProposedLiningDate");
            tableMapping.ColumnMappings.Add("DeadlineLiningDate", "DeadlineLiningDate");
            tableMapping.ColumnMappings.Add("P1Date", "P1Date");
            tableMapping.ColumnMappings.Add("M1Date", "M1Date");
            tableMapping.ColumnMappings.Add("M2Date", "M2Date");
            tableMapping.ColumnMappings.Add("InstallDate", "InstallDate");
            tableMapping.ColumnMappings.Add("FinalVideoDate", "FinalVideoDate");
            tableMapping.ColumnMappings.Add("IssueIdentified", "IssueIdentified");
            tableMapping.ColumnMappings.Add("IssueLFS", "IssueLFS");
            tableMapping.ColumnMappings.Add("IssueClient", "IssueClient");
            tableMapping.ColumnMappings.Add("IssueSales", "IssueSales");
            tableMapping.ColumnMappings.Add("IssueGivenToClient", "IssueGivenToClient");
            tableMapping.ColumnMappings.Add("IssueResolved", "IssueResolved");
            tableMapping.ColumnMappings.Add("IssueInvestigation", "IssueInvestigation");
            tableMapping.ColumnMappings.Add("CXIsRemoved", "CXIsRemoved");
            tableMapping.ColumnMappings.Add("MeasurementTakenBy", "MeasurementTakenBy");
            tableMapping.ColumnMappings.Add("Material", "Material");
            tableMapping.ColumnMappings.Add("TrafficControl", "TrafficControl");
            tableMapping.ColumnMappings.Add("SiteDetails", "SiteDetails");
            tableMapping.ColumnMappings.Add("PipeSizeChange", "PipeSizeChange");
            tableMapping.ColumnMappings.Add("StandardBypass", "StandardBypass");            
            tableMapping.ColumnMappings.Add("StandardBypassComments", "StandardBypassComments");
            tableMapping.ColumnMappings.Add("TrafficControlDetails", "TrafficControlDetails");
            tableMapping.ColumnMappings.Add("MeasurementType", "MeasurementType");
            tableMapping.ColumnMappings.Add("MeasurementFromMH", "MeasurementFromMH");
            tableMapping.ColumnMappings.Add("VideoDoneFromMH", "VideoDoneFromMH");
            tableMapping.ColumnMappings.Add("VideoDoneToMH", "VideoDoneToMH");
            tableMapping.ColumnMappings.Add("MeasurementTakenByM2", "MeasurementTakenByM2");
            tableMapping.ColumnMappings.Add("DropPipe", "DropPipe");
            tableMapping.ColumnMappings.Add("DropPipeInvertDepth", "DropPipeInvertDepth");
            tableMapping.ColumnMappings.Add("CappedLaterals", "CappedLaterals");
            tableMapping.ColumnMappings.Add("LineWithID", "LineWithID");
            tableMapping.ColumnMappings.Add("HydrantAddress", "HydrantAddress");
            tableMapping.ColumnMappings.Add("HydroWireWithin10FtOfInversionMH", "HydroWireWithin10FtOfInversionMH");            
            tableMapping.ColumnMappings.Add("DistanceToInversionMH", "DistanceToInversionMH");
            tableMapping.ColumnMappings.Add("SurfaceGrade", "SurfaceGrade");
            tableMapping.ColumnMappings.Add("HydroPulley", "HydroPulley");
            tableMapping.ColumnMappings.Add("FridgeCart", "FridgeCart");
            tableMapping.ColumnMappings.Add("TwoPump", "TwoPump");
            tableMapping.ColumnMappings.Add("SixBypass", "SixBypass");
            tableMapping.ColumnMappings.Add("Scaffolding", "Scaffolding");
            tableMapping.ColumnMappings.Add("WinchExtension", "WinchExtension");
            tableMapping.ColumnMappings.Add("ExtraGenerator", "ExtraGenerator");
            tableMapping.ColumnMappings.Add("GreyCableExtension", "GreyCableExtension");
            tableMapping.ColumnMappings.Add("EasementMats", "EasementMats");
            tableMapping.ColumnMappings.Add("RampRequired", "RampRequired");
            tableMapping.ColumnMappings.Add("VideoLength", "VideoLength");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("PreFlushDate", "PreFlushDate");
            tableMapping.ColumnMappings.Add("PreVideoDate", "PreVideoDate");
            tableMapping.ColumnMappings.Add("RaProjectId", "RaProjectId");
            tableMapping.ColumnMappings.Add("RaWorkId", "RaWorkId");
            tableMapping.ColumnMappings.Add("CameraSkid", "CameraSkid");
            tableMapping.ColumnMappings.Add("RoboticPrepCompleted", "RoboticPrepCompleted");
            tableMapping.ColumnMappings.Add("RoboticPrepCompletedDate", "RoboticPrepCompletedDate");
            
            // Wet out data
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
            tableMapping.ColumnMappings.Add("WetOutInstallDate", "WetOutInstallDate");
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
            tableMapping.ColumnMappings.Add("CommentsCipp", "CommentsCipp");
            tableMapping.ColumnMappings.Add("ResinsLabel", "CommentsCipp");
            tableMapping.ColumnMappings.Add("DrumContainsLabel", "DrumContainsLabel");
            tableMapping.ColumnMappings.Add("LinerTubeLabel", "LinerTubeLabel");
            tableMapping.ColumnMappings.Add("ForLbDrumsLabel", "forLbDrumsLabel");
            tableMapping.ColumnMappings.Add("NetResinLabel", "NetResinLabel");
            tableMapping.ColumnMappings.Add("CatalystLabel", "CatalystLabel");

            tableMapping.ColumnMappings.Add("InversionComment", "InversionComment");
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
            tableMapping.ColumnMappings.Add("InversionLinerTubeLabel", "InversionLinerTubeLabel");
            tableMapping.ColumnMappings.Add("HeadsIdealLabel", "HeadsIdealLabel");
            tableMapping.ColumnMappings.Add("PumpingAndCirculationLabel", "PumpingAndCirculationLabel");

            tableMapping.ColumnMappings.Add("AccessType", "AccessType");
            tableMapping.ColumnMappings.Add("P1Completed", "P1Completed");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByWorkIdAssetId
        /// </summary>
        /// <param name="workId">workID</param>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByWorkIdAssetId(int workId, int assetId,int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FULLLENGTHLININGWORKDETAILSGATEWAY_LOADBYWORKIDASSETID", new SqlParameter("@workId", workId), new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int workId)
        {
            string filter = string.Format("WorkID = {0}", workId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.FullLengthLining.FullLengthLiningWorkDetailsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetClientId. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ClientId or EMPTY</returns>
        public string GetClientId(int workId)
        {
            if (GetRow(workId).IsNull("ClientID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ClientID"];
            }
        }



        /// <summary>
        /// GetClientId Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original ClientID or EMPTY</returns>
        public string GetClientIdOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["ClientID"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ClientID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetProposedLiningDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ProposedLiningDate o EMPTY</returns>
        public DateTime? GetProposedLiningDate(int workId)
        {
            if (GetRow(workId).IsNull("ProposedLiningDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["ProposedLiningDate"];
            }
        }



        /// <summary>
        /// GetProposedLiningDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original ProposedLiningDate or EMPTY</returns>
        public DateTime? GetProposedLiningDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["ProposedLiningDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["ProposedLiningDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDeadlineLiningDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ProposedLiningDate o EMPTY</returns>
        public DateTime? GetDeadlineLiningDate(int workId)
        {
            if (GetRow(workId).IsNull("DeadlineLiningDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["DeadlineLiningDate"];
            }
        }



        /// <summary>
        /// GetDeadlineLiningDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DeadlineLiningDate or EMPTY</returns>
        public DateTime? GetDeadlineLiningDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DeadlineLiningDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["DeadlineLiningDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetP1Date. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>P1 Date o EMPTY</returns>
        public DateTime? GetP1Date(int workId)
        {
            if (GetRow(workId).IsNull("P1Date"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["P1Date"];
            }
        }



        /// <summary>
        /// GetP1Date Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original P1Date or EMPTY</returns>
        public DateTime? GetP1DateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["P1Date"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["P1Date", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetM1Date. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>M1 Date o EMPTY</returns>
        public DateTime? GetM1Date(int workId)
        {
            if (GetRow(workId).IsNull("M1Date"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["M1Date"];
            }
        }



        /// <summary>
        /// GetM1Date Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original M1Date or EMPTY</returns>
        public DateTime? GetM1DateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["M1Date"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["M1Date", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetM2Date. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>M2 Date o EMPTY</returns>
        public DateTime? GetM2Date(int workId)
        {
            if (GetRow(workId).IsNull("M2Date"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["M2Date"];
            }
        }



        /// <summary>
        /// GetM2Date Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original M2Date or EMPTY</returns>
        public DateTime? GetM2DateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["M2Date"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["M2Date", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInstallDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>InstallDate o EMPTY</returns>
        public DateTime? GetInstallDate(int workId)
        {
            if (GetRow(workId).IsNull("InstallDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["InstallDate"];
            }
        }



        /// <summary>
        /// GetInstallDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original InstallDate or EMPTY</returns>
        public DateTime? GetInstallDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["InstallDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["InstallDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetFinalVideoDate. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>FinalVideoDate o EMPTY</returns>
        public DateTime? GetFinalVideoDate(int workId)
        {
            if (GetRow(workId).IsNull("FinalVideoDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["FinalVideoDate"];
            }
        }



        /// <summary>
        /// GetFinalVideoDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original FinalVideoDate or EMPTY</returns>
        public DateTime? GetFinalVideoDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["FinalVideoDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["FinalVideoDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetIssueIdentified. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueIdentified</returns>
        public bool GetIssueIdentified(int workId)
        {
            return (bool)GetRow(workId)["IssueIdentified"];
        }



        /// <summary>
        /// GetIssueIdentified Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueIdentified or EMPTY</returns>
        public bool GetIssueIdentifiedOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueIdentified", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueLFS. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueLFS</returns>
        public bool GetIssueLFS(int workId)
        {
            return (bool)GetRow(workId)["IssueLFS"];
        }



        /// <summary>
        /// GetIssueLFS Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueLFS or EMPTY</returns>
        public bool GetIssueLFSOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueLFS", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueClient. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueClient</returns>
        public bool GetIssueClient(int workId)
        {
            return (bool)GetRow(workId)["IssueClient"];
        }



        /// <summary>
        /// GetIssueClient Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueClient or EMPTY</returns>
        public bool GetIssueClientOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueClient", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueSales. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueSales</returns>
        public bool GetIssueSales(int workId)
        {
            return (bool)GetRow(workId)["IssueSales"];
        }



        /// <summary>
        /// GetIssueSales Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueSales or EMPTY</returns>
        public bool GetIssueSalesOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueSales", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueGivenToClient. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueGivenToClient</returns>
        public bool GetIssueGivenToClient(int workId)
        {
            return (bool)GetRow(workId)["IssueGivenToClient"];
        }



        /// <summary>
        /// GetIssueGivenToClient Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueGivenToClient or EMPTY</returns>
        public bool GetIssueGivenToClientOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueGivenToClient", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueResolved. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueResolved</returns>
        public bool GetIssueResolved(int workId)
        {
            return (bool)GetRow(workId)["IssueResolved"];
        }



        /// <summary>
        /// GetIssueResolved Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueResolved or EMPTY</returns>
        public bool GetIssueResolvedOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueResolved", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueInvestigation. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueInvestigation</returns>
        public bool GetIssueInvestigation(int workId)
        {
            return (bool)GetRow(workId)["IssueInvestigation"];
        }



        /// <summary>
        /// GetIssueInvestigation Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueInvestigation or EMPTY</returns>
        public bool GetIssueInvestigationOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueInvestigation", DataRowVersion.Original];
        }
        


        /// <summary>
        /// GetCxisRemoved. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CXIsRemoved or EMPTY</returns>
        public int? GetCxisRemoved(int workId)
        {
            if (GetRow(workId).IsNull("CXIsRemoved"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["CXIsRemoved"];
            }
        }



        /// <summary>
        /// GetCxisRemoved Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original CXIsRemoved or EMPTY</returns>
        public int? GetCxisRemovedOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["CXIsRemoved"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["CXIsRemoved", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMeasurementTakenBy. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>MeasurementTakenBy or EMPTY</returns>
        public string GetMeasurementTakenBy(int workId)
        {
            if (GetRow(workId).IsNull("MeasurementTakenBy"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementTakenBy"];
            }
        }



        /// <summary>
        /// GetMeasurementTakenBy Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original MeasurementTakenBy or EMPTY</returns>
        public string GetMeasurementTakenByOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["MeasurementTakenBy"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementTakenBy", DataRowVersion.Original];
            }
        }


        
        /// <summary>
        /// GetMaterial. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>StandardBypassComments or EMPTY</returns>
        public string GetMaterial(int workId)
        {
            if (GetRow(workId).IsNull("Material"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Material"];
            }
        }



        /// <summary>
        /// GetMaterial Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Material or EMPTY</returns>
        public string GetMaterialOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Material"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Material", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTrafficControl. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TrafficControl or EMPTY</returns>
        public string GetTrafficControl(int workId)
        {
            if (GetRow(workId).IsNull("TrafficControl"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["TrafficControl"];
            }
        }



        /// <summary>
        /// GetTrafficControl Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TrafficControl or EMPTY</returns>
        public string GetTrafficControlOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["TrafficControl"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["TrafficControl", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSiteDetails. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>SiteDetails or EMPTY</returns>
        public string GetSiteDetails(int workId)
        {
            if (GetRow(workId).IsNull("SiteDetails"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["SiteDetails"];
            }
        }



        /// <summary>
        /// GetSiteDetails Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original SiteDetails or EMPTY</returns>
        public string GetSiteDetailsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["SiteDetails"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["SiteDetails", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPipeSizeChange. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PipeSizeChange</returns>
        public bool GetPipeSizeChange(int workId)
        {
            return (bool)GetRow(workId)["PipeSizeChange"];
        }



        /// <summary>
        /// GetPipeSizeChange Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PipeSizeChange or EMPTY</returns>
        public bool GetPipeSizeChangeOriginal(int workId)
        {
            return (bool)GetRow(workId)["PipeSizeChange", DataRowVersion.Original];
        }



        /// <summary>
        /// GetStandardBypass. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>StandardBypass</returns>
        public bool GetStandardBypass(int workId)
        {
            return (bool)GetRow(workId)["StandardBypass"];
        }



        /// <summary>
        /// GetStandardBypass Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original StandardBypass or EMPTY</returns>
        public bool GetStandardBypassOriginal(int workId)
        {
            return (bool)GetRow(workId)["StandardBypass", DataRowVersion.Original];
        }


        
        /// <summary>
        /// GetStandardBypassComments. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>StandardBypassComments or EMPTY</returns>
        public string GetStandardBypassComments(int workId)
        {
            if (GetRow(workId).IsNull("StandardBypassComments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["StandardBypassComments"];
            }
        }



        /// <summary>
        /// GetStandardBypassComments Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original StandardBypassComments or EMPTY</returns>
        public string GetStandardBypassCommentsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["StandardBypassComments"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["StandardBypassComments", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTrafficControlDetails. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TrafficControlDetails or EMPTY</returns>
        public string GetTrafficControlDetails(int workId)
        {
            if (GetRow(workId).IsNull("TrafficControlDetails"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["TrafficControlDetails"];
            }
        }



        /// <summary>
        /// GetTrafficControlDetails Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TrafficControlDetails or EMPTY</returns>
        public string GetTrafficControlDetailsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["TrafficControlDetails"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["TrafficControlDetails", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMeasurementType. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>MeasurementType or EMPTY</returns>
        public string GetMeasurementType(int workId)
        {
            if (GetRow(workId).IsNull("MeasurementType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementType"];
            }
        }



        /// <summary>
        /// GetMeasurementType Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original MeasurementType or EMPTY</returns>
        public string GetMeasurementTypeOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["MeasurementType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMeasurementFromMh. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>MeasurementFromMH or EMPTY</returns>
        public string GetMeasurementFromMh(int workId)
        {
            if (GetRow(workId).IsNull("MeasurementFromMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementFromMH"];
            }
        }



        /// <summary>
        /// GetMeasurementFromMh Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original MeasurementFromMH or EMPTY</returns>
        public string GetMeasurementFromMhOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["MeasurementFromMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementFromMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetVideoDoneFromMh. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>VideoDoneFromMH or EMPTY</returns>
        public string GetVideoDoneFromMh(int workId)
        {
            if (GetRow(workId).IsNull("VideoDoneFromMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoDoneFromMH"];
            }
        }



        /// <summary>
        /// GetVideoDoneFromMh Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original VideoDoneFromMH or EMPTY</returns>
        public string GetVideoDoneFromMhOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["VideoDoneFromMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoDoneFromMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetVideoDoneToMh. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>VideoDoneToMH or EMPTY</returns>
        public string GetVideoDoneToMh(int workId)
        {
            if (GetRow(workId).IsNull("VideoDoneToMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoDoneToMH"];
            }
        }



        /// <summary>
        /// GetVideoDoneToMh Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original VideoDoneToMH or EMPTY</returns>
        public string GetVideoDoneToMhOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["VideoDoneToMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoDoneToMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMeasurementTakenByM2. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>MeasurementTakenByM2 or EMPTY</returns>
        public string GetMeasurementTakenByM2(int workId)
        {
            if (GetRow(workId).IsNull("MeasurementTakenByM2"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementTakenByM2"];
            }
        }



        /// <summary>
        /// GetMeasurementTakenByM2 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original MeasurementTakenByM2 or EMPTY</returns>
        public string GetMeasurementTakenByM2Original(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["MeasurementTakenByM2"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementTakenByM2", DataRowVersion.Original];
            }
        }


        
        /// <summary>
        /// GetDropPipe. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DropPipe</returns>
        public bool GetDropPipe(int workId)
        {
            return (bool)GetRow(workId)["DropPipe"];
        }



        /// <summary>
        /// GetDropPipe Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DropPipe or EMPTY</returns>
        public bool GetDropPipeOriginal(int workId)
        {
            return (bool)GetRow(workId)["DropPipe", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDropPipeInvertDepth. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DropPipeInvertDepth or EMPTY</returns>
        public string GetDropPipeInvertDepth(int workId)
        {
            if (GetRow(workId).IsNull("DropPipeInvertDepth"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DropPipeInvertDepth"];
            }
        }



        /// <summary>
        /// GetDropPipeInvertDepth Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DropPipeInvertDepth or EMPTY</returns>
        public string GetDropPipeInvertDepthOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DropPipeInvertDepth"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DropPipeInvertDepth", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCappedLaterals. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CappedLaterals or EMPTY</returns>
        public int? GetCappedLaterals(int workId)
        {
            if (GetRow(workId).IsNull("CappedLaterals"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["CappedLaterals"];
            }
        }



        /// <summary>
        /// GetCappedLaterals Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original CappedLaterals or EMPTY</returns>
        public int? GetCappedLateralsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["CappedLaterals"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["CappedLaterals", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLineWithId. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LineWithID or EMPTY</returns>
        public string GetLineWithId(int workId)
        {
            if (GetRow(workId).IsNull("LineWithID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["LineWithID"];
            }
        }



        /// <summary>
        /// GetLineWithId Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original LineWithID or EMPTY</returns>
        public string GetLineWithIdOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["LineWithID"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["LineWithID", DataRowVersion.Original];
            }
        }
            
        

        /// <summary>
        /// GetHydrantAddress. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HydrantAddress or EMPTY</returns>
        public string GetHydrantAddress(int workId)
        {
            if (GetRow(workId).IsNull("HydrantAddress"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["HydrantAddress"];
            }
        }



        /// <summary>
        /// GetHydrantAddress Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original HydrantAddress or EMPTY</returns>
        public string GetHydrantAddressOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["HydrantAddress"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["HydrantAddress", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetHydroWiredWithin10FtOfInversionMH. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HydroWiredWithin10FtOfInversionMH or EMPTY</returns>
        public string GetHydroWiredWithin10FtOfInversionMH(int workId)
        {
            if (GetRow(workId).IsNull("HydroWireWithin10FtOfInversionMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["HydroWireWithin10FtOfInversionMH"];
            }
        }



        /// <summary>
        /// GetHydroWiredWithin10FtOfInversionMH Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original HydroWiredWithin10FtOfInversionMH or EMPTY</returns>
        public string GetHydroWiredWithin10FtOfInversionMHOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["HydroWireWithin10FtOfInversionMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["HydroWireWithin10FtOfInversionMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDistanceToInversionMh. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DistanceToInversionMH or EMPTY</returns>
        public string GetDistanceToInversionMh(int workId)
        {
            if (GetRow(workId).IsNull("DistanceToInversionMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DistanceToInversionMH"];
            }
        }



        /// <summary>
        /// GetDistanceToInversionMh Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DistanceToInversionMH or EMPTY</returns>
        public string GetDistanceToInversionMhOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DistanceToInversionMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DistanceToInversionMH", DataRowVersion.Original];
            }
        }
     

        
        /// <summary>
        /// GetSurfaceGrade. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>SurfaceGrade or EMPTY</returns>
        public string GetSurfaceGrade(int workId)
        {
            if (GetRow(workId).IsNull("SurfaceGrade"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["SurfaceGrade"];
            }
        }



        /// <summary>
        /// GetSurfaceGrade Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original SurfaceGrade or EMPTY</returns>
        public string GetSurfaceGradeOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["SurfaceGrade"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["SurfaceGrade", DataRowVersion.Original];
            }
        }
                


        /// <summary>
        /// GetHydroPulley. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HydroPulley</returns>
        public bool GetHydroPulley(int workId)
        {
            return (bool)GetRow(workId)["HydroPulley"];
        }



        /// <summary>
        /// GetHydroPulley Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original HydroPulley or EMPTY</returns>
        public bool GetHydroPulleyOriginal(int workId)
        {
            return (bool)GetRow(workId)["HydroPulley", DataRowVersion.Original];
        }



        /// <summary>
        /// GetFridgeCart. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>FridgeCart</returns>
        public bool GetFridgeCart(int workId)
        {
            return (bool)GetRow(workId)["FridgeCart"];
        }



        /// <summary>
        /// GetFridgeCart Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original FridgeCart or EMPTY</returns>
        public bool GetFridgeCartOriginal(int workId)
        {
            return (bool)GetRow(workId)["FridgeCart", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTwoPump. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TwoPump</returns>
        public bool GetTwoPump(int workId)
        {
            return (bool)GetRow(workId)["TwoPump"];
        }



        /// <summary>
        /// GetTwoPump Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TwoPump or EMPTY</returns>
        public bool GetTwoPumpOriginal(int workId)
        {
            return (bool)GetRow(workId)["TwoPump", DataRowVersion.Original];
        }



        /// <summary>
        /// GetSixBypass. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>SixBypass</returns>
        public bool GetSixBypass(int workId)
        {
            return (bool)GetRow(workId)["SixBypass"];
        }



        /// <summary>
        /// GetSixBypass Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original SixBypass or EMPTY</returns>
        public bool GetSixBypassOriginal(int workId)
        {
            return (bool)GetRow(workId)["SixBypass", DataRowVersion.Original];
        }



        /// <summary>
        /// GetScaffolding. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Scaffolding</returns>
        public bool GetScaffolding(int workId)
        {
            return (bool)GetRow(workId)["Scaffolding"];
        }



        /// <summary>
        /// GetScaffolding Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Scaffolding or EMPTY</returns>
        public bool GetScaffoldingOriginal(int workId)
        {
            return (bool)GetRow(workId)["Scaffolding", DataRowVersion.Original];
        }



        /// <summary>
        /// GetWinchExtension. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>WinchExtension</returns>
        public bool GetWinchExtension(int workId)
        {
            return (bool)GetRow(workId)["WinchExtension"];
        }



        /// <summary>
        /// GetWinchExtension Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original WinchExtention or EMPTY</returns>
        public bool GetWinchExtensionOriginal(int workId)
        {
            return (bool)GetRow(workId)["WinchExtension", DataRowVersion.Original];
        }



        /// <summary>
        /// GetExtraGenerator. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ExtraGenerator</returns>
        public bool GetExtraGenerator(int workId)
        {
            return (bool)GetRow(workId)["ExtraGenerator"];
        }



        /// <summary>
        /// GetExtraGenerator Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original ExtraGenerator or EMPTY</returns>
        public bool GetExtraGeneratorOriginal(int workId)
        {
            return (bool)GetRow(workId)["ExtraGenerator", DataRowVersion.Original];
        }



        /// <summary>
        /// GetGreyCableExtension. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>GreyCableExtension</returns>
        public bool GetGreyCableExtension(int workId)
        {
            return (bool)GetRow(workId)["GreyCableExtension"];
        }



        /// <summary>
        /// GetGreyCableExtension Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original GreyCableExtension or EMPTY</returns>
        public bool GetGreyCableExtensionOriginal(int workId)
        {
            return (bool)GetRow(workId)["GreyCableExtension", DataRowVersion.Original];
        }



        /// <summary>
        /// GetEasementMats. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>EasementMats</returns>
        public bool GetEasementMats(int workId)
        {
            return (bool)GetRow(workId)["EasementMats"];
        }



        /// <summary>
        /// GetEasementMats Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original EasementMats or EMPTY</returns>
        public bool GetEasementMatsOriginal(int workId)
        {
            return (bool)GetRow(workId)["EasementMats", DataRowVersion.Original];
        }



        /// <summary>
        /// GetRampRequired. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>RampRequired</returns>
        public bool GetRampRequired(int workId)
        {
            return (bool)GetRow(workId)["RampRequired"];
        }



        /// <summary>
        /// GetRampRequired Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original RampRequired or EMPTY</returns>
        public bool GetRampRequiredOriginal(int workId)
        {
            return (bool)GetRow(workId)["RampRequired", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCameraSkid. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CameraSkid</returns>
        public bool GetCameraSkid(int workId)
        {
            return (bool)GetRow(workId)["CameraSkid"];
        }



        /// <summary>
        /// GetCameraSkid Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original CameraSkid or EMPTY</returns>
        public bool GetCameraSkidOriginal(int workId)
        {
            return (bool)GetRow(workId)["CameraSkid", DataRowVersion.Original];
        }

        

        /// <summary>
        /// GetVideoLength. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>VideoLength or EMPTY</returns>
        public string GetVideoLength(int workId)
        {
            if (GetRow(workId).IsNull("VideoLength"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoLength"];
            }
        }



        /// <summary>
        /// GetVideoLength Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original VideoLength or EMPTY</returns>
        public string GetVideoLengthOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["VideoLength"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoLength", DataRowVersion.Original];
            }
        }

        
        
        /// <summary>
        /// GetComments. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Comments or EMPTY</returns>
        public string GetComments(int workId)
        {
            if (GetRow(workId).IsNull("Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Comments"];
            }
        }



        /// <summary>
        /// GetComments Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Comments or EMPTY</returns>
        public string GetCommentsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Comments"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Comments", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPreFlushDate. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PreFlushDate o EMPTY</returns>
        public DateTime? GetPreFlushDate(int workId)
        {
            if (GetRow(workId).IsNull("PreFlushDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PreFlushDate"];
            }
        }



        /// <summary>
        /// GetPreFlushDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PreFlushDate or EMPTY</returns>
        public DateTime? GetPreFlushDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["PreFlushDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PreFlushDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPreVideoDate. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PreVideoDate o EMPTY</returns>
        public DateTime? GetPreVideoDate(int workId)
        {
            if (GetRow(workId).IsNull("PreVideoDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PreVideoDate"];
            }
        }



        /// <summary>
        /// GetPreVideoDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PreVideoDate or EMPTY</returns>
        public DateTime? GetPreVideoDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["PreVideoDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PreVideoDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRaProjectId. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>RaProjectId or EMPTY</returns>
        public int? GetRaProjectId(int workId)
        {
            if (GetRow(workId).IsNull("RaProjectId"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["RaProjectId"];
            }
        }



        /// <summary>
        /// GetRaProjectId Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original RaProjectId or EMPTY</returns>
        public int? GetRaProjectIdOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["RaProjectId"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {

                return (int)GetRow(workId)["RaProjectId", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRaWorkId. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>RaWorkId or EMPTY</returns>
        public int GetRaWorkId(int workId)
        {
            if (GetRow(workId).IsNull("RaWorkId"))
            {
                return 0;
            }
            else
            {
                return (int)GetRow(workId)["RaWorkId"];
            }            
        }



        /// <summary>
        /// GetRaWorkId Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original RaWorkId or EMPTY</returns>
        public int GetRaWorkIdOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["RaWorkId"], DataRowVersion.Original))
            {
                return 0;
            }
            else
            {

                return (int)GetRow(workId)["RaWorkId", DataRowVersion.Original];
            }            
        }



        /// <summary>
        /// GetRoboticPrepCompleted. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>RoboticPrepCompleted</returns>
        public bool GetRoboticPrepCompleted(int workId)
        {
            return (bool)GetRow(workId)["RoboticPrepCompleted"];
        }



        /// <summary>
        /// GetRoboticPrepCompleted Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original RoboticPrepCompleted or EMPTY</returns>
        public bool GetRoboticPrepCompletedOriginal(int workId)
        {
            return (bool)GetRow(workId)["RoboticPrepCompleted", DataRowVersion.Original];
        }



        /// <summary>
        /// GetRoboticPrepCompletedDate. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>RoboticPrepCompletedDate o EMPTY</returns>
        public DateTime? GetRoboticPrepCompletedDate(int workId)
        {
            if (GetRow(workId).IsNull("RoboticPrepCompletedDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["RoboticPrepCompletedDate"];
            }
        }



        /// <summary>
        /// GetRoboticPrepCompletedDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original RoboticPrepCompletedDate or EMPTY</returns>
        public DateTime? GetRoboticPrepCompletedDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["RoboticPrepCompletedDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["RoboticPrepCompletedDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLinerTube. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LinerTube or EMPTY</returns>
        public string GetLinerTube(int workId)
        {
            if (GetRow(workId).IsNull("LinerTube"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["LinerTube"];
            }
        }



        /// <summary>
        /// GetLinerTube Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original LinerTube or EMPTY</returns>
        public string GetLinerTubeOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["LinerTube"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["LinerTube", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetExcessResin. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ExcessResin or EMPTY</returns>
        public decimal GetExcessResin(int workId)
        {
             return (decimal)GetRow(workId)["ExcessResin"];           
        }



        /// <summary>
        /// GetExcessResin Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original ExcessResin or EMPTY</returns>
        public decimal GetExcessResinOriginal(int workId)
        {
            return (decimal)GetRow(workId)["ExcessResin", DataRowVersion.Original];
        }



        /// <summary>
        /// GetResinId. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ResinID or EMPTY</returns>
        public int GetResinId(int workId)
        {
            return (int)GetRow(workId)["ResinID"];
        }



        /// <summary>
        /// GetResinId Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original ResinID or EMPTY</returns>
        public int GetResinIdOriginal(int workId)
        {
            return (int)GetRow(workId)["ResinID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetEmployeeIdd. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>EmployeeID or EMPTY</returns>
        public int GetEmployeeId(int workId)
        {
            return (int)GetRow(workId)["EmployeeID"];
        }



        /// <summary>
        /// GetEmployeeId Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original EmployeeID or EMPTY</returns>
        public int GetEmployeeIdOriginal(int workId)
        {
            return (int)GetRow(workId)["EmployeeID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPoundsDrums. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PoundsDrums or EMPTY</returns>
        public string GetPoundsDrums(int workId)
        {          
            return (string)GetRow(workId)["PoundsDrums"];           
        }



        /// <summary>
        /// GetPoundsDrums Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PoundsDrums or EMPTY</returns>
        public string GetPoundsDrumsOriginal(int workId)
        {
            return (string)GetRow(workId)["PoundsDrums", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDrumDiameter. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DrumDiameter or EMPTY</returns>
        public decimal GetDrumDiameter(int workId)
        {
            return (decimal)GetRow(workId)["DrumDiameter"];
        }



        /// <summary>
        /// GetDrumDiameter Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DrumDiameter or EMPTY</returns>
        public decimal GetDrumDiameterOriginal(int workId)
        {
            return (decimal)GetRow(workId)["DrumDiameter", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetHoistMaximumHeight. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HoistMaximumHeight or EMPTY</returns>
        public decimal GetHoistMaximumHeight(int workId)
        {
            return (decimal)GetRow(workId)["HoistMaximumHeight"];
        }



        /// <summary>
        /// GetHoistMaximumHeight Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original HoistMaximumHeight or EMPTY</returns>
        public decimal GetHoistMaximumHeightOriginal(int workId)
        {
            return (decimal)GetRow(workId)["HoistMaximumHeight", DataRowVersion.Original];           
        }



         /// <summary>
        /// GetHoistMinimumHeight. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HoistMinimumHeight or EMPTY</returns>
        public decimal GetHoistMinimumHeight(int workId)
        {
            return (decimal)GetRow(workId)["HoistMinimumHeight"];
        }



        /// <summary>
        /// GetHoistMinimumHeight Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original HoistMinimumHeight or EMPTY</returns>
        public decimal GetHoistMinimumHeightOriginal(int workId)
        {
            return (decimal)GetRow(workId)["HoistMinimumHeight", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetDownDropTubeLenght. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DownDropTubeLenght or EMPTY</returns>
        public decimal GetDownDropTubeLenght(int workId)
        {
            return (decimal)GetRow(workId)["DownDropTubeLenght"];            
        }



        /// <summary>
        /// GetDownDropTubeLenght Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DownDropTubeLenght or EMPTY</returns>
        public decimal GetDownDropTubeLenghtOriginal(int workId)
        {
            return (decimal)GetRow(workId)["DownDropTubeLenght", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetPumpHeightAboveGround. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PumpHeightAboveGround or EMPTY</returns>
        public decimal GetPumpHeightAboveGround(int workId)
        {
            return (decimal)GetRow(workId)["PumpHeightAboveGround"];            
        }



        /// <summary>
        /// GetPumpHeightAboveGround Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PumpHeightAboveGround or EMPTY</returns>
        public decimal GetPumpHeightAboveGroundOriginal(int workId)
        {
            return (decimal)GetRow(workId)["PumpHeightAboveGround", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetTubeResinToFeltFactor. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TubeResinToFeltFactor or EMPTY</returns>
        public int GetTubeResinToFeltFactor(int workId)
        {
            return (int)GetRow(workId)["TubeResinToFeltFactor"];            
        }



        /// <summary>
        /// GetTubeResinToFeltFactor Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TubeResinToFeltFactor or EMPTY</returns>
        public int GetTubeResinToFeltFactorOriginal(int workId)
        {
            return (int)GetRow(workId)["TubeResinToFeltFactor", DataRowVersion.Original];           
        }

        

        /// <summary>
        /// GetDateOfSheet. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DateOfSheet o EMPTY</returns>
        public DateTime GetDateOfSheet(int workId)
        {
            return (DateTime)GetRow(workId)["DateOfSheet"];            
        }



        /// <summary>
        /// GetDateOfSheet Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DateOfSheet or EMPTY</returns>
        public DateTime GetDateOfSheetOriginal(int workId)
        {
            return (DateTime)GetRow(workId)["DateOfSheet", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetRunDetails. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>RunDetails or EMPTY</returns>
        public string GetRunDetails(int workId)
        {
            if (GetRow(workId).IsNull("RunDetails"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["RunDetails"];
            }
        }



        /// <summary>
        /// GetRunDetails Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original RunDetails or EMPTY</returns>
        public string GetRunDetailsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["RunDetails"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["RunDetails", DataRowVersion.Original];
            }
        }




        /// <summary>
        /// GetRunDetails2. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>RunDetails2 or EMPTY</returns>
        public string GetRunDetails2(int workId)
        {
            if (GetRow(workId).IsNull("RunDetails2"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["RunDetails2"];
            }
        }



        /// <summary>
        /// GetRunDetails2 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original RunDetails2 or EMPTY</returns>
        public string GetRunDetails2Original(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["RunDetails2"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["RunDetails2", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetWetOutDate. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>WetOutDate o EMPTY</returns>
        public DateTime GetWetOutDate(int workId)
        {
            return (DateTime)GetRow(workId)["WetOutDate"];            
        }



        /// <summary>
        /// GetWetOutDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original WetOutDate or EMPTY</returns>
        public DateTime GetWetOutDateOriginal(int workId)
        {
            return (DateTime)GetRow(workId)["WetOutDate", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetWetOutInstallDate. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>WetOutInstallDate o EMPTY</returns>
        public DateTime? GetWetOutInstallDate(int workId)
        {
            if (GetRow(workId).IsNull("WetOutInstallDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["WetOutInstallDate"];
            }
        }



        /// <summary>
        /// GetWetOutInstallDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original WetOutInstallDate or EMPTY</returns>
        public DateTime? GetWetOutInstallDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["WetOutInstallDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["WetOutInstallDate", DataRowVersion.Original];     
            }
                   
        }



        /// <summary>
        /// GetInversionThickness. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Thickness or EMPTY</returns>
        public string GetInversionThickness(int workId)
        {
            if (GetRow(workId).IsNull("Thickness"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Thickness"];
            }
        }



        /// <summary>
        /// GetInversionThickness Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Thickness or EMPTY</returns>
        public string GetInversionThicknessOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Thickness"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Thickness", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLengthToLine. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LengthToLine or EMPTY</returns>
        public decimal GetLengthToLine(int workId)
        {
            return (decimal)GetRow(workId)["LengthToLine"];            
        }



        /// <summary>
        /// GetLengthToLine Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original LengthToLine or EMPTY</returns>
        public decimal GetLengthToLineOriginal(int workId)
        {
            return (decimal)GetRow(workId)["LengthToLine", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetPlusExtra. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PlusExtra or EMPTY</returns>
        public decimal GetPlusExtra(int workId)
        {
            return (decimal)GetRow(workId)["PlusExtra"];            
        }



        /// <summary>
        /// GetPlusExtra Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PlusExtra or EMPTY</returns>
        public decimal GetPlusExtraOriginal(int workId)
        {
            return (decimal)GetRow(workId)["PlusExtra", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetForTurnOffset. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ForTurnOffset or EMPTY</returns>
        public decimal GetForTurnOffset(int workId)
        {
            return (decimal)GetRow(workId)["ForTurnOffset"];            
        }



        /// <summary>
        /// GetForTurnOffset Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original ForTurnOffset or EMPTY</returns>
        public decimal GetForTurnOffsetOriginal(int workId)
        {
            return (decimal)GetRow(workId)["ForTurnOffset", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetLengthToWetOut. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LengthToWetOut or EMPTY</returns>
        public decimal GetLengthToWetOut(int workId)
        {
            return (decimal)GetRow(workId)["LengthToWetOut"];            
        }



        /// <summary>
        /// GetLengthToWetOut Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original LengthToWetOut or EMPTY</returns>
        public decimal GetLengthToWetOutOriginal(int workId)
        {
            return (decimal)GetRow(workId)["LengthToWetOut", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetTubeMaxColdHead. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TubeMaxColdHead or EMPTY</returns>
        public decimal GetTubeMaxColdHead(int workId)
        {
            return (decimal)GetRow(workId)["TubeMaxColdHead"];            
        }



        /// <summary>
        /// GetTubeMaxColdHead Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TubeMaxColdHead or EMPTY</returns>
        public decimal GetTubeMaxColdHeadOriginal(int workId)
        {
            return (decimal)GetRow(workId)["TubeMaxColdHead", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetTubeMaxColdHeadPsi. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TubeMaxColdHeadPsi or EMPTY</returns>
        public decimal GetTubeMaxColdHeadPsi(int workId)
        {
            return (decimal)GetRow(workId)["TubeMaxColdHeadPsi"];            
        }



        /// <summary>
        /// GetTubeMaxColdHeadPsi Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TubeMaxColdHeadPsi or EMPTY</returns>
        public decimal GetTubeMaxColdHeadPsiOriginal(int workId)
        {
            return (decimal)GetRow(workId)["TubeMaxColdHeadPsi", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetTubeMaxHotHead. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TubeMaxHotHead or EMPTY</returns>
        public decimal GetTubeMaxHotHead(int workId)
        {
             return (decimal)GetRow(workId)["TubeMaxHotHead"];            
        }



        /// <summary>
        /// GetTubeMaxHotHead Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TubeMaxHotHead or EMPTY</returns>
        public decimal GetTubeMaxHotHeadOriginal(int workId)
        {
            return (decimal)GetRow(workId)["TubeMaxHotHead", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetTubeMaxHotHeadPsi. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TubeMaxHotHeadPsi or EMPTY</returns>
        public decimal GetTubeMaxHotHeadPsi(int workId)
        {
            return (decimal)GetRow(workId)["TubeMaxHotHeadPsi"];            
        }



        /// <summary>
        /// GetTubeMaxHotHeadPsi Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TubeMaxHotHeadPsi or EMPTY</returns>
        public decimal GetTubeMaxHotHeadPsiOriginal(int workId)
        {
            return (decimal)GetRow(workId)["TubeMaxHotHeadPsi", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetTubeIdealHead. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TubeIdealHead or EMPTY</returns>
        public decimal GetTubeIdealHead(int workId)
        {
            return (decimal)GetRow(workId)["TubeIdealHead"];           
        }



        /// <summary>
        /// GetTubeIdealHead Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TubeIdealHead or EMPTY</returns>
        public decimal GetTubeIdealHeadOriginal(int workId)
        {
            return (decimal)GetRow(workId)["TubeIdealHead", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetTubeIdealHeadPsi. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TubeIdealHeadPsi or EMPTY</returns>
        public decimal GetTubeIdealHeadPsi(int workId)
        {
            return (decimal)GetRow(workId)["TubeIdealHeadPsi"];            
        }



        /// <summary>
        /// GetTubeIdealHeadPsi Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TubeIdealHeadPsi or EMPTY</returns>
        public decimal GetTubeIdealHeadPsiOriginal(int workId)
        {
            return (decimal)GetRow(workId)["TubeIdealHeadPsi", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetNetResinForTube. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NetResinForTube or EMPTY</returns>
        public decimal GetNetResinForTube(int workId)
        {          
            return (decimal)GetRow(workId)["NetResinForTube"];            
        }



        /// <summary>
        /// GetNetResinForTube Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original NetResinForTube or EMPTY</returns>
        public decimal GetNetResinForTubeOriginal(int workId)
        {
            return (decimal)GetRow(workId)["NetResinForTube", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetNetResinForTubeUsgals. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NetResinForTubeUsgals or EMPTY</returns>
        public decimal GetNetResinForTubeUsgals(int workId)
        {
            return (decimal)GetRow(workId)["NetResinForTubeUsgals"];            
        }



        /// <summary>
        /// GetNetResinForTubeUsgals Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original NetResinForTubeUsgals or EMPTY</returns>
        public decimal GetNetResinForTubeUsgalsOriginal(int workId)
        {
            return (decimal)GetRow(workId)["NetResinForTubeUsgals", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetNetResinForTubeDrumsIns. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NetResinForTubeDrumsIns or EMPTY</returns>
        public string GetNetResinForTubeDrumsIns(int workId)
        {
            if (GetRow(workId).IsNull("NetResinForTubeDrumsIns"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["NetResinForTubeDrumsIns"];
            }
        }



        /// <summary>
        /// GetNetResinForTubeDrumsIns Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original NetResinForTubeDrumsIns or EMPTY</returns>
        public string GetNetResinForTubeDrumsInsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["NetResinForTubeDrumsIns"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["NetResinForTubeDrumsIns", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetNetResinForTubeLbsFt. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NetResinForTubeLbsFt or EMPTY</returns>
        public decimal GetNetResinForTubeLbsFt(int workId)
        {
            return (decimal)GetRow(workId)["NetResinForTubeLbsFt"];            
        }



        /// <summary>
        /// GetNetResinForTubeLbsFt Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original NetResinForTubeLbsFt or EMPTY</returns>
        public decimal GetNetResinForTubeLbsFtOriginal(int workId)
        {
            return (decimal)GetRow(workId)["NetResinForTubeLbsFt", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetNetResinForTubeUsgFt. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NetResinForTubeUsgFt or EMPTY</returns>
        public decimal GetNetResinForTubeUsgFt(int workId)
        {
            return (decimal)GetRow(workId)["NetResinForTubeUsgFt"];            
        }



        /// <summary>
        /// GetNetResinForTubeUsgFt Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original NetResinForTubeUsgFt or EMPTY</returns>
        public decimal GetNetResinForTubeUsgFtOriginal(int workId)
        {
            return (decimal)GetRow(workId)["NetResinForTubeUsgFt", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetExtraResinForMix. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ExtraResinForMix or EMPTY</returns>
        public int GetExtraResinForMix(int workId)
        {
            return (int)GetRow(workId)["ExtraResinForMix"];            
        }



        /// <summary>
        /// GetExtraResinForMix Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original ExtraResinForMix or EMPTY</returns>
        public int GetExtraResinForMixOriginal(int workId)
        {
            return (int)GetRow(workId)["ExtraResinForMix", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetExtraLbsForMix. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ExtraLbsForMix or EMPTY</returns>
        public decimal GetExtraLbsForMix(int workId)
        {
            return (decimal)GetRow(workId)["ExtraLbsForMix"];            
        }



        /// <summary>
        /// GetExtraLbsForMix Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original ExtraLbsForMix or EMPTY</returns>
        public decimal GetExtraLbsForMixOriginal(int workId)
        {
            return (decimal)GetRow(workId)["ExtraLbsForMix", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetTotalMixQuantity. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TotalMixQuantity or EMPTY</returns>
        public decimal GetTotalMixQuantity(int workId)
        {
            return (decimal)GetRow(workId)["TotalMixQuantity"];            
        }



        /// <summary>
        /// GetTotalMixQuantity Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TotalMixQuantity or EMPTY</returns>
        public decimal GetTotalMixQuantityOriginal(int workId)
        {
            return (decimal)GetRow(workId)["TotalMixQuantity", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetTotalMixQuantityUsgals. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TotalMixQuantityUsgals or EMPTY</returns>
        public decimal GetTotalMixQuantityUsgals(int workId)
        {
            return (decimal)GetRow(workId)["TotalMixQuantityUsgals"];            
        }



        /// <summary>
        /// GetTotalMixQuantityUsgals Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TotalMixQuantityUsgals or EMPTY</returns>
        public decimal GetTotalMixQuantityUsgalsOriginal(int workId)
        {
            return (decimal)GetRow(workId)["TotalMixQuantityUsgals", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetTotalMixQuantityDrumsIns. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TotalMixQuantityDrumsIns or EMPTY</returns>
        public string GetTotalMixQuantityDrumsIns(int workId)
        {
            if (GetRow(workId).IsNull("TotalMixQuantityDrumsIns"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["TotalMixQuantityDrumsIns"];
            }
        }



        /// <summary>
        /// GetTotalMixQuantityDrumsIns Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TotalMixQuantityDrumsIns or EMPTY</returns>
        public string GetTotalMixQuantityDrumsInsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["TotalMixQuantityDrumsIns"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["TotalMixQuantityDrumsIns", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInversionType. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>InversionType or EMPTY</returns>
        public string GetInversionType(int workId)
        {
            if (GetRow(workId).IsNull("InversionType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["InversionType"];
            }
        }



        /// <summary>
        /// GetInversionType Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original InversionType or EMPTY</returns>
        public string GetInversionTypeOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["InversionType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["InversionType", DataRowVersion.Original];
            }
        }

                       

        /// <summary>
        /// GetDepthOfInversionMH. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DepthOfInversionMH or EMPTY</returns>
        public decimal GetDepthOfInversionMH(int workId)
        {
            return (decimal)GetRow(workId)["DepthOfInversionMH"];            
        }



        /// <summary>
        /// GetDepthOfInversionMH Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DepthOfInversionMH or EMPTY</returns>
        public decimal GetDepthOfInversionMHOriginal(int workId)
        {
            return (decimal)GetRow(workId)["DepthOfInversionMH", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetTubeForColumn. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TubeForColumn or EMPTY</returns>
        public decimal GetTubeForColumn(int workId)
        {
            return (decimal)GetRow(workId)["TubeForColumn"];            
        }



        /// <summary>
        /// GetTubeForColumn Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TubeForColumn or EMPTY</returns>
        public decimal GetTubeForColumnOriginal(int workId)
        {
            return (decimal)GetRow(workId)["TubeForColumn", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetTubeForStartDry. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TubeForStartDry or EMPTY</returns>
        public decimal GetTubeForStartDry(int workId)
        {
            return (decimal)GetRow(workId)["TubeForStartDry"];            
        }



        /// <summary>
        /// GetTubeForStartDry Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TubeForStartDry or EMPTY</returns>
        public decimal GetTubeForStartDryOriginal(int workId)
        {
            return (decimal)GetRow(workId)["TubeForStartDry", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetTotalTube. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TotalTube or EMPTY</returns>
        public decimal GetTotalTube(int workId)
        {
            return (decimal)GetRow(workId)["TotalTube"];            
        }



        /// <summary>
        /// GetTotalTube Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TotalTube or EMPTY</returns>
        public decimal GetTotalTubeOriginal(int workId)
        {
            return (decimal)GetRow(workId)["TotalTube", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetDropTubeConnects. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DropTubeConnects or EMPTY</returns>
        public string GetDropTubeConnects(int workId)
        {
            if (GetRow(workId).IsNull("DropTubeConnects"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DropTubeConnects"];
            }
        }



        /// <summary>
        /// GetDropTubeConnects Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DropTubeConnects or EMPTY</returns>
        public string GetDropTubeConnectsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DropTubeConnects"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DropTubeConnects", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAllowsHeadTo. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>AllowsHeadTo or EMPTY</returns>
        public decimal GetAllowsHeadTo(int workId)
        {
            return (decimal)GetRow(workId)["AllowsHeadTo"];            
        }



        /// <summary>
        /// GetAllowsHeadTo Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original AllowsHeadTo or EMPTY</returns>
        public decimal GetAllowsHeadToOriginal(int workId)
        {
            return (decimal)GetRow(workId)["AllowsHeadTo", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetRollerGap. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>RollerGap or EMPTY</returns>
        public decimal GetRollerGap(int workId)
        {
            return (decimal)GetRow(workId)["RollerGap"];            
        }



        /// <summary>
        /// GetRollerGap Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original RollerGap or EMPTY</returns>
        public decimal GetRollerGapOriginal(int workId)
        {
            return (decimal)GetRow(workId)["RollerGap", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetHeightNeeded. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HeightNeeded or EMPTY</returns>
        public decimal GetHeightNeeded(int workId)
        {
            return (decimal)GetRow(workId)["HeightNeeded"];            
        }



        /// <summary>
        /// GetHeightNeeded Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original HeightNeeded or EMPTY</returns>
        public decimal GetHeightNeededOriginal(int workId)
        {
            return (decimal)GetRow(workId)["HeightNeeded", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetAvailable. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Available or EMPTY</returns>
        public string GetAvailable(int workId)
        {
            if (GetRow(workId).IsNull("Available"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Available"];
            }
        }



        /// <summary>
        /// GetAvailable Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Available or EMPTY</returns>
        public string GetAvailableOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Available"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Available", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetHoistHeight. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HoistHeight or EMPTY</returns>
        public string GetHoistHeight(int workId)
        {
            if (GetRow(workId).IsNull("HoistHeight"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["HoistHeight"];
            }
        }



        /// <summary>
        /// GetHoistHeight Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original HoistHeight or EMPTY</returns>
        public string GetHoistHeightOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["HoistHeight"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["HoistHeight", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCommentsCipp. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CommentsCipp or EMPTY</returns>
        public string GetCommentsCipp(int workId)
        {
            if (GetRow(workId).IsNull("CommentsCipp"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["CommentsCipp"];
            }
        }



        /// <summary>
        /// GetCommentsCipp Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original CommentsCipp or EMPTY</returns>
        public string GetCommentsCippOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["CommentsCipp"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["CommentsCipp", DataRowVersion.Original];
            }
        }



        ///<summary>
        ///GetResinsLabel. If not exists, raise an exception.
        ///</summary>
        ///<param name="workId">workId</param>
        /// <returns>ResinsLabel or EMPTY</returns>
        public string GetResinsLabel(int workId)
        {
            if (GetRow(workId).IsNull("ResinsLabel"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ResinsLabel"];
            }
        }



        /// <summary>
        /// GetResinsLabel Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original ResinsLabel or EMPTY</returns>
        public string GetResinsLabelOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["ResinsLabel"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ResinsLabel", DataRowVersion.Original];
            }
        }



        ///<summary>
        ///GetDrumContainsLabel. If not exists, raise an exception.
        ///</summary>
        ///<param name="workId">workId</param>
        /// <returns>DrumContainsLabel or EMPTY</returns>
        public string GetDrumContainsLabel(int workId)
        {
            if (GetRow(workId).IsNull("DrumContainsLabel"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DrumContainsLabel"];
            }
        }



        /// <summary>
        /// GetDrumContainsLabel Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DrumContainsLabel or EMPTY</returns>
        public string GetDrumContainsLabelOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DrumContainsLabel"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DrumContainsLabel", DataRowVersion.Original];
            }
        }



        ///<summary>
        ///GetLinerTubeLabel. If not exists, raise an exception.
        ///</summary>
        ///<param name="workId">workId</param>
        /// <returns>LinerTubeLabel or EMPTY</returns>
        public string GetLinerTubeLabel(int workId)
        {
            if (GetRow(workId).IsNull("LinerTubeLabel"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["LinerTubeLabel"];
            }
        }



        /// <summary>
        /// GetLinerTubeLabel Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original LinerTubeLabel or EMPTY</returns>
        public string GetLinerTubeLabelOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["LinerTubeLabel"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["LinerTubeLabel", DataRowVersion.Original];
            }
        }



        ///<summary>
        ///GetForLbDrumsLabel. If not exists, raise an exception.
        ///</summary>
        ///<param name="workId">workId</param>
        /// <returns>ForLbDrumsLabel or EMPTY</returns>
        public string GetForLbDrumsLabel(int workId)
        {
            if (GetRow(workId).IsNull("ForLbDrumsLabel"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ForLbDrumsLabel"];
            }
        }



        /// <summary>
        /// GetForLbDrumsLabel Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original ForLbDrumsLabel or EMPTY</returns>
        public string GetForLbDrumsLabelOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["ForLbDrumsLabel"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ForLbDrumsLabel", DataRowVersion.Original];
            }
        }



        ///<summary>
        ///GetNetResinLabel. If not exists, raise an exception.
        ///</summary>
        ///<param name="workId">workId</param>
        /// <returns>NetResinLabel or EMPTY</returns>
        public string GetNetResinLabel(int workId)
        {
            if (GetRow(workId).IsNull("NetResinLabel"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["NetResinLabel"];
            }
        }



        /// <summary>
        /// GetNetResinLabel Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original NetResinLabel or EMPTY</returns>
        public string GetNetResinLabelOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["NetResinLabel"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["NetResinLabel", DataRowVersion.Original];
            }
        }



        ///<summary>
        ///GetCatalystLabel. If not exists, raise an exception.
        ///</summary>
        ///<param name="workId">workId</param>
        /// <returns>CatalystLabel or EMPTY</returns>
        public string GetCatalystLabel(int workId)
        {
            if (GetRow(workId).IsNull("CatalystLabel"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["CatalystLabel"];
            }
        }



        /// <summary>
        /// GetCatalystLabel Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original CatalystLabel or EMPTY</returns>
        public string GetCatalystLabelOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["CatalystLabel"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["CatalystLabel", DataRowVersion.Original];
            }
        }

        
        
        /// <summary>
        /// GetInversionComment. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>InversionComment or EMPTY</returns>
        public string GetInversionComment(int workId)
        {
            if (GetRow(workId).IsNull("InversionComment"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["InversionComment"];
            }
        }



        /// <summary>
        /// GetInversionComment Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original InversionComment or EMPTY</returns>
        public string GetInversionCommentOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["InversionComment"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["InversionComment", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPipeType. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PipeType or EMPTY</returns>
        public string GetPipeType(int workId)
        {
            if (GetRow(workId).IsNull("PipeType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["PipeType"];
            }
        }



        /// <summary>
        /// GetPipeType Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PipeType or EMPTY</returns>
        public string GetPipeTypeOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["PipeType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["PipeType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPipeCondition. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PipeCondition or EMPTY</returns>
        public string GetPipeCondition(int workId)
        {
            if (GetRow(workId).IsNull("PipeCondition"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["PipeCondition"];
            }
        }



        /// <summary>
        /// GetPipeCondition Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PipeCondition or EMPTY</returns>
        public string GetPipeConditionOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["PipeCondition"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["PipeCondition", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetGroundMoisture. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>GroundMoisture or EMPTY</returns>
        public string GetGroundMoisture(int workId)
        {
            if (GetRow(workId).IsNull("GroundMoisture"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["GroundMoisture"];
            }
        }



        /// <summary>
        /// GetGroundMoisture Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original GroundMoisture or EMPTY</returns>
        public string GetGroundMoistureOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["GroundMoisture"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["GroundMoisture", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetBoilerSize. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>BoilerSize or EMPTY</returns>
        public decimal GetBoilerSize(int workId)
        {
            return (decimal)GetRow(workId)["BoilerSize"];
        }



        /// <summary>
        /// GetBoilerSize Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original BoilerSize or EMPTY</returns>
        public decimal GetBoilerSizeOriginal(int workId)
        {
            return (decimal)GetRow(workId)["BoilerSize", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPumpTotalCapacity. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PumpTotalCapacity or EMPTY</returns>
        public decimal GetPumpTotalCapacity(int workId)
        {
            return (decimal)GetRow(workId)["PumpTotalCapacity"];
        }



        /// <summary>
        /// GetPumpTotalCapacity Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PumpTotalCapacity or EMPTY</returns>
        public decimal GetPumpTotalCapacityOriginal(int workId)
        {
            return (decimal)GetRow(workId)["PumpTotalCapacity", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLayFlatSize. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LayFlatSize or EMPTY</returns>
        public decimal GetLayFlatSize(int workId)
        {
            return (decimal)GetRow(workId)["LayFlatSize"];
        }



        /// <summary>
        /// GetLayFlatSize Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original LayFlatSize or EMPTY</returns>
        public decimal GetLayFlatSizeOriginal(int workId)
        {
            return (decimal)GetRow(workId)["LayFlatSize", DataRowVersion.Original];
        }




        /// <summary>
        /// GetLayFlatQuantityTotal. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LayFlatQuantityTotal or EMPTY</returns>
        public decimal GetLayFlatQuantityTotal(int workId)
        {
            return (decimal)GetRow(workId)["LayFlatQuantityTotal"];
        }



        /// <summary>
        /// GetLayFlatQuantityTotal Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original LayFlatQuantityTotal or EMPTY</returns>
        public decimal GetLayFlatQuantityTotalOriginal(int workId)
        {
            return (decimal)GetRow(workId)["LayFlatQuantityTotal", DataRowVersion.Original];
        }



        /// <summary>
        /// GetWaterStartTemp. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>WaterStartTemp or EMPTY</returns>
        public decimal GetWaterStartTemp(int workId)
        {
            return (decimal)GetRow(workId)["WaterStartTemp"];
        }



        /// <summary>
        /// GetWaterStartTemp Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original WaterStartTemp or EMPTY</returns>
        public decimal GetWaterStartTempOriginal(int workId)
        {
            return (decimal)GetRow(workId)["WaterStartTemp", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTemp1. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Temp1 or EMPTY</returns>
        public decimal GetTemp1(int workId)
        {
            return (decimal)GetRow(workId)["Temp1"];
        }



        /// <summary>
        /// GetTemp1 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Temp1 or EMPTY</returns>
        public decimal GetTemp1Original(int workId)
        {
            return (decimal)GetRow(workId)["Temp1", DataRowVersion.Original];
        }



        /// <summary>
        /// GetHoldAtT1. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HoldAtT1 or EMPTY</returns>
        public decimal GetHoldAtT1(int workId)
        {
            return (decimal)GetRow(workId)["HoldAtT1"];
        }



        /// <summary>
        /// GetHoldAtT1 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original HoldAtT1 or EMPTY</returns>
        public decimal GetHoldAtT1Original(int workId)
        {
            return (decimal)GetRow(workId)["HoldAtT1", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTempT2. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TempT2 or EMPTY</returns>
        public decimal GetTempT2(int workId)
        {
            return (decimal)GetRow(workId)["TempT2"];
        }



        /// <summary>
        /// GetTempT2 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TempT2 or EMPTY</returns>
        public decimal GetTempT2Original(int workId)
        {
            return (decimal)GetRow(workId)["TempT2", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCookAtT2. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CookAtT2 or EMPTY</returns>
        public decimal GetCookAtT2(int workId)
        {
            return (decimal)GetRow(workId)["CookAtT2"];
        }
                       

        
        /// <summary>
        /// GetCookAtT2 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original CookAtT2 or EMPTY</returns>
        public decimal GetCookAtT2Original(int workId)
        {
            return (decimal)GetRow(workId)["CookAtT2", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCoolDownFor. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CoolDownFor or EMPTY</returns>
        public decimal GetCoolDownFor(int workId)
        {
            return (decimal)GetRow(workId)["CoolDownFor"];
        }



        /// <summary>
        /// GetCoolDownFor Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original CoolDownFor or EMPTY</returns>
        public decimal GetCoolDownForOriginal(int workId)
        {
            return (decimal)GetRow(workId)["CoolDownFor", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCoolToTemp. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CoolToTemp or EMPTY</returns>
        public decimal GetCoolToTemp(int workId)
        {
            return (decimal)GetRow(workId)["CoolToTemp"];
        }



        /// <summary>
        /// GetCoolToTemp Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original CoolToTemp or EMPTY</returns>
        public decimal GetCoolToTempOriginal(int workId)
        {
            return (decimal)GetRow(workId)["CoolToTemp", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDropInPipeRun. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DropInPipeRun or EMPTY</returns>
        public decimal GetDropInPipeRun(int workId)
        {
            return (decimal)GetRow(workId)["DropInPipeRun"];
        }



        /// <summary>
        /// GetDropInPipeRun Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DropInPipeRun or EMPTY</returns>
        public decimal GetDropInPipeRunOriginal(int workId)
        {
            return (decimal)GetRow(workId)["DropInPipeRun", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPipeSlopOf. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PipeSlopOf or EMPTY</returns>
        public decimal GetPipeSlopOf(int workId)
        {
            return (decimal)GetRow(workId)["PipeSlopOf"];
        }



        /// <summary>
        /// GetPipeSlopOf Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PipeSlopOf or EMPTY</returns>
        public decimal GetPipeSlopOfOriginal(int workId)
        {
            return (decimal)GetRow(workId)["PipeSlopOf", DataRowVersion.Original];
        }



        /// <summary>
        /// GetF45F120. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>F45F120 or EMPTY</returns>
        public decimal GetF45F120(int workId)
        {
            return (decimal)GetRow(workId)["F45F120"];
        }



        /// <summary>
        /// GetF45F120 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original F45F120 or EMPTY</returns>
        public decimal GetF45F120Original(int workId)
        {
            return (decimal)GetRow(workId)["F45F120", DataRowVersion.Original];
        }



        /// <summary>
        /// GetHold. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Hold or EMPTY</returns>
        public decimal GetHold(int workId)
        {
            return (decimal)GetRow(workId)["Hold"];
        }



        /// <summary>
        /// GetHold Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Hold or EMPTY</returns>
        public decimal GetHoldOriginal(int workId)
        {
            return (decimal)GetRow(workId)["Hold", DataRowVersion.Original];
        }



        /// <summary>
        /// GetF120F185. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>F120F185 or EMPTY</returns>
        public decimal GetF120F185(int workId)
        {
            return (decimal)GetRow(workId)["F120F185"];
        }



        /// <summary>
        /// GetF120F185 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original F120F185 or EMPTY</returns>
        public decimal GetF120F185Original(int workId)
        {
            return (decimal)GetRow(workId)["F120F185", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCookTime. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CookTime or EMPTY</returns>
        public decimal GetCookTime(int workId)
        {
            return (decimal)GetRow(workId)["CookTime"];
        }



        /// <summary>
        /// GetCookTime Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original CookTime or EMPTY</returns>
        public decimal GetCookTimeOriginal(int workId)
        {
            return (decimal)GetRow(workId)["CookTime", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCoolTime. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CoolTime or EMPTY</returns>
        public decimal GetCoolTime(int workId)
        {
            return (decimal)GetRow(workId)["CoolTime"];
        }



        /// <summary>
        /// GetCoolTime Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original CoolTime or EMPTY</returns>
        public decimal GetCoolTimeOriginal(int workId)
        {
            return (decimal)GetRow(workId)["CoolTime", DataRowVersion.Original];
        }



        /// <summary>
        /// GetAproxTotal. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>AproxTotal or EMPTY</returns>
        public decimal GetAproxTotal(int workId)
        {
            return (decimal)GetRow(workId)["AproxTotal"];
        }



        /// <summary>
        /// GetAproxTotal Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original AproxTotal or EMPTY</returns>
        public decimal GetAproxTotalOriginal(int workId)
        {
            return (decimal)GetRow(workId)["AproxTotal", DataRowVersion.Original];
        }



        /// <summary>
        /// GetWaterChangesPerHour. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>WaterChangesPerHour or EMPTY</returns>
        public decimal GetWaterChangesPerHour(int workId)
        {
            return (decimal)GetRow(workId)["WaterChangesPerHour"];
        }



        /// <summary>
        /// GetWaterChangesPerHour Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original WaterChangesPerHour or EMPTY</returns>
        public decimal GetWaterChangesPerHourOriginal(int workId)
        {
            return (decimal)GetRow(workId)["WaterChangesPerHour", DataRowVersion.Original];
        }



        /// <summary>
        /// GetReturnWaterVelocity. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ReturnWaterVelocity or EMPTY</returns>
        public decimal GetReturnWaterVelocity(int workId)
        {
            return (decimal)GetRow(workId)["ReturnWaterVelocity"];
        }



        /// <summary>
        /// GetReturnWaterVelocity Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original ReturnWaterVelocity or EMPTY</returns>
        public decimal GetReturnWaterVelocityOriginal(int workId)
        {
            return (decimal)GetRow(workId)["ReturnWaterVelocity", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLayflatBackPressure. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LayflatBackPressure or EMPTY</returns>
        public decimal GetLayflatBackPressure(int workId)
        {
            return (decimal)GetRow(workId)["LayflatBackPressure"];
        }



        /// <summary>
        /// GetLayflatBackPressure Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original LayflatBackPressure or EMPTY</returns>
        public decimal GetLayflatBackPressureOriginal(int workId)
        {
            return (decimal)GetRow(workId)["LayflatBackPressure", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPumpLiftAtIdealHead. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PumpLiftAtIdealHead or EMPTY</returns>
        public decimal GetPumpLiftAtIdealHead(int workId)
        {
            return (decimal)GetRow(workId)["PumpLiftAtIdealHead"];
        }



        /// <summary>
        /// GetPumpLiftAtIdealHead Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PumpLiftAtIdealHead or EMPTY</returns>
        public decimal GetPumpLiftAtIdealHeadOriginal(int workId)
        {
            return (decimal)GetRow(workId)["PumpLiftAtIdealHead", DataRowVersion.Original];
        }



        /// <summary>
        /// GetWaterToFillLinerColumn. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>WaterToFillLinerColumn or EMPTY</returns>
        public decimal GetWaterToFillLinerColumn(int workId)
        {
            return (decimal)GetRow(workId)["WaterToFillLinerColumn"];
        }



        /// <summary>
        /// GetWaterToFillLinerColumn Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original WaterToFillLinerColumn or EMPTY</returns>
        public decimal GetWaterToFillLinerColumnOriginal(int workId)
        {
            return (decimal)GetRow(workId)["WaterToFillLinerColumn", DataRowVersion.Original];
        }



        /// <summary>
        /// GetWaterPerFit. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>WaterPerFit or EMPTY</returns>
        public decimal GetWaterPerFit(int workId)
        {
            return (decimal)GetRow(workId)["WaterPerFit"];
        }



        /// <summary>
        /// GetWaterPerFit Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original WaterPerFit or EMPTY</returns>
        public decimal GetWaterPerFitOriginal(int workId)
        {
            return (decimal)GetRow(workId)["WaterPerFit", DataRowVersion.Original];
        }



        /// <summary>
        /// GetInstallationResults. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>InstallationResults or EMPTY</returns>
        public string GetInstallationResults(int workId)
        {
            if (GetRow(workId).IsNull("InstallationResults"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["InstallationResults"];
            }
        }



        /// <summary>
        /// GetInstallationResults Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original InstallationResults or EMPTY</returns>
        public string GetInstallationResultsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["InstallationResults"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["InstallationResults", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInversionLinerTubeLabel. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LinerTubeLabel or EMPTY</returns>
        public string GetInversionLinerTubeLabel(int workId)
        {
            if (GetRow(workId).IsNull("InversionLinerTubeLabel"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["InversionLinerTubeLabel"];
            }
        }



        /// <summary>
        /// GetInversionLinerTubeLabel Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original LinerTubeLabel or EMPTY</returns>
        public string GetInversionLinerTubeLabelOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["InversionLinerTubeLabel"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["InversionLinerTubeLabel", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetHeadsIdealLabel. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>HeadsIdealLabel or EMPTY</returns>
        public string GetHeadsIdealLabel(int workId)
        {
            if (GetRow(workId).IsNull("HeadsIdealLabel"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["HeadsIdealLabel"];
            }
        }



        /// <summary>
        /// GetHeadsIdealLabel Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original HeadsIdealLabel or EMPTY</returns>
        public string GetHeadsIdealLabelOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["HeadsIdealLabel"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["HeadsIdealLabel", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPumpingAndCirculationLabel. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PumpingAndCirculationLabel or EMPTY</returns>
        public string GetPumpingAndCirculationLabel(int workId)
        {
            if (GetRow(workId).IsNull("PumpingAndCirculationLabel"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["PumpingAndCirculationLabel"];
            }
        }



        /// <summary>
        /// GetPumpingAndCirculationLabel Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PumpingAndCirculationLabel or EMPTY</returns>
        public string GetPumpingAndCirculationLabelOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["PumpingAndCirculationLabel"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["PumpingAndCirculationLabel", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetP1Completed
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>P1Completed</returns>
        public bool GetP1Completed(int workId)
        {
            return (bool)GetRow(workId)["P1Completed"];
        }



        /// <summary>
        /// GetP1Completed Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original P1Completed</returns>
        public bool GetP1CompletedOriginal(int workId)
        {
            return (bool)GetRow(workId)["P1Completed", DataRowVersion.Original];
        }



        /// <summary>
        /// GetAccessType. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>AccessType or EMPTY</returns>
        public string GetAccessType(int workId)
        {
            if (GetRow(workId).IsNull("AccessType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["AccessType"];
            }
        }



        /// <summary>
        /// GetAccessType Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original AccessType or EMPTY</returns>
        public string GetAccessTypeOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["AccessType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["AccessType", DataRowVersion.Original];
            }
        }
        


    }
}