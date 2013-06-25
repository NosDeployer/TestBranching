using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using LiquiForce.LFSLive.DA.FleetManagement.Services;


namespace LiquiForce.LFSLive.WebUI.FleetManagement.Services
{
    /// <summary>
    /// Summary description for servicesThirdPartyVendor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class servicesThirdPartyVendor : System.Web.Services.WebService
    {

        [WebMethod]
        public String[] GetThirdPartyVendorList(string prefixText, int count, string contextKey)
        {
            // split serviceId, companyId
            string[] location = Regex.Split(contextKey, ",");

            Int32 serviceId = Int32.Parse(location[0]);
            int companyId = int.Parse(location[1]);

            // load MHs
            ServicesThirdPartyVendorGateway servicesThirdPartyVendorGateway = new ServicesThirdPartyVendorGateway();
            servicesThirdPartyVendorGateway.LoadSimilarTop12ThirdPartyVendorByServiceId(serviceId, prefixText, companyId);

            // process list and return
            if (servicesThirdPartyVendorGateway.Table.Rows.Count == 0)
            {
                return new string[0];
            }
            else
            {
                List<string> items = new List<string>(count);
                for (int i = 0; (i < count) & (i < servicesThirdPartyVendorGateway.Table.Rows.Count); i++)
                {
                    items.Add(servicesThirdPartyVendorGateway.Table.Rows[i]["AssignThirdPartyVendor"].ToString());
                }

                return items.ToArray();
            }

        }
    }
}
