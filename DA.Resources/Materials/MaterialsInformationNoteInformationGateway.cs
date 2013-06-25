using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Materials
{
    /// <summary>
    /// MaterialsInformationNoteInformationGateway
    /// </summary>
    public class MaterialsInformationNoteInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsInformationNoteInformationGateway()
            : base("NoteInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsInformationNoteInformationGateway(DataSet data)
            : base(data, "NoteInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MaterialsInformationTDS();
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
            tableMapping.ColumnMappings.Add("MaterialID", "MaterialID");
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
        /// LoadAllByMaterialId
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAllByMaterialId(int materialId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_MATERIALSINFORMATIONNOTEINFORMATIONGATEWAY_LOADALLBYMATERIAL", new SqlParameter("@materialId", materialId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int materialId, int refId)
        {
            string filter = string.Format("MaterialID = {0} AND RefID = {1}", materialId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Materials.MaterialsInformationServiceNoteGateway.GetRow");
            }
        }



        /// <summary>
        /// GetSubject
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        /// <returns>Subject or EMPTY</returns>
        public string GetSubject(int materialId, int refId)
        {
            if (GetRow(materialId, refId).IsNull("Subject"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(materialId, refId)["Subject"];
            }
        }



        /// <summary>
        /// GetSubject Original
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Subject or EMPTY</returns>
        public string GetSubjectOriginal(int materialId, int refId)
        {
            if (GetRow(materialId, refId).IsNull(Table.Columns["Subject"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(materialId, refId)["Subject", DataRowVersion.Original];
            }
        }


        
        /// <summary>
        /// GetUserId Original
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original UserId or EMPTY</returns>
        public int GetUserIdOriginal(int materialId, int refId)
        {
            return (int)GetRow(materialId, refId)["UserID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDateTime_ Original
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original DateTime_ or EMPTY</returns>
        public DateTime GetDateTime_Original(int materialId, int refId)
        {
            return (DateTime)GetRow(materialId, refId)["DateTime_", DataRowVersion.Original];
        }



        /// <summary>
        /// GetNote
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        /// <returns>Note or EMPTY</returns>
        public string GetNote(int materialId, int refId)
        {
            if (GetRow(materialId, refId).IsNull("Note"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(materialId, refId)["Note"];
            }
        }



        /// <summary>
        /// GetNote Original
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Note or EMPTY</returns>
        public string GetNoteOriginal(int materialId, int refId)
        {
            if (GetRow(materialId, refId).IsNull(Table.Columns["Note"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(materialId, refId)["Note", DataRowVersion.Original];
            }
        }



    }
}
