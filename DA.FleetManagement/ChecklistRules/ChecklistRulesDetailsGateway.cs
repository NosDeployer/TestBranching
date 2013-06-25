using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules
{
    /// <summary>
    /// ChecklistRulesDetailsGateway
    /// </summary>
    public class ChecklistRulesDetailsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ChecklistRulesDetailsGateway()
            : base("ChecklistRulesDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ChecklistRulesDetailsGateway(DataSet data)
            : base(data, "ChecklistRulesDetails")
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
            tableMapping.DataSetTable = "ChecklistRulesDetails";
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
        /// LoadByRuleId
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByRuleId(int ruleId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_CHECKLISTRULESDETAILSGATEWAY_LOADBYRULEID", new SqlParameter("@ruleId", ruleId), new SqlParameter("@companyId", companyId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules.ChecklistRulesGateway.GetRow");
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
        /// GetNameOriginal Original
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Original Name or EMPTY</returns>
        public string GetNameOriginal(int ruleId)
        {
            if (GetRow(ruleId).IsNull(Table.Columns["Name"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(ruleId)["Name", DataRowVersion.Original];
            }
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
        /// GetDescriptionOriginal
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Original Description or EMPTY</returns>
        public string GetDescriptionOriginal(int ruleId)
        {
            if (GetRow(ruleId).IsNull(Table.Columns["Description"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(ruleId)["Description", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMto
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>MTO</returns>
        public bool GetMto(int ruleId)
        {
            return (bool)GetRow(ruleId)["MTO"];
        }



        /// <summary>
        /// GetMtoOriginal
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Original Mto or EMPTY</returns>
        public bool GetMtoOriginal(int ruleId)
        {
            return (bool)GetRow(ruleId)["MTO", DataRowVersion.Original];            
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
        /// GetFrequencyOriginal
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Original Frequency or EMPTY</returns>
        public string GetFrequencyOriginal(int ruleId)
        {
            return (string)GetRow(ruleId)["Frequency", DataRowVersion.Original];
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
        /// GetAlarmOriginal
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Original Alarm or EMPTY</returns>
        public bool GetAlarmOriginal(int ruleId)
        {
            return (bool)GetRow(ruleId)["Alarm", DataRowVersion.Original];
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
        /// GetAlarmDaysOriginal
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Original AlarmDays or EMPTY</returns>
        public string GetAlarmDaysOriginal(int ruleId)
        {
            if (GetRow(ruleId).IsNull(Table.Columns["AlarmDays"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(ruleId)["AlarmDays", DataRowVersion.Original];
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
        /// GetServiceRequestOriginal
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Original ServiceRequest or EMPTY</returns>
        public bool GetServiceRequestOriginal(int ruleId)
        {
            return (bool)GetRow(ruleId)["ServiceRequest", DataRowVersion.Original];
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
        /// GetServiceRequestDaysOriginal
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Original GetServiceRequestDaysOriginal or EMPTY</returns>
        public string GetServiceRequestDaysOriginal(int ruleId)
        {
            if (GetRow(ruleId).IsNull(Table.Columns["ServiceRequestDays"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(ruleId)["ServiceRequestDays", DataRowVersion.Original];
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



    }
}
