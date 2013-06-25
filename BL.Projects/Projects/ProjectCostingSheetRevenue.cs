using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetRevenue
    /// </summary>
    public class ProjectCostingSheetRevenue : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetRevenue()
            : base("LFS_PROJECT_COSTING_SHEET_REVENUE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetRevenue(DataSet data)
            : base(data, "LFS_PROJECT_COSTING_SHEET_REVENUE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refIDRevenue">refIDRevenue</param>
        /// <param name="refId">refId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="function_">function_</param>
        /// <param name="comment">comment</param>
        public void InsertDirect(int costingSheetId, int refIDRevenue, decimal revenue, bool deleted, int companyId, DateTime startDate, DateTime endDate, string comment)
        {
            // Insert costing sheet Revenues
            ProjectCostingSheetRevenueGateway projectCostingSheetRevenueGateway = new ProjectCostingSheetRevenueGateway(null);
            projectCostingSheetRevenueGateway.Insert(costingSheetId, refIDRevenue, revenue, deleted, companyId, startDate, endDate, comment);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="refIDRevenue">refIDRevenue</param>
        /// <param name="originalRevenue">originalRevenue</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalStartDate">originalStartDate</param>
        /// <param name="originalEndDate">originalEndDate</param>
        /// <param name="originalComment">originalComment</param>
        ///  
        /// <param name="newUnitOfMeasurement">newRevenue</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newStartDate">newStartDate</param>
        /// <param name="newEndDate">newEndDate</param>
        /// <param name="newComment">newComment</param>
        public void UpdateDirect(int costingSheetId, int refIDRevenue, decimal originalRevenue, bool originalDeleted, int originalCompanyId, DateTime originalStartDate, DateTime originalEndDate, string originalComment, decimal newRevenue, bool newDeleted, int newCompanyId, DateTime newStartDate, DateTime newEndDate, string newComment)
        {
            ProjectCostingSheetRevenueGateway projectCostingSheetRevenueGateway = new ProjectCostingSheetRevenueGateway(null);
            projectCostingSheetRevenueGateway.Update(costingSheetId, refIDRevenue, originalRevenue, originalDeleted, originalCompanyId, originalStartDate, originalEndDate, originalComment, newRevenue, newDeleted, newCompanyId, newStartDate, newEndDate, newComment);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int costingSheetId, int companyId)
        {
            ProjectCostingSheetRevenueGateway projectCostingSheetRevenueGateway = new ProjectCostingSheetRevenueGateway(null);
            projectCostingSheetRevenueGateway.DeleteAll(costingSheetId, companyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refIDRevenue">refIDRevenue</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int costingSheetId, int refIdRevenue, int companyId)
        {
            ProjectCostingSheetRevenueGateway projectCostingSheetRevenueGateway = new ProjectCostingSheetRevenueGateway(null);
            projectCostingSheetRevenueGateway.Delete(costingSheetId, refIdRevenue, companyId);
        }



    }
}