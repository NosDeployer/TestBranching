using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Assets;

namespace LiquiForce.LFSLive.BL.CWP.Assets
{
    /// <summary>
    /// LfsAssetSewer
    /// </summary>
    public class LfsAssetSewer : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LfsAssetSewer() : base("LFS_ASSET_SEWER")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LfsAssetSewer(DataSet data) : base(data, "LFS_ASSET_SEWER")
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
            LfsAssetSewerGateway lfsAssetSewerGateway = new LfsAssetSewerGateway(new DataSet());
            lfsAssetSewerGateway.Insert(assetId, deleted, companyId);
        }


        
        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="originalAssetId">originalAssetId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        public void DeleteDirect(int originalAssetId,  int originalCompanyId)
        {
            LfsAssetSewerGateway lfsAssetSewerGateway = new LfsAssetSewerGateway(Data);
            lfsAssetSewerGateway.Delete(originalAssetId,  originalCompanyId);
        }



    }
}
