using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Units
{
    /// <summary>
    /// UnitsChecklistRulesTempGateway
    /// </summary>
    public class UnitsChecklistRulesTempGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public UnitsChecklistRulesTempGateway()
            : base("UnitsChecklistRulesTemp")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public UnitsChecklistRulesTempGateway(DataSet data)
            : base(data, "UnitsChecklistRulesTemp")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsAddTDS();
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
            tableMapping.DataSetTable = "UnitsChecklistRulesTemp";
            tableMapping.ColumnMappings.Add("RuleID", "RuleID");
            tableMapping.ColumnMappings.Add("Count", "Count");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("Frequency", "Frequency");
            tableMapping.ColumnMappings.Add("LastService", "LastService");
            tableMapping.ColumnMappings.Add("NextDue", "NextDue");
            tableMapping.ColumnMappings.Add("Done", "Done");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
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
        /// LoadByCategoryIdCompanyLevelId
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="count">count</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByCategoryIdCompanyLevelId(int categoryId, int companyLevelId, int count, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITSCHECKLISTRULESTEMPGATEWAY_LOADBYCATEGORYIDCOMPANYLEVELID", new SqlParameter("@categoryId", categoryId), new SqlParameter("@companyLevelId", companyLevelId), new SqlParameter("@count", count), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompanyLevelId
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="count">count</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByCompanyLevelId(int companyLevelId, int count, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITSCHECKLISTRULESTEMPGATEWAY_LOADBYCOMPANYLEVELID", new SqlParameter("@companyLevelId", companyLevelId), new SqlParameter("@count", count), new SqlParameter("@companyId", companyId));
            return Data;
        }
        

        
    }
}

