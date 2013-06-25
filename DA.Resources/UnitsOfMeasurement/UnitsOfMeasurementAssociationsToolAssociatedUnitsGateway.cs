using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement
{
    /// <summary>
    /// UnitsOfMeasurementAssociationsToolAssociatedUnitsGateway
    /// </summary>
    public class UnitsOfMeasurementAssociationsToolAssociatedUnitsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsOfMeasurementAssociationsToolAssociatedUnitsGateway()
            : base("AssociatedUnits")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsOfMeasurementAssociationsToolAssociatedUnitsGateway(DataSet data)
            : base(data, "AssociatedUnits")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsOfMeasurementAssociationsToolTDS();
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
            tableMapping.DataSetTable = "AssociatedUnits";
            tableMapping.ColumnMappings.Add("AssociationsID", "AssociationsID");
            tableMapping.ColumnMappings.Add("UnitOfMeasurementID", "UnitOfMeasurementID");
            tableMapping.ColumnMappings.Add("Module", "Module");
            tableMapping.ColumnMappings.Add("ByDefault", "ByDefault");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("InDataBase", "InDataBase");
            tableMapping.ColumnMappings.Add("Description", "Description");
            
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
        /// LoadAll
        /// </summary>
        /// <param name="module">module</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAll(string module, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_UNITSOFMEASUREMENTASSOCIATIONSTOOLASSOCIATEDUNITSGATEWAY_LOADALL", new SqlParameter("@module", module), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="associationsId">associationsId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int associationsId)
        {
            string filter = string.Format("AssociationsID = {0}", associationsId);
            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetModule
        /// </summary>
        /// <param name="associationsId">associationsId</param>
        /// <returns>Module</returns>
        public string GetModule(int associationsId)
        {
            return (string)GetRow(associationsId)["Module"];
        }



        /// <summary>
        /// GetModule Original
        /// </summary>
        /// <param name="associationsId">associationsId</param>
        /// <returns>Original Module or EMPTY</returns>
        public string GetModuleOriginal(int associationsId)
        {
            if (GetRow(associationsId).IsNull(Table.Columns["Module"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(associationsId)["Module", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUnitOfMeasurementId
        /// </summary>
        /// <param name="associationsId">associationsId</param>
        /// <returns>UnitOfMeasurementID</returns>
        public int GetUnitOfMeasurementId(int associationsId)
        {
            return (int)GetRow(associationsId)["UnitOfMeasurementID"];
        }



        /// <summary>
        /// GetUnitOfMeasurementIdOriginal Original
        /// </summary>
        /// <param name="associationsId">associationsId</param>
        /// <returns>Original UnitOfMeasurementID or EMPTY</returns>
        public int GetUnitOfMeasurementIdOriginal(int associationsId)
        {
            return (int)GetRow(associationsId)["UnitOfMeasurementID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetByDefault
        /// </summary>
        /// <param name="associationsId">associationsId</param>
        /// <returns>ByDefault</returns>
        public bool GetByDefault(int associationsId)
        {
            return (bool)GetRow(associationsId)["ByDefault"];
        }



        /// <summary>
        /// GetByDefault Original
        /// </summary>
        /// <param name="associationsId">associationsId</param>
        /// <returns>Original ByDefault or EMPTY</returns>
        public bool GetByDefaultOriginal(int associationsId)
        {
            return (bool)GetRow(associationsId)["ByDefault", DataRowVersion.Original];
        }
    }
}
