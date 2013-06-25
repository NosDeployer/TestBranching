using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddBondingsInformation
    /// </summary>
    public class ProjectCostingSheetAddBondingsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetAddBondingsInformation()
            : base("BondingsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetAddBondingsInformation(DataSet data)
            : base(data, "BondingsInformation")
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

            ProjectCostingSheetAddBondingListGateway projectCostingSheetAddBondingListGateway = new ProjectCostingSheetAddBondingListGateway(Data);
            projectCostingSheetAddBondingListGateway.LoadByProjectIdStartDateEndDate(projectId, startDate, endDate, companyId);

            foreach (ProjectCostingSheetAddTDS.BondingListRow subcontractorListRow in (ProjectCostingSheetAddTDS.BondingListDataTable)projectCostingSheetAddBondingListGateway.Table)
            {
                DateTime newStartDate = new DateTime();
                newStartDate = startDate;
                DateTime newEndDate = new DateTime();
                newEndDate = endDate;

                ProjectCostingSheetAddOriginalBondingGateway projectCostingSheetAddOriginalBondingGateway = new ProjectCostingSheetAddOriginalBondingGateway(Data);
                projectCostingSheetAddOriginalBondingGateway.LoadByProjectIdStartDateEndDateBondingId(projectId, newStartDate, newEndDate, subcontractorListRow.BondingCompanyID);

                if (projectCostingSheetAddOriginalBondingGateway.Table.Rows.Count > 0)
                {
                    foreach (ProjectCostingSheetAddTDS.OriginalBondingRow originalBondingRow in (ProjectCostingSheetAddTDS.OriginalBondingDataTable)projectCostingSheetAddOriginalBondingGateway.Table)
                    {
                        ProjectCostingSheetAddTDS.BondingsInformationRow newRow = ((ProjectCostingSheetAddTDS.BondingsInformationDataTable)Table).NewBondingsInformationRow();
                        newRow.CostingSheetID = 0;
                        newRow.BondingCompanyID = subcontractorListRow.BondingCompanyID;
                        newRow.RefID = refId++;
                        newRow.Rate = originalBondingRow.Rate;
                        newRow.Deleted = false;
                        newRow.InDatabase = false;
                        newRow.COMPANY_ID = companyId;
                        newRow.StartDate = originalBondingRow.Date_;
                        newRow.EndDate = newEndDate;
                        newRow.FromDatabase = true;
                        newRow.Bonding = originalBondingRow.Bonding;
                        newRow.Comment = ""; if (!originalBondingRow.IsCommentNull()) newRow.Comment = originalBondingRow.Comment;

                        ((ProjectCostingSheetAddTDS.BondingsInformationDataTable)Table).AddBondingsInformationRow(newRow);
                    }
                }
            }
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="bondingId">bondingId</param>
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
        public void Insert(int costingSheetId, int bondingCompanyId, decimal rate, bool deleted, int companyId, DateTime startDate, DateTime endDate, string bonding)
        {
            ProjectCostingSheetAddTDS.BondingsInformationRow row = ((ProjectCostingSheetAddTDS.BondingsInformationDataTable)Table).NewBondingsInformationRow();

            row.CostingSheetID = costingSheetId;
            row.BondingCompanyID = bondingCompanyId;
            row.RefID = GetNewRefId();
            row.Rate = rate;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.StartDate = startDate;
            row.EndDate = endDate;
            row.FromDatabase = false;
            row.Bonding = bonding;

            ((ProjectCostingSheetAddTDS.BondingsInformationDataTable)Table).AddBondingsInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="bondingId">bondingId</param>
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
        public void Update(int costingSheetId, int bondingCompanyId, int refId, decimal rate, bool deleted, int companyId, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetAddTDS.BondingsInformationRow row = GetRow(costingSheetId, bondingCompanyId, refId);

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
        /// <param name="bondingId">bondingId</param>
        /// <param name="refId">refId</param>
        public void Delete(int costingSheetId, int bondingCompanyId, int refId)
        {
            ProjectCostingSheetAddTDS.BondingsInformationRow row = GetRow(costingSheetId, bondingCompanyId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Bondings Costing Sheet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetAddTDS changes = (ProjectCostingSheetAddTDS)Data.GetChanges();

            if (changes.BondingsInformation.Rows.Count > 0)
            {
                foreach (ProjectCostingSheetAddTDS.BondingsInformationRow row in (ProjectCostingSheetAddTDS.BondingsInformationDataTable)changes.BondingsInformation)
                {
                    // Insert new costing sheet Bondings 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCostingSheetBondings projectCostingSheetBondings = new ProjectCostingSheetBondings(null);
                        projectCostingSheetBondings.InsertDirect(costingSheetId, row.BondingCompanyID, row.RefID, row.Rate, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.Comment);
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
        /// <param name="bondingId">bondingId</param>
        /// <param name="refId">refId</param>
        /// <returns>row</returns>
        private ProjectCostingSheetAddTDS.BondingsInformationRow GetRow(int costingSheetId, int bondingCompanyId, int refId)
        {
            ProjectCostingSheetAddTDS.BondingsInformationRow row = ((ProjectCostingSheetAddTDS.BondingsInformationDataTable)Table).FindByCostingSheetIDBondingCompanyIDRefID(costingSheetId, bondingCompanyId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetAddBondingsInformation.GetRow");
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

            foreach (ProjectCostingSheetAddTDS.BondingsInformationRow row in (ProjectCostingSheetAddTDS.BondingsInformationDataTable)Table)
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