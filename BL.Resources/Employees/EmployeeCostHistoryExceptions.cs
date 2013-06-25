using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeCostHistoryExceptions
    /// </summary>
    public class EmployeeCostHistoryExceptions: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeCostHistoryExceptions()
            : base("LFS_RESOURCES_EMPLOYEE_COST_HISTORY_EXCEPTIONS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeCostHistoryExceptions(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE_COST_HISTORY_EXCEPTIONS")
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
        /// Insert a new employee (direct to DB)
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="work_">work_</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="payRateCad">payRateCad</param>
        /// <param name="burdenRateCad">burdenRateCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="payRateUsd">payRateUsd</param>
        /// <param name="burdenRateUsd">burdenRateUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>  
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="benefitFactorCad">benefitFactorCad</param>
        /// <param name="benefitFactorUsd">benefitFactorUsd</param>
        /// <param name="healthBenefitUsd">healthBenefitUsd</param>
        public void InsertDirect(int costId, int refId, int employeeId, string work_, string unitOfMeasurement, decimal payRateCad, decimal burdenRateCad, decimal totalCostCad, decimal payRateUsd, decimal burdenRateUsd, decimal totalCostUsd, bool deleted, int companyId, decimal benefitFactorCad, decimal benefitFactorUsd, decimal healthBenefitUsd)
        {
            EmployeeCostHistoryExceptionsGateway employeeCostHistoryExceptionsGateway = new EmployeeCostHistoryExceptionsGateway(null);
            employeeCostHistoryExceptionsGateway.Insert(costId, refId, employeeId, work_, unitOfMeasurement, payRateCad, burdenRateCad, totalCostCad, payRateUsd, burdenRateUsd, totalCostUsd, deleted, companyId, benefitFactorCad, benefitFactorUsd, healthBenefitUsd);
        }



        /// <summary>
        /// Update employee  cost(direct to DB)
        /// </summary>
        /// <param name="originalCostId">originalCostId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalWork">originalWork</param>        
        /// <param name="originalUnitOfMeasurement">originalUnitOfMeasurement</param>
        /// <param name="originalPayRateCad">originalPayRateCad</param>
        /// <param name="originalBurdenRateCad">originalBurdenRateCad</param>
        /// <param name="originalTotalCostCad">originalTotalCostCad</param>
        /// <param name="originalPayRateUsd">originalPayRateUsd</param>
        /// <param name="originalBurdenRateUsd">originalBurdenRateUsd</param>
        /// <param name="originalTotalCostUsd">originalTotalCostUsd</param>        
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalBenefitFactorCad">originalBenefitFactorCad</param>
        /// <param name="originalBenefitFactorUsd">originalBenefitFactorUsd</param>
        /// <param name="originalHealthBenefitUsd">originalHealthBenefitUsd</param>
        ///
        /// <param name="newCostId">newCostId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newEmployeeId">newEmployeeId</param>
        /// <param name="newWork">newWork</param>        
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
        public void UpdateDirect(int originalCostId, int originalRefId, int originalEmployeeId, string originalWork, string originalUnitOfMeasurement, decimal originalPayRateCad, decimal originalBurdenRateCad, decimal originalTotalCostCad, decimal originalPayRateUsd, decimal originalBurdenRateUsd, decimal originalTotalCostUsd, bool originalDeleted, int originalCompanyId, decimal originalBenefitFactorCad, decimal originalBenefitFactorUsd, decimal originalHealthBenefitUsd, int newCostId, int newRefId, int newEmployeeId, string newWork, string newUnitOfMeasurement, decimal newPayRateCad, decimal newBurdenRateCad, decimal newTotalCostCad, decimal newPayRateUsd, decimal newBurdenRateUsd, decimal newTotalCostUsd, bool newDeleted, int newCompanyId, decimal newBenefitFactorCad, decimal newBenefitFactorUsd, decimal newHealthBenefitUsd)
        {
            EmployeeCostHistoryExceptionsGateway employeeCostHistoryExceptionsGateway = new EmployeeCostHistoryExceptionsGateway(null);
            employeeCostHistoryExceptionsGateway.Update(originalCostId, originalRefId, originalEmployeeId, originalWork, originalUnitOfMeasurement, originalPayRateCad, originalBurdenRateCad, originalTotalCostCad, originalPayRateUsd, originalBurdenRateUsd, originalTotalCostUsd, originalDeleted, originalCompanyId, originalBenefitFactorCad, originalBenefitFactorUsd, originalHealthBenefitUsd, newCostId, newRefId, newEmployeeId, newWork, newUnitOfMeasurement, newPayRateCad, newBurdenRateCad, newTotalCostCad, newPayRateUsd, newBurdenRateUsd, newTotalCostUsd, newDeleted, newCompanyId, newBenefitFactorCad, newBenefitFactorUsd, newHealthBenefitUsd);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int costId, int refId, int companyId)
        {
            EmployeeCostHistoryExceptionsGateway employeeCostHistoryExceptionsGateway = new EmployeeCostHistoryExceptionsGateway(null);
            employeeCostHistoryExceptionsGateway.Delete(costId, refId,  companyId);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int employeeId, int companyId)
        {
            EmployeeCostHistoryExceptionsGateway employeeCostHistoryExceptionsGateway = new EmployeeCostHistoryExceptionsGateway(null);
            employeeCostHistoryExceptionsGateway.DeleteAll(employeeId,  companyId);
        }

    }
}
