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
using System.IO;

namespace LiquiForce.LFSLive.WebUI
{
    public partial class new_viewer4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //--- Validate query string
            if ((Request.QueryString["file_name"] == null) || (Request.QueryString["report_name"] == null) || (Request.QueryString["report_format"] == null))
            {
                Response.Redirect("./error_page.aspx?error=" + "Invalid query string in new_viewer4.aspx");
            }

            //--- Preview report
            string fileName = Server.UrlDecode(Request.QueryString["file_name"].ToString());

            Response.ClearContent();
            Response.ClearHeaders();
            switch (Request.QueryString["report_format"])
            {
                case "pdf":
                    //Response.AppendHeader("Content-Type", "application/pdf");
                    //Response.AppendHeader("Content-Type", "application/force-download");
                    //Response.AppendHeader("Content-Type", "application/octet-stream");
                    //Response.AppendHeader("Content-Type", "application/download");
                    //Response.AppendHeader("content-disposition", "attachment; filename=" + Request.QueryString["report_name"] + ".pdf");
                    FileInfo file = new FileInfo(fileName);
                    Response.AddHeader("Pragma", "public");
                    Response.AddHeader("Expires", "0");
                    Response.AddHeader("Cache-Control", "mustrevalidate, post-check=0, pre-check=0");
                    Response.AddHeader("Content-Type", "application/force-download");
                    Response.AddHeader("Content-Type", "application/octet-stream");
                    Response.AddHeader("Content-Type", "application/download");
                    Response.AddHeader("Content-Disposition", string.Format("attachment; filename=\"{0}\"", Request.QueryString["report_name"] + ".pdf"));
                    Response.AddHeader("Content-Transfer-Encoding", "binary");
                    Response.AddHeader("Content-Length", file.Length.ToString());

                    //Response.AppendHeader("Content-Disposition", "filename=" + Request.QueryString["report_name"] + ".pdf");
                    break;

                case "excel":
                    System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
                    Response.AppendHeader("Content-Type", "application/vnd.ms-excel");
                    Response.AppendHeader("Content-Length", fi.Length.ToString());
                    Response.AppendHeader("Content-Disposition", "filename=" + Request.QueryString["report_name"] + ".xls");
                    break;

                case "word":
                    break;
            }
            Response.WriteFile(fileName);
            Response.Flush();
            Response.Close();

            System.IO.File.Delete(fileName);

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