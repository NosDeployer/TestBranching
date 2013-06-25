using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Hotels;

namespace LiquiForce.LFSLive.BL.Resources.Hotels
{
    /// <summary>
    /// Hotels
    /// </summary>
    public class Hotels: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Hotels()
            : base("LFS_RESOURCES_HOTELS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Hotels(DataSet data)
            : base(data, "LFS_RESOURCES_HOTELS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new HotelsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        /// <param name="name">name</param>
        /// <param name="active">active</param>        
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int companiesId, DateTime date, string name, bool deleted, int companyId)
        {
            HotelsGateway hotelsGateway = new HotelsGateway(null);
            hotelsGateway.Insert(companiesId, date, name, deleted, companyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        public void DeleteDirect(int companiesId, DateTime date)
        {
            // Delete comments
            HotelsGateway hotelsGateway = new HotelsGateway(null);
            hotelsGateway.Delete(companiesId, date);
        }
    }
}