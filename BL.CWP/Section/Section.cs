using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;

namespace LiquiForce.LFSLive.BL.CWP.Section
{
    /// <summary>
    /// Section
    /// </summary>
    public class Section : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Section() : base("LFS_MASTER_AREA")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Section(DataSet data) : base(data, "LFS_MASTER_AREA")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SectionTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Update direct
        /// </summary>
        /// <param name="originalId">originalId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalRecordId">originalRecordId</param>        
        /// <param name="originalClientId">originalClientId</param>        
        /// <param name="originalCompaniesId">originalCompaniesId</param>
        /// <param name="originalSubArea">originalSubArea</param>
        /// <param name="originalStreet">originalStreet</param>
        /// <param name="originalUSMH">originalUSMH</param>
        /// <param name="originalDSMH">originalDSMH</param>
        /// <param name="originalSize_">originalSize_</param>
        /// <param name="originalScaledLength">originalScaledLength</param>
        /// <param name="originalP1Date">originalP1Date</param>
        /// <param name="originalActualLength">originalActualLength</param>
        /// <param name="originalLiveLats">originalLiveLats</param>
        /// <param name="originalCXIsRemoved">originalCXIsRemoved</param>
        /// <param name="originalM1Date">originalM1Date</param>
        /// <param name="originalM2Date">originalM2Date</param>
        /// <param name="originalInstallDate">originalInstallDate</param>
        /// <param name="originalFinalVideo">originalFinalVideo</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalIssueIdentified">originalIssueIdentified</param>
        /// <param name="originalIssueResolved">originalIssueResolved</param>
        /// <param name="originalFullLengthLining">originalFullLengthLining</param>
        /// <param name="originalSubcontractorLining">originalSubcontractorLining</param>
        /// <param name="originalOutOfScopeInArea">originalOutOfScopeInArea</param>
        /// <param name="originalIssueGivenToBayCity">originalIssueGivenToBayCity</param>
        /// <param name="originalConfirmedSize">originalConfirmedSize</param>
        /// <param name="originalInstallRate">originalInstallRate</param>
        /// <param name="originalDeadlineDate">originalDeadlineDate</param>
        /// <param name="originalProposedLiningDate">originalProposedLiningDate</param>
        /// <param name="originalSalesIssue">originalSalesIssue</param>
        /// <param name="originalLFSIssue">originalLFSIssue</param>
        /// <param name="originalClientIssue">originalClientIssue</param>
        /// <param name="originalInvestigationIssue">originalInvestigationIssue</param>
        /// <param name="originalPointLining">originalPointLining</param>
        /// <param name="originalGrouting">originalGrouting</param>
        /// <param name="originalLateralLining">originalLateralLining</param>
        /// <param name="originalVacExDate">originalVacExDateParameter</param>
        /// <param name="originalPusherDate">originalPusherDate</param>
        /// <param name="originalLinerOrdered">originalLinerOrdered</param>
        /// <param name="originalRestoration">originalRestoration</param>
        /// <param name="originalGroutDate">originalGroutDate</param>
        /// <param name="originalJLiner">originalJLiner</param>
        /// <param name="originalRehabAssessment">originalRehabAssessment</param>
        /// <param name="originalEstimatedJoints">originalEstimatedJoints</param>
        /// <param name="originalJointsTestSealed">originalJointsTestSealed</param>
        /// <param name="originalPreFlushDate">originalPreFlushDate</param>
        /// <param name="originalPreVideoDate">originalPreVideoDate</param>
        /// <param name="originalUSMHMN">originalUSMHMN</param>
        /// <param name="originalDSMHMN">originalDSMHMN</param>
        /// <param name="originalUSMHDepth">originalUSMHDepth</param>
        /// <param name="originalDSMHDepth">originalDSMHDepth</param>
        /// <param name="originalMeasurementsTakenBy">originalMeasurementsTakenBy</param>
        /// <param name="originalSteelTapeThruPipe">originalSteelTapeThruPipe</param>
        /// <param name="originalUSMHAtMouth1200">originalUSMHAtMouth1200</param>
        /// <param name="originalUSMHAtMouth100">originalUSMHAtMouth100</param>
        /// <param name="originalUSMHAtMouth200">originalUSMHAtMouth200</param>
        /// <param name="originalUSMHAtMouth300">originalUSMHAtMouth300</param>
        /// <param name="originalUSMHAtMouth400">originalUSMHAtMouth400</param>
        /// <param name="originalUSMHAtMouth500">originalUSMHAtMouth500</param>
        /// <param name="originalDSMHAtMouth1200">originalDSMHAtMouth1200</param>
        /// <param name="originalDSMHAtMouth100">originalDSMHAtMouth100</param>
        /// <param name="originalDSMHAtMouth200">originalDSMHAtMouth200</param>
        /// <param name="originalDSMHAtMouth300">originalDSMHAtMouth300</param>
        /// <param name="originalDSMHAtMouth400">originalDSMHAtMouth400</param>
        /// <param name="originalDSMHAtMouth500">originalDSMHAtMouth500</param>
        /// <param name="originalHydrantAddress">originalHydrantAddress</param>
        /// <param name="originalDistanceToInversionMH">originalDistanceToInversionMH</param>
        /// <param name="originalRampsRequired">originalRampsRequired</param>
        /// <param name="originalDegreeOfTrafficControl">originalDegreeOfTrafficControl</param>
        /// <param name="originalStandarBypass">originalStandarBypass</param>
        /// <param name="originalHydroWireDetails">originalHydroWireDetails</param>
        /// <param name="originalPipeMaterialType">originalPipeMaterialType</param>
        /// <param name="originalCappedLaterals">originalCappedLaterals</param>
        /// <param name="originalRoboticPrepRequired">originalRoboticPrepRequired</param>
        /// <param name="originalPipeSizeChange">originalPipeSizeChange</param>
        /// <param name="originalM1Comments">originalM1Comments</param>
        /// <param name="originalVideoDoneFrom">originalVideoDoneFrom</param>
        /// <param name="originalToManhole">originalToManhole</param>
        /// <param name="originalCutterDescriptionDuringMeasuring">originalCutterDescriptionDuringMeasuring</param>
        /// <param name="originalFullLengthPointLiner">originalFullLengthPointLiner</param>
        /// <param name="originalBypassRequired">originalBypassRequired</param>
        /// <param name="originalRoboticDistances">originalRoboticDistances</param>
        /// <param name="originalTrafficControlDetails">originalTrafficControlDetails</param>
        /// <param name="originalLineWithID">originalLineWithID</param>
        /// <param name="originalSchoolZone">originalSchoolZone</param>
        /// <param name="originalRestaurantArea">originalRestaurantArea</param>
        /// <param name="originalCarwashLaundromat">originalCarwashLaundromat</param>
        /// <param name="originalHydroPulley">originalHydroPulley</param>
        /// <param name="originalFridgeCart">originalFridgeCart</param>
        /// <param name="originalTwoInchPump">originalTwoInchPump</param>
        /// <param name="originalSixInchBypass">originalSixInchBypass</param>
        /// <param name="originalScaffolding">originalScaffolding</param>
        /// <param name="originalWinchExtension">originalWinchExtension</param>
        /// <param name="originalExtraGenerator">originalExtraGenerator</param>
        /// <param name="originalGreyCableExtension">originalGreyCableExtension</param>
        /// <param name="originalEasementMats">originalEasementMats</param>
        /// <param name="originalMeasurementType">originalMeasurementType</param>
        /// <param name="originalDropPipe">originalDropPipe</param>
        /// <param name="originalDropPipeInvertDepth">originalDropPipeInvertDepth</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalMeasuredFromManhole">originalMeasuredFromManhole</param>
        /// <param name="originalMainLined">originalMainLined</param>
        /// <param name="originalBenchingIssue">originalBenchingIssue</param>
        /// <param name="originalArchived">originalArchived</param>
        /// <param name="originalScaledLength1">originalScaledLength1</param>
        /// <param name="originalHistory">originalHistory</param>
        /// <param name="originalNumLats">originalNumLats</param>
        /// <param name="originalNotLinedYet">originalNotLinedYet</param>
        /// <param name="originalAllMeasured">originalAllMeasured</param>
        /// <param name="originalCity">originalCity</param>
        /// <param name="originalProvState">originalProvState</param>
        /// <param name="originalIssueWithLaterals">originalIssueWithLaterals</param>
        /// <param name="originalNotMeasuredYet">originalNotMeasuredYet</param>
        /// <param name="originalNotDeliveredYet">originalNotDeliveredYet</param>
        ///        
        /// <param name="newId">newId</param>        
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newRecordId">newRecordId</param>        
        /// <param name="newClientId">newClientId</param>
        /// <param name="newCompaniesId">newCompaniesId</param> 
        /// <param name="newSubArea">newSubArea</param>
        /// <param name="newStreet">newStreet</param>
        /// <param name="newUSMH">newUSMH</param>
        /// <param name="newDSMH">newDSMH</param>
        /// <param name="newSize_">newSize_</param>
        /// <param name="newScaledLength">newScaledLength</param>
        /// <param name="newP1Date">newP1Date</param>
        /// <param name="newActualLength">newActualLength</param>
        /// <param name="newLiveLats">newLiveLats</param>
        /// <param name="newCXIsRemoved">newCXIsRemoved</param>
        /// <param name="newM1Date">newM1Date</param>
        /// <param name="newM2Date">newM2Date</param>
        /// <param name="newInstallDate">newInstallDate</param>
        /// <param name="newFinalVideo">newFinalVideo</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newIssueIdentified">newIssueIdentified</param>
        /// <param name="newIssueResolved">newIssueResolved</param>
        /// <param name="newFullLengthLining">newFullLengthLining</param>
        /// <param name="newSubcontractorLining">newSubcontractorLining</param>
        /// <param name="newOutOfScopeInArea">newOutOfScopeInArea</param>
        /// <param name="newIssueGivenToBayCity">newIssueGivenToBayCity</param>
        /// <param name="newConfirmedSize">newConfirmedSize</param>
        /// <param name="newInstallRate">newInstallRate</param>
        /// <param name="newDeadlineDate">newDeadlineDate</param>
        /// <param name="newProposedLiningDate">newProposedLiningDate</param>
        /// <param name="newSalesIssue">newSalesIssue</param>
        /// <param name="newLFSIssue">newLFSIssue</param>
        /// <param name="newClientIssue">newClientIssue</param>
        /// <param name="newInvestigationIssue">newInvestigationIssue</param>
        /// <param name="newPointLining">newPointLining</param>
        /// <param name="newGrouting">newGrouting</param>
        /// <param name="newLateralLining">newLateralLining</param>
        /// <param name="newVacExDate">newVacExDateParameter</param>
        /// <param name="newPusherDate">newPusherDate</param>
        /// <param name="newLinerOrdered">newLinerOrdered</param>
        /// <param name="newRestoration">newRestoration</param>
        /// <param name="newGroutDate">newGroutDate</param>
        /// <param name="newJLiner">newJLiner</param>
        /// <param name="newRehabAssessment">newRehabAssessment</param>
        /// <param name="newEstimatedJoints">newEstimatedJoints</param>
        /// <param name="newJointsTestSealed">newJointsTestSealed</param>
        /// <param name="newPreFlushDate">newPreFlushDate</param>
        /// <param name="newPreVideoDate">newPreVideoDate</param>
        /// <param name="newUSMHMN">newUSMHMN</param>
        /// <param name="newDSMHMN">newDSMHMN</param>
        /// <param name="newUSMHDepth">newUSMHDepth</param>
        /// <param name="newDSMHDepth">newDSMHDepth</param>
        /// <param name="newMeasurementsTakenBy">newMeasurementsTakenBy</param>
        /// <param name="newSteelTapeThruPipe">newSteelTapeThruPipe</param>
        /// <param name="newUSMHAtMouth1200">newUSMHAtMouth1200</param>
        /// <param name="newUSMHAtMouth100">newUSMHAtMouth100</param>
        /// <param name="newUSMHAtMouth200">newUSMHAtMouth200</param>
        /// <param name="newUSMHAtMouth300">newUSMHAtMouth300</param>
        /// <param name="newUSMHAtMouth400">newUSMHAtMouth400</param>
        /// <param name="newUSMHAtMouth500">newUSMHAtMouth500</param>
        /// <param name="newDSMHAtMouth1200">newDSMHAtMouth1200</param>
        /// <param name="newDSMHAtMouth100">newDSMHAtMouth100</param>
        /// <param name="newDSMHAtMouth200">newDSMHAtMouth200</param>
        /// <param name="newDSMHAtMouth300">newDSMHAtMouth300</param>
        /// <param name="newDSMHAtMouth400">newDSMHAtMouth400</param>
        /// <param name="newDSMHAtMouth500">newDSMHAtMouth500</param>
        /// <param name="newHydrantAddress">newHydrantAddress</param>
        /// <param name="newDistanceToInversionMH">newDistanceToInversionMH</param>
        /// <param name="newRampsRequired">newRampsRequired</param>
        /// <param name="newDegreeOfTrafficControl">newDegreeOfTrafficControl</param>
        /// <param name="newStandarBypass">newStandarBypass</param>
        /// <param name="newHydroWireDetails">newHydroWireDetails</param>
        /// <param name="newPipeMaterialType">newPipeMaterialType</param>
        /// <param name="newCappedLaterals">newCappedLaterals</param>
        /// <param name="newRoboticPrepRequired">newRoboticPrepRequired</param>
        /// <param name="newPipeSizeChange">newPipeSizeChange</param>
        /// <param name="newM1Comments">newM1Comments</param>
        /// <param name="newVideoDoneFrom">newVideoDoneFrom</param>
        /// <param name="newToManhole">newToManhole</param>
        /// <param name="newCutterDescriptionDuringMeasuring">newCutterDescriptionDuringMeasuring</param>
        /// <param name="newFullLengthPointLiner">newFullLengthPointLiner</param>
        /// <param name="newBypassRequired">newBypassRequired</param>
        /// <param name="newRoboticDistances">newRoboticDistances</param>
        /// <param name="newTrafficControlDetails">newTrafficControlDetails</param>
        /// <param name="newLineWithID">newLineWithID</param>
        /// <param name="newSchoolZone">neSchoolZone</param>
        /// <param name="newRestaurantArea">newRestaurantArea</param>
        /// <param name="newCarwashLaundromat">newCarwashLaundromat</param>
        /// <param name="newHydroPulley">newHydroPulley</param>
        /// <param name="newFridgeCart">FridgeCart</param>
        /// <param name="newTwoInchPump">newTwoInchPump</param>
        /// <param name="newSixInchBypass">newSixInchBypass</param>
        /// <param name="newScaffolding">newScaffolding</param>
        /// <param name="newWinchExtension">WinchExtension</param>
        /// <param name="newExtraGenerator">newExtraGenerator</param>
        /// <param name="newGreyCableExtension">newGreyCableExtension</param>
        /// <param name="newEasementMats">newEasementMats</param>
        /// <param name="newMeasurementType">newMeasurementType</param>
        /// <param name="newDropPipe">newDropPipe</param>
        /// <param name="newDropPipeInvertDepth">newDropPipeInvertDepth</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newMeasuredFromManhole">newMeasuredFromManhole</param>
        /// <param name="newMainLined">newMainLined</param>
        /// <param name="newBenchingIssue">newBenchingIssue</param>
        /// <param name="newArchived">newArchived</param>
        /// <param name="newScaledLength1">newScaledLength1</param>
        /// <param name="newHistory">newHistory</param>
        /// <param name="newNumLats">newNumLats</param>
        /// <param name="newNotLinedYet">newNotLinedYet</param>
        /// <param name="newAllMeasured">newAllMeasured</param>
        /// <param name="newCity">newCity</param>
        /// <param name="newProvState">newProvState</param>
        /// <param name="newIssueWithLaterals">newIssueWithLaterals</param>
        /// <param name="newNotMeasuredYet">newNotMeasuredYet</param>
        /// <param name="newNotDeliveredYet">newNotDeliveredYet</param>
        public void UpdateDirect(Guid originalId, int originalCompanyId, string originalRecordId, string originalClientId, int? originalCompaniesId, string originalSubArea, string originalStreet, string originalUSMH, string originalDSMH, string originalSize_, string originalScaledLength, DateTime? originalP1Date, string originalActualLength, double? originalLiveLats, string originalCXIsRemoved, DateTime? originalM1Date, DateTime? originalM2Date, DateTime? originalInstallDate, DateTime? originalFinalVideo, string originalComments, bool originalIssueIdentified, bool originalIssueResolved, bool originalFullLengthLining, bool originalSubcontractorLining, bool originalOutOfScopeInArea, bool originalIssueGivenToBayCity, int? originalConfirmedSize, decimal? originalInstallRate, DateTime? originalDeadlineDate, DateTime? originalProposedLiningDate, bool originalSalesIssue, bool originalLFSIssue, bool originalClientIssue, bool originalInvestigationIssue, bool originalPointLining, bool originalGrouting, bool originalLateralLining, DateTime? originalVacExDate, DateTime? originalPusherDate, DateTime? originalLinerOrdered, DateTime? originalRestoration, DateTime? originalGroutDate, bool originalJLiner, bool originalRehabAssessment, int? originalEstimatedJoints, int? originalJointsTestSealed, DateTime? originalPreFlushDate, DateTime? originalPreVideoDate, string originalUSMHMN, string originalDSMHMN, string originalUSMHDepth, string originalDSMHDepth, string originalMeasurementsTakenBy, string originalSteelTapeThruPipe, double? originalUSMHAtMouth1200, double? originalUSMHAtMouth100, double? originalUSMHAtMouth200, double? originalUSMHAtMouth300, double? originalUSMHAtMouth400, double? originalUSMHAtMouth500, double? originalDSMHAtMouth1200, double? originalDSMHAtMouth100, double? originalDSMHAtMouth200, double? originalDSMHAtMouth300, double? originalDSMHAtMouth400, double? originalDSMHAtMouth500, string originalHydrantAddress, string originalDistanceToInversionMH, bool originalRampsRequired, string originalDegreeOfTrafficControl, bool originalStandarBypass, string originalHydroWireDetails, string originalPipeMaterialType, int? originalCappedLaterals, bool originalRoboticPrepRequired, bool originalPipeSizeChange, string originalM1Comments, string originalVideoDoneFrom, string originalToManhole, string originalCutterDescriptionDuringMeasuring, bool originalFullLengthPointLiner, bool originalBypassRequired, string originalRoboticDistances, string originalTrafficControlDetails, string originalLineWithID, bool originalSchoolZone, bool originalRestaurantArea, bool originalCarwashLaundromat, bool originalHydroPulley, bool originalFridgeCart, bool originalTwoInchPump, bool originalSixInchBypass, bool originalScaffolding, bool originalWinchExtension, bool originalExtraGenerator, bool originalGreyCableExtension, bool originalEasementMats, string originalMeasurementType, bool originalDropPipe, string originalDropPipeInvertDepth, bool originalDeleted, string originalMeasuredFromManhole, string originalMainLined, string originalBenchingIssue, bool originalArchived, double? originalScaledLength1, string originalHistory, int? originalNumLats, int? originalNotLinedYet, bool originalAllMeasured, string originalCity, string originalProvState, string originalIssueWithLaterals, int? originalNotMeasuredYet, int? originalNotDeliveredYet, Guid newId, int newCompanyId, string newRecordId, string newClientId, int? newCompaniesId, string newSubArea, string newStreet, string newUSMH, string newDSMH, string newSize_, string newScaledLength, DateTime? newP1Date, string newActualLength, double? newLiveLats, string newCXIsRemoved, DateTime? newM1Date, DateTime? newM2Date, DateTime? newInstallDate, DateTime? newFinalVideo, string newComments, bool newIssueIdentified, bool newIssueResolved, bool newFullLengthLining, bool newSubcontractorLining, bool newOutOfScopeInArea, bool newIssueGivenToBayCity, int? newConfirmedSize, decimal? newInstallRate, DateTime? newDeadlineDate, DateTime? newProposedLiningDate, bool newSalesIssue, bool newLFSIssue, bool newClientIssue, bool newInvestigationIssue, bool newPointLining, bool newGrouting, bool newLateralLining, DateTime? newVacExDate, DateTime? newPusherDate, DateTime? newLinerOrdered, DateTime? newRestoration, DateTime? newGroutDate, bool newJLiner, bool newRehabAssessment, int? newEstimatedJoints, int? newJointsTestSealed, DateTime? newPreFlushDate, DateTime? newPreVideoDate, string newUSMHMN, string newDSMHMN, string newUSMHDepth, string newDSMHDepth, string newMeasurementsTakenBy, string newSteelTapeThruPipe, double? newUSMHAtMouth1200, double? newUSMHAtMouth100, double? newUSMHAtMouth200, double? newUSMHAtMouth300, double? newUSMHAtMouth400, double? newUSMHAtMouth500, double? newDSMHAtMouth1200, double? newDSMHAtMouth100, double? newDSMHAtMouth200, double? newDSMHAtMouth300, double? newDSMHAtMouth400, double? newDSMHAtMouth500, string newHydrantAddress, string newDistanceToInversionMH, bool newRampsRequired, string newDegreeOfTrafficControl, bool newStandarBypass, string newHydroWireDetails, string newPipeMaterialType, int? newCappedLaterals, bool newRoboticPrepRequired, bool newPipeSizeChange, string newM1Comments, string newVideoDoneFrom, string newToManhole, string newCutterDescriptionDuringMeasuring, bool newFullLengthPointLiner, bool newBypassRequired, string newRoboticDistances, string newTrafficControlDetails, string newLineWithID, bool newSchoolZone, bool newRestaurantArea, bool newCarwashLaundromat, bool newHydroPulley, bool newFridgeCart, bool newTwoInchPump, bool newSixInchBypass, bool newScaffolding, bool newWinchExtension, bool newExtraGenerator, bool newGreyCableExtension, bool newEasementMats, string newMeasurementType, bool newDropPipe, string newDropPipeInvertDepth, bool newDeleted, string newMeasuredFromManhole, string newMainLined, string newBenchingIssue, bool newArchived, double? newScaledLength1, string newHistory, int? newNumLats, int? newNotLinedYet, bool newAllMeasured, string newCity, string newProvState, string newIssueWithLaterals, int? newNotMeasuredYet, int? newNotDeliveredYet)
        {
            SectionGateway sectionGateway = new SectionGateway(null);
            sectionGateway.Update(originalId, originalCompanyId, originalRecordId, originalClientId, originalCompaniesId, originalSubArea, originalStreet, originalUSMH, originalDSMH, originalSize_, originalScaledLength, originalP1Date, originalActualLength, originalLiveLats, originalCXIsRemoved, originalM1Date, originalM2Date, originalInstallDate, originalFinalVideo, originalComments, originalIssueIdentified, originalIssueResolved, originalFullLengthLining, originalSubcontractorLining, originalOutOfScopeInArea, originalIssueGivenToBayCity, originalConfirmedSize, originalInstallRate, originalDeadlineDate, originalProposedLiningDate, originalSalesIssue, originalLFSIssue, originalClientIssue, originalInvestigationIssue, originalPointLining, originalGrouting, originalLateralLining, originalVacExDate, originalPusherDate, originalLinerOrdered, originalRestoration, originalGroutDate, originalJLiner, originalRehabAssessment, originalEstimatedJoints, originalJointsTestSealed, originalPreFlushDate, originalPreVideoDate, originalUSMHMN, originalDSMHMN, originalUSMHDepth, originalDSMHDepth, originalMeasurementsTakenBy, originalSteelTapeThruPipe, originalUSMHAtMouth1200, originalUSMHAtMouth100, originalUSMHAtMouth200, originalUSMHAtMouth300, originalUSMHAtMouth400, originalUSMHAtMouth500, originalDSMHAtMouth1200, originalDSMHAtMouth100, originalDSMHAtMouth200, originalDSMHAtMouth300, originalDSMHAtMouth400, originalDSMHAtMouth500, originalHydrantAddress, originalDistanceToInversionMH, originalRampsRequired, originalDegreeOfTrafficControl, originalStandarBypass, originalHydroWireDetails, originalPipeMaterialType, originalCappedLaterals, originalRoboticPrepRequired, originalPipeSizeChange, originalM1Comments, originalVideoDoneFrom, originalToManhole, originalCutterDescriptionDuringMeasuring, originalFullLengthPointLiner, originalBypassRequired, originalRoboticDistances, originalTrafficControlDetails, originalLineWithID, originalSchoolZone, originalRestaurantArea, originalCarwashLaundromat, originalHydroPulley, originalFridgeCart, originalTwoInchPump, originalSixInchBypass, originalScaffolding, originalWinchExtension, originalExtraGenerator, originalGreyCableExtension, originalEasementMats, originalMeasurementType, originalDropPipe, originalDropPipeInvertDepth, originalDeleted, originalMeasuredFromManhole, originalMainLined, originalBenchingIssue, originalArchived, originalScaledLength1, originalHistory, originalNumLats, originalNotLinedYet, originalAllMeasured, originalCity, originalProvState, originalIssueWithLaterals, originalNotMeasuredYet, originalNotDeliveredYet, newId, newCompanyId, newRecordId, newClientId, newCompaniesId, newSubArea, newStreet, newUSMH, newDSMH, newSize_, newScaledLength, newP1Date, newActualLength, newLiveLats, newCXIsRemoved, newM1Date, newM2Date, newInstallDate, newFinalVideo, newComments, newIssueIdentified, newIssueResolved, newFullLengthLining, newSubcontractorLining, newOutOfScopeInArea, newIssueGivenToBayCity, newConfirmedSize, newInstallRate, newDeadlineDate, newProposedLiningDate, newSalesIssue, newLFSIssue, newClientIssue, newInvestigationIssue, newPointLining, newGrouting, newLateralLining, newVacExDate, newPusherDate, newLinerOrdered, newRestoration, newGroutDate, newJLiner, newRehabAssessment, newEstimatedJoints, newJointsTestSealed, newPreFlushDate, newPreVideoDate, newUSMHMN, newDSMHMN, newUSMHDepth, newDSMHDepth, newMeasurementsTakenBy, newSteelTapeThruPipe, newUSMHAtMouth1200, newUSMHAtMouth100, newUSMHAtMouth200, newUSMHAtMouth300, newUSMHAtMouth400, newUSMHAtMouth500, newDSMHAtMouth1200, newDSMHAtMouth100, newDSMHAtMouth200, newDSMHAtMouth300, newDSMHAtMouth400, newDSMHAtMouth500, newHydrantAddress, newDistanceToInversionMH, newRampsRequired, newDegreeOfTrafficControl, newStandarBypass, newHydroWireDetails, newPipeMaterialType, newCappedLaterals, newRoboticPrepRequired, newPipeSizeChange, newM1Comments, newVideoDoneFrom, newToManhole, newCutterDescriptionDuringMeasuring, newFullLengthPointLiner, newBypassRequired, newRoboticDistances, newTrafficControlDetails, newLineWithID, newSchoolZone, newRestaurantArea, newCarwashLaundromat, newHydroPulley, newFridgeCart, newTwoInchPump, newSixInchBypass, newScaffolding, newWinchExtension, newExtraGenerator, newGreyCableExtension, newEasementMats, newMeasurementType, newDropPipe, newDropPipeInvertDepth, newDeleted, newMeasuredFromManhole, newMainLined, newBenchingIssue, newArchived, newScaledLength1, newHistory, newNumLats, newNotLinedYet, newAllMeasured, newCity, newProvState, newIssueWithLaterals, newNotMeasuredYet, newNotDeliveredYet);
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
            DataRow[] jlinerRows = Data.Tables["LFS_JUNCTION_LINER2"].Select("(ID = '" + id.ToString() + "') AND (COMPANY_ID = " + companyId.ToString() + ")");
            foreach (SectionTDS.LFS_JUNCTION_LINER2Row lfsJunctionLiner2Row in jlinerRows)
            {
                if (!lfsJunctionLiner2Row.Deleted)
                {
                    if (lfsJunctionLiner2Row.Issue != "Out Of Scope")
                    {
                        numLats++;
                        if (lfsJunctionLiner2Row.IsLinerInstalledNull()) notLinedYet++;
                        if (lfsJunctionLiner2Row.IsMeasuredNull()) allMeasured = false;
                        if (lfsJunctionLiner2Row.IsMeasuredNull()) notMeasuredYet++;
                        if (lfsJunctionLiner2Row.IsDeliveredNull())notDeliveredYet++;
                    }
                }
            }

            // Update section
            SectionTDS.LFS_MASTER_AREARow lfsMasterAreaRow = GetRow(id, companyId);
            lfsMasterAreaRow.NumLats = numLats;
            lfsMasterAreaRow.NotLinedYet = notLinedYet;
            lfsMasterAreaRow.AllMeasured = (numLats == 0) ? false : allMeasured;
            lfsMasterAreaRow.NotMeasuredYet = notMeasuredYet;
            lfsMasterAreaRow.NotDeliveredYet = notDeliveredYet;
        }



