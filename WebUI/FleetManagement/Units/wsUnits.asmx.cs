using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Units
{
    /// <summary>
    /// Summary description for wsUnits
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService()]
    public class wsUnits : System.Web.Services.WebService
    {
        [WebMethod]
        public String[] GetManufacturerList(string prefixText, int count, string contextKey)
        {
            int companyId = int.Parse(contextKey);//

            // load Manufacturer's
            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.LoadSimilarTop12(prefixText, companyId);

            // process list and return
            if (unitsGateway.Table.Rows.Count == 0)
            {
                return new string[0];
            }
            else
            {
                List<string> items = new List<string>(count);
                for (int i = 0; (i < count) & (i < unitsGateway.Table.Rows.Count); i++)
                {
                    if (!items.Contains(unitsGateway.Table.Rows[i]["Manufacturer"].ToString()))
                    {
                        items.Add(unitsGateway.Table.Rows[i]["Manufacturer"].ToString());
                    }
                }

                return items.ToArray();
            }
        }



    }
}
