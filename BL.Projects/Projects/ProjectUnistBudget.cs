using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectUnistBudget
    /// </summary>
    public class ProjectUnistBudget : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectUnistBudget()
            : base("LFS_PROJECT_UNITS_BUDGET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectUnistBudget(DataSet data)
            : base(data, "LFS_PROJECT_UNITS_BUDGET")
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
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int projectId, decimal budget, bool deleted, int companyId)
        {
            ProjectUnistBudgetGateway projectUnistBudgetGateway = new ProjectUnistBudgetGateway(null);
            projectUnistBudgetGateway.Insert(projectId, budget, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalBudget">originalBudget</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newBudget">newBudget</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalProjectId, decimal originalBudget, bool originalDeleted, int originalCompanyId, int newProjectId,decimal newBudget, bool newDeleted, int newCompanyId)
        {
            ProjectUnistBudgetGateway projectUnistBudgetGateway = new ProjectUnistBudgetGateway(null);
            projectUnistBudgetGateway.Update(originalProjectId, originalBudget, originalDeleted, originalCompanyId, newProjectId, newBudget, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int projectId, decimal budget, bool deleted, int companyId)
        {
            ProjectUnistBudgetGateway projectUnistBudgetGateway = new ProjectUnistBudgetGateway(null);
            projectUnistBudgetGateway.Delete(projectId, companyId);
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ProjectTDS.LFS_PROJECT_UNITS_BUDGETRow</returns>
        private ProjectTDS.LFS_PROJECT_UNITS_BUDGETRow GetRow(int projectId)
        {
            ProjectTDS.LFS_PROJECT_UNITS_BUDGETRow row = ((ProjectTDS.LFS_PROJECT_UNITS_BUDGETDataTable)Table).FindByProjectID(projectId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectUnitsBudget.GetRow");
            }

            return row;
        }



    }
}