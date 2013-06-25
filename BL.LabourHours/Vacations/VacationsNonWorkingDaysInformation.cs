using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;

namespace LiquiForce.LFSLive.BL.LabourHours.Vacations
{
    /// <summary>
    /// VacationsNonWorkingDaysInformation
    /// </summary>
    public class VacationsNonWorkingDaysInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsNonWorkingDaysInformation()
            : base("NonWorkingDaysInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsNonWorkingDaysInformation(DataSet data)
            : base(data, "NonWorkingDaysInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new VacationsNonWorkingDaysInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByCompanyLevelId
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadByCompanyLevelId(int companyLevelId, int companyId)
        {
            VacationsNonWorkingDaysInformationGateway vacationsNonWorkingDaysInformationGateway = new VacationsNonWorkingDaysInformationGateway(Data);
            vacationsNonWorkingDaysInformationGateway.LoadByCompanyLevelId(companyLevelId, companyId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="subject">subject</param>
        /// <param name="userId">userId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="note">note</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(DateTime date, int companyLevelId, string description, bool deleted, int companyId, bool inDatabase)
        {
            VacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformationRow row = ((VacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformationDataTable)Table).NewNonWorkingDaysInformationRow();

            row.NonWorkingDayID = GetNonWorkingDayId();
            row.StartDate = date;
            row.CompanyLevelID = companyLevelId;
            row.Description = description;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.EndDate = date;

            ((VacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformationDataTable)Table).AddNonWorkingDaysInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="date">date</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="description">description</param>
        public void Update(int nonWorkingDayId, string description)
        {
            VacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformationRow row = GetRow(nonWorkingDayId);
            row.Description = description;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="date">date</param>
        /// <param name="companyLevelId">companyLevelId</param>
        public void Delete(int nonWorkingDayId)
        {
            VacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformationRow row = GetRow(nonWorkingDayId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all NonWorking Days (direct)
        /// </summary>
        public void Save()
        {
            VacationsNonWorkingDaysInformationTDS nonWorkingDaysInformationChanges = (VacationsNonWorkingDaysInformationTDS)Data.GetChanges();

            if (nonWorkingDaysInformationChanges != null)
            {
                if (nonWorkingDaysInformationChanges.NonWorkingDaysInformation.Rows.Count > 0)
                {
                    VacationsNonWorkingDaysInformationGateway vacationsNonWorkingDaysInformationGateway = new VacationsNonWorkingDaysInformationGateway(nonWorkingDaysInformationChanges);

                    foreach (VacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformationRow row in (VacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformationDataTable)nonWorkingDaysInformationChanges.NonWorkingDaysInformation)
                    {
                        // Insert new NonWorking Day 
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            VacationsNonWorkingDays vacationsNonWorkingDays = new VacationsNonWorkingDays(null);
                            vacationsNonWorkingDays.InsertDirect(row.StartDate, row.CompanyLevelID, row.Description, row.Deleted, row.COMPANY_ID);
                        }

                        // Update NonWorking Day 
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            int originalNonWorkingDayId = row.NonWorkingDayID;
                            DateTime originalDate = row.StartDate;
                            int originalCompanyLevelId = row.CompanyLevelID;
                            bool originalDeleted = false;
                            int originalCompanyId = row.COMPANY_ID;

                            // Original values
                            string originalDescription = vacationsNonWorkingDaysInformationGateway.GetDescriptionOriginal(originalNonWorkingDayId);

                            // New values
                            string newDescription = vacationsNonWorkingDaysInformationGateway.GetDescription(originalNonWorkingDayId);

                            VacationsNonWorkingDays vacationsNonWorkingDays = new VacationsNonWorkingDays(null);
                            vacationsNonWorkingDays.UpdateDirect(originalNonWorkingDayId, originalDate, originalCompanyLevelId, originalDescription, originalDeleted, originalCompanyId, originalDate, originalCompanyLevelId, newDescription, originalDeleted, originalCompanyId);
                        }

                        // Delete NonWorking Day  
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            int originalNonWorkingDayId = row.NonWorkingDayID;

                            VacationsNonWorkingDays vacationsNonWorkingDays = new VacationsNonWorkingDays(null);
                            vacationsNonWorkingDays.DeleteDirect(originalNonWorkingDayId, row.COMPANY_ID);
                        }
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
        /// <param name="nonWorkingDayId">nonWorkingDayId</param>
        /// <returns>Obtained row</returns>
        private VacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformationRow GetRow(int nonWorkingDayId)
        {
            VacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformationRow row = ((VacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformationDataTable)Table).FindByNonWorkingDayID(nonWorkingDayId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.Vacations.VacationsNonWorkingDaysInformation.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNonWorkingDayId
        /// </summary>
        /// <returns>nonWorkingDayId</returns>
        private int GetNonWorkingDayId()
        {
            int nonWorkingDayId = 1;

            foreach (VacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformationRow row in (VacationsNonWorkingDaysInformationTDS.NonWorkingDaysInformationDataTable)Table)
            {
                if (nonWorkingDayId <= row.NonWorkingDayID)
                {
                    nonWorkingDayId = row.NonWorkingDayID + 1;
                }
            }

            return nonWorkingDayId;
        }



    }
}