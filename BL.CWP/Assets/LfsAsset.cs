using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.DA.Assets.Assets;

namespace LiquiForce.LFSLive.BL.CWP.Assets
{
    /// <summary>
    /// LfsAsset
    /// </summary>
    public class LfsAsset : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LfsAsset() : base("LFS_ASSET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LfsAsset(DataSet data) : base(data, "LFS_ASSET")
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
        /// <param name="assetId">assetId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int assetId, bool deleted, int companyId)
        {
            LfsAssetGateway lfsAssetGateway = new LfsAssetGateway(new DataSet());
            lfsAssetGateway.Insert(assetId, deleted, companyId);
        }


        
        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="originalAssetId">originalAssetId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        public void DeleteDirect(int originalAssetId,  int originalCompanyId)
        {
            LfsAssetGateway lfsAssetGateway = new LfsAssetGateway(Data);
            lfsAssetGateway.Delete(originalAssetId,  originalCompanyId);
        }



    }
}
