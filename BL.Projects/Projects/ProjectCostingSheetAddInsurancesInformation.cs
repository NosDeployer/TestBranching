using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddInsurancesInformation
    /// </summary>
    public class ProjectCostingSheetAddInsurancesInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetAddInsurancesInformation()
            : base("InsurancesInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetAddInsurancesInformation(DataSet data)
            : base(data, "InsurancesInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetAddTDS();
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void Load(int projectId, DateTime startDate, DateTime endDate, int companyId)
        {
            int refId = 0;

            ProjectCostingSheetAddInsuranceListGateway projectCostingSheetAddInsuranceListGateway = new ProjectCostingSheetAddInsuranceListGateway(Data);
            projectCostingSheetAddInsuranceListGateway.LoadByProjectIdStartDateEndDate(projectId, startDate, endDate, companyId);

            foreach (ProjectCostingSheetAddTDS.InsuranceListRow subcontractorListRow in (ProjectCostingSheetAddTDS.InsuranceListDataTable)projectCostingSheetAddInsuranceListGateway.Table)
            {
                DateTime newStartDate = new DateTime();
                newStartDate = startDate;
                DateTime newEndDate = new DateTime();
                newEndDate = endDate;

                ProjectCostingSheetAddOriginalInsuranceGateway projectCostingSheetAddOriginalInsuranceGateway = new ProjectCostingSheetAddOriginalInsuranceGateway(Data);
                projectCostingSheetAddOriginalInsuranceGateway.LoadByProjectIdStartDateEndDateInsuranceId(projectId, newStartDate, newEndDate, subcontractorListRow.InsuranceCompanyID);

                if (projectCostingSheetAddOriginalInsuranceGateway.Table.Rows.Count > 0)
                {
                    foreach (ProjectCostingSheetAddTDS.OriginalInsuranceRow originalInsuranceRow in (ProjectCostingSheetAddTDS.OriginalInsuranceDataTable)projectCostingSheetAddOriginalInsuranceGateway.Table)
                    {
                        ProjectCostingSheetAddTDS.InsurancesInformationRow newRow = ((ProjectCostingSheetAddTDS.InsurancesInformationDataTable)Table).NewInsurancesInformationRow();
                        newRow.CostingSheetID = 0;
                        newRow.InsuranceCompanyID = subcontractorListRow.InsuranceCompanyID;
                        newRow.RefID = refId++;
                        newRow.Rate = originalInsuranceRow.Rate;
                        newRow.Deleted = false;
                        newRow.InDatabase = false;
                        newRow.COMPANY_ID = companyId;
                        newRow.StartDate = originalInsuranceRow.Date_;
                        newRow.EndDate = newEndDate;
                        newRow.FromDatabase = true;
                        newRow.Insurance = originalInsuranceRow.Insurance;
                        newRow.Comment = ""; if (!originalInsuranceRow.IsCommentNull()) newRow.Comment = originalInsuranceRow.Comment;

                        ((ProjectCostingSheetAddTDS.InsurancesInformationDataTable)Table).AddInsurancesInformationRow(newRow);
                    }
                }
            }
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceId">insuranceId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="comment">comment</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="subcontractor">subcontractor</param>
        public void Insert(int costingSheetId, int insuranceCompanyId, decimal rate, bool deleted, int companyId, DateTime startDate, DateTime endDate, string insurance)
        {
            ProjectCostingSheetAddTDS.InsurancesInformationRow row = ((ProjectCostingSheetAddTDS.InsurancesInformationDataTable)Table).NewInsurancesInformationRow();

            row.CostingSheetID = costingSheetId;
            row.InsuranceCompanyID = insuranceCompanyId;
            row.RefID = GetNewRefId();
            row.Rate = rate;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.FromDatabase = false;
            row.Insurance = insurance;

            ((ProjectCostingSheetAddTDS.InsurancesInformationDataTable)Table).AddInsurancesInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceId">insuranceId</param>
        /// <param name="refId">refId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Update(int costingSheetId, int insuranceCompanyId, int refId, decimal rate, bool deleted, int companyId, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetAddTDS.InsurancesInformationRow row = GetRow(costingSheetId, insuranceCompanyId, refId);

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
        /// <param name="insuranceId">insuranceId</param>
        /// <param name="refId">refId</param>
        public void Delete(int costingSheetId, int insuranceCompanyId, int refId)
        {
            ProjectCostingSheetAddTDS.InsurancesInformationRow row = GetRow(costingSheetId, insuranceCompanyId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Insurances Costing Sheet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetAddTDS changes = (ProjectCostingSheetAddTDS)Data.GetChanges();

            if (changes.InsurancesInformation.Rows.Count > 0)
            {
                foreach (ProjectCostingSheetAddTDS.InsurancesInformationRow row in (ProjectCostingSheetAddTDS.InsurancesInformationDataTable)changes.InsurancesInformation)
                {
                    // Insert new costing sheet Insurances 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCostingSheetInsurances projectCostingSheetInsurances = new ProjectCostingSheetInsurances(null);
                        projectCostingSheetInsurances.InsertDirect(costingSheetId, row.InsuranceCompanyID, row.RefID, row.Rate, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.Comment);
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="insuranceId">insuranceId</param>
        /// <param name="refId">refId</param>
        /// <returns>row</returns>
        private ProjectCostingSheetAddTDS.InsurancesInformationRow GetRow(int costingSheetId, int insuranceCompanyId, int refId)
        {
            ProjectCostingSheetAddTDS.InsurancesInformationRow row = ((ProjectCostingSheetAddTDS.InsurancesInformationDataTable)Table).FindByCostingSheetIDInsuranceCompanyIDRefID(costingSheetId, insuranceCompanyId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetAddInsurancesInformation.GetRow");
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

            foreach (ProjectCostingSheetAddTDS.InsurancesInformationRow row in (ProjectCostingSheetAddTDS.InsurancesInformationDataTable)Table)
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