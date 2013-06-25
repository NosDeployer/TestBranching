using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeStandardCostsSetup
    /// </summary>
    public class EmployeeStandardCostsSetup: TableModule
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeStandardCostsSetup()
            : base("StandardCostsSetup")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeStandardCostsSetup(DataSet data)
            : base(data, "StandardCostsSetup")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeStandardCostsSetupTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAll
        /// </summary>       
        public void LoadAll()
        {
            EmployeeStandardCostsSetupGateway employeeStandardCostsSetupGateway = new EmployeeStandardCostsSetupGateway(Data);
            employeeStandardCostsSetupGateway.LoadAll();
        }



        /// <summary>
        /// Update costs
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="bourdenFactor">bourdenFactor</param>
        /// <param name="usHealthBenefitFactor">usHealthBenefitFactor</param>
        /// <param name="benefitFactorCad">benefitFactorCad</param>
        /// <param name="benefitFactorUsd">benefitFactorUsd</param>
        public void Update(int employeeId, decimal? bourdenFactor, decimal? usHealthBenefitFactor, decimal? benefitFactorCad, decimal? benefitFactorUsd)
        {
            EmployeeStandardCostsSetupTDS.StandardCostsSetupRow row = GetRow(employeeId);

            // Cost Data                        
            if (bourdenFactor.HasValue) row.BourdenFactor = (decimal)bourdenFactor; else row.SetBourdenFactorNull();
            if (usHealthBenefitFactor.HasValue) row.USHealthBenefitFactor = (decimal)usHealthBenefitFactor; else row.SetUSHealthBenefitFactorNull();
            if (benefitFactorCad.HasValue) row.BenefitFactorCad = (decimal)benefitFactorCad; else row.SetBenefitFactorCadNull();
            if (benefitFactorUsd.HasValue) row.BenefitFactorUsd = (decimal)benefitFactorUsd; else row.SetBenefitFactorUsdNull();            
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            EmployeeStandardCostsSetupTDS employeeStandardCostsSetupChanges = (EmployeeStandardCostsSetupTDS)Data.GetChanges();

            if (employeeStandardCostsSetupChanges.StandardCostsSetup.Rows.Count > 0)
            {
                EmployeeStandardCostsSetupGateway employeeStandardCostsSetupGateway = new EmployeeStandardCostsSetupGateway(employeeStandardCostsSetupChanges);

                // Update employee
                foreach (EmployeeStandardCostsSetupTDS.StandardCostsSetupRow standardCostsSetupRow in (EmployeeStandardCostsSetupTDS.StandardCostsSetupDataTable)employeeStandardCostsSetupChanges.StandardCostsSetup)
                {
                    // Unchanged values
                    int employeeId = standardCostsSetupRow.EmployeeID;
                    int? loginId = null; if(!standardCostsSetupRow.IsLoginIDNull()) loginId =  standardCostsSetupRow.LoginID;
                    int? contactsId = null; if (!standardCostsSetupRow.IsContactsIDNull()) contactsId = standardCostsSetupRow.ContactsID;
                    string fullName = standardCostsSetupRow.FullName;
                    string firstName = standardCostsSetupRow.FirstName;
                    string middleInitial = ""; if (!standardCostsSetupRow.IsMiddleInitialNull()) middleInitial = standardCostsSetupRow.MiddleInitial;                    
                    string lastName = standardCostsSetupRow.LastName;
                    string type = standardCostsSetupRow.Type;
                    string state = standardCostsSetupRow.State;
                    bool isSalessman = standardCostsSetupRow.IsSalesman;
                    bool requestProjectTime = standardCostsSetupRow.RequestProjectTime;
                    bool deleted = standardCostsSetupRow.Deleted;
                    bool salaried = standardCostsSetupRow.Salaried;
                    string eMail = ""; if (!standardCostsSetupRow.IseMailNull()) eMail = standardCostsSetupRow.eMail;
                    bool assignableSrs = standardCostsSetupRow.AssignableSRS;
                    string jobClassType = ""; if (!standardCostsSetupRow.IsJobClassTypeNull()) jobClassType = standardCostsSetupRow.JobClassType;
                    string category = standardCostsSetupRow.Category;
                    string personalAgencyName = ""; if (!standardCostsSetupRow.IsPersonalAgencyNameNull()) personalAgencyName = standardCostsSetupRow.PersonalAgencyName;
                    bool isVacationsManager = standardCostsSetupRow.IsVacationsManager;
                    bool approveTimesheets = standardCostsSetupRow.ApproveTimesheets;
                    
                    // Original values
                    decimal? originalBourdenFactor = employeeStandardCostsSetupGateway.GetBourdenFactorOriginal(employeeId);
                    decimal? originalUSHealthBenefitFactor = employeeStandardCostsSetupGateway.GetUSHealthBenefitFactorOriginal(employeeId);
                    decimal? originalBenefitFactorCad = employeeStandardCostsSetupGateway.GetBenefitFactorCadOriginal(employeeId);
                    decimal? originalBenefitFactorUsd = employeeStandardCostsSetupGateway.GetBenefitFactorUsdOriginal(employeeId);
                    
                    // New variables
                    decimal? newBourdenFactor = employeeStandardCostsSetupGateway.GetBourdenFactor(employeeId);
                    decimal? newUSHealthBenefitFactor = employeeStandardCostsSetupGateway.GetUSHealthBenefitFactor(employeeId);
                    decimal? newBenefitFactorCad = employeeStandardCostsSetupGateway.GetBenefitFactorCad(employeeId);
                    decimal? newBenefitFactorUsd = employeeStandardCostsSetupGateway.GetBenefitFactorUsd(employeeId);
                    string crew = ""; if (!standardCostsSetupRow.IsCrewNull()) crew = standardCostsSetupRow.Crew;

                    // ... Update employee
                    Employee employee = new Employee(null);
                    employee.UpdateDirect(employeeId, loginId, contactsId, fullName, firstName, middleInitial, lastName, type, state, isSalessman, requestProjectTime, deleted, salaried, eMail, assignableSrs, jobClassType, category, personalAgencyName, isVacationsManager, approveTimesheets, originalBourdenFactor, originalUSHealthBenefitFactor, originalBenefitFactorCad, originalBenefitFactorUsd, crew, fullName, firstName, middleInitial, lastName, type, state, isSalessman, requestProjectTime, deleted, salaried, eMail, assignableSrs, jobClassType, category, personalAgencyName, isVacationsManager, approveTimesheets, newBourdenFactor, newUSHealthBenefitFactor, newBenefitFactorCad, newBenefitFactorUsd, crew);

                    // ... Update cost history table
                    // ... ... if there are new values
                    if ((newBourdenFactor.HasValue) && (newUSHealthBenefitFactor.HasValue) && (newBenefitFactorCad.HasValue) && (newBenefitFactorUsd.HasValue))
                    {
                        // ... ... verify if the new values are different from original
                        if ((originalBourdenFactor.HasValue) && (originalUSHealthBenefitFactor.HasValue) && (originalBenefitFactorCad.HasValue) && (originalBenefitFactorUsd.HasValue))
                        {
                            if (((decimal)originalBourdenFactor != (decimal)newBourdenFactor) || ((decimal)originalUSHealthBenefitFactor != (decimal)newUSHealthBenefitFactor) || ((decimal)originalBenefitFactorCad != (decimal)newBenefitFactorCad) || ((decimal)originalBenefitFactorUsd != (decimal)newBenefitFactorUsd))
                            {
                                EmployeeInformationCostInformationGateway employeeInformationCostInformationGateway = new EmployeeInformationCostInformationGateway();
                                employeeInformationCostInformationGateway.LoadLastCostByEmployeeId(employeeId, companyId);
                                if (employeeInformationCostInformationGateway.Table.Rows.Count > 0)
                                {
                                    DateTime date = DateTime.Now;
                                    int lastCostId = employeeInformationCostInformationGateway.GetCostId(employeeId);
                                    string unitOfMeasurement = employeeInformationCostInformationGateway.GetUnitOfMeasurement(lastCostId, employeeId);
                                    decimal payRateCad = employeeInformationCostInformationGateway.GetPayRateCad(lastCostId, employeeId);
                                    decimal payRateUsd = employeeInformationCostInformationGateway.GetPayRateUsd(lastCostId, employeeId);
                                    decimal benefitFactorUsd = employeeInformationCostInformationGateway.GetBenefitFactorUsd(lastCostId, employeeId);

                                    decimal boudenFactor = (decimal)newBourdenFactor / 100;

                                    decimal burdenRateCad = Decimal.Round(payRateCad * boudenFactor, 2);
                                    decimal totalCostCad = payRateCad + burdenRateCad;
                                    totalCostCad = Decimal.Round(totalCostCad, 2);

                                    decimal burdenRateUsd = Decimal.Round(payRateUsd * boudenFactor, 2);
                                    decimal totalCostUsd = payRateUsd + burdenRateUsd;
                                    totalCostUsd = Decimal.Round(totalCostUsd, 2);
                                    
                                    decimal healthBenefitFactorUsd = (decimal)newUSHealthBenefitFactor / 100;
                                    decimal healthBenefitUsd = benefitFactorUsd * healthBenefitFactorUsd;

                                    int newCostId = lastCostId + 1;

                                    EmployeeCostHistory employeeCostHistory = new EmployeeCostHistory(null);
                                    employeeCostHistory.InsertDirect(newCostId, employeeId, date, unitOfMeasurement, payRateCad, burdenRateCad, totalCostCad, payRateUsd, burdenRateUsd, totalCostUsd, false, companyId, (decimal)newBenefitFactorCad, (decimal)newBenefitFactorUsd, healthBenefitUsd);
                                }
                            }
                        }
                    }
                }
            }            
        }



        /// <summary>
        /// GetSummary
        /// </summary>
        /// <returns>Summary</returns>
        public string GetSummary()
        {
            string summary = "";
            foreach (EmployeeStandardCostsSetupTDS.StandardCostsSetupRow row in (EmployeeStandardCostsSetupTDS.StandardCostsSetupDataTable)Table)
            {
                summary = summary + "Team Member: " + row.FullName;
                string boudenFactor = "";
                if (!row.IsBourdenFactorNull()) boudenFactor = row.BourdenFactor.ToString();
                summary = summary + ", Burden Factor (%): " + boudenFactor;

                string usHealthBenefitFactor = "";
                if (!row.IsUSHealthBenefitFactorNull()) usHealthBenefitFactor = row.USHealthBenefitFactor.ToString();
                summary = summary + ", US Health Benefit Factor (%): " + usHealthBenefitFactor;

                string benefitFactorCad = "";
                if (!row.IsBenefitFactorCadNull()) benefitFactorCad = row.BenefitFactorCad.ToString();
                summary = summary + ", Benefit Factor (Cad): " + benefitFactorCad;

                string benefitFactorUsd = "";
                if (!row.IsBenefitFactorUsdNull()) benefitFactorUsd = row.BenefitFactorUsd.ToString();
                summary = summary + ", Benefit Factor (Usd): " + benefitFactorUsd + "\n\n";
            }

            return summary;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //   

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Obtained row</returns>
        private EmployeeStandardCostsSetupTDS.StandardCostsSetupRow GetRow(int employeeId)
        {
            EmployeeStandardCostsSetupTDS.StandardCostsSetupRow row = ((EmployeeStandardCostsSetupTDS.StandardCostsSetupDataTable)Table).FindByEmployeeID(employeeId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.Employee.EmployeeStandardCostsSetup.GetRow");
            }

            return row;
        }
      


    }
}
