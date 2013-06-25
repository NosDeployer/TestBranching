using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Common;

namespace LiquiForce.LFSLive.BL.FleetManagement.Common
{
    /// <summary>
    /// FmTypeViewConditionItemList
    /// </summary>
    public class FmTypeViewConditionItemList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmTypeViewConditionItemList()
            : base("LFS_FM_TYPE_VIEW_CONDITION_ITEM")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmTypeViewConditionItemList(DataSet data)
            : base(data, "LFS_FM_TYPE_VIEW_CONDITION_ITEM")
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
        /// <param name="conditionId">conditionId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItemInView(string fmType, int companyId, int conditionId)
        {
            // Add item
            CreateTableStructure();

            // Load viewType list
            FmTypeViewConditionItemListGateway fmTypeViewConditionItemListGateway = new FmTypeViewConditionItemListGateway(Data);
            fmTypeViewConditionItemListGateway.ClearBeforeFill = false;
            fmTypeViewConditionItemListGateway.LoadByFmTypeConditionId(fmType, companyId, conditionId);
            fmTypeViewConditionItemListGateway.ClearBeforeFill = true;

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
            System.Data.DataTable table = new DataTable("LFS_FM_TYPE_VIEW_CONDITION_ITEM");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }        



    }
}