using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules
{
    /// <summary>
    /// RuleGateway
    /// </summary>
    public class RuleGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RuleGateway()
            : base("LFS_FM_RULE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RuleGateway(DataSet data)
            : base(data, "LFS_FM_RULE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new RuleTDS();
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
            tableMapping.DataSetTable = "LFS_FM_RULE";
            tableMapping.ColumnMappings.Add("RuleID", "RuleID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("MTO", "MTO");
            tableMapping.ColumnMappings.Add("Frequency", "Frequency");
            tableMapping.ColumnMappings.Add("Alarm", "Alarm");
            tableMapping.ColumnMappings.Add("AlarmDays", "AlarmDays");
            tableMapping.ColumnMappings.Add("ServiceRequest", "ServiceRequest");
            tableMapping.ColumnMappings.Add("ServiceRequestDays", "ServiceRequestDays");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_FM_RULE] WHERE (([RuleID] = @Original_RuleID) AND ([Name] = @Original_Name) AND ([MTO] = @Original_MTO) AND ([Frequency] = @Original_Frequency) AND ([Alarm] = @Original_Alarm) AND ((@IsNull_AlarmDays = 1 AND [AlarmDays] IS NULL) OR ([AlarmDays] = @Original_AlarmDays)) AND ([ServiceRequest] = @Original_ServiceRequest) AND ((@IsNull_ServiceRequestDays = 1 AND [ServiceRequestDays] IS NULL) OR ([ServiceRequestDays] = @Original_ServiceRequestDays)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MTO", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MTO", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Frequency", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Frequency", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Alarm", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Alarm", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AlarmDays", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AlarmDays", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AlarmDays", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AlarmDays", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ServiceRequest", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceRequest", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ServiceRequestDays", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceRequestDays", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ServiceRequestDays", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceRequestDays", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_RULE] ([Name], [Description], [MTO], [Frequency], [Alarm], [AlarmDays], [ServiceRequest], [ServiceRequestDays], [Deleted], [COMPANY_ID]) VALUES (@Name, @Description, @MTO, @Frequency, @Alarm, @AlarmDays, @ServiceRequest, @ServiceRequestDays, @Deleted, @COMPANY_ID);
SELECT RuleID, Name, Description, MTO, Frequency, Alarm, AlarmDays, ServiceRequest, ServiceRequestDays, Deleted, COMPANY_ID FROM LFS_FM_RULE WHERE (RuleID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MTO", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MTO", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Frequency", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Frequency", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Alarm", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Alarm", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AlarmDays", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AlarmDays", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ServiceRequest", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceRequest", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ServiceRequestDays", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceRequestDays", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_RULE] SET [Name] = @Name, [Description] = @Description, [MTO] = @MTO, [Frequency] = @Frequency, [Alarm] = @Alarm, [AlarmDays] = @AlarmDays, [ServiceRequest] = @ServiceRequest, [ServiceRequestDays] = @ServiceRequestDays, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([RuleID] = @Original_RuleID) AND ([Name] = @Original_Name) AND ([MTO] = @Original_MTO) AND ([Frequency] = @Original_Frequency) AND ([Alarm] = @Original_Alarm) AND ((@IsNull_AlarmDays = 1 AND [AlarmDays] IS NULL) OR ([AlarmDays] = @Original_AlarmDays)) AND ([ServiceRequest] = @Original_ServiceRequest) AND ((@IsNull_ServiceRequestDays = 1 AND [ServiceRequestDays] IS NULL) OR ([ServiceRequestDays] = @Original_ServiceRequestDays)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT RuleID, Name, Description, MTO, Frequency, Alarm, AlarmDays, ServiceRequest, ServiceRequestDays, Deleted, COMPANY_ID FROM LFS_FM_RULE WHERE (RuleID = @RuleID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MTO", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MTO", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Frequency", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Frequency", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Alarm", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Alarm", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AlarmDays", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AlarmDays", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ServiceRequest", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceRequest", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ServiceRequestDays", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceRequestDays", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RuleID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MTO", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MTO", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Frequency", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Frequency", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Alarm", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Alarm", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AlarmDays", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AlarmDays", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AlarmDays", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AlarmDays", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ServiceRequest", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceRequest", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ServiceRequestDays", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceRequestDays", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ServiceRequestDays", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceRequestDays", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RuleID", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "RuleID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

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
        /// LoadAllByRuleId
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadAllByRuleId(int ruleId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_RULEGATEWAY_LOADALLBYRULEID", new SqlParameter("@ruleId", ruleId), new SqlParameter("@companyId", companyId));
            return Data;
        }




        /// <summary>
        /// LoadByRuleId
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByRuleId(int ruleId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_RULEGATEWAY_LOADBYRULEID", new SqlParameter("@ruleId", ruleId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_RULEGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int ruleId)
        {
            string filter = string.Format("RuleID = {0}", ruleId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules.RuleGateway.GetRow");
            }
        }



        /// <summary>
        /// GetName. If not exists, raise an exception.
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Name or EMPTY</returns>
        public string GetName(int ruleId)
        {
            return (string)GetRow(ruleId)["Name"];            
        }



        /// <summary>
        /// GetDescription. If not exists, raise an exception.
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Description or EMPTY</returns>
        public string GetDescription(int ruleId)
        {
            if (GetRow(ruleId).IsNull("Description"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(ruleId)["Description"];
            }
        }



        /// <summary>
        /// GetMto. 
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>MTO</returns>
        public bool GetMto(int ruleId)
        {
            return (bool)GetRow(ruleId)["MTO"];
        }



        /// <summary>
        /// GetFrequency. If not exists, raise an exception.
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Frequency or EMPTY</returns>
        public string GetFrequency(int ruleId)
        {
            return (string)GetRow(ruleId)["Frequency"];            
        }



        /// <summary>
        /// GetAlarm. 
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Alarm</returns>
        public bool GetAlarm(int ruleId)
        {
            return (bool)GetRow(ruleId)["Alarm"];
        }



        /// <summary>
        /// GetAlarmDays. If not exists, raise an exception.
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>AlarmDays o EMPTY</returns>
        public int? GetAlarmDays(int ruleId)
        {
            if (GetRow(ruleId).IsNull("AlarmDays"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(ruleId)["AlarmDays"];
            }
        }



        /// <summary>
        /// GetServiceRequest. 
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>ServiceRequest</returns>
        public bool GetServiceRequest(int ruleId)
        {
            return (bool)GetRow(ruleId)["ServiceRequest"];
        }



        /// <summary>
        /// GetServiceRequestDays. If not exists, raise an exception.
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>ServiceRequestDays o EMPTY</returns>
        public int? GetServiceRequestDays(int ruleId)
        {
            if (GetRow(ruleId).IsNull("ServiceRequestDays"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(ruleId)["ServiceRequestDays"];
            }
        }



        /// <summary>
        /// GetDeleted. 
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>True if the section is deleted</returns>
        public bool GetDeleted(int ruleId)
        {
            return (bool)GetRow(ruleId)["Deleted"];
        }



        /// <summary>
        /// GetCompanyId. 
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>CompanyId</returns>
        public int GetCompanyId(int ruleId)
        {
            return (int)GetRow(ruleId)["COMPANY_ID"];
        }





                       
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //
        
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="mto">mto</param>
        /// <param name="frequency">frequency</param>
        /// <param name="alarm">alarm</param>
        /// <param name="alarmDays">alarmDays</param>
        /// <param name="serviceRequest">serviceRequest</param>
        /// <param name="serviceRequestDays">serviceRequestDays</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <returns>RuleID</returns>
        public int Insert(string name, string description, bool mto, string frequency, bool alarm, int? alarmDays, bool serviceRequest, int? serviceRequestDays, bool deleted, int companyId)
        {
            SqlParameter nameParameter = new SqlParameter("Name", name);
            SqlParameter descriptionParameter = (description != "") ? new SqlParameter("Description", description) : new SqlParameter("Description", DBNull.Value);
            SqlParameter mtoParameter = new SqlParameter("MTO", mto);
            SqlParameter frequencyParameter = new SqlParameter("Frequency", frequency);
            SqlParameter alarmParameter = new SqlParameter("Alarm", alarm);
            SqlParameter alarmDaysParameter = (alarmDays.HasValue) ? new SqlParameter("AlarmDays", (int)alarmDays) : new SqlParameter("AlarmDays", DBNull.Value);
            SqlParameter serviceRequestParameter = new SqlParameter("ServiceRequest", serviceRequest);
            SqlParameter serviceRequestDaysParameter = (serviceRequestDays.HasValue) ? new SqlParameter("ServiceRequestDays", (int)serviceRequestDays) : new SqlParameter("ServiceRequestDays", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_FM_RULE] ([Name], [Description], [MTO], [Frequency], [Alarm], [AlarmDays], [ServiceRequest], [ServiceRequestDays], [Deleted], [COMPANY_ID]) VALUES (@Name, @Description, @MTO, @Frequency, @Alarm, @AlarmDays, @ServiceRequest, @ServiceRequestDays, @Deleted, @COMPANY_ID); SELECT RuleID FROM LFS_FM_RULE WHERE (RuleID = SCOPE_IDENTITY())";

            int ruleId = (int)ExecuteScalar(command, nameParameter, descriptionParameter, mtoParameter, frequencyParameter, alarmParameter, alarmDaysParameter, serviceRequestParameter, serviceRequestDaysParameter, deletedParameter, companyIdParameter);

            return ruleId;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="mto">mto</param>
        /// <param name="frequency">frequency</param>
        /// <param name="alarm">alarm</param>
        /// <param name="alarmDays">alarmDays</param>
        /// <param name="serviceRequest">serviceRequest</param>
        /// <param name="serviceRequestDays">serviceRequestDays</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Update(int originalRuleId, string newName, string newDescription, bool newMto, string newFrequency, bool newAlarm, int? newAlarmDays, bool newServiceRequest, int? newServiceRequestDays, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalRuleIdParameter = new SqlParameter("Original_RuleId", originalRuleId);

            SqlParameter newRuleIdParameter = new SqlParameter("RuleID", originalRuleId);
            SqlParameter newNameParameter = new SqlParameter("Name", newName);
            SqlParameter newDescriptionParameter = (newDescription != "") ? new SqlParameter("Description", newDescription) : new SqlParameter("Description", DBNull.Value);
            SqlParameter newMtoParameter = new SqlParameter("MTO", newMto);
            SqlParameter newFrequencyParameter = new SqlParameter("Frequency", newFrequency);
            SqlParameter newAlarmParameter = new SqlParameter("Alarm", newAlarm);
            SqlParameter newAlarmDaysParameter = (newAlarmDays.HasValue) ? new SqlParameter("AlarmDays", (int)newAlarmDays) : new SqlParameter("AlarmDays", DBNull.Value);
            SqlParameter newServiceRequestParameter = new SqlParameter("ServiceRequest", newServiceRequest);
            SqlParameter newServiceRequestDaysParameter = (newServiceRequestDays.HasValue) ? new SqlParameter("ServiceRequestDays", (int)newServiceRequestDays) : new SqlParameter("ServiceRequestDays", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_FM_RULE] " +
                             "SET [Name] = @Name, [Description] = @Description,  " +
                             "[MTO] = @MTO, [Frequency] = @Frequency, [Alarm] = @Alarm, [AlarmDays] = @AlarmDays, " +
                             "[ServiceRequest] = @ServiceRequest, [ServiceRequestDays] = @ServiceRequestDays, " +
                             "[Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID " +
                             "WHERE ([RuleID] = @Original_RuleID)";

            int rowsAffected = (int)ExecuteNonQuery(command, newNameParameter, newDescriptionParameter, newMtoParameter, newFrequencyParameter, newAlarmParameter, newAlarmDaysParameter, newServiceRequestParameter, newServiceRequestDaysParameter, newDeletedParameter, newCompanyIdParameter, originalRuleIdParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// delete
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int ruleId, int companyId)
        {
            SqlParameter ruleIdParameter = new SqlParameter("RuleID", ruleId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_RULE] SET  [Deleted] = @Deleted WHERE (([RuleID] = @RuleID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, ruleIdParameter, companyIdParameter, deletedParameter);
            
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// GetLastRuleId
        /// </summary>
        /// <returns>Last RuleID</returns>
        public int GetLastRuleId()
        {
            string commandText = "SELECT MAX(RuleID) AS ruleId FROM LFS_FM_RULE";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);

            return ((int)ExecuteScalar(command));
        }

       
 
    }
}