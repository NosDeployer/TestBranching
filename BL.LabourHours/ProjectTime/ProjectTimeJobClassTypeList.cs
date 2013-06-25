using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// ProjectTimeJobClassTypeList
    /// </summary>
    public class ProjectTimeJobClassTypeList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTimeJobClassTypeList()
            : base("LFS_PROJECT_TIME_JOB_CLASS_TYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTimeJobClassTypeList(DataSet data)
            : base(data, "LFS_PROJECT_TIME_JOB_CLASS_TYPE")
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
        /// <param name="countryId"></param>
        /// <param name="companyId">companyId</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <returns>Data</returns>
        public DataSet LoadAndAddItem(int countryId, int companyId, string jobClassType)
        {
            // Add item
            CreateTableStructure();
            Insert(jobClassType);

            // Load work list
            ProjectTimeJobClassTypeListGateway projectTimeJobClassTypeListGateway = new ProjectTimeJobClassTypeListGateway(Data);
            projectTimeJobClassTypeListGateway.ClearBeforeFill = false;
            projectTimeJobClassTypeListGateway.LoadByCountryId(countryId, companyId);
            projectTimeJobClassTypeListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="jobClassType">jobClassType</param>
        public void Insert(string jobClassType)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["JobClassType"] = jobClassType;
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
            System.Data.DataTable table = new DataTable("LFS_PROJECT_TIME_JOB_CLASS_TYPE");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "JobClassType";
            Table.Columns.Add(column);
        }


        
    }
}