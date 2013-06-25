using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Services.Services;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectWorkFunctionFairWage
    /// </summary>
    public class ProjectWorkFunctionFairWage : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectWorkFunctionFairWage()
            : base("LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectWorkFunctionFairWage(DataSet data)
            : base(data, "LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE")
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
        /// <param name="isFairWage">isFairWage</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int projectId, string work_, string function_, int refId, bool isFairWage, bool deleted, int companyId)
        {
            ProjectWorkFunctionFairWageGateway projectWorkFunctionFairWageGateway = new ProjectWorkFunctionFairWageGateway(null);
            projectWorkFunctionFairWageGateway.Insert(projectId, work_, function_, refId, isFairWage, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalWork_">originalWork_</param>
        /// <param name="originalFunction_">originalFunction_</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalIsFairWage">originalIsFairWage</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newWork_">newWork_</param>
        /// <param name="newFunction_">newFunction_</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newIsFairWage">newIsFairWage</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalProjectId, string originalWork_, string originalFunction_, int originalRefId, bool originalIsFairWage, bool originalDeleted, int originalCompanyId, int newProjectId, string newWork_, string newFunction_, int newRefId, bool newIsFairWage, bool newDeleted, int newCompanyId)
        {
            ProjectWorkFunctionFairWageGateway projectWorkFunctionFairWageGateway = new ProjectWorkFunctionFairWageGateway(null);
            projectWorkFunctionFairWageGateway.Update(originalProjectId, originalWork_, originalFunction_, originalRefId, originalIsFairWage, originalDeleted, originalCompanyId, newProjectId, newWork_, newFunction_, newRefId, newIsFairWage, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="refId">refId</param>
        /// <param name="isFairWage">isFairWage</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int projectId, string work_, string function_, int refId, bool isFairWage, bool deleted, int companyId)
        {
            ProjectWorkFunctionFairWageGateway projectWorkFunctionFairWageGateway = new ProjectWorkFunctionFairWageGateway(null);
            projectWorkFunctionFairWageGateway.Delete(projectId, work_, function_, refId, companyId);
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGERow</returns>
        private ProjectTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGERow GetRow(int projectId, string work_, string function_, int refId)
        {
            ProjectTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGERow row = ((ProjectTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable)Table).FindByProjectIDWork_Function_RefID(projectId, work_, function_, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectService.GetRow");
            }

            return row;
        }



    }
}