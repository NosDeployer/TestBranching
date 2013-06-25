using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardChecklistAlarmsGateway
    /// </summary>
    public class DashboardChecklistAlarmsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public DashboardChecklistAlarmsGateway()
            : base("DashboardChecklistAlarms")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public DashboardChecklistAlarmsGateway(DataSet data)
            : base(data, "DashboardChecklistAlarms")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new DashboardTDS();
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
            tableMapping.DataSetTable = "DashboardChecklistAlarms";
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("RuleID", "RuleID");
            tableMapping.ColumnMappings.Add("ChecklistAlarmsCompleteName", "ChecklistAlarmsCompleteName");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("State", "State");
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
        /// LoadAllByAlarmPeriod
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllByAlarmPeriod(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDCKECKLISTALARMSGATEWAY_LOADALLBYALARMPERIOD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadAllByAlarmPeriodUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllByAlarmPeriodUnitType(int companyId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDCKECKLISTALARMSGATEWAY_LOADALLBYALARMPERIODUNITTYPE", new SqlParameter("@companyId", companyId), new SqlParameter("@unitType", unitType));
            return Data;
        }



        /// <summary>
        /// LoadAllByAlarmPeriodCompanyLevelId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllByAlarmPeriodCompanyLevelId(int companyId, int companyLevelId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDCKECKLISTALARMSGATEWAY_LOADALLBYALARMPERIODCOMPANYLEVELID", new SqlParameter("@companyId", companyId), new SqlParameter("@companyLevelId", companyLevelId));
            return Data;
        }



        /// <summary>
        /// LoadAllByAlarmPeriodCompanyLevelIdUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllByAlarmPeriodCompanyLevelIdUnitType(int companyId, int companyLevelId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDCKECKLISTALARMSGATEWAY_LOADALLBYALARMPERIODCOMPANYLEVELIDUNITTYPE", new SqlParameter("@companyId", companyId), new SqlParameter("@companyLevelId", companyLevelId), new SqlParameter("@unitType", unitType));
            return Data;
        }


        
        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int serviceId)
        {
            string filter = string.Format("(ServiceID = {0})", serviceId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Dashboard.DashboardChecklistAlarmsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetChecklistAlarmsCompleteName
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>ChecklistAlarmsCompleteName</returns>
        public string GetChecklistAlarmsCompleteName(int serviceId)
        {
            return (string)GetRow(serviceId)["ChecklistAlarmsCompleteName"];
        }



    }
}