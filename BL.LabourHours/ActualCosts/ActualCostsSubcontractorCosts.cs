using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsSubcontractorCosts
    /// </summary>
    public class ActualCostsSubcontractorCosts : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsSubcontractorCosts()
            : base("LFS_LABOUR_HOURS_ACTUAL_COSTS_SUBCONTRACTOR_COSTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsSubcontractorCosts(DataSet data)
            : base(data, "LFS_LABOUR_HOURS_ACTUAL_COSTS_SUBCONTRACTOR_COSTS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ActualCostsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="subcontractorId">subcontractorId</param>        
        /// <param name="date">date</param>
        /// <param name="quantity">quantity</param>
        /// <param name="rateCad">rateCad</param>
        /// <param name="totalCad">totalCad</param>
        /// <param name="rateUsd">rateUsd</param>
        /// <param name="totalUsd">totalUsd</param>        
        /// <param name="comment">comment</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>        
        public void InsertDirect(int projectId, int refId, int subcontractorId, DateTime date, double quantity, decimal rateCad, decimal totalCad, decimal rateUsd, decimal totalUsd, string comment, bool deleted, int companyId)
        {
            ActualCostsSubcontractorCostsGateway actualCostsSubcontractorCostsGateway = new ActualCostsSubcontractorCostsGateway(null);
            actualCostsSubcontractorCostsGateway.Insert(projectId, refId, subcontractorId, date, quantity, rateCad, totalCad, rateUsd, totalUsd, comment, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalRefId">originalRefId</param>        
        /// <param name="originalSubcontractorId">originalSubcontractorId</param>
        /// <param name="originalDate">originalDate</param>
        /// <param name="originalQuantity">originalQuantity</param>
        /// <param name="originalRateCad">originalRateCad</param>
        /// <param name="originalTotalCad">originalTotalCad</param>        
        /// <param name="originalRateUsd">originalRateUsd</param>
        /// <param name="originalTotalUsd">originalTotalUsd</param>
        /// <param name="originalTotal">originalTotal</param>
        /// <param name="originalComment">originalComment</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>        

        /// <param name="newProjectId">newProjectId</param>        
        /// <param name="newRefId">newRefId</param>        
        /// <param name="newSubcontractorId">newSubcontractorId</param>
        /// <param name="newDate">newDate</param>
        /// <param name="newQuantity">newQuantity</param>
        /// <param name="newRateCad">newRateCad</param>
        /// <param name="newTotalCad">newTotalCad</param>
        /// <param name="newRateUsd">newRateUsd</param>
        /// <param name="newTotalUsd">newTotalUsd</param>
        /// <param name="newRate">newRate</param>
        /// <param name="newTotal">newTotal</param>
        /// <param name="newComment">newComment</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>    
        public void UpdateDirect(int originalProjectId, int originalRefId, int originalSubcontractorId, DateTime originalDate, double originalQuantity, decimal originalRateCad, decimal originalTotalCad, decimal originalRateUsd, decimal originalTotalUsd, string originalComment, bool originalDeleted, int originalCompanyId, int newProjectId, int newRefId, int newSubcontractorId, DateTime newDate, double newQuantity, decimal newRateCad, decimal newTotalCad, decimal newRateUsd, decimal newTotalUsd, string newComment, bool newDeleted, int newCompanyId)
        {
            ActualCostsSubcontractorCostsGateway actualCostsSubcontractorCostsGateway = new ActualCostsSubcontractorCostsGateway(null);
            actualCostsSubcontractorCostsGateway.Update(originalProjectId, originalRefId, originalSubcontractorId, originalDate, originalQuantity, originalRateCad, originalTotalCad, originalRateUsd, originalTotalUsd, originalComment, originalDeleted, originalCompanyId, newProjectId, newRefId, newSubcontractorId, newDate, newQuantity, newRateCad, newTotalCad, newRateUsd, newTotalUsd, newComment, newDeleted, newCompanyId);
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int projectId, int refId, int companyId)
        {
            ActualCostsSubcontractorCostsGateway actualCostsSubcontractorCostsGateway = new ActualCostsSubcontractorCostsGateway(null);
            actualCostsSubcontractorCostsGateway.Delete(projectId, refId, companyId);
        }

    }
}
