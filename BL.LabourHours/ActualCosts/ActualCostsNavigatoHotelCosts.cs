using System.Data;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsNavigatorHotelCosts
    /// </summary>
    public class ActualCostsNavigatorHotelCosts : TableModule
    {
        //// ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsNavigatorHotelCosts()
            : base("HotelCosts")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsNavigatorHotelCosts(DataSet data)
            : base(data, "HotelCosts")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ActualCostsNavigatorTDS();
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
            ActualCostsNavigatorHotelCostsGateway actualCostsNavigatorHotelCostsGateway = new ActualCostsNavigatorHotelCostsGateway(Data);
            actualCostsNavigatorHotelCostsGateway.LoadWhereOrderBy(whereClause, orderByClause);

            UpdateDataForNavigator();
        }



        /// <summary>
        /// Update
        /// </summary>        
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="selected">selected</param>
        public void Update(int projectId, int refId, bool selected)
        {
            ActualCostsNavigatorTDS.HotelCostsRow row = GetRow(projectId, refId);
            row.Selected = selected;
        }

        




        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetPreviousId
        /// </summary>
        /// <param name="actualCostsNavigatorTDS">actualCostsNavigatorTDS</param>
        /// <param name="currentRefID">currentRefID</param>
        /// <returns>prevRefID</returns>
        public static int GetPreviousId(ActualCostsNavigatorTDS actualCostsNavigatorTDS, int currentRefID)
        {
            int prevRefID = currentRefID;

            for (int i = 0; i < actualCostsNavigatorTDS.HotelCosts.DefaultView.Count; i++)
            {
                if ((int)actualCostsNavigatorTDS.HotelCosts.DefaultView[i]["RefID"] == currentRefID)
                {
                    if (i == 0)
                    {
                        prevRefID = currentRefID;
                    }
                    else
                    {
                        prevRefID = (int)actualCostsNavigatorTDS.HotelCosts.DefaultView[i - 1]["RefID"];
                    }

                    break;
                }
            }

            return prevRefID;
        }



        /// <summary>
        /// GetNextId
        /// </summary>
        /// <param name="actualCostsNavigatorTDS">actualCostsNavigatorTDS</param>
        /// <param name="currentRefID">currentRefID</param>
        /// <returns>nextRefID</returns>
        public static int GetNextId(ActualCostsNavigatorTDS actualCostsNavigatorTDS, int currentRefID)
        {
            int nextRefID = currentRefID;

            for (int i = 0; i < actualCostsNavigatorTDS.HotelCosts.DefaultView.Count; i++)
            {
                if ((int)actualCostsNavigatorTDS.HotelCosts.DefaultView[i]["RefID"] == currentRefID)
                {
                    if (i == actualCostsNavigatorTDS.HotelCosts.DefaultView.Count - 1)
                    {
                        nextRefID = currentRefID;
                    }
                    else
                    {
                        nextRefID = (int)actualCostsNavigatorTDS.HotelCosts.DefaultView[i + 1]["RefID"];
                    }
                    break;
                }
            }

            return nextRefID;
        }



        /// <summary>
        /// GetRow
        /// </summary>        
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns></returns>
        private ActualCostsNavigatorTDS.HotelCostsRow GetRow(int projectId, int refId)
        {
            return ((ActualCostsNavigatorTDS.HotelCostsDataTable)Table).FindByProjectIDRefID(projectId, refId);
        }



        private void UpdateDataForNavigator()
        {
            foreach (ActualCostsNavigatorTDS.HotelCostsRow row in (ActualCostsNavigatorTDS.HotelCostsDataTable)Table)
            {
                int projectId = row.ProjectID;

                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    row.RateUsd = row.RateCad;                    
                }
            }
        }



    }
}