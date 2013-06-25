using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation
{
    /// <summary>
    /// ManholeRehabilitationManholeDetailsGateway
    /// </summary>
    public class ManholeRehabilitationManholeDetailsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ManholeRehabilitationManholeDetailsGateway()
            : base("ManholeDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ManholeRehabilitationManholeDetailsGateway(DataSet data)
            : base(data, "ManholeDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ManholeRehabilitationTDS();
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
            tableMapping.DataSetTable = "ManholeDetails";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("MHID", "MHID");
            tableMapping.ColumnMappings.Add("Latitud", "Latitud");
            tableMapping.ColumnMappings.Add("Longitude", "Longitude");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ManholeShape", "ManholeShape");
            tableMapping.ColumnMappings.Add("Location", "Location");
            tableMapping.ColumnMappings.Add("MaterialID", "MaterialID");
            tableMapping.ColumnMappings.Add("TopDiameter", "TopDiameter");
            tableMapping.ColumnMappings.Add("TopDepth", "TopDepth");
            tableMapping.ColumnMappings.Add("TopFloor", "TopFloor");
            tableMapping.ColumnMappings.Add("TopCeiling", "TopCeiling");
            tableMapping.ColumnMappings.Add("TopBenching", "TopBenching");
            tableMapping.ColumnMappings.Add("DownDiameter", "DownDiameter");
            tableMapping.ColumnMappings.Add("DownDepth", "DownDepth");
            tableMapping.ColumnMappings.Add("DownFloor", "DownFloor");
            tableMapping.ColumnMappings.Add("DownCeiling", "DownCeiling");
            tableMapping.ColumnMappings.Add("DownBenching", "DownBenching");
            tableMapping.ColumnMappings.Add("Rectangle1LongSide", "Rectangle1LongSide");
            tableMapping.ColumnMappings.Add("Rectangle1ShortSide", "Rectangle1ShortSide");
            tableMapping.ColumnMappings.Add("Rectangle2LongSide", "Rectangle2LongSide");
            tableMapping.ColumnMappings.Add("Rectangle2ShortSide", "Rectangle2ShortSide");
            tableMapping.ColumnMappings.Add("TopSurfaceArea", "TopSurfaceArea");
            tableMapping.ColumnMappings.Add("DownSurfaceArea", "DownSurfaceArea");
            tableMapping.ColumnMappings.Add("ManholeRugs", "ManholeRugs");
            tableMapping.ColumnMappings.Add("TotalDepth", "TotalDepth");
            tableMapping.ColumnMappings.Add("TotalSurfaceArea", "TotalSurfaceArea");
            tableMapping.ColumnMappings.Add("ConditionRating", "ConditionRating");
            tableMapping.ColumnMappings.Add("MaterialDescription", "MaterialDescription");
            
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
        /// LoadByAssetId
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByAssetId(int assetId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_MANHOLEREHABILITATIONMANHOLEDETAILSGATEWAY_LOADBYASSETID", new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));
            return Data;            
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int assetId)
        {
            string filter = string.Format("AssetID = {0}", assetId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation.ManholeRehabilitationManholeDetailsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetMHID
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>MHID or EMPTY</returns>
        public string GetMHID(int assetId)
        {
            if (GetRow(assetId).IsNull("MHID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["MHID"];
            }
        }



        /// <summary>
        /// GetLatitud
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Latitud or EMPTY</returns>
        public string GetLatitud(int assetId)
        {
            if (GetRow(assetId).IsNull("Latitud"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Latitud"];
            }
        }



        /// <summary>
        /// GetLatitud Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original Latitud or EMPTY</returns>
        public string GetLatitudOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["Latitud"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Latitud", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLongitude. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Longitude or EMPTY</returns>
        public string GetLongitude(int assetId)
        {
            if (GetRow(assetId).IsNull("Longitude"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Longitude"];
            }
        }



        /// <summary>
        /// GetLongitude Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original Longitude or EMPTY</returns>
        public string GetLongitudeOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["Longitude"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Longitude", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAddress. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Address or EMPTY</returns>
        public string GetAddress(int assetId)
        {
            if (GetRow(assetId).IsNull("Address"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Address"];
            }
        }



        /// <summary>
        /// GetAddress Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original Address or EMPTY</returns>
        public string GetAddressOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["Address"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Address", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetManholeShape
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>ManholeShape or EMPTY</returns>
        public string GetManholeShape(int assetId)
        {
            if (GetRow(assetId).IsNull("ManholeShape"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["ManholeShape"];
            }
        }



        /// <summary>
        /// GetManholeShape Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original ManholeShape or EMPTY</returns>
        public string GetManholeShapeOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["ManholeShape"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["ManholeShape", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLocation
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Location or EMPTY</returns>
        public string GetLocation(int assetId)
        {
            if (GetRow(assetId).IsNull("Location"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Location"];
            }
        }



        /// <summary>
        /// GetLocation Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original Location or EMPTY</returns>
        public string GetLocationOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["Location"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Location", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMaterialID
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>MaterialID or EMPTY</returns>
        public int? GetMaterialID(int assetId)
        {
            if (GetRow(assetId).IsNull("MaterialID"))
            {
                return null;
            }
            else
            {
                return (int?)GetRow(assetId)["MaterialID"];
            }
        }



        /// <summary>
        /// GetMaterialID Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original MaterialID or EMPTY</returns>
        public int? GetMaterialIDOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["MaterialID"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(assetId)["MaterialID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTopDiameter
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>TopDiameter or EMPTY</returns>
        public string GetTopDiameter(int assetId)
        {
            if (GetRow(assetId).IsNull("TopDiameter"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["TopDiameter"];
            }
        }



        /// <summary>
        /// GetTopDiameter Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original TopDiameter or EMPTY</returns>
        public string GetTopDiameterOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["TopDiameter"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["TopDiameter", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTopDepth
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>TopDepth or EMPTY</returns>
        public string GetTopDepth(int assetId)
        {
            if (GetRow(assetId).IsNull("TopDepth"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["TopDepth"];
            }
        }



        /// <summary>
        /// GetTopDepth Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original TopDepth or EMPTY</returns>
        public string GetTopDepthOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["TopDepth"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["TopDepth", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTopFloor
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>TopFloor or EMPTY</returns>
        public string GetTopFloor(int assetId)
        {
            if (GetRow(assetId).IsNull("TopFloor"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["TopFloor"];
            }
        }



        /// <summary>
        /// GetTopFloor Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original TopFloor or EMPTY</returns>
        public string GetTopFloorOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["TopFloor"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["TopFloor", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTopCeiling. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>TopCeiling or EMPTY</returns>
        public string GetTopCeiling(int assetId)
        {
            if (GetRow(assetId).IsNull("TopCeiling"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["TopCeiling"];
            }
        }



        /// <summary>
        /// GetTopCeiling Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original TopCeiling or EMPTY</returns>
        public string GetTopCeilingOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["TopCeiling"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["TopCeiling", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTopBenching. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>TopBenching or EMPTY</returns>
        public string GetTopBenching(int assetId)
        {
            if (GetRow(assetId).IsNull("TopBenching"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["TopBenching"];
            }
        }



        /// <summary>
        /// GetTopBenching Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original TopBenching or EMPTY</returns>
        public string GetTopBenchingOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["TopBenching"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["TopBenching", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDownDiameter
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DownDiameter or EMPTY</returns>
        public string GetDownDiameter(int assetId)
        {
            if (GetRow(assetId).IsNull("DownDiameter"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DownDiameter"];
            }
        }



        /// <summary>
        /// GetDownDiameter Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original DownDiameter or EMPTY</returns>
        public string GetDownDiameterOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["DownDiameter"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DownDiameter", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDownDepth. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DownDepth or EMPTY</returns>
        public string GetDownDepth(int assetId)
        {
            if (GetRow(assetId).IsNull("DownDepth"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DownDepth"];
            }
        }



        /// <summary>
        /// GetDownDepth Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original DownDepth or EMPTY</returns>
        public string GetDownDepthOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["DownDepth"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DownDepth", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDownFloor. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DownFloor or EMPTY</returns>
        public string GetDownFloor(int assetId)
        {
            if (GetRow(assetId).IsNull("DownFloor"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DownFloor"];
            }
        }



        /// <summary>
        /// GetDownFloor Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original DownFloor or EMPTY</returns>
        public string GetDownFloorOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["DownFloor"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DownFloor", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDownCeiling. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DownCeiling or EMPTY</returns>
        public string GetDownCeiling(int assetId)
        {
            if (GetRow(assetId).IsNull("DownCeiling"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DownCeiling"];
            }
        }



        /// <summary>
        /// GetDownCeiling Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original DownCeiling or EMPTY</returns>
        public string GetDownCeilingOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["DownCeiling"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DownCeiling", DataRowVersion.Original];
            }
        }


        
        /// <summary>
        /// GetDownBenching. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DownBenching or EMPTY</returns>
        public string GetDownBenching(int assetId)
        {
            if (GetRow(assetId).IsNull("DownBenching"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DownBenching"];
            }
        }



        /// <summary>
        /// GetDownBenching Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original DownBenching or EMPTY</returns>
        public string GetDownBenchingOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["DownBenching"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DownBenching", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRectangle1LongSide. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Rectangle1LongSide or EMPTY</returns>
        public string GetRectangle1LongSide(int assetId)
        {
            if (GetRow(assetId).IsNull("Rectangle1LongSide"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Rectangle1LongSide"];
            }
        }



        /// <summary>
        /// GetRectangle1LongSide Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original Rectangle1LongSide or EMPTY</returns>
        public string GetRectangle1LongSideOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["Rectangle1LongSide"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Rectangle1LongSide", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRectangle1ShortSide. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Rectangle1ShortSide or EMPTY</returns>
        public string GetRectangle1ShortSide(int assetId)
        {
            if (GetRow(assetId).IsNull("Rectangle1ShortSide"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Rectangle1ShortSide"];
            }
        }



        /// <summary>
        /// GetRectangle1ShortSide Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original Rectangle1ShortSide or EMPTY</returns>
        public string GetRectangle1ShortSideOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["Rectangle1ShortSide"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Rectangle1ShortSide", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRectangle2LongSide. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Rectangle2LongSide or EMPTY</returns>
        public string GetRectangle2LongSide(int assetId)
        {
            if (GetRow(assetId).IsNull("Rectangle2LongSide"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Rectangle2LongSide"];
            }
        }



        /// <summary>
        /// GetRectangle2LongSide Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original Rectangle2LongSide or EMPTY</returns>
        public string GetRectangle2LongSideOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["Rectangle2LongSide"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Rectangle2LongSide", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRectangle2ShortSide. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Rectangle2ShortSide or EMPTY</returns>
        public string GetRectangle2ShortSide(int assetId)
        {
            if (GetRow(assetId).IsNull("Rectangle2ShortSide"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Rectangle2ShortSide"];
            }
        }



        /// <summary>
        /// GetRectangle2ShortSide Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original Rectangle2ShortSide or EMPTY</returns>
        public string GetRectangle2ShortSideOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["Rectangle2ShortSide"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["Rectangle2ShortSide", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTopSurfaceArea. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>TopSurfaceArea or EMPTY</returns>
        public string GetTopSurfaceArea(int assetId)
        {
            if (GetRow(assetId).IsNull("TopSurfaceArea"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["TopSurfaceArea"];
            }
        }



        /// <summary>
        /// GetTopSurfaceArea Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original TopSurfaceArea or EMPTY</returns>
        public string GetTopSurfaceAreaOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["TopSurfaceArea"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["TopSurfaceArea", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDownSurfaceArea. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>DownSurfaceArea or EMPTY</returns>
        public string GetDownSurfaceArea(int assetId)
        {
            if (GetRow(assetId).IsNull("DownSurfaceArea"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DownSurfaceArea"];
            }
        }



        /// <summary>
        /// GetDownSurfaceArea Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original DownSurfaceArea or EMPTY</returns>
        public string GetDownSurfaceAreaOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["DownSurfaceArea"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["DownSurfaceArea", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetManholeRugs. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>ManholeRugs or EMPTY</returns>
        public int? GetManholeRugs(int assetId)
        {
            if (GetRow(assetId).IsNull("ManholeRugs"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(assetId)["ManholeRugs"];
            }
        }



        /// <summary>
        /// GetManholeRugs Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original ManholeRugs or EMPTY</returns>
        public int? GetManholeRugsOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["ManholeRugs"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(assetId)["ManholeRugs", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTotalDepth. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>TotalDepth or EMPTY</returns>
        public string GetTotalDepth(int assetId)
        {
            if (GetRow(assetId).IsNull("TotalDepth"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["TotalDepth"];
            }
        }



        /// <summary>
        /// GetTotalDepth Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original TotalDepth or EMPTY</returns>
        public string GetTotalDepthOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["TotalDepth"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["TotalDepth", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTotalSurfaceArea. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>TotalSurfaceArea or EMPTY</returns>
        public string GetTotalSurfaceArea(int assetId)
        {
            if (GetRow(assetId).IsNull("TotalSurfaceArea"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["TotalSurfaceArea"];
            }
        }



        /// <summary>
        /// GetTotalSurfaceArea Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original TotalSurfaceArea or EMPTY</returns>
        public string GetTotalSurfaceAreaOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["TotalSurfaceArea"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["TotalSurfaceArea", DataRowVersion.Original];
            }
        }




        /// <summary>
        /// GetConditionRating. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>ConditionRating or EMPTY</returns>
        public int? GetConditionRating(int assetId)
        {
            if (GetRow(assetId).IsNull("ConditionRating"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(assetId)["ConditionRating"];
            }
        }



        /// <summary>
        /// GetConditionRating Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original ConditionRating or EMPTY</returns>
        public int? GetConditionRatingOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["ConditionRating"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(assetId)["ConditionRating", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMaterialDescription. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>MaterialDescription or EMPTY</returns>
        public string GetMaterialDescription(int assetId)
        {
            if (GetRow(assetId).IsNull("MaterialDescription"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["MaterialDescription"];
            }
        }



        /// <summary>
        /// GetMaterialDescription Original
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Original MaterialDescription or EMPTY</returns>
        public string GetMaterialDescriptionOriginal(int assetId)
        {
            if (GetRow(assetId).IsNull(Table.Columns["MaterialDescription"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(assetId)["MaterialDescription", DataRowVersion.Original];
            }
        }

    }
}
