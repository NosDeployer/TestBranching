using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Assets.Assets;

namespace LiquiForce.LFSLive.BL.Assets.Assets
{
    /// <summary>
    /// Asset
    /// </summary>
    public class Asset : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Asset() : base("AM_ASSET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Asset(DataSet data) : base(data, "AM_ASSET")
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
        /// <param name="assetType">assetType</param>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public int InsertDirect(string assetType, Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, bool deleted, int companyId)
        {
            AssetGateway assetGateway = new AssetGateway(new DataSet());
            int assetId = assetGateway.Insert(assetType, countryId, provinceId, countyId, cityId, deleted, companyId);

            return assetId;
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        public bool DeleteDirect(int assetId, int companyId)
        {
            AssetGateway assetGateway = new AssetGateway(Data);
            assetGateway.Delete(assetId, companyId);

            return true;
        }



    }
}