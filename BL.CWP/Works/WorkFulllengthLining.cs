using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLining
    /// </summary>
    public class WorkFullLengthLining : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLining() : base("LFS_WORK_FULLLENGTHLINING")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLining(DataSet data) : base(data, "LFS_WORK_FULLLENGTHLINING")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WorkTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //
        
        /// <summary>
        /// Insert a new Full Length Lining Work (direct to DB), empty works
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="proposedLiningDate">proposedLiningDate</param>
        /// <param name="deadlineLiningDate">deadlineLiningDate</param>
        /// <param name="p1Date">p1Date</param>
        /// <param name="m1Date">m1Date</param>
        /// <param name="m2Date">m2Date</param>
        /// <param name="installDate">installDate</param>
        /// <param name="finalVideoDate">finalVideoDate</param>
        /// <param name="issueIdentified">issueIdentified</param>
        /// <param name="issueLfs">issueLfs</param>
        /// <param name="issueClient">issueClient</param>
        /// <param name="issueSales">issueSales</param>
        /// <param name="issueGivenToClient">issueGivenToClient</param>
        /// <param name="issueResolved">issueResolved</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="issueInvestigation">issueInvestigation</param>
        /// <param name="comments">comments</param>
        /// <param name="history">history</param>
        /// <returns>int</returns>
        public int InsertDirectEmptyWorks(int projectId, int assetId, int? libraryCategoriesId, string clientId, DateTime? proposedLiningDate, DateTime? deadlineLiningDate, DateTime? p1Date, DateTime? m1Date, DateTime? m2Date, DateTime? installDate, DateTime? finalVideoDate, bool issueIdentified, bool issueLfs, bool issueClient, bool issueSales, bool issueGivenToClient, bool issueResolved, bool deleted, int companyId, bool issueInvestigation, string comments, string history)
        {
            int workId = 0;

            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Full Length Lining", companyId);

            if (workGateway.Table.Rows.Count == 0)
            {
                workId = new Work(null).InsertDirect(projectId, assetId, "Full Length Lining", libraryCategoriesId, deleted, companyId, comments, history);
                new WorkFullLengthLiningGateway(null).Insert(workId, clientId, proposedLiningDate, deadlineLiningDate, p1Date, m1Date, m2Date, installDate, finalVideoDate, issueIdentified, issueLfs, issueClient, issueSales, issueGivenToClient, issueResolved, deleted, companyId, issueInvestigation);
                new WorkFullLengthLiningP1Gateway(null).Insert(workId, null, deleted, companyId, false, null, false);
                new WorkFullLengthLiningM1Gateway(null).Insert(workId, "", "", "", false, false, "", "", "", "", "", "", deleted, companyId, "");
                new WorkFullLengthLiningM2Gateway(null).Insert(workId,"", "", false, "", null, "", "", "No", "", "", false, false, false, false, false, false, false, false, false, false, deleted, companyId, false);
            }
            else
            {
                workId = workGateway.GetWorkId(assetId, "Full Length Lining", projectId);
            }

            return workId;
        }



        /// <summary>
        /// Insert a new Full Length Lining Work (direct to DB), full Data
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="proposedLiningDate">proposedLiningDate</param>
        /// <param name="deadlineLiningDate">deadlineLiningDate</param>
        /// <param name="p1Date">p1Date</param>
        /// <param name="m1Date">m1Date</param>
        /// <param name="m2Date">m2Date</param>
        /// <param name="installDate">installDate</param>
        /// <param name="finalVideoDate">finalVideoDate</param>
        /// <param name="issueIdentified">issueIdentified</param>
        /// <param name="issueLfs">issueLfs</param>
        /// <param name="issueClient">issueClient</param>
        /// <param name="issueSales">issueSales</param>
        /// <param name="issueGivenToClient">issueGivenToClient</param>
        /// <param name="issueResolved">issueResolved</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="issueInvestigation">issueInvestigation</param>
        /// <param name="comments">comments</param>
        /// <param name="history">history</param>
        /// <param name="cxisRemoved">cxisRemoved</param>
        /// <param name="roboticPrepCompleted">roboticPrepCompleted</param>
        /// <param name="roboticPrepCompletedDate">roboticPrepCompletedDate</param>
        /// <param name="measurementTakenBy">measurementTakenBy</param>
        /// <param name="trafficControl">trafficControl</param>
        /// <param name="siteDetails">siteDetails</param>
        /// <param name="pipeSizeChange">pipeSizeChange</param>
        /// <param name="standardByPass">standardByPass</param>        
        /// <param name="standardByPassComments">standardByPassComments</param>
        /// <param name="trafficControlDetails">trafficControlDetails</param>
        /// <param name="measurementType">measurementType</param>
        /// <param name="measurementFromMH">measurementFromMH</param>
        /// <param name="videoDoneFromMH">videoDoneFromMH</param>
        /// <param name="videoDoneToMH">videoDoneToMH</param>
        /// <param name="videoLength">videoLength</param>
        /// <param name="measurementTakenBy2">measurementTakenBy2</param>
        /// <param name="dropPipe">dropPipe</param>
        /// <param name="dropPipeInvertDepth">dropPipeInvertDepth</param>
        /// <param name="cappedLaterals">cappedLaterals</param>
        /// <param name="lineWithID">lineWithID</param>
        /// <param name="hydrantAddress">hydrantAddress</param>
        /// <param name="hydroWireWithin10FtOfInversionMH">hydroWireWithin10FtOfInversionMH</param>
        /// <param name="distanceToInversionMH">distanceToInversionMH</param>
        /// <param name="surfaceGrade">surfaceGrade</param>
        /// <param name="hydroPulley">hydroPulley</param>
        /// <param name="fridgeCart">fridgeCart</param>
        /// <param name="twoPump">twoPump</param>
        /// <param name="sixBypass">sixBypass</param>
        /// <param name="scaffolding">scaffolding</param>
        /// <param name="winchExtention">winchExtention</param>
        /// <param name="extraGenerator">extraGenerator</param>
        /// <param name="greyCableExtension">greyCableExtension</param>
        /// <param name="easementMats">easementMats</param>
        /// <param name="rampRequired">rampRequired</param>
        /// <param name="cameraSkid">cameraSkid</param>
        /// <param name="accessType">accessType</param>
        /// <param name="p1Completed">p1Completed</param>
        /// <returns>int</returns>
        public int InsertDirectFullWork(int projectId, int assetId, int? libraryCategoriesId, string clientId, DateTime? proposedLiningDate, DateTime? deadlineLiningDate, DateTime? p1Date, DateTime? m1Date, DateTime? m2Date, DateTime? installDate, DateTime? finalVideoDate, bool issueIdentified, bool issueLfs, bool issueClient, bool issueSales, bool issueGivenToClient, bool issueResolved, bool deleted, int companyId, bool issueInvestigation, string comments, string history, int? cxisRemoved, bool roboticPrepCompleted, DateTime? roboticPrepCompletedDate, string measurementTakenBy, string trafficControl, string siteDetails, bool pipeSizeChange, bool standardByPass, string standardByPassComments, string trafficControlDetails, string  measurementType, string  measurementFromMH, string videoDoneFromMH, string videoDoneToMH, string videoLength, string  measurementTakenBy2,bool dropPipe, string dropPipeInvertDepth, int? cappedLaterals, string lineWithID,string hydrantAddress, string hydroWireWithin10FtOfInversionMH, string distanceToInversionMH, string surfaceGrade, bool hydroPulley, bool fridgeCart, bool twoPump, bool sixBypass, bool scaffolding, bool winchExtention, bool extraGenerator, bool greyCableExtension, bool easementMats, bool rampRequired, bool cameraSkid, string accessType, bool p1Completed)
        {
            int workId = 0;
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Full Length Lining", companyId);
            if (workGateway.Table.Rows.Count == 0)
            {
                workId = new Work(null).InsertDirect(projectId, assetId, "Full Length Lining", libraryCategoriesId, deleted, companyId, comments, history);
                new WorkFullLengthLiningGateway(null).Insert(workId, clientId, proposedLiningDate, deadlineLiningDate, p1Date, m1Date, m2Date, installDate, finalVideoDate, issueIdentified, issueLfs, issueClient, issueSales, issueGivenToClient, issueResolved, deleted, companyId, issueInvestigation);
                new WorkFullLengthLiningP1Gateway(null).Insert(workId, cxisRemoved, deleted, companyId, roboticPrepCompleted, roboticPrepCompletedDate, p1Completed);
                new WorkFullLengthLiningM1Gateway(null).Insert(workId, measurementTakenBy, trafficControl, siteDetails, pipeSizeChange, standardByPass, standardByPassComments, trafficControlDetails, measurementType, measurementFromMH, videoDoneFromMH, videoDoneToMH, deleted, companyId, accessType);                                                               
                new WorkFullLengthLiningM2Gateway(null).Insert(workId, videoLength, measurementTakenBy2, dropPipe, dropPipeInvertDepth, cappedLaterals, lineWithID, hydrantAddress, hydroWireWithin10FtOfInversionMH, distanceToInversionMH, surfaceGrade, hydroPulley, fridgeCart, twoPump, sixBypass, scaffolding, winchExtention, extraGenerator, greyCableExtension, easementMats, rampRequired,  deleted, companyId, cameraSkid);
            }
            else
            {
                workId = workGateway.GetWorkId(assetId, "Full Length Lining", projectId);
            }

            return workId;
        }


        
        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="sectionAssetId">sectionAssetId</param>
        /// <param name="originalWorkId">originalWorkId</param>        
        /// <param name="originalClientId">originalClientId</param>
        /// <param name="originalProposedLiningDate">originalProposedLiningDate</param>
        /// <param name="originalDeadlineLiningDate">originalDeadlineLiningDate</param>
        /// <param name="originalP1Date">originalP1Date</param>
        /// <param name="originalM1Date">originalM1Date</param>
        /// <param name="originalM2Date">originalM2Date</param>
        /// <param name="originalInstallDate">originalInstallDate</param>
        /// <param name="originalFinalVideo">originalFinalVideo</param>
        /// <param name="originalIssueIdentified">originalIssueIdentified</param>
        /// <param name="originalLfsIssue">originalLfsIssue</param>
        /// <param name="originalClientIssue">originalClientIssue</param>
        /// <param name="originalSalesIssue">originalSalesIssue</param>
        /// <param name="originalIssueGivenToClient">originalIssueGivenToClient</param>
        /// <param name="originalIssueResolved">originalIssueResolved</param>
        /// <param name="originalIssueInvestigation">originalIssueInvestigation</param>
        /// <param name="originalCxisRemoved">originalCxisRemoved</param>
        /// <param name="originalRoboticPrepCompleted">originalRoboticPrepCompleted</param>
        /// <param name="originalRoboticPrepCompletedDate">originalRoboticPrepCompletedDate</param>
        /// <param name="originalMeasurementsTakenBy">originalMeasurementsTakenBy</param> 
        /// <param name="originalTrafficControl">originalTrafficControl</param>
        /// <param name="originalSiteDetails">originalSiteDetails</param>
        /// <param name="originalPipeSizeChange">originalPipeSizeChange</param> 
        /// <param name="originalStandardByPass">originalStandardByPass</param>         
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
        /// <param name="originalLineWidthId">originalLineWidthId</param>
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
        /// <param name="originalRampsRequired">originalRampsRequired</param> 
        /// <param name="originalVideoLength">originalVideoLength</param>        
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalCameraSkid">originalCameraSkid</param>
        /// <param name="originalAccessType">originalAccessType</param>
        /// <param name="originalP1Completed">originalP1Completed</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newClientId">newClientId</param>
        /// <param name="newProposedLiningDate">newProposedLiningDate</param>
        /// <param name="newDeadlineLiningDate">newDeadlineLiningDate</param>
        /// <param name="newP1Date">newP1Date</param>
        /// <param name="newM1Date">newM1Date</param>
        /// <param name="newM2Date">newM2Date</param>
        /// <param name="newInstallDate">newInstallDate</param>
        /// <param name="newFinalVideo">newFinalVideo</param>
        /// <param name="newIssueIdentified">newIssueIdentified</param>
        /// <param name="newLfsIssue">newLfsIssue</param>
        /// <param name="newClientIssue">newClientIssue</param>
        /// <param name="newSalesIssue">newSalesIssue</param>
        /// <param name="newIssueGivenToClient">newIssueGivenToClient</param>
        /// <param name="newIssueResolved">newIssueResolved</param>
        /// <param name="newIssueInvestigation">newIssueInvestigation</param>
        /// <param name="newCxisRemoved">newCxisRemoved</param> 
        /// <param name="newRoboticPrepCompleted">newRoboticPrepCompleted</param>
        /// <param name="newRoboticPrepCompletedDate">newRoboticPrepCompletedDate</param>
        /// <param name="newMeasurementsTakenBy">newMeasurementsTakenBy</param> 
        /// <param name="newTrafficControl">newTrafficControl</param>
        /// <param name="newSiteDetails">newSiteDetails</param>
        /// <param name="newPipeSizeChange">newPipeSizeChange</param> 
        /// <param name="newStandardByPass">newStandardByPass</param>         
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
        /// <param name="newLineWidthId">newLineWidthId</param>
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
        /// <param name="newRampsRequired">newRampsRequired</param>         
        /// <param name="newVideoLength">newVideoLength</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newCameraSkid">newCameraSkid</param>     
        /// <param name="newAccessType">newAccessType</param>
        /// <param name="newP1Completed">newP1Completed</param>
        public void UpdateDirect(int sectionAssetId, int originalWorkId, string originalClientId, DateTime? originalProposedLiningDate, DateTime? originalDeadlineLiningDate, DateTime? originalP1Date, DateTime? originalM1Date, DateTime? originalM2Date, DateTime? originalInstallDate, DateTime? originalFinalVideo, bool originalIssueIdentified, bool originalLfsIssue, bool originalClientIssue, bool originalSalesIssue, bool originalIssueGivenToClient, bool originalIssueResolved, bool originalIssueInvestigation, int? originalCxisRemoved, bool originalRoboticPrepCompleted, DateTime? originalRoboticPrepCompletedDate,  string originalMeasurementsTakenBy, string originalTrafficControl, string originalSiteDetails, bool originalPipeSizeChange, bool originalStandardByPass, string originalStandardBypassComments, string originalTrafficControlDetails, string originalMeasurementType, string originalMeasurementFromMh, string originalVideoDoneFromMh, string originalVideoDoneToMh, string originalMeasurementTakenByM2, bool originalDropPipe, string originalDropPipeInvertDepth, int? originalCappedLaterals, string originalLineWidthId, string originalHydrantAddress, string originalHydroWireWithin10FtOfInversionMH, string originalDistanceToInversionMh, string originalSurfaceGrade, bool originalHydroPulley, bool originalFridgeCart, bool originalTwoPump, bool originalSixBypass, bool originalScaffolding, bool originalWinchExtension, bool originalExtraGenerator, bool originalGreyCableExtension, bool originalEasementMats, bool originalRampsRequired, string originalVideoLength, bool originalDeleted, int originalCompanyId, bool originalCameraSkid, string originalAccessType, bool originalP1Completed, int newWorkId, string newClientId, DateTime? newProposedLiningDate, DateTime? newDeadlineLiningDate, DateTime? newP1Date, DateTime? newM1Date, DateTime? newM2Date, DateTime? newInstallDate, DateTime? newFinalVideo, bool newIssueIdentified, bool newLfsIssue, bool newClientIssue, bool newSalesIssue, bool newIssueGivenToClient, bool newIssueResolved, bool newIssueInvestigation, int? newCxisRemoved, bool newRoboticPrepCompleted, DateTime? newRoboticPrepCompletedDate, string newMeasurementsTakenBy, string newTrafficControl, string newSiteDetails, bool newPipeSizeChange, bool newStandardByPass, string newStandardBypassComments, string newTrafficControlDetails, string newMeasurementType, string newMeasurementFromMh, string newVideoDoneFromMh, string newVideoDoneToMh, string newMeasurementTakenByM2, bool newDropPipe, string newDropPipeInvertDepth, int? newCappedLaterals, string newDistanceToInversionMh, string newLineWidthId, string newHydrantAddress, string newHydroWireWithin10FtOfInversionMH, string newSurfaceGrade,  bool newHydroPulley, bool newFridgeCart, bool newTwoPump, bool newSixBypass, bool newScaffolding, bool newWinchExtension, bool newExtraGenerator, bool newGreyCableExtension, bool newEasementMats, bool newRampsRequired,   string newVideoLength,  bool newDeleted, int newCompanyId, bool newCameraSkid, string newAccessType, bool newP1Completed)
        {         
            // Update P1 fullLengthLining
            WorkFullLengthLiningP1 workFullLengthLiningP1 = new WorkFullLengthLiningP1(null);
            workFullLengthLiningP1.UpdateDirect(originalWorkId, originalCxisRemoved, originalRoboticPrepCompleted, originalRoboticPrepCompletedDate, originalDeleted, originalCompanyId, originalP1Completed, newWorkId, newCxisRemoved, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newDeleted, newCompanyId, newP1Completed);

            // Update M1 fullLengthLining
            WorkFullLengthLiningM1 workFullLengthLiningM1 = new WorkFullLengthLiningM1(null);
            workFullLengthLiningM1.UpdateDirect(originalWorkId, originalMeasurementsTakenBy, originalTrafficControl, originalSiteDetails, originalPipeSizeChange, originalStandardByPass, originalStandardBypassComments, originalTrafficControlDetails, originalMeasurementType, originalMeasurementFromMh, originalVideoDoneFromMh, originalVideoDoneToMh,  originalDeleted, originalCompanyId, originalAccessType, newWorkId, newMeasurementsTakenBy, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardByPass, newStandardBypassComments, newTrafficControlDetails, newMeasurementType, newMeasurementFromMh, newVideoDoneFromMh, newVideoDoneToMh, newDeleted, newCompanyId, newAccessType);

            // Update M2 fullLengthLining
            WorkFullLengthLiningM2 workFullLengthLiningM2 = new WorkFullLengthLiningM2(null);
            workFullLengthLiningM2.UpdateDirect(sectionAssetId, originalWorkId, originalVideoLength, originalMeasurementTakenByM2, originalDropPipe, originalDropPipeInvertDepth, originalCappedLaterals, originalLineWidthId, originalHydrantAddress, originalHydroWireWithin10FtOfInversionMH, originalDistanceToInversionMh, originalSurfaceGrade, originalHydroPulley, originalFridgeCart, originalTwoPump, originalSixBypass, originalScaffolding, originalWinchExtension, originalExtraGenerator, originalGreyCableExtension, originalEasementMats, originalRampsRequired, originalDeleted, originalCompanyId, originalCameraSkid, newWorkId, newVideoLength, newMeasurementTakenByM2, newDropPipe, newDropPipeInvertDepth, newCappedLaterals, newLineWidthId, newHydrantAddress, newHydroWireWithin10FtOfInversionMH, newDistanceToInversionMh, newSurfaceGrade, newHydroPulley, newFridgeCart, newTwoPump, newSixBypass, newScaffolding, newWinchExtension, newExtraGenerator, newGreyCableExtension, newEasementMats, newRampsRequired, newDeleted, newCompanyId, newCameraSkid);                 

            // Update fullLengthLining
            WorkFullLengthLiningGateway workFullLengthLiningGateway = new WorkFullLengthLiningGateway(null);
            workFullLengthLiningGateway.Update(originalWorkId, originalClientId, originalProposedLiningDate, originalDeadlineLiningDate, originalP1Date, originalM1Date, originalM2Date, originalInstallDate, originalFinalVideo, originalIssueIdentified, originalLfsIssue, originalClientIssue, originalSalesIssue, originalIssueGivenToClient, originalIssueResolved, originalDeleted, originalCompanyId, originalIssueInvestigation, newWorkId, newClientId, newProposedLiningDate, newDeadlineLiningDate, newP1Date, newM1Date, newM2Date, newInstallDate, newFinalVideo, newIssueIdentified, newLfsIssue, newClientIssue, newSalesIssue, newIssueGivenToClient, newIssueResolved, newIssueInvestigation, newDeleted, newCompanyId);
        }


              
        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, int companyId)
        {
            WorkFullLengthLiningGateway workFullLengthLiningGateway = new WorkFullLengthLiningGateway();
            workFullLengthLiningGateway.LoadByWorkId(workId, companyId);

            if (workFullLengthLiningGateway.Table.Rows.Count > 0)
            {
                // Delete P1
                WorkFullLengthLiningP1 workFullLengthLiningP1 = new WorkFullLengthLiningP1(null);
                workFullLengthLiningP1.DeleteDirect(workId, companyId);

                // Delete M1                
                WorkFullLengthLiningM1 workFullLengthLiningM1 = new WorkFullLengthLiningM1(null);
                workFullLengthLiningM1.DeleteDirect(workId, companyId);

                // Delete M2
                WorkFullLengthLiningM2 workFullLengthLiningM2 = new WorkFullLengthLiningM2(null);
                workFullLengthLiningM2.DeleteDirect(workId, companyId);

                // Delete WorkComments
                WorkComments workComments = new WorkComments(null);
                workComments.DeleteAllDirect(workId, companyId);

                // Delete Catalysts

                // Delete wet out data

                // delete inversion data

                // Delete WorkFullLengthLining
                workFullLengthLiningGateway.Delete(workId, companyId);

                // Delete work
                Work work = new Work(null);
                work.DeleteDirect(workId, companyId);
            }
        }


        
    }
}
