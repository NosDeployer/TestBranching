using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddOtherCategoryInformation
    /// </summary>
    public class ProjectCostingSheetAddOtherCategoryInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetAddOtherCategoryInformation()
            : base("OtherCategoryInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetAddOtherCategoryInformation(DataSet data)
            : base(data, "OtherCategoryInformation")
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
        public void Load(int projectId, DateTime startDate, DateTime endDate, int companyId)
        {
            int refId = 0;

            ProjectCostingSheetAddOtherCategoryListGateway projectCostingSheetAddOtherCategoryListGateway = new ProjectCostingSheetAddOtherCategoryListGateway(Data);
            projectCostingSheetAddOtherCategoryListGateway.LoadByProjectIdStartDateEndDate(projectId, startDate, endDate, companyId);

            foreach (ProjectCostingSheetAddTDS.OtherCategoryListRow subcontractorListRow in (ProjectCostingSheetAddTDS.OtherCategoryListDataTable)projectCostingSheetAddOtherCategoryListGateway.Table)
            {
                DateTime newStartDate = new DateTime();
                newStartDate = startDate;
                DateTime newEndDate = new DateTime();
                newEndDate = endDate;

                ProjectCostingSheetAddOriginalOtherCategoryGateway projectCostingSheetAddOriginalOtherCategoryGateway = new ProjectCostingSheetAddOriginalOtherCategoryGateway(Data);
                projectCostingSheetAddOriginalOtherCategoryGateway.LoadByProjectIdStartDateEndDateOtherCategoryId(projectId, newStartDate, newEndDate, subcontractorListRow.Category);

                if (projectCostingSheetAddOriginalOtherCategoryGateway.Table.Rows.Count > 0)
                {
                    foreach (ProjectCostingSheetAddTDS.OriginalOtherCategoryRow originalOtherCategoryRow in (ProjectCostingSheetAddTDS.OriginalOtherCategoryDataTable)projectCostingSheetAddOriginalOtherCategoryGateway.Table)
                    {
                        ProjectCostingSheetAddTDS.OtherCategoryInformationRow newRow = ((ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable)Table).NewOtherCategoryInformationRow();
                        newRow.CostingSheetID = 0;
                        newRow.Category = subcontractorListRow.Category;
                        newRow.RefID = refId++;
                        newRow.Rate = originalOtherCategoryRow.Rate;
                        newRow.Deleted = false;
                        newRow.InDatabase = false;
                        newRow.COMPANY_ID = companyId;
                        newRow.StartDate = originalOtherCategoryRow.Date_;
                        newRow.EndDate = newEndDate;
                        newRow.FromDatabase = true;
                        newRow.Comment = ""; if (!originalOtherCategoryRow.IsCommentNull()) newRow.Comment = originalOtherCategoryRow.Comment;

                        ((ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable)Table).AddOtherCategoryInformationRow(newRow);
                    }
                }
            }
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceId">insuranceId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="comment">comment</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="subcontractor">subcontractor</param>
        public void Insert(int costingSheetId, string category, decimal rate, bool deleted, int companyId, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetAddTDS.OtherCategoryInformationRow row = ((ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable)Table).NewOtherCategoryInformationRow();

            row.CostingSheetID = costingSheetId;
            row.Category = category;
            row.RefID = GetNewRefId();
            row.Rate = rate;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.FromDatabase = false;

            ((ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable)Table).AddOtherCategoryInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceId">insuranceId</param>
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
        public void Update(int costingSheetId, string category, int refId, decimal rate, bool deleted, int companyId, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetAddTDS.OtherCategoryInformationRow row = GetRow(costingSheetId, category, refId);

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
        /// <param name="insuranceId">insuranceId</param>
        /// <param name="refId">refId</param>
        public void Delete(int costingSheetId, string category, int refId)
        {
            ProjectCostingSheetAddTDS.OtherCategoryInformationRow row = GetRow(costingSheetId, category, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all OtherCategorys Costing Sheet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetAddTDS changes = (ProjectCostingSheetAddTDS)Data.GetChanges();

            if (changes.OtherCategoryInformation.Rows.Count > 0)
            {
                foreach (ProjectCostingSheetAddTDS.OtherCategoryInformationRow row in (ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable)changes.OtherCategoryInformation)
                {
                    // Insert new costing sheet OtherCategorys 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCostingSheetOtherCategory projectCostingSheetOtherCategorys = new ProjectCostingSheetOtherCategory(null);
                        projectCostingSheetOtherCategorys.InsertDirect(costingSheetId, row.Category, row.RefID, row.Rate, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.Comment);
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
        /// <param name="insuranceId">insuranceId</param>
        /// <param name="refId">refId</param>
        /// <returns>row</returns>
        private ProjectCostingSheetAddTDS.OtherCategoryInformationRow GetRow(int costingSheetId, string category, int refId)
        {
            ProjectCostingSheetAddTDS.OtherCategoryInformationRow row = ((ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable)Table).FindByCostingSheetIDCategoryRefID(costingSheetId, category, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetAddOtherCategorysInformation.GetRow");
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

            foreach (ProjectCostingSheetAddTDS.OtherCategoryInformationRow row in (ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable)Table)
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