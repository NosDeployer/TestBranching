﻿using System.Data;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsNavigatorBondingCompaniesCosts
    /// </summary>
    public class ActualCostsNavigatorBondingCompaniesCosts : TableModule
    {
        //// ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsNavigatorBondingCompaniesCosts()
            : base("BondingCompaniesCosts")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsNavigatorBondingCompaniesCosts(DataSet data)
            : base(data, "BondingCompaniesCosts")
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
            ActualCostsNavigatorBondingCompaniesCostsGateway actualCostsNavigatorBondingCompaniesCostsGateway = new ActualCostsNavigatorBondingCompaniesCostsGateway(Data);
            actualCostsNavigatorBondingCompaniesCostsGateway.LoadWhereOrderBy(whereClause, orderByClause);

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
            ActualCostsNavigatorTDS.BondingCompaniesCostsRow row = GetRow(projectId, refId);
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

            for (int i = 0; i < actualCostsNavigatorTDS.BondingCompaniesCosts.DefaultView.Count; i++)
            {
                if ((int)actualCostsNavigatorTDS.BondingCompaniesCosts.DefaultView[i]["RefID"] == currentRefID)
                {
                    if (i == 0)
                    {
                        prevRefID = currentRefID;
                    }
                    else
                    {
                        prevRefID = (int)actualCostsNavigatorTDS.BondingCompaniesCosts.DefaultView[i - 1]["RefID"];
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

            for (int i = 0; i < actualCostsNavigatorTDS.BondingCompaniesCosts.DefaultView.Count; i++)
            {
                if ((int)actualCostsNavigatorTDS.BondingCompaniesCosts.DefaultView[i]["RefID"] == currentRefID)
                {
                    if (i == actualCostsNavigatorTDS.BondingCompaniesCosts.DefaultView.Count - 1)
                    {
                        nextRefID = currentRefID;
                    }
                    else
                    {
                        nextRefID = (int)actualCostsNavigatorTDS.BondingCompaniesCosts.DefaultView[i + 1]["RefID"];
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
        private ActualCostsNavigatorTDS.BondingCompaniesCostsRow GetRow( int projectId, int refId)
        {
            return ((ActualCostsNavigatorTDS.BondingCompaniesCostsDataTable)Table).FindByProjectIDRefID( projectId, refId);
        }



        private void UpdateDataForNavigator()
        {
            foreach (ActualCostsNavigatorTDS.BondingCompaniesCostsRow row in (ActualCostsNavigatorTDS.BondingCompaniesCostsDataTable)Table)
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