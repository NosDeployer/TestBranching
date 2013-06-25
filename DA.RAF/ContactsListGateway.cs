using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.RAF
{
    /// <summary>
    /// ContactsListGateway
    /// </summary>
    public class ContactsListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ContactsListGateway() : base("CONTACTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ContactsListGateway(DataSet data) : base(data, "CONTACTS")
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
            FillDataWithStoredProcedure("LFS_RAF_CONTACTSLISTGATEWAY_LOADALL", new SqlParameter("@companyId", companyId));  
            return Data;
        }

        
        
        /// <summary>
        /// LoadAllByCompaniesId
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAllByCompaniesId(int companiesId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RAF_CONTACTSLISTGATEWAY_LOADALLBYCOMPANIESID", new SqlParameter("@companiesId", companiesId), new SqlParameter("@companyId", companyId)); 
            return Data;
        }



    }
}
