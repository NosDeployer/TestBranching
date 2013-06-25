using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetInformationOtherCategoryInformation
    /// </summary>
    public class ProjectCostingSheetInformationOtherCategoryInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetInformationOtherCategoryInformation()
            : base("OtherCategoryInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetInformationOtherCategoryInformation(DataSet data)
            : base(data, "OtherCategoryInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetInformationTDS();
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="category">category</param>
        /// <param name="rate">rate</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="hotel">hotel</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Insert(int costingSheetId, string category, decimal rate, bool deleted, int companyId, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.OtherCategoryInformationRow row = ((ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable)Table).NewOtherCategoryInformationRow();

            row.CostingSheetID = costingSheetId;
            row.Category = category;
            row.RefID = GetNewRefId();
            row.Rate = rate;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.StartDate = startDate;
            row.EndDate = endDate;

            ((ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable)Table).AddOtherCategoryInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="category">category</param>
        /// <param name="refId">refId</param>
        /// <param name="rate">rate</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="hotel">hotel</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Update(int costingSheetId, string category, int refId, decimal rate, bool deleted, int companyId, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.OtherCategoryInformationRow row = GetRow(costingSheetId, category, refId);

            row.CostingSheetID = costingSheetId;
            row.Category = category;
            row.Rate = rate;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.StartDate = startDate;
            row.EndDate = endDate;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="category">category</param>
        /// <param name="refId">refId</param>
        public void Delete(int costingSheetId, string category, int refId)
        {
            ProjectCostingSheetInformationTDS.OtherCategoryInformationRow row = GetRow(costingSheetId, category, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Other Category Costing Sheets
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetInformationTDS otherCategoryInformationChanges = (ProjectCostingSheetInformationTDS)Data.GetChanges();

            if (otherCategoryInformationChanges.OtherCategoryInformation.Rows.Count > 0)
            {
                ProjectCostingSheetInformationOtherCategoryInformationGateway projectCostingSheetInformationOtherCategoryInformationGateway = new ProjectCostingSheetInformationOtherCategoryInformationGateway(otherCategoryInformationChanges);

                foreach (ProjectCostingSheetInformationTDS.OtherCategoryInformationRow row in (ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable)otherCategoryInformationChanges.OtherCategoryInformation)
                {
                    // Insert new costing sheet Other Category
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCostingSheetOtherCategory otherCategory = new ProjectCostingSheetOtherCategory(null);
                        otherCategory.InsertDirect(costingSheetId, row.Category, row.RefID, row.Rate, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.Comment);
                    }

                    // Update costing sheet Other Category
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        string category = row.Category;
                        int refId = row.RefID;
                        bool deleted = false;

                        //original values
                        decimal originalRate = projectCostingSheetInformationOtherCategoryInformationGateway.GetRateOriginal(costingSheetId, category, refId);
                        DateTime originalStartDate = projectCostingSheetInformationOtherCategoryInformationGateway.GetStartDateOriginal(costingSheetId, category, refId);
                        DateTime originalEndDate = projectCostingSheetInformationOtherCategoryInformationGateway.GetEndDateOriginal(costingSheetId, category, refId);

                        //original values
                        decimal newRate = projectCostingSheetInformationOtherCategoryInformationGateway.GetRate(costingSheetId, category, refId);
                        DateTime newStartDate = projectCostingSheetInformationOtherCategoryInformationGateway.GetStartDate(costingSheetId, category, refId);
                        DateTime newEndDate = projectCostingSheetInformationOtherCategoryInformationGateway.GetEndDate(costingSheetId, category, refId);

                        ProjectCostingSheetOtherCategory otherCategory = new ProjectCostingSheetOtherCategory(null);
                        //otherCategory.UpdateDirect(costingSheetId, category, refId, originalRate, deleted, companyId, originalStartDate, originalEndDate, newRate, deleted, companyId, newStartDate, newEndDate);
                    }

                    // Delete costing sheet Other Category 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        /*ProjectCostingSheetOtherCategory otherCategory = new ProjectCostingSheetOtherCategory(null);
                        otherCategory.DeleteDirect(row.CostingSheetID, row.Category, row.RefID, row.COMPANY_ID);*/
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="category">category</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private ProjectCostingSheetInformationTDS.OtherCategoryInformationRow GetRow(int costingSheetId, string category, int refId)
        {
            ProjectCostingSheetInformationTDS.OtherCategoryInformationRow row = ((ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable)Table).FindByRefIDCategoryCostingSheetID(refId, category, costingSheetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetInformationOtherCategoryInformation.GetRow");
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

            foreach (ProjectCostingSheetInformationTDS.OtherCategoryInformationRow row in (ProjectCostingSheetInformationTDS.OtherCategoryInformationDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }



    }
}