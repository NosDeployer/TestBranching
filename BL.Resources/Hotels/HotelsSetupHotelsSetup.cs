using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Hotels;

namespace LiquiForce.LFSLive.BL.Resources.Hotels
{
    /// <summary>
    /// HotelsSetupHotelsSetup
    /// </summary>
    public class HotelsSetupHotelsSetup : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public HotelsSetupHotelsSetup()
            : base("HotelsSetup")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public HotelsSetupHotelsSetup(DataSet data)
            : base(data, "HotelsSetup")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new HotelsSetupTDS();
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
            HotelsSetupHotelsSetupGateway hotelsSetupHotelsSetupGateway = new HotelsSetupHotelsSetupGateway(Data);
            hotelsSetupHotelsSetupGateway.LoadAll(companyId);

            UpdateDataForNavigators();
        }



        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Load(int companyId)
        {
            HotelsSetupHotelsSetupGateway hotelsSetupHotelsSetupGateway = new HotelsSetupHotelsSetupGateway(Data);
            hotelsSetupHotelsSetupGateway.Load(companyId);

            UpdateDataForNavigators();
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
                
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        public void Delete(int companiesId, DateTime date)
        {
            HotelsSetupTDS.HotelsSetupRow row = GetRow(companiesId, date);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all hotels to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            HotelsSetupTDS hotelsSetupChanges = (HotelsSetupTDS)Data.GetChanges();

            if (hotelsSetupChanges != null)
            {
                if (hotelsSetupChanges.HotelsSetup.Rows.Count > 0)
                {
                    HotelsSetupHotelsSetupGateway hotelsSetupHotelsSetupGateway = new HotelsSetupHotelsSetupGateway(hotelsSetupChanges);

                    foreach (HotelsSetupTDS.HotelsSetupRow row in (HotelsSetupTDS.HotelsSetupDataTable)hotelsSetupChanges.HotelsSetup)
                    {                       
                        // Delete hotels
                        if (row.Deleted)
                        {
                            Hotels hotels = new Hotels(null);
                            hotels.DeleteDirect(row.COMPANIES_ID, row.Date);
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
        /// <returns>HotelsSetupTDS.HotelsSetupRow</returns>
        private HotelsSetupTDS.HotelsSetupRow GetRow(int companiesId, DateTime date)
        {
            HotelsSetupTDS.HotelsSetupRow row = ((HotelsSetupTDS.HotelsSetupDataTable)Table).FindByCOMPANIES_IDDate(companiesId, date);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.Hotels.HotelsSetupHotelsSetup.GetRow");
            }

            return row;
        }



        /// <summary>
        /// UpdateDataForNavigators
        /// </summary>
        private void UpdateDataForNavigators()
        {
            foreach (HotelsSetupTDS.HotelsSetupRow row in (HotelsSetupTDS.HotelsSetupDataTable)Table)
            {
                row.DateString = row.Date.ToString();
            }
        }



    }
}