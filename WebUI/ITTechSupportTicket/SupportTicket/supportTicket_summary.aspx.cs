using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket;
using LiquiForce.LFSLive.DA.Resources.Employees;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// supportTicket_summary
    /// </summary>
    public partial class supportTicket_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected SupportTicketInformationTDS supportTicketInformationTDS;        
        protected SupportTicketInformationTDS.ActivityInformationDataTable activityInformation;
        
        

        
        
                      
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
                if (!(Convert.ToBoolean(Session["sgLFS_ITTST_SUPPORTTICKET_ADMIN"])))
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_ITTST_SUPPORTTICKET_VIEW"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["supportTicket_id"] == null) || ((string)Request.QueryString["dashboard"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in supportTicket_summary.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfSupportTicketId.Value = Request.QueryString["supportTicket_id"].ToString();
                hdfDashboard.Value = Request.QueryString["dashboard"].ToString();

                // If coming from 
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int currentSupportTicketId = Int32.Parse(hdfSupportTicketId.Value.ToString());

                Session.Remove("activityInformationDummyForST");

                // ... supportTicket_navigator2.aspx, supportTicket_add.aspx, wucMySupportTicket.ascx, wucSupportTicketAssignedToMe.ascx
                if ((Request.QueryString["source_page"] == "supportTicket_navigator2.aspx") || (Request.QueryString["source_page"] == "supportTicket_add.aspx") || (Request.QueryString["source_page"] == "wucMySupportTicket.ascx") || (Request.QueryString["source_page"] == "wucSupportTicketAssignedToMe.ascx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    supportTicketInformationTDS = new SupportTicketInformationTDS();                    
                    activityInformation = new SupportTicketInformationTDS.ActivityInformationDataTable();

                    SupportTicketInformationBasicInformation supportTicketInformationBasicInformation = new SupportTicketInformationBasicInformation(supportTicketInformationTDS);
                    supportTicketInformationBasicInformation.LoadAllBySupportTicketId(currentSupportTicketId, companyId);

                    SupportTicketInformationActivityInformation supportTicketInformationActivityInformation = new SupportTicketInformationActivityInformation(supportTicketInformationTDS);
                    supportTicketInformationActivityInformation.LoadAllBySupportTicketId(currentSupportTicketId, companyId);
                                     
                    // Store dataset
                    Session["supportTicketInformationTDS"] = supportTicketInformationTDS;
                    Session["activityInformationForST"] = activityInformation;
                }

                // ... supportTicket_delete.aspx or supportTicket_edit.aspx, supportTicket_activity.aspx
                if ((Request.QueryString["source_page"] == "supportTicket_delete.aspx") || (Request.QueryString["source_page"] == "supportTicket_edit.aspx") || (Request.QueryString["source_page"] == "supportTicket_activity.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    supportTicketInformationTDS = (SupportTicketInformationTDS)Session["supportTicketInformationTDS"];
                    activityInformation = (SupportTicketInformationTDS.ActivityInformationDataTable)Session["activityInformationForST"];                    
                }                

                // Prepare initial data
                // ... for subject
                SupportTicketInformationBasicInformationGateway supportTicketInformationBasicInformationGateway = new SupportTicketInformationBasicInformationGateway();
                supportTicketInformationBasicInformationGateway.LoadAllBySupportTicketId(currentSupportTicketId, companyId);
                lblTitleSubjectName.Text = " " + supportTicketInformationBasicInformationGateway.GetSubject(currentSupportTicketId);

                // ... Data for current to do list               
                LoadSupportTicketData(currentSupportTicketId, companyId);                
            }
            else
            {
                // Restore datasets
                supportTicketInformationTDS = (SupportTicketInformationTDS)Session["supportTicketInformationTDS"];
                activityInformation = (SupportTicketInformationTDS.ActivityInformationDataTable)Session["activityInformationForST"];
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "ITTechSupportTicket";

            // Validate top menu, if completed no more actions could be done.          
            if (hdfState.Value == "Completed")
            {
                tkrmTop.Items[1].Visible = false;
            }            
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //    
        
        protected void grdSupportTicket_DataBound(object sender, EventArgs e)
        {
            AddToDoNewEmptyFix(grdSupportTicket);
        }



        protected void grdSupportTicket_RowDataBound(object sender, GridViewRowEventArgs e)
        {          
            // Control normal rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {               
                // Change label text
                string type_ = ((Label)e.Row.FindControl("lblType")).Text;
                if (type_ == "AssignUser")
                {
                    ((Label)e.Row.FindControl("lblUser")).Text = "Assign To";
                }

                if (type_ == "AddComment")
                {
                    ((Label)e.Row.FindControl("lblUser")).Text = "Comment Added By";
                }

                if (type_ == "CloseTicket")
                {
                    ((Label)e.Row.FindControl("lblUser")).Text = "Support Ticket Completed By";
                }

                if (type_ == "OnHold")
                {
                    ((Label)e.Row.FindControl("lblUser")).Text = "On Hold By";
                }
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
                    //url = "./supportTicket_edit.aspx?source_page=supportTicket_summary.aspx&supportTicket_id=" + hdfSupportTicketId.Value + "&dashboard=" + hdfDashboard.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mAssign":
                    url = "./supportTicket_activity.aspx?source_page=supportTicket_summary.aspx&supportTicket_id=" + hdfSupportTicketId.Value + "&action=Assign To User" + "&dashboard="+ hdfDashboard.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mAssignOwner":
                    url = "./supportTicket_activity.aspx?source_page=supportTicket_summary.aspx&supportTicket_id=" + hdfSupportTicketId.Value + "&action=Assign To Owner" + "&dashboard=" + hdfDashboard.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mComment":
                    url = "./supportTicket_activity.aspx?source_page=supportTicket_summary.aspx&supportTicket_id=" + hdfSupportTicketId.Value + "&action=Add Comment" + "&dashboard=" + hdfDashboard.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mPutOnHold":
                    url = "./supportTicket_activity.aspx?source_page=supportTicket_summary.aspx&supportTicket_id=" + hdfSupportTicketId.Value + "&action=Put On Hold" + "&dashboard=" + hdfDashboard.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mComplete":
                    url = "./supportTicket_activity.aspx?source_page=supportTicket_summary.aspx&supportTicket_id=" + hdfSupportTicketId.Value + "&action=Complete" + "&dashboard=" + hdfDashboard.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mDelete":
                    url = "./supportTicket_delete.aspx?source_page=supportTicket_summary.aspx&supportTicket_id=" + hdfSupportTicketId.Value + "&dashboard=no" + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mLastSearch":
                    if (Request.QueryString["dashboard"] == "True")
                    {
                        url = "./../../ITTechSupportTicket/Dashboard/dashboard_login.aspx?source_page=out";
                    }
                    else
                    {
                        if (Request.QueryString["source_page"] == "supportTicket_add.aspx")
                        {
                            url = "./supportTicket_navigator.aspx?source_page=out";
                        }

                        if (Request.QueryString["source_page"] == "supportTicket_navigator2.aspx")
                        {
                            url = "./supportTicket_navigator2.aspx?source_page=supportTicket_summary.aspx" + GetNavigatorState() + "&update=yes";
                        }
                        
                        if (Request.QueryString["source_page"] == "supportTicket_edit.aspx")
                        {
                            url = "./supportTicket_navigator2.aspx?source_page=supportTicket_summary.aspx" + GetNavigatorState() + "&update=yes";
                        }

                        if (Request.QueryString["source_page"] == "supportTicket_activity.aspx")
                        {
                            url = "./supportTicket_navigator2.aspx?source_page=supportTicket_summary.aspx" + GetNavigatorState() + "&update=yes";
                        }
                    }
                                        
                    break;

                case "mPrevious":
                    if ((Request.QueryString["source_page"] != "supportTicket_add.aspx") && (Request.QueryString["source_page"] != "wucMySupportTicket.ascx") && (Request.QueryString["source_page"] != "wucSupportTicketAssignedToMe.ascx"))
                    {
                        if ((SupportTicketNavigatorTDS)Session["supportTicketNavigatorTDS"] != null)
                        {
                            // Get previous record
                            int previousId = SupportTicketNavigator.GetPreviousId((SupportTicketNavigatorTDS)Session["supportTicketNavigatorTDS"], Int32.Parse(hdfSupportTicketId.Value));
                            if (previousId != Int32.Parse(hdfSupportTicketId.Value))
                            {
                                // Redirect
                                url = "./supportTicket_summary.aspx?source_page=supportTicket_navigator2.aspx&dashboard=" + hdfDashboard.Value + "&supportTicket_id=" + previousId.ToString() + GetNavigatorState() + "&update=yes";
                            }
                        }
                    }
                    break;

                case "mNext":
                    if ((Request.QueryString["source_page"] != "supportTicket_add.aspx") && (Request.QueryString["source_page"] != "wucMySupportTicket.ascx") && (Request.QueryString["source_page"] != "wucSupportTicketAssignedToMe.ascx"))
                    {
                        if ((SupportTicketNavigatorTDS)Session["supportTicketNavigatorTDS"] != null)
                        {
                            // Get next record
                            int nextId = SupportTicketNavigator.GetNextId((SupportTicketNavigatorTDS)Session["supportTicketNavigatorTDS"], Int32.Parse(hdfSupportTicketId.Value));
                            if (nextId != Int32.Parse(hdfSupportTicketId.Value))
                            {
                                // Redirect
                                url = "./supportTicket_summary.aspx?source_page=supportTicket_navigator2.aspx&dashboard=" + hdfDashboard.Value + "&supportTicket_id=" + nextId.ToString() + GetNavigatorState() + "&update=yes";
                            }
                        }
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
                case "mSearch":
                    url = "./supportTicket_navigator.aspx?source_page=lm";
                    break;                
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./supportTicket_summary.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_state=" + Request.QueryString["search_state"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }

        

        #region Load Functions

        private void LoadSupportTicketData(int supportTicketId, int companyId)
        {
            // Load Data
            LoadData(supportTicketId);
            LoadActivityData(supportTicketId, companyId);
        }



        private void LoadData(int supportTicketId)
        {
            SupportTicketInformationBasicInformationGateway supportTicketInformationBasicInformationGateway = new SupportTicketInformationBasicInformationGateway(supportTicketInformationTDS);
            if (supportTicketInformationBasicInformationGateway.Table.Rows.Count > 0)
            {
                // Load to do Details
                int companyId = Int32.Parse(hdfCompanyId.Value);

                int createdById = supportTicketInformationBasicInformationGateway.GetCreatedByID(supportTicketId);
                EmployeeGateway employeeGateway = new EmployeeGateway();
                employeeGateway.LoadByEmployeeId(createdById);
                tbxCreatedBy.Text = employeeGateway.GetFullName(createdById);

                tbxCreationDate.Text = supportTicketInformationBasicInformationGateway.GetCreationDate(supportTicketId).ToString();
                tbxState.Text = supportTicketInformationBasicInformationGateway.GetState(supportTicketId);
                tbxCategoryName.Text = supportTicketInformationBasicInformationGateway.GetCategoryName(supportTicketId);

                if (supportTicketInformationBasicInformationGateway.GetDueDate(supportTicketId).HasValue)
                {
                    DateTime dueDateValue = (DateTime)supportTicketInformationBasicInformationGateway.GetDueDate(supportTicketId);
                    tbxDueDate.Text = dueDateValue.Month.ToString() + "/" + dueDateValue.Day.ToString() + "/" + dueDateValue.Year.ToString();
                }                              

                hdfState.Value = supportTicketInformationBasicInformationGateway.GetState(supportTicketId);
            }
        }



        private void LoadActivityData(int supportTicketId, int companyId)
        {
            SupportTicketInformationActivityInformation supportTicketInformationActivityInformation = new SupportTicketInformationActivityInformation();
            supportTicketInformationActivityInformation.LoadAllBySupportTicketId(supportTicketId, companyId);

            int lastRefId = supportTicketInformationActivityInformation.GetLastAssignedUserRefId();

            SupportTicketInformationActivityInformationGateway supportTicketInformationActivityInformationGateway = new SupportTicketInformationActivityInformationGateway(supportTicketInformationActivityInformation.Data);
                        
            if (supportTicketInformationActivityInformationGateway.Table.Rows.Count > 0)
            {
                // For last assigned user
                tbxAssignedUser.Text = supportTicketInformationActivityInformationGateway.GetEmployeeFullName(supportTicketId, lastRefId);
                hdfAssignedUser.Value = supportTicketInformationActivityInformationGateway.GetEmployeeID(supportTicketId, lastRefId).ToString();
            }
        }



        #endregion
        



        protected void AddToDoNewEmptyFix(GridView grdView)
        {
            if (grdSupportTicket.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                SupportTicketInformationTDS.ActivityInformationDataTable dt = new SupportTicketInformationTDS.ActivityInformationDataTable();
                dt.AddActivityInformationRow(-1, -1, "", DateTime.Now, -1, "", false, companyId, false, "", false);
                Session["activityInformationDummyForST"] = dt;
                grdSupportTicket.DataBind();
            }

            // normally executes at all postbacks
            if (grdSupportTicket.Rows.Count == 1)
            {
                SupportTicketInformationTDS.ActivityInformationDataTable dt = (SupportTicketInformationTDS.ActivityInformationDataTable)Session["activityInformationDummyForST"];
                if (dt != null)
                {
                    grdSupportTicket.Rows[0].Visible = false;
                    grdSupportTicket.Rows[0].Controls.Clear();

                    Session.Remove("activityInformationDummyForST");
                }
            }
        }          
             
                   
                
        public SupportTicketInformationTDS.ActivityInformationDataTable GetToDoNew()
        {
            activityInformation = (SupportTicketInformationTDS.ActivityInformationDataTable)Session["activityInformationDummyForST"];

            if (activityInformation == null)
            {
                activityInformation = ((SupportTicketInformationTDS)Session["supportTicketInformationTDS"]).ActivityInformation;
            }

            return activityInformation;
        }



    }
}