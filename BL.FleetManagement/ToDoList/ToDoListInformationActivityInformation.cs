using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;

namespace LiquiForce.LFSLive.BL.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListInformationActivityInformation
    /// </summary>
    public class ToDoListInformationActivityInformation: TableModule
    {
       // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListInformationActivityInformation()
            : base("ActivityInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ToDoListInformationActivityInformation(DataSet data)
            : base(data, "ActivityInformation")
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
            ToDoListInformationActivityInformationGateway toDoListInformationActivityInformationGateway = new ToDoListInformationActivityInformationGateway(Data);
            toDoListInformationActivityInformationGateway.LoadAllByToDoId(toDoId, companyId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="type_">type_</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="comment">comment</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="employeeFullName">EmployeeFullName</param>
        public void Insert(int toDoId, int employeeId, string type_, DateTime dateTime_, string comment, bool deleted, int companyId, bool inDatabase, string employeeFullName)
        {
            ToDoListInformationTDS.ActivityInformationRow row = ((ToDoListInformationTDS.ActivityInformationDataTable)Table).NewActivityInformationRow();

            row.ToDoID = toDoId;
            row.RefID = GetNewRefId();
            row.EmployeeID = employeeId;
            row.Type_ = type_;
            row.DateTime_ = dateTime_;           
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDataBase = inDatabase;
            row.EmployeeFullName = employeeFullName;
            row.Comment = comment;

            ((ToDoListInformationTDS.ActivityInformationDataTable)Table).AddActivityInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="refId">refId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="employeeeFullName">employeeFullName</param>
        /// <param name="comment">comment</param>
        public void Update(int toDoId, int refId, int employeeId, string employeeFullName, string comment)
        {
            ToDoListInformationTDS.ActivityInformationRow row = GetRow(toDoId, refId);
            row.Comment = comment;
            row.EmployeeID = employeeId;
            row.EmployeeFullName = employeeFullName;
        }

                

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="refId">refId</param>
        public void Delete(int toDoId, int refId)
        {
            ToDoListInformationTDS.ActivityInformationRow row = GetRow(toDoId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        public void DeleteAll(int toDoId)
        {
            foreach (ToDoListInformationTDS.ActivityInformationRow row in (ToDoListInformationTDS.ActivityInformationDataTable)Table)
            {
                row.Deleted = true;
            }
        }



        /// <summary>
        /// Save all activities to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            ToDoListInformationTDS toDoListInformationChanges = (ToDoListInformationTDS)Data.GetChanges();

            if (toDoListInformationChanges != null)
            {
                if (toDoListInformationChanges.ActivityInformation.Rows.Count > 0)
                {
                    ToDoListInformationActivityInformationGateway toDoListInformationActivityInformationGateway = new ToDoListInformationActivityInformationGateway(toDoListInformationChanges);

                    foreach (ToDoListInformationTDS.ActivityInformationRow row in (ToDoListInformationTDS.ActivityInformationDataTable)toDoListInformationChanges.ActivityInformation)
                    {
                        // Insert new activity 
                        if ((!row.Deleted) && (!row.InDataBase))
                        {
                            // new values
                            int toDoId = row.ToDoID;
                            int refId = row.RefID;

                            int employeeId = toDoListInformationActivityInformationGateway.GetEmployeeID(toDoId, refId);
                            string type_ = toDoListInformationActivityInformationGateway.GetType_(toDoId, refId);
                            DateTime dateTime_ = toDoListInformationActivityInformationGateway.GetDateTime_(toDoId, refId);
                            string comment = toDoListInformationActivityInformationGateway.GetComment(toDoId, refId);

                            ToDoListToDoListActivity toDoListToDoListActivity = new ToDoListToDoListActivity(null);
                            toDoListToDoListActivity.InsertDirect(toDoId, refId, employeeId, type_, dateTime_, row.Deleted, row.COMPANY_ID, comment);
                        }

                        // Update activities
                        if ((!row.Deleted) && (row.InDataBase))
                        {
                            int toDoId = row.ToDoID;
                            int refId = row.RefID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            // original values
                            int originalEmployeeId = toDoListInformationActivityInformationGateway.GetEmployeeID(toDoId, refId);
                            string originalType_ = toDoListInformationActivityInformationGateway.GetType_(toDoId, refId);
                            DateTime originalDateTime_ = toDoListInformationActivityInformationGateway.GetDateTime_(toDoId, refId);
                            string originalComment = toDoListInformationActivityInformationGateway.GetComment(toDoId, refId);

                            // new values
                            int newEmployeeId = toDoListInformationActivityInformationGateway.GetEmployeeIDOriginal(toDoId, refId);
                            string newComment = toDoListInformationActivityInformationGateway.GetCommentOriginal(toDoId, refId);

                            ToDoListToDoListActivity toDoListToDoListActivity = new ToDoListToDoListActivity(null);
                            toDoListToDoListActivity.UpdateDirect(toDoId, refId, originalEmployeeId, originalType_, originalDateTime_, originalDeleted, originalCompanyId, originalComment, toDoId, refId, newEmployeeId, originalType_, originalDateTime_, originalDeleted, originalCompanyId, newComment);
                        }

                        // Deleted activity
                        if ((row.Deleted) && (row.InDataBase))
                        {
                            ToDoListToDoListActivity toDoListToDoListActivity = new ToDoListToDoListActivity(null);
                            toDoListToDoListActivity.DeleteDirect(row.ToDoID, row.RefID, row.COMPANY_ID);
                        }
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private ToDoListInformationTDS.ActivityInformationRow GetRow(int toDoId, int refId)
        {
            ToDoListInformationTDS.ActivityInformationRow row = ((ToDoListInformationTDS.ActivityInformationDataTable)Table).FindByToDoIDRefID(toDoId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.ToDolist.toDoListInformationActivityInformation.GetRow");
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

            foreach (ToDoListInformationTDS.ActivityInformationRow row in (ToDoListInformationTDS.ActivityInformationDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }



        /// <summary>
        /// GetLastAssignedUserRefId
        /// </summary>
        /// <returns>Last ID</returns>
        public int GetLastAssignedUserRefId()
        {
            int newRefId = 1;

            foreach (ToDoListInformationTDS.ActivityInformationRow row in (ToDoListInformationTDS.ActivityInformationDataTable)Table)
            {
                if ((row.Type_ == "AssignUser") && (!row.Deleted))
                {
                    if (newRefId < row.RefID)
                    {
                        newRefId = row.RefID;
                    }
                }
            }

            return newRefId;
        }



    }
}