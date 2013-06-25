using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.SubcontractorHours;

namespace LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours
{
    /// <summary>
    /// SubcontractorHoursAddSubcontractorHours
    /// </summary>
    public class SubcontractorHoursAddSubcontractorHours : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SubcontractorHoursAddSubcontractorHours()
            : base("SubcontractorHours")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SubcontractorHoursAddSubcontractorHours(DataSet data)
            : base(data, "SubcontractorHours")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SubcontractorHoursAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadAllByProjectId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public void LoadAllByProjectId(int projectId, int companyId)
        {
            SubcontractorHoursAddSubcontractorHoursGateway subcontractorHoursAddSubcontractorHoursGateway = new SubcontractorHoursAddSubcontractorHoursGateway(Data);
            subcontractorHoursAddSubcontractorHoursGateway.LoadAllByProjectId(projectId, companyId);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="date">date</param>
        /// <param name="quantity">quantity</param>
        /// <param name="rateCad">rateCad</param>
        /// <param name="totalCad">totalCad</param>
        /// <param name="rateUsd">rateUsd</param>
        /// <param name="totalUsd">totalUsd</param>        
        /// <param name="comment">comment</param>
        /// <param name="deleted">Deleted</param>
        /// <param name="libraryFilesId">LibraryFilesId</param>
        /// <param name="companyId">CompanyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="name">name</param>
        /// <param name="client">client</param>
        /// <param name="project">project</param>
        public void Insert(int projectId, int subcontractorId, DateTime date, double quantity, decimal rateCad, decimal totalCad, decimal rateUsd, decimal totalUsd, string comment, bool deleted, int companyId, bool inDatabase, string name, string client, string project, int clientId)
        {
            SubcontractorHoursAddTDS.SubcontractorHoursRow row = ((SubcontractorHoursAddTDS.SubcontractorHoursDataTable)Table).NewSubcontractorHoursRow();
            row.RefID = GetNewRefId(projectId, companyId);
            row.ProjectID = projectId;
            row.SubcontractorID = subcontractorId;
            row.Date = date;
            row.Quantity = quantity;
            row.RateCad = rateCad;
            row.TotalCad = totalCad;
            row.RateUsd = rateUsd;
            row.TotalUsd = totalUsd;
            if ((comment != "") && (comment != null)) row.Comment = comment.Trim(); else row.SetCommentNull();
            row.Deleted = deleted;            
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.Name = name;
            row.Rate = rateCad;
            row.Total = totalCad;
            row.Client = client;
            row.Project = project;
            row.ClientID = clientId;
            ((SubcontractorHoursAddTDS.SubcontractorHoursDataTable)Table).AddSubcontractorHoursRow(row);
        }



        /// <summary>
        /// Update
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
        /// <param name="deleted">Deleted</param>        
        /// <param name="companyId">CompanyId</param>
        /// <param name="name">name</param>
        /// <param name="client">client</param>
        /// <param name="project">project</param>
        public void Update(int projectId, int refId, int subcontractorId, DateTime date, double quantity, decimal rateCad, decimal totalCad, decimal rateUsd, decimal totalUsd, string comment, bool deleted, int companyId, string name, string client, string project, int clientId)
        {
            SubcontractorHoursAddTDS.SubcontractorHoursRow row = GetRow(projectId, refId);
            
            row.SubcontractorID = subcontractorId;
            row.Date = date;
            row.Quantity = quantity;
            row.RateCad = rateCad;
            row.TotalCad = totalCad;
            row.RateUsd = rateUsd;
            row.TotalUsd = totalUsd;
            if ((comment != "") && (comment != null)) row.Comment = comment.Trim(); else row.SetCommentNull();            
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.Name = name;
            row.Rate = rateCad;
            row.Total = totalCad;
            row.Client = client;
            row.Project = project;
            row.ClientID = clientId;
        }



        /// <summary>
        /// Delete project
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="refId">RefId</param>
        /// <returns></returns>
        public void Delete(int projectId, int refId)
        {
            SubcontractorHoursAddTDS.SubcontractorHoursRow row = GetRow(projectId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all udfs to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            SubcontractorHoursAddTDS subcontractorsChanges = (SubcontractorHoursAddTDS)Data.GetChanges();

            if (subcontractorsChanges != null)
            {
                if (subcontractorsChanges.SubcontractorHours.Rows.Count > 0)
                {
                    SubcontractorHoursAddSubcontractorHoursGateway subcontractorHoursAddSubcontractorHoursGateway = new SubcontractorHoursAddSubcontractorHoursGateway(subcontractorsChanges);

                    foreach (SubcontractorHoursAddTDS.SubcontractorHoursRow row in (SubcontractorHoursAddTDS.SubcontractorHoursDataTable)subcontractorsChanges.SubcontractorHours)
                    {
                        // Insert new subcontractor hours 
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            int projectId = row.ProjectID;
                            int refId = row.RefID;
                            int subcontractorId = row.SubcontractorID;

                            decimal rateUsd = 0; if (!row.IsRateUsdNull()) rateUsd = row.RateUsd;
                            decimal totalUsd = 0; if (!row.IsTotalUsdNull()) totalUsd = row.TotalUsd;
                            string comment = ""; if (!row.IsCommentNull()) comment = row.Comment;

                            SubcontractorHoursSubcontractorHours subcontractorHoursSubcontractorHours = new SubcontractorHoursSubcontractorHours(null);
                            subcontractorHoursSubcontractorHours.InsertDirect(projectId, refId, subcontractorId, row.Date, row.Quantity, row.RateCad, row.TotalCad, rateUsd, totalUsd, comment, row.Deleted, row.COMPANY_ID);
                        }

                        //// Update subcontractor hours 
                        //if ((!row.Deleted) && (row.InDatabase))
                        //{
                        //    int projectId = row.ProjectID;
                        //    int refId = row.RefID;
                        //    bool originalDeleted = false;
                        //    int originalCompanyId = companyId;

                        //    // Original values
                        //    int originalSubcontractorId = subcontractorHoursAddSubcontractorHoursGateway.GetSubcontractorIDOriginal(projectId, refId);
                        //    DateTime originalDate = subcontractorHoursAddSubcontractorHoursGateway.GetDateOriginal(projectId, refId);
                        //    double originalQuantity = subcontractorHoursAddSubcontractorHoursGateway.GetQuantityOriginal(projectId, refId);
                        //    decimal originalRateCad = subcontractorHoursAddSubcontractorHoursGateway.GetRateCadOriginal(projectId, refId);
                        //    decimal originalTotalCad = subcontractorHoursAddSubcontractorHoursGateway.GetTotalCadOriginal(projectId, refId);
                        //    decimal originalRateUsd = subcontractorHoursAddSubcontractorHoursGateway.GetRateUsdOriginal(projectId, refId);
                        //    decimal originalTotalUsd = subcontractorHoursAddSubcontractorHoursGateway.GetTotalUsdOriginal(projectId, refId);
                        //    string originalComment = subcontractorHoursAddSubcontractorHoursGateway.GetCommentOriginal(projectId, refId);                        

                        //    // New values
                        //    int newSubcontractorId = subcontractorHoursAddSubcontractorHoursGateway.GetSubcontractorID(projectId, refId);
                        //    DateTime newDate = subcontractorHoursAddSubcontractorHoursGateway.GetDate(projectId, refId);
                        //    double newQuantity = subcontractorHoursAddSubcontractorHoursGateway.GetQuantity(projectId, refId);
                        //    decimal newRateCad = subcontractorHoursAddSubcontractorHoursGateway.GetRateCad(projectId, refId);
                        //    decimal newTotalCad = subcontractorHoursAddSubcontractorHoursGateway.GetTotalCad(projectId, refId);
                        //    decimal newRateUsd = subcontractorHoursAddSubcontractorHoursGateway.GetRateUsd(projectId, refId);
                        //    decimal newTotalUsd = subcontractorHoursAddSubcontractorHoursGateway.GetTotalUsd(projectId, refId);                        
                        //    string newComment = subcontractorHoursAddSubcontractorHoursGateway.GetComment(projectId, refId);

                        //    SubcontractorHoursSubcontractorHours subcontractorHoursSubcontractorHours = new SubcontractorHoursSubcontractorHours(null);
                        //    subcontractorHoursSubcontractorHours.UpdateDirect(projectId, refId, originalSubcontractorId, originalDate, originalQuantity, originalRateCad, originalTotalCad, originalRateUsd, originalTotalUsd, originalComment, originalDeleted, originalCompanyId, projectId, refId, newSubcontractorId, newDate, newQuantity, newRateCad, newTotalCad, newRateUsd, newTotalUsd, newComment, originalDeleted, originalCompanyId);
                        //}

                        //// Delete subcontractor hours  
                        //if ((row.Deleted) && (row.InDatabase))
                        //{
                        //    SubcontractorHoursSubcontractorHours subcontractorHoursSubcontractorHours = new SubcontractorHoursSubcontractorHours(null);
                        //    subcontractorHoursSubcontractorHours.DeleteDirect(row.ProjectID, row.RefID, row.COMPANY_ID);
                        //}
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
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>New ID</returns>
        public int GetNewRefId(int projectId, int companyId)
        {
            //SubcontractorHoursAddTDS dataSet = new SubcontractorHoursAddTDS();
            //dataSet.SubcontractorHours.Merge(this.Table, true);
            //SubcontractorHoursAddSubcontractorHours model = new SubcontractorHoursAddSubcontractorHours(dataSet);

            //if (dataSet.SubcontractorHours.Rows.Count <= 0)
            //{
            //    model.LoadAllByProjectId(projectId, companyId);
            //}

            //// Store tables
            //this.Table = (SubcontractorHoursAddTDS.SubcontractorHoursDataTable)model.Table;

            int newRefId = 0;

            if (Table.Rows.Count == 0)
            {
                SubcontractorHoursAddSubcontractorHoursGateway rr = new SubcontractorHoursAddSubcontractorHoursGateway();
                rr.LoadAllByProjectId(projectId, companyId);

                foreach (SubcontractorHoursAddTDS.SubcontractorHoursRow row1 in (SubcontractorHoursAddTDS.SubcontractorHoursDataTable)rr.Table)
                {
                    if (newRefId < row1.RefID)
                    {
                        newRefId = row1.RefID;
                    }
                }
            }
            else
            {
                foreach (SubcontractorHoursAddTDS.SubcontractorHoursRow row2 in (SubcontractorHoursAddTDS.SubcontractorHoursDataTable)Table)
                {
                    if (newRefId < row2.RefID)
                    {
                        newRefId = row2.RefID;
                    }
                }

            }

            newRefId++;

            return newRefId;
        }



        /// <summary>
        /// Get a single sobcontractor hour. If not exists, raise an exception
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>SubcontractorHoursAddTDS.SubcontractorHoursRow</returns>
        private SubcontractorHoursAddTDS.SubcontractorHoursRow GetRow(int projectId, int refId)
        {
            SubcontractorHoursAddTDS.SubcontractorHoursRow row = ((SubcontractorHoursAddTDS.SubcontractorHoursDataTable)Table).FindByProjectIDRefID(projectId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours.SubcontractorHoursAddSubcontractorHours.GetRow");
            }

            return row;
        }



    }
}