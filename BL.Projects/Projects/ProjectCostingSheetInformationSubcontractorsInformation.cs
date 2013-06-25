using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetInformationSubcontractorsInformation
    /// </summary>
    public class ProjectCostingSheetInformationSubcontractorsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetInformationSubcontractorsInformation()
            : base("SubcontractorsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetInformationSubcontractorsInformation(DataSet data)
            : base(data, "SubcontractorsInformation")
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
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="subcontractor">subcontractor</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Insert(int costingSheetId, int subcontractorId, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string subcontractor, DateTime startDate, DateTime endDate, string comment)
        {
            ProjectCostingSheetInformationTDS.SubcontractorsInformationRow row = ((ProjectCostingSheetInformationTDS.SubcontractorsInformationDataTable)Table).NewSubcontractorsInformationRow();

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

            ((ProjectCostingSheetInformationTDS.SubcontractorsInformationDataTable)Table).AddSubcontractorsInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="subcontractor">subcontractor</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Update(int costingSheetId, int subcontractorId, int refId, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string subcontractor, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.SubcontractorsInformationRow row = GetRow(costingSheetId, subcontractorId, refId);

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
            ProjectCostingSheetInformationTDS.SubcontractorsInformationRow row = GetRow(costingSheetId, subcontractorId, refId);
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

            if (subcontractorsInformationChanges.SubcontractorsInformation.Rows.Count > 0)
            {
                ProjectCostingSheetInformationSubcontractorsInformationGateway projectCostingSheetInformationSubcontractorsInformationGateway = new ProjectCostingSheetInformationSubcontractorsInformationGateway(subcontractorsInformationChanges);

                foreach (ProjectCostingSheetInformationTDS.SubcontractorsInformationRow row in (ProjectCostingSheetInformationTDS.SubcontractorsInformationDataTable)subcontractorsInformationChanges.SubcontractorsInformation)
                {
                    // Insert new costing sheet Subcontractors
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCostingSheetSubcontractors subcontractors = new ProjectCostingSheetSubcontractors(null);
                        subcontractors.InsertDirect(costingSheetId, row.SubcontractorID, row.RefID, row.UnitOfMeasurement, row.Quantity, row.CostCad, row.TotalCostCad, row.CostUsd, row.TotalCostUsd, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.Comment);
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

                        ProjectCostingSheetSubcontractors subcontractors = new ProjectCostingSheetSubcontractors(null);
                        subcontractors.UpdateDirect(costingSheetId, subcontractorId, refId, originalUnitOfMeasurement, originalQuantity, originalCostCad, originalTotalCostCad, originalCostUsd, originalTotalCostUsd, deleted, companyId, originalStartDate, originalEndDate, newUnitOfMeasurement, newQuantity, newCostCad, newTotalCostCad, newCostUsd, newTotalCostUsd, deleted, companyId, newStartDate, newEndDate);
                    }

                    // Delete costing sheet Subcontractors 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        ProjectCostingSheetSubcontractors subcontractors = new ProjectCostingSheetSubcontractors(null);
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
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private ProjectCostingSheetInformationTDS.SubcontractorsInformationRow GetRow(int costingSheetId, int subcontractorId, int refId)
        {
            ProjectCostingSheetInformationTDS.SubcontractorsInformationRow row = ((ProjectCostingSheetInformationTDS.SubcontractorsInformationDataTable)Table).FindByRefIDSubcontractorIDCostingSheetID(refId, subcontractorId, costingSheetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetInformationSubcontractorsInformation.GetRow");
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

            foreach (ProjectCostingSheetInformationTDS.SubcontractorsInformationRow row in (ProjectCostingSheetInformationTDS.SubcontractorsInformationDataTable)Table)
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