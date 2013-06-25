using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Common
{
    /// <summary>
    /// ResourceTypeViewDisplayGateway
    /// </summary>
    public class ResourceTypeViewDisplayGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ResourceTypeViewDisplayGateway()
            : base("LFS_RESOURCES_TYPE_VIEW_DISPLAY")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ResourceTypeViewDisplayGateway(DataSet data)
            : base(data, "LFS_RESOURCES_TYPE_VIEW_DISPLAY")
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
            tableMapping.DataSetTable = "LFS_RESOURCES_TYPE_VIEW_DISPLAY";
            tableMapping.ColumnMappings.Add("ResourceType", "ResourceType");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("DisplayID", "DisplayID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("Always", "Always");
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
        /// LoadByWorkTypeInColumnsByDefault
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inColumnsToDisplay">inColumnsToDisplay</param>
        /// <returns> Data </returns>
        public DataSet LoadByWorkTypeInColumnsByDefault(string resourceType, int companyId, bool inColumnsByDefault)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_RESOURCETYPEVIEWDISPLAYGATEWAY_LOADBYRESOURCETYPEINCOLUMNSBYDEFAULT", new SqlParameter("@resourceType", resourceType), new SqlParameter("@companyId", companyId), new SqlParameter("@inColumnsByDefault", inColumnsByDefault));
            return Data;
        }


        
        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public DataRow GetRow(string resourceType, int companyId, int displayId)
        {
            string filter = string.Format("(ResourceType = '{0}') AND (COMPANY_ID = '{1}') AND (DisplayID  = {2})", resourceType, companyId, displayId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Common.ResourceTypeViewDisplayGateway.GetRow");
            }

        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public string GetName(string resourceType, int companyId, int displayId)
        {
            return (string)GetRow(resourceType, companyId, displayId)["Name"];
        }



        /// <summary>
        /// GetColumn_
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public string GetColumn_(string resourceType, int companyId, int displayId)
        {
            return (string)GetRow(resourceType, companyId, displayId)["Column_"];
        }



        /// <summary>
        /// GetTable_
        /// </summary>
        /// <param name="resourceType">resourceType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public string GetTable_(string resourceType, int companyId, int displayId)
        {
            return (string)GetRow(resourceType, companyId, displayId)["Table_"];
        }



    }
}
