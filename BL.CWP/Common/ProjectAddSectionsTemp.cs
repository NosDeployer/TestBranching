using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// ProjectAddSectionsTemp
    /// </summary>
    public class ProjectAddSectionsTemp : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectAddSectionsTemp() : base("ProjectAddSectionsTemp")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectAddSectionsTemp(DataSet data) : base(data, "ProjectAddSectionsTemp")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectAddSectionsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a selected or added section
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="street">street</param>
        /// <param name="usmh">usmh</param>
        /// <param name="dsmh">dsmh</param>
        /// <param name="rehabAssessmentWork">rehabAssessmentWork</param>
        /// <param name="fulllengthLiningWork">fulllengthLiningWork</param>
        /// <param name="pointRepairsWork">pointRepairsWork</param>
        /// <param name="junctionLiningWork">junctionLiningWork</param>
        /// <param name="type">type</param>
        /// <param name="selected">selected</param>
        /// <param name="deleted">deleted</param>
        /// <param name="flowOrderId">flowOrderId</param>
        /// <param name="mapSize">mapSize</param>
        /// <param name="mapLength">mapLength</param>
        /// <param name="rehabAssessmetPrevWork">rehabAssessmetPrevWork</param>
        /// <param name="fullLengthLiningPrevWork">fullLengthLiningPrevWork</param>
        /// <param name="pointRepairsPrevWork">pointRepairsPrevWork</param>
        /// <param name="junctionLiningPrevWork">junctionLiningPrevWork</param>
        /// 
        /// <param name="usmhStreet">usmhStreet</param>
        /// <param name="usmhLatitude">usmhLatitude</param>
        /// <param name="usmhLongitude">usmhLongitude</param>
        /// <param name="usmhShape">usmhShape</param>
        /// <param name="usmhLocation">usmhLocation</param>
        /// <param name="usmhConditionRating">usmhConditionRating</param>
        /// <param name="usmhMaterialId">usmhMaterialId</param>
        /// <param name="usmhTopDiameter">usmhTopDiameter</param>
        /// <param name="usmhTopDepth">usmhTopDepth</param>
        /// <param name="usmhDownDiameter">usmhDownDiameter</param>
        /// <param name="usmhDownDepth">usmhDownDepth</param>
        /// <param name="usmhManholeRugs">usmhManholeRugs</param>
        /// <param name="usmhRectangle1LongSide">usmhRectangle1LongSide</param>
        /// <param name="usmhRectangle1ShortSide">usmhRectangle1ShortSide</param>
        /// <param name="usmhRectangle2LongSide">usmhRectangle2LongSide</param>
        /// <param name="usmhRectangle2ShortSide">usmhRectangle2ShortSide</param>
        /// <param name="usmhTotalSurfaceArea">usmhTotalSurfaceArea</param>
        /// 
        /// <param name="dsmhStreet">dsmhStreet</param>
        /// <param name="dsmhLatitude">dsmhLatitude</param>
        /// <param name="dsmhLongitude">dsmhLongitude</param>
        /// <param name="dsmhShape">dsmhShape</param>
        /// <param name="dsmhLocation">dsmhLocation</param>
        /// <param name="dsmhConditionRating">dsmhConditionRating</param>
        /// <param name="dsmhMaterialId">dsmhMaterialId</param>
        /// <param name="dsmhTopDiameter">dsmhTopDiameter</param>
        /// <param name="dsmhTopDepth">dsmhTopDepth</param>
        /// <param name="dsmhDownDiameter">dsmhDownDiameter</param>
        /// <param name="dsmhDownDepth">dsmhDownDepth</param>
        /// <param name="dsmhManholeRugs">dsmhManholeRugs</param>
        /// <param name="dsmhRectangle1LongSide">dsmhRectangle1LongSide</param>
        /// <param name="dsmhRectangle1ShortSide">dsmhRectangle1ShortSide</param>
        /// <param name="dsmhRectangle2LongSide">dsmhRectangle2LongSide</param>
        /// <param name="dsmhRectangle2ShortSide">dsmhRectangle2ShortSide</param>
        /// <param name="dsmhTotalSurfaceArea">dsmhTotalSurfaceArea</param>             
        /// <param name="sectionMaterial">sectionMaterial</param>
        /// <param name="clientId">clientId</param>
        public void Insert(int assetId, string sectionId, string street, string usmh, string dsmh, bool rehabAssessmentWork, bool fulllengthLiningWork, bool pointRepairsWork, bool junctionLiningWork, string type, bool selected, bool deleted, string flowOrderId, string mapSize, string mapLength, bool rehabAssessmetPrevWork, bool fullLengthLiningPrevWork, bool pointRepairsPrevWork, bool junctionLiningPrevWork, string usmhStreet, string usmhLatitude, string usmhLongitude, string usmhShape, string usmhLocation, int? usmhConditionRating, int? usmhMaterialId, string usmhTopDiameter, string usmhTopDepth, string usmhDownDiameter, string usmhDownDepth, int? usmhManholeRugs, string usmhRectangle1LongSide, string usmhRectangle1ShortSide, string usmhRectangle2LongSide, string usmhRectangle2ShortSide, string usmhTotalSurfaceArea, string dsmhStreet, string dsmhLatitude, string dsmhLongitude, string dsmhShape, string dsmhLocation, int? dsmhConditionRating, int? dsmhMaterialId, string dsmhTopDiameter, string dsmhTopDepth, string dsmhDownDiameter, string dsmhDownDepth, int? dsmhManholeRugs, string dsmhRectangle1LongSide, string dsmhRectangle1ShortSide, string dsmhRectangle2LongSide, string dsmhRectangle2ShortSide, string dsmhTotalSurfaceArea, string sectionMaterial, string clientId, bool mHRehabUsmh, bool mHRehabDsmh)
        {
            ProjectAddSectionsTDS.ProjectAddSectionsTempRow row = ((ProjectAddSectionsTDS.ProjectAddSectionsTempDataTable)Table).NewProjectAddSectionsTempRow();

            row.ID = GetNewId();
            row.AssetID = assetId;
            row.SectionID = sectionId;
            if (street.Trim() != "") row.Street = street; else row.SetStreetNull();
            if (usmh.Trim() != "") row.USMH = usmh; else row.SetUSMHNull();
            if (dsmh.Trim() != "") row.DSMH = dsmh; else row.SetDSMHNull();
            row.RehabAssessmentWork = rehabAssessmentWork;
            row.FulllengthLiningWork = fulllengthLiningWork;
            row.PointRepairsWork = pointRepairsWork;
            row.JunctionLiningWork = junctionLiningWork;
            row.MHRehabUsmh = mHRehabUsmh;
            row.MHRehabDsmh = mHRehabDsmh;
            row.Type = type;
            row.Selected = selected;
            row.Deleted = deleted;
            row.FlowOrderID = flowOrderId;
            if (mapSize.Trim() != "") row.MapSize = mapSize; else row.SetMapSizeNull();
            if (mapLength.Trim() != "") row.MapLength = mapLength; else row.SetMapLengthNull();
            row.RehabAssessmentPrevWork = rehabAssessmetPrevWork;
            row.FullLengthLiningPrevWork = fullLengthLiningPrevWork;
            row.PointRepairsPrevWork = pointRepairsPrevWork;
            row.JunctionLiningPrevWork = junctionLiningPrevWork;
            if (sectionMaterial.Trim() != "") row.SectionMaterial = sectionMaterial; else row.SetSectionMaterialNull();
            if (clientId.Trim() != "") row.ClientId = clientId; else row.SetClientIdNull();
            
            if (usmhStreet.Trim() != "") row.UsmhStreet = usmhStreet; else row.SetUsmhStreetNull();
            if (usmhLatitude.Trim() != "") row.UsmhLatitude = usmhLatitude; else row.SetUsmhLatitudeNull();
            if (usmhLongitude.Trim() != "") row.UsmhLongitude = usmhLongitude; else row.SetUsmhLongitudeNull();
            if (usmhShape.Trim() != "") row.UsmhShape = usmhShape; else row.SetUsmhShapeNull();
            if (usmhLocation.Trim() != "") row.UsmhLocation = usmhLocation; else row.SetUsmhLocationNull();
            if (usmhConditionRating.HasValue) row.UsmhConditionRating = (int)usmhConditionRating; else row.SetUsmhConditionRatingNull();
            if (usmhMaterialId.HasValue) row.UsmhMaterialId = (int)usmhMaterialId; else row.SetUsmhMaterialIdNull();
            if (usmhTopDiameter.Trim() != "") row.UsmhTopDiameter = usmhTopDiameter; else row.SetUsmhTopDiameterNull();
            if (usmhTopDepth.Trim() != "") row.UsmhTopDepth = usmhTopDepth; else row.SetUsmhTopDepthNull();
            if (usmhDownDiameter.Trim() != "") row.UsmhDownDiameter = usmhDownDiameter; else row.SetUsmhDownDiameterNull();
            if (usmhDownDepth.Trim() != "") row.UsmhDownDepth = usmhDownDepth; else row.SetUsmhDownDepthNull();
            if (usmhManholeRugs.HasValue) row.UsmhManholeRugs = (int)usmhManholeRugs; else row.SetUsmhManholeRugsNull();
            if (usmhRectangle1LongSide.Trim() != "") row.UsmhRectangle1LongSide = usmhRectangle1LongSide; else row.SetUsmhRectangle1LongSideNull();
            if (usmhRectangle1ShortSide.Trim() != "") row.UsmhRectangle1ShortSide = usmhRectangle1ShortSide; else row.SetUsmhRectangle1ShortSideNull();
            if (usmhRectangle2LongSide.Trim() != "") row.UsmhRectangle2LongSide = usmhRectangle2LongSide; else row.SetUsmhRectangle2LongSideNull();
            if (usmhRectangle2ShortSide.Trim() != "") row.UsmhRectangle2ShortSide = usmhRectangle2ShortSide; else row.SetUsmhRectangle2ShortSideNull();
            if (usmhTotalSurfaceArea.Trim() != "") row.UsmhTotalSurfaceArea = usmhTotalSurfaceArea; else row.SetUsmhTotalSurfaceAreaNull();

            if (dsmhStreet.Trim() != "") row.DsmhStreet = dsmhStreet; else row.SetDsmhStreetNull();
            if (dsmhLatitude.Trim() != "") row.DsmhLatitude = dsmhLatitude; else row.SetDsmhLatitudeNull();
            if (dsmhLongitude.Trim() != "") row.DsmhLongitude = dsmhLongitude; else row.SetDsmhLongitudeNull();
            if (dsmhShape.Trim() != "") row.DsmhShape = dsmhShape; else row.SetDsmhShapeNull();
            if (dsmhLocation.Trim() != "") row.DsmhLocation = dsmhLocation; else row.SetDsmhLocationNull();
            if (dsmhConditionRating.HasValue) row.DsmhConditionRating = (int)dsmhConditionRating; else row.SetDsmhConditionRatingNull();
            if (dsmhMaterialId.HasValue) row.DsmhMaterialId = (int)dsmhMaterialId; else row.SetDsmhMaterialIdNull();
            if (dsmhTopDiameter.Trim() != "") row.DsmhTopDiameter = dsmhTopDiameter; else row.SetDsmhTopDiameterNull();
            if (dsmhTopDepth.Trim() != "") row.DsmhTopDepth = dsmhTopDepth; else row.SetDsmhTopDepthNull();
            if (dsmhDownDiameter.Trim() != "") row.DsmhDownDiameter = dsmhDownDiameter; else row.SetDsmhDownDiameterNull();
            if (dsmhDownDepth.Trim() != "") row.DsmhDownDepth = dsmhDownDepth; else row.SetDsmhDownDepthNull();
            if (dsmhManholeRugs.HasValue) row.DsmhManholeRugs = (int)dsmhManholeRugs; else row.SetDsmhManholeRugsNull();
            if (dsmhRectangle1LongSide.Trim() != "") row.DsmhRectangle1LongSide = dsmhRectangle1LongSide; else row.SetDsmhRectangle1LongSideNull();
            if (dsmhRectangle1ShortSide.Trim() != "") row.DsmhRectangle1ShortSide = dsmhRectangle1ShortSide; else row.SetDsmhRectangle1ShortSideNull();
            if (dsmhRectangle2LongSide.Trim() != "") row.DsmhRectangle2LongSide = dsmhRectangle2LongSide; else row.SetDsmhRectangle2LongSideNull();
            if (dsmhRectangle2ShortSide.Trim() != "") row.DsmhRectangle2ShortSide = dsmhRectangle2ShortSide; else row.SetDsmhRectangle2ShortSideNull();
            if (dsmhTotalSurfaceArea.Trim() != "") row.DsmhTotalSurfaceArea = dsmhTotalSurfaceArea; else row.SetDsmhTotalSurfaceAreaNull();
            
            ((ProjectAddSectionsTDS.ProjectAddSectionsTempDataTable)Table).AddProjectAddSectionsTempRow(row);
        }



        /// <summary>
        /// Delete a added or selected section
        /// </summary>
        /// <param name="id">id</param>
        public void Delete(int id)
        {
            ProjectAddSectionsTDS.ProjectAddSectionsTempRow row = GetRow(id);
            
            row.Deleted = true;
        }



        /// <summary>
        /// Process a new section's table 
        /// </summary>
        public void ProcessNew()
        {
            foreach (ProjectAddSectionsTDS.ProjectAddSectionsNewRow rowNew in (ProjectAddSectionsTDS.ProjectAddSectionsNewDataTable)Data.Tables["ProjectAddSectionsNew"])
            {
                if (!rowNew.Deleted)
                {
                    int assetId = 0;
                    string sectionId = rowNew.SectionID;
                    string street = ""; if (!rowNew.IsStreetNull()) street = rowNew.Street;
                    string usmh = ""; if (!rowNew.IsUSMHNull()) usmh = rowNew.USMH;
                    string dsmh = ""; if (!rowNew.IsDSMHNull()) dsmh = rowNew.DSMH;
                    bool raWork = rowNew.RehabAssessmentWork;
                    bool fllWork = rowNew.FulllengthLiningWork;
                    bool prWork = rowNew.PointRepairsWork;
                    bool jlWork = rowNew.JunctionLiningWork;
                    bool deleted = false;
                    string flowOrderId = rowNew.FlowOrderID;
                    string mapSize = ""; if (!rowNew.IsMapSizeNull()) mapSize = rowNew.MapSize;
                    string mapLength = ""; if (!rowNew.IsMapLengthNull()) mapLength = rowNew.MapLength;

                    string sectionMaterial = ""; if (!rowNew.IsSectionMaterialNull()) sectionMaterial = rowNew.SectionMaterial;
                    string clientId = ""; if (!rowNew.IsClientIdNull()) clientId = rowNew.ClientId;

                    string usmhStreet = ""; if (!rowNew.IsUsmhStreetNull()) usmhStreet = rowNew.UsmhStreet;
                    string usmhLatitude = ""; if (!rowNew.IsUsmhLatitudeNull()) usmhLatitude = rowNew.UsmhLatitude;
                    string usmhLongitude = ""; if (!rowNew.IsUsmhLongitudeNull()) usmhLongitude = rowNew.UsmhLongitude;
                    string usmhShape = ""; if (!rowNew.IsUsmhShapeNull()) usmhShape = rowNew.UsmhShape;
                    string usmhLocation = ""; if (!rowNew.IsUsmhLocationNull()) usmhLocation = rowNew.UsmhLocation;
                    int? usmhConditionRating = null; if (!rowNew.IsUsmhConditionRatingNull()) usmhConditionRating = (int)rowNew.UsmhConditionRating;
                    int? usmhMaterialId = null; if (!rowNew.IsUsmhMaterialIdNull()) usmhMaterialId = (int)rowNew.UsmhMaterialId;
                    string usmhTopDiameter = ""; if (!rowNew.IsUsmhTopDiameterNull()) usmhTopDiameter = rowNew.UsmhTopDiameter;
                    string usmhTopDepth = ""; if (!rowNew.IsUsmhTopDepthNull()) usmhTopDepth = rowNew.UsmhTopDepth;
                    string usmhDownDiameter = ""; if (!rowNew.IsUsmhDownDiameterNull()) usmhDownDiameter = rowNew.UsmhDownDiameter;
                    string usmhDownDepth = ""; if (!rowNew.IsUsmhDownDepthNull()) usmhDownDepth = rowNew.UsmhDownDepth;
                    int? usmhManholeRugs = null; if (!rowNew.IsUsmhManholeRugsNull()) usmhManholeRugs = (int)rowNew.UsmhManholeRugs;
                    string usmhRectangle1LongSide = ""; if (!rowNew.IsUsmhRectangle1LongSideNull()) usmhRectangle1LongSide = rowNew.UsmhRectangle1LongSide;
                    string usmhRectangle1ShortSide = ""; if (!rowNew.IsUsmhRectangle1ShortSideNull()) usmhRectangle1ShortSide = rowNew.UsmhRectangle1ShortSide;
                    string usmhRectangle2LongSide = ""; if (!rowNew.IsUsmhRectangle2LongSideNull()) usmhRectangle2LongSide = rowNew.UsmhRectangle2LongSide;
                    string usmhRectangle2ShortSide = ""; if (!rowNew.IsUsmhRectangle2ShortSideNull()) usmhRectangle2ShortSide = rowNew.UsmhRectangle2ShortSide;
                    string usmhTotalSurfaceArea = ""; if (!rowNew.IsUsmhTotalSurfaceAreaNull()) usmhTotalSurfaceArea = rowNew.UsmhTotalSurfaceArea;             
 
                    string dsmhStreet = ""; if (!rowNew.IsDsmhStreetNull()) dsmhStreet = rowNew.DsmhStreet;
                    string dsmhLatitude = ""; if (!rowNew.IsDsmhLatitudeNull()) dsmhLatitude = rowNew.DsmhLatitude;
                    string dsmhLongitude = ""; if (!rowNew.IsDsmhLongitudeNull()) dsmhLongitude = rowNew.DsmhLongitude;
                    string dsmhShape = ""; if (!rowNew.IsDsmhShapeNull()) dsmhShape = rowNew.DsmhShape;
                    string dsmhLocation = ""; if (!rowNew.IsDsmhLocationNull()) dsmhLocation = rowNew.DsmhLocation;
                    int? dsmhConditionRating = null; if (!rowNew.IsDsmhConditionRatingNull()) dsmhConditionRating = (int)rowNew.DsmhConditionRating;
                    int? dsmhMaterialId = null; if (!rowNew.IsDsmhMaterialIdNull()) dsmhMaterialId = (int)rowNew.DsmhMaterialId;
                    string dsmhTopDiameter = ""; if (!rowNew.IsDsmhTopDiameterNull()) dsmhTopDiameter = rowNew.DsmhTopDiameter;
                    string dsmhTopDepth = ""; if (!rowNew.IsDsmhTopDepthNull()) dsmhTopDepth = rowNew.DsmhTopDepth;
                    string dsmhDownDiameter = ""; if (!rowNew.IsDsmhDownDiameterNull()) dsmhDownDiameter = rowNew.DsmhDownDiameter;
                    string dsmhDownDepth = ""; if (!rowNew.IsDsmhDownDepthNull()) dsmhDownDepth = rowNew.DsmhDownDepth;
                    int? dsmhManholeRugs = null; if (!rowNew.IsDsmhManholeRugsNull()) dsmhManholeRugs = (int)rowNew.DsmhManholeRugs;
                    string dsmhRectangle1LongSide = ""; if (!rowNew.IsDsmhRectangle1LongSideNull()) dsmhRectangle1LongSide = rowNew.DsmhRectangle1LongSide;
                    string dsmhRectangle1ShortSide = ""; if (!rowNew.IsDsmhRectangle1ShortSideNull()) dsmhRectangle1ShortSide = rowNew.DsmhRectangle1ShortSide;
                    string dsmhRectangle2LongSide = ""; if (!rowNew.IsDsmhRectangle2LongSideNull()) dsmhRectangle2LongSide = rowNew.DsmhRectangle2LongSide;
                    string dsmhRectangle2ShortSide = ""; if (!rowNew.IsDsmhRectangle2ShortSideNull()) dsmhRectangle2ShortSide = rowNew.DsmhRectangle2ShortSide;
                    string dsmhTotalSurfaceArea = ""; if (!rowNew.IsDsmhTotalSurfaceAreaNull()) dsmhTotalSurfaceArea = rowNew.DsmhTotalSurfaceArea;

                    bool mhRehabUsmh = rowNew.MHRehabUsmh;
                    bool mhRehabDsmh = rowNew.MHRehabDsmh;

                    Insert(assetId, sectionId, street, usmh, dsmh, raWork, fllWork, prWork, jlWork, "New Section", false, deleted, flowOrderId, mapSize, mapLength, false, false, false, false, usmhStreet, usmhLatitude, usmhLongitude, usmhShape, usmhLocation, usmhConditionRating, usmhMaterialId, usmhTopDiameter, usmhTopDepth, usmhDownDiameter, usmhDownDepth, usmhManholeRugs, usmhRectangle1LongSide, usmhRectangle1ShortSide, usmhRectangle2LongSide, usmhRectangle2ShortSide, usmhTotalSurfaceArea, dsmhStreet, dsmhLatitude, dsmhLongitude, dsmhShape, dsmhLocation, dsmhConditionRating, dsmhMaterialId, dsmhTopDiameter, dsmhTopDepth, dsmhDownDiameter, dsmhDownDepth, dsmhManholeRugs, dsmhRectangle1LongSide, dsmhRectangle1ShortSide, dsmhRectangle2LongSide, dsmhRectangle2ShortSide, dsmhTotalSurfaceArea, sectionMaterial, clientId, mhRehabUsmh, mhRehabDsmh);
                }
            }
        }



        /// <summary>
        /// Process a search & selected section's table
        /// </summary>
        public void ProcessSearch()
        {
            foreach (ProjectAddSectionsTDS.ProjectAddSectionsSearchRow rowSearch in (ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable)Data.Tables["ProjectAddSectionsSearch"])
            {
                if ((!rowSearch.Deleted) && (rowSearch.Selected) && (!ExistsBySectionId(rowSearch.SectionID)))
                {
                    int assetId = rowSearch.AssetID;
                    string sectionId = rowSearch.SectionID;
                    string street = ""; if (!rowSearch.IsStreetNull()) street = rowSearch.Street;
                    string usmh = ""; if (!rowSearch.IsUSMHNull()) usmh = rowSearch.USMH;
                    string dsmh = ""; if (!rowSearch.IsDSMHNull()) dsmh = rowSearch.DSMH;
                    bool raWork = rowSearch.RehabAssessmentWork;
                    bool fllWork = rowSearch.FulllengthLiningWork;
                    bool prWork = rowSearch.PointRepairsWork;
                    bool jlWork = rowSearch.JunctionLiningWork;
                    bool deleted = false;
                    string flowOrderId = rowSearch.FlowOrderID;
                    string mapSize = ""; if (!rowSearch.IsMapSizeNull()) mapSize = rowSearch.MapSize;
                    string mapLength = ""; if (!rowSearch.IsMapLengthNull()) mapLength = rowSearch.MapLength;
                    bool rehabAssessmentPrevWork = rowSearch.RehabAssessmentPrevWork;
                    bool fullLengthLiningPrevWork = rowSearch.FullLengthLiningPrevWork;
                    bool pointRepairsPrevWork = rowSearch.PointRepairsPrevWork;
                    bool junctionLiningPrevWork = rowSearch.JunctionLiningPrevWork;

                    string sectionMaterial = "";
                    string clientId = "";
                    string usmhStreet = ""; 
                    string usmhLatitude = ""; 
                    string usmhLongitude = ""; 
                    string usmhShape = ""; 
                    string usmhLocation = ""; 
                    int? usmhConditionRating = null; 
                    int? usmhMaterialId = null;
                    string usmhTopDiameter = ""; 
                    string usmhTopDepth = "";
                    string usmhDownDiameter = ""; 
                    string usmhDownDepth = ""; 
                    int? usmhManholeRugs = null; 
                    string usmhRectangle1LongSide = ""; 
                    string usmhRectangle1ShortSide = "";
                    string usmhRectangle2LongSide = ""; 
                    string usmhRectangle2ShortSide = "";
                    string usmhTotalSurfaceArea = "";

                    string dsmhStreet = ""; 
                    string dsmhLatitude = ""; 
                    string dsmhLongitude = "";
                    string dsmhShape = ""; 
                    string dsmhLocation = "";
                    int? dsmhConditionRating = null; 
                    int? dsmhMaterialId = null; 
                    string dsmhTopDiameter = ""; 
                    string dsmhTopDepth = ""; 
                    string dsmhDownDiameter = ""; 
                    string dsmhDownDepth = ""; 
                    int? dsmhManholeRugs = null;
                    string dsmhRectangle1LongSide = ""; 
                    string dsmhRectangle1ShortSide = ""; 
                    string dsmhRectangle2LongSide = ""; 
                    string dsmhRectangle2ShortSide = "";
                    string dsmhTotalSurfaceArea = "";

                    bool mhRehabUsmh = false;
                    bool mhRehabDsmh = false;

                    Insert(assetId, sectionId, street, usmh, dsmh, raWork, fllWork, prWork, jlWork, "Existing Section", false, deleted, flowOrderId, mapSize, mapLength, rehabAssessmentPrevWork, fullLengthLiningPrevWork, pointRepairsPrevWork, junctionLiningPrevWork, usmhStreet, usmhLatitude, usmhLongitude, usmhShape, usmhLocation, usmhConditionRating, usmhMaterialId, usmhTopDiameter, usmhTopDepth, usmhDownDiameter, usmhDownDepth, usmhManholeRugs, usmhRectangle1LongSide, usmhRectangle1ShortSide, usmhRectangle2LongSide, usmhRectangle2ShortSide, usmhTotalSurfaceArea, dsmhStreet, dsmhLatitude, dsmhLongitude, dsmhShape, dsmhLocation, dsmhConditionRating, dsmhMaterialId, dsmhTopDiameter, dsmhTopDepth, dsmhDownDiameter, dsmhDownDepth, dsmhManholeRugs, dsmhRectangle1LongSide, dsmhRectangle1ShortSide, dsmhRectangle2LongSide, dsmhRectangle2ShortSide, dsmhTotalSurfaceArea, sectionMaterial, clientId, mhRehabUsmh, mhRehabDsmh);
                }
            }
        }



        /// <summary>
        /// Save all sections & works to database (direct)
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="companyId">companyId</param>
        public void Save(int projectId, Int64 countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int companyId)
        {
            foreach (ProjectAddSectionsTDS.ProjectAddSectionsTempRow row in (ProjectAddSectionsTDS.ProjectAddSectionsTempDataTable)Table)
            {
                if (!row.Deleted)
                {
                    // Save section
                    int section_assetId = SaveSection(row, projectId, countryId, provinceId, countyId, cityId, companyId);

                    // Save work
                    if (row.RehabAssessmentWork)
                    {                        
                        SaveRAWork(projectId, section_assetId, companyId, row.RehabAssessmentPrevWork, row.FullLengthLiningPrevWork, row.PointRepairsPrevWork, row.JunctionLiningPrevWork, row.RehabAssessmentWork, row.FulllengthLiningWork, row.PointRepairsWork, row.JunctionLiningWork);
                    }

                    if (row.FulllengthLiningWork)
                    {
                        string clientId = ""; if (!row.IsClientIdNull()) clientId = row.ClientId;
                        SaveFLLWork(projectId, section_assetId, companyId, row.RehabAssessmentPrevWork, row.FullLengthLiningPrevWork, row.PointRepairsPrevWork, row.JunctionLiningPrevWork, row.RehabAssessmentWork, row.FulllengthLiningWork, row.PointRepairsWork, row.JunctionLiningWork, clientId);
                    }

                    if (row.PointRepairsWork)
                    {
                        string clientId = ""; if (!row.IsClientIdNull()) clientId = row.ClientId;
                        SavePRWork(projectId, section_assetId, companyId, row.RehabAssessmentPrevWork, row.FullLengthLiningPrevWork, row.PointRepairsPrevWork, row.JunctionLiningPrevWork, row.RehabAssessmentWork, row.FulllengthLiningWork, row.PointRepairsWork, row.JunctionLiningWork, clientId);
                    }

                    if (row.JunctionLiningWork)
                    {
                        SaveJLWork(projectId, section_assetId, companyId, row.RehabAssessmentPrevWork, row.FullLengthLiningPrevWork, row.PointRepairsPrevWork, row.JunctionLiningPrevWork, row.RehabAssessmentWork, row.FulllengthLiningWork, row.PointRepairsWork, row.JunctionLiningWork);
                    }                    
                }
            }
        }



        /// <summary>
        /// Return a text with all sections for saved in a database
        /// </summary>
        /// <param name="workType">workType</param>
        /// <returns>sectionsSummary</returns>
        public string GetSectionsSummary(string workType)
        {
            string sectionsSummary = "";

            foreach (ProjectAddSectionsTDS.ProjectAddSectionsTempRow row in (ProjectAddSectionsTDS.ProjectAddSectionsTempDataTable)Table)
            {
                string street = "(empty)"; if (!row.IsStreetNull()) street = row.Street.Trim();
                string usmh = "(empty)"; if (!row.IsUSMHNull()) usmh = row.USMH.Trim();
                string dsmh = "(empty)"; if (!row.IsDSMHNull()) dsmh = row.DSMH.Trim(); ;
                string mapSize = "(empty)"; if (!row.IsMapSizeNull()) mapSize = row.MapSize.Trim();
                string mapLength = "(empty)"; if (!row.IsMapLengthNull()) mapLength = row.MapLength.Trim();
                string sectionMaterial = "(empty)"; if (!row.IsSectionMaterialNull()) sectionMaterial = row.SectionMaterial.Trim();
                string clientId = "(empty)"; if (!row.IsClientIdNull()) clientId = row.ClientId;

                // Data
                if (!row.Deleted)
                {
                    // Validate flowOrder
                    string flowOrderId = "(empty)";
                    if (row.FlowOrderID.Length >= 6)
                    {
                        flowOrderId = row.FlowOrderID.Trim();
                    }

                    // Show Data
                    sectionsSummary = sectionsSummary + "- " + flowOrderId + ", " + street + ", " + usmh + ", " + dsmh + ", " + mapSize + ", " + mapLength + ", " + sectionMaterial + ", " + clientId + " (" + row.Type.Trim();

                    if ((row.RehabAssessmentPrevWork) || (row.FullLengthLiningPrevWork) || (row.PointRepairsPrevWork) || (row.JunctionLiningPrevWork))
                    {
                        sectionsSummary = sectionsSummary + "/Copy previous works (";
                        if (row.RehabAssessmentPrevWork) sectionsSummary = sectionsSummary + "RA, ";
                        if (row.FullLengthLiningPrevWork) sectionsSummary = sectionsSummary + "FLL, ";
                        if (row.PointRepairsPrevWork) sectionsSummary = sectionsSummary + "PR, ";
                        if (row.JunctionLiningPrevWork) sectionsSummary = sectionsSummary + "JL, ";

                        sectionsSummary = sectionsSummary.Substring(0, sectionsSummary.Length - 2) + ")";
                    }
                    sectionsSummary = sectionsSummary +  ")\n"; 
                }
            }
            return sectionsSummary;
        }



        /// <summary>
        /// ExistsBySectionId
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <returns>True if the section exists, otherwise false</returns>
        public bool ExistsBySectionId(string sectionId)
        {
            string filter = string.Format("(SectionID = '{0}') AND (Deleted = 0)", sectionId);

            if (Table.Select(filter).Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //


        /// <summary>
        /// Get a single section. If not exists, raise an exception
        /// </summary>
        /// <param name="id">assetId</param>
        /// <returns>Row</returns>
        private ProjectAddSectionsTDS.ProjectAddSectionsTempRow GetRow(int id)
        {
            ProjectAddSectionsTDS.ProjectAddSectionsTempRow row = ((ProjectAddSectionsTDS.ProjectAddSectionsTempDataTable)Table).FindByID(id);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Common.ProjectAddSectionsTemp.GetRow");
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

            foreach (ProjectAddSectionsTDS.ProjectAddSectionsTempRow row in (ProjectAddSectionsTDS.ProjectAddSectionsTempDataTable)Table)
            {
                if (newId < row.ID)
                {
                    newId = row.ID;
                }
            }

            newId++;

            return newId;
        }



        /// <summary>
        /// Save a section
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="projectId">projectId</param>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>section_assetId</returns>
        private int SaveSection(ProjectAddSectionsTDS.ProjectAddSectionsTempRow row, int projectId, Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int companyId)
        {
            string street = ""; if (!row.IsStreetNull()) street = row.Street;
            string usmh = ""; if (!row.IsUSMHNull()) usmh = row.USMH;
            string dsmh = ""; if (!row.IsDSMHNull()) dsmh = row.DSMH;
            
            string usmhStreet = ""; if (!row.IsUsmhStreetNull()) usmhStreet = row.UsmhStreet;
            string usmhLatitude = ""; if (!row.IsUsmhLatitudeNull()) usmhLatitude = row.UsmhLatitude;
            string usmhLongitude = ""; if (!row.IsUsmhLongitudeNull()) usmhLongitude = row.UsmhLongitude;
            string usmhShape = ""; if (!row.IsUsmhShapeNull()) usmhShape = row.UsmhShape;
            string usmhLocation = ""; if (!row.IsUsmhLocationNull()) usmhLocation = row.UsmhLocation;
            int? usmhConditionRating = null; if (!row.IsUsmhConditionRatingNull()) usmhConditionRating = row.UsmhConditionRating;
            int? usmhMaterialId = null; if (!row.IsUsmhMaterialIdNull()) usmhMaterialId = row.UsmhMaterialId;
            string usmhTopDiameter = ""; if (!row.IsUsmhTopDiameterNull()) usmhTopDiameter = row.UsmhTopDiameter;
            string usmhTopDepth = ""; if (!row.IsUsmhTopDepthNull()) usmhTopDepth = row.UsmhTopDepth;
            string usmhDownDiameter = ""; if (!row.IsUsmhDownDiameterNull()) usmhDownDiameter = row.UsmhDownDiameter;
            string usmhDownDepth = ""; if (!row.IsUsmhDownDepthNull()) usmhDownDepth = row.UsmhDownDepth;
            int? usmhManholeRugs = null; if (!row.IsUsmhManholeRugsNull()) usmhManholeRugs = row.UsmhManholeRugs;
            string usmhRectangle1LongSide = ""; if (!row.IsUsmhRectangle1LongSideNull()) usmhRectangle1LongSide = row.UsmhRectangle1LongSide;
            string usmhRectangle1ShortSide = ""; if (!row.IsUsmhRectangle1ShortSideNull()) usmhRectangle1ShortSide = row.UsmhRectangle1ShortSide;
            string usmhRectangle2LongSide = ""; if (!row.IsUsmhRectangle2LongSideNull()) usmhRectangle2LongSide = row.UsmhRectangle2LongSide;
            string usmhRectangle2ShortSide = ""; if (!row.IsUsmhRectangle2ShortSideNull()) usmhRectangle2ShortSide = row.UsmhRectangle2ShortSide;
            string usmhTotalSurfaceArea = ""; if (!row.IsUsmhTotalSurfaceAreaNull()) usmhTotalSurfaceArea = row.UsmhTotalSurfaceArea;

            string dsmhStreet = ""; if (!row.IsDsmhStreetNull()) dsmhStreet = row.DsmhStreet;
            string dsmhLatitude = ""; if (!row.IsDsmhLatitudeNull()) dsmhLatitude = row.DsmhLatitude;
            string dsmhLongitude = ""; if (!row.IsDsmhLongitudeNull()) dsmhLongitude = row.DsmhLongitude;
            string dsmhShape = ""; if (!row.IsDsmhShapeNull()) dsmhShape = row.DsmhShape;
            string dsmhLocation = ""; if (!row.IsDsmhLocationNull()) dsmhLocation = row.DsmhLocation;
            int? dsmhConditionRating = null; if (!row.IsDsmhConditionRatingNull()) dsmhConditionRating = row.DsmhConditionRating;
            int? dsmhMaterialId = null; if (!row.IsDsmhMaterialIdNull()) dsmhMaterialId = row.DsmhMaterialId;
            string dsmhTopDiameter = ""; if (!row.IsDsmhTopDiameterNull()) dsmhTopDiameter = row.DsmhTopDiameter;
            string dsmhTopDepth = ""; if (!row.IsDsmhTopDepthNull()) dsmhTopDepth = row.DsmhTopDepth;
            string dsmhDownDiameter = ""; if (!row.IsDsmhDownDiameterNull()) dsmhDownDiameter = row.DsmhDownDiameter;
            string dsmhDownDepth = ""; if (!row.IsDsmhDownDepthNull()) dsmhDownDepth = row.DsmhDownDepth;
            int? dsmhManholeRugs = null; if (!row.IsDsmhManholeRugsNull()) dsmhManholeRugs = row.DsmhManholeRugs;
            string dsmhRectangle1LongSide = ""; if (!row.IsDsmhRectangle1LongSideNull()) dsmhRectangle1LongSide = row.DsmhRectangle1LongSide;
            string dsmhRectangle1ShortSide = ""; if (!row.IsDsmhRectangle1ShortSideNull()) dsmhRectangle1ShortSide = row.DsmhRectangle1ShortSide;
            string dsmhRectangle2LongSide = ""; if (!row.IsDsmhRectangle2LongSideNull()) dsmhRectangle2LongSide = row.DsmhRectangle2LongSide;
            string dsmhRectangle2ShortSide = ""; if (!row.IsDsmhRectangle2ShortSideNull()) dsmhRectangle2ShortSide = row.DsmhRectangle2ShortSide;
            string dsmhTotalSurfaceArea = ""; if (!row.IsDsmhTotalSurfaceAreaNull()) dsmhTotalSurfaceArea = row.DsmhTotalSurfaceArea;

            // insert usmh (if not exists)
            int? usmh_assetId = null;
            if (usmh != "")
            {
                LfsAssetSewerMH lfsAssetSewerUsmh = new LfsAssetSewerMH(null);
                usmh_assetId = lfsAssetSewerUsmh.InsertDirect(countryId, provinceId, countyId, cityId, usmh, usmhLatitude, usmhLongitude, usmhStreet, false, companyId, usmhShape, usmhLocation, usmhMaterialId, usmhTopDiameter, usmhTopDepth, "", "", "", usmhDownDiameter, usmhDownDepth, "", "", "", usmhRectangle1LongSide, usmhRectangle1ShortSide, usmhRectangle2LongSide, usmhRectangle2ShortSide, "", "", usmhManholeRugs, "", usmhTotalSurfaceArea, usmhConditionRating);

                // insert in LFS tables (only if not exists)
                AssetSewerMHGateway assetSewerMHGateway = new AssetSewerMHGateway();

                if (!assetSewerMHGateway.IsUsedInMHProject(projectId, usmh_assetId.Value))
                {
                    AssetSewerMHGateway assetSewerMhGatewayForUSMH = new AssetSewerMHGateway(null);
                    assetSewerMhGatewayForUSMH.InsertMHProject(usmh_assetId.Value, projectId, DateTime.Now, false, companyId);
                }

                if (row.MHRehabUsmh)
                {
                    //TODO MH
                    SaveMHRehabWork(projectId, usmh_assetId.Value, companyId);
                }
            }

            // insert dsmh (if not exists)
            int? dsmh_assetId = null;
            if (dsmh != "")
            {
                LfsAssetSewerMH lfsAssetSewerDsmh = new LfsAssetSewerMH(null);
                dsmh_assetId = lfsAssetSewerDsmh.InsertDirect(countryId, provinceId, countyId, cityId, dsmh, dsmhLatitude, dsmhLongitude, dsmhStreet, false, companyId, dsmhShape, dsmhLocation, dsmhMaterialId, dsmhTopDiameter, dsmhTopDepth, "", "", "", dsmhDownDiameter, dsmhDownDepth, "", "", "", dsmhRectangle1LongSide, dsmhRectangle1ShortSide, dsmhRectangle2LongSide, dsmhRectangle2ShortSide, "", "", dsmhManholeRugs, "", dsmhTotalSurfaceArea, dsmhConditionRating);

                // insert in LFS tables (only if not exists)
                AssetSewerMHGateway assetSewerMHGateway = new AssetSewerMHGateway();

                if (!assetSewerMHGateway.IsUsedInMHProject(projectId, dsmh_assetId.Value))
                {
                    AssetSewerMHGateway assetSewerMhGatewayForDSMH = new AssetSewerMHGateway(null);
                    assetSewerMhGatewayForDSMH.InsertMHProject(dsmh_assetId.Value, projectId, DateTime.Now, false, companyId);
                }

                if (row.MHRehabDsmh)
                {
                    //TODO MH
                    SaveMHRehabWork(projectId, dsmh_assetId.Value, companyId);
                }
            }

            // insert section
            LfsAssetSewerSection lfsAssetSewerSection = new LfsAssetSewerSection(null);
            string mapSize = ""; if (!row.IsMapSizeNull()) mapSize = row.MapSize;
            string mapLength = ""; if (!row.IsMapLengthNull()) mapLength = row.MapLength;                       

            int sectionMaterialRefId = 1; // first material when adding new section
            string sectionMaterial = ""; if (!row.IsSectionMaterialNull()) sectionMaterial = row.SectionMaterial;            
            DateTime sectionMaterialDate = DateTime.Now;

            int section_assetId = lfsAssetSewerSection.InsertDirect(countryId, provinceId, countyId, cityId, row.SectionID, street, usmh_assetId, dsmh_assetId, mapSize, "", mapLength, "", null, null, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", false, companyId, "", "", sectionMaterialRefId, sectionMaterial, sectionMaterialDate);

            return section_assetId;
        }



        /// <summary>
        /// Save a RA work
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="section_assetId">section_assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="rehabAssessmentPrevWork">rehabAssessmentPrevWork</param>
        /// <param name="fullLengthLiningPrevWork">fullLengthLiningPrevWork</param>
        /// <param name="pointRepairsPrevWork">pointRepairsPrevWork</param>
        /// <param name="junctionLiningPrevWork">junctionLiningPrevWork</param>
        private void SaveRAWork(int projectId, int section_assetId, int companyId, bool rehabAssessmentPrevWork, bool fullLengthLiningPrevWork, bool pointRepairsPrevWork, bool junctionLiningPrevWork, bool rehabAssessmentNewWork, bool fullLengthLiningNewWork, bool pointRepairsNewWork, bool junctionLiningNewWork)
        {
            // If there is no previous work
            if (!rehabAssessmentPrevWork)
            {
                WorkRehabAssessment workRehabAssessment = new WorkRehabAssessment(null);
                workRehabAssessment.InsertDirect(projectId, section_assetId, null, null, null, false, companyId, "", "");
            }
            else
            {
                // Copy selected works
                SavePreviousRAWork(projectId, section_assetId, companyId);
                if (fullLengthLiningPrevWork && !fullLengthLiningNewWork) SavePreviousFLWork(projectId, section_assetId, companyId);
                if (pointRepairsPrevWork && !pointRepairsNewWork) SavePreviousPRWork(projectId, section_assetId, companyId);
                if (junctionLiningPrevWork && !junctionLiningNewWork) SavePreviousJLWork(projectId, section_assetId, companyId);
            }
        }



        /// <summary>
        /// Save a FLL work
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="section_assetId">section_assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="rehabAssessmentPrevWork">rehabAssessmentPrevWork</param>
        /// <param name="fullLengthLiningPrevWork">fullLengthLiningPrevWork</param>
        /// <param name="pointRepairsPrevWork">pointRepairsPrevWork</param>
        /// <param name="junctionLiningPrevWork">junctionLiningPrevWork</param>
        /// <param name="rehabAssessmentNewWork">rehabAssessmentNewWork</param>
        /// <param name="fullLengthLiningNewWork">fullLengthLiningNewWork</param>
        /// <param name="pointRepairsNewWork">pointRepairsNewWork</param>
        /// <param name="junctionLiningNewWork">junctionLiningNewWork</param>
        /// <param name="clientId">clientId</param>
        private void SaveFLLWork(int projectId, int section_assetId, int companyId, bool rehabAssessmentPrevWork, bool fullLengthLiningPrevWork, bool pointRepairsPrevWork, bool junctionLiningPrevWork, bool rehabAssessmentNewWork, bool fullLengthLiningNewWork, bool pointRepairsNewWork, bool junctionLiningNewWork, string clientId)
        {
            // If there is no previous work
            if (!fullLengthLiningPrevWork)
            {
                WorkFullLengthLining workFullLengthLining = new WorkFullLengthLining(null);
                workFullLengthLining.InsertDirectEmptyWorks(projectId, section_assetId, null, clientId, null, null, null, null, null, null, null, false, false, false, false, false, false, false, companyId, false, "", "");
            }
            else
            {
                // Copy selected works
                if (rehabAssessmentPrevWork && !rehabAssessmentNewWork) SavePreviousRAWork(projectId, section_assetId, companyId);
                SavePreviousFLWork(projectId, section_assetId, companyId);
                if (pointRepairsPrevWork && !pointRepairsNewWork) SavePreviousPRWork(projectId, section_assetId, companyId);
                if (junctionLiningPrevWork && !junctionLiningNewWork) SavePreviousJLWork(projectId, section_assetId, companyId);
            }
        }



        /// <summary>
        /// Save a PR work
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="section_assetId">section_assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="rehabAssessmentPrevWork">rehabAssessmentPrevWork</param>
        /// <param name="fullLengthLiningPrevWork">fullLengthLiningPrevWork</param>
        /// <param name="pointRepairsPrevWork">pointRepairsPrevWork</param>
        /// <param name="junctionLiningPrevWork">junctionLiningPrevWork</param>
        /// <param name="rehabAssessmentNewWork">rehabAssessmentNewWork</param>
        /// <param name="fullLengthLiningNewWork">fullLengthLiningNewWork</param>
        /// <param name="junctionLiningNewWork">junctionLiningNewWork</param>
        /// <param name="pointRepairsNewWork">pointRepairsNewWork</param>
        /// <param name="clientId">clientId</param>
        private void SavePRWork(int projectId, int section_assetId, int companyId, bool rehabAssessmentPrevWork, bool fullLengthLiningPrevWork, bool pointRepairsPrevWork, bool junctionLiningPrevWork, bool rehabAssessmentNewWork, bool fullLengthLiningNewWork, bool pointRepairsNewWork, bool junctionLiningNewWork, string clientId)
        {
            // If there is no previous work
            if (!pointRepairsPrevWork)
            {
                WorkPointRepairs workPointRepairs = new WorkPointRepairs(null);
                workPointRepairs.InsertDirect(projectId, section_assetId, null, clientId, "", null, false, "", null, null, null, null, null, false, false, false, false, false, false, false, "", false, companyId, "", "");
            }
            else
            {
                // Copy selected works
                if (rehabAssessmentPrevWork && !rehabAssessmentNewWork) SavePreviousRAWork(projectId, section_assetId, companyId);
                if (fullLengthLiningPrevWork && !fullLengthLiningNewWork) SavePreviousFLWork(projectId, section_assetId, companyId);
                SavePreviousPRWork(projectId, section_assetId, companyId);
                if (junctionLiningPrevWork && !junctionLiningNewWork) SavePreviousJLWork(projectId, section_assetId, companyId);
            }
        }


        
        /// <summary>
        /// Save a JL Work
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="section_assetId">section_assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="rehabAssessmentPrevWork">rehabAssessmentPrevWork</param>
        /// <param name="fullLengthLiningPrevWork">fullLengthLiningPrevWork</param>
        /// <param name="pointRepairsPrevWork">pointRepairsPrevWork</param>
        /// <param name="junctionLiningPrevWork">junctionLiningPrevWork</param>
        private void SaveJLWork(int projectId, int section_assetId, int companyId, bool rehabAssessmentPrevWork, bool fullLengthLiningPrevWork, bool pointRepairsPrevWork, bool junctionLiningPrevWork, bool rehabAssessmentNewWork, bool fullLengthLiningNewWork, bool pointRepairsNewWork, bool junctionLiningNewWork)
        {
            // If there is no previous work
            if (!junctionLiningPrevWork)
            {
                WorkJunctionLiningSection workJunctionLiningSection = new WorkJunctionLiningSection(null);
                workJunctionLiningSection.InsertDirect(projectId, section_assetId, null, 0, 0, false, "No", 0, 0, false, companyId, "", "", "", "", false, "", 0);
            }
            else
            {
                // Copy selected works
                if (rehabAssessmentPrevWork && !rehabAssessmentNewWork) SavePreviousRAWork(projectId, section_assetId, companyId);
                if (fullLengthLiningPrevWork && !fullLengthLiningNewWork) SavePreviousFLWork(projectId, section_assetId, companyId);
                if (pointRepairsPrevWork && !pointRepairsNewWork) SavePreviousPRWork(projectId, section_assetId, companyId);
                SavePreviousJLWork(projectId, section_assetId, companyId);
            }
        }



        /// <summary>
        /// SaveMHRehabWork
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="mh_assetId">mh_assetId</param>
        /// <param name="companyId">companyId</param>
        private void SaveMHRehabWork(int projectId, int mh_assetId, int companyId)
        {
            MrBatchVerificationGateway mrBatchVerificationForLastBatch = new MrBatchVerificationGateway();
            mrBatchVerificationForLastBatch.LoadLastBatch(companyId);
            int? batchId = null;

            if (mrBatchVerificationForLastBatch.Table.Rows.Count > 0)
            {
                WorkManholeRehabilitationBatchGateway workManholeRehabilitationBatchGateway = new WorkManholeRehabilitationBatchGateway();
                batchId = workManholeRehabilitationBatchGateway.GetLastId(companyId);
            }

            WorkManholeRehabilitation workManholeRehabilitation = new WorkManholeRehabilitation(null);
            workManholeRehabilitation.InsertDirectEmptyWorks(projectId, mh_assetId, null, null, batchId, false, companyId);
        }


                
        /// <summary>
        /// Save a Previous RA work
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="section_assetId">section_assetId</param>
        /// <param name="companyId">companyId</param>
        private void SavePreviousRAWork(int projectId, int section_assetId, int companyId)
        {
            // Load Previous work  - Rehab assessment data (last sections work)            
            string workType = "Rehab Assessment";
            WorkRehabAssessmentGateway workRehabAssessmentGateway = new WorkRehabAssessmentGateway();
            workRehabAssessmentGateway.LoadTop1ByProjectIdAssetIdWorkType(projectId, section_assetId, workType, companyId);
            
            int workId = workRehabAssessmentGateway.GetWorkIdTop1();
            DateTime? preFlushDate = null; if (workRehabAssessmentGateway.GetPreFlushDateTop1().HasValue) preFlushDate = workRehabAssessmentGateway.GetPreFlushDateTop1();
            DateTime? preVideoDate = null; if (workRehabAssessmentGateway.GetPreVideoDateTop1().HasValue) preVideoDate = workRehabAssessmentGateway.GetPreVideoDateTop1();

            // Load Previous work  -  General work data
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByWorkId(workId, companyId);
            int? libraryCategoriesId = null; if (workGateway.GetLibraryCategoriesId(workId).HasValue) libraryCategoriesId = workGateway.GetLibraryCategoriesId(workId);
            string comments = workGateway.GetComments(workId);
            string history = workGateway.GetHistory(workId);

            // Save new work
            WorkRehabAssessment workRehabAssessment = new WorkRehabAssessment(null);
            int newSectionWorkId = workRehabAssessment.InsertDirect(projectId, section_assetId, libraryCategoriesId, preFlushDate, preVideoDate, false, companyId, comments, history);

            // Load Previous work  - Comments and History
            SavePreviousComments(workId, workType, companyId, newSectionWorkId);
            SavePreviousHistory(workId, workType, companyId, newSectionWorkId);
        }



        /// <summary>
        /// Save a Previous FL work
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="section_assetId">section_assetId</param>
        /// <param name="companyId">companyId</param>
        private void SavePreviousFLWork(int projectId, int section_assetId, int companyId)
        {
            // Load Previous work  -  Full Length Lining data (last sections work)            
            string workType = "Full Length Lining";
            WorkFullLengthLiningGateway workFullLengthLiningGateway = new WorkFullLengthLiningGateway();
            workFullLengthLiningGateway.LoadTop1ByProjectIdAssetIdWorkType(projectId, section_assetId, workType, companyId);

            int workId = workFullLengthLiningGateway.GetWorkIdTop1();
            string clientId = ""; if (workFullLengthLiningGateway.GetClientId(workId) != "") clientId = workFullLengthLiningGateway.GetClientId(workId);
            DateTime? proposedLiningDate = null; if (workFullLengthLiningGateway.GetProposedLiningDate(workId).HasValue) proposedLiningDate = workFullLengthLiningGateway.GetProposedLiningDate(workId);
            DateTime? deadlineLiningDate = null; if (workFullLengthLiningGateway.GetDeadlineLiningDate(workId).HasValue) deadlineLiningDate = workFullLengthLiningGateway.GetDeadlineLiningDate(workId);
            DateTime? p1Date = null; if (workFullLengthLiningGateway.GetP1Date(workId).HasValue) p1Date = workFullLengthLiningGateway.GetP1Date(workId);
            DateTime? m1Date = null; if (workFullLengthLiningGateway.GetM1Date(workId).HasValue) m1Date = workFullLengthLiningGateway.GetM1Date(workId);
            DateTime? m2Date = null; if (workFullLengthLiningGateway.GetM2Date(workId).HasValue) m2Date = workFullLengthLiningGateway.GetM2Date(workId);
            DateTime? installDate = null; if (workFullLengthLiningGateway.GetInstallDate(workId).HasValue) installDate = workFullLengthLiningGateway.GetInstallDate(workId);
            DateTime? finalVideoDate = null; if (workFullLengthLiningGateway.GetFinalVideoDate(workId).HasValue) finalVideoDate = workFullLengthLiningGateway.GetFinalVideoDate(workId);
            bool issueIdentified = workFullLengthLiningGateway.GetIssueIdentified(workId);
            bool issueLfs = workFullLengthLiningGateway.GetIssueLFS(workId);
            bool issueClient = workFullLengthLiningGateway.GetIssueClient(workId);
            bool issueSales = workFullLengthLiningGateway.GetIssueSales(workId);
            bool issueGivenToClient = workFullLengthLiningGateway.GetIssueGivenToClient(workId);
            bool issueResolved = workFullLengthLiningGateway.GetIssueResolved(workId);
            bool issueInvestigation = workFullLengthLiningGateway.GetIssueInvestigation(workId);

            // Load Previous work  -  Full Length Lining M1 data (last sections work)         
            FullLengthLiningWorkDetailsGateway fullLengthLiningWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway();
            fullLengthLiningWorkDetailsGateway.LoadByWorkIdAssetId(workId, section_assetId, companyId);

            string measurementTakenBy = ""; if (fullLengthLiningWorkDetailsGateway.GetMeasurementTakenBy(workId) != "") measurementTakenBy = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenBy(workId);
            string trafficControl = ""; if (fullLengthLiningWorkDetailsGateway.GetTrafficControl(workId) != "") trafficControl = fullLengthLiningWorkDetailsGateway.GetTrafficControl(workId);
            string siteDetails = ""; if (fullLengthLiningWorkDetailsGateway.GetSiteDetails(workId) != "") siteDetails = fullLengthLiningWorkDetailsGateway.GetSiteDetails(workId);
            string accessType = ""; if (fullLengthLiningWorkDetailsGateway.GetAccessType(workId) != "") accessType = fullLengthLiningWorkDetailsGateway.GetAccessType(workId);
            bool pipeSizeChange = fullLengthLiningWorkDetailsGateway.GetPipeSizeChange(workId);
            bool standardByPass = fullLengthLiningWorkDetailsGateway.GetStandardBypass(workId);
            string standardByPassComments = ""; if (fullLengthLiningWorkDetailsGateway.GetStandardBypassComments(workId) != "") standardByPassComments = fullLengthLiningWorkDetailsGateway.GetStandardBypassComments(workId);
            string trafficControlDetails = ""; if (fullLengthLiningWorkDetailsGateway.GetTrafficControlDetails(workId) != "") trafficControlDetails = fullLengthLiningWorkDetailsGateway.GetTrafficControlDetails(workId);
            string measurementType = ""; if (fullLengthLiningWorkDetailsGateway.GetMeasurementType(workId) != "") measurementType = fullLengthLiningWorkDetailsGateway.GetMeasurementType(workId);
            string measurementFromMH = ""; if (fullLengthLiningWorkDetailsGateway.GetMeasurementFromMh(workId) != "") measurementFromMH = fullLengthLiningWorkDetailsGateway.GetMeasurementFromMh(workId);
            string videoDoneFromMH = ""; if (fullLengthLiningWorkDetailsGateway.GetVideoDoneFromMh(workId) != "") videoDoneFromMH = fullLengthLiningWorkDetailsGateway.GetVideoDoneFromMh(workId);
            string videoDoneToMH = ""; if (fullLengthLiningWorkDetailsGateway.GetVideoDoneToMh(workId) != "") videoDoneToMH = fullLengthLiningWorkDetailsGateway.GetVideoDoneToMh(workId);

            // Load Previous work  -  Full Length Lining M2 data (last sections work)            
            string videoLength = ""; if (fullLengthLiningWorkDetailsGateway.GetVideoLength(workId) != "") videoLength = fullLengthLiningWorkDetailsGateway.GetVideoLength(workId);
            string measurementTakenBy2 = ""; if (fullLengthLiningWorkDetailsGateway.GetMeasurementTakenByM2(workId) != "") measurementTakenBy2 = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenByM2(workId);
            bool dropPipe = fullLengthLiningWorkDetailsGateway.GetDropPipe(workId);
            string dropPipeInvertDepth = ""; if (fullLengthLiningWorkDetailsGateway.GetDropPipeInvertDepth(workId) != "") dropPipeInvertDepth = fullLengthLiningWorkDetailsGateway.GetDropPipeInvertDepth(workId);
            int? cappedLaterals = null; if (fullLengthLiningWorkDetailsGateway.GetCappedLaterals(workId).HasValue) cappedLaterals = fullLengthLiningWorkDetailsGateway.GetCappedLaterals(workId);
            string lineWithID = ""; if (fullLengthLiningWorkDetailsGateway.GetLineWithId(workId) != "") lineWithID = fullLengthLiningWorkDetailsGateway.GetLineWithId(workId);
            string hydrantAddress = ""; if (fullLengthLiningWorkDetailsGateway.GetHydrantAddress(workId) != "") hydrantAddress = fullLengthLiningWorkDetailsGateway.GetHydrantAddress(workId);
            string hydroWireWithin10FtOfInversionMH = ""; if (fullLengthLiningWorkDetailsGateway.GetHydroWiredWithin10FtOfInversionMH(workId) != "") hydroWireWithin10FtOfInversionMH = fullLengthLiningWorkDetailsGateway.GetHydroWiredWithin10FtOfInversionMH(workId);
            string distanceToInversionMH = ""; if (fullLengthLiningWorkDetailsGateway.GetDistanceToInversionMh(workId) != "") distanceToInversionMH = fullLengthLiningWorkDetailsGateway.GetDistanceToInversionMh(workId);
            string surfaceGrade = ""; if (fullLengthLiningWorkDetailsGateway.GetSurfaceGrade(workId) != "") surfaceGrade = fullLengthLiningWorkDetailsGateway.GetSurfaceGrade(workId);
            bool hydroPulley = fullLengthLiningWorkDetailsGateway.GetHydroPulley(workId);
            bool fridgeCart = fullLengthLiningWorkDetailsGateway.GetFridgeCart(workId);
            bool twoPump = fullLengthLiningWorkDetailsGateway.GetTwoPump(workId);
            bool sixBypass = fullLengthLiningWorkDetailsGateway.GetSixBypass(workId);
            bool scaffolding = fullLengthLiningWorkDetailsGateway.GetScaffolding(workId);
            bool winchExtention = fullLengthLiningWorkDetailsGateway.GetWinchExtension(workId);
            bool extraGenerator = fullLengthLiningWorkDetailsGateway.GetExtraGenerator(workId);
            bool greyCableExtension = fullLengthLiningWorkDetailsGateway.GetGreyCableExtension(workId);
            bool easementMats = fullLengthLiningWorkDetailsGateway.GetEasementMats(workId);
            bool rampRequired = fullLengthLiningWorkDetailsGateway.GetRampRequired(workId);
            bool cameraSkid = fullLengthLiningWorkDetailsGateway.GetCameraSkid(workId);

            // Load Previous work  -  Full Length Lining P1 data (last sections work)        
            int? cxisRemoved = null; if (fullLengthLiningWorkDetailsGateway.GetCxisRemoved(workId).HasValue) fullLengthLiningWorkDetailsGateway.GetCxisRemoved(workId);
            bool roboticPrepCompleted = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompleted(workId);
            DateTime? roboticPrepCompletedDate = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompletedDate(workId);
            bool p1Completed = fullLengthLiningWorkDetailsGateway.GetP1Completed(workId);

            // Load Previous work  -  General work data
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByWorkId(workId, companyId);

            int? libraryCategoriesId = null; if (workGateway.GetLibraryCategoriesId(workId).HasValue) libraryCategoriesId = workGateway.GetLibraryCategoriesId(workId);
            string comments = workGateway.GetComments(workId);
            string history = workGateway.GetHistory(workId);

            // Save new work
            WorkFullLengthLining workFullLengthLining = new WorkFullLengthLining(null);
            int newSectionWorkId = workFullLengthLining.InsertDirectFullWork(projectId, section_assetId, libraryCategoriesId, clientId, proposedLiningDate, deadlineLiningDate, p1Date, m1Date, m2Date, installDate, finalVideoDate, issueIdentified, issueLfs, issueClient, issueSales, issueGivenToClient, issueResolved, false, companyId, issueInvestigation, comments, history, cxisRemoved, roboticPrepCompleted, roboticPrepCompletedDate, measurementTakenBy, trafficControl, siteDetails, pipeSizeChange, standardByPass, standardByPassComments, trafficControlDetails, measurementType, measurementFromMH, videoDoneFromMH, videoDoneToMH, videoLength, measurementTakenBy2, dropPipe, dropPipeInvertDepth, cappedLaterals, lineWithID, hydrantAddress, hydroWireWithin10FtOfInversionMH, distanceToInversionMH, surfaceGrade, hydroPulley, fridgeCart, twoPump, sixBypass, scaffolding, winchExtention, extraGenerator, greyCableExtension, easementMats, rampRequired, cameraSkid, accessType, p1Completed);

            // Load Previous work  -  Save fl laterals
            WorkFullLengthLiningM1LateralGateway workFullLengthLiningM1LateralGateway = new WorkFullLengthLiningM1LateralGateway();
            workFullLengthLiningM1LateralGateway.LoadByWorkId(workId, companyId);

            foreach (WorkTDS.LFS_WORK_FULLLENGTHLINING_M1_LATERALRow lateralRow in (WorkTDS.LFS_WORK_FULLLENGTHLINING_M1_LATERALDataTable)workFullLengthLiningM1LateralGateway.Table)
            {
                int lateral = lateralRow.Lateral;
                string videoDistance = ""; if (!lateralRow.IsVideoDistanceNull()) videoDistance = lateralRow.VideoDistance;
                string clockPosition = ""; if (!lateralRow.IsClockPositionNull()) clockPosition = lateralRow.ClockPosition;
                string distanceToCentre = ""; if (!lateralRow.IsDistanceToCentreNull()) distanceToCentre = lateralRow.DistanceToCentre;
                string timeOpened = ""; if (!lateralRow.IsTimeOpenedNull()) timeOpened = lateralRow.TimeOpened;
                string reverseSetup = ""; if (!lateralRow.IsReverseSetupNull()) reverseSetup = lateralRow.ReverseSetup;
                DateTime? reinstate = null; if (!lateralRow.IsReinstateNull()) reinstate = lateralRow.Reinstate;
                string lateralComments = ""; if (!lateralRow.IsCommentsNull()) lateralComments = lateralRow.Comments;
                string clientInspectionNo = ""; if (!lateralRow.IsClientInspectionNoNull()) clientInspectionNo = lateralRow.ClientInspectionNo;
                DateTime? v1Inspection = null; if (!lateralRow.IsV1InspectionNull()) v1Inspection = lateralRow.V1Inspection;
                bool requiresRoboticPrep = lateralRow.RequiresRoboticPrep;
                DateTime? requiresRoboticPrepDate = null; if (!lateralRow.IsRequiresRoboticPrepDateNull()) requiresRoboticPrepDate = lateralRow.RequiresRoboticPrepDate;
                bool holdClientIssue = lateralRow.HoldClientIssue;
                bool holdLFSIssue = lateralRow.HoldLFSIssue;
                bool lineLateral = lateralRow.LineLateral;
                bool dyeTestReq = lateralRow.DyeTestReq;
                DateTime? dyeTestComplete = null; if (!lateralRow.IsDyeTestCompleteNull()) dyeTestComplete = lateralRow.DyeTestComplete;
                string contractYear = lateralRow.ContractYear;

                WorkFullLengthLiningM1Lateral workFullLengthLiningM1Lateral = new WorkFullLengthLiningM1Lateral();
                workFullLengthLiningM1Lateral.InsertDirect(newSectionWorkId, lateral, videoDistance, clockPosition, distanceToCentre, timeOpened, reverseSetup, reinstate, lateralComments, false, companyId, clientInspectionNo, v1Inspection, requiresRoboticPrep, requiresRoboticPrepDate, holdClientIssue, holdLFSIssue, lineLateral, dyeTestReq, dyeTestComplete, contractYear);
            }

            // Load Previous work  - Comments and History
            SavePreviousComments(workId, workType, companyId, newSectionWorkId);
            SavePreviousHistory(workId, workType, companyId, newSectionWorkId);
        }



        /// <summary>
        /// Save a Previous PR work
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="section_assetId">section_assetId</param>
        /// <param name="companyId">companyId</param>
        private void SavePreviousPRWork(int projectId, int section_assetId, int companyId)
        {
            // Load Previous work - Point Repairs data (last sections work)            
            string workType = "Point Repairs";
            WorkPointRepairsGateway workPointRepairsGateway = new WorkPointRepairsGateway();
            workPointRepairsGateway.LoadTop1ByProjectIdAssetIdWorkType(projectId, section_assetId, workType, companyId);

            int workId = workPointRepairsGateway.GetWorkIdTop1();
            string clientId = ""; if (workPointRepairsGateway.GetClientId(workId) != "") clientId = workPointRepairsGateway.GetClientId(workId);
            string measurementTakenBy = ""; if (workPointRepairsGateway.GetMeasurementTakenBy(workId) != "") measurementTakenBy = workPointRepairsGateway.GetMeasurementTakenBy(workId);
            DateTime? repairConfirmationDate = null; if (workPointRepairsGateway.GetRepairConfirmationDate(workId).HasValue) repairConfirmationDate = workPointRepairsGateway.GetRepairConfirmationDate(workId);
            bool bypassRequired = workPointRepairsGateway.GetBypassRequired(workId);
            string roboticDistances = ""; if (workPointRepairsGateway.GetRoboticDistances(workId) != "") roboticDistances = workPointRepairsGateway.GetRoboticDistances(workId);
            DateTime? proposedLiningDate = null; if (workPointRepairsGateway.GetProposedLiningDate(workId).HasValue) proposedLiningDate = workPointRepairsGateway.GetProposedLiningDate(workId);
            DateTime? deadlineLiningDate = null; if (workPointRepairsGateway.GetDeadlineLiningDate(workId).HasValue) deadlineLiningDate = workPointRepairsGateway.GetDeadlineLiningDate(workId);
            DateTime? finalVideoDate = null; if (workPointRepairsGateway.GetFinalVideoDate(workId).HasValue) finalVideoDate = workPointRepairsGateway.GetFinalVideoDate(workId);            
            int? estimatedJoints = null; if (workPointRepairsGateway.GetEstimatedJoints(workId).HasValue) estimatedJoints = workPointRepairsGateway.GetEstimatedJoints(workId);
            int? jointsTestSealed = null; if (workPointRepairsGateway.GetJointsTestSealed(workId).HasValue) jointsTestSealed = workPointRepairsGateway.GetJointsTestSealed(workId);
            bool issueIdentified = workPointRepairsGateway.GetIssueIdentified(workId);
            bool issueLfs = workPointRepairsGateway.GetIssueLFS(workId);
            bool issueClient = workPointRepairsGateway.GetIssueClient(workId);
            bool issueSales = workPointRepairsGateway.GetIssueSales(workId);            
            bool issueGivenToClient = workPointRepairsGateway.GetIssueGivenToClient(workId);
            bool issueResolved = workPointRepairsGateway.GetIssueResolved(workId);
            bool issueInvestigation = workPointRepairsGateway.GetIssueInvestigation(workId);
            string repairId = ""; if (workPointRepairsGateway.GetRepairID(workId) != "") repairId = workPointRepairsGateway.GetRepairID(workId);

            // Load Previous work - General work data
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByWorkId(workId, companyId);

            int? libraryCategoriesId = null; if (workGateway.GetLibraryCategoriesId(workId).HasValue) libraryCategoriesId = workGateway.GetLibraryCategoriesId(workId);
            string comments = workGateway.GetComments(workId);
            string history = workGateway.GetHistory(workId);

            // Save new work
            WorkPointRepairs workPointRepairs = new WorkPointRepairs(null);
            int newSectionWorkId = workPointRepairs.InsertDirect(projectId, section_assetId, libraryCategoriesId, clientId, measurementTakenBy, repairConfirmationDate, bypassRequired, roboticDistances, proposedLiningDate, deadlineLiningDate, finalVideoDate, estimatedJoints, jointsTestSealed, issueIdentified, issueLfs, issueClient, issueSales, issueGivenToClient, issueResolved, issueInvestigation, repairId, false, companyId, comments, history);

            // Load Previous work  -  Save pr repair
            WorkPointRepairsRepairGateway workPointRepairsRepairGateway = new WorkPointRepairsRepairGateway();
            workPointRepairsRepairGateway.LoadByWorkId(workId, companyId);

            foreach (WorkTDS.LFS_WORK_POINT_REPAIRS_REPAIRRow row in (WorkTDS.LFS_WORK_POINT_REPAIRS_REPAIRDataTable)workPointRepairsRepairGateway.Table)
            {
                string repairPointId = row.RepairPointID;
                string type = ""; if (!row.IsTypeNull()) type = row.Type;
                string reamDistance = ""; if (!row.IsReamDistanceNull()) reamDistance = row.ReamDistance;
                DateTime? reamDate = null; if (!row.IsReamDateNull()) reamDate = row.ReamDate;
                string linerDistance = ""; if (!row.IsLinerDistanceNull()) linerDistance = row.LinerDistance;
                string direction = ""; if (!row.IsDirectionNull()) direction = row.Direction;
                int? reinstates = null; if (!row.IsReinstatesNull()) reinstates = row.Reinstates;
                string ltmh = ""; if (!row.IsLTMHNull()) ltmh = row.LTMH;
                string vtmh = ""; if (!row.IsVTMHNull()) vtmh = row.VTMH;
                string distance = ""; if (!row.IsDistanceNull()) distance = row.Distance;
                string size_ = ""; if (!row.IsSize_Null()) size_ = row.Size_;
                DateTime? installDate = null; if (!row.IsInstallDateNull()) installDate = row.InstallDate;
                string mhShot = ""; if (!row.IsMHShotNull()) mhShot = row.MHShot;
                string groutDistance = ""; if (!row.IsGroutDistanceNull()) groutDistance = row.GroutDistance;
                DateTime? groutDate = null; if (!row.IsGroutDateNull()) groutDate = row.GroutDate;
                string approval = ""; if (!row.IsApprovalNull()) approval = row.Approval;
                bool extraRepair = row.ExtraRepair;
                bool cancelled = row.Cancelled;
                string commentsRepair = ""; if (!row.IsCommentsNull()) commentsRepair = row.Comments;
                string defectQualifier = ""; if (!row.IsDefectQualifierNull()) defectQualifier = row.DefectQualifier;
                string defecDetails = ""; if (!row.IsDefectDetailsNull()) defecDetails = row.DefectDetails;
                string length = ""; if (!row.IsLengthNull()) length = row.Length;
                DateTime? reinstateDate = null; if (!row.IsReinstateDateNull()) reinstateDate = row.ReinstateDate;

                WorkPointRepairsRepair workPointRepairsRepair = new WorkPointRepairsRepair();
                workPointRepairsRepair.InsertDirect(newSectionWorkId, repairPointId, type, reamDistance, reamDate, linerDistance, direction, reinstates, ltmh, vtmh, distance, size_, installDate, mhShot, groutDistance, groutDate, approval, extraRepair, cancelled, commentsRepair, false, companyId, defectQualifier, defectQualifier, length, reinstateDate);
            }

            // Load Previous work  - Comments and History
            SavePreviousComments(workId, workType, companyId, newSectionWorkId);
            SavePreviousHistory(workId, workType, companyId, newSectionWorkId);            
        }



        /// <summary>
        /// Save a Previous JL work
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="section_assetId">section_assetId</param>
        /// <param name="companyId">companyId</param>
        private void SavePreviousJLWork(int projectId, int section_assetId, int companyId)
        {
            // Load Previous work  -  Junction Lining section data (last sections work)            
            string workType = "Junction Lining Section";
            WorkJunctionLiningSectionGateway workJunctionLiningSectionGateway = new WorkJunctionLiningSectionGateway();
            workJunctionLiningSectionGateway.LoadTop1ByProjectIdAssetIdWorkType(projectId, section_assetId, workType, companyId);

            int workId = workJunctionLiningSectionGateway.GetWorkIdTop1();
            int numLats = workJunctionLiningSectionGateway.GetNumLats(workId);
            int notLinedYet = workJunctionLiningSectionGateway.GetNotLinedYet(workId);
            Boolean allMeasured = workJunctionLiningSectionGateway.GetAllMeasured(workId);
            string issueWithLaterals = workJunctionLiningSectionGateway.GetIssueWithLaterals(workId);
            int notMeasuredYet = workJunctionLiningSectionGateway.GetNotMeasuredYet(workId);
            int notDeliveredYet = workJunctionLiningSectionGateway.GetNotDeliveredYet(workId);
            string trafficControl = ""; if (workJunctionLiningSectionGateway.GetTrafficControl(workId) != "") trafficControl = workJunctionLiningSectionGateway.GetTrafficControl(workId);
            string trafficControlDetails = ""; if (workJunctionLiningSectionGateway.GetTrafficControlDetails(workId) != "") trafficControlDetails = workJunctionLiningSectionGateway.GetTrafficControlDetails(workId);
            Boolean standardBypass = workJunctionLiningSectionGateway.GetStandardBypass(workId);
            string standardBypassComments = ""; if (workJunctionLiningSectionGateway.GetStandardBypassComments(workId) != "") standardBypassComments = workJunctionLiningSectionGateway.GetStandardBypassComments(workId);
            int availableToLine = workJunctionLiningSectionGateway.GetAvailableToLine(workId);

            // Load Previous work  -  General work data
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByWorkId(workId, companyId);

            int? libraryCategoriesId = null; if (workGateway.GetLibraryCategoriesId(workId).HasValue) libraryCategoriesId = workGateway.GetLibraryCategoriesId(workId);
            string comments = workGateway.GetComments(workId);
            string history = workGateway.GetHistory(workId);

            // Save new work
            WorkJunctionLiningSection workJunctionLiningSection = new WorkJunctionLiningSection(null);
            int newSectionWorkId = workJunctionLiningSection.InsertDirect(projectId, section_assetId, libraryCategoriesId, numLats, notLinedYet, allMeasured, issueWithLaterals, notMeasuredYet, notDeliveredYet, false, companyId, comments, history, trafficControl, trafficControlDetails, standardBypass, standardBypassComments, availableToLine);

            // Load Previous work  - Junction Lining Lateral data
            WorkJunctionLiningLateralGateway workJunctionLiningLateralGateway = new WorkJunctionLiningLateralGateway();
            workJunctionLiningLateralGateway.LoadBySectionWorkId(workId, companyId);

            foreach (WorkTDS.LFS_WORK_JUNCTIONLINING_LATERALRow lateralRow in (WorkTDS.LFS_WORK_JUNCTIONLINING_LATERALDataTable)workJunctionLiningLateralGateway.Table)
            {
                WorkGateway workGatewayForLateral = new WorkGateway();
                workGatewayForLateral.LoadByWorkId(lateralRow.WorkID, companyId);
                int lateral_assetId = workGatewayForLateral.GetAssetId(lateralRow.WorkID);
                
                DateTime? pipeLocated = null; if (!lateralRow.IsPipeLocatedNull()) pipeLocated = lateralRow.PipeLocated;
                DateTime? sevicesLocated = null; if (!lateralRow.IsServicesLocatedNull()) sevicesLocated = lateralRow.ServicesLocated;
                DateTime? coInstalled = null; if (!lateralRow.IsCoInstalledNull()) coInstalled = lateralRow.CoInstalled;
                DateTime? backfilledConcrete = null; if (!lateralRow.IsBackfilledConcreteNull()) backfilledConcrete = lateralRow.BackfilledConcrete;
                DateTime? backfilledSoil = null; if (!lateralRow.IsBackfilledSoilNull()) backfilledSoil = lateralRow.BackfilledSoil;
                DateTime? grouted = null; if (!lateralRow.IsGroutedNull()) grouted = lateralRow.Grouted;
                DateTime? cored = null; if (!lateralRow.IsCoredNull()) cored = lateralRow.Cored;
                DateTime? prepped = null; if (!lateralRow.IsPreppedNull()) prepped = lateralRow.Prepped;
                DateTime? measured = null; if (!lateralRow.IsMeasuredNull()) measured = lateralRow.Measured;
                string linerSize = ""; if (!lateralRow.IsLinerSizeNull()) linerSize = lateralRow.LinerSize;
                DateTime? inProcess = null; if (!lateralRow.IsInProcessNull()) inProcess = lateralRow.InProcess;
                DateTime? inStock = null; if (!lateralRow.IsInStockNull()) inStock = lateralRow.InStock;
                DateTime? delivered = null; if (!lateralRow.IsDeliveredNull()) delivered = lateralRow.Delivered;
                int? buildRebuild = null; if (!lateralRow.IsBuildRebuildNull()) buildRebuild = lateralRow.BuildRebuild;
                DateTime? preVideo = null; if (!lateralRow.IsPreVideoNull()) preVideo = lateralRow.PreVideo;
                DateTime? linerInstalled = null; if (!lateralRow.IsLinerInstalledNull()) linerInstalled = lateralRow.LinerInstalled;
                DateTime? finalVideo = null; if (!lateralRow.IsFinalVideoNull()) finalVideo = lateralRow.FinalVideo;
                decimal? cost = null; if (!lateralRow.IsCostNull()) cost = lateralRow.Cost;
                DateTime? videoInspection = null; if (!lateralRow.IsVideoInspectionNull()) videoInspection = lateralRow.VideoInspection;
                bool coRequired = lateralRow.CoRequired;
                bool pitRequired = lateralRow.PitRequired;
                string coPitLocation = ""; if (!lateralRow.IsCoPitLocationNull()) coPitLocation = lateralRow.CoPitLocation;
                bool postContractDigRequired = lateralRow.PostContractDigRequired;
                DateTime? coCutDown = null; if (!lateralRow.IsCoCutDownNull()) coCutDown = lateralRow.CoCutDown;
                DateTime? finalRestoration = null; if (!lateralRow.IsFinalRestorationNull()) finalRestoration = lateralRow.FinalRestoration;
                string videoLengthToPropertyLine = ""; if (!lateralRow.IsVideoLengthToPropertyLineNull()) videoLengthToPropertyLine = lateralRow.VideoLengthToPropertyLine;
                bool liningThruCo = lateralRow.LiningThruCo;
                DateTime? noticeDelivered = null; if (!lateralRow.IsNoticeDeliveredNull()) noticeDelivered = lateralRow.NoticeDelivered;
                string hamiltonInspectionNumber = ""; if (!lateralRow.IsHamiltonInspectionNumberNull()) hamiltonInspectionNumber = lateralRow.HamiltonInspectionNumber;
                string flange = ""; if (!lateralRow.IsFlangeNull()) flange = lateralRow.Flange;
                string gasket = ""; if (!lateralRow.IsGasketNull()) gasket = lateralRow.Gasket;
                string depthOfLocated = ""; if (!lateralRow.IsDepthOfLocatedNull()) depthOfLocated = lateralRow.DepthOfLocated;
                bool digRequiredPriorToLining = lateralRow.DigRequiredPriorToLining;
                DateTime? digRequiredPriorToLiningCompleted = null; if (!lateralRow.IsDigRequiredPriorToLiningCompletedNull()) digRequiredPriorToLiningCompleted = lateralRow.DigRequiredPriorToLiningCompleted;
                bool digRequiredAfterLining = lateralRow.DigRequiredAfterLining;
                DateTime? digRequiredAfterLiningCompleted = null; if (!lateralRow.IsDigRequiredAfterLiningCompletedNull()) digRequiredAfterLiningCompleted = lateralRow.DigRequiredAfterLiningCompleted;
                bool outOfScope = lateralRow.OutOfScope;
                bool holdClientIssue = lateralRow.HoldClientIssue;
                DateTime? holdClientIssueResolved = null; if (!lateralRow.IsHoldClientIssueResolvedNull()) holdClientIssueResolved = lateralRow.HoldClientIssueResolved;
                bool holdLFSIssue = lateralRow.HoldLFSIssue;
                DateTime? holdLFSIssueResolved = null; if (!lateralRow.IsHoldLFSIssueResolvedNull()) holdLFSIssueResolved = lateralRow.HoldLFSIssueResolved;
                bool requiresRoboticPrep = lateralRow.LateralRequiresRoboticPrep;
                DateTime? requiresRoboticPrepCompleted = null; if (!lateralRow.IsLateralRequiresRoboticPrepCompletedNull()) requiresRoboticPrepCompleted = lateralRow.LateralRequiresRoboticPrepCompleted;
                string linerType = ""; if (!lateralRow.IsLinerTypeNull()) linerType = lateralRow.LinerType;
                string prepType = ""; if (!lateralRow.IsPrepTypeNull()) prepType = lateralRow.PrepType;
                bool dyeTestReq = lateralRow.DyeTestReq;
                DateTime? dyeTestComplete = null; if (!lateralRow.IsDyeTestCompleteNull()) dyeTestComplete = lateralRow.DyeTestComplete;
                string contractYear = ""; if (!lateralRow.IsContractYearNull()) contractYear = lateralRow.ContractYear;
                
                WorkJunctionLiningLateral workJunctionLiningLateral = new WorkJunctionLiningLateral(null);
                workJunctionLiningLateral.InsertDirect(projectId, lateral_assetId, newSectionWorkId, pipeLocated, sevicesLocated, coInstalled, backfilledConcrete, backfilledSoil, grouted, cored, prepped, measured, linerSize, inProcess, inStock, delivered, buildRebuild, preVideo, linerInstalled, finalVideo, cost, videoInspection, coRequired, pitRequired, coPitLocation, postContractDigRequired, coCutDown, finalRestoration, false, companyId, comments, history, videoLengthToPropertyLine, liningThruCo, noticeDelivered, hamiltonInspectionNumber, flange, gasket, depthOfLocated, digRequiredPriorToLining, digRequiredPriorToLiningCompleted, digRequiredAfterLining, digRequiredAfterLiningCompleted, outOfScope, holdClientIssue, holdClientIssueResolved, holdLFSIssue, holdLFSIssueResolved, requiresRoboticPrep, requiresRoboticPrepCompleted, linerType, prepType, dyeTestReq, dyeTestComplete, contractYear);
            }

            // Load Previous work  - Comments and History
            SavePreviousComments(workId, workType, companyId, newSectionWorkId);
            SavePreviousHistory(workId, workType, companyId, newSectionWorkId);
        }



        /// <summary>
        /// Save Previous Comments
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="newSectionWorkId">newSectionWorkId</param>
        private void SavePreviousComments(int workId, string workType, int companyId, int newSectionWorkId)
        {
            WorkCommentsGateway workCommentsGateway = new WorkCommentsGateway();
            workCommentsGateway.LoadAllByWorkIdWorkType(workId, companyId, workType);

            foreach (WorkTDS.LFS_WORK_COMMENTRow commentRow in (WorkTDS.LFS_WORK_COMMENTDataTable)workCommentsGateway.Table)
            {
                int refId = commentRow.RefID;
                string type = ""; if (!commentRow.IsTypeNull()) type = commentRow.Type;
                string subject = commentRow.Subject;
                int userId = commentRow.UserID;
                DateTime? dateTime_ = null; if (!commentRow.IsDateTime_Null()) dateTime_ = commentRow.DateTime_;
                string comment = ""; if (!commentRow.IsCommentNull()) comment = commentRow.Comment;
                int? libraryFilesId = null; if (!commentRow.IsLIBRARY_FILES_IDNull()) libraryFilesId = commentRow.LIBRARY_FILES_ID;

                WorkComments workComments = new WorkComments();
                workComments.InsertDirect(newSectionWorkId, refId, type, subject, userId, dateTime_, comment, libraryFilesId, false, companyId, workType);
            }
        }



        /// <summary>
        /// Save Previous History
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="newSectionWorkId">newSectionWorkId</param>
        private void SavePreviousHistory(int workId, string workType, int companyId, int newSectionWorkId)
        {
            WorkHistoryGateway workHistoryGateway = new WorkHistoryGateway();
            workHistoryGateway.LoadAllByWorkIdWorkType(workId, companyId, workType);

            foreach (WorkTDS.LFS_WORK_HISTORYRow historyRow in (WorkTDS.LFS_WORK_HISTORYDataTable)workHistoryGateway.Table)
            {
                int refId = historyRow.RefID;
                string type = ""; if (!historyRow.IsTypeNull()) type = historyRow.Type;
                string subject = historyRow.Subject;
                int userId = historyRow.UserID;
                DateTime? dateTime_ = null; if (!historyRow.IsDateTime_Null()) dateTime_ = historyRow.DateTime_;
                string history = ""; if (!historyRow.IsHistoryNull()) history = historyRow.History;
                int? libraryFilesId = null; if (!historyRow.IsLIBRARY_FILES_IDNull()) libraryFilesId = historyRow.LIBRARY_FILES_ID;

                WorkHistory workHistory = new WorkHistory();
                workHistory.InsertDirect(newSectionWorkId, refId, type, subject, userId, dateTime_, history, libraryFilesId, false, companyId, workType);
            }
        }



    }
}