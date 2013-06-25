using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;

namespace LiquiForce.LFSLive.BL.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsInformationInsuranceCostsBasicInformation
    /// </summary>
    public class ActualCostsInformationInsuranceCostsBasicInformation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsInformationInsuranceCostsBasicInformation()
            : base("InsuranceCostsBasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsInformationInsuranceCostsBasicInformation(DataSet data)
            : base(data, "InsuranceCostsBasicInformation")
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
            ActualCostsInformationInsuranceCostsBasicInformationGateway actualCostsInformationInsuranceCostsBasicInformationGateway = new ActualCostsInformationInsuranceCostsBasicInformationGateway(Data);
            actualCostsInformationInsuranceCostsBasicInformationGateway.LoadByProjectIdRefId(projectId, refId, companyId);
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
            ActualCostsInformationTDS.InsuranceCostsBasicInformationRow row = GetRow(projectId, refId);
 
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
            ActualCostsInformationTDS.InsuranceCostsBasicInformationRow row = GetRow(projectId, refId);

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

            if (hotelCostsInformationChanges.InsuranceCostsBasicInformation.Rows.Count > 0)
            {
                ActualCostsInformationInsuranceCostsBasicInformationGateway actualCostsInformationInsuranceCostsBasicInformationGateway = new ActualCostsInformationInsuranceCostsBasicInformationGateway(hotelCostsInformationChanges);

                // Update employee
                foreach (ActualCostsInformationTDS.InsuranceCostsBasicInformationRow row in (ActualCostsInformationTDS.InsuranceCostsBasicInformationDataTable)hotelCostsInformationChanges.InsuranceCostsBasicInformation)
                {
                    // Insert new hours 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        string comment = ""; if (!row.IsCommentNull()) comment = row.Comment;
                        ActualCostsInsuranceCompaniesCosts actualCostsInsuranceCompaniesCosts = new ActualCostsInsuranceCompaniesCosts(null);
                        actualCostsInsuranceCompaniesCosts.InsertDirect(row.ProjectID, row.RefID, row.InsuranceCompanyID, row.Date, row.RateCad, row.RateUsd, comment, row.Deleted, row.COMPANY_ID);
                    }

                    // Update hours
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int projectId = row.ProjectID;
                        int refId = row.RefID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // Original values
                        int originalInsuranceId = actualCostsInformationInsuranceCostsBasicInformationGateway.GetInsuranceIDOriginal(projectId, refId);
                        DateTime originalDate = actualCostsInformationInsuranceCostsBasicInformationGateway.GetDateOriginal(projectId, refId);                        
                        decimal originalRateCad = actualCostsInformationInsuranceCostsBasicInformationGateway.GetRateCadOriginal(projectId, refId);                        
                        decimal originalRateUsd = actualCostsInformationInsuranceCostsBasicInformationGateway.GetRateUsdOriginal(projectId, refId);                        
                        string originalComment = actualCostsInformationInsuranceCostsBasicInformationGateway.GetCommentOriginal(projectId, refId);

                        // New values
                        int newInsuranceId = actualCostsInformationInsuranceCostsBasicInformationGateway.GetInsuranceID(projectId, refId);
                        DateTime newDate = actualCostsInformationInsuranceCostsBasicInformationGateway.GetDate(projectId, refId);                        
                        decimal newRateCad = actualCostsInformationInsuranceCostsBasicInformationGateway.GetRateCad(projectId, refId);                        
                        decimal newRateUsd = actualCostsInformationInsuranceCostsBasicInformationGateway.GetRateUsd(projectId, refId);                        
                        string newComment = actualCostsInformationInsuranceCostsBasicInformationGateway.GetComment(projectId, refId);

                        ActualCostsInsuranceCompaniesCosts actualCostsInsuranceCompaniesCosts = new ActualCostsInsuranceCompaniesCosts(null);
                        actualCostsInsuranceCompaniesCosts.UpdateDirect(projectId, refId, originalInsuranceId, originalDate, originalRateCad, originalRateUsd, originalComment, originalDeleted, originalCompanyId, projectId, refId, newInsuranceId, newDate, newRateCad, newRateUsd, newComment, originalDeleted, originalCompanyId);
                    }

                    // Delete hours 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        ActualCostsInsuranceCompaniesCosts actualCostsInsuranceCompaniesCosts = new ActualCostsInsuranceCompaniesCosts(null);
                        actualCostsInsuranceCompaniesCosts.DeleteDirect(row.ProjectID, row.RefID, row.COMPANY_ID);
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
        private ActualCostsInformationTDS.InsuranceCostsBasicInformationRow GetRow(int projectId, int refId)
        {
            ActualCostsInformationTDS.InsuranceCostsBasicInformationRow row = ((ActualCostsInformationTDS.InsuranceCostsBasicInformationDataTable)Table).FindByProjectIDRefID(projectId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsInformationInsuranceCostsBasicInformation.GetRow");
            }

            return row;
        }



    }
}