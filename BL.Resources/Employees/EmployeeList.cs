using System;
using System.Data;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.Common;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeList
    /// </summary>
    public class EmployeeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeList() : base("LFS_RESOURCES_EMPLOYEE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeList(DataSet data) : base(data, "LFS_RESOURCES_EMPLOYEE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DataSet();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAndAddItem
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="fullName">fullName</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int employeeId, string fullName)
        {
            // Add item
            CreateTableStructure();
            Insert(employeeId, fullName);

            // Load employees list
            EmployeeListGateway employeeListGateway = new EmployeeListGateway(Data);
            employeeListGateway.ClearBeforeFill = false;
            employeeListGateway.Load();
            employeeListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAndAddItemNoSubcontractor
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="fullName">fullName</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItemNoSubcontractor(int employeeId, string fullName)
        {
            // Add item
            CreateTableStructure();
            Insert(employeeId, fullName);

            // Load employees list
            EmployeeListGateway employeeListGateway = new EmployeeListGateway(Data);
            employeeListGateway.ClearBeforeFill = false;
            employeeListGateway.LoadNoSubcontractor();
            employeeListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadByRequestProjectTimeAndAddItem
        /// </summary>
        /// <param name="requestProjectTime">requestProjectTime</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="fullName">fullName</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByRequestProjectTimeAndAddItem(int requestProjectTime, int employeeId, string fullName)
        {
            // Insert extra employee
            CreateTableStructure();
            Insert(employeeId, fullName);

            // Load employees
            EmployeeListGateway employeeListGateway = new EmployeeListGateway(Data);
            employeeListGateway.ClearBeforeFill = false;
            employeeListGateway.LoadByRequestProjectTime(requestProjectTime);
            employeeListGateway.ClearBeforeFill = true;

            // Return DataSet
            return Data;
        }



        /// <summary>
        /// LoadByRequestProjectTimeEmployeeTypeAndAddItem
        /// </summary>
        /// <param name="requestProjectTime">requestProjectTime</param>
        /// <param name="employeeType">employeeType</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="fullName">fullName</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByRequestProjectTimeEmployeeTypeAndAddItem(int requestProjectTime, string employeeType, int employeeId, string fullName)
        {
            // Insert extra employee
            CreateTableStructure();
            Insert(employeeId, fullName);

            // Load employees
            EmployeeListGateway employeeListGateway = new EmployeeListGateway(Data);
            employeeListGateway.ClearBeforeFill = false;
            employeeListGateway.LoadByRequestProjectTimeEmployeeType(requestProjectTime, employeeType);
            employeeListGateway.ClearBeforeFill = true;

            // Return DataSet
            return Data;
        }



        /// <summary>
        /// LoadByRequestProjectTimeEmployeeTypeEmployeeIdApproveManagerAndAddItem
        /// </summary>
        /// <param name="requestProjectTime">requestProjectTime</param>
        /// <param name="employeeType">employeeType</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="fullName">fullName</param>
        /// <param name="employeeIdManager">employeeIdManager</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByRequestProjectTimeEmployeeTypeEmployeeIdApproveManagerAndAddItem(int requestProjectTime, string employeeType, int employeeId, string fullName, int employeeIdApproveManager)
        {
            // Insert extra employee
            CreateTableStructure();
            Insert(employeeId, fullName);

            // Load employees
            EmployeeListGateway employeeListGateway = new EmployeeListGateway(Data);
            employeeListGateway.ClearBeforeFill = false;
            employeeListGateway.LoadByRequestProjectTimeEmployeeTypeEmployeeIdApproveManager(requestProjectTime, employeeType, employeeIdApproveManager);
            employeeListGateway.ClearBeforeFill = true;

            // Return DataSet
            return Data;
        }



        /// <summary>
        /// LoadBySalariedAndAddItem
        /// </summary>
        /// <param name="salaried">salaried</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="fullName">fullName</param>
        /// <returns>DataSet</returns>
        public DataSet LoadBySalariedAndAddItem(int salaried, int employeeId, string fullName)
        {
            // Insert extra employee
            CreateTableStructure();
            Insert(employeeId, fullName);

            // Load employees
            EmployeeListGateway employeeListGateway = new EmployeeListGateway(Data);
            employeeListGateway.ClearBeforeFill = false;
            employeeListGateway.LoadBySalaried(salaried);
            employeeListGateway.ClearBeforeFill = true;

            // Return DataSet
            return Data;
        }



        /// <summary>
        /// LoadBySalariedEmployeeTypeAndAddItem
        /// </summary>
        /// <param name="salaried">salaried</param>
        /// <param name="employeeType">employeeType</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="fullName">fullName</param>
        /// <returns>DataSet</returns>
        public DataSet LoadBySalariedEmployeeTypeAndAddItem(int salaried, string employeeType, int employeeId, string fullName)
        {
            // Insert extra employee
            CreateTableStructure();
            Insert(employeeId, fullName);

            // Load employees
            EmployeeListGateway employeeListGateway = new EmployeeListGateway(Data);
            employeeListGateway.ClearBeforeFill = false;
            employeeListGateway.LoadBySalariedEmployeeType(salaried, employeeType);
            employeeListGateway.ClearBeforeFill = true;

            // Return DataSet
            return Data;
        }



        /// <summary>
        /// LoadBySalariedStateRequestProjectTimeAndAddItem
        /// </summary>
        /// <param name="salaried">salaried</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="fullName">fullName</param>
        /// <param name="state">state</param>
        /// <param name="requestProjectTime">requestProjectTime</param>
        /// <returns>DataSet</returns>
        public DataSet LoadBySalariedStateRequestProjectTimeAndAddItem(int salaried, int employeeId, string fullName, string state, int requestProjectTime)
        {
            // Insert extra employee
            CreateTableStructure();
            Insert(employeeId, fullName);

            // Load employees
            EmployeeListGateway employeeListGateway = new EmployeeListGateway(Data);
            employeeListGateway.ClearBeforeFill = false;
            employeeListGateway.LoadBySalariedStateRequestProjectTime(salaried, state, requestProjectTime);
            employeeListGateway.ClearBeforeFill = true;

            // Return DataSet
            return Data;
        }



        /// <summary>
        /// LoadBySalariedStateAndAddItem
        /// </summary>
        /// <param name="salaried">salaried</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="fullName">fullName</param>
        /// <param name="state">state</param>        
        /// <returns>DataSet</returns>
        public DataSet LoadBySalariedStateAndAddItem(int salaried, int employeeId, string fullName, string state)
        {
            // Insert extra employee
            CreateTableStructure();
            Insert(employeeId, fullName);

            // Load employees
            EmployeeListGateway employeeListGateway = new EmployeeListGateway(Data);
            employeeListGateway.ClearBeforeFill = false;
            employeeListGateway.LoadBySalariedState(salaried, state);
            employeeListGateway.ClearBeforeFill = true;

            // Return DataSet
            return Data;
        }



        /// <summary>
        /// LoadCurrentEmployees
        /// </summary>        
        /// <param name="employeeId">employeeId</param>
        /// <param name="fullName">fullName</param>
        /// <returns>DataSet</returns>
        public DataSet LoadCurrentEmployees(int employeeId, string fullName)
        {
            // Insert extra employee
            CreateTableStructure();
            Insert(employeeId, fullName);

            // Load employees
            EmployeeListGateway employeeListGateway = new EmployeeListGateway(Data);
            employeeListGateway.ClearBeforeFill = false;
            employeeListGateway.LoadCurrentEmployees();
            employeeListGateway.ClearBeforeFill = true;

            // Return DataSet
            return Data;
        }



        /// <summary>
        /// LoadByAssignableSrsAndAddItem
        /// </summary>
        /// <param name="salaried">salaried</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="fullName">fullName</param>       
        /// <returns>DataSet</returns>
        public DataSet LoadByAssignableSrsAndAddItem(int assignableSrs, int employeeId, string fullName)
        {
            // Insert extra employee
            CreateTableStructure();
            Insert(employeeId, fullName);

            // Load employees
            EmployeeListGateway employeeListGateway = new EmployeeListGateway(Data);
            employeeListGateway.ClearBeforeFill = false;
            employeeListGateway.LoadByAssignableSrs(assignableSrs);
            employeeListGateway.ClearBeforeFill = true;

            // Return DataSet
            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="fullName">fullName</param>
        public void Insert(int employeeId, string fullName)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["EmployeeID"] = employeeId;
            newRow["FullName"] = fullName;
            Table.Rows.Add(newRow);
        }





        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// CreateTableStructure
        /// </summary>
        private void CreateTableStructure()
        {
            // Create table
            System.Data.DataTable table = new DataTable("LFS_RESOURCES_EMPLOYEE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "EmployeeID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "FullName";
            Table.Columns.Add(column);
        }



    }
}