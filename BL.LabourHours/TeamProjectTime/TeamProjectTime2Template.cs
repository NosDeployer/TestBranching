using System;
using System.Data;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime;

namespace LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime
{
    /// <summary>
    /// TeamProjectTime2Template
    /// </summary>
    public class TeamProjectTime2Template : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TeamProjectTime2Template()
            : base("Template")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        public TeamProjectTime2Template(DataSet data)
            : base(data, "Template")
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
        /// Update 
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="selected">selected</param>
        public void Update(int teamProjectTimeId, bool selected)
        {
            TeamProjectTime2TDS.TemplateRow row = GetRow(teamProjectTimeId);
            row.Selected = selected;
        }



        /// <summary>
        /// Delete a Template
        /// </summary>
        /// <param name="teamProjectTimeId">TeamProjectTimeId</param>
        public void Delete(int teamProjectTimeId)
        {
            // Delete Template row
            TeamProjectTime2TDS.TemplateRow row = GetRow(teamProjectTimeId);
            row.Deleted = true;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single template. If not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <returns>Obtained template</returns>
        private TeamProjectTime2TDS.TemplateRow GetRow(int teamProjectTimeId)
        {
            TeamProjectTime2TDS.TemplateRow row = ((TeamProjectTime2TDS.TemplateDataTable)Table).FindByTeamProjectTimeID(teamProjectTimeId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime.TeamProjectTime2Template.GetRow");
            }

            return row;
        }



    }
}