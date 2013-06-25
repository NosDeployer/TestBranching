using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetInformationReportInformationGateway
    /// </summary>
    public class ProjectCostingSheetInformationReportInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetInformationReportInformationGateway()
            : base("ReportInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetInformationReportInformationGateway(DataSet data)
            : base(data, "ReportInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetInformationTDS();
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
            tableMapping.DataSetTable = "ReportInformation";
            tableMapping.ColumnMappings.Add("CostingSheetID", "CostingSheetID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("CompaniesID", "CompaniesID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("TotalLabourHoursCad", "TotalLabourHoursCad");
            tableMapping.ColumnMappings.Add("TotalLabourHoursUsd", "TotalLabourHoursUsd");
            tableMapping.ColumnMappings.Add("TotalMaterialsCad", "TotalMaterialsCad");
            tableMapping.ColumnMappings.Add("TotalMaterialsUsd", "TotalMaterialsUsd");
            tableMapping.ColumnMappings.Add("TotalUnitsCad", "TotalUnitsCad");
            tableMapping.ColumnMappings.Add("TotalUnitsUsd", "TotalUnitsUsd");
            tableMapping.ColumnMappings.Add("TotalOtherCostsCad", "TotalOtherCostsCad");
            tableMapping.ColumnMappings.Add("TotalOtherCostsUsd", "TotalOtherCostsUsd");
            tableMapping.ColumnMappings.Add("GrandTotalCad", "GrandTotalCad");
            tableMapping.ColumnMappings.Add("GrandTotalUsd", "GrandTotalUsd");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("FromTo", "FromTo");
            tableMapping.ColumnMappings.Add("ProjectStartDate", "ProjectStartDate");
            tableMapping.ColumnMappings.Add("ProjectEndDate", "ProjectEndDate");
            tableMapping.ColumnMappings.Add("ClientName", "ClientName");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("GrandRevenue", "GrandRevenue");
            tableMapping.ColumnMappings.Add("GrandProfit", "GrandProfit");
            tableMapping.ColumnMappings.Add("GrandGrossMargin", "GrandGrossMargin");            
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
        /// <returns>Data</returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETINFORMATIONREPORTINFORMATIONGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByCompaniesId(int companiesId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETINFORMATIONREPORTINFORMATIONGATEWAY_LOADBYCOMPANIESID", new SqlParameter("@companiesId", companiesId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByCompaniesIdProjectId(int companiesId, int projectId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETINFORMATIONREPORTINFORMATIONGATEWAY_LOADBYCOMPANIESIDPROJECTID", new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@companyId", companyId));
            return Data;
        }

        
        
    }
}