using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningP1
    /// </summary>
    public class WorkFullLengthLiningP1 : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningP1()
            : base("LFS_WORK_FULLLENGTHLINING_P1")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningP1(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_P1")
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
        /// <param name="originalCxisRemoved">originalCxisRemoved</param>
        /// <param name="originalRoboticPrepCompleted">originalRoboticPrepCompleted</param>
        /// <param name="originalRoboticPrepCompletedDate">originalRoboticPrepCompletedDate</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalP1Completed">originalP1Completed</param>
        /// 
        /// <param name="newWorkId">newWorkId></param>
        /// <param name="newCxisRemoved">newCxisRemoved</param>
        /// <param name="newRoboticPrepCompleted">newRoboticPrepCompleted</param>
        /// <param name="newRoboticPrepCompletedDate">newRoboticPrepCompletedDate</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newP1Completed">newP1Completed</param>
        public void UpdateDirect(int originalWorkId, int? originalCxisRemoved, bool originalRoboticPrepCompleted, DateTime? originalRoboticPrepCompletedDate, bool originalDeleted, int originalCompanyId, bool originalP1Completed, int newWorkId, int? newCxisRemoved, bool newRoboticPrepCompleted, DateTime? newRoboticPrepCompletedDate, bool newDeleted, int newCompanyId, bool newP1Completed)
        {
            WorkFullLengthLiningP1Gateway workFullLengthLiningP1Gateway = new WorkFullLengthLiningP1Gateway(null);
            workFullLengthLiningP1Gateway.Update(originalWorkId, originalCxisRemoved, originalDeleted, originalCompanyId, originalRoboticPrepCompleted, originalRoboticPrepCompletedDate, originalP1Completed, newWorkId, newCxisRemoved, newDeleted, newCompanyId, newRoboticPrepCompleted, newRoboticPrepCompletedDate, newP1Completed);
        }

                      
  
        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, int companyId)
        {
            WorkFullLengthLiningP1Gateway workFullLengthLiningP1Gateway = new WorkFullLengthLiningP1Gateway(null);
            workFullLengthLiningP1Gateway.Delete(workId, companyId);
        }


        
    }
}