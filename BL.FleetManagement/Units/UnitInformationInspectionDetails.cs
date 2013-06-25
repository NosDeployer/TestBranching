using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitInformationInspectionDetails
    /// </summary>
    public class UnitInformationInspectionDetails :TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitInformationInspectionDetails()
            : base("InspectionDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitInformationInspectionDetails(DataSet data)
            : base(data, "InspectionDetails")
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
        /// LoadByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByUnitId(int unitId, int companyId)
        {
            UnitInformationInspectionDetailsGateway unitInformationInspectionDetails = new UnitInformationInspectionDetailsGateway(Data);
            unitInformationInspectionDetails.LoadByUnitId(unitId, companyId);
        }


        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="date_">date_</param>
        /// <param name="country">country</param>
        /// <param name="state">state</param>
        /// <param name="type">type</param>
        /// <param name="result">result</param>
        /// <param name="cost">cost</param>
        /// <param name="notes">notes</param>
        /// <param name="inspectedBy">inspectedBy</param>
        /// <param name="attach">attach</param>
        /// <param name="deleted">deleted</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(DateTime date_, Int64 country, Int64 state, string type, string result, decimal? cost, string notes, string inspectedBy, string attach, bool deleted, bool inDatabase)
        {
            UnitInformationTDS.InspectionDetailsRow row = ((UnitInformationTDS.InspectionDetailsDataTable)Table).NewInspectionDetailsRow();

            row.InspectionID = GetNewInspectionId();
            row.Date_ = date_;
            row.Country = country;
            row.State = state;
            row.Type = type;
            if (result != "") row.Result = result; else row.SetResultNull();
            if (cost.HasValue) row.Cost = (decimal)cost; else row.SetCostNull();
            if (notes != "") row.Notes = notes; else row.SetNotesNull();
            if (inspectedBy != "") row.InspectedBy = inspectedBy; else row.SetInspectedByNull();
            if (attach != "") row.Attach = attach; else row.SetAttachNull();
            row.Deleted = deleted;
            row.InDatabase = false;
                        
            ((UnitInformationTDS.InspectionDetailsDataTable)Table).AddInspectionDetailsRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <param name="date_">date_</param>
        /// <param name="country">country</param>
        /// <param name="state">state</param>
        /// <param name="type">type</param>
        /// <param name="result">result</param>
        /// <param name="cost">cost</param>
        /// <param name="notes">notes</param>
        /// <param name="inspectedBy">inspectedBy</param>
        /// <param name="attach">attach</param>
        /// <param name="deleted">deleted</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Update(int inspectionId, DateTime date_, Int64 country, Int64 state, string type, string result, decimal? cost, string notes, string inspectedBy, string attach, bool deleted, bool inDatabase)
        {
            UnitInformationTDS.InspectionDetailsRow row = GetRow(inspectionId);

            row.Date_ = date_;
            row.Country = country;
            row.State = state;
            row.Type = type;
            if (result != "") row.Result = result; else row.SetResultNull();
            if (cost.HasValue) row.Cost = (decimal)cost; else row.SetCostNull();
            if (notes != "") row.Notes = notes; else row.SetNotesNull();
            if (inspectedBy != "") row.InspectedBy = inspectedBy; else row.SetInspectedByNull();
            if (attach != "") row.Attach = attach; else row.SetAttachNull();
            //row.Deleted = deleted;
            //row.InDatabase = false;
        }



        
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        public void Delete(int inspectionId)
        {
            UnitInformationTDS.InspectionDetailsRow row = GetRow(inspectionId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        public void DeleteAll()
        {
            foreach (UnitInformationTDS.InspectionDetailsRow row in (UnitInformationTDS.InspectionDetailsDataTable)Table)
            {
                row.Deleted = true;                
            }
        }


        
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void Save(int unitId, int companyId)
        {
            UnitInformationTDS unitInformationChanges = (UnitInformationTDS)Data.GetChanges();
            if (unitInformationChanges.InspectionDetails.Rows.Count > 0)
            {
                UnitInformationInspectionDetailsGateway unitInformationInspectionDetailsGateway = new UnitInformationInspectionDetailsGateway(unitInformationChanges);

                foreach (UnitInformationTDS.InspectionDetailsRow row in (UnitInformationTDS.InspectionDetailsDataTable)unitInformationChanges.InspectionDetails)
                {
                    // Insert new inspection
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        // Insert inspection
                        int inspectionId = row.InspectionID;
                        DateTime date_ = unitInformationInspectionDetailsGateway.GetDate_(inspectionId);
                        Int64 country = unitInformationInspectionDetailsGateway.GetCountry(inspectionId);
                        Int64 state = unitInformationInspectionDetailsGateway.GetState(inspectionId);
                        string type = unitInformationInspectionDetailsGateway.GetType(inspectionId);
                        string result = unitInformationInspectionDetailsGateway.GetResult(inspectionId);
                        decimal? cost = unitInformationInspectionDetailsGateway.GetCost(inspectionId);
                        string notes = unitInformationInspectionDetailsGateway.GetNotes(inspectionId);
                        string inspectedBy = unitInformationInspectionDetailsGateway.GetInspectedBy(inspectionId);
                        string attach = unitInformationInspectionDetailsGateway.GetAttach(inspectionId);

                        InsertInspection(unitId, inspectionId, date_, country, state, type, result, cost, notes, inspectedBy, attach, false, companyId);
                    }

                    // Update inspection
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int inspectionId = row.InspectionID;

                        // original values
                        DateTime originalDate_ = unitInformationInspectionDetailsGateway.GetDate_Original(inspectionId);
                        Int64 originalCountry = unitInformationInspectionDetailsGateway.GetCountryOriginal(inspectionId);
                        Int64 originalState = unitInformationInspectionDetailsGateway.GetStateOriginal(inspectionId);
                        string originalType = unitInformationInspectionDetailsGateway.GetTypeOriginal(inspectionId);
                        string originalResult = unitInformationInspectionDetailsGateway.GetResultOriginal(inspectionId);
                        decimal? originalCost = unitInformationInspectionDetailsGateway.GetCostOriginal(inspectionId);
                        string originalNotes = unitInformationInspectionDetailsGateway.GetNotesOriginal(inspectionId);
                        string originalInspectedBy = unitInformationInspectionDetailsGateway.GetInspectedByOriginal(inspectionId);
                        string originalAttach = unitInformationInspectionDetailsGateway.GetAttachOriginal(inspectionId);

                        // new values
                        DateTime newDate_ = unitInformationInspectionDetailsGateway.GetDate_(inspectionId);
                        Int64 newCountry = unitInformationInspectionDetailsGateway.GetCountry(inspectionId);
                        Int64 newState = unitInformationInspectionDetailsGateway.GetState(inspectionId);
                        string newType = unitInformationInspectionDetailsGateway.GetType(inspectionId);
                        string newResult = unitInformationInspectionDetailsGateway.GetResult(inspectionId);
                        decimal? newCost = unitInformationInspectionDetailsGateway.GetCost(inspectionId);
                        string newNotes = unitInformationInspectionDetailsGateway.GetNotes(inspectionId);
                        string newInspectedBy = unitInformationInspectionDetailsGateway.GetInspectedBy(inspectionId);
                        string newAttach = unitInformationInspectionDetailsGateway.GetAttach(inspectionId);

                        UpdateInspection(unitId, inspectionId, originalDate_, originalCountry, originalState, originalType, originalResult, originalCost, originalNotes, originalInspectedBy, originalAttach, false, companyId, unitId, inspectionId, newDate_, newCountry, newState, newType, newResult, newCost, newNotes, newInspectedBy, newAttach, false, companyId);
                    }

                    // Delete inspection
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        int inspectionId = row.InspectionID;
                        DeleteInspection(unitId, inspectionId, companyId);
                    }
                }
            }
        }



        

         
        //// ////////////////////////////////////////////////////////////////////////
        //// PRIVATE METHODS
        ////

        /// <summary>
        /// GetNewInspectionId
        /// </summary>
        /// <returns>newInspectionId</returns>
        private int GetNewInspectionId()
        {
            int newInspectionId = 0;

            foreach (UnitInformationTDS.InspectionDetailsRow row in (UnitInformationTDS.InspectionDetailsDataTable)Table)
            {
                if (newInspectionId < row.InspectionID)
                {
                    newInspectionId = row.InspectionID;
                }
            }

            newInspectionId++;

            return newInspectionId;
        }


        
        /// <summary>
        /// InsertInspection
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="inspectionId">inspectionId</param>
        /// <param name="date_">date_</param>
        /// <param name="country">country</param>
        /// <param name="state">state</param>
        /// <param name="type">type</param>
        /// <param name="result">result</param>
        /// <param name="cost">cost</param>
        /// <param name="notes">notes</param>
        /// <param name="inspectedBy">inspectedBy</param>
        /// <param name="attach">attach</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        private void InsertInspection(int unitId, int inspectionId, DateTime date_, Int64 country, Int64 state, string type, string result, decimal? cost, string notes, string inspectedBy, string attach, bool deleted, int companyId)
        {
            UnitsInspection unitInspection = new UnitsInspection(null);
            unitInspection.InsertDirect(unitId, inspectionId, date_, country, state, type, result, cost, notes, inspectedBy, attach, deleted, companyId);
        }



        /// <summary>
        /// UpdateInspection
        /// </summary>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalInspectionId">originalInspectionId</param>
        /// <param name="originalDate_">originalDate_</param>
        /// <param name="originalCountry">originalCountry</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalResult">originalResult</param>
        /// <param name="originalCost">originalCost</param>
        /// <param name="originalNotes">originalNotes</param>
        /// <param name="originalInspectedBy">originalInspectedBy</param>
        /// <param name="originalAttach">originalAttach</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newUnitId">newUnitId</param>
        /// <param name="newInspectionId">newInspectionId</param>
        /// <param name="newDate_">newDate_</param>
        /// <param name="newCountry">newCountry</param>
        /// <param name="newState">newState</param>
        /// <param name="newType">newType</param>
        /// <param name="newResult">newResult</param>
        /// <param name="newCost">newCost</param>
        /// <param name="newNotes">newNotes</param>
        /// <param name="newInspectedBy">newInspectedBy</param>
        /// <param name="newAttach">newAttach</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        private void UpdateInspection(int originalUnitId, int originalInspectionId, DateTime originalDate_, Int64 originalCountry, Int64 originalState, string originalType, string originalResult, decimal? originalCost, string originalNotes, string originalInspectedBy, string originalAttach, bool originalDeleted, int originalCompanyId, int newUnitId, int newInspectionId, DateTime newDate_, Int64 newCountry, Int64 newState, string newType, string newResult, decimal? newCost, string newNotes, string newInspectedBy, string newAttach, bool newDeleted, int newCompanyId)
        {
            UnitsInspection unitInspection = new UnitsInspection(null);
            unitInspection.UpdateDirect(originalUnitId, originalInspectionId, originalDate_, originalCountry, originalState, originalType, originalResult, originalCost, originalNotes, originalInspectedBy, originalAttach, originalDeleted, originalCompanyId, newUnitId, newInspectionId, newDate_, newCountry, newState, newType, newResult, newCost, newNotes, newInspectedBy, newAttach, newDeleted, newCompanyId);
        }
    


        /// <summary>
        /// DeleteInspection
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="inspectionId">inspectionId</param>
        /// <param name="companyId">companyId</param>
        private void DeleteInspection(int unitId, int inspectionId, int companyId)
        {
            UnitsInspection unitInspection = new UnitsInspection(null);
            unitInspection.DeletedDirect(unitId, inspectionId, companyId);
        }     


        
        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Obtained row</returns>
        private UnitInformationTDS.InspectionDetailsRow GetRow(int inspectionId)
        {
            UnitInformationTDS.InspectionDetailsRow row = ((UnitInformationTDS.InspectionDetailsDataTable)Table).FindByInspectionID(inspectionId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Units.UnitInformationInspectionDetails.GetRow");
            }

            return row;
        }       



    }
}
