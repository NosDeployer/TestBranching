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
    public partial class mForm3 : System.Web.UI.MasterPage
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
                _activeToolbar = value;                
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
                lblUserEmail.Text = Convert.ToString(Session["justeMail"]);
            }
        }

       

        protected void lkbtnSignOut_Click(object sender, EventArgs e)
        {
            AppSettingsReader appSettingReader = new AppSettingsReader();
            Response.Redirect(appSettingReader.GetValue("LoginPage", typeof(System.String)).ToString());
        }


    }
}