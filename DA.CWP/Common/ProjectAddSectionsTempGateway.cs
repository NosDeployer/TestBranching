using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// ProjectAddSectionsTempGateway
    /// </summary>
    public class ProjectAddSectionsTempGateway  : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectAddSectionsTempGateway()
            : base("ProjectAddSectionsTemp")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectAddSectionsTempGateway(DataSet data)
            : base(data, "ProjectAddSectionsTemp")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectAddSectionsTDS();
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
            tableMapping.DataSetTable = "ProjectAddSections";
            tableMapping.ColumnMappings.Add("ID");
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("USMHDescription", "USMHDescription");
            tableMapping.ColumnMappings.Add("DSMHDescription", "DSMHDescription");
            tableMapping.ColumnMappings.Add("JunctionLiningWork", "JunctionLiningWork");
            tableMapping.ColumnMappings.Add("RehabAssessmentWork", "RehabAssessmentWork");
            tableMapping.ColumnMappings.Add("FulllengthLiningWork", "FulllengthLiningWork");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("AssetIdCopy", "AssetIdCopy");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("MapSize", "MapSize");
            tableMapping.ColumnMappings.Add("MapLength", "MapLength");

            tableMapping.ColumnMappings.Add("RehabAssessmentPrevWork", "RehabAssessmentPrevWork");
            tableMapping.ColumnMappings.Add("FullLengthLiningPrevWork", "FullLengthLiningPrevWork");
            tableMapping.ColumnMappings.Add("JunctionLiningPrevWork", "JunctionLiningPrevWork");

            tableMapping.ColumnMappings.Add("PointRepairsWork", "PointRepairsWork");
            tableMapping.ColumnMappings.Add("PointRepairsPrevWork", "PointRepairsPrevWork");

            tableMapping.ColumnMappings.Add("UsmhStreet", "UsmhStreet");
            tableMapping.ColumnMappings.Add("UsmhLatitude", "UsmhLatitude");
            tableMapping.ColumnMappings.Add("UsmhLongitude", "UsmhLongitude");
            tableMapping.ColumnMappings.Add("UsmhShape", "UsmhShape");
            tableMapping.ColumnMappings.Add("UsmhLocation", "UsmhLocation");
            tableMapping.ColumnMappings.Add("UsmhMaterialId", "UsmhMaterialId");
            tableMapping.ColumnMappings.Add("UsmhMaterialType", "UsmhMaterialType");
            tableMapping.ColumnMappings.Add("UsmhTopDiameter", "UsmhTopDiameter");
            tableMapping.ColumnMappings.Add("UsmhTopDepth", "UsmhTopDepth");
            tableMapping.ColumnMappings.Add("UsmhDownDiameter", "UsmhDownDiameter");
            tableMapping.ColumnMappings.Add("UsmhDownDepth", "UsmhDownDepth");
            tableMapping.ColumnMappings.Add("UsmhManholeRugs", "UsmhManholeRugs");
            tableMapping.ColumnMappings.Add("UsmhRectangle1LongSide", "UsmhRectangle1LongSide");
            tableMapping.ColumnMappings.Add("UsmhRectangle1ShortSide", "UsmhRectangle1ShortSide");
            tableMapping.ColumnMappings.Add("UsmhRectangle2LongSide", "UsmhRectangle2LongSide");
            tableMapping.ColumnMappings.Add("UsmhRectangle2ShortSide", "UsmhRectangle2ShortSide");
            tableMapping.ColumnMappings.Add("UsmhTotalSurfaceArea", "UsmhTotalSurfaceArea");

            tableMapping.ColumnMappings.Add("DsmhStreet", "DsmhStreet");
            tableMapping.ColumnMappings.Add("DsmhLatitude", "DsmhLatitude");
            tableMapping.ColumnMappings.Add("DsmhLongitude", "DsmhLongitude");
            tableMapping.ColumnMappings.Add("DsmhShape", "DsmhShape");
            tableMapping.ColumnMappings.Add("DsmhLocation", "DsmhLocation");
            tableMapping.ColumnMappings.Add("DsmhMaterialId", "DsmhMaterialId");
            tableMapping.ColumnMappings.Add("DsmhMaterialType", "DsmhMaterialType");
            tableMapping.ColumnMappings.Add("DsmhTopDiameter", "DsmhTopDiameter");
            tableMapping.ColumnMappings.Add("DsmhTopDepth", "DsmhTopDepth");
            tableMapping.ColumnMappings.Add("DsmhDownDiameter", "DsmhDownDiameter");
            tableMapping.ColumnMappings.Add("DsmhDownDepth", "DsmhDownDepth");
            tableMapping.ColumnMappings.Add("DsmhManholeRugs", "DsmhManholeRugs");
            tableMapping.ColumnMappings.Add("DsmhRectangle1LongSide", "DsmhRectangle1LongSide");
            tableMapping.ColumnMappings.Add("DsmhRectangle1ShortSide", "DsmhRectangle1ShortSide");
            tableMapping.ColumnMappings.Add("DsmhRectangle2LongSide", "DsmhRectangle2LongSide");
            tableMapping.ColumnMappings.Add("DsmhRectangle2ShortSide", "DsmhRectangle2ShortSide");
            tableMapping.ColumnMappings.Add("DsmhTotalSurfaceArea", "DsmhTotalSurfaceArea");

            tableMapping.ColumnMappings.Add("UsmhConditionRating", "UsmhConditionRating");
            tableMapping.ColumnMappings.Add("DsmhConditionRating", "DsmhConditionRating");

            tableMapping.ColumnMappings.Add("SectionMaterial", "SectionMaterial");
            tableMapping.ColumnMappings.Add("ClientId", "ClientId");
            tableMapping.ColumnMappings.Add("MHRehabUsmh", "MHRehabUsmh");
            tableMapping.ColumnMappings.Add("MHRehabDsmh", "MHRehabDsmh");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }


  
    }
}