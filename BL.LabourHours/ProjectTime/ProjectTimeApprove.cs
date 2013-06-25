using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// ProjectTimeApprove
    /// </summary>
    public class ProjectTimeApprove : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTimeApprove()
            : base("ProjectTimeApprove")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTimeApprove(DataSet data)
            : base(data, "ProjectTimeApprove")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTimeApproveTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Update project time
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <param name="selected">selected</param>
        public void Update(int projectTimeId, bool selected)
        {
            ProjectTimeApproveTDS.ProjectTimeApproveRow row = GetRow(projectTimeId);
            row.Selected = selected;
        }




        

        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Row</returns>
        private ProjectTimeApproveTDS.ProjectTimeApproveRow GetRow(int projectTimeId)
        {
            ProjectTimeApproveTDS.ProjectTimeApproveRow row = ((ProjectTimeApproveTDS.ProjectTimeApproveDataTable)Table).FindByProjectTimeID(projectTimeId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTimeApprove.GetRow");
            }

            return row;
        }



    }
}