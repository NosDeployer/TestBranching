using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeeInformationNoteInformationGateway
    /// </summary>
    public class EmployeeInformationNoteInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeInformationNoteInformationGateway()
            : base("NoteInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeInformationNoteInformationGateway(DataSet data)
            : base(data, "NoteInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeInformationTDS();
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
            tableMapping.DataSetTable = "NoteInformation";
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("UserID", "UserID");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("Note", "Note");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");            
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
        /// LoadAllByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAllByEmployeeId(int employeeId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEINFORMATIONNOTEINFORMATIONGATEWAY_LOADALLBYEMPLOYEEID", new SqlParameter("@employeeId", employeeId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int employeeId, int refId)
        {
            string filter = string.Format("EmployeeID = {0} AND RefID = {1}", employeeId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Employees.EmployeeInformationNoteInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetSubject
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Subject or EMPTY</returns>
        public string GetSubject(int employeeId, int refId)
        {
            if (GetRow(employeeId, refId).IsNull("Subject"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId, refId)["Subject"];
            }
        }



        /// <summary>
        /// GetSubject Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Subject or EMPTY</returns>
        public string GetSubjectOriginal(int employeeId, int refId)
        {
            if (GetRow(employeeId, refId).IsNull(Table.Columns["Subject"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId, refId)["Subject", DataRowVersion.Original];
            }
        }


        
        /// <summary>
        /// GetUserId Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original UserId</returns>
        public int GetUserIdOriginal(int employeeId, int refId)
        {
            return (int)GetRow(employeeId, refId)["UserID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDateTime_ Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original DateTime_</returns>
        public DateTime GetDateTime_Original(int employeeId, int refId)
        {
            return (DateTime)GetRow(employeeId, refId)["DateTime_", DataRowVersion.Original];
        }



        /// <summary>
        /// GetNote
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Note or EMPTY</returns>
        public string GetNote(int employeeId, int refId)
        {
            if (GetRow(employeeId, refId).IsNull("Note"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId, refId)["Note"];
            }
        }



        /// <summary>
        /// GetNote Original
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Note or EMPTY</returns>
        public string GetNoteOriginal(int employeeId, int refId)
        {
            if (GetRow(employeeId, refId).IsNull(Table.Columns["Note"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId, refId)["Note", DataRowVersion.Original];
            }
        }



    }
}