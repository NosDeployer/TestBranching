using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.DA.RAF
{
    /// <summary>
    /// LibraryFilesGateway
    /// </summary>
    public class LibraryFilesGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LibraryFilesGateway()
            : base("LIBRARY_FILES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LibraryFilesGateway(DataSet data)
            : base(data, "LIBRARY_FILES")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new LibraryTDS();
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
            tableMapping.DataSetTable = "LIBRARY_FILES";
            tableMapping.ColumnMappings.Add("LIBRARY_FILES_ID", "LIBRARY_FILES_ID");
            tableMapping.ColumnMappings.Add("LIBRARY_CATEGORIES_ID", "LIBRARY_CATEGORIES_ID");
            tableMapping.ColumnMappings.Add("DESCRIPTION", "DESCRIPTION");
            tableMapping.ColumnMappings.Add("ACTIVE", "ACTIVE");
            tableMapping.ColumnMappings.Add("FILENAME", "FILENAME");
            tableMapping.ColumnMappings.Add("ORIGINAL_FILENAME", "ORIGINAL_FILENAME");
            tableMapping.ColumnMappings.Add("DATE_TIME", "DATE_TIME");
            tableMapping.ColumnMappings.Add("LOGIN_ID", "LOGIN_ID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("FILE_SIZE", "FILE_SIZE");
            tableMapping.ColumnMappings.Add("THUMBNAIL_FILENAME", "THUMBNAIL_FILENAME");
            tableMapping.ColumnMappings.Add("NO_RECENTLY_UPLOADED", "NO_RECENTLY_UPLOADED");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LIBRARY_FILES] WHERE (([LIBRARY_FILES_ID] = @Original_LIBRARY_FILES_ID) AND ((@IsNull_LIBRARY_CATEGORIES_ID = 1 AND [LIBRARY_CATEGORIES_ID] IS NULL) OR ([LIBRARY_CATEGORIES_ID] = @Original_LIBRARY_CATEGORIES_ID)) AND ((@IsNull_DESCRIPTION = 1 AND [DESCRIPTION] IS NULL) OR ([DESCRIPTION] = @Original_DESCRIPTION)) AND ((@IsNull_ACTIVE = 1 AND [ACTIVE] IS NULL) OR ([ACTIVE] = @Original_ACTIVE)) AND ((@IsNull_FILENAME = 1 AND [FILENAME] IS NULL) OR ([FILENAME] = @Original_FILENAME)) AND ((@p3 = 1 AND [ORIGINAL_FILENAME] IS NULL) OR ([ORIGINAL_FILENAME] = @p2)) AND ((@IsNull_DATE_TIME = 1 AND [DATE_TIME] IS NULL) OR ([DATE_TIME] = @Original_DATE_TIME)) AND ((@IsNull_LOGIN_ID = 1 AND [LOGIN_ID] IS NULL) OR ([LOGIN_ID] = @Original_LOGIN_ID)) AND ((@IsNull_COMPANY_ID = 1 AND [COMPANY_ID] IS NULL) OR ([COMPANY_ID] = @Original_COMPANY_ID)) AND ((@IsNull_FILE_SIZE = 1 AND [FILE_SIZE] IS NULL) OR ([FILE_SIZE] = @Original_FILE_SIZE)) AND ((@IsNull_THUMBNAIL_FILENAME = 1 AND [THUMBNAIL_FILENAME] IS NULL) OR ([THUMBNAIL_FILENAME] = @Original_THUMBNAIL_FILENAME)) AND ((@IsNull_NO_RECENTLY_UPLOADED = 1 AND [NO_RECENTLY_UPLOADED] IS NULL) OR ([NO_RECENTLY_UPLOADED] = @Original_NO_RECENTLY_UPLOADED)))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LIBRARY_FILES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LIBRARY_CATEGORIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LIBRARY_CATEGORIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DESCRIPTION", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DESCRIPTION", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DESCRIPTION", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DESCRIPTION", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ACTIVE", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ACTIVE", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ACTIVE", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ACTIVE", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FILENAME", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FILENAME", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FILENAME", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "FILENAME", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@p3", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ORIGINAL_FILENAME", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@p2", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ORIGINAL_FILENAME", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DATE_TIME", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DATE_TIME", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DATE_TIME", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DATE_TIME", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LOGIN_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LOGIN_ID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LOGIN_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LOGIN_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FILE_SIZE", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FILE_SIZE", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FILE_SIZE", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "FILE_SIZE", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_THUMBNAIL_FILENAME", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "THUMBNAIL_FILENAME", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_THUMBNAIL_FILENAME", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "THUMBNAIL_FILENAME", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_NO_RECENTLY_UPLOADED", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NO_RECENTLY_UPLOADED", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NO_RECENTLY_UPLOADED", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "NO_RECENTLY_UPLOADED", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LIBRARY_FILES] ([LIBRARY_CATEGORIES_ID], [DESCRIPTION], [ACTIVE], [FILENAME], [ORIGINAL_FILENAME], [DATE_TIME], [LOGIN_ID], [COMPANY_ID], [FILE_SIZE], [THUMBNAIL_FILENAME], [NO_RECENTLY_UPLOADED]) VALUES (@LIBRARY_CATEGORIES_ID, @DESCRIPTION, @ACTIVE, @FILENAME, @p1, @DATE_TIME, @LOGIN_ID, @COMPANY_ID, @FILE_SIZE, @THUMBNAIL_FILENAME, @NO_RECENTLY_UPLOADED);
SELECT LIBRARY_FILES_ID, LIBRARY_CATEGORIES_ID, DESCRIPTION, ACTIVE, FILENAME, ORIGINAL_FILENAME, DATE_TIME, LOGIN_ID, COMPANY_ID, FILE_SIZE, THUMBNAIL_FILENAME, NO_RECENTLY_UPLOADED FROM LIBRARY_FILES WHERE (LIBRARY_FILES_ID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LIBRARY_CATEGORIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DESCRIPTION", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DESCRIPTION", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ACTIVE", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ACTIVE", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FILENAME", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "FILENAME", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@p1", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ORIGINAL_FILENAME", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATE_TIME", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DATE_TIME", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LOGIN_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LOGIN_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FILE_SIZE", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "FILE_SIZE", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@THUMBNAIL_FILENAME", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "THUMBNAIL_FILENAME", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NO_RECENTLY_UPLOADED", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "NO_RECENTLY_UPLOADED", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LIBRARY_FILES] SET [LIBRARY_CATEGORIES_ID] = @LIBRARY_CATEGORIES_ID" +
                ", [DESCRIPTION] = @DESCRIPTION, [ACTIVE] = @ACTIVE, [FILENAME] = @FILENAME, [ORI" +
                "GINAL_FILENAME] = @p1, [DATE_TIME] = @DATE_TIME, [LOGIN_ID] = @LOGIN_ID, [COMPAN" +
                "Y_ID] = @COMPANY_ID, [FILE_SIZE] = @FILE_SIZE, [THUMBNAIL_FILENAME] = @THUMBNAIL" +
                "_FILENAME, [NO_RECENTLY_UPLOADED] = @NO_RECENTLY_UPLOADED WHERE (([LIBRARY_FILES" +
                "_ID] = @Original_LIBRARY_FILES_ID) AND ((@IsNull_LIBRARY_CATEGORIES_ID = 1 AND [" +
                "LIBRARY_CATEGORIES_ID] IS NULL) OR ([LIBRARY_CATEGORIES_ID] = @Original_LIBRARY_" +
                "CATEGORIES_ID)) AND ((@IsNull_DESCRIPTION = 1 AND [DESCRIPTION] IS NULL) OR ([DE" +
                "SCRIPTION] = @Original_DESCRIPTION)) AND ((@IsNull_ACTIVE = 1 AND [ACTIVE] IS NU" +
                "LL) OR ([ACTIVE] = @Original_ACTIVE)) AND ((@IsNull_FILENAME = 1 AND [FILENAME] " +
                "IS NULL) OR ([FILENAME] = @Original_FILENAME)) AND ((@p3 = 1 AND [ORIGINAL_FILEN" +
                "AME] IS NULL) OR ([ORIGINAL_FILENAME] = @p2)) AND ((@IsNull_DATE_TIME = 1 AND [D" +
                "ATE_TIME] IS NULL) OR ([DATE_TIME] = @Original_DATE_TIME)) AND ((@IsNull_LOGIN_I" +
                "D = 1 AND [LOGIN_ID] IS NULL) OR ([LOGIN_ID] = @Original_LOGIN_ID)) AND ((@IsNul" +
                "l_COMPANY_ID = 1 AND [COMPANY_ID] IS NULL) OR ([COMPANY_ID] = @Original_COMPANY_" +
                "ID)) AND ((@IsNull_FILE_SIZE = 1 AND [FILE_SIZE] IS NULL) OR ([FILE_SIZE] = @Ori" +
                "ginal_FILE_SIZE)) AND ((@IsNull_THUMBNAIL_FILENAME = 1 AND [THUMBNAIL_FILENAME] " +
                "IS NULL) OR ([THUMBNAIL_FILENAME] = @Original_THUMBNAIL_FILENAME)) AND ((@IsNull" +
                "_NO_RECENTLY_UPLOADED = 1 AND [NO_RECENTLY_UPLOADED] IS NULL) OR ([NO_RECENTLY_U" +
                "PLOADED] = @Original_NO_RECENTLY_UPLOADED)));\r\nSELECT LIBRARY_FILES_ID, LIBRARY_" +
                "CATEGORIES_ID, DESCRIPTION, ACTIVE, FILENAME, ORIGINAL_FILENAME, DATE_TIME, LOGI" +
                "N_ID, COMPANY_ID, FILE_SIZE, THUMBNAIL_FILENAME, NO_RECENTLY_UPLOADED FROM LIBRA" +
                "RY_FILES WHERE (LIBRARY_FILES_ID = @LIBRARY_FILES_ID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LIBRARY_CATEGORIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DESCRIPTION", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DESCRIPTION", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ACTIVE", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ACTIVE", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FILENAME", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "FILENAME", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@p1", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ORIGINAL_FILENAME", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DATE_TIME", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DATE_TIME", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LOGIN_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LOGIN_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FILE_SIZE", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "FILE_SIZE", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@THUMBNAIL_FILENAME", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "THUMBNAIL_FILENAME", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NO_RECENTLY_UPLOADED", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "NO_RECENTLY_UPLOADED", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LIBRARY_FILES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LIBRARY_CATEGORIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LIBRARY_CATEGORIES_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DESCRIPTION", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DESCRIPTION", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DESCRIPTION", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DESCRIPTION", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ACTIVE", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ACTIVE", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ACTIVE", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ACTIVE", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FILENAME", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FILENAME", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FILENAME", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "FILENAME", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@p3", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ORIGINAL_FILENAME", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@p2", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "ORIGINAL_FILENAME", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_DATE_TIME", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "DATE_TIME", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DATE_TIME", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "DATE_TIME", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LOGIN_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LOGIN_ID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LOGIN_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LOGIN_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_FILE_SIZE", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FILE_SIZE", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FILE_SIZE", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "FILE_SIZE", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_THUMBNAIL_FILENAME", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "THUMBNAIL_FILENAME", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_THUMBNAIL_FILENAME", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "THUMBNAIL_FILENAME", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_NO_RECENTLY_UPLOADED", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NO_RECENTLY_UPLOADED", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NO_RECENTLY_UPLOADED", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "NO_RECENTLY_UPLOADED", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LIBRARY_FILES_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_FILES_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByLibraryFilesId
        /// </summary>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <returns>Data</returns>
        public DataSet LoadByLibraryFilesId(int libraryFilesId)
        {
            FillDataWithStoredProcedure("LIBRARY_FILES_RETURN_FOR_LIBRARY_FILES_ID", new SqlParameter("@library_files_id", libraryFilesId));  
            return Data;
        }


        /// <summary>
        /// LoadByFileName
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadByFileName(string fileName, int companyId)
        {
            FillDataWithStoredProcedure("LIBRARY_FILES_RETURN_FOR_FILENAME", new SqlParameter("@filename", fileName), new SqlParameter("@company_id", companyId)); 
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int libraryFilesId)
        {
            string filter = string.Format("LIBRARY_FILES_ID = {0}", libraryFilesId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.RAF.LibraryFilesGateway.GetRow");
            }
        }



        /// <summary>
        /// GetRow2
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow2(string fileName)
        {
            string filter = string.Format("FILENAME = '{0}'", fileName);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.RAF.LibraryFilesGateway.GetRow");
            }
        }



        /// <summary>
        /// GetOriginalFileName
        /// </summary>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <returns>OriginalFileName</returns>
        public string GetOriginalFileName(int libraryFilesId)
        {
            return (string)GetRow(libraryFilesId)["ORIGINAL_FILENAME"];
        }



        /// <summary>
        /// GetlibraryFilesId
        /// </summary>
        /// <param name="libraryFilesId">fileName</param>
        /// <returns>LIBRARY_FILES_ID</returns>
        public int GetlibraryFilesId(string fileName)
        {
            return (int)GetRow2(fileName)["LIBRARY_FILES_ID"];
        }



        /// <summary>
        /// GetFileName
        /// </summary>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <returns>FileName</returns>
        public string GetFileName(int libraryFilesId)
        {
            return (string)GetRow(libraryFilesId)["FILENAME"];
        }



        /// <summary>
        /// GetActive
        /// </summary>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <returns>ACTIVE</returns>
        public bool GetActive(int libraryFilesId)
        {
            return (bool)GetRow(libraryFilesId)["ACTIVE"];
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// DeleteByLibraryFilesId
        /// </summary>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <returns></returns>
        public int DeleteByLibraryFilesId(int libraryFilesId)
        {
            return (int)ExecuteNonQueryWithStoredProcedure("LIBRARY_FILES_DELETE_FOR_LIBRARY_FILES_ID", new SqlParameter("@library_files_id", libraryFilesId));
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <param name="description">description</param>
        /// <param name="originalFileName">originalFileName</param>
        /// <param name="thumbnailFileName">thumbnailFileName</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <param name="loginId">loginId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fileSize">fileSize</param>
        /// <returns></returns>
        public int Insert(string fileName, string description, string originalFileName, string thumbnailFileName, int libraryCategoriesId, int loginId, int companyId, string fileSize)
        {
            return (int)ExecuteNonQueryWithStoredProcedure("LIBRARY_FILES_INSERT", new SqlParameter("@description", description), new SqlParameter("@filename", fileName), new SqlParameter("@thumbnail_filename", description), new SqlParameter("@original_filename", originalFileName), new SqlParameter("@library_categories_id", libraryCategoriesId), new SqlParameter("@login_id", loginId), new SqlParameter("@company_id", companyId), new SqlParameter("@file_size", fileSize)); //Note: COMPANY_ID
        }



        /// <summary>
        /// GetLastLibraryFilesId
        /// </summary>
        /// <returns>Last LibraryFilesID</returns>
        public int GetLastLibraryFilesId()
        {
            string commandText = "SELECT MAX(LIBRARY_FILES_ID) AS libraryFilesId FROM LIBRARY_FILES";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);

            return ((int)ExecuteScalar(command));
        }



        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            DataTable tableChanges = Table.GetChanges();

            if ((tableChanges != null) && (tableChanges.Rows.Count > 0))
            {
                try
                {
                    Adapter.Update(Data, this.TableName);
                }
                catch (DBConcurrencyException dBConcurrencyException)
                {
                    throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
                }
                catch (SqlException sqlException)
                {
                    byte severityLevel = sqlException.Class;
                    if (severityLevel <= 16)
                    {
                        throw new Exception("Low severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                    }
                    if ((severityLevel >= 17) && (severityLevel <= 19))
                    {
                        throw new Exception("Mid severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                    }
                    if (severityLevel >= 20)
                    {
                        throw new Exception("High severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Unknow error. Your operation has been cancelled.", e);
                }
            }
        }

        
        
    }
}
