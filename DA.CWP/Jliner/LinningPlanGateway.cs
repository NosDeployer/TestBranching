using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Section;

namespace LiquiForce.LFSLive.DA.CWP.Jliner
{
    /// <summary>
    /// LinningPlanGateway
    /// </summary>
    public class LinningPlanGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LinningPlanGateway() : base("LinningPlan")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LinningPlanGateway(DataSet data) : base(data, "LinningPlan")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new LinningPlanTDS();
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
            tableMapping.DataSetTable = "LinningPlan";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("RecordID", "RecordID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("ConfirmedSize", "ConfirmedSize");
            tableMapping.ColumnMappings.Add("BypassRequired", "BypassRequired");
            tableMapping.ColumnMappings.Add("DegreeOfTrafficControl", "DegreeOfTrafficControl");
            tableMapping.ColumnMappings.Add("NumLats", "NumLats");
            tableMapping.ColumnMappings.Add("NotLinedYet", "NotLinedYet");
            tableMapping.ColumnMappings.Add("ActualLength", "ActualLength");
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
            tableMapping.ColumnMappings.Add("LinerMNType", "LinerMNType");
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
        /// LoadByCompaniesIdIssueWithLateralsNoOutOfScope
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">companiesId</param>
        /// <returns>Data</returns>
        public DataSet LoadByCompaniesIdIssueWithLateralsNoOutOfScope(int companyId, int companiesId)
        {
            FillDataWithStoredProcedure("LFS_CWP_LINNINGPLANGATEWAY_LOADBYCOMPANIESIDISSUEWITHLATERALSNOOUTOFSCOPE", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdOtherIssueWithLaterals
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">companiesId</param>
        /// <returns>Data</returns>
        public DataSet LoadByCompaniesIdOtherIssueWithLaterals(int companyId, int companiesId)
        {
            FillDataWithStoredProcedure("LFS_CWP_LINNINGPLANGATEWAY_LOADBYCOMPANIESIDOTHERISSUEWITHLATERALS", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId));
            return Data;
        }





         
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //
        
        /// <summary>
        /// IsLateralsIssueNo
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Returns true if all laterals have Issue = No</returns>
        public bool IsLateralsIssueNo(Guid id)
        {
            FillDataWithStoredProcedure("LFS_CWP_LINNINGPLANGATEWAY_ISLATERALSISSUENO", new SqlParameter("@id", id));//Note: COMPANY_ID
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
        /// <param name="id">Id</param>
        /// <returns>Returns true if at least one lateral issue is true and the rest no</returns>
        public bool IsLateralsIssueYes(Guid id)
        {
            FillDataWithStoredProcedure("LFS_CWP_LINNINGPLANGATEWAY_ISLATERALSISSUEYES", new SqlParameter("@id", id));//Note: COMPANY_ID
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
        /// <param name="id">Id</param>
        /// <returns>Returns true if at least one lateral issue is Out Of Scope and the rest no</returns>
        public bool IsLateralsIssueOutOfScope(Guid id)
        {
            FillDataWithStoredProcedure("LFS_CWP_LINNINGPLANGATEWAY_ISLATERALSISSUEOUTOFSCOPE", new SqlParameter("@id", id));//Note: COMPANY_ID
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
        /// <param name="id">Id</param>
        /// <returns>Returns true if at least one lateral issue is yes, at least one is Out Of Scope and the rest no</returns>
        public bool IsLateralsIssueYesOutOfScope(Guid id)
        {
            FillDataWithStoredProcedure("LFS_CWP_LINNINGPLANGATEWAY_ISLATERALSISSUEYESOUTOFSCOPE", new SqlParameter("@id", id));//Note: COMPANY_ID
            bool use = false;
            if ((int)Table.Rows.Count > 0)
            {
                use = true;
            }

            return use;
        }


    
    }
}