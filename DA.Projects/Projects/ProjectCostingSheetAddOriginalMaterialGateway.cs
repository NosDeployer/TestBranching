using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddOriginalMaterialGateway
    /// </summary>
    public class ProjectCostingSheetAddOriginalMaterialGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCostingSheetAddOriginalMaterialGateway()
            : base("OriginalMaterial")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCostingSheetAddOriginalMaterialGateway(DataSet data)
            : base(data, "OriginalMaterial")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetAddTDS();
        }



        /// <summary>
        /// InitAdapter (empty)
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.DataSetTable = "OriginalMaterial";
            tableMapping.ColumnMappings.Add("ConfirmedSize", "ConfirmedSize");
            tableMapping.ColumnMappings.Add("SteelTapeLength", "SteelTapeLength");
            tableMapping.ColumnMappings.Add("LinerSize", "LinerSize");
            tableMapping.ColumnMappings.Add("LinerInstalled", "LinerInstalled");
            tableMapping.ColumnMappings.Add("COInstalled", "COInstalled");
            tableMapping.ColumnMappings.Add("BackfilledSoil", "BackfilledSoil");
            tableMapping.ColumnMappings.Add("BackfilledConcrete", "BackfilledConcrete");
            tableMapping.ColumnMappings.Add("Size", "Size");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("Tickness", "Tickness");
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
        /// <param name="projectId">projectId</param>
        /// <param name="work_">work_</param>
        /// <param name="size">size</param>
        /// <param name="tickness">tickness</param>
        /// <param name="length">length</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <returns>Data</returns>
        public DataSet Load(int projectId, string work_, string size, string tickness, string length, DateTime startDate, DateTime endDate)
        {
            switch (work_)
            {
                case "Full Length Lining":
                    FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETINFORMATIONORIGINALMATERIALGATEWAY_LOADBYCOSTINGSHEETIDBYFLL", new SqlParameter("@projectId", projectId), new SqlParameter("@size", size), new SqlParameter("@thickness", tickness), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate));
                    break;

                    //TODO MH
                case "Manhole Rehab":
                    FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETINFORMATIONORIGINALMATERIALGATEWAY_LOADBYCOSTINGSHEETIDBYMHREHAB", new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate));
                    break;

                case "Point Repairs":
                    FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETINFORMATIONORIGINALMATERIALGATEWAY_LOADBYCOSTINGSHEETIDBYPR", new SqlParameter("@projectId", projectId), new SqlParameter("@size", size), new SqlParameter("@length", length), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate)); 
                    break;

                case "Junction Lining":
                    FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETINFORMATIONORIGINALMATERIALGATEWAY_LOADBYCOSTINGSHEETIDBYJL", new SqlParameter("@projectId", projectId), new SqlParameter("@size", size), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate));
                    break;

                case "Junction Lining Misc Supplies":
                    FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETINFORMATIONORIGINALMATERIALGATEWAY_LOADBYCOSTINGSHEETIDBYJLMISCSUPPLIES", new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate));
                    break;

                case "Junction Lining Cleanout Material":
                    FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETINFORMATIONORIGINALMATERIALGATEWAY_LOADBYCOSTINGSHEETIDBYJLCLEANOUTMATERIAL", new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate));
                    break;

                case "Junction Lining Backfill Cleanut":
                    FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETINFORMATIONORIGINALMATERIALGATEWAY_LOADBYCOSTINGSHEETIDBYJLBACKFILLCLEANOUT", new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate));
                    break;

                case "Junction Lining Restoration Crowle":
                    FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETINFORMATIONORIGINALMATERIALGATEWAY_LOADBYCOSTINGSHEETIDBYJLRESTORATIONCROWLE", new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate));
                    break;
            }

            return Data;
        }



    }
}