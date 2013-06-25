using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// ProjectTimeSectionTemp
    /// </summary>
    public class ProjectTimeSectionTemp : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTimeSectionTemp()
            : base("LFS_PROJECT_TIME_SECTION_TEMP")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTimeSectionTemp(DataSet data)
            : base(data, "LFS_PROJECT_TIME_SECTION_TEMP")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTimeTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="flowOrderId">flowOrderId</param>
        /// <param name="completed">completed</param>
        /// <param name="date_">date_</param>
        /// <param name="percentageOpened">percentageOpened</param>
        /// <param name="percentageBrushed">percentageBrushed</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int projectTimeId, string sectionId, string flowOrderId, bool completed, DateTime date_, int percentageOpened, int percentageBrushed, bool deleted, int companyId)
        {
            // Insert new project time
            ProjectTimeTDS.LFS_PROJECT_TIME_SECTION_TEMPRow projectTimeSectionRow = ((ProjectTimeTDS.LFS_PROJECT_TIME_SECTION_TEMPDataTable)Table).NewLFS_PROJECT_TIME_SECTION_TEMPRow();

            projectTimeSectionRow.ProjectTimeID = projectTimeId;
            projectTimeSectionRow.SectionID = sectionId;
            projectTimeSectionRow.FlowOrderID = flowOrderId;
            projectTimeSectionRow.Completed = completed;
            projectTimeSectionRow.Date_ = date_;
            projectTimeSectionRow.PercentageOpened = percentageOpened;
            projectTimeSectionRow.PercentageBrushed = percentageBrushed;
            projectTimeSectionRow.Deleted = deleted;
            projectTimeSectionRow.COMPANY_ID = companyId;

            ((ProjectTimeTDS.LFS_PROJECT_TIME_SECTION_TEMPDataTable)Table).AddLFS_PROJECT_TIME_SECTION_TEMPRow(projectTimeSectionRow);
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <param name="sectionId">sectionId</param>
        public void Delete(int projectTimeId, string sectionId)
        {
            ProjectTimeTDS.LFS_PROJECT_TIME_SECTION_TEMPRow projectTimeRow = GetRow(projectTimeId, sectionId);
            projectTimeRow.Deleted = true;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>ProjectTimeTDS.LFS_PROJECT_TIME_SECTION_TEMPRow</returns>
        private ProjectTimeTDS.LFS_PROJECT_TIME_SECTION_TEMPRow GetRow(int projectTimeId, string sectionId)
        {
            ProjectTimeTDS.LFS_PROJECT_TIME_SECTION_TEMPRow row = ((ProjectTimeTDS.LFS_PROJECT_TIME_SECTION_TEMPDataTable)Table).FindByProjectTimeIDSectionID(projectTimeId, sectionId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTimeSectionTemp.GetRow");
            }

            return row;
        }



    }
}