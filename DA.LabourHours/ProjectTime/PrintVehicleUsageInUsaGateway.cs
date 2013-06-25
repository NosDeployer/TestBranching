using System;
using System.Data;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintVehicleUsageInUsaGateway
    /// </summary>
    public class PrintVehicleUsageInUsaGateway : DataTableGateway
    {
        // CONSTRUCTORS
        public PrintVehicleUsageInUsaGateway()
            : base("PrintVehicleUsageInUsa")
        {
        }

        public PrintVehicleUsageInUsaGateway(DataSet data)
            : base(data, "PrintVehicleUsageInUsa")
        {
        }



        // INITIALIZERS
        protected override void InitData()
        {
            _data = new PrintVehicleUsageInUsaTDS();
        }

        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "PrintVehicleUsageInUSA";
            tableMapping.ColumnMappings.Add("UnitCode", "UnitCode");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("TowedUnitID", "TowedUnitID");
            tableMapping.ColumnMappings.Add("ProjectTimeState", "ProjectTimeState");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }



        // METHODS
        public void LoadByStartDateEndDateProjectTimeState(DateTime startDate, DateTime endDate, string projectTimeState)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = string.Format("SELECT LFS_FM_UNIT.UnitCode, LFS_PROJECT_TIME.Date_, LFS_PROJECT_TIME.TowedUnitID, LFS_PROJECT_TIME.ProjectTimeState FROM LFS_PROJECT_TIME INNER JOIN LFS_FM_UNIT ON LFS_PROJECT_TIME.UnitID = LFS_FM_UNIT.UnitID INNER JOIN LFS_PROJECT ON LFS_PROJECT_TIME.ProjectID = LFS_PROJECT.ProjectID WHERE (LFS_PROJECT_TIME.Date_ BETWEEN '{0}' AND '{1}') AND (LFS_PROJECT_TIME.Deleted = 0) AND (LFS_FM_UNIT.Deleted = 0) AND (LFS_PROJECT.CountryID = 2) AND (LFS_PROJECT_TIME.ProjectTimeState LIKE '{2}') ORDER BY LFS_FM_UNIT.UnitCode, LFS_PROJECT_TIME.Date_", startDate, endDate, projectTimeState);
            }
            else
            {
                commandText = string.Format("SELECT LFS_FM_UNIT.UnitCode, LFS_PROJECT_TIME.Date_, LFS_PROJECT_TIME.TowedUnitID, LFS_PROJECT_TIME.ProjectTimeState FROM LFS_PROJECT_TIME INNER JOIN LFS_FM_UNIT ON LFS_PROJECT_TIME.UnitID = LFS_FM_UNIT.UnitID INNER JOIN LFS_PROJECT ON LFS_PROJECT_TIME.ProjectID = LFS_PROJECT.ProjectID WHERE (LFS_PROJECT_TIME.Date_ BETWEEN '{0}' AND '{1}') AND (LFS_PROJECT_TIME.Deleted = 0) AND (LFS_FM_UNIT.Deleted = 0) AND (LFS_PROJECT.CountryID = 2) AND (LFS_PROJECT_TIME.ProjectTimeState <> 'Approved') ORDER BY LFS_FM_UNIT.UnitCode, LFS_PROJECT_TIME.Date_", startDate, endDate);
            }

            FillData(commandText);
        }



    }
}