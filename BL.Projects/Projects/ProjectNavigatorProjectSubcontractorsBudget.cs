using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectSubcontractorsBudget
    /// </summary>
    public class ProjectNavigatorProjectSubcontractorsBudget : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectSubcontractorsBudget()
            : base("ProjectSubcontractorsBudget")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectSubcontractorsBudget(DataSet data)
            : base(data, "ProjectSubcontractorsBudget")
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
            ProjectNavigatorProjectSubcontractorsBudgetGateway projectNavigatorProjectSubcontractorsBudgetGateway = new ProjectNavigatorProjectSubcontractorsBudgetGateway(Data);
            projectNavigatorProjectSubcontractorsBudgetGateway.LoadAllByProjectId(projectId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="subcontractor">subcontractor</param>
        public void Insert(int projectId, int subcontractorId, decimal budget, bool deleted, int companyId, bool inDatabase, string subcontractor)
        {
            ProjectNavigatorTDS.ProjectSubcontractorsBudgetRow row = ((ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable)Table).NewProjectSubcontractorsBudgetRow();

            row.ProjectID = projectId;
            row.SubcontractorID = subcontractorId;
            row.RefID = GetNewRefId(subcontractorId);
            row.Budget = budget;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.Subcontractor = subcontractor;

            ((ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable)Table).AddProjectSubcontractorsBudgetRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Update(int projectId, int subcontractorId, int refId, decimal budget, bool deleted, int companyId)
        {
            ProjectNavigatorTDS.ProjectSubcontractorsBudgetRow row = GetRow(projectId, subcontractorId, refId);
            row.Budget = budget;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        public void Delete(int projectId, int subcontractorId, int refId)
        {
            ProjectNavigatorTDS.ProjectSubcontractorsBudgetRow row = GetRow(projectId, subcontractorId, refId);
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
                if (changes.ProjectSubcontractorsBudget.Rows.Count > 0)
                {
                    ProjectNavigatorProjectSubcontractorsBudgetGateway projectNavigatorProjectSubcontractorsBudgetGateway = new ProjectNavigatorProjectSubcontractorsBudgetGateway(changes);

                    foreach (ProjectNavigatorTDS.ProjectSubcontractorsBudgetRow row in (ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable)changes.ProjectSubcontractorsBudget)
                    {
                        // Insert new work function budget
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            ProjectSubcontractorsBudget projectSubcontractorsBudget = new ProjectSubcontractorsBudget(null);
                            projectSubcontractorsBudget.InsertDirect(row.ProjectID, row.SubcontractorID, row.RefID, row.Budget, row.Deleted, row.COMPANY_ID);
                        }

                        // Update work function budget
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            int projectId = row.ProjectID;
                            int refId = row.RefID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            // original values                            
                            decimal originalBudget = projectNavigatorProjectSubcontractorsBudgetGateway.GetBudgetOriginal(projectId, row.SubcontractorID, refId);

                            // new values                            
                            decimal newBudget = projectNavigatorProjectSubcontractorsBudgetGateway.GetBudget(projectId, row.SubcontractorID, refId);

                            ProjectSubcontractorsBudget projectSubcontractorsBudget = new ProjectSubcontractorsBudget(null);
                            projectSubcontractorsBudget.UpdateDirect(projectId, row.SubcontractorID, refId, originalBudget, originalDeleted, originalCompanyId, projectId, row.SubcontractorID, refId, newBudget, originalDeleted, originalCompanyId);
                        }

                        // Delete work function budget 
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            ProjectSubcontractorsBudget projectSubcontractorsBudget = new ProjectSubcontractorsBudget(null);
                            projectSubcontractorsBudget.DeleteDirect(row.ProjectID, row.SubcontractorID, row.RefID, row.Budget, row.Deleted, row.COMPANY_ID);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// GetNewRefID
        /// </summary>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <returns>newRefId</returns>
        public int GetNewRefId(int subcontractorId)
        {
            int newRefId = 0;

            foreach (ProjectNavigatorTDS.ProjectSubcontractorsBudgetRow row in (ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable)Table)
            {
                if ((newRefId < row.RefID) && (row.SubcontractorID == subcontractorId))
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
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectNavigatorTDS.ProjectSubcontractorsBudgetRow</returns>
        private ProjectNavigatorTDS.ProjectSubcontractorsBudgetRow GetRow(int projectId, int subcontractorId, int refId)
        {
            ProjectNavigatorTDS.ProjectSubcontractorsBudgetRow row = ((ProjectNavigatorTDS.ProjectSubcontractorsBudgetDataTable)Table).FindByProjectIDSubcontractorIDRefID(projectId, subcontractorId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectNavigatorProjectSubcontractorsBudget.GetRow");
            }

            return row;
        }


        
    }
}