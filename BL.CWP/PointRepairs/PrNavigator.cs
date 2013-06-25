using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.PointRepairs;

namespace LiquiForce.LFSLive.BL.CWP.PointRepairs
{
    /// <summary>
    /// PrNavigator
    /// </summary>
    public class PrNavigator : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PrNavigator()
            : base("PrNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PrNavigator(DataSet data)
            : base(data, "PrNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PrNavigatorTDS();
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
        /// <param name="conditionValue2">conditionValue2</param>
        /// <param name="textForSearch2">textForSearch2</param>
        /// <param name="companyId">companyId</param>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <param name="workType">workType</param>
        /// <param name="name">name</param>
        public void Load(string whereClause, string orderByClause, string conditionValue, string textForSearch, string conditionValue2, string textForSearch2, int companyId, int currentProjectId, string workType, string name)
        {
            PrNavigatorGateway prNavigatorGateway = new PrNavigatorGateway(Data);
            prNavigatorGateway.LoadWhereOrderBy(whereClause, orderByClause, conditionValue, textForSearch, name, conditionValue2, textForSearch2);

            UpdateFieldsForSections();
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
            PrNavigatorGateway prNavigatorGateway = new PrNavigatorGateway(Data);
            prNavigatorGateway.LoadForViewsProjectIdCompanyIdWorkType(sqlCommand, projectId, companyId, workType);

            UpdateFieldsForSections();
        }


        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="assetId_">assetId_</param>
        /// <param name="selected">selected</param>
        public void Update(string assetId_, bool selected)
        {
            PrNavigatorTDS.PrNavigatorRow prNavigatorRow = GetRow(assetId_);
            prNavigatorRow.Selected = selected;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
       
        ///<summary>
        ///Get a single row. If not exists, raise an exception
        ///</summary>
        ///<param name="assetId_">assetId_</param>
        ///<returns>PrNavigatorTDS.PrNavigatorRow</returns>
        private PrNavigatorTDS.PrNavigatorRow GetRow(string assetId_)
        {
            PrNavigatorTDS.PrNavigatorRow row = ((PrNavigatorTDS.PrNavigatorDataTable)Table).FindByAssetID_(assetId_);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.PointRepairs.PrNavigator.GetRow");
            }

            return row;
        }



        /// <summary>
        /// UpdateFieldsForSections
        /// </summary>
        private void UpdateFieldsForSections()
        {
            foreach (PrNavigatorTDS.PrNavigatorRow row in (PrNavigatorTDS.PrNavigatorDataTable)Table)
            {
                if (row.IsBypassRequiredNull()) row.BypassRequired = false;
                row.RoboticPrepRequired = false;
                if (row.IsIssueIdentifiedNull()) row.IssueIdentified = false;
                if (row.IsIssueLFSNull()) row.IssueLFS = false;
                if (row.IsIssueClientNull()) row.IssueClient = false;
                if (row.IsIssueSalesNull()) row.IssueSales = false;
                if (row.IsIssueGivenToClientNull()) row.IssueGivenToClient = false;
                if (row.IsIssueInvestigationNull()) row.IssueInvestigation = false;
                if (row.IsIssueResolvedNull()) row.IssueResolved = false;
            }
        }



        /// <summary>
        /// GetPreviousId
        /// </summary>
        /// <param name="prNavigatorTDS">prNavigatorTDS</param>
        /// <param name="currentAssetId">currentAssetId</param>
        /// <returns>prevAssetId</returns>
        public static int GetPreviousId(PrNavigatorTDS prNavigatorTDS, int currentAssetId)
        {
            int prevAssetId = currentAssetId;

            for (int i = 0; i < prNavigatorTDS.PrNavigator.DefaultView.Count; i++)
            {
                if ((int)prNavigatorTDS.PrNavigator.DefaultView[i]["AssetID"] == currentAssetId)
                {
                    if (i == 0)
                    {
                        prevAssetId = currentAssetId;
                    }
                    else
                    {
                        prevAssetId = (int)prNavigatorTDS.PrNavigator.DefaultView[i - 1]["AssetID"];
                    }

                    break;
                }
            }

            return prevAssetId;
        }



        /// <summary>
        /// GetNextId
        /// </summary>
        /// <param name="prNavigatorTDS">prNavigatorTDS</param>
        /// <param name="currentAssetId">currentAssetId</param>
        /// <returns>nextAssetId</returns>
        public static int GetNextId(PrNavigatorTDS prNavigatorTDS, int currentAssetId)
        {
            int nextAssetId = currentAssetId;

            for (int i = 0; i < prNavigatorTDS.PrNavigator.DefaultView.Count; i++)
            {
                if ((int)prNavigatorTDS.PrNavigator.DefaultView[i]["AssetID"] == currentAssetId)
                {
                    if (i == prNavigatorTDS.PrNavigator.DefaultView.Count - 1)
                    {
                        nextAssetId = currentAssetId;
                    }
                    else
                    {
                        nextAssetId = (int)prNavigatorTDS.PrNavigator.DefaultView[i + 1]["AssetID"];
                    }
                    break;
                }
            }

            return nextAssetId;
        }



    }
}