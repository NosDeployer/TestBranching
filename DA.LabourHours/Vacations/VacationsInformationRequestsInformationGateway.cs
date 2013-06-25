using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.Vacations
{
    /// <summary>
    /// VacationsInformationRequestsInformationGateway
    /// </summary>
    public class VacationsInformationRequestsInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsInformationRequestsInformationGateway()
            : base("RequestsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsInformationRequestsInformationGateway(DataSet data)
            : base(data, "RequestsInformation")
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
            tableMapping.DataSetTable = "RequestsInformation";
            tableMapping.ColumnMappings.Add("RequestID", "RequestID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("TotalPaidVacationDays", "TotalPaidVacationDays");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("EmployeeName", "EmployeeName");
            tableMapping.ColumnMappings.Add("Details", "Details");
            tableMapping.ColumnMappings.Add("RejectReason", "RejectReason");
            tableMapping.ColumnMappings.Add("CancelReason", "CancelReason");
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
        /// LoadByRequestId
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByRequestId(int requestId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSINFORMATIONREQUESTSINFORMATIONGATEWAY_LOADBYREQUESTID", new SqlParameter("requestId", requestId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByState
        /// </summary>
        /// <param name="state">state</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByState(string state, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSINFORMATIONREQUESTSINFORMATIONGATEWAY_LOADBYSTATE", new SqlParameter("state", state), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByEmployeeIdState
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="state">state</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByEmployeeIdState(int employeeId, string state, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSINFORMATIONREQUESTSINFORMATIONGATEWAY_LOADBYEMPLOYEEIDSTATE", new SqlParameter("employeeId", employeeId), new SqlParameter("state", state), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int requestId)
        {
            string filter = string.Format("RequestID = {0}", requestId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.LabourHours.Vacations.VacationsInformationRequestsInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetEmployeeID
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <returns>EmployeeID</returns>
        public int GetEmployeeID(int requestId)
        {
            return (int)GetRow(requestId)["EmployeeID"];
        }



        /// <summary>
        /// GetStartDate
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <returns>StartDate</returns>
        public DateTime GetStartDate(int requestId)
        {
            return (DateTime)GetRow(requestId)["StartDate"];
        }



        /// <summary>
        /// GetStartDate Original
        /// </summary>
        /// <param name="requestId">requestId</param>        
        /// <returns>Original StartDate</returns>
        public DateTime GetStartDateOriginal(int requestId)
        {
            return (DateTime)GetRow(requestId)["StartDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetEndDate
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <returns>EndDate</returns>
        public DateTime GetEndDate(int requestId)
        {
            return (DateTime)GetRow(requestId)["EndDate"];
        }



        /// <summary>
        /// GetEndDate Original
        /// </summary>
        /// <param name="requestId">requestId</param>        
        /// <returns>Original EndDate</returns>
        public DateTime GetEndDateOriginal(int requestId)
        {
            return (DateTime)GetRow(requestId)["EndDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalPaidVacationDays
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <returns>TotalPaidVacationDays</returns>
        public double GetTotalPaidVacationDays(int requestId)
        {
            return (double)GetRow(requestId)["TotalPaidVacationDays"];
        }



        /// <summary>
        /// GetTotalPaidVacationDays Original
        /// </summary>
        /// <param name="requestId">requestId</param>        
        /// <returns>Original TotalPaidVacationDays</returns>
        public double GetTotalPaidVacationDaysOriginal(int requestId)
        {
            return (double)GetRow(requestId)["TotalPaidVacationDays", DataRowVersion.Original];
        }



        /// <summary>
        /// GetState
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <returns>State</returns>
        public string GetState(int requestId)
        {
            return (string)GetRow(requestId)["State"];
        }



        /// <summary>
        /// GetState Original
        /// </summary>
        /// <param name="requestId">requestId</param>        
        /// <returns>Original State</returns>
        public string GetStateOriginal(int requestId)
        {
            return (string)GetRow(requestId)["State", DataRowVersion.Original];
        }



        /// <summary>
        /// GetComments
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <returns>Comments</returns>
        public string GetComments(int requestId)
        {
            return (string)GetRow(requestId)["Comments"];
        }



        /// <summary>
        /// GetComments Original
        /// </summary>
        /// <param name="requestId">requestId</param>        
        /// <returns>Original Comments</returns>
        public string GetCommentsOriginal(int requestId)
        {
            return (string)GetRow(requestId)["Comments", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDetails
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <returns>Details or EMPTY</returns>
        public string GetDetails(int requestId)
        {
            if (GetRow(requestId).IsNull("Details"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(requestId)["Details"];
            }
        }



        /// <summary>
        /// GetDetailsOriginal
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <returns>Details or EMPTY</returns>
        public string GetDetailsOriginal(int requestId)
        {
            if (GetRow(requestId).IsNull(Table.Columns["Details"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(requestId)["Details", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRejectReason
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <returns>RejectReason or EMPTY</returns>
        public string GetRejectReason(int requestId)
        {
            if (GetRow(requestId).IsNull("RejectReason"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(requestId)["RejectReason"];
            }
        }



        /// <summary>
        /// GetDetailsOriginal
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <returns>Details or EMPTY</returns>
        public string GetRejectReasonOriginal(int requestId)
        {
            if (GetRow(requestId).IsNull(Table.Columns["RejectReason"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(requestId)["RejectReason", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCancelReason
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <returns>CancelReason or EMPTY</returns>
        public string GetCancelReason(int requestId)
        {
            if (GetRow(requestId).IsNull("CancelReason"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(requestId)["CancelReason"];
            }
        }



        /// <summary>
        /// GetDetailsOriginal
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <returns>CancelReason or EMPTY</returns>
        public string GetCancelReasonOriginal(int requestId)
        {
            if (GetRow(requestId).IsNull(Table.Columns["CancelReason"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(requestId)["CancelReason", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDeleted
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <returns>Deleted</returns>
        public bool GetDeleted(int requestId)
        {
            return (bool)GetRow(requestId)["Deleted"];
        }



        /// <summary>
        /// GetDeleted Original
        /// </summary>
        /// <param name="requestId">requestId</param>        
        /// <returns>Original Deleted</returns>
        public bool GetDeletedOriginal(int requestId)
        {
            return (bool)GetRow(requestId)["Deleted", DataRowVersion.Original];
        }


                
    }
}