using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.JunctionLining
{
    /// <summary>
    /// JlLiningPlanGateway
    /// </summary>
    public class JlLiningPlanGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlLiningPlanGateway() : base("JlLiningPlan")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlLiningPlanGateway(DataSet data)
            : base(data, "JlLiningPlan")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlLiningPlanTDS();
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
            tableMapping.DataSetTable = "JlLiningPlan";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("StandardBypass", "StandardBypass");
            tableMapping.ColumnMappings.Add("StandardBypassComments", "StandardBypassComments");
            tableMapping.ColumnMappings.Add("TrafficControl", "TrafficControl");
            tableMapping.ColumnMappings.Add("TrafficControlDetails", "TrafficControlDetails");
            tableMapping.ColumnMappings.Add("NumLats", "NumLats");
            tableMapping.ColumnMappings.Add("NotLinedYet", "NotLinedYet");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("AllMeasured", "AllMeasured");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("Flusher", "Flusher");
            tableMapping.ColumnMappings.Add("FlusherMN", "FlusherMN");
            tableMapping.ColumnMappings.Add("Liner", "Liner");
            tableMapping.ColumnMappings.Add("LinerMN", "LinerMN");
            tableMapping.ColumnMappings.Add("Rotator", "Rotator");
            tableMapping.ColumnMappings.Add("RotatorMN", "RotatorMN");
            tableMapping.ColumnMappings.Add("Compressor", "Compressor");
            tableMapping.ColumnMappings.Add("CompressorMN", "CompressorMN");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("NotMeasuredYet", "NotMeasuredYet");
            tableMapping.ColumnMappings.Add("IssueWithLaterals", "IssueWithLaterals");
            tableMapping.ColumnMappings.Add("NotDeliveredYet", "NotDeliveredYet");
            tableMapping.ColumnMappings.Add("USMHDescription", "USMHDescription");
            tableMapping.ColumnMappings.Add("DSMHDescription", "DSMHDescription");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("USMHAddress", "USMHAddress");
            tableMapping.ColumnMappings.Add("DSMHAddress", "DSMHAddress");
            tableMapping.ColumnMappings.Add("AvailableToLine", "AvailableToLine");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATSET
        //

        /// <summary>
        /// LoadByProjectIdIssueWithLateralsNoOutOfScope
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="projectId">projectId</param>
        /// <returns>Data</returns>
        public DataSet LoadByProjectIdIssueWithLateralsNoOutOfScope(int companyId, int projectId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLLININGPLANGATEWAY_LOADBYPROJECTIDISSUEWITHLATERALSNOOUTOFSCOPE", new SqlParameter("@companyId", companyId), new SqlParameter("@projectId", projectId));
            return Data;
        }



        /// <summary>
        /// LoadByProjectIdOtherIssueWithLaterals
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="projectId">projectId</param>       
        /// <returns>Data</returns>
        public DataSet LoadByProjectIdOtherIssueWithLaterals(int companyId, int projectId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLLININGPLANGATEWAY_LOADBYPROJECTIDOTHERISSUEWITHLATERALS", new SqlParameter("@companyId", companyId), new SqlParameter("@projectId", projectId));
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// IsLateralsIssueNo
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Returns true if all laterals have Issue = No</returns>
        public bool IsLateralsIssueNo(int workId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLLININGPLANGATEWAY_ISLATERALSISSUENO", new SqlParameter("@workId", workId));
            bool use = false;
            if ((int)Table.Rows.Count > 0)
            {
                use = true;
            }

            return use;
        }



        /// <summary>
        /// IsLateralsIssueYes
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Returns true if at least one lateral issue is true and the rest no</returns>
        public bool IsLateralsIssueYes(int workId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLLININGPLANGATEWAY_ISLATERALSISSUEYES", new SqlParameter("@workId", workId));//Note: COMPANY_ID
            bool use = false;
            if ((int)Table.Rows.Count > 0)
            {
                use = true;
            }

            return use;
        }



        /// <summary>
        /// IsLateralsIssueOutOfScope
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Returns true if at least one lateral issue is Out Of Scope and the rest no</returns>
        public bool IsLateralsIssueOutOfScope(int workId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLLININGPLANGATEWAY_ISLATERALSISSUEOUTOFSCOPE", new SqlParameter("@workId", workId));//Note: COMPANY_ID
            bool use = false;
            if ((int)Table.Rows.Count > 0)
            {
                use = true;
            }

            return use;
        }



        /// <summary>
        /// IsLateralsIssueYesOutOfScope
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Returns true if at least one lateral issue is yes, at least one is Out Of Scope and the rest no</returns>
        public bool IsLateralsIssueYesOutOfScope(int workId)
        {
            FillDataWithStoredProcedure("LFS_CWP_JLLININGPLANGATEWAY_ISLATERALSISSUEYESOUTOFSCOPE", new SqlParameter("@workId", workId));//Note: COMPANY_ID
            bool use = false;
            if ((int)Table.Rows.Count > 0)
            {
                use = true;
            }

            return use;
        }



    }
}