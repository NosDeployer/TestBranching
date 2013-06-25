using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkJunctionLiningSection
    /// </summary>
    public class WorkJunctionLiningSection : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkJunctionLiningSection() : base("LFS_WORK_JUNCTIONLINING_SECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkJunctionLiningSection(DataSet data) : base(data, "LFS_WORK_JUNCTIONLINING_SECTION")
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
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <param name="numLats">numLats</param>
        /// <param name="notLinedYet">notLinedYet</param>
        /// <param name="allMeasured">allMeasured</param>
        /// <param name="issueWithLaterals">issueWithLaterals</param>
        /// <param name="notMeasuredYet">notMeasuredYet</param>
        /// <param name="notDeliveredYet">notDeliveredYet</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="history">history</param>
        /// <param name="trafficControl">trafficControl</param>
        /// <param name="trafficControlDetails">trafficControlDetails</param>
        /// <param name="standardBypass">standardBypass</param>
        /// <param name="standardBypassComments">standardBypassComments</param>
        /// <param name="availableToLine">availableToLine</param>
        /// <returns></returns>
        public int InsertDirect(int projectId, int assetId, int? libraryCategoriesId, int numLats, int notLinedYet, bool allMeasured, string issueWithLaterals, int notMeasuredYet, int notDeliveredYet, bool deleted, int companyId, string comments, string history, string trafficControl, string trafficControlDetails, bool standardBypass, string standardBypassComments, int availableToLine)
        {
            int workId = 0;

            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Junction Lining Section", companyId);
            
            if (workGateway.Table.Rows.Count == 0)
            {
                workId = new Work(null).InsertDirect(projectId, assetId, "Junction Lining Section", libraryCategoriesId, deleted, companyId, comments, history);
                new WorkJunctionLiningSectionGateway(null).Insert(workId, numLats, notLinedYet, allMeasured, issueWithLaterals, notMeasuredYet, notDeliveredYet, deleted, companyId, trafficControl, trafficControlDetails, standardBypass, standardBypassComments, availableToLine);
            }
            else
            {
                workId = workGateway.GetWorkId(assetId, "Junction Lining Section", projectId);
            }

            return workId;
        }

        

        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, int companyId)
        {
            WorkJunctionLiningSectionGateway workJunctionLiningSectionGateway = new WorkJunctionLiningSectionGateway();
            workJunctionLiningSectionGateway.LoadByWorkId(workId, companyId);

            if (workJunctionLiningSectionGateway.Table.Rows.Count > 0)
            {
                WorkJunctionLiningLateralGateway workJunctionLiningLateralGateway = new WorkJunctionLiningLateralGateway();
                workJunctionLiningLateralGateway.LoadBySectionWorkId(workId, companyId);

                // ... Delete Laterals
                WorkJunctionLiningLateral workJunctionLiningLateral = new WorkJunctionLiningLateral();

                foreach (WorkTDS.LFS_WORK_JUNCTIONLINING_LATERALRow row in (WorkTDS.LFS_WORK_JUNCTIONLINING_LATERALDataTable)workJunctionLiningLateralGateway.Table)
                {
                    workJunctionLiningLateral.DeleteDirect(row.WorkID, row.SectionWorkID, companyId);
                }

                // ... Delete WorkJunctionLiningSection
                workJunctionLiningSectionGateway.Delete(workId, companyId);
                
                // ... Delete work
                Work work = new Work(null);
                work.DeleteDirect(workId, companyId);
            }
        }


        
        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="originalNumLats">originalNumLats</param>
        /// <param name="originalNotLinedYet">originalNotLinedYet</param>
        /// <param name="originalAllMeasured">originalAllMeasured</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalIssueWithLaterals">originalIssueWithLaterals</param>
        /// <param name="originalNotMeasuredYet">originalNotMeasuredYet</param>
        /// <param name="originalNotDeliveredYet">originalNotDeliveredYet</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalTrafficControl">originalTrafficControl</param>
        /// <param name="originalTrafficControlDetails">originalTrafficControlDetails</param>
        /// <param name="originalStandardBypass">originalStandardBypass</param>
        /// <param name="originalStandardBypassComments">originalStandardBypassComments</param>
        /// <param name="newNumLats">newNumLats</param>
        /// <param name="newNotLinedYet">newNotLinedYet</param>
        /// <param name="newAllMeasured">newAllMeasured</param>
        /// <param name="newIssueWithLaterals">newIssueWithLaterals</param>
        /// <param name="newNotMeasuredYet">newNotMeasuredYet</param>
        /// <param name="newNotDeliveredYet">newNotDeliveredYet</param>
        /// <param name="newTrafficControl">newTrafficControl</param>
        /// <param name="newTrafficControlDetails">newTrafficControlDetails</param>
        /// <param name="newStandardBypass">newStandardBypass</param>
        /// <param name="newStandardBypassComments">newStandardBypassComments</param>
        public void UpdateDirect(int workId, int originalNumLats, int originalNotLinedYet, bool originalAllMeasured, bool originalDeleted, string originalIssueWithLaterals, int originalNotMeasuredYet, int originalNotDeliveredYet, int originalCompanyId, string originalTrafficControl, string originalTrafficControlDetails, bool originalStandardBypass, string originalStandardBypassComments, int originalAvailableToLine, int newNumLats, int newNotLinedYet, bool newAllMeasured, string newIssueWithLaterals, int newNotMeasuredYet, int newNotDeliveredYet, string newTrafficControl, string newTrafficControlDetails, bool newStandardBypass, string newStandardBypassComments, int newAvailableToLine)
        {
            WorkJunctionLiningSectionGateway workJunctionLiningSectionGateway = new WorkJunctionLiningSectionGateway(null);
            workJunctionLiningSectionGateway.Update(workId, originalNumLats, originalNotLinedYet, originalAllMeasured, originalDeleted, originalIssueWithLaterals, originalNotMeasuredYet, originalNotDeliveredYet, originalCompanyId, originalTrafficControl, originalTrafficControlDetails, originalStandardBypass, originalStandardBypassComments, originalAvailableToLine, newNumLats, newNotLinedYet, newAllMeasured, newIssueWithLaterals, newNotMeasuredYet, newNotDeliveredYet, newTrafficControl, newTrafficControlDetails, newStandardBypass, newStandardBypassComments, newAvailableToLine);
        }       


        
    }
}
