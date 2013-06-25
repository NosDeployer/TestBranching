using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningInversionGroundMoistureList
    /// </summary>
    public class WorkFullLengthLiningInversionGroundMoistureList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningInversionGroundMoistureList()
            : base("LFS_WORK_FULLLENGTHLINING_INVERSION_GROUNDMOINSTURE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningInversionGroundMoistureList(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_INVERSION_GROUNDMOINSTURE")
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
        /// <param name="groundMoisture">groundMoisture</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string groundMoisture, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(groundMoisture);

            // Load viewType list
            WorkFullLengthLiningInversionGroundMoistureListGateway workFullLengthLiningInversionGroundMoistureListGateway = new WorkFullLengthLiningInversionGroundMoistureListGateway(Data);
            workFullLengthLiningInversionGroundMoistureListGateway.ClearBeforeFill = false;
            workFullLengthLiningInversionGroundMoistureListGateway.Load(companyId);
            workFullLengthLiningInversionGroundMoistureListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="groundMoisture">groundMoisture</param>
        public void Insert(string groundMoisture)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["GroundMoisture"] = groundMoisture;
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
            System.Data.DataTable table = new DataTable("LFS_WORK_FULLLENGTHLINING_INVERSION_GROUNDMOINSTURE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "GroundMoisture";
            Table.Columns.Add(column);
        }
    }
}
