using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddOriginalUnitGateway
    /// </summary>
    public class ProjectCostingSheetAddOriginalUnitGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCostingSheetAddOriginalUnitGateway()
            : base("OriginalUnit")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCostingSheetAddOriginalUnitGateway(DataSet data)
            : base(data, "OriginalUnit")
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
            tableMapping.DataSetTable = "OriginalUnit";
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("ProjectId", "ProjectId");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("ProjectTime", "ProjectTime");
            tableMapping.ColumnMappings.Add("TowedUnitID", "TowedUnitID");
            tableMapping.ColumnMappings.Add("Work_", "Work_");
            tableMapping.ColumnMappings.Add("Function_", "Function_");
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
        /// Load
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="work_">work_</param>
        /// <param name="unitId">unitId</param>
        /// <returns>Data</byp.returns>
        public DataSet Load(int projectId, DateTime startDate, DateTime endDate, string work_, string function_, int unitId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDORIGINALUNITGATEWAY_LOADBYPROJECTIDSTARTDATEENDDATEWORKFUNCTIONUNITID", new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@work_", work_), new SqlParameter("@function_", function_), new SqlParameter("@unitId", unitId));
            return Data;            
        }



    }
}