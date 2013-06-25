using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.PointRepairs;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;

namespace LiquiForce.LFSLive.BL.CWP.PointRepairs
{
    /// <summary>
    /// PointRepairsWorkDetails
    /// </summary>
    public class PointRepairsWorkDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PointRepairsWorkDetails()
            : base("WorkDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PointRepairsWorkDetails(DataSet data)
            : base(data, "WorkDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PointRepairsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByWorkIdAssetId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByWorkIdAssetId(int workId, int assetId, int companyId)
        {
            PointRepairsWorkDetailsGateway pointRepairsWorkDetailsGateway = new PointRepairsWorkDetailsGateway(Data);
            pointRepairsWorkDetailsGateway.LoadByWorkIdAssetId(workId, assetId, companyId);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="clientID">clientID</param>
        /// <param name="measurementTakenBy">measurementTakenBy</param>
        /// <param name="repairConfirmationDate">repairConfirmationDate</param>
        /// <param name="bypassRequired">bypassRequired</param>
        /// <param name="roboticDistances">roboticDistances</param>
        /// <param name="proposedLiningDate">proposedLiningDate</param>
        /// <param name="deadlineLiningDate">deadlineLiningDate</param>
        /// <param name="finalVideoDate">finalVideoDate</param>
        /// <param name="estimatedJoints">estimatedJoints</param>
        /// <param name="jointsTestSealed">jointsTestSealed</param>
        /// <param name="issueIdentified">issueIdentified</param>
        /// <param name="issueLFS">issueLFS</param>
        /// <param name="issueClient">issueClient</param>
        /// <param name="issueSales">issueSales</param>
        /// <param name="issueGivenToClient">issueGivenToClient</param>
        /// <param name="issueResolved">issueResolved</param>
        /// <param name="issueInvestigation">issueInvestigation</param>
        public void Update(int workId, string clientID, string measurementTakenBy, DateTime? repairConfirmationDate, bool bypassRequired, string roboticDistances, DateTime? proposedLiningDate, DateTime? deadlineLiningDate, DateTime? finalVideoDate, int? estimatedJoints, int? jointsTestSealed, bool issueIdentified, bool issueLFS, bool issueClient, bool issueSales, bool issueGivenToClient, bool issueResolved, bool issueInvestigation, DateTime? p1Date, int? CXIsRemoved, string trafficControl, string material, string videoLength, DateTime? preVideoDate, DateTime? preFlushDate)
        {
            PointRepairsTDS.WorkDetailsRow row = GetRow(workId);

            if (clientID.Trim() != "") row.ClientID = clientID; else row.SetClientIDNull();
            if (measurementTakenBy != "") row.MeasurementTakenBy = measurementTakenBy; else row.IsMeasurementTakenByNull();
            if (repairConfirmationDate.HasValue) row.RepairConfirmationDate = (DateTime)repairConfirmationDate; else row.SetRepairConfirmationDateNull();
            row.BypassRequired = bypassRequired;
            if (roboticDistances != "") row.RoboticDistances = roboticDistances; else row.SetRoboticDistancesNull();
            if (proposedLiningDate.HasValue) row.ProposedLiningDate = (DateTime)proposedLiningDate; else row.SetProposedLiningDateNull();
            if (deadlineLiningDate.HasValue) row.DeadlineLiningDate = (DateTime)deadlineLiningDate; else row.SetDeadlineLiningDateNull();
            if (finalVideoDate.HasValue) row.FinalVideoDate = (DateTime)finalVideoDate; else row.SetFinalVideoDateNull();
            if (estimatedJoints.HasValue) row.EstimatedJoints = (int)estimatedJoints; else row.SetEstimatedJointsNull();
            if (jointsTestSealed.HasValue) row.JointsTestSealed = (int)jointsTestSealed; else row.SetJointsTestSealedNull();
            row.IssueIdentified = issueIdentified;
            row.IssueLFS = issueLFS;
            row.IssueClient = issueClient;
            row.IssueSales = issueSales;
            row.IssueGivenToClient = issueGivenToClient;
            row.IssueResolved = issueResolved;
            row.IssueInvestigation = issueInvestigation;

            // Prep
            if (p1Date.HasValue) row.P1Date = (DateTime)p1Date; else row.SetP1DateNull();
            if (CXIsRemoved.HasValue) row.CXIsRemoved = (int)CXIsRemoved; else row.SetCXIsRemovedNull();

            if (material != "") row.Material = material; else row.SetMaterialNull();
            if (trafficControl != "") row.TrafficControl = trafficControl; else row.SetTrafficControlNull();

            // M2
            if (videoLength != "") row.VideoLength = videoLength; else row.SetVideoLengthNull();

            // RA
            if (preFlushDate.HasValue) row.PreFlushDate = (DateTime)preFlushDate; else row.SetPreFlushDateNull();
            if (preVideoDate.HasValue) row.PreVideoDate = (DateTime)preVideoDate; else row.SetPreVideoDateNull();
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

            PointRepairsTDS.WorkDetailsRow row = GetRow(workId);

            workGateway.LoadByWorkId(workId, companyId);
            workComentsGateway.LoadByWorkIdWorkType(workId, companyId, "Point Repairs");
            row.Comments = workComments.GetAllComments(workId, companyId, workComentsGateway.Table.Rows.Count, "\n");
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="workId">workId</param>
        public void Delete(int workId)
        {
            PointRepairsTDS.WorkDetailsRow row = GetRow(workId);
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
            WorkPointRepairs workPointRepairs = new WorkPointRepairs(null);
            workPointRepairs.DeleteDirect(workId, companyId);

            // Delete section
            LfsAssetSewerSection lfsAssetSewerSection = new LfsAssetSewerSection(null);
            lfsAssetSewerSection.DeleteDirect(assetId, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="sectionAssetId">sectionAssetId</param>
        /// <param name="companyId">companyId</param>
        public void Save(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int projectId, int sectionAssetId, int companyId)
        {
            PointRepairsTDS pointRepairsChanges = (PointRepairsTDS)Data.GetChanges();

            if (pointRepairsChanges.WorkDetails.Rows.Count > 0)
            {
                PointRepairsWorkDetailsGateway pointRepairsWorkDetailsGateway = new PointRepairsWorkDetailsGateway(pointRepairsChanges);

                // Update sections
                foreach (PointRepairsTDS.WorkDetailsRow workDetailsRow in (PointRepairsTDS.WorkDetailsDataTable)pointRepairsChanges.WorkDetails)
                {
                    // Unchanged values
                    int workId = workDetailsRow.WorkID;

                    // Original values
                    string originalClientId = pointRepairsWorkDetailsGateway.GetClientIdOriginal(workId);
                    string originalMeasurementTakenBy = pointRepairsWorkDetailsGateway.GetMeasurementTakenByOriginal(workId);
                    DateTime? originalRepairConfirmationDate = pointRepairsWorkDetailsGateway.GetRepairConfirmationDateOriginal(workId);                    
                    bool originalBypassRequired = pointRepairsWorkDetailsGateway.GetBypassRequiredOriginal(workId);
                    string originalRoboticDistances = pointRepairsWorkDetailsGateway.GetRoboticDistancesOriginal(workId);
                    DateTime? originalProposedLiningDate = pointRepairsWorkDetailsGateway.GetProposedLiningDateOriginal(workId);
                    DateTime? originalDeadlineLiningDate = pointRepairsWorkDetailsGateway.GetDeadlineLiningDateOriginal(workId);
                    DateTime? originalFinalVideoDate = pointRepairsWorkDetailsGateway.GetFinalVideoDateOriginal(workId);
                    int? originalEstimatedJoints = pointRepairsWorkDetailsGateway.GetEstimatedJointsOriginal(workId);
                    int? originalJointsTestSealed = pointRepairsWorkDetailsGateway.GetJointsTestSealedOriginal(workId);
                    bool originalIssueIdentified = pointRepairsWorkDetailsGateway.GetIssueIdentifiedOriginal(workId);
                    bool originalIssueLFS = pointRepairsWorkDetailsGateway.GetIssueLFSOriginal(workId);
                    bool originalIssueClient = pointRepairsWorkDetailsGateway.GetIssueClientOriginal(workId);
                    bool originalIssueSales = pointRepairsWorkDetailsGateway.GetIssueSalesOriginal(workId);
                    bool originalIssueGivenToClient = pointRepairsWorkDetailsGateway.GetIssueGivenToClientOriginal(workId);
                    bool originalIssueResolved = pointRepairsWorkDetailsGateway.GetIssueResolvedOriginal(workId);
                    bool originalIssueInvestigation = pointRepairsWorkDetailsGateway.GetIssueInvestigationOriginal(workId);
                    
                    // New variables
                    string newClientId = pointRepairsWorkDetailsGateway.GetClientId(workId);
                    string newMeasurementTakenBy = pointRepairsWorkDetailsGateway.GetMeasurementTakenBy(workId);
                    DateTime? newRepairConfirmationDate = pointRepairsWorkDetailsGateway.GetRepairConfirmationDate(workId);
                    bool newBypassRequired = pointRepairsWorkDetailsGateway.GetBypassRequired(workId);
                    string newRoboticDistances = pointRepairsWorkDetailsGateway.GetRoboticDistances(workId);
                    DateTime? newProposedLiningDate = pointRepairsWorkDetailsGateway.GetProposedLiningDate(workId);
                    DateTime? newDeadlineLiningDate = pointRepairsWorkDetailsGateway.GetDeadlineLiningDate(workId);
                    DateTime? newFinalVideoDate = pointRepairsWorkDetailsGateway.GetFinalVideoDate(workId);
                    int? newEstimatedJoints = pointRepairsWorkDetailsGateway.GetEstimatedJoints(workId);
                    int? newJointsTestSealed = pointRepairsWorkDetailsGateway.GetJointsTestSealed(workId);
                    bool newIssueIdentified = pointRepairsWorkDetailsGateway.GetIssueIdentified(workId);
                    bool newIssueLFS = pointRepairsWorkDetailsGateway.GetIssueLFS(workId);
                    bool newIssueClient = pointRepairsWorkDetailsGateway.GetIssueClient(workId);
                    bool newIssueSales = pointRepairsWorkDetailsGateway.GetIssueSales(workId);
                    bool newIssueGivenToClient = pointRepairsWorkDetailsGateway.GetIssueGivenToClient(workId);
                    bool newIssueResolved = pointRepairsWorkDetailsGateway.GetIssueResolved(workId);
                    bool newIssueInvestigation = pointRepairsWorkDetailsGateway.GetIssueInvestigation(workId);

                    // ... RA
                    DateTime? originalPreFlushDate = pointRepairsWorkDetailsGateway.GetPreFlushDateOriginal(workId);
                    DateTime? originalPreVideoDate = pointRepairsWorkDetailsGateway.GetPreVideoDateOriginal(workId);

                    // ... FLL P1
                    DateTime? originalP1Date = pointRepairsWorkDetailsGateway.GetP1DateOriginal(workId);
                    int? originalCxisRemoved = pointRepairsWorkDetailsGateway.GetCxisRemovedOriginal(workId);

                    // ... FLL M1
                    string originalTrafficControl = pointRepairsWorkDetailsGateway.GetTrafficControlOriginal(workId);
                    string originalMaterial = pointRepairsWorkDetailsGateway.GetMaterialOriginal(workId);

                    // ... FLL M2
                    string originalVideoLength = pointRepairsWorkDetailsGateway.GetVideoLengthOriginal(workId);

                    // ... P1
                    DateTime? newP1Date = pointRepairsWorkDetailsGateway.GetP1Date(workId);
                    int? newCxisRemoved = pointRepairsWorkDetailsGateway.GetCxisRemoved(workId);
                    string newTrafficControl = pointRepairsWorkDetailsGateway.GetTrafficControl(workId);
                    string newMaterial = pointRepairsWorkDetailsGateway.GetMaterial(workId);

                    // ... M2
                    string newVideoLength = pointRepairsWorkDetailsGateway.GetVideoLength(workId);

                    // ... RA
                    DateTime? newPreFlushDate = pointRepairsWorkDetailsGateway.GetPreFlushDate(workId);
                    DateTime? newPreVideoDate = pointRepairsWorkDetailsGateway.GetPreVideoDate(workId);

                    // ... FLL WorkID
                    int workIdFll = 0; if (!workDetailsRow.IsWorkIDFLLNull()) workIdFll = workDetailsRow.WorkIDFLL;
                    int workIdRa = 0; if (!workDetailsRow.IsWorkIDRANull()) workIdRa = workDetailsRow.WorkIDRA;

                    if (workIdFll != 0) // ... Has Fll work
                    {
                        FullLengthLiningWorkDetailsGateway fullLengthLiningWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway();
                        fullLengthLiningWorkDetailsGateway.LoadByWorkIdAssetId(workIdFll, sectionAssetId, companyId);

                        // Original values
                        string originalClientIdFLL = fullLengthLiningWorkDetailsGateway.GetClientIdOriginal(workIdFll);
                        DateTime? originalProposedLiningDateFLL = fullLengthLiningWorkDetailsGateway.GetProposedLiningDateOriginal(workIdFll);
                        DateTime? originalDeadlineLiningDateFLL = fullLengthLiningWorkDetailsGateway.GetDeadlineLiningDateOriginal(workIdFll);
                        DateTime? originalM1Date = fullLengthLiningWorkDetailsGateway.GetM1DateOriginal(workIdFll);
                        DateTime? originalM2Date = fullLengthLiningWorkDetailsGateway.GetM2DateOriginal(workIdFll);
                        DateTime? originalInstallDate = fullLengthLiningWorkDetailsGateway.GetInstallDateOriginal(workIdFll);
                        DateTime? originalFinalVideoDateFLL = fullLengthLiningWorkDetailsGateway.GetFinalVideoDateOriginal(workIdFll);
                        bool originalIssueIdentifiedFLL = fullLengthLiningWorkDetailsGateway.GetIssueIdentifiedOriginal(workIdFll);
                        bool originalIssueLFSFLL = fullLengthLiningWorkDetailsGateway.GetIssueLFSOriginal(workIdFll);
                        bool originalIssueClientFLL = fullLengthLiningWorkDetailsGateway.GetIssueClientOriginal(workIdFll);
                        bool originalIssueSalesFLL = fullLengthLiningWorkDetailsGateway.GetIssueSalesOriginal(workIdFll);
                        bool originalIssueGivenToClientFLL = fullLengthLiningWorkDetailsGateway.GetIssueGivenToClientOriginal(workIdFll);
                        bool originalIssueResolvedFLL = fullLengthLiningWorkDetailsGateway.GetIssueResolvedOriginal(workIdFll);
                        bool originalIssueInvestigationFLL = fullLengthLiningWorkDetailsGateway.GetIssueInvestigationOriginal(workIdFll);
                        bool originalRoboticPrepCompleted = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompletedOriginal(workIdFll);
                        DateTime? originalRoboticPrepCompletedDate = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompletedDateOriginal(workIdFll);
                        bool originalP1Completed = fullLengthLiningWorkDetailsGateway.GetP1CompletedOriginal(workIdFll);

                        // M1 data
                        string originalMeasurementTakenByFLL = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenByOriginal(workIdFll);
                        string originalSiteDetails = fullLengthLiningWorkDetailsGateway.GetSiteDetailsOriginal(workIdFll);
                        bool originalPipeSizeChange = fullLengthLiningWorkDetailsGateway.GetPipeSizeChangeOriginal(workIdFll);
                        bool originalStandardBypass = fullLengthLiningWorkDetailsGateway.GetStandardBypassOriginal(workIdFll);
                        string originalStandardBypassComments = fullLengthLiningWorkDetailsGateway.GetStandardBypassCommentsOriginal(workIdFll);
                        string originalTrafficControlDetails = fullLengthLiningWorkDetailsGateway.GetTrafficControlDetailsOriginal(workIdFll);
                        string originalMeasurementType = fullLengthLiningWorkDetailsGateway.GetMeasurementTypeOriginal(workIdFll);
                        string originalMeasurementFromMh = fullLengthLiningWorkDetailsGateway.GetMeasurementFromMhOriginal(workIdFll);
                        string originalVideoDoneFromMh = fullLengthLiningWorkDetailsGateway.GetVideoDoneFromMhOriginal(workIdFll);
                        string originalVideoDoneToMh = fullLengthLiningWorkDetailsGateway.GetVideoDoneToMhOriginal(workIdFll);
                        string originalAccessType = fullLengthLiningWorkDetailsGateway.GetAccessTypeOriginal(workIdFll);

                        // M2 data
                        string originalMeasurementTakenByM2 = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenByM2Original(workIdFll);
                        bool originalDropPipe = fullLengthLiningWorkDetailsGateway.GetDropPipeOriginal(workIdFll);
                        string originalDropPipeInvertDepth = fullLengthLiningWorkDetailsGateway.GetDropPipeInvertDepthOriginal(workIdFll);
                        int? originalCappedLaterals = fullLengthLiningWorkDetailsGateway.GetCappedLateralsOriginal(workIdFll);
                        string originalLineWithId = fullLengthLiningWorkDetailsGateway.GetLineWithIdOriginal(workIdFll);
                        string originalHydrantAddress = fullLengthLiningWorkDetailsGateway.GetHydrantAddressOriginal(workIdFll);
                        string originalHydroWireWithin10FtOfInversionMH = fullLengthLiningWorkDetailsGateway.GetHydroWiredWithin10FtOfInversionMHOriginal(workIdFll);
                        string originalDistanceToInversionMh = fullLengthLiningWorkDetailsGateway.GetDistanceToInversionMhOriginal(workIdFll);
                        string originalSurfaceGrade = fullLengthLiningWorkDetailsGateway.GetSurfaceGradeOriginal(workIdFll);
                        bool originalHydroPulley = fullLengthLiningWorkDetailsGateway.GetHydroPulleyOriginal(workIdFll);
                        bool originalFridgeCart = fullLengthLiningWorkDetailsGateway.GetFridgeCartOriginal(workIdFll);
                        bool originalTwoPump = fullLengthLiningWorkDetailsGateway.GetTwoPumpOriginal(workIdFll);
                        bool originalSixBypass = fullLengthLiningWorkDetailsGateway.GetSixBypassOriginal(workIdFll);
                        bool originalScaffolding = fullLengthLiningWorkDetailsGateway.GetScaffoldingOriginal(workIdFll);
                        bool originalWinchExtension = fullLengthLiningWorkDetailsGateway.GetWinchExtensionOriginal(workIdFll);
                        bool originalExtraGenerator = fullLengthLiningWorkDetailsGateway.GetExtraGeneratorOriginal(workIdFll);
                        bool originalGreyCableExtension = fullLengthLiningWorkDetailsGateway.GetGreyCableExtensionOriginal(workIdFll);
                        bool originalEasementMats = fullLengthLiningWorkDetailsGateway.GetEasementMatsOriginal(workIdFll);
                        bool originalRampRequired = fullLengthLiningWorkDetailsGateway.GetRampRequiredOriginal(workIdFll);
                        bool originalCameraSkid = fullLengthLiningWorkDetailsGateway.GetCameraSkidOriginal(workIdFll);

                        // Comments
                        string originalComments = fullLengthLiningWorkDetailsGateway.GetCommentsOriginal(workIdFll);

                        // New variables
                        string newClientIdFLL = fullLengthLiningWorkDetailsGateway.GetClientId(workIdFll);
                        DateTime? newProposedLiningDateFLL = fullLengthLiningWorkDetailsGateway.GetProposedLiningDate(workIdFll);
                        DateTime? newDeadlineLiningDateFLL = fullLengthLiningWorkDetailsGateway.GetDeadlineLiningDate(workIdFll);
                        DateTime? newM1Date = fullLengthLiningWorkDetailsGateway.GetM1Date(workIdFll);
                        DateTime? newM2Date = fullLengthLiningWorkDetailsGateway.GetM2Date(workIdFll);
                        DateTime? newInstallDate = fullLengthLiningWorkDetailsGateway.GetInstallDate(workIdFll);
                        DateTime? newFinalVideoDateFLL = fullLengthLiningWorkDetailsGateway.GetFinalVideoDate(workIdFll);
                        bool newIssueIdentifiedFLL = fullLengthLiningWorkDetailsGateway.GetIssueIdentified(workIdFll);
                        bool newIssueLFSFLL = fullLengthLiningWorkDetailsGateway.GetIssueLFS(workIdFll);
                        bool newIssueClientFLL = fullLengthLiningWorkDetailsGateway.GetIssueClient(workIdFll);
                        bool newIssueSalesFLL = fullLengthLiningWorkDetailsGateway.GetIssueSales(workIdFll);
                        bool newIssueGivenToClientFLL = fullLengthLiningWorkDetailsGateway.GetIssueGivenToClient(workIdFll);
                        bool newIssueResolvedFLL = fullLengthLiningWorkDetailsGateway.GetIssueResolved(workIdFll);
                        bool newIssueInvestigationFLL = fullLengthLiningWorkDetailsGateway.GetIssueInvestigation(workIdFll);
                        bool newRoboticPrepCompleted = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompleted(workIdFll);
                        DateTime? newRoboticPrepCompletedDate = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompletedDate(workIdFll);
                        bool newP1Completed = fullLengthLiningWorkDetailsGateway.GetP1Completed(workIdFll);

                        // M1
                        string newMeasurementTakenByFLL = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenBy(workIdFll);
                        string newSiteDetails = fullLengthLiningWorkDetailsGateway.GetSiteDetails(workIdFll);
                        bool newPipeSizeChange = fullLengthLiningWorkDetailsGateway.GetPipeSizeChange(workIdFll);
                        bool newStandardBypass = fullLengthLiningWorkDetailsGateway.GetStandardBypass(workIdFll);
                        string newStandardBypassComments = fullLengthLiningWorkDetailsGateway.GetStandardBypassComments(workIdFll);
                        string newTrafficControlDetails = fullLengthLiningWorkDetailsGateway.GetTrafficControlDetails(workIdFll);
                        string newMeasurementType = fullLengthLiningWorkDetailsGateway.GetMeasurementType(workIdFll);
                        string newMeasurementFromMh = fullLengthLiningWorkDetailsGateway.GetMeasurementFromMh(workIdFll);
                        string newVideoDoneFromMh = fullLengthLiningWorkDetailsGateway.GetVideoDoneFromMh(workIdFll);
                        string newVideoDoneToMh = fullLengthLiningWorkDetailsGateway.GetVideoDoneToMh(workIdFll);
                        string newAccessType = fullLengthLiningWorkDetailsGateway.GetAccessType(workIdFll);

                        // M2
                        string newMeasurementTakenByM2 = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenByM2(workIdFll);
                        bool newDropPipe = fullLengthLiningWorkDetailsGateway.GetDropPipe(workIdFll);
                        string newDropPipeInvertDepth = fullLengthLiningWorkDetailsGateway.GetDropPipeInvertDepth(workIdFll);
                        int? newCappedLaterals = fullLengthLiningWorkDetailsGateway.GetCappedLaterals(workIdFll);
                        string newLineWithId = fullLengthLiningWorkDetailsGateway.GetLineWithId(workIdFll);
                        string newHydrantAddress = fullLengthLiningWorkDetailsGateway.GetHydrantAddress(workIdFll);
                        string newHydroWireWithin10FtOfInversionMH = fullLengthLiningWorkDetailsGateway.GetHydroWiredWithin10FtOfInversionMH(workIdFll);
                        string newDistanceToInversionMh = fullLengthLiningWorkDetailsGateway.GetDistanceToInversionMh(workIdFll);
                        string newSurfaceGrade = fullLengthLiningWorkDetailsGateway.GetSurfaceGrade(workIdFll);
                        bool newHydroPulley = fullLengthLiningWorkDetailsGateway.GetHydroPulley(workIdFll);
                        bool newFridgeCart = fullLengthLiningWorkDetailsGateway.GetFridgeCart(workIdFll);
                        bool newTwoPump = fullLengthLiningWorkDetailsGateway.GetTwoPump(workIdFll);
                        bool newSixBypass = fullLengthLiningWorkDetailsGateway.GetSixBypass(workIdFll);
                        bool newScaffolding = fullLengthLiningWorkDetailsGateway.GetScaffolding(workIdFll);
                        bool newWinchExtension = fullLengthLiningWorkDetailsGateway.GetWinchExtension(workIdFll);
                        bool newExtraGenerator = fullLengthLiningWorkDetailsGateway.GetExtraGenerator(workIdFll);
                        bool newGreyCableExtension = fullLengthLiningWorkDetailsGateway.GetGreyCableExtension(workIdFll);
                        bool newEasementMats = fullLengthLiningWorkDetailsGateway.GetEasementMats(workIdFll);
                        bool newRampRequired = fullLengthLiningWorkDetailsGateway.GetRampRequired(workIdFll);
                        bool newCameraSkid = fullLengthLiningWorkDetailsGateway.GetCameraSkid(workIdFll);

                        // comments
                        string newComments = fullLengthLiningWorkDetailsGateway.GetComments(workIdFll);
                                                
                        // ... Update work
                        UpdateFllWork(sectionAssetId, countryId, provinceId, countyId, cityId, workIdFll, originalClientIdFLL, originalProposedLiningDateFLL, originalDeadlineLiningDateFLL, originalP1Date, originalM1Date, originalM2Date, originalInstallDate, originalFinalVideoDateFLL, originalIssueIdentifiedFLL, originalIssueLFSFLL, originalIssueClientFLL, originalIssueSalesFLL, originalIssueGivenToClientFLL, originalIssueResolvedFLL, originalIssueInvestigationFLL, originalCxisRemoved, originalRoboticPrepCompleted, originalRoboticPrepCompletedDate, originalMeasurementTakenByFLL, originalTrafficControl, originalSiteDetails, originalPipeSizeChange, originalStandardBypass, originalStandardBypassComments, originalTrafficControlDetails, originalMeasurementType, originalMeasurementFromMh, originalVideoDoneFromMh, originalVideoDoneToMh, originalVideoLength, originalComments, false, companyId, originalMaterial, originalAccessType, originalP1Completed, newClientIdFLL, originalProposedLiningDateFLL, originalDeadlineLiningDateFLL, newP1Date, newM1Date, originalM2Date, originalInstallDate, originalFinalVideoDateFLL, originalIssueIdentifiedFLL, originalIssueLFSFLL, originalIssueClientFLL, originalIssueSalesFLL, originalIssueGivenToClientFLL, originalIssueResolvedFLL, originalIssueInvestigationFLL, newCxisRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newMeasurementTakenByFLL, newMaterial, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardBypass, newStandardBypassComments, newTrafficControlDetails, newMeasurementType, newMeasurementFromMh, newVideoDoneFromMh, newVideoDoneToMh, newVideoLength, newComments, false, companyId, newAccessType, newP1Completed);
                    }
                    else
                    {
                        if (newP1Date.HasValue || newCxisRemoved.HasValue || newMaterial != "" || newTrafficControl != "" || newVideoLength != "") // Insert Fll work
                        {
                            WorkFullLengthLining workFullLengthLining = new WorkFullLengthLining(null);
                            workIdFll = workFullLengthLining.InsertDirectEmptyWorks(projectId, sectionAssetId, null, "", null, null, null, null, null, null, null, false, false, false, false, false, false, false, companyId, false, "", "");

                            FullLengthLiningWorkDetailsGateway fullLengthLiningWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway();
                            fullLengthLiningWorkDetailsGateway.LoadByWorkIdAssetId(workIdFll, sectionAssetId, companyId);

                            // Original values
                            string originalClientIdFLL = fullLengthLiningWorkDetailsGateway.GetClientIdOriginal(workIdFll);
                            DateTime? originalProposedLiningDateFLL = fullLengthLiningWorkDetailsGateway.GetProposedLiningDateOriginal(workIdFll);
                            DateTime? originalDeadlineLiningDateFLL = fullLengthLiningWorkDetailsGateway.GetDeadlineLiningDateOriginal(workIdFll);
                            DateTime? originalM1Date = fullLengthLiningWorkDetailsGateway.GetM1DateOriginal(workIdFll);
                            DateTime? originalM2Date = fullLengthLiningWorkDetailsGateway.GetM2DateOriginal(workIdFll);
                            DateTime? originalInstallDate = fullLengthLiningWorkDetailsGateway.GetInstallDateOriginal(workIdFll);
                            DateTime? originalFinalVideoDateFLL = fullLengthLiningWorkDetailsGateway.GetFinalVideoDateOriginal(workIdFll);
                            bool originalIssueIdentifiedFLL = fullLengthLiningWorkDetailsGateway.GetIssueIdentifiedOriginal(workIdFll);
                            bool originalIssueLFSFLL = fullLengthLiningWorkDetailsGateway.GetIssueLFSOriginal(workIdFll);
                            bool originalIssueClientFLL = fullLengthLiningWorkDetailsGateway.GetIssueClientOriginal(workIdFll);
                            bool originalIssueSalesFLL = fullLengthLiningWorkDetailsGateway.GetIssueSalesOriginal(workIdFll);
                            bool originalIssueGivenToClientFLL = fullLengthLiningWorkDetailsGateway.GetIssueGivenToClientOriginal(workIdFll);
                            bool originalIssueResolvedFLL = fullLengthLiningWorkDetailsGateway.GetIssueResolvedOriginal(workIdFll);
                            bool originalIssueInvestigationFLL = fullLengthLiningWorkDetailsGateway.GetIssueInvestigationOriginal(workIdFll);
                            bool originalRoboticPrepCompleted = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompletedOriginal(workIdFll);
                            DateTime? originalRoboticPrepCompletedDate = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompletedDateOriginal(workIdFll);
                            bool originalP1Completed = fullLengthLiningWorkDetailsGateway.GetP1CompletedOriginal(workIdFll);

                            // M1 data
                            string originalMeasurementTakenByFLL = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenByOriginal(workIdFll);
                            string originalSiteDetails = fullLengthLiningWorkDetailsGateway.GetSiteDetailsOriginal(workIdFll);
                            bool originalPipeSizeChange = fullLengthLiningWorkDetailsGateway.GetPipeSizeChangeOriginal(workIdFll);
                            bool originalStandardBypass = fullLengthLiningWorkDetailsGateway.GetStandardBypassOriginal(workIdFll);
                            string originalStandardBypassComments = fullLengthLiningWorkDetailsGateway.GetStandardBypassCommentsOriginal(workIdFll);
                            string originalTrafficControlDetails = fullLengthLiningWorkDetailsGateway.GetTrafficControlDetailsOriginal(workIdFll);
                            string originalMeasurementType = fullLengthLiningWorkDetailsGateway.GetMeasurementTypeOriginal(workIdFll);
                            string originalMeasurementFromMh = fullLengthLiningWorkDetailsGateway.GetMeasurementFromMhOriginal(workIdFll);
                            string originalVideoDoneFromMh = fullLengthLiningWorkDetailsGateway.GetVideoDoneFromMhOriginal(workIdFll);
                            string originalVideoDoneToMh = fullLengthLiningWorkDetailsGateway.GetVideoDoneToMhOriginal(workIdFll);
                            string originalAccessType = fullLengthLiningWorkDetailsGateway.GetAccessTypeOriginal(workIdFll);

                            // M2 data
                            string originalMeasurementTakenByM2 = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenByM2Original(workIdFll);
                            bool originalDropPipe = fullLengthLiningWorkDetailsGateway.GetDropPipeOriginal(workIdFll);
                            string originalDropPipeInvertDepth = fullLengthLiningWorkDetailsGateway.GetDropPipeInvertDepthOriginal(workIdFll);
                            int? originalCappedLaterals = fullLengthLiningWorkDetailsGateway.GetCappedLateralsOriginal(workIdFll);
                            string originalLineWithId = fullLengthLiningWorkDetailsGateway.GetLineWithIdOriginal(workIdFll);
                            string originalHydrantAddress = fullLengthLiningWorkDetailsGateway.GetHydrantAddressOriginal(workIdFll);
                            string originalHydroWireWithin10FtOfInversionMH = fullLengthLiningWorkDetailsGateway.GetHydroWiredWithin10FtOfInversionMHOriginal(workIdFll);
                            string originalDistanceToInversionMh = fullLengthLiningWorkDetailsGateway.GetDistanceToInversionMhOriginal(workIdFll);
                            string originalSurfaceGrade = fullLengthLiningWorkDetailsGateway.GetSurfaceGradeOriginal(workIdFll);
                            bool originalHydroPulley = fullLengthLiningWorkDetailsGateway.GetHydroPulleyOriginal(workIdFll);
                            bool originalFridgeCart = fullLengthLiningWorkDetailsGateway.GetFridgeCartOriginal(workIdFll);
                            bool originalTwoPump = fullLengthLiningWorkDetailsGateway.GetTwoPumpOriginal(workIdFll);
                            bool originalSixBypass = fullLengthLiningWorkDetailsGateway.GetSixBypassOriginal(workIdFll);
                            bool originalScaffolding = fullLengthLiningWorkDetailsGateway.GetScaffoldingOriginal(workIdFll);
                            bool originalWinchExtension = fullLengthLiningWorkDetailsGateway.GetWinchExtensionOriginal(workIdFll);
                            bool originalExtraGenerator = fullLengthLiningWorkDetailsGateway.GetExtraGeneratorOriginal(workIdFll);
                            bool originalGreyCableExtension = fullLengthLiningWorkDetailsGateway.GetGreyCableExtensionOriginal(workIdFll);
                            bool originalEasementMats = fullLengthLiningWorkDetailsGateway.GetEasementMatsOriginal(workIdFll);
                            bool originalRampRequired = fullLengthLiningWorkDetailsGateway.GetRampRequiredOriginal(workIdFll);
                            bool originalCameraSkid = fullLengthLiningWorkDetailsGateway.GetCameraSkidOriginal(workIdFll);

                            // Comments
                            string originalComments = fullLengthLiningWorkDetailsGateway.GetCommentsOriginal(workIdFll);

                            // New variables
                            string newClientIdFLL = fullLengthLiningWorkDetailsGateway.GetClientId(workIdFll);
                            DateTime? newProposedLiningDateFLL = fullLengthLiningWorkDetailsGateway.GetProposedLiningDate(workIdFll);
                            DateTime? newDeadlineLiningDateFLL = fullLengthLiningWorkDetailsGateway.GetDeadlineLiningDate(workIdFll);
                            DateTime? newM1Date = fullLengthLiningWorkDetailsGateway.GetM1Date(workIdFll);
                            DateTime? newM2Date = fullLengthLiningWorkDetailsGateway.GetM2Date(workIdFll);
                            DateTime? newInstallDate = fullLengthLiningWorkDetailsGateway.GetInstallDate(workIdFll);
                            DateTime? newFinalVideoDateFLL = fullLengthLiningWorkDetailsGateway.GetFinalVideoDate(workIdFll);
                            bool newIssueIdentifiedFLL = fullLengthLiningWorkDetailsGateway.GetIssueIdentified(workIdFll);
                            bool newIssueLFSFLL = fullLengthLiningWorkDetailsGateway.GetIssueLFS(workIdFll);
                            bool newIssueClientFLL = fullLengthLiningWorkDetailsGateway.GetIssueClient(workIdFll);
                            bool newIssueSalesFLL = fullLengthLiningWorkDetailsGateway.GetIssueSales(workIdFll);
                            bool newIssueGivenToClientFLL = fullLengthLiningWorkDetailsGateway.GetIssueGivenToClient(workIdFll);
                            bool newIssueResolvedFLL = fullLengthLiningWorkDetailsGateway.GetIssueResolved(workIdFll);
                            bool newIssueInvestigationFLL = fullLengthLiningWorkDetailsGateway.GetIssueInvestigation(workIdFll);
                            bool newRoboticPrepCompleted = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompleted(workIdFll);
                            DateTime? newRoboticPrepCompletedDate = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompletedDate(workIdFll);
                            bool newP1Completed = fullLengthLiningWorkDetailsGateway.GetP1Completed(workIdFll);

                            // M1
                            string newMeasurementTakenByFLL = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenBy(workIdFll);
                            string newSiteDetails = fullLengthLiningWorkDetailsGateway.GetSiteDetails(workIdFll);
                            bool newPipeSizeChange = fullLengthLiningWorkDetailsGateway.GetPipeSizeChange(workIdFll);
                            bool newStandardBypass = fullLengthLiningWorkDetailsGateway.GetStandardBypass(workIdFll);
                            string newStandardBypassComments = fullLengthLiningWorkDetailsGateway.GetStandardBypassComments(workIdFll);
                            string newTrafficControlDetails = fullLengthLiningWorkDetailsGateway.GetTrafficControlDetails(workIdFll);
                            string newMeasurementType = fullLengthLiningWorkDetailsGateway.GetMeasurementType(workIdFll);
                            string newMeasurementFromMh = fullLengthLiningWorkDetailsGateway.GetMeasurementFromMh(workIdFll);
                            string newVideoDoneFromMh = fullLengthLiningWorkDetailsGateway.GetVideoDoneFromMh(workIdFll);
                            string newVideoDoneToMh = fullLengthLiningWorkDetailsGateway.GetVideoDoneToMh(workIdFll);
                            string newAccessType = fullLengthLiningWorkDetailsGateway.GetAccessType(workIdFll);

                            // M2
                            string newMeasurementTakenByM2 = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenByM2(workIdFll);
                            bool newDropPipe = fullLengthLiningWorkDetailsGateway.GetDropPipe(workIdFll);
                            string newDropPipeInvertDepth = fullLengthLiningWorkDetailsGateway.GetDropPipeInvertDepth(workIdFll);
                            int? newCappedLaterals = fullLengthLiningWorkDetailsGateway.GetCappedLaterals(workIdFll);
                            string newLineWithId = fullLengthLiningWorkDetailsGateway.GetLineWithId(workIdFll);
                            string newHydrantAddress = fullLengthLiningWorkDetailsGateway.GetHydrantAddress(workIdFll);
                            string newHydroWireWithin10FtOfInversionMH = fullLengthLiningWorkDetailsGateway.GetHydroWiredWithin10FtOfInversionMH(workIdFll);
                            string newDistanceToInversionMh = fullLengthLiningWorkDetailsGateway.GetDistanceToInversionMh(workIdFll);
                            string newSurfaceGrade = fullLengthLiningWorkDetailsGateway.GetSurfaceGrade(workIdFll);
                            bool newHydroPulley = fullLengthLiningWorkDetailsGateway.GetHydroPulley(workIdFll);
                            bool newFridgeCart = fullLengthLiningWorkDetailsGateway.GetFridgeCart(workIdFll);
                            bool newTwoPump = fullLengthLiningWorkDetailsGateway.GetTwoPump(workIdFll);
                            bool newSixBypass = fullLengthLiningWorkDetailsGateway.GetSixBypass(workIdFll);
                            bool newScaffolding = fullLengthLiningWorkDetailsGateway.GetScaffolding(workIdFll);
                            bool newWinchExtension = fullLengthLiningWorkDetailsGateway.GetWinchExtension(workIdFll);
                            bool newExtraGenerator = fullLengthLiningWorkDetailsGateway.GetExtraGenerator(workIdFll);
                            bool newGreyCableExtension = fullLengthLiningWorkDetailsGateway.GetGreyCableExtension(workIdFll);
                            bool newEasementMats = fullLengthLiningWorkDetailsGateway.GetEasementMats(workIdFll);
                            bool newRampRequired = fullLengthLiningWorkDetailsGateway.GetRampRequired(workIdFll);
                            bool newCameraSkid = fullLengthLiningWorkDetailsGateway.GetCameraSkid(workIdFll);

                            // comments
                            string newComments = fullLengthLiningWorkDetailsGateway.GetComments(workIdFll);

                            // ... Update work
                            UpdateFllWork(sectionAssetId, countryId, provinceId, countyId, cityId, workIdFll, originalClientIdFLL, originalProposedLiningDateFLL, originalDeadlineLiningDateFLL, originalP1Date, originalM1Date, originalM2Date, originalInstallDate, originalFinalVideoDateFLL, originalIssueIdentifiedFLL, originalIssueLFSFLL, originalIssueClientFLL, originalIssueSalesFLL, originalIssueGivenToClientFLL, originalIssueResolvedFLL, originalIssueInvestigationFLL, originalCxisRemoved, originalRoboticPrepCompleted, originalRoboticPrepCompletedDate, originalMeasurementTakenByFLL, originalTrafficControl, originalSiteDetails, originalPipeSizeChange, originalStandardBypass, originalStandardBypassComments, originalTrafficControlDetails, originalMeasurementType, originalMeasurementFromMh, originalVideoDoneFromMh, originalVideoDoneToMh, originalVideoLength, originalComments, false, companyId, originalMaterial, originalAccessType, originalP1Completed, newClientIdFLL, originalProposedLiningDateFLL, originalDeadlineLiningDateFLL, newP1Date, newM1Date, originalM2Date, originalInstallDate, originalFinalVideoDateFLL, originalIssueIdentifiedFLL, originalIssueLFSFLL, originalIssueClientFLL, originalIssueSalesFLL, originalIssueGivenToClientFLL, originalIssueResolvedFLL, originalIssueInvestigationFLL, newCxisRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newMeasurementTakenByFLL, newMaterial, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardBypass, newStandardBypassComments, newTrafficControlDetails, newMeasurementType, newMeasurementFromMh, newVideoDoneFromMh, newVideoDoneToMh, newVideoLength, newComments, false, companyId, newAccessType, newP1Completed);
                        }
                    }

                    if (workIdRa != 0) // ... Has Fll work
                    {
                        UpdateRaWork(workIdRa, originalPreFlushDate, originalPreVideoDate, newPreFlushDate, newPreVideoDate, companyId);
                    }
                    else
                    {
                        if (newPreFlushDate.HasValue || newPreVideoDate.HasValue) // Insert RA work
                        {
                            WorkRehabAssessment workRehabAssessment = new WorkRehabAssessment(null);
                            workIdRa = workRehabAssessment.InsertDirect(projectId, sectionAssetId, null, newPreFlushDate, newPreVideoDate, false, companyId, "", "");

                            UpdateRaWork(workIdRa, originalPreFlushDate, originalPreVideoDate, newPreFlushDate, newPreVideoDate, companyId);
                        }
                    }
                                        
                    // Update work
                    WorkPointRepairs workPointRepairs = new WorkPointRepairs(null);
                    workPointRepairs.UpdateDirect(sectionAssetId, workId, originalClientId, originalMeasurementTakenBy, originalRepairConfirmationDate, originalBypassRequired, originalRoboticDistances, originalProposedLiningDate, originalDeadlineLiningDate, originalFinalVideoDate, originalEstimatedJoints, originalJointsTestSealed, originalIssueIdentified, originalIssueLFS, originalIssueClient, originalIssueSales, originalIssueGivenToClient, originalIssueResolved, originalIssueInvestigation, "", false, companyId, workId, newClientId, newMeasurementTakenBy, newRepairConfirmationDate, newBypassRequired, newRoboticDistances, newProposedLiningDate, newDeadlineLiningDate, newFinalVideoDate, newEstimatedJoints, newJointsTestSealed, newIssueIdentified, newIssueLFS, newIssueClient, newIssueSales, newIssueGivenToClient, newIssueResolved, newIssueInvestigation, "", false, companyId);

                    // Get original variables
                    WorkGateway workGateway = new WorkGateway();
                    workGateway.LoadByWorkId(workId, companyId);

                    string originalWorkType = workGateway.GetWorkTypeOriginal(workId);
                    int? originalLibraryCategoriesId = workGateway.GetLibraryCategoriesIdOriginal(workId);
                    string originalComment = workGateway.GetCommentsOriginal(workId);
                    string originalHistory = workGateway.GetHistoryOriginal(workId);

                    //Get new comment
                    WorkCommentsGateway workCommentsGateway = new WorkCommentsGateway();
                    workCommentsGateway.LoadByAssetIdWorkTypeProjectId(sectionAssetId, companyId, "Point Repairs", projectId);
                    WorkComments workComments = new WorkComments(workCommentsGateway.Data);
                    string newComment = workComments.GetCommentsSummary(companyId, workCommentsGateway.Table.Rows.Count, "\n");

                    Work work = new Work(null);
                    work.UpdateDirect(workId, projectId, sectionAssetId, originalWorkType, originalLibraryCategoriesId, false, companyId, originalComment, originalHistory, workId, projectId, sectionAssetId, originalWorkType, originalLibraryCategoriesId, false, companyId, newComment, originalHistory);
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateFllWork
        /// </summary>
        /// <param name="sectionAssetId">sectionAssetId</param>
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
        /// <param name="originalIssue">originalIssue</param>
        /// <param name="originalStandardBypassComments">originalStandardBypassComments</param>
        /// <param name="originalTrafficControlDetails">originalTrafficControlDetails</param>
        /// <param name="originalMeasurementType">originalMeasurementType</param>
        /// <param name="originalMeasurementFromMh">originalMeasurementFromMh</param>
        /// <param name="originalVideoDoneFromMh">originalVideoDoneFromMh</param>
        /// <param name="originalVideoDoneToMh">originalVideoDoneToMh</param>
        /// <param name="originalRoboticPrepDate">originalRoboticPrepDate</param>
        /// <param name="originalVideoLength">originalVideoLength</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
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
        /// <param name="newIssue">newIssue</param>
        /// <param name="newStandardBypassComments">newStandardBypassComments</param>
        /// <param name="newTrafficControlDetails">newTrafficControlDetails</param>
        /// <param name="newMeasurementType">newMeasurementType</param>
        /// <param name="newMeasurementFromMh">newMeasurementFromMh</param>
        /// <param name="newVideoDoneFromMh">newVideoDoneFromMh</param>
        /// <param name="newVideoDoneToMh">newVideoDoneToMh</param>
        ///<param name="newVideoLength">newVideoLength</param>        
        /// <param name="newComments">newComments</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newAccessType">newAccessType</param>
        /// <param name="newP1Completed">newP1Completed</param>
        private void UpdateFllWork(int sectionAssetId, Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int workId, string originalClientId, DateTime? originalProposedLiningDate, DateTime? originalDeadlineLiningDate, DateTime? originalP1Date, DateTime? originalM1Date, DateTime? originalM2Date, DateTime? originalInstallDate, DateTime? originalFinalVideoDate, bool originalIssueIdentified, bool originalIssueLFS, bool originalIssueClient, bool originalIssueSales, bool originalIssueGivenToClient, bool originalIssueResolved, bool originalIssueInvestigation, int? originalCxisRemoved, bool originalRoboticPrepCompleted, DateTime? originalRoboticPrepCompletedDate, string originalMeasurementTakenBy, string originalTrafficControl, string originalSiteDetails, bool originalPipeSizeChange, bool originalStandardBypass, string originalStandardBypassComments, string originalTrafficControlDetails, string originalMeasurementType, string originalMeasurementFromMh, string originalVideoDoneFromMh, string originalVideoDoneToMh, string originalVideoLength, string originalComments, bool originalDeleted, int originalCompanyId, string originalMaterials, string originalAccessType, bool originalP1Completed, string newClientId, DateTime? newProposedLiningDate, DateTime? newDeadlineLiningDate, DateTime? newP1Date, DateTime? newM1Date, DateTime? newM2Date, DateTime? newInstallDate, DateTime? newFinalVideoDate, bool newIssueIdentified, bool newIssueLFS, bool newIssueClient, bool newIssueSales, bool newIssueGivenToClient, bool newIssueResolved, bool newIssueInvestigation, int? newCxisRemoved, bool newRoboticPrepCompleted, DateTime? newRoboticPrepCompletedDate, string newMeasurementTakenBy, string newMaterials, string newTrafficControl, string newSiteDetails, bool newPipeSizeChange, bool newStandardBypass, string newStandardBypassComments, string newTrafficControlDetails, string newMeasurementType, string newMeasurementFromMh, string newVideoDoneFromMh, string newVideoDoneToMh, string newVideoLength, string newComments, bool newDeleted, int newCompanyId, string newAccessType, bool newP1Completed)
        {
            if (newSiteDetails == "(Select a Site Detail)") newSiteDetails = "Not applicable";

            // Update P1 fullLengthLining
            WorkFullLengthLiningP1 workFullLengthLiningP1 = new WorkFullLengthLiningP1(null);
            workFullLengthLiningP1.UpdateDirect(workId, originalCxisRemoved, originalRoboticPrepCompleted, originalRoboticPrepCompletedDate, originalDeleted, originalCompanyId, originalP1Completed, workId, newCxisRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newDeleted, newCompanyId, newP1Completed);

            // Update M1 fullLengthLining
            WorkFullLengthLiningM1 workFullLengthLiningM1 = new WorkFullLengthLiningM1(null);
            workFullLengthLiningM1.UpdateDirect(workId, originalMeasurementFromMh, originalTrafficControl, originalSiteDetails, originalPipeSizeChange, originalStandardBypass, originalStandardBypassComments, originalTrafficControlDetails, originalMeasurementType, originalMeasurementFromMh, originalVideoDoneFromMh, originalVideoDoneToMh, originalDeleted, originalCompanyId, originalAccessType, workId, newMeasurementTakenBy, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardBypass, newStandardBypassComments, newTrafficControlDetails, newMeasurementType, newMeasurementFromMh, newVideoDoneFromMh, newVideoDoneToMh, newDeleted, newCompanyId, newAccessType);

            // Update M2 fullLengthLining (VideoLength)
            WorkFullLengthLiningM2 workFullLengthLiningM2 = new WorkFullLengthLiningM2(null);
            workFullLengthLiningM2.UpdateVideoLengthDirect(sectionAssetId, workId, originalVideoLength, originalDeleted, originalCompanyId, workId, newVideoLength, newDeleted, newCompanyId);

            // Update fullLengthLining
            WorkFullLengthLiningGateway workFullLengthLiningGateway = new WorkFullLengthLiningGateway(null);
            workFullLengthLiningGateway.Update(workId, originalClientId, originalProposedLiningDate, originalDeadlineLiningDate, originalP1Date, originalM1Date, originalM2Date, originalInstallDate, originalFinalVideoDate, originalIssueIdentified, originalIssueLFS, originalIssueClient, originalIssueSales, originalIssueGivenToClient, originalIssueResolved, originalDeleted, originalCompanyId, originalIssueInvestigation, workId, newClientId, newProposedLiningDate, newDeadlineLiningDate, newP1Date, newM1Date, newM2Date, newInstallDate, newFinalVideoDate, newIssueIdentified, newIssueLFS, newIssueClient, newIssueSales, newIssueGivenToClient, newIssueResolved, newIssueInvestigation, newDeleted, newCompanyId);
        }



        /// <summary>
        /// UpdateRaWork
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="originalPreFlushDate">originalPreFlushDate</param>
        /// <param name="originalPreVideoDate">originalPreVideoDate</param>
        /// <param name="newPreFlushDate">newPreFlushDate</param>
        /// <param name="newPreVideoDate">newPreVideoDate</param>
        /// <param name="companyId">companyId</param>
        private void UpdateRaWork(int workId, DateTime? originalPreFlushDate, DateTime? originalPreVideoDate, DateTime? newPreFlushDate, DateTime? newPreVideoDate, int companyId)
        {
            WorkRehabAssessment workRehabAssessment = new WorkRehabAssessment(null);
            workRehabAssessment.UpdateDirect(workId, originalPreFlushDate, originalPreVideoDate, false, companyId, workId, newPreFlushDate, newPreVideoDate, false, companyId);
        }


        
        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Row obtained</returns>
        private PointRepairsTDS.WorkDetailsRow GetRow(int workId)
        {
            PointRepairsTDS.WorkDetailsRow row = ((PointRepairsTDS.WorkDetailsDataTable)Table).FindByWorkID(workId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.PointRepairs.PointRepairsWorkDetails.GetRow");
            }

            return row;
        }



    }
}