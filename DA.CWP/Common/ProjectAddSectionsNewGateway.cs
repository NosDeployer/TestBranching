using System;
using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// ProjectAddSectionsNewGateway
    /// </summary>
    public class ProjectAddSectionsNewGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectAddSectionsNewGateway()
            : base("ProjectAddSectionsNew")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectAddSectionsNewGateway(DataSet data)
            : base(data, "ProjectAddSectionsNew")
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
            tableMapping.DataSetTable = "ProjectAddSectionsNew";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");            
            tableMapping.ColumnMappings.Add("RehabAssessmentWork", "RehabAssessmentWork");
            tableMapping.ColumnMappings.Add("FulllengthLiningWork", "FulllengthLiningWork");
            tableMapping.ColumnMappings.Add("JunctionLiningWork", "JunctionLiningWork");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("MapSize", "MapSize");
            tableMapping.ColumnMappings.Add("MapLength", "MapLength");
            tableMapping.ColumnMappings.Add("PointRepairsWork", "PointRepairsWork");

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






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int id)
        {
            string filter = string.Format("ID = {0}", id);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.ProjectAddSectionsNewGateway.GetRow");
            }
        }



        /// <summary>
        /// GetUsmhShape
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>UsmhShape or EMPTY</returns>
        public string GetUsmhShape(int id)
        {
            if (GetRow(id).IsNull("UsmhShape"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id)["UsmhShape"];
            }
        }



        /// <summary>
        /// GetUsmhShape Original
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Original UsmhShape or EMPTY</returns>
        public string GetUsmhShapeOriginal(int id)
        {
            if (GetRow(id).IsNull(Table.Columns["UsmhShape"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id)["UsmhShape", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUsmhLocation
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>UsmhLocation or EMPTY</returns>
        public string GetUsmhLocation(int id)
        {
            if (GetRow(id).IsNull("UsmhLocation"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id)["UsmhLocation"];
            }
        }



        /// <summary>
        /// GetUsmhLocation Original
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Original UsmhLocation or EMPTY</returns>
        public string GetUsmhLocationOriginal(int id)
        {
            if (GetRow(id).IsNull(Table.Columns["UsmhLocation"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id)["UsmhLocation", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUsmhMaterialId
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>UsmhMaterialId or EMPTY</returns>
        public int? GetUsmhMaterialId(int id)
        {
            if (GetRow(id).IsNull("UsmhMaterialId"))
            {
                return null;
            }
            else
            {
                return (int?)GetRow(id)["UsmhMaterialId"];
            }
        }



        /// <summary>
        /// GetUsmhMaterialId Original
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Original UsmhMaterialId or EMPTY</returns>
        public int? GetUsmhMaterialIdOriginal(int id)
        {
            if (GetRow(id).IsNull(Table.Columns["UsmhMaterialId"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id)["UsmhMaterialId", DataRowVersion.Original];
            }
        }       



        /// <summary>
        /// GetUsmhManholeRugs. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>UsmhManholeRugs or EMPTY</returns>
        public int? GetUsmhManholeRugs(int id)
        {
            if (GetRow(id).IsNull("UsmhManholeRugs"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id)["UsmhManholeRugs"];
            }
        }



        /// <summary>
        /// GetUsmhManholeRugs Original
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Original UsmhManholeRugs or EMPTY</returns>
        public int? GetUsmhManholeRugsOriginal(int id)
        {
            if (GetRow(id).IsNull(Table.Columns["UsmhManholeRugs"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id)["UsmhManholeRugs", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUsmhConditionRating. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>UsmhConditionRating or EMPTY</returns>
        public int? GetUsmhConditionRating(int id)
        {
            if (GetRow(id).IsNull("UsmhConditionRating"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id)["UsmhConditionRating"];
            }
        }



        /// <summary>
        /// GetUsmhConditionRating Original
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Original UsmhConditionRating or EMPTY</returns>
        public int? GetUsmhConditionRatingOriginal(int id)
        {
            if (GetRow(id).IsNull(Table.Columns["UsmhConditionRating"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id)["UsmhConditionRating", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDsmhShape
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>DsmhShape or EMPTY</returns>
        public string GetDsmhShape(int id)
        {
            if (GetRow(id).IsNull("DsmhShape"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id)["DsmhShape"];
            }
        }



        /// <summary>
        /// GetDsmhShape Original
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Original DsmhShape or EMPTY</returns>
        public string GetDsmhShapeOriginal(int id)
        {
            if (GetRow(id).IsNull(Table.Columns["DsmhShape"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id)["DsmhShape", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDsmhLocation
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>DsmhLocation or EMPTY</returns>
        public string GetDsmhLocation(int id)
        {
            if (GetRow(id).IsNull("DsmhLocation"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id)["DsmhLocation"];
            }
        }



        /// <summary>
        /// GetDsmhLocation Original
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Original DsmhLocation or EMPTY</returns>
        public string GetDsmhLocationOriginal(int id)
        {
            if (GetRow(id).IsNull(Table.Columns["DsmhLocation"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id)["DsmhLocation", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDsmhMaterialId
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>DsmhMaterialId or EMPTY</returns>
        public int? GetDsmhMaterialId(int id)
        {
            if (GetRow(id).IsNull("DsmhMaterialId"))
            {
                return null;
            }
            else
            {
                return (int?)GetRow(id)["DsmhMaterialId"];
            }
        }



        /// <summary>
        /// GetDsmhMaterialId Original
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Original DsmhMaterialId or EMPTY</returns>
        public int? GetDsmhMaterialIdOriginal(int id)
        {
            if (GetRow(id).IsNull(Table.Columns["DsmhMaterialId"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id)["DsmhMaterialId", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDsmhManholeRugs. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>DsmhManholeRugs or EMPTY</returns>
        public int? GetDsmhManholeRugs(int id)
        {
            if (GetRow(id).IsNull("DsmhManholeRugs"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id)["DsmhManholeRugs"];
            }
        }



        /// <summary>
        /// GetDsmhManholeRugs Original
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Original DsmhManholeRugs or EMPTY</returns>
        public int? GetDsmhManholeRugsOriginal(int id)
        {
            if (GetRow(id).IsNull(Table.Columns["DsmhManholeRugs"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id)["DsmhManholeRugs", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDsmhConditionRating. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>DsmhConditionRating or EMPTY</returns>
        public int? GetDsmhConditionRating(int id)
        {
            if (GetRow(id).IsNull("DsmhConditionRating"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id)["DsmhConditionRating"];
            }
        }



        /// <summary>
        /// GetDsmhConditionRating Original
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Original DsmhConditionRating or EMPTY</returns>
        public int? GetDsmhConditionRatingOriginal(int id)
        {
            if (GetRow(id).IsNull(Table.Columns["DsmhConditionRating"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id)["DsmhConditionRating", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetClientId
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>ClientId or EMPTY</returns>
        public string GetClientId(int id)
        {
            if (GetRow(id).IsNull("ClientId"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id)["ClientId"];
            }
        }



        /// <summary>
        /// GetClientId Original
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Original ClientId or EMPTY</returns>
        public string GetClientIdOriginal(int id)
        {
            if (GetRow(id).IsNull(Table.Columns["ClientId"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id)["ClientId", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSectionMaterial
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>SectionMaterial or EMPTY</returns>
        public string GetSectionMaterial(int id)
        {
            if (GetRow(id).IsNull("SectionMaterial"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id)["SectionMaterial"];
            }
        }



        /// <summary>
        /// GetSectionMaterial Original
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Original SectionMaterial or EMPTY</returns>
        public string GetSectionMaterialOriginal(int id)
        {
            if (GetRow(id).IsNull(Table.Columns["SectionMaterial"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id)["SectionMaterial", DataRowVersion.Original];
            }
        }
    }
}
