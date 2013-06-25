using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// ProjectAddSectionsTempGateway
    /// </summary>
    public class SelectProjectLastUsedProjectsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public SelectProjectLastUsedProjectsGateway()
            : base("LastUsedProjects")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public SelectProjectLastUsedProjectsGateway(DataSet data)
            : base(data, "LastUsedProjects")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new SelectProjectTDS();
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
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("UserID", "UserID");
            tableMapping.ColumnMappings.Add("LastLoggedInDate", "LastLoggedInDate");            
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");            
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("ClientName", "ClientName");
            tableMapping.ColumnMappings.Add("InDataBase", "InDataBase");            

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
        /// LoadByLoginIdWorkType
        /// </summary>
        /// <param name="loginId">loginId</param>        
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadByLoginIdWorkType(int loginId, string workType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_SELECTPROJECTLASTUSEDPROJECTSGATEWAY_LOADBYLOGINIDWORKTYPE", new SqlParameter("@loginId", loginId), new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int projectId, int clientId, int userId,  int companyId, string workType)
        {
            string filter = string.Format("(ProjectID = {0}) AND (ClientID = {1}) AND (UserID = {2})  AND (COMPANY_ID = {3}) AND (WorkType = '{4}') ", projectId, clientId, userId, companyId, workType);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.SelectProjectLastUsedProjectsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetProjectId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>ProjectId</returns>
        public int GetProjectId(int projectId, int clientId, int userId, int companyId, string workType)
        {
            return (int)GetRow(projectId, clientId, userId, companyId, workType)["ProjectID"];            
        }



        /// <summary>
        /// GetProjectId Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>Original ProjectId or EMPTY</returns>
        public int GetProjectIdOriginal(int projectId, int clientId, int userId, int companyId, string workType)
        {
            return (int)GetRow(projectId, clientId, userId, companyId, workType)["ProjectID", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetClientId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>ClientId</returns>
        public int GetClientId(int projectId, int clientId, int userId, int companyId, string workType)
        {
            return (int)GetRow(projectId, clientId, userId, companyId, workType)["ClientID"];
        }



        /// <summary>
        /// GetClientId Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="userId">userId</param>       
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>Original ClientId or EMPTY</returns>
        public int GetClientIdOriginal(int projectId, int clientId, int userId, int companyId, string workType)
        {
            return (int)GetRow(projectId, clientId, userId, companyId, workType)["ClientID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetUserId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>UserId</returns>
        public int GetUserId(int projectId, int clientId, int userId, int companyId, string workType)
        {
            return (int)GetRow(projectId, clientId, userId, companyId, workType)["UserID"];
        }



        /// <summary>
        /// GetUserId Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>Original UserId or EMPTY</returns>
        public int GetUserIdOriginal(int projectId, int clientId, int userId, int companyId, string workType)
        {
            return (int)GetRow(projectId, clientId, userId, companyId, workType)["UserID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLastLoggedInDate
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>LastLoggedInDate</returns>
        public DateTime GetLastLoggedInDate(int projectId, int clientId, int userId, int companyId, string workType)
        {
            return (DateTime)GetRow(projectId, clientId, userId, companyId, workType)["LastLoggedInDate"];
        }



        /// <summary>
        /// GetLastLoggedInDate Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>Original LastLoggedInDate or EMPTY</returns>
        public DateTime GetLastLoggedInDateOriginal(int projectId, int clientId, int userId, int companyId, string workType)
        {
            return (DateTime)GetRow(projectId, clientId, userId, companyId, workType)["LastLoggedInDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCompanyId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>CompanyId</returns>
        public int GetCompanyId(int projectId, int clientId, int userId, int companyId, string workType)
        {
            return (int)GetRow(projectId, clientId, userId, companyId, workType)["COMPANY_ID"];
        }



        /// <summary>
        /// GetCompanyId Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>Original CompanyId or EMPTY</returns>
        public int GetCompanyIdOriginal(int projectId, int clientId, int userId, int companyId, string workType)
        {
            return (int)GetRow(projectId, clientId, userId, companyId, workType)["COMPANY_ID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetWorkType
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>WorkType</returns>
        public string GetWorkType(int projectId, int clientId, int userId, int companyId, string workType)
        {
            return (string)GetRow(projectId, clientId, userId, companyId, workType)["WorkType"];
        }



        /// <summary>
        /// GetWorkType Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="userId">userId</param>        
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>Original WorkType or EMPTY</returns>
        public string GetWorkTypeOriginal(int projectId, int clientId, int userId, int companyId, string workType)
        {
            return (string)GetRow(projectId, clientId, userId, companyId, workType)["WorkType", DataRowVersion.Original];
        }
  
    }
}
