using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectInsurancesBudget
    /// </summary>
    public class ProjectNavigatorProjectInsurancesBudget : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectInsurancesBudget()
            : base("ProjectInsurancesBudget")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectInsurancesBudget(DataSet data)
            : base(data, "ProjectInsurancesBudget")
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
            ProjectNavigatorProjectInsurancesBudgetGateway projectNavigatorProjectInsurancesBudgetGateway = new ProjectNavigatorProjectInsurancesBudgetGateway(Data);
            projectNavigatorProjectInsurancesBudgetGateway.LoadAllByProjectId(projectId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="subcontractor">subcontractor</param>
        public void Insert(int projectId, int insuranceCompanyId, decimal budget, bool deleted, int companyId, bool inDatabase, string insurance)
        {
            ProjectNavigatorTDS.ProjectInsurancesBudgetRow row = ((ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable)Table).NewProjectInsurancesBudgetRow();

            row.ProjectID = projectId;
            row.InsuranceCompanyID = insuranceCompanyId;
            row.RefID = GetNewRefId(insuranceCompanyId);
            row.Budget = budget;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.Insurance = insurance;

            ((ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable)Table).AddProjectInsurancesBudgetRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Update(int projectId, int insuranceCompanyId, int refId, decimal budget, bool deleted, int companyId)
        {
            ProjectNavigatorTDS.ProjectInsurancesBudgetRow row = GetRow(projectId, insuranceCompanyId, refId);
            row.Budget = budget;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        public void Delete(int projectId, int insuranceCompanyId, int refId)
        {
            ProjectNavigatorTDS.ProjectInsurancesBudgetRow row = GetRow(projectId, insuranceCompanyId, refId);
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
                if (changes.ProjectInsurancesBudget.Rows.Count > 0)
                {
                    ProjectNavigatorProjectInsurancesBudgetGateway projectNavigatorProjectInsurancesBudgetGateway = new ProjectNavigatorProjectInsurancesBudgetGateway(changes);

                    foreach (ProjectNavigatorTDS.ProjectInsurancesBudgetRow row in (ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable)changes.ProjectInsurancesBudget)
                    {
                        // Insert new work function budget
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            ProjectInsurancesBudget projectInsurancesBudget = new ProjectInsurancesBudget(null);
                            projectInsurancesBudget.InsertDirect(row.ProjectID, row.InsuranceCompanyID, row.RefID, row.Budget, row.Deleted, row.COMPANY_ID);
                        }

                        // Update work function budget
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            int projectId = row.ProjectID;
                            int refId = row.RefID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            // original values                            
                            decimal originalBudget = projectNavigatorProjectInsurancesBudgetGateway.GetBudgetOriginal(projectId, row.InsuranceCompanyID, refId);

                            // new values                            
                            decimal newBudget = projectNavigatorProjectInsurancesBudgetGateway.GetBudget(projectId, row.InsuranceCompanyID, refId);

                            ProjectInsurancesBudget projectInsurancesBudget = new ProjectInsurancesBudget(null);
                            projectInsurancesBudget.UpdateDirect(projectId, row.InsuranceCompanyID, refId, originalBudget, originalDeleted, originalCompanyId, projectId, row.InsuranceCompanyID, refId, newBudget, originalDeleted, originalCompanyId);
                        }

                        // Delete work function budget 
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            ProjectInsurancesBudget projectInsurancesBudget = new ProjectInsurancesBudget(null);
                            projectInsurancesBudget.DeleteDirect(row.ProjectID, row.InsuranceCompanyID, row.RefID, row.Budget, row.Deleted, row.COMPANY_ID);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// GetNewRefID
        /// </summary>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <returns>newRefId</returns>
        public int GetNewRefId(int insuranceCompanyId)
        {
            int newRefId = 0;

            foreach (ProjectNavigatorTDS.ProjectInsurancesBudgetRow row in (ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable)Table)
            {
                if ((newRefId < row.RefID) && (row.InsuranceCompanyID == insuranceCompanyId))
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
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectNavigatorTDS.ProjectInsurancesBudgetRow</returns>
        private ProjectNavigatorTDS.ProjectInsurancesBudgetRow GetRow(int projectId, int insuranceCompanyId, int refId)
        {
            ProjectNavigatorTDS.ProjectInsurancesBudgetRow row = ((ProjectNavigatorTDS.ProjectInsurancesBudgetDataTable)Table).FindByProjectIDInsuranceCompanyIDRefID(projectId, insuranceCompanyId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectNavigatorProjectInsurancesBudget.GetRow");
            }

            return row;
        }


        
    }
}