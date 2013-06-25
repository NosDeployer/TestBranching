using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime;
using System;

namespace LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime
{
    /// <summary>
    /// TeamProjectTime2Section
    /// </summary>
    public class TeamProjectTime2Section : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TeamProjectTime2Section()
            : base("LFS_TEAM_PROJECT_TIME_SECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public TeamProjectTime2Section(DataSet data)
            : base(data, "LFS_TEAM_PROJECT_TIME_SECTION")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new TeamProjectTime2TDS();
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadForFllPrepAndMeasure
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="workType">workType</param>
        /// <pparam name="prepDate">prepDate</param>
        public void LoadForFllPrepAndMeasure(int projectId, string workType, DateTime prepDate)
        {
            TeamProjectTime2SectionGateway teamProjectTime2SectionGateway = new TeamProjectTime2SectionGateway(Data);
            teamProjectTime2SectionGateway.LoadByProjectIdWorkTypeForFllPrepAndMeasure(projectId, workType);

            UpdateData(prepDate);
        }



        /// <summary>
        /// LoadForFllInstall
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="workType">workType</param>
        /// <pparam name="installDate">installDate<param>
        public void LoadForFllInstall(int projectId, string workType, DateTime installDate)
        {
            TeamProjectTime2SectionGateway teamProjectTime2SectionGateway = new TeamProjectTime2SectionGateway(Data);
            teamProjectTime2SectionGateway.LoadByProjectIdWorkTypeForFllInstall(projectId, workType, installDate);

            UpdateData(installDate);
        }



        /// <summary>
        /// LoadForReinstatePostVideo
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="workType">workType</param>
        /// <pparam name="postVideo">postVideo<param>
        public void LoadForFllReinstatePostVideo(int projectId, string workType, DateTime postVideo)
        {
            TeamProjectTime2SectionGateway teamProjectTime2SectionGateway = new TeamProjectTime2SectionGateway(Data);
            teamProjectTime2SectionGateway.LoadByProjectIdWorkTypeForReinstatePostVideo(projectId, workType, postVideo);

            UpdateData(postVideo);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <param name="flowOrderId">flowOrderId</param>
        /// <param name="completed">completed</param>
        /// <param name="date_">date_</param>
        /// <param name="selected">selected</param>
        /// <param name="percentageOpened">percentageOpened</param>
        /// <param name="percentageBrushed">percentageBrushed</param>
        public void Insert(string sectionId, string flowOrderId, bool completed, DateTime? date_, bool selected, int percentageOpened, int percentageBrushed)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONRow row = ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)Table).NewLFS_TEAM_PROJECT_TIME_SECTIONRow();

            row.SectionID = sectionId;
            row.FlowOrderID = flowOrderId;
            if (date_.HasValue) row._Date = date_.Value;
            row.Completed = completed;
            row.Selected = selected;
            row.PercentageOpened = percentageOpened;
            row.PercentageBrushed = percentageBrushed;

            ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)Table).AddLFS_TEAM_PROJECT_TIME_SECTIONRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <param name="completed">completed</param>
        /// <param name="date_">date_</param>
        /// <param name="selected">selected</param>
        public void Update(string sectionId, bool completed, DateTime? date_, bool selected)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONRow row = GetRow(sectionId);

            if (date_.HasValue) row._Date = date_.Value;
            row.Completed = completed;
            row.Selected = selected;
        }



        /// <summary>
        /// Update2
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <param name="completed">completed</param>
        /// <param name="date_">date_</param>
        /// <param name="selected">selected</param>
        /// <param name="percentageOpened">percentageOpened</param>
        /// <param name="percentageBrushed">percentageBrushed</param>
        public void Update2(string sectionId, bool completed, DateTime? date_, bool selected, int percentageOpened, int percentageBrushed)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONRow row = GetRow(sectionId);

            if (date_.HasValue) row._Date = date_.Value;
            row.Completed = completed;
            row.Selected = selected;
            row.PercentageOpened = percentageOpened;
            row.PercentageBrushed = percentageBrushed;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <returns>Row</returns>
        private TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONRow GetRow(string sectionId)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONRow row = ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)Table).FindBySectionID(sectionId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime.TeamProjectTime2Section.GetRow");
            }

            return row;
        }



        /// <summary>
        /// UpdateData
        /// </summary>
        /// <param name="_Date">_Date</param>
        private void UpdateData(DateTime _Date)
        {
            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONRow row in (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)Table)
            {
                if (row.IsNull("_Date"))
                {
                    row._Date = _Date;
                }
            }
        }



    }
}