using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.JunctionLining
{
    /// <summary>
    /// JlToBuildReport
    /// </summary>
    public class JlToBuildReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //
        
        /// <summary>
        /// Constructor
        /// </summary>
        public JlToBuildReport()
            : base("JLToBuild")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public JlToBuildReport(DataSet data)
            : base(data, "JLToBuild")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JltoBuildReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //
        
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Load(int companyId)
        {
            JltoBuildReportGateway jlToBuildReportGateway = new JltoBuildReportGateway(Data);
            jlToBuildReportGateway.Load(companyId);

            UpdateFieldsForSections();
        }



        /// <summary>
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        public void LoadByCompaniesIdProjectId(int companyId, int companiesId, int projectId)
        {
            JltoBuildReportGateway jlToBuildReportGateway = new JltoBuildReportGateway(Data);
            jlToBuildReportGateway.LoadByCompaniesIdProjectId(companyId, companiesId, projectId);

            UpdateFieldsForSections();
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        public void LoadByCompaniesId(int companyId, int companiesId)
        {
            JltoBuildReportGateway jlToBuildReportGateway = new JltoBuildReportGateway(Data);
            jlToBuildReportGateway.LoadByCompaniesId(companyId, companiesId);

            UpdateFieldsForSections();
        }



        /// <summary>
        /// UpdateForReport
        /// </summary>
        public void UpdateForReport()
        {            
            foreach (JltoBuildReportTDS.JLToBuildRow jlToBuildRow in ((JltoBuildReportTDS.JLToBuildDataTable)Table))
            {
                // Load work
                WorkGateway workGateway = new WorkGateway();
                workGateway.LoadByProjectIdAssetIdWorkType(jlToBuildRow.ProjectID, jlToBuildRow.AssetID, "Junction Lining Lateral", jlToBuildRow.COMPANY_ID);
                int workId = workGateway.GetWorkId(jlToBuildRow.AssetID, "Junction Lining Lateral", jlToBuildRow.ProjectID);
                
                // Load Laterals in work
                WorkJunctionLiningLateralGateway workJunctionLiningLateralGateway = new WorkJunctionLiningLateralGateway();
                workJunctionLiningLateralGateway.LoadByWorkId(workId, jlToBuildRow.COMPANY_ID);

                // Load original data
                DateTime? originalPipeLocated = workJunctionLiningLateralGateway.GetPipeLocated(workId);
                int sectionWorkId = workJunctionLiningLateralGateway.GetSectionWorkID(workId);
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
                DateTime? originalDyeTestComplete = workJunctionLiningLateralGateway.GetDyeTestComplete(workId);
                string originalContractYear = workJunctionLiningLateralGateway.GetContractYear(workId);

                // New data
                DateTime? newPipeLocated = originalPipeLocated;
                DateTime? newServicesLocated = originalServicesLocated;
                DateTime? newCoInstalled = originalCoInstalled;
                DateTime? newBackfilledConcrete = originalBackfilledConcrete;
                DateTime? newBackfilledSoil = originalBackfilledSoil;
                DateTime? newGrouted = originalGrouted;
                DateTime? newCored = originalCored;
                DateTime? newPrepped = originalPrepped;
                DateTime? newMeasured = originalMeasured;
                string newLinerSize = originalLinerSize;
                DateTime? newInProcess = DateTime.Now;
                DateTime? newInStock = originalInStock;
                DateTime? newDelivered = originalDelivered;
                DateTime? newPreVideo = originalPreVideo;
                DateTime? newLinerInstalled = originalLinerInstalled;
                DateTime? newFinalVideo = originalFinalVideo;
                decimal? newCost = originalCost;
                DateTime? newVideoInspection = originalVideoInspection;
                bool newCoRequired = originalCoRequired;
                bool newPitRequired = originalPitRequired;
                string newCoPitLocation = originalCoPitLocation;
                bool newPostContractDigRequired = originalPostContractDigRequired;
                DateTime? newCoCutDown = originalCoCutDown;
                DateTime? newFinalRestoration = originalFinalRestoration;
                int? newBuildRebuild = (int)originalBuildRebuild + 1;
                string newVideoLengthToPropertyLine = originalVideoLengthToPropertyLine;
                bool newLiningThruCo = originalLiningThruCo;
                DateTime? newNoticeDelivered = originalNoticeDelivered;
                string newHamiltonInspectionNumber = originalHamiltonInspectionNumber;
                string newFlange = originalFlange;
                string newGasket = originalGasket;
                string newDepthOfLocated = originalDepthOfLocated;
                bool newDigRequiredPriorToLining = originalDigRequiredPriorToLining;
                DateTime? newDigRequiredPriorToLiningCompleted = originalDigRequiredPriorToLiningCompleted;
                bool newDigRequiredAfterLining = originalDigRequiredAfterLining;
                DateTime? newDigRequiredAfterLiningCompleted = originalDigRequiredAfterLiningCompleted;
                bool newOutOfScope = originalOutOfScope;
                bool newHoldClientIssue = originalHoldClientIssue;
                DateTime? newHoldClientIssueResolved = originalHoldClientIssueResolved;
                bool newHoldLFSIssue = originalHoldLFSIssue;
                DateTime? newHoldLFSIssueResolved = originalHoldLFSIssueResolved;
                bool newRequiresRoboticPrep = originalRequiresRoboticPrep;
                DateTime? newRequiresRoboticPrepCompleted = originalRequiresRoboticPrepCompleted;
                string newLinerType = originalLinerType;
                string newPrepType = originalPrepType;
                bool newDyeTestReq = originalDyeTestReq;
                DateTime? newDyeTestComplete = originalDyeTestComplete;
                string newContractYear = originalContractYear;
                
                // Update Lateral
                WorkJunctionLiningLateral workJunctionLiningLateral = new WorkJunctionLiningLateral(null);
                workJunctionLiningLateral.UpdateDirect(workId, sectionWorkId, originalPipeLocated, originalServicesLocated, originalCoInstalled, originalBackfilledConcrete, originalBackfilledSoil, originalGrouted, originalCored, originalPrepped, originalMeasured, originalLinerSize, originalInProcess, originalInStock, originalDelivered, originalBuildRebuild, originalPreVideo, originalLinerInstalled, originalFinalVideo, originalCost, originalVideoInspection, originalCoRequired, originalPitRequired, originalCoPitLocation, originalPostContractDigRequired, originalCoCutDown, originalFinalRestoration, false, jlToBuildRow.COMPANY_ID, originalVideoLengthToPropertyLine, originalLiningThruCo, originalNoticeDelivered, originalHamiltonInspectionNumber, originalFlange, originalGasket, originalDepthOfLocated, originalDigRequiredPriorToLining, originalDigRequiredPriorToLiningCompleted, originalDigRequiredAfterLining, originalDigRequiredAfterLiningCompleted, originalOutOfScope, originalHoldClientIssue, originalHoldClientIssueResolved, originalHoldLFSIssue, originalHoldLFSIssueResolved, originalRequiresRoboticPrep, originalRequiresRoboticPrepCompleted, originalLinerType, originalPrepType, originalDyeTestReq, originalDyeTestComplete, newPipeLocated, newServicesLocated, newCoInstalled, newBackfilledConcrete, newBackfilledSoil, newGrouted, newCored, newPrepped, newMeasured, newLinerSize, newInProcess, newInStock, newDelivered, newBuildRebuild, newPreVideo, newLinerInstalled, newFinalVideo, newCost, newVideoInspection, newCoRequired, newPitRequired, newCoPitLocation, newPostContractDigRequired, newCoCutDown, newFinalRestoration, jlToBuildRow.COMPANY_ID, newVideoLengthToPropertyLine, newLiningThruCo, newNoticeDelivered, newHamiltonInspectionNumber, newFlange, newGasket, newDepthOfLocated, newDigRequiredPriorToLining, newDigRequiredPriorToLiningCompleted, newDigRequiredAfterLining, newDigRequiredAfterLiningCompleted, newOutOfScope, newHoldClientIssue, newHoldClientIssueResolved, newHoldLFSIssue, newHoldLFSIssueResolved, newRequiresRoboticPrep, newRequiresRoboticPrepCompleted, newLinerType, newPrepType, newDyeTestReq, newDyeTestComplete, originalContractYear, newContractYear);
            }                                
            
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateFieldsForSections
        /// </summary>
        private void UpdateFieldsForSections()
        {
            // Distance Validation
            foreach (JltoBuildReportTDS.JLToBuildRow row in ((JltoBuildReportTDS.JLToBuildDataTable)Table))
            {
                if (!row.IsMainSizeNull())
                {
                    if (Distance.IsValidDistance(row.MainSize))
                    {
                        Distance distance = new Distance(row.MainSize);

                        switch (distance.DistanceType)
                        {
                            case 2:
                                row.MainSize = distance.ToStringInEng1();
                                break;
                            case 3:
                                if (Convert.ToInt32(row.MainSize) > 99)
                                {
                                    double newMainSize = 0;
                                    newMainSize = Convert.ToDouble(row.MainSize) * 0.03937;
                                    row.MainSize = Convert.ToString(Math.Ceiling(newMainSize)) + "\"";
                                }
                                else
                                {
                                    row.MainSize = row.MainSize + "\"";
                                }
                                break;
                            case 4:
                                row.MainSize = distance.ToStringInEng1();
                                break;
                            case 5:
                                row.MainSize = distance.ToStringInEng1();
                                break;
                        }
                    }
                }
            }

            foreach (JltoBuildReportTDS.JLToBuildRow row in ((JltoBuildReportTDS.JLToBuildDataTable)Table))
            {
                // Validate RoboticPrepCompleted
                WorkGateway workGateway = new WorkGateway();
                workGateway.LoadByProjectIdAssetIdWorkType(row.ProjectID, row.Section_, "Full Length Lining", row.COMPANY_ID);
                if (workGateway.Table.Rows.Count > 0)
                {
                    // ... Get WorkId for Full Length Lining
                    int workIdFll = workGateway.GetWorkId(row.Section_, "Full Length Lining", row.ProjectID);

                    // ... Load if there is robotic prep completed
                    FullLengthLiningWorkDetailsGateway fullLengthLiningWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway();
                    fullLengthLiningWorkDetailsGateway.LoadByWorkIdAssetId(workIdFll, row.AssetID, row.COMPANY_ID);

                    bool roboticPrepCompleted = false;
                    DateTime? roboticPrepCompletedDate = null;

                    roboticPrepCompleted = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompleted(workIdFll);
                    roboticPrepCompletedDate = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompletedDate(workIdFll);

                    if ((roboticPrepCompleted) && (!roboticPrepCompletedDate.HasValue))
                    {
                        row.Delete();
                    }
                }
            }
        }



    }
}