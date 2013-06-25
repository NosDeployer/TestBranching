using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetInformationInsurancesInformation
    /// </summary>
    public class ProjectCostingSheetInformationInsurancesInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetInformationInsurancesInformation()
            : base("InsurancesInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetInformationInsurancesInformation(DataSet data)
            : base(data, "InsurancesInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetInformationTDS();
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="rate">rate</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="insurance">insurance</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Insert(int costingSheetId, int insuranceCompanyId, decimal rate, bool deleted, int companyId, string insurance, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.InsurancesInformationRow row = ((ProjectCostingSheetInformationTDS.InsurancesInformationDataTable)Table).NewInsurancesInformationRow();

            row.CostingSheetID = costingSheetId;
            row.InsuranceCompanyID = insuranceCompanyId;
            row.RefID = GetNewRefId();
            row.Rate = rate;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.Insurance = insurance;
            row.StartDate = startDate;
            row.EndDate = endDate;

            ((ProjectCostingSheetInformationTDS.InsurancesInformationDataTable)Table).AddInsurancesInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <param name="rate">rate</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Update(int costingSheetId, int insuranceCompanyId, int refId, decimal rate, bool deleted, int companyId, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.InsurancesInformationRow row = GetRow(costingSheetId, insuranceCompanyId, refId);

            row.CostingSheetID = costingSheetId;
            row.InsuranceCompanyID = insuranceCompanyId;
            row.Rate = rate;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.StartDate = startDate;
            row.EndDate = endDate;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        public void Delete(int costingSheetId, int insuranceCompanyId, int refId)
        {
            ProjectCostingSheetInformationTDS.InsurancesInformationRow row = GetRow(costingSheetId, insuranceCompanyId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Insurances Costing Sheets
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetInformationTDS insurancesInformationChanges = (ProjectCostingSheetInformationTDS)Data.GetChanges();

            if (insurancesInformationChanges.InsurancesInformation.Rows.Count > 0)
            {
                ProjectCostingSheetInformationInsurancesInformationGateway projectCostingSheetInformationInsurancesInformationGateway = new ProjectCostingSheetInformationInsurancesInformationGateway(insurancesInformationChanges);

                foreach (ProjectCostingSheetInformationTDS.InsurancesInformationRow row in (ProjectCostingSheetInformationTDS.InsurancesInformationDataTable)insurancesInformationChanges.InsurancesInformation)
                {
                    // Insert new costing sheet Insurances
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCostingSheetInsurances insurances = new ProjectCostingSheetInsurances(null);
                        insurances.InsertDirect(costingSheetId, row.InsuranceCompanyID, row.RefID, row.Rate, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.Comment);
                    }

                    // Update costing sheet Insurances
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int insuranceCompanyId = row.InsuranceCompanyID;
                        int refId = row.RefID;
                        bool deleted = false;

                        //original values
                        decimal originalRate = projectCostingSheetInformationInsurancesInformationGateway.GetRateOriginal(costingSheetId, insuranceCompanyId, refId);
                        DateTime originalStartDate = projectCostingSheetInformationInsurancesInformationGateway.GetStartDateOriginal(costingSheetId, insuranceCompanyId, refId);
                        DateTime originalEndDate = projectCostingSheetInformationInsurancesInformationGateway.GetEndDateOriginal(costingSheetId, insuranceCompanyId, refId);

                        //original values
                        decimal newRate = projectCostingSheetInformationInsurancesInformationGateway.GetRate(costingSheetId, insuranceCompanyId, refId);
                        DateTime newStartDate = projectCostingSheetInformationInsurancesInformationGateway.GetStartDate(costingSheetId, insuranceCompanyId, refId);
                        DateTime newEndDate = projectCostingSheetInformationInsurancesInformationGateway.GetEndDate(costingSheetId, insuranceCompanyId, refId);

                        ProjectCostingSheetInsurances insurances = new ProjectCostingSheetInsurances(null);
                        //insurances.UpdateDirect(costingSheetId, insuranceCompanyId, refId, originalRate, deleted, companyId, originalStartDate, originalEndDate, newRate, deleted, companyId, newStartDate, newEndDate);
                    }

                    // Delete costing sheet Insurances 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        /*ProjectCostingSheetInsurances insurances = new ProjectCostingSheetInsurances(null);
                        insurances.DeleteDirect(row.CostingSheetID, row.InsuranceCompanyID, row.RefID, row.COMPANY_ID);*/
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
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private ProjectCostingSheetInformationTDS.InsurancesInformationRow GetRow(int costingSheetId, int insuranceCompanyId, int refId)
        {
            ProjectCostingSheetInformationTDS.InsurancesInformationRow row = ((ProjectCostingSheetInformationTDS.InsurancesInformationDataTable)Table).FindByRefIDInsuranceCompanyIDCostingSheetID(refId, insuranceCompanyId, costingSheetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetInformationInsurancesInformation.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>RefID</returns>
        private int GetNewRefId()
        {
            int newRefId = 0;

            foreach (ProjectCostingSheetInformationTDS.InsurancesInformationRow row in (ProjectCostingSheetInformationTDS.InsurancesInformationDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }



    }
}