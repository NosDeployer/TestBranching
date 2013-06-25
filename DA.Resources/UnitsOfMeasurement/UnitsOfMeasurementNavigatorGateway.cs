using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement
{
    /// <summary>
    /// UnitsOfMeasurementNavigatorGateway
    /// </summary>
    public class UnitsOfMeasurementNavigatorGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsOfMeasurementNavigatorGateway()
            : base("UnitsOfMeasurementNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsOfMeasurementNavigatorGateway(DataSet data)
            : base(data, "UnitsOfMeasurementNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsOfMeasurementNavigatorTDS();
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
            tableMapping.DataSetTable = "UnitsOfMeasurementNavigator";
            tableMapping.ColumnMappings.Add("UnitOfMeasurementID", "UnitOfMeasurementID");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("Abbreviation", "Abbreviation");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDataBase", "InDataBase");
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
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAll(int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_UNITSOFMEASUREMENTNAVIGATORGATEWAY_LOADALL", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="unitOfMeasurementId">unitOfMeasurementId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int unitOfMeasurementId)
        {
            string filter = string.Format("UnitOfMeasurementID = {0}", unitOfMeasurementId);
            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement.UnitsOfMeasurementGateway.GetRow");
            }
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="description">description</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow2(string description)
        {
            string filter = string.Format("Description = '{0}'", description);
            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement.UnitsOfMeasurementGateway.GetRow");
            }
        }



        /// <summary>
        /// GetDescription
        /// </summary>
        /// <param name="unitOfMeasurementId">unitOfMeasurementId</param>
        /// <returns>Description</returns>
        public string GetDescription(int unitOfMeasurementId)
        {
            return (string)GetRow(unitOfMeasurementId)["Description"];
        }



        /// <summary>
        /// GetDescription Original
        /// </summary>
        /// <param name="unitOfMeasurementId">unitOfMeasurementId</param>
        /// <returns>Original Description or EMPTY</returns>
        public string GetDescriptionOriginal(int unitOfMeasurementId)
        {
            if (GetRow(unitOfMeasurementId).IsNull(Table.Columns["Description"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitOfMeasurementId)["Description", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUnitOfMeasurementId
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Description</returns>
        public int GetUnitOfMeasurementId(string description)
        {
            return (int)GetRow2(description)["UnitOfMeasurementID"];
        }



        /// <summary>
        /// GetAbbreviation
        /// </summary>
        /// <param name="unitOfMeasurementId">unitOfMeasurementId</param>
        /// <returns>Type</returns>
        public string GetAbbreviation(int unitOfMeasurementId)
        {
            return (string)GetRow(unitOfMeasurementId)["Abbreviation"];
        }



        /// <summary>
        /// GetAbbreviation Original
        /// </summary>
        /// <param name="unitOfMeasurementId">unitOfMeasurementId</param>
        /// <returns>Original Abbreviation or EMPTY</returns>
        public string GetAbbreviationOriginal(int unitOfMeasurementId)
        {
            if (GetRow(unitOfMeasurementId).IsNull(Table.Columns["Abbreviation"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitOfMeasurementId)["Abbreviation", DataRowVersion.Original];
            }
        }

 
    }
}
