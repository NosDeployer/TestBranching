using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlNavigator
    /// </summary>
    public class FlNavigator : TableModule
    {        
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlNavigator()
            : base("FlNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlNavigator(DataSet data)
            : base(data, "FlNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlNavigatorTDS();
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
            FlNavigatorGateway flNavigatorGateway = new FlNavigatorGateway(Data);
            flNavigatorGateway.LoadWhereOrderBy(whereClause, orderByClause, conditionValue, textForSearch);

            UpdateFieldsForSections();
        }



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
            FlNavigatorGateway flNavigatorGateway = new FlNavigatorGateway(Data);
            flNavigatorGateway.LoadWhereOrderBy(whereClause, orderByClause, conditionValue, textForSearch, name, conditionValue2, textForSearch2);

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
            FlNavigatorGateway flNavigatorGateway = new FlNavigatorGateway(Data);
            flNavigatorGateway.LoadForViewsProjectIdCompanyIdWorkType(sqlCommand, projectId, companyId, workType);

            UpdateFieldsForSections();
        }


        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="selected">selected</param>
        public void Update(string assetId, bool selected)
        {
            FlNavigatorTDS.FlNavigatorRow flNavigatorRow = GetRow(assetId);
            flNavigatorRow.Selected = selected;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
       
        ///<summary>
        ///Get a single row. If not exists, raise an exception
        ///</summary>
        ///<param name="assetId">assetId</param>
        ///<returns>FlNavigatorTDS.FlNavigatorRow</returns>
        private FlNavigatorTDS.FlNavigatorRow GetRow(string assetId)
        {
            FlNavigatorTDS.FlNavigatorRow row = ((FlNavigatorTDS.FlNavigatorDataTable)Table).FindByAssetID_(assetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlNavigator.GetRow");
            }

            return row;
        }



        /// <summary>
        /// UpdateFieldsForSections
        /// </summary>
        private void UpdateFieldsForSections()
        {
            foreach (FlNavigatorTDS.FlNavigatorRow row in (FlNavigatorTDS.FlNavigatorDataTable)Table)
            {
                if (!row.IsSize_Null())
                {
                    try
                    {
                        if (Distance.IsValidDistance(row.Size_))
                        {
                            Distance distance = new Distance(row.Size_);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    row.Size_ = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    if (Convert.ToDouble(row.Size_) > 99)
                                    {
                                        double newSize_ = 0;
                                        newSize_ = Convert.ToDouble(row.Size_) * 0.03937;
                                        row.Size_ = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                    }
                                    else
                                    {
                                        row.Size_ = row.Size_ + "\"";
                                    }
                                    break;
                                case 4:
                                    row.Size_ = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    row.Size_ = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }
                    catch
                    {
                    }
                }

                row.RoboticPrepRequired = false;
            }
        }



        /// <summary>
        /// GetPreviousId
        /// </summary>
        /// <param name="flNavigatorTDS">flNavigatorTDS</param>
        /// <param name="currentAssetId">currentAssetId</param>
        /// <returns>prevAssetId</returns>
        public static int GetPreviousId(FlNavigatorTDS flNavigatorTDS, int currentAssetId)
        {
            int prevAssetId = currentAssetId;

            for (int i = 0; i < flNavigatorTDS.FlNavigator.DefaultView.Count; i++)
            {
                if ((int)flNavigatorTDS.FlNavigator.DefaultView[i]["AssetID"] == currentAssetId)
                {
                    if (i == 0)
                    {
                        prevAssetId = currentAssetId;
                    }
                    else
                    {
                        prevAssetId = (int)flNavigatorTDS.FlNavigator.DefaultView[i - 1]["AssetID"];
                    }

                    break;
                }
            }

            return prevAssetId;
        }

        

        /// <summary>
        /// GetNextId
        /// </summary>
        /// <param name="flNavigatorTDS">flNavigatorTDS</param>
        /// <param name="currentAssetId">currentAssetId</param>
        /// <returns>nextAssetId</returns>
        public static int GetNextId(FlNavigatorTDS flNavigatorTDS, int currentAssetId)
        {
            int nextAssetId = currentAssetId;

            for (int i = 0; i < flNavigatorTDS.FlNavigator.DefaultView.Count; i++)
            {
                if ((int)flNavigatorTDS.FlNavigator.DefaultView[i]["AssetID"] == currentAssetId)
                {
                    if (i == flNavigatorTDS.FlNavigator.DefaultView.Count - 1)
                    {
                        nextAssetId = currentAssetId;
                    }
                    else
                    {
                        nextAssetId = (int)flNavigatorTDS.FlNavigator.DefaultView[i + 1]["AssetID"];
                    }
                    break;
                }
            }

            return nextAssetId;
        }



    }
}