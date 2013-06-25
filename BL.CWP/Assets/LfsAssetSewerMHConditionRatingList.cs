using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Assets;

namespace LiquiForce.LFSLive.BL.CWP.Assets
{
    /// <summary>
    /// LfsAssetSewerMHConditionRatingList
    /// </summary>
    public class LfsAssetSewerMHConditionRatingList: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LfsAssetSewerMHConditionRatingList()
            : base("LFS_ASSET_SEWER_MH_CONDITION_RATING")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LfsAssetSewerMHConditionRatingList(DataSet data)
            : base(data, "LFS_ASSET_SEWER_MH_CONDITION_RATING")
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
        /// <param name="conditionRatingId">conditionRatingId</param>
        /// <param name="conditionRating">conditionRating</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAndAddItem(int conditionRatingId, string conditionRating, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(conditionRatingId, conditionRating);

            // Load countries list
            LfsAssetSewerMHConditionRatingListGateway lfsAssetSewerMHConditionRatingListGateway = new LfsAssetSewerMHConditionRatingListGateway(Data);
            lfsAssetSewerMHConditionRatingListGateway.ClearBeforeFill = false;
            lfsAssetSewerMHConditionRatingListGateway.Load(companyId);
            lfsAssetSewerMHConditionRatingListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="conditionRatingId">conditionRatingId</param>
        /// <param name="conditionRating">conditionRating</param>        
        public void Insert(int conditionRatingId, string conditionRating)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["ConditionRatingId"] = conditionRatingId;
            newRow["ConditionRating"] = conditionRating;
            Table.Rows.Add(newRow);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// CreateTableStructure
        /// </summary>
        public void CreateTableStructure()
        {
            // Create table
            System.Data.DataTable table = new DataTable("LFS_ASSET_SEWER_MH_CONDITION_RATING");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ConditionRatingId";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ConditionRating";
            Table.Columns.Add(column);
        }
    }


}
