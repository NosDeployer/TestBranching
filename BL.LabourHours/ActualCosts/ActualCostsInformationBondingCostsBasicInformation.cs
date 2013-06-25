using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;

namespace LiquiForce.LFSLive.BL.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsInformationBondingCostsBasicInformation
    /// </summary>
    public class ActualCostsInformationBondingCostsBasicInformation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsInformationBondingCostsBasicInformation()
            : base("BondingCostsBasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsInformationBondingCostsBasicInformation(DataSet data)
            : base(data, "BondingCostsBasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ActualCostsInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByProjectIdRefId
        /// </summary>
        /// <param name="projectId">projectId</param>    
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByProjectIdRefId(int projectId, int refId, int companyId)
        {
            ActualCostsInformationBondingCostsBasicInformationGateway actualCostsInformationBondingCostsBasicInformationGateway = new ActualCostsInformationBondingCostsBasicInformationGateway(Data);
            actualCostsInformationBondingCostsBasicInformationGateway.LoadByProjectIdRefId(projectId, refId, companyId);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="date">date</param>        
        /// <param name="rateCad">rateCad</param>
        /// <param name="rateUsd">rateUsd</param>             
        /// <param name="comment">comment</param>
        public void Update(int projectId, int refId, DateTime date, decimal rateCad, decimal rateUsd, string comment)
        {
            ActualCostsInformationTDS.BondingCostsBasicInformationRow row = GetRow(projectId, refId);
 
            // General Data                      
            row.Date = date;            
            row.RateCad = rateCad;            
            row.RateUsd = rateUsd;            
            if (comment.Trim() != "") row.Comment = comment; else row.SetCommentNull();           
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>       
        public void Delete(int projectId, int refId)
        {
            ActualCostsInformationTDS.BondingCostsBasicInformationRow row = GetRow(projectId, refId);

            // General Data                      
            row.Deleted = true;            
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            ActualCostsInformationTDS hotelCostsInformationChanges = (ActualCostsInformationTDS)Data.GetChanges();

            if (hotelCostsInformationChanges.BondingCostsBasicInformation.Rows.Count > 0)
            {
                ActualCostsInformationBondingCostsBasicInformationGateway actualCostsInformationBondingCostsBasicInformationGateway = new ActualCostsInformationBondingCostsBasicInformationGateway(hotelCostsInformationChanges);

                // Update employee
                foreach (ActualCostsInformationTDS.BondingCostsBasicInformationRow row in (ActualCostsInformationTDS.BondingCostsBasicInformationDataTable)hotelCostsInformationChanges.BondingCostsBasicInformation)
                {
                    // Insert new hours 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        string comment = ""; if (!row.IsCommentNull()) comment = row.Comment;
                        ActualCostsBondingCompaniesCosts actualCostsBondingCompaniesCosts = new ActualCostsBondingCompaniesCosts(null);
                        actualCostsBondingCompaniesCosts.InsertDirect(row.ProjectID, row.RefID, row.BondingCompanyID, row.Date, row.RateCad, row.RateUsd, comment, row.Deleted, row.COMPANY_ID);
                    }

                    // Update hours
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int projectId = row.ProjectID;
                        int refId = row.RefID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // Original values
                        int originalBondingId = actualCostsInformationBondingCostsBasicInformationGateway.GetBondingIDOriginal(projectId, refId);
                        DateTime originalDate = actualCostsInformationBondingCostsBasicInformationGateway.GetDateOriginal(projectId, refId);                        
                        decimal originalRateCad = actualCostsInformationBondingCostsBasicInformationGateway.GetRateCadOriginal(projectId, refId);                        
                        decimal originalRateUsd = actualCostsInformationBondingCostsBasicInformationGateway.GetRateUsdOriginal(projectId, refId);                        
                        string originalComment = actualCostsInformationBondingCostsBasicInformationGateway.GetCommentOriginal(projectId, refId);

                        // New values
                        int newBondingId = actualCostsInformationBondingCostsBasicInformationGateway.GetBondingID(projectId, refId);
                        DateTime newDate = actualCostsInformationBondingCostsBasicInformationGateway.GetDate(projectId, refId);                        
                        decimal newRateCad = actualCostsInformationBondingCostsBasicInformationGateway.GetRateCad(projectId, refId);                        
                        decimal newRateUsd = actualCostsInformationBondingCostsBasicInformationGateway.GetRateUsd(projectId, refId);                        
                        string newComment = actualCostsInformationBondingCostsBasicInformationGateway.GetComment(projectId, refId);

                        ActualCostsBondingCompaniesCosts actualCostsBondingCompaniesCosts = new ActualCostsBondingCompaniesCosts(null);
                        actualCostsBondingCompaniesCosts.UpdateDirect(projectId, refId, originalBondingId, originalDate, originalRateCad, originalRateUsd, originalComment, originalDeleted, originalCompanyId, projectId, refId, newBondingId, newDate, newRateCad, newRateUsd, newComment, originalDeleted, originalCompanyId);
                    }

                    // Delete hours 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        ActualCostsBondingCompaniesCosts actualCostsBondingCompaniesCosts = new ActualCostsBondingCompaniesCosts(null);
                        actualCostsBondingCompaniesCosts.DeleteDirect(row.ProjectID, row.RefID, row.COMPANY_ID);
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //   

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private ActualCostsInformationTDS.BondingCostsBasicInformationRow GetRow(int projectId, int refId)
        {
            ActualCostsInformationTDS.BondingCostsBasicInformationRow row = ((ActualCostsInformationTDS.BondingCostsBasicInformationDataTable)Table).FindByProjectIDRefID(projectId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsInformationBondingCostsBasicInformation.GetRow");
            }

            return row;
        }



    }
}