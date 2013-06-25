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

namespace LiquiForce.LFSLive.WebUI.CWP
{
	public partial class WebForm1 : System.Web.UI.Page
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
			if (!Convert.ToBoolean(Session["sgLFS_APP_VIEW"]))
			{
				Response.Redirect("./../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
			}

			//--- Validate query string
			if ((Request.QueryString["target_report"] == null) || (Request.QueryString["format"] == null))
			{
				Response.Redirect("./../error_page.aspx?error=" + "Invalid query string in viewer2.aspx");
			}

			//--- Preview report
			string fName = (string)Session["fName"];
            System.IO.FileInfo fi = new System.IO.FileInfo(fName);

			Response.ClearContent();
			Response.ClearHeaders();
			switch (Request.QueryString["format"])
			{
				case "pdf":
					Response.AppendHeader("Content-Type", "application/pdf");
                    Response.AppendHeader("Content-Length", fi.Length.ToString());
					break;

				case "excel":
					Response.AppendHeader("Content-Type", "application/vnd.ms-excel");
                    Response.AppendHeader("Content-Length", fi.Length.ToString());
					Response.AppendHeader("Content-Disposition", "filename=" + Request.QueryString["target_report"] + ".xls");
					break;

				case "word":
					break;
			}
			Response.WriteFile(fName);
			Response.Flush();
			Response.Close();

			System.IO.File.Delete(fName);
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
