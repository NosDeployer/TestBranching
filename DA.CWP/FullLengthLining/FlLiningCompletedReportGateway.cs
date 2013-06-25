using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FlLiningCompletedReportGateway
    /// </summary>
    public class FlLiningCompletedReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlLiningCompletedReportGateway()
            : base("LiningCompleted")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlLiningCompletedReportGateway(DataSet data)
            : base(data, "LiningCompleted")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlLiningCompletedReportTDS();
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
            tableMapping.DataSetTable = "LiningCompleted";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("InstallDate", "InstallDate");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("NAME", "NAME");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("USMHDescription", "USMHDescription");
            tableMapping.ColumnMappings.Add("DSMHDescription", "DSMHDescription");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("CountryName", "CountryName");
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
        /// LoadByCompaniesIdProjectIdStartDateEndDate
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesIdProjectIdStartDateEndDate(int companiesId, int projectId, DateTime startDate, DateTime endDate, int companyId)
        {
            string command = "SELECT     AASS.AssetID, AASS.COMPANY_ID, LW.ProjectID, AASS.SectionID, C.COMPANIES_ID, AASS.Street, AASS.USMH, AASS.DSMH, AASS.Size_, "+
                " LWFLL.InstallDate, AASS.Length, C.NAME, '" + startDate.ToShortDateString() + "' AS StartDate, "+
                " '" + endDate.ToShortDateString() + "' AS EndDate, AMSUSMH.MHID AS USMHDescription, AMSDSMH.MHID AS DSMHDescription, "+
                " LP.Name AS ProjectName, AASS.FlowOrderID, LC.Name AS CountryName "+
                " FROM         AM_ASSET_SEWER_SECTION AASS INNER JOIN "+
                " LFS_WORK LW ON AASS.AssetID = LW.AssetID INNER JOIN "+
                " LFS_PROJECT LP ON LW.ProjectID = LP.ProjectID INNER JOIN "+
                " LFS_WORK_FULLLENGTHLINING LWFLL ON LW.WorkID = LWFLL.WorkID INNER JOIN "+
                " LFS_RESOURCES_COMPANIES C ON C.COMPANIES_ID = LP.ClientID INNER JOIN " +
                " LFS_COUNTRY LC ON LP.CountryID = LC.CountryID AND LP.CountryID = LC.CountryID LEFT OUTER JOIN "+
                " AM_ASSET_SEWER_MH AMSUSMH ON AASS.USMH = AMSUSMH.AssetID LEFT OUTER JOIN "+
                " AM_ASSET_SEWER_MH AMSDSMH ON AASS.DSMH = AMSDSMH.AssetID " +
                " WHERE (AASS.COMPANY_ID = '" + companyId + "') AND (LW.ProjectID = '" + projectId + "') "+
                " AND (C.COMPANIES_ID = '" + companiesId + "') AND (AASS.Length IS NOT NULL) AND "+
                " (LWFLL.InstallDate BETWEEN CONVERT(DATETIME, '" + startDate.Month + "/" + startDate.Day + "/" + startDate.Year + " 00:00:00') AND "+
                " CONVERT (DATETIME, '" + endDate.Month + "/" + endDate.Day + "/" + endDate.Year + " 23:59:59')) AND "+
                " (AASS.Deleted = 0) "+
                " ORDER BY AASS.Size_, LWFLL.InstallDate";
            FillData(command);
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdStartDateEndDateCountryId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesIdProjectIdStartDateEndDateCountryId(int companiesId, int projectId, DateTime startDate, DateTime endDate, int countryId, int companyId)
        {
            string command = "SELECT     AASS.AssetID, AASS.COMPANY_ID, LW.ProjectID, AASS.SectionID, C.COMPANIES_ID, AASS.Street, AASS.USMH, AASS.DSMH, AASS.Size_, " +
                " LWFLL.InstallDate, AASS.Length, C.NAME, '" + startDate.ToShortDateString() + "' AS StartDate, " +
                " '" + endDate.ToShortDateString() + "' AS EndDate, AMSUSMH.MHID AS USMHDescription, AMSDSMH.MHID AS DSMHDescription, " +
                " LP.Name AS ProjectName, AASS.FlowOrderID, LC.Name AS CountryName " +
                " FROM         AM_ASSET_SEWER_SECTION AASS INNER JOIN " +
                " LFS_WORK LW ON AASS.AssetID = LW.AssetID INNER JOIN " +
                " LFS_PROJECT LP ON LW.ProjectID = LP.ProjectID INNER JOIN " +
                " LFS_WORK_FULLLENGTHLINING LWFLL ON LW.WorkID = LWFLL.WorkID INNER JOIN " +
                " LFS_RESOURCES_COMPANIES C ON C.COMPANIES_ID = LP.ClientID INNER JOIN " +
                " LFS_COUNTRY LC ON LP.CountryID = LC.CountryID AND LP.CountryID = LC.CountryID LEFT OUTER JOIN " +
                " AM_ASSET_SEWER_MH AMSUSMH ON AASS.USMH = AMSUSMH.AssetID LEFT OUTER JOIN " +
                " AM_ASSET_SEWER_MH AMSDSMH ON AASS.DSMH = AMSDSMH.AssetID " +
                " WHERE (AASS.COMPANY_ID = '" + companyId + "') AND (LC.CountryID =" + countryId +") AND (LW.ProjectID = '" + projectId + "') " +
                " AND (C.COMPANIES_ID = '" + companiesId + "') AND (AASS.Length IS NOT NULL) AND " +
                " (LWFLL.InstallDate BETWEEN CONVERT(DATETIME, '" + startDate.Month + "/" + startDate.Day + "/" + startDate.Year + " 00:00:00') AND " +
                " CONVERT (DATETIME, '" + endDate.Month + "/" + endDate.Day + "/" + endDate.Year + " 23:59:59')) AND " +
                " (AASS.Deleted = 0) " +
                " ORDER BY AASS.Size_, LWFLL.InstallDate";
            FillData(command);
            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdStartDateEndDate
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesIdStartDateEndDate(int companiesId, DateTime startDate, DateTime endDate, int companyId)
        {
            string command = "SELECT     AASS.AssetID, AASS.COMPANY_ID, LW.ProjectID, AASS.SectionID, C.COMPANIES_ID, AASS.Street, AASS.USMH, AASS.DSMH, AASS.Size_, " +
                " LWFLL.InstallDate, AASS.Length, C.NAME, '" + startDate.ToShortDateString() + "' AS StartDate, " +
                " '" + endDate.ToShortDateString() + "' AS EndDate, AMSUSMH.MHID AS USMHDescription, AMSDSMH.MHID AS DSMHDescription, " +
                " LP.Name AS ProjectName, AASS.FlowOrderID, LC.Name AS CountryName " +
                " FROM         AM_ASSET_SEWER_SECTION AASS INNER JOIN " +
                " LFS_WORK LW ON AASS.AssetID = LW.AssetID INNER JOIN " +
                " LFS_PROJECT LP ON LW.ProjectID = LP.ProjectID INNER JOIN " +
                " LFS_WORK_FULLLENGTHLINING LWFLL ON LW.WorkID = LWFLL.WorkID INNER JOIN " +
                " LFS_RESOURCES_COMPANIES C ON C.COMPANIES_ID = LP.ClientID INNER JOIN " +
                " LFS_COUNTRY LC ON LP.CountryID = LC.CountryID AND LP.CountryID = LC.CountryID LEFT OUTER JOIN " +
                " AM_ASSET_SEWER_MH AMSUSMH ON AASS.USMH = AMSUSMH.AssetID LEFT OUTER JOIN " +
                " AM_ASSET_SEWER_MH AMSDSMH ON AASS.DSMH = AMSDSMH.AssetID " +
            " WHERE (AASS.COMPANY_ID = '" + companyId + "') AND (C.COMPANIES_ID = '" + companiesId + "') AND (AASS.Length IS NOT NULL) AND (LWFLL.InstallDate BETWEEN CONVERT(DATETIME, '" + startDate.Month + "/" + startDate.Day + "/" + startDate.Year + " 00:00:00') AND CONVERT (DATETIME, '" + endDate.Month + "/" + endDate.Day + "/" + endDate.Year + " 23:59:59')) AND (AASS.Deleted = 0) ORDER BY AASS.Size_, LWFLL.InstallDate";
            FillData(command);

            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdStartDateEndDateCountryId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>        
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesIdStartDateEndDateCountryId(int companiesId, DateTime startDate, DateTime endDate, int countryId, int companyId)
        {
            string command = "SELECT     AASS.AssetID, AASS.COMPANY_ID, LW.ProjectID, AASS.SectionID, C.COMPANIES_ID, AASS.Street, AASS.USMH, AASS.DSMH, AASS.Size_, " +
                " LWFLL.InstallDate, AASS.Length, C.NAME, '" + startDate.ToShortDateString() + "' AS StartDate, " +
                " '" + endDate.ToShortDateString() + "' AS EndDate, AMSUSMH.MHID AS USMHDescription, AMSDSMH.MHID AS DSMHDescription, " +
                " LP.Name AS ProjectName, AASS.FlowOrderID, LC.Name AS CountryName " +
                " FROM         AM_ASSET_SEWER_SECTION AASS INNER JOIN " +
                " LFS_WORK LW ON AASS.AssetID = LW.AssetID INNER JOIN " +
                " LFS_PROJECT LP ON LW.ProjectID = LP.ProjectID INNER JOIN " +
                " LFS_WORK_FULLLENGTHLINING LWFLL ON LW.WorkID = LWFLL.WorkID INNER JOIN " +
                " LFS_RESOURCES_COMPANIES C ON C.COMPANIES_ID = LP.ClientID INNER JOIN " +
                " LFS_COUNTRY LC ON LP.CountryID = LC.CountryID AND LP.CountryID = LC.CountryID LEFT OUTER JOIN " +
                " AM_ASSET_SEWER_MH AMSUSMH ON AASS.USMH = AMSUSMH.AssetID LEFT OUTER JOIN " +
                " AM_ASSET_SEWER_MH AMSDSMH ON AASS.DSMH = AMSDSMH.AssetID " +
            " WHERE (AASS.COMPANY_ID = '" + companyId + "') AND (LC.CountryID =" + countryId + ") AND (C.COMPANIES_ID = '" + companiesId + "') AND (AASS.Length IS NOT NULL) AND (LWFLL.InstallDate BETWEEN CONVERT(DATETIME, '" + startDate.Month + "/" + startDate.Day + "/" + startDate.Year + " 00:00:00') AND CONVERT (DATETIME, '" + endDate.Month + "/" + endDate.Day + "/" + endDate.Year + " 23:59:59')) AND (AASS.Deleted = 0) ORDER BY AASS.Size_, LWFLL.InstallDate";
            FillData(command);

            return Data;
        }


        
        /// <summary>
        /// LoadByStartDateEndDate
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByStartDateEndDate(DateTime startDate, DateTime endDate, int companyId)
        {
            string command = "SELECT     AASS.AssetID, AASS.COMPANY_ID, LW.ProjectID, AASS.SectionID, C.COMPANIES_ID, AASS.Street, AASS.USMH, AASS.DSMH, AASS.Size_, " +
                " LWFLL.InstallDate, AASS.Length, C.NAME, '" + startDate.ToShortDateString() + "' AS StartDate, " +
                " '" + endDate.ToShortDateString() + "' AS EndDate, AMSUSMH.MHID AS USMHDescription, AMSDSMH.MHID AS DSMHDescription, " +
                " LP.Name AS ProjectName, AASS.FlowOrderID, LC.Name AS CountryName " +
                " FROM         AM_ASSET_SEWER_SECTION AASS INNER JOIN " +
                " LFS_WORK LW ON AASS.AssetID = LW.AssetID INNER JOIN " +
                " LFS_PROJECT LP ON LW.ProjectID = LP.ProjectID INNER JOIN " +
                " LFS_WORK_FULLLENGTHLINING LWFLL ON LW.WorkID = LWFLL.WorkID INNER JOIN " +
                " LFS_RESOURCES_COMPANIES C ON C.COMPANIES_ID = LP.ClientID INNER JOIN " +
                " LFS_COUNTRY LC ON LP.CountryID = LC.CountryID AND LP.CountryID = LC.CountryID LEFT OUTER JOIN " +
                " AM_ASSET_SEWER_MH AMSUSMH ON AASS.USMH = AMSUSMH.AssetID LEFT OUTER JOIN " +
                " AM_ASSET_SEWER_MH AMSDSMH ON AASS.DSMH = AMSDSMH.AssetID " +
            " WHERE (AASS.COMPANY_ID = '" + companyId + "') AND (AASS.Length IS NOT NULL) AND (LWFLL.InstallDate BETWEEN CONVERT(DATETIME, '" + startDate.Month + "/" + startDate.Day + "/" + startDate.Year + " 00:00:00') AND CONVERT (DATETIME, '" + endDate.Month + "/" + endDate.Day + "/" + endDate.Year + " 23:59:59')) AND (AASS.Deleted = 0) ORDER BY AASS.Size_, LWFLL.InstallDate";
            FillData(command);

            return Data;
        }



        /// <summary>
        /// LoadByStartDateEndDateCountryId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByStartDateEndDateCountryId(DateTime startDate, DateTime endDate, int countryId, int companyId)
        {
            string command = "SELECT     AASS.AssetID, AASS.COMPANY_ID, LW.ProjectID, AASS.SectionID, C.COMPANIES_ID, AASS.Street, AASS.USMH, AASS.DSMH, AASS.Size_, " +
                " LWFLL.InstallDate, AASS.Length, C.NAME, '" + startDate.ToShortDateString() + "' AS StartDate, " +
                " '" + endDate.ToShortDateString() + "' AS EndDate, AMSUSMH.MHID AS USMHDescription, AMSDSMH.MHID AS DSMHDescription, " +
                " LP.Name AS ProjectName, AASS.FlowOrderID, LC.Name AS CountryName " +
                " FROM         AM_ASSET_SEWER_SECTION AASS INNER JOIN " +
                " LFS_WORK LW ON AASS.AssetID = LW.AssetID INNER JOIN " +
                " LFS_PROJECT LP ON LW.ProjectID = LP.ProjectID INNER JOIN " +
                " LFS_WORK_FULLLENGTHLINING LWFLL ON LW.WorkID = LWFLL.WorkID INNER JOIN " +
                " LFS_RESOURCES_COMPANIES C ON C.COMPANIES_ID = LP.ClientID INNER JOIN " +
                " LFS_COUNTRY LC ON LP.CountryID = LC.CountryID AND LP.CountryID = LC.CountryID LEFT OUTER JOIN " +
                " AM_ASSET_SEWER_MH AMSUSMH ON AASS.USMH = AMSUSMH.AssetID LEFT OUTER JOIN " +
                " AM_ASSET_SEWER_MH AMSDSMH ON AASS.DSMH = AMSDSMH.AssetID " +
            " WHERE (AASS.COMPANY_ID = '" + companyId + "') AND (LC.CountryID =" + countryId + ") AND (AASS.Length IS NOT NULL) AND (LWFLL.InstallDate BETWEEN CONVERT(DATETIME, '" + startDate.Month + "/" + startDate.Day + "/" + startDate.Year + " 00:00:00') AND CONVERT (DATETIME, '" + endDate.Month + "/" + endDate.Day + "/" + endDate.Year + " 23:59:59')) AND (AASS.Deleted = 0) ORDER BY AASS.Size_, LWFLL.InstallDate";
            FillData(command);

            return Data;
        }



    }
}