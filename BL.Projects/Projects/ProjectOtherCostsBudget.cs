using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectOtherCostsBudget
    /// </summary>
    public class ProjectOtherCostsBudget : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectOtherCostsBudget()
            : base("LFS_PROJECT_OTHER_COSTS_BUDGET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectOtherCostsBudget(DataSet data)
            : base(data, "LFS_PROJECT_OTHER_COSTS_BUDGET")
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
        /// <param name="category">category</param>
        /// <param name="refId">refId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int projectId, string category, int refId, decimal budget, bool deleted, int companyId)
        {
            ProjectOtherCostsBudgetGateway projectOtherCostsBudgetGateway = new ProjectOtherCostsBudgetGateway(null);
            projectOtherCostsBudgetGateway.Insert(projectId, category, refId, budget, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalCategory">originalCategory</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalBudget">originalBudget</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="originalCategory">originalCategory</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newBudget">newBudget</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalProjectId,  string originalCategory, int originalRefId, decimal originalBudget, bool originalDeleted, int originalCompanyId, int newProjectId, string newCategory, int newRefId, decimal newBudget, bool newDeleted, int newCompanyId)
        {
            ProjectOtherCostsBudgetGateway projectOtherCostsBudgetGateway = new ProjectOtherCostsBudgetGateway(null);
            projectOtherCostsBudgetGateway.Update(originalProjectId, originalCategory, originalRefId, originalBudget, originalDeleted, originalCompanyId, newProjectId, newCategory, newRefId, newBudget, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="category">category</param>
        /// <param name="refId">refId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int projectId, string category, int refId, decimal budget, bool deleted, int companyId)
        {
            ProjectOtherCostsBudgetGateway projectOtherCostsBudgetGateway = new ProjectOtherCostsBudgetGateway(null);
            projectOtherCostsBudgetGateway.Delete(projectId, category, refId, companyId);
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="category">category</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectTDS.LFS_PROJECT_OTHER_COSTS_BUDGETRow</returns>
        private ProjectTDS.LFS_PROJECT_OTHER_COSTS_BUDGETRow GetRow(int projectId, string category, int refId)
        {
            ProjectTDS.LFS_PROJECT_OTHER_COSTS_BUDGETRow row = ((ProjectTDS.LFS_PROJECT_OTHER_COSTS_BUDGETDataTable)Table).FindByProjectIDCategoryRefID(projectId, category, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectOTherCostsBudget.GetRow");
            }

            return row;
        }



    }
}