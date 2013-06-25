using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime
{
    /// <summary>
    /// TeamProjectTime2SectionGateway
    /// </summary>
    public class TeamProjectTime2SectionGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public TeamProjectTime2SectionGateway()
            : base("LFS_TEAM_PROJECT_TIME_SECTION")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public TeamProjectTime2SectionGateway(DataSet data)
            : base(data, "LFS_TEAM_PROJECT_TIME_SECTION")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new TeamProjectTime2TDS();
        }



        /// <summary>
        /// InitAdapter (empty)
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "LFS_TEAM_PROJECT_TIME_SECTION";
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("Completed", "Completed");
            tableMapping.ColumnMappings.Add("_Date", "_Date");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("PercentageOpened", "PercentageOpened");
            tableMapping.ColumnMappings.Add("PercentageBrushed", "PercentageBrushed");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }



        // /////////////////////    ///////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByProjectIdWorkTypeForFllPrepAndMeasure
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="workType">workType</param>
        /// <returns>Data</returns>
        public DataSet LoadByProjectIdWorkTypeForFllPrepAndMeasure(int projectId, string workType)
        {
            FillDataWithStoredProcedure("LFS_TEAM_PROJECT_TIME_SECTIONGATEWAY_LOADBYPROJECTIDWORKTYPE", new SqlParameter("@projectId", projectId), new SqlParameter("@workType", workType));
            return Data;
        }



        /// <summary>
        /// LoadByProjectIdWorkTypeForFllInstall
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="workType">workType</param>
        /// <param name="installDate">installDate</param>
        /// <returns>Data</returns>
        public DataSet LoadByProjectIdWorkTypeForFllInstall(int projectId, string workType, DateTime installDate)
        {
            FillDataWithStoredProcedure("LFS_TEAM_PROJECT_TIME_SECTIONINSTALLGATEWAY_LOADBYPROJECTIDWORKTYPE", new SqlParameter("@projectId", projectId), new SqlParameter("@workType", workType), new SqlParameter("@installDate", installDate));
            return Data;
        }



        /// <summary>
        /// LoadByProjectIdWorkTypeForReinstatePostVideo
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="workType">workType</param>
        /// <param name="postVideo">postVideo</param>
        /// <returns>Data</returns>
        public DataSet LoadByProjectIdWorkTypeForReinstatePostVideo(int projectId, string workType, DateTime postVideo)
        {
            FillDataWithStoredProcedure("LFS_TEAM_PROJECT_TIME_SECTIONREINSTATEPOSTVIDEOGATEWAY_LOADBYPROJECTIDWORKTYPE", new SqlParameter("@projectId", projectId), new SqlParameter("@workType", workType), new SqlParameter("@postVideo", postVideo));
            return Data;
        }



    }
}