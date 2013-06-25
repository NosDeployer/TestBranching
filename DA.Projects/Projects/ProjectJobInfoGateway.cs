using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectJobInfoGateway
    /// </summary>
    public class ProjectJobInfoGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectJobInfoGateway()
            : base("LFS_PROJECT_JOB_INFO")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectJobInfoGateway(DataSet data)
            : base(data, "LFS_PROJECT_JOB_INFO")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTDS();
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
            tableMapping.DataSetTable = "LFS_PROJECT_JOB_INFO";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("TypeOfWorkMhRehab", "TypeOfWorkMhRehab");
            tableMapping.ColumnMappings.Add("TypeOfWorkJuntionLining", "TypeOfWorkJuntionLining");
            tableMapping.ColumnMappings.Add("TypeOfWorkProjectmanagement", "TypeOfWorkProjectmanagement");
            tableMapping.ColumnMappings.Add("TypeOfWorkFullLenghtLining", "TypeOfWorkFullLenghtLining");
            tableMapping.ColumnMappings.Add("TypeOfWorkPointRepairs", "TypeOfWorkPointRepairs");
            tableMapping.ColumnMappings.Add("TypeOfWorkRehabAssessment", "TypeOfWorkRehabAssessment");
            tableMapping.ColumnMappings.Add("TypeOfWorkGrout", "TypeOfWorkGrout");
            tableMapping.ColumnMappings.Add("TypeOfWorkOther", "TypeOfWorkOther");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Agreement", "Agreement");
            tableMapping.ColumnMappings.Add("WrittenQuote", "WrittenQuote");
            tableMapping.ColumnMappings.Add("Role", "Role");
            this._adapter.TableMappings.Add(tableMapping);
            
            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_PROJECT_JOB_INFO] WHERE (([ProjectID] = @Original_ProjectID) AND ([TypeOfWorkMhRehab] = @Original_TypeOfWorkMhRehab) AND ([TypeOfWorkJuntionLining] = @Original_TypeOfWorkJuntionLining) AND ([TypeOfWorkProjectmanagement] = @Original_TypeOfWorkProjectmanagement) AND ([TypeOfWorkFullLenghtLining] = @Original_TypeOfWorkFullLenghtLining) AND ([TypeOfWorkPointRepairs] = @Original_TypeOfWorkPointRepairs) AND ([TypeOfWorkRehabAssessment] = @Original_TypeOfWorkRehabAssessment) AND ([TypeOfWorkGrout] = @Original_TypeOfWorkGrout) AND ([TypeOfWorkOther] = @Original_TypeOfWorkOther) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([Agreement] = @Original_Agreement) AND ([WrittenQuote] = @Original_WrittenQuote))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TypeOfWorkMhRehab", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkMhRehab", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TypeOfWorkJuntionLining", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkJuntionLining", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TypeOfWorkProjectmanagement", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkProjectmanagement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TypeOfWorkFullLenghtLining", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkFullLenghtLining", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TypeOfWorkPointRepairs", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkPointRepairs", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TypeOfWorkRehabAssessment", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkRehabAssessment", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TypeOfWorkGrout", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkGrout", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TypeOfWorkOther", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkOther", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Agreement", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Agreement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WrittenQuote", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WrittenQuote", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT_JOB_INFO] ([ProjectID], [TypeOfWorkMhRehab], [TypeOfWorkJuntionLining], [TypeOfWorkProjectmanagement], [TypeOfWorkFullLenghtLining], [TypeOfWorkPointRepairs], [TypeOfWorkRehabAssessment], [TypeOfWorkGrout], [TypeOfWorkOther], [COMPANY_ID], [Agreement], [WrittenQuote], [Role]) VALUES (@ProjectID, @TypeOfWorkMhRehab, @TypeOfWorkJuntionLining, @TypeOfWorkProjectmanagement, @TypeOfWorkFullLenghtLining, @TypeOfWorkPointRepairs, @TypeOfWorkRehabAssessment, @TypeOfWorkGrout, @TypeOfWorkOther, @COMPANY_ID, @Agreement, @WrittenQuote, @Role);
