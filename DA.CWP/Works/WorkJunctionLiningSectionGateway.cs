using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkJunctionLiningSectionGateway
    /// </summary>
    public class WorkJunctionLiningSectionGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkJunctionLiningSectionGateway()
            : base("LFS_WORK_JUNCTIONLINING_SECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkJunctionLiningSectionGateway(DataSet data)
            : base(data, "LFS_WORK_JUNCTIONLINING_SECTION")
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
            tableMapping.DataSetTable = "LFS_WORK_JUNCTIONLINING_SECTION";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("NumLats", "NumLats");
            tableMapping.ColumnMappings.Add("NotLinedYet", "NotLinedYet");
            tableMapping.ColumnMappings.Add("AllMeasured", "AllMeasured");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("IssueWithLaterals", "IssueWithLaterals");
            tableMapping.ColumnMappings.Add("NotMeasuredYet", "NotMeasuredYet");
            tableMapping.ColumnMappings.Add("NotDeliveredYet", "NotDeliveredYet");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("TrafficControl", "TrafficControl");
            tableMapping.ColumnMappings.Add("TrafficControlDetails", "TrafficControlDetails");
            tableMapping.ColumnMappings.Add("StandardBypass", "StandardBypass");
            tableMapping.ColumnMappings.Add("StandardBypassComments", "StandardBypassComments");
            tableMapping.ColumnMappings.Add("AvailableToLine", "AvailableToLine");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_WORK_JUNCTIONLINING_SECTION] WHERE (([WorkID] = @Original_WorkID) AND ([NumLats] = @Original_NumLats) AND ([NotLinedYet] = @Original_NotLinedYet) AND ([AllMeasured] = @Original_AllMeasured) AND ([Deleted] = @Original_Deleted) AND ([IssueWithLaterals] = @Original_IssueWithLaterals) AND ([NotMeasuredYet] = @Original_NotMeasuredYet) AND ([NotDeliveredYet] = @Original_NotDeliveredYet) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_TrafficControl = 1 AND [TrafficControl] IS NULL) OR ([TrafficControl] = @Original_TrafficControl)) AND ([StandardBypass] = @Original_StandardBypass) AND ([AvailableToLine] = @Original_AvailableToLine))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NumLats", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NumLats", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NotLinedYet", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotLinedYet", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AllMeasured", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AllMeasured", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueWithLaterals", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueWithLaterals", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NotMeasuredYet", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotMeasuredYet", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NotDeliveredYet", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotDeliveredYet", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TrafficControl", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TrafficControl", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TrafficControl", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TrafficControl", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StandardBypass", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StandardBypass", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AvailableToLine", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AvailableToLine", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_JUNCTIONLINING_SECTION] ([WorkID], [NumLats], [NotLinedYet], [AllMeasured], [Deleted], [IssueWithLaterals], [NotMeasuredYet], [NotDeliveredYet], [COMPANY_ID], [TrafficControl], [TrafficControlDetails], [StandardBypass], [StandardBypassComments], [AvailableToLine]) VALUES (@WorkID, @NumLats, @NotLinedYet, @AllMeasured, @Deleted, @IssueWithLaterals, @NotMeasuredYet, @NotDeliveredYet, @COMPANY_ID, @TrafficControl, @TrafficControlDetails, @StandardBypass, @StandardBypassComments, @AvailableToLine);
