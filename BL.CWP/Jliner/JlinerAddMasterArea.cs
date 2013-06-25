using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.BL.CWP.Section;

namespace LiquiForce.LFSLive.BL.CWP.Jliner
{
    /// <summary>
    /// JlinerAddMasterArea
    /// </summary>
    public class JlinerAddMasterArea : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlinerAddMasterArea()
            : base("MasterArea")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlinerAddMasterArea(DataSet data)
            : base(data, "MasterArea")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlinerAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        public void Update(Guid id, int companyId,  bool selected)
        {
            JlinerAddTDS.MasterAreaRow row = GetRow(id, companyId);
            row.Selected = selected;
        }



        /// <summary>
        /// UpdateJliners
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        public void UpdateJliners(Guid id, int companyId)
        {
            int numLats = 0;
            int notLinedYet = 0;
            bool allMeasured = true;
            int notMeasuredYet = 0;
            int notDeliveredYet = 0;

            // Select row's jliners
            DataRow[] jlinerRows = Data.Tables["JunctionLiner2"].Select("(ID = '" + id.ToString() + "') AND (COMPANY_ID = " + companyId.ToString() + ")");
            foreach (JlinerAddTDS.JunctionLiner2Row lfsJunctionLiner2Row in jlinerRows)
            {
                if (!lfsJunctionLiner2Row.Deleted)
                {
                    if (lfsJunctionLiner2Row.Issue != "Out Of Scope")
                    {
                        numLats++;
                        if (lfsJunctionLiner2Row.IsLinerInstalledNull()) notLinedYet++;
                        if (lfsJunctionLiner2Row.IsMeasuredNull()) allMeasured = false;
                        if (lfsJunctionLiner2Row.IsMeasuredNull()) notMeasuredYet++;
                        if (lfsJunctionLiner2Row.IsDeliveredNull()) notDeliveredYet++;
                    }
                }
            }

            // Update section
            JlinerAddTDS.MasterAreaRow lfsMasterAreaRow = GetRow(id, companyId);
            lfsMasterAreaRow.NumLats = numLats;
            lfsMasterAreaRow.NotLinedYet = notLinedYet;
            lfsMasterAreaRow.AllMeasured = (numLats == 0) ? false : allMeasured;
            lfsMasterAreaRow.NotMeasuredYet = notMeasuredYet;
            lfsMasterAreaRow.NotDeliveredYet = notDeliveredYet;
        }



