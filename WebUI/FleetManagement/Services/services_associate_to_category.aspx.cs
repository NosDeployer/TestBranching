using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.FleetManagement.Services;
using LiquiForce.LFSLive.BL.FleetManagement.Services;
using System.Web.UI.HtmlControls;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Services
{
    /// <summary>
    /// services_associate_to_category
    /// </summary>
    public partial class services_associate_to_category : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ServiceInformationTDS serviceInformationTDS;
        protected LibraryTDS libraryTDSForServices;






        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                hdfUpdate.Value = "no";

                libraryTDSForServices = new LibraryTDS();
                serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDS"];

                Session["libraryTDSForServices"] = libraryTDSForServices;
                
                ViewState["serviceId"] = int.Parse(Request.QueryString["service_id"].ToString());
            }
            else
            {
                libraryTDSForServices = (LibraryTDS)Session["libraryTDSForServices"];
                serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDS"];
            }
        }



        protected void btnAssociate_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                string associateCategory = tvCategoriesRoot.SelectedNode.Text;
                int libraryCategoryId = int.Parse(tvCategoriesRoot.SelectedNode.Value);

                ServiceInformationBasicInformation serviceInformationBasicInformation= new ServiceInformationBasicInformation(serviceInformationTDS);
                serviceInformationBasicInformation.UpdateLibraryCategoriesId(int.Parse(ViewState["serviceId"].ToString()), libraryCategoryId);
                Session["serviceInformationTDS"] = serviceInformationTDS;
                
                Response.Write("<script language='javascript'> {window.close();}</script>");
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./services_associate_to_category.js");
        }



        protected void PopulateNode(object sender, TreeNodeEventArgs e)
        {
            int companyId = Int32.Parse(Session["companyID"].ToString());
            libraryTDSForServices = (LibraryTDS)Session["libraryTDSForServices"];
            LibraryCategoriesGateway libraryCategoriesGateway = new LibraryCategoriesGateway(libraryTDSForServices);
            TreeNode node = e.Node;

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

            Session["libraryTDSForServices"] = libraryTDSForServices;
        }



    }
}