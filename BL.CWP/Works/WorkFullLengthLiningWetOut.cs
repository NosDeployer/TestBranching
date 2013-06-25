using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningWetOut
    /// </summary>
    public class WorkFullLengthLiningWetOut: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningWetOut()
            : base("LFS_WORK_FULLLENGTHLINING_WETOUT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningWetOut(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_WETOUT")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WorkTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //             

        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="linerTube">linerTube</param>
        /// <param name="resinId">resinId</param>
        /// <param name="excessResin">excessResin</param>
        /// <param name="poundsDrums">poundsDrums</param>
        /// <param name="drumDiameter">drumDiameter</param>
        /// <param name="hoistMaximumHeight">hoistMaximumHeight</param>
        /// <param name="hoistMinimumHeight">hoistMinimumHeight</param>
        /// <param name="downDropTubeLenght">downDropTubeLenght</param>
        /// <param name="pumpHeightAboveGround">pumpHeightAboveGround</param>
        /// <param name="tubeResinToFeltFactor">tubeResinToFeltFactor</param>
        /// <param name="dateOfSheet">dateOfSheet</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="runDetails">runDetails</param>
        /// <param name="runDetails2">runDetails2</param>
        /// <param name="wetOutDate">wetOutDate</param>
        /// <param name="installDate">installDate</param>
        /// <param name="thickness">thickness</param>
        /// <param name="lengthToLine">lengthToLine</param>
        /// <param name="plusExtra">plusExtra</param>
        /// <param name="forTurnOffset">forTurnOffset</param>
        /// <param name="lengthToWetOut">lengthToWetOut</param>
        /// <param name="tubeMaxColdHead">tubeMaxColdHead</param>
        /// <param name="tubeMaxColdHeadPsi">tubeMaxColdHeadPsi</param>
        /// <param name="tubeMaxHotHead">tubeMaxHotHead</param>
        /// <param name="tubeMaxHotHeadPsi">tubeMaxHotHeadPsi</param>
        /// <param name="tubeIdealHead">tubeIdealHead</param>
        /// <param name="tubeIdealHeadPsi">tubeIdealHeadPsi</param>
        /// <param name="netResinForTube">netResinForTube</param>
        /// <param name="netResinForTubeUsgals">netResinForTubeUsgals</param>
        /// <param name="netResinForTubeDrumsIns">netResinForTubeDrumsIns</param>
        /// <param name="netResinForTubeLbsFt">netResinForTubeLbsFt</param>
        /// <param name="netResinForTubeUsgFt">netResinForTubeUsgFt</param>
        /// <param name="extraResinForMix">extraResinForMix</param>
        /// <param name="extraLbsForMix">extraLbsForMix</param>
        /// <param name="totalMixQuantity">totalMixQuantity</param>
        /// <param name="totalMixQuantityUsgals">totalMixQuantityUsgals</param>
        /// <param name="totalMixQuantityDrumsIns">totalMixQuantityDrumsIns</param>
        /// <param name="inversionType">inversionType</param>
        /// <param name="depthOfInversionMH">depthOfInversionMH</param>
        /// <param name="tubeForColumn">tubeForColumn</param>
        /// <param name="tubeForStartDry">tubeForStartDry</param>
        /// <param name="totalTube">totalTube</param>
        /// <param name="dropTubeConnects">dropTubeConnects</param>
        /// <param name="allowsHeadTo">allowsHeadTo</param>
        /// <param name="rollerGap">rollerGap</param>
        /// <param name="heightNeeded">heightNeeded</param>
        /// <param name="available">available</param>
        /// <param name="hoistHeight">hoistHeight</param>
        /// <param name="comments">comments</param>
        /// <param name="netResinLabel">netResinLabel</param>
        /// <param name="drumContainsLabel">drumContainsLabel</param>
        /// <param name="linerTubeLabel">linerTubeLabel</param>
        /// <param name="forLbDrumsLabel">forLbDrumsLabel</param>
        /// <param name="netResinLabel">netResinLabel</param>
        /// <param name="catalystLabel">catalystLabel</param> 
        /// <param name="deleted">deleted</param>       
        /// <param name="companyId">companyId</param>    
        public void InsertDirect(int workId, string linerTube, int resinId, decimal excessResin, string poundsDrums, decimal drumDiameter, decimal hoistMaximumHeight, decimal hoistMinimumHeight, decimal downDropTubeLenght, decimal pumpHeightAboveGround, int tubeResinToFeltFactor, DateTime dateOfSheet, int employeeId, string runDetails, string runDetails2, DateTime wetOutDate, DateTime? installDate, string thickness, decimal lengthToLine, decimal plusExtra, decimal forTurnOffset, decimal lengthToWetOut, decimal tubeMaxColdHead, decimal tubeMaxColdHeadPsi, decimal tubeMaxHotHead, decimal tubeMaxHotHeadPsi, decimal tubeIdealHead, decimal tubeIdealHeadPsi, decimal netResinForTube, decimal netResinForTubeUsgals, string netResinForTubeDrumsIns, decimal netResinForTubeLbsFt, decimal netResinForTubeUsgFt, int extraResinForMix, decimal extraLbsForMix, decimal totalMixQuantity, decimal totalMixQuantityUsgals, string totalMixQuantityDrumsIns, string inversionType, decimal depthOfInversionMH, decimal tubeForColumn, decimal tubeForStartDry, decimal totalTube, string dropTubeConnects, decimal allowsHeadTo, decimal rollerGap, decimal heightNeeded, string available, string hoistHeight, string comments, string resinsLabel, string drumContainsLabel, string linerTubeLabel, string forLbDrumsLabel, string netResinLabel, string catalystLabel, bool deleted, int companyId)
        {
            WorkFullLengthLiningWetOutGateway workFullLengthLiningWetOutGateway = new WorkFullLengthLiningWetOutGateway(Data);
            workFullLengthLiningWetOutGateway.Insert(workId, linerTube, resinId, excessResin, poundsDrums, drumDiameter, hoistMaximumHeight, hoistMinimumHeight, downDropTubeLenght, pumpHeightAboveGround, tubeResinToFeltFactor, dateOfSheet, employeeId, runDetails, runDetails2, wetOutDate, installDate, thickness, lengthToLine, plusExtra, forTurnOffset, lengthToWetOut, tubeMaxColdHead, tubeMaxColdHeadPsi, tubeMaxHotHead, tubeMaxHotHeadPsi, tubeIdealHead, tubeIdealHeadPsi, netResinForTube, netResinForTubeUsgals, netResinForTubeDrumsIns, netResinForTubeLbsFt, netResinForTubeUsgFt, extraResinForMix, extraLbsForMix, totalMixQuantity, totalMixQuantityUsgals, totalMixQuantityDrumsIns, inversionType, depthOfInversionMH, tubeForColumn, tubeForStartDry, totalTube, dropTubeConnects, allowsHeadTo, rollerGap, heightNeeded, available, hoistHeight, comments, resinsLabel, drumContainsLabel, linerTubeLabel, forLbDrumsLabel, netResinLabel, catalystLabel, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalLinerTube">originalLinerTube</param>
        /// <param name="originalResinId">originalResinId</param>
        /// <param name="originalExcessResin">originalExcessResin</param>
        /// <param name="originalPoundsDrums">originalPoundsDrums</param>
        /// <param name="originalDrumDiameter">originalDrumDiameter</param>
        /// <param name="originalHoistMaximumHeight">originalHoistMaximumHeight</param>
        /// <param name="originalHoistMinimumHeight">originalHoistMinimumHeight</param>
        /// <param name="originalDownDropTubeLenght">originalDownDropTubeLenght</param>
        /// <param name="originalPumpHeightAboveGround">originalPumpHeightAboveGround</param>
        /// <param name="originalTubeResinToFeltFactor">originalTubeResinToFeltFactor</param>
        /// <param name="originalDateOfSheet">originalDateOfSheet</param>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalRunDetails">originalRunDetails</param>
        /// <param name="originalRunDetails2">originalRunDetails2</param>
        /// <param name="originalWetOutDate">originalWetOutDate</param>
        /// <param name="originalInstallDate">originalInstallDate</param>
        /// <param name="originalThickness">originalThickness</param>
        /// <param name="originalLengthToLine">originalLengthToLine</param>
        /// <param name="originalPlusExtra">originalPlusExtra</param>
        /// <param name="originalForTurnOffset">originalForTurnOffset</param>
        /// <param name="originalLengthToWetOut">originalLengthToWetOut</param>
        /// <param name="originalTubeMaxColdHead">originalTubeMaxColdHead</param>
        /// <param name="originalTubeMaxColdHeadPsi">originalTubeMaxColdHeadPsi</param>
        /// <param name="originalTubeMaxHotHead">originalTubeMaxHotHead</param>
        /// <param name="originalTubeMaxHotHeadPsi">originalTubeMaxHotHeadPsi</param>
        /// <param name="originalTubeIdealHead">originalTubeIdealHead</param>
        /// <param name="originalTubeIdealHeadPsi">originalTubeIdealHeadPsi</param>
        /// <param name="originalNetResinForTube">originalNetResinForTube</param>
        /// <param name="originalNetResinForTubeUsgals">originalNetResinForTubeUsgals</param>
        /// <param name="originalNetResinForTubeDrumsIns">originalNetResinForTubeDrumsIns</param>
        /// <param name="originalNetResinForTubeLbsFt">originalNetResinForTubeLbsFt</param>
        /// <param name="originalNetResinForTubeUsgFt">originalNetResinForTubeUsgFt>
        /// <param name="originalExtraResinForMix">originalExtraResinForMix</param>
        /// <param name="originalExtraLbsForMix">originalExtraLbsForMix</param>
        /// <param name="originalTotalMixQuantity">originalTotalMixQuantity</param>
        /// <param name="originalTotalMixQuantityUsgals">originalTotalMixQuantityUsgals</param>
        /// <param name="originalTotalMixQuantityDrumsIns">originalTotalMixQuantityDrumsIns</param>
        /// <param name="originalInversionType">originalInversionType>
        /// <param name="originalDepthOfInversionMH">originalDepthOfInversionMH</param>
        /// <param name="originalTubeForColumn">originalTubeForColumn</param>
        /// <param name="originalTubeForStartDry">originalTubeForStartDry</param>
        /// <param name="originalTotalTube">originalTotalTube</param>
        /// <param name="originalDropTubeConnects">originalDropTubeConnects</param>
        /// <param name="originalAllowsHeadTo">originalAllowsHeadTo</param>
        /// <param name="originalRollerGap">originalRollerGap</param>
        /// <param name="originalHeightNeeded">originalHeightNeeded</param>
        /// <param name="originalAvailable">originalAvailable</param>
        /// <param name="originalHoistHeight">originalHoistHeight</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalResinsLabel">originalResinsLabel</param>
        /// <param name="originalDrumContainsLabel">originalDrumContainsLabel</param>
        /// <param name="originalLinerTubeLabel">originalLinerTubeLabel</param>
        /// <param name="originalForLbDrumsLabel">originalForLbDrumsLabel</param>
        /// <param name="originalNetResinLabel">originalNetResinLabel</param>
        /// <param name="originalCatalystLabel">originalCatalystLabel</param> 
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newLinerTube">newLinerTube</param>
        /// <param name="newResinId">newResinId</param>
        /// <param name="newExcessResin">newExcessResin</param>
        /// <param name="newPoundsDrums">newPoundsDrums</param>
        /// <param name="newDrumDiameter">newDrumDiameter</param>
        /// <param name="newHoistMaximumHeight">newHoistMaximumHeight</param>
        /// <param name="newHoistMinimumHeight">newHoistMinimumHeight</param>
        /// <param name="newDownDropTubeLenght">newDownDropTubeLenght</param>
        /// <param name="newPumpHeightAboveGround">newPumpHeightAboveGround</param>
        /// <param name="newTubeResinToFeltFactor">newTubeResinToFeltFactor</param>
        /// <param name="newDateOfSheet">newDateOfSheet</param>
        /// <param name="newEmployeeId">newEmployeeId</param>
        /// <param name="newRunDetails">newRunDetails</param>
        /// <param name="newRunDetails2">newRunDetails2</param>
        /// <param name="newWetOutDate">newWetOutDate</param>
        /// <param name="newInstallDate">newInstallDate</param>
        /// <param name="newThickness">newThickness</param>
        /// <param name="newLengthToLine">newLengthToLine</param>
        /// <param name="newPlusExtra">newPlusExtra</param>
        /// <param name="newForTurnOffset">newForTurnOffset</param>
        /// <param name="newLengthToWetOut">newLengthToWetOut</param>
        /// <param name="newTubeMaxColdHead">newTubeMaxColdHead</param>
        /// <param name="newTubeMaxColdHeadPsi">newTubeMaxColdHeadPsi</param>
        /// <param name="newTubeMaxHotHead">newTubeMaxHotHead</param>
        /// <param name="newTubeMaxHotHeadPsi">newTubeMaxHotHeadPsi</param>
        /// <param name="newTubeIdealHead">newTubeIdealHead</param>
        /// <param name="newTubeIdealHeadPsi">newTubeIdealHeadPsi</param>
        /// <param name="newNetResinForTube">newNetResinForTube</param>
        /// <param name="newNetResinForTubeUsgals">newNetResinForTubeUsgals</param>
        /// <param name="newNetResinForTubeDrumsIns">newNetResinForTubeDrumsIns</param>
        /// <param name="newNetResinForTubeLbsFt">newNetResinForTubeLbsFt</param>
        /// <param name="newNetResinForTubeUsgFt">newNetResinForTubeUsgFt>
        /// <param name="newExtraResinForMix">newExtraResinForMix</param>
        /// <param name="newExtraLbsForMix">newExtraLbsForMix</param>
        /// <param name="newTotalMixQuantity">newTotalMixQuantity</param>
        /// <param name="newTotalMixQuantityUsgals">newTotalMixQuantityUsgals</param>
        /// <param name="newTotalMixQuantityDrumsIns">newTotalMixQuantityDrumsIns</param>
        /// <param name="newInversionType">newInversionType>
        /// <param name="newDepthOfInversionMH">newDepthOfInversionMH</param>
        /// <param name="newTubeForColumn">newTubeForColumn</param>
        /// <param name="newTubeForStartDry">newTubeForStartDry</param>
        /// <param name="newTotalTube">newTotalTube</param>
        /// <param name="newDropTubeConnects">newDropTubeConnects</param>
        /// <param name="newAllowsHeadTo">newAllowsHeadTo</param>
        /// <param name="newRollerGap">newRollerGap</param>
        /// <param name="newHeightNeeded">newHeightNeeded</param>
        /// <param name="newAvailable">newAvailable</param>
        /// <param name="newHoistHeight">newHoistHeight</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newResinsLabel">newResinsLabel</param>
        /// <param name="newDrumContainsLabel">newDrumContainsLabel</param>
        /// <param name="newLinerTubeLabel">newLinerTubeLabel</param>
        /// <param name="newForLbDrumsLabel">newForLbDrumsLabel</param>
        /// <param name="newNetResinLabel">newNetResinLabel</param>
        /// <param name="newCatalystLabel">newCatalystLabel</param> 
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalWorkId, string originalLinerTube, int originalResinId, decimal originalExcessResin, string originalPoundsDrums, decimal originalDrumDiameter, decimal originalHoistMaximumHeight, decimal originalHoistMinimumHeight, decimal originalDownDropTubeLenght, decimal originalPumpHeightAboveGround, int originalTubeResinToFeltFactor, DateTime originalDateOfSheet, int originalEmployeeId, string originalRunDetails, string originalRunDetails2, DateTime originalWetOutDate, DateTime? originalInstallDate, string originalThickness, decimal originalLengthToLine, decimal originalPlusExtra, decimal originalForTurnOffset, decimal originalLengthToWetOut, decimal originalTubeMaxColdHead, decimal originalTubeMaxColdHeadPsi, decimal originalTubeMaxHotHead, decimal originalTubeMaxHotHeadPsi, decimal originalTubeIdealHead, decimal originalTubeIdealHeadPsi, decimal originalNetResinForTube, decimal originalNetResinForTubeUsgals, string originalNetResinForTubeDrumsIns, decimal originalNetResinForTubeLbsFt, decimal originalNetResinForTubeUsgFt, int originalExtraResinForMix, decimal originalExtraLbsForMix, decimal originalTotalMixQuantity, decimal originalTotalMixQuantityUsgals, string originalTotalMixQuantityDrumsIns, string originalInversionType, decimal originalDepthOfInversionMH, decimal originalTubeForColumn, decimal originalTubeForStartDry, decimal originalTotalTube, string originalDropTubeConnects, decimal originalAllowsHeadTo, decimal originalRollerGap, decimal originalHeightNeeded, string originalAvailable, string originalHoistHeight, string originalComments, string originalResinsLabel, string originalDrumContainsLabel, string originalLinerTubeLabel, string originalForLbDrumsLabel, string originalNetResinLabel, string originalCatalystLabel, bool originalDeleted, int originalCompanyId, int newWorkId, string newLinerTube, int newResinId, decimal newExcessResin, string newPoundsDrums, decimal newDrumDiameter, decimal newHoistMaximumHeight, decimal newHoistMinimumHeight, decimal newDownDropTubeLenght, decimal newPumpHeightAboveGround, int newTubeResinToFeltFactor, DateTime newDateOfSheet, int newEmployeeId, string newRunDetails, string newRunDetails2, DateTime newWetOutDate, DateTime? newInstallDate, string newThickness, decimal newLengthToLine, decimal newPlusExtra, decimal newForTurnOffset, decimal newLengthToWetOut, decimal newTubeMaxColdHead, decimal newTubeMaxColdHeadPsi, decimal newTubeMaxHotHead, decimal newTubeMaxHotHeadPsi, decimal newTubeIdealHead, decimal newTubeIdealHeadPsi, decimal newNetResinForTube, decimal newNetResinForTubeUsgals, string newNetResinForTubeDrumsIns, decimal newNetResinForTubeLbsFt, decimal newNetResinForTubeUsgFt, int newExtraResinForMix, decimal newExtraLbsForMix, decimal newTotalMixQuantity, decimal newTotalMixQuantityUsgals, string newTotalMixQuantityDrumsIns, string newInversionType, decimal newDepthOfInversionMH, decimal newTubeForColumn, decimal newTubeForStartDry, decimal newTotalTube, string newDropTubeConnects, decimal newAllowsHeadTo, decimal newRollerGap, decimal newHeightNeeded, string newAvailable, string newHoistHeight, string newComments, string newResinsLabel, string newDrumContainsLabel, string newLinerTubeLabel, string newForLbDrumsLabel, string newNetResinLabel, string newCatalystLabel, bool newDeleted, int newCompanyId)
        {
            WorkFullLengthLiningWetOutGateway workFullLengthLiningWetOutGateway = new WorkFullLengthLiningWetOutGateway(null);
            workFullLengthLiningWetOutGateway.Update(originalWorkId, originalLinerTube, originalResinId, originalExcessResin, originalPoundsDrums, originalDrumDiameter, originalHoistMaximumHeight, originalHoistMinimumHeight, originalDownDropTubeLenght, originalPumpHeightAboveGround, originalTubeResinToFeltFactor, originalDateOfSheet, originalEmployeeId, originalRunDetails, originalRunDetails2, originalWetOutDate, originalInstallDate, originalThickness, originalLengthToLine, originalPlusExtra, originalForTurnOffset, originalLengthToWetOut, originalTubeMaxColdHead, originalTubeMaxColdHeadPsi, originalTubeMaxHotHead, originalTubeMaxHotHeadPsi, originalTubeIdealHead, originalTubeIdealHeadPsi, originalNetResinForTube, originalNetResinForTubeUsgals,  originalNetResinForTubeDrumsIns, originalNetResinForTubeLbsFt, originalNetResinForTubeUsgFt, originalExtraResinForMix, originalExtraLbsForMix, originalTotalMixQuantity, originalTotalMixQuantityUsgals,  originalTotalMixQuantityDrumsIns, originalInversionType, originalDepthOfInversionMH, originalTubeForColumn, originalTubeForStartDry, originalTotalTube, originalDropTubeConnects, originalAllowsHeadTo, originalRollerGap, originalHeightNeeded, originalAvailable, originalHoistHeight, originalComments, originalResinsLabel, originalDrumContainsLabel, originalLinerTubeLabel, originalForLbDrumsLabel, originalNetResinLabel, originalCatalystLabel,  originalDeleted, originalCompanyId, newWorkId,  newLinerTube, newResinId, newExcessResin, newPoundsDrums, newDrumDiameter, newHoistMaximumHeight, newHoistMinimumHeight, newDownDropTubeLenght, newPumpHeightAboveGround, newTubeResinToFeltFactor, newDateOfSheet, newEmployeeId, newRunDetails, newRunDetails2, newWetOutDate, newInstallDate, newThickness, newLengthToLine, newPlusExtra, newForTurnOffset, newLengthToWetOut, newTubeMaxColdHead, newTubeMaxColdHeadPsi, newTubeMaxHotHead, newTubeMaxHotHeadPsi, newTubeIdealHead, newTubeIdealHeadPsi, newNetResinForTube, newNetResinForTubeUsgals,  newNetResinForTubeDrumsIns, newNetResinForTubeLbsFt, newNetResinForTubeUsgFt, newExtraResinForMix, newExtraLbsForMix, newTotalMixQuantity, newTotalMixQuantityUsgals,  newTotalMixQuantityDrumsIns, newInversionType, newDepthOfInversionMH, newTubeForColumn, newTubeForStartDry, newTotalTube, newDropTubeConnects, newAllowsHeadTo, newRollerGap, newHeightNeeded, newAvailable, newHoistHeight, newComments,  newResinsLabel, newDrumContainsLabel, newLinerTubeLabel, newForLbDrumsLabel, newNetResinLabel, newCatalystLabel,  newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>        
        public void DeleteDirect(int originalWorkId, int originalCompanyId)
        {
            // Delete wet out comments
            WorkFullLengthLiningWetOutCommentsGateway workFullLengthLiningWetOutCommentsGateway = new WorkFullLengthLiningWetOutCommentsGateway(null);
            workFullLengthLiningWetOutCommentsGateway.DeleteAll(originalWorkId, originalCompanyId);

            // Delete wet out catalysts
            WorkFullLengthLiningWetOutCatalystsGateway workFullLengthLiningWetOutCatalystsGateway = new WorkFullLengthLiningWetOutCatalystsGateway(null);
            workFullLengthLiningWetOutCatalystsGateway.DeleteAll(originalWorkId, originalCompanyId);
            
            // Delete wet out data
            WorkFullLengthLiningWetOutGateway workFullLengthLiningWetOutGateway = new WorkFullLengthLiningWetOutGateway(null);
            workFullLengthLiningWetOutGateway.Delete(originalWorkId, originalCompanyId);
        }

    }
}
