using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddOriginalHotelGateway
    /// </summary>
    public class ProjectCostingSheetAddOriginalHotelGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCostingSheetAddOriginalHotelGateway()
            : base("OriginalHotel")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCostingSheetAddOriginalHotelGateway(DataSet data)
            : base(data, "OriginalHotel")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetAddTDS();
        }



        /// <summary>
        /// InitAdapter (empty)
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.DataSetTable = "OriginalHotel";
            tableMapping.ColumnMappings.Add("HotelID", "HotelID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("Rate", "Rate");
            tableMapping.ColumnMappings.Add("Hotel", "Hotel");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
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
        /// LoadByProjectIdStartDateEndDateHotelId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <returns>Data</byp.returns>
        public DataSet LoadByProjectIdStartDateEndDateHotelId(int projectId, DateTime startDate, DateTime endDate, int hotelId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDORIGINALHOTELGATEWAY_LOADBYPROJECTIDSTARTDATEENDDATEHOTELID", new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@hotelId", hotelId));
            return Data;            
        }



    }
}