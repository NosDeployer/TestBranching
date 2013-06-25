using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Units
{
    /// <summary>
    /// UnitInformationChecklistDetailsGateway
    /// </summary>
    public class UnitInformationChecklistDetailsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public UnitInformationChecklistDetailsGateway()
            : base("ChecklistDetails")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public UnitInformationChecklistDetailsGateway(DataSet data)
            : base(data, "ChecklistDetails")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitInformationTDS();
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
            tableMapping.DataSetTable = "ChecklistDetails";
            tableMapping.ColumnMappings.Add("RuleID", "RuleID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("Frequency", "Frequency");
            tableMapping.ColumnMappings.Add("LastService", "LastService");
            tableMapping.ColumnMappings.Add("NextDue", "NextDue");
            tableMapping.ColumnMappings.Add("Done", "Done");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
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
        /// LoadByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByUnitId(int unitId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITINFORMATIONCHECKLISTDETAILSGATEWAY_LOADBYUNITID", new SqlParameter("@unitId", unitId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByUnitIdWithoutInProgressRules
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByUnitIdWithoutInProgressRules(int unitId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITINFORMATIONCHECKLISTDETAILSGATEWAY_LOADBYUNITIDWITHOUTINPROGRESSRULES", new SqlParameter("@unitId", unitId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Row</returns>
        public DataRow GetRow(int ruleId)
        {
            string filter = string.Format("(RuleID  = {0})", ruleId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Units.UnitInformationChecklistDetailsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetLastService
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>LastService or EMPTY</returns>
        public DateTime? GetLastService(int ruleId)
        {
            if (GetRow(ruleId).IsNull("LastService"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(ruleId)["LastService"];
            }
        }



        /// <summary>
        /// GetLastService Original
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Original LastService or EMPTY</returns>
        public DateTime? GetLastServiceOriginal(int ruleId)
        {
            if (GetRow(ruleId).IsNull(Table.Columns["LastService"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(ruleId)["LastService", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetNextDue
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>NextDue or EMPTY</returns>
        public DateTime? GetNextDue(int ruleId)
        {
            if (GetRow(ruleId).IsNull("NextDue"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(ruleId)["NextDue"];
            }
        }



        /// <summary>
        /// GetNextDue Original
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Original NextDue or EMPTY</returns>
        public DateTime? GetNextDueOriginal(int ruleId)
        {
            if (GetRow(ruleId).IsNull(Table.Columns["NextDue"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(ruleId)["NextDue", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDone
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Done</returns>
        public bool GetDone(int ruleId)
        {
            return (bool)GetRow(ruleId)["Done"];
        }



        /// <summary>
        /// GetDone Original
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Original Done or EMPTY</returns>
        public bool GetDoneOriginal(int ruleId)
        {
            return (bool)GetRow(ruleId)["Done", DataRowVersion.Original];
        }



        /// <summary>
        /// GetState
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>State or EMPTY</returns>
        public string GetState(int ruleId)
        {
            if (GetRow(ruleId).IsNull("State"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(ruleId)["State"];
            }
        }



        /// <summary>
        /// GetState Original
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Original State or EMPTY</returns>
        public string GetStateOriginal(int ruleId)
        {
            if (GetRow(ruleId).IsNull(Table.Columns["State"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(ruleId)["State", DataRowVersion.Original];
            }
        }



    }
}


