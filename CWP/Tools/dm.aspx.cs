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
using LFS.DatabaseGateway;

namespace LFS.Tools
{
	public partial class dm1 : System.Web.UI.Page
	{
		private string ConnectionString;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!(Convert.ToBoolean(Session["sgLFS_APP_ADMIN"])))
			{
				throw new Exception("You are not authorized to view this page. Contact your system administrator.");
			}

			AppSettingsReader appSettingReader = new AppSettingsReader();
			ConnectionString = appSettingReader.GetValue("ConnectionString", typeof(System.String)).ToString();

			if (IsPostBack)
			{
				this.Button1.Visible=false;
				this.Button2.Visible=false;
				this.Button3.Visible=false;
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

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			int newRefId;

			SqlConnection connection = new SqlConnection(ConnectionString);
			SqlConnection connection2 = new SqlConnection(ConnectionString);
			SqlConnection connection3 = new SqlConnection(ConnectionString);

			//SqlCommand command = new SqlCommand("SELECT ID FROM LFS_MASTER_AREA_TMP WHERE RecordId like 't%' AND COMPANY_ID = 3 order by ID", connection);
			SqlCommand command = new SqlCommand("SELECT ID FROM LFS_MASTER_AREA_TMP WHERE COMPANY_ID = 3 order by ID", connection);
			SqlCommand command2 = new SqlCommand("", connection2);
			SqlCommand command3 = new SqlCommand("", connection3);
			
			connection.Open();
			connection2.Open();
			connection3.Open();

			SqlDataReader dr = command.ExecuteReader();
			while (dr.Read())
			{
				command2.CommandText = "SELECT newid()";
				System.Guid newID = (System.Guid)command2.ExecuteScalar();

				command2.CommandText = "insert into lfs_master_area " + 
					                   "select '" + newID + "', COMPANY_ID, ID, ClientID, COMPANIES_ID, SubArea, Street, USMH, DSMH, Size_, ScaledLength, P1Date, ActualLength, LiveLats, CXIsRemoved, M1Date, M2Date, InstallDate, FinalVideo, Comments, IssueIdentified, IssueResolved, FullLengthLining, SubcontractorLining, " +
					                   "OutOfScopeInArea, IssueGivenToBayCity, ConfirmedSize, InstallRate, DeadlineDate, ProposedLiningDate, SalesIssue, LFSIssue, ClientIssue, InvestigationIssue, PointLining, Grouting, LateralLining, VacExDate, PusherDate, LinerOrdered, Restoration, GroutDate, JLiner, RehabAssessment, " +
					                   "EstimatedJoints, JointsTestSealed, PreFlushDate, PreVideoDate, USMHMN, DSMHMN, USMHDepth, DSMHDepth, MeasurementsTakenBy, SteelTapeThruPipe, USMHAtMouth1200, USMHAtMouth100, USMHAtMouth200, USMHAtMouth300, USMHAtMouth400, USMHAtMouth500, DSMHAtMouth1200, DSMHAtMouth100, " +
					                   "DSMHAtMouth200, DSMHAtMouth300, DSMHAtMouth400, DSMHAtMouth500, HydrantAddress, DistanceToInversionMH, RampsRequired, DegreeOfTrafficControl, StandarBypass, HydroWireDetails, PipeMaterialType, CappedLaterals, RoboticPrepRequired, PipeSizeChange, M1Comments, VideoDoneFrom, " +
					                   "ToManhole, CutterDescriptionDuringMeasuring, FullLengthPointLiner, BypassRequired, RoboticDistances, TrafficControlDetails, LineWithID, SchoolZone, RestaurantArea, CarwashLaundromat, HydroPulley, FridgeCart, TwoInchPump, SixInchBypass, Scaffolding, WinchExtension, ExtraGenerator, " + 
					                   "GreyCableExtension, EasementMats, MeasurementType, DropPipe, DropPipeInvertDepth, LastModified, Deleted, Locked " + 
					                   "from lfs_master_area_tmp where ID = '" + dr["ID"] + "'";
				command2.ExecuteNonQuery();

				newRefId = 1;
				command2.CommandText = "select ID, RefID from lfs_point_repairs_tmp where id = '" + dr["ID"] +"' order by RefID";
				SqlDataReader dr2 = command2.ExecuteReader();
				while (dr2.Read())
				{
					command3.CommandText = "insert into lfs_point_repairs " +
						                   "select '" + newID + "', " + newRefId + ", COMPANY_ID, RefID, RepairSize, InstallDate, Distance, Cost, Reinstates, LTAtMH, VTAtMH, LinerDistance, Direction, MHShot, Comments, LastModified, Deleted " + 
									       "from lfs_point_repairs_tmp where ID = '" + dr2["ID"] +"' and RefID = '" + dr2["RefID"] + "'";
					command3.ExecuteNonQuery();

					newRefId++;
				}
				dr2.Close();

				command2.CommandText = "insert into lfs_m2_tables " + 
									   "select '" + newID + "', RefID, COMPANY_ID, VideoDistance, ClockPosition, LiveOrAbandoned, DistanceToCentreOfLateral, LateralDiameter, LateralType, DateTimeOpened, Comments, ReverseSetup, LastModified, Deleted " +
									   "from lfs_m2_tables_tmp where id = '" + dr["ID"] +"'";
				command2.ExecuteNonQuery();

				Response.Write(dr["ID"] + "  <br>");
			}
			dr.Close();

			connection3.Close();
			connection2.Close();
			connection.Close();	

			Response.Write("<br>Data migrated successfully!");
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);
			SqlConnection connection2 = new SqlConnection(ConnectionString);
			SqlConnection connection3 = new SqlConnection(ConnectionString);

