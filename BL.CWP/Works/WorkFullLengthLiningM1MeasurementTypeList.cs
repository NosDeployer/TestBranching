using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningM1MeasurementTypeList
    /// </summary
    public class WorkFullLengthLiningM1MeasurementTypeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningM1MeasurementTypeList()
            : base("LFS_WORK_FULLLENGTHLINING_M1_MEASUREMENT_TYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningM1MeasurementTypeList(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_M1_MEASUREMENT_TYPE")
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
        /// <param name="measurementType">measurementType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string measurementType, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(measurementType);

            // Load viewType list
            WorkFullLengthLiningM1MeasurementTypeListGateway workFullLengthLiningM1MeasurementTypeListGateway = new WorkFullLengthLiningM1MeasurementTypeListGateway(Data);
            workFullLengthLiningM1MeasurementTypeListGateway.ClearBeforeFill = false;
            workFullLengthLiningM1MeasurementTypeListGateway.Load(companyId);
            workFullLengthLiningM1MeasurementTypeListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="measurementType">measurementType</param>
        public void Insert(string measurementType)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["MeasurementType"] = measurementType;
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
            System.Data.DataTable table = new DataTable("LFS_WORK_FULLLENGTHLINING_M1_MEASUREMENT_TYPE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "MeasurementType";
            Table.Columns.Add(column);
        }


    }
}
