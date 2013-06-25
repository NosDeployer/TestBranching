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
    public partial class new_viewer3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //--- Validate query string
            if ((Request.QueryString["file_name"] == null) || (Request.QueryString["report_name"] == null) || (Request.QueryString["report_format"] == null))
            {
                Response.Redirect("./error_page.aspx?error=" + "Invalid query string in new_viewer3.aspx");
            }

            //--- File Info
            string fileName = Request.QueryString["file_name"];
            System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
            string reportName = Request.QueryString["report_name"];

            Response.ClearContent();
            Response.ClearHeaders();
            switch (Request.QueryString["report_format"])
            {
                case "pdf":
                    Response.AppendHeader("Content-Type", "application/pdf");
                    Response.AppendHeader("Content-Length", fi.Length.ToString());
                    //Response.AppendHeader("Content-Disposition", string.Format("attachment; filename=\"{0}\"", reportName + ".pdf"));
                    Response.AppendHeader("Content-Disposition", string.Format("filename=\"{0}\"", reportName + ".pdf"));
                    break;

                case "excel":
                    Response.AppendHeader("Content-Type", "application/vnd.ms-excel");
                    Response.AppendHeader("Content-Length", fi.Length.ToString());
                    Response.AppendHeader("Content-Disposition", "filename=" + reportName + ".xls");
                    break;

                case "word":
                    break;
            }
            Response.WriteFile(fileName);
            Response.Flush();
            Response.Close();

            System.IO.File.Delete(fileName);
        }
    }
}
