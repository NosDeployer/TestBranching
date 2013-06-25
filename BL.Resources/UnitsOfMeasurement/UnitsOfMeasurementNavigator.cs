using System;
using System.Data;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement;
using LiquiForce.LFSLive.BL.Common;

namespace LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement
{
    /// <summary>
    /// UnitsOfMeasurementNavigator
    /// </summary>
    public class UnitsOfMeasurementNavigator : TableModule
    {
        //// ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsOfMeasurementNavigator()
            : base("UnitsOfMeasurementNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsOfMeasurementNavigator(DataSet data)
            : base(data, "UnitsOfMeasurementNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsOfMeasurementNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAll
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void LoadAll(int companyId)
        {
            UnitsOfMeasurementNavigatorGateway unitsOfMeasurementNavigatorGateway = new UnitsOfMeasurementNavigatorGateway(Data);
            unitsOfMeasurementNavigatorGateway.LoadAll(companyId);
        }



        /// <summary>
        /// Insert a new unit of measurement
        /// </summary>
        /// <param name="description">description</param>
        /// <param name="abreviation">abreviation</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDataBase">inDataBase</param>
        /// <returns>materialId</returns>
        public int Insert(string description, string abreviation, bool deleted, int companyId, bool inDataBase)
        {
            UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorRow row = ((UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorDataTable)Table).NewUnitsOfMeasurementNavigatorRow();

            row.UnitOfMeasurementID = GetNewUnitOfMeasurementId();
            row.Description = description;
            row.Abbreviation = abreviation;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDataBase = inDataBase;

            ((UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorDataTable)Table).AddUnitsOfMeasurementNavigatorRow(row);

            return row.UnitOfMeasurementID;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="unitOfMeasurementId">unitOfMeasurementId</param>
        /// <param name="description">description</param>
        /// <param name="abreviation">abreviation</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>        
        public void Update(int unitOfMeasurementId, string description, string abreviation, bool deleted, int companyId)
        {
            UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorRow row = GetRow(unitOfMeasurementId);

            // General Data            
            row.Description = description;
            row.Abbreviation = abreviation;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="unitOfMeasurementId">unitOfMeasurementId</param>
        public void Delete(int unitOfMeasurementId)
        {
            UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorRow row = GetRow(unitOfMeasurementId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            UnitsOfMeasurementNavigatorTDS unitOfMeasurementAddChanges = (UnitsOfMeasurementNavigatorTDS)Data.GetChanges();

            if (unitOfMeasurementAddChanges != null)
            {
                if (unitOfMeasurementAddChanges.UnitsOfMeasurementNavigator.Rows.Count > 0)
                {
                    UnitsOfMeasurementNavigatorGateway unitsOfMeasurementNavigatorGateway = new UnitsOfMeasurementNavigatorGateway(unitOfMeasurementAddChanges);

                    // Update unit of measurement
                    foreach (UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorRow row in (UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorDataTable)unitOfMeasurementAddChanges.UnitsOfMeasurementNavigator)
                    {
                        int companyId = row.COMPANY_ID;

                        // Insert new unit of measurement 
                        if ((!row.Deleted) && (!row.InDataBase))
                        {                            
                            int unitOfMeasurementId = row.UnitOfMeasurementID;
                            string description = row.Description;
                            string abreviation = row.Abbreviation;
                            bool deleted = row.Deleted;       
                            
                            UnitsOfMeasurement unitsOfMeasurement = new UnitsOfMeasurement(null);                    
                            unitsOfMeasurement.InsertDirect(unitOfMeasurementId, description, abreviation, deleted, companyId);
                        }

                        // Update unit of measurement 
                        if ((!row.Deleted) && (row.InDataBase))
                        {
                            int unitOfMeasurementId = row.UnitOfMeasurementID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            // Original values
                            string originalDescription = unitsOfMeasurementNavigatorGateway.GetDescriptionOriginal(unitOfMeasurementId);
                            string originalAbbreviation = unitsOfMeasurementNavigatorGateway.GetAbbreviationOriginal(unitOfMeasurementId);

                            // New values
                            string newDescription = unitsOfMeasurementNavigatorGateway.GetDescription(unitOfMeasurementId);
                            string newAbbreviation = unitsOfMeasurementNavigatorGateway.GetAbbreviation(unitOfMeasurementId);

                            UnitsOfMeasurement unitsOfMeasurement = new UnitsOfMeasurement(null);
                            unitsOfMeasurement.UpdateDirect(unitOfMeasurementId, originalDescription, originalAbbreviation, originalDeleted, originalCompanyId, unitOfMeasurementId, newDescription, newAbbreviation, originalDeleted, originalCompanyId);
                        }

                        // Delete unit of measurement  
                        if ((row.Deleted) && (row.InDataBase))
                        {
                            UnitsOfMeasurement unitsOfMeasurement = new UnitsOfMeasurement(null);
                            unitsOfMeasurement.DeleteDirect(row.UnitOfMeasurementID, row.COMPANY_ID);
                        }

                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
        /// <summary>
        /// GetNewUnitOfMeasurementId
        /// </summary>
        /// <returns>New ID</returns>
        private int GetNewUnitOfMeasurementId()
        {
            int newId = 0;

            foreach (UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorRow row in (UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorDataTable)Table)
            {
                if (newId < row.UnitOfMeasurementID)
                {
                    newId = row.UnitOfMeasurementID;
                }
            }

            newId++;

            return newId;
        }



        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="unitOfMeasurementId">unitOfMeasurementId</param>
        /// <returns>Obtained row</returns>
        private UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorRow GetRow(int unitOfMeasurementId)
        {
            UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorRow row = ((UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorDataTable)Table).FindByUnitOfMeasurementID(unitOfMeasurementId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementNavigator.GetRow");
            }

            return row;
        }


    }
}