using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime
{
    /// <summary>
    /// TeamProjectTime2DetailGateway 
    /// </summary>
    public class TeamProjectTime2DetailGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTOR
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TeamProjectTime2DetailGateway()
            : base("LFS_TEAM_PROJECT_TIME_DETAIL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public TeamProjectTime2DetailGateway(DataSet data)
            : base(data, "LFS_TEAM_PROJECT_TIME_DETAIL")
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
            tableMapping.DataSetTable = "LFS_TEAM_PROJECT_TIME_DETAIL";
            tableMapping.ColumnMappings.Add("TeamProjectTimeID", "TeamProjectTimeID");
            tableMapping.ColumnMappings.Add("DetailID", "DetailID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("CompaniesID", "CompaniesID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("StartTime", "StartTime");
            tableMapping.ColumnMappings.Add("EndTime", "EndTime");
            tableMapping.ColumnMappings.Add("Offset", "Offset");
            tableMapping.ColumnMappings.Add("ProjectTime", "ProjectTime");
            tableMapping.ColumnMappings.Add("WorkingDetails", "WorkingDetails");
            tableMapping.ColumnMappings.Add("Location", "Location");
            tableMapping.ColumnMappings.Add("MealsCountry", "MealsCountry");
            tableMapping.ColumnMappings.Add("MealsAllowanceType", "MealsAllowanceType");
            tableMapping.ColumnMappings.Add("MealsAllowance", "MealsAllowance");
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("TowedUnitID", "TowedUnitID");
            tableMapping.ColumnMappings.Add("ProjectTimeState", "ProjectTimeState");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("Work_", "Work_");
            tableMapping.ColumnMappings.Add("Function_", "Function_");
            tableMapping.ColumnMappings.Add("FairWage", "FairWage");
            tableMapping.ColumnMappings.Add("JobClassType", "JobClassType");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_TEAM_PROJECT_TIME_DETAIL] WHERE (([TeamProjectTimeID] = @O" +
                "riginal_TeamProjectTimeID) AND ([DetailID] = @Original_DetailID) AND ([EmployeeI" +
                "D] = @Original_EmployeeID) AND ([CompaniesID] = @Original_CompaniesID) AND ([Pro" +
                "jectID] = @Original_ProjectID) AND ([Date_] = @Original_Date_) AND ((@IsNull_Sta" +
                "rtTime = 1 AND [StartTime] IS NULL) OR ([StartTime] = @Original_StartTime)) AND " +
                "((@IsNull_EndTime = 1 AND [EndTime] IS NULL) OR ([EndTime] = @Original_EndTime))" +
                " AND ((@IsNull_Offset = 1 AND [Offset] IS NULL) OR ([Offset] = @Original_Offset)" +
                ") AND ([ProjectTime] = @Original_ProjectTime) AND ((@IsNull_WorkingDetails = 1 A" +
                "ND [WorkingDetails] IS NULL) OR ([WorkingDetails] = @Original_WorkingDetails)) A" +
                "ND ((@IsNull_Location = 1 AND [Location] IS NULL) OR ([Location] = @Original_Loc" +
                "ation)) AND ((@IsNull_MealsCountry = 1 AND [MealsCountry] IS NULL) OR ([MealsCou" +
                "ntry] = @Original_MealsCountry)) AND ((@IsNull_MealsAllowanceType = 1 AND [Meals" +
                "AllowanceType] IS NULL) OR ([MealsAllowanceType] = @Original_MealsAllowanceType)" +
                ") AND ([MealsAllowance] = @Original_MealsAllowance) AND ((@IsNull_UnitID = 1 AND" +
                " [UnitID] IS NULL) OR ([UnitID] = @Original_UnitID)) AND ((@IsNull_TowedUnitID =" +
                " 1 AND [TowedUnitID] IS NULL) OR ([TowedUnitID] = @Original_TowedUnitID)) AND ([" +
                "ProjectTimeState] = @Original_ProjectTimeState) AND ([Deleted] = @Original_Delet" +
                "ed) AND ((@IsNull_Work_ = 1 AND [Work_] IS NULL) OR ([Work_] = @Original_Work_))" +
                " AND ((@IsNull_Function_ = 1 AND [Function_] IS NULL) OR ([Function_] = @Origina" +
                "l_Function_)) AND ([FairWage] = @Original_FairWage) AND ((@IsNull_JobClassType =" +
                " 1 AND [JobClassType] IS NULL) OR ([JobClassType] = @Original_JobClassType)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TeamProjectTimeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TeamProjectTimeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DetailID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DetailID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompaniesID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompaniesID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Date_", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartTime", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_EndTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndTime", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Offset", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Offset", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Offset", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Offset", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectTime", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectTimeState", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectTimeState", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Work_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Function_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FairWage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FairWage", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_JobClassType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_JobClassType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_TEAM_PROJECT_TIME_DETAIL] ([TeamProjectTimeID], [DetailID], [EmployeeID], [CompaniesID], [ProjectID], [Date_], [StartTime], [EndTime], [Offset], [ProjectTime], [WorkingDetails], [Location], [MealsCountry], [MealsAllowanceType], [MealsAllowance], [UnitID], [TowedUnitID], [ProjectTimeState], [Comments], [Deleted], [Work_], [Function_], [FairWage], [JobClassType]) VALUES (@TeamProjectTimeID, @DetailID, @EmployeeID, @CompaniesID, @ProjectID, @Date_, @StartTime, @EndTime, @Offset, @ProjectTime, @WorkingDetails, @Location, @MealsCountry, @MealsAllowanceType, @MealsAllowance, @UnitID, @TowedUnitID, @ProjectTimeState, @Comments, @Deleted, @Work_, @Function_, @FairWage, @JobClassType);
SELECT TeamProjectTimeID, DetailID, EmployeeID, CompaniesID, ProjectID, Date_, StartTime, EndTime, Offset, ProjectTime, WorkingDetails, Location, MealsCountry, MealsAllowanceType, MealsAllowance, UnitID, TowedUnitID, ProjectTimeState, Comments, Deleted, Work_, Function_, FairWage, JobClassType FROM LFS_TEAM_PROJECT_TIME_DETAIL WHERE (DetailID = @DetailID) AND (TeamProjectTimeID = @TeamProjectTimeID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TeamProjectTimeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TeamProjectTimeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DetailID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DetailID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompaniesID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompaniesID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Date_", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartTime", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndTime", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Offset", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Offset", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectTime", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkingDetails", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkingDetails", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Location", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Location", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsCountry", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCountry", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsAllowanceType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsAllowanceType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsAllowance", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsAllowance", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TowedUnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TowedUnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectTimeState", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectTimeState", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FairWage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FairWage", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@JobClassType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_TEAM_PROJECT_TIME_DETAIL] SET [TeamProjectTimeID] = @TeamProjec" +
                "tTimeID, [DetailID] = @DetailID, [EmployeeID] = @EmployeeID, [CompaniesID] = @Co" +
                "mpaniesID, [ProjectID] = @ProjectID, [Date_] = @Date_, [StartTime] = @StartTime," +
                " [EndTime] = @EndTime, [Offset] = @Offset, [ProjectTime] = @ProjectTime, [Workin" +
                "gDetails] = @WorkingDetails, [Location] = @Location, [MealsCountry] = @MealsCoun" +
                "try, [MealsAllowanceType] = @MealsAllowanceType, [MealsAllowance] = @MealsAllowa" +
                "nce, [UnitID] = @UnitID, [TowedUnitID] = @TowedUnitID, [ProjectTimeState] = @Pro" +
                "jectTimeState, [Comments] = @Comments, [Deleted] = @Deleted, [Work_] = @Work_, [" +
                "Function_] = @Function_, [FairWage] = @FairWage, [JobClassType] = @JobClassType " +
                "WHERE (([TeamProjectTimeID] = @Original_TeamProjectTimeID) AND ([DetailID] = @Or" +
                "iginal_DetailID) AND ([EmployeeID] = @Original_EmployeeID) AND ([CompaniesID] = " +
                "@Original_CompaniesID) AND ([ProjectID] = @Original_ProjectID) AND ([Date_] = @O" +
                "riginal_Date_) AND ((@IsNull_StartTime = 1 AND [StartTime] IS NULL) OR ([StartTi" +
                "me] = @Original_StartTime)) AND ((@IsNull_EndTime = 1 AND [EndTime] IS NULL) OR " +
                "([EndTime] = @Original_EndTime)) AND ((@IsNull_Offset = 1 AND [Offset] IS NULL) " +
                "OR ([Offset] = @Original_Offset)) AND ([ProjectTime] = @Original_ProjectTime) AN" +
                "D ((@IsNull_WorkingDetails = 1 AND [WorkingDetails] IS NULL) OR ([WorkingDetails" +
                "] = @Original_WorkingDetails)) AND ((@IsNull_Location = 1 AND [Location] IS NULL" +
                ") OR ([Location] = @Original_Location)) AND ((@IsNull_MealsCountry = 1 AND [Meal" +
                "sCountry] IS NULL) OR ([MealsCountry] = @Original_MealsCountry)) AND ((@IsNull_M" +
                "ealsAllowanceType = 1 AND [MealsAllowanceType] IS NULL) OR ([MealsAllowanceType]" +
                " = @Original_MealsAllowanceType)) AND ([MealsAllowance] = @Original_MealsAllowan" +
                "ce) AND ((@IsNull_UnitID = 1 AND [UnitID] IS NULL) OR ([UnitID] = @Original_Unit" +
                "ID)) AND ((@IsNull_TowedUnitID = 1 AND [TowedUnitID] IS NULL) OR ([TowedUnitID] " +
                "= @Original_TowedUnitID)) AND ([ProjectTimeState] = @Original_ProjectTimeState) " +
                "AND ([Deleted] = @Original_Deleted) AND ((@IsNull_Work_ = 1 AND [Work_] IS NULL)" +
                " OR ([Work_] = @Original_Work_)) AND ((@IsNull_Function_ = 1 AND [Function_] IS " +
                "NULL) OR ([Function_] = @Original_Function_)) AND ([FairWage] = @Original_FairWa" +
                "ge) AND ((@IsNull_JobClassType = 1 AND [JobClassType] IS NULL) OR ([JobClassType" +
                "] = @Original_JobClassType)));\r\nSELECT TeamProjectTimeID, DetailID, EmployeeID, " +
                "CompaniesID, ProjectID, Date_, StartTime, EndTime, Offset, ProjectTime, WorkingD" +
                "etails, Location, MealsCountry, MealsAllowanceType, MealsAllowance, UnitID, Towe" +
                "dUnitID, ProjectTimeState, Comments, Deleted, Work_, Function_, FairWage, JobCla" +
                "ssType FROM LFS_TEAM_PROJECT_TIME_DETAIL WHERE (DetailID = @DetailID) AND (TeamP" +
                "rojectTimeID = @TeamProjectTimeID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TeamProjectTimeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TeamProjectTimeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DetailID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DetailID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompaniesID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompaniesID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Date_", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartTime", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndTime", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Offset", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Offset", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectTime", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkingDetails", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkingDetails", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Location", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Location", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsCountry", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsCountry", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsAllowanceType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsAllowanceType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MealsAllowance", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MealsAllowance", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TowedUnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TowedUnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectTimeState", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectTimeState", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FairWage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FairWage", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@JobClassType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TeamProjectTimeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TeamProjectTimeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DetailID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DetailID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompaniesID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompaniesID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Date_", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartTime", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_EndTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndTime", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Offset", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Offset", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Offset", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Offset", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectTime", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectTimeState", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectTimeState", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Work_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Function_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FairWage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FairWage", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_JobClassType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_JobClassType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC CONSTRUCTOR
        //

        /// <summary>
        /// LoadByTeamProjectTimeId
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByTeamProjectTimeId(int teamProjectTimeId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_TEAMPROJECTTIME2DETAILGATEWAY_LOADBYTEAMPROJECTTIMEID", new SqlParameter("@teamProjectTimeId", teamProjectTimeId));
            return Data;
        }



        /// <summary>
        /// LoadAllByTeamProjectTimeId
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllByTeamProjectTimeId(int teamProjectTimeId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_TEAMPROJECTTIME2DETAILGATEWAY_LOADALLBYTEAMPROJECTTIMEID", new SqlParameter("@teamProjectTimeId", teamProjectTimeId));
            return Data;
        }



        /// <summary>
        /// CountByTeamProjectTimeId
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>Count </returns>
        public int CountByTeamProjectTimeId(int teamProjectTimeId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_TEAMPROJECTTIME2DETAILGATEWAY_COUNTBYTEAMPROJECTTIMEID", new SqlParameter("@teamProjectTimeId", teamProjectTimeId));

            return (int)Table.Rows[0]["Count"];
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detaildId">detailId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int teamProjectTimeId, int detaildId)
        {
            string filter = string.Format("TeamProjectTimeID = {0} AND DetailID = {1}", teamProjectTimeId, detaildId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime.TeamProjectTime2DetailGateway.GetRow");
            }
        }



        /// <summary>
        /// GetEmployeeId
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Employee Id</returns>
        public int GetEmployeeId(int teamProjectTimeId, int detailId)
        {
            return (int)GetRow(teamProjectTimeId, detailId)["EmployeeID"];
        }



        /// <summary>
        /// GetCompaniesId
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Companies Id</returns>
        public int GetCompaniesId(int teamProjectTimeId, int detailId)
        {
            return (int)GetRow(teamProjectTimeId, detailId)["CompaniesID"];
        }



        /// <summary>
        /// GetProjectId
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Project Id</returns>
        public int GetProjectId(int teamProjectTimeId, int detailId)
        {
            return (int)GetRow(teamProjectTimeId, detailId)["ProjectID"];
        }



        /// <summary>
        /// GetDate_
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Date_</returns>
        public DateTime GetDate_(int teamProjectTimeId, int detailId)
        {
            return (DateTime)GetRow(teamProjectTimeId, detailId)["Date_"];
        }



        /// <summary>
        /// GetStartTime
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Star Time or EMPTY</returns>
        public string GetStartTime(int teamProjectTimeId, int detailId)
        {
            if (GetRow(teamProjectTimeId, detailId).IsNull("StartTime"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(teamProjectTimeId, detailId)["StartTime"];
            }
        }



        /// <summary>
        /// GetEndTime
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>End Time or EMPTY</returns>
        public string GetEndTime(int teamProjectTimeId, int detailId)
        {
            if (GetRow(teamProjectTimeId, detailId).IsNull("EndTime"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(teamProjectTimeId, detailId)["EndTime"];
            }
        }



        /// <summary>
        /// GetOffset
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Offset or null</returns>
        public double? GetOffset(int teamProjectTimeId, int detailId)
        {
            if (GetRow(teamProjectTimeId, detailId).IsNull("Offset"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(teamProjectTimeId, detailId)["Offset"];
            }
        }



        /// <summary>
        /// GetProjectTime
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Project Time</returns>
        public double GetProjectTime(int teamProjectTimeId, int detailId)
        {
            return (double)GetRow(teamProjectTimeId, detailId)["ProjectTime"];
        }



        /// <summary>
        /// GetWorkingDetails
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Working Details or EMPTY</returns>
        public string GetWorkingDetails(int teamProjectTimeId, int detailId)
        {
            if (GetRow(teamProjectTimeId, detailId).IsNull("WorkingDetails"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(teamProjectTimeId, detailId)["WorkingDetails"];
            }
        }



        /// <summary>
        /// GetLocation
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Location o EMPTY</returns>
        public string GetLocation(int teamProjectTimeId, int detailId)
        {
            if (GetRow(teamProjectTimeId, detailId).IsNull("Location"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(teamProjectTimeId, detailId)["Location"];
            }
        }



        /// <summary>
        /// GetMealsCountry
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Meals Country or null</returns>
        public Int64? GetMealsCountry(int teamProjectTimeId, int detailId)
        {
            if (GetRow(teamProjectTimeId, detailId).IsNull("MealsCountry"))
            {
                return null;
            }
            else
            {
                return (Int64)GetRow(teamProjectTimeId, detailId)["MealsCountry"];
            }
        }



        /// <summary>
        /// GetMealsAllowanceType
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns> Meals Allowance Type or EMPTY</returns>
        public string GetMealsAllowanceType(int teamProjectTimeId, int detailId)
        {
            if (GetRow(teamProjectTimeId, detailId).IsNull("MealsAllowanceType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(teamProjectTimeId, detailId)["MealsAllowanceType"];
            }
        }



        /// <summary>
        /// GetMealsAllowance
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Meals Allowance</returns>
        public decimal GetMealsAllowance(int teamProjectTimeId, int detailId)
        {
            return (decimal)GetRow(teamProjectTimeId, detailId)["MealsAllowance"];
        }



        /// <summary>
        /// GetUnitId 
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Unit Id or null</returns>
        public int? GetUnitId(int teamProjectTimeId, int detailId)
        {
            if (GetRow(teamProjectTimeId, detailId).IsNull("UnitId"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(teamProjectTimeId, detailId)["UnitId"];
            }
        }



        /// <summary>
        /// GetTowedUnitId
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Towed Unit Id or null</returns>
        public int? GetTowedUnitId(int teamProjectTimeId, int detailId)
        {
            if (GetRow(teamProjectTimeId, detailId).IsNull("TowedUnitId"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(teamProjectTimeId, detailId)["TowedUnitId"];
            }

        }



        /// <summary>
        /// GetComments
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Comments or EMPTY</returns>
        public string GetComments(int teamProjectTimeId, int detailId)
        {
            if (GetRow(teamProjectTimeId, detailId).IsNull("Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(teamProjectTimeId, detailId)["Comments"];
            }
        }



        /// <summary>
        /// GetProjectTimeState
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Project Time State</returns>
        public string GetProjectTimeState(int teamProjectTimeId, int detailId)
        {
            return (string)GetRow(teamProjectTimeId, detailId)["ProjectTimeState"];
        }



        /// <summary>
        /// GetWork
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Work_ or EMPTY</returns>
        public string GetWork(int teamProjectTimeId, int detailId)
        {
            if (GetRow(teamProjectTimeId, detailId).IsNull("Work_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(teamProjectTimeId, detailId)["Work_"];
            }
        }



        /// <summary>
        /// GetFunction
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Function_ or EMPTY</returns>
        public string GetFunction(int teamProjectTimeId, int detailId)
        {
            if (GetRow(teamProjectTimeId, detailId).IsNull("Function_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(teamProjectTimeId, detailId)["Function_"];
            }
        }



        /// <summary>
        /// GetFairWage
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>FairWage</returns>
        public bool GetFairWage(int teamProjectTimeId, int detailId)
        {
            return (bool)GetRow(teamProjectTimeId, detailId)["FairWage"];
        }



        /// <summary>
        /// GetJobClassType
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>JobClassType or EMPTY</returns>
        public string GetJobClassType(int teamProjectTimeId, int detailId)
        {
            if (GetRow(teamProjectTimeId, detailId).IsNull("JobClassType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(teamProjectTimeId, detailId)["JobClassType"];
            }
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