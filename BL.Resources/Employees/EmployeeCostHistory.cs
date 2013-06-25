using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeCostHistory
    /// </summary>
    public class EmployeeCostHistory: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeCostHistory()
            : base("LFS_RESOURCES_EMPLOYEE_COST_HISTORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeCostHistory(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE_COST_HISTORY")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new employee cost (direct to DB)
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="date">date</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="payRateCad">payRateCad</param>
        /// <param name="burdenRateCad">burdenRateCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="payRateUsd">payRateUsd</param>
        /// <param name="burdenRateUsd">burdenRateUsd</param>
        /// <param name="totalcostUsd">totalcostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="benefitFactorCad">benefitFactorCad</param>
        /// <param name="benefitFactorUsd">benefitFactorUsd</param>
        /// <param name="healthBenefitUsd">healthBenefitUsd</param>
        public void InsertDirect(int costId, int employeeId, DateTime date, string unitOfMeasurement, decimal payRateCad, decimal burdenRateCad, decimal totalCostCad, decimal payRateUsd, decimal burdenRateUsd, decimal totalcostUsd, bool deleted, int companyId, decimal benefitFactorCad, decimal benefitFactorUsd, decimal healthBenefitUsd)
        {
            EmployeeCostHistoryGateway employeeCostHistoryGateway = new EmployeeCostHistoryGateway(null);
            employeeCostHistoryGateway.Insert(costId, employeeId, date, unitOfMeasurement, payRateCad, burdenRateCad, totalCostCad, payRateUsd, burdenRateUsd, totalcostUsd, deleted, companyId, benefitFactorCad, benefitFactorUsd, healthBenefitUsd);
        }



        /// <summary>
        /// Update employee  cost (direct to DB)
        /// </summary>
        /// <param name="originalCostId">originalCostId</param>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalDate">originalDate</param>
        /// <param name="originalUnitOfMeasurement">originalUnitOfMeasurement</param>
        /// <param name="originalPayRateCad">originalPayRateCad</param>
        /// <param name="originalBurdenRateCad">originalBurdenRateCad</param>
        /// <param name="originalTotalCostCad">originalTotalCostCad</param>
        /// <param name="originalPayRateUsd">originalPayRateUsd</param>
        /// <param name="originalBurdenRateUsd">originalBurdenRateUsd</param>
        /// <param name="originalTotalCostUsd">originalTotalCostUsd</param>        
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalBenefirFactorCad">originalBenefirFactorCad</param>
        /// <param name="originalBenefitFactorUsd">originalBenefitFactorUsd</param>
        /// <param name="originalHealthBenefitUsd">originalHealthBenefitUsd</param>
        ///
        /// <param name="newCostId">newCostId</param>
        /// <param name="newEmployeeId">newEmployeeId</param>
        /// <param name="newDate">newDate</param>
        /// <param name="newUnitOfMeasurement">newUnitOfMeasurement</param>
        /// <param name="newPayRateCad">newPayRateCad</param>
        /// <param name="newBurdenRateCad">newBurdenRateCad</param>
        /// <param name="newTotalCostCad">newTotalCostCad</param>
        /// <param name="newPayRateUsd">newPayRateUsd</param>
        /// <param name="newBurdenRateUsd">newBurdenRateUsd</param>
        /// <param name="newTotalCostUsd">newTotalCostUsd</param>        
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newBenefitFactorCad">newBenefitFactorCad</param>
        /// <param name="newBenefitFactorUsd">newBenefitFactorUsd</param>
        /// <param name="newHealthBenefitUsd">newHealthBenefitUsd</param>
        public void UpdateDirect(int originalCostId, int originalEmployeeId, DateTime originalDate, string originalUnitOfMeasurement, decimal originalPayRateCad, decimal originalBurdenRateCad, decimal originalTotalCostCad, decimal originalPayRateUsd, decimal originalBurdenRateUsd, decimal originalTotalCostUsd, bool originalDeleted, int originalCompanyId, decimal originalBenefirFactorCad, decimal originalBenefitFactorUsd, decimal originalHealthBenefitUsd, int newCostId, int newEmployeeId, DateTime newDate, string newUnitOfMeasurement, decimal newPayRateCad, decimal newBurdenRateCad, decimal newTotalCostCad, decimal newPayRateUsd, decimal newBurdenRateUsd, decimal newTotalCostUsd, bool newDeleted, int newCompanyId, decimal newBenefitFactorCad, decimal newBenefitFactorUsd, decimal newHealthBenefitUsd)
        {
            EmployeeCostHistoryGateway employeeCostHistoryGateway = new EmployeeCostHistoryGateway(null);
            employeeCostHistoryGateway.Update(originalCostId, originalEmployeeId, originalDate, originalUnitOfMeasurement, originalPayRateCad, originalBurdenRateCad, originalTotalCostCad, originalPayRateUsd, originalBurdenRateUsd, originalTotalCostUsd, originalDeleted, originalCompanyId, originalBenefirFactorCad, originalBenefitFactorUsd, originalHealthBenefitUsd, newCostId, newEmployeeId, newDate, newUnitOfMeasurement, newPayRateCad, newBurdenRateCad, newTotalCostCad, newPayRateUsd, newBurdenRateUsd, newTotalCostUsd, newDeleted, newCompanyId, newBenefitFactorCad, newBenefitFactorUsd, newHealthBenefitUsd);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="originalCostId">originalCostId</param>
        /// <param name="originalMaterialId">originalMaterialId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        public void DeleteDirect(int originalCostId, int originalMaterialId, int originalCompanyId)
        {
            EmployeeCostHistoryGateway employeeCostHistoryGateway = new EmployeeCostHistoryGateway(null);
            employeeCostHistoryGateway.Delete(originalCostId, originalMaterialId, originalCompanyId);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int employeeId, int companyId)
        {
            // Delete exceptions           
            EmployeeCostHistoryExceptions employeeCostHistoryExceptions = new EmployeeCostHistoryExceptions(null);
            employeeCostHistoryExceptions.DeleteAllDirect(employeeId, companyId);

            // Delete costs
            EmployeeCostHistoryGateway employeeCostHistoryGateway = new EmployeeCostHistoryGateway(null);
            employeeCostHistoryGateway.DeleteAll(employeeId, companyId);
        }



    }
}