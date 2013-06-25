using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using LiquiForce.LFSLive.DA.Assets.Assets;

namespace LiquiForce.LFSLive.WebUI.CWP.Assets
{
    /// <summary>
    /// Summary description for wsAssetSewerMH
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService()]
    public class wsAssetSewerMH : System.Web.Services.WebService
    {
        [WebMethod]
        public String[] GetMHList(string prefixText, int count, string contextKey)
        {
            // split country, province, ...
            string[] location = Regex.Split(contextKey, ",");

            Int64 countryId = Int64.Parse(location[0]);
            Int64? provinceId = null; if (location[1] != "0") provinceId = Int64.Parse(location[1]);
            Int64? countyId = null; if (location[2] != "0") countyId = Int64.Parse(location[2]);
            Int64? cityId = null; if (location[3] != "0") cityId = Int64.Parse(location[3]);
            int companyId = int.Parse(location[4]);

            // load MHs
            AssetSewerMHGateway assetSewerMhGateway = new AssetSewerMHGateway();
            assetSewerMhGateway.LoadSimilarTop12ByCountryIdProvinceIdCountyIdCityIdMhId(countryId, provinceId, countyId, cityId, prefixText, companyId);

            // process list and return
            if (assetSewerMhGateway.Table.Rows.Count == 0)
            {
                return new string[0];
            }
            else
            {
                List<string> items = new List<string>(count);
                for (int i = 0; (i < count) & (i < assetSewerMhGateway.Table.Rows.Count); i++)
                {
                    items.Add(assetSewerMhGateway.Table.Rows[i]["MHID"].ToString());
                }

                return items.ToArray();
            }

        }
    }
}
