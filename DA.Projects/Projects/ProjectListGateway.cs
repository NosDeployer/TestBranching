using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectListGateway
    /// </summary>
    public class ProjectListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectListGateway()
            : base("LFS_PROJECT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectListGateway(DataSet data)
            : base(data, "LFS_PROJECT")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DataSet();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            _adapter = new SqlDataAdapter("", DB.Connection);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <returns>Data</returns>
        public DataSet Load()
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTLISTGATEWAY_LOAD");
            return Data;
        }



        /// <summary>
        /// LoadByClientId
        /// </summary>
        /// <param name="clientId">ClientId filter</param>
        /// <returns>Data</returns>
        public DataSet LoadByClientId(int clientId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTLISTGATEWAY_LOADBYCLIENTID", new SqlParameter("@clientId", clientId));
            return Data;
        }



        /// <summary>
        /// LoadByClientIdProjects
        /// </summary>
        /// <param name="clientId">ClientId filter</param>
        /// <returns>Data</returns>
        public DataSet LoadByClientIdProjects(int clientId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTLISTGATEWAY_LOADBYCLIENTIDPROJECTS", new SqlParameter("@clientId", clientId));
            return Data;
        }



        /// <summary>
        /// LoadByClientIdActiveProjectsActiveBallparkProjects
        /// </summary>
        /// <param name="clientId">ClientId filter</param>
        /// <returns>Data</returns>
        public DataSet LoadByClientIdActiveProjectsActiveBallparkProjects(int clientId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTLISTGATEWAY_LOADBYCLIENTIDACTIVEPROJECTSACTIVEBALLPARKPROJECTS", new SqlParameter("@clientId", clientId));
            return Data;
        }



        /// <summary>
        /// LoadByClientIdActiveProjectsActiveInternalProjectsActiveBallparkProjects
        /// </summary>
        /// <param name="clientId">ClientId filter</param>
        /// <returns>Data</returns>
        public DataSet LoadByClientIdActiveProjectsActiveInternalProjectsActiveBallparkProjects(int clientId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTLISTGATEWAY_LOADBYCLIENTIDACTIVEPROJECTSACTIVEINTERNALPROJECTSACTIVEBALLPARKPROJECTS", new SqlParameter("@clientId", clientId));
            return Data;
        }



        /// <summary>
        /// LoadByClientIdProjectsInternalProjectsBallparkProjects
        /// </summary>
        /// <param name="clientId">ClientId filter</param>
        /// <returns>Data</returns>
        public DataSet LoadByClientIdProjectsInternalProjectsBallparkProjects(int clientId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTLISTGATEWAY_LOADBYCLIENTIDPROJECTSINTERNALPROJECTSBALLPARKPROJECTS", new SqlParameter("@clientId", clientId));
            return Data;
        }



    }
}
