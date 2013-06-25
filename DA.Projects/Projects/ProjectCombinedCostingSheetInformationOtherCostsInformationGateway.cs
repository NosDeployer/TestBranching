using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCombinedCostingSheetInformationOtherCostsInformationGateway
    /// </summary>
    public class ProjectCombinedCostingSheetInformationOtherCostsInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCombinedCostingSheetInformationOtherCostsInformationGateway()
            : base("CombinedOtherCostsInformation")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCombinedCostingSheetInformationOtherCostsInformationGateway(DataSet data)
            : base(data, "CombinedOtherCostsInformation")
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
            tableMapping.DataSetTable = "CombinedOtherCostsInformation";
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
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("Project", "Project");
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
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOMBINEDCOSTINGSHEETINFORMATIONOTHERCOSTSINFORMATIONGATEWAY_LOADBYCOSTINGSHEETID", new SqlParameter("@costingSheetId", costingSheetId), new SqlParameter("@companyId", companyId));
            return Data;            
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectCombinedCostingSheetInformationOtherCostsInformationGateway.GetRow");
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



        /// <summary>
        /// GetUnitOfMeasurement Original.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original UnitOfMeasurement</returns>
        public string GetUnitOfMeasurementOriginal(int costingSheetId, int refId)
        {
            return (string)GetRow(costingSheetId, refId)["UnitOfMeasurement", DataRowVersion.Original];
        }



        /// <summary>
        /// GetQuantity.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Quantity</returns>
        public double GetQuantity(int costingSheetId, int refId)
        {
            return (double)GetRow(costingSheetId, refId)["Quantity"];
        }



        /// <summary>
        /// GetQuantity Original.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Quantity</returns>
        public double GetQuantityOriginal(int costingSheetId, int refId)
        {
            return (double)GetRow(costingSheetId, refId)["Quantity", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCostCad
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>CostCad</returns>
        public decimal GetCostCad(int costingSheetId, int refId)
        {
            return (decimal)GetRow(costingSheetId, refId)["CostCad"];
        }



        /// <summary>
        /// GetCostCad Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original CostCad</returns>
        public decimal GetCostCadOriginal(int costingSheetId, int refId)
        {
            return (decimal)GetRow(costingSheetId, refId)["CostCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalCostCad
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>TotalCostCad</returns>
        public decimal GetTotalCostCad(int costingSheetId, int refId)
        {
            return (decimal)GetRow(costingSheetId, refId)["TotalCostCad"];
        }



        /// <summary>
        /// GetTotalCostCad Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original TotalCostCad</returns>
        public decimal GetTotalCostCadOriginal(int costingSheetId, int refId)
        {
            return (decimal)GetRow(costingSheetId, refId)["TotalCostCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCostUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>CostUsd</returns>
        public decimal GetCostUsd(int costingSheetId, int refId)
        {
            return (decimal)GetRow(costingSheetId, refId)["CostUsd"];
        }



        /// <summary>
        /// GetCostUsd Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original CostUsd</returns>
        public decimal GetCostUsdOriginal(int costingSheetId, int refId)
        {
            return (decimal)GetRow(costingSheetId, refId)["CostUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalCostUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>TotalCostUsd</returns>
        public decimal GetTotalCostUsd(int costingSheetId, int refId)
        {
            return (decimal)GetRow(costingSheetId, refId)["TotalCostUsd"];
        }



        /// <summary>
        /// GetTotalCostUsd Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original TotalCostUsd</returns>
        public decimal GetTotalCostUsdOriginal(int costingSheetId, int refId)
        {
            return (decimal)GetRow(costingSheetId, refId)["TotalCostUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDeleted
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Deleted</returns>
        public bool GetDeleted(int costingSheetId, int refId)
        {
            return (bool)GetRow(costingSheetId, refId)["Deleted"];
        }



        /// <summary>
        /// GetDeleted Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Deleted</returns>
        public bool GetDeletedOriginal(int costingSheetId, int refId)
        {
            return (bool)GetRow(costingSheetId, refId)["Deleted", DataRowVersion.Original];
        }



        /// <summary>
        /// GetWork_
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Work_ or EMPTY</returns>
        public string GetWork_(int costingSheetId, int refId)
        {
            if (GetRow(costingSheetId, refId).IsNull("Work_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(costingSheetId, refId)["Work_"];
            }
        }



        /// <summary>
        /// GetWork_ Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Work_ or EMPTY</returns>
        public string GetWork_Original(int costingSheetId, int refId)
        {
            if (GetRow(costingSheetId, refId).IsNull(Table.Columns["Work_"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(costingSheetId, refId)["Work_", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetFunction_
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Function_ or EMPTY</returns>
        public string GetFunction_(int costingSheetId, int refId)
        {
            if (GetRow(costingSheetId, refId).IsNull("Function_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(costingSheetId, refId)["Function_"];
            }
        }



        /// <summary>
        /// GetFunction_ Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Function_ or EMPTY</returns>
        public string GetFunction_Original(int costingSheetId, int refId)
        {
            if (GetRow(costingSheetId, refId).IsNull(Table.Columns["Function_"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(costingSheetId, refId)["Function_", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDescription
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Description</returns>
        public string GetDescription(int costingSheetId, int refId)
        {
            return (string)GetRow(costingSheetId, refId)["Description"];
        }



        /// <summary>
        /// GetDescription Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Description</returns>
        public string GetDescriptionOriginal(int costingSheetId, int refId)
        {
            return (string)GetRow(costingSheetId, refId)["Description", DataRowVersion.Original];
        }



        /// <summary>
        /// GetStartDate
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>StartDate</returns>
        public DateTime GetStartDate(int costingSheetId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, refId)["StartDate"];
        }



        /// <summary>
        /// GetStartDate Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original StartDate</returns>
        public DateTime GetStartDateOriginal(int costingSheetId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, refId)["StartDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetEndDate
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>EndDate</returns>
        public DateTime GetEndDate(int costingSheetId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, refId)["EndDate"];
        }



        /// <summary>
        /// GetEndDate Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original EndDate</returns>
        public DateTime GetEndDateOriginal(int costingSheetId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, refId)["EndDate", DataRowVersion.Original];
        }



    }
}