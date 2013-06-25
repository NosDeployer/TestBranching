using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// Employee
    /// </summary>
    public class Employee : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Employee()
            : base("LFS_RESOURCES_EMPLOYEE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Employee(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE")
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
        /// LoadByFleetManager
        /// </summary>
        public void LoadByFleetManager(int companyLevelId)
        {
            EmployeeGateway employeeGateway = new EmployeeGateway(Data);
            employeeGateway.LoadByFleetManager(companyLevelId);
        }



        /// <summary>
        /// Insert a new enployee (direct to DB)
        /// </summary>
        /// <param name="loginId">loginId</param>       
        /// <param name="contactsId">contactsId</param>
        /// <param name="fullName">fullName</param>
        /// <param name="firstName">firstName</param>
        /// <param name="middleInitial">middleInitial</param>
        /// <param name="lastName">lastName</param>
        /// <param name="type">type</param>
        /// <param name="state">state</param>
        /// <param name="isSalesman">isSalesman</param>
        /// <param name="requestProjectTime">requestProjectTime</param>
        /// <param name="deleted">deleted</param>
        /// <param name="salaried">salaried</param>        
        /// <param name="eMail">eMail</param>
        /// <param name="assignableSrs">assignableSrs</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <param name="category">category</param>
        /// <param name="personalAgencyName">personalAgencyName</param>
        /// <param name="isVacationsManager">isVacationsManager</param>
        /// <param name="approveTimesheets">approveTimesheets</param>
        /// <param name="bourdenFactor">bourdenFactor</param>
        /// <param name="usHealthBenefitFactor">usHealthBenefitFactor</param>
        /// <param name="benefitFactorCad">benefitFactorCad</param>
        /// <param name="benefitFactorUsd">benefitFactorUsd</param>
        /// <param name="crew">crew</param>
        /// <returns>employeeId</returns>
        public int InsertDirect(int? loginId, int? contactsId, string fullName, string firstName, string middleInitial, string lastName, string type, string state, bool isSalesman, bool requestProjectTime, bool deleted, bool salaried, string eMail, bool assignableSrs, string jobClassType, string category, string personalAgencyName, bool isVacationsManager, bool approveTimesheets, decimal? bourdenFactor, decimal? usHealthBenefitFactor, decimal? benefitFactorCad, decimal? benefitFactorUsd, string crew)
        {
            EmployeeGateway employeeGateway = new EmployeeGateway(null);
            return employeeGateway.Insert(loginId, contactsId, fullName, firstName, middleInitial, lastName, type, state, isSalesman, requestProjectTime, deleted, salaried, eMail, assignableSrs, jobClassType, category, personalAgencyName, isVacationsManager, approveTimesheets, bourdenFactor, usHealthBenefitFactor, benefitFactorCad, benefitFactorUsd, crew);
        }



        /// <summary>
        /// Update employee (direct to DB)
        /// </summary>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalLoginId">originalLoginId</param>       
        /// <param name="originalContactsId">originalContactsId</param>
        /// <param name="originalFullName">originalFullName</param>
        /// <param name="originalFirstName">originalFirstName</param>
        /// <param name="originalMiddleInitial">originalMiddleInitial</param>
        /// <param name="originalLastName">originalLastName</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalIsSalesman">originalIsSalesman</param>
        /// <param name="originalRequestProjectTime">originalRequestProjectTime</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalSalaried">originalSalaried</param>
        /// <param name="originalEMail">originalEMail</param>
        /// <param name="originalAssignableSrs">originalAssignableSrs</param>
        /// <param name="originalJobClassType">originalJobClassType</param>
        /// <param name="originalCategory">originalCategory</param>
        /// <param name="originalPersonalAgencyName">originalPersonalAgencyName</param>
        /// <param name="originalIsVacationsManager">originalIsVacationsManager</param>
        /// <param name="originalApproveTimesheets">originalApproveTimesheets</param>
        /// <param name="originalBourdenFactor">originalBourdenFactor</param>
        /// <param name="originalUsHealthBenefitFactor">originalUsHealthBenefitFactor</param>
        /// <param name="originalBenefitFactorCad">originalBenefitFactorCad</param>
        /// <param name="originalBenefitFactorUsd">originalBenefitFactorUsd</param>
        /// <param name="originalCrew">originalCrew</param>
        ///
        /// <param name="newFullName">newFullName</param>
        /// <param name="newFirstName">newFirstName</param>
        /// <param name="newMiddleInitial">newMiddleInitial</param>
        /// <param name="newLastName">newLastName</param>
        /// <param name="newType">newType</param>
        /// <param name="newState">newState</param>
        /// <param name="newIsSalesman">newIsSalesman</param>
        /// <param name="newRequestProjectTime">newRequestProjectTime</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newSalaried">newSalaried</param>
        /// <param name="newEMail">newEMail</param>
        /// <param name="newAssignableSrs">newAssignableSrs</param>
        /// <param name="newJobClassType">newJobClassType</param>
        /// <param name="newCategory">newCategory</param>
        /// <param name="newPersonalAgencyName">nerPersonalAgencyName</param>
        /// <param name="newIsVacationsManager">newIsVacationsManager</param>
        /// <param name="newApproveTimesheets">newApproveTimesheets</param>
        /// <param name="newBourdenFactor">newBourdenFactor</param>
        /// <param name="newUsHealthBenefitFactor">newUsHealthBenefitFactor</param>
        /// <param name="newBenefitFactorCad">newBenefitFactorCad</param>
        /// <param name="newBenefitFactorUsd">newBenefitFactorUsd</param>
        /// <param name="newCrew">newCrew</param>
        public void UpdateDirect(int originalEmployeeId, int? originalLoginId, int? originalContactsId, string originalFullName, string originalFirstName, string originalMiddleInitial, string originalLastName, string originalType, string originalState, bool originalIsSalesman, bool originalRequestProjectTime, bool originalDeleted, bool originalSalaried, string originalEMail, bool originalAssignableSrs, string originalJobClassType, string originalCategory, string originalPersonalAgencyName, bool originalIsVacationsManager, bool originalApproveTimesheets, decimal? originalBourdenFactor, decimal? originalUsHealthBenefitFactor, decimal? originalBenefitFactorCad, decimal? originalBenefitFactorUsd, string originalCrew, string newFullName, string newFirstName, string newMiddleInitial, string newLastName, string newType, string newState, bool newIsSalesman, bool newRequestProjectTime, bool newDeleted, bool newSalaried, string newEMail, bool newAssignableSrs, string newJobClassType, string newCategory, string newPersonalAgencyName, bool newIsVacationsManager, bool newApproveTimesheets,  decimal? newBourdenFactor, decimal? newUsHealthBenefitFactor, decimal? newBenefitFactorCad, decimal? newBenefitFactorUsd, string newCrew)
        {
            EmployeeGateway employeeGateway = new EmployeeGateway(null);
            employeeGateway.Update(originalEmployeeId, originalLoginId, originalContactsId, originalFullName, originalFirstName, originalMiddleInitial, originalLastName, originalType, originalState, originalIsSalesman, originalRequestProjectTime, originalDeleted, originalSalaried, originalEMail, originalAssignableSrs, originalJobClassType, originalCategory, originalPersonalAgencyName, originalIsVacationsManager, originalApproveTimesheets, originalBourdenFactor, originalUsHealthBenefitFactor, originalBenefitFactorCad, originalBenefitFactorUsd, originalCategory, newFullName, newFirstName, newMiddleInitial, newLastName, newType, newState, newIsSalesman, newRequestProjectTime, newDeleted, newSalaried, newEMail, newAssignableSrs, newJobClassType, newCategory, newPersonalAgencyName, newIsVacationsManager, newApproveTimesheets, newBourdenFactor, newUsHealthBenefitFactor, newBenefitFactorCad, newBenefitFactorUsd, newCrew);
        }



        /// <summary>
        /// UpdateSalesman
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="isSalesman">isSalesman</param>
        public void UpdateSalesman(int employeeId, bool isSalesman)
        {
            EmployeeTDS.LFS_RESOURCES_EMPLOYEERow employeeRow = GetRow(employeeId);
            employeeRow.IsSalesman = isSalesman;
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        public void DeleteDirect(int originalEmployeeId)
        {
            EmployeeGateway employeeGateway = new EmployeeGateway(null);
            employeeGateway.Delete(originalEmployeeId);
        }



        /// <summary>
        /// GetAllFleetManagersEMails
        /// </summary>
        /// <returns>All Fleet Managers E-mails</returns>
        public string GetAllFleetManagersEMails()
        {
            string allFleetManagersMails = "";

            foreach (EmployeeTDS.LFS_RESOURCES_EMPLOYEERow row in (EmployeeTDS.LFS_RESOURCES_EMPLOYEEDataTable)Table)
            {
                if (!row.IseMailNull())
                {
                    allFleetManagersMails = allFleetManagersMails + row.eMail + ", ";
                }
            }

            if (allFleetManagersMails.Length > 0)
            {
                allFleetManagersMails = allFleetManagersMails.Substring(0, allFleetManagersMails.Length - 2);
            }

            return allFleetManagersMails;
        }



        /// <summary>
        /// GetAllFleetManagersNames
        /// </summary>        
        /// <returns>All Fleet Managers E-mails</returns>
        public string GetAllFleetManagersNames()
        {
            string allFleetManagersNames = "";

            foreach (EmployeeTDS.LFS_RESOURCES_EMPLOYEERow row in (EmployeeTDS.LFS_RESOURCES_EMPLOYEEDataTable)Table)
            {
                allFleetManagersNames = allFleetManagersNames + row.FirstName + " " + row.LastName + ", ";
            }

            if (allFleetManagersNames.Length > 0)
            {
                allFleetManagersNames = allFleetManagersNames.Substring(0, allFleetManagersNames.Length - 2);
            }

            return allFleetManagersNames;
        }



        /// <summary>
        /// IsValidApproveTimesheetsManager
        /// </summary>
        /// <param name="employeeIdToApprove">employeeIdToApprove</param>
        /// <param name="employeeIdApproveManager">employeeIdApproveManager</param>
        /// <returns>TRUE OR FALSE</returns>
        public bool IsValidApproveTimesheetsManager(int employeeIdToApprove, int employeeIdApproveManager)
        {
            EmployeeGateway employeeGatewayForEmployeeApproveManager = new EmployeeGateway(new DataSet());
            employeeGatewayForEmployeeApproveManager.LoadByEmployeeId(employeeIdApproveManager);

            EmployeeGateway employeeGatewayForEmployeeToApprove = new EmployeeGateway(new DataSet());
            employeeGatewayForEmployeeToApprove.LoadByEmployeeId(employeeIdToApprove);

            if (!employeeGatewayForEmployeeApproveManager.GetApproveTimesheets(employeeIdApproveManager))
            {
                return false;
            }
            else
            {
                if (employeeIdToApprove == employeeIdApproveManager)
                {
                    return true;
                }
                else
                {
                    string employeeToApproveType = employeeGatewayForEmployeeToApprove.GetType(employeeIdToApprove);
                    string employeeApproveManagerType = employeeGatewayForEmployeeApproveManager.GetType(employeeIdApproveManager);

                    string employeeToApproveCategory = employeeGatewayForEmployeeToApprove.GetCategory(employeeIdToApprove);

                    if (ContainsType(employeeToApproveType, employeeApproveManagerType))
                    {
                        EmployeeGateway employeeGateway = new EmployeeGateway();
                        if (employeeGateway.IsEmployeeWithApproveTimesheetInCategory(employeeIdApproveManager, employeeToApproveCategory))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }



        /// <summary>
        /// ContainsType
        /// </summary>
        /// <param name="employeeToApproveType">employeeToApproveType</param>
        /// <param name="employeeApproveManagerType">employeeApproveManagerType</param>
        /// <returns>True or False</returns>
        public bool ContainsType(string employeeToApproveType, string employeeApproveManagerType)
        {
            if (employeeApproveManagerType.Contains("CA") && employeeToApproveType.Contains("CA"))
            {
                return true;
            }
            else
            {
                if (employeeApproveManagerType.Contains("US") && employeeToApproveType.Contains("US"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }



        /// <summary>
        /// GetAllCategoryManagers
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>All Category Managers</returns>
        public string GetAllCategoryManagers(string category, int employeeId)
        {
            string allCategoryManagers = "";

            EmployeeInformationBasicInformationGateway employeeInformationBasicInformationGateway = new EmployeeInformationBasicInformationGateway();
            employeeInformationBasicInformationGateway.LoadByEmployeeId(employeeId);

            string employeeType = "";

            if (employeeInformationBasicInformationGateway.GetType(employeeId).Contains("CA"))
            {
                employeeType = "%CA";
            }
            else
            {
                employeeType = "%US";
            }

            EmployeeGateway employeeGateway = new EmployeeGateway(Data);
            employeeGateway.LoadApproveManagersByCategoryType(category, employeeType);

            foreach (EmployeeTDS.LFS_RESOURCES_EMPLOYEERow row in (EmployeeTDS.LFS_RESOURCES_EMPLOYEEDataTable)Table)
            {
                if (allCategoryManagers.Length > 0)
                {
                    allCategoryManagers = allCategoryManagers + ", " + row.LastName + " " + row.FirstName;
                }
                else
                {
                    allCategoryManagers = allCategoryManagers + row.LastName + " " + row.FirstName;
                }
            }

            //if (allCategoryManagers[allCategoryManagers.Length-1] == ',')
            //{
            //    allCategoryManagers = allCategoryManagers.Substring(0, allCategoryManagers.Length - 2);
            //}

            return allCategoryManagers;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns></returns>
        private EmployeeTDS.LFS_RESOURCES_EMPLOYEERow GetRow(int employeeId)
        {
            return ((EmployeeTDS.LFS_RESOURCES_EMPLOYEEDataTable)Table).FindByEmployeeID(employeeId);
        }



    }
}