using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Common;

namespace LiquiForce.LFSLive.BL.Resources.Common
{
    /// <summary>
    /// ResourceTypeViewSortList
    /// </summary>
    public class ResourceTypeViewSortList : TableModule 
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceTypeViewSortList()
            : base("LFS_RESOURCES_TYPE_VIEW_SORT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ResourceTypeViewSortList(DataSet data)
            : base(data, "LFS_RESOURCES_TYPE_VIEW_SORT")
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
        /// <returns></returns>
        public DataSet LoadAndAddItemInFor(string resourceType, int companyId, bool inFor)
        {
            // Add item
            CreateTableStructure();

            // Load viewType list
            ResourceTypeViewSortListGateway resourceTypeViewSortListGateway = new ResourceTypeViewSortListGateway(Data);
            resourceTypeViewSortListGateway.ClearBeforeFill = false;
            resourceTypeViewSortListGateway.LoadByResourceTypeInFor(resourceType, companyId, inFor);
            resourceTypeViewSortListGateway.ClearBeforeFill = true;

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
            System.Data.DataTable table = new DataTable("LFS_RESOURCES_TYPE_VIEW_SORT");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;
            
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "SortID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }



    }
}