using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Common;

namespace LiquiForce.LFSLive.BL.FleetManagement.Common
{
    /// <summary>
    /// FmViewList
    /// </summary
    public class FmViewList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmViewList()
            : base("LFS_FM_VIEW")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmViewList(DataSet data)
            : base(data, "LFS_FM_VIEW")
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
        /// <param name="viewTypeGlobal">viewTypeGlobal</param>
        /// <param name="viewTypePersonal">viewTypePersonal</param>
        /// <param name="loginId">loginId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAndAddItem(string fmType, string viewTypeGlobal, string viewTypePersonal, int loginId, int companyId)
        {
            // Add item
            CreateTableStructure();

            // Load viewType list
            FmViewListGateway fmViewListGateway = new FmViewListGateway(Data);
            fmViewListGateway.ClearBeforeFill = false;

            // Global views
            if (viewTypeGlobal == "Global")
            {
                Insert(-1, "----- GLOBAL VIEWS -----");
                fmViewListGateway.LoadByFmTypeGlobalViewType(fmType, viewTypeGlobal, companyId);
            }

            //Personal Views
            Insert(-2, "----- PERSONAL VIEWS -----");
            fmViewListGateway.LoadByFmTypeLoginIdViewType(fmType, loginId, viewTypePersonal, companyId);

            fmViewListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="comment">comment</param>
        public void Insert(int viewId, string comment)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["ViewID"] = viewId;
            newRow["Name"] = comment;
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
            System.Data.DataTable table = new DataTable("LFS_FM_VIEW");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ViewID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }



    }
}