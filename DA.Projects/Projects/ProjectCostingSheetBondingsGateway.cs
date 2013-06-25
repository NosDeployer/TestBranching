using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetBondingsGateway
    /// </summary>
    public class ProjectCostingSheetBondingsGateway : DataTableGateway
    {
        ///////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetBondingsGateway()
            : base("LFS_PROJECT_COSTING_SHEET_BONDING")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetBondingsGateway(DataSet data)
            : base(data, "LFS_PROJECT_COSTING_SHEET_BONDING")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetTDS();
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
            tableMapping.DataSetTable = "LFS_PROJECT_COSTING_SHEET_BONDING";
            tableMapping.ColumnMappings.Add("CostingSheetID", "CostingSheetID");
            tableMapping.ColumnMappings.Add("BondingCompanyID", "BondingCompanyID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("Rate", "Rate");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");            
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="bondingID">bondingID</param>
        /// <param name="refId">refId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="function_">function_</param>
        public void Insert(int costingSheetId, int bondingId, int refId, decimal rate, bool deleted, int companyId, DateTime startDate, DateTime endDate, string comment)
        {
            SqlParameter costingSheetIdParameter = new SqlParameter("CostingSheetID", costingSheetId);
            SqlParameter bondingIdParameter = new SqlParameter("BondingCompanyID", bondingId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter rateParameter = new SqlParameter("Rate", rate); rateParameter.SqlDbType = SqlDbType.Money;
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter startDateParameter = new SqlParameter("StartDate", startDate);
            SqlParameter endDateParameter = new SqlParameter("EndDate", endDate);
            SqlParameter commentParameter = new SqlParameter("Comment", comment);

            string command = "INSERT INTO [dbo].[LFS_PROJECT_COSTING_SHEET_BONDING] ([CostingSheetID], [BondingCompanyID], [RefID], " +
                             " [Rate], [Deleted], [COMPANY_ID], [StartDate], [EndDate], [Comment]) VALUES (@CostingSheetID, @BondingCompanyID, @RefID, " +
                             " @Rate, @Deleted, @COMPANY_ID, @StartDate, @EndDate, @Comment)";

            ExecuteScalar(command, costingSheetIdParameter, bondingIdParameter, refIdParameter, rateParameter, deletedParameter, companyIdParameter, startDateParameter, endDateParameter, commentParameter);
        }



    }
}