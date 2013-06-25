using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Materials
{
    /// <summary>
    /// MaterialsInformationCostHistoryInformationGateway
    /// </summary>
    public class MaterialsInformationCostHistoryInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsInformationCostHistoryInformationGateway()
            : base("CostHistoryInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsInformationCostHistoryInformationGateway(DataSet data)
            : base(data, "CostHistoryInformation")
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
            tableMapping.DataSetTable = "CostHistoryInformation";
            tableMapping.ColumnMappings.Add("CostID", "CostID");
            tableMapping.ColumnMappings.Add("MaterialID", "MaterialID");
            tableMapping.ColumnMappings.Add("Date", "Date");            
            tableMapping.ColumnMappings.Add("UnitOfMeasurement", "UnitOfMeasurement");
            tableMapping.ColumnMappings.Add("CostCad", "CostCad");
            tableMapping.ColumnMappings.Add("CostUsd", "CostUsd");            
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");            
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
        /// LoadAllByMaterialId
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAllByMaterialId(int materialId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_MATERIALSINFORMATIONCOSTHISTORYINFORMATIONGATEWAY_LOADALLBYMATERIALID", new SqlParameter("@materialId", materialId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="materialId">materialId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int costId, int materialId)
        {
            string filter = string.Format("CostID = {0} AND MaterialID = {1}", costId, materialId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Materials.MaterialsInformationCostHistoryInformation.GetRow");
            }
        }



        /// <summary>
        /// GetUnitOfMeasurement
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="materialId">materialId</param>      
        /// <returns>UnitOfMeasurement</returns>
        public string GetUnitOfMeasurement(int costId, int materialId)
        {
            return (string)GetRow(costId, materialId)["UnitOfMeasurement"];
        }



        /// <summary>
        /// GetUnitOfMeasurement Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="materialId">materialId</param>
        /// <returns>Original UnitOfMeasurement</returns>
        public string GetUnitOfMeasurementOriginal(int costId, int materialId)
        {
            return (string)GetRow(costId, materialId)["UnitOfMeasurement", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDate
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="materialId">materialId</param>      
        /// <returns>Date</returns>
        public DateTime GetDate(int costId, int materialId)
        {
            return (DateTime)GetRow(costId, materialId)["Date"];
        }



        /// <summary>
        /// GetUnitOfMeasurement Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="materialId">materialId</param>
        /// <returns>Original Date</returns>
        public DateTime GetDateOriginal(int costId, int materialId)
        {
            return (DateTime)GetRow(costId, materialId)["Date", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCostCad
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="materialId">materialId</param>      
        /// <returns>CostCad</returns>
        public Decimal GetCostCad(int costId, int materialId)
        {
            return (Decimal)GetRow(costId, materialId)["CostCad"];
        }



        /// <summary>
        /// GetCostCad Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="materialId">materialId</param>
        /// <returns>Original CostCad</returns>
        public Decimal GetCostCadOriginal(int costId, int materialId)
        {
            return (Decimal)GetRow(costId, materialId)["CostCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCostUsd
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="materialId">materialId</param>      
        /// <returns>CostUsd</returns>
        public Decimal GetCostUsd(int costId, int materialId)
        {
            return (Decimal)GetRow(costId, materialId)["CostUsd"];
        }



        /// <summary>
        /// GetCostUsd Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="materialId">materialId</param>
        /// <returns>Original CostUsd</returns>
        public Decimal GetCostUsdOriginal(int costId, int materialId)
        {
            return (Decimal)GetRow(costId, materialId)["CostUsd", DataRowVersion.Original];
        }


               
    }
}