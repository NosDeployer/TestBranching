using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// ProjectTimeGateway
    /// </summary>
    public class ProjectTimeGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTimeGateway()
            : base("LFS_PROJECT_TIME")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTimeGateway(DataSet data)
            : base(data, "LFS_PROJECT_TIME")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTimeTDS();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization
            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.DataSetTable = "LFS_PROJECT_TIME";
            tableMapping.ColumnMappings.Add("ProjectTimeID", "ProjectTimeID");
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
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ApprovedByID", "ApprovedByID");
            tableMapping.ColumnMappings.Add("FairWage", "FairWage");
            tableMapping.ColumnMappings.Add("JobClassType", "JobClassType");
            tableMapping.ColumnMappings.Add("CreatedByID", "CreatedByID");
            tableMapping.ColumnMappings.Add("CreateDate", "CreateDate");
            tableMapping.ColumnMappings.Add("UpdateByID", "UpdateByID");
            tableMapping.ColumnMappings.Add("UpdateDate", "UpdateDate");
            tableMapping.ColumnMappings.Add("DeletedByID", "DeletedByID");
            tableMapping.ColumnMappings.Add("DeleteDate", "DeleteDate");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_PROJECT_TIME] WHERE (([ProjectTimeID] = @Original_ProjectT" +
                "imeID) AND ([EmployeeID] = @Original_EmployeeID) AND ([CompaniesID] = @Original_" +
                "CompaniesID) AND ([ProjectID] = @Original_ProjectID) AND ([Date_] = @Original_Da" +
                "te_) AND ((@IsNull_StartTime = 1 AND [StartTime] IS NULL) OR ([StartTime] = @Ori" +
                "ginal_StartTime)) AND ((@IsNull_EndTime = 1 AND [EndTime] IS NULL) OR ([EndTime]" +
                " = @Original_EndTime)) AND ((@IsNull_Offset = 1 AND [Offset] IS NULL) OR ([Offse" +
                "t] = @Original_Offset)) AND ([ProjectTime] = @Original_ProjectTime) AND ((@IsNul" +
                "l_WorkingDetails = 1 AND [WorkingDetails] IS NULL) OR ([WorkingDetails] = @Origi" +
                "nal_WorkingDetails)) AND ((@IsNull_Location = 1 AND [Location] IS NULL) OR ([Loc" +
                "ation] = @Original_Location)) AND ((@IsNull_MealsCountry = 1 AND [MealsCountry] " +
                "IS NULL) OR ([MealsCountry] = @Original_MealsCountry)) AND ((@IsNull_MealsAllowa" +
                "nceType = 1 AND [MealsAllowanceType] IS NULL) OR ([MealsAllowanceType] = @Origin" +
                "al_MealsAllowanceType)) AND ([MealsAllowance] = @Original_MealsAllowance) AND ((" +
                "@IsNull_UnitID = 1 AND [UnitID] IS NULL) OR ([UnitID] = @Original_UnitID)) AND (" +
                "(@IsNull_TowedUnitID = 1 AND [TowedUnitID] IS NULL) OR ([TowedUnitID] = @Origina" +
                "l_TowedUnitID)) AND ([ProjectTimeState] = @Original_ProjectTimeState) AND ([Dele" +
                "ted] = @Original_Deleted) AND ((@IsNull_Work_ = 1 AND [Work_] IS NULL) OR ([Work" +
                "_] = @Original_Work_)) AND ((@IsNull_Function_ = 1 AND [Function_] IS NULL) OR (" +
                "[Function_] = @Original_Function_)) AND ([COMPANY_ID] = @Original_COMPANY_ID) AN" +
                "D ((@IsNull_ApprovedByID = 1 AND [ApprovedByID] IS NULL) OR ([ApprovedByID] = @O" +
                "riginal_ApprovedByID)) AND ([FairWage] = @Original_FairWage) AND ((@IsNull_JobCl" +
                "assType = 1 AND [JobClassType] IS NULL) OR ([JobClassType] = @Original_JobClassT" +
                "ype)) AND ((@IsNull_CreatedByID = 1 AND [CreatedByID] IS NULL) OR ([CreatedByID]" +
                " = @Original_CreatedByID)) AND ((@IsNull_CreateDate = 1 AND [CreateDate] IS NULL" +
                ") OR ([CreateDate] = @Original_CreateDate)) AND ((@IsNull_UpdateByID = 1 AND [Up" +
                "dateByID] IS NULL) OR ([UpdateByID] = @Original_UpdateByID)) AND ((@IsNull_Updat" +
                "eDate = 1 AND [UpdateDate] IS NULL) OR ([UpdateDate] = @Original_UpdateDate)) AN" +
                "D ((@IsNull_DeletedByID = 1 AND [DeletedByID] IS NULL) OR ([DeletedByID] = @Orig" +
                "inal_DeletedByID)) AND ((@IsNull_DeleteDate = 1 AND [DeleteDate] IS NULL) OR ([D" +
                "eleteDate] = @Original_DeleteDate)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectTimeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectTimeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompaniesID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompaniesID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Date_", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_EndTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ApprovedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApprovedByID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ApprovedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApprovedByID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FairWage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FairWage", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_JobClassType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_JobClassType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CreatedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreatedByID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CreatedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreatedByID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CreateDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreateDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CreateDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreateDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_UpdateByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UpdateByID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UpdateByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UpdateByID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_UpdateDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UpdateDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UpdateDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UpdateDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DeletedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeletedByID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DeletedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeletedByID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DeleteDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeleteDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DeleteDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeleteDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT_TIME] ([EmployeeID], [CompaniesID], [ProjectID], [Date_], [StartTime], [EndTime], [Offset], [ProjectTime], [WorkingDetails], [Location], [MealsCountry], [MealsAllowanceType], [MealsAllowance], [UnitID], [TowedUnitID], [ProjectTimeState], [Comments], [Deleted], [Work_], [Function_], [COMPANY_ID], [ApprovedByID], [FairWage], [JobClassType], [CreatedByID], [CreateDate], [UpdateByID], [UpdateDate], [DeletedByID], [DeleteDate]) VALUES (@EmployeeID, @CompaniesID, @ProjectID, @Date_, @StartTime, @EndTime, @Offset, @ProjectTime, @WorkingDetails, @Location, @MealsCountry, @MealsAllowanceType, @MealsAllowance, @UnitID, @TowedUnitID, @ProjectTimeState, @Comments, @Deleted, @Work_, @Function_, @COMPANY_ID, @ApprovedByID, @FairWage, @JobClassType, @CreatedByID, @CreateDate, @UpdateByID, @UpdateDate, @DeletedByID, @DeleteDate);
SELECT ProjectTimeID, EmployeeID, CompaniesID, ProjectID, Date_, StartTime, EndTime, Offset, ProjectTime, WorkingDetails, Location, MealsCountry, MealsAllowanceType, MealsAllowance, UnitID, TowedUnitID, ProjectTimeState, Comments, Deleted, Work_, Function_, COMPANY_ID, ApprovedByID, FairWage, JobClassType, CreatedByID, CreateDate, UpdateByID, UpdateDate, DeletedByID, DeleteDate FROM LFS_PROJECT_TIME WHERE (ProjectTimeID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompaniesID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompaniesID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Date_", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
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
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ApprovedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApprovedByID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FairWage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FairWage", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@JobClassType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CreatedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreatedByID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CreateDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreateDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UpdateByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UpdateByID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UpdateDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UpdateDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DeletedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeletedByID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DeleteDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeleteDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_PROJECT_TIME] SET [EmployeeID] = @EmployeeID, [CompaniesID] = @" +
                "CompaniesID, [ProjectID] = @ProjectID, [Date_] = @Date_, [StartTime] = @StartTim" +
                "e, [EndTime] = @EndTime, [Offset] = @Offset, [ProjectTime] = @ProjectTime, [Work" +
                "ingDetails] = @WorkingDetails, [Location] = @Location, [MealsCountry] = @MealsCo" +
                "untry, [MealsAllowanceType] = @MealsAllowanceType, [MealsAllowance] = @MealsAllo" +
                "wance, [UnitID] = @UnitID, [TowedUnitID] = @TowedUnitID, [ProjectTimeState] = @P" +
                "rojectTimeState, [Comments] = @Comments, [Deleted] = @Deleted, [Work_] = @Work_," +
                " [Function_] = @Function_, [COMPANY_ID] = @COMPANY_ID, [ApprovedByID] = @Approve" +
                "dByID, [FairWage] = @FairWage, [JobClassType] = @JobClassType, [CreatedByID] = @" +
                "CreatedByID, [CreateDate] = @CreateDate, [UpdateByID] = @UpdateByID, [UpdateDate" +
                "] = @UpdateDate, [DeletedByID] = @DeletedByID, [DeleteDate] = @DeleteDate WHERE " +
                "(([ProjectTimeID] = @Original_ProjectTimeID) AND ([EmployeeID] = @Original_Emplo" +
                "yeeID) AND ([CompaniesID] = @Original_CompaniesID) AND ([ProjectID] = @Original_" +
                "ProjectID) AND ([Date_] = @Original_Date_) AND ((@IsNull_StartTime = 1 AND [Star" +
                "tTime] IS NULL) OR ([StartTime] = @Original_StartTime)) AND ((@IsNull_EndTime = " +
                "1 AND [EndTime] IS NULL) OR ([EndTime] = @Original_EndTime)) AND ((@IsNull_Offse" +
                "t = 1 AND [Offset] IS NULL) OR ([Offset] = @Original_Offset)) AND ([ProjectTime]" +
                " = @Original_ProjectTime) AND ((@IsNull_WorkingDetails = 1 AND [WorkingDetails] " +
                "IS NULL) OR ([WorkingDetails] = @Original_WorkingDetails)) AND ((@IsNull_Locatio" +
                "n = 1 AND [Location] IS NULL) OR ([Location] = @Original_Location)) AND ((@IsNul" +
                "l_MealsCountry = 1 AND [MealsCountry] IS NULL) OR ([MealsCountry] = @Original_Me" +
                "alsCountry)) AND ((@IsNull_MealsAllowanceType = 1 AND [MealsAllowanceType] IS NU" +
                "LL) OR ([MealsAllowanceType] = @Original_MealsAllowanceType)) AND ([MealsAllowan" +
                "ce] = @Original_MealsAllowance) AND ((@IsNull_UnitID = 1 AND [UnitID] IS NULL) O" +
                "R ([UnitID] = @Original_UnitID)) AND ((@IsNull_TowedUnitID = 1 AND [TowedUnitID]" +
                " IS NULL) OR ([TowedUnitID] = @Original_TowedUnitID)) AND ([ProjectTimeState] = " +
                "@Original_ProjectTimeState) AND ([Deleted] = @Original_Deleted) AND ((@IsNull_Wo" +
                "rk_ = 1 AND [Work_] IS NULL) OR ([Work_] = @Original_Work_)) AND ((@IsNull_Funct" +
                "ion_ = 1 AND [Function_] IS NULL) OR ([Function_] = @Original_Function_)) AND ([" +
                "COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_ApprovedByID = 1 AND [Approved" +
                "ByID] IS NULL) OR ([ApprovedByID] = @Original_ApprovedByID)) AND ([FairWage] = @" +
                "Original_FairWage) AND ((@IsNull_JobClassType = 1 AND [JobClassType] IS NULL) OR" +
                " ([JobClassType] = @Original_JobClassType)) AND ((@IsNull_CreatedByID = 1 AND [C" +
                "reatedByID] IS NULL) OR ([CreatedByID] = @Original_CreatedByID)) AND ((@IsNull_C" +
                "reateDate = 1 AND [CreateDate] IS NULL) OR ([CreateDate] = @Original_CreateDate)" +
                ") AND ((@IsNull_UpdateByID = 1 AND [UpdateByID] IS NULL) OR ([UpdateByID] = @Ori" +
                "ginal_UpdateByID)) AND ((@IsNull_UpdateDate = 1 AND [UpdateDate] IS NULL) OR ([U" +
                "pdateDate] = @Original_UpdateDate)) AND ((@IsNull_DeletedByID = 1 AND [DeletedBy" +
                "ID] IS NULL) OR ([DeletedByID] = @Original_DeletedByID)) AND ((@IsNull_DeleteDat" +
                "e = 1 AND [DeleteDate] IS NULL) OR ([DeleteDate] = @Original_DeleteDate)));\r\nSEL" +
                "ECT ProjectTimeID, EmployeeID, CompaniesID, ProjectID, Date_, StartTime, EndTime" +
                ", Offset, ProjectTime, WorkingDetails, Location, MealsCountry, MealsAllowanceTyp" +
                "e, MealsAllowance, UnitID, TowedUnitID, ProjectTimeState, Comments, Deleted, Wor" +
                "k_, Function_, COMPANY_ID, ApprovedByID, FairWage, JobClassType, CreatedByID, Cr" +
                "eateDate, UpdateByID, UpdateDate, DeletedByID, DeleteDate FROM LFS_PROJECT_TIME " +
                "WHERE (ProjectTimeID = @ProjectTimeID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompaniesID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompaniesID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Date_", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
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
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ApprovedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApprovedByID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FairWage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FairWage", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@JobClassType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CreatedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreatedByID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CreateDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreateDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UpdateByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UpdateByID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UpdateDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UpdateDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DeletedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeletedByID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DeleteDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeleteDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectTimeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectTimeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompaniesID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompaniesID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Date_", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_EndTime", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndTime", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ApprovedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApprovedByID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ApprovedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApprovedByID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FairWage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FairWage", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_JobClassType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_JobClassType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CreatedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreatedByID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CreatedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreatedByID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CreateDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreateDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CreateDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CreateDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_UpdateByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UpdateByID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UpdateByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UpdateByID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_UpdateDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UpdateDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UpdateDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UpdateDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DeletedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeletedByID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DeletedByID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeletedByID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DeleteDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeleteDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DeleteDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DeleteDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectTimeID", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectTimeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByProjectTimeId
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Data</returns>
        public DataSet LoadByProjectTimeId(int projectTimeId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PROJECTTIMEGATEWAY_LOADBYPROJECTTIMEID", new SqlParameter("@projectTimeId", projectTimeId));
            return Data;
        }



        /// <summary>
        /// LoadByEmployeeIdPayPeriodId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="payPeriodId">payPeriodId</param>
        /// <returns>Data</returns>
        public DataSet LoadByEmployeeIdPayPeriodId(int employeeId, int payPeriodId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PROJECTTIMEGATEWAY_LOADBYEMPLOYEEIDPAYPERIODID", new SqlParameter("@employeeId", employeeId), new SqlParameter("@payPeriodId", payPeriodId));
            return Data;
        }



        /// <summary>
        /// GetLastProjectId
        /// </summary>
        /// <returns>Last ProjectID</returns>
        public int GetLastProjectTimeId()
        {
            string commandText = "SELECT MAX(ProjectTimeID) AS projectTimeId FROM LFS_PROJECT_TIME";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);

            return ((int)ExecuteScalar(command));
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int projectTimeId)
        {
            string filter = string.Format("ProjectTimeID = {0}", projectTimeId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.LabourHours.ProjectTime.ProjectTimeGateway.GetRow");
            }
        }



        /// <summary>
        /// GetEmployeeId
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>EmployeeID</returns>
        public int GetEmployeeId(int projectTimeId)
        {
            return (int)GetRow(projectTimeId)["EmployeeID"];
        }



        /// <summary>
        /// GetCompaniesId
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>CompaniesID</returns>
        public int GetCompaniesId(int projectTimeId)
        {
            return (int)GetRow(projectTimeId)["CompaniesID"];
        }



        /// <summary>
        /// GetProjectId
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>ProjectID</returns>
        public int GetProjectId(int projectTimeId)
        {
            return (int)GetRow(projectTimeId)["ProjectID"];
        }



        /// <summary>
        /// GetDate_
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Date_</returns>
        public DateTime GetDate_(int projectTimeId)
        {
            return (DateTime)GetRow(projectTimeId)["Date_"];
        }



        /// <summary>
        /// GetStartTime
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>StartTime or null</returns>
        public DateTime? GetStartTime(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("StartTime"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(projectTimeId)["StartTime"];
            }
        }



        /// <summary>
        /// GetEndTime
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>EndTime or null</returns>
        public DateTime? GetEndTime(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("EndTime"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(projectTimeId)["EndTime"];
            }
        }



        /// <summary>
        /// GetOffset
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Offset or null</returns>
        public double? GetOffset(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("Offset"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectTimeId)["Offset"];
            }
        }



        /// <summary>
        /// GetProjectTime
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>ProjectTime</returns>
        public double GetProjectTime(int projectTimeId)
        {
            return (double)GetRow(projectTimeId)["ProjectTime"];
        }



        /// <summary>
        /// GetWorkingDetails
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>WorkingDetails or EMPTY</returns>
        public string GetWorkingDetails(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("WorkingDetails"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["WorkingDetails"];
            }
        }



        /// <summary>
        /// GetLocation
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Location or EMPTY</returns>
        public string GetLocation(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("Location"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["Location"];
            }
        }



        /// <summary>
        /// GetMealsCountry
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>MealsCountry or null</returns>
        public Int64? GetMealsCountry(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("MealsCountry"))
            {
                return null;
            }
            else
            {
                return (Int64)GetRow(projectTimeId)["MealsCountry"];
            }
        }



        /// <summary>
        /// GetMealsAllowanceType
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>MealsAllowanceType or EMPTY </returns>
        public string GetMealsAllowanceType(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("MealsAllowanceType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["MealsAllowanceType"];
            }
        }



        /// <summary>
        /// GetMealsAllowance
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>MealsAllowance</returns>
        public decimal GetMealsAllowance(int projectTimeId)
        {
            return (decimal)GetRow(projectTimeId)["MealsAllowance"];
        }



        /// <summary>
        /// GetUnitId
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>UnitId or null</returns>
        public int? GetUnitId(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("UnitId"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectTimeId)["UnitId"];
            }
        }



        /// <summary>
        /// GetTowedUnitId
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>TowedUnitId or null</returns>
        public int? GetTowedUnitId(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("TowedUnitId"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectTimeId)["TowedUnitId"];
            }
        }



        /// <summary>
        /// GetProjectTimeState
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>ProjectTimeState</returns>
        public string GetProjectTimeState(int projectTimeId)
        {
            return (string)GetRow(projectTimeId)["ProjectTimeState"];
        }



        /// <summary>
        /// GetComments
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Comments or EMPTY</returns>
        public string GetComments(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["Comments"];
            }
        }



        /// <summary>
        /// GetWork
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Work_ or EMPTY</returns>
        public string GetWork(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("Work_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["Work_"];
            }
        }



        /// <summary>
        /// GetFunction
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Function_ or EMPTY</returns>
        public string GetFunction(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("Function_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["Function_"];
            }
        }



        /// <summary>
        /// GetFairWage
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>FairWage</returns>
        public bool GetFairWage(int projectTimeId)
        {
            return (bool)GetRow(projectTimeId)["FairWage"];
        }



        /// <summary>
        /// GetJobClassType
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>JobClassType or EMPTY</returns>
        public string GetJobClassType(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("JobClassType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["JobClassType"];
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



        /// <summary>
        /// Update2
        /// </summary>
        public void Update2()
        {
            DataTable tableChanges = Table.GetChanges();

            if (tableChanges == null) return;

            try
            {
                DB.Open();
                DB.BeginTransaction();

                Adapter.InsertCommand.Transaction = DB.Transaction;
                Adapter.UpdateCommand.Transaction = DB.Transaction;
                Adapter.DeleteCommand.Transaction = DB.Transaction;

                if ((tableChanges != null) && (tableChanges.Rows.Count > 0))
                {
                    Adapter.Update(tableChanges);
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






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// ExistsMealsAllowanceByEmployeIdDate
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="date_">date_</param>
        /// <param name="companyId">companyId</param>
        /// <returns>True or false</returns>
        public bool ExistsMealsAllowanceByEmployeIdDate(int employeeId, DateTime date_, int companyId)
        {
            string commandText = "SELECT COUNT(*) AS NO FROM LFS_PROJECT_TIME WHERE (EmployeeID = @employeeId) AND (Date_ = @date_) AND (MealsAllowance > 0) AND (COMPANY_ID = @companyId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@employeeId", employeeId));
            command.Parameters.Add(new SqlParameter("@date_", date_));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));

            int count = (int)ExecuteScalar(command);

            return (count > 0) ? true : false;
        }



        /// <summary>
        /// ExistsMealsAllowanceByEmployeIdStartDateLastDate
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="lastDate">lastDate</param>
        /// <param name="companyId">companyId</param>
        /// <returns>True or false</returns>
        public bool ExistsMealsAllowanceByEmployeIdStartDateLastDate(int employeeId, DateTime startDate, DateTime lastDate, int companyId)
        {
            string commandText = "SELECT COUNT(*) AS NO FROM LFS_PROJECT_TIME WHERE (EmployeeID = @employeeId) AND (Date_ Between @startDate AND @lastDate) AND (MealsAllowance > 0) AND (COMPANY_ID = @companyId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@employeeId", employeeId));
            command.Parameters.Add(new SqlParameter("@startDate", startDate));
            command.Parameters.Add(new SqlParameter("@lastDate", lastDate));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));

            int count = (int)ExecuteScalar(command);

            return (count > 0) ? true : false;
        }



        /// <summary>
        /// ExistsMealsAllowanceByProjectTimeIdEmployeIdDate
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="date_">date_</param>
        /// <param name="companyId">companyId</param>
        /// <returns>True or false</returns>
        public bool ExistsMealsAllowanceByProjectTimeIdEmployeIdDate(int projectTimeId, int employeeId, DateTime date_, int companyId)
        {
            string commandText = "SELECT COUNT(*) AS NO FROM LFS_PROJECT_TIME WHERE (EmployeeID = @employeeId) AND (Date_ = @date_) AND (MealsAllowance > 0) AND (COMPANY_ID = @companyId) AND (Deleted = 0) AND (ProjectTimeID <> @projectTimeId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@employeeId", employeeId));
            command.Parameters.Add(new SqlParameter("@date_", date_));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));
            command.Parameters.Add(new SqlParameter("@projectTimeId", projectTimeId));

            int count = (int)ExecuteScalar(command);

            return (count > 0) ? true : false;
        }



        /// <summary>
        /// ExistsMealsAllowanceByProjectTimeIdEmployeIdStartDateLastDate
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="lastDate">lastDate</param>
        /// <param name="companyId">companyId</param>
        /// <returns>True or false</returns>
        public bool ExistsMealsAllowanceByProjectTimeIdEmployeIdStartDateLastDate(int projectTimeId, int employeeId, DateTime startDate, DateTime lastDate, int companyId)
        {
            string commandText = "SELECT COUNT(*) AS NO FROM LFS_PROJECT_TIME WHERE (EmployeeID = @employeeId) AND (Date_ Between @startDate AND @lastDate) AND (MealsAllowance > 0) AND (COMPANY_ID = @companyId) AND (Deleted = 0) AND (ProjectTimeID <> @projectTimeId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@employeeId", employeeId));
            command.Parameters.Add(new SqlParameter("@startDate", startDate));
            command.Parameters.Add(new SqlParameter("@lastDate", lastDate));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));
            command.Parameters.Add(new SqlParameter("@projectTimeId", projectTimeId));

            int count = (int)ExecuteScalar(command);

            return (count > 0) ? true : false;
        }



        /// <summary>
        /// NotExistsByEmployeIdDate_StartTimeEndTime
        /// </summary>        
        /// <param name="employeeId">employeeId</param>
        /// <param name="date_">date_</param>
        /// <param name="startTime">startTime</param>
        /// <param name="companyId">companyId</param>
        /// <param name="endTime">endTime</param>
        /// <returns>True or false</returns>
        public bool NotExistsByEmployeIdDate_StartTimeEndTime(int employeeId, DateTime date_, string startTime, string endTime, int companyId)
        {
            // Verify if there are records for the date_
            string commandTextTotal = "SELECT COUNT(*) AS NO FROM LFS_PROJECT_TIME WHERE (COMPANY_ID = @companyId) AND " +
            " (Deleted = 0) AND (EmployeeID = @employeeId) AND (Date_ = @date_) ";            
            SqlCommand commandTotal = new SqlCommand(commandTextTotal, DB.Connection);
            commandTotal.Parameters.Add(new SqlParameter("@employeeId", employeeId));
            commandTotal.Parameters.Add(new SqlParameter("@date_", date_));
            commandTotal.Parameters.Add(new SqlParameter("@companyId", companyId));
            int countTotal = (int)ExecuteScalar(commandTotal);

            // If no Records for the date_
            if (countTotal == 0)
            {
                return true;
            }
            else
            {
                // If there are records for the date
                string[] startTimeSplit = startTime.Split(':');
                int startTimeHour = Int32.Parse(startTimeSplit[0].ToString());
                int startTimeMinute = Int32.Parse(startTimeSplit[1].ToString());
                DateTime newStartTime = new DateTime(date_.Year, date_.Month, date_.Day, startTimeHour, startTimeMinute, 0);

                string[] endTimeSplit = endTime.Split(':');
                int endTimeHour = Int32.Parse(endTimeSplit[0].ToString());
                int endTimeMinute = Int32.Parse(endTimeSplit[1].ToString());
                DateTime newEndTime = new DateTime(date_.Year, date_.Month, date_.Day, endTimeHour, endTimeMinute, 0);

                if (newEndTime < newStartTime)
                {
                    newEndTime = newEndTime.AddDays(1);
                }

                string commandTextCase1 = "SELECT COUNT(*) AS NO FROM LFS_PROJECT_TIME WHERE (COMPANY_ID = @companyId) AND (Deleted = 0) AND (EmployeeID = @employeeId) AND (Date_ = @date_) AND (EndTime > StartTime) AND " +
                            " ( (@startTime > StartTime AND @startTime < EndTime) OR " +
                            "   (@endTime   > StartTime AND @endTime   < EndTime) OR       " +
                            "   (@startTime > StartTime AND @endTime   < EndTime) OR " +
                            "   (@startTime < StartTime AND @endTime   > EndTime) OR " +
                            "   (@startTime = StartTime AND @endTime   = EndTime) OR " +
                            "   (@startTime < StartTime AND @endTime   = EndTime) OR " +
                            "   (@startTime = StartTime AND @endTime   > EndTime) " +
                            " )";
                SqlCommand commandCase1 = new SqlCommand(commandTextCase1, DB.Connection);
                commandCase1.Parameters.Add(new SqlParameter("@employeeId", employeeId));
                commandCase1.Parameters.Add(new SqlParameter("@date_", date_));
                commandCase1.Parameters.Add(new SqlParameter("@startTime", newStartTime));
                commandCase1.Parameters.Add(new SqlParameter("@endTime", newEndTime));
                commandCase1.Parameters.Add(new SqlParameter("@companyId", companyId));

                int countCase1 = (int)ExecuteScalar(commandCase1);
                if (countCase1 > 0)
                {
                    return false;
                }                                            
            }

            return true;
        }



       



        /// <summary>
        /// NotExistsByEmployeIdDate_StartTimeEndTimeEdit
        /// </summary>        
        /// <param name="projectTimeId">projectTimeId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="date_">date_</param>
        /// <param name="startTime">startTime</param>
        /// <param name="companyId">companyId</param>
        /// <param name="endTime">endTime</param>
        /// <returns>True or false</returns>
        public bool NotExistsByEmployeIdDate_StartTimeEndTimeEdit(int projectTimeId, int employeeId, DateTime date_, string startTime, string endTime, int companyId)
        {
            // Verify if there are records for the date_
            string commandTextTotal = "SELECT COUNT(*) AS NO FROM LFS_PROJECT_TIME WHERE (COMPANY_ID = @companyId) AND " +
            " (Deleted = 0) AND (EmployeeID = @employeeId) AND (Date_ = @date_) AND (ProjectTimeID != @projectTimeId) ";
            SqlCommand commandTotal = new SqlCommand(commandTextTotal, DB.Connection);
            commandTotal.Parameters.Add(new SqlParameter("@projectTimeId", projectTimeId));
            commandTotal.Parameters.Add(new SqlParameter("@employeeId", employeeId));
            commandTotal.Parameters.Add(new SqlParameter("@date_", date_));
            commandTotal.Parameters.Add(new SqlParameter("@companyId", companyId));
            int countTotal = (int)ExecuteScalar(commandTotal);

            // If no Records for the date_
            if (countTotal == 0)
            {
                return true;
            }
            else
            {
                // If there are records for the date
                string[] startTimeSplit = startTime.Split(':');
                int startTimeHour = Int32.Parse(startTimeSplit[0].ToString());
                int startTimeMinute = Int32.Parse(startTimeSplit[1].ToString());
                DateTime newStartTime = new DateTime(date_.Year, date_.Month, date_.Day, startTimeHour, startTimeMinute, 0);

                string[] endTimeSplit = endTime.Split(':');
                int endTimeHour = Int32.Parse(endTimeSplit[0].ToString());
                int endTimeMinute = Int32.Parse(endTimeSplit[1].ToString());
                DateTime newEndTime = new DateTime(date_.Year, date_.Month, date_.Day, endTimeHour, endTimeMinute, 0);

                if (newEndTime < newStartTime)
                {
                    newEndTime = newEndTime.AddDays(1);
                }

                string commandTextCase1 = "SELECT COUNT(*) AS NO FROM LFS_PROJECT_TIME WHERE (COMPANY_ID = @companyId) AND (Deleted = 0) AND (EmployeeID = @employeeId) AND (ProjectTimeID != @projectTimeId) AND (Date_ = @date_) AND (EndTime > StartTime) AND " +
                            " ( (@startTime > StartTime AND @startTime < EndTime) OR "+
                            "   (@endTime   > StartTime AND @endTime   < EndTime) OR       " +
                            "   (@startTime > StartTime AND @endTime   < EndTime) OR " +
                            "   (@startTime < StartTime AND @endTime   > EndTime) OR " +
                            "   (@startTime = StartTime AND @endTime   = EndTime) OR " +
                            "   (@startTime < StartTime AND @endTime   = EndTime) OR " +
                            "   (@startTime = StartTime AND @endTime   > EndTime) " +
                            " )";
                SqlCommand commandCase1 = new SqlCommand(commandTextCase1, DB.Connection);
                commandCase1.Parameters.Add(new SqlParameter("@employeeId", employeeId));
                commandCase1.Parameters.Add(new SqlParameter("@date_", date_));
                commandCase1.Parameters.Add(new SqlParameter("@startTime", newStartTime));
                commandCase1.Parameters.Add(new SqlParameter("@endTime", newEndTime));
                commandCase1.Parameters.Add(new SqlParameter("@companyId", companyId));
                commandCase1.Parameters.Add(new SqlParameter("@projectTimeId", projectTimeId));

                int countCase1 = (int)ExecuteScalar(commandCase1);
                if (countCase1 > 0)
                {
                    return false;
                }
            }

            return true;
        }



    }
}