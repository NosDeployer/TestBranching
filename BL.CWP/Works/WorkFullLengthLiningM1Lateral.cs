using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningM1Lateral
    /// </summary>
    class WorkFullLengthLiningM1Lateral : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningM1Lateral()
            : base("LFS_WORK_FULLLENGTHLINING_M1_LATERAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningM1Lateral(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_M1_LATERAL")
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
        /// Delete
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int workId, int companyId)
        {
            WorkFullLengthLiningM1LateralGateway workFullLengthLiningM1LateralGateway = new WorkFullLengthLiningM1LateralGateway();
            workFullLengthLiningM1LateralGateway.LoadByWorkId(workId, companyId);

            foreach (WorkTDS.LFS_WORK_FULLLENGTHLINING_M1_LATERALRow row in (WorkTDS.LFS_WORK_FULLLENGTHLINING_M1_LATERALDataTable)workFullLengthLiningM1LateralGateway.Table)
            {
                // delete lfs lateral client
                WorkGateway workGateway = new WorkGateway();
                workGateway.LoadByWorkId(workId, companyId);
                int currentProjectId = workGateway.GetProjectId(workId);

                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(currentProjectId);
                int clientId = projectGateway.GetClientID(currentProjectId);

                LfsAssetSewerLateralClientGateway lfsAssetSewerLateralClientGateway = new LfsAssetSewerLateralClientGateway();
                lfsAssetSewerLateralClientGateway.LoadByAssetIdClientId(row.Lateral, clientId, companyId);

                if (lfsAssetSewerLateralClientGateway.Table.Rows.Count > 0)
                {
                    LfsAssetSewerLateralClient lfsAssetSewerLateralClient = new LfsAssetSewerLateralClient(null);
                    lfsAssetSewerLateralClient.DeleteDirect(row.Lateral, clientId, companyId);
                }
                            
                // Delete work lateral
                workFullLengthLiningM1LateralGateway.Delete(workId, row.Lateral, companyId);

                // Delete section
                LfsAssetSewerLateral lfsAssetSewerLateral = new LfsAssetSewerLateral(null);
                lfsAssetSewerLateral.DeleteDirect(row.Lateral, companyId);
            }
        }



        /// <summary>
        /// InsertDirect
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
        /// <param name="requiresRoboticPrep">requiresRoboticPrep</param>
        /// <param name="requiresRoboticPrepDate">requiresRoboticPrepDate</param> 
        /// <param name="holdClientIssue">holdClientIssue</param>
        /// <param name="holdLFSIssue">holdLFSIssue</param>
        /// <param name="lineLateral">lineLateral</param>
        /// <param name="dyeTestReq">dyeTestReq</param>
        /// <param name="dyeTestComplete">dyeTestComplete</param>
        /// <param name="contractYear">contractYear</param>
        public void InsertDirect(int workId, int lateral, string videoDistance, string clockPosition, string distanceToCentre, string timeOpened, string reverseSetup, DateTime? reinstate, string comments, bool deleted, int companyId, string clientInspectionNo, DateTime? v1Inspection, bool requiresRoboticPrep, DateTime? requiresRoboticPrepDate, bool holdClientIssue, bool holdLFSIssue, bool lineLateral, bool dyeTestReq, DateTime? dyeTestComplete, string contractYear)
        {
            WorkFullLengthLiningM1LateralGateway workFullLengthLiningM1LateralGateway = new WorkFullLengthLiningM1LateralGateway(Data);
            workFullLengthLiningM1LateralGateway.Insert(workId, lateral, videoDistance, clockPosition, distanceToCentre, timeOpened, reverseSetup, reinstate, comments, deleted, companyId, clientInspectionNo, v1Inspection, requiresRoboticPrep, requiresRoboticPrepDate, holdClientIssue, holdLFSIssue, lineLateral, dyeTestReq, dyeTestComplete, contractYear);
        }



        /// <summary>
        /// UpdateDirect
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
        public void UpdateDirect(int originalWorkId, int originalLateral, string originalVideoDistance, string originalClockPosition, string originalDistanceToCentre, string originalTimeOpened, string originalReverseSetup, DateTime? originalReinstate, string originalComments, bool originalDeleted, int originalCompanyId, string originalClientInspectionNo, DateTime? originalV1Inspection, bool originalRequiresRoboticPrep, DateTime? originalRequiresRoboticPrepDate, bool originalHoldClientIssue, bool originalHoldLFSIssue, bool originalLineLateral, bool originalDyeTestReq, DateTime? originalDyeTestComplete, string originalContractYear, int newWorkId, int newLateral, string newVideoDistance, string newClockPosition, string newDistanceToCentre, string newTimeOpened, string newReverseSetup, DateTime? newReinstate, string newComments, bool newDeleted, int newCompanyId, string newClientInspectionNo, DateTime? newV1Inspection, bool newRequiresRoboticPrep, DateTime? newRequiresRoboticPrepDate, bool newHoldClientIssue, bool newHoldLFSIssue, bool newLineLateral, bool newDyeTestReq, DateTime? newDyeTestComplete, string newContractYear)
        {
            WorkFullLengthLiningM1LateralGateway workFullLengthLiningM1LateralGateway = new WorkFullLengthLiningM1LateralGateway(null);
            workFullLengthLiningM1LateralGateway.Update(originalWorkId, originalLateral, originalVideoDistance, originalClockPosition, originalDistanceToCentre, originalTimeOpened, originalReverseSetup, originalReinstate, originalComments, originalDeleted, originalCompanyId, originalClientInspectionNo, originalV1Inspection, originalRequiresRoboticPrep, originalRequiresRoboticPrepDate, originalHoldClientIssue, originalHoldLFSIssue, originalLineLateral, originalDyeTestReq, originalDyeTestComplete, originalContractYear, newWorkId, newLateral, newVideoDistance, newClockPosition, newDistanceToCentre, newTimeOpened, newReverseSetup, newReinstate, newComments, newDeleted, newCompanyId, newClientInspectionNo, newV1Inspection, newRequiresRoboticPrep, newRequiresRoboticPrepDate, newHoldClientIssue, newHoldLFSIssue, newLineLateral, newDyeTestReq, newDyeTestComplete, newContractYear);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="lateral">lateral</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, int lateral, int companyId)
        {
            WorkFullLengthLiningM1LateralGateway workFullLengthLiningM1LateralGateway = new WorkFullLengthLiningM1LateralGateway(null);
            workFullLengthLiningM1LateralGateway.Delete(workId, lateral, companyId);
        }



   }
}