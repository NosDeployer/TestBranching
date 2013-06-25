using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.Vacations
{
    /// <summary>
    /// VacationsAddDaysInformationGateway
    /// </summary>
    public class VacationsAddDaysInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsAddDaysInformationGateway()
            : base("DaysInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsAddDaysInformationGateway(DataSet data)
            : base(data, "DaysInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new VacationsAddTDS();
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
        /// LoadNonWorkingDays
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadNonWorkingDays(int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSADDDAYSINFORMATIONGATEWAY_LOADNONWORKINGDAYS", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadNonWorkingDaysByCompanyLevelId
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadNonWorkingDaysByCompanyLevelId(int companyLevelId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSADDDAYSINFORMATIONGATEWAY_LOADNONWORKINGDAYSBYCOMPANYLEVELID", new SqlParameter("companyLevelId", companyLevelId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadPreviousVacations
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadPreviousVacations(int employeeId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_VACATIONSADDDAYSINFORMATIONGATEWAY_LOADPREVIOUSVACATIONSBYEMPLOYEEID", new SqlParameter("employeeId", employeeId), new SqlParameter("@companyId", companyId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.LabourHours.Vacations.VacationsAddDaysInformationGateway.GetRow");
            }
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
        /// GetInDatabase
        /// </summary>
        /// <param name="vacationId">vacationId</param>
        /// <returns>InDatabase</returns>
        public bool GetInDatabase(int vacationId)
        {
            return (bool)GetRow(vacationId)["InDatabase"];
        }



    }
}