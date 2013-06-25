using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeeInformationCategoryApproveTimesheetsInformationGateway
    /// </summary>
    public class EmployeeInformationCategoryApproveTimesheetsInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeInformationCategoryApproveTimesheetsInformationGateway()
            : base("CategoryApproveTimesheetsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeInformationCategoryApproveTimesheetsInformationGateway(DataSet data)
            : base(data, "CategoryApproveTimesheetsInformation")
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
            tableMapping.DataSetTable = "CategoryApproveTimesheetsInformation";
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("Category", "Category");
            tableMapping.ColumnMappings.Add("ApproveTimesheets", "ApproveTimesheets");
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
        /// <returns>Dataset</returns>
        public DataSet LoadByEmployeeId(int employeeId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEINFORMATIONCATEGORYAPPROVETIMESHEETSINFORMATIONGATEWAY_LOADBYEMPLOYEEID", new SqlParameter("@employeeId", employeeId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// /// <param name="employeeId">employeeId</param>
        /// <param name="category">category</param>        
        /// <returns>DataRow</returns>
        public DataRow GetRow(int employeeId, string category)
        {
            string filter = string.Format("EmployeeID = {0} AND Category = '{1}'", employeeId, category);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Employee.EmployeeInformationCategoryApproveTimesheetsInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetApproveTimesheets
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="category">category</param>      
        /// <returns>ApproveTimesheets</returns>
        public bool GetApproveTimesheets(int employeeId, string category)
        {
            try
            {
                return (bool)GetRow(employeeId, category)["ApproveTimesheets"];
            }
            catch
            {
                return false;
            }
        }



        /// <summary>
        /// GetApproveTimesheets Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="category">category</param>
        /// <returns>Original ApproveTimesheets</returns>
        public bool GetApproveTimesheetsOriginal(int employeeId, string category)
        {
            try
            {
                return (bool)GetRow(employeeId, category)["ApproveTimesheets", DataRowVersion.Original];
            }
            catch
            {
                return false;
            }
        }

         
      
    }
}