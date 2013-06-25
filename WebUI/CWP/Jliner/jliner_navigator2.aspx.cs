using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.BL.CWP.Jliner;
using LiquiForce.LFSLive.BL.CWP.Section;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.Jliner
{
    /// <summary>
    /// jliner_navigator2 
    /// </summar
    public partial class jliner_navigator2 : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected JlinerNavigatorTDS jlinerNavigatorTDS;






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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in jliner_navigator2.aspx");
                }

                // Tag page
                hdfCurrentClient.Value = (string)Request.QueryString["client"];

                // ... for the ddl Sub areas
                SectionSubArea sectionSubArea = new SectionSubArea();
                sectionSubArea.LoadAndAddItem(int.Parse(hdfCurrentClient.Value), "(All)");
                ddlSubArea.DataSource = sectionSubArea.Table;
                ddlSubArea.DataValueField = "SubArea";
                ddlSubArea.DataTextField = "SubArea";
                ddlSubArea.DataBind();

                // If coming from 
                // ... jliner_navigator.aspx or jliner_navigator2.aspx
                if ((Request.QueryString["source_page"] == "jliner_navigator.aspx") || (Request.QueryString["source_page"] == "jliner_navigator2.aspx"))
                {
                    RestoreNavigatorState();

                    jlinerNavigatorTDS = (JlinerNavigatorTDS)Session["jlinerNavigatorTDS"];
                }

                // ... flat_section_jliner_edit.aspx or flat_section_jliner_summary.aspx  or jliner_delete.aspx
                if ((Request.QueryString["source_page"] == "flat_section_jliner_edit.aspx") || (Request.QueryString["source_page"] == "flat_section_jliner_summary.aspx") || (Request.QueryString["source_page"] == "jliner_delete.aspx"))
                {
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        jlinerNavigatorTDS = (JlinerNavigatorTDS)Session["jlinerNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("jlinerNavigatorTDS");

                        // ... Search data with updates
                        jlinerNavigatorTDS = SubmitSearch();

                        // ... store datasets
                        Session["jlinerNavigatorTDS"] = jlinerNavigatorTDS;
                    }
                }

                // ... jliner_delete.aspx
                if (Request.QueryString["source_page"] == "jliner_delete.aspx")
                {
                    if (jlinerNavigatorTDS.JlinerNavigator.Rows.Count == 0)
                    {
                        string url = "./jliner_navigator.aspx?source_page=jliner_navigator2.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState() + "&no_results=no";
                        Response.Redirect(url);
                    }
                }

                // Prepare initial data
                // ...  for the client
                int companyId = Int32.Parse(Session["companyID"].ToString());
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadByCompaniesId(int.Parse(hdfCurrentClient.Value), companyId);

                TextBox tbxCurrentClient = (TextBox)tkrpbLeftMenuCurrentClient.FindItemByValue("mCurrentClient").FindControl("tbxCurrentClient");
                tbxCurrentClient.Text = companiesGateway.GetName(int.Parse(hdfCurrentClient.Value));
                hdfClientName.Value = tbxCurrentClient.Text;

                // ... for the grid
                grdJlinerNavigator.DataSource = jlinerNavigatorTDS.JlinerNavigator;
                grdJlinerNavigator.DataBind();

                // ... for the total rows
                if (jlinerNavigatorTDS.JlinerNavigator.Rows.Count > 0)
                {
                    grdJlinerNavigator.Caption = String.Format("<table border='0' width='100%' cellpadding='0' cellspacing='0' style='font-weight: bold; font-size: 11px; color: #2F82C7; font-family: 'Microsoft Sans Serif';'><tr><td>Total Rows: {0}</td></tr></table>", jlinerNavigatorTDS.JlinerNavigator.Rows.Count);
                    grdJlinerNavigator.ShowHeader = true;
                }
                else
                {
                    grdJlinerNavigator.ShowHeader = false;
                }
            }
            else
            {
                // Restore TDS
                jlinerNavigatorTDS = (JlinerNavigatorTDS)Session["jlinerNavigatorTDS"];

                // ... for the total rows
                if (jlinerNavigatorTDS.JlinerNavigator.Rows.Count > 0)
                {
                    grdJlinerNavigator.Caption = String.Format("<table border='0' width='100%' cellpadding='0' cellspacing='0' style='font-weight: bold; font-size: 11px; color: #2F82C7; font-family: 'Microsoft Sans Serif';'><tr><td>Total Rows: {0}</td></tr></table>", jlinerNavigatorTDS.JlinerNavigator.Rows.Count);
                    grdJlinerNavigator.ShowHeader = true;
                }
                else
                {
                    grdJlinerNavigator.ShowHeader = false;
                }
            }
        }



        protected void btnbSearch_Click(object sender, EventArgs e)
        {
            
            if (Page.IsValid)
            {
                string url = "";

                // Delete store data
                Session.Contents.Remove("jlinerNavigatorTDS");

                // Get data from DA gateway
                jlinerNavigatorTDS = SubmitSearch();

                // Show results
                if (jlinerNavigatorTDS.JlinerNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["jlinerNavigatorTDS"] = jlinerNavigatorTDS;

                    // ... Go to the results page
                    url = "./jliner_navigator2.aspx?source_page=jliner_navigator2.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./jliner_navigator.aspx?source_page=jliner_navigator2.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState() + "&no_results=yes";
                }

                Response.Redirect(url);
            }
        }        



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm7 master = (mForm7)this.Master;
            master.ActiveToolbar = "CWP";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            ArrayList jlinerIdArrayList = GetJlinerIdArrayList();
            if (jlinerIdArrayList.Count > 0)
            {
                FlatSectionJliner flatSectionJliner = new FlatSectionJliner();
                flatSectionJliner.LoadBySaleDetailIdArrayList(jlinerIdArrayList, 1);
                flatSectionJliner.UpdateCommentsHistoryForProcess();

                if (flatSectionJliner.Table.Rows.Count > 0)
                {
                    // Delete store dataset
                    Session.Remove("flatSectionJlinerTDS");

                    // Store datasets
                    Session["jlinerNavigatorTDS"] = jlinerNavigatorTDS;
                    Session["flatSectionJlinerTDS"] = flatSectionJliner.Data;
                    Session["rowFocus"] = null;

                    // Redirect
                    string url = "./flat_section_jliner_summary.aspx?source_page=jliner_navigator2.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState();
                    Response.Redirect(url);
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }



        protected void btnEdit_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            ArrayList jlinerIdArrayList = GetJlinerIdArrayList();
            if (jlinerIdArrayList.Count > 0)
            {
                FlatSectionJliner flatSectionJliner = new FlatSectionJliner();
                flatSectionJliner.LoadBySaleDetailIdArrayList(jlinerIdArrayList, 1);
                flatSectionJliner.UpdateCommentsHistoryForProcess();

                if (flatSectionJliner.Table.Rows.Count > 0)
                {
                    // Delete store dataset
                    Session.Remove("flatSectionJlinerTDS");

                    // Store datasets
                    Session["jlinerNavigatorTDS"] = jlinerNavigatorTDS;
                    Session["flatSectionJlinerTDS"] = flatSectionJliner.Data;
                    Session["rowFocus"] = null;

                    // Redirect
                    string url = "./flat_section_jliner_edit.aspx?source_page=jliner_navigator2.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState();
                    Response.Redirect(url);
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            ArrayList jlinerIdArrayList = GetJlinerIdArrayList();
            if (jlinerIdArrayList.Count > 0)
            {
                FlatSectionJliner flatSectionJliner = new FlatSectionJliner();
                flatSectionJliner.LoadBySaleDetailIdArrayList(jlinerIdArrayList, 1);

                if (flatSectionJliner.Table.Rows.Count > 0)
                {
                    // Delete store dataset
                    Session.Remove("flatSectionJlinerTDS");

                    // Store datasets
                    Session["jlinerNavigatorTDS"] = jlinerNavigatorTDS;
                    Session["flatSectionJlinerTDS"] = flatSectionJliner.Data;

                    // Redirect
                    string url = "./jliner_delete.aspx?source_page=jliner_navigator2.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState();
                    Response.Redirect(url);
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }



        protected void cvForDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //  Date fields validate
            if ((ddlCondition1.SelectedValue == "JL.VideoInspection") || (ddlCondition1.SelectedValue == "JL.PipeLocated") || (ddlCondition1.SelectedValue == "JL.ServicesLocated") || (ddlCondition1.SelectedValue == "JL.CoInstalled") || (ddlCondition1.SelectedValue == "JL.BackfilledConcrete") || (ddlCondition1.SelectedValue == "JL.BackfilledSoil") || (ddlCondition1.SelectedValue == "JL.Grouted") || (ddlCondition1.SelectedValue == "JL.Cored") || (ddlCondition1.SelectedValue == "JL.Prepped") || (ddlCondition1.SelectedValue == "JL.Measured") || (ddlCondition1.SelectedValue == "JL.InProcess") || (ddlCondition1.SelectedValue == "JL.InStock") || (ddlCondition1.SelectedValue == "JL.Delivered") || (ddlCondition1.SelectedValue == "JL.PreVideo") || (ddlCondition1.SelectedValue == "JL.LinerInstalled") || (ddlCondition1.SelectedValue == "JL.FinalVideo") || (ddlCondition1.SelectedValue == "JL.CoCutDown") || (ddlCondition1.SelectedValue == "JL.FinalRestoration") || (ddlCondition1.SelectedValue == "JL.NoticeDelivered"))
            {
                // for complete date and only year
                if (((Validator.IsValidDate(args.Value.Trim()) && (args.Value.Trim().Length > 7))) || ((Validator.IsValidInt32(args.Value.Trim())) && (args.Value.Trim().Length == 4)) || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvForDateRange_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //  Date fields validate
            if ((ddlCondition1.SelectedValue == "JL.VideoInspection") || (ddlCondition1.SelectedValue == "JL.PipeLocated") || (ddlCondition1.SelectedValue == "JL.ServicesLocated") || (ddlCondition1.SelectedValue == "JL.CoInstalled") || (ddlCondition1.SelectedValue == "JL.BackfilledConcrete") || (ddlCondition1.SelectedValue == "JL.BackfilledSoil") || (ddlCondition1.SelectedValue == "JL.Grouted") || (ddlCondition1.SelectedValue == "JL.Cored") || (ddlCondition1.SelectedValue == "JL.Prepped") || (ddlCondition1.SelectedValue == "JL.Measured") || (ddlCondition1.SelectedValue == "JL.InProcess") || (ddlCondition1.SelectedValue == "JL.InStock") || (ddlCondition1.SelectedValue == "JL.Delivered") || (ddlCondition1.SelectedValue == "JL.PreVideo") || (ddlCondition1.SelectedValue == "JL.LinerInstalled") || (ddlCondition1.SelectedValue == "JL.FinalVideo") || (ddlCondition1.SelectedValue == "JL.CoCutDown") || (ddlCondition1.SelectedValue == "JL.FinalRestoration") || (ddlCondition1.SelectedValue == "JL.NoticeDelivered"))
            {
                // For dates before 1900
                if (cvForDate.IsValid)
                {
                    string[] date = (args.Value.Trim()).Split('/');
                    if (((Validator.IsValidDate(args.Value.Trim())) && (Int32.Parse(date[2]) >= 1900)) || ((args.Value.Trim().Length == 4) && (Validator.IsValidInt32(args.Value.Trim())) && (Int32.Parse(args.Value.Trim()) >= 1900)) || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvForBoolean_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Booleans fields validate
            if ((ddlCondition1.SelectedValue == "JL.CoRequired") || (ddlCondition1.SelectedValue == "JL.PitRequired") || (ddlCondition1.SelectedValue == "JL.PostContractDigRequired") || (ddlCondition1.SelectedValue == "JL.LiningThruCo"))
            {
                if ((args.Value.Trim().ToUpper() == "Y") || (args.Value.Trim().ToUpper() == "YES") || (args.Value.Trim().ToUpper() == "N") || (args.Value.Trim().ToUpper() == "NO") || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvForNumberCondition_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Integer number fields validate
            if ((ddlCondition1.SelectedValue != "") && (ddlOperator1.SelectedValue != ""))
            {
                if (ddlCondition1.SelectedValue == "JL.BuildRebuild")
                {
                    if ((tbxCondition1.Text != "") && (tbxCondition1.Text != "%"))
                    {
                        if (Validator.IsValidInt32(args.Value.Trim()))
                        {
                            args.IsValid = true;
                        }
                        else
                        {
                            args.IsValid = false;
                        }
                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }
            }
        }



        protected void cvInvalidOperatorForBoolean1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Booleans fields validate
            if ((ddlCondition1.SelectedValue == "JL.CoRequired") || (ddlCondition1.SelectedValue == "JL.PitRequired") || (ddlCondition1.SelectedValue == "JL.PostContractDigRequired") || (ddlCondition1.SelectedValue == "JL.LiningThruCo"))
            {
                // ... The not operator can't be use with %
                if ((ddlOperator1.SelectedValue == "<>") && (tbxCondition1.Text.Trim() == "%"))
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvInvalidOperator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //  Operator for Text and boolean fields
            if ((ddlCondition1.SelectedValue == "MA.RecordID + '-' + JL.DetailID") || (ddlCondition1.SelectedValue == "JL.ClientLateralID") || (ddlCondition1.SelectedValue == "JL.Address") || (ddlCondition1.SelectedValue == "MA.Street") || (ddlCondition1.SelectedValue == "JL.History") || (ddlCondition1.SelectedValue == "JL.Comments") || (ddlCondition1.SelectedValue == "MA.USMH") || (ddlCondition1.SelectedValue == "MA.DSMH") || (ddlCondition1.SelectedValue == "JL.CoPitLocation") || (ddlCondition1.SelectedValue == "JL.CoRequired") || (ddlCondition1.SelectedValue == "JL.PitRequired") || (ddlCondition1.SelectedValue == "JL.PostContractDigRequired") || (ddlCondition1.SelectedValue == "JL.LiningThruCo") || (ddlCondition1.SelectedValue == "JL.HamiltonInspectionNumber"))
            {
                //  ... Bolean fields only use equals to and not operators
                if ((ddlOperator1.SelectedValue == "=") || (ddlOperator1.SelectedValue == "<>"))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }

            // For Date fields
            if ((ddlCondition1.SelectedValue == "JL.VideoInspection") || (ddlCondition1.SelectedValue == "JL.PipeLocated") || (ddlCondition1.SelectedValue == "JL.ServicesLocated") || (ddlCondition1.SelectedValue == "JL.CoInstalled") || (ddlCondition1.SelectedValue == "JL.BackfilledConcrete") || (ddlCondition1.SelectedValue == "JL.BackfilledSoil") || (ddlCondition1.SelectedValue == "JL.Grouted") || (ddlCondition1.SelectedValue == "JL.Cored") || (ddlCondition1.SelectedValue == "JL.Prepped") || (ddlCondition1.SelectedValue == "JL.Measured") || (ddlCondition1.SelectedValue == "JL.InProcess") || (ddlCondition1.SelectedValue == "JL.InStock") || (ddlCondition1.SelectedValue == "JL.Delivered") || (ddlCondition1.SelectedValue == "JL.PreVideo") || (ddlCondition1.SelectedValue == "JL.LinerInstalled") || (ddlCondition1.SelectedValue == "JL.FinalVideo") || (ddlCondition1.SelectedValue == "JL.CoCutDown") || (ddlCondition1.SelectedValue == "JL.FinalRestoration") || (ddlCondition1.SelectedValue == "JL.NoticeDelivered"))
            {
                if ((tbxCondition1.Text.Trim() == "%") && (ddlOperator1.SelectedValue != "=") && (ddlOperator1.SelectedValue != "<>"))
                {
                    args.IsValid = false;
                }
                else
                {
                    if ((tbxCondition1.Text.Trim() == "") && (ddlOperator1.SelectedValue != "=") && (ddlOperator1.SelectedValue != "<>"))
                    {
                        args.IsValid = false;
                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }
            }

            // For Integer fields
            if (ddlCondition1.SelectedValue == "JL.BuildRebuild")
            {
                if ((tbxCondition1.Text.Trim() == "%") && (ddlOperator1.SelectedValue != "=") && (ddlOperator1.SelectedValue != "<>"))
                {
                    args.IsValid = false;
                }
                else
                {
                    if ((tbxCondition1.Text.Trim() == "") && (ddlOperator1.SelectedValue != "=") && (ddlOperator1.SelectedValue != "<>"))
                    {
                        args.IsValid = false;
                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }
            }
        }



        protected void cvForDateCondition2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //  Date fields validate
            if ((ddlCondition2.SelectedValue != "") && (ddlOperator2.SelectedValue != ""))
            {
                if ((ddlCondition2.SelectedValue == "JL.VideoInspection") || (ddlCondition2.SelectedValue == "JL.PipeLocated") || (ddlCondition2.SelectedValue == "JL.ServicesLocated") || (ddlCondition2.SelectedValue == "JL.CoInstalled") || (ddlCondition2.SelectedValue == "JL.BackfilledConcrete") || (ddlCondition2.SelectedValue == "JL.BackfilledSoil") || (ddlCondition2.SelectedValue == "JL.Grouted") || (ddlCondition2.SelectedValue == "JL.Cored") || (ddlCondition2.SelectedValue == "JL.Prepped") || (ddlCondition2.SelectedValue == "JL.Measured") || (ddlCondition2.SelectedValue == "JL.InProcess") || (ddlCondition2.SelectedValue == "JL.InStock") || (ddlCondition2.SelectedValue == "JL.Delivered") || (ddlCondition2.SelectedValue == "JL.PreVideo") || (ddlCondition2.SelectedValue == "JL.LinerInstalled") || (ddlCondition2.SelectedValue == "JL.FinalVideo") || (ddlCondition2.SelectedValue == "JL.CoCutDown") || (ddlCondition2.SelectedValue == "JL.FinalRestoration") || (ddlCondition2.SelectedValue == "JL.NoticeDelivered"))
                {
                    // for complete date and only year
                    if (((Validator.IsValidDate(args.Value.Trim()) && (args.Value.Trim().Length > 7))) || ((Validator.IsValidInt32(args.Value.Trim())) && (args.Value.Trim().Length == 4)) || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
            }

        }



        protected void cvForDateRangeCondition2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //  Date fields validate
            if ((ddlCondition2.SelectedValue != "") && (ddlOperator2.SelectedValue != ""))
            {
                if ((ddlCondition2.SelectedValue == "JL.VideoInspection") || (ddlCondition2.SelectedValue == "JL.PipeLocated") || (ddlCondition2.SelectedValue == "JL.ServicesLocated") || (ddlCondition2.SelectedValue == "JL.CoInstalled") || (ddlCondition2.SelectedValue == "JL.BackfilledConcrete") || (ddlCondition2.SelectedValue == "JL.BackfilledSoil") || (ddlCondition2.SelectedValue == "JL.Grouted") || (ddlCondition2.SelectedValue == "JL.Cored") || (ddlCondition2.SelectedValue == "JL.Prepped") || (ddlCondition2.SelectedValue == "JL.Measured") || (ddlCondition2.SelectedValue == "JL.InProcess") || (ddlCondition2.SelectedValue == "JL.InStock") || (ddlCondition2.SelectedValue == "JL.Delivered") || (ddlCondition2.SelectedValue == "JL.PreVideo") || (ddlCondition2.SelectedValue == "JL.LinerInstalled") || (ddlCondition2.SelectedValue == "JL.FinalVideo") || (ddlCondition2.SelectedValue == "JL.CoCutDown") || (ddlCondition2.SelectedValue == "JL.FinalRestoration") || (ddlCondition2.SelectedValue == "JL.NoticeDelivered"))
                {
                    // For dates before 1900
                    if (cvForDateCondition2.IsValid)
                    {
                        string[] date = (args.Value.Trim()).Split('/');
                        if (((Validator.IsValidDate(args.Value.Trim())) && (Int32.Parse(date[2]) >= 1900)) || ((args.Value.Trim().Length == 4) && (Validator.IsValidInt32(args.Value.Trim())) && (Int32.Parse(args.Value.Trim()) >= 1900)) || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                        {
                            args.IsValid = true;
                        }
                        else
                        {
                            args.IsValid = false;
                        }
                    }
                }
            }
        }



        protected void cvForBooleanCondition2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Booleans fields validate
            if ((ddlCondition2.SelectedValue != "") && (ddlOperator2.SelectedValue != ""))
            {
                if ((ddlCondition2.SelectedValue == "JL.CoRequired") || (ddlCondition2.SelectedValue == "JL.PitRequired") || (ddlCondition2.SelectedValue == "JL.PostContractDigRequired") || (ddlCondition2.SelectedValue == "JL.LiningThruCo"))
                {
                    if ((args.Value.Trim().ToUpper() == "Y") || (args.Value.Trim().ToUpper() == "YES") || (args.Value.Trim().ToUpper() == "N") || (args.Value.Trim().ToUpper() == "NO") || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvForNumberCondition2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //  Integer number fields validate
            if ((ddlCondition2.SelectedValue != "") && (ddlOperator2.SelectedValue != ""))
            {
                if (ddlCondition2.SelectedValue == "JL.BuildRebuild")
                {
                    if ((tbxCondition2.Text != "") && (tbxCondition2.Text != "%"))
                    {
                        if (Validator.IsValidInt32(args.Value.Trim()))
                        {
                            args.IsValid = true;
                        }
                        else
                        {
                            args.IsValid = false;
                        }
                    }
                    else
                    {
                        args.IsValid = true;
                    }                   
                }
            }
        }



        protected void cvInvalidOperatorForBoolean2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Booleans fields validate
            if ((ddlCondition2.SelectedValue == "JL.CoRequired") || (ddlCondition2.SelectedValue == "JL.PitRequired") || (ddlCondition2.SelectedValue == "JL.PostContractDigRequired") || (ddlCondition2.SelectedValue == "JL.LiningThruCo"))
            {
                // ... The not operator can't be use with %
                if ((ddlOperator2.SelectedValue == "<>") && (tbxCondition2.Text.Trim() == "%"))
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvInvalidOperator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((ddlCondition2.SelectedValue != "") && (ddlOperator2.SelectedValue != ""))
            {
                //  Operator for Text and boolean fields
                if ((ddlCondition2.SelectedValue == "MA.RecordID + '-' + JL.DetailID") || (ddlCondition2.SelectedValue == "JL.ClientLateralID") || (ddlCondition2.SelectedValue == "JL.Address") || (ddlCondition2.SelectedValue == "MA.Street") || (ddlCondition2.SelectedValue == "JL.History") || (ddlCondition2.SelectedValue == "JL.Comments") || (ddlCondition2.SelectedValue == "MA.USMH") || (ddlCondition2.SelectedValue == "MA.DSMH") || (ddlCondition2.SelectedValue == "JL.CoPitLocation") || (ddlCondition2.SelectedValue == "JL.CoRequired") || (ddlCondition2.SelectedValue == "JL.PitRequired") || (ddlCondition2.SelectedValue == "JL.PostContractDigRequired") || (ddlCondition2.SelectedValue == "JL.LiningThruCo") || (ddlCondition2.SelectedValue == "JL.HamiltonInspectionNumber"))
                {
                    if ((ddlOperator2.SelectedValue == "=") || (ddlOperator2.SelectedValue == "<>"))
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }

                // ... For date fields
                if ((ddlCondition2.SelectedValue == "JL.VideoInspection") || (ddlCondition2.SelectedValue == "JL.PipeLocated") || (ddlCondition2.SelectedValue == "JL.ServicesLocated") || (ddlCondition2.SelectedValue == "JL.CoInstalled") || (ddlCondition2.SelectedValue == "JL.BackfilledConcrete") || (ddlCondition2.SelectedValue == "JL.BackfilledSoil") || (ddlCondition2.SelectedValue == "JL.Grouted") || (ddlCondition2.SelectedValue == "JL.Cored") || (ddlCondition2.SelectedValue == "JL.Prepped") || (ddlCondition2.SelectedValue == "JL.Measured") || (ddlCondition2.SelectedValue == "JL.InProcess") || (ddlCondition2.SelectedValue == "JL.InStock") || (ddlCondition2.SelectedValue == "JL.Delivered") || (ddlCondition2.SelectedValue == "JL.PreVideo") || (ddlCondition2.SelectedValue == "JL.LinerInstalled") || (ddlCondition2.SelectedValue == "JL.FinalVideo") || (ddlCondition2.SelectedValue == "JL.CoCutDown") || (ddlCondition2.SelectedValue == "JL.FinalRestoration") || (ddlCondition2.SelectedValue == "JL.NoticeDelivered"))
                {
                    if ((tbxCondition2.Text.Trim() == "%") && (ddlOperator2.SelectedValue != "=") && (ddlOperator2.SelectedValue != "<>"))
                    {
                        args.IsValid = false;
                    }
                    else
                    {
                        if ((tbxCondition2.Text.Trim() == "") && (ddlOperator2.SelectedValue != "=") && (ddlOperator2.SelectedValue != "<>"))
                        {
                            args.IsValid = false;
                        }
                        else
                        {
                            args.IsValid = true;
                        }
                    }
                }

                // For Integer fields
                if (ddlCondition2.SelectedValue == "JL.BuildRebuild")
                {
                    if ((tbxCondition2.Text.Trim() == "%") && (ddlOperator2.SelectedValue != "=") && (ddlOperator2.SelectedValue != "<>"))
                    {
                        args.IsValid = false;
                    }
                    else
                    {
                        if ((tbxCondition2.Text.Trim() == "") && (ddlOperator2.SelectedValue != "=") && (ddlOperator2.SelectedValue != "<>"))
                        {
                            args.IsValid = false;
                        }
                        else
                        {
                            args.IsValid = true;
                        }
                    }
                }
            }
        }



        protected void cvSelectOperator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((ddlCondition2.SelectedValue != "") && (ddlOperator2.SelectedValue == ""))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvDeleteOperator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((ddlCondition2.SelectedValue == "") && (ddlOperator2.SelectedValue != ""))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }

        }



        protected void cvDeleteCondition2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((ddlCondition2.SelectedValue == "") && (tbxCondition2.Text.Trim() != ""))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = "";
            string headerValues = "";

            switch (e.Item.Value)
            {
                case "mClearSearch":
                    url = "./jliner_navigator.aspx?source_page=lm&client=" + hdfCurrentClient.Value;
                    break;

                case "mPreview":
                    int totalColumns = 38;

                    // Update comments
                    JlinerNavigator jlinerNavigator = new JlinerNavigator(jlinerNavigatorTDS);
                    jlinerNavigator.UpdateCommentsHistoryForReport();

                    // Establishing header values                        
                    if (cbxId.Checked) headerValues += "ID";
                    if (cbxClientLateralId.Checked) headerValues += " * Client Lateral ID";
                    if (cbxHamiltonInspectionNumber.Checked) headerValues += " * Hamilton Inspection Number";
                    if (cbxStreet.Checked) headerValues += " * Street";
                    if (cbxAddress.Checked) headerValues += " * Address";
                    if (cbxCity.Checked) headerValues += " * City";
                    if (cbxUSMH.Checked) headerValues += " * USMH";
                    if (cbxDSMH.Checked) headerValues += " * DSMH";
                    if (cbxVideoInspection.Checked) headerValues += " * Video Inspection";
                    if (cbxVideoLengthToPropertyLine.Checked) headerValues += " * Video Length To PL";
                    if (cbxPipeLocated.Checked) headerValues += " * Pipe Located";
                    if (cbxServicesLocated.Checked) headerValues += " * Services Located";
                    if (cbxCoRequired.Checked) headerValues += " * C/O Req.";
                    if (cbxPitRequired.Checked) headerValues += " * Pit Req.";
                    if (cbxCoPitLocation.Checked) headerValues += " * CO/Pit Location";
                    if (cbxCoInstalled.Checked) headerValues += " * C/O Installed";
                    if (cbxBackfilledConcrete.Checked) headerValues += " * Backfilled Con.";
                    if (cbxBackfilledSoil.Checked) headerValues += " * Backfilled Soil";
                    if (cbxGrouted.Checked) headerValues += " * Grouted";
                    if (cbxCored.Checked) headerValues += " * Cored";
                    if (cbxPrepped.Checked) headerValues += " * Prepped";
                    if (cbxPreVideo.Checked) headerValues += " * Pre-Video";
                    if (cbxMeasured.Checked) headerValues += " * Measured";
                    if (cbxLinerSize.Checked) headerValues += " * Liner Size";
                    if (cbxLiningThruCo.Checked) headerValues += " * Lining Thru C/O";
                    if (cbxNoticeDelivered.Checked) headerValues += " * Notice Delivered";
                    if (cbxInProcess.Checked) headerValues += " * In Process";
                    if (cbxInStock.Checked) headerValues += " * In Stock";
                    if (cbxDelivered.Checked) headerValues += " * Delivered";
                    if (cbxLinerInstalled.Checked) headerValues += " * Liner Installed";
                    if (cbxFinalVideo.Checked) headerValues += " * Final Video";
                    if (cbxDistanceFromUSMH.Checked) headerValues += " * Dist. From USMH";
                    if (cbxDistanceFromDSMH.Checked) headerValues += " * Dist. From DSMH";
                    if (cbxPostContractDigRequired.Checked) headerValues += " * Post Contract Dig?";
                    if (cbxCoCutDown.Checked) headerValues += " * C/O Cut Down?";
                    if (cbxFinalRestoration.Checked) headerValues += " * Final Restoration";
                    if (cbxCost.Checked) headerValues += " * Cost";
                    if (cbxBuidRebuid.Checked) headerValues += " * Build / Rebuild";

                    // Establishing columns to display
                    string[] columns = headerValues.Split('*');
                    string columnsForReport = "";
                    int j;

                    // ... for visible columns
                    for (int i = 0; i < columns.Length; i++)
                    {
                        j = i + 1;
                        columnsForReport += "&header" + j + "=" + columns[i].Trim();
                    }

                    // ... For not visible columns
                    for (int i = columns.Length; i < totalColumns; i++)
                    {
                        j = i + 1;
                        columnsForReport += "&header" + j + "=None";
                    }

                    // ... For comments and history options
                    string comments = "None";
                    string history = "None";
                    if (cbxComments.Checked) comments = "Comments";
                    if (cbxHistory.Checked) history = "History";

                    // Report call
                    Page.Validate();
                    if (Page.IsValid)
                    {
                        PostPageChanges();
                        Response.Write("<script language='javascript'> {window.open('./../../viewer.aspx?target_report=rJlinerPrintSearchResults" + columnsForReport + "&comments=" + comments + "&history=" + history + "&totalColumns=" + totalColumns + "&totalSelectedColumns=" + columns.Length + "&name=" + hdfClientName.Value + "&format=pdf', '_blank', 'toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width=600, height=300');}</script>");
                    }

                    break;

                case "mExport":
                    int totalColumnsExport = 40;
                    headerValues = "";
                    columnsForReport = "";

                    // Update comments
                    JlinerNavigator jlinerNavigatorExcel = new JlinerNavigator(jlinerNavigatorTDS);
                    jlinerNavigatorExcel.UpdateCommentsHistoryForReport();

                    // Establishing header values
                    if (cbxId.Checked) headerValues += "ID";
                    if (cbxClientLateralId.Checked) headerValues += " * Client Lateral ID";
                    if (cbxHamiltonInspectionNumber.Checked) headerValues += " * Hamilton Inspection Number";
                    if (cbxStreet.Checked) headerValues += " * Street";
                    if (cbxAddress.Checked) headerValues += " * Address";
                    if (cbxCity.Checked) headerValues += " * City";
                    if (cbxUSMH.Checked) headerValues += " * USMH";
                    if (cbxDSMH.Checked) headerValues += " * DSMH";
                    if (cbxVideoInspection.Checked) headerValues += " * Video Inspection";
                    if (cbxVideoLengthToPropertyLine.Checked) headerValues += " * Video Length To PL";
                    if (cbxPipeLocated.Checked) headerValues += " * Pipe Located";
                    if (cbxServicesLocated.Checked) headerValues += " * Services Located";
                    if (cbxCoRequired.Checked) headerValues += " * C/O Req.";
                    if (cbxPitRequired.Checked) headerValues += " * Pit Req.";
                    if (cbxCoPitLocation.Checked) headerValues += " * CO/Pit Location";
                    if (cbxCoInstalled.Checked) headerValues += " * C/O Installed";
                    if (cbxBackfilledConcrete.Checked) headerValues += " * Backfilled Con.";
                    if (cbxBackfilledSoil.Checked) headerValues += " * Backfilled Soil";
                    if (cbxGrouted.Checked) headerValues += " * Grouted";
                    if (cbxCored.Checked) headerValues += " * Cored";
                    if (cbxPrepped.Checked) headerValues += " * Prepped";
                    if (cbxPreVideo.Checked) headerValues += " * Pre-Video";
                    if (cbxMeasured.Checked) headerValues += " * Measured";
                    if (cbxLinerSize.Checked) headerValues += " * Liner Size";
                    if (cbxLiningThruCo.Checked) headerValues += " * Lining Thru C/O";
                    if (cbxNoticeDelivered.Checked) headerValues += " * Notice Delivered";
                    if (cbxInProcess.Checked) headerValues += " * In Process";
                    if (cbxInStock.Checked) headerValues += " * In Stock";
                    if (cbxDelivered.Checked) headerValues += " * Delivered";
                    if (cbxLinerInstalled.Checked) headerValues += " * Liner Installed";
                    if (cbxFinalVideo.Checked) headerValues += " * Final Video";
                    if (cbxDistanceFromUSMH.Checked) headerValues += " * Dist. From USMH";
                    if (cbxDistanceFromDSMH.Checked) headerValues += " * Dist. From DSMH";
                    if (cbxPostContractDigRequired.Checked) headerValues += " * Post Contract Dig?";
                    if (cbxCoCutDown.Checked) headerValues += " * C/O Cut Down?";
                    if (cbxFinalRestoration.Checked) headerValues += " * Final Restoration";
                    if (cbxCost.Checked) headerValues += " * Cost";
                    if (cbxBuidRebuid.Checked) headerValues += " * Build / Rebuild";
                    if (cbxComments.Checked) headerValues += " * Comments";
                    if (cbxHistory.Checked) headerValues += " * History";

                    // Establishing columns to display
                    string[] columnsExcel = headerValues.Split('*');

                    // ... for visible columns
                    for (int i = 0; i < columnsExcel.Length; i++)
                    {
                        j = i + 1;
                        columnsForReport += "&header" + j + "=" + columnsExcel[i].Trim();
                    }

                    // ... For not visible columns
                    for (int i = columnsExcel.Length; i < totalColumnsExport; i++)
                    {
                        j = i + 1;
                        columnsForReport += "&header" + j + "=None";
                    }

                    // Report call
                    Page.Validate();
                    if (Page.IsValid)
                    {
                        PostPageChanges();
                        url = "./../../viewer.aspx?target_report=rJlinerPrintSearchResults" + columnsForReport + "&totalColumns=" + totalColumnsExport + "&totalSelectedColumns=" + columnsExcel.Length + "&name=" + hdfClientName.Value + "&format=excel";

                    }
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

                case "mLiningPlan":
                    url = "./linning_plan.aspx?source_page=lm&client=" + hdfCurrentClient.Value;
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        protected string GetRound(object value, int decimals)
        {
            if (value != DBNull.Value)
            {
                if (decimals == 2)
                {
                    return string.Format("{0:0.00}", Convert.ToDecimal(value));
                }
                else
                {
                    return string.Format("{0:0.0}", Convert.ToDecimal(value));
                }
            }
            else
            {
                return "";
            }
        }



        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfCurrentClientId = '" + hdfCurrentClient.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./jliner_navigator2.js");
        }



        private void RestoreNavigatorState()
        {
            // Columns To Display
            string columnsToDisplay = Request.QueryString["columns_to_display"];
            cbxId.Checked = (columnsToDisplay.IndexOf("Id") >= 0 ? true : false);
            cbxClientLateralId.Checked = (columnsToDisplay.IndexOf("ClientLateralId") >= 0 ? true : false);
            cbxHamiltonInspectionNumber.Checked = (columnsToDisplay.IndexOf("HamiltonInspectionNumber") >= 0 ? true : false);
            cbxStreet.Checked = (columnsToDisplay.IndexOf("Street") >= 0 ? true : false);
            cbxAddress.Checked = (columnsToDisplay.IndexOf("Address") >= 0 ? true : false);
            cbxCity.Checked = (columnsToDisplay.IndexOf("City") >= 0 ? true : false);
            cbxUSMH.Checked = (columnsToDisplay.IndexOf("U_SMH") >= 0 ? true : false);
            cbxDSMH.Checked = (columnsToDisplay.IndexOf("D_SMH") >= 0 ? true : false);
            cbxVideoInspection.Checked = (columnsToDisplay.IndexOf("VideoInspection") >= 0 ? true : false);
            cbxVideoLengthToPropertyLine.Checked = (columnsToDisplay.IndexOf("VideoLengthToPropertyLine") >= 0 ? true : false);
            cbxPipeLocated.Checked = (columnsToDisplay.IndexOf("PipeLocated") >= 0 ? true : false);
            cbxServicesLocated.Checked = (columnsToDisplay.IndexOf("ServicesLocated") >= 0 ? true : false);
            cbxCoRequired.Checked = (columnsToDisplay.IndexOf("CoRequired") >= 0 ? true : false);
            cbxPitRequired.Checked = (columnsToDisplay.IndexOf("PitRequired") >= 0 ? true : false);
            cbxCoPitLocation.Checked = (columnsToDisplay.IndexOf("CoPitLocation") >= 0 ? true : false);
            cbxCoInstalled.Checked = (columnsToDisplay.IndexOf("CoInstalled") >= 0 ? true : false);
            cbxBackfilledConcrete.Checked = (columnsToDisplay.IndexOf("BackfilledConcrete") >= 0 ? true : false);
            cbxBackfilledSoil.Checked = (columnsToDisplay.IndexOf("BackfilledSoil") >= 0 ? true : false);
            cbxGrouted.Checked = (columnsToDisplay.IndexOf("Grouted") >= 0 ? true : false);
            cbxCored.Checked = (columnsToDisplay.IndexOf("Cored") >= 0 ? true : false);
            cbxPrepped.Checked = (columnsToDisplay.IndexOf("Prepped") >= 0 ? true : false);
            cbxPreVideo.Checked = (columnsToDisplay.IndexOf("PreVideo") >= 0 ? true : false);
            cbxMeasured.Checked = (columnsToDisplay.IndexOf("Measured") >= 0 ? true : false);
            cbxLinerSize.Checked = (columnsToDisplay.IndexOf("LinerSize") >= 0 ? true : false);
            cbxLiningThruCo.Checked = (columnsToDisplay.IndexOf("LiningThruCo") >= 0 ? true : false);
            cbxNoticeDelivered.Checked = (columnsToDisplay.IndexOf("NoticeD_elivered") >= 0 ? true : false);
            cbxInProcess.Checked = (columnsToDisplay.IndexOf("InProcess") >= 0 ? true : false);
            cbxInStock.Checked = (columnsToDisplay.IndexOf("InStock") >= 0 ? true : false);
            cbxDelivered.Checked = (columnsToDisplay.IndexOf("Delivered") >= 0 ? true : false);
            cbxLinerInstalled.Checked = (columnsToDisplay.IndexOf("LinerInstalled") >= 0 ? true : false);
            cbxFinalVideo.Checked = (columnsToDisplay.IndexOf("FinalVideo") >= 0 ? true : false);
            cbxDistanceFromUSMH.Checked = (columnsToDisplay.IndexOf("DistanceFromUSMH") >= 0 ? true : false);
            cbxDistanceFromDSMH.Checked = (columnsToDisplay.IndexOf("DistanceFromDSMH") >= 0 ? true : false);
            cbxPostContractDigRequired.Checked = (columnsToDisplay.IndexOf("PostContractDigRequired") >= 0 ? true : false);
            cbxCoCutDown.Checked = (columnsToDisplay.IndexOf("CoCutDown") >= 0 ? true : false);
            cbxFinalRestoration.Checked = (columnsToDisplay.IndexOf("FinalRestoration") >= 0 ? true : false);
            cbxCost.Checked = (columnsToDisplay.IndexOf("Cost") >= 0 ? true : false);
            cbxBuidRebuid.Checked = (columnsToDisplay.IndexOf("BuildRebuild") >= 0 ? true : false);
            cbxComments.Checked = (columnsToDisplay.IndexOf("Comments") >= 0 ? true : false);
            cbxHistory.Checked = (columnsToDisplay.IndexOf("History") >= 0 ? true : false);

            // Search condition 1
            if (Request.QueryString["search_ddlCondition1"] == "MA.RecordID   '-'   JL.DetailID")
            {
                ddlCondition1.SelectedIndex = 0;
            }
            else
            {
                ddlCondition1.SelectedValue = Request.QueryString["search_ddlCondition1"];
            }
            
            ddlOperator1.SelectedValue = Request.QueryString["search_ddlOperator1"];
            tbxCondition1.Text = Request.QueryString["search_tbxCondition1"];

            // Search condition 2
            if (Request.QueryString["search_ddlCondition2"] == "MA.RecordID   '-'   JL.DetailID")
            {
                ddlCondition2.SelectedIndex = 1;
            }
            else
            {
                ddlCondition2.SelectedValue = Request.QueryString["search_ddlCondition2"];
            }
            ddlOperator2.SelectedValue = Request.QueryString["search_ddlOperator2"];
            tbxCondition2.Text = Request.QueryString["search_tbxCondition2"];
            
            // Other values
            ddlIssues.SelectedValue = Request.QueryString["search_issues"];
            ddlSortBy.SelectedValue = Request.QueryString["search_sort_by"];
            ddlSubArea.SelectedValue = Request.QueryString["search_sub_area"];

            // Grid's columns
            grdJlinerNavigator.Columns[2].Visible = cbxClientLateralId.Checked;
            grdJlinerNavigator.Columns[3].Visible = cbxHamiltonInspectionNumber.Checked;
            grdJlinerNavigator.Columns[4].Visible = cbxStreet.Checked;
            grdJlinerNavigator.Columns[5].Visible = cbxAddress.Checked;
            grdJlinerNavigator.Columns[6].Visible = cbxCity.Checked;
            grdJlinerNavigator.Columns[7].Visible = cbxUSMH.Checked;
            grdJlinerNavigator.Columns[8].Visible = cbxDSMH.Checked;
            grdJlinerNavigator.Columns[9].Visible = cbxVideoInspection.Checked;
            grdJlinerNavigator.Columns[10].Visible = cbxVideoLengthToPropertyLine.Checked;
            grdJlinerNavigator.Columns[11].Visible = cbxPipeLocated.Checked;
            grdJlinerNavigator.Columns[12].Visible = cbxServicesLocated.Checked;
            grdJlinerNavigator.Columns[13].Visible = cbxCoRequired.Checked;
            grdJlinerNavigator.Columns[14].Visible = cbxPitRequired.Checked;
            grdJlinerNavigator.Columns[15].Visible = cbxCoPitLocation.Checked;
            grdJlinerNavigator.Columns[16].Visible = cbxCoInstalled.Checked;
            grdJlinerNavigator.Columns[17].Visible = cbxBackfilledConcrete.Checked;
            grdJlinerNavigator.Columns[18].Visible = cbxBackfilledSoil.Checked;
            grdJlinerNavigator.Columns[19].Visible = cbxGrouted.Checked;
            grdJlinerNavigator.Columns[20].Visible = cbxCored.Checked;
            grdJlinerNavigator.Columns[21].Visible = cbxPrepped.Checked;
            grdJlinerNavigator.Columns[22].Visible = cbxPreVideo.Checked;
            grdJlinerNavigator.Columns[23].Visible = cbxMeasured.Checked;
            grdJlinerNavigator.Columns[24].Visible = cbxLinerSize.Checked;
            grdJlinerNavigator.Columns[25].Visible = cbxLiningThruCo.Checked;
            grdJlinerNavigator.Columns[26].Visible = cbxNoticeDelivered.Checked;
            grdJlinerNavigator.Columns[27].Visible = cbxInProcess.Checked;
            grdJlinerNavigator.Columns[28].Visible = cbxInStock.Checked;
            grdJlinerNavigator.Columns[29].Visible = cbxDelivered.Checked;
            grdJlinerNavigator.Columns[30].Visible = cbxLinerInstalled.Checked;
            grdJlinerNavigator.Columns[31].Visible = cbxFinalVideo.Checked;
            grdJlinerNavigator.Columns[32].Visible = cbxDistanceFromUSMH.Checked;
            grdJlinerNavigator.Columns[33].Visible = cbxDistanceFromDSMH.Checked;
            grdJlinerNavigator.Columns[34].Visible = cbxPostContractDigRequired.Checked;
            grdJlinerNavigator.Columns[35].Visible = cbxCoCutDown.Checked;
            grdJlinerNavigator.Columns[36].Visible = cbxFinalRestoration.Checked;
            grdJlinerNavigator.Columns[37].Visible = cbxCost.Checked;
            grdJlinerNavigator.Columns[38].Visible = cbxBuidRebuid.Checked;
            grdJlinerNavigator.Columns[39].Visible = cbxComments.Checked;
            grdJlinerNavigator.Columns[40].Visible = cbxHistory.Checked;
        }



        private string GetNavigatorState()
        {
            // Columns To Display
            string columnsToDisplay = "&columns_to_display=Id,";
            columnsToDisplay = columnsToDisplay + (cbxClientLateralId.Checked ? "ClientLateralId," : "");
            columnsToDisplay = columnsToDisplay + (cbxHamiltonInspectionNumber.Checked ? "HamiltonInspectionNumber," : "");
            columnsToDisplay = columnsToDisplay + (cbxStreet.Checked ? "Street," : "");
            columnsToDisplay = columnsToDisplay + (cbxAddress.Checked ? "Address," : "");
            columnsToDisplay = columnsToDisplay + (cbxCity.Checked ? "City," : "");
            columnsToDisplay = columnsToDisplay + (cbxUSMH.Checked ? "U_SMH," : "");
            columnsToDisplay = columnsToDisplay + (cbxDSMH.Checked ? "D_SMH," : "");
            columnsToDisplay = columnsToDisplay + (cbxVideoInspection.Checked ? "VideoInspection," : "");
            columnsToDisplay = columnsToDisplay + (cbxVideoLengthToPropertyLine.Checked ? "VideoLengthToPropertyLine," : "");
            columnsToDisplay = columnsToDisplay + (cbxPipeLocated.Checked ? "PipeLocated," : "");
            columnsToDisplay = columnsToDisplay + (cbxServicesLocated.Checked ? "ServicesLocated," : "");
            columnsToDisplay = columnsToDisplay + (cbxCoRequired.Checked ? "CoRequired," : "");
            columnsToDisplay = columnsToDisplay + (cbxPitRequired.Checked ? "PitRequired," : "");
            columnsToDisplay = columnsToDisplay + (cbxCoPitLocation.Checked ? "CoPitLocation," : "");
            columnsToDisplay = columnsToDisplay + (cbxCoInstalled.Checked ? "CoInstalled," : "");
            columnsToDisplay = columnsToDisplay + (cbxBackfilledConcrete.Checked ? "BackfilledConcrete," : "");
            columnsToDisplay = columnsToDisplay + (cbxBackfilledSoil.Checked ? "BackfilledSoil," : "");
            columnsToDisplay = columnsToDisplay + (cbxGrouted.Checked ? "Grouted," : "");
            columnsToDisplay = columnsToDisplay + (cbxCored.Checked ? "Cored," : "");
            columnsToDisplay = columnsToDisplay + (cbxPrepped.Checked ? "Prepped," : "");
            columnsToDisplay = columnsToDisplay + (cbxPreVideo.Checked ? "PreVideo," : "");
            columnsToDisplay = columnsToDisplay + (cbxMeasured.Checked ? "Measured," : "");
            columnsToDisplay = columnsToDisplay + (cbxLinerSize.Checked ? "LinerSize," : "");
            columnsToDisplay = columnsToDisplay + (cbxLiningThruCo.Checked ? "LiningThruCo," : "");
            columnsToDisplay = columnsToDisplay + (cbxNoticeDelivered.Checked ? "NoticeD_elivered," : "");
            columnsToDisplay = columnsToDisplay + (cbxInProcess.Checked ? "InProcess," : "");
            columnsToDisplay = columnsToDisplay + (cbxInStock.Checked ? "InStock," : "");
            columnsToDisplay = columnsToDisplay + (cbxDelivered.Checked ? "Delivered," : "");
            columnsToDisplay = columnsToDisplay + (cbxLinerInstalled.Checked ? "LinerInstalled," : "");
            columnsToDisplay = columnsToDisplay + (cbxFinalVideo.Checked ? "FinalVideo," : "");
            columnsToDisplay = columnsToDisplay + (cbxDistanceFromUSMH.Checked ? "DistanceFromUSMH," : "");
            columnsToDisplay = columnsToDisplay + (cbxDistanceFromDSMH.Checked ? "DistanceFromDSMH," : "");
            columnsToDisplay = columnsToDisplay + (cbxPostContractDigRequired.Checked ? "PostContractDigRequired," : "");
            columnsToDisplay = columnsToDisplay + (cbxCoCutDown.Checked ? "CoCutDown," : "");
            columnsToDisplay = columnsToDisplay + (cbxFinalRestoration.Checked ? "FinalRestoration," : "");
            columnsToDisplay = columnsToDisplay + (cbxCost.Checked ? "Cost," : "");
            columnsToDisplay = columnsToDisplay + (cbxBuidRebuid.Checked ? "BuildRebuild," : "");
            columnsToDisplay = columnsToDisplay + (cbxComments.Checked ? "Comments," : "");
            columnsToDisplay = columnsToDisplay + (cbxHistory.Checked ? "History," : "");
            columnsToDisplay = columnsToDisplay.Substring(0, columnsToDisplay.Length - 1);

            // SearchOptions for condition 1
            string searchOptions = "";
            searchOptions = searchOptions + "&search_ddlCondition1=" + ddlCondition1.SelectedValue;
            searchOptions = searchOptions + "&search_ddlOperator1=" + ddlOperator1.SelectedValue;
            searchOptions = searchOptions + "&search_tbxCondition1=" + tbxCondition1.Text.Trim();

            // SearchOptions for condition 2
            searchOptions = searchOptions + "&search_ddlCondition2=" + ddlCondition2.SelectedValue;
            searchOptions = searchOptions + "&search_ddlOperator2=" + ddlOperator2.SelectedValue;
            searchOptions = searchOptions + "&search_tbxCondition2=" + tbxCondition2.Text.Trim();

            // Other values
            searchOptions = searchOptions + "&search_issues=" + ddlIssues.SelectedValue;
            searchOptions = searchOptions + "&search_sort_by=" + ddlSortBy.SelectedValue;
            searchOptions = searchOptions + "&search_sub_area=" + ddlSubArea.SelectedValue;

            // Return
            return columnsToDisplay + searchOptions;
        }



        private JlinerNavigatorTDS SubmitSearch()
        {
            // Retrieve clauses
            string whereClause = GetWhereClause();
            string orderByClause = GetOrderByClause();

            JlinerNavigator jlinerNavigator = new JlinerNavigator();

            // ... Load data
            jlinerNavigator.Load(whereClause, orderByClause);

            return (JlinerNavigatorTDS)jlinerNavigator.Data;
        }



        private string GetWhereClause()
        {
            // General conditions
            string whereClause = "(MA.Deleted = 0) AND (MA.Archived = 0) AND (MA.COMPANY_ID = 3) AND (JL.Deleted = 0) AND "; //Note: COMPANY_ID

            // Client condition
            whereClause = whereClause + "(MA.COMPANIES_ID = " + hdfCurrentClient.Value + ") AND ";

            // Issues condition
            if (ddlIssues.SelectedValue != "(All)")
            {
                switch (ddlIssues.SelectedValue)
                {
                    case "Yes":
                        whereClause = whereClause + "(JL.Issue = 'Yes') AND ";
                        break;

                    case "No":
                        whereClause = whereClause + "(JL.Issue = 'No') AND ";
                        break;

                    case "Out Of Scope":
                        whereClause = whereClause + "(JL.Issue = 'Out Of Scope') AND ";
                        break;

                    case "Dig Required Prior To Lining":
                        whereClause = whereClause + "(JL.Issue = 'Dig Required Prior To Lining') AND ";
                        break;

                    case "Dig Required After Lining":
                        whereClause = whereClause + "(JL.Issue = 'Dig Required After Lining') AND ";
                        break;

                    case "Hold - Client Issue":
                        whereClause = whereClause + "(JL.Issue = 'Hold - Client Issue') AND ";
                        break;

                    case "Hold - LFS Issue":
                        whereClause = whereClause + "(JL.Issue = 'Hold - LFS Issue') AND ";
                        break;

                    case "Robotic Prep Required":
                        whereClause = whereClause + "  (JL.Issue = 'Robotic Prep Required') AND ";
                        break;
                }
            }

            // Sub Area condition
            if (ddlSubArea.SelectedValue != "(All)")
            {
                if (ddlSubArea.SelectedValue != "")
                {
                    whereClause = whereClause + "(MA.SubArea = '" + ddlSubArea.SelectedValue.ToString() + "') AND ";
                }
                else
                {
                    whereClause = whereClause + "(MA.SubArea = '' OR MA.SubArea IS NULL) AND ";
                }
            }

            // Field condition
            // ... Condition 1
            whereClause = modifyWhereClauseForCondition(whereClause, ddlCondition1.SelectedValue, ddlOperator1.SelectedValue, tbxCondition1.Text.Trim());

            // ... If condition 2 exists
            if (ddlCondition2.SelectedValue != "")
            {
                whereClause = whereClause + " AND ";
                whereClause = modifyWhereClauseForCondition(whereClause, ddlCondition2.SelectedValue, ddlOperator2.SelectedValue, tbxCondition2.Text.Trim());
            }

            return whereClause;
        }



        private string modifyWhereClauseForCondition(string whereClause, string conditionValue, string operatorValue, string textForSearch)
        {
            // ... FOR TEXT FIELDS. (Jliner ID, client lateral id, Address, Street, USMH, DSMH, CoPitLocation, Comments or HamiltonInspectionNumber)
            if ((conditionValue == "MA.RecordID + '-' + JL.DetailID") || (conditionValue == "JL.ClientLateralID") || (conditionValue == "JL.Address") || (conditionValue == "MA.Street") || (conditionValue == "JL.History") || (conditionValue == "JL.Comments") || (conditionValue == "MA.USMH") || (conditionValue == "MA.DSMH") || (conditionValue == "JL.CoPitLocation") || (conditionValue == "JL.HamiltonInspectionNumber"))
            {
                // ... For operator =
                if (operatorValue == "=")
                {
                    if (textForSearch == "")
                    {
                        whereClause = whereClause + "(" + conditionValue + " IS NULL)";
                    }
                    else
                    {
                        if (textForSearch == "%")
                        {
                            whereClause = whereClause + "((" + conditionValue + " LIKE '%')";
                            whereClause = whereClause + " OR (" + conditionValue + " IS NULL))";
                        }
                        else
                        {
                            textForSearch = textForSearch.Replace("'", "''");
                            whereClause = whereClause + "(" + conditionValue + " LIKE '%" + textForSearch + "%')";
                        }
                    }
                }
                else
                {
                    // ... For operator <>
                    if (operatorValue == "<>")
                    {
                        if (textForSearch == "")
                        {
                            whereClause = whereClause + "((" + conditionValue + " LIKE '%')";
                            whereClause = whereClause + " OR (" + conditionValue + " IS NOT NULL))";
                        }
                        else
                        {
                            if (textForSearch == "%")
                            {
                                whereClause = whereClause + "(" + conditionValue + " IS NULL)";
                            }
                            else
                            {
                                textForSearch = textForSearch.Replace("'", "''");
                                whereClause = whereClause + "((" + conditionValue + " NOT LIKE '%" + textForSearch + "%')";
                                whereClause = whereClause + " OR (" + conditionValue + " IS NULL))";
                            }
                        }
                    }
                }
            }

            // ... FOR BOOLEAN FIELDS (CoRequired, PitRequired, PostContractDigRequired, LiningThruCo)
            if ((conditionValue == "JL.CoRequired") || (conditionValue == "JL.PitRequired") || (conditionValue == "JL.PostContractDigRequired") || (conditionValue == "JL.LiningThruCo"))
            {
                // ... For operator =
                if (operatorValue == "=")
                {
                    if (textForSearch == "")
                    {
                        whereClause = whereClause.Substring(0, whereClause.Length - 4);
                    }
                    else
                    {
                        if ((textForSearch.ToUpper() == "Y") || (textForSearch.ToUpper() == "YES"))
                        {
                            whereClause = whereClause + "(" + conditionValue + " = 1)";
                        }
                        else
                        {
                            if ((textForSearch.ToUpper() == "N") || (textForSearch.ToUpper() == "NO"))
                            {
                                whereClause = whereClause + "(" + conditionValue + " = 0)";
                            }
                            else
                            {
                                if (textForSearch == "%")
                                {
                                    whereClause = whereClause + "((" + conditionValue + " = 1) OR (" + conditionValue + " = 0))";
                                }
                            }
                        }
                    }
                }
                else
                {
                    // ... For operator <>
                    if (operatorValue == "<>")
                    {
                        if (textForSearch == "")
                        {
                            whereClause = whereClause + "((" + conditionValue + " = 1) OR (" + conditionValue + " = 0))";
                        }
                        else
                        {
                            if ((textForSearch.ToUpper() == "Y") || (textForSearch.ToUpper() == "YES"))
                            {
                                whereClause = whereClause + "(" + conditionValue + " = 0)";
                            }
                            else
                            {
                                if ((textForSearch.ToUpper() == "N") || (textForSearch.ToUpper() == "NO"))
                                {
                                    whereClause = whereClause + "(" + conditionValue + " = 1)";
                                }
                                else
                                {
                                    if (textForSearch == "%")
                                    {
                                        whereClause = whereClause.Substring(0, whereClause.Length - 4);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // ... FOR INTEGER FIELDS. (Build / Rebuild #)
            if (conditionValue == "JL.BuildRebuild")
            {
                // ... For operator =
                if (operatorValue == "=")
                {
                    if (textForSearch == "")
                    {
                        whereClause = whereClause + "(" + conditionValue + " IS NULL)";
                    }
                    else
                    {
                        if (textForSearch == "%")
                        {
                            whereClause = whereClause + "((" + conditionValue + " LIKE '%')";
                            whereClause = whereClause + " OR (" + conditionValue + " IS NULL))";
                        }
                        else
                        {
                            whereClause = whereClause + "(" + conditionValue + operatorValue + textForSearch + ")";
                        }
                    }
                }
                else
                {
                    // ... For operator <>
                    if (operatorValue == "<>")
                    {
                        if (textForSearch == "")
                        {
                            whereClause = whereClause + "((" + conditionValue + " LIKE '%')";
                            whereClause = whereClause + " OR (" + conditionValue + " IS NOT NULL))";
                        }
                        else
                        {
                            if (textForSearch == "%")
                            {
                                whereClause = whereClause + "(" + conditionValue + " IS NULL)";
                            }
                            else
                            {
                                whereClause = whereClause + "((" + conditionValue + operatorValue + textForSearch + ")";
                                whereClause = whereClause + " OR (" + conditionValue + " IS NULL))";
                            }
                        }
                    }
                    else
                    {
                        // ... For other operators

                        // ... Determine the operator
                        string whereOperator = "";
                        if (operatorValue == "'>='")
                        {
                            whereOperator = ">=";
                        }
                        else
                        {
                            if (operatorValue == "'<='")
                            {
                                whereOperator = "<=";
                            }
                            else
                            {
                                whereOperator = operatorValue;
                            }
                        }

                        whereClause = whereClause + "(" + conditionValue + whereOperator + textForSearch + ")";
                    }
                }
            }

            // ... FOR DATE FIELDS. (VideoInspection, PipeLocated, ServicesLocated, CoInstalled, BackfilledConcrete, BackfilledSoil, Grouted, Cored, Prepped, Measured, InProcess, InStock, Delivered, PreVideo, LinerInstalled, FinalVideo, CoCutDown, FinalRestoration or NoticeDelivered)
            if ((conditionValue == "JL.VideoInspection") || (conditionValue == "JL.PipeLocated") || (conditionValue == "JL.ServicesLocated") || (conditionValue == "JL.CoInstalled") || (conditionValue == "JL.BackfilledConcrete") || (conditionValue == "JL.BackfilledSoil") || (conditionValue == "JL.Grouted") || (conditionValue == "JL.Cored") || (conditionValue == "JL.Prepped") || (conditionValue == "JL.Measured") || (conditionValue == "JL.InProcess") || (conditionValue == "JL.InStock") || (conditionValue == "JL.Delivered") || (conditionValue == "JL.PreVideo") || (conditionValue == "JL.LinerInstalled") || (conditionValue == "JL.FinalVideo") || (conditionValue == "JL.CoCutDown") || (conditionValue == "JL.FinalRestoration") || (conditionValue == "JL.NoticeDelivered"))
            {
                // ... For operator =
                if (operatorValue == "=")
                {
                    if (textForSearch == "")
                    {
                        whereClause = whereClause + "(CAST(CONVERT(varchar," + conditionValue + ", 101) AS smalldatetime) IS NULL)";
                    }
                    else
                    {
                        if (textForSearch == "%")
                        {
                            whereClause = whereClause + "((CAST(CONVERT(varchar," + conditionValue + ", 101) AS smalldatetime) IS NOT NULL) OR ";
                            whereClause = whereClause + "(CAST(CONVERT(varchar," + conditionValue + ", 101) AS smalldatetime) IS NULL))";
                        }
                        else
                        {
                            if ((Validator.IsValidDate(textForSearch)) && (textForSearch.Length > 7))
                            {
                                whereClause = whereClause + " ( CAST(CONVERT(varchar,"+ conditionValue + ", 101) AS smalldatetime) = '" + textForSearch + "')";
                            }
                            else
                            {
                                whereClause = whereClause + "(CAST(CONVERT(varchar," + conditionValue + ", 101) AS smalldatetime) LIKE '%" + textForSearch + "%')";
                            }
                        }
                    }
                }
                else
                {
                    // ... For operator <>
                    if (operatorValue == "<>")
                    {
                        if (textForSearch == "")
                        {
                            whereClause = whereClause + "((CAST(CONVERT(varchar," + conditionValue + ", 101) AS smalldatetime) IS NOT NULL) OR";
                            whereClause = whereClause + "(CAST(CONVERT(varchar," + conditionValue + ", 101) AS smalldatetime) IS NULL))";
                        }
                        else
                        {
                            if (textForSearch == "%")
                            {
                                whereClause = whereClause + "(CAST(CONVERT(varchar," + conditionValue + ", 101) AS smalldatetime) IS NULL)";
                            }
                            else
                            {
                                if ((Validator.IsValidDate(textForSearch)) && (textForSearch.Length > 7))
                                {
                                    whereClause = whereClause + "((CAST(CONVERT(varchar," + conditionValue + ", 101) AS smalldatetime) != '" + textForSearch + "')";
                                    whereClause = whereClause + " OR (CAST(CONVERT(varchar," + conditionValue + ", 101) AS smalldatetime) IS NULL))";
                                }
                                else
                                {
                                    whereClause = whereClause + "((CAST(CONVERT(varchar," + conditionValue + ", 101) AS smalldatetime) NOT LIKE '%" + textForSearch + "%')";
                                    whereClause = whereClause + " OR (CAST(CONVERT(varchar," + conditionValue + ", 101) AS smalldatetime) IS NULL))";
                                }
                            }
                        }
                    }
                    else
                    {
                        // ... For other operators

                        // ... Determine the operator
                        string whereOperator = "";
                        if (operatorValue == "'>='")
                        {
                            whereOperator = ">=";
                        }
                        else
                        {
                            if (operatorValue == "'<='")
                            {
                                whereOperator = "<=";
                            }
                            else
                            {
                                whereOperator = operatorValue;
                            }
                        }

                        // ... Determine the where clause
                        if ((Validator.IsValidDate(textForSearch)) && (textForSearch.Length > 7))
                        {
                            whereClause = whereClause + "(CAST(CONVERT(varchar," + conditionValue + ", 101) AS smalldatetime)" + whereOperator + " '" + textForSearch + "')";
                        }
                        else
                        {
                            if (operatorValue == ">" || operatorValue == "'<='")
                            {
                                whereClause = whereClause + "(CAST(CONVERT(varchar," + conditionValue + ", 101) AS smalldatetime)" + whereOperator + " '12/31/" + textForSearch + "')";
                            }
                            else
                            {
                                whereClause = whereClause + "(CAST(CONVERT(varchar," + conditionValue + ", 101) AS smalldatetime)" + whereOperator + " '" + textForSearch + "')";
                            }
                        }
                    }
                }
            }

            return whereClause;
        }



        private string GetOrderByClause()
        {
            string orderBy = "";

            if (ddlSortBy.SelectedValue == "Date")
            {
                switch (ddlCondition1.SelectedValue)
                {
                    case "JL.VideoInspection":
                        orderBy = "JL.VideoInspection DESC";
                        break;

                    case "JL.PipeLocated":
                        orderBy = "JL.PipeLocated DESC";
                        break;

                    case "JL.ServicesLocated":
                        orderBy = "JL.ServicesLocated DESC";
                        break;

                    case "JL.CoInstalled":
                        orderBy = "JL.CoInstalled DESC";
                        break;

                    case "JL.BackfilledConcrete":
                        orderBy = "JL.BackfilledConcrete DESC";
                        break;

                    case "JL.BackfilledSoil":
                        orderBy = "JL.BackfilledSoil DESC";
                        break;

                    case "JL.Grouted":
                        orderBy = "JL.Grouted DESC";
                        break;

                    case "JL.Cored":
                        orderBy = "JL.Cored DESC";
                        break;

                    case "JL.Prepped":
                        orderBy = "JL.Prepped DESC";
                        break;

                    case "JL.Measured":
                        orderBy = "JL.Measured DESC";
                        break;

                    case "JL.InProcess":
                        orderBy = "JL.InProcess DESC";
                        break;

                    case "JL.InStock":
                        orderBy = "JL.InStock DESC";
                        break;

                    case "JL.Delivered":
                        orderBy = "JL.Delivered DESC";
                        break;

                    case "JL.PreVideo":
                        orderBy = "JL.PreVideo DESC";
                        break;

                    case "JL.LinerInstalled":
                        orderBy = "JL.LinerInstalled DESC";
                        break;

                    case "JL.FinalVideo":
                        orderBy = "JL.FinalVideo DESC";
                        break;

                    case "JL.CoCutDown":
                        orderBy = "JL.CoCutDown DESC";
                        break;

                    case "JL.FinalRestoration":
                        orderBy = "JL.FinalRestoration DESC";
                        break;

                    case "JL.NoticeDelivered":
                        orderBy = "JL.NoticeDelivered DESC";
                        break;

                    default:
                        orderBy = "MA.RecordID, JL.DetailID";
                        break;
                }
            }
            else
            {
                orderBy = ddlSortBy.SelectedValue;
            }

            return orderBy;
        }



        private void PostPageChanges()
        {
            JlinerNavigator jlinerNavigator = new JlinerNavigator(jlinerNavigatorTDS);

            // Update jlinernavigator rows
            foreach (GridViewRow row in grdJlinerNavigator.Rows)
            {
                string id_ = ((Label)row.FindControl("lblId_")).Text.Trim();
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                jlinerNavigator.Update(id_, selected);
            }

            jlinerNavigator.Data.AcceptChanges();

            // Store datasets
            Session["jlinerNavigatorTDS"] = jlinerNavigatorTDS;
        }



        private ArrayList GetJlinerIdArrayList()
        {
            ArrayList jlinerIdArrayList = new ArrayList();

            foreach (JlinerNavigatorTDS.JlinerNavigatorRow jlinerNavigatorRow in jlinerNavigatorTDS.JlinerNavigator)
            {
                if (jlinerNavigatorRow.Selected)
                {
                    jlinerIdArrayList.Add(new JlinerId(jlinerNavigatorRow.ID, jlinerNavigatorRow.RefID, jlinerNavigatorRow.COMPANY_ID));
                }
            }

            return jlinerIdArrayList;
        }

 

    }
}
