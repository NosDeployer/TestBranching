using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FlInversionFieldCureRecordReportGateway
    /// </summary>
    public class FlInversionFieldCureRecordReportGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlInversionFieldCureRecordReportGateway()
            : base("LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlInversionFieldCureRecordReportGateway(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlInversionReportTDS();
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
            tableMapping.DataSetTable = "LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("ReadingTime", "ReadingTime");
            tableMapping.ColumnMappings.Add("HeadFt", "HeadFt");
            tableMapping.ColumnMappings.Add("BoilerInF", "BoilerInF");
            tableMapping.ColumnMappings.Add("BoilerOutF", "BoilerOutF");
            tableMapping.ColumnMappings.Add("PumpFlow", "PumpFlow");
            tableMapping.ColumnMappings.Add("PumpPsi", "PumpPsi");
            tableMapping.ColumnMappings.Add("MH1Top", "MH1Top");
            tableMapping.ColumnMappings.Add("MH1Bot", "MH1Bot");
            tableMapping.ColumnMappings.Add("MH2Top", "MH2Top");
            tableMapping.ColumnMappings.Add("MH2Bot", "MH2Bot");
            tableMapping.ColumnMappings.Add("MH3Top", "MH3Top");
            tableMapping.ColumnMappings.Add("MH3Bot", "MH3Bot");
            tableMapping.ColumnMappings.Add("MH4Top", "MH4Top");
            tableMapping.ColumnMappings.Add("MH4Bot", "MH4Bot");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");            this._adapter.TableMappings.Add(tableMapping);

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
        /// LoadByWorkId
        /// </summary>
        /// <param name="companyId">companyId</param>        
        /// <param name="workId">workId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByWorkId(int companyId, int workId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLINVERSIONFIELDCURERECORDREPORTGATEWAY_LOADBYWORKID", new SqlParameter("@companyId", companyId), new SqlParameter("@workId", workId));
            return Data;
        }
    }
}
