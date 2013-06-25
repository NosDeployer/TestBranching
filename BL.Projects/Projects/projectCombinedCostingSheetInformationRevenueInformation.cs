using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// projectCombinedCostingSheetInformationRevenueInformation
    /// </summary>
    public class projectCombinedCostingSheetInformationRevenueInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public projectCombinedCostingSheetInformationRevenueInformation()
            : base("CombinedRevenueInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public projectCombinedCostingSheetInformationRevenueInformation(DataSet data)
            : base(data, "CombinedRevenueInformation")
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
        /// <param name="work_">work_</param>
        /// <param name="unitId">unitId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitCode">unitCode</param>
        /// <param name="unitDescription">unitDescription</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Insert(int costingSheetId, decimal revenue, bool deleted, int companyId, DateTime startDate, DateTime endDate, string comment)
        {
            ProjectCostingSheetInformationTDS.CombinedRevenueInformationRow row = ((ProjectCostingSheetInformationTDS.CombinedRevenueInformationDataTable)Table).NewCombinedRevenueInformationRow();

            row.CostingSheetID = costingSheetId;
            row.RefIDRevenue = GetNewRefId();
            row.Revenue = revenue;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.Comment = comment;

            ((ProjectCostingSheetInformationTDS.CombinedRevenueInformationDataTable)Table).AddCombinedRevenueInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitCode">unitCode</param>
        /// <param name="unitDescription">unitDescription</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Update(int costingSheetId, int refIdRevenue, decimal revenue, bool deleted, int companyId, DateTime startDate, DateTime endDate, string comment)
        {
            ProjectCostingSheetInformationTDS.CombinedRevenueInformationRow row = GetRow(costingSheetId, refIdRevenue);

            row.CostingSheetID = costingSheetId;
            row.RefIDRevenue = refIdRevenue;
            row.Revenue = revenue;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.Comment = comment;
            row.StartDate = startDate;
            row.EndDate = endDate;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        public void Delete(int costingSheetId, int subcontractorId, int refIdRevenue)
        {
            ProjectCostingSheetInformationTDS.CombinedRevenueInformationRow row = GetRow(costingSheetId, refIdRevenue);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Revenue Costing Sheets
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetInformationTDS subcontractorsInformationChanges = (ProjectCostingSheetInformationTDS)Data.GetChanges();

            if (subcontractorsInformationChanges.CombinedRevenueInformation.Rows.Count > 0)
            {
                projectCombinedCostingSheetInformationRevenueInformationGateway projectCombinedCostingSheetInformationRevenueInformationGateway = new projectCombinedCostingSheetInformationRevenueInformationGateway(subcontractorsInformationChanges);

                foreach (ProjectCostingSheetInformationTDS.CombinedRevenueInformationRow row in (ProjectCostingSheetInformationTDS.CombinedRevenueInformationDataTable)subcontractorsInformationChanges.CombinedRevenueInformation)
                {
                    // Insert new costing sheet Revenue
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCombinedCostingSheetRevenue subcontractors = new ProjectCombinedCostingSheetRevenue(null);
                        subcontractors.InsertDirect(costingSheetId, row.RefIDRevenue, row.Revenue, false, row.COMPANY_ID, row.StartDate, row.EndDate, row.Comment, row.ProjectID);
                    } 

                    // Update costing sheet Revenue
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        //int subcontractorId = row.SubcontractorID;
                        //int refId = row.RefID;
                        //bool deleted = false;

                        ////original values
                        //string originalUnitOfMeasurement = projectCombinedCostingSheetInformationRevenueInformationGateway.GetUnitOfMeasurementOriginal(costingSheetId, subcontractorId, refId);
                        //double originalQuantity = projectCostingSheetInformationRevenueInformationGateway.GetQuantityOriginal(costingSheetId, subcontractorId, refId);
                        //decimal originalCostCad = projectCostingSheetInformationRevenueInformationGateway.GetCostCadOriginal(costingSheetId, subcontractorId, refId);
                        //decimal originalTotalCostCad = projectCostingSheetInformationRevenueInformationGateway.GetTotalCostCadOriginal(costingSheetId, subcontractorId, refId);
                        //decimal originalCostUsd = projectCostingSheetInformationRevenueInformationGateway.GetCostUsdOriginal(costingSheetId, subcontractorId, refId);
                        //decimal originalTotalCostUsd = projectCostingSheetInformationRevenueInformationGateway.GetTotalCostUsdOriginal(costingSheetId, subcontractorId, refId);
                        //DateTime originalStartDate = projectCostingSheetInformationRevenueInformationGateway.GetStartDateOriginal(costingSheetId, subcontractorId, refId);
                        //DateTime originalEndDate = projectCostingSheetInformationRevenueInformationGateway.GetEndDateOriginal(costingSheetId, subcontractorId, refId);

                        ////original values
                        //string newUnitOfMeasurement = projectCostingSheetInformationRevenueInformationGateway.GetUnitOfMeasurement(costingSheetId, subcontractorId, refId);
                        //double newQuantity = projectCostingSheetInformationRevenueInformationGateway.GetQuantity(costingSheetId, subcontractorId, refId);
                        //decimal newCostCad = projectCostingSheetInformationRevenueInformationGateway.GetCostCad(costingSheetId, subcontractorId, refId);
                        //decimal newTotalCostCad = projectCostingSheetInformationRevenueInformationGateway.GetTotalCostCad(costingSheetId, subcontractorId, refId);
                        //decimal newCostUsd = projectCostingSheetInformationRevenueInformationGateway.GetCostUsd(costingSheetId, subcontractorId, refId);
                        //decimal newTotalCostUsd = projectCostingSheetInformationRevenueInformationGateway.GetTotalCostUsd(costingSheetId, subcontractorId, refId);
                        //DateTime newStartDate = projectCostingSheetInformationRevenueInformationGateway.GetStartDate(costingSheetId, subcontractorId, refId);
                        //DateTime newEndDate = projectCostingSheetInformationRevenueInformationGateway.GetEndDate(costingSheetId, subcontractorId, refId);

                        //ProjectCombinedCostingSheetRevenue subcontractors = new ProjectCombinedCostingSheetRevenue(null);
                        //subcontractors.UpdateDirect(costingSheetId, subcontractorId, refId, originalUnitOfMeasurement, originalQuantity, originalCostCad, originalTotalCostCad, originalCostUsd, originalTotalCostUsd, deleted, companyId, originalStartDate, originalEndDate, newUnitOfMeasurement, newQuantity, newCostCad, newTotalCostCad, newCostUsd, newTotalCostUsd, deleted, companyId, newStartDate, newEndDate);
                    }

                    // Delete costing sheet Revenue 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        ProjectCombinedCostingSheetRevenue subcontractors = new ProjectCombinedCostingSheetRevenue(null);
                        subcontractors.DeleteDirect(row.CostingSheetID, row.RefIDRevenue, row.COMPANY_ID);
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
        /// <param name="work_">work_</param>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private ProjectCostingSheetInformationTDS.CombinedRevenueInformationRow GetRow(int costingSheetId, int refIdRevenue)
        {
            ProjectCostingSheetInformationTDS.CombinedRevenueInformationRow row = ((ProjectCostingSheetInformationTDS.CombinedRevenueInformationDataTable)Table).FindByCostingSheetIDRefIDRevenue(costingSheetId, refIdRevenue);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCombinedCostingSheetInformationRevenueInformation.GetRow");
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

            foreach (ProjectCostingSheetInformationTDS.CombinedRevenueInformationRow row in (ProjectCostingSheetInformationTDS.CombinedRevenueInformationDataTable)Table)
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