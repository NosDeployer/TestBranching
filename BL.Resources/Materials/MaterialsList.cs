using System;
using System.Data;
using LiquiForce.LFSLive.DA.Resources.Materials;
using LiquiForce.LFSLive.BL.Common;

namespace LiquiForce.LFSLive.BL.Resources.Materials
{
    /// <summary>
    /// MaterialsList
    /// </summary>
    public class MaterialsList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsList()
            : base("LFS_RESOURCES_MATERIAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsList(DataSet data)
            : base(data, "LFS_RESOURCES_MATERIAL")
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
        /// <param name="description">description</param>
        /// <param name="materialId">materialId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string description, int materialId, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(description, materialId);

            // Load employees list
            MaterialsListGateway materialsListGateway = new MaterialsListGateway(Data);
            materialsListGateway.ClearBeforeFill = false;
            materialsListGateway.Load(companyId);
            materialsListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAndAddItemByType
        /// </summary>        
        /// <param name="description">description</param>
        /// <param name="materialId">materialId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="type">type</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItemByType(string description, int materialId, int companyId, string type)
        {
            // Add item
            CreateTableStructure();
            Insert(description, materialId);

            // Load employees list
            MaterialsListGateway materialsListGateway = new MaterialsListGateway(Data);
            materialsListGateway.ClearBeforeFill = false;
            materialsListGateway.LoadByType(type, companyId);
            materialsListGateway.ClearBeforeFill = true;

            return Data;
        }


       
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="description">description</param>
        /// <param name="materialId">materialId</param>        
        public void Insert(string description, int materialId)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["Description"] = description;
            newRow["MaterialID"] = materialId;
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
            System.Data.DataTable table = new DataTable("LFS_RESOURCES_MATERIAL");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;           

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Description";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "MaterialID";
            Table.Columns.Add(column);
        }



    }
}