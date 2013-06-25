using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// BallparkSummaryReportGateway
    /// </summary>
    public class BallparkSummaryReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public BallparkSummaryReportGateway()
            : base("BallparkSummaryReportTDS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public BallparkSummaryReportGateway(DataSet data)
            : base(data, "BallparkSummaryReportTDS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new BallparkSummaryReportTDS();
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
            tableMapping.DataSetTable = "BallparkSummaryReportTDS";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("ProjectState", "ProjectState");
            tableMapping.ColumnMappings.Add("CountryID", "CountryID");
            tableMapping.ColumnMappings.Add("ProjectNumber", "ProjectNumber");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("ClientName", "ClientName");
            tableMapping.ColumnMappings.Add("BillMoney", "BillMoney");
            tableMapping.ColumnMappings.Add("BillPrice", "BillPrice");
            tableMapping.ColumnMappings.Add("SalesmanID", "SalesmanID");
            tableMapping.ColumnMappings.Add("SalesmanName", "SalesmanName");
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
        /// <param name="order">Order clause</param>
        /// <param name="projectId">ProjectId filter</param>
        public void LoadWhereOrderBy(string where, string orderBy)
        {
            string commandText = string.Format("SELECT P.ProjectID, P.ProjectState, P.CountryID, P.ProjectNumber, P.Name, C.COMPANY_ID AS ClientID, C.NAME AS ClientName, SBP.BillMoney, SBP.BillPrice, E.EmployeeID AS SalesmanID, E.FullName AS SalesmanName FROM LFS_PROJECT AS P INNER JOIN LFS_RESOURCES_COMPANIES AS C ON P.ClientID = C.COMPANIES_ID LEFT OUTER JOIN LFS_PROJECT_SALE_BILLING_PRICING AS SBP ON P.ProjectID = SBP.ProjectID LEFT OUTER JOIN LFS_RESOURCES_EMPLOYEE AS E ON P.SalesmanID = E.EmployeeID WHERE {0} ORDER BY {1}", where, orderBy);
            FillData(commandText);
        }



    }
}
