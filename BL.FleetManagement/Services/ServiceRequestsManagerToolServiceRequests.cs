using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Services
{
    /// <summary>
    /// ServiceRequestsManagerToolServiceRequests
    /// </summary>
    public class ServiceRequestsManagerToolServiceRequests : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceRequestsManagerToolServiceRequests()
            : base("ServiceRequests")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServiceRequestsManagerToolServiceRequests(DataSet data)
            : base(data, "ServiceRequests")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServiceRequestsManagerToolTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAll
        /// </summary>                     
        /// <param name="companyId">companyId</param>
        public void LoadAll(int companyId)
        {
            ServiceRequestsManagerToolServiceRequestsGateway serviceRequestsManagerToolServiceRequestsGateway = new ServiceRequestsManagerToolServiceRequestsGateway(Data);
            serviceRequestsManagerToolServiceRequestsGateway.LoadAll(companyId);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="selected">selected</param>
        public void Update(int serviceId, bool selected)
        {
            ServiceRequestsManagerToolTDS.ServiceRequestsRow row = GetRow(serviceId);
            row.Selected = selected;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        ///<summary>
        ///Get a single row. If not exists, raise an exception
        ///</summary>
        ///<param name="serviceId">serviceId</param>
        ///<returns>ServiceRequestsManagerToolTDS.ServiceRequestsRow</returns>
        private ServiceRequestsManagerToolTDS.ServiceRequestsRow GetRow(int serviceId)
        {
            ServiceRequestsManagerToolTDS.ServiceRequestsRow row = ((ServiceRequestsManagerToolTDS.ServiceRequestsDataTable)Table).FindByServiceID(serviceId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Services.ServiceRequestsManagementToolServiceRequests.GetRow");
            }

            return row;
        }
    }
}

