using System;
using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddLabourHoursInformationGateway
    /// </summary>
    public class ProjectCostingSheetAddLabourHoursInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCostingSheetAddLabourHoursInformationGateway()
            : base("LabourHoursInformation")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCostingSheetAddLabourHoursInformationGateway(DataSet data)
            : base(data, "LabourHoursInformation")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetAddTDS();
        }



        /// <summary>
        /// InitAdapter (empty)
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.DataSetTable = "LabourHoursInformation";
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
            tableMapping.ColumnMappings.Add("FromDatabase", "FromDatabase");
            tableMapping.ColumnMappings.Add("WorkFunction", "WorkFunction");
            tableMapping.ColumnMappings.Add("Function_", "Function_");
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectCostingSheetAddLabourHoursInformationGateway.GetRow");
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
        /// GetFromDatabase
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>FromDatabase</returns>
        public bool GetFromDatabase(int costingSheetId, string work_, int employeeId, int refId)
        {
            return (bool)GetRow(costingSheetId, work_, employeeId, refId)["FromDatabase"];
        }



    }
}