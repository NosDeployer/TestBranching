using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCombinedCostingSheetInformationSubcontractorsInformation
    /// </summary>
    public class ProjectCombinedCostingSheetInformationSubcontractorsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCombinedCostingSheetInformationSubcontractorsInformation()
            : base("CombinedSubcontractorsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCombinedCostingSheetInformationSubcontractorsInformation(DataSet data)
            : base(data, "CombinedSubcontractorsInformation")
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
        public void Insert(int costingSheetId, int subcontractorId, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string subcontractor, DateTime startDate, DateTime endDate, string comment)
        {
            ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationRow row = ((ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable)Table).NewCombinedSubcontractorsInformationRow();

            row.CostingSheetID = costingSheetId;
            row.SubcontractorID = subcontractorId;
            row.RefID = GetNewRefId();
            row.Quantity = quantity;
            row.UnitOfMeasurement = unitOfMeasurement;
            row.CostCad = costCad;
            row.TotalCostCad = totalCostCad;
            row.CostUsd = costUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.Subcontractor = subcontractor;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.Comment = comment;

            ((ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable)Table).AddCombinedSubcontractorsInformationRow(row);
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
        public void Update(int costingSheetId, int subcontractorId, int refId, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string subcontractor, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationRow row = GetRow(costingSheetId, subcontractorId, refId);

            row.CostingSheetID = costingSheetId;
            row.SubcontractorID = subcontractorId;
            row.Quantity = quantity;
            row.UnitOfMeasurement = unitOfMeasurement;
            row.CostCad = costCad;
            row.TotalCostCad = totalCostCad;
            row.CostUsd = costUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.Subcontractor = subcontractor;
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
        public void Delete(int costingSheetId, int subcontractorId, int refId)
        {
            ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationRow row = GetRow(costingSheetId, subcontractorId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Subcontractors Costing Sheets
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetInformationTDS subcontractorsInformationChanges = (ProjectCostingSheetInformationTDS)Data.GetChanges();

            if (subcontractorsInformationChanges.CombinedSubcontractorsInformation.Rows.Count > 0)
            {
                ProjectCombinedCostingSheetInformationSubcontractorsInformationGateway projectCostingSheetInformationSubcontractorsInformationGateway = new ProjectCombinedCostingSheetInformationSubcontractorsInformationGateway(subcontractorsInformationChanges);

                foreach (ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationRow row in (ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable)subcontractorsInformationChanges.CombinedSubcontractorsInformation)
                {
                    // Insert new costing sheet Subcontractors
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCombinedCostingSheetSubcontractors subcontractors = new ProjectCombinedCostingSheetSubcontractors(null);
                        subcontractors.InsertDirect(costingSheetId, row.SubcontractorID, row.RefID, row.UnitOfMeasurement, row.Quantity, row.CostCad, row.TotalCostCad, row.CostUsd, row.TotalCostUsd, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.Comment, row.ProjectID);
                    }

                    // Update costing sheet Subcontractors
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int subcontractorId = row.SubcontractorID;
                        int refId = row.RefID;
                        bool deleted = false;

                        //original values
                        string originalUnitOfMeasurement = projectCostingSheetInformationSubcontractorsInformationGateway.GetUnitOfMeasurementOriginal(costingSheetId, subcontractorId, refId);
                        double originalQuantity = projectCostingSheetInformationSubcontractorsInformationGateway.GetQuantityOriginal(costingSheetId, subcontractorId, refId);
                        decimal originalCostCad = projectCostingSheetInformationSubcontractorsInformationGateway.GetCostCadOriginal(costingSheetId, subcontractorId, refId);
                        decimal originalTotalCostCad = projectCostingSheetInformationSubcontractorsInformationGateway.GetTotalCostCadOriginal(costingSheetId, subcontractorId, refId);
                        decimal originalCostUsd = projectCostingSheetInformationSubcontractorsInformationGateway.GetCostUsdOriginal(costingSheetId, subcontractorId, refId);
                        decimal originalTotalCostUsd = projectCostingSheetInformationSubcontractorsInformationGateway.GetTotalCostUsdOriginal(costingSheetId, subcontractorId, refId);
                        DateTime originalStartDate = projectCostingSheetInformationSubcontractorsInformationGateway.GetStartDateOriginal(costingSheetId, subcontractorId, refId);
                        DateTime originalEndDate = projectCostingSheetInformationSubcontractorsInformationGateway.GetEndDateOriginal(costingSheetId, subcontractorId, refId);

                        //original values
                        string newUnitOfMeasurement = projectCostingSheetInformationSubcontractorsInformationGateway.GetUnitOfMeasurement(costingSheetId, subcontractorId, refId);
                        double newQuantity = projectCostingSheetInformationSubcontractorsInformationGateway.GetQuantity(costingSheetId, subcontractorId, refId);
                        decimal newCostCad = projectCostingSheetInformationSubcontractorsInformationGateway.GetCostCad(costingSheetId, subcontractorId, refId);
                        decimal newTotalCostCad = projectCostingSheetInformationSubcontractorsInformationGateway.GetTotalCostCad(costingSheetId, subcontractorId, refId);
                        decimal newCostUsd = projectCostingSheetInformationSubcontractorsInformationGateway.GetCostUsd(costingSheetId, subcontractorId, refId);
                        decimal newTotalCostUsd = projectCostingSheetInformationSubcontractorsInformationGateway.GetTotalCostUsd(costingSheetId, subcontractorId, refId);
                        DateTime newStartDate = projectCostingSheetInformationSubcontractorsInformationGateway.GetStartDate(costingSheetId, subcontractorId, refId);
                        DateTime newEndDate = projectCostingSheetInformationSubcontractorsInformationGateway.GetEndDate(costingSheetId, subcontractorId, refId);

                        ProjectCombinedCostingSheetSubcontractors subcontractors = new ProjectCombinedCostingSheetSubcontractors(null);
                        subcontractors.UpdateDirect(costingSheetId, subcontractorId, refId, originalUnitOfMeasurement, originalQuantity, originalCostCad, originalTotalCostCad, originalCostUsd, originalTotalCostUsd, deleted, companyId, originalStartDate, originalEndDate, newUnitOfMeasurement, newQuantity, newCostCad, newTotalCostCad, newCostUsd, newTotalCostUsd, deleted, companyId, newStartDate, newEndDate);
                    }

                    // Delete costing sheet Subcontractors 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        ProjectCombinedCostingSheetSubcontractors subcontractors = new ProjectCombinedCostingSheetSubcontractors(null);
                        subcontractors.DeleteDirect(row.CostingSheetID, row.SubcontractorID, row.RefID, row.COMPANY_ID);
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
        private ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationRow GetRow(int costingSheetId, int subcontractorId, int refId)
        {
            ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationRow row = ((ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable)Table).FindByRefIDSubcontractorIDCostingSheetID(refId, subcontractorId, costingSheetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetInformationCombinedSubcontractorsInformation.GetRow");
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

            foreach (ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationRow row in (ProjectCostingSheetInformationTDS.CombinedSubcontractorsInformationDataTable)Table)
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