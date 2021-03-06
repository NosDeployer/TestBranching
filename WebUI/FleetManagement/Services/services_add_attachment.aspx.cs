﻿using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Brettle.Web.NeatUpload;
using LiquiForce.LFSLive.BL.FleetManagement.Services;
using LiquiForce.LFSLive.BL.RAF;
using LiquiForce.LFSLive.DA.FleetManagement.Services;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Services
{
    /// <summary>
    /// services_add_attachment
    /// </summary>
    public partial class services_add_attachment : System.Web.UI.Page
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
                hdfUpdate.Value = "yes";
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();

                tbxDescription.Text = Server.UrlDecode(Request.QueryString["subject"].ToString());
                ViewState["refId"] = Request.QueryString["refId"].ToString();
                
                try
                {
                    ViewState["refIdCost"] = Request.QueryString["refIdCost"].ToString();
                }
                catch
                {
                    ViewState["refIdCost"] = 0;
                }

                ViewState["serviceId"] = Request.QueryString["service_id"].ToString();
                ViewState["libraryCategoriesId"] = Request.QueryString["library_categories_id"].ToString();

                if (Request.QueryString["source_page"] == "services_edit.aspx")
                {
                    serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDS"];
                }
                else
                {
                    serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDSForManagerTool"];
                }
                 
                if (Session["libraryTDSForServices"] != null)
                {
                    libraryTDSForServices = (LibraryTDS)Session["libraryTDSForServices"];
                }
                else
                {
                    libraryTDSForServices = new LibraryTDS();
                }                
            }
            else
            {
                if (Request.QueryString["source_page"] == "services_edit.aspx")
                {
                    serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDS"];
                }
                else
                {
                    serviceInformationTDS = (ServiceInformationTDS)Session["serviceInformationTDSForManagerTool"];
                }
                
                if (Session["libraryTDSForServices"] != null)
                {
                    libraryTDSForServices = (LibraryTDS)Session["libraryTDSForServices"];
                }
                else
                {
                    libraryTDSForServices = new LibraryTDS();
                }
            }
        }        



        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            if (nuifAttachment.HasFile)
            {
                int serviceId = Convert.ToInt32(ViewState["serviceId"].ToString());
                int refId = Convert.ToInt32(ViewState["refId"].ToString());

                //--- Process the upload request
                int companyId = Int32.Parse(Session["companyID"].ToString());
                ProcessUpload2(serviceId, refId, companyId);

                ViewState["update"] = "yes";

                Response.Write("<script language='javascript'> {window.close();}</script>");
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Dialog title
            mDialog2 dialog2 = (mDialog2)this.Master;
            dialog2.DialogTitle = "Add Attachment";
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void ProcessUpload2(int serviceId, int refId, int companyId)
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

                LibraryFiles libraryFiles = new LibraryFiles(libraryTDSForServices);
                libraryFiles.Insert(filename, tbxDescription.Text, nuifAttachment.FileName, null, Convert.ToInt32(ViewState["libraryCategoriesId"]), Convert.ToInt32(hdfLoginId.Value), int.Parse(Session["companyID"].ToString()), nuifAttachment.FileContent.Length.ToString()); //Note: COMPANY_ID 

                ServiceInformationServiceNote model = new ServiceInformationServiceNote(serviceInformationTDS);
                model.UpdateLibraryFilesId(serviceId, refId, 0, nuifAttachment.FileName, filename);

                int refIdCost = Convert.ToInt32(ViewState["refIdCost"].ToString());
                if (refIdCost > 0)
                {
                    ServiceInformationServiceCost modelCost = new ServiceInformationServiceCost(serviceInformationTDS);
                    modelCost.UpdateLibraryFilesId(serviceId, refIdCost, nuifAttachment.FileName, filename);
                }

                Session["libraryTDSForServices"] = libraryTDSForServices;

                if (Request.QueryString["source_page"] == "services_edit.aspx")
                {
                    Session["serviceInformationTDS"] = serviceInformationTDS;
                }
                else
                {
                    Session["serviceInformationTDSForManagerTool"] = serviceInformationTDS;
                }
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./services_add_attachment.js");
        }



    }
}