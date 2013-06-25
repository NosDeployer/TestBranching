using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;

namespace LiquiForce.LFSLive.BL.LabourHours.Vacations
{
    /// <summary>
    /// VacationsSetup
    /// </summary>
    public class VacationsSetup : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsSetup()
            : base("VacationsSetup")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsSetup(DataSet data)
            : base(data, "VacationsSetup")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new VacationsSetupTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByYear
        /// </summary>
        /// <param name="year">year</param>              
        /// <param name="companyId">companyId</param>
        public void LoadByYear(int year, int companyId)
        {
            VacationsSetupGateway vacationsSetupGateway = new VacationsSetupGateway(Data);
            vacationsSetupGateway.LoadByYear(year, companyId);
            UpdateTotalVacations();
        }




        /// <summary>
        /// LoadByYearEmployeeType
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeType">employeeType</param>
        /// <param name="companyId">companyId</param>
        public void LoadByYearEmployeeType(int year, string employeeType, int companyId)
        {
            VacationsSetupGateway vacationsSetupGateway = new VacationsSetupGateway(Data);
            vacationsSetupGateway.LoadByYearEmployeeType(year, employeeType, companyId);
            UpdateTotalVacations();
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="vacationDays">vacationDays</param>
        /// <param name="carryOverDays">carryOverDays</param>        
        public void Update(int year, int employeeId, double vacationDays, double carryOverDays)
        {
            VacationsSetupTDS.VacationsSetupRow row = GetRow(year, employeeId);
            row.VacationDays = vacationDays;
            row.CarryOverDays = carryOverDays;
            row.TotalVacationDays = vacationDays + carryOverDays;
        }



        /// <summary>
        /// Save vacation setup to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            VacationsSetupTDS vacationSetupChanges = (VacationsSetupTDS)Data.GetChanges();

            if (vacationSetupChanges != null)
            {
                if (vacationSetupChanges.VacationsSetup.Rows.Count > 0)
                {
                    VacationsSetupGateway vacationsSetupGateway = new VacationsSetupGateway(vacationSetupChanges);

                    foreach (VacationsSetupTDS.VacationsSetupRow row in (VacationsSetupTDS.VacationsSetupDataTable)vacationSetupChanges.VacationsSetup)
                    {
                        // Insert new vacation setup
                        if (!row.InDatabase)
                        {
                            double totalTakenVacationDays = 0;
                            VacationsEmployeeMaxPaidVacations vacationsEmployeeMaxPaidVacations = new VacationsEmployeeMaxPaidVacations(null);
                            vacationsEmployeeMaxPaidVacations.InsertDirect(row.Year, row.EmployeeID, row.VacationDays, totalTakenVacationDays, row.CarryOverDays, row.TotalVacationDays, false, companyId);
                        }

                        // Update vacation setup
                        if (row.InDatabase)
                        {
                            int year = row.Year;
                            int employeeId = row.EmployeeID;

                            // ... original values
                            double originalVacationDays = vacationsSetupGateway.GetVacationDaysOriginal(year, employeeId);
                            double originalCarryOverDays = vacationsSetupGateway.GetCarryOverDaysOriginal(year, employeeId);
                            double originalTotalVacationDays = vacationsSetupGateway.GetTotalVacationDaysOriginal(year, employeeId);

                            // ... new values
                            double newVacationDays = vacationsSetupGateway.GetVacationDays(year, employeeId);
                            double newCarryOverDays = vacationsSetupGateway.GetCarryOverDays(year, employeeId);
                            double newTotalVacationDays = vacationsSetupGateway.GetTotalVacationDays(year, employeeId);

                            if ((originalVacationDays != newVacationDays) || (originalCarryOverDays != newCarryOverDays))
                            {
                                VacationsEmployeeMaxPaidVacations vacationsEmployeeMaxPaidVacations = new VacationsEmployeeMaxPaidVacations(null);
                                vacationsEmployeeMaxPaidVacations.UpdateDirect(year, employeeId, originalVacationDays, row.TotalTakenVacationDays, originalCarryOverDays, originalTotalVacationDays, false, companyId, year, employeeId, newVacationDays, row.TotalTakenVacationDays, newCarryOverDays, newTotalVacationDays, false, companyId);
                            }
                        }
                    }
                }
            }
        }

        

        /// <summary>
        /// GetSummary
        /// </summary>
        /// <param name="yearToShow">yearToShow</param>
        /// <returns>summary</returns>
        public string GetSummary(int yearToShow)
        {
            string summary = "\n";
            
            DataView dv = Table.DefaultView;
            dv.RowFilter = string.Format("Year = {0}", yearToShow);

            summary += "Period: " + yearToShow.ToString() + "\n";

            foreach (DataRowView row in dv)
            {
                summary += "     " + row["EmployeeName"].ToString() + "\n";
                summary += "\t Entitlement: " + row["VacationDays"].ToString()  + "\n";
                summary += "\t Carry Over: " +  row["CarryOverDays"].ToString() + "\n";
                summary += "\t TOTAL: " + row["TotalVacationDays"].ToString() + "\n\n";
            }

            return summary;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Obtained row</returns>
        private VacationsSetupTDS.VacationsSetupRow GetRow(int year, int employeeId)
        {
            VacationsSetupTDS.VacationsSetupRow row = ((VacationsSetupTDS.VacationsSetupDataTable)Table).FindByYearEmployeeID(year, employeeId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.Vacations.VacationsSetup.GetRow");
            }

            return row;
        }



        /// <summary>
        /// UpdateTotalVacations
        /// </summary>
        private void UpdateTotalVacations()
        {
            foreach (VacationsSetupTDS.VacationsSetupRow row in (VacationsSetupTDS.VacationsSetupDataTable)Table)
            {
                row.TotalVacationDays = row.VacationDays + row.CarryOverDays;
            }
        }

        

    }
}