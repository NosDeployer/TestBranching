using System.Data;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using System.Data.SqlClient;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// ProjectTimeApproveGateway
    /// </summary>
    public class ProjectTimeApproveGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTimeApproveGateway()
            : base("ProjectTimeApprove")
        {
        }


        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>

        public ProjectTimeApproveGateway(DataSet data)
            : base(data, "ProjectTimeApprove")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTimeApproveTDS();
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
            tableMapping.DataSetTable = "ProjectTimeApprove";
            tableMapping.ColumnMappings.Add("ProjectTimeID", "ProjectTimeID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("TeamMember", "TeamMember");
            tableMapping.ColumnMappings.Add("Client", "Client");
            tableMapping.ColumnMappings.Add("ProjectNumber", "ProjectNumber");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("StartTime", "StartTime");
            tableMapping.ColumnMappings.Add("EndTime", "EndTime");
            tableMapping.ColumnMappings.Add("ProjectTime", "ProjectTime");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("CountryID", "CountryID");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("JobClass", "JobClass");
            tableMapping.ColumnMappings.Add("TypeOfWork", "TypeOfWork");
            tableMapping.ColumnMappings.Add("Function_", "Function_");
            
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
        /// <returns>DataSet</returns>
        public DataSet Load()
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PROJECTTIMEAPPROVEGATEWAY_LOAD");
            return Data;
        }



        /// <summary>
        /// LoadByEmployeeType
        /// </summary>
        /// <param name="employeeType">employeeType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByEmployeeType(string employeeType)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PROJECTTIMEAPPROVEGATEWAY_LOADBYEMPLOYEETYPE", new SqlParameter("employeeType", employeeType));
            return Data;
        }



        /// <summary>
        /// LoadByEmployeeTypeEmployeeIdApproveManager
        /// </summary>
        /// <param name="employeeType">employeeType</param>
        /// <param name="employeeIdApproveManager">employeeIdApproveManager</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByEmployeeTypeEmployeeIdApproveManager(string employeeType, int employeeIdApproveManager)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PROJECTTIMEAPPROVEGATEWAY_LOADBYEMPLOYEETYPEEMPLOYEEIDAPPROVEMANAGER", new SqlParameter("employeeType", employeeType), new SqlParameter("employeeIdApproveManager", employeeIdApproveManager));
            return Data;
        }



    }
}