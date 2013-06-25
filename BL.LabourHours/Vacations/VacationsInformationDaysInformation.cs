using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;

namespace LiquiForce.LFSLive.BL.LabourHours.Vacations
{
    /// <summary>
    /// VacationsInformationDaysInformation
    /// </summary>
    public class VacationsInformationDaysInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsInformationDaysInformation()
            : base("DaysInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsInformationDaysInformation(DataSet data)
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






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByRequestId
        /// </summary>
        /// <param name="requestId">requestId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByRequestId(int requestId, int companyId)
        {
            VacationsInformationDaysInformationGateway vacationsInformationDaysInformationGateway = new VacationsInformationDaysInformationGateway(Data);
            vacationsInformationDaysInformationGateway.LoadByRequestId(requestId, companyId);
        }



        /// <summary>
        /// LoadByVacationId
        /// </summary>
        /// <param name="vacationId">vacationId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByVacationId(int vacationId, int companyId)
        {
            VacationsInformationDaysInformationGateway vacationsInformationDaysInformationGateway = new VacationsInformationDaysInformationGateway(Data);
            vacationsInformationDaysInformationGateway.LoadByVacationId(vacationId, companyId);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

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
            VacationsInformationTDS.DaysInformationRow row = ((VacationsInformationTDS.DaysInformationDataTable)Table).NewDaysInformationRow();
            row.VacationID = GetVacationId();
            row.RequestID = requestId;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.Description = description;
            row.PaymentType = paymentType;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;

            ((VacationsInformationTDS.DaysInformationDataTable)Table).AddDaysInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="vacationId">vacationId</param>
        /// <param name="paymentType">paymentType</param>
        public void Update(int vacationId, string paymentType)
        {
            VacationsInformationTDS.DaysInformationRow row = GetRow(vacationId);
            row.PaymentType = paymentType;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="vacationId">vacationId</param>
        public void Delete(int vacationId)
        {
            VacationsInformationTDS.DaysInformationRow row = GetRow(vacationId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            VacationsInformationTDS vacationsInformationChanges = (VacationsInformationTDS)Data.GetChanges();

            if (vacationsInformationChanges.DaysInformation.Rows.Count > 0)
            {
                VacationsInformationDaysInformationGateway vacationsInformationDaysInformationGateway = new VacationsInformationDaysInformationGateway(vacationsInformationChanges);

                foreach (VacationsInformationTDS.DaysInformationRow row in (VacationsInformationTDS.DaysInformationDataTable)vacationsInformationChanges.DaysInformation)
                {
                    // Insert new vacation day 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        int requestId = row.RequestID;

                        VacationDays vacationDays = new VacationDays(null);
                        vacationDays.InsertDirect(requestId, row.StartDate, row.EndDate, row.Description, row.PaymentType, row.Deleted, row.COMPANY_ID);
                    }

                    // Update vacation day
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int vacationId = row.VacationID;
                        int requestId = row.RequestID;
                        bool deleted = row.Deleted;
                        int companyId = row.COMPANY_ID;

                        // original values
                        DateTime originalStartDate = vacationsInformationDaysInformationGateway.GetStartDateOriginal(vacationId);
                        DateTime originalEndDate = vacationsInformationDaysInformationGateway.GetEndDateOriginal(vacationId);
                        string originalDescription = vacationsInformationDaysInformationGateway.GetDescriptionOriginal(vacationId);
                        string originalPaymentType = vacationsInformationDaysInformationGateway.GetPaymentTypeOriginal(vacationId);

                        // new values
                        DateTime newStartDate = vacationsInformationDaysInformationGateway.GetStartDate(vacationId);
                        DateTime newEndDate = vacationsInformationDaysInformationGateway.GetEndDate(vacationId);
                        string newDescription = vacationsInformationDaysInformationGateway.GetDescription(vacationId);
                        string newPaymentType = vacationsInformationDaysInformationGateway.GetPaymentType(vacationId);

                        VacationDays vacationDays = new VacationDays(null);
                        vacationDays.UpdateDirect(vacationId, requestId, originalStartDate, originalEndDate, originalDescription, originalPaymentType, deleted, companyId, vacationId, requestId, newStartDate, newEndDate, newDescription, newPaymentType, deleted, companyId);
                    }

                    // Delete vacation day 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        VacationDays vacationDays = new VacationDays(null);
                        vacationDays.DeleteDirect(row.VacationID);
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
        private VacationsInformationTDS.DaysInformationRow GetRow(int vacationId)
        {
            VacationsInformationTDS.DaysInformationRow row = ((VacationsInformationTDS.DaysInformationDataTable)Table).FindByVacationID(vacationId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.Vacations.VacationsInformationDaysInformation.GetRow");
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

            foreach (VacationsInformationTDS.DaysInformationRow row in (VacationsInformationTDS.DaysInformationDataTable)Table)
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