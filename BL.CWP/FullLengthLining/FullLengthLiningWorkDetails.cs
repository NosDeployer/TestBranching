using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FullLengthLiningWorkDetails
    /// </summary>
    public class FullLengthLiningWorkDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FullLengthLiningWorkDetails()
            : base("WorkDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FullLengthLiningWorkDetails(DataSet data)
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






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByWorkIdAssetId(int workId, int assetId, int companyId)
        {
            FullLengthLiningWorkDetailsGateway fullLengthLiningWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway(Data);
            fullLengthLiningWorkDetailsGateway.LoadByWorkIdAssetId(workId, assetId, companyId);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="clientID">clientID</param>
        /// <param name="proposedLiningDate">proposedLiningDate</param>
        /// <param name="deadlineLiningDate">deadlineLiningDate</param>
        /// <param name="p1Date">p1Date</param>
        /// <param name="m1Date">m1Date</param>
        /// <param name="m2Date">m2Date</param>
        /// <param name="installDate">installDate</param>
        /// <param name="finalVideoDate">finalVideoDate</param>
        /// <param name="issueIdentified">issueIdentified</param>
        /// <param name="issueLFS">issueLFS</param>    
        /// <param name="issueClient">issueClient</param> 
        /// <param name="issueSales">issueSales</param>    
        /// <param name="issueGivenToClient">issueGivenToClient</param>   
        /// <param name="issueResolved">issueResolved</param>   
        /// <param name="issueInvestigation">issueInvestigation</param> 
        /// <param name="CXIsRemoved">CXIsRemoved</param>
        /// <param name="newRoboticPrepCompleted">newRoboticPrepCompleted</param>
        /// <param name="newRoboticPrepCompletedDate">newRoboticPrepCompletedDate</param>
        /// <param name="measurementTakenBy">measurementTakenBy</param>
        /// <param name="material">material</param>
        /// <param name="trafficControl">trafficControl</param>
        /// <param name="siteDetails">siteDetails</param>
        /// <param name="pipeSizeChange">pipeSizeChange</param>
        /// <param name="standardBypass">standardBypass</param>        
        /// <param name="standardBypassComments">standardBypassComments</param>
        /// <param name="trafficControlDetails">trafficControlDetails</param>
        /// <param name="measurementType">measurementType</param>
        /// <param name="measuredFromMh">measuredFromMh</param>
        /// <param name="videoDoneFromMh">videoDoneFromMh</param>
        /// <param name="videoDoneToMh">videoDoneToMh</param>
        /// <param name="measurementTakenByM2">measurementTakenByM2</param>
        /// <param name="dropPipe">dropPipe</param>
        /// <param name="dropPipeInvertDepth">dropPipeInvertDepth</param>
        /// <param name="cappedLaterals">cappedLaterals</param>         
        /// <param name="lineWithID">lineWithID</param>        
        /// <param name="hydrantAddress">hydrantAddress</param>
        /// <param name="hydroWireWithin10FtOfInversionMH">hydroWireWithin10FtOfInversionMH</param>
        /// <param name="distanceToInversionMh">distanceToInversionMh</param> 
        /// <param name="surfaceGrade">surfaceGrade</param>
        /// <param name="hydroPulley">hydroPulley</param>
        /// <param name="fridgeCart">fridgeCart</param>
        /// <param name="twoPump">twoPump</param>
        /// <param name="sixBypass">sixBypass</param>
        /// <param name="scaffolding">scaffolding</param>
        /// <param name="winchExtension">winchExtension</param>
        /// <param name="extraGenerator">extraGenerator</param>
        /// <param name="greyCableExtension">greyCableExtension</param>
        /// <param name="easementMats">easementMats</param>
        /// <param name="rampRequired">rampRequired</param>        
        /// <param name="videoLength">videoLength</param>
        /// <param name="preFlushDate">preFlushDate</param>
        /// <param name="preVideoDate">preVideoDate</param>
        /// <param name="cameraSkid">cameraSkid</param>
        /// <param name="accessType">accessType</param>
        /// <param name="p1Completed">p1Completed</param>
        public void Update(int workId, string clientID, DateTime? proposedLiningDate, DateTime? deadlineLiningDate, DateTime? p1Date, DateTime? m1Date, DateTime? m2Date, DateTime? installDate, DateTime? finalVideoDate, bool issueIdentified, bool issueLFS, bool issueClient, bool issueSales, bool issueGivenToClient, bool issueResolved, bool issueInvestigation, int? CXIsRemoved, bool newRoboticPrepCompleted, DateTime? newRoboticPrepCompletedDate, string measurementTakenBy, string material, string trafficControl, string siteDetails, bool pipeSizeChange, bool standardBypass, string standardBypassComments, string trafficControlDetails, string measurementType, string measuredFromMh, string videoDoneFromMh, string videoDoneToMh, string measurementTakenByM2, bool dropPipe, string dropPipeInvertDepth, int? cappedLaterals, string lineWithID, string hydrantAddress, string hydroWireWithin10FtOfInversionMH, string distanceToInversionMh, string surfaceGrade, bool hydroPulley, bool fridgeCart, bool twoPump, bool sixBypass, bool scaffolding, bool winchExtension, bool extraGenerator, bool greyCableExtension, bool easementMats, bool rampRequired, string videoLength, DateTime? preFlushDate, DateTime? preVideoDate, bool cameraSkid, string accessType, bool p1Completed)
        {
            FullLengthLiningTDS.WorkDetailsRow row = GetRow(workId);

            if (clientID.Trim() != "") row.ClientID = clientID; else row.SetClientIDNull();
            if (proposedLiningDate.HasValue) row.ProposedLiningDate = (DateTime)proposedLiningDate; else row.SetProposedLiningDateNull();
            if (deadlineLiningDate.HasValue) row.DeadlineLiningDate = (DateTime)deadlineLiningDate; else row.SetDeadlineLiningDateNull();
            if (p1Date.HasValue) row.P1Date = (DateTime)p1Date; else row.SetP1DateNull();
            if (m1Date.HasValue) row.M1Date = (DateTime)m1Date; else row.SetM1DateNull();
            if (m2Date.HasValue) row.M2Date = (DateTime)m2Date; else row.SetM2DateNull();
            if (installDate.HasValue) row.InstallDate = (DateTime)installDate; else row.SetInstallDateNull();
            if (finalVideoDate.HasValue) row.FinalVideoDate = (DateTime)finalVideoDate; else row.SetFinalVideoDateNull();
            row.IssueIdentified = issueIdentified;
            row.IssueLFS = issueLFS;
            row.IssueClient = issueClient;
            row.IssueSales = issueSales;
            row.IssueGivenToClient = issueGivenToClient;
            row.IssueResolved = issueResolved;
            row.IssueInvestigation = issueInvestigation;
            if (CXIsRemoved.HasValue) row.CXIsRemoved = (int)CXIsRemoved; else row.SetCXIsRemovedNull();
            row.RoboticPrepCompleted = newRoboticPrepCompleted;
            if (newRoboticPrepCompletedDate.HasValue) row.RoboticPrepCompletedDate = (DateTime)newRoboticPrepCompletedDate; else row.SetRoboticPrepCompletedDateNull();
            row.P1Completed = p1Completed;

            // M1
            if (measurementTakenBy != "") row.MeasurementTakenBy = measurementTakenBy; else row.IsMeasurementTakenByNull();
            if (material != "") row.Material = material; else row.SetMaterialNull();
            if (trafficControl != "") row.TrafficControl = trafficControl; else row.SetTrafficControlNull();
            if (siteDetails != "") row.SiteDetails = siteDetails; else row.SetSiteDetailsNull();
            row.PipeSizeChange = pipeSizeChange;
            row.StandardBypass = standardBypass;
            if (standardBypassComments != "") row.StandardBypassComments = standardBypassComments; else row.SetStandardBypassCommentsNull();
            if (trafficControlDetails != "") row.TrafficControlDetails = trafficControlDetails; else row.SetTrafficControlDetailsNull();
            if (measurementType != "") row.MeasurementType = measurementType; else row.SetMeasurementTypeNull();
            if (measuredFromMh != "") row.MeasurementFromMH = measuredFromMh; else row.SetMeasurementFromMHNull();
            if (videoDoneFromMh != "") row.VideoDoneFromMH = videoDoneFromMh; else row.SetVideoDoneFromMHNull();
            if (videoDoneToMh != "") row.VideoDoneToMH = videoDoneToMh; else row.SetVideoDoneToMHNull();
            if (accessType.Trim() != "") row.AccessType = accessType; else row.SetAccessTypeNull();

            // M2
            if (measurementTakenByM2 != "") row.MeasurementTakenByM2 = measurementTakenByM2; else row.SetMeasurementTakenByM2Null();
            row.DropPipe = dropPipe;
            if (dropPipeInvertDepth != "") row.DropPipeInvertDepth = dropPipeInvertDepth; else row.SetDropPipeInvertDepthNull();
            if (cappedLaterals.HasValue) row.CappedLaterals = (int)cappedLaterals; else row.SetCappedLateralsNull();
            if (lineWithID != "") row.LineWithID = lineWithID; else row.SetLineWithIDNull();            
            if (hydrantAddress != "") row.HydrantAddress = hydrantAddress; else row.SetHydrantAddressNull();
            row.HydroWireWithin10FtOfInversionMH = hydroWireWithin10FtOfInversionMH; 
            if (distanceToInversionMh != "") row.DistanceToInversionMH = distanceToInversionMh; else row.SetDistanceToInversionMHNull();
            row.SurfaceGrade = surfaceGrade;
            row.HydroPulley = hydroPulley;
            row.FridgeCart = fridgeCart;
            row.TwoPump = twoPump;
            row.SixBypass = sixBypass;
            row.Scaffolding = scaffolding;
            row.WinchExtension = winchExtension;
            row.ExtraGenerator = extraGenerator;
            row.GreyCableExtension = greyCableExtension;
            row.EasementMats = easementMats;
            row.RampRequired = rampRequired;
            row.CameraSkid = cameraSkid;
            
            if (videoLength != "") row.VideoLength =  videoLength; else row.SetVideoLengthNull();

            // RA
            if (preFlushDate.HasValue) row.PreFlushDate = (DateTime)preFlushDate; else row.SetPreFlushDateNull();
            if (preVideoDate.HasValue) row.PreVideoDate = (DateTime)preVideoDate; else row.SetPreVideoDateNull();
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="p1Date">p1Date</param>
        /// <param name="p1Completed">p1Completed</param>
        /// <param name="installDate">installDate</param>
        /// <param name="finalVideoDate">finalVideoDate</param>
        public void Update(int workId, DateTime? p1Date, bool p1Completed, DateTime? installDate, DateTime? finalVideoDate)
        {
            FullLengthLiningTDS.WorkDetailsRow row = GetRow(workId);

            if (installDate.HasValue) row.InstallDate = (DateTime)installDate; else row.SetInstallDateNull();
            if (finalVideoDate.HasValue) row.FinalVideoDate = (DateTime)finalVideoDate; else row.SetFinalVideoDateNull();
            if (p1Date.HasValue) row.P1Date = (DateTime)p1Date; else row.SetP1DateNull();
            row.P1Completed = p1Completed;
        }



        /// <summary>
        /// UpdateWithWetOutInformation
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="clientID">clientID</param>
        /// <param name="proposedLiningDate">proposedLiningDate</param>
        /// <param name="deadlineLiningDate">deadlineLiningDate</param>
        /// <param name="p1Date">p1Date</param>
        /// <param name="m1Date">m1Date</param>
        /// <param name="m2Date">m2Date</param>
        /// <param name="installDate">installDate</param>
        /// <param name="finalVideoDate">finalVideoDate</param>
        /// <param name="issueIdentified">issueIdentified</param>
        /// <param name="issueLFS">issueLFS</param>    
        /// <param name="issueClient">issueClient</param> 
        /// <param name="issueSales">issueSales</param>    
        /// <param name="issueGivenToClient">issueGivenToClient</param>   
        /// <param name="issueResolved">issueResolved</param>   
        /// <param name="issueInvestigation">issueInvestigation</param> 
        /// <param name="CXIsRemoved">CXIsRemoved</param>
        /// <param name="newRoboticPrepCompleted">newRoboticPrepCompleted</param>
        /// <param name="newRoboticPrepCompletedDate">newRoboticPrepCompletedDate</param>
        /// <param name="measurementTakenBy">measurementTakenBy</param>
        /// <param name="material">material</param>
        /// <param name="trafficControl">trafficControl</param>
        /// <param name="siteDetails">siteDetails</param>
        /// <param name="pipeSizeChange">pipeSizeChange</param>
        /// <param name="standardBypass">standardBypass</param>        
        /// <param name="standardBypassComments">standardBypassComments</param>
        /// <param name="trafficControlDetails">trafficControlDetails</param>
        /// <param name="measurementType">measurementType</param>
        /// <param name="measuredFromMh">measuredFromMh</param>
        /// <param name="videoDoneFromMh">videoDoneFromMh</param>
        /// <param name="videoDoneToMh">videoDoneToMh</param>
        /// <param name="measurementTakenByM2">measurementTakenByM2</param>
        /// <param name="dropPipe">dropPipe</param>
        /// <param name="dropPipeInvertDepth">dropPipeInvertDepth</param>
        /// <param name="cappedLaterals">cappedLaterals</param>         
        /// <param name="lineWithID">lineWithID</param>        
        /// <param name="hydrantAddress">hydrantAddress</param>
        /// <param name="hydroWireWithin10FtOfInversionMH">hydroWireWithin10FtOfInversionMH</param>
        /// <param name="distanceToInversionMh">distanceToInversionMh</param> 
        /// <param name="surfaceGrade">surfaceGrade</param>
        /// <param name="hydroPulley">hydroPulley</param>
        /// <param name="fridgeCart">fridgeCart</param>
        /// <param name="twoPump">twoPump</param>
        /// <param name="sixBypass">sixBypass</param>
        /// <param name="scaffolding">scaffolding</param>
        /// <param name="winchExtension">winchExtension</param>
        /// <param name="extraGenerator">extraGenerator</param>
        /// <param name="greyCableExtension">greyCableExtension</param>
        /// <param name="easementMats">easementMats</param>
        /// <param name="rampRequired">rampRequired</param>        
        /// <param name="videoLength">videoLength</param>
        /// <param name="preFlushDate">preFlushDate</param>
        /// <param name="preVideoDate">preVideoDate</param>
        /// <param name="cameraSkid">cameraSkid</param>
        /// <param name="linerTube">linerTube</param>
        /// <param name="resinId">resinId</param>, 
        /// <param name="excessResin">excessResin</param>
        /// <param name="poundsDrums">poundsDrums</param>
        /// <param name="drumDiameter">drumDiameter</param> 
        /// <param name="hoistMaximumHeight">hoistMaximumHeight</param> 
        /// <param name="hoistMinimumHeight">hoistMinimumHeight</param> 
        /// <param name="downDropTubeLenght">downDropTubeLenght</param> 
        /// <param name="pumpHeightAboveGround">pumpHeightAboveGround</param> 
        /// <param name="tubeResinToFeltFactor">tubeResinToFeltFactor</param> 
        /// <param name="dateOfSheet">dateOfSheet</param> 
        /// <param name="employeeID">employeeID</param> 
        /// <param name="runDetails">runDetails</param> 
        /// <param name="runDetails2">runDetails2</param> 
        /// <param name="wetOutDate">wetOutDate</param>
        /// <param name="wetOutInstallDate">wetOutInstallDate</param> 
        /// <param name="inversionThickness">inversionThickness</param> 
        /// <param name="lengthToLine">lengthToLine</param> 
        /// <param name="plusExtra">plusExtra</param> 
        /// <param name="forTurnOffset">forTurnOffset</param> 
        /// <param name="lengthToWetOut">lengthToWetOut</param> 
        /// <param name="tubeMaxColdHead">tubeMaxColdHead</param> 
        /// <param name="tubeMaxColdHeadPsi">tubeMaxColdHeadPsi</param> 
        /// <param name="tubeMaxHotHead">tubeMaxHotHead</param> 
        /// <param name="tubeMaxHotHeadPsi">tubeMaxHotHeadPsi</param> 
        /// <param name="tubeIdealHead"></param> tubeIdealHead
        /// <param name="tubeIdealHeadPsi">tubeIdealHeadPsi</param>
        /// <param name="netResinForTube">netResinForTube</param>
        /// <param name="netResinForTubeUsgals">netResinForTubeUsgals</param>
        /// <param name="netResinForTubeDrumsIns">netResinForTubeDrumsIns</param>
        /// <param name="netResinForTubeLbsFt">netResinForTubeLbsFt</param>
        /// <param name="netResinForTubeUsgFt">netResinForTubeUsgFt</param>
        /// <param name="extraResinForMix">extraResinForMix</param>
        /// <param name="extraLbsForMix">extraLbsForMix</param>
        /// <param name="totalMixQuantity">totalMixQuantity</param>
        /// <param name="totalMixQuantityUsgals">totalMixQuantityUsgals</param>
        /// <param name="totalMixQuantityDrumsIns">totalMixQuantityDrumsIns</param>
        /// <param name="inversionType">inversionType</param>
        /// <param name="depthOfInversionMH">depthOfInversionMH</param>
        /// <param name="tubeForColumn">tubeForColumn</param>
        /// <param name="tubeForStartDry">tubeForStartDry</param>
        /// <param name="totalTube">totalTube</param>
        /// <param name="dropTubeConnects">dropTubeConnects</param>
        /// <param name="allowsHeadTo">allowsHeadTo</param>
        /// <param name="rollerGap">rollerGap</param>
        /// <param name="heightNeeded">heightNeeded</param>
        /// <param name="available">available</param>
        /// <param name="hoistHeight">hoistHeight</param>
        /// <param name="commentsCipp">commentsCipp</param>
        /// <param name="resinsLabel">resinsLabel</param>
        /// <param name="drumContainsLabel">drumContainsLabel</param>
        /// <param name="linerTubeLabel">linerTubeLabel</param>
        /// <param name="forLbDrumsLabel">forLbDrumsLabel</param>
        /// <param name="netResinLabel">netResinLabel</param>
        /// <param name="catalystLabel">catalystLabel</param> 
        /// 
        /// <param name="inversionComment">inversionComment</param>
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
        /// <param name="cookAtT2">cookAtT2</param>
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
        /// <param name="inversionLinerTubeLabel">inversionLinerTubeLabel</param>
        /// <param name="headsIdealLabel">headsIdealLabel</param>
        /// <param name="pumpingAndCirculationLabel">pumpingAndCirculationLabel</param>
        /// <param name="accessType">accessType</param>
        /// <param name="p1Completed">p1Completed</param>
        public void UpdateWithWetOutInformation(int workId, string clientID, DateTime? proposedLiningDate, DateTime? deadlineLiningDate, DateTime? p1Date, DateTime? m1Date, DateTime? m2Date, DateTime? installDate, DateTime? finalVideoDate, bool issueIdentified, bool issueLFS, bool issueClient, bool issueSales, bool issueGivenToClient, bool issueResolved, bool issueInvestigation, int? CXIsRemoved, bool newRoboticPrepCompleted, DateTime? newRoboticPrepCompletedDate, string measurementTakenBy, string material, string trafficControl, string siteDetails, bool pipeSizeChange, bool standardBypass, string standardBypassComments, string trafficControlDetails, string measurementType, string measuredFromMh, string videoDoneFromMh, string videoDoneToMh, string measurementTakenByM2, bool dropPipe, string dropPipeInvertDepth, int? cappedLaterals, string lineWithID, string hydrantAddress, string hydroWireWithin10FtOfInversionMH, string distanceToInversionMh, string surfaceGrade, bool hydroPulley, bool fridgeCart, bool twoPump, bool sixBypass, bool scaffolding, bool winchExtension, bool extraGenerator, bool greyCableExtension, bool easementMats, bool rampRequired, string videoLength, DateTime? preFlushDate, DateTime? preVideoDate, bool cameraSkid, string linerTube, int resinId, decimal excessResin, string poundsDrums, decimal drumDiameter, decimal hoistMaximumHeight, decimal hoistMinimumHeight, decimal downDropTubeLenght, decimal pumpHeightAboveGround, int tubeResinToFeltFactor, DateTime dateOfSheet, int employeeID, string runDetails, string runDetails2, DateTime wetOutDate, DateTime? wetOutInstallDate, string inversionThickness, decimal lengthToLine, decimal plusExtra, decimal forTurnOffset, decimal lengthToWetOut, decimal tubeMaxColdHead, decimal tubeMaxColdHeadPsi, decimal tubeMaxHotHead, decimal tubeMaxHotHeadPsi, decimal tubeIdealHead, decimal tubeIdealHeadPsi, decimal netResinForTube, decimal netResinForTubeUsgals, string netResinForTubeDrumsIns, decimal netResinForTubeLbsFt, decimal netResinForTubeUsgFt, int extraResinForMix, decimal extraLbsForMix, decimal totalMixQuantity, decimal totalMixQuantityUsgals, string totalMixQuantityDrumsIns, string inversionType, decimal depthOfInversionMH, decimal tubeForColumn, decimal tubeForStartDry, decimal totalTube, string dropTubeConnects, decimal allowsHeadTo, decimal rollerGap, decimal heightNeeded, string available, string hoistHeight, string commentsCipp, string resinsLabel, string drumContainsLabel, string linerTubeLabel, string forLbDrumsLabel, string netResinLabel, string catalystLabel, string inversionComment, string pipeType, string pipeCondition, string groundMoisture, decimal boilerSize, decimal pumpTotalCapacity, decimal layFlatSize, decimal layFlatQuantityTotal, decimal waterStartTemp, decimal temp1, decimal holdAtT1, decimal tempT2, decimal cookAtT2, decimal coolDownFor, decimal coolToTemp, decimal dropInPipeRun, decimal pipeSlopOf, decimal f45F120, decimal hold, decimal f120F185, decimal cookTime, decimal coolTime, decimal aproxTotal, decimal waterChangesPerHour, decimal returnWaterVelocity, decimal layflatBackPressure, decimal pumpLiftAtIdealHead, decimal waterToFillLinerColumn, decimal waterPerFit, string installationResults, string inversionLinerTubeLabel, string headsIdealLabel, string pumpingAndCirculationLabel, string accessType, bool p1Completed)
        {
            FullLengthLiningTDS.WorkDetailsRow row = GetRow(workId);

            if (clientID.Trim() != "") row.ClientID = clientID; else row.SetClientIDNull();
            if (proposedLiningDate.HasValue) row.ProposedLiningDate = (DateTime)proposedLiningDate; else row.SetProposedLiningDateNull();
            if (deadlineLiningDate.HasValue) row.DeadlineLiningDate = (DateTime)deadlineLiningDate; else row.SetDeadlineLiningDateNull();
            if (p1Date.HasValue) row.P1Date = (DateTime)p1Date; else row.SetP1DateNull();
            if (m1Date.HasValue) row.M1Date = (DateTime)m1Date; else row.SetM1DateNull();
            if (m2Date.HasValue) row.M2Date = (DateTime)m2Date; else row.SetM2DateNull();
            if (installDate.HasValue) row.InstallDate = (DateTime)installDate; else row.SetInstallDateNull();
            if (finalVideoDate.HasValue) row.FinalVideoDate = (DateTime)finalVideoDate; else row.SetFinalVideoDateNull();
            row.IssueIdentified = issueIdentified;
            row.IssueLFS = issueLFS;
            row.IssueClient = issueClient;
            row.IssueSales = issueSales;
            row.IssueGivenToClient = issueGivenToClient;
            row.IssueResolved = issueResolved;
            row.IssueInvestigation = issueInvestigation;
            if (CXIsRemoved.HasValue) row.CXIsRemoved = (int)CXIsRemoved; else row.SetCXIsRemovedNull();
            row.RoboticPrepCompleted = newRoboticPrepCompleted;
            if (newRoboticPrepCompletedDate.HasValue) row.RoboticPrepCompletedDate = (DateTime)newRoboticPrepCompletedDate; else row.SetRoboticPrepCompletedDateNull();
            row.P1Completed = p1Completed;

            // M1
            if (measurementTakenBy != "") row.MeasurementTakenBy = measurementTakenBy; else row.IsMeasurementTakenByNull();
            if (material != "") row.Material = material; else row.SetMaterialNull();
            if (trafficControl != "") row.TrafficControl = trafficControl; else row.SetTrafficControlNull();
            if (siteDetails != "") row.SiteDetails = siteDetails; else row.SetSiteDetailsNull();
            row.PipeSizeChange = pipeSizeChange;
            row.StandardBypass = standardBypass;
            if (standardBypassComments != "") row.StandardBypassComments = standardBypassComments; else row.SetStandardBypassCommentsNull();
            if (trafficControlDetails != "") row.TrafficControlDetails = trafficControlDetails; else row.SetTrafficControlDetailsNull();
            if (measurementType != "") row.MeasurementType = measurementType; else row.SetMeasurementTypeNull();
            if (measuredFromMh != "") row.MeasurementFromMH = measuredFromMh; else row.SetMeasurementFromMHNull();
            if (videoDoneFromMh != "") row.VideoDoneFromMH = videoDoneFromMh; else row.SetVideoDoneFromMHNull();
            if (videoDoneToMh != "") row.VideoDoneToMH = videoDoneToMh; else row.SetVideoDoneToMHNull();
            if (accessType.Trim() != "") row.AccessType = accessType; else row.SetAccessTypeNull();

            // M2
            if (measurementTakenByM2 != "") row.MeasurementTakenByM2 = measurementTakenByM2; else row.SetMeasurementTakenByM2Null();
            row.DropPipe = dropPipe;
            if (dropPipeInvertDepth != "") row.DropPipeInvertDepth = dropPipeInvertDepth; else row.SetDropPipeInvertDepthNull();
            if (cappedLaterals.HasValue) row.CappedLaterals = (int)cappedLaterals; else row.SetCappedLateralsNull();
            if (lineWithID != "") row.LineWithID = lineWithID; else row.SetLineWithIDNull();            
            if (hydrantAddress != "") row.HydrantAddress = hydrantAddress; else row.SetHydrantAddressNull();
            row.HydroWireWithin10FtOfInversionMH = hydroWireWithin10FtOfInversionMH; 
            if (distanceToInversionMh != "") row.DistanceToInversionMH = distanceToInversionMh; else row.SetDistanceToInversionMHNull();
            row.SurfaceGrade = surfaceGrade;
            row.HydroPulley = hydroPulley;
            row.FridgeCart = fridgeCart;
            row.TwoPump = twoPump;
            row.SixBypass = sixBypass;
            row.Scaffolding = scaffolding;
            row.WinchExtension = winchExtension;
            row.ExtraGenerator = extraGenerator;
            row.GreyCableExtension = greyCableExtension;
            row.EasementMats = easementMats;
            row.RampRequired = rampRequired;
            row.CameraSkid = cameraSkid;
            
            if (videoLength != "") row.VideoLength =  videoLength; else row.SetVideoLengthNull();

            // RA
            if (preFlushDate.HasValue) row.PreFlushDate = (DateTime)preFlushDate; else row.SetPreFlushDateNull();
            if (preVideoDate.HasValue) row.PreVideoDate = (DateTime)preVideoDate; else row.SetPreVideoDateNull();

            // Wet Out Data
            row.LinerTube = linerTube;
            row.ResinID = resinId;
            row.ExcessResin = excessResin;
            row.PoundsDrums = poundsDrums;
            row.DrumDiameter = drumDiameter;
            row.HoistMaximumHeight = hoistMaximumHeight;
            row.HoistMinimumHeight = hoistMinimumHeight;
            row.DownDropTubeLenght = downDropTubeLenght;
            row.PumpHeightAboveGround = pumpHeightAboveGround;
            row.TubeResinToFeltFactor = tubeResinToFeltFactor;
            row.DateOfSheet = dateOfSheet;
            row.EmployeeID = employeeID;
            row.RunDetails = runDetails;
            row.RunDetails2 = runDetails2;
            row.WetOutDate = wetOutDate;
            if (wetOutInstallDate.HasValue) row.WetOutInstallDate = (DateTime)wetOutInstallDate; else row.SetWetOutInstallDateNull();            
            row.Thickness = inversionThickness;
            row.LengthToLine = lengthToLine;
            row.PlusExtra = plusExtra;
            row.ForTurnOffset = forTurnOffset;
            row.LengthToWetOut = lengthToWetOut;
            row.TubeMaxColdHead = tubeMaxColdHead;
            row.TubeMaxColdHeadPsi = tubeMaxColdHeadPsi;
            row.TubeMaxHotHead = tubeMaxHotHead;
            row.TubeMaxHotHeadPsi = tubeMaxHotHeadPsi;
            row.TubeIdealHead = tubeIdealHead;
            row.TubeIdealHeadPsi = tubeIdealHeadPsi;
            row.NetResinForTube = netResinForTube;
            row.NetResinForTubeUsgals = netResinForTubeUsgals;
            row.NetResinForTubeDrumsIns = netResinForTubeDrumsIns;
            row.NetResinForTubeLbsFt = netResinForTubeLbsFt;
            row.NetResinForTubeUsgFt = netResinForTubeUsgFt;
            row.ExtraResinForMix = extraResinForMix;
            row.ExtraLbsForMix = extraLbsForMix;
            row.TotalMixQuantity = totalMixQuantity;
            row.TotalMixQuantityUsgals = totalMixQuantityUsgals;            
            row.TotalMixQuantityDrumsIns = totalMixQuantityDrumsIns;
            row.InversionType = inversionType;
            row.DepthOfInversionMH = depthOfInversionMH;
            row.TubeForColumn= tubeForColumn;
            row.TubeForStartDry = tubeForStartDry;
            row.TotalTube = totalTube;
            row.DropTubeConnects = dropTubeConnects;
            row.AllowsHeadTo = allowsHeadTo;
            row.RollerGap = rollerGap;
            row.HeightNeeded = heightNeeded;
            row.Available = available;
            row.HoistHeight = hoistHeight;
            row.CommentsCipp = commentsCipp;
            row.ResinsLabel = resinsLabel;
            row.DrumContainsLabel = drumContainsLabel;
            row.LinerTubeLabel = linerTubeLabel;
            row.ForLbDrumsLabel = forLbDrumsLabel;
            row.NetResinLabel = netResinLabel;
            row.CatalystLabel = catalystLabel;

            // InversionData
            if (inversionComment != "")row.InversionComment = inversionComment;else row.SetInversionCommentNull();
            row.PipeType = pipeType;
            row.PipeCondition = pipeCondition;
            row.GroundMoisture = groundMoisture;
            row.BoilerSize = boilerSize;
            row.PumpTotalCapacity = pumpTotalCapacity;
            row.LayFlatSize = layFlatSize;
            row.LayFlatQuantityTotal = layFlatQuantityTotal;
            row.WaterStartTemp = waterStartTemp;
            row.Temp1 = temp1;
            row.HoldAtT1 = holdAtT1;
            row.TempT2 = tempT2;
            row.CookAtT2 = cookAtT2;
            row.CoolDownFor = coolDownFor;
            row.CoolToTemp = coolToTemp;
            row.DropInPipeRun = dropInPipeRun;
            row.PipeSlopOf = pipeSlopOf;
            row.F45F120 = f45F120;
            row.Hold = hold;
            row.F120F185 = f120F185;
            row.CookTime = cookTime;            
            row.CoolTime = coolTime;
            row.AproxTotal = aproxTotal;
            row.WaterChangesPerHour = waterChangesPerHour;
            row.ReturnWaterVelocity = returnWaterVelocity;
            row.LayflatBackPressure = layflatBackPressure;
            row.PumpLiftAtIdealHead = pumpLiftAtIdealHead;
            row.WaterToFillLinerColumn = waterToFillLinerColumn;
            row.WaterPerFit = waterPerFit;
            if (installationResults != "") row.InstallationResults = installationResults; else row.SetInstallationResultsNull();
            row.InversionLinerTubeLabel = inversionLinerTubeLabel;
            row.HeadsIdealLabel = headsIdealLabel;
            row.PumpingAndCirculationLabel = pumpingAndCirculationLabel;
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="sectionAssetId">sectionAssetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="includeWetOutInformation">includeWetOutInformation</param>
        /// <param name="includeInversionInformation">includeInversionInformation</param>
        public void Save(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int projectId, int sectionAssetId, int companyId, bool includeWetOutInformation, bool includeInversionInformation)
        {
            FullLengthLiningTDS fullLengthLiningChanges = (FullLengthLiningTDS)Data.GetChanges();

            if (fullLengthLiningChanges.WorkDetails.Rows.Count > 0)
            {
                FullLengthLiningWorkDetailsGateway fullLengthLiningWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway(fullLengthLiningChanges);

                // Update sections
                foreach (FullLengthLiningTDS.WorkDetailsRow row in (FullLengthLiningTDS.WorkDetailsDataTable)fullLengthLiningChanges.WorkDetails)
                {
                    // Unchanged values
                    int workId = row.WorkID;

                    // Original values
                    string originalClientId = fullLengthLiningWorkDetailsGateway.GetClientIdOriginal(workId);
                    DateTime? originalProposedLiningDate = fullLengthLiningWorkDetailsGateway.GetProposedLiningDateOriginal(workId);
                    DateTime? originalDeadlineLiningDate = fullLengthLiningWorkDetailsGateway.GetDeadlineLiningDateOriginal(workId);
                    DateTime? originalP1Date = fullLengthLiningWorkDetailsGateway.GetP1DateOriginal(workId);
                    DateTime? originalM1Date = fullLengthLiningWorkDetailsGateway.GetM1DateOriginal(workId);
                    DateTime? originalM2Date = fullLengthLiningWorkDetailsGateway.GetM2DateOriginal(workId);
                    DateTime? originalInstallDate = fullLengthLiningWorkDetailsGateway.GetInstallDateOriginal(workId);
                    DateTime? originalFinalVideoDate = fullLengthLiningWorkDetailsGateway.GetFinalVideoDateOriginal(workId);
                    bool originalIssueIdentified = fullLengthLiningWorkDetailsGateway.GetIssueIdentifiedOriginal(workId);
                    bool originalIssueLFS = fullLengthLiningWorkDetailsGateway.GetIssueLFSOriginal(workId);
                    bool originalIssueClient = fullLengthLiningWorkDetailsGateway.GetIssueClientOriginal(workId);
                    bool originalIssueSales = fullLengthLiningWorkDetailsGateway.GetIssueSalesOriginal(workId);
                    bool originalIssueGivenToClient = fullLengthLiningWorkDetailsGateway.GetIssueGivenToClientOriginal(workId);
                    bool originalIssueResolved = fullLengthLiningWorkDetailsGateway.GetIssueResolvedOriginal(workId);
                    bool originalIssueInvestigation = fullLengthLiningWorkDetailsGateway.GetIssueInvestigationOriginal(workId);
                    int? originalCxisRemoved = fullLengthLiningWorkDetailsGateway.GetCxisRemovedOriginal(workId);
                    bool originalRoboticPrepCompleted = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompletedOriginal(workId);
                    DateTime? originalRoboticPrepCompletedDate = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompletedDateOriginal(workId);
                    DateTime? originalPreFlushDate = fullLengthLiningWorkDetailsGateway.GetPreFlushDateOriginal(workId);
                    DateTime? originalPreVideoDate = fullLengthLiningWorkDetailsGateway.GetPreVideoDateOriginal(workId);
                    int originalRaWorkId = fullLengthLiningWorkDetailsGateway.GetRaWorkIdOriginal(workId);
                    bool originalP1Completed = fullLengthLiningWorkDetailsGateway.GetP1CompletedOriginal(workId);
                    
                    // M1 data
                    string originalMeasurementTakenBy = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenByOriginal(workId);
                    string originalMaterial = fullLengthLiningWorkDetailsGateway.GetMaterialOriginal(workId);
                    string originalTrafficControl = fullLengthLiningWorkDetailsGateway.GetTrafficControlOriginal(workId);
                    string originalSiteDetails = fullLengthLiningWorkDetailsGateway.GetSiteDetailsOriginal(workId);
                    bool originalPipeSizeChange = fullLengthLiningWorkDetailsGateway.GetPipeSizeChangeOriginal(workId);
                    bool originalStandardBypass = fullLengthLiningWorkDetailsGateway.GetStandardBypassOriginal(workId);
                    string originalStandardBypassComments = fullLengthLiningWorkDetailsGateway.GetStandardBypassCommentsOriginal(workId);
                    string originalTrafficControlDetails = fullLengthLiningWorkDetailsGateway.GetTrafficControlDetailsOriginal(workId);
                    string originalMeasurementType = fullLengthLiningWorkDetailsGateway.GetMeasurementTypeOriginal(workId);
                    string originalMeasurementFromMh = fullLengthLiningWorkDetailsGateway.GetMeasurementFromMhOriginal(workId);
                    string originalVideoDoneFromMh = fullLengthLiningWorkDetailsGateway.GetVideoDoneFromMhOriginal(workId);
                    string originalVideoDoneToMh = fullLengthLiningWorkDetailsGateway.GetVideoDoneToMhOriginal(workId);
                    string originalAccessType = fullLengthLiningWorkDetailsGateway.GetAccessTypeOriginal(workId);

                    // M2 data
                    string originalMeasurementTakenByM2 = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenByM2Original(workId);
                    bool originalDropPipe = fullLengthLiningWorkDetailsGateway.GetDropPipeOriginal(workId);
                    string originalDropPipeInvertDepth = fullLengthLiningWorkDetailsGateway.GetDropPipeInvertDepthOriginal(workId);
                    int? originalCappedLaterals = fullLengthLiningWorkDetailsGateway.GetCappedLateralsOriginal(workId);
                    string originalLineWithId = fullLengthLiningWorkDetailsGateway.GetLineWithIdOriginal(workId);                    
                    string originalHydrantAddress = fullLengthLiningWorkDetailsGateway.GetHydrantAddressOriginal(workId);
                    string originalHydroWireWithin10FtOfInversionMH = fullLengthLiningWorkDetailsGateway.GetHydroWiredWithin10FtOfInversionMHOriginal(workId);
                    string originalDistanceToInversionMh = fullLengthLiningWorkDetailsGateway.GetDistanceToInversionMhOriginal(workId);
                    string originalSurfaceGrade = fullLengthLiningWorkDetailsGateway.GetSurfaceGradeOriginal(workId);
                    bool originalHydroPulley = fullLengthLiningWorkDetailsGateway.GetHydroPulleyOriginal(workId);
                    bool originalFridgeCart = fullLengthLiningWorkDetailsGateway.GetFridgeCartOriginal(workId);
                    bool originalTwoPump = fullLengthLiningWorkDetailsGateway.GetTwoPumpOriginal(workId);
                    bool originalSixBypass = fullLengthLiningWorkDetailsGateway.GetSixBypassOriginal(workId);
                    bool originalScaffolding = fullLengthLiningWorkDetailsGateway.GetScaffoldingOriginal(workId);
                    bool originalWinchExtension = fullLengthLiningWorkDetailsGateway.GetWinchExtensionOriginal(workId);
                    bool originalExtraGenerator = fullLengthLiningWorkDetailsGateway.GetExtraGeneratorOriginal(workId);
                    bool originalGreyCableExtension = fullLengthLiningWorkDetailsGateway.GetGreyCableExtensionOriginal(workId);
                    bool originalEasementMats = fullLengthLiningWorkDetailsGateway.GetEasementMatsOriginal(workId);
                    bool originalRampRequired = fullLengthLiningWorkDetailsGateway.GetRampRequiredOriginal(workId);
                    string originalVideoLength = fullLengthLiningWorkDetailsGateway.GetVideoLengthOriginal(workId);
                    bool originalCameraSkid = fullLengthLiningWorkDetailsGateway.GetCameraSkidOriginal(workId);

                    // Comments
                    string originalComments = fullLengthLiningWorkDetailsGateway.GetCommentsOriginal(workId);

                    // New variables
                    string newClientId = fullLengthLiningWorkDetailsGateway.GetClientId(workId);
                    DateTime? newProposedLiningDate = fullLengthLiningWorkDetailsGateway.GetProposedLiningDate(workId);
                    DateTime? newDeadlineLiningDate = fullLengthLiningWorkDetailsGateway.GetDeadlineLiningDate(workId);
                    DateTime? newP1Date = fullLengthLiningWorkDetailsGateway.GetP1Date(workId);
                    DateTime? newM1Date = fullLengthLiningWorkDetailsGateway.GetM1Date(workId);
                    DateTime? newM2Date = fullLengthLiningWorkDetailsGateway.GetM2Date(workId);
                    DateTime? newInstallDate = fullLengthLiningWorkDetailsGateway.GetInstallDate(workId);
                    DateTime? newFinalVideoDate = fullLengthLiningWorkDetailsGateway.GetFinalVideoDate(workId);
                    bool newIssueIdentified = fullLengthLiningWorkDetailsGateway.GetIssueIdentified(workId);
                    bool newIssueLFS = fullLengthLiningWorkDetailsGateway.GetIssueLFS(workId);
                    bool newIssueClient = fullLengthLiningWorkDetailsGateway.GetIssueClient(workId);
                    bool newIssueSales = fullLengthLiningWorkDetailsGateway.GetIssueSales(workId);
                    bool newIssueGivenToClient = fullLengthLiningWorkDetailsGateway.GetIssueGivenToClient(workId);
                    bool newIssueResolved = fullLengthLiningWorkDetailsGateway.GetIssueResolved(workId);
                    bool newIssueInvestigation = fullLengthLiningWorkDetailsGateway.GetIssueInvestigation(workId);
                    int? newCxisRemoved = fullLengthLiningWorkDetailsGateway.GetCxisRemoved(workId);
                    bool newRoboticPrepCompleted = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompleted(workId);
                    DateTime? newRoboticPrepCompletedDate = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompletedDate(workId);
                    DateTime? newPreFlushDate = fullLengthLiningWorkDetailsGateway.GetPreFlushDate(workId);
                    DateTime? newPreVideoDate = fullLengthLiningWorkDetailsGateway.GetPreVideoDate(workId);
                    int newRaWorkId = fullLengthLiningWorkDetailsGateway.GetRaWorkId(workId);
                    bool newP1Completed = fullLengthLiningWorkDetailsGateway.GetP1Completed(workId);

                    // M1
                    string newMeasurementTakenBy = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenBy(workId);
                    string newMaterial = fullLengthLiningWorkDetailsGateway.GetMaterial(workId);
                    string newTrafficControl = fullLengthLiningWorkDetailsGateway.GetTrafficControl(workId);
                    string newSiteDetails = fullLengthLiningWorkDetailsGateway.GetSiteDetails(workId);
                    bool newPipeSizeChange = fullLengthLiningWorkDetailsGateway.GetPipeSizeChange(workId);
                    bool newStandardBypass = fullLengthLiningWorkDetailsGateway.GetStandardBypass(workId);
                    string newStandardBypassComments = fullLengthLiningWorkDetailsGateway.GetStandardBypassComments(workId);
                    string newTrafficControlDetails = fullLengthLiningWorkDetailsGateway.GetTrafficControlDetails(workId);
                    string newMeasurementType = fullLengthLiningWorkDetailsGateway.GetMeasurementType(workId);
                    string newMeasurementFromMh = fullLengthLiningWorkDetailsGateway.GetMeasurementFromMh(workId);
                    string newVideoDoneFromMh = fullLengthLiningWorkDetailsGateway.GetVideoDoneFromMh(workId);
                    string newVideoDoneToMh = fullLengthLiningWorkDetailsGateway.GetVideoDoneToMh(workId);
                    string newAccessType = fullLengthLiningWorkDetailsGateway.GetAccessType(workId);

                    // M2
                    string newMeasurementTakenByM2 = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenByM2(workId);
                    bool newDropPipe = fullLengthLiningWorkDetailsGateway.GetDropPipe(workId);
                    string newDropPipeInvertDepth = fullLengthLiningWorkDetailsGateway.GetDropPipeInvertDepth(workId);
                    int? newCappedLaterals = fullLengthLiningWorkDetailsGateway.GetCappedLaterals(workId);
                    string newLineWithId = fullLengthLiningWorkDetailsGateway.GetLineWithId(workId);
                    string newHydrantAddress = fullLengthLiningWorkDetailsGateway.GetHydrantAddress(workId);
                    string newHydroWireWithin10FtOfInversionMH = fullLengthLiningWorkDetailsGateway.GetHydroWiredWithin10FtOfInversionMH(workId);
                    string newDistanceToInversionMh = fullLengthLiningWorkDetailsGateway.GetDistanceToInversionMh(workId);
                    string newSurfaceGrade = fullLengthLiningWorkDetailsGateway.GetSurfaceGrade(workId);
                    bool newHydroPulley = fullLengthLiningWorkDetailsGateway.GetHydroPulley(workId);
                    bool newFridgeCart = fullLengthLiningWorkDetailsGateway.GetFridgeCart(workId);
                    bool newTwoPump = fullLengthLiningWorkDetailsGateway.GetTwoPump(workId);
                    bool newSixBypass = fullLengthLiningWorkDetailsGateway.GetSixBypass(workId);
                    bool newScaffolding = fullLengthLiningWorkDetailsGateway.GetScaffolding(workId);
                    bool newWinchExtension = fullLengthLiningWorkDetailsGateway.GetWinchExtension(workId);
                    bool newExtraGenerator = fullLengthLiningWorkDetailsGateway.GetExtraGenerator(workId);
                    bool newGreyCableExtension = fullLengthLiningWorkDetailsGateway.GetGreyCableExtension(workId);
                    bool newEasementMats = fullLengthLiningWorkDetailsGateway.GetEasementMats(workId);
                    bool newRampRequired = fullLengthLiningWorkDetailsGateway.GetRampRequired(workId);
                    string newVideoLength = fullLengthLiningWorkDetailsGateway.GetVideoLength(workId);
                    bool newCameraSkid = fullLengthLiningWorkDetailsGateway.GetCameraSkid(workId);

                    // comments
                    string newComments = fullLengthLiningWorkDetailsGateway.GetComments(workId);

                    // Update work
                    UpdateWork(countryId, provinceId, countyId, cityId, workId, originalClientId, originalProposedLiningDate, originalDeadlineLiningDate, originalP1Date, originalM1Date, originalM2Date, originalInstallDate, originalFinalVideoDate, originalIssueIdentified, originalIssueLFS, originalIssueClient, originalIssueSales, originalIssueGivenToClient, originalIssueResolved, originalIssueInvestigation, originalCxisRemoved, originalRoboticPrepCompleted, originalRoboticPrepCompletedDate, originalMeasurementTakenBy, originalTrafficControl, originalSiteDetails, originalPipeSizeChange, originalStandardBypass, originalStandardBypassComments, originalTrafficControlDetails, originalMeasurementType, originalMeasurementFromMh, originalVideoDoneFromMh, originalVideoDoneToMh, originalMeasurementTakenByM2, originalDropPipe, originalDropPipeInvertDepth, originalCappedLaterals, originalLineWithId, originalHydrantAddress, originalHydroWireWithin10FtOfInversionMH, originalDistanceToInversionMh, originalSurfaceGrade, originalHydroPulley, originalFridgeCart, originalTwoPump, originalSixBypass, originalScaffolding, originalWinchExtension, originalExtraGenerator, originalGreyCableExtension, originalEasementMats, originalRampRequired, originalVideoLength, originalComments, originalPreFlushDate, originalPreVideoDate, originalRaWorkId, false, companyId, originalMaterial, originalCameraSkid, originalAccessType, originalP1Completed, newClientId, newProposedLiningDate, newDeadlineLiningDate, newP1Date, newM1Date, newM2Date, newInstallDate, newFinalVideoDate, newIssueIdentified, newIssueLFS, newIssueClient, newIssueSales, newIssueGivenToClient, newIssueResolved, newIssueInvestigation, newCxisRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newMeasurementTakenBy, newMaterial, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardBypass, newStandardBypassComments, newTrafficControlDetails, newMeasurementType, newMeasurementFromMh, newVideoDoneFromMh, newVideoDoneToMh, newMeasurementTakenByM2, newDropPipe, newDropPipeInvertDepth, newCappedLaterals, newLineWithId, newHydrantAddress, newHydroWireWithin10FtOfInversionMH, newDistanceToInversionMh, newSurfaceGrade, newHydroPulley, newFridgeCart, newTwoPump, newSixBypass, newScaffolding, newWinchExtension, newExtraGenerator, newGreyCableExtension, newEasementMats, newRampRequired, newVideoLength, newComments, newPreFlushDate, newPreVideoDate, newRaWorkId, sectionAssetId, false, companyId, newCameraSkid, newAccessType, newP1Completed);

                    // For wet out information
                    if (includeWetOutInformation)
                    {
                        // Update data
                        WorkFullLengthLiningWetOutGateway workFullLengthLiningWetOutGateway = new WorkFullLengthLiningWetOutGateway();
                        workFullLengthLiningWetOutGateway.LoadByWorkId(workId, companyId);                              

                        // ... Verify if work has wet out data information
                        if (workFullLengthLiningWetOutGateway.Table.Rows.Count > 0)
                        {
                            // Wet Out data original values
                            string originalLinerTube = fullLengthLiningWorkDetailsGateway.GetLinerTubeOriginal(workId);
                            int originalResinID = fullLengthLiningWorkDetailsGateway.GetResinIdOriginal(workId);
                            decimal originalExcessResin = fullLengthLiningWorkDetailsGateway.GetExcessResinOriginal(workId);
                            string originalPoundsDrums = fullLengthLiningWorkDetailsGateway.GetPoundsDrumsOriginal(workId);
                            decimal originalDrumDiameter = fullLengthLiningWorkDetailsGateway.GetDrumDiameterOriginal(workId);
                            decimal originalHoistMaximumHeight = fullLengthLiningWorkDetailsGateway.GetHoistMaximumHeightOriginal(workId);
                            decimal originalHoistMinimumHeight = fullLengthLiningWorkDetailsGateway.GetHoistMinimumHeightOriginal(workId);
                            decimal originalDownDropTubeLenght = fullLengthLiningWorkDetailsGateway.GetDownDropTubeLenghtOriginal(workId);
                            decimal originalPumpHeightAboveGround = fullLengthLiningWorkDetailsGateway.GetPumpHeightAboveGroundOriginal(workId);
                            int originalTubeResinToFeltFactor = fullLengthLiningWorkDetailsGateway.GetTubeResinToFeltFactorOriginal(workId);
                            DateTime originalDateOfSheet = fullLengthLiningWorkDetailsGateway.GetDateOfSheetOriginal(workId);
                            int originalEmployeeID = fullLengthLiningWorkDetailsGateway.GetEmployeeIdOriginal(workId);
                            string originalRunDetails = fullLengthLiningWorkDetailsGateway.GetRunDetailsOriginal(workId);
                            string originalRunDetails2 = fullLengthLiningWorkDetailsGateway.GetRunDetails2Original(workId);
                            DateTime originalWetOutDate = fullLengthLiningWorkDetailsGateway.GetWetOutDateOriginal(workId);
                            DateTime? originalWetOutInstallDate = fullLengthLiningWorkDetailsGateway.GetWetOutInstallDateOriginal(workId);
                            string originalThickness = fullLengthLiningWorkDetailsGateway.GetInversionThicknessOriginal(workId);
                            decimal originalLengthToLine = fullLengthLiningWorkDetailsGateway.GetLengthToLineOriginal(workId);
                            decimal originalPlusExtra = fullLengthLiningWorkDetailsGateway.GetPlusExtraOriginal(workId);
                            decimal originalForTurnOffset = fullLengthLiningWorkDetailsGateway.GetForTurnOffsetOriginal(workId);
                            decimal originalLengthToWetOut = fullLengthLiningWorkDetailsGateway.GetLengthToWetOutOriginal(workId);
                            decimal originalTubeMaxColdHead = fullLengthLiningWorkDetailsGateway.GetTubeMaxColdHeadOriginal(workId);
                            decimal originalTubeMaxColdHeadPsi = fullLengthLiningWorkDetailsGateway.GetTubeMaxColdHeadPsiOriginal(workId);
                            decimal originalTubeMaxHotHead = fullLengthLiningWorkDetailsGateway.GetTubeMaxHotHeadOriginal(workId);
                            decimal originalTubeMaxHotHeadPsi = fullLengthLiningWorkDetailsGateway.GetTubeMaxHotHeadPsiOriginal(workId);
                            decimal originalTubeIdealHead = fullLengthLiningWorkDetailsGateway.GetTubeIdealHeadOriginal(workId);
                            decimal originalTubeIdealHeadPsi = fullLengthLiningWorkDetailsGateway.GetTubeIdealHeadPsiOriginal(workId);
                            decimal originalNetResinForTube = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeOriginal(workId);
                            decimal originalNetResinForTubeUsgals = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeUsgalsOriginal(workId);
                            string originalNetResinForTubeDrumsIns = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeDrumsInsOriginal(workId);
                            decimal originalNetResinForTubeLbsFt = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeLbsFtOriginal(workId);
                            decimal originalNetResinForTubeUsgFt = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeUsgFtOriginal(workId);
                            int originalExtraResinForMix = fullLengthLiningWorkDetailsGateway.GetExtraResinForMixOriginal(workId);
                            decimal originalExtraLbsForMix = fullLengthLiningWorkDetailsGateway.GetExtraLbsForMixOriginal(workId);
                            decimal originalTotalMixQuantity = fullLengthLiningWorkDetailsGateway.GetTotalMixQuantityOriginal(workId);
                            decimal originalTotalMixQuantityUsgals = fullLengthLiningWorkDetailsGateway.GetTotalMixQuantityUsgalsOriginal(workId);
                            string originalTotalMixQuantityDrumsIns = fullLengthLiningWorkDetailsGateway.GetTotalMixQuantityDrumsInsOriginal(workId);
                            string originalInversionType = fullLengthLiningWorkDetailsGateway.GetInversionTypeOriginal(workId);
                            decimal originalDepthOfInversionMH = fullLengthLiningWorkDetailsGateway.GetDepthOfInversionMHOriginal(workId);
                            decimal originalTubeForColumn = fullLengthLiningWorkDetailsGateway.GetTubeForColumnOriginal(workId);
                            decimal originalTubeForStartDry = fullLengthLiningWorkDetailsGateway.GetTubeForStartDryOriginal(workId);
                            decimal originalTotalTube = fullLengthLiningWorkDetailsGateway.GetTotalTubeOriginal(workId);
                            string originalDropTubeConnects = fullLengthLiningWorkDetailsGateway.GetDropTubeConnectsOriginal(workId);
                            decimal originalAllowsHeadTo = fullLengthLiningWorkDetailsGateway.GetAllowsHeadToOriginal(workId);
                            decimal originalRollerGap = fullLengthLiningWorkDetailsGateway.GetRollerGapOriginal(workId);
                            decimal originalHeightNeeded = fullLengthLiningWorkDetailsGateway.GetHeightNeededOriginal(workId);
                            string originalAvailable = fullLengthLiningWorkDetailsGateway.GetAvailableOriginal(workId);
                            string originalHoistHeight = fullLengthLiningWorkDetailsGateway.GetHoistHeightOriginal(workId);
                            string originalCommentsCipp = fullLengthLiningWorkDetailsGateway.GetCommentsCippOriginal(workId);
                            string originalResinLabel = fullLengthLiningWorkDetailsGateway.GetResinsLabelOriginal(workId);
                            string originalDrumContainsLabel = fullLengthLiningWorkDetailsGateway.GetDrumContainsLabelOriginal(workId);
                            string originalLinerTubeLabel = fullLengthLiningWorkDetailsGateway.GetLinerTubeLabelOriginal(workId);
                            string originalForLbDrumsLabel = fullLengthLiningWorkDetailsGateway.GetForLbDrumsLabelOriginal(workId);
                            string originalNetResinLabel = fullLengthLiningWorkDetailsGateway.GetNetResinLabelOriginal(workId);
                            string originalCatalystLabel = fullLengthLiningWorkDetailsGateway.GetCatalystLabelOriginal(workId);

                            // Wet Out new data 
                            string newLinerTube = fullLengthLiningWorkDetailsGateway.GetLinerTube(workId);
                            int newResinID = fullLengthLiningWorkDetailsGateway.GetResinId(workId);
                            decimal newExcessResin = fullLengthLiningWorkDetailsGateway.GetExcessResin(workId);
                            string newPoundsDrums = fullLengthLiningWorkDetailsGateway.GetPoundsDrums(workId);
                            decimal newDrumDiameter = fullLengthLiningWorkDetailsGateway.GetDrumDiameter(workId);
                            decimal newHoistMaximumHeight = fullLengthLiningWorkDetailsGateway.GetHoistMaximumHeight(workId);
                            decimal newHoistMinimumHeight = fullLengthLiningWorkDetailsGateway.GetHoistMinimumHeight(workId);
                            decimal newDownDropTubeLenght = fullLengthLiningWorkDetailsGateway.GetDownDropTubeLenght(workId);
                            decimal newPumpHeightAboveGround = fullLengthLiningWorkDetailsGateway.GetPumpHeightAboveGround(workId);
                            int newTubeResinToFeltFactor = fullLengthLiningWorkDetailsGateway.GetTubeResinToFeltFactor(workId);
                            DateTime newDateOfSheet = fullLengthLiningWorkDetailsGateway.GetDateOfSheet(workId);
                            int newEmployeeID = fullLengthLiningWorkDetailsGateway.GetEmployeeId(workId);
                            string newRunDetails = fullLengthLiningWorkDetailsGateway.GetRunDetails(workId);
                            string newRunDetails2 = fullLengthLiningWorkDetailsGateway.GetRunDetails2(workId);
                            DateTime newWetOutDate = fullLengthLiningWorkDetailsGateway.GetWetOutDate(workId);
                            DateTime? newWetOutInstallDate = fullLengthLiningWorkDetailsGateway.GetWetOutInstallDate(workId);
                            string newThickness = fullLengthLiningWorkDetailsGateway.GetInversionThickness(workId);
                            decimal newLengthToLine = fullLengthLiningWorkDetailsGateway.GetLengthToLine(workId);
                            decimal newPlusExtra = fullLengthLiningWorkDetailsGateway.GetPlusExtra(workId);
                            decimal newForTurnOffset = fullLengthLiningWorkDetailsGateway.GetForTurnOffset(workId);
                            decimal newLengthToWetOut = fullLengthLiningWorkDetailsGateway.GetLengthToWetOut(workId);
                            decimal newTubeMaxColdHead = fullLengthLiningWorkDetailsGateway.GetTubeMaxColdHead(workId);
                            decimal newTubeMaxColdHeadPsi = fullLengthLiningWorkDetailsGateway.GetTubeMaxColdHeadPsi(workId);
                            decimal newTubeMaxHotHead = fullLengthLiningWorkDetailsGateway.GetTubeMaxHotHead(workId);
                            decimal newTubeMaxHotHeadPsi = fullLengthLiningWorkDetailsGateway.GetTubeMaxHotHeadPsi(workId);
                            decimal newTubeIdealHead = fullLengthLiningWorkDetailsGateway.GetTubeIdealHead(workId);
                            decimal newTubeIdealHeadPsi = fullLengthLiningWorkDetailsGateway.GetTubeIdealHeadPsi(workId);
                            decimal newNetResinForTube = fullLengthLiningWorkDetailsGateway.GetNetResinForTube(workId);
                            decimal newNetResinForTubeUsgals = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeUsgals(workId);
                            string newNetResinForTubeDrumsIns = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeDrumsIns(workId);
                            decimal newNetResinForTubeLbsFt = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeLbsFt(workId);
                            decimal newNetResinForTubeUsgFt = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeUsgFt(workId);
                            int newExtraResinForMix = fullLengthLiningWorkDetailsGateway.GetExtraResinForMix(workId);
                            decimal newExtraLbsForMix = fullLengthLiningWorkDetailsGateway.GetExtraLbsForMix(workId);
                            decimal newTotalMixQuantity = fullLengthLiningWorkDetailsGateway.GetTotalMixQuantity(workId);
                            decimal newTotalMixQuantityUsgals = fullLengthLiningWorkDetailsGateway.GetTotalMixQuantityUsgals(workId);
                            string newTotalMixQuantityDrumsIns = fullLengthLiningWorkDetailsGateway.GetTotalMixQuantityDrumsIns(workId);
                            string newInversionType = fullLengthLiningWorkDetailsGateway.GetInversionType(workId);
                            decimal newDepthOfInversionMH = fullLengthLiningWorkDetailsGateway.GetDepthOfInversionMH(workId);
                            decimal newTubeForColumn = fullLengthLiningWorkDetailsGateway.GetTubeForColumn(workId);
                            decimal newTubeForStartDry = fullLengthLiningWorkDetailsGateway.GetTubeForStartDry(workId);
                            decimal newTotalTube = fullLengthLiningWorkDetailsGateway.GetTotalTube(workId);
                            string newDropTubeConnects = fullLengthLiningWorkDetailsGateway.GetDropTubeConnects(workId);
                            decimal newAllowsHeadTo = fullLengthLiningWorkDetailsGateway.GetAllowsHeadTo(workId);
                            decimal newRollerGap = fullLengthLiningWorkDetailsGateway.GetRollerGap(workId);
                            decimal newHeightNeeded = fullLengthLiningWorkDetailsGateway.GetHeightNeeded(workId);
                            string newAvailable = fullLengthLiningWorkDetailsGateway.GetAvailable(workId);
                            string newHoistHeight = fullLengthLiningWorkDetailsGateway.GetHoistHeight(workId);
                            string newCommentsCipp = fullLengthLiningWorkDetailsGateway.GetCommentsCipp(workId);
                            string newResinLabel = fullLengthLiningWorkDetailsGateway.GetResinsLabel(workId);
                            string newDrumContainsLabel = fullLengthLiningWorkDetailsGateway.GetDrumContainsLabel(workId);
                            string newLinerTubeLabel = fullLengthLiningWorkDetailsGateway.GetLinerTubeLabel(workId);
                            string newForLbDrumsLabel = fullLengthLiningWorkDetailsGateway.GetForLbDrumsLabel(workId);
                            string newNetResinLabel = fullLengthLiningWorkDetailsGateway.GetNetResinLabel(workId);
                            string newCatalystLabel = fullLengthLiningWorkDetailsGateway.GetCatalystLabel(workId);

                            string originalInversionComment = "";
                            string originalPipeType = "";
                            string originalPipeCondition = "";
                            string originalGroundMoisture = "";
                            decimal originalBoilerSize = 0m;
                            decimal originalPumpTotalCapacity = 0m;
                            decimal originalLayFlatSize = 0m;
                            decimal originalLayFlatQuantityTotal = 0m;
                            decimal originalWaterStartTemp = 0m;
                            decimal originalTemp1 =  0m;
                            decimal originalHoldAtT1 = 0m;
                            decimal originalTempT2 = 0m;
                            decimal originalCookAtT2 = 0m;
                            decimal originalCoolDownFor = 0m;
                            decimal originalCoolToTemp = 0m;
                            decimal originalDropInPipeRun = 0m;
                            decimal originalPipeSlopOf = 0m;
                            decimal originalF45F120 = 0m;
                            decimal originalHold = 0m;
                            decimal originalF120F185 = 0m;
                            decimal originalCookTime = 0m;
                            decimal originalCoolTime = 0m;
                            decimal originalAproxTotal = 0m;
                            decimal originalWaterChangesPerHour = 0m;
                            decimal originalReturnWaterVelocity = 0m;
                            decimal originalLayflatBackPressure = 0m;
                            decimal originalPumpLiftAtIdealHead = 0m;
                            decimal originalWaterToFillLinerColumn = 0m;
                            decimal originalWaterPerFit = 0m;
                            string originalInstallationResults = "";
                            string originalInversionLinerTubeLabel = "";
                            string originalHeadsIdealLabel = "";
                            string originalPumpingAndCirculationLabel = "";

                            // Inversion new Data
                            string newInversionComment = "";
                            string newPipeType = "";
                            string newPipeCondition = "";
                            string newGroundMoisture = "";
                            decimal newBoilerSize = 0m;
                            decimal newPumpTotalCapacity = 0m;
                            decimal newLayFlatSize = 0m;
                            decimal newLayFlatQuantityTotal = 0m;
                            decimal newWaterStartTemp = 0m;
                            decimal newTemp1 = 0m;
                            decimal newHoldAtT1 = 0m;
                            decimal newTempT2 = 0m;
                            decimal newCookAtT2 = 0m;
                            decimal newCoolDownFor = 0m;
                            decimal newCoolToTemp = 0m;
                            decimal newDropInPipeRun = 0m;
                            decimal newPipeSlopOf = 0m;
                            decimal newF45F120 = 0m;
                            decimal newHold = 0m;
                            decimal newF120F185 = 0m;
                            decimal newCookTime = 0m;
                            decimal newCoolTime = 0m;
                            decimal newAproxTotal = 0m;
                            decimal newWaterChangesPerHour = 0m;
                            decimal newReturnWaterVelocity = 0m;
                            decimal newLayflatBackPressure = 0m;
                            decimal newPumpLiftAtIdealHead = 0m;
                            decimal newWaterToFillLinerColumn = 0m;
                            decimal newWaterPerFit = 0m;
                            string newInstallationResults = "";
                            string newInversionLinerTubeLabel = "";
                            string newHeadsIdealLabel = "";
                            string newPumpingAndCirculationLabel = "";

                            if (includeInversionInformation)
                            {
                                // InversionData original values
                                originalInversionComment = fullLengthLiningWorkDetailsGateway.GetInversionCommentOriginal(workId);
                                originalPipeType = fullLengthLiningWorkDetailsGateway.GetPipeTypeOriginal(workId);
                                originalPipeCondition = fullLengthLiningWorkDetailsGateway.GetPipeConditionOriginal(workId);
                                originalGroundMoisture = fullLengthLiningWorkDetailsGateway.GetGroundMoistureOriginal(workId);
                                originalBoilerSize = fullLengthLiningWorkDetailsGateway.GetBoilerSizeOriginal(workId);
                                originalPumpTotalCapacity = fullLengthLiningWorkDetailsGateway.GetPumpTotalCapacityOriginal(workId);
                                originalLayFlatSize = fullLengthLiningWorkDetailsGateway.GetLayFlatSizeOriginal(workId);
                                originalLayFlatQuantityTotal = fullLengthLiningWorkDetailsGateway.GetLayFlatQuantityTotalOriginal(workId);
                                originalWaterStartTemp = fullLengthLiningWorkDetailsGateway.GetWaterStartTempOriginal(workId);
                                originalTemp1 = fullLengthLiningWorkDetailsGateway.GetTemp1Original(workId);
                                originalHoldAtT1 = fullLengthLiningWorkDetailsGateway.GetHoldAtT1Original(workId);
                                originalTempT2 = fullLengthLiningWorkDetailsGateway.GetTempT2Original(workId);
                                originalCookAtT2 = fullLengthLiningWorkDetailsGateway.GetCookAtT2Original(workId);
                                originalCoolDownFor = fullLengthLiningWorkDetailsGateway.GetCoolDownForOriginal(workId);
                                originalCoolToTemp = fullLengthLiningWorkDetailsGateway.GetCoolToTempOriginal(workId);
                                originalDropInPipeRun = fullLengthLiningWorkDetailsGateway.GetDropInPipeRunOriginal(workId);
                                originalPipeSlopOf = fullLengthLiningWorkDetailsGateway.GetPipeSlopOfOriginal(workId);
                                originalF45F120 = fullLengthLiningWorkDetailsGateway.GetF45F120Original(workId);
                                originalHold = fullLengthLiningWorkDetailsGateway.GetHoldOriginal(workId);
                                originalF120F185 = fullLengthLiningWorkDetailsGateway.GetF120F185Original(workId);
                                originalCookTime = fullLengthLiningWorkDetailsGateway.GetCookTimeOriginal(workId);
                                originalCoolTime = fullLengthLiningWorkDetailsGateway.GetCoolTimeOriginal(workId);
                                originalAproxTotal = fullLengthLiningWorkDetailsGateway.GetAproxTotalOriginal(workId);
                                originalWaterChangesPerHour = fullLengthLiningWorkDetailsGateway.GetWaterChangesPerHourOriginal(workId);
                                originalReturnWaterVelocity = fullLengthLiningWorkDetailsGateway.GetReturnWaterVelocityOriginal(workId);
                                originalLayflatBackPressure = fullLengthLiningWorkDetailsGateway.GetLayflatBackPressureOriginal(workId);
                                originalPumpLiftAtIdealHead = fullLengthLiningWorkDetailsGateway.GetPumpLiftAtIdealHeadOriginal(workId);
                                originalWaterToFillLinerColumn = fullLengthLiningWorkDetailsGateway.GetWaterToFillLinerColumnOriginal(workId);
                                originalWaterPerFit = fullLengthLiningWorkDetailsGateway.GetWaterPerFitOriginal(workId);
                                originalInstallationResults = fullLengthLiningWorkDetailsGateway.GetInstallationResultsOriginal(workId);
                                originalInversionLinerTubeLabel = fullLengthLiningWorkDetailsGateway.GetInversionLinerTubeLabelOriginal(workId);
                                originalHeadsIdealLabel = fullLengthLiningWorkDetailsGateway.GetHeadsIdealLabelOriginal(workId);
                                originalPumpingAndCirculationLabel = fullLengthLiningWorkDetailsGateway.GetPumpingAndCirculationLabelOriginal(workId);

                                // Inversion new Data
                                newInversionComment = fullLengthLiningWorkDetailsGateway.GetInversionComment(workId);
                                newPipeType = fullLengthLiningWorkDetailsGateway.GetPipeType(workId);
                                newPipeCondition = fullLengthLiningWorkDetailsGateway.GetPipeCondition(workId);
                                newGroundMoisture = fullLengthLiningWorkDetailsGateway.GetGroundMoisture(workId);
                                newBoilerSize = fullLengthLiningWorkDetailsGateway.GetBoilerSize(workId);
                                newPumpTotalCapacity = fullLengthLiningWorkDetailsGateway.GetPumpTotalCapacity(workId);
                                newLayFlatSize = fullLengthLiningWorkDetailsGateway.GetLayFlatSize(workId);
                                newLayFlatQuantityTotal = fullLengthLiningWorkDetailsGateway.GetLayFlatQuantityTotal(workId);
                                newWaterStartTemp = fullLengthLiningWorkDetailsGateway.GetWaterStartTemp(workId);
                                newTemp1 = fullLengthLiningWorkDetailsGateway.GetTemp1(workId);
                                newHoldAtT1 = fullLengthLiningWorkDetailsGateway.GetHoldAtT1(workId);
                                newTempT2 = fullLengthLiningWorkDetailsGateway.GetTempT2(workId);
                                newCookAtT2 = fullLengthLiningWorkDetailsGateway.GetCookAtT2(workId);
                                newCoolDownFor = fullLengthLiningWorkDetailsGateway.GetCoolDownFor(workId);
                                newCoolToTemp = fullLengthLiningWorkDetailsGateway.GetCoolToTemp(workId);
                                newDropInPipeRun = fullLengthLiningWorkDetailsGateway.GetDropInPipeRun(workId);
                                newPipeSlopOf = fullLengthLiningWorkDetailsGateway.GetPipeSlopOf(workId);
                                newF45F120 = fullLengthLiningWorkDetailsGateway.GetF45F120(workId);
                                newHold = fullLengthLiningWorkDetailsGateway.GetHold(workId);
                                newF120F185 = fullLengthLiningWorkDetailsGateway.GetF120F185(workId);
                                newCookTime = fullLengthLiningWorkDetailsGateway.GetCookTime(workId);
                                newCoolTime = fullLengthLiningWorkDetailsGateway.GetCoolTime(workId);
                                newAproxTotal = fullLengthLiningWorkDetailsGateway.GetAproxTotal(workId);
                                newWaterChangesPerHour = fullLengthLiningWorkDetailsGateway.GetWaterChangesPerHour(workId);
                                newReturnWaterVelocity = fullLengthLiningWorkDetailsGateway.GetReturnWaterVelocity(workId);
                                newLayflatBackPressure = fullLengthLiningWorkDetailsGateway.GetLayflatBackPressure(workId);
                                newPumpLiftAtIdealHead = fullLengthLiningWorkDetailsGateway.GetPumpLiftAtIdealHead(workId);
                                newWaterToFillLinerColumn = fullLengthLiningWorkDetailsGateway.GetWaterToFillLinerColumn(workId);
                                newWaterPerFit = fullLengthLiningWorkDetailsGateway.GetWaterPerFit(workId);
                                newInstallationResults = fullLengthLiningWorkDetailsGateway.GetInstallationResults(workId);
                                newInversionLinerTubeLabel = fullLengthLiningWorkDetailsGateway.GetInversionLinerTubeLabel(workId);
                                newHeadsIdealLabel = fullLengthLiningWorkDetailsGateway.GetHeadsIdealLabel(workId);
                                newPumpingAndCirculationLabel = fullLengthLiningWorkDetailsGateway.GetPumpingAndCirculationLabel(workId);
                            }

                            // Get All sectionIds for insert
                            string runDetails = row.RunDetails;
                            string[] runDetailsList = runDetails.Split('>');

                            for (int i = 0; i < runDetailsList.Length; i++)
                            {
                                AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
                                string sectionId = runDetailsList[i].ToString();
                                assetSewerSectionGateway.LoadBySectionId(sectionId, companyId);
                                int assetId = assetSewerSectionGateway.GetAssetID(sectionId);

                                WorkGateway workGateway = new WorkGateway();
                                int newWorkId = 0;
                                workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Full Length Lining", companyId);
                                if (workGateway.Table.Rows.Count > 0)
                                {
                                    newWorkId = workGateway.GetWorkId(assetId, "Full Length Lining", projectId);
                                }
                                
                                WorkFullLengthLiningWetOutGateway workFullLengthLiningWetOutGatewayForReview = new WorkFullLengthLiningWetOutGateway();
                                workFullLengthLiningWetOutGatewayForReview.LoadByWorkId(newWorkId, companyId);
                                if (workFullLengthLiningWetOutGatewayForReview.Table.Rows.Count > 0)
                                {                                    
                                    // Update work with cipp information
                                    UpdateWorkWetOutInformation(newWorkId, originalLinerTube, originalResinID, originalExcessResin, originalPoundsDrums, originalDrumDiameter, originalHoistMaximumHeight, originalHoistMinimumHeight, originalDownDropTubeLenght, originalPumpHeightAboveGround, originalTubeResinToFeltFactor, originalDateOfSheet, originalEmployeeID, originalRunDetails, originalRunDetails2, originalWetOutDate, originalWetOutInstallDate, originalThickness, originalLengthToLine, originalPlusExtra, originalForTurnOffset, originalLengthToWetOut, originalTubeMaxColdHead, originalTubeMaxColdHeadPsi, originalTubeMaxHotHead, originalTubeMaxHotHeadPsi, originalTubeIdealHead, originalTubeIdealHeadPsi, originalNetResinForTube, originalNetResinForTubeUsgals, originalNetResinForTubeDrumsIns, originalNetResinForTubeLbsFt, originalNetResinForTubeUsgFt, originalExtraResinForMix, originalExtraLbsForMix, originalTotalMixQuantity, originalTotalMixQuantityUsgals, originalTotalMixQuantityDrumsIns, originalInversionType, originalDepthOfInversionMH, originalTubeForColumn, originalTubeForStartDry, originalTotalTube, originalDropTubeConnects, originalAllowsHeadTo, originalRollerGap, originalHeightNeeded, originalAvailable, originalHoistHeight, originalCommentsCipp, originalResinLabel, originalDrumContainsLabel, originalLinerTubeLabel, originalForLbDrumsLabel, originalNetResinLabel, originalCatalystLabel, originalInversionComment, originalPipeType, originalPipeCondition, originalGroundMoisture, originalBoilerSize, originalPumpTotalCapacity, originalLayFlatSize, originalLayFlatQuantityTotal, originalWaterStartTemp, originalTemp1, originalHoldAtT1, originalTempT2, originalCookAtT2, originalCoolDownFor, originalCoolToTemp, originalDropInPipeRun, originalPipeSlopOf, originalF45F120, originalHold, originalF120F185, originalCookTime, originalCoolTime, originalAproxTotal, originalWaterChangesPerHour, originalReturnWaterVelocity, originalLayflatBackPressure, originalPumpLiftAtIdealHead, originalWaterToFillLinerColumn, originalWaterPerFit, originalInstallationResults, originalInversionLinerTubeLabel, originalHeadsIdealLabel, originalPumpingAndCirculationLabel, false, companyId, newLinerTube, newResinID, newExcessResin, newPoundsDrums, newDrumDiameter, newHoistMaximumHeight, newHoistMinimumHeight, newDownDropTubeLenght, newPumpHeightAboveGround, newTubeResinToFeltFactor, newDateOfSheet, newEmployeeID, newRunDetails, newRunDetails2, newWetOutDate, newWetOutInstallDate, newThickness, newLengthToLine, newPlusExtra, newForTurnOffset, newLengthToWetOut, newTubeMaxColdHead, newTubeMaxColdHeadPsi, newTubeMaxHotHead, newTubeMaxHotHeadPsi, newTubeIdealHead, newTubeIdealHeadPsi, newNetResinForTube, newNetResinForTubeUsgals, newNetResinForTubeDrumsIns, newNetResinForTubeLbsFt, newNetResinForTubeUsgFt, newExtraResinForMix, newExtraLbsForMix, newTotalMixQuantity, newTotalMixQuantityUsgals, newTotalMixQuantityDrumsIns, newInversionType, newDepthOfInversionMH, newTubeForColumn, newTubeForStartDry, newTotalTube, newDropTubeConnects, newAllowsHeadTo, newRollerGap, newHeightNeeded, newAvailable, newHoistHeight, newCommentsCipp, newResinLabel, newDrumContainsLabel, newLinerTubeLabel, newForLbDrumsLabel, newNetResinLabel, newCatalystLabel, newInversionComment, newPipeType, newPipeCondition, newGroundMoisture, newBoilerSize, newPumpTotalCapacity, newLayFlatSize, newLayFlatQuantityTotal, newWaterStartTemp, newTemp1, newHoldAtT1, newTempT2, newCookAtT2, newCoolDownFor, newCoolToTemp, newDropInPipeRun, newPipeSlopOf, newF45F120, newHold, newF120F185, newCookTime, newCoolTime, newAproxTotal, newWaterChangesPerHour, newReturnWaterVelocity, newLayflatBackPressure, newPumpLiftAtIdealHead, newWaterToFillLinerColumn, newWaterPerFit, newInstallationResults, newInversionLinerTubeLabel, newHeadsIdealLabel, newPumpingAndCirculationLabel, false, companyId, includeWetOutInformation, includeInversionInformation);
                                }
                                else
                                {
                                    // ... Insert wet out data
                                    string inversionComment = fullLengthLiningWorkDetailsGateway.GetInversionComment(workId);
                                    string installationResults = fullLengthLiningWorkDetailsGateway.GetInstallationResults(workId);
                                    DateTime? wetOutInstallDate = fullLengthLiningWorkDetailsGateway.GetWetOutInstallDate(workId);

                                    InsertWorkWetOutInformation(newWorkId, row.LinerTube, row.ResinID, row.ExcessResin, row.PoundsDrums, row.DrumDiameter, row.HoistMaximumHeight, row.HoistMinimumHeight, row.DownDropTubeLenght, row.PumpHeightAboveGround, row.TubeResinToFeltFactor, row.DateOfSheet, row.EmployeeID, row.RunDetails, row.RunDetails2, row.WetOutDate, wetOutInstallDate, row.Thickness, row.LengthToLine, row.PlusExtra, row.ForTurnOffset, row.LengthToWetOut, row.TubeMaxColdHead, row.TubeMaxColdHeadPsi, row.TubeMaxHotHead, row.TubeMaxHotHeadPsi, row.TubeIdealHead, row.TubeIdealHeadPsi, row.NetResinForTube, row.NetResinForTubeUsgals, row.NetResinForTubeDrumsIns, row.NetResinForTubeLbsFt, row.NetResinForTubeUsgFt, row.ExtraResinForMix, row.ExtraLbsForMix, row.TotalMixQuantity, row.TotalMixQuantityUsgals, row.TotalMixQuantityDrumsIns, row.InversionType, row.DepthOfInversionMH, row.TubeForColumn, row.TubeForStartDry, row.TotalTube, row.DropTubeConnects, row.AllowsHeadTo, row.RollerGap, row.HeightNeeded, row.Available, row.HoistHeight, row.CommentsCipp, row.ResinsLabel, row.DrumContainsLabel, row.LinerTubeLabel, row.ForLbDrumsLabel, row.NetResinLabel, row.CatalystLabel, inversionComment, row.PipeType, row.PipeCondition, row.GroundMoisture, row.BoilerSize, row.PumpTotalCapacity, row.LayFlatSize, row.LayFlatQuantityTotal, row.WaterStartTemp, row.Temp1, row.HoldAtT1, row.TempT2, row.CookAtT2, row.CoolDownFor, row.CoolToTemp, row.DropInPipeRun, row.PipeSlopOf, row.F45F120, row.Hold, row.F120F185, row.CookTime, row.CoolTime, row.AproxTotal, row.WaterChangesPerHour, row.ReturnWaterVelocity, row.LayflatBackPressure, row.PumpLiftAtIdealHead, row.WaterToFillLinerColumn, row.WaterPerFit, installationResults, row.InversionLinerTubeLabel, row.HeadsIdealLabel, row.PumpingAndCirculationLabel, row.Deleted, row.COMPANY_ID, includeWetOutInformation, includeInversionInformation);
                                }
                            }                                                      
                        }
                        else
                        { 
                            // Get All sectionIds for insert
                            string runDetails = row.RunDetails;                            
                            string[] runDetailsList = runDetails.Split('>');
                            
                            for (int i = 0; i < runDetailsList.Length; i++)
                            {
                                AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
                                string sectionId = runDetailsList[i].ToString();
                                assetSewerSectionGateway.LoadBySectionId(sectionId, companyId);
                                int assetId = assetSewerSectionGateway.GetAssetID(sectionId);

                                WorkGateway workGateway = new WorkGateway();
                                workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Full Length Lining", companyId);
                                if (workGateway.Table.Rows.Count > 0) 
                                {
                                    int newWorkId = workGateway.GetWorkId(assetId, "Full Length Lining", projectId);

                                    // ... Insert wet out data
                                    string inversionComment = fullLengthLiningWorkDetailsGateway.GetInversionComment(workId);
                                    string installationResults = fullLengthLiningWorkDetailsGateway.GetInstallationResults(workId);
                                    DateTime? wetOutInstallDate = fullLengthLiningWorkDetailsGateway.GetWetOutInstallDate(workId);

                                    InsertWorkWetOutInformation(newWorkId, row.LinerTube, row.ResinID, row.ExcessResin, row.PoundsDrums, row.DrumDiameter, row.HoistMaximumHeight, row.HoistMinimumHeight, row.DownDropTubeLenght, row.PumpHeightAboveGround, row.TubeResinToFeltFactor, row.DateOfSheet, row.EmployeeID, row.RunDetails, row.RunDetails2, row.WetOutDate, wetOutInstallDate, row.Thickness, row.LengthToLine, row.PlusExtra, row.ForTurnOffset, row.LengthToWetOut, row.TubeMaxColdHead, row.TubeMaxColdHeadPsi, row.TubeMaxHotHead, row.TubeMaxHotHeadPsi, row.TubeIdealHead, row.TubeIdealHeadPsi, row.NetResinForTube, row.NetResinForTubeUsgals, row.NetResinForTubeDrumsIns, row.NetResinForTubeLbsFt, row.NetResinForTubeUsgFt, row.ExtraResinForMix, row.ExtraLbsForMix, row.TotalMixQuantity, row.TotalMixQuantityUsgals, row.TotalMixQuantityDrumsIns, row.InversionType, row.DepthOfInversionMH, row.TubeForColumn, row.TubeForStartDry, row.TotalTube, row.DropTubeConnects, row.AllowsHeadTo, row.RollerGap, row.HeightNeeded, row.Available, row.HoistHeight, row.CommentsCipp, row.ResinsLabel, row.DrumContainsLabel, row.LinerTubeLabel, row.ForLbDrumsLabel, row.NetResinLabel, row.CatalystLabel, inversionComment, row.PipeType, row.PipeCondition, row.GroundMoisture, row.BoilerSize, row.PumpTotalCapacity, row.LayFlatSize, row.LayFlatQuantityTotal, row.WaterStartTemp, row.Temp1, row.HoldAtT1, row.TempT2, row.CookAtT2, row.CoolDownFor, row.CoolToTemp, row.DropInPipeRun, row.PipeSlopOf, row.F45F120, row.Hold, row.F120F185, row.CookTime, row.CoolTime, row.AproxTotal, row.WaterChangesPerHour, row.ReturnWaterVelocity, row.LayflatBackPressure, row.PumpLiftAtIdealHead, row.WaterToFillLinerColumn, row.WaterPerFit, installationResults, row.InversionLinerTubeLabel, row.HeadsIdealLabel, row.PumpingAndCirculationLabel, row.Deleted, row.COMPANY_ID, includeWetOutInformation, includeInversionInformation);
                                }
                            }
                        }
                    }

                    // Update JL Section WorkID 
                    int sectionWorkId = 0;
                    WorkGateway workGatewayForJL = new WorkGateway();
                    workGatewayForJL.LoadByProjectIdAssetIdWorkType(projectId, sectionAssetId, "Junction Lining Section", companyId);

                    if (workGatewayForJL.Table.Rows.Count > 0)
                    {
                        sectionWorkId = workGatewayForJL.GetWorkId(sectionAssetId, "Junction Lining Section", projectId);
                        WorkJunctionLiningSectionGateway workJunctionLiningSectionGateway = new WorkJunctionLiningSectionGateway();
                        workJunctionLiningSectionGateway.LoadByWorkId(sectionWorkId, companyId);

                        // get old values of section
                        int numLats = workJunctionLiningSectionGateway.GetNumLats(sectionWorkId);
                        int notLinedYet = workJunctionLiningSectionGateway.GetNotLinedYet(sectionWorkId);
                        bool allMeasured = workJunctionLiningSectionGateway.GetAllMeasured(sectionWorkId);
                        bool deleted = workJunctionLiningSectionGateway.GetDeleted(sectionWorkId);
                        string issueWithLaterals = workJunctionLiningSectionGateway.GetIssueWithLaterals(sectionWorkId);
                        int notMeasuredYet = workJunctionLiningSectionGateway.GetNotMeasuredYet(sectionWorkId);
                        int notDeliveredYet = workJunctionLiningSectionGateway.GetNotDeliveredYet(sectionWorkId);
                        string trafficControl = workJunctionLiningSectionGateway.GetTrafficControl(sectionWorkId);
                        string trafficControlDetails = workJunctionLiningSectionGateway.GetTrafficControlDetails(sectionWorkId);
                        bool standardBypass = workJunctionLiningSectionGateway.GetStandardBypass(sectionWorkId);
                        string standardBypassComments = workJunctionLiningSectionGateway.GetStandardBypassComments(sectionWorkId);
                        int availableToLine = workJunctionLiningSectionGateway.GetAvailableToLine(sectionWorkId);

                        WorkJunctionLiningSection workJunctionLiningSection = new WorkJunctionLiningSection(null);
                        workJunctionLiningSection.UpdateDirect(sectionWorkId, numLats, notLinedYet, allMeasured, deleted, issueWithLaterals, notMeasuredYet, notDeliveredYet, companyId, trafficControl, trafficControlDetails, standardBypass, standardBypassComments, availableToLine, numLats, notLinedYet, allMeasured, issueWithLaterals, notMeasuredYet, notDeliveredYet, newTrafficControl, newTrafficControlDetails, newStandardBypass, newStandardBypassComments, availableToLine);
                    }
                }
            }
        }



        /// <summary>
        /// UpdateCommentsForSummaryEdit
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void UpdateCommentsForSummaryEdit(int workId, int companyId)
        {
            WorkCommentsGateway workComentsGateway = new WorkCommentsGateway();
            WorkComments workComments = new WorkComments(workComentsGateway.Data);
            WorkGateway workGateway = new WorkGateway();

            FullLengthLiningTDS.WorkDetailsRow row = GetRow(workId);
            
            workGateway.LoadByWorkId(workId, companyId);
            workComentsGateway.LoadByWorkIdWorkType(workId, companyId, "Full Length Lining");
            row.Comments = workComments.GetAllComments(workId, companyId, workComentsGateway.Table.Rows.Count, "\n");            
        }



        /// <summary>
        /// UpdateCommentsWetOutForSummaryEdit
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void UpdateCommentsWetOutForSummaryEdit(int workId, int companyId)
        {
            WorkFullLengthLiningWetOutCommentsGateway workFullLengthLiningWetOutCommentsGateway = new WorkFullLengthLiningWetOutCommentsGateway();
            WorkFullLengthLiningWetOutComments workFullLengthLiningWetOutComments = new WorkFullLengthLiningWetOutComments(workFullLengthLiningWetOutCommentsGateway.Data);
            WorkGateway workGateway = new WorkGateway();

            FullLengthLiningTDS.WorkDetailsRow row = GetRow(workId);

            workGateway.LoadByWorkId(workId, companyId);
            workFullLengthLiningWetOutCommentsGateway.LoadAllByWorkIdWorkType(workId, companyId, "Full Length Lining Wet Out");
            row.CommentsCipp = workFullLengthLiningWetOutComments.GetAllComments(workId, companyId, workFullLengthLiningWetOutCommentsGateway.Table.Rows.Count, "\n");
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="workId">workId</param>
        public void Delete(int workId)
        {
            FullLengthLiningTDS.WorkDetailsRow row = GetRow(workId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, int assetId, int companyId)
        {
           // Delete work
            WorkFullLengthLining workFullLengthLining = new WorkFullLengthLining(null);
            workFullLengthLining.DeleteDirect(workId, companyId);

            // Delete section
            LfsAssetSewerSection lfsAssetSewerSection = new LfsAssetSewerSection(null);
            lfsAssetSewerSection.DeleteDirect(assetId, companyId);
        }
 





        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateWork
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="workId">workId</param>
        /// <param name="originalClientId">originalClientId</param>
        /// <param name="originalProposedLiningDate">originalProposedLiningDate</param>
        /// <param name="originalDeadlineLiningDate">originalDeadlineLiningDate</param>
        /// <param name="originalP1Date">originalP1Date</param>
        /// <param name="originalM1Date">originalM1Date</param>
        /// <param name="originalM2Date">originalM2Date</param>
        /// <param name="originalInstallDate">originalInstallDate</param>
        /// <param name="originalFinalVideoDate">originalFinalVideoDate</param>
        /// <param name="originalIssueIdentified">originalIssueIdentified</param>
        /// <param name="originalIssueLFS">originalIssueLFS</param>
        /// <param name="originalIssueClient">originalIssueClient</param>
        /// <param name="originalIssueSales">originalIssueSales</param>
        /// <param name="originalIssueGivenToClient">originalIssueGivenToClient</param>
        /// <param name="originalIssueResolved">originalIssueResolved</param>
        /// <param name="originalIssueInvestigation">originalIssueInvestigation</param>
        /// <param name="originalCxisRemoved">originalCxisRemoved</param>
        /// <param name="originalRoboticPrepCompleted">originalRoboticPrepCompleted</param>
        /// <param name="originalRoboticPrepCompletedDate">originalRoboticPrepCompletedDate</param>
        /// <param name="originalMeasurementTakenBy">originalMeasurementTakenBy</param>
        /// <param name="originalMaterials">originalMaterials</param>
        /// <param name="originalTrafficControl">originalTrafficControl</param>
        /// <param name="originalSiteDetails">originalSiteDetails</param>
        /// <param name="originalPipeSizeChange">originalPipeSizeChange</param>
        /// <param name="originalStandardBypass">originalStandardBypass</param>        
        /// <param name="originalStandardBypassComments">originalStandardBypassComments</param>
        /// <param name="originalTrafficControlDetails">originalTrafficControlDetails</param>
        /// <param name="originalMeasurementType">originalMeasurementType</param>
        /// <param name="originalMeasurementFromMh">originalMeasurementFromMh</param>
        /// <param name="originalVideoDoneFromMh">originalVideoDoneFromMh</param>
        /// <param name="originalVideoDoneToMh">originalVideoDoneToMh</param>
        /// <param name="originalMeasurementTakenByM2">originalMeasurementTakenByM2</param>
        /// <param name="originalDropPipe">originalDropPipe</param>
        /// <param name="originalDropPipeInvertDepth">originalDropPipeInvertDepth</param>
        /// <param name="originalCappedLaterals">originalCappedLaterals</param>   
        /// <param name="originalLineWithId">originalLineWithId</param>        
        /// <param name="originalHydrantAddress">originalHydrantAddress</param>
        /// <param name="originalHydroWireWithin10FtOfInversionMH">originalHydroWireWithin10FtOfInversionMH</param>
        /// <param name="originalDistanceToInversionMh">originalDistanceToInversionMh</param>
        /// <param name="originalSurfaceGrade">originalSurfaceGrade</param>
        /// <param name="originalHydroPulley">originalHydroPulley</param>
        /// <param name="originalFridgeCart">originalFridgeCart</param>
        /// <param name="originalTwoPump">originalTwoPump</param>
        /// <param name="originalSixBypass">originalSixBypass</param>
        /// <param name="originalScaffolding">originalScaffolding</param>
        /// <param name="originalWinchExtension">originalWinchExtension</param>
        /// <param name="originalExtraGenerator">originalExtraGenerator</param>
        /// <param name="originalGreyCableExtension">originalGreyCableExtension</param>
        /// <param name="originalEasementMats">originalEasementMats</param>
        /// <param name="originalRampRequired">originalRampRequired</param>
        /// <param name="originalVideoLength">originalVideoLength</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalPreFlushDate">originalPreFlushDate</param>
        /// <param name="originalPreVideoDate">originalPreVideoDate</param>
        /// <param name="originalRaWorkId">originalRaWorkId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalCameraSkid">originalCameraSkid</param>  
        /// <param name="originalAccessType">originalAccessType</param>
        /// <param name="originalP1Completed">originalP1Completed</param>
        /// 
        /// <param name="newClientId">newClientId</param>
        /// <param name="newProposedLiningDate">newProposedLiningDate</param>
        /// <param name="newDeadlineLiningDate">newDeadlineLiningDate</param>
        /// <param name="newP1Date">newP1Date</param>
        /// <param name="newM1Date">newM1Date</param>
        /// <param name="newM2Date">newM2Date</param>
        /// <param name="newInstallDate">newInstallDate</param>
        /// <param name="newFinalVideoDate">newFinalVideoDate</param>
        /// <param name="newIssueIdentified">newIssueIdentified</param>
        /// <param name="newIssueLFS">newIssueLFS</param>
        /// <param name="newIssueClient">newIssueClient</param>
        /// <param name="newIssueSales">newIssueSales</param>
        /// <param name="newIssueGivenToClient">newIssueGivenToClient</param>
        /// <param name="newIssueResolved">newIssueResolved</param>
        /// <param name="newIssueInvestigation">newIssueInvestigation</param>
        /// <param name="newCxisRemoved">newCxisRemoved</param>
        /// <param name="newRoboticPrepCompleted">newRoboticPrepCompleted</param>
        /// <param name="newRoboticPrepCompletedDate">newRoboticPrepCompletedDate</param>
        /// <param name="newMeasurementTakenBy">newMeasurementTakenBy</param>
        /// <param name="newMaterials">newMaterials</param>
        /// <param name="newTrafficControl">newTrafficControl</param>
        /// <param name="newSiteDetails">newSiteDetails</param>
        /// <param name="newPipeSizeChange">newPipeSizeChange</param>
        /// <param name="newStandardBypass">newStandardBypass</param>        
        /// <param name="newStandardBypassComments">newStandardBypassComments</param>
        /// <param name="newTrafficControlDetails">newTrafficControlDetails</param>
        /// <param name="newMeasurementType">newMeasurementType</param>
        /// <param name="newMeasurementFromMh">newMeasurementFromMh</param>
        /// <param name="newVideoDoneFromMh">newVideoDoneFromMh</param>
        /// <param name="newVideoDoneToMh">newVideoDoneToMh</param>
        /// <param name="newMeasurementTakenByM2">newMeasurementTakenByM2</param>
        /// <param name="newDropPipe">newDropPipe</param>
        /// <param name="newDropPipeInvertDepth">newDropPipeInvertDepth</param>
        /// <param name="newCappedLaterals">newCappedLaterals</param> 
        /// <param name="newLineWithId">newLineWithId</param>
        /// <param name="newHydrantAddress">newHydrantAddress</param>
        /// <param name="newHydroWireWithin10FtOfInversionMH">newHydroWireWithin10FtOfInversionMH</param>        
        /// <param name="newDistanceToInversionMh">newDistanceToInversionMh</param> 
        /// <param name="newSurfaceGrade">newSurfaceGrade</param>
        /// <param name="newHydroPulley">newHydroPulley</param>
        /// <param name="newFridgeCart">newFridgeCart</param>
        /// <param name="newTwoPump">newTwoPump</param>
        /// <param name="newSixBypass">newSixBypass</param>
        /// <param name="newScaffolding">newScaffolding</param>
        /// <param name="newWinchExtension">newWinchExtension</param>
        /// <param name="newExtraGenerator">newExtraGenerator</param>
        /// <param name="newGreyCableExtension">newGreyCableExtension</param>
        /// <param name="newEasementMats">newEasementMats</param>
        /// <param name="newRampRequired">newRampRequired</param>
        /// <param name="newVideoLength">newVideoLength</param>        
        /// <param name="newComments">newComments</param>
        /// <param name="newPreFlushDate">newPreFlushDate</param>
        /// <param name="newPreVideoDate">newPreVideoDate</param>
        /// <param name="newRaWorkId">newRaWorkId</param>
        /// <param name="sectionAssetId">sectionAssetId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newCameraSkid">newCameraSkid</param>
        /// <param name="newAccessType">newAccessType</param>
        /// <param name="newP1Completed">newP1Completed</param>
        private void UpdateWork(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int workId, string originalClientId, DateTime? originalProposedLiningDate, DateTime? originalDeadlineLiningDate, DateTime? originalP1Date, DateTime? originalM1Date, DateTime? originalM2Date, DateTime? originalInstallDate, DateTime? originalFinalVideoDate, bool originalIssueIdentified, bool originalIssueLFS, bool originalIssueClient, bool originalIssueSales, bool originalIssueGivenToClient, bool originalIssueResolved, bool originalIssueInvestigation, int? originalCxisRemoved, bool originalRoboticPrepCompleted, DateTime? originalRoboticPrepCompletedDate, string originalMeasurementTakenBy, string originalTrafficControl, string originalSiteDetails, bool originalPipeSizeChange, bool originalStandardBypass, string originalStandardBypassComments, string originalTrafficControlDetails, string originalMeasurementType, string originalMeasurementFromMh, string originalVideoDoneFromMh, string originalVideoDoneToMh, string originalMeasurementTakenByM2, bool originalDropPipe, string originalDropPipeInvertDepth, int? originalCappedLaterals, string originalLineWithId, string originalHydrantAddress, string originalHydroWireWithin10FtOfInversionMH, string originalDistanceToInversionMh, string originalSurfaceGrade, bool originalHydroPulley, bool originalFridgeCart, bool originalTwoPump, bool originalSixBypass, bool originalScaffolding, bool originalWinchExtension, bool originalExtraGenerator, bool originalGreyCableExtension, bool originalEasementMats, bool originalRampRequired, string originalVideoLength, string originalComments,DateTime? originalPreFlushDate, DateTime? originalPreVideoDate, int originalRaWorkId, bool originalDeleted, int originalCompanyId, string originalMaterials, bool originalCameraSkid, string originalAccessType, bool originalP1Completed, string newClientId, DateTime? newProposedLiningDate, DateTime? newDeadlineLiningDate, DateTime? newP1Date, DateTime? newM1Date, DateTime? newM2Date, DateTime? newInstallDate, DateTime? newFinalVideoDate, bool newIssueIdentified, bool newIssueLFS, bool newIssueClient, bool newIssueSales, bool newIssueGivenToClient, bool newIssueResolved, bool newIssueInvestigation, int? newCxisRemoved, bool newRoboticPrepCompleted, DateTime? newRoboticPrepCompletedDate, string newMeasurementTakenBy, string newMaterials, string newTrafficControl, string newSiteDetails, bool newPipeSizeChange, bool newStandardBypass, string newStandardBypassComments, string newTrafficControlDetails, string newMeasurementType, string newMeasurementFromMh, string newVideoDoneFromMh, string newVideoDoneToMh, string newMeasurementTakenByM2, bool newDropPipe, string newDropPipeInvertDepth, int? newCappedLaterals, string newLineWithId, string newHydrantAddress, string newHydroWireWithin10FtOfInversionMH, string newDistanceToInversionMh, string newSurfaceGrade, bool newHydroPulley, bool newFridgeCart, bool newTwoPump, bool newSixBypass, bool newScaffolding, bool newWinchExtension, bool newExtraGenerator, bool newGreyCableExtension, bool newEasementMats, bool newRampRequired, string newVideoLength, string newComments, DateTime? newPreFlushDate, DateTime? newPreVideoDate, int newRaWorkId, int sectionAssetId, bool newDeleted, int newCompanyId, bool newCameraSkid, string newAccessType, bool newP1Completed)
        {
            WorkFullLengthLining workFullLengthLining = new WorkFullLengthLining(null);
            workFullLengthLining.UpdateDirect(sectionAssetId, workId, originalClientId, originalProposedLiningDate, originalDeadlineLiningDate, originalP1Date, originalM1Date, originalM2Date, originalInstallDate, originalFinalVideoDate, originalIssueIdentified, originalIssueLFS, originalIssueClient, originalIssueSales, originalIssueGivenToClient, originalIssueResolved, originalIssueInvestigation, originalCxisRemoved, originalRoboticPrepCompleted, originalRoboticPrepCompletedDate, originalMeasurementTakenBy, originalTrafficControl, originalSiteDetails, originalPipeSizeChange, originalStandardBypass, originalStandardBypassComments, originalTrafficControlDetails, originalMeasurementType, originalMeasurementFromMh, originalVideoDoneFromMh, originalVideoDoneToMh, originalMeasurementTakenByM2, originalDropPipe, originalDropPipeInvertDepth, originalCappedLaterals, originalLineWithId, originalHydrantAddress, originalHydroWireWithin10FtOfInversionMH, originalDistanceToInversionMh, originalSurfaceGrade, originalHydroPulley, originalFridgeCart, originalTwoPump, originalSixBypass, originalScaffolding, originalWinchExtension, originalExtraGenerator, originalGreyCableExtension, originalEasementMats, originalRampRequired, originalVideoLength, originalDeleted, originalCompanyId, originalCameraSkid, originalAccessType, originalP1Completed, workId, newClientId, newProposedLiningDate, newDeadlineLiningDate, newP1Date, newM1Date, newM2Date, newInstallDate, newFinalVideoDate, newIssueIdentified, newIssueLFS, newIssueClient, newIssueSales, newIssueGivenToClient, newIssueResolved, newIssueInvestigation, newCxisRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newMeasurementTakenBy, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardBypass, newStandardBypassComments, newTrafficControlDetails, newMeasurementType, newMeasurementFromMh, newVideoDoneFromMh, newVideoDoneToMh, newMeasurementTakenByM2, newDropPipe, newDropPipeInvertDepth, newCappedLaterals, newDistanceToInversionMh, newLineWithId, newHydrantAddress, newHydroWireWithin10FtOfInversionMH, newSurfaceGrade, newHydroPulley, newFridgeCart, newTwoPump, newSixBypass, newScaffolding, newWinchExtension, newExtraGenerator, newGreyCableExtension, newEasementMats, newRampRequired, newVideoLength, newDeleted, newCompanyId, newCameraSkid, newAccessType, newP1Completed);

            if (originalRaWorkId != 0)
            {
                WorkRehabAssessment workRehabAssessment = new WorkRehabAssessment(null);
                workRehabAssessment.UpdateDirect(originalRaWorkId, originalPreFlushDate, originalPreVideoDate, false, originalCompanyId, newRaWorkId, newPreFlushDate, newPreVideoDate, false, newCompanyId);
            }
        }



        /// <summary>
        /// UpdateWorkWetOutInformation
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="originalLinerTube">originalLinerTube</param>
        /// <param name="originalResinID">originalResinID</param>
        /// <param name="originalExcessResin">originalExcessResin</param>
        /// <param name="originalPoundsDrums">originalPoundsDrums</param>
        /// <param name="originalDrumDiameter">originalDrumDiameter</param>
        /// <param name="originalHoistMaximumHeight">originalHoistMaximumHeight</param>
        /// <param name="originalHoistMinimumHeight">originalHoistMinimumHeight</param>
        /// <param name="originalDownDropTubeLenght">originalDownDropTubeLenght</param>
        /// <param name="originalPumpHeightAboveGround">originalPumpHeightAboveGround</param>
        /// <param name="originalTubeResinToFeltFactor">originalTubeResinToFeltFactor</param>
        /// <param name="originalDateOfSheet">originalDateOfSheet</param>
        /// <param name="originalEmployeeID">originalEmployeeID</param>
        /// <param name="originalRunDetails">originalRunDetails</param>
        /// <param name="originalRunDetails2">originalRunDetails2</param>
        /// <param name="originalWetOutDate">originalWetOutDate</param>
        /// <param name="originalWetOutInstallDate">originalWetOutInstallDate</param>
        /// <param name="originalThickness">originalThickness</param>
        /// <param name="originalLengthToLine">originalLengthToLine</param>
        /// <param name="originalPlusExtra">originalPlusExtra</param>
        /// <param name="originalPlusExtra">originalPlusExtra</param>
        /// <param name="originalForTurnOffset">originalForTurnOffset</param>
        /// <param name="originalLengthToWetOut">originalLengthToWetOut</param>
        /// <param name="originalTubeMaxColdHead">originalTubeMaxColdHead</param>
        /// <param name="originalTubeMaxColdHeadPsi">originalTubeMaxColdHeadPsi</param>
        /// <param name="originalTubeMaxHotHead">originalTubeMaxHotHead</param>        
        /// <param name="originalTubeMaxHotHeadPsi">originalTubeMaxHotHeadPsi</param>
        /// <param name="originalTubeIdealHead">originalTubeIdealHead</param>
        /// <param name="originalTubeIdealHeadPsi">originalTubeIdealHeadPsi</param>
        /// <param name="originalNetResinForTube">originalNetResinForTube</param>
        /// <param name="originalNetResinForTubeUsgals">originalNetResinForTubeUsgals</param>
        /// <param name="originalNetResinForTubeDrumsIns">originalNetResinForTubeDrumsIns</param>
        /// <param name="originalNetResinForTubeLbsFt">originalNetResinForTubeLbsFt</param>
        /// <param name="originalNetResinForTubeUsgFt">originalNetResinForTubeUsgFt</param>
        /// <param name="originalExtraResinForMix">originalExtraResinForMix</param>
        /// <param name="originalExtraLbsForMix">originalExtraLbsForMix</param>
        /// <param name="originalTotalMixQuantity">originalTotalMixQuantity</param>
        /// <param name="originalTotalMixQuantityUsgals">originalTubeMaxHotHead</param>
        /// <param name="originalTotalMixQuantityUsgals">originalTotalMixQuantityUsgals</param>       
        /// <param name="originalTotalMixQuantityDrumsIns">originalTotalMixQuantityDrumsIns</param>
        /// <param name="originalInversionType">originalInversionType</param>
        /// <param name="originalDepthOfInversionMH">originalDepthOfInversionMH</param>
        /// <param name="originalTubeForColumn">originalTubeForColumn</param>
        /// <param name="originalTubeForStartDry">originalTubeForStartDry</param>
        /// <param name="originalTotalTube">originalTotalTube</param>
        /// <param name="originalDropTubeConnects">originalDropTubeConnects</param>
        /// <param name="originalAllowsHeadTo">originalAllowsHeadTo</param>
        /// <param name="originalRollerGap">originalRollerGap</param>
        /// <param name="originalHeightNeeded">originalHeightNeeded</param>
        /// <param name="originalAvailable">originalAvailable</param>
        /// <param name="originalHoistHeight">originalHoistHeight</param>
        /// <param name="originalCommentsCipp">originalCommentsCipp</param>
        /// <param name="originalResinsLabel">originalResinsLabel</param>
        /// <param name="originalDrumContainsLabel">originalDrumContainsLabel</param>
        /// <param name="originalLinerTubeLabel">originalLinerTubeLabel</param>
        /// <param name="originalForLbDrumsLabel">originalForLbDrumsLabel</param>
        /// <param name="originalNetResinLabel">originalNetResinLabel</param>
        /// <param name="originalCatalystLabel">originalCatalystLabel</param> 
        /// 
        /// <param name="originalInversionComment">originalInversionComment</param>
        /// <param name="originalTotalMixQuantityUsgals">originalTotalMixQuantityUsgals</param>
        /// <param name="originalTotalMixQuantityUsgals">originalTotalMixQuantityUsgals</param>
        /// <param name="originalTotalMixQuantityUsgals">originalTotalMixQuantityUsgals</param>
        /// <param name="originalTotalMixQuantityUsgals">originalTotalMixQuantityUsgals</param>
        /// <param name="originalTotalMixQuantityUsgals">originalTotalMixQuantityUsgals</param>
        /// <param name="originalTotalMixQuantityUsgals">originalTotalMixQuantityUsgals</param>
        /// <param name="originalTotalMixQuantityUsgals">originalTotalMixQuantityUsgals</param>
        /// <param name="originalTotalMixQuantityUsgals">originalTotalMixQuantityUsgals</param>
        /// <param name="originalTotalMixQuantityUsgals">originalTotalMixQuantityUsgals</param>
        /// <param name="originalTotalMixQuantityUsgals">originalTotalMixQuantityUsgals</param>
        /// <param name="originalTotalMixQuantityUsgals">originalTotalMixQuantityUsgals</param>
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
        /// <param name="originalInversionLinerTubeLabel">originalInversionLinerTubeLabel</param>
        /// <param name="originalHeadsIdealLabel">originalHeadsIdealLabel</param>
        /// <param name="originalPumpingAndCirculationLabel">originalPumpingAndCirculationLabel</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// 
        /// 
        /// <param name="workId">workId</param>
        /// <param name="newLinerTube">newLinerTube</param>
        /// <param name="newResinID">newResinID</param>
        /// <param name="newExcessResin">newExcessResin</param>
        /// <param name="newPoundsDrums">newPoundsDrums</param>
        /// <param name="newDrumDiameter">newDrumDiameter</param>
        /// <param name="newHoistMaximumHeight">newHoistMaximumHeight</param>
        /// <param name="newHoistMinimumHeight">newHoistMinimumHeight</param>
        /// <param name="newDownDropTubeLenght">newDownDropTubeLenght</param>
        /// <param name="newPumpHeightAboveGround">newPumpHeightAboveGround</param>
        /// <param name="newTubeResinToFeltFactor">newTubeResinToFeltFactor</param>
        /// <param name="newDateOfSheet">newDateOfSheet</param>
        /// <param name="newEmployeeID">newEmployeeID</param>
        /// <param name="newRunDetails">newRunDetails</param>
        /// <param name="newRunDetails2">newRunDetails2</param>
        /// <param name="newWetOutDate">newWetOutDate</param>
        /// <param name="newWetOutInstallDate">newWetOutInstallDate</param>
        /// <param name="newThickness">newThickness</param>
        /// <param name="newLengthToLine">newLengthToLine</param>
        /// <param name="newPlusExtra">newPlusExtra</param>
        /// <param name="newPlusExtra">newPlusExtra</param>
        /// <param name="newForTurnOffset">newForTurnOffset</param>
        /// <param name="newLengthToWetOut">newLengthToWetOut</param>
        /// <param name="newTubeMaxColdHead">newTubeMaxColdHead</param>
        /// <param name="newTubeMaxColdHeadPsi">newTubeMaxColdHeadPsi</param>
        /// <param name="newTubeMaxHotHead">newTubeMaxHotHead</param>        
        /// <param name="newTubeMaxHotHeadPsi">newTubeMaxHotHeadPsi</param>
        /// <param name="newTubeIdealHead">newTubeIdealHead</param>
        /// <param name="newTubeIdealHeadPsi">newTubeIdealHeadPsi</param>
        /// <param name="newNetResinForTube">newNetResinForTube</param>
        /// <param name="newNetResinForTubeUsgals">newNetResinForTubeUsgals</param>
        /// <param name="newNetResinForTubeDrumsIns">newNetResinForTubeDrumsIns</param>
        /// <param name="newNetResinForTubeLbsFt">newNetResinForTubeLbsFt</param>
        /// <param name="newNetResinForTubeUsgFt">newNetResinForTubeUsgFt</param>
        /// <param name="newExtraResinForMix">newExtraResinForMix</param>
        /// <param name="newExtraLbsForMix">newExtraLbsForMix</param>
        /// <param name="newTotalMixQuantity">newTotalMixQuantity</param>
        /// <param name="newTotalMixQuantityUsgals">newTubeMaxHotHead</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>        ///
        /// <param name="newTotalMixQuantityDrumsIns">newTotalMixQuantityDrumsIns</param>
        /// <param name="newInversionType">newInversionType</param>
        /// <param name="newDepthOfInversionMH">newDepthOfInversionMH</param>
        /// <param name="newTubeForColumn">newTubeForColumn</param>
        /// <param name="newTubeForStartDry">newTubeForStartDry</param>
        /// <param name="newTotalTube">newTotalTube</param>
        /// <param name="newDropTubeConnects">newDropTubeConnects</param>
        /// <param name="newAllowsHeadTo">newAllowsHeadTo</param>
        /// <param name="newRollerGap">newRollerGap</param>
        /// <param name="newHeightNeeded">newHeightNeeded</param>
        /// <param name="newAvailable">newAvailable</param>
        /// <param name="newHoistHeight">newHoistHeight</param>
        /// <param name="newCommentsCipp">newCommentsCipp</param>
        /// <param name="newResinsLabel">newResinsLabel</param>
        /// <param name="newDrumContainsLabel">newDrumContainsLabel</param>
        /// <param name="newLinerTubeLabel">newLinerTubeLabel</param>
        /// <param name="newForLbDrumsLabel">newForLbDrumsLabel</param>
        /// <param name="newNetResinLabel">newNetResinLabel</param>
        /// <param name="newCatalystLabel">newCatalystLabel</param> 
        /// 
        /// <param name="newInversionComment">newInversionComment</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
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
        /// <param name="newTempT2">newTempT2</param>
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
        /// <param name="newInversionLinerTubeLabel">newInversionLinerTubeLabel</param>
        /// <param name="newHeadsIdealLabel">newHeadsIdealLabel</param>
        /// <param name="newPumpingAndCirculationLabel">newPumpingAndCirculationLabel</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>     
        /// <param name="includeWetOutInformation">includeWetOutInformation</param>
        /// <param name="includeInversionInformation">includeInversionInformation</param>        
        private void UpdateWorkWetOutInformation(int workId, string originalLinerTube, int originalResinID, decimal originalExcessResin, string originalPoundsDrums, decimal originalDrumDiameter, decimal originalHoistMaximumHeight, decimal originalHoistMinimumHeight, decimal originalDownDropTubeLenght, decimal originalPumpHeightAboveGround, int originalTubeResinToFeltFactor, DateTime originalDateOfSheet, int originalEmployeeID, string originalRunDetails, string originalRunDetails2, DateTime originalWetOutDate, DateTime? originalWetOutInstallDate, string originalThickness, decimal originalLengthToLine, decimal originalPlusExtra, decimal originalForTurnOffset, decimal originalLengthToWetOut, decimal originalTubeMaxColdHead, decimal originalTubeMaxColdHeadPsi, decimal originalTubeMaxHotHead, decimal originalTubeMaxHotHeadPsi, decimal originalTubeIdealHead, decimal originalTubeIdealHeadPsi, decimal originalNetResinForTube, decimal originalNetResinForTubeUsgals, string originalNetResinForTubeDrumsIns, decimal originalNetResinForTubeLbsFt, decimal originalNetResinForTubeUsgFt, int originalExtraResinForMix, decimal originalExtraLbsForMix, decimal originalTotalMixQuantity, decimal originalTotalMixQuantityUsgals, string originalTotalMixQuantityDrumsIns, string originalInversionType, decimal originalDepthOfInversionMH, decimal originalTubeForColumn, decimal originalTubeForStartDry, decimal originalTotalTube, string originalDropTubeConnects, decimal originalAllowsHeadTo, decimal originalRollerGap, decimal originalHeightNeeded, string originalAvailable, string originalHoistHeight, string originalCommentsCipp, string originalResinsLabel, string origianlDrumContainsLabel, string originalLinerTubeLabel, string originalForLbDrumsLabel, string originalNetResinLabel, string originalCatalystLabel, string originalInversionComment, string originalPipeType, string originalPipeCondition, string originalGroundMoisture, decimal originalBoilerSize, decimal originalPumpTotalCapacity, decimal originalLayFlatSize, decimal originalLayFlatQuantityTotal, decimal originalWaterStartTemp, decimal originalTemp1, decimal originalHoldAtT1, decimal originalTempT2, decimal originalCookAtT2, decimal originalCoolDownFor, decimal originalCoolToTemp, decimal originalDropInPipeRun, decimal originalPipeSlopOf, decimal originalF45F120, decimal originalHold, decimal originalF120F185, decimal originalCookTime, decimal originalCoolTime, decimal originalAproxTotal, decimal originalWaterChangesPerHour, decimal originalReturnWaterVelocity, decimal originalLayflatBackPressure, decimal originalPumpLiftAtIdealHead, decimal originalWaterToFillLinerColumn, decimal originalWaterPerFit, string originalInstallationResults, string originalInversionLinerTubeLabel, string originalHeadsIdealLabel, string originalPumpingAndCirculationLabel, bool originalDeleted, int originalCompanyId, string newLinerTube, int newResinID, decimal newExcessResin, string newPoundsDrums, decimal newDrumDiameter, decimal newHoistMaximumHeight, decimal newHoistMinimumHeight, decimal newDownDropTubeLenght, decimal newPumpHeightAboveGround, int newTubeResinToFeltFactor, DateTime newDateOfSheet, int newEmployeeID, string newRunDetails, string newRunDetails2, DateTime newWetOutDate, DateTime? newWetOutInstallDate, string newThickness, decimal newLengthToLine, decimal newPlusExtra, decimal newForTurnOffset, decimal newLengthToWetOut, decimal newTubeMaxColdHead, decimal newTubeMaxColdHeadPsi, decimal newTubeMaxHotHead, decimal newTubeMaxHotHeadPsi, decimal newTubeIdealHead, decimal newTubeIdealHeadPsi, decimal newNetResinForTube, decimal newNetResinForTubeUsgals, string newNetResinForTubeDrumsIns, decimal newNetResinForTubeLbsFt, decimal newNetResinForTubeUsgFt, int newExtraResinForMix, decimal newExtraLbsForMix, decimal newTotalMixQuantity, decimal newTotalMixQuantityUsgals, string newTotalMixQuantityDrumsIns, string newInversionType, decimal newDepthOfInversionMH, decimal newTubeForColumn, decimal newTubeForStartDry, decimal newTotalTube, string newDropTubeConnects, decimal newAllowsHeadTo, decimal newRollerGap, decimal newHeightNeeded, string newAvailable, string newHoistHeight, string newCommentsCipp, string newResinsLabel, string newDrumContainsLabel, string newLinerTubeLabel, string newForLbDrumsLabel, string newNetResinLabel, string newCatalystLabel, string newInversionComment, string newPipeType, string newPipeCondition, string newGroundMoisture, decimal newBoilerSize, decimal newPumpTotalCapacity, decimal newLayFlatSize, decimal newLayFlatQuantityTotal, decimal newWaterStartTemp, decimal newTemp1, decimal newHoldAtT1, decimal newTempT2, decimal newCookAtT2, decimal newCoolDownFor, decimal newCoolToTemp, decimal newDropInPipeRun, decimal newPipeSlopOf, decimal newF45F120, decimal newHold, decimal newF120F185, decimal newCookTime, decimal newCoolTime, decimal newAproxTotal, decimal newWaterChangesPerHour, decimal newReturnWaterVelocity, decimal newLayflatBackPressure, decimal newPumpLiftAtIdealHead, decimal newWaterToFillLinerColumn, decimal newWaterPerFit, string newInstallationResults, string newInversionLinerTubeLabel, string newHeadsIdealLabel, string newPumpingAndCirculationLabel, bool newDeleted, int newCompanyId, bool includeWetOutInformation, bool includeInversionInformation)
        {                               
            // Update wet out data
            if (includeWetOutInformation)
            {
                WorkFullLengthLiningWetOut workFullLengthLiningWetOut = new WorkFullLengthLiningWetOut(null);
                workFullLengthLiningWetOut.UpdateDirect(workId, originalLinerTube, originalResinID, originalExcessResin, originalPoundsDrums, originalDrumDiameter, originalHoistMaximumHeight, originalHoistMinimumHeight, originalDownDropTubeLenght, originalPumpHeightAboveGround, originalTubeResinToFeltFactor, originalDateOfSheet, originalEmployeeID, originalRunDetails, originalRunDetails2, originalWetOutDate, originalWetOutInstallDate, originalThickness, originalLengthToLine, originalPlusExtra, originalForTurnOffset, originalLengthToWetOut, originalTubeMaxColdHead, originalTubeMaxColdHeadPsi, originalTubeMaxHotHead, originalTubeMaxHotHeadPsi, originalTubeIdealHead, originalTubeIdealHeadPsi, originalNetResinForTube, originalNetResinForTubeUsgals, originalNetResinForTubeDrumsIns, originalNetResinForTubeLbsFt, originalNetResinForTubeUsgFt, originalExtraResinForMix, originalExtraLbsForMix, originalTotalMixQuantity, originalTotalMixQuantityUsgals, originalTotalMixQuantityDrumsIns, originalInversionType, originalDepthOfInversionMH, originalTubeForColumn, originalTubeForStartDry, originalTotalTube, originalDropTubeConnects, originalAllowsHeadTo, originalRollerGap, originalHeightNeeded, originalAvailable, originalHoistHeight, originalCommentsCipp, originalResinsLabel, origianlDrumContainsLabel, originalLinerTubeLabel, originalForLbDrumsLabel, originalNetResinLabel, originalCatalystLabel, originalDeleted, originalCompanyId, workId, newLinerTube, newResinID, newExcessResin, newPoundsDrums, newDrumDiameter, newHoistMaximumHeight, newHoistMinimumHeight, newDownDropTubeLenght, newPumpHeightAboveGround, newTubeResinToFeltFactor, newDateOfSheet, newEmployeeID, newRunDetails, newRunDetails2, newWetOutDate, newWetOutInstallDate, newThickness, newLengthToLine, newPlusExtra, newForTurnOffset, newLengthToWetOut, newTubeMaxColdHead, newTubeMaxColdHeadPsi, newTubeMaxHotHead, newTubeMaxHotHeadPsi, newTubeIdealHead, newTubeIdealHeadPsi, newNetResinForTube, newNetResinForTubeUsgals, newNetResinForTubeDrumsIns, newNetResinForTubeLbsFt, newNetResinForTubeUsgFt, newExtraResinForMix, newExtraLbsForMix, newTotalMixQuantity, newTotalMixQuantityUsgals, newTotalMixQuantityDrumsIns, newInversionType, newDepthOfInversionMH, newTubeForColumn, newTubeForStartDry, newTotalTube, newDropTubeConnects, newAllowsHeadTo, newRollerGap, newHeightNeeded, newAvailable, newHoistHeight, newCommentsCipp, newResinsLabel, newDrumContainsLabel, newLinerTubeLabel, newForLbDrumsLabel, newNetResinLabel, newCatalystLabel, newDeleted, newCompanyId);
            }

            // Update inversion data
            if (includeInversionInformation)
            {
                WorkFullLengthLiningInversion workFullLengthLiningInversion = new WorkFullLengthLiningInversion(null);
                workFullLengthLiningInversion.UpdateDirect(workId, originalInversionComment, originalPipeType, originalPipeCondition, originalGroundMoisture, originalBoilerSize, originalPumpTotalCapacity, originalLayFlatSize, originalLayFlatQuantityTotal, originalWaterStartTemp, originalTemp1, originalHoldAtT1, originalTempT2, originalCookAtT2, originalCoolDownFor, originalCoolToTemp, originalDropInPipeRun, originalPipeSlopOf, originalF45F120, originalHold, originalF120F185, originalCookTime, originalCoolTime, originalAproxTotal, originalWaterChangesPerHour, originalReturnWaterVelocity, originalLayflatBackPressure, originalPumpLiftAtIdealHead, originalWaterToFillLinerColumn, originalWaterPerFit, originalInstallationResults, originalInversionLinerTubeLabel, originalHeadsIdealLabel, originalPumpingAndCirculationLabel, originalDeleted, originalCompanyId, workId, newInversionComment, newPipeType, newPipeCondition, newGroundMoisture, newBoilerSize, newPumpTotalCapacity, newLayFlatSize, newLayFlatQuantityTotal, newWaterStartTemp, newTemp1, newHoldAtT1, newTempT2, newCookAtT2, newCoolDownFor, newCoolToTemp, newDropInPipeRun, newPipeSlopOf, newF45F120, newHold, newF120F185, newCookTime, newCoolTime, newAproxTotal, newWaterChangesPerHour, newReturnWaterVelocity, newLayflatBackPressure, newPumpLiftAtIdealHead, newWaterToFillLinerColumn, newWaterPerFit, newInstallationResults, newInversionLinerTubeLabel, newHeadsIdealLabel, newPumpingAndCirculationLabel, newDeleted, newCompanyId);
            }
        }



        /// <summary>
        /// InsertWorkWetOutInformation
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="newLinerTube">newLinerTube</param>
        /// <param name="newResinID">newResinID</param>
        /// <param name="newExcessResin">newExcessResin</param>
        /// <param name="newPoundsDrums">newPoundsDrums</param>
        /// <param name="newDrumDiameter">newDrumDiameter</param>
        /// <param name="newHoistMaximumHeight">newHoistMaximumHeight</param>
        /// <param name="newHoistMinimumHeight">newHoistMinimumHeight</param>
        /// <param name="newDownDropTubeLenght">newDownDropTubeLenght</param>
        /// <param name="newPumpHeightAboveGround">newPumpHeightAboveGround</param>
        /// <param name="newTubeResinToFeltFactor">newTubeResinToFeltFactor</param>
        /// <param name="newDateOfSheet">newDateOfSheet</param>
        /// <param name="newEmployeeID">newEmployeeID</param>
        /// <param name="newRunDetails">newRunDetails</param>
        /// <param name="newRunDetails2">newRunDetails2</param>
        /// <param name="newWetOutDate">newWetOutDate</param>
        /// <param name="newWetOutInstallDate">newWetOutInstallDate</param>
        /// <param name="newThickness">newThickness</param>
        /// <param name="newLengthToLine">newLengthToLine</param>
        /// <param name="newPlusExtra">newPlusExtra</param>
        /// <param name="newPlusExtra">newPlusExtra</param>
        /// <param name="newForTurnOffset">newForTurnOffset</param>
        /// <param name="newLengthToWetOut">newLengthToWetOut</param>
        /// <param name="newTubeMaxColdHead">newTubeMaxColdHead</param>
        /// <param name="newTubeMaxColdHeadPsi">newTubeMaxColdHeadPsi</param>
        /// <param name="newTubeMaxHotHead">newTubeMaxHotHead</param>        
        /// <param name="newTubeMaxHotHeadPsi">newTubeMaxHotHeadPsi</param>
        /// <param name="newTubeIdealHead">newTubeIdealHead</param>
        /// <param name="newTubeIdealHeadPsi">newTubeIdealHeadPsi</param>
        /// <param name="newNetResinForTube">newNetResinForTube</param>
        /// <param name="newNetResinForTubeUsgals">newNetResinForTubeUsgals</param>
        /// <param name="newNetResinForTubeDrumsIns">newNetResinForTubeDrumsIns</param>
        /// <param name="newNetResinForTubeLbsFt">newNetResinForTubeLbsFt</param>
        /// <param name="newNetResinForTubeUsgFt">newNetResinForTubeUsgFt</param>
        /// <param name="newExtraResinForMix">newExtraResinForMix</param>
        /// <param name="newExtraLbsForMix">newExtraLbsForMix</param>
        /// <param name="newTotalMixQuantity">newTotalMixQuantity</param>
        /// <param name="newTotalMixQuantityUsgals">newTubeMaxHotHead</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>        
        /// <param name="newTotalMixQuantityDrumsIns">newTotalMixQuantityDrumsIns</param>
        /// <param name="newInversionType">newInversionType</param>
        /// <param name="newDepthOfInversionMH">newDepthOfInversionMH</param>
        /// <param name="newTubeForColumn">newTubeForColumn</param>
        /// <param name="newTubeForStartDry">newTubeForStartDry</param>
        /// <param name="newTotalTube">newTotalTube</param>
        /// <param name="newDropTubeConnects">newDropTubeConnects</param>
        /// <param name="newAllowsHeadTo">newAllowsHeadTo</param>
        /// <param name="newRollerGap">newRollerGap</param>
        /// <param name="newHeightNeeded">newHeightNeeded</param>
        /// <param name="newAvailable">newAvailable</param>
        /// <param name="newHoistHeight">newHoistHeight</param>
        /// <param name="newCommentsCipp">newCommentsCipp</param>
        /// <param name="newResinsLabel">newResinsLabel</param>
        /// <param name="newDrumContainsLabel">newDrumContainsLabel</param>
        /// <param name="newLinerTubeLabel">newLinerTubeLabel</param>
        /// <param name="newForLbDrumsLabel">newForLbDrumsLabel</param>
        /// <param name="newNetResinLabel">newNetResinLabel</param>
        /// <param name="newCatalystLabel">newCatalystLabel</param> 
        /// 
        /// 
        /// <param name="newInversionComment">newInversionComment</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
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
        /// <param name="newTempT2">newTempT2</param>
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
        /// <param name="newInversionLinerTubeLabel">newInversionLinerTubeLabel</param>
        /// <param name="newHeadsIdealLabel">newHeadsIdealLabel</param>       
        /// <param name="newPumpingAndCirculationLabel">newPumpingAndCirculationLabel</param>        
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>   
        /// <param name="includeWetOutInformation">includeWetOutInformation</param>
        /// <param name="includeInversionInformation">includeInversionInformation</param>        
        private void InsertWorkWetOutInformation(int workId, string newLinerTube, int newResinID, decimal newExcessResin, string newPoundsDrums, decimal newDrumDiameter, decimal newHoistMaximumHeight, decimal newHoistMinimumHeight, decimal newDownDropTubeLenght, decimal newPumpHeightAboveGround, int newTubeResinToFeltFactor, DateTime newDateOfSheet, int newEmployeeID, string newRunDetails, string newRunDetails2, DateTime newWetOutDate, DateTime? newWetOutInstallDate, string newThickness, decimal newLengthToLine, decimal newPlusExtra, decimal newForTurnOffset, decimal newLengthToWetOut, decimal newTubeMaxColdHead, decimal newTubeMaxColdHeadPsi, decimal newTubeMaxHotHead, decimal newTubeMaxHotHeadPsi, decimal newTubeIdealHead, decimal newTubeIdealHeadPsi, decimal newNetResinForTube, decimal newNetResinForTubeUsgals, string newNetResinForTubeDrumsIns, decimal newNetResinForTubeLbsFt, decimal newNetResinForTubeUsgFt, int newExtraResinForMix, decimal newExtraLbsForMix, decimal newTotalMixQuantity, decimal newTotalMixQuantityUsgals, string newTotalMixQuantityDrumsIns, string newInversionType, decimal newDepthOfInversionMH, decimal newTubeForColumn, decimal newTubeForStartDry, decimal newTotalTube, string newDropTubeConnects, decimal newAllowsHeadTo, decimal newRollerGap, decimal newHeightNeeded, string newAvailable, string newHoistHeight, string newCommentsCipp, string newResinsLabel, string newDrumContainsLabel, string newLinerTubeLabel, string newForLbDrumsLabel, string newNetResinLabel, string newCatalystLabel, string newInversionComment, string newPipeType, string newPipeCondition, string newGroundMoisture, decimal newBoilerSize, decimal newPumpTotalCapacity, decimal newLayFlatSize, decimal newLayFlatQuantityTotal, decimal newWaterStartTemp, decimal newTemp1, decimal newHoldAtT1, decimal newTempT2, decimal newCookAtT2, decimal newCoolDownFor, decimal newCoolToTemp, decimal newDropInPipeRun, decimal newPipeSlopOf, decimal newF45F120, decimal newHold, decimal newF120F185, decimal newCookTime, decimal newCoolTime, decimal newAproxTotal, decimal newWaterChangesPerHour, decimal newReturnWaterVelocity, decimal newLayflatBackPressure, decimal newPumpLiftAtIdealHead, decimal newWaterToFillLinerColumn, decimal newWaterPerFit, string newInstallationResults, string newInversionLinerTubeLabel, string newHeadsIdealLabel, string newPumpingAndCirculationLabel, bool newDeleted, int newCompanyId, bool includeWetOutInformation, bool includeInversionInformation)
        {
            // Update inversion data
            if (includeInversionInformation)
            {
                WorkFullLengthLiningInversion workFullLengthLiningInversion = new WorkFullLengthLiningInversion(null);
                workFullLengthLiningInversion.InsertDirect(workId, newInversionComment, newPipeType, newPipeCondition, newGroundMoisture, newBoilerSize, newPumpTotalCapacity, newLayFlatSize, newLayFlatQuantityTotal, newWaterStartTemp, newTemp1, newHoldAtT1, newTempT2, newCookAtT2, newCoolDownFor, newCoolToTemp, newDropInPipeRun, newPipeSlopOf, newF45F120, newHold, newF120F185, newCookTime, newCoolTime, newAproxTotal, newWaterChangesPerHour, newReturnWaterVelocity, newLayflatBackPressure, newPumpLiftAtIdealHead, newWaterToFillLinerColumn, newWaterPerFit, newInstallationResults, newInversionLinerTubeLabel, newHeadsIdealLabel, newPumpingAndCirculationLabel, newDeleted, newCompanyId);
            }

            // Update wet out data
            if (includeWetOutInformation)
            {
                WorkFullLengthLiningWetOut workFullLengthLiningWetOut = new WorkFullLengthLiningWetOut(null);
                workFullLengthLiningWetOut.InsertDirect(workId, newLinerTube, newResinID, newExcessResin, newPoundsDrums, newDrumDiameter, newHoistMaximumHeight, newHoistMinimumHeight, newDownDropTubeLenght, newPumpHeightAboveGround, newTubeResinToFeltFactor, newDateOfSheet, newEmployeeID, newRunDetails, newRunDetails2, newWetOutDate, newWetOutInstallDate, newThickness, newLengthToLine, newPlusExtra, newForTurnOffset, newLengthToWetOut, newTubeMaxColdHead, newTubeMaxColdHeadPsi, newTubeMaxHotHead, newTubeMaxHotHeadPsi, newTubeIdealHead, newTubeIdealHeadPsi, newNetResinForTube, newNetResinForTubeUsgals, newNetResinForTubeDrumsIns, newNetResinForTubeLbsFt, newNetResinForTubeUsgFt, newExtraResinForMix, newExtraLbsForMix, newTotalMixQuantity, newTotalMixQuantityUsgals, newTotalMixQuantityDrumsIns, newInversionType, newDepthOfInversionMH, newTubeForColumn, newTubeForStartDry, newTotalTube, newDropTubeConnects, newAllowsHeadTo, newRollerGap, newHeightNeeded, newAvailable, newHoistHeight, newCommentsCipp, newResinsLabel, newDrumContainsLabel, newLinerTubeLabel, newForLbDrumsLabel, newNetResinLabel, newCatalystLabel, newDeleted, newCompanyId);
            }
        }



        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Row obtained</returns>
        private FullLengthLiningTDS.WorkDetailsRow GetRow(int workId)
        {
            FullLengthLiningTDS.WorkDetailsRow row = ((FullLengthLiningTDS.WorkDetailsDataTable)Table).FindByWorkID(workId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.FullLengthLining.FullLengthLiningWorkDetails.GetRow");
            }

            return row;
        }



    }
}