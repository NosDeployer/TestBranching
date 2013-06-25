using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectWorkFunctionFairWage
    /// </summary>
    public class ProjectNavigatorProjectWorkFunctionFairWage : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectWorkFunctionFairWage()
            : base("LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectWorkFunctionFairWage(DataSet data)
            : base(data, "LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE")
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
            ProjectNavigatorProjectWorkFunctionFairWageGateway projectNavigatorProjectWorkFunctionFairWageGateway = new ProjectNavigatorProjectWorkFunctionFairWageGateway(Data);
            projectNavigatorProjectWorkFunctionFairWageGateway.LoadAllByProjectId(projectId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="isFairWage">isFairWage</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="workFunction">workFunction</param>
        public void Insert(int projectId, string work_, string function_, bool isFairWage, bool deleted, int companyId, bool inDatabase, string workFunction)
        {
            ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGERow row = ((ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable)Table).NewLFS_PROJECT_WORK_FUNCTION_FAIR_WAGERow();

            row.ProjectID = projectId;
            row.Work_ = work_;
            row.Function_ = function_;
            row.RefID = GetNewRefId(work_, function_);
            row.IsFairWage = isFairWage;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.WorkFunction = workFunction;

            ((ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable)Table).AddLFS_PROJECT_WORK_FUNCTION_FAIR_WAGERow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="refId">refId</param>
        /// <param name="isFairWage">isFairWage</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Update(int projectId, string work_, string function_, int refId, bool isFairWage, bool deleted, int companyId)
        {
            ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGERow row = GetRow(projectId, work_, function_, refId);
            row.IsFairWage = isFairWage;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="refId">refId</param>
        public void Delete(int projectId, string work_, string function_, int refId)
        {
            ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGERow row = GetRow(projectId, work_, function_, refId);
            row.Deleted = true;
        }

      
        
        /// <summary>
        /// Save all data to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            ProjectNavigatorTDS workFunctionChanges = (ProjectNavigatorTDS)Data.GetChanges();

            if (workFunctionChanges != null)
            {
                if (workFunctionChanges.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE.Rows.Count > 0)
                {
                    ProjectNavigatorProjectWorkFunctionFairWageGateway projectNavigatorProjectWorkFunctionFairWageGateway = new ProjectNavigatorProjectWorkFunctionFairWageGateway(workFunctionChanges);

                    foreach (ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGERow row in (ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable)workFunctionChanges.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE)
                    {
                        // Insert new work function fair wage 
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            ProjectWorkFunctionFairWage projectWorkFunctionFairWage = new ProjectWorkFunctionFairWage(null);
                            projectWorkFunctionFairWage.InsertDirect(row.ProjectID, row.Work_, row.Function_, row.RefID, row.IsFairWage, row.Deleted, row.COMPANY_ID);
                        }

                        // Update work function fair wage 
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            int projectId = row.ProjectID;
                            string work_ = row.Work_;
                            string function = row.Function_;
                            int refId = row.RefID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            // original values                            
                            bool  originalIsFairWage = projectNavigatorProjectWorkFunctionFairWageGateway.GetIsFairWageOriginal(projectId, work_, function, refId);

                            // new values                            
                            bool newIsFairWage = projectNavigatorProjectWorkFunctionFairWageGateway.GetIsFairWage(projectId, work_, function, refId);

                            ProjectWorkFunctionFairWage projectWorkFunctionFairWage = new ProjectWorkFunctionFairWage(null);
                            projectWorkFunctionFairWage.UpdateDirect(projectId, work_, function, refId, originalIsFairWage, originalDeleted, originalCompanyId, projectId, work_, function, refId, newIsFairWage, originalDeleted, originalCompanyId);
                        }

                        // Delete work function fair wage  
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            ProjectWorkFunctionFairWage projectWorkFunctionFairWage = new ProjectWorkFunctionFairWage(null);
                            projectWorkFunctionFairWage.DeleteDirect(row.ProjectID, row.Work_, row.Function_, row.RefID, row.IsFairWage, row.Deleted, row.COMPANY_ID);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// GetNewRefID
        /// </summary>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <returns>newRefId</returns>
        public int GetNewRefId(string work_, string function_)
        {
            int newRefId = 0;

            foreach (ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGERow row in (ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable)Table)
            {
                if ((newRefId < row.RefID) && (row.Work_ == work_) && (row.Function_ == function_))
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }



        /// <summary>
        /// ExistWorkFunction
        /// </summary>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <returns>True or False</returns>
        public bool ExistWorkFunction(string work_, string function_)
        {
            foreach (ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGERow row in (ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable)Table)
            {
                if ((row.Work_ == work_) && (row.Function_ == function_))
                {
                    return true;
                }
            }

            return false;
        }
      




        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGERow</returns>
        private ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGERow GetRow(int projectId, string work_, string function_, int refId)
        {
            ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGERow row = ((ProjectNavigatorTDS.LFS_PROJECT_WORK_FUNCTION_FAIR_WAGEDataTable)Table).FindByProjectIDWork_Function_RefID(projectId, work_, function_, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectNavigatorProjectWorkFunctionFairWage.GetRow");
            }

            return row;
        }


        
    }
}