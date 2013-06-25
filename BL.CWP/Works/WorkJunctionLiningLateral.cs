using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkJunctionLiningLateral
    /// </summary>
    public class WorkJunctionLiningLateral : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkJunctionLiningLateral()
            : base("LFS_WORK_JUNCTIONLINING_LATERAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkJunctionLiningLateral(DataSet data)
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






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
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
        /// <param name="comments">comments</param>
        /// <param name="history">history</param>
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
        /// <returns>int</returns>
        public int InsertDirect(int projectId, int assetId, int sectionWorkId, DateTime? pipeLocated, DateTime? servicesLocated, DateTime? coInstalled, DateTime? backfilledConcrete, DateTime? backfilledSoil, DateTime? grouted, DateTime? cored, DateTime? prepped, DateTime? measured, string linerSize, DateTime? inProcess, DateTime? inStock, DateTime? delivered, int? builRebuild, DateTime? preVideo, DateTime? linerInstalled, DateTime? finalVideo, decimal? cost, DateTime? videoInspection, bool coRequired, bool pitRequired, string coPitLocation, bool postContractDigRequired, DateTime? coCutDown, DateTime? finalRestoration, bool deleted, int companyId, string comments, string history, string videoLengthToPropertyLine, bool liningThruCo, DateTime? noticeDelivered, string hamiltonInspectionNumber, string flange, string gasket, string depthOfLocated, bool digRequiredPriorToLining, DateTime? digRequiredPriorToLiningCompleted, bool digRequiredAfterLining, DateTime? digRequiredAfterLiningCompleted, bool outOfScope, bool holdClientIssue, DateTime? holdClientIssueResolved, bool holdLFSIssue, DateTime? holdLFSIssueResolved, bool requiresRoboticPrep, DateTime? requiresRoboticPrepCompleted, string linerType, string prepType, bool dyeTestReq, DateTime? dyeTestComplete, string contractYear)
        {
            int workId = 0;
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Junction Lining Lateral", companyId);
            
            if (workGateway.Table.Rows.Count == 0)
            {
                workId = new Work(null).InsertDirect(projectId, assetId, "Junction Lining Lateral", null, false, companyId, comments, history);
                new WorkJunctionLiningLateralGateway(null).Insert(workId, sectionWorkId, pipeLocated, servicesLocated, coInstalled, backfilledConcrete, backfilledSoil, grouted, cored, prepped, measured, linerSize, inProcess, inStock, delivered, builRebuild, preVideo, linerInstalled, finalVideo, cost, videoInspection, coRequired, pitRequired, coPitLocation, postContractDigRequired, coCutDown, finalRestoration, deleted, companyId, videoLengthToPropertyLine, liningThruCo, noticeDelivered, hamiltonInspectionNumber, flange, gasket, depthOfLocated, digRequiredPriorToLining, digRequiredPriorToLiningCompleted, digRequiredAfterLining, digRequiredAfterLiningCompleted, outOfScope, holdClientIssue, holdClientIssueResolved, holdLFSIssue, holdLFSIssueResolved, requiresRoboticPrep,  requiresRoboticPrepCompleted, linerType, prepType, dyeTestReq, dyeTestComplete, contractYear);

                // Update WorkJunctionLiningSection
                UpdateSection(sectionWorkId, workId, companyId);                
            }
            else
            {
                workId = workGateway.GetWorkId(assetId, "Junction Lining Lateral", projectId);
            }

            return workId;
        }



        /// <summary>
        /// UpdateDirect
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
        /// <param name="originalRequiresRoboticPrep">originalRequiresRoboticPrep</param> 
        /// <param name="originalLinerType">originalLinerType</param>
        /// <param name="originalPrepType">originalPrepType</param>
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
        /// <param name="companyId">companyId</param>
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
        /// <param name="newRequiresRoboticPrep">newRequiresRoboticPrep</param>
        /// <param name="newLinerType">newLinerType</param>
        /// <param name="newPrepType">newPrepType</param>
        /// <param name="dyeTestReq">dyeTestReq</param>
        /// <param name="dyeTestComplete">dyeTestComplete</param>
        public void UpdateDirect(int workId, int sectionWorkId, DateTime? originalPipeLocated, DateTime? originalServicesLocated, DateTime? originalCoInstalled, DateTime? originalBackfilledConcrete, DateTime? originalBackfilledSoil, DateTime? originalGrouted, DateTime? originalCored, DateTime? originalPrepped, DateTime? originalMeasured, string originalLinerSize, DateTime? originalInProcess, DateTime? originalInStock, DateTime? originalDelivered, int? originalBuildRebuild, DateTime? originalPreVideo, DateTime? originalLinerInstalled, DateTime? originalFinalVideo, decimal? originalCost, DateTime? originalVideoInspection, bool originalCoRequired, bool originalPitRequired, string originalCoPitLocation, bool originalPostContractDigRequired, DateTime? originalCoCutDown, DateTime? originalFinalRestoration, bool originalDeleted, int originalCompanyId, string originalVideoLengthToPropertyLine, bool originalLiningThruCo, DateTime? originalNoticeDelivered, string originalHamiltonInspectionNumber, string originalFlange, string originalGasket, string originalDepthOfLocated, bool originalDigRequiredPriorToLining, DateTime? originalDigRequiredPriorToLiningCompleted, bool originalDigRequiredAfterLining, DateTime? originalDigRequiredAfterLiningCompleted, bool originalOutOfScope, bool originalHoldClientIssue, DateTime? originalHoldClientIssueResolved, bool originalHoldLFSIssue, DateTime? originalHoldLFSIssueResolved, bool originalRequiresRoboticPrep, DateTime? originalRequiresRoboticPrepCompleted, string originalLinerType, string originalPrepType, bool originalDyeTestReq, DateTime? originalDyeTestComplete, DateTime? newPipeLocated, DateTime? newServicesLocated, DateTime? newCoInstalled, DateTime? newBackfilledConcrete, DateTime? newBackfilledSoil, DateTime? newGrouted, DateTime? newCored, DateTime? newPrepped, DateTime? newMeasured, string newLinerSize, DateTime? newInProcess, DateTime? newInStock, DateTime? newDelivered, int? newBuildRebuild, DateTime? newPreVideo, DateTime? newLinerInstalled, DateTime? newFinalVideo, decimal? newCost, DateTime? newVideoInspection, bool newCoRequired, bool newPitRequired, string newCoPitLocation, bool newPostContractDigRequired, DateTime? newCoCutDown, DateTime? newFinalRestoration, int companyId, string newVideoLengthToPropertyLine, bool newLiningThruCo, DateTime? newNoticeDelivered, string newHamiltonInspectionNumber, string newFlange, string newGasket, string newDepthOfLocated, bool newDigRequiredPriorToLining, DateTime? newDigRequiredPriorToLiningCompleted, bool newDigRequiredAfterLining, DateTime? newDigRequiredAfterLiningCompleted, bool newOutOfScope, bool newHoldClientIssue, DateTime? newHoldClientIssueResolved, bool newHoldLFSIssue, DateTime? newHoldLFSIssueResolved, bool newRequiresRoboticPrep, DateTime? newRequiresRoboticPrepCompleted, string newLinerType, string newPrepType, bool newDyeTestReq, DateTime? newDyeTestComplete, string originalContractYear, string newContractYear)
        {
            // Update WorkJunctionLiningLateral
            WorkJunctionLiningLateralGateway workJunctionLiningLateralGateway = new WorkJunctionLiningLateralGateway(null);
            workJunctionLiningLateralGateway.Update(workId, sectionWorkId, originalPipeLocated, originalServicesLocated, originalCoInstalled, originalBackfilledConcrete, originalBackfilledSoil, originalGrouted, originalCored, originalPrepped, originalMeasured, originalLinerSize, originalInProcess, originalInStock, originalDelivered, originalBuildRebuild, originalPreVideo, originalLinerInstalled, originalFinalVideo, originalCost, originalVideoInspection, originalCoRequired, originalPitRequired, originalCoPitLocation, originalPostContractDigRequired, originalCoCutDown, originalFinalRestoration, originalDeleted, originalCompanyId, originalVideoLengthToPropertyLine, originalLiningThruCo, originalNoticeDelivered, originalHamiltonInspectionNumber, originalFlange, originalGasket, originalDepthOfLocated, originalDigRequiredPriorToLining, originalDigRequiredPriorToLiningCompleted, originalDigRequiredAfterLining, originalDigRequiredAfterLiningCompleted, originalOutOfScope, originalHoldClientIssue, originalHoldClientIssueResolved, originalHoldLFSIssue, originalHoldLFSIssueResolved, originalRequiresRoboticPrep, originalRequiresRoboticPrepCompleted, originalLinerType, originalPrepType, originalDyeTestReq, originalDyeTestComplete, newPipeLocated, newServicesLocated, newCoInstalled, newBackfilledConcrete, newBackfilledSoil, newGrouted, newCored, newPrepped, newMeasured, newLinerSize, newInProcess, newInStock, newDelivered, newBuildRebuild, newPreVideo, newLinerInstalled, newFinalVideo,  newCost, newVideoInspection, newCoRequired, newPitRequired, newCoPitLocation, newPostContractDigRequired, newCoCutDown, newFinalRestoration, newVideoLengthToPropertyLine, newLiningThruCo, newNoticeDelivered, newHamiltonInspectionNumber, newFlange, newGasket, newDepthOfLocated, newDigRequiredPriorToLining, newDigRequiredPriorToLiningCompleted, newDigRequiredAfterLining, newDigRequiredAfterLiningCompleted, newOutOfScope, newHoldClientIssue, newHoldClientIssueResolved, newHoldLFSIssue, newHoldLFSIssueResolved, newRequiresRoboticPrep, newRequiresRoboticPrepCompleted, newLinerType, newPrepType, newDyeTestReq, newDyeTestComplete, originalContractYear, newContractYear);

            // Update WorkJunctionLiningSection
            UpdateSection(sectionWorkId, workId, companyId); 
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="sectionWorkId">sectionWorkId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, int sectionWorkId, int companyId)
        {
            // Delete WorkJunctionLiningLateral
            WorkJunctionLiningLateralGateway workJunctionLiningLateralGateway = new WorkJunctionLiningLateralGateway(null);
            workJunctionLiningLateralGateway.Delete(workId, companyId);

            // Delete Work
            Work work = new Work(null);
            work.DeleteDirect(workId, companyId);
       
            // Update WorkJunctionLiningSection
            UpdateSection(sectionWorkId, workId, companyId);            
        }



        /// <summary>
        /// UpdateSection
        /// <param name="sectionWorkId">sectionWorkId</param>
        /// <param name="lateralWorkId">lateralWorkId</param>
        /// <param name="companyId">companyId</param>
        public void UpdateSection(int sectionWorkId, int lateralWorkId, int companyId)
        {
            // load section
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

            //  get new values of section
            int newNumLats = 0;
            int newNotLinedYet = 0;
            bool newAllMeasured = true;
            int newNotMeasuredYet = 0;
            int newNotDeliveredYet = 0;
            string newIssueWithLaterals = "No";
            int newAvailableToLine = 0;
            int totDelivered = 0;
            int totInstalled = 0;

            // load laterals
            WorkJunctionLiningLateralGateway workJunctionLiningLateralGateway = new WorkJunctionLiningLateralGateway();
            workJunctionLiningLateralGateway.LoadBySectionWorkId(sectionWorkId, companyId);

            foreach (WorkTDS.LFS_WORK_JUNCTIONLINING_LATERALRow row in (WorkTDS.LFS_WORK_JUNCTIONLINING_LATERALDataTable)workJunctionLiningLateralGateway.Table)
            {
                if (!row.Deleted)
                {
                    // ... With no outofscope issue
                    if (!row.OutOfScope)
                    {
                        newNumLats++;
                        if (row.IsLinerInstalledNull()) newNotLinedYet++;
                        if (row.IsMeasuredNull()) newAllMeasured = false;
                        if (row.IsMeasuredNull()) newNotMeasuredYet++;
                        if (row.IsDeliveredNull()) newNotDeliveredYet++;
                        if (!row.IsDeliveredNull()) totDelivered++;
                        if (!row.IsLinerInstalledNull()) totInstalled++;
                    }                  
                }
            }
            
            if (newNumLats == 0) newAllMeasured = false;

            if (newNumLats > 0)
            {
                newAvailableToLine = totDelivered - totInstalled;
                
                // lining plan
                JlLiningPlanGateway jlLiningPlanGateway = new JlLiningPlanGateway();

                if (jlLiningPlanGateway.IsLateralsIssueNo(sectionWorkId))
                {
                    newIssueWithLaterals = "No";
                }
                else
                {
                    if (jlLiningPlanGateway.IsLateralsIssueOutOfScope(sectionWorkId))
                    {
                        newIssueWithLaterals = "Out Of Scope";
                    }
                    else
                    {
                        if (jlLiningPlanGateway.IsLateralsIssueYesOutOfScope(sectionWorkId))
                        {
                            newIssueWithLaterals = "Yes, Out Of Scope";
                        }
                        else
                        {
                            if (jlLiningPlanGateway.IsLateralsIssueYes(sectionWorkId))
                            {
                                newIssueWithLaterals = "Yes";
                            }
                        }
                    }
                }
            }

            // Update Work Juntion Lining Section
            WorkJunctionLiningSection workJunctionLiningSection = new WorkJunctionLiningSection(null);
            workJunctionLiningSection.UpdateDirect(sectionWorkId, numLats, notLinedYet, allMeasured, deleted, issueWithLaterals, notMeasuredYet, notDeliveredYet, companyId, trafficControl, trafficControlDetails, standardBypass, standardBypassComments, availableToLine, newNumLats, newNotLinedYet, newAllMeasured, newIssueWithLaterals, newNotMeasuredYet, newNotDeliveredYet, trafficControl, trafficControlDetails, standardBypass, standardBypassComments, newAvailableToLine); 
        }
              

        
    }
}