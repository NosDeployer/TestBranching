using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// Work
    /// </summary>
    public class Work : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Work() : base("LFS_WORK")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Work(DataSet data) : base(data, "LFS_WORK")
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
        /// Insert a new work (direct to DB)
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="workType">workType</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="comments">comments</param>
        /// <param name="history">history</param>
        /// <returns>workId</returns>
        public int InsertDirect(int projectId, int assetId, string workType, int? libraryCategoriesId, bool deleted, int companyId, string comments, string history)
        {
            WorkGateway workGateway = new WorkGateway(null);
            int workId = workGateway.Insert(projectId, assetId, workType, libraryCategoriesId, deleted, companyId, comments, history);

            return workId;
        }



        /// <summary>
        /// Update a work (direct to DB)
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalAssetId">originalAssetId</param>
        /// <param name="originalWorkType">originalWorkType</param>
        /// <param name="originalLibraryCategoriesId">originalLibraryCategoriesId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalHistory">originalHistory</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newAssetId">newAssetId</param>
        /// <param name="newWorkType">newWorkType</param>
        /// <param name="newLibraryCategoriesId">newLibraryCategoriesId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newHistory">newHistory</param>
        public void UpdateDirect(int originalWorkId, int originalProjectId, int originalAssetId, string originalWorkType, int? originalLibraryCategoriesId, bool originalDeleted, int originalCompanyId, string originalComments, string originalHistory, int newWorkId, int newProjectId, int newAssetId, string newWorkType, int? newLibraryCategoriesId, bool newDeleted, int newCompanyId, string newComments, string newHistory)
        {
            WorkGateway workGateway = new WorkGateway(null);
            workGateway.Update(originalWorkId, originalProjectId, originalAssetId, originalWorkType, originalLibraryCategoriesId, originalDeleted, originalCompanyId, originalComments, originalHistory, newWorkId, newProjectId, newAssetId, newWorkType, newLibraryCategoriesId, newDeleted, newCompanyId, newComments, newHistory);
        }


        
        /// <summary>
        /// DeleteDirect including comments & history
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, int companyId)
        {
            // Delete comments
            WorkComments workComments = new WorkComments(null);
            workComments.DeleteAllDirect(workId, companyId);

            // Delete History
            WorkHistory workHistory = new WorkHistory(null);
            workHistory.DeleteAllDirect(workId, companyId);

            // delete Work
            WorkGateway workGateway = new WorkGateway(Data); 
            workGateway.Delete(workId, companyId);
        }



    }
}