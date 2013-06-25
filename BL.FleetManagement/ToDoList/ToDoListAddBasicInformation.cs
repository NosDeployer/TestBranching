using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;

namespace LiquiForce.LFSLive.BL.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListAddBasicInformation
    /// </summary>
    public class ToDoListAddBasicInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListAddBasicInformation()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ToDoListAddBasicInformation(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ToDoListAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a to do list
        /// </summary>
        /// <param name="subject">subject</param>        
        /// <param name="comment">comment</param>
        /// <param name="dueDate">dueDate</param>
        /// <param name="unitId">unitId</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="state">state</param>        
        /// <param name="createdById">createdById</param>
        /// <param name="type_">type_</param>
        public void Insert(string subject, string comment, DateTime? dueDate, int? unitId, int assignTeamMemberId, bool deleted, int companyId, string state, int createdById, string type_)
        {
            ToDoListAddTDS.BasicInformationRow row = ((ToDoListAddTDS.BasicInformationDataTable)Table).NewBasicInformationRow();

            row.ToDoID = GetNewId();
            row.Subject = subject;
            row.Comment = comment;
            if (dueDate.HasValue) row.DueDate = (DateTime)dueDate; else row.SetDueDateNull();
            if (unitId.HasValue) row.UnitId = (int)unitId; else row.SetUnitIdNull();
            row.TeamMemberID = assignTeamMemberId; 
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.State = state;
            row.CreatedByID = createdById;
            row.Type_ = type_;

            ((ToDoListAddTDS.BasicInformationDataTable)Table).AddBasicInformationRow(row);
        }



        /// <summary>
        /// Save to do lists
        /// </summary>
        /// <param name="creationDate">creationDate</param>        
        /// <param name="companyId">companyId</param>
        public int? Save(DateTime creationDate, int companyId)
        {
            int newToDoListId = 0;

            ToDoListAddTDS ToDoListAddChanges = (ToDoListAddTDS)Data.GetChanges();
            if (ToDoListAddChanges.BasicInformation.Rows.Count > 0)
            {
                ToDoListToDoListGateway toDoListToDoListGateway = new ToDoListToDoListGateway(ToDoListAddChanges);

                foreach (ToDoListAddTDS.BasicInformationRow row in (ToDoListAddTDS.BasicInformationDataTable)ToDoListAddChanges.BasicInformation)
                {
                    string subject = ""; if (!row.IsSubjectNull()) subject = row.Subject;
                    string comment = ""; if (!row.IsCommentNull()) comment = row.Comment;
                    DateTime? dueDate = null; if (!row.IsDueDateNull()) dueDate = row.DueDate;
                    int? unitId = null; if (!row.IsUnitIdNull()) unitId = row.UnitId;
                    int employeeId = 0; if (!row.IsTeamMemberIDNull()) employeeId = row.TeamMemberID;
                    bool deleted = row.Deleted;
                    string state = row.State;
                    int createdById = row.CreatedByID;
                    int refId = 1;
                    string type_ = row.Type_;

                    // ... Insert the to do list
                    ToDoListToDoList toDoListToDoList = new ToDoListToDoList(null);
                    newToDoListId = toDoListToDoList.InsertDirect(subject, creationDate, createdById, state, dueDate, unitId, deleted, companyId);

                    // ... Insert first Activity (Default Assignation - first Activity)
                    ToDoListToDoListActivity toDoListToDoListActivity = new ToDoListToDoListActivity(null);
                    toDoListToDoListActivity.InsertDirect(newToDoListId, refId, employeeId, type_, creationDate, row.Deleted, companyId, comment);
                }
            }

            return newToDoListId;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single section. If not exists, raise an exception
        /// </summary>
        /// <param name="toDoListId">internal toDoListId</param>
        /// <returns>Row</returns>
        private ToDoListAddTDS.BasicInformationRow GetRow(int toDoListId)
        {
            ToDoListAddTDS.BasicInformationRow row = ((ToDoListAddTDS.BasicInformationDataTable)Table).FindByToDoID(toDoListId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.ToDoList.ToDoListAddBasicInformation.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewId
        /// </summary>
        /// <returns>ToDoListId</returns>
        private int GetNewId()
        {
            int newId = 0;

            foreach (ToDoListAddTDS.BasicInformationRow row in (ToDoListAddTDS.BasicInformationDataTable)Table)
            {
                if (newId < row.ToDoID)
                {
                    newId = row.ToDoID;
                }
            }

            newId++;

            return newId;
        }



    }
}