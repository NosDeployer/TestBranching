using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetInformationSubcontractorsInformationGateway
    /// </summary>
    public class ProjectCostingSheetInformationSubcontractorsInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCostingSheetInformationSubcontractorsInformationGateway()
            : base("SubcontractorsInformation")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCostingSheetInformationSubcontractorsInformationGateway(DataSet data)
            : base(data, "SubcontractorsInformation")
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
            tableMapping.DataSetTable = "SubcontractorsInformation";
            tableMapping.ColumnMappings.Add("CostingSheetID", "CostingSheetID");
            tableMapping.ColumnMappings.Add("SubcontractorID", "SubcontractorID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("UnitOfMeasurement", "UnitOfMeasurement");
            tableMapping.ColumnMappings.Add("Quantity", "Quantity");
            tableMapping.ColumnMappings.Add("CostCad", "CostCad");
            tableMapping.ColumnMappings.Add("TotalCostCad", "TotalCostCad");
            tableMapping.ColumnMappings.Add("CostUsd", "CostUsd");
            tableMapping.ColumnMappings.Add("TotalCostUsd", "TotalCostUsd");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("Subcontractor", "Subcontractor");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("Budget", "Budget");
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
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETINFORMATIONSUBCONTRACTORSINFORMATIONGATEWAY_LOADBYCOSTINGSHEETID", new SqlParameter("@costingSheetId", costingSheetId), new SqlParameter("@companyId", companyId));
            return Data;            
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int costingSheetId, int subcontractorId, int refId)
        {
            string filter = string.Format("CostingSheetID = {0} AND SubcontractorID = {1} AND RefID = {2}", costingSheetId, subcontractorId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectCostingSheetInformationSubcontractorsInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetUnitOfMeasurement.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>UnitOfMeasurement</returns>
        public string GetUnitOfMeasurement(int costingSheetId, int subcontractorId, int refId)
        {
            return (string)GetRow(costingSheetId, subcontractorId, refId)["UnitOfMeasurement"];
        }



        /// <summary>
        /// GetUnitOfMeasurement Original.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        //// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original UnitOfMeasurement</returns>
        public string GetUnitOfMeasurementOriginal(int costingSheetId, int subcontractorId, int refId)
        {
            return (string)GetRow(costingSheetId, subcontractorId, refId)["UnitOfMeasurement", DataRowVersion.Original];
        }



        /// <summary>
        /// GetQuantity.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        //// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Quantity</returns>
        public double GetQuantity(int costingSheetId, int subcontractorId, int refId)
        {
            return (double)GetRow(costingSheetId, subcontractorId, refId)["Quantity"];
        }



        /// <summary>
        /// GetQuantity Original.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        //// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Quantity</returns>
        public double GetQuantityOriginal(int costingSheetId, int subcontractorId, int refId)
        {
            return (double)GetRow(costingSheetId, subcontractorId, refId)["Quantity", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCostCad
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>CostCad</returns>
        public decimal GetCostCad(int costingSheetId, int subcontractorId, int refId)
        {
            return (decimal)GetRow(costingSheetId, subcontractorId, refId)["CostCad"];
        }



        /// <summary>
        /// GetCostCad Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original CostCad</returns>
        public decimal GetCostCadOriginal(int costingSheetId, int subcontractorId, int refId)
        {
            return (decimal)GetRow(costingSheetId, subcontractorId, refId)["CostCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalCostCad
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>TotalCostCad</returns>
        public decimal GetTotalCostCad(int costingSheetId, int subcontractorId, int refId)
        {
            return (decimal)GetRow(costingSheetId, subcontractorId, refId)["TotalCostCad"];
        }



        /// <summary>
        /// GetTotalCostCad Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original TotalCostCad</returns>
        public decimal GetTotalCostCadOriginal(int costingSheetId, int subcontractorId, int refId)
        {
            return (decimal)GetRow(costingSheetId, subcontractorId, refId)["TotalCostCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCostUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>CostUsd</returns>
        public decimal GetCostUsd(int costingSheetId, int subcontractorId, int refId)
        {
            return (decimal)GetRow(costingSheetId, subcontractorId, refId)["CostUsd"];
        }



        /// <summary>
        /// GetCostUsd Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original CostUsd</returns>
        public decimal GetCostUsdOriginal(int costingSheetId, int subcontractorId, int refId)
        {
            return (decimal)GetRow(costingSheetId, subcontractorId, refId)["CostUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalCostUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>TotalCostUsd</returns>
        public decimal GetTotalCostUsd(int costingSheetId, int subcontractorId, int refId)
        {
            return (decimal)GetRow(costingSheetId, subcontractorId, refId)["TotalCostUsd"];
        }



        /// <summary>
        /// GetTotalCostUsd Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original TotalCostUsd</returns>
        public decimal GetTotalCostUsdOriginal(int costingSheetId, int subcontractorId, int refId)
        {
            return (decimal)GetRow(costingSheetId, subcontractorId, refId)["TotalCostUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDeleted
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Deleted</returns>
        public bool GetDeleted(int costingSheetId, int subcontractorId, int refId)
        {
            return (bool)GetRow(costingSheetId, subcontractorId, refId)["Deleted"];
        }



        /// <summary>
        /// GetDeleted Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Deleted</returns>
        public bool GetDeletedOriginal(int costingSheetId, int subcontractorId, int refId)
        {
            return (bool)GetRow(costingSheetId, subcontractorId, refId)["Deleted", DataRowVersion.Original];
        }



        /// <summary>
        /// GetStartDate
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>StartDate</returns>
        public DateTime GetStartDate(int costingSheetId, int subcontractorId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, subcontractorId, refId)["StartDate"];
        }



        /// <summary>
        /// GetStartDate Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original StartDate</returns>
        public DateTime GetStartDateOriginal(int costingSheetId, int subcontractorId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, subcontractorId, refId)["StartDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetEndDate
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>EndDate</returns>
        public DateTime GetEndDate(int costingSheetId, int subcontractorId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, subcontractorId, refId)["EndDate"];
        }



        /// <summary>
        /// GetEndDate Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original EndDate</returns>
        public DateTime GetEndDateOriginal(int costingSheetId, int subcontractorId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, subcontractorId, refId)["EndDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetInDatabase.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>InDatabase</returns>
        public bool GetInDatabase(int costingSheetId, int subcontractorId, int refId)
        {
            return (bool)GetRow(costingSheetId, subcontractorId, refId)["InDatabase"];
        }



    }
}