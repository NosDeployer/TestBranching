using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Materials;

namespace LiquiForce.LFSLive.BL.Resources.Materials
{
    /// <summary>
    /// MaterialsInformationCostHistoryInformation
    /// </summary>
    public class MaterialsInformationCostHistoryInformation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsInformationCostHistoryInformation()
            : base("CostHistoryInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsInformationCostHistoryInformation(DataSet data)
            : base(data, "CostHistoryInformation")
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
        /// LoadAllByMaterialId
        /// </summary>
        /// <param name="materialId">materialId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadAllByMaterialId(int materialId, int companyId)
        {
            MaterialsInformationCostHistoryInformationGateway materialsInformationCostHistoryInformationGateway = new MaterialsInformationCostHistoryInformationGateway(Data);
            materialsInformationCostHistoryInformationGateway.LoadAllByMaterialId(materialId, companyId);
        }



        /// <summary>
        /// Insert
        /// </summary>        
        /// <param name="materialId">materialId</param>
        /// <param name="date">date</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="costCad">costCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(int materialId, DateTime date, string unitOfMeasurement, decimal costCad, decimal costUsd, bool deleted, int companyId, bool inDatabase)
        {
            MaterialsInformationTDS.CostHistoryInformationRow row = ((MaterialsInformationTDS.CostHistoryInformationDataTable)Table).NewCostHistoryInformationRow();

            row.CostID = GetNewRefId(); 
            row.MaterialID = materialId;            
            row.Date = date;
            row.UnitOfMeasurement = unitOfMeasurement;
            row.CostCad = costCad;
            row.CostUsd = costUsd;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;

            ((MaterialsInformationTDS.CostHistoryInformationDataTable)Table).AddCostHistoryInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="materialId">materialId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="costCad">costCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="note">note</param>
        public void Update(int costId, int materialId, string unitOfMeasurement, decimal costCad, decimal costUsd, DateTime date)
        {
            MaterialsInformationTDS.CostHistoryInformationRow row = GetRow(costId, materialId);

            row.UnitOfMeasurement = unitOfMeasurement;
            row.CostCad = costCad;
            row.CostUsd = costUsd;
            row.Date = date;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="materialId">materialId</param>
        public void Delete(int costId, int materialId)
        {
            MaterialsInformationTDS.CostHistoryInformationRow row = GetRow(costId, materialId);
            row.Deleted = true;

            MaterialsInformationCostHistoryExceptionsInformation model = new MaterialsInformationCostHistoryExceptionsInformation(Data);
            model.DeleteAll(costId);
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="materialId">materialId</param>
        public void DeleteAll(int materialId)
        {
            foreach (MaterialsInformationTDS.CostHistoryInformationRow row in (MaterialsInformationTDS.CostHistoryInformationDataTable)Table)
            {
                row.Deleted = true;

                // Delete exceptions
                foreach (MaterialsInformationTDS.CostHistoryExceptionsInformationRow rowException in (MaterialsInformationTDS.CostHistoryExceptionsInformationDataTable)Table)
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
            MaterialsInformationTDS costHistoryInformationChanges = (MaterialsInformationTDS)Data.GetChanges();

            if (costHistoryInformationChanges.CostHistoryInformation.Rows.Count > 0)
            {
                MaterialsInformationCostHistoryInformationGateway materialsInformationCostHistoryInformationGateway = new MaterialsInformationCostHistoryInformationGateway(costHistoryInformationChanges);

                foreach (MaterialsInformationTDS.CostHistoryInformationRow row in (MaterialsInformationTDS.CostHistoryInformationDataTable)costHistoryInformationChanges.CostHistoryInformation)
                {
                    // Insert new costs 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        MaterialsCostHistory materialsCostHistory = new MaterialsCostHistory(null);
                        materialsCostHistory.InsertDirect(row.CostID, row.MaterialID, row.Date, row.UnitOfMeasurement, row.CostCad, row.CostUsd, row.Deleted, row.COMPANY_ID);                                               
                    }

                    // Update costs
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int costId = row.CostID;
                        int materialId = row.MaterialID;                        
                        bool originalDeleted = row.Deleted;
                        int originalCompanyId = companyId;

                        // original values
                        DateTime originalDate = materialsInformationCostHistoryInformationGateway.GetDateOriginal(costId, materialId);
                        string originalUnitOfMeasurement = materialsInformationCostHistoryInformationGateway.GetUnitOfMeasurementOriginal(costId, materialId);
                        decimal originalCostCad = materialsInformationCostHistoryInformationGateway.GetCostCadOriginal(costId, materialId);
                        decimal originalCostUsd = materialsInformationCostHistoryInformationGateway.GetCostUsdOriginal(costId, materialId);

                        // new values
                        DateTime newDate = materialsInformationCostHistoryInformationGateway.GetDate(costId, materialId);
                        string newUnitOfMeasurement = materialsInformationCostHistoryInformationGateway.GetUnitOfMeasurement(costId, materialId);
                        decimal newCostCad = materialsInformationCostHistoryInformationGateway.GetCostCad(costId, materialId);
                        decimal newCostUsd = materialsInformationCostHistoryInformationGateway.GetCostUsd(costId, materialId);                        

                        MaterialsCostHistory materialsCostHistory = new MaterialsCostHistory(null);
                        materialsCostHistory.UpdateDirect(costId, materialId, originalDate, originalUnitOfMeasurement, originalCostCad, originalCostUsd, originalDeleted, originalCompanyId, costId, materialId, newDate, newUnitOfMeasurement, newCostCad, newCostUsd, originalDeleted, originalCompanyId);
                    }

                    // Deleted costs 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        MaterialsCostHistory materialsCostHistory = new MaterialsCostHistory(null);
                        materialsCostHistory.DeleteDirect(row.CostID, row.MaterialID, row.COMPANY_ID);
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
        /// <param name="materialId">materialId</param>
        /// <returns>Obtained row</returns>
        private MaterialsInformationTDS.CostHistoryInformationRow GetRow(int costId, int materialId)
        {
            MaterialsInformationTDS.CostHistoryInformationRow row = ((MaterialsInformationTDS.CostHistoryInformationDataTable)Table).FindByCostIDMaterialID(costId, materialId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Resources.MaterialsInformationCostHistoryInformation.GetRow");
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

            foreach (MaterialsInformationTDS.CostHistoryInformationRow row in (MaterialsInformationTDS.CostHistoryInformationDataTable)Table)
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
