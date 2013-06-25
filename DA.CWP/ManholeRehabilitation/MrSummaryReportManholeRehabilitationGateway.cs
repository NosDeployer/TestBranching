using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation
{
    /// <summary>
    /// MrSummaryReportManholeRehabilitationGateway
    /// </summary>
    public class MrSummaryReportManholeRehabilitationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MrSummaryReportManholeRehabilitationGateway()
            : base("ManholeRehabilitation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public MrSummaryReportManholeRehabilitationGateway(DataSet data)
            : base(data, "ManholeRehabilitation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MrSummaryReportTDS();
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
            tableMapping.DataSetTable = "ManholeRehabilitation";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("MHID", "MHID");
            tableMapping.ColumnMappings.Add("Latitud", "Latitud");
            tableMapping.ColumnMappings.Add("Longitude", "Longitude");
            tableMapping.ColumnMappings.Add("Address", "Address");            
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ManholeShape", "ManholeShape");
            tableMapping.ColumnMappings.Add("Location", "Location");
            tableMapping.ColumnMappings.Add("MaterialID", "MaterialID");
            tableMapping.ColumnMappings.Add("TopDiameter", "TopDiameter");
            tableMapping.ColumnMappings.Add("TopDepth", "TopDepth");
            tableMapping.ColumnMappings.Add("TopFloor", "TopFloor");
            tableMapping.ColumnMappings.Add("TopCeiling", "TopCeiling");
            tableMapping.ColumnMappings.Add("TopBenching", "TopBenching");
            tableMapping.ColumnMappings.Add("DownDiameter", "DownDiameter");
            tableMapping.ColumnMappings.Add("DownDepth", "DownDepth");
            tableMapping.ColumnMappings.Add("DownFloor", "DownFloor");
            tableMapping.ColumnMappings.Add("DownCeiling", "DownCeiling");
            tableMapping.ColumnMappings.Add("DownBenching", "DownBenching");
            tableMapping.ColumnMappings.Add("Rectangle1LongSide", "Rectangle1LongSide");
            tableMapping.ColumnMappings.Add("Rectangle1ShortSide", "Rectangle1ShortSide");
            tableMapping.ColumnMappings.Add("Rectangle2LongSide", "Rectangle2LongSide");
            tableMapping.ColumnMappings.Add("Rectangle2ShortSide", "Rectangle2ShortSide");
            tableMapping.ColumnMappings.Add("TopSurfaceArea", "TopSurfaceArea");
            tableMapping.ColumnMappings.Add("DownSurfaceArea", "DownSurfaceArea");
            tableMapping.ColumnMappings.Add("ManholeRugs", "ManholeRugs");
            tableMapping.ColumnMappings.Add("TotalDepth", "TotalDepth");
            tableMapping.ColumnMappings.Add("TotalSurfaceArea", "TotalSurfaceArea");
            tableMapping.ColumnMappings.Add("ConditionRating", "ConditionRating");
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("PreppedDate", "PreppedDate");
            tableMapping.ColumnMappings.Add("SprayedDate", "SprayedDate");
            tableMapping.ColumnMappings.Add("BatchID", "BatchID");
            tableMapping.ColumnMappings.Add("BatchDate", "BatchDate");
            tableMapping.ColumnMappings.Add("Comment", "Comment");

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
        /// LoadByCompaniesIdAssetId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="assetId">assetId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesIdAssetId(int companyId, int companiesId, int assetId)
        {
            FillDataWithStoredProcedure("LFS_CWP_MRSUMMARYREPORTMANHOLEREHABILITATIONGATEWAY_LOADBYCOMPANIESIDASSETID", new SqlParameter("@companiesId", companiesId), new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdAssetId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesIdProjectIdAssetId(int companyId, int companiesId, int projectId, int assetId)
        {
            FillDataWithStoredProcedure("LFS_CWP_MRSUMMARYREPORTMANHOLEREHABILITATIONGATEWAY_LOADBYCOMPANIESIDPROJECTIDASSETID", new SqlParameter("@projectId", projectId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByAssetId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="assetId">assetId</param>
        /// <returns></returns>
        public DataSet LoadByAssetId(int companyId, int assetId)
        {
            FillDataWithStoredProcedure("LFS_CWP_MRSUMMARYREPORTMANHOLEREHABILITATIONGATEWAY_LOADBYASSETID", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));
            return Data;
        }
    }
}