			SqlCommand command = new SqlCommand("", connection);
			SqlCommand command2 = new SqlCommand("", connection2);
			SqlCommand command3 = new SqlCommand("", connection3);
			
			// Preliminar validation
			bool abort = false;

			connection.Open();
			command.CommandText = "select recordid from lfs_master_area where actuallength <> steeltapethrupipe order by recordid";
			SqlDataReader dr = command.ExecuteReader();
			if (dr.HasRows)
			{
				abort = true;
				Response.Write("The following records have different values in ActualLength and SteelTapeThruPipe: <br>");
			}

			while (dr.Read())
			{
				Response.Write(dr["recordid"].ToString() + "<br>");
			}
			dr.Close();
			connection.Close();

			if (abort) return;

			// Sync actuallenght, steeltapethrupipe, and reversesetup
			connection.Open();
			connection2.Open();
			connection3.Open();
			
			Response.Write("Synchronizing ActualLength - SteelTapeThruPipe - ReverseSetup <br>");

			//command.CommandText = "select id, recordid, actuallength, steeltapethrupipe from lfs_master_area where recordid like 't%' order by recordid";
			command.CommandText = "select id, recordid, actuallength, steeltapethrupipe from lfs_master_area order by recordid";
			dr = command.ExecuteReader();
			while (dr.Read())
			{
				// ... Sync ActualLength-SteelTapeThruPipe
				string actualLength = dr.IsDBNull(dr.GetOrdinal("actuallength")) ? "null" : (string)dr["actuallength"];
				string steelTapeThruPipe = dr.IsDBNull(dr.GetOrdinal("steeltapethrupipe")) ? "null" : (string)dr["steeltapethrupipe"];

				if ((actualLength == steelTapeThruPipe) && (actualLength != "null"))
				{
					actualLength = (string)dr["actuallength"];
				} 
				else if ((actualLength == "null") && (steelTapeThruPipe == "null"))
				{
					actualLength = "";
				}
				else if (actualLength == "null")
				{
					command3.CommandText = "update lfs_master_area set actuallength = '" + ((string)dr["steeltapethrupipe"]).Replace("'", "''") + "' where id = '" + dr["id"].ToString() + "' and company_id = 3";
					command3.ExecuteNonQuery();

					actualLength = (string)dr["steeltapethrupipe"];
				}
				else if (steelTapeThruPipe == "null")
				{
					command3.CommandText = "update lfs_master_area set steeltapethrupipe = '" + ((string)dr["actuallength"]).Replace("'", "''") + "' where id = '" + dr["id"].ToString() + "' and company_id = 3";
					command3.ExecuteNonQuery();

					actualLength = (string)dr["ActualLength"];
				}
				else
				{
					throw new Exception("Something went wrong A");
				}

				// ... Calc reverse setup
				command2.CommandText = "select refid, distancetocentreoflateral from lfs_m2_tables where id = '" + dr["id"].ToString() + "' and company_id = 3";
				SqlDataReader dr2 = command2.ExecuteReader();
				while (dr2.Read())
				{
					if (!dr2.IsDBNull(dr2.GetOrdinal("distancetocentreoflateral")))
					{
						string reverseSetup = Distance.Subtract(actualLength, (string)dr2["distancetocentreoflateral"] );
					
						command3.CommandText = "update lfs_m2_tables set reversesetup = '" + reverseSetup.Replace("'", "''") + "' where id = '" + dr["id"].ToString() + "' and refid = " + dr2["refid"].ToString() + " and company_id = 3";
						command3.ExecuteNonQuery();
					}
				}
				dr2.Close();

				Response.Write(dr["recordid"] + "  <br>");
			}
			dr.Close();

			connection3.Close();
			connection2.Close();
			connection.Close();	

			Response.Write("<br>Task successfully completed!");
		}

		protected void Button3_Click(object sender, System.EventArgs e)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);
			
			SqlCommand command = new SqlCommand("", connection);
			
			connection.Open();
			
			Response.Write("Initializing RCT tables... <br><br>");

			TDSLFSRecord originalData = new TDSLFSRecord();
			LFS.DatabaseGateway.LFSRecordGateway lfsRecordGateway = new LFSRecordGateway();

			//command.CommandText = "select id, recordid from lfs_master_area where recordid like 't%'order by recordid";
			command.CommandText = "select id, recordid from lfs_master_area order by recordid";
			SqlDataReader dr = command.ExecuteReader();
			while (dr.Read())
			{
				TDSLFSRecord currentData = lfsRecordGateway.GetRecordAndRCTByIdCompanyId((System.Guid)dr["id"], 3);

				TDSLFSRecord changes = RecordChangeTracking.GetChanges(originalData, currentData, 7);
				currentData.Merge(changes);

				try
				{
					lfsRecordGateway.UpdateRecord(currentData);
				}
				catch(Exception ex)
				{
					throw ex;
				}

				Response.Write(dr["recordid"] + "  <br>");
			}
			dr.Close();

			connection.Close();	

			Response.Write("<br>Task successfully completed!");
		}

	}
}
