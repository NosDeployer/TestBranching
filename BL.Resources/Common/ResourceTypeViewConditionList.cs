using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Common;

namespace LiquiForce.LFSLive.BL.Resources.Common
{
    /// <summary>
    /// ResourceTypeViewConditionList
    /// </summary>
    public class ResourceTypeViewConditionList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceTypeViewConditionList()
            : base("LFS_RESOURCES_TYPE_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ResourceTypeViewConditionList(DataSet data)
            : base(data, "LFS_RESOURCES_TYPE_VIEW_CONDITION")
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
        /// LoadAndAddItemInFor
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <returns>dataset</returns>
        public DataSet LoadAndAddItemInFor(string resourceType, int companyId, bool inFor)
        {
            // Add item
            CreateTableStructure();

            // Load viewType list
            ResourceTypeViewConditionListGateway resourceTypeViewConditionListGateway = new ResourceTypeViewConditionListGateway(Data);
            resourceTypeViewConditionListGateway.ClearBeforeFill = false;
            resourceTypeViewConditionListGateway.LoadByResourceTypeInFor(resourceType, companyId, inFor);
            resourceTypeViewConditionListGateway.ClearBeforeFill = true;

            return Data;
        }
        
        /// <summary>
        /// LoadAndAddItemInFor
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <param name="admin">admin</param>
        /// <returns>dataset</returns>
        public DataSet LoadAndAddItemInFor(string resourceType, int companyId, bool inFor, bool admin)
        {
            // Add item
            CreateTableStructure();

            // Load viewType list
            ResourceTypeViewConditionListGateway resourceTypeViewConditionListGateway = new ResourceTypeViewConditionListGateway(Data);
            resourceTypeViewConditionListGateway.ClearBeforeFill = false;

            if (admin)
            {
                resourceTypeViewConditionListGateway.LoadByResourceTypeInFor(resourceType, companyId, inFor);
            }
            else
            {
                // No Admins could not see cost values
                resourceTypeViewConditionListGateway.LoadByResourceTypeInForNoAdmin(resourceType, companyId, inFor);
            }            
            
            resourceTypeViewConditionListGateway.ClearBeforeFill = true;

            return Data;
        }






        /// <summary>
        /// LoadAndAddItemInFor
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <param name="conditionId">conditionId</param>
        /// <param name="name">name</param>
        /// <returns>dataset</returns>
        public DataSet LoadAndAddItemInFor(string resourceType, int companyId, bool inFor, int conditionId, string name)
        {
            // Add item
            CreateTableStructure();
            Insert(conditionId, name);

            // Load viewType list
            ResourceTypeViewConditionListGateway resourceTypeViewConditionListGateway = new ResourceTypeViewConditionListGateway(Data);
            resourceTypeViewConditionListGateway.ClearBeforeFill = false;
            resourceTypeViewConditionListGateway.LoadByResourceTypeInFor(resourceType, companyId, inFor);
            resourceTypeViewConditionListGateway.ClearBeforeFill = true;

            return Data;
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
            System.Data.DataTable table = new DataTable("LFS_RESOURCES_TYPE_VIEW_CONDITION");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "ConditionID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="conditionId">conditionId</param>
        /// <param name="name">name</param>
        public void Insert(int conditionId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["ConditionID"] = conditionId;
            newRow["Name"] = name;
            Table.Rows.Add(newRow);
        }



    }
}

