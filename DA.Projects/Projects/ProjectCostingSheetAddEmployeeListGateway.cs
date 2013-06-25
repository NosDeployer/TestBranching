using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddEmployeeListGateway
    /// </summary>
    public class ProjectCostingSheetAddEmployeeListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCostingSheetAddEmployeeListGateway()
            : base("EmployeeList")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCostingSheetAddEmployeeListGateway(DataSet data)
            : base(data, "EmployeeList")
        {
        }



        /// <summary>
        /// InitData. Create a ProjectCostingSheetAddTDS dataset
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetAddTDS();
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
            tableMapping.DataSetTable = "EmployeeList";
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("CostCad", "CostCad");
            tableMapping.ColumnMappings.Add("CostUsd", "CostUsd");
            tableMapping.ColumnMappings.Add("UnitOfMeasurement", "UnitOfMeasurement");
            tableMapping.ColumnMappings.Add("PayRateCad", "PayRateCad");
            tableMapping.ColumnMappings.Add("PayRateUsd", "PayRateUsd");
            tableMapping.ColumnMappings.Add("BurdenRateCad", "BurdenRateCad");
            tableMapping.ColumnMappings.Add("BurdenRateUsd", "BurdenRateUsd");
            tableMapping.ColumnMappings.Add("BenefitFactorCad", "BenefitFactorCad");
            tableMapping.ColumnMappings.Add("BenefitFactorUsd", "BenefitFactorUsd");
            tableMapping.ColumnMappings.Add("HealthBenefitUsd", "HealthBenefitUsd");
            tableMapping.ColumnMappings.Add("BourdenFactor", "BourdenFactor");
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
        /// LoadByProjectIdStartDateEndDateWorkFunction
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="work">work</param>
        /// <param name="function">function</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByProjectIdStartDateEndDateWorkFunction(int projectId, DateTime startDate, DateTime endDate, string work, string function, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDEMPLOYEELISTGATEWAY_LOADBYPROJECTIDSTARTDATEENDDATEWORKFUNCTION", new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@work", work), new SqlParameter("@function", function), new SqlParameter("@companyId", companyId));
            return Data;
        }


        
        /// <summary>
        /// LoadByProjectIdStartDateEndDateWorkFunctionJobClass
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="work">work</param>
        /// <param name="function">function</param>
        /// <param name="jobClass">jobClass</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByProjectIdStartDateEndDateWorkFunctionJobClass(int projectId, DateTime startDate, DateTime endDate, string work, string function, string jobClass, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDEMPLOYEELISTGATEWAY_LOADBYPROJECTIDSTARTDATEENDDATEWORKFUNCTIONJOBCLASS", new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@work", work), new SqlParameter("@function", function), new SqlParameter("@jobClass", jobClass), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Data</returns>
        public DataSet LoadByEmployeeId(int employeeId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDEMPLOYEELISTGATEWAY_LOADBYEMPLOYEEID", new SqlParameter("@employeeId", employeeId));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateEmployeeId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateEmployeeId(DateTime startDate, int employeeId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDEMPLOYEELISTGATEWAY_LOADBYSTARTDATEEMPLOYEEID", new SqlParameter("@startDate", startDate), new SqlParameter("@employeeId", employeeId));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateEmployeeId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateEmployeeIdFairWage(DateTime startDate, int employeeId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDEMPLOYEELISTGATEWAY_LOADBYSTARTDATEEMPLOYEEIDFAIRWAGE", new SqlParameter("@startDate", startDate), new SqlParameter("@employeeId", employeeId));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateEndDateEmployeeId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateEndDateEmployeeId(DateTime startDate, DateTime endDate, int employeeId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDEMPLOYEELISTGATEWAY_LOADBYSTARTDATEENDATEEMPLOYEEID", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@employeeId", employeeId));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateEndDateEmployeeId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateEndDateEmployeeIdFairWage(DateTime startDate, DateTime endDate, int employeeId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDEMPLOYEELISTGATEWAY_LOADBYSTARTDATEENDATEEMPLOYEEIDFAIRWAGE", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@employeeId", employeeId));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateEmployeeIdWork_
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="work_">work_</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateEmployeeIdWork_(DateTime startDate, int employeeId, string work_)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDEMPLOYEELISTGATEWAY_LOADBYSTARTDATEEMPLOYEEIDWORK_", new SqlParameter("@startDate", startDate), new SqlParameter("@employeeId", employeeId), new SqlParameter("@work_", work_));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateEmployeeIdWork_
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="work_">work_</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateEmployeeIdWork_FairWage(DateTime startDate, int employeeId, string work_)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDEMPLOYEELISTGATEWAY_LOADBYSTARTDATEEMPLOYEEIDWORK_FAIRWAGE", new SqlParameter("@startDate", startDate), new SqlParameter("@employeeId", employeeId), new SqlParameter("@work_", work_));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateEndDateEmployeeIdWork_
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="work_">work_</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateEndDateEmployeeIdWork_(DateTime startDate, DateTime endDate, int employeeId, string work_)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDEMPLOYEELISTGATEWAY_LOADBYSTARTDATEENDATEEMPLOYEEIDWORK_", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@employeeId", employeeId), new SqlParameter("@work_", work_));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateEndDateEmployeeIdWork_
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="work_">work_</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateEndDateEmployeeIdWork_FairWage(DateTime startDate, DateTime endDate, int employeeId, string work_)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDEMPLOYEELISTGATEWAY_LOADBYSTARTDATEENDATEEMPLOYEEIDWORK_FAIRWAGE", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@employeeId", employeeId), new SqlParameter("@work_", work_));
            return Data;
        }



        /// <summary>
        /// Get a single row
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectCostingSheetAddEmployeeListGateway.GetRow");
            }
        }



    }
}