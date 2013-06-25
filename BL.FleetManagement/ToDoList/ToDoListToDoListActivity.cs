using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;

namespace LiquiForce.LFSLive.BL.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListToDoListActivity
    /// </summary>
    public class ToDoListToDoListActivity : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListToDoListActivity()
            : base("LFS_FM_TODOLIST_ACTIVITY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ToDoListToDoListActivity(DataSet data)
            : base(data, "LFS_FM_TODOLIST_ACTIVITY")
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
        /// <param name="toDoId">toDoId</param>
        /// <param name="refId">refId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="type_">type_</param>
        /// <param name="dateTime_">dateTime_</param>        
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="comment">comment</param>
        public void InsertDirect(int toDoId, int refId, int employeeId, string type_, DateTime dateTime_, bool deleted, int companyId, string comment)
        {
            ToDoListToDoListActivityGateway toDoListToDoListActivityGateway = new ToDoListToDoListActivityGateway(null);
            toDoListToDoListActivityGateway.Insert(toDoId, refId, employeeId, type_, dateTime_, deleted, companyId, comment);
        }



        /// <summary>
        /// Update direct - activity (direct to DB)
        /// </summary>
        /// <param name="originalToDoId">originalToDoId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalType_">originalType_</param>
        /// <param name="originalDateTime_">originalDateTime_</param>        
        /// <param name="originalDeleted">originalDeleted</param> 
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalComment">originalComment</param>
        ///
        /// <param name="newToDoId">newToDoId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newEmployeeId">newEmployeeId</param>
        /// <param name="newType_">newType_</param>
        /// <param name="newDateTime_">newDateTime_</param>        
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newComment">newComment</param>
        public void UpdateDirect(int originalToDoId, int originalRefId, int originalEmployeeId, string originalType_, DateTime originalDateTime_, bool originalDeleted, int originalCompanyId, string originalComment, int newToDoId, int newRefId, int newEmployeeId, string newType_, DateTime newDateTime_, bool newDeleted, int newCompanyId, string newComment)
        {
            ToDoListToDoListActivityGateway toDoListToDoListActivityGateway = new ToDoListToDoListActivityGateway(null);
            toDoListToDoListActivityGateway.Update(originalToDoId, originalRefId, originalEmployeeId, originalType_, originalDateTime_, originalDeleted, originalCompanyId, originalComment, newToDoId, newRefId, newEmployeeId, newType_, newDateTime_, newDeleted, newCompanyId, newComment);
        }
        


        /// <summary>
        /// Delete one activity  (direct to DB)
        /// </summary>
        /// <param name="originalToDoId">originalToDoId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        public void DeleteDirect(int originalToDoId, int originalRefId, int originalCompanyId)
        {
            ToDoListToDoListActivityGateway toDoListToDoListActivityGateway = new ToDoListToDoListActivityGateway(null);
            toDoListToDoListActivityGateway.Delete(originalToDoId, originalRefId, originalCompanyId);
        }



        /// <summary>
        /// Delete all activities  (direct to DB)
        /// </summary>
        /// <param name="originalToDoId">originalToDoId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        public void DeleteAllDirect(int originalToDoId, int originalCompanyId)
        {
            ToDoListToDoListActivityGateway toDoListToDoListActivityGateway = new ToDoListToDoListActivityGateway(null);
            toDoListToDoListActivityGateway.DeleteAll(originalToDoId, originalCompanyId);
        }



    }
}
