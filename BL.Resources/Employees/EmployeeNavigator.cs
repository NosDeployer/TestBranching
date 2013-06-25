using System.Data;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.Common;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeNavigator
    /// </summary>
    public class EmployeeNavigator : TableModule
    {
        //// ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeNavigator()
            : base("EmployeeNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeNavigator(DataSet data)
            : base(data, "EmployeeNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="whereClause">whereClause</param>
        /// <param name="orderByClause">orderByClause</param>
        /// <param name="conditionValue">conditionValue</param>
        /// <param name="textForSearch">textForSearch</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="resourceType">resourceType</param>
        public void Load(string whereClause, string orderByClause, string conditionValue, string textForSearch, int companyId,  string resourceType)
        {
            EmployeeNavigatorGateway employeeNavigatorGateway = new EmployeeNavigatorGateway(Data);
            employeeNavigatorGateway.LoadWhereOrderBy(whereClause, orderByClause, conditionValue, textForSearch);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="selected">selected</param>
        public void Update(int employeeId, bool selected)
        {
            EmployeeNavigatorTDS.EmployeeNavigatorRow employeeRow = GetRow(employeeId);
            employeeRow.Selected = selected;
        }



        /// <summary>
        /// UpdateSalesman
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="isSalesman">isSalesman</param>
        public void UpdateSalesman(int employeeId, bool isSalesman)
        {
            EmployeeNavigatorTDS.EmployeeNavigatorRow employeeRow = GetRow(employeeId);
            employeeRow.IsSalesman = isSalesman;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        public void Delete(int employeeId)
        {
            EmployeeNavigatorTDS.EmployeeNavigatorRow employeeRow = GetRow(employeeId);
            employeeRow.Deleted = true;
        }



        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            EmployeeNavigatorTDS employeeNavigatorChanges = (EmployeeNavigatorTDS)Data.GetChanges();

            if (employeeNavigatorChanges != null)
            {
                if (employeeNavigatorChanges.EmployeeNavigator.Rows.Count > 0)
                {
                    EmployeeNavigatorGateway employeeNavigatorGateway = new EmployeeNavigatorGateway(employeeNavigatorChanges);

                    // Update employees
                    foreach (EmployeeNavigatorTDS.EmployeeNavigatorRow row in (EmployeeNavigatorTDS.EmployeeNavigatorDataTable)employeeNavigatorChanges.EmployeeNavigator)
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
                            string jobClassType = ""; if (!row.IsJobClassTypeNull()) jobClassType = row.JobClassType;
                            string personalAgencyName = ""; if (!row.IsPersonalAgencyNameNull()) personalAgencyName = row.PersonalAgencyName;
                            decimal? bourdenFactor = null; if (!row.IsBourdenFactorNull()) bourdenFactor = (decimal)row.BourdenFactor;
                            decimal? usHealthBenefitFactor = null; if (!row.IsUSHealthBenefitFactorNull()) usHealthBenefitFactor = (decimal)row.USHealthBenefitFactor;
                            decimal? standardBenefitFactorCad = null; if (!row.IsStandardBenefitFactorCadNull()) standardBenefitFactorCad = (decimal)row.StandardBenefitFactorCad;
                            decimal? standardBenefitFactorUsd = null; if (!row.IsStandardBenefitFactorUsdNull()) standardBenefitFactorUsd = (decimal)row.StandardBenefitFactorUsd;
                            string crew = ""; if (!row.IsCrewNull()) crew = row.Crew;
                            employee.InsertDirect(loginId, contactsId, row.FullName, row.FirstName, middleInitial, row.LastName, row.Type, row.State, row.IsSalesman, row.RequestProjectTime, row.Deleted, row.Salaried, email, assignableSrs, jobClassType, row.Category, personalAgencyName, row.IsVacationsManager, row.ApproveTimesheets, bourdenFactor, usHealthBenefitFactor, standardBenefitFactorCad, standardBenefitFactorUsd, crew);
                        }

                        // Update employees
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            // non editable values
                            int employeeId = row.EmployeeID;
                            int? originalLoginId = row.LoginID;
                            int? originalContactsId = row.ContactsID;
                            bool originalDeleted = false;
                            decimal? originalBourdenFactor = null; if (!row.IsBourdenFactorNull()) originalBourdenFactor = (decimal)row.BourdenFactor;
                            decimal? originalUSHealthBenefitFactor = null; if (!row.IsUSHealthBenefitFactorNull()) originalUSHealthBenefitFactor = (decimal)row.USHealthBenefitFactor;
                            decimal? originalStandardBenefitFactorCad = null; if (!row.IsStandardBenefitFactorCadNull()) originalStandardBenefitFactorCad = (decimal)row.StandardBenefitFactorCad;
                            decimal? originalStandardBenefitFactorUsd = null; if (!row.IsStandardBenefitFactorUsdNull()) originalStandardBenefitFactorUsd = (decimal)row.StandardBenefitFactorUsd;

                            // original values
                            string originalFullName = employeeNavigatorGateway.GetFullNameOriginal(employeeId);
                            string originalFirstName = employeeNavigatorGateway.GetFirstNameOriginal(employeeId);
                            string originalMiddleInitial = employeeNavigatorGateway.GetMiddleInitialOriginal(employeeId);
                            string originalLastName = employeeNavigatorGateway.GetLastNameOriginal(employeeId);
                            string originalType = employeeNavigatorGateway.GetTypeOriginal(employeeId);
                            string originalState = employeeNavigatorGateway.GetStateOriginal(employeeId);
                            bool originalIsSalesman = employeeNavigatorGateway.GetIsSalesmanOriginal(employeeId);
                            bool originalRequestProjectTime = employeeNavigatorGateway.GetRequestProjectTimeOriginal(employeeId);
                            bool originalSalaried = employeeNavigatorGateway.GetSalariedOriginal(employeeId);
                            string originalEMail = employeeNavigatorGateway.GetEMailOriginal(employeeId);
                            bool originalAssignableSrs = employeeNavigatorGateway.GetAssignableSRSOriginal(employeeId);
                            string originalJobClassType = employeeNavigatorGateway.GetJobClassTypeOriginal(employeeId);
                            string originalCategory = employeeNavigatorGateway.GetCategoryOriginal(employeeId);
                            string originalPersonalAgencyName = employeeNavigatorGateway.GetPersonalAgencyNameOriginal(employeeId);
                            bool originalIsVacationsManager = employeeNavigatorGateway.GetIsVacationsManagerOriginal(employeeId);
                            bool originalApproveTimesheets = employeeNavigatorGateway.GetApproveTimesheetsOriginal(employeeId);
                            
                            // new values
                            string newFullName = employeeNavigatorGateway.GetFullName(employeeId);
                            string newFirstName = employeeNavigatorGateway.GetFirstName(employeeId);
                            string newMiddleInitial = employeeNavigatorGateway.GetMiddleInitial(employeeId);
                            string newLastName = employeeNavigatorGateway.GetLastName(employeeId);
                            string newType = employeeNavigatorGateway.GetType(employeeId);
                            string newState = employeeNavigatorGateway.GetState(employeeId);
                            bool newIsSalesman = employeeNavigatorGateway.GetIsSalesman(employeeId);
                            bool newRequestProjectTime = employeeNavigatorGateway.GetRequestProjectTime(employeeId);
                            bool newSalaried = employeeNavigatorGateway.GetSalaried(employeeId);
                            string newEMail = employeeNavigatorGateway.GetEMail(employeeId);
                            bool newAssignableSrs = employeeNavigatorGateway.GetAssignableSRS(employeeId);
                            string newJobClassType = employeeNavigatorGateway.GetJobClassType(employeeId);
                            string newCategory = employeeNavigatorGateway.GetCategory(employeeId);
                            string newPersonalAgencyName = employeeNavigatorGateway.GetPersonalAgencyName(employeeId);
                            bool newIsVacationsManager = employeeNavigatorGateway.GetIsVacationsManager(employeeId);
                            bool newApproveTimesheets = employeeNavigatorGateway.GetApproveTimesheets(employeeId);
                            string crew = ""; if (!row.IsCrewNull()) crew = row.Crew;//TODO CREW
                            Employee employee = new Employee(null);
                            employee.UpdateDirect(employeeId, originalLoginId, originalContactsId, originalFullName, originalFirstName, originalMiddleInitial, originalLastName, originalType, originalState, originalIsSalesman, originalRequestProjectTime, originalDeleted, originalSalaried, originalEMail, originalAssignableSrs, originalJobClassType, originalCategory, originalPersonalAgencyName, originalIsVacationsManager, originalApproveTimesheets, originalBourdenFactor, originalUSHealthBenefitFactor, originalStandardBenefitFactorCad, originalStandardBenefitFactorUsd, crew, newFullName, newFirstName, newMiddleInitial, newLastName, newType, newState, newIsSalesman, newRequestProjectTime, originalDeleted, newSalaried, newEMail, newAssignableSrs, newJobClassType, newCategory, newPersonalAgencyName, newIsVacationsManager, newApproveTimesheets, originalBourdenFactor, originalUSHealthBenefitFactor, originalStandardBenefitFactorCad, originalStandardBenefitFactorUsd, crew);
                        }

                        // Deleted employees 
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            Employee employee = new Employee(null);
                            employee.DeleteDirect(row.EmployeeID);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// IsInUse
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>int</returns>
        public int IsInUse(int employeeId)
        {
            EmployeeNavigatorGateway employeeNavigatorGateway = new EmployeeNavigatorGateway(new DataSet());
            int categoryOfUsage = employeeNavigatorGateway.IsInUse(employeeId);

            return categoryOfUsage;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns></returns>
        private EmployeeNavigatorTDS.EmployeeNavigatorRow GetRow(int employeeId)
        {
            return ((EmployeeNavigatorTDS.EmployeeNavigatorDataTable)Table).FindByEmployeeID(employeeId);
        }



        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>New ID</returns>
        private int GetNewEmployeeId()
        {
            int newEmployeeId = 0;

            foreach (EmployeeNavigatorTDS.EmployeeNavigatorRow row in (EmployeeNavigatorTDS.EmployeeNavigatorDataTable)Table)
            {
                if (newEmployeeId < row.EmployeeID)
                {
                    newEmployeeId = row.EmployeeID;
                }
            }

            newEmployeeId++;

            return newEmployeeId;
        }



        /// <summary>
        /// GetPreviousId
        /// </summary>
        /// <param name="employeeNavigatorTDS">employeeNavigatorTDS</param>
        /// <param name="currentEmployeeId">currentEmployeeId</param>
        /// <returns>prevEmployeeId</returns>
        public static int GetPreviousId(EmployeeNavigatorTDS employeeNavigatorTDS, int currentEmployeeId)
        {
            int prevEmployeeId = currentEmployeeId;

            for (int i = 0; i < employeeNavigatorTDS.EmployeeNavigator.DefaultView.Count; i++)
            {
                if ((int)employeeNavigatorTDS.EmployeeNavigator.DefaultView[i]["EmployeeID"] == currentEmployeeId)
                {
                    if (i == 0)
                    {
                        prevEmployeeId = currentEmployeeId;
                    }
                    else
                    {
                        prevEmployeeId = (int)employeeNavigatorTDS.EmployeeNavigator.DefaultView[i - 1]["EmployeeID"];
                    }

                    break;
                }
            }

            return prevEmployeeId;
        }



        /// <summary>
        /// GetNextId
        /// </summary>
        /// <param name="employeeNavigatorTDS">employeeNavigatorTDS</param>
        /// <param name="currentEmployeeId">currentEmployeeId</param>
        /// <returns>nextEmployeeId</returns>
        public static int GetNextId(EmployeeNavigatorTDS employeeNavigatorTDS, int currentEmployeeId)
        {
            int nextEmployeeId = currentEmployeeId;

            for (int i = 0; i < employeeNavigatorTDS.EmployeeNavigator.DefaultView.Count; i++)
            {
                if ((int)employeeNavigatorTDS.EmployeeNavigator.DefaultView[i]["EmployeeID"] == currentEmployeeId)
                {
                    if (i == employeeNavigatorTDS.EmployeeNavigator.DefaultView.Count - 1)
                    {
                        nextEmployeeId = currentEmployeeId;
                    }
                    else
                    {
                        nextEmployeeId = (int)employeeNavigatorTDS.EmployeeNavigator.DefaultView[i + 1]["EmployeeID"];
                    }
                    break;
                }
            }

            return nextEmployeeId;
        }



    }
}