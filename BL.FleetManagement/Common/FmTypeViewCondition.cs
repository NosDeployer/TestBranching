using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Common;

namespace LiquiForce.LFSLive.BL.FleetManagement.Common
{
    /// <summary>
    /// FmTypeViewCondition
    /// </summary>
    public class FmTypeViewCondition : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmTypeViewCondition()
            : base("LFS_FM_TYPE_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmTypeViewCondition(DataSet data)
            : base(data, "LFS_FM_TYPE_VIEW_CONDITION")
        {
        }
                           


        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FmViewTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByFmTypeConditionId
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="conditionId">conditionId</param>
        public void LoadByFmTypeConditionId(string fmType, int companyId, int conditionId)
        {
            FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway(Data);
            fmTypeViewConditionGateway.LoadByFmTypeConditionId(fmType, companyId, conditionId);           
        }
        


    }
}