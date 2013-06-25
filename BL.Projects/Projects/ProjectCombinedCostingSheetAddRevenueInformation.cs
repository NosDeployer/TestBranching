using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using System.Collections;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCombinedCostingSheetAddRevenueInformation
    /// </summary>
    public class ProjectCombinedCostingSheetAddRevenueInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCombinedCostingSheetAddRevenueInformation()
            : base("CombinedRevenueInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCombinedCostingSheetAddRevenueInformation(DataSet data)
            : base(data, "CombinedRevenueInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetAddTDS();
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void Load(ArrayList projects, DateTime startDate, DateTime endDate, int companyId)
        {
            foreach (int projectId in projects)
            {
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);

                string project = projectGateway.GetName(projectId);
                
                DateTime newStartDate = new DateTime();
                newStartDate = startDate;
                DateTime newEndDate = new DateTime();
                newEndDate = endDate;

                ProjectCostingSheetAddOriginalRevenueGateway projectCostingSheetAddOriginalRevenueGateway = new ProjectCostingSheetAddOriginalRevenueGateway(Data);
                projectCostingSheetAddOriginalRevenueGateway.LoadByProjectIdStartDateEndDate(projectId, newStartDate, newEndDate);

                if (projectCostingSheetAddOriginalRevenueGateway.Table.Rows.Count > 0)
                {
                    foreach (ProjectCostingSheetAddTDS.OriginalRevenueRow originalRow in (ProjectCostingSheetAddTDS.OriginalRevenueDataTable)projectCostingSheetAddOriginalRevenueGateway.Table)
                    {
                        ProjectCostingSheetAddTDS.CombinedRevenueInformationRow newRow = ((ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable)Table).NewCombinedRevenueInformationRow();
                        newRow.CostingSheetID = 0;
                        newRow.RefIDRevenue = originalRow.RefIDRevenue;
                        newRow.Revenue = originalRow.Revenue;
                        newRow.Deleted = false;
                        newRow.InDatabase = false;
                        newRow.COMPANY_ID = companyId;
                        newRow.Comment = ""; if (!originalRow.IsCommentNull()) newRow.Comment = originalRow.Comment;
                        newRow.StartDate = originalRow.Date_;
                        newRow.EndDate = originalRow.Date_;
                        newRow.FromDatabase = true;
                        newRow.ProjectID = projectId;
                        newRow.Project = project;
                        ((ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable)Table).AddCombinedRevenueInformationRow(newRow);
                    }
                }
            }
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="revenue">revenue</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="comment">comment</param>
        public void Insert(int costingSheetId, decimal revenue, bool deleted, int companyId, DateTime startDate, DateTime endDate, string comment, int projectId)
        {
            ProjectCostingSheetAddTDS.CombinedRevenueInformationRow row = ((ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable)Table).NewCombinedRevenueInformationRow();

            row.CostingSheetID = costingSheetId;
            row.RefIDRevenue = GetNewRefId();
            row.Revenue = revenue;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.Comment = comment;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.FromDatabase = false;
            row.ProjectID = projectId;

            ((ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable)Table).AddCombinedRevenueInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refIdRevenue">refIdRevenue</param>
        /// <param name="revenue">revenue</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="comment">comment</param>
        public void Update(int costingSheetId, int refIdRevenue, decimal revenue, bool deleted, int companyId, DateTime startDate, DateTime endDate, string comment)
        {
            ProjectCostingSheetAddTDS.CombinedRevenueInformationRow row = GetRow(costingSheetId, refIdRevenue);

            row.Revenue = revenue;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.Comment = comment;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refIdRevenue</param>
        public void Delete(int costingSheetId, int refIdRevenue)
        {
            ProjectCostingSheetAddTDS.CombinedRevenueInformationRow row = GetRow(costingSheetId, refIdRevenue);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Revenue Costing Sheet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetAddTDS informationChanges = (ProjectCostingSheetAddTDS)Data.GetChanges();

            if (informationChanges.CombinedRevenueInformation.Rows.Count > 0)
            {
                foreach (ProjectCostingSheetAddTDS.CombinedRevenueInformationRow row in (ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable)informationChanges.CombinedRevenueInformation)
                {
                    // Insert new costing sheet Revenue 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCombinedCostingSheetRevenue projectCostingSheetRevenue = new ProjectCombinedCostingSheetRevenue(null);
                        projectCostingSheetRevenue.InsertDirect(costingSheetId, row.RefIDRevenue, row.Revenue, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.Comment, row.ProjectID);
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
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refIdRevenue">refIdRevenue</param>
        /// <returns>row</returns>
        private ProjectCostingSheetAddTDS.CombinedRevenueInformationRow GetRow(int costingSheetId, int refIdRevenue)
        {
            ProjectCostingSheetAddTDS.CombinedRevenueInformationRow row = ((ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable)Table).FindByCostingSheetIDRefIDRevenue(costingSheetId, refIdRevenue);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCombinedCostingSheetAddRevenueInformation.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>RefID</returns>
        private int GetNewRefId()
        {
            int newRefId = 0;

            foreach (ProjectCostingSheetAddTDS.CombinedRevenueInformationRow row in (ProjectCostingSheetAddTDS.CombinedRevenueInformationDataTable)Table)
            {
                if (newRefId < row.RefIDRevenue)
                {
                    newRefId = row.RefIDRevenue;
                }
            }

            newRefId++;

            return newRefId;
        }


        
    }
}