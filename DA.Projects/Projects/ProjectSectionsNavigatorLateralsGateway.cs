using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectSectionsNavigatorLateralsGateway
    /// </summary>
    public class ProjectSectionsNavigatorLateralsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectSectionsNavigatorLateralsGateway()
            : base("ProjectSectionNavigatorLaterals")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectSectionsNavigatorLateralsGateway(DataSet data)
            : base(data, "ProjectSectionNavigatorLaterals")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectSectionsNavigatorTDS();
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
            tableMapping.DataSetTable = "ProjectSectionNavigatorLaterals";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("LateralID", "LateralID");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
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
        /// LoadBySection_ProjectId
        /// </summary>
        /// <param name="section_">section_</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadBySection_ProjectId(int section_, int projectId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTSECTIONSNAVIGATORLATERALS_LOADBYSECTION_PROJECTID", new SqlParameter("@section_", section_), new SqlParameter("@projectId", projectId), new SqlParameter("@companyId", companyId));
            return Data;
        }
    }
}
