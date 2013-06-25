using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Units
{
    /// <summary>
    /// UnitInformationNoteDetailsGateway
    /// </summary>
    public class UnitInformationNoteDetailsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitInformationNoteDetailsGateway()
            : base("NoteInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitInformationNoteDetailsGateway(DataSet data)
            : base(data, "NoteInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitInformationTDS();
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
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("UserID", "UserID");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("Note", "Note");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("LIBRARY_FILES_ID", "LIBRARY_FILES_ID");
            tableMapping.ColumnMappings.Add("ORIGINAL_FILENAME", "ORIGINAL_FILENAME");
            tableMapping.ColumnMappings.Add("FILENAME", "FILENAME");
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
        /// LoadAllByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAllByUnitId(int unitId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITINFORMATIONNOTEDETAILSGATEWAY_LOADALLBYUNITID", new SqlParameter("@unitId", unitId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int unitId, int refId)
        {
            string filter = string.Format("UnitID = {0} AND RefID = {1}", unitId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Units.UnitInformationNoteDetailsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetSubject
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <returns>Subject or EMPTY</returns>
        public string GetSubject(int unitId, int refId)
        {
            if (GetRow(unitId, refId).IsNull("Subject"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId, refId)["Subject"];
            }
        }



        /// <summary>
        /// GetSubject Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Subject or EMPTY</returns>
        public string GetSubjectOriginal(int unitId, int refId)
        {
            if (GetRow(unitId, refId).IsNull(Table.Columns["Subject"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId, refId)["Subject", DataRowVersion.Original];
            }
        }


        
        /// <summary>
        /// GetUserId Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original UserId or EMPTY</returns>
        public int GetUserIdOriginal(int unitId, int refId)
        {
            return (int)GetRow(unitId, refId)["UserID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDateTime_ Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original DateTime_ or EMPTY</returns>
        public DateTime GetDateTime_Original(int unitId, int refId)
        {
            return (DateTime)GetRow(unitId, refId)["DateTime_", DataRowVersion.Original];
        }



        /// <summary>
        /// GetNote
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <returns>Note or EMPTY</returns>
        public string GetNote(int unitId, int refId)
        {
            if (GetRow(unitId, refId).IsNull("Note"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId, refId)["Note"];
            }
        }



        /// <summary>
        /// GetNote Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Note or EMPTY</returns>
        public string GetNoteOriginal(int unitId, int refId)
        {
            if (GetRow(unitId, refId).IsNull(Table.Columns["Note"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId, refId)["Note", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLibraryFilesId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <returns>LibraryFilesId or NULL</returns>
        public int? GetLibraryFilesId(int unitId, int refId)
        {
            if (GetRow(unitId, refId).IsNull("LIBRARY_FILES_ID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(unitId, refId)["LIBRARY_FILES_ID"];
            }
        }



        /// <summary>
        /// GetLibraryFilesId Original
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original LibraryFilesId or NULL</returns>
        public int? GetLibraryFilesIdOriginal(int unitId, int refId)
        {
            if (GetRow(unitId, refId).IsNull(Table.Columns["LIBRARY_FILES_ID"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(unitId, refId)["LIBRARY_FILES_ID", DataRowVersion.Original];
            }
        }



    }
}