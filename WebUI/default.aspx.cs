using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Configuration;

namespace LiquiForce.LFSLive.WebUI
{
	public partial class _default : System.Web.UI.Page
	{
		/// ////////////////////////////////////////////////////////////////////////
		/// EVENTS
		///

		//
		// Page_Load
		//
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//--- MOVED FROM GLOBAL.ASAX BECAUSE NO GLOBAL.ASAX WILL BE AVAILABLE

			//--- Set login page
			AppSettingsReader appSettingReader = new AppSettingsReader();
			Session["loginPage"] = appSettingReader.GetValue("LoginPage", typeof(System.String)).ToString();

			//--- Validate session variables from www.iamatrenchlessexpert.com

            //--- ... userName
            if (Session["userName"] == null)
            {
                Response.Redirect("./error_page.aspx?error=" + "'Session[\"userName\"]' variable undefined.");
            }

			//--- ... companyId
			if (Session["companyID"] == null)
			{
				Response.Redirect("./error_page.aspx?error=" + "'Session[\"companyID\"]' variable undefined.");
			}

			//--- ... loginID
			if (Session["loginID"] == null)
			{
				Response.Redirect("./error_page.aspx?error=" + "'Session[\"loginID\"]' variable undefined.");
			}

            //--- ... justMail
            if (Session["justeMail"] == null)
            {
                Response.Redirect("./error_page.aspx?error=" + "'Session[\"justeMail\"]' variable undefined.");
            }

			//--- ... security session variables
			if (Session["sgLFS_APP_VIEW"] == null)
			{
				Response.Redirect("./error_page.aspx?error=" + "'Session[\"sgLFS_APP_VIEW\"]' variable undefined.");
			}

			if (Session["sgLFS_APP_ADD"] == null)
			{
				Response.Redirect("./error_page.aspx?error=" + "'Session[\"sgLFS_APP_ADD\"]' variable undefined.");
			}

			if (Session["sgLFS_APP_EDIT"] == null)
			{
				Response.Redirect("./error_page.aspx?error=" + "'Session[\"sgLFS_APP_EDIT\"]' variable undefined.");
			}

			if (Session["sgLFS_APP_DELETE"] == null)
			{
				Response.Redirect("./error_page.aspx?error=" + "'Session[\"sgLFS_APP_DELETE\"]' variable undefined.");
			}

			if (Session["sgLFS_APP_ADMIN"] == null)
			{
				Response.Redirect("./error_page.aspx?error=" + "'Session[\"sgLFS_APP_ADMIN\"]' variable undefined.");
			}

            if (Session["sgLFS_PROJECTS_VIEW"] == null)
            {
                Response.Redirect("./error_page.aspx?error=" + "'Session[\"sgLFS_PROJECTS_VIEW\"]' variable undefined.");
            }

            if (Session["sgLFS_PROJECTS_ADD"] == null)
            {
                Response.Redirect("./error_page.aspx?error=" + "'Session[\"sgLFS_PROJECTS_ADD\"]' variable undefined.");
            }

            if (Session["sgLFS_PROJECTS_EDIT"] == null)
            {
                Response.Redirect("./error_page.aspx?error=" + "'Session[\"sgLFS_PROJECTS_EDIT\"]' variable undefined.");
            }
            
            if (Session["sgLFS_PROJECTS_DELETE"] == null)
            {
                Response.Redirect("./error_page.aspx?error=" + "'Session[\"sgLFS_PROJECTS_DELETE\"]' variable undefined.");
            }
            
            //--- security check
			if (!Convert.ToBoolean(Session["sgLFS_APP_VIEW"]))
			{
				Response.Redirect("./error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
			}
		}

		//
		// Page_PreRender
		//
		protected void Page_PreRender(object sender, EventArgs e)
		{
			
		}



		/// ////////////////////////////////////////////////////////////////////////
		/// AUXILIAR EVENTS
		///

		//
		// lkbtnSignOut_Click
		//
		protected void lkbtnSignOut_Click(object sender, System.EventArgs e)
		{
			//--- Sing out
			Response.Redirect(Convert.ToString(Session["loginPage"]));
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);

			//--- Wire events
			this.PreRender += new EventHandler(Page_PreRender);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion


	}
}
