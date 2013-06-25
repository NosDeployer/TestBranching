using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkRehabAssessment 
    /// </summary>
    public class WorkRehabAssessment : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkRehabAssessment() : base("LFS_WORK_REHABASSESSMENT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkRehabAssessment(DataSet data) : base(data, "LFS_WORK_REHABASSESSMENT")
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
        /// <param name="projectId">projectId></param>
        /// <param name="assetId">assetId</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <param name="preFlushDate">preFlushDate</param>
        /// <param name="preVideoDate">preVideoDate</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public int InsertDirect(int projectId, int assetId, int? libraryCategoriesId, DateTime? preFlushDate, DateTime? preVideoDate, bool deleted, int companyId, string comments, string history)
        {
            int workId = 0;
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Rehab Assessment", companyId);
            
            if (workGateway.Table.Rows.Count == 0)
            {
                workId = new Work(null).InsertDirect(projectId, assetId, "Rehab Assessment", libraryCategoriesId, deleted, companyId, comments, history);
                new WorkRehabAssessmentGateway(null).Insert(workId, preFlushDate, preVideoDate, deleted, companyId);
            }
            else
            {
                workId = workGateway.GetWorkId(assetId, "Rehab Assessment", projectId);
            }

            return workId;
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalPreFlushDate">originalPreFlushDate</param>
        /// <param name="originalPreVideoDate">originalPreVideoDate</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newPreFlushDate">newPreFlushDate</param>
        /// <param name="newPreVideoDate">newPreVideoDate</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalWorkId, DateTime? originalPreFlushDate, DateTime? originalPreVideoDate, bool originalDeleted, int originalCompanyId, int newWorkId, DateTime? newPreFlushDate, DateTime? newPreVideoDate, bool newDeleted, int newCompanyId)
        {
            WorkRehabAssessmentGateway workRehabAssessmentGateway = new WorkRehabAssessmentGateway(Data);
            workRehabAssessmentGateway.Update(originalWorkId, originalPreFlushDate, originalPreVideoDate, originalDeleted, originalCompanyId, newWorkId, newPreFlushDate, newPreVideoDate, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, int companyId)
        {                  
            WorkRehabAssessmentGateway workRehabAssessmentGateway = new WorkRehabAssessmentGateway(null);            
            workRehabAssessmentGateway.Delete(workId, companyId);             

            Work work = new Work(null);
            work.DeleteDirect(workId, companyId);
        }


        
    }
}