using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.BL.CWP.Jliner;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.Jliner
{
    /// <summary>
    /// flat_section_jliner_summary
    /// </summar
    public partial class flat_section_jliner_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected FlatSectionJlinerTDS flatSectionJlinerTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_APP_VIEW"]) && Convert.ToBoolean(Session["sgLFS_APP_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in flat_section_jliner_summary.aspx");
                }

                // Tag page
                hdfCurrentClient.Value = (string)Request.QueryString["client"];

                // Restore datasets
                flatSectionJlinerTDS = (FlatSectionJlinerTDS)Session["flatSectionJlinerTDS"];

                // Prepare initial data
                // ... for the client
                int companyId = Int32.Parse(Session["companyID"].ToString());
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadByCompaniesId(int.Parse(hdfCurrentClient.Value), companyId);

                TextBox tbxCurrentClient = (TextBox)tkrpbLeftMenuCurrentClient.FindItemByValue("mCurrentClient").FindControl("tbxCurrentClient");
                tbxCurrentClient.Text = companiesGateway.GetName(int.Parse(hdfCurrentClient.Value));

                // If coming from 
                // ... jliner_navigator2.aspx
                if (Request.QueryString["source_page"] == "jliner_navigator2.aspx")
                {
                    StoreNavigatorState();
                }

                // ... jliner_delete.aspx or flat_section_jliner_edit.aspx
                if ((Request.QueryString["source_page"] == "jliner_delete.aspx") || (Request.QueryString["source_page"] == "flat_section_jliner_edit.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];
                }

                // Grid filter
                odsFlatSectionJliner.FilterExpression = "(Deleted = 0)";
                if (grdvJliner.Rows.Count == 0)
                {
                    Response.Redirect("./jliner_navigator2.aspx?source_page=flat_section_jliner_summary.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"]);
                }

                if (Session["rowFocus"] != null)
                {
                    this.SetFocusGridView();
                }
            }
            else
            {
                // Restore datasets
                flatSectionJlinerTDS = (FlatSectionJlinerTDS)Session["flatSectionJlinerTDS"];

                // Grid filter
                odsFlatSectionJliner.FilterExpression = "(Deleted = 0)";
                if (grdvJliner.Rows.Count == 0)
                {
                    Response.Redirect("./jliner_navigator2.aspx?source_page=flat_section_jliner_summary.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"]);
                }
            }
        }
        


        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "CWP";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdvJliner_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int rowFocus = e.Row.RowIndex;
                HiddenField hdfID = (HiddenField)e.Row.FindControl("hdfID");
                HiddenField hdfRefID = (HiddenField)e.Row.FindControl("hdfRefID");
                HiddenField hdfCompanyID = (HiddenField)e.Row.FindControl("hdfCompanyID");

                // ... for comments
                Button btnComments = (Button)e.Row.FindControl("btnComments");
                btnComments.OnClientClick = string.Format("return btnCommentsClick('{0}', '{1}', '{2}', '{3}');", hdfID.Value, hdfRefID.Value, hdfCompanyID.Value, rowFocus);

                // ... for history
                Button btnHistory = (Button)e.Row.FindControl("btnHistory");
                btnHistory.OnClientClick = string.Format("return btnHistoryClick('{0}', '{1}', '{2}', '{3}');", hdfID.Value, hdfRefID.Value, hdfCompanyID.Value, rowFocus);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mEdit":
                    if (this.Update() > 0)
                    {
                        Session["rowFocus"] = null;
                        url = "./flat_section_jliner_edit.aspx?source_page=flat_section_jliner_summary.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }
                    break;

                case "mDelete":
                    if (this.Update() > 0)
                    {
                        Session["rowFocus"] = null;
                        url = "./jliner_delete.aspx?source_page=flat_section_jliner_summary.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }
                    break;

                case "mBulkDateUpdate":
                    if (this.Update() > 0)
                    {
                        string script = "<script language='javascript'>";
                        string url2 = "./jliner_bulk_date_update.aspx?source_page=flat_section_jliner_summary&client=" + hdfCurrentClient.Value;
                        script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=550, height=330')", url2);
                        script = script + "</script>";
                        Response.Write(script);
                    }
                    break;

                case "mLastSearch":
                    url = "./jliner_navigator2.aspx?source_page=flat_section_jliner_summary.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mChange":
                    url = "./jliner_main.aspx?source_page=lm&client=" + hdfCurrentClient.Value;
                    break;

                case "mSearch":
                    url = "./jliner_navigator.aspx?source_page=lm&client=" + hdfCurrentClient.Value;
                    break;

                case "mLiningPlan":
                    url = "./linning_plan.aspx?source_page=lm&client=" + hdfCurrentClient.Value;
                    break;
            }

            if (url != "") Response.Redirect(url);
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
            contentVariables += "var hdfCurrentClientId = '" + hdfCurrentClient.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./flat_section_jliner_summary.js");
        }



        protected string GetIssueSelected(object issue)
        {
            if (issue != DBNull.Value)
            {
                if (issue.ToString() == "Dig Required Prior To Lining")
                {
                    return "Dig Req'd Prior To Lining";
                }

                if (issue.ToString() == "Dig Required After Lining")
                {
                    return "Dig Req'd After Lining";
                }
                
                if (issue.ToString() == "Robotic Prep Required")
                {
                    return "Robotic Prep Req'd";
                }

                return issue.ToString();                           
            }
            else
            {
                return "";
            }
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_ddlOperator1=" + Request.QueryString["search_ddlOperator1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlCondition2=" + Request.QueryString["search_ddlCondition2"] + "&search_ddlOperator2=" + Request.QueryString["search_ddlOperator2"] + "&search_tbxCondition2=" + Request.QueryString["search_tbxCondition2"] + "&search_issues=" + Request.QueryString["search_issues"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_sub_area=" + Request.QueryString["search_sub_area"]; 
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private int Update()
        {
            FlatSectionJliner flatSectionJliner = new FlatSectionJliner(flatSectionJlinerTDS);
            int jlinerSelected = 0;

            // Update flatSectionJlinerTDS
            foreach (GridViewRow row in grdvJliner.Rows)
            {
                string id_ = ((TextBox)row.FindControl("tbxId_")).Text;
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                flatSectionJliner.UpdateSelected(id_, selected);

                if (selected) jlinerSelected++;
            }

            // Save jliners selection
            flatSectionJlinerTDS.AcceptChanges();

            // Store datasets
            Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;

            return jlinerSelected;
        }



        private void SetFocusGridView()
        {
            int index = (int)Session["rowFocus"];
            GridViewRow gridRow = grdvJliner.Rows[index];
            gridRow.FindControl("tbxHistory").Focus();
        }



    }
}