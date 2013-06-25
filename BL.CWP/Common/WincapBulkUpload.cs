using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.BL.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WincapBulkUpload
    /// </summary>
    public class WincapBulkUpload : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WincapBulkUpload() : base("WincapBulkUpload")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WincapBulkUpload(DataSet data)
            : base(data, "WincapBulkUpload")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WincapBulkUploadTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="street">street</param>
        /// <param name="clientId">clientId</param>
        /// <param name="subArea">subArea</param>
        /// <param name="usmh">usmh</param>
        /// <param name="dsmh">dsmh</param>
        /// <param name="mapSize">mapSize</param>
        /// <param name="confirmedSize">confirmedSize</param>
        /// <param name="mapLength">mapLength</param>
        /// <param name="actualLength">actualLength</param>
        /// <param name="raWork">raWork</param>
        /// <param name="raComments">raComments</param>
        /// <param name="fllWork">fllWork</param>
        /// <param name="fllComments">fllComments</param>
        /// <param name="jlWork">jlWork</param>
        public void Insert(string id, string sectionId, string state, string direction, string distance, string videoDistance, string clockPosition, string distanceToCentre, string reverseSetup, string comments)
        {
            WincapBulkUploadTDS.WincapBulkUploadRow row = ((WincapBulkUploadTDS.WincapBulkUploadDataTable)Table).NewWincapBulkUploadRow();

            row.ID = id;

            row.SectionID = sectionId;

            if (state != "")
            {
                if (state.EndsWith("A") || state.EndsWith("D") || state.EndsWith("I"))
                {
                    state = "Live";
                }

                if (state.EndsWith("B"))
                {
                    state = "Undefined";
                }

                if (state.EndsWith("C"))
                {
                    state = "Visible Plugged";
                }

                row.State = state;
            }

            if (direction != "")
            {
                row.Direction = direction;

                if (direction == "D")
                {
                    if (distance != "")
                    {
                        row.Distance = distance;
                        row.DistanceFromDSMH = distance;
                        row.SetDistanceFromUSMHNull();
                    }
                    else
                    {
                        row.SetDistanceNull();
                        row.SetDistanceFromDSMHNull();
                        row.SetDistanceFromUSMHNull();
                    }
                }
                else
                {
                    if (distance != "")
                    {
                        row.Distance = distance;
                        row.DistanceFromUSMH = distance;
                        row.SetDistanceFromDSMHNull();
                    }
                    else
                    {
                        row.SetDistanceNull();
                        row.SetDistanceFromUSMHNull();
                        row.SetDistanceFromDSMHNull();
                    }
                }
            }
            else
            {
                row.SetDirectionNull();
                row.SetDistanceFromUSMHNull();
                row.SetDistanceFromDSMHNull();
                row.SetDistanceNull();
            }

            if (videoDistance.Trim() != "") row.VideoDistance = videoDistance; else row.SetVideoDistanceNull();
            if (clockPosition.Trim() != "") row.ClockPosition = clockPosition; else row.SetClockPositionNull();
            if (distanceToCentre.Trim() != "") row.DistanceToCentre = distanceToCentre; else row.SetDistanceToCentreNull();
            if (reverseSetup.Trim() != "") row.ReverseSetup = reverseSetup; else row.SetReverseSetupNull();
            if (comments.Trim() != "") row.Comments = comments; else row.SetCommentsNull();
            ((WincapBulkUploadTDS.WincapBulkUploadDataTable)Table).AddWincapBulkUploadRow(row);
        }



        
        /// <summary>
        /// GetSectionsSummary
        /// </summary>
        /// <param name="header">header</param>
        /// <returns></returns>
        public string GetSectionsSummary(string header)
        {
            string sectionsSummary = header + "\n";

            foreach (WincapBulkUploadTDS.WincapBulkUploadRow row in (WincapBulkUploadTDS.WincapBulkUploadDataTable)Table)
            {
                string sectionId = row.SectionID;
                string state = "(empty)"; if (!row.IsStateNull()) state = row.State;
                string direction = "(empty)"; if (!row.IsDirectionNull()) direction = row.Direction;
                string distance = "(empty)"; if (!row.IsDistanceNull()) distance = row.Distance;
                string videoDistance = "(empty)"; if (!row.IsVideoDistanceNull()) videoDistance = row.VideoDistance;
                string clockPosition = "(empty)"; if (!row.IsClockPositionNull()) clockPosition = row.ClockPosition;
                string distanceToCentre = "(empty)"; if (!row.IsDistanceToCentreNull()) distanceToCentre = row.DistanceToCentre;
                string reverseSetup = "(empty)"; if (!row.IsReverseSetupNull()) reverseSetup = row.ReverseSetup;
                string comments = "(empty)"; if (!row.IsCommentsNull()) comments = row.Comments;
                               
                sectionsSummary = sectionsSummary + "- " + sectionId + ", " + state + ", " + direction + ", " + distance + ", " + videoDistance + ", " + clockPosition + ", " + distanceToCentre + ", " + reverseSetup + ", " + comments + "\n";
                
            }
            return sectionsSummary;
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="loginId">loginId</param>
        public void Save(int projectId, Int64 countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int companyId, int loginId)
        {
            FullLengthLiningTDS fullLengthLiningTDS = new FullLengthLiningTDS();
            
            foreach (WincapBulkUploadTDS.WincapBulkUploadRow row in (WincapBulkUploadTDS.WincapBulkUploadDataTable)Table)
            {
                string state = ""; if (!row.IsStateNull()) state = row.State;
                string direction = ""; if (!row.IsDirectionNull()) direction = row.Direction;
                string distance = ""; if (!row.IsDistanceNull()) distance = row.Distance;
                string videoDistance = ""; if (!row.IsVideoDistanceNull()) videoDistance = row.VideoDistance;
                string clockPosition = ""; if (!row.IsClockPositionNull()) clockPosition = row.ClockPosition;
                string distanceToCentre = ""; if (!row.IsDistanceToCentreNull()) distanceToCentre = row.DistanceToCentre;
                string reverseSetup = ""; if (!row.IsReverseSetupNull()) reverseSetup = row.ReverseSetup;
                string comments = ""; if (!row.IsCommentsNull()) comments = row.Comments;
                string measuredFromMh = "USMH";
                if (row.Direction.Contains("D"))
                {
                    measuredFromMh = "DSMH";
                }

                int section_assetId = SaveSection(row.SectionID, projectId, countryId, provinceId, countyId, cityId, companyId);

                WorkFullLengthLining workFullLengthLining = new WorkFullLengthLining(null);
                int workId = workFullLengthLining.InsertDirectEmptyWorks(projectId, section_assetId, null, "", null, null, null, null, null, null, null, false, false, false, false, false, false, false, companyId, false, "", "");

                FullLengthLiningLateralDetails flLateralDetails = new FullLengthLiningLateralDetails();
                flLateralDetails.LoadForEdit(workId, section_assetId, companyId, projectId);

                // Generate increment
                string lateralIdIncrement = "";

                if (measuredFromMh == "USMH" || measuredFromMh == "")
                {
                    lateralIdIncrement = flLateralDetails.GetMaxLateralId2();
                }
                else
                {
                    if (measuredFromMh == "DSMH")
                    {
                        lateralIdIncrement = flLateralDetails.GetMinLateralId2();
                    }
                }

                string videoLength = "";

                string lateralId = "FL-" + lateralIdIncrement;
                
                FullLengthLiningLateralDetails model = new FullLengthLiningLateralDetails(fullLengthLiningTDS);
                model.Insert(videoDistance, clockPosition, distanceToCentre, "", reverseSetup, null, comments, lateralId, "", "", false, companyId, true, state, "", "", "", "", null, false, null, false, false, false, "", false, false, null);

                model.Save(workId, projectId, section_assetId, countryId, provinceId, countyId, cityId, videoLength, companyId, false, false, null);                
            }
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
        private int SaveSection(string flowOrderId, int projectId, Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int companyId)
        {            
            // insert section
            string sectionId = GetSectionId(countryId, provinceId, countyId, cityId, Convert.ToInt32(flowOrderId), companyId);

            LfsAssetSewerSection lfsAssetSewerSection = new LfsAssetSewerSection(null);            
            int section_assetId = lfsAssetSewerSection.InsertDirect(countryId, provinceId, countyId, cityId, sectionId, "", null, null, "", "", "", "", null, null, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", false, companyId, "", "", -1, "", DateTime.Now);

            return section_assetId;
        }



        /// <summary>
        /// GetSectionId
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>nextSectionId</returns>
        private string GetSectionId(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int flowOrderId, int companyId)
        {
            string sectionId = "";

            // Locations string
            string location = "";
            if (!countryId.HasValue) location = location + "0."; else location = location + countryId.ToString() + ".";
            if (!provinceId.HasValue) location = location + "0."; else location = location + provinceId.ToString() + ".";
            if (!countyId.HasValue) location = location + "0."; else location = location + countyId.ToString() + ".";
            if (!cityId.HasValue) location = location + "0"; else location = location + cityId.ToString();
            location = location + "-";

            // ... Get next secuential number
            string newSecuentialNumber = flowOrderId.ToString();

            // complete string with 0
            for (int i = flowOrderId.ToString().Length; i < 6; i++)
            {
                newSecuentialNumber = "0" + newSecuentialNumber;
            }

            // next sectionId
            sectionId = location + newSecuentialNumber;

            return sectionId;
        }


                
    }
}