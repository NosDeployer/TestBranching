using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Units
{
    /// <summary>
    /// UnitInformationCostExceptionsInformationGateway
    /// </summary>
    public class UnitInformationCostExceptionsInformationGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitInformationCostExceptionsInformationGateway()
            : base("CostExceptionsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitInformationCostExceptionsInformationGateway(DataSet data)
            : base(data, "CostExceptionsInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitInformationTDS();
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
            tableMapping.DataSetTable = "CostExceptionsInformation";
            tableMapping.ColumnMappings.Add("CostID", "CostID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");           
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("Work_", "Work_");
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
        /// LoadAllByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAllByUnitId(int unitId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITINFORMATIONCOSTEXCEPTIONSINFORMATIONGATEWAY_LOADALLBYUNITID", new SqlParameter("@unitId", unitId), new SqlParameter("@companyId", companyId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Units.UnitInformationCostExceptionsInformationGateway.GetRow");
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

