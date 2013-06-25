using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Services.Services;

namespace LiquiForce.LFSLive.BL.Services.Services
{
    /// <summary>
    /// ServiceList
    /// </summary>
    public class ServiceList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceList() : base("LFS_SERVICE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServiceList(DataSet data) : base(data, "LFS_SERVICE")
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
        /// <param name="serviceId">serviceId</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(int? serviceId, string name, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(serviceId, name);

            // Load companies list
            ServiceListGateway serviceListGateway = new ServiceListGateway(Data);
            serviceListGateway.ClearBeforeFill = false;
            serviceListGateway.Load(companyId);
            serviceListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="name">name</param>
        public void Insert(int? serviceId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            if (serviceId.HasValue)
            {
                newRow["ServiceID"] = serviceId;
            }
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
            System.Data.DataTable table = new DataTable("LFS_SERVICE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ServiceID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }



    }
}
