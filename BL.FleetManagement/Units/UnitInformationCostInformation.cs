using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitInformationCostInformation
    /// </summary>
    public class UnitInformationCostInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitInformationCostInformation()
            : base("CostInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitInformationCostInformation(DataSet data)
            : base(data, "CostInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadAllByUnitId(int unitId, int companyId)
        {
            UnitInformationCostInformationGateway unitInformationCostInformationGateway = new UnitInformationCostInformationGateway(Data);
            unitInformationCostInformationGateway.LoadAllByUnitId(unitId, companyId);
        }



        /// <summary>
        /// Insert
        /// </summary>        
        /// <param name="unitId">unitId</param>
        /// <param name="date">date</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="costCad">costCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(int unitId, DateTime date, string unitOfMeasurement, decimal costCad, decimal costUsd, bool deleted, int companyId, bool inDatabase)
        {
            UnitInformationTDS.CostInformationRow row = ((UnitInformationTDS.CostInformationDataTable)Table).NewCostInformationRow();

            row.CostID = GetNewRefId();
            row.UnitID = unitId;
            row.Date = date;
            row.UnitOfMeasurement = unitOfMeasurement;
            row.CostCad = costCad;
            row.CostUsd = costUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;

            ((UnitInformationTDS.CostInformationDataTable)Table).AddCostInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="unitId">unitId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="costCad">costCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="note">note</param>
        public void Update(int costId, int unitId, string unitOfMeasurement, decimal costCad, decimal costUsd, DateTime date)
        {
            UnitInformationTDS.CostInformationRow row = GetRow(costId);

            row.UnitOfMeasurement = unitOfMeasurement;
            row.CostCad = costCad;
            row.CostUsd = costUsd;
            row.Date = date;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costId">costId</param>        
        public void Delete(int costId, int unitId)
        {
            UnitInformationTDS.CostInformationRow row = GetRow(costId);
            row.Deleted = true;

            UnitInformationCostExceptionsInformation model = new UnitInformationCostExceptionsInformation(Data);
            model.DeleteAll(costId);
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="unitId">unitId</param>
        public void DeleteAll(int unitId)
        {
            foreach (UnitInformationTDS.CostInformationRow row in (UnitInformationTDS.CostInformationDataTable)Table)
            {
                row.Deleted = true;

                // Delete exceptions
                foreach (UnitInformationTDS.CostExceptionsInformationRow rowException in (UnitInformationTDS.CostExceptionsInformationDataTable)Table)
                {
                    if (row.CostID == rowException.CostID)
                    {
                        rowException.Deleted = true;
                    }
                }
            }
        }



        /// <summary>
        /// Save all costs to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            UnitInformationTDS unitInformationChanges = (UnitInformationTDS)Data.GetChanges();

            if (unitInformationChanges.CostInformation.Rows.Count > 0)
            {
                UnitInformationCostInformationGateway unitInformationCostInformationGateway = new UnitInformationCostInformationGateway(unitInformationChanges);

                foreach (UnitInformationTDS.CostInformationRow row in (UnitInformationTDS.CostInformationDataTable)unitInformationChanges.CostInformation)
                {
                    // Insert new costs 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        UnitsCostHistory unitsCostHistory = new UnitsCostHistory(null);
                        unitsCostHistory.InsertDirect(row.CostID, row.UnitID, row.Date, row.UnitOfMeasurement, row.CostCad, row.CostUsd, row.Deleted, row.COMPANY_ID);
                    }

                    // Update costs
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int costId = row.CostID;
                        int materialId = row.UnitID;
                        bool originalDeleted = row.Deleted;
                        int originalCompanyId = companyId;

                        // original values
                        DateTime originalDate = unitInformationCostInformationGateway.GetDateOriginal(costId);
                        string originalUnitOfMeasurement = unitInformationCostInformationGateway.GetUnitOfMeasurementOriginal(costId);
                        decimal originalCostCad = unitInformationCostInformationGateway.GetCostCadOriginal(costId);
                        decimal originalCostUsd = unitInformationCostInformationGateway.GetCostUsdOriginal(costId);

                        // new values
                        DateTime newDate = unitInformationCostInformationGateway.GetDate(costId);
                        string newUnitOfMeasurement = unitInformationCostInformationGateway.GetUnitOfMeasurement(costId);
                        decimal newCostCad = unitInformationCostInformationGateway.GetCostCad(costId);
                        decimal newCostUsd = unitInformationCostInformationGateway.GetCostUsd(costId);

                        UnitsCostHistory unitsCostHistory = new UnitsCostHistory(null);
                        unitsCostHistory.UpdateDirect(costId, materialId, originalDate, originalUnitOfMeasurement, originalCostCad, originalCostUsd, originalDeleted, originalCompanyId, costId, materialId, newDate, newUnitOfMeasurement, newCostCad, newCostUsd, originalDeleted, originalCompanyId);
                    }

                    // Deleted costs 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        UnitsCostHistory unitsCostHistory = new UnitsCostHistory(null);
                        unitsCostHistory.DeleteDirect(row.CostID, row.UnitID, row.COMPANY_ID);
                    }
                }
            }
        }






        //// ////////////////////////////////////////////////////////////////////////
        //// PRIVATE METHODS
        ////

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="costId">costId</param>        
        /// <returns>Obtained row</returns>
        private UnitInformationTDS.CostInformationRow GetRow(int costId)
        {
            UnitInformationTDS.CostInformationRow row = ((UnitInformationTDS.CostInformationDataTable)Table).FindByCostID(costId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Units.UnitInformationCostInformation.GetRow");
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

            foreach (UnitInformationTDS.CostInformationRow row in (UnitInformationTDS.CostInformationDataTable)Table)
            {
                if (newRefId < row.CostID)
                {
                    newRefId = row.CostID;
                }
            }

            newRefId++;

            return newRefId;
        }

    }
}