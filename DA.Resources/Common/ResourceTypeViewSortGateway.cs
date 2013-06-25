using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Common
{
    /// <summary>
    /// ResourceTypeViewSortGateway
    /// </summary>
    public class ResourceTypeViewSortGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ResourceTypeViewSortGateway()
            : base("LFS_RESOURCES_TYPE_VIEW_SORT")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ResourceTypeViewSortGateway(DataSet data)
            : base(data, "LFS_RESOURCES_TYPE_VIEW_SORT")
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
            tableMapping.DataSetTable = "LFS_RESOURCES_TYPE_VIEW_SORT";
            tableMapping.ColumnMappings.Add("ResourceType", "ResourceType");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("SortID", "SortID");
            tableMapping.ColumnMappings.Add("Name", "Name");
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
        /// LoadByResourceTypeSortId
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns>data set</returns>
        public DataSet LoadByResourceTypeSortId(string resourceType, int companyId, int sortId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_RESOURCETYPEVIEWSORTGATEWAY_LOADBYRESOURCETYPESORTID", new SqlParameter("@resourceType", resourceType), new SqlParameter("@companyId", companyId), new SqlParameter("@sortId", sortId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns></returns>
        public DataRow GetRow(string resourceType, int companyId, int sortId)
        {
            string filter = string.Format("(ResourceType = '{0}') AND (COMPANY_ID = '{1}') AND (SortID  = {2})", resourceType, companyId, sortId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Common.ResourceTypeViewSortGateway.GetRow");
            }

        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns>Name</returns>
        public string GetName(string resourceType, int companyId, int sortId)
        {
            return (string)GetRow(resourceType, companyId, sortId)["Name"];
        }



        /// <summary>
        /// GetColumn_
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns>Column_</returns>
        public string GetColumn_(string resourceType, int companyId, int sortId)
        {
            return (string)GetRow(resourceType, companyId, sortId)["Column_"];
        }



        /// <summary>
        /// GetTable_
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns>Table_</returns>
        public string GetTable_(string resourceType, int companyId, int sortId)
        {
            if (GetRow(resourceType, companyId, sortId).IsNull("Table_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(resourceType, companyId, sortId)["Table_"];
            }            
        }



    }
}