using System;
using System.Data;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.Common;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeInformationPayVacationDaysInformationList
    /// </summary>
    public class EmployeeInformationPayVacationDaysInformationList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeInformationPayVacationDaysInformationList()
            : base("PayVacationDaysInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeInformationPayVacationDaysInformationList(DataSet data)
            : base(data, "PayVacationDaysInformation")
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
        /// <returns>DataSet</returns>
        public DataSet Load()
        {
            // Add item
            CreateTableStructure();

            // Load personal agency list
            EmployeeInformationPayVacationDaysInformationListGateway employeeInformationPayVacationDaysInformationListGateway = new EmployeeInformationPayVacationDaysInformationListGateway(Data);
            employeeInformationPayVacationDaysInformationListGateway.ClearBeforeFill = false;
            employeeInformationPayVacationDaysInformationListGateway.Load();
            employeeInformationPayVacationDaysInformationListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByEmployeeId(int employeeId)
        {
            // Add item
            CreateTableStructure();
            
            // Load year list
            EmployeeInformationPayVacationDaysInformationListGateway employeeInformationPayVacationDaysInformationListGateway = new EmployeeInformationPayVacationDaysInformationListGateway(Data);
            employeeInformationPayVacationDaysInformationListGateway.ClearBeforeFill = false;
            employeeInformationPayVacationDaysInformationListGateway.LoadByEmployeeId(employeeId);
            employeeInformationPayVacationDaysInformationListGateway.ClearBeforeFill = true;

            return Data;
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
            System.Data.DataTable table = new DataTable("PayVacationDaysInformation");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Year";
            Table.Columns.Add(column);
        }



    }
}