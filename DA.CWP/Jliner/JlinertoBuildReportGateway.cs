using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Jliner
{
    /// <summary>
    /// JlinertoBuildReportGateway
    /// </summary>
    public class JlinertoBuildReportGateway : DataTableGateway
    {

        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlinertoBuildReportGateway()
            : base("JLinersToBuild")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public JlinertoBuildReportGateway(DataSet data)
            : base(data, "JLinersToBuild")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlinertoBuildReportTDS();
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
            tableMapping.DataSetTable = "JLinersToBuild";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("RecordID", "RecordID");
            tableMapping.ColumnMappings.Add("DetailID", "DetailID");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("ConfirmedSize", "ConfirmedSize");
            tableMapping.ColumnMappings.Add("LinerSize", "LinerSize");
            tableMapping.ColumnMappings.Add("IssueIdentified", "IssueIdentified");
            tableMapping.ColumnMappings.Add("IssueResolved", "IssueResolved");
            tableMapping.ColumnMappings.Add("Measured", "Measured");
            tableMapping.ColumnMappings.Add("Issue", "Issue");
            tableMapping.ColumnMappings.Add("InProcess", "InProcess");
            tableMapping.ColumnMappings.Add("LinerInstalled", "LinerInstalled");
            tableMapping.ColumnMappings.Add("Archived", "Archived");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("MDeleted", "MDeleted");
            tableMapping.ColumnMappings.Add("Name", "Name");
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
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINERTOBUILDREPORTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesID
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadByCompaniesID(int companyId, int companiesId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLINERTOBUILDREPORTGATEWAY_LOADBYCOMPANIESID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId));

            return Data;
        }
    }
}
