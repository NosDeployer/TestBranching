using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    public class ProjectSubcontractor : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectSubcontractor() : base("LFS_PROJECT_SUBCONTRACTOR")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectSubcontractor(DataSet data) : base(data, "LFS_PROJECT_SUBCONTRACTOR")
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
        /// <param name="refId">refId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="writtenQuote">writtenQuote</param>
        /// <param name="surveyedSite">surveyedSite</param>
        /// <param name="workedBefore">workedBefore</param>
        /// <param name="role">role</param>
        /// <param name="agreement">agreement</param>
        /// <param name="issues">issues</param>
        /// <param name="purchaseOrder">purchaseOrder</param>
        /// <param name="insuranceCertificate">insuranceCertificate</param>
        /// <param name="wsib">wsib</param>
        /// <param name="molForm1000">molForm1000</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="royalties">royalties</param>
        public void Insert(int projectId, int refId, int subcontractorId, bool writtenQuote, bool surveyedSite, bool workedBefore, string role, bool agreement, string issues, bool purchaseOrder, bool insuranceCertificate, bool wsib, string molForm1000, bool deleted, int companyId, int? royalties)
        {
            ProjectTDS.LFS_PROJECT_SUBCONTRACTORRow lfsProjectSubcontractorRow = ((ProjectTDS.LFS_PROJECT_SUBCONTRACTORDataTable)Table).NewLFS_PROJECT_SUBCONTRACTORRow();

            lfsProjectSubcontractorRow.ProjectID = projectId;
            lfsProjectSubcontractorRow.RefID = refId;
            lfsProjectSubcontractorRow.SubcontractorID = subcontractorId;
            lfsProjectSubcontractorRow.WrittenQuote = writtenQuote;
            lfsProjectSubcontractorRow.SurveyedSite = surveyedSite;
            lfsProjectSubcontractorRow.WorkedBefore = workedBefore;
            if (role.Trim() != "") lfsProjectSubcontractorRow.Role = role.Trim();
            lfsProjectSubcontractorRow.Agreement = agreement;
            if (issues.Trim() != "") lfsProjectSubcontractorRow.Issues = issues.Trim();
            lfsProjectSubcontractorRow.PurchaseOrder = purchaseOrder;
            lfsProjectSubcontractorRow.InsuranceCertificate = insuranceCertificate;
            lfsProjectSubcontractorRow.WSIB = wsib;
            lfsProjectSubcontractorRow.MOLForm1000 = molForm1000;
            lfsProjectSubcontractorRow.Deleted = deleted;
            lfsProjectSubcontractorRow.COMPANY_ID = companyId;
            if (royalties.HasValue)
            {
                lfsProjectSubcontractorRow.Royalties = (int)royalties;
            }
            else
            {
                lfsProjectSubcontractorRow.SetRoyaltiesNull();
            }

            ((ProjectTDS.LFS_PROJECT_SUBCONTRACTORDataTable)Table).AddLFS_PROJECT_SUBCONTRACTORRow(lfsProjectSubcontractorRow);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="writtenQuote">writtenQuote</param>
        /// <param name="surveyedSite">surveyedSite</param>
        /// <param name="workedBefore">workedBefore</param>
        /// <param name="role">role</param>
        /// <param name="agreement">agreement</param>
        /// <param name="issues">issues</param>
        /// <param name="purchaseOrder">purchaseOrder</param>
        /// <param name="insuranceCertificate">insuranceCertificate</param>
        /// <param name="wsib">wsib</param>
        /// <param name="molForm1000">molForm1000</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="royalties">royalties</param>
        public void Update(int projectId, int refId, int subcontractorId, bool writtenQuote, bool surveyedSite, bool workedBefore, string role, bool agreement, string issues, bool purchaseOrder, bool insuranceCertificate, bool wsib, string molForm1000, bool deleted, int companyId, int? royalties)
        {
            ProjectTDS.LFS_PROJECT_SUBCONTRACTORRow lfsProjectSubcontractorRow = GetRow(projectId, refId);

            lfsProjectSubcontractorRow.SubcontractorID = subcontractorId;
            lfsProjectSubcontractorRow.WrittenQuote = writtenQuote;
            lfsProjectSubcontractorRow.SurveyedSite = surveyedSite;
            lfsProjectSubcontractorRow.WorkedBefore = workedBefore;
            if (role.Trim() != "") lfsProjectSubcontractorRow.Role = role.Trim(); else lfsProjectSubcontractorRow.SetRoleNull();
            lfsProjectSubcontractorRow.Agreement = agreement;
            if (issues.Trim() != "") lfsProjectSubcontractorRow.Issues = issues.Trim(); else lfsProjectSubcontractorRow.SetIssuesNull();
            lfsProjectSubcontractorRow.PurchaseOrder = purchaseOrder;
            lfsProjectSubcontractorRow.InsuranceCertificate = insuranceCertificate;
            lfsProjectSubcontractorRow.WSIB = wsib;
            lfsProjectSubcontractorRow.MOLForm1000 = molForm1000;
            lfsProjectSubcontractorRow.Deleted = deleted;
            lfsProjectSubcontractorRow.COMPANY_ID = companyId;
            if (royalties.HasValue) lfsProjectSubcontractorRow.Royalties = (int)royalties; else lfsProjectSubcontractorRow.SetRoyaltiesNull();
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        public void Delete(int projectId, int refId)
        {
            ProjectTDS.LFS_PROJECT_SUBCONTRACTORRow lfsProjectSubcontractorRow = GetRow(projectId, refId);

            lfsProjectSubcontractorRow.Deleted = true;
        }



        /// <summary>
        /// GetNewRefID
        /// </summary>
        /// <returns></returns>
        public int GetNewRefId()
        {
            int newRefId = 0;

            foreach (ProjectTDS.LFS_PROJECT_SUBCONTRACTORRow row in (ProjectTDS.LFS_PROJECT_SUBCONTRACTORDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectTDS.LFS_PROJECT_SubcontractorRow</returns>
        private ProjectTDS.LFS_PROJECT_SUBCONTRACTORRow GetRow(int projectId, int refId)
        {
            ProjectTDS.LFS_PROJECT_SUBCONTRACTORRow row = ((ProjectTDS.LFS_PROJECT_SUBCONTRACTORDataTable)Table).FindByProjectIDRefID(projectId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectSubcontractor.GetRow");
            }

            return row;

        }



    }
}
