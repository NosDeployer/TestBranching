using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.RehabAssessment;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.RehabAssessment
{
    /// <summary>
    /// RehabAssessmentWorkDetails
    /// </summary>
    public class RehabAssessmentWorkDetails : TableModule
    {
    // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RehabAssessmentWorkDetails()
            : base("WorkDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RehabAssessmentWorkDetails(DataSet data)
            : base(data, "WorkDetails")
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
        /// LoadByWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByWorkId(int workId, int companyId)
        {
            RehabAssessmentWorkDetailsGateway rehabAssessmentWorkDetailsGateway = new RehabAssessmentWorkDetailsGateway(Data);
            rehabAssessmentWorkDetailsGateway.LoadByWorkId(workId, companyId);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="workIdFll">workIdFll</param>
        /// <param name="clientID">clientID</param>
        /// <param name="p1Date">p1Date</param>
        /// <param name="m1Date">m1Date</param>
        /// <param name="CXIsRemoved">CXIsRemoved</param>
        /// <param name="roboticPrepCompleted">roboticPrepCompleted</param>
        /// <param name="roboticPrepCompletedDate">roboticPrepCompletedDate</param>
        /// <param name="measurementTakenBy">measurementTakenBy</param>
        /// <param name="trafficControl">trafficControl</param>
        /// <param name="siteDetails">siteDetails</param>
        /// <param name="pipeSizeChange">pipeSizeChange</param>
        /// <param name="standardBypass">standardBypass</param>
        /// <param name="standardBypassComments">standardBypassComments</param>
        /// <param name="trafficControlDetails">trafficControlDetails</param>       
        /// <param name="material">material</param>
        /// <param name="measurementType">measurementType</param>
        /// <param name="measuredFromMh">measuredFromMh</param>
        /// <param name="videoDoneFromMh">videoDoneFromMh</param>
        /// <param name="videoDoneToMh">videoDoneToMh</param>
        /// <param name="videoDistanceM2">videoDistanceM2</param>
        /// <param name="preFlushDate">preFlushDate</param>
        /// <param name="preVideoDate">preVideoDate</param>
        /// <param name="accessType">accessType</param>
        /// <param name="p1Completed">p1Completed</param>
        public void Update(int workId, int workIdFll, string clientID, DateTime? p1Date, DateTime? m1Date, int? CXIsRemoved, bool roboticPrepCompleted, DateTime? roboticPrepCompletedDate, string measurementTakenBy, string trafficControl, string siteDetails, bool pipeSizeChange, bool standardBypass, string standardBypassComments, string trafficControlDetails, string material, string measurementType, string measuredFromMh, string videoDoneFromMh, string videoDoneToMh, string videoDistanceM2, DateTime? preVideoDate, DateTime? preFlushDate, string accessType, bool p1Completed)
        {
            RehabAssessmentTDS.WorkDetailsRow row = GetRow(workId);
            
            // WorkID for FLL
            if (workIdFll != 0) row.WorkIDFll = workIdFll; else row.SetWorkIDFllNull();

            // General
            if (clientID.Trim() != "") row.ClientID = clientID; else row.SetClientIDNull();

            // Prep
            if (p1Date.HasValue) row.P1Date = (DateTime)p1Date; else row.SetP1DateNull();
            if (CXIsRemoved.HasValue) row.CXIsRemoved = (int)CXIsRemoved; else row.SetCXIsRemovedNull();
            row.RoboticPrepCompleted = roboticPrepCompleted;
            if (roboticPrepCompletedDate.HasValue) row.RoboticPrepCompletedDate = (DateTime)roboticPrepCompletedDate; else row.SetRoboticPrepCompletedDateNull();
            row.P1Completed = p1Completed;

            // M1
            if (m1Date.HasValue) row.M1Date = (DateTime)m1Date; else row.SetM1DateNull();
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
            if (accessType != "") row.AccessType = accessType; else row.SetAccessTypeNull();
            
            // M2
            if (videoDistanceM2 != "") row.VideoDistance = videoDistanceM2; else row.SetVideoDistanceNull();
            
            // RA
            if (preFlushDate.HasValue) row.PreFlushDate = (DateTime)preFlushDate; else row.SetPreFlushDateNull();
            if (preVideoDate.HasValue) row.PreVideoDate = (DateTime)preVideoDate; else row.SetPreVideoDateNull();
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sectionAssetId">sectionAssetId</param>
        public void Save(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int projectId, int companyId, int sectionAssetId)
        {
            RehabAssessmentTDS rehabAssessmentChanges = (RehabAssessmentTDS)Data.GetChanges();

            if (rehabAssessmentChanges.WorkDetails.Rows.Count > 0)
            {
                RehabAssessmentWorkDetailsGateway rehabAssessmentWorkDetailsGateway = new RehabAssessmentWorkDetailsGateway(rehabAssessmentChanges);

                // Update sections
                foreach (RehabAssessmentTDS.WorkDetailsRow workDetailsRow in (RehabAssessmentTDS.WorkDetailsDataTable)rehabAssessmentChanges.WorkDetails)
                {
                    // Unchanged values
                    int workId = workDetailsRow.WorkID;                    

                    // Original values
                    // ... General
                    string originalClientId = rehabAssessmentWorkDetailsGateway.GetClientIdOriginal(workId);
                    DateTime? originalPreFlushDate = rehabAssessmentWorkDetailsGateway.GetPreFlushDateOriginal(workId);
                    DateTime? originalPreVideoDate = rehabAssessmentWorkDetailsGateway.GetPreVideoDateOriginal(workId);

                    // ... P1
                    DateTime? originalP1Date = rehabAssessmentWorkDetailsGateway.GetP1DateOriginal(workId);
                    int? originalCxisRemoved = rehabAssessmentWorkDetailsGateway.GetCxisRemovedOriginal(workId);
                    bool originalRoboticPrepCompleted = rehabAssessmentWorkDetailsGateway.GetRoboticPrepCompletedOriginal(workId);
                    DateTime? originalRoboticPrepCompletedDate = rehabAssessmentWorkDetailsGateway.GetRoboticPrepCompletedDateOriginal(workId);
                    bool originalP1Completed = rehabAssessmentWorkDetailsGateway.GetP1CompletedOriginal(workId);
                    
                    // ... M1
                    DateTime? originalM1Date = rehabAssessmentWorkDetailsGateway.GetM1DateOriginal(workId);
                    string originalMeasurementTakenBy = rehabAssessmentWorkDetailsGateway.GetMeasurementTakenByOriginal(workId);
                    string originalTrafficControl = rehabAssessmentWorkDetailsGateway.GetTrafficControlOriginal(workId);
                    string originalSiteDetails = rehabAssessmentWorkDetailsGateway.GetSiteDetailsOriginal(workId);
                    bool originalPipeSizeChange = rehabAssessmentWorkDetailsGateway.GetPipeSizeChange(workId);
                    bool originalStandardBypass = rehabAssessmentWorkDetailsGateway.GetStandardBypass(workId);
                    string originalStandardBypassComments = rehabAssessmentWorkDetailsGateway.GetStandardBypassCommentsOriginal(workId);
                    string originalTrafficControlDetails = rehabAssessmentWorkDetailsGateway.GetTrafficControlDetailsOriginal(workId);
                    string originalMeasurementType = rehabAssessmentWorkDetailsGateway.GetMeasurementTypeOriginal(workId);
                    string originalMeasurementFromMh = rehabAssessmentWorkDetailsGateway.GetMeasurementFromMhOriginal(workId);
                    string originalVideoDoneFromMh = rehabAssessmentWorkDetailsGateway.GetVideoDoneFromMhOriginal(workId);
                    string originalVideoDoneToMh = rehabAssessmentWorkDetailsGateway.GetVideoDoneToMhOriginal(workId);                    
                    string originalMaterial = rehabAssessmentWorkDetailsGateway.GetMaterialOriginal(workId);
                    string originalAccessType = rehabAssessmentWorkDetailsGateway.GetAccessTypeOriginal(workId);

                    // ... Comments
                    string originalComments = rehabAssessmentWorkDetailsGateway.GetCommentsOriginal(workId);

                    // ... M2
                    string originalVideoDistance = rehabAssessmentWorkDetailsGateway.GetVideoDistanceOriginal(workId);
                                        
                    // New variables
                    // ... General
                    string newClientId = rehabAssessmentWorkDetailsGateway.GetClientId(workId);

                    // ... P1
                    DateTime? newP1Date = rehabAssessmentWorkDetailsGateway.GetP1Date(workId);
                    int? newCxisRemoved = rehabAssessmentWorkDetailsGateway.GetCxisRemoved(workId);
                    bool newRoboticPrepCompleted = rehabAssessmentWorkDetailsGateway.GetRoboticPrepCompleted(workId);
                    DateTime? newRoboticPrepCompletedDate = rehabAssessmentWorkDetailsGateway.GetRoboticPrepCompletedDate(workId);
                    bool newP1Completed = rehabAssessmentWorkDetailsGateway.GetP1Completed(workId);

                    // ... M1
                    DateTime? newM1Date = rehabAssessmentWorkDetailsGateway.GetM1Date(workId);                    
                    string newMeasurementTakenBy = rehabAssessmentWorkDetailsGateway.GetMeasurementTakenBy(workId);
                    string newTrafficControl = rehabAssessmentWorkDetailsGateway.GetTrafficControl(workId);
                    string newSiteDetails = rehabAssessmentWorkDetailsGateway.GetSiteDetails(workId);
                    bool newPipeSizeChange = rehabAssessmentWorkDetailsGateway.GetPipeSizeChange(workId);
                    bool newStandardBypass = rehabAssessmentWorkDetailsGateway.GetStandardBypass(workId);
                    string newStandardBypassComments = rehabAssessmentWorkDetailsGateway.GetStandardBypassComments(workId);
                    string newTrafficControlDetails = rehabAssessmentWorkDetailsGateway.GetTrafficControlDetails(workId);
                    string newMeasurementType = rehabAssessmentWorkDetailsGateway.GetMeasurementType(workId);
                    string newMeasurementFromMh = rehabAssessmentWorkDetailsGateway.GetMeasurementFromMh(workId);
                    string newVideoDoneFromMh = rehabAssessmentWorkDetailsGateway.GetVideoDoneFromMh(workId);
                    string newVideoDoneToMh = rehabAssessmentWorkDetailsGateway.GetVideoDoneToMh(workId);
                    string newMaterial = rehabAssessmentWorkDetailsGateway.GetMaterial(workId);
                    string newAccessType = rehabAssessmentWorkDetailsGateway.GetAccessType(workId);

                    // ... M2
                    string newVideoDistance = rehabAssessmentWorkDetailsGateway.GetVideoDistance(workId);
                    
                    // ... Comments
                    string newComments = rehabAssessmentWorkDetailsGateway.GetComments(workId);
                    
                    // ... RA
                    DateTime? newPreFlushDate = rehabAssessmentWorkDetailsGateway.GetPreFlushDate(workId);
                    DateTime? newPreVideoDate = rehabAssessmentWorkDetailsGateway.GetPreVideoDate(workId);

                    // ... FLL WorkID
                    int workIdFll = 0; if (!workDetailsRow.IsWorkIDFllNull()) workIdFll = workDetailsRow.WorkIDFll;

                    if (workIdFll != 0) // ... Has Fll work
                    {
                        WorkFullLengthLiningGateway workFullLengthLiningGateway = new WorkFullLengthLiningGateway();
                        workFullLengthLiningGateway.LoadByWorkId(workIdFll, companyId);

                        DateTime? originalProposedLiningDate = workFullLengthLiningGateway.GetProposedLiningDate(workIdFll);
                        DateTime? originalDeadlineLiningDate = workFullLengthLiningGateway.GetDeadlineLiningDate(workIdFll);
                        DateTime? originalM2Date = workFullLengthLiningGateway.GetM2Date(workIdFll);
                        DateTime? originalInstallDate = workFullLengthLiningGateway.GetInstallDate(workIdFll);
                        DateTime? originalFinalVideoDate = workFullLengthLiningGateway.GetFinalVideoDate(workIdFll);
                        bool originalIssueIdentified = workFullLengthLiningGateway.GetIssueIdentified(workIdFll);
                        bool originalIssueLFS = workFullLengthLiningGateway.GetIssueLFS(workIdFll);
                        bool originalIssueClient = workFullLengthLiningGateway.GetIssueClient(workIdFll);
                        bool originalIssueSales = workFullLengthLiningGateway.GetIssueSales(workIdFll);
                        bool originalIssueGivenToClient = workFullLengthLiningGateway.GetIssueGivenToClient(workIdFll);
                        bool originalIssueResolved = workFullLengthLiningGateway.GetIssueResolved(workIdFll);
                        bool originalIssueInvestigation = workFullLengthLiningGateway.GetIssueInvestigation(workIdFll);
                        
                        // ... Update work
                        UpdateFllWork(sectionAssetId, countryId, provinceId, countyId, cityId, workIdFll, originalClientId, originalProposedLiningDate, originalDeadlineLiningDate, originalP1Date, originalM1Date, originalM2Date, originalInstallDate, originalFinalVideoDate, originalIssueIdentified, originalIssueLFS, originalIssueClient, originalIssueSales, originalIssueGivenToClient, originalIssueResolved, originalIssueInvestigation, originalCxisRemoved, originalRoboticPrepCompleted, originalRoboticPrepCompletedDate, originalMeasurementTakenBy, originalTrafficControl, originalSiteDetails, originalPipeSizeChange, originalStandardBypass, originalStandardBypassComments, originalTrafficControlDetails, originalMeasurementType, originalMeasurementFromMh, originalVideoDoneFromMh, originalVideoDoneToMh, originalVideoDistance, originalComments, false, companyId, originalMaterial, originalAccessType, originalP1Completed, newClientId, originalProposedLiningDate, originalDeadlineLiningDate, newP1Date, newM1Date, originalM2Date, originalInstallDate, originalFinalVideoDate, originalIssueIdentified, originalIssueLFS, originalIssueClient, originalIssueSales, originalIssueGivenToClient, originalIssueResolved, originalIssueInvestigation, newCxisRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newMeasurementTakenBy, newMaterial, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardBypass, newStandardBypassComments, newTrafficControlDetails, newMeasurementType, newMeasurementFromMh, newVideoDoneFromMh, newVideoDoneToMh, newVideoDistance, newComments, false, companyId, newAccessType, newP1Completed);
                        UpdateRaWork(workId, originalPreFlushDate, originalPreVideoDate, newPreFlushDate, newPreVideoDate, companyId);
                    }
                    else
                    {
                        if (newClientId != "" || newP1Date.HasValue || newCxisRemoved.HasValue || newM1Date.HasValue || newMeasurementTakenBy != "" || newMaterial != "" || newTrafficControl != "" || newMeasurementType != "" || newMeasurementFromMh != "" || newVideoDoneFromMh != "" || newVideoDoneToMh != "" || newStandardBypassComments != "" || newTrafficControlDetails != ""  || newVideoDistance != "") // Insert Fll work
                        {
                            WorkFullLengthLining workFullLengthLining = new WorkFullLengthLining(null);
                            workIdFll = workFullLengthLining.InsertDirectEmptyWorks(projectId, sectionAssetId, null, "", null, null, null, null, null, null, null, false, false, false, false, false, false, false, companyId, false, "", "");

                            WorkFullLengthLiningGateway workFullLengthLiningGateway = new WorkFullLengthLiningGateway();
                            workFullLengthLiningGateway.LoadByWorkId(workIdFll, companyId);

                            DateTime? originalProposedLiningDate = workFullLengthLiningGateway.GetProposedLiningDate(workIdFll);
                            DateTime? originalDeadlineLiningDate = workFullLengthLiningGateway.GetDeadlineLiningDate(workIdFll);
                            DateTime? originalM2Date = workFullLengthLiningGateway.GetM2Date(workIdFll);
                            DateTime? originalInstallDate = workFullLengthLiningGateway.GetInstallDate(workIdFll);
                            DateTime? originalFinalVideoDate = workFullLengthLiningGateway.GetFinalVideoDate(workIdFll);
                            bool originalIssueIdentified = workFullLengthLiningGateway.GetIssueIdentified(workIdFll);
                            bool originalIssueLFS = workFullLengthLiningGateway.GetIssueLFS(workIdFll);
                            bool originalIssueClient = workFullLengthLiningGateway.GetIssueClient(workIdFll);
                            bool originalIssueSales = workFullLengthLiningGateway.GetIssueSales(workIdFll);
                            bool originalIssueGivenToClient = workFullLengthLiningGateway.GetIssueGivenToClient(workIdFll);
                            bool originalIssueResolved = workFullLengthLiningGateway.GetIssueResolved(workIdFll);
                            bool originalIssueInvestigation = workFullLengthLiningGateway.GetIssueInvestigation(workIdFll);

                            // ... Update work
                            UpdateFllWork(sectionAssetId, countryId, provinceId, countyId, cityId, workIdFll, originalClientId, originalProposedLiningDate, originalDeadlineLiningDate, originalP1Date, originalM1Date, originalM2Date, originalInstallDate, originalFinalVideoDate, originalIssueIdentified, originalIssueLFS, originalIssueClient, originalIssueSales, originalIssueGivenToClient, originalIssueResolved, originalIssueInvestigation, originalCxisRemoved, originalRoboticPrepCompleted, originalRoboticPrepCompletedDate, originalMeasurementTakenBy, originalTrafficControl, originalSiteDetails, originalPipeSizeChange, originalStandardBypass, originalStandardBypassComments, originalTrafficControlDetails, originalMeasurementType, originalMeasurementFromMh, originalVideoDoneFromMh, originalVideoDoneToMh, originalVideoDistance, originalComments, false, companyId, originalMaterial, originalAccessType, originalP1Completed, newClientId, originalProposedLiningDate, originalDeadlineLiningDate, newP1Date, newM1Date, originalM2Date, originalInstallDate, originalFinalVideoDate, originalIssueIdentified, originalIssueLFS, originalIssueClient, originalIssueSales, originalIssueGivenToClient, originalIssueResolved, originalIssueInvestigation, newCxisRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newMeasurementTakenBy, newMaterial, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardBypass, newStandardBypassComments, newTrafficControlDetails, newMeasurementType, newMeasurementFromMh, newVideoDoneFromMh, newVideoDoneToMh, newVideoDistance, newComments, false, companyId, newAccessType, newP1Completed);
                            UpdateRaWork(workId, originalPreFlushDate, originalPreVideoDate, newPreFlushDate, newPreVideoDate, companyId);
                        }
                        else // ... Do not have Fll work
                        {
                            UpdateRaWork(workId, originalPreFlushDate, originalPreVideoDate, newPreFlushDate, newPreVideoDate, companyId);
                        }
                    }

                    // JL Section WorkID
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

            RehabAssessmentTDS.WorkDetailsRow row = GetRow(workId);
            
            workGateway.LoadByWorkId(workId, companyId);
            workComentsGateway.LoadByWorkIdWorkType(workId, companyId, "Rehab Assessment");
            row.Comments = workComments.GetAllComments(workId, companyId, workComentsGateway.Table.Rows.Count, "\n");            
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="workId">workId</param>
        public void Delete(int workId)
        {
            RehabAssessmentTDS.WorkDetailsRow row = GetRow(workId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteDirectAll
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirectAll(int projectId, int assetId, int companyId)
        {
            int workIdRa = GetWorkId(projectId, assetId, "Rehab Assessment", companyId);            
            int workIdFll = GetWorkId(projectId, assetId, "Full Length Lining", companyId);           

            // Delete work
            WorkRehabAssessment workRehabAssessment = new WorkRehabAssessment(null);
            workRehabAssessment.DeleteDirect(workIdRa, companyId);

            // Delete work
            WorkFullLengthLining workFullLengthLining = new WorkFullLengthLining(null);
            workFullLengthLining.DeleteDirect(workIdFll, companyId);

            // Delete section
            LfsAssetSewerSection lfsAssetSewerSection = new LfsAssetSewerSection(null);
            lfsAssetSewerSection.DeleteDirect(assetId, companyId);                     
        }



        /// <summary>
        /// DeleteDirectRaOnly
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirectRaOnly(int workId, int assetId, int companyId)
        {
            // Delete work
            WorkRehabAssessment workRehabAssessment = new WorkRehabAssessment(null);
            workRehabAssessment.DeleteDirect(workId, companyId);

            // Delete section
            LfsAssetSewerSection lfsAssetSewerSection = new LfsAssetSewerSection(null);
            lfsAssetSewerSection.DeleteDirect(assetId, companyId);
        }
 





        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetWorkId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        private int GetWorkId(int projectId, int assetId, string workType, int companyId)
        {
            int workId = 0;
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, workType, companyId);
            if (workGateway.Table.Rows.Count > 0)
            {
                // Get WorkId
                workId = workGateway.GetWorkId(assetId, workType, projectId);
            }

            return workId;
        }



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
        private RehabAssessmentTDS.WorkDetailsRow GetRow(int workId)
        {
            RehabAssessmentTDS.WorkDetailsRow row = ((RehabAssessmentTDS.WorkDetailsDataTable)Table).FindByWorkID(workId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.RehabAssessment.RehabAssessmentWorkDetails.GetRow");
            }

            return row;
        }



    }
}