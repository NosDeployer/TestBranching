using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Materials;

namespace LiquiForce.LFSLive.BL.Resources.Materials
{
    /// <summary>
    /// MaterialsInformationBasicInformation
    /// </summary>
    public class MaterialsInformationBasicInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsInformationBasicInformation()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsInformationBasicInformation(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MaterialsInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByMaterialId
        /// </summary>
        /// <param name="materialId">materialId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadByMaterialId(int materialId, int companyId)
        {
            MaterialsInformationBasicInformationGateway materialsInformationBasicInformationGateway = new MaterialsInformationBasicInformationGateway(Data);
            materialsInformationBasicInformationGateway.LoadByMaterialId(materialId, companyId);
        }



        /// <summary>
        /// Update
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
        public void Update(int materialId, string description, string size, string length, string thickness, string type, string state, bool deleted, int companyId)
        {
            MaterialsInformationTDS.BasicInformationRow row = GetRow(materialId);
 
            // General Data            
            row.Description = description;
            row.Size = size;
            if (length != "") row.Length = length; else row.SetLengthNull();
            if (thickness != "") row.Thickness = thickness; else row.SetThicknessNull();
            row.Type = type;
            row.State = state;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;            
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="materialId">materialId</param>
        public void Delete(int materialId)
        {
            MaterialsInformationTDS.BasicInformationRow row = GetRow(materialId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="materialId">materialId</param>        
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int materialId, int companyId)
        {
            // Delete notes
            MaterialsNotes materialsNotes = new MaterialsNotes(null);
            materialsNotes.DeleteAllDirect(materialId, companyId);

            // Delete costs
            MaterialsCostHistory materialsCostHistory = new MaterialsCostHistory(null);
            materialsCostHistory.DeleteAllDirect(materialId, companyId);

            // Delete materials
            Materials materials = new Materials(null);
            materials.DeleteDirect(materialId);
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            MaterialsInformationTDS materialsInformationChanges = (MaterialsInformationTDS)Data.GetChanges();

            if (materialsInformationChanges.BasicInformation.Rows.Count > 0)
            {
                MaterialsInformationBasicInformationGateway materialsInformationBasicInformationGateway = new MaterialsInformationBasicInformationGateway(materialsInformationChanges);

                // Update services
                foreach (MaterialsInformationTDS.BasicInformationRow basicInformationRow in (MaterialsInformationTDS.BasicInformationDataTable)materialsInformationChanges.BasicInformation)
                {
                    // Unchanged values
                    int materialId = basicInformationRow.MaterialID;
                    bool deleted = basicInformationRow.Deleted;                    

                    // Original values
                    string originalDescription = materialsInformationBasicInformationGateway.GetDescriptionOriginal(materialId);
                    string originalSize = materialsInformationBasicInformationGateway.GetSizeOriginal(materialId);
                    string originalLength = materialsInformationBasicInformationGateway.GetLengthOriginal(materialId);
                    string originalThickness = materialsInformationBasicInformationGateway.GetThicknessOriginal(materialId);
                    string originalType = materialsInformationBasicInformationGateway.GetTypeOriginal(materialId);
                    string originalState = materialsInformationBasicInformationGateway.GetStateOriginal(materialId);
                                       
                    // New variables
                    string newDescription = materialsInformationBasicInformationGateway.GetDescription(materialId);
                    string newSize = materialsInformationBasicInformationGateway.GetSize(materialId);
                    string newLength = materialsInformationBasicInformationGateway.GetLength(materialId);
                    string newThickness = materialsInformationBasicInformationGateway.GetThickness(materialId);
                    string newType = materialsInformationBasicInformationGateway.GetType(materialId);
                    string newState = materialsInformationBasicInformationGateway.GetState(materialId);                    

                    // ... Update 
                    Materials materials = new Materials(null);
                    materials.UpdateDirect(materialId, originalDescription, originalSize, originalLength, originalThickness, originalType, originalState, deleted, companyId, materialId, newDescription, newSize, newLength, newThickness, newType, newState, deleted, companyId);                                                            
                }
            }
        }



        

                
        //// ////////////////////////////////////////////////////////////////////////
        //// PRIVATE METHODS
        ////   

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Obtained row</returns>
        private MaterialsInformationTDS.BasicInformationRow GetRow(int materialId)
        {
            MaterialsInformationTDS.BasicInformationRow row = ((MaterialsInformationTDS.BasicInformationDataTable)Table).FindByMaterialID(materialId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.Materials.MaterialsInformationBasicInformation.GetRow");
            }

            return row;
        }


    }
}