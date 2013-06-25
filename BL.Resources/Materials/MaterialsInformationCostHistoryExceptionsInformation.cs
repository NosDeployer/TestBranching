using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Materials;

namespace LiquiForce.LFSLive.BL.Resources.Materials
{
    /// <summary>
    /// MaterialsInformationCostHistoryExceptionsInformation
    /// </summary>
    public class MaterialsInformationCostHistoryExceptionsInformation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsInformationCostHistoryExceptionsInformation()
            : base("CostHistoryExceptionsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsInformationCostHistoryExceptionsInformation(DataSet data)
            : base(data, "CostHistoryExceptionsInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MaterialsInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllByCostId
        /// </summary>
        /// <param name="costId">costId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadAllByCostId(int costId, int companyId)
        {
            MaterialsInformationCostHistoryExceptionsInformationGateway materialsInformationCostHistoryExceptionsInformationGateway = new MaterialsInformationCostHistoryExceptionsInformationGateway(Data);
            materialsInformationCostHistoryExceptionsInformationGateway.LoadAllByCostId(costId, companyId);
        }



        /// <summary>
        /// LoadAllByMaterialId
        /// </summary>
        /// <param name="materialId">materialId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadAllByMaterialId(int materialId, int companyId)
        {
            MaterialsInformationCostHistoryExceptionsInformationGateway materialsInformationCostHistoryExceptionsInformationGateway = new MaterialsInformationCostHistoryExceptionsInformationGateway(Data);
            materialsInformationCostHistoryExceptionsInformationGateway.LoadAllByMaterialId(materialId, companyId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="costCad">costCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="workFunction">workFunction</param>
        public void Insert(int costId, string work_, string function_, string unitOfMeasurement, decimal costCad, decimal costUsd, bool deleted, int companyId, bool inDatabase, string workFunction)
        {
            MaterialsInformationTDS.CostHistoryExceptionsInformationRow row = ((MaterialsInformationTDS.CostHistoryExceptionsInformationDataTable)Table).NewCostHistoryExceptionsInformationRow();

            row.CostID = costId;
            row.RefID = GetNewRefId();
            row.Work_ = work_;
            row.Function_ = function_;
            row.UnitOfMeasurement = unitOfMeasurement;
            row.CostCad = costCad;
            row.CostUsd = costUsd;            
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.WorkFunction = workFunction;

            ((MaterialsInformationTDS.CostHistoryExceptionsInformationDataTable)Table).AddCostHistoryExceptionsInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="costCad">costCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="workFunction">workFunction</param>
        public void Update(int costId, int refId, string work_, string function_, string unitOfMeasurement, decimal costCad, decimal costUsd, string workFunction)
        {
            MaterialsInformationTDS.CostHistoryExceptionsInformationRow row = GetRow(costId, refId);
            row.Work_ = work_;
            row.Function_ = function_;
            row.WorkFunction = workFunction;
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
            MaterialsInformationTDS.CostHistoryExceptionsInformationRow row = GetRow(costId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="costId">costId</param>
        public void DeleteAll(int costId)
        {
            foreach (MaterialsInformationTDS.CostHistoryExceptionsInformationRow row in (MaterialsInformationTDS.CostHistoryExceptionsInformationDataTable)Table)
            {
                row.Deleted = true;
            }
        }



        /// <summary>
        /// Save all materials to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId, int materialId)
        {
            MaterialsInformationTDS costHistoryExceptionsInformationChanges = (MaterialsInformationTDS)Data.GetChanges();

            if (costHistoryExceptionsInformationChanges.CostHistoryExceptionsInformation.Rows.Count > 0)
            {
                MaterialsInformationCostHistoryExceptionsInformationGateway materialsInformationCostHistoryExceptionsInformationGateway = new MaterialsInformationCostHistoryExceptionsInformationGateway(costHistoryExceptionsInformationChanges);

                foreach (MaterialsInformationTDS.CostHistoryExceptionsInformationRow row in (MaterialsInformationTDS.CostHistoryExceptionsInformationDataTable)costHistoryExceptionsInformationChanges.CostHistoryExceptionsInformation)
                {
                    // Insert new costs exceptions 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        MaterialsCostHistoryExceptions materialsCostHistoryExceptions = new MaterialsCostHistoryExceptions(null);
                        materialsCostHistoryExceptions.InsertDirect(row.CostID, row.RefID, materialId, row.Work_, row.Function_, row.UnitOfMeasurement, row.CostCad, row.CostUsd, row.Deleted, row.COMPANY_ID);
                    }

                    // Update costs exceptions
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int costId = row.CostID;
                        int refId = row.RefID;
                        bool originalDeleted = row.Deleted;
                        int originalCompanyId = companyId;

                        // original values
                        string originalWork = materialsInformationCostHistoryExceptionsInformationGateway.GetWork_Original(costId, refId);
                        string originalFunction = materialsInformationCostHistoryExceptionsInformationGateway.GetFunction_Original(costId, refId);
                        string originalUnitOfMeasurement = materialsInformationCostHistoryExceptionsInformationGateway.GetUnitOfMeasurementOriginal(costId, refId);
                        decimal originalCostCad = materialsInformationCostHistoryExceptionsInformationGateway.GetCostCadOriginal(costId, refId);
                        decimal originalCostUsd = materialsInformationCostHistoryExceptionsInformationGateway.GetCostUsdOriginal(costId, refId);

                        // new values
                        string newWork = materialsInformationCostHistoryExceptionsInformationGateway.GetWork_Original(costId, refId);
                        string newFunction = materialsInformationCostHistoryExceptionsInformationGateway.GetFunction_Original(costId, refId);
                        string newUnitOfMeasurement = materialsInformationCostHistoryExceptionsInformationGateway.GetUnitOfMeasurement(costId, refId);
                        decimal newCostCad = materialsInformationCostHistoryExceptionsInformationGateway.GetCostCad(costId, refId);
                        decimal newCostUsd = materialsInformationCostHistoryExceptionsInformationGateway.GetCostUsd(costId, refId);
                        
                        MaterialsCostHistoryExceptions materialsCostHistoryExceptions = new MaterialsCostHistoryExceptions(null);
                        materialsCostHistoryExceptions.UpdateDirect(costId, refId, materialId, originalWork, originalFunction, originalUnitOfMeasurement, originalCostCad, originalCostUsd, originalDeleted, originalCompanyId, costId, refId, materialId, newWork, newFunction, newUnitOfMeasurement, newCostCad, newCostUsd, originalDeleted, originalCompanyId);
                    }

                    // Deleted costs exceptions 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        MaterialsCostHistoryExceptions materialsCostHistoryExceptions = new MaterialsCostHistoryExceptions(null);
                        materialsCostHistoryExceptions.DeleteDirect(row.CostID, row.RefID, row.COMPANY_ID);
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
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <returns>Obtained row</returns>        
        private MaterialsInformationTDS.CostHistoryExceptionsInformationRow GetRow(int costId, int refId)
        {
            MaterialsInformationTDS.CostHistoryExceptionsInformationRow row = ((MaterialsInformationTDS.CostHistoryExceptionsInformationDataTable)Table).FindByCostIDRefID(costId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Resources.MaterialsInformationCostHistoryExceptionsInformation.GetRow");
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

            foreach (MaterialsInformationTDS.CostHistoryExceptionsInformationRow row in (MaterialsInformationTDS.CostHistoryExceptionsInformationDataTable)Table)
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