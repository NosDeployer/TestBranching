using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.Vacations
{
    /// <summary>
    /// VacationsNonWorkingDaysInformationGateway
    /// </summary>
    public class VacationsNonWorkingDaysInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsNonWorkingDaysInformationGateway()
            : base("NonWorkingDaysInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsNonWorkingDaysInformationGateway(DataSet data)
            : base(data, "NonWorkingDaysInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new VacationsNonWorkingDaysInformationTDS();
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
            tableMapping.DataSetTable = "NonWorkingDaysInformation";
            tableMapping.ColumnMappings.Add("NonWorkingDayID", "NonWorkingDayID");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("CompanyLevelID", "CompanyLevelID");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
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
        /// LoadByCompanyLevelId
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadByCompanyLevelId(int companyLevelId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_VACATION_NONWORKINGDAYSINFORMATIONGATEWAY_LOADBYCOMPANYLEVELID", new SqlParameter("@companyLevelId", companyLevelId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="nonWorkingDayId">nonWorkingDayId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int nonWorkingDayId)
        {
            string filter = string.Format("NonWorkingDayID = {0}", nonWorkingDayId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.LabourHours.Vacations.VacationsNonWorkingDaysInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetDescription
        /// </summary>
        /// <param name="nonWorkingDayId">nonWorkingDayId</param>
        /// <returns>Description</returns>
        public string GetDescription(int nonWorkingDayId)
        {
            return (string)GetRow(nonWorkingDayId)["Description"];
        }


        
        /// <summary>
        /// GetDescription Original
        /// </summary>
        /// <param name="nonWorkingDayId">nonWorkingDayId</param>
        /// <returns>Original Description</returns>
        public string GetDescriptionOriginal(int nonWorkingDayId)
        {
            return (string)GetRow(nonWorkingDayId)["Description", DataRowVersion.Original];
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// IsNonWorkingDay
        /// </summary>
        /// <param name="date">date</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Description</returns>
        public bool IsNonWorkingDay(DateTime date, int companyLevelId, int companyId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_VACATION_NONWORKING_DAYS WHERE (Date = @date) AND (CompanyLevelID = @companyLevelId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@date", date));
            command.Parameters.Add(new SqlParameter("@companyLevelId", companyLevelId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }




    }
}