using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Units
{
    /// <summary>
    /// UnitChecklistsReportChecklistDetailsGateway
    /// </summary>
    public class UnitChecklistsReportChecklistDetailsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitChecklistsReportChecklistDetailsGateway()
            : base("UnitChecklistsReportChecklistDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public UnitChecklistsReportChecklistDetailsGateway(DataSet data)
            : base(data, "UnitChecklistsReportChecklistDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitChecklistsReportTDS();
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
            tableMapping.DataSetTable = "UnitChecklistsReportChecklistDetails";
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("RuleID", "RuleID");
            tableMapping.ColumnMappings.Add("MTO", "MTO");
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
            FillDataWithStoredProcedure("LFS_FM_UNITCHECKLISREPORTCHECKLISTDETAILSGATEWAY_LOADBYUNITID", new SqlParameter("@unitId", unitId), new SqlParameter("@companyId", companyId));
            return Data;
        }        



        /// <summary>
        /// LoadByUnitIdFrequency
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="frequency">frequency</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByUnitIdFrequency(int unitId, string frequency, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITCHECKLISREPORTCHECKLISTDETAILSGATEWAY_LOADBYUNITIDFREQUENCY", new SqlParameter("@unitId", unitId), new SqlParameter("@frequency", frequency), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByUnitIdMtoDotRules
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="mtoDotRules">mtoDotRules</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByUnitIdMtoDotRules(int unitId, string mtoDotRules, int companyId)
        {
            int mto = 0;
            if (mtoDotRules == "MTODOTRules")
            {
                mto = 1;
            }

            FillDataWithStoredProcedure("LFS_FM_UNITCHECKLISREPORTCHECKLISTDETAILSGATEWAY_LOADBYUNITIDMTODOTRULES", new SqlParameter("@unitId", unitId), new SqlParameter("@mto", mto), new SqlParameter("@companyId", companyId));                     
            return Data;
        }



        /// <summary>
        /// LoadByUnitIdMtoDotRulesFrequency
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="mtoDotRules">mtoDotRules</param>
        /// <param name="frequency">frequency</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByUnitIdMtoDotRulesFrequency(int unitId, string mtoDotRules, string frequency, int companyId)
        {
            int mto = 0;
            if (mtoDotRules == "MTODOTRules")
            {
                mto = 1;
            }

            FillDataWithStoredProcedure("LFS_FM_UNITCHECKLISREPORTCHECKLISTDETAILSGATEWAY_LOADBYUNITIDMTODOTRULESFREQUENCY", new SqlParameter("@unitId", unitId), new SqlParameter("@mto", mto), new SqlParameter("@frequency", frequency), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByUnitIdState
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="state">state</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByUnitIdState(int unitId, string state, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITCHECKLISREPORTCHECKLISTDETAILSGATEWAY_LOADBYUNITIDSTATE", new SqlParameter("@unitId", unitId), new SqlParameter("@state", state), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByUnitIdStateFrequency
        /// </summary>
        /// <param name="unitId">unitId</param>        
        /// <param name="frequency">frequency</param>
        /// <param name="state">state</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByUnitIdFrequencyState(int unitId, string frequency, string state, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITCHECKLISREPORTCHECKLISTDETAILSGATEWAY_LOADBYUNITIDFREQUENCYSTATE", new SqlParameter("@unitId", unitId), new SqlParameter("@frequency", frequency), new SqlParameter("@state", state), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByUnitIdStateMtoDotRules
        /// </summary>
        /// <param name="unitId">unitId</param>        
        /// <param name="mtoDotRules">mtoDotRules</param>   
        /// <param name="state">state</param>      
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByUnitIdMtoDotRulesState(int unitId, string mtoDotRules, string state, int companyId)
        {
            int mto = 0;
            if (mtoDotRules == "MTODOTRules")
            {
                mto = 1;
            }

            FillDataWithStoredProcedure("LFS_FM_UNITCHECKLISREPORTCHECKLISTDETAILSGATEWAY_LOADBYUNITIDMTODOTRULESSTATE", new SqlParameter("@unitId", unitId), new SqlParameter("@mto", mto), new SqlParameter("@state", state), new SqlParameter("@companyId", companyId));                       
            return Data;
        }



        /// <summary>
        /// LoadByUnitIdStateMtoDotRulesFrequency
        /// </summary>
        /// <param name="unitId">unitId</param>        
        /// <param name="mtoDotRules">mtoDotRules</param>   
        /// <param name="frequency">frequency</param>
        /// <param name="state">state</param>      
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByUnitIdMtoDotRulesFrequencyState(int unitId, string mtoDotRules, string frequency, string state, int companyId)
        {
            int mto = 0;
            if (mtoDotRules == "MTODOTRules")
            {
                mto = 1;
            }

            FillDataWithStoredProcedure("LFS_FM_UNITCHECKLISREPORTCHECKLISTDETAILSGATEWAY_LOADBYUNITIDMTODOTRULESFREQUENCYSTATE", new SqlParameter("@unitId", unitId), new SqlParameter("@mto", mto), new SqlParameter("@frequency", frequency), new SqlParameter("@state", state), new SqlParameter("@companyId", companyId));                      
            return Data;
        }



    }
}
