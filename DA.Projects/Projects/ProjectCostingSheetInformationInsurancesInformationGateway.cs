using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetInformationInsurancesInformationGateway
    /// </summary>
    public class ProjectCostingSheetInformationInsurancesInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCostingSheetInformationInsurancesInformationGateway()
            : base("InsurancesInformation")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCostingSheetInformationInsurancesInformationGateway(DataSet data)
            : base(data, "InsurancesInformation")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetInformationTDS();
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
            tableMapping.DataSetTable = "InsurancesInformation";
            tableMapping.ColumnMappings.Add("CostingSheetID", "CostingSheetID");
            tableMapping.ColumnMappings.Add("InsuranceCompanyID", "InsuranceCompanyID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Rate", "Rate");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("Insurance", "Insurance");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("Budget", "Budget");
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
        /// LoadByCostingSheetId
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByCostingSheetId(int costingSheetId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETINFORMATIONINSURANCESINFORMATIONGATEWAY_LOADBYCOSTINGSHEETID", new SqlParameter("@costingSheetId", costingSheetId), new SqlParameter("@companyId", companyId));
            return Data;            
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int costingSheetId, int insuranceCompanyId, int refId)
        {
            string filter = string.Format("CostingSheetID = {0} AND InsuranceCompanyID = {1} AND RefID = {2}", costingSheetId, insuranceCompanyId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectCostingSheetInformationInsurancesInformationGateway.GetRow");
            }
        }


        /// <summary>
        /// GetRate
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>GetRate</returns>
        public decimal GetRate(int costingSheetId, int insuranceCompanyId, int refId)
        {
            return (decimal)GetRow(costingSheetId, insuranceCompanyId, refId)["Rate"];
        }



        /// <summary>
        /// GetRate Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Rate</returns>
        public decimal GetRateOriginal(int costingSheetId, int insuranceCompanyId, int refId)
        {
            return (decimal)GetRow(costingSheetId, insuranceCompanyId, refId)["Rate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDeleted
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>Deleted</returns>
        public bool GetDeleted(int costingSheetId, int insuranceCompanyId, int refId)
        {
            return (bool)GetRow(costingSheetId, insuranceCompanyId, refId)["Deleted"];
        }



        /// <summary>
        /// GetDeleted Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Deleted</returns>
        public bool GetDeletedOriginal(int costingSheetId, int insuranceCompanyId, int refId)
        {
            return (bool)GetRow(costingSheetId, insuranceCompanyId, refId)["Deleted", DataRowVersion.Original];
        }



        /// <summary>
        /// GetStartDate
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>StartDate</returns>
        public DateTime GetStartDate(int costingSheetId, int insuranceCompanyId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, insuranceCompanyId, refId)["StartDate"];
        }



        /// <summary>
        /// GetStartDate Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original StartDate</returns>
        public DateTime GetStartDateOriginal(int costingSheetId, int insuranceCompanyId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, insuranceCompanyId, refId)["StartDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetEndDate
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>EndDate</returns>
        public DateTime GetEndDate(int costingSheetId, int insuranceCompanyId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, insuranceCompanyId, refId)["EndDate"];
        }



        /// <summary>
        /// GetEndDate Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original EndDate</returns>
        public DateTime GetEndDateOriginal(int costingSheetId, int insuranceCompanyId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, insuranceCompanyId, refId)["EndDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetInDatabase.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>InDatabase</returns>
        public bool GetInDatabase(int costingSheetId, int insuranceCompanyId, int refId)
        {
            return (bool)GetRow(costingSheetId, insuranceCompanyId, refId)["InDatabase"];
        }



    }
}