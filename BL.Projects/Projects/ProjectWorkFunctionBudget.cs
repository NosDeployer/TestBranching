using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Services.Services;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectWorkFunctionBudget
    /// </summary>
    public class ProjectWorkFunctionBudget : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectWorkFunctionBudget()
            : base("LFS_PROJECT_WORK_FUNCTION_BUDGET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectWorkFunctionBudget(DataSet data)
            : base(data, "LFS_PROJECT_WORK_FUNCTION_BUDGET")
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
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="refId">refId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int projectId, string work_, string function_, int refId, decimal budget, bool deleted, int companyId, decimal budget_)
        {
            ProjectWorkFunctionBudgetGateway projectWorkFunctionBudgetGateway = new ProjectWorkFunctionBudgetGateway(null);
            projectWorkFunctionBudgetGateway.Insert(projectId, work_, function_, refId, budget, deleted, companyId, budget_);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalWork_">originalWork_</param>
        /// <param name="originalFunction_">originalFunction_</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalBudget">originalBudget</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newWork_">newWork_</param>
        /// <param name="newFunction_">newFunction_</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newBudget">newBudget</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalProjectId, string originalWork_, string originalFunction_, int originalRefId, decimal originalBudget, bool originalDeleted, int originalCompanyId, int newProjectId, string newWork_, string newFunction_, int newRefId, decimal newBudget, bool newDeleted, int newCompanyId, decimal originalBuget_, decimal newBudget_)
        {
            ProjectWorkFunctionBudgetGateway projectWorkFunctionBudgetGateway = new ProjectWorkFunctionBudgetGateway(null);
            projectWorkFunctionBudgetGateway.Update(originalProjectId, originalWork_, originalFunction_, originalRefId, originalBudget, originalDeleted, originalCompanyId, newProjectId, newWork_, newFunction_, newRefId, newBudget, newDeleted, newCompanyId, originalBuget_, newBudget_);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="refId">refId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int projectId, string work_, string function_, int refId, decimal budget, bool deleted, int companyId)
        {
            ProjectWorkFunctionBudgetGateway projectWorkFunctionBudgetGateway = new ProjectWorkFunctionBudgetGateway(null);
            projectWorkFunctionBudgetGateway.Delete(projectId, work_, function_, refId, companyId);
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectTDS.LFS_PROJECT_WORK_FUNCTION_BUDGETRow</returns>
        private ProjectTDS.LFS_PROJECT_WORK_FUNCTION_BUDGETRow GetRow(int projectId, string work_, string function_, int refId)
        {
            ProjectTDS.LFS_PROJECT_WORK_FUNCTION_BUDGETRow row = ((ProjectTDS.LFS_PROJECT_WORK_FUNCTION_BUDGETDataTable)Table).FindByProjectIDWork_Function_RefID(projectId, work_, function_, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectWorkFunctionBudget.GetRow");
            }

            return row;
        }



    }
}