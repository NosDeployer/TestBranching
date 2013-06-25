using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardAspnetMembershipGateway
    /// </summary>
    public class DashboardAspnetMembershipGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public DashboardAspnetMembershipGateway()
            : base("aspnet_Membership")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public DashboardAspnetMembershipGateway(DataSet data)
            : base(data, "aspnet_Membership")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new DashboardAspnetTDS();
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
            tableMapping.DataSetTable = "aspnet_Membership";
            tableMapping.ColumnMappings.Add("ApplicationId", "ApplicationId");
            tableMapping.ColumnMappings.Add("UserId", "UserId");
            tableMapping.ColumnMappings.Add("Password", "Password");
            tableMapping.ColumnMappings.Add("PasswordFormat", "PasswordFormat");
            tableMapping.ColumnMappings.Add("PasswordSalt", "PasswordSalt");
            tableMapping.ColumnMappings.Add("MobilePIN", "MobilePIN");
            tableMapping.ColumnMappings.Add("Email", "Email");
            tableMapping.ColumnMappings.Add("LoweredEmail", "LoweredEmail");
            tableMapping.ColumnMappings.Add("PasswordQuestion", "PasswordQuestion");
            tableMapping.ColumnMappings.Add("PasswordAnswer", "PasswordAnswer");
            tableMapping.ColumnMappings.Add("IsApproved", "IsApproved");
            tableMapping.ColumnMappings.Add("IsLockedOut", "IsLockedOut");
            tableMapping.ColumnMappings.Add("CreateDate", "CreateDate");
            tableMapping.ColumnMappings.Add("LastLoginDate", "LastLoginDate");
            tableMapping.ColumnMappings.Add("LastPasswordChangedDate", "LastPasswordChangedDate");
            tableMapping.ColumnMappings.Add("LastLockoutDate", "LastLockoutDate");
            tableMapping.ColumnMappings.Add("FailedPasswordAttemptCount", "FailedPasswordAttemptCount");
            tableMapping.ColumnMappings.Add("FailedPasswordAttemptWindowStart", "FailedPasswordAttemptWindowStart");
            tableMapping.ColumnMappings.Add("FailedPasswordAnswerAttemptCount", "FailedPasswordAnswerAttemptCount");
            tableMapping.ColumnMappings.Add("FailedPasswordAnswerAttemptWindowStart", "FailedPasswordAnswerAttemptWindowStart");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[aspnet_Membership] WHERE (([ApplicationId] = @Original_ApplicationId) AND ([UserId] = @Original_UserId) AND ([Password] = @Original_Password) AND ([PasswordFormat] = @Original_PasswordFormat) AND ([PasswordSalt] = @Original_PasswordSalt) AND ((@IsNull_MobilePIN = 1 AND [MobilePIN] IS NULL) OR ([MobilePIN] = @Original_MobilePIN)) AND ((@IsNull_Email = 1 AND [Email] IS NULL) OR ([Email] = @Original_Email)) AND ((@IsNull_LoweredEmail = 1 AND [LoweredEmail] IS NULL) OR ([LoweredEmail] = @Original_LoweredEmail)) AND ((@IsNull_PasswordQuestion = 1 AND [PasswordQuestion] IS NULL) OR ([PasswordQuestion] = @Original_PasswordQuestion)) AND ((@IsNull_PasswordAnswer = 1 AND [PasswordAnswer] IS NULL) OR ([PasswordAnswer] = @Original_PasswordAnswer)) AND ([IsApproved] = @Original_IsApproved) AND ([IsLockedOut] = @Original_IsLockedOut) AND ([CreateDate] = @Original_CreateDate) AND ([LastLoginDate] = @Original_LastLoginDate) AND ([LastPasswordChangedDate] = @Original_LastPasswordChangedDate) AND ([LastLockoutDate] = @Original_LastLockoutDate) AND ([FailedPasswordAttemptCount] = @Original_FailedPasswordAttemptCount) AND ([FailedPasswordAttemptWindowStart] = @Original_FailedPasswordAttemptWindowStart) AND ([FailedPasswordAnswerAttemptCount] = @Original_FailedPasswordAnswerAttemptCount) AND ([FailedPasswordAnswerAttemptWindowStart] = @Original_FailedPasswordAnswerAttemptWindowStart))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ApplicationId", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ApplicationId", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserId", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "UserId", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Password", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Password", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PasswordFormat", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordFormat", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PasswordSalt", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordSalt", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MobilePIN", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MobilePIN", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MobilePIN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MobilePIN", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Email", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Email", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Email", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Email", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LoweredEmail", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoweredEmail", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LoweredEmail", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LoweredEmail", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PasswordQuestion", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordQuestion", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PasswordQuestion", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordQuestion", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PasswordAnswer", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordAnswer", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PasswordAnswer", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordAnswer", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IsApproved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IsApproved", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IsLockedOut", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IsLockedOut", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CreateDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "CreateDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LastLoginDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LastLoginDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LastPasswordChangedDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LastPasswordChangedDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LastLockoutDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LastLockoutDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FailedPasswordAttemptCount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FailedPasswordAttemptCount", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FailedPasswordAttemptWindowStart", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FailedPasswordAttemptWindowStart", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FailedPasswordAnswerAttemptCount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FailedPasswordAnswerAttemptCount", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FailedPasswordAnswerAttemptWindowStart", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FailedPasswordAnswerAttemptWindowStart", System.Data.DataRowVersion.Original, false, null, "", "", ""));
           
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[aspnet_Membership] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [MobilePIN], [Email], [LoweredEmail], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [Comment]) VALUES (@ApplicationId, @UserId, @Password, @PasswordFormat, @PasswordSalt, @MobilePIN, @Email, @LoweredEmail, @PasswordQuestion, @PasswordAnswer, @IsApproved, @IsLockedOut, @CreateDate, @LastLoginDate, @LastPasswordChangedDate, @LastLockoutDate, @FailedPasswordAttemptCount, @FailedPasswordAttemptWindowStart, @FailedPasswordAnswerAttemptCount, @FailedPasswordAnswerAttemptWindowStart, @Comment);
SELECT ApplicationId, UserId, Password, PasswordFormat, PasswordSalt, MobilePIN, Email, LoweredEmail, PasswordQuestion, PasswordAnswer, IsApproved, IsLockedOut, CreateDate, LastLoginDate, LastPasswordChangedDate, LastLockoutDate, FailedPasswordAttemptCount, FailedPasswordAttemptWindowStart, FailedPasswordAnswerAttemptCount, FailedPasswordAnswerAttemptWindowStart, Comment FROM aspnet_Membership WHERE (UserId = @UserId)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ApplicationId", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ApplicationId", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserId", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "UserId", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Password", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PasswordFormat", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordFormat", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PasswordSalt", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordSalt", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MobilePIN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MobilePIN", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Email", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LoweredEmail", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LoweredEmail", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PasswordQuestion", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordQuestion", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PasswordAnswer", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordAnswer", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsApproved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IsApproved", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsLockedOut", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IsLockedOut", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreateDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "CreateDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastLoginDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LastLoginDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastPasswordChangedDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LastPasswordChangedDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastLockoutDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LastLockoutDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FailedPasswordAttemptCount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FailedPasswordAttemptCount", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FailedPasswordAttemptWindowStart", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FailedPasswordAttemptWindowStart", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FailedPasswordAnswerAttemptCount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FailedPasswordAnswerAttemptCount", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FailedPasswordAnswerAttemptWindowStart", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FailedPasswordAnswerAttemptWindowStart", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comment", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "Comment", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[aspnet_Membership] SET [ApplicationId] = @ApplicationId, [UserId] =" +
                " @UserId, [Password] = @Password, [PasswordFormat] = @PasswordFormat, [PasswordS" +
                "alt] = @PasswordSalt, [MobilePIN] = @MobilePIN, [Email] = @Email, [LoweredEmail]" +
                " = @LoweredEmail, [PasswordQuestion] = @PasswordQuestion, [PasswordAnswer] = @Pa" +
                "sswordAnswer, [IsApproved] = @IsApproved, [IsLockedOut] = @IsLockedOut, [CreateD" +
                "ate] = @CreateDate, [LastLoginDate] = @LastLoginDate, [LastPasswordChangedDate] " +
                "= @LastPasswordChangedDate, [LastLockoutDate] = @LastLockoutDate, [FailedPasswor" +
                "dAttemptCount] = @FailedPasswordAttemptCount, [FailedPasswordAttemptWindowStart]" +
                " = @FailedPasswordAttemptWindowStart, [FailedPasswordAnswerAttemptCount] = @Fail" +
                "edPasswordAnswerAttemptCount, [FailedPasswordAnswerAttemptWindowStart] = @Failed" +
                "PasswordAnswerAttemptWindowStart, [Comment] = @Comment WHERE (([ApplicationId] =" +
                " @Original_ApplicationId) AND ([UserId] = @Original_UserId) AND ([Password] = @O" +
                "riginal_Password) AND ([PasswordFormat] = @Original_PasswordFormat) AND ([Passwo" +
                "rdSalt] = @Original_PasswordSalt) AND ((@IsNull_MobilePIN = 1 AND [MobilePIN] IS" +
                " NULL) OR ([MobilePIN] = @Original_MobilePIN)) AND ((@IsNull_Email = 1 AND [Emai" +
                "l] IS NULL) OR ([Email] = @Original_Email)) AND ((@IsNull_LoweredEmail = 1 AND [" +
                "LoweredEmail] IS NULL) OR ([LoweredEmail] = @Original_LoweredEmail)) AND ((@IsNu" +
                "ll_PasswordQuestion = 1 AND [PasswordQuestion] IS NULL) OR ([PasswordQuestion] =" +
                " @Original_PasswordQuestion)) AND ((@IsNull_PasswordAnswer = 1 AND [PasswordAnsw" +
                "er] IS NULL) OR ([PasswordAnswer] = @Original_PasswordAnswer)) AND ([IsApproved]" +
                " = @Original_IsApproved) AND ([IsLockedOut] = @Original_IsLockedOut) AND ([Creat" +
                "eDate] = @Original_CreateDate) AND ([LastLoginDate] = @Original_LastLoginDate) A" +
                "ND ([LastPasswordChangedDate] = @Original_LastPasswordChangedDate) AND ([LastLoc" +
                "koutDate] = @Original_LastLockoutDate) AND ([FailedPasswordAttemptCount] = @Orig" +
                "inal_FailedPasswordAttemptCount) AND ([FailedPasswordAttemptWindowStart] = @Orig" +
                "inal_FailedPasswordAttemptWindowStart) AND ([FailedPasswordAnswerAttemptCount] =" +
                " @Original_FailedPasswordAnswerAttemptCount) AND ([FailedPasswordAnswerAttemptWi" +
                "ndowStart] = @Original_FailedPasswordAnswerAttemptWindowStart));\r\nSELECT Applica" +
                "tionId, UserId, Password, PasswordFormat, PasswordSalt, MobilePIN, Email, Lowere" +
                "dEmail, PasswordQuestion, PasswordAnswer, IsApproved, IsLockedOut, CreateDate, L" +
                "astLoginDate, LastPasswordChangedDate, LastLockoutDate, FailedPasswordAttemptCou" +
                "nt, FailedPasswordAttemptWindowStart, FailedPasswordAnswerAttemptCount, FailedPa" +
                "sswordAnswerAttemptWindowStart, Comment FROM aspnet_Membership WHERE (UserId = @" +
                "UserId)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ApplicationId", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ApplicationId", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserId", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "UserId", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Password", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PasswordFormat", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordFormat", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PasswordSalt", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordSalt", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MobilePIN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MobilePIN", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Email", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LoweredEmail", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LoweredEmail", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PasswordQuestion", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordQuestion", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PasswordAnswer", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordAnswer", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsApproved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IsApproved", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsLockedOut", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IsLockedOut", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreateDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "CreateDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastLoginDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LastLoginDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastPasswordChangedDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LastPasswordChangedDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastLockoutDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LastLockoutDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FailedPasswordAttemptCount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FailedPasswordAttemptCount", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FailedPasswordAttemptWindowStart", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FailedPasswordAttemptWindowStart", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FailedPasswordAnswerAttemptCount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FailedPasswordAnswerAttemptCount", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FailedPasswordAnswerAttemptWindowStart", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FailedPasswordAnswerAttemptWindowStart", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comment", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "Comment", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ApplicationId", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ApplicationId", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserId", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "UserId", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Password", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Password", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PasswordFormat", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordFormat", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PasswordSalt", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordSalt", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MobilePIN", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MobilePIN", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MobilePIN", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MobilePIN", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Email", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Email", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Email", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Email", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LoweredEmail", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoweredEmail", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LoweredEmail", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LoweredEmail", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PasswordQuestion", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordQuestion", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PasswordQuestion", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordQuestion", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_PasswordAnswer", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordAnswer", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PasswordAnswer", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "PasswordAnswer", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IsApproved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IsApproved", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IsLockedOut", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "IsLockedOut", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CreateDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "CreateDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LastLoginDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LastLoginDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LastPasswordChangedDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LastPasswordChangedDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LastLockoutDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "LastLockoutDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FailedPasswordAttemptCount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FailedPasswordAttemptCount", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FailedPasswordAttemptWindowStart", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FailedPasswordAttemptWindowStart", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FailedPasswordAnswerAttemptCount", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "FailedPasswordAnswerAttemptCount", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FailedPasswordAnswerAttemptWindowStart", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "FailedPasswordAnswerAttemptWindowStart", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
        #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// CreateUser
        /// </summary>
        /// <param name="applicationName">applicationName</param>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        /// <param name="passwordSalt">passwordSalt</param>
        /// <param name="email">email</param>
        /// <param name="passwordQuestion">passwordQuestion</param>
        /// <param name="passwordAnswer">passwordAnswer</param>
        /// <param name="isApproved">isApproved</param>
        /// <param name="currentTimeUtc">currentTimeUtc</param>
        /// <param name="createDate">createDate</param>
        /// <param name="uniqueEmail">uniqueEmail</param>
        /// <param name="passwordFormat">passwordFormat</param>
        /// <param name="userId">userId</param>
        /// <returns>DataSet</returns>
        public DataSet CreateUser(string applicationName, string userName, string password, string passwordSalt, string email, string passwordQuestion, string passwordAnswer, bool isApproved, DateTime currentTimeUtc, DateTime? createDate, int uniqueEmail, int passwordFormat, Guid userId)
        {
            FillDataWithStoredProcedure("aspnet_Membership_CreateUser", new SqlParameter("@ApplicationName", applicationName), new SqlParameter("@UserName", userName), new SqlParameter("@Password", password), new SqlParameter("@PasswordSalt", passwordSalt), new SqlParameter("@Email", email), new SqlParameter("@PasswordQuestion", passwordQuestion), new SqlParameter("@PasswordAnswer", passwordAnswer), new SqlParameter("@IsApproved", isApproved), new SqlParameter("@CurrentTimeUtc", currentTimeUtc), new SqlParameter("@CreateDate", createDate), new SqlParameter("@UniqueEmail", uniqueEmail), new SqlParameter("@PasswordFormat", passwordFormat), new SqlParameter("@UserId", userId) );
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// ExistsUser
        /// </summary>
        /// <param name="projectId">projectId</param>    
        /// <param name="assetId">assetId</param>
        /// <param name="actualWorkType">actualWorkType</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        //public bool ExistsUser(int projectId, int assetId, int companyId)
        //{
        //    string commandText = String.Format("SELECT COUNT(*) AS NO " +
        //                                       " FROM  aspnet_Membership am " +
        //                                       " WHERE (AssetID = {1}) AND (WorkType LIKE '{2}') " +
        //                                       " AND (ProjectID <> {0} AND (COMPANY_ID = {3}))", projectId, assetId, workType, companyId);

        //    int count = (int)ExecuteScalar(commandText);

        //    return (count > 0) ? true : false;
        //}

    }
}



