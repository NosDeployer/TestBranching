using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.FleetManagement.Common
{
    /// <summary>
    /// FmViewConditionNewGateway
    /// </summary>
    public class FmViewConditionNewGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public FmViewConditionNewGateway()
            : base("FmViewConditionNew")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public FmViewConditionNewGateway(DataSet data)
            : base(data, "FmViewConditionNew")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new FmViewTDS();
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
            tableMapping.DataSetTable = "FmViewConditionNew";
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
        /// LoadByViewIdFmType
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fmType">fmType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByViewIdFmType(int viewId, int companyId, string fmType)
        {
            FillDataWithStoredProcedure("LFS_FM_FMVIEWCONDITIONNEWGATEWAY_LOADBYVIEWIDFMTYPE", new SqlParameter("@viewId", viewId), new SqlParameter("@companyId", companyId), new SqlParameter("@fmType", fmType));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Common.FmViewConditionNewGateway.GetRow");
            }
        }



        /// <summary>
        /// GetSign
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Sign</returns>
        public string GetSign(int id)
        {
            return (string)GetRow(id)["Sign"];
        }



        /// <summary>
        /// GetOperator
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Operator</returns>
        public string GetOperator(int id)
        {
            return (string)GetRow(id)["Operator"];
        }



        /// <summary>
        /// GetValue_
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Value_</returns>
        public string GetValue_(int id)
        {
            return (string)GetRow(id)["Value_"];
        }



        /// <summary>
        /// GetInDatabase
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>InDatabase</returns>
        public bool GetInDatabase(int id)
        {
            return (bool)GetRow(id)["InDatabase"];
        }



        /// <summary>
        /// GetConditionId
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>ConditionID</returns>
        public int GetConditionId(int id)
        {
            return (int)GetRow(id)["ConditionID"];
        }


  
    }
}