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
    public partial class mReportForM1 : System.Web.UI.MasterPage
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
        protected bool _directly;
        protected string _reportFrame;

        protected DataSet _data1;
        protected DataSet _data2;
        protected string _table1;
        protected string _table2;
        protected ReportDocument _report1;
        protected ReportDocument _report2;       
        ReportMethod1 _generateMethod1;
        ReportMethod2 _generateMethod2;



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
                    tkrmReportToolbar.Items[4].Visible = false;
                    tkrmReportToolbar.Items[6].Visible = false;
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
                    tkrmReportToolbar.Items[3].Visible = false;
                    tkrmReportToolbar.Items[5].Visible = false;
                }
            }
        }



        public ReportDocument Report1
        {
            // Crystal Report associated to form
            set
            {
                _report1 = value;
                if (_report1 != null)
                {
                    _report1.SetDataSource(Data1);
                }
            }
            get
            {
                if (_report1 == null)
                {
                    throw new Exception("The report is empty");
                }
                return _report1;
            }
        }



        public ReportDocument Report2
        {
            // Crystal Report associated to form
            set
            {
                _report2 = value;
                if (_report2 != null)
                {
                    _report2.SetDataSource(Data2);
                }
            }
            get
            {
                if (_report2 == null)
                {
                    throw new Exception("The report is empty");
                }
                return _report2;
            }
        }



        public string Format1
        {
            // Get a format of the report: pdf or excel
            get
            {
                return hdfFormat1.Value;
            }
        }



        public string Format2
        {
            // Get a format of the report: pdf or excel
            get
            {
                return hdfFormat2.Value;
            }
        }



        public DataSet Data1
        {
            // Set or get the dataSet associated to report
            set
            {
                _data1 = value;
            }
            get
            {
                if (_data1 == null)
                {
                    throw new Exception("Call generate method first");
                }
                return _data1;
            }
        }



        public DataSet Data2
        {
            // Set or get the dataSet associated to report
            set
            {
                _data2 = value;
            }
            get
            {
                if (_data2 == null)
                {
                    throw new Exception("Call generate method first");
                }
                return _data2;
            }
        }



        public string Table1
        {
            // Set or get the table name associated to report
            set
            {
                _table1 = value;
            }
            get
            {
                return _table1;
            }
        }



        public string Table2
        {
            // Set or get the table name associated to report
            set
            {
                _table2 = value;
            }
            get
            {
                return _table2;
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
                    hdfFormat1.Value = "pdf";
                    PrintM1();
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
                    hdfFormat1.Value = "excel";
                    PrintM1();
                }
            }
        }



        public ReportMethod1 GenerateMethod1
        {
            // Delegate for generate method
            set
            {
                _generateMethod1 = value;
            }
        }



        public ReportMethod2 GenerateMethod2
        {
            // Delegate for generate method
            set
            {
                _generateMethod2 = value;
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
                lReportFrame.Text = string.Format("<iframe id='iReportFrame' width='100%' height='522px' frameborder='0' src='{0}'></iframe>", _reportFrame);
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
                hdfFormat1.Value = "empty";
                hdfFormat2.Value = "empty";
                this.ReportFrame = "./../../new_viewer1.aspx";
            }
        }



        protected void Page_Unload(object sender, System.EventArgs e)
        {
            if ((_report1 != null) && (_report1.IsLoaded))
            {
                _report1.Close();
                _report1.Dispose();
            }

            if ((_report2 != null) && (_report2.IsLoaded))
            {
                _report2.Close();
                _report2.Dispose();
            }
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mCriteria":
                    tdCriteria.Visible = !tdCriteria.Visible;

                    if (hdfFormat1.Value != "empty")
                    {
                        PrintM1();
                    }
                    break;

                case "mPrintM1":
                    hdfFormat1.Value = "pdf";
                    PrintM1();
                    break;

                case "mExportM1":
                    hdfFormat1.Value = "excel";
                    PrintM1();
                    break;

                case "mPrintM2":
                    hdfFormat2.Value = "pdf";
                    PrintM2();
                    break;

                case "mExportM2":
                    hdfFormat2.Value = "excel";
                    PrintM2();
                    break;

                case "mPrintM1M2":
                    hdfFormat1.Value = "pdf";
                    hdfFormat2.Value = "pdf";
                    PrintM1M2();
                    break;

                case "mExportM1M2":
                    hdfFormat1.Value = "excel";
                    hdfFormat2.Value = "excel";
                    PrintM1M2();
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            ClientScriptManager cs = Page.ClientScript;

            // Register client-side code
            cs.RegisterClientScriptInclude("clientSideCode", "./../../mReportForM1.js");
        }



        public delegate void ReportMethod1();



        public delegate void ReportMethod2();



        private void PrintM1()
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
            if (_generateMethod1 == null)
            {
                throw new Exception("Generate method is not defined");
            }
            _generateMethod1();

            // Configure & export report
            if (_data1.Tables[_table1].Rows.Count > 0)
            {
                // ... Path & file name
                string physicalApplicationPath = Request.PhysicalApplicationPath;
                if (Request.PhysicalApplicationPath.Substring(Request.PhysicalApplicationPath.Length - 1, 1) != "\\")
                {
                    physicalApplicationPath += "\\";
                }

                string fileName = "";
                switch (hdfFormat1.Value)
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
                _report1.ExportOptions.DestinationOptions = diskOptions;
                _report1.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                switch (hdfFormat1.Value)
                {
                    case "pdf":
                        _report1.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        break;
                    
                    case "excel":
                        ExcelFormatOptions excelOptions = new ExcelFormatOptions();
                        excelOptions.ExcelUseConstantColumnWidth = false;
                        excelOptions.ExcelTabHasColumnHeadings = false;

                        _report1.ExportOptions.ExportFormatType = ExportFormatType.Excel;
                        _report1.ExportOptions.FormatOptions = excelOptions;
                        break;
                }

                // ... Export report
                try
                {
                    _report1.Export();
                }
                catch (Exception ex)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + ex.Message);
                }

                // ... Preview report
                this.ReportFrame = string.Format("./../../new_viewer3.aspx?file_name={0}&report_name={1}&report_format={2}", fileName, "M1 Report", hdfFormat1.Value);
            }
            else
            {
                this.ReportFrame = "./../../new_viewer2.aspx";

                // ... Store state
                hdfFormat1.Value = "empty";
            }
        }



        private void PrintM2()
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
            if (_generateMethod2 == null)
            {
                throw new Exception("Generate method is not defined");
            }
            _generateMethod2();

            // Configure & export report
            if (_data2.Tables[_table2].Rows.Count > 0)
            {
                // ... Path & file name
                string physicalApplicationPath = Request.PhysicalApplicationPath;
                if (Request.PhysicalApplicationPath.Substring(Request.PhysicalApplicationPath.Length - 1, 1) != "\\")
                {
                    physicalApplicationPath += "\\";
                }

                string fileName = "";
                switch (hdfFormat2.Value)
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
                _report2.ExportOptions.DestinationOptions = diskOptions;
                _report2.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                switch (hdfFormat2.Value)
                {
                    case "pdf":
                        _report2.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        break;

                    case "excel":
                        ExcelFormatOptions excelOptions = new ExcelFormatOptions();
                        excelOptions.ExcelUseConstantColumnWidth = false;
                        excelOptions.ExcelTabHasColumnHeadings = false;

                        _report2.ExportOptions.ExportFormatType = ExportFormatType.Excel;
                        _report2.ExportOptions.FormatOptions = excelOptions;
                        break;
                }

                // ... Export report
                try
                {
                    _report2.Export();
                }
                catch (Exception ex)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + ex.Message);
                }

                // ... Preview report
                this.ReportFrame = string.Format("./../../new_viewer3.aspx?file_name={0}&report_name={1}&report_format={2}", fileName, "M2 Report", hdfFormat2.Value);
            }
            else
            {
                this.ReportFrame = "./../../new_viewer2.aspx";

                // ... Store state
                hdfFormat2.Value = "empty";
            }
        }



        private void PrintM1M2()
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
            if (_generateMethod1 == null)
            {
                throw new Exception("Generate method 1 is not defined");
            }
            _generateMethod1();

            // Generate report
            if (_generateMethod2 == null)
            {
                throw new Exception("Generate method is not defined");
            }
            _generateMethod2();

            // Configure & export report for M1
            if (_data1.Tables[_table1].Rows.Count > 0)
            {
                // ... Path & file name
                string physicalApplicationPath = Request.PhysicalApplicationPath;
                if (Request.PhysicalApplicationPath.Substring(Request.PhysicalApplicationPath.Length - 1, 1) != "\\")
                {
                    physicalApplicationPath += "\\";
                }

                string fileName = "";
                switch (hdfFormat1.Value)
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
                _report1.ExportOptions.DestinationOptions = diskOptions;
                _report1.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                switch (hdfFormat1.Value)
                {
                    case "pdf":
                        _report1.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        break;

                    case "excel":
                        ExcelFormatOptions excelOptions = new ExcelFormatOptions();
                        excelOptions.ExcelUseConstantColumnWidth = false;
                        excelOptions.ExcelTabHasColumnHeadings = false;

                        _report1.ExportOptions.ExportFormatType = ExportFormatType.Excel;
                        _report1.ExportOptions.FormatOptions = excelOptions;
                        break;
                }

                // ... Export report
                try
                {
                    _report1.Export();
                }
                catch (Exception ex)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + ex.Message);
                }

                // ... Preview report
                this.ReportFrame = string.Format("./../../new_viewer3.aspx?file_name={0}&report_name={1}&report_format={2}", fileName, "M1 Report", hdfFormat1.Value);
            }
            else
            {
                this.ReportFrame = "./../../new_viewer2.aspx";

                // ... Store state
                hdfFormat1.Value = "empty";
            }

            // Configure & export report for M2
            if (_data2.Tables[_table2].Rows.Count > 0)
            {
                // ... Path & file name
                string physicalApplicationPath = Request.PhysicalApplicationPath;
                if (Request.PhysicalApplicationPath.Substring(Request.PhysicalApplicationPath.Length - 1, 1) != "\\")
                {
                    physicalApplicationPath += "\\";
                }

                string fileName = "";
                switch (hdfFormat2.Value)
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
                _report2.ExportOptions.DestinationOptions = diskOptions;
                _report2.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                switch (hdfFormat2.Value)
                {
                    case "pdf":
                        _report2.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        break;

                    case "excel":
                        ExcelFormatOptions excelOptions = new ExcelFormatOptions();
                        excelOptions.ExcelUseConstantColumnWidth = false;
                        excelOptions.ExcelTabHasColumnHeadings = false;

                        _report2.ExportOptions.ExportFormatType = ExportFormatType.Excel;
                        _report2.ExportOptions.FormatOptions = excelOptions;
                        break;
                }

                // ... Export report
                try
                {
                    _report2.Export();
                }
                catch (Exception ex)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + ex.Message);
                }

                string script = "<script language='javascript'>";
                string url = String.Format("./../../new_viewer4.aspx?file_name={0}&report_name={1}&report_format={2}", Server.UrlEncode(fileName), "M2 Report", hdfFormat2.Value);
                script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=0, height=0')", url);
                script = script + "</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "DownloadAttachment", script, false);
            }
            else
            {
                this.ReportFrame = "./../../new_viewer2.aspx";

                // ... Store state
                hdfFormat2.Value = "empty";
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        public void SetParameter1(string parameterName, params object[] parameters)
        {
            ParameterValues currentParameterValues = new ParameterValues();

            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterDiscreteValue parameterDiscreteValue = new ParameterDiscreteValue();
                parameterDiscreteValue.Value = parameters[i].ToString();
                currentParameterValues.Add(parameterDiscreteValue);
            }

            ParameterFieldDefinitions parameterFieldDefinitions = _report1.DataDefinition.ParameterFields;
            ParameterFieldDefinition parameterFieldDefinition = parameterFieldDefinitions[parameterName];
            parameterFieldDefinition.ApplyCurrentValues(currentParameterValues);
        }



        public void SetParameter2(string parameterName, params object[] parameters)
        {
            ParameterValues currentParameterValues = new ParameterValues();

            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterDiscreteValue parameterDiscreteValue = new ParameterDiscreteValue();
                parameterDiscreteValue.Value = parameters[i].ToString();
                currentParameterValues.Add(parameterDiscreteValue);
            }

            ParameterFieldDefinitions parameterFieldDefinitions = _report2.DataDefinition.ParameterFields;
            ParameterFieldDefinition parameterFieldDefinition = parameterFieldDefinitions[parameterName];
            parameterFieldDefinition.ApplyCurrentValues(currentParameterValues);
        }



    }
}