using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.RAF
{
    /// <summary>
    /// UserListGateway
    /// </summary>
    public class UserListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UserListGateway() : base("USER")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        public UserListGateway(DataSet data) : base(data, "USER")
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
            FillDataWithStoredProcedure("LFS_RAF_USERLISTGATEWAY_LOAD", new SqlParameter("@companyId", 3));//Note: COMPANY_ID
            return Data;
        }



    }
}
