using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.Vacations
{
    /// <summary>
    /// VacationsInformationDaysInformationGateway
    /// </summary>
    public class VacationsInformationDaysInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsInformationDaysInformationGateway()
            : base("DaysInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsInformationDaysInformationGateway(DataSet data)
            : base(data, "DaysInformation")
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
            tableMapping.DataSetTable = "DaysInformation";
            tableMapping.ColumnMappings.Add("VacationID", "VacationID");
            tableMapping.ColumnMappings.Add("RequestID", "RequestID");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("PaymentType", "PaymentType");
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
        /// LoadByRequestId
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByRequestId(int requestId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSINFORMATIONDAYSINFORMATIONGATEWAY_LOADBYREQUESTID", new SqlParameter("requestId", requestId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByVacationId
        /// </summary>
        /// <param name="vacationId">vacationId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByVacationId(int vacationId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSINFORMATIONDAYSINFORMATIONGATEWAY_LOADBYVACATIONID", new SqlParameter("vacationId", vacationId), new SqlParameter("@companyId", companyId));
            return Data;
        }

        

        // <summary>
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.LabourHours.Vacations.VacationsInformationDaysInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetRequestID
        /// </summary>
        /// <param name="vacationId">vacationId</param>
        /// <returns>RequestID</returns>
        public int GetRequestID(int vacationId)
        {
            return (int)GetRow(vacationId)["RequestID"];
        }



        /// <summary>
        /// GetStartDate
        /// </summary>
        /// <param name="vacationId">vacationId</param>
        /// <returns>StartDate</returns>
        public DateTime GetStartDate(int vacationId)
        {
            return (DateTime)GetRow(vacationId)["StartDate"];
        }



        /// <summary>
        /// GetStartDate Original
        /// </summary>
        /// <param name="vacationId">vacationId</param>        
        /// <returns>Original StartDate</returns>
        public DateTime GetStartDateOriginal(int vacationId)
        {
            return (DateTime)GetRow(vacationId)["StartDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetEndDate
        /// </summary>
        /// <param name="vacationId">vacationId</param>
        /// <returns>EndDate</returns>
        public DateTime GetEndDate(int vacationId)
        {
            return (DateTime)GetRow(vacationId)["EndDate"];
        }



        /// <summary>
        /// GetEndDate Original
        /// </summary>
        /// <param name="vacationId">vacationId</param>        
        /// <returns>Original EndDate</returns>
        public DateTime GetEndDateOriginal(int vacationId)
        {
            return (DateTime)GetRow(vacationId)["EndDate", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDescription
        /// </summary>
        /// <param name="vacationId">vacationId</param>
        /// <returns>Description</returns>
        public string GetDescription(int vacationId)
        {
            return (string)GetRow(vacationId)["Description"];
        }



        /// <summary>
        /// GetDescription Original
        /// </summary>
        /// <param name="vacationId">vacationId</param>
        /// <returns>Original Description</returns>
        public string GetDescriptionOriginal(int vacationId)
        {
            return (string)GetRow(vacationId)["Description", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPaymentType
        /// </summary>
        /// <param name="vacationId">vacationId</param>
        /// <returns>PaymentType</returns>
        public string GetPaymentType(int vacationId)
        {
            return (string)GetRow(vacationId)["PaymentType"];
        }



        /// <summary>
        /// GetPaymentType Original
        /// </summary>
        /// <param name="vacationId">vacationId</param>
        /// <returns>Original PaymentType</returns>
        public string GetPaymentTypeOriginal(int vacationId)
        {
            return (string)GetRow(vacationId)["PaymentType", DataRowVersion.Original];
        }



    }
}