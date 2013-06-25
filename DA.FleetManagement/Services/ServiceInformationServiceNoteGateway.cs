using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServiceInformationServiceNote
    /// </summary>
    public class ServiceInformationServiceNoteGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceInformationServiceNoteGateway()
            : base("NoteInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServiceInformationServiceNoteGateway(DataSet data)
            : base(data, "NoteInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServiceInformationTDS();
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
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("UserID", "UserID");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("Note", "Note");
            tableMapping.ColumnMappings.Add("LIBRARY_FILES_ID", "LIBRARY_FILES_ID");
            tableMapping.ColumnMappings.Add("ORIGINAL_FILENAME", "ORIGINAL_FILENAME");
            tableMapping.ColumnMappings.Add("FILENAME", "FILENAME");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InServiceNoteDatabase", "InServiceNoteDatabase");            
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
        /// LoadAllByServiceId
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAllByServiceId(int serviceId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICEINFORMATIONSERVICENOTEGATEWAY_LOADALLBYSERVICEID", new SqlParameter("@serviceId", serviceId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int serviceId, int refId)
        {
            string filter = string.Format("ServiceID = {0} AND RefID = {1}", serviceId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Services.ServiceInformationServiceNoteGateway.GetRow");
            }
        }



        /// <summary>
        /// GetSubject
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Subject or EMPTY</returns>
        public string GetSubject(int serviceId, int refId)
        {
            if (GetRow(serviceId, refId).IsNull("Subject"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId, refId)["Subject"];
            }
        }



        /// <summary>
        /// GetSubject Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Subject or EMPTY</returns>
        public string GetSubjectOriginal(int serviceId, int refId)
        {
            if (GetRow(serviceId, refId).IsNull(Table.Columns["Subject"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId, refId)["Subject", DataRowVersion.Original];
            }
        }


        
        /// <summary>
        /// GetUserId Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original UserId or EMPTY</returns>
        public int GetUserIdOriginal(int serviceId, int refId)
        {
            return (int)GetRow(serviceId, refId)["UserID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDateTime_ Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original DateTime_ or EMPTY</returns>
        public DateTime GetDateTime_Original(int serviceId, int refId)
        {
            return (DateTime) GetRow(serviceId, refId)["DateTime_", DataRowVersion.Original];
        }



        /// <summary>
        /// GetNote
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Note or EMPTY</returns>
        public string GetNote(int serviceId, int refId)
        {
            if (GetRow(serviceId, refId).IsNull("Note"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId, refId)["Note"];
            }
        }



        /// <summary>
        /// GetNote Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Note or EMPTY</returns>
        public string GetNoteOriginal(int serviceId, int refId)
        {
            if (GetRow(serviceId, refId).IsNull(Table.Columns["Note"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId, refId)["Note", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLibraryFilesId
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>LIBRARY_FILES_ID or EMPTY</returns>
        public int? GetLibraryFilesId(int serviceId, int refId)
        {
            if (GetRow(serviceId, refId).IsNull("LIBRARY_FILES_ID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(serviceId, refId)["LIBRARY_FILES_ID"];
            }
        }



        /// <summary>
        /// GetLibraryFilesId Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original LIBRARY_FILES_ID or EMPTY</returns>
        public int? GetLibraryFilesIdOriginal(int serviceId, int refId)
        {
            if (GetRow(serviceId, refId).IsNull(Table.Columns["LIBRARY_FILES_ID"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(serviceId, refId)["LIBRARY_FILES_ID", DataRowVersion.Original];
            }
        }



    }
}