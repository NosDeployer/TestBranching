using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkJunctionLiningFlangeGasketListGateway
    /// </summary>
    public class WorkJunctionLiningFlangeGasketListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkJunctionLiningFlangeGasketListGateway()
            : base("LFS_WORK_JUNCTIONLINING_FLANGE_GASKET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkJunctionLiningFlangeGasketListGateway(DataSet data)
            : base(data, "LFS_WORK_JUNCTIONLINING_FLANGE_GASKET")
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
        /// LoadAll
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAll(int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JUNCTIONLININGFLANGEGASKETLISTGATEWAY_LOADALL", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByFlange
        /// </summary>
        /// <param name="flange">flange</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByFlange(string flange, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JUNCTIONLININGFLANGEGASKETLISTGATEWAY_LOADBYFLANGE", new SqlParameter("@flange", flange), new SqlParameter("@companyId", companyId));
            return Data;
        }        



    }
}