        /// <summary>
        /// Save all sections & works to database (direct)
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        public void Save(Guid id, int companyId)
        {
            JlinerAddTDS jlinerAddChanges = (JlinerAddTDS)Data.GetChanges();

            if (jlinerAddChanges.MasterArea.Rows.Count > 0)
            {
                JlinerAddMasterAreaGateway jlinerAddMasterAreaGateway = new JlinerAddMasterAreaGateway(jlinerAddChanges);

                foreach (JlinerAddTDS.MasterAreaRow row in (JlinerAddTDS.MasterAreaDataTable)jlinerAddChanges.MasterArea)
                {
                    // Update laterals
                    if (!row.Deleted)
                    {
                        // original values
                        string originalRecordId = jlinerAddMasterAreaGateway.GetRecordIDOriginal(id, companyId);
                        string originalClientId = jlinerAddMasterAreaGateway.GetClientIDOriginal(id, companyId);
                        int? originalCompaniesId = jlinerAddMasterAreaGateway.GetCOMPANIES_IDOriginal(id, companyId);
                        string originalSubArea = jlinerAddMasterAreaGateway.GetSubAreaOriginal(id, companyId);
                        string originalStreet = jlinerAddMasterAreaGateway.GetStreetOriginal(id, companyId);
                        string originalUsmh = jlinerAddMasterAreaGateway.GetUSMHOriginal(id, companyId);
                        string originalDsmh = jlinerAddMasterAreaGateway.GetDSMHOriginal(id, companyId);
                        string originalSize_ = jlinerAddMasterAreaGateway.GetSize_Original(id, companyId);
                        string originalScaledLength = jlinerAddMasterAreaGateway.GetScaledLengthOriginal(id, companyId);
                        DateTime? originalP1Date = jlinerAddMasterAreaGateway.GetP1DateOriginal(id, companyId);
                        string originalActualLength = jlinerAddMasterAreaGateway.GetActualLengthOriginal(id, companyId);
                        double? originalLiveLats = jlinerAddMasterAreaGateway.GetLiveLatsOriginal(id, companyId);
                        string originalCXIsRemoved = jlinerAddMasterAreaGateway.GetCXIsRemovedOriginal(id, companyId);
                        DateTime? originalM1Date = jlinerAddMasterAreaGateway.GetM1DateOriginal(id, companyId);
                        DateTime? originalM2Date = jlinerAddMasterAreaGateway.GetM2DateOriginal(id, companyId);
                        DateTime? originalInstallDate = jlinerAddMasterAreaGateway.GetInstallDateOriginal(id, companyId);
                        DateTime? originalFinalVideo = jlinerAddMasterAreaGateway.GetFinalVideoOriginal(id, companyId);
                        string originalComments = jlinerAddMasterAreaGateway.GetCommentsOriginal(id, companyId);
                        bool originalIssueIdentified = jlinerAddMasterAreaGateway.GetIssueIdentifiedOriginal(id, companyId);
                        bool originalIssueResolved = jlinerAddMasterAreaGateway.GetIssueResolvedOriginal(id, companyId);
                        bool originalFullLengthLining = jlinerAddMasterAreaGateway.GetFullLengthLiningOriginal(id, companyId);
                        bool originalSubcontractorLining = jlinerAddMasterAreaGateway.GetSubcontractorLiningOriginal(id, companyId);
                        bool originalOutOfScopeInArea = jlinerAddMasterAreaGateway.GetOutOfScopeInAreaOriginal(id, companyId);
                        bool originalIssueGivenToBayCity = jlinerAddMasterAreaGateway.GetIssueGivenToBayCityOriginal(id, companyId);
                        int? originalConfirmedSize = jlinerAddMasterAreaGateway.GetConfirmedSizeOriginal(id, companyId);
                        decimal? originalInstallRate = jlinerAddMasterAreaGateway.GetInstallRateOriginal(id, companyId);
                        DateTime? originalDeadlineDate = jlinerAddMasterAreaGateway.GetDeadlineDateOriginal(id, companyId);
                        DateTime? originalProposedLiningDate = jlinerAddMasterAreaGateway.GetProposedLiningDateOriginal(id, companyId);
                        bool originalSalesIssue = jlinerAddMasterAreaGateway.GetSalesIssueOriginal(id, companyId);
                        bool originalLFSIssue = jlinerAddMasterAreaGateway.GetLFSIssueOriginal(id, companyId);
                        bool originalClientIssue = jlinerAddMasterAreaGateway.GetClientIssueOriginal(id, companyId);
                        bool originalInvestigationIssue = jlinerAddMasterAreaGateway.GetInvestigationIssueOriginal(id, companyId);
                        bool originalPointLining = jlinerAddMasterAreaGateway.GetPointLiningOriginal(id, companyId);
                        bool originalGrouting = jlinerAddMasterAreaGateway.GetGroutingOriginal(id, companyId);
                        bool originalLateralLining = jlinerAddMasterAreaGateway.GetLateralLiningOriginal(id, companyId);
                        DateTime? originalVacExDate = jlinerAddMasterAreaGateway.GetVacExDateOriginal(id, companyId);
                        DateTime? originalPusherDate = jlinerAddMasterAreaGateway.GetPusherDateOriginal(id, companyId);
                        DateTime? originalLinerOrdered = jlinerAddMasterAreaGateway.GetLinerOrderedOriginal(id, companyId);
                        DateTime? originalRestoration = jlinerAddMasterAreaGateway.GetRestorationOriginal(id, companyId);
                        DateTime? originalGroutDate = jlinerAddMasterAreaGateway.GetGroutDateOriginal(id, companyId);
                        bool originalJLiner = jlinerAddMasterAreaGateway.GetJLinerOriginal(id, companyId);
                        bool originalRehabAssessment = jlinerAddMasterAreaGateway.GetRehabAssessmentOriginal(id, companyId);
                        int? originalEstimatedJoints = jlinerAddMasterAreaGateway.GetEstimatedJointsOriginal(id, companyId);
                        int? originalJointsTestSealed = jlinerAddMasterAreaGateway.GetJointsTestSealedOriginal(id, companyId);
                        DateTime? originalPreFlushDate = jlinerAddMasterAreaGateway.GetPreFlushDateOriginal(id, companyId);
                        DateTime? originalPreVideoDate = jlinerAddMasterAreaGateway.GetPreVideoDateOriginal(id, companyId);
                        string originalUSMHMN = jlinerAddMasterAreaGateway.GetUSMHOriginal(id, companyId);
                        string originalDSMHMN = jlinerAddMasterAreaGateway.GetDSMHOriginal(id, companyId);
                        string originalUSMHDepth = jlinerAddMasterAreaGateway.GetUSMHDepthOriginal(id, companyId);
                        string originalDSMHDepth = jlinerAddMasterAreaGateway.GetDSMHDepthOriginal(id, companyId);
                        string originalMeasurementsTakenBy = jlinerAddMasterAreaGateway.GetMeasurementsTakenByOriginal(id, companyId);
                        string originalSteelTapeThruPipe = jlinerAddMasterAreaGateway.GetSteelTapeThruPipeOriginal(id, companyId);
                        double? originalUSMHAtMouth1200 = jlinerAddMasterAreaGateway.GetUSMHAtMouth1200Original(id, companyId);
                        double? originalUSMHAtMouth100 = jlinerAddMasterAreaGateway.GetUSMHAtMouth100Original(id, companyId);
                        double? originalUSMHAtMouth200 = jlinerAddMasterAreaGateway.GetUSMHAtMouth200Original(id, companyId);
                        double? originalUSMHAtMouth300 = jlinerAddMasterAreaGateway.GetUSMHAtMouth300Original(id, companyId);
                        double? originalUSMHAtMouth400 = jlinerAddMasterAreaGateway.GetUSMHAtMouth400Original(id, companyId);
                        double? originalUSMHAtMouth500 = jlinerAddMasterAreaGateway.GetUSMHAtMouth500Original(id, companyId);
                        double? originalDSMHAtMouth1200 = jlinerAddMasterAreaGateway.GetDSMHAtMouth1200Original(id, companyId);
                        double? originalDSMHAtMouth100 = jlinerAddMasterAreaGateway.GetDSMHAtMouth100Original(id, companyId);
                        double? originalDSMHAtMouth200 = jlinerAddMasterAreaGateway.GetDSMHAtMouth200Original(id, companyId);
                        double? originalDSMHAtMouth300 = jlinerAddMasterAreaGateway.GetDSMHAtMouth300Original(id, companyId);
                        double? originalDSMHAtMouth400 = jlinerAddMasterAreaGateway.GetDSMHAtMouth400Original(id, companyId);
                        double? originalDSMHAtMouth500 = jlinerAddMasterAreaGateway.GetDSMHAtMouth500Original(id, companyId);
                        string originalHydrantAddress = jlinerAddMasterAreaGateway.GetHydrantAddressOriginal(id, companyId);
                        string originalDistanceToInversionMH = jlinerAddMasterAreaGateway.GetDistanceToInversionMHOriginal(id, companyId);
                        bool originalRampsRequired = jlinerAddMasterAreaGateway.GetRampsRequiredOriginal(id, companyId);
                        string originalDegreeOfTrafficControl = jlinerAddMasterAreaGateway.GetDegreeOfTrafficControlOriginal(id, companyId);
                        bool originalStandarBypass = jlinerAddMasterAreaGateway.GetStandarBypassOriginal(id, companyId);
                        string originalHydroWireDetails = jlinerAddMasterAreaGateway.GetHydroWireDetailsOriginal(id, companyId);
                        string originalPipeMaterialType = jlinerAddMasterAreaGateway.GetPipeMaterialTypeOriginal(id, companyId);
                        int? originalCappedLaterals = jlinerAddMasterAreaGateway.GetCappedLateralsOriginal(id, companyId);
                        bool originalRoboticPrepRequired = jlinerAddMasterAreaGateway.GetRoboticPrepRequiredOriginal(id, companyId);
                        bool originalPipeSizeChange = jlinerAddMasterAreaGateway.GetPipeSizeChangeOriginal(id, companyId);
                        string originalM1Comments = jlinerAddMasterAreaGateway.GetM1CommentsOriginal(id, companyId);
                        string originalVideoDoneFrom = jlinerAddMasterAreaGateway.GetVideoDoneFromOriginal(id, companyId);
                        string originalToManhole = jlinerAddMasterAreaGateway.GetToManholeOriginal(id, companyId);
                        string originalCutterDescriptionDuringMeasuring = jlinerAddMasterAreaGateway.GetCutterDescriptionDuringMeasuringOriginal(id, companyId);
                        bool originalFullLengthPointLiner = jlinerAddMasterAreaGateway.GetFullLengthPointLinerOriginal(id, companyId);
                        bool originalBypassRequired = jlinerAddMasterAreaGateway.GetBypassRequiredOriginal(id, companyId);
                        string originalRoboticDistances = jlinerAddMasterAreaGateway.GetRoboticDistancesOriginal(id, companyId);
                        string originalTrafficControlDetails = jlinerAddMasterAreaGateway.GetTrafficControlDetailsOriginal(id, companyId);
                        string originalLineWithID = jlinerAddMasterAreaGateway.GetLineWithIDOriginal(id, companyId);
                        bool originalSchoolZone = jlinerAddMasterAreaGateway.GetSchoolZoneOriginal(id, companyId);
                        bool originalRestaurantArea = jlinerAddMasterAreaGateway.GetRestaurantAreaOriginal(id, companyId);
                        bool originalCarwashLaundromat = jlinerAddMasterAreaGateway.GetCarwashLaundromatOriginal(id, companyId);
                        bool originalHydroPulley = jlinerAddMasterAreaGateway.GetHydroPulleyOriginal(id, companyId);
                        bool originalFridgeCart = jlinerAddMasterAreaGateway.GetFridgeCartOriginal(id, companyId);
                        bool originalTwoInchPump = jlinerAddMasterAreaGateway.GetTwoInchPumpOriginal(id, companyId);
                        bool originalSixInchBypass = jlinerAddMasterAreaGateway.GetSixInchBypassOriginal(id, companyId);
                        bool originalScaffolding = jlinerAddMasterAreaGateway.GetScaffoldingOriginal(id, companyId);
                        bool originalWinchExtension = jlinerAddMasterAreaGateway.GetWinchExtensionOriginal(id, companyId);
                        bool originalExtraGenerator = jlinerAddMasterAreaGateway.GetExtraGeneratorOriginal(id, companyId);
                        bool originalGreyCableExtension = jlinerAddMasterAreaGateway.GetGreyCableExtensionOriginal(id, companyId);
                        bool originalEasementMats = jlinerAddMasterAreaGateway.GetEasementMatsOriginal(id, companyId);
                        string originalMeasurementType = jlinerAddMasterAreaGateway.GetMeasurementTypeOriginal(id, companyId);
                        bool originalDropPipe = jlinerAddMasterAreaGateway.GetDropPipeOriginal(id, companyId);
                        string originalDropPipeInvertDepth = jlinerAddMasterAreaGateway.GetDropPipeInvertDepthOriginal(id, companyId);
                        bool originalDeleted = row.Deleted;
                        string originalMeasuredFromManhole = jlinerAddMasterAreaGateway.GetMeasuredFromManholeOriginal(id, companyId);
                        string originalMainLined = jlinerAddMasterAreaGateway.GetMainLinedOriginal(id, companyId);
                        string originalBenchingIssue = jlinerAddMasterAreaGateway.GetBenchingIssueOriginal(id, companyId);
                        bool originalArchived = jlinerAddMasterAreaGateway.GetArchivedOriginal(id, companyId);
                        double? originalScaledLength1 = jlinerAddMasterAreaGateway.GetScaledLength1Original(id, companyId);
                        string originalHistory = jlinerAddMasterAreaGateway.GetHistoryOriginal(id, companyId);
                        int? originalNumLats = jlinerAddMasterAreaGateway.GetNumLatsOriginal(id, companyId);
                        int? originalNotLinedYet = jlinerAddMasterAreaGateway.GetNotLinedYetOriginal(id, companyId);
                        bool originalAllMeasured = jlinerAddMasterAreaGateway.GetAllMeasuredOriginal(id, companyId);
                        string originalCity = jlinerAddMasterAreaGateway.GetCityOriginal(id, companyId);
                        string originalProvState = jlinerAddMasterAreaGateway.GetProvStateOriginal(id, companyId);
                        string originalIssueWithLaterals = jlinerAddMasterAreaGateway.GetIssueWithLateralsOriginal(id, companyId);
                        int? originalNotMeasuredYet = jlinerAddMasterAreaGateway.GetNotMeasuredYetOriginal(id, companyId);
                        int? originalNotDeliveredYet = jlinerAddMasterAreaGateway.GetNotDeliveredYetOriginal(id, companyId);

                        // new values
                        int? newNumLats = jlinerAddMasterAreaGateway.GetNumLats(id,companyId);
                        int? newNotLinedYet = jlinerAddMasterAreaGateway.GetNotLinedYet(id,companyId);
                        bool newAllMeasured = false;
                        if (newNumLats == 0)
                        {
                            newAllMeasured = jlinerAddMasterAreaGateway.GetAllMeasured(id,companyId);
                        }
                        int? newNotMeasuredYet = jlinerAddMasterAreaGateway.GetNotMeasuredYet(id,companyId);
                        int? newNotDeliveredYet = jlinerAddMasterAreaGateway.GetNotDeliveredYet(id,companyId);
            
                         LiquiForce.LFSLive.BL.CWP.Section.Section section = new LiquiForce.LFSLive.BL.CWP.Section.Section(null);
                         section.UpdateDirect(id, companyId, originalRecordId, originalClientId, originalCompaniesId, originalSubArea, originalStreet, originalUsmh, originalDsmh, originalSize_, originalScaledLength, originalP1Date, originalActualLength, originalLiveLats, originalCXIsRemoved, originalM1Date, originalM2Date, originalInstallDate, originalFinalVideo, originalComments, originalIssueIdentified, originalIssueResolved, originalFullLengthLining, originalSubcontractorLining, originalOutOfScopeInArea, originalIssueGivenToBayCity, originalConfirmedSize, originalInstallRate, originalDeadlineDate, originalProposedLiningDate, originalSalesIssue, originalLFSIssue, originalClientIssue, originalInvestigationIssue, originalPointLining, originalGrouting, originalLateralLining, originalVacExDate, originalPusherDate, originalLinerOrdered, originalRestoration, originalGroutDate, originalJLiner, originalRehabAssessment, originalEstimatedJoints, originalJointsTestSealed, originalPreFlushDate, originalPreVideoDate, originalUSMHMN, originalDSMHMN, originalUSMHDepth, originalDSMHDepth, originalMeasurementsTakenBy, originalSteelTapeThruPipe, originalUSMHAtMouth1200, originalUSMHAtMouth100, originalUSMHAtMouth200, originalUSMHAtMouth300, originalUSMHAtMouth400, originalUSMHAtMouth500, originalDSMHAtMouth1200, originalDSMHAtMouth100, originalDSMHAtMouth200, originalDSMHAtMouth300, originalDSMHAtMouth400, originalDSMHAtMouth500, originalHydrantAddress, originalDistanceToInversionMH, originalRampsRequired, originalDegreeOfTrafficControl, originalStandarBypass, originalHydroWireDetails, originalPipeMaterialType, originalCappedLaterals, originalRoboticPrepRequired, originalPipeSizeChange, originalM1Comments, originalVideoDoneFrom, originalToManhole, originalCutterDescriptionDuringMeasuring, originalFullLengthPointLiner, originalBypassRequired, originalRoboticDistances, originalTrafficControlDetails, originalLineWithID, originalSchoolZone, originalRestaurantArea, originalCarwashLaundromat, originalHydroPulley, originalFridgeCart, originalTwoInchPump, originalSixInchBypass, originalScaffolding, originalWinchExtension, originalExtraGenerator, originalGreyCableExtension, originalEasementMats, originalMeasurementType, originalDropPipe, originalDropPipeInvertDepth, originalDeleted, originalMeasuredFromManhole, originalMainLined, originalBenchingIssue, originalArchived, originalScaledLength1, originalHistory, originalNumLats, originalNotLinedYet, originalAllMeasured, originalCity, originalProvState, originalIssueWithLaterals, originalNotMeasuredYet, originalNotDeliveredYet, id, companyId, originalRecordId, originalClientId, originalCompaniesId, originalSubArea, originalStreet, originalUsmh, originalDsmh, originalSize_, originalScaledLength, originalP1Date, originalActualLength, originalLiveLats, originalCXIsRemoved, originalM1Date, originalM2Date, originalInstallDate, originalFinalVideo, originalComments, originalIssueIdentified, originalIssueResolved, originalFullLengthLining, originalSubcontractorLining, originalOutOfScopeInArea, originalIssueGivenToBayCity, originalConfirmedSize, originalInstallRate, originalDeadlineDate, originalProposedLiningDate, originalSalesIssue, originalLFSIssue, originalClientIssue, originalInvestigationIssue, originalPointLining, originalGrouting, originalLateralLining, originalVacExDate, originalPusherDate, originalLinerOrdered, originalRestoration, originalGroutDate, originalJLiner, originalRehabAssessment, originalEstimatedJoints, originalJointsTestSealed, originalPreFlushDate, originalPreVideoDate, originalUSMHMN, originalDSMHMN, originalUSMHDepth, originalDSMHDepth, originalMeasurementsTakenBy, originalSteelTapeThruPipe, originalUSMHAtMouth1200, originalUSMHAtMouth100, originalUSMHAtMouth200, originalUSMHAtMouth300, originalUSMHAtMouth400, originalUSMHAtMouth500, originalDSMHAtMouth1200, originalDSMHAtMouth100, originalDSMHAtMouth200, originalDSMHAtMouth300, originalDSMHAtMouth400, originalDSMHAtMouth500, originalHydrantAddress, originalDistanceToInversionMH, originalRampsRequired, originalDegreeOfTrafficControl, originalStandarBypass, originalHydroWireDetails, originalPipeMaterialType, originalCappedLaterals, originalRoboticPrepRequired, originalPipeSizeChange, originalM1Comments, originalVideoDoneFrom, originalToManhole, originalCutterDescriptionDuringMeasuring, originalFullLengthPointLiner, originalBypassRequired, originalRoboticDistances, originalTrafficControlDetails, originalLineWithID, originalSchoolZone, originalRestaurantArea, originalCarwashLaundromat, originalHydroPulley, originalFridgeCart, originalTwoInchPump, originalSixInchBypass, originalScaffolding, originalWinchExtension, originalExtraGenerator, originalGreyCableExtension, originalEasementMats, originalMeasurementType, originalDropPipe, originalDropPipeInvertDepth, originalDeleted, originalMeasuredFromManhole, originalMainLined, originalBenchingIssue, originalArchived, originalScaledLength1, originalHistory, newNumLats, newNotLinedYet, newAllMeasured, originalCity, originalProvState, originalIssueWithLaterals, newNotMeasuredYet, newNotDeliveredYet);

                    }
                }
            }            
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        ///<summary>
        ///Get a single row. If not exists, raise an exception
        ///</summary>
        ///<param name="id">id</param>
        /// <param name="companyId">companyId</param>
        ///<returns>JlinerAddTDS.MasterAreaRow</returns>
        private JlinerAddTDS.MasterAreaRow GetRow(Guid id, int companyId)
        {
            JlinerAddTDS.MasterAreaRow row = ((JlinerAddTDS.MasterAreaDataTable)Table).FindByIDCOMPANY_ID(id, companyId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Jliner.JlinerAddMasterArea.GetRow");
            }

            return row;
        }
    }
}
