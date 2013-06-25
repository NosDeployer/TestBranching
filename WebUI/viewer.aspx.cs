using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.BL.CWP.Jliner;
using LiquiForce.LFSLive.WebUI.CWP.Jliner;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI
{
	public partial class viewer : System.Web.UI.Page
	{
        /// ////////////////////////////////////////////////////////////////////////
        /// PROPERTIES AND FIELDS
        ///

        //
        // Data Access components
        //
        protected CrystalDecisions.CrystalReports.Engine.ReportDocument report;

        /// ////////////////////////////////////////////////////////////////////////
		/// EVENTS
		///

		protected void Page_Load(object sender, System.EventArgs e)
		{
            // Security check
            if (!Convert.ToBoolean(Session["sgLFS_APP_VIEW"]))
            {
                Response.Redirect("./error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
            }

            // Validate query string
            if ((Request.QueryString["target_report"] == null) || (Request.QueryString["format"] == null))
            {
                Response.Redirect("./error_page.aspx?error=" + "Invalid query string in viewer.aspx");
            }

            // Initialize
            bool empty = false;

            // Get report data
            #region Get report data
            
            switch (Request.QueryString["target_report"])
            {
                // ... TimesheetMissing
                case "TimesheetMissing":
                    bool includeSalaried = (Request.QueryString["include_salaried"] == "true") ? true : false;
                    TimesheetMissingReportGateway gateway = new TimesheetMissingReportGateway();
                    if (Request.QueryString["all_employees"] == "true")
                    {
                        if (Request.QueryString["all_countries"] == "true")
                        {
                            gateway.LoadByFromTo(DateTime.Parse(Request.QueryString["date_from"]), DateTime.Parse(Request.QueryString["date_to"]), Request.QueryString["employee_state"], Request.QueryString["employee_type"], includeSalaried);
                        }
                        else
                        {
                            gateway.LoadByCountryIdFromTo(int.Parse(Request.QueryString["country_id"]), DateTime.Parse(Request.QueryString["date_from"]), DateTime.Parse(Request.QueryString["date_to"]), Request.QueryString["employee_state"], Request.QueryString["employee_type"], includeSalaried);
                        }
                    }
                    else
                    {
                        if (Request.QueryString["all_countries"] == "true")
                        {
                            gateway.LoadByEmployeeIDFromTo(int.Parse(Request.QueryString["employee_id"]), DateTime.Parse(Request.QueryString["date_from"]), DateTime.Parse(Request.QueryString["date_to"]), Request.QueryString["employee_state"], Request.QueryString["employee_type"], includeSalaried);
                        }
                        else
                        {
                            gateway.LoadByCountryIdEmployeeIDFromTo(int.Parse(Request.QueryString["country_id"]), int.Parse(Request.QueryString["employee_id"]), DateTime.Parse(Request.QueryString["date_from"]), DateTime.Parse(Request.QueryString["date_to"]), Request.QueryString["employee_state"], Request.QueryString["employee_type"], includeSalaried);
                        }
                    }

                    if (gateway.Table.Rows.Count > 0)
                    {
                        report = new TimesheetMissingReport();
                        report.SetDataSource(gateway.Data);

                        if (Request.QueryString["format"] == "pdf")
                        {
                            ((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
                            ((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
                        }
                        else
                        {
                            ((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
                            ((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
                        }
                    }
                    else
                    {
                        empty = true;
                    }
                    break;               


                // rJlinerPrintSearchResults
                case "rJlinerPrintSearchResults":
                    JlinerNavigatorTDS jlinerNavigatorTDS = (JlinerNavigatorTDS)Session["jlinerNavigatorTDS"];
                    LiquiForce.LFSLive.BL.CWP.Jliner.JlinerNavigator jlinerNavigator = new LiquiForce.LFSLive.BL.CWP.Jliner.JlinerNavigator(jlinerNavigatorTDS);

                    if (jlinerNavigator.Table.Rows.Count > 0)
                    {
                        report = new LiquiForce.LFSLive.WebUI.CWP.Jliner.rJlinerPrintSearchResults();
                        report.SetDataSource(jlinerNavigator.Data);

                        ArrayList parameterList = new ArrayList();
                        parameterList.Add(Request.QueryString["name"]);
                        SetCurrentValuesForParameterField(report, "name", parameterList);
                        parameterList.Clear();

                        if (Request.QueryString["format"] == "pdf")
                        {
                            // ... Parameters
                            int j;
                            for (int i = 0; i < int.Parse(Request.QueryString["totalColumns"]); i++)
                            {
                                j = i + 1;
                                if (Request.QueryString["header" + j].ToString() == "Hamilton Inspection Number")
                                {
                                    parameterList.Add("Hamilton Insp.#");
                                    SetCurrentValuesForParameterField(report, "header" + j, parameterList);
                                    parameterList.Clear();
                                }
                                else
                                {
                                    if (Request.QueryString["header" + j].ToString() == "Build / Rebuild")
                                    {
                                        parameterList.Add("Build / Rebuild #");
                                        SetCurrentValuesForParameterField(report, "header" + j, parameterList);
                                        parameterList.Clear();
                                    }
                                    else
                                    {
                                        parameterList.Add(Request.QueryString["header" + j]);
                                        SetCurrentValuesForParameterField(report, "header" + j, parameterList);
                                        parameterList.Clear();
                                    }
                                }
                            }

                            parameterList.Add(Request.QueryString["comments"]);
                            SetCurrentValuesForParameterField(report, "header39", parameterList);
                            parameterList.Clear();

                            parameterList.Add(Request.QueryString["history"]);
                            SetCurrentValuesForParameterField(report, "header40", parameterList);
                            parameterList.Clear();

                            // ... Sections
                            ((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
                            ((Section)report.ReportDefinition.Sections["sDetailForExel"]).SectionFormat.EnableSuppress = true;

                            if (int.Parse(Request.QueryString["totalSelectedColumns"]) <= 12)
                            {
                                ((Section)report.ReportDefinition.Sections["sDetail48columns"]).SectionFormat.EnableSuppress = true;
                                ((Section)report.ReportDefinition.Sections["sDetail36columns"]).SectionFormat.EnableSuppress = true;
                                ((Section)report.ReportDefinition.Sections["sDetail24columns"]).SectionFormat.EnableSuppress = true;
                                ((Section)report.ReportDefinition.Sections["sDetail12columns"]).SectionFormat.EnableSuppress = false;
                            }
                            else
                            {
                                if ((int.Parse(Request.QueryString["totalSelectedColumns"]) > 12) && (int.Parse(Request.QueryString["totalSelectedColumns"]) <= 24))
                                {
                                    ((Section)report.ReportDefinition.Sections["sDetail48columns"]).SectionFormat.EnableSuppress = true;
                                    ((Section)report.ReportDefinition.Sections["sDetail36columns"]).SectionFormat.EnableSuppress = true;
                                    ((Section)report.ReportDefinition.Sections["sDetail24columns"]).SectionFormat.EnableSuppress = false;
                                    ((Section)report.ReportDefinition.Sections["sDetail12columns"]).SectionFormat.EnableSuppress = true;
                                }
                                else
                                {
                                    if ((int.Parse(Request.QueryString["totalSelectedColumns"]) > 24) && (int.Parse(Request.QueryString["totalSelectedColumns"]) <= 36))
                                    {
                                        ((Section)report.ReportDefinition.Sections["sDetail48columns"]).SectionFormat.EnableSuppress = true;
                                        ((Section)report.ReportDefinition.Sections["sDetail36columns"]).SectionFormat.EnableSuppress = false;
                                        ((Section)report.ReportDefinition.Sections["sDetail24columns"]).SectionFormat.EnableSuppress = true;
                                        ((Section)report.ReportDefinition.Sections["sDetail12columns"]).SectionFormat.EnableSuppress = true;
                                    }
                                    else
                                    {
                                        ((Section)report.ReportDefinition.Sections["sDetail48columns"]).SectionFormat.EnableSuppress = false;
                                        ((Section)report.ReportDefinition.Sections["sDetail36columns"]).SectionFormat.EnableSuppress = true;
                                        ((Section)report.ReportDefinition.Sections["sDetail24columns"]).SectionFormat.EnableSuppress = true;
                                        ((Section)report.ReportDefinition.Sections["sDetail12columns"]).SectionFormat.EnableSuppress = true;
                                    }
                                }
                            }
                        }
                        else
                        {

                            // ... Parameters
                            int j;
                            for (int i = 0; i < int.Parse(Request.QueryString["totalColumns"]); i++)
                            {
                                j = i + 1;
                                if (Request.QueryString["header" + j].ToString() == "Hamilton Inspection Number")
                                {
                                    parameterList.Add("Hamilton Insp.#");
                                    SetCurrentValuesForParameterField(report, "header" + j, parameterList);
                                    parameterList.Clear();
                                }
                                else
                                {
                                    parameterList.Add(Request.QueryString["header" + j]);
                                    SetCurrentValuesForParameterField(report, "header" + j, parameterList);
                                    parameterList.Clear();
                                }                               
                            }

                            // ... Sections
                            ((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
                            ((Section)report.ReportDefinition.Sections["sDetailForExel"]).SectionFormat.EnableSuppress = false;
                            ((Section)report.ReportDefinition.Sections["sDetail48columns"]).SectionFormat.EnableSuppress = true;
                            ((Section)report.ReportDefinition.Sections["sDetail36columns"]).SectionFormat.EnableSuppress = true;
                            ((Section)report.ReportDefinition.Sections["sDetail24columns"]).SectionFormat.EnableSuppress = true;
                            ((Section)report.ReportDefinition.Sections["sDetail12columns"]).SectionFormat.EnableSuppress = true;
                            ((Section)report.ReportDefinition.Sections["sDetailSectionComments"]).SectionFormat.EnableSuppress = true;
                            ((Section)report.ReportDefinition.Sections["sDetailSectionHistory"]).SectionFormat.EnableSuppress = true;
                            ((Section)report.ReportDefinition.Sections["sDetailSeparator"]).SectionFormat.EnableSuppress = true;
                            ((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
                            ((Section)report.ReportDefinition.Sections["sTitle"]).SectionFormat.EnableSuppress = true;
                        }

                        // Report format
                        report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                        report.PrintOptions.PaperSize = PaperSize.PaperLegal;
                    }
                    else
                    {
                        empty = true;
                    }
                    break;
                
            }
            #endregion

            if (!empty)
            {
                // Configure report

                // ... Disk options
                string physicalApplicationPath = Request.PhysicalApplicationPath;
                if (Request.PhysicalApplicationPath.Substring(Request.PhysicalApplicationPath.Length - 1, 1) != "\\")
                {
                    physicalApplicationPath += "\\";
                }

                string fName = "";
                switch (Request.QueryString["format"])
                {
                    case "pdf":
                        fName = physicalApplicationPath + "export\\" + Guid.NewGuid().ToString() + ".pdf";
                        Session["fName"] = fName;
                        break;

                    case "excel":
                        fName = physicalApplicationPath + "export\\" + Guid.NewGuid().ToString() + ".xls";
                        Session["fName"] = fName;
                        break;

                    case "word":
                        break;
                }

                DiskFileDestinationOptions diskOptions = new DiskFileDestinationOptions();
                diskOptions.DiskFileName = fName;

                // ... Export options
                report.ExportOptions.DestinationOptions = diskOptions;
                report.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;

                switch (Request.QueryString["format"])
                {
                    case "pdf":
                        report.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        break;

                    case "excel":
                        ExcelFormatOptions excelOptions = new ExcelFormatOptions();
                        excelOptions.ExcelUseConstantColumnWidth = false;
                        excelOptions.ExcelTabHasColumnHeadings = false;

                        report.ExportOptions.ExportFormatType = ExportFormatType.Excel;
                        report.ExportOptions.FormatOptions = excelOptions;
                        break;

                    case "word":
                        break;
                }

                // Export report
                try
                {
                    report.Export();
                }
                catch (Exception ex)
                {
                    Response.Redirect("./error_page.aspx?error=" + ex.Message);
                }

                // Preview report
                Response.Redirect("./viewer2.aspx?target_report=" + Request.QueryString["target_report"] + "&format=" + Request.QueryString["format"], true);
            }
            else
            {
                Response.Write("<br>         No records found for your report.");
            }
        }



        protected void Page_Unload(object sender, System.EventArgs e)
        {
            report.Close();
            report.Dispose();
        }



        private void SetCurrentValuesForParameterField(ReportDocument report, string parameterName, ArrayList parameterList)
        {
            ParameterValues currentParameterValues = new ParameterValues();

            foreach (object submittedValue in parameterList)
            {
                ParameterDiscreteValue parameterDiscreteValue = new ParameterDiscreteValue();
                parameterDiscreteValue.Value = submittedValue.ToString();
                currentParameterValues.Add(parameterDiscreteValue);
            }

            ParameterFieldDefinitions parameterFieldDefinitions = report.DataDefinition.ParameterFields;
            ParameterFieldDefinition parameterFieldDefinition = parameterFieldDefinitions[parameterName];
            parameterFieldDefinition.ApplyCurrentValues(currentParameterValues);
        }

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			// 
			// report
			// 
			this.report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
			this.report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
			this.report.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper;
			this.report.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Default;

		}
		#endregion

	}
}