using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningCatalysts
    /// </summary>
    public class WorkFullLengthLiningCatalysts: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningCatalysts()
            : base("LFS_WORK_FULLLENGTHLINING_CATALYSTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningCatalysts(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_CATALYSTS")
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
        /// InsertDirect a catalyst
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <param name="name">name</param>
        /// <param name="defaultPercentageByWeight">defaultPercentageByWeight</param>
        /// <param name="deleted">deleted</param>       
        /// <param name="companyId">companyId</param>        
        public void InsertDirect(int catalystId, string name, decimal defaultPercentageByWeight, bool deleted, int companyId)
        {
            WorkFullLengthLiningCatalystsGateway workFullLengthLiningCatalystsGateway = new WorkFullLengthLiningCatalystsGateway(null);
            workFullLengthLiningCatalystsGateway.Insert(catalystId, name, defaultPercentageByWeight, deleted, companyId);
        }


        /// <summary>
        /// UpdateDirect a catalyst
        /// </summary>
        /// <param name="originalCatalystId">originalCatalystId</param>
        /// <param name="originalName">originalName</param>
        /// <param name="originalDefaultPercentageByWeight">originalDefaultPercentageByWeight</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newCatalystId">newCatalystId</param>
        /// <param name="newName">newName</param>
        /// <param name="newDefaultPercentageByWeight">newDefaultPercentageByWeight</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalCatalystId, string originalName, decimal originalDefaultPercentageByWeight, bool originalDeleted, int originalCompanyId, int newCatalystId, string newName, decimal newDefaultPercentageByWeight, bool newDeleted, int newCompanyId)
        {
            WorkFullLengthLiningCatalystsGateway workFullLengthLiningCatalystsGateway = new WorkFullLengthLiningCatalystsGateway(null);
            workFullLengthLiningCatalystsGateway.Update(originalCatalystId, originalName, originalDefaultPercentageByWeight, originalDeleted, originalCompanyId, newCatalystId, newName, newDefaultPercentageByWeight, newDeleted, newCompanyId);
        }
                      
  

        /// <summary>
        /// DeleteDirect a catalyst
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int catalystId, int companyId)
        {
            WorkFullLengthLiningCatalystsGateway workFullLengthLiningCatalystsGateway = new WorkFullLengthLiningCatalystsGateway(null);
            workFullLengthLiningCatalystsGateway.Delete(catalystId, companyId);
        }


    }
}