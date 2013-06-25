using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime
{
    /// <summary>
    /// TeamProjectTime2Gateway
    /// </summary>
    public class TeamProjectTime2Gateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TeamProjectTime2Gateway()
            : base("LFS_TEAM_PROJECT_TIME")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public TeamProjectTime2Gateway(DataSet data)
            : base(data, "LFS_TEAM_PROJECT_TIME")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new TeamProjectTime2TDS();
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
            tableMapping.DataSetTable = "LFS_TEAM_PROJECT_TIME";
            tableMapping.ColumnMappings.Add("TeamProjectTimeID", "TeamProjectTimeID");
            tableMapping.ColumnMappings.Add("TemplateName", "TemplateName");
            tableMapping.ColumnMappings.Add("CompaniesID", "CompaniesID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("StartTime", "StartTime");
            tableMapping.ColumnMappings.Add("EndTime", "EndTime");
            tableMapping.ColumnMappings.Add("Offset", "Offset");
            tableMapping.ColumnMappings.Add("WorkingDetails", "WorkingDetails");
            tableMapping.ColumnMappings.Add("Location", "Location");
            tableMapping.ColumnMappings.Add("MealsCountry", "MealsCountry");
            tableMapping.ColumnMappings.Add("MealsAllowanceType", "MealsAllowanceType");
            tableMapping.ColumnMappings.Add("MealsAllowance", "MealsAllowance");
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("TowedUnitID", "TowedUnitID");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("LoginID", "LoginID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("Work_", "Work_");
            tableMapping.ColumnMappings.Add("Function_", "Function_");
            tableMapping.ColumnMappings.Add("FairWage", "FairWage");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_TEAM_PROJECT_TIME] WHERE (([TeamProjectTimeID] = @Original" +
                "_TeamProjectTimeID) AND ((@IsNull_TemplateName = 1 AND [TemplateName] IS NULL) O" +
                "R ([TemplateName] = @Original_TemplateName)) AND ([CompaniesID] = @Original_Comp" +
                "aniesID) AND ([ProjectID] = @Original_ProjectID) AND ([Date_] = @Original_Date_)" +
                " AND ((@IsNull_StartTime = 1 AND [StartTime] IS NULL) OR ([StartTime] = @Origina" +
                "l_StartTime)) AND ((@IsNull_EndTime = 1 AND [EndTime] IS NULL) OR ([EndTime] = @" +
                "Original_EndTime)) AND ((@IsNull_Offset = 1 AND [Offset] IS NULL) OR ([Offset] =" +
                " @Original_Offset)) AND ((@IsNull_WorkingDetails = 1 AND [WorkingDetails] IS NUL" +
                "L) OR ([WorkingDetails] = @Original_WorkingDetails)) AND ((@IsNull_Location = 1 " +
                "AND [Location] IS NULL) OR ([Location] = @Original_Location)) AND ((@IsNull_Meal" +
                "sCountry = 1 AND [MealsCountry] IS NULL) OR ([MealsCountry] = @Original_MealsCou" +
                "ntry)) AND ((@IsNull_MealsAllowanceType = 1 AND [MealsAllowanceType] IS NULL) OR" +
                " ([MealsAllowanceType] = @Original_MealsAllowanceType)) AND ([MealsAllowance] = " +
                "@Original_MealsAllowance) AND ((@IsNull_UnitID = 1 AND [UnitID] IS NULL) OR ([Un" +
                "itID] = @Original_UnitID)) AND ((@IsNull_TowedUnitID = 1 AND [TowedUnitID] IS NU" +
                "LL) OR ([TowedUnitID] = @Original_TowedUnitID)) AND ([Type] = @Original_Type) AN" +
                "D ([State] = @Original_State) AND ([LoginID] = @Original_LoginID) AND ([Deleted]" +
                " = @Original_Deleted) AND ((@IsNull_Work_ = 1 AND [Work_] IS NULL) OR ([Work_] =" +
                " @Original_Work_)) AND ((@IsNull_Function_ = 1 AND [Function_] IS NULL) OR ([Fun" +
                "ction_] = @Original_Function_)) AND ([FairWage] = @Original_FairWage))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TeamProjectTimeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TeamProjectTimeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TemplateName", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TemplateName", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TemplateName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TemplateName", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompaniesID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompaniesID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Date_", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_EndTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Offset", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Offset", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Offset", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Offset", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_WorkingDetails", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkingDetails", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkingDetails", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkingDetails", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Location", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Location", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Location", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Location", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MealsCountry", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCountry", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MealsCountry", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCountry", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MealsAllowanceType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsAllowanceType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MealsAllowanceType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsAllowanceType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MealsAllowance", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsAllowance", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TowedUnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TowedUnitID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TowedUnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TowedUnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LoginID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LoginID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Work_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Function_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FairWage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FairWage", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_TEAM_PROJECT_TIME] ([TemplateName], [CompaniesID], [ProjectID], [Date_], [StartTime], [EndTime], [Offset], [WorkingDetails], [Location], [MealsCountry], [MealsAllowanceType], [MealsAllowance], [UnitID], [TowedUnitID], [Comments], [Type], [State], [LoginID], [Deleted], [Work_], [Function_], [FairWage]) VALUES (@TemplateName, @CompaniesID, @ProjectID, @Date_, @StartTime, @EndTime, @Offset, @WorkingDetails, @Location, @MealsCountry, @MealsAllowanceType, @MealsAllowance, @UnitID, @TowedUnitID, @Comments, @Type, @State, @LoginID, @Deleted, @Work_, @Function_, @FairWage);
SELECT TeamProjectTimeID, TemplateName, CompaniesID, ProjectID, Date_, StartTime, EndTime, Offset, WorkingDetails, Location, MealsCountry, MealsAllowanceType, MealsAllowance, UnitID, TowedUnitID, Comments, Type, State, LoginID, Deleted, Work_, Function_, FairWage FROM LFS_TEAM_PROJECT_TIME WHERE (TeamProjectTimeID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TemplateName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TemplateName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompaniesID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompaniesID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Date_", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Offset", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Offset", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkingDetails", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkingDetails", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Location", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Location", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsCountry", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCountry", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsAllowanceType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsAllowanceType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsAllowance", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsAllowance", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TowedUnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TowedUnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LoginID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LoginID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FairWage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FairWage", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_TEAM_PROJECT_TIME] SET [TemplateName] = @TemplateName, [Compani" +
                "esID] = @CompaniesID, [ProjectID] = @ProjectID, [Date_] = @Date_, [StartTime] = " +
                "@StartTime, [EndTime] = @EndTime, [Offset] = @Offset, [WorkingDetails] = @Workin" +
                "gDetails, [Location] = @Location, [MealsCountry] = @MealsCountry, [MealsAllowanc" +
                "eType] = @MealsAllowanceType, [MealsAllowance] = @MealsAllowance, [UnitID] = @Un" +
                "itID, [TowedUnitID] = @TowedUnitID, [Comments] = @Comments, [Type] = @Type, [Sta" +
                "te] = @State, [LoginID] = @LoginID, [Deleted] = @Deleted, [Work_] = @Work_, [Fun" +
                "ction_] = @Function_, [FairWage] = @FairWage WHERE (([TeamProjectTimeID] = @Orig" +
                "inal_TeamProjectTimeID) AND ((@IsNull_TemplateName = 1 AND [TemplateName] IS NUL" +
                "L) OR ([TemplateName] = @Original_TemplateName)) AND ([CompaniesID] = @Original_" +
                "CompaniesID) AND ([ProjectID] = @Original_ProjectID) AND ([Date_] = @Original_Da" +
                "te_) AND ((@IsNull_StartTime = 1 AND [StartTime] IS NULL) OR ([StartTime] = @Ori" +
                "ginal_StartTime)) AND ((@IsNull_EndTime = 1 AND [EndTime] IS NULL) OR ([EndTime]" +
                " = @Original_EndTime)) AND ((@IsNull_Offset = 1 AND [Offset] IS NULL) OR ([Offse" +
                "t] = @Original_Offset)) AND ((@IsNull_WorkingDetails = 1 AND [WorkingDetails] IS" +
                " NULL) OR ([WorkingDetails] = @Original_WorkingDetails)) AND ((@IsNull_Location " +
                "= 1 AND [Location] IS NULL) OR ([Location] = @Original_Location)) AND ((@IsNull_" +
                "MealsCountry = 1 AND [MealsCountry] IS NULL) OR ([MealsCountry] = @Original_Meal" +
                "sCountry)) AND ((@IsNull_MealsAllowanceType = 1 AND [MealsAllowanceType] IS NULL" +
                ") OR ([MealsAllowanceType] = @Original_MealsAllowanceType)) AND ([MealsAllowance" +
                "] = @Original_MealsAllowance) AND ((@IsNull_UnitID = 1 AND [UnitID] IS NULL) OR " +
                "([UnitID] = @Original_UnitID)) AND ((@IsNull_TowedUnitID = 1 AND [TowedUnitID] I" +
                "S NULL) OR ([TowedUnitID] = @Original_TowedUnitID)) AND ([Type] = @Original_Type" +
                ") AND ([State] = @Original_State) AND ([LoginID] = @Original_LoginID) AND ([Dele" +
                "ted] = @Original_Deleted) AND ((@IsNull_Work_ = 1 AND [Work_] IS NULL) OR ([Work" +
                "_] = @Original_Work_)) AND ((@IsNull_Function_ = 1 AND [Function_] IS NULL) OR (" +
                "[Function_] = @Original_Function_)) AND ([FairWage] = @Original_FairWage));\r\nSEL" +
                "ECT TeamProjectTimeID, TemplateName, CompaniesID, ProjectID, Date_, StartTime, E" +
                "ndTime, Offset, WorkingDetails, Location, MealsCountry, MealsAllowanceType, Meal" +
                "sAllowance, UnitID, TowedUnitID, Comments, Type, State, LoginID, Deleted, Work_," +
                " Function_, FairWage FROM LFS_TEAM_PROJECT_TIME WHERE (TeamProjectTimeID = @Team" +
                "ProjectTimeID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TemplateName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TemplateName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompaniesID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompaniesID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Date_", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Offset", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Offset", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkingDetails", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkingDetails", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Location", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Location", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsCountry", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCountry", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsAllowanceType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsAllowanceType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsAllowance", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsAllowance", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TowedUnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TowedUnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LoginID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LoginID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FairWage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FairWage", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TeamProjectTimeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TeamProjectTimeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TemplateName", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TemplateName", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TemplateName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TemplateName", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompaniesID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompaniesID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Date_", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_EndTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Offset", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Offset", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Offset", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Offset", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_WorkingDetails", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkingDetails", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkingDetails", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkingDetails", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Location", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Location", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Location", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Location", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MealsCountry", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCountry", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MealsCountry", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCountry", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MealsAllowanceType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsAllowanceType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MealsAllowanceType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsAllowanceType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MealsAllowance", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsAllowance", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TowedUnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TowedUnitID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TowedUnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TowedUnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LoginID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LoginID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Work_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Function_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FairWage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FairWage", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TeamProjectTimeID", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "TeamProjectTimeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load one TeamProjectTime by TeamProjectTimeId
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>Data</returns>
        public DataSet LoadByTeamProjectTimeId(int teamProjectTimeId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_TEAMPROJECTTIME2GATEWAY_LOADBYTEAMPROJECTTIMEID", new SqlParameter("@teamProjectTimeId", teamProjectTimeId));
            return Data;
        }



        /// <summary>
        /// Load TeamProjectTimes for DropDownList by LoginID
        /// </summary>
        /// <param name="loginId">LoginID from RAF</param>
        /// <returns>Data</returns>
        public DataSet LoadForDropDownListByLoginId(int loginId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_TEAMPROJECTTIME2GATEWAY_LOADFORDROPDOWNLISTBYLOGINID", new SqlParameter("@loginId", loginId));
            return Data;
        }



        /// <summary>
        /// IsTemplateInUse by TemplateName and LoginId?
        /// </summary>
        /// <param name="templateName">templateName</param>
        /// <param name="loginId">loginId</param>
        public bool IsTemplateNameInUseByTemplateNameLoginId(string templateName, int loginId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_TEAMPROJECTTIME2GATEWAY_ISTEMPLATENAMEINUSEBYTEMPLATENAMELOGINID", new SqlParameter("@templateName", templateName), new SqlParameter("@loginId", loginId));

            if ((int)Table.Rows[0]["Count"] > 0)
            {
                return true;
            }
            return false;
        }



        /// <summary>
        /// Get a single TeamProjectTime. If not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int teamProjectTimeId)
        {
            string filter = string.Format("TeamProjectTimeID = {0}", teamProjectTimeId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime.TeamProjectTime2Gateway.GetRow");
            }
        }



        /// <summary>
        /// GetTemplateName. If TeamProjectTime not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>Template Name or EMPTY</returns>
        public string GetTemplateName(int teamProjectTimeId)
        {
            if (GetRow(teamProjectTimeId).IsNull("TemplateName"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(teamProjectTimeId)["TemplateName"];
            }
        }



        /// <summary>
        /// GetCompaniesId. If TeamProjectTime not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>Companies Id</returns>
        public int GetCompaniesId(int teamProjectTimeId)
        {
            return (int)GetRow(teamProjectTimeId)["CompaniesID"];
        }



        /// <summary>
        /// GetProjectIdId. If TeamProjectTime not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>Project Id</returns>
        public int GetProjectId(int teamProjectTimeId)
        {
            return (int)GetRow(teamProjectTimeId)["ProjectID"];
        }



        /// <summary>
        /// GetDate_. If TeamProjectTime not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>Date_</returns>
        public DateTime GetDate_(int teamProjectTimeId)
        {
            return (DateTime)GetRow(teamProjectTimeId)["Date_"];
        }



        /// <summary>
        /// GetStartTime. If TeamProjectTime not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns> Start Date or null</returns>
        public DateTime? GetStartTime(int teamProjectTimeId)
        {
            if (GetRow(teamProjectTimeId).IsNull("StartTime"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(teamProjectTimeId)["StartTime"];
            }
        }



        /// <summary>
        /// GetEndTime. If TeamProjectTime not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>End Time or null</returns>
        public DateTime? GetEndTime(int teamProjectTimeId)
        {
            if (GetRow(teamProjectTimeId).IsNull("EndTime"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(teamProjectTimeId)["EndTime"];
            }
        }



        /// <summary>
        /// GetOffset. If TeamProjectTime not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>Offset or null</returns>
        public double? GetOffset(int teamProjectTimeId)
        {
            if (GetRow(teamProjectTimeId).IsNull("Offset"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(teamProjectTimeId)["Offset"];
            }
        }



        /// <summary>
        /// GetWorkingDetails. If TeamProjectTime not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>Working Details or EMPTY</returns>
        public string GetWorkingDetails(int teamProjectTimeId)
        {
            if (GetRow(teamProjectTimeId).IsNull("WorkingDetails"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(teamProjectTimeId)["WorkingDetails"];
            }
        }



        /// <summary>
        /// GetLocation. If TeamProjectTime not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>Location or EMPTY</returns>
        public string GetLocation(int teamProjectTimeId)
        {
            if (GetRow(teamProjectTimeId).IsNull("Location"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(teamProjectTimeId)["Location"];
            }
        }



        /// <summary>
        /// GetMealsCountry. If TeamProjectTime not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>Meals Country or null</returns>
        public Int64? GetMealsCountry(int teamProjectTimeId)
        {
            if (GetRow(teamProjectTimeId).IsNull("MealsCountry"))
            {
                return null;
            }
            else
            {
                return (Int64)GetRow(teamProjectTimeId)["MealsCountry"];
            }
        }



        /// <summary>
        /// GetMealsAllowanceType. If TeamProjectTime not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>MealsAllowanceType or EMPTY</returns>
        public string GetMealsAllowanceType(int teamProjectTimeId)
        {
            if (GetRow(teamProjectTimeId).IsNull("MealsAllowanceType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(teamProjectTimeId)["MealsAllowanceType"];
            }
        }



        /// <summary>
        /// GetMealsAllowance. If TeamProjectTime not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>MealsAllowance</returns>
        public decimal GetMealsAllowance(int teamProjectTimeId)
        {
            return (decimal)GetRow(teamProjectTimeId)["MealsAllowance"];
        }



        /// <summary>
        /// GetUnitId. If TeamProjectTime not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>Unit Id or null</returns>
        public int? GetUnitId(int teamProjectTimeId)
        {
            if (GetRow(teamProjectTimeId).IsNull("UnitId"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(teamProjectTimeId)["UnitId"];
            }
        }



        /// <summary>
        /// GetTowedUnitId. If TeamProjectTime not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>Towed Unit Id or null</returns>
        public int? GetTowedUnitId(int teamProjectTimeId)
        {
            if (GetRow(teamProjectTimeId).IsNull("TowedUnitId"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(teamProjectTimeId)["TowedUnitId"];
            }
        }



        /// <summary>
        /// GetWork
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>Work_ or EMPTY</returns>
        public string GetWork(int teamProjectTimeId)
        {
            if (GetRow(teamProjectTimeId).IsNull("Work_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(teamProjectTimeId)["Work_"];
            }
        }



        /// <summary>
        /// GetFunction
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>Function_ or EMPTY</returns>
        public string GetFunction(int teamProjectTimeId)
        {
            if (GetRow(teamProjectTimeId).IsNull("Function_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(teamProjectTimeId)["Function_"];
            }
        }



        /// <summary>
        /// GetFairWage. If TeamProjectTime not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>FairWage</returns>
        public bool GetFairWage(int teamProjectTimeId)
        {
            return (bool)GetRow(teamProjectTimeId)["FairWage"];
        }



        /// <summary>
        /// Update TeamProjectTime, TeamProjectTimeDetail and ProjectTimes
        /// </summary>
        /// <param name="projectTime2TDS">ProjectTime2TDS</param>
        public void Update(ProjectTimeTDS projectTime2TDS)
        {
            TeamProjectTime2DetailGateway teamProjectTime2DetailGateway = new TeamProjectTime2DetailGateway(Data);
            ProjectTimeGateway projectTime2Gateway = new ProjectTimeGateway(projectTime2TDS);
            ProjectTimeSectionGateway projectTime2SectionGateway = new ProjectTimeSectionGateway(projectTime2TDS);

            DataTable teamProjectTime2Changes = Table.GetChanges();
            DataTable teamProjectTime2DetailChanges = teamProjectTime2DetailGateway.Table.GetChanges();
            DataTable projectTime2Changes = projectTime2Gateway.Table.GetChanges();
            DataTable projectTime2SectionChanges = projectTime2SectionGateway.Table.GetChanges();

            if ((teamProjectTime2Changes == null) && (teamProjectTime2DetailChanges == null) && (projectTime2Changes == null)) return;

            try
            {
                DB.Open();
                DB.BeginTransaction();

                Adapter.InsertCommand.Transaction = DB.Transaction;
                Adapter.UpdateCommand.Transaction = DB.Transaction;
                Adapter.DeleteCommand.Transaction = DB.Transaction;

                teamProjectTime2DetailGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                teamProjectTime2DetailGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                teamProjectTime2DetailGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectTime2Gateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectTime2Gateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectTime2Gateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectTime2SectionGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectTime2SectionGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectTime2SectionGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                if ((teamProjectTime2Changes != null) && (teamProjectTime2Changes.Rows.Count > 0))
                {
                    int lastTeamProjectTimeId = DB.GetIdentCurrent("LFS_TEAM_PROJECT_TIME", DB.Transaction);
                    Adapter.Update(teamProjectTime2Changes);
                    int newTeamProjectTimeId = DB.GetIdentCurrent("LFS_TEAM_PROJECT_TIME", DB.Transaction);
                    if (lastTeamProjectTimeId != newTeamProjectTimeId)
                    {
                        TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIMERow row = ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIMEDataTable)Table).FindByTeamProjectTimeID(0);
                        row.TeamProjectTimeID = newTeamProjectTimeId;
                        teamProjectTime2DetailChanges = teamProjectTime2DetailGateway.Table.GetChanges();
                    }
                }

                if ((teamProjectTime2DetailChanges != null) && (teamProjectTime2DetailChanges.Rows.Count > 0))
                {
                    teamProjectTime2DetailGateway.Adapter.Update(teamProjectTime2DetailChanges);
                }

                if ((projectTime2Changes != null) && (projectTime2Changes.Rows.Count > 0))
                {
                    projectTime2Gateway.Adapter.Update(projectTime2Changes);
                }

                if ((projectTime2SectionChanges != null) && (projectTime2SectionChanges.Rows.Count > 0))
                {
                    projectTime2SectionGateway.Adapter.Update(projectTime2SectionChanges);
                }

                DB.CommitTransaction();
            }
            catch (DBConcurrencyException dBConcurrencyException)
            {
                DB.RollbackTransaction();
                throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
            }
            catch (SqlException sqlException)
            {
                DB.RollbackTransaction();
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
                DB.RollbackTransaction();
                throw new Exception("Unknow error. Your operation has been cancelled.", e);
            }
            finally
            {
                DB.Close();
            }
        }



        /// <summary>
        /// Update TeamProjectTime and TeamProjectTimeDetails
        /// </summary>
        public void UpdateForTemplate()
        {
            TeamProjectTime2DetailGateway teamProjectTime2DetailGateway = new TeamProjectTime2DetailGateway(Data);

            DataTable teamProjectTime2Changes = Table.GetChanges();
            DataTable teamProjectTime2DetailChanges = teamProjectTime2DetailGateway.Table.GetChanges();

            if ((teamProjectTime2Changes == null) && (teamProjectTime2DetailChanges == null)) return;

            try
            {
                DB.Open();
                DB.BeginTransaction();

                Adapter.InsertCommand.Transaction = DB.Transaction;
                Adapter.UpdateCommand.Transaction = DB.Transaction;
                Adapter.DeleteCommand.Transaction = DB.Transaction;

                teamProjectTime2DetailGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                teamProjectTime2DetailGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                teamProjectTime2DetailGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                if ((teamProjectTime2Changes != null) && (teamProjectTime2Changes.Rows.Count > 0))
                {
                    Adapter.Update(teamProjectTime2Changes);
                }

                if ((teamProjectTime2DetailChanges != null) && (teamProjectTime2DetailChanges.Rows.Count > 0))
                {
                    teamProjectTime2DetailGateway.Adapter.Update(teamProjectTime2DetailChanges);
                }

                DB.CommitTransaction();
            }
            catch (DBConcurrencyException dBConcurrencyException)
            {
                DB.RollbackTransaction();
                throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
            }
            catch (SqlException sqlException)
            {
                DB.RollbackTransaction();
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
                DB.RollbackTransaction();
                throw new Exception("Unknow error. Your operation has been cancelled.", e);
            }
            finally
            {
                DB.Close();
            }
        }



    }
}