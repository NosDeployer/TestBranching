using System.Data;
using LiquiForce.LFSLive.DA.LabourHours.SubcontractorHours;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours
{
    /// <summary>
    /// SubcontractorHoursNavigator
    /// </summary>
    public class SubcontractorHoursNavigator : TableModule
    {
        //// ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SubcontractorHoursNavigator()
            : base("SubcontractorHoursNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SubcontractorHoursNavigator(DataSet data)
            : base(data, "SubcontractorHoursNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SubcontractorHoursNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="whereClause">whereClause</param>
        /// <param name="orderByClause">orderByClause</param>
        public void Load(string whereClause, string orderByClause)
        {
            SubcontractorHoursNavigatorGateway subcontractorHoursNavigatorGateway = new SubcontractorHoursNavigatorGateway(Data);
            subcontractorHoursNavigatorGateway.LoadWhereOrderBy(whereClause, orderByClause);

            UpdateDataForNavigator();
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="selected">selected</param>
        public void Update(int subcontractorId, int projectId, int refId, bool selected)
        {
            SubcontractorHoursNavigatorTDS.SubcontractorHoursNavigatorRow row = GetRow(subcontractorId, projectId, refId);
            row.Selected = selected;
        }

        




        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetPreviousId
        /// </summary>
        /// <param name="subcontractorHoursNavigatorTDS">subcontractorHoursNavigatorTDS</param>
        /// <param name="currentRefID">currentRefID</param>
        /// <returns>prevRefID</returns>
        public static int GetPreviousId(SubcontractorHoursNavigatorTDS subcontractorHoursNavigatorTDS, int currentRefID)
        {
            int prevRefID = currentRefID;

            for (int i = 0; i < subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.DefaultView.Count; i++)
            {
                if ((int)subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.DefaultView[i]["RefID"] == currentRefID)
                {
                    if (i == 0)
                    {
                        prevRefID = currentRefID;
                    }
                    else
                    {
                        prevRefID = (int)subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.DefaultView[i - 1]["RefID"];
                    }

                    break;
                }
            }

            return prevRefID;
        }



        /// <summary>
        /// GetNextId
        /// </summary>
        /// <param name="subcontractorHoursNavigatorTDS">subcontractorHoursNavigatorTDS</param>
        /// <param name="currentRefID">currentRefID</param>
        /// <returns>nextRefID</returns>
        public static int GetNextId(SubcontractorHoursNavigatorTDS subcontractorHoursNavigatorTDS, int currentRefID)
        {
            int nextRefID = currentRefID;

            for (int i = 0; i < subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.DefaultView.Count; i++)
            {
                if ((int)subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.DefaultView[i]["RefID"] == currentRefID)
                {
                    if (i == subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.DefaultView.Count - 1)
                    {
                        nextRefID = currentRefID;
                    }
                    else
                    {
                        nextRefID = (int)subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.DefaultView[i + 1]["RefID"];
                    }
                    break;
                }
            }

            return nextRefID;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns></returns>
        private SubcontractorHoursNavigatorTDS.SubcontractorHoursNavigatorRow GetRow(int subcontractorId, int projectId, int refId)
        {
            return ((SubcontractorHoursNavigatorTDS.SubcontractorHoursNavigatorDataTable)Table).FindBySubcontractorIDProjectIDRefID(subcontractorId, projectId, refId);
        }



        private void UpdateDataForNavigator()
        {
            foreach (SubcontractorHoursNavigatorTDS.SubcontractorHoursNavigatorRow row in (SubcontractorHoursNavigatorTDS.SubcontractorHoursNavigatorDataTable)Table)
            {
                int projectId = row.ProjectID;

                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    row.RateUsd = row.RateCad;
                    row.TotalUsd = row.TotalCad;
                }
            }
        }



    }
}