﻿using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddOtherCostsInformation
    /// </summary>
    public class ProjectCostingSheetAddOtherCostsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetAddOtherCostsInformation()
            : base("OtherCostsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetAddOtherCostsInformation(DataSet data)
            : base(data, "OtherCostsInformation")
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
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="description">description</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workFunction">workFunction</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Insert(int costingSheetId, string work_, string function_, string description, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string workFunction, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetAddTDS.OtherCostsInformationRow row = ((ProjectCostingSheetAddTDS.OtherCostsInformationDataTable)Table).NewOtherCostsInformationRow();

            row.CostingSheetID = costingSheetId;
            row.RefID = GetNewRefId();
            row.Work_ = work_;
            row.Function_ = function_;
            row.Description = description;
            row.UnitOfMeasurement = unitOfMeasurement;
            row.Quantity = quantity;
            row.CostCad = costCad;
            row.TotalCostCad = totalCostCad;
            row.CostUsd = costUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.WorkFunction = workFunction;
            row.StartDate = startDate;
            row.EndDate = endDate;
            
            ((ProjectCostingSheetAddTDS.OtherCostsInformationDataTable)Table).AddOtherCostsInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="description">description</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workFunction">workFunction</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void Update(int costingSheetId, int refId, string work_, string function_, string description, string unitOfMeasurement, double quantity, decimal costCad, decimal totalCostCad, decimal costUsd, decimal totalCostUsd, bool deleted, int companyId, string workFunction, DateTime startDate, DateTime endDate)
        {
            ProjectCostingSheetAddTDS.OtherCostsInformationRow row = GetRow(costingSheetId, refId);

            row.Work_ = work_;
            row.Function_ = function_;
            row.Description = description;
            row.UnitOfMeasurement = unitOfMeasurement;
            row.Quantity = quantity;
            row.CostCad = costCad;
            row.TotalCostCad = totalCostCad;
            row.CostUsd = costUsd;
            row.TotalCostUsd = totalCostUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.WorkFunction = workFunction;
            row.StartDate = startDate;
            row.EndDate = endDate;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refId</param>
        public void Delete(int costingSheetId, int refId)
        {
            ProjectCostingSheetAddTDS.OtherCostsInformationRow row = GetRow(costingSheetId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Other Costs Costing Sheet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId, int costingSheetId)
        {
            ProjectCostingSheetAddTDS otherCostsInformationChanges = (ProjectCostingSheetAddTDS)Data.GetChanges();

            if (otherCostsInformationChanges.OtherCostsInformation.Rows.Count > 0)
            {
                foreach (ProjectCostingSheetAddTDS.OtherCostsInformationRow row in (ProjectCostingSheetAddTDS.OtherCostsInformationDataTable)otherCostsInformationChanges.OtherCostsInformation)
                {
                    // Insert new costing sheet Other Costs 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        ProjectCostingSheetOtherCosts otherCosts = new ProjectCostingSheetOtherCosts(null);
                        otherCosts.InsertDirect(costingSheetId, row.RefID, row.Work_, row.Function_, row.Description, row.UnitOfMeasurement, row.Quantity, row.CostCad, row.TotalCostCad, row.CostUsd, row.TotalCostUsd, row.Deleted, row.COMPANY_ID, row.StartDate, row.EndDate);
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
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private ProjectCostingSheetAddTDS.OtherCostsInformationRow GetRow(int costingSheetId, int refId)
        {
            ProjectCostingSheetAddTDS.OtherCostsInformationRow row = ((ProjectCostingSheetAddTDS.OtherCostsInformationDataTable)Table).FindByCostingSheetIDRefID(costingSheetId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetAddOtherCostsInformation.GetRow");
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

            foreach (ProjectCostingSheetAddTDS.OtherCostsInformationRow row in (ProjectCostingSheetAddTDS.OtherCostsInformationDataTable)Table)
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