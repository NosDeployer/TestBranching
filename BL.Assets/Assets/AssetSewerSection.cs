using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.Assets.Assets
{
    /// <summary>
    /// AssetSewerSection
    /// </summary>
    public class AssetSewerSection : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AssetSewerSection() : base("AM_ASSET_SEWER_SECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AssetSewerSection(DataSet data) : base(data, "AM_ASSET_SEWER_SECTION")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new AssetsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //
               
        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="street">street</param>
        /// <param name="usmh">usmh</param>
        /// <param name="dsmh">dsmh</param>
        /// <param name="mapSize">mapSize</param>
        /// <param name="size">size</param>
        /// <param name="mapLength">mapLength</param>
        /// <param name="length">length</param>
        /// <param name="laterals">laterals</param>
        /// <param name="liveLaterals">liveLaterals</param>
        /// <param name="flowDirections">flowDirections</param>
        /// <param name="usmhDepth">usmhDepth</param>
        /// <param name="dsmhDepth">dsmhDepth</param>
        /// <param name="usmhAddress">usmhAddress</param>
        /// <param name="dsmhAddress">dsmhAddress</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="flowOrderId">flowOrderId</param>
        /// <returns>section_assetId</returns>
        public int InsertDirect(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, string sectionId, string street, int? usmh, int? dsmh, string mapSize, string size, string mapLength, string length, int? laterals, int? liveLaterals, string flowDirections, string usmhDepth, string dsmhDepth, string usmhAddress, string dsmhAddress, bool deleted, int companyId, string flowOrderId)
        {
            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
            assetSewerSectionGateway.LoadByCountryIdProvinceIdCountyIdCityIdSectionId(countryId, provinceId, countyId, cityId, sectionId, companyId);

            int section_assetId = 0;
            if (assetSewerSectionGateway.Table.Rows.Count == 0)
            {
                section_assetId = new Asset(new DataSet()).InsertDirect("Sewer", countryId, provinceId, countyId, cityId, deleted, companyId);
                new AssetSewer(new DataSet()).InsertDirect(section_assetId, "Section", deleted, companyId);
                assetSewerSectionGateway.Insert(section_assetId, sectionId, street, usmh, dsmh, mapSize, size, mapLength, length, laterals, liveLaterals, flowDirections, usmhDepth, dsmhDepth, deleted, companyId, flowOrderId);
            }
            else
            {
                section_assetId = assetSewerSectionGateway.GetAssetID(sectionId);
            }

            return section_assetId;
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="originalAssetId">originalAssetId</param>
        /// <param name="originalSectionId">originalSectionId</param>
        /// <param name="originalStreet">originalStreet</param>
        /// <param name="originalUsmh">originalUsmh</param>
        /// <param name="originalDsmh">originalDsmh</param>
        /// <param name="originalMapSize">originalMapSize</param>
        /// <param name="originalSize">originalSize</param>
        /// <param name="originalMapLength">originalMapLength</param>
        /// <param name="originalLength">originalLength</param>
        /// <param name="originalLaterals">originalLaterals</param>
        /// <param name="originalLiveLaterals">originalLiveLaterals</param>
        /// <param name="originalFlowDirection">originalFlowDirection</param>
        /// <param name="originalUsmhDepth">originalUsmhDepth</param>
        /// <param name="originalDsmhDepth">originalDsmhDepth</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalFlowOrderId">originalFlowOrderId</param>
        /// <param name="newAssetId">newAssetId</param>
        /// <param name="newSectionId">newSectionId</param>
        /// <param name="newStreet">newStreet</param>
        /// <param name="newUsmh">newUsmh</param>
        /// <param name="newDsmh">newDsmh</param>
        /// <param name="newMapSize">newMapSize</param>
        /// <param name="newSize">newSize</param>
        /// <param name="newMapLength">newMapLength</param>
        /// <param name="newLength">newLength</param>
        /// <param name="newLaterals">newLaterals</param>
        /// <param name="newLiveLaterals">newLiveLaterals</param>
        /// <param name="newFlowDirection">newFlowDirection</param>
        /// <param name="newUsmhDepth">newUsmhDepth</param>
        /// <param name="newDsmhDepth">newDsmhDepth</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newFlowOrderId">newFlowOrderId</param>
        public void UpdateDirect(int originalAssetId, string originalSectionId, string originalStreet, int? originalUsmh, int? originalDsmh, string originalMapSize, string originalSize, string originalMapLength, string originalLength, int? originalLaterals, int? originalLiveLaterals, string originalFlowDirection, string originalUsmhDepth, string originalDsmhDepth, bool originalDeleted, int originalCompanyId, string originalFlowOrderId, int newAssetId, string newSectionId, string newStreet, int? newUsmh, int? newDsmh, string newMapSize, string newSize, string newMapLength, string newLength, int? newLaterals, int? newLiveLaterals, string newFlowDirection, string newUsmhDepth, string newDsmhDepth, bool newDeleted, int newCompanyId, string newFlowOrderId)
        {
            // update section
            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway(null);
            assetSewerSectionGateway.Update(originalAssetId, originalSectionId, originalStreet, originalUsmh, originalDsmh, originalMapSize, originalSize, originalMapLength, originalLength, originalLaterals, originalLiveLaterals, originalFlowDirection, originalUsmhDepth, originalDsmhDepth, originalDeleted, originalCompanyId, originalFlowOrderId, newAssetId, newSectionId, newStreet, newUsmh, newDsmh, newMapSize, newSize, newMapLength, newLength, newLaterals, newLiveLaterals, newFlowDirection, newUsmhDepth, newDsmhDepth, newDeleted, newCompanyId, newFlowOrderId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        public bool DeleteDirect(int assetId, int companyId)
        {
            // Delete laterals
            // ... Define initial models
            AssetSewerLateral assetSewerLateral = new AssetSewerLateral(null);

            // ... Load laterals
            AssetSewerLateralGateway assetSewerLateralGateway = new AssetSewerLateralGateway();
            assetSewerLateralGateway.LoadBySectionId(assetId, companyId);

            // ... Delete laterals
            foreach (AssetsTDS.AM_ASSET_SEWER_LATERALRow rowLateral in (AssetsTDS.AM_ASSET_SEWER_LATERALDataTable)assetSewerLateralGateway.Table)
            {
                assetSewerLateral.DeleteDirect(rowLateral.AssetID, companyId);
            }

            // Delete section                
            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway(null);
            assetSewerSectionGateway.Delete(assetId, companyId);

            AssetSewer assetSewer = new AssetSewer(null);
            assetSewer.DeleteDirect(assetId, companyId);

            Asset asset = new Asset(null);
            asset.DeleteDirect(assetId, companyId);

            return true;
        }



        /// <summary>
        /// Verify if new length <= distance from usmh's laterals  
        /// </summary>
        /// <param name="newLength">newLength</param>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public bool VerifyNewLengthByAssetId(string newLength, int assetId, int companyId)
        {
            Distance newLengthDistance = new Distance(newLength);

            AssetSewerLateralGateway assetSewerLateralGateway = new AssetSewerLateralGateway();
            assetSewerLateralGateway.LoadAllBySectionId(assetId, companyId);

            foreach(AssetsTDS.AM_ASSET_SEWER_LATERALRow lateralRow in (AssetsTDS.AM_ASSET_SEWER_LATERALDataTable) assetSewerLateralGateway.Table)
            {
                Distance distanceFromUsmh = new Distance(assetSewerLateralGateway.GetDistanceFromUSMH(lateralRow.AssetID));

                Distance diference = newLengthDistance - distanceFromUsmh;
                if (diference.ToDoubleInEng3() < 0)
                {
                    return false;
                }
            }

            return true;
        }



        /// <summary>
        /// GetFlowOrderList. 
        /// </summary>        
        /// <returns>a string with all comments separeted with  the enterString</returns>
        public string GetFlowOrderList()
        {
            string flowOrderList = "";

            foreach (AssetsTDS.AM_ASSET_SEWER_SECTIONRow row in (AssetsTDS.AM_ASSET_SEWER_SECTIONDataTable)Table)
            {
                flowOrderList = flowOrderList + row.FlowOrderID + ", ";                
                flowOrderList.Substring(0, flowOrderList.Length-1);
            }

            return (flowOrderList);
        }



    }
}