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
using System.Configuration;
using System.IO;
using System.Data.OleDb;
using LiquiForce.LFSLive.CWP.DatabaseGateway;
using LiquiForce.LFSLive.CWP.Tools;

namespace LiquiForce.LFSLive.WebUI.CWP
{
	public partial class bulk_upload : System.Web.UI.Page
	{
		/// ////////////////////////////////////////////////////////////////////////
		/// EVENTS
		///

		//
		// Page_Load
		//
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//--- Security check
			if (!(Convert.ToBoolean(Session["sgLFS_APP_VIEW"]) && Convert.ToBoolean(Session["sgLFS_APP_ADMIN"])))
			{
				Response.Redirect("./../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
			}
		}

		//
		// btnUpload_Click
		//
		protected void btnUpload_Click(object sender, System.EventArgs e)
		{
			string fName = null;
			HttpPostedFile postedFile = htmlInputFile.PostedFile;

			if ((postedFile != null) && (postedFile.ContentLength > 0))
			{
				try
				{
					//--- Post file
					byte[] buffer = new byte[postedFile.ContentLength];
					postedFile.InputStream.Read(buffer, 0, postedFile.ContentLength);

					//--- Save posted file
					string physicalApplicationPath = Request.PhysicalApplicationPath;
					if (Request.PhysicalApplicationPath.Substring(Request.PhysicalApplicationPath.Length-1, 1) != "\\")
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
					}
					else
					{
						lblResults.Text = "'" + Path.GetFileName(postedFile.FileName) + "' successfully uploaded!";
					}
				}
				catch(Exception ex)
				{
					Response.Redirect("./../error_page.aspx?error=" + ex.Message.ToString());
				}
				finally
				{
					File.Delete(fName);
				}
			}
			else
			{
				lblResults.Text = "Please select a file";
			}
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// ProcessBulkUpload
		//
		private bool ProcessBulkUpload(string fName, out string bulkUploadResultMessage)
		{
			//--- Initialize
			bool bulkUploadProccessed = true;
			bulkUploadResultMessage = "";
			
			TDSLFSRecord tdsLfsRecord = new TDSLFSRecord();  // holds the current record being uploaded
			TDSLFSRecord tdsLfsRecord2 = new TDSLFSRecord(); // holds all the records uploaded so far

			CompaniesGateway companiesGateway = new CompaniesGateway();
			LFSMasterAreaGateway lfsMasterAreaGateway = new LFSMasterAreaGateway();

			AppSettingsReader appSettingReader = new AppSettingsReader();
			string excelConnectionString = appSettingReader.GetValue("ExcelConnectionString", typeof(System.String)).ToString() + fName + ";";
			OleDbConnection connection = new OleDbConnection(excelConnectionString);
			OleDbConnection connection2 = new OleDbConnection(excelConnectionString);
			
			OleDbCommand command = null;
			OleDbCommand command2 = null;
			
			OleDbDataReader dataReader = null;
			OleDbDataReader dataReader2 = null;
			
			try
			{
				//--- Preliminar validation of lfs_master_area data range
				#region Preliminar validation of lfs_master_area data range

				ArrayList validatedRecordIds = new ArrayList();

				try
				{
					connection.Open();
					command = new OleDbCommand("select * from [lfs_master_area]", connection);
					dataReader = command.ExecuteReader();

					while (dataReader.Read())
					{
						if (!IsEmptyRow(dataReader))
						{
							string recordId = dataReader.GetValue(dataReader.GetOrdinal("ID")).ToString().ToUpper().Trim();

							if ( (recordId != "NULL") && (recordId != "") )
							{
								//--- ... validate whether the ID is unique
								foreach (string tempRecordId in validatedRecordIds)
								{
									if (tempRecordId == recordId)
									{
										bulkUploadResultMessage = "The ID '" + recordId + "' is not unique within the lfs_master_area data range.  Bulk upload ABORTED.";
										bulkUploadProccessed = false;
										break;
									}
								}

								//--- ... validate whether the ID is not already in use in the database
								if (bulkUploadProccessed)
								{
									if (lfsMasterAreaGateway.IsRecordIdInUse(recordId, Convert.ToInt32(Session["companyID"])))
									{
										bulkUploadResultMessage = "'" + recordId + "' is already in the database.  Bulk upload ABORTED.";
										bulkUploadProccessed = false;
									}
									else
									{
										validatedRecordIds.Add(recordId);
									}
								}
							}
							else
							{
								bulkUploadResultMessage = "Do not enter NULL in 'ID' column (lfs_master_area data range).  Bulk upload ABORTED.";
								bulkUploadProccessed = false;
							}

							if (!bulkUploadProccessed)
							{
								break;
							}
						}
					}

					dataReader.Close();
					connection.Close();
				}
				catch(Exception ex)
				{
					bulkUploadResultMessage = "You did not define the 'lfs_master_area' data range.  Bulk upload ABORTED.  Original message: " + ex.Message;
					bulkUploadProccessed = false;

					if (connection.State == ConnectionState.Open)
					{
						connection.Close();
					}
				}

#endregion


				//--- Preliminar validation of lfs_point_repairs data range
				#region Preliminar validation of lfs_point_repairs data range

				if (bulkUploadProccessed && cbxUploadLfsPointRepairs.Checked)
				{
					try
					{
						connection.Open();
						command = new OleDbCommand("select * from [lfs_point_repairs]", connection);
						dataReader = command.ExecuteReader();
			
						while (dataReader.Read())
						{
							if (!IsEmptyRow(dataReader))
							{
								string recordId = dataReader.GetValue(dataReader.GetOrdinal("ID")).ToString().ToUpper().Trim();

								if ( (recordId != "NULL") && (recordId != "") )
								{
									//--- ... validate whether the ID is defined in the lfs_master_area data range
									bool found = false;
									foreach (string tempRecordId in validatedRecordIds)
									{
										if (tempRecordId == recordId)
										{
											found = true;
											break;
										}
									}

									if (!found)
									{
										bulkUploadResultMessage = "The ID '" + recordId + "' defined in lfs_point_repairs data range does not have a corresponding ID defined in lfs_master_area data range.  Bulk upload ABORTED.";
										bulkUploadProccessed = false;
									}
								}
								else
								{
									bulkUploadResultMessage = "Do not enter NULL in 'ID' column (lfs_point_repairs data range).  Bulk upload ABORTED.";
									bulkUploadProccessed = false;
								}

								if (!bulkUploadProccessed)
								{
									break;
								}
							}
						}

						dataReader.Close();
						connection.Close();
					}
					catch(Exception ex)
					{
						bulkUploadResultMessage = "You did not define the 'lfs_point_repairs' data range.  Bulk upload ABORTED.  Original message: " + ex.Message;
						bulkUploadProccessed = false;

						if (connection.State == ConnectionState.Open)
						{
							connection.Close();
						}
					}
				}

				#endregion


				//--- Preliminar validation of lfs_junction_liner data range
				#region Preliminar validation of lfs_junction_liner data range

				if (bulkUploadProccessed && cbxUploadLfsJunctionLiner.Checked)
				{
					try
					{
						connection.Open();
						command = new OleDbCommand("select * from [lfs_junction_liner]", connection);
						dataReader = command.ExecuteReader();
			
						while (dataReader.Read())
						{
							if (!IsEmptyRow(dataReader))
							{
								string recordId = dataReader.GetValue(dataReader.GetOrdinal("ID")).ToString().ToUpper().Trim();

								if ( (recordId != "NULL") && (recordId != "") )
								{
									//--- ... validate whether the ID is defined in the lfs_master_area data range
									bool found = false;
									foreach (string tempRecordId in validatedRecordIds)
									{
										if (tempRecordId == recordId)
										{
											found = true;
											break;
										}
									}

									if (!found)
									{
										bulkUploadResultMessage = "The ID '" + recordId + "' defined in lfs_junction_liner data range does not have a corresponding ID defined in lfs_master_area data range.  Bulk upload ABORTED.";
										bulkUploadProccessed = false;
									}
								}
								else
								{
									bulkUploadResultMessage = "Do not enter NULL in 'ID' column (lfs_junction_liner data range).  Bulk upload ABORTED.";
									bulkUploadProccessed = false;
								}

								if (!bulkUploadProccessed)
								{
									break;
								}
							}
						}

						dataReader.Close();
						connection.Close();
					}
					catch(Exception ex)
					{
						bulkUploadResultMessage = "You did not define the 'lfs_junction_liner' data range.  Bulk upload ABORTED.  Original message: " + ex.Message;
						bulkUploadProccessed = false;

						if (connection.State == ConnectionState.Open)
						{
							connection.Close();
						}
					}
				}

				#endregion

				//--- Process bulk upload
				if (bulkUploadProccessed)
				{	
					connection.Open();
					command = new OleDbCommand("select * from [lfs_master_area]", connection);
					dataReader = command.ExecuteReader();
				
					while (dataReader.Read())
					{
						if (!IsEmptyRow(dataReader))
						{
							//--- ... fill lfs master area row
							string recordId = dataReader.GetValue(dataReader.GetOrdinal("ID")).ToString().Trim();

							TDSLFSRecord.LFS_MASTER_AREARow lfsMasterAreaRow = tdsLfsRecord.LFS_MASTER_AREA.NewLFS_MASTER_AREARow();

							#region fill lfsMasterAreaRow

							lfsMasterAreaRow.ID = lfsMasterAreaGateway.GetNewId();
							lfsMasterAreaRow.COMPANY_ID = Convert.ToInt32(Session["companyID"]);
							lfsMasterAreaRow.RecordID = recordId;
							lfsMasterAreaRow.IssueIdentified = false;
							lfsMasterAreaRow.IssueResolved = false;
							lfsMasterAreaRow.FullLengthLining = false;
							lfsMasterAreaRow.SubcontractorLining = false;
							lfsMasterAreaRow.OutOfScopeInArea = false;
							lfsMasterAreaRow.IssueGivenToBayCity = false;
							lfsMasterAreaRow.SalesIssue = false;
							lfsMasterAreaRow.LFSIssue = false;
							lfsMasterAreaRow.ClientIssue = false;
							lfsMasterAreaRow.InvestigationIssue = false;
							lfsMasterAreaRow.PointLining = false;
							lfsMasterAreaRow.Grouting = false;
							lfsMasterAreaRow.LateralLining = false;
							lfsMasterAreaRow.JLiner = false;
							lfsMasterAreaRow.RehabAssessment = false;
							lfsMasterAreaRow.RampsRequired = false;
							lfsMasterAreaRow.StandarBypass = false;
							lfsMasterAreaRow.RoboticPrepRequired = false;
							lfsMasterAreaRow.PipeSizeChange = false;
							lfsMasterAreaRow.FullLengthPointLiner = false;
							lfsMasterAreaRow.BypassRequired = false;
							///
							lfsMasterAreaRow.SchoolZone = false; 
							lfsMasterAreaRow.RestaurantArea = false;
							lfsMasterAreaRow.CarwashLaundromat = false;
							lfsMasterAreaRow.HydroPulley = false;
							lfsMasterAreaRow.FridgeCart = false;
							lfsMasterAreaRow.TwoInchPump = false;
							lfsMasterAreaRow.SixInchBypass = false;
							lfsMasterAreaRow.Scaffolding = false;
							lfsMasterAreaRow.WinchExtension = false;
							lfsMasterAreaRow.ExtraGenerator = false;
							lfsMasterAreaRow.GreyCableExtension = false;
							lfsMasterAreaRow.EasementMats = false;
							lfsMasterAreaRow.DropPipe = false;
                            lfsMasterAreaRow.AllMeasured = false;
							lfsMasterAreaRow.Deleted = false;
							lfsMasterAreaRow.Archived = false;

							string dataCell = null;
							string dataCellToUpper = null;

							string actualLength = null;
							string steelTapeThruPipe = null;

							for (int i=0; i < dataReader.FieldCount; i++)
							{
								dataCell = dataReader.GetValue(i).ToString().Trim();
								dataCellToUpper = dataReader.GetValue(i).ToString().Trim().ToUpper();

								switch (dataReader.GetName(i).Trim())
								{
									case "ID":
										break;

									case "ClientID":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.ClientID = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetClientIDNull();
										}
										break;

									case "Client":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.COMPANIES_ID = companiesGateway.GetCOMPANIES_ID(Convert.ToInt32(Session["companyID"]), dataCell);
											if (lfsMasterAreaRow.COMPANIES_ID == Int32.MinValue)
											{
												bulkUploadResultMessage = "Client '" + dataReader.GetValue(i).ToString() + "' was not found in the database (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											bulkUploadResultMessage = "Do not enter NULL in 'Client' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "SubArea":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.SubArea = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetSubAreaNull();
										}
										break;

									case "Street":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.Street = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetStreetNull();
										}
										break;

									case "USMH":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.USMH = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetUSMHNull();
										}
										break;

									case "DSMH":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.DSMH = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetDSMHNull();
										}
										break;

									case "Size":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.Size_ = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetSize_Null();
										}
										break;

									case "ScaledLength":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDouble(dataCell))
											{
												lfsMasterAreaRow.ScaledLength = dataCell;
												lfsMasterAreaRow.ScaledLength1 = Double.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'ScaledLength' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetScaledLengthNull();
											lfsMasterAreaRow.SetScaledLength1Null();
										}
										break;

									case "P1Date":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDate(dataCell))
											{
												lfsMasterAreaRow.P1Date = DateTime.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'P1Date' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetP1DateNull();
										}
										break;

