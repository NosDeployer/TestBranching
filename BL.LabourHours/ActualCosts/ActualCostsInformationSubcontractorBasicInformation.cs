using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;

namespace LiquiForce.LFSLive.BL.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsInformationSubcontractorBasicInformation
    /// </summary>
    public class ActualCostsInformationSubcontractorBasicInformation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsInformationSubcontractorBasicInformation()
            : base("SubcontractorBasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsInformationSubcontractorBasicInformation(DataSet data)
            : base(data, "SubcontractorBasicInformation")
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
            ActualCostsInformationSubcontractorBasicInformationGateway actualCostsInformationSubcontractorBasicInformationGateway = new ActualCostsInformationSubcontractorBasicInformationGateway(Data);
            actualCostsInformationSubcontractorBasicInformationGateway.LoadByProjectIdRefId(projectId, refId, companyId);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="date">date</param>
        /// <param name="quantity">quantity</param>
        /// <param name="rateCad">rateCad</param>
        /// <param name="totalCad">totalCad</param>
        /// <param name="rateUsd">rateUsd</param>
        /// <param name="totalUsd">totalUsd</param>        
        /// <param name="comment">comment</param>
        public void Update(int projectId, int refId, DateTime date, double quantity, decimal rateCad, decimal totalCad, decimal rateUsd, decimal totalUsd, string comment)
        {
            ActualCostsInformationTDS.SubcontractorBasicInformationRow row = GetRow(projectId, refId);
 
            // General Data                      
            row.Date = date;
            row.Quantity = quantity;
            row.RateCad = rateCad;
            row.TotalCad = totalCad;
            row.RateUsd = rateUsd;
            row.TotalUsd = totalUsd;
            if (comment.Trim() != "") row.Comment = comment; else row.SetCommentNull();           
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>       
        public void Delete(int projectId, int refId)
        {
            ActualCostsInformationTDS.SubcontractorBasicInformationRow row = GetRow(projectId, refId);

            // General Data                      
            row.Deleted = true;            
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            ActualCostsInformationTDS subcontractorHoursInformationChanges = (ActualCostsInformationTDS)Data.GetChanges();

            if (subcontractorHoursInformationChanges.SubcontractorBasicInformation.Rows.Count > 0)
            {
                ActualCostsInformationSubcontractorBasicInformationGateway actualCostsInformationSubcontractorBasicInformationGateway = new ActualCostsInformationSubcontractorBasicInformationGateway(subcontractorHoursInformationChanges);

                // Update employee
                foreach (ActualCostsInformationTDS.SubcontractorBasicInformationRow row in (ActualCostsInformationTDS.SubcontractorBasicInformationDataTable)subcontractorHoursInformationChanges.SubcontractorBasicInformation)
                {
                    // Insert new hours 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        string comment = ""; if (!row.IsCommentNull()) comment = row.Comment;
                        ActualCostsSubcontractorCosts actualCostsSubcontractorCosts = new ActualCostsSubcontractorCosts(null);
                        actualCostsSubcontractorCosts.InsertDirect(row.ProjectID, row.RefID, row.SubcontractorID, row.Date, row.Quantity, row.RateCad, row.TotalCad, row.RateUsd, row.TotalUsd, comment, row.Deleted, row.COMPANY_ID);
                    }

                    // Update hours
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int projectId = row.ProjectID;
                        int refId = row.RefID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // Original values
                        int originalSubcontractorId = actualCostsInformationSubcontractorBasicInformationGateway.GetSubcontractorIDOriginal(projectId, refId);
                        DateTime originalDate = actualCostsInformationSubcontractorBasicInformationGateway.GetDateOriginal(projectId, refId);
                        double originalQuantity = actualCostsInformationSubcontractorBasicInformationGateway.GetQuantityOriginal(projectId, refId);
                        decimal originalRateCad = actualCostsInformationSubcontractorBasicInformationGateway.GetRateCadOriginal(projectId, refId);
                        decimal originalTotalCad = actualCostsInformationSubcontractorBasicInformationGateway.GetTotalCadOriginal(projectId, refId);
                        decimal originalRateUsd = actualCostsInformationSubcontractorBasicInformationGateway.GetRateUsdOriginal(projectId, refId);
                        decimal originalTotalUsd = actualCostsInformationSubcontractorBasicInformationGateway.GetTotalUsdOriginal(projectId, refId);
                        string originalComment = actualCostsInformationSubcontractorBasicInformationGateway.GetCommentOriginal(projectId, refId);

                        // New values
                        int newSubcontractorId = actualCostsInformationSubcontractorBasicInformationGateway.GetSubcontractorID(projectId, refId);
                        DateTime newDate = actualCostsInformationSubcontractorBasicInformationGateway.GetDate(projectId, refId);
                        double newQuantity = actualCostsInformationSubcontractorBasicInformationGateway.GetQuantity(projectId, refId);
                        decimal newRateCad = actualCostsInformationSubcontractorBasicInformationGateway.GetRateCad(projectId, refId);
                        decimal newTotalCad = actualCostsInformationSubcontractorBasicInformationGateway.GetTotalCad(projectId, refId);
                        decimal newRateUsd = actualCostsInformationSubcontractorBasicInformationGateway.GetRateUsd(projectId, refId);
                        decimal newTotalUsd = actualCostsInformationSubcontractorBasicInformationGateway.GetTotalUsd(projectId, refId);
                        string newComment = actualCostsInformationSubcontractorBasicInformationGateway.GetComment(projectId, refId);

                        ActualCostsSubcontractorCosts actualCostsSubcontractorCosts = new ActualCostsSubcontractorCosts(null);
                        actualCostsSubcontractorCosts.UpdateDirect(projectId, refId, originalSubcontractorId, originalDate, originalQuantity, originalRateCad, originalTotalCad, originalRateUsd, originalTotalUsd, originalComment, originalDeleted, originalCompanyId, projectId, refId, newSubcontractorId, newDate, newQuantity, newRateCad, newTotalCad, newRateUsd, newTotalUsd, newComment, originalDeleted, originalCompanyId);
                    }

                    // Delete hours 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        ActualCostsSubcontractorCosts actualCostsSubcontractorCosts = new ActualCostsSubcontractorCosts(null);
                        actualCostsSubcontractorCosts.DeleteDirect(row.ProjectID, row.RefID, row.COMPANY_ID);
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
        private ActualCostsInformationTDS.SubcontractorBasicInformationRow GetRow(int projectId, int refId)
        {
            ActualCostsInformationTDS.SubcontractorBasicInformationRow row = ((ActualCostsInformationTDS.SubcontractorBasicInformationDataTable)Table).FindByProjectIDRefID(projectId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsInformationSubcontractorBasicInformation.GetRow");
            }

            return row;
        }



    }
}