SELECT ProjectID, TypeOfWorkMhRehab, TypeOfWorkJuntionLining, TypeOfWorkProjectmanagement, TypeOfWorkFullLenghtLining, TypeOfWorkPointRepairs, TypeOfWorkRehabAssessment, TypeOfWorkGrout, TypeOfWorkOther, COMPANY_ID, Agreement, WrittenQuote, Role FROM LFS_PROJECT_JOB_INFO WHERE (ProjectID = @ProjectID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TypeOfWorkMhRehab", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkMhRehab", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TypeOfWorkJuntionLining", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkJuntionLining", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TypeOfWorkProjectmanagement", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkProjectmanagement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TypeOfWorkFullLenghtLining", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkFullLenghtLining", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TypeOfWorkPointRepairs", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkPointRepairs", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TypeOfWorkRehabAssessment", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkRehabAssessment", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TypeOfWorkGrout", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkGrout", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TypeOfWorkOther", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkOther", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Agreement", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Agreement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WrittenQuote", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WrittenQuote", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Role", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Role", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_PROJECT_JOB_INFO] SET [ProjectID] = @ProjectID, [TypeOfWorkMhRe" +
                "hab] = @TypeOfWorkMhRehab, [TypeOfWorkJuntionLining] = @TypeOfWorkJuntionLining," +
                " [TypeOfWorkProjectmanagement] = @TypeOfWorkProjectmanagement, [TypeOfWorkFullLe" +
                "nghtLining] = @TypeOfWorkFullLenghtLining, [TypeOfWorkPointRepairs] = @TypeOfWor" +
                "kPointRepairs, [TypeOfWorkRehabAssessment] = @TypeOfWorkRehabAssessment, [TypeOf" +
                "WorkGrout] = @TypeOfWorkGrout, [TypeOfWorkOther] = @TypeOfWorkOther, [COMPANY_ID" +
                "] = @COMPANY_ID, [Agreement] = @Agreement, [WrittenQuote] = @WrittenQuote, [Role" +
                "] = @Role WHERE (([ProjectID] = @Original_ProjectID) AND ([TypeOfWorkMhRehab] = " +
                "@Original_TypeOfWorkMhRehab) AND ([TypeOfWorkJuntionLining] = @Original_TypeOfWo" +
                "rkJuntionLining) AND ([TypeOfWorkProjectmanagement] = @Original_TypeOfWorkProjec" +
                "tmanagement) AND ([TypeOfWorkFullLenghtLining] = @Original_TypeOfWorkFullLenghtL" +
                "ining) AND ([TypeOfWorkPointRepairs] = @Original_TypeOfWorkPointRepairs) AND ([T" +
                "ypeOfWorkRehabAssessment] = @Original_TypeOfWorkRehabAssessment) AND ([TypeOfWor" +
                "kGrout] = @Original_TypeOfWorkGrout) AND ([TypeOfWorkOther] = @Original_TypeOfWo" +
                "rkOther) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([Agreement] = @Original_" +
                "Agreement) AND ([WrittenQuote] = @Original_WrittenQuote));\r\nSELECT ProjectID, Ty" +
                "peOfWorkMhRehab, TypeOfWorkJuntionLining, TypeOfWorkProjectmanagement, TypeOfWor" +
                "kFullLenghtLining, TypeOfWorkPointRepairs, TypeOfWorkRehabAssessment, TypeOfWork" +
                "Grout, TypeOfWorkOther, COMPANY_ID, Agreement, WrittenQuote, Role FROM LFS_PROJE" +
                "CT_JOB_INFO WHERE (ProjectID = @ProjectID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TypeOfWorkMhRehab", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkMhRehab", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TypeOfWorkJuntionLining", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkJuntionLining", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TypeOfWorkProjectmanagement", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkProjectmanagement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TypeOfWorkFullLenghtLining", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkFullLenghtLining", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TypeOfWorkPointRepairs", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkPointRepairs", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TypeOfWorkRehabAssessment", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkRehabAssessment", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TypeOfWorkGrout", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkGrout", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TypeOfWorkOther", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkOther", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Agreement", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Agreement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WrittenQuote", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WrittenQuote", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Role", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Role", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TypeOfWorkMhRehab", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkMhRehab", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TypeOfWorkJuntionLining", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkJuntionLining", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TypeOfWorkProjectmanagement", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkProjectmanagement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TypeOfWorkFullLenghtLining", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkFullLenghtLining", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TypeOfWorkPointRepairs", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkPointRepairs", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TypeOfWorkRehabAssessment", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkRehabAssessment", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TypeOfWorkGrout", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkGrout", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TypeOfWorkOther", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TypeOfWorkOther", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Agreement", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Agreement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WrittenQuote", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WrittenQuote", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
                        
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
        /// <param name="projectId">ProjectId filter</param>
        /// <returns>Data</returns>
        public DataSet LoadAllByProjectId(int projectId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTJOBINFOGATEWAY_LOADALLBYPROJECTID", new SqlParameter("@projectId", projectId));
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a  Job info (direct to DB)
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="typeOfWorkMhRehab">typeOfWorkMhRehab</param>
        /// <param name="typeOfWorkJuntionLining">typeOfWorkJuntionLining</param>
        /// <param name="typeOfWorkProjectManagement">typeOfWorkProjectManagement</param>
        /// <param name="typeOfWorkFullLenghtLining">typeOfWorkFullLenghtLining</param>
        /// <param name="typeOfWorkPointRepairs">typeOfWorkPointRepairs</param>
        /// <param name="typeOfWorkRehabAssessment">typeOfWorkRehabAssessment</param>      
        /// <param name="typeOfWorkGrout">typeOfWorkGrout</param>
        /// <param name="typeOfWorkOther">typeOfWorkOther</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="agreement">agreement</param>
        /// <param name="writtenQuote">writtenQuote</param>
        /// <param name="role">role</param>
        /// <returns>rowsAffected</returns>
        public void Insert(int projectId, bool typeOfWorkMhRehab, bool typeOfWorkJuntionLining, bool typeOfWorkProjectManagement, bool typeOfWorkFullLenghtLining, bool typeOfWorkPointRepairs, bool typeOfWorkRehabAssessment, bool typeOfWorkGrout, bool typeOfWorkOther, int companyId, bool agreement, bool writtenQuote, string role)
        {
            SqlParameter projectIdParameter = new SqlParameter("ProjectID", projectId);
            SqlParameter typeOfWorkMhRehabParameter = new SqlParameter("TypeOfWorkMhRehab", typeOfWorkMhRehab);
            SqlParameter typeOfWorkJuntionLiningParameter = new SqlParameter("TypeOfWorkJuntionLining", typeOfWorkJuntionLining);
            SqlParameter typeOfWorkProjectManagementParameter = new SqlParameter("TypeOfWorkProjectManagement", typeOfWorkProjectManagement);
            SqlParameter typeOfWorkFullLenghtLiningParameter = new SqlParameter("TypeOfWorkFullLenghtLining", typeOfWorkFullLenghtLining);
            SqlParameter typeOfWorkPointRepairsParameter = new SqlParameter("TypeOfWorkPointRepairs", typeOfWorkPointRepairs);
            SqlParameter typeOfWorkRehabAssessmentParameter = new SqlParameter("TypeOfWorkRehabAssessment", typeOfWorkRehabAssessment);
            SqlParameter typeOfWorkGroutParameter = new SqlParameter("TypeOfWorkGrout", typeOfWorkGrout);
            SqlParameter typeOfWorkOtherParameter = new SqlParameter("TypeOfWorkOther", typeOfWorkOther);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter agreementParameter = new SqlParameter("Agreement", agreement);
            SqlParameter writtenQuoteParameter = new SqlParameter("WrittenQuote", writtenQuote);
            SqlParameter roleParameter = (role.Trim() != "") ? new SqlParameter("Role", role.Trim()) : new SqlParameter("Role", DBNull.Value);

            string command = "INSERT INTO [dbo].[LFS_PROJECT_JOB_INFO] ([ProjectID], [TypeOfWorkMhRehab], [TypeOfWorkJuntionLining], [TypeOfWorkProjectmanagement], [TypeOfWorkFullLenghtLining], [TypeOfWorkPointRepairs], [TypeOfWorkRehabAssessment], [TypeOfWorkGrout], [TypeOfWorkOther], [COMPANY_ID], [Agreement], [WrittenQuote], [Role]) VALUES (@ProjectID, @TypeOfWorkMhRehab, @TypeOfWorkJuntionLining, @TypeOfWorkProjectmanagement, @TypeOfWorkFullLenghtLining, @TypeOfWorkPointRepairs, @TypeOfWorkRehabAssessment, @TypeOfWorkGrout, @TypeOfWorkOther, @COMPANY_ID, @Agreement, @WrittenQuote, @Role)";

            int rowsAffected = (int)ExecuteNonQuery(command, projectIdParameter, typeOfWorkMhRehabParameter, typeOfWorkJuntionLiningParameter, typeOfWorkProjectManagementParameter, typeOfWorkFullLenghtLiningParameter, typeOfWorkPointRepairsParameter, typeOfWorkRehabAssessmentParameter, typeOfWorkGroutParameter, typeOfWorkOtherParameter, companyIdParameter, agreementParameter, writtenQuoteParameter, roleParameter);
            
        }



        /// <summary>
        /// Update  job info (direct to DB)
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalTypeOfWorkMhRehab">originalTypeOfWorkMhRehab</param>
        /// <param name="originalTypeOfWorkJuntionLining">originalTypeOfWorkJuntionLining</param>
        /// <param name="originalTypeOfWorkProjectManagement">originalTypeOfWorkProjectManagement</param>
        /// <param name="originalTypeOfWorkFullLenghtLining">originalTypeOfWorkFullLenghtLining</param>
        /// <param name="originalTypeOfWorkPointRepairs">originalTypeOfWorkPointRepairs</param>
        /// <param name="originaltypeOfWorkRehabAssessment">originaltypeOfWorkRehabAssessment</param>
        /// <param name="originalTypeOfWorkGrout">originalTypeOfWorkGrout</param>
        /// <param name="originalTypeOfWorkOther">originalTypeOfWorkOther</param>
        /// <param name="originalCompanyId">originalCompanyId</param>  
        /// <param name="originalAgreement">originalAgreement</param>
        /// <param name="originalWrittenQuote">originalWrittenQuote</param>
        /// <param name="originalRole">originalRole</param>
        /// 
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newTypeOfWorkMhRehab">newTypeOfWorkMhRehab</param>
        /// <param name="newTypeOfWorkJuntionLining">newTypeOfWorkJuntionLining</param>
        /// <param name="newTypeOfWorkProjectManagement">newTypeOfWorkProjectManagement</param>
        /// <param name="newTypeOfWorkFullLenghtLining">newTypeOfWorkFullLenghtLining</param>
        /// <param name="newTypeOfWorkPointRepairs">newTypeOfWorkPointRepairs</param>
        /// <param name="newtypeOfWorkRehabAssessment">newtypeOfWorkRehabAssessment</param>
        /// <param name="newTypeOfWorkGrout">newTypeOfWorkGrout</param>
        /// <param name="newTypeOfWorkOther">newTypeOfWorkOther</param>
        /// <param name="newCompanyId">newCompanyId</param>        
        /// <param name="newAgreement">newAgreement</param>
        /// <param name="newWrittenQuote">newWrittenQuote</param>
        /// <param name="newRole">newRole</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalProjectId, bool originalTypeOfWorkMhRehab, bool originalTypeOfWorkJuntionLining, bool originalTypeOfWorkProjectManagement, bool originalTypeOfWorkFullLenghtLining, bool originalTypeOfWorkPointRepairs, bool originaltypeOfWorkRehabAssessment, bool originalTypeOfWorkGrout, bool originalTypeOfWorkOther, int originalCompanyId, bool originalAgreement, bool originalWrittenQuote, string originalRole, int newProjectId, bool newTypeOfWorkMhRehab, bool newTypeOfWorkJuntionLining, bool newTypeOfWorkProjectManagement, bool newTypeOfWorkFullLenghtLining, bool newTypeOfWorkPointRepairs, bool newtypeOfWorkRehabAssessment, bool newTypeOfWorkGrout, bool newTypeOfWorkOther, int newCompanyId, bool newAgreement, bool newWrittenQuote, string newRole)
        {
            SqlParameter originalProjectIdParameter = new SqlParameter("Original_ProjectID", originalProjectId);
            SqlParameter originalTypeOfWorkMhRehabParameter = new SqlParameter("Original_TypeOfWorkMhRehab", originalTypeOfWorkMhRehab);
            SqlParameter originalTypeOfWorkJuntionLiningParameter =  new SqlParameter("Original_TypeOfWorkJuntionLining", originalTypeOfWorkJuntionLining);
            SqlParameter originalTypeOfWorkProjectManagementParameter = new SqlParameter("Original_TypeOfWorkProjectManagement", originalTypeOfWorkProjectManagement);
            SqlParameter originalTypeOfWorkFullLenghtLiningParameter = new SqlParameter("Original_TypeOfWorkFullLenghtLining", originalTypeOfWorkFullLenghtLining);
            SqlParameter originalTypeOfWorkPointRepairsParameter =  new SqlParameter("Original_TypeOfWorkPointRepairs", originalTypeOfWorkPointRepairs);            
            SqlParameter originaltypeOfWorkRehabAssessmentParameter = new SqlParameter("Original_typeOfWorkRehabAssessment", originaltypeOfWorkRehabAssessment);
            SqlParameter originalTypeOfWorkGroutParameter = new SqlParameter("Original_TypeOfWorkGrout", originalTypeOfWorkGrout);
            SqlParameter originalTypeOfWorkOtherParameter = new SqlParameter("Original_TypeOfWorkOther", originalTypeOfWorkOther);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalAgreementParameter = new SqlParameter("Original_Agreement", originalAgreement);
            SqlParameter originalWrittenQuoteParameter = new SqlParameter("Original_WrittenQuote", originalWrittenQuote);
            SqlParameter originalRoleParameter = (originalRole.Trim() != "") ? new SqlParameter("Original_Role", originalRole.Trim()) : new SqlParameter("Original_Role", DBNull.Value);

            SqlParameter newProjectIdParameter = new SqlParameter("ProjectID", newProjectId);
            SqlParameter newTypeOfWorkMhRehabParameter = new SqlParameter("TypeOfWorkMhRehab", newTypeOfWorkMhRehab);
            SqlParameter newTypeOfWorkJuntionLiningParameter =  new SqlParameter("TypeOfWorkJuntionLining", newTypeOfWorkJuntionLining);
            SqlParameter newTypeOfWorkProjectManagementParameter = new SqlParameter("TypeOfWorkProjectManagement", newTypeOfWorkProjectManagement);
            SqlParameter newTypeOfWorkFullLenghtLiningParameter =  new SqlParameter("TypeOfWorkFullLenghtLining", newTypeOfWorkFullLenghtLining);
            SqlParameter newTypeOfWorkPointRepairsParameter =  new SqlParameter("TypeOfWorkPointRepairs", newTypeOfWorkPointRepairs);            
            SqlParameter newtypeOfWorkRehabAssessmentParameter = new SqlParameter("typeOfWorkRehabAssessment", newtypeOfWorkRehabAssessment);
            SqlParameter newTypeOfWorkGroutParameter = new SqlParameter("TypeOfWorkGrout", newTypeOfWorkGrout);
            SqlParameter newTypeOfWorkOtherParameter = new SqlParameter("TypeOfWorkOther", newTypeOfWorkOther);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newAgreementParameter = new SqlParameter("Agreement", newAgreement);
            SqlParameter newWrittenQuoteParameter = new SqlParameter("WrittenQuote", newWrittenQuote);
            SqlParameter newRoleParameter = (newRole.Trim() != "") ? new SqlParameter("Role", newRole.Trim()) : new SqlParameter("Role", DBNull.Value);

            string command = "UPDATE [dbo].[LFS_PROJECT_JOB_INFO] SET [ProjectID] = @ProjectID, [TypeOfWorkMhRe" +
                "hab] = @TypeOfWorkMhRehab, [TypeOfWorkJuntionLining] = @TypeOfWorkJuntionLining," +
                " [TypeOfWorkProjectmanagement] = @TypeOfWorkProjectmanagement, [TypeOfWorkFullLe" +
                "nghtLining] = @TypeOfWorkFullLenghtLining, [TypeOfWorkPointRepairs] = @TypeOfWor" +
                "kPointRepairs, [TypeOfWorkRehabAssessment] = @TypeOfWorkRehabAssessment, [TypeOf" +
                "WorkGrout] = @TypeOfWorkGrout, [TypeOfWorkOther] = @TypeOfWorkOther, [COMPANY_ID" +
                "] = @COMPANY_ID, [Agreement] = @Agreement, [WrittenQuote] = @WrittenQuote, [Role" +
                "] = @Role WHERE ([ProjectID] = @Original_ProjectID)";

            int rowsAffected = (int)ExecuteNonQuery(command, originalProjectIdParameter, originalTypeOfWorkMhRehabParameter, originalTypeOfWorkJuntionLiningParameter, originalTypeOfWorkProjectManagementParameter, originalTypeOfWorkFullLenghtLiningParameter, originalTypeOfWorkPointRepairsParameter, originaltypeOfWorkRehabAssessmentParameter, originalTypeOfWorkGroutParameter, originalTypeOfWorkOtherParameter, originalCompanyIdParameter, originalAgreementParameter, originalWrittenQuoteParameter, originalRoleParameter, newProjectIdParameter, newTypeOfWorkMhRehabParameter, newTypeOfWorkJuntionLiningParameter, newTypeOfWorkProjectManagementParameter, newTypeOfWorkFullLenghtLiningParameter, newTypeOfWorkPointRepairsParameter, newtypeOfWorkRehabAssessmentParameter, newTypeOfWorkGroutParameter, newTypeOfWorkOtherParameter, newCompanyIdParameter, newAgreementParameter, newWrittenQuoteParameter, newRoleParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }

    }
}
