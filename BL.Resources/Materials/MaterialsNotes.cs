using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Materials;

namespace LiquiForce.LFSLive.BL.Resources.Materials
{
    /// <summary>
    /// MaterialsNotes
    /// </summary>
    public class MaterialsNotes: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsNotes()
            : base("LFS_RESOURCES_MATERIAL_NOTES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsNotes(DataSet data)
            : base(data, "LFS_RESOURCES_MATERIAL_NOTES")
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
        /// Insert a new materials (direct to DB)
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        /// <param name="subject">subject</param>
        /// <param name="userId">userId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="note">note</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int materialId, int refId, string subject, int userId, DateTime dateTime_, string note, bool deleted, int companyId)
        {
            MaterialsNotesGateway materialsNotesGateway = new MaterialsNotesGateway(null);
            materialsNotesGateway.Insert(materialId, refId, subject, userId, dateTime_, note, deleted, companyId);
        }



        /// <summary>
        /// Update materials (direct to DB)
        /// </summary>
        /// <param name="originalMaterialId">originalMaterialId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalSubject">originalSubject</param>
        /// <param name="originalUserId">originalUserId</param>
        /// <param name="originalDateTime_">originalDateTime_</param>
        /// <param name="originalNote">originalNote</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newMaterialId">newMaterialId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newSubject">newSubject</param>
        /// <param name="newUserId">newUserId</param>
        /// <param name="newDateTime">newDateTime</param>
        /// <param name="newNote">newNote</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalMaterialId, int originalRefId, string originalSubject, int originalUserId, DateTime originalDateTime_, string originalNote, bool originalDeleted, int originalCompanyId, int newMaterialId, int newRefId, string newSubject, int newUserId, DateTime newDateTime, string newNote, bool newDeleted, int newCompanyId)
        {
            MaterialsNotesGateway materialsNotesGateway = new MaterialsNotesGateway(null);
            materialsNotesGateway.Update(originalMaterialId, originalRefId, originalSubject, originalUserId, originalDateTime_, originalNote, originalDeleted, originalCompanyId, newMaterialId, newRefId, newSubject, newUserId, newDateTime, newNote, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int materialId, int refId, int companyId)
        {
            MaterialsNotesGateway materialsNotesGateway = new MaterialsNotesGateway(null);
            materialsNotesGateway.Delete(materialId, refId, companyId);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int materialId, int companyId)
        {
            MaterialsNotesGateway materialsNotesGateway = new MaterialsNotesGateway(null);
            materialsNotesGateway.DeleteAll(materialId, companyId);
        }

    }
}
