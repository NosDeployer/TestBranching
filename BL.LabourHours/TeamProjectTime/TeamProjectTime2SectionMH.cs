using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime;
using System.Collections;

namespace LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime
{
    /// <summary>
    /// TeamProjectTime2SectionMH
    /// </summary>
    public class TeamProjectTime2SectionMH : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TeamProjectTime2SectionMH()
            : base("LFS_TEAM_PROJECT_TIME_SECTION_MH")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public TeamProjectTime2SectionMH(DataSet data)
            : base(data, "LFS_TEAM_PROJECT_TIME_SECTION_MH")
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
        /// LoadByProjectIdAndUpdateDate
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <param name="_date">_date</param>
        /// <param name="companyId">companyId</param>
        public void LoadByProjectIdAndUpdateDate(int projectId, DateTime _date, int companyId)
        {
            TeamProjectTime2SectionMHGateway teamProjectTime2SectionMHGateway = new TeamProjectTime2SectionMHGateway(Data);
            teamProjectTime2SectionMHGateway.LoadByProjectId(projectId, companyId);

            UpdateData(_date);
        }



        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <param name="_date">_date</param>
        /// <param name="companyId">companyId</param>
        public void Load(string sectionId, DateTime _date, int companyId)
        {
            TeamProjectTime2SectionMHGateway teamProjectTime2SectionMHGateway = new TeamProjectTime2SectionMHGateway(Data);
            teamProjectTime2SectionMHGateway.LoadBySectionId(sectionId, companyId);

            UpdateData(_date);
        }        



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="_date">_date</param>
        /// <param name="selected">selected</param>
        public void Update(int assetId, DateTime _date, bool selected)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHRow row = GetRow(assetId);

            row._Date = _date;
            row.Selected = selected;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Row</returns>
        private TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHRow GetRow(int assetId)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHRow row = ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable)Table).FindByAssetID(assetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime.TempProjectTime2SectionMH.GetRow");
            }

            return row;
        }



        /// <summary>
        /// UpdateData
        /// </summary>
        /// <param name="_Date">_Date</param>
        private void UpdateData(DateTime _Date)
        {
            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHRow row in (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable)Table)
            {
                if (row.IsNull("_Date"))
                {
                    row._Date = _Date;
                }
            }
        }



    }
}