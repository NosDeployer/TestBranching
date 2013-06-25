using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Services
{
    /// <summary>
    /// ServicesNavigator
    /// </summary>
    public class ServicesNavigator : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesNavigator()
            : base("ServicesNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServicesNavigator(DataSet data)
            : base(data, "ServicesNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="whereClause">whereClause</param>
        /// <param name="orderByClause">orderByClause</param>
        /// <param name="conditionValue">conditionValue</param>
        /// <param name="textForSearch">textForSearch</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fmType">fmType</param>
        public void Load(string whereClause, string orderByClause, string conditionValue, string textForSearch, int companyId, string fmType)
        {
            ServicesNavigatorGateway servicesNavigatorGateway = new ServicesNavigatorGateway(Data);
            servicesNavigatorGateway.LoadWhereOrderBy(whereClause, orderByClause, conditionValue, textForSearch);
            UpdateDataForNavigator();
        }



        /// <summary>
        /// LoadForViewsFmTypeCompanyId
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        public void LoadForViewsFmTypeCompanyId(string sqlCommand, string fmType, int companyId)
        {
            ServicesNavigatorGateway servicesNavigatorGateway = new ServicesNavigatorGateway(Data);
            servicesNavigatorGateway.LoadForViewsProjectIdCompanyIdFmType(sqlCommand, companyId, fmType);
            UpdateDataForNavigator();
        }


        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="selected">selected</param>
        public void Update(int serviceId, bool selected)
        {
            ServicesNavigatorTDS.ServicesNavigatorRow serviceNavigatorRow = GetRow(serviceId);
            serviceNavigatorRow.Selected = selected;
        }



        /// <summary>
        /// GetPreviousId
        /// </summary>
        /// <param name="ServicesNavigatorTDS">ServicesNavigatorTDS</param>
        /// <param name="currentServiceId">currentServiceId</param>
        /// <returns>prevServiceId</returns>
        public static int GetPreviousId(ServicesNavigatorTDS servicesNavigatorTDS, int currentServiceId)
        {
            int prevServiceId = currentServiceId;

            for (int i = 0; i < servicesNavigatorTDS.ServicesNavigator.DefaultView.Count; i++)
            {
                if ((int)servicesNavigatorTDS.ServicesNavigator.DefaultView[i]["ServiceID"] == currentServiceId)
                {
                    if (i == 0)
                    {
                        prevServiceId = currentServiceId;
                    }
                    else
                    {
                        prevServiceId = (int)servicesNavigatorTDS.ServicesNavigator.DefaultView[i - 1]["ServiceID"];
                    }

                    break;
                }
            }

            return prevServiceId;
        }



        /// <summary>
        /// GetNextId
        /// </summary>
        /// <param name="ServicesNavigatorTDS">ServicesNavigatorTDS</param>
        /// <param name="currentServiceId">currentServiceId</param>
        /// <returns>nextServiceId</returns>
        public static int GetNextId(ServicesNavigatorTDS servicesNavigatorTDS, int currentServiceId)
        {
            int nextServiceId = currentServiceId;

            for (int i = 0; i < servicesNavigatorTDS.ServicesNavigator.DefaultView.Count; i++)
            {
                if ((int)servicesNavigatorTDS.ServicesNavigator.DefaultView[i]["ServiceID"] == currentServiceId)
                {
                    if (i == servicesNavigatorTDS.ServicesNavigator.DefaultView.Count - 1)
                    {
                        nextServiceId = currentServiceId;
                    }
                    else
                    {
                        nextServiceId = (int)servicesNavigatorTDS.ServicesNavigator.DefaultView[i + 1]["ServiceID"];
                    }
                    break;
                }
            }

            return nextServiceId;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
       
        ///<summary>
        ///Get a single row. If not exists, raise an exception
        ///</summary>
        ///<param name="serviceId">serviceId</param>
        ///<returns>ServicesNavigatorTDS.ServicesNavigatorRow</returns>
        private ServicesNavigatorTDS.ServicesNavigatorRow GetRow(int serviceId)
        {
            ServicesNavigatorTDS.ServicesNavigatorRow row = ((ServicesNavigatorTDS.ServicesNavigatorDataTable)Table).FindByServiceID(serviceId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FM.Services.ServicesNavigator.GetRow");
            }

            return row;
        }



        /// <summary>
        /// UpdateDataForNavigator
        /// </summary>
        private void UpdateDataForNavigator()
        {
            foreach (ServicesNavigatorTDS.ServicesNavigatorRow row in (ServicesNavigatorTDS.ServicesNavigatorDataTable)Table)
            {
                if (row.IsAssignedToNull())
                {
                    ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway();
                    serviceInformationBasicInformationGateway.LoadByServiceId(row.ServiceID, row.COMPANY_ID);
                    if (serviceInformationBasicInformationGateway.GetAssignedThirdPartyVendor(row.ServiceID) != "")
                    {
                        row.AssignedTo = serviceInformationBasicInformationGateway.GetAssignedThirdPartyVendor(row.ServiceID);
                    }
                }

                if (row.IsMTONull()) row.MTO = false;
                if (row.IsCompleteWorkDetailPreventableNull()) row.CompleteWorkDetailPreventable = false;
            }
        }



    }
}