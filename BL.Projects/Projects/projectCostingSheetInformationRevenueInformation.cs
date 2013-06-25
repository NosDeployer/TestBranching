using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// projectCostingSheetInformationRevenueInformation
    /// </summary>
    public class projectCostingSheetInformationRevenueInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public projectCostingSheetInformationRevenueInformation()
            : base("RevenueInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public projectCostingSheetInformationRevenueInformation(DataSet data)
            : base(data, "RevenueInformation")
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
            ProjectCostingSheetInformationTDS.RevenueInformationRow row = ((ProjectCostingSheetInformationTDS.RevenueInformationDataTable)Table).NewRevenueInformationRow();

            row.CostingSheetID = costingSheetId;
            row.RefIDRevenue = GetNewRefId();
            row.Revenue = revenue;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.Comment = comment;

            ((ProjectCostingSheetInformationTDS.RevenueInformationDataTable)Table).AddRevenueInformationRow(row);
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
            ProjectCostingSheetInformationTDS.RevenueInformationRow row = GetRow(costingSheetId, refIdRevenue);

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
            ProjectCostingSheetInformationTDS.RevenueInformationRow row = GetRow(costingSheetId, refIdRevenue);
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

            if (subcontractorsInformationChanges.RevenueInformation.Rows.Count > 0)
            {
                projectCostingSheetInformationRevenueInformationGateway projectCostingSheetInformationRevenueInformationGateway = new projectCostingSheetInformationRevenueInformationGateway(subcontractorsInformationChanges);

                foreach (ProjectCostingSheetInformationTDS.RevenueInformationRow row in (ProjectCostingSheetInformationTDS.RevenueInformationDataTable)subcontractorsInformationChanges.RevenueInformation)
                {
                    // Insert new costing sheet Revenue
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCostingSheetRevenue subcontractors = new ProjectCostingSheetRevenue(null);
                        subcontractors.InsertDirect(costingSheetId, row.RefIDRevenue, row.Revenue, false, row.COMPANY_ID, row.StartDate, row.EndDate, row.Comment);
                    } 

                    // Update costing sheet Revenue
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        //int subcontractorId = row.SubcontractorID;
                        //int refId = row.RefID;
                        //bool deleted = false;

                        ////original values
                        //string originalUnitOfMeasurement = projectCostingSheetInformationRevenueInformationGateway.GetUnitOfMeasurementOriginal(costingSheetId, subcontractorId, refId);
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

                        //ProjectCostingSheetRevenue subcontractors = new ProjectCostingSheetRevenue(null);
                        //subcontractors.UpdateDirect(costingSheetId, subcontractorId, refId, originalUnitOfMeasurement, originalQuantity, originalCostCad, originalTotalCostCad, originalCostUsd, originalTotalCostUsd, deleted, companyId, originalStartDate, originalEndDate, newUnitOfMeasurement, newQuantity, newCostCad, newTotalCostCad, newCostUsd, newTotalCostUsd, deleted, companyId, newStartDate, newEndDate);
                    }

                    // Delete costing sheet Revenue 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        ProjectCostingSheetRevenue subcontractors = new ProjectCostingSheetRevenue(null);
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
        private ProjectCostingSheetInformationTDS.RevenueInformationRow GetRow(int costingSheetId, int refIdRevenue)
        {
            ProjectCostingSheetInformationTDS.RevenueInformationRow row = ((ProjectCostingSheetInformationTDS.RevenueInformationDataTable)Table).FindByCostingSheetIDRefIDRevenue(costingSheetId, refIdRevenue);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetInformationRevenueInformation.GetRow");
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

            foreach (ProjectCostingSheetInformationTDS.RevenueInformationRow row in (ProjectCostingSheetInformationTDS.RevenueInformationDataTable)Table)
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