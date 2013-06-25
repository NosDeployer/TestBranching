using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// ProjectTimeJobClassTypeListGateway
    /// </summary>
    public class ProjectTimeJobClassTypeListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTimeJobClassTypeListGateway()
            : base("LFS_PROJECT_TIME_JOB_CLASS_TYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTimeJobClassTypeListGateway(DataSet data)
            : base(data, "LFS_PROJECT_TIME_JOB_CLASS_TYPE")
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
        /// LoadByCountryId
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet LoadByCountryId(int countryId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PROJECTTIMEJOBCLASSTYPELISTGATEWAY_LOADBYCOUNTRYID", new SqlParameter("@countryId", countryId), new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}