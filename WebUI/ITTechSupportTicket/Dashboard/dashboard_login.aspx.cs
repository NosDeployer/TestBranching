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
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.ITTechSupportTicket.Dashboard
{
    /// <summary>
    /// dashboard_login
    /// </summary>
    public partial class dashboard_login : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get user data
            int loginId = Convert.ToInt32(Session["loginID"]);
            int companyId = Int32.Parse(Session["companyID"].ToString());

            LoginGateway loginGateway = new LoginGateway(new DataSet());
            loginGateway.LoadByLoginId(loginId, companyId);

            string userName = loginGateway.GetUserName(loginId, companyId);
            string userMail = loginGateway.GetEmail(loginId, companyId);
            string password = loginGateway.GetPassword(loginId, companyId);

            // Fomat new pass
            string newPassword = password;
            if (password.Length <= 7)
            {
                for (int i = password.Length; i <= 7; i++)
                {
                    newPassword = newPassword + "!";
                }
            }
            else
            {
                newPassword = newPassword + "!";
            }

            // Verify pass, if not a valid user create one
            if (!(Membership.ValidateUser(userName, newPassword)))
            {
                MembershipCreateStatus createStatus;
                Membership.CreateUser(userName, newPassword, userMail, "Password question", "password answer", true, out createStatus);
            }

            FormsAuthentication.RedirectFromLoginPage(userName, false);

            if (Convert.ToBoolean(Session["sgLFS_ITTST_SUPPORTTICKET_ADMIN"]))
            {
                Response.Redirect(".//dashboardManager.aspx?source_page=out");
            }
            else
            {
                Response.Redirect(".//dashboard.aspx?source_page=out");
            }
        }



    }
}