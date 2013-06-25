using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels
{
    /// <summary>
    /// CompanyLevelsAddManagersGateway
    /// </summary>
    public class CompanyLevelsAddManagersGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompanyLevelsAddManagersGateway()
            : base("CompanyLevelManagers")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public CompanyLevelsAddManagersGateway(DataSet data)
            : base(data, "CompanyLevelManagers")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new CompanyLevelsAddTDS();
        }



        /// <summary>
        /// InitAdapter (empty)
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "CompanyLevelManagers";
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("CompanyLevelID", "CompanyLevelID");
            tableMapping.ColumnMappings.Add("FullName", "FullName");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
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
        /// Load
        /// </summary>
        /// <returns>Data</returns>
        /// <param name="companyId">companyId</param>
        public DataSet LoadAll(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_COMPANYLEVELMANAGERSGATEWAY_LOADALL", new SqlParameter("@companyId", companyId));
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// InUseHasManagers
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>true or false</returns>
        public bool InUseHasManagers(int companyLevelId, int employeeId, int companyId)
        {
            SqlParameter companyLevelIdParameter = new SqlParameter("CompanyLevelID", companyLevelId);
            SqlParameter employeeIdParameter = new SqlParameter("EmployeeID", employeeId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "SELECT COUNT(*) FROM dbo.LFS_FM_COMPANYLEVEL_MANAGERS WHERE (Deleted = 0) AND (COMPANY_ID = @COMPANY_ID) AND (CompanyLevelID = @companyLevelId) AND (EmployeeID = @employeeId)";

            int count = (int)ExecuteScalar(command, companyLevelIdParameter, employeeIdParameter, companyIdParameter);

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
