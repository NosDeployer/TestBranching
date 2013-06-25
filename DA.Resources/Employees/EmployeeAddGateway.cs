using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{ 
    /// <summary>
    /// EmployeeAddGateway
    /// </summary>
    public class EmployeeAddGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeAddGateway()
            : base("EmployeeAdd")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeAddGateway(DataSet data)
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



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "EmployeeAdd";
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
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("JobClassType", "JobClassType");
            tableMapping.ColumnMappings.Add("Category", "Category");
            tableMapping.ColumnMappings.Add("PersonalAgencyName", "PersonalAgencyName");
            tableMapping.ColumnMappings.Add("IsVacationsManager", "IsVacationsManager");
            tableMapping.ColumnMappings.Add("ApproveTimesheets", "ApproveTimesheets");
            tableMapping.ColumnMappings.Add("BourdenFactor", "BourdenFactor");
            tableMapping.ColumnMappings.Add("USHealthBenefitFactor", "USHealthBenefitFactor");
            tableMapping.ColumnMappings.Add("BenefitFactorCad", "BenefitFactorCad");
            tableMapping.ColumnMappings.Add("BenefitFactorUsd", "BenefitFactorUsd");
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
        /// <returns>Data</returns>
        public DataSet LoadAll()
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEADDGATEWAY_LOADALL");
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// IsInLfs
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <returns>bool</returns>
        public bool IsInLfs(int loginId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEADDGATEWAY_ISINLFS", new SqlParameter("@loginId", loginId));

            if (Table.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }



    }
}