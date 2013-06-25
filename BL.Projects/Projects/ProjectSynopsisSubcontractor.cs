using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectSynopsisReport
    /// </summary>
    public class ProjectSynopsisSubcontractor : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectSynopsisSubcontractor()
            : base("LFS_PROJECT_SUBCONTRACTOR")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public ProjectSynopsisSubcontractor(DataSet data)
            : base(data, "LFS_PROJECT_SUBCONTRACTOR")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectSynopsisReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// UpdateForProcess
        /// </summary>
        public void UpdateForReport(int projectId, int companiesId, int companyId)
        {
            CompaniesGateway companiesGateway = new CompaniesGateway();
            companiesGateway.LoadAllByCompaniesId(companiesId, companyId);

            // For LFS_PROJECT_SUBCONTRACTORS
            // ... for subcontractor Name
            foreach (ProjectSynopsisReportTDS.LFS_PROJECT_SUBCONTRACTORRow row in this.Table.Rows)
            {
                if (row.ProjectID == projectId)
                {
                    companiesGateway.LoadAllByCompaniesId((int)row.SubcontractorID, companyId);
                    try
                    {
                        row.Name = companiesGateway.GetName((int)row.SubcontractorID);
                    }
                    catch
                    {
                        row.Name = "";
                    }
                }
            }
        }



    }
}
