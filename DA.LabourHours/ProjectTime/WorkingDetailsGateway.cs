using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// WorkingDetailsGateway
    /// </summary>
    public class WorkingDetailsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkingDetailsGateway()
            : base("LFS_WORKING_DETAILS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkingDetailsGateway(DataSet data)
            : base(data, "LFS_WORKING_DETAILS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DataSet();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            _adapter = new SqlDataAdapter("", DB.Connection);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <returns>Data</returns>
        public DataSet Load()
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_WORKINGDETAILSGATEWAY_LOAD");
            return Data;
        }



        /// <summary>
        /// LoadActive
        /// </summary>
        /// <returns>Data</returns>
        public DataSet LoadActive()
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_WORKINGDETAILSGATEWAY_LOADACTIVE");
            return Data;
        }



    }
}