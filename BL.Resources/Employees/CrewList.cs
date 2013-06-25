using System;
using System.Data;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.Common;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// CrewList
    /// </summary>
    public class CrewList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CrewList()
            : base("LFS_RESOURCES_EMPLOYEE_CREW")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CrewList(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE_CREW")
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
        /// <param name="crew">crew</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>        
        public DataSet LoadAndAddItem(string crew, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(crew);

            // Load personal agency list
            CrewListGateway crewListGateway = new CrewListGateway(Data);
            crewListGateway.ClearBeforeFill = false;
            crewListGateway.Load(companyId);
            crewListGateway.ClearBeforeFill = true;

            return Data;
        }

        





        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="crew">crew</param>
        private void Insert(string crew)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["Crew"] = crew;
            Table.Rows.Add(newRow);
        }



        /// <summary>
        /// CreateTableStructure
        /// </summary>
        private void CreateTableStructure()
        {
            // Create table
            System.Data.DataTable table = new DataTable("LFS_RESOURCES_EMPLOYEE_CREW");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Crew";
            Table.Columns.Add(column);
        }



    }
}