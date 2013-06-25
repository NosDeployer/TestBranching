using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetInformationBondingsInformationGateway
    /// </summary>
    public class ProjectCostingSheetInformationBondingsInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCostingSheetInformationBondingsInformationGateway()
            : base("BondingsInformation")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCostingSheetInformationBondingsInformationGateway(DataSet data)
            : base(data, "BondingsInformation")
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
            tableMapping.DataSetTable = "BondingsInformation";
            tableMapping.ColumnMappings.Add("CostingSheetID", "CostingSheetID");
            tableMapping.ColumnMappings.Add("BondingCompanyID", "BondingCompanyID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Rate", "Rate");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("Bonding", "Bonding");
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
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETINFORMATIONBONDINGSINFORMATIONGATEWAY_LOADBYCOSTINGSHEETID", new SqlParameter("@costingSheetId", costingSheetId), new SqlParameter("@companyId", companyId));
            return Data;            
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int costingSheetId, int bondingCompanyId, int refId)
        {
            string filter = string.Format("CostingSheetID = {0} AND BondingCompanyID = {1} AND RefID = {2}", costingSheetId, bondingCompanyId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectCostingSheetInformationBondingsInformationGateway.GetRow");
            }
        }


        /// <summary>
        /// GetRate
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>GetRate</returns>
        public decimal GetRate(int costingSheetId, int bondingCompanyId, int refId)
        {
            return (decimal)GetRow(costingSheetId, bondingCompanyId, refId)["Rate"];
        }



        /// <summary>
        /// GetRate Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Rate</returns>
        public decimal GetRateOriginal(int costingSheetId, int bondingCompanyId, int refId)
        {
            return (decimal)GetRow(costingSheetId, bondingCompanyId, refId)["Rate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDeleted
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>Deleted</returns>
        public bool GetDeleted(int costingSheetId, int bondingCompanyId, int refId)
        {
            return (bool)GetRow(costingSheetId, bondingCompanyId, refId)["Deleted"];
        }



        /// <summary>
        /// GetDeleted Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Deleted</returns>
        public bool GetDeletedOriginal(int costingSheetId, int bondingCompanyId, int refId)
        {
            return (bool)GetRow(costingSheetId, bondingCompanyId, refId)["Deleted", DataRowVersion.Original];
        }



        /// <summary>
        /// GetStartDate
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>StartDate</returns>
        public DateTime GetStartDate(int costingSheetId, int bondingCompanyId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, bondingCompanyId, refId)["StartDate"];
        }



        /// <summary>
        /// GetStartDate Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original StartDate</returns>
        public DateTime GetStartDateOriginal(int costingSheetId, int bondingCompanyId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, bondingCompanyId, refId)["StartDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetEndDate
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>EndDate</returns>
        public DateTime GetEndDate(int costingSheetId, int bondingCompanyId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, bondingCompanyId, refId)["EndDate"];
        }



        /// <summary>
        /// GetEndDate Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original EndDate</returns>
        public DateTime GetEndDateOriginal(int costingSheetId, int bondingCompanyId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, bondingCompanyId, refId)["EndDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetInDatabase.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>InDatabase</returns>
        public bool GetInDatabase(int costingSheetId, int bondingCompanyId, int refId)
        {
            return (bool)GetRow(costingSheetId, bondingCompanyId, refId)["InDatabase"];
        }



    }
}