using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListToDoAssignedToMeReportGateway
    /// </summary>
    public class ToDoListToDoAssignedToMeReportGateway : DataTableGateway
    {
       // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListToDoAssignedToMeReportGateway()
            : base("ToDoListToDoAssignedToMe")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public ToDoListToDoAssignedToMeReportGateway(DataSet data)
            : base(data, "ToDoListToDoAssignedToMe")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ToDoListToDoAssignedToMeReportTDS();
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
            tableMapping.DataSetTable = "ToDoListToDoAssignedToMe";
            tableMapping.ColumnMappings.Add("ToDoID", "ToDoID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("CreationDate", "CreationDate");
            tableMapping.ColumnMappings.Add("CreatedByID", "CreatedByID");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("DueDate", "DueDate");
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");           
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("CreatedByFullName", "CreatedByFullName");
            tableMapping.ColumnMappings.Add("UnitDescription", "UnitDescription");
            
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
        /// LoadToDoAssignedToMeByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadToDoAssignedToMeByEmployeeId(int employeeId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_TODOLISTTODOASSIGNEDTOMEREPORTGATEWAY_LOADTODOASSIGNEDTOMEBYEMPLOYEEID", new SqlParameter("@employeeId", employeeId), new SqlParameter("@companyId", companyId));
            return Data;
        }
               

    }
}