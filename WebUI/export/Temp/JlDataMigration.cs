using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.WebUI.export.Temp;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.CWP.Jliner;

namespace LiquiForce.LFSLive.WebUI
{
    /// <summary>
    /// JlDataMigration
    /// </summary>
    public class JlDataMigration : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlDataMigration() : base("JlDataMigration")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlDataMigration(DataSet data)
            : base(data, "JlDataMigration")
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
        /// <param name="companiesId">companiesId</param>
        /// <param name="client">client</param>
        /// <param name="subArea">subArea</param>
        /// <param name="street">street</param>
        /// <param name="usmh">usmh</param>
        /// <param name="dsmh">dsmh</param>
        /// <param name="size_">size_</param>
        /// <param name="scaledLength">scaledLength</param>
        /// <param name="actualLength">actualLength</param>
        /// <param name="confirmedSize">confirmedSize</param>
        /// <param name="jLiner">jLiner</param>
        /// <param name="usmhMn">usmhMn</param>
        /// <param name="dsmhMn">dsmhMn</param>
        /// <param name="usmhDepth">usmhDepth</param>
        /// <param name="dsmhDepth">dsmhDepth</param>
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
        /// <param name="numLats">numLats</param>
        /// <param name="notLinedYet">notLinedYet</param>
        /// <param name="allMeasured">allMeasured</param>
        /// <param name="issueWithLaterals">issueWithLaterals</param>
        /// <param name="notDeliveredYet">notDeliveredYet</param>
        /// <param name="notMeasuredYet">notMeasuredYet</param>
        public void Insert(Guid originalId, string originalSectionId, int companiesId, string client, string subArea, string street, string usmh, string dsmh, string size_, string scaledLength, string actualLength, string confirmedSize, bool jLiner, string usmhMn, string dsmhMn, string usmhDepth, string dsmhDepth, string steelTapeThruPipe, string usmhAtMouth1200, string usmhAtMouth100, string usmhAtMouth200, string usmhAtMouth300, string usmhAtMouth400, string usmhAtMouth500, string dsmhAtMouth1200, string dsmhAtMouth100, string dsmhAtMouth200, string dsmhAtMouth300, string dsmhAtMouth400, string dsmhAtMouth500, int? numLats, int? notLinedYet, bool allMeasured, string issueWithLaterals, int? notMeasuredYet, int? notDeliveredYet)
        {
            DataMigrationTDS.JlDataMigrationRow row = ((DataMigrationTDS.JlDataMigrationDataTable)Table).NewJlDataMigrationRow();

            row.OriginalID = originalId;
            row.OriginalSectionID = originalSectionId;
            row.COMPANIES_ID = companiesId;
            if (client.Trim() != "") row.Client = client; else row.SetClientNull();
            if (subArea.Trim() != "") row.SubArea = subArea; else row.SetSubAreaNull();
            if (street.Trim() != "") row.Street = street; else row.SetStreetNull();
            if (usmh.Trim() != "") row.USMH = usmh; else row.SetUSMHNull();
            if (dsmh.Trim() != "") row.DSMH = dsmh; else row.SetDSMHNull();
            if (size_.Trim() != "") row.Size_ = size_; else row.SetSize_Null();
            if (scaledLength.Trim() != "") row.ScaledLength = scaledLength; else row.SetScaledLengthNull();
            if (actualLength.Trim() != "") row.ActualLength = actualLength; else row.SetActualLengthNull();
            if (confirmedSize.Trim() != "") row.ConfirmedSize = confirmedSize; else row.SetConfirmedSizeNull();
            row.JLiner = jLiner;
            if (usmhMn.Trim() != "") row.USMHMN = usmhMn; else row.SetUSMHMNNull();
            if (dsmhMn.Trim() != "") row.DSMHMN = dsmhMn; else row.SetDSMHMNNull();
            if (usmhDepth.Trim() != "") row.USMHDepth = usmhDepth; else row.SetUSMHDepthNull();
            if (dsmhDepth.Trim() != "") row.DSMHDepth = dsmhDepth; else row.SetDSMHDepthNull();
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
            if (numLats.HasValue) row.NumLats = (int)numLats; else row.NumLats = 0;
            row.AllMeasured = allMeasured;
            if (notLinedYet.HasValue) row.NotLinedYet = (int)notLinedYet; else row.NotLinedYet = 0;
            if (issueWithLaterals.Trim() != "") row.IssueWithLaterals = issueWithLaterals; else row.IssueWithLaterals = "No";
            if (notDeliveredYet.HasValue) row.NotDeliveredYet = (int)notDeliveredYet; else row.NotDeliveredYet = 0;
            if (notMeasuredYet.HasValue) row.NotMeasuredYet = (int)notMeasuredYet; else row.NotMeasuredYet = 0;
            
            ((DataMigrationTDS.JlDataMigrationDataTable)Table).AddJlDataMigrationRow(row);
        }



