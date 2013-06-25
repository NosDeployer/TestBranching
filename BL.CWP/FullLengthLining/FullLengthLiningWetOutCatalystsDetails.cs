using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FullLengthLiningWetOutCatalystsDetails
    /// </summary>
    public class FullLengthLiningWetOutCatalystsDetails: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FullLengthLiningWetOutCatalystsDetails()
            : base("WetOutCatalystsDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FullLengthLiningWetOutCatalystsDetails(DataSet data)
            : base(data, "WetOutCatalystsDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FullLengthLiningTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAll
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void LoadAll(int workId, int companyId)
        {
            FullLengthLiningWetOutCatalystsDetailsGateway fullLengthLiningWetOutCatalystsDetailsGateway = new FullLengthLiningWetOutCatalystsDetailsGateway(Data);
            fullLengthLiningWetOutCatalystsDetailsGateway.LoadAllByWorkId(workId, companyId);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new catalyst
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="catalystId">catalystId</param>
        /// <param name="name">name</param>
        /// <param name="percentageByWeight">percentageByWeight</param>
        /// <param name="lbsForMixQuantity">lbsForMixQuantity</param>
        /// <param name="lbsForDrum">lbsForDrum</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(int workId, int catalystId, string name, decimal percentageByWeight,  decimal lbsForMixQuantity, string lbsForDrum, bool deleted, int companyId, bool inDatabase)
        {
            FullLengthLiningTDS.WetOutCatalystsDetailsRow row = ((FullLengthLiningTDS.WetOutCatalystsDetailsDataTable)Table).NewWetOutCatalystsDetailsRow();

            row.WorkID = workId;
            row.RefID = GetNewRefId();
            row.CatalystID = catalystId;
            row.Name = name.Trim();
            row.PercentageByWeight = percentageByWeight;
            row.LbsForMixQuantity = lbsForMixQuantity;
            row.LbsForDrum = lbsForDrum;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;

            ((FullLengthLiningTDS.WetOutCatalystsDetailsDataTable)Table).AddWetOutCatalystsDetailsRow(row);
        }



        /// <summary>
        /// Update a catalyst
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>        
        /// <param name="percentageByWeight">percentageByWeight</param>
        /// <param name="lbsForMixQuantity">lbsForMixQuantity</param>
        /// <param name="lbsForDrum">lbsForDrum</param>
        /// <param name="companyId">companyId</param>
        public void Update(int workId, int refId, decimal percentageByWeight, decimal lbsForMixQuantity, string lbsForDrum, int companyId)
        {
            FullLengthLiningTDS.WetOutCatalystsDetailsRow row = GetRow(workId, refId);
                        
            row.PercentageByWeight = percentageByWeight;
            row.LbsForMixQuantity = lbsForMixQuantity;
            row.LbsForDrum = lbsForDrum;
        }
               

        
        /// <summary>
        /// Delete one catalyst
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int workId, int refId, int companyId)
        {
            FullLengthLiningTDS.WetOutCatalystsDetailsRow row = GetRow(workId, refId);
            row.Deleted = true;            
        }



        /// <summary>
        /// Save all catalysts to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>   
        /// <param name="runDetails">runDetails</param>
        /// <param name="projectId">projectId</param>
        public void Save(int companyId, string runDetails, int projectId)
        {            
            string[] runDetailsList = runDetails.Split('>');           

            FullLengthLiningTDS fullLengthLiningWetOutCatalystsDetailsChanges = (FullLengthLiningTDS)Data.GetChanges();

            if (fullLengthLiningWetOutCatalystsDetailsChanges.WetOutCatalystsDetails.Rows.Count > 0)
            {
                FullLengthLiningWetOutCatalystsDetailsGateway fullLengthLiningWetOutCatalystsDetailsGateway = new FullLengthLiningWetOutCatalystsDetailsGateway(fullLengthLiningWetOutCatalystsDetailsChanges);

                foreach (FullLengthLiningTDS.WetOutCatalystsDetailsRow row in (FullLengthLiningTDS.WetOutCatalystsDetailsDataTable)fullLengthLiningWetOutCatalystsDetailsChanges.WetOutCatalystsDetails)
                {
                    // Insert new catalysts 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        for (int i = 0; i < runDetailsList.Length; i++)
                        {
                            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
                            string sectionId = runDetailsList[i].ToString();
                            assetSewerSectionGateway.LoadBySectionId(sectionId, companyId);
                            int assetId = assetSewerSectionGateway.GetAssetID(sectionId);

                            WorkGateway workGateway = new WorkGateway();
                            int newWorkId = 0;

                            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Full Length Lining", companyId);
                            if (workGateway.Table.Rows.Count > 0)
                            {
                                newWorkId = workGateway.GetWorkId(assetId, "Full Length Lining", projectId);
                            }

                            if (newWorkId > 0)
                            {
                                WorkFullLengthLiningWetOutCatalysts workFullLengthLiningWetOutCatalysts = new WorkFullLengthLiningWetOutCatalysts(null);
                                workFullLengthLiningWetOutCatalysts.InsertDirect(newWorkId, row.RefID, row.CatalystID, row.PercentageByWeight, row.LbsForMixQuantity, row.LbsForDrum, row.Deleted, row.COMPANY_ID);
                            }
                        }
                    }

                    // Update catalysts
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int workId = row.WorkID;
                        int refId = row.RefID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;
                        int originalCatalystId = row.CatalystID;
                        
                        // original values
                        decimal originalPercentageByWeight = fullLengthLiningWetOutCatalystsDetailsGateway.GetPercentageByWeightOriginal(workId, refId);
                        decimal originalLbsForMixQuantity = fullLengthLiningWetOutCatalystsDetailsGateway.GetLbsForMixQuantityOriginal(workId, refId);
                        string originalLbsForDrum = fullLengthLiningWetOutCatalystsDetailsGateway.GetLbsForDrumOriginal(workId, refId);

                        // new values
                        decimal newPercentageByWeight = fullLengthLiningWetOutCatalystsDetailsGateway.GetPercentageByWeight(workId, refId);
                        decimal newLbsForMixQuantity = fullLengthLiningWetOutCatalystsDetailsGateway.GetLbsForMixQuantity(workId, refId);
                        string newLbsForDrum = fullLengthLiningWetOutCatalystsDetailsGateway.GetLbsForDrum(workId, refId);

                        for (int i = 0; i < runDetailsList.Length; i++)
                        {
                            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
                            string sectionId = runDetailsList[i].ToString();
                            assetSewerSectionGateway.LoadBySectionId(sectionId, companyId);
                            int assetId = assetSewerSectionGateway.GetAssetID(sectionId);

                            WorkGateway workGateway = new WorkGateway();
                            int newWorkId = 0;

                            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Full Length Lining", companyId);
                            if (workGateway.Table.Rows.Count > 0)
                            {
                                newWorkId = workGateway.GetWorkId(assetId, "Full Length Lining", projectId);
                            }

                            if (newWorkId > 0)
                            {
                                FullLengthLiningWetOutCatalystsDetailsGateway fullLengthLiningWetOutCatalystsDetailsGatewayForReview = new FullLengthLiningWetOutCatalystsDetailsGateway();
                                fullLengthLiningWetOutCatalystsDetailsGatewayForReview.LoadByWorkId(newWorkId, companyId);

                                if (fullLengthLiningWetOutCatalystsDetailsGatewayForReview.Table.Rows.Count > 0)
                                {
                                    WorkFullLengthLiningWetOutCatalysts workFullLengthLiningWetOutCatalysts = new WorkFullLengthLiningWetOutCatalysts(null);
                                    workFullLengthLiningWetOutCatalysts.UpdateDirect(newWorkId, refId, originalCatalystId, originalPercentageByWeight, originalLbsForMixQuantity, originalLbsForDrum, originalDeleted, originalCompanyId, workId, refId, originalCatalystId, newPercentageByWeight, newLbsForMixQuantity, newLbsForDrum, originalDeleted, originalCompanyId);
                                }
                                else
                                {
                                    WorkFullLengthLiningWetOutCatalysts workFullLengthLiningWetOutCatalysts = new WorkFullLengthLiningWetOutCatalysts(null);
                                    workFullLengthLiningWetOutCatalysts.InsertDirect(newWorkId, row.RefID, row.CatalystID, row.PercentageByWeight, row.LbsForMixQuantity, row.LbsForDrum, row.Deleted, row.COMPANY_ID);
                                }
                            }
                        }
                    }

                    // Deleted catalysts 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        for (int i = 0; i < runDetailsList.Length; i++)
                        {
                            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
                            string sectionId = runDetailsList[i].ToString();
                            assetSewerSectionGateway.LoadBySectionId(sectionId, companyId);
                            int assetId = assetSewerSectionGateway.GetAssetID(sectionId);

                            WorkGateway workGateway = new WorkGateway();
                            int newWorkId = 0;
                            
                            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Full Length Lining", companyId);
                            if (workGateway.Table.Rows.Count > 0)
                            {
                                newWorkId = workGateway.GetWorkId(assetId, "Full Length Lining", projectId);
                            }

                            if (newWorkId > 0)
                            {
                                WorkFullLengthLiningWetOutCatalysts workFullLengthLiningWetOutCatalysts = new WorkFullLengthLiningWetOutCatalysts(null);
                                workFullLengthLiningWetOutCatalysts.DeleteDirect(newWorkId, row.RefID, row.COMPANY_ID);
                            }
                        }
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
        /// <returns>New ID</returns>
        private int GetNewRefId()
        {
            int newRefId = 0;

            foreach (FullLengthLiningTDS.WetOutCatalystsDetailsRow row in (FullLengthLiningTDS.WetOutCatalystsDetailsDataTable)Table)
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
        /// Get a single catalyst. If not exists, raise an exception
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">RefID</param>
        /// <returns>FullLengthLiningTDS.WetOutCatalystsDetailsRow</returns>
        private FullLengthLiningTDS.WetOutCatalystsDetailsRow GetRow(int workId, int refId)
        {
            FullLengthLiningTDS.WetOutCatalystsDetailsRow row = ((FullLengthLiningTDS.WetOutCatalystsDetailsDataTable)Table).FindByWorkIDRefID(workId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.FullLengthLining.FullLengthLiningWetOutCatalystsDetails.GetRow");
            }

            return row;
        }
    }
}
