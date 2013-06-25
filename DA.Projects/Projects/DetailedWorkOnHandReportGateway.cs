using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// DetailedWorkOnHandReport
    /// </summary>
    public class DetailedWorkOnHandReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DetailedWorkOnHandReportGateway()
            : base("DetailedWorkOnHandReport")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DetailedWorkOnHandReportGateway(DataSet data)
            : base(data, "DetailedWorkOnHandReport")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DetailedWorkOnHandReportTDS();
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
            tableMapping.DataSetTable = "DetailedWorkOnHandReport";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("GeneralBondingSupplied", "GeneralBondingSupplied");
            tableMapping.ColumnMappings.Add("BillMoney", "BillMoney");
            tableMapping.ColumnMappings.Add("BillPrice", "BillPrice");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("ExtrasToDate", "ExtrasToDate");
            tableMapping.ColumnMappings.Add("CostsIncurred", "CostsIncurred");
            tableMapping.ColumnMappings.Add("OriginalProfitEstimated", "OriginalProfitEstimated");
            tableMapping.ColumnMappings.Add("TotalAmountIncludingExtras", "TotalAmountIncludingExtras");
            tableMapping.ColumnMappings.Add("InvoicedToDate", "InvoicedToDate");
            tableMapping.ColumnMappings.Add("ClientName", "ClientName");
            tableMapping.ColumnMappings.Add("ClientProjectNumber", "ClientProjectNumber");
            tableMapping.ColumnMappings.Add("BondNumber", "BondNumber");
            tableMapping.ColumnMappings.Add("LeftToInvoice", "LeftToInvoice");
            tableMapping.ColumnMappings.Add("PercentageCompleted", "PercentageCompleted");
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
        /// LoadWhere
        /// </summary>
        /// <param name="where">Where clause</param>
        public void LoadWhere(string where)
        {
            string commandText = string.Format("SELECT P.ProjectID, P.EndDate, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName, SBP.BillMoney, SBP.BillPrice, ES.GeneralBondingSupplied, CU.ExtrasToDate, CU.CostsIncurred, CU.CostToComplete, CU.OriginalProfitEstimated, SBP.BillPrice + CU.ExtrasToDate as TotalAmountIncludingExtras, CU.InvoicedToDate, C.Name AS ClientName, P.ClientProjectNumber, ES.BondNumber, 0 AS LeftToInvoice, 0 AS PercentageCompleted FROM LFS_PROJECT AS P INNER JOIN LFS_RESOURCES_COMPANIES AS C ON P.ClientID = C.COMPANIES_ID LEFT OUTER JOIN LFS_PROJECT_SALE_BILLING_PRICING AS SBP ON P.ProjectID = SBP.ProjectID LEFT OUTER JOIN LFS_PROJECT_ENGINEER_SUBCONTRACTORS AS ES ON P.ProjectID = ES.ProjectID LEFT OUTER JOIN LFS_PROJECT_COSTING_UPDATES AS CU ON P.ProjectID = CU.ProjectID WHERE {0} ORDER BY SUBSTRING(P.ProjectNumber, LEN(P.ProjectNumber) - 4, 5) ASC", where);
            FillData(commandText);
        }



    }
}