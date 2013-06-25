using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FlWetOutReportGateway
    /// </summary>
    public class FlWetOutReportGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlWetOutReportGateway()
            : base("LFS_WORK_FULLLENGTHLINING_WETOUT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlWetOutReportGateway(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_WETOUT")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlWetOutReportTDS();
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
            tableMapping.DataSetTable = "LFS_WORK_FULLLENGTHLINING_WETOUT";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("LinerTube", "LinerTube");
            tableMapping.ColumnMappings.Add("ResinID", "ResinID");
            tableMapping.ColumnMappings.Add("ExcessResin", "ExcessResin");
            tableMapping.ColumnMappings.Add("PoundsDrums", "PoundsDrums");
            tableMapping.ColumnMappings.Add("DrumDiameter", "DrumDiameter");
            tableMapping.ColumnMappings.Add("HoistMaximumHeight", "HoistMaximumHeight");
            tableMapping.ColumnMappings.Add("HoistMinimumHeight", "HoistMinimumHeight");
            tableMapping.ColumnMappings.Add("DownDropTubeLenght", "DownDropTubeLenght");
            tableMapping.ColumnMappings.Add("PumpHeightAboveGround", "PumpHeightAboveGround");
            tableMapping.ColumnMappings.Add("TubeResinToFeltFactor", "TubeResinToFeltFactor");
            tableMapping.ColumnMappings.Add("DateOfSheet", "DateOfSheet");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("RunDetails", "RunDetails");
            tableMapping.ColumnMappings.Add("RunDetails2", "RunDetails2");
            tableMapping.ColumnMappings.Add("WetOutDate", "WetOutDate");
            tableMapping.ColumnMappings.Add("InstallDate", "InstallDate");
            tableMapping.ColumnMappings.Add("Thickness", "Thickness");
            tableMapping.ColumnMappings.Add("LengthToLine", "LengthToLine");
            tableMapping.ColumnMappings.Add("PlusExtra", "PlusExtra");
            tableMapping.ColumnMappings.Add("ForTurnOffset", "ForTurnOffset");
            tableMapping.ColumnMappings.Add("LengthToWetOut", "LengthToWetOut");
            tableMapping.ColumnMappings.Add("TubeMaxColdHead", "TubeMaxColdHead");
            tableMapping.ColumnMappings.Add("TubeMaxColdHeadPsi", "TubeMaxColdHeadPsi");
            tableMapping.ColumnMappings.Add("TubeMaxHotHead", "TubeMaxHotHead");
            tableMapping.ColumnMappings.Add("TubeMaxHotHeadPsi", "TubeMaxHotHeadPsi");
            tableMapping.ColumnMappings.Add("TubeIdealHead", "TubeIdealHead");
            tableMapping.ColumnMappings.Add("TubeIdealHeadPsi", "TubeIdealHeadPsi");
            tableMapping.ColumnMappings.Add("NetResinForTube", "NetResinForTube");
            tableMapping.ColumnMappings.Add("NetResinForTubeUsgals", "NetResinForTubeUsgals");
            tableMapping.ColumnMappings.Add("NetResinForTubeDrumsIns", "NetResinForTubeDrumsIns");
            tableMapping.ColumnMappings.Add("NetResinForTubeLbsFt", "NetResinForTubeLbsFt");
            tableMapping.ColumnMappings.Add("NetResinForTubeUsgFt", "NetResinForTubeUsgFt");
            tableMapping.ColumnMappings.Add("ExtraResinForMix", "ExtraResinForMix");
            tableMapping.ColumnMappings.Add("ExtraLbsForMix", "ExtraLbsForMix");
            tableMapping.ColumnMappings.Add("TotalMixQuantity", "TotalMixQuantity");
            tableMapping.ColumnMappings.Add("TotalMixQuantityUsgals", "TotalMixQuantityUsgals");
            tableMapping.ColumnMappings.Add("TotalMixQuantityDrumsIns", "TotalMixQuantityDrumsIns");
            tableMapping.ColumnMappings.Add("InversionType", "InversionType");
            tableMapping.ColumnMappings.Add("DepthOfInversionMH", "DepthOfInversionMH");
            tableMapping.ColumnMappings.Add("TubeForColumn", "TubeForColumn");
            tableMapping.ColumnMappings.Add("TubeForStartDry", "TubeForStartDry");
            tableMapping.ColumnMappings.Add("TotalTube", "TotalTube");
            tableMapping.ColumnMappings.Add("DropTubeConnects", "DropTubeConnects");
            tableMapping.ColumnMappings.Add("AllowsHeadTo", "AllowsHeadTo");
            tableMapping.ColumnMappings.Add("RollerGap", "RollerGap");
            tableMapping.ColumnMappings.Add("HeightNeeded", "HeightNeeded");
            tableMapping.ColumnMappings.Add("Available", "Available");
            tableMapping.ColumnMappings.Add("HoistHeight", "HoistHeight");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("ResinsLabel", "ResinsLabel");
            tableMapping.ColumnMappings.Add("DrumContainsLabel", "DrumContainsLabel");
            tableMapping.ColumnMappings.Add("LinerTubeLabel", "LinerTubeLabel");
            tableMapping.ColumnMappings.Add("ForLbDrumsLabel", "ForLbDrumsLabel");
            tableMapping.ColumnMappings.Add("NetResinLabel", "NetResinLabel");
            tableMapping.ColumnMappings.Add("CatalystLabel", "CatalystLabel");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("MadeBy", "MadeBy");
            tableMapping.ColumnMappings.Add("JobName", "JobName");
            tableMapping.ColumnMappings.Add("JobNumber", "JobNumber");
            tableMapping.ColumnMappings.Add("Street", "Street");            
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
        /// LoadByCompaniesIdSectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="sectionId">sectionId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCompaniesIdSectionId(int companyId, int companiesId, string sectionId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLWETOUTREPORTGATEWAY_LOADBYCOMPANIESIDSECTIONID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@sectionId", sectionId));
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
            FillDataWithStoredProcedure("LFS_CWP_FLWETOUTREPORTGATEWAY_LOADBYCOMPANIESIDPROJECTIDSECTIONID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@sectionId", sectionId));
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
            FillDataWithStoredProcedure("LFS_CWP_FLWETOUTREPORTGATEWAY_LOADBYSECTIONID", new SqlParameter("@companyId", companyId), new SqlParameter("@sectionId", sectionId));
            return Data;
        }
    }
}
