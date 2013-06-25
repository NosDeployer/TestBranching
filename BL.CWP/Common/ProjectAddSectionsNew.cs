using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// ProjectAddSectionsNew
    /// </summary>
    public class ProjectAddSectionsNew : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectAddSectionsNew() : base("ProjectAddSectionsNew")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectAddSectionsNew(DataSet data) : base(data, "ProjectAddSectionsNew")
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
        /// Insert a section
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <param name="street">street</param>
        /// <param name="usmh">usmh</param>
        /// <param name="dsmh">dsmh</param>
        /// <param name="rehabAssessmentWork">rehabAssessmentWork</param>
        /// <param name="fulllengthLiningWork">fulllengthLiningWork</param>
        /// <param name="pointRepairsWork">pointRepairsWork</param>
        /// <param name="junctionLiningWork">junctionLiningWork</param>
        /// <param name="deleted">deleted</param>
        /// <param name="flowOrderId">flowOrderId</param>
        /// <param name="mapSize">mapSize</param>
        /// <param name="mapLength">mapLength</param>
        /// 
        /// <param name="usmhStreet">usmhStreet</param>
        /// <param name="usmhLatitude">usmhLatitude</param>
        /// <param name="usmhLongitude">usmhLongitude</param>
        /// <param name="usmhShape">usmhShape</param>
        /// <param name="usmhLocation">usmhLocation</param>
        /// <param name="usmhConditionRating">usmhConditionRating</param>
        /// <param name="usmhMaterialId">usmhMaterialId</param>
        /// <param name="usmhMaterial">usmhMaterial</param>
        /// <param name="usmhTopDiameter">usmhTopDiameter</param>
        /// <param name="usmhTopDepth">usmhTopDepth</param>
        /// <param name="usmhDownDiameter"usmhDownDiameter>usmhDownDiameter</param>
        /// <param name="usmhDownDepth">usmhDownDepth</param>
        /// <param name="usmhManholeRugs">usmhManholeRugs</param>
        /// <param name="usmhRectangle1LongSide">usmhRectangle1LongSide</param>
        /// <param name="usmhRectangle1ShortSide">usmhRectangle1ShortSide</param>
        /// <param name="usmhRectangle2LongSide">usmhRectangle2LongSide</param>
        /// <param name="usmhRectangle2shortSide">usmhRectangle2ShortSide</param>
        /// <param name="usmhTotalSurfaceArea">usmhTotalSurfaceArea</param>
        /// 
        /// <param name="dsmhStreet">dsmhStreet</param>
        /// <param name="dsmhLatitude">dsmhLatitude</param>
        /// <param name="dsmhLongitude">dsmhLongitude</param>
        /// <param name="dsmhShape">dsmhShape</param>
        /// <param name="dsmhLocation">dsmhLocation</param>
        /// <param name="dsmhConditionRating">dsmhConditionRating</param>
        /// <param name="dsmhMaterialId">dsmhMaterialId</param>
        /// <param name="dsmhMaterial">dsmhMaterial</param>
        /// <param name="dsmhTopDiameter">dsmhTopDiameter</param>
        /// <param name="dsmhTopDepth">dsmhTopDepth</param>
        /// <param name="dsmhDownDiameter"dsmhDownDiameter>dsmhDownDiameter</param>
        /// <param name="dsmhDownDepth">dsmhDownDepth</param>
        /// <param name="dsmhManholeRugs">dsmhManholeRugs</param>
        /// <param name="dsmhRectangle1LongSide">dsmhRectangle1LongSide</param>
        /// <param name="dsmhRectangle1ShortSide">dsmhRectangle1ShortSide</param>
        /// <param name="dsmhRectangle2LongSide">dsmhRectangle2LongSide</param>
        /// <param name="dsmhRectangle2ShortSide">dsmhRectangle2ShortSide</param>
        /// <param name="dsmhTotalSurfaceArea">dsmhTotalSurfaceArea</param>
        /// <param name="sectionMaterial">sectionMaterial</param>
        /// <param name="clientId">clientId</param>
        public void Insert(string sectionId, string street, string usmh, string dsmh, bool rehabAssessmentWork, bool fulllengthLiningWork, bool pointRepairsWork, bool junctionLiningWork, bool deleted, string flowOrderId, string mapSize, string mapLength, string usmhStreet, string usmhLatitude, string usmhLongitude, string usmhShape, string usmhLocation, int? usmhConditionRating, int? usmhMaterialId, string usmhMaterial, string usmhTopDiameter, string usmhTopDepth, string usmhDownDiameter, string usmhDownDepth, int? usmhManholeRugs, string usmhRectangle1LongSide, string usmhRectangle1ShortSide, string usmhRectangle2LongSide, string usmhRectangle2ShortSide, string usmhTotalSurfaceArea, string dsmhStreet, string dsmhLatitude, string dsmhLongitude, string dsmhShape, string dsmhLocation, int? dsmhConditionRating, int? dsmhMaterialId, string dsmhMaterial, string dsmhTopDiameter, string dsmhTopDepth, string dsmhDownDiameter, string dsmhDownDepth, int? dsmhManholeRugs, string dsmhRectangle1LongSide, string dsmhRectangle1ShortSide, string dsmhRectangle2LongSide, string dsmhRectangle2ShortSide, string dsmhTotalSurfaceArea, string sectionMaterial, string clientId, bool mHRehabUsmh, bool mHRehabDsmh)
        {
            ProjectAddSectionsTDS.ProjectAddSectionsNewRow row = ((ProjectAddSectionsTDS.ProjectAddSectionsNewDataTable)Table).NewProjectAddSectionsNewRow();

            row.ID = GetNewId();
            row.SectionID = sectionId;
            if (street.Trim() != "") row.Street = street; else row.SetStreetNull();
            if (usmh.Trim() != "") row.USMH = usmh; else row.SetUSMHNull();
            if (dsmh.Trim() != "") row.DSMH = dsmh; else row.SetDSMHNull();
            row.JunctionLiningWork = junctionLiningWork;
            row.RehabAssessmentWork = rehabAssessmentWork;
            row.FulllengthLiningWork = fulllengthLiningWork;
            row.PointRepairsWork = pointRepairsWork;
            row.Deleted = deleted;
            row.FlowOrderID = flowOrderId;
            if (mapSize.Trim() != "") row.MapSize = mapSize; else row.SetMapSizeNull();
            if (mapLength.Trim() != "") row.MapLength = mapLength; else row.SetMapLengthNull();
            if (sectionMaterial.Trim() != "") row.SectionMaterial = sectionMaterial; else row.SetSectionMaterialNull();
            if (clientId.Trim() != "") row.ClientId = clientId; else row.SetClientIdNull(); 

            // Structure data
            if (usmhStreet.Trim() != "") row.UsmhStreet = usmhStreet; else row.SetUsmhStreetNull();
            if (usmhLatitude.Trim() != "") row.UsmhLatitude = usmhLatitude; else row.SetUsmhLatitudeNull();
            if (usmhLongitude.Trim() != "") row.UsmhLongitude = usmhLongitude; else row.SetUsmhLongitudeNull();
            if (usmhShape.Trim() != "") row.UsmhShape = usmhShape; else row.SetUsmhShapeNull();
            if (usmhLocation.Trim() != "") row.UsmhLocation = usmhLocation; else row.SetUsmhLocationNull();
            if (usmhConditionRating.HasValue) row.UsmhConditionRating = (int)usmhConditionRating; else row.SetUsmhConditionRatingNull();
            if (usmhMaterialId.HasValue) row.UsmhMaterialId = (int)usmhMaterialId; else row.SetUsmhMaterialIdNull();
            if (usmhMaterial.Trim() != "") row.UsmhMaterialType = usmhMaterial; else row.SetUsmhMaterialTypeNull();
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
            if (dsmhMaterial.Trim() != "") row.DsmhMaterialType = dsmhMaterial; else row.SetDsmhMaterialTypeNull();
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
            row.MHRehabUsmh = mHRehabUsmh;
            row.MHRehabDsmh = mHRehabDsmh;

            ((ProjectAddSectionsTDS.ProjectAddSectionsNewDataTable)Table).AddProjectAddSectionsNewRow(row);
        }



        /// <summary>
        /// Update a section
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="street">street</param>
        /// <param name="usmh">usmh</param>
        /// <param name="dsmh">dsmh</param>
        /// <param name="junctionLiningWork">junctionLiningWork</param>
        /// <param name="rehabAssessmentWork">rehabAssessmentWork</param>
        /// <param name="fulllengthLiningWork">fulllengthLiningWork</param>
        /// <param name="pointRepairsWork">pointRepairsWork</param>
        /// <param name="deleted">deleted</param>
        /// <param name="flowOrderId">flowOrderId</param>
        /// <param name="mapSize">mapSize</param>
        /// <param name="mapLength">mapLength</param>
        /// 
        /// <param name="usmhStreet">usmhStreet</param>
        /// <param name="usmhLatitude">usmhLatitude</param>
        /// <param name="usmhLongitude">usmhLongitude</param>
        /// <param name="usmhShape">usmhShape</param>
        /// <param name="usmhLocation">usmhLocation</param>
        /// <param name="usmhConditionRating">usmhConditionRating</param>
        /// <param name="usmhMaterialId">usmhMaterialId</param>
        /// <param name="usmhMaterial">usmhMaterial</param>
        /// <param name="usmhTopDiameter">usmhTopDiameter</param>
        /// <param name="usmhTopDepth">usmhTopDepth</param>
        /// <param name="usmhDownDiameter"usmhDownDiameter>usmhDownDiameter</param>
        /// <param name="usmhDownDepth">usmhDownDepth</param>
        /// <param name="usmhManholeRugs">usmhManholeRugs</param>
        /// <param name="usmhRectangle1LongSide">usmhRectangle1LongSide</param>
        /// <param name="usmhRectangle1ShortSide">usmhRectangle1ShortSide</param>
        /// <param name="usmhRectangle2LongSide">usmhRectangle2LongSide</param>
        /// <param name="usmhRectangle2shortSide">usmhRectangle2ShortSide</param>
        /// <param name="usmhTotalSurfaceArea">usmhTotalSurfaceArea</param>
        /// 
        /// <param name="dsmhStreet">dsmhStreet</param>
        /// <param name="dsmhLatitude">dsmhLatitude</param>
        /// <param name="dsmhLongitude">dsmhLongitude</param>
        /// <param name="dsmhShape">dsmhShape</param>
        /// <param name="dsmhLocation">dsmhLocation</param>
        /// <param name="dsmhConditionRating">dsmhConditionRating</param>
        /// <param name="dsmhMaterialId">dsmhMaterialId</param>
        /// <param name="dsmhMaterial">dsmhMaterial</param>
        /// <param name="dsmhTopDiameter">dsmhTopDiameter</param>
        /// <param name="dsmhTopDepth">dsmhTopDepth</param>
        /// <param name="dsmhDownDiameter"dsmhDownDiameter>dsmhDownDiameter</param>
        /// <param name="dsmhDownDepth">dsmhDownDepth</param>
        /// <param name="dsmhManholeRugs">dsmhManholeRugs</param>
        /// <param name="dsmhRectangle1LongSide">dsmhRectangle1LongSide</param>
        /// <param name="dsmhRectangle1ShortSide">dsmhRectangle1ShortSide</param>
        /// <param name="dsmhRectangle2LongSide">dsmhRectangle2LongSide</param>
        /// <param name="dsmhRectangle2ShortSide">dsmhRectangle2ShortSide</param>
        /// <param name="dsmhTotalSurfaceArea">dsmhTotalSurfaceArea</param>
        /// <param name="sectionMaterial">sectionMaterial</param>
        /// <param name="clientId">clientId</param>
        public void Update(int id, string sectionId, string street, string usmh, string dsmh, bool junctionLiningWork, bool rehabAssessmentWork, bool fulllengthLiningWork, bool pointRepairsWork, bool deleted, string flowOrderId, string mapSize, string mapLength, string usmhStreet, string usmhLatitude, string usmhLongitude, string usmhShape, string usmhLocation, int? usmhConditionRating, int? usmhMaterialId, string usmhMaterial, string usmhTopDiameter, string usmhTopDepth, string usmhDownDiameter, string usmhDownDepth, int? usmhManholeRugs, string usmhRectangle1LongSide, string usmhRectangle1ShortSide, string usmhRectangle2LongSide, string usmhRectangle2ShortSide, string usmhTotalSurfaceArea, string dsmhStreet, string dsmhLatitude, string dsmhLongitude, string dsmhShape, string dsmhLocation, int? dsmhConditionRating, int? dsmhMaterialId, string dsmhMaterial, string dsmhTopDiameter, string dsmhTopDepth, string dsmhDownDiameter, string dsmhDownDepth, int? dsmhManholeRugs, string dsmhRectangle1LongSide, string dsmhRectangle1ShortSide, string dsmhRectangle2LongSide, string dsmhRectangle2ShortSide, string dsmhTotalSurfaceArea, string sectionMaterial, string clientId, bool mHRehabUsmh, bool mHRehabDsmh)
        {
            ProjectAddSectionsTDS.ProjectAddSectionsNewRow row = GetRow(id);

            row.SectionID = sectionId;
            if (street.Trim() != "") row.Street = street; else row.SetStreetNull();
            if (usmh.Trim() != "") row.USMH = usmh; else row.SetUSMHNull();
            if (dsmh.Trim() != "") row.DSMH = dsmh; else row.SetDSMHNull();
            row.JunctionLiningWork = junctionLiningWork;
            row.RehabAssessmentWork = rehabAssessmentWork;
            row.FulllengthLiningWork = fulllengthLiningWork;
            row.PointRepairsWork = pointRepairsWork;
            row.MHRehabUsmh = mHRehabUsmh;
            row.MHRehabDsmh = mHRehabDsmh;
            row.Deleted = deleted;
            row.FlowOrderID = flowOrderId;
            if (mapSize.Trim() != "") row.MapSize = mapSize; else row.SetMapSizeNull();
            if (mapLength.Trim() != "") row.MapLength = mapLength; else row.SetMapLengthNull();
            if (sectionMaterial.Trim() != "") row.SectionMaterial = sectionMaterial; else row.SetSectionMaterialNull();
            if (clientId.Trim() != "") row.ClientId = clientId; else row.SetClientIdNull();           

            // Structure data
            if (usmhStreet.Trim() != "") row.UsmhStreet = usmhStreet; else row.SetUsmhStreetNull();
            if (usmhLatitude.Trim() != "") row.UsmhLatitude = usmhLatitude; else row.SetUsmhLatitudeNull();
            if (usmhLongitude.Trim() != "") row.UsmhLongitude = usmhLongitude; else row.SetUsmhLongitudeNull();
            if (usmhShape.Trim() != "") row.UsmhShape = usmhShape; else row.SetUsmhShapeNull();
            if (usmhLocation.Trim() != "") row.UsmhLocation = usmhLocation; else row.SetUsmhLocationNull();
            if (usmhConditionRating.HasValue) row.UsmhConditionRating = (int)usmhConditionRating; else row.SetUsmhConditionRatingNull();
            if (usmhMaterialId.HasValue) row.UsmhMaterialId = (int)usmhMaterialId; else row.SetUsmhMaterialIdNull();
            if (usmhMaterial.Trim() != "") row.UsmhMaterialType = usmhMaterial; else row.SetUsmhMaterialTypeNull();
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
            if (dsmhMaterial.Trim() != "") row.DsmhMaterialType = dsmhMaterial; else row.SetDsmhMaterialTypeNull();
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
        }



        /// <summary>
        /// Delete a section
        /// </summary>
        /// <param name="id">id</param>
        public void Delete(int id)
        {
            ProjectAddSectionsTDS.ProjectAddSectionsNewRow row = GetRow(id);

            row.Deleted = true;
        }



        /// <summary>
        /// Verify in a section exists for inserting
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
        /// <param name="id">internal id</param>
        /// <returns>Row</returns>
        private ProjectAddSectionsTDS.ProjectAddSectionsNewRow GetRow(int id)
        {
            ProjectAddSectionsTDS.ProjectAddSectionsNewRow row = ((ProjectAddSectionsTDS.ProjectAddSectionsNewDataTable)Table).FindByID(id);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Common.ProjectAddSectionsNew.GetRow");
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

            foreach (ProjectAddSectionsTDS.ProjectAddSectionsNewRow row in (ProjectAddSectionsTDS.ProjectAddSectionsNewDataTable)Table)
            {
                if (newId < row.ID)
                {
                    newId = row.ID;
                }
            }

            newId++;

            return newId;
        }


                
    }
}