using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeeInformationTypeHistoryInformationGateway
    /// </summary>
    public class EmployeeInformationTypeHistoryInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeInformationTypeHistoryInformationGateway()
            : base("TypeHistoryInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeInformationTypeHistoryInformationGateway(DataSet data)
            : base(data, "TypeHistoryInformation")
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
            tableMapping.DataSetTable = "TypeHistoryInformation";
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("Type", "Type");            
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
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
        /// LoadAllByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAllByEmployeeId(int employeeId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEINFORMATIONTYPEHISTORYINFORMATIONGATEWAY_LOADALLBYEMPLOYEEID", new SqlParameter("@employeeId", employeeId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int employeeId, int refId)
        {
            string filter = string.Format("EmployeeID = {0} AND RefID = {1}", employeeId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Employees.EmployeeInformationTypeHistoryInformationGateway.GetRow");
            }
        }

      

        /// <summary>
        /// GetDate
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>      
        /// <returns>Date</returns>
        public DateTime GetDate(int employeeId, int refId)
        {
            return (DateTime)GetRow(employeeId, refId)["Date"];
        }



        /// <summary>
        /// GetDate Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Date</returns>
        public DateTime GetDateOriginal(int employeeId, int refId)
        {
            return (DateTime)GetRow(employeeId, refId)["Date", DataRowVersion.Original];
        }



        /// <summary>
        /// GetType
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>      
        /// <returns>Type</returns>
        public String GetType(int employeeId, int refId)
        {
            return (String)GetRow(employeeId, refId)["Type"];
        }



        /// <summary>
        /// GetType Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Type</returns>
        public string GetTypeOriginal(int employeeId, int refId)
        {
            return (string)GetRow(employeeId, refId)["Type", DataRowVersion.Original];
        }



    }
}