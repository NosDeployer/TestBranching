using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FlM1ReportGateway
    /// </summary>
    public class FlM1ReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlM1ReportGateway()
            : base("M1ReportByClient")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlM1ReportGateway(DataSet data)
            : base(data, "M1ReportByClient")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlM1ReportTDS();
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
            tableMapping.DataSetTable = "M1ReportByClient";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("NAME", "NAME");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("M1Date", "M1Date");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("USMHAddress", "USMHAddress");
            tableMapping.ColumnMappings.Add("DSMHAddress", "DSMHAddress");
            tableMapping.ColumnMappings.Add("USMHDepth", "USMHDepth");
            tableMapping.ColumnMappings.Add("DSMHDepth", "DSMHDepth");
            tableMapping.ColumnMappings.Add("MeasurementTakenBy", "MeasurementTakenBy");
            tableMapping.ColumnMappings.Add("USMHMouth12", "USMHMouth12");
            tableMapping.ColumnMappings.Add("USMHMouth1", "USMHMouth1");
            tableMapping.ColumnMappings.Add("USMHMouth2", "USMHMouth2");
            tableMapping.ColumnMappings.Add("USMHMouth3", "USMHMouth3");
            tableMapping.ColumnMappings.Add("USMHMouth4", "USMHMouth4");
            tableMapping.ColumnMappings.Add("USMHMouth5", "USMHMouth5");
            tableMapping.ColumnMappings.Add("DSMHMouth12", "DSMHMouth12");
            tableMapping.ColumnMappings.Add("DSMHMouth1", "DSMHMouth1");
            tableMapping.ColumnMappings.Add("DSMHMouth2", "DSMHMouth2");
            tableMapping.ColumnMappings.Add("DSMHMouth3", "DSMHMouth3");
            tableMapping.ColumnMappings.Add("DSMHMouth4", "DSMHMouth4");
            tableMapping.ColumnMappings.Add("DSMHMouth5", "DSMHMouth5");           
            tableMapping.ColumnMappings.Add("TrafficControl", "TrafficControl");
            tableMapping.ColumnMappings.Add("StandardBypass", "StandardBypass");
            tableMapping.ColumnMappings.Add("PipeMaterialType", "PipeMaterialType");
            tableMapping.ColumnMappings.Add("PipeSizeChange", "PipeSizeChange");
            tableMapping.ColumnMappings.Add("M1Comments", "M1Comments");
            tableMapping.ColumnMappings.Add("TrafficControlDetails", "TrafficControlDetails");
            tableMapping.ColumnMappings.Add("USMHDescription", "USMHDescription");
            tableMapping.ColumnMappings.Add("DSMHDescription", "DSMHDescription");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("MeasurementType", "MeasurementType");
            tableMapping.ColumnMappings.Add("MeasurementFromMH", "MeasurementFromMH");
            tableMapping.ColumnMappings.Add("VideoDoneFromMH", "VideoDoneFromMH");
            tableMapping.ColumnMappings.Add("VideoDoneToMH", "VideoDoneToMH");
            tableMapping.ColumnMappings.Add("SiteDetails", "SiteDetails");
            tableMapping.ColumnMappings.Add("StandardBypassComments", "StandardBypassComments");
            tableMapping.ColumnMappings.Add("LiveLaterals", "LiveLaterals");
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
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="projectId">projectId</param>
        public DataSet LoadByCompaniesIdProjectId(int companyId, int companiesId, int projectId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM1REPORTGATEWAY_LOADBYCOMPANIESIDPROJECTID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId));
            return Data;           
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdSectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="projectId">projectId</param>
        /// <param name="sectionId">sectionId</param>
        public DataSet LoadByCompaniesIdProjectIdSectionId(int companyId, int companiesId, int projectId, string sectionId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM1REPORTGATEWAY_LOADBYCOMPANIESIDPROJECTIDSECTIONID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@sectionId", sectionId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdDate
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="projectId">projectId</param>
        /// <param name="date">date</param>
        public DataSet LoadByCompaniesIdProjectIdDate(int companyId, int companiesId, int projectId, string date)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM1REPORTGATEWAY_LOADBYCOMPANIESIDPROJECTIDDATE", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@date", date));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdStreet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="projectId">projectId</param>
        /// <param name="street">street</param>
        public DataSet LoadByCompaniesIdProjectIdStreet(int companyId, int companiesId, int projectId, string street)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM1REPORTGATEWAY_LOADBYCOMPANIESIDPROJECTIDSTREET", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@street", street));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdSubArea
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="projectId">projectId</param>
        /// <param name="subArea">subArea</param>
        public DataSet LoadByCompaniesIdProjectIdSubArea(int companyId, int companiesId, int projectId, string subArea)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM1REPORTGATEWAY_LOADBYCOMPANIESIDPROJECTIDSUBAREA", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@subArea", subArea));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <returns></returns>
        public DataSet LoadByCompaniesId(int companyId, int companiesId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM1REPORTGATEWAY_LOADBYCOMPANIESID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdSectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>   
        /// <param name="sectionId">sectionId</param>
        /// <returns></returns>
        public DataSet LoadByCompaniesIdSectionId(int companyId, int companiesId, string sectionId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM1REPORTGATEWAY_LOADBYCOMPANIESIDSECTIONID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@sectionId", sectionId));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdDate
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param> 
        /// <param name="date">date</param>
        /// <returns></returns>
        public DataSet LoadByCompaniesIdDate(int companyId, int companiesId, string date)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM1REPORTGATEWAY_LOADBYCOMPANIESIDDATE", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@date", date));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdStreet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="street">street</param>
        /// <returns></returns>
        public DataSet LoadByCompaniesIdStreet(int companyId, int companiesId, string street)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM1REPORTGATEWAY_LOADBYCOMPANIESIDSTREET", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@street", street));
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdSubArea
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="subArea">subArea</param>
        /// <returns></returns>
        public DataSet LoadByCompaniesIdSubArea(int companyId, int companiesId, string subArea)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM1REPORTGATEWAY_LOADBYCOMPANIESIDSUBAREA", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@subArea", subArea));
            return Data;
        }



        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM1REPORTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByDate
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="date">date</param>
        /// <returns></returns>
        public DataSet LoadByDate(int companyId, string date)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM1REPORTGATEWAY_LOADBYDATE", new SqlParameter("@companyId", companyId), new SqlParameter("@date", date));
            return Data;
        }



        /// <summary>
        /// LoadByStreet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="street">street</param>
        /// <returns></returns>
        public DataSet LoadByStreet(int companyId, string street)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM1REPORTGATEWAY_LOADBYSTREET", new SqlParameter("@companyId", companyId), new SqlParameter("@street", street));
            return Data;
        }



        /// <summary>
        /// LoadBySubArea
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="subArea">subArea</param>
        /// <returns></returns>
        public DataSet LoadBySubArea(int companyId, string subArea)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM1REPORTGATEWAY_LOADBYSUBAREA", new SqlParameter("@companyId", companyId), new SqlParameter("@subArea", subArea));
            return Data;
        }



        /// <summary>
        /// LoadBySectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="sectionId">sectionId</param>
        /// <returns></returns>
        public DataSet LoadBySectionId(int companyId, string sectionId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM1REPORTGATEWAY_LOADBYSECTIONID", new SqlParameter("@companyId", companyId), new SqlParameter("@sectionId", sectionId));//Note: COMPANY_ID
            return Data;
        }



    }
}