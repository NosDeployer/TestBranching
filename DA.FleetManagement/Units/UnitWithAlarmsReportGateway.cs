using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
namespace LiquiForce.LFSLive.DA.FleetManagement.Units
{
    /// <summary>
    /// UnitWithAlarmsReportGateway
    /// </summary>
    public class UnitWithAlarmsReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitWithAlarmsReportGateway()
            : base("UnitWithAlarmsReport")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public UnitWithAlarmsReportGateway(DataSet data)
            : base(data, "UnitWithAlarmsReport")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitWithAlarmsReportTDS();
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
            tableMapping.DataSetTable = "UnitWithAlarmsReport";
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("UnitCode", "UnitCode");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("VIN", "VIN");
            tableMapping.ColumnMappings.Add("Manufacturer", "Manufacturer");
            tableMapping.ColumnMappings.Add("Model", "Model");
            tableMapping.ColumnMappings.Add("Year_", "Year_");
            tableMapping.ColumnMappings.Add("IsTowable", "IsTowable");
            tableMapping.ColumnMappings.Add("CompanyLevelID", "CompanyLevelID");
            tableMapping.ColumnMappings.Add("AcquisitionDate", "AcquisitionDate");
            tableMapping.ColumnMappings.Add("DispositionDate", "DispositionDate");
            tableMapping.ColumnMappings.Add("DispositionReason", "DispositionReason");
            tableMapping.ColumnMappings.Add("CostCad", "CostCad");
            tableMapping.ColumnMappings.Add("CostUsd", "CostUsd");
            tableMapping.ColumnMappings.Add("OwnerType", "OwnerType");
            tableMapping.ColumnMappings.Add("OwnerCountry", "OwnerCountry");
            tableMapping.ColumnMappings.Add("OwnerState", "OwnerState");
            tableMapping.ColumnMappings.Add("OwnerName", "OwnerName");
            tableMapping.ColumnMappings.Add("OwnerContact", "OwnerContact");
            tableMapping.ColumnMappings.Add("QualifiedDate", "QualifiedDate");
            tableMapping.ColumnMappings.Add("NotQualifiedDate", "NotQualifiedDate");
            tableMapping.ColumnMappings.Add("NotQualifiedExplain", "NotQualifiedExplain");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("Notes", "Notes");
            tableMapping.ColumnMappings.Add("Categories", "Categories");
            tableMapping.ColumnMappings.Add("LicenseCountry", "LicenseCountry");
            tableMapping.ColumnMappings.Add("LicenseState", "LicenseState");
            tableMapping.ColumnMappings.Add("LicensePlateNumbver", "LicensePlateNumbver");
            tableMapping.ColumnMappings.Add("AportionedTagNumber", "AportionedTagNumber");
            tableMapping.ColumnMappings.Add("ActualWeight", "ActualWeight");
            tableMapping.ColumnMappings.Add("RegisteredWeight", "RegisteredWeight");
            tableMapping.ColumnMappings.Add("TireSizeFront", "TireSizeFront");
            tableMapping.ColumnMappings.Add("TireSizeBack", "TireSizeBack");
            tableMapping.ColumnMappings.Add("NumberOfAxes", "NumberOfAxes");
            tableMapping.ColumnMappings.Add("FuelType", "FuelType");
            tableMapping.ColumnMappings.Add("BeginningOdometer", "BeginningOdometer");
            tableMapping.ColumnMappings.Add("IsReeferEquipped", "IsReeferEquipped");
            tableMapping.ColumnMappings.Add("IsPTOEquipped", "IsPTOEquipped");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("CompanyLevel", "CompanyLevel");
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
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITWITHALARMSREPORTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }               



    }
}