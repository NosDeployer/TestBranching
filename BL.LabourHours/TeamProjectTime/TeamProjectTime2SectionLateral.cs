using System;
using System.Collections;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime;

namespace LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime
{
    /// <summary>
    /// TeamProjectTime2SectionLateral
    /// </summary>
    public class TeamProjectTime2SectionLateral : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TeamProjectTime2SectionLateral()
            : base("LFS_TEAM_PROJECT_TIME_SECTION_LATERAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public TeamProjectTime2SectionLateral(DataSet data)
            : base(data, "LFS_TEAM_PROJECT_TIME_SECTION_LATERAL")
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
        /// Load
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        public void Load(string sectionId)
        {
            TeamProjectTime2SectionLateralGateway teamProjectTime2SectionLateralGateway = new TeamProjectTime2SectionLateralGateway(Data);
            teamProjectTime2SectionLateralGateway.ClearBeforeFill = false;
            teamProjectTime2SectionLateralGateway.LoadBySectionId(sectionId);
            teamProjectTime2SectionLateralGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <param name="lateralId">lateralId</param>
        /// <param name="opened">opened</param>
        /// <param name="brushed">brushed</param>
        /// <param name="selected">selected</param>
        public void Update(string sectionId, string lateralId, bool opened, bool brushed, bool selected)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALRow row = GetRow(sectionId, lateralId);

            row.Opened = opened;
            row.Brushed = brushed;
            row.Selected = selected;
        }



        public void Delete(string sectionId)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALRow row in (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALDataTable)Table)
            {
                if (row.SectionID == sectionId)
                {
                    duplicateList.Add(row);
                }
            }

            foreach (DataRow dRow in duplicateList)
            {
                this.Table.Rows.Remove(dRow);
            }

            this.Table.DefaultView.Sort = "SectionID ASC";
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <param name="lateralId">lateralId</param>
        /// <returns>Row</returns>
        private TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALRow GetRow(string sectionId, string lateralId)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALRow row = ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALDataTable)Table).FindBySectionIDLateralID(sectionId, lateralId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime.TempProjectTime2SectionLateral.GetRow");
            }

            return row;
        }



    }
}