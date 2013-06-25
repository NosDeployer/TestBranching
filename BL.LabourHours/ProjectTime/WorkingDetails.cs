using System;
using System.Data;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// WorkingDetails
    /// </summary>
    public class WorkingDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkingDetails() : base("LFS_WORKING_DETAILS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkingDetails(DataSet data) : base(data, "LFS_WORKING_DETAILS")
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
        /// <param name="workingDetails">workingDetails</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string workingDetails)
        {
            // Add item
            CreateTableStructure();
            Insert(workingDetails);

            // Load working details list
            WorkingDetailsGateway workingDetailsGateway = new WorkingDetailsGateway(Data);
            workingDetailsGateway.ClearBeforeFill = false;
            workingDetailsGateway.Load();
            workingDetailsGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadActiveAndAddItem
        /// </summary>
        /// <param name="workingDetails">workingDetails</param>
        /// <returns>DataSet</returns>
        public DataSet LoadActiveAndAddItem(string workingDetails)
        {
            // Add item
            CreateTableStructure();
            Insert(workingDetails);

            // Load working details list
            WorkingDetailsGateway workingDetailsGateway = new WorkingDetailsGateway(Data);
            workingDetailsGateway.ClearBeforeFill = false;
            workingDetailsGateway.LoadActive();
            workingDetailsGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="workingDetails">workingDetails</param>
        public void Insert(string workingDetails)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["WorkingDetails"] = workingDetails;
            Table.Rows.Add(newRow);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// CreateTableStructure
        /// </summary>
        private void CreateTableStructure()
        {
            // Create table
            DataTable table = new DataTable("LFS_WORKING_DETAILS");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "WorkingDetails";
            Table.Columns.Add(column);
        }


        
    }
}