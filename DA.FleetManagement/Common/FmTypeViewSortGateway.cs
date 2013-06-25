using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.FleetManagement.Common
{
    /// <summary>
    /// FmTypeViewSortGateway
    /// </summary>
    public class FmTypeViewSortGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public FmTypeViewSortGateway()
            : base("LFS_FM_TYPE_VIEW_SORT")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public FmTypeViewSortGateway(DataSet data)
            : base(data, "LFS_FM_TYPE_VIEW_SORT")
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
            tableMapping.DataSetTable = "LFS_FM_TYPE_VIEW_SORT";
            tableMapping.ColumnMappings.Add("FmType", "FmkType");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("SortID", "SortID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("InFor", "InFor");
            tableMapping.ColumnMappings.Add("InView", "InView");
            tableMapping.ColumnMappings.Add("Column_", "Column_");
            tableMapping.ColumnMappings.Add("Table_", "Table_");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("Order_", "Order_");
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
        /// LoadByFmTypeInView
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inView">inView</param>
        /// <returns>data set</returns>
        public DataSet LoadByFmTypeInView(string fmType, int companyId, bool inView)
        {
            FillDataWithStoredProcedure("LFS_FM_FMTYPEVIEWSORTGATEWAY_LOADBYFMTYPEINVIEW", new SqlParameter("@fmType", fmType), new SqlParameter("@companyId", companyId), new SqlParameter("@inView", inView));
            return Data;
        }



        /// <summary>
        /// LoadByFmTypeSortId
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns>data set</returns>
        public DataSet LoadByFmTypeSortId(string fmType, int companyId, int sortId)
        {
            FillDataWithStoredProcedure("LFS_FM_FMTYPEVIEWSORTGATEWAY_LOADBYFMTYPESORTID", new SqlParameter("@fmType", fmType), new SqlParameter("@companyId", companyId), new SqlParameter("@sortId", sortId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns></returns>
        public DataRow GetRow(string fmType, int companyId, int sortId)
        {
            string filter = string.Format("(FmType = '{0}') AND (COMPANY_ID = '{1}') AND (SortID  = {2})", fmType, companyId, sortId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Common.FmTypeViewSortGateway.GetRow");
            }
        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns>Name</returns>
        public string GetName(string fmType, int companyId, int sortId)
        {
            return (string)GetRow(fmType, companyId, sortId)["Name"];
        }



        /// <summary>
        /// GetColumn_
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns>Column_</returns>
        public string GetColumn_(string fmType, int companyId, int sortId)
        {
            return (string)GetRow(fmType, companyId, sortId)["Column_"];
        }



        /// <summary>
        /// GetTable_
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns>Table_</returns>
        public string GetTable_(string fmType, int companyId, int sortId)
        {
            return (string)GetRow(fmType, companyId, sortId)["Table_"];
        }



    }
}