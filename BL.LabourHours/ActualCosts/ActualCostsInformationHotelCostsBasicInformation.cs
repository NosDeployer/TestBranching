using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;

namespace LiquiForce.LFSLive.BL.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsInformationHotelCostsBasicInformation
    /// </summary>
    public class ActualCostsInformationHotelCostsBasicInformation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsInformationHotelCostsBasicInformation()
            : base("HotelCostsBasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsInformationHotelCostsBasicInformation(DataSet data)
            : base(data, "HotelCostsBasicInformation")
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
            ActualCostsInformationHotelCostsBasicInformationGateway actualCostsInformationHotelCostsBasicInformationGateway = new ActualCostsInformationHotelCostsBasicInformationGateway(Data);
            actualCostsInformationHotelCostsBasicInformationGateway.LoadByProjectIdRefId(projectId, refId, companyId);
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
            ActualCostsInformationTDS.HotelCostsBasicInformationRow row = GetRow(projectId, refId);
 
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
            ActualCostsInformationTDS.HotelCostsBasicInformationRow row = GetRow(projectId, refId);

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

            if (hotelCostsInformationChanges.HotelCostsBasicInformation.Rows.Count > 0)
            {
                ActualCostsInformationHotelCostsBasicInformationGateway actualCostsInformationHotelCostsBasicInformationGateway = new ActualCostsInformationHotelCostsBasicInformationGateway(hotelCostsInformationChanges);

                // Update employee
                foreach (ActualCostsInformationTDS.HotelCostsBasicInformationRow row in (ActualCostsInformationTDS.HotelCostsBasicInformationDataTable)hotelCostsInformationChanges.HotelCostsBasicInformation)
                {
                    // Insert new hours 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        string comment = ""; if (!row.IsCommentNull()) comment = row.Comment;
                        ActualCostsHotelCosts actualCostsHotelCosts = new ActualCostsHotelCosts(null);
                        actualCostsHotelCosts.InsertDirect(row.ProjectID, row.RefID, row.HotelID, row.Date, row.RateCad, row.RateUsd, comment, row.Deleted, row.COMPANY_ID);
                    }

                    // Update hours
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int projectId = row.ProjectID;
                        int refId = row.RefID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // Original values
                        int originalHotelId = actualCostsInformationHotelCostsBasicInformationGateway.GetHotelIDOriginal(projectId, refId);
                        DateTime originalDate = actualCostsInformationHotelCostsBasicInformationGateway.GetDateOriginal(projectId, refId);                        
                        decimal originalRateCad = actualCostsInformationHotelCostsBasicInformationGateway.GetRateCadOriginal(projectId, refId);                        
                        decimal originalRateUsd = actualCostsInformationHotelCostsBasicInformationGateway.GetRateUsdOriginal(projectId, refId);                        
                        string originalComment = actualCostsInformationHotelCostsBasicInformationGateway.GetCommentOriginal(projectId, refId);

                        // New values
                        int newHotelId = actualCostsInformationHotelCostsBasicInformationGateway.GetHotelID(projectId, refId);
                        DateTime newDate = actualCostsInformationHotelCostsBasicInformationGateway.GetDate(projectId, refId);                        
                        decimal newRateCad = actualCostsInformationHotelCostsBasicInformationGateway.GetRateCad(projectId, refId);                        
                        decimal newRateUsd = actualCostsInformationHotelCostsBasicInformationGateway.GetRateUsd(projectId, refId);                        
                        string newComment = actualCostsInformationHotelCostsBasicInformationGateway.GetComment(projectId, refId);

                        ActualCostsHotelCosts actualCostsHotelCosts = new ActualCostsHotelCosts(null);
                        actualCostsHotelCosts.UpdateDirect(projectId, refId, originalHotelId, originalDate, originalRateCad, originalRateUsd, originalComment, originalDeleted, originalCompanyId, projectId, refId, newHotelId, newDate, newRateCad, newRateUsd, newComment, originalDeleted, originalCompanyId);
                    }

                    // Delete hours 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        ActualCostsHotelCosts actualCostsHotelCosts = new ActualCostsHotelCosts(null);
                        actualCostsHotelCosts.DeleteDirect(row.ProjectID, row.RefID, row.COMPANY_ID);
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
        private ActualCostsInformationTDS.HotelCostsBasicInformationRow GetRow(int projectId, int refId)
        {
            ActualCostsInformationTDS.HotelCostsBasicInformationRow row = ((ActualCostsInformationTDS.HotelCostsBasicInformationDataTable)Table).FindByProjectIDRefID(projectId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsInformationHotelCostsBasicInformation.GetRow");
            }

            return row;
        }



    }
}