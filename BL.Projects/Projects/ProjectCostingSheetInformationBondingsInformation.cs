using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetInformationBondingsInformation
    /// </summary>
    public class ProjectCostingSheetInformationBondingsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetInformationBondingsInformation()
            : base("BondingsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetInformationBondingsInformation(DataSet data)
            : base(data, "BondingsInformation")
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
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="rate">rate</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="bonding">bonding</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Insert(int costingSheetId, int bondingCompanyId, decimal rate, bool deleted, int companyId, string bonding, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.BondingsInformationRow row = ((ProjectCostingSheetInformationTDS.BondingsInformationDataTable)Table).NewBondingsInformationRow();

            row.CostingSheetID = costingSheetId;
            row.BondingCompanyID = bondingCompanyId;
            row.RefID = GetNewRefId();
            row.Rate = rate;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.Bonding = bonding;
            row.StartDate = startDate;
            row.EndDate = endDate;

            ((ProjectCostingSheetInformationTDS.BondingsInformationDataTable)Table).AddBondingsInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        /// <param name="rate">rate</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Update(int costingSheetId, int bondingCompanyId, int refId, decimal rate, bool deleted, int companyId, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetInformationTDS.BondingsInformationRow row = GetRow(costingSheetId, bondingCompanyId, refId);

            row.CostingSheetID = costingSheetId;
            row.BondingCompanyID = bondingCompanyId;
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
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        public void Delete(int costingSheetId, int bondingCompanyId, int refId)
        {
            ProjectCostingSheetInformationTDS.BondingsInformationRow row = GetRow(costingSheetId, bondingCompanyId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Bondings Costing Sheets
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetInformationTDS bondingsInformationChanges = (ProjectCostingSheetInformationTDS)Data.GetChanges();

            if (bondingsInformationChanges.BondingsInformation.Rows.Count > 0)
            {
                ProjectCostingSheetInformationBondingsInformationGateway projectCostingSheetInformationBondingsInformationGateway = new ProjectCostingSheetInformationBondingsInformationGateway(bondingsInformationChanges);

                foreach (ProjectCostingSheetInformationTDS.BondingsInformationRow row in (ProjectCostingSheetInformationTDS.BondingsInformationDataTable)bondingsInformationChanges.BondingsInformation)
                {
                    // Insert new costing sheet Bondings
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCostingSheetBondings bondings = new ProjectCostingSheetBondings(null);
                        bondings.InsertDirect(costingSheetId, row.BondingCompanyID, row.RefID, row.Rate, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate, row.Comment);
                    }

                    // Update costing sheet Bondings
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int bondingCompanyId = row.BondingCompanyID;
                        int refId = row.RefID;
                        bool deleted = false;

                        //original values
                        decimal originalRate = projectCostingSheetInformationBondingsInformationGateway.GetRateOriginal(costingSheetId, bondingCompanyId, refId);
                        DateTime originalStartDate = projectCostingSheetInformationBondingsInformationGateway.GetStartDateOriginal(costingSheetId, bondingCompanyId, refId);
                        DateTime originalEndDate = projectCostingSheetInformationBondingsInformationGateway.GetEndDateOriginal(costingSheetId, bondingCompanyId, refId);

                        //original values
                        decimal newRate = projectCostingSheetInformationBondingsInformationGateway.GetRate(costingSheetId, bondingCompanyId, refId);
                        DateTime newStartDate = projectCostingSheetInformationBondingsInformationGateway.GetStartDate(costingSheetId, bondingCompanyId, refId);
                        DateTime newEndDate = projectCostingSheetInformationBondingsInformationGateway.GetEndDate(costingSheetId, bondingCompanyId, refId);

                        ProjectCostingSheetBondings bondings = new ProjectCostingSheetBondings(null);
                        //bondings.UpdateDirect(costingSheetId, bondingCompanyId, refId, originalRate, deleted, companyId, originalStartDate, originalEndDate, newRate, deleted, companyId, newStartDate, newEndDate);
                    }

                    // Delete costing sheet Bondings 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        /*ProjectCostingSheetBondings bondings = new ProjectCostingSheetBondings(null);
                        bondings.DeleteDirect(row.CostingSheetID, row.BondingCompanyID, row.RefID, row.COMPANY_ID);*/
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
        /// <param name="bondingCompanyId">bondingCompanyId</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private ProjectCostingSheetInformationTDS.BondingsInformationRow GetRow(int costingSheetId, int bondingCompanyId, int refId)
        {
            ProjectCostingSheetInformationTDS.BondingsInformationRow row = ((ProjectCostingSheetInformationTDS.BondingsInformationDataTable)Table).FindByRefIDBondingCompanyIDCostingSheetID(refId, bondingCompanyId, costingSheetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetInformationBondingsInformation.GetRow");
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

            foreach (ProjectCostingSheetInformationTDS.BondingsInformationRow row in (ProjectCostingSheetInformationTDS.BondingsInformationDataTable)Table)
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