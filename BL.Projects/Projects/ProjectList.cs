using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectList
    /// </summary>
    public class ProjectList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectList() : base("LFS_PROJECT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectList(DataSet data) : base(data, "LFS_PROJECT")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DataSet();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAndAddItem
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="name">Project name</param>
        /// <param name="clientId">ClientId - CompaniesId (RAF)</param>
        /// <returns></returns>
        public DataSet LoadAndAddItem(int projectId, string name, int clientId)
        {
            // Add item
            CreateTableStructure();
            Insert(projectId, name);

            // Load project list
            ProjectListGateway projectListGateway = new ProjectListGateway(Data);
            projectListGateway.ClearBeforeFill = false;
            projectListGateway.LoadByClientId(clientId);
            projectListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadProjectsAndAddItem
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="name">Project name</param>
        /// <param name="clientId">ClientId - CompaniesId (RAF)</param>
        /// <returns></returns>
        public DataSet LoadProjectsAndAddItem(int projectId, string name, int clientId)
        {
            // Add item
            CreateTableStructure();
            Insert(projectId, name);

            // Load project list
            ProjectListGateway projectListGateway = new ProjectListGateway(Data);
            projectListGateway.ClearBeforeFill = false;
            projectListGateway.LoadByClientIdProjects(clientId);
            projectListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadActiveProjectsActiveBallparkProjectsAndAddItem
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="name">Project name</param>
        /// <param name="clientId">ClientId - CompaniesId (RAF)</param>
        /// <returns></returns>
        public DataSet LoadActiveProjectsActiveBallparkProjectsAndAddItem(int projectId, string name, int clientId)
        {
            // Add item
            CreateTableStructure();
            Insert(projectId, name);

            // Load project list
            ProjectListGateway projectListGateway = new ProjectListGateway(Data);
            projectListGateway.ClearBeforeFill = false;
            projectListGateway.LoadByClientIdActiveProjectsActiveBallparkProjects(clientId);
            projectListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadActiveProjectsActiveInternalProjectsActiveBallparkProjectsAndAddItem
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="name">Project name</param>
        /// <param name="clientId">ClientId - CompaniesId (RAF)</param>
        /// <returns></returns>
        public DataSet LoadActiveProjectsActiveInternalProjectsActiveBallparkProjectsAndAddItem(int projectId, string name, int clientId)
        {
            // Add item
            CreateTableStructure();
            Insert(projectId, name);

            // Load project list
            ProjectListGateway projectListGateway = new ProjectListGateway(Data);
            projectListGateway.ClearBeforeFill = false;
            projectListGateway.LoadByClientIdActiveProjectsActiveInternalProjectsActiveBallparkProjects(clientId);
            projectListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// LoadProjectsInternalProjectsBallparkProjectsAndAddItem
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="name">Project name</param>
        /// <param name="clientId">ClientId - CompaniesId (RAF)</param>
        /// <returns></returns>
        public DataSet LoadProjectsInternalProjectsBallparkProjectsAndAddItem(int projectId, string name, int clientId)
        {
            // Add item
            CreateTableStructure();
            Insert(projectId, name);

            // Load project list
            ProjectListGateway projectListGateway = new ProjectListGateway(Data);
            projectListGateway.ClearBeforeFill = false;
            projectListGateway.LoadByClientIdProjectsInternalProjectsBallparkProjects(clientId);
            projectListGateway.ClearBeforeFill = true;

            return Data;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="name">name</param>
        public void Insert(int projectId, string name)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructure();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["ProjectID"] = projectId;
            newRow["Name"] = name;
            Table.Rows.Add(newRow);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// CreateTableStructure
        /// </summary>
        private void CreateTableStructure()
        {
            // Create table
            System.Data.DataTable table = new DataTable("LFS_PROJECT");
            Data.Tables.Add(table);

            // Add columns
            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ProjectID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            Table.Columns.Add(column);
        }



    }
}
