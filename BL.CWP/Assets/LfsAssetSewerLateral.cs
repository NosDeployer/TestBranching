using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.Assets.Assets;

namespace LiquiForce.LFSLive.BL.CWP.Assets
{
    /// <summary>
    /// LfsAssetSewerLateral
    /// </summary>
    public class LfsAssetSewerLateral : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LfsAssetSewerLateral() : base("LFS_ASSET_SEWER_LATERAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LfsAssetSewerLateral(DataSet data) : base(data, "LFS_ASSET_SEWER_LATERAL")
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
        /// <param name="section_">section_</param>
        /// <param name="address">address</param>
        /// <param name="lateralId">lateralId</param>
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
        /// <returns>lateral_assetId</returns>
        public int InsertDirect(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int section_, string address, string lateralId, string latitudeAtSection, string longitudeAtSection, string latitudeAtPropertyLine, string longitudeAtPropertyLine, string state, string size_, string distanceFromUSMH, string distanceFromDSMH, string mapSize, bool deleted, int companyId, string connectionType)
        {
            // insert lateral in AM tables (only if not exists)
            AssetSewerLateral assetSewerLateral = new AssetSewerLateral(null);
            int lateral_assetId = assetSewerLateral.InsertDirect(countryId, provinceId, countyId, cityId, section_, address, lateralId, latitudeAtSection, longitudeAtSection, latitudeAtPropertyLine, longitudeAtPropertyLine, state, size_, distanceFromUSMH, distanceFromDSMH, mapSize, deleted, companyId, connectionType);

            // verify if section exists in LFS tables for insertion
            LfsAssetSewerLateralGateway lfsAssetSewerLateralGateway = new LfsAssetSewerLateralGateway();
            lfsAssetSewerLateralGateway.LoadByAssetId(lateral_assetId, companyId);
            
            if (lfsAssetSewerLateralGateway.Table.Rows.Count == 0)
            {
                new LfsAsset(new DataSet()).InsertDirect(lateral_assetId, deleted, companyId);
                new LfsAssetSewer(new DataSet()).InsertDirect(lateral_assetId, deleted, companyId);
                lfsAssetSewerLateralGateway.Insert(lateral_assetId, deleted, companyId);
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
            if (!InUse(assetId, companyId))
            {
                // delete in LFS tables
                LfsAssetSewerLateralGateway lfsAssetSewerLateralGateway = new LfsAssetSewerLateralGateway(null);
                lfsAssetSewerLateralGateway.Delete(assetId, companyId);

                LfsAssetSewer lfsAssetSewer = new LfsAssetSewer(null);
                lfsAssetSewer.DeleteDirect(assetId, companyId);

                LfsAsset lfsAsset = new LfsAsset(null);
                lfsAsset.DeleteDirect(assetId, companyId);

                // delete in AM tables
                AssetSewerLateral assetSewerLateral = new AssetSewerLateral(null);
                assetSewerLateral.DeleteDirect(assetId, companyId);

                return true;
            }
            else
            {
                return false;
            }
        }


        
        /// <summary>
        /// Verify is a lateral has any link to other entity
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

            // Verify FLL-M1-Lateral
            LfsAssetSewerLateralGateway lfsAssetSewerLateralGateway = new LfsAssetSewerLateralGateway(null);
            if (lfsAssetSewerLateralGateway.InUseFLM1(assetId, companyId))
            {
                return true;
            }

            return false;
        }



    }
}