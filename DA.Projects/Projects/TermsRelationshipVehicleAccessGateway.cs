using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// TermsRelationshipVehicleAccessGateway
    /// </summary>
    public class TermsRelationshipVehicleAccessGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TermsRelationshipVehicleAccessGateway()
            : base("LFS_PROJECT_TERMS_RELATIONSHIP_VEHICLE_ACCESS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public TermsRelationshipVehicleAccessGateway(DataSet data)
            : base(data, "LFS_PROJECT_TERMS_RELATIONSHIP_VEHICLE_ACCESS")
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
            FillDataWithStoredProcedure("LFS_PROJECTS_TERMSRELATIONSHIPVEHICLEACCESSGATEWAY_LOAD");
            return Data;
        }



    }
}
