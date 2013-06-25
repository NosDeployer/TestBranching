using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitsNavigator
    /// </summary>
    public class UnitsNavigator : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsNavigator()
            : base("UnitsNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsNavigator(DataSet data)
            : base(data, "UnitsNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsNavigatorTDS();
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
        public void Load(string whereClause, string orderByClause, string conditionValue, string textForSearch, int companyId)
        {
            UnitsNavigatorGateway unitsNavigatorGateway = new UnitsNavigatorGateway(Data);
            unitsNavigatorGateway.LoadWhereOrderBy(whereClause, orderByClause, conditionValue, textForSearch);

            ProcessForReport();
        }



        /// <summary>
        /// LoadForViewsFmTypeCompanyId
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        public void LoadForViewsFmTypeCompanyId(string sqlCommand, string fmType, int companyId)
        {
            UnitsNavigatorGateway unitsNavigatorGateway = new UnitsNavigatorGateway(Data);
            unitsNavigatorGateway.LoadForViewsFmTypeCompanyId(sqlCommand, companyId, fmType);

            ProcessForReport();
        }


        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="selected">selected</param>
        public void Update(int unitId, bool selected)
        {
            UnitsNavigatorTDS.UnitsNavigatorRow unitsNavigatorRow = GetRow(unitId);
            unitsNavigatorRow.Selected = selected;
        }



        /// <summary>
        /// GetPreviousId
        /// </summary>
        /// <param name="unitsNavigatorTDS">unitsNavigatorTDS</param>
        /// <param name="currentUnitId">currentUnitId</param>
        /// <returns>prevUnitId</returns>
        public static int GetPreviousId(UnitsNavigatorTDS unitsNavigatorTDS, int currentUnitId)
        {
            int prevUnitId = currentUnitId;

            for (int i = 0; i < unitsNavigatorTDS.UnitsNavigator.DefaultView.Count; i++)
            {
                if ((int)unitsNavigatorTDS.UnitsNavigator.DefaultView[i]["UnitID"] == currentUnitId)
                {
                    if (i == 0)
                    {
                        prevUnitId = currentUnitId;
                    }
                    else
                    {
                        prevUnitId = (int)unitsNavigatorTDS.UnitsNavigator.DefaultView[i - 1]["UnitID"];
                    }

                    break;
                }
            }

            return prevUnitId;
        }



        /// <summary>
        /// GetNextId
        /// </summary>
        /// <param name="unitsNavigatorTDS">unitsNavigatorTDS</param>
        /// <param name="currentUnitId">currentUnitId</param>
        /// <returns>nextUnitId</returns>
        public static int GetNextId(UnitsNavigatorTDS unitsNavigatorTDS, int currentUnitId)
        {
            int nextUnitId = currentUnitId;

            for (int i = 0; i < unitsNavigatorTDS.UnitsNavigator.DefaultView.Count; i++)
            {
                if ((int)unitsNavigatorTDS.UnitsNavigator.DefaultView[i]["UnitID"] == currentUnitId)
                {
                    if (i == unitsNavigatorTDS.UnitsNavigator.DefaultView.Count - 1)
                    {
                        nextUnitId = currentUnitId;
                    }
                    else
                    {
                        nextUnitId = (int)unitsNavigatorTDS.UnitsNavigator.DefaultView[i + 1]["UnitID"];
                    }

                    break;
                }
            }

            return nextUnitId;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// ProcessForReport
        /// </summary>
        private void ProcessForReport()
        {
            foreach (UnitsNavigatorTDS.UnitsNavigatorRow row in (UnitsNavigatorTDS.UnitsNavigatorDataTable)Table)
            {
                if (row.IsIsPTOEquippedNull()) row.IsPTOEquipped = false;
                if (row.IsIsReeferEquippedNull()) row.IsReeferEquipped = false;
                if (row.IsIsTowableNull()) row.IsTowable = false;
            }
        }
                       


        ///<summary>
        ///Get a single row. If not exists, raise an exception
        ///</summary>
        ///<param name="unitId">unitId</param>
        ///<returns>UnitsNavigatorTDS.UnitsNavigatorRow</returns>
        private UnitsNavigatorTDS.UnitsNavigatorRow GetRow(int unitId)
        {
            UnitsNavigatorTDS.UnitsNavigatorRow row = ((UnitsNavigatorTDS.UnitsNavigatorDataTable)Table).FindByUnitID(unitId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FM.Units.UnitsNavigator.GetRow");
            }

            return row;
        }



    }
}