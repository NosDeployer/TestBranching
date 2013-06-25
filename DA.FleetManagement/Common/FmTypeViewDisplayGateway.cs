using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.FleetManagement.Common
{
    /// <summary>
    /// FmTypeViewDisplayGateway
    /// </summary>
    public class FmTypeViewDisplayGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public FmTypeViewDisplayGateway()
            : base("LFS_FM_TYPE_VIEW_DISPLAY")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public FmTypeViewDisplayGateway(DataSet data)
            : base(data, "LFS_FM_TYPE_VIEW_DISPLAY")
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
            tableMapping.DataSetTable = "LFS_FM_TYPE_VIEW_DISPLAY";
            tableMapping.ColumnMappings.Add("FmType", "FmType");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("DisplayID", "DisplayID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("Always", "Always");
            tableMapping.ColumnMappings.Add("Column_", "Column_");
            tableMapping.ColumnMappings.Add("Table_", "Table_");
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
        /// LoadByFmType
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadByFmType(string fmType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_FMTYPEVIEWDISPLAYGATEWAY_LOADBYFMTYPE", new SqlParameter("@fmType", fmType), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByFmTypeInColumnsByDefault
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inColumnsToDisplay">inColumnsToDisplay</param>
        /// <returns> Data </returns>
        public DataSet LoadByFmTypeInColumnsByDefault(string fmType, int companyId, bool inColumnsByDefault)
        {
            FillDataWithStoredProcedure("LFS_FM_FMTYPEVIEWDISPLAYGATEWAY_LOADBYFMTYPEINCOLUMNSBYDEFAULT", new SqlParameter("@fmType", fmType), new SqlParameter("@companyId", companyId), new SqlParameter("@inColumnsByDefault", inColumnsByDefault));
            return Data;
        }



        /// <summary>
        /// LoadByFmTypeDisplayId
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public DataSet LoadByFmTypeDisplayId(string fmType, int companyId, int displayId)
        {
            FillDataWithStoredProcedure("LFS_FM_FMTYPEVIEWDISPLAYGATEWAY_LOADBYFMTYPEDISPLAYID", new SqlParameter("@fmType", fmType), new SqlParameter("@companyId", companyId), new SqlParameter("@displayId", displayId));
            return Data;
        }


        
        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public DataRow GetRow(string fmType, int companyId, int displayId)
        {
            string filter = string.Format("(FmType = '{0}') AND (COMPANY_ID = '{1}') AND (DisplayID  = {2})", fmType, companyId, displayId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Common.WorkTypeViewDisplayGateway.GetRow");
            }

        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns>Name</returns>
        public string GetName(string fmType, int companyId, int displayId)
        {
            return (string)GetRow(fmType, companyId, displayId)["Name"];
        }



        /// <summary>
        /// GetColumn_
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns>Column_</returns>
        public string GetColumn_(string fmType, int companyId, int displayId)
        {
            return (string)GetRow(fmType, companyId, displayId)["Column_"];
        }



        /// <summary>
        /// GetTable_
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns>Table_</returns>
        public string GetTable_(string fmType, int companyId, int displayId)
        {
            return (string)GetRow(fmType, companyId, displayId)["Table_"];
        }



    }
}