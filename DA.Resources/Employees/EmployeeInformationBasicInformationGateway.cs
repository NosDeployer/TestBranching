using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeeInformationBasicInformationGateway
    /// </summary>
    public class EmployeeInformationBasicInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeInformationBasicInformationGateway()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeInformationBasicInformationGateway(DataSet data)
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



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "BasicInformation";
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("LoginID", "LoginID");
            tableMapping.ColumnMappings.Add("ContactsID", "ContactsID");
            tableMapping.ColumnMappings.Add("FullName", "FullName");
            tableMapping.ColumnMappings.Add("FirstName", "FirstName");
            tableMapping.ColumnMappings.Add("MiddleInitial", "MiddleInitial");
            tableMapping.ColumnMappings.Add("LastName", "LastName");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("IsSalesman", "IsSalesman");
            tableMapping.ColumnMappings.Add("RequestProjectTime", "RequestProjectTime");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("Salaried", "Salaried");
            tableMapping.ColumnMappings.Add("eMail", "eMail");
            tableMapping.ColumnMappings.Add("AssignableSRS", "AssignableSRS");
            tableMapping.ColumnMappings.Add("JobClassType", "JobClassType");
            tableMapping.ColumnMappings.Add("Category", "Category");
            tableMapping.ColumnMappings.Add("PersonalAgencyName", "PersonalAgencyName");
            tableMapping.ColumnMappings.Add("IsVacationsManager", "IsVacationsManager");
            tableMapping.ColumnMappings.Add("ApproveTimesheets", "ApproveTimesheets");
            tableMapping.ColumnMappings.Add("BourdenFactor", "BourdenFactor");
            tableMapping.ColumnMappings.Add("USHealthBenefitFactor", "USHealthBenefitFactor");
            tableMapping.ColumnMappings.Add("BenefitFactorCad", "BenefitFactorCad");
            tableMapping.ColumnMappings.Add("BenefitFactorUsd", "BenefitFactorUsd");
            tableMapping.ColumnMappings.Add("Crew", "Crew");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>        
        /// <returns>Data</returns>
        public DataSet LoadByEmployeeId(int employeeId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEINFORMATIONBASICINFORMATIONGATEWAY_LOADBYEMPLOYEEID", new SqlParameter("@employeeId", employeeId));
            return Data;            
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int employeeId)
        {
            string filter = string.Format("EmployeeID = {0}", employeeId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Employees.EmployeeInformationBasicInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetFirstName
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>FirstName or EMPTY</returns>
        public string GetFirstName(int employeeId)
        {
            if (GetRow(employeeId).IsNull("FirstName"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["FirstName"];
            }
        }



        /// <summary>
        /// GetFirstName Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original FirstName or EMPTY</returns>
        public string GetFirstNameOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["FirstName"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["FirstName", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLastName
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>LastName or EMPTY</returns>
        public string GetLastName(int employeeId)
        {
            if (GetRow(employeeId).IsNull("LastName"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["LastName"];
            }
        }



        /// <summary>
        /// GetLastName Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original LastName or EMPTY</returns>
        public string GetLastNameOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["LastName"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["LastName", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetType
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Type or EMPTY</returns>
        public string GetType(int employeeId)
        {
            if (GetRow(employeeId).IsNull("Type"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["Type"];
            }
        }



        /// <summary>
        /// GetType Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original Type or EMPTY</returns>
        public string GetTypeOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["Type"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["Type", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetState
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>State or EMPTY</returns>
        public string GetState(int employeeId)
        {
            if (GetRow(employeeId).IsNull("State"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["State"];
            }
        }



        /// <summary>
        /// GetState Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original State or EMPTY</returns>
        public string GetStateOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["State"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["State", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GeteMail
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>eMail or EMPTY</returns>
        public string GeteMail(int employeeId)
        {
            if (GetRow(employeeId).IsNull("eMail"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["eMail"];
            }
        }



        /// <summary>
        /// GeteMail Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original eMail or EMPTY</returns>
        public string GeteMailOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["eMail"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["eMail", DataRowVersion.Original];
            }
        }


                
        /// <summary>
        /// GetIsSalesman
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>IsSalesman</returns>
        public bool GetIsSalesman(int employeeId)
        {
            return (bool)GetRow(employeeId)["IsSalesman"];
        }



        /// <summary>
        /// GetIsSalesman Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original IsSalesman</returns>
        public bool GetIsSalesmanOriginal(int employeeId)
        {
            return (bool)GetRow(employeeId)["IsSalesman", DataRowVersion.Original];
        }



        /// <summary>
        /// GetRequestProjectTime
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>RequestProjectTime</returns>
        public bool GetRequestProjectTime(int employeeId)
        {
            return (bool)GetRow(employeeId)["RequestProjectTime"];
        }



        /// <summary>
        /// GetRequestProjectTimen Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original RequestProjectTime</returns>
        public bool GetRequestProjectTimeOriginal(int employeeId)
        {
            return (bool)GetRow(employeeId)["RequestProjectTime", DataRowVersion.Original];
        }



        /// <summary>
        /// GetSalaried
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Salaried</returns>
        public bool GetSalaried(int employeeId)
        {
            return (bool)GetRow(employeeId)["Salaried"];
        }



        /// <summary>
        /// GetSalaried Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original Salaried</returns>
        public bool GetSalariedOriginal(int employeeId)
        {
            return (bool)GetRow(employeeId)["Salaried", DataRowVersion.Original];
        }



        /// <summary>
        /// GetAssignableSRS
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>AssignableSRS</returns>
        public bool GetAssignableSRS(int employeeId)
        {
            return (bool)GetRow(employeeId)["AssignableSRS"];
        }



        /// <summary>
        /// GetAssignableSRS Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original AssignableSRS</returns>
        public bool GetAssignableSRSOriginal(int employeeId)
        {
            return (bool)GetRow(employeeId)["AssignableSRS", DataRowVersion.Original];
        }



        /// <summary>
        /// GetJobClassType
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>JobClassType or EMPTY</returns>
        public string GetJobClassType(int employeeId)
        {
            if (GetRow(employeeId).IsNull("JobClassType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["JobClassType"];
            }
        }



        /// <summary>
        /// GetJobClassType Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original JobClassType or EMPTY</returns>
        public string GetJobClassTypeOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["JobClassType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["JobClassType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCategory
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Category</returns>
        public string GetCategory(int employeeId)
        {
            return (string)GetRow(employeeId)["Category"];
        }



        /// <summary>
        /// GetCategory Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original Category or EMPTY</returns>
        public string GetCategoryOriginal(int employeeId)
        {
            return (string)GetRow(employeeId)["Category", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPersonalAgencyName
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>PersonalAgencyName or EMPTY</returns>
        public string GetPersonalAgencyName(int employeeId)
        {
            if (GetRow(employeeId).IsNull("PersonalAgencyName"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["PersonalAgencyName"];
            }
        }



        /// <summary>
        /// GetPersonalAgencyName Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original PersonalAgencyName or EMPTY</returns>
        public string GetPersonalAgencyNameOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["PersonalAgencyName"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["PersonalAgencyName", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetIsVacationsManager
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>IsVacationsManager</returns>
        public bool GetIsVacationsManager(int employeeId)
        {
            return (bool)GetRow(employeeId)["IsVacationsManager"];
        }



        /// <summary>
        /// GetIsVacationsManager Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original IsVacationsManager</returns>
        public bool GetIsVacationsManagerOriginal(int employeeId)
        {
            return (bool)GetRow(employeeId)["IsVacationsManager", DataRowVersion.Original];
        }



        /// <summary>
        /// GetApproveTimesheets
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>ApproveTimesheets</returns>
        public bool GetApproveTimesheets(int employeeId)
        {
            return (bool)GetRow(employeeId)["ApproveTimesheets"];
        }




        /// <summary>
        /// GetApproveTimesheets Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original ApproveTimesheets</returns>
        public bool GetApproveTimesheetsOriginal(int employeeId)
        {
            return (bool)GetRow(employeeId)["ApproveTimesheets", DataRowVersion.Original];
        }



        /// <summary>
        /// GetBourdenFactor
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>BourdenFactor or EMPTY</returns>
        public decimal? GetBourdenFactor(int employeeId)
        {
            if (GetRow(employeeId).IsNull("BourdenFactor"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(employeeId)["BourdenFactor"];
            }
        }



        /// <summary>
        /// GetBourdenFactor Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original BourdenFactor or EMPTY</returns>
        public decimal? GetBourdenFactorOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["BourdenFactor"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(employeeId)["BourdenFactor", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUSHealthBenefitFactor
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>USHealthBenefitFactor or EMPTY</returns>
        public decimal? GetUSHealthBenefitFactor(int employeeId)
        {
            if (GetRow(employeeId).IsNull("USHealthBenefitFactor"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(employeeId)["USHealthBenefitFactor"];
            }
        }



        /// <summary>
        /// GetUSHealthBenefitFactor Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original USHealthBenefitFactor or EMPTY</returns>
        public decimal? GetUSHealthBenefitFactorOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["USHealthBenefitFactor"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(employeeId)["USHealthBenefitFactor", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetBenefitFactorCad
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>BenefitFactorCad or EMPTY</returns>
        public decimal? GetBenefitFactorCad(int employeeId)
        {
            if (GetRow(employeeId).IsNull("BenefitFactorCad"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(employeeId)["BenefitFactorCad"];
            }
        }



        /// <summary>
        /// GetBenefitFactorCad Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original BenefitFactorCad or EMPTY</returns>
        public decimal? GetBenefitFactorCadOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["BenefitFactorCad"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(employeeId)["BenefitFactorCad", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetBenefitFactorUsd
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>BenefitFactorUsd or EMPTY</returns>
        public decimal? GetBenefitFactorUsd(int employeeId)
        {
            if (GetRow(employeeId).IsNull("BenefitFactorUsd"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(employeeId)["BenefitFactorUsd"];
            }
        }



        /// <summary>
        /// GetBenefitFactorUsd Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original BenefitFactorUsd or EMPTY</returns>
        public decimal? GetBenefitFactorUsdOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["BenefitFactorUsd"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(employeeId)["BenefitFactorUsd", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCrew
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Crew or EMPTY</returns>
        public string GetCrew(int employeeId)
        {
            if (GetRow(employeeId).IsNull("Crew"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["Crew"];
            }
        }



        /// <summary>
        /// GetCrew Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original Crew or EMPTY</returns>
        public string GetCrewOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["Crew"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["Crew", DataRowVersion.Original];
            }
        }


        
    }
}