using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation
{
    /// <summary>
    /// ManholeRehabilitationWorkDetails
    /// </summary>
    public class ManholeRehabilitationWorkDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ManholeRehabilitationWorkDetails()
            : base("WorkDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ManholeRehabilitationWorkDetails(DataSet data)
            : base(data, "WorkDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ManholeRehabilitationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByWorkIdAssetId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByWorkIdAssetId(int workId, int assetId, int companyId)
        {
            ManholeRehabilitationWorkDetailsGateway manholeRehabilitationWorkDetailsGateway = new ManholeRehabilitationWorkDetailsGateway(Data);
            manholeRehabilitationWorkDetailsGateway.LoadByWorkIdAssetId(workId, assetId, companyId);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="preppedDate">preppedDate</param>
        /// <param name="sprayedDate">sprayedDate</param>
        /// <param name="batchId">batchId</param> 
        /// <param name="date">date</param> 
        /// <param name="companyId">companyId</param>
        public void Update(int workId, DateTime? preppedDate, DateTime? sprayedDate, int? batchId, DateTime date, int companyId)
        {
            WorkManholeRehabilitationGateway workManholeRehabilitationGatewayForReview = new WorkManholeRehabilitationGateway();
            workManholeRehabilitationGatewayForReview.LoadByWorkId(workId, companyId);

            if (workManholeRehabilitationGatewayForReview.Table.Rows.Count > 0)
            {
                // Update work 
                ManholeRehabilitationTDS.WorkDetailsRow row = GetRow(workId);

                if (preppedDate.HasValue) row.PreppedDate = (DateTime)preppedDate; else row.SetPreppedDateNull();
                if (sprayedDate.HasValue) row.SprayedDate = (DateTime)sprayedDate; else row.SetSprayedDateNull();
                row.Date = date;
                row.BatchID = (int)batchId;
            }
            else
            {
                // ... Insert work
                ManholeRehabilitationTDS.WorkDetailsRow lfsManholeRehabilitationRow = ((ManholeRehabilitationTDS.WorkDetailsDataTable)Table).NewWorkDetailsRow();

                workId = GetNewId();
                lfsManholeRehabilitationRow.WorkID = workId;
                if (preppedDate.HasValue) lfsManholeRehabilitationRow.PreppedDate = (DateTime)preppedDate; else lfsManholeRehabilitationRow.SetPreppedDateNull();
                if (sprayedDate.HasValue) lfsManholeRehabilitationRow.SprayedDate = (DateTime)sprayedDate; else lfsManholeRehabilitationRow.SetSprayedDateNull();

                lfsManholeRehabilitationRow.BatchID = 0;

                MrBatchVerificationGateway mrBatchVerificationGateway = new MrBatchVerificationGateway();
                mrBatchVerificationGateway.LoadAll(companyId);

                if (mrBatchVerificationGateway.Table.Rows.Count > 0)
                {
                    WorkManholeRehabilitationBatchGateway workManholeRehabilitationBatchGateway = new WorkManholeRehabilitationBatchGateway();
                    lfsManholeRehabilitationRow.BatchID = workManholeRehabilitationBatchGateway.GetLastId(companyId);
                }
                else
                {
                    lfsManholeRehabilitationRow.SetBatchIDNull();
                }
                
                lfsManholeRehabilitationRow.Date = (DateTime)date;
                lfsManholeRehabilitationRow.Deleted = false;
                lfsManholeRehabilitationRow.COMPANY_ID = companyId;

                ((ManholeRehabilitationTDS.WorkDetailsDataTable)Table).AddWorkDetailsRow(lfsManholeRehabilitationRow);
            }
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inProject">inProject</param>
        /// <returns>WorkID</returns>
        public int Save(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int projectId, int assetId, int companyId, bool inProject)
        {
            ManholeRehabilitationTDS manholeRehabilitationChanges = (ManholeRehabilitationTDS)Data.GetChanges();
            int workId = 0;

            if (manholeRehabilitationChanges.WorkDetails.Rows.Count > 0)
            {
                ManholeRehabilitationWorkDetailsGateway manholeRehabilitationWorkDetailsGateway = new ManholeRehabilitationWorkDetailsGateway(manholeRehabilitationChanges);

                // Update manhole rehabilitation
                foreach (ManholeRehabilitationTDS.WorkDetailsRow row in (ManholeRehabilitationTDS.WorkDetailsDataTable)manholeRehabilitationChanges.WorkDetails)
                {
                    // Unchanged values
                    workId = row.WorkID;

                    WorkManholeRehabilitationGateway workManholeRehabilitationGateway = new WorkManholeRehabilitationGateway();
                    workManholeRehabilitationGateway.LoadByWorkId(workId, companyId);

                    if (workManholeRehabilitationGateway.Table.Rows.Count > 0)
                    {
                        // Update Information
                        // Original values
                        // ... work values            
                        DateTime? originalPreppedDate = manholeRehabilitationWorkDetailsGateway.GetPreppedDateOriginal(workId);
                        DateTime? originalSprayedDate = manholeRehabilitationWorkDetailsGateway.GetSprayedDateOriginal(workId);

                        // ... Comments
                        string originalComments = manholeRehabilitationWorkDetailsGateway.GetCommentsOriginal(workId);

                        // New variables
                        DateTime? newPreppedDate = manholeRehabilitationWorkDetailsGateway.GetPreppedDate(workId);
                        DateTime? newSprayedDate = manholeRehabilitationWorkDetailsGateway.GetSprayedDate(workId);

                        // comments
                        string newComments = manholeRehabilitationWorkDetailsGateway.GetComments(workId);

                        // Update work                        
                        UpdateWork(countryId, provinceId, countyId, cityId, projectId, assetId, originalPreppedDate, originalSprayedDate, row.BatchID, originalComments, false, companyId, newPreppedDate, newSprayedDate, row.BatchID, newComments, false);
                    }
                    else
                    {
                        // Loading workId
                        WorkGateway workGateway = new WorkGateway();
                        workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Manhole Rehabilitation", companyId);

                        if (workGateway.Table.Rows.Count == 0)
                        {
                            // New variables
                            DateTime? newPreppedDate = manholeRehabilitationWorkDetailsGateway.GetPreppedDate(workId);
                            DateTime? newSprayedDate = manholeRehabilitationWorkDetailsGateway.GetSprayedDate(workId);
                            int? newBatchId = manholeRehabilitationWorkDetailsGateway.GetBatchID(workId);
                            string newComments = manholeRehabilitationWorkDetailsGateway.GetComments(workId);

                            // InsertWork
                            Work work = new Work();

                            int? libraryCategories = null;
                            string history = "";

                            int newWorkId = work.InsertDirect(projectId, assetId, "Manhole Rehabilitation", libraryCategories, false, companyId, newComments, history);

                            // ... Insert manhole rehabilitation work
                            WorkManholeRehabilitation workManholeRehabilitation = new WorkManholeRehabilitation();
                            workManholeRehabilitation.InsertDirect(newWorkId, newPreppedDate, newSprayedDate, newBatchId, false, companyId);

                            workId = newWorkId;
                        }
                    }
                }
            }

            return workId;
        }



        /// <summary>
        /// Save2
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inProject">inProject</param>
        public void Save2(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int projectId, int assetId, int companyId, bool inProject)
        {
            ManholeRehabilitationTDS manholeRehabilitationChanges = (ManholeRehabilitationTDS)Data.GetChanges();

            if (manholeRehabilitationChanges.WorkDetails.Rows.Count > 0)
            {
                ManholeRehabilitationWorkDetailsGateway manholeRehabilitationWorkDetailsGateway = new ManholeRehabilitationWorkDetailsGateway(manholeRehabilitationChanges);

                // Update manhole rehabilitation
                foreach (ManholeRehabilitationTDS.WorkDetailsRow row in (ManholeRehabilitationTDS.WorkDetailsDataTable)manholeRehabilitationChanges.WorkDetails)
                {
                    // Unchanged values
                    int workId = row.WorkID;

                    WorkManholeRehabilitationGateway workManholeRehabilitationGateway = new WorkManholeRehabilitationGateway();
                    workManholeRehabilitationGateway.LoadByWorkId(workId, companyId);

                    if (workManholeRehabilitationGateway.Table.Rows.Count > 0)
                    {
                        // Update Information
                        // Original values
                        // ... work values            
                        DateTime? originalPreppedDate = manholeRehabilitationWorkDetailsGateway.GetPreppedDateOriginal(workId);
                        DateTime? originalSprayedDate = manholeRehabilitationWorkDetailsGateway.GetSprayedDateOriginal(workId);

                        // ... Comments
                        string originalComments = manholeRehabilitationWorkDetailsGateway.GetCommentsOriginal(workId);

                        // New variables
                        DateTime? newPreppedDate = manholeRehabilitationWorkDetailsGateway.GetPreppedDate(workId);
                        DateTime? newSprayedDate = manholeRehabilitationWorkDetailsGateway.GetSprayedDate(workId);

                        // comments
                        string newComments = manholeRehabilitationWorkDetailsGateway.GetComments(workId);

                        // Update work                        
                        UpdateWork(countryId, provinceId, countyId, cityId, projectId, assetId, originalPreppedDate, originalSprayedDate, row.BatchID, originalComments, false, companyId, newPreppedDate, newSprayedDate, row.BatchID, newComments, false);
                    }
                    else
                    {
                        // Loading workId
                        WorkGateway workGateway = new WorkGateway();
                        workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Manhole Rehabilitation", companyId);

                        if (workGateway.Table.Rows.Count == 0)
                        {
                            // New variables
                            DateTime? newPreppedDate = manholeRehabilitationWorkDetailsGateway.GetPreppedDate(workId);
                            DateTime? newSprayedDate = manholeRehabilitationWorkDetailsGateway.GetSprayedDate(workId);
                            int? newBatchId = manholeRehabilitationWorkDetailsGateway.GetBatchID(workId);
                            string newComments = manholeRehabilitationWorkDetailsGateway.GetComments(workId);

                            // InsertWork
                            Work work = new Work();

                            int? libraryCategories = null;
                            string history = "";
                            int newWorkId = work.InsertDirect(projectId, assetId, "Manhole Rehabilitation", libraryCategories, false, companyId, newComments, history);

                            // ... Insert manhole rehabilitation work
                            WorkManholeRehabilitation workManholeRehabilitation = new WorkManholeRehabilitation();
                            workManholeRehabilitation.InsertDirect(newWorkId, newPreppedDate, newSprayedDate, newBatchId, false, companyId);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// UpdateCommentsForSummaryEdit
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void UpdateCommentsForSummaryEdit(int workId, int companyId)
        {
            WorkCommentsGateway workComentsGateway = new WorkCommentsGateway();
            WorkComments workComments = new WorkComments(workComentsGateway.Data);
            WorkGateway workGateway = new WorkGateway();

            ManholeRehabilitationTDS.WorkDetailsRow row = GetRow(workId);

            workGateway.LoadByWorkId(workId, companyId);
            workComentsGateway.LoadByWorkIdWorkType(workId, companyId, "Manhole Rehabilitation");
            row.Comments = workComments.GetAllComments(workId, companyId, workComentsGateway.Table.Rows.Count, "\n");            
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="workId">workId</param>
        public void Delete(int workId)
        {
            ManholeRehabilitationTDS.WorkDetailsRow row = GetRow(workId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, int companyId)
        {
            // Delete work
            WorkManholeRehabilitation workManholeRehabilitation = new WorkManholeRehabilitation(null);
            workManholeRehabilitation.DeleteDirect(workId, companyId);
        }
 





        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateWork
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="originalPreppedDate">originalPreppedDate</param>
        /// <param name="originalSprayedDate">originalSprayedDate</param>
        /// <param name="originalBatchId">originalBatchId</param>        
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newPreppedDate">newPreppedDate</param>
        /// <param name="newSprayedDate">newSprayedDate</param>
        /// <param name="newBatchId">newBatchId</param>        
        /// <param name="newComments">newComments</param>
        /// <param name="newDeleted">newDeleted</param>
        private void UpdateWork(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int projectId, int assetId, DateTime? originalPreppedDate, DateTime? originalSprayedDate, int originalBatchId, string originalComments, bool originalDeleted, int originalCompanyId, DateTime? newPreppedDate, DateTime? newSprayedDate, int newBatchId, string newComments, bool newDeleted)
        {
            int newWorkId = 0;

            // Loading workId
            WorkGateway workGateway = new WorkGateway();                
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Manhole Rehabilitation", originalCompanyId);

            if (workGateway.Table.Rows.Count > 0)
            {
                newWorkId = workGateway.GetWorkId(assetId, "Manhole Rehabilitation", projectId);

                int? libraryCategoriesId = workGateway.GetLibraryCategoriesId(newWorkId);
                string history = workGateway.GetHistory(newWorkId);

                // Updating work
                Work work = new Work();
                work.UpdateDirect(newWorkId, projectId, assetId, "Manhole Rehabilitation", libraryCategoriesId, originalDeleted, originalCompanyId, originalComments, history, newWorkId, projectId, assetId, "Manhole Rehabilitation", libraryCategoriesId, originalDeleted, originalCompanyId, newComments, history);

                // Update manhole rehabilitation work
                WorkManholeRehabilitation workManholeRehabilitation = new WorkManholeRehabilitation();
                workManholeRehabilitation.UpdateDirect(newWorkId, originalPreppedDate, originalSprayedDate, originalBatchId, originalDeleted, originalCompanyId, newWorkId, newPreppedDate, newSprayedDate, newBatchId, newDeleted, originalCompanyId);
            }                       
        }       


        
        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Row obtained</returns>
        private ManholeRehabilitationTDS.WorkDetailsRow GetRow(int workId)
        {
            ManholeRehabilitationTDS.WorkDetailsRow row = ((ManholeRehabilitationTDS.WorkDetailsDataTable)Table).FindByWorkID(workId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation.ManholeRehabilitationWorkDetails.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewId
        /// </summary>
        /// <returns>newId</returns>
        private int GetNewId()
        {
            int newId = 0;

            foreach (ManholeRehabilitationTDS.WorkDetailsRow row in (ManholeRehabilitationTDS.WorkDetailsDataTable)Table)
            {
                if (newId < row.WorkID)
                {
                    newId = row.WorkID;
                }
            }

            newId++;

            return newId;
        }



    }
}