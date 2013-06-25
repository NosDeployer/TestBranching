using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardToDoListAssignedToMeOnHoldGateway
    /// </summary>
    public class DashboardToDoListAssignedToMeOnHoldGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public DashboardToDoListAssignedToMeOnHoldGateway()
            : base("DashboardToDoListAssignedToMeOnHold")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public DashboardToDoListAssignedToMeOnHoldGateway(DataSet data)
            : base(data, "DashboardToDoListAssignedToMeOnHold")
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
            tableMapping.DataSetTable = "DashboardToDoListAssignedToMeOnHold";
            tableMapping.ColumnMappings.Add("ToDoID", "ToDoID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
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
        /// LoadToDoListAssignedToMeOnHoldByEmployeeId
        /// </summary>        
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadToDoListAssignedToMeOnHoldByEmployeeId(int employeeId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDTODOLISTASSIGNEDTOMEONHOLDGATEWAY_LOADTODOLISTASSIGNEDTOMEONHOLDBYEMPLOYEEID", new SqlParameter("@employeeId", employeeId), new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}