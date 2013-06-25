using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Materials
{
    /// <summary>
    /// MaterialsNavigatorGateway
    /// </summary>
    public class MaterialsNavigatorGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsNavigatorGateway()
            : base("MaterialNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsNavigatorGateway(DataSet data)
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



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "MaterialNavigator";
            tableMapping.ColumnMappings.Add("MaterialID", "MaterialID");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("Size", "Size");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("Thickness", "Thickness");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("CostCad", "CostCad");
            tableMapping.ColumnMappings.Add("CostUsd", "CostUsd");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_MATERIALSNAVIGATORGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadWhereOrderBy
        /// </summary>
        /// <param name="where">clause WHERE</param>
        /// <param name="orderBy">clause ORDER BY</param>
        /// <param name="conditionValue">conditionValue</param>
        /// <param name="textForSearch">textForSearch</param>
        public void LoadWhereOrderBy(string where, string orderBy, string conditionValue, string textForSearch)
        {
            // For costs
            string whereClauseCostCad = "";

            if (conditionValue == "CostCad")
            {
                if (textForSearch == "")
                {
                    whereClauseCostCad = whereClauseCostCad + " AND  (LRM.MaterialID NOT IN " +
                        " (SELECT DISTINCT   LRMCH.MaterialID " +
                        "  FROM         LFS_RESOURCES_MATERIAL_COST_HISTORY LRMCH " +
                        "   WHERE (LRMCH.Deleted = 0)  " +
                                 "  ) )";
                }
                else
                {
                    if (textForSearch == "%")
                    {
                        whereClauseCostCad = whereClauseCostCad + " AND  (LRM.MaterialID IN " +
                        " (SELECT DISTINCT   LRMCH.MaterialID " +
                        "  FROM         LFS_RESOURCES_MATERIAL_COST_HISTORY LRMCH " +
                        "   WHERE (LRMCH.Deleted = 0)  " +
                                 "  ) ) OR  (LRM.MaterialID NOT IN " +
                        " (SELECT DISTINCT   LRMCH.MaterialID " +
                        "  FROM         LFS_RESOURCES_MATERIAL_COST_HISTORY LRMCH " +
                        "   WHERE (LRMCH.Deleted = 0)  " +
                                 "  ) )";
                    }
                    else
                    {
                        whereClauseCostCad = whereClauseCostCad + " AND  (LRM.MaterialID IN " +
                       " (SELECT DISTINCT   LRMCH.MaterialID " +
                       "  FROM         LFS_RESOURCES_MATERIAL_COST_HISTORY LRMCH " +
                       "   WHERE (LRMCH.Deleted = 0) AND (LRMCH.CostCad = " + textForSearch + ")" +
                                "  ) )";
                    }
                }
            }

            string whereClauseCostUsd = "";

            if (conditionValue == "CostUsd")
            {
                if (textForSearch == "")
                {
                    whereClauseCostUsd = whereClauseCostUsd + " AND  (LRM.MaterialID NOT IN " +
                        " (SELECT DISTINCT   LRMCH.MaterialID " +
                        "  FROM         LFS_RESOURCES_MATERIAL_COST_HISTORY LRMCH " +
                        "   WHERE (LRMCH.Deleted = 0)  " +
                                 "  ) )";
                }
                else
                {
                    if (textForSearch == "%")
                    {
                        whereClauseCostUsd = whereClauseCostUsd + " AND  (LRM.MaterialID IN " +
                        " (SELECT DISTINCT   LRMCH.MaterialID " +
                        "  FROM         LFS_RESOURCES_MATERIAL_COST_HISTORY LRMCH " +
                        "   WHERE (LRMCH.Deleted = 0)  " +
                                 "  ) ) OR  (LRM.MaterialID NOT IN " +
                        " (SELECT DISTINCT   LRMCH.MaterialID " +
                        "  FROM         LFS_RESOURCES_MATERIAL_COST_HISTORY LRMCH " +
                        "   WHERE (LRMCH.Deleted = 0)  " +
                                 "  ) )";
                    }
                    else
                    {
                        whereClauseCostUsd = whereClauseCostUsd + " AND  (LRM.MaterialID IN " +
                       " (SELECT DISTINCT   LRMCH.MaterialID " +
                       "  FROM         LFS_RESOURCES_MATERIAL_COST_HISTORY LRMCH " +
                       "   WHERE (LRMCH.Deleted = 0) AND (LRMCH.CostUsd = " + textForSearch + ")" +
                                "  ) )";
                    }
                }
            }



            string commandText = String.Format("SELECT     MaterialID, Description, Size, Length, Thickness, Type, State, Deleted, COMPANY_ID, CAST(0 AS BIT) AS Selected, " +
                    " (SELECT  top 1 LRMCH1.CostCad FROM LFS_RESOURCES_MATERIAL_COST_HISTORY LRMCH1 WHERE LRMCH1.MaterialID = LRM.MaterialID ORDER BY LRMCH1.Date Desc) AS CostCad, " +
                    " (SELECT  top 1 LRMCH2.CostUsd FROM LFS_RESOURCES_MATERIAL_COST_HISTORY LRMCH2 WHERE LRMCH2.MaterialID = LRM.MaterialID ORDER BY LRMCH2.Date Desc) AS CostUsd " +
                      " FROM         LFS_RESOURCES_MATERIAL  LRM" +
                      " WHERE {0} {2}{3}{1}", where, orderBy, whereClauseCostCad, whereClauseCostUsd);
            FillData(commandText);
        }
    }
}
