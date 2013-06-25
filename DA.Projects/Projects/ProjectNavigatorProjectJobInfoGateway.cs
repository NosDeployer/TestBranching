using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectJobInfoGateway
    /// </summary>
    public class ProjectNavigatorProjectJobInfoGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectJobInfoGateway()
            : base("ProjectJobInfo")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectJobInfoGateway(DataSet data)
            : base(data, "ProjectJobInfo")
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
            tableMapping.DataSetTable = "ProjectJobInfo";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("TypeOfWorkMhRehab", "TypeOfWorkMhRehab");
            tableMapping.ColumnMappings.Add("TypeOfWorkJuntionLining", "TypeOfWorkJuntionLining");
            tableMapping.ColumnMappings.Add("TypeOfWorkProjectManagement", "TypeOfWorkProjectManagement");
            tableMapping.ColumnMappings.Add("TypeOfWorkFullLenghtLining", "TypeOfWorkFullLenghtLining");
            tableMapping.ColumnMappings.Add("TypeOfWorkPointRepairs", "TypeOfWorkPointRepairs");
            tableMapping.ColumnMappings.Add("TypeOfWorkRehabAssessment", "TypeOfWorkRehabAssessment");
            tableMapping.ColumnMappings.Add("TypeOfWorkGrout", "TypeOfWorkGrout");
            tableMapping.ColumnMappings.Add("TypeOfWorkOther", "TypeOfWorkOther");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");                       
            tableMapping.ColumnMappings.Add("Agreement", "Agreement");
            tableMapping.ColumnMappings.Add("WrittenQuote", "WrittenQuote");
            tableMapping.ColumnMappings.Add("Role", "Role");        
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
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTNAVIGATORPROJECTJOBINFOGATEWAY_LOADALLBYPROJECTID", new SqlParameter("@projectId", projectId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <returns>DataRow</returns>
        public DataRow GetRow(int projectId)
        {
            string filter = string.Format("ProjectID = {0} ", projectId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectNavigatorProjectJobInfoGateway.GetRow");
            }
        }



        /// <summary>
        /// GetTypeOfWorkMhRehab
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <returns>TypeOfWorkMhRehab or EMPTY</returns>
        public bool GetTypeOfWorkMhRehab(int projectId)
        {
            return (bool)GetRow(projectId)["TypeOfWorkMhRehab"];         
        }



        /// <summary>
        /// GetTypeOfWorkMhRehab Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Original TypeOfWorkMhRehab or EMPTY</returns>
        public bool GetTypeOfWorkMhRehabOriginal(int projectId)
        {
            return (bool)GetRow(projectId)["TypeOfWorkMhRehab", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetTypeOfWorkJuntionLining
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <returns>TypeOfWorkJuntionLining or EMPTY</returns>
        public bool GetTypeOfWorkJuntionLining(int projectId)
        {
            return (bool)GetRow(projectId)["TypeOfWorkJuntionLining"];
        }



        /// <summary>
        /// GetTypeOfWorkJuntionLining Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Original TypeOfWorkJuntionLining or EMPTY</returns>
        public bool GetTypeOfWorkJuntionLiningOriginal(int projectId)
        {
            return (bool)GetRow(projectId)["TypeOfWorkJuntionLining", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTypeOfWorkProjectManagement
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <returns>TypeOfWorkProjectManagement or EMPTY</returns>
        public bool GetTypeOfWorkProjectManagement(int projectId)
        {
            return (bool)GetRow(projectId)["TypeOfWorkProjectManagement"];
        }



        /// <summary>
        /// GetTypeOfWorkProjectManagement Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Original TypeOfWorkProjectManagement or EMPTY</returns>
        public bool GetTypeOfWorkProjectManagementOriginal(int projectId)
        {
            return (bool)GetRow(projectId)["TypeOfWorkProjectManagement", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTypeOfWorkFullLenghtLining
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <returns>TypeOfWorkFullLenghtLining or EMPTY</returns>
        public bool GetTypeOfWorkFullLenghtLining(int projectId)
        {
            return (bool)GetRow(projectId)["TypeOfWorkFullLenghtLining"];
        }



        /// <summary>
        /// GetTypeOfWorkFullLenghtLining Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Original TypeOfWorkFullLenghtLining or EMPTY</returns>
        public bool GetTypeOfWorkFullLenghtLiningOriginal(int projectId)
        {
            return (bool)GetRow(projectId)["TypeOfWorkFullLenghtLining", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTypeOfWorkPointRepairs
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <returns>TypeOfWorkPointRepairs or EMPTY</returns>
        public bool GetTypeOfWorkPointRepairs(int projectId)
        {
            return (bool)GetRow(projectId)["TypeOfWorkPointRepairs"];
        }



        /// <summary>
        /// GetTypeOfWorkPointRepairs Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Original TypeOfWorkPointRepairs or EMPTY</returns>
        public bool GetTypeOfWorkPointRepairsOriginal(int projectId)
        {
            return (bool)GetRow(projectId)["TypeOfWorkPointRepairs", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTypeOfWorkRehabAssessment
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <returns>TypeOfWorkRehabAssessment or EMPTY</returns>
        public bool GetTypeOfWorkRehabAssessment(int projectId)
        {
            return (bool)GetRow(projectId)["TypeOfWorkRehabAssessment"];
        }



        /// <summary>
        /// GetTypeOfWorkRehabAssessment Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Original TypeOfWorkRehabAssessment or EMPTY</returns>
        public bool GetTypeOfWorkRehabAssessmentOriginal(int projectId)
        {
            return (bool)GetRow(projectId)["TypeOfWorkRehabAssessment", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTypeOfWorkGrout
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <returns>TypeOfWorkGrout or EMPTY</returns>
        public bool GetTypeOfWorkGrout(int projectId)
        {
            return (bool)GetRow(projectId)["TypeOfWorkGrout"];
        }



        /// <summary>
        /// GetTypeOfWorkGrout Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Original TypeOfWorkGrout or EMPTY</returns>
        public bool GetTypeOfWorkGroutOriginal(int projectId)
        {
            return (bool)GetRow(projectId)["TypeOfWorkGrout", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTypeOfWorkOther
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <returns>TypeOfWorkOther or EMPTY</returns>
        public bool GetTypeOfWorkOther(int projectId)
        {
            return (bool)GetRow(projectId)["TypeOfWorkOther"];
        }



        /// <summary>
        /// GetTypeOfWorkOther Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Original TypeOfWorkOther or EMPTY</returns>
        public bool GetTypeOfWorkOtherOriginal(int projectId)
        {
            return (bool)GetRow(projectId)["TypeOfWorkOther", DataRowVersion.Original];
        }



        /// <summary>
        /// GetAgreement
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <returns>Agreement or EMPTY</returns>
        public bool GetAgreement(int projectId)
        {
            return (bool)GetRow(projectId)["Agreement"];
        }



        /// <summary>
        /// GetAgreement Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Original Agreement or EMPTY</returns>
        public bool GetAgreementOriginal(int projectId)
        {
            return (bool)GetRow(projectId)["Agreement", DataRowVersion.Original];
        }



        /// <summary>
        /// GetWrittenQuote
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <returns>WrittenQuote or EMPTY</returns>
        public bool GetWrittenQuote(int projectId)
        {
            return (bool)GetRow(projectId)["WrittenQuote"];
        }



        /// <summary>
        /// GetWrittenQuote Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Original WrittenQuote or EMPTY</returns>
        public bool GetWrittenQuoteOriginal(int projectId)
        {
            return (bool)GetRow(projectId)["WrittenQuote", DataRowVersion.Original];
        }



        /// <summary>
        /// GetRole
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <returns>Role or EMPTY</returns>
        public string GetRole(int projectId)
        {
            if (GetRow(projectId).IsNull("Role"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["Role"];
            }
        }



        /// <summary>
        /// GetRole Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Original Role or EMPTY</returns>
        public string GetRoleOriginal(int projectId)
        {
            if (GetRow(projectId).IsNull(Table.Columns["Role"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["Role", DataRowVersion.Original];
            }
        }
    }
}
