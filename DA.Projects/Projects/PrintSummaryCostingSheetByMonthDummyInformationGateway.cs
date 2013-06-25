using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    public class PrintSummaryCostingSheetByMonthDummyInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintSummaryCostingSheetByMonthDummyInformationGateway()
            : base("DummyInformation")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintSummaryCostingSheetByMonthDummyInformationGateway(DataSet data)
            : base(data, "DummyInformation")
        {
        }



        /// <summary>
        /// InitData. Create a PrintManhoursPerPhaseTDS dataset
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetAddTDS();
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
            tableMapping.DataSetTable = "DummyInformation";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjetID");
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
        /// Load
        /// </summary>   
        public DataSet LoadProjectsWithTimesheets(DateTime startDate, DateTime endDate)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTLISTGATEWAY_LOADPROJECTSWITHTIMESHEETS", new SqlParameter("startDate", startDate), new SqlParameter("endDate", endDate));
            return Data;
        }



    }
}