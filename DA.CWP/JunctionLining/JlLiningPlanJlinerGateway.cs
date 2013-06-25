using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.JunctionLining
{
    /// <summary>
    /// JlLiningPlanJlinerGateway
    /// </summary>
    public class JlLiningPlanJlinerGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlLiningPlanJlinerGateway()
            : base("JlLiningPlanJliner")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlLiningPlanJlinerGateway(DataSet data)
            : base(data, "JlLiningPlanJliner")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlLiningPlanTDS();
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
            tableMapping.DataSetTable = "JlLiningPlanJliner";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("Section_", "Section_");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("LateralID", "LateralID");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("PullInDistance", "PullInDistance");
            tableMapping.ColumnMappings.Add("LinerSize", "LinerSize");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("FlowOrderIDLateralID", "FlowOrderIDLateralID");
            tableMapping.ColumnMappings.Add("ClientLateralID", "ClientLateralID");
            tableMapping.ColumnMappings.Add("Flange", "Flange");
            tableMapping.ColumnMappings.Add("CoPitLocation", "CoPitLocation");
            tableMapping.ColumnMappings.Add("MainSize", "MainSize");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("ParentInstallOrder", "ParentInstallOrder");
            tableMapping.ColumnMappings.Add("SectionWorkID", "SectionWorkID");
            tableMapping.ColumnMappings.Add("LinerType", "LinerType");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATSET
        //

        /// <summary>
        /// LoadByAssetIdMnSelected
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="mn">mn</param>
        /// <param name="selected">selected</param>
        /// <returns>Data</returns>
        public DataSet LoadByAssetIdMnSelected(int assetId, int companyId, string mn, string selected)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLLININGPLANJLINERGATEWAY_LOADBYASSETID", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId),  new SqlParameter("@selected", selected));

            switch (mn)
            {
                case "USMH":
                    FillDataWithStoredProcedure("LFS_CWP_JLLININGPLANJLINERGATEWAY_LOADBYASSETIDUSMH", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId), new SqlParameter("@selected", selected));
                    break;
                case "DSMH":
                    FillDataWithStoredProcedure("LFS_CWP_JLLININGPLANJLINERGATEWAY_LOADBYASSETIDDSMH", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId), new SqlParameter("@selected", selected));
                    break;
            }

            return Data;
        }



        /// <summary>
        /// LoadBySection_AssetIdAndLateralOrder
        /// </summary>
        /// <param name="section_">section_</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="mn">mn</param>
        /// <param name="selected">selected</param>
        /// <param name="parentInstallOrder">parentInstallOrder</param>
        /// <param name="assetId">assetId</param>
        /// <returns>Data</returns>
        public DataSet LoadBySection_AssetIdAndLateralOrder(int section_, int companyId,  string mn, int selected, string parentInstallOrder, int assetId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLLININGPLANJLINERGATEWAY_LOADBYSECTION_ASSETIDANDLATERALORDER", new SqlParameter("@section_", section_), new SqlParameter("@companyId", companyId), new SqlParameter("@selected", selected), new SqlParameter("@parentInstallOrder", parentInstallOrder), new SqlParameter("@assetId", assetId));

            switch (mn)
            {
                case "USMH":
                    FillDataWithStoredProcedure("LFS_CWP_JLLININGPLANJLINERGATEWAY_LOADBYSECTION_ASSETIDANDLATERALORDERUSMH", new SqlParameter("@section_", section_), new SqlParameter("@companyId", companyId), new SqlParameter("@selected", selected), new SqlParameter("@parentInstallOrder", parentInstallOrder), new SqlParameter("@assetId", assetId));
                    break;
                case "DSMH":
                    FillDataWithStoredProcedure("LFS_CWP_JLLININGPLANJLINERGATEWAY_LOADBYSECTION_ASSETIDANDLATERALORDERDSMH", new SqlParameter("@section_", section_), new SqlParameter("@companyId", companyId), new SqlParameter("@selected", selected), new SqlParameter("@parentInstallOrder", parentInstallOrder), new SqlParameter("@assetId", assetId));
                    break;
            }

            return Data;
        }



    }
}