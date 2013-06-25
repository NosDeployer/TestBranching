using System;
using System.Data;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListNavigatorGateway
    /// </summary>
    public class ToDoListNavigatorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListNavigatorGateway()
            : base("ToDoListNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ToDoListNavigatorGateway(DataSet data)
            : base(data, "ToDoListNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ToDoListNavigatorTDS();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "ToDoListNavigator";
            tableMapping.ColumnMappings.Add("ToDoID", "ToDoID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("CreationDate", "CreationDate");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("DueDate", "DueDate");
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");

            tableMapping.ColumnMappings.Add("UnitCode", "UnitCode");
            tableMapping.ColumnMappings.Add("OwnerID", "OwnerID");
            tableMapping.ColumnMappings.Add("OwnerName", "OwnerName");
            tableMapping.ColumnMappings.Add("LastAssignedTeamMemberID", "LastAssignedTeamMemberID");
            tableMapping.ColumnMappings.Add("LastAssignedTeamMemberName", "LastAssignedTeamMemberName");
            tableMapping.ColumnMappings.Add("LastComment", "LastComment");
            tableMapping.ColumnMappings.Add("LastCommentDate", "LastCommentDate");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
                       
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadWhereOrderBy
        /// </summary>
        /// <param name="where">clause WHERE</param>
        /// <param name="orderBy">clause ORDER BY</param>
        /// <param name="conditionValue">conditionValue</param>
        /// <param name="conditionName">conditionName</param>
        /// <param name="textForSearch">textForSearch</param>
        public void LoadWhereOrderBy(string where, string orderBy, string conditionValue, string conditionName, string textForSearch)
        {
            // For Assigned To
            string whereClauseSpecial = "";
            if ((conditionValue == "FullName") && (conditionName == "Assigned To"))
            {
                char[] delimit = new char[] { ' ' };
                string[] nameSplited = textForSearch.Split(delimit);
                string firstName = nameSplited[0];
                string lastName = ""; if (nameSplited.Length > 1) lastName = nameSplited[1];

                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    whereClauseSpecial = whereClauseSpecial + " AND (LFTDL.ToDoID IN " +
                             "         (SELECT    LFTDLA.ToDoID " +
                             "          FROM      LFS_FM_TODOLIST_ACTIVITY AS LFTDLA INNER JOIN " +
                             "                    LFS_RESOURCES_EMPLOYEE AS LRE ON LFTDLA.EmployeeID = LRE.EmployeeID " +
                             "          WHERE     (LFTDLA.ToDoID = LFTDL.ToDoID) AND  (LFTDLA.Deleted = 0) AND (LFTDLA.Type_ = 'AssignUser') " +
                             "          AND  ( (LRE.FullName LIKE '%" + textForSearch.Trim() + "%') " +
                             "          OR      ((LRE.FirstName LIKE '%" + firstName.Trim() + "%') AND (LRE.LastName LIKE '%" + lastName.Trim() + "%')) " +
                             "               ) " +
                             "         ) " +
                             "                                       )";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereClauseSpecial = whereClauseSpecial + "  AND (LFTDL.ToDoID NOT IN " +
                             "         (SELECT     LFTDLA.ToDoID " +
                             "          FROM      LFS_FM_TODOLIST_ACTIVITY AS LFTDLA   " +
                             "          WHERE     (LFTDLA.ToDoID = LFTDL.ToDoID) AND  (LFTDLA.Deleted = 0) AND (LFTDLA.Type_ = 'AssignUser') " +
                             "         ) )";                             
                    }
                }
            }

            // For Created By
            if ((conditionValue == "FullName") && (conditionName == "Created By"))
            {
                char[] delimit = new char[] { ' ' };
                string[] nameSplited = textForSearch.Split(delimit);
                string firstName = nameSplited[0];
                string lastName = ""; if (nameSplited.Length > 1) lastName = nameSplited[1];

                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    whereClauseSpecial = whereClauseSpecial + " AND (LFTDL.ToDoID IN " +
                             "         (SELECT    LFTDLA.ToDoID " +
                             "          FROM      LFS_FM_TODOLIST AS LFTDLA INNER JOIN " +
                             "                    LFS_RESOURCES_EMPLOYEE AS LRE ON LFTDLA.CreatedByID = LRE.EmployeeID " +
                             "          WHERE     (LFTDLA.Deleted = 0) " +
                             "          AND  ( (LRE.FullName LIKE '%" + textForSearch.Trim() + "%') "+
                             "          OR      ((LRE.FirstName LIKE '%" + firstName.Trim() + "%') AND (LRE.LastName LIKE '%" + lastName.Trim() + "%')) " +
                             "               ) "+
                             "         ) "+
                             "                                       )";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereClauseSpecial = whereClauseSpecial + "  AND (LFTDL.ToDoID NOT IN " +
                             "         (SELECT    LFTDLA.ToDoID " +
                             "          FROM      LFS_FM_TODOLIST AS LFTDLA  " +
                             "          WHERE     (LFTDLA.Deleted = 0) " +
                             "         ) )";
                    }
                }
            }

            // For Last Comment
            if (conditionValue == "Comment")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    whereClauseSpecial = whereClauseSpecial + " AND (LFTDL.ToDoID IN " +
                             "         (SELECT    LFTDLA.ToDoID " +
                             "          FROM      LFS_FM_TODOLIST_ACTIVITY AS LFTDLA" +
                             "          WHERE     (LFTDLA.ToDoID = LFTDL.ToDoID) AND  (LFTDLA.Deleted = 0) " +
                             "          AND (LFTDLA.Comment LIKE '%" + textForSearch.Trim() + "%')))";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereClauseSpecial = whereClauseSpecial + "  AND (LFTDL.ToDoID NOT IN " +
                             "         (SELECT    LFTDLA.ToDoID " +
                             "          FROM      LFS_FM_TODOLIST_ACTIVITY AS LFTDLA  " +
                             "          WHERE     (LFTDLA.ToDoID = LFTDL.ToDoID) AND  (LFTDLA.Deleted = 0) AND (LFTDLA.Comment is not null)b   " +
                             "          ))";
                    }
                }
            }

            string commandText = "";
            commandText = String.Format(" SELECT LFTDL.ToDoID, LFTDL.Subject, LFTDL.CreationDate,   " +
                                        " LFTDL.State, LFTDL.DueDate, LFTDL.UnitID, LFTDL.Deleted,  " +
                                        " LFTDL.COMPANY_ID, (LFU.UnitCode + ' - '+ LFU.Description) AS UnitCode , LFTDL.CreatedByID,  " +
                                        " (SELECT     TOP (1) LRE.FullName FROM LFS_FM_TODOLIST AS LFTDL1 INNER JOIN  LFS_RESOURCES_EMPLOYEE AS LRE ON LFTDL1.CreatedByID = LRE.EmployeeID AND LFTDL1.CreatedByID = LFTDL.CreatedByID) AS OwnerName,   " +
                                        " (SELECT Top 1 LFTDLA.EmployeeID FROM LFS_FM_TODOLIST_ACTIVITY AS LFTDLA  Where  LFTDLA.ToDoID = LFTDL.ToDoID Order By LFTDLA.DateTime_ DESC) AS LastAssignedTeamMemberID,   " +
                                        " (SELECT Top 1 LRE.FullName FROM LFS_FM_TODOLIST_ACTIVITY AS LFTDLA INNER JOIN LFS_RESOURCES_EMPLOYEE AS LRE ON LFTDLA.EmployeeID = LRE.EmployeeID Where  LFTDLA.ToDoID = LFTDL.ToDoID  Order By LFTDLA.DateTime_ DESC) AS LastAssignedTeamMemberName,   " +
                                        " (SELECT Top 1 LFTDLA.Comment FROM LFS_FM_TODOLIST_ACTIVITY AS LFTDLA Where  LFTDLA.ToDoID = LFTDL.ToDoID Order By LFTDLA.DateTime_ DESC) AS LastComment,   " +
                                        " (SELECT Top 1 LFTDLA.DateTime_ FROM LFS_FM_TODOLIST_ACTIVITY AS LFTDLA Where  LFTDLA.ToDoID = LFTDL.ToDoID Order By LFTDLA.DateTime_ DESC) AS LastCommentDate,  " + 
                                        " CAST(0 AS bit) AS Selected  " +

                                        " FROM         LFS_FM_TODOLIST AS LFTDL LEFT JOIN  "+
                                        " LFS_FM_UNIT AS LFU ON LFTDL.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                                        " LFS_RESOURCES_EMPLOYEE LEOwner ON LFTDL.CreatedByID = LEOwner.EmployeeID" +
                                        " WHERE {0} {1} {2}", where, whereClauseSpecial, orderBy);
            FillData(commandText);
        }
                      

    }
}
