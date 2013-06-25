using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Section
{
    /// <summary>
    /// SectionMHGateway
    /// </summary>
    public class SectionMHGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SectionMHGateway()
            : base("LFS_MASTER_AREA")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SectionMHGateway(DataSet data)
            : base(data, "LFS_MASTER_AREA")
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
        /// LoadUSMHMNById
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="id">id</param>
        /// <returns>Data</returns>
        public DataSet LoadUSMHMNById(int companyId, Guid id)
        {
            FillDataWithStoredProcedure("LFS_CWP_SECTIONUSMHMNGATEWAY_LOADBYID", new SqlParameter("@companyId", companyId), new SqlParameter("@id", id));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadDSMHMNById
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="id">id</param>
        /// <returns>Data</returns>
        public DataSet LoadDSMHMNById(int companyId, Guid id)
        {
            FillDataWithStoredProcedure("LFS_CWP_SECTIONDSMHMNGATEWAY_LOADBYID", new SqlParameter("@companyId", companyId), new SqlParameter("@id", id));//Note: COMPANY_ID
            return Data;
        }



    }
}
