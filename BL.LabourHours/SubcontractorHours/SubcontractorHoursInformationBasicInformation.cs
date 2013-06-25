using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.SubcontractorHours;

namespace LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours
{
    /// <summary>
    /// SubcontractorHoursInformationBasicInformation
    /// </summary>
    public class SubcontractorHoursInformationBasicInformation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SubcontractorHoursInformationBasicInformation()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SubcontractorHoursInformationBasicInformation(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SubcontractorHoursInformationTDS();
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
            SubcontractorHoursInformationBasicInformationGateway subcontractorHoursInformationBasicInformationGateway = new SubcontractorHoursInformationBasicInformationGateway(Data);
            subcontractorHoursInformationBasicInformationGateway.LoadByProjectIdRefId(projectId, refId, companyId);
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
            SubcontractorHoursInformationTDS.BasicInformationRow row = GetRow(projectId, refId);
 
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
            SubcontractorHoursInformationTDS.BasicInformationRow row = GetRow(projectId, refId);

            // General Data                      
            row.Deleted = true;            
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            SubcontractorHoursInformationTDS aubcontractorHoursInformationChanges = (SubcontractorHoursInformationTDS)Data.GetChanges();

            if (aubcontractorHoursInformationChanges.BasicInformation.Rows.Count > 0)
            {
                SubcontractorHoursInformationBasicInformationGateway employeeInformationBasicInformationGateway = new SubcontractorHoursInformationBasicInformationGateway(aubcontractorHoursInformationChanges);

                // Update employee
                foreach (SubcontractorHoursInformationTDS.BasicInformationRow row in (SubcontractorHoursInformationTDS.BasicInformationDataTable)aubcontractorHoursInformationChanges.BasicInformation)
                {
                    // Insert new hours 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        string comment = ""; if (!row.IsCommentNull()) comment = row.Comment;
                        SubcontractorHoursSubcontractorHours subcontractorHoursSubcontractorHours = new SubcontractorHoursSubcontractorHours(null);
                        subcontractorHoursSubcontractorHours.InsertDirect(row.ProjectID, row.RefID, row.SubcontractorID, row.Date, row.Quantity, row.RateCad, row.TotalCad, row.RateUsd, row.TotalUsd, comment, row.Deleted, row.COMPANY_ID);
                    }

                    // Update hours
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int projectId = row.ProjectID;
                        int refId = row.RefID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // Original values
                        int originalSubcontractorId = employeeInformationBasicInformationGateway.GetSubcontractorIDOriginal(projectId, refId);
                        DateTime originalDate = employeeInformationBasicInformationGateway.GetDateOriginal(projectId, refId);
                        double originalQuantity = employeeInformationBasicInformationGateway.GetQuantityOriginal(projectId, refId);
                        decimal originalRateCad = employeeInformationBasicInformationGateway.GetRateCadOriginal(projectId, refId);
                        decimal originalTotalCad = employeeInformationBasicInformationGateway.GetTotalCadOriginal(projectId, refId);
                        decimal originalRateUsd = employeeInformationBasicInformationGateway.GetRateUsdOriginal(projectId, refId);
                        decimal originalTotalUsd = employeeInformationBasicInformationGateway.GetTotalUsdOriginal(projectId, refId);
                        string originalComment = employeeInformationBasicInformationGateway.GetCommentOriginal(projectId, refId);

                        // New values
                        int newSubcontractorId = employeeInformationBasicInformationGateway.GetSubcontractorID(projectId, refId);
                        DateTime newDate = employeeInformationBasicInformationGateway.GetDate(projectId, refId);
                        double newQuantity = employeeInformationBasicInformationGateway.GetQuantity(projectId, refId);
                        decimal newRateCad = employeeInformationBasicInformationGateway.GetRateCad(projectId, refId);
                        decimal newTotalCad = employeeInformationBasicInformationGateway.GetTotalCad(projectId, refId);
                        decimal newRateUsd = employeeInformationBasicInformationGateway.GetRateUsd(projectId, refId);
                        decimal newTotalUsd = employeeInformationBasicInformationGateway.GetTotalUsd(projectId, refId);
                        string newComment = employeeInformationBasicInformationGateway.GetComment(projectId, refId);

                        SubcontractorHoursSubcontractorHours subcontractorHoursSubcontractorHours = new SubcontractorHoursSubcontractorHours(null);
                        subcontractorHoursSubcontractorHours.UpdateDirect(projectId, refId, originalSubcontractorId, originalDate, originalQuantity, originalRateCad, originalTotalCad, originalRateUsd, originalTotalUsd, originalComment, originalDeleted, originalCompanyId, projectId, refId, newSubcontractorId, newDate, newQuantity, newRateCad, newTotalCad, newRateUsd, newTotalUsd, newComment, originalDeleted, originalCompanyId);
                    }

                    // Delete hours 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        SubcontractorHoursSubcontractorHours subcontractorHoursSubcontractorHours = new SubcontractorHoursSubcontractorHours(null);
                        subcontractorHoursSubcontractorHours.DeleteDirect(row.ProjectID, row.RefID, row.COMPANY_ID);
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
        private SubcontractorHoursInformationTDS.BasicInformationRow GetRow(int projectId, int refId)
        {
            SubcontractorHoursInformationTDS.BasicInformationRow row = ((SubcontractorHoursInformationTDS.BasicInformationDataTable)Table).FindByProjectIDRefID(projectId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours.SubcontractorHoursInformationBasicInformation.GetRow");
            }

            return row;
        }



    }
}