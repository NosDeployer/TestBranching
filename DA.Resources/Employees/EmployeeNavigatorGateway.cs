using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeeNavigatorGateway
    /// </summary>
    public class EmployeeNavigatorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeNavigatorGateway()
            : base("EmployeeNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeNavigatorGateway(DataSet data)
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



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "EmployeeNavigator";
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
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("PayRateCad", "PayRateCad");
            tableMapping.ColumnMappings.Add("BurdenRateCad", "BurdenRateCad");
            tableMapping.ColumnMappings.Add("TotalCostCad", "TotalCostCad");
            tableMapping.ColumnMappings.Add("PayRateUsd", "PayRateUsd");
            tableMapping.ColumnMappings.Add("BurdenRateUsd", "BurdenRateUsd");
            tableMapping.ColumnMappings.Add("TotalCostUsd", "TotalCostUsd");
            tableMapping.ColumnMappings.Add("AssignableSRS", "AssignableSRS");
            tableMapping.ColumnMappings.Add("BenefitFactorCad", "BenefitFactorCad");
            tableMapping.ColumnMappings.Add("BenefitFactorUsd", "BenefitFactorUsd");
            tableMapping.ColumnMappings.Add("JobClassType", "JobClassType");
            tableMapping.ColumnMappings.Add("Category", "Category");
            tableMapping.ColumnMappings.Add("PersonalAgencyName", "PersonalAgencyName");
            tableMapping.ColumnMappings.Add("IsVacationsManager", "IsVacationsManager");
            tableMapping.ColumnMappings.Add("ApproveTimesheets", "ApproveTimesheets");
            tableMapping.ColumnMappings.Add("BourdenFactor", "BourdenFactor");
            tableMapping.ColumnMappings.Add("USHealthBenefitFactor", "USHealthBenefitFactor");
            tableMapping.ColumnMappings.Add("StandardBenefitFactorCad", "StandardBenefitFactorCad");
            tableMapping.ColumnMappings.Add("StandardBenefitFactorUsd", "StandardBenefitFactorUsd");
            tableMapping.ColumnMappings.Add("HealthBenefitUsd", "HealthBenefitUsd");
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
        /// LoadWhereOrderBy
        /// </summary>
        /// <param name="where">clause WHERE</param>
        /// <param name="orderBy">clause ORDER BY</param>
        /// <param name="conditionValue">conditionValue</param>
        /// <param name="textForSearch">textForSearch</param>
        public void LoadWhereOrderBy(string where, string orderBy, string conditionValue, string textForSearch)
        {
            // For costs
            string whereClauseCostCad = "";

            if ((conditionValue == "PayRateCad") || (conditionValue == "BurdenRateCad") || (conditionValue == "TotalCostCad") || (conditionValue == "PayRateUsd") || (conditionValue == "BurdenRateUsd") || (conditionValue == "TotalCostUsd") || (conditionValue == "BenefitFactorCad") || (conditionValue == "BenefitFactorUsd") || (conditionValue == "HealthBenefitUsd"))
            {
                if (textForSearch == "")
                {
                    whereClauseCostCad = whereClauseCostCad + " AND  (LRE.EmployeeID NOT IN " +
                        " (SELECT DISTINCT   LRECH.EmployeeID " +
                        "  FROM         LFS_RESOURCES_EMPLOYEE_COST_HISTORY LRECH " +
                        "   WHERE (LRECH.Deleted = 0)  " +
                                 "  ) )";
                }
                else
                {
                    if (textForSearch == "%")
                    {
                        whereClauseCostCad = whereClauseCostCad + " AND  (LRE.EmployeeID IN " +
                        " (SELECT DISTINCT   LRECH.EmployeeID " +
                        "  FROM         LFS_RESOURCES_EMPLOYEE_COST_HISTORY LRECH " +
                        "   WHERE (LRECH.Deleted = 0)  " +
                                 "  ) ) OR  (LRE.EmployeeID NOT IN " +
                        " (SELECT DISTINCT   LRECH.EmployeeID " +
                        "  FROM         LFS_RESOURCES_EMPLOYEE_COST_HISTORY LRECH " +
                        "   WHERE (LRECH.Deleted = 0)  " +
                                 "  ) )";
                    }
                    else
                    {
                        whereClauseCostCad = whereClauseCostCad + " AND  (LRE.EmployeeID IN " +
                       " (SELECT DISTINCT   LRECH.EmployeeID " +
                       "  FROM         LFS_RESOURCES_EMPLOYEE_COST_HISTORY LRECH " +
                       "   WHERE (LRECH.Deleted = 0) AND (LRECH." + conditionValue + " = " + textForSearch + ")" +
                                "  ) )";
                    }
                }
            }

            string commandText = String.Format("SELECT     LRE.EmployeeID, LRE.LoginID, LRE.ContactsID, LRE.FullName, LRE.FirstName, LRE.MiddleInitial, LRE.LastName, LRE.Type,  " +
                      " LRE.State, LRE.IsSalesman, LRE.RequestProjectTime, LRE.Deleted, LRE.Salaried, LRE.eMail, CAST(1 AS bit) AS InDatabase,  " +
                      " CAST(0 AS bit) AS Selected, " +

                      " (SELECT  top 1 LRECH1.PayRateCad FROM LFS_RESOURCES_EMPLOYEE_COST_HISTORY LRECH1 WHERE LRECH1.EmployeeID = LRE.EmployeeID ORDER BY LRECH1.Date Desc) AS PayRateCad, " +
                      " (SELECT  top 1 LRECH1.BurdenRateCad FROM LFS_RESOURCES_EMPLOYEE_COST_HISTORY LRECH1 WHERE LRECH1.EmployeeID = LRE.EmployeeID ORDER BY LRECH1.Date Desc) AS BurdenRateCad, " +
                      " (SELECT  top 1 LRECH1.TotalCostCad FROM LFS_RESOURCES_EMPLOYEE_COST_HISTORY LRECH1 WHERE LRECH1.EmployeeID = LRE.EmployeeID ORDER BY LRECH1.Date Desc) AS TotalCostCad, " +

                      " (SELECT  top 1 LRECH1.PayRateUsd FROM LFS_RESOURCES_EMPLOYEE_COST_HISTORY LRECH1 WHERE LRECH1.EmployeeID = LRE.EmployeeID ORDER BY LRECH1.Date Desc) AS PayRateUsd, " +
                      " (SELECT  top 1 LRECH1.BurdenRateUsd FROM LFS_RESOURCES_EMPLOYEE_COST_HISTORY LRECH1 WHERE LRECH1.EmployeeID = LRE.EmployeeID ORDER BY LRECH1.Date Desc) AS BurdenRateUsd, " +
                      " (SELECT  top 1 LRECH1.TotalCostUsd FROM LFS_RESOURCES_EMPLOYEE_COST_HISTORY LRECH1 WHERE LRECH1.EmployeeID = LRE.EmployeeID ORDER BY LRECH1.Date Desc) AS TotalCostUsd, LRE.AssignableSRS, " +

                      " (SELECT top 1 LRECH1.BenefitFactorCad FROM LFS_RESOURCES_EMPLOYEE_COST_HISTORY LRECH1 WHERE LRECH1.EmployeeID = LRE.EmployeeID ORDER BY LRECH1.Date Desc) AS BenefitFactorCad, " +
                      " (SELECT top 1 LRECH1.BenefitFactorUsd FROM LFS_RESOURCES_EMPLOYEE_COST_HISTORY LRECH1 WHERE LRECH1.EmployeeID = LRE.EmployeeID ORDER BY LRECH1.Date Desc) AS BenefitFactorUsd, " +
                      " JobClassType, Category, PersonalAgencyName, IsVacationsManager, ApproveTimesheets, BourdenFactor, USHealthBenefitFactor, BenefitFactorCad AS StandardBenefitFactorCad, BenefitFactorUsd AS StandardBenefitFactorUsd, " +
                      " (SELECT top 1 LRECH1.HealthBenefitUsd FROM LFS_RESOURCES_EMPLOYEE_COST_HISTORY LRECH1 WHERE LRECH1.EmployeeID = LRE.EmployeeID ORDER BY LRECH1.Date Desc) AS HealthBenefitUsd, Crew " +                                           

                      " FROM         LFS_RESOURCES_EMPLOYEE AS LRE INNER JOIN " +
                      " LFS_RESOURCES_EMPLOYEE_STATE AS LRES ON LRE.State = LRES.State INNER JOIN " +
                      " LFS_RESOURCES_EMPLOYEE_TYPE AS LRET ON LRE.Type = LRET.Type " +
                      " WHERE {0} {1} ORDER BY {2}", where, whereClauseCostCad, orderBy);
            FillData(commandText);
        }



        /// <summary>
        /// GetRow
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Employees.EmployeeNavigatorGateway.GetRow");
            }
        }



        /// <summary>
        /// GetFullName
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>FullName</returns>
        public string GetFullName(int employeeId)
        {
            if (GetRow(employeeId).IsNull("FullName"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["FullName"];
            }
        }



        /// <summary>
        /// GetFullName Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original FullName or EMPTY</returns>
        public string GetFullNameOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["FullName"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["FullName", DataRowVersion.Original];
            }
        }




        /// <summary>
        /// GetLastName
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>LastName</returns>
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
        /// GetFirstName
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>FirstName</returns>
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
        /// GetMiddleInitial
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>MiddleInitial</returns>
        public string GetMiddleInitial(int employeeId)
        {
            if (GetRow(employeeId).IsNull("MiddleInitial"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["MiddleInitial"];
            }
        }



        /// <summary>
        /// GetMiddleInitial Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original MiddleInitial or EMPTY</returns>
        public string GetMiddleInitialOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["MiddleInitial"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["MiddleInitial", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetType
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Type</returns>
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
        /// <returns>State</returns>
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
        /// GetRequestProjectTime
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>RequestProjectTime</returns>
        public bool GetRequestProjectTime(int employeeId)
        {
            return (bool)GetRow(employeeId)["RequestProjectTime"];
        }



        /// <summary>
        /// GetRequestProjectTime Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original RequestProjectTime or EMPTY</returns>
        public bool GetRequestProjectTimeOriginal(int employeeId)
        {
            return (bool)GetRow(employeeId)["RequestProjectTime", DataRowVersion.Original];
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
        /// <returns>Original IsSalesman or EMPTY</returns>
        public bool GetIsSalesmanOriginal(int employeeId)
        {
            return (bool)GetRow(employeeId)["IsSalesman", DataRowVersion.Original];
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
        /// <returns>Original Salaried or EMPTY</returns>
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
        /// <returns>Original AssignableSRS or EMPTY</returns>
        public bool GetAssignableSRSOriginal(int employeeId)
        {
            return (bool)GetRow(employeeId)["AssignableSRS", DataRowVersion.Original];
        }



        /// <summary>
        /// GetEMail
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>eMail</returns>
        public string GetEMail(int employeeId)
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
        /// GetEMail Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original eMail or EMPTY</returns>
        public string GetEMailOriginal(int employeeId)
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
        /// GetStandardBenefitFactorCad
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>StandardBenefitFactorCad or EMPTY</returns>
        public decimal? GetStandardBenefitFactorCad(int employeeId)
        {
            if (GetRow(employeeId).IsNull("StandardBenefitFactorCad"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(employeeId)["StandardBenefitFactorCad"];
            }
        }



        /// <summary>
        /// GetStandardBenefitFactorCad Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original StandardBenefitFactorCad or EMPTY</returns>
        public decimal? GetStandardBenefitFactorCadOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["StandardBenefitFactorCad"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(employeeId)["StandardBenefitFactorCad", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetStandardBenefitFactorUsd
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>StandardBenefitFactorUsd or EMPTY</returns>
        public decimal? GetStandardBenefitFactorUsd(int employeeId)
        {
            if (GetRow(employeeId).IsNull("StandardBenefitFactorUsd"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(employeeId)["StandardBenefitFactorUsd"];
            }
        }



        /// <summary>
        /// GetStandardBenefitFactorUsd Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original StandardBenefitFactorUsd or EMPTY</returns>
        public decimal? GetStandardBenefitFactorUsdOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["StandardBenefitFactorUsd"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(employeeId)["StandardBenefitFactorUsd", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetHealthBenefitUsd
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>HealthBenefitUsd or EMPTY</returns>
        public decimal? GetHealthBenefitUsd(int employeeId)
        {
            if (GetRow(employeeId).IsNull("HealthBenefitUsd"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(employeeId)["HealthBenefitUsd"];
            }
        }



        /// <summary>
        /// GetHealthBenefitUsd Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original HealthBenefitUsd or EMPTY</returns>
        public decimal? GetHealthBenefitUsdOriginal(int employeeId)
        {
            if (GetRow(employeeId).IsNull(Table.Columns["HealthBenefitUsd"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(employeeId)["HealthBenefitUsd", DataRowVersion.Original];
            }
        }

        



        /// <summary>
        /// IsInUse
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>is in use</returns>
        public int IsInUse(int employeeId)
        {
            int categoryOfUsage = 0;

            if (IsUsedInProjectTime(employeeId))
            {
                categoryOfUsage = 1;
            }

            if (IsUsedInTeamProjectTimeDetail(employeeId))
            {
                categoryOfUsage = 2;
            }

            if (IsUsedInProjectsAsProjectLead(employeeId))
            {
                categoryOfUsage = 3;
            }

            if (IsUsedInProjectsAsSalesman(employeeId))
            {
                categoryOfUsage = 4;
            }

            return categoryOfUsage;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// IsUsedInProjectsAsProjectLead
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>bool</returns>
        public bool IsUsedInProjectsAsProjectLead(int employeeId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEENAVIGATORGATEWAY_ISUSEDINPROJECTSASPROJECTLEAD", new SqlParameter("@employeeId", employeeId));

            if ((int)Table.Rows[0]["No"] > 0)
            {
                return true;
            }

            return false;
        }



        /// <summary>
        /// IsUsedInProjectsAsSalesman
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>bool</returns>
        public bool IsUsedInProjectsAsSalesman(int employeeId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEGATEWAY_ISUSEDINPROJECTSASSALESMAN", new SqlParameter("@employeeId", employeeId));

            if ((int)Table.Rows[0]["No"] > 0)
            {
                return true;
            }

            return false;
        }



        /// <summary>
        /// IsUsedInProjectTime
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>bool</returns>
        public bool IsUsedInProjectTime(int employeeId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEENAVIGATORGATEWAY_ISUSEDINPROJECTTIME", new SqlParameter("@employeeId", employeeId));

            if ((int)Table.Rows[0]["No"] > 0)
            {
                return true;
            }

            return false;
        }



        /// <summary>
        /// IsUsedInTeamProjectTimeDetail
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>bool</returns>
        public bool IsUsedInTeamProjectTimeDetail(int employeeId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEENAVIGATORGATEWAY_ISUSEDINTEAMPROJECTTIMEDETAIL", new SqlParameter("@employeeId", employeeId));

            if ((int)Table.Rows[0]["No"] > 0)
            {
                return true;
            }

            return false;
        }



    }
}