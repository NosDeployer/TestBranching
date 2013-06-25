using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningWetOutCatalysts
    /// </summary>
    public class WorkFullLengthLiningWetOutCatalysts: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningWetOutCatalysts()
            : base("LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningWetOutCatalysts(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS")
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
        /// Insert a new wet out catalyst (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="catalystId">catalystId</param>
        /// <param name="percentageByWeight">percentageByWeight</param>
        /// <param name="lbsForMixQuantity">lbsForMixQuantity</param>
        /// <param name="lbsForDrum">lbsForDrum</param>
        /// <param name="deleted">deleted</param>       
        /// <param name="companyId">companyId</param>        
        /// <returns></returns>
        public void InsertDirect(int workId, int refId, int catalystId, decimal percentageByWeight, decimal lbsForMixQuantity, string lbsForDrum, bool deleted, int companyId)
        {
            WorkFullLengthLiningWetOutCatalystsGateway workFullLengthLiningWetOutCatalystsGateway = new WorkFullLengthLiningWetOutCatalystsGateway(null);
            workFullLengthLiningWetOutCatalystsGateway.Insert(workId, refId, catalystId, percentageByWeight, lbsForMixQuantity, lbsForDrum, deleted, companyId);
        }
               


        /// <summary>
        /// Update direct a new wet out catalyst
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCatalystId">originalCatalystId</param>        
        /// <param name="originalPercentageByWeight">originalPercentageByWeight</param>
        /// <param name="originalLbsForMixQuantity">originalLbsForMixQuantity</param>
        /// <param name="originalLbsForDrum">originalLbsForDrum</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newCatalystId">newCatalystId</param>        
        /// <param name="newPercentageByWeight">newPercentageByWeight</param>
        /// <param name="newLbsForMixQuantity">newLbsForMixQuantity</param>
        /// <param name="newLbsForDrum">newLbsForDrum</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalWorkId, int originalRefId, int originalCatalystId, decimal originalPercentageByWeight, decimal originalLbsForMixQuantity, string originalLbsForDrum, bool originalDeleted, int originalCompanyId, int newWorkId, int newRefId, int newCatalystId, decimal newPercentageByWeight, decimal newLbsForMixQuantity, string newLbsForDrum, bool newDeleted, int newCompanyId)
        {
            WorkFullLengthLiningWetOutCatalystsGateway workFullLengthLiningWetOutCatalystsGateway = new WorkFullLengthLiningWetOutCatalystsGateway(null);
            workFullLengthLiningWetOutCatalystsGateway.Update(originalWorkId, originalRefId, originalCatalystId, originalPercentageByWeight, originalLbsForMixQuantity, originalLbsForDrum, originalDeleted, originalCompanyId, newWorkId, newRefId, newCatalystId, newPercentageByWeight, newLbsForMixQuantity, newLbsForDrum, newDeleted, newCompanyId);
        }
                

        
        /// <summary>
        /// DeleteDirect 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        public void DeleteDirect(int workId, int refId, int originalCompanyId)
        {
            WorkFullLengthLiningWetOutCatalystsGateway workFullLengthLiningWetOutCatalystsGateway = new WorkFullLengthLiningWetOutCatalystsGateway(null);
            workFullLengthLiningWetOutCatalystsGateway.Delete(workId, refId, originalCompanyId);
        }



        /// <summary>
        /// DeleteAllDirect
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int workId, int companyId)
        {
            WorkFullLengthLiningWetOutCatalystsGateway workFullLengthLiningWetOutCatalystsGateway = new WorkFullLengthLiningWetOutCatalystsGateway(null);
            workFullLengthLiningWetOutCatalystsGateway.DeleteAll(workId, companyId);
        }

    }
}
