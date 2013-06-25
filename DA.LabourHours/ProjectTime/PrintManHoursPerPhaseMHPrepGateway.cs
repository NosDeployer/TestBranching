using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintManHoursPerPhaseMHPrepGateway
    /// </summary>
    public class PrintManHoursPerPhaseMHPrepGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintManHoursPerPhaseMHPrepGateway()
            : base("PrintManHoursPerPhaseMHPrep")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintManHoursPerPhaseMHPrepGateway(DataSet data)
            : base(data, "PrintManHoursPerPhaseMHPrep")
        {
        }



        /// <summary>
        /// InitData. Create a PrintManhoursPerPhaseTDS dataset
        /// </summary>
        protected override void InitData()
        {
            _data = new PrintManhoursPerPhaseTDS();
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
            tableMapping.DataSetTable = "PrintManHoursPerPhaseMHPrep";
            tableMapping.ColumnMappings.Add("ClientName", "ClientName");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("Phase", "Phase");
            tableMapping.ColumnMappings.Add("Hrs", "Hrs");
            tableMapping.ColumnMappings.Add("MHID", "MHID");
            tableMapping.ColumnMappings.Add("Crew", "Crew");
            tableMapping.ColumnMappings.Add("Shape", "Shape");
            tableMapping.ColumnMappings.Add("Material", "Material");
            tableMapping.ColumnMappings.Add("Location", "Location");
            tableMapping.ColumnMappings.Add("Rating", "Rating");
            tableMapping.ColumnMappings.Add("TotalFt", "TotalFt");
            tableMapping.ColumnMappings.Add("RealFt", "RealFt");
            tableMapping.ColumnMappings.Add("Budget", "Budget");
            tableMapping.ColumnMappings.Add("LiveLaterals", "LiveLaterals");
            tableMapping.ColumnMappings.Add("RealLiveLaterals", "RealLiveLaterals");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("TotalFtDouble", "TotalFtDouble");
            tableMapping.ColumnMappings.Add("TotalHrs", "TotalHrs");
            tableMapping.ColumnMappings.Add("NumPeriods", "NumPeriods");
            tableMapping.ColumnMappings.Add("AverageRate", "AverageRate");
            tableMapping.ColumnMappings.Add("SumFtLateralsByPeriod", "SumFtLateralsByPeriod");
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
        /// LoadByStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original with filters  </para>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        public DataSet LoadByStartDateEndDateProjectTimeStateWorkFunction(int? countryId, DateTime startDate, DateTime endDate, string projectTimeState, string work_, string function_, string shape, int conditionRating, string location, string material, string crew)
        {
            if (countryId.HasValue)
            {
                FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTMANHOURSPERPHASEMHGATEWAY_LOADBYSTARTDATEENDDATEPROJECTTIMESTATEWORKFUNCTIONCOUNTRYID", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@work_", work_), new SqlParameter("@function_", function_), new SqlParameter("@shape", shape), new SqlParameter("@conditionRating", conditionRating), new SqlParameter("@location", location), new SqlParameter("@material", material), new SqlParameter("@crew", crew), new SqlParameter("@countryId", countryId));
            }
            else
            {
                FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTMANHOURSPERPHASEMHGATEWAY_LOADBYSTARTDATEENDDATEPROJECTTIMESTATEWORKFUNCTION", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@work_", work_), new SqlParameter("@function_", function_), new SqlParameter("@shape", shape), new SqlParameter("@conditionRating", conditionRating), new SqlParameter("@location", location), new SqlParameter("@material", material), new SqlParameter("@crew", crew));
            }

            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original with filters  </para>
        /// <param name="companiesId">Company filter (client) for project Costing report</param>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        public DataSet LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, string work_, string function_, string shape, int conditionRating, string location, string material, string crew)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTMANHOURSPERPHASEMHGATEWAY_LOADBYCOMPANIESIDSTARTDATEENDDATEPROJECTTIMESTATEWORKFUNCTION", new SqlParameter("@companiesId", companiesId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@work_", work_), new SqlParameter("@function_", function_), new SqlParameter("@shape", shape), new SqlParameter("@conditionRating", conditionRating), new SqlParameter("@location", location), new SqlParameter("@material", material), new SqlParameter("@crew", crew));

            return Data;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original with filters  </para> 
        /// <param name="companiesId">Company filter (client) for Project Costing report</param>
        /// <param name="projectId">Project filter for Project Costing report</param>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for  Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        public DataSet LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, string work_, string function_, string shape, int conditionRating, string location, string material, string crew)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTMANHOURSPERPHASEMHGATEWAY_LOADBYCOMPANIESIDPROJECTIDSTARTDATEENDDATEPROJECTTIMESTATEWORKFUNCTION", new SqlParameter("@companiesId", companiesId), new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@work_", work_), new SqlParameter("@function_", function_), new SqlParameter("@shape", shape), new SqlParameter("@conditionRating", conditionRating), new SqlParameter("@location", location), new SqlParameter("@material", material), new SqlParameter("@crew", crew));

            return Data;
        }



    }
}