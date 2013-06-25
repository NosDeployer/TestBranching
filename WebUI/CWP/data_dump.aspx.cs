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
using System.Data.SqlClient;
using System.IO;
using LiquiForce.LFSLive.CWP.DatabaseGateway;

namespace LiquiForce.LFSLive.WebUI.CWP
{
	public partial class data_dump : System.Web.UI.Page
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
		// btnDump_Click
		//
		protected void btnDump_Click(object sender, System.EventArgs e)
		{
			//--- Prepare file name
			string physicalApplicationPath = Request.PhysicalApplicationPath;
			if (Request.PhysicalApplicationPath.Substring(Request.PhysicalApplicationPath.Length-1, 1) != "\\")
			{
				physicalApplicationPath += "\\";
			}
				
			string fName = "";
			switch (ddlTable.SelectedValue)
			{
				case "Master area":
					fName = physicalApplicationPath + "export\\master_area.csv";
					break;

				case "Point repairs":
					fName = physicalApplicationPath + "export\\point_repairs.csv";
					break;

				case "M2 Tables":
					fName = physicalApplicationPath + "export\\m2_tables.csv";
					break;

				case "Junction Liners":
					fName = physicalApplicationPath + "export\\junction_liners.csv";
					break;
			}

			//--- Export
			switch (ddlTable.SelectedValue)
			{
				case "Master area":
					this.ExportMasterArea(fName, cbxIncludeArchivedRecords.Checked, Convert.ToInt32(Session["companyID"]));
					break;

				case "Point repairs":
					this.ExportPointRepairs(fName, cbxIncludeArchivedRecords.Checked, Convert.ToInt32(Session["companyID"]));
					break;

				case "M2 Tables":
					this.ExportM2Tables(fName, cbxIncludeArchivedRecords.Checked, Convert.ToInt32(Session["companyID"]));
					break;

				case "Junction Liners":
					this.ExportJunctionLiners(fName, cbxIncludeArchivedRecords.Checked, Convert.ToInt32(Session["companyID"]));
					break;
			}

			//--- Download
			Response.AppendHeader("Content-Type", "text/csv");
			Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(fName));
			Response.AppendHeader("Content-Description", "LFS Combined Work Program Data Dump");
			Response.WriteFile(fName);
			Response.End();
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// ExportMasterArea
		//
		public void ExportMasterArea(string fName, bool includeArchivedRecords, int companyId)
		{
			//--- Initialize
			StreamWriter streamWriter = null;
			SqlDataReader dataReader = null;

			//--- Prepare

			//--- ... Connection
			AppSettingsReader appSettingReader = new AppSettingsReader();
			string ConnectionString = appSettingReader.GetValue("ConnectionString", typeof(System.String)).ToString();
			SqlConnection connection = new SqlConnection(ConnectionString);

			//--- ... Command
            string commandText = "SELECT MA.RecordID, MA.ClientID, MA.COMPANIES_ID, C.NAME AS Client, MA.SubArea, MA.Street, MA.USMH, MA.DSMH, MA.Size_, MA.ScaledLength, MA.P1Date, MA.ActualLength, MA.LiveLats, MA.CXIsRemoved, MA.M1Date, MA.M2Date, MA.InstallDate, MA.FinalVideo, MA.IssueIdentified, MA.IssueResolved, MA.FullLengthLining, MA.SubcontractorLining, MA.OutOfScopeInArea, MA.IssueGivenToBayCity, MA.ConfirmedSize, MA.InstallRate, MA.DeadlineDate, MA.ProposedLiningDate, MA.SalesIssue, MA.LFSIssue, MA.ClientIssue, MA.InvestigationIssue, MA.PointLining, MA.Grouting, MA.LateralLining, MA.VacExDate, MA.PusherDate, MA.LinerOrdered, MA.Restoration, MA.GroutDate, MA.JLiner, MA.RehabAssessment, MA.EstimatedJoints, MA.JointsTestSealed, MA.PreFlushDate, MA.PreVideoDate, MA.USMHMN, MA.DSMHMN, MA.USMHDepth, MA.DSMHDepth, MA.MeasurementsTakenBy, MA.SteelTapeThruPipe, MA.USMHAtMouth1200, MA.USMHAtMouth100, MA.USMHAtMouth200, MA.USMHAtMouth300, MA.USMHAtMouth400, MA.USMHAtMouth500, MA.DSMHAtMouth1200, MA.DSMHAtMouth100, MA.DSMHAtMouth200, MA.DSMHAtMouth300, MA.DSMHAtMouth400, MA.DSMHAtMouth500, MA.HydrantAddress, MA.DistanceToInversionMH, MA.RampsRequired, MA.DegreeOfTrafficControl, MA.StandarBypass, MA.HydroWireDetails, MA.PipeMaterialType, MA.CappedLaterals, MA.RoboticPrepRequired, MA.PipeSizeChange, MA.VideoDoneFrom, MA.ToManhole, MA.CutterDescriptionDuringMeasuring, MA.FullLengthPointLiner, MA.BypassRequired, MA.RoboticDistances, MA.LineWithID, MA.SchoolZone, MA.RestaurantArea, MA.CarwashLaundromat, MA.HydroPulley, MA.FridgeCart, MA.TwoInchPump, MA.SixInchBypass, MA.Scaffolding, MA.WinchExtension, MA.ExtraGenerator, MA.GreyCableExtension, MA.EasementMats, MA.MeasurementType, MA.DropPipe, MA.DropPipeInvertDepth, MA.MeasuredFromManhole, MA.MainLined, MA.BenchingIssue, MA.History, MA.NumLats, MA.NotLinedYet, MA.AllMeasured, MA.City, MA.ProvState FROM LFS_MASTER_AREA AS MA INNER JOIN LFS_RESOURCES_COMPANIES AS C ON MA.COMPANIES_ID = C.COMPANIES_ID WHERE (MA.COMPANY_ID = @companyId) AND (MA.Deleted = 0)";
			if (!includeArchivedRecords)
			{
				commandText = commandText + " AND (MA.Archived = 0)";
			}
			commandText = commandText + " ORDER BY MA.RecordID";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			
			//--- Export
			try
			{
				streamWriter = new StreamWriter(fName);
				
				streamWriter.WriteLine("ID,ClientID,COMPANIES_ID,Client,SubArea,Street,USMH,DSMH,Size_,ScaledLength,P1Date,ActualLength,LiveLats,CXIsRemoved,M1Date,M2Date,InstallDate,FinalVideo,IssueIdentified,IssueResolved,FullLengthLining,SubcontractorLining,OutOfScopeInArea,IssueGivenToBayCity,ConfirmedSize,InstallRate,DeadlineDate,ProposedLiningDate,SalesIssue,LFSIssue,ClientIssue,InvestigationIssue,PointLining,Grouting,LateralLining,VacExDate,PusherDate,LinerOrdered,Restoration,GroutDate,JLiner,RehabAssessment,EstimatedJoints,JointsTestSealed,PreFlushDate,PreVideoDate,USMHMN,DSMHMN,USMHDepth,DSMHDepth,MeasurementsTakenBy,SteelTapeThruPipe,USMHAtMouth1200,USMHAtMouth100,USMHAtMouth200,USMHAtMouth300,USMHAtMouth400,USMHAtMouth500,DSMHAtMouth1200,DSMHAtMouth100,DSMHAtMouth200,DSMHAtMouth300,DSMHAtMouth400,DSMHAtMouth500,HydrantAddress,DistanceToInversionMH,RampsRequired,DegreeOfTrafficControl,StandarBypass,HydroWireDetails,PipeMaterialType,CappedLaterals,RoboticPrepRequired,PipeSizeChange,VideoDoneFrom,ToManhole,CutterDescriptionDuringMeasuring,FullLengthPointLiner,BypassRequired,RoboticDistances,LineWithID,SchoolZone,RestaurantArea,CarwashLaundromat,HydroPulley,FridgeCart,TwoInchPump,SixInchBypass,Scaffolding,WinchExtension,ExtraGenerator,GreyCableExtension,EasementMats,MeasurementType,DropPipe,DropPipeInvertDepth,MeasuredFromManhole,MainLined,BenchingIssue,History,NumLats,NotLinedYet,AllMeasured,City,ProvState");
				connection.Open();
				dataReader = command.ExecuteReader();
				while (dataReader.Read())
				{
					for (int i=0; i<dataReader.FieldCount; i++)
					{
						if (i < dataReader.FieldCount-1)
						{
							if (!dataReader.IsDBNull(i))
							{
								streamWriter.Write(dataReader[i].ToString() + ",");
							}
							else
							{
								streamWriter.Write("NULL" + ",");
							}
						}
						else
						{
							if (!dataReader.IsDBNull(i))
							{
								streamWriter.WriteLine(dataReader[i].ToString());
							}
							else
							{
								streamWriter.WriteLine("NULL");
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Response.Redirect("./../error_page.aspx?error=" + ex.Message);
			}
			finally
			{
				streamWriter.Flush();
				streamWriter.Close();
				dataReader.Close();
				connection.Close();
			}
		}

		//
		// ExportPointRepairs
		//
		public void ExportPointRepairs(string fName, bool includeArchivedRecords, int companyId)
		{
			//--- Initialize
			StreamWriter streamWriter = null;
			SqlDataReader dataReader = null;

			//--- Prepare

			//--- ... Connection
			AppSettingsReader appSettingReader = new AppSettingsReader();
			string ConnectionString = appSettingReader.GetValue("ConnectionString", typeof(System.String)).ToString();
			SqlConnection connection = new SqlConnection(ConnectionString);

			//--- ... Command
			string commandText = "SELECT LFS_MASTER_AREA.RecordID, LFS_POINT_REPAIRS.DetailID, LFS_POINT_REPAIRS.RepairSize, LFS_POINT_REPAIRS.InstallDate, LFS_POINT_REPAIRS.Distance, LFS_POINT_REPAIRS.Cost, LFS_POINT_REPAIRS.Reinstates, LFS_POINT_REPAIRS.LTAtMH, LFS_POINT_REPAIRS.VTAtMH, LFS_POINT_REPAIRS.LinerDistance, LFS_POINT_REPAIRS.Direction, LFS_POINT_REPAIRS.MHShot, LFS_POINT_REPAIRS.ExtraRepair, LFS_POINT_REPAIRS.Cancelled, LFS_POINT_REPAIRS.Approved, LFS_POINT_REPAIRS.NotApproved FROM LFS_MASTER_AREA INNER JOIN LFS_POINT_REPAIRS ON LFS_MASTER_AREA.ID = LFS_POINT_REPAIRS.ID AND LFS_MASTER_AREA.COMPANY_ID = LFS_POINT_REPAIRS.COMPANY_ID WHERE (LFS_MASTER_AREA.COMPANY_ID = @companyId) AND (LFS_MASTER_AREA.Deleted = 0) AND (LFS_POINT_REPAIRS.Deleted = 0)";
			if (!includeArchivedRecords)
			{
				commandText = commandText + " AND (LFS_POINT_REPAIRS.Archived = 0)";
			}
			commandText = commandText + " ORDER BY LFS_MASTER_AREA.RecordID, LFS_POINT_REPAIRS.DetailID";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			
			//--- Export
			try
			{
				streamWriter = new StreamWriter(fName);
				
				streamWriter.WriteLine("ID,DetailID,RepairSize,InstallDate,Distance,Cost,Reinstates,LTAtMH,VTAtMH,LinerDistance,Direction,MHShot,ExtraRepair,Cancelled,Approved,NotApproved");
				
				connection.Open();
				dataReader = command.ExecuteReader();
				while (dataReader.Read())
				{
					for (int i=0; i<dataReader.FieldCount; i++)
					{
						if (i < dataReader.FieldCount-1)
						{
							if (!dataReader.IsDBNull(i))
							{
								streamWriter.Write(dataReader[i].ToString() + ",");
							}
							else
							{
								streamWriter.Write("NULL" + ",");
							}
						}
						else
						{
							if (!dataReader.IsDBNull(i))
							{
								streamWriter.WriteLine(dataReader[i].ToString());
							}
							else
							{
								streamWriter.WriteLine("NULL");
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Response.Redirect("./../error_page.aspx?error=" + ex.Message);
			}
			finally
			{
				streamWriter.Flush();
				streamWriter.Close();
				dataReader.Close();
				connection.Close();
			}
		}

		//
		// ExportM2Tables
		//
		public void ExportM2Tables(string fName, bool includeArchivedRecords, int companyId)
		{
			//--- Initialize
			StreamWriter streamWriter = null;
			SqlDataReader dataReader = null;

			//--- Prepare

			//--- ... Connection string
			AppSettingsReader appSettingReader = new AppSettingsReader();
			string ConnectionString = appSettingReader.GetValue("ConnectionString", typeof(System.String)).ToString();
			SqlConnection connection = new SqlConnection(ConnectionString);

			//--- ... Command
			string commandText = "SELECT LFS_MASTER_AREA.RecordID, LFS_M2_TABLES.RefID, LFS_M2_TABLES.COMPANY_ID, LFS_M2_TABLES.VideoDistance, LFS_M2_TABLES.ClockPosition, LFS_M2_TABLES.LiveOrAbandoned, LFS_M2_TABLES.DistanceToCentreOfLateral, LFS_M2_TABLES.LateralDiameter, LFS_M2_TABLES.LateralType, LFS_M2_TABLES.DateTimeOpened, LFS_M2_TABLES.ReverseSetup FROM LFS_MASTER_AREA INNER JOIN LFS_M2_TABLES ON (LFS_MASTER_AREA.ID = LFS_M2_TABLES.ID) AND (LFS_MASTER_AREA.COMPANY_ID = LFS_M2_TABLES.COMPANY_ID) WHERE (LFS_MASTER_AREA.COMPANY_ID = @companyId)AND (LFS_MASTER_AREA.Deleted = 0) AND (LFS_M2_TABLES.Deleted = 0)";
			if (!includeArchivedRecords)
			{
				commandText = commandText + " AND (LFS_M2_TABLES.Archived = 0)";
			}
			commandText = commandText + " ORDER BY LFS_MASTER_AREA.RecordID, LFS_M2_TABLES.RefID";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			
			//--- Export
			try
			{
				streamWriter = new StreamWriter(fName);
				
				streamWriter.WriteLine("ID,RefID,COMPANY_ID,VideoDistance,ClockPosition,LiveOrAbandoned,DistanceToCentreOfLateral,LateralDiameter,LateralType,DateTimeOpened,ReverseSetup");

				connection.Open();
				dataReader = command.ExecuteReader();
				while (dataReader.Read())
				{
					for (int i=0; i<dataReader.FieldCount; i++)
					{
						if (i < dataReader.FieldCount-1)
						{
							if (!dataReader.IsDBNull(i))
							{
								streamWriter.Write(dataReader[i].ToString() + ",");
							}
							else
							{
								streamWriter.Write("NULL" + ",");
							}
						}
						else
						{
							if (!dataReader.IsDBNull(i))
							{
								streamWriter.WriteLine(dataReader[i].ToString());
							}
							else
							{
								streamWriter.WriteLine("NULL");
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Response.Redirect("./../error_page.aspx?error=" + ex.Message);
			}
			finally
			{
				streamWriter.Flush();
				streamWriter.Close();
				dataReader.Close();
				connection.Close();
			}
		}

		//
		// ExportJunctionLiners
		//
		public void ExportJunctionLiners(string fName, bool includeArchivedRecords, int companyId)
		{
			//--- Initialize
			StreamWriter streamWriter = null;
			SqlDataReader dataReader = null;

			//--- Prepare

			//--- ... Connection
			AppSettingsReader appSettingReader = new AppSettingsReader();
			string ConnectionString = appSettingReader.GetValue("ConnectionString", typeof(System.String)).ToString();
			SqlConnection connection = new SqlConnection(ConnectionString);

			//--- ... Command
			string commandText = "SELECT LFS_MASTER_AREA.RecordID, LFS_JUNCTION_LINER.DetailID, LFS_JUNCTION_LINER.MN, LFS_JUNCTION_LINER.DistanceFromUSMH, LFS_JUNCTION_LINER.ConfirmedLatSize, LFS_JUNCTION_LINER.LateralMaterial, LFS_JUNCTION_LINER.SharedLateral, LFS_JUNCTION_LINER.CleanoutRequired, LFS_JUNCTION_LINER.PitRequired, LFS_JUNCTION_LINER.MHShot, LFS_JUNCTION_LINER.MainConnection, LFS_JUNCTION_LINER.Transition, LFS_JUNCTION_LINER.CleanoutInstalled, LFS_JUNCTION_LINER.PitInstalled, LFS_JUNCTION_LINER.CleanoutGrouted, LFS_JUNCTION_LINER.CleanoutCored, LFS_JUNCTION_LINER.PrepCompleted, LFS_JUNCTION_LINER.MeasuredLatLength, LFS_JUNCTION_LINER.MeasurementsTakenBy, LFS_JUNCTION_LINER.LinerInstalled, LFS_JUNCTION_LINER.FinalVideo, LFS_JUNCTION_LINER.RestorationComplete, LFS_JUNCTION_LINER.LinerOrdered, LFS_JUNCTION_LINER.LinerInStock, LFS_JUNCTION_LINER.LinerPrice FROM LFS_MASTER_AREA INNER JOIN LFS_JUNCTION_LINER ON LFS_MASTER_AREA.ID = LFS_JUNCTION_LINER.ID AND LFS_MASTER_AREA.COMPANY_ID = LFS_JUNCTION_LINER.COMPANY_ID WHERE (LFS_MASTER_AREA.COMPANY_ID = @companyId) AND (LFS_MASTER_AREA.Deleted = 0) AND (LFS_JUNCTION_LINER.Deleted = 0)";
			if (!includeArchivedRecords)
			{
				commandText = commandText + " AND (LFS_JUNCTION_LINER.Archived = 0)";
			}
			commandText = commandText + " ORDER BY LFS_MASTER_AREA.RecordID, LFS_JUNCTION_LINER.DetailID";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			
			//--- Export
			try
			{
				streamWriter = new StreamWriter(fName);
				
				streamWriter.WriteLine("ID,DetailID,MN,DistanceFromUSMH,ConfirmedLatSize,LateralMaterial,SharedLateral,CleanoutRequired,PitRequired,MHShot,MainConnection,Transition,CleanoutInstalled,PitInstalled,CleanoutGrouted,CleanoutCored,PrepCompleted,MeasuredLatLength,MeasurementsTakenBy,LinerInstalled,FinalVideo,RestorationComplete,LinerOrdered,LinerInStock,LinerPrice");
				
				connection.Open();
				dataReader = command.ExecuteReader();
				while (dataReader.Read())
				{
					for (int i=0; i<dataReader.FieldCount; i++)
					{
						if (i < dataReader.FieldCount-1)
						{
							if (!dataReader.IsDBNull(i))
							{
								streamWriter.Write(dataReader[i].ToString() + ",");
							}
							else
							{
								streamWriter.Write("NULL" + ",");
							}
						}
						else
						{
							if (!dataReader.IsDBNull(i))
							{
								streamWriter.WriteLine(dataReader[i].ToString());
							}
							else
							{
								streamWriter.WriteLine("NULL");
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Response.Redirect("./../error_page.aspx?error=" + ex.Message);
			}
			finally
			{
				streamWriter.Flush();
				streamWriter.Close();
				dataReader.Close();
				connection.Close();
			}
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
