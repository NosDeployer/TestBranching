using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeAdd
    /// </summary>
    public class EmployeeAdd : TableModule
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeAdd()
            : base("EmployeeAdd")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeAdd(DataSet data)
            : base(data, "EmployeeAdd")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeesAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new employee
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <param name="contactId">contactId</param>
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
        /// <param name="assignableSRS">assignableSRS</param>
        /// <param name="inDataBase">inDataBase</param>        
        /// <param name="jobClass">jobClass</param>
        /// <param name="category">category</param>
        /// <param name="personalAgencyName">personalAgencyName</param>
        /// <param name="isVacationsManager">isVacationsManager</param>
        /// <param name="approveTimesheets">approveTimesheets</param>
        /// <param name="bourdenFactor">bourdenFactor</param>
        /// <param name="usHealthBenefitFactor">usHealthBenefitFactor</param>
        /// <param name="benefitFactorCad">benefitFactorCad</param>
        /// <param name="benefitFactorUsd">benefitFactorUsd</param>
        public int Insert(int? loginId, int? contactId, string fullName, string firstName, string middleInitial, string lastName, string type, string state, bool isSalesman, bool requestProjectTime, bool deleted, bool salaried, string eMail, bool assignableSRS, bool inDataBase, string jobClass, string category, string personalAgencyName, bool isVacationsManager, bool approveTimesheets, decimal? bourdenFactor, decimal? usHealthBenefitFactor, decimal? benefitFactorCad,  decimal? benefitFactorUsd)
        {
            EmployeesAddTDS.EmployeeAddRow row = ((EmployeesAddTDS.EmployeeAddDataTable)Table).NewEmployeeAddRow();

            row.EmployeeID = GetNewEmployeeId();
            if (loginId.HasValue) row.LoginID = (int)loginId; else row.IsLoginIDNull();
            if (contactId.HasValue) row.ContactsID = (int)contactId; else row.IsContactsIDNull();
            row.FullName = fullName;
            row.FirstName = firstName;
            if (middleInitial != "") row.MiddleInitial = middleInitial; else row.IsMiddleInitialNull();
            row.LastName = lastName;
            row.Type = type;
            row.State = state;
            row.IsSalesman = isSalesman;
            row.RequestProjectTime = requestProjectTime;
            row.Deleted = deleted;
            row.Salaried = salaried;
            if (eMail != "") row.eMail = eMail; else row.IseMailNull();
            row.AssignableSRS = assignableSRS;
            row.InDatabase = inDataBase;
            if (jobClass != "") row.JobClassType = jobClass; else row.IsJobClassTypeNull();
            row.Category = category;
            if (personalAgencyName != "") row.PersonalAgencyName = personalAgencyName; else row.IsPersonalAgencyNameNull();
            row.IsVacationsManager = isVacationsManager;
            row.ApproveTimesheets = approveTimesheets;
            if (bourdenFactor.HasValue) row.BourdenFactor = (decimal)bourdenFactor; else row.IsBourdenFactorNull();
            if (usHealthBenefitFactor.HasValue) row.USHealthBenefitFactor = (decimal)usHealthBenefitFactor; else row.IsUSHealthBenefitFactorNull();
            if (benefitFactorCad.HasValue) row.BenefitFactorCad = (decimal)benefitFactorCad; else row.IsBenefitFactorCadNull();
            if (benefitFactorUsd.HasValue) row.BenefitFactorUsd = (decimal)benefitFactorUsd; else row.IsBenefitFactorUsdNull();
            
            ((EmployeesAddTDS.EmployeeAddDataTable)Table).AddEmployeeAddRow(row);

            return row.EmployeeID;
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <returns>employeeId</returns>
        public int Save()
        {
            EmployeesAddTDS employeeAddChanges = (EmployeesAddTDS)Data.GetChanges();
            int employeeId = 0;

            if (employeeAddChanges != null)
            {
                if (employeeAddChanges.EmployeeAdd.Rows.Count > 0)
                {
                    EmployeeAddGateway employeeNavigatorGateway = new EmployeeAddGateway(employeeAddChanges);

                    // Update employees
                    foreach (EmployeesAddTDS.EmployeeAddRow row in (EmployeesAddTDS.EmployeeAddDataTable)employeeAddChanges.EmployeeAdd)
                    {
                        // Insert new employees 
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            Employee employee = new Employee(null);
                            int? loginId = null; if (!row.IsLoginIDNull()) loginId = row.LoginID;
                            int? contactsId = null; if (!row.IsContactsIDNull()) contactsId = row.ContactsID;
                            string middleInitial = ""; if (!row.IsMiddleInitialNull()) middleInitial = row.MiddleInitial;
                            string email = ""; if (!row.IseMailNull()) email = row.eMail;
                            bool assignableSrs = row.AssignableSRS;
                            string jobClass = ""; if (!row.IsJobClassTypeNull()) jobClass = row.JobClassType;
                            string personalAgencyName = ""; if (!row.IsPersonalAgencyNameNull()) personalAgencyName = row.PersonalAgencyName;
                            bool isVacationsManager = row.IsVacationsManager;
                            bool approveTimesheets = row.ApproveTimesheets;
                            decimal? bourdenFactor = null; if (!row.IsBourdenFactorNull()) bourdenFactor = (decimal)row.BourdenFactor;
                            decimal? usHealthBenefitFactor = null; if (!row.IsUSHealthBenefitFactorNull()) usHealthBenefitFactor = (decimal)row.USHealthBenefitFactor;
                            decimal? benefitFactorCad = null; if (!row.IsBenefitFactorCadNull()) benefitFactorCad = (decimal)row.BenefitFactorCad;
                            decimal? benefitFactorUsd = null; if (!row.IsBenefitFactorUsdNull()) benefitFactorUsd = (decimal)row.BenefitFactorUsd;
                            string crew = ""; //TODO CREW

                            employeeId = employee.InsertDirect(loginId, contactsId, row.FullName, row.FirstName, middleInitial, row.LastName, row.Type, row.State, row.IsSalesman, row.RequestProjectTime, row.Deleted, row.Salaried, email, assignableSrs, jobClass, row.Category, personalAgencyName, isVacationsManager, approveTimesheets, bourdenFactor, usHealthBenefitFactor, benefitFactorCad, benefitFactorUsd, crew);
                            
                            // Employee Categories Approve Timesheets
                            EmployeeCategoryApproveTimesheets employeeCategoryApproveTimesheets = new EmployeeCategoryApproveTimesheets(null);
                            employeeCategoryApproveTimesheets.InsertDirect(employeeId, "Field", false, false);
                            employeeCategoryApproveTimesheets.InsertDirect(employeeId, "Field 44", false, false);
                            employeeCategoryApproveTimesheets.InsertDirect(employeeId, "Mechanic/Manufactoring", false, false);
                            employeeCategoryApproveTimesheets.InsertDirect(employeeId, "Office/Admin", false, false);
                            employeeCategoryApproveTimesheets.InsertDirect(employeeId, "Special Forces", false, false);
                        }                      
                    }
                }
            }

            return employeeId;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetNewEmployeeId
        /// </summary>
        /// <returns>newEmployeeId</returns>
        private int GetNewEmployeeId()
        {
            int newEmployeeId = 0;

            foreach (EmployeesAddTDS.EmployeeAddRow row in (EmployeesAddTDS.EmployeeAddDataTable)Table)
            {
                if (newEmployeeId < row.EmployeeID)
                {
                    newEmployeeId = row.EmployeeID;
                }
            }

            newEmployeeId++;

            return newEmployeeId;
        }



    }
}