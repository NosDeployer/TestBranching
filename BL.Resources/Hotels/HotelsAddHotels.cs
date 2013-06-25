using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Hotels;

namespace LiquiForce.LFSLive.BL.Resources.Hotels
{
    /// <summary>
    /// HotelsAddHotels
    /// </summary>
    public class HotelsAddHotels: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public HotelsAddHotels()
            : base("Hotels")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public HotelsAddHotels(DataSet data)
            : base(data, "Hotels")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new HotelsAddTDS();
        }






        //// ////////////////////////////////////////////////////////////////////////
        //// PRIVATE METHODS
        ////

        /// <summary>
        /// Insert Hotels
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="deleted">deleted</param>
        public void Insert(int companiesId, DateTime date, string name, bool deleted, int companyId)
        {
            HotelsAddTDS.HotelsRow row = ((HotelsAddTDS.HotelsDataTable)Table).NewHotelsRow();
            row.COMPANIES_ID = companiesId;
            row.Date = date;
            row.Name = name;            
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;

            ((HotelsAddTDS.HotelsDataTable)Table).AddHotelsRow(row);
        }






        //// ////////////////////////////////////////////////////////////////////////
        //// PRIVATE METHODS
        ////
               
        /// <summary>
        /// Save all bondingCompanies to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            HotelsAddTDS hotelsChanges = (HotelsAddTDS)Data.GetChanges();

            if (hotelsChanges.Hotels.Rows.Count > 0)
            {
                HotelsAddHotelsGateway hotelsAddHotelsGateway = new HotelsAddHotelsGateway(hotelsChanges);

                foreach (HotelsAddTDS.HotelsRow row in (HotelsAddTDS.HotelsDataTable)hotelsChanges.Hotels)
                {
                    //Insert companies                   
                    Hotels hotels = new Hotels(null);
                    hotels.InsertDirect(row.COMPANIES_ID, row.Date, row.Name,  row.Deleted, row.COMPANY_ID);                    
                }
            }
        }



        /// <summary>
        /// Get a single hotels. If not exists, raise an exception
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        /// <returns>HotelsAddTDS.HotelsRow</returns>
        private HotelsAddTDS.HotelsRow GetRow(int companiesId, DateTime date)
        {
            HotelsAddTDS.HotelsRow row = ((HotelsAddTDS.HotelsDataTable)Table).FindByCOMPANIES_IDDate(companiesId, date);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.Hotels.HotelsAddHotels.GetRow");
            }

            return row;
        }


    }
}
