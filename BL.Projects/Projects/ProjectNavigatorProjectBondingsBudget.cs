using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectBondingsBudget
    /// </summary>
    public class ProjectNavigatorProjectBondingsBudget : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectBondingsBudget()
            : base("ProjectBondingsBudget")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectBondingsBudget(DataSet data)
            : base(data, "ProjectBondingsBudget")
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
            ProjectNavigatorProjectBondingsBudgetGateway projectNavigatorProjectBondingsBudgetGateway = new ProjectNavigatorProjectBondingsBudgetGateway(Data);
            projectNavigatorProjectBondingsBudgetGateway.LoadAllByProjectId(projectId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="subcontractor">subcontractor</param>
        public void Insert(int projectId, int bondingCompanyId, decimal budget, bool deleted, int companyId, bool inDatabase, string bonding)
        {
            ProjectNavigatorTDS.ProjectBondingsBudgetRow row = ((ProjectNavigatorTDS.ProjectBondingsBudgetDataTable)Table).NewProjectBondingsBudgetRow();

            row.ProjectID = projectId;
            row.BondingCompanyID = bondingCompanyId;
            row.RefID = GetNewRefId(bondingCompanyId);
            row.Budget = budget;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.Bonding = bonding;

            ((ProjectNavigatorTDS.ProjectBondingsBudgetDataTable)Table).AddProjectBondingsBudgetRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Update(int projectId, int bondingCompanyId, int refId, decimal budget, bool deleted, int companyId)
        {
            ProjectNavigatorTDS.ProjectBondingsBudgetRow row = GetRow(projectId, bondingCompanyId, refId);
            row.Budget = budget;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        public void Delete(int projectId, int bondingCompanyId, int refId)
        {
            ProjectNavigatorTDS.ProjectBondingsBudgetRow row = GetRow(projectId, bondingCompanyId, refId);
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
                if (changes.ProjectBondingsBudget.Rows.Count > 0)
                {
                    ProjectNavigatorProjectBondingsBudgetGateway projectNavigatorProjectBondingsBudgetGateway = new ProjectNavigatorProjectBondingsBudgetGateway(changes);

                    foreach (ProjectNavigatorTDS.ProjectBondingsBudgetRow row in (ProjectNavigatorTDS.ProjectBondingsBudgetDataTable)changes.ProjectBondingsBudget)
                    {
                        // Insert new work function budget
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            ProjectBondingsBudget projectBondingsBudget = new ProjectBondingsBudget(null);
                            projectBondingsBudget.InsertDirect(row.ProjectID, row.BondingCompanyID, row.RefID, row.Budget, row.Deleted, row.COMPANY_ID);
                        }

                        // Update work function budget
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            int projectId = row.ProjectID;
                            int refId = row.RefID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            // original values                            
                            decimal originalBudget = projectNavigatorProjectBondingsBudgetGateway.GetBudgetOriginal(projectId, row.BondingCompanyID, refId);

                            // new values                            
                            decimal newBudget = projectNavigatorProjectBondingsBudgetGateway.GetBudget(projectId, row.BondingCompanyID, refId);

                            ProjectBondingsBudget projectBondingsBudget = new ProjectBondingsBudget(null);
                            projectBondingsBudget.UpdateDirect(projectId, row.BondingCompanyID, refId, originalBudget, originalDeleted, originalCompanyId, projectId, row.BondingCompanyID, refId, newBudget, originalDeleted, originalCompanyId);
                        }

                        // Delete work function budget 
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            ProjectBondingsBudget projectBondingsBudget = new ProjectBondingsBudget(null);
                            projectBondingsBudget.DeleteDirect(row.ProjectID, row.BondingCompanyID, row.RefID, row.Budget, row.Deleted, row.COMPANY_ID);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// GetNewRefID
        /// </summary>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <returns>newRefId</returns>
        public int GetNewRefId(int bondingCompanyId)
        {
            int newRefId = 0;

            foreach (ProjectNavigatorTDS.ProjectBondingsBudgetRow row in (ProjectNavigatorTDS.ProjectBondingsBudgetDataTable)Table)
            {
                if ((newRefId < row.RefID) && (row.BondingCompanyID == bondingCompanyId))
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
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectNavigatorTDS.ProjectBondingsBudgetRow</returns>
        private ProjectNavigatorTDS.ProjectBondingsBudgetRow GetRow(int projectId, int bondingCompanyId, int refId)
        {
            ProjectNavigatorTDS.ProjectBondingsBudgetRow row = ((ProjectNavigatorTDS.ProjectBondingsBudgetDataTable)Table).FindByProjectIDBondingCompanyIDRefID(projectId, bondingCompanyId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectNavigatorProjectBondingsBudget.GetRow");
            }

            return row;
        }


        
    }
}