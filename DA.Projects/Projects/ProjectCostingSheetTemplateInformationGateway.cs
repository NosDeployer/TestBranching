using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;
using System;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetTemplateInformationGateway
    /// </summary>
    public class ProjectCostingSheetTemplateInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCostingSheetTemplateInformationGateway()
            : base("TemplateInformation")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCostingSheetTemplateInformationGateway(DataSet data)
            : base(data, "TemplateInformation")
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
            tableMapping.DataSetTable = "TemplateInformation";
            tableMapping.ColumnMappings.Add("CostingSheetTemplateID", "CostingSheetTemplateID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("RAData", "RAData");
            tableMapping.ColumnMappings.Add("FLLData", "FLLData");
            tableMapping.ColumnMappings.Add("PRData", "PRData");
            tableMapping.ColumnMappings.Add("JLData", "JLData");
            tableMapping.ColumnMappings.Add("MRData", "MRData");
            tableMapping.ColumnMappings.Add("MOBData", "MOBData");
            tableMapping.ColumnMappings.Add("OtherData", "OtherData");
            tableMapping.ColumnMappings.Add("LabourHourData", "LabourHourData");
            tableMapping.ColumnMappings.Add("UnitData", "UnitData");
            tableMapping.ColumnMappings.Add("MaterialData", "MaterialData");
            tableMapping.ColumnMappings.Add("SubcontractorData", "SubcontractorData");
            tableMapping.ColumnMappings.Add("MiscData", "MiscData");
            tableMapping.ColumnMappings.Add("RevenueIncluded", "RevenueIncluded");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("Month", "Month");
            tableMapping.ColumnMappings.Add("Day", "Day");
            tableMapping.ColumnMappings.Add("Year", "Year");
            tableMapping.ColumnMappings.Add("Month2", "Month2");
            tableMapping.ColumnMappings.Add("Day2", "Day2");
            tableMapping.ColumnMappings.Add("Year2", "Year2");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
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
        /// Load one template by LoginID
        /// </summary>
        /// <param name="loginId">LoginID from RAF</param>
        /// <returns>Data</returns>
        public DataSet LoadAll(int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDTEMPLATEINFORMATIONGATEWAY_LOADALL", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Load one template by LoginID
        /// </summary>
        /// <param name="loginId">LoginID from RAF</param>
        /// <returns>Data</returns>
        public DataSet LoadByCostingSheetTemplateId(int costingSheetTemplateId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDTEMPLATEINFORMATIONGATEWAY_LOADBYCOSTINGSHEETTEMPLATEID", new SqlParameter("@costingSheetTemplateId", costingSheetTemplateId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int costingSheetTemplateId)
        {
            string filter = string.Format("CostingSheetTemplateID = {0}", costingSheetTemplateId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectCostingSheetInformationTemplateInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetName.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns></returns>
        public string GetName(int costingSheetTemplateId)
        {
            return (string)GetRow(costingSheetTemplateId)["Name"];
        }



        /// <summary>
        /// GetName Original.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original </returns>
        public string GetNameOriginal(int costingSheetTemplateId)
        {
            return (string)GetRow(costingSheetTemplateId)["Name", DataRowVersion.Original];
        }



        /// <summary>
        /// GetRAData.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns></returns>
        public bool GetRAData(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["RAData"];
        }



        /// <summary>
        /// GetRAData Original.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original </returns>
        public bool GetRADataOriginal(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["RAData", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPRData.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns></returns>
        public bool GetPRData(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["PRData"];
        }



        /// <summary>
        /// GetPRData Original.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original </returns>
        public bool GetPRDataOriginal(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["PRData", DataRowVersion.Original];
        }



        /// <summary>
        /// GetJLData.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns></returns>
        public bool GetJLData(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["JLData"];
        }



        /// <summary>
        /// GetJLData Original.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original </returns>
        public bool GetJLDataOriginal(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["JLData", DataRowVersion.Original];
        }

        

        /// <summary>
        /// GetMRData.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns></returns>
        public bool GetMRData(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["MRData"];
        }



        /// <summary>
        /// GetMRData Original.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original </returns>
        public bool GetMRDataOriginal(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["MRData", DataRowVersion.Original];
        }

        

        /// <summary>
        /// GetMOBData.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns></returns>
        public bool GetMOBData(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["MOBData"];
        }



        /// <summary>
        /// GetMOBData Original.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original </returns>
        public bool GetMOBDataOriginal(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["MOBData", DataRowVersion.Original];
        }

        

        /// <summary>
        /// GetOtherData.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns></returns>
        public bool GetOtherData(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["OtherData"];
        }



        /// <summary>
        /// GetOtherData Original.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original </returns>
        public bool GetOtherDataOriginal(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["OtherData", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLabourHourData.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns></returns>
        public bool GetLabourHourData(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["LabourHourData"];
        }



        /// <summary>
        /// GetLabourHourData Original.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original </returns>
        public bool GetLabourHourDataOriginal(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["LabourHourData", DataRowVersion.Original];
        }



        /// <summary>
        /// GetUnitData.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns></returns>
        public bool GetUnitData(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["UnitData"];
        }



        /// <summary>
        /// GetUnitData Original.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original </returns>
        public bool GetUnitDataOriginal(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["UnitData", DataRowVersion.Original];
        }



        /// <summary>
        /// GetMaterialData.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns></returns>
        public bool GetMaterialData(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["MaterialData"];
        }



        /// <summary>
        /// GetMaterialData Original.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original </returns>
        public bool GetMaterialDataOriginal(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["MaterialData", DataRowVersion.Original];
        }



        /// <summary>
        /// GetSubcontractorData.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns></returns>
        public bool GetSubcontractorData(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["SubcontractorData"];
        }



        /// <summary>
        /// GetSubcontractorData Original.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original </returns>
        public bool GetSubcontractorDataOriginal(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["SubcontractorData", DataRowVersion.Original];
        }

        

        /// <summary>
        /// GetMiscData.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns></returns>
        public bool GetMiscData(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["MiscData"];
        }



        /// <summary>
        /// GetMiscData Original.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original </returns>
        public bool GetMiscDataOriginal(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["MiscData", DataRowVersion.Original];
        }

        

        /// <summary>
        /// GetRevenueIncluded.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns></returns>
        public bool GetRevenueIncluded(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["RevenueIncluded"];
        }



        /// <summary>
        /// GetRevenueIncluded Original.
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original </returns>
        public bool GetRevenueIncludedOriginal(int costingSheetTemplateId)
        {
            return (bool)GetRow(costingSheetTemplateId)["RevenueIncluded", DataRowVersion.Original];
        }



        /// <summary>
        /// GetMonth
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Month or null</returns>
        public int? GetMonth(int costingSheetTemplateId)
        {
            if (GetRow(costingSheetTemplateId).IsNull("Month"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(costingSheetTemplateId)["Month"];
            }
        }



        /// <summary>
        /// GetMonth Original
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original Month or null</returns>
        public int? GetMonthOriginal(int costingSheetTemplateId)
        {
            if (GetRow(costingSheetTemplateId).IsNull(Table.Columns["Month"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(costingSheetTemplateId)["Month", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDay
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Day or null</returns>
        public int? GetDay(int costingSheetTemplateId)
        {
            if (GetRow(costingSheetTemplateId).IsNull("Day"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(costingSheetTemplateId)["Day"];
            }
        }



        /// <summary>
        /// GetDay Original
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original Day or null</returns>
        public int? GetDayOriginal(int costingSheetTemplateId)
        {
            if (GetRow(costingSheetTemplateId).IsNull(Table.Columns["Day"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(costingSheetTemplateId)["Day", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetYear
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Year or null</returns>
        public int? GetYear(int costingSheetTemplateId)
        {
            if (GetRow(costingSheetTemplateId).IsNull("Year"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(costingSheetTemplateId)["Year"];
            }
        }



        /// <summary>
        /// GetYear Original
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original Year or null</returns>
        public int? GetYearOriginal(int costingSheetTemplateId)
        {
            if (GetRow(costingSheetTemplateId).IsNull(Table.Columns["Year"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(costingSheetTemplateId)["Year", DataRowVersion.Original];
            }
        }
        
                
        
        /// <summary>
        /// GetMonth2
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Month or null</returns>
        public int? GetMonth2(int costingSheetTemplateId)
        {
            if (GetRow(costingSheetTemplateId).IsNull("Month2"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(costingSheetTemplateId)["Month2"];
            }
        }



        /// <summary>
        /// GetMonth2 Original
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original Month or null</returns>
        public int? GetMonth2Original(int costingSheetTemplateId)
        {
            if (GetRow(costingSheetTemplateId).IsNull(Table.Columns["Month2"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(costingSheetTemplateId)["Month2", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDay2
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Day or null</returns>
        public int? GetDay2(int costingSheetTemplateId)
        {
            if (GetRow(costingSheetTemplateId).IsNull("Day2"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(costingSheetTemplateId)["Day2"];
            }
        }



        /// <summary>
        /// GetDay2 Original
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original Day or null</returns>
        public int? GetDay2Original(int costingSheetTemplateId)
        {
            if (GetRow(costingSheetTemplateId).IsNull(Table.Columns["Day2"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(costingSheetTemplateId)["Day2", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetYear2
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Year or null</returns>
        public int? GetYear2(int costingSheetTemplateId)
        {
            if (GetRow(costingSheetTemplateId).IsNull("Year2"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(costingSheetTemplateId)["Year2"];
            }
        }



        /// <summary>
        /// GetYear2 Original
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <returns>Original Year or null</returns>
        public int? GetYear2Original(int costingSheetTemplateId)
        {
            if (GetRow(costingSheetTemplateId).IsNull(Table.Columns["Year2"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(costingSheetTemplateId)["Year2", DataRowVersion.Original];
            }
        }



    }
}