using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Units
{
    /// <summary>
    /// UnitsAddNewGateway
    /// </summary>
    public class UnitsAddNewGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public UnitsAddNewGateway()
            : base("UnitsAddNew")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public UnitsAddNewGateway(DataSet data)
            : base(data, "UnitsAddNew")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsAddTDS();
        }



        /// <summary>
        /// InitAdapter (empty)
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "UnitsAddNew";
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("Code", "Code");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("VIN", "VIN");
            tableMapping.ColumnMappings.Add("Manufacturer", "Manufacturer");
            tableMapping.ColumnMappings.Add("Model", "Model");
            tableMapping.ColumnMappings.Add("Year_", "Year_");
            tableMapping.ColumnMappings.Add("IsTowable", "IsTowable");
            tableMapping.ColumnMappings.Add("LicenseCountry", "LicenseCountry");
            tableMapping.ColumnMappings.Add("LicenseState", "LicenseState");
            tableMapping.ColumnMappings.Add("LicensePlateNumber", "LicensePlateNumber");
            tableMapping.ColumnMappings.Add("ApportionedTagNumber", "ApportionedTagNumber");
            tableMapping.ColumnMappings.Add("CompanyLevelID", "CompanyLevelID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }



    }
}

