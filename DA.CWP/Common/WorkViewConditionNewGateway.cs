using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// WorkViewConditionNewGateway
    /// </summary>
    public class WorkViewConditionNewGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public WorkViewConditionNewGateway()
            : base("WorkViewConditionNew")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public WorkViewConditionNewGateway(DataSet data)
            : base(data, "WorkViewConditionNew")
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
            tableMapping.DataSetTable = "WorkViewConditionNew";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("ConditionID", "ConditionID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Operator", "Operator");
            tableMapping.ColumnMappings.Add("Sign", "Sign");
            tableMapping.ColumnMappings.Add("ConditionNumber", "ConditionNumber");
            tableMapping.ColumnMappings.Add("Value_", "Value_");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
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
        /// LoadByViewIdWorkType
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByViewIdWorkType(int viewId, int companyId, string workType)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKVIEWCONDITIONNEWGATEWAY_LOADBYVIEWIDWORKTYPE", new SqlParameter("@viewId", viewId), new SqlParameter("@companyId", companyId), new SqlParameter("@workType", workType));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int id)
        {
            string filter = string.Format("ID = {0}", id.ToString());

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.WorkViewConditionNewGateway.GetRow");
            }
        }



        /// <summary>
        /// GetState
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>State</returns>
        public string GetSign(int id)
        {
            return (string)GetRow(id)["Sign"];
        }



        /// <summary>
        /// GetInProjectDatabase
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>InProjectDatabase</returns>
        public string GetOperator(int id)
        {
            return (string)GetRow(id)["Operator"];
        }



        /// <summary>
        /// GetValue_
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetValue_(int id)
        {
            return (string)GetRow(id)["Value_"];
        }



        /// <summary>
        /// GetInDatabase
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>InDatabase</returns>
        public bool GetInDatabase(int id)
        {
            return (bool)GetRow(id)["InDatabase"];
        }



        /// <summary>
        /// GetConditionId
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>InDatabase</returns>
        public int GetConditionId(int id)
        {
            return (int)GetRow(id)["ConditionID"];
        }


  
    }
}

