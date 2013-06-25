using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Units
{
    /// <summary>
    /// UnitInformationUnitDetailsGateway
    /// </summary>
    public class UnitInformationUnitDetailsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitInformationUnitDetailsGateway()
            : base("UnitDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitInformationUnitDetailsGateway(DataSet data)
            : base(data, "UnitDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitInformationTDS();
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
            tableMapping.DataSetTable = "UnitDetails";
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
            tableMapping.ColumnMappings.Add("InsuranceClass", "InsuranceClass");
            tableMapping.ColumnMappings.Add("InsuranceClassRyderSpecified", "InsuranceClassRyderSpecified");
            tableMapping.ColumnMappings.Add("PurchasePrice", "PurchasePrice");
            tableMapping.ColumnMappings.Add("ScrapDate", "ScrapDate");
            tableMapping.ColumnMappings.Add("SaleProceeds", "SaleProceeds");
            tableMapping.ColumnMappings.Add("LIBRARY_CATEGORIES_ID", "LIBRARY_CATEGORIES_ID");
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
        /// LoadByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByUnitId(int unitId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITINFORMATIONUNITDETAILSGATEWAY_LOADBYUNITID", new SqlParameter("@unitId", unitId), new SqlParameter("@companyId", companyId));
            return Data;            
        }



        /// <summary>
        /// LoadAllByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">COMPANY_ID</param>
        /// <returns>Data</returns>
        public DataSet LoadAllByUnitId(int unitId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITINFORMATIONUNITDETAILSGATEWAY_LOADALLBYUNITID", new SqlParameter("@unitId", unitId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int unitId)
        {
            string filter = string.Format("UnitID = {0}", unitId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Units.UnitInformationUnitDetails.GetRow");
            }
        }



        /// <summary>
        /// GetState
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>State</returns>
        public string GetState(int unitId)
        {
            return (string)GetRow(unitId)["State"];            
        }



        /// <summary>
        /// GetState
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>State</returns>
        public string GetType(int unitId)
        {
            return (string)GetRow(unitId)["Type"];
        }



        /// <summary>
        /// GetUnitCode. If not exists, raise an exception.
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>UnitCode or EMPTY</returns>
        public string GetUnitCode(int unitId)
        {
            if (GetRow(unitId).IsNull("UnitCode"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["UnitCode"];
            }
        }



        /// <summary>
        /// GetUnitCode Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original UnitCode or EMPTY</unitId>
        public string GetUnitCodeOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["UnitCode"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["UnitCode", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDescription
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Description or EMPTY</returns>
        public string GetDescription(int unitId)
        {
            if (GetRow(unitId).IsNull("Description"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["Description"];
            }
        }



        /// <summary>
        /// GetDescriptionOriginal Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original Description or EMPTY</returns>
        public string GetDescriptionOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["Description"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["Description", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetVin
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>VIN or EMPTY</returns>
        public string GetVin(int unitId)
        {
            if (GetRow(unitId).IsNull("VIN"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["VIN"];
            }
        }



        /// <summary>
        /// GetVin Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original VIN or EMPTY</returns>
        public string GetVinOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["VIN"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["VIN", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetManufacturer
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Manufacturer or EMPTY</returns>
        public string GetManufacturer(int unitId)
        {
            if (GetRow(unitId).IsNull("Manufacturer"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["Manufacturer"];
            }
        }



        /// <summary>
        /// GetManufacturer Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original Manufacturer or EMPTY</returns>
        public string GetManufacturerOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["Manufacturer"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["Manufacturer", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetModel
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Model or EMPTY</returns>
        public string GetModel(int unitId)
        {
            if (GetRow(unitId).IsNull("Model"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["Model"];
            }
        }



        /// <summary>
        /// GetModel Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original Model or EMPTY</returns>
        public string GetModelOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["Model"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["Model", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetYear_
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Year_ or EMPTY</returns>
        public string GetYear_(int unitId)
        {
            if (GetRow(unitId).IsNull("Year_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["Year_"];
            }
        }



        /// <summary>
        /// GetYear_ Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original Year_ or EMPTY</returns>
        public string GetYear_Original(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["Year_"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["Year_", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetIsTowable
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>IsTowable</returns>
        public bool GetIsTowable(int unitId)
        {
            return (bool)GetRow(unitId)["IsTowable"];
        }



        /// <summary>
        /// GetIsTowable Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original IsTowable</returns>
        public bool GetIsTowableOriginal(int unitId)
        {
            return (bool)GetRow(unitId)["IsTowable", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCompanyLevelId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>CompanyLevelID</returns>
        public int GetCompanyLevelId(int unitId)
        {
            return (int)GetRow(unitId)["CompanyLevelID"];
        }



        /// <summary>
        /// GetCompanyLevelIdOriginal Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original CompanyLevelID</returns>
        public int GetCompanyLevelIdOriginal(int unitId)
        {
            return (int)GetRow(unitId)["CompanyLevelID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetAcquisitionDate
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>AcquisitionDate or null</returns>
        public DateTime? GetAcquisitionDate(int unitId)
        {
            if (GetRow(unitId).IsNull("AcquisitionDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(unitId)["AcquisitionDate"];
            }
        }



        /// <summary>
        /// GetAcquisitionDate Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original AcquisitionDate or null</returns>
        public DateTime? GetAcquisitionDateOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["AcquisitionDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(unitId)["AcquisitionDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDispositionDate
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>DispositionDate or null</returns>
        public DateTime? GetDispositionDate(int unitId)
        {
            if (GetRow(unitId).IsNull("DispositionDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(unitId)["DispositionDate"];
            }
        }



        /// <summary>
        /// GetDispositionDate Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original DispositionDate or null</returns>
        public DateTime? GetDispositionDateOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["DispositionDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(unitId)["DispositionDate", DataRowVersion.Original];
            }
        }

                       

        /// <summary>
        /// GetDispositionReason
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>DispositionReason or EMPTY</returns>
        public string GetDispositionReason(int unitId)
        {
            if (GetRow(unitId).IsNull("DispositionReason"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["DispositionReason"];
            }
        }



        /// <summary>
        /// GetDispositionReason Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original DispositionReason or EMPTY</returns>
        public string GetDispositionReasonOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["DispositionReason"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["DispositionReason", DataRowVersion.Original];
            }
        }       



        /// <summary>
        /// GetLicenseCountry
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>LicenseCountry or null</returns>
        public Int64? GetLicenseCountry(int unitId)
        {
            if (GetRow(unitId).IsNull("LicenseCountry"))
            {
                return null;
            }
            else
            {
                return (Int64)GetRow(unitId)["LicenseCountry"];
            }
        }



        /// <summary>
        /// GetLicenseCountry Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original LicenseCountry or null</returns>
        public Int64? GetLicenseCountryOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["LicenseCountry"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (Int64)GetRow(unitId)["LicenseCountry", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLicenseState
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>LicenseState or null</returns>
        public Int64? GetLicenseState(int unitId)
        {
            if (GetRow(unitId).IsNull("LicenseState"))
            {
                return null;
            }
            else
            {
                return (Int64)GetRow(unitId)["LicenseState"];
            }
        }



        /// <summary>
        /// GetLicenseState Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original LicenseState or null</returns>
        public Int64? GetLicenseStateOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["LicenseState"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (Int64)GetRow(unitId)["LicenseState", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLicensePlateNumbver
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>LicensePlateNumbver or EMPTY</returns>
        public string GetLicensePlateNumbver(int unitId)
        {
            if (GetRow(unitId).IsNull("LicensePlateNumbver"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["LicensePlateNumbver"];
            }
        }



        /// <summary>
        /// GetLicensePlateNumbver Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original LicensePlateNumbver or EMPTY</returns>
        public string GetLicensePlateNumbverOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["LicensePlateNumbver"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["LicensePlateNumbver", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAportionedTagNumber
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>AportionedTagNumber or EMPTY</returns>
        public string GetAportionedTagNumber(int unitId)
        {
            if (GetRow(unitId).IsNull("AportionedTagNumber"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["AportionedTagNumber"];
            }
        }



        /// <summary>
        /// GetAportionedTagNumber Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original AportionedTagNumber or EMPTY</returns>
        public string GetAportionedTagNumberOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["AportionedTagNumber"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["AportionedTagNumber", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetActualWeight
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>ActualWeight or EMPTY</returns>
        public string GetActualWeight(int unitId)
        {
            if (GetRow(unitId).IsNull("ActualWeight"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["ActualWeight"];
            }
        }



        /// <summary>
        /// GetActualWeight Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original ActualWeight or EMPTY</returns>
        public string GetActualWeightOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["ActualWeight"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["ActualWeight", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRegisteredWeight
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>RegisteredWeight or EMPTY</returns>
        public string GetRegisteredWeight(int unitId)
        {
            if (GetRow(unitId).IsNull("RegisteredWeight"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["RegisteredWeight"];
            }
        }



        /// <summary>
        /// GetRegisteredWeight Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original RegisteredWeight or EMPTY</returns>
        public string GetRegisteredWeightOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["RegisteredWeight"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["RegisteredWeight", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTireSizeFront
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>TireSizeFront or EMPTY</returns>
        public string GetTireSizeFront(int unitId)
        {
            if (GetRow(unitId).IsNull("TireSizeFront"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["TireSizeFront"];
            }
        }



        /// <summary>
        /// GetTireSizeFront Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original TireSizeFront or EMPTY</returns>
        public string GetTireSizeFrontOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["TireSizeFront"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["TireSizeFront", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTireSizeBack
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>TireSizeBack or EMPTY</returns>
        public string GetTireSizeBack(int unitId)
        {
            if (GetRow(unitId).IsNull("TireSizeBack"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["TireSizeBack"];
            }
        }



        /// <summary>
        /// GetTireSizeBack Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original TireSizeBack or EMPTY</returns>
        public string GetTireSizeBackOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["TireSizeBack"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["TireSizeBack", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetNumberOfAxes
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>NumberOfAxes or EMPTY</returns>
        public string GetNumberOfAxes(int unitId)
        {
            if (GetRow(unitId).IsNull("NumberOfAxes"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["NumberOfAxes"];
            }
        }



        /// <summary>
        /// GetNumberOfAxes Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original NumberOfAxes or EMPTY</returns>
        public string GetNumberOfAxesOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["NumberOfAxes"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["NumberOfAxes", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetFuelType
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>FuelType or EMPTY</returns>
        public string GetFuelType(int unitId)
        {
            if (GetRow(unitId).IsNull("FuelType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["FuelType"];
            }
        }



        /// <summary>
        /// GetFuelType Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original FuelType or EMPTY</returns>
        public string GetFuelTypeOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["FuelType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["FuelType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetBeginningOdometer
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>FuelType or EMPTY</returns>
        public string GetBeginningOdometer(int unitId)
        {
            if (GetRow(unitId).IsNull("BeginningOdometer"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["BeginningOdometer"];
            }
        }



        /// <summary>
        /// GetBeginningOdometer Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original BeginningOdometer or EMPTY</returns>
        public string GetBeginningOdometerOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["BeginningOdometer"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["BeginningOdometer", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetIsReeferEquipped
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>IsReeferEquipped</returns>
        public bool GetIsReeferEquipped(int unitId)
        {
            return (bool)GetRow(unitId)["IsReeferEquipped"];
        }



        /// <summary>
        /// GetIsReeferEquipped Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original IsReeferEquipped or EMPTY</returns>
        public bool GetIsReeferEquippedOriginal(int unitId)
        {
            return (bool)GetRow(unitId)["IsReeferEquipped", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetIsPTOEquipped
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>IsPTOEquipped</returns>
        public bool GetIsPTOEquipped(int unitId)
        {
            return (bool)GetRow(unitId)["IsPTOEquipped"];
        }



        /// <summary>
        /// GetIsPTOEquipped Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original IsPTOEquipped</returns>
        public bool GetIsPTOEquippedOriginal(int unitId)
        {
            return (bool)GetRow(unitId)["IsPTOEquipped", DataRowVersion.Original];
        }



        /// <summary>
        /// GetOwnerType
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>OwnerType or EMPTY</returns>
        public string GetOwnerType(int unitId)
        {
            if (GetRow(unitId).IsNull("OwnerType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["OwnerType"];
            }
        }



        /// <summary>
        /// GetOwnerType Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original OwnerType or EMPTY</returns>
        public string GetOwnerTypeOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["OwnerType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["OwnerType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetOwnerCountry
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>OwnerCountry or null</returns>
        public Int64? GetOwnerCountry(int unitId)
        {
            if (GetRow(unitId).IsNull("OwnerCountry"))
            {
                return null;
            }
            else
            {
                return (Int64)GetRow(unitId)["OwnerCountry"];
            }
        }



        /// <summary>
        /// GetOwnerCountry Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original OwnerCountry or null</returns>
        public Int64? GetOwnerCountryOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["OwnerCountry"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (Int64)GetRow(unitId)["OwnerCountry", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetOwnerState
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>OwnerState or null</returns>
        public Int64? GetOwnerState(int unitId)
        {
            if (GetRow(unitId).IsNull("OwnerState"))
            {
                return null;
            }
            else
            {
                return (Int64)GetRow(unitId)["OwnerState"];
            }
        }



        /// <summary>
        /// GetOwnerState Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original OwnerState or null</returns>
        public Int64? GetOwnerStateOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["OwnerState"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (Int64)GetRow(unitId)["OwnerState", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetOwnerName
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>OwnerName or EMPTY</returns>
        public string GetOwnerName(int unitId)
        {
            if (GetRow(unitId).IsNull("OwnerName"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["OwnerName"];
            }
        }



        /// <summary>
        /// GetOwnerName Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original OwnerName or EMPTY</returns>
        public string GetOwnerNameOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["OwnerName"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["OwnerName", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetOwnerContact
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>OwnerContact or EMPTY</returns>
        public string GetOwnerContact(int unitId)
        {
            if (GetRow(unitId).IsNull("OwnerContact"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["OwnerContact"];
            }
        }



        /// <summary>
        /// GetOwnerContact Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original OwnerContact or EMPTY</returns>
        public string GetOwnerContactOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["OwnerContact"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["OwnerContact", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetQualifiedDate
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>QualifiedDate or null</returns>
        public DateTime? GetQualifiedDate(int unitId)
        {
            if (GetRow(unitId).IsNull("QualifiedDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(unitId)["QualifiedDate"];
            }
        }



        /// <summary>
        /// GetQualifiedDate Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original QualifiedDate or null</returns>
        public DateTime? GetQualifiedDateOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["QualifiedDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(unitId)["QualifiedDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetNotQualifiedDate
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>DispositionDate or null</returns>
        public DateTime? GetNotQualifiedDate(int unitId)
        {
            if (GetRow(unitId).IsNull("NotQualifiedDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(unitId)["NotQualifiedDate"];
            }
        }



        /// <summary>
        /// GetNotQualifiedDate Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original NotQualifiedDate or null</returns>
        public DateTime? GetNotQualifiedDateOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["NotQualifiedDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(unitId)["NotQualifiedDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetNotQualifiedExplain
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>NotQualifiedExplain or EMPTY</returns>
        public string GetNotQualifiedExplain(int unitId)
        {
            if (GetRow(unitId).IsNull("NotQualifiedExplain"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["NotQualifiedExplain"];
            }
        }



        /// <summary>
        /// GetNotQualifiedExplain Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original NotQualifiedExplain or EMPTY</returns>
        public string GetNotQualifiedExplainOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["NotQualifiedExplain"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["NotQualifiedExplain", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInsuranceClass
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>InsuranceClass or EMPTY</returns>
        public string GetInsuranceClass(int unitId)
        {
            if (GetRow(unitId).IsNull("InsuranceClass"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["InsuranceClass"];
            }
        }



        /// <summary>
        /// GetInsuranceClassOriginal Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original InsuranceClass or EMPTY</returns>
        public string GetInsuranceClassOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["InsuranceClass"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["InsuranceClass", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInsuranceClassRyderSpecified
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>InsuranceClassRyderSpecified or EMPTY</returns>
        public string GetInsuranceClassRyderSpecified(int unitId)
        {
            if (GetRow(unitId).IsNull("InsuranceClassRyderSpecified"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["InsuranceClassRyderSpecified"];
            }
        }



        /// <summary>
        /// GetInsuranceClassRyderSpecifiedOriginal Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original InsuranceClassRyderSpecified or EMPTY</returns>
        public string GetInsuranceClassRyderSpecifiedOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["InsuranceClassRyderSpecified"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["InsuranceClassRyderSpecified", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPurchasePrice
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>PurchasePrice or null</returns>
        public decimal? GetPurchasePrice(int unitId)
        {
            if (GetRow(unitId).IsNull("PurchasePrice"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(unitId)["PurchasePrice"];
            }
        }



        /// <summary>
        /// GetPurchasePrice Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original PurchasePrice or null</returns>
        public decimal? GetPurchasePriceOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["PurchasePrice"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(unitId)["PurchasePrice", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetScrapDate
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>ScrapDate or null</returns>
        public DateTime? GetScrapDate(int unitId)
        {
            if (GetRow(unitId).IsNull("ScrapDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(unitId)["ScrapDate"];
            }
        }



        /// <summary>
        /// GetScrapDate Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original ScrapDate or null</returns>
        public DateTime? GetScrapDateOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["ScrapDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(unitId)["ScrapDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSaleProceeds
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>SaleProceeds or null</returns>
        public decimal? GetSaleProceeds(int unitId)
        {
            if (GetRow(unitId).IsNull("SaleProceeds"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(unitId)["SaleProceeds"];
            }
        }



        /// <summary>
        /// GetSaleProceeds Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original SaleProceeds or null</returns>
        public decimal? GetSaleProceedsOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["SaleProceeds"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(unitId)["SaleProceeds", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLibraryCategoriesId. If not exists, raise an exception
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Library Categories Id or null</returns>
        public int? GetLibraryCategoriesId(int unitId)
        {
            if (GetRow(unitId).IsNull("LIBRARY_CATEGORIES_ID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(unitId)["LIBRARY_CATEGORIES_ID"];
            }
        }



        // <summary>
        /// GetLibraryCategoriesId Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Original LIBRARY_CATEGORIES_ID or null</returns>
        public int? GetLibraryCategoriesIdOriginal(int unitId)
        {
            if (GetRow(unitId).IsNull(Table.Columns["LIBRARY_CATEGORIES_ID"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(unitId)["LIBRARY_CATEGORIES_ID", DataRowVersion.Original];
            }
        }
        


    }
}
