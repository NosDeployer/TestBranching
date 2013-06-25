using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectJobClassTypeRate
    /// </summary>
    public class ProjectNavigatorProjectJobClassTypeRate : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectJobClassTypeRate()
            : base("LFS_PROJECT_JOB_CLASS_TYPE_RATE")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectJobClassTypeRate(DataSet data)
            : base(data, "LFS_PROJECT_JOB_CLASS_TYPE_RATE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllByProjectId
        /// </summary>
        /// <param name="projectId">projectId</param>              
        public void LoadAllByProjectId(int projectId)
        {
            ProjectNavigatorProjectJobClassTypeRateGateway projectNavigatorProjectJobClassTypeRateGateway = new ProjectNavigatorProjectJobClassTypeRateGateway(Data);
            projectNavigatorProjectJobClassTypeRateGateway.LoadAllByProjectId(projectId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <param name="rate">rate</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="fringeRate">fringeRate</param>
        public void Insert(int projectId, string jobClassType, decimal rate, bool deleted, int companyId, bool inDatabase, decimal fringeRate)
        {
            ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATERow row = ((ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)Table).NewLFS_PROJECT_JOB_CLASS_TYPE_RATERow();

            row.ProjectID = projectId;
            row.JobClassType = jobClassType;
            row.RefID = GetNewRefId(jobClassType);
            row.Rate = rate;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.FringeRate = fringeRate;

            ((ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)Table).AddLFS_PROJECT_JOB_CLASS_TYPE_RATERow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <param name="refId">refId</param>
        /// <param name="rate">rate</param>
        /// <param name="fringeRate">fringeRate</param>
        public void Update(int projectId, string jobClassType, int refId, decimal rate, decimal fringeRate)
        {
            ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATERow row = GetRow(projectId, jobClassType, refId);
            row.Rate = rate;
            row.FringeRate = fringeRate;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <param name="refId">refId</param>
        public void Delete(int projectId, string jobClassType, int refId)
        {
            ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATERow row = GetRow(projectId, jobClassType, refId);
            row.Deleted = true;
        }

      
        
        /// <summary>
        /// Save all Service to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            ProjectNavigatorTDS workFunctionChanges = (ProjectNavigatorTDS)Data.GetChanges();

            if (workFunctionChanges != null)
            {
                if (workFunctionChanges.LFS_PROJECT_JOB_CLASS_TYPE_RATE.Rows.Count > 0)
                {
                    ProjectNavigatorProjectJobClassTypeRateGateway projectNavigatorProjectJobClassTypeRateGateway = new ProjectNavigatorProjectJobClassTypeRateGateway(workFunctionChanges);

                    foreach (ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATERow row in (ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)workFunctionChanges.LFS_PROJECT_JOB_CLASS_TYPE_RATE)
                    {
                        // Insert new Job Class Tye Rate 
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            ProjectJobClassTyeRate projectJobClassTyeRate = new ProjectJobClassTyeRate(null);
                            projectJobClassTyeRate.InsertDirect(row.ProjectID, row.JobClassType, row.RefID, row.Rate, row.Deleted, row.COMPANY_ID, row.FringeRate);
                        }

                        // Update Job Class Tye Rate  
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            int projectId = row.ProjectID;
                            string jobClassType = row.JobClassType;
                            int refId = row.RefID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;
                            
                            // original values                            
                            decimal originalRate = projectNavigatorProjectJobClassTypeRateGateway.GetRateOriginal(projectId, jobClassType, refId);
                            decimal originalFringeRate = projectNavigatorProjectJobClassTypeRateGateway.GetFringeRateOriginal(projectId, jobClassType, refId);

                            // new values                            
                            decimal newRate = projectNavigatorProjectJobClassTypeRateGateway.GetRate(projectId, jobClassType, refId);
                            decimal newFringeRate = projectNavigatorProjectJobClassTypeRateGateway.GetFringeRate(projectId, jobClassType, refId);

                            ProjectJobClassTyeRate projectJobClassTyeRate = new ProjectJobClassTyeRate(null);
                            projectJobClassTyeRate.UpdateDirect(projectId, jobClassType, refId, originalRate, originalDeleted, originalCompanyId, originalFringeRate, projectId, jobClassType, refId, newRate, originalDeleted, originalCompanyId, newFringeRate);
                        }

                        // Delete Job Class Tye Rate   
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            ProjectJobClassTyeRate projectJobClassTyeRate = new ProjectJobClassTyeRate(null);
                            projectJobClassTyeRate.DeleteDirect(row.ProjectID, row.JobClassType, row.RefID, row.COMPANY_ID);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// GetNewRefID
        /// </summary>
        /// <returns></returns>
        public int GetNewRefId(string jobClassType)
        {
            int newRefId = 0;

            foreach (ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATERow row in (ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)Table)
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
        /// <param name="refId">refId</param>
        /// <returns>ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATERow</returns>
        private ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATERow GetRow(int projectId, string jobClassType, int refId)
        {
            ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATERow row = ((ProjectNavigatorTDS.LFS_PROJECT_JOB_CLASS_TYPE_RATEDataTable)Table).FindByProjectIDJobClassTypeRefID(projectId, jobClassType, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectJobClassTypeRate.GetRow");
            }

            return row;
        }


        
    }
}