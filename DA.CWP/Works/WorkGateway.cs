using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkGateway
    /// </summary>
    public class WorkGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkGateway() : base("LFS_WORK")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkGateway(DataSet data) : base(data, "LFS_WORK")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WorkTDS();
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
            tableMapping.DataSetTable = "LFS_WORK";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("WorkType", "WorkType");
            tableMapping.ColumnMappings.Add("LIBRARY_CATEGORIES_ID", "LIBRARY_CATEGORIES_ID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("History", "History");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_WORK] WHERE (([WorkID] = @Original_WorkID) AND ([ProjectID] = @Original_ProjectID) AND ([AssetID] = @Original_AssetID) AND ([WorkType] = @Original_WorkType) AND ((@IsNull_LIBRARY_CATEGORIES_ID = 1 AND [LIBRARY_CATEGORIES_ID] IS NULL) OR ([LIBRARY_CATEGORIES_ID] = @Original_LIBRARY_CATEGORIES_ID)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK] ([ProjectID], [AssetID], [WorkType], [LIBRARY_CATEGORIES_ID], [Deleted], [COMPANY_ID], [Comments], [History]) VALUES (@ProjectID, @AssetID, @WorkType, @LIBRARY_CATEGORIES_ID, @Deleted, @COMPANY_ID, @Comments, @History);
SELECT WorkID, ProjectID, AssetID, WorkType, LIBRARY_CATEGORIES_ID, Deleted, COMPANY_ID, Comments, History FROM LFS_WORK WHERE (WorkID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@History", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "History", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_WORK] SET [ProjectID] = @ProjectID, [AssetID] = @AssetID, [WorkType] = @WorkType, [LIBRARY_CATEGORIES_ID] = @LIBRARY_CATEGORIES_ID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [Comments] = @Comments, [History] = @History WHERE (([WorkID] = @Original_WorkID) AND ([ProjectID] = @Original_ProjectID) AND ([AssetID] = @Original_AssetID) AND ([WorkType] = @Original_WorkType) AND ((@IsNull_LIBRARY_CATEGORIES_ID = 1 AND [LIBRARY_CATEGORIES_ID] IS NULL) OR ([LIBRARY_CATEGORIES_ID] = @Original_LIBRARY_CATEGORIES_ID)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT WorkID, ProjectID, AssetID, WorkType, LIBRARY_CATEGORIES_ID, Deleted, COMPANY_ID, Comments, History FROM LFS_WORK WHERE (WorkID = @WorkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@History", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "History", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssetID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssetID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByWorkId(int workId,int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKGATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByAssetId
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByAssetId(int assetId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKGATEWAY_LOADBYASSETID", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));
            return Data;        
        }



        /// <summary>
        /// LoadByProjectIdAssetIdWorkType
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="workType">workType</param>
        /// <param name="currentProjectId">currentProjectId</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByProjectIdAssetIdWorkType(int currentProjectId, int assetId, string workType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKGATEWAY_LOADBYPROJECTIDASSETIDWORKTYPE", new SqlParameter("@currentProjectId", currentProjectId), new SqlParameter("@assetId", assetId), new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId));
            return Data;
        }

        

        /// <summary>
        /// Get a single work
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="workType">workType</param>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int assetId, string workType, int currentProjectId)
        {
            string filter = string.Format("(AssetID = {0}) AND (WorkType = '{1}') AND (ProjectID = {2})", assetId, workType, currentProjectId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Works.WorkGateway.GetRow");
            }
        }



        /// <summary>
        /// Get a single work
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int workId)
        {
            string filter = string.Format("(WorkID = {0})", workId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Works.WorkGateway.GetRow");
            }
        }



        /// <summary>
        /// GetWorkId. If project not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="workType">workType</param>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <returns>WorkId</returns>
        public int GetWorkId(int assetId, string workType, int currentProjectId)
        {
            return (int)GetRow(assetId,workType, currentProjectId)["WorkID"];
        }



        /// <summary>
        /// GetAssetId. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>AssetID</returns>
        public int GetAssetId(int workId)
        {
            return (int)GetRow(workId)["AssetID"];
        }



        /// <summary>
        /// GetProjectId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ProjectID</returns>
        public int GetProjectId(int workId)
        {
            return (int)GetRow(workId)["ProjectID"];
        }



        /// <summary>
        /// GetWorkType
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>work type or EMPTY</returns>
        public string GetWorkType(int workId)
        {
            if (GetRow(workId).IsNull("WorkType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["WorkType"];
            }
        }



        /// <summary>
        /// GetWorkType Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original WorkType or EMPTY</returns>
        public string GetWorkTypeOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["WorkType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["WorkType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLibraryCategoriesId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>LIBRARY_CATEGORIES_ID or NULL</returns>
        public int? GetLibraryCategoriesId(int workId)
        {
            if (GetRow(workId).IsNull("LIBRARY_CATEGORIES_ID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["LIBRARY_CATEGORIES_ID"];
            }
        }



        /// <summary>
        /// GetLibraryCategoriesId Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original LibraryCategoriesId or NULL</returns>
        public int? GetLibraryCategoriesIdOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["LIBRARY_CATEGORIES_ID"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["LIBRARY_CATEGORIES_ID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDeleted. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TRUE if project deleted</returns>
        public bool GetDeleted(int workId)
        {
            return (bool)GetRow(workId)["Deleted"];
        }



        /// <summary>
        /// GetCompanyID. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CompanyId - CompaniesId</returns>
        public int GetCompanyID(int workId)
        {
            return (int)GetRow(workId)["COMPANY_ID"];
        }



        /// <summary>
        /// GetComments
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Comments or EMPTY</returns>
        public string GetComments(int workId)
        {
            if (GetRow(workId).IsNull("Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Comments"];
            }
        }



        /// <summary>
        /// GetComments Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Comments or EMPTY</returns>
        public string GetCommentsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Comments"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Comments", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetHistory
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>History or EMPTY</returns>
        public string GetHistory(int workId)
        {
            if (GetRow(workId).IsNull("History"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["History"];
            }
        }



        /// <summary>
        /// GetHistory Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original History or EMPTY</returns>
        public string GetHistoryOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["History"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["History", DataRowVersion.Original];
            }
        }
        




        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //
        
        /// <summary>
        /// Verify if the asset is used in any work
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>true if the assetId is used in any work</returns>
        public bool InUseAssetId(int assetId, int companyId)
        {
            string commandText = "SELECT COUNT(*) FROM dbo.LFS_WORK WHERE (AssetId = @assetId) AND (Deleted = 0) AND (COMPANY_ID = @companyId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@assetId", assetId));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));

            int count = (int)ExecuteScalar(command);

            return (count > 0) ? true : false;
        }



        /// <summary>
        /// ExistsProjectIdAssetIdWorkTypeCompanyId
        /// </summary>
        /// <param name="assetId">AssetId</param>
        /// <param name="currentProjectId">currentProjectId filter</param>
        /// <param name="workType">WorkType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>boolean</returns>
        public Boolean ExistsProjectIdAssetIdWorkTypeCompanyId(int assetId, int currentProjectId, string workType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKGATEWAY_LOADBYPROJECTIDASSETIDWORKTYPECOMPANYID", new SqlParameter("@assetId", assetId), new SqlParameter("@projectId", currentProjectId), new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId));//COMPANY_ID
            if ((int)Table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// ExistsProjectIdAssetIdWorkTypeCompanyId
        /// </summary>
        /// <param name="assetId">AssetId</param>
        /// <param name="currentProjectId">currentProjectId filter</param>
        /// <param name="workType">WorkType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>boolean</returns>
        public Boolean ExistsProjectIdAssetIdWorkTypeCompanyId(int currentProjectId, int assetId, int companyId, string workType)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKGATEWAY_LOADBYPROJECTIDASSETIDWORKTYPECOMPANYID", new SqlParameter("@assetId", assetId), new SqlParameter("@projectId", currentProjectId), new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId));//COMPANY_ID
            if ((int)Table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// Verify if a section exists in a project with specific work
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public bool ExistsSectionByProjectIdSectionIdWorkType(int projectId, string sectionId, string workType, int companyId)
        {
            SqlParameter projectIdParameter = new SqlParameter("projectId", projectId);
            SqlParameter sectionIdParameter = new SqlParameter("sectionId", sectionId);
            SqlParameter workTypeParameter = new SqlParameter("workType", workType);
            SqlParameter companyIdParameter = new SqlParameter("companyId", companyId);

            string command = "SELECT COUNT(*) FROM dbo.LFS_WORK W INNER JOIN dbo.AM_ASSET_SEWER_SECTION ASS ON W.AssetID = ASS.AssetID WHERE (W.Deleted = 0) AND (ASS.Deleted = 0) AND (W.ProjectID = @projectId) AND (W.COMPANY_ID = @companyId) AND (ASS.SectionID = @sectionId) AND (W.WorkType LIKE @workType)";

            int count = (int) ExecuteScalar(command, projectIdParameter, sectionIdParameter, workTypeParameter, companyIdParameter);

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a new work (direct to DB)
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="workType">workType</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="comments">comments</param>
        /// <param name="history">history</param>
        /// <returns>workId</returns>
        public int Insert(int projectId, int assetId, string workType, int? libraryCategoriesId, bool deleted, int companyId, string comments, string history)
        {
            SqlParameter projectIdParameter = new SqlParameter("ProjectID", projectId);
            SqlParameter assetIdParameter = new SqlParameter("AssetID", assetId);
            SqlParameter workTypeParameter = new SqlParameter("WorkType", workType);
            SqlParameter libraryCategoriesIdParameter = (libraryCategoriesId.HasValue) ? new SqlParameter("LIBRARY_CATEGORIES_ID", (int)libraryCategoriesId) : new SqlParameter("LIBRARY_CATEGORIES_ID", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter commentsParameter = (comments.Trim() != "") ? new SqlParameter("Comments", comments.Trim()) : new SqlParameter("Comments", DBNull.Value);
            SqlParameter historyParameter = (history.Trim() != "") ? new SqlParameter("History", history.Trim()) : new SqlParameter("History", DBNull.Value);

            string command = "INSERT INTO [dbo].[LFS_WORK] ([ProjectID], [AssetID], [WorkType], [LIBRARY_CATEGORIES_ID], [Deleted], [COMPANY_ID], [Comments], [History]) VALUES (@ProjectID, @AssetID, @WorkType, @LIBRARY_CATEGORIES_ID, @Deleted, @COMPANY_ID, @Comments, @History); SELECT WorkID FROM LFS_WORK WHERE (WorkID = SCOPE_IDENTITY())";

            int workId = (int) ExecuteScalar(command, projectIdParameter, assetIdParameter, workTypeParameter, libraryCategoriesIdParameter, deletedParameter, companyIdParameter, commentsParameter, historyParameter);

            return workId;
        }



        /// <summary>
        /// Update work (direct to DB)
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalAssetId">originalAssetId</param>
        /// <param name="originalWorkType">originalWorkType</param>
        /// <param name="originalLibraryCategoriesId">originalLibraryCategoriesId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalHistory">originalHistory</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newAssetId">newAssetId</param>
        /// <param name="newWorkType">newWorkType</param>
        /// <param name="newLibraryCategoriesId">newLibraryCategoriesId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newHistory">newHistory</param>
        public int Update(int originalWorkId, int originalProjectId, int originalAssetId, string originalWorkType, int? originalLibraryCategoriesId, bool originalDeleted, int originalCompanyId, string originalComments, string originalHistory, int newWorkId, int newProjectId, int newAssetId, string newWorkType, int? newLibraryCategoriesId, bool newDeleted, int newCompanyId, string newComments, string newHistory)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", originalWorkId);
            SqlParameter originalProjectIdParameter = new SqlParameter("Original_ProjectID", originalProjectId);
            SqlParameter originalAssetIdParameter = new SqlParameter("Original_AssetID", originalAssetId);
            SqlParameter originalWorkTypeParameter = new SqlParameter("Original_WorkType", originalWorkType);
            SqlParameter originalLibraryCategoriesIdParameter = (originalLibraryCategoriesId.HasValue) ? new SqlParameter("Original_LIBRARY_CATEGORIES_ID", (int)originalLibraryCategoriesId) : new SqlParameter("Original_LIBRARY_CATEGORIES_ID", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalCommentsParameter = (originalComments.Trim() != "") ? new SqlParameter("Original_Comments", originalComments.Trim()) : new SqlParameter("Original_Comments", DBNull.Value);
            SqlParameter originalHistoryParameter = (originalHistory.Trim() != "") ? new SqlParameter("Original_History", originalHistory.Trim()) : new SqlParameter("Original_History", DBNull.Value);

            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", newWorkId);
            SqlParameter newProjectIdParameter = new SqlParameter("ProjectID", newProjectId);
            SqlParameter newAssetIdParameter = new SqlParameter("AssetID", newAssetId);
            SqlParameter newWorkTypeParameter = new SqlParameter("WorkType", newWorkType);
            SqlParameter newLibraryCategoriesIdParameter = (newLibraryCategoriesId.HasValue) ? new SqlParameter("LIBRARY_CATEGORIES_ID", (int)newLibraryCategoriesId) : new SqlParameter("LIBRARY_CATEGORIES_ID", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newCommentsParameter = (newComments.Trim() != "") ? new SqlParameter("Comments", newComments.Trim()) : new SqlParameter("Comments", DBNull.Value);
            SqlParameter newHistoryParameter = (newHistory.Trim() != "") ? new SqlParameter("History", newHistory.Trim()) : new SqlParameter("History", DBNull.Value);

            string command = "UPDATE [dbo].[LFS_WORK] SET  "+
                " [LIBRARY_CATEGORIES_ID] = @LIBRARY_CATEGORIES_ID, "+
                " [Comments] = @Comments, "+
                " [History] = @History "+
                " WHERE (([WorkID] = @Original_WorkID) AND ([ProjectID] = @Original_ProjectID) AND "+
                " ([AssetID] = @Original_AssetID) AND ([WorkType] = @Original_WorkType) AND "+
                " ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalProjectIdParameter, originalAssetIdParameter, originalWorkTypeParameter, originalLibraryCategoriesIdParameter, originalDeletedParameter, originalCompanyIdParameter, originalCommentsParameter, originalHistoryParameter, newWorkIdParameter, newProjectIdParameter, newAssetIdParameter, newWorkTypeParameter, newLibraryCategoriesIdParameter, newDeletedParameter, newCompanyIdParameter, newCommentsParameter, newHistoryParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete a work (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        public void Delete(int originalWorkId, int originalCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("@Original_WorkID", originalWorkId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK] SET  [Deleted] = @Deleted  "+
                             " WHERE (([WorkID] = @Original_WorkID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery( command, originalWorkIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



    }
}