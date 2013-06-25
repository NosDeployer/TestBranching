using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardMyToDoListGateway
    /// </summary>
    public class DashboardMyToDoListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public DashboardMyToDoListGateway()
            : base("DashboardMyToDoList")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public DashboardMyToDoListGateway(DataSet data)
            : base(data, "DashboardMyToDoList")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new DashboardTDS();
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
            tableMapping.DataSetTable = "DashboardMyToDoList";
            tableMapping.ColumnMappings.Add("ToDoID", "ToDoID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("LastComment", "LastComment");
            tableMapping.ColumnMappings.Add("UnitCode", "UnitCode");
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
        /// LoadCurrentToDoList
        /// </summary>                
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadCurrentToDoListByState(string state, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDMYTODOLISTGATEWAY_LOADALLCURRENTTODOLISTBYSTATE", new SqlParameter("@state", state), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadMyCurrentToDoListByCreatedById
        /// </summary>        
        /// <param name="createdById">createdById</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadMyCurrentToDoListByCreatedByIdState(int createdById, string state, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDMYTODOLISTGATEWAY_LOADALLMYCURRENTTODOLISTBYCREATEDBYIDSTATE", new SqlParameter("@createdById", createdById), new SqlParameter("@state", state), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int toDoId)
        {
            string filter = string.Format("(ToDoID = {0})", toDoId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Dashboard.DashboardMyToDoListGateway.GetRow");
            }
        }



        /// <summary>
        /// GetMySubject
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <returns>Subject</returns>
        public string GetMySubject(int toDoId)
        {
            return (string)GetRow(toDoId)["Subject"];
        }



    }
}