using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectSelectProjectLastUsedProjectsGateway
    /// </summary>
    public class ProjectSelectProjectLastUsedProjectsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectSelectProjectLastUsedProjectsGateway()
            : base("LastUsedProjects")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectSelectProjectLastUsedProjectsGateway(DataSet data)
            : base(data, "LastUsedProjects")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectSelectProjectTDS();
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
            tableMapping.DataSetTable = "LastUsedProjects";                        
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("UserID", "UserID");
            tableMapping.ColumnMappings.Add("LastLoggedInDate", "LastLoggedInDate");            
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");            
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");            
            tableMapping.ColumnMappings.Add("InDataBase", "InDataBase");
            tableMapping.ColumnMappings.Add("ClientName", "ClientName");
            tableMapping.ColumnMappings.Add("Description", "Description");
            
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
        /// LoadByLoginId
        /// </summary>
        /// <param name="loginId">loginId</param>  
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadByLoginId(int loginId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_SELECTPROJECTLASTUSEDPROJECTSGATEWAY_LOADBYLOGINID", new SqlParameter("@loginId", loginId),  new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>        
        /// <returns>DataRow</returns>
        public DataRow GetRow(int projectId, int userId,  int companyId)
        {
            string filter = string.Format("(ProjectID = {0})  AND (UserID = {1})  AND (COMPANY_ID = {2}) ", projectId, userId, companyId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.SelectProjectLastUsedProjectsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetProjectId
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>        
        /// <returns>ProjectId</returns>
        public int GetProjectId(int projectId, int userId, int companyId)
        {
            return (int)GetRow(projectId,  userId, companyId)["ProjectID"];            
        }



        /// <summary>
        /// GetProjectId Original
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>        
        /// <returns>Original ProjectId</returns>
        public int GetProjectIdOriginal(int projectId, int userId, int companyId)
        {
            return (int)GetRow(projectId, userId, companyId)["ProjectID", DataRowVersion.Original];            
        }        



        /// <summary>
        /// GetUserId
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>        
        /// <returns>UserId</returns>
        public int GetUserId(int projectId, int userId, int companyId)
        {
            return (int)GetRow(projectId, userId, companyId)["UserID"];
        }



        /// <summary>
        /// GetUserId Original
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>        
        /// <returns>Original UserId</returns>
        public int GetUserIdOriginal(int projectId, int userId, int companyId)
        {
            return (int)GetRow(projectId, userId, companyId)["UserID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLastLoggedInDate
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>        
        /// <returns>LastLoggedInDate</returns>
        public DateTime GetLastLoggedInDate(int projectId, int userId, int companyId)
        {
            return (DateTime)GetRow(projectId, userId, companyId)["LastLoggedInDate"];
        }



        /// <summary>
        /// GetLastLoggedInDate Original
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>        
        /// <returns>Original LastLoggedInDate</returns>
        public DateTime GetLastLoggedInDateOriginal(int projectId,  int userId, int companyId)
        {
            return (DateTime)GetRow(projectId,  userId, companyId)["LastLoggedInDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCompanyId
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>        
        /// <returns>CompanyId</returns>
        public int GetCompanyId(int projectId, int userId, int companyId)
        {
            return (int)GetRow(projectId,  userId, companyId)["COMPANY_ID"];
        }



        /// <summary>
        /// GetCompanyId Original
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>        
        /// <returns>Original CompanyId</returns>
        public int GetCompanyIdOriginal(int projectId, int userId, int companyId)
        {
            return (int)GetRow(projectId,  userId, companyId)["COMPANY_ID", DataRowVersion.Original];
        }



    }
}