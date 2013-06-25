using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{    
    /// <summary>
    /// FullLengthLiningSectionDetails
    /// </summary>
    public class FullLengthLiningSectionDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FullLengthLiningSectionDetails()
            : base("SectionDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FullLengthLiningSectionDetails(DataSet data)
            : base(data, "SectionDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FullLengthLiningTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByWorkId
        /// </summary>
        /// <param name="workId">workId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadByWorkId(int workId, int companyId)
        {
            FullLengthLiningSectionDetailsGateway fullLengthLiningSectionDetailsGateway = new FullLengthLiningSectionDetailsGateway(Data);
            fullLengthLiningSectionDetailsGateway.LoadByWorkId(workId, companyId);

            // Update some fields before to show
            UpdateFieldsForSections();
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="street">street</param>        
        /// <param name="mapSize">mapSize</param>
        /// <param name="size">size</param>
        /// <param name="mapLength">mapLength</param>
        /// <param name="length">length</param>
        /// <param name="laterals">laterals</param>
        /// <param name="liveLaterals">liveLaterals</param>
        /// <param name="usmhDepth">usmhDepth</param>
        /// <param name="dsmhDepth">dsmhDepth</param>
        /// <param name="steelTapeThroughSewer">steelTapeThroughSewer</param>
        /// <param name="usmhMouth12">usmhMouth12</param>
        /// <param name="usmhMouth1">usmhMouth1</param>
        /// <param name="usmhMouth2">usmhMouth2</param>
        /// <param name="usmhMouth3">usmhMouth3</param>
        /// <param name="usmhMouth4">usmhMouth4</param>
        /// <param name="usmhMouth5">usmhMouth5</param>
        /// <param name="dsmhMouth12">dsmhMouth12</param>
        /// <param name="dsmhMouth1">dsmhMouth1</param>
        /// <param name="dsmhMouth2">dsmhMouth2</param>
        /// <param name="dsmhMouth3">dsmhMouth3</param>
        /// <param name="dsmhMouth4">dsmhMouth4</param>
        /// <param name="dsmhMouth5">dsmhMouth5</param>
        /// <param name="usmhDescription">usmhDescription</param>
        /// <param name="dsmhDescription">dsmhDescription</param>
        /// <param name="usmhAddress">usmhAddress</param>
        /// <param name="dsmhAddress">dsmhAddress</param>
        /// <param name="subArea">subArea</param>
        /// <param name="thickness">thickness</param>
        public void Update(int workId, int assetId, string street, string mapSize, string size, string mapLength, string length, int? laterals, int? liveLaterals, string usmhDepth, string dsmhDepth, string steelTapeThroughSewer, string usmhMouth12, string usmhMouth1, string usmhMouth2, string usmhMouth3, string usmhMouth4, string usmhMouth5, string dsmhMouth12, string dsmhMouth1, string dsmhMouth2, string dsmhMouth3, string dsmhMouth4, string dsmhMouth5, string usmhDescription, string dsmhDescription, string usmhAddress, string dsmhAddress, string subArea, string thickness)
        {
            FullLengthLiningTDS.SectionDetailsRow row = GetRow(workId);

            if (street != "") row.Street = street; else row.SetStreetNull();
            if (mapSize != "") row.MapSize = mapSize; else row.SetMapSizeNull();
            if (size != "") row.Size_ = size; else row.SetSize_Null();
            if (mapLength != "") row.MapLength = mapLength; else row.SetMapLengthNull();
            if (length != "") row.Length = length; else row.SetLengthNull();
            if (laterals.HasValue) row.Laterals = (int)laterals; else row.SetLateralsNull();
            if (liveLaterals.HasValue) row.LiveLaterals = (int)liveLaterals; else row.SetLiveLateralsNull();
            if (usmhDepth != "") row.USMHDepth = usmhDepth; else row.SetUSMHDepthNull();
            if (dsmhDepth != "") row.DSMHDepth = dsmhDepth; else row.SetDSMHDepthNull();
            if (steelTapeThroughSewer != "") row.SteelTapeThroughSewer = steelTapeThroughSewer; else row.SetSteelTapeThroughSewerNull();
            if (usmhMouth12 != "") row.USMHMouth12 = usmhMouth12; else row.SetUSMHMouth12Null();
            if (usmhMouth1 != "") row.USMHMouth1 = usmhMouth1; else row.SetUSMHMouth1Null();
            if (usmhMouth2 != "") row.USMHMouth2 = usmhMouth2; else row.SetUSMHMouth2Null();
            if (usmhMouth3 != "") row.USMHMouth3 = usmhMouth3; else row.SetUSMHMouth3Null();
            if (usmhMouth4 != "") row.USMHMouth4 = usmhMouth4; else row.SetUSMHMouth4Null();
            if (usmhMouth5 != "") row.USMHMouth5 = usmhMouth5; else row.SetUSMHMouth5Null();
            if (dsmhMouth12 != "") row.DSMHMouth12 = dsmhMouth12; else row.SetDSMHMouth12Null();
            if (dsmhMouth1 != "") row.DSMHMouth1 = dsmhMouth1; else row.SetDSMHMouth1Null();
            if (dsmhMouth2 != "") row.DSMHMouth2 = dsmhMouth2; else row.SetDSMHMouth2Null();
            if (dsmhMouth3 != "") row.DSMHMouth3 = dsmhMouth3; else row.SetDSMHMouth3Null();
            if (dsmhMouth4 != "") row.DSMHMouth4 = dsmhMouth4; else row.SetDSMHMouth4Null();
            if (dsmhMouth5 != "") row.DSMHMouth5 = dsmhMouth5; else row.SetDSMHMouth5Null();
            if (usmhDescription != "") row.USMHDescription = usmhDescription; else row.SetUSMHDescriptionNull();
            if (dsmhDescription != "") row.DSMHDescription = dsmhDescription; else row.SetDSMHDescriptionNull();
            if (usmhAddress != "") row.USMHAddress = usmhAddress; else row.SetUSMHAddressNull();
            if (dsmhAddress != "") row.DSMHAddress = dsmhAddress; else row.SetDSMHAddressNull();
            if (subArea.Trim() != "") row.SubArea = subArea; else row.SetSubAreaNull();
            if (thickness != "") row.Thickness = thickness; else row.SetThicknessNull();            
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
            FullLengthLiningTDS fullLengthLiningChanges = (FullLengthLiningTDS)Data.GetChanges();

            if (fullLengthLiningChanges.SectionDetails.Rows.Count > 0)
            {
                FullLengthLiningSectionDetailsGateway fullLengthLiningSectionDetailsGateway = new FullLengthLiningSectionDetailsGateway(fullLengthLiningChanges);

                // Update sections
                foreach (FullLengthLiningTDS.SectionDetailsRow sectionDetailsRow in (FullLengthLiningTDS.SectionDetailsDataTable)fullLengthLiningChanges.SectionDetails)
                {
                    // Unchanged values
                    int workId = sectionDetailsRow.WorkID;
                    int assetId = sectionDetailsRow.AssetID;                    
                    string sectionId = sectionDetailsRow.SectionID;

                    // Original values
                    string originalStreet = fullLengthLiningSectionDetailsGateway.GetStreetOriginal(workId);
                    int? originalUsmh = fullLengthLiningSectionDetailsGateway.GetUsmh(workId);
                    string originalUsmhId = fullLengthLiningSectionDetailsGateway.GetUsmhDescriptionOriginal(workId);
                    int? originalDsmh = fullLengthLiningSectionDetailsGateway.GetDsmh(workId);
                    string originalDsmhId = fullLengthLiningSectionDetailsGateway.GetDsmhDescriptionOriginal(workId);
                    string originalMapSize = fullLengthLiningSectionDetailsGateway.GetMapSizeOriginal(workId);
                    string originalSize = fullLengthLiningSectionDetailsGateway.GetSizeOriginal(workId);
                    string originalMapLength = fullLengthLiningSectionDetailsGateway.GetMapLengthOriginal(workId);
                    string originalLength = fullLengthLiningSectionDetailsGateway.GetLengthOriginal(workId);
                    int? originalLaterals = fullLengthLiningSectionDetailsGateway.GetLateralsOriginal(workId);
                    int? originalLiveLaterals = fullLengthLiningSectionDetailsGateway.GetLiveLateralsOriginal(workId);
                    string originalUsmhDepth = fullLengthLiningSectionDetailsGateway.GetUsmhDepthOriginal(workId);
                    string originalDsmhDepth = fullLengthLiningSectionDetailsGateway.GetDsmhDepthOriginal(workId);
                    string originalSteelTapeThroughSewer = fullLengthLiningSectionDetailsGateway.GetSteelTapeThroughSewerOriginal(workId);
                    string originalUsmhMouth12 = fullLengthLiningSectionDetailsGateway.GetUsmhMouth12Original(workId);
                    string originalUsmhMouth1 = fullLengthLiningSectionDetailsGateway.GetUsmhMouth1Original(workId);
                    string originalUsmhMouth2 = fullLengthLiningSectionDetailsGateway.GetUsmhMouth2Original(workId);
                    string originalUsmhMouth3 = fullLengthLiningSectionDetailsGateway.GetUsmhMouth3Original(workId);
                    string originalUsmhMouth4 = fullLengthLiningSectionDetailsGateway.GetUsmhMouth4Original(workId);
                    string originalUsmhMouth5 = fullLengthLiningSectionDetailsGateway.GetUsmhMouth5Original(workId);
                    string originalDsmhMouth12 = fullLengthLiningSectionDetailsGateway.GetDsmhMouth12Original(workId);
                    string originalDsmhMouth1 = fullLengthLiningSectionDetailsGateway.GetDsmhMouth1Original(workId);
                    string originalDsmhMouth2 = fullLengthLiningSectionDetailsGateway.GetDsmhMouth2Original(workId);
                    string originalDsmhMouth3 = fullLengthLiningSectionDetailsGateway.GetDsmhMouth3Original(workId);
                    string originalDsmhMouth4 = fullLengthLiningSectionDetailsGateway.GetDsmhMouth4Original(workId);
                    string originalDsmhMouth5 = fullLengthLiningSectionDetailsGateway.GetDsmhMouth5Original(workId);
                    string originalUsmhAddress = fullLengthLiningSectionDetailsGateway.GetUsmhAddressOriginal(workId);
                    string originalDsmhAddress = fullLengthLiningSectionDetailsGateway.GetDsmhAddressOriginal(workId);
                    string originalSubArea = fullLengthLiningSectionDetailsGateway.GetSubAreaOriginal(workId);
                    string originalThickness = fullLengthLiningSectionDetailsGateway.GetThicknessOriginal(workId);

                    // New variables
                    string newStreet = fullLengthLiningSectionDetailsGateway.GetStreet(workId);
                    string newUsmh = fullLengthLiningSectionDetailsGateway.GetUsmhDescription(workId);
                    string newDsmh = fullLengthLiningSectionDetailsGateway.GetDsmhDescription(workId);
                    string newMapSize = fullLengthLiningSectionDetailsGateway.GetMapSize(workId);
                    string newSize = fullLengthLiningSectionDetailsGateway.GetSize_(workId);
                    string newMapLength = fullLengthLiningSectionDetailsGateway.GetMapLength(workId);
                    string newLength = fullLengthLiningSectionDetailsGateway.GetLength(workId);
                    int? newLaterals = fullLengthLiningSectionDetailsGateway.GetLaterals(workId);
                    int? newLiveLaterals = fullLengthLiningSectionDetailsGateway.GetLiveLaterals(workId);
                    string newUsmhDepth = fullLengthLiningSectionDetailsGateway.GetUsmhDepth(workId);
                    string newDsmhDepth = fullLengthLiningSectionDetailsGateway.GetDsmhDepth(workId);
                    string newSteelTapeThroughSewer = fullLengthLiningSectionDetailsGateway.GetSteelTapeThroughSewer(workId);
                    string newUsmhMouth12 = fullLengthLiningSectionDetailsGateway.GetUsmhMouth12(workId);
                    string newUsmhMouth1 = fullLengthLiningSectionDetailsGateway.GetUsmhMouth1(workId);
                    string newUsmhMouth2 = fullLengthLiningSectionDetailsGateway.GetUsmhMouth2(workId);
                    string newUsmhMouth3 = fullLengthLiningSectionDetailsGateway.GetUsmhMouth3(workId);
                    string newUsmhMouth4 = fullLengthLiningSectionDetailsGateway.GetUsmhMouth4(workId);
                    string newUsmhMouth5 = fullLengthLiningSectionDetailsGateway.GetUsmhMouth5(workId);
                    string newDsmhMouth12 = fullLengthLiningSectionDetailsGateway.GetDsmhMouth12(workId);
                    string newDsmhMouth1 = fullLengthLiningSectionDetailsGateway.GetDsmhMouth1(workId);
                    string newDsmhMouth2 = fullLengthLiningSectionDetailsGateway.GetDsmhMouth2(workId);
                    string newDsmhMouth3 = fullLengthLiningSectionDetailsGateway.GetDsmhMouth3(workId);
                    string newDsmhMouth4 = fullLengthLiningSectionDetailsGateway.GetDsmhMouth4(workId);
                    string newDsmhMouth5 = fullLengthLiningSectionDetailsGateway.GetDsmhMouth5(workId);
                    string newUsmhAddress = fullLengthLiningSectionDetailsGateway.GetUsmhAddress(workId);
                    string newDsmhAddress = fullLengthLiningSectionDetailsGateway.GetDsmhAddress(workId);
                    string newSubArea = fullLengthLiningSectionDetailsGateway.GetSubArea(workId);
                    string newThickness = fullLengthLiningSectionDetailsGateway.GetThickness(workId);

                    // Update
                    Update(projectId, countryId, provinceId, countyId, cityId, workId, assetId, sectionId, originalStreet, originalUsmh, originalUsmhId, originalDsmh, originalDsmhId, originalMapSize, originalSize, originalMapLength, originalLength, originalLaterals, originalLiveLaterals, originalUsmhDepth, originalDsmhDepth, originalSteelTapeThroughSewer, originalSubArea, originalUsmhMouth12, originalUsmhMouth1, originalUsmhMouth2, originalUsmhMouth3, originalUsmhMouth4, originalUsmhMouth5, originalDsmhMouth12, originalDsmhMouth1, originalDsmhMouth2, originalDsmhMouth3, originalDsmhMouth4, originalDsmhMouth5,  false, companyId, originalUsmhAddress, originalDsmhAddress, originalThickness, workId, assetId, sectionId, newStreet, newUsmh, newDsmh, newMapSize, newSize, newMapLength, newLength, newLaterals, newLiveLaterals, newUsmhDepth, newDsmhDepth, newSteelTapeThroughSewer, newSubArea, newUsmhMouth12, newUsmhMouth1, newUsmhMouth2, newUsmhMouth3, newUsmhMouth4, newUsmhMouth5, newDsmhMouth12, newDsmhMouth1, newDsmhMouth2, newDsmhMouth3, newDsmhMouth4, newDsmhMouth5, false, companyId, newUsmhAddress, newDsmhAddress, newThickness);         
                }
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="workId">workId</param>
        public void Delete(int workId)
        {
            FullLengthLiningTDS.SectionDetailsRow row = GetRow(workId);
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
            // Insert USMH if data change (only if not exists)
            int? newUsmh = originalUsmh;
            if (originalUsmhId != newUsmhId)
            {
                if (newUsmhId.Trim() != "")
                {
                    LfsAssetSewerMH lfsAssetSewerUsmh = new LfsAssetSewerMH(null);
                    newUsmh = lfsAssetSewerUsmh.InsertDirect(countryId, provinceId, countyId, cityId, newUsmhId, "", "", newUsmhAddress, false, originalCompanyId, "", "", null, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", null, "", "", null);
                }
                else
                {
                    newUsmh = null;
                }
            }
            else
            {
                // Update existing mh
                UpdateMH(countryId, provinceId, countyId, cityId, originalUsmhId, originalUsmhAddress, newUsmhAddress, originalCompanyId);
            }

            // insert DSMH if data change (only if not exists)
            int? newDsmh = originalDsmh;
            if (originalDsmhId != newDsmhId)
            {
                if (newDsmhId.Trim() != "")
                {
                    LfsAssetSewerMH lfsAssetSewerDsmh = new LfsAssetSewerMH(null);
                    newDsmh = lfsAssetSewerDsmh.InsertDirect(countryId, provinceId, countyId, cityId, newDsmhId, "", "", newDsmhAddress, false, originalCompanyId, "", "", null, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", null, "", "", null);
                }
                else
                {
                    newDsmh = null;
                }
            }
            else
            {
                // Update existing mh
                UpdateMH(countryId, provinceId, countyId, cityId, originalDsmhId, originalDsmhAddress, newDsmhAddress, originalCompanyId);
            }

            // update section
            UpdateSection(originalWorkId, originalAssetId, originalSectionId, originalStreet, originalUsmh,  originalDsmh,  originalMapSize, originalSize, originalMapLength, originalLength, originalLaterals,  originalLiveLaterals, originalUsmhDepth, originalDsmhDepth, originalSteelTapeThroughSewer, originalSubArea, originalUsmhMouth12, originalUsmhMouth1, originalUsmhMouth2,  originalUsmhMouth3,  originalUsmhMouth4,  originalUsmhMouth5, originalDsmhMouth12, originalDsmhMouth1, originalDsmhMouth2, originalDsmhMouth3, originalDsmhMouth4, originalDsmhMouth5,  originalDeleted, originalCompanyId, originalUsmhAddress, originalDsmhAddress, originalThickness, newWorkId, newAssetId, newSectionId, newStreet, newUsmh, newDsmh, newMapSize, newSize, newMapLength, newLength, newLaterals, newLiveLaterals, newUsmhDepth, newDsmhDepth, newSteelTapeThroughSewer, newSubArea, newUsmhMouth12,  newUsmhMouth1, newUsmhMouth2, newUsmhMouth3, newUsmhMouth4, newUsmhMouth5, newDsmhMouth12, newDsmhMouth1, newDsmhMouth2, newDsmhMouth3, newDsmhMouth4,  newDsmhMouth5, newDeleted, newCompanyId, newUsmhAddress, newDsmhAddress, projectId, newThickness);
        }



        /// <summary>
        /// UpdateMH
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="mhId">mhId</param>
        /// <param name="originalUsmhAddress">originalUsmhAddress</param>
        /// <param name="newUsmhAddress">newUsmhAddress</param>
        /// <param name="companyId">companyId</param>
        private void UpdateMH(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, string mhId, string originalAddress, string newAddress, int companyId)
        {
            // Get unchanged data
            // ... mh
            AssetSewerMHGateway assetSewerMHGateway = new AssetSewerMHGateway();
            assetSewerMHGateway.LoadByCountryIdProvinceIdCountyIdCityIdMhId(countryId, provinceId, countyId, cityId, mhId, companyId, "", "", ""); //TODO MH

            // Update mh
            if (assetSewerMHGateway.Table.Rows.Count > 0)
            {
                int originalAssetId = assetSewerMHGateway.GetAssetID(mhId);
                string originalLatitude = assetSewerMHGateway.GetLatitude(mhId);
                string originalLongitude = assetSewerMHGateway.GetLongitude(mhId);
                bool originalDeleted = assetSewerMHGateway.GetDeleted(mhId);
                int originalCompanyId = assetSewerMHGateway.GetCompanyId(mhId);

                string originalManholeShape = assetSewerMHGateway.GetManholeShape(mhId);
                string originalLocation = assetSewerMHGateway.GetLocation(mhId);
                int? originalMaterialID = assetSewerMHGateway.GetMaterialID(mhId);
                string originalTopDiameter = assetSewerMHGateway.GetTopDepth(mhId);
                string originalTopDepth = assetSewerMHGateway.GetTopDepth(mhId);
                string originalTopFloor = assetSewerMHGateway.GetTopFloor(mhId);
                string originalTopCeiling = assetSewerMHGateway.GetTopFloor(mhId);
                string originalTopBenching = assetSewerMHGateway.GetTopBenching(mhId);
                string originalDownDiameter = assetSewerMHGateway.GetDownDiameter(mhId);
                string originalDownDepth = assetSewerMHGateway.GetDownDepth(mhId);
                string originalDownFloor = assetSewerMHGateway.GetDownFloor(mhId);
                string originalDownCeiling = assetSewerMHGateway.GetDownCeiling(mhId);
                string originalDownBenching = assetSewerMHGateway.GetDownBenching(mhId);
                string originalRectangle1LongSide = assetSewerMHGateway.GetRectangle1LongSide(mhId);
                string originalRectangle1ShortSide = assetSewerMHGateway.GetRectangle1ShortSide(mhId);
                string originalRectangle2LongSide = assetSewerMHGateway.GetRectangle2LongSide(mhId);
                string originalRectangle2ShortSide = assetSewerMHGateway.GetRectangle2ShortSide(mhId);
                string originalTopSurfaceArea = assetSewerMHGateway.GetTopSurfaceArea(mhId);
                string originalDownSurfaceArea = assetSewerMHGateway.GetDownSurfaceArea(mhId);
                int? originalManholeRugs = assetSewerMHGateway.GetManholeRugs(mhId);
                string originalTotalDepth = assetSewerMHGateway.GetTotalDepth(mhId);
                string originalTotalSurfaceArea = assetSewerMHGateway.GetTotalSurfaceArea(mhId);                

                AssetSewerMH assetSewerMH = new AssetSewerMH(assetSewerMHGateway.Data);
                assetSewerMH.UpdateDirect(originalAssetId, mhId, originalLatitude, originalLongitude, originalAddress, originalManholeShape, originalLocation, originalMaterialID, originalTopDiameter, originalTopDepth, originalTopFloor, originalTopCeiling, originalTopBenching, originalDownDiameter, originalDownDepth, originalDownFloor, originalDownCeiling, originalDownBenching, originalRectangle1LongSide, originalRectangle1ShortSide, originalRectangle2LongSide, originalRectangle2ShortSide, originalTopSurfaceArea, originalDownSurfaceArea, originalManholeRugs, originalTotalDepth, originalTotalSurfaceArea, originalDeleted, originalCompanyId, originalAssetId, mhId, originalLatitude, originalLongitude, newAddress, originalManholeShape, originalLocation, originalMaterialID, originalTopDiameter, originalTopDepth, originalTopFloor, originalTopCeiling, originalTopBenching, originalDownDiameter, originalDownDepth, originalDownFloor, originalDownCeiling, originalDownBenching, originalRectangle1LongSide, originalRectangle1ShortSide, originalRectangle2LongSide, originalRectangle2ShortSide, originalTopSurfaceArea, originalDownSurfaceArea, originalManholeRugs, originalTotalDepth, originalTotalSurfaceArea, originalDeleted, originalCompanyId);
            }
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
            // Get unchanged data
            // ... section
            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
            assetSewerSectionGateway.LoadByAssetId(assetId, originalCompanyId);

            int? laterals = assetSewerSectionGateway.GetLaterals(assetId);
            string flowDirection = assetSewerSectionGateway.GetFlowDirection(assetId);

            // Update section
            LfsAssetSewerSection lfsAssetSewerSection = new LfsAssetSewerSection(null);
            lfsAssetSewerSection.UpdateDirect(assetId, originalSectionId, originalStreet, originalUsmh, originalDsmh, originalMapSize, originalSize, originalMapLength, originalLength, originalLaterals, originalLiveLaterals, flowDirection, originalUsmhDepth, originalDsmhDepth, originalSteelTapeThroughSewer, originalUsmhMouth12, originalUsmhMouth1, originalUsmhMouth2, originalUsmhMouth3, originalUsmhMouth4, originalUsmhMouth5, originalDsmhMouth12, originalDsmhMouth1, originalDsmhMouth2, originalDsmhMouth3, originalDsmhMouth4, originalDsmhMouth5, originalDelete, originalCompanyId, originalSubArea, originalThickness, assetId, newSectionId, newStreet, newUsmh, newDsmh, newMapSize, newSize, newMapLength, newLength, newLaterals, newLiveLaterals, flowDirection, newUsmhDepth, newDsmhDepth, newSteelTapeThroughSewer, newUsmhMouth12, newUsmhMouth1, newUsmhMouth2, newUsmhMouth3, newUsmhMouth4, newUsmhMouth5, newDsmhMouth12, newDsmhMouth1, newDsmhMouth2, newDsmhMouth3, newDsmhMouth4, newDsmhMouth5, newDelete, newCompanyId, newSubArea, newThickness); 
        }


        /// <summary>
        /// UpdateFieldsForSections
        /// </summary>
        private void UpdateFieldsForSections()
        {
            foreach (FullLengthLiningTDS.SectionDetailsRow row in (FullLengthLiningTDS.SectionDetailsDataTable)Table)
            {
                if (!row.IsSize_Null())
                {
                    try
                    {
                        if (Distance.IsValidDistance(row.Size_))
                        {
                            Distance distance = new Distance(row.Size_);
                            
                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.Size_ = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    if (Convert.ToDouble(row.Size_) > 99)
                                    {
                                        double newSize_ = 0;
                                        newSize_ = Convert.ToDouble(row.Size_) * 0.03937;
                                        row.Size_ = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                    }
                                    else
                                    {
                                        if (Validator.IsValidInt32(row.Size_))
                                        {
                                            row.Size_ = row.Size_ + "\"";
                                        }
                                    }
                                    break;
                                case 4:
                                    row.Size_ = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.Size_ = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }



        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Row obtained</returns>
        private FullLengthLiningTDS.SectionDetailsRow GetRow(int workId)
        {
            FullLengthLiningTDS.SectionDetailsRow row = ((FullLengthLiningTDS.SectionDetailsDataTable)Table).FindByWorkID(workId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.FullLengthLining.FullLengthLiningSectionDetails.GetRow");
            }

            return row;
        }
                   


    }
}