SELECT WorkID, NumLats, NotLinedYet, AllMeasured, Deleted, IssueWithLaterals, NotMeasuredYet, NotDeliveredYet, COMPANY_ID, TrafficControl, TrafficControlDetails, StandardBypass, StandardBypassComments, AvailableToLine FROM LFS_WORK_JUNCTIONLINING_SECTION WHERE (WorkID = @WorkID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NumLats", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NumLats", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NotLinedYet", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotLinedYet", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AllMeasured", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AllMeasured", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueWithLaterals", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueWithLaterals", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NotMeasuredYet", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotMeasuredYet", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NotDeliveredYet", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotDeliveredYet", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TrafficControl", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TrafficControl", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TrafficControlDetails", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TrafficControlDetails", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StandardBypass", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StandardBypass", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StandardBypassComments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StandardBypassComments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AvailableToLine", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AvailableToLine", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_WORK_JUNCTIONLINING_SECTION] SET [WorkID] = @WorkID, [NumLats] = @NumLats, [NotLinedYet] = @NotLinedYet, [AllMeasured] = @AllMeasured, [Deleted] = @Deleted, [IssueWithLaterals] = @IssueWithLaterals, [NotMeasuredYet] = @NotMeasuredYet, [NotDeliveredYet] = @NotDeliveredYet, [COMPANY_ID] = @COMPANY_ID, [TrafficControl] = @TrafficControl, [TrafficControlDetails] = @TrafficControlDetails, [StandardBypass] = @StandardBypass, [StandardBypassComments] = @StandardBypassComments, [AvailableToLine] = @AvailableToLine WHERE (([WorkID] = @Original_WorkID) AND ([NumLats] = @Original_NumLats) AND ([NotLinedYet] = @Original_NotLinedYet) AND ([AllMeasured] = @Original_AllMeasured) AND ([Deleted] = @Original_Deleted) AND ([IssueWithLaterals] = @Original_IssueWithLaterals) AND ([NotMeasuredYet] = @Original_NotMeasuredYet) AND ([NotDeliveredYet] = @Original_NotDeliveredYet) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_TrafficControl = 1 AND [TrafficControl] IS NULL) OR ([TrafficControl] = @Original_TrafficControl)) AND ([StandardBypass] = @Original_StandardBypass) AND ([AvailableToLine] = @Original_AvailableToLine));
SELECT WorkID, NumLats, NotLinedYet, AllMeasured, Deleted, IssueWithLaterals, NotMeasuredYet, NotDeliveredYet, COMPANY_ID, TrafficControl, TrafficControlDetails, StandardBypass, StandardBypassComments, AvailableToLine FROM LFS_WORK_JUNCTIONLINING_SECTION WHERE (WorkID = @WorkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NumLats", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NumLats", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NotLinedYet", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotLinedYet", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AllMeasured", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AllMeasured", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IssueWithLaterals", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueWithLaterals", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NotMeasuredYet", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotMeasuredYet", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NotDeliveredYet", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotDeliveredYet", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TrafficControl", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TrafficControl", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@TrafficControlDetails", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TrafficControlDetails", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StandardBypass", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StandardBypass", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StandardBypassComments", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StandardBypassComments", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AvailableToLine", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AvailableToLine", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NumLats", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NumLats", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NotLinedYet", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotLinedYet", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AllMeasured", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AllMeasured", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IssueWithLaterals", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IssueWithLaterals", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NotMeasuredYet", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotMeasuredYet", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NotDeliveredYet", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotDeliveredYet", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_TrafficControl", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TrafficControl", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_TrafficControl", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "TrafficControl", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StandardBypass", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StandardBypass", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AvailableToLine", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AvailableToLine", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

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
        public DataSet LoadByWorkId(int workId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKJUNCTIONLININGSECTIONGATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadTop1ByProjectIdAssetIdWorkType
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadTop1ByProjectIdAssetIdWorkType(int projectId, int assetId, string workType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKJUNCTIONLININGSECTIONGATEWAY_LOADTOP1BYPROJECTIDASSETIDWORKTYPE", new SqlParameter("@projectId", projectId), new SqlParameter("@assetId", assetId), new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetWorkId. If not exists, raise an exception.
        /// </summary>
        /// <returns>GetWorkId or EMPTY</returns>
        public int GetWorkIdTop1()
        {
            return (int)GetRowTop1()["WorkID"];
        }



       
        /// <summary>
        /// GetNumLats. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NumLats</returns>
        public int GetNumLats(int workId)
        {
            return (int)GetRow(workId)["NumLats"];
        }



        /// <summary>
        /// GetNotLinedYet. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NumLats</returns>
        public int GetNotLinedYet(int workId)
        {
            return (int)GetRow(workId)["NotLinedYet"];
        }



        /// <summary>
        /// GetAllMeasured. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TRUE if project deleted</returns>
        public bool GetAllMeasured(int workId)
        {
            return (bool)GetRow(workId)["AllMeasured"];
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
        /// GetIssueWithLaterals
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        public string GetIssueWithLaterals(int workId)
        {
            if (GetRow(workId).IsNull("IssueWithLaterals"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["IssueWithLaterals"];
            }
        }



        /// <summary>
        /// GetNotMeasuredYet. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NotMeasuredYet</returns>
        public int GetNotMeasuredYet(int workId)
        {
            return (int)GetRow(workId)["NotMeasuredYet"];
        }



        /// <summary>
        /// GetNotDeliveredYet. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NotDeliveredYet</returns>
        public int GetNotDeliveredYet(int workId)
        {
            return (int)GetRow(workId)["NotDeliveredYet"];
        }



        /// <summary>
        /// GetCompanyID. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CpmpanyId - CompaniesId</returns>
        public int GetCompanyID(int workId)
        {
            return (int)GetRow(workId)["COMPANY_ID"];
        }



        /// <summary>
        /// GetTrafficControl
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        public string GetTrafficControl(int workId)
        {
            if (GetRow(workId).IsNull("TrafficControl"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["TrafficControl"];
            }
        }



        /// <summary>
        /// GetTrafficControlDetails
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        public string GetTrafficControlDetails(int workId)
        {
            if (GetRow(workId).IsNull("TrafficControlDetails"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["TrafficControlDetails"];
            }
        }



        /// <summary>
        /// GetStandardBypass
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        public bool GetStandardBypass(int workId)
        {
            return (bool)GetRow(workId)["StandardBypass"];
        }



        /// <summary>
        /// GetStandardBypassComments
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        public string GetStandardBypassComments(int workId)
        {
            if (GetRow(workId).IsNull("StandardBypassComments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["StandardBypassComments"];
            }
        }



        /// <summary>
        /// GetAvailableToLine. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>AvailableToLine</returns>
        public int GetAvailableToLine(int workId)
        {
            return (int)GetRow(workId)["AvailableToLine"];
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Works.JunctionLiningSectionGateway.GetRow");
            }
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <returns>DataRow</returns>
        public DataRow GetRowTop1()
        {
            if (Table.Select().Length > 0)
            {
                DataRow row = Table.Select()[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.WorkFullLengthLiningGateway.GetRow");
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="numLats">numLats</param>
        /// <param name="notLinedYet">notLinedYet</param>
        /// <param name="allMeasured">allMeasured</param>
        /// <param name="issueWithLaterals">issueWithLaterals</param>
        /// <param name="notMeasuredYet">notMeasuredYet</param>
        /// <param name="notDeliveredYet">notDeliveredYet</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="trafficControl">trafficControl</param>
        /// <param name="trafficControlDetails">trafficControlDetails</param>
        /// <param name="standardBypass">standardBypass</param>
        /// <param name="standardBypassComments">standardBypassComments</param>
        /// <param name="availableToLine">availableToLine</param>
        /// <returns></returns>
        public int Insert(int workId, int numLats, int notLinedYet, bool allMeasured, string issueWithLaterals, int notMeasuredYet, int notDeliveredYet, bool deleted, int companyId, string trafficControl, string trafficControlDetails, bool standardBypass, string standardBypassComments, int availableToLine)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter numLatsParameter = new SqlParameter("NumLats", numLats);
            SqlParameter notLinedYetParameter = new SqlParameter("NotLinedYet", notLinedYet);
            SqlParameter allMeasuredParameter = new SqlParameter("AllMeasured", allMeasured);
            SqlParameter issueWithLateralsParameter = new SqlParameter("IssueWithLaterals", issueWithLaterals);
            SqlParameter notMeasuredYetParameter = new SqlParameter("NotMeasuredYet", notMeasuredYet);
            SqlParameter notDeliveredYetParameter = new SqlParameter("NotDeliveredYet", notDeliveredYet);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter trafficControlParameter = (trafficControl.Trim() != "") ? new SqlParameter("TrafficControl", trafficControl.Trim()) : new SqlParameter("TrafficControl", DBNull.Value);
            SqlParameter trafficControlDetailsParameter = (trafficControlDetails.Trim() != "") ? new SqlParameter("TrafficControlDetails", trafficControlDetails.Trim()) : new SqlParameter("TrafficControlDetails", DBNull.Value);
            SqlParameter standardBypassParameter = new SqlParameter("StandardBypass", standardBypass);
            SqlParameter standardBypassCommentsParameter = (standardBypassComments.Trim() != "") ? new SqlParameter("StandardBypassComments", standardBypassComments.Trim()) : new SqlParameter("StandardBypassComments", DBNull.Value);
            SqlParameter availableToLineParameter = new SqlParameter("AvailableToLine", availableToLine);

            string command = "INSERT INTO [dbo].[LFS_WORK_JUNCTIONLINING_SECTION] ([WorkID], [NumLats], [NotLinedYet], [AllMeasured], [Deleted], [IssueWithLaterals], [NotMeasuredYet], [NotDeliveredYet], [COMPANY_ID], [TrafficControl], [TrafficControlDetails], [StandardBypass], [StandardBypassComments], [AvailableToLine]) VALUES (@WorkID, @NumLats, @NotLinedYet, @AllMeasured, @Deleted, @IssueWithLaterals, @NotMeasuredYet, @NotDeliveredYet, @COMPANY_ID, @TrafficControl, @TrafficControlDetails, @StandardBypass, @StandardBypassComments, @AvailableToLine)";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, numLatsParameter, notLinedYetParameter, allMeasuredParameter, issueWithLateralsParameter, notMeasuredYetParameter, notDeliveredYetParameter, deletedParameter, companyIdParameter, trafficControlParameter, trafficControlDetailsParameter, standardBypassParameter, standardBypassCommentsParameter, availableToLineParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Delete a work (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalWorkId, int originalCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("@Original_WorkID", originalWorkId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_JUNCTIONLINING_SECTION] SET  [Deleted] = @Deleted  " +
                             " WHERE (([WorkID] = @Original_WorkID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery( command, originalWorkIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="originalNumLats">originalNumLats</param>
        /// <param name="originalNotLinedYet">originalNotLinedYet</param>
        /// <param name="originalAllMeasured">originalAllMeasured</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalIssueWithLaterals">originalIssueWithLaterals</param>
        /// <param name="originalNotMeasuredYet">originalNotMeasuredYet</param>
        /// <param name="originalNotDeliveredYet">originalNotDeliveredYet</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalTrafficControl">originalTrafficControl</param>
        /// <param name="originalTrafficControlDetails">originalTrafficControlDetails</param>
        /// <param name="originalStandardBypass">originalStandardBypass</param>
        /// <param name="originalStandardBypassComments">originalStandardBypassComments</param>
        /// <param name="originalAvailableToLine">originalAvailableToLine</param>
        /// 
        /// <param name="newNumLats">newNumLats</param>
        /// <param name="newNotLinedYet">newNotLinedYet</param>
        /// <param name="newAllMeasured">newAllMeasured</param>
        /// <param name="newIssueWithLaterals">newIssueWithLaterals</param>
        /// <param name="newNotMeasuredYet">newNotMeasuredYet</param>
        /// <param name="newNotDeliveredYet">newNotDeliveredYet</param>
        /// <param name="newTrafficControl">newTrafficControl</param>
        /// <param name="newTrafficControlDetails">newTrafficControlDetails</param>
        /// <param name="newStandardBypass">newStandardBypass</param>
        /// <param name="newStandardBypassComments">newStandardBypassComments</param>
        /// <param name="newAvailableToLine">newAvailableToLine</param>
        /// <returns></returns>
        public int Update(int workId, int originalNumLats, int originalNotLinedYet, bool originalAllMeasured, bool originalDeleted, string originalIssueWithLaterals, int originalNotMeasuredYet, int originalNotDeliveredYet, int originalCompanyId, string originalTrafficControl, string originalTrafficControlDetails, bool originalStandardBypass, string originalStandardBypassComments, int originalAvailableToLine,  int newNumLats, int newNotLinedYet, bool newAllMeasured, string newIssueWithLaterals, int newNotMeasuredYet, int newNotDeliveredYet, string newTrafficControl, string newTrafficControlDetails, bool newStandardBypass, string newStandardBypassComments, int newAvailableToLine)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", workId);
            //SqlParameter originalSubAreaParameter = (originalSubArea.Trim() != "") ? new SqlParameter("Original_SubArea", originalSubArea.Trim()) : new SqlParameter("Original_SubArea", DBNull.Value);
            //SqlParameter originalNumLatsParameter = new SqlParameter("Original_NumLats", originalNumLats);
            //SqlParameter originalNotLinedYetParameter = new SqlParameter("Original_NotLinedYet", originalNotLinedYet);
            //SqlParameter originalAllMeasuredParameter = new SqlParameter("Original_AllMeasured", originalAllMeasured);
            //SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            //SqlParameter originalIssueWithLateralsParameter = (originalIssueWithLaterals.Trim() != "") ? new SqlParameter("Original_IssueWithLaterals", originalIssueWithLaterals.Trim()) : new SqlParameter("Original_IssueWithLaterals", DBNull.Value);
            //SqlParameter originalNotMeasuredYetParameter = new SqlParameter("Original_NotMeasuredYet", originalNotMeasuredYet);
            //SqlParameter originalNotDeliveredYetParameter = new SqlParameter("Original_NotDeliveredYet", originalNotDeliveredYet);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            //SqlParameter originalTrafficControlParameter = (originalTrafficControl.Trim() != "") ? new SqlParameter("Original_TrafficControl", originalTrafficControl.Trim()) : new SqlParameter("Original_TrafficControl", DBNull.Value);
            //SqlParameter originalTrafficControlDetailsParameter = (originalTrafficControlDetails.Trim() != "") ? new SqlParameter("Original_TrafficControlDetails", originalTrafficControlDetails.Trim()) : new SqlParameter("Original_TrafficControlDetails", DBNull.Value);
            //SqlParameter originalStandardBypassParameter = new SqlParameter("Original_StandardBypass", originalStandardBypass);
            //SqlParameter originalStandardBypassCommentsParameter = (originalStandardBypassComments.Trim() != "") ? new SqlParameter("Original_StandardBypassComments", originalStandardBypassComments.Trim()) : new SqlParameter("Original_StandardBypassComments", DBNull.Value);
            //SqlParameter originalAvailableToLineParameter = new SqlParameter("Original_AvailableToLine", originalAvailableToLine);

            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter newNumLatsParameter = new SqlParameter("NumLats", newNumLats);
            SqlParameter newNotLinedYetParameter = new SqlParameter("NotLinedYet", newNotLinedYet);
            SqlParameter newAllMeasuredParameter = new SqlParameter("AllMeasured", newAllMeasured);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", originalDeleted);
            SqlParameter newIssueWithLateralsParameter = (newIssueWithLaterals.Trim() != "") ? new SqlParameter("IssueWithLaterals", newIssueWithLaterals.Trim()) : new SqlParameter("IssueWithLaterals", DBNull.Value);
            SqlParameter newNotMeasuredYetParameter = new SqlParameter("NotMeasuredYet", newNotMeasuredYet);
            SqlParameter newNotDeliveredYetParameter = new SqlParameter("NotDeliveredYet", newNotDeliveredYet);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", originalCompanyId);
            SqlParameter newTrafficControlParameter = (newTrafficControl.Trim() != "") ? new SqlParameter("TrafficControl", newTrafficControl.Trim()) : new SqlParameter("TrafficControl", DBNull.Value);
            SqlParameter newTrafficControlDetailsParameter = (newTrafficControlDetails.Trim() != "") ? new SqlParameter("TrafficControlDetails", newTrafficControlDetails.Trim()) : new SqlParameter("TrafficControlDetails", DBNull.Value);
            SqlParameter newStandardBypassParameter = new SqlParameter("StandardBypass", newStandardBypass);
            SqlParameter newStandardBypassCommentsParameter = (newStandardBypassComments.Trim() != "") ? new SqlParameter("StandardBypassComments", newStandardBypassComments.Trim()) : new SqlParameter("StandardBypassComments", DBNull.Value);
            SqlParameter newAvailableToLineParameter = new SqlParameter("AvailableToLine", newAvailableToLine);

            string command = "UPDATE [dbo].[LFS_WORK_JUNCTIONLINING_SECTION] " +
                             "SET [WorkID] = @WorkID, [NumLats] = @NumLats, [NotLinedYet] = @NotLinedYet, "+
                             " [AllMeasured] = @AllMeasured, [Deleted] = @Deleted, [IssueWithLaterals] = @IssueWithLaterals, " + 
                             " [NotMeasuredYet] = @NotMeasuredYet, [NotDeliveredYet] = @NotDeliveredYet, "+
                             " [COMPANY_ID] = @COMPANY_ID, [TrafficControl] = @TrafficControl, "+
                             " [TrafficControlDetails] = @TrafficControlDetails, " +
                             " [StandardBypass] = @StandardBypass, [StandardBypassComments] = @StandardBypassComments, " +
                             " [AvailableToLine] = @AvailableToLine "+
                             " WHERE ([WorkID] = @Original_WorkID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID)";

            //int rowsAffected = (int)ExecuteNonQuery( command, newWorkIdParameter, newSubAreaParameter, newNumLatsParameter, newNotLinedYetParameter, newAllMeasuredParameter, newDeletedParameter, newIssueWithLateralsParameter, newNotMeasuredYetParameter, newNotDeliveredYetParameter, newCompanyIdParameter, newTrafficControlParameter, newTrafficControlDetailsParameter, newStandardBypassParameter, newStandardBypassCommentsParameter, originalWorkIdParameter, originalSubAreaParameter, originalNumLatsParameter, originalNotDeliveredYetParameter, originalAllMeasuredParameter, originalDeletedParameter, originalIssueWithLateralsParameter, originalNotMeasuredYetParameter, originalNotDeliveredYetParameter, originalCompanyIdParameter, originalTrafficControlParameter, originalTrafficControlDetailsParameter, originalStandardBypassParameter, originalStandardBypassCommentsParameter, originalAvailableToLineParameter, newAvailableToLineParameter);
            int rowsAffected = (int)ExecuteNonQuery(command, originalCompanyIdParameter, newWorkIdParameter, newNumLatsParameter, newNotLinedYetParameter, newAllMeasuredParameter, newDeletedParameter, newIssueWithLateralsParameter, newNotMeasuredYetParameter, newNotDeliveredYetParameter, newCompanyIdParameter, newTrafficControlParameter, newTrafficControlDetailsParameter, newStandardBypassParameter, newStandardBypassCommentsParameter, originalWorkIdParameter, newAvailableToLineParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}
