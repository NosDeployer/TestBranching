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
    public partial class mDialog : System.Web.UI.MasterPage
    {
        /// ////////////////////////////////////////////////////////////////////////
        /// PROPERTIES AND FIELDS
        ///    
        public string DialogTitle
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }






        /// ////////////////////////////////////////////////////////////////////////
        /// EVENTS
        ///        
        protected void Page_Load(object sender, EventArgs e)
        {

        }


    }
}