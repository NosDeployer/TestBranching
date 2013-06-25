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
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_associate_to_category
    /// </summary>
    public partial class project_associate_to_category : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected LibraryTDS libraryTDS;
        protected ProjectTDS projectTDS;






        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Store navigator state
                StoreNavigatorState();

                hdfUpdate.Value = "no";

                libraryTDS = new LibraryTDS();
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];

                Session["libraryTDS"] = libraryTDS;
                Session["lfsProjectTDS"] = projectTDS;

                ViewState["projectId"] = int.Parse(Request.QueryString["project_id"].ToString());
            }
            else
            {
                libraryTDS = (LibraryTDS)Session["libraryTDS"];
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
            }
        }                



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Dialog title
            mDialog2 dialog2 = (mDialog2)this.Master;
            dialog2.DialogTitle = "Associate To Category";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void btnAssociate_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                string associateCategory = tvCategoriesRoot.SelectedNode.Text;
                int libraryCategoryId = int.Parse(tvCategoriesRoot.SelectedNode.Value);

                if (projectTDS.LFS_PROJECT.Rows.Count > 0)
                {
                    Project project = new Project(projectTDS);
                    project.UpdateLibraryCategoriesId(int.Parse(ViewState["projectId"].ToString()), libraryCategoryId);
                    UpdateDatabase();
                }
                else
                {
                    ProjectGateway projectGatewayForLoad = new ProjectGateway(projectTDS);
                    projectGatewayForLoad.LoadByProjectId(int.Parse(ViewState["projectId"].ToString()));

                    Project project = new Project(projectTDS);
                    project.UpdateLibraryCategoriesId(int.Parse(ViewState["projectId"].ToString()), libraryCategoryId);
                    UpdateDatabase();
                }

                Response.Write("<script language='javascript'> {window.close();}</script>");
            }
        }



        protected void cvCategories_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (tvCategoriesRoot.SelectedValue != "" && tvCategoriesRoot.SelectedValue != "Trenchless University")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void StoreNavigatorState()
        {
            if (Session["navigatorState"] != null)
            {
                ViewState["navigatorState"] = Session["navigatorState"].ToString();
            }
            else
            {
                ViewState["navigatorState"] = "&search_projectnumber=&search_projectname=&search_client=&search_type=%&search_state=%";
            }
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void UpdateDatabase()
        {
            try
            {
                ProjectGateway projectGateway = new ProjectGateway(projectTDS);
                projectGateway.Update3();

                projectTDS.AcceptChanges();
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void RegisterClientScripts()
        {
            // Register client-side events
            HtmlGenericControl body = (HtmlGenericControl)Page.Master.FindControl("myBody");
            body.Attributes.Add("onunload", "OnUnload();");
            body.Attributes.Add("onload", "OnLoad();");
            
            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfUpdateId = '" + hdfUpdate.ClientID + "';";
            contentVariables += "var pnlCategoriesId = '" + pnlCategories.UniqueID + "' ;";
            contentVariables += "var tvCategoriesRootId = '" + tvCategoriesRoot.UniqueID + "' ;";
            
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./project_associate_to_category.js");
        }



        protected void PopulateNode(object sender, TreeNodeEventArgs e)
        {
            libraryTDS = (LibraryTDS)Session["libraryTDS"];
            LibraryCategoriesGateway libraryCategoriesGateway = new LibraryCategoriesGateway(libraryTDS);
            TreeNode node = e.Node;
            int companyId = Int32.Parse(Session["companyID"].ToString());

            if (e.Node.Depth == 0)
            {               
                libraryCategoriesGateway.LoadAllByParentId(0, companyId);
                foreach (LibraryTDS.LIBRARY_CATEGORIESRow rowLibraryCategories in (LibraryTDS.LIBRARY_CATEGORIESDataTable)libraryCategoriesGateway.Table)
                {
                    TreeNode newNode = new TreeNode(rowLibraryCategories.CATEGORY_NAME, rowLibraryCategories.LIBRARY_CATEGORIES_ID.ToString());
                    if (libraryCategoriesGateway.CountByParentId(rowLibraryCategories.LIBRARY_CATEGORIES_ID, companyId) > 0)
                    {
                        newNode.PopulateOnDemand = true;
                    }
                    node.ChildNodes.Add(newNode);
                }
            }
            else
            {
                int libraryCategoriesId = Int32.Parse(e.Node.Value);
                libraryCategoriesGateway.LoadAllByParentId(libraryCategoriesId, companyId); 

                foreach (LibraryTDS.LIBRARY_CATEGORIESRow rowLibraryCategories in (LibraryTDS.LIBRARY_CATEGORIESDataTable)libraryCategoriesGateway.Table)
                {
                    TreeNode newNode = new TreeNode(rowLibraryCategories.CATEGORY_NAME, rowLibraryCategories.LIBRARY_CATEGORIES_ID.ToString());
                    if (libraryCategoriesGateway.CountByParentId(rowLibraryCategories.LIBRARY_CATEGORIES_ID, companyId) > 0)
                    {
                        newNode.PopulateOnDemand = true;
                    }
                    node.ChildNodes.Add(newNode);
                }
            }

            Session["libraryTDS"] = libraryTDS;
        }



    }
}
