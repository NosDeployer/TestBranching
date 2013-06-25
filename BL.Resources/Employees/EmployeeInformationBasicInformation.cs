using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeInformationBasicInformation
    /// </summary>
    public class EmployeeInformationBasicInformation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeInformationBasicInformation()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeInformationBasicInformation(DataSet data)
            : base(data, "BasicInformation")
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
        /// LoadByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadByEmployeeId(int employeeId, int companyId)
        {
            EmployeeInformationBasicInformationGateway employeeInformationBasicInformationGateway = new EmployeeInformationBasicInformationGateway(Data);
            employeeInformationBasicInformationGateway.LoadByEmployeeId(employeeId);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="firstName">firstName</param>
        /// <param name="lastName">lastName</param>
        /// <param name="type">type</param>
        /// <param name="state">state</param>
        /// <param name="isSalesman">isSalesman</param>
        /// <param name="requestProjectTime">requestProjectTime</param>
        /// <param name="salaried">salaried</param>
        /// <param name="eMail">eMail</param>        
        /// <param name="newAssignableSrs">newAssignableSrs</param>
        /// <param name="jobClass">jobClass</param>
        /// <param name="category">category</param>
        /// <param name="personalAgencyName">personalAgencyName</param>
        /// <param name="isVacationsManager">isVacationsManager</param>
        /// <param name="approveTimesheets">approveTimesheets</param>
        /// <param name="crew">crew</param>
        public void Update(int employeeId, string firstName, string lastName, string type, string state, bool isSalesman, bool requestProjectTime, bool salaried, string eMail, bool newAssignableSrs, string jobClass, string category, string personalAgencyName, bool isVacationsManager, bool approveTimesheets, string crew)
        {
            EmployeeInformationTDS.BasicInformationRow row = GetRow(employeeId);
 
            // General Data            
            row.FirstName = firstName;
            row.LastName = lastName;
            row.Type = type;
            row.State = state;
            row.IsSalesman = isSalesman;
            row.RequestProjectTime = requestProjectTime;
            row.Salaried = salaried;
            if (eMail.Trim() != "") row.eMail = eMail; else row.SeteMailNull();
            row.AssignableSRS = newAssignableSrs;
            if (jobClass.Trim() != "") row.JobClassType = jobClass; else row.SetJobClassTypeNull();
            row.Category = category;
            if (personalAgencyName.Trim() != "") row.PersonalAgencyName = personalAgencyName; else row.SetPersonalAgencyNameNull();
            row.IsVacationsManager = isVacationsManager;
            row.ApproveTimesheets = approveTimesheets;
            if (crew.Trim() != "") row.Crew = crew; else row.SetCrewNull();
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            EmployeeInformationTDS employeeInformationChanges = (EmployeeInformationTDS)Data.GetChanges();

            if (employeeInformationChanges.BasicInformation.Rows.Count > 0)
            {
                EmployeeInformationBasicInformationGateway employeeInformationBasicInformationGateway = new EmployeeInformationBasicInformationGateway(employeeInformationChanges);

                // Update employee
                foreach (EmployeeInformationTDS.BasicInformationRow basicInformationRow in (EmployeeInformationTDS.BasicInformationDataTable)employeeInformationChanges.BasicInformation)
                {
                    // Unchanged values
                    int employeeId = basicInformationRow.EmployeeID;
                    int? loginId = null; if(!basicInformationRow.IsLoginIDNull()) loginId =  basicInformationRow.LoginID;
                    int? contactsId = null; if (!basicInformationRow.IsContactsIDNull()) contactsId = basicInformationRow.ContactsID;
                    string middleInitial = ""; if (!basicInformationRow.IsMiddleInitialNull()) middleInitial = basicInformationRow.MiddleInitial;
                    bool deleted = basicInformationRow.Deleted;
                    decimal? bourdenFactor = null; if (!basicInformationRow.IsBourdenFactorNull()) bourdenFactor = (decimal)basicInformationRow.BourdenFactor;
                    decimal? usHealthBenefitFactor = null; if (!basicInformationRow.IsUSHealthBenefitFactorNull()) usHealthBenefitFactor = (decimal)basicInformationRow.USHealthBenefitFactor;
                    decimal? benefitFactorCad = null; if (!basicInformationRow.IsBenefitFactorCadNull()) benefitFactorCad = (decimal)basicInformationRow.BenefitFactorCad;
                    decimal? benefitFactorUsd = null; if (!basicInformationRow.IsBenefitFactorUsdNull()) benefitFactorUsd = (decimal)basicInformationRow.BenefitFactorUsd;

                    // Original values
                    string originalFirstName = employeeInformationBasicInformationGateway.GetFirstNameOriginal(employeeId);
                    string originalLastName = employeeInformationBasicInformationGateway.GetLastNameOriginal(employeeId);
                    string originalFullName = originalFirstName +  ' ' + originalLastName;
                    string originalType = employeeInformationBasicInformationGateway.GetTypeOriginal(employeeId);
                    string originalState = employeeInformationBasicInformationGateway.GetStateOriginal(employeeId);
                    bool originalIsSalessman = employeeInformationBasicInformationGateway.GetIsSalesmanOriginal(employeeId);
                    bool originalRequestProjectTime = employeeInformationBasicInformationGateway.GetRequestProjectTimeOriginal(employeeId);
                    bool originalSalaried = employeeInformationBasicInformationGateway.GetSalariedOriginal(employeeId);
                    string originalEMail = employeeInformationBasicInformationGateway.GeteMailOriginal(employeeId);
                    bool originalAssignableSrs = employeeInformationBasicInformationGateway.GetAssignableSRSOriginal(employeeId);
                    string originalJobClassType = employeeInformationBasicInformationGateway.GetJobClassTypeOriginal(employeeId);
                    string originalCategory = employeeInformationBasicInformationGateway.GetCategoryOriginal(employeeId);
                    string originalPersonalAgencyName = employeeInformationBasicInformationGateway.GetPersonalAgencyNameOriginal(employeeId);
                    bool originalIsVacationsManager = employeeInformationBasicInformationGateway.GetIsVacationsManagerOriginal(employeeId);
                    bool originalApproveTimesheets = employeeInformationBasicInformationGateway.GetApproveTimesheetsOriginal(employeeId);
                    string originalCrew = employeeInformationBasicInformationGateway.GetCrewOriginal(employeeId);

                    // New variables
                    string newFirstName = employeeInformationBasicInformationGateway.GetFirstName(employeeId);
                    string newLastName = employeeInformationBasicInformationGateway.GetLastName(employeeId);
                    string newFullName = newFirstName + ' ' + newLastName;
                    string newType = employeeInformationBasicInformationGateway.GetType(employeeId);
                    string newState = employeeInformationBasicInformationGateway.GetState(employeeId);
                    bool newIsSalessman = employeeInformationBasicInformationGateway.GetIsSalesman(employeeId);
                    bool newRequestProjectTime = employeeInformationBasicInformationGateway.GetRequestProjectTime(employeeId);
                    bool newSalaried = employeeInformationBasicInformationGateway.GetSalaried(employeeId);
                    string newEMail = employeeInformationBasicInformationGateway.GeteMail(employeeId);
                    bool newAssignableSrs = employeeInformationBasicInformationGateway.GetAssignableSRS(employeeId);
                    string newJobClassType = employeeInformationBasicInformationGateway.GetJobClassType(employeeId);
                    string newCategory = employeeInformationBasicInformationGateway.GetCategory(employeeId);
                    string newPersonalAgencyName = employeeInformationBasicInformationGateway.GetPersonalAgencyName(employeeId);
                    bool newIsVacationsManager = employeeInformationBasicInformationGateway.GetIsVacationsManager(employeeId);
                    bool newApproveTimesheets = employeeInformationBasicInformationGateway.GetApproveTimesheets(employeeId);
                    string newCrew = employeeInformationBasicInformationGateway.GetCrew(employeeId);

                    // ... Update 
                    Employee employee = new Employee(null);
                    employee.UpdateDirect(employeeId, loginId, contactsId, originalFullName, originalFirstName, middleInitial, originalLastName, originalType, originalState, originalIsSalessman, originalRequestProjectTime, deleted, originalSalaried, originalEMail, originalAssignableSrs, originalJobClassType, originalCategory, originalPersonalAgencyName, originalIsVacationsManager, originalApproveTimesheets, bourdenFactor, usHealthBenefitFactor, benefitFactorCad, benefitFactorUsd, originalCrew, newFullName, newFirstName, middleInitial, newLastName, newType, newState, newIsSalessman, newRequestProjectTime, deleted, newSalaried, newEMail, newAssignableSrs, newJobClassType, newCategory, newPersonalAgencyName, newIsVacationsManager, newApproveTimesheets,  bourdenFactor, usHealthBenefitFactor, benefitFactorCad, benefitFactorUsd, newCrew);
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //   

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Obtained row</returns>
        private EmployeeInformationTDS.BasicInformationRow GetRow(int employeeId)
        {
            EmployeeInformationTDS.BasicInformationRow row = ((EmployeeInformationTDS.BasicInformationDataTable)Table).FindByEmployeeID(employeeId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.Employee.EmployeeInformationBasicInformation.GetRow");
            }

            return row;
        }



    }
}