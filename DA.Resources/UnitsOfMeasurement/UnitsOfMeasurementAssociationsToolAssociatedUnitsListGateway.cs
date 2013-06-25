using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement
{
    /// <summary>
    /// UnitsOfMeasurementAssociationsToolAssociatedUnitsListGateway
    /// </summary>
    public class UnitsOfMeasurementAssociationsToolAssociatedUnitsListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsOfMeasurementAssociationsToolAssociatedUnitsListGateway()
            : base("LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsOfMeasurementAssociationsToolAssociatedUnitsListGateway(DataSet data)
            : base(data, "LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS")
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
            FillDataWithStoredProcedure("LFS_RESOURCES_UNITSOFMEASUREMENTASSOCIATIONSTOOLASSOCIATEDUNITSLISTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByModule
        /// </summary>       
        /// <param name="module">module</param>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet LoadByModule(string module, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_UNITSOFMEASUREMENTASSOCIATIONSTOOLASSOCIATEDUNITSLISTGATEWAY_LOADBYMODULE", new SqlParameter("@module", module), new SqlParameter("@companyId", companyId));
            return Data;
        }

    }
}
