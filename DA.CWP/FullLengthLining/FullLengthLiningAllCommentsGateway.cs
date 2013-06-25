using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FullLengthLiningAllCommentsGateway
    /// </summary>
    public class FullLengthLiningAllCommentsGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FullLengthLiningAllCommentsGateway()
            : base("AllComments")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FullLengthLiningAllCommentsGateway(DataSet data)
            : base(data, "AllComments")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FullLengthLiningTDS();
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
            tableMapping.DataSetTable = "AllComments";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("UserID", "UserID");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("LIBRARY_FILES_ID", "LIBRARY_FILES_ID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");            
            tableMapping.ColumnMappings.Add("WorkType", "WorkType");
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
        /// LoadAllByJlWorkIdRaWorkId
        /// </summary>
        /// <param name="flWorkId">flWorkId</param>
        /// <param name="raWorkId">raWorkId</param>
        /// <param name="companyId">companyId</param>       
        /// <returns>data set</returns>
        public DataSet LoadAllByJlWorkIdRaWorkId(int flWorkId, int raWorkId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLATSECTIONJLALLCOMMENTSGATEWAY_LOADALLBYFLWORKIDRAWORKID", new SqlParameter("@flWorkId", flWorkId), new SqlParameter("@raWorkId", raWorkId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int workId, int refId)
        {
            string filter = string.Format("WorkID = {0} AND RefID = {1}", workId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.FullLenthLining.FullLengthLiningAllCommentsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetSubject
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Subject or EMPTY</returns>
        public string GetSubject(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("Subject"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, refId)["Subject"];
            }
        }



        /// <summary>
        /// GetSubject Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Subject or EMPTY</returns>
        public string GetSubjectOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["Subject"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, refId)["Subject", DataRowVersion.Original];
            }
        }


        
        /// <summary>
        /// GetUserId Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original UserId or EMPTY</returns>
        public int GetUserIdOriginal(int workId, int refId)
        {
            return (int)GetRow(workId, refId)["UserID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDateTime_ Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original DateTime_ or EMPTY</returns>
        public DateTime GetDateTime_Original(int workId, int refId)
        {
            return (DateTime) GetRow(workId, refId)["DateTime_", DataRowVersion.Original];
        }



        /// <summary>
        /// GetComment
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Comment or EMPTY</returns>
        public string GetComment(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("Comment"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, refId)["Comment"];
            }
        }



        /// <summary>
        /// GetComment Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Comment or EMPTY</returns>
        public string GetCommentOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["Comment"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, refId)["Comment", DataRowVersion.Original];
            }
        }


        
        /// <summary>
        /// GetType
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Type or EMPTY</returns>
        public string GetType(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("Type"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, refId)["Type"];
            }
        }



        /// <summary>
        /// GetType Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Type or EMPTY</returns>
        public string GetTypeOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["Type"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, refId)["Type", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLIBRARY_FILES_ID
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>LIBRARY_FILES_ID or EMPTY</returns>
        public int? GetLIBRARY_FILES_ID(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("LIBRARY_FILES_ID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId, refId)["LIBRARY_FILES_ID"];
            }
        }



        /// <summary>
        /// GetLIBRARY_FILES_ID Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original LIBRARY_FILES_ID or EMPTY</returns>
        public int? GetLIBRARY_FILES_IDOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["LIBRARY_FILES_ID"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId, refId)["LIBRARY_FILES_ID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetWorkType
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>WorkType or EMPTY</returns>
        public string GetWorkType(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("WorkType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, refId)["WorkType"];
            }
        }



        /// <summary>
        /// GetWorkType Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original WorkType or EMPTY</returns>
        public string GetWorkTypeOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["WorkType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, refId)["WorkType", DataRowVersion.Original];
            }
        }








    }
}

