using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;

namespace LiquiForce.LFSLive.BL.CWP.Section
{
    /// <summary>
    /// SectionDSMHMN
    /// </summary>
    public class SectionMH : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //
        /// <summary>
        /// Constructor
        /// </summary>
        public SectionMH()
            : base("LFS_MASTER_AREA")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SectionMH(DataSet data)
            : base(data, "LFS_MASTER_AREA")
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
        /// <param name="mh">mh</param>
        /// <param name="mhType">mhType</param>
        /// <param name="id">ID</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAndAddItem(string mh, string mhType, Guid id, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(mh, mhType);

            // Load USMHMN and DSMHMN
            SectionMHGateway sectionMHGateway = new SectionMHGateway(Data);
            sectionMHGateway.ClearBeforeFill = false;
            sectionMHGateway.LoadUSMHMNById(companyId, id); //Note: COMPANY_ID
            sectionMHGateway.LoadDSMHMNById(companyId, id); //Note: COMPANY_ID
            sectionMHGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="mh">mh</param>
        /// <param name="mhType">mhType</param>
        public void Insert(string mh, string mhType)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["MH"] = mh;
            newRow["MHType"] = mhType;
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
            System.Data.DataTable table = new DataTable("LFS_MASTER_AREA");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "MH";
            Table.Columns.Add(column);

            // Add columns
            DataColumn column2;
            column2 = new DataColumn();
            column2.DataType = System.Type.GetType("System.String");
            column2.ColumnName = "MHType";
            Table.Columns.Add(column2);
        }



    }
}
