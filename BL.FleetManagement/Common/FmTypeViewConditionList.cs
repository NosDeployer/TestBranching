using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Common;

namespace LiquiForce.LFSLive.BL.FleetManagement.Common
{
    /// <summary>
    /// FmTypeViewConditionList
    /// </summary>
    public class FmTypeViewConditionList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmTypeViewConditionList()
            : base("LFS_FM_TYPE_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmTypeViewConditionList(DataSet data)
            : base(data, "LFS_FM_TYPE_VIEW_CONDITION")
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
        /// LoadAndAddItemInView
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inView">inView</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItemInView(string fmType, int companyId, bool inView)
        {
            // Add item
            CreateTableStructure();

            // Load viewType list
            FmTypeViewConditionListGateway fmTypeViewConditionListGateway = new FmTypeViewConditionListGateway(Data);
            fmTypeViewConditionListGateway.ClearBeforeFill = false;
            fmTypeViewConditionListGateway.LoadByFmTypeInView(fmType, companyId, inView);
            fmTypeViewConditionListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadAndAddItemInFor
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inFor">inFor</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItemInFor(string fmType, int companyId, bool inFor)
        {
            // Add item
            CreateTableStructure();

            // Load viewType list
            FmTypeViewConditionListGateway fmTypeViewConditionListGateway = new FmTypeViewConditionListGateway(Data);
            fmTypeViewConditionListGateway.ClearBeforeFill = false;
            fmTypeViewConditionListGateway.LoadByFmTypeInFor(fmType, companyId, inFor);
            fmTypeViewConditionListGateway.ClearBeforeFill = true;

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
            System.Data.DataTable table = new DataTable("LFS_FM_TYPE_VIEW_CONDITION");
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



    }
}