using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.Assets.Assets;

namespace LiquiForce.LFSLive.BL.Assets.Assets
{
    /// <summary>
    /// AssetSewerMaterial
    /// </summary>
    public class AssetSewerMaterial : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AssetSewerMaterial()
            : base("AM_ASSET_SEWER_MATERIAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AssetSewerMaterial(DataSet data)
            : base(data, "AM_ASSET_SEWER_MATERIAL")
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
        /// Insert Direct all materials of an asset
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="refId">refId</param>
        /// <param name="materialType">materialType</param>
        /// <param name="date_">date_</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public bool InsertDirect(int assetId, int refId, string materialType, DateTime date_, bool deleted, int companyId)
        {
            AssetSewerMaterialGateway assetSewerMaterialGateway = new AssetSewerMaterialGateway(null);
            assetSewerMaterialGateway.Insert(assetId, refId, materialType, date_, deleted, companyId);

            return true;
        }



        /// <summary>
        /// Update material (direct to DB)
        /// </summary>
        /// <param name="originalAssetId">originalAssetId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalMaterialType">originalMaterialType</param>
        /// <param name="originalDate">originalDate</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDeleted">originalDeleted</param>        
        /// 
        /// <param name="newAssetId">newAssetId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newMaterialType">newMaterialType</param>
        /// <param name="newDate">newDate</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDeleted">newDeleted</param>        
        public void UpdateDirect(int originalAssetId, int originalRefId, string originalMaterialType, DateTime originalDate, int originalCompanyId, bool originalDeleted, int newAssetId, int newRefId, string newMaterialType, DateTime newDate, int newCompanyId, bool newDeleted)
        {
            AssetSewerMaterialGateway assetSewerMaterialGateway = new AssetSewerMaterialGateway(null);
            assetSewerMaterialGateway.Update(originalAssetId, originalRefId, originalMaterialType, originalDate, originalCompanyId, originalDeleted, newAssetId, newRefId, newMaterialType, newDate, newCompanyId, newDeleted);
        }



        /// <summary>
        /// Delete Direct all materials of an asset
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public bool DeleteDirect(int assetId, int refId, int companyId)
        {
            AssetSewerMaterialGateway assetSewerMaterialGateway = new AssetSewerMaterialGateway(null);
            assetSewerMaterialGateway.Delete(assetId, refId, companyId);

            return true;
        }



        /// <summary>
        /// Delete Direct all materials of an asset
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public bool DeleteAllDirect(int assetId, int companyId)
        {
            AssetSewerMaterialGateway assetSewerMaterialGateway = new AssetSewerMaterialGateway(null);
            assetSewerMaterialGateway.DeleteAll(assetId, companyId);

            return true;
        }










    }
}

