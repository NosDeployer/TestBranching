using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectHotelsBudget
    /// </summary>
    public class ProjectNavigatorProjectHotelsBudget : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectHotelsBudget()
            : base("ProjectHotelsBudget")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectHotelsBudget(DataSet data)
            : base(data, "ProjectHotelsBudget")
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
            ProjectNavigatorProjectHotelsBudgetGateway projectNavigatorProjectHotelsBudgetGateway = new ProjectNavigatorProjectHotelsBudgetGateway(Data);
            projectNavigatorProjectHotelsBudgetGateway.LoadAllByProjectId(projectId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="holelId">holelId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="subcontractor">subcontractor</param>
        public void Insert(int projectId, int holelId, decimal budget, bool deleted, int companyId, bool inDatabase, string hotel)
        {
            ProjectNavigatorTDS.ProjectHotelsBudgetRow row = ((ProjectNavigatorTDS.ProjectHotelsBudgetDataTable)Table).NewProjectHotelsBudgetRow();

            row.ProjectID = projectId;
            row.HolelID = holelId;
            row.RefID = GetNewRefId(holelId);
            row.Budget = budget;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.Hotel = hotel;

            ((ProjectNavigatorTDS.ProjectHotelsBudgetDataTable)Table).AddProjectHotelsBudgetRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="holelId">holelId</param>
        /// <param name="refId">refId</param>
        /// <param name="budget">budget</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Update(int projectId, int holelId, int refId, decimal budget, bool deleted, int companyId)
        {
            ProjectNavigatorTDS.ProjectHotelsBudgetRow row = GetRow(projectId, holelId, refId);
            row.Budget = budget;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="holelId">holelId</param>
        /// <param name="refId">refId</param>
        public void Delete(int projectId, int holelId, int refId)
        {
            ProjectNavigatorTDS.ProjectHotelsBudgetRow row = GetRow(projectId, holelId, refId);
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
                if (changes.ProjectHotelsBudget.Rows.Count > 0)
                {
                    ProjectNavigatorProjectHotelsBudgetGateway projectNavigatorProjectHotelsBudgetGateway = new ProjectNavigatorProjectHotelsBudgetGateway(changes);

                    foreach (ProjectNavigatorTDS.ProjectHotelsBudgetRow row in (ProjectNavigatorTDS.ProjectHotelsBudgetDataTable)changes.ProjectHotelsBudget)
                    {
                        // Insert new work function budget
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            ProjectHotelsBudget projectHotelsBudget = new ProjectHotelsBudget(null);
                            projectHotelsBudget.InsertDirect(row.ProjectID, row.HolelID, row.RefID, row.Budget, row.Deleted, row.COMPANY_ID);
                        }

                        // Update work function budget
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            int projectId = row.ProjectID;
                            int refId = row.RefID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            // original values                            
                            decimal originalBudget = projectNavigatorProjectHotelsBudgetGateway.GetBudgetOriginal(projectId, row.HolelID, refId);

                            // new values                            
                            decimal newBudget = projectNavigatorProjectHotelsBudgetGateway.GetBudget(projectId, row.HolelID, refId);

                            ProjectHotelsBudget projectHotelsBudget = new ProjectHotelsBudget(null);
                            projectHotelsBudget.UpdateDirect(projectId, row.HolelID, refId, originalBudget, originalDeleted, originalCompanyId, projectId, row.HolelID, refId, newBudget, originalDeleted, originalCompanyId);
                        }

                        // Delete work function budget 
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            ProjectHotelsBudget projectHotelsBudget = new ProjectHotelsBudget(null);
                            projectHotelsBudget.DeleteDirect(row.ProjectID, row.HolelID, row.RefID, row.Budget, row.Deleted, row.COMPANY_ID);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// GetNewRefID
        /// </summary>
        /// <param name="holelId">holelId</param>
        /// <returns>newRefId</returns>
        public int GetNewRefId(int holelId)
        {
            int newRefId = 0;

            foreach (ProjectNavigatorTDS.ProjectHotelsBudgetRow row in (ProjectNavigatorTDS.ProjectHotelsBudgetDataTable)Table)
            {
                if ((newRefId < row.RefID) && (row.HolelID == holelId))
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
        /// <param name="holelId">holelId</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectNavigatorTDS.ProjectHotelsBudgetRow</returns>
        private ProjectNavigatorTDS.ProjectHotelsBudgetRow GetRow(int projectId, int holelId, int refId)
        {
            ProjectNavigatorTDS.ProjectHotelsBudgetRow row = ((ProjectNavigatorTDS.ProjectHotelsBudgetDataTable)Table).FindByProjectIDHolelIDRefID(projectId, holelId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectNavigatorProjectHotelsBudget.GetRow");
            }

            return row;
        }


        
    }
}