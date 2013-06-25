using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListToDoAssignedToMeActivityReportGateway
    /// </summary>
    public class ToDoListToDoAssignedToMeActivityReportGateway : DataTableGateway
    {
       // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListToDoAssignedToMeActivityReportGateway()
            : base("ToDoListActivityToDoAssignedToMe")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public ToDoListToDoAssignedToMeActivityReportGateway(DataSet data)
            : base(data, "ToDoListActivityToDoAssignedToMe")
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
            tableMapping.DataSetTable = "ToDoListActivityMyToDo";
            tableMapping.ColumnMappings.Add("ToDoID", "ToDoID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("Type_", "Type_");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("Comment", "Comment");                 
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("EmployeeFullName", "EmployeeFullName");            
            
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
        /// LoadToDoAssignedToMeActivityByToDoId
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadToDoAssignedToMeActivityByToDoId(int toDoId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_TODOLISTTODOASSIGNEDTOMEACTIVITYREPORTGATEWAY_LOADTODOASSIGNEDTOMEACTIVITYBYTODOID", new SqlParameter("@toDoId", toDoId), new SqlParameter("@companyId", companyId)); 
            return Data;
        }



        

    }
}