using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation
{
    /// <summary>
    /// MrBatchVerification
    /// </summary>
    public class MrBatchVerification: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MrBatchVerification()
            : base("BatchValidation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MrBatchVerification(DataSet data)
            : base(data, "BatchValidation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MrBatchVerificationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAll
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadAll(int companyId)
        {
            MrBatchVerificationGateway mrBatchVerificationGateway = new MrBatchVerificationGateway(Data);
            mrBatchVerificationGateway.LoadAll(companyId);
        }



        /// <summary>
        /// LoadByBatchId
        /// </summary>
        /// <param name="batchId">batchId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByBatchId(int batchId,int companyId)
        {
            MrBatchVerificationGateway mrBatchVerificationGateway = new MrBatchVerificationGateway(Data);
            mrBatchVerificationGateway.LoadByBatchId(batchId, companyId);
        }



        /// <summary>
        /// LoadLastBatch
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadLastBatch(int companyId)
        {
            MrBatchVerificationGateway mrBatchVerificationGateway = new MrBatchVerificationGateway(Data);
            mrBatchVerificationGateway.LoadLastBatch(companyId);
        }



        /// <summary>
        /// Insert a new batch
        /// </summary>
        /// <param name="description">description</param>
        /// <param name="date">date</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(string description, DateTime date, bool deleted, int companyId, bool inDatabase)
        {
            MrBatchVerificationTDS.BatchValidationRow row = ((MrBatchVerificationTDS.BatchValidationDataTable)Table).NewBatchValidationRow();

            row.BatchID = GetNewId();
            row.Description = description;
            row.Date = date;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;

            ((MrBatchVerificationTDS.BatchValidationDataTable)Table).AddBatchValidationRow(row);
        }



        /// <summary>
        /// Update a batch
        /// </summary>
        /// <param name="batchId">batchId</param>
        /// <param name="description">description</param>
        /// <param name="date">date</param>
        public void Update(int batchId, string description, DateTime date)
        {
            MrBatchVerificationTDS.BatchValidationRow row = GetRow(batchId);

            row.Description = description;
            row.Date = date;
        }



        /// <summary>
        /// Delete one batch
        /// </summary>
        /// <param name="batchId">batchId</param>
        /// <param name="companyId">companyId</param>        
        public void Delete(int batchId, int companyId)
        {
            MrBatchVerificationTDS.BatchValidationRow row = GetRow(batchId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all batch to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            MrBatchVerificationTDS flBatchValidationChanges = (MrBatchVerificationTDS)Data.GetChanges();

            if (flBatchValidationChanges != null)
            {
                if (flBatchValidationChanges.BatchValidation.Rows.Count > 0)
                {
                    MrBatchVerificationGateway mrBatchVerificationGateway = new MrBatchVerificationGateway(flBatchValidationChanges);

                    foreach (MrBatchVerificationTDS.BatchValidationRow row in (MrBatchVerificationTDS.BatchValidationDataTable)flBatchValidationChanges.BatchValidation)
                    {
                        // Insert new catalysts 
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            WorkManholeRehabilitationBatch workManholeRehabilitationBatch = new WorkManholeRehabilitationBatch(null);
                            workManholeRehabilitationBatch.InsertDirect(row.BatchID, row.Description, row.Date, row.Deleted, row.COMPANY_ID);
                        }

                        //Update catalysts
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            int batchId = row.BatchID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            //original values
                            string originalDescription = mrBatchVerificationGateway.GetDescriptionOriginal(batchId);
                            DateTime originalDate = mrBatchVerificationGateway.GetDateOriginal(batchId);

                            // new values
                            string newDescription = mrBatchVerificationGateway.GetDescription(batchId);
                            DateTime newDate = mrBatchVerificationGateway.GetDate(batchId);

                            WorkManholeRehabilitationBatch workManholeRehabilitationBatch = new WorkManholeRehabilitationBatch(null);
                            workManholeRehabilitationBatch.UpdateDirect(batchId, originalDescription, originalDate, originalDeleted, originalCompanyId, batchId, newDescription, newDate, originalDeleted, originalCompanyId);
                        }

                        // Deleted catalysts 
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            WorkManholeRehabilitationBatch workManholeRehabilitationBatch = new WorkManholeRehabilitationBatch(null);
                            workManholeRehabilitationBatch.DeleteDirect(row.BatchID, row.COMPANY_ID);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// GetSummary
        /// </summary>
        /// <returns>Summary</returns>
        public string GetSummary()
        {
            string summary = "";
            foreach (MrBatchVerificationTDS.BatchValidationRow row in (MrBatchVerificationTDS.BatchValidationDataTable)Table)
            {
                if (!row.Deleted)
                {
                    DateTime date = row.Date;
                    summary = summary + "Date: " + date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString() + "\n";

                    summary = summary + "Description: " + row.Description + "\n\n";
                }
            }

            return summary;
        }






        //// ////////////////////////////////////////////////////////////////////////
        //// PRIVATE METHODS
        ////

        /// <summary>
        /// GetNewId
        /// </summary>
        /// <returns>New ID</returns>
        private int GetNewId()
        {
            int newId = 0;

            foreach (MrBatchVerificationTDS.BatchValidationRow row in (MrBatchVerificationTDS.BatchValidationDataTable)Table)
            {
                if (newId < row.BatchID)
                {
                    newId = row.BatchID;
                }
            }

            newId++;

            return newId;
        }       



        /// <summary>
        /// Get a single catalyst. If not exists, raise an exception
        /// </summary>
        /// <param name="batchId">batchId</param>
        /// <returns>MrBatchVerificationTDS.BatchValidationRow</returns>
        private MrBatchVerificationTDS.BatchValidationRow GetRow(int batchId)
        {
            MrBatchVerificationTDS.BatchValidationRow row = ((MrBatchVerificationTDS.BatchValidationDataTable)Table).FindByBatchID(batchId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation.MrBatchVerification.GetRow");
            }

            return row;
        }


        

    }
}
    