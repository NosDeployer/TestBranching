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
using LiquiForce.LFSLive.CWP.DatabaseGateway;

namespace LiquiForce.LFSLive.WebUI.CWP
{
	public partial class id_lookup : System.Web.UI.Page
	{
		/// ////////////////////////////////////////////////////////////////////////
		/// EVENTS
		///

		//
		// Page_Load
		//
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//--- Security check
			if (!(Convert.ToBoolean(Session["sgLFS_APP_VIEW"]) && Convert.ToBoolean(Session["sgLFS_APP_ADD"])))
			{
				Response.Redirect("./../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
			}
		}

		//
		// ddlLastID_SelectedIndexChanged
		//
		protected void ddlLastID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LFSMasterAreaGateway lfsMasterAreaGateway = new LFSMasterAreaGateway();

			switch (ddlLastID.SelectedValue)
			{
				case "2006":
					tbxRecordID.Text = lfsMasterAreaGateway.GetLastRecordIdLookupFor05(Convert.ToInt32(Session["companyID"]));
					break;

                case "2007":
                    tbxRecordID.Text = lfsMasterAreaGateway.GetLastRecordIdLookupFor07(Convert.ToInt32(Session["companyID"]));
                    break;
                
                case "BAY CITY":
					tbxRecordID.Text = lfsMasterAreaGateway.GetLastRecordIdLookupForBayCity(Convert.ToInt32(Session["companyID"]));
					break;

				default:
					tbxRecordID.Text = "";
					break;
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
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
