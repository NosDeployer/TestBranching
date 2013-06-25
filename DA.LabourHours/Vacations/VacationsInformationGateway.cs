using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.Vacations
{
    /// <summary>
    /// VacationsInformationGateway
    /// </summary>
    public class VacationsInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsInformationGateway()
            : base("VacationsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsInformationGateway(DataSet data)
            : base(data, "VacationsInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new VacationsInformationTDS();
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
            tableMapping.DataSetTable = "VacationsInformation";
            tableMapping.ColumnMappings.Add("VacationID", "VacationID");
            tableMapping.ColumnMappings.Add("RequestID", "RequestID");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("PaymentType", "PaymentType");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("CompanyId", "CompanyId");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("EmployeeName", "EmployeeName");
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
        /// LoadByEmployeeType
        /// </summary>
        /// <param name="employeeType">employeeType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByEmployeeType(string employeeType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSINFORMATIONGATEWAY_LOADBYEMPLOYEETYPE", new SqlParameter("@employeeType", employeeType), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByEmployeeIdEmployeeType
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="employeeType">employeeType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByEmployeeIdEmployeeType(int employeeId, string employeeType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSINFORMATIONGATEWAY_LOADBYEMPLOYEEIDEMPLOYEETYPE", new SqlParameter("employeeId", employeeId), new SqlParameter("@employeeType", employeeType), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="vacationId">vacationId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int vacationId)
        {
            string filter = string.Format("VacationID = {0}", vacationId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.LabourHours.Vacations.VacationsInformationGateway.GetRow");
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// IsFullVacationDay
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataRow</returns>
        public bool IsFullVacationDay(DateTime startDate, int employeeId, int companyId)
        {
            string commandText = "SELECT     COUNT(*) " +
                " FROM         LFS_VACATION_DAYS AS LVD INNER JOIN " +
                " LFS_VACATION_REQUESTS AS LVR ON LVD.RequestID = LVR.RequestID " +
                " WHERE (LVD.startDate = @date) AND (LVR.EmployeeID = @employeeId) "+
                " AND ((LVD.PaymentType = 'Full Vacation Day') OR (LVD.PaymentType = 'Unpaid Leave Full Day')) "+
                " AND(LVD.Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@date", startDate));
            command.Parameters.Add(new SqlParameter("@employeeId", employeeId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsHalfVacationDay
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataRow</returns>
        public int IsHalfVacationDay(DateTime startDate, int employeeId, int companyId)
        {
            string commandText = "SELECT     COUNT(*) " +
                " FROM         LFS_VACATION_DAYS AS LVD INNER JOIN " +
                " LFS_VACATION_REQUESTS AS LVR ON LVD.RequestID = LVR.RequestID " +
                " WHERE (LVD.startDate = @date) AND (LVR.EmployeeID = @employeeId) " +
                " AND ((LVD.PaymentType = 'Half Vacation Day') OR (LVD.PaymentType = 'Unpaid Leave Half Day')) " +
                " AND(LVD.Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@date", startDate));
            command.Parameters.Add(new SqlParameter("@employeeId", employeeId));

            int result = (int)ExecuteScalar(command);
            return result;
        }



        /// <summary>
        /// ValidateIfExistsAVacation
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>bool</returns>
        public bool ExistsAVacation(DateTime startDate, int employeeId, int companyId)
        {
            string commandText = "SELECT     COUNT(*) " +
                " FROM         LFS_VACATION_DAYS AS LVD INNER JOIN " +
                " LFS_VACATION_REQUESTS AS LVR ON LVD.RequestID = LVR.RequestID " +
                " WHERE (LVD.startDate = @date) AND (LVR.EmployeeID = @employeeId) " +
                " AND(LVD.Deleted = 0) AND (LVR.Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@date", startDate));
            command.Parameters.Add(new SqlParameter("@employeeId", employeeId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }




    }
}