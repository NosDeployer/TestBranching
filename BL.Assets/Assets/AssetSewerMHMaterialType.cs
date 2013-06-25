using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.Assets.Assets;

namespace LiquiForce.LFSLive.BL.Assets.Assets
{
    /// <summary>
    /// AssetSewerMHMaterialType
    /// </summary>
    public class AssetSewerMHMaterialType : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AssetSewerMHMaterialType()
            : base("AM_ASSET_SEWER_MH_MATERIAL_TYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AssetSewerMHMaterialType(DataSet data)
            : base(data, "AM_ASSET_SEWER_MH_MATERIAL_TYPE")
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
        /// LoadByWorkId
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByWorkIdAssetId(int materialId, int companyId)
        {
            AssetSewerMHMaterialTypeGateway assetSewerMHMaterialTypeGateway = new AssetSewerMHMaterialTypeGateway(Data);
            assetSewerMHMaterialTypeGateway.LoadByMaterialId(materialId, companyId);
        }



    }
}

