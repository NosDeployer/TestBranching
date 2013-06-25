using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.WebUI.export.Temp;

namespace LiquiForce.LFSLive.WebUI
{
    /// <summary>
    /// jl_data_migration
    /// </summary>
    public partial class jl_data_migration : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //
        protected DataMigrationTDS.JlDataMigrationDataTable dataMigration;
        protected DataMigrationTDS.DataMigrationProjectDataTable dataMigrationProject;
        private int timeOut;






        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Prepare initial data
                Session.Remove("dataMigration");

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";
                hdfCompanyId.Value = Session["companyID"].ToString();

                // ... Initialize tables
                dataMigration = new DataMigrationTDS.JlDataMigrationDataTable();
                dataMigrationProject = new DataMigrationTDS.DataMigrationProjectDataTable();

                // ... Store tables
                Session["dataMigration"] = dataMigration;
                Session["dataMigrationProject"] = dataMigrationProject;

                // StepSection1In
                wzDataMigration.ActiveStepIndex = 0;
                StepProjectsIn();

            }
            else
            {
                // Restore tables
                dataMigration = (DataMigrationTDS.JlDataMigrationDataTable)Session["dataMigration"];
                dataMigrationProject = (DataMigrationTDS.DataMigrationProjectDataTable)Session["dataMigrationProject"];
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
                switch (wzDataMigration.ActiveStep.Name)
                {
                    case "Projects":
                        StepProjectsIn();
                        break;

                    case "Sections":
                        StepSectionsIn();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    default:
                        throw new Exception("The option for " + wzDataMigration.ActiveStep.Name + " step in jl_data_migration.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzDataMigration.ActiveStep.Name)
            {
                case "Projects":
                    e.Cancel = !StepProjectsNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Projects";
                        wzDataMigration.ActiveStepIndex = wzDataMigration.WizardSteps.IndexOf(Sections);
                    }
                    break;

                case "Sections":
                    e.Cancel = !StepSectionsNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Sections";
                        wzDataMigration.ActiveStepIndex = wzDataMigration.WizardSteps.IndexOf(StepSummary);
                    }
                    break;

                default:
                    throw new Exception("The option for " + wzDataMigration.ActiveStep.Name + " step in jl_data_migration.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzDataMigration.ActiveStep.Name)
            {
                case "Sections":
                    e.Cancel = !StepSectionsPrevious();
                    break;

                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzDataMigration.ActiveStep.Name + " step in jl_data_migration.Wizard_PreviousButtonClick function does not exist");
            }

            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzDataMigration.ActiveStep.Name;
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






        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP1 - PROJECTS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - PROJECTS - METHODS
        //

        private void StepProjectsIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select a Microsoft Excel file of migration project";

            //--- Initialize
            DataMigrationTDS dataSet = new DataMigrationTDS();
            dataSet.DataMigrationProject.Merge(dataMigrationProject, true);
            DataMigrationProject model = new DataMigrationProject(dataSet);
            model.Table.Rows.Clear();
            dataMigrationProject = dataSet.DataMigrationProject;
            Session["dataMigrationProject"] = dataSet.DataMigrationProject;
        }



        private bool StepProjectsNext()
        {
            string fName = null;
            HttpPostedFile postedFile = htmlInputFileProjects.PostedFile;

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
                string bulkUploadProjectsResultMessage;

                if (!ProcessBulkProjectsUpload(fName, out bulkUploadProjectsResultMessage))
                {
                    lblResultsProjects.Text = bulkUploadProjectsResultMessage;
                    File.Delete(fName);
                    return false;
                }
                else
                {
                    File.Delete(fName);

                    // create dataset
                    DataMigrationTDS dataSet = new DataMigrationTDS();
                    dataSet.DataMigrationProject.Merge(dataMigrationProject, true);

                    Session["dataMigrationProject"] = dataMigrationProject;

                    return true;
                }
            }
            else
            {
                lblResultsProjects.Text = "Please select a file";
                return false;
            }
            //return true;
        }



        private bool ProcessBulkProjectsUpload(string fName, out string bulkUploadProjectsResultMessage)
        {
            bool bulkUploadProccessed = true;
            bulkUploadProjectsResultMessage = "";

            AppSettingsReader appSettingReader = new AppSettingsReader();
            string excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties='Excel 8.0;HDR=YES;IMEX=1';Data Source=" + fName + ";";
            OleDbConnection connection = new OleDbConnection(excelConnectionString);
            OleDbCommand command = null;
            OleDbDataReader dataReader = null;

            try
            {
                try
                {
                    //--- Process bulk upload
                    if (bulkUploadProccessed)
                    {
                        connection.Open();
                        command = new OleDbCommand("select * from [projects]", connection);
                        dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            if (!IsEmptyRow(dataReader))
                            {
                                int companiesId = 0;
                                Int64 countryId = 0;
                                Int64? provinceId = null;
                                Int64? countyId = null;
                                Int64? cityId = null;
                                int officeId = 0;
                                int? projectLeadId = null;
                                int salesmanId = 0;
                                string project = "";

                                string dataCell = null;
                                string dataCellToUpper = null;

                                //--- ... fill section row
                                for (int i = 0; i < dataReader.FieldCount; i++)
                                {
                                    dataCell = dataReader.GetValue(i).ToString().Trim();
                                    dataCellToUpper = dataReader.GetValue(i).ToString().Trim().ToUpper();

                                    switch (dataReader.GetName(i).Trim())
                                    {
                                        case "COMPANIES_ID":
                                            companiesId = int.Parse(dataCell);
                                            break;

                                        case "Country":
                                            if (dataCellToUpper != "NULL")
                                            {
                                                countryId = Int64.Parse(dataCell);
                                            }
                                            break;

                                        case "Province":
                                            if (dataCellToUpper != "NULL")
                                            {
                                                provinceId = Int64.Parse(dataCell);
                                            }
                                            break;

                                        case "County":
                                            if (dataCellToUpper != "NULL")
                                            {
                                                countyId = Int64.Parse(dataCell);
                                            }
                                            break;

                                        case "City":
                                            if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                            {
                                                cityId = Int64.Parse(dataCell);
                                            }
                                            break;

                                        case "Office":
                                            if (dataCellToUpper != "NULL")
                                            {
                                                officeId = int.Parse(dataCell);
                                            }
                                            break;

                                        case "Project Lead (optional)":
                                            if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                            {
                                                projectLeadId = int.Parse(dataCell);
                                            }
                                            break;

                                        case "Salesman":
                                            if (dataCellToUpper != "NULL")
                                            {
                                                salesmanId = int.Parse(dataCell);
                                            }
                                            break;

                                        case "Project":
                                            if (dataCellToUpper != "NULL")
                                            {
                                                project = dataCell;
                                            }
                                            else
                                            {
                                                bulkUploadProjectsResultMessage = "Invalid value in 'Project' column.  Bulk upload ABORTED.";
                                                bulkUploadProccessed = false;
                                            }
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
                                    DataMigrationTDS dataSet = new DataMigrationTDS();
                                    dataSet.DataMigrationProject.Merge(dataMigrationProject, true);
                                    DataMigrationProject model = new DataMigrationProject(dataSet);
                                    model.Insert(companiesId, countryId, provinceId, countyId, cityId, officeId, projectLeadId, salesmanId, project);
                                    dataMigrationProject = dataSet.DataMigrationProject;
                                    Session["dataMigrationProject"] = dataSet.DataMigrationProject;
                                }
                            }
                        }

                        dataReader.Close();
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    bulkUploadProjectsResultMessage = "You did not define the 'projects' data range.  Bulk upload ABORTED.  Original message: " + ex.Message;
                    bulkUploadProccessed = false;

                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
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






        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP1 - SECTIONS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - SECTIONS - METHODS
        //

        private void StepSectionsIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select a Microsoft Excel file of migration section";

            //--- Initialize
            DataMigrationTDS dataSet = new DataMigrationTDS();
            dataSet.JlDataMigration.Merge(dataMigration, true);
            JlDataMigration model = new JlDataMigration(dataSet);
            model.Table.Rows.Clear();
            dataMigration = dataSet.JlDataMigration;
            Session["dataMigration"] = dataSet.JlDataMigration;
        }



        private bool StepSectionsNext()
        {
            string fName = null;
            HttpPostedFile postedFile = htmlInputFileSections.PostedFile;

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
                    lblResultsSections.Text = bulkUploadResultMessage;
                    File.Delete(fName);
                    return false;
                }
                else
                {
                    File.Delete(fName);

                    // create dataset
                    DataMigrationTDS dataSet = new DataMigrationTDS();
                    dataSet.JlDataMigration.Merge(dataMigration, true);

                    Session["dataMigration"] = dataMigration;

                    return true;
                }
            }
            else
            {
                lblResultsSections.Text = "Please select a file";
                return false;
            }
        }



        private bool ProcessBulkUpload(string fName, out string bulkUploadResultMessage)
        {
            bool bulkUploadProccessed = true;
            bulkUploadResultMessage = "";

            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();

            AppSettingsReader appSettingReader = new AppSettingsReader();
            string excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties='Excel 8.0;HDR=YES;IMEX=1';Data Source=" + fName + ";";

            OleDbConnection connection = new OleDbConnection(excelConnectionString);
            OleDbCommand command = null;
            OleDbDataReader dataReader = null;

            try
            {
                try
                {
                    connection.Open();
                    command = new OleDbCommand("select * from [sections]", connection);
                    dataReader = command.ExecuteReader();
                    dataReader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    bulkUploadResultMessage = "You did not define the 'sections' data range.  Bulk upload ABORTED.  Original message: " + ex.Message;
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
                            bool deleted = false;
                            int companiesId = 0;
                            string client = "";
                            string subArea = "";
                            string street = "";
                            string usmh = "";
                            string dsmh = "";
                            string mapSize = ""; //Size_                            
                            string mapLength = ""; //ScaledLength
                            string actualLength = ""; //
                            string confirmedSize = "";
                            bool jlWork = false; // JL work
                            string usmhMn = "";
                            string dsmhMn = "";
                            string usmhDepth = "";
                            string dsmhDepth = "";
                            string steelTapeThruPipe = "";
                            string usmhAtMouth1200 = "";
                            string usmhAtMouth100 = "";
                            string usmhAtMouth200 = "";
                            string usmhAtMouth300 = "";
                            string usmhAtMouth400 = "";
                            string usmhAtMouth500 = "";
                            string dsmhAtMouth1200 = "";
                            string dsmhAtMouth100 = "";
                            string dsmhAtMouth200 = "";
                            string dsmhAtMouth300 = "";
                            string dsmhAtMouth400 = "";
                            string dsmhAtMouth500 = "";
                            
                            string dataCell = null;
                            string dataCellToUpper = null;

                            //--- ... fill section row
                            string originalSectionId = dataReader.GetValue(dataReader.GetOrdinal("ID")).ToString().Trim();
                            
                            for (int i = 0; i < dataReader.FieldCount; i++)
                            {
                                dataCell = dataReader.GetValue(i).ToString().Trim();
                                dataCellToUpper = dataReader.GetValue(i).ToString().Trim().ToUpper();

                                switch (dataReader.GetName(i).Trim())
                                {
                                    case "ID":
                                        originalSectionId = dataCell;
                                        break;

                                    case "COMPANIES_ID":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            companiesId = int.Parse(dataCell);
                                        }
                                        else
                                        {
                                            bulkUploadResultMessage = "Invalid value in 'COMPANIES_ID' column (" + originalSectionId + ").  Bulk upload ABORTED.";                                            
                                        }

                                        break;

                                    case "SubArea":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            subArea = dataCell;
                                        }
                                        break;

                                    case "Street":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            street = dataCell;
                                        }
                                        break;

                                    case "USMH":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            usmh = dataCell;
                                        }
                                        break;

                                    case "DSMH":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            dsmh = dataCell;
                                        }
                                        break;

                                    case "Size_":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            if (Distance.IsValidDistance(dataCell))
                                            {
                                                mapSize = dataCell;
                                            }
                                            else
                                            {
                                                bulkUploadResultMessage = "Invalid value in 'Size_' column (" + originalSectionId + ").  Bulk upload ABORTED.";
                                                bulkUploadProccessed = false;
                                            }
                                        }
                                        break;

                                    case "ScaledLength":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            if (Distance.IsValidDistance(dataCell))
                                            {
                                                mapLength = dataCell;
                                            }
                                            else
                                            {
                                                bulkUploadResultMessage = "Invalid value in 'ScaledLength' column (" + originalSectionId + ").  Bulk upload ABORTED.";
                                                bulkUploadProccessed = false;
                                            }
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
                                                bulkUploadResultMessage = "Invalid value in 'ActualLength' column (" + originalSectionId + " " + dataCell + ").  Bulk upload ABORTED.";
                                                bulkUploadProccessed = false;
                                            }
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
                                                bulkUploadResultMessage = "Invalid value in 'ConfirmedSize' column (" + originalSectionId + ").  Bulk upload ABORTED.";
                                                bulkUploadProccessed = false;
                                            }
                                        }
                                        break;

                                    case "JLiner":
                                        if ((dataCellToUpper == "YES") || (dataCellToUpper == "NO"))
                                        {
                                            jlWork = (dataCellToUpper == "YES") ? true : false;
                                        }
                                        break;

                                    case "USMHMN":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            usmhMn = dataCell;
                                        }
                                        break;

                                    case "DSMHMN":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            dsmhMn = dataCell;
                                        }
                                        break;

                                    case "USMHDepth":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            usmhDepth = dataCell;
                                        }
                                        break;

                                    case "DSMHDepth":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            dsmhDepth = dataCell;
                                        }
                                        break;

                                    case "SteelTapeThruPipe":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            steelTapeThruPipe = dataCell;
                                        }
                                        break;

                                    case "USMHAtMouth1200":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            usmhAtMouth1200 = dataCell;
                                        }
                                        break;

                                    case "USMHAtMouth100":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            usmhAtMouth100 = dataCell;
                                        }
                                        break;

                                    case "USMHAtMouth200":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            usmhAtMouth200 = dataCell;
                                        }
                                        break;
                                    case "USMHAtMouth300":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            usmhAtMouth300 = dataCell;
                                        }
                                        break;
                                    case "USMHAtMouth400":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            usmhAtMouth400 = dataCell;
                                        }
                                        break;
                                    case "USMHAtMouth500":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            usmhAtMouth500 = dataCell;
                                        }
                                        break;

                                    case "DSMHAtMouth1200":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            dsmhAtMouth1200 = dataCell;
                                        }
                                        break;

                                    case "DSMHAtMouth100":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            dsmhAtMouth100 = dataCell;
                                        }
                                        break;

                                    case "DSMHAtMouth200":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            dsmhAtMouth200 = dataCell;
                                        }
                                        break;

                                    case "DSMHAtMouth300":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            dsmhAtMouth300 = dataCell;
                                        }
                                        break;
                                    case "DSMHAtMouth400":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            dsmhAtMouth400 = dataCell;
                                        }
                                        break;

                                    case "DSMHAtMouth500":
                                        if (dataCellToUpper != "NULL" && dataCellToUpper != "")
                                        {
                                            dsmhAtMouth500 = dataCell;
                                        }
                                        break;

                                    case "Deleted":
                                        if ((dataCellToUpper == "YES") || (dataCellToUpper == "NO"))
                                        {
                                            deleted = (dataCellToUpper == "YES") ? true : false;
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

                            if (bulkUploadProccessed && jlWork && !deleted)
                            {
                                DataMigrationGateway dataMigrationGateway = new DataMigrationGateway(null);
                                Guid originalId = dataMigrationGateway.GetOriginalIdByCompanyIdCompaniesIdRecordIdStreet(int.Parse(hdfCompanyId.Value), companiesId, originalSectionId, street);

                                id = id + 1;

                                if (!dataMigrationGateway.IsMigratedSection(originalId, originalSectionId))
                                {
                                    //--- Initialize
                                    int companyId = Int32.Parse(hdfCompanyId.Value);
                                    DataMigrationTDS dataSet = new DataMigrationTDS();
                                    dataSet.JlDataMigration.Merge(dataMigration, true);
                                    JlDataMigration model = new JlDataMigration(dataSet);
                                    CompaniesGateway companiesGateway = new CompaniesGateway();
                                    companiesGateway.LoadByCompaniesId(companiesId, companyId);
                                    client = companiesGateway.GetName(companiesId);

                                    model.Insert(originalId, originalSectionId, companiesId, client, subArea, street, usmh, dsmh, mapSize, mapLength, actualLength, confirmedSize, jlWork, usmhMn, dsmhMn, usmhDepth, dsmhDepth, steelTapeThruPipe, usmhAtMouth1200, usmhAtMouth100, usmhAtMouth200, usmhAtMouth300, usmhAtMouth400, usmhAtMouth500, dsmhAtMouth1200, dsmhAtMouth100, dsmhAtMouth200, dsmhAtMouth300, dsmhAtMouth400, dsmhAtMouth500, 0, 0, false, "No", 0, 0);

                                    dataMigration = dataSet.JlDataMigration;
                                    Session["dataMigration"] = dataSet.JlDataMigration;
                                }
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



        private bool StepSectionsPrevious()
        {
            return true;
        }






        #region STEP2 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - SUMMARY
        //


        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - SUMMARY - AUXILIAR METHODS
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
            DataMigrationTDS dataSet = new DataMigrationTDS();
            dataSet.JlDataMigration.Merge(dataMigration, true);
            JlDataMigration model = new JlDataMigration(dataSet);

            tbxSummary.Text = model.GetSectionsSummary("");
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
            title.Text = "Junction Lining Data Migration";
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void Save()
        {
            // process sections
            DataMigrationTDS dataSet = new DataMigrationTDS();
            dataSet.JlDataMigration.Merge(dataMigration, true);
            dataSet.DataMigrationProject.Merge(dataMigrationProject, true);
            JlDataMigration model = new JlDataMigration(dataSet);
            DataMigrationProject modelProject = new DataMigrationProject(dataSet);

            int loginId = Convert.ToInt32(Session["loginID"]);

            // save to database
            DB.Open();
            DB.BeginTransaction();
            try
            {
                modelProject.Save(int.Parse(hdfCompanyId.Value), loginId);
                model.Save(int.Parse(hdfCompanyId.Value), loginId);

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



        protected void wzDataMigration_Init(object sender, EventArgs e)
        {
            timeOut = Server.ScriptTimeout;

            // Give it 3 hours = 10800 seconds
            Server.ScriptTimeout = 10800;
        }



        protected void wzDataMigration_Unload(object sender, EventArgs e)
        {
            Server.ScriptTimeout = timeOut;
        }



    }
}
