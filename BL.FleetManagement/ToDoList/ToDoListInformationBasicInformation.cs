using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;

namespace LiquiForce.LFSLive.BL.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListInformationBasicInformation
    /// </summary>
    public class ToDoListInformationBasicInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListInformationBasicInformation()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ToDoListInformationBasicInformation(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ToDoListInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllByToDoId
        /// </summary>
        /// <param name="toDoId">toDoId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadAllByToDoId(int toDoId, int companyId)
        {
            ToDoListInformationBasicInformationGateway toDoListInformationBasicInformationGateway = new ToDoListInformationBasicInformationGateway(Data);
            toDoListInformationBasicInformationGateway.LoadAllByToDoId(toDoId, companyId);
        }

        

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="dueDate">dueDate</param>
        /// <param name="unitId">unitId</param>
        public void Update(int toDoId, DateTime? dueDate, int? unitId)
        {
            ToDoListInformationTDS.BasicInformationRow row = GetRow(toDoId);
            if (dueDate.HasValue) row.DueDate = (DateTime)dueDate; else row.SetDueDateNull();
            if (unitId.HasValue) row.UnitID = (int)unitId; else row.SetUnitIDNull();                         
        }



        /// <summary>
        /// UpdateState
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="state">state</param>
        public void UpdateState(int toDoId, string state)
        {
            ToDoListInformationTDS.BasicInformationRow row = GetRow(toDoId);
            row.State = state;
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            ToDoListInformationTDS toDoListInformationChanges = (ToDoListInformationTDS)Data.GetChanges();

            if (toDoListInformationChanges != null)
            {
                if (toDoListInformationChanges.BasicInformation.Rows.Count > 0)
                {
                    ToDoListInformationBasicInformationGateway toDoListInformationBasicInformationGateway = new ToDoListInformationBasicInformationGateway(toDoListInformationChanges);

                    // Update to do
                    foreach (ToDoListInformationTDS.BasicInformationRow row in (ToDoListInformationTDS.BasicInformationDataTable)toDoListInformationChanges.BasicInformation)
                    {
                        // Unchanged values
                        int toDoId = row.ToDoID;
                        string subject = toDoListInformationBasicInformationGateway.GetSubject(toDoId);
                        DateTime creationDate = toDoListInformationBasicInformationGateway.GetCreationDate(toDoId);
                        int createdById = toDoListInformationBasicInformationGateway.GetCreatedByID(toDoId);

                        // Original values
                        DateTime? originalDueDate = null; if (toDoListInformationBasicInformationGateway.GetDueDateOriginal(toDoId).HasValue) originalDueDate = (DateTime)toDoListInformationBasicInformationGateway.GetDueDateOriginal(toDoId);
                        int? originalUnitId = null; if (toDoListInformationBasicInformationGateway.GetUnitIDOriginal(toDoId).HasValue) originalUnitId = (int)toDoListInformationBasicInformationGateway.GetUnitIDOriginal(toDoId);
                        string originalState = toDoListInformationBasicInformationGateway.GetStateOriginal(toDoId);

                        // New variables
                        DateTime? newDueDate = null; if (toDoListInformationBasicInformationGateway.GetDueDate(toDoId).HasValue) newDueDate = (DateTime)toDoListInformationBasicInformationGateway.GetDueDate(toDoId);
                        int? newUnitId = null; if (toDoListInformationBasicInformationGateway.GetUnitID(toDoId).HasValue) newUnitId = (int)toDoListInformationBasicInformationGateway.GetUnitID(toDoId);
                        string newState = toDoListInformationBasicInformationGateway.GetState(toDoId);

                        ToDoListToDoList toDoListToDoList = new ToDoListToDoList(null);
                        toDoListToDoList.UpdateDirect(toDoId, subject, creationDate, createdById, originalState, originalDueDate, originalUnitId, row.Deleted, row.COMPANY_ID, toDoId, subject, creationDate, createdById, newState, newDueDate, newUnitId, row.Deleted, row.COMPANY_ID);
                    }
                }
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        public void Delete(int toDoId)
        {
            ToDoListInformationTDS.BasicInformationRow row = GetRow(toDoId);
            row.Deleted = true;
        }

               



                        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <returns>Obtained row</returns>
        private ToDoListInformationTDS.BasicInformationRow GetRow(int toDoId)
        {
            ToDoListInformationTDS.BasicInformationRow row = ((ToDoListInformationTDS.BasicInformationDataTable)Table).FindByToDoID(toDoId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.ToDoList.ToDoListInformationBasicInformation.GetRow");
            }

            return row;
        }



    }
}