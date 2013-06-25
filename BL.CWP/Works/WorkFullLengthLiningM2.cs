using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningM2
    /// </summary>
    public class WorkFullLengthLiningM2 : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningM2()
            : base("LFS_WORK_FULLLENGTHLINING_M2")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningM2(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_M2")
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
        /// UpdateDirect
        /// </summary>
        /// <param name="sectionAssetId">sectionAssetId</param>
        /// <param name="originalWorkId">originalWorkId</param>        
        /// <param name="originalVideoLength">originalVideoLength</param>
        /// <param name="originalMeasurementTakenBy">originalMeasurementTakenBy</param>
        /// <param name="originalDropPipe">originalDropPipe</param>
        /// <param name="originalDropPipeInvertDepth">originalDropPipeInvertDepth</param>
        /// <param name="originalCappedLaterals">originalCappedLaterals</param>
        /// <param name="originalLineWidthId">originalLineWidthId</param>        
        /// <param name="originalHydrantAddress">originalHydrantAddress</param> 
        /// <param name="originalHydroWireWithin10FtOfInversionMH">originalHydroWireWithin10FtOfInversionMH</param>
        /// <param name="originalDistanceToInversionMH">originalDistanceToInversionMH</param>
        /// <param name="originalSurfaceGrade">originalSurfaceGrade</param>
        /// <param name="originalHydroPulley">originalHydroPulley</param> 
        /// <param name="originalFridgeCart">originalFridgeCart</param> 
        /// <param name="originalTwoPump">originalTwoPump</param> 
        /// <param name="originalSixBypass">originalSixBypass</param> 
        /// <param name="originalScaffolding">originalScaffolding</param> 
        /// <param name="originalWinchExtension">originalWinchExtension</param> 
        /// <param name="originalExtraGenerator">originalExtraGenerator</param> 
        /// <param name="originalGreyCableExtension">originalGreyCableExtension</param> 
        /// <param name="originalEasementMats">originalEasementMats</param> 
        /// <param name="originalRampsRequired">originalRampsRequired</param>  
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalCameraSkid">originalCameraSkid</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>        
        /// <param name="newVideoLength">newVideoLength</param>
        /// <param name="newMeasurementTakenBy">newMeasurementTakenBy</param>
        /// <param name="newDropPipe">newDropPipe</param>
        /// <param name="newDropPipeInvertDepth">newDropPipeInvertDepth</param>
        /// <param name="newCappedLaterals">newCappedLaterals</param>
        /// <param name="newLineWidthId">newLineWidthId</param>         
        /// <param name="newHydrantAddress">newHydrantAddress</param> 
        /// <param name="newHydroWireWithin10FtOfInversionMH">newHydroWireWithin10FtOfInversionMH</param>
        /// <param name="newDistanceToInversionMH">newDistanceToInversionMH</param>   
        /// <param name="newSurfaceGrade">newSurfaceGrade</param>     
        /// <param name="newHydroPulley">newHydroPulley</param> 
        /// <param name="newFridgeCart">newFridgeCart</param> 
        /// <param name="newTwoPump">newTwoPump</param> 
        /// <param name="newSixBypass">newSixBypass</param> 
        /// <param name="newScaffolding">newScaffolding</param> 
        /// <param name="newWinchExtension">newWinchExtension</param> 
        /// <param name="newExtraGenerator">newExtraGenerator</param> 
        /// <param name="newGreyCableExtension">newGreyCableExtension</param> 
        /// <param name="newEasementMats">newEasementMats</param> 
        /// <param name="newRampsRequired">newRampsRequired</param>     
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newCameraSkid">newCameraSkid</param>
        public void UpdateDirect(int sectionAssetId, int originalWorkId, string originalVideoLength, string originalMeasurementTakenBy, bool originalDropPipe, string originalDropPipeInvertDepth, int? originalCappedLaterals, string originalLineWidthId, string originalHydrantAddress, string originalHydroWireWithin10FtOfInversionMH, string originalDistanceToInversionMH, string originalSurfaceGrade, bool originalHydroPulley, bool originalFridgeCart, bool originalTwoPump, bool originalSixBypass, bool originalScaffolding, bool originalWinchExtension, bool originalExtraGenerator, bool originalGreyCableExtension, bool originalEasementMats, bool originalRampsRequired, bool originalDeleted, int originalCompanyId, bool originalCameraSkid, int newWorkId, string newVideoLength, string newMeasurementTakenBy, bool newDropPipe, string newDropPipeInvertDepth, int? newCappedLaterals, string newLineWidthId, string newHydrantAddress, string newHydroWireWithin10FtOfInversionMH, string newDistanceToInversionMH, string newSurfaceGrade, bool newHydroPulley, bool newFridgeCart, bool newTwoPump, bool newSixBypass, bool newScaffolding, bool newWinchExtension, bool newExtraGenerator, bool newGreyCableExtension, bool newEasementMats, bool newRampsRequired, bool newDeleted, int newCompanyId, bool newCameraSkid)
        {
            WorkFullLengthLiningM2Gateway workFullLengthLiningM2Gateway = new WorkFullLengthLiningM2Gateway(null);
            workFullLengthLiningM2Gateway.Update(originalWorkId, originalVideoLength, originalMeasurementTakenBy, originalDropPipe, originalDropPipeInvertDepth, originalCappedLaterals, originalLineWidthId, originalHydrantAddress, originalHydroWireWithin10FtOfInversionMH, originalDistanceToInversionMH, originalSurfaceGrade, originalHydroPulley, originalFridgeCart, originalTwoPump, originalSixBypass, originalScaffolding, originalWinchExtension, originalExtraGenerator, originalGreyCableExtension, originalEasementMats, originalRampsRequired, originalDeleted, originalCompanyId, originalCameraSkid, newWorkId, newVideoLength, newMeasurementTakenBy, newDropPipe, newDropPipeInvertDepth, newCappedLaterals, newLineWidthId,  newHydrantAddress, newHydroWireWithin10FtOfInversionMH, newDistanceToInversionMH, newSurfaceGrade, newHydroPulley, newFridgeCart, newTwoPump, newSixBypass, newScaffolding, newWinchExtension, newExtraGenerator, newGreyCableExtension, newEasementMats, newRampsRequired, newDeleted, newCompanyId, newCameraSkid);
        }



        /// <summary>
        /// UpdateVideoLengthDirect
        /// </summary>
        /// <param name="sectionAssetId">sectionAssetId</param>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalVideoLength">originalVideoLength</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newVideoLength">newVideoLength</param>
        /// <param name="newDeleted"></param>
        /// <param name="newCompanyId"></param>
        public void UpdateVideoLengthDirect(int sectionAssetId, int originalWorkId, string originalVideoLength, bool originalDeleted, int originalCompanyId, int newWorkId, string newVideoLength, bool newDeleted, int newCompanyId)
        {
            WorkFullLengthLiningM2Gateway workFullLengthLiningM2Gateway = new WorkFullLengthLiningM2Gateway(null);
            workFullLengthLiningM2Gateway.UpdateVideoLength(originalWorkId, originalVideoLength, originalDeleted, originalCompanyId, newWorkId, newVideoLength, newDeleted, newCompanyId);
        }
        


        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, int companyId)
        {
            // Delete WorkFullLengthLiningLateral
            WorkFullLengthLiningM1Lateral workFullLengthLiningM1Lateral = new WorkFullLengthLiningM1Lateral(null);
            workFullLengthLiningM1Lateral.Delete(workId, companyId);

            // Delete m2 data
            WorkFullLengthLiningM2Gateway workFullLengthLiningM2Gateway = new WorkFullLengthLiningM2Gateway(null);
            workFullLengthLiningM2Gateway.Delete(workId, companyId);
        }



    }
}