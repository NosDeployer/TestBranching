using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeInformationCostInformation
    /// </summary>
    public class EmployeeInformationCostInformation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeInformationCostInformation()
            : base("CostInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeInformationCostInformation(DataSet data)
            : base(data, "CostInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadAllByEmployeeId(int employeeId, int companyId)
        {
            EmployeeInformationCostInformationGateway employeeInformationCostInformationGateway = new EmployeeInformationCostInformationGateway(Data);
            employeeInformationCostInformationGateway.LoadAllByEmployeeId(employeeId, companyId);
        }



        /// <summary>
        /// Insert
        /// </summary>        
        /// <param name="employeeId">employeeId</param>
        /// <param name="date">date</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="payRateCad">payRateCad</param>
        /// <param name="burdenRateCad">burdenRateCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="payRateUsd">payRateUsd</param>
        /// <param name="burdenRateUsd">burdenRateUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="benefitFactorCad">benefitFactorCad</param>
        /// <param name="benefitFactorUsd">benefitFactorUsd</param>
        /// <param name="healthBenefitUsd">healthBenefitUsd</param>
        public void Insert(int employeeId, DateTime date, string unitOfMeasurement, decimal payRateCad, decimal burdenRateCad, decimal totalCostCad, decimal payRateUsd, decimal burdenRateUsd, decimal totalCostUsd, bool deleted, int companyId, bool inDatabase, decimal benefitFactorCad, decimal benefitFactorUsd, decimal healthBenefitUsd)
        {
            EmployeeInformationTDS.CostInformationRow row = ((EmployeeInformationTDS.CostInformationDataTable)Table).NewCostInformationRow();

            row.CostID = GetNewRefId(); 
            row.EmployeeID = employeeId;            
            row.Date = date;
            row.UnitOfMeasurement = unitOfMeasurement;
            row.PayRateCad = payRateCad;
            row.BurdenRateCad = burdenRateCad;
            row.TotalCostCad = totalCostCad;
            row.PayRateUsd = payRateUsd;
            row.BurdenRateUsd = burdenRateUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.BenefitFactorCad = benefitFactorCad;
            row.BenefitFactorUsd = benefitFactorUsd;
            row.HealthBenefitUsd = healthBenefitUsd;

            ((EmployeeInformationTDS.CostInformationDataTable)Table).AddCostInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="payRateCad">payRateCad</param>
        /// <param name="burdenRateCad">burdenRateCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="payRateUsd">payRateUsd</param>
        /// <param name="burdenRateUsd">burdenRateUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="date">date</param>       
        /// <param name="healthBenefitUsd">healthBenefitUsd</param>
        public void Update(int costId, int employeeId, string unitOfMeasurement, decimal payRateCad, decimal burdenRateCad, decimal totalCostCad, decimal payRateUsd, decimal burdenRateUsd, decimal totalCostUsd, DateTime date, decimal healthBenefitUsd)
        {
            EmployeeInformationTDS.CostInformationRow row = GetRow(costId);

            row.UnitOfMeasurement = unitOfMeasurement;
            row.PayRateCad = payRateCad;
            row.BurdenRateCad = burdenRateCad;
            row.TotalCostCad = totalCostCad;
            row.PayRateUsd = payRateUsd;
            row.BurdenRateUsd = burdenRateUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Date = date;            
            row.HealthBenefitUsd = healthBenefitUsd;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        public void Delete(int costId, int employeeId)
        {
            EmployeeInformationTDS.CostInformationRow row = GetRow(costId);
            row.Deleted = true;

            EmployeeInformationCostExceptionsInformation model = new EmployeeInformationCostExceptionsInformation(Data);
            model.DeleteAll(costId);
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        public void DeleteAll(int employeeId)
        {
            foreach (EmployeeInformationTDS.CostInformationRow row in (EmployeeInformationTDS.CostInformationDataTable)Table)
            {
                row.Deleted = true;

                // Delete exceptions
                foreach (EmployeeInformationTDS.CostExceptionsInformationRow rowException in (EmployeeInformationTDS.CostExceptionsInformationDataTable)Table)
                {
                    if (row.CostID == rowException.CostID)
                    {
                        rowException.Deleted = true;
                    }
                }
            }
        }



        /// <summary>
        /// Save all costs to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            EmployeeInformationTDS costInformationChanges = (EmployeeInformationTDS)Data.GetChanges();

            if (costInformationChanges.CostInformation.Rows.Count > 0)
            {
                EmployeeInformationCostInformationGateway employeeInformationCostInformationGateway = new EmployeeInformationCostInformationGateway(costInformationChanges);

                foreach (EmployeeInformationTDS.CostInformationRow row in (EmployeeInformationTDS.CostInformationDataTable)costInformationChanges.CostInformation)
                {
                    // Insert new costs 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        EmployeeCostHistory employeeCost = new EmployeeCostHistory(null);
                        employeeCost.InsertDirect(row.CostID, row.EmployeeID, row.Date, row.UnitOfMeasurement, row.PayRateCad, row.BurdenRateCad, row.TotalCostCad, row.PayRateUsd, row.BurdenRateUsd, row.TotalCostUsd, row.Deleted, row.COMPANY_ID, row.BenefitFactorCad, row.BenefitFactorUsd, row.HealthBenefitUsd); 
                    }

                    // Update costs
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int costId = row.CostID;
                        int employeeId = row.EmployeeID;                        
                        bool originalDeleted = row.Deleted;
                        int originalCompanyId = companyId;

                        // original values
                        DateTime originalDate = employeeInformationCostInformationGateway.GetDateOriginal(costId, employeeId);
                        string originalUnitOfMeasurement = employeeInformationCostInformationGateway.GetUnitOfMeasurementOriginal(costId, employeeId);
                        decimal originalPayRateCad = employeeInformationCostInformationGateway.GetPayRateCadOriginal(costId, employeeId);
                        decimal originalBurdenRateCad = employeeInformationCostInformationGateway.GetBurdenRateCadOriginal(costId, employeeId);
                        decimal originalTotalCostCad = employeeInformationCostInformationGateway.GetTotalCostCadOriginal(costId, employeeId);
                        decimal originalPayRateUsd = employeeInformationCostInformationGateway.GetPayRateUsdOriginal(costId, employeeId);
                        decimal originalBurdenRateUsd = employeeInformationCostInformationGateway.GetBurdenRateUsdOriginal(costId, employeeId);
                        decimal originalTotalCostUsd = employeeInformationCostInformationGateway.GetTotalCostUsdOriginal(costId, employeeId);
                        decimal originalBenefitFactorCad = employeeInformationCostInformationGateway.GetBenefitFactorCadOriginal(costId, employeeId);
                        decimal originalBenefitFactorUsd = employeeInformationCostInformationGateway.GetBenefitFactorUsdOriginal(costId, employeeId);
                        decimal originalHealthBenefitUsd = employeeInformationCostInformationGateway.GetHealthBenefitUsdOriginal(costId, employeeId);

                        // new values
                        DateTime newDate = employeeInformationCostInformationGateway.GetDate(costId, employeeId);
                        string newUnitOfMeasurement = employeeInformationCostInformationGateway.GetUnitOfMeasurement(costId, employeeId);
                        decimal newPayRateCad = employeeInformationCostInformationGateway.GetPayRateCad(costId, employeeId);
                        decimal newBurdenRateCad = employeeInformationCostInformationGateway.GetBurdenRateCad(costId, employeeId);
                        decimal newTotalCostCad = employeeInformationCostInformationGateway.GetTotalCostCad(costId, employeeId);
                        decimal newPayRateUsd = employeeInformationCostInformationGateway.GetPayRateUsd(costId, employeeId);
                        decimal newBurdenRateUsd = employeeInformationCostInformationGateway.GetBurdenRateUsd(costId, employeeId);
                        decimal newTotalCostUsd = employeeInformationCostInformationGateway.GetTotalCostUsd(costId, employeeId);
                        decimal newBenefitFactorCad = employeeInformationCostInformationGateway.GetBenefitFactorCad(costId, employeeId);
                        decimal newBenefitFactorUsd = employeeInformationCostInformationGateway.GetBenefitFactorUsd(costId, employeeId);
                        decimal newHealthBenefitUsd = employeeInformationCostInformationGateway.GetHealthBenefitUsd(costId, employeeId);

                        EmployeeCostHistory employeeCost = new EmployeeCostHistory(null);
                        employeeCost.UpdateDirect(costId, employeeId, originalDate, originalUnitOfMeasurement, originalPayRateCad, originalBurdenRateCad, originalTotalCostCad, originalPayRateUsd, originalBurdenRateUsd, originalTotalCostUsd, originalDeleted, originalCompanyId, originalBenefitFactorCad, originalBenefitFactorUsd, originalHealthBenefitUsd, costId, employeeId, newDate, newUnitOfMeasurement, newPayRateCad, newBurdenRateCad, newTotalCostCad, newPayRateUsd, newBurdenRateUsd, newTotalCostUsd, originalDeleted, originalCompanyId, newBenefitFactorCad, newBenefitFactorUsd, newHealthBenefitUsd);
                    }

                    // Deleted costs 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        EmployeeCostHistory employeeCost = new EmployeeCostHistory(null);
                        employeeCost.DeleteDirect(row.CostID, row.EmployeeID, row.COMPANY_ID);
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
        /// <param name="costId">costId</param>        
        /// <returns>Obtained row</returns>
        private EmployeeInformationTDS.CostInformationRow GetRow(int costId)
        {
            EmployeeInformationTDS.CostInformationRow row = ((EmployeeInformationTDS.CostInformationDataTable)Table).FindByCostID(costId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.Employees.EmployeeInformationCostInformation.GetRow");
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

            foreach (EmployeeInformationTDS.CostInformationRow row in (EmployeeInformationTDS.CostInformationDataTable)Table)
            {
                if (newRefId < row.CostID)
                {
                    newRefId = row.CostID;
                }
            }

            newRefId++;

            return newRefId;
        }



    }
}