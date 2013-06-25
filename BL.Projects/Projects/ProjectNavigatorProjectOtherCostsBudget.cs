using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectOtherCostsBudget
    /// </summary>
    public class ProjectNavigatorProjectOtherCostsBudget : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectOtherCostsBudget()
            : base("ProjectOtherCostsBudget")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectOtherCostsBudget(DataSet data)
            : base(data, "ProjectOtherCostsBudget")
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
            ProjectNavigatorProjectOtherCostsBudgetGateway projectNavigatorProjectOtherCostsBudgetGateway = new ProjectNavigatorProjectOtherCostsBudgetGateway(Data);
            projectNavigatorProjectOtherCostsBudgetGateway.LoadAllByProjectId(projectId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="category">category</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="subcontractor">subcontractor</param>
        public void Insert(int projectId, string category, decimal budget, bool deleted, int companyId, bool inDatabase)
        {
            ProjectNavigatorTDS.ProjectOtherCostsBudgetRow row = ((ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable)Table).NewProjectOtherCostsBudgetRow();

            row.ProjectID = projectId;
            row.Category = category;
            row.RefID = GetNewRefId(category);
            row.Budget = budget;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;

            ((ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable)Table).AddProjectOtherCostsBudgetRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="category">category</param>
        /// <param name="refId">refId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Update(int projectId, string category, int refId, decimal budget, bool deleted, int companyId)
        {
            ProjectNavigatorTDS.ProjectOtherCostsBudgetRow row = GetRow(projectId, category, refId);
            row.Budget = budget;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="category">category</param>
        /// <param name="refId">refId</param>
        public void Delete(int projectId, string category, int refId)
        {
            ProjectNavigatorTDS.ProjectOtherCostsBudgetRow row = GetRow(projectId, category, refId);
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
                if (changes.ProjectOtherCostsBudget.Rows.Count > 0)
                {
                    ProjectNavigatorProjectOtherCostsBudgetGateway projectNavigatorProjectOtherCostsBudgetGateway = new ProjectNavigatorProjectOtherCostsBudgetGateway(changes);

                    foreach (ProjectNavigatorTDS.ProjectOtherCostsBudgetRow row in (ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable)changes.ProjectOtherCostsBudget)
                    {
                        // Insert new work function budget
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            ProjectOtherCostsBudget projectOtherCostsBudget = new ProjectOtherCostsBudget(null);
                            projectOtherCostsBudget.InsertDirect(row.ProjectID, row.Category, row.RefID, row.Budget, row.Deleted, row.COMPANY_ID);
                        }

                        // Update work function budget
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            int projectId = row.ProjectID;
                            int refId = row.RefID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            // original values                            
                            decimal originalBudget = projectNavigatorProjectOtherCostsBudgetGateway.GetBudgetOriginal(projectId, row.Category, refId);

                            // new values                            
                            decimal newBudget = projectNavigatorProjectOtherCostsBudgetGateway.GetBudget(projectId, row.Category, refId);

                            ProjectOtherCostsBudget projectOtherCostsBudget = new ProjectOtherCostsBudget(null);
                            projectOtherCostsBudget.UpdateDirect(projectId, row.Category, refId, originalBudget, originalDeleted, originalCompanyId, projectId, row.Category, refId, newBudget, originalDeleted, originalCompanyId);
                        }

                        // Delete work function budget 
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            ProjectOtherCostsBudget projectOtherCostsBudget = new ProjectOtherCostsBudget(null);
                            projectOtherCostsBudget.DeleteDirect(row.ProjectID, row.Category, row.RefID, row.Budget, row.Deleted, row.COMPANY_ID);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// GetNewRefID
        /// </summary>
        /// <param name="category">category</param>
        /// <returns>newRefId</returns>
        public int GetNewRefId(string category)
        {
            int newRefId = 0;

            foreach (ProjectNavigatorTDS.ProjectOtherCostsBudgetRow row in (ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable)Table)
            {
                if ((newRefId < row.RefID) && (row.Category == category))
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
        /// <param name="category">category</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectNavigatorTDS.ProjectOtherCostsBudgetRow</returns>
        private ProjectNavigatorTDS.ProjectOtherCostsBudgetRow GetRow(int projectId, string category, int refId)
        {
            ProjectNavigatorTDS.ProjectOtherCostsBudgetRow row = ((ProjectNavigatorTDS.ProjectOtherCostsBudgetDataTable)Table).FindByProjectIDCategoryRefID(projectId, category, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectNavigatorProjectOtherCostsBudget.GetRow");
            }

            return row;
        }


        
    }
}