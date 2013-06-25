using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Units
{
    /// <summary>
    /// UnitInformationCostInformationGateway
    /// </summary>
    public class UnitInformationCostInformationGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitInformationCostInformationGateway()
            : base("CostInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitInformationCostInformationGateway(DataSet data)
            : base(data, "CostInformation")
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
            tableMapping.DataSetTable = "CostInformation";
            tableMapping.ColumnMappings.Add("CostID", "CostID");
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");            
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
        /// LoadAllByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAllByUnitId(int unitId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITINFORMATIONCOSTINFORMATIONGATEWAY_LOADALLBYUNITID", new SqlParameter("@unitId", unitId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadLastCostByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadLastCostByUnitId(int unitId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITINFORMATIONCOSTINFORMATIONGATEWAY_LOADLASTCOSTBYUNITID", new SqlParameter("@unitId", unitId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="costId">costId</param>        
        /// <returns>DataRow</returns>
        public DataRow GetRow(int costId)
        {
            string filter = string.Format("CostID = {0}", costId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Units.UnitInformationcostInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetUnitOfMeasurement
        /// </summary>
        /// <param name="costId">costId</param>         
        /// <returns>UnitOfMeasurement</returns>
        public string GetUnitOfMeasurement(int costId)
        {
            return (string)GetRow(costId)["UnitOfMeasurement"];
        }



        /// <summary>
        /// GetUnitOfMeasurement Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <returns>Original UnitOfMeasurement</returns>
        public string GetUnitOfMeasurementOriginal(int costId)
        {
            return (string)GetRow(costId)["UnitOfMeasurement", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDate
        /// </summary>
        /// <param name="costId">costId</param>        
        /// <returns>Date</returns>
        public DateTime GetDate(int costId)
        {
            return (DateTime)GetRow(costId)["Date"];
        }



        /// <summary>
        /// GetUnitOfMeasurement Original
        /// </summary>
        /// <param name="costId">costId</param>        
        /// <returns>Original Date</returns>
        public DateTime GetDateOriginal(int costId)
        {
            return (DateTime)GetRow(costId)["Date", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCostCad
        /// </summary>
        /// <param name="costId">costId</param>        
        /// <returns>CostCad</returns>
        public Decimal GetCostCad(int costId)
        {
            return (Decimal)GetRow(costId)["CostCad"];
        }



        /// <summary>
        /// GetCostCad Original
        /// </summary>
        /// <param name="costId">costId</param>        
        /// <returns>Original CostCad</returns>
        public Decimal GetCostCadOriginal(int costId)
        {
            return (Decimal)GetRow(costId)["CostCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCostUsd
        /// </summary>
        /// <param name="costId">costId</param>             
        /// <returns>CostUsd</returns>
        public Decimal GetCostUsd(int costId)
        {
            return (Decimal)GetRow(costId)["CostUsd"];
        }



        /// <summary>
        /// GetCostUsd Original
        /// </summary>
        /// <param name="costId">costId</param>        
        /// <returns>Original CostUsd</returns>
        public Decimal GetCostUsdOriginal(int costId)
        {
            return (Decimal)GetRow(costId)["CostUsd", DataRowVersion.Original];
        }

    }
}
