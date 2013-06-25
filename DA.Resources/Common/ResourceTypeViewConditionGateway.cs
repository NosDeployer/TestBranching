using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Common
{
    /// <summary>
    /// ResourceTypeViewConditionGateway
    /// </summary>
    public class ResourceTypeViewConditionGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ResourceTypeViewConditionGateway()
            : base("LFS_RESOURCES_TYPE_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ResourceTypeViewConditionGateway(DataSet data)
            : base(data, "LFS_RESOURCES_TYPE_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new ResourceViewTDS();
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
            tableMapping.DataSetTable = "LFS_RESOURCES_TYPE_VIEW_CONDITION";
            tableMapping.ColumnMappings.Add("ResourceType", "ResourceType");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ConditionID", "ConditionID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("InFor", "InFor");
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
        /// LoadByResourceTypeConditionId
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns>data set</returns>
        public DataSet LoadByResourceTypeConditionId(string resourceType, int companyId, int conditionId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_RESOURCETYPEVIEWCONDITIONGATEWAY_LOADBYRESOURCETYPECONDITIONID", new SqlParameter("@resourceType", resourceType), new SqlParameter("@companyId", companyId), new SqlParameter("@conditionId", conditionId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns></returns>
        public DataRow GetRow(string resourceType, int companyId, int conditionId)
        {
            string filter = string.Format("(ResourceType = '{0}') AND (COMPANY_ID = '{1}') AND (ConditionID  = {2})", resourceType, companyId, conditionId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Common.ResourceTypeViewConditionGateway.GetRow");
            }

        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns>Name</returns>
        public string GetName(string resourceType, int companyId, int conditionId)
        {
            return (string)GetRow(resourceType, companyId, conditionId)["Name"];
        }



        /// <summary>
        /// GetType
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns>Type</returns>
        public string GetType(string resourceType, int companyId, int conditionId)
        {
            return (string)GetRow(resourceType, companyId, conditionId)["Type"];
        }

        

        /// <summary>
        /// GetColumn_
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns>Column_</returns>
        public string GetColumn_(string resourceType, int companyId, int conditionId)
        {
            return (string)GetRow(resourceType, companyId, conditionId)["Column_"];
        }



        /// <summary>
        /// GetTable_
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        /// <returns>Table_</returns>
        public string GetTable_(string resourceType, int companyId, int conditionId)
        {
            return (string)GetRow(resourceType, companyId, conditionId)["Table_"];
        }



    }
}

