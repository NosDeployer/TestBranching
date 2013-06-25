using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectMaterialsBudget
    /// </summary>
    public class ProjectNavigatorProjectMaterialsBudget : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectMaterialsBudget()
            : base("ProjectMaterialsBudget")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectMaterialsBudget(DataSet data)
            : base(data, "ProjectMaterialsBudget")
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
            ProjectNavigatorProjectMaterialsBudgetGateway projectNavigatorProjectMaterialsBudgetGateway = new ProjectNavigatorProjectMaterialsBudgetGateway(Data);
            projectNavigatorProjectMaterialsBudgetGateway.LoadAllByProjectId(projectId);
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
            ProjectNavigatorTDS.ProjectMaterialsBudgetRow row = ((ProjectNavigatorTDS.ProjectMaterialsBudgetDataTable)Table).NewProjectMaterialsBudgetRow();

            row.ProjectID = projectId;
            row.Budget = budget;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;

            ((ProjectNavigatorTDS.ProjectMaterialsBudgetDataTable)Table).AddProjectMaterialsBudgetRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="budget">budget</param>
        public void Update(int projectId, decimal budget)
        {
            ProjectNavigatorTDS.ProjectMaterialsBudgetRow row = GetRow(projectId);
            row.Budget = budget;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        public void Delete(int projectId)
        {
            ProjectNavigatorTDS.ProjectMaterialsBudgetRow row = GetRow(projectId);
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
                if (changes.ProjectMaterialsBudget.Rows.Count > 0)
                {
                    ProjectNavigatorProjectMaterialsBudgetGateway projectNavigatorProjectMaterialsBudgetGateway = new ProjectNavigatorProjectMaterialsBudgetGateway(changes);

                    foreach (ProjectNavigatorTDS.ProjectMaterialsBudgetRow row in (ProjectNavigatorTDS.ProjectMaterialsBudgetDataTable)changes.ProjectMaterialsBudget)
                    {
                        // Insert new work function budget
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            ProjectMaterialsBudget projectMaterialsBudget = new ProjectMaterialsBudget(null);
                            projectMaterialsBudget.InsertDirect(row.ProjectID, row.Budget, row.Deleted, row.COMPANY_ID);
                        }

                        // Update work function budget
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            int projectId = row.ProjectID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            // original values                            
                            decimal  originalBudget = projectNavigatorProjectMaterialsBudgetGateway.GetBudgetOriginal(projectId);

                            // new values                            
                            decimal newBudget = projectNavigatorProjectMaterialsBudgetGateway.GetBudget(projectId);

                            ProjectMaterialsBudget projectMaterialsBudget = new ProjectMaterialsBudget(null);
                            projectMaterialsBudget.UpdateDirect(projectId, originalBudget, originalDeleted, originalCompanyId, projectId, newBudget, originalDeleted, originalCompanyId);
                        }

                        // Delete work function budget 
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            ProjectMaterialsBudget projectMaterialsBudget = new ProjectMaterialsBudget(null);
                            projectMaterialsBudget.DeleteDirect(row.ProjectID, row.Budget, row.Deleted, row.COMPANY_ID);
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
        /// <returns>ProjectNavigatorTDS.ProjectMaterialsBudgetRow</returns>
        private ProjectNavigatorTDS.ProjectMaterialsBudgetRow GetRow(int projectId)
        {
            ProjectNavigatorTDS.ProjectMaterialsBudgetRow row = ((ProjectNavigatorTDS.ProjectMaterialsBudgetDataTable)Table).FindByProjectID(projectId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectNavigatorProjectMaterialsBudget.GetRow");
            }

            return row;
        }


        
    }
}