using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Assets.Assets;

namespace LiquiForce.LFSLive.BL.Assets.Assets
{
    /// <summary>
    /// MaterialInformation
    /// </summary>
    public class MaterialInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialInformation()
            : base("MaterialInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialInformation(DataSet data)
            : base(data, "MaterialInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MaterialInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new material
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="materialType">materialType</param>
        /// <param name="date_">date_</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(int assetId, string materialType, DateTime date_, bool deleted, int companyId, bool inDatabase)
        {
            MaterialInformationTDS.MaterialInformationRow row = ((MaterialInformationTDS.MaterialInformationDataTable)Table).NewMaterialInformationRow();

            row.AssetID = assetId;
            row.RefID = GetNewRefId();
            row.MaterialType = materialType;
            row.Date_ = date_;
            row.COMPANY_ID = companyId;
            row.Deleted = deleted;
            row.InDatabase = inDatabase;

            ((MaterialInformationTDS.MaterialInformationDataTable)Table).AddMaterialInformationRow(row);
        }



        /// <summary>
        /// Update material
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="refId">refId</param>
        /// <param name="materialType">materialType</param>
        public void Update(int assetId, int refId, string materialType)
        {
            MaterialInformationTDS.MaterialInformationRow row = GetRow(assetId, refId);

            row.MaterialType = materialType;
        }



        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="refId">refId</param>
        public void Delete(int assetId, int refId)
        {
            MaterialInformationTDS.MaterialInformationRow row = GetRow(assetId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all materials to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            MaterialInformationTDS materialInformationChanges = (MaterialInformationTDS)Data.GetChanges();

            if (materialInformationChanges.MaterialInformation.Rows.Count > 0)
            {
                MaterialInformationGateway materialInformationGateway = new MaterialInformationGateway(materialInformationChanges);

                foreach (MaterialInformationTDS.MaterialInformationRow row in (MaterialInformationTDS.MaterialInformationDataTable)materialInformationChanges.MaterialInformation)
                {
                    // Insert new materials 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        AssetSewerMaterial assetSewerMaterial = new AssetSewerMaterial(null);
                        assetSewerMaterial.InsertDirect(row.AssetID, row.RefID, row.MaterialType, row.Date_, row.Deleted, row.COMPANY_ID);
                    }

                    // Update materials
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int assetId = row.AssetID;
                        int refId = row.RefID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // original values
                        string originalMaterialType = materialInformationGateway.GetMaterialTypeOriginal(assetId, refId);
                        DateTime originalDate_ = materialInformationGateway.GetDate_Original(assetId, refId);

                        // new values
                        string newMaterialType = materialInformationGateway.GetMaterialType(assetId, refId);

                        AssetSewerMaterial assetSewerMaterial = new AssetSewerMaterial(null);
                        assetSewerMaterial.UpdateDirect(assetId, refId, originalMaterialType, originalDate_, originalCompanyId, originalDeleted, assetId, refId, newMaterialType, originalDate_, originalCompanyId, originalDeleted);
                    }

                    // Deleted materials 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        AssetSewerMaterial assetSewerMaterial = new AssetSewerMaterial(null);
                        assetSewerMaterial.DeleteDirect(row.AssetID, row.RefID, row.COMPANY_ID);
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>New refID</returns>
        public int GetNewRefId()
        {
            int newRefId = 0;

            foreach (MaterialInformationTDS.MaterialInformationRow row in (MaterialInformationTDS.MaterialInformationDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }



        /// <summary>
        /// Get a single row. If not exists, raise an exception
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Row</returns>
        private MaterialInformationTDS.MaterialInformationRow GetRow(int assetId, int refId)
        {
            MaterialInformationTDS.MaterialInformationRow row = ((MaterialInformationTDS.MaterialInformationDataTable)Table).FindByAssetIDRefID(assetId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Assets.Assets.MaterialInformation.GetRow");
            }

            return row;
        }



    }
}