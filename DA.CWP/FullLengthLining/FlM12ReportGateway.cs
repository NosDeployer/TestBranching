using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FlM2ReportGateway
    /// </summary>
    public class FlM12ReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlM12ReportGateway()
            : base("M2_SECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlM12ReportGateway(DataSet data)
            : base(data, "M2_SECTION")
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
            tableMapping.DataSetTable = "M2_SECTION";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("NAME", "NAME");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("M2Date", "M2Date");
            tableMapping.ColumnMappings.Add("VideoLength", "VideoLength");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("HydrantAddress", "HydrantAddress");
            tableMapping.ColumnMappings.Add("DistanceToInversionMH", "DistanceToInversionMH");
            tableMapping.ColumnMappings.Add("RampRequired", "RampRequired");
            tableMapping.ColumnMappings.Add("LineWithID", "LineWithID");
            tableMapping.ColumnMappings.Add("HydroPulley", "HydroPulley");
            tableMapping.ColumnMappings.Add("FridgeCart", "FridgeCart");
            tableMapping.ColumnMappings.Add("TwoPump", "TwoPump");
            tableMapping.ColumnMappings.Add("SixBypass", "SixBypass");
            tableMapping.ColumnMappings.Add("Scaffolding", "Scaffolding");
            tableMapping.ColumnMappings.Add("WinchExtention", "WinchExtention");
            tableMapping.ColumnMappings.Add("ExtraGenerator", "ExtraGenerator");
            tableMapping.ColumnMappings.Add("GreyCableExtension", "GreyCableExtension");
            tableMapping.ColumnMappings.Add("EasementMats", "EasementMats");
            tableMapping.ColumnMappings.Add("DropPipe", "DropPipe");
            tableMapping.ColumnMappings.Add("DropPipeInvertDepth", "DropPipeInvertDepth");
            tableMapping.ColumnMappings.Add("MeasurementTakenBy", "MeasurementTakenBy");
            tableMapping.ColumnMappings.Add("CappedLaterals", "CappedLaterals");
            tableMapping.ColumnMappings.Add("HydroWireWithin10FtOfInversionMH", "HydroWireWithin10FtOfInversionMH");
            tableMapping.ColumnMappings.Add("SurfaceGrade", "SurfaceGrade");
            tableMapping.ColumnMappings.Add("CameraSkid", "CameraSkid");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
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
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesIdProjectId(int companyId, int companiesId, int projectId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM12REPORTGATEWAY_LOADBYCOMPANIESIDPROJECTID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesId(int companyId, int companiesId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM12REPORTGATEWAY_LOADBYCOMPANIESID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM12REPORTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadByDate
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="date">date</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByDate(int companyId, string date)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM12REPORTGATEWAY_LOADBYDATE", new SqlParameter("@companyId", companyId), new SqlParameter("@date", date));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadByStreet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="street">street</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByStreet(int companyId, string street)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM12REPORTGATEWAY_LOADBYSTREET", new SqlParameter("@companyId", companyId), new SqlParameter("@street", street));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadBySubArea
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="subArea">subArea</param>
        /// <returns>DataSet</returns>
        public DataSet LoadBySubArea(int companyId, string subArea)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM12REPORTGATEWAY_LOADBYSUBAREA", new SqlParameter("@companyId", companyId), new SqlParameter("@subArea", subArea));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadBySectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="sectionId">sectionId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadBySectionId(int companyId, string sectionId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM12REPORTGATEWAY_LOADBYSECTIONID", new SqlParameter("@companyId", companyId), new SqlParameter("@sectionId", sectionId));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdSectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="sectionId">sectionId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesIdSectionId(int companyId, int companiesId, string sectionId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM12REPORTGATEWAY_LOADBYCOMPANIESIDSECTIONID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@sectionId", sectionId));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdDate
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>   
        /// <param name="date">date</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesIdDate(int companyId, int companiesId, string date)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM12REPORTGATEWAY_LOADBYCOMPANIESIDDATE", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@date", date));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdStreet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="street">street</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesIdStreet(int companyId, int companiesId, string street)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM12REPORTGATEWAY_LOADBYCOMPANIESIDSTREET", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@street", street));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdSubArea
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="subArea">subArea</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesIdSubArea(int companyId, int companiesId, string subArea)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM12REPORTGATEWAY_LOADBYCOMPANIESIDSUBAREA", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@subArea", subArea));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdSectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="projectId">projectId</param>
        /// <param name="sectionId">sectionId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesIdProjectIdSectionId(int companyId, int companiesId, int projectId, string sectionId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM12REPORTGATEWAY_LOADBYCOMPANIESIDPROJECTIDSECTIONID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@sectionId", sectionId));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdDate
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="projectId">projectId</param>
        /// <param name="date">date</param>
        /// <remreturns>DataSet</remreturns>
        public DataSet LoadByCompaniesIdProjectIdDate(int companyId, int companiesId, int projectId, string date)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM12REPORTGATEWAY_LOADBYCOMPANIESIDPROJECTIDDATE", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@date", date));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdStreet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="projectId">projectId</param>
        /// <param name="street">street</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesIdProjectIdStreet(int companyId, int companiesId, int projectId, string street)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM12REPORTGATEWAY_LOADBYCOMPANIESIDPROJECTIDSTREET", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@street", street));//Note: COMPANY_ID
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdSubArea
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="projectId">projectId</param>
        /// <param name="subArea">subArea</param>
        /// <rereturns>DataSet</rereturns>
        public DataSet LoadByCompaniesIdProjectIdSubArea(int companyId, int companiesId, int projectId, string subArea)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM12REPORTGATEWAY_LOADBYCOMPANIESIDPROJECTIDSUBAREA", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@subArea", subArea));//Note: COMPANY_ID
            return Data;
        }



    }
}