using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.FleetManagement.Units;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Units
{
    /// <summary>
    /// units_associate_to_category
    /// </summary>
    public partial class units_associate_to_category : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected UnitInformationTDS unitInformationTDS;
        protected LibraryTDS libraryTDSForUnits;






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

                libraryTDSForUnits = new LibraryTDS();
                unitInformationTDS = (UnitInformationTDS)Session["unitInformationTDS"];

                Session["libraryTDSForUnits"] = libraryTDSForUnits;

                ViewState["unitId"] = int.Parse(Request.QueryString["unit_id"].ToString());
            }
            else
            {
                libraryTDSForUnits = (LibraryTDS)Session["libraryTDSForUnits"];
                unitInformationTDS = (UnitInformationTDS)Session["unitInformationTDS"];
            }
        }



        protected void btnAssociate_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                string associateCategory = tvCategoriesRoot.SelectedNode.Text;
                int libraryCategoryId = int.Parse(tvCategoriesRoot.SelectedNode.Value);

                UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
                unitInformationUnitDetails.UpdateLibraryCategoriesId(int.Parse(ViewState["unitId"].ToString()), libraryCategoryId);
                Session["unitInformationTDS"] = unitInformationTDS;

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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./units_associate_to_category.js");
        }



        protected void PopulateNode(object sender, TreeNodeEventArgs e)
        {
            libraryTDSForUnits = (LibraryTDS)Session["libraryTDSForUnits"];
            LibraryCategoriesGateway libraryCategoriesGateway = new LibraryCategoriesGateway(libraryTDSForUnits);
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

            Session["libraryTDSForUnits"] = libraryTDSForUnits;
        }



    }
}