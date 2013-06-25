using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeeInformationCostExceptionsInformationGateway
    /// </summary>
    public class EmployeeInformationCostExceptionsInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeInformationCostExceptionsInformationGateway()
            : base("CostExceptionsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeInformationCostExceptionsInformationGateway(DataSet data)
            : base(data, "CostExceptionsInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeInformationTDS();
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
            tableMapping.DataSetTable = "EmployeeInformationCostExceptionsInformationGateway";
            tableMapping.ColumnMappings.Add("CostID", "CostID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("Work_", "Work_");            
            tableMapping.ColumnMappings.Add("UnitOfMeasurement", "UnitOfMeasurement");
            tableMapping.ColumnMappings.Add("PayRateCad", "PayRateCad");
            tableMapping.ColumnMappings.Add("BurdenRateCad", "BurdenRateCad");
            tableMapping.ColumnMappings.Add("TotalCostCad", "TotalCostCad");
            tableMapping.ColumnMappings.Add("PayRateUsd", "PayRateUsd");
            tableMapping.ColumnMappings.Add("BurdenRateUsd", "BurdenRateUsd");
            tableMapping.ColumnMappings.Add("TotalCostUsd", "TotalCostUsd");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("BenefitFactorCad", "BenefitFactorCad");
            tableMapping.ColumnMappings.Add("BenefitFactorUsd", "BenefitFactorUsd");
            tableMapping.ColumnMappings.Add("HealthBenefitUsd", "HealthBenefitUsd");
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
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEESINFORMATIONCOSTEXCEPTIONSINFORMATIONGATEWAY_LOADALLBYCOSTID", new SqlParameter("@costId", costId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadAllByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAllByEmployeeId(int employeeId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEINFORMATIONCOSTEXCEPTIONSINFORMATIONGATEWAY_LOADALLBYEMPLOYEEID", new SqlParameter("@employeeId", employeeId), new SqlParameter("@companyId", companyId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Employees.EmployeeInformationCostExceptionsInformationGateway.GetRow");
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
        /// GetPayRateCad
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>      
        /// <returns>PayRateCad</returns>
        public Decimal GetPayRateCad(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["PayRateCad"];
        }



        /// <summary>
        /// GetPayRateCad Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original PayRateCad</returns>
        public Decimal GetPayRateCadOriginal(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["PayRateCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetBurdenRateCad
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>      
        /// <returns>BurdenRateCad</returns>
        public Decimal GetBurdenRateCad(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["BurdenRateCad"];
        }



        /// <summary>
        /// GetBurdenRateCad Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original BurdenRateCad</returns>
        public Decimal GetBurdenRateCadOriginal(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["BurdenRateCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalCostCad
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>      
        /// <returns>TotalCostCad</returns>
        public Decimal GetTotalCostCad(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["TotalCostCad"];
        }



        /// <summary>
        /// GetTotalCostCad Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original TotalCostCad</returns>
        public Decimal GetTotalCostCadOriginal(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["TotalCostCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPayRateUsd
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>      
        /// <returns>PayRateUsd</returns>
        public Decimal GetPayRateUsd(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["PayRateUsd"];
        }



        /// <summary>
        /// GetPayRateUsd Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original PayRateUsd</returns>
        public Decimal GetPayRateUsdOriginal(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["PayRateUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetBurdenRateUsd
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>      
        /// <returns>BurdenRateUsd</returns>
        public Decimal GetBurdenRateUsd(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["BurdenRateUsd"];
        }



        /// <summary>
        /// GetBurdenRateUsd Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original BurdenRateUsd</returns>
        public Decimal GetBurdenRateUsdOriginal(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["BurdenRateUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalCostUsd
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>      
        /// <returns>TotalCostUsd</returns>
        public Decimal GetTotalCostUsd(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["TotalCostUsd"];
        }



        /// <summary>
        /// GetTotalCostUsd Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original TotalCostUsd</returns>
        public Decimal GetTotalCostUsdOriginal(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["TotalCostUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetBenefitFactorCad
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>      
        /// <returns>BenefitFactorCad</returns>
        public Decimal GetBenefitFactorCad(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["BenefitFactorCad"];
        }



        /// <summary>
        /// GetBenefitFactorCad Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original BenefitFactorCad</returns>
        public Decimal GetBenefitFactorCadOriginal(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["BenefitFactorCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetBenefitFactorUsd
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>      
        /// <returns>BenefitFactorUsd</returns>
        public Decimal GetBenefitFactorUsd(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["BenefitFactorUsd"];
        }



        /// <summary>
        /// GetBenefitFactorUsd Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original BenefitFactorUsd</returns>
        public Decimal GetBenefitFactorUsdOriginal(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["BenefitFactorUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetHealthBenefitUsd
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>      
        /// <returns>HealthBenefitUsd</returns>
        public Decimal GetHealthBenefitUsd(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["HealthBenefitUsd"];
        }



        /// <summary>
        /// GetHealthBenefitUsd Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original HealthBenefitUsd</returns>
        public Decimal GetHealthBenefitUsdOriginal(int costId, int refId)
        {
            return (Decimal)GetRow(costId, refId)["HealthBenefitUsd", DataRowVersion.Original];
        }



    }
}