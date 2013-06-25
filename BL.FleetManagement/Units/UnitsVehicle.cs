using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitsVehicle
    /// </summary>
    public class UnitsVehicle : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsVehicle()
            : base("LFS_FM_UNIT_VEHICLE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsVehicle(DataSet data)
            : base(data, "LFS_FM_UNIT_VEHICLE")
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
        /// InsertDirect
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="licenseCountry">licenseCountry</param>
        /// <param name="licenseState">licenseState</param>
        /// <param name="licensePlateNumbver">licensePlateNumbver</param>
        /// <param name="aportionedTagNumber">aportionedTagNumber</param>
        /// <param name="actualWeight">actualWeight</param>
        /// <param name="registeredWeight">registeredWeight</param>
        /// <param name="tireSizeFront">tireSizeFront</param>
        /// <param name="tireSizeBack">tireSizeBack</param>
        /// <param name="numberOfAxes">numberOfAxes</param>
        /// <param name="fuelType">fuelType</param>
        /// <param name="beginningOdometer">beginningOdometer</param>
        /// <param name="isReeferEquipped">isReeferEquipped</param>
        /// <param name="isPTOEquipped">isPTOEquipped</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int unitId, Int64? licenseCountry, Int64? licenseState, string licensePlateNumbver, string aportionedTagNumber, string actualWeight, string registeredWeight, string tireSizeFront, string tireSizeBack, string numberOfAxes, string fuelType, string beginningOdometer, bool isReeferEquipped, bool isPTOEquipped, bool deleted, int companyId)
        {
            UnitsVehicleGateway unitsVehicleGateway = new UnitsVehicleGateway(null);
            unitsVehicleGateway.Insert(unitId, licenseCountry, licenseState, licensePlateNumbver, aportionedTagNumber, actualWeight, registeredWeight, tireSizeFront, tireSizeBack, numberOfAxes, fuelType, beginningOdometer, isReeferEquipped, isPTOEquipped, deleted, companyId);          
        }



        /// <summary>
        /// Update
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
        /// <param name="newUnitId">newUnitId</param>
        /// <param name="newLicenseCountry">newLicenseCountry</param>
        /// <param name="newLicenseState">newLicenseState</param>
        /// <param name="newLicensePlateNumbver">newLicensePlateNumbver</param>
        /// <param name="newAportionedTagNumber">newAportionedTagNumber</param>
        /// <param name="newActualWeight">newActualWeight</param>
        /// <param name="newTireSizeFront">newTireSizeFront</param>
        /// <param name="newTireSizeBack">newTireSizeBack</param>
        /// <param name="newNumberOfAxes">newNumberOfAxes</param>
        /// <param name="newFuelType">newFuelType</param>
        /// <param name="newBeginningOdometer">newBeginningOdometer</param>
        /// <param name="newIsReeferEquipped">newIsReeferEquipped</param>
        /// <param name="newIsPTOEquipped">newIsPTOEquipped</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalUnitId, Int64? originalLicenseCountry, Int64? originalLicenseState, string originalLicensePlateNumbver, string originalAportionedTagNumber, string originalActualWeight, string originalRegisteredWeight, string originalTireSizeFront, string originalTireSizeBack, string originalNumberOfAxes, string originalFuelType, string originalBeginningOdometer, bool originalIsReeferEquipped, bool originalIsPTOEquipped, bool originalDeleted, int originalCompanyId, int newUnitId, Int64? newLicenseCountry, Int64? newLicenseState, string newLicensePlateNumbver, string newAportionedTagNumber, string newActualWeight, string newRegisteredWeight, string newTireSizeFront, string newTireSizeBack, string newNumberOfAxes, string newFuelType, string newBeginningOdometer, bool newIsReeferEquipped, bool newIsPTOEquipped, bool newDeleted, int newCompanyId)
        {
            UnitsVehicleGateway unitsVehicleGateway = new UnitsVehicleGateway(null);
            unitsVehicleGateway.Update(originalUnitId, originalLicenseCountry, originalLicenseState, originalLicensePlateNumbver, originalAportionedTagNumber, originalActualWeight, originalRegisteredWeight, originalTireSizeFront, originalTireSizeBack, originalNumberOfAxes, originalFuelType, originalBeginningOdometer, originalIsReeferEquipped, originalIsPTOEquipped, originalDeleted, originalCompanyId, newUnitId, newLicenseCountry, newLicenseState, newLicensePlateNumbver, newAportionedTagNumber, newActualWeight, newRegisteredWeight, newTireSizeFront, newTireSizeBack, newNumberOfAxes, newFuelType, newBeginningOdometer, newIsReeferEquipped, newIsPTOEquipped, newDeleted, newCompanyId);
        }


        
        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int unitId, int companyId)
        {
            UnitsVehicleGateway unitsVehicleGateway = new UnitsVehicleGateway(null);
            unitsVehicleGateway.Delete(unitId, companyId);
        }

        

    }
}


