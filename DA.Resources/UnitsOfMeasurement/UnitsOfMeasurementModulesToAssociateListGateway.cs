using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement
{
    /// <summary>
    /// UnitsOfMeasurementModulesToAssociateListGateway
    /// </summary>
    public class UnitsOfMeasurementModulesToAssociateListGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsOfMeasurementModulesToAssociateListGateway()
            : base("LFS_RESOURCES_UNITS_OF_MEASUREMENT_MODULES_TO_ASSOCIATE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsOfMeasurementModulesToAssociateListGateway(DataSet data)
            : base(data, "LFS_RESOURCES_UNITS_OF_MEASUREMENT_MODULES_TO_ASSOCIATE")
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
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_UNITSOFMEASUREMENTMODULESTOASSOCIATELISTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }


    }
}
