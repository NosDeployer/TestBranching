using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.Assets.Assets;

namespace LiquiForce.LFSLive.BL.Assets.Assets
{
    /// <summary>
    /// AssetSewerLateral
    /// </summary>
    public class AssetSewerLateral : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AssetSewerLateral() : base("AM_ASSET_SEWER_LATERAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AssetSewerLateral(DataSet data) : base(data, "AM_ASSET_SEWER_LATERAL")
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
        /// <param name="section_">section_</param>
        /// <param name="address">address</param>
        /// <param name="lateralID">lateralID</param>
        /// <param name="latitudeAtSection">latitudeAtSection</param>
        /// <param name="longitudeAtSection">longitudeAtSection</param>
        /// <param name="latitudeAtPropertyLine">latitudeAtPropertyLine</param>
        /// <param name="longitudeAtPropertyLine">longitudeAtPropertyLine</param>
        /// <param name="state">state</param>
        /// <param name="size_">size_</param>
        /// <param name="distanceFromUSMH">distanceFromUSMH</param>
        /// <param name="distanceFromDSMH">distanceFromDSMH</param>
        /// <param name="mapSize">mapSize</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="connectionType">connectionType</param>
        /// <returns></returns>
        public int InsertDirect(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int section_, string address, string lateralID, string latitudeAtSection, string longitudeAtSection, string latitudeAtPropertyLine, string longitudeAtPropertyLine, string state, string size_, string distanceFromUSMH, string distanceFromDSMH, string mapSize, bool deleted, int companyId, string connectionType)
        {
            AssetSewerLateralGateway assetSewerLateralGateway = new AssetSewerLateralGateway();
            assetSewerLateralGateway.LoadBySectionLateralId(section_, lateralID, companyId);

            int lateral_assetId = 0;
            if (assetSewerLateralGateway.Table.Rows.Count == 0)
            {
                // Insert Asset
                lateral_assetId = new Asset(new DataSet()).InsertDirect("Sewer", countryId, provinceId, countyId, cityId, deleted, companyId);
                new AssetSewer(new DataSet()).InsertDirect(lateral_assetId, "Lateral", deleted, companyId);
                assetSewerLateralGateway.Insert(lateral_assetId, section_, address, lateralID, latitudeAtSection, longitudeAtSection, latitudeAtPropertyLine, longitudeAtPropertyLine, state, size_, distanceFromUSMH, distanceFromDSMH, mapSize, deleted, companyId, connectionType);
                
                // Update Section
                // ... load section
                AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
                assetSewerSectionGateway.LoadByAssetId(section_, companyId);

                // ... get old values of section
                string sectionIdS = assetSewerSectionGateway.GetSectionId(section_);
                string streetS = assetSewerSectionGateway.GetStreet(section_);
                int? usmhIdS = assetSewerSectionGateway.GetUSMH(section_);
                int? dsmhIdS = assetSewerSectionGateway.GetDSMH(section_);
                string mapSizeS = assetSewerSectionGateway.GetMapSize(section_);
                string size_S = assetSewerSectionGateway.GetSize_(section_);
                string mapLengthS = assetSewerSectionGateway.GetMapSize(section_);
                string lengthS = assetSewerSectionGateway.GetLength(section_);
                int? lateralsS = assetSewerSectionGateway.GetLaterals(section_);
                int? liveLateralsS = assetSewerSectionGateway.GetLiveLaterals(section_);
                string flowDirectionS = assetSewerSectionGateway.GetFlowDirection(section_);
                string usmhDepthS = assetSewerSectionGateway.GetUSMHDepth(section_);
                string dsmhDepthS = assetSewerSectionGateway.GetDSMHDepth(section_);
                string flowOrderIdS = assetSewerSectionGateway.GetFlowOrderID(section_);

                // ... calculate new values of section
                int? newLaterals  = lateralsS;
                if (newLaterals.HasValue)
                {
                    newLaterals = newLaterals + 1;
                }
                else
                {
                    newLaterals = 1;
                }

                int? newLiveLaterals = liveLateralsS;
                if (state == "Live")
                {
                    if (newLiveLaterals.HasValue)
                    {
                        newLiveLaterals = newLiveLaterals + 1;
                    }
                    else
                    {
                        newLiveLaterals = 1;
                    }
                }
                else
                {
                    newLiveLaterals = 0;
                }

                // ... update section
                AssetSewerSection assetSewerSection = new AssetSewerSection(assetSewerSectionGateway.Data);
                assetSewerSection.UpdateDirect(section_, sectionIdS, streetS, usmhIdS, dsmhIdS, mapSizeS, size_S, mapLengthS, lengthS, lateralsS, liveLateralsS, flowDirectionS, usmhDepthS, dsmhDepthS, deleted, companyId, flowOrderIdS, section_, sectionIdS, streetS, usmhIdS, dsmhIdS, mapSizeS, size_S, mapLengthS, lengthS, newLaterals, newLiveLaterals, flowDirectionS, usmhDepthS, dsmhDepthS, deleted, companyId, flowOrderIdS);
            }
            else
            {
                lateral_assetId = assetSewerLateralGateway.GetAssetID(section_, lateralID);
            }

            return lateral_assetId;
        }


        
        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        public bool DeleteDirect(int assetId, int companyId)
        {
            // Get initial data
            AssetSewerLateralGateway assetSewerLateralGateway = new AssetSewerLateralGateway();
            assetSewerLateralGateway.LoadByAssetId(assetId, companyId);
            int section_ = assetSewerLateralGateway.GetSection(assetId);
            string state = assetSewerLateralGateway.GetState(assetId);

            // Delete lateral
            assetSewerLateralGateway.Delete(assetId, companyId);
            AssetSewer assetSewer = new AssetSewer(null);
            assetSewer.DeleteDirect(assetId, companyId);
            Asset asset = new Asset(null);
            asset.DeleteDirect(assetId, companyId);

            // Update Section
            // ... Load section
            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
            assetSewerSectionGateway.LoadByAssetId(section_, companyId);

            // ... Get old values of section 
            string sectionIdS = assetSewerSectionGateway.GetSectionId(section_);
            string streetS = assetSewerSectionGateway.GetStreet(section_);
            int? usmhIdS = assetSewerSectionGateway.GetUSMH(section_);
            int? dsmhIdS = assetSewerSectionGateway.GetDSMH(section_);
            string mapSizeS = assetSewerSectionGateway.GetMapSize(section_);
            string size_S = assetSewerSectionGateway.GetSize_(section_);
            string mapLengthS = assetSewerSectionGateway.GetMapSize(section_);
            string lengthS = assetSewerSectionGateway.GetLength(section_);
            int? lateralsS = assetSewerSectionGateway.GetLaterals(section_);
            int? liveLateralsS = assetSewerSectionGateway.GetLiveLaterals(section_);
            string flowDirectionS = assetSewerSectionGateway.GetFlowDirection(section_);
            string usmhDepthS = assetSewerSectionGateway.GetUSMHDepth(section_);
            string dsmhDepthS = assetSewerSectionGateway.GetDSMHDepth(section_);
            bool deletedS = assetSewerSectionGateway.GetDeleted(section_);
            string flowOrderIdS = assetSewerSectionGateway.GetFlowOrderID(section_);

            // ... Calculate new values of section
            int? newLaterals = lateralsS - 1;
            
            int? newLiveLaterals = liveLateralsS;
            if ((newLiveLaterals.HasValue) && (state == "Live"))
            {
                newLiveLaterals = newLiveLaterals - 1;
            }

            // ... Update section
            AssetSewerSection assetSewerSection = new AssetSewerSection(assetSewerSectionGateway.Data);
            assetSewerSection.UpdateDirect(section_, sectionIdS, streetS, usmhIdS, dsmhIdS, mapSizeS, size_S, mapLengthS, lengthS, lateralsS, liveLateralsS, flowDirectionS, usmhDepthS, dsmhDepthS, deletedS, companyId, flowOrderIdS, section_, sectionIdS, streetS, usmhIdS, dsmhIdS, mapSizeS, size_S, mapLengthS, lengthS, newLaterals, newLiveLaterals, flowDirectionS, usmhDepthS, dsmhDepthS, deletedS, companyId, flowOrderIdS);

            return true;
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalAssetId">originalAssetId</param>
        /// <param name="originalSection_">originalSection_</param>
        /// <param name="originalAddress">originalAddress</param>
        /// <param name="originalLateralId">originalLateralId</param>
        /// <param name="originalLatitudeAtSection">originalLatitudeAtSection</param>
        /// <param name="originalLongitudeAtSection">originalLongitudeAtSection</param>
        /// <param name="originalLatitudeAtPropertyLine">originalLatitudeAtPropertyLine</param>
        /// <param name="originalLongitudeAtPropertyLine">originalLongitudeAtPropertyLine</param>
        /// <param name="originalState">originalState</param>
        /// <param name="orignalSize">orignalSize</param>
        /// <param name="originalDistanceFromUsmh">originalDistanceFromUsmh</param>
        /// <param name="originalDistanceFromDsmh">originalDistanceFromDsmh</param>
        /// <param name="originalMapSize">originalMapSize</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalConnectionType">originalConnectionType</param>
        /// 
        /// <param name="newAssetId">newAssetId</param>
        /// <param name="newSection_">newSection_</param>
        /// <param name="newAddress">newAddress</param>
        /// <param name="newLateralId">newLateralId</param>
        /// <param name="newLatitudeAtSection">newLatitudeAtSection</param>
        /// <param name="newLongitudeAtSection">newLongitudeAtSection</param>
        /// <param name="newLatitudeAtPropertyLine">newLatitudeAtPropertyLine</param>
        /// <param name="newLongitudeAtPropertyLine">newLongitudeAtPropertyLine</param>
        /// <param name="newState">newState</param>
        /// <param name="newSize">newSize</param>
        /// <param name="newDistanceFromUsmh">newDistanceFromUsmh</param>
        /// <param name="newDistanceFromDsmh">newDistanceFromDsmh</param>
        /// <param name="newMapSize">newMapSize</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newConnectionType">newConnectionType</param>
        public void UpdateDirect(int originalAssetId, int originalSection_, string originalAddress, string originalLateralId, string originalLatitudeAtSection, string originalLongitudeAtSection, string originalLatitudeAtPropertyLine, string originalLongitudeAtPropertyLine, string originalState, string orignalSize, string originalDistanceFromUsmh, string originalDistanceFromDsmh, string originalMapSize, bool originalDeleted, int originalCompanyId, string originalConnectionType, int newAssetId, int newSection_, string newAddress, string newLateralId, string newLatitudeAtSection, string newLongitudeAtSection, string newLatitudeAtPropertyLine, string newLongitudeAtPropertyLine, string newState, string newSize, string newDistanceFromUsmh, string newDistanceFromDsmh, string newMapSize, bool newDeleted, int newCompanyId, string newConnectionType)
        {
            AssetSewerLateralGateway assetSewerLateralGateway = new AssetSewerLateralGateway();
            assetSewerLateralGateway.Update(originalAssetId, originalSection_, originalAddress, originalLateralId, originalLatitudeAtSection, originalLongitudeAtSection, originalLatitudeAtPropertyLine, originalLongitudeAtPropertyLine, originalState, orignalSize, originalDistanceFromUsmh, originalDistanceFromDsmh, originalMapSize, originalDeleted, originalCompanyId, originalConnectionType, newAssetId, newSection_, newAddress, newLateralId, newLatitudeAtSection, newLongitudeAtSection, newLatitudeAtPropertyLine, newLongitudeAtPropertyLine, newState, newSize, newDistanceFromUsmh, newDistanceFromDsmh, newMapSize, newDeleted, newCompanyId, newConnectionType);

            // Update section
            if ((originalState != newState) && ((newState == "Live") || (originalState == "Live")))
            {
                // ... Load section
                AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
                assetSewerSectionGateway.LoadByAssetId(originalSection_, originalCompanyId);

                // ... Get old values of section
                string sectionIdS = assetSewerSectionGateway.GetSectionId(originalSection_);
                string streetS = assetSewerSectionGateway.GetStreet(originalSection_);
                int? usmhIdS = assetSewerSectionGateway.GetUSMH(originalSection_);
                int? dsmhIdS = assetSewerSectionGateway.GetDSMH(originalSection_);
                string mapSizeS = assetSewerSectionGateway.GetMapSize(originalSection_);
                string size_S = assetSewerSectionGateway.GetSize_(originalSection_);
                string mapLengthS = assetSewerSectionGateway.GetMapSize(originalSection_);
                string lengthS = assetSewerSectionGateway.GetLength(originalSection_);
                int? lateralsS = assetSewerSectionGateway.GetLaterals(originalSection_);
                int? liveLateralsS = assetSewerSectionGateway.GetLiveLaterals(originalSection_);
                string flowDirectionS = assetSewerSectionGateway.GetFlowDirection(originalSection_);
                string usmhDepthS = assetSewerSectionGateway.GetUSMHDepth(originalSection_);
                string dsmhDepthS = assetSewerSectionGateway.GetDSMHDepth(originalSection_);
                bool deletedS = assetSewerSectionGateway.GetDeleted(originalSection_);
                string flowOrderIdS = assetSewerSectionGateway.GetFlowOrderID(originalSection_);

                // ... Calculate new values of section
                int? newLiveLaterals = liveLateralsS;
                if (originalState == "Live")
                {
                    newLiveLaterals = newLiveLaterals - 1;
                }
                if (newState == "Live")
                {
                    newLiveLaterals = newLiveLaterals + 1;
                }

                // ... Update section
                AssetSewerSection assetSewerSection = new AssetSewerSection(assetSewerSectionGateway.Data);
                assetSewerSection.UpdateDirect(originalSection_, sectionIdS, streetS, usmhIdS, dsmhIdS, mapSizeS, size_S, mapLengthS, lengthS, lateralsS, liveLateralsS, flowDirectionS, usmhDepthS, dsmhDepthS, deletedS, originalCompanyId, flowOrderIdS, originalSection_, sectionIdS, streetS, usmhIdS, dsmhIdS, mapSizeS, size_S, mapLengthS, lengthS, lateralsS, newLiveLaterals, flowDirectionS, usmhDepthS, dsmhDepthS, deletedS, originalCompanyId, flowOrderIdS);
            }
        }


                
        /// <summary>
        /// GetAllLaterals
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public string GetAllLaterals(int sectionId, int companyId) //ojo: mario - para que sirve?
        {
            string laterals = "";

            foreach (AssetsTDS.AM_ASSET_SEWER_LATERALRow row in (AssetsTDS.AM_ASSET_SEWER_LATERALDataTable)Table)
            {
                if ((row.Section_ == sectionId) && (row.COMPANY_ID == companyId))
                {
                    // ... Form the laterals string
                    if (laterals.Trim().Length <= 0)
                    {
                        laterals = laterals + row.LateralID;
                    }
                    else
                    {
                        laterals = laterals + ", " + row.LateralID; ;
                    }
                }
            }
            return (laterals);
        }
        


    }
}
