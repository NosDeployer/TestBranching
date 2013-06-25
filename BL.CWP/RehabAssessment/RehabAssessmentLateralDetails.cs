using System;
using System.Data;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.DA.CWP.RehabAssessment;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.RehabAssessment
{
    /// <summary>
    /// RehabAssessmentLateralDetails
    /// </summary>
    public class RehabAssessmentLateralDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RehabAssessmentLateralDetails()
            : base("LateralDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RehabAssessmentLateralDetails(DataSet data)
            : base(data, "LateralDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new RehabAssessmentTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllByWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void LoadAllByWorkId(int workId, int companyId)
        {
            RehabAssessmentLateralDetailsGateway rehabAssessmentLateralDetailsGateway = new RehabAssessmentLateralDetailsGateway(Data);
            rehabAssessmentLateralDetailsGateway.LoadAllByWorkId(workId, companyId);
        }



        /// <summary>
        /// LoadForEdit
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="projectId">projectId</param>
        public void LoadForEdit(int workId, int assetId, int companyId, int projectId)
        {
            RehabAssessmentLateralDetailsGateway rehabAssessmentLateralDetailsGateway = new RehabAssessmentLateralDetailsGateway(Data);
            rehabAssessmentLateralDetailsGateway.ClearBeforeFill = false;
            rehabAssessmentLateralDetailsGateway.LoadInWorkInJlForEdit(workId, assetId, companyId);
            rehabAssessmentLateralDetailsGateway.LoadInWorkForEdit(workId, assetId, companyId);
            rehabAssessmentLateralDetailsGateway.LoadNotInWorkForEdit(workId, assetId, companyId, projectId);
            rehabAssessmentLateralDetailsGateway.ClearBeforeFill = true;

            UpdateFieldsForSections(assetId, projectId, companyId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="videoDistance">videoDistance</param>
        /// <param name="clockPosition">clockPosition</param>
        /// <param name="distanceToCentre">distanceToCentre</param>
        /// <param name="timeOpened">timeOpened</param>
        /// <param name="reverseSetup">reverseSetup</param>
        /// <param name="reinstate">reinstate</param>
        /// <param name="comments">comments</param>
        /// <param name="lateralId">lateralId</param>
        /// <param name="size">size</param>
        /// <param name="materialType">materialType</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inProject">inProject</param>
        /// <param name="live">live</param>
        /// <param name="clientLateralId">clientLateralId</param>
        /// <param name="inFll">inFll</param>
        /// <param name="inJl">inJl</param>
        /// <param name="connectionType">connectionType</param>
        /// <param name="mn">mn</param>
        /// <param name="clientInspectionNo">clientInspectionNo</param>
        /// <param name="v1Inspection">v1Inspection</param>
        /// <param name="requiresRoboticPrep">requiresRoboticPrep</param>
        /// <param name="requiresRoboticPrepDate">requiresRoboticPrepDate</param>
        /// <param name="holdClientIssue">holdClientIssue</param>
        /// <param name="holdLFSIssue">holdLFSIssue</param>
        /// <param name="lineLateral">lineLateral</param>
        /// <param name="flange">flange</param>
        /// <param name="dyeTestReq">dyeTestReq</param>
        /// <param name="dyeTestComplete">dyeTestComplete</param>
        /// <param name="contractYear">contractYear</param>
        public void Insert(string videoDistance, string clockPosition, string distanceToCentre, string timeOpened, string reverseSetup, DateTime? reinstate, string comments, string lateralId, string size, string materialType, bool deleted, int companyId, bool inProject, string live, string clientLateralId, bool inFll, bool inJl, string connectionType, string mn, string clientInspectionNo, DateTime? v1Inspection, bool requiresRoboticPrep, DateTime? requiresRoboticPrepDate, bool holdClientIssue, bool holdLFSIssue, bool lineLateral, string flange, bool dyeTestReq, DateTime? dyeTestComplete, string contractYear)
        {
            RehabAssessmentTDS.LateralDetailsRow row = ((RehabAssessmentTDS.LateralDetailsDataTable)Table).NewLateralDetailsRow();

            row.Lateral = GetNewLateral();
            if (videoDistance != "") row.VideoDistance = videoDistance; else row.SetVideoDistanceNull();
            if (clockPosition != "") row.ClockPosition = clockPosition; else row.SetClockPositionNull();
            if (distanceToCentre != "") row.DistanceToCentre = distanceToCentre; else row.SetDistanceToCentreNull();
            if (timeOpened != "") row.TimeOpened = timeOpened; else row.SetTimeOpenedNull();
            if (reverseSetup != "") row.ReverseSetup = reverseSetup; else row.SetReverseSetupNull();
            if (reinstate.HasValue) row.Reinstate = (DateTime)reinstate; else row.SetReinstateNull();
            if (comments != "") row.Comments = comments; else row.SetCommentsNull();
            if (lateralId != "") row.LateralID = lateralId;
            if (size != "") row.Size_ = size; else row.SetSize_Null();
            if (materialType != "") row.MaterialType = materialType; else row.SetMaterialTypeNull();
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InProject = inProject;
            row.InProjectDatabase = false;
            row.InDatabase = false;
            if (live != "") row.Live = live; else row.SetLiveNull();
            row.ToProcess = true;
            if (clientLateralId != "") row.ClientLateralID = clientLateralId; else row.SetClientLateralIDNull();
            row.InFll = inFll;
            row.InFllDatabase = false;
            row.InJl = inJl;
            row.InJlDatabase = false;
            if (connectionType != "") row.ConnectionType = connectionType; else row.SetConnectionTypeNull();
            if (mn != "") row.Mn = mn; else row.SetMnNull();
            if (clientInspectionNo != "") row.ClientInspectionNo = clientInspectionNo; else row.SetClientInspectionNoNull();
            if (v1Inspection.HasValue) row.V1Inspection = (DateTime)v1Inspection; else row.SetV1InspectionNull();
            row.RequiresRoboticPrep = requiresRoboticPrep;
            if (requiresRoboticPrepDate.HasValue) row.RequiresRoboticPrepDate = (DateTime)requiresRoboticPrepDate; else row.SetRequiresRoboticPrepDateNull();
            row.HoldClientIssue = holdClientIssue;
            row.HoldLFSIssue = holdLFSIssue;
            row.LineLateral = lineLateral;
            if (flange != "") row.Flange = flange; else row.SetFlangeNull();   
            if (videoDistance != "") row.DistanceFromUSMH = videoDistance; else row.SetDistanceFromUSMHNull();
            if (reverseSetup != "") row.DistanceFromDSMH = reverseSetup; else row.SetDistanceFromDSMHNull();
            row.DyeTestReq = dyeTestReq;
            if (dyeTestComplete.HasValue) row.DyeTestComplete = (DateTime)dyeTestComplete; else row.SetDyeTestCompleteNull();
            row.ContractYear = contractYear;

            ((RehabAssessmentTDS.LateralDetailsDataTable)Table).AddLateralDetailsRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="refId">refId</param>
        /// <param name="lateralId">lateralId</param>
        /// <param name="size">size</param>
        /// <param name="materialType">materialType</param>
        /// <param name="live">live</param>
        /// <param name="videoDistance">videoDistance</param>
        /// <param name="clockPosition">clockPosition</param>
        /// <param name="distanceToCentre">distanceToCentre</param>
        /// <param name="timeOpened">timeOpened</param>
        /// <param name="reverseSetup">reverseSetup</param>
        /// <param name="reinstate">reinstate</param>
        /// <param name="comments">comments</param>
        /// <param name="inProject">inProject</param>
        /// <param name="clientLateralId">clientLateralId</param>
        /// <param name="inFll">inFll</param>
        /// <param name="inJl">inJl</param>
        /// <param name="connectionType">connectionType</param>
        /// <param name="mn">mn</param>
        /// <param name="clientInspectionNo">clientInspectionNo</param>
        /// <param name="v1Inspection">v1Inspection</param>
        /// <param name="requiresRoboticPrep">requiresRoboticPrep</param>
        /// <param name="requiresRoboticPrepDate">requiresRoboticPrepDate</param>
        /// <param name="holdClientIssue">holdClientIssue</param>
        /// <param name="holdLFSIssue">holdLFSIssue</param>
        /// <param name="lineLateral">lineLateral</param>
        /// <param name="flange">flange</param>
        /// <param name="dyeTestReq">dyeTestReq</param>
        /// <param name="dyeTestComplete">dyeTestComplete</param>
        /// <param name="contractYear">contractYear</param>
        public void Update(int refId, string lateralId, string size, string materialType, string live, string videoDistance, string clockPosition, string distanceToCentre, string timeOpened, string reverseSetup, DateTime? reinstate, string comments, bool inProject, string clientLateralId, bool inFll, bool inJl, string connectionType, string mn, string clientInspectionNo, DateTime? v1Inspection, bool requiresRoboticPrep, DateTime? requiresRoboticPrepDate, bool holdClientIssue, bool holdLFSIssue, bool lineLateral, string flange, bool dyeTestReq, DateTime? dyeTestComplete, string contractYear)
        {
            RehabAssessmentTDS.LateralDetailsRow row = GetRow(refId);

            if (lateralId != "") row.LateralID = lateralId;
            if (size != "") row.Size_ = size; else row.SetSize_Null();
            if (materialType != "") row.MaterialType = materialType; else row.SetMaterialTypeNull();
            if (live != "") row.Live = live; else row.SetLiveNull();
            if (videoDistance != "") row.VideoDistance = videoDistance; else row.SetVideoDistanceNull();
            if (clockPosition != "") row.ClockPosition = clockPosition; else row.SetClockPositionNull();
            if (distanceToCentre != "") row.DistanceToCentre = distanceToCentre; else row.SetDistanceToCentreNull();
            if (timeOpened != "") row.TimeOpened = timeOpened; else row.SetTimeOpenedNull();
            if (reverseSetup != "") row.ReverseSetup = reverseSetup; else row.SetReverseSetupNull();
            if (reinstate.HasValue) row.Reinstate = (DateTime)reinstate; else row.SetReinstateNull();
            if (comments != "") row.Comments = comments; else row.SetCommentsNull();
            row.InProject = inProject;
            row.ToProcess = true;
            if (clientLateralId != "") row.ClientLateralID = clientLateralId; else row.SetClientLateralIDNull();
            row.InFll = inFll;
            row.InJl = inJl;
            if (connectionType != "") row.ConnectionType = connectionType; else row.SetConnectionTypeNull();
            if (mn != "") row.Mn = mn; else row.SetMnNull();
            if (clientInspectionNo != "") row.ClientInspectionNo = clientInspectionNo; else row.SetClientInspectionNoNull();
            if (v1Inspection.HasValue) row.V1Inspection = (DateTime)v1Inspection; else row.SetV1InspectionNull();
            if (videoDistance != "") row.DistanceFromUSMH = videoDistance; else row.SetDistanceFromUSMHNull();
            if (reverseSetup != "") row.DistanceFromDSMH = reverseSetup; else row.SetDistanceFromDSMHNull();            
            row.RequiresRoboticPrep = requiresRoboticPrep;
            if (requiresRoboticPrepDate.HasValue) row.RequiresRoboticPrepDate = (DateTime)requiresRoboticPrepDate; else row.SetRequiresRoboticPrepDateNull();
            row.HoldClientIssue = holdClientIssue;
            row.HoldLFSIssue = holdLFSIssue;
            row.LineLateral = lineLateral;
            if (flange != "") row.Flange = flange; else row.SetFlangeNull();
            row.DyeTestReq = dyeTestReq;
            if (dyeTestComplete.HasValue) row.DyeTestComplete = (DateTime)dyeTestComplete; else row.SetDyeTestCompleteNull();
            row.ContractYear = contractYear;
        }



        /// <summary>
        /// UpdateLengthReverseSetup
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="videoLength">videoLength</param>
        public void UpdateLengthReverseSetup(int workId, int assetId, string videoLength)
        {
            foreach (RehabAssessmentTDS.LateralDetailsRow row in (RehabAssessmentTDS.LateralDetailsDataTable)Table)
            {
                // Reverse Setup and Distance From DSMH calculation
                string videoDistance = ""; if (!row.IsVideoDistanceNull()) videoDistance = row.VideoDistance;
                string reverseSetup = "";
                Distance videoLengthD = new Distance(videoLength);

                if (videoDistance != "")
                {
                    Distance videoDistanceD = new Distance(videoDistance);
                    Distance reverseSetupD = videoLengthD - videoDistanceD;

                    switch (videoDistanceD.DistanceType)
                    {
                        case 1:
                            reverseSetup = reverseSetupD.ToStringInEng1();
                            break;
                        case 2:
                            reverseSetup = reverseSetupD.ToStringInEng2();
                            break;
                        case 3:
                            reverseSetup = reverseSetupD.ToStringInEng3();
                            break;
                        case 4:
                            reverseSetup = reverseSetupD.ToStringInMet1();
                            break;
                        case 5:
                            reverseSetup = reverseSetupD.ToStringInMil1();
                            break;
                    }
                }

                row.ReverseSetup = reverseSetup;
                row.DistanceFromDSMH = reverseSetup;
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="refId">refId</param>
        public void Delete(int refId)
        {
            RehabAssessmentTDS.LateralDetailsRow row = GetRow(refId);
            row.Deleted = true;
            row.ToProcess = true;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="workId">workId</param>
        public void DeleteAll(int workId)
        {
            foreach (RehabAssessmentTDS.LateralDetailsRow row in (RehabAssessmentTDS.LateralDetailsDataTable)Table)
            {
                row.Deleted = true;
            }
        }



        /// <summary>
        /// Save all sections & works to database (direct)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="sectionAssetId">sectionAssetId</param>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="length">length</param>
        /// <param name="companyId">companyId</param>
        /// <param name="isNewMeasuredFromDsmh">isNewMeasuredFromDsmh</param>
        /// <param name="prepDataRoboticPrep">prepDataRoboticPrep</param>
        /// <param name="prepDataRoboticPrepCompleted">prepDataRoboticPrepCompleted</param>
        public void Save(int workId, int projectId, int sectionAssetId, Int64 countryId, Int64? provinceId, Int64? countyId, Int64? cityId, string length, int companyId, bool isNewMeasuredFromDsmh, bool prepDataRoboticPrep, DateTime? prepDataRoboticPrepCompleted)
        {
            // Update Laterals
            RehabAssessmentLateralDetailsGateway rehabAssessmentLateralDetailsGateway = new RehabAssessmentLateralDetailsGateway(Data);

            if (rehabAssessmentLateralDetailsGateway.Table.Rows.Count > 0)
            {
                // Get WorkId
                if (workId == 0)
                {
                    WorkFullLengthLining workFullLengthLining = new WorkFullLengthLining(null);
                    workId = workFullLengthLining.InsertDirectEmptyWorks(projectId, sectionAssetId, null, "", null, null, null, null, null, null, null, false, false, false, false, false, false, false, companyId, false, "", "");
                }

                foreach (RehabAssessmentTDS.LateralDetailsRow row in (RehabAssessmentTDS.LateralDetailsDataTable)Table)
                {
                    int lateral = row.Lateral;

                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);
                    int clientId = projectGateway.GetClientID(projectId);

                    // ... Insert lateral
                    if ((!row.InDatabase) && (!row.Deleted))
                    {
                        string videoDistance = rehabAssessmentLateralDetailsGateway.GetVideoDistance(lateral);
                        string clockPosition = rehabAssessmentLateralDetailsGateway.GetClockPosition(lateral);
                        string distanceToCentre = rehabAssessmentLateralDetailsGateway.GetDistanceToCentre(lateral);
                        string timeOpened = rehabAssessmentLateralDetailsGateway.GetTimeOpened(lateral);
                        string reverseSetup = rehabAssessmentLateralDetailsGateway.GetReverseSetup(lateral);
                        DateTime? reinstate = rehabAssessmentLateralDetailsGateway.GetReinstate(lateral);
                        string comments = rehabAssessmentLateralDetailsGateway.GetComments(lateral);
                        string clientLateralId = rehabAssessmentLateralDetailsGateway.GetClientLateralId(lateral);
                        string clientInspectionNo = rehabAssessmentLateralDetailsGateway.GetClientInspectionNo(lateral);
                        DateTime? v1Inspection = rehabAssessmentLateralDetailsGateway.GetV1Inspection(lateral);
                        bool requiredRoboticPrep = rehabAssessmentLateralDetailsGateway.GetRequiresRoboticPrep(lateral);
                        DateTime? requiredRoboticPrepDate = rehabAssessmentLateralDetailsGateway.GetRequiresRoboticPrepDate(lateral);
                        bool holdClientIssue = rehabAssessmentLateralDetailsGateway.GetHoldClientIssue(lateral);
                        bool holdLFSIssue = rehabAssessmentLateralDetailsGateway.GetHoldLFSIssue(lateral);
                        bool lineLateral = rehabAssessmentLateralDetailsGateway.GetLineLateral(lateral);
                        string flange = rehabAssessmentLateralDetailsGateway.GetFlange(lateral);
                        bool dyeTestReq = rehabAssessmentLateralDetailsGateway.GetDyeTestReq(lateral);
                        DateTime? dyeTestComplete = null; if (rehabAssessmentLateralDetailsGateway.GetDyeTestComplete(lateral).HasValue) dyeTestComplete = rehabAssessmentLateralDetailsGateway.GetDyeTestComplete(lateral);
                        string contractYear = rehabAssessmentLateralDetailsGateway.GetContractYear(lateral);

                        // ... ... Insert asset
                        int lateral_assetId = SaveLateral(row, projectId, sectionAssetId, countryId, provinceId, countyId, cityId, companyId, isNewMeasuredFromDsmh);

                        // ... ... Insert lateral to FulllengthLining
                        InsertFLLLateral(workId, lateral_assetId, videoDistance, clockPosition, distanceToCentre, timeOpened, reverseSetup, reinstate, comments, false, companyId, clientInspectionNo, v1Inspection, requiredRoboticPrep, requiredRoboticPrepDate, holdClientIssue, holdLFSIssue, lineLateral, dyeTestReq, dyeTestComplete, contractYear);

                        // ... ... If lateral will be in Junction Lining
                        if ((row.LineLateral) && (!row.InJlDatabase))
                        {
                            if (((!prepDataRoboticPrep) && (!prepDataRoboticPrepCompleted.HasValue)) || ((prepDataRoboticPrep) && (prepDataRoboticPrepCompleted.HasValue)))
                            {
                                // ... ... Load work id
                                int sectionWorkId = 0;
                                WorkJunctionLiningSection workJunctionLiningSection = new WorkJunctionLiningSection(null);
                                sectionWorkId = workJunctionLiningSection.InsertDirect(projectId, sectionAssetId, null, 0, 0, false, "No", 0, 0, false, companyId, "", "", "", "", false, "", 0);

                                WorkJunctionLiningLateralGateway workJunctionLiningLateralGateway = new WorkJunctionLiningLateralGateway();
                                WorkJunctionLiningLateral workJunctionLiningLateral = new WorkJunctionLiningLateral(workJunctionLiningLateralGateway.Data);
                                workJunctionLiningLateral.InsertDirect(projectId, lateral_assetId, sectionWorkId, null, null, null, null, null, null, null, null, null, "", null, null, null, 0, null, null, null, 0, v1Inspection, true, false, "", false, null, null, false, companyId, "", "", "", false, null, "", flange, "", "", false, null, false, null, false, holdClientIssue, null, holdLFSIssue, null, requiredRoboticPrep, requiredRoboticPrepDate, "", "", dyeTestReq, dyeTestComplete, contractYear);
                            }
                        }

                        // ... Insert material for M1 lateral
                        try
                        {
                            string material = rehabAssessmentLateralDetailsGateway.GetMaterialType(lateral);
                            if (material != "")
                            {
                                InsertMaterial(lateral_assetId, material, companyId);
                            }
                        }
                        catch { }

                        //... Insert client lateral id
                        try
                        {
                            if (clientLateralId.Trim() != "")
                            {
                                LfsAssetSewerLateralClient lfsAssetSewerLateralClient = new LfsAssetSewerLateralClient(null);
                                lfsAssetSewerLateralClient.InsertDirect(lateral_assetId, clientId, clientLateralId, false, companyId);
                            }
                        }
                        catch { }
                    }

                    // ... Edit laterals
                    if ((row.InDatabase) && (!row.Deleted))
                    {
                        // original values
                        string originalVideoDistance = rehabAssessmentLateralDetailsGateway.GetVideoDistanceOriginal(lateral);
                        string originalClockPosition = rehabAssessmentLateralDetailsGateway.GetClockPositionOriginal(lateral);
                        string originalDistanceToCentre = rehabAssessmentLateralDetailsGateway.GetDistanceToCentreOriginal(lateral);
                        string originalTimeOpened = rehabAssessmentLateralDetailsGateway.GetTimeOpenedOriginal(lateral);
                        string originalReverseSetup = rehabAssessmentLateralDetailsGateway.GetReverseSetupOriginal(lateral);
                        DateTime? originalReinstate = rehabAssessmentLateralDetailsGateway.GetReinstateOriginal(lateral);
                        string originalComments = rehabAssessmentLateralDetailsGateway.GetCommentsOriginal(lateral);
                        string originalClientLateralId = rehabAssessmentLateralDetailsGateway.GetClientLateralIdOriginal(lateral);
                        string originalClientInspectionNo = rehabAssessmentLateralDetailsGateway.GetClientInspectionNoOriginal(lateral);
                        DateTime? originalV1Inspection = rehabAssessmentLateralDetailsGateway.GetV1InspectionOriginal(lateral);
                        bool originalRequiresRoboticPrep = rehabAssessmentLateralDetailsGateway.GetRequiresRoboticPrepOriginal(lateral);
                        DateTime? originalRequiresRoboticPrepDate = rehabAssessmentLateralDetailsGateway.GetRequiresRoboticPrepDateOriginal(lateral);
                        bool originalHoldClientIssue = rehabAssessmentLateralDetailsGateway.GetHoldClientIssueOriginal(lateral);
                        bool originalHoldLFSIssue = rehabAssessmentLateralDetailsGateway.GetHoldLFSIssueOriginal(lateral);
                        bool originalLineLateral = rehabAssessmentLateralDetailsGateway.GetLineLateralOriginal(lateral);
                        bool originalDyeTestReq = rehabAssessmentLateralDetailsGateway.GetDyeTestReqOriginal(lateral);
                        DateTime? originalDyeTestComplete = null; if (rehabAssessmentLateralDetailsGateway.GetDyeTestCompleteOriginal(lateral).HasValue) originalDyeTestComplete = rehabAssessmentLateralDetailsGateway.GetDyeTestCompleteOriginal(lateral);
                        string originalContractYear = rehabAssessmentLateralDetailsGateway.GetContractYearOriginal(lateral);

                        // new values
                        string newVideoDistance = rehabAssessmentLateralDetailsGateway.GetVideoDistance(lateral);
                        string newClockPosition = rehabAssessmentLateralDetailsGateway.GetClockPosition(lateral);
                        string newDistanceToCentre = rehabAssessmentLateralDetailsGateway.GetDistanceToCentre(lateral);
                        string newTimeOpened = rehabAssessmentLateralDetailsGateway.GetTimeOpened(lateral);
                        string newReverseSetup = rehabAssessmentLateralDetailsGateway.GetReverseSetup(lateral);
                        DateTime? newReinstate = rehabAssessmentLateralDetailsGateway.GetReinstate(lateral);
                        string newComments = rehabAssessmentLateralDetailsGateway.GetComments(lateral);
                        string newClientLateralId = rehabAssessmentLateralDetailsGateway.GetClientLateralId(lateral);
                        string newClientInspectionNo = rehabAssessmentLateralDetailsGateway.GetClientInspectionNo(lateral);
                        DateTime? newV1Inspection = rehabAssessmentLateralDetailsGateway.GetV1Inspection(lateral);
                        bool newRequiresRoboticPrep = rehabAssessmentLateralDetailsGateway.GetRequiresRoboticPrep(lateral);
                        DateTime? newRequiresRoboticPrepDate = rehabAssessmentLateralDetailsGateway.GetRequiresRoboticPrepDate(lateral);
                        bool newHoldClientIssue = rehabAssessmentLateralDetailsGateway.GetHoldClientIssue(lateral);
                        bool newHoldLFSIssue = rehabAssessmentLateralDetailsGateway.GetHoldLFSIssue(lateral);
                        bool newLineLateral = rehabAssessmentLateralDetailsGateway.GetLineLateral(lateral);
                        string newFlange = rehabAssessmentLateralDetailsGateway.GetFlange(lateral);
                        bool newDyeTestReq = rehabAssessmentLateralDetailsGateway.GetDyeTestReq(lateral);
                        DateTime? newDyeTestComplete = null; if (rehabAssessmentLateralDetailsGateway.GetDyeTestComplete(lateral).HasValue) newDyeTestComplete = rehabAssessmentLateralDetailsGateway.GetDyeTestComplete(lateral);
                        string newContractYear = rehabAssessmentLateralDetailsGateway.GetContractYear(lateral);

                        // ... Update laterals
                        int lateral_assetId = SaveLateral(row, projectId, sectionAssetId, countryId, provinceId, countyId, cityId, companyId, isNewMeasuredFromDsmh);
                        UpdateLateral(row, projectId, sectionAssetId, countryId, provinceId, countyId, cityId, length, companyId);

                        // ... Update if lateral is in FulllenghtLining                    
                        if (!row.InFllDatabase)
                        {
                            WorkFullLengthLiningM1LateralGateway workFullLengthLiningM1LateralGateay = new WorkFullLengthLiningM1LateralGateway();
                            workFullLengthLiningM1LateralGateay.LoadAllByWorkIdLateral(workId, lateral_assetId, companyId);

                            if (workFullLengthLiningM1LateralGateay.Table.Rows.Count == 0)
                            {
                                InsertFLLLateral(workId, lateral_assetId, newVideoDistance, newClockPosition, newDistanceToCentre, newTimeOpened, newReverseSetup, newReinstate, newComments, false, companyId, newClientInspectionNo, newV1Inspection, newRequiresRoboticPrep, newRequiresRoboticPrepDate, newHoldClientIssue, newHoldLFSIssue, newLineLateral, newDyeTestReq, newDyeTestComplete, newContractYear);
                            }
                            else
                            {
                                UpdateFLLLateral(workId, lateral_assetId, originalVideoDistance, originalClockPosition, originalDistanceToCentre, originalTimeOpened, originalReverseSetup, originalReinstate, originalComments, true, companyId, originalClientInspectionNo, originalV1Inspection, originalRequiresRoboticPrep, originalRequiresRoboticPrepDate, originalHoldClientIssue, originalHoldLFSIssue, originalLineLateral, originalDyeTestReq, originalDyeTestComplete, originalContractYear, workId, lateral_assetId, newVideoDistance, newClockPosition, newDistanceToCentre, newTimeOpened, newReverseSetup, newReinstate, newComments, false, companyId, newClientInspectionNo, newV1Inspection, newRequiresRoboticPrep, newRequiresRoboticPrepDate, newHoldClientIssue, newHoldLFSIssue, newLineLateral, newDyeTestReq, newDyeTestComplete, newContractYear);
                            }
                        }
                        else
                        {
                            UpdateFLLLateral(workId, lateral_assetId, originalVideoDistance, originalClockPosition, originalDistanceToCentre, originalTimeOpened, originalReverseSetup, originalReinstate, originalComments, false, companyId, originalClientInspectionNo, originalV1Inspection, originalRequiresRoboticPrep, originalRequiresRoboticPrepDate, originalHoldClientIssue, originalHoldLFSIssue, originalLineLateral, originalDyeTestReq, originalDyeTestComplete, originalContractYear,workId, lateral_assetId, newVideoDistance, newClockPosition, newDistanceToCentre, newTimeOpened, newReverseSetup, newReinstate, newComments, false, companyId, newClientInspectionNo, newV1Inspection, newRequiresRoboticPrep, newRequiresRoboticPrepDate, newHoldClientIssue, newHoldLFSIssue, newLineLateral, newDyeTestReq, newDyeTestComplete, newContractYear);
                        }

                        // ... Update if lateral is in Junction Lining
                        if (row.InJlDatabase)
                        {
                            if (originalLineLateral == newLineLateral)
                            {
                                // ... ... Update jl lateral (clientInspectionNo, v1Inspection, requiredRoboticPrep, requiredRoboticPrepDate, holdClientIssue, holdLFSIssue, flange)
                                UpdateJLLaterals(projectId, lateral_assetId, companyId, newV1Inspection, newClientInspectionNo, newRequiresRoboticPrep, newRequiresRoboticPrepDate, newHoldClientIssue, newHoldLFSIssue, newFlange, newDyeTestReq, newDyeTestComplete, newContractYear);
                            }
                            else
                            {
                                int sectionWorkId = 0;
                                WorkJunctionLiningSection workJunctionLiningSection = new WorkJunctionLiningSection(null);
                                sectionWorkId = workJunctionLiningSection.InsertDirect(projectId, sectionAssetId, null, 0, 0, false, "No", 0, 0, false, companyId, "", "", "", "", false, "", 0);

                                // Delete empty lateral form jl.
                                DeleteJLLaterals(projectId, lateral_assetId, companyId, sectionWorkId);                          
                            }
                        }
                        else
                        {
                            // ... ... Insert if should be in junction Lining
                            if (row.LineLateral)
                            {
                                if (((!prepDataRoboticPrep) && (!prepDataRoboticPrepCompleted.HasValue)) || ((prepDataRoboticPrep) && (prepDataRoboticPrepCompleted.HasValue)))
                                {
                                    int sectionWorkId = 0;

                                    // Insert to jl laterals                                        
                                    WorkJunctionLiningSection workJunctionLiningSection = new WorkJunctionLiningSection(null);
                                    sectionWorkId = workJunctionLiningSection.InsertDirect(projectId, sectionAssetId, null, 0, 0, false, "No", 0, 0, false, companyId, "", "", "", "", false, "", 0);

                                    WorkJunctionLiningLateralGateway workJunctionLiningLateralGateway = new WorkJunctionLiningLateralGateway();
                                    WorkJunctionLiningLateral workJunctionLiningLateral = new WorkJunctionLiningLateral(workJunctionLiningLateralGateway.Data);
                                    workJunctionLiningLateral.InsertDirect(projectId, lateral_assetId, sectionWorkId, null, null, null, null, null, null, null, null, null, "", null, null, null, 0, null, null, null, 0, newV1Inspection, false, false, "", false, null, null, false, companyId, "", "", "", false, null, newClientInspectionNo, newFlange, "", "", false, null, false, null, false, newHoldClientIssue, null, newHoldLFSIssue, null, newRequiresRoboticPrep, newRequiresRoboticPrepDate, "", "", newDyeTestReq, newDyeTestComplete, newContractYear);
                                }
                            }
                        }

                        string material = rehabAssessmentLateralDetailsGateway.GetMaterialType(lateral);
                        if (material != "")
                        {
                            InsertMaterial(lateral_assetId, material, companyId);
                        }

                        try
                        {
                            LfsAssetSewerLateralClientGateway lfsAssetSewerLateralClientGateway = new LfsAssetSewerLateralClientGateway();
                            lfsAssetSewerLateralClientGateway.LoadAllByAssetIdClientId(lateral_assetId, clientId, companyId);

                            if (lfsAssetSewerLateralClientGateway.Table.Rows.Count == 0)
                            {
                                LfsAssetSewerLateralClient lfsAssetSewerLateralClient = new LfsAssetSewerLateralClient(null);
                                lfsAssetSewerLateralClient.InsertDirect(lateral_assetId, clientId, originalClientLateralId, false, companyId);
                            }
                            else
                            {
                                LfsAssetSewerLateralClient lfsAssetSewerLateralClient = new LfsAssetSewerLateralClient(null);
                                string originalClientLateralId2 = lfsAssetSewerLateralClientGateway.GetClientLateralId(lateral_assetId, clientId);

                                lfsAssetSewerLateralClient.UpdateDirect(lateral_assetId, clientId, originalClientLateralId, false, companyId, lateral_assetId, clientId, newClientLateralId, false, companyId);
                            }
                        }
                        catch
                        { }
                    }

                    // ... Delete laterals
                    if ((row.InDatabase) && (row.Deleted))
                    {
                        DeleteFLLLateral(workId, row.Lateral, companyId, clientId);
                    }
                }
            }
        }



        /// <summary>
        /// Verify if a lateral exists for inserting
        /// </summary>
        /// <param name="lateralId">lateralId</param>
        /// <returns>True if the lateral exists, otherwise false</returns>
        public bool ExistsByLateralId(string lateralId)
        {
            string filter = string.Format("(LateralID = '{0}') AND (Deleted = 0)", lateralId);

            if (Table.Select(filter).Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// NotProcess
        /// </summary>
        /// <param name="refId">refId</param>
        public void NotProcess(int refId)
        {
            RehabAssessmentTDS.LateralDetailsRow row = GetRow(refId);
            row.ToProcess = false;
        }



        /// <summary>
        /// GetMaxLateralId2
        /// </summary>
        /// <returns>available lateral id</returns>
        public string GetMaxLateralId2()
        {
            int firstMaxLateralId = 64;
            int secondMaxLateralId = 63;
            int lateralIdAsci = 64;
            string lateralId = "";

            foreach (RehabAssessmentTDS.LateralDetailsRow row in (RehabAssessmentTDS.LateralDetailsDataTable)Table)
            {
                if (!row.Deleted)
                {
                    if (row.LateralID.Length < 5)
                    {
                        lateralId = row.LateralID.Substring(row.LateralID.Length - 1, 1);
                        lateralIdAsci = (int)lateralId[0];
                        
                        if (lateralIdAsci >= firstMaxLateralId)
                        {
                            if (lateralIdAsci < 90 && secondMaxLateralId <64)
                            {
                                firstMaxLateralId = lateralIdAsci;
                            }
                            else
                            {
                                if (secondMaxLateralId < 64)
                                {
                                    secondMaxLateralId = 64;
                                }
                            }
                        }
                    }
                    else
                    {
                        lateralId = row.LateralID.Substring(row.LateralID.Length - 2, 2);
                        lateralIdAsci = (int)lateralId[1];

                        if (lateralIdAsci >= secondMaxLateralId)
                        {
                            secondMaxLateralId = lateralIdAsci;
                        }
                    }
                }
            }

            if (secondMaxLateralId > 63)
            {
                return Convert.ToChar(65).ToString() + Convert.ToChar(secondMaxLateralId+1).ToString();
            }
            else
            {
                return Convert.ToChar(firstMaxLateralId+1).ToString();
            }
        }



        /// <summary>
        /// GetMinLateralId2
        /// </summary>
        /// <returns>available laterals</returns>
        public string GetMinLateralId2()
        {
            int firstMaxLateralId = 91;
            int secondMaxLateralId = 91;
            int lateralIdAsci = 64;
            string lateralId = "";

            foreach (RehabAssessmentTDS.LateralDetailsRow row in (RehabAssessmentTDS.LateralDetailsDataTable)Table)
            {
                if (!row.Deleted)
                {
                    if (row.LateralID.Length < 5)
                    {
                        lateralId = row.LateralID.Substring(row.LateralID.Length - 1, 1);
                        lateralIdAsci = (int)lateralId[0];

                        if (lateralIdAsci <= firstMaxLateralId)
                        {
                            firstMaxLateralId = lateralIdAsci;
                        }
                    }
                    else
                    {
                        lateralId = row.LateralID.Substring(row.LateralID.Length - 2, 2);
                        lateralIdAsci = (int)lateralId[1];

                        if (lateralIdAsci <= secondMaxLateralId)
                        {
                            if (lateralIdAsci > 65)
                            {
                                secondMaxLateralId = lateralIdAsci;
                            }
                            else
                            {
                                secondMaxLateralId = 65;
                            }
                        }
                    }
                }
            }

            if (secondMaxLateralId >= 66)
            {
                return Convert.ToChar(65).ToString() + Convert.ToChar(secondMaxLateralId - 1).ToString();
            }
            else
            {
                return Convert.ToChar(firstMaxLateralId - 1).ToString();
            }
        }



        /// <summary>
        /// GetTotalLaterals
        /// </summary>
        /// <returns></returns>
        public int GetTotalLaterals()
        {
            int totalLaterals = 0;
            foreach (RehabAssessmentTDS.LateralDetailsRow row in (RehabAssessmentTDS.LateralDetailsDataTable)Table)
            {
                if (!row.Deleted)
                {
                    totalLaterals = totalLaterals + 1;
                }
            }

            return totalLaterals;
        }



        /// <summary>
        /// GetLiveLaterals
        /// </summary>
        /// <returns></returns>
        public int GetLiveLaterals()
        {
            int liveLaterals = 0;
            foreach (RehabAssessmentTDS.LateralDetailsRow row in (RehabAssessmentTDS.LateralDetailsDataTable)Table)
            {
                if (!row.Deleted && row.Live == "Live")
                {
                    liveLaterals = liveLaterals + 1;
                }
            }

            return liveLaterals;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// ModifyLateralId
        /// </summary>
        public void ModifyLateralId()
        {
            int lateralIdAsci = 64;
            string lateralId = "";

            int numLaterals = Table.Select("Deleted = 0").Length;

            foreach (RehabAssessmentTDS.LateralDetailsRow row in (RehabAssessmentTDS.LateralDetailsDataTable)Table)
            {
                if (!row.Deleted)
                {
                    if (numLaterals >= 27 && numLaterals <= 51)
                    {
                        if (row.LateralID.Length < 5)
                        {
                            lateralId = row.LateralID.Substring(row.LateralID.Length - 1, 1);
                            lateralIdAsci = (int)lateralId[0];
                            row.LateralID = Convert.ToChar(lateralIdAsci - (52 - numLaterals)).ToString();
                        }
                        else
                        {
                            lateralId = row.LateralID.Substring(row.LateralID.Length - 2, 2);
                            lateralIdAsci = (int)lateralId[1];
                            if ((lateralIdAsci - (26 - numLaterals)) > 90)
                            {
                                row.LateralID = Convert.ToChar(65).ToString() + Convert.ToChar(lateralIdAsci - (52 - numLaterals)).ToString(); ;
                            }
                            else
                            {
                                row.LateralID = Convert.ToChar(lateralIdAsci - (26 - numLaterals)).ToString();
                            }
                        }
                    }

                    if (numLaterals <= 26)
                    {
                        lateralId = row.LateralID.Substring(row.LateralID.Length - 2, 2);
                        lateralIdAsci = (int)lateralId[1];

                        if (row.LateralID.Length == 5)
                        {
                            row.LateralID = Convert.ToChar(lateralIdAsci - (26 - numLaterals)).ToString();
                        }
                    }
                }
            }
        }


        
        /// <summary>
        /// Save a lateral
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="projectId">projectId</param>
        /// <param name="sectionAssetId">sectionAssetId</param>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="isNewMeasuredFromDsmh">isNewMeasuredFromDsmh</param>
        /// <returns>lateral_assetId</returns>
        private int SaveLateral(RehabAssessmentTDS.LateralDetailsRow row, int projectId, int sectionAssetId, Int64 countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int companyId, bool isNewMeasuredFromDsmh)
        {
            int section_ = sectionAssetId;
            string lateralID = row.LateralID;

            if (!isNewMeasuredFromDsmh)
            {
                lateralID = lateralID.Substring(3, lateralID.Length - 3);
            }

            string address = ""; if (!row.IsMnNull()) address = row.Mn;
            string size_ = ""; if (!row.IsSize_Null()) size_ = row.Size_;
            string live = ""; if (!row.IsLiveNull()) live = row.Live;
            string distanceFromUSMH = ""; if (!row.IsDistanceFromUSMHNull()) distanceFromUSMH = row.DistanceFromUSMH;
            string distanceFromDSMH = ""; if (!row.IsDistanceFromDSMHNull()) distanceFromDSMH = row.DistanceFromDSMH;
            string connectionType = ""; if (!row.IsConnectionTypeNull()) connectionType = row.ConnectionType;
           
            LfsAssetSewerLateral lfsAssetSewerLateral = new LfsAssetSewerLateral(null);
            int lateral_assetId = lfsAssetSewerLateral.InsertDirect(countryId, provinceId, countyId, cityId, section_, address, lateralID, "", "", "", "", live, size_, distanceFromUSMH, distanceFromDSMH, "", false, companyId, connectionType);

            return lateral_assetId;
        }



        /// <summary>
        /// Update Lateral
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="projectId">projectId</param>
        /// <param name="sectionAssetId">sectionAssetId</param>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="videoLength">videoLength</param>
        /// <param name="companyId">companyId</param>
        private void UpdateLateral(RehabAssessmentTDS.LateralDetailsRow row, int projectId, int sectionAssetId, Int64 countryId, Int64? provinceId, Int64? countyId, Int64? cityId, string videoLength, int companyId)
        {
            // not modified variables
            RehabAssessmentTDS rehabAssessment = (RehabAssessmentTDS)Data;
            RehabAssessmentLateralDetailsGateway rehabAssessmentLateralDetailsGateway = new RehabAssessmentLateralDetailsGateway(rehabAssessment);
            int lateral = row.Lateral;

            AssetSewerLateralGateway assetSewerLateralGateway = new AssetSewerLateralGateway();
            assetSewerLateralGateway.LoadByAssetId(lateral, companyId);
            
            int section_ = assetSewerLateralGateway.GetSection(lateral);
            string lateralId = assetSewerLateralGateway.GetLateralId(lateral);
            string latitudeAtSection = assetSewerLateralGateway.GetLatitudeAtSection(lateral);
            string longitudeAtSection = assetSewerLateralGateway.GetLongitudeAtSection(lateral);
            string latitudeAtPropertyLine = assetSewerLateralGateway.GetLatitudeAtPropertyLine(lateral);
            string longitudeAtPropertyLine = assetSewerLateralGateway.GetLongitudeAtPropertyLine(lateral);
            string mapSize = assetSewerLateralGateway.GetMapSize(lateral);

            // original values
            string originalState = rehabAssessmentLateralDetailsGateway.GetLiveOriginal(lateral);
            string originalSize = rehabAssessmentLateralDetailsGateway.GetSizeOriginal(lateral);
            string originalDistanceFromUsmh = rehabAssessmentLateralDetailsGateway.GetDistanceFromUSMHOriginal(lateral);
            string originalDistanceFromDsmh = rehabAssessmentLateralDetailsGateway.GetDistanceFromDSMHOriginal(lateral);
            string originalConnectionType = rehabAssessmentLateralDetailsGateway.GetConnectionTypeOriginal(lateral);
            string originalAddress = rehabAssessmentLateralDetailsGateway.GetMnOriginal(lateral);

            // new values
            string newState = rehabAssessmentLateralDetailsGateway.GetLive(lateral);
            string newSize = rehabAssessmentLateralDetailsGateway.GetSize(lateral);
            string newDistanceFromUsmh = rehabAssessmentLateralDetailsGateway.GetDistanceFromUSMH(lateral);
            string newDistanceFromDsmh = rehabAssessmentLateralDetailsGateway.GetDistanceFromDSMH(lateral);
            string newConnectionType = rehabAssessmentLateralDetailsGateway.GetConnectionType(lateral);
            string newAddress = rehabAssessmentLateralDetailsGateway.GetMn(lateral);
            
            // update asset laterals
            AssetSewerLateral assetSewerLateral = new AssetSewerLateral(null);
            assetSewerLateral.UpdateDirect(lateral, section_, originalAddress, lateralId, latitudeAtSection, longitudeAtSection, latitudeAtPropertyLine, longitudeAtPropertyLine, originalState, originalSize, originalDistanceFromUsmh, originalDistanceFromDsmh, mapSize, false, companyId, originalConnectionType, lateral, section_, newAddress, lateralId, latitudeAtSection, longitudeAtSection, latitudeAtPropertyLine, longitudeAtPropertyLine, newState, newSize, newDistanceFromUsmh, newDistanceFromDsmh, mapSize, false, companyId, newConnectionType);
        }



        /// <summary>
        /// Insert a lateral work
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <param name="videoDistance">videoDistance</param>
        /// <param name="clockPosition">clockPosition</param>
        /// <param name="distanceToCentre">distanceToCentre</param>
        /// <param name="timeOpened">timeOpened</param>
        /// <param name="reverseSetup">reverseSetup</param>
        /// <param name="reinstate">reinstate</param>
        /// <param name="comments">comments</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="clientInspectionNo">clientInspectionNo</param>
        /// <param name="v1Inspection">v1Inspection</param>
        /// <param name="requiredRoboticPrep">requiredRoboticPrep</param>
        /// <param name="requiredRoboticPrepDate">requiredRoboticPrepDate</param>
        /// <param name="holdClientIssue">holdClientIssue</param>
        /// <param name="holdLFSIssue">holdLFSIssue</param>
        /// <param name="lineLateral">lineLateral</param>
        /// <param name="dyeTestReq">dyeTestReq</param>
        /// <param name="dyeTestComplete">dyeTestComplete</param>
        /// <param name="contractYear">contractYear</param>
        private void InsertFLLLateral(int workId, int lateral, string videoDistance, string clockPosition, string distanceToCentre, string timeOpened, string reverseSetup, DateTime? reinstate, string comments, bool deleted, int companyId, string clientInspectionNo, DateTime? v1Inspection, bool requiredRoboticPrep, DateTime? requiredRoboticPrepDate, bool holdClientIssue, bool holdLFSIssue, bool lineLateral,bool dyeTestReq, DateTime? dyeTestComplete, string contractYear)
        {
            WorkFullLengthLiningM1LateralGateway workFullLengthLiningM1LateralGateway = new WorkFullLengthLiningM1LateralGateway();
            WorkFullLengthLiningM1Lateral workFullLengthLiningM1Lateral = new WorkFullLengthLiningM1Lateral(workFullLengthLiningM1LateralGateway.Data);
            workFullLengthLiningM1Lateral.InsertDirect(workId, lateral, videoDistance, clockPosition, distanceToCentre, timeOpened, reverseSetup, reinstate, comments, deleted, companyId, clientInspectionNo, v1Inspection, requiredRoboticPrep, requiredRoboticPrepDate, holdClientIssue, holdLFSIssue, lineLateral, dyeTestReq, dyeTestComplete, contractYear);
        }



        /// <summary>
        /// Insert a material
        /// </summary>
        /// <param name="lateral_assetId">lateral_assetId</param>
        /// <param name="material">material</param>
        /// <param name="companyId">companyId</param>
        private void InsertMaterial(int lateral_assetId, string material, int companyId)
        {
            LfsAssetSewerLateralGateway lfsAssetSewertLateralGateway = new LfsAssetSewerLateralGateway(null);
            if (!lfsAssetSewertLateralGateway.IsUsedInMaterials(lateral_assetId, material, companyId))
            {
                MaterialInformationGateway materialInformationGateway = new MaterialInformationGateway();
                materialInformationGateway.LoadAllByAssetId(lateral_assetId, companyId);

                AssetSewerMaterial assetSewerMaterial = new AssetSewerMaterial(materialInformationGateway.Data);
                assetSewerMaterial.InsertDirect(lateral_assetId, materialInformationGateway.Table.Rows.Count + 1, material, DateTime.Now, false, companyId);
            }
        }



        /// <summary>
        /// Update lateral work
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalLateral">originalLateral</param>
        /// <param name="originalVideoDistance">originalVideoDistance</param>
        /// <param name="originalClockPosition">originalClockPosition</param>
        /// <param name="originalDistanceToCentre">originalDistanceToCentre</param>
        /// <param name="originalTimeOpened">originalTimeOpened</param>
        /// <param name="originalReverseSetup">originalReverseSetup</param>
        /// <param name="originalReinstate">originalReinstate</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalClientInspectionNo">originalClientInspectionNo</param>
        /// <param name="originalV1Inspection">originalV1Inspection</param>
        /// <param name="originalRequiresRoboticPrep">originalRequiresRoboticPrep</param>
        /// <param name="originalRequiresRoboticPrepDate">originalRequiresRoboticPrepDate</param>
        /// <param name="originalHoldClientIssue">originalHoldClientIssue</param>
        /// <param name="originalHoldLFSIssue">originalHoldLFSIssue</param>
        /// <param name="originalLineLateral">originalLineLateral</param>
        /// <param name="originalDyeTestReq">originalDyeTestReq</param>
        /// <param name="originalDyeTestComplete">originalDyeTestComplete</param>
        /// <param name="originalContractYear">originalContractYear</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newLateral">newLateral</param>
        /// <param name="newVideoDistance">newVideoDistance</param>
        /// <param name="newClockPosition">newClockPosition</param>
        /// <param name="newDistanceToCentre">newDistanceToCentre</param>
        /// <param name="newTimeOpened">newTimeOpened</param>
        /// <param name="newReverseSetup">newReverseSetup</param>
        /// <param name="newReinstate">newReinstate</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newClientInspectionNo">newClientInspectionNo</param>
        /// <param name="newV1Inspection">newV1Inspection</param>
        /// <param name="newRequiresRoboticPrep">newRequiresRoboticPrep</param>
        /// <param name="newRequiresRoboticPrepDate">newRequiresRoboticPrepDate</param>
        /// <param name="newHoldClientIssue">newHoldClientIssue</param>
        /// <param name="newHoldLFSIssue">newHoldLFSIssue</param>
        /// <param name="newLineLateral">newLineLateral</param>
        /// <param name="newDyeTestReq">newDyeTestReq</param>
        /// <param name="newDyeTestComplete">newDyeTestComplete</param>
        /// <param name="newContractYear">newContractYear</param>
        private void UpdateFLLLateral(int originalWorkId, int originalLateral, string originalVideoDistance, string originalClockPosition, string originalDistanceToCentre, string originalTimeOpened, string originalReverseSetup, DateTime? originalReinstate, string originalComments, bool originalDeleted, int originalCompanyId, string originalClientInspectionNo, DateTime? originalV1Inspection, bool originalRequiresRoboticPrep, DateTime? originalRequiresRoboticPrepDate, bool originalHoldClientIssue, bool originalHoldLFSIssue, bool originalLineLateral, bool originalDyeTestReq, DateTime? originalDyeTestComplete, string originalContractYear, int newWorkId, int newLateral, string newVideoDistance, string newClockPosition, string newDistanceToCentre, string newTimeOpened, string newReverseSetup, DateTime? newReinstate, string newComments, bool newDeleted, int newCompanyId, string newClientInspectionNo, DateTime? newV1Inspection, bool newRequiresRoboticPrep, DateTime? newRequiresRoboticPrepDate, bool newHoldClientIssue, bool newHoldLFSIssue, bool newLineLateral, bool newDyeTestReq, DateTime? newDyeTestComplete, string newContractYear)
        {
            // Update m1 lateral
            WorkFullLengthLiningM1Lateral workFullLengthLiningM1Lateral = new WorkFullLengthLiningM1Lateral(null);
            workFullLengthLiningM1Lateral.UpdateDirect(originalWorkId, originalLateral, originalVideoDistance, originalClockPosition, originalDistanceToCentre, originalTimeOpened, originalReverseSetup, originalReinstate, originalComments, originalDeleted, originalCompanyId, originalClientInspectionNo, originalV1Inspection, originalRequiresRoboticPrep, originalRequiresRoboticPrepDate, originalHoldClientIssue, originalHoldLFSIssue, originalLineLateral, originalDyeTestReq, originalDyeTestComplete, originalContractYear, newWorkId, newLateral, newVideoDistance, newClockPosition, newDistanceToCentre, newTimeOpened, newReverseSetup, newReinstate, newComments, newDeleted, newCompanyId, newClientInspectionNo, newV1Inspection, newRequiresRoboticPrep, newRequiresRoboticPrepDate, newHoldClientIssue, newHoldLFSIssue, newLineLateral, newDyeTestReq, newDyeTestComplete, newContractYear);
        }



        /// <summary>
        /// Delete lateral work
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <param name="companyId">companyId</param>
        /// <param name="clientId">clientId</param>
        private void DeleteFLLLateral(int workId, int lateral, int companyId, int clientId)
        {
            // Delete work lateral
            WorkFullLengthLiningM1Lateral workFullLengthLiningM1Lateral = new WorkFullLengthLiningM1Lateral(null);
            workFullLengthLiningM1Lateral.DeleteDirect(workId, lateral, companyId);

            // Delete section
            LfsAssetSewerLateral lfsAssetSewerLateral = new LfsAssetSewerLateral(null);
            bool isDeleted = lfsAssetSewerLateral.DeleteDirect(lateral, companyId);

            if (isDeleted)
            {
                LfsAssetSewerLateralClient lfsAssetSewerLateralClient = new LfsAssetSewerLateralClient(null);
                lfsAssetSewerLateralClient.DeleteDirect(lateral, clientId, companyId);
            }
        }



        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Row obtained</returns>
        private RehabAssessmentTDS.LateralDetailsRow GetRow(int lateral)
        {
            RehabAssessmentTDS.LateralDetailsRow row = ((RehabAssessmentTDS.LateralDetailsDataTable)Table).FindByLateral(lateral);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.RehabAssessment.RehabAssessmentLateralDetails.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewLateral
        /// </summary>
        /// <returns>newLateral</returns>
        private int GetNewLateral()
        {
            int newLateral = 0;

            foreach (RehabAssessmentTDS.LateralDetailsRow row in (RehabAssessmentTDS.LateralDetailsDataTable)Table)
            {
                if (newLateral < row.Lateral)
                {
                    newLateral = row.Lateral;
                }
            }

            newLateral++;

            return newLateral;
        }



        /// <summary>
        /// UpdateFieldsForSections
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        private void UpdateFieldsForSections(int assetId, int projectId, int companyId)
        {
            foreach (RehabAssessmentTDS.LateralDetailsRow row in (RehabAssessmentTDS.LateralDetailsDataTable)Table)
            {
                if (!row.IsSize_Null())
                {
                    try
                    {
                        if (Distance.IsValidDistance(row.Size_))
                        {
                            Distance distance = new Distance(row.Size_);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.Size_ = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    if (Convert.ToDouble(row.Size_) > 99)
                                    {
                                        double newSize_ = 0;
                                        newSize_ = Convert.ToDouble(row.Size_) * 0.03937;
                                        row.Size_ = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                    }
                                    else
                                    {
                                        if (Validator.IsValidInt32(row.Size_))
                                        {
                                            row.Size_ = row.Size_ + "\"";
                                        }
                                    }
                                    break;
                                case 4:
                                    row.Size_ = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.Size_ = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }



        /// <summary>
        /// UpdateJLLaterals
        /// </summary>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <param name="lateral_assetId">lateral_assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="videoInspection">videoInspection</param>
        /// <param name="clientInspectionNo">clientInspectionNo</param>
        /// <param name="requiredRoboticPrep">requiredRoboticPrep</param>
        /// <param name="requiredRoboticPrepDate">requiredRoboticPrepDate</param>
        /// <param name="holdClientIssue">holdClientIssue</param>
        /// <param name="holdLFSIssue">holdLFSIssue</param>
        /// <param name="flange">flange</param>
        /// <param name="dyeTestReq">dyeTestReq</param>
        /// <param name="dyeTestComplete">dyeTestComplete</param>
        private void UpdateJLLaterals(int currentProjectId, int lateral_assetId, int companyId, DateTime? videoInspection, string clientInspectionNo, bool requiredRoboticPrep, DateTime? requiredRoboticPrepDate, bool holdClientIssue, bool holdLFSIssue, string flange, bool dyeTestReq, DateTime? dyeTestComplete, string contractYear)
        {
            // Load work id
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(currentProjectId, lateral_assetId, "Junction Lining Lateral", companyId);

            if (workGateway.Table.Rows.Count > 0)
            {
                int workId = workGateway.GetWorkId(lateral_assetId, "Junction Lining Lateral", currentProjectId);

                if (workId > 0)
                {
                    WorkJunctionLiningLateralGateway workJunctionLiningLateralGateway = new WorkJunctionLiningLateralGateway();
                    workJunctionLiningLateralGateway.LoadByWorkId(workId, companyId);

                    // Load original data
                    int originalSectionWorkId = workJunctionLiningLateralGateway.GetSectionWorkID(workId);
                    DateTime? originalPipeLocated = workJunctionLiningLateralGateway.GetPipeLocated(workId);
                    DateTime? originalServicesLocated = workJunctionLiningLateralGateway.GetServicesLocated(workId);
                    DateTime? originalCoInstalled = workJunctionLiningLateralGateway.GetCoInstalled(workId);
                    DateTime? originalBackfilledConcrete = workJunctionLiningLateralGateway.GetBackfilledConcrete(workId);
                    DateTime? originalBackfilledSoil = workJunctionLiningLateralGateway.GetBackfilledSoil(workId);
                    DateTime? originalGrouted = workJunctionLiningLateralGateway.GetGrouted(workId);
                    DateTime? originalCored = workJunctionLiningLateralGateway.GetCored(workId);
                    DateTime? originalPrepped = workJunctionLiningLateralGateway.GetPrepped(workId);
                    DateTime? originalMeasured = workJunctionLiningLateralGateway.GetMeasured(workId);
                    string originalLinerSize = workJunctionLiningLateralGateway.GetLinerSize(workId);
                    DateTime? originalInProcess = workJunctionLiningLateralGateway.GetInProcess(workId);
                    DateTime? originalInStock = workJunctionLiningLateralGateway.GetInStock(workId);
                    DateTime? originalDelivered = workJunctionLiningLateralGateway.GetDelivered(workId);
                    int? originalBuildRebuild = workJunctionLiningLateralGateway.GetBuildRebuild(workId);
                    DateTime? originalPreVideo = workJunctionLiningLateralGateway.GetPreVideo(workId);
                    DateTime? originalLinerInstalled = workJunctionLiningLateralGateway.GetLinerInstalled(workId);
                    DateTime? originalFinalVideo = workJunctionLiningLateralGateway.GetFinalVideo(workId);
                    decimal? originalCost = workJunctionLiningLateralGateway.GetCost(workId);
                    DateTime? originalVideoInspection = workJunctionLiningLateralGateway.GetVideoInspection(workId);
                    bool originalCoRequired = workJunctionLiningLateralGateway.GetCoRequired(workId);
                    bool originalPitRequired = workJunctionLiningLateralGateway.GetPitRequired(workId);
                    string originalCoPitLocation = workJunctionLiningLateralGateway.GetCoPitLocation(workId);
                    bool originalPostContractDigRequired = workJunctionLiningLateralGateway.GetPostContractDigRequired(workId);
                    DateTime? originalCoCutDown = workJunctionLiningLateralGateway.GetCoCutDown(workId);
                    DateTime? originalFinalRestoration = workJunctionLiningLateralGateway.GetFinalRestoration(workId);
                    string originalVideoLengthToPropertyLine = workJunctionLiningLateralGateway.GetVideoLengthToPropertyLine(workId);
                    bool originalLiningThruCo = workJunctionLiningLateralGateway.GetLiningThruCo(workId);
                    DateTime? originalNoticeDelivered = workJunctionLiningLateralGateway.GetNoticeDelivered(workId);
                    string originalHamiltonInspectionNumber = workJunctionLiningLateralGateway.GetHamiltonInspectionNumber(workId);
                    string originalFlange = workJunctionLiningLateralGateway.GetFlange(workId);
                    string originalGasket = workJunctionLiningLateralGateway.GetGasket(workId);
                    string originalDepthOfLocated = workJunctionLiningLateralGateway.GetDepthOfLocated(workId);
                    bool originalDigRequiredPriorToLining = workJunctionLiningLateralGateway.GetDigRequiredPriorToLining(workId);
                    DateTime? originalDigRequiredPriorToLiningCompleted = workJunctionLiningLateralGateway.GetDigRequiredPriorToLiningCompleted(workId);
                    bool originalDigRequiredAfterLining = workJunctionLiningLateralGateway.GetDigRequiredAfterLining(workId);
                    DateTime? originalDigRequiredAfterLiningCompleted = workJunctionLiningLateralGateway.GetDigRequiredAfterLiningCompleted(workId);
                    bool originalOutOfScope = workJunctionLiningLateralGateway.GetOutOfScope(workId);
                    bool originalHoldClientIssue = workJunctionLiningLateralGateway.GetHoldClientIssue(workId);
                    DateTime? originalHoldClientIssueResolved = workJunctionLiningLateralGateway.GetHoldClientIssueResolved(workId);
                    bool originalHoldLFSIssue = workJunctionLiningLateralGateway.GetHoldLFSIssue(workId);
                    DateTime? originalHoldLFSIssueResolved = workJunctionLiningLateralGateway.GetHoldLFSIssueResolved(workId);
                    bool originalRequiresRoboticPrep = workJunctionLiningLateralGateway.GetLateralRequiresRoboticPrep(workId);
                    DateTime? originalRequiresRoboticPrepCompleted = workJunctionLiningLateralGateway.GetLateralRequiresRoboticPrepCompleted(workId);
                    string originalLinerType = workJunctionLiningLateralGateway.GetLinerType(workId);
                    string originalPrepType = workJunctionLiningLateralGateway.GetPrepType(workId);
                    bool originalDyeTestReq = workJunctionLiningLateralGateway.GetDyeTestReq(workId);
                    DateTime? originalDyeTestComplete = null; if (workJunctionLiningLateralGateway.GetDyeTestComplete(workId).HasValue) originalDyeTestComplete = workJunctionLiningLateralGateway.GetDyeTestComplete(workId);
                    string originalContractYear = workJunctionLiningLateralGateway.GetContractYear(workId);

                    // New data           
                    DateTime? newVideoInspection = videoInspection;
                    string newClientInspectionNo = clientInspectionNo;
                    bool newRequiresRoboticPrep = requiredRoboticPrep;
                    bool newHoldClientIssue = holdClientIssue;
                    bool newHoldLFSIssue = holdLFSIssue;
                    DateTime? newRequiresRoboticPrepCompleted = null; if (requiredRoboticPrepDate.HasValue) newRequiresRoboticPrepCompleted = (DateTime)requiredRoboticPrepDate;
                    bool newDyeTestReq = dyeTestReq;
                    DateTime? newDyeTestComplete = null; if (dyeTestComplete.HasValue) newDyeTestComplete = (DateTime)dyeTestComplete;
                    string newContractYear = contractYear;

                    // Update work
                    WorkJunctionLiningLateral workJunctionLiningLateral = new WorkJunctionLiningLateral(null);
                    workJunctionLiningLateral.UpdateDirect(workId, originalSectionWorkId, originalPipeLocated, originalServicesLocated, originalCoInstalled, originalBackfilledConcrete, originalBackfilledSoil, originalGrouted, originalCored, originalPrepped, originalMeasured, originalLinerSize, originalInProcess, originalInStock, originalDelivered, originalBuildRebuild, originalPreVideo, originalLinerInstalled, originalFinalVideo, originalCost, originalVideoInspection, originalCoRequired, originalPitRequired, originalCoPitLocation, originalPostContractDigRequired, originalCoCutDown, originalFinalRestoration, false, companyId, originalVideoLengthToPropertyLine, originalLiningThruCo, originalNoticeDelivered, originalHamiltonInspectionNumber, originalFlange, originalGasket, originalDepthOfLocated, originalDigRequiredPriorToLining, originalDigRequiredPriorToLiningCompleted, originalDigRequiredAfterLining, originalDigRequiredAfterLiningCompleted, originalOutOfScope, originalHoldClientIssue, originalHoldClientIssueResolved, originalHoldLFSIssue, originalHoldLFSIssueResolved, originalRequiresRoboticPrep, originalRequiresRoboticPrepCompleted, originalLinerType, originalPrepType, originalDyeTestReq, originalDyeTestComplete, originalPipeLocated, originalServicesLocated, originalCoInstalled, originalBackfilledConcrete, originalBackfilledSoil, originalGrouted, originalCored, originalPrepped, originalMeasured, originalLinerSize, originalInProcess, originalInStock, originalDelivered, originalBuildRebuild, originalPreVideo, originalLinerInstalled, originalFinalVideo,  originalCost, newVideoInspection, originalCoRequired, originalPitRequired, originalCoPitLocation, originalPostContractDigRequired, originalCoCutDown, originalFinalRestoration, companyId, originalVideoLengthToPropertyLine, originalLiningThruCo, originalNoticeDelivered, newClientInspectionNo, flange, originalGasket, originalDepthOfLocated, originalDigRequiredPriorToLining, originalDigRequiredPriorToLiningCompleted, originalDigRequiredAfterLining, originalDigRequiredAfterLiningCompleted, originalOutOfScope, newHoldClientIssue, originalHoldClientIssueResolved, newHoldLFSIssue, originalHoldLFSIssueResolved, newRequiresRoboticPrep, newRequiresRoboticPrepCompleted, originalLinerType, originalPrepType, newDyeTestReq, newDyeTestComplete, originalContractYear, newContractYear);
                }
            }
        }



        /// <summary>
        /// DeleteJLLaterals
        /// </summary>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <param name="lateral_assetId">lateral_assetId</param>
        /// <param name="companyId">companyId</param>       
        /// <param name="sectionWorkId">sectionWorkId</param>
        private void DeleteJLLaterals(int currentProjectId, int lateral_assetId, int companyId, int sectionWorkId)
        {
            // Load work id
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(currentProjectId, lateral_assetId, "Junction Lining Lateral", companyId);

            if (workGateway.Table.Rows.Count > 0)
            {
                int workId = workGateway.GetWorkId(lateral_assetId, "Junction Lining Lateral", currentProjectId);

                if (workId > 0)
                {                    
                    // Delete work
                    WorkJunctionLiningLateral workJunctionLiningLateral = new WorkJunctionLiningLateral(null);
                    workJunctionLiningLateral.DeleteDirect(workId, sectionWorkId, companyId);
                }
            }
        }      
        


    }
}