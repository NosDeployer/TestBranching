using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.CWP.Common;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.Company.Organization;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.WebUI.CWP.Common
{
    /// <summary>
    /// wincap_bulk_upload
    /// </summary>
    public partial class wincap_bulk_upload : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected WincapBulkUploadTDS.WincapBulkUploadDataTable wincapBulkUpload;






        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in wincap_bulk_upload.aspx");
                }

                // Tag Page
                TagPage();

                // Prepare initial data
                Session.Remove("wincapBulkUpload");

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";

                // ... Initialize tables
                wincapBulkUpload = new WincapBulkUploadTDS.WincapBulkUploadDataTable();

                // ... Store tables
                Session["wincapBulkUpload"] = wincapBulkUpload;

                // StepSection1In
                wzBulkUpload.ActiveStepIndex = 0;
                StepBeginIn();

            }
            else
            {
                // Restore tables
                wincapBulkUpload = (WincapBulkUploadTDS.WincapBulkUploadDataTable)Session["wincapBulkUpload"];
            }

            // control for postback
            hdfTag.Value = DateTime.Now.ToLongTimeString();
        }






        #region Wizard navigation events

        // ////////////////////////////////////////////////////////////////////////
        // WIZARD NAVIGATION EVENTS
        //

        protected void Wizard_ActiveStepChanged(object sender, EventArgs e)
        {
            if (ViewState["StepFrom"] != null)
            {
                switch (wzBulkUpload.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    default:
                        throw new Exception("The option for " + wzBulkUpload.ActiveStep.Name + " step in bulk_upload.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzBulkUpload.ActiveStep.Name)
            {
                case "Begin":
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Begin";
                        wzBulkUpload.ActiveStepIndex = wzBulkUpload.WizardSteps.IndexOf(StepSummary);

                    }
                    break;

                default:
                    throw new Exception("The option for " + wzBulkUpload.ActiveStep.Name + " step in bulk_upload.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzBulkUpload.ActiveStep.Name)
            {
                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzBulkUpload.ActiveStep.Name + " step in bulk_upload.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzBulkUpload.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = (!StepSummaryFinish());

            if (!e.Cancel)
            {
                Response.Write("<script language='javascript'> { window.close();}</script>");
            }

        }



        protected void Wizard_CancelButtonClick(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }

        #endregion





        #region STEP1 - BEGIN
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP1 - BEGIN
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select a Microsoft Excel file";

            //--- Initialize
            WincapBulkUploadTDS dataSet = new WincapBulkUploadTDS();
            dataSet.WincapBulkUpload.Merge(wincapBulkUpload, true);
            WincapBulkUpload model = new WincapBulkUpload(dataSet);
            model.Table.Rows.Clear();
            wincapBulkUpload = dataSet.WincapBulkUpload;
            Session["wincapBulkUpload"] = dataSet.WincapBulkUpload;
        }



        private bool StepBeginNext()
        {
            string fName = null;
            HttpPostedFile postedFile = htmlInputFile.PostedFile;

            if ((postedFile != null) && (postedFile.ContentLength > 0))
            {
                //--- Post file
                byte[] buffer = new byte[postedFile.ContentLength];
                postedFile.InputStream.Read(buffer, 0, postedFile.ContentLength);

                //--- Save posted file
                string physicalApplicationPath = Request.PhysicalApplicationPath;
                if (Request.PhysicalApplicationPath.Substring(Request.PhysicalApplicationPath.Length - 1, 1) != "\\")
                {
                    physicalApplicationPath += "\\";
                }
                fName = physicalApplicationPath + "export\\" + Path.GetFileName(postedFile.FileName);
                postedFile.SaveAs(fName);

                //--- Process bulk upload
                string wincapBulkUploadResultMessage;

                if (!ProcessBulkUpload(fName, out wincapBulkUploadResultMessage))
                {
                    lblResults.Text = wincapBulkUploadResultMessage;
                    File.Delete(fName);
                    return false;
                }
                else
                {
                    File.Delete(fName);

                    // create dataset
                    WincapBulkUploadTDS dataSet = new WincapBulkUploadTDS();
                    dataSet.WincapBulkUpload.Merge(wincapBulkUpload, true);

                    Session["wincapBulkUpload"] = wincapBulkUpload;

                    return true;
                }
            }
            else
            {
                lblResults.Text = "Please select a file";
                return false;
            }
        }



        private bool ProcessBulkUpload(string fName, out string wincapBulkUploadResultMessage)
        {
            bool wincapBulkUploadProccessed = true;
            wincapBulkUploadResultMessage = "";

            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();

            AppSettingsReader appSettingReader = new AppSettingsReader();
            string excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties='Excel 8.0;HDR=YES;IMEX=1';Data Source=" + fName + ";";
            OleDbConnection connection = new OleDbConnection(excelConnectionString);
            OleDbCommand command = null;
            OleDbDataReader dataReader = null;

            try
            {
                ArrayList validatedIds = new ArrayList();

                connection.Open();
                command = new OleDbCommand("select * from [sections]", connection);
                dataReader = command.ExecuteReader();

                int id = 0;

                while (dataReader.Read())
                {
                    if (!IsEmptyRow(dataReader))
                    {
                        string sectionId = "";
                        string state = "";
                        string distance = "";
                        string direction = "";
                        string videoDistance = "";
                        string clockPosition = "";
                        string distanceToCentre = "";
                        string reverseSetup = "";
                        string comments = "";

                        string dataCell = null;
                        string dataCellToUpper = null;

                        //--- ... fill section row                            
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            dataCell = dataReader.GetValue(i).ToString().Trim();
                            dataCellToUpper = dataReader.GetValue(i).ToString().Trim().ToUpper();

                            switch (dataReader.GetName(i).Trim())
                            {
                                case "SectionID":
                                    if (dataCellToUpper != "NULL")
                                    {
                                        sectionId = dataCell;
                                    }
                                    else
                                    {
                                        sectionId = "";
                                    }
                                    break;

                                case "State":
                                    if (dataCellToUpper != "NULL")
                                    {
                                        state = dataCell;
                                    }
                                    else
                                    {
                                        state = "";
                                    }
                                    break;

                                case "Direction":
                                    if (dataCellToUpper != "NULL")
                                    {
                                        direction = dataCell;
                                    }
                                    else
                                    {
                                        direction = "";
                                    }
                                    break;

                                case "Distance":
                                    if (dataCellToUpper != "NULL")
                                    {
                                        if (Distance.IsValidDistance(dataCell))
                                        {
                                            distance = dataCell;
                                        }
                                        else
                                        {
                                            wincapBulkUploadResultMessage = "Invalid value in 'Distance' column (" + id + "). Wincan Bulk Upload ABORTED.";
                                            wincapBulkUploadProccessed = false;
                                        }
                                    }
                                    else
                                    {
                                        distance = "";
                                    }
                                    break;

                                case "VideoDistance":
                                    if (dataCellToUpper != "NULL")
                                    {
                                        if (Distance.IsValidDistance(dataCell))
                                        {
                                            videoDistance = dataCell;
                                        }
                                        else
                                        {
                                            wincapBulkUploadResultMessage = "Invalid value in 'VideoDistance' column (" + id + "). Wincan Bulk Upload ABORTED.";
                                            wincapBulkUploadProccessed = false;
                                        }
                                    }
                                    else
                                    {
                                        videoDistance = "";
                                    }
                                    break;

                                case "ClockPosition":
                                    if (dataCellToUpper != "NULL")
                                    {
                                        clockPosition = dataCell;
                                    }
                                    else
                                    {
                                        clockPosition = "";
                                    }
                                    break;

                                case "DistanceToCentre":
                                    if (dataCellToUpper != "NULL")
                                    {
                                        if (Distance.IsValidDistance(dataCell))
                                        {
                                            distanceToCentre = dataCell;
                                        }
                                        else
                                        {
                                            wincapBulkUploadResultMessage = "Invalid value in 'DistanceToCentre' column (" + id + "). Wincan Bulk Upload ABORTED.";
                                            wincapBulkUploadProccessed = false;
                                        }
                                    }
                                    else
                                    {
                                        distanceToCentre = "";
                                    }
                                    break;

                                case "ReverseSetup":
                                    if (dataCellToUpper != "NULL")
                                    {
                                        if (Distance.IsValidDistance(dataCell))
                                        {
                                            reverseSetup = dataCell;
                                        }
                                        else
                                        {
                                            wincapBulkUploadResultMessage = "Invalid value in 'ReverseSetup' column (" + id + "). Wincan Bulk Upload ABORTED.";
                                            wincapBulkUploadProccessed = false;
                                        }
                                    }
                                    else
                                    {
                                        reverseSetup = "";
                                    }
                                    break;

                                case "Comments":
                                    if (dataCellToUpper != "NULL")
                                    {
                                        comments = dataCell;
                                    }
                                    else
                                    {
                                        comments = "";
                                    }
                                    break;

                                default:
                                    wincapBulkUploadResultMessage = "Invalid column name '" + dataReader.GetName(i) + "' in section data range.";
                                    wincapBulkUploadProccessed = false;
                                    break;
                            }

                            if (!wincapBulkUploadProccessed)
                            {
                                break;
                            }
                        }

                        if (wincapBulkUploadProccessed)
                        {
                            //--- Initialize
                            WincapBulkUploadTDS dataSet = new WincapBulkUploadTDS();
                            dataSet.WincapBulkUpload.Merge(wincapBulkUpload, true);
                            WincapBulkUpload model = new WincapBulkUpload(dataSet);
                            id = id + 1;
                            model.Insert(id.ToString(), sectionId, state, direction, distance, videoDistance, clockPosition, distanceToCentre, reverseSetup, comments);
                            wincapBulkUpload = dataSet.WincapBulkUpload;
                            Session["wincapBulkUpload"] = dataSet.WincapBulkUpload;
                        }
                    }
                }

                dataReader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                }

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                throw ex;
            }

            return (wincapBulkUploadProccessed) ? true : false;
        }
        #endregion






        #region STEP2 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - SUMMARY
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - SUMMARY - METHODS
        //

        private void StepSummaryIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Summary";

            // Initialize summary
            WincapBulkUploadTDS dataSet = new WincapBulkUploadTDS();
            dataSet.WincapBulkUpload.Merge(wincapBulkUpload, true);
            WincapBulkUpload model = new WincapBulkUpload(dataSet);

            tbxSummary.Text = model.GetSectionsSummary(hdfProjectLocation.Value.ToString());
        }



        private bool StepSummaryPrevious()
        {
            return true;
        }



        private bool StepSummaryFinish()
        {
            if (Page.IsValid)
            {
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS 
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizard title
            Label title = (Label)this.Master.FindControl("lblTitle");
            title.Text = "Wincan (Lateral) Bulk Upload";
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        #region RegisterClientScript & TagPage

        private void TagPage()
        {
            hdfCompanyId.Value = Session["companyID"].ToString();
            hdfProjectId.Value = Request.QueryString["project_id"].ToString();

            // Get ids & location
            int projectId = Int32.Parse(hdfProjectId.Value.Trim());
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            // ... Get ids
            Int64 currentCountry = projectGateway.GetCountryID(projectId);
            Int64? currentProvince = null; if (projectGateway.GetProvinceID(projectId).HasValue) currentProvince = (Int64)projectGateway.GetProvinceID(projectId);
            Int64? currentCounty = null; if (projectGateway.GetCountyID(projectId).HasValue) currentCounty = (Int64)projectGateway.GetCountyID(projectId);
            Int64? currentCity = null; if (projectGateway.GetCityID(projectId).HasValue) currentCity = (Int64)projectGateway.GetCityID(projectId);

            hdfCountryId.Value = currentCountry.ToString();
            hdfProvinceId.Value = currentProvince.ToString();
            hdfCountyId.Value = currentCounty.ToString();
            hdfCityId.Value = currentCity.ToString();

            // .. Get location
            string projectLocation = "";

            CountryGateway countryGateway = new CountryGateway();
            countryGateway.LoadByCountryId(currentCountry);
            projectLocation = projectLocation + countryGateway.GetName(currentCountry);

            if (currentProvince.HasValue)
            {
                ProvinceGateway provinceGateway = new ProvinceGateway();
                provinceGateway.LoadByProvinceId((Int64)currentProvince);
                projectLocation = projectLocation + ", " + provinceGateway.GetName((Int64)currentProvince);
            }

            if (currentCounty.HasValue)
            {
                CountyGateway countyGateway = new CountyGateway();
                countyGateway.LoadByCountyId((Int64)currentCounty);
                projectLocation = projectLocation + ", " + countyGateway.GetName((Int64)currentCounty);
            }

            if (currentCity.HasValue)
            {
                CityGateway cityGateway = new CityGateway();
                cityGateway.LoadByCityId((Int64)currentCity);
                projectLocation = projectLocation + ", " + cityGateway.GetName((Int64)currentCity);
            }

            hdfProjectLocation.Value = String.Format("The sections and laterals will be upload to {0}", projectLocation);
        }

        #endregion



        private void Save()
        {
            // process sections
            WincapBulkUploadTDS dataSet = new WincapBulkUploadTDS();
            dataSet.WincapBulkUpload.Merge(wincapBulkUpload, true);
            WincapBulkUpload model = new WincapBulkUpload(dataSet);

            // get parameters
            Int64 countryId = int.Parse(hdfCountryId.Value);
            Int64? provinceId = null; if (hdfProvinceId.Value != "") provinceId = Int64.Parse(hdfProvinceId.Value);
            Int64? countyId = null; if (hdfCountyId.Value != "") countyId = Int64.Parse(hdfCountyId.Value);
            Int64? cityId = null; if (hdfCityId.Value != "") cityId = Int64.Parse(hdfCityId.Value);
            int loginId = Convert.ToInt32(Session["loginID"]);

            // save to database
            DB.Open();
            DB.BeginTransaction();
            try
            {
                model.Save(int.Parse(hdfProjectId.Value), countryId, provinceId, countyId, cityId, int.Parse(hdfCompanyId.Value), loginId);

                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private bool IsEmptyRow(OleDbDataReader dataReader)
        {
            bool empty = true;

            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                if (dataReader.GetValue(i).ToString() != "")
                {
                    empty = false;
                    break;
                }
            }

            return empty;
        }



    }
}