									case "ActualLength":
										if (dataCellToUpper != "NULL")
										{
											if (Distance.IsValidDistance(dataCell))
											{
												if (steelTapeThruPipe == null || steelTapeThruPipe == dataCell)
												{
													lfsMasterAreaRow.ActualLength = dataCell;
													lfsMasterAreaRow.SteelTapeThruPipe = dataCell;
													actualLength = dataCell;
												}
												else
												{
													bulkUploadResultMessage = "'ActualLength' value is not equal to 'SteelTapeThruPipe' value (" + recordId + ").  Bulk upload ABORTED.";
													bulkUploadProccessed = false;
												}
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'ActualLength' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else 
										{
											if (steelTapeThruPipe == null || steelTapeThruPipe == "")
											{
												lfsMasterAreaRow.SetActualLengthNull();
												lfsMasterAreaRow.SetSteelTapeThruPipeNull();
												actualLength = "";
											}
											else
											{
												bulkUploadResultMessage = "'ActualLength' value is not equal to 'SteelTapeThruPipe' value (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										break;

									case "LiveLats":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDouble(dataCell))
											{
												lfsMasterAreaRow.LiveLats = Double.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'LiveLats' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetLiveLatsNull();
										}
										break;

									case "CXIsRemoved":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.CXIsRemoved = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetCXIsRemovedNull();
										}
										break;

									case "M1Date":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDate(dataCell))
											{
												lfsMasterAreaRow.M1Date = DateTime.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'M1Date' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetM1DateNull();
										}
										break;

									case "M2Date":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDate(dataCell))
											{
												lfsMasterAreaRow.M2Date = DateTime.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'M2Date' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetM2DateNull();
										}
										break;

