using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectSynopsisNote
    /// </summary>
    public class ProjectSynopsisNote : TableModule
    {

        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectSynopsisNote()
            : base("LFS_PROJECT_NOTE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public ProjectSynopsisNote(DataSet data)
            : base(data, "LFS_PROJECT_NOTE")
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
        /// UpdateForReport
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>        
        public void UpdateForReport(int projectId, int companyId)
        {
            // For LFS_PROJECT_NOTE
            // ... for Writer Name
            foreach (ProjectSynopsisReportTDS.LFS_PROJECT_NOTERow row in this.Table.Rows)
            {
                if (row.ProjectID == projectId)
                {                    
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadAllByLoginId(Convert.ToInt32(row.LoginID), companyId);
                    try
                    {
                        row.WrittenBy = loginGateway.GetLastName(Convert.ToInt32(row.LoginID), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(row.LoginID), companyId);
                    }
                    catch
                    {
                        row.WrittenBy = "";
                    }
                }
            }
        }
        
        

    }
}
