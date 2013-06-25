using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeInformationCostExceptionsInformation
    /// </summary>
    public class EmployeeInformationCostExceptionsInformation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeInformationCostExceptionsInformation()
            : base("CostExceptionsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeInformationCostExceptionsInformation(DataSet data)
            : base(data, "CostExceptionsInformation")
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
        /// LoadAllByCostId
        /// </summary>
        /// <param name="costId">costId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadAllByCostId(int costId, int companyId)
        {
            EmployeeInformationCostExceptionsInformationGateway employeeInformationCostExceptionsInformationGateway = new EmployeeInformationCostExceptionsInformationGateway(Data);
            employeeInformationCostExceptionsInformationGateway.LoadAllByCostId(costId, companyId);
        }



        /// <summary>
        /// LoadAllByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadAllByEmployeeId(int employeeId, int companyId)
        {
            EmployeeInformationCostExceptionsInformationGateway employeeInformationCostExceptionsInformationGateway = new EmployeeInformationCostExceptionsInformationGateway(Data);
            employeeInformationCostExceptionsInformationGateway.LoadAllByEmployeeId(employeeId, companyId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costId">costId</param>
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
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="benefitFactorCad">benefitFactorCad</param>
        /// <param name="benefitFactorUsd">benefitFactotUsd</param>
        /// <param name="healthBenefitUsd">healthBenefitUsd</param>
        public void Insert(int costId, string work_, string unitOfMeasurement, decimal payRateCad, decimal burdenRateCad, decimal totalCostCad, decimal payRateUsd, decimal burdenRateUsd, decimal totalCostUsd, bool deleted, int companyId, bool inDatabase, decimal benefitFactorCad, decimal benefitFactorUsd, decimal healthBenefitUsd)
        {
            EmployeeInformationTDS.CostExceptionsInformationRow row = ((EmployeeInformationTDS.CostExceptionsInformationDataTable)Table).NewCostExceptionsInformationRow();

            row.EmployeeID = 0;
            row.CostID = costId;
            row.RefID = GetNewRefId();
            row.Work_ = work_;            
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

            ((EmployeeInformationTDS.CostExceptionsInformationDataTable)Table).AddCostExceptionsInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <param name="work_">work_</param>        
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="payRateCad">payRateCad</param>
        /// <param name="burdenRateCad">burdenRateCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="payRateUsd">payRateUsd</param>
        /// <param name="burdenRateUsd">burdenRateUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>        
        /// <param name="healthBenefitUsd">healthBenefitUsd</param>
        public void Update(int costId, int refId, string work_, string unitOfMeasurement, decimal payRateCad, decimal burdenRateCad, decimal totalCostCad, decimal payRateUsd, decimal burdenRateUsd, decimal totalCostUsd, decimal healthBenefitUsd)
        {
            EmployeeInformationTDS.CostExceptionsInformationRow row = GetRow(costId, refId);
            row.Work_ = work_;                        
            row.UnitOfMeasurement = unitOfMeasurement;
            row.PayRateCad = payRateCad;
            row.BurdenRateCad = burdenRateCad;
            row.TotalCostCad = totalCostCad;
            row.PayRateUsd = payRateUsd;
            row.BurdenRateUsd = burdenRateUsd;
            row.TotalCostUsd = totalCostUsd;           
            row.HealthBenefitUsd = healthBenefitUsd;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        public void Delete(int costId, int refId)
        {
            EmployeeInformationTDS.CostExceptionsInformationRow row = GetRow(costId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="costId">costId</param>
        public void DeleteAll(int costId)
        {
            foreach (EmployeeInformationTDS.CostExceptionsInformationRow row in (EmployeeInformationTDS.CostExceptionsInformationDataTable)Table)
            {
                row.Deleted = true;
            }
        }



        /// <summary>
        /// Save all employee cost exception to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId, int employeeId)
        {
            EmployeeInformationTDS costExceptionsInformationChanges = (EmployeeInformationTDS)Data.GetChanges();

            if (costExceptionsInformationChanges.CostExceptionsInformation.Rows.Count > 0)
            {
                EmployeeInformationCostExceptionsInformationGateway employeeInformationCostExceptionsInformationGateway = new EmployeeInformationCostExceptionsInformationGateway(costExceptionsInformationChanges);

                foreach (EmployeeInformationTDS.CostExceptionsInformationRow row in (EmployeeInformationTDS.CostExceptionsInformationDataTable)costExceptionsInformationChanges.CostExceptionsInformation)
                {
                    // Insert new costs exceptions 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        EmployeeCostHistoryExceptions employeeCostHistoryExceptions = new EmployeeCostHistoryExceptions(null);
                        employeeCostHistoryExceptions.InsertDirect(row.CostID, row.RefID, employeeId, row.Work_, row.UnitOfMeasurement, row.PayRateCad, row.BurdenRateCad, row.TotalCostCad, row.PayRateUsd, row.BurdenRateUsd, row.TotalCostUsd, row.Deleted, row.COMPANY_ID, row.BenefitFactorCad, row.BenefitFactorUsd, row.HealthBenefitUsd);
                    }

                    // Update costs exceptions
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int costId = row.CostID;
                        int refId = row.RefID;
                        bool originalDeleted = row.Deleted;
                        int originalCompanyId = companyId;

                        // original values
                        string originalWork = employeeInformationCostExceptionsInformationGateway.GetWork_Original(costId, refId);                        
                        string originalUnitOfMeasurement = employeeInformationCostExceptionsInformationGateway.GetUnitOfMeasurementOriginal(costId, refId);
                        decimal originalPayRateCad = employeeInformationCostExceptionsInformationGateway.GetPayRateCadOriginal(costId, refId);
                        decimal originalBurdenRateCad = employeeInformationCostExceptionsInformationGateway.GetBurdenRateCadOriginal(costId, refId);
                        decimal originalTotalCostCad = employeeInformationCostExceptionsInformationGateway.GetTotalCostCadOriginal(costId, refId);
                        decimal originalPayRateUsd = employeeInformationCostExceptionsInformationGateway.GetPayRateUsdOriginal(costId, refId);
                        decimal originalBurdenRateUsd = employeeInformationCostExceptionsInformationGateway.GetBurdenRateUsdOriginal(costId, refId);
                        decimal originalTotalCostUsd = employeeInformationCostExceptionsInformationGateway.GetTotalCostUsdOriginal(costId, refId);
                        decimal originalBenefitFactorCad = employeeInformationCostExceptionsInformationGateway.GetBenefitFactorCadOriginal(costId, refId);
                        decimal originalBenefitFactorUsd = employeeInformationCostExceptionsInformationGateway.GetBenefitFactorUsdOriginal(costId, refId);
                        decimal originalHealthBenefitUsd = employeeInformationCostExceptionsInformationGateway.GetHealthBenefitUsdOriginal(costId, employeeId);
                        
                        // new values
                        string newWork = employeeInformationCostExceptionsInformationGateway.GetWork_(costId, refId);
                        string newUnitOfMeasurement = employeeInformationCostExceptionsInformationGateway.GetUnitOfMeasurement(costId, refId);
                        decimal newPayRateCad = employeeInformationCostExceptionsInformationGateway.GetPayRateCad(costId, refId);
                        decimal newBurdenRateCad = employeeInformationCostExceptionsInformationGateway.GetBurdenRateCad(costId, refId);
                        decimal newTotalCostCad = employeeInformationCostExceptionsInformationGateway.GetTotalCostCad(costId, refId);
                        decimal newPayRateUsd = employeeInformationCostExceptionsInformationGateway.GetPayRateUsd(costId, refId);
                        decimal newBurdenRateUsd = employeeInformationCostExceptionsInformationGateway.GetBurdenRateUsd(costId, refId);
                        decimal newTotalCostUsd = employeeInformationCostExceptionsInformationGateway.GetTotalCostUsd(costId, refId);
                        decimal newBenefitFactorCad = employeeInformationCostExceptionsInformationGateway.GetBenefitFactorCad(costId, refId);
                        decimal newBenefitFactorUsd = employeeInformationCostExceptionsInformationGateway.GetBenefitFactorUsd(costId, refId);
                        decimal newHealthBenefitUsd = employeeInformationCostExceptionsInformationGateway.GetHealthBenefitUsd(costId, employeeId);


                        EmployeeCostHistoryExceptions employeeCostHistoryExceptions = new EmployeeCostHistoryExceptions(null);
                        employeeCostHistoryExceptions.UpdateDirect(costId, refId, employeeId, originalWork, originalUnitOfMeasurement, originalPayRateCad, originalBurdenRateCad, originalTotalCostCad, originalPayRateUsd, originalBurdenRateUsd, originalTotalCostUsd, originalDeleted, originalCompanyId, originalBenefitFactorCad, originalBenefitFactorUsd, originalHealthBenefitUsd, costId, refId, employeeId, newWork, newUnitOfMeasurement, newPayRateCad, newBurdenRateCad, newTotalCostCad, newPayRateUsd, newBurdenRateUsd, newTotalCostUsd, originalDeleted, originalCompanyId, newBenefitFactorCad, newBenefitFactorUsd, newHealthBenefitUsd);
                    }

                    // Deleted costs exceptions 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        EmployeeCostHistoryExceptions employeeCostHistoryExceptions = new EmployeeCostHistoryExceptions(null);
                        employeeCostHistoryExceptions.DeleteDirect(row.CostID, row.RefID, row.COMPANY_ID);
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
        /// <param name="refId">refId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <returns>Obtained row</returns>        
        private EmployeeInformationTDS.CostExceptionsInformationRow GetRow(int costId, int refId)
        {
            EmployeeInformationTDS.CostExceptionsInformationRow row = ((EmployeeInformationTDS.CostExceptionsInformationDataTable)Table).FindByCostIDRefID(costId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Resources.EmployeeInformationCostExceptionsInformation.GetRow");
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

            foreach (EmployeeInformationTDS.CostExceptionsInformationRow row in (EmployeeInformationTDS.CostExceptionsInformationDataTable)Table)
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