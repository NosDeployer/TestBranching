using System;
using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddOtherCostsInformationGateway
    /// </summary>
    public class ProjectCostingSheetAddOtherCostsInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCostingSheetAddOtherCostsInformationGateway()
            : base("OtherCostsInformation")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCostingSheetAddOtherCostsInformationGateway(DataSet data)
            : base(data, "OtherCostsInformation")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetAddTDS();
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
            tableMapping.DataSetTable = "OtherCostsInformation";
            tableMapping.ColumnMappings.Add("CostingSheetID", "CostingSheetID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Work_", "Work_");
            tableMapping.ColumnMappings.Add("Function_", "Function_");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("UnitOfMeasurement", "UnitOfMeasurement");
            tableMapping.ColumnMappings.Add("Quantity", "Quantity");
            tableMapping.ColumnMappings.Add("CostCad", "CostCad");
            tableMapping.ColumnMappings.Add("TotalCostCad", "TotalCostCad");
            tableMapping.ColumnMappings.Add("CostUsd", "CostUsd");
            tableMapping.ColumnMappings.Add("TotalCostUsd", "TotalCostUsd");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("WorkFunction", "WorkFunction");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int costingSheetId, int refId)
        {
            string filter = string.Format("CostingSheetID = {0} AND RefID = {1}", costingSheetId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectCostingSheetAddOtherCostsInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetUnitOfMeasurement.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>UnitOfMeasurement</returns>
        public string GetUnitOfMeasurement(int costingSheetId, int refId)
        {
            return (string)GetRow(costingSheetId, refId)["UnitOfMeasurement"];
        }



    }
}