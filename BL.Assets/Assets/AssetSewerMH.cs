using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Assets.Assets;

namespace LiquiForce.LFSLive.BL.Assets.Assets
{
    /// <summary>
    /// AssetSewerMH
    /// </summary>
    public class AssetSewerMH : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AssetSewerMH() : base("AM_ASSET_SEWER_MH")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AssetSewerMH(DataSet data) : base(data, "AM_ASSET_SEWER_MH")
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
        /// <param name="mhid">mhid</param>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <param name="address">address</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="manholeShape">manholeShape</param>
        /// <param name="location">location</param>
        /// <param name="materialID">materialID</param>
        /// <param name="topDiameter">topDiameter</param>
        /// <param name="topDepth">topDepth</param>
        /// <param name="topFloor">topFloor</param>
        /// <param name="topCeiling">topCeiling</param>
        /// <param name="topBenching">topBenching</param>
        /// <param name="downDiameter">downDiameter</param>
        /// <param name="downDepth">downDepth</param>
        /// <param name="downFloor">downFloor</param>
        /// <param name="downCeiling">downCeiling</param>
        /// <param name="downBenching">downBenching</param>
        /// <param name="rectangle1LongSide">rectangle1LongSide</param>
        /// <param name="rectangle1ShortSide">rectangle1ShortSide</param>
        /// <param name="rectangle2LongSide">rectangle2LongSide</param>
        /// <param name="rectangle2ShortSide">rectangle2ShortSide</param>
        /// <param name="topSurfaceArea">topSurfaceArea</param>
        /// <param name="downSurfaceArea">downSurfaceArea</param>
        /// <param name="manholeRugs">manholeRugs</param>
        /// <param name="totalDepth">totalDepth</param>
        /// <param name="totalSurfaceArea">totalSurfaceArea</param>
        public int InsertDirect(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, string mhid, string latitude, string longitude, string address, bool deleted, int companyId, string manholeShape, string location, int? materialID, string topDiameter, string topDepth, string topFloor, string topCeiling, string topBenching, string downDiameter, string downDepth, string downFloor, string downCeiling, string downBenching, string rectangle1LongSide, string rectangle1ShortSide, string rectangle2LongSide, string rectangle2ShortSide, string topSurfaceArea, string downSurfaceArea, int? manholeRugs, string totalDepth, string totalSurfaceArea)                                                                                                     
        {
            AssetSewerMHGateway assetSewerMhGateway = new AssetSewerMHGateway();
            assetSewerMhGateway.LoadByCountryIdProvinceIdCountyIdCityIdMhId(countryId, provinceId, countyId, cityId, mhid, companyId, latitude, longitude, address);
            int mh_assetId = 0;

            if (assetSewerMhGateway.Table.Rows.Count == 0)
            {
                mh_assetId = new Asset(new DataSet()).InsertDirect("Sewer", countryId, provinceId, countyId, cityId, deleted, companyId);
                new AssetSewer(new DataSet()).InsertDirect(mh_assetId, "MH", deleted, companyId);
                assetSewerMhGateway.Insert(mh_assetId, mhid, latitude, longitude, address, deleted, companyId, manholeShape, location, materialID, topDiameter, topDepth, topFloor, topCeiling, topBenching, downDiameter, downDepth, downFloor, downCeiling, downBenching, rectangle1LongSide, rectangle1ShortSide, rectangle2LongSide, rectangle2ShortSide, topSurfaceArea, downSurfaceArea, manholeRugs, totalDepth, totalSurfaceArea);
                              
            }
            else
            {
                mh_assetId = assetSewerMhGateway.GetAssetID(mhid);
            }

            return mh_assetId;
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalAssetId">originalAssetId</param>
        /// <param name="originalMhId">originalMhId</param>
        /// <param name="originalLatitud">originalLatitud</param>
        /// <param name="originalLongitude">originalLongitude</param>
        /// <param name="originalAddress">originalAddress</param>
        /// <param name="originalManholeShape">originalManholeShape</param>
        /// <param name="originalLocation">originalLocation</param>
        /// <param name="originalMaterialID">originalMaterialID</param>
        /// <param name="originalTopDiameter">originalTopDiameter</param>
        /// <param name="originalTopDepth">originalTopDepth</param>
        /// <param name="originalTopFloor">originalTopFloor</param>
        /// <param name="originalTopCeiling">originalTopCeiling</param>
        /// <param name="originalTopBenching">originalTopBenching</param>
        /// <param name="originalDownDiameter">originalDownDiameter</param>
        /// <param name="originalDownDepth">originalDownDepth</param>
        /// <param name="originalDownFloor">originalDownFloor</param>
        /// <param name="originalDownCeiling">originalDownCeiling</param>
        /// <param name="originalDownBenching">originalDownBenching</param>
        /// <param name="originalRectangle1LongSide">originalRectangle1LongSide</param>
        /// <param name="originalRectangle1ShortSide">originalRectangle1ShortSide</param>
        /// <param name="originalRectangle2LongSide">originalRectangle2LongSide</param>
        /// <param name="originalRectangle2ShortSide">originalRectangle2ShortSide</param>
        /// <param name="originalTopSurfaceArea">originalTopSurfaceArea</param>
        /// <param name="originalDownSurfaceArea">originalDownSurfaceArea</param>
        /// <param name="originalManholeRugs">originalManholeRugs</param>
        /// <param name="originalTotalDepth">originalTotalDepth</param>
        /// <param name="originalTotalSurfaceArea">originalTotalSurfaceArea</param>        
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newAssetId">newAssetId</param>
        /// <param name="newMhId">newMhId</param>
        /// <param name="newLatitude">newLatitude</param>
        /// <param name="newLongitude">newLongitude</param>
        /// <param name="newAddress">newAddress</param>
        /// <param name="newManholeShape">newManholeShape</param>
        /// <param name="newLocation">newLocation</param>
        /// <param name="newMaterialID">newMaterialID</param>
        /// <param name="newTopDiameter">newTopDiameter</param>
        /// <param name="newTopDepth">newTopDepth</param>
        /// <param name="newTopFloor">newTopFloor</param>
        /// <param name="newTopCeiling">newTopCeiling</param>
        /// <param name="newTopBenching">newTopBenching</param>
        /// <param name="newDownDiameter">newDownDiameter</param>
        /// <param name="newDownDepth">newDownDepth</param>
        /// <param name="newDownFloor">newDownFloor</param>
        /// <param name="newDownCeiling">newDownCeiling</param>
        /// <param name="newDownBenching">newDownBenching</param>
        /// <param name="newRectangle1LongSide">newRectangle1LongSide</param>
        /// <param name="newRectangle1ShortSide">newRectangle1ShortSide</param>
        /// <param name="newRectangle2LongSide">newRectangle2LongSide</param>
        /// <param name="newRectangle2ShortSide">newRectangle2ShortSide</param>
        /// <param name="newTopSurfaceArea">newTopSurfaceArea</param>
        /// <param name="newDownSurfaceArea">newDownSurfaceArea</param>
        /// <param name="newManholeRugs">newManholeRugs</param>
        /// <param name="newTotalDepth">newTotalDepth</param>
        /// <param name="newTotalSurfaceArea">newTotalSurfaceArea</param>              
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalAssetId, string originalMhId, string originalLatitud, string originalLongitude, string originalAddress, string originalManholeShape, string originalLocation, int? originalMaterialID, string originalTopDiameter, string originalTopDepth, string originalTopFloor, string originalTopCeiling, string originalTopBenching, string originalDownDiameter, string originalDownDepth, string originalDownFloor, string originalDownCeiling, string originalDownBenching, string  originalRectangle1LongSide, string originalRectangle1ShortSide, string originalRectangle2LongSide, string originalRectangle2ShortSide, string originalTopSurfaceArea, string originalDownSurfaceArea,  int? originalManholeRugs, string  originalTotalDepth, string originalTotalSurfaceArea, bool originalDeleted, int originalCompanyId, int newAssetId, string newMhId, string newLatitud, string newLongitude, string newAddress, string newManholeShape, string newLocation, int? newMaterialID,  string newTopDiameter, string newTopDepth, string newTopFloor, string newTopCeiling, string newTopBenching, string newDownDiameter, string newDownDepth, string newDownFloor, string newDownCeiling, string newDownBenching, string newRectangle1LongSide, string newRectangle1ShortSide, string newRectangle2LongSide, string newRectangle2ShortSide, string newTopSurfaceArea, string newDownSurfaceArea, int? newManholeRugs, string newTotalDepth, string newTotalSurfaceArea, bool newDeleted, int newCompanyId)
        {
            AssetSewerMHGateway assetSewerMhGateway = new AssetSewerMHGateway(null);
            assetSewerMhGateway.Update(originalAssetId, originalMhId, originalLatitud, originalLongitude, originalAddress, originalManholeShape, originalLocation, originalMaterialID, originalTopDiameter, originalTopDepth, originalTopFloor, originalTopCeiling, originalTopBenching, originalDownDiameter, originalDownDepth, originalDownFloor, originalDownCeiling, originalDownBenching,  originalRectangle1LongSide, originalRectangle1ShortSide, originalRectangle2LongSide, originalRectangle2ShortSide, originalTopSurfaceArea, originalDownSurfaceArea, originalManholeRugs, originalTotalDepth, originalTotalSurfaceArea, originalDeleted, originalCompanyId, newAssetId, newMhId, newLatitud, newLongitude, newAddress, newManholeShape, newLocation, newMaterialID,  newTopDiameter, newTopDepth, newTopFloor, newTopCeiling, newTopBenching, newDownDiameter, newDownDepth, newDownFloor, newDownCeiling, newDownBenching, newRectangle1LongSide, newRectangle1ShortSide, newRectangle2LongSide, newRectangle2ShortSide, newTopSurfaceArea, newDownSurfaceArea, newManholeRugs, newTotalDepth, newTotalSurfaceArea, newDeleted, newCompanyId);
        }
        

        
        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        public bool DeleteDirect(int assetId, int companyId)
        {
            if (!InUse(assetId, companyId))
            {
                AssetSewerMHGateway assetSewerMhGateway = new AssetSewerMHGateway(null);
                assetSewerMhGateway.Delete(assetId, companyId);

                AssetSewer assetSewer = new AssetSewer(null);
                assetSewer.DeleteDirect(assetId, companyId);

                Asset asset = new Asset(null);
                asset.DeleteDirect(assetId, companyId);

                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// Verify if MH is in use for any entity
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>true if MH is in use for any entity, not if it not in use</returns>
        public bool InUse(int assetId, int companyId)
        {
            // verify use for sections like USMH or DSMH
            AssetSewerMHGateway assetSewerMhGateway = new AssetSewerMHGateway(null);
            if (assetSewerMhGateway.InUseForSections(assetId, companyId))
            {
                return true;
            }

            // default return
            return false;
        }



    }
}