using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardToDoListAssignedToMeGateway
    /// </summary>
    public class DashboardToDoListAssignedToMeGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public DashboardToDoListAssignedToMeGateway()
            : base("DashboardToDoListAssignedToMe")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public DashboardToDoListAssignedToMeGateway(DataSet data)
            : base(data, "DashboardToDoListAssignedToMe")
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
            tableMapping.DataSetTable = "DashboardToDoListAssignedToMe";
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
        /// LoadCurrentToDoListAssignedToMeByEmployeeId
        /// </summary>        
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadCurrentToDoListAssignedToMeByEmployeeId(int employeeId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDTODOLISTASSIGNEDTOMEGATEWAY_LOADCURRENTTODOLISTASSIGNEDTOMEBYEMPLOYEEID", new SqlParameter("@employeeId", employeeId), new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}