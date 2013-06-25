using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCombinedCostingSheetInformationMaterialsInformation
    /// </summary>
    public class ProjectCombinedCostingSheetInformationMaterialsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCombinedCostingSheetInformationMaterialsInformation()
            : base("CombinedMaterialsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCombinedCostingSheetInformationMaterialsInformation(DataSet data)
            : base(data, "CombinedMaterialsInformation")
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
        /// <param name="materialId">materialId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="process">process</param>
        /// <param name="description">description</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Insert(int costingSheetId, int materialId, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string process, string description, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.CombinedMaterialsInformationRow row = ((ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable)Table).NewCombinedMaterialsInformationRow();

            row.CostingSheetID = costingSheetId;
            row.MaterialID = materialId;
            row.RefID = GetNewRefId();
            row.UnitOfMeasurement = unitOfMeasurement;
            row.Quantity = quantity;
            row.CostCad = costCad;
            row.TotalCostCad = totalCostCad;
            row.CostUsd = costUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.Process = process;
            row.Description = description;
            row.StartDate = startDate;
            row.EndDate = endDate;

            ((ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable)Table).AddCombinedMaterialsInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="process">process</param>
        /// <param name="description">description</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Update(int costingSheetId, int materialId, int refId, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string process, string description, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.CombinedMaterialsInformationRow row = GetRow(costingSheetId, materialId, refId);

            row.UnitOfMeasurement = unitOfMeasurement;
            row.Quantity = quantity;
            row.CostCad = costCad;
            row.TotalCostCad = totalCostCad;
            row.CostUsd = costUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.Process = process;
            row.Description = description;
            row.StartDate = startDate;
            row.EndDate = endDate;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        public void Delete(int costingSheetId, int materialId, int refId)
        {
            ProjectCostingSheetInformationTDS.CombinedMaterialsInformationRow row = GetRow(costingSheetId, materialId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Materials Costing Sheets
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetInformationTDS materialsInformationChanges = (ProjectCostingSheetInformationTDS)Data.GetChanges();

            if (materialsInformationChanges.CombinedMaterialsInformation.Rows.Count > 0)
            {
                ProjectCombinedCostingSheetInformationMaterialsInformationGateway projectCostingSheetInformationMaterialsInformationGateway = new ProjectCombinedCostingSheetInformationMaterialsInformationGateway(materialsInformationChanges);

                foreach (ProjectCostingSheetInformationTDS.CombinedMaterialsInformationRow row in (ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable)materialsInformationChanges.CombinedMaterialsInformation)
                {
                    // Insert new costing sheet Materials 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCombinedCostingSheetMaterials materials = new ProjectCombinedCostingSheetMaterials(null);
                        materials.InsertDirect(costingSheetId, row.MaterialID, row.RefID, row.UnitOfMeasurement, row.Quantity, row.CostCad, row.TotalCostCad, row.CostUsd, row.TotalCostUsd, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.Function_, row.ProjectID);
                    }

                    // Update costing sheet Materials 
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int materialId = row.MaterialID;
                        int refId = row.RefID;
                        bool deleted = false;

                        //original values
                        string originalUnitOfMeasurement = projectCostingSheetInformationMaterialsInformationGateway.GetUnitOfMeasurementOriginal(costingSheetId, materialId, refId);
                        double originalQuantity = projectCostingSheetInformationMaterialsInformationGateway.GetQuantityOriginal(costingSheetId, materialId, refId);
                        decimal originalCostCad = projectCostingSheetInformationMaterialsInformationGateway.GetCostCadOriginal(costingSheetId, materialId, refId);
                        decimal originalTotalCostCad = projectCostingSheetInformationMaterialsInformationGateway.GetTotalCostCadOriginal(costingSheetId, materialId, refId);
                        decimal originalCostUsd = projectCostingSheetInformationMaterialsInformationGateway.GetCostUsdOriginal(costingSheetId, materialId, refId);
                        decimal originalTotalCostUsd = projectCostingSheetInformationMaterialsInformationGateway.GetTotalCostUsdOriginal(costingSheetId, materialId, refId);
                        DateTime originalStartDate = projectCostingSheetInformationMaterialsInformationGateway.GetStartDateOriginal(costingSheetId, materialId, refId);
                        DateTime originalEndDate = projectCostingSheetInformationMaterialsInformationGateway.GetEndDateOriginal(costingSheetId, materialId, refId);
                        string originalFunction_ = projectCostingSheetInformationMaterialsInformationGateway.GetFunction_Original(costingSheetId, materialId, refId);

                        //original values
                        string newUnitOfMeasurement = projectCostingSheetInformationMaterialsInformationGateway.GetUnitOfMeasurement(costingSheetId, materialId, refId);
                        double newQuantity = projectCostingSheetInformationMaterialsInformationGateway.GetQuantity(costingSheetId, materialId, refId);
                        decimal newCostCad = projectCostingSheetInformationMaterialsInformationGateway.GetCostCad(costingSheetId, materialId, refId);
                        decimal newTotalCostCad = projectCostingSheetInformationMaterialsInformationGateway.GetTotalCostCad(costingSheetId, materialId, refId);
                        decimal newCostUsd = projectCostingSheetInformationMaterialsInformationGateway.GetCostUsd(costingSheetId, materialId, refId);
                        decimal newTotalCostUsd = projectCostingSheetInformationMaterialsInformationGateway.GetTotalCostUsd(costingSheetId, materialId, refId);
                        DateTime newStartDate = projectCostingSheetInformationMaterialsInformationGateway.GetStartDate(costingSheetId, materialId, refId);
                        DateTime newEndDate = projectCostingSheetInformationMaterialsInformationGateway.GetEndDate(costingSheetId, materialId, refId);
                        string newFunction_ = projectCostingSheetInformationMaterialsInformationGateway.GetFunction_(costingSheetId, materialId, refId);

                        ProjectCombinedCostingSheetMaterials materials = new ProjectCombinedCostingSheetMaterials(null);
                        materials.UpdateDirect(costingSheetId, materialId, refId, originalUnitOfMeasurement, originalQuantity, originalCostCad, originalTotalCostCad, originalCostUsd, originalTotalCostUsd, deleted, companyId, originalStartDate, originalEndDate, originalFunction_, newUnitOfMeasurement, newQuantity, newCostCad, newTotalCostCad, newCostUsd, newTotalCostUsd, deleted, companyId, newStartDate, newEndDate, newFunction_);
                    }

                    // Delete costing sheet Materials  
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        ProjectCombinedCostingSheetMaterials materials = new ProjectCombinedCostingSheetMaterials(null);
                        materials.DeleteDirect(costingSheetId, row.MaterialID, row.RefID, row.COMPANY_ID);
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
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private ProjectCostingSheetInformationTDS.CombinedMaterialsInformationRow GetRow(int costingSheetId, int materialId, int refId)
        {
            ProjectCostingSheetInformationTDS.CombinedMaterialsInformationRow row = ((ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable)Table).FindByCostingSheetIDMaterialIDRefID(costingSheetId, materialId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCombinedCostingSheetInformationMaterialsInformation.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>newRefId</returns>
        private int GetNewRefId()
        {
            int newRefId = 0;

            foreach (ProjectCostingSheetInformationTDS.CombinedMaterialsInformationRow row in (ProjectCostingSheetInformationTDS.CombinedMaterialsInformationDataTable)Table)
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