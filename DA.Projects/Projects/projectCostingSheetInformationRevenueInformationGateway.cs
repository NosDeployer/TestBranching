using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// projectCostingSheetInformationRevenueInformationGateway
    /// </summary>
    public class projectCostingSheetInformationRevenueInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public projectCostingSheetInformationRevenueInformationGateway()
            : base("RevenueInformation")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public projectCostingSheetInformationRevenueInformationGateway(DataSet data)
            : base(data, "RevenueInformation")
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
            tableMapping.DataSetTable = "RevenueInformation";
            tableMapping.ColumnMappings.Add("CostingSheetID", "CostingSheetID");
            tableMapping.ColumnMappings.Add("RefIDRevenue", "RefIDRevenue");
            tableMapping.ColumnMappings.Add("Revenue", "Revenue");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
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
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETINFORMATIONREVENUEINFORMATIONGATEWAY_LOADBYCOSTINGSHEETID", new SqlParameter("@costingSheetId", costingSheetId), new SqlParameter("@companyId", companyId));
            return Data;            
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int costingSheetId, int refIdRevenue)
        {
            string filter = string.Format("CostingSheetID = {0} AND RefIDRevenue = {1}", costingSheetId, refIdRevenue);

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
        /// GetCostCad
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>CostCad</returns>
        public decimal GetRevenue(int costingSheetId, int refIdRevenue)
        {
            return (decimal)GetRow(costingSheetId, refIdRevenue)["Revenue"];
        }



        /// <summary>
        /// GetCostCad Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="unitId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original CostCad</returns>
        public decimal GetRevenueOriginal(int costingSheetId, int refIdRevenue)
        {
            return (decimal)GetRow(costingSheetId, refIdRevenue)["Revenue", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDeleted
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Deleted</returns>
        public bool GetDeleted(int costingSheetId, int refIdRevenue)
        {
            return (bool)GetRow(costingSheetId, refIdRevenue)["Deleted"];
        }



        /// <summary>
        /// GetDeleted Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Deleted</returns>
        public bool GetDeletedOriginal(int costingSheetId, int refIdRevenue)
        {
            return (bool)GetRow(costingSheetId, refIdRevenue)["Deleted", DataRowVersion.Original];
        }



        /// <summary>
        /// GetStartDate
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>StartDate</returns>
        public DateTime GetStartDate(int costingSheetId, int refIdRevenue)
        {
            return (DateTime)GetRow(costingSheetId, refIdRevenue)["StartDate"];
        }



        /// <summary>
        /// GetStartDate Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original StartDate</returns>
        public DateTime GetStartDateOriginal(int costingSheetId, int refIdRevenue)
        {
            return (DateTime)GetRow(costingSheetId, refIdRevenue)["StartDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetEndDate
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>EndDate</returns>
        public DateTime GetEndDate(int costingSheetId, int refIdRevenue)
        {
            return (DateTime)GetRow(costingSheetId, refIdRevenue)["EndDate"];
        }



        /// <summary>
        /// GetEndDate Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original EndDate</returns>
        public DateTime GetEndDateOriginal(int costingSheetId, int refIdRevenue)
        {
            return (DateTime)GetRow(costingSheetId, refIdRevenue)["EndDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetComment
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refIdRevenue">refIdRevenue</param>        
        /// <returns>Comment or EMPTY</returns>
        public string GetComment(int costingSheetId, int refIdRevenue)
        {
            if (GetRow(costingSheetId, refIdRevenue).IsNull("Comment"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(costingSheetId, refIdRevenue)["Comment"];
            }
        }



        /// <summary>
        /// GetComment Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refIdRevenue">refIdRevenue</param>        
        /// <returns>Original Comment or EMPTY</returns>
        public string GetCommentOriginal(int costingSheetId, int refIdRevenue)
        {
            if (GetRow(costingSheetId, refIdRevenue).IsNull(Table.Columns["Comment"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(costingSheetId, refIdRevenue)["Comment", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInDatabase.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>InDatabase</returns>
        public bool GetInDatabase(int costingSheetId, int refIdRevenue)
        {
            return (bool)GetRow(costingSheetId, refIdRevenue)["InDatabase"];
        }



    }
}