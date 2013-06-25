using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;


namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// ProjectTimeWorkGateway
    /// </summary>
    public class ProjectTimeWorkListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTimeWorkListGateway()
            : base("LFS_PROJECT_TIME_WORK")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTimeWorkListGateway(DataSet data)
            : base(data, "LFS_PROJECT_TIME_WORK")
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
        /// <returns> Data </returns>
        public DataSet Load()
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PROJECTTIMEWORKLISTGATEWAY_LOAD");
            return Data;
        }



        /// <summary>
        /// LoadByWork
        /// </summary>
        /// <param name="workId">work_</param>
        /// <returns> Data </returns>
        public DataSet LoadByWork(string work_)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PROJECTTIMEWORKLISTGATEWAY_LOADWORK", new SqlParameter("@work_", work_));
            return Data;
        }
    }
}
