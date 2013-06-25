using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetInformationUnitsInformation
    /// </summary>
    public class ProjectCostingSheetInformationUnitsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetInformationUnitsInformation()
            : base("UnitsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetInformationUnitsInformation(DataSet data)
            : base(data, "UnitsInformation")
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
        public void Insert(int costingSheetId, string work_, int unitId, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string unitCode, string unitDescription, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.UnitsInformationRow row = ((ProjectCostingSheetInformationTDS.UnitsInformationDataTable)Table).NewUnitsInformationRow();

            row.CostingSheetID = costingSheetId;
            row.Work_ = work_;
            row.UnitID = unitId;
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
            row.UnitCode = unitCode;
            row.UnitDescription = unitDescription;
            row.InDatabase = false;
            row.StartDate = startDate;
            row.EndDate = endDate;

            ((ProjectCostingSheetInformationTDS.UnitsInformationDataTable)Table).AddUnitsInformationRow(row);
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
        public void Update(int costingSheetId, string work_, int unitId, int refId, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string unitCode, string unitDescription, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.UnitsInformationRow row = GetRow(costingSheetId, work_, unitId, refId);

            row.CostingSheetID = costingSheetId;
            row.Work_ = work_;
            row.UnitID = unitId;
            row.Quantity = quantity;
            row.UnitOfMeasurement = unitOfMeasurement;
            row.CostCad = costCad;
            row.TotalCostCad = totalCostCad;
            row.CostUsd = costUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.UnitCode = unitCode;
            row.UnitDescription = unitDescription;
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
        public void Delete(int costingSheetId, string work_, int unitId, int refId)
        {
            ProjectCostingSheetInformationTDS.UnitsInformationRow row = GetRow(costingSheetId, work_, unitId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Units Costing Sheets
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetInformationTDS unitsInformationChanges = (ProjectCostingSheetInformationTDS)Data.GetChanges();

            if (unitsInformationChanges.UnitsInformation.Rows.Count > 0)
            {
                ProjectCostingSheetInformationUnitsInformationGateway projectCostingSheetInformationUnitsInformationGateway = new ProjectCostingSheetInformationUnitsInformationGateway(unitsInformationChanges);

                foreach (ProjectCostingSheetInformationTDS.UnitsInformationRow row in (ProjectCostingSheetInformationTDS.UnitsInformationDataTable)unitsInformationChanges.UnitsInformation)
                {
                    // Insert new costing sheet Units
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCostingSheetUnits units = new ProjectCostingSheetUnits(null);
                        units.InsertDirect(costingSheetId, row.Work_, row.UnitID, row.RefID, row.UnitOfMeasurement, row.Quantity, row.CostCad, row.TotalCostCad, row.CostUsd, row.TotalCostUsd, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.Function_);
                    }

                    // Update costing sheet Units
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        string work_ = row.Work_;
                        int unitId = row.UnitID;
                        int refId = row.RefID;
                        bool deleted = false;

                        //original values
                        string originalUnitOfMeasurement = projectCostingSheetInformationUnitsInformationGateway.GetUnitOfMeasurementOriginal(costingSheetId, work_, unitId, refId);
                        double originalQuantity = projectCostingSheetInformationUnitsInformationGateway.GetQuantityOriginal(costingSheetId, work_, unitId, refId);
                        decimal originalCostCad = projectCostingSheetInformationUnitsInformationGateway.GetCostCadOriginal(costingSheetId, work_, unitId, refId);
                        decimal originalTotalCostCad = projectCostingSheetInformationUnitsInformationGateway.GetTotalCostCadOriginal(costingSheetId, work_, unitId, refId);
                        decimal originalCostUsd = projectCostingSheetInformationUnitsInformationGateway.GetCostUsdOriginal(costingSheetId, work_, unitId, refId);
                        decimal originalTotalCostUsd = projectCostingSheetInformationUnitsInformationGateway.GetTotalCostUsdOriginal(costingSheetId, work_, unitId, refId);
                        DateTime originalStartDate = projectCostingSheetInformationUnitsInformationGateway.GetStartDateOriginal(costingSheetId, work_, unitId, refId);
                        DateTime originalEndDate = projectCostingSheetInformationUnitsInformationGateway.GetEndDateOriginal(costingSheetId, work_, unitId, refId);
                        string originalFunction_ = projectCostingSheetInformationUnitsInformationGateway.GetFunction_Original(costingSheetId, work_, unitId, refId);

                        //original values
                        string newUnitOfMeasurement = projectCostingSheetInformationUnitsInformationGateway.GetUnitOfMeasurement(costingSheetId, work_, unitId, refId);
                        double newQuantity = projectCostingSheetInformationUnitsInformationGateway.GetQuantity(costingSheetId, work_, unitId, refId);
                        decimal newCostCad = projectCostingSheetInformationUnitsInformationGateway.GetCostCad(costingSheetId, work_, unitId, refId);
                        decimal newTotalCostCad = projectCostingSheetInformationUnitsInformationGateway.GetTotalCostCad(costingSheetId, work_, unitId, refId);
                        decimal newCostUsd = projectCostingSheetInformationUnitsInformationGateway.GetCostUsd(costingSheetId, work_, unitId, refId);
                        decimal newTotalCostUsd = projectCostingSheetInformationUnitsInformationGateway.GetTotalCostUsd(costingSheetId, work_, unitId, refId);
                        DateTime newStartDate = projectCostingSheetInformationUnitsInformationGateway.GetStartDate(costingSheetId, work_, unitId, refId);
                        DateTime newEndDate = projectCostingSheetInformationUnitsInformationGateway.GetEndDate(costingSheetId, work_, unitId, refId);
                        string newFunction_ = projectCostingSheetInformationUnitsInformationGateway.GetFunction_(costingSheetId, work_, unitId, refId);

                        ProjectCostingSheetUnits units = new ProjectCostingSheetUnits(null);
                        units.UpdateDirect(costingSheetId, work_, unitId, refId, originalUnitOfMeasurement, originalQuantity, originalCostCad, originalTotalCostCad, originalCostUsd, originalTotalCostUsd, deleted, companyId, originalStartDate, originalEndDate, originalFunction_, newUnitOfMeasurement, newQuantity, newCostCad, newTotalCostCad, newCostUsd, newTotalCostUsd, deleted, companyId, newStartDate, newEndDate, newFunction_);
                    }

                    // Delete costing sheet Units 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        ProjectCostingSheetUnits units = new ProjectCostingSheetUnits(null);
                        units.DeleteDirect(row.CostingSheetID, row.Work_, row.UnitID, row.RefID, row.COMPANY_ID);
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
        private ProjectCostingSheetInformationTDS.UnitsInformationRow GetRow(int costingSheetId, string work_, int unitId, int refId)
        {
            ProjectCostingSheetInformationTDS.UnitsInformationRow row = ((ProjectCostingSheetInformationTDS.UnitsInformationDataTable)Table).FindByRefIDUnitIDWork_CostingSheetID(refId, unitId, work_, costingSheetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetInformationUnitsInformation.GetRow");
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

            foreach (ProjectCostingSheetInformationTDS.UnitsInformationRow row in (ProjectCostingSheetInformationTDS.UnitsInformationDataTable)Table)
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