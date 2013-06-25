using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation
{
    /// <summary>
    /// MrNavigator
    /// </summary>
    public class MrNavigator : TableModule
    {        
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MrNavigator()
            : base("MrNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MrNavigator(DataSet data)
            : base(data, "MrNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MrNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="whereClause">whereClause</param>
        /// <param name="orderByClause">orderByClause</param>
        /// <param name="conditionValue1">conditionValue1</param>
        /// <param name="conditionValue2">conditionValue2</param>
        /// <param name="textForSearch1">textForSearch1</param>
        /// <param name="textForSearch2">textForSearch2</param>
        /// <param name="companyId">companyId</param>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <param name="workType">workType</param>
        /// <param name="inProject">inProject</param>
        public void Load(string whereClause, string orderByClause, string conditionValue1, string conditionValue2, string textForSearch1, string textForSearch2, int companyId, int currentProjectId, string workType, bool inProject)
        {
            MrNavigatorGateway mrNavigatorGateway = new MrNavigatorGateway(Data);
            mrNavigatorGateway.LoadWhereOrderBy(whereClause, orderByClause, conditionValue1, conditionValue2, textForSearch1, textForSearch2, inProject, currentProjectId, workType);
        }



        /// <summary>
        /// LoadForViewsProjectIdCompanyIdWorkType
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>        
        /// <param name="inProject">inProject</param>
        public void LoadForViewsProjectIdCompanyIdWorkType(string sqlCommand, int projectId, int companyId, string workType, bool inProject)
        {
            MrNavigatorGateway mrNavigatorGateway = new MrNavigatorGateway(Data);
            mrNavigatorGateway.LoadForViewsProjectIdCompanyIdWorkType(sqlCommand, projectId, companyId, workType);
        }


        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="selected">selected</param>
        public void Update(int assetId, bool selected)
        {
            MrNavigatorTDS.MrNavigatorRow mrNavigatorRow = GetRow(assetId);
            mrNavigatorRow.Selected = selected;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
       
        ///<summary>
        ///Get a single row. If not exists, raise an exception
        ///</summary>
        ///<param name="assetId">assetId</param>
        ///<returns>MrNavigatorTDS.MrNavigatorRow</returns>
        private MrNavigatorTDS.MrNavigatorRow GetRow(int assetId)
        {
            MrNavigatorTDS.MrNavigatorRow row = ((MrNavigatorTDS.MrNavigatorDataTable)Table).FindByAssetID(assetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation.MrNavigator.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetPreviousId
        /// </summary>
        /// <param name="mrNavigatorTDS">mrNavigatorTDS</param>
        /// <param name="currentAssetId">currentAssetId</param>
        /// <returns>prevAssetId</returns>
        public static int GetPreviousId(MrNavigatorTDS mrNavigatorTDS, int currentAssetId)
        {
            int prevAssetId = currentAssetId;

            for (int i = 0; i < mrNavigatorTDS.MrNavigator.DefaultView.Count; i++)
            {
                if ((int)mrNavigatorTDS.MrNavigator.DefaultView[i]["AssetID"] == currentAssetId)
                {
                    if (i == 0)
                    {
                        prevAssetId = currentAssetId;
                    }
                    else
                    {
                        prevAssetId = (int)mrNavigatorTDS.MrNavigator.DefaultView[i - 1]["AssetID"];
                    }

                    break;
                }
            }

            return prevAssetId;
        }

        

        /// <summary>
        /// GetNextId
        /// </summary>
        /// <param name="mrNavigatorTDS">mrNavigatorTDS</param>
        /// <param name="currentAssetId">currentAssetId</param>
        /// <returns>nextAssetId</returns>
        public static int GetNextId(MrNavigatorTDS mrNavigatorTDS, int currentAssetId)
        {
            int nextAssetId = currentAssetId;

            for (int i = 0; i < mrNavigatorTDS.MrNavigator.DefaultView.Count; i++)
            {
                if ((int)mrNavigatorTDS.MrNavigator.DefaultView[i]["AssetID"] == currentAssetId)
                {
                    if (i == mrNavigatorTDS.MrNavigator.DefaultView.Count - 1)
                    {
                        nextAssetId = currentAssetId;
                    }
                    else
                    {
                        nextAssetId = (int)mrNavigatorTDS.MrNavigator.DefaultView[i + 1]["AssetID"];
                    }
                    break;
                }
            }

            return nextAssetId;
        }



    }
}