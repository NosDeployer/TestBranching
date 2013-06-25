using System;
using System.Data;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.Materials;
using LiquiForce.LFSLive.BL.Common;

namespace LiquiForce.LFSLive.BL.Resources.Materials
{
    /// <summary>
    /// MaterialsNavigator
    /// </summary>
    public class MaterialsNavigator : TableModule
    {
        //// ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsNavigator()
            : base("MaterialNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsNavigator(DataSet data)
            : base(data, "MaterialNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MaterialsNavigatorTDS();
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
        /// <param name="resourceType">resourceType</param>
        public void Load(string whereClause, string orderByClause, string conditionValue, string textForSearch, int companyId, string resourceType)
        {
            MaterialsNavigatorGateway materialsNavigatorGateway = new MaterialsNavigatorGateway(Data);
            materialsNavigatorGateway.LoadWhereOrderBy(whereClause, orderByClause, conditionValue, textForSearch);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="selected">selected</param>
        public void Update(int materialId, bool selected)
        {
            MaterialsNavigatorTDS.MaterialNavigatorRow materialRow = GetRow(materialId);
            materialRow.Selected = selected;
        }        






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns></returns>
        private MaterialsNavigatorTDS.MaterialNavigatorRow GetRow(int materialId)
        {
            return ((MaterialsNavigatorTDS.MaterialNavigatorDataTable)Table).FindByMaterialID(materialId);
        }



        /// <summary>
        /// GetPreviousId
        /// </summary>
        /// <param name="materialsNavigatorTDS">materialsNavigatorTDS</param>
        /// <param name="currentMaterialId">currentMaterialId</param>
        /// <returns>prevMaterialId</returns>
        public static int GetPreviousId(MaterialsNavigatorTDS materialsNavigatorTDS, int currentMaterialId)
        {
            int prevMaterialId = currentMaterialId;

            for (int i = 0; i < materialsNavigatorTDS.MaterialNavigator.DefaultView.Count; i++)
            {
                if ((int)materialsNavigatorTDS.MaterialNavigator.DefaultView[i]["MaterialID"] == currentMaterialId)
                {
                    if (i == 0)
                    {
                        prevMaterialId = currentMaterialId;
                    }
                    else
                    {
                        prevMaterialId = (int)materialsNavigatorTDS.MaterialNavigator.DefaultView[i - 1]["MaterialID"];
                    }

                    break;
                }
            }

            return prevMaterialId;
        }



        /// <summary>
        /// GetNextId
        /// </summary>
        /// <param name="materialsNavigatorTDS">materialsNavigatorTDS</param>
        /// <param name="currentMaterialId">currentMaterialId</param>
        /// <returns>nextMaterialId</returns>
        public static int GetNextId(MaterialsNavigatorTDS materialsNavigatorTDS, int currentMaterialId)
        {
            int nextMaterialId = currentMaterialId;

            for (int i = 0; i < materialsNavigatorTDS.MaterialNavigator.DefaultView.Count; i++)
            {
                if ((int)materialsNavigatorTDS.MaterialNavigator.DefaultView[i]["MaterialID"] == currentMaterialId)
                {
                    if (i == materialsNavigatorTDS.MaterialNavigator.DefaultView.Count - 1)
                    {
                        nextMaterialId = currentMaterialId;
                    }
                    else
                    {
                        nextMaterialId = (int)materialsNavigatorTDS.MaterialNavigator.DefaultView[i + 1]["MaterialID"];
                    }
                    break;
                }
            }

            return nextMaterialId;
        }



    }
}