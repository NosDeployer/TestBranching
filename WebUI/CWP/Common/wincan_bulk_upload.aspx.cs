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
    /// wincan_bulk_upload
    /// </summary>
    public partial class wincan_bulk_upload : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected WincanBulkUploadTDS.WincanBulkUploadDataTable wincanBulkUpload;






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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in wincan_bulk_upload.aspx");
                }

                // Tag Page
                TagPage();

                // Prepare initial data
                Session.Remove("wincanBulkUpload");

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";

                // ... Initialize tables
                wincanBulkUpload = new WincanBulkUploadTDS.WincanBulkUploadDataTable();

                // ... Store tables
                Session["wincanBulkUpload"] = wincanBulkUpload;

                // StepSection1In
                wzBulkUpload.ActiveStepIndex = 0;
                StepBeginIn();

            }
            else
            {
                // Restore tables
                wincanBulkUpload = (WincanBulkUploadTDS.WincanBulkUploadDataTable)Session["wincanBulkUpload"];
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
            instruction.Text = "Please select a Microsoft Access file";

            //--- Initialize
            WincanBulkUploadTDS dataSet = new WincanBulkUploadTDS();
            dataSet.WincanBulkUpload.Merge(wincanBulkUpload, true);
            WincanBulkUpload model = new WincanBulkUpload(dataSet);
            model.Table.Rows.Clear();
            wincanBulkUpload = dataSet.WincanBulkUpload;
            Session["wincanBulkUpload"] = dataSet.WincanBulkUpload;
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
                string wincanBulkUploadResultMessage;

                if (!ProcessBulkUpload(fName, out wincanBulkUploadResultMessage))
                {
                    lblResults.Text = wincanBulkUploadResultMessage;
                    File.Delete(fName);
                    return false;
                }
                else
                {
                    File.Delete(fName);

                    // create dataset
                    WincanBulkUploadTDS dataSet = new WincanBulkUploadTDS();
                    dataSet.WincanBulkUpload.Merge(wincanBulkUpload, true);

                    Session["wincanBulkUpload"] = wincanBulkUpload;

                    return true;
                }
            }
            else
            {
                lblResults.Text = "Please select a file";
                return false;
            }
        }



        private bool ProcessBulkUpload(string fName, out string wincanBulkUploadResultMessage)
        {
            bool wincanBulkUploadProccessed = true;
            wincanBulkUploadResultMessage = "";

            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();

            AppSettingsReader appSettingReader = new AppSettingsReader();
            //string excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties='Excel 8.0;HDR=YES;IMEX=1';Data Source=" + fName + ";";
            string accessConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + fName + ";";
            
            //OleDbConnection connection = new OleDbConnection(excelConnectionString);
            OleDbConnection connection = new OleDbConnection(accessConnectionString);
            string sql = "SELECT SI_T.SI_InspName AS SectionID, SO_T.SO_OpCode AS State, SI_T.SI_InspectionDir AS Direction, SI_T.SI_InspectedLengthFeet AS Distance, SO_T.SO_PositionFeet AS VideoDistance, SO_T.SO_ClockPosition1 AS ClockPosition "+
                            " , SO_T.SO_Dim1 AS DistanceToCentre, SO_T.SO_ToGoFeet AS ReverseSetup, SO_T.SO_Remark AS Comments" +
                            " FROM SI_T INNER JOIN SO_T ON SI_T.SI_ID = SO_T.SO_Inspecs_ID;";
            OleDbCommand command = null;
            
            OleDbDataReader dataReader = null;           

            try
            {
                ArrayList validatedIds = new ArrayList();

                connection.Open();
                command = new OleDbCommand(sql, connection);
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
                                        wincanBulkUploadProccessed = false;
                                    }
                                    break;

                                case "State":
                                    if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                    {
                                        state = dataCell;
                                    }
                                    else
                                    {
                                        state = "Undefined";
                                    }
                                    break;

                                case "Direction":
                                    if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                    {
                                        direction = dataCell;
                                    }
                                    else
                                    {
                                        direction = "U";
                                    }
                                    break;

                                case "Distance":
                                    if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                    {
                                        if (Distance.IsValidDistance(dataCell))
                                        {
                                            distance = dataCell;
                                        }
                                        else
                                        {
                                            wincanBulkUploadResultMessage = "Invalid value in 'Distance' column (" + id + "). Wincan Bulk Upload ABORTED.";
                                            wincanBulkUploadProccessed = false;
                                        }
                                    }
                                    else
                                    {
                                        distance = "";
                                    }
                                    break;

                                case "VideoDistance":
                                    if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                    {
                                        if (Distance.IsValidDistance(dataCell))
                                        {
                                            videoDistance = dataCell;
                                        }
                                        else
                                        {
                                            wincanBulkUploadResultMessage = "Invalid value in 'VideoDistance' column (" + id + "). Wincan Bulk Upload ABORTED.";
                                            wincanBulkUploadProccessed = false;
                                        }
                                    }
                                    else
                                    {
                                        videoDistance = "";
                                    }
                                    break;

                                case "ClockPosition":
                                    if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                    {
                                        clockPosition = dataCell;
                                    }
                                    else
                                    {
                                        clockPosition = "";
                                    }
                                    break;

                                case "DistanceToCentre":
                                    if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                    {
                                        if (Distance.IsValidDistance(dataCell))
                                        {
                                            distanceToCentre = dataCell;
                                        }
                                        else
                                        {
                                            wincanBulkUploadResultMessage = "Invalid value in 'DistanceToCentre' column (" + id + "). Wincan Bulk Upload ABORTED.";
                                            wincanBulkUploadProccessed = false;
                                        }
                                    }
                                    else
                                    {
                                        distanceToCentre = "";
                                    }
                                    break;

                                case "ReverseSetup":
                                    if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                    {
                                        if (Distance.IsValidDistance(dataCell))
                                        {
                                            reverseSetup = dataCell;
                                        }
                                        else
                                        {
                                            wincanBulkUploadResultMessage = "Invalid value in 'ReverseSetup' column (" + id + "). Wincan Bulk Upload ABORTED.";
                                            wincanBulkUploadProccessed = false;
                                        }
                                    }
                                    else
                                    {
                                        reverseSetup = "";
                                    }
                                    break;

                                case "Comments":
                                    if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                    {
                                        comments = dataCell;
                                    }
                                    else
                                    {
                                        comments = "";
                                    }
                                    break;

                                default:
                                    wincanBulkUploadResultMessage = "Invalid column name '" + dataReader.GetName(i) + "' in section data range.";
                                    wincanBulkUploadProccessed = false;
                                    break;
                            }

                            if (!wincanBulkUploadProccessed)
                            {
                                break;
                            }
                        }

                        if (wincanBulkUploadProccessed)
                        {
                            //--- Initialize
                            WincanBulkUploadTDS dataSet = new WincanBulkUploadTDS();
                            dataSet.WincanBulkUpload.Merge(wincanBulkUpload, true);
                            WincanBulkUpload model = new WincanBulkUpload(dataSet);
                            id = id + 1;
                            model.Insert(id.ToString(), sectionId, state, direction, distance, videoDistance, clockPosition, distanceToCentre, reverseSetup, comments);
                            wincanBulkUpload = dataSet.WincanBulkUpload;
                            Session["wincanBulkUpload"] = dataSet.WincanBulkUpload;
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

            return (wincanBulkUploadProccessed) ? true : false;
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
            WincanBulkUploadTDS dataSet = new WincanBulkUploadTDS();
            dataSet.WincanBulkUpload.Merge(wincanBulkUpload, true);
            WincanBulkUpload model = new WincanBulkUpload(dataSet);

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
            WincanBulkUploadTDS dataSet = new WincanBulkUploadTDS();
            dataSet.WincanBulkUpload.Merge(wincanBulkUpload, true);
            WincanBulkUpload model = new WincanBulkUpload(dataSet);

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