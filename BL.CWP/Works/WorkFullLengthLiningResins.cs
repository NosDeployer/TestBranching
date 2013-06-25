using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningResins
    /// </summary>
    public class WorkFullLengthLiningResins : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningResins()
            : base("LFS_WORK_FULLLENGTHLINING_RESINS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningResins(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_RESINS")
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
        /// InsertDirect a resin
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <param name="resinMake">resinMake</param>
        /// <param name="resinType">resinType</param>
        /// <param name="resinNumber">resinNumber</param>
        /// <param name="lbUsg">lbUsg</param>
        /// <param name="lbDrums">lbDrums</param>
        /// <param name="activeResin">activeResin</param>
        /// <param name="applyCatalystTo">applyCatalystTo</param>
        /// <param name="filter">filter</param>
        /// <param name="deleted">deleted</param>       
        /// <param name="companyId">companyId</param>        
        public void InsertDirect(int resinId, string resinMake, string resinType, string resinNumber, decimal lbUsg, int lbDrums, decimal activeResin, string applyCatalystTo, decimal filter, bool deleted, int companyId)
        {
            WorkFullLengthLiningResinsGateway workFullLengthLiningResinsGateway = new WorkFullLengthLiningResinsGateway(null);
            workFullLengthLiningResinsGateway.Insert(resinId, resinMake, resinType, resinNumber, lbUsg, lbDrums, activeResin, applyCatalystTo, filter, deleted, companyId);
        }


        /// <summary>
        /// UpdateDirect a resin
        /// </summary>
        /// <param name="originalResinId">originalResinId</param>
        /// <param name="originalResinMake">originalResinMake</param>
        /// <param name="originalResinType">originalResinType</param>
        /// <param name="originalResinNumber">originalResinNumber</param>
        /// <param name="originalLbUsg">originalLbUsg</param>
        /// <param name="originalLbDrums">originalLbDrums</param>
        /// <param name="originalActiveResin">originalActiveResin</param>
        /// <param name="originalApplyCatalystTo">originalApplyCatalystTo</param>
        /// <param name="originalFilter">originalFilter</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newResinId">newResinId</param>
        /// <param name="newResinMake">newResinMake</param>
        /// <param name="newResinType">newResinType</param>
        /// <param name="newResinNumber">newResinNumber</param>
        /// <param name="newLbUsg">newLbUsg</param>
        /// <param name="newLbDrums">newLbDrums</param>
        /// <param name="newActiveResin">newActiveResin</param>
        /// <param name="newApplyCatalystTo">newApplyCatalystTo</param>
        /// <param name="newFilter">newFilter</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalResinId, string originalResinMake, string originalResinType, string originalResinNumber, decimal originalLbUsg, int originalLbDrums, decimal originalActiveResin, string originalApplyCatalystTo, decimal originalFilter, bool originalDeleted, int originalCompanyId, int newResinId, string newResinMake, string newResinType, string newResinNumber, decimal newLbUsg, int newLbDrums, decimal newActiveResin, string newApplyCatalystTo, decimal newFilter, bool newDeleted, int newCompanyId)
        {
            WorkFullLengthLiningResinsGateway workFullLengthLiningResinsGateway = new WorkFullLengthLiningResinsGateway(null);
            workFullLengthLiningResinsGateway.Update(originalResinId, originalResinMake, originalResinType, originalResinNumber, originalLbUsg, originalLbDrums, originalActiveResin, originalApplyCatalystTo, originalFilter, originalDeleted, originalCompanyId, newResinId, newResinMake, newResinType, newResinNumber, newLbUsg, newLbDrums, newActiveResin, newApplyCatalystTo, newFilter, newDeleted, newCompanyId);
        }
                      
  

        /// <summary>
        /// DeleteDirect a resin
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int resinId, int companyId)
        {
            WorkFullLengthLiningResinsGateway workFullLengthLiningResinsGateway = new WorkFullLengthLiningResinsGateway(null);
            workFullLengthLiningResinsGateway.Delete(resinId, companyId);
        }



    }
}
