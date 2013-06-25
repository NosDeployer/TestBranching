using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.BL.CWP.Section;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.Jliner
{
    /// <summary>
    /// Linning Plan
    /// </summary>
    public partial class linning_plan : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected LinningPlanTDS linningPlanTDS;






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
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in linning_plan.aspx");
                }

                // Tag page
                hdfCurrentClient.Value = (string)Request.QueryString["client"];

                // Prepare initial data

                // ...  for the client
                int companyId = Int32.Parse(Session["companyID"].ToString());
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadByCompaniesId(int.Parse(hdfCurrentClient.Value), companyId);
                TextBox tbxCurrentClient = (TextBox)tkrpbLeftMenuCurrentClient.FindItemByValue("mCurrentClient").FindControl("tbxCurrentClient");
                tbxCurrentClient.Text = companiesGateway.GetName(int.Parse(hdfCurrentClient.Value));

                // ... for the grid
                linningPlanTDS = new LinningPlanTDS();
                LinningPlanGateway linningPlanGateway = new LinningPlanGateway(linningPlanTDS);
                linningPlanGateway.ClearBeforeFill = false;
                
                linningPlanGateway.LoadByCompaniesIdIssueWithLateralsNoOutOfScope(companyId, int.Parse(hdfCurrentClient.Value)); 
                linningPlanGateway.LoadByCompaniesIdOtherIssueWithLaterals(companyId, int.Parse(hdfCurrentClient.Value)); 

                grdLinningPlan.DataSource = linningPlanGateway.Table;
                grdLinningPlan.DataBind();

                // Check results
                if (linningPlanTDS.LinningPlan.Rows.Count > 0)
                {
                    pNoResults.Visible = false;
                }
                else
                {
                    pNoResults.Visible = true;
                }

                // Store dataset
                Session["linningPlanTDS"] = linningPlanTDS;
            }
            else
            {
                // Restore dataset
                linningPlanTDS = (LinningPlanTDS) Session["linningPlanTDS"];

                // ... for the grid
                LinningPlanGateway linningPlanGateway = new LinningPlanGateway(linningPlanTDS);
                linningPlanGateway.ClearBeforeFill = false;
                int companyId = Int32.Parse(Session["companyID"].ToString());
                linningPlanGateway.LoadByCompaniesIdIssueWithLateralsNoOutOfScope(companyId, int.Parse(hdfCurrentClient.Value));
                linningPlanGateway.LoadByCompaniesIdOtherIssueWithLaterals(companyId, int.Parse(hdfCurrentClient.Value)); 

                grdLinningPlan.DataSource = linningPlanGateway.Table;
                grdLinningPlan.DataBind();
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
        
        protected void grdLinningPlan_Sorting(object sender, GridViewSortEventArgs e)
        {
            string direction = (e.SortDirection == SortDirection.Ascending) ? "ASC" : "DESC";

            DataView dataView = new DataView(linningPlanTDS.LinningPlan);
            dataView.Sort = e.SortExpression + " " + direction;
            grdLinningPlan.DataSource = dataView;
            grdLinningPlan.DataBind();
        }



        protected void grdLinningPlan_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Guid id = new Guid(((HiddenField)e.Row.FindControl("hdfId")).Value);
                int companyId = int.Parse(((HiddenField)e.Row.FindControl("hdfCompanyId")).Value);

                DropDownList ddlFlusherMN = (DropDownList)e.Row.FindControl("ddlFlusherMN");
                DropDownList ddlLinerMN = (DropDownList)e.Row.FindControl("ddlLinerMN");
                DropDownList ddlRotatorMN = (DropDownList)e.Row.FindControl("ddlRotatorMN");
                DropDownList ddlCompressorMN = (DropDownList)e.Row.FindControl("ddlCompressorMN");

                SectionMH sectionMH = new SectionMH(new DataSet());
                sectionMH.LoadAndAddItem("", "", id, companyId);

                ddlFlusherMN.DataSource = sectionMH.Table;
                ddlFlusherMN.DataBind();

                ddlLinerMN.DataSource = sectionMH.Table;
                ddlLinerMN.DataBind();

                ddlRotatorMN.DataSource = sectionMH.Table;
                ddlRotatorMN.DataBind();

                ddlCompressorMN.DataSource = sectionMH.Table;
                ddlCompressorMN.DataBind();
            }
        }



        protected void btnOrder_Click(object sender, EventArgs e)
        {
            PostPageChanges();
            if (ddlOrder.SelectedIndex == 0)
            {
                grdLinningPlan.Sort("AllMeasured, NumLats, RecordID", SortDirection.Descending);
            }
            else
            {
                grdLinningPlan.Sort("Selected", SortDirection.Ascending);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

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
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            if (e.Item.Value == "mPreview")
            {
                if (linningPlanTDS.LinningPlan.Rows.Count > 0)
                {
                    Page.Validate();
                    if (Page.IsValid)
                    {
                        PostPageChanges();
                        Response.Write("<script language='javascript'> {window.open('./lining_plan_report.aspx?source_page=linning_plan.aspx&client_id=" + hdfCurrentClient.Value + "', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        protected string GetBooleanValue(object value)
        {
            return ((bool)value) ? "Yes" : "No";
        }

      
        
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./linning_plan.js");
        }



        private void PostPageChanges()
        {
            LiquiForce.LFSLive.BL.CWP.Jliner.LinningPlan linningPlan = new LiquiForce.LFSLive.BL.CWP.Jliner.LinningPlan(linningPlanTDS);

            // Update section-setups
            foreach (GridViewRow row in grdLinningPlan.Rows)
            {
                Guid id = new Guid(((HiddenField)row.FindControl("hdfId")).Value);
                int companyId = int.Parse(((HiddenField)row.FindControl("hdfCompanyId")).Value);
                DateTime? date_ = null; if (((TextBox)row.FindControl("tbxDate_")).Text.Trim() != "") date_ = DateTime.Parse(((TextBox)row.FindControl("tbxDate_")).Text.Trim());
                string flusher = ((DropDownList)row.FindControl("ddlFlusher")).SelectedValue;
                string flusherMN = ((DropDownList)row.FindControl("ddlFlusherMN")).SelectedValue;
                string liner = ((DropDownList)row.FindControl("ddlLiner")).SelectedValue;
                string linerMN = ((DropDownList)row.FindControl("ddlLinerMN")).SelectedItem.Text;
                string rotator = ((DropDownList)row.FindControl("ddlRotator")).SelectedValue;
                string rotatorMN = ((DropDownList)row.FindControl("ddlRotatorMN")).SelectedValue;
                string compressor = ((DropDownList)row.FindControl("ddlCompressor")).SelectedValue;
                string compressorMN = ((DropDownList)row.FindControl("ddlCompressorMN")).SelectedValue;
                string selected = ((DropDownList)row.FindControl("ddlSelected")).SelectedValue;
                string linerMNType = ((DropDownList)row.FindControl("ddlLinerMN")).SelectedValue;

                linningPlan.UpdateForReport(id, companyId, date_, flusher, flusherMN, liner, linerMN, rotator, rotatorMN, compressor, compressorMN, selected, linerMNType);
            }

            // Store datasets
            Session["linningPlanTDS"] = linningPlanTDS;
        }      



    }
}