        /// <summary>
        /// UpdateIssueWithLaterals
        /// </summary>
        public void UpdateIssueWithLaterals()
        {
            LinningPlanGateway liningPlanGateway = new LinningPlanGateway();

            foreach (SectionTDS.LFS_MASTER_AREARow lfsMasterAreaRow in (SectionTDS.LFS_MASTER_AREADataTable)Table)
            {
                Guid rowId = lfsMasterAreaRow.ID;

                if (lfsMasterAreaRow.NumLats > 0)
                {
                    if (liningPlanGateway.IsLateralsIssueNo(rowId))
                    {
                        lfsMasterAreaRow.IssueWithLaterals = "No";
                    }
                    else
                    {
                        if (liningPlanGateway.IsLateralsIssueOutOfScope(rowId))
                        {
                            lfsMasterAreaRow.IssueWithLaterals = "Out Of Scope";
                        }
                        else
                        {
                            if (liningPlanGateway.IsLateralsIssueYesOutOfScope(rowId))
                            {
                                lfsMasterAreaRow.IssueWithLaterals = "Yes, Out Of Scope";
                            }
                            else
                            {
                                if (liningPlanGateway.IsLateralsIssueYes(rowId))
                                {
                                    lfsMasterAreaRow.IssueWithLaterals = "Yes";
                                }
                            }
                        }
                    }
                }
                else
                {
                    lfsMasterAreaRow.IssueWithLaterals = "No";
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single section. If not exists, raise an exception
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        private SectionTDS.LFS_MASTER_AREARow GetRow(Guid id, int companyId)
        {
            SectionTDS.LFS_MASTER_AREARow row = ((SectionTDS.LFS_MASTER_AREADataTable)Table).FindByIDCOMPANY_ID(id, companyId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Section.Section.GetRow");
            }

            return row;
        }



    }
}
