using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Common;

namespace LiquiForce.LFSLive.BL.FleetManagement.Common
{
    /// <summary>
    /// FmViewSortByList
    /// </summary
    public class FmTypeViewSortList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmTypeViewSortList()
            : base("LFS_FM_TYPE_VIEW_SORT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmTypeViewSortList(DataSet data)
            : base(data, "LFS_FM_TYPE_VIEW_SORT")
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
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string fmType, int companyId, bool inFor)
        {
            // Add item
            CreateTableStructure();

            // Load viewType list
            FmTypeViewSortListGateway fmTypeViewSortListGateway = new FmTypeViewSortListGateway(Data);
            fmTypeViewSortListGateway.ClearBeforeFill = false;
            fmTypeViewSortListGateway.LoadByFmTypeInFor(fmType, companyId, inFor);
            fmTypeViewSortListGateway.ClearBeforeFill = true;

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
            System.Data.DataTable table = new DataTable("LFS_FM_TYPE_VIEW_SORT");
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