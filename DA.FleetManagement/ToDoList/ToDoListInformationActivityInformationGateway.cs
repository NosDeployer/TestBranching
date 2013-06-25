using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListInformationActivityInformationGateway
    /// </summary>
    public class ToDoListInformationActivityInformationGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListInformationActivityInformationGateway()
            : base("ActivityInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ToDoListInformationActivityInformationGateway(DataSet data)
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



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "ActivityInformation";
            tableMapping.ColumnMappings.Add("ToDoID", "ToDoID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("Type_", "Type_");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("EmployeeFullName", "EmployeeFullName");
            
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
        /// LoadAllByToDoId
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadAllByToDoId(int toDoId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_TODOLISTINFORMATIONACTIVITYINFORMATIONGATEWAY_LOADALLBYTODOID", new SqlParameter("@toDoId", toDoId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadLastActivityByToDoId
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadLastActivityByToDoId(int toDoId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_TODOLISTINFORMATIONACTIVITYINFORMATIONGATEWAY_LOADLASTACTIVITYBYTODOID", new SqlParameter("@toDoId", toDoId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int toDoId, int refId)
        {
            string filter = string.Format("ToDoID = {0} AND RefID = {1}", toDoId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.ToDoList.ToDoListInformationActivityInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetEmployeeID
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="refId">refId</param>
        /// <returns>EmployeeID or EMPTY</returns>
        public int GetEmployeeID(int toDoId, int refId)
        {           
            return (int)GetRow(toDoId, refId)["EmployeeID"];           
        }



        /// <summary>
        /// GetEmployeeID Original
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original EmployeeID or EMPTY</returns>
        public int GetEmployeeIDOriginal(int toDoId, int refId)
        {          
            return (int)GetRow(toDoId, refId)["EmployeeID", DataRowVersion.Original];           
        }



        /// <summary>
        /// GetType_
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="refId">refId</param>
        /// <returns>Type_ or EMPTY</returns>
        public string GetType_(int toDoId, int refId)
        {
            if (GetRow(toDoId, refId).IsNull("Type_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(toDoId, refId)["Type_"];
            }
        }



        /// <summary>
        /// GetDateTime_
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="refId">refId</param>
        /// <returns>DateTime_ or EMPTY</returns>
        public DateTime GetDateTime_(int toDoId, int refId)
        {
            return (DateTime)GetRow(toDoId, refId)["DateTime_"];         
        }



        /// <summary>
        /// GetComment
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="refId">refId</param>
        /// <returns>Comment or EMPTY</returns>
        public string GetComment(int toDoId, int refId)
        {
            if (GetRow(toDoId, refId).IsNull("Comment"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(toDoId, refId)["Comment"];
            }
        }


        
        /// <summary>
        /// GetComment Original
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Comment or EMPTY</returns>
        public string GetCommentOriginal(int toDoId, int refId)
        {
            if (GetRow(toDoId, refId).IsNull(Table.Columns["Comment"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(toDoId, refId)["Comment", DataRowVersion.Original];
            }
        }

        

        /// <summary>
        /// GetEmployeeFullName
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="refId">refId</param>
        /// <returns>EmployeeFullName or EMPTY</returns>
        public string GetEmployeeFullName(int toDoId, int refId)
        {
            if (GetRow(toDoId, refId).IsNull("EmployeeFullName"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(toDoId, refId)["EmployeeFullName"];
            }
        }



    }
}
