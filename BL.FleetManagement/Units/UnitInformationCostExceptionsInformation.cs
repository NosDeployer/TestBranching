using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.BL.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitInformationCostExceptionsInformation
    /// </summary>
    public class UnitInformationCostExceptionsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitInformationCostExceptionsInformation()
            : base("CostExceptionsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitInformationCostExceptionsInformation(DataSet data)
            : base(data, "CostExceptionsInformation")
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
            UnitInformationCostExceptionsInformationGateway unitInformationCostExceptionsInformationGateway = new UnitInformationCostExceptionsInformationGateway(Data);
            unitInformationCostExceptionsInformationGateway.LoadAllByUnitId(unitId, companyId);
        }



        ///// <summary>
        ///// Insert
        ///// </summary>
        /// <param name="costId">costId</param>
        /// <param name="work_">work_</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="costCad">costCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(int costId, string work_, string unitOfMeasurement, decimal costCad, decimal costUsd, bool deleted, int companyId, bool inDatabase)
        {
            UnitInformationTDS.CostExceptionsInformationRow row = ((UnitInformationTDS.CostExceptionsInformationDataTable)Table).NewCostExceptionsInformationRow();

            row.CostID = costId;
            row.RefID = GetNewRefId();
            row.Work_ = work_;            
            row.UnitOfMeasurement = unitOfMeasurement;
            row.CostCad = costCad;
            row.CostUsd = costUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.UnitID = 0;

            ((UnitInformationTDS.CostExceptionsInformationDataTable)Table).AddCostExceptionsInformationRow(row);
        }




        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <param name="work_">work_</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="costCad">costCad</param>
        /// <param name="costUsd">costUsd</param>        
        public void Update(int costId, int refId, string work_, string unitOfMeasurement, decimal costCad, decimal costUsd)
        {
            UnitInformationTDS.CostExceptionsInformationRow row = GetRow(costId, refId);
            row.Work_ = work_;
            row.UnitOfMeasurement = unitOfMeasurement;
            row.CostCad = costCad;
            row.CostUsd = costUsd;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costId">costId</param> 
        /// <param name="refId">refId</param>
        public void Delete(int costId, int refId)
        {
            UnitInformationTDS.CostExceptionsInformationRow row = GetRow(costId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="unitId">unitId</param>
        public void DeleteAll(int unitId)
        {
            foreach (UnitInformationTDS.CostExceptionsInformationRow row in (UnitInformationTDS.CostExceptionsInformationDataTable)Table)
            {
                if (row.UnitID == unitId)
                {
                    row.Deleted = true;
                }
            }
        }



        /// <summary>
        /// Save all unit to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId, int unitId)
        {
            UnitInformationTDS costExceptionsInformationChanges = (UnitInformationTDS)Data.GetChanges();

            if (costExceptionsInformationChanges.CostExceptionsInformation.Rows.Count > 0)
            {
                UnitInformationCostExceptionsInformationGateway unitInformationCostExceptionsInformationGateway = new UnitInformationCostExceptionsInformationGateway(costExceptionsInformationChanges);

                foreach (UnitInformationTDS.CostExceptionsInformationRow row in (UnitInformationTDS.CostExceptionsInformationDataTable)costExceptionsInformationChanges.CostExceptionsInformation)
                {
                    // Insert new costs exceptions 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        UnitsCostHistoryExceptions unitsCostHistoryExceptions = new UnitsCostHistoryExceptions(null);
                        unitsCostHistoryExceptions.InsertDirect(row.CostID, row.RefID, unitId, row.Work_, row.UnitOfMeasurement, row.CostCad, row.CostUsd, row.Deleted, row.COMPANY_ID);
                    }

                    // Update costs exceptions
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int costId = row.CostID;
                        int refId = row.RefID;
                        bool originalDeleted = row.Deleted;
                        int originalCompanyId = companyId;

                        // original values
                        string originalWork = unitInformationCostExceptionsInformationGateway.GetWork_Original(costId, refId);                        
                        string originalUnitOfMeasurement = unitInformationCostExceptionsInformationGateway.GetUnitOfMeasurementOriginal(costId, refId);
                        decimal originalCostCad = unitInformationCostExceptionsInformationGateway.GetCostCadOriginal(costId, refId);
                        decimal originalCostUsd = unitInformationCostExceptionsInformationGateway.GetCostUsdOriginal(costId, refId);

                        // new values
                        string newWork = unitInformationCostExceptionsInformationGateway.GetWork_Original(costId, refId);                        
                        string newUnitOfMeasurement = unitInformationCostExceptionsInformationGateway.GetUnitOfMeasurement(costId, refId);
                        decimal newCostCad = unitInformationCostExceptionsInformationGateway.GetCostCad(costId, refId);
                        decimal newCostUsd = unitInformationCostExceptionsInformationGateway.GetCostUsd(costId, refId);

                        UnitsCostHistoryExceptions unitsCostHistoryExceptions = new UnitsCostHistoryExceptions(null);
                        unitsCostHistoryExceptions.UpdateDirect(costId, refId, unitId, originalWork, originalUnitOfMeasurement, originalCostCad, originalCostUsd, originalDeleted, originalCompanyId, costId, refId, unitId, newWork, newUnitOfMeasurement, newCostCad, newCostUsd, originalDeleted, originalCompanyId);
                    }

                    // Deleted costs exceptions 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        UnitsCostHistoryExceptions unitsCostHistoryExceptions = new UnitsCostHistoryExceptions(null);
                        unitsCostHistoryExceptions.DeleteDirect(row.CostID, row.RefID, row.COMPANY_ID);
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
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private UnitInformationTDS.CostExceptionsInformationRow GetRow(int costId, int refId)
        {
            UnitInformationTDS.CostExceptionsInformationRow row = ((UnitInformationTDS.CostExceptionsInformationDataTable)Table).FindByCostIDRefID(costId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Units.UnitInformationCostExceptionsInformation.GetRow");
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

            foreach (UnitInformationTDS.CostExceptionsInformationRow row in (UnitInformationTDS.CostExceptionsInformationDataTable)Table)
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