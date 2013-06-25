using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Materials
{
    /// <summary>
    /// MaterialsInformationCostHistoryExceptionsInformationGateway
    /// </summary>
    public class MaterialsInformationCostHistoryExceptionsInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsInformationCostHistoryExceptionsInformationGateway()
            : base("CostHistoryExceptionsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsInformationCostHistoryExceptionsInformationGateway(DataSet data)
            : base(data, "CostHistoryExceptionsInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MaterialsInformationTDS();
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
            tableMapping.DataSetTable = "CostHistoryExceptionsInformation";
            tableMapping.ColumnMappings.Add("CostID", "CostID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("MaterialID", "MaterialID");
            tableMapping.ColumnMappings.Add("Work_", "Work_");
            tableMapping.ColumnMappings.Add("Function_", "Function_");
            tableMapping.ColumnMappings.Add("UnitOfMeasurement", "UnitOfMeasurement");
            tableMapping.ColumnMappings.Add("CostCad", "CostCad");
            tableMapping.ColumnMappings.Add("CostUsd", "CostUsd");            
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("WorkFunction", "WorkFunction");
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
        /// LoadAllByCostId
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAllByCostId(int costId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_MATERIALSINFORMATIONCOSTHISTORYEXCEPTIONSINFORMATIONGATEWAY_LOADALLBYCOSTID", new SqlParameter("@costId", costId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadAllByMaterialId
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAllByMaterialId(int materialId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_MATERIALSINFORMATIONCOSTHISTORYEXCEPTIONSINFORMATIONGATEWAY_LOADALLBYMATERIALID", new SqlParameter("@materialId", materialId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int costId, int refId)
        {
            string filter = string.Format("CostID = {0} AND RefID = {1}", costId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Materials.MaterialsInformationcostHistoryExceptionsInformation.GetRow");
            }
        }



        /// <summary>
        /// GetWorkFunction
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>WorkFunction or EMPTY</returns>
        public string GetWorkFunction(int costId, int refId)
        {
            if (GetRow(costId, refId).IsNull("WorkFunction"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(costId, refId)["WorkFunction"];
            }
        }



        /// <summary>
        /// GetUnitOfMeasurement
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>UnitOfMeasurment</returns>
        public string GetUnitOfMeasurement(int costId, int refId)
        {
            return (string)GetRow(costId, refId)["UnitOfMeasurement"];
        }



        /// <summary>
        /// GetUnitOfMeasurement Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original UnitOfMeasurement</returns>
        public string GetUnitOfMeasurementOriginal(int costId, int refId)
        {
            return (string)GetRow(costId, refId)["UnitOfMeasurement", DataRowVersion.Original];
        }



        /// <summary>
        /// GetWork_
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>Work_</returns>
        public string GetWork_(int costId, int refId)
        {
            return (string)GetRow(costId, refId)["Work_"];
        }



        /// <summary>
        /// GetWork_ Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Work_</returns>
        public string GetWork_Original(int costId, int refId)
        {
            return (string)GetRow(costId, refId)["Work_", DataRowVersion.Original];
        }



        /// <summary>
        /// GetFunction_
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>Function_</returns>
        public string GetFunction_(int costId, int refId)
        {
            return (string)GetRow(costId, refId)["Function_"];
        }



        /// <summary>
        /// GetFunction_ Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Function_</returns>
        public string GetFunction_Original(int costId, int refId)
        {
            return (string)GetRow(costId, refId)["Function_", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCostCad
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>      
        /// <returns>CostCad</returns>
        public Decimal GetCostCad(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["CostCad"];
        }



        /// <summary>
        /// GetCostCad Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original CostCad</returns>
        public Decimal GetCostCadOriginal(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["CostCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCostUsd
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>      
        /// <returns>CostUsd</returns>
        public Decimal GetCostUsd(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["CostUsd"];
        }



        /// <summary>
        /// GetCostUsd Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original CostUsd</returns>
        public Decimal GetCostUsdOriginal(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["CostUsd", DataRowVersion.Original];
        }



    }
}
