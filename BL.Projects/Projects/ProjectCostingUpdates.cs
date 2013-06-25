using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingUpdates
    /// </summary>
    public class ProjectCostingUpdates : TableModule
    {

        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingUpdates()
            : base("LFS_PROJECT_COSTING_UPDATES")
        {
        }
                


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingUpdates(DataSet data)
            : base(data, "LFS_PROJECT_COSTING_UPDATES")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //



        /// <summary>
        /// Insert 
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="extrasToDate">ExtrasToDate</param>
        /// <param name="costsIncurred">CostsIncurred</param>
        /// <param name="costToComplete">CostToComplete</param>
        /// <param name="originalProfitEstimated">OriginalProfitEstimated</param>
        /// <param name="invoicedToDate">InvoicedToDate</param>
        /// <param name="companyId"></param>
        public void Insert(int projectId, decimal? extrasToDate, decimal? costsIncurred, decimal? costToComplete, decimal? originalProfitEstimated, decimal? invoicedToDate, int companyId)
        {
            // Insert new costing updates
            ProjectTDS.LFS_PROJECT_COSTING_UPDATESRow projectCostingUpdatesRow = ((ProjectTDS.LFS_PROJECT_COSTING_UPDATESDataTable)Table).NewLFS_PROJECT_COSTING_UPDATESRow();

            projectCostingUpdatesRow.ProjectID = projectId;

            if (extrasToDate.HasValue) projectCostingUpdatesRow.ExtrasToDate = (decimal)extrasToDate; else projectCostingUpdatesRow.SetExtrasToDateNull();
            if (costsIncurred.HasValue) projectCostingUpdatesRow.CostsIncurred = (decimal)costsIncurred; else projectCostingUpdatesRow.SetCostsIncurredNull();
            if (costToComplete.HasValue) projectCostingUpdatesRow.CostToComplete = (decimal)costToComplete; else projectCostingUpdatesRow.SetCostToCompleteNull();
            if (originalProfitEstimated.HasValue) projectCostingUpdatesRow.OriginalProfitEstimated = (decimal)originalProfitEstimated; else projectCostingUpdatesRow.SetOriginalProfitEstimatedNull();
            if (invoicedToDate.HasValue) projectCostingUpdatesRow.InvoicedToDate = (decimal)invoicedToDate; else projectCostingUpdatesRow.SetInvoicedToDateNull();
            projectCostingUpdatesRow.COMPANY_ID = companyId;

            ((ProjectTDS.LFS_PROJECT_COSTING_UPDATESDataTable)Table).AddLFS_PROJECT_COSTING_UPDATESRow(projectCostingUpdatesRow);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="extrasToDate">ExtrasToDate</param>
        /// <param name="costsIncurred">CostsIncurred</param>
        /// <param name="costToComplete">CostToComplete</param>
        /// <param name="originalProfitEstimated">OriginalProfitEstimated</param>
        /// <param name="invoicedToDate">InvoicedToDate</param>
        /// <param name="companyId"></param>
        public void Update(int projectId, decimal? extrasToDate, decimal? costsIncurred, decimal? costToComplete, decimal? originalProfitEstimated, decimal? invoicedToDate, int companyId)
        {
            ProjectTDS.LFS_PROJECT_COSTING_UPDATESRow projectCostingUpdatesRow = GetRow(projectId);

            if (extrasToDate.HasValue) projectCostingUpdatesRow.ExtrasToDate = (decimal)extrasToDate; else projectCostingUpdatesRow.SetExtrasToDateNull();
            if (costsIncurred.HasValue) projectCostingUpdatesRow.CostsIncurred = (decimal)costsIncurred; else projectCostingUpdatesRow.SetCostsIncurredNull();
            if (costToComplete.HasValue) projectCostingUpdatesRow.CostToComplete = (decimal)costToComplete; else projectCostingUpdatesRow.SetCostToCompleteNull();
            if (originalProfitEstimated.HasValue) projectCostingUpdatesRow.OriginalProfitEstimated = (decimal)originalProfitEstimated; else projectCostingUpdatesRow.SetOriginalProfitEstimatedNull();
            if (invoicedToDate.HasValue) projectCostingUpdatesRow.InvoicedToDate = (decimal)invoicedToDate; else projectCostingUpdatesRow.SetInvoicedToDateNull();
            projectCostingUpdatesRow.COMPANY_ID = companyId;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ProjectTDS.LFS_PROJECT_COSTING_UPDATESRow</returns>
        private ProjectTDS.LFS_PROJECT_COSTING_UPDATESRow GetRow(int projectId)
        {
            ProjectTDS.LFS_PROJECT_COSTING_UPDATESRow row = ((ProjectTDS.LFS_PROJECT_COSTING_UPDATESDataTable)Table).FindByProjectID(projectId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingUpdates.GetRow");
            }
            return row;
        }
    }
}