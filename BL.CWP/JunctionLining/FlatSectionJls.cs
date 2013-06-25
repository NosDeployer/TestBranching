using System;
using System.Collections;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.JunctionLining
{
    /// <summary>
    /// FlatSectionJls
    /// </summary>
    public class FlatSectionJls : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlatSectionJls() : base("FlatSectionJls")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlatSectionJls(DataSet data) : base(data, "FlatSectionJls")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlatSectionJlsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByWorkIdArrayList
        /// </summary>
        /// <param name="workIdArrayList">workIdArrayList</param>
        /// <param name="selected">selected</param>
        /// <param name="companyId">companyId</param>
        public void LoadByWorkIdArrayList(ArrayList workIdArrayList, int selected, int companyId)
        {
            FlatSectionJlsGateway flatSectionJlsGateway = new FlatSectionJlsGateway(Data);

            flatSectionJlsGateway.Table.Clear();
            flatSectionJlsGateway.ClearBeforeFill = false;

            foreach (JlsId jlsId in workIdArrayList)
            {
                flatSectionJlsGateway.LoadByWorkId(jlsId.workId, selected, companyId);
            }

            flatSectionJlsGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// UpdateSelected
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="selected">selected</param>
        public void UpdateSelected(int workId, bool selected)
        {
            FlatSectionJlsTDS.FlatSectionJlsRow flatSectionJlsRow = GetRow(workId);
            flatSectionJlsRow.Selected = selected;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="street">street</param>
        /// <param name="usmhId">usmhId</param>
        /// <param name="dsmhId">dsmhId</param>
        /// <param name="size_">size_</param>
        /// <param name="length">length</param>
        /// <param name="subArea">subArea</param>
        /// <param name="trafficControl">trafficControl</param>
        /// <param name="trafficControlDetails">trafficControlDetails</param>
        /// <param name="standardBypass">standardBypass</param>
        /// <param name="standardBypassComments">standardBypassComments</param>
        public void Update(int workId, string street, string usmhId, string dsmhId, string size_, string length, string subArea, string trafficControl, string trafficControlDetails, bool standardBypass, string standardBypassComments)
        {
            FlatSectionJlsTDS.FlatSectionJlsRow row = GetRow(workId);

            if (street.Trim() != "") row.Street = street.Trim(); else row.SetStreetNull();
            if (usmhId.Trim() != "") row.USMHID = usmhId.Trim(); else row.SetUSMHIDNull();
            if (dsmhId.Trim() != "") row.DSMHID = dsmhId.Trim(); else row.SetDSMHIDNull();
            if (length.Trim() != "") row.Length = length.Trim(); else row.SetLengthNull();
            if (size_.Trim() != "") row.Size_ = size_.Trim(); else row.SetSize_Null();
            if (subArea.Trim() != "") row.SubArea = subArea.Trim(); else row.SetSubAreaNull();
            if (trafficControl.Trim() != "") row.TrafficControl = trafficControl.Trim(); else row.SetTrafficControlNull();
            if (trafficControlDetails.Trim() != "") row.TrafficControlDetails = trafficControlDetails.Trim(); else row.SetTrafficControlDetailsNull();
            row.StandardBypass = standardBypass;
            if (standardBypassComments.Trim() != "") row.StandardBypassComments = standardBypassComments.Trim(); else row.SetStandardBypassCommentsNull();
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public void UpdateDirect(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int projectId, int companyId)
        {
            FlatSectionJlsTDS flatSectionJlsChanges = (FlatSectionJlsTDS)Data.GetChanges();
            if (flatSectionJlsChanges.FlatSectionJls.Rows.Count > 0)
            {
                FlatSectionJlsGateway flatSectionJlsGateway = new FlatSectionJlsGateway(flatSectionJlsChanges);

                // Update Jls
                foreach (FlatSectionJlsTDS.FlatSectionJlsRow flatSectionJlsRow in (FlatSectionJlsTDS.FlatSectionJlsDataTable)flatSectionJlsChanges.FlatSectionJls)
                {
                    // ... Unchanged values
                    int workId = flatSectionJlsRow.WorkID;
                    int assetId = flatSectionJlsGateway.GetAssetId(workId);
                    string sectionId = flatSectionJlsGateway.GetSectionId(workId);
                    int? usmh = flatSectionJlsGateway.GetUsmhOriginal(workId);
                    int? dsmh = flatSectionJlsGateway.GetDsmhOriginal(workId);
                    int numLats = flatSectionJlsGateway.GetNumLats(workId);
                    int notLinedYet = flatSectionJlsGateway.GetNotLinedYet(workId);
                    bool allMeasured = flatSectionJlsGateway.GetAllMeasured(workId);
                    string issueWithLaterals = flatSectionJlsGateway.GetIssueWithLaterals(workId);
                    int notMeasuredYet = flatSectionJlsGateway.GetNotMeasuredYet(workId);
                    int notDeliveredYet = flatSectionJlsGateway.GetNotDeliveredYet(workId);
                    int availableToLine = flatSectionJlsGateway.GetAvailableToLine(workId);

                    // ... Original values
                    string originalStreet = flatSectionJlsGateway.GetStreetOriginal(workId);
                    string originalUsmhId = flatSectionJlsGateway.GetUsmhIdOriginal(workId);
                    string originalDsmhId = flatSectionJlsGateway.GetDsmhIdOriginal(workId);
                    string originalSize_ = flatSectionJlsGateway.GetSize_Original(workId);
                    string originalLength = flatSectionJlsGateway.GetLengthOriginal(workId);
                    string originalSubArea = flatSectionJlsGateway.GetSubAreaOriginal(workId);
                    string originalTrafficControl = flatSectionJlsGateway.GetTrafficControlOriginal(workId);
                    string originalTrafficControlDetails = flatSectionJlsGateway.GetTrafficControlDetailsOriginal(workId);
                    bool originalStandardBypass = flatSectionJlsGateway.GetStandardBypassOriginal(workId);
                    string originalStandardBypassComments = flatSectionJlsGateway.GetStandardBypassCommentsOriginal(workId);

                    // ... New variables
                    string newStreet = flatSectionJlsGateway.GetStreet(workId);
                    string newUsmhId = flatSectionJlsGateway.GetUsmhId(workId);
                    string newDsmhId = flatSectionJlsGateway.GetDsmhId(workId);
                    string newSize_ = flatSectionJlsGateway.GetSize_(workId);
                    string newLength = flatSectionJlsGateway.GetLength(workId);
                    string newSubArea = flatSectionJlsGateway.GetSubArea(workId);
                    string newTrafficControl = flatSectionJlsGateway.GetTrafficControl(workId);
                    string newTrafficControlDetails = flatSectionJlsGateway.GetTrafficControlDetails(workId);
                    bool newStandardBypass = flatSectionJlsGateway.GetStandardBypass(workId);
                    string newStandardBypassComments = flatSectionJlsGateway.GetStandardBypassComments(workId);

                    // ... Update
                    Update(countryId, provinceId, countyId, cityId, projectId, workId, assetId, sectionId, numLats, notLinedYet, allMeasured, issueWithLaterals, notMeasuredYet, notDeliveredYet, usmh, originalUsmhId, dsmh, originalDsmhId, originalStreet, originalSize_, originalLength, originalSubArea, originalTrafficControl, originalTrafficControlDetails, originalStandardBypass, originalStandardBypassComments, availableToLine, newUsmhId, newDsmhId, newStreet, newSize_, newLength, newSubArea, newTrafficControl, newTrafficControlDetails, newStandardBypass, newStandardBypassComments, companyId);
                }
            }
        }


                
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="workId">workId</param>
        public void Delete(int workId)
        {
            FlatSectionJlsTDS.FlatSectionJlsRow row = GetRow(workId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int companyId)
        {
            FlatSectionJlsTDS flatSectionJlsChanges = (FlatSectionJlsTDS)Data.GetChanges();
            if (flatSectionJlsChanges.FlatSectionJls.Rows.Count > 0)
            {
                FlatSectionJlsGateway flatSectionJlsGateway = new FlatSectionJlsGateway(flatSectionJlsChanges);

                // Update sections
                foreach (FlatSectionJlsTDS.FlatSectionJlsRow flatSectionJlsRow in (FlatSectionJlsTDS.FlatSectionJlsDataTable)flatSectionJlsChanges.FlatSectionJls)
                {
                    if ((flatSectionJlsRow.Selected) && (flatSectionJlsRow.Deleted))
                    {
                        // ... Get values
                        int workId = flatSectionJlsRow.WorkID;
                        int assetId = flatSectionJlsRow.AssetID;

                        // ... Delete
                        Delete(workId, assetId, companyId);
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single FlatSectionJlsRow. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Row obtained</returns>
        private FlatSectionJlsTDS.FlatSectionJlsRow GetRow(int workId)
        {
            FlatSectionJlsTDS.FlatSectionJlsRow flatSectionJlsRow = ((FlatSectionJlsTDS.FlatSectionJlsDataTable)Table).FindByWorkID(workId);

            if (flatSectionJlsRow == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.JunctionLining.FlatSectionJls.GetRow");
            }

            return flatSectionJlsRow;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="workId">workId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="numLats">numLats</param>
        /// <param name="notLinedYet">notLinedYet</param>
        /// <param name="allMeasured">allMeasured</param>
        /// <param name="issueWithLaterals">issueWithLaterals</param>
        /// <param name="notMeasuredYet">notMeasuredYet</param>
        /// <param name="notDeliveredYet">notDeliveredYet</param>
        /// <param name="originalUsmh">originalUsmh</param>
        /// <param name="originalUsmhId">originalUsmhId</param>
        /// <param name="originalDsmh">originalDsmh</param>
        /// <param name="originalDsmhId">originalDsmhId</param>
        /// <param name="originalStreet">originalStreet</param>
        /// <param name="originalSize_">originalSize_</param>
        /// <param name="originalLength">originalLength</param>
        /// <param name="originalSubArea">originalSubArea</param>
        /// <param name="originalTrafficControl">originalTrafficControl</param>
        /// <param name="originalTrafficControlDetails">originalTrafficControlDetails</param>
        /// <param name="originalStandardBypass">originalStandardBypass</param>
        /// <param name="originalStandardBypassComments">originalStandardBypassComments</param>
        /// <param name="availableToLine">availableToLine</param>
        /// 
        /// <param name="newUsmhId">newUsmhId</param>
        /// <param name="newDsmhId">newDsmhId</param>
        /// <param name="newStreet">newStreet</param>
        /// <param name="newSize_">newSize_</param>
        /// <param name="newLength">newLength</param>
        /// <param name="newSubArea">newSubArea</param>
        /// <param name="newTrafficControl">newTrafficControl</param>
        /// <param name="newTrafficControlDetails">newTrafficControlDetails</param>
        /// <param name="newStandardBypass">newStandardBypass</param>
        /// <param name="newStandardBypassComments">newStandardBypassComments</param>
        /// <param name="companyId">companyId</param>
        private void Update(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int projectId, int workId, int assetId, string sectionId, int numLats, int notLinedYet, bool allMeasured, string issueWithLaterals, int notMeasuredYet, int notDeliveredYet, int? originalUsmh, string originalUsmhId, int? originalDsmh, string originalDsmhId, string originalStreet, string originalSize_, string originalLength, string originalSubArea, string originalTrafficControl, string originalTrafficControlDetails, bool originalStandardBypass, string originalStandardBypassComments, int availableToLine, string newUsmhId, string newDsmhId, string newStreet, string newSize_, string newLength, string newSubArea, string newTrafficControl, string newTrafficControlDetails, bool newStandardBypass, string newStandardBypassComments, int companyId)
        {
            // insert USMH if data change (only if not exists)
            int? newUsmh = originalUsmh;
            if (originalUsmhId != newUsmhId)
            {
                if (newUsmhId.Trim() != "")
                {
                    LfsAssetSewerMH lfsAssetSewerUsmh = new LfsAssetSewerMH(null);
                    newUsmh = lfsAssetSewerUsmh.InsertDirect(countryId, provinceId, countyId, cityId, newUsmhId, "", "", "", false, companyId, "", "", null, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", null, "", "", null);
                }
                else
                {
                    newUsmh = null;
                }
            }

            // insert DSMH if data change (only if not exists)
            int? newDsmh = originalDsmh;
            if (originalDsmhId != newDsmhId)
            {
                if (newDsmhId.Trim() != "")
                {
                    LfsAssetSewerMH lfsAssetSewerDsmh = new LfsAssetSewerMH(null);
                    newDsmh = lfsAssetSewerDsmh.InsertDirect(countryId, provinceId, countyId, cityId, newDsmhId, "", "", "", false, companyId, "", "", null, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", null, "", "", null);
                }
                else
                {
                    newDsmh = null;
                }
            }

            // update section
            UpdateSection(countryId, provinceId, countyId, cityId, assetId, sectionId, originalStreet, originalUsmh, originalDsmh, originalSize_, originalLength, originalSubArea, newStreet, newUsmh, newDsmh, newSize_, newLength, newSubArea, companyId, projectId, workId);

            // update work
            UpdateWork(workId, numLats, notLinedYet, allMeasured, issueWithLaterals, notMeasuredYet, notDeliveredYet, originalTrafficControl, originalTrafficControlDetails, originalStandardBypass, originalStandardBypassComments, availableToLine, newTrafficControl, newTrafficControlDetails, newStandardBypass, newStandardBypassComments, companyId, availableToLine);

            // update fll work
            UpdateFllWork(assetId, projectId, originalTrafficControl, originalTrafficControlDetails, originalStandardBypass, originalStandardBypassComments, newTrafficControl, newTrafficControlDetails, newStandardBypass, newStandardBypassComments, companyId);            
        }



        /// <summary>
        /// UpdateSection
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="originalStreet">originalStreet</param>
        /// <param name="originalUsmh">originalUsmh</param>
        /// <param name="originalDsmh">originalDsmh</param>
        /// <param name="originalSize_">originalSize_</param>
        /// <param name="originalLength">originalLength</param>
        /// <param name="originalSubArea">originalSubArea</param>
        /// <param name="newStreet">newStreet</param>
        /// <param name="newUsmh">newUsmh</param>
        /// <param name="newDsmh">newDsmh</param>
        /// <param name="newSize_">newSize_</param>
        /// <param name="newLength">newLength</param>
        /// <param name="newSubArea">newSubArea</param>
        /// <param name="companyId">companyId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="workId">workId</param>
        private void UpdateSection(Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int assetId, string sectionId, string originalStreet, int? originalUsmh, int? originalDsmh, string originalSize_, string originalLength, string originalSubArea, string newStreet, int? newUsmh, int? newDsmh, string newSize_, string newLength, string newSubArea, int companyId, int projectId, int workId)
        {
            // Load data
            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
            assetSewerSectionGateway.LoadByAssetId(assetId, companyId);

            LfsAssetSewerSectionGateway lfsAssetSewerSectionGateway = new LfsAssetSewerSectionGateway(assetSewerSectionGateway.Data);
            lfsAssetSewerSectionGateway.LoadByAssetId(assetId, companyId);

            // Get unchanged data
            // ... section
            string mapSize_ = assetSewerSectionGateway.GetMapSize(assetId);
            string mapLength = assetSewerSectionGateway.GetMapLength(assetId);
            int? laterals = assetSewerSectionGateway.GetLaterals(assetId);
            int? liveLaterals = assetSewerSectionGateway.GetLiveLaterals(assetId);
            string flowDirection = assetSewerSectionGateway.GetFlowDirection(assetId);
            string usmhDepth = assetSewerSectionGateway.GetUSMHDepth(assetId);
            string dsmhDepth = assetSewerSectionGateway.GetDSMHDepth(assetId);

            // ... lfs section
            string steelTapeTroughSewer = lfsAssetSewerSectionGateway.GetSteelTapeThroughSewer(assetId);
            string usmhMouth12 = lfsAssetSewerSectionGateway.GetUSMHMouth12(assetId);
            string usmhMouth1 = lfsAssetSewerSectionGateway.GetUSMHMouth1(assetId);
            string usmhMouth2 = lfsAssetSewerSectionGateway.GetUSMHMouth2(assetId);
            string usmhMouth3 = lfsAssetSewerSectionGateway.GetUSMHMouth3(assetId);
            string usmhMouth4 = lfsAssetSewerSectionGateway.GetUSMHMouth4(assetId);
            string usmhMouth5 = lfsAssetSewerSectionGateway.GetUSMHMouth5(assetId);
            string dsmhMouth12 = lfsAssetSewerSectionGateway.GetDSMHMouth12(assetId);
            string dsmhMouth1 = lfsAssetSewerSectionGateway.GetDSMHMouth1(assetId);
            string dsmhMouth2 = lfsAssetSewerSectionGateway.GetDSMHMouth2(assetId);
            string dsmhMouth3 = lfsAssetSewerSectionGateway.GetDSMHMouth3(assetId);
            string dsmhMouth4 = lfsAssetSewerSectionGateway.GetDSMHMouth4(assetId);
            string dsmhMouth5 = lfsAssetSewerSectionGateway.GetDSMHMouth5(assetId);
            string thickness = lfsAssetSewerSectionGateway.GetThickness(assetId);
            
            //Update Full Length Lining work
            if (originalLength != newLength)
            {
                steelTapeTroughSewer = newLength;
            }
            // Update
            LfsAssetSewerSection lfsAssetSewerSection = new LfsAssetSewerSection(null);
            lfsAssetSewerSection.UpdateDirect(assetId, sectionId, originalStreet, originalUsmh, originalDsmh, mapSize_, originalSize_, mapLength, originalLength, laterals, liveLaterals, flowDirection, usmhDepth, dsmhDepth, steelTapeTroughSewer, usmhMouth12, usmhMouth1, usmhMouth2, usmhMouth3, usmhMouth4, usmhMouth5, dsmhMouth12, dsmhMouth1, dsmhMouth2, dsmhMouth3, dsmhMouth4, dsmhMouth5, false, companyId, originalSubArea, thickness, assetId, sectionId, newStreet, newUsmh, newDsmh, mapSize_, newSize_, mapLength, newLength, laterals, liveLaterals, flowDirection, usmhDepth, dsmhDepth, steelTapeTroughSewer, usmhMouth12, usmhMouth1, usmhMouth2, usmhMouth3, usmhMouth4, usmhMouth5, dsmhMouth12, dsmhMouth1, dsmhMouth2, dsmhMouth3, dsmhMouth4, dsmhMouth5, false, companyId, newSubArea, thickness);
                        
        }



        /// <summary>
        /// Update Work
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="numLats">numLats</param>
        /// <param name="notLinedYet">notLinedYet</param>
        /// <param name="allMeasured">allMeasured</param>
        /// <param name="issueWithLaterals">issueWithLaterals</param>
        /// <param name="notMeasuredYet">notMeasuredYet</param>
        /// <param name="notDeliveredYet">notDeliveredYet</param>
        /// <param name="originalSubArea">originalSubArea</param>
        /// <param name="originalTrafficControl">originalTrafficControl</param>
        /// <param name="originalTrafficControlDetails">originalTrafficControlDetails</param>
        /// <param name="originalStandardBypass">originalStandardBypass</param>
        /// <param name="originalStandardBypassComments">originalStandardBypassComments</param>
        /// <param name="originalAvailableToLine">originalAvailableToLine</param>
        /// 
        /// <param name="newTrafficControl">newTrafficControl</param>
        /// <param name="newTrafficControlDetails">newTrafficControlDetails</param>
        /// <param name="newStandardBypass">newStandardBypass</param>
        /// <param name="newStandardBypassComments">newStandardBypassComments</param>
        /// <param name="newAvailableToLine">newAvailableToLine</param>
        /// <param name="companyId">companyId</param>
        private void UpdateWork(int workId, int numLats, int notLinedYet, bool allMeasured, string issueWithLaterals, int notMeasuredYet, int notDeliveredYet, string originalTrafficControl, string originalTrafficControlDetails, bool originalStandardBypass, string originalStandardBypassComments, int originalAvailableToLine, string newTrafficControl, string newTrafficControlDetails, bool newStandardBypass, string newStandardBypassComments, int companyId, int newAvailableToLine)
        {
            WorkJunctionLiningSection workJunctionLiningSection = new WorkJunctionLiningSection(null);
            workJunctionLiningSection.UpdateDirect(workId, numLats, notLinedYet, allMeasured, false, issueWithLaterals, notMeasuredYet, notDeliveredYet, companyId, originalTrafficControl, originalTrafficControlDetails, originalStandardBypass, originalStandardBypassComments, originalAvailableToLine, numLats, notLinedYet, allMeasured, issueWithLaterals, notMeasuredYet, notDeliveredYet, newTrafficControl, newTrafficControlDetails, newStandardBypass, newStandardBypassComments, newAvailableToLine);
        }



        /// <summary>
        /// Update Fll Work
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="numLats">numLats</param>
        /// <param name="notLinedYet">notLinedYet</param>
        /// <param name="allMeasured">allMeasured</param>
        /// <param name="issueWithLaterals">issueWithLaterals</param>
        /// <param name="notMeasuredYet">notMeasuredYet</param>
        /// <param name="notDeliveredYet">notDeliveredYet</param>
        /// <param name="originalSubArea">originalSubArea</param>
        /// <param name="originalTrafficControl">originalTrafficControl</param>
        /// <param name="originalTrafficControlDetails">originalTrafficControlDetails</param>
        /// <param name="originalStandardBypass">originalStandardBypass</param>
        /// <param name="originalStandardBypassComments">originalStandardBypassComments</param>
        /// <param name="newTrafficControl">newTrafficControl</param>
        /// <param name="newTrafficControlDetails">newTrafficControlDetails</param>
        /// <param name="newStandardBypass">newStandardBypass</param>
        /// <param name="newStandardBypassComments">newStandardBypassComments</param>
        /// <param name="companyId">companyId</param>
        private void UpdateFllWork(int assetId, int projectId, string originalTrafficControl, string originalTrafficControlDetails, bool originalStandardBypass, string originalStandardBypassComments, string newTrafficControl, string newTrafficControlDetails, bool newStandardBypass, string newStandardBypassComments, int companyId)
        {
            if ((originalTrafficControlDetails != newTrafficControlDetails) || (originalStandardBypassComments != newStandardBypassComments) || (originalTrafficControl != newTrafficControl) || (originalStandardBypass != newStandardBypass))
            {
                int workIdFll = 0;
                WorkGateway workGateway = new WorkGateway();
                workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Full Length Lining", companyId);
                if (workGateway.Table.Rows.Count > 0)
                {
                    // Get WorkId
                    workIdFll = workGateway.GetWorkId(assetId, "Full Length Lining", projectId);

                    WorkFullLengthLiningM1Gateway workFullLengthLiningM1Gateway = new WorkFullLengthLiningM1Gateway();
                    workFullLengthLiningM1Gateway.LoadByWorkId(workIdFll, companyId);

                    // Original values
                    string originalMeasurementTakenBy = workFullLengthLiningM1Gateway.GetMeasurementTakenBy(workIdFll);
                    string originalSiteDetails = workFullLengthLiningM1Gateway.GetSiteDetails(workIdFll);
                    bool originalPipeSizeChange = workFullLengthLiningM1Gateway.GetPipeSizeChange(workIdFll);                    
                    string originalMeasurementType = workFullLengthLiningM1Gateway.GetMeasurementType(workIdFll);
                    string originalMeasurementFromMh = workFullLengthLiningM1Gateway.GetMeasurementFromMh(workIdFll);
                    string originalVideoDoneFromMh = workFullLengthLiningM1Gateway.GetVideoDoneFromMh(workIdFll);
                    string originalVideoDoneToMh = workFullLengthLiningM1Gateway.GetVideoDoneToMh(workIdFll);
                    bool originalDeleted = workFullLengthLiningM1Gateway.GetDeleted(workIdFll);
                    string originalAccessType = workFullLengthLiningM1Gateway.GetAccessType(workIdFll);

                    // Update M1 fullLengthLining
                    WorkFullLengthLiningM1 workFullLengthLiningM1 = new WorkFullLengthLiningM1(null);
                    workFullLengthLiningM1.UpdateDirect(workIdFll, originalMeasurementTakenBy, originalTrafficControl, originalSiteDetails, originalPipeSizeChange, originalStandardBypass, originalStandardBypassComments, originalTrafficControlDetails, originalMeasurementType, originalMeasurementFromMh, originalVideoDoneFromMh, originalVideoDoneToMh,  originalDeleted, companyId, originalAccessType, workIdFll, originalMeasurementTakenBy, newTrafficControl, originalSiteDetails, originalPipeSizeChange, newStandardBypass, newStandardBypassComments, newTrafficControlDetails, originalMeasurementType, originalMeasurementFromMh, originalVideoDoneFromMh, originalVideoDoneToMh,  originalDeleted, companyId, originalAccessType);
                }
                else
                {
                    // Create FLL Work
                    WorkFullLengthLining workFullLengthLining = new WorkFullLengthLining(null);
                    workIdFll = workFullLengthLining.InsertDirectEmptyWorks(projectId, assetId, null, "", null, null, null, null, null, null, null, false, false, false, false, false, false, false, companyId, false, "", "");

                    WorkFullLengthLiningM1Gateway workFullLengthLiningM1Gateway = new WorkFullLengthLiningM1Gateway();
                    workFullLengthLiningM1Gateway.LoadByWorkId(workIdFll, companyId);

                    // Original values
                    string originalMeasurementTakenBy = workFullLengthLiningM1Gateway.GetMeasurementTakenBy(workIdFll);
                    string originalSiteDetails = workFullLengthLiningM1Gateway.GetSiteDetails(workIdFll);
                    bool originalPipeSizeChange = workFullLengthLiningM1Gateway.GetPipeSizeChange(workIdFll);
                    string originalMeasurementType = workFullLengthLiningM1Gateway.GetMeasurementType(workIdFll);
                    string originalMeasurementFromMh = workFullLengthLiningM1Gateway.GetMeasurementFromMh(workIdFll);
                    string originalVideoDoneFromMh = workFullLengthLiningM1Gateway.GetVideoDoneFromMh(workIdFll);
                    string originalVideoDoneToMh = workFullLengthLiningM1Gateway.GetVideoDoneToMh(workIdFll);
                    bool originalDeleted = workFullLengthLiningM1Gateway.GetDeleted(workIdFll);
                    string originalAccessType = workFullLengthLiningM1Gateway.GetAccessType(workIdFll);

                    // Update M1 fullLengthLining
                    WorkFullLengthLiningM1 workFullLengthLiningM1 = new WorkFullLengthLiningM1(null);
                    workFullLengthLiningM1.UpdateDirect(workIdFll, originalMeasurementFromMh, originalTrafficControl, originalSiteDetails, originalPipeSizeChange, originalStandardBypass, originalStandardBypassComments, originalTrafficControlDetails, originalMeasurementType, originalMeasurementFromMh, originalVideoDoneFromMh, originalVideoDoneToMh, originalDeleted, companyId, originalAccessType, workIdFll, originalMeasurementTakenBy, newTrafficControl, originalSiteDetails, originalPipeSizeChange, newStandardBypass, newStandardBypassComments, newTrafficControlDetails, originalMeasurementType, originalMeasurementFromMh, originalVideoDoneFromMh, originalVideoDoneToMh, originalDeleted, companyId, originalAccessType);
                }
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        private void Delete(int workId, int assetId, int companyId)
        {
            // Delete work
            WorkJunctionLiningSection workJunctionLiningSection = new WorkJunctionLiningSection(null);
            workJunctionLiningSection.DeleteDirect(workId, companyId);

            // Delete section
            LfsAssetSewerSection lfsAssetSewerSection = new LfsAssetSewerSection(null);
            lfsAssetSewerSection.DeleteDirect(assetId, companyId);
        }

        

    }
}