using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintMealsOriginalGateway
    /// </summary
    public class PrintMealsOriginalGateway : DataTableGateway
    {
        /// <summary>
        /// Constructor
        /// </summary>     
        public PrintMealsOriginalGateway()
            : base("Original")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PrintMealsOriginalGateway(DataSet data)
            : base(data, "Original")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PrintMealsTDS();
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
            tableMapping.DataSetTable = "Original";
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("EmployeeName", "EmployeeName");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("MealsCountry", "MealsCountry");
            tableMapping.ColumnMappings.Add("MealsAllowance", "MealsAllowance");
            tableMapping.ColumnMappings.Add("Salaried", "Salaried");
            tableMapping.ColumnMappings.Add("ProjectTimeState", "ProjectTimeState");
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
        /// Load
        /// </summary>
        /// <returns>Data</returns>
        public DataSet Load()
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTMEALSORIGINALGATEWAY_LOAD");
            return Data;
        }



        /// <summary>
        /// LoadByEmployeeTypeStartDateEndDateProjectTimeState
        /// </summary>
        /// <returns>Data</returns>
        public DataSet LoadByEmployeeTypeStartDateEndDateProjectTimeState(string employeeType, DateTime startDate, DateTime endDate, string projectTimeState)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTMEALSORIGINALGATEWAY_LOADBYEMPLOYEETYPESTARTDATEENDDATEPROJECTTIMESTATE", new SqlParameter("@employeeType", employeeType), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@projectTimeState", projectTimeState));
            return Data;
        }



        /// <summary>
        /// LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeState
        /// </summary>
        /// <returns>Data</returns>
        public DataSet LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeState(string employeeType, DateTime startDate, DateTime endDate, int employeeId, string projectTimeState)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTMEALSORIGINALGATEWAY_LOADBYEMPLOYEETYPESTARTDATEENDDATEEMPLOYEEIDPROJECTTIMESTATE", new SqlParameter("@employeeType", employeeType), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState));
            return Data;
        }



        /// <summary>
        /// LoadByEmployeeTypeSalariedStartDateEndDateProjectTimeState
        /// </summary>
        /// <returns>Data</returns>
        public DataSet LoadByEmployeeTypeSalariedStartDateEndDateProjectTimeState(string employeeType, DateTime startDate, DateTime endDate, string projectTimeState, int salaried)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTMEALSORIGINALGATEWAY_LOADBYEMPLOYEETYPESALARIEDSTARTDATEENDDATEPROJECTTIMESTATE", new SqlParameter("@employeeType", employeeType), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@salaried", salaried), new SqlParameter("@projectTimeState", projectTimeState));
            return Data;
        }



        /// <summary>
        /// LoadByEmployeeTypeSalariedStartDateEndDateEmployeeIdProjectTimeState
        /// </summary>
        /// <returns>Data</returns>
        public DataSet LoadByEmployeeTypeSalariedStartDateEndDateEmployeeIdProjectTimeState(string employeeType, DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, int salaried)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PRINTMEALSORIGINALGATEWAY_LOADBYEMPLOYEETYPESALARIEDSTARTDATEENDDATEEMPLOYEEIDPROJECTTIMESTATE", new SqlParameter("@employeeType", employeeType), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@employeeId", employeeId), new SqlParameter("@projectTimeState", projectTimeState), new SqlParameter("@salaried", salaried));
            return Data;
        }



    }
}