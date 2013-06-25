using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.BL.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.BL.CWP.Jliner;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.Jliner
{
    /// <summary>
    /// Flat Section Jliner Edit
    /// </summary>
    public partial class flat_section_jliner_edit : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected FlatSectionJlinerTDS flatSectionJlinerTDS;
        protected SectionTDS sectionTDS;






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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in flat_section_jliner_edit.aspx");
                }

                // Tag page
                hdfCurrentClient.Value = (string)Request.QueryString["client"];

                // If coming from 
                // ... jliner_navigator2.aspx
                if (Request.QueryString["source_page"] == "jliner_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";
                }

                // ... flat_section_jliner_summary.aspx
                if (Request.QueryString["source_page"] == "flat_section_jliner_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];
                }

                // Prepare initial data
                // ...  for the client
                int companyId = Int32.Parse(Session["companyID"].ToString());
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadByCompaniesId(int.Parse(hdfCurrentClient.Value), companyId);

                TextBox tbxCurrentClient = (TextBox)tkrpbLeftMenuCurrentClient.FindItemByValue("mCurrentClient").FindControl("tbxCurrentClient");
                tbxCurrentClient.Text = companiesGateway.GetName(int.Parse(hdfCurrentClient.Value));

                // Restore datasets
                flatSectionJlinerTDS = (FlatSectionJlinerTDS)Session["flatSectionJlinerTDS"];

                DataView dataViewFlatSectionJliner = new DataView(flatSectionJlinerTDS.FlatSectionJliner);
                dataViewFlatSectionJliner.RowFilter = "(Selected = 1) AND (Deleted = 0)";
                grdvJliner.DataSource = dataViewFlatSectionJliner;
                
                //DataBind
                odsCoPitLocation.DataBind();
                grdvJliner.DataBind();

                if (Session["rowFocus"] != null)
                {
                    this.SetFocusGridView();
                }
            }
            else
            {
                // Restore datasets
                flatSectionJlinerTDS = (FlatSectionJlinerTDS)Session["flatSectionJlinerTDS"];

                DataView dataViewFlatSectionJliner = new DataView(flatSectionJlinerTDS.FlatSectionJliner);
                dataViewFlatSectionJliner.RowFilter = "(Selected = 1) AND (Deleted = 0)";
                grdvJliner.DataSource = dataViewFlatSectionJliner;
                
                //DataBind
                odsCoPitLocation.DataBind();
                grdvJliner.DataBind();
            }
        }

        
        
        protected void grdvJliner_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Comments")
            {
                this.Save2();

                int index = Convert.ToInt32(e.CommandArgument);
                Session["rowFocus"] = index;
                GridViewRow gridRow = grdvJliner.Rows[index];

                HiddenField hdfID = (HiddenField)gridRow.FindControl("hdfID");
                HiddenField hdfRefID = (HiddenField)gridRow.FindControl("hdfRefID");
                HiddenField hdfCompanyID = (HiddenField)gridRow.FindControl("hdfCompanyID");

                string script = "<script language='javascript'>";
                string url = "./jliner_comments.aspx?source_page=flat_section_jliner_edit.aspx&rowId=" + hdfID.Value + "&rowRefId=" + hdfRefID.Value + "&rowCompanyId=" + hdfCompanyID.Value + "&client=" + hdfCurrentClient.Value + "&rowFocus=" + index;
                script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=795, height=640')", url);
                script = script + "</script>";
                Response.Write(script);
            }

            if (e.CommandName == "History")
            {
                this.Save2();

                int index = Convert.ToInt32(e.CommandArgument);
                Session["rowFocus"] = index;
                GridViewRow gridRow = grdvJliner.Rows[index];

                HiddenField hdfID = (HiddenField)gridRow.FindControl("hdfID");
                HiddenField hdfRefID = (HiddenField)gridRow.FindControl("hdfRefID");
                HiddenField hdfCompanyID = (HiddenField)gridRow.FindControl("hdfCompanyID");

                string script = "<script language='javascript'>";
                string url = "./jliner_history.aspx?source_page=flat_section_jliner_edit.aspx&rowId=" + hdfID.Value + "&rowRefId=" + hdfRefID.Value + "&rowCompanyId=" + hdfCompanyID.Value + "&client=" + hdfCurrentClient.Value + "&rowFocus=" + index;
                script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=795, height=640')", url);
                script = script + "</script>";
                Response.Write(script);
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

        protected void cvDistance_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistanceFromUsmh = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvDistanceFromUsmh.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                }

                // Control of distance > 0
                if (args.IsValid)
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvDistanceFromUsmh.Text = "Invalid distance. (must be equal or greater than 0)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void grdvJliner_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // ... for comments
                Button btnComments = (Button)e.Row.FindControl("btnComments");
                btnComments.CommandArgument = e.Row.RowIndex.ToString();

                // ... for history
                Button btnHistory = (Button)e.Row.FindControl("btnHistory");
                btnHistory.CommandArgument = e.Row.RowIndex.ToString();
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mSave":
                    this.Save();
                    break;

                case "mCancel":
                    flatSectionJlinerTDS.RejectChanges();

                    string url = "";
                    if (Request.QueryString["source_page"] == "jliner_navigator2.aspx")
                    {
                        url = "./jliner_navigator2.aspx?source_page=flat_section_jliner_edit.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (Request.QueryString["source_page"] == "flat_section_jliner_summary.aspx")
                    {
                        url = "./flat_section_jliner_summary.aspx?source_page=flat_section_jliner_edit.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }
                    Response.Redirect(url);
                    break;
            }
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

        protected string GetCoPitLocationSelected(object name)
        {
            string coPitLocationSelect = " ";
            
            if (name != DBNull.Value)
            {
                coPitLocationSelect = name.ToString();
            }

            return coPitLocationSelect;
        }



        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfCurrentClientId = '" + hdfCurrentClient.ClientID + "';";
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';";  

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./flat_section_jliner_edit.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_ddlOperator1=" + Request.QueryString["search_ddlOperator1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlCondition2=" + Request.QueryString["search_ddlCondition2"] + "&search_ddlOperator2=" + Request.QueryString["search_ddlOperator2"] + "&search_tbxCondition2=" + Request.QueryString["search_tbxCondition2"] + "&search_issues=" + Request.QueryString["search_issues"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_sub_area=" + Request.QueryString["search_sub_area"];              
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void Save()
        {
            Page.Validate();

            if (Page.IsValid)
            {
                FlatSectionJliner flatSectionJliner = new FlatSectionJliner(flatSectionJlinerTDS);

                // Update flatSectionJlinerTDS
                foreach (GridViewRow row in grdvJliner.Rows)
                {
                    // ... Get standard fields
                    Guid id = new Guid(((HiddenField)row.FindControl("hdfId")).Value);
                    int companyId = int.Parse(((HiddenField)row.FindControl("hdfCompanyId")).Value);
                    int refId = int.Parse(((HiddenField)row.FindControl("hdfRefId")).Value);
                    string recordId = ((HiddenField)row.FindControl("hdfRecordId")).Value;
                    string detailId = ((HiddenField)row.FindControl("hdfDetailId")).Value;
                    string id_ = ((TextBox)row.FindControl("tbxId_")).Text.Trim();
                    string clientLateralId = ""; if (((TextBox)row.FindControl("tbxClientLateralId")).Text.Trim() != "") clientLateralId = ((TextBox)row.FindControl("tbxClientLateralId")).Text.Trim();
                    string address = ((TextBox)row.FindControl("tbxAddress")).Text.Trim();
                    DateTime? pipeLocated = null; if (((TextBox)row.FindControl("tbxPipeLocated")).Text.Trim() != "") pipeLocated = DateTime.Parse(((TextBox)row.FindControl("tbxPipeLocated")).Text.Trim());
                    DateTime? servicesLocated = null; if (((TextBox)row.FindControl("tbxServicesLocated")).Text.Trim() != "") servicesLocated = DateTime.Parse(((TextBox)row.FindControl("tbxServicesLocated")).Text.Trim());
                    DateTime? coInstalled = null; if (((TextBox)row.FindControl("tbxCoInstalled")).Text.Trim() != "") coInstalled = DateTime.Parse(((TextBox)row.FindControl("tbxCoInstalled")).Text.Trim());
                    DateTime? backfilledConcrete = null; if (((TextBox)row.FindControl("tbxBackfilledConcrete")).Text.Trim() != "") backfilledConcrete = DateTime.Parse(((TextBox)row.FindControl("tbxBackfilledConcrete")).Text.Trim());
                    DateTime? backfilledSoil = null; if (((TextBox)row.FindControl("tbxBackfilledSoil")).Text.Trim() != "") backfilledSoil = DateTime.Parse(((TextBox)row.FindControl("tbxBackfilledSoil")).Text.Trim());
                    DateTime? grouted = null; if (((TextBox)row.FindControl("tbxGrouted")).Text.Trim() != "") grouted = DateTime.Parse(((TextBox)row.FindControl("tbxGrouted")).Text.Trim());
                    DateTime? cored = null; if (((TextBox)row.FindControl("tbxCored")).Text.Trim() != "") cored = DateTime.Parse(((TextBox)row.FindControl("tbxCored")).Text.Trim());
                    DateTime? prepped = null; if (((TextBox)row.FindControl("tbxPrepped")).Text.Trim() != "") prepped = DateTime.Parse(((TextBox)row.FindControl("tbxPrepped")).Text.Trim());
                    DateTime? measured = null; if (((TextBox)row.FindControl("tbxMeasured")).Text.Trim() != "") measured = DateTime.Parse(((TextBox)row.FindControl("tbxMeasured")).Text.Trim());
                    string linerSize = ""; if (((TextBox)row.FindControl("tbxLinerSize")).Text.Trim() != "") linerSize = ((TextBox)row.FindControl("tbxLinerSize")).Text.Trim();
                    bool liningThruCo = ((CheckBox)row.FindControl("cbxLiningThruCo")).Checked;
                    DateTime? inProcess = null; if (((TextBox)row.FindControl("tbxInProcess")).Text.Trim() != "") inProcess = DateTime.Parse(((TextBox)row.FindControl("tbxInProcess")).Text.Trim());
                    DateTime? inStock = null; if (((TextBox)row.FindControl("tbxInStock")).Text.Trim() != "") inStock = DateTime.Parse(((TextBox)row.FindControl("tbxInStock")).Text.Trim());
                    DateTime? delivered = null; if (((TextBox)row.FindControl("tbxDelivered")).Text.Trim() != "") delivered = DateTime.Parse(((TextBox)row.FindControl("tbxDelivered")).Text.Trim());
                    DateTime? preVideo = null; if (((TextBox)row.FindControl("tbxPreVideo")).Text.Trim() != "") preVideo = DateTime.Parse(((TextBox)row.FindControl("tbxPreVideo")).Text.Trim());
                    DateTime? linerInstalled = null; if (((TextBox)row.FindControl("tbxLinerInstalled")).Text.Trim() != "") linerInstalled = DateTime.Parse(((TextBox)row.FindControl("tbxLinerInstalled")).Text.Trim());
                    DateTime? finalVideo = null; if (((TextBox)row.FindControl("tbxFinalVideo")).Text.Trim() != "") finalVideo = DateTime.Parse(((TextBox)row.FindControl("tbxFinalVideo")).Text.Trim());
                    double? distanceFromUSMH = null; if (((TextBox)row.FindControl("tbxDistanceFromUSMH")).Text.Trim() != "") distanceFromUSMH = double.Parse(((TextBox)row.FindControl("tbxDistanceFromUSMH")).Text.Trim());
                    string comments = ""; if (((TextBox)row.FindControl("tbxComments")).Text.Trim() != "") comments = ((TextBox)row.FindControl("tbxComments")).Text.Trim();
                    string history = ""; if (((TextBox)row.FindControl("tbxHistory")).Text.Trim() != "") history = ((TextBox)row.FindControl("tbxHistory")).Text.Trim();
                    string issue = ((DropDownList)row.FindControl("ddlIssue")).SelectedValue.Trim();
                    decimal? cost = null; if (((TextBox)row.FindControl("tbxCost")).Text.Trim() != "") cost = decimal.Parse(((TextBox)row.FindControl("tbxCost")).Text.Trim());
                    DateTime? videoInspection = null; if (((TextBox)row.FindControl("tbxVideoInspection")).Text.Trim() != "") videoInspection = DateTime.Parse(((TextBox)row.FindControl("tbxVideoInspection")).Text.Trim());
                    string videoLengthToPropertyLine = ""; if (((TextBox)row.FindControl("tbxVideoLengthToPropertyLine")).Text.Trim() != "") videoLengthToPropertyLine = ((TextBox)row.FindControl("tbxVideoLengthToPropertyLine")).Text.Trim();
                    bool coRequired = ((CheckBox)row.FindControl("cbxCoReq")).Checked;
                    bool pitRequired = ((CheckBox)row.FindControl("cbxPitReq")).Checked;
                    string coPitLocation = ""; coPitLocation = ((DropDownList)row.FindControl("ddlCoPitLocation")).SelectedValue;
                    bool postContractDigRequired = ((CheckBox)row.FindControl("cbxPostContractDigRequired")).Checked;
                    DateTime? coCutDown = null; if (((TextBox)row.FindControl("tbxCoCutDown")).Text.Trim() != "") coCutDown = DateTime.Parse(((TextBox)row.FindControl("tbxCoCutDown")).Text.Trim());
                    DateTime? finalRestoration = null; if (((TextBox)row.FindControl("tbxFinalRestoration")).Text.Trim() != "") finalRestoration = DateTime.Parse(((TextBox)row.FindControl("tbxFinalRestoration")).Text.Trim());
                    bool deleted = false;
                    bool selected = true;
                    string hamiltonInspectionNumber = ""; if (((TextBox)row.FindControl("tbxHamiltonInspectionNumber")).Text.Trim() != "") hamiltonInspectionNumber = ((TextBox)row.FindControl("tbxHamiltonInspectionNumber")).Text.Trim();
                    DateTime? noticeDelivered = null; if (((TextBox)row.FindControl("tbxNoticeDelivered")).Text.Trim() != "") noticeDelivered = DateTime.Parse(((TextBox)row.FindControl("tbxNoticeDelivered")).Text.Trim());

                    // ... Calculate fields
                    double? distanceFromDSMH = null;
                    if (distanceFromUSMH.HasValue)
                    {
                        SectionGateway sectionGateway = new SectionGateway();
                        sectionGateway.LoadById(id, companyId);

                        Distance length = new Distance(sectionGateway.GetActualLength(id)) - new Distance(((double)distanceFromUSMH).ToString());
                        distanceFromDSMH = length.ToDoubleInEng3();
                    }

                    // ... Update row
                    flatSectionJliner.Update(id_, id, refId, companyId, recordId, detailId, address, pipeLocated, servicesLocated, coInstalled, backfilledConcrete, backfilledSoil, grouted, cored, prepped, measured, linerSize, inProcess, inStock, delivered, preVideo, linerInstalled, finalVideo, distanceFromUSMH, distanceFromDSMH, comments, history, issue, cost, deleted, selected, videoInspection, coRequired, pitRequired, coPitLocation, postContractDigRequired, coCutDown, finalRestoration, clientLateralId, videoLengthToPropertyLine, liningThruCo, hamiltonInspectionNumber, noticeDelivered);
                }

                // Store datasets
                Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;

                // Update section and jliners
                sectionTDS = new SectionTDS();
                flatSectionJliner.Save(sectionTDS);

                // Update database
                UpdateDatabase();

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "jliner_navigator2.aspx")
                {
                    url = "./jliner_navigator2.aspx?source_page=flat_section_jliner_edit.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState() + "&update=yes";
                }

                if (Request.QueryString["source_page"] == "flat_section_jliner_summary.aspx")
                {
                    url = "./flat_section_jliner_summary.aspx?source_page=flat_section_jliner_edit.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState() + "&update=yes";
                }
                Response.Redirect(url);
            }
        }



        private void Save2()
        {
            Page.Validate();

            if (Page.IsValid)
            {
                FlatSectionJliner flatSectionJliner = new FlatSectionJliner(flatSectionJlinerTDS);

                // Update flatSectionJlinerTDS
                foreach (GridViewRow row in grdvJliner.Rows)
                {
                    // ... Get standard fields
                    Guid id = new Guid(((HiddenField)row.FindControl("hdfId")).Value);
                    int companyId = int.Parse(((HiddenField)row.FindControl("hdfCompanyId")).Value);
                    int refId = int.Parse(((HiddenField)row.FindControl("hdfRefId")).Value);
                    string recordId = ((HiddenField)row.FindControl("hdfRecordId")).Value;
                    string detailId = ((HiddenField)row.FindControl("hdfDetailId")).Value;
                    string id_ = ((TextBox)row.FindControl("tbxId_")).Text.Trim();
                    string address = ((TextBox)row.FindControl("tbxAddress")).Text.Trim();
                    DateTime? pipeLocated = null; if (((TextBox)row.FindControl("tbxPipeLocated")).Text.Trim() != "") pipeLocated = DateTime.Parse(((TextBox)row.FindControl("tbxPipeLocated")).Text.Trim());
                    DateTime? servicesLocated = null; if (((TextBox)row.FindControl("tbxServicesLocated")).Text.Trim() != "") servicesLocated = DateTime.Parse(((TextBox)row.FindControl("tbxServicesLocated")).Text.Trim());
                    DateTime? coInstalled = null; if (((TextBox)row.FindControl("tbxCoInstalled")).Text.Trim() != "") coInstalled = DateTime.Parse(((TextBox)row.FindControl("tbxCoInstalled")).Text.Trim());
                    DateTime? backfilledConcrete = null; if (((TextBox)row.FindControl("tbxBackfilledConcrete")).Text.Trim() != "") backfilledConcrete = DateTime.Parse(((TextBox)row.FindControl("tbxBackfilledConcrete")).Text.Trim());
                    DateTime? backfilledSoil = null; if (((TextBox)row.FindControl("tbxBackfilledSoil")).Text.Trim() != "") backfilledSoil = DateTime.Parse(((TextBox)row.FindControl("tbxBackfilledSoil")).Text.Trim());
                    DateTime? grouted = null; if (((TextBox)row.FindControl("tbxGrouted")).Text.Trim() != "") grouted = DateTime.Parse(((TextBox)row.FindControl("tbxGrouted")).Text.Trim());
                    DateTime? cored = null; if (((TextBox)row.FindControl("tbxCored")).Text.Trim() != "") cored = DateTime.Parse(((TextBox)row.FindControl("tbxCored")).Text.Trim());
                    DateTime? prepped = null; if (((TextBox)row.FindControl("tbxPrepped")).Text.Trim() != "") prepped = DateTime.Parse(((TextBox)row.FindControl("tbxPrepped")).Text.Trim());
                    DateTime? measured = null; if (((TextBox)row.FindControl("tbxMeasured")).Text.Trim() != "") measured = DateTime.Parse(((TextBox)row.FindControl("tbxMeasured")).Text.Trim());
                    string linerSize = ""; if (((TextBox)row.FindControl("tbxLinerSize")).Text.Trim() != "") linerSize = ((TextBox)row.FindControl("tbxLinerSize")).Text.Trim();
                    bool liningThruCo = ((CheckBox)row.FindControl("cbxLiningThruCo")).Checked;
                    DateTime? inProcess = null; if (((TextBox)row.FindControl("tbxInProcess")).Text.Trim() != "") inProcess = DateTime.Parse(((TextBox)row.FindControl("tbxInProcess")).Text.Trim());
                    DateTime? inStock = null; if (((TextBox)row.FindControl("tbxInStock")).Text.Trim() != "") inStock = DateTime.Parse(((TextBox)row.FindControl("tbxInStock")).Text.Trim());
                    DateTime? delivered = null; if (((TextBox)row.FindControl("tbxDelivered")).Text.Trim() != "") delivered = DateTime.Parse(((TextBox)row.FindControl("tbxDelivered")).Text.Trim());
                    DateTime? preVideo = null; if (((TextBox)row.FindControl("tbxPreVideo")).Text.Trim() != "") preVideo = DateTime.Parse(((TextBox)row.FindControl("tbxPreVideo")).Text.Trim());
                    DateTime? linerInstalled = null; if (((TextBox)row.FindControl("tbxLinerInstalled")).Text.Trim() != "") linerInstalled = DateTime.Parse(((TextBox)row.FindControl("tbxLinerInstalled")).Text.Trim());
                    DateTime? finalVideo = null; if (((TextBox)row.FindControl("tbxFinalVideo")).Text.Trim() != "") finalVideo = DateTime.Parse(((TextBox)row.FindControl("tbxFinalVideo")).Text.Trim());
                    double? distanceFromUSMH = null; if (((TextBox)row.FindControl("tbxDistanceFromUSMH")).Text.Trim() != "") distanceFromUSMH = double.Parse(((TextBox)row.FindControl("tbxDistanceFromUSMH")).Text.Trim());
                    string comments = ""; if (((TextBox)row.FindControl("tbxComments")).Text.Trim() != "") comments = ((TextBox)row.FindControl("tbxComments")).Text.Trim();
                    string history = ""; if (((TextBox)row.FindControl("tbxHistory")).Text.Trim() != "") history = ((TextBox)row.FindControl("tbxHistory")).Text.Trim();
                    string issue = ((DropDownList)row.FindControl("ddlIssue")).SelectedValue.Trim();
                    decimal? cost = null; if (((TextBox)row.FindControl("tbxCost")).Text.Trim() != "") cost = decimal.Parse(((TextBox)row.FindControl("tbxCost")).Text.Trim());
                    bool deleted = false;
                    bool selected = true;
                    DateTime? videoInspection = null; if (((TextBox)row.FindControl("tbxVideoInspection")).Text.Trim() != "") videoInspection = DateTime.Parse(((TextBox)row.FindControl("tbxVideoInspection")).Text.Trim());
                    string videoLengthToPropertyLine = ""; if (((TextBox)row.FindControl("tbxVideoLengthToPropertyLine")).Text.Trim() != "") videoLengthToPropertyLine = ((TextBox)row.FindControl("tbxVideoLengthToPropertyLine")).Text.Trim();
                    bool coRequired = ((CheckBox)row.FindControl("cbxCoReq")).Checked;
                    bool pitRequired = ((CheckBox)row.FindControl("cbxPitReq")).Checked;
                    string coPitLocation = ""; coPitLocation = ((DropDownList)row.FindControl("ddlCoPitLocation")).SelectedValue;
                    bool postContractDigRequired = ((CheckBox)row.FindControl("cbxPostContractDigRequired")).Checked;
                    DateTime? coCutDown = null; if (((TextBox)row.FindControl("tbxCoCutDown")).Text.Trim() != "") coCutDown = DateTime.Parse(((TextBox)row.FindControl("tbxCoCutDown")).Text.Trim());
                    DateTime? finalRestoration = null; if (((TextBox)row.FindControl("tbxFinalRestoration")).Text.Trim() != "") finalRestoration = DateTime.Parse(((TextBox)row.FindControl("tbxFinalRestoration")).Text.Trim());
                    string clientLateralId = ""; if (((TextBox)row.FindControl("tbxClientLateralId")).Text.Trim() != "") clientLateralId = ((TextBox)row.FindControl("tbxClientLateralId")).Text.Trim();
                    string hamiltonInspectionNumber = ""; if (((TextBox)row.FindControl("tbxHamiltonInspectionNumber")).Text.Trim() != "") hamiltonInspectionNumber = ((TextBox)row.FindControl("tbxHamiltonInspectionNumber")).Text.Trim();
                    DateTime? noticeDelivered = null; if (((TextBox)row.FindControl("tbxNoticeDelivered")).Text.Trim() != "") noticeDelivered = DateTime.Parse(((TextBox)row.FindControl("tbxNoticeDelivered")).Text.Trim());

                    // ... Calculate fields
                    double? distanceFromDSMH = null;
                    if (distanceFromUSMH.HasValue)
                    {
                        SectionGateway sectionGateway = new SectionGateway();
                        sectionGateway.LoadById(id, companyId);

                        Distance length = new Distance(sectionGateway.GetActualLength(id)) - new Distance(((double)distanceFromUSMH).ToString());
                        distanceFromDSMH = length.ToDoubleInEng3();
                    }

                    // ... Update row
                    flatSectionJliner.Update(id_, id, refId, companyId, recordId, detailId, address, pipeLocated, servicesLocated, coInstalled, backfilledConcrete, backfilledSoil, grouted, cored, prepped, measured, linerSize, inProcess, inStock, delivered, preVideo, linerInstalled, finalVideo, distanceFromUSMH, distanceFromDSMH, comments, history, issue, cost, deleted, selected, videoInspection, coRequired, pitRequired, coPitLocation, postContractDigRequired, coCutDown, finalRestoration, clientLateralId, videoLengthToPropertyLine, liningThruCo, hamiltonInspectionNumber, noticeDelivered);
                }

                // Store datasets
                Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;

                // Update section and jliners
                sectionTDS = new SectionTDS();
                flatSectionJliner.Save(sectionTDS);
            }
        }



        private void SetFocusGridView()
        {
            int index = (int)Session["rowFocus"];
            GridViewRow gridRow = grdvJliner.Rows[index];
            gridRow.FindControl("tbxHistory").Focus();
        }



        public override void Validate()
        {
            // Validate page
            base.Validate();

            if (Page.IsValid)
            {
                // Update flatSectionJlineTDS
                foreach (GridViewRow row in grdvJliner.Rows)
                {
                    // ... Get standard fields
                    Guid id = new Guid(((HiddenField)row.FindControl("hdfId")).Value);
                    int companyId = int.Parse(((HiddenField)row.FindControl("hdfCompanyId")).Value);
                    double? distanceFromUSMH = null; if (((TextBox)row.FindControl("tbxDistanceFromUSMH")).Text.Trim() != "") distanceFromUSMH = double.Parse(((TextBox)row.FindControl("tbxDistanceFromUSMH")).Text.Trim());

                    // ... Calculate fields
                    double? distanceFromDSMH = null;
                    if (distanceFromUSMH.HasValue)
                    {
                        SectionGateway sectionGateway = new SectionGateway();
                        sectionGateway.LoadById(id, companyId);

                        Distance length = new Distance(sectionGateway.GetActualLength(id)) - new Distance(((double)distanceFromUSMH).ToString());
                        distanceFromDSMH = length.ToDoubleInEng3();
                    }

                    // ... Check validation fields
                    if (distanceFromDSMH.HasValue)
                    {
                        if ((double)distanceFromDSMH < 0)
                        {
                            CompareValidator cvDistanceFromDSMH = ((CompareValidator)row.FindControl("cvDistanceFromDSMH"));
                            cvDistanceFromDSMH.IsValid = false;
                        }
                    }
                }
            }
        }



        private void UpdateDatabase()
        {
            try
            {
                SectionGateway sectionGateway = new SectionGateway(sectionTDS);
                sectionGateway.Update();

                sectionTDS.AcceptChanges();
                flatSectionJlinerTDS.AcceptChanges();
                Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;

                // Update IssueWithLaterals field
                Section section = new Section(sectionTDS);
                section.UpdateIssueWithLaterals();
                sectionGateway.Update2();
                sectionTDS.AcceptChanges();
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }


               
    }
}