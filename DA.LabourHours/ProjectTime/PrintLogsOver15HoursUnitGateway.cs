using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    public class PrintLogsOver15HoursUnitGateway : DataTableGateway
    {
        // CONSTRUCTORS
        public PrintLogsOver15HoursUnitGateway()
            : base("LFS_UNIT")
        {
        }

        public PrintLogsOver15HoursUnitGateway(DataSet data)
            : base(data, "LFS_UNIT")
        {
        }



        // INITIALIZERS
        protected override void InitData()
        {
            _data = new PrintLogsOver15HoursTDS();
        }

        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "LFS_UNIT";
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("UnitCode", "UnitCode");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }



        // METHODS
        public void Load()
        {
            string commandText = "SELECT UnitID, UnitCode FROM LFS_FM_UNIT WHERE (Deleted = 0) AND (IsTowable = 0) ORDER BY UnitCode";
            FillData(commandText);
        }
    }
}
