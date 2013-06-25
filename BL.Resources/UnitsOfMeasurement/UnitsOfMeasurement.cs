using System;
using System.Data;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement;
using LiquiForce.LFSLive.BL.Common;

namespace LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement
{
    /// <summary>
    /// UnitsOfMeasurement
    /// </summary>
    public class UnitsOfMeasurement: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsOfMeasurement()
            : base("LFS_RESOURCES_UNITS_OF_MEASUREMENT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsOfMeasurement(DataSet data)
            : base(data, "LFS_RESOURCES_UNITS_OF_MEASUREMENT")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsOfMeasurementTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //
        
        /// <summary>
        /// Insert a new unit of measurement (direct to DB)
        /// </summary>
        /// <param name="unitOfMeasurementId">unitOfMeasurementId</param>       
        /// <param name="description">description</param>
        /// <param name="abreviation">abreviation</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int unitOfMeasurementId, string description, string abreviation, bool deleted, int companyId)
        {
            UnitsOfMeasurementGateway unitsOfMeasurementGateway = new UnitsOfMeasurementGateway(null);
            unitsOfMeasurementGateway.Insert(unitOfMeasurementId, description, abreviation, deleted, companyId);
        }



        /// <summary>
        /// Update unit of measurement (direct to DB)
        /// </summary>
        /// <param name="originalUnitOfMeasurementId">originalUnitOfMeasurementId</param>       
        /// <param name="originalDescription">originalDescription</param>
        /// <param name="originalAbbreviation">originalAbbreviation</param>
        /// <param name="originalDeleted">originalDeleted</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        ///
        /// <param name="newDescription">newDescription</param>
        /// <param name="newAbbreviation">newAbbreviation</param>
        /// <param name="newDeleted">newDeleted</param>        
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalUnitOfMeasurementId, string originalDescription, string originalAbbreviation, bool originalDeleted, int originalCompanyId, int newUnitOfMeasurementId, string newDescription, string newAbbreviation, bool newDeleted, int newCompanyId)
        {
            UnitsOfMeasurementGateway unitsOfMeasurementGateway = new UnitsOfMeasurementGateway(null);
            unitsOfMeasurementGateway.Update(originalUnitOfMeasurementId, originalDescription, originalAbbreviation, originalDeleted, originalCompanyId, newUnitOfMeasurementId, newDescription, newAbbreviation, newDeleted, newCompanyId);
        }       



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="originalUnitOfMeasurementId">originalUnitOfMeasurementId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int originalUnitOfMeasurementId, int companyId)
        {
            UnitsOfMeasurementGateway unitsOfMeasurementGateway = new UnitsOfMeasurementGateway(null);
            unitsOfMeasurementGateway.Delete(originalUnitOfMeasurementId, companyId);
        }


    }
}
