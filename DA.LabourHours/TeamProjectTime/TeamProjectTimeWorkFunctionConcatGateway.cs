using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime
{
    /// <summary>
    /// TeamProjectTimeWorkFunctionConcatGateway
    /// </summary>
    public class TeamProjectTimeWorkFunctionConcatGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TeamProjectTimeWorkFunctionConcatGateway()
            : base("TEAM_PROJECT_TIME_WORK_FUNCTION_CONCAT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public TeamProjectTimeWorkFunctionConcatGateway(DataSet data)
            : base(data, "TEAM_PROJECT_TIME_WORK_FUNCTION_CONCAT")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new TeamProjectTime2TDS();
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
            tableMapping.DataSetTable = "TEAM_PROJECT_TIME_WORK_FUNCTION_CONCAT";
            tableMapping.ColumnMappings.Add("WorkFunctionConcat", "WorkFunctionConcat");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion

        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadWorkFunctionConcat
        /// </summary>
        /// <returns>Data</returns>
        public DataSet LoadWorkFunctionConcat()
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_TEAMPROJECTTIMEWORKFUNCTIONCONCATGATEWAY_LOADWORKFUNCTIONCONCAT");
            return Data;
        }



    }
}