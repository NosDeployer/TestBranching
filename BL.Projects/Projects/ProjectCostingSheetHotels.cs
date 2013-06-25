using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetHotels
    /// </summary>
    public class ProjectCostingSheetHotels : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetHotels()
            : base("LFS_PROJECT_COSTING_SHEET_HOTEL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetHotels(DataSet data)
            : base(data, "LFS_PROJECT_COSTING_SHEET_HOTEL")
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
        /// <param name="subcontractorID">subcontractorID</param>
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
        public void InsertDirect(int costingSheetId, int hotelId, int refId, decimal rate, bool deleted, int companyId, DateTime startDate, DateTime endDate, string comment)
        {
            // Insert costing sheet Subcontractors
            ProjectCostingSheetHotelsGateway projectCostingSheetSubcontractorsGateway = new ProjectCostingSheetHotelsGateway(null);
            projectCostingSheetSubcontractorsGateway.Insert(costingSheetId, hotelId, refId, rate, deleted, companyId, startDate, endDate, comment);
        }



    }
}