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
using LiquiForce.LFSLive.BL.Resources.Companies;

namespace LiquiForce.LFSLive.WebUI.CWP.Jliner
{
    /// <summary>
    /// Jliner Main
    /// </summary>
    public partial class jliner_main : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_APP_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in jliner_main.aspx");
                }

                // Prepare initial data

                // ...  for the client
                int companyId = Convert.ToInt32(Session["companyID"]);
                CompaniesList companiesList = new CompaniesList();
                companiesList.LoadAndAddItem(-1, "(Select A Client)", companyId);
                ddlClient.DataSource = companiesList.Table;
                ddlClient.DataValueField = "COMPANIES_ID";
                ddlClient.DataTextField = "Name";
                ddlClient.DataBind();

                // If comming from 

                // ...out
                if (Request.QueryString["source_page"] == "out")
                {
                    ddlClient.SelectedValue = "-1";
                }

                // ... left menu
                if (Request.QueryString["source_page"] == "lm")
                {
                    ddlClient.SelectedValue = (string)Request.QueryString["client"];
                }
            }
        }



        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                string url = "./jliner_navigator.aspx?source_page=jliner_main.aspx&client=" + ddlClient.SelectedValue;

                Response.Redirect(url);
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "CWP";
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var ddlClientId = '" + ddlClient.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./jliner_main.js");
        }




    }
}
