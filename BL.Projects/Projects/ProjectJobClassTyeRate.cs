using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectJobClassTyeRate
    /// </summary>
    public class ProjectJobClassTyeRate : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectJobClassTyeRate()
            : base("LFS_PROJECT_JOB_CLASS_TYPE_RATE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectJobClassTyeRate(DataSet data)
            : base(data, "LFS_PROJECT_JOB_CLASS_TYPE_RATE")
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
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <param name="refId">refId</param>
        /// <param name="rate">rate</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fringeRate">fringeRate</param>
        public void Insert(int projectId, string jobClassType, int refId, decimal rate, bool deleted, int companyId, decimal fringeRate)
        {
            ProjectTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATERow row = ((ProjectTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)Table).NewLFS_PROJECT_JOB_CLASS_TYPE_RATERow();

            row.ProjectID = projectId;
            row.JobClassType = jobClassType;
            row.RefID = refId;
            row.Rate = rate;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.FringeRate = fringeRate;

            ((ProjectTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)Table).AddLFS_PROJECT_JOB_CLASS_TYPE_RATERow(row);
        }

        

        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <param name="refId">refId</param>
        /// <param name="rate">rate</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fringeRate">fringeRate</param>
        public void InsertDirect(int projectId, string jobClassType, int refId, decimal rate, bool deleted, int companyId, decimal fringeRate)
        {
            ProjectJobClassTypeRateGateway projectJobClassTypeRateGateway = new ProjectJobClassTypeRateGateway(null);
            projectJobClassTypeRateGateway.Insert(projectId, jobClassType, refId, rate, deleted, companyId, fringeRate);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalJobClassType">originalJobClassType</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalRate">originalRate</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalFringeRate">originalFringeRate</param>
        /// 
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newJobClassType">newJobClassType</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newRate">newRate</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newFringeRate">newFringeRate</param>
        public void UpdateDirect(int originalProjectId, string originalJobClassType, int originalRefId, decimal originalRate, bool originalDeleted, int originalCompanyId, decimal originalFringeRate, int newProjectId, string newJobClassType, int newRefId, decimal newRate, bool newDeleted, int newCompanyId, decimal newFringeRate)
        {
            ProjectJobClassTypeRateGateway projectJobClassTypeRateGateway = new ProjectJobClassTypeRateGateway(null);
            projectJobClassTypeRateGateway.Update(originalProjectId, originalJobClassType, originalRefId, originalRate, originalDeleted, originalCompanyId, originalFringeRate, newProjectId, newJobClassType, newRefId, newRate, newDeleted, newCompanyId, newFringeRate);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int projectId, string jobClassType, int refId, int companyId)
        {
            ProjectJobClassTypeRateGateway projectJobClassTypeRateGateway = new ProjectJobClassTypeRateGateway(null);
            projectJobClassTypeRateGateway.Delete(projectId, jobClassType, refId, companyId);
        }
       


        /// <summary>
        /// GetNewRefID
        /// </summary>
        /// <returns></returns>
        public int GetNewRefId(string jobClassType)
        {
            int newRefId = 0;

            foreach (ProjectTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATERow row in (ProjectTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)Table)
            {
                if ((newRefId < row.RefID) && (row.JobClassType == jobClassType))
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATERow</returns>
        private ProjectTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATERow GetRow(int projectId, string jobClassType, int refId)
        {
            ProjectTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATERow row = ((ProjectTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)Table).FindByProjectIDJobClassTypeRefID(projectId, jobClassType, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectJobClassTypeRate.GetRow");
            }

            return row;
        }



    }
}