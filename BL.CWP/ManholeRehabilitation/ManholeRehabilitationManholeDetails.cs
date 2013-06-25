using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation
{    
    /// <summary>
    /// ManholeRehabilitationManholeDetails
    /// </summary>
    public class ManholeRehabilitationManholeDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ManholeRehabilitationManholeDetails()
            : base("ManholeDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ManholeRehabilitationManholeDetails(DataSet data)
            : base(data, "ManholeDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ManholeRehabilitationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByAssetId
        /// </summary>
        /// <param name="assetId">assetId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadByAssetId(int assetId, int companyId)
        {
            ManholeRehabilitationManholeDetailsGateway manholeRehabilitationManholeDetailsGateway = new ManholeRehabilitationManholeDetailsGateway(Data);
            manholeRehabilitationManholeDetailsGateway.LoadByAssetId(assetId, companyId);            
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="longitud">longitud</param>
        /// <param name="latitude">latitude</param>        
        /// <param name="address">address</param>
        /// <param name="manholeShape">manholeShape</param>
        /// <param name="location">location</param>
        /// <param name="materialId">materialId</param>
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
        /// <param name="conditionRating">conditionRating</param>
        /// <param name="materialDescription">materialDescription</param>               
        public void Update(int assetId, string longitud, string latitude, string address, string manholeShape, string location, int? materialId, string topDiameter, string topDepth, string topFloor, string topCeiling, string topBenching, string downDiameter, string downDepth, string downFloor, string downCeiling, string downBenching, string rectangle1LongSide, string rectangle1ShortSide, string rectangle2LongSide, string rectangle2ShortSide, string topSurfaceArea, string downSurfaceArea, int? manholeRugs, string totalDepth, string totalSurfaceArea, int? conditionRating, string materialDescription)
        {
            ManholeRehabilitationTDS.ManholeDetailsRow row = GetRow(assetId);

            if (longitud != "") row.Longitude = longitud; else row.SetLongitudeNull();
            if (latitude != "") row.Latitud = latitude; else row.SetLatitudNull();
            if (address != "") row.Address = address; else row.SetAddressNull();
            if (manholeShape != "") row.ManholeShape = manholeShape; else row.SetManholeShapeNull();
            if (location != "") row.Location = location; else row.SetLocationNull();
            if (materialId.HasValue) row.MaterialID = (int)materialId; else row.SetMaterialIDNull();
            if (topDiameter !="") row.TopDiameter = topDiameter; else row.SetTopDiameterNull();
            if (topDepth != "") row.TopDepth = topDepth; else row.SetTopDepthNull();
            if (topFloor != "") row.TopFloor = topFloor; else row.SetTopFloorNull();
            if (topCeiling != "") row.TopCeiling = topCeiling; else row.SetTopCeilingNull();
            if (topBenching != "") row.TopBenching = topBenching; else row.SetTopBenchingNull();
            if (downDiameter != "") row.DownDiameter = downDiameter; else row.SetDownDiameterNull();
            if (downDepth != "") row.DownDepth = downDepth; else row.SetDownDepthNull();
            if (downFloor != "") row.DownFloor = downFloor; else row.SetDownFloorNull();
            if (downCeiling != "") row.DownCeiling = downCeiling; else row.SetDownCeilingNull();
            if (downBenching != "") row.DownBenching = downBenching; else row.SetDownBenchingNull();
            if (rectangle1LongSide != "") row.Rectangle1LongSide = rectangle1LongSide; else row.SetRectangle1LongSideNull();
            if (rectangle1ShortSide != "") row.Rectangle1ShortSide = rectangle1ShortSide; else row.SetRectangle1ShortSideNull();
            if (rectangle2LongSide != "") row.Rectangle2LongSide = rectangle2LongSide; else row.SetRectangle2LongSideNull();
            if (rectangle2ShortSide != "") row.Rectangle2ShortSide = rectangle2ShortSide; else row.SetRectangle2ShortSideNull();
            if (topSurfaceArea != "") row.TopSurfaceArea = topSurfaceArea; else row.SetTopSurfaceAreaNull();
            if (downSurfaceArea != "") row.DownSurfaceArea = downSurfaceArea; else row.SetDownSurfaceAreaNull();
            if (manholeRugs.HasValue) row.ManholeRugs = (int)manholeRugs; else row.SetManholeRugsNull();
            if (totalDepth != "") row.TotalDepth = totalDepth; else row.SetTotalDepthNull();
            if (totalSurfaceArea != "") row.TotalSurfaceArea = totalSurfaceArea; else row.SetTotalSurfaceAreaNull();
            if (conditionRating.HasValue) row.ConditionRating = (int)conditionRating; else row.SetConditionRatingNull();
            if (materialDescription != "") row.MaterialDescription = materialDescription; else row.SetMaterialDescriptionNull();            
        }



        /// <summary>
        ///Save
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public void Save(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int projectId, int companyId)
        {
            //Update Section
            ManholeRehabilitationTDS manholeChanges = (ManholeRehabilitationTDS)Data.GetChanges();

            if (manholeChanges.ManholeDetails.Rows.Count > 0)
            {
                ManholeRehabilitationManholeDetailsGateway manholeRehabilitationManholeDetailsGateway = new ManholeRehabilitationManholeDetailsGateway(manholeChanges);

                // Update sections
                foreach (ManholeRehabilitationTDS.ManholeDetailsRow manholeDetailsRow in (ManholeRehabilitationTDS.ManholeDetailsDataTable)manholeChanges.ManholeDetails)
                {
                    // Unchanged values                    
                    int assetId = manholeDetailsRow.AssetID;
                    string mhId = manholeDetailsRow.MHID;

                    // Original values
                    string originalLatitud = manholeRehabilitationManholeDetailsGateway.GetLatitudOriginal(assetId);
                    string originalLongitude = manholeRehabilitationManholeDetailsGateway.GetLongitudeOriginal(assetId);
                    string originalAddress = manholeRehabilitationManholeDetailsGateway.GetAddressOriginal(assetId);
                    string originalManholeShape = manholeRehabilitationManholeDetailsGateway.GetManholeShapeOriginal(assetId);
                    string originalLocation = manholeRehabilitationManholeDetailsGateway.GetLocationOriginal(assetId);
                    int? originalMaterialID = manholeRehabilitationManholeDetailsGateway.GetMaterialIDOriginal(assetId);
                    string originalTopDiameter = manholeRehabilitationManholeDetailsGateway.GetTopDiameterOriginal(assetId);
                    string originalTopDepth = manholeRehabilitationManholeDetailsGateway.GetTopDepthOriginal(assetId);                    
                    string originalTopFloor = manholeRehabilitationManholeDetailsGateway.GetTopFloorOriginal(assetId);
                    string originalTopCeiling = manholeRehabilitationManholeDetailsGateway.GetTopCeilingOriginal(assetId);
                    string originalTopBenching = manholeRehabilitationManholeDetailsGateway.GetTopBenchingOriginal(assetId);
                    string originalDownDiameter = manholeRehabilitationManholeDetailsGateway.GetDownDiameterOriginal(assetId);
                    string originalDownDepth = manholeRehabilitationManholeDetailsGateway.GetDownDepthOriginal(assetId);
                    string originalDownFloor = manholeRehabilitationManholeDetailsGateway.GetDownFloorOriginal(assetId);
                    string originalDownCeiling = manholeRehabilitationManholeDetailsGateway.GetDownCeilingOriginal(assetId);
                    string originalDownBenching = manholeRehabilitationManholeDetailsGateway.GetDownBenchingOriginal(assetId);
                    string originalRectangle1LongSide = manholeRehabilitationManholeDetailsGateway.GetRectangle1LongSideOriginal(assetId);
                    string originalRectangle1ShortSide = manholeRehabilitationManholeDetailsGateway.GetRectangle1ShortSideOriginal(assetId);
                    string originalRectangle2LongSide = manholeRehabilitationManholeDetailsGateway.GetRectangle2LongSideOriginal(assetId);
                    string originalRectangle2ShortSide = manholeRehabilitationManholeDetailsGateway.GetRectangle2ShortSideOriginal(assetId);
                    string originalTopSurfaceArea = manholeRehabilitationManholeDetailsGateway.GetTopSurfaceAreaOriginal(assetId);
                    string originalDownSurfaceArea = manholeRehabilitationManholeDetailsGateway.GetDownSurfaceAreaOriginal(assetId);
                    int? originalManholeRugs = manholeRehabilitationManholeDetailsGateway.GetManholeRugsOriginal(assetId);
                    string originalTotalDepth = manholeRehabilitationManholeDetailsGateway.GetTotalDepthOriginal(assetId);
                    string originalTotalSurfaceArea = manholeRehabilitationManholeDetailsGateway.GetTotalSurfaceAreaOriginal(assetId);
                    int? originalConditionRating = manholeRehabilitationManholeDetailsGateway.GetConditionRatingOriginal(assetId);
                    
                    // New variables
                    string newLatitud = manholeRehabilitationManholeDetailsGateway.GetLatitud(assetId);
                    string newLongitude = manholeRehabilitationManholeDetailsGateway.GetLongitude(assetId);
                    string newAddress = manholeRehabilitationManholeDetailsGateway.GetAddress(assetId);
                    string newManholeShape = manholeRehabilitationManholeDetailsGateway.GetManholeShape(assetId);
                    string newLocation = manholeRehabilitationManholeDetailsGateway.GetLocation(assetId);
                    int? newMaterialID = manholeRehabilitationManholeDetailsGateway.GetMaterialID(assetId);
                    string newTopDiameter = manholeRehabilitationManholeDetailsGateway.GetTopDiameter(assetId);
                    string newTopDepth = manholeRehabilitationManholeDetailsGateway.GetTopDepth(assetId);
                    string newTopFloor = manholeRehabilitationManholeDetailsGateway.GetTopFloor(assetId);
                    string newTopCeiling = manholeRehabilitationManholeDetailsGateway.GetTopCeiling(assetId);
                    string newTopBenching = manholeRehabilitationManholeDetailsGateway.GetTopBenching(assetId);
                    string newDownDiameter = manholeRehabilitationManholeDetailsGateway.GetDownDiameter(assetId);
                    string newDownDepth = manholeRehabilitationManholeDetailsGateway.GetDownDepth(assetId);
                    string newDownFloor = manholeRehabilitationManholeDetailsGateway.GetDownFloor(assetId);
                    string newDownCeiling = manholeRehabilitationManholeDetailsGateway.GetDownCeiling(assetId);
                    string newDownBenching = manholeRehabilitationManholeDetailsGateway.GetDownBenching(assetId);
                    string newRectangle1LongSide = manholeRehabilitationManholeDetailsGateway.GetRectangle1LongSide(assetId);
                    string newRectangle1ShortSide = manholeRehabilitationManholeDetailsGateway.GetRectangle1ShortSide(assetId);
                    string newRectangle2LongSide = manholeRehabilitationManholeDetailsGateway.GetRectangle2LongSide(assetId);
                    string newRectangle2ShortSide = manholeRehabilitationManholeDetailsGateway.GetRectangle2ShortSide(assetId);
                    string newTopSurfaceArea = manholeRehabilitationManholeDetailsGateway.GetTopSurfaceArea(assetId);
                    string newDownSurfaceArea = manholeRehabilitationManholeDetailsGateway.GetDownSurfaceArea(assetId);
                    int? newManholeRugs = manholeRehabilitationManholeDetailsGateway.GetManholeRugs(assetId);
                    string newTotalDepth = manholeRehabilitationManholeDetailsGateway.GetTotalDepth(assetId);
                    string newTotalSurfaceArea = manholeRehabilitationManholeDetailsGateway.GetTotalSurfaceArea(assetId);
                    int? newConditionRating = manholeRehabilitationManholeDetailsGateway.GetConditionRating(assetId);

                    // Update
                    AssetSewerMHGateway assetSewerMHGateway = new AssetSewerMHGateway();
                    assetSewerMHGateway.LoadByAssetId(assetId, companyId);
                                     
                    if (assetSewerMHGateway.Table.Rows.Count > 0)
                    {
                        // ... update asset manhole
                        AssetSewerMH assetSewerMH = new AssetSewerMH(assetSewerMHGateway.Data);
                        assetSewerMH.UpdateDirect(assetId, mhId, originalLatitud, originalLongitude, originalAddress, originalManholeShape, originalLocation, originalMaterialID, originalTopDiameter, originalTopDepth, originalTopFloor, originalTopCeiling, originalTopBenching, originalDownDiameter, originalDownDepth, originalDownFloor, originalDownCeiling, originalDownBenching, originalRectangle1LongSide, originalRectangle1ShortSide, originalRectangle2LongSide, originalRectangle2ShortSide, originalTopSurfaceArea, originalDownSurfaceArea, originalManholeRugs, originalTotalDepth, originalTotalSurfaceArea, false, companyId, assetId, mhId, newLatitud, newLongitude, newAddress, newManholeShape, newLocation, newMaterialID, newTopDiameter, newTopDepth, newTopFloor, newTopCeiling, newTopBenching, newDownDiameter, newDownDepth, newDownFloor, newDownCeiling, newDownBenching, newRectangle1LongSide, newRectangle1ShortSide, newRectangle2LongSide, newRectangle2ShortSide, newTopSurfaceArea, newDownSurfaceArea, newManholeRugs, newTotalDepth, newTotalSurfaceArea, false, companyId);

                        // ... update lfs manhole
                        LfsAssetSewerMH lfsAssetSewerMH = new LfsAssetSewerMH(null);
                        lfsAssetSewerMH.UpdateDirect(assetId, false, companyId, originalConditionRating, false, companyId, newConditionRating); 
                    }                                       
                }
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="assetId">assetId</param>
        public void Delete(int assetId)
        {
            ManholeRehabilitationTDS.ManholeDetailsRow row = GetRow(assetId);
            row.Deleted = true;
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalAssetId">originalAssetId</param>
        /// <param name="originalSectionId">originalSectionId</param>
        /// <param name="originalStreet">originalStreet</param>
        /// <param name="originalUsmh">originalUsmh</param>
        /// <param name="originalUsmhId">originalUsmhId</param>
        /// <param name="originalDsmh">originalDsmh</param>
        /// <param name="originalDsmhId">originalDsmhId</param>
        /// <param name="originalMapSize">originalMapSize</param>
        /// <param name="originalSize">originalSize</param>
        /// <param name="originalMapLength">originalMapLength</param>
        /// <param name="originalLength">originalLength</param>
        /// <param name="originalLaterals">laterals</param>
        /// <param name="originalLiveLaterals">liveLaterals</param>
        /// <param name="originalUsmhDepth">originalUsmhDepth</param>
        /// <param name="originalDsmhDepth">originalDsmhDepth</param>
        /// <param name="originalSteelTapeThroughSewer">originalSteelTapeThroughSewer</param>
        /// <param name="originalSubArea">originalSubArea</param>
        /// <param name="originalUsmhMouth12">originalUsmhMouth12</param>
        /// <param name="originalUsmhMouth1">originalUsmhMouth1</param>
        /// <param name="originalUsmhMouth2">originalUsmhMouth2</param>
        /// <param name="originalUsmhMouth3">originalUsmhMouth3</param>
        /// <param name="originalUsmhMouth4">originalUsmhMouth4</param>
        /// <param name="originalUsmhMouth5">originalUsmhMouth5</param>
        /// <param name="originalDsmhMouth12">originalDsmhMouth12</param>
        /// <param name="originalDsmhMouth1">originalDsmhMouth1</param>
        /// <param name="originalDsmhMouth2">originalDsmhMouth2</param>
        /// <param name="originalDsmhMouth3">originalDsmhMouth3</param>
        /// <param name="originalDsmhMouth4">originalDsmhMouth4</param>
        /// <param name="originalDsmhMouth5">originalDsmhMouth5</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalUsmhAddress">originalUsmhAddress</param>
        /// <param name="originalDsmhAddress">originalDsmhAddress</param>
        /// <param name="originalThickness">originalThickness</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newAssetId">newAssetId</param>
        /// <param name="newSectionId">newSectionId</param>
        /// <param name="newStreet">newStreet</param>
        /// <param name="newUsmhId">newUsmhId</param>
        /// <param name="newDsmhId">newDsmhId</param>
        /// <param name="newMapSize">newMapSize</param>
        /// <param name="newSize">newSize</param>
        /// <param name="newMapLength">newMapLength</param>
        /// <param name="newLength">newLength</param>
        /// <param name="newMapLength">newMapLength</param>
        /// <param name="newLaterals">newLaterals</param>
        /// <param name="newLiveLaterals">newLiveLaterals</param>
        /// <param name="newUsmhDepth">newUsmhDepth</param>
        /// <param name="newDsmhDepth">newDsmhDepth</param>
        /// <param name="newSteelTapeThroughSewer">newSteelTapeThroughSewer</param>
        /// <param name="newSubArea">newSubArea</param>
        /// <param name="newUsmhMouth12">newUsmhMouth12</param>
        /// <param name="newUsmhMouth1">newUsmhMouth1</param>
        /// <param name="newUsmhMouth2">newUsmhMouth2</param>
        /// <param name="newUsmhMouth3">newUsmhMouth3</param>
        /// <param name="newUsmhMouth4">newUsmhMouth4</param>
        /// <param name="newUsmhMouth5">newUsmhMouth5</param>
        /// <param name="newDsmhMouth12">newDsmhMouth12</param>
        /// <param name="newDsmhMouth1">newDsmhMouth1</param>
        /// <param name="newDsmhMouth2">newDsmhMouth2</param>
        /// <param name="newDsmhMouth3">newDsmhMouth3</param>
        /// <param name="newDsmhMouth4">newDsmhMouth4</param>
        /// <param name="newDsmhMouth5">newDsmhMouth5</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newUsmhAddress">newUsmhAddress</param>
        /// <param name="newDsmhAddress">newDsmhAddress</param>
        /// <param name="newThickness">newThickness</param>
        private void Update(int projectId, Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int originalWorkId, int originalAssetId, string originalSectionId, string originalStreet, int? originalUsmh, string originalUsmhId, int? originalDsmh, string originalDsmhId, string originalMapSize, string originalSize, string originalMapLength, string originalLength, int? originalLaterals, int? originalLiveLaterals, string originalUsmhDepth, string originalDsmhDepth, string originalSteelTapeThroughSewer, string originalSubArea, string originalUsmhMouth12, string originalUsmhMouth1, string originalUsmhMouth2, string originalUsmhMouth3, string originalUsmhMouth4, string originalUsmhMouth5, string originalDsmhMouth12, string originalDsmhMouth1, string originalDsmhMouth2, string originalDsmhMouth3, string originalDsmhMouth4, string originalDsmhMouth5, bool originalDeleted, int originalCompanyId, string originalUsmhAddress, string originalDsmhAddress, string originalThickness, int newWorkId, int newAssetId, string newSectionId, string newStreet, string newUsmhId, string newDsmhId, string newMapSize, string newSize, string newMapLength, string newLength, int? newLaterals, int? newLiveLaterals, string newUsmhDepth, string newDsmhDepth, string newSteelTapeThroughSewer, string newSubArea, string newUsmhMouth12, string newUsmhMouth1, string newUsmhMouth2, string newUsmhMouth3, string newUsmhMouth4, string newUsmhMouth5, string newDsmhMouth12, string newDsmhMouth1, string newDsmhMouth2, string newDsmhMouth3, string newDsmhMouth4, string newDsmhMouth5, bool newDeleted, int newCompanyId, string newUsmhAddress, string newDsmhAddress, string newThickness)
        {
            //// Insert USMH if data change (only if not exists)
            //int? newUsmh = originalUsmh;
            //if (originalUsmhId != newUsmhId)
            //{
            //    if (newUsmhId.Trim() != "")
            //    {
            //        LfsAssetSewerMH lfsAssetSewerUsmh = new LfsAssetSewerMH(null);
            //        newUsmh = lfsAssetSewerUsmh.InsertDirect(countryId, provinceId, countyId, cityId, newUsmhId, "", "", newUsmhAddress, false, originalCompanyId);
            //    }
            //    else
            //    {
            //        newUsmh = null;
            //    }
            //}
            //else
            //{
            //    // Update existing mh
            //    UpdateMH(countryId, provinceId, countyId, cityId, originalUsmhId, originalUsmhAddress, newUsmhAddress, originalCompanyId);
            //}

            //// insert DSMH if data change (only if not exists)
            //int? newDsmh = originalDsmh;
            //if (originalDsmhId != newDsmhId)
            //{
            //    if (newDsmhId.Trim() != "")
            //    {
            //        LfsAssetSewerMH lfsAssetSewerDsmh = new LfsAssetSewerMH(null);
            //        newDsmh = lfsAssetSewerDsmh.InsertDirect(countryId, provinceId, countyId, cityId, newDsmhId, "", "", newDsmhAddress, false, originalCompanyId);
            //    }
            //    else
            //    {
            //        newDsmh = null;
            //    }
            //}
            //else
            //{
            //    // Update existing mh
            //    UpdateMH(countryId, provinceId, countyId, cityId, originalDsmhId, originalDsmhAddress, newDsmhAddress, originalCompanyId);
            //}

            //// update section
            //UpdateSection(originalWorkId, originalAssetId, originalSectionId, originalStreet, originalUsmh,  originalDsmh,  originalMapSize, originalSize, originalMapLength, originalLength, originalLaterals,  originalLiveLaterals, originalUsmhDepth, originalDsmhDepth, originalSteelTapeThroughSewer, originalSubArea, originalUsmhMouth12, originalUsmhMouth1, originalUsmhMouth2,  originalUsmhMouth3,  originalUsmhMouth4,  originalUsmhMouth5, originalDsmhMouth12, originalDsmhMouth1, originalDsmhMouth2, originalDsmhMouth3, originalDsmhMouth4, originalDsmhMouth5,  originalDeleted, originalCompanyId, originalUsmhAddress, originalDsmhAddress, originalThickness, newWorkId, newAssetId, newSectionId, newStreet, newUsmh, newDsmh, newMapSize, newSize, newMapLength, newLength, newLaterals, newLiveLaterals, newUsmhDepth, newDsmhDepth, newSteelTapeThroughSewer, newSubArea, newUsmhMouth12,  newUsmhMouth1, newUsmhMouth2, newUsmhMouth3, newUsmhMouth4, newUsmhMouth5, newDsmhMouth12, newDsmhMouth1, newDsmhMouth2, newDsmhMouth3, newDsmhMouth4,  newDsmhMouth5, newDeleted, newCompanyId, newUsmhAddress, newDsmhAddress, projectId, newThickness);
        }



        



        /// <summary>
        /// UpdateSection
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="originalSectionId">originalSectionId</param>
        /// <param name="originalStreet">originalStreet</param>
        /// <param name="originalUsmh">originalUsmh</param>
        /// <param name="originalDsmh">originalDsmh</param>
        /// <param name="originalMapSize">originalMapSize</param>
        /// <param name="originalSize">originalSize</param>
        /// <param name="originalMapLength">originalMapLength</param>
        /// <param name="originalLength">originalLength</param>
        /// <param name="originalLaterals">laterals</param>
        /// <param name="originalLiveLaterals">liveLaterals</param>
        /// <param name="originalUsmhDepth">originalUsmhDepth</param>
        /// <param name="originalDsmhDepth">originalDsmhDepth</param>
        /// <param name="originalSteelTapeThroughSewer">originalSteelTapeThroughSewer</param>
        /// <param name="originalSubArea">originalSubArea</param>
        /// <param name="originalUsmhMouth12">originalUsmhMouth12</param>
        /// <param name="originalUsmhMouth1">originalUsmhMouth1</param>
        /// <param name="originalUsmhMouth2">originalUsmhMouth2</param>
        /// <param name="originalUsmhMouth3">originalUsmhMouth3</param>
        /// <param name="originalUsmhMouth4">originalUsmhMouth4</param>
        /// <param name="originalUsmhMouth5">originalUsmhMouth5</param>
        /// <param name="originalDsmhMouth12">originalDsmhMouth12</param>
        /// <param name="originalDsmhMouth1">originalDsmhMouth1</param>
        /// <param name="originalDsmhMouth2">originalDsmhMouth2</param>
        /// <param name="originalDsmhMouth3">originalDsmhMouth3</param>
        /// <param name="originalDsmhMouth4">originalDsmhMouth4</param>
        /// <param name="originalDsmhMouth5">originalDsmhMouth5</param>
        /// <param name="originalDelete">originalDelete</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalUsmhAddress">originalUsmhAddress</param>
        /// <param name="originalDsmhAddress">originalDsmhAddress</param>
        /// <param name="originalThickness">originalThickness</param>
        /// 
        /// <param name="projectId">projectId</param>
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newAssetId">newAssetId</param>
        /// <param name="newSectionId">newSectionId</param>
        /// <param name="newStreet">newStreet</param>
        /// <param name="newUsmh">newUsmh</param>
        /// <param name="newDsmh">newDsmh</param>
        /// <param name="newMapSize">newMapSize</param>
        /// <param name="newSize">newSize</param>
        /// <param name="newMapLength">newMapLength</param>
        /// <param name="newLength">newLength</param>
        /// <param name="newMapLength">newMapLength</param>
        /// <param name="newLaterals">newLaterals</param>
        /// <param name="newLiveLaterals">newLiveLaterals</param>
        /// <param name="newUsmhDepth">newUsmhDepth</param>
        /// <param name="newDsmhDepth">newDsmhDepth</param>
        /// <param name="newSteelTapeThroughSewer">newSteelTapeThroughSewer</param>
        /// <param name="newSubArea">newSubArea</param>
        /// <param name="newUsmhMouth12">newUsmhMouth12</param>
        /// <param name="newUsmhMouth1">newUsmhMouth1</param>
        /// <param name="newUsmhMouth2">newUsmhMouth2</param>
        /// <param name="newUsmhMouth3">newUsmhMouth3</param>
        /// <param name="newUsmhMouth4">newUsmhMouth4</param>
        /// <param name="newUsmhMouth5">newUsmhMouth5</param>
        /// <param name="newDsmhMouth12">newDsmhMouth12</param>
        /// <param name="newDsmhMouth1">newDsmhMouth1</param>
        /// <param name="newDsmhMouth2">newDsmhMouth2</param>
        /// <param name="newDsmhMouth3">newDsmhMouth3</param>
        /// <param name="newDsmhMouth4">newDsmhMouth4</param>
        /// <param name="newDsmhMouth5">newDsmhMouth5</param>
        /// <param name="newDelete">newDelete</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newUsmhAddress">newUsmhAddress</param>
        /// <param name="newDsmhAddress">newDsmhAddress</param>
        /// <param name="newThickness">newThickness</param>        
        private void UpdateSection(int originalWorkId, int assetId, string originalSectionId, string originalStreet, int? originalUsmh, int? originalDsmh, string originalMapSize, string originalSize, string originalMapLength, string originalLength, int? originalLaterals, int? originalLiveLaterals, string originalUsmhDepth, string originalDsmhDepth, string originalSteelTapeThroughSewer, string originalSubArea, string originalUsmhMouth12, string originalUsmhMouth1, string originalUsmhMouth2, string originalUsmhMouth3, string originalUsmhMouth4, string originalUsmhMouth5, string originalDsmhMouth12, string originalDsmhMouth1, string originalDsmhMouth2, string originalDsmhMouth3, string originalDsmhMouth4, string originalDsmhMouth5, bool originalDelete, int originalCompanyId, string originalUsmhAddress, string originalDsmhAddress, string originalThickness, int newWorkId, int newAssetId, string newSectionId, string newStreet, int? newUsmh, int? newDsmh, string newMapSize, string newSize, string newMapLength, string newLength, int? newLaterals, int? newLiveLaterals, string newUsmhDepth, string newDsmhDepth, string newSteelTapeThroughSewer, string newSubArea, string newUsmhMouth12, string newUsmhMouth1, string newUsmhMouth2, string newUsmhMouth3, string newUsmhMouth4, string newUsmhMouth5, string newDsmhMouth12, string newDsmhMouth1, string newDsmhMouth2, string newDsmhMouth3, string newDsmhMouth4, string newDsmhMouth5, bool newDelete, int newCompanyId, string newUsmhAddress, string newDsmhAddress, int projectId, string newThickness)
        {
            //// Get unchanged data
            //// ... section
            //AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
            //assetSewerSectionGateway.LoadByAssetId(assetId, originalCompanyId);

            //int? laterals = assetSewerSectionGateway.GetLaterals(assetId);
            //string flowDirection = assetSewerSectionGateway.GetFlowDirection(assetId);

            //// Update section
            //LfsAssetSewerSection lfsAssetSewerSection = new LfsAssetSewerSection(null);
            //lfsAssetSewerSection.UpdateDirect(assetId, originalSectionId, originalStreet, originalUsmh, originalDsmh, originalMapSize, originalSize, originalMapLength, originalLength, originalLaterals, originalLiveLaterals, flowDirection, originalUsmhDepth, originalDsmhDepth, originalSteelTapeThroughSewer, originalUsmhMouth12, originalUsmhMouth1, originalUsmhMouth2, originalUsmhMouth3, originalUsmhMouth4, originalUsmhMouth5, originalDsmhMouth12, originalDsmhMouth1, originalDsmhMouth2, originalDsmhMouth3, originalDsmhMouth4, originalDsmhMouth5, originalDelete, originalCompanyId, originalSubArea, originalThickness, assetId, newSectionId, newStreet, newUsmh, newDsmh, newMapSize, newSize, newMapLength, newLength, newLaterals, newLiveLaterals, flowDirection, newUsmhDepth, newDsmhDepth, newSteelTapeThroughSewer, newUsmhMouth12, newUsmhMouth1, newUsmhMouth2, newUsmhMouth3, newUsmhMouth4, newUsmhMouth5, newDsmhMouth12, newDsmhMouth1, newDsmhMouth2, newDsmhMouth3, newDsmhMouth4, newDsmhMouth5, newDelete, newCompanyId, newSubArea, newThickness); 
        }      



        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Row obtained</returns>
        private ManholeRehabilitationTDS.ManholeDetailsRow GetRow(int assetId)
        {
            ManholeRehabilitationTDS.ManholeDetailsRow row = ((ManholeRehabilitationTDS.ManholeDetailsDataTable)Table).FindByAssetID(assetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation.ManholeRehabilitationManholeDetails.GetRow");
            }

            return row;
        }
                   


    }
}