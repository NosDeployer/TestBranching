using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitInformationServiceDetails
    /// </summary>
    public class UnitInformationServiceDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitInformationServiceDetails()
            : base("ServiceDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitInformationServiceDetails(DataSet data)
            : base(data, "ServiceDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitInformationTDS();
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void Load(int unitId, int companyId)
        {
            UnitInformationServiceDetailsGateway unitInformationServiceDetailsGateway = new UnitInformationServiceDetailsGateway(Data);
            unitInformationServiceDetailsGateway.LoadByUnitId(unitId, companyId);            
        }     
                         
        

    }
}


