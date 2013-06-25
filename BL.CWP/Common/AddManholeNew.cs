using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.DA.Assets.Assets;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// AddManholeNew
    /// </summary>
    public  class AddManholeNew: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AddManholeNew()
            : base("AddManholeNew")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AddManholeNew(DataSet data)
            : base(data, "AddManholeNew")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new AddManholeTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a manhole
        /// </summary>
        /// <param name="mhId">mhId</param>
        /// <param name="longitude">longitude</param>
        /// <param name="latitude">latitude</param>
        /// <param name="address">address</param>
        /// <param name="shape">shape>
        /// <param name="manholeShape">manholeShape</param>
        /// <param name="location">location</param>
        /// <param name="materialId">materialId</param>
        /// <param name="topDiameter">topDiameter</param>
        /// <param name="topDepth">topDepth</param>
        /// <param name="topFloor">topFloor</param>
        /// <param name="topCeiling">topCeiling</param>
        /// <param name="topBenching">topBenching</param>
        /// <param name="downDiameter">downDiameter</param>
        /// <param name="downDepth">downDepth</param>
        /// <param name="downFloor">downFloor</param>
        /// <param name="downCeiling">downCeiling</param>
        /// <param name="downBenching">downBenching</param>
        /// <param name="rectangle1LongSide">rectangle1LongSide</param>
        /// <param name="rectangle1ShortSide">rectangle1ShortSide</param>
        /// <param name="rectangle2LongSide">rectangle2LongSide</param>
        /// <param name="rectangle2ShortSide">rectangle2ShortSide</param>
        /// <param name="topSurfaceArea">topSurfaceArea</param>
        /// <param name="downSurfaceArea">downSurfaceArea</param>
        /// <param name="manholeRugs">manholeRugs</param>
        /// <param name="totalDepth">totalDepth</param>
        /// <param name="totalSurfaceArea">totalSurfaceArea</param>
        /// <param name="conditionRating">conditionRating</param>
        /// <param name="materialDescription">materialDescription</param>    
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(string mhId, string longitude, string latitude, string address, string manholeShape, string location, int? materialId, string topDiameter, string topDepth, string topFloor, string topCeiling, string topBenching, string downDiameter, string downDepth, string downFloor, string downCeiling, string downBenching, string rectangle1LongSide, string rectangle1ShortSide, string rectangle2LongSide, string rectangle2ShortSide, string topSurfaceArea, string downSurfaceArea, int? manholeRugs, string totalDepth, string totalSurfaceArea, int? conditionRating, string materialDescription, bool deleted, int companyId)
        {
            AddManholeTDS.AddManholeNewRow row = ((AddManholeTDS.AddManholeNewDataTable)Table).NewAddManholeNewRow();

            row.AssetID = GetNewId();
            row.MHID = mhId;
            row.Longitude = ""; if (longitude != "") row.Longitude = longitude;
            row.Latitud = ""; if (latitude != "") row.Latitud = latitude;
            row.Address = ""; if (address != "") row.Address = address; 
            row.ManholeShape = "";  if (manholeShape != "") row.ManholeShape = manholeShape;
            row.Location = ""; if (location != "") row.Location = location; 
            if (materialId != -1)
            {
                row.MaterialID = (int)materialId;
                row.MaterialDescription = materialDescription;
            }
            else
            {
                row.SetMaterialIDNull();
                row.MaterialDescription = "";
            }
            row.TopDiameter = "";  if (topDiameter != "") row.TopDiameter = topDiameter; 
            row.TopDepth = ""; if (topDepth != "") row.TopDepth = topDepth; 
            row.TopFloor = ""; if (topFloor != "") row.TopFloor = topFloor; 
            row.TopCeiling = ""; if (topCeiling != "") row.TopCeiling = topCeiling;
            row.TopBenching = ""; if (topBenching != "") row.TopBenching = topBenching;
            row.DownDiameter = ""; if (downDiameter != "") row.DownDiameter = downDiameter; 
            row.DownDepth = "";if (downDepth != "") row.DownDepth = downDepth;
            row.DownFloor = ""; if (downFloor != "") row.DownFloor = downFloor; 
            row.DownCeiling = ""; if (downCeiling != "") row.DownCeiling = downCeiling; 
            row.DownBenching = ""; if (downBenching != "") row.DownBenching = downBenching; 
            row.Rectangle1LongSide = "";  if (rectangle1LongSide != "") row.Rectangle1LongSide = rectangle1LongSide; 
            row.Rectangle1ShortSide = ""; if (rectangle1ShortSide != "") row.Rectangle1ShortSide = rectangle1ShortSide; 
            row.Rectangle2LongSide = ""; if (rectangle2LongSide != "") row.Rectangle2LongSide = rectangle2LongSide; 
            row.Rectangle2ShortSide = "";  if (rectangle2ShortSide != "") row.Rectangle2ShortSide = rectangle2ShortSide; 
            row.TopSurfaceArea = "";  if (topSurfaceArea != "") row.TopSurfaceArea = topSurfaceArea; 
            row.DownSurfaceArea = ""; if (downSurfaceArea != "") row.DownSurfaceArea = downSurfaceArea;
            if (manholeRugs.HasValue) row.ManholeRugs = (int)manholeRugs; else row.SetManholeRugsNull();
            row.TotalDepth = ""; if (totalDepth != "") row.TotalDepth = totalDepth; 
            row.TotalSurfaceArea = "";  if (totalSurfaceArea != "") row.TotalSurfaceArea = totalSurfaceArea;
            if (conditionRating.HasValue) row.ConditionRating = (int)conditionRating; else row.SetConditionRatingNull();
            row.InDatabase = false;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;

            ((AddManholeTDS.AddManholeNewDataTable)Table).AddAddManholeNewRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="assetId">assetId</param>
         /// <param name="longitud">longitud</param>
        /// <param name="latitude">latitude</param>        
        /// <param name="address">address</param>
        /// <param name="manholeShape">manholeShape</param>
        /// <param name="location">location</param>
        /// <param name="materialId">materialId</param>
        /// <param name="topDiameter">topDiameter</param>
        /// <param name="topDepth">topDepth</param>
        /// <param name="topFloor">topFloor</param>
        /// <param name="topCeiling">topCeiling</param>
        /// <param name="topBenching">topBenching</param>
        /// <param name="downDiameter">downDiameter</param>
        /// <param name="downDepth">downDepth</param>
        /// <param name="downFloor">downFloor</param>
        /// <param name="downCeiling">downCeiling</param>
        /// <param name="downBenching">downBenching</param>
        /// <param name="rectangle1LongSide">rectangle1LongSide</param>
        /// <param name="rectangle1ShortSide">rectangle1ShortSide</param>
        /// <param name="rectangle2LongSide">rectangle2LongSide</param>
        /// <param name="rectangle2ShortSide">rectangle2ShortSide</param>
        /// <param name="topSurfaceArea">topSurfaceArea</param>
        /// <param name="downSurfaceArea">downSurfaceArea</param>
        /// <param name="manholeRugs">manholeRugs</param>
        /// <param name="totalDepth">totalDepth</param>
        /// <param name="totalSurfaceArea">totalSurfaceArea</param>
        /// <param name="conditionRating">conditionRating</param>
        /// <param name="materialDescription">materialDescription</param>  
        public void Update(int assetId, string longitud, string latitude, string address, string manholeShape, string location, int? materialId, string topDiameter, string topDepth, string topFloor, string topCeiling, string topBenching, string downDiameter, string downDepth, string downFloor, string downCeiling, string downBenching, string rectangle1LongSide, string rectangle1ShortSide, string rectangle2LongSide, string rectangle2ShortSide, string topSurfaceArea, string downSurfaceArea, int? manholeRugs, string totalDepth, string totalSurfaceArea, int? conditionRating, string materialDescription)
        {
            AddManholeTDS.AddManholeNewRow row = GetRow(assetId);

            row.Longitude = ""; if (longitud != "") row.Longitude = longitud;
            row.Latitud = ""; if (latitude != "") row.Latitud = latitude;
            row.Address = ""; if (address != "") row.Address = address;
            row.ManholeShape = ""; if (manholeShape != "") row.ManholeShape = manholeShape;
            row.Location = ""; if (location != "") row.Location = location;
            if (materialId != -1)
            {
                row.MaterialID = (int)materialId;
                row.MaterialDescription = materialDescription;
            }
            else
            {
                row.SetMaterialIDNull();
                row.MaterialDescription = "";
            }
            row.TopDiameter = ""; if (topDiameter != "") row.TopDiameter = topDiameter;
            row.TopDepth = ""; if (topDepth != "") row.TopDepth = topDepth;
            row.TopFloor = ""; if (topFloor != "") row.TopFloor = topFloor;
            row.TopCeiling = ""; if (topCeiling != "") row.TopCeiling = topCeiling;
            row.TopBenching = ""; if (topBenching != "") row.TopBenching = topBenching;
            row.DownDiameter = ""; if (downDiameter != "") row.DownDiameter = downDiameter;
            row.DownDepth = ""; if (downDepth != "") row.DownDepth = downDepth;
            row.DownFloor = ""; if (downFloor != "") row.DownFloor = downFloor;
            row.DownCeiling = ""; if (downCeiling != "") row.DownCeiling = downCeiling;
            row.DownBenching = ""; if (downBenching != "") row.DownBenching = downBenching;
            row.Rectangle1LongSide = ""; if (rectangle1LongSide != "") row.Rectangle1LongSide = rectangle1LongSide;
            row.Rectangle1ShortSide = ""; if (rectangle1ShortSide != "") row.Rectangle1ShortSide = rectangle1ShortSide;
            row.Rectangle2LongSide = ""; if (rectangle2LongSide != "") row.Rectangle2LongSide = rectangle2LongSide;
            row.Rectangle2ShortSide = ""; if (rectangle2ShortSide != "") row.Rectangle2ShortSide = rectangle2ShortSide;
            row.TopSurfaceArea = ""; if (topSurfaceArea != "") row.TopSurfaceArea = topSurfaceArea;
            row.DownSurfaceArea = ""; if (downSurfaceArea != "") row.DownSurfaceArea = downSurfaceArea;
            if (manholeRugs.HasValue) row.ManholeRugs = (int)manholeRugs; else row.SetManholeRugsNull();
            row.TotalDepth = ""; if (totalDepth != "") row.TotalDepth = totalDepth;
            row.TotalSurfaceArea = ""; if (totalSurfaceArea != "") row.TotalSurfaceArea = totalSurfaceArea;
            if (conditionRating.HasValue) row.ConditionRating = (int)conditionRating; else row.SetConditionRatingNull();
        }



        /// <summary>
        /// Delete a manhole
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int assetId, int companyId)
        {
            AddManholeTDS.AddManholeNewRow row = GetRow(assetId);

            if (row.COMPANY_ID == companyId)
            {
                row.Deleted = true;
            }
        }



        /// <summary>
        /// Save all manhole to database (direct)
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="companyId">companyId</param>        
        public void Save(Int64? countryId, Int64?  provinceId, Int64? countyId, Int64? cityId, int companyId, int projectId)
        {
            AddManholeTDS mrManholesAddChanges = (AddManholeTDS)Data.GetChanges();

            if (mrManholesAddChanges.AddManholeNew.Rows.Count > 0)
            {
                AddManholeNewGateway addManholeNewGateway = new AddManholeNewGateway(mrManholesAddChanges);

                foreach (AddManholeTDS.AddManholeNewRow row in (AddManholeTDS.AddManholeNewDataTable)mrManholesAddChanges.AddManholeNew)
                {
                    // Insert new manhole 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        // ... Insert manhole
                        int? manholeRugs = null; if (!row.IsManholeRugsNull()) manholeRugs = row.ManholeRugs;                        
                        int? conditionRating = null; if (!row.IsConditionRatingNull()) conditionRating = row.ConditionRating;
                        int? materialId = null; if (!row.IsMaterialIDNull()) materialId = row.MaterialID;
                        
                        LfsAssetSewerMH lfsAssetSewerMH = new LfsAssetSewerMH();

                        int assetId = lfsAssetSewerMH.InsertDirect(countryId, provinceId, countyId, cityId, row.MHID, row.Latitud, row.Longitude, row.Address, row.Deleted, companyId, row.ManholeShape, row.Location, materialId, row.TopDiameter, row.TopDepth, row.TopFloor, row.TopCeiling, row.TopBenching, row.DownDiameter, row.DownDepth, row.DownFloor, row.DownCeiling, row.DownBenching, row.Rectangle1LongSide, row.Rectangle1ShortSide, row.Rectangle2LongSide, row.Rectangle2ShortSide, row.TopSurfaceArea, row.DownSurfaceArea, manholeRugs, row.TotalDepth, row.TotalSurfaceArea, conditionRating);

                        // insert in LFS tables (only if not exists)
                        AssetSewerMHGateway assetSewerMHGateway = new AssetSewerMHGateway();

                        if (!assetSewerMHGateway.IsUsedInMHProject(projectId, assetId))
                        {
                            AssetSewerMHGateway assetSewerMhGateway = new AssetSewerMHGateway(null);
                            assetSewerMhGateway.InsertMHProject(assetId, projectId, DateTime.Now, false, companyId);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// GetSummary
        /// </summary>
        /// <returns>Summary</returns>
        public string GetSummary()
        {
            string summary = "";
            foreach (AddManholeTDS.AddManholeNewRow row in (AddManholeTDS.AddManholeNewDataTable)Table)
            {
                summary = summary + "Asset: " + row.MHID;
                if (!row.IsAddressNull()) summary = summary + ", Street: " + row.Address;
                if (!row.IsLatitudNull()) summary = summary + ", Latitude: " + row.Latitud;
                if (!row.IsLongitudeNull()) summary = summary + ", Longitude: " + row.Longitude;
                if (!row.IsManholeShapeNull()) summary = summary + ", Shape: " + row.ManholeShape;
                if (!row.IsLocationNull()) summary = summary + ", Location: " + row.Location;
                if (!row.IsConditionRatingNull()) summary = summary + ", Condition Rating: " + row.ConditionRating.ToString();
                if (!row.IsMaterialDescriptionNull()) summary = summary + ", Material: " + row.MaterialDescription + "\n\n";               
            }

            return summary;
        }
            






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single section. If not exists, raise an exception
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>Row</returns>
        private AddManholeTDS.AddManholeNewRow GetRow(int assetId)
        {
            AddManholeTDS.AddManholeNewRow row = ((AddManholeTDS.AddManholeNewDataTable)Table).FindByAssetID(assetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Common.AddManholeNew.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewId
        /// </summary>
        /// <returns>AssetID</returns>
        private int GetNewId()
        {
            int newId = 0;

            foreach (AddManholeTDS.AddManholeNewRow row in (AddManholeTDS.AddManholeNewDataTable)Table)
            {
                if (newId < row.AssetID)
                {
                    newId = row.AssetID;
                }
            }

            newId++;

            return newId;
        }


                
    }
}
