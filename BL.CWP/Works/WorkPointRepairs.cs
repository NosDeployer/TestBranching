using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    public class WorkPointRepairs : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkPointRepairs()
            : base("LFS_WORK_POINT_REPAIRS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkPointRepairs(DataSet data)
            : base(data, "LFS_WORK_POINT_REPAIRS")
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
        /// Insert Direct
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="measurementTakenBy">measurementTakenBy</param>
        /// <param name="repairconfirmationDate">repairconfirmationDate</param>
        /// <param name="bypassRequired">bypassRequired</param>
        /// <param name="roboticDistances">roboticDistances</param>
        /// <param name="proposedLiningDate">proposedLiningDate</param>
        /// <param name="deadlineLiningDate">deadlineLiningDate</param>
        /// <param name="finalVideoDate">finalVideoDate</param>
        /// <param name="estimatedJoints">estimatedJoints</param>
        /// <param name="jointsTestSealed">jointsTestSealed</param>
        /// <param name="issueIdentified">issueIdentified</param>
        /// <param name="issueLfs">issueLfs</param>
        /// <param name="issueClient">issueClient</param>
        /// <param name="issueSales">issueSales</param>        
        /// <param name="issueGivenToClient">issueGivenToClient</param>
        /// <param name="issueResolved">issueResolved</param>
        /// <param name="issueInvestigation">issueInvestigation</param>
        /// <param name="repairId">repairId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="comments">comments</param>
        /// <param name="history">history</param>
        /// <returns>rowsAffected</returns>
        public int InsertDirect(int projectId, int assetId, int? libraryCategoriesId, string clientId, string measurementTakenBy, DateTime? repairconfirmationDate, bool bypassRequired, string roboticDistances, DateTime? proposedLiningDate, DateTime? deadlineLiningDate, DateTime? finalVideoDate, int? estimatedJoints, int? jointsTestSealed, bool issueIdentified, bool issueLfs, bool issueClient, bool issueSales, bool issueGivenToClient, bool issueResolved, bool issueInvestigation, string repairId, bool deleted, int companyId, string comments, string history)
        {
            int workId = 0;
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Point Repairs", companyId);

            if (workGateway.Table.Rows.Count == 0)
            {
                workId = new Work(null).InsertDirect(projectId, assetId, "Point Repairs", libraryCategoriesId, deleted, companyId, comments, history);
                new WorkPointRepairsGateway(null).Insert(workId, clientId, measurementTakenBy, repairconfirmationDate, bypassRequired, roboticDistances, proposedLiningDate, deadlineLiningDate, finalVideoDate, estimatedJoints, jointsTestSealed, issueIdentified, issueLfs, issueClient, issueSales, issueGivenToClient, issueResolved, issueInvestigation, repairId, deleted, companyId);                
            }
            else
            {
                workId = workGateway.GetWorkId(assetId, "Point Repairs", projectId);
            }

            return workId;
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="sectionAssetId"></param>
        /// <param name="originalWorkId"></param>
        /// <param name="originalClientId"></param>
        /// <param name="originalMeasurementTakenBy"></param>
        /// <param name="originalRepairConfirmationDate"></param>
        /// <param name="originalBypassRequired"></param>
        /// <param name="originalRoboticDistances"></param>
        /// <param name="originalProposedLiningDate"></param>
        /// <param name="originalDeadlineLiningDate"></param>
        /// <param name="originalFinalVideoDate"></param>
        /// <param name="originalEstimatedJoints"></param>
        /// <param name="originalJointsTestSealed"></param>
        /// <param name="originalIssueIdentified"></param>
        /// <param name="originalIssueLfs"></param>
        /// <param name="originalIssueClient"></param>
        /// <param name="originalIssueSales"></param>
        /// <param name="originalIssueGivenToClient"></param>
        /// <param name="originalIssueResolved"></param>
        /// <param name="originalIssueInvestigation"></param>
        /// <param name="originalRepairId"></param>
        /// <param name="originalDeleted"></param>
        /// <param name="originalCompanyId"></param>
        /// 
        /// <param name="newWorkId"></param>
        /// <param name="newClientId"></param>
        /// <param name="newMeasurementTakenBy"></param>
        /// <param name="newRepairConfirmationDate"></param>
        /// <param name="newBypassRequired"></param>
        /// <param name="newRoboticDistances"></param>
        /// <param name="newProposedLiningDate"></param>
        /// <param name="newDeadlineLiningDate"></param>
        /// <param name="newFinalVideoDate"></param>
        /// <param name="newEstimatedJoints"></param>
        /// <param name="newJointsTestSealed"></param>
        /// <param name="newIssueIdentified"></param>
        /// <param name="newIssueLfs"></param>
        /// <param name="newIssueClient"></param>
        /// <param name="newIssueSales"></param>
        /// <param name="newIssueGivenToClient"></param>
        /// <param name="newIssueResolved"></param>
        /// <param name="newIssueInvestigation"></param>
        /// <param name="newRepairId"></param>
        /// <param name="newDeleted"></param>
        /// <param name="newCompanyId"></param>
        public void UpdateDirect(int sectionAssetId, int originalWorkId, string originalClientId, string originalMeasurementTakenBy, DateTime? originalRepairConfirmationDate, bool originalBypassRequired, string originalRoboticDistances, DateTime? originalProposedLiningDate, DateTime? originalDeadlineLiningDate, DateTime? originalFinalVideoDate, int? originalEstimatedJoints, int? originalJointsTestSealed, bool originalIssueIdentified, bool originalIssueLfs, bool originalIssueClient, bool originalIssueSales, bool originalIssueGivenToClient, bool originalIssueResolved, bool originalIssueInvestigation, string originalRepairId, bool originalDeleted, int originalCompanyId, int newWorkId, string newClientId, string newMeasurementTakenBy, DateTime? newRepairConfirmationDate, bool newBypassRequired, string newRoboticDistances, DateTime? newProposedLiningDate, DateTime? newDeadlineLiningDate, DateTime? newFinalVideoDate, int? newEstimatedJoints, int? newJointsTestSealed, bool newIssueIdentified, bool newIssueLfs, bool newIssueClient, bool newIssueSales, bool newIssueGivenToClient, bool newIssueResolved, bool newIssueInvestigation, string newRepairId, bool newDeleted, int newCompanyId)
        {
            WorkPointRepairsGateway workPointRepairsGateway = new WorkPointRepairsGateway(null);
            workPointRepairsGateway.Update(originalWorkId, originalClientId, originalMeasurementTakenBy, originalRepairConfirmationDate, originalBypassRequired, originalRoboticDistances, originalProposedLiningDate, originalDeadlineLiningDate, originalFinalVideoDate, originalEstimatedJoints, originalJointsTestSealed, originalIssueIdentified, originalIssueLfs, originalIssueClient, originalIssueSales, originalIssueGivenToClient, originalIssueResolved, originalIssueInvestigation, originalRepairId, originalDeleted, originalCompanyId, originalWorkId, newClientId, newMeasurementTakenBy, newRepairConfirmationDate, newBypassRequired, newRoboticDistances, newProposedLiningDate, newDeadlineLiningDate, newFinalVideoDate, newEstimatedJoints, newJointsTestSealed, newIssueIdentified, newIssueLfs, newIssueClient, newIssueSales, newIssueGivenToClient, newIssueResolved, newIssueInvestigation, newRepairId, newDeleted, newCompanyId);           
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, int companyId)
        {
            WorkPointRepairsGateway workPointRepairsGateway = new WorkPointRepairsGateway();
            workPointRepairsGateway.LoadByWorkId(workId, companyId);

            if (workPointRepairsGateway.Table.Rows.Count > 0)
            {
                // Delete WorkPointRepairsRepair
                WorkPointRepairsRepair workPointRepairsRepair = new WorkPointRepairsRepair();
                workPointRepairsRepair.Delete(workId, companyId);

                // Delete WorkPointRepairs
                workPointRepairsGateway.Delete(workId, companyId);

                // Delete work
                Work work = new Work(null);
                work.DeleteDirect(workId, companyId);
            }
        }



    }
}