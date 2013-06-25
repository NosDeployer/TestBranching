using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// PersonalAgencyInformation
    /// </summary>
    public class PersonalAgencyInformation : TableModule
    {
        // ///////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PersonalAgencyInformation()
            : base("PersonalAgencyInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PersonalAgencyInformation(DataSet data)
            : base(data, "PersonalAgencyInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PersonalAgencyInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new size
        /// </summary>
        /// <param name="personalAgencyName">personalAgencyName</param>
        /// <param name="companyId">companyId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(string personalAgencyName, int companyId, bool deleted, bool inDatabase)
        {
            PersonalAgencyInformationTDS.PersonalAgencyInformationRow row = ((PersonalAgencyInformationTDS.PersonalAgencyInformationDataTable)Table).NewPersonalAgencyInformationRow();

            row.PersonalAgencyName = personalAgencyName;
            row.COMPANY_ID = companyId;
            row.Deleted = deleted;
            row.InDatabase = inDatabase;
            row.Selected = false;

            ((PersonalAgencyInformationTDS.PersonalAgencyInformationDataTable)Table).AddPersonalAgencyInformationRow(row);
        }



        /// <summary>
        /// Update personalAgencyName
        /// </summary>
        /// <param name="originalPersonalAgencyName">originalPersonalAgencyName</param>
        /// <param name="newPersonalAgencyName">newPersonalAgencyName</param>
        /// <param name="companyId">companyId</param>
        public void Update(string originalPersonalAgencyName, string newPersonalAgencyName, int companyId)
        {
            PersonalAgencyInformationTDS.PersonalAgencyInformationRow row = GetRow(originalPersonalAgencyName, companyId);
            row.PersonalAgencyName = newPersonalAgencyName;
            row.NewPersonalAgencyName = originalPersonalAgencyName;
        }



        /// <summary>
        /// Update Selected
        /// </summary>
        /// <param name="personalAgencyName">personalAgencyName</param>
        /// <param name="companyId">companyId</param>
        /// <param name="selected">selected</param>
        public void UpdateSelected(string personalAgencyName, int companyId, bool selected)
        {
            PersonalAgencyInformationTDS.PersonalAgencyInformationRow row = GetRow(personalAgencyName, companyId);
            row.Selected = selected;
        }



        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="personalAgencyName">personalAgencyName</param>
        /// <param name="companyId">companyId</param>
        public void Delete(string personalAgencyName, int companyId)
        {
            PersonalAgencyInformationTDS.PersonalAgencyInformationRow row = GetRow(personalAgencyName, companyId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all personalAgencyName to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            PersonalAgencyInformationTDS personalAgencyInformationChanges = (PersonalAgencyInformationTDS)Data.GetChanges();

            if (personalAgencyInformationChanges != null)
            {
                if (personalAgencyInformationChanges.PersonalAgencyInformation.Rows.Count > 0)
                {
                    PersonalAgencyInformationGateway sizeInformationGateway = new PersonalAgencyInformationGateway(personalAgencyInformationChanges);

                    foreach (PersonalAgencyInformationTDS.PersonalAgencyInformationRow row in (PersonalAgencyInformationTDS.PersonalAgencyInformationDataTable)personalAgencyInformationChanges.PersonalAgencyInformation)
                    {
                        // Insert new personal agency 
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            EmployeePersonalAgencyGateway employeePersonalAgencyGateway = new EmployeePersonalAgencyGateway();
                            EmployeePersonalAgency employeePersonalAgency = new EmployeePersonalAgency(null);

                            if (!employeePersonalAgencyGateway.ExistPersonalAgency(row.PersonalAgencyName, row.COMPANY_ID))
                            {
                                employeePersonalAgency.InsertDirect(row.PersonalAgencyName, row.COMPANY_ID, row.Deleted);
                            }
                            else
                            {
                                employeePersonalAgency.UnDeleteDirect(row.PersonalAgencyName, row.COMPANY_ID);
                            }
                        }

                        // Update personal agency
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            string originalPersonalAgencyName = row.NewPersonalAgencyName;
                            string newPersonalAgencyName = row.PersonalAgencyName;
                            int originalCompanyId = companyId;

                            EmployeePersonalAgencyGateway employeePersonalAgencyGateway = new EmployeePersonalAgencyGateway();
                            EmployeePersonalAgency employeePersonalAgency = new EmployeePersonalAgency(null);

                            if (!employeePersonalAgencyGateway.ExistPersonalAgency(row.PersonalAgencyName, row.COMPANY_ID))
                            {
                                employeePersonalAgency.InsertDirect(newPersonalAgencyName, originalCompanyId, false);
                            }
                            else
                            {
                                employeePersonalAgency.UnDeleteDirect(newPersonalAgencyName, originalCompanyId);
                            }

                            if (employeePersonalAgencyGateway.IsUsedInEmployee(originalPersonalAgencyName, companyId))
                            {
                                EmployeeGateway employeeGateway = new EmployeeGateway(null);
                                employeeGateway.UpdatePersonalAgencyName(originalPersonalAgencyName, newPersonalAgencyName);
                            }

                            employeePersonalAgency.DeleteDirect(originalPersonalAgencyName, companyId);
                        }

                        // Delete personal agency 
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            EmployeePersonalAgency employeePersonalAgency = new EmployeePersonalAgency(null);
                            employeePersonalAgency.DeleteDirect(row.PersonalAgencyName, row.COMPANY_ID);
                        }
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception
        /// </summary>
        /// <param name="personalAgencyName">personalAgencyName</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Row</returns>
        private PersonalAgencyInformationTDS.PersonalAgencyInformationRow GetRow(string personalAgencyName, int companyId)
        {
            PersonalAgencyInformationTDS.PersonalAgencyInformationRow row = ((PersonalAgencyInformationTDS.PersonalAgencyInformationDataTable)Table).FindByPersonalAgencyNameCOMPANY_ID(personalAgencyName, companyId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.Employees.PersonalAgencyInformation.GetRow");
            }

            return row;
        }



    }
}