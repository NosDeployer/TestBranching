using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.WebUI.export.Temp;

namespace LiquiForce.LFSLive.WebUI
{
    /// <summary>
    /// JlDataMigrationGateway
    /// </summary>
    public class JlDataMigrationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public JlDataMigrationGateway()
            : base("JlDataMigration")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public JlDataMigrationGateway(DataSet data)
            : base(data, "JlDataMigration")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new DataMigrationTDS();
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
            tableMapping.DataSetTable = "JlDataMigration";
            tableMapping.ColumnMappings.Add("OriginalID", "OriginalID");
            tableMapping.ColumnMappings.Add("OriginalSectionID", "OriginalSectionID");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("Client", "Client");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("ScaledLength", "ScaledLength");
            tableMapping.ColumnMappings.Add("ActualLength", "ActualLength");
            tableMapping.ColumnMappings.Add("ConfirmedSize", "ConfirmedSize");
            tableMapping.ColumnMappings.Add("JLiner", "JLiner");
            tableMapping.ColumnMappings.Add("USMHMN", "USMHMN");
            tableMapping.ColumnMappings.Add("DSMHMN", "DSMHMN");
            tableMapping.ColumnMappings.Add("USMHDepth", "USMHDepth");
            tableMapping.ColumnMappings.Add("DSMHDepth", "DSMHDepth");
            tableMapping.ColumnMappings.Add("SteelTapeThruPipe", "SteelTapeThruPipe");
            tableMapping.ColumnMappings.Add("USMHAtMouth1200", "USMHAtMouth1200");
            tableMapping.ColumnMappings.Add("USMHAtMouth100", "USMHAtMouth100");
            tableMapping.ColumnMappings.Add("USMHAtMouth200", "USMHAtMouth200");
            tableMapping.ColumnMappings.Add("USMHAtMouth300", "USMHAtMouth300");
            tableMapping.ColumnMappings.Add("USMHAtMouth400", "USMHAtMouth400");
            tableMapping.ColumnMappings.Add("USMHAtMouth500", "USMHAtMouth500");
            tableMapping.ColumnMappings.Add("DSMHAtMouth1200", "DSMHAtMouth1200");
            tableMapping.ColumnMappings.Add("DSMHAtMouth100", "DSMHAtMouth100");
            tableMapping.ColumnMappings.Add("DSMHAtMouth200", "DSMHAtMouth200");
            tableMapping.ColumnMappings.Add("DSMHAtMouth300", "DSMHAtMouth300");
            tableMapping.ColumnMappings.Add("DSMHAtMouth400", "DSMHAtMouth400");
            tableMapping.ColumnMappings.Add("DSMHAtMouth500", "DSMHAtMouth500");
            tableMapping.ColumnMappings.Add("NumLats", "NumLats");
            tableMapping.ColumnMappings.Add("NotLinedYet", "NotLinedYet");
            tableMapping.ColumnMappings.Add("AllMeasured", "AllMeasured");
            tableMapping.ColumnMappings.Add("IssueWithLaterals", "IssueWithLaterals");
            tableMapping.ColumnMappings.Add("NotMeasuredYet", "NotMeasuredYet");
            tableMapping.ColumnMappings.Add("NotDeliveredYet", "NotDeliveredYet");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        /// <summary>
        /// InsertDataMigration
        /// </summary>
        /// <param name="originalId"></param>
        /// <param name="originalSectionId"></param>
        /// <param name="newId"></param>
        /// <param name="newSectionId"></param>
        public void InsertDataMigration(Guid originalId, string originalSectionId, int newId, string newSectionId)
        {
            SqlParameter originalIdParameter = new SqlParameter("OriginalID", originalId);
            SqlParameter originalSectionIdParameter = new SqlParameter("OriginalSectionID", originalSectionId);
            SqlParameter newIdParameter = new SqlParameter("NewID", newId);
            SqlParameter newSectionIdParameter = new SqlParameter("NewSectionID", newSectionId);

            string command = "INSERT INTO [dbo].[LFS_MIGRATED_SECTIONS] ([OriginalID], [OriginalSectionID], [NewID], [NewSectionID]) VALUES (@OriginalID, @OriginalSectionID, @NewID, @NewSectionID);";

            ExecuteNonQuery(command, originalIdParameter, originalSectionIdParameter, newIdParameter, newSectionIdParameter);
        }



        /// <summary>
        /// InsertMaterial
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="materialType"></param>
        /// <param name="date_"></param>
        /// <param name="deleted"></param>
        /// <param name="companyId"></param>
        public void InsertMaterial(int assetId, int refId, string materialType, DateTime date_, bool deleted, int companyId)
        {
            SqlParameter assetIdParameter = new SqlParameter("AssetID", assetId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter materialTypeParameter = new SqlParameter("MaterialType", materialType);
            SqlParameter date_Parameter = new SqlParameter("Date_", date_);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);

            string command = "INSERT INTO [dbo].[AM_ASSET_SEWER_MATERIAL] ([AssetID], [RefID], [MaterialType], [Date_], [COMPANY_ID], [Deleted]) VALUES (@AssetID, @RefID, @MaterialType, @Date_, @COMPANY_ID, @Deleted);";

            ExecuteNonQuery(command, assetIdParameter, refIdParameter, materialTypeParameter, date_Parameter, companyIdParameter, deletedParameter);
        }


        /// <summary>
        /// GetOriginalIdByCompanyIdCompaniesIdRecordIdStreet
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Guid GetOriginalIdByCompanyIdCompaniesIdRecordIdStreet(int companyId, int companiesId, string recordId, string street)
        {
            string commandText = "SELECT ID FROM LFS_MASTER_AREA WHERE (COMPANY_ID = @companyId) AND (COMPANIES_ID = @companiesId) AND (RecordID LIKE '%' + @recordId + '%') ";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@companyId", companyId));
            command.Parameters.Add(new SqlParameter("@companiesId", companiesId));
            command.Parameters.Add(new SqlParameter("@recordId", recordId));
            Guid projectId = (Guid)(ExecuteScalar(command));

            return projectId;
        }



        /// <summary>
        /// IsMigratedSection
        /// </summary>
        /// <param name="originalId"></param>
        /// <param name="originalSectionId"></param>
        /// <returns></returns>
        public bool IsMigratedSection(Guid originalId, string originalSectionId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_MIGRATED_SECTIONS WHERE (OriginalID = @originalId) AND (OriginalSectionID = @recordId) ";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@originalId", originalId));
            command.Parameters.Add(new SqlParameter("@recordId", originalSectionId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }


        
    }
}

