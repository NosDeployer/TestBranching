using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetsNavigator
    /// </summary>
    public class ProjectCostingSheetsNavigator : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetsNavigator()
            : base("ProjectCostingSheetsNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetsNavigator(DataSet data)
            : base(data, "ProjectCostingSheetsNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetsNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByProjectId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByProjectId(int projectId, int companyId)
        {
            ProjectCostingSheetsNavigatorGateway projectCostingSheetsNavigatorGateway = new ProjectCostingSheetsNavigatorGateway(Data);
            projectCostingSheetsNavigatorGateway.LoadByProjectId(projectId, companyId);            
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="selected">selected</param>
        public void Update(int costingSheetId, bool selected)
        {
            ProjectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigatorRow projectCostingSheetsNavigatorRow = GetRow(costingSheetId);
            projectCostingSheetsNavigatorRow.Selected = selected;            
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>ProjectCostingSheetsNavigatorRow</returns>
        private ProjectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigatorRow GetRow(int costingSheetId)
        {
            ProjectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigatorRow row = ((ProjectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigatorDataTable)Table).FindByCostingSheetID(costingSheetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetsNavigator.GetRow");
            }

            return row;
        }



    }
}