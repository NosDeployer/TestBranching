using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListInformationBasicInformationGateway
    /// </summary>
    public class ToDoListInformationBasicInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListInformationBasicInformationGateway()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ToDoListInformationBasicInformationGateway(DataSet data)
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



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "BasicInformation";
            tableMapping.ColumnMappings.Add("ToDoID", "ToDoID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("CreationDate", "CreationDate");
            tableMapping.ColumnMappings.Add("CreatedByID", "CreatedByID");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("DueDate", "DueDate");
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");

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
        /// <returns>Data</returns>
        public DataSet LoadAllByToDoId(int toDoId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_TODOINFORMATIONBASICINFORMATIONGATEWAY_LOADALLBYTODOID", new SqlParameter("@toDoId", toDoId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        ///// <summary>
        ///// LoadInProgressByRuleId
        ///// </summary>
        ///// <param name="ruleId">ruleId</param>
        ///// <param name="companyId">companyId</param>
        ///// <returns>Data</returns>
        //public DataSet LoadInProgressByRuleId(int ruleId, int companyId)
        //{
        //    FillDataWithStoredProcedure("LFS_FM_SERVICEINFORMATIONBASICINFORMATIONGATEWAY_LOADINPROGRESSBYRULEID", new SqlParameter("ruleId", ruleId), new SqlParameter("@companyId", companyId));
        //    return Data;
        //}



        ///// <summary>
        ///// LoadInProgressByUnitIdRuleId
        ///// </summary>
        ///// <param name="unitId">unitId</param>
        ///// <param name="ruleId">ruleId</param>
        ///// <param name="companyId">companyId</param>
        ///// <returns>Data</returns>
        //public DataSet LoadInProgressByUnitIdRuleId(int unitId, int ruleId, int companyId)
        //{
        //    FillDataWithStoredProcedure("LFS_FM_SERVICEINFORMATIONBASICINFORMATIONGATEWAY_LOADINPROGRESSBYUNITIDRULEID", new SqlParameter("@unitId", unitId), new SqlParameter("ruleId", ruleId), new SqlParameter("@companyId", companyId));
        //    return Data;
        //}



        ///// <summary>
        ///// LoadByServiceId
        ///// </summary>
        ///// <param name="toDoId">toDoId</param>
        ///// <param name="companyId">companyId</param>
        ///// <returns>Data</returns>
        //public DataSet LoadInProgressByServiceIdUnitIdRuleId(int toDoId, int unitId, int ruleId, int companyId)
        //{
        //    FillDataWithStoredProcedure("LFS_FM_SERVICESGATEWAY_LOADINPROGRESSBYSERVICEIDUNITIDRULEID", new SqlParameter("@toDoId", toDoId), new SqlParameter("@unitId", unitId), new SqlParameter("@ruleId", ruleId), new SqlParameter("@companyId", companyId));
        //    return Data;
        //}



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int toDoId)
        {
            string filter = string.Format("ToDoID = {0}", toDoId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.ToDoList.ToDoListInformationBasicInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetState
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <returns>State or EMPTY</returns>
        public string GetState(int toDoId)
        {
            if (GetRow(toDoId).IsNull("State"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(toDoId)["State"];
            }
        }



        /// <summary>
        /// GetState Original
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <returns>Original State or EMPTY</returns>
        public string GetStateOriginal(int toDoId)
        {
            if (GetRow(toDoId).IsNull(Table.Columns["State"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(toDoId)["State", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSubject
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <returns>Subject or EMPTY</returns>
        public string GetSubject(int toDoId)
        {
            if (GetRow(toDoId).IsNull("Subject"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(toDoId)["Subject"];
            }
        }



        /// <summary>
        /// GetSubject Original
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <returns>Original Subject or EMPTY</returns>
        public string GetSubjectOriginal(int toDoId)
        {
            if (GetRow(toDoId).IsNull(Table.Columns["Subject"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(toDoId)["Subject", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDueDate
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <returns>DueDate or EMPTY</returns>
        public DateTime? GetDueDate(int toDoId)
        {
            if (GetRow(toDoId).IsNull("DueDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(toDoId)["DueDate"];
            }
        }



        /// <summary>
        /// GetDueDate Original If not exists, raise an exception.
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <returns>DueDate</returns>
        public DateTime? GetDueDateOriginal(int toDoId)
        {
            if (GetRow(toDoId).IsNull(Table.Columns["DueDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(toDoId)["DueDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCreationDate If not exists, raise an exception.
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <returns>CreationDate</returns>
        public DateTime GetCreationDate(int toDoId)
        {
            return (DateTime)GetRow(toDoId)["CreationDate"];
        }



        /// <summary>
        /// GetUnitID
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <returns>UnitID or EMPTY</returns>
        public int? GetUnitID(int toDoId)
        {
            if (GetRow(toDoId).IsNull("UnitID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(toDoId)["UnitID"];
            }
        }



        /// <summary>
        /// GetUnitID Original
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <returns>Original UnitID or EMPTY</returns>
        public int? GetUnitIDOriginal(int toDoId)
        {
            if (GetRow(toDoId).IsNull(Table.Columns["UnitID"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(toDoId)["UnitID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCreatedByID. If not exists, raise an exception.
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <returns>CreatedByID</returns>
        public int GetCreatedByID(int toDoId)
        {
            return (int)GetRow(toDoId)["CreatedByID"];
        }
                        
    }
}