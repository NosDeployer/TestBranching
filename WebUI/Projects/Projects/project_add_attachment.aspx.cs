using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Brettle.Web.NeatUpload;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.BL.RAF;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_add_attachment
    /// </summary>
    public partial class project_add_attachment : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectTDS projectTDS;
        protected LibraryTDS libraryTDS;
        protected ProjectNavigatorTDS projectNavigatorTDS;
        protected ProjectNavigatorTDS.ProjectNotesDataTable projectNotes;
               





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

                hdfUpdate.Value = "yes";
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();

                tbxDescription.Text = Server.UrlDecode(Request.QueryString["subject"].ToString());
                ViewState["refId"] = Request.QueryString["refId"].ToString();
                ViewState["projectId"] = Request.QueryString["project_id"].ToString();
                ViewState["libraryCategoriesId"] = Request.QueryString["library_categories_id"].ToString();

                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                projectNavigatorTDS = (ProjectNavigatorTDS)Session["projectNavigatorTDS"];
                projectNotes = (ProjectNavigatorTDS.ProjectNotesDataTable)Session["projectNotes"];
                
                if (Session["lfsLibraryTDS"] != null)
                {
                    libraryTDS = (LibraryTDS)Session["lfsLibraryTDS"];
                }
                else
                {
                    libraryTDS = new LibraryTDS();
                }

                Session["lfsProjectTDS"] = projectTDS;       
            }
            else
            {
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                projectNavigatorTDS = (ProjectNavigatorTDS)Session["projectNavigatorTDS"];
                projectNotes = (ProjectNavigatorTDS.ProjectNotesDataTable)Session["projectNotes"];
                
                if (Session["lfsLibraryTDS"] != null)
                {
                    libraryTDS = (LibraryTDS)Session["lfsLibraryTDS"];
                }
                else
                {
                    libraryTDS = new LibraryTDS();
                }
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Dialog title
            mDialog2 dialog2 = (mDialog2)this.Master;
            dialog2.DialogTitle = "Add Attachment";
        }



        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            if (nuifAttachment.HasFile)
            {
                int projectId = Convert.ToInt32(ViewState["projectId"].ToString());
                int refId = Convert.ToInt32(ViewState["refId"].ToString());

                //--- Process the upload request
                int companyId = Int32.Parse(Session["companyID"].ToString());
                ProcessUpload2(projectId, refId, companyId);

                ViewState["update"] = "yes";

                Response.Write("<script language='javascript'> {window.close();}</script>");
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

                // Save notes
                int companyId = Int32.Parse(Session["companyID"].ToString());
                ProjectNavigatorGateway projectNavigatorGateway = new ProjectNavigatorGateway(projectNavigatorTDS);

                ProjectNavigatorProjectNotes projectNavigatorProjectNotes = new ProjectNavigatorProjectNotes(projectNavigatorTDS);
                projectNavigatorProjectNotes.Save(companyId);

                Session["lfsProjectTDS"] = projectTDS;
                Session["projectNavigatorTDS"] = projectNavigatorTDS;
                Session["lfsLibraryTDS"] = libraryTDS;
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }

                

        private void ProcessUpload2(int projectId, int refId, int companyId)
        {
            LibraryFilesGateway libraryFilesGateway = new LibraryFilesGateway();

            try
            {
                //... Set the default path to store uploaded files.
                AppSettingsReader appSettingReader = new AppSettingsReader();
                string websitePath = appSettingReader.GetValue("WebsitePath", typeof(System.String)).ToString();

                string filename = "";

                //... Get the extension of file
                string[] shortFilename = nuifAttachment.FileName.Split(new char[] { '.' });
                string ext = "." + shortFilename[shortFilename.Length - 1];

                bool exit = false;

                while (!exit)
                {
                    StringBuilder builder = new StringBuilder();
                    Random rand = new Random();
                    char ch;

                    for (int i = 0; i < 8; i++)
                    {
                        ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rand.NextDouble() + 65)));
                        builder.Append(ch);
                    }

                    filename = builder.ToString();
                    filename = filename + ext;

                    libraryFilesGateway.LoadByFileName(filename, companyId);

                    if (libraryFilesGateway.Table.Rows.Count > 0)
                    {
                        exit = false;
                    }
                    else
                    {
                        exit = true;
                    }
                }

                string pathFull = websitePath + "\\Files\\LF_DGHOUGDH\\Library\\";

                //... Save the file
                nuifAttachment.MoveTo(Path.Combine(pathFull, filename), MoveToOptions.Overwrite);

                LibraryFiles libraryFiles = new LibraryFiles(libraryTDS);
                libraryFiles.Insert(filename, tbxDescription.Text, nuifAttachment.FileName, null, Convert.ToInt32(ViewState["libraryCategoriesId"]), Convert.ToInt32(hdfLoginId.Value), int.Parse(Session["companyID"].ToString()), nuifAttachment.FileContent.Length.ToString()); //Note: COMPANY_ID 

                ProjectNavigatorProjectNotes model = new ProjectNavigatorProjectNotes(projectNavigatorTDS);
                model.UpdateLibraryFilesId(projectId, refId, 0, nuifAttachment.FileName, filename);

                Session["lfsProjectTDS"] = projectTDS;
                Session["lfsLibraryTDS"] = libraryTDS;
                Session["projectNavigatorTDS"] = projectNavigatorTDS;
                Session["fromAttachment"] = "yes";
            }
            catch (Exception ex)
            { 
            }
        }



        private void RegisterClientScripts()
        {
            // Register client-side events
            HtmlGenericControl body = (HtmlGenericControl)Page.Master.FindControl("myBody");
            body.Attributes.Add("onunload", "OnUnload();");
                       
            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfUpdateId = '" + hdfUpdate.ClientID + "';";
            contentVariables += "var hdfLoginIdId = '" + hdfLoginId.ClientID + "';";
                                    
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./project_add_attachment.js");
        }



    }
}