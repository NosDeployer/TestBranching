using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectUnitsBudget
    /// </summary>
    public class ProjectNavigatorProjectUnitsBudget : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectUnitsBudget()
            : base("ProjectUnitsBudget")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectUnitsBudget(DataSet data)
            : base(data, "ProjectUnitsBudget")
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
            ProjectNavigatorProjectUnitsBudgetGateway projectNavigatorProjectUnitsBudgetGateway = new ProjectNavigatorProjectUnitsBudgetGateway(Data);
            projectNavigatorProjectUnitsBudgetGateway.LoadAllByProjectId(projectId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(int projectId, decimal budget, bool deleted, int companyId, bool inDatabase)
        {
            ProjectNavigatorTDS.ProjectUnitsBudgetRow row = ((ProjectNavigatorTDS.ProjectUnitsBudgetDataTable)Table).NewProjectUnitsBudgetRow();

            row.ProjectID = projectId;
            row.Budget = budget;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;

            ((ProjectNavigatorTDS.ProjectUnitsBudgetDataTable)Table).AddProjectUnitsBudgetRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="budget">budget</param>
        public void Update(int projectId, decimal budget)
        {
            ProjectNavigatorTDS.ProjectUnitsBudgetRow row = GetRow(projectId);
            row.Budget = budget;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        public void Delete(int projectId)
        {
            ProjectNavigatorTDS.ProjectUnitsBudgetRow row = GetRow(projectId);
            row.Deleted = true;
        }

      
        
        /// <summary>
        /// Save all data to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            ProjectNavigatorTDS changes = (ProjectNavigatorTDS)Data.GetChanges();

            if (changes != null)
            {
                if (changes.ProjectUnitsBudget.Rows.Count > 0)
                {
                    ProjectNavigatorProjectUnitsBudgetGateway projectNavigatorProjectUnitsBudgetGateway = new ProjectNavigatorProjectUnitsBudgetGateway(changes);

                    foreach (ProjectNavigatorTDS.ProjectUnitsBudgetRow row in (ProjectNavigatorTDS.ProjectUnitsBudgetDataTable)changes.ProjectUnitsBudget)
                    {
                        // Insert new work function budget
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            ProjectUnistBudget projectUnitsBudget = new ProjectUnistBudget(null);
                            projectUnitsBudget.InsertDirect(row.ProjectID, row.Budget, row.Deleted, row.COMPANY_ID);
                        }

                        // Update work function budget
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            int projectId = row.ProjectID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            // original values                            
                            decimal  originalBudget = projectNavigatorProjectUnitsBudgetGateway.GetBudgetOriginal(projectId);

                            // new values                            
                            decimal newBudget = projectNavigatorProjectUnitsBudgetGateway.GetBudget(projectId);

                            ProjectUnistBudget projectUnitsBudget = new ProjectUnistBudget(null);
                            projectUnitsBudget.UpdateDirect(projectId, originalBudget, originalDeleted, originalCompanyId, projectId, newBudget, originalDeleted, originalCompanyId);
                        }

                        // Delete work function budget 
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            ProjectUnistBudget projectUnitsBudget = new ProjectUnistBudget(null);
                            projectUnitsBudget.DeleteDirect(row.ProjectID, row.Budget, row.Deleted, row.COMPANY_ID);
                        }
                    }
                }
            }
        }
      




        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ProjectNavigatorTDS.ProjectUnitsBudgetRow</returns>
        private ProjectNavigatorTDS.ProjectUnitsBudgetRow GetRow(int projectId)
        {
            ProjectNavigatorTDS.ProjectUnitsBudgetRow row = ((ProjectNavigatorTDS.ProjectUnitsBudgetDataTable)Table).FindByProjectID(projectId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectNavigatorProjectUnitsBudget.GetRow");
            }

            return row;
        }


        
    }
}