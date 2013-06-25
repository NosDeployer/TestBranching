using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace LiquiForce.LFSLive.WebUI
{
    public partial class mForm8 : System.Web.UI.MasterPage
    {
        /// ////////////////////////////////////////////////////////////////////////
        /// PROPERTIES AND FIELDS
        ///

        private string _activeToolbar;



        public string ActiveToolbar
        {
            get
            {
                return _activeToolbar;
            }
            set
            {
                AppSettingsReader appSettingReader = new AppSettingsReader();
                string themePath = appSettingReader.GetValue("ThemePath", typeof(System.String)).ToString();

                _activeToolbar = value;

                switch (_activeToolbar)
                {
                    case "Projects":
                        mMaster.Items[0].ImageUrl = themePath + "menu_projects_press.png";
                        mMaster.Items[1].ImageUrl = themePath + "menu_esewers_out.png";
                        mMaster.Items[2].ImageUrl = themePath + "menu_labour_out.png";
                        mMaster.Items[3].ImageUrl = themePath + "menu_fm_out.png";
                        mMaster.Items[4].ImageUrl = themePath + "menu_cwp_out.png";
                        mMaster.Items[5].ImageUrl = themePath + "menu_resources_out.png";
                        mMaster.Items[6].ImageUrl = themePath + "menu_it_tech_support_out.png";
                        break;

                    case "eSewers":
                        mMaster.Items[0].ImageUrl = themePath + "menu_projects_out.png";
                        mMaster.Items[1].ImageUrl = themePath + "menu_esewers_press.png";
                        mMaster.Items[2].ImageUrl = themePath + "menu_labour_out.png";
                        mMaster.Items[3].ImageUrl = themePath + "menu_fm_out.png";
                        mMaster.Items[4].ImageUrl = themePath + "menu_cwp_out.png";
                        mMaster.Items[5].ImageUrl = themePath + "menu_resources_out.png";
                        mMaster.Items[6].ImageUrl = themePath + "menu_it_tech_support_out.png";
                        break;

                    case "LabourHours":
                        mMaster.Items[0].ImageUrl = themePath + "menu_projects_out.png";
                        mMaster.Items[1].ImageUrl = themePath + "menu_esewers_out.png";
                        mMaster.Items[2].ImageUrl = themePath + "menu_labour_press.png";
                        mMaster.Items[3].ImageUrl = themePath + "menu_fm_out.png";
                        mMaster.Items[4].ImageUrl = themePath + "menu_cwp_out.png";
                        mMaster.Items[5].ImageUrl = themePath + "menu_resources_out.png";
                        mMaster.Items[6].ImageUrl = themePath + "menu_it_tech_support_out.png";
                        break;

                    case "CWP":
                        mMaster.Items[0].ImageUrl = themePath + "menu_projects_out.png";
                        mMaster.Items[1].ImageUrl = themePath + "menu_esewers_out.png";
                        mMaster.Items[2].ImageUrl = themePath + "menu_labour_out.png";
                        mMaster.Items[3].ImageUrl = themePath + "menu_fm_out.png";
                        mMaster.Items[4].ImageUrl = themePath + "menu_cwp_press.png";
                        mMaster.Items[5].ImageUrl = themePath + "menu_resources_out.png";
                        mMaster.Items[6].ImageUrl = themePath + "menu_it_tech_support_out.png";
                        break;

                    case "FleetManagement":
                        mMaster.Items[0].ImageUrl = themePath + "menu_projects_out.png";
                        mMaster.Items[1].ImageUrl = themePath + "menu_esewers_out.png";
                        mMaster.Items[2].ImageUrl = themePath + "menu_labour_out.png";
                        mMaster.Items[3].ImageUrl = themePath + "menu_fm_press.png";
                        mMaster.Items[4].ImageUrl = themePath + "menu_cwp_out.png";
                        mMaster.Items[5].ImageUrl = themePath + "menu_resources_out.png";
                        mMaster.Items[6].ImageUrl = themePath + "menu_it_tech_support_out.png";
                        break;

                    case "Resources":
                        mMaster.Items[0].ImageUrl = themePath + "menu_projects_out.png";
                        mMaster.Items[1].ImageUrl = themePath + "menu_esewers_out.png";
                        mMaster.Items[2].ImageUrl = themePath + "menu_labour_out.png";
                        mMaster.Items[3].ImageUrl = themePath + "menu_fm_out.png";
                        mMaster.Items[4].ImageUrl = themePath + "menu_cwp_out.png";
                        mMaster.Items[5].ImageUrl = themePath + "menu_resources_press.png";
                        mMaster.Items[6].ImageUrl = themePath + "menu_it_tech_support_out.png";
                        break;

                    case "ITTechSupportTicket":
                        mMaster.Items[0].ImageUrl = themePath + "menu_projects_out.png";
                        mMaster.Items[1].ImageUrl = themePath + "menu_esewers_out.png";
                        mMaster.Items[2].ImageUrl = themePath + "menu_labour_out.png";
                        mMaster.Items[3].ImageUrl = themePath + "menu_fm_out.png";
                        mMaster.Items[4].ImageUrl = themePath + "menu_cwp_out.png";
                        mMaster.Items[5].ImageUrl = themePath + "menu_resources_out.png";
                        mMaster.Items[6].ImageUrl = themePath + "menu_it_tech_support_press.png";
                        break;

                    case "None":
                        mMaster.Items[0].ImageUrl = themePath + "menu_projects_out.png";
                        mMaster.Items[1].ImageUrl = themePath + "menu_esewers_out.png";
                        mMaster.Items[2].ImageUrl = themePath + "menu_labour_out.png";
                        mMaster.Items[3].ImageUrl = themePath + "menu_fm_out.png";
                        mMaster.Items[4].ImageUrl = themePath + "menu_cwp_out.png";
                        mMaster.Items[5].ImageUrl = themePath + "menu_resources_out.png";
                        mMaster.Items[6].ImageUrl = themePath + "menu_it_tech_support_out.png";
                        break;
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ActiveToolbar = "None";
                lblUser.Text = Convert.ToString(Session["justeMail"]);
            }
        }



        protected void ibtnSignOut_Click(object sender, ImageClickEventArgs e)
        {
            AppSettingsReader appSettingReader = new AppSettingsReader();
            Response.Redirect(appSettingReader.GetValue("LoginPage", typeof(System.String)).ToString());
        }

    }
}