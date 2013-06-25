using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectOtherCostsBudgetGateway
    /// </summary>
    public class ProjectNavigatorProjectOtherCostsBudgetGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectOtherCostsBudgetGateway()
            : base("ProjectOtherCostsBudget")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectOtherCostsBudgetGateway(DataSet data)
            : base(data, "ProjectOtherCostsBudget")
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
            tableMapping.DataSetTable = "ProjectOtherCostsBudget";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("Category", "Category");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Budget", "Budget");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
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
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTNAVIGATORPROJECTOTHERCOSTSBUDGET_LOADALLBYPROJECTID", new SqlParameter("@projectId", projectId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="category">category</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int projectId, string category, int refId)
        {
            string filter = string.Format("ProjectID = {0} AND Category = '{1}' AND RefID = {2}", projectId, category, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectNavigatorProjectOtherCostsBudgetGateway.GetRow");
            }
        }



        /// <summary>
        /// GetBudget
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="category">category</param>
        /// <param name="refId">refId</param>
        /// <returns>Budget</returns>
        public decimal GetBudget(int projectId, string category, int refId)
        {
            return (decimal)GetRow(projectId, category, refId)["Budget"];            
        }



        /// <summary>
        /// GetBudget Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="category">category</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Budget</returns>
        public decimal GetBudgetOriginal(int projectId, string category, int refId)
        {
            return (decimal)GetRow(projectId, category, refId)["Budget", DataRowVersion.Original];            
        }     



    }
}