using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectRevenue
    /// </summary>
    public class ProjectRevenue : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectRevenue()
            : base("LFS_PROJECT_REVENUE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectRevenue(DataSet data)
            : base(data, "LFS_PROJECT_REVENUE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert revenue
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <param name="refId">refId</param>
        /// <param name="date">date</param>
        /// <param name="revenue">revenue</param>
        /// <param name="comment">comment</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>  
        /// <returns>refID</returns>
        public int InsertDirect(int projectId, int refId, DateTime date, decimal revenue, string comment, bool deleted, int companyId)
        {            
            ProjectRevenueGateway projectRevenueGateway = new ProjectRevenueGateway(null);
            int refID = projectRevenueGateway.Insert(projectId, refId, date, revenue, comment, deleted, companyId);

            return refID;
        }



        /// <summary>
        /// Update revenue
        /// </summary>        
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalRefId">originalRefId</param>       
        /// <param name="originalDate">originalDate</param>
        /// <param name="originalRevenue">originalRevenue</param>      
        /// <param name="originalComment">originalComment</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>        

        /// <param name="newProjectId">newProjectId</param> 
        /// <param name="newRefId">newRefId</param>               
        /// <param name="newDate">newDate</param>
        /// <param name="newRevenue">newRevenue</param>      
        /// <param name="newComment">newComment</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param> 
        public void UpdateDirect( int originalProjectId, int originalRefId, DateTime originalDate, decimal originalRevenue, string originalComment, bool originalDeleted, int originalCompanyId,int newProjectId,  int newRefId, DateTime newDate, decimal newRevenue,  string newComment, bool newDeleted, int newCompanyId)
        {
            ProjectRevenueGateway projectRevenueGateway = new ProjectRevenueGateway(null);
            projectRevenueGateway.Update(originalProjectId,originalRefId,  originalDate, originalRevenue, originalComment, originalDeleted, originalCompanyId, newProjectId, newRefId, newDate, newRevenue,  newComment, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>        
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int projectId, int refId, int companyId)
        {
            ProjectRevenueGateway projectRevenueGateway = new ProjectRevenueGateway(null);
            projectRevenueGateway.Delete(projectId, refId, companyId);            
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int projectId, int companyId)
        {
            ProjectRevenueGateway projectRevenueGateway = new ProjectRevenueGateway(null);
            projectRevenueGateway.DeleteAllByProjectId(projectId, companyId);
        }



        ///// <summary>
        ///// ValidateIfExistsARenevue
        ///// </summary>
        ///// <param name="date">date</param>
        ///// <param name="projectId">projectId</param>
        ///// <param name="companyId">companyId</param>
        //public bool ValidateIfExistsARenevue(DateTime date, int projectId, int companyId)
        //{
        //    bool valid = true;

        //    ProjectRevenueGateway projectRevenueGateway = new ProjectRevenueGateway();            
            
        //    // If exists a revenue it's not a valid new entry
        //    if (projectRevenueGateway.ExistsRenevue(date, projectId, companyId))
        //    {
        //        valid = false;
        //    }

        //    return valid;
        //}

        

    }
}