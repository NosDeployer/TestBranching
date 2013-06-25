using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectEngineerSubcontractors
    /// </summary>
    public class ProjectEngineerSubcontractors : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectEngineerSubcontractors() : base("LFS_PROJECT_ENGINEER_SUBCONTRACTORS")
        {
        }




        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectEngineerSubcontractors(DataSet data) : base(data, "LFS_PROJECT_ENGINEER_SUBCONTRACTORS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="generalContractor">generalContractor</param>
        /// <param name="generalWSIB">generalWSIB</param>
        /// <param name="generalInsuranceCertificate">generalInsuranceCertificate</param>
        /// <param name="generalBondingSupplied">generalBondingSupplied</param>
        /// <param name="generalMOLForm">generalMOLForm</param>
        /// <param name="generalNoticeProject">generalNoticeProject</param>
        /// <param name="generalForm1000">generalForm1000</param>
        /// <param name="engineeringFirmId">engineeringFirmId</param>
        /// <param name="engineerId">engineerId</param>
        /// <param name="engineerNumber">engineerNumber</param>
        /// <param name="subcontractorUsed">subcontractorUsed</param>
        /// <param name="companyId">companyId</param>
        /// <param name="bondNumber">bondNumber</param>
        public void Insert(int projectId, bool generalContractor, bool generalWSIB, bool generalInsuranceCertificate, string generalBondingSupplied, string generalMOLForm, bool generalNoticeProject, bool generalForm1000, int? engineeringFirmId, int? engineerId, string engineerNumber, bool subcontractorUsed, int companyId, string bondNumber)
        {
            ProjectTDS.LFS_PROJECT_ENGINEER_SUBCONTRACTORSRow lfsProjectEngineerSubcontractorsRow = ((ProjectTDS.LFS_PROJECT_ENGINEER_SUBCONTRACTORSDataTable)Table).NewLFS_PROJECT_ENGINEER_SUBCONTRACTORSRow();
            lfsProjectEngineerSubcontractorsRow.ProjectID = projectId;
            lfsProjectEngineerSubcontractorsRow.GeneralContractor = generalContractor;
            lfsProjectEngineerSubcontractorsRow.GeneralWSIB = generalWSIB;
            lfsProjectEngineerSubcontractorsRow.GeneralInsuranceCertificate = generalInsuranceCertificate;
            if (generalBondingSupplied.Trim() != "") lfsProjectEngineerSubcontractorsRow.GeneralBondingSupplied = generalBondingSupplied.Trim();
            if (generalMOLForm.Trim() != "") lfsProjectEngineerSubcontractorsRow.GeneralMOLForm = generalMOLForm.Trim();
            lfsProjectEngineerSubcontractorsRow.GeneralNoticeProject = generalNoticeProject;
            lfsProjectEngineerSubcontractorsRow.GeneralForm1000 = generalForm1000;
            if (engineeringFirmId.HasValue) lfsProjectEngineerSubcontractorsRow.EngineeringFirmID = (int)engineeringFirmId;
            if (engineerId.HasValue) lfsProjectEngineerSubcontractorsRow.EngineerID = (int)engineerId;
            if (engineerNumber.Trim() != "") lfsProjectEngineerSubcontractorsRow.EngineerNumber = engineerNumber.Trim();
            lfsProjectEngineerSubcontractorsRow.SubcontractorUsed = subcontractorUsed;
            lfsProjectEngineerSubcontractorsRow.COMPANY_ID = companyId;
            if (bondNumber.Trim() != "") lfsProjectEngineerSubcontractorsRow.BondNumber = bondNumber.Trim(); 
            ((ProjectTDS.LFS_PROJECT_ENGINEER_SUBCONTRACTORSDataTable)Table).AddLFS_PROJECT_ENGINEER_SUBCONTRACTORSRow(lfsProjectEngineerSubcontractorsRow);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="generalContractor">generalContractor</param>
        /// <param name="generalWSIB">generalWSIB</param>
        /// <param name="generalInsuranceCertificate">generalInsuranceCertificate</param>
        /// <param name="generalBondingSupplied">generalBondingSupplied</param>
        /// <param name="generalMOLForm">generalMOLForm</param>
        /// <param name="generalNoticeProject">generalNoticeProject</param>
        /// <param name="generalForm1000">generalForm1000</param>
        /// <param name="engineeringFirmId">engineeringFirmId</param>
        /// <param name="engineerId">engineerId</param>
        /// <param name="engineerNumber">engineerNumber</param>
        /// <param name="subcontractorUsed">subcontractorUsed</param>
        /// <param name="companyId">companyId</param>
        /// <param name="bondNumber">bondNumber</param>
        //public void Update(int projectId, bool generalContractor, bool generalWSIB, bool generalInsuranceCertificate, string generalBondingSupplied, string generalMOLForm, bool generalNoticeProject, bool generalForm1000, int? engineeringFirmId, int? engineerId, string engineerNumber, bool subcontractorUsed, int companyId, string bondNumber)
        public void Update(int projectId, bool generalContractor, bool generalWSIB, bool generalInsuranceCertificate, string generalBondingSupplied,  bool subcontractorUsed, int companyId, string bondNumber)
        {
            ProjectTDS.LFS_PROJECT_ENGINEER_SUBCONTRACTORSRow lfsProjectEngineerSubcontractorsRow = GetRow(projectId);

            lfsProjectEngineerSubcontractorsRow.GeneralContractor = generalContractor;
            lfsProjectEngineerSubcontractorsRow.GeneralWSIB = generalWSIB;
            lfsProjectEngineerSubcontractorsRow.GeneralInsuranceCertificate = generalInsuranceCertificate;
            if (generalBondingSupplied.Trim() != "") lfsProjectEngineerSubcontractorsRow.GeneralBondingSupplied = generalBondingSupplied.Trim();
            //if (generalMOLForm.Trim() != "") lfsProjectEngineerSubcontractorsRow.GeneralMOLForm = generalMOLForm.Trim();
            //lfsProjectEngineerSubcontractorsRow.GeneralNoticeProject = generalNoticeProject;
            //lfsProjectEngineerSubcontractorsRow.GeneralForm1000 = generalForm1000;
            //if (engineeringFirmId.HasValue) lfsProjectEngineerSubcontractorsRow.EngineeringFirmID = (int)engineeringFirmId; else lfsProjectEngineerSubcontractorsRow.SetEngineeringFirmIDNull();
            //if (engineerId.HasValue) lfsProjectEngineerSubcontractorsRow.EngineerID = (int)engineerId; else lfsProjectEngineerSubcontractorsRow.SetEngineerIDNull();
            //if (engineerNumber.Trim() != "") lfsProjectEngineerSubcontractorsRow.EngineerNumber = engineerNumber.Trim(); else lfsProjectEngineerSubcontractorsRow.SetEngineerNumberNull();
            lfsProjectEngineerSubcontractorsRow.SubcontractorUsed = subcontractorUsed;
            lfsProjectEngineerSubcontractorsRow.COMPANY_ID = companyId;
            if (bondNumber.Trim() != "") lfsProjectEngineerSubcontractorsRow.BondNumber = bondNumber.Trim();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ProjectTDS.LFS_PROJECT_SALE:BILLING_PRICINGRow</returns>
        private ProjectTDS.LFS_PROJECT_ENGINEER_SUBCONTRACTORSRow GetRow(int projectId)
        {
            ProjectTDS.LFS_PROJECT_ENGINEER_SUBCONTRACTORSRow row = ((ProjectTDS.LFS_PROJECT_ENGINEER_SUBCONTRACTORSDataTable)Table).FindByProjectID(projectId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectEngineerSubcontractors.GetRow");
            }

            return row;

        }



    }
}
