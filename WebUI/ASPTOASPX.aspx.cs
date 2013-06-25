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
using NerdsOnSite.IAAN.BusinessLogicLayer;

namespace IAAN.SessionSwitch
{
	/// <summary>
	/// Summary description for ASPTOASPX.
	/// </summary>
	public partial class ASPTOASPX : System.Web.UI.Page
	{
		
		

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Guid sessionId = Guid.Empty;
			try
			{
				 sessionId = new Guid((string)Request["sessionID"]);
			}
			catch
			{
				//non guid found in request object for SessionId
				Response.Write("Invalid Session ID, Access Denied.");
				Response.End();
			}
			

			Hashtable sessions = SessionGateway.GetSessionByGuid(sessionId);



			if (sessions.Count > 0)
			{
				IDictionaryEnumerator sessEnumerator = sessions.GetEnumerator();

				while ( sessEnumerator.MoveNext() )
				{
					Session[sessEnumerator.Key.ToString()] = sessEnumerator.Value;
				}

				string userName = (string)Session["userName"];
				if (userName != null)
				{
					System.Web.Security.FormsAuthentication.SetAuthCookie(userName,false);
					//Context.User = new NerdsOnSite.IAAN.Security.CustomPrincipal(Context.User.Identity, Convert.ToInt32(Session["userID"]), "Administrator", (string)Session["userName"]);
				}

				Response.Redirect(Session["DestPage"].ToString(),true);
			}
			else
			{
				//Guid supplied, not found in the session_gateway table
				Response.Write("Invalid Session ID, Access Denied.");
				Response.End();
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
