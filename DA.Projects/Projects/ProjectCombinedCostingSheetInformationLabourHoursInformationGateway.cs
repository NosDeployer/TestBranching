using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCombinedCostingSheetInformationLabourHoursInformationGateway
    /// </summary>
    public class ProjectCombinedCostingSheetInformationLabourHoursInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCombinedCostingSheetInformationLabourHoursInformationGateway()
            : base("CombinedLabourHoursInformation")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCombinedCostingSheetInformationLabourHoursInformationGateway(DataSet data)
            : base(data, "CombinedLabourHoursInformation")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetInformationTDS();
        }



        /// <summary>
        /// InitAdapter (empty)
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.DataSetTable = "CombinedLabourHoursInformation";
            tableMapping.ColumnMappings.Add("CostingSheetID", "CostingSheetID");
            tableMapping.ColumnMappings.Add("Work_", "Work_");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("LHQuantity", "LHQuantity");
            tableMapping.ColumnMappings.Add("LHUnitOfMeasurement", "LHUnitOfMeasurement");
            tableMapping.ColumnMappings.Add("MealsUnitOfMeasurement", "MealsUnitOfMeasurement");
            tableMapping.ColumnMappings.Add("MealsQuantity", "MealsQuantity");
            tableMapping.ColumnMappings.Add("MotelUnitOfMeasurement", "MotelUnitOfMeasurement");
            tableMapping.ColumnMappings.Add("MotelQuantity", "MotelQuantity");
            tableMapping.ColumnMappings.Add("LHCostCad", "LHCostCad");
            tableMapping.ColumnMappings.Add("MealsCostCad", "MealsCostCad");
            tableMapping.ColumnMappings.Add("MotelCostCad", "MotelCostCad");
            tableMapping.ColumnMappings.Add("TotalCostCad", "TotalCostCad");
            tableMapping.ColumnMappings.Add("LHCostUsd", "LHCostUsd");
            tableMapping.ColumnMappings.Add("MealsCostUsd", "MealsCostUsd");
            tableMapping.ColumnMappings.Add("MotelCostUsd", "MotelCostUsd");
            tableMapping.ColumnMappings.Add("TotalCostUsd", "TotalCostUsd");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("WorkFunction", "WorkFunction");
            tableMapping.ColumnMappings.Add("Function_", "Function_");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("Project", "Project");
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
        /// LoadByCostingSheetId
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByCostingSheetId(int costingSheetId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOMBINEDCOSTINGSHEETINFORMATIONLABOURHOURSINFORMATIONGATEWAY_LOADBYCOSTINGSHEETID", new SqlParameter("@costingSheetId", costingSheetId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int costingSheetId, string work_, int employeeId, int refId)
        {
            string filter = string.Format("CostingSheetID = {0} AND Work_ = '{1}' AND EmployeeID = {2} AND RefID = {3}", costingSheetId, work_, employeeId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectCombinedCostingSheetInformationLabourHoursInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetLHUnitOfMeasurement.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>LHUnitOfMeasurement</returns>
        public string GetLHUnitOfMeasurement(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (string)GetRow(costingSheetId, work_, employeeId, refId)["LHUnitOfMeasurement"];
        }



        /// <summary>
        /// GetLHUnitOfMeasurement Original.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original LHUnitOfMeasurement</returns>
        public string GetLHUnitOfMeasurementOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (string)GetRow(costingSheetId, work_, employeeId, refId)["LHUnitOfMeasurement", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLHQuantity.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>NaLHQuantityme</returns>
        public double GetLHQuantity(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (double)GetRow(costingSheetId, work_, employeeId, refId)["LHQuantity"];
        }



        /// <summary>
        /// GetLHQuantity Original.
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original LHQuantity</returns>
        public double GetLHQuantityOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (double)GetRow(costingSheetId, work_, employeeId, refId)["LHQuantity", DataRowVersion.Original];
        }        



        /// <summary>
        /// GetDeleted
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Deleted</returns>
        public bool GetDeleted(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (bool)GetRow(costingSheetId, work_, employeeId, refId)["Deleted"];
        }



        /// <summary>
        /// GetDeleted Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Deleted</returns>
        public bool GetDeletedOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (bool)GetRow(costingSheetId, work_, employeeId, refId)["Deleted", DataRowVersion.Original];
        }



        /// <summary>
        /// GetMealsUnitOfMeasurement
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>MealsUnitOfMeasurement or EMPTY</returns>
        public string GetMealsUnitOfMeasurement(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull("MealsUnitOfMeasurement"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(costingSheetId, work_, employeeId, refId)["MealsUnitOfMeasurement"];
            }
        }



        /// <summary>
        /// GetMealsUnitOfMeasurement Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MealsUnitOfMeasurement or EMPTY</returns>
        public string GetMealsUnitOfMeasurementOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull(Table.Columns["MealsUnitOfMeasurement"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(costingSheetId, work_, employeeId, refId)["MealsUnitOfMeasurement", DataRowVersion.Original];
            }
        }


        /// <summary>
        /// GetMealsQuantity
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>MealsQuantity or null</returns>
        public int? GetMealsQuantity(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull("MealsQuantity"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(costingSheetId, work_, employeeId, refId)["MealsQuantity"];
            }
        }



        /// <summary>
        /// GetMealsQuantity Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MealsQuantity or null</returns>
        public int? GetMealsQuantityOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull(Table.Columns["MealsQuantity"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(costingSheetId, work_, employeeId, refId)["MealsQuantity", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMotelUnitOfMeasurement
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>MotelUnitOfMeasurement or EMPTY</returns>
        public string GetMotelUnitOfMeasurement(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull("MotelUnitOfMeasurement"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(costingSheetId, work_, employeeId, refId)["MotelUnitOfMeasurement"];
            }
        }



        /// <summary>
        /// GetMotelUnitOfMeasurement Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MotelUnitOfMeasurement or EMPTY</returns>
        public string GetMotelUnitOfMeasurementOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull(Table.Columns["MotelUnitOfMeasurement"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(costingSheetId, work_, employeeId, refId)["MotelUnitOfMeasurement", DataRowVersion.Original];
            }
        }



        /// GetMotelQuantity
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>MotelQuantity or null</returns>
        public int? GetMotelQuantity(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull("MotelQuantity"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(costingSheetId, work_, employeeId, refId)["MotelQuantity"];
            }
        }



        /// <summary>
        /// GetMotelQuantity Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MotelQuantity or null</returns>
        public int? GetMotelQuantityOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull(Table.Columns["MotelQuantity"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(costingSheetId, work_, employeeId, refId)["MotelQuantity", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLHCostCad
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>LHCostCad</returns>
        public decimal GetLHCostCad(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (decimal)GetRow(costingSheetId, work_, employeeId, refId)["LHCostCad"];
        }



        /// <summary>
        /// GetLHCostCad Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original LHCostCad</returns>
        public decimal GetLHCostCadOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (decimal)GetRow(costingSheetId, work_, employeeId, refId)["LHCostCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetMealsCostCad
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>MealsCostCad or null</returns>
        public decimal? GetMealsCostCad(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull("MealsCostCad"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(costingSheetId, work_, employeeId, refId)["MealsCostCad"];
            }
        }



        /// <summary>
        /// GetMealsCostCadOriginal
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MealsCostCad or null</returns>
        public decimal? GetMealsCostCadOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull(Table.Columns["MealsCostCad"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(costingSheetId, work_, employeeId, refId)["MealsCostCad", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// MotelCostCad
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>MotelCostCad or null</returns>
        public decimal? GetMotelCostCad(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull("MotelCostCad"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(costingSheetId, work_, employeeId, refId)["MotelCostCad"];
            }
        }



        /// <summary>
        /// GetMotelCostCad Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MotelCostCad or null</returns>
        public decimal? GetMotelCostCadOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull(Table.Columns["MotelCostCad"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(costingSheetId, work_, employeeId, refId)["MotelCostCad", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTotalCostCad
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>TotalCostCad</returns>
        public decimal GetTotalCostCad(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (decimal)GetRow(costingSheetId, work_, employeeId, refId)["TotalCostCad"];
        }



        /// <summary>
        /// GetTotalCostCad Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original TotalCostCad</returns>
        public decimal GetTotalCostCadOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (decimal)GetRow(costingSheetId, work_, employeeId, refId)["TotalCostCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLHCostUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>LHCostUsd</returns>
        public decimal GetLHCostUsd(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (decimal)GetRow(costingSheetId, work_, employeeId, refId)["LHCostUsd"];
        }



        /// <summary>
        /// GetLHCostUsd Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original LHCostUsd</returns>
        public decimal GetLHCostUsdOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (decimal)GetRow(costingSheetId, work_, employeeId, refId)["LHCostUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetMealsCostUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>MealsCostUsd or null</returns>
        public decimal? GetMealsCostUsd(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull("MealsCostUsd"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(costingSheetId, work_, employeeId, refId)["MealsCostUsd"];
            }
        }



        /// <summary>
        /// GetMealsCostUsdOriginal
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MealsCostUsd or null</returns>
        public decimal? GetMealsCostUsdOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull(Table.Columns["MealsCostUsd"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(costingSheetId, work_, employeeId, refId)["MealsCostUsd", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMotelCostUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>MotelCostUsd or null</returns>
        public decimal? GetMotelCostUsd(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull("MotelCostUsd"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(costingSheetId, work_, employeeId, refId)["MotelCostUsd"];
            }
        }



        /// <summary>
        /// GetMotelCostUsd Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original MotelCostUsd or null</returns>
        public decimal? GetMotelCostUsdOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull(Table.Columns["MotelCostUsd"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(costingSheetId, work_, employeeId, refId)["MotelCostUsd", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTotalCostUsd
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>TotalCostUsd</returns>
        public decimal GetTotalCostUsd(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (decimal)GetRow(costingSheetId, work_, employeeId, refId)["TotalCostUsd"];
        }



        /// <summary>
        /// GetTotalCostUsd Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original TotalCostUsd</returns>
        public decimal GetTotalCostUsdOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (decimal)GetRow(costingSheetId, work_, employeeId, refId)["TotalCostUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetStartDate
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>StartDate</returns>
        public DateTime GetStartDate(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, work_, employeeId, refId)["StartDate"];
        }



        /// <summary>
        /// GetStartDate Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original StartDate</returns>
        public DateTime GetStartDateOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, work_, employeeId, refId)["StartDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetEndDate
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>EndDate</returns>
        public DateTime GetEndDate(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, work_, employeeId, refId)["EndDate"];
        }



        /// <summary>
        /// GetEndDate Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original EndDate</returns>
        public DateTime GetEndDateOriginal(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (DateTime)GetRow(costingSheetId, work_, employeeId, refId)["EndDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetInDatabase
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>InDatabase</returns>
        public bool GetInDatabase(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (bool)GetRow(costingSheetId, work_, employeeId, refId)["InDatabase"];
        }



        /// <summary>
        /// GetFunction_
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Function_ or EMPTY</returns>
        public string GetFunction_(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull("Function_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(costingSheetId, work_, employeeId, refId)["Function_"];
            }
        }



        /// <summary>
        /// GetFunction_ Original
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Function_ or EMPTY</returns>
        public string GetFunction_Original(int costingSheetId, string work_, int employeeId, int refId)
        {
            if (GetRow(costingSheetId, work_, employeeId, refId).IsNull(Table.Columns["Function_"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(costingSheetId, work_, employeeId, refId)["Function_", DataRowVersion.Original];
            }
        }



    }
}