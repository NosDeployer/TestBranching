using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime
{
    /// <summary>
    /// TeamProjectTime2SectionLateralGateway
    /// </summary>
    public class TeamProjectTime2SectionLateralGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public TeamProjectTime2SectionLateralGateway()
            : base("LFS_TEAM_PROJECT_TIME_SECTION_LATERAL")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public TeamProjectTime2SectionLateralGateway(DataSet data)
            : base(data, "LFS_TEAM_PROJECT_TIME_SECTION_LATERAL")
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
            tableMapping.DataSetTable = "LFS_TEAM_PROJECT_TIME_SECTION_LATERAL";
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("LateralID", "LateralID");
            tableMapping.ColumnMappings.Add("Opened", "Opened");
            tableMapping.ColumnMappings.Add("Brushed", "Brushed");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("AssetIDLateral", "AssetIDLateral");
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
        /// LoadBySectionId
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <returns>Data</returns>
        public DataSet LoadBySectionId(string sectionId)
        {
            FillDataWithStoredProcedure("LFS_TEAM_PROJECT_TIME_SECTION_LATERALGATEWAY_LOADBYPROJECTIDSECTIONIDWORKTYPE", new SqlParameter("@sectionId",  sectionId));
            return Data;
        }



    }
}