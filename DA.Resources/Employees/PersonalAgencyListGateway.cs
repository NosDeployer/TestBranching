using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// PersonalAgencyListGateway
    /// </summary>
    public class PersonalAgencyListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PersonalAgencyListGateway()
            : base("LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PersonalAgencyListGateway(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES")
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
        public DataSet Load()
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_PERSONALAGENCYLISTGATEWAY_LOAD");
            return Data;
        }
             

    
    }
}