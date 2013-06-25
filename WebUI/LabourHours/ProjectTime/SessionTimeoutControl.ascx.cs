using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    public partial class SessionTimeoutControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (HttpContext.Current == null)
                writer.Write("[ *** SessionTimeout: " + this.ID + " *** ]");
            base.Render(writer);
        }


        protected override void OnPreRender(EventArgs e)
        {
            if (Context.Session != null)
            {
                if (Context.Session.IsNewSession)
                {
                    string sCookieHeader = Page.Request.Headers["Cookie"];
                    if ((null != sCookieHeader) && (sCookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }
            }
        }

    }
}