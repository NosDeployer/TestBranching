using System;
using System.Data;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.Common;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// PersonalAgencyList
    /// </summary>
    public class PersonalAgencyList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PersonalAgencyList()
            : base("LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PersonalAgencyList(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES")
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
        public DataSet LoadAndAddItem(string personalAgencyName)
        {
            // Add item
            CreateTableStructure();
            Insert(personalAgencyName);

            // Load personal agency list
            PersonalAgencyListGateway personalAgencyListGateway = new PersonalAgencyListGateway(Data);
            personalAgencyListGateway.ClearBeforeFill = false;
            personalAgencyListGateway.Load();
            personalAgencyListGateway.ClearBeforeFill = true;

            return Data;
        }

        





        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="personalAgencyName">personalAgencyName</param>
        private void Insert(string personalAgencyName)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["PersonalAgencyName"] = personalAgencyName;
            Table.Rows.Add(newRow);
        }



        /// <summary>
        /// CreateTableStructure
        /// </summary>
        private void CreateTableStructure()
        {
            // Create table
            System.Data.DataTable table = new DataTable("LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "PersonalAgencyName";
            Table.Columns.Add(column);
        }



    }
}