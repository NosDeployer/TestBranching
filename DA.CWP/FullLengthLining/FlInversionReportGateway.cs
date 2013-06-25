using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FlInversionReportGateway
    /// </summary>
    public class FlInversionReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlInversionReportGateway()
            : base("LFS_WORK_FULLLENGTHLINING_INVERSION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlInversionReportGateway(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_INVERSION")
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
            tableMapping.DataSetTable = "LFS_WORK_FULLLENGTHLINING_INVERSION";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("PipeType", "PipeType");
            tableMapping.ColumnMappings.Add("PipeCondition", "PipeCondition");
            tableMapping.ColumnMappings.Add("GroundMoisture", "GroundMoisture");
            tableMapping.ColumnMappings.Add("BoilerSize", "BoilerSize");
            tableMapping.ColumnMappings.Add("PumpTotalCapacity", "PumpTotalCapacity");
            tableMapping.ColumnMappings.Add("LayFlatSize", "LayFlatSize");
            tableMapping.ColumnMappings.Add("LayFlatQuantityTotal", "LayFlatQuantityTotal");
            tableMapping.ColumnMappings.Add("WaterStartTemp", "WaterStartTemp");
            tableMapping.ColumnMappings.Add("Temp1", "Temp1");
            tableMapping.ColumnMappings.Add("HoldAtT1", "HoldAtT1");
            tableMapping.ColumnMappings.Add("TempT2", "TempT2");
            tableMapping.ColumnMappings.Add("CookAtT2", "CookAtT2");
            tableMapping.ColumnMappings.Add("CoolDownFor", "CoolDownFor");
            tableMapping.ColumnMappings.Add("CoolToTemp", "CoolToTemp");
            tableMapping.ColumnMappings.Add("DropInPipeRun", "DropInPipeRun");
            tableMapping.ColumnMappings.Add("PipeSlopOf", "PipeSlopOf");
            tableMapping.ColumnMappings.Add("F45F120", "F45F120");
            tableMapping.ColumnMappings.Add("Hold", "Hold");
            tableMapping.ColumnMappings.Add("F120F185", "F120F185");
            tableMapping.ColumnMappings.Add("CookTime", "CookTime");
            tableMapping.ColumnMappings.Add("CoolTime", "CoolTime");
            tableMapping.ColumnMappings.Add("AproxTotal", "AproxTotal");
            tableMapping.ColumnMappings.Add("WaterChangesPerHour", "WaterChangesPerHour");
            tableMapping.ColumnMappings.Add("ReturnWaterVelocity", "ReturnWaterVelocity");
            tableMapping.ColumnMappings.Add("LayflatBackPressure", "LayflatBackPressure");
            tableMapping.ColumnMappings.Add("PumpLiftAtIdealHead", "PumpLiftAtIdealHead");
            tableMapping.ColumnMappings.Add("WaterToFillLinerColumn", "WaterToFillLinerColumn");
            tableMapping.ColumnMappings.Add("WaterPerFit", "WaterPerFit");
            tableMapping.ColumnMappings.Add("InstallationResults", "InstallationResults");
            tableMapping.ColumnMappings.Add("LinerTubeLabel", "LinerTubeLabel");
            tableMapping.ColumnMappings.Add("HeadsIdealLabel", "HeadsIdealLabel");
            tableMapping.ColumnMappings.Add("PumpingAndCirculationLabel", "PumpingAndCirculationLabel");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");

            tableMapping.ColumnMappings.Add("TubeSize", "TubeSize");
            tableMapping.ColumnMappings.Add("JobName", "JobName");
            tableMapping.ColumnMappings.Add("JobNumber", "JobNumber");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("LengthToWetOut", "LengthToWetOut");
            tableMapping.ColumnMappings.Add("WetOutDate", "WetOutDate");
            tableMapping.ColumnMappings.Add("InstallDate", "InstallDate");
            tableMapping.ColumnMappings.Add("InstalledBy", "InstalledBy");
            tableMapping.ColumnMappings.Add("Thickness", "Thickness");
            tableMapping.ColumnMappings.Add("TubeMaxColdHead", "TubeMaxColdHead");
            tableMapping.ColumnMappings.Add("TubeMaxHotHead", "TubeMaxHotHead");
            tableMapping.ColumnMappings.Add("TubeIdealHead", "TubeIdealHead");
            tableMapping.ColumnMappings.Add("PumpHeightAboveGround", "PumpHeightAboveGround");
            tableMapping.ColumnMappings.Add("DepthOfInversionMH", "DepthOfInversionMH");
            tableMapping.ColumnMappings.Add("RunDetails", "RunDetails");
            tableMapping.ColumnMappings.Add("RunDetails2", "RunDetails2");
            tableMapping.ColumnMappings.Add("LinerTube", "LinerTube");                
                
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
            FillDataWithStoredProcedure("LFS_CWP_FLINVERSIONREPORTGATEWAY_LOADBYCOMPANIESIDSECTIONID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@sectionId", sectionId));
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
            FillDataWithStoredProcedure("LFS_CWP_FLINVERSIONREPORTGATEWAY_LOADBYCOMPANIESIDPROJECTIDSECTIONID", new SqlParameter("@companyId", companyId), new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@sectionId", sectionId));
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
            FillDataWithStoredProcedure("LFS_CWP_FLINVERSIONREPORTGATEWAY_LOADBYSECTIONID", new SqlParameter("@companyId", companyId), new SqlParameter("@sectionId", sectionId));
            return Data;
        }

    }
}