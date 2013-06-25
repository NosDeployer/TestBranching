using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectNotesGateway
    /// </summary>
    public class ProjectNavigatorProjectNotesGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectNotesGateway()
            : base("ProjectNotes")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectNotesGateway(DataSet data)
            : base(data, "ProjectNotes")
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
            tableMapping.DataSetTable = "ProjectNotes";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("DateTime", "DateTime");
            tableMapping.ColumnMappings.Add("LoginID", "LoginID");
            tableMapping.ColumnMappings.Add("Note", "Note");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("LIBRARY_FILES_ID", "LIBRARY_FILES_ID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ORIGINAL_FILENAME", "ORIGINAL_FILENAME");
            tableMapping.ColumnMappings.Add("FILENAME", "FILENAME");
            tableMapping.ColumnMappings.Add("InNoteDatabase", "InNoteDatabase");           
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
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTNAVIGATORPROJECTNOTESGATEWAY_LOADALLBYPROJECTID", new SqlParameter("@projectId", projectId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int projectId, int refId)
        {
            string filter = string.Format("ProjectID = {0} AND RefID = {1}", projectId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectNavigatorProjectNotesGateway.GetRow");
            }
        }



        /// <summary>
        /// GetSubject
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Subject or EMPTY</returns>
        public string GetSubject(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull("Subject"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["Subject"];
            }
        }



        /// <summary>
        /// GetSubject Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Subject or EMPTY</returns>
        public string GetSubjectOriginal(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull(Table.Columns["Subject"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["Subject", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLoginId Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original LoginID or EMPTY</returns>
        public int GetLoginIdOriginal(int projectId, int refId)
        {
            return (int)GetRow(projectId, refId)["LoginID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDateTime Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original DateTime or EMPTY</returns>
        public DateTime GetDateTimeOriginal(int projectId, int refId)
        {
            return (DateTime)GetRow(projectId, refId)["DateTime", DataRowVersion.Original];
        }



        /// <summary>
        /// GetNote
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Note or EMPTY</returns>
        public string GetNote(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull("Note"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["Note"];
            }
        }



        /// <summary>
        /// GetNote Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Note or EMPTY</returns>
        public string GetNoteOriginal(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull(Table.Columns["Note"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["Note", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLibraryFilesId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>LIBRARY_FILES_ID or EMPTY</returns>
        public int? GetLibraryFilesId(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull("LIBRARY_FILES_ID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectId, refId)["LIBRARY_FILES_ID"];
            }
        }



        /// <summary>
        /// GetLibraryFilesId Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original LIBRARY_FILES_ID or EMPTY</returns>
        public int? GetLibraryFilesIdOriginal(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull(Table.Columns["LIBRARY_FILES_ID"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectId, refId)["LIBRARY_FILES_ID", DataRowVersion.Original];
            }
        }



    }
}
