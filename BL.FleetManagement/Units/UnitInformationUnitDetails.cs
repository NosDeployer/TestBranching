using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.FleetManagement.Categories;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitInformationUnitDetails
    /// </summary>
    public class UnitInformationUnitDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitInformationUnitDetails()
            : base("UnitDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitInformationUnitDetails(DataSet data)
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






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadByUnitId(int unitId, int companyId)
        {
            UnitInformationUnitDetailsGateway unitInformationUnitDetailsGateway = new UnitInformationUnitDetailsGateway(Data);
            unitInformationUnitDetailsGateway.LoadByUnitId(unitId, companyId);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="unitCode">unitCode</param>
        /// <param name="description">description</param>
        /// <param name="vin">vin</param>
        /// <param name="manufacturer">manufacturer</param>
        /// <param name="model">model</param>
        /// <param name="year_">year_</param>
        /// <param name="isTowable">isTowable</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="acquisitionDate">acquisitionDate</param>
        /// <param name="dispositionDate">dispositionDate</param>
        /// <param name="dispositionReason">dispositionReason</param>        
        /// <param name="licenseCountry">licenseCountry</param>
        /// <param name="licenseState">licenseState</param>
        /// <param name="licensePlateNumber">licensePlateNumber</param>
        /// <param name="aportionedTagNumber">aportionedTagNumber</param>
        /// <param name="actualWeight">actualWeight</param>
        /// <param name="registeredWeight">registeredWeight</param>
        /// <param name="tireSizeFront">tireSizeFront</param>
        /// <param name="tireSizeBack">tireSizeBack</param>
        /// <param name="numberOfAxes">numberOfAxes</param>
        /// <param name="fuelType">fuelType</param>
        /// <param name="beginningOdometer">beginningOdometer</param>
        /// <param name="isReeferEquipped">isReeferEquipped</param>
        /// <param name="isPtoEquiped">isPtoEquiped</param>        
        /// <param name="ownerType">ownerType</param>
        /// <param name="ownerCountry">ownerCountry</param>
        /// <param name="ownerState">ownerState</param>
        /// <param name="ownerName">ownerName</param>
        /// <param name="ownerContact">ownerContact</param>
        /// <param name="qualifiedDate">qualifiedDate</param>
        /// <param name="notQualifiedDate">notQualifiedDate</param>
        /// <param name="notQualifiedExplain">notQualifiedExplain</param>
        /// <param name="insuranceClass">insuranceClass</param>
        /// <param name="insuranceClassRyderSpecified">insuranceClassRyderSpecified</param>
        /// <param name="purchasePrice">purchasePrice</param>
        /// <param name="scrapDate">scrapDate</param>
        /// <param name="saleProceeds">saleProceeds</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        public void Update(int unitId, string unitCode, string description, string vin, string manufacturer, string model, string year_, bool isTowable, int companyLevelId, DateTime? acquisitionDate, DateTime? dispositionDate, string dispositionReason, Int64? licenseCountry, Int64? licenseState, string licensePlateNumber, string aportionedTagNumber, string actualWeight, string registeredWeight, string tireSizeFront, string tireSizeBack, string numberOfAxes, string fuelType, string beginningOdometer, bool isReeferEquipped, bool isPtoEquiped, string ownerType, Int64? ownerCountry, Int64? ownerState, string ownerName, string ownerContact, DateTime? qualifiedDate, DateTime? notQualifiedDate, string notQualifiedExplain, string insuranceClass, string insuranceClassRyderSpecified, decimal? purchasePrice, DateTime? scrapDate, decimal? saleProceeds, int? libraryCategoriesId)
        {
            UnitInformationTDS.UnitDetailsRow row = GetRow(unitId);

            // General Data
            row.UnitCode = unitCode;
            if (description.Trim() != "") row.Description = description; else row.SetDescriptionNull();
            if (vin.Trim() != "") row.VIN = vin; else row.SetVINNull();
            if (manufacturer.Trim() != "") row.Manufacturer = manufacturer; else row.SetManufacturerNull();
            if (model.Trim() != "") row.Model = model; else row.SetModelNull();
            if (year_.Trim() != "") row.Year_ = year_; else row.SetYear_Null();
            row.IsTowable = isTowable;
            row.CompanyLevelID = companyLevelId;
            if (acquisitionDate.HasValue) row.AcquisitionDate = (DateTime)acquisitionDate; else row.SetAcquisitionDateNull();
            if (dispositionDate.HasValue) row.DispositionDate = (DateTime)dispositionDate; else row.SetDispositionDateNull();
            if (dispositionReason.Trim() != "") row.DispositionReason = dispositionReason; else row.SetDispositionReasonNull();            
            if (ownerType.Trim() != "") row.OwnerType = ownerType; else row.SetOwnerTypeNull();
            if (ownerCountry.HasValue) row.OwnerCountry = (Int64)ownerCountry; else row.SetOwnerCountryNull();
            if (ownerState.HasValue) row.OwnerState = (Int64)ownerState; else row.SetOwnerStateNull();
            if (ownerName.Trim() != "") row.OwnerName = ownerName; else row.SetOwnerNameNull();
            if (ownerContact.Trim() != "") row.OwnerContact = ownerContact; else row.SetOwnerContactNull();
            if (qualifiedDate.HasValue) row.QualifiedDate = (DateTime)qualifiedDate; else row.SetQualifiedDateNull();
            if (notQualifiedDate.HasValue) row.NotQualifiedDate = (DateTime)notQualifiedDate; else row.SetNotQualifiedDateNull();
            if (notQualifiedExplain.Trim() != "") row.NotQualifiedExplain = notQualifiedExplain; else row.SetNotQualifiedExplainNull();
            if (insuranceClass.Trim() != "") row.InsuranceClass = insuranceClass; else row.SetInsuranceClassNull();
            if (insuranceClassRyderSpecified.Trim() != "") row.InsuranceClassRyderSpecified = insuranceClassRyderSpecified; else row.SetInsuranceClassRyderSpecifiedNull();
            if (purchasePrice.HasValue) row.PurchasePrice = purchasePrice.Value; else row.SetPurchasePriceNull();
            if (scrapDate.HasValue) row.ScrapDate = (DateTime)scrapDate; else row.SetScrapDateNull();
            if (saleProceeds.HasValue) row.SaleProceeds = saleProceeds.Value; else row.SetSaleProceedsNull();

            // Vehicle Info
            if (licenseCountry.HasValue) row.LicenseCountry = (Int64)licenseCountry; else row.SetLicenseCountryNull();
            if (licenseState.HasValue) row.LicenseState = (Int64)licenseState; else row.SetLicenseStateNull();
            if (licensePlateNumber.Trim() != "") row.LicensePlateNumbver = licensePlateNumber; else row.SetLicensePlateNumbverNull();
            if (aportionedTagNumber.Trim() != "") row.AportionedTagNumber = aportionedTagNumber; else row.SetAportionedTagNumberNull();
            if (actualWeight.Trim() != "") row.ActualWeight = actualWeight; else row.SetActualWeightNull();
            if (registeredWeight.Trim() != "") row.RegisteredWeight = registeredWeight; else row.SetRegisteredWeightNull();
            if (tireSizeFront.Trim() != "") row.TireSizeFront = tireSizeFront; else row.SetTireSizeFrontNull();
            if (tireSizeBack.Trim() != "") row.TireSizeBack = tireSizeBack; else row.SetTireSizeBackNull();
            if (numberOfAxes.Trim() != "") row.NumberOfAxes = numberOfAxes; else row.SetNumberOfAxesNull();
            if (fuelType.Trim() != "") row.FuelType = fuelType; else row.SetFuelTypeNull();
            if (beginningOdometer.Trim() != "") row.BeginningOdometer = beginningOdometer; else row.SetBeginningOdometerNull();
            row.IsReeferEquipped = isReeferEquipped;
            row.IsPTOEquipped = isPtoEquiped;            
        }



        /// <summary>
        /// UpdateState
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="state">="</param>
        public void UpdateState(int unitId, string state)
        {
            UnitInformationTDS.UnitDetailsRow row = GetRow(unitId);
            row.State = state;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="unitId">unitId</param>
        public void Delete(int unitId)
        {
            UnitInformationTDS.UnitDetailsRow row = GetRow(unitId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="unitType">unitType</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int unitId, string unitType, int companyId)
        {
            Units units = new Units(null);
            units.DeleteDirect(unitId, unitType, companyId);
        }



        /// <summary>
        /// UpdateLibraryCategoriesId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        public void UpdateLibraryCategoriesId(int unitId, int? libraryCategoriesId)
        {
            UnitInformationTDS.UnitDetailsRow row = GetRow(unitId);
            if (libraryCategoriesId.HasValue) row.LIBRARY_CATEGORIES_ID = (int)libraryCategoriesId; else row.SetLIBRARY_CATEGORIES_IDNull();
        }


        
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="categoriesSelected">categoriesSelected</param>
        /// <param name="companyId">companyId</param>
        public void Save(ArrayList categoriesSelected, int companyId)
        {
            UnitInformationTDS unitsInformationChanges = (UnitInformationTDS)Data.GetChanges();

            if (unitsInformationChanges.UnitDetails.Rows.Count > 0)
            {
                UnitInformationUnitDetailsGateway unitInformationUnitDetailsGateway = new UnitInformationUnitDetailsGateway(unitsInformationChanges);

                // Update unit
                foreach (UnitInformationTDS.UnitDetailsRow unitDetailsRow in (UnitInformationTDS.UnitDetailsDataTable)unitsInformationChanges.UnitDetails)
                {
                    // Unchanged values
                    int unitId = unitDetailsRow.UnitID;
                    string state = unitInformationUnitDetailsGateway.GetState(unitId);
                    string type = unitInformationUnitDetailsGateway.GetType(unitId);
                    bool deleted = false;
                    string notes = ""; if (!unitDetailsRow.IsNotesNull()) notes = unitDetailsRow.Notes;
                    string originalCategories = ""; if (!unitDetailsRow.IsCategoriesNull()) originalCategories = unitDetailsRow.Categories;
                                        
                    // Original Unit values
                    string originalUnitCode = unitInformationUnitDetailsGateway.GetUnitCodeOriginal(unitId);
                    string originalDescription = unitInformationUnitDetailsGateway.GetDescriptionOriginal(unitId);
                    string originalVin = unitInformationUnitDetailsGateway.GetVinOriginal(unitId);
                    string originalManufacturer = unitInformationUnitDetailsGateway.GetManufacturerOriginal(unitId);
                    string originalModel = unitInformationUnitDetailsGateway.GetModelOriginal(unitId);
                    string originalYear_ = unitInformationUnitDetailsGateway.GetYear_Original(unitId);
                    bool originalIsTowable = unitInformationUnitDetailsGateway.GetIsTowableOriginal(unitId);
                    int originalCompanyLevelId = unitInformationUnitDetailsGateway.GetCompanyLevelIdOriginal(unitId);
                    DateTime? originalAcquisitionDate = null; if (unitInformationUnitDetailsGateway.GetAcquisitionDateOriginal(unitId).HasValue) originalAcquisitionDate = (DateTime)unitInformationUnitDetailsGateway.GetAcquisitionDateOriginal(unitId);
                    DateTime? originalDispositionDate = null; if (unitInformationUnitDetailsGateway.GetDispositionDateOriginal(unitId).HasValue) originalDispositionDate = (DateTime)unitInformationUnitDetailsGateway.GetDispositionDateOriginal(unitId);
                    string originalDispositionReason = unitInformationUnitDetailsGateway.GetDispositionReasonOriginal(unitId);
                    string originalOwnerType = unitInformationUnitDetailsGateway.GetOwnerTypeOriginal(unitId);
                    Int64? originalOwnerCountry = null; if (unitInformationUnitDetailsGateway.GetOwnerCountryOriginal(unitId).HasValue) originalOwnerCountry = (Int64)unitInformationUnitDetailsGateway.GetOwnerCountryOriginal(unitId);
                    Int64? originalOwnerState = null; if (unitInformationUnitDetailsGateway.GetOwnerStateOriginal(unitId).HasValue) originalOwnerState = (Int64)unitInformationUnitDetailsGateway.GetOwnerStateOriginal(unitId);
                    string originalOwnerName = unitInformationUnitDetailsGateway.GetOwnerNameOriginal(unitId);
                    string originalOwnerContact = unitInformationUnitDetailsGateway.GetOwnerContactOriginal(unitId);
                    DateTime? originalQualifiedDate = null; if (unitInformationUnitDetailsGateway.GetQualifiedDateOriginal(unitId).HasValue) originalQualifiedDate = (DateTime)unitInformationUnitDetailsGateway.GetQualifiedDateOriginal(unitId);
                    DateTime? originalNotQualifiedDate = null; if (unitInformationUnitDetailsGateway.GetNotQualifiedDateOriginal(unitId).HasValue) originalNotQualifiedDate = (DateTime)unitInformationUnitDetailsGateway.GetNotQualifiedDateOriginal(unitId);
                    string originalNotQualifiedExplain = unitInformationUnitDetailsGateway.GetNotQualifiedExplainOriginal(unitId);
                    string originalInsuranceClass = unitInformationUnitDetailsGateway.GetInsuranceClassOriginal(unitId);
                    string originalInsuranceClassRyderSpecified = unitInformationUnitDetailsGateway.GetInsuranceClassRyderSpecifiedOriginal(unitId);
                    decimal? originalPurchasePrice = null; if (unitInformationUnitDetailsGateway.GetPurchasePriceOriginal(unitId).HasValue) originalPurchasePrice = unitInformationUnitDetailsGateway.GetPurchasePriceOriginal(unitId).Value;
                    DateTime? originalScrapDate = null; if (unitInformationUnitDetailsGateway.GetScrapDateOriginal(unitId).HasValue) originalScrapDate = (DateTime)unitInformationUnitDetailsGateway.GetScrapDateOriginal(unitId);
                    decimal? originalSaleProceeds = null; if (unitInformationUnitDetailsGateway.GetSaleProceedsOriginal(unitId).HasValue) originalSaleProceeds = unitInformationUnitDetailsGateway.GetSaleProceedsOriginal(unitId).Value;
                    int? originalLibraryCategoriesId = null; if (unitInformationUnitDetailsGateway.GetLibraryCategoriesIdOriginal(unitId).HasValue) originalLibraryCategoriesId = unitInformationUnitDetailsGateway.GetLibraryCategoriesIdOriginal(unitId).Value;
                    
                    // New Unit values
                    string newUnitCode = unitInformationUnitDetailsGateway.GetUnitCode(unitId);
                    string newDescription = unitInformationUnitDetailsGateway.GetDescription(unitId);
                    string newVin = unitInformationUnitDetailsGateway.GetVin(unitId);
                    string newManufacturer = unitInformationUnitDetailsGateway.GetManufacturer(unitId);
                    string newModel = unitInformationUnitDetailsGateway.GetModel(unitId);
                    string newYear_ = unitInformationUnitDetailsGateway.GetYear_(unitId);
                    bool newIsTowable = unitInformationUnitDetailsGateway.GetIsTowable(unitId);
                    int newCompanyLevelId = unitInformationUnitDetailsGateway.GetCompanyLevelId(unitId);
                    DateTime? newAcquisitionDate = null; if (unitInformationUnitDetailsGateway.GetAcquisitionDate(unitId).HasValue) newAcquisitionDate = (DateTime)unitInformationUnitDetailsGateway.GetAcquisitionDate(unitId);
                    DateTime? newDispositionDate = null; if (unitInformationUnitDetailsGateway.GetDispositionDate(unitId).HasValue) newDispositionDate = (DateTime)unitInformationUnitDetailsGateway.GetDispositionDate(unitId);
                    string newDispositionReason = unitInformationUnitDetailsGateway.GetDispositionReason(unitId);
                    string newOwnerType = unitInformationUnitDetailsGateway.GetOwnerType(unitId);
                    Int64? newOwnerCountry = null; if (unitInformationUnitDetailsGateway.GetOwnerCountry(unitId).HasValue) newOwnerCountry = (Int64)unitInformationUnitDetailsGateway.GetOwnerCountry(unitId);
                    Int64? newOwnerState = null; if (unitInformationUnitDetailsGateway.GetOwnerState(unitId).HasValue) newOwnerState = (Int64)unitInformationUnitDetailsGateway.GetOwnerState(unitId);
                    string newOwnerName = unitInformationUnitDetailsGateway.GetOwnerName(unitId);
                    string newOwnerContact = unitInformationUnitDetailsGateway.GetOwnerContact(unitId);
                    DateTime? newQualifiedDate = null; if (unitInformationUnitDetailsGateway.GetQualifiedDate(unitId).HasValue) newQualifiedDate = (DateTime)unitInformationUnitDetailsGateway.GetQualifiedDate(unitId);
                    DateTime? newNotQualifiedDate = null; if (unitInformationUnitDetailsGateway.GetNotQualifiedDate(unitId).HasValue) newNotQualifiedDate = (DateTime)unitInformationUnitDetailsGateway.GetNotQualifiedDate(unitId);
                    string newNotQualifiedExplain = unitInformationUnitDetailsGateway.GetNotQualifiedExplain(unitId);

                    string newCategories = "";

                    if (categoriesSelected.Count > 0)
                    {
                        foreach (int categoryId in categoriesSelected)
                        {
                            CategoryGateway categoryGateway = new CategoryGateway();
                            categoryGateway.LoadByCategoryId(categoryId, companyId);
                            newCategories = newCategories + categoryGateway.GetName(categoryId) + ", ";
                        }

                        if (newCategories.Length > 2)
                        {
                            newCategories = newCategories.Substring(0, newCategories.Length - 2);
                        }
                    }

                    string newInsuranceClass = unitInformationUnitDetailsGateway.GetInsuranceClass(unitId);
                    string newInsuranceClassRyderSpecified = unitInformationUnitDetailsGateway.GetInsuranceClassRyderSpecified(unitId);
                    decimal? newPurchasePrice = null; if (unitInformationUnitDetailsGateway.GetPurchasePrice(unitId).HasValue) newPurchasePrice = unitInformationUnitDetailsGateway.GetPurchasePrice(unitId).Value;
                    DateTime? newScrapDate = null; if (unitInformationUnitDetailsGateway.GetScrapDate(unitId).HasValue) newScrapDate = (DateTime)unitInformationUnitDetailsGateway.GetScrapDate(unitId);
                    decimal? newSaleProceeds = null; if (unitInformationUnitDetailsGateway.GetSaleProceeds(unitId).HasValue) newSaleProceeds = unitInformationUnitDetailsGateway.GetSaleProceeds(unitId).Value;
                    int? newLibraryCategoriesId = null; if (unitInformationUnitDetailsGateway.GetLibraryCategoriesId(unitId).HasValue) newLibraryCategoriesId = unitInformationUnitDetailsGateway.GetLibraryCategoriesId(unitId).Value;

                    // Update unit
                    UpdateUnit(unitId, originalUnitCode, originalDescription, originalVin, originalManufacturer, originalModel, originalYear_, originalIsTowable, originalCompanyLevelId, originalAcquisitionDate, originalDispositionDate, originalDispositionReason,  originalOwnerType, originalOwnerCountry, originalOwnerState, originalOwnerName, originalOwnerContact, originalQualifiedDate, originalNotQualifiedDate, originalNotQualifiedExplain, state, type, deleted, companyId, notes, originalCategories, originalInsuranceClass, originalInsuranceClassRyderSpecified, originalPurchasePrice, originalScrapDate, originalSaleProceeds, originalLibraryCategoriesId, unitId, newUnitCode, newDescription, newVin, newManufacturer, newModel, newYear_, newIsTowable, newCompanyLevelId, newAcquisitionDate, newDispositionDate, newDispositionReason,  newOwnerType, newOwnerCountry, newOwnerState, newOwnerName, newOwnerContact, newQualifiedDate, newNotQualifiedDate, newNotQualifiedExplain, state, type, deleted, companyId, notes, newCategories, newInsuranceClass, newInsuranceClassRyderSpecified, newPurchasePrice, newScrapDate, newSaleProceeds, newLibraryCategoriesId);
                    UpdateUnitCategory(unitId, companyId, categoriesSelected, newCompanyLevelId);
                    
                    if (type == "Vehicle")
                    {
                        // Original Unit Vehicle values
                        Int64? originalLicenseCountry = null; if (unitInformationUnitDetailsGateway.GetLicenseCountryOriginal(unitId).HasValue) originalLicenseCountry = (Int64)unitInformationUnitDetailsGateway.GetLicenseCountryOriginal(unitId);
                        Int64? originalLicenseState = null; if (unitInformationUnitDetailsGateway.GetLicenseStateOriginal(unitId).HasValue) originalLicenseState = (Int64)unitInformationUnitDetailsGateway.GetLicenseStateOriginal(unitId);
                        string originalLicensePlateNumber = unitInformationUnitDetailsGateway.GetLicensePlateNumbverOriginal(unitId);
                        string originalAportionedTagNumber = unitInformationUnitDetailsGateway.GetAportionedTagNumberOriginal(unitId);
                        string originalActualWeight = unitInformationUnitDetailsGateway.GetActualWeightOriginal(unitId);
                        string originalRegisteredWeight = unitInformationUnitDetailsGateway.GetRegisteredWeightOriginal(unitId);
                        string originalTireSizeFront = unitInformationUnitDetailsGateway.GetTireSizeFrontOriginal(unitId);
                        string originalTireSizeBack = unitInformationUnitDetailsGateway.GetTireSizeBackOriginal(unitId);
                        string originalNumberOfAxes = unitInformationUnitDetailsGateway.GetNumberOfAxesOriginal(unitId);
                        string originalFuelType = unitInformationUnitDetailsGateway.GetFuelTypeOriginal(unitId);
                        string originalBeginningOdometer = unitInformationUnitDetailsGateway.GetBeginningOdometerOriginal(unitId);
                        bool originalIsReeferEquipped = unitInformationUnitDetailsGateway.GetIsReeferEquippedOriginal(unitId);
                        bool originalIsPtoEquipped = unitInformationUnitDetailsGateway.GetIsPTOEquippedOriginal(unitId);

                        // New Unit Vehicle values
                        Int64? newLicenseCountry = null; if (unitInformationUnitDetailsGateway.GetLicenseCountry(unitId).HasValue) newLicenseCountry = (Int64)unitInformationUnitDetailsGateway.GetLicenseCountry(unitId);
                        Int64? newLicenseState = null; if (unitInformationUnitDetailsGateway.GetLicenseState(unitId).HasValue) newLicenseState = (Int64)unitInformationUnitDetailsGateway.GetLicenseState(unitId);
                        string newLicensePlateNumber = unitInformationUnitDetailsGateway.GetLicensePlateNumbver(unitId);
                        string newAportionedTagNumber = unitInformationUnitDetailsGateway.GetAportionedTagNumber(unitId);
                        string newActualWeight = unitInformationUnitDetailsGateway.GetActualWeight(unitId);
                        string newRegisteredWeight = unitInformationUnitDetailsGateway.GetRegisteredWeight(unitId);
                        string newTireSizeFront = unitInformationUnitDetailsGateway.GetTireSizeFront(unitId);
                        string newTireSizeBack = unitInformationUnitDetailsGateway.GetTireSizeBack(unitId);
                        string newNumberOfAxes = unitInformationUnitDetailsGateway.GetNumberOfAxes(unitId);
                        string newFuelType = unitInformationUnitDetailsGateway.GetFuelType(unitId);
                        string newBeginningOdometer = unitInformationUnitDetailsGateway.GetBeginningOdometer(unitId);
                        bool newIsReeferEquipped = unitInformationUnitDetailsGateway.GetIsReeferEquipped(unitId);
                        bool newIsPtoEquipped = unitInformationUnitDetailsGateway.GetIsPTOEquipped(unitId);

                        UpdateUnitVehicle(unitId, originalLicenseCountry, originalLicenseState, originalLicensePlateNumber, originalAportionedTagNumber, originalActualWeight, originalRegisteredWeight, originalTireSizeFront, originalTireSizeBack, originalNumberOfAxes, originalFuelType, originalBeginningOdometer, originalIsReeferEquipped, originalIsPtoEquipped, deleted, companyId, unitId, newLicenseCountry, newLicenseState, newLicensePlateNumber, newAportionedTagNumber, newActualWeight, newRegisteredWeight, newTireSizeFront, newTireSizeBack, newNumberOfAxes, newFuelType, newBeginningOdometer, newIsReeferEquipped, newIsPtoEquipped, deleted, companyId);
                    }
                }
            }
        }



        /// <summary>
        /// SaveState
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="newState">newState</param>
        public void SaveState(int companyId, string newState)
        {
            UnitInformationTDS unitsInformationChanges = (UnitInformationTDS)Data.GetChanges();

            if (unitsInformationChanges.UnitDetails.Rows.Count > 0)
            {
                UnitInformationUnitDetailsGateway unitInformationUnitDetailsGateway = new UnitInformationUnitDetailsGateway(unitsInformationChanges);

                // Update unit state
                foreach (UnitInformationTDS.UnitDetailsRow unitDetailsRow in (UnitInformationTDS.UnitDetailsDataTable)unitsInformationChanges.UnitDetails)
                {
                    // Unchanged values
                    int unitId = unitDetailsRow.UnitID;
                    string state = unitDetailsRow.State;

                    UpdateUnitState(unitId, companyId, state);

                    if (newState == "Disposed")
                    {
                        DeleteChecklists(unitId, companyId);
                    }

                    if (newState == "Removed")
                    {
                        DeleteChecklists(unitId, companyId);
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
        
        /// <summary>
        /// UpdateUnit
        /// </summary>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalUnitCode"originalUnitCode></param>
        /// <param name="originalDescription">originalDescription</param>
        /// <param name="originalVin">originalVin</param>
        /// <param name="originalManufacturer">originalManufacturer</param>
        /// <param name="originalModel">originalModel</param>
        /// <param name="originalYear_">originalYear_</param>
        /// <param name="originalIsTowable">originalIsTowable</param>
        /// <param name="originalCompanyLevelId">originalCompanyLevelId</param>
        /// <param name="originalAcquisitionDate">originalAcquisitionDate</param>
        /// <param name="originalDispositionDate">originalDispositionDate</param>
        /// <param name="originalDispositionReason">originalDispositionReason</param>        
        /// <param name="originalOwnerType">originalOwnerType</param>
        /// <param name="originalOwnerCountry">originalOwnerCountry</param>
        /// <param name="originalOwnerState">originalOwnerState</param>
        /// <param name="originalOwnerName">originalOwnerName</param>
        /// <param name="originalOwnerContact">originalOwnerContact</param>
        /// <param name="originalQualifiedDate">originalQualifiedDate</param>
        /// <param name="originalNotQualifiedDate">originalNotQualifiedDate</param>
        /// <param name="originalNotQualifiedExplain">originalNotQualifiedExplain</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalNotes">originalNotes</param>
        /// <param name="originalCategories">originalCategories</param>
        /// <param name="originalInsuranceClass">originalInsuranceClass</param>
        /// <param name="originalInsuranceClassRyderSpecified">originalInsuranceClassRyderSpecified</param>
        /// <param name="originalPurchasePrice">originalPurchasePrice</param>
        /// <param name="originalSaleProceeds">originalSaleProceeds</param>
        /// <param name="originalScrapDate">originalScrapDate</param>
        /// <param name="originalLibraryCategoriesId">originalLibraryCategoriesId</param>
        /// 
        /// <param name="newUnitId">newUnitId</param>
        /// <param name="newUnitCode">newUnitCode</param>
        /// <param name="newDescription">newDescription</param>
        /// <param name="newVin">newVin</param>
        /// <param name="newManufacturer">newManufacturer</param>
        /// <param name="newModel">newModel</param>
        /// <param name="newYear_">newYear_</param>
        /// <param name="newIsTowable">newIsTowable</param>
        /// <param name="newCompanyLevelId">newCompanyLevelId</param>
        /// <param name="newAcquisitionDate">newAcquisitionDate</param>
        /// <param name="newDispositionDate">newDispositionDate</param>
        /// <param name="newDispositionReason">newDispositionReason</param>        
        /// <param name="newOwnerType">newOwnerType</param>
        /// <param name="newOwnerCountry">newOwnerCountry</param>
        /// <param name="newOwnerState">newOwnerState</param>
        /// <param name="newOwnerName">newOwnerName</param>
        /// <param name="newOwnerContact">newOwnerContact</param>
        /// <param name="newQualifiedDate">newQualifiedDate</param>
        /// <param name="newNotQualifiedDate">newNotQualifiedDate</param>
        /// <param name="newNotQualifiedExplain">newNotQualifiedExplain</param>
        /// <param name="newState">newState</param>
        /// <param name="newType">newType</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newNotes">newNotes</param>
        /// <param name="newCategories">newCategories</param>
        /// <param name="newInsuranceClass">newInsuranceClass</param>
        /// <param name="newInsuranceClassRyderSpecified">newInsuranceClassRyderSpecified</param>
        /// <param name="newPurchasePrice">newPurchasePrice</param>
        /// <param name="newSaleProceeds">newSaleProceeds</param>
        /// <param name="newScrapDate">newScrapDate</param>
        /// <param name="newLibraryCategoriesId">newLibraryCategoriesId</param>
        private void UpdateUnit(int originalUnitId, string originalUnitCode, string originalDescription, string originalVin, string originalManufacturer, string originalModel, string originalYear_, bool originalIsTowable, int originalCompanyLevelId, DateTime? originalAcquisitionDate, DateTime? originalDispositionDate, string originalDispositionReason, string originalOwnerType, Int64? originalOwnerCountry, Int64? originalOwnerState, string originalOwnerName, string originalOwnerContact, DateTime? originalQualifiedDate, DateTime? originalNotQualifiedDate, string originalNotQualifiedExplain, string originalState, string originalType, bool originalDeleted, int originalCompanyId, string originalNotes, string originalCategories, string originalInsuranceClass, string originalInsuranceClassRyderSpecified, decimal? originalPurchasePrice, DateTime? originalScrapDate, decimal? originalSaleProceeds, int? originalLibraryCategoriesId, int newUnitId, string newUnitCode, string newDescription, string newVin, string newManufacturer, string newModel, string newYear_, bool newIsTowable, int newCompanyLevelId, DateTime? newAcquisitionDate, DateTime? newDispositionDate, string newDispositionReason, string newOwnerType, Int64? newOwnerCountry, Int64? newOwnerState, string newOwnerName, string newOwnerContact, DateTime? newQualifiedDate, DateTime? newNotQualifiedDate, string newNotQualifiedExplain, string newState, string newType, bool newDeleted, int newCompanyId, string newNotes, string newCategories, string newInsuranceClass, string newInsuranceClassRyderSpecified, decimal? newPurchasePrice, DateTime? newScrapDate, decimal? newSaleProceeds, int? newLibraryCategoriesId)
        {
            Units units = new Units(null);
            units.UpdateDirect(originalUnitId, originalUnitCode, originalDescription, originalVin, originalManufacturer, originalModel, originalYear_, originalIsTowable, originalCompanyLevelId, originalAcquisitionDate, originalDispositionDate, originalDispositionReason,  originalOwnerType, originalOwnerCountry, originalOwnerState, originalOwnerName, originalOwnerContact, originalQualifiedDate, originalNotQualifiedDate, originalNotQualifiedExplain, originalState, originalType, originalDeleted, originalCompanyId, originalNotes, originalCategories, originalInsuranceClass, originalInsuranceClassRyderSpecified, originalPurchasePrice, originalScrapDate, originalSaleProceeds, originalLibraryCategoriesId, newUnitId, newUnitCode, newDescription, newVin, newManufacturer, newModel, newYear_, newIsTowable, newCompanyLevelId, newAcquisitionDate, newDispositionDate, newDispositionReason, newOwnerType, newOwnerCountry, newOwnerState, newOwnerName, newOwnerContact, newQualifiedDate, newNotQualifiedDate, newNotQualifiedExplain, newState, newType, newDeleted, newCompanyId, newNotes, newCategories, newInsuranceClass, newInsuranceClassRyderSpecified, newPurchasePrice, newScrapDate, newSaleProceeds, newLibraryCategoriesId);
        }



        /// <summary>
        /// UpdateUnitState
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="state">state</param>
        private void UpdateUnitState(int unitId, int companyId, string state)
        {
            Units units = new Units(null);
            units.UpdateStateDirect(unitId, companyId, state);
        }



        /// <summary>
        /// UpdateUnitCategory
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="categoriesSelected">categoriesSelected</param>
        /// <param name="companyLevelId">companyLevelId</param>
        private void UpdateUnitCategory(int unitId, int companyId, ArrayList categoriesSelected, int companyLevelId)
        {
            RuleCategoryUnitsGateway ruleCategoryUnitsGateway = new RuleCategoryUnitsGateway(null);

            CategoryGateway categoryGateway = new CategoryGateway();
            categoryGateway.Load(companyId);

            if (categoryGateway.Table.Rows.Count > 0)
            {
                foreach (CategoriesTDS.LFS_FM_CATEGORYRow row in (CategoriesTDS.LFS_FM_CATEGORYDataTable)categoryGateway.Table)
                {
                    int categoryId = row.CategoryID;

                    UnitsCategoryGateway unitsCategoryGateway = new UnitsCategoryGateway(null);

                    // Exists in DB
                    if (unitsCategoryGateway.IsUsedInUnitCategory(unitId, categoryId, true))
                    {
                        if (!categoriesSelected.Contains(categoryId))
                        {
                            UnitsCategory unitsCategory = new UnitsCategory(null);
                            unitsCategory.DeleteDirect(unitId, categoryId, companyId);

                            RuleCategoryGateway ruleCategoryGateway = new RuleCategoryGateway();
                            ruleCategoryGateway.LoadByCategoryId(categoryId, companyId);

                            foreach (RuleTDS.LFS_FM_RULE_CATEGORYRow rowRuleCategory in (RuleTDS.LFS_FM_RULE_CATEGORYDataTable)ruleCategoryGateway.Table)
                            {
                                int ruleId = rowRuleCategory.RuleID;

                                if (ruleCategoryUnitsGateway.IsUsedInRuleCategoryUnits(ruleId, categoryId, unitId))
                                {
                                    // Delete
                                    RuleCategoryUnits ruleCategoryUnits = new RuleCategoryUnits(null);
                                    ruleCategoryUnits.DeleteDirect(ruleId, categoryId, unitId, companyId);
                                }
                            }
                        }
                        else
                        {
                            UnitsCategory unitsCategory = new UnitsCategory(null);
                            unitsCategory.UnDeleteDirect(unitId, categoryId, companyId);
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

        
        
        /// <summary>
        /// UpdateUnitVehicle
        /// </summary>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalLicenseCountry">originalLicenseCountry</param>
        /// <param name="originalLicenseState">originalLicenseState</param>
        /// <param name="originalLicensePlateNumbver">originalLicensePlateNumbver</param>
        /// <param name="originalAportionedTagNumber">originalAportionedTagNumber</param>
        /// <param name="originalActualWeight">originalActualWeight</param>
        /// <param name="originalRegisteredWeight">originalRegisteredWeight</param>
        /// <param name="originalTireSizeFront">originalTireSizeFront</param>
        /// <param name="originalTireSizeBack">originalTireSizeBack</param>
        /// <param name="originalNumberOfAxes">originalNumberOfAxes</param>
        /// <param name="originalFuelType">originalFuelType</param>
        /// <param name="originalBeginningOdometer">originalBeginningOdometer</param>
        /// <param name="originalIsReeferEquipped">originalIsReeferEquipped</param>
        /// <param name="originalIsPTOEquipped">originalIsPTOEquipped</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newUnitId">newUnitId</param>
        /// <param name="newLicenseCountry">newLicenseCountry</param>
        /// <param name="newLicenseState">newLicenseState</param>
        /// <param name="newLicensePlateNumbver">newLicensePlateNumbver</param>
        /// <param name="newAportionedTagNumber">newAportionedTagNumber</param>
        /// <param name="newActualWeight">newActualWeight</param>
        /// <param name="newRegisteredWeight">newRegisteredWeight</param>
        /// <param name="newTireSizeFront">newTireSizeFront</param>
        /// <param name="newTireSizeBack">newTireSizeBack</param>
        /// <param name="newNumberOfAxes">newNumberOfAxes</param>
        /// <param name="newFuelType">newFuelType</param>
        /// <param name="newBeginningOdometer">newBeginningOdometer</param>
        /// <param name="newIsReeferEquipped">newIsReeferEquipped</param>
        /// <param name="newIsPTOEquipped">newIsPTOEquipped</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        private void UpdateUnitVehicle(int originalUnitId, Int64? originalLicenseCountry, Int64? originalLicenseState, string originalLicensePlateNumbver, string originalAportionedTagNumber, string originalActualWeight, string originalRegisteredWeight, string originalTireSizeFront, string originalTireSizeBack, string originalNumberOfAxes, string originalFuelType, string originalBeginningOdometer, bool originalIsReeferEquipped, bool originalIsPTOEquipped, bool originalDeleted, int originalCompanyId, int newUnitId, Int64? newLicenseCountry, Int64? newLicenseState, string newLicensePlateNumbver, string newAportionedTagNumber, string newActualWeight, string newRegisteredWeight, string newTireSizeFront, string newTireSizeBack, string newNumberOfAxes, string newFuelType, string newBeginningOdometer, bool newIsReeferEquipped, bool newIsPTOEquipped, bool newDeleted, int newCompanyId)
        {
            UnitsVehicle unitsVehicle = new UnitsVehicle(null);
            unitsVehicle.UpdateDirect(originalUnitId, originalLicenseCountry, originalLicenseState, originalLicensePlateNumbver, originalAportionedTagNumber, originalActualWeight, originalRegisteredWeight, originalTireSizeFront, originalTireSizeBack, originalNumberOfAxes, originalFuelType, originalBeginningOdometer, originalIsReeferEquipped, originalIsPTOEquipped, originalDeleted, originalCompanyId, newUnitId, newLicenseCountry, newLicenseState, newLicensePlateNumbver, newAportionedTagNumber, newActualWeight, newRegisteredWeight, newTireSizeFront, newTireSizeBack, newNumberOfAxes, newFuelType, newBeginningOdometer, newIsReeferEquipped, newIsPTOEquipped, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteChecklists
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        private void DeleteChecklists(int unitId, int companyId)
        {
            ChecklistGateway checklistGateway = new ChecklistGateway(null);

            if (checklistGateway.IsUnitUsedInChecklist(unitId))
            {
                // Delete all checklists for unitId
                Checklist checklist = new Checklist(null);
                checklist.DeleteDirectByUnitId(unitId, companyId);
            }
        }



        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Obtained row</returns>
        private UnitInformationTDS.UnitDetailsRow GetRow(int unitId)
        {
            UnitInformationTDS.UnitDetailsRow row = ((UnitInformationTDS.UnitDetailsDataTable)Table).FindByUnitID(unitId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Units.UnitInformationUnitDetails.GetRow");
            }

            return row;
        }

        
        
    }
}