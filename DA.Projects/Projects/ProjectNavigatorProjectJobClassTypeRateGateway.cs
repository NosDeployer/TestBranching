using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectJobClassTypeRateGateway
    /// </summary>
    public class ProjectNavigatorProjectJobClassTypeRateGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectJobClassTypeRateGateway()
            : base("LFS_PROJECT_JOB_CLASS_TYPE_RATE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectJobClassTypeRateGateway(DataSet data)
            : base(data, "LFS_PROJECT_JOB_CLASS_TYPE_RATE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectNavigatorTDS();
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
            tableMapping.DataSetTable = "LFS_PROJECT_JOB_CLASS_TYPE_RATE";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("JobClassType", "JobClassType");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Rate", "Rate");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("FringeRate", "FringeRate");
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
        /// LoadAllByProjectId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Data</returns>
        public DataSet LoadAllByProjectId(int projectId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTNAVIGATORPROJECTJOBCLASSTYPERATEGATEWAY_LOADALLBYPROJECTID", new SqlParameter("@projectId", projectId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int projectId, string jobClassType, int refId)
        {
            string filter = string.Format("ProjectID = {0} AND JobClassType = '{1}' AND RefID = {2}", projectId, jobClassType, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectNavigatorProjectServiceGateway.GetRow");
            }
        }



        /// <summary>
        /// GetRate
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Rate</returns>
        public decimal GetRate(int projectId, string jobClassType, int refId)
        {
            return (decimal)GetRow(projectId, jobClassType, refId)["Rate"];            
        }



        /// <summary>
        /// GetRate Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Rate</returns>
        public decimal GetRateOriginal(int projectId, string jobClassType, int refId)
        {
            return (decimal)GetRow(projectId, jobClassType, refId)["Rate", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetFringeRate
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <param name="refId">refId</param>
        /// <returns>FringeRate</returns>
        public decimal GetFringeRate(int projectId, string jobClassType, int refId)
        {
            return (decimal)GetRow(projectId, jobClassType, refId)["FringeRate"];
        }



        /// <summary>
        /// GetFringeRate Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <param name="refId">refId</param>
        /// <returns>Original FringeRate</returns>
        public decimal GetFringeRateOriginal(int projectId, string jobClassType, int refId)
        {
            return (decimal)GetRow(projectId, jobClassType, refId)["FringeRate", DataRowVersion.Original];
        }



    }
}