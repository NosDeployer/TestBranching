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

namespace LiquiForce.LFSLive.WebUI.CWP.FullLengthLining
{
    /// <summary>
    /// fl_cxi_removed_report
    /// </summary>
    public partial class fl_cxi_removed_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Access to this page
                if (!Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();

                // Register delegates
                this.RegisterDelegates();
            }
            else
            {
                // Register delegates
                this.RegisterDelegates();
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set title & criteria width
            mReport1 master = (mReport1)this.Master;
            master.Title = "CXI Removed Report";

            master.ShowTitle = true;
            master.ShowToolBar = true;
            master.ShowCriteria = true;
            master.CriteriaWidth = "200px";

            if (!IsPostBack)
            {
                master.PrintDirectly = false;
                master.ExportDirectly = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterDelegates()
        {
            mReport1 master = (mReport1)this.Master;
            master.GenerateMethod = new mReport1.ReportMethod(Generate);
        }



        private void Generate()
        {
            mReport1 master = (mReport1)this.Master;

            // Get Data
            LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlCXIRemovedReport flCXIRemovedReport = new LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlCXIRemovedReport();
            int companyId = Int32.Parse(hdfCompanyId.Value);

            if (ddlCountry.SelectedValue == "(All)")
            {
                flCXIRemovedReport.Load(companyId);
            }
            else
            {
                flCXIRemovedReport.LoadByCountryId(Int32.Parse(ddlCountry.SelectedValue), companyId);
            }

            // ... set properties to master page
            master.Data = flCXIRemovedReport.Data;
            master.Table = flCXIRemovedReport.TableName;

            // Get report
            if (flCXIRemovedReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new FlCXIRemovedReport();
                }
                else
                {
                    master.Report = new FlCXIRemovedReportExport();
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                    int loginId = Convert.ToInt32(Session["loginID"]);  

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());
                }
            }           
        }



    }
}