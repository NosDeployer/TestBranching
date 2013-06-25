using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using System.Collections;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.FleetManagement.Categories;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitsAddNew
    /// </summary>
    public class UnitsAddNew : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsAddNew()
            : base("UnitsAddNew")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsAddNew(DataSet data)
            : base(data, "UnitsAddNew")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="code">code</param>
        /// <param name="description">description</param>
        /// <param name="vin">vin</param>
        /// <param name="manufacturer">manufacturer</param>
        /// <param name="model">model</param>
        /// <param name="year_">year_</param>
        /// <param name="isTowable">isTowable</param>
        /// <param name="licenseCountry">licenseCountry</param>
        /// <param name="licenseState">licenseState</param>
        /// <param name="licensePlateNumber">licensePlateNumber</param>
        /// <param name="apportionedTagNumber">apportionedTagNumber</param>
        /// <param name="companyLevelId">companyLevelId</param>
        public void Insert(string type, string code, string description, string vin, string manufacturer, string model, string year_, bool isTowable, Int64? licenseCountry, Int64? licenseState, string licensePlateNumber, string apportionedTagNumber, int companyLevelId)
        {
            UnitsAddTDS.UnitsAddNewRow row = ((UnitsAddTDS.UnitsAddNewDataTable)Table).NewUnitsAddNewRow();

            row.UnitID = GetNewId();
            if (type.Trim() != "") row.Type = type; else row.SetTypeNull();
            row.Code = code.Trim();
            if (description.Trim() != "") row.Description = description; else row.SetDescriptionNull();
            if (vin.Trim() != "") row.VIN = vin; else row.SetVINNull();
            if (manufacturer.Trim() != "") row.Manufacturer = manufacturer; else row.SetManufacturerNull();
            if (model.Trim() != "") row.Model = model; else row.SetModelNull();
            if (year_.Trim() != "") row.Year_ = year_; else row.SetYear_Null();
            row.IsTowable = isTowable;
            if (licenseCountry.HasValue) row.LicenseCountry = (Int64)licenseCountry; else row.SetLicenseCountryNull();
            if (licenseState.HasValue) row.LicenseState = (Int64)licenseState; else row.SetLicenseStateNull();
            if (licensePlateNumber.Trim() != "") row.LicensePlateNumber = licensePlateNumber; else row.SetLicensePlateNumberNull();
            if (apportionedTagNumber.Trim() != "") row.ApportionedTagNumber = apportionedTagNumber; else row.SetApportionedTagNumberNull();
            row.CompanyLevelID = companyLevelId;

            ((UnitsAddTDS.UnitsAddNewDataTable)Table).AddUnitsAddNewRow(row);
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="categoriesSelected">categoriesSelected</param>
        /// <param name="companyId">companyId</param>
        public void Save(ArrayList categoriesSelected, int companyId)
        {
            UnitsAddTDS unitsAddChanges = (UnitsAddTDS)Data.GetChanges();
            
            if (unitsAddChanges.UnitsAddNew.Rows.Count > 0)
            {
                foreach (UnitsAddTDS.UnitsAddNewRow row in (UnitsAddTDS.UnitsAddNewDataTable)unitsAddChanges.UnitsAddNew)
                {
                    string type = ""; if (!row.IsTypeNull()) type = row.Type;
                    string code = row.Code;
                    string description = ""; if (!row.IsDescriptionNull()) description = row.Description;
                    string vin = ""; if (!row.IsVINNull()) vin = row.VIN;
                    string manufacturer = ""; if (!row.IsManufacturerNull()) manufacturer = row.Manufacturer;
                    string model = ""; if (!row.IsModelNull()) model = row.Model;
                    string year_ = ""; if (!row.IsYear_Null()) year_ = row.Year_;
                    bool isTowable = row.IsTowable;
                    Int64? licenseCountry = null; if (!row.IsLicenseCountryNull()) licenseCountry = row.LicenseCountry;
                    Int64? licenseState = null; if (!row.IsLicenseStateNull()) licenseState = row.LicenseState;
                    string licensePlateNumber = ""; if (!row.IsLicensePlateNumberNull()) licensePlateNumber = row.LicensePlateNumber;
                    int companyLevelId = row.CompanyLevelID;
                    string apportionedTagNumber = ""; if (!row.IsApportionedTagNumberNull()) apportionedTagNumber = row.ApportionedTagNumber;
                    
                    string categories = "";
                    
                    if (categoriesSelected.Count > 0)
                    {
                        foreach (int categoryId in categoriesSelected)
                        {
                            CategoryGateway categoryGateway = new CategoryGateway();
                            categoryGateway.LoadByCategoryId(categoryId, companyId);
                            categories = categories + categoryGateway.GetName(categoryId) + ", ";                            
                        }

                        if (categories.Length > 2)
                        {
                            categories = categories.Substring(0, categories.Length - 2);
                        }
                    }

                    Units units = new Units(null);
                    int unitId = units.InsertDirect(code, description, vin, manufacturer, model, year_, isTowable, companyLevelId, null, null, "", "", null, null, "", "", null, null, "", "Active", type, false, companyId, "", categories, "", "", null, null, null, null);
                    
                    // ... Insert vehicle info
                    if (type == "Vehicle")
                    {
                        new UnitsVehicle(null).InsertDirect(unitId, licenseCountry, licenseState, licensePlateNumber, apportionedTagNumber, "", "", "", "", "", "", "", false, false, false, companyId);
                    }

                    // Save UnitCategory
                    UpdateUnitCategory(unitId, companyId, categoriesSelected);

                    // Save Checklist
                    UnitsChecklistRulesTemp unitChecklistRulesTemp = new UnitsChecklistRulesTemp(Data);
                    unitChecklistRulesTemp.Save(unitId, companyId);
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single unit. If not exists, raise an exception
        /// </summary>
        /// <param name="unitId">internal unitID</param>
        /// <returns>Row</returns>
        private UnitsAddTDS.UnitsAddNewRow GetRow(int unitId)
        {
            UnitsAddTDS.UnitsAddNewRow row = ((UnitsAddTDS.UnitsAddNewDataTable)Table).FindByUnitID(unitId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsAddNew.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewId
        /// </summary>
        /// <returns>UnitID</returns>
        private int GetNewId()
        {
            int newId = 0;

            foreach (UnitsAddTDS.UnitsAddNewRow row in (UnitsAddTDS.UnitsAddNewDataTable)Table)
            {
                if (newId < row.UnitID)
                {
                    newId = row.UnitID;
                }
            }

            newId++;

            return newId;
        }



        /// <summary>
        /// UpdateUnitCategory
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="categoriesSelected">categoriesSelected</param>
        private void UpdateUnitCategory(int unitId, int companyId, ArrayList categoriesSelected)
        {
            CategoryGateway categoryGateway = new CategoryGateway();
            categoryGateway.Load(companyId);

            if (categoryGateway.Table.Rows.Count > 0)
            {
                foreach (CategoriesTDS.LFS_FM_CATEGORYRow row in (CategoriesTDS.LFS_FM_CATEGORYDataTable)categoryGateway.Table)
                {
                    int categoryId = row.CategoryID;

                    UnitsCategoryGateway unitsCategoryGateway = new UnitsCategoryGateway(null);

                    if (unitsCategoryGateway.IsUsedInUnitCategory(unitId, categoryId))
                    {
                        if (!categoriesSelected.Contains(categoryId))
                        {
                            UnitsCategory unitsCategory = new UnitsCategory(null);
                            unitsCategory.DeleteDirect(unitId, categoryId, companyId);
                        }
                    }
                    else
                    {
                        if (categoriesSelected.Contains(categoryId))
                        {
                            UnitsCategory unitsCategory = new UnitsCategory(null);
                            unitsCategory.InsertDirect(unitId, categoryId, false, companyId);
                        }
                    }
                }
            }
        }



    }
}