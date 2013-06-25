using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.Assets.Assets;

namespace LiquiForce.LFSLive.BL.Assets.Assets
{
    /// <summary>
    /// AssetSewer
    /// </summary>
    public class AssetSewer : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AssetSewer() : base("AM_ASSET_SEWER")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AssetSewer(DataSet data) : base(data, "AM_ASSET_SEWER")
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
        /// <param name="assetId">assetId</param>
        /// <param name="assetSewerType">assetSewerType</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int assetId, string assetSewerType, bool deleted, int companyId)
        {
            AssetSewerGateway assetSewerGateway = new AssetSewerGateway(new DataSet());
            assetSewerGateway.Insert(assetId, assetSewerType, deleted, companyId);
        }


        
        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        public bool DeleteDirect(int assetId, int companyId)
        {
            // delete materials
            AssetSewerMaterial assetSewerMaterial = new AssetSewerMaterial(null);
            assetSewerMaterial.DeleteAllDirect(assetId, companyId);

            // delete sewer
            AssetSewerGateway assetSewerGateway = new AssetSewerGateway(Data);
            assetSewerGateway.Delete(assetId, companyId);

            return true;
        }



    }
}
