using System;
using System.Data;
using LiquiForce.LFSLive.DA.Resources.Materials;
using LiquiForce.LFSLive.BL.Common;

namespace LiquiForce.LFSLive.BL.Resources.Materials
{
    /// <summary>
    /// MaterialsTypeList
    /// </summary>
    public class MaterialsTypeList: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsTypeList()
            : base("LFS_RESOURCES_MATERIAL_TYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsTypeList(DataSet data)
            : base(data, "LFS_RESOURCES_MATERIAL_TYPE")
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
            Insert(type, companyId);

            // Load employees list
            MaterialsTypeListGateway materialsTypeListGateway = new MaterialsTypeListGateway(Data);
            materialsTypeListGateway.ClearBeforeFill = false;
            materialsTypeListGateway.Load(companyId);
            materialsTypeListGateway.ClearBeforeFill = true;

            return Data;
        }


       
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="companyId">companyId</param>        
        public void Insert(string type, int companyId)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["Type"] = type;
            newRow["COMPANY_ID"] = companyId;
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
            System.Data.DataTable table = new DataTable("LFS_RESOURCES_MATERIAL_TYPE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;           

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Type";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "COMPANY_ID";
            Table.Columns.Add(column);
        }



    }
}