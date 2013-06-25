using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningM1SiteDetailsList
    /// </summary>
    public class WorkFullLengthLiningM1SiteDetailsList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningM1SiteDetailsList()
            : base("LFS_WORK_FULLLENGTHLINING_M1_SITE_DETAILS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningM1SiteDetailsList(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_M1_SITE_DETAILS")
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
        /// <param name="siteDetails">siteDetails</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAndAddItem(string siteDetails, int companyId)
        {
            // Add item
            CreateTableStructure();
            Insert(siteDetails);

            // Load viewType list
            WorkFullLengthLiningM1SiteDetailsListGateway workFullLengthLiningM1SiteDetailsListGateway = new WorkFullLengthLiningM1SiteDetailsListGateway(Data);
            workFullLengthLiningM1SiteDetailsListGateway.ClearBeforeFill = false;
            workFullLengthLiningM1SiteDetailsListGateway.Load(companyId);
            workFullLengthLiningM1SiteDetailsListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="siteDetails">siteDetails</param>
        public void Insert(string siteDetails)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["SiteDetails"] = siteDetails;
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
            System.Data.DataTable table = new DataTable("LFS_WORK_FULLLENGTHLINING_M1_SITE_DETAILS");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "SiteDetails";
            Table.Columns.Add(column);
        }

    }
}
