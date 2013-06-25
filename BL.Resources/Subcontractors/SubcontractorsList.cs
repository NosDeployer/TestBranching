using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Subcontractors;

namespace LiquiForce.LFSLive.BL.Resources.Subcontractors
{
    /// <summary>
    /// SubcontractorsList
    /// </summary>
    public class SubcontractorsList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SubcontractorsList()
            : base("LFS_RESOURCES_SUBCONTRACTORS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SubcontractorsList(DataSet data)
            : base(data, "LFS_RESOURCES_SUBCONTRACTORS")
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
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int companyId)
        {
            // Add item
            CreateTableStructure();            

            // Load costing sheet list
            SubcontractorsListGateway subcontractorsListGateway = new SubcontractorsListGateway(Data);
            subcontractorsListGateway.ClearBeforeFill = false;
            subcontractorsListGateway.Load(companyId);
            subcontractorsListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAndAddItem
        /// </summary>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int subcontractorId, string name, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(subcontractorId, name);

            // Load costing sheet list
            SubcontractorsListGateway subcontractorsListGateway = new SubcontractorsListGateway(Data);
            subcontractorsListGateway.ClearBeforeFill = false;
            subcontractorsListGateway.Load(companyId);
            subcontractorsListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">subcontractorId</param>
        /// <param name="name">name</param>
        public void Insert(int subcontractorId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["SubcontractorID"] = subcontractorId;
            newRow["Name"] = name;
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
            System.Data.DataTable table = new DataTable("LFS_RESOURCES_SUBCONTRACTORS");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "SubcontractorID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }



    }
}