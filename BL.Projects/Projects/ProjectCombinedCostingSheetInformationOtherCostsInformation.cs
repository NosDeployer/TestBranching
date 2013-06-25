using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCombinedCostingSheetInformationOtherCostsInformation
    /// </summary>
    public class ProjectCombinedCostingSheetInformationOtherCostsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCombinedCostingSheetInformationOtherCostsInformation()
            : base("CombinedOtherCostsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCombinedCostingSheetInformationOtherCostsInformation(DataSet data)
            : base(data, "CombinedOtherCostsInformation")
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
        /// <param name="function_">function_</param>
        /// <param name="description">description</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workFunction">workFunction</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Insert(int costingSheetId, string work_, string function_, string description, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string workFunction, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationRow row = ((ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)Table).NewCombinedOtherCostsInformationRow();

            row.CostingSheetID = costingSheetId;
            row.RefID = GetNewRefId();
            row.Work_ = work_;
            row.Function_ = function_;
            row.Description = description;
            row.UnitOfMeasurement = unitOfMeasurement;
            row.Quantity = quantity;
            row.CostCad = costCad;
            row.TotalCostCad = totalCostCad;
            row.CostUsd = costUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.WorkFunction = workFunction;
            row.StartDate = startDate;
            row.EndDate = endDate;
            
            ((ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)Table).AddCombinedOtherCostsInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="description">description</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workFunction">workFunction</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Update(int costingSheetId, int refId, string work_, string function_, string description, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string workFunction, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationRow row = GetRow(costingSheetId, refId);

            row.Work_ = work_;
            row.Function_ = function_;
            row.Description = description;
            row.UnitOfMeasurement = unitOfMeasurement;
            row.Quantity = quantity;
            row.CostCad = costCad;
            row.TotalCostCad = totalCostCad;
            row.CostUsd = costUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.WorkFunction = workFunction;
            row.StartDate = startDate;
            row.EndDate = endDate;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        public void Delete(int costingSheetId, int refId)
        {
            ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationRow row = GetRow(costingSheetId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Other Costs Costing Sheet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetInformationTDS otherCostsInformationChanges = (ProjectCostingSheetInformationTDS)Data.GetChanges();

            if (otherCostsInformationChanges.CombinedOtherCostsInformation.Rows.Count > 0)
            {
                ProjectCombinedCostingSheetInformationOtherCostsInformationGateway projectCostingSheetInformationOtherCostsInformationGateway = new ProjectCombinedCostingSheetInformationOtherCostsInformationGateway(otherCostsInformationChanges);

                foreach (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationRow row in (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)otherCostsInformationChanges.CombinedOtherCostsInformation)
                {
                    // Insert new costing sheet Other Costs 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCombinedCostingSheetOtherCosts otherCosts = new ProjectCombinedCostingSheetOtherCosts(null);
                        otherCosts.InsertDirect(costingSheetId, row.RefID, row.Work_, row.Function_, row.Description, row.UnitOfMeasurement, row.Quantity, row.CostCad, row.TotalCostCad, row.CostUsd, row.TotalCostUsd, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.ProjectID);
                    }

                    // Update costing sheet Other Costs 
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int refId = row.RefID;
                        bool deleted = false;

                        //original values
                        string originalWork_ = projectCostingSheetInformationOtherCostsInformationGateway.GetWork_Original(costingSheetId, refId);
                        string originalFunction = projectCostingSheetInformationOtherCostsInformationGateway.GetFunction_Original(costingSheetId, refId);
                        string originalDescription = projectCostingSheetInformationOtherCostsInformationGateway.GetDescriptionOriginal(costingSheetId, refId);
                        string originalUnitOfMeasurement = projectCostingSheetInformationOtherCostsInformationGateway.GetUnitOfMeasurementOriginal(costingSheetId, refId);
                        double originalQuantity = projectCostingSheetInformationOtherCostsInformationGateway.GetQuantityOriginal(costingSheetId, refId);
                        decimal originalCostCad = projectCostingSheetInformationOtherCostsInformationGateway.GetCostCadOriginal(costingSheetId, refId);
                        decimal originalTotalCostCad = projectCostingSheetInformationOtherCostsInformationGateway.GetTotalCostCadOriginal(costingSheetId, refId);
                        decimal originalCostUsd = projectCostingSheetInformationOtherCostsInformationGateway.GetCostUsdOriginal(costingSheetId, refId);
                        decimal originalTotalCostUsd = projectCostingSheetInformationOtherCostsInformationGateway.GetTotalCostUsdOriginal(costingSheetId, refId);
                        DateTime originalStartDate = projectCostingSheetInformationOtherCostsInformationGateway.GetStartDateOriginal(costingSheetId, refId);
                        DateTime originalEndDate = projectCostingSheetInformationOtherCostsInformationGateway.GetEndDateOriginal(costingSheetId, refId);

                        //original values
                        string newWork_ = projectCostingSheetInformationOtherCostsInformationGateway.GetWork_(costingSheetId, refId);
                        string newFunction = projectCostingSheetInformationOtherCostsInformationGateway.GetFunction_(costingSheetId, refId);
                        string newDescription = projectCostingSheetInformationOtherCostsInformationGateway.GetDescription(costingSheetId, refId);
                        string newUnitOfMeasurement = projectCostingSheetInformationOtherCostsInformationGateway.GetUnitOfMeasurement(costingSheetId, refId);
                        double newQuantity = projectCostingSheetInformationOtherCostsInformationGateway.GetQuantity(costingSheetId, refId);
                        decimal newCostCad = projectCostingSheetInformationOtherCostsInformationGateway.GetCostCad(costingSheetId, refId);
                        decimal newTotalCostCad = projectCostingSheetInformationOtherCostsInformationGateway.GetTotalCostCad(costingSheetId, refId);
                        decimal newCostUsd = projectCostingSheetInformationOtherCostsInformationGateway.GetCostUsd(costingSheetId, refId);
                        decimal newTotalCostUsd = projectCostingSheetInformationOtherCostsInformationGateway.GetTotalCostUsd(costingSheetId, refId);
                        DateTime newStartDate = projectCostingSheetInformationOtherCostsInformationGateway.GetStartDate(costingSheetId, refId);
                        DateTime newEndDate = projectCostingSheetInformationOtherCostsInformationGateway.GetEndDate(costingSheetId, refId);

                        ProjectCombinedCostingSheetOtherCosts otherCosts = new ProjectCombinedCostingSheetOtherCosts(null);
                        otherCosts.UpdateDirect(costingSheetId, refId, originalWork_, originalFunction, originalDescription, originalUnitOfMeasurement, originalQuantity, originalCostCad, originalTotalCostCad, originalCostUsd, originalTotalCostUsd, deleted, companyId, originalStartDate, originalEndDate, newWork_, newFunction, newDescription, newUnitOfMeasurement, newQuantity, newCostCad, newTotalCostCad, newCostUsd, newTotalCostUsd, deleted, companyId, newStartDate, newEndDate); 
                    }

                    // Delete costing sheet Other Costs  
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        ProjectCombinedCostingSheetOtherCosts otherCosts = new ProjectCombinedCostingSheetOtherCosts(null);
                        otherCosts.DeleteDirect(row.CostingSheetID, row.RefID, row.COMPANY_ID);
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
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationRow GetRow(int costingSheetId, int refId)
        {
            ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationRow row = ((ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)Table).FindByCostingSheetIDRefID(costingSheetId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCombinedCostingSheetInformationOtherCostsInformation.GetRow");
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

            foreach (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationRow row in (ProjectCostingSheetInformationTDS.CombinedOtherCostsInformationDataTable)Table)
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