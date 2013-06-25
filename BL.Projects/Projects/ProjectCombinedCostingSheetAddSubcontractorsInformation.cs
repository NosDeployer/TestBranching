using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using System.Collections;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCombinedCostingSheetAddSubcontractorsInformation
    /// </summary>
    public class ProjectCombinedCostingSheetAddSubcontractorsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCombinedCostingSheetAddSubcontractorsInformation()
            : base("CombinedSubcontractorsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCombinedCostingSheetAddSubcontractorsInformation(DataSet data)
            : base(data, "CombinedSubcontractorsInformation")
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
        public void Load(ArrayList projects, DateTime startDate, DateTime endDate, int companyId, int clientId)
        {
            int refId = 0;

            foreach (int projectId in projects)
            {
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);

                string project = projectGateway.GetName(projectId);

                ProjectCostingSheetAddSubcontractorListGateway projectCostingSheetAddSubcontractorListGateway = new ProjectCostingSheetAddSubcontractorListGateway(Data);
                projectCostingSheetAddSubcontractorListGateway.LoadByProjectIdStartDateEndDate(projectId, startDate, endDate, companyId);

                foreach (ProjectCostingSheetAddTDS.SubcontractorListRow subcontractorListRow in (ProjectCostingSheetAddTDS.SubcontractorListDataTable)projectCostingSheetAddSubcontractorListGateway.Table)
                {
                    DateTime newStartDate = new DateTime();
                    newStartDate = startDate;
                    DateTime newEndDate = new DateTime();
                    newEndDate = endDate;

                    ProjectCostingSheetAddOriginalSubcontractorGateway projectCostingSheetAddOriginalSubcontractorGateway = new ProjectCostingSheetAddOriginalSubcontractorGateway(Data);
                    projectCostingSheetAddOriginalSubcontractorGateway.LoadByProjectIdStartDateEndDateSubcontractorId(projectId, newStartDate, newEndDate, subcontractorListRow.SubcontractorID);

                    if (projectCostingSheetAddOriginalSubcontractorGateway.Table.Rows.Count > 0)
                    {
                        foreach (ProjectCostingSheetAddTDS.OriginalSubcontractorRow originalSubcontractorRow in (ProjectCostingSheetAddTDS.OriginalSubcontractorDataTable)projectCostingSheetAddOriginalSubcontractorGateway.Table)
                        {
                            ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationRow newRow = ((ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable)Table).NewCombinedSubcontractorsInformationRow();
                            newRow.CostingSheetID = 0;
                            newRow.SubcontractorID = subcontractorListRow.SubcontractorID;
                            newRow.RefID = refId++;
                            newRow.Quantity = originalSubcontractorRow.Quantity;
                            newRow.CostCad = originalSubcontractorRow.RateCad;
                            newRow.TotalCostCad = (Convert.ToDecimal(originalSubcontractorRow.Quantity) * originalSubcontractorRow.RateCad);
                            newRow.CostUsd = originalSubcontractorRow.RateUsd;
                            newRow.TotalCostUsd = (Convert.ToDecimal(originalSubcontractorRow.Quantity) * originalSubcontractorRow.RateUsd);
                            newRow.Deleted = false;
                            newRow.InDatabase = false;
                            newRow.COMPANY_ID = companyId;
                            newRow.Comment = ""; if (!originalSubcontractorRow.IsCommentNull()) newRow.Comment = originalSubcontractorRow.Comment;
                            newRow.UnitOfMeasurement = subcontractorListRow.UnitOfMeasurement;
                            //newRow.StartDate = newStartDate;
                            newRow.StartDate = originalSubcontractorRow.Date_;
                            newRow.EndDate = newEndDate;
                            newRow.FromDatabase = true;
                            newRow.Subcontractor = originalSubcontractorRow.Subcontractor;
                            newRow.ClientID = clientId;
                            newRow.ProjectID = projectId;
                            newRow.Project = project;
                            ((ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable)Table).AddCombinedSubcontractorsInformationRow(newRow);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
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
        public void Insert(int costingSheetId, int subcontractorId, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, string comment, bool deleted, int companyId, DateTime startDate, DateTime endDate, string subcontractor, int projectId)
        {
            ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationRow row = ((ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable)Table).NewCombinedSubcontractorsInformationRow();

            row.CostingSheetID = costingSheetId;
            row.SubcontractorID = subcontractorId;
            row.RefID = GetNewRefId();
            row.Quantity = quantity;
            row.UnitOfMeasurement = unitOfMeasurement;
            row.CostCad = costCad;
            row.TotalCostCad = totalCostCad;
            row.CostUsd = costUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.Comment = comment;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.FromDatabase = false;
            row.Subcontractor = subcontractor;
            row.ProjectID = projectId;

            ((ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable)Table).AddCombinedSubcontractorsInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
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
        public void Update(int costingSheetId, int subcontractorId, int refId, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string comment, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationRow row = GetRow(costingSheetId, subcontractorId, refId);

            row.Quantity = quantity;
            row.UnitOfMeasurement = unitOfMeasurement;
            row.CostCad = costCad;
            row.TotalCostCad = totalCostCad;
            row.CostUsd = costUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.Comment = comment;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        public void Delete(int costingSheetId, int subcontractorId, int refId)
        {
            ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationRow row = GetRow(costingSheetId, subcontractorId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Subcontractors Costing Sheet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetAddTDS unitsInformationChanges = (ProjectCostingSheetAddTDS)Data.GetChanges();

            if (unitsInformationChanges.CombinedSubcontractorsInformation.Rows.Count > 0)
            {
                foreach (ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationRow row in (ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable)unitsInformationChanges.CombinedSubcontractorsInformation)
                {
                    // Insert new costing sheet Subcontractors 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCombinedCostingSheetSubcontractors projectCostingSheetSubcontractors = new ProjectCombinedCostingSheetSubcontractors(null);
                        projectCostingSheetSubcontractors.InsertDirect(costingSheetId, row.SubcontractorID, row.RefID, row.UnitOfMeasurement, row.Quantity, row.CostCad, row.TotalCostCad, row.CostUsd, row.TotalCostUsd, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.Comment, row.ProjectID);
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
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="refId">refId</param>
        /// <returns>row</returns>
        private ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationRow GetRow(int costingSheetId, int subcontractorId, int refId)
        {
            ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationRow row = ((ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable)Table).FindByCostingSheetIDSubcontractorIDRefID(costingSheetId, subcontractorId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCombinedCostingSheetAddSubcontractorsInformation.GetRow");
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

            foreach (ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationRow row in (ProjectCostingSheetAddTDS.CombinedSubcontractorsInformationDataTable)Table)
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