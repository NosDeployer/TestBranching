using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectWorkFunctionBudget
    /// </summary>
    public class ProjectNavigatorProjectWorkFunctionBudget: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectWorkFunctionBudget()
            : base("ProjectWorkFunctionBudget")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectWorkFunctionBudget(DataSet data)
            : base(data, "ProjectWorkFunctionBudget")
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
            ProjectNavigatorProjectWorkFunctionBudgetGateway projectNavigatorProjectWorkFunctionBudgetGateway = new ProjectNavigatorProjectWorkFunctionBudgetGateway(Data);
            projectNavigatorProjectWorkFunctionBudgetGateway.LoadAllByProjectId(projectId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="workFunction">workFunction</param>
        public void Insert(int projectId, string work_, string function_, decimal budget, bool deleted, int companyId, bool inDatabase, string workFunction, decimal budget_)
        {
            ProjectNavigatorTDS.ProjectWorkFunctionBudgetRow row = ((ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable)Table).NewProjectWorkFunctionBudgetRow();

            row.ProjectID = projectId;
            row.Work_ = work_;
            row.Function_ = function_;
            row.RefID = GetNewRefId(work_, function_);
            row.Budget = budget;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.WorkFunction = workFunction;
            row.Budget_ = budget_;

            ((ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable)Table).AddProjectWorkFunctionBudgetRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="refId">refId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Update(int projectId, string work_, string function_, int refId, decimal budget, bool deleted, int companyId, decimal budget_)
        {
            ProjectNavigatorTDS.ProjectWorkFunctionBudgetRow row = GetRow(projectId, work_, function_, refId);
            row.Budget = budget;
            row.Budget_ = budget_;
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
            ProjectNavigatorTDS.ProjectWorkFunctionBudgetRow row = GetRow(projectId, work_, function_, refId);
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
                if (workFunctionChanges.ProjectWorkFunctionBudget.Rows.Count > 0)
                {
                    ProjectNavigatorProjectWorkFunctionBudgetGateway projectNavigatorProjectWorkFunctionBudgetGateway = new ProjectNavigatorProjectWorkFunctionBudgetGateway(workFunctionChanges);

                    foreach (ProjectNavigatorTDS.ProjectWorkFunctionBudgetRow row in (ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable)workFunctionChanges.ProjectWorkFunctionBudget)
                    {
                        // Insert new work function budget
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            ProjectWorkFunctionBudget projectWorkFunctionBudget = new ProjectWorkFunctionBudget(null);
                            projectWorkFunctionBudget.InsertDirect(row.ProjectID, row.Work_, row.Function_, row.RefID, row.Budget, row.Deleted, row.COMPANY_ID, row.Budget_);
                        }

                        // Update work function budget
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            int projectId = row.ProjectID;
                            string work_ = row.Work_;
                            string function = row.Function_;
                            int refId = row.RefID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            // original values                            
                            decimal originalBudget = projectNavigatorProjectWorkFunctionBudgetGateway.GetBudgetOriginal(projectId, work_, function, refId);
                            decimal originalBudget_ = projectNavigatorProjectWorkFunctionBudgetGateway.GetBudget_Original(projectId, work_, function, refId);

                            // new values                            
                            decimal newBudget = projectNavigatorProjectWorkFunctionBudgetGateway.GetBudget(projectId, work_, function, refId);
                            decimal newBudget_ = projectNavigatorProjectWorkFunctionBudgetGateway.GetBudget_(projectId, work_, function, refId);

                            ProjectWorkFunctionBudget projectWorkFunctionBudget = new ProjectWorkFunctionBudget(null);
                            projectWorkFunctionBudget.UpdateDirect(projectId, work_, function, refId, originalBudget, originalDeleted, originalCompanyId, projectId, work_, function, refId, newBudget, originalDeleted, originalCompanyId, originalBudget_, newBudget_);
                        }

                        // Delete work function budget 
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            ProjectWorkFunctionBudget projectWorkFunctionBudget = new ProjectWorkFunctionBudget(null);
                            projectWorkFunctionBudget.DeleteDirect(row.ProjectID, row.Work_, row.Function_, row.RefID, row.Budget, row.Deleted, row.COMPANY_ID);
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

            foreach (ProjectNavigatorTDS.ProjectWorkFunctionBudgetRow row in (ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable)Table)
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
            foreach (ProjectNavigatorTDS.ProjectWorkFunctionBudgetRow row in (ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable)Table)
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
        /// <returns>ProjectNavigatorTDS.ProjectWorkFunctionBudgetRow</returns>
        private ProjectNavigatorTDS.ProjectWorkFunctionBudgetRow GetRow(int projectId, string work_, string function_, int refId)
        {
            ProjectNavigatorTDS.ProjectWorkFunctionBudgetRow row = ((ProjectNavigatorTDS.ProjectWorkFunctionBudgetDataTable)Table).FindByProjectIDWork_Function_RefID(projectId, work_, function_, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectNavigatorProjectWorkFunctionBudget.GetRow");
            }

            return row;
        }


        
    }
}