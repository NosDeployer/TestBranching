using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Services.Services;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectSubcontractorsBudget
    /// </summary>
    public class ProjectSubcontractorsBudget : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectSubcontractorsBudget()
            : base("LFS_PROJECT_SUBCONTRACTORS_BUDGET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectSubcontractorsBudget(DataSet data)
            : base(data, "LFS_PROJECT_SUBCONTRACTORS_BUDGET")
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
        /// InsertDirect
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int projectId, int subcontractorId, int refId, decimal budget, bool deleted, int companyId)
        {
            ProjectSubcontractorsBudgetGateway projectSubcontractorsBudgetGateway = new ProjectSubcontractorsBudgetGateway(null);
            projectSubcontractorsBudgetGateway.Insert(projectId, subcontractorId, refId, budget, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalSubcontractorId">originalSubcontractorId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalBudget">originalBudget</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newWork_">newSubcontractorId</param>
        /// <param name="newBudget">newBudget</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalProjectId, int originalSubcontractorId, int originalRefId, decimal originalBudget, bool originalDeleted, int originalCompanyId, int newProjectId, int newSubcontractorId, int newRefId, decimal newBudget, bool newDeleted, int newCompanyId)
        {
            ProjectSubcontractorsBudgetGateway projectSubcontractorsBudgetGateway = new ProjectSubcontractorsBudgetGateway(null);
            projectSubcontractorsBudgetGateway.Update(originalProjectId, originalSubcontractorId, originalRefId, originalBudget, originalDeleted, originalCompanyId, newProjectId, newSubcontractorId, newRefId, newBudget, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int projectId, int subcontractorId, int refId, decimal budget, bool deleted, int companyId)
        {
            ProjectSubcontractorsBudgetGateway projectSubcontractorsBudgetGateway = new ProjectSubcontractorsBudgetGateway(null);
            projectSubcontractorsBudgetGateway.Delete(projectId, subcontractorId, refId, companyId);
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectTDS.LFS_PROJECT_SUBCONTRACTORS_BUDGETRow</returns>
        private ProjectTDS.LFS_PROJECT_SUBCONTRACTORS_BUDGETRow GetRow(int projectId, int subcontractorId, int refId)
        {
            ProjectTDS.LFS_PROJECT_SUBCONTRACTORS_BUDGETRow row = ((ProjectTDS.LFS_PROJECT_SUBCONTRACTORS_BUDGETDataTable)Table).FindByProjectIDSubcontractorIDRefID(projectId, subcontractorId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectSubcontractorsBudget.GetRow");
            }

            return row;
        }



    }
}