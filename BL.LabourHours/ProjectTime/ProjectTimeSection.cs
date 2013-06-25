using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.PayPeriod;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// ProjectTimeSection
    /// </summary>
    public class ProjectTimeSection : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTimeSection()
            : base("LFS_PROJECT_TIME_SECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTimeSection(DataSet data)
            : base(data, "LFS_PROJECT_TIME_SECTION")
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
            ProjectTimeTDS.LFS_PROJECT_TIME_SECTIONRow projectTimeSectionRow = ((ProjectTimeTDS.LFS_PROJECT_TIME_SECTIONDataTable)Table).NewLFS_PROJECT_TIME_SECTIONRow();

            projectTimeSectionRow.ProjectTimeID = projectTimeId;
            projectTimeSectionRow.SectionID = sectionId;
            projectTimeSectionRow.FlowOrderID = flowOrderId;
            projectTimeSectionRow.Completed = completed;
            projectTimeSectionRow.Date_ = date_;
            projectTimeSectionRow.PercentageOpened = percentageOpened;
            projectTimeSectionRow.PercentageBrushed = percentageBrushed;
            projectTimeSectionRow.Deleted = deleted;
            projectTimeSectionRow.COMPANY_ID = companyId;

            ((ProjectTimeTDS.LFS_PROJECT_TIME_SECTIONDataTable)Table).AddLFS_PROJECT_TIME_SECTIONRow(projectTimeSectionRow);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectTimeTDSToSave">projectTimeTDSToSave</param>
        public void Insert(ProjectTimeTDS projectTimeTDSToSave)
        {
            foreach (ProjectTimeTDS.LFS_PROJECT_TIME_SECTION_TEMPRow projectTimeSectionTempRow in ((ProjectTimeTDS)Data).LFS_PROJECT_TIME_SECTION_TEMP)
            {
                if (!projectTimeSectionTempRow.Deleted)
                {
                    int projectTimeId = projectTimeSectionTempRow.ProjectTimeID;
                    string sectionId = projectTimeSectionTempRow.SectionID;
                    string flowOrderId = projectTimeSectionTempRow.FlowOrderID;
                    bool completed = projectTimeSectionTempRow.Completed;
                    DateTime date_ = projectTimeSectionTempRow.Date_;
                    int percentageOpened = projectTimeSectionTempRow.PercentageOpened;
                    int percentageBrushed = projectTimeSectionTempRow.PercentageBrushed;
                    bool deleted = projectTimeSectionTempRow.Deleted;
                    int companyId = projectTimeSectionTempRow.COMPANY_ID;

                    ProjectTimeSection projectTimeSectionToSave = new ProjectTimeSection(Data);
                    projectTimeSectionToSave.Insert(projectTimeId, sectionId, flowOrderId, completed, date_, percentageOpened, percentageBrushed, deleted, companyId);
                }
            }
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        public void DeleteAll(int projectTimeId)
        {
            foreach (ProjectTimeTDS.LFS_PROJECT_TIME_SECTIONRow row in (ProjectTimeTDS.LFS_PROJECT_TIME_SECTIONDataTable)Table)
            {
                if (row.ProjectTimeID == projectTimeId)
                {
                    row.Deleted = true;
                }
            }
        }



    }
}