using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddEmployeePayPeriodGateway
    /// </summary>
    public class ProjectCostingSheetAddEmployeePayPeriodGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCostingSheetAddEmployeePayPeriodGateway()
            : base("EmployeePayPeriod")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCostingSheetAddEmployeePayPeriodGateway(DataSet data)
            : base(data, "EmployeePayPeriod")
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
            tableMapping.DataSetTable = "EmployeePayPeriod";
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
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
        /// LoadByStartDateEndDateEmployeeId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateEndDateEmployeeId(DateTime startDate, DateTime endDate, int employeeId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDEMPLOYEEPAYPERIODGATEWAY_LOADBYSTARTDATEENDATEEMPLOYEEID", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@employeeId", employeeId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectCostingSheetAddEmployeePayPeriod.GetRow");
            }
        }



    }
}