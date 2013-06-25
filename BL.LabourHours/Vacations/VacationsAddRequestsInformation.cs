using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;

namespace LiquiForce.LFSLive.BL.LabourHours.Vacations
{
    /// <summary>
    /// VacationsAddRequestsInformation
    /// </summary>
    public class VacationsAddRequestsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsAddRequestsInformation()
            : base("RequestsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsAddRequestsInformation(DataSet data)
            : base(data, "RequestsInformation")
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
        /// Insert
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="totalPaidVacationDays">totalPaidVacationDays</param>
        /// <param name="state">state</param>
        /// <param name="comments">comments</param>
        /// <param name="details">details</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int employeeId, DateTime startDate, DateTime endDate, double totalPaidVacationDays, string state, string comments, string details, bool deleted, int companyId)
        {
            VacationsAddTDS.RequestsInformationRow row = ((VacationsAddTDS.RequestsInformationDataTable)Table).NewRequestsInformationRow();
            row.RequestID = GetRequestId();
            row.EmployeeID = employeeId;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.TotalPaidVacationDays = totalPaidVacationDays;
            row.State = state;
            if (comments.Trim() != "") row.Comments = comments; else row.SetCommentsNull();
            row.Details = details;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;

            ((VacationsAddTDS.RequestsInformationDataTable)Table).AddRequestsInformationRow(row);
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="oldTotalTakenVacationDays">oldTotalTakenVacationDays</param>
        /// <returns>requestId</returns>
        public int Save(double newTotalTakenVacationDays)
        {
            int requestId = 0;
            VacationsAddTDS vacationsAddChanges = (VacationsAddTDS)Data.GetChanges();

            if (vacationsAddChanges.RequestsInformation.Rows.Count > 0)
            {
                foreach (VacationsAddTDS.RequestsInformationRow row in (VacationsAddTDS.RequestsInformationDataTable)vacationsAddChanges.RequestsInformation)
                {
                    string comments = ""; if (!row.IsCommentsNull()) comments = row.Comments;

                    VacationRequests vacationRequests = new VacationRequests(null);
                    requestId = vacationRequests.InsertDirect(row.EmployeeID, row.StartDate, row.EndDate, row.TotalPaidVacationDays, row.State, comments, row.Details, "", "", row.Deleted, row.COMPANY_ID);

                    VacationsEmployeeMaxPaidVacations vacationsEmployeeMaxPaidVacations = new VacationsEmployeeMaxPaidVacations();
                    vacationsEmployeeMaxPaidVacations.UpdateTotalTakenVacationDays(row.StartDate.Year, row.EmployeeID, newTotalTakenVacationDays);
                }
            }

            return requestId;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRequestId
        /// </summary>
        /// <returns>newRequestId</returns>
        private int GetRequestId()
        {
            int newRequestId = 0;

            foreach (VacationsAddTDS.RequestsInformationRow row in (VacationsAddTDS.RequestsInformationDataTable)Table)
            {
                if (newRequestId < row.RequestID)
                {
                    newRequestId = row.RequestID;
                }
            }

            newRequestId++;

            return newRequestId;
        }



    }
}