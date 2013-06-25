using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.Resources.Materials;

namespace LiquiForce.LFSLive.BL.Resources.Materials
{
    /// <summary>
    /// MaterialsAdd
    /// </summary>
    public class MaterialsAdd: TableModule
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsAdd()
            : base("MaterialAdd")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsAdd(DataSet data)
            : base(data, "MaterialAdd")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MaterialsAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new material
        /// </summary>
        /// <param name="description">description</param>
        /// <param name="size">size</param>
        /// <param name="length">length</param>
        /// <param name="thickness">thickness</param>
        /// <param name="type">type</param>
        /// <param name="state">state</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDataBase">inDataBase</param>
        /// <returns>materialId</returns>
        public int Insert( string description, string size, string length, string thickness, string type, string state, bool deleted, int companyId, bool inDataBase)
        {
            MaterialsAddTDS.MaterialAddRow row = ((MaterialsAddTDS.MaterialAddDataTable)Table).NewMaterialAddRow();

            row.MaterialID = GetNewMaterialId();            
            row.Description = description;
            if (size != "") row.Size = size; else row.SetSizeNull();
            if (length != "")  row.Length = length; else row.SetLengthNull();
            if (thickness != "") row.Thickness = thickness; else row.SetThicknessNull();
            row.Type = type;            
            row.State = state;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDataBase;

            ((MaterialsAddTDS.MaterialAddDataTable)Table).AddMaterialAddRow(row);

            return row.MaterialID;
        }



        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            MaterialsAddTDS materialsAddChanges = (MaterialsAddTDS)Data.GetChanges();

            if (materialsAddChanges != null)
            {
                if (materialsAddChanges.MaterialAdd.Rows.Count > 0)
                {
                    MaterialsAddGateway materialsNavigatorGateway = new MaterialsAddGateway(materialsAddChanges);

                    // Update materials
                    foreach (MaterialsAddTDS.MaterialAddRow row in (MaterialsAddTDS.MaterialAddDataTable)materialsAddChanges.MaterialAdd)
                    {
                        // Insert new materials 
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            Materials material = new Materials(null);
                            int materialId = row.MaterialID;
                            string description = row.Description;
                            string size = ""; if(!row.IsSizeNull()) size = row.Size;
                            string length = ""; if (!row.IsLengthNull()) length = row.Length;
                            string thickness = ""; if (!row.IsThicknessNull()) thickness = row.Thickness;
                            string type = row.Type;
                            string state = row.State;
                            bool deleted = row.Deleted;
                            int companyId = row.COMPANY_ID;

                            material.InsertDirect(materialId, description, size, length, thickness, type, state, deleted, companyId);
                        }                      
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
        /// <summary>
        /// GetNewMaterialId
        /// </summary>
        /// <returns>New ID</returns>
        private int GetNewMaterialId()
        {
            int newMaterialId = 0;

            foreach (MaterialsAddTDS.MaterialAddRow row in (MaterialsAddTDS.MaterialAddDataTable)Table)
            {
                if (newMaterialId < row.MaterialID)
                {
                    newMaterialId = row.MaterialID;
                }
            }

            newMaterialId++;

            return newMaterialId;
        }
    }
}