        /// <summary>
        /// GetSectionsSummary
        /// </summary>
        /// <param name="header">header</param>
        /// <returns></returns>
        public string GetSectionsSummary(string header)
        {
            string sectionsSummary = header + "\n";

            foreach (DataMigrationTDS.JlDataMigrationRow row in (DataMigrationTDS.JlDataMigrationDataTable)Table)
            {
                string street = "(empty)"; if (!row.IsStreetNull()) street = row.Street.Trim();
                string subArea = "(empty)"; if (!row.IsSubAreaNull()) subArea = row.SubArea.Trim();
                string usmh = "(empty)"; if (!row.IsUSMHNull()) usmh = row.USMH.Trim();
                string dsmh = "(empty)"; if (!row.IsDSMHNull()) dsmh = row.DSMH.Trim();

                // Get Works
                string works = "";
                
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
            foreach (DataMigrationTDS.JlDataMigrationRow row in (DataMigrationTDS.JlDataMigrationDataTable)Table)
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
                    Guid originalId = row.OriginalID;
                    
                    if (row.JLiner)
                    {
                        SaveJLWork(originalId, section_assetId, row.NumLats, row.NotLinedYet, row.AllMeasured, row.IssueWithLaterals, row.NotMeasuredYet, row.NotDeliveredYet, projectId, countryId, provinceId, countyId, cityId, companyId);
                    }

                    // Insert in DataMigration Table                    
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
        private int SaveSection(DataMigrationTDS.JlDataMigrationRow row, int projectId, Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int companyId)
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
        /// Save a JL Work
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="section_assetId">section_assetId</param>
        /// <param name="numLats">numLats</param>
        /// <param name="notLinedYet">notLinedYet</param>
        /// <param name="allMeasured">allMeasured</param>
        /// <param name="issueWithLaterals">issueWithLaterals</param>
        /// <param name="notMeasuredYet">notMeasuredYet</param>
        /// <param name="notDeliveredYet">notDeliveredYet</param>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="companyId">companyId</param>
        private void SaveJLWork(Guid originalId, int section_assetId, int numLats, int notLinedYet, bool allMeasured, string issueWithLaterals, int notMeasuredYet, int notDeliveredYet, int projectId, Int64? countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int companyId)
        {
            // Insert Junction Lining Section
            WorkJunctionLiningSection workJunctionLiningSection = new WorkJunctionLiningSection(null);
            int sectionWorkId = workJunctionLiningSection.InsertDirect(projectId, section_assetId, null, numLats, notLinedYet, allMeasured, issueWithLaterals, notMeasuredYet, notDeliveredYet, false, companyId, "", "", "", "", false, "", 0);            

            // Insert Junction Lining Laterals
            SectionTDS sectionTDS = new SectionTDS();

            SectionGateway sectionGateway = new SectionGateway(sectionTDS);
            sectionGateway.LoadById(originalId, companyId);

            JlinerGateway jlinerGateway = new JlinerGateway(sectionTDS);
            jlinerGateway.LoadByIdCompanyId(originalId, companyId);

            foreach (SectionTDS.LFS_JUNCTION_LINER2Row row in (SectionTDS.LFS_JUNCTION_LINER2DataTable)jlinerGateway.Table)
            {
                string lateralID = ""; if (!row.IsDetailIDNull()) lateralID = row.DetailID;
                string address = ""; if (!row.IsAddressNull()) address = row.Address;
                string distanceFromUSMH = ""; if (!row.IsDistanceFromUSMHNull()) distanceFromUSMH = row.DistanceFromUSMH.ToString();
                string distanceFromDSMH = ""; if (!row.IsDistanceFromDSMHNull()) distanceFromDSMH = row.DistanceFromDSMH.ToString();
                DateTime? pipeLocated = null; if (!row.IsPipeLocatedNull()) pipeLocated = row.PipeLocated;
                DateTime? servicesLocated = null; if (!row.IsServicesLocatedNull()) servicesLocated = row.ServicesLocated;
                DateTime? coInstalled = null; if (!row.IsCoInstalledNull()) coInstalled = row.CoInstalled;
                DateTime? backfilledConcrete = null; if (!row.IsBackfilledConcreteNull()) backfilledConcrete = row.BackfilledConcrete;
                DateTime? backfilledSoil = null; if (!row.IsBackfilledSoilNull()) backfilledSoil = row.BackfilledSoil;
                DateTime? grouted = null; if (!row.IsGroutedNull()) grouted = row.Grouted;
                DateTime? cored = null; if (!row.IsCoredNull()) cored = row.Cored;
                DateTime? prepped = null; if (!row.IsPreppedNull()) prepped = row.Prepped;
                DateTime? measured = null; if (!row.IsMeasuredNull()) measured = row.Measured;
                string linerSize = ""; if (!row.IsLinerSizeNull()) linerSize = row.LinerSize;
                DateTime? inProcess = null; if (!row.IsInProcessNull()) inProcess = row.InProcess;
                DateTime? inStock = null; if (!row.IsInStockNull()) inStock = row.InStock;
                DateTime? delivered = null; if (!row.IsDeliveredNull()) delivered = row.Delivered;
                int? buildRebuid = null; if (!row.IsBuildRebuildNull()) buildRebuid = row.BuildRebuild;
                DateTime? preVideo = null; if (!row.IsPreVideoNull()) preVideo = row.PreVideo;
                DateTime? linerInstalled = null; if (!row.IsLinerInstalledNull()) linerInstalled = row.LinerInstalled;
                DateTime? finalVideo = null; if (!row.IsFinalVideoNull()) finalVideo = row.FinalVideo;
                string map = ""; if (!row.IsMapNull()) map = row.Map;
                decimal? cost = null; if (!row.IsCostNull()) cost = row.Cost;
                DateTime? videoInspection = null; if (!row.IsVideoInspectionNull()) videoInspection = row.VideoInspection;
                bool coRequired = row.CoRequired;
                bool pitRequired = row.PitRequired;
                string coPitLocation = ""; if (!row.IsCoPitLocationNull()) coPitLocation = row.CoPitLocation;
                bool postContractDigRequired = row.PostContractDigRequired;
                string comments = ""; if (!row.IsCommentsNull()) comments = row.Comments;
                string history = ""; if (!row.IsHistoryNull()) history = row.History;
                DateTime? coCutDown = null; if (!row.IsCoCutDownNull()) coCutDown = row.CoCutDown;
                DateTime? finalRestoration = null; if (!row.IsFinalRestorationNull()) finalRestoration = row.FinalRestoration;
                string clientLateralId = ""; if (!row.IsClientLateralIDNull()) clientLateralId = row.ClientLateralID;
                string videoLengthToPropertyLine = ""; if (!row.IsVideoLengthToPropertyLineNull()) videoLengthToPropertyLine = row.VideoLengthToPropertyLine;
                bool liningThruCo = row.LiningThruCo;
                DateTime? noticeDelivered = null; if (!row.IsNoticeDeliveredNull()) noticeDelivered = row.NoticeDelivered;
                string hamiltonInspectionNumber = ""; if (!row.IsHamiltonInspectionNumberNull()) hamiltonInspectionNumber = row.HamiltonInspectionNumber;
                bool dyeTestReq = row.DyeTestReq;
                DateTime? dyeTestComplete = null; if (!row.IsDyeTestCompleteNull()) dyeTestComplete = row.DyeTestComplete;
                
                // Fields only presents in new Junction lining
                string flange = "";
                string gasket = "";
                string connectionType = "";
                string depthOfLocated = "";
                bool digRequiredPriorToLining = false;
                DateTime? digRequiredPriorToLiningCompleted = null;
                bool digRequiredAfterLining = false;
                DateTime? digRequiredAfterLiningCompleted = null;
                bool outOfScope = false;
                bool holdClientIssue = false;
                DateTime? holdClientIssueResolved  = null;
                bool holdLFSIssue = false;
                DateTime? holdLFSIssueResolved = null;
                bool requiresRoboticPrep = false;
                DateTime? requiresRoboticPrepCompleted = null;
                
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);
                int clientId = projectGateway.GetClientID(projectId);
                
                // Insert into LFS Asset Lateral
                LfsAssetSewerLateral lfsAssetSewerLateral = new LfsAssetSewerLateral(null);
                int lateralAssetId = lfsAssetSewerLateral.InsertDirect(countryId, provinceId, countyId, cityId, section_assetId, address, lateralID, "", "", "", "", "Live", "", distanceFromUSMH, distanceFromDSMH, "", false, companyId, connectionType);

                // Insert into LFS Asset Lateral Client
                LfsAssetSewerLateralClient lfsAssetSewerLateralClient = new LfsAssetSewerLateralClient(null);
                lfsAssetSewerLateralClient.InsertDirect(lateralAssetId, clientId, clientLateralId, false, companyId);

                // Insert into Work Junction Lining Lateral
                WorkJunctionLiningLateral workJunctionLiningLateral = new WorkJunctionLiningLateral(null);
                int workLateral = workJunctionLiningLateral.InsertDirect(projectId, lateralAssetId, sectionWorkId, pipeLocated, servicesLocated, coInstalled, backfilledConcrete, backfilledSoil, grouted, cored, prepped, measured, linerSize, inProcess, inStock, delivered, buildRebuid, preVideo, linerInstalled, finalVideo, cost, videoInspection, coRequired, pitRequired, coPitLocation, postContractDigRequired, coCutDown, finalRestoration, false, companyId, comments, history, videoLengthToPropertyLine, liningThruCo, noticeDelivered, hamiltonInspectionNumber, flange, gasket, depthOfLocated, digRequiredPriorToLining, digRequiredPriorToLiningCompleted, digRequiredAfterLining, digRequiredAfterLiningCompleted, outOfScope, holdClientIssue, holdClientIssueResolved, holdLFSIssue, holdLFSIssueResolved, requiresRoboticPrep, requiresRoboticPrepCompleted, "", "", dyeTestReq, dyeTestComplete, "");

                // Insert into Work Comments
                JlinerCommentGateway jlinerCommentGateway = new JlinerCommentGateway(sectionTDS);
                jlinerCommentGateway.LoadByIdRefId(originalId, row.RefID, companyId);

                foreach (SectionTDS.LFS_JUNCTION_LINER2_COMMENTRow rowComment in (SectionTDS.LFS_JUNCTION_LINER2_COMMENTDataTable)jlinerCommentGateway.Table)
                {
                    int loginId = rowComment.LoginID;
                    DateTime dateTime_ = rowComment.DateTime_;
                    string comment = rowComment.Comment;

                    WorkCommentsGateway workCommentsGateway = new WorkCommentsGateway();
                    workCommentsGateway.LoadByWorkIdWorkType(workLateral, companyId, "Junction Lining Lateral");
                    WorkComments workComments = new WorkComments(workCommentsGateway.Data);
                    workComments.Insert(workLateral, 0, "Junction Lining Lateral", "Bulk Upload Comments", loginId, dateTime_, comment, null, false, companyId, false, "Junction Lining");

                    // Update Comments               
                    workCommentsGateway.Update();
                }

                // Insert into Work History
                JlinerHistoryGateway jlinerHistoryGateway = new JlinerHistoryGateway(sectionTDS);
                jlinerHistoryGateway.LoadByIdRefId(originalId, row.RefID, companyId);

                foreach (SectionTDS.LFS_JUNCTION_LINER2_HISTORYRow rowHistory in (SectionTDS.LFS_JUNCTION_LINER2_HISTORYDataTable)jlinerHistoryGateway.Table)
                {
                    int loginId = rowHistory.LoginID;
                    DateTime dateTime_H = rowHistory.DateTime_;
                    string history_ = rowHistory.History;

                    WorkHistoryGateway workHistoryGateway = new WorkHistoryGateway();
                    workHistoryGateway.LoadByWorkIdWorkType(workLateral, companyId, "Junction Lining Lateral");
                    WorkHistory workHistory = new WorkHistory(workHistoryGateway.Data);
                    workHistory.Insert(workLateral, 0, "Junction Lining Lateral", "Bulk Upload History", loginId, dateTime_H, history_, null, false, companyId, false, "Junction Lining");

                    // Update History              
                    workHistoryGateway.Update();                    
                }
            }
        }



    }
}