using System;
using System.Data;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Assets
{
    /// <summary>
    /// LfsAssetSewerSection
    /// </summary>
    public class LfsAssetSewerSection : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LfsAssetSewerSection() : base("LFS_ASSET_SEWER_SECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LfsAssetSewerSection(DataSet data) : base(data, "LFS_ASSET_SEWER_SECTION")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new LfsAssetsTDS();
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
        /// <param name="subArea">subArea</param>
        /// <param name="usmh">usmh</param>
        /// <param name="dsmh">dsmh</param>
        /// <param name="mapSize">mapSize</param>
        /// <param name="size_">size_</param>
        /// <param name="mapLength">mapLength</param>
        /// <param name="length">length</param>
        /// <param name="laterals">laterals</param>
        /// <param name="liveLaterals">liveLaterals</param>
        /// <param name="flowDirection">flowDirection</param>
        /// <param name="usmhDepth">usmhDepth</param>
        /// <param name="dsmhDepth">dsmhDepth</param>
        /// <param name="usmhAddress">usmhAddress</param>
        /// <param name="dsmhAddress">dsmhAddress</param>
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
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="subArea">subArea</param>
        /// <param name="thickness">thickness</param>
        /// <param name="sectionMaterialRefId">sectionMaterialRefId</param>
        /// <param name="sectionMaterial">sectionMaterial</param>
        /// <param name="sectionMaterialDate">sectionMaterialDate</param>
        /// <returns></returns>
        public int InsertDirect(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, string sectionId, string street, int? usmh, int? dsmh, string mapSize, string size_, string mapLength, string length, int? laterals, int? liveLaterals, string flowDirection, string usmhDepth, string dsmhDepth, string usmhAddress, string dsmhAddress, string steelTapeThroughSewer, string usmhMouth12, string usmhMouth1, string usmhMouth2, string usmhMouth3, string usmhMouth4, string usmhMouth5, string dsmhMouth12, string dsmhMouth1, string dsmhMouth2, string dsmhMouth3, string dsmhMouth4, string dsmhMouth5, bool deleted, int companyId, string subArea, string thickness, int sectionMaterialRefId, string sectionMaterial, DateTime sectionMaterialDate)
        {
            string newSectionId = "";
            string newFlowOrderId = "";

            // Verify sectionId
            string[] secuentialPart = sectionId.Split('-');
            if (secuentialPart.Length > 2)
            {
                // ... Intermediate section Id
                newSectionId = sectionId;
                newFlowOrderId = newSectionId.Substring(newSectionId.Length - 6, 6);
            }
            else
            {
                if (secuentialPart.Length == 2)
                {
                    // ... Existent section Id
                    newSectionId = sectionId;
                    newFlowOrderId = secuentialPart[1];
                }
                else
                { 
                    // ... New Section Id
                    newSectionId = GetSectionNextId(countryId, provinceId, countyId, cityId, companyId);
                    newFlowOrderId = newSectionId.Substring(newSectionId.Length - 6, 6);
                }
            }

            // insert section, materials and MHs in AM tables (only if not exists)
            AssetSewerSection assetSewerSection = new AssetSewerSection(new DataSet());
            int section_assetId = assetSewerSection.InsertDirect(countryId, provinceId, countyId, cityId, newSectionId, street, usmh, dsmh, mapSize, size_, mapLength, length, laterals, liveLaterals, flowDirection, usmhDepth, dsmhDepth, usmhAddress, dsmhAddress, deleted, companyId, newFlowOrderId);
                        
            if (sectionMaterial != "" )
            {
                new AssetSewerMaterial(new DataSet()).InsertDirect(section_assetId, sectionMaterialRefId, sectionMaterial, sectionMaterialDate, deleted, companyId);
            }

            // verify if section exists in LFS tables for insertion
            LfsAssetSewerSectionGateway lfsAssetSewerSectionGateway = new LfsAssetSewerSectionGateway();
            lfsAssetSewerSectionGateway.LoadByAssetId(section_assetId, companyId);
            if (lfsAssetSewerSectionGateway.Table.Rows.Count == 0)
            {
                new LfsAsset(new DataSet()).InsertDirect(section_assetId, deleted, companyId);
                new LfsAssetSewer(new DataSet()).InsertDirect(section_assetId, deleted, companyId);
                lfsAssetSewerSectionGateway.Insert(section_assetId, steelTapeThroughSewer, usmhMouth12, usmhMouth1, usmhMouth2, usmhMouth3, usmhMouth4, usmhMouth5, dsmhMouth12, dsmhMouth1, dsmhMouth2, dsmhMouth3, dsmhMouth4, dsmhMouth5, deleted, companyId, subArea, thickness);
            }

            return section_assetId;
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
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
        /// <param name="originalSteelTapeThroughSewer">originalSteelTapeThroughSewer</param>
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
        /// <param name="originalSubArea">originalSubArea</param>
        /// <param name="originalThickness">originalThickness</param>
        /// 
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
        /// <param name="newSteelTapeThroughSewer">newSteelTapeThroughSewer</param>
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
        /// <param name="newSubArea">newSubArea</param>
        /// <param name="newThickness">newThickness</param>
        public void UpdateDirect(int originalAssetId, string originalSectionId, string originalStreet, int? originalUsmh, int? originalDsmh, string originalMapSize, string originalSize, string originalMapLength, string originalLength, int? originalLaterals, int? originalLiveLaterals, string originalFlowDirection, string originalUsmhDepth, string originalDsmhDepth, string originalSteelTapeThroughSewer, string originalUsmhMouth12, string originalUsmhMouth1, string originalUsmhMouth2, string originalUsmhMouth3, string originalUsmhMouth4, string originalUsmhMouth5, string originalDsmhMouth12, string originalDsmhMouth1, string originalDsmhMouth2, string originalDsmhMouth3, string originalDsmhMouth4, string originalDsmhMouth5, bool originalDeleted, int originalCompanyId, string originalSubArea, string originalThickness, int newAssetId, string newSectionId, string newStreet, int? newUsmh, int? newDsmh, string newMapSize, string newSize, string newMapLength, string newLength, int? newLaterals, int? newLiveLaterals, string newFlowDirection, string newUsmhDepth, string newDsmhDepth, string newSteelTapeThroughSewer, string newUsmhMouth12, string newUsmhMouth1, string newUsmhMouth2, string newUsmhMouth3, string newUsmhMouth4, string newUsmhMouth5, string newDsmhMouth12, string newDsmhMouth1, string newDsmhMouth2, string newDsmhMouth3, string newDsmhMouth4, string newDsmhMouth5, bool newDeleted, int newCompanyId, string newSubArea, string newThickness)
        {
            // update AM Section
            AssetSewerSection assetSewerSection = new AssetSewerSection(null);

            string originalFlowOrderId = "";
            string newFlowOrderId = "";

            // Verify sectionId
            string[] secuentialPart = originalSectionId.Split('-');
            if (secuentialPart[1].Contains("."))
            {
                // ... Flow order for intermediate section Id
                originalFlowOrderId = secuentialPart[1];
                newFlowOrderId = secuentialPart[1];
            }
            else
            {
                // ... Flow Order of section Id
                originalFlowOrderId = originalSectionId.Substring(originalSectionId.Length - 6, 6);
                newFlowOrderId = newSectionId.Substring(newSectionId.Length - 6, 6);
            }

            assetSewerSection.UpdateDirect(originalAssetId, originalSectionId, originalStreet, originalUsmh, originalDsmh, originalMapSize, originalSize, originalMapLength, originalLength, originalLaterals, originalLiveLaterals, originalFlowDirection, originalUsmhDepth, originalDsmhDepth, originalDeleted, originalCompanyId, originalFlowOrderId, newAssetId, newSectionId, newStreet, newUsmh, newDsmh, newMapSize, newSize, newMapLength, newLength, newLaterals, newLiveLaterals, newFlowDirection, newUsmhDepth, newDsmhDepth, newDeleted, newCompanyId, newFlowOrderId);

            // update LFS section
            if (originalLength != newLength)
            {
                newSteelTapeThroughSewer = newLength;
            }

            LfsAssetSewerSectionGateway lfsAssetSewerSectionGateway = new LfsAssetSewerSectionGateway(null);
            lfsAssetSewerSectionGateway.Update(originalAssetId, originalSteelTapeThroughSewer, originalUsmhMouth12, originalUsmhMouth1, originalUsmhMouth2, originalUsmhMouth3, originalUsmhMouth4, originalUsmhMouth5, originalDsmhMouth12, originalDsmhMouth1, originalDsmhMouth2, originalDsmhMouth3, originalDsmhMouth4, originalDsmhMouth5, originalDeleted, originalCompanyId, originalSubArea, originalThickness, newAssetId, newSteelTapeThroughSewer, newUsmhMouth12, newUsmhMouth1, newUsmhMouth2, newUsmhMouth3, newUsmhMouth4, newUsmhMouth5, newDsmhMouth12, newDsmhMouth1, newDsmhMouth2, newDsmhMouth3, newDsmhMouth4, newDsmhMouth5, newDeleted, newCompanyId, newSubArea, newThickness);

            // delete original usmh (if not in use)
            if ((newUsmh != originalUsmh) && (originalUsmh.HasValue))
            {
                LfsAssetSewerMH lfsAssetSewerUsmh = new LfsAssetSewerMH(null);
                lfsAssetSewerUsmh.DeleteDirect((int)originalUsmh, originalCompanyId);
            }

            // delete original dsmh (if not in use)
            if ((newDsmh != originalDsmh) && (originalDsmh.HasValue))
            {
                LfsAssetSewerMH lfsAssetSewerDsmh = new LfsAssetSewerMH(null);
                lfsAssetSewerDsmh.DeleteDirect((int)originalDsmh, originalCompanyId);
            }
        }


        
        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public bool DeleteDirect(int assetId, int companyId)
        {
            // Verify in use
            if (!InUse(assetId, companyId))
            {
                // Delete laterals
                // ... Define initial models
                LfsAssetSewerLateral lfsAssetSewerLateral = new LfsAssetSewerLateral(null);

                // ... Load laterals
                AssetSewerLateralGateway assetSewerLateralGateway = new AssetSewerLateralGateway();
                assetSewerLateralGateway.LoadBySectionId(assetId, companyId);

                // ... Delete laterals
                foreach (AssetsTDS.AM_ASSET_SEWER_LATERALRow rowLateral in (AssetsTDS.AM_ASSET_SEWER_LATERALDataTable)assetSewerLateralGateway.Table)
                {
                    lfsAssetSewerLateral.DeleteDirect(rowLateral.AssetID, companyId);
                }

                // Get MHs for deleted 
                AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
                assetSewerSectionGateway.LoadByAssetId(assetId, companyId);
                int? usmh_assetId = assetSewerSectionGateway.GetUSMH(assetId);
                int? dsmh_assetId = assetSewerSectionGateway.GetDSMH(assetId);

                // Delete section                
                LfsAssetSewerSectionGateway lfsAssetSewerSectionGateway = new LfsAssetSewerSectionGateway(null);
                lfsAssetSewerSectionGateway.Delete(assetId, companyId);

                LfsAssetSewer lfsAssetSewer = new LfsAssetSewer(null);
                lfsAssetSewer.DeleteDirect(assetId, companyId);

                LfsAsset lfsAsset = new LfsAsset(null);
                lfsAsset.DeleteDirect(assetId, companyId);

                // delete section in AM tables
                AssetSewerSection assetSewerSection = new AssetSewerSection(null);
                assetSewerSection.DeleteDirect(assetId, companyId);

                // Delete USMH (if not in use)
                if (usmh_assetId.HasValue)
                {
                    LfsAssetSewerMH lfsAssetSewerUsmh = new LfsAssetSewerMH(null);
                    lfsAssetSewerUsmh.DeleteDirect((int)usmh_assetId, companyId);
                }

                // Delete DSMH (if not in use)
                if (dsmh_assetId.HasValue)
                {
                    LfsAssetSewerMH lfsAssetSewerDsmh = new LfsAssetSewerMH(null);
                    lfsAssetSewerDsmh.DeleteDirect((int)dsmh_assetId, companyId);
                }

                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// Verify if section is in use
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public bool InUse(int assetId, int companyId)
        {
            // Verify work
            WorkGateway workGateway = new WorkGateway(null);
            if (workGateway.InUseAssetId(assetId, companyId))
            {
                return true;
            }

            return false;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
        
        /// <summary>
        /// GetSectionNextId
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>nextSectionId</returns>
        private string GetSectionNextId(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int companyId)
        {
            string nextSectionId = "";

            // Locations string
            string location = "";
            if (!countryId.HasValue) location = location + "0."; else location = location + countryId.ToString() + ".";
            if (!provinceId.HasValue) location = location + "0."; else location = location + provinceId.ToString() + ".";
            if (!countyId.HasValue) location = location + "0."; else location = location + countyId.ToString() + ".";
            if (!cityId.HasValue) location = location + "0"; else location = location + cityId.ToString();
            location = location + "-";

            // AutoIncrement part
            // ... load lastSectionId
            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
            string lastSectionId = "";

            if (assetSewerSectionGateway.GetLastSectionId(countryId, provinceId, countyId, cityId, companyId) != "")
            {
                lastSectionId = assetSewerSectionGateway.GetLastSectionId(countryId, provinceId, countyId, cityId, companyId);
            }

            // ... Get next secuential number
            string newSecuentialNumber = "";
            int lastSectionId_ = 0; 
            
            // ... If there is a last section id
            if (lastSectionId != "")
            {
                string[] lastSectionIdSplit = lastSectionId.Split('-');

                if (lastSectionIdSplit.Length >= 2)
                {
                    lastSectionId_ = Int32.Parse(lastSectionIdSplit[1]);
                }
            }
            newSecuentialNumber = GetSectionIncrement(lastSectionId_);

            // next sectionId
            nextSectionId = location + newSecuentialNumber;

            return nextSectionId;
        }



        /// <summary>
        /// GetSectionIncrement
        /// </summary>
        /// <param name="sectionIncrement">sectionIncrement</param>
        /// <returns>Section Increment string</returns>
        private string GetSectionIncrement(int sectionIncrement)
        {
            string newIncrement = "";

            if (sectionIncrement != 0)
            {
                // calc next increment
                sectionIncrement = sectionIncrement + 1;

                newIncrement = sectionIncrement.ToString().Trim();

                // complete string with 0
                for (int i = sectionIncrement.ToString().Length; i < 6; i++)
                {
                    newIncrement = "0" + newIncrement;
                }
            }
            else
            {
                // for first Id
                newIncrement = "000001";
            }

            return newIncrement;
        }



    }
}