using System;
using System.Data;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement;
using LiquiForce.LFSLive.BL.Common;

namespace LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement
{
    /// <summary>
    /// UnitsOfMeasurementAssociationsToolAssociatedUnits
    /// </summary>
    public class UnitsOfMeasurementAssociationsToolAssociatedUnits: TableModule
    {
        //// ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsOfMeasurementAssociationsToolAssociatedUnits()
            : base("AssociatedUnits")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsOfMeasurementAssociationsToolAssociatedUnits(DataSet data)
            : base(data, "AssociatedUnits")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsOfMeasurementAssociationsToolTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAll
        /// </summary>
        /// <param name="module">module</param>
        /// <param name="companyId">companyId</param>          
        public void LoadAll(string module, int companyId)
        {
            UnitsOfMeasurementAssociationsToolAssociatedUnitsGateway unitsOfMeasurementAssociationsToolAssociatedUnitsGateway = new UnitsOfMeasurementAssociationsToolAssociatedUnitsGateway(Data);
            unitsOfMeasurementAssociationsToolAssociatedUnitsGateway.LoadAll(module, companyId);
        }



        /// <summary>
        /// Update associations
        /// </summary>
        /// <param name="associationsId">associationsId</param>
        /// <param name="byDefault">byDefault</param>
        /// <param name="selected">selected</param>
        /// <returns>materialId</returns>
        public void Update(int associationsId, bool byDefault, bool selected)
        {
            // Update
            UnitsOfMeasurementAssociationsToolTDS.AssociatedUnitsRow row = GetRow(associationsId);
            row.ByDefault = byDefault;
            row.Selected = selected;

            // Delete
            if ((!selected) && (row.InDataBase))
            {
                row.Deleted = true;
            }
        }
            

        
        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            UnitsOfMeasurementAssociationsToolTDS unitsOfMeasurementAssociationsToolAddChanges = (UnitsOfMeasurementAssociationsToolTDS)Data.GetChanges();

            if (unitsOfMeasurementAssociationsToolAddChanges != null)
            {
                if (unitsOfMeasurementAssociationsToolAddChanges.AssociatedUnits.Rows.Count > 0)
                {
                    UnitsOfMeasurementAssociationsToolAssociatedUnitsGateway unitsOfMeasurementAssociationsToolAssociatedUnitsGateway = new UnitsOfMeasurementAssociationsToolAssociatedUnitsGateway(unitsOfMeasurementAssociationsToolAddChanges);

                    // Update associations
                    foreach (UnitsOfMeasurementAssociationsToolTDS.AssociatedUnitsRow row in (UnitsOfMeasurementAssociationsToolTDS.AssociatedUnitsDataTable)unitsOfMeasurementAssociationsToolAddChanges.AssociatedUnits)
                    {
                        int companyId = row.COMPANY_ID;

                        // Insert new unit of measurement 
                        if ((row.Selected) && (!row.Deleted) && (!row.InDataBase))
                        {
                            int associationsId = row.AssociationsID;
                            int unitOfMeasurementId = row.UnitOfMeasurementID;
                            string module = row.Module;
                            bool byDefault = row.ByDefault;
                            bool deleted = row.Deleted;

                            UnitsOfMeasurementAssociations unitsOfMeasurementAssociations = new UnitsOfMeasurementAssociations(null);
                            unitsOfMeasurementAssociations.InsertDirect(associationsId, unitOfMeasurementId, module, byDefault, deleted, companyId);
                        }

                        // Update associations 
                        if ((row.Selected) && (!row.Deleted) && (row.InDataBase))
                        {
                            int associationsId = row.AssociationsID;
                            int unitOfMeasurementId = row.UnitOfMeasurementID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            // Original values
                            int originalUnitOfMeasurementId = unitsOfMeasurementAssociationsToolAssociatedUnitsGateway.GetUnitOfMeasurementIdOriginal(associationsId);
                            string originalModule = unitsOfMeasurementAssociationsToolAssociatedUnitsGateway.GetModuleOriginal(associationsId);
                            bool originalByDefault = unitsOfMeasurementAssociationsToolAssociatedUnitsGateway.GetByDefaultOriginal(associationsId);

                            // New values
                            int newUnitOfMeasurementId = unitsOfMeasurementAssociationsToolAssociatedUnitsGateway.GetUnitOfMeasurementId(associationsId);
                            string newModule = unitsOfMeasurementAssociationsToolAssociatedUnitsGateway.GetModule(associationsId);
                            bool newByDefault = unitsOfMeasurementAssociationsToolAssociatedUnitsGateway.GetByDefault(associationsId);

                            UnitsOfMeasurementAssociations unitsOfMeasurementAssociations = new UnitsOfMeasurementAssociations(null);
                            unitsOfMeasurementAssociations.UpdateDirect(associationsId, unitOfMeasurementId, originalModule, originalByDefault, originalDeleted, originalCompanyId, associationsId, unitOfMeasurementId, newModule, newByDefault, originalDeleted, originalCompanyId);
                        }

                        // Delete associations 
                        if ((row.Deleted) && (row.InDataBase))
                        {
                            UnitsOfMeasurementAssociations unitsOfMeasurementAssociations = new UnitsOfMeasurementAssociations(null);
                            unitsOfMeasurementAssociations.DeleteDirect(row.AssociationsID, row.COMPANY_ID);
                        }

                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
        /// <summary>
        /// GetNewAssociationsId
        /// </summary>
        /// <returns>New ID</returns>
        private int GetNewAssociationsId()
        {
            int newId = 0;

            foreach (UnitsOfMeasurementAssociationsToolTDS.AssociatedUnitsRow row in (UnitsOfMeasurementAssociationsToolTDS.AssociatedUnitsDataTable)Table)
            {
                if (newId < row.AssociationsID)
                {
                    newId = row.AssociationsID;
                }
            }

            newId++;

            return newId;
        }



        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="associationsId">associationsId</param>
        /// <param name="module">module</param>
        /// <returns>Obtained row</returns>
        private UnitsOfMeasurementAssociationsToolTDS.AssociatedUnitsRow GetRow(int associationsId)
        {
            UnitsOfMeasurementAssociationsToolTDS.AssociatedUnitsRow row = ((UnitsOfMeasurementAssociationsToolTDS.AssociatedUnitsDataTable)Table).FindByAssociationsID(associationsId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnits.GetRow");
            }

            return row;
        }


    }
}
