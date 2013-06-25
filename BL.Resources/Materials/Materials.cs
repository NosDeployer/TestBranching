using System;
using System.Data;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.Materials;
using LiquiForce.LFSLive.BL.Common;

namespace LiquiForce.LFSLive.BL.Resources.Materials
{
    /// <summary>
    /// Materials
    /// </summary>
    public class Materials: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Materials()
            : base("LFS_RESOURCES_MATERIAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Materials(DataSet data)
            : base(data, "LFS_RESOURCES_MATERIAL")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MaterialsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //
        
        /// <summary>
        /// Insert a new material (direct to DB)
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="description">description</param>
        /// <param name="size">size</param>
        /// <param name="length">length</param>
        /// <param name="thickness">thickness</param>
        /// <param name="type">type</param>
        /// <param name="state">state</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int materialId, string description, string size, string length, string thickness, string type, string state, bool deleted, int companyId)
        {
            MaterialsGateway materialsGateway = new MaterialsGateway(null);
            materialsGateway.Insert(materialId, description, size, length, thickness, type, state, deleted, companyId);
        }



        /// <summary>
        /// Update material (direct to DB)
        /// </summary>
        /// <param name="originalMaterialId">originalMaterialId</param>       
        /// <param name="originalDescription">originalDescription</param>
        /// <param name="originalSize">originalSize</param>
        /// <param name="originalLength">originalLength</param>
        /// <param name="originalThickness">originalThickness</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalDeleted">originalDeleted</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        ///
        /// <param name="newDescription">newDescription</param>
        /// <param name="newSize">newSize</param>
        /// <param name="newLength">newLength</param>
        /// <param name="newThickness">newThickness</param>
        /// <param name="newType">newType</param>
        /// <param name="newState">newState</param>
        /// <param name="newDeleted">newDeleted</param>        
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalMaterialId, string originalDescription, string originalSize, string originalLength, string originalThickness, string originalType, string originalState, bool originalDeleted, int originalCompanyId, int newMaterialId, string newDescription, string newSize, string newLength, string newThickness, string newType, string newState, bool newDeleted, int newCompanyId)
        {
            MaterialsGateway materialsGateway = new MaterialsGateway(null);
            materialsGateway.Update(originalMaterialId, originalDescription, originalSize, originalLength, originalThickness, originalType, originalState, originalDeleted, originalCompanyId, newMaterialId, newDescription, newSize, newLength, newThickness, newType, newState, newDeleted, newCompanyId);
        }       



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="originalMaterialId">originalMaterialId</param>
        public void DeleteDirect(int originalMaterialId)
        {
            MaterialsGateway materialsGateway = new MaterialsGateway(null);
            materialsGateway.Delete(originalMaterialId);
        }


    }
}
