using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningInversion
    /// </summary>
    public class WorkFullLengthLiningInversion: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningInversion()
            : base("LFS_WORK_FULLLENGTHLINING_INVERSION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningInversion(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_INVERSION")
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
        /// <param name="comment">comment</param>
        /// <param name="pipeType">pipeType</param>
        /// <param name="pipeCondition">pipeCondition</param>
        /// <param name="groundMoisture">groundMoisture</param>
        /// <param name="boilerSize">boilerSize</param>
        /// <param name="pumpTotalCapacity">pumpTotalCapacity</param>
        /// <param name="layFlatSize">layFlatSize</param>
        /// <param name="layFlatQuantityTotal">layFlatQuantityTotal</param>
        /// <param name="waterStartTemp">waterStartTemp</param>
        /// <param name="temp1">temp1</param>
        /// <param name="holdAtT1">holdAtT1</param>
        /// <param name="temp2">temp2</param>
        /// <param name="cookAt2">cookAt2</param>         
        /// <param name="coolDownFor">coolDownFor</param>
        /// <param name="coolToTemp">coolToTemp</param>
        /// <param name="dropInPipeRun">dropInPipeRun</param>
        /// <param name="pipeSlopOf">pipeSlopOf</param>
        /// <param name="f45F120">f45F120</param>
        /// <param name="hold">hold</param>
        /// <param name="f120F185">f120F185</param>
        /// <param name="cookTime">cookTime</param>
        /// <param name="coolTime">coolTime</param>
        /// <param name="aproxTotal">aproxTotal</param>
        /// <param name="waterChangesPerHour">waterChangesPerHour</param>
        /// <param name="returnWaterVelocity">returnWaterVelocity</param>
        /// <param name="layflatBackPressure">layflatBackPressure</param>
        /// <param name="pumpLiftAtIdealHead">pumpLiftAtIdealHead</param>
        /// <param name="waterToFillLinerColumn">waterToFillLinerColumn</param>
        /// <param name="waterPerFit">waterPerFit</param>
        /// <param name="installationResults">installationResults</param>
        /// <param name="linerTubeLabel">inerTubeLabel</param>
        /// <param name="headsIdealLabel">headsIdealLabel</param>
        /// <param name="pumpingAndCirculationLabel">pumpingAndCirculationLabel</param>,
        /// <param name="deleted">deleted</param>       
        /// <param name="companyId">companyId</param>      
        public void InsertDirect(int workId, string comment, string pipeType, string pipeCondition, string groundMoisture, decimal boilerSize, decimal pumpTotalCapacity, decimal layFlatSize, decimal layFlatQuantityTotal, decimal waterStartTemp, decimal temp1, decimal holdAtT1, decimal temp2, decimal cookAt2, decimal coolDownFor, decimal coolToTemp, decimal dropInPipeRun, decimal pipeSlopOf, decimal f45F120, decimal hold, decimal f120F185, decimal cookTime, decimal coolTime, decimal aproxTotal, decimal waterChangesPerHour, decimal returnWaterVelocity, decimal layflatBackPressure, decimal pumpLiftAtIdealHead, decimal waterToFillLinerColumn, decimal waterPerFit, string installationResults, string linerTubeLabel, string headsIdealLabel, string pumpingAndCirculationLabel, bool deleted, int companyId)
        {
            WorkFullLengthLiningInversionGateway workFullLengthLiningInversionGateway = new WorkFullLengthLiningInversionGateway(Data);
            workFullLengthLiningInversionGateway.Insert(workId, comment, pipeType,  pipeCondition,  groundMoisture,  boilerSize,  pumpTotalCapacity,  layFlatSize,  layFlatQuantityTotal,  waterStartTemp,  temp1,  holdAtT1, temp2, cookAt2,  coolDownFor,  coolToTemp,  dropInPipeRun,  pipeSlopOf,  f45F120,  hold,  f120F185,  cookTime,  coolTime,  aproxTotal,  waterChangesPerHour,  returnWaterVelocity,  layflatBackPressure,  pumpLiftAtIdealHead,  waterToFillLinerColumn,  waterPerFit,  installationResults, linerTubeLabel, headsIdealLabel, pumpingAndCirculationLabel,  deleted,  companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalComment">originalComment</param>
        /// <param name="originalPipeType">originalPipeType</param>
        /// <param name="originalPipeCondition">originalPipeCondition</param>
        /// <param name="originalGroundMoisture">originalGroundMoisture</param>
        /// <param name="originalBoilerSize">originalBoilerSize</param>
        /// <param name="originalPumpTotalCapacity">originalPumpTotalCapacity</param>
        /// <param name="originalLayFlatSize">originalLayFlatSize</param>
        /// <param name="originalLayFlatQuantityTotal">originalLayFlatQuantityTotal</param>
        /// <param name="originalWaterStartTemp">originalWaterStartTemp</param>
        /// <param name="originalTemp1">originalTemp1</param>
        /// <param name="originalHoldAtT1">originalHoldAtT1</param>
        /// <param name="originalTempT2">originalTempT2</param>
        /// <param name="originalCookAtT2">originalCookAtT2</param>        
        /// <param name="originalCoolDownFor">originalCoolDownFor</param>
        /// <param name="originalCoolToTemp">originalCoolToTemp</param>
        /// <param name="originalDropInPipeRun">originalDropInPipeRun</param>
        /// <param name="originalPipeSlopOf">originalPipeSlopOf</param>
        /// <param name="originalF45F120">originalF45F120</param>
        /// <param name="originalHold">originalHold</param>
        /// <param name="originalF120F185">originalF120F185</param>
        /// <param name="originalCookTime">originalCookTime</param>
        /// <param name="originalCoolTime">originalCoolTime</param>
        /// <param name="originalAproxTotal">originalAproxTotal</param>
        /// <param name="originalWaterChangesPerHour">originalWaterChangesPerHour</param>
        /// <param name="originalReturnWaterVelocity">originalReturnWaterVelocity</param>
        /// <param name="originalLayflatBackPressure">originalLayflatBackPressure</param>
        /// <param name="originalPumpLiftAtIdealHead">originalPumpLiftAtIdealHead</param>
        /// <param name="originalWaterToFillLinerColumn">originalWaterToFillLinerColumn</param>
        /// <param name="originalWaterPerFit">originalWaterPerFit</param>
        /// <param name="originalInstallationResults">originalInstallationResults</param>
        /// <param name="originalLinerTubeLabel">originalLinerTubeLabel</param>
        /// <param name="originalHeadsIdealLabel">originalHeadsIdealLabel</param>
        /// <param name="originalPumpingAndCirculationLabel">originalPumpingAndCirculationLabel</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newComment">newComment</param>
        /// <param name="newPipeType">newPipeType</param>
        /// <param name="newPipeCondition">newPipeCondition</param>
        /// <param name="newGroundMoisture">newGroundMoisture</param>
        /// <param name="newBoilerSize">newBoilerSize</param>
        /// <param name="newPumpTotalCapacity">newPumpTotalCapacity</param>
        /// <param name="newLayFlatSize">newLayFlatSize</param>
        /// <param name="newLayFlatQuantityTotal">newLayFlatQuantityTotal</param>
        /// <param name="newWaterStartTemp">newWaterStartTemp</param>
        /// <param name="newTemp1">newTemp1</param>
        /// <param name="newHoldAtT1">newHoldAtT1</param>
        /// <param name="newTempT2">newTempT2</param>
        /// <param name="newCookAtT2">newCookAtT2</param>        
        /// <param name="newCoolDownFor">newCoolDownFor</param>
        /// <param name="newCoolToTemp">newCoolToTemp</param>
        /// <param name="newDropInPipeRun">newDropInPipeRun</param>
        /// <param name="newPipeSlopOf">newPipeSlopOf</param>
        /// <param name="newF45F120">newF45F120</param>
        /// <param name="newHold">newHold</param>
        /// <param name="newF120F185">newF120F185</param>
        /// <param name="newCookTime">newCookTime</param>
        /// <param name="newCoolTime">newCoolTime</param>
        /// <param name="newAproxTotal">newAproxTotal</param>
        /// <param name="newWaterChangesPerHour">newWaterChangesPerHour</param>
        /// <param name="newReturnWaterVelocity">newReturnWaterVelocity</param>
        /// <param name="newLayflatBackPressure">newLayflatBackPressure</param>
        /// <param name="newPumpLiftAtIdealHead">newPumpLiftAtIdealHead</param>
        /// <param name="newWaterToFillLinerColumn">newWaterToFillLinerColumn</param>
        /// <param name="newWaterPerFit">newWaterPerFit</param>
        /// <param name="newInstallationResults">newInstallationResults</param>
        /// <param name="newLinerTubeLabel">newLinerTubeLabel</param>
        /// <param name="newHeadsIdealLabel">newHeadsIdealLabel</param>
        /// <param name="newPumpingAndCirculationLabel">newPumpingAndCirculationLabel</param>        
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalWorkId, string originalComment, string originalPipeType, string originalPipeCondition, string originalGroundMoisture, decimal originalBoilerSize, decimal originalPumpTotalCapacity, decimal originalLayFlatSize, decimal originalLayFlatQuantityTotal, decimal originalWaterStartTemp, decimal originalTemp1, decimal originalHoldAtT1, decimal originalTempT2, decimal originalCookAtT2, decimal originalCoolDownFor, decimal originalCoolToTemp, decimal originalDropInPipeRun, decimal originalPipeSlopOf, decimal originalF45F120, decimal originalHold, decimal originalF120F185, decimal originalCookTime, decimal originalCoolTime, decimal originalAproxTotal, decimal originalWaterChangesPerHour, decimal originalReturnWaterVelocity, decimal originalLayflatBackPressure, decimal originalPumpLiftAtIdealHead, decimal originalWaterToFillLinerColumn, decimal originalWaterPerFit, string originalInstallationResults, string originalLinerTubeLabel, string originalHeadsIdealLabel, string originalPumpingAndCirculationLabel, bool originalDeleted, int originalCompanyId, int newWorkId, string newComment, string newPipeType, string newPipeCondition, string newGroundMoisture, decimal newBoilerSize, decimal newPumpTotalCapacity, decimal newLayFlatSize, decimal newLayFlatQuantityTotal, decimal newWaterStartTemp, decimal newTemp1, decimal newHoldAtT1, decimal newTempT2, decimal newCookAtT2, decimal newCoolDownFor, decimal newCoolToTemp, decimal newDropInPipeRun, decimal newPipeSlopOf, decimal newF45F120, decimal newHold, decimal newF120F185, decimal newCookTime, decimal newCoolTime, decimal newAproxTotal, decimal newWaterChangesPerHour, decimal newReturnWaterVelocity, decimal newLayflatBackPressure, decimal newPumpLiftAtIdealHead, decimal newWaterToFillLinerColumn, decimal newWaterPerFit, string newInstallationResults, string newLinerTubeLabel, string newHeadsIdealLabel, string newPumpingAndCirculationLabel, bool newDeleted, int newCompanyId)
        {
            WorkFullLengthLiningInversionGateway workFullLengthLiningInversionGateway = new WorkFullLengthLiningInversionGateway(null);
            workFullLengthLiningInversionGateway.Update(originalWorkId, originalComment, originalPipeType, originalPipeCondition, originalGroundMoisture, originalBoilerSize, originalPumpTotalCapacity, originalLayFlatSize, originalLayFlatQuantityTotal, originalWaterStartTemp, originalTemp1, originalHoldAtT1, originalTempT2, originalCookAtT2, originalCoolDownFor, originalCoolToTemp, originalDropInPipeRun, originalPipeSlopOf, originalF45F120, originalHold, originalF120F185, originalCookTime, originalCoolTime, originalAproxTotal, originalWaterChangesPerHour, originalReturnWaterVelocity, originalLayflatBackPressure, originalPumpLiftAtIdealHead, originalWaterToFillLinerColumn, originalWaterPerFit, originalInstallationResults, originalLinerTubeLabel, originalHeadsIdealLabel, originalPumpingAndCirculationLabel, originalDeleted, originalCompanyId, newWorkId, newComment, newPipeType, newPipeCondition, newGroundMoisture, newBoilerSize, newPumpTotalCapacity, newLayFlatSize, newLayFlatQuantityTotal, newWaterStartTemp, newTemp1, newHoldAtT1, newTempT2, newCookAtT2, newCoolDownFor, newCoolToTemp, newDropInPipeRun, newPipeSlopOf, newF45F120, newHold, newF120F185, newCookTime, newCoolTime, newAproxTotal, newWaterChangesPerHour, newReturnWaterVelocity, newLayflatBackPressure, newPumpLiftAtIdealHead, newWaterToFillLinerColumn, newWaterPerFit, newInstallationResults, newLinerTubeLabel, newHeadsIdealLabel, newPumpingAndCirculationLabel, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, int companyId)
        {
            // delete field cure records                
            WorkFullLengthLiningInversionFieldCureRecordGateway workFullLengthLiningInversionFieldCureRecordGateway = new WorkFullLengthLiningInversionFieldCureRecordGateway();
            workFullLengthLiningInversionFieldCureRecordGateway.LoadByWorkId(workId, companyId);

            if (workFullLengthLiningInversionFieldCureRecordGateway.Table.Rows.Count > 0)
            {
                WorkFullLengthLiningInversionFieldCureRecord workFullLengthLiningInversionFieldCureRecord = new WorkFullLengthLiningInversionFieldCureRecord(null);
                workFullLengthLiningInversionFieldCureRecord.DeleteAllDirect(workId, companyId);
            }

            // Delete inversion
            WorkFullLengthLiningInversionGateway workFullLengthLiningInversionGateway = new WorkFullLengthLiningInversionGateway(Data);
            workFullLengthLiningInversionGateway.Delete(workId, companyId);
        }

    }
}
