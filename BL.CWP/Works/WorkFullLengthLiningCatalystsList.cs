using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningWetOutCatalystsList
    /// </summary>
    public class WorkFullLengthLiningCatalystsList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningCatalystsList()
            : base("LFS_WORK_FULLLENGTHLINING_CATALYSTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningCatalystsList(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_CATALYSTS")
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
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int catalystId, string name, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(catalystId, name);

            // Load viewType list
            WorkFullLengthLiningCatalystsListGateway workFullLengthLiningCatalystsListGateway = new WorkFullLengthLiningCatalystsListGateway(Data);
            workFullLengthLiningCatalystsListGateway.ClearBeforeFill = false;
            workFullLengthLiningCatalystsListGateway.Load(companyId);
            workFullLengthLiningCatalystsListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <param name="name">name</param>
        public void Insert(int catalystId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["CatalystID"] = catalystId;
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
            System.Data.DataTable table = new DataTable("LFS_WORK_FULLLENGTHLINING_CATALYSTS");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "CatalystID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }
    }
}
