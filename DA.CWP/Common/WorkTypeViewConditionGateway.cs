using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// WorkTypeViewConditionGateway
    /// </summary>
    public class WorkTypeViewConditionGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public WorkTypeViewConditionGateway()
            : base("LFS_WORK_TYPE_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public WorkTypeViewConditionGateway(DataSet data)
            : base(data, "LFS_WORK_TYPE_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new WorkViewTDS();
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
            tableMapping.DataSetTable = "LFS_WORK_TYPE_VIEW_CONDITION";
            tableMapping.ColumnMappings.Add("WorkType", "WorkType");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ConditionID", "ConditionID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("InFor", "InFor");
            tableMapping.ColumnMappings.Add("InView", "InView");
            tableMapping.ColumnMappings.Add("Column_", "Column_");
            tableMapping.ColumnMappings.Add("Table_", "Table_");
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
        /// LoadByWorkTypeConditionId
        /// </summary>
        /// <param name="workType">workType</param>        
        /// <param name="conditionId">conditionId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByWorkTypeConditionId(string workType, int conditionId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKTYPEVIEWCONDITIONGATEWAY_LOADBYWORKTYPECONDITIONID", new SqlParameter("@workType", workType), new SqlParameter("@conditionId", conditionId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns></returns>
        public DataRow GetRow(string workType, int companyId, int conditionId)
        {
            string filter = string.Format("(WorkType = '{0}') AND (COMPANY_ID = '{1}') AND (ConditionID  = {2})", workType, companyId, conditionId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.WorkTypeViewConditionGateway.GetRow");
            }

        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns>Name</returns>
        public string GetName(string workType, int companyId, int conditionId)
        {
            return (string)GetRow(workType, companyId, conditionId)["Name"];
        }



        /// <summary>
        /// GetType
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns>Type</returns>
        public string GetType(string workType, int companyId, int conditionId)
        {
            return (string)GetRow(workType, companyId, conditionId)["Type"];
        }

        

        /// <summary>
        /// GetColumn_
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns>Column_</returns>
        public string GetColumn_(string workType, int companyId, int conditionId)
        {
            return (string)GetRow(workType, companyId, conditionId)["Column_"];
        }



        /// <summary>
        /// GetTable_
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns>Table_</returns>
        public string GetTable_(string workType, int companyId, int conditionId)
        {
            return (string)GetRow(workType, companyId, conditionId)["Table_"];
        }



    }
}

