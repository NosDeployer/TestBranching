using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FlCatalystsAddGateway
    /// </summary>
    public class FlCatalystsAddGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlCatalystsAddGateway()
            : base("FlCatalystsAdd")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlCatalystsAddGateway(DataSet data)
            : base(data, "FlCatalystsAdd")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlCatalystsAddTDS();
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
            tableMapping.DataSetTable = "FlCatalystsAdd";
            tableMapping.ColumnMappings.Add("CatalystID", "CatalystID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("DefaultPercentageByWeight", "DefaultPercentageByWeight");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
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
        /// LoadAll
        /// </summary>
        /// <param name="companyId">companyId</param>       
        /// <returns>data set</returns>
        public DataSet LoadAll(int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLCATALYSTSADDGATEWAY_LOADALL", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCatalystId
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <param name="companyId">companyId</param>       
        /// <returns>data set</returns>
        public DataSet LoadByCatalystId(int catalystId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLCATALYSTSADDGATEWAY_LOADBYCATALYSTID", new SqlParameter("@catalystId", catalystId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int catalystId)
        {
            string filter = string.Format("CatalystID = {0}", catalystId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.FullLenthLining.FlCatalystsAddGateway.GetRow");
            }
        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <returns>Name or EMPTY</returns>
        public string GetName(int catalystId)
        {
            if (GetRow(catalystId).IsNull("Name"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(catalystId)["Name"];
            }
        }



        /// <summary>
        /// GetName Original
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <returns>Original Name or EMPTY</returns>
        public string GetNameOriginal(int catalystId)
        {
            if (GetRow(catalystId).IsNull(Table.Columns["Name"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(catalystId)["Name", DataRowVersion.Original];
            }
        }
               
        
        
        /// <summary>
        /// GetDefaultPercentageByWeight
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <returns>DefaultPercentageByWeight or EMPTY</returns>
        public decimal GetDefaultPercentageByWeight(int catalystId)
        {
            return (decimal)GetRow(catalystId)["DefaultPercentageByWeight"];         
        }



        /// <summary>
        /// GetDefaultPercentageByWeight Original
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <returns>Original DefaultPercentageByWeight or EMPTY</returns>
        public decimal GetDefaultPercentageByWeightOriginal(int catalystId)
        {
            return (decimal)GetRow(catalystId)["DefaultPercentageByWeight", DataRowVersion.Original];
        }


    }
}
