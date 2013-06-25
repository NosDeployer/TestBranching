using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCombinedCostingSheetsNavigator
    /// </summary>
    public class ProjectCombinedCostingSheetsNavigator : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCombinedCostingSheetsNavigator()
            : base("ProjectCombinedCostingSheetsNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCombinedCostingSheetsNavigator(DataSet data)
            : base(data, "ProjectCombinedCostingSheetsNavigator")
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
        /// LoadByClientId
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByClientId(int clientId, int companyId)
        {
            ProjectCombinedCostingSheetsNavigatorGateway projectCombinedCostingSheetsNavigatorGateway = new ProjectCombinedCostingSheetsNavigatorGateway(Data);
            projectCombinedCostingSheetsNavigatorGateway.LoadByClientId(clientId, companyId);            
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="selected">selected</param>
        public void Update(int costingSheetId, bool selected)
        {
            ProjectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigatorRow row = GetRow(costingSheetId);
            row.Selected = selected;            
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <returns>ProjectCombinedCostingSheetsNavigatorRow</returns>
        private ProjectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigatorRow GetRow(int costingSheetId)
        {
            ProjectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigatorRow row = ((ProjectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigatorDataTable)Table).FindByCostingSheetID(costingSheetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCombinedCostingSheetsNavigator.GetRow");
            }

            return row;
        }



    }
}