using System;
using System.Configuration;
using System.IO;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_download_attachment
    /// </summary>
    public partial class project_download_attachment : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            string originalFileName = Server.UrlDecode(Request.QueryString["original_filename"].ToString());
            string fileName = Server.UrlDecode(Request.QueryString["filename"].ToString());

            // Button download functionality
            if ((originalFileName != "") && (fileName != ""))
            {
                Session["blah"] = true;
                AppSettingsReader appSettingReader = new AppSettingsReader();
                string websitePath = appSettingReader.GetValue("WebsitePath", typeof(System.String)).ToString();

                string fullPath = string.Format("{0}\\Files\\LF_DGHOUGDH\\Library\\{1}", websitePath, fileName);
                FileInfo file = new FileInfo(fullPath);

                // Checking if file exists
                if (file.Exists)
                {
                    Response.Clear();
                    Response.AddHeader("Pragma", "public");
                    Response.AddHeader("Expires", "0");
                    Response.AddHeader("Cache-Control", "mustrevalidate, post-check=0, pre-check=0");
                    Response.AddHeader("Content-Type", "application/force-download");
                    Response.AddHeader("Content-Type", "application/octet-stream");
                    Response.AddHeader("Content-Type", "application/download");
                    Response.AddHeader("Content-Disposition", string.Format("attachment; filename=\"{0}\"", originalFileName));
                    Response.AddHeader("Content-Transfer-Encoding", "binary");
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.WriteFile(file.FullName);
                    Response.Flush();
                    Response.End();
                }
            }

            Response.Write("<script language='javascript'> {window.close();}</script>"); 
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> {window.close();}</script>");
        }



        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> {window.close();}</script>");
        }



    }
}