using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsReportGeneralGateway
    /// </summary>
    public class ActualCostsReportGeneralGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ActualCostsReportGeneralGateway()
            : base("PrintActualCostsGeneral")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ActualCostsReportGeneralGateway(DataSet data)
            : base(data, "PrintActualCostsGeneral")
        {
        }



        /// <summary>
        /// InitData. Create a PrintManhoursPerPhaseTDS dataset
        /// </summary>
        protected override void InitData()
        {
            _data = new ActualCostsReportTDS();
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
            tableMapping.DataSetTable = "PrintActualCostsGeneral";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjetID");
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
        /// Load
        /// </summary>   
        public DataSet Load()
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTLISTGATEWAY_LOAD");
            return Data;
        }



        /// <summary>
        /// LoadForSubcontractors
        /// </summary>        
        /// <param name="companyId">companyId</param>
        public DataSet LoadForSubcontractors(int companyId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_ACTUALCOSTSREPORTGENERALGATEWAY_LOADFORSUBCONTRACTORS", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Load
        /// </summary>
        /// <para>Load Original with filters  </para>
        /// <param name="companyId">companyId</param>
        /// <param name="countryId">countryId</param>
        public DataSet LoadByCountryId(int companyId, int countryId, DateTime startDate, DateTime endDate)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTMANHOURSPERPHASEGENERALGATEWAY_LOADBYCOUNTRYID", new SqlParameter("@companyId", companyId), new SqlParameter("@countryId", countryId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate));
            return Data;
        }



        /// <summary>
        /// Load
        /// </summary>
        /// <para>Load Original with filters  </para>
        /// <param name="companyId">companyId</param>
        /// <param name="clientId">clientId</param>
        public DataSet LoadByClientId(int companyId, int clientId, DateTime startDate, DateTime endDate)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTMANHOURSPERPHASEGENERALGATEWAY_LOADBYCLIENTID", new SqlParameter("@companyId", companyId), new SqlParameter("@clientId", clientId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate));
            return Data;
        }



        /// <summary>
        /// Load
        /// </summary>
        /// <para>Load Original with filters  </para>
        /// <param name="companyId">companyId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        public DataSet LoadByProjectId(int companyId, int projectId, DateTime startDate, DateTime endDate)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTMANHOURSPERPHASEGENERALGATEWAY_LOADBYPROJECTID", new SqlParameter("@companyId", companyId), new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate));
            return Data;
        }



    }
}