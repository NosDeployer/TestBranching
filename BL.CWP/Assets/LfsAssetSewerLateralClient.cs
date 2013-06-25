using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Assets;

namespace LiquiForce.LFSLive.BL.CWP.Assets
{
    /// <summary>
    /// LfsAssetSewerLateralClient
    /// </summary>
    public class LfsAssetSewerLateralClient : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LfsAssetSewerLateralClient()
            : base("LFS_ASSET_SEWER_LATERAL_CLIENT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LfsAssetSewerLateralClient(DataSet data)
            : base(data, "LFS_ASSET_SEWER_LATERAL_CLIENT")
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
        /// /// <param name="clientId">clientId</param>
        /// <param name="clientLateralId">clientLateralId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int assetId, int clientId, string clientLateralId, bool deleted, int companyId)
        {
            LfsAssetSewerLateralClientGateway lfsAssetSewerLateralClientGateway = new LfsAssetSewerLateralClientGateway(null);
            lfsAssetSewerLateralClientGateway.Insert(assetId, clientId, clientLateralId, deleted, companyId);                  
        }


        
        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalAssetId"></param>
        /// <param name="originalClientId"></param>
        /// <param name="originalClientLateralId"></param>
        /// <param name="originalDeleted"></param>
        /// <param name="originalCompanyId"></param>
        /// <param name="newAssetId"></param>
        /// <param name="newClientId"></param>
        /// <param name="newClientLateralId"></param>
        /// <param name="newDeleted"></param>
        /// <param name="newCompanyId"></param>
        public void UpdateDirect(int originalAssetId, int originalClientId, string originalClientLateralId, bool originalDeleted, int originalCompanyId, int newAssetId, int newClientId, string newClientLateralId, bool newDeleted, int newCompanyId)
        {
            LfsAssetSewerLateralClientGateway lfsAssetSewerLateralClientGateway = new LfsAssetSewerLateralClientGateway(null);
            lfsAssetSewerLateralClientGateway.Update(originalAssetId, originalClientId, originalClientLateralId, originalDeleted, originalCompanyId, newAssetId, newClientId, newClientLateralId, newDeleted, newCompanyId);            
        }


                
        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int assetId, int clientId, int companyId)
        {
            LfsAssetSewerLateralClientGateway lfsAssetSewerLateralClientGateway = new LfsAssetSewerLateralClientGateway(null);
            lfsAssetSewerLateralClientGateway.Delete(assetId, clientId, companyId);
        }


        
        /// <summary>
        /// Verify is a lateral has client lateral id
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public bool InUse(int assetId, int clientId, int companyId)
        {
            LfsAssetSewerLateralClientGateway lfsAssetSewerLateralClientGateway = new LfsAssetSewerLateralClientGateway(null);
            if (lfsAssetSewerLateralClientGateway.ExistClientLateralId(assetId, clientId, companyId))
            {
                return true;
            }

            return false;
        }



    }
}