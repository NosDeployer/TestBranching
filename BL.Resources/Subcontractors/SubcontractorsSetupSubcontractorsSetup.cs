using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Subcontractors;

namespace LiquiForce.LFSLive.BL.Resources.Subcontractors
{
    /// <summary>
    /// SubcontractorsSetupSubcontractorsSetup
    /// </summary>
    public class SubcontractorsSetupSubcontractorsSetup: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SubcontractorsSetupSubcontractorsSetup()
            : base("SubcontractorsSetup")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SubcontractorsSetupSubcontractorsSetup(DataSet data)
            : base(data, "SubcontractorsSetup")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SubcontractorsSetupTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadAll
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadAll(int companyId)
        {
            SubcontractorsSetupSubcontractorsSetupGateway subcontractorsSetupSubcontractorsSetupGateway = new SubcontractorsSetupSubcontractorsSetupGateway(Data);
            subcontractorsSetupSubcontractorsSetupGateway.LoadAll(companyId);

            UpdateDataForNavigators();
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Update subcontractors
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        /// <param name="active">active</param>
        public void Update(int companiesId, DateTime date, bool active)
        {
            SubcontractorsSetupTDS.SubcontractorsSetupRow row = GetRow(companiesId, date);
            row.Active = active;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        public void Delete(int companiesId, DateTime date)
        {
            SubcontractorsSetupTDS.SubcontractorsSetupRow row = GetRow(companiesId, date);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all subcontractors to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            SubcontractorsSetupTDS subcontractorSetupChanges = (SubcontractorsSetupTDS)Data.GetChanges();

            if (subcontractorSetupChanges != null)
            {
                if (subcontractorSetupChanges.SubcontractorsSetup.Rows.Count > 0)
                {
                    SubcontractorsSetupSubcontractorsSetupGateway subcontractorsSetupSubcontractorsSetupGateway = new SubcontractorsSetupSubcontractorsSetupGateway(subcontractorSetupChanges);

                    foreach (SubcontractorsSetupTDS.SubcontractorsSetupRow row in (SubcontractorsSetupTDS.SubcontractorsSetupDataTable)subcontractorSetupChanges.SubcontractorsSetup)
                    {
                        //Update subcontractors                   
                        if (!row.Deleted)
                        {
                            int companiesId = row.COMPANIES_ID;
                            DateTime date = row.Date;
                            bool deleted = row.Deleted;

                            // original values
                            bool originalActive = subcontractorsSetupSubcontractorsSetupGateway.GetActiveOriginal(companiesId, date);

                            // new values
                            bool newActive = subcontractorsSetupSubcontractorsSetupGateway.GetActive(companiesId, date);

                            SubcontractorsResoucesSubcontractors subcontractorsResoucesSubcontractors = new SubcontractorsResoucesSubcontractors(null);
                            subcontractorsResoucesSubcontractors.UpdateDirect(companiesId, date, originalActive, row.Udf, deleted, companyId, companiesId, date, newActive, row.Udf, deleted, companyId);
                        }

                        // Delete subcontractors
                        if (row.Deleted)
                        {
                            SubcontractorsResoucesSubcontractors subcontractorsResoucesSubcontractorsDelete = new SubcontractorsResoucesSubcontractors(null);
                            subcontractorsResoucesSubcontractorsDelete.DeleteDirect(row.COMPANIES_ID, row.Date);
                        }
                    }
                }
            }
        }
       
        

        /// <summary>
        /// Get a single catalyst. If not exists, raise an exception
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        /// <returns>SubcontractorsSetupTDS.SubcontractorsSetupRow</returns>
        private SubcontractorsSetupTDS.SubcontractorsSetupRow GetRow(int companiesId, DateTime date)
        {
            SubcontractorsSetupTDS.SubcontractorsSetupRow row = ((SubcontractorsSetupTDS.SubcontractorsSetupDataTable)Table).FindByCOMPANIES_IDDate(companiesId, date);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.Subcontractors.SubcontractorsSetupSubcontractorsSetup.GetRow");
            }

            return row;
        }



        /// <summary>
        /// UpdateDataForNavigators
        /// </summary>
        private void UpdateDataForNavigators()
        {
            foreach (SubcontractorsSetupTDS.SubcontractorsSetupRow row in (SubcontractorsSetupTDS.SubcontractorsSetupDataTable)Table)
            {
                row.DateString = row.Date.ToString();
            }
        }
        


    }
}