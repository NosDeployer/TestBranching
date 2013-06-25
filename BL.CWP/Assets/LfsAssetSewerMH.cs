using System;
using System.Data;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Assets;

namespace LiquiForce.LFSLive.BL.CWP.Assets
{
    /// <summary>
    /// LfsAssetSewerMH
    /// </summary>
    public class LfsAssetSewerMH : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LfsAssetSewerMH() : base("LFS_ASSET_SEWER_MH")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LfsAssetSewerMH(DataSet data) : base(data, "LFS_ASSET_SEWER_MH")
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
        /// <param name="conditionRating">conditionRating</param>
        /// <returns></returns>
        public int InsertDirect(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, string mhid, string latitude, string longitude, string address, bool deleted, int companyId, string manholeShape, string location, int? materialID, string topDiameter, string topDepth, string topFloor, string topCeiling, string topBenching, string downDiameter, string downDepth, string downFloor, string downCeiling, string downBenching, string rectangle1LongSide, string rectangle1ShortSide, string rectangle2LongSide, string rectangle2ShortSide, string topSurfaceArea, string downSurfaceArea, int? manholeRugs, string totalDepth, string totalSurfaceArea, int? conditionRating)
        {
            // insert in AM tables (only if not exists)
            AssetSewerMH assetSewerMh = new AssetSewerMH(null);
            int mh_assetId = assetSewerMh.InsertDirect(countryId, provinceId, countyId, cityId, mhid, latitude, longitude, address, deleted, companyId, manholeShape, location, materialID, topDiameter, topDepth, topFloor, topCeiling, topBenching, downDiameter, downDepth, downFloor, downCeiling, downBenching, rectangle1LongSide, rectangle1ShortSide, rectangle2LongSide, rectangle2ShortSide, topSurfaceArea, downSurfaceArea, manholeRugs, totalDepth, totalSurfaceArea);

            // insert in LFS tables (only if not exists)
            LfsAssetSewerMHGateway lfsAssetSewerMhGateway = new LfsAssetSewerMHGateway();
            lfsAssetSewerMhGateway.LoadByAssetId(mh_assetId, companyId);

            if (lfsAssetSewerMhGateway.Table.Rows.Count == 0)
            {
                new LfsAsset(new DataSet()).InsertDirect(mh_assetId, deleted, companyId);
                new LfsAssetSewer(new DataSet()).InsertDirect(mh_assetId, deleted, companyId);
                new LfsAssetSewerMHGateway(new DataSet()).Insert(mh_assetId, deleted, companyId, conditionRating);
            }

            return mh_assetId;
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="conditionRating">conditionRating</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public void UpdateDirect(int originalAssetId, bool originalDeleted, int originalCompanyId, int? originalConditionRating, bool newDeleted, int newCompanyId, int? newConditionRating)
        {
            LfsAssetSewerMHGateway lfsAssetSewerMhGateway = new LfsAssetSewerMHGateway();
            lfsAssetSewerMhGateway.LoadByAssetId(originalAssetId, originalCompanyId);

            if (lfsAssetSewerMhGateway.Table.Rows.Count > 0)
            {
                new LfsAssetSewerMHGateway(new DataSet()).Update(originalAssetId, originalDeleted, originalCompanyId, originalConditionRating, originalAssetId, newDeleted, newCompanyId, newConditionRating);
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
            // verify use
            if (!InUse(assetId, companyId))
            {
                // delete in LFS tables
                LfsAssetSewerMHGateway lfsAssetSewerMHGateway = new LfsAssetSewerMHGateway(null);
                lfsAssetSewerMHGateway.Delete(assetId, companyId);

                LfsAssetSewer lfsAssetSewer = new LfsAssetSewer(null);
                lfsAssetSewer.DeleteDirect(assetId, companyId);

                LfsAsset lfsAsset = new LfsAsset(null);
                lfsAsset.DeleteDirect(assetId, companyId);

                // delete in AM tables
                AssetSewerMH assetSewerMh = new AssetSewerMH(null);
                assetSewerMh.DeleteDirect(assetId, companyId);

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
        /// <returns></returns>
        public bool InUse(int assetId, int companyId)
        {
            AssetSewerMH assetSewerMh = new AssetSewerMH(null);
            return assetSewerMh.InUse(assetId, companyId);
        }



    }
}