using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.RehabAssessment;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;

namespace LiquiForce.LFSLive.BL.CWP.RehabAssessment
{    
    /// <summary>
    /// RaNavigator
    /// </summary>
    public class RaNavigator: TableModule
    {

        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RaNavigator()
            : base("RaNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RaNavigator(DataSet data)
            : base(data, "RaNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new RaNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="whereClause">whereClause</param>
        /// <param name="orderByClause">orderByClause</param>
        /// <param name="conditionValue">conditionValue</param>
        /// <param name="textForSearch">textForSearch</param>
        /// <param name="companyId">companyId</param>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <param name="workType">workType</param>
        public void Load(string whereClause, string orderByClause, string conditionValue, string textForSearch, int companyId, int currentProjectId, string workType)
        {
            RaNavigatorGateway raNavigatorGateway = new RaNavigatorGateway(Data);
            raNavigatorGateway.LoadWhereOrderBy(whereClause, orderByClause, conditionValue, textForSearch);

            UpdateForProcess(currentProjectId, companyId);
        }



        /// <summary>
        /// LoadForViewsProjectIdCompanyIdWorkType
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        public void LoadForViewsProjectIdCompanyIdWorkType(string sqlCommand, int projectId, int companyId, string workType)
        {
            RaNavigatorGateway raNavigatorGateway = new RaNavigatorGateway(Data);
            raNavigatorGateway.LoadForViewsProjectIdCompanyIdWorkType(sqlCommand, projectId, companyId, workType);

            UpdateForProcess(projectId, companyId);
        }


        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="selected">selected</param>
        public void Update(int assetId, bool selected)
        {
            RaNavigatorTDS.RaNavigatorRow raNavigatorRow = GetRow(assetId);
            raNavigatorRow.Selected = selected;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
                 
        /// <summary>
        /// Get a single row. If not exists, raise an exception
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>RANavigatorTDS.RANavigatorRow</returns>
        private RaNavigatorTDS.RaNavigatorRow GetRow(int assetId)
        {
            RaNavigatorTDS.RaNavigatorRow row = ((RaNavigatorTDS.RaNavigatorDataTable)Table).FindByAssetID_(assetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.RehabAssessment.RaNavigator.GetRow");
            }

            return row;
        }



        /// <summary>
        /// UpdateForProcess
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>        
        private void UpdateForProcess(int projectId, int companyId)
        {
            foreach (RaNavigatorTDS.RaNavigatorRow row in (RaNavigatorTDS.RaNavigatorDataTable)Table)
            {
                if (row.IsStandardBypassNull()) row.StandardBypass = false;
                if (row.IsPipeSizeChangeNull()) row.PipeSizeChange = false;
                row.RoboticPrepRequired = false;
                if (row.IsRoboticPrepCompletedNull()) row.RoboticPrepCompleted = false;
            }
        }



        /// <summary>
        /// GetPreviousId
        /// </summary>
        /// <param name="raNavigatorTDS">raNavigatorTDS</param>
        /// <param name="currentAssetId">currentAssetId</param>
        /// <returns>prevAssetId</returns>
        public static int GetPreviousId(RaNavigatorTDS raNavigatorTDS, int currentAssetId)
        {
            int prevAssetId = currentAssetId;

            for (int i = 0; i < raNavigatorTDS.RaNavigator.DefaultView.Count; i++)
            {
                if ((int)raNavigatorTDS.RaNavigator.DefaultView[i]["AssetID"] == currentAssetId)
                {
                    if (i == 0)
                    {
                        prevAssetId = currentAssetId;
                    }
                    else
                    {
                        prevAssetId = (int)raNavigatorTDS.RaNavigator.DefaultView[i - 1]["AssetID"];
                    }

                    break;
                }
            }

            return prevAssetId;
        }



        /// <summary>
        /// GetNextId
        /// </summary>
        /// <param name="raNavigatorTDS">raNavigatorTDS</param>
        /// <param name="currentAssetId">currentAssetId</param>
        /// <returns>nextAssetId</returns>
        public static int GetNextId(RaNavigatorTDS raNavigatorTDS, int currentAssetId)
        {
            int nextAssetId = currentAssetId;

            for (int i = 0; i < raNavigatorTDS.RaNavigator.DefaultView.Count; i++)
            {
                if ((int)raNavigatorTDS.RaNavigator.DefaultView[i]["AssetID"] == currentAssetId)
                {
                    if (i == raNavigatorTDS.RaNavigator.DefaultView.Count - 1)
                    {
                        nextAssetId = currentAssetId;
                    }
                    else
                    {
                        nextAssetId = (int)raNavigatorTDS.RaNavigator.DefaultView[i + 1]["AssetID"];
                    }
                    break;
                }
            }

            return nextAssetId;
        }



    }
}