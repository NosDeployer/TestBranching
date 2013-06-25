using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// TotalValueWorkAheadReportGateway
    /// </summary>
    public class TotalValueWorkAheadReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TotalValueWorkAheadReportGateway() : base("TotalValueWorkAheadReport")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public TotalValueWorkAheadReportGateway(DataSet data) : base(data, "TotalValueWorkAheadReport")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTDS();
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
            tableMapping.DataSetTable = "TotalValueWorkAhead";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("ProjectState", "ProjectState");
            tableMapping.ColumnMappings.Add("CountryID", "CountryID");
            tableMapping.ColumnMappings.Add("ProjectNumber", "ProjectNumber");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("ClientName", "ClientName");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("SaleGettingJob", "SaleGettingJob");
            tableMapping.ColumnMappings.Add("BillMoney", "BillMoney");
            tableMapping.ColumnMappings.Add("BillPrice", "BillPrice");
            tableMapping.ColumnMappings.Add("Total", "Total");
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
        /// <param name="projectId">ProjectId filter</param>
        public void LoadWhere(string where)
        {
            string commandText = string.Format("SELECT P.ProjectID, P.ProjectState, P.CountryID, P.ProjectNumber, P.Name, C.COMPANY_ID AS ClientID, C.NAME AS ClientName, P.StartDate, P.EndDate, SBP.SaleGettingJob, SBP.BillMoney, SBP.BillPrice, CAST(0 AS Decimal) AS Total FROM LFS_PROJECT AS P INNER JOIN LFS_RESOURCES_COMPANIES AS C ON P.ClientID = C.COMPANIES_ID LEFT OUTER JOIN LFS_PROJECT_SALE_BILLING_PRICING AS SBP ON P.ProjectID = SBP.ProjectID WHERE {0} ORDER BY P.ProjectState, P.ProjectNumber", where);
            FillData(commandText);
        }



    }
}
