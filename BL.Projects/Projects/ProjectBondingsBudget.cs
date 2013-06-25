using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Services.Services;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectBondingsBudget
    /// </summary>
    public class ProjectBondingsBudget : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectBondingsBudget()
            : base("LFS_PROJECT_BONDINGS_BUDGET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectBondingsBudget(DataSet data)
            : base(data, "LFS_PROJECT_BONDINGS_BUDGET")
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
        public void InsertDirect(int projectId, int bondingCompanyId, int refId, decimal budget, bool deleted, int companyId)
        {
            ProjectBondingsBudgetGateway projectBondingsBudgetGateway = new ProjectBondingsBudgetGateway(null);
            projectBondingsBudgetGateway.Insert(projectId, bondingCompanyId, refId, budget, deleted, companyId);
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
        public void UpdateDirect(int originalProjectId, int originalBondingCompanyId, int originalRefId, decimal originalBudget, bool originalDeleted, int originalCompanyId, int newProjectId, int newBondingCompanyId, int newRefId, decimal newBudget, bool newDeleted, int newCompanyId)
        {
            ProjectBondingsBudgetGateway projectBondingsBudgetGateway = new ProjectBondingsBudgetGateway(null);
            projectBondingsBudgetGateway.Update(originalProjectId, originalBondingCompanyId, originalRefId, originalBudget, originalDeleted, originalCompanyId, newProjectId, newBondingCompanyId, newRefId, newBudget, newDeleted, newCompanyId);
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
        public void DeleteDirect(int projectId, int bondingCompanyId, int refId, decimal budget, bool deleted, int companyId)
        {
            ProjectBondingsBudgetGateway projectBondingsBudgetGateway = new ProjectBondingsBudgetGateway(null);
            projectBondingsBudgetGateway.Delete(projectId, bondingCompanyId, refId, companyId);
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectTDS.LFS_PROJECT_BONDINGS_BUDGETRow</returns>
        private ProjectTDS.LFS_PROJECT_BONDINGS_BUDGETRow GetRow(int projectId, int bondingCompanyId, int refId)
        {
            ProjectTDS.LFS_PROJECT_BONDINGS_BUDGETRow row = ((ProjectTDS.LFS_PROJECT_BONDINGS_BUDGETDataTable)Table).FindByProjectIDBondingCompanyIDRefID(projectId, bondingCompanyId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectHotelsBudget.GetRow");
            }

            return row;
        }



    }
}