									case "InstallDate":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDate(dataCell))
											{
												lfsMasterAreaRow.InstallDate = DateTime.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'InstallDate' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetInstallDateNull();
										}
										break;

									case "FinalVideo":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDate(dataCell))
											{
												lfsMasterAreaRow.FinalVideo = DateTime.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'FinalVideo' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetFinalVideoNull();
										}
										break;

									case "Comments":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.Comments = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetCommentsNull();
										}
										break;

									case "IssueIdentified":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.IssueIdentified = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'IssueIdentified' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "IssueResolved":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.IssueResolved = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'IssueResolved' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "FullLengthLining":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.FullLengthLining = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'FullLengthLining' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "SubcontractorLining":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.SubcontractorLining = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'SubcontractorLining' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "OutOfScopeInArea":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.OutOfScopeInArea = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'OutOfScopeInArea' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "IssueGivenToBayCity":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.IssueGivenToBayCity = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'IssueGivenToBayCity' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "ConfirmedSize":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidInt32(dataCell))
											{
												lfsMasterAreaRow.ConfirmedSize = Int32.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'ConfirmedSize' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetConfirmedSizeNull();
										}
										break;

									case "InstallRate":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDecimal(dataCell))
											{
												lfsMasterAreaRow.InstallRate = Decimal.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'InstallRate' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetInstallRateNull();
										}
										break;

									case "DeadlineDate":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDate(dataCell))
											{
												lfsMasterAreaRow.DeadlineDate = DateTime.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'DeadlineDate' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetDeadlineDateNull();
										}
										break;

									case "ProposedLiningDate":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDate(dataCell))
											{
												lfsMasterAreaRow.ProposedLiningDate = DateTime.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'ProposedLiningDate' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetProposedLiningDateNull();
										}
										break;

									case "SalesIssue":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.SalesIssue = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'SalesIssue' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "LFSIssue":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.LFSIssue = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'LFSIssue' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "ClientIssue":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.ClientIssue = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'ClientIssue' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "InvestigationIssue":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.InvestigationIssue = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'InvestigationIssue' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "PointLining":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.PointLining = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'PointLining' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "Grouting":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.Grouting = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'Grouting' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "LateralLining":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.LateralLining = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'LateralLining' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "VacExDate":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDate(dataCell))
											{
												lfsMasterAreaRow.VacExDate = DateTime.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'VacExDate' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetVacExDateNull();
										}
										break;

									case "PusherDate":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDate(dataCell))
											{
												lfsMasterAreaRow.PusherDate = DateTime.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'PusherDate' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetPusherDateNull();
										}
										break;

									case "LinerOrdered":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDate(dataCell))
											{
												lfsMasterAreaRow.LinerOrdered = DateTime.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'LinerOrdered' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetLinerOrderedNull();
										}
										break;

									case "Restoration":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDate(dataCell))
											{
												lfsMasterAreaRow.Restoration = DateTime.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'Restoration' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetRestorationNull();
										}
										break;

									case "GroutDate":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDate(dataCell))
											{
												lfsMasterAreaRow.GroutDate = DateTime.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'GroutDate' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetGroutDateNull();
										}
										break;

									case "JLiner":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.JLiner = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'JLiner' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "RehabAssessment":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.RehabAssessment = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'RehabAssessment' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "EstimatedJoints":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidInt32(dataCell))
											{
												lfsMasterAreaRow.EstimatedJoints = Int32.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'EstimatedJoints' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetEstimatedJointsNull();
										}
										break;

									case "JointsTestSealed":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidInt32(dataCell))
											{
												lfsMasterAreaRow.JointsTestSealed = Int32.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'JointsTestSealed' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetJointsTestSealedNull();
										}
										break;

									case "PreFlushDate":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDate(dataCell))
											{
												lfsMasterAreaRow.PreFlushDate = DateTime.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'PreFlushDate' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetPreFlushDateNull();
										}
										break;

									case "PreVideoDate":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDate(dataCell))
											{
												lfsMasterAreaRow.PreVideoDate = DateTime.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'PreVideoDate' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetPreVideoDateNull();
										}
										break;

									case "USMHMN":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.USMHMN = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetUSMHMNNull();
										}
										break;

									case "DSMHMN":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.DSMHMN = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetDSMHMNNull();
										}
										break;

									case "USMHDepth":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.USMHDepth = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetUSMHDepthNull();
										}
										break;

									case "DSMHDepth":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.DSMHDepth = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetDSMHDepthNull();
										}
										break;

									case "MeasurementsTakenBy":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.MeasurementsTakenBy = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetMeasurementsTakenByNull();
										}
										break;

									case "SteelTapeThruPipe":
										if (dataCellToUpper != "NULL")
										{
											if (Distance.IsValidDistance(dataCell))
											{
												if (actualLength == null || actualLength == dataCell)
												{
													lfsMasterAreaRow.SteelTapeThruPipe = dataCell;
													lfsMasterAreaRow.ActualLength = dataCell; // SYNCHRONIZED
													steelTapeThruPipe = dataCell;
												}
												else
												{
													bulkUploadResultMessage = "'SteelTapeThruPipe' value is not equal to 'ActualLength' value (" + recordId + ").   Bulk upload ABORTED.";
													bulkUploadProccessed = false;
												}
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'SteelTapeThruPipe' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}									
										}
										else 
										{
											if (actualLength == null || actualLength == "")
											{
												lfsMasterAreaRow.SetSteelTapeThruPipeNull();
												lfsMasterAreaRow.SetActualLengthNull(); // SYNCHRONIZED
												steelTapeThruPipe = "";
											}
											else
											{
												bulkUploadResultMessage = "'SteelTapeThruPipe' value is not equal to 'ActualLength' value (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										break;

									case "USMHAtMouth1200":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDouble(dataCell))
											{
												lfsMasterAreaRow.USMHAtMouth1200 = Double.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'USMHAtMouth1200' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetUSMHAtMouth1200Null();
										}
										break;

									case "USMHAtMouth100":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDouble(dataCell))
											{
												lfsMasterAreaRow.USMHAtMouth100 = Double.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'USMHAtMouth100' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetUSMHAtMouth100Null();
										}
										break;

									case "USMHAtMouth200":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDouble(dataCell))
											{
												lfsMasterAreaRow.USMHAtMouth200 = Double.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'USMHAtMouth200' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetUSMHAtMouth200Null();
										}
										break;

									case "USMHAtMouth300":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDouble(dataCell))
											{
												lfsMasterAreaRow.USMHAtMouth300 = Double.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'USMHAtMouth300' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetUSMHAtMouth300Null();
										}
										break;

									case "USMHAtMouth400":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDouble(dataCell))
											{
												lfsMasterAreaRow.USMHAtMouth400 = Double.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'USMHAtMouth400' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetUSMHAtMouth400Null();
										}
										break;

									case "USMHAtMouth500":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDouble(dataCell))
											{
												lfsMasterAreaRow.USMHAtMouth500 = Double.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'USMHAtMouth500' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetUSMHAtMouth500Null();
										}
										break;

									case "DSMHAtMouth1200":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDouble(dataCell))
											{
												lfsMasterAreaRow.DSMHAtMouth1200 = Double.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'DSMHAtMouth1200' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetDSMHAtMouth1200Null();
										}
										break;

									case "DSMHAtMouth100":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDouble(dataCell))
											{
												lfsMasterAreaRow.DSMHAtMouth100 = Double.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'DSMHAtMouth100' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetDSMHAtMouth100Null();
										}
										break;

									case "DSMHAtMouth200":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDouble(dataCell))
											{
												lfsMasterAreaRow.DSMHAtMouth200 = Double.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'DSMHAtMouth200' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetDSMHAtMouth200Null();
										}
										break;

									case "DSMHAtMouth300":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDouble(dataCell))
											{
												lfsMasterAreaRow.DSMHAtMouth300 = Double.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'DSMHAtMouth300' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetDSMHAtMouth300Null();
										}
										break;

									case "DSMHAtMouth400":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDouble(dataCell))
											{
												lfsMasterAreaRow.DSMHAtMouth400 = Double.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'DSMHAtMouth400' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetDSMHAtMouth400Null();
										}
										break;

									case "DSMHAtMouth500":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidDouble(dataCell))
											{
												lfsMasterAreaRow.DSMHAtMouth500 = Double.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'DSMHAtMouth500' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetDSMHAtMouth500Null();
										}
										break;

									case "HydrantAddress":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.HydrantAddress = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetHydrantAddressNull();
										}
										break;

									case "DistanceToInversionMH":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.DistanceToInversionMH = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetDistanceToInversionMHNull();
										}
										break;

									case "RampsRequired":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.RampsRequired = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'RampsRequired' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "DegreeOfTrafficControl":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.DegreeOfTrafficControl = dataCell;
											if ( (dataCell != "FLAGMEN REQUIRED") && (dataCell != "MAJOR ROAD") && (dataCell != "PERMIT REQUIRED") && (dataCell != "RESIDENTIAL"))
											{
												bulkUploadResultMessage = "Invalid value in 'DegreeOfTrafficControl' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetDegreeOfTrafficControlNull();	
										}
										break;

									case "StandarBypass":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.StandarBypass = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'StandarBypass' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "HydroWireDetails":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.HydroWireDetails = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetHydroWireDetailsNull();
										}
										break;

									case "PipeMaterialType":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.PipeMaterialType = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetPipeMaterialTypeNull();
										}
										break;

									case "CappedLaterals":
										if (dataCellToUpper != "NULL")
										{
											if (Validator.IsValidInt32(dataCell))
											{
												lfsMasterAreaRow.CappedLaterals = Int32.Parse(dataCell);
											}
											else
											{
												bulkUploadResultMessage = "Invalid value in 'CappedLaterals' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}
										}
										else
										{
											lfsMasterAreaRow.SetCappedLateralsNull();
										}
										break;

									case "RoboticPrepRequired":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.RoboticPrepRequired = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'RoboticPrepRequired' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "PipeSizeChange":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.PipeSizeChange = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'PipeSizeChange' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "M1Comments":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.M1Comments = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetM1CommentsNull();
										}
										break;

									case "VideoDoneFrom":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.VideoDoneFrom = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetVideoDoneFromNull();	
										}
										break;

									case "ToManhole":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.ToManhole = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetToManholeNull();
										}
										break;

									case "CutterDescriptionDuringMeasuring":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.CutterDescriptionDuringMeasuring = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetCutterDescriptionDuringMeasuringNull();
										}
										break;

									case "FullLengthPointLiner":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.FullLengthPointLiner = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'FullLengthPointLiner' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "BypassRequired":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.BypassRequired = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'BypassRequired' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "RoboticDistances":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.RoboticDistances = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetRoboticDistancesNull();
										}
										break;

										///

									case "TrafficControlDetails":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.TrafficControlDetails = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetTrafficControlDetailsNull();
										}
										break;
							
									case "LineWithID":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.LineWithID = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetLineWithIDNull();
										}
										break;

									case "SchoolZone":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.SchoolZone = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'SchoolZone' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "RestaurantArea":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.RestaurantArea = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'RestaurantArea' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "CarwashLaundromat":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.CarwashLaundromat = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'CarwashLaundromat' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "HydroPulley":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.HydroPulley = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'HydroPulley' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "FridgeCart":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.FridgeCart = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'FridgeCart' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "TwoInchPump":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.TwoInchPump = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'TwoInchPump' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;
								
									case "SixInchBypass":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.SixInchBypass = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'SixInchBypass' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "Scaffolding":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.Scaffolding = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'Scaffolding' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "WinchExtension":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.WinchExtension = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'WinchExtension' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "ExtraGenerator":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.ExtraGenerator = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'ExtraGenerator' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "GreyCableExtension":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.GreyCableExtension = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'GreyCableExtension' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "EasementMats":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.EasementMats = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'EasementMats' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "MeasurementType":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.MeasurementType = dataCell;
											if ( (dataCell != "CAMERA") && (dataCell != "SIMULATOR"))
											{
												bulkUploadResultMessage = "Invalid value in 'MeasurementType' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}								
										}
										else
										{
											lfsMasterAreaRow.SetMeasurementTypeNull();
										}
										break;

									case "DropPipe":
										if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
										{
											lfsMasterAreaRow.DropPipe = (dataCellToUpper == "YES") ? true : false;
										}
										else
										{
											bulkUploadResultMessage = "Invalid value in 'DropPipe' column (" + recordId + ").  Bulk upload ABORTED.";
											bulkUploadProccessed = false;
										}
										break;

									case "DropPipeInvertDepth":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.DropPipeInvertDepth = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetDropPipeInvertDepthNull();
										}
										break;

									case "MeasuredFromManhole":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.MeasuredFromManhole = dataCell;
										}
										else
										{
											lfsMasterAreaRow.SetMeasuredFromManholeNull();
										}
										break;

									case "MainLined":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.MainLined = dataCell;
											if ( (dataCellToUpper != "YES") && (dataCellToUpper != "NO"))
											{
												bulkUploadResultMessage = "Invalid value in 'MainLined' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}								
										}
										else
										{
											lfsMasterAreaRow.SetMainLinedNull();
										}
										break;

									case "BenchingIssue":
										if (dataCellToUpper != "NULL")
										{
											lfsMasterAreaRow.BenchingIssue = dataCell;
											if ( (dataCellToUpper != "YES") && (dataCellToUpper != "NO"))
											{
												bulkUploadResultMessage = "Invalid value in 'BenchingIssue' column (" + recordId + ").  Bulk upload ABORTED.";
												bulkUploadProccessed = false;
											}								
										}
										else
										{
											lfsMasterAreaRow.SetBenchingIssueNull();
										}
										break;

                                    case "History":
                                        if (dataCellToUpper != "NULL")
                                        {
                                            lfsMasterAreaRow.History = dataCell;
                                        }
                                        else
                                        {
                                            lfsMasterAreaRow.SetHistoryNull();
                                        }
                                        break;

                                    case "NumLats":
                                        if (dataCellToUpper != "NULL")
                                        {
                                            if (Validator.IsValidInt32(dataCell))
                                            {
                                                lfsMasterAreaRow.NumLats = Int32.Parse(dataCell);
                                            }
                                            else
                                            {
                                                bulkUploadResultMessage = "Invalid value in 'NumLats' column (" + recordId + ").  Bulk upload ABORTED.";
                                                bulkUploadProccessed = false;
                                            }
                                        }
                                        else
                                        {
                                            lfsMasterAreaRow.NumLats = 0;
                                        }
                                        break;

                                    case "NotLinedYet":
                                        if (dataCellToUpper != "NULL")
                                        {
                                            if (Validator.IsValidInt32(dataCell))
                                            {
                                                lfsMasterAreaRow.NotLinedYet = Int32.Parse(dataCell);
                                            }
                                            else
                                            {
                                                bulkUploadResultMessage = "Invalid value in 'NotLinedYet' column (" + recordId + ").  Bulk upload ABORTED.";
                                                bulkUploadProccessed = false;
                                            }
                                        }
                                        else
                                        {
                                            lfsMasterAreaRow.NotLinedYet = 0;
                                        }
                                        break;

                                    case "AllMeasured":
                                        if ((dataCellToUpper == "YES") || (dataCellToUpper == "NO"))
                                        {
                                            lfsMasterAreaRow.AllMeasured = (dataCellToUpper == "YES") ? true : false;
                                        }
                                        else
                                        {
                                            bulkUploadResultMessage = "Invalid value in 'AllMeasured' column (" + recordId + ").  Bulk upload ABORTED.";
                                            bulkUploadProccessed = false;
                                        }
                                        break;

                                    case "City":
                                        if (dataCellToUpper != "NULL")
                                        {
                                            lfsMasterAreaRow.City = dataCell;
                                        }
                                        else
                                        {
                                            lfsMasterAreaRow.SetCityNull();
                                        }
                                        break;

                                    case "ProvState":
                                        if (dataCellToUpper != "NULL")
                                        {
                                            lfsMasterAreaRow.ProvState = dataCell;
                                        }
                                        else
                                        {
                                            lfsMasterAreaRow.SetProvStateNull();
                                        }
                                        break;

                                    default:
										bulkUploadResultMessage = "Invalid column name '" + dataReader.GetName(i) + "' in lfs_master_area data range.";
										bulkUploadProccessed = false;
										break;
								}

								if (!bulkUploadProccessed)
								{
									break;
								}
							}

							#endregion
						
							tdsLfsRecord.LFS_MASTER_AREA.AddLFS_MASTER_AREARow(lfsMasterAreaRow);


							//--- ... fill lfs point repairs rows
							if (cbxUploadLfsPointRepairs.Checked)
							{
								connection2.Open();
								command2 = new OleDbCommand("select * from [lfs_point_repairs] where ID = '" + recordId + "'", connection2);
								dataReader2 = command2.ExecuteReader();

								while (dataReader2.Read())
								{
									if (!IsEmptyRow(dataReader))
									{
										TDSLFSRecord.LFS_POINT_REPAIRSRow lfsPointRepairsRow = tdsLfsRecord.LFS_POINT_REPAIRS.NewLFS_POINT_REPAIRSRow();

										#region fill lfsPointRepairsRow

										lfsPointRepairsRow.ID = lfsMasterAreaRow.ID;
										lfsPointRepairsRow.RefID = Generator.GetNewLfsPointRepairsRefId(tdsLfsRecord);
										lfsPointRepairsRow.COMPANY_ID = Convert.ToInt32(Session["companyID"]);
										lfsPointRepairsRow.DetailID = Generator.GetNewLfsPointRepairsDetailId(tdsLfsRecord);
										lfsPointRepairsRow.Deleted = false; 
										lfsPointRepairsRow.ExtraRepair = false;
										lfsPointRepairsRow.Cancelled = false;
										lfsPointRepairsRow.Approved = false;
										lfsPointRepairsRow.NotApproved = false;
										lfsPointRepairsRow.Archived = false;

										for (int i=0; i < dataReader2.FieldCount; i++)
										{
											dataCell = dataReader2.GetValue(i).ToString().Trim();
											dataCellToUpper = dataReader2.GetValue(i).ToString().Trim().ToUpper();

											switch (dataReader2.GetName(i).Trim())
											{
												case "ID":
													break;

												case "RepairSize":
													if (dataCellToUpper != "NULL")
													{
														lfsPointRepairsRow.RepairSize = dataCell;
													}
													else
													{
														lfsPointRepairsRow.SetRepairSizeNull();
													}
													break;

												case "InstallDate":
													if (dataCellToUpper != "NULL")
													{
														if (Validator.IsValidDate(dataCell))
														{
															lfsPointRepairsRow.InstallDate = DateTime.Parse(dataCell);
														}
														else
														{
															bulkUploadResultMessage = "Invalid value in 'InstallDate' column (" + recordId + ").  Bulk upload ABORTED.";
															bulkUploadProccessed = false;
														}
													}
													else
													{
														lfsPointRepairsRow.SetInstallDateNull();
													}
													break;

												case "Distance":
													if (dataCellToUpper != "NULL")
													{
														lfsPointRepairsRow.Distance = dataCell;
													}
													else
													{
														lfsPointRepairsRow.SetDistanceNull();
													}
													break;

												case "Cost":
													if (dataCellToUpper != "NULL")
													{
														if (Validator.IsValidDecimal(dataCell))
														{
															lfsPointRepairsRow.Cost = Decimal.Parse(dataCell);
														}
														else
														{
															bulkUploadResultMessage = "Invalid value in 'Cost' column (" + recordId + ").  Bulk upload ABORTED.";
															bulkUploadProccessed = false;
														}
													}
													else
													{
														lfsPointRepairsRow.SetCostNull();
													}
													break;

												case "Reinstates":
													if (dataCellToUpper != "NULL")
													{
														if (Validator.IsValidInt32(dataCell))
														{
															lfsPointRepairsRow.Reinstates = Int32.Parse(dataCell);
														}
														else
														{
															bulkUploadResultMessage = "Invalid value in 'Reinstates' column (" + recordId + ").  Bulk upload ABORTED.";
															bulkUploadProccessed = false;
														}
													}
													else
													{
														lfsPointRepairsRow.SetReinstatesNull();
													}
													break;

												case "LTAtMH":
													if (dataCellToUpper != "NULL")
													{
														lfsPointRepairsRow.LTAtMH = dataCell;
													}
													else
													{
														lfsPointRepairsRow.SetLTAtMHNull();
													}
													break;

												case "VTAtMH":
													if (dataCellToUpper != "NULL")
													{
														lfsPointRepairsRow.VTAtMH = dataCell;
													}
													else
													{
														lfsPointRepairsRow.SetVTAtMHNull();
													}
													break;

												case "LinerDistance":
													if (dataCellToUpper != "NULL")
													{
														lfsPointRepairsRow.LinerDistance = dataCell;
													}
													else
													{
														lfsPointRepairsRow.SetLinerDistanceNull();
													}
													break;

												case "Direction":
													if (dataCellToUpper != "NULL")
													{
														lfsPointRepairsRow.Direction = dataCell;
														if ( (dataCell != "DS PULL IN") && (dataCell != "DS PUSH IN") && (dataCell != "US PULL IN") && (dataCell != "US PUSH IN"))
														{
															bulkUploadResultMessage = "Invalid value in 'Direction' column (" + recordId + ").  Bulk upload ABORTED.";
															bulkUploadProccessed = false;
														}								
													}
													else
													{
														lfsPointRepairsRow.SetDirectionNull();
													}
													break;

												case "MHShot":
													if (dataCellToUpper != "NULL")
													{
														lfsPointRepairsRow.MHShot = dataCell;
														if ( (dataCell != "DS MH SHOT") && (dataCell != "US MH SHOT"))
														{
															bulkUploadResultMessage = "Invalid value in 'MHShot' column (" + recordId + ").  Bulk upload ABORTED.";
															bulkUploadProccessed = false;
														}								
													}
													else
													{
														lfsPointRepairsRow.SetMHShotNull();
													}
													break;

												case "Comments":
													if (dataCellToUpper != "NULL")
													{
														lfsPointRepairsRow.Comments = dataCell;
													}
													else
													{
														lfsPointRepairsRow.SetCommentsNull();
													}
													break;

												case "ExtraRepair":
													if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
													{
														lfsPointRepairsRow.ExtraRepair = (dataCellToUpper == "YES") ? true : false;
													}
													else
													{
														bulkUploadResultMessage = "Invalid value in 'ExtraRepair' column (" + recordId + ").  Bulk upload ABORTED.";
														bulkUploadProccessed = false;
													}
													break;

												case "Cancelled":
													if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
													{
														lfsPointRepairsRow.Cancelled = (dataCellToUpper == "YES") ? true : false;
													}
													else
													{
														bulkUploadResultMessage = "Invalid value in 'Cancelled' column (" + recordId + ").  Bulk upload ABORTED.";
														bulkUploadProccessed = false;
													}
													break;

												case "Approved":
													if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
													{
														lfsPointRepairsRow.Approved = (dataCellToUpper == "YES") ? true : false;
													}
													else
													{
														bulkUploadResultMessage = "Invalid value in 'Approved' column (" + recordId + ").  Bulk upload ABORTED.";
														bulkUploadProccessed = false;
													}
													break;

												case "NotApproved":
													if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
													{
														lfsPointRepairsRow.NotApproved = (dataCellToUpper == "YES") ? true : false;
													}
													else
													{
														bulkUploadResultMessage = "Invalid value in 'NotApproved' column (" + recordId + ").  Bulk upload ABORTED.";
														bulkUploadProccessed = false;
													}
													break;

												default:
													bulkUploadResultMessage = "Invalid column name '" + dataReader2.GetName(i) + "' in lfs_point_repairs data range.";
													bulkUploadProccessed = false;
													break;
											}

											if (!bulkUploadProccessed)
											{
												break;
											}
										}

										#endregion

										tdsLfsRecord.LFS_POINT_REPAIRS.AddLFS_POINT_REPAIRSRow(lfsPointRepairsRow);

										if (!bulkUploadProccessed)
										{
											break;
										}
									}
								}

								dataReader2.Close();
								connection2.Close();
							}


							//--- ... fill lfs junction liner rows
							if (cbxUploadLfsJunctionLiner.Checked)
							{
								connection2.Open();
								command2 = new OleDbCommand("select * from [lfs_junction_liner] where ID = '" + recordId + "'", connection2);
								dataReader2 = command2.ExecuteReader();

								while (dataReader2.Read())
								{
									if (!IsEmptyRow(dataReader))
									{
										TDSLFSRecord.LFS_JUNCTION_LINERRow lfsJunctionLinerRow = tdsLfsRecord.LFS_JUNCTION_LINER.NewLFS_JUNCTION_LINERRow();

										#region fill lfsJunctionLinerRow

										lfsJunctionLinerRow.ID = lfsMasterAreaRow.ID;
										lfsJunctionLinerRow.RefID = Generator.GetNewLfsJunctionLinerRefId(tdsLfsRecord);
										lfsJunctionLinerRow.COMPANY_ID = Convert.ToInt32(Session["companyID"]);
										lfsJunctionLinerRow.DetailID = Generator.GetNewLfsJunctionLinerDetailId(tdsLfsRecord);
										lfsJunctionLinerRow.CleanoutRequired = false;
										lfsJunctionLinerRow.PitRequired = false;
										lfsJunctionLinerRow.MHShot = false;
										lfsJunctionLinerRow.CleanoutInstalled = false;
										lfsJunctionLinerRow.PitInstalled = false;
										lfsJunctionLinerRow.CleanoutGrouted = false;
										lfsJunctionLinerRow.CleanoutCored = false;
										lfsJunctionLinerRow.RestorationComplete = false;
										lfsJunctionLinerRow.LinerOrdered = false;
										lfsJunctionLinerRow.LinerInStock = false;
										lfsJunctionLinerRow.Deleted = false;
										lfsJunctionLinerRow.Archived = false;
										
										for (int i=0; i < dataReader2.FieldCount; i++)
										{
											dataCell = dataReader2.GetValue(i).ToString().Trim();
											dataCellToUpper = dataReader2.GetValue(i).ToString().Trim().ToUpper();

											switch (dataReader2.GetName(i).Trim())
											{
												case "ID":
													break;

												case "MN": 
													if (dataCellToUpper != "NULL")
													{
														lfsJunctionLinerRow.MN = dataCell;
													}
													else
													{
														lfsJunctionLinerRow.SetMNNull();
													}
													break;

												case "DistanceFromUSMH":
													if (dataCellToUpper != "NULL")
													{
														if (Validator.IsValidDouble(dataCell))
														{
															lfsJunctionLinerRow.DistanceFromUSMH = Double.Parse(dataCell);
														}
														else
														{
															bulkUploadResultMessage = "Invalid value in 'DistanceFromUSMH' column (" + recordId + ").  Bulk upload ABORTED.";
															bulkUploadProccessed = false;
														}
													}
													else
													{
														lfsJunctionLinerRow.SetDistanceFromUSMHNull();
													}
													break;

												case "ConfirmedLatSize": 
													if (dataCellToUpper != "NULL")
													{
														lfsJunctionLinerRow.ConfirmedLatSize = dataCell;
													}
													else
													{
														lfsJunctionLinerRow.SetConfirmedLatSizeNull();
													}
													break;

												case "LateralMaterial": 
													if (dataCellToUpper != "NULL")
													{
														lfsJunctionLinerRow.LateralMaterial = dataCell;
													}
													else
													{
														lfsJunctionLinerRow.SetLateralMaterialNull();
													}
													break;

												case "SharedLateral":
													if (dataCellToUpper != "NULL")
													{
														if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
														{
															lfsJunctionLinerRow.SharedLateral = (dataCellToUpper == "YES") ? "Yes" : "No";
														}
														else
                                                        {
															bulkUploadResultMessage = "Invalid value in 'SharedLateral' column (" + recordId + ").  Bulk upload ABORTED.";
															bulkUploadProccessed = false;
														}								
													}
													else
													{
														lfsJunctionLinerRow.SetSharedLateralNull();
													}
													break;

												case "CleanoutRequired":
													if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
													{
														lfsJunctionLinerRow.CleanoutRequired = (dataCellToUpper == "YES") ? true : false;
													}
													else
													{
														bulkUploadResultMessage = "Invalid value in 'CleanoutRequired' column (" + recordId + ").  Bulk upload ABORTED.";
														bulkUploadProccessed = false;
													}
													break;

												case "PitRequired":
													if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
													{
														lfsJunctionLinerRow.PitRequired = (dataCellToUpper == "YES") ? true : false;
													}
													else
													{
														bulkUploadResultMessage = "Invalid value in 'PitRequired' column (" + recordId + ").  Bulk upload ABORTED.";
														bulkUploadProccessed = false;
													}
													break;

												case "MHShot":
													if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
													{
														lfsJunctionLinerRow.MHShot = (dataCellToUpper == "YES") ? true : false;
													}
													else
													{
														bulkUploadResultMessage = "Invalid value in 'MHShot' column (" + recordId + ").  Bulk upload ABORTED.";
														bulkUploadProccessed = false;
													}
													break;

												case "MainConnection":
													if (dataCellToUpper != "NULL")
													{
														if ( (dataCellToUpper == "TEE") || (dataCellToUpper == "WEE") )
														{
															lfsJunctionLinerRow.MainConnection = (dataCellToUpper == "TEE") ? "Tee" : "Wee";
														}
														else
														{
															bulkUploadResultMessage = "Invalid value in 'MainConnection' column (" + recordId + ").  Bulk upload ABORTED.";
															bulkUploadProccessed = false;
														}								
													}
													else
													{
														lfsJunctionLinerRow.SetMainConnectionNull();
													}
													break;

												case "Transition":
													if (dataCellToUpper != "NULL")
													{
														if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
														{
															lfsJunctionLinerRow.Transition = (dataCellToUpper == "YES") ? "Yes" : "No";
														}
														else
														{
															bulkUploadResultMessage = "Invalid value in 'Transition' column (" + recordId + ").  Bulk upload ABORTED.";
															bulkUploadProccessed = false;
														}								
													}
													else
													{
														lfsJunctionLinerRow.SetTransitionNull();
													}
													break;

												case "CleanoutInstalled":
													if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
													{
														lfsJunctionLinerRow.CleanoutInstalled = (dataCellToUpper == "YES") ? true : false;
													}
													else
													{
														bulkUploadResultMessage = "Invalid value in 'CleanoutInstalled' column (" + recordId + ").  Bulk upload ABORTED.";
														bulkUploadProccessed = false;
													}
													break;

												case "PitInstalled":
													if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
													{
														lfsJunctionLinerRow.PitInstalled = (dataCellToUpper == "YES") ? true : false;
													}
													else
													{
														bulkUploadResultMessage = "Invalid value in 'PitInstalled' column (" + recordId + ").  Bulk upload ABORTED.";
														bulkUploadProccessed = false;
													}
													break;

												case "CleanoutGrouted":
													if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
													{
														lfsJunctionLinerRow.CleanoutGrouted = (dataCellToUpper == "YES") ? true : false;
													}
													else
													{
														bulkUploadResultMessage = "Invalid value in 'CleanoutGrouted' column (" + recordId + ").  Bulk upload ABORTED.";
														bulkUploadProccessed = false;
													}
													break;

												case "CleanoutCored":
													if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
													{
														lfsJunctionLinerRow.CleanoutCored = (dataCellToUpper == "YES") ? true : false;
													}
													else
													{
														bulkUploadResultMessage = "Invalid value in 'CleanoutCored' column (" + recordId + ").  Bulk upload ABORTED.";
														bulkUploadProccessed = false;
													}
													break;

												case "PrepCompleted":
													if (dataCellToUpper != "NULL")
													{
														if (Validator.IsValidDate(dataCell))
														{
															lfsJunctionLinerRow.PrepCompleted = DateTime.Parse(dataCell);
														}
														else
														{
															bulkUploadResultMessage = "Invalid value in 'PrepCompleted' column (" + recordId + ").  Bulk upload ABORTED.";
															bulkUploadProccessed = false;
														}
													}
													else
													{
														lfsJunctionLinerRow.SetPrepCompletedNull();
													}
													break;

												case "MeasuredLatLength": 
													if (dataCellToUpper != "NULL")
													{
														lfsJunctionLinerRow.MeasuredLatLength = dataCell;
													}
													else
													{
														lfsJunctionLinerRow.SetMeasuredLatLengthNull();
													}
													break;

												case "MeasurementsTakenBy": 
													if (dataCellToUpper != "NULL")
													{
														lfsJunctionLinerRow.MeasurementsTakenBy = dataCell;
													}
													else
													{
														lfsJunctionLinerRow.SetMeasurementsTakenByNull();
													}
													break;

												case "LinerInstalled":
													if (dataCellToUpper != "NULL")
													{
														if (Validator.IsValidDate(dataCell))
														{
															lfsJunctionLinerRow.LinerInstalled = DateTime.Parse(dataCell);
														}
														else
														{
															bulkUploadResultMessage = "Invalid value in 'LinerInstalled' column (" + recordId + ").  Bulk upload ABORTED.";
															bulkUploadProccessed = false;
														}
													}
													else
													{
														lfsJunctionLinerRow.SetLinerInstalledNull();
													}
													break;

												case "FinalVideo":
													if (dataCellToUpper != "NULL")
													{
														if (Validator.IsValidDate(dataCell))
														{
															lfsJunctionLinerRow.FinalVideo = DateTime.Parse(dataCell);
														}
														else
														{
															bulkUploadResultMessage = "Invalid value in 'FinalVideo' column (" + recordId + ").  Bulk upload ABORTED.";
															bulkUploadProccessed = false;
														}
													}
													else
													{
														lfsJunctionLinerRow.SetFinalVideoNull();
													}
													break;

												case "RestorationComplete":
													if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
													{
														lfsJunctionLinerRow.RestorationComplete = (dataCellToUpper == "YES") ? true : false;
													}
													else
													{
														bulkUploadResultMessage = "Invalid value in 'RestorationComplete' column (" + recordId + ").  Bulk upload ABORTED.";
														bulkUploadProccessed = false;
													}
													break;

												case "LinerOrdered":
													if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
													{
														lfsJunctionLinerRow.LinerOrdered = (dataCellToUpper == "YES") ? true : false;
													}
													else
													{
														bulkUploadResultMessage = "Invalid value in 'LinerOrdered' column (" + recordId + ").  Bulk upload ABORTED.";
														bulkUploadProccessed = false;
													}
													break;

												case "LinerInStock":
													if ( (dataCellToUpper == "YES") || (dataCellToUpper == "NO") )
													{
														lfsJunctionLinerRow.LinerInStock = (dataCellToUpper == "YES") ? true : false;
													}
													else
													{
														bulkUploadResultMessage = "Invalid value in 'LinerInStock' column (" + recordId + ").  Bulk upload ABORTED.";
														bulkUploadProccessed = false;
													}
													break;

												case "LinerPrice":
													if (dataCellToUpper != "NULL")
													{
														if (Validator.IsValidDecimal(dataCell))
														{
															lfsJunctionLinerRow.LinerPrice = Decimal.Parse(dataCell);
														}
														else
														{
															bulkUploadResultMessage = "Invalid value in 'LinerPrice' column (" + recordId + ").  Bulk upload ABORTED.";
															bulkUploadProccessed = false;
														}
													}
													else
													{
														lfsJunctionLinerRow.SetLinerPriceNull();
													}
													break;

												case "Comments": 
													if (dataCellToUpper != "NULL")
													{
														lfsJunctionLinerRow.Comments = dataCell;
													}
													else
													{
														lfsJunctionLinerRow.SetCommentsNull();
													}
													break;

												default:
													bulkUploadResultMessage = "Invalid column name '" + dataReader2.GetName(i) + "' in lfs_junction_liner data range.";
													bulkUploadProccessed = false;
													break;
											}

											if (!bulkUploadProccessed)
											{
												break;
											}
										}

										#endregion

										tdsLfsRecord.LFS_JUNCTION_LINER.AddLFS_JUNCTION_LINERRow(lfsJunctionLinerRow);

										if (!bulkUploadProccessed)
										{
											break;
										}
									}
								}

								dataReader2.Close();
								connection2.Close();
							}


							//--- ... caculate data for record change tracking
							tdsLfsRecord2.Merge(tdsLfsRecord);
							tdsLfsRecord.Clear();

							if (!bulkUploadProccessed)
							{
								break;
							}
						}
					}

					dataReader.Close();
					connection.Close();


					//--- Insert bulk uploaded data in database
					if (bulkUploadProccessed)
					{
						//--- Update database
						LFSRecordGateway lfsRecordGateway = new LFSRecordGateway();
						lfsRecordGateway.UpdateRecord(tdsLfsRecord2);
					}
				}
			}
			catch(Exception ex)
			{
				if (!dataReader2.IsClosed)
				{
					dataReader2.Close();
				}

				if (connection2.State == ConnectionState.Open)
				{
					connection2.Close();
				}

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

		//
		// IsEmptyRow
		//
		private bool IsEmptyRow(OleDbDataReader dataReader)
		{
			bool empty = true;

			for (int i=0; i < dataReader.FieldCount; i++)
			{
				if (dataReader.GetValue(i).ToString() != "")
				{
					empty = false;
					break;
				}
			}

			return empty;
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

		}
		#endregion


	}
}
