using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetInformationLabourHoursInformation
    /// </summary>
    public class ProjectCostingSheetInformationLabourHoursInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetInformationLabourHoursInformation()
            : base("LabourHoursInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetInformationLabourHoursInformation(DataSet data)
            : base(data, "LabourHoursInformation")
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
        /// <param name="employeeId">employeeId</param>
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
        /// <param name="name">name</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Insert(int costingSheetId, string work_, int employeeId, double lHQuantity, string lHUnitOfMeasurement, string mealsUnitOfMeasurement, int? mealsQuantity, string motelUnitOfMeasurement, int? motelQuantity, decimal lHCostCad, decimal? mealsCostCad, decimal? motelCostCad, decimal totalCostCad, decimal lHCostUsd, decimal? mealsCostUsd, decimal? motelCostUsd, decimal totalCostUsd, bool deleted, int companyId, string name, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.LabourHoursInformationRow row = ((ProjectCostingSheetInformationTDS.LabourHoursInformationDataTable)Table).NewLabourHoursInformationRow();

            row.CostingSheetID = costingSheetId;
            row.Work_ = work_;
            row.EmployeeID = employeeId;
            row.RefID = GetNewRefId();
            row.LHQuantity = lHQuantity;
            row.LHUnitOfMeasurement = lHUnitOfMeasurement;
            row.MealsUnitOfMeasurement = mealsUnitOfMeasurement.Trim();
            if (mealsQuantity.HasValue) row.MealsQuantity = mealsQuantity.Value ; else row.SetMealsQuantityNull();
            row.MotelUnitOfMeasurement = motelUnitOfMeasurement.Trim();
            if (motelQuantity.HasValue) row.MotelQuantity = motelQuantity.Value; else row.SetMotelQuantityNull();
            row.LHCostCad = lHCostCad;
            if (mealsCostCad.HasValue) row.MealsCostCad = mealsCostCad.Value; else row.SetMealsCostCadNull();
            if (motelCostCad.HasValue) row.MotelCostCad = motelCostCad.Value; else row.SetMotelCostCadNull();
            row.TotalCostCad = totalCostCad;
            row.LHCostUsd = lHCostUsd;
            if (mealsCostUsd.HasValue) row.MealsCostUsd = mealsCostUsd.Value; else row.SetMealsCostUsdNull();
            if (motelCostUsd.HasValue) row.MotelCostUsd = motelCostUsd.Value; else row.SetMotelCostUsdNull();
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.Name = name;
            row.StartDate = startDate;
            row.EndDate = endDate;

            ((ProjectCostingSheetInformationTDS.LabourHoursInformationDataTable)Table).AddLabourHoursInformationRow(row);
        }



        /// <summary>
        /// Update
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
        /// <param name="name">name</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Update(int costingSheetId, string work_, int employeeId, int refId, double lHQuantity, string lHUnitOfMeasurement, string mealsUnitOfMeasurement, int? mealsQuantity, string motelUnitOfMeasurement, int? motelQuantity, decimal lHCostCad, decimal? mealsCostCad, decimal? motelCostCad, decimal totalCostCad, decimal lHCostUsd, decimal? mealsCostUsd, decimal? motelCostUsd, decimal totalCostUsd, bool deleted, int companyId, string name, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.LabourHoursInformationRow row = GetRow(costingSheetId, work_, employeeId, refId);

            row.LHQuantity = lHQuantity;
            row.LHUnitOfMeasurement = lHUnitOfMeasurement;
            row.MealsUnitOfMeasurement = mealsUnitOfMeasurement.Trim();
            if (mealsQuantity.HasValue) row.MealsQuantity = mealsQuantity.Value; else row.SetMealsQuantityNull();
            row.MotelUnitOfMeasurement = motelUnitOfMeasurement.Trim();
            if (motelQuantity.HasValue) row.MotelQuantity = motelQuantity.Value; else row.SetMotelQuantityNull();
            row.LHCostCad = lHCostCad;
            if (mealsCostCad.HasValue) row.MealsCostCad = mealsCostCad.Value; else row.SetMealsCostCadNull();
            if (motelCostCad.HasValue) row.MotelCostCad = motelCostCad.Value; else row.SetMotelCostCadNull();
            row.TotalCostCad = totalCostCad;
            row.LHCostUsd = lHCostUsd;
            if (mealsCostUsd.HasValue) row.MealsCostUsd = mealsCostUsd.Value; else row.SetMealsCostUsdNull();
            if (motelCostUsd.HasValue) row.MotelCostUsd = motelCostUsd.Value; else row.SetMotelCostUsdNull();
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.Name = name; 
            row.StartDate = startDate;
            row.EndDate = endDate;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        public void Delete(int costingSheetId, string work_, int employeeId, int refId)
        {
            ProjectCostingSheetInformationTDS.LabourHoursInformationRow row = GetRow(costingSheetId, work_, employeeId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all LH Costing Sheets
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetInformationTDS labourHourInformationChanges = (ProjectCostingSheetInformationTDS)Data.GetChanges();

            if (labourHourInformationChanges.LabourHoursInformation.Rows.Count > 0)
            {
                ProjectCostingSheetInformationLabourHoursInformationGateway projectCostingSheetInformationLabourHoursInformationGateway = new ProjectCostingSheetInformationLabourHoursInformationGateway(labourHourInformationChanges);

                foreach (ProjectCostingSheetInformationTDS.LabourHoursInformationRow row in (ProjectCostingSheetInformationTDS.LabourHoursInformationDataTable)labourHourInformationChanges.LabourHoursInformation)
                {
                    // Insert new costing sheet Labour Hours 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        int? mealsQuantity = null; if (!row.IsMealsQuantityNull()) mealsQuantity = row.MealsQuantity;
                        int? motelQuantity = null; if (!row.IsMotelQuantityNull()) motelQuantity = row.MotelQuantity;
                        decimal? measlCostCad = null; if (!row.IsMealsCostCadNull()) measlCostCad = row.MealsCostCad;
                        decimal? motelCostCad = null; if (!row.IsMotelCostCadNull()) motelCostCad = row.MotelCostCad;
                        decimal? measlCostUsd = null; if (!row.IsMealsCostUsdNull()) measlCostUsd = row.MealsCostUsd;
                        decimal? motelCostUsd = null; if (!row.IsMotelCostUsdNull()) motelCostUsd = row.MotelCostUsd;
                       
                        ProjectCostingSheetLabourHours labourHours = new ProjectCostingSheetLabourHours(null);
                        labourHours.InsertDirect(costingSheetId, row.Work_, row.EmployeeID, row.RefID, row.LHQuantity, row.LHUnitOfMeasurement, row.MealsUnitOfMeasurement, mealsQuantity, row.MotelUnitOfMeasurement, motelQuantity, row.LHCostCad, measlCostCad, motelCostCad, row.TotalCostCad, row.LHCostUsd, measlCostUsd, motelCostUsd, row.TotalCostUsd, false, companyId, row.StartDate, row.EndDate, row.Function_);
                    }

                    // Update costing sheet Labour Hours 
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        string work_ = row.Work_;
                        int employeeId = row.EmployeeID;
                        int refId = row.RefID;
                        bool deleted = false;

                        //original values
                        string originalLHUnitOfMeasurement = projectCostingSheetInformationLabourHoursInformationGateway.GetLHUnitOfMeasurementOriginal(costingSheetId, work_, employeeId, refId);
                        double originalLHQuantity = projectCostingSheetInformationLabourHoursInformationGateway.GetLHQuantityOriginal(costingSheetId, work_, employeeId, refId);
                        string originalMealsUnitOfMeasurement = projectCostingSheetInformationLabourHoursInformationGateway.GetMealsUnitOfMeasurementOriginal(costingSheetId, work_, employeeId, refId);
                        int? originalMealsQuantity = null; if (projectCostingSheetInformationLabourHoursInformationGateway.GetMealsQuantityOriginal(costingSheetId, work_, employeeId, refId).HasValue) originalMealsQuantity = projectCostingSheetInformationLabourHoursInformationGateway.GetMealsQuantityOriginal(costingSheetId, work_, employeeId, refId).Value;
                        string originalMotelUnitOfMeasurement = projectCostingSheetInformationLabourHoursInformationGateway.GetMotelUnitOfMeasurementOriginal(costingSheetId, work_, employeeId, refId);
                        int? originalMotelQuantity = null; if (projectCostingSheetInformationLabourHoursInformationGateway.GetMotelQuantityOriginal(costingSheetId, work_, employeeId, refId).HasValue) originalMotelQuantity = projectCostingSheetInformationLabourHoursInformationGateway.GetMotelQuantityOriginal(costingSheetId, work_, employeeId, refId).Value;
                        decimal originalLHCostCad = projectCostingSheetInformationLabourHoursInformationGateway.GetLHCostCadOriginal(costingSheetId, work_, employeeId, refId);
                        decimal? originalMealsCostCad = null; if (projectCostingSheetInformationLabourHoursInformationGateway.GetMealsCostCadOriginal(costingSheetId, work_, employeeId, refId).HasValue) originalMealsCostCad = projectCostingSheetInformationLabourHoursInformationGateway.GetMealsCostCadOriginal(costingSheetId, work_, employeeId, refId);
                        decimal? originalMotelCostCad = null; if (projectCostingSheetInformationLabourHoursInformationGateway.GetMotelCostCadOriginal(costingSheetId, work_, employeeId, refId).HasValue) originalMotelCostCad = projectCostingSheetInformationLabourHoursInformationGateway.GetMotelCostCadOriginal(costingSheetId, work_, employeeId, refId);
                        decimal originalTotalCostCad = projectCostingSheetInformationLabourHoursInformationGateway.GetTotalCostCadOriginal(costingSheetId, work_, employeeId, refId);
                        decimal originalLHCostUsd = projectCostingSheetInformationLabourHoursInformationGateway.GetLHCostUsdOriginal(costingSheetId, work_, employeeId, refId);
                        decimal? originalMealsCostUsd = null; if (projectCostingSheetInformationLabourHoursInformationGateway.GetMealsCostUsdOriginal(costingSheetId, work_, employeeId, refId).HasValue) originalMealsCostUsd = projectCostingSheetInformationLabourHoursInformationGateway.GetMealsCostUsdOriginal(costingSheetId, work_, employeeId, refId);
                        decimal? originalMotelCostUsd = null; if (projectCostingSheetInformationLabourHoursInformationGateway.GetMotelCostUsdOriginal(costingSheetId, work_, employeeId, refId).HasValue) originalMotelCostUsd = projectCostingSheetInformationLabourHoursInformationGateway.GetMotelCostUsdOriginal(costingSheetId, work_, employeeId, refId);
                        decimal originalTotalCostUsd = projectCostingSheetInformationLabourHoursInformationGateway.GetTotalCostUsdOriginal(costingSheetId, work_, employeeId, refId);
                        DateTime originalStartDate = projectCostingSheetInformationLabourHoursInformationGateway.GetStartDateOriginal(costingSheetId, work_, employeeId, refId);
                        DateTime originalEndDate = projectCostingSheetInformationLabourHoursInformationGateway.GetEndDateOriginal(costingSheetId, work_, employeeId, refId);
                        string originalFunction_ = projectCostingSheetInformationLabourHoursInformationGateway.GetFunction_Original(costingSheetId, work_, employeeId, refId);

                        //original values
                        string newLHUnitOfMeasurement = projectCostingSheetInformationLabourHoursInformationGateway.GetLHUnitOfMeasurement(costingSheetId, work_, employeeId, refId);
                        double newLHQuantity = projectCostingSheetInformationLabourHoursInformationGateway.GetLHQuantity(costingSheetId, work_, employeeId, refId);
                        string newMealsUnitOfMeasurement = projectCostingSheetInformationLabourHoursInformationGateway.GetMealsUnitOfMeasurement(costingSheetId, work_, employeeId, refId);
                        int? newMealsQuantity = null; if (projectCostingSheetInformationLabourHoursInformationGateway.GetMealsQuantity(costingSheetId, work_, employeeId, refId).HasValue) newMealsQuantity = projectCostingSheetInformationLabourHoursInformationGateway.GetMealsQuantity(costingSheetId, work_, employeeId, refId).Value;
                        string newMotelUnitOfMeasurement = projectCostingSheetInformationLabourHoursInformationGateway.GetMotelUnitOfMeasurement(costingSheetId, work_, employeeId, refId);
                        int? newMotelQuantity = null; if (projectCostingSheetInformationLabourHoursInformationGateway.GetMotelQuantity(costingSheetId, work_, employeeId, refId).HasValue) newMotelQuantity = projectCostingSheetInformationLabourHoursInformationGateway.GetMotelQuantity(costingSheetId, work_, employeeId, refId).Value;
                        decimal newLHCostCad = projectCostingSheetInformationLabourHoursInformationGateway.GetLHCostCad(costingSheetId, work_, employeeId, refId);
                        decimal? newMealsCostCad = null; if (projectCostingSheetInformationLabourHoursInformationGateway.GetMealsCostCad(costingSheetId, work_, employeeId, refId).HasValue) newMealsCostCad = projectCostingSheetInformationLabourHoursInformationGateway.GetMealsCostCad(costingSheetId, work_, employeeId, refId);
                        decimal? newMotelCostCad = null; if (projectCostingSheetInformationLabourHoursInformationGateway.GetMotelCostCad(costingSheetId, work_, employeeId, refId).HasValue) newMotelCostCad = projectCostingSheetInformationLabourHoursInformationGateway.GetMotelCostCad(costingSheetId, work_, employeeId, refId);
                        decimal newTotalCostCad = projectCostingSheetInformationLabourHoursInformationGateway.GetTotalCostCad(costingSheetId, work_, employeeId, refId);
                        decimal newLHCostUsd = projectCostingSheetInformationLabourHoursInformationGateway.GetLHCostUsd(costingSheetId, work_, employeeId, refId);
                        decimal? newMealsCostUsd = null; if (projectCostingSheetInformationLabourHoursInformationGateway.GetMealsCostUsd(costingSheetId, work_, employeeId, refId).HasValue) newMealsCostUsd = projectCostingSheetInformationLabourHoursInformationGateway.GetMealsCostUsd(costingSheetId, work_, employeeId, refId);
                        decimal? newMotelCostUsd = null; if (projectCostingSheetInformationLabourHoursInformationGateway.GetMotelCostUsd(costingSheetId, work_, employeeId, refId).HasValue) newMotelCostUsd = projectCostingSheetInformationLabourHoursInformationGateway.GetMotelCostUsd(costingSheetId, work_, employeeId, refId);
                        decimal newTotalCostUsd = projectCostingSheetInformationLabourHoursInformationGateway.GetTotalCostUsd(costingSheetId, work_, employeeId, refId);
                        DateTime newStartDate = projectCostingSheetInformationLabourHoursInformationGateway.GetStartDate(costingSheetId, work_, employeeId, refId);
                        DateTime newEndDate = projectCostingSheetInformationLabourHoursInformationGateway.GetEndDate(costingSheetId, work_, employeeId, refId);
                        string newFunction_ = projectCostingSheetInformationLabourHoursInformationGateway.GetFunction_(costingSheetId, work_, employeeId, refId);

                        ProjectCostingSheetLabourHours labourHours = new ProjectCostingSheetLabourHours(null);
                        labourHours.UpdateDirect(costingSheetId, employeeId, refId, work_, originalLHQuantity, originalLHUnitOfMeasurement, originalMealsUnitOfMeasurement, originalMealsQuantity, originalMealsUnitOfMeasurement, originalMotelQuantity, originalLHCostCad, originalMealsCostCad, originalMotelCostCad, originalTotalCostCad, originalLHCostUsd, originalMealsCostUsd, originalMotelCostUsd, originalTotalCostUsd, deleted, companyId, originalStartDate, originalEndDate, originalFunction_, work_, newLHQuantity, newLHUnitOfMeasurement, newMealsUnitOfMeasurement, newMealsQuantity, newMotelUnitOfMeasurement, newMotelQuantity, newLHCostCad, newMealsCostCad, newMotelCostCad, newTotalCostCad, newLHCostUsd, newMealsCostUsd, newMotelCostUsd, newTotalCostUsd, deleted, companyId, newStartDate, newEndDate, newFunction_);
                    }

                    // Delete costing sheet Labour Hours  
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        ProjectCostingSheetLabourHours labourHours = new ProjectCostingSheetLabourHours(null);
                        labourHours.DeleteDirect(row.CostingSheetID, row.Work_, row.EmployeeID, row.RefID, row.COMPANY_ID);
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
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>row</returns>
        private ProjectCostingSheetInformationTDS.LabourHoursInformationRow GetRow(int costingSheetId, string work_, int employeeId, int refId)
        {
            ProjectCostingSheetInformationTDS.LabourHoursInformationRow row = ((ProjectCostingSheetInformationTDS.LabourHoursInformationDataTable)Table).FindByRefIDEmployeeIDWork_CostingSheetID(refId, employeeId, work_, costingSheetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetInformationLabourHoursInformation.GetRow");
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

            foreach (ProjectCostingSheetInformationTDS.LabourHoursInformationRow row in (ProjectCostingSheetInformationTDS.LabourHoursInformationDataTable)Table)
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