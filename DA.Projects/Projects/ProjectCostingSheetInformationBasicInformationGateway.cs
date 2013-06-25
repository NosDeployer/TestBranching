using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetInformationBasicInformationGateway
    /// </summary>
    public class ProjectCostingSheetInformationBasicInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetInformationBasicInformationGateway()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetInformationBasicInformationGateway(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetInformationTDS();
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
            tableMapping.DataSetTable = "BasicInformation";
            tableMapping.ColumnMappings.Add("CostingSheetID", "CostingSheetID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("TotalLabourHoursCad", "TotalLabourHoursCad");
            tableMapping.ColumnMappings.Add("TotalLabourHoursUsd", "TotalLabourHoursUsd");
            tableMapping.ColumnMappings.Add("TotalMaterialsCad", "TotalMaterialsCad");
            tableMapping.ColumnMappings.Add("TotalMaterialsUsd", "TotalMaterialsUsd");
            tableMapping.ColumnMappings.Add("TotalUnitsCad", "TotalUnitsCad");
            tableMapping.ColumnMappings.Add("TotalUnitsUsd", "TotalUnitsUsd");
            tableMapping.ColumnMappings.Add("TotalOtherCostsCad", "TotalOtherCostsCad");
            tableMapping.ColumnMappings.Add("TotalOtherCostsUsd", "TotalOtherCostsUsd");
            tableMapping.ColumnMappings.Add("GrandTotalCad", "GrandTotalCad");
            tableMapping.ColumnMappings.Add("GrandTotalUsd", "GrandTotalUsd");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("FromTo", "FromTo");
            tableMapping.ColumnMappings.Add("TotalSubcontractorsCad", "TotalSubcontractorsCad");
            tableMapping.ColumnMappings.Add("TotalSubcontractorsUsd", "TotalSubcontractorsUsd");
            tableMapping.ColumnMappings.Add("GrandRevenue", "GrandRevenue");
            tableMapping.ColumnMappings.Add("GrandProfit", "GrandProfit");
            tableMapping.ColumnMappings.Add("GrandGrossMargin", "GrandGrossMargin");
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
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETINFORMATIONBASICINFORMATIONGATEWAY_LOADBYCOSTINGSHEETID", new SqlParameter("@costingSheetId", costingSheetId), new SqlParameter("@companyId", companyId));
            return Data;            
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int costingSheetId)
        {
            string filter = string.Format("CostingSheetID = {0}", costingSheetId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectCostingSheetInformationBasicInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetProjectID.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>ProjectID</returns>
        public int GetProjectID(int costingSheetId)
        {
            return (int)GetRow(costingSheetId)["ProjectID"];
        }



        /// <summary>
        /// GetName.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>Name</returns>
        public string GetName(int costingSheetId)
        {
            return (string)GetRow(costingSheetId)["Name"];
        }



        /// <summary>
        /// GetName Original.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>Original Name</returns>
        public string GetNameOriginal(int costingSheetId)
        {
            return (string)GetRow(costingSheetId)["Name", DataRowVersion.Original];
        }
                


        /// <summary>
        /// GetStartDate.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>StartDate</returns>
        public DateTime GetStartDate(int costingSheetId)
        {
            return (DateTime)GetRow(costingSheetId)["StartDate"];
        }



        /// <summary>
        /// GetEndDate.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>EndDate</returns>
        public DateTime GetEndDate(int costingSheetId)
        {
            return (DateTime)GetRow(costingSheetId)["EndDate"];
        }



        /// <summary>
        /// GetState.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>State</returns>
        public string GetState(int costingSheetId)
        {
            return (string)GetRow(costingSheetId)["State"];
        }



        /// <summary>
        /// GetState Original.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>Original State</returns>
        public string GetStateOriginal(int costingSheetId)
        {
            return (string)GetRow(costingSheetId)["State", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalLabourHoursCad
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>TotalLabourHoursCad</returns>
        public decimal GetTotalLabourHoursCad(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalLabourHoursCad"];
        }



        /// <summary>
        /// GetTotalLabourHoursCad Original
        /// </summary>
        /// <param name="unitId">costingSheetId</param>
        /// <returns>Original TotalLabourHoursCad</returns>
        public decimal GetTotalLabourHoursCadOriginal(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalLabourHoursCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalLabourHoursUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>TotalLabourHoursUsd</returns>
        public decimal GetTotalLabourHoursUsd(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalLabourHoursUsd"];
        }



        /// <summary>
        /// GetTotalLabourHoursUsd Original
        /// </summary>
        /// <param name="unitId">costingSheetId</param>
        /// <returns>Original TotalLabourHoursUsd</returns>
        public decimal GetTotalLabourHoursUsdOriginal(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalLabourHoursUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalMaterialsCad
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>TotalMaterialsCad</returns>
        public decimal GetTotalMaterialsCad(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalMaterialsCad"];
        }



        /// <summary>
        /// GetTotalMaterialsCad Original
        /// </summary>
        /// <param name="unitId">costingSheetId</param>
        /// <returns>Original TotalMaterialsCad</returns>
        public decimal GetTotalMaterialsCadOriginal(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalMaterialsCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalMaterialsUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>TotalMaterialsUsd</returns>
        public decimal GetTotalMaterialsUsd(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalMaterialsUsd"];
        }



        /// <summary>
        /// GetTotalMaterialsUsd Original
        /// </summary>
        /// <param name="unitId">costingSheetId</param>
        /// <returns>Original TotalMaterialsUsd</returns>
        public decimal GetTotalMaterialsUsdOriginal(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalMaterialsUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalUnitsCad
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>TotalUnitsCad</returns>
        public decimal GetTotalUnitsCad(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalUnitsCad"];
        }



        /// <summary>
        /// GetTotalUnitsCad Original
        /// </summary>
        /// <param name="unitId">costingSheetId</param>
        /// <returns>Original TotalUnitsCad</returns>
        public decimal GetTotalUnitsCadOriginal(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalUnitsCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalUnitsUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>TotalUnitsUsd</returns>
        public decimal GetTotalUnitsUsd(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalUnitsUsd"];
        }



        /// <summary>
        /// GetTotalUnitsUsd Original
        /// </summary>
        /// <param name="unitId">costingSheetId</param>
        /// <returns>Original TotalUnitsUsd</returns>
        public decimal GetTotalUnitsUsdOriginal(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalUnitsUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalOtherCostsCad
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>TotalOtherCostsCad</returns>
        public decimal GetTotalOtherCostsCad(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalOtherCostsCad"];
        }



        /// <summary>
        /// GetTotalOtherCostsCad Original
        /// </summary>
        /// <param name="unitId">costingSheetId</param>
        /// <returns>Original TotalOtherCostsCad</returns>
        public decimal GetTotalOtherCostsCadOriginal(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalOtherCostsCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalOtherCostsUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>TotalOtherCostsUsd</returns>
        public decimal GetTotalOtherCostsUsd(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalOtherCostsUsd"];
        }



        /// <summary>
        /// GetTotalOtherCostsUsd Original
        /// </summary>
        /// <param name="unitId">costingSheetId</param>
        /// <returns>Original TotalOtherCostsUsd</returns>
        public decimal GetTotalOtherCostsUsdOriginal(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalOtherCostsUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetGrandTotalCad
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>GrandTotalCad</returns>
        public decimal GetGrandTotalCad(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["GrandTotalCad"];
        }



        /// <summary>
        /// GetGrandTotalCad Original
        /// </summary>
        /// <param name="unitId">costingSheetId</param>
        /// <returns>Original GrandTotalCad</returns>
        public decimal GetGrandTotalCadOriginal(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["GrandTotalCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetGrandTotalUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>GrandTotalUsd</returns>
        public decimal GetGrandTotalUsd(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["GrandTotalUsd"];
        }



        /// <summary>
        /// GetGrandTotalUsd Original
        /// </summary>
        /// <param name="unitId">costingSheetId</param>
        /// <returns>Original GrandTotalUsd</returns>
        public decimal GetGrandTotalUsdOriginal(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["GrandTotalUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDeleted
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>GetDeleted</returns>
        public bool GetDeleted(int costingSheetId)
        {
            return (bool)GetRow(costingSheetId)["Deleted"];
        }



        /// <summary>
        /// GetDeleted Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>Original Deleted</returns>
        public bool GetDeletedOriginal(int costingSheetId)
        {
            return (bool)GetRow(costingSheetId)["Deleted", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalSubcontractorsCad
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>TotalSubcontractorsCad</returns>
        public decimal GetTotalSubcontractorsCad(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalSubcontractorsCad"];
        }



        /// <summary>
        /// GetTotalSubcontractorsCad Original
        /// </summary>
        /// <param name="unitId">costingSheetId</param>
        /// <returns>Original TotalSubcontractorsCad</returns>
        public decimal GetTotalSubcontractorsCadOriginal(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalSubcontractorsCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalSubcontractorsUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>TotalSubcontractorsUsd</returns>
        public decimal GetTotalSubcontractorsUsd(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalSubcontractorsUsd"];
        }



        /// <summary>
        /// GetTotalSubcontractorsUsd Original
        /// </summary>
        /// <param name="unitId">costingSheetId</param>
        /// <returns>Original TotalSubcontractorsUsd</returns>
        public decimal GetTotalSubcontractorsUsdOriginal(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["TotalSubcontractorsUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetGrandTotalUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>GrandTotalUsd</returns>
        public decimal GetGrandRevenue(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["GrandRevenue"];
        }



        // <summary>
        /// GetTotalSubcontractorsUsd Original
        /// </summary>
        /// <param name="unitId">costingSheetId</param>
        /// <returns>Original TotalSubcontractorsUsd</returns>
        public decimal GetGrandRevenueOriginal(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["GrandRevenue", DataRowVersion.Original];
        }



        /// <summary>
        /// GetGrandTotalUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>GrandTotalUsd</returns>
        public decimal GetGrandProfit(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["GrandProfit"];
        }



        // <summary>
        /// GetTotalSubcontractorsUsd Original
        /// </summary>
        /// <param name="unitId">costingSheetId</param>
        /// <returns>Original TotalSubcontractorsUsd</returns>
        public decimal GetGrandProfitOriginal(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["GrandProfit", DataRowVersion.Original];
        }



        /// <summary>
        /// GetGrandTotalUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>GrandTotalUsd</returns>
        public decimal GetGrandGrossMargin(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["GrandGrossMargin"];
        }



        // <summary>
        /// GetTotalSubcontractorsUsd Original
        /// </summary>
        /// <param name="unitId">costingSheetId</param>
        /// <returns>Original TotalSubcontractorsUsd</returns>
        public decimal GetGrandGrossMarginOriginal(int costingSheetId)
        {
            return (decimal)GetRow(costingSheetId)["GrandGrossMargin", DataRowVersion.Original];
        }


        
    }
}