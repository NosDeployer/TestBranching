using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;

namespace LiquiForce.LFSLive.BL.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListToDoList
    /// </summary>
    public class ToDoListToDoList : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListToDoList()
            : base("LFS_FM_TODOLIST")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ToDoListToDoList(DataSet data)
            : base(data, "LFS_FM_TODOLIST")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ToDoListTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert direct (direct to DB)
        /// </summary>
        /// <param name="subject">subject</param>
        /// <param name="creationDate">creationDate</param>
        /// <param name="createdById">createdById</param>
        /// <param name="state">state</param>
        /// <param name="dueDate">dueDate</param>
        /// <param name="unitId">unitId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>       
        /// <returns>todoId</returns>
        public int InsertDirect(string subject, DateTime creationDate, int createdById, string state, DateTime? dueDate, int? unitId, bool deleted, int companyId)
        {
            ToDoListToDoListGateway toDoListToDoListGateway = new ToDoListToDoListGateway(null);
            return toDoListToDoListGateway.Insert(subject, creationDate, createdById, state, dueDate, unitId, deleted, companyId);
        }



        /// <summary>
        /// Update direct - to do  (direct to DB)
        /// </summary>
        /// <param name="originalToDoId">originalToDoId</param>
        /// <param name="originalSubject">originalSubject</param>
        /// <param name="originalCreationDate">originalCreationDate</param>
        /// <param name="originalCreatedById">originalCreatedById</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalDueDate">originalDueDate</param>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalDeleted">originalDeleted</param> 
        /// <param name="originalCompanyId">originalCompanyId</param>
        ///
        /// <param name="newToDoId">newToDoId</param>
        /// <param name="newSubject">newSubject</param>
        /// <param name="newCreationDate">newCreationDate</param>
        /// <param name="newCreatedById">newCreatedById</param>
        /// <param name="newState">newState</param>
        /// <param name="newDueDate">newDueDate</param>
        /// <param name="newUnitId">newUnitId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalToDoId, string originalSubject, DateTime originalCreationDate, int originalCreatedById, string originalState, DateTime? originalDueDate, int? originalUnitId, bool originalDeleted, int originalCompanyId, int newToDoId, string newSubject, DateTime newCreationDate, int newCreatedById, string newState, DateTime? newDueDate, int? newUnitId, bool newDeleted, int newCompanyId)
        {
            ToDoListToDoListGateway toDoListToDoListGateway = new ToDoListToDoListGateway(null);
            toDoListToDoListGateway.Update(originalToDoId, originalSubject, originalCreationDate, originalCreatedById, originalState, originalDueDate, originalUnitId, originalDeleted, originalCompanyId, newToDoId, newSubject, newCreationDate, newCreatedById, newState, newDueDate, newUnitId, newDeleted, newCompanyId);
        }
        


        /// <summary>
        /// DeleteDirect (direct to DB)
        /// </summary>
        /// <param name="toDoListId">toDoListId</param>        
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int toDoListId, int companyId)
        {
            ToDoListToDoListGateway toDoListToDoListGateway = new ToDoListToDoListGateway(null);
            toDoListToDoListGateway.Delete(toDoListId, companyId);
        }


        
    }
}
