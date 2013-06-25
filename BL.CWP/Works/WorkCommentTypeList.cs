using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkCommentTypeList
    /// </summary>
    public class WorkCommentTypeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkCommentTypeList()
            : base("LFS_WORK_COMMENT_TYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkCommentTypeList(DataSet data)
            : base(data, "LFS_WORK_COMMENT_TYPE")
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
        /// <param name="commentType">commentType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem( string commentType, int companyId, string workType)
        {
            // Add item
            CreateTableStructure();
            Insert(commentType);

            // Load viewType list
            WorkCommentTypeListGateway workCommentTypeListGateway = new WorkCommentTypeListGateway(Data);
            workCommentTypeListGateway.ClearBeforeFill = false;
            workCommentTypeListGateway.LoadByWorkType(companyId, workType);
            workCommentTypeListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="commentType">commentType</param>
        public void Insert(string commentType)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["Type"] = commentType;
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
            System.Data.DataTable table = new DataTable("LFS_WORK_COMMENT_TYPE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Type";
            Table.Columns.Add(column);
        }



    }
}
