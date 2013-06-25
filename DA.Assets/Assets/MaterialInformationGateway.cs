using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Assets.Assets
{
    /// <summary>
    /// MaterialInformationGateway
    /// </summary>
    public class MaterialInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialInformationGateway()
            : base("MaterialInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialInformationGateway(DataSet data)
            : base(data, "MaterialInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MaterialInformationTDS();
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
            tableMapping.DataSetTable = "MaterialInformation";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("MaterialType", "MaterialType");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
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
        /// LoadAllByAssetId
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadAllByAssetId(int assetId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_ASSETS_MATERIALINFORMATIONGATEWAY_LOADALLBYASSETID", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadLastMaterialByAssetId
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadLastMaterialByAssetId(int assetId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_ASSETS_MATERIALINFORMATIONGATEWAY_LOADLASTMATERIALBYASSETID", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int assetId, int refId)
        {
            string filter = string.Format("(AssetID = {0})  AND (RefID = {1})", assetId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Assets.Assets.MaterialInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DataRow</returns>
        public DataRow GetLastRow(int assetId)
        {
            string filter = string.Format("(AssetID = {0})", assetId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Assets.Assets.MaterialInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetMaterialType
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>MaterialType or EMPTY</returns>
        public string GetLastMaterialType(int assetId)
        {
            if (GetLastRow(assetId).IsNull("MaterialType"))
            {
                return "";
            }
            else
            {
                return (string)GetLastRow(assetId)["MaterialType"];
            }
        }



        /// <summary>
        /// GetMaterialType
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="refId">refId</param>
        /// <returns>MaterialType or EMPTY</returns>
        public string GetMaterialType(int assetId, int refId)
        {
            if (GetRow(assetId, refId).IsNull("MaterialType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId, refId)["MaterialType"];
            }
        }



        /// <summary>
        /// GetMaterialType Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MAterial type or EMPTY</returns>
        public string GetMaterialTypeOriginal(int assetId, int refId)
        {
            if (GetRow(assetId, refId).IsNull(Table.Columns["MaterialType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId, refId)["MaterialType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDate_ Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Date_ or EMPTY</returns>
        public DateTime GetDate_Original(int assetId, int refId)
        {
            return (DateTime)GetRow(assetId, refId)["Date_", DataRowVersion.Original];
        }



    }
}