using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Revenue;

namespace LiquiForce.LFSLive.BL.Projects.Revenue
{
    /// <summary>
    /// RevenueNavigator
    /// </summary>
    public class RevenueNavigator: TableModule
    {
        //// ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RevenueNavigator()
            : base("RevenueNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RevenueNavigator(DataSet data)
            : base(data, "RevenueNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new RevenueNavigatorTDS();
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
            RevenueNavigatorGateway RevenueNavigatorGateway = new RevenueNavigatorGateway(Data);
            RevenueNavigatorGateway.LoadWhereOrderBy(whereClause, orderByClause);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="selected">selected</param>
        public void Update(int projectId, int refId, bool selected)
        {
            RevenueNavigatorTDS.RevenueNavigatorRow row = GetRow(projectId, refId);
            row.Selected = selected;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetPreviousProjectId
        /// </summary>
        /// <param name="RevenueNavigatorTDS">RevenueNavigatorTDS</param>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <param name="currentRefID">currentRefID</param>
        /// <returns>prevRefID</returns>
        public static int GetPreviousProjectId(RevenueNavigatorTDS RevenueNavigatorTDS, int currentProjectId, int currentRefId)
        {
            int prevProjectId = currentProjectId;

            for (int i = 0; i < RevenueNavigatorTDS.RevenueNavigator.DefaultView.Count; i++)
            {
                if (((int)RevenueNavigatorTDS.RevenueNavigator.DefaultView[i]["RefID"] == currentRefId) && ((int)RevenueNavigatorTDS.RevenueNavigator.DefaultView[i]["ProjectID"] == currentProjectId))
                {
                    if (i == 0)
                    {
                        prevProjectId = currentProjectId;
                    }
                    else
                    {
                        prevProjectId = (int)RevenueNavigatorTDS.RevenueNavigator.DefaultView[i - 1]["ProjectID"];
                    }

                    break;
                }
            }

            return prevProjectId;
        }



        /// <summary>
        /// GetPreviousRefId
        /// </summary>
        /// <param name="RevenueNavigatorTDS">RevenueNavigatorTDS</param>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <param name="currentRefID">currentRefID</param>
        /// <returns>prevRefID</returns>
        public static int GetPreviousRefId(RevenueNavigatorTDS RevenueNavigatorTDS, int currentProjectId, int currentRefId)
        {
            int prevRefId = currentRefId;

            for (int i = 0; i < RevenueNavigatorTDS.RevenueNavigator.DefaultView.Count; i++)
            {
                if (((int)RevenueNavigatorTDS.RevenueNavigator.DefaultView[i]["RefID"] == currentRefId) && ((int)RevenueNavigatorTDS.RevenueNavigator.DefaultView[i]["ProjectID"] == currentProjectId))
                {
                    if (i == 0)
                    {
                        prevRefId = currentRefId;
                    }
                    else
                    {
                        prevRefId = (int)RevenueNavigatorTDS.RevenueNavigator.DefaultView[i - 1]["RefID"];
                    }

                    break;
                }
            }

            return prevRefId;
        }



        /// <summary>
        /// GetNextProjectId
        /// </summary>
        /// <param name="RevenueNavigatorTDS">RevenueNavigatorTDS</param>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <param name="currentRefId">currentRefId</param>
        /// <returns>nextProjectID</returns>
        public static int GetNextProjectId(RevenueNavigatorTDS RevenueNavigatorTDS, int currentProjectId, int currentRefId)
        {
            int nextProjectId = currentProjectId;

            for (int i = 0; i < RevenueNavigatorTDS.RevenueNavigator.DefaultView.Count; i++)
            {
                if (((int)RevenueNavigatorTDS.RevenueNavigator.DefaultView[i]["RefID"] == currentRefId) && ((int)RevenueNavigatorTDS.RevenueNavigator.DefaultView[i]["ProjectID"] == currentProjectId))
                {
                    if (i == RevenueNavigatorTDS.RevenueNavigator.DefaultView.Count - 1)
                    {
                        nextProjectId = currentProjectId;
                    }
                    else
                    {
                        nextProjectId = (int)RevenueNavigatorTDS.RevenueNavigator.DefaultView[i + 1]["ProjectID"];
                    }
                    break;
                }
            }

            return nextProjectId;
        }



        /// <summary>
        /// GetNextRefId
        /// </summary>
        /// <param name="RevenueNavigatorTDS">RevenueNavigatorTDS</param>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <param name="currentRefID">currentRefID</param>
        /// <returns>nextRefID</returns>
        public static int GetNextRefId(RevenueNavigatorTDS RevenueNavigatorTDS, int currentProjectId, int currentRefId)
        {
            int nextRefId = currentRefId;

            for (int i = 0; i < RevenueNavigatorTDS.RevenueNavigator.DefaultView.Count; i++)
            {
                if (((int)RevenueNavigatorTDS.RevenueNavigator.DefaultView[i]["RefID"] == currentRefId) && ((int)RevenueNavigatorTDS.RevenueNavigator.DefaultView[i]["ProjectID"] == currentProjectId))
                {
                    if (i == RevenueNavigatorTDS.RevenueNavigator.DefaultView.Count - 1)
                    {
                        nextRefId = currentRefId;
                    }
                    else
                    {
                        nextRefId = (int)RevenueNavigatorTDS.RevenueNavigator.DefaultView[i + 1]["RefID"];
                    }
                    break;
                }
            }

            return nextRefId;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns></returns>
        private RevenueNavigatorTDS.RevenueNavigatorRow GetRow(int projectId, int refId)
        {
            return ((RevenueNavigatorTDS.RevenueNavigatorDataTable)Table).FindByProjectIDRefID(projectId, refId);
        }



    }
}