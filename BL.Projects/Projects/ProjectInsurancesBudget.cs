using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectInsurancesBudget
    /// </summary>
    public class ProjectInsurancesBudget : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectInsurancesBudget()
            : base("LFS_PROJECT_INSURANCES_BUDGET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectInsurancesBudget(DataSet data)
            : base(data, "LFS_PROJECT_INSURANCES_BUDGET")
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
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int projectId, int insuranceCompanyId, int refId, decimal budget, bool deleted, int companyId)
        {
            ProjectInsurancesBudgetGateway projecInsurancesBudgetGateway = new ProjectInsurancesBudgetGateway(null);
            projecInsurancesBudgetGateway.Insert(projectId, insuranceCompanyId, refId, budget, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalInsuranceCompanyId">originalInsuranceCompanyId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalBudget">originalBudget</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newInsuranceCompanyId">newInsuranceCompanyId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newBudget">newBudget</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalProjectId, int originalInsuranceCompanyId, int originalRefId, decimal originalBudget, bool originalDeleted, int originalCompanyId, int newProjectId, int newInsuranceCompanyId, int newRefId, decimal newBudget, bool newDeleted, int newCompanyId)
        {
            ProjectInsurancesBudgetGateway projecInsurancesBudgetGateway = new ProjectInsurancesBudgetGateway(null);
            projecInsurancesBudgetGateway.Update(originalProjectId, originalInsuranceCompanyId, originalRefId, originalBudget, originalDeleted, originalCompanyId, newProjectId, newInsuranceCompanyId, newRefId, newBudget, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int projectId, int insuranceCompanyId, int refId, decimal budget, bool deleted, int companyId)
        {
            ProjectInsurancesBudgetGateway projecInsurancesBudgetGateway = new ProjectInsurancesBudgetGateway(null);
            projecInsurancesBudgetGateway.Delete(projectId, insuranceCompanyId, refId, companyId);
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectTDS.LFS_PROJECT_INSURANCES_BUDGETRow</returns>
        private ProjectTDS.LFS_PROJECT_INSURANCES_BUDGETRow GetRow(int projectId, int insuranceCompanyId, int refId)
        {
            ProjectTDS.LFS_PROJECT_INSURANCES_BUDGETRow row = ((ProjectTDS.LFS_PROJECT_INSURANCES_BUDGETDataTable)Table).FindByProjectIDInsuranceCompanyIDRefID(projectId, insuranceCompanyId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectInsuranesBudget.GetRow");
            }

            return row;
        }



    }
}