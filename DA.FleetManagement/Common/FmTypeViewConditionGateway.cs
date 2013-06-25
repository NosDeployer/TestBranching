using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Common
{
    /// <summary>
    /// FmTypeViewConditionGateway
    /// </summary>
    public class FmTypeViewConditionGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public FmTypeViewConditionGateway()
            : base("LFS_FM_TYPE_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public FmTypeViewConditionGateway(DataSet data)
            : base(data, "LFS_FM_TYPE_VIEW_CONDITION")
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
            tableMapping.DataSetTable = "LFS_FM_TYPE_VIEW_CONDITION";
            tableMapping.ColumnMappings.Add("FmType", "FmType");
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
        /// LoadByFmTypeConditionId
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByFmTypeConditionId(string fmType, int companyId, int conditionId)
        {
            FillDataWithStoredProcedure("LFS_FM_FMTYPEVIEWCONDITIONGATEWAY_LOADBYFMTYPECONDITIONID", new SqlParameter("@fmType", fmType), new SqlParameter("@companyId", companyId), new SqlParameter("@conditionId", conditionId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns></returns>
        public DataRow GetRow(string fmType, int companyId, int conditionId)
        {
            string filter = string.Format("(FmType = '{0}') AND (COMPANY_ID = '{1}') AND (ConditionID  = {2})", fmType, companyId, conditionId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Common.FmTypeViewConditionGateway.GetRow");
            }

        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns>Name</returns>
        public string GetName(string fmType, int companyId, int conditionId)
        {
            return (string)GetRow(fmType, companyId, conditionId)["Name"];
        }



        /// <summary>
        /// GetType
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns>Type</returns>
        public string GetType(string fmType, int companyId, int conditionId)
        {
            return (string)GetRow(fmType, companyId, conditionId)["Type"];
        }

        

        /// <summary>
        /// GetColumn_
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns>Column_</returns>
        public string GetColumn_(string fmType, int companyId, int conditionId)
        {
            return (string)GetRow(fmType, companyId, conditionId)["Column_"];
        }



        /// <summary>
        /// GetTable_
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns>Table_</returns>
        public string GetTable_(string fmType, int companyId, int conditionId)
        {
            return (string)GetRow(fmType, companyId, conditionId)["Table_"];
        }



    }
}