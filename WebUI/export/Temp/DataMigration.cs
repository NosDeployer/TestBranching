using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.WebUI.export.Temp;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.WebUI
{
    /// <summary>
    /// DataMigration
    /// </summary>
    public class DataMigration : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DataMigration() : base("DataMigration")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DataMigration(DataSet data)
            : base(data, "DataMigration")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DataMigrationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalSectionId">originalSectionId</param>
        /// <param name="clientId">clientId</param>
        /// <param name="companiesId">companiesId</param>
        /// <param name="client">client</param>
        /// <param name="subArea">subArea</param>
        /// <param name="street">street</param>
        /// <param name="usmh">usmh</param>
        /// <param name="dsmh">dsmh</param>
        /// <param name="size_">size_</param>
        /// <param name="scaledLength">scaledLength</param>
        /// <param name="p1Date">p1Date</param>
        /// <param name="actualLength">actualLength</param>
        /// <param name="cxisRemoved">cxisRemoved</param>
        /// <param name="m1Date">m1Date</param>
        /// <param name="m2Date">m2Date</param>
        /// <param name="installDate">installDate</param>
        /// <param name="finalVideo">finalVideo</param>
        /// <param name="issueIdentified">issueIdentified</param>
        /// <param name="issueResolved">issueResolved</param>
        /// <param name="fullLengthLining">fullLengthLining</param>
        /// <param name="issueGivenToBayCity">issueGivenToBayCity</param>
        /// <param name="confirmedSize">confirmedSize</param>
        /// <param name="deadlineDate">deadlineDate</param>
        /// <param name="proposedLiningDate">proposedLiningDate</param>
        /// <param name="salesIssue">salesIssue</param>
        /// <param name="lfsIssue">lfsIssue</param>
        /// <param name="clientIssue">clientIssue</param>
        /// <param name="investigationIssue">investigationIssue</param>
        /// <param name="jLiner">jLiner</param>
        /// <param name="rehabAssessment">rehabAssessment</param>
        /// <param name="preFlushDate">preFlushDate</param>
        /// <param name="preVideoDate">preVideoDate</param>
        /// <param name="usmhMn">usmhMn</param>
        /// <param name="dsmhMn">dsmhMn</param>
        /// <param name="usmhDepth">usmhDepth</param>
        /// <param name="dsmhDepth">dsmhDepth</param>
        /// <param name="measurementsTakenBy">measurementsTakenBy</param>
        /// <param name="steelTapeThruPipe">steelTapeThruPipe</param>
        /// <param name="usmhAtMouth1200">usmhAtMouth1200</param>
        /// <param name="usmhAtMouth100">usmhAtMouth100</param>
        /// <param name="usmhAtMouth200">usmhAtMouth200</param>
        /// <param name="usmhAtMouth300">usmhAtMouth300</param>
        /// <param name="usmhAtMouth400">usmhAtMouth400</param>
        /// <param name="usmhAtMouth500">usmhAtMouth500</param>
        /// <param name="dsmhAtMouth1200">dsmhAtMouth1200</param>
        /// <param name="dsmhAtMouth100">dsmhAtMouth100</param>
        /// <param name="dsmhAtMouth200">dsmhAtMouth200</param>
        /// <param name="dsmhAtMouth300">dsmhAtMouth300</param>
        /// <param name="dsmhAtMouth400">dsmhAtMouth400</param>
        /// <param name="dsmhAtMouth500">dsmhAtMouth500</param>
        /// <param name="hydrantAddress">hydrantAddress</param>
        /// <param name="distanceToInversionMH">distanceToInversionMH</param>
        /// <param name="rampsRequired">rampsRequired</param>
        /// <param name="degreeOfTrafficControl">degreeOfTrafficControl</param>
        /// <param name="standarBypass">standarBypass</param>
        /// <param name="hydroWireDetails">hydroWireDetails</param>
        /// <param name="pipeMaterialType">pipeMaterialType</param>
        /// <param name="cappedLaterals">cappedLaterals</param>
        /// <param name="roboticPrepRequired">roboticPrepRequired</param>
        /// <param name="pipeSizeChange">pipeSizeChange</param>
        /// <param name="videoDoneFrom">videoDoneFrom</param>
        /// <param name="toManhole">toManhole</param>
        /// <param name="cutterDescriptionDuringMeasuring">cutterDescriptionDuringMeasuring</param>
        /// <param name="lineWithID">lineWithID</param>
        /// <param name="schoolZone">schoolZone</param>
        /// <param name="restaurantArea">restaurantArea</param>
        /// <param name="carwashLaundromat">carwashLaundromat</param>
        /// <param name="hydroPulley">hydroPulley</param>
        /// <param name="fridgeCart">fridgeCart</param>
        /// <param name="twoInchPump">twoInchPump</param>
        /// <param name="sixInchBypass">sixInchBypass</param>
        /// <param name="scaffolding">scaffolding</param>
        /// <param name="winchExtension">winchExtension</param>
        /// <param name="extraGenerator">extraGenerator</param>
        /// <param name="greyCableExtension">greyCableExtension</param>
        /// <param name="easementMats">easementMats</param>
        /// <param name="measurementType">measurementType</param>
        /// <param name="dropPipe">dropPipe</param>
        /// <param name="dropPipeInvertDepth">dropPipeInvertDepth</param>
        /// <param name="measuredFromManhole">measuredFromManhole</param>
        public void Insert(Guid originalId, string originalSectionId, string clientId, int companiesId, string client, string subArea, string street, string usmh, string dsmh, string size_, string scaledLength, DateTime? p1Date, string actualLength, string cxisRemoved, DateTime? m1Date, DateTime? m2Date, DateTime? installDate, DateTime? finalVideo, bool issueIdentified, bool issueResolved, bool fullLengthLining, bool issueGivenToBayCity, string confirmedSize, DateTime? deadlineDate, DateTime? proposedLiningDate, bool salesIssue, bool lfsIssue, bool clientIssue, bool investigationIssue, bool jLiner, bool rehabAssessment, DateTime? preFlushDate, DateTime? preVideoDate, string usmhMn, string dsmhMn, string usmhDepth, string dsmhDepth, string measurementsTakenBy, string steelTapeThruPipe, string usmhAtMouth1200, string usmhAtMouth100, string usmhAtMouth200, string usmhAtMouth300, string usmhAtMouth400, string usmhAtMouth500, string dsmhAtMouth1200, string dsmhAtMouth100, string dsmhAtMouth200, string dsmhAtMouth300, string dsmhAtMouth400, string dsmhAtMouth500, string hydrantAddress, string distanceToInversionMH, bool rampsRequired, string degreeOfTrafficControl, bool standarBypass, string hydroWireDetails, string pipeMaterialType, int? cappedLaterals, bool roboticPrepRequired, bool pipeSizeChange, string videoDoneFrom, string toManhole, string cutterDescriptionDuringMeasuring, string lineWithID, bool schoolZone, bool restaurantArea, bool carwashLaundromat, bool hydroPulley, bool fridgeCart, bool twoInchPump, bool sixInchBypass, bool scaffolding, bool winchExtension, bool extraGenerator, bool greyCableExtension, bool easementMats, string measurementType, bool dropPipe, string dropPipeInvertDepth, string measuredFromManhole)
        {
            DataMigrationTDS.DataMigrationRow row = ((DataMigrationTDS.DataMigrationDataTable)Table).NewDataMigrationRow();

            row.OriginalID = originalId;
            row.OriginalSectionID = originalSectionId;
            if (clientId.Trim() != "") row.ClientID = clientId; else row.SetClientIDNull();
            row.COMPANIES_ID = companiesId;
            if (client.Trim() != "") row.Client = client; else row.SetClientNull();
            if (subArea.Trim() != "") row.SubArea = subArea; else row.SetSubAreaNull();
            if (street.Trim() != "") row.Street = street; else row.SetStreetNull();
            if (usmh.Trim() != "") row.USMH = usmh; else row.SetUSMHNull();
            if (dsmh.Trim() != "") row.DSMH = dsmh; else row.SetDSMHNull();
            if (size_.Trim() != "") row.Size_ = size_; else row.SetSize_Null();
            if (scaledLength.Trim() != "") row.ScaledLength = scaledLength; else row.SetScaledLengthNull();
            if (p1Date.HasValue) row.P1Date = (DateTime)p1Date; else row.SetP1DateNull();
            if (actualLength.Trim() != "") row.ActualLength = actualLength; else row.SetActualLengthNull();
            if (cxisRemoved.Trim() != "") row.CXIsRemoved = cxisRemoved; else row.SetCXIsRemovedNull();
            if (m1Date.HasValue) row.M1Date = (DateTime)m1Date; else row.SetM1DateNull();
            if (m2Date.HasValue) row.M2Date = (DateTime)m2Date; else row.SetM2DateNull();
            if (installDate.HasValue) row.InstallDate = (DateTime)installDate; else row.SetInstallDateNull();
            if (finalVideo.HasValue) row.FinalVideo = (DateTime)finalVideo; else row.SetFinalVideoNull();
            row.IssueIdentified = issueIdentified;
            row.IssueResolved = issueResolved;
            row.FullLengthLining = fullLengthLining;
            row.IssueGivenToBayCity = issueGivenToBayCity;
            if (confirmedSize.Trim() != "") row.ConfirmedSize = confirmedSize; else row.SetConfirmedSizeNull();
            if (deadlineDate.HasValue) row.DeadlineDate = (DateTime)deadlineDate; else row.SetDeadlineDateNull();
            if (proposedLiningDate.HasValue) row.ProposedLiningDate = (DateTime)proposedLiningDate; else row.SetProposedLiningDateNull();
            row.SalesIssue = salesIssue;
            row.LFSIssue = lfsIssue;
            row.ClientIssue = clientIssue;
            row.InvestigationIssue = investigationIssue;
            row.JLiner = jLiner;
            row.RehabAssessment = rehabAssessment;
            if (preFlushDate.HasValue) row.PreFlushDate = (DateTime)preFlushDate; else row.SetPreFlushDateNull();
            if (preVideoDate.HasValue) row.PreVideoDate = (DateTime)preVideoDate; else row.SetPreVideoDateNull();
            if (usmhMn.Trim() != "") row.USMHMN = usmhMn; else row.SetUSMHMNNull();
            if (dsmhMn.Trim() != "") row.DSMHMN = dsmhMn; else row.SetDSMHMNNull();
            if (usmhDepth.Trim() != "") row.USMHDepth = usmhDepth; else row.SetUSMHDepthNull();
            if (dsmhDepth.Trim() != "") row.DSMHDepth = dsmhDepth; else row.SetDSMHDepthNull();
            if (measurementsTakenBy.Trim() != "") row.MeasurementsTakenBy = measurementsTakenBy; else row.IsMeasurementsTakenByNull();
            if (steelTapeThruPipe.Trim() != "") row.SteelTapeThruPipe = steelTapeThruPipe; else row.SetSteelTapeThruPipeNull();
            if (usmhAtMouth1200.Trim() != "") row.USMHAtMouth1200 = usmhAtMouth1200; else row.SetUSMHAtMouth1200Null();
            if (usmhAtMouth100.Trim() != "") row.USMHAtMouth100 = usmhAtMouth100; else row.SetUSMHAtMouth100Null();
            if (usmhAtMouth200.Trim() != "") row.USMHAtMouth200 = usmhAtMouth200; else row.SetUSMHAtMouth200Null();
            if (usmhAtMouth300.Trim() != "") row.USMHAtMouth300 = usmhAtMouth300; else row.SetUSMHAtMouth300Null();
            if (usmhAtMouth400.Trim() != "") row.USMHAtMouth400 = usmhAtMouth400; else row.SetUSMHAtMouth400Null();
            if (usmhAtMouth500.Trim() != "") row.USMHAtMouth500 = usmhAtMouth500; else row.SetUSMHAtMouth500Null();
            if (dsmhAtMouth1200.Trim() != "") row.DSMHAtMouth1200 = dsmhAtMouth1200; else row.SetDSMHAtMouth1200Null();
            if (dsmhAtMouth100.Trim() != "") row.DSMHAtMouth100 = dsmhAtMouth100; else row.SetDSMHAtMouth100Null();
            if (dsmhAtMouth200.Trim() != "") row.DSMHAtMouth200 = dsmhAtMouth200; else row.SetDSMHAtMouth200Null();
            if (dsmhAtMouth300.Trim() != "") row.DSMHAtMouth300 = dsmhAtMouth300; else row.SetDSMHAtMouth300Null();
            if (dsmhAtMouth400.Trim() != "") row.DSMHAtMouth400 = dsmhAtMouth400; else row.SetDSMHAtMouth400Null();
            if (dsmhAtMouth500.Trim() != "") row.DSMHAtMouth500 = dsmhAtMouth500; else row.SetDSMHAtMouth500Null();
            if (hydrantAddress.Trim() != "") row.HydrantAddress = hydrantAddress; else row.SetHydrantAddressNull();
            if (distanceToInversionMH.Trim() != "") row.DistanceToInversionMH = distanceToInversionMH; else row.SetDistanceToInversionMHNull();
            row.RampsRequired = rampsRequired;
            if (degreeOfTrafficControl.Trim() != "") row.DegreeOfTrafficControl = degreeOfTrafficControl; else row.SetDegreeOfTrafficControlNull();
            row.StandarBypass = standarBypass;
            if (hydroWireDetails.Trim() != "") row.HydroWireDetails = hydroWireDetails; else row.SetHydroWireDetailsNull();
            if (pipeMaterialType.Trim() != "") row.PipeMaterialType = pipeMaterialType; else row.SetPipeMaterialTypeNull();
            if (cappedLaterals.HasValue) row.CappedLaterals = (int)cappedLaterals; else row.SetCappedLateralsNull();
            row.RoboticPrepRequired = roboticPrepRequired;
            row.PipeSizeChange = pipeSizeChange;
            if (videoDoneFrom.Trim() != "") row.VideoDoneFrom = videoDoneFrom; else row.SetVideoDoneFromNull();
            if (toManhole.Trim() != "") row.ToManhole = toManhole; else row.SetToManholeNull();
            if (cutterDescriptionDuringMeasuring.Trim() != "") row.CutterDescriptionDuringMeasuring = cutterDescriptionDuringMeasuring; else row.SetCutterDescriptionDuringMeasuringNull();
            if (lineWithID.Trim() != "") row.LineWithID = lineWithID; else row.SetLineWithIDNull();
            row.SchoolZone = schoolZone;
            row.RestaurantArea = restaurantArea;
            row.CarwashLaundromat = carwashLaundromat;
            row.HydroPulley = hydroPulley;
            row.FridgeCart = fridgeCart;
            row.TwoInchPump = twoInchPump;
            row.SixInchBypass = sixInchBypass;
            row.Scaffolding = scaffolding;
            row.WinchExtension = winchExtension;
            row.ExtraGenerator = extraGenerator;
            row.GreyCableExtension = greyCableExtension;
            row.EasementMats = easementMats;
            if (measurementType.Trim() != "") row.MeasurementType = measurementType; else row.SetMeasurementTypeNull();
            row.DropPipe = dropPipe;
            if (dropPipeInvertDepth.Trim() != "") row.DropPipeInvertDepth = dropPipeInvertDepth; else row.SetDropPipeInvertDepthNull();
            if (measuredFromManhole.Trim() != "") row.MeasuredFromManhole = measuredFromManhole; else row.SetMeasuredFromManholeNull();
            
            ((DataMigrationTDS.DataMigrationDataTable)Table).AddDataMigrationRow(row);
        }



        /// <summary>
        /// GetSectionsSummary
        /// </summary>
        /// <param name="header">header</param>
        /// <returns></returns>
        public string GetSectionsSummary(string header)
        {
            string sectionsSummary = header + "\n";

            foreach (DataMigrationTDS.DataMigrationRow row in (DataMigrationTDS.DataMigrationDataTable)Table)
            {
                string street = "(empty)"; if (!row.IsStreetNull()) street = row.Street.Trim();
                string subArea = "(empty)"; if (!row.IsSubAreaNull()) subArea = row.SubArea.Trim();
                string usmh = "(empty)"; if (!row.IsUSMHNull()) usmh = row.USMH.Trim();
                string dsmh = "(empty)"; if (!row.IsDSMHNull()) dsmh = row.DSMH.Trim();

                // Get Works
                string works = "";
                if (row.RehabAssessment) works = "Rehab Assessment";
                if (row.FullLengthLining)
                {
                    if (works.Length > 0)
                    {
                        works = works + ", Full Length Lining";
                    }
                    else
                    {
                        works = "Full Length Lining";
                    }
                }
                if (row.JLiner)
                {
                    if (works.Length > 0)
                    {
                        works = works + ",  Junction Lining";
                    }
                    else
                    {
                        works = "Junction Lining";
                    }
                }

                sectionsSummary = sectionsSummary + "- " + row.OriginalSectionID.Trim() + ",  " + street + ",  " + subArea + ", " + usmh + ",  " + dsmh + ", " + works + "\n";
                //sectionsSummary = sectionsSummary + "- " + street + ",  " + subArea + ", " + usmh + ",  " + dsmh + ", " + works + "\n";

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
        public void Save(int companyId, int loginId)
        {
            foreach (DataMigrationTDS.DataMigrationRow row in (DataMigrationTDS.DataMigrationDataTable)Table)
            {
                // Get ids & location
                ProjectGateway projectGateway = new ProjectGateway();
                DataMigrationProjectGateway dataMigrationProjectGateway = new DataMigrationProjectGateway(null);
                string name = string.Format("{0} Data Migration Project", row.Client);

                int projectId = dataMigrationProjectGateway.GetProjectIdByName(name);
                
                if (projectId != 0)
                {
                    projectGateway.LoadByProjectId(projectId);

                    // get parameters
                    Int64 countryId = projectGateway.GetCountryID(projectId);
                    Int64? provinceId = null; if (projectGateway.GetProvinceID(projectId).HasValue) provinceId = projectGateway.GetProvinceID(projectId);
                    Int64? countyId = null; if (projectGateway.GetCountyID(projectId).HasValue) countyId = projectGateway.GetCountyID(projectId);
                    Int64? cityId = null; if (projectGateway.GetCityID(projectId).HasValue) cityId = projectGateway.GetCityID(projectId);
                    
                    //Save section
                    int section_assetId = SaveSection(row, projectId, countryId, provinceId, countyId, cityId, companyId);

                    if (row.RehabAssessment)
                    {
                        string raComments = "";
                        SaveRAWork(row, projectId, section_assetId, companyId, raComments, loginId);
                    }

                    if (row.FullLengthLining)
                    {
                        string fllComments = "";
                        SaveFLLWork(row, projectId, section_assetId, companyId, fllComments, loginId);
                    }

                    if (row.JLiner)
                    {
                        SaveJLWork(projectId, section_assetId, companyId);
                    }

                    // Insert in DataMigration Table
                    Guid originalId = row.OriginalID;
                    string originalSectionId = row.OriginalSectionID;
                    AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
                    assetSewerSectionGateway.LoadByAssetId(section_assetId, companyId);
                    string newSectionId = assetSewerSectionGateway.GetSectionId(section_assetId);

                    DataMigrationGateway dataMigrationGateway = new DataMigrationGateway(null);
                    dataMigrationGateway.InsertDataMigration(originalId, originalSectionId, section_assetId, newSectionId);
                }
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
        private int SaveSection(DataMigrationTDS.DataMigrationRow row, int projectId, Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int companyId)
        {
            string street = ""; if (!row.IsStreetNull()) street = row.Street;
            string subArea = ""; if (!row.IsSubAreaNull()) subArea = row.SubArea;
            string usmh = ""; if (!row.IsUSMHNull()) usmh = row.USMH;
            string dsmh = ""; if (!row.IsDSMHNull()) dsmh = row.DSMH;
            string usmhAddress = ""; if (!row.IsUSMHMNNull()) usmhAddress = row.USMHMN;
            string dsmhAddress = ""; if (!row.IsDSMHMNNull()) dsmhAddress = row.DSMHMN;
            string mapLength = ""; if (!row.IsScaledLengthNull()) mapLength = row.ScaledLength;
            string actualLength = ""; if (!row.IsActualLengthNull()) actualLength = row.ActualLength;
            string mapSize = ""; if (!row.IsSize_Null()) mapSize = row.Size_;
            string confirmedSize = ""; if (!row.IsConfirmedSizeNull()) confirmedSize = row.ConfirmedSize;
            string usmhDepth = ""; if (!row.IsUSMHDepthNull()) usmhDepth = row.USMHDepth;
            string dsmhDepth = ""; if (!row.IsDSMHDepthNull()) dsmhDepth = row.DSMHDepth;
            string steelTapeThruPipe = ""; if (!row.IsSteelTapeThruPipeNull()) steelTapeThruPipe = row.SteelTapeThruPipe;
            string usmhMouth12 = ""; if (!row.IsUSMHAtMouth1200Null()) usmhMouth12 = row.USMHAtMouth1200;
            string usmhMouth1 = ""; if (!row.IsUSMHAtMouth100Null()) usmhMouth12 = row.USMHAtMouth100;
            string usmhMouth2 = ""; if (!row.IsUSMHAtMouth200Null()) usmhMouth12 = row.USMHAtMouth200;
            string usmhMouth3 = ""; if (!row.IsUSMHAtMouth300Null()) usmhMouth12 = row.USMHAtMouth300;
            string usmhMouth4 = ""; if (!row.IsUSMHAtMouth400Null()) usmhMouth12 = row.USMHAtMouth400;
            string usmhMouth5 = ""; if (!row.IsUSMHAtMouth500Null()) usmhMouth12 = row.USMHAtMouth500;
            string dsmhMouth12 = ""; if (!row.IsDSMHAtMouth1200Null()) dsmhMouth12 = row.DSMHAtMouth1200;
            string dsmhMouth1 = ""; if (!row.IsDSMHAtMouth100Null()) dsmhMouth12 = row.DSMHAtMouth100;
            string dsmhMouth2 = ""; if (!row.IsDSMHAtMouth200Null()) dsmhMouth12 = row.DSMHAtMouth200;
            string dsmhMouth3 = ""; if (!row.IsDSMHAtMouth300Null()) dsmhMouth12 = row.DSMHAtMouth300;
            string dsmhMouth4 = ""; if (!row.IsDSMHAtMouth400Null()) dsmhMouth12 = row.DSMHAtMouth400;
            string dsmhMouth5 = ""; if (!row.IsDSMHAtMouth500Null()) dsmhMouth12 = row.DSMHAtMouth500;
            string thickness = ""; if (!row.IsThicknessNull()) thickness = row.Thickness;

            // insert usmh (if not exists)
            int? usmh_assetId = null;
            if (usmh != "")
            {
                LfsAssetSewerMH lfsAssetSewerUsmh = new LfsAssetSewerMH(null);
                usmh_assetId = lfsAssetSewerUsmh.InsertDirect(countryId, provinceId, countyId, cityId, usmh, "", "", usmhAddress, false, companyId, "", "", null, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", null, "", "", null);
            }

            // insert dsmh (if not exists)
            int? dsmh_assetId = null;
            if (dsmh != "")
            {
                LfsAssetSewerMH lfsAssetSewerDsmh = new LfsAssetSewerMH(null);
                dsmh_assetId = lfsAssetSewerDsmh.InsertDirect(countryId, provinceId, countyId, cityId, dsmh, "", "", dsmhAddress, false, companyId, "", "", null, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", null, "", "", null);
            }

            // insert section
            LfsAssetSewerSection lfsAssetSewerSection = new LfsAssetSewerSection(null);
            int section_assetId = lfsAssetSewerSection.InsertDirect(countryId, provinceId, countyId, cityId, row.OriginalSectionID, street, usmh_assetId, dsmh_assetId, mapSize, confirmedSize, mapLength, actualLength, null, null, "", usmhDepth, dsmhDepth, usmhAddress, dsmhAddress, steelTapeThruPipe, usmhMouth12, usmhMouth1, usmhMouth2, usmhMouth3, usmhMouth4, usmhMouth5, dsmhMouth12, dsmhMouth1, dsmhMouth2, dsmhMouth3, dsmhMouth4, dsmhMouth5, false, companyId, subArea, thickness, -1, "", DateTime.Now);

            return section_assetId;
        }



        /// <summary>
        /// SaveRAWork
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="section_assetId">section_assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="subArea">subArea</param>
        /// <param name="comments">comments</param>
        /// <param name="loginId">loginId</param>
        private void SaveRAWork(DataMigrationTDS.DataMigrationRow row, int projectId, int section_assetId, int companyId, string comments, int loginId)
        {
            DateTime dateTime_ = DateTime.Now;
            string commentsToWork = "";
            DateTime? preFlushDate = null; if (!row.IsPreFlushDateNull()) preFlushDate = row.PreFlushDate;
            DateTime? preVideoDate = null; if (!row.IsPreVideoDateNull()) preVideoDate = row.PreVideoDate;                    

            if (comments != "")
            {
                // ... Get user name
                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(loginId, companyId);
                string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);

                // ... Form the comment string
                commentsToWork = commentsToWork + dateTime_ + "\n" + "(" + user.Trim() + ") \n Subject: Bulk Upload Comments \n Comment: " + comments;
            }

            WorkRehabAssessment workRehabAssessment = new WorkRehabAssessment(null);
            int workId = workRehabAssessment.InsertDirect(projectId, section_assetId, null, preFlushDate, preVideoDate, false, companyId, commentsToWork, "");

            if (comments != "")
            {
                WorkCommentsGateway workCommentsGateway = new WorkCommentsGateway();
                workCommentsGateway.LoadByWorkIdWorkType(workId, companyId, "Rehab Assessment");
                WorkComments workComments = new WorkComments(workCommentsGateway.Data);
                workComments.Insert(workId, 0, "Rehab Assessment", "Bulk Upload Comments", loginId, DateTime.Now, comments, null, false, companyId, false, "Rehab Assessment");

                // UpdateComments               
                workCommentsGateway.Update();
            }
        }



        /// <summary>
        /// SaveFLLWork
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="section_assetId"></param>
        /// <param name="companyId"></param>
        /// <param name="comments"></param>
        /// <param name="loginId"></param>
        private void SaveFLLWork(DataMigrationTDS.DataMigrationRow row, int projectId, int section_assetId, int companyId, string comments, int loginId)
        {
            DateTime dateTime_ = DateTime.Now;
            string commentsToWork = "";
            string clientId = ""; if (!row.IsClientIDNull()) clientId = row.ClientID;
            DateTime? proposedLiningDate = null; if (!row.IsProposedLiningDateNull()) proposedLiningDate = row.ProposedLiningDate;
            DateTime? deadLineLiningDate = null; if (!row.IsDeadlineDateNull()) deadLineLiningDate = row.DeadlineDate;
            DateTime? p1Date = null; if (!row.IsP1DateNull()) p1Date = row.P1Date;
            DateTime? m1Date = null; if (!row.IsM1DateNull()) m1Date = row.M1Date;
            DateTime? m2Date = null; if (!row.IsM2DateNull()) m2Date = row.M2Date;
            DateTime? installDate = null; if (!row.IsInstallDateNull()) installDate = row.InstallDate;
            DateTime? finalVideoDate = null; if (!row.IsFinalVideoNull()) finalVideoDate = row.FinalVideo;
            bool issueIdentified = row.IssueIdentified;
            bool issueLFS = row.LFSIssue;
            bool issueClient = row.ClientIssue;
            bool issueSales = row.SalesIssue;
            bool issueGivenToClient = row.IssueGivenToBayCity;
            bool issueResolved = row.IssueResolved;
            bool issueInvestigation = row.InvestigationIssue;
            int? cxisRemoved = null; if (!row.IsCXIsRemovedNull()) cxisRemoved = int.Parse(row.CXIsRemoved);
            string lineWidthId = ""; if (!row.IsLineWithIDNull()) lineWidthId = row.LineWithID;
            string measurementsTakenBy = ""; if (!row.IsMeasurementsTakenByNull()) measurementsTakenBy = row.MeasurementsTakenBy;
            string hydrantAddress = ""; if (!row.IsHydrantAddressNull()) hydrantAddress = row.HydrantAddress;
            string distanceToInversionMh = ""; if (!row.IsDistanceToInversionMHNull()) distanceToInversionMh = row.DistanceToInversionMH;
            string trafficControl = ""; if (!row.IsDegreeOfTrafficControlNull()) trafficControl = row.DegreeOfTrafficControl;
            string hydroWireDetails = ""; if (!row.IsHydroWireDetailsNull()) hydroWireDetails = row.HydroWireDetails;
            bool rampsRequired = row.RampsRequired;
            bool pipeSizeChanges = row.PipeSizeChange;
            bool standarBypass = row.StandarBypass;
            bool roboticPrepRequired = row.RoboticPrepRequired;
            bool schoolZone = row.SchoolZone;
            bool restaurantArea = row.RestaurantArea;
            bool carswashLaundromat = row.CarwashLaundromat;
            bool hydroPulley = row.HydroPulley;
            bool fridgeCart = row.FridgeCart;
            bool twoPump = row.TwoInchPump;
            bool sixBypass = row.SixInchBypass;
            bool scaffolding = row.Scaffolding;
            bool winchExtension = row.WinchExtension;
            bool extraGenerator = row.ExtraGenerator;
            bool greyCableExtension = row.GreyCableExtension;
            bool easementMats = row.EasementMats;
            string measurementType = ""; if (!row.IsMeasurementTypeNull()) measurementType = row.MeasurementType;
            string measurementFromMh = ""; if (!row.IsMeasuredFromManholeNull()) measurementFromMh = row.MeasuredFromManhole;
            string videoDoneFromMh = ""; if (!row.IsVideoDoneFromNull()) videoDoneFromMh = row.VideoDoneFrom;
            string videoDoneToMh = ""; if (!row.IsToManholeNull()) videoDoneToMh = row.ToManhole;
            string videoDistance = ""; if (!row.IsCutterDescriptionDuringMeasuringNull()) videoDistance = row.CutterDescriptionDuringMeasuring;
            bool dropPipe = row.DropPipe;
            string dropPipeInvertDepth = ""; if (!row.IsDropPipeInvertDepthNull()) dropPipeInvertDepth = row.DropPipeInvertDepth;
            int? cappedLaterals = null; if (!row.IsCappedLateralsNull()) cappedLaterals = row.CappedLaterals;
            string materialType = ""; if (!row.IsPipeMaterialTypeNull()) materialType = row.PipeMaterialType;
            string usmh = ""; if (!row.IsUSMHNull()) usmh = row.USMH;
            string dsmh = ""; if (!row.IsDSMHNull()) dsmh = row.DSMH;                
                        
            if (comments != "")
            {
                // ... Get user name
                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(loginId, companyId);
                string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);

                // ... Form the comment string
                commentsToWork = commentsToWork + dateTime_ + "\n" + "(" + user.Trim() + ") \n Subject: Bulk Upload Comments \n Comment: " + comments;
            }

            if (measurementFromMh != "")
            {
                if (measurementFromMh.ToUpper() == "USMH" || usmh.Contains(measurementFromMh))
                {
                    measurementFromMh = "USMH";
                }

                if (measurementFromMh.ToUpper() == "DSMH" || dsmh.Contains(measurementFromMh))
                {
                    measurementFromMh = "DSMH";
                }

                if (measurementFromMh != "USMH" && measurementFromMh != "DSMH")
                {
                    measurementFromMh = "";
                }
            }

            if (videoDoneFromMh != "")
            {
                if (videoDoneFromMh.ToUpper() == "USMH" || usmh.Contains(videoDoneFromMh))
                {
                    videoDoneFromMh = "USMH";
                }

                if (videoDoneFromMh.ToUpper() == "DSMH" || dsmh.Contains(videoDoneFromMh))
                {
                    videoDoneFromMh = "DSMH";
                }

                if (videoDoneFromMh != "USMH" && videoDoneFromMh != "DSMH")
                {
                    videoDoneFromMh = "";
                }
            }

            if (videoDoneToMh != "")
            {
                if (videoDoneToMh.ToUpper() == "USMH" || usmh.Contains(videoDoneToMh))
                {
                    videoDoneToMh = "USMH";
                }

                if (videoDoneToMh.ToUpper() == "DSMH" || dsmh.Contains(videoDoneToMh))
                {
                    videoDoneToMh = "DSMH";
                }

                if (videoDoneToMh != "USMH" && videoDoneToMh != "DSMH")
                {
                    videoDoneToMh = "";
                }
            }

            WorkFullLengthLining workFullLengthLining = new WorkFullLengthLining(null);
            int workId = workFullLengthLining.InsertDirectEmptyWorks(projectId, section_assetId, null, clientId, proposedLiningDate, deadLineLiningDate, p1Date, m1Date, m2Date, installDate, finalVideoDate, issueIdentified, issueLFS, issueClient, issueSales, issueGivenToClient, issueResolved, false, companyId, issueInvestigation, commentsToWork, "");
            
            if (comments != "")
            {
                WorkCommentsGateway workCommentsGateway = new WorkCommentsGateway();
                workCommentsGateway.LoadByWorkIdWorkType(workId, companyId, "Full Length Lining");
                WorkComments workComments = new WorkComments(workCommentsGateway.Data);
                workComments.Insert(workId, 0, "Other", "Bulk Upload Comments", loginId, dateTime_, comments, null, false, companyId, false, "Full Length Lining");
                
                // UpdateComments               
                workCommentsGateway.Update();
            }

            if (materialType != "")
            {
                DataMigrationGateway dataMigrationGateway = new DataMigrationGateway(null);
                dataMigrationGateway.InsertMaterial(section_assetId, 1, materialType, dateTime_, false, companyId);
            }            
        }



        /// <summary>
        /// Save a JL Work
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="section_assetId">section_assetId</param>
        /// <param name="companyId">companyId</param>
        private void SaveJLWork(int projectId, int section_assetId, int companyId)
        {
            WorkJunctionLiningSection workJunctionLiningSection = new WorkJunctionLiningSection(null);
            workJunctionLiningSection.InsertDirect(projectId, section_assetId, null, 0, 0, false, "No", 0, 0, false, companyId, "", "", "", "", false, "", 0);            
        }



    }
}
