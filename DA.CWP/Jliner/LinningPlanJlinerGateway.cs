using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Section;

namespace LiquiForce.LFSLive.DA.CWP.Jliner
{
    /// <summary>
    /// LinningPlanJlinerGateway
    /// </summary>
    public class LinningPlanJlinerGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LinningPlanJlinerGateway() : base("LFS_JUNCTION_LINER2")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LinningPlanJlinerGateway(DataSet data) : base(data, "LFS_JUNCTION_LINER2")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new LinningPlanTDS();
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
            tableMapping.DataSetTable = "LFS_JUNCTION_LINER2";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("DetailID", "DetailID");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("PullInDistance", "PullInDistance");
            tableMapping.ColumnMappings.Add("LinerSize", "LinerSize");
            tableMapping.ColumnMappings.Add("ClientLateralID", "ClientLateralID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }







        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATSET
        //

        /// <summary>
        /// LoadByIdMn
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        /// <param name="mn">mn</param>
        /// <returns>Data</returns>
        public DataSet LoadByIdMn(Guid id, int companyId, string mn)
        {
            FillDataWithStoredProcedure("LFS_CWP_LINNINGPLANJLINERGATEWAY_LOADBYID", new SqlParameter("@id", id), new SqlParameter("@companyId", companyId));

            switch (mn)
            {
                case "USMH":
                    FillDataWithStoredProcedure("LFS_CWP_LINNINGPLANJLINERGATEWAY_LOADBYIDUSMH", new SqlParameter("@id", id), new SqlParameter("@companyId", companyId));                  
                    break;
                case "DSMH":
                    FillDataWithStoredProcedure("LFS_CWP_LINNINGPLANJLINERGATEWAY_LOADBYIDDSMH", new SqlParameter("@id", id), new SqlParameter("@companyId", companyId));
                    break;
            }

            return Data;
        }



    }
}