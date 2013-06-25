using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectHistory
    /// </summary>
    public class ProjectHistory : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectHistory() : base("LFS_PROJECT_HISTORY")
        {
        }

        


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectHistory(DataSet data)
            : base(data, "LFS_PROJECT_HISTORY")
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
        /// <param name="projectId">ProjectId</param>
        /// <param name="refId">RefId</param>
        /// <param name="projectState">Project State</param>
        /// <param name="date_">Date_</param>
        /// <param name="loginId">LoginId</param>
        /// <param name="companyId"></param>
        public void Insert(int projectId, int refId, string projectState, DateTime date_, int loginId, int companyId)
        {
            // Insert new project
            ProjectTDS.LFS_PROJECT_HISTORYRow projectHistoryRow = ((ProjectTDS.LFS_PROJECT_HISTORYDataTable)Table).NewLFS_PROJECT_HISTORYRow();
            projectHistoryRow.ProjectID = projectId;
            projectHistoryRow.RefID = refId;
            projectHistoryRow.ProjectState = projectState;
            projectHistoryRow.Date_ = DateTime.Parse(date_.ToShortDateString());
            projectHistoryRow.LoginID = loginId;
            projectHistoryRow.COMPANY_ID = companyId;

            ((ProjectTDS.LFS_PROJECT_HISTORYDataTable)Table).AddLFS_PROJECT_HISTORYRow(projectHistoryRow);
        }



        /// <summary>
        /// GetNewRefID
        /// </summary>
        /// <returns></returns>
        public int GetNewRefId()
        {
            int newRefId = 0;

            foreach (ProjectTDS.LFS_PROJECT_HISTORYRow row in (ProjectTDS.LFS_PROJECT_HISTORYDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }
    }
}
