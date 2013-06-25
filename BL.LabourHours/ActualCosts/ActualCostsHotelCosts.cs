using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsHotelCosts
    /// </summary>
    public class ActualCostsHotelCosts : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsHotelCosts()
            : base("LFS_LABOUR_HOURS_ACTUAL_COSTS_HOTEL_COSTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsHotelCosts(DataSet data)
            : base(data, "LFS_LABOUR_HOURS_ACTUAL_COSTS_HOTEL_COSTS")
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
        /// <param name="hotelId">hotelId</param>        
        /// <param name="date">date</param>        
        /// <param name="rateCad">rateCad</param>        
        /// <param name="rateUsd">rateUsd</param>        
        /// <param name="comment">comment</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>        
        public void InsertDirect(int projectId, int refId, int hotelId, DateTime date, decimal rateCad, decimal rateUsd, string comment, bool deleted, int companyId)
        {
            ActualCostsHotelCostsGateway actualCostsSubcontractorCostsGateway = new ActualCostsHotelCostsGateway(null);
            actualCostsSubcontractorCostsGateway.Insert(projectId, refId, hotelId, date, rateCad, rateUsd, comment, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalRefId">originalRefId</param>        
        /// <param name="originalHotelId">originalHotelId</param>
        /// <param name="originalDate">originalDate</param>                
        /// <param name="originalRateCad">originalRateCad</param>
        /// <param name="originalRateUsd">originalRateUsd</param>
        /// <param name="originalComment">originalComment</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>        

        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newRefId">newRefId</param>              
        /// <param name="newHotelId">newHotelId</param>
        /// <param name="newDate">newDate</param>
        /// <param name="newRateCad">newRateCad</param>
        /// <param name="newRateUsd">newRateUsd</param>        
        /// <param name="newTotal">newTotal</param>
        /// <param name="newComment">newComment</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>    
        public void UpdateDirect(int originalProjectId, int originalRefId, int originalHotelId, DateTime originalDate, decimal originalRateCad, decimal originalRateUsd,  string originalComment, bool originalDeleted, int originalCompanyId, int newProjectId, int newRefId, int newHotelId, DateTime newDate, decimal newRateCad,  decimal newRateUsd, string newComment, bool newDeleted, int newCompanyId)
        {
            ActualCostsHotelCostsGateway actualCostsSubcontractorCostsGateway = new ActualCostsHotelCostsGateway(null);
            actualCostsSubcontractorCostsGateway.Update(originalProjectId, originalRefId, originalHotelId, originalDate, originalRateCad, originalRateUsd, originalComment, originalDeleted, originalCompanyId, newProjectId, newRefId, newHotelId, newDate, newRateCad, newRateUsd, newComment, newDeleted, newCompanyId);
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int projectId, int refId, int companyId)
        {
            ActualCostsHotelCostsGateway actualCostsSubcontractorCostsGateway = new ActualCostsHotelCostsGateway(null);
            actualCostsSubcontractorCostsGateway.Delete(projectId, refId, companyId);
        }

    }
}
