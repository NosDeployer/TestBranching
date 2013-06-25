using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeeStandardCostsSetupGateway
    /// </summary>
    public class EmployeeStandardCostsSetupGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeStandardCostsSetupGateway()
            : base("StandardCostsSetup")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeStandardCostsSetupGateway(DataSet data)
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



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "StandardCostsSetup";
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
        /// LoadAll
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Data</returns>
        public DataSet LoadAll()
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEESTANDARDCOSTSSETUPGATEWAY_LOADALL");
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Employees.EmployeeStandardCostsSetupGateway.GetRow");
            }
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



    }
}