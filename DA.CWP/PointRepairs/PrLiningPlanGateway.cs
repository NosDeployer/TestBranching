using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Section;

namespace LiquiForce.LFSLive.DA.CWP.PointRepairs
{
    /// <summary>
    /// PlLiningPlanGateway
    /// </summary>
    public class PrLiningPlanGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PrLiningPlanGateway()
            : base("PlLiningPlan")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PrLiningPlanGateway(DataSet data)
            : base(data, "PlLiningPlan")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PlLiningPlanTDS();
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
            tableMapping.DataSetTable = "PlLiningPlan";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("RepairPointID", "RepairPointID");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("UsmhDescription", "UsmhDescription");
            tableMapping.ColumnMappings.Add("DsmhDescription", "DsmhDescription");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("ReamDistance", "ReamDistance");
            tableMapping.ColumnMappings.Add("ReamDate", "ReamDate");
            tableMapping.ColumnMappings.Add("LinerDistance", "LinerDistance");
            tableMapping.ColumnMappings.Add("Direction", "Direction");
            tableMapping.ColumnMappings.Add("Reinstates", "Reinstates");
            tableMapping.ColumnMappings.Add("LTMH", "LTMH");
            tableMapping.ColumnMappings.Add("VTMH", "VTMH");
            tableMapping.ColumnMappings.Add("Distance", "Distance");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("InstallDate", "InstallDate");
            tableMapping.ColumnMappings.Add("MHShot", "MHShot");
            tableMapping.ColumnMappings.Add("GroutDistance", "GroutDistance");
            tableMapping.ColumnMappings.Add("GroutDate", "GroutDate");
            tableMapping.ColumnMappings.Add("Approval", "Approval");
            tableMapping.ColumnMappings.Add("ExtraRepair", "ExtraRepair");
            tableMapping.ColumnMappings.Add("Cancelled", "Cancelled");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Liner", "Liner");
            tableMapping.ColumnMappings.Add("LinerMN", "LinerMN");
            tableMapping.ColumnMappings.Add("Video", "Video");
            tableMapping.ColumnMappings.Add("VideoMN", "VideoMN");
            tableMapping.ColumnMappings.Add("DefectQualifier", "DefectQualifier");
            tableMapping.ColumnMappings.Add("DefectDetails", "DefectDetails");
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
        /// Load
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet Load(int projectId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_PLLININGPLANGATEWAY_LOAD", new SqlParameter("@projectId", projectId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadWithoutIssueIdentifiedWithoutInstallDateWithoutCancelledWithoutNotApproved
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadWithoutIssueIdentifiedWithoutInstallDateWithoutCancelledWithoutNotApproved(int projectId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_PLLININGPLANGATEWAY_LOADWITHOUTISSUEIDENTIFIEDWITHOUTINSTALLDATEWITHOUTCANCELLEDWITHOUTNOTAPPROVED", new SqlParameter("@projectId", projectId), new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}