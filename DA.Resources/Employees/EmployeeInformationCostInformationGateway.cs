using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeeInformationCostInformationGateway
    /// </summary>
    public class EmployeeInformationCostInformationGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeInformationCostInformationGateway()
            : base("CostInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeInformationCostInformationGateway(DataSet data)
            : base(data, "CostInformation")
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
            tableMapping.DataSetTable = "CostInformation";
            tableMapping.ColumnMappings.Add("CostID", "CostID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("Date", "Date");            
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
        /// LoadAllByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAllByEmployeeId(int employeeId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEINFORMATIONCOSTINFORMATIONGATEWAY_LOADALLBYEMPLOYEEID", new SqlParameter("@employeeId", employeeId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadLastCostByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadLastCostByEmployeeId(int employeeId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEINFORMATIONCOSTINFORMATIONGATEWAY_LOADLASTCOSTBYEMPLOYEEID", new SqlParameter("@employeeId", employeeId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int costId, int employeeId)
        {
            string filter = string.Format("CostID = {0} AND EmployeeID = {1}", costId, employeeId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Employee.EmployeeInformationCostInformation.GetRow");
            }
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int employeeId)
        {
            string filter = string.Format("EmployeeID = {0}", employeeId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Employee.EmployeeInformationCostInformation.GetRow");
            }
        }



        /// <summary>
        /// GetCostId
        /// </summary>        
        /// <param name="employeeId">employeeId</param>      
        /// <returns>CostID</returns>
        public int GetCostId(int employeeId)
        {
            return (int)GetRow(employeeId)["CostID"];
        }


        
        /// <summary>
        /// GetUnitOfMeasurement
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>      
        /// <returns>UnitOfMeasurement</returns>
        public string GetUnitOfMeasurement(int costId, int employeeId)
        {
            return (string)GetRow(costId, employeeId)["UnitOfMeasurement"];
        }



        /// <summary>
        /// GetUnitOfMeasurement Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original UnitOfMeasurement</returns>
        public string GetUnitOfMeasurementOriginal(int costId, int employeeId)
        {
            return (string)GetRow(costId, employeeId)["UnitOfMeasurement", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDate
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>      
        /// <returns>Date</returns>
        public DateTime GetDate(int costId, int employeeId)
        {
            return (DateTime)GetRow(costId, employeeId)["Date"];
        }



        /// <summary>
        /// GetDate Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original Date</returns>
        public DateTime GetDateOriginal(int costId, int employeeId)
        {
            return (DateTime)GetRow(costId, employeeId)["Date", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPayRateCad
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>      
        /// <returns>PayRateCad</returns>
        public Decimal GetPayRateCad(int costId, int employeeId)
        {
            return (Decimal)GetRow(costId, employeeId)["PayRateCad"];
        }



        /// <summary>
        /// GetPayRateCad Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original PayRateCad</returns>
        public Decimal GetPayRateCadOriginal(int costId, int employeeId)
        {
            return (Decimal)GetRow(costId, employeeId)["PayRateCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetBurdenRateCad
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>      
        /// <returns>BurdenRateCad</returns>
        public Decimal GetBurdenRateCad(int costId, int employeeId)
        {
            return (Decimal)GetRow(costId, employeeId)["BurdenRateCad"];
        }



        /// <summary>
        /// GetBurdenRateCad Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original BurdenRateCad</returns>
        public Decimal GetBurdenRateCadOriginal(int costId, int employeeId)
        {
            return (Decimal)GetRow(costId, employeeId)["BurdenRateCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalCostCad
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>      
        /// <returns>TotalCostCad</returns>
        public Decimal GetTotalCostCad(int costId, int employeeId)
        {
            return (Decimal)GetRow(costId, employeeId)["TotalCostCad"];
        }



        /// <summary>
        /// GetTotalCostCad Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original TotalCostCad</returns>
        public Decimal GetTotalCostCadOriginal(int costId, int employeeId)
        {
            return (Decimal)GetRow(costId, employeeId)["TotalCostCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPayRateUsd
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>      
        /// <returns>PayRateUsd</returns>
        public Decimal GetPayRateUsd(int costId, int employeeId)
        {
            return (Decimal)GetRow(costId, employeeId)["PayRateUsd"];
        }



        /// <summary>
        /// GetPayRateUsd Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original PayRateUsd</returns>
        public Decimal GetPayRateUsdOriginal(int costId, int employeeId)
        {
            return (Decimal)GetRow(costId, employeeId)["PayRateUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetBurdenRateUsd
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>      
        /// <returns>BurdenRateUsd</returns>
        public Decimal GetBurdenRateUsd(int costId, int employeeId)
        {
            return (Decimal)GetRow(costId, employeeId)["BurdenRateUsd"];
        }



        /// <summary>
        /// GetBurdenRateUsd Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original BurdenRateUsd</returns>
        public Decimal GetBurdenRateUsdOriginal(int costId, int employeeId)
        {
            return (Decimal)GetRow(costId, employeeId)["BurdenRateUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalCostUsd
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>      
        /// <returns>TotalCostUsd</returns>
        public Decimal GetTotalCostUsd(int costId, int employeeId)
        {
            return (Decimal)GetRow(costId, employeeId)["TotalCostUsd"];
        }



        /// <summary>
        /// GetTotalCostUsd Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original TotalCostUsd</returns>
        public Decimal GetTotalCostUsdOriginal(int costId, int employeeId)
        {
            return (Decimal)GetRow(costId, employeeId)["TotalCostUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetBenefitFactorCad
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>      
        /// <returns>BenefitFactorCad</returns>
        public Decimal GetBenefitFactorCad(int costId, int employeeId)
        {
            return (Decimal)GetRow(costId, employeeId)["BenefitFactorCad"];
        }



        /// <summary>
        /// GetBenefitFactorCad Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original BenefitFactorCad</returns>
        public Decimal GetBenefitFactorCadOriginal(int costId, int employeeId)
        {
            return (Decimal)GetRow(costId, employeeId)["BenefitFactorCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetBenefitFactorUsd
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>      
        /// <returns>BenefitFactorUsd</returns>
        public Decimal GetBenefitFactorUsd(int costId, int employeeId)
        {
            return (Decimal)GetRow(costId, employeeId)["BenefitFactorUsd"];
        }



        /// <summary>
        /// GetBenefitFactorCad Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original BenefitFactorUsd</returns>
        public Decimal GetBenefitFactorUsdOriginal(int costId, int employeeId)
        {
            return (Decimal)GetRow(costId, employeeId)["BenefitFactorUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetHealthBenefitUsd
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>      
        /// <returns>HealthBenefitUsd</returns>
        public Decimal GetHealthBenefitUsd(int costId, int employeeId)
        {
            if (GetRow(costId, employeeId).IsNull("HealthBenefitUsd"))
            {
                return 0;
            }
            else
            {
                return (Decimal)GetRow(costId, employeeId)["HealthBenefitUsd"];
            }
        }



        /// <summary>
        /// GetHealthBenefitUsd Original
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Original HealthBenefitUsd</returns>
        public Decimal GetHealthBenefitUsdOriginal(int costId, int employeeId)
        {
            if (GetRow(costId, employeeId).IsNull(Table.Columns["HealthBenefitUsd"], DataRowVersion.Original))
            {
                return 0;
            }
            else
            {
                return (Decimal)GetRow(costId, employeeId)["HealthBenefitUsd", DataRowVersion.Original];
            }
        }


               
    }
}