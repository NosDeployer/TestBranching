using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.JunctionLining
{
    /// <summary>
    /// JltoBuildReportGateway
    /// </summary>
    public class JltoBuildReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JltoBuildReportGateway()
            : base("JLToBuild")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public JltoBuildReportGateway(DataSet data)
            : base(data, "JLToBuild")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JltoBuildReportTDS();
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
            tableMapping.DataSetTable = "JLToBuild";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Section_", "Section_");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("LateralID", "LateralID");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("LinerSize", "LinerSize");
            tableMapping.ColumnMappings.Add("Measured", "Measured");
            tableMapping.ColumnMappings.Add("InProcess", "InProcess");
            tableMapping.ColumnMappings.Add("LinerInstalled", "LinerInstalled");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("MDeleted", "MDeleted");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("Flange", "Flange");
            tableMapping.ColumnMappings.Add("Gasket", "Gasket");
            tableMapping.ColumnMappings.Add("MainSize", "MainSize");
            tableMapping.ColumnMappings.Add("DigRequiredPriorToLining", "DigRequiredPriorToLining");
            tableMapping.ColumnMappings.Add("DigRequiredPriorToLiningCompleted", "DigRequiredPriorToLiningCompleted");
            tableMapping.ColumnMappings.Add("DigRequiredAfterLining", "DigRequiredAfterLining");
            tableMapping.ColumnMappings.Add("DigRequiredAfterLiningCompleted", "DigRequiredAfterLiningCompleted");
            tableMapping.ColumnMappings.Add("OutOfScope", "OutOfScope");
            tableMapping.ColumnMappings.Add("HoldClientIssue", "HoldClientIssue");
            tableMapping.ColumnMappings.Add("HoldClientIssueResolved", "HoldClientIssueResolved");
            tableMapping.ColumnMappings.Add("HoldLFSIssue", "HoldLFSIssue");
            tableMapping.ColumnMappings.Add("HoldLFSIssueResolved", "HoldLFSIssueResolved");
            tableMapping.ColumnMappings.Add("LateralRequiresRoboticPrep", "LateralRequiresRoboticPrep");
            tableMapping.ColumnMappings.Add("LateralRequiresRoboticPrepCompleted", "LateralRequiresRoboticPrepCompleted");
            tableMapping.ColumnMappings.Add("RoboticPrepCompleted", "RoboticPrepCompleted");
            tableMapping.ColumnMappings.Add("LinerType", "LinerType");
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
        /// <returns>Dataset</returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLTOBUILDREPORTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesIdProjectId(int companyId, int companiesId, int projectId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLTOBUILDREPORTGATEWAY_LOADBYCOMPANIESIDPROJECTID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesId(int companyId, int companiesId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLTOBUILDREPORTGATEWAY_LOADBYCOMPANIESID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId));
            return Data;
        }



    }
}