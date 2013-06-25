using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetLabourHours
    /// </summary>
    public class ProjectCostingSheetLabourHours : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetLabourHours()
            : base("LFS_PROJECT_COSTING_SHEET_LABOUR_HOURS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetLabourHours(DataSet data)
            : base(data, "LFS_PROJECT_COSTING_SHEET_LABOUR_HOURS")
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
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <param name="lHQuantity">lHQuantity</param>
        /// <param name="lHUnitOfMeasurement">lHUnitOfMeasurement</param>
        /// <param name="mealsUnitOfMeasurement">mealsUnitOfMeasurement</param>
        /// <param name="mealsQuantity">mealsQuantity</param>
        /// <param name="motelUnitOfMeasurement">motelUnitOfMeasurement</param>
        /// <param name="motelQuantity">motelQuantity</param>
        /// <param name="lHCostCad">lHCostCad</param>
        /// <param name="mealsCostCad">mealsCostCad</param>
        /// <param name="motelCostCad">motelCostCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="lHCostUsd">lHCostUsd</param>
        /// <param name="mealsCostUsd">mealsCostUsd</param>
        /// <param name="motelCostUsd">motelCostUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="function_">function_</param>
        public void InsertDirect(int costingSheetId, string work_, int employeeId, int refId, double lHQuantity, string lHUnitOfMeasurement, string mealsUnitOfMeasurement, int? mealsQuantity, string motelUnitOfMeasurement, int? motelQuantity, decimal lHCostCad, decimal? mealsCostCad, decimal? motelCostCad, decimal totalCostCad, decimal lHCostUsd, decimal? mealsCostUsd, decimal? motelCostUsd, decimal totalCostUsd, bool deleted, int companyId, DateTime startDate, DateTime endDate, string function_)
        {
            // Insert costing sheet LH
            ProjectCostingSheetLabourHoursGateway projectCostingSheetLabourHoursGateway = new ProjectCostingSheetLabourHoursGateway(null);
            projectCostingSheetLabourHoursGateway.Insert(costingSheetId, work_, employeeId, refId, lHQuantity, lHUnitOfMeasurement, mealsUnitOfMeasurement, mealsQuantity, motelUnitOfMeasurement, motelQuantity, lHCostCad, mealsCostCad, motelCostCad, totalCostCad, lHCostUsd, mealsCostUsd, motelCostUsd, totalCostUsd, deleted, companyId, startDate, endDate, function_);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <param name="originalWork_">originalWork_</param>
        /// <param name="originalLHQuantity">originalLHQuantity</param>
        /// <param name="originalLHUnitOfMeasurement">originalLHUnitOfMeasurement</param>
        /// <param name="originalMealsUnitOfMeasurement">originalMealsUnitOfMeasurement</param>
        /// <param name="originalMealsQuantity">originalMealsQuantity</param>
        /// <param name="originalMotelUnitOfMeasurement">originalMotelUnitOfMeasurement</param>
        /// <param name="originalMotelQuantity">originalMotelQuantity</param>
        /// <param name="originalLHCostCad">originalLHCostCad</param>
        /// <param name="originalMealsCostCad">originalMealsCostCad</param>
        /// <param name="originalMotelCostCad">originalMotelCostCad</param>
        /// <param name="originalTotalCostCad">originalTotalCostCad</param>
        /// <param name="originalLHCostUsd">originalLHCostUsd</param>
        /// <param name="originalMealsCostUsd">originalMealsCostUsd</param>
        /// <param name="originalMotelCostUsd">originalMotelCostUsd</param>
        /// <param name="originalTotalCostUsd">originalTotalCostUsd</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalStartDate">originalStartDate</param>
        /// <param name="originalEndDate">originalEndDate</param>
        /// <param name="originalFunction_">originalFunction_</param>
        /// 
        /// <param name="newWork_">newWork_</param>
        /// <param name="newLHQuantity">newLHQuantity</param>
        /// <param name="newLHUnitOfMeasurement">newLHUnitOfMeasurement</param>
        /// <param name="newMealsUnitOfMeasurement">newMealsUnitOfMeasurement</param>
        /// <param name="newMealsQuantity">newMealsQuantity</param>
        /// <param name="newMotelUnitOfMeasurement">newMotelUnitOfMeasurement</param>
        /// <param name="newMotelQuantity">newMotelQuantity</param>
        /// <param name="newLHCostCad">newLHCostCad</param>
        /// <param name="newMealsCostCad">newMealsCostCad</param>
        /// <param name="newMotelCostCad">newMotelCostCad</param>
        /// <param name="newTotalCostCad">newTotalCostCad</param>
        /// <param name="newLHCostUsd">newLHCostUsd</param>
        /// <param name="newMealsCostUsd">newMealsCostUsd</param>
        /// <param name="newMotelCostUsd">newMotelCostUsd</param>
        /// <param name="newTotalCostUsd">newTotalCostUsd</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newStartDate">newStartDate</param>
        /// <param name="newEndDate">newEndDate</param>
        /// <param name="newFunction_">newFunction_</param>
        public void UpdateDirect(int costingSheetId, int employeeId, int refId, string originalWork_, double originalLHQuantity, string originalLHUnitOfMeasurement, string originalMealsUnitOfMeasurement, int? originalMealsQuantity, string originalMotelUnitOfMeasurement, int? originalMotelQuantity, decimal originalLHCostCad, decimal? originalMealsCostCad, decimal? originalMotelCostCad, decimal originalTotalCostCad, decimal originalLHCostUsd, decimal? originalMealsCostUsd, decimal? originalMotelCostUsd, decimal originalTotalCostUsd, bool originalDeleted, int originalCompanyId, DateTime originalStartDate, DateTime originalEndDate, string originalFunction_, string newWork_, double newLHQuantity, string newLHUnitOfMeasurement, string newMealsUnitOfMeasurement, int? newMealsQuantity, string newMotelUnitOfMeasurement, int? newMotelQuantity, decimal newLHCostCad, decimal? newMealsCostCad, decimal? newMotelCostCad, decimal newTotalCostCad, decimal newLHCostUsd, decimal? newMealsCostUsd, decimal? newMotelCostUsd, decimal newTotalCostUsd, bool newDeleted, int newCompanyId, DateTime newStartDate, DateTime newEndDate, string newFunction_)
        {
            ProjectCostingSheetLabourHoursGateway projectCostingSheetLabourHoursGateway = new ProjectCostingSheetLabourHoursGateway(null);
            projectCostingSheetLabourHoursGateway.Update(costingSheetId, employeeId, refId, originalWork_, originalLHQuantity, originalLHUnitOfMeasurement, originalMealsUnitOfMeasurement, originalMealsQuantity, originalMotelUnitOfMeasurement, originalMotelQuantity, originalLHCostCad, originalMealsCostCad, originalMotelCostCad, originalTotalCostCad, originalLHCostUsd, originalMealsCostUsd, originalMotelCostUsd, originalTotalCostUsd, originalDeleted, originalCompanyId, originalStartDate, originalEndDate, originalFunction_, newWork_, newLHQuantity, newLHUnitOfMeasurement, newMealsUnitOfMeasurement, newMealsQuantity, newMotelUnitOfMeasurement, newMotelQuantity, newLHCostCad, newMealsCostCad, newMotelCostCad, newTotalCostCad, newLHCostUsd, newMealsCostUsd, newMotelCostUsd, newTotalCostUsd, newDeleted, newCompanyId, newStartDate, newEndDate, newFunction_);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int costingSheetId, int companyId)
        {
            ProjectCostingSheetLabourHoursGateway projectCostingSheetLabourHoursGateway = new ProjectCostingSheetLabourHoursGateway(null);
            projectCostingSheetLabourHoursGateway.DeleteAll(costingSheetId, companyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int costingSheetId, string work_, int employeeId, int refId, int companyId)
        {
            ProjectCostingSheetLabourHoursGateway projectCostingSheetLabourHoursGateway = new ProjectCostingSheetLabourHoursGateway(null);
            projectCostingSheetLabourHoursGateway.Delete(costingSheetId, work_, employeeId, refId, companyId);
        }



    }
}