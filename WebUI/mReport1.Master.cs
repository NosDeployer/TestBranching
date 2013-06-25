
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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI
{
    public partial class mReport1 : System.Web.UI.MasterPage
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected bool _title = true;
        protected bool _toolbar = true;
        protected bool _criteria = true;
        protected bool _export = true;
        protected bool _preview = true;
        protected int _criteriaWidth;
        protected DataSet _data;
        protected string _table;
        protected ReportDocument _report;
        protected bool _directly;
        protected string _reportFrame;
        ReportMethod _generateMethod;
        private int timeOut;



        public string Title
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                // Set title to report
                lblTitle.Text = value;
            }
        }

        

        public bool ShowTitle
        {
            // Set if the title was displayed
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                if (!_title)
                {
                    tableTitle.Visible = false;
                    trTitle.Visible = false;

                    if (ShowToolBar)
                    {
                        trTableTitleWithToolbar1.Visible = true;
                        trTableTitleWithToolbar2.Visible = true;
                        trTableTitleWithoutToolbar1.Visible = false;
                    }
                    else
                    {
                        trTableTitleWithToolbar1.Visible = false;
                        trTableTitleWithToolbar2.Visible = false;
                        trTableTitleWithoutToolbar1.Visible = true;
                    }
                }
            }
        }



        public bool ShowToolBar
        {
            // Set if the toolbar was displayed
            get
            {
                return _toolbar;
            }
            set
            {
                _toolbar = value;
                if (!_toolbar)
                {
                    tableToolbar.Visible = false;
                    trToolbar.Visible = false;
                    trReport.Style["height"] = "680px";
                    ShowCriteria = false;

                    trTableTitleWithToolbar1.Visible = false;
                    trTableTitleWithToolbar2.Visible = false;
                    trTableTitleWithoutToolbar1.Visible = true;
                }
                else
                {
                    trTableTitleWithToolbar1.Visible = true;
                    trTableTitleWithToolbar2.Visible = true;
                    trTableTitleWithoutToolbar1.Visible = false;
                }
            }
        }



        public string CriteriaWidth
        {
            set
            {
                // Set width for criteria area
                tdCriteria.Width = value;
            }
        }



        public bool ShowCriteria
        {
            // Set if the criteria was displayed
            get
            {
                return _criteria;
            }
            set
            {
                if (!_toolbar)
                {
                    _criteria = false;
                }
                else
                {
                    _criteria = value;
                }

                if (!_criteria)
                {
                    tkrmReportToolbar.Items[0].Visible = false;
                    tdCriteria.Visible = false;                    
                }
            }
        }

        
                
        public bool ShowExport
        {
            // Set if the export option was displayed
            get
            {
                return _export;
            }
            set
            {
                if (!_toolbar)
                {
                    _export = false;
                }
                else
                {
                    _export = value;
                }

                if (!_export)
                {
                    tkrmReportToolbar.Items[2].Visible = false;
                }
            }
        }



        public bool ShowPreview
        {
            // Set if the export option was displayed
            get
            {
                return _preview;
            }
            set
            {
                if (!_toolbar)
                {
                    _preview = false;
                }
                else
                {
                    _preview = value;
                }

                if (!_preview)
                {
                    tkrmReportToolbar.Items[1].Visible = false;
                }
            }
        }



        public ReportDocument Report
        {
            // Crystal Report associated to form
            set
            {
                _report = value;
                if (_report != null)
                {
                    _report.SetDataSource(Data);
                }
            }
            get
            {
                if (_report == null)
                {
                    throw new Exception("The report is empty");
                }
                return _report;
            }
        }


                
        public string Format
        {
            // Get a format of the report: pdf or excel
            get
            {
                return hdfFormat.Value;
            }
        }



        public DataSet Data
        {
            // Set or get the dataSet associated to report
            set
            {
                _data = value;
            }
            get
            {
                if (_data == null)
                {
                    throw new Exception("Call generate method first");
                }
                return _data;
            }
        }



        public string Table
        {
            // Set or get the table name associated to report
            set
            {
                _table = value;
            }
            get
            {
                return _table;
            }
        }



        public bool PrintDirectly
        {
            // Print to PDF directly
            set
            {
                _directly = value;
                if (value)
                {
                    hdfFormat.Value = "pdf";
                    Print();
                }
            }
        }



        public bool ExportDirectly
        {
            // Export to EXCEL directly
            set
            {
                if (value)
                {
                    hdfFormat.Value = "excel";
                    Print();
                }
            }
        }


        
        public ReportMethod GenerateMethod
        {
            // Delegate for generate method
            set
            {
                _generateMethod = value;
            }
        }



        private string ReportFrame
        {
            get
            {
                return _reportFrame;
            }
            set
            {
                _reportFrame = value;
                if (!_toolbar)
                {
                    lReportFrame.Text = string.Format("<iframe id='iReportFrame' width='100%' height='680px' frameborder='0' src='{0}'></iframe>", _reportFrame);
                }
                else
                {
                    lReportFrame.Text = string.Format("<iframe id='iReportFrame' width='100%' height='522px' frameborder='0' src='{0}'></iframe>", _reportFrame);
                }
            }
        }



        

                
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                hdfFormat.Value = "empty";
                this.ReportFrame = "./../../new_viewer1.aspx";

                //Session.Timeout == 
            }
        }



        protected void Page_Init(object sender, EventArgs e)
        {
            timeOut = Server.ScriptTimeout;

            // Give it 1 hour = 3600 seconds
            Server.ScriptTimeout = 3600;
            
        }



        protected void Page_Unload(object sender, System.EventArgs e)
        {
            if ((_report != null) && (_report.IsLoaded))
            {
                _report.Close();
                _report.Dispose();
            }

            Server.ScriptTimeout = timeOut;
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mCriteria":
                    tdCriteria.Visible = !tdCriteria.Visible;
                    
                    if (hdfFormat.Value != "empty")
                    {
                        Print();
                    }
                    break;

                case "mPrint":
                    hdfFormat.Value = "pdf";
                    Print();
                    break;

                case "mExport":
                    hdfFormat.Value = "excel";
                    Print();
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            ClientScriptManager cs = Page.ClientScript;
        
            // Register client-side code
            cs.RegisterClientScriptInclude("clientSideCode", "./../../mReport1.js");

            // Resolve timeout problem
            ScriptManager scriptManager = (ScriptManager)this.Page.Master.FindControl("ScriptManager1");
            if (scriptManager != null)
            {                
                scriptManager.AsyncPostBackTimeout = 1200;
            }
        }



        public delegate void ReportMethod();
                


        private void Print()
        {
            // Border control
            if (!ShowTitle && !ShowToolBar && !ShowCriteria)
            {
                trTopReport.Visible = false;
                trBottomReport.Visible = false;
                tdLeftReport.Visible = false;
                tdRightReport.Visible = false;
            }

            // Generate report
            if (_generateMethod == null)
            {
                throw new Exception("Generate method is not defined");
            }
            _generateMethod();

            // Configure & export report
            if (_data.Tables[_table].Rows.Count > 0)
            {
                // ... Path & file name
                string physicalApplicationPath = Request.PhysicalApplicationPath;
                if (Request.PhysicalApplicationPath.Substring(Request.PhysicalApplicationPath.Length - 1, 1) != "\\")
                {
                    physicalApplicationPath += "\\";
                }

                string fileName = "";
                switch (hdfFormat.Value)
                {
                    case "pdf":
                        fileName = physicalApplicationPath + "export\\" + Guid.NewGuid().ToString() + ".pdf";
                        break;

                    case "excel":
                        fileName = physicalApplicationPath + "export\\" + Guid.NewGuid().ToString() + ".xls";
                        break;
                }

                DiskFileDestinationOptions diskOptions = new DiskFileDestinationOptions();
                diskOptions.DiskFileName = fileName;

                // ... Export options
                _report.ExportOptions.DestinationOptions = diskOptions;
                _report.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                switch (hdfFormat.Value)
                {
                    case "pdf":
                        _report.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        break;

                    case "excel":
                        ExcelFormatOptions excelOptions = new ExcelFormatOptions();
                        excelOptions.ExcelUseConstantColumnWidth = false;
                        excelOptions.ExcelTabHasColumnHeadings = false;

                        _report.ExportOptions.ExportFormatType = ExportFormatType.Excel;
                        _report.ExportOptions.FormatOptions = excelOptions;
                        break;
                }

                // ... Export report
                try
                {
                    _report.Export();
                }
                catch (Exception ex)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + ex.Message);
                }

                // ... Preview report
                //title = title.Replace("'", "''");
                Title = Title.Replace("'", "%27");
                this.ReportFrame = string.Format("./../../new_viewer3.aspx?file_name={0}&report_name={1}&report_format={2}", fileName, Title, hdfFormat.Value);
            }
            else
            {
                this.ReportFrame = "./../../new_viewer2.aspx";

                // ... Store state
                hdfFormat.Value = "empty";
            }
        }



        public void SetParameter(string parameterName, params object[] parameters)
        {
            ParameterValues currentParameterValues = new ParameterValues();

            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterDiscreteValue parameterDiscreteValue = new ParameterDiscreteValue();
                parameterDiscreteValue.Value = parameters[i].ToString();
                currentParameterValues.Add(parameterDiscreteValue);
            }

            ParameterFieldDefinitions parameterFieldDefinitions = _report.DataDefinition.ParameterFields;
            ParameterFieldDefinition parameterFieldDefinition = parameterFieldDefinitions[parameterName];
            parameterFieldDefinition.ApplyCurrentValues(currentParameterValues);
        }

        

    }
}