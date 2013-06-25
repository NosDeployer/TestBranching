using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime
{
    /// <summary>
    /// TeamProjectTime2SectionMHGateway
    /// </summary>
    public class TeamProjectTime2SectionMHGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public TeamProjectTime2SectionMHGateway()
            : base("LFS_TEAM_PROJECT_TIME_SECTION_MH")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public TeamProjectTime2SectionMHGateway(DataSet data)
            : base(data, "LFS_TEAM_PROJECT_TIME_SECTION_MH")
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
            tableMapping.DataSetTable = "LFS_TEAM_PROJECT_TIME_SECTION_MH";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("ManholeNumber", "ManholeNumber");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("SquareFoot", "SquareFoot");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("_Date", "_Date");
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
        /// LoadBySectionId
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadBySectionId(string sectionId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_TEAM_PROJECT_TIME_SECTION_MHGATEWAY_LOADBYSECTIONID", new SqlParameter("@sectionId", sectionId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByProjectId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByProjectId(int projectId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_TEAM_PROJECT_TIME_SECTION_MHGATEWAY_LOADBYPROJECTID", new SqlParameter("@projectId", projectId), new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}