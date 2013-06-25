using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Jliner
{
    /// <summary>
    /// JlinerOverviewReportGateway
    /// </summary>
    public class JlinerOverviewReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlinerOverviewReportGateway()
            : base("JlinerOverview")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public JlinerOverviewReportGateway(DataSet data)
            : base(data, "JlinerOverview")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlinerOverviewReportTDS();
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
            tableMapping.DataSetTable = "JlinerOverview";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("ActualLength", "ActualLength");
            tableMapping.ColumnMappings.Add("ConfirmedSize", "ConfirmedSize");
            tableMapping.ColumnMappings.Add("P1Date", "P1Date");
            tableMapping.ColumnMappings.Add("MainLined", "MainLined");
            tableMapping.ColumnMappings.Add("BenchingIssue", "BenchingIssue");
            tableMapping.ColumnMappings.Add("DetailID", "DetailID");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("Issue", "Issue");
            tableMapping.ColumnMappings.Add("DistanceFromUSMH", "DistanceFromUSMH");
            tableMapping.ColumnMappings.Add("PipeLocated", "PipeLocated");
            tableMapping.ColumnMappings.Add("ServicesLocated", "ServicesLocated");
            tableMapping.ColumnMappings.Add("CoInstalled", "CoInstalled");
            tableMapping.ColumnMappings.Add("BackfilledSoil", "BackfilledSoil");
            tableMapping.ColumnMappings.Add("BackfilledConcrete", "BackfilledConcrete");
            tableMapping.ColumnMappings.Add("Grouted", "Grouted");
            tableMapping.ColumnMappings.Add("Cored", "Cored");
            tableMapping.ColumnMappings.Add("Prepped", "Prepped");
            tableMapping.ColumnMappings.Add("Measured", "Measured");
            tableMapping.ColumnMappings.Add("LinerSize", "LinerSize");
            tableMapping.ColumnMappings.Add("InProcess", "InProcess");
            tableMapping.ColumnMappings.Add("InStock", "InStock");
            tableMapping.ColumnMappings.Add("Delivered", "Delivered");
            tableMapping.ColumnMappings.Add("BuildRebuild", "BuildRebuild");
            tableMapping.ColumnMappings.Add("PreVideo", "PreVideo");
            tableMapping.ColumnMappings.Add("LinerInstalled", "LinerInstalled");
            tableMapping.ColumnMappings.Add("FinalVideo", "FinalVideo");
            tableMapping.ColumnMappings.Add("RecordID", "RecordID");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("JLiner", "JLiner");
            tableMapping.ColumnMappings.Add("DistanceFromDSMH", "DistanceFromDSMH");
            tableMapping.ColumnMappings.Add("NAME", "NAME");
            tableMapping.ColumnMappings.Add("VideoInspection", "VideoInspection");
            tableMapping.ColumnMappings.Add("Abbreviation", "Abbreviation");
            tableMapping.ColumnMappings.Add("CoPitLocation", "CoPitLocation");
            tableMapping.ColumnMappings.Add("PostContractDigRequired", "PostContractDigRequired");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("ClientLateralID", "ClientLateralID");
            tableMapping.ColumnMappings.Add("VideoLengthToPropertyLine", "VideoLengthToPropertyLine");
            tableMapping.ColumnMappings.Add("LiningThruCo", "LiningThruCo");
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
        /// LoadByCompaniesID
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="companyId">companyId</param>
        public JlinerOverviewReportTDS LoadByCompaniesID(int companiesId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINEROVERVIEWREPORTGATEWAY_LOADBYCOMPANIESID", new SqlParameter("@companiesId", companiesId), new SqlParameter("@companyId", companyId)); 

            return (JlinerOverviewReportTDS)Data;
        }



        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        public JlinerOverviewReportTDS Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINEROVERVIEWREPORTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));

            return (JlinerOverviewReportTDS)Data;
        }



    }
}