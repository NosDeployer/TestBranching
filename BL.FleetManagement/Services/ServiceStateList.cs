using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Services
{
    /// <summary>
    /// ServiceStateList
    /// </summary
    public class ServiceStateList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceStateList()
            : base("LFS_FM_SERVICE_STATE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServiceStateList(DataSet data)
            : base(data, "LFS_FM_SERVICE_STATE")
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
        /// <param name="type">type</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string type, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(type);

            // Load service state list
            ServiceStateListGateway serviceStateListGateway = new ServiceStateListGateway(Data);
            serviceStateListGateway.ClearBeforeFill = false;
            serviceStateListGateway.LoadAll(companyId);
            serviceStateListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="type">type</param>
        public void Insert(string type)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["State"] = type;
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
            System.Data.DataTable table = new DataTable("LFS_FM_SERVICE_STATE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "State";
            Table.Columns.Add(column);
        }


    }
}
