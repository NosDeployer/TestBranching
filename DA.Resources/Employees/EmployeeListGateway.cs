using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeeListGateway
    /// </summary>
    public class EmployeeListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeListGateway()
            : base("LFS_RESOURCES_EMPLOYEE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeListGateway(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DataSet();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            _adapter = new SqlDataAdapter("", DB.Connection);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <returns>Data</returns>
        public DataSet Load()
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEELISTGATEWAY_LOAD");
            return Data;
        }



        /// <summary>
        /// LoadByRequestProjectTime
        /// </summary>
        /// <param name="requestProjectTime">requestProjectTime</param>
        /// <returns>Data</returns>
        public DataSet LoadByRequestProjectTime(int requestProjectTime)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEELISTGATEWAY_LOADBYREQUESTPROJECTTIME", new SqlParameter("@requestProjectTime", requestProjectTime));
            return Data;
        }



        /// <summary>
        /// LoadByRequestProjectTimeEmployeeType
        /// </summary>
        /// <param name="requestProjectTime">requestProjectTime</param>
        /// <param name="employeeType">employeeType</param>
        /// <returns>Data</returns>
        public DataSet LoadByRequestProjectTimeEmployeeType(int requestProjectTime, string employeeType)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEELISTGATEWAY_LOADBYREQUESTPROJECTTIMEEMPLOYEETYPE", new SqlParameter("@requestProjectTime", requestProjectTime), new SqlParameter("@employeeType", employeeType));
            return Data;
        }



        /// <summary>
        /// LoadByRequestProjectTimeEmployeeTypeEmployeeIdApproveManager
        /// </summary>
        /// <param name="requestProjectTime">requestProjectTime</param>
        /// <param name="employeeType">employeeType</param>
        /// <param name="employeeIdApproveManager">employeeIdApproveManager</param>
        /// <returns>Data</returns>
        public DataSet LoadByRequestProjectTimeEmployeeTypeEmployeeIdApproveManager(int requestProjectTime, string employeeType, int employeeIdApproveManager)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEELISTGATEWAY_LOADBYREQUESTPROJECTTIMEEMPLOYEETYPEEMPLOYEEIDAPPROVEMANAGER", new SqlParameter("@requestProjectTime", requestProjectTime), new SqlParameter("@employeeType", employeeType), new SqlParameter("@employeeIdApproveManager", employeeIdApproveManager));
            return Data;
        }



        /// <summary>
        /// LoadByRequestProjectTimeWithoutEmployeeId
        /// </summary>
        /// <param name="requestProjectTime">requestProjectTime</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Data</returns>
        public DataSet LoadByRequestProjectTimeWithoutEmployeeId(int requestProjectTime, int employeeId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEELISTGATEWAY_LOADBYREQUESTPROJECTTIMEWITHOUTEMPLOYEEID", new SqlParameter("@requestProjectTime", requestProjectTime), new SqlParameter("@employeeId", employeeId));
            return Data;
        }




        /// <summary>
        /// LoadNoSubcontractor
        /// </summary>
        /// <returns>Data</returns>
        public DataSet LoadNoSubcontractor()
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEELISTGATEWAY_LOADNOSUBCONTRACTOR");
            return Data;
        }


        
        /// <summary>
        /// LoadBySalaried
        /// </summary>
        /// <param name="salaried">salaried</param>
        /// <returns>Data</returns>
        public DataSet LoadBySalaried(int salaried)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEELISTGATEWAY_LOADBYSALARIED", new SqlParameter("@salaried", salaried));
            return Data;
        }



        /// <summary>
        /// LoadBySalariedEmployeeType
        /// </summary>
        /// <param name="salaried">salaried</param>
        /// <param name="employeeType">employeeType</param>
        /// <returns>Data</returns>
        public DataSet LoadBySalariedEmployeeType(int salaried, string employeeType)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEELISTGATEWAY_LOADBYSALARIEDEMPLOYEETYPE", new SqlParameter("@salaried", salaried), new SqlParameter("employeeType", employeeType));
            return Data;
        }



        /// <summary>
        /// LoadBySalariedStateRequestProjectTime
        /// </summary>
        /// <param name="salaried">salaried</param>
        /// <param name="state">state</param>
        /// <param name="requestProjectTime">requestProjectTime</param>
        /// <returns>Data</returns>
        public DataSet LoadBySalariedStateRequestProjectTime(int salaried, string state, int requestProjectTime)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEELISTGATEWAY_LOADBYSALARIEDSTATEREQUESTPROJECTTIME", new SqlParameter("@salaried", salaried), new SqlParameter("@state", state), new SqlParameter("@requestProjectTime", requestProjectTime));
            return Data;
        }



        /// <summary>
        /// LoadBySalariedState
        /// </summary>
        /// <param name="salaried">salaried</param>
        /// <param name="state">state</param>        
        /// <returns>Data</returns>
        public DataSet LoadBySalariedState(int salaried, string state)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEELISTGATEWAY_LOADBYSALARIEDSTATE", new SqlParameter("@salaried", salaried), new SqlParameter("@state", state));
            return Data;
        }



        /// <summary>
        /// LoadByAssignableSrs
        /// </summary>
        /// <param name="assignable">assignableSrs</param>
        /// <returns>Data</returns>
        public DataSet LoadByAssignableSrs(int assignableSrs)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEELISTGATEWAY_LOADBYASSIGNABLESRS", new SqlParameter("@assignableSrs", assignableSrs));
            return Data;
        }



        /// <summary>
        /// LoadCurrentEmployees
        /// </summary>        
        /// <returns>Data</returns>
        public DataSet LoadCurrentEmployees()
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEELISTGATEWAY_LOADCURRENTEMPLOYEES");
            return Data;
        }



    }
}
