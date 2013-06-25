using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// Units
    /// </summary>
    public class Units : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Units()
            : base("LFS_FM_UNIT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Units(DataSet data)
            : base(data, "LFS_FM_UNIT")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert direct to DB
        /// </summary>
        /// <param name="code">code</param>
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
        /// <param name="ownerType">ownerType</param>
        /// <param name="ownerCountry">ownerCountry</param>
        /// <param name="ownerState">ownerState</param>
        /// <param name="ownerName">ownerName</param>
        /// <param name="ownerContact">ownerContact</param>
        /// <param name="qualifiedDate">qualifiedDate</param>
        /// <param name="notQualifiedDate">notQualifiedDate</param>
        /// <param name="notQualifiedExplain">notQualifiedExplain</param>
        /// <param name="state">state</param>
        /// <param name="type">type</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="notes">notes</param>
        /// <param name="categories">categories</param>
        /// <param name="insuranceClass">insuranceClass</param>
        /// <param name="insuranceClassRyderSpecified">insuranceClassRyderSpecified</param>
        /// <param name="purchasePrice">purchasePrice</param>
        /// <param name="scrapDate">scrapDate</param>
        /// <param name="saleProceeds">saleProceeds</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <returns>unitId</returns>
        public int InsertDirect(string code, string description, string vin, string manufacturer, string model, string year_, bool isTowable, int companyLevelId, DateTime? acquisitionDate, DateTime? dispositionDate, string dispositionReason, string ownerType, Int64? ownerCountry, Int64? ownerState, string ownerName, string ownerContact, DateTime? qualifiedDate, DateTime? notQualifiedDate, string notQualifiedExplain, string state, string type, bool deleted, int companyId, string notes, string categories, string insuranceClass, string insuranceClassRyderSpecified, decimal? purchasePrice, DateTime? scrapDate, decimal? saleProceeds, int? libraryCategoriesId)
        {
            // Get unitId and insert unit
            UnitsGateway unitsGateway = new UnitsGateway(null);
            int unitId = unitsGateway.Insert(code, description, vin, manufacturer, model, year_, isTowable, companyLevelId, acquisitionDate, dispositionDate, dispositionReason, ownerType, ownerCountry, ownerState, ownerName, ownerContact, qualifiedDate, notQualifiedDate, notQualifiedExplain, state, type, deleted, companyId, notes, categories, insuranceClass, insuranceClassRyderSpecified, purchasePrice, scrapDate, saleProceeds, libraryCategoriesId);           
            
            return unitId;
        }



        /// <summary>
        /// Update a unit (direct to DB)
        /// </summary>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalCode">originalCode</param>
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
        /// <param name="newCode">newCode</param>
        /// <param name="newDescription">newDescription</param>
        /// <param name="newVin">newVin</param>
        /// <param name="newManufacturer">newManufacturer</param>
        /// <param name="newModel">newModel</param>
        /// <param name="newYear_">newYear_</param>
        /// <param name="newIsTowable">newIsTowable</param>
        /// <param name="newCompanyLevelId">newCompanyLevelId</param>
        /// <param name="newAcquisitionDate">newAcquisitionDate</param>
        /// <param name="newDispositionDate"newDispositionDate></param>
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
        public void UpdateDirect(int originalUnitId, string originalUnitCode, string originalDescription, string originalVin, string originalManufacturer, string originalModel, string originalYear_, bool originalIsTowable, int originalCompanyLevelId, DateTime? originalAcquisitionDate, DateTime? originalDispositionDate, string originalDispositionReason, string originalOwnerType, Int64? originalOwnerCountry, Int64? originalOwnerState, string originalOwnerName, string originalOwnerContact, DateTime? originalQualifiedDate, DateTime? originalNotQualifiedDate, string originalNotQualifiedExplain, string originalState, string originalType, bool originalDeleted, int originalCompanyId, string originalNotes, string originalCategories, string originalInsuranceClass, string originalInsuranceClassRyderSpecified, decimal? originalPurchasePrice, DateTime? originalScrapDate, decimal? originalSaleProceeds, int? originalLibraryCategoriesId, int newUnitId, string newUnitCode, string newDescription, string newVin, string newManufacturer, string newModel, string newYear_, bool newIsTowable, int newCompanyLevelId, DateTime? newAcquisitionDate, DateTime? newDispositionDate, string newDispositionReason, string newOwnerType, Int64? newOwnerCountry, Int64? newOwnerState, string newOwnerName, string newOwnerContact, DateTime? newQualifiedDate, DateTime? newNotQualifiedDate, string newNotQualifiedExplain, string newState, string newType, bool newDeleted, int newCompanyId, string newNotes, string newCategories, string newInsuranceClass, string newInsuranceClassRyderSpecified, decimal? newPurchasePrice, DateTime? newScrapDate, decimal? newSaleProceeds, int? newLibraryCategoriesId)
        {
            UnitsGateway unitsGateway = new UnitsGateway(null);
            unitsGateway.Update(originalUnitId, originalUnitCode, originalDescription, originalVin, originalManufacturer, originalModel, originalYear_, originalIsTowable, originalCompanyLevelId, originalAcquisitionDate, originalDispositionDate, originalDispositionReason,  originalOwnerType, originalOwnerCountry, originalOwnerState, originalOwnerName, originalOwnerContact, originalQualifiedDate, originalNotQualifiedDate, originalNotQualifiedExplain, originalState, originalType, originalDeleted, originalCompanyId, originalNotes, originalCategories, originalInsuranceClass, originalInsuranceClassRyderSpecified, originalPurchasePrice, originalScrapDate, originalSaleProceeds, originalLibraryCategoriesId, newUnitId, newUnitCode, newDescription, newVin, newManufacturer, newModel, newYear_, newIsTowable, newCompanyLevelId, newAcquisitionDate, newDispositionDate, newDispositionReason,  newOwnerType, newOwnerCountry, newOwnerState, newOwnerName, newOwnerContact, newQualifiedDate, newNotQualifiedDate, newNotQualifiedExplain, newState, newType, newDeleted, newCompanyId, newNotes, newCategories, newInsuranceClass, newInsuranceClassRyderSpecified, newPurchasePrice, newScrapDate, newSaleProceeds, newLibraryCategoriesId);
        }



        /// <summary>
        /// UpdateStateDirect
        /// </summary>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newState">newState</param>
        public void UpdateStateDirect(int originalUnitId, int originalCompanyId, string newState)
        {
            UnitsGateway unitsGateway = new UnitsGateway(null);
            unitsGateway.UpdateState(originalUnitId, originalCompanyId, newState);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="unitType">unitType</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int unitId, string unitType, int companyId)
        {
            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.LoadByUnitId(unitId,  companyId);

            if (unitsGateway.Table.Rows.Count > 0)
            {
                // ... Delete unit categories
                UnitsCategory unitsCategory = new UnitsCategory(null);                
                UnitsCategoryGateway unitsCategoryGateway = new UnitsCategoryGateway();
                unitsCategoryGateway.LoadByUnitId(unitId, companyId);

                foreach (UnitsTDS.LFS_FM_UNIT_CATEGORYRow rowCategories in (UnitsTDS.LFS_FM_UNIT_CATEGORYDataTable)unitsCategoryGateway.Table)
                {
                    unitsCategory.DeleteDirect(unitId, rowCategories.CategoryID, companyId);                    
                }

                // ... if vehicle type then delete unit
                if (unitType == "Vehicle")
                {
                    UnitsVehicle unitsVehicle = new UnitsVehicle(null);
                    unitsVehicle.DeleteDirect(unitId, companyId);
                }

                // ... Delete inspections
                UnitsInspection unitsInspection = new UnitsInspection(null);
                UnitsInspectionGateway unitsInspectionGateway = new UnitsInspectionGateway();
                unitsInspectionGateway.LoadByUnitId(unitId, companyId);

                foreach (UnitsTDS.LFS_FM_UNIT_INSPECTIONRow rowInspections in (UnitsTDS.LFS_FM_UNIT_INSPECTIONDataTable)unitsInspectionGateway.Table)
                {
                    unitsInspection.DeletedDirect(unitId, rowInspections.InspectionID, companyId);                                   
                }
                
                // ... Delete unit
                unitsGateway.Delete(unitId, companyId);
            }
        }



        /// <summary>
        /// IsInUse
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>int</returns>
        public int IsInUse(int unitId, int companyId)
        {
            UnitsGateway unitsGateway = new UnitsGateway(new DataSet());

            if (unitsGateway.IsUsedInProjectTime(unitId))
            {
                return 1;
            }

            if (unitsGateway.IsUsedInTeamProjectTime(unitId))
            {
                return 2;
            }

            if (unitsGateway.IsUsedInTeamProjectTimeDetail(unitId))
            {
                return 3;
            }

            if (unitsGateway.IsUnitWithServicesActives(unitId, companyId))
            {
                return 4;
            }

            return 0;
        }

        

    }
}