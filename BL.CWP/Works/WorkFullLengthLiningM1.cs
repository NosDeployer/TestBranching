using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningM1
    /// </summary>
    public class WorkFullLengthLiningM1 : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningM1()
            : base("LFS_WORK_FULLLENGTHLINING_M1")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningM1(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_M1")
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
        /// UpdateDirect a work
        /// </summary>
        /// <param name="originalWorkId">originalWorkId></param>
        /// <param name="originalMeasurementsTakenBy">originalMeasurementsTakenBy</param> 
        /// <param name="originalTrafficControl">originalTrafficControl</param>
        /// <param name="originalSiteDetails">originalSiteDetails</param>
        /// <param name="originalPipeSizeChange">originalPipeSizeChange</param> 
        /// <param name="originalStandardByPass">originalStandardByPass</param>         
        /// <param name="originalStandardBypassComments">originalStandardBypassComments</param> 
        /// <param name="originalTrafficControlDetails">originalTrafficControlDetails</param> 
        /// <param name="originalMeasurementType">originalMeasurementType</param>
        /// <param name="originalMeasurementFromMh">originalMeasurementFromMh</param>
        /// <param name="originalVideoDoneFromMh">originalVideoDoneFromMh</param>
        /// <param name="originalVideoDoneToMh">originalVideoDoneToMh</param>
        /// <param name="originalRoboticPrepDate">originalRoboticPrepDate</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalIssue">originalIssue</param>
        /// <param name="originalAccessType">originalAccessType</param>
        /// 
        /// <param name="newWorkId">newWorkid</param>
        /// <param name="newMeasurementsTakenBy">newMeasurementsTakenBy</param>
        /// <param name="newTrafficControl">newTrafficControl</param>
        /// <param name="newSiteDetails">newSiteDetails</param>
        /// <param name="newPipeSizeChange">newPipeSizeChange</param> 
        /// <param name="newStandardByPass">newStandardByPass</param>         
        /// <param name="newStandardBypassComments">newStandardBypassComments</param> 
        /// <param name="newTrafficControlDetails">newTrafficControlDetails</param> 
        /// <param name="newMeasurementType">newMeasurementType</param>
        /// <param name="newMeasurementFromMh">newMeasurementFromMh</param>
        /// <param name="newVideoDoneFromMh">newVideoDoneFromMh</param>
        /// <param name="newVideoDoneToMh">newVideoDoneToMh</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newAccessType">newAccessType</param>
        public void UpdateDirect(int originalWorkId, string originalMeasurementsTakenBy, string originalTrafficControl, string originalSiteDetails, bool originalPipeSizeChange, bool originalStandardByPass, string originalStandardBypassComments, string originalTrafficControlDetails, string originalMeasurementType, string originalMeasurementFromMh, string originalVideoDoneFromMh, string originalVideoDoneToMh,  bool originalDeleted, int originalCompanyId, string originalAccessType, int newWorkId, string newMeasurementsTakenBy, string newTrafficControl, string newSiteDetails, bool newPipeSizeChange, bool newStandardByPass, string newStandardBypassComments, string newTrafficControlDetails, string newMeasurementType, string newMeasurementFromMh, string newVideoDoneFromMh, string newVideoDoneToMh, bool newDeleted, int newCompanyId, string newAccessType)
        {
            WorkFullLengthLiningM1Gateway workFullLengthLiningM1Gateway = new WorkFullLengthLiningM1Gateway(null);
            workFullLengthLiningM1Gateway.Update(originalWorkId, originalMeasurementsTakenBy, originalTrafficControl, originalSiteDetails, originalPipeSizeChange, originalStandardByPass, originalStandardBypassComments, originalTrafficControlDetails, originalMeasurementType, originalMeasurementFromMh, originalVideoDoneFromMh, originalVideoDoneToMh, originalDeleted, originalCompanyId, originalAccessType, newWorkId, newMeasurementsTakenBy, newTrafficControl, newSiteDetails, newPipeSizeChange, newStandardByPass, newStandardBypassComments, newTrafficControlDetails, newMeasurementType, newMeasurementFromMh, newVideoDoneFromMh, newVideoDoneToMh, newDeleted, newCompanyId, newAccessType);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, int companyId)
        {
            WorkFullLengthLiningM1Gateway workFullLengthLiningM1Gateway = new WorkFullLengthLiningM1Gateway(null);
            workFullLengthLiningM1Gateway.Delete(workId, companyId);
        }



    }
}