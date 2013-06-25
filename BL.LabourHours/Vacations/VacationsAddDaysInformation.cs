using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;

namespace LiquiForce.LFSLive.BL.LabourHours.Vacations
{
    /// <summary>
    /// VacationsAddDaysInformation
    /// </summary>
    public class VacationsAddDaysInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsAddDaysInformation()
            : base("DaysInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsAddDaysInformation(DataSet data)
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






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadDataForVacationsAdd
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public void LoadDataForVacationsAdd(int companyLevelId, int employeeId, int companyId)
        {
            VacationsAddDaysInformationGateway vacationsAddDaysInformationGateway = new VacationsAddDaysInformationGateway(Data);
            vacationsAddDaysInformationGateway.ClearBeforeFill = false;
            vacationsAddDaysInformationGateway.LoadNonWorkingDaysByCompanyLevelId(companyLevelId, companyId);
            vacationsAddDaysInformationGateway.LoadPreviousVacations(employeeId, companyId);
            vacationsAddDaysInformationGateway.ClearBeforeFill = true;
        }

        /// <summary>
        /// LoadNonWorkingDays
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void LoadNonWorkingDays(int companyId)
        {
            VacationsAddDaysInformationGateway vacationsAddDaysInformationGateway = new VacationsAddDaysInformationGateway(Data);
            vacationsAddDaysInformationGateway.ClearBeforeFill = false;
            vacationsAddDaysInformationGateway.LoadNonWorkingDays(companyId);
            vacationsAddDaysInformationGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// LoadNonWorkingDaysByCompanyLevelId
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>        
        public void LoadNonWorkingDaysByCompanyLevelId(int companyLevelId, int companyId)
        {
            VacationsAddDaysInformationGateway vacationsAddDaysInformationGateway = new VacationsAddDaysInformationGateway(Data);
            vacationsAddDaysInformationGateway.ClearBeforeFill = false;
            vacationsAddDaysInformationGateway.LoadNonWorkingDaysByCompanyLevelId(companyLevelId, companyId);
            vacationsAddDaysInformationGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// LoadPreviousVacations
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public void LoadPreviousVacations(int employeeId, int companyId)
        {
            VacationsAddDaysInformationGateway vacationsAddDaysInformationGateway = new VacationsAddDaysInformationGateway(Data);
            vacationsAddDaysInformationGateway.ClearBeforeFill = false;
            vacationsAddDaysInformationGateway.LoadPreviousVacations(employeeId, companyId);
            vacationsAddDaysInformationGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="description">description</param>
        /// <param name="paymentType">paymentType</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int requestId, DateTime startDate, DateTime endDate, string description, string paymentType, bool deleted, int companyId)
        {
            VacationsAddTDS.DaysInformationRow row = ((VacationsAddTDS.DaysInformationDataTable)Table).NewDaysInformationRow();
            row.VacationID = GetVacationId();
            row.RequestID = requestId;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.Description = description;
            row.PaymentType = paymentType;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;

            ((VacationsAddTDS.DaysInformationDataTable)Table).AddDaysInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="vacationId">vacationId</param>
        /// <param name="paymentType">paymentType</param>
        public void Update(int vacationId, string paymentType)
        {
            VacationsAddTDS.DaysInformationRow row = GetRow(vacationId);
            row.PaymentType = paymentType;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="vacationId">vacationId</param>
        public void Delete(int vacationId)
        {
            VacationsAddTDS.DaysInformationRow row = GetRow(vacationId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="requestId">requestId</param>
        public void Save(int requestId)
        {
            VacationsAddTDS vacationsAddChanges = (VacationsAddTDS)Data.GetChanges();

            if (vacationsAddChanges.DaysInformation.Rows.Count > 0)
            {
                foreach (VacationsAddTDS.DaysInformationRow row in (VacationsAddTDS.DaysInformationDataTable)vacationsAddChanges.DaysInformation)
                {
                    // Insert
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        VacationDays vacationDays = new VacationDays(null);
                        vacationDays.InsertDirect(requestId, row.StartDate, row.EndDate, row.Description, row.PaymentType, row.Deleted, row.COMPANY_ID);
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="vacationId">vacationId</param>
        /// <returns>Obtained row</returns>
        private VacationsAddTDS.DaysInformationRow GetRow(int vacationId)
        {
            VacationsAddTDS.DaysInformationRow row = ((VacationsAddTDS.DaysInformationDataTable)Table).FindByVacationID(vacationId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.Vacations.VacationsAddDaysInformation.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetVacationId
        /// </summary>
        /// <returns>newVacationId</returns>
        private int GetVacationId()
        {
            int newVacationId = 0;

            foreach (VacationsAddTDS.DaysInformationRow row in (VacationsAddTDS.DaysInformationDataTable)Table)
            {
                if (newVacationId < row.VacationID)
                {
                    newVacationId = row.VacationID;
                }
            }

            newVacationId++;

            return newVacationId;
        }



    }
}