using System;
using System.Data;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement;
using LiquiForce.LFSLive.BL.Common;

namespace LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement
{
    /// <summary>
    /// UnitsOfMeasurementAssociations
    /// </summary>
    public class UnitsOfMeasurementAssociations : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsOfMeasurementAssociations()
            : base("LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsOfMeasurementAssociations(DataSet data)
            : base(data, "LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS")
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
        /// Insert an association (direct to DB)
        /// </summary>
        /// <param name="associationsId">associationsId</param>
        /// <param name="unitOfMeasurementId">unitOfMeasurementId</param>       
        /// <param name="module">module</param>
        /// <param name="byDefault">byDefault</param>
        /// <param name="deleted">deleted</param>        
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int associationsId, int unitOfMeasurementId, string module, bool byDefault, bool deleted, int companyId)
        {
            UnitsOfMeasurementAssociationsGateway unitsOfMeasurementAssociationsGateway = new UnitsOfMeasurementAssociationsGateway(null);
            unitsOfMeasurementAssociationsGateway.Insert(associationsId, unitOfMeasurementId, module, byDefault, deleted, companyId);
        }



        /// <summary>
        /// Update an association (direct to DB)
        /// </summary>
        /// <param name="originalAssociationsId">originalAssociationsId</param>
        /// <param name="originalUnitOfMeasurementId">originalUnitOfMeasurementId</param>       
        /// <param name="originalModule">originalModule</param>
        /// <param name="originalByDefault">originalByDefault</param>
        /// <param name="originalDeleted">originalDeleted</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        ///
        /// <param name="newAssociationsId">newAssociationsId</param>
        /// <param name="newUnitOfMeasurementId">newUnitOfMeasurementId</param>
        /// <param name="newModule">newModule</param>
        /// <param name="newByDefault">newByDefault</param>
        /// <param name="newDeleted">newDeleted</param>        
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalAssociationsId, int originalUnitOfMeasurementId, string originalModule, bool originalByDefault, bool originalDeleted, int originalCompanyId, int newAssociationsId, int newUnitOfMeasurementId, string newModule, bool newByDefault, bool newDeleted, int newCompanyId)
        {
            UnitsOfMeasurementAssociationsGateway unitsOfMeasurementAssociationsGateway = new UnitsOfMeasurementAssociationsGateway(null);
            unitsOfMeasurementAssociationsGateway.Update(originalAssociationsId, originalUnitOfMeasurementId, originalModule, originalByDefault, originalDeleted, originalCompanyId, newAssociationsId, newUnitOfMeasurementId, newModule, newByDefault, newDeleted, newCompanyId);
        }       



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="originalAssociationsId">originalAssociationsId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int originalAssociationsId, int companyId)
        {
            UnitsOfMeasurementAssociationsGateway unitsOfMeasurementAssociationsGateway = new UnitsOfMeasurementAssociationsGateway(null);
            unitsOfMeasurementAssociationsGateway.Delete(originalAssociationsId, companyId);
        }

    }
}
