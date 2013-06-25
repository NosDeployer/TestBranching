using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;

namespace LiquiForce.LFSLive.BL.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsInformationOtherCostsBasicInformation
    /// </summary>
    public class ActualCostsInformationOtherCostsBasicInformation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsInformationOtherCostsBasicInformation()
            : base("OtherCostsBasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsInformationOtherCostsBasicInformation(DataSet data)
            : base(data, "OtherCostsBasicInformation")
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
            ActualCostsInformationOtherCostsBasicInformationGateway actualCostsInformationOtherCostsBasicInformationGateway = new ActualCostsInformationOtherCostsBasicInformationGateway(Data);
            actualCostsInformationOtherCostsBasicInformationGateway.LoadByProjectIdRefId(projectId, refId, companyId);
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
            ActualCostsInformationTDS.OtherCostsBasicInformationRow row = GetRow(projectId, refId);
 
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
            ActualCostsInformationTDS.OtherCostsBasicInformationRow row = GetRow(projectId, refId);

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

            if (hotelCostsInformationChanges.OtherCostsBasicInformation.Rows.Count > 0)
            {
                ActualCostsInformationOtherCostsBasicInformationGateway actualCostsInformationOtherCostsBasicInformationGateway = new ActualCostsInformationOtherCostsBasicInformationGateway(hotelCostsInformationChanges);

                // Update employee
                foreach (ActualCostsInformationTDS.OtherCostsBasicInformationRow row in (ActualCostsInformationTDS.OtherCostsBasicInformationDataTable)hotelCostsInformationChanges.OtherCostsBasicInformation)
                {
                    // Insert new hours 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        string comment = ""; if (!row.IsCommentNull()) comment = row.Comment;
                        ActualCostsOtherCosts actualCostsOtherCosts = new ActualCostsOtherCosts(null);
                        actualCostsOtherCosts.InsertDirect(row.ProjectID, row.RefID, row.Category, row.Date, row.RateCad, row.RateUsd, comment, row.Deleted, row.COMPANY_ID);
                    }

                    // Update hours
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int projectId = row.ProjectID;
                        int refId = row.RefID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // Original values
                        string originalCategoryId = actualCostsInformationOtherCostsBasicInformationGateway.GetCategoryOriginal(projectId, refId);
                        DateTime originalDate = actualCostsInformationOtherCostsBasicInformationGateway.GetDateOriginal(projectId, refId);                        
                        decimal originalRateCad = actualCostsInformationOtherCostsBasicInformationGateway.GetRateCadOriginal(projectId, refId);                        
                        decimal originalRateUsd = actualCostsInformationOtherCostsBasicInformationGateway.GetRateUsdOriginal(projectId, refId);                        
                        string originalComment = actualCostsInformationOtherCostsBasicInformationGateway.GetCommentOriginal(projectId, refId);

                        // New values
                        string newCategoryId = actualCostsInformationOtherCostsBasicInformationGateway.GetCategory(projectId, refId);
                        DateTime newDate = actualCostsInformationOtherCostsBasicInformationGateway.GetDate(projectId, refId);                        
                        decimal newRateCad = actualCostsInformationOtherCostsBasicInformationGateway.GetRateCad(projectId, refId);                        
                        decimal newRateUsd = actualCostsInformationOtherCostsBasicInformationGateway.GetRateUsd(projectId, refId);                        
                        string newComment = actualCostsInformationOtherCostsBasicInformationGateway.GetComment(projectId, refId);

                        ActualCostsOtherCosts actualCostsOtherCosts = new ActualCostsOtherCosts(null);
                        actualCostsOtherCosts.UpdateDirect(projectId, refId, originalCategoryId, originalDate, originalRateCad, originalRateUsd, originalComment, originalDeleted, originalCompanyId, projectId, refId, newCategoryId, newDate, newRateCad, newRateUsd, newComment, originalDeleted, originalCompanyId);
                    }

                    // Delete hours 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        ActualCostsOtherCosts actualCostsOtherCosts = new ActualCostsOtherCosts(null);
                        actualCostsOtherCosts.DeleteDirect(row.ProjectID, row.RefID, row.COMPANY_ID);
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
        private ActualCostsInformationTDS.OtherCostsBasicInformationRow GetRow(int projectId, int refId)
        {
            ActualCostsInformationTDS.OtherCostsBasicInformationRow row = ((ActualCostsInformationTDS.OtherCostsBasicInformationDataTable)Table).FindByProjectIDRefID(projectId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsInformationOtherCostsBasicInformation.GetRow");
            }

            return row;
        }



    }
}