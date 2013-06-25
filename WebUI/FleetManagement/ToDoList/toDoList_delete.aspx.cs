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
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;
using LiquiForce.LFSLive.BL.FleetManagement.ToDoList;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.ToDoList
{
    /// <summary>
    /// toDoList_delete
    /// </summary>
    public partial class toDoList_delete : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //
        protected ToDoListInformationTDS toDolistInformationTDS;
        protected ToDoListTDS toDoListTDS;





                
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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_TODOLIST_VIEW"]) && Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_TODOLIST_DELETE"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["toDo_id"] == null) || ((string)Request.QueryString["dashboard"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in toDoList_delete.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfToDoListId.Value = Request.QueryString["toDo_id"].ToString();
                hdfDashboard.Value = Request.QueryString["dashboard"].ToString();
                hdfFmType.Value = "ToDoList";

                // If comming from 
                // ... toDoList_navigator2.aspx
                if (Request.QueryString["source_page"] == "toDoList_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    toDolistInformationTDS = new ToDoListInformationTDS();
                    toDoListTDS = new ToDoListTDS();

                    int toDolistId = Int32.Parse(hdfToDoListId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    ToDoListInformationBasicInformation toDolistInformationBasicInformation = new ToDoListInformationBasicInformation(toDolistInformationTDS);
                    toDolistInformationBasicInformation.LoadAllByToDoId(toDolistId, companyId);

                    ToDoListInformationActivityInformation toDoListInformationActivityInformation = new ToDoListInformationActivityInformation(toDolistInformationTDS);
                    toDoListInformationActivityInformation.LoadAllByToDoId(toDolistId, companyId);

                    // Store dataset
                    Session["toDolistInformationTDS"] = toDolistInformationTDS;
                    Session["toDoListTDS"] = toDoListTDS;
                }

                // ... toDoList_summary.aspx
                if (Request.QueryString["source_page"] == "toDoList_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    toDoListTDS = (ToDoListTDS)Session["toDoListTDS"];
                    toDolistInformationTDS = (ToDoListInformationTDS)Session["toDolistInformationTDS"];
                }
            }
            else
            {
                // Restore datasets
                toDoListTDS = (ToDoListTDS)Session["toDoListTDS"];
                toDolistInformationTDS = (ToDoListInformationTDS)Session["toDolistInformationTDS"];
            }
        }        



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "FleetManagement";
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mDelete":
                    this.Delete();
                    break;

                case "mCancel":
                    string url = "";
                    if (Request.QueryString["source_page"] == "toDoList_navigator2.aspx")
                    {
                        url = "./toDoList_navigator2.aspx?source_page=toDoList_delete.aspx&toDo_id=" + hdfToDoListId.Value + GetNavigatorState() + "&update=yes";
                    }

                    if (Request.QueryString["source_page"] == "toDoList_summary.aspx")
                    {
                        int activeTab = 0; // load active tab
                        url = "./toDoList_summary.aspx?source_page=toDoList_delete.aspx&dashboard=" + hdfDashboard.Value + "&toDo_id=" + hdfToDoListId.Value + GetNavigatorState() + "&update=yes" + "&active_tab=" + activeTab;
                    }
                    Response.Redirect(url);
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./toDoList_delete.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_state=" + Request.QueryString["search_state"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void Delete()
        {
            Page.Validate();

            if (Page.IsValid)
            {
                // Delete all data for toDolist
                int toDolistId = Int32.Parse(hdfToDoListId.Value);

                ToDoListInformationBasicInformation toDolistInformationBasicInformation = new ToDoListInformationBasicInformation(toDolistInformationTDS);
                toDolistInformationBasicInformation.Delete(toDolistId);

                ToDoListInformationActivityInformation toDoListInformationActivityInformation = new ToDoListInformationActivityInformation(toDolistInformationTDS);
                toDoListInformationActivityInformation.DeleteAll(toDolistId);

                // Update databse
                UpdateDatabase();

                // Store datasets
                Session["toDolistInformationTDS"] = toDolistInformationTDS;

                // Redirect
                string url = "";

                if (Request.QueryString["dashboard"] == "True")
                {
                    url = "./../../FleetManagement/Dashboard/dashboard_login.aspx?source_page=out";
                }
                else
                {
                    url = "./toDoList_navigator2.aspx?source_page=toDoList_delete.aspx&toDo_id=" + hdfToDoListId.Value + GetNavigatorState() + "&update=yes";
                }
                Response.Redirect(url);
            }
        }



        private void UpdateDatabase()
        {
            // Get ids
            int toDoId = Int32.Parse(hdfToDoListId.Value);
            string toDolistType = hdfFmType.Value;
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // Delete
            DB.Open();
            DB.BeginTransaction();
            try
            {
                ToDoListToDoListActivity toDoListToDoListActivity = new ToDoListToDoListActivity(toDolistInformationTDS);
                toDoListToDoListActivity.DeleteAllDirect(toDoId, companyId);

                ToDoListToDoList toDoList = new ToDoListToDoList(null);
                toDoList.DeleteDirect(toDoId, companyId);

                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



    }
}