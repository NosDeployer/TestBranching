using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Services.Services;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectHotelsBudget
    /// </summary>
    public class ProjectHotelsBudget : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectHotelsBudget()
            : base("LFS_PROJECT_HOTELS_BUDGET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectHotelsBudget(DataSet data)
            : base(data, "LFS_PROJECT_HOTELS_BUDGET")
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
        /// <param name="holelId">holelId</param>
        /// <param name="refId">refId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int projectId, int holelId, int refId, decimal budget, bool deleted, int companyId)
        {
            ProjectHotelsBudgetGateway projectHotelsBudgetGateway = new ProjectHotelsBudgetGateway(null);
            projectHotelsBudgetGateway.Insert(projectId, holelId, refId, budget, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalHolelId">originalHolelId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalBudget">originalBudget</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newHolelId">newHolelId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newBudget">newBudget</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalProjectId, int originalHolelId, int originalRefId, decimal originalBudget, bool originalDeleted, int originalCompanyId, int newProjectId, int newHolelId, int newRefId, decimal newBudget, bool newDeleted, int newCompanyId)
        {
            ProjectHotelsBudgetGateway projectHotelsBudgetGateway = new ProjectHotelsBudgetGateway(null);
            projectHotelsBudgetGateway.Update(originalProjectId, originalHolelId, originalRefId, originalBudget, originalDeleted, originalCompanyId, newProjectId, newHolelId, newRefId, newBudget, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="holelId">holelId</param>
        /// <param name="refId">refId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int projectId, int holelId, int refId, decimal budget, bool deleted, int companyId)
        {
            ProjectHotelsBudgetGateway projectHotelsBudgetGateway = new ProjectHotelsBudgetGateway(null);
            projectHotelsBudgetGateway.Delete(projectId, holelId, refId, companyId);
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="holelId">holelId</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectTDS.LFS_PROJECT_HOTELS_BUDGETRow</returns>
        private ProjectTDS.LFS_PROJECT_HOTELS_BUDGETRow GetRow(int projectId, int holelId, int refId)
        {
            ProjectTDS.LFS_PROJECT_HOTELS_BUDGETRow row = ((ProjectTDS.LFS_PROJECT_HOTELS_BUDGETDataTable)Table).FindByProjectIDHolelIDRefID(projectId, holelId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectHotelsBudget.GetRow");
            }

            return row;
        }



    }
}