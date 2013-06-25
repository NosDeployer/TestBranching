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
    public partial class bulk_upload : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected BulkUploadTDS.BulkUploadDataTable bulkUpload;
       





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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in bulk_upload.aspx");
                }

                // Tag Page
                TagPage();

                // Prepare initial data
                Session.Remove("bulkUpload");

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";

                // ... Initialize tables
                bulkUpload = new BulkUploadTDS.BulkUploadDataTable();                

                // ... Store tables
                Session["bulkUpload"] = bulkUpload;

                // StepSection1In
                wzBulkUpload.ActiveStepIndex = 0;
                StepBeginIn();
                
            }
            else
            {
                // Restore tables
                bulkUpload = (BulkUploadTDS.BulkUploadDataTable)Session["bulkUpload"];
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
            BulkUploadTDS dataSet = new BulkUploadTDS();
            dataSet.BulkUpload.Merge(bulkUpload, true);
            BulkUpload model = new BulkUpload(dataSet);
            model.Table.Rows.Clear();
            bulkUpload = dataSet.BulkUpload;
            Session["bulkUpload"] = dataSet.BulkUpload;
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
                string bulkUploadResultMessage;

                if (!ProcessBulkUpload(fName, out bulkUploadResultMessage))
                {
                    lblResults.Text = bulkUploadResultMessage;
                    File.Delete(fName);
                    return false;
                }
                else
                {
                    File.Delete(fName);

                    // create dataset
                    BulkUploadTDS dataSet = new BulkUploadTDS();
                    dataSet.BulkUpload.Merge(bulkUpload, true);

                    Session["bulkUpload"] = bulkUpload;
                    
                    return true;                        
                }  
            }
            else
            {
                lblResults.Text = "Please select a file";
                return false;
            }
        }



        private bool ProcessBulkUpload(string fName, out string bulkUploadResultMessage)
        {
            bool bulkUploadProccessed = true;
            bulkUploadResultMessage = "";

            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();

            AppSettingsReader appSettingReader = new AppSettingsReader();
            string excelConnectionString = appSettingReader.GetValue("ExcelConnectionString", typeof(System.String)).ToString() + fName + ";";
            OleDbConnection connection = new OleDbConnection(excelConnectionString);
            OleDbCommand command = null;
            OleDbDataReader dataReader = null;

            try
            {
                ArrayList validatedIds = new ArrayList();

                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from [sections]", connection);
                    dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        if (!IsEmptyRow(dataReader))
                        {
                            string raWork = ""; 
                            try 
                            { 
                                raWork = dataReader.GetValue(dataReader.GetOrdinal("RAWork")).ToString().ToUpper().Trim(); }
                            catch 
                            { 
                            }
 
                            string fllWork = "";
                            try
                            {
                                fllWork = dataReader.GetValue(dataReader.GetOrdinal("FLLWork")).ToString().ToUpper().Trim();
                            }
                            catch
                            {
                            }

                            string jlWork = "";
                            try
                            {
                                jlWork = dataReader.GetValue(dataReader.GetOrdinal("JLWork")).ToString().ToUpper().Trim();
                            }
                            catch
                            {
                            }

                            if (bulkUploadProccessed)
                            {
                                if (((raWork != null) && (raWork != "")) || ((fllWork != null) && (fllWork != "")) || ((jlWork != null) && (jlWork != "")))
                                {
                                    if ((raWork.ToUpper() == "YES") || (fllWork.ToUpper() == "YES") || (jlWork.ToUpper() == "YES"))
                                    {
                                        bulkUploadProccessed = true;
                                    }
                                    else
                                    {
                                        bulkUploadResultMessage = "At least one work must exist in 'Works' columns (sections data range). Bulk upload ABORTED.";
                                        bulkUploadProccessed = false;
                                    }
                                }
                                else
                                {
                                    bulkUploadResultMessage = "At least one work must exist in 'Works' columns (sections data range). Bulk upload ABORTED.";
                                    bulkUploadProccessed = false;
                                }

                                if (!bulkUploadProccessed)
                                {
                                    break;
                                }
                            }
                        }
                    }

                    dataReader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    bulkUploadResultMessage = "You did not define the 'sections' data range. Bulk upload ABORTED. Original message: " + ex.Message;
                    bulkUploadProccessed = false;

                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }

                //--- Process bulk upload
                if (bulkUploadProccessed)
                {
                    connection.Open();
                    command = new OleDbCommand("select * from [sections]", connection);
                    dataReader = command.ExecuteReader();

                    int id = 0;

                    while (dataReader.Read())
                    {
                        if (!IsEmptyRow(dataReader))
                        {
                            string street = "";
                            string clientId = "";
                            string subArea = "";
                            string usmh = "";
                            string dsmh = "";
                            string mapSize = "";
                            string confirmedSize = "";
                            string mapLength = "";
                            string actualLength = "";
                            bool raWork = false;
                            string raComments = "";
                            bool fllWork = false;
                            string fllComments = "";
                            bool jlWork = false;
                            string dataCell = null;
                            string dataCellToUpper = null;

                            //--- ... fill section row                            
                            for (int i = 0; i < dataReader.FieldCount; i++)
                            {
                                dataCell = dataReader.GetValue(i).ToString().Trim();
                                dataCellToUpper = dataReader.GetValue(i).ToString().Trim().ToUpper();

                                switch (dataReader.GetName(i).Trim())
                                {
                                    case "Street":
                                        if (dataCellToUpper != "NULL")
                                        {
                                            street = dataCell;
                                        }
                                        else
                                        {
                                            street = "";
                                        }
                                        break;

                                    case "Client ID":
                                        if (dataCellToUpper != "NULL")
                                        {
                                            clientId = dataCell;
                                        }
                                        else
                                        {
                                            clientId = "";
                                        }
                                        break; 

                                    case "SubArea":
                                        if (dataCellToUpper != "NULL")
                                        {
                                            subArea = dataCell;
                                        }
                                        else
                                        {
                                            subArea = "";
                                        }
                                        break;        

                                    case "USMH":
                                        if (dataCellToUpper != "NULL")
                                        {
                                            usmh = dataCell;
                                        }
                                        else
                                        {
                                            usmh = "";
                                        }
                                        break;

                                    case "DSMH":
                                        if (dataCellToUpper != "NULL")
                                        {
                                            dsmh = dataCell;
                                        }
                                        else
                                        {
                                            dsmh = "";
                                        }
                                        break;

                                    case "MapSize":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            if (Distance.IsValidDistance(dataCell))
                                            {
                                                mapSize = dataCell;
                                            }
                                            else
                                            {
                                                bulkUploadResultMessage = "Invalid value in 'MapSize' column (" + id + "). Bulk upload ABORTED.";
                                                bulkUploadProccessed = false;
                                            }
                                        }
                                        else
                                        {
                                            mapSize = "";
                                        }
                                        break;

                                    case "ConfirmedSize":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            if (Distance.IsValidDistance(dataCell))
                                            {
                                                confirmedSize = dataCell;
                                            }
                                            else
                                            {
                                                bulkUploadResultMessage = "Invalid value in 'ConfirmedSize' column (" + id + "). Bulk upload ABORTED.";
                                                bulkUploadProccessed = false;
                                            }
                                        }
                                        else
                                        {
                                            confirmedSize = "";
                                        }
                                        break;

                                    case "MapLength":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            if (Distance.IsValidDistance(dataCell))
                                            {
                                                mapLength = dataCell;
                                            }
                                            else
                                            {
                                                bulkUploadResultMessage = "Invalid value in 'MapLength' column (" + id + "). Bulk upload ABORTED.";
                                                bulkUploadProccessed = false;
                                            }
                                        }
                                        else
                                        {
                                            mapLength = "";
                                        }
                                        break;

                                    case "ActualLength":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            if (Distance.IsValidDistance(dataCell))
                                            {
                                                actualLength = dataCell;
                                            }
                                            else
                                            {
                                                bulkUploadResultMessage = "Invalid value in 'ActualLength' column (" + id + "). Bulk upload ABORTED.";
                                                bulkUploadProccessed = false;
                                            }
                                        }
                                        else
                                        {
                                            actualLength = "";
                                        }
                                        break;

                                    case "RAWork":
                                        if ((dataCellToUpper == "YES") || (dataCellToUpper == "NO"))
                                        {
                                            raWork = (dataCellToUpper == "YES") ? true : false;
                                        }
                                        else
                                        {
                                            bulkUploadResultMessage = "Invalid value in 'RAWork' column (" + id + "). Bulk upload ABORTED.";
                                            bulkUploadProccessed = false;
                                        }
                                        break;

                                    case "RAComments":
                                        if (dataCellToUpper != "NULL")
                                        {
                                            raComments = dataCell;
                                        }
                                        else
                                        {
                                            raComments = "";
                                        }
                                        break;

                                    case "FLLWork":
                                        if ((dataCellToUpper == "YES") || (dataCellToUpper == "NO"))
                                        {
                                            fllWork = (dataCellToUpper == "YES") ? true : false;
                                        }
                                        else
                                        {
                                            bulkUploadResultMessage = "Invalid value in 'FLLWork' column (" + id + "). Bulk upload ABORTED.";
                                            bulkUploadProccessed = false;
                                        }
                                        break;

                                    case "FLLComments":
                                        if (dataCellToUpper != "NULL")
                                        {
                                            fllComments = dataCell;
                                        }
                                        else
                                        {
                                            fllComments = "";
                                        }
                                        break;

                                    case "JLWork":
                                        if ((dataCellToUpper == "YES") || (dataCellToUpper == "NO"))
                                        {
                                            jlWork = (dataCellToUpper == "YES") ? true : false;
                                        }
                                        else
                                        {
                                            bulkUploadResultMessage = "Invalid value in 'JLWork' column (" + id + "). Bulk upload ABORTED.";
                                            bulkUploadProccessed = false;
                                        }
                                        break;                                                              

                                    default:
                                        bulkUploadResultMessage = "Invalid column name '" + dataReader.GetName(i) + "' in section data range.";
                                        bulkUploadProccessed = false;
                                        break;
                                }

                                if (!bulkUploadProccessed)
                                {
                                    break;
                                }
                            }

                            if (bulkUploadProccessed)
                            {
                                //--- Initialize
                                BulkUploadTDS dataSet = new BulkUploadTDS();
                                dataSet.BulkUpload.Merge(bulkUpload, true);
                                BulkUpload model = new BulkUpload(dataSet);
                                id = id + 1;
                                model.Insert(id.ToString(), street, clientId, subArea, usmh, dsmh, mapSize, confirmedSize, mapLength, actualLength, raWork, raComments, fllWork, fllComments, jlWork);
                                bulkUpload = dataSet.BulkUpload;
                                Session["bulkUpload"] = dataSet.BulkUpload;
                            }
                        }
                    }

                    dataReader.Close();
                    connection.Close();
                }
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

            return (bulkUploadProccessed) ? true : false;
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
            BulkUploadTDS dataSet = new BulkUploadTDS();
            dataSet.BulkUpload.Merge(bulkUpload, true);
            BulkUpload model = new BulkUpload(dataSet);

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
            title.Text = "Bulk Upload";
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

            hdfProjectLocation.Value = String.Format("The sections will be upload to {0}", projectLocation);
        }

        #endregion



        private void Save()
        {
            // process sections
            BulkUploadTDS dataSet = new BulkUploadTDS();
            dataSet.BulkUpload.Merge(bulkUpload, true);
            BulkUpload model = new BulkUpload(dataSet);           

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