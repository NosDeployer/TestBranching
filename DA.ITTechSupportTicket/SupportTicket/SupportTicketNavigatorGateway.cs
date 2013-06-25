using System;
using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// SupportTicketNavigatorGateway
    /// </summary>
    public class SupportTicketNavigatorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SupportTicketNavigatorGateway()
            : base("SupportTicketNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SupportTicketNavigatorGateway(DataSet data)
            : base(data, "SupportTicketNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SupportTicketNavigatorTDS();
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
            tableMapping.DataSetTable = "SupportTicketNavigator";
            tableMapping.ColumnMappings.Add("SupportTicketID", "SupportTicketID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("CreationDate", "CreationDate");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("DueDate", "DueDate");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("OwnerID", "OwnerID");
            tableMapping.ColumnMappings.Add("OwnerName", "OwnerName");
            tableMapping.ColumnMappings.Add("LastAssignedTeamMemberID", "LastAssignedTeamMemberID");
            tableMapping.ColumnMappings.Add("LastAssignedTeamMemberName", "LastAssignedTeamMemberName");
            tableMapping.ColumnMappings.Add("LastComment", "LastComment");
            tableMapping.ColumnMappings.Add("LastCommentDate", "LastCommentDate");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("CategoryName", "CategoryName");
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

                string lastName2 = nameSplited[0];
                string firstName2 = ""; if (nameSplited.Length > 1) lastName = nameSplited[1];

                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    whereClauseSpecial = whereClauseSpecial + " AND (LITST.SupportTicketID IN " +
                             "         (SELECT    LITSTA.SupportTicketID " +
                             "          FROM      LFS_ITTST_SUPPORTICKET_ACTIVITY AS LITSTA INNER JOIN " +
                             "                    LFS_RESOURCES_EMPLOYEE AS LRE ON LITSTA.EmployeeID = LRE.EmployeeID " +
                             "          WHERE     (LITSTA.SupportTicketID = LITST.SupportTicketID) AND  (LITSTA.Deleted = 0) AND (LITSTA.Type_ = 'AssignUser') " +
                             "          AND  ( (LRE.FullName LIKE '%" + textForSearch.Trim() + "%') " +
                             "          OR      (((LRE.FirstName LIKE '%" + firstName.Trim() + "%') OR (LRE.FirstName LIKE '%" + firstName2.Trim() + "%')) AND " +
                             "                  ((LRE.LastName LIKE '%" + lastName.Trim() + "%') OR (LRE.LastName LIKE '%" + lastName2.Trim() + "%'))) " +
                             "               ) " +
                             "         ) " +
                             "                                       )";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereClauseSpecial = whereClauseSpecial + "  AND (LITST.SupportTicketID NOT IN " +
                             "         (SELECT     LITSTA.SupportTicketID " +
                             "          FROM      LFS_ITTST_SUPPORTICKET_ACTIVITY AS LITSTA   " +
                             "          WHERE     (LITSTA.SupportTicketID = LITST.SupportTicketID) AND  (LITSTA.Deleted = 0) AND (LITSTA.Type_ = 'AssignUser') " +
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

                string lastName2 = nameSplited[0];
                string firstName2 = ""; if (nameSplited.Length > 1) lastName = nameSplited[1];

                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    whereClauseSpecial = whereClauseSpecial + " AND (LITST.SupportTicketID IN " +
                             "         (SELECT    LITSTA.SupportTicketID " +
                             "          FROM      LFS_ITTST_SUPPORTICKET AS LITSTA INNER JOIN " +
                             "                    LFS_RESOURCES_EMPLOYEE AS LRE ON LITSTA.CreatedByID = LRE.EmployeeID " +
                             "          WHERE     (LITSTA.Deleted = 0) " +
                             "          AND  ( (LRE.FullName LIKE '%" + textForSearch.Trim() + "%') "+
                             "          OR      (((LRE.FirstName LIKE '%" + firstName.Trim() + "%') OR (LRE.FirstName LIKE '%" + firstName2.Trim() + "%')) AND  " +
                             "                  ((LRE.LastName LIKE '%" + lastName.Trim() + "%') OR (LRE.LastName LIKE '%" + lastName2.Trim() + "%'))) " +
                             "               ) "+
                             "         ) "+
                             "                                       )";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereClauseSpecial = whereClauseSpecial + "  AND (LITST.SupportTicketID NOT IN " +
                             "         (SELECT    LITSTA.SupportTicketID " +
                             "          FROM      LFS_ITTST_SUPPORTICKET AS LITSTA  " +
                             "          WHERE     (LITSTA.Deleted = 0) " +
                             "         ) )";
                    }
                }
            }

            // For Last Comment
            if (conditionValue == "Comment")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    whereClauseSpecial = whereClauseSpecial + " AND (LITST.SupportTicketID IN " +
                             "         (SELECT    LITSTA.SupportTicketID " +
                             "          FROM      LFS_ITTST_SUPPORTICKET_ACTIVITY AS LITSTA" +
                             "          WHERE     (LITSTA.SupportTicketID = LITST.SupportTicketID) AND  (LITSTA.Deleted = 0) " +
                             "          AND (LITSTA.Comment LIKE '%" + textForSearch.Trim() + "%')))";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereClauseSpecial = whereClauseSpecial + "  AND (LITST.SupportTicketID NOT IN " +
                             "         (SELECT    LITSTA.SupportTicketID " +
                             "          FROM      LFS_ITTST_SUPPORTICKET_ACTIVITY AS LITSTA  " +
                             "          WHERE     (LITSTA.SupportTicketID = LITST.SupportTicketID) AND  (LITSTA.Deleted = 0) AND (LITSTA.Comment is not null)b   " +
                             "          ))";
                    }
                }
            }

            string commandText = "";
            commandText = String.Format(" SELECT LITST.SupportTicketID, LITST.Subject, LITST.CreationDate,   " +
                                        " LITST.State, LITST.DueDate, LITST.Deleted,  " +
                                        " LITST.COMPANY_ID, LITST.CreatedByID,  " +
                                        " (SELECT     TOP (1) LRE.FullName FROM LFS_ITTST_SUPPORTICKET AS LITST1 INNER JOIN  LFS_RESOURCES_EMPLOYEE AS LRE ON LITST1.CreatedByID = LRE.EmployeeID AND LITST1.CreatedByID = LITST.CreatedByID) AS OwnerName,   " +
                                        " (SELECT Top 1 LITSTA.EmployeeID FROM LFS_ITTST_SUPPORTICKET_ACTIVITY AS LITSTA  Where  LITSTA.SupportTicketID = LITST.SupportTicketID Order By LITSTA.DateTime_ DESC) AS LastAssignedTeamMemberID,   " +
                                        " (SELECT Top 1 LRE.FullName FROM LFS_ITTST_SUPPORTICKET_ACTIVITY AS LITSTA INNER JOIN LFS_RESOURCES_EMPLOYEE AS LRE ON LITSTA.EmployeeID = LRE.EmployeeID Where  LITSTA.SupportTicketID = LITST.SupportTicketID  Order By LITSTA.DateTime_ DESC) AS LastAssignedTeamMemberName,   " +
                                        " (SELECT Top 1 LITSTA.Comment FROM LFS_ITTST_SUPPORTICKET_ACTIVITY AS LITSTA Where  LITSTA.SupportTicketID = LITST.SupportTicketID Order By LITSTA.DateTime_ DESC) AS LastComment,   " +
                                        " (SELECT Top 1 LITSTA.DateTime_ FROM LFS_ITTST_SUPPORTICKET_ACTIVITY AS LITSTA Where  LITSTA.SupportTicketID = LITST.SupportTicketID Order By LITSTA.DateTime_ DESC) AS LastCommentDate,  " + 
                                        " CAST(0 AS bit) AS Selected, LFC.Name AS CategoryName  " +

                                        " FROM         LFS_ITTST_SUPPORTICKET AS LITST LEFT JOIN  "+
                                        " LFS_RESOURCES_EMPLOYEE LEOwner ON LITST.CreatedByID = LEOwner.EmployeeID INNER JOIN" +
                                        " LFS_ITTST_CATEGORY LFC ON LITST.CategoryID = LFC.CategoryID "+
                                        " WHERE {0} {1} {2}", where, whereClauseSpecial, orderBy);
            FillData(commandText);
        }
            
          

    }
}