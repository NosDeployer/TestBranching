using System;
using System.Data;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using System.Data.SqlClient;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintUnnapprovedProjectTimesGateway
    /// </summary>
    public class PrintUnnapprovedProjectTimesGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintUnnapprovedProjectTimesGateway()
            : base("UnapprovedProjectTimes")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintUnnapprovedProjectTimesGateway(DataSet data)
            : base(data, "UnapprovedProjectTimes")
        {
        }



        /// <summary>
        /// InitData. Create a PrintProjectCostingTDS dataset
        /// </summary>
        protected override void InitData()
        {
            _data = new PrintUnnapprovedProjectTimesTDS();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "UnapprovedProjectTimes";
            tableMapping.ColumnMappings.Add("EmployeeName", "EmployeeName");
            tableMapping.ColumnMappings.Add("Category", "Category");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("Country", "Country");
            tableMapping.ColumnMappings.Add("Manager", "Manager");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByStartDateEndDateCountryId
        /// </summary>
        /// <para>Load Original with filters</para>
        /// <param name="startDate">Start date filter for report</param>
        /// <param name="endDate">End date filter for report</param>
        /// <param name="countryId">countryId</param>
        public DataSet LoadByStartDateEndDateCountryId(DateTime startDate, DateTime endDate, Int64 countryId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTUNAPPROVEDPROJECTTIMESGATEWAY_LOADBYSTARTDATEENDDATECOUNTRYID", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@countryId", countryId));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateEndDate
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public DataSet LoadByStartDateEndDate(DateTime startDate, DateTime endDate)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTUNAPPROVEDPROJECTTIMESGATEWAY_LOADBYSTARTDATEENDDATE", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate));
            return Data;
        }



    }
}