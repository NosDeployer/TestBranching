using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LiquiForce.LFSLive.CWP.Reports
{
	public class LFSRecordForReportsGateway
	{
		///////////////////////////////////////////////////////////////////////////
		/// PROPERTIES AND FIELDS
		///

		//
		// Connection
		//
		private string ConnectionString;

		

		///////////////////////////////////////////////////////////////////////////
		/// CONSTRUCTORS
		///

		//
		// Default
		//
		public LFSRecordForReportsGateway()
		{
			//--- Get the connection string
			AppSettingsReader appSettingReader = new AppSettingsReader();
			ConnectionString = appSettingReader.GetValue("ConnectionString", typeof(System.String)).ToString();
		}

	

		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR CXIRemovedReport
		///

		//
		// GetCXIRemovedReportByCompanyId
		//
		public TDSCXIRemovedReport GetCXIRemovedReportByCompanyId(int companyId)
		{
			//--- Get data for CXIRemovedReport
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT ID, COMPANY_ID, Street, USMH, DSMH, Size_, P1Date, CXIsRemoved, RecordID FROM LFS_MASTER_AREA WHERE (COMPANY_ID = @companyId) AND (CXIsRemoved IS NOT NULL) AND (Deleted = 0) AND (Archived = 0) ORDER BY P1Date";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));

			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			TDSCXIRemovedReport dataSet = new TDSCXIRemovedReport();
			dataAdapter.Fill(dataSet, "CXIRemovedReport");
				
			//--- Return results
			return dataSet;
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR ReadyForLining
		///

		//
		// GetReadyForLiningByCompanyId
		//
		public TDSReadyForLining GetReadyForLiningByCompanyId(int companyId, bool all_clients, int companies_id)
		{
			//--- Get data for ReadyForLining
			SqlConnection connection = new SqlConnection(ConnectionString);

			if ((all_clients == true) && (companies_id == 0))
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.SubArea, m.Street, m.USMH, m.DSMH, m.ConfirmedSize, m.ActualLength, m.M2Date, m.LiveLats, m.Comments, m.IssueIdentified, m.IssueResolved, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.M2Date IS NOT NULL) AND (m.ID IN (SELECT ID FROM LFS_MASTER_AREA WHERE (FullLengthLining = 1) AND (IssueIdentified = 1) AND (IssueResolved = 1) OR (FullLengthLining = 1) AND (IssueIdentified = 0) AND (IssueResolved = 0))) AND (m.InstallDate IS NULL) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID"; 
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSReadyForLining dataSet = new TDSReadyForLining();
				dataAdapter.Fill(dataSet, "ReadyForLining");
				
				//--- Return results
				return dataSet;
			}
			else
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.SubArea, m.Street, m.USMH, m.DSMH, m.ConfirmedSize, m.ActualLength, m.M2Date, m.LiveLats, m.Comments, m.IssueIdentified, m.IssueResolved, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.M2Date IS NOT NULL) AND (m.ID IN (SELECT ID FROM LFS_MASTER_AREA WHERE (FullLengthLining = 1) AND (IssueIdentified = 1) AND (IssueResolved = 1) OR (FullLengthLining = 1) AND (IssueIdentified = 0) AND (IssueResolved = 0))) AND (m.InstallDate IS NULL) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSReadyForLining dataSet = new TDSReadyForLining();
				dataAdapter.Fill(dataSet, "ReadyForLining");
				
				//--- Return results
				return dataSet;
			}			
		}


		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR ToBePrepped
		///

		//
		// GetToBePreppedByCompanyId
		//
		public TDSToBePrepped GetToBePreppedByCompanyId(int companyId, bool all_clients, int companies_id)
		{
			//--- Get data for ToBePrepped
			SqlConnection connection = new SqlConnection(ConnectionString);

			if ((all_clients == true) && (companies_id == 0))
			{
				string commandText = "SELECT  m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.SubArea, m.Street, m.USMH, m.DSMH, m.Size_, m.ScaledLength, m.P1Date, m.Comments, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.ID IN (SELECT ID FROM LFS_MASTER_AREA WHERE (FullLengthLining = 1) AND (IssueIdentified = 1) AND (IssueResolved = 1) OR (FullLengthLining = 1) AND (IssueIdentified = 0) AND (IssueResolved = 0))) AND (m.P1Date IS NULL) AND (m.FullLengthLining = 1) AND (m.OutOfScopeInArea = 0) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID"; 
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSToBePrepped dataSet = new TDSToBePrepped();
				dataAdapter.Fill(dataSet, "ToBePrepped");
				
				//--- Return results
				return dataSet;
			}
			else
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.SubArea, m.Street, m.USMH, m.DSMH, m.Size_, m.ScaledLength, m.P1Date, m.Comments, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.P1Date IS NULL) AND (m.FullLengthLining = 1) AND (m.OutOfScopeInArea = 0) AND (m.ID IN (SELECT ID FROM LFS_MASTER_AREA WHERE (FullLengthLining = 1) AND (IssueIdentified = 1) AND (IssueResolved = 1) OR (FullLengthLining = 1) AND (IssueIdentified = 0) AND (IssueResolved = 0))) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID"; 
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSToBePrepped dataSet = new TDSToBePrepped();
				dataAdapter.Fill(dataSet, "ToBePrepped");
				
				//--- Return results
				return dataSet;
			}			
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR ToBeMeasured
		///

		//
		// GetToBeMeasuredByCompanyId
		//
		public TDSToBeMeasured GetToBeMeasuredByCompanyId(int companyId, bool all_clients, int companies_id)
		{
			//--- Get data for ToBeMeasured
			SqlConnection connection = new SqlConnection(ConnectionString);

			if ((all_clients == true) && (companies_id == 0))
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.SubArea, m.Street, m.USMH, m.DSMH, m.Size_, m.ConfirmedSize, m.ScaledLength, m.ActualLength, m.M1Date, m.M2Date, m.Comments, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.M1Date IS NULL) AND (m.M2Date IS NULL) AND (m.FullLengthLining = 1) AND (m.P1Date IS NOT NULL) AND (m.ID IN (SELECT ID FROM LFS_MASTER_AREA WHERE (FullLengthLining = 1) AND (IssueIdentified = 1) AND (IssueResolved = 1) OR (FullLengthLining = 1) AND (IssueIdentified = 0) AND (IssueResolved = 0))) AND (m.Deleted = 0) AND (m.Archived = 0) OR (m.M1Date IS NOT NULL) AND (m.M2Date IS NULL) AND (m.FullLengthLining = 1) AND (m.P1Date IS NOT NULL) AND (m.ID IN(SELECT ID FROM LFS_MASTER_AREA WHERE (FullLengthLining = 1) AND (IssueIdentified = 1) AND (IssueResolved = 1) OR (FullLengthLining = 1) AND (IssueIdentified = 0) AND (IssueResolved = 0))) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSToBeMeasured dataSet = new TDSToBeMeasured();
				dataAdapter.Fill(dataSet, "ToBeMeasured");
				
				//--- Return results
				return dataSet;
			}
			else
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.SubArea, m.Street, m.USMH, m.DSMH, m.Size_, m.ConfirmedSize, m.ScaledLength, m.ActualLength, m.M1Date, m.M2Date, m.Comments, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.M1Date IS NULL) AND (m.M2Date IS NULL) AND (m.FullLengthLining = 1) AND (m.P1Date IS NOT NULL) AND (m.ID IN (SELECT ID FROM LFS_MASTER_AREA WHERE (FullLengthLining = 1) AND (IssueIdentified = 1) AND (IssueResolved = 1) OR (FullLengthLining = 1) AND (IssueIdentified = 0) AND (IssueResolved = 0))) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) OR (m.M1Date IS NOT NULL) AND (m.M2Date IS NULL) AND (m.FullLengthLining = 1) AND (m.P1Date IS NOT NULL) AND (m.ID IN (SELECT ID FROM LFS_MASTER_AREA WHERE (FullLengthLining = 1) AND (IssueIdentified = 1) AND (IssueResolved = 1) OR (FullLengthLining = 1) AND (IssueIdentified = 0) AND (IssueResolved = 0))) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSToBeMeasured dataSet = new TDSToBeMeasured();
				dataAdapter.Fill(dataSet, "ToBeMeasured");
				
				//--- Return results
				return dataSet;
			}			
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR LiningCompleted
		///

		//
		// GetLiningCompletedByCompanyId
		//
		public TDSLiningCompleted GetLiningCompletedByCompanyId(int companyId, bool all_clients, int companies_id, DateTime startDate, DateTime endDate)
		{
			//--- Get data for LiningCompleted
			SqlConnection connection = new SqlConnection(ConnectionString);

			if ((all_clients == true) && (companies_id == 0))
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.Street, m.USMH, m.DSMH, m.ConfirmedSize, m.InstallDate, m.ActualLength, m.InstallRate, c.NAME, StartDate = '" + startDate.ToShortDateString() + "', EndDate = '" + endDate.ToShortDateString() +"' FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.ActualLength IS NOT NULL) AND (m.InstallDate BETWEEN CONVERT(DATETIME, '"+startDate.Month+"/"+startDate.Day+"/"+startDate.Year+" 00:00:00') AND CONVERT (DATETIME, '"+endDate.Month+"/"+endDate.Day+"/"+endDate.Year+" 23:59:59')) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.ConfirmedSize, m.InstallDate";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSLiningCompleted dataSet = new TDSLiningCompleted();
				dataAdapter.Fill(dataSet, "LiningCompleted");
				
				//--- Return results
				return dataSet;
			}
			else
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.Street, m.USMH, m.DSMH, m.ConfirmedSize, m.InstallDate, m.ActualLength, m.InstallRate, c.NAME, StartDate = '" + startDate.ToShortDateString() + "', EndDate = '" + endDate.ToShortDateString() +"' FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.ActualLength IS NOT NULL) AND (m.InstallDate BETWEEN CONVERT(DATETIME, '"+startDate.Month+"/"+startDate.Day+"/"+startDate.Year+" 00:00:00') AND CONVERT (DATETIME, '"+endDate.Month+"/"+endDate.Day+"/"+endDate.Year+" 23:59:59')) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.ConfirmedSize, m.InstallDate";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSLiningCompleted dataSet = new TDSLiningCompleted();
				dataAdapter.Fill(dataSet, "LiningCompleted");
				
				//--- Return results
				return dataSet;
			}			
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR OverviewReport
		///

		//
		// GetOverviewReportByCompanyId
		//
		public TDSOverviewReport GetOverviewReportByCompanyId(int companyId, bool all_clients, int companies_id)
		{
			//--- Get data for OverviewReport
			SqlConnection connection = new SqlConnection(ConnectionString);

			if ((all_clients == true) && (companies_id == 0))
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.ClientID, m.SubArea, m.Street, m.USMH, m.DSMH, m.Size_, m.ConfirmedSize, m.ScaledLength, m.ActualLength, m.P1Date, m.CXIsRemoved, m.LiveLats, m.M1Date, m.M2Date, m.InstallDate, m.FinalVideo, m.IssueIdentified, m.SalesIssue, m.LFSIssue, m.ClientIssue, m.IssueGivenToBayCity, m.IssueResolved, m.FullLengthLining, c.NAME, m.COMPANIES_ID, m.RecordID FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.FullLengthLining = 1) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSOverviewReport dataSet = new TDSOverviewReport();
				dataAdapter.Fill(dataSet, "OverviewReport");

				//--- Return results
				return dataSet;
			}
			else
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.ClientID, m.SubArea, m.Street, m.USMH, m.DSMH, m.Size_, m.ConfirmedSize, m.ScaledLength, m.ActualLength, m.P1Date, m.CXIsRemoved, m.LiveLats, m.M1Date, m.M2Date, m.InstallDate, m.FinalVideo, m.IssueIdentified, m.SalesIssue, m.LFSIssue, m.ClientIssue, m.IssueGivenToBayCity, m.IssueResolved, m.FullLengthLining, c.NAME, m.COMPANIES_ID, m.RecordID FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.FullLengthLining = 1) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSOverviewReport dataSet = new TDSOverviewReport();
				dataAdapter.Fill(dataSet, "OverviewReport");

				//--- Return results
				return dataSet;
			}
		}


		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR RehabAssessmentAreas
		///

		//
		// GetRehabAssessmentAreas
		//
		public TDSRehabAssessmentAreas GetRehabAssessmentAreasByCompanyId(int companyId, bool all_clients, int companies_id)
		{
			//--- Get data for RehabAssessmentAreas
			SqlConnection connection = new SqlConnection(ConnectionString);
			
			if ((all_clients == true) && (companies_id == 0))
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.ClientID, m.COMPANIES_ID, m.SubArea, m.Street, m.USMH, m.DSMH, m.Size_, m.ConfirmedSize, m.ScaledLength, m.ActualLength, m.PreFlushDate, m.PreVideoDate, m.Comments, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.RehabAssessment = 1) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				
				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSRehabAssessmentAreas dataSet = new TDSRehabAssessmentAreas();
				dataAdapter.Fill(dataSet, "RehabAssessmentAreas");

				//--- Return results
				return dataSet;
			}
			else
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.ClientID, m.COMPANIES_ID, m.SubArea, m.Street, m.USMH, m.DSMH, m.Size_, m.ConfirmedSize, m.ScaledLength, m.ActualLength, m.PreFlushDate, m.PreVideoDate, m.Comments, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.RehabAssessment = 1) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSRehabAssessmentAreas dataSet = new TDSRehabAssessmentAreas();
				dataAdapter.Fill(dataSet, "RehabAssessmentAreas");

				//--- Return results
				return dataSet;
			}
		}


		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR AllOutstandingIssues
		///

		//
		// GetAllOutstandingIssuestByCompanyId
		//
		public TDSAllOutstandingIssues GetAllOutstandingIssuesByCompanyId(int companyId, bool all_clients, int companies_id)
		{
			//--- Get data for AllOutstandingIssues
			SqlConnection connection = new SqlConnection(ConnectionString);

			if ((all_clients == true) && (companies_id == 0))
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.Street, m.USMH, m.DSMH, m.Comments, m.SalesIssue, m.LFSIssue, m.ClientIssue, m.InvestigationIssue, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.IssueIdentified = 1) AND (m.IssueResolved = 0) AND (m.Deleted = 0) AND (m.Archived = 0) OR (m.IssueResolved = 0) AND (m.IssueGivenToBayCity = 1) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSAllOutstandingIssues dataSet = new TDSAllOutstandingIssues();
				dataAdapter.Fill(dataSet, "AllOutstandingIssues");

				//--- Return results
				return dataSet;
			}
			else
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.Street, m.USMH, m.DSMH, m.Comments, m.SalesIssue, m.LFSIssue, m.ClientIssue, m.InvestigationIssue, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.IssueIdentified = 1) AND (m.IssueResolved = 0) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) OR (m.IssueResolved = 0) AND (m.IssueGivenToBayCity = 1) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSAllOutstandingIssues dataSet = new TDSAllOutstandingIssues();
				dataAdapter.Fill(dataSet, "AllOutstandingIssues");

				//--- Return results
				return dataSet;
			}
		}


		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR OutstandingClientIssues
		///

		//
		// GetOutstandingClientIssuesByCompanyId
		//
		public TDSOutstandingClientIssues GetOutstandingClientIssuesByCompanyId(int companyId, bool all_clients, int companies_id)
		{
			//--- Get data for OutstandingClientIssues
			SqlConnection connection = new SqlConnection(ConnectionString);

			if ((all_clients == true) && (companies_id == 0))
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.Street, m.USMH, m.DSMH, m.Comments, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.IssueIdentified = 1) AND (m.IssueResolved = 0) AND (m.ClientIssue = 1) AND (m.Deleted = 0) AND (m.Archived = 0) OR (m.IssueResolved = 0) AND (m.IssueGivenToBayCity = 1) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSOutstandingClientIssues dataSet = new TDSOutstandingClientIssues();
				dataAdapter.Fill(dataSet, "OutstandingClientIssues");

				//--- Return results
				return dataSet;
			}
			else
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.Street, m.USMH, m.DSMH, m.Comments, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.IssueIdentified = 1) AND (m.IssueResolved = 0) AND (m.ClientIssue = 1) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) OR (m.IssueResolved = 0) AND (m.IssueGivenToBayCity = 1) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSOutstandingClientIssues dataSet = new TDSOutstandingClientIssues();
				dataAdapter.Fill(dataSet, "OutstandingClientIssues");

				//--- Return results
				return dataSet;
			}
		}


		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR OutstandingLFSIssues
		///

		//
		// GetOutstandingLFSIssuesByCompanyId
		//
		public TDSOutstandingLFSIssues GetOutstandingLFSIssuesByCompanyId(int companyId, bool all_clients, int companies_id)
		{
			//--- Get data for OutstandingLFSIssues
			SqlConnection connection = new SqlConnection(ConnectionString);

			if ((all_clients == true) && (companies_id == 0))
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.Street, m.USMH, m.DSMH, m.Comments, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.IssueIdentified = 1) AND (m.IssueResolved = 0) AND (m.LFSIssue = 1) AND (m.Deleted = 0) AND (m.Archived = 0) OR (m.IssueResolved = 0) AND (m.Deleted = 0) AND (m.IssueGivenToBayCity = 1) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSOutstandingLFSIssues dataSet = new TDSOutstandingLFSIssues();
				dataAdapter.Fill(dataSet, "OutstandingLFSIssues");

				//--- Return results
				return dataSet;
			}
			else
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.Street, m.USMH, m.DSMH, m.Comments, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.IssueIdentified = 1) AND (m.IssueResolved = 0) AND (m.LFSIssue = 1) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) OR (m.IssueResolved = 0) AND (m.IssueGivenToBayCity = 1) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSOutstandingLFSIssues dataSet = new TDSOutstandingLFSIssues();
				dataAdapter.Fill(dataSet, "OutstandingLFSIssues");

				//--- Return results
				return dataSet;
			}
		}
		


		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR OutstandingInvestigationIssues
		///

		//
		// GetOutstandingInvestigationIssuesByCompanyId
		//
		public TDSOutstandingInvestigationIssues GetOutstandingInvestigacionIssuesByCompanyId(int companyId, bool all_clients, int companies_id)
		{
			//--- Get data for OutstandingInvestigationIssues
			SqlConnection connection = new SqlConnection(ConnectionString);

			if ((all_clients == true) && (companies_id == 0))
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.Street, m.USMH, m.DSMH, m.Comments, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.IssueIdentified = 1) AND (m.IssueResolved = 0) AND (m.InvestigationIssue = 1) AND (m.Deleted = 0) AND (m.Archived = 0) OR (m.IssueResolved = 0) AND (m.IssueGivenToBayCity = 1) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSOutstandingInvestigationIssues dataSet = new TDSOutstandingInvestigationIssues();
				dataAdapter.Fill(dataSet, "OutstandingInvestigationUssue");

				//--- Return results
				return dataSet;
			}
			else
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.Street, m.USMH, m.DSMH, m.Comments, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.IssueIdentified = 1) AND (m.IssueResolved = 0) AND (m.InvestigationIssue = 1) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) OR (m.IssueResolved = 0) AND (m.IssueGivenToBayCity = 1) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID ";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSOutstandingInvestigationIssues dataSet = new TDSOutstandingInvestigationIssues();
				dataAdapter.Fill(dataSet, "OutstandingInvestigationUssue");

				//--- Return results
				return dataSet;
			}
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR OutstandingSalesIssues
		///

		//
		// GetOutstandingSalesIssuesByCompanyId
		//     
		public TDSOutstandingSalesIssues GetOutstandingSalesIssuesByCompanyId(int companyId, bool all_clients, int companies_id)
		{
			//--- Get data for OutstandingSalesIssues
			SqlConnection connection = new SqlConnection(ConnectionString);

			if ((all_clients == true) && (companies_id == 0))
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.Street, m.USMH, m.DSMH, m.Comments, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.IssueIdentified = 1) AND (m.IssueResolved = 0) AND (m.SalesIssue = 1) AND (m.Deleted = 0) AND (m.Archived = 0) OR (m.IssueResolved = 0) AND (m.IssueGivenToBayCity = 1) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSOutstandingSalesIssues dataSet = new TDSOutstandingSalesIssues();
				dataAdapter.Fill(dataSet, "OutstandingSalesIssues");

				//--- Return results
				return dataSet;
			}
			else
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.Street, m.USMH, m.DSMH, m.Comments, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.IssueIdentified = 1) AND (m.IssueResolved = 0) AND (m.SalesIssue = 1) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) OR (m.IssueResolved = 0) AND (m.IssueGivenToBayCity = 1) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSOutstandingSalesIssues dataSet = new TDSOutstandingSalesIssues();
				dataAdapter.Fill(dataSet, "OutstandingSalesIssues");

				//--- Return results
				return dataSet;
			}
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR ClientInvestigationIssuesCityCopy
		///

		//
		// GetClientInvestigationIssuesCityCopyByCompanyId
		//     
		public TDSClientInvestigationIssuesCityCopy GetClientInvestigationIssuesCityCopyByCompanyId(int companyId, bool all_clients, int companies_id)
		{
			//--- Get data for ClientInvestigationIssuesCityCopy
			SqlConnection connection = new SqlConnection(ConnectionString);

			if ((all_clients == true) && (companies_id == 0))
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.Street, m.USMH, m.DSMH, m.Comments, m.ClientIssue, m.InvestigationIssue, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.IssueIdentified = 1) AND (m.IssueResolved = 0) AND (m.LFSIssue = 0) AND (m.Deleted = 0) AND (m.Archived = 0) OR (m.IssueResolved = 0) AND (m.IssueGivenToBayCity = 1) AND (m.LFSIssue = 0) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSClientInvestigationIssuesCityCopy dataSet = new TDSClientInvestigationIssuesCityCopy();
				dataAdapter.Fill(dataSet, "ClientInvestigationIssuesCityCopy");

				//--- Return results
				return dataSet;
			}
			else
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, m.Street, m.USMH, m.DSMH, m.Comments, m.ClientIssue, m.InvestigationIssue, c.NAME FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.IssueIdentified = 1) AND (m.IssueResolved = 0) AND (m.LFSIssue = 0) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) OR (m.IssueResolved = 0) AND (m.IssueGivenToBayCity = 1) AND (m.LFSIssue = 0) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSClientInvestigationIssuesCityCopy dataSet = new TDSClientInvestigationIssuesCityCopy();
				dataAdapter.Fill(dataSet, "ClientInvestigationIssuesCityCopy");

				//--- Return results
				return dataSet;
			}
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR PointLinerReport
		///

		//
		// GetPointLinerReportByCompanyId
		//     
		public TDSPointLinerReport GetPointLinerReportByCompanyId(int companyId, bool all_clients, int companies_id)
		{
			//--- Get data for PointLinerReport
			SqlConnection connection = new SqlConnection(ConnectionString);

			if ((all_clients == true) && (companies_id == 0))
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.ClientID, m.COMPANIES_ID, m.SubArea, m.Street, m.USMH, m.DSMH, m.P1Date, m.M1Date, m.FinalVideo, m.Comments, c.NAME, m.RecordID FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.IssueIdentified = 0) AND (m.PointLining = 1) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSPointLinerReport dataSet = new  TDSPointLinerReport();
				dataAdapter.Fill(dataSet, "PointLinerReport");

				commandText = "SELECT p.ID, p.RefID, p.COMPANY_ID, p.RepairSize, p.InstallDate, p.Distance, p.Reinstates, p.DetailID, p.ExtraRepair, p.Cancelled, p.Approved, p.NotApproved FROM LFS_MASTER_AREA m INNER JOIN LFS_POINT_REPAIRS p ON m.ID = p.ID AND m.COMPANY_ID = p.COMPANY_ID WHERE (m.COMPANY_ID = @companyId) AND (m.IssueIdentified = 0) AND (m.PointLining = 1) AND (m.Deleted = 0) AND (m.Archived = 0) AND (p.Deleted = 0) AND (p.Archived = 0) ORDER BY m.RecordID, p.DetailID";
				command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));

				SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command);

				dataAdapter1.Fill(dataSet, "LFS_POINT_REPAIRS");

				//--- Return results
				return dataSet;			
			}
			else
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.ClientID, m.COMPANIES_ID, m.SubArea, m.Street, m.USMH, m.DSMH, m.P1Date, m.M1Date, m.FinalVideo, m.Comments, c.NAME, m.RecordID FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.PointLining = 1) AND (m.IssueIdentified = 0) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSPointLinerReport dataSet = new  TDSPointLinerReport();
				dataAdapter.Fill(dataSet, "PointLinerReport");

				commandText = "SELECT p.ID, p.RefID, p.COMPANY_ID, p.RepairSize, p.InstallDate, p.Distance, p.Reinstates, p.DetailID, p.ExtraRepair, p.Cancelled, p.Approved, p.NotApproved FROM LFS_MASTER_AREA m INNER JOIN LFS_POINT_REPAIRS p ON m.ID = p.ID AND m.COMPANY_ID = p.COMPANY_ID WHERE (m.COMPANY_ID = @companyId) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.IssueIdentified = 0) AND (m.PointLining = 1) AND (m.Deleted = 0) AND (m.Archived = 0) AND (p.Deleted = 0) AND (p.Archived = 0) ORDER BY m.RecordID, p.DetailID";				
				command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

				SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command);

				dataAdapter1.Fill(dataSet, "LFS_POINT_REPAIRS");

				//--- Return results
				return dataSet;
			}
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR PointLinerScopeSheet
		///

		//
		// GetPointLinerScopeSheetByCompanyId
		//     
		public TDSPointLinerScopeSheet GetPointLinerScopeSheetByCompanyId(int companyId, bool all_clients, int companies_id)
		{
			//--- Get data for PointLinerScopeSheet
			SqlConnection connection = new SqlConnection(ConnectionString);

			if ((all_clients == true) && (companies_id == 0))
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.COMPANIES_ID, m.Street, m.USMH, m.DSMH, m.Size_, m.USMHMN, m.DSMHMN, m.ConfirmedSize, m.ScaledLength, m.ActualLength, m.P1Date, m.M1Date, m.PipeMaterialType, m.Comments, m.MeasurementsTakenBy, m.DegreeOfTrafficControl, m.RoboticPrepRequired, m.RoboticDistances, m.BypassRequired, c.NAME, t.TrafficControl, m.RecordID FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID LEFT OUTER JOIN LFS_TRAFFIC_CONTROL t ON m.DegreeOfTrafficControl = t.TrafficControl WHERE (m.COMPANY_ID = @companyId) AND (m.PointLining = 1) AND (m.IssueIdentified = 0) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSPointLinerScopeSheet dataSet = new TDSPointLinerScopeSheet();
				dataAdapter.Fill(dataSet, "PointLinerScopeSheet");

				commandText = "SELECT p.ID, p.RefID, p.COMPANY_ID, p.Distance, p.RepairSize, p.Reinstates, p.LTAtMH, p.VTAtMH, p.LinerDistance, p.Direction, p.MHShot, p.Comments, p.InstallDate, d.Direction AS Dir, p.DetailID FROM LFS_MASTER_AREA m INNER JOIN LFS_POINT_REPAIRS p ON m.ID = p.ID AND m.COMPANY_ID = p.COMPANY_ID LEFT OUTER JOIN LFS_DIRECTIONS d ON p.Direction = d.Direction WHERE (m.COMPANY_ID = @companyId) AND (p.Deleted = 0) AND (p.Archived = 0)";
				command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));

				SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command);

				dataAdapter1.Fill(dataSet, "LFS_POINT_REPAIRS");

				//--- Return results
				return dataSet;			
			}
			else
			{
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.COMPANIES_ID, m.Street, m.USMH, m.DSMH, m.Size_, m.USMHMN, m.DSMHMN, m.ConfirmedSize, m.ScaledLength, m.ActualLength, m.P1Date, m.M1Date, m.PipeMaterialType, m.Comments, m.MeasurementsTakenBy, m.DegreeOfTrafficControl, m.RoboticPrepRequired, m.RoboticDistances, m.BypassRequired, c.NAME, t.TrafficControl, m.RecordID FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID LEFT OUTER JOIN LFS_TRAFFIC_CONTROL t ON m.DegreeOfTrafficControl = t.TrafficControl WHERE (m.COMPANY_ID = @companyId) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.PointLining = 1) AND (m.IssueIdentified = 0) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSPointLinerScopeSheet dataSet = new TDSPointLinerScopeSheet();
				dataAdapter.Fill(dataSet, "PointLinerScopeSheet");

				commandText = "SELECT p.ID, p.RefID, p.COMPANY_ID, p.Distance, p.RepairSize, p.Reinstates, p.LTAtMH, p.VTAtMH, p.LinerDistance, p.Direction, p.MHShot, p.Comments, p.InstallDate, d.Direction AS Dir, p.DetailID FROM LFS_MASTER_AREA m INNER JOIN LFS_POINT_REPAIRS p ON m.ID = p.ID AND m.COMPANY_ID = p.COMPANY_ID LEFT OUTER JOIN LFS_DIRECTIONS d ON p.Direction = d.Direction WHERE (m.COMPANY_ID = @companyId) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (p.Deleted = 0) AND (p.Archived = 0)";
				command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));
				
				SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command);

				dataAdapter1.Fill(dataSet, "LFS_POINT_REPAIRS");

				//--- Return results
				return dataSet;
			}
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR OutstandingPointRepairs
		///

		//
		// GetOutstandingPointRepairsCompanyIdCompaniesId
		//     
		public TDSOutstandingPointRepairs GetOutstandingPointRepairsCompanyIdCompaniesId(int companyId, bool all_clients, int companies_id)
		{
			if ((all_clients == true) && (companies_id == 0))
			{
				//--- Get data for PointLinerReport
				return GetOutstandingPointRepairsByCompanyId(companyId);
			}
			else
			{
				//--- Get data for PointLinerReport
				SqlConnection connection = new SqlConnection(ConnectionString);

				string commandText = "SELECT m.ID, m.COMPANY_ID, m.ClientID, m.COMPANIES_ID, m.SubArea, m.Street, m.USMH, m.DSMH, m.P1Date, m.M1Date, m.FinalVideo, m.Comments, c.NAME, m.RecordID FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE m.ID IN (SELECT DISTINCT ma.ID FROM LFS_MASTER_AREA ma INNER JOIN LFS_POINT_REPAIRS p ON ma.ID = p.ID AND ma.COMPANY_ID = p.COMPANY_ID WHERE (ma.COMPANY_ID = @companyId) AND (ma.COMPANIES_ID = @companiesId) AND (ma.IssueIdentified = 0) AND (ma.PointLining = 1) AND (ma.Deleted = 0) AND (p.InstallDate IS NULL) AND (p.Cancelled = 0) AND (p.NotApproved = 0) AND (p.Deleted = 0) AND (p.Archived = 0)) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@companiesId", companies_id));

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

				TDSOutstandingPointRepairs dataSet = new  TDSOutstandingPointRepairs();
				dataAdapter.Fill(dataSet, "OutstandingPointRepairs");

				commandText = "SELECT p.ID, p.RefID, p.COMPANY_ID, p.RepairSize, p.InstallDate, p.Distance, p.Reinstates, p.DetailID, p.ExtraRepair, p.Approved FROM LFS_MASTER_AREA m INNER JOIN LFS_POINT_REPAIRS p ON m.ID = p.ID AND m.COMPANY_ID = p.COMPANY_ID WHERE (m.COMPANY_ID = @companyId) AND (m.COMPANIES_ID = @companiesId) AND (m.IssueIdentified = 0) AND (m.PointLining = 1) AND (m.Deleted = 0) AND (m.Archived = 0) AND (p.InstallDate IS NULL) AND (p.Cancelled = 0) AND (p.NotApproved = 0) AND (p.Deleted = 0) AND (p.Archived = 0)";
				command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@companiesId", companies_id));

				SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command);

				dataAdapter1.Fill(dataSet, "LFS_POINT_REPAIRS");

				//--- Return results
				return dataSet;			
			}
		}
		
		//
		// GetOutstandingPointRepairsCompanyId
		//     
		public TDSOutstandingPointRepairs GetOutstandingPointRepairsByCompanyId(int companyId)
		{
			//--- Get data for PointLinerReport
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT m.ID, m.COMPANY_ID, m.ClientID, m.COMPANIES_ID, m.SubArea, m.Street, m.USMH, m.DSMH, m.P1Date, m.M1Date, m.FinalVideo, m.Comments, c.NAME, m.RecordID FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE m.ID IN (SELECT DISTINCT ma.ID FROM LFS_MASTER_AREA ma INNER JOIN LFS_POINT_REPAIRS p ON ma.ID = p.ID AND ma.COMPANY_ID = p.COMPANY_ID WHERE (ma.COMPANY_ID = @companyId) AND (ma.IssueIdentified = 0) AND (ma.PointLining = 1) AND (ma.Deleted = 0) AND (p.InstallDate IS NULL) AND (p.Cancelled = 0) AND (p.NotApproved = 0) AND (p.Deleted = 0) AND (p.Archived = 0)) ORDER BY m.RecordID";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));

			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			TDSOutstandingPointRepairs dataSet = new  TDSOutstandingPointRepairs();
			dataAdapter.Fill(dataSet, "OutstandingPointRepairs");

			commandText = "SELECT p.ID, p.RefID, p.COMPANY_ID, p.RepairSize, p.InstallDate, p.Distance, p.Reinstates, p.DetailID, p.ExtraRepair, p.Approved FROM LFS_MASTER_AREA m INNER JOIN LFS_POINT_REPAIRS p ON m.ID = p.ID AND m.COMPANY_ID = p.COMPANY_ID WHERE (m.COMPANY_ID = @companyId) AND (m.IssueIdentified = 0) AND (m.PointLining = 1) AND (m.Deleted = 0) AND (m.Archived = 0) AND (p.InstallDate IS NULL) AND (p.Cancelled = 0) AND (p.NotApproved = 0) AND (p.Deleted = 0) AND (p.Archived = 0)";
			command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));

			SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command);

			dataAdapter1.Fill(dataSet, "LFS_POINT_REPAIRS");

			//--- Return results
			return dataSet;			
		}
		
		
		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR M1ReportByClient
		///

		//
		// GetM1ReportByClientByCompanyIdByID
		//     
		public TDSM1ReportByClient GetM1ReportByClientByCompanyIdByID(int companyId, string recordId)
		{
			//--- Get data for M1ReportByClient
			SqlConnection connection = new SqlConnection(ConnectionString);
			
			string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, c.NAME, m.SubArea, m.Street, m.USMH, m.DSMH, m.ActualLength, m.M1Date, m.ConfirmedSize, m.USMHMN, m.DSMHMN, m.USMHDepth, m.DSMHDepth, m.MeasurementsTakenBy, m.USMHAtMouth1200, m.USMHAtMouth100, m.USMHAtMouth200, m.USMHAtMouth300, m.USMHAtMouth400, m.USMHAtMouth500, m.DSMHAtMouth1200, m.DSMHAtMouth100, m.DSMHAtMouth200, m.DSMHAtMouth300, m.DSMHAtMouth400, m.DSMHAtMouth500, m.HydrantAddress, m.DistanceToInversionMH, m.RampsRequired, m.DegreeOfTrafficControl, t.TrafficControl, m.StandarBypass, m.HydroWireDetails, m.PipeMaterialType, m.RoboticPrepRequired, m.PipeSizeChange, m.M1Comments, m.TrafficControlDetails, m.LineWithID, m.SchoolZone, m.RestaurantArea, m.CarwashLaundromat, m.HydroPulley, m.FridgeCart, m.TwoInchPump, m.SixInchBypass, m.Scaffolding, m.WinchExtension, m.ExtraGenerator, m.GreyCableExtension, m.EasementMats, m.DropPipe, m.DropPipeInvertDepth FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID LEFT OUTER JOIN LFS_TRAFFIC_CONTROL t ON m.DegreeOfTrafficControl = t.TrafficControl WHERE (m.COMPANY_ID = @companyId) AND (m.RecordID = @RecordID) AND (m.M1Date IS NOT NULL) AND (m.FullLengthLining = 1) AND (m.Deleted = 0) AND (m.Archived = 0)";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@RecordID", recordId));

			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			TDSM1ReportByClient dataSet = new TDSM1ReportByClient();
			dataAdapter.Fill(dataSet, "M1ReportByClient");

			//--- Return results
			return dataSet;		
		}

		//
		// GetM1ReportByClientByCompanyIdByCompanies
		//     
		public TDSM1ReportByClient GetM1ReportByClientByCompanyIdByCompanies(int companyId, int companies_id)
		{
			//--- Get data for M1ReportByClient
			SqlConnection connection = new SqlConnection(ConnectionString);
		
			string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, c.NAME, m.SubArea, m.Street, m.USMH, m.DSMH, m.ActualLength, m.M1Date, m.ConfirmedSize, m.USMHMN, m.DSMHMN, m.USMHDepth, m.DSMHDepth, m.MeasurementsTakenBy, m.USMHAtMouth1200, m.USMHAtMouth100, m.USMHAtMouth200, m.USMHAtMouth300, m.USMHAtMouth400, m.USMHAtMouth500, m.DSMHAtMouth1200, m.DSMHAtMouth100, m.DSMHAtMouth200, m.DSMHAtMouth300, m.DSMHAtMouth400, m.DSMHAtMouth500, m.HydrantAddress, m.DistanceToInversionMH, m.RampsRequired, m.DegreeOfTrafficControl, t.TrafficControl, m.StandarBypass, m.HydroWireDetails, m.PipeMaterialType, m.RoboticPrepRequired, m.PipeSizeChange, m.M1Comments, m.TrafficControlDetails, m.LineWithID, m.SchoolZone, m.RestaurantArea, m.CarwashLaundromat, m.HydroPulley, m.FridgeCart, m.TwoInchPump, m.SixInchBypass, m.Scaffolding, m.WinchExtension, m.ExtraGenerator, m.GreyCableExtension, m.EasementMats, m.DropPipe, m.DropPipeInvertDepth FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID LEFT OUTER JOIN LFS_TRAFFIC_CONTROL t ON m.DegreeOfTrafficControl = t.TrafficControl WHERE (m.COMPANY_ID = @companyId) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.M1Date IS NOT NULL) AND (m.FullLengthLining = 1) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			TDSM1ReportByClient dataSet = new TDSM1ReportByClient();
			dataAdapter.Fill(dataSet, "M1ReportByClient");

			//--- Return results
			return dataSet;			
		}

		//
		// GetM1ReportByClientByCompanyIdByDate
		//     
		public TDSM1ReportByClient GetM1ReportByClientByCompanyIdByDate(int companyId, string date)
		{
			//--- Get data for M1ReportByClient
			SqlConnection connection = new SqlConnection(ConnectionString);
		
			string commandText = "SELECT m.ID, m.COMPANY_ID, m.RecordID, m.COMPANIES_ID, c.NAME, m.SubArea, m.Street, m.USMH, m.DSMH, m.ActualLength, m.M1Date, m.ConfirmedSize, m.USMHMN, m.DSMHMN, m.USMHDepth, m.DSMHDepth, m.MeasurementsTakenBy, m.USMHAtMouth1200, m.USMHAtMouth100, m.USMHAtMouth200, m.USMHAtMouth300, m.USMHAtMouth400, m.USMHAtMouth500, m.DSMHAtMouth1200, m.DSMHAtMouth100, m.DSMHAtMouth200, m.DSMHAtMouth300, m.DSMHAtMouth400, m.DSMHAtMouth500, m.HydrantAddress, m.DistanceToInversionMH, m.RampsRequired, m.DegreeOfTrafficControl, t.TrafficControl, m.StandarBypass, m.HydroWireDetails, m.PipeMaterialType, m.RoboticPrepRequired, m.PipeSizeChange, m.M1Comments, m.TrafficControlDetails, m.LineWithID, m.SchoolZone, m.RestaurantArea, m.CarwashLaundromat, m.HydroPulley, m.FridgeCart, m.TwoInchPump, m.SixInchBypass, m.Scaffolding, m.WinchExtension, m.ExtraGenerator, m.GreyCableExtension, m.EasementMats, m.DropPipe, m.DropPipeInvertDepth FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID LEFT OUTER JOIN LFS_TRAFFIC_CONTROL t ON m.DegreeOfTrafficControl = t.TrafficControl WHERE (m.COMPANY_ID = @companyId) AND (m.M1Date = @M1Date) AND (m.M1Date IS NOT NULL) AND (m.FullLengthLining = 1) AND (m.Deleted = 0) AND (m.Archived = 0) ORDER BY m.RecordID";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@M1Date", date));

			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			TDSM1ReportByClient dataSet = new TDSM1ReportByClient();
			dataAdapter.Fill(dataSet, "M1ReportByClient");

			//--- Return results
			return dataSet;			
		}


		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR M2ReportByID
		///

		//
		// GetM2ReportByIDByCompanyIdById
		//     
		public TDSM2ReportByID GetM2ReportByIDByCompanyIdById(int companyId, string recordId)
		{
			//--- Get data for M2ReportByID
			SqlConnection connection = new SqlConnection(ConnectionString);
			
			string commandText = "SELECT DISTINCT m.ID, m.COMPANY_ID, m.RecordID , m.COMPANIES_ID, c.NAME, m.Street, m.USMH, m.DSMH, m.ConfirmedSize, m.LiveLats, m.M2Date, m.VideoDoneFrom, m.ToManhole, m.CutterDescriptionDuringMeasuring, m.MeasurementType, m.MeasuredFromManhole FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID INNER JOIN LFS_M2_TABLES t ON m.ID = t.ID AND m.COMPANY_ID = t.COMPANY_ID WHERE (m.COMPANY_ID = @companyId) AND (m.RecordID = @RecordID) AND (m.M2Date IS NOT NULL) AND (m.Deleted = 0) AND (m.Archived = 0) AND (t.Deleted = 0) AND (t.Archived = 0) ORDER BY m.RecordID";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@RecordID", recordId));

			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
			TDSM2ReportByID dataSet = new TDSM2ReportByID();
			dataAdapter.Fill(dataSet, "LFS_MASTER_AREA");

			commandText = "SELECT t.ID, t.RefID, t.COMPANY_ID, t.VideoDistance, t.ClockPosition, t.LiveOrAbandoned, t.DistanceToCentreOfLateral, t.LateralDiameter, t.LateralType, t.DateTimeOpened, t.Comments, t.ReverseSetup FROM LFS_MASTER_AREA m INNER JOIN LFS_M2_TABLES t ON m.ID = t.ID AND m.COMPANY_ID = t.COMPANY_ID WHERE (m.COMPANY_ID = @companyId) AND (m.RecordID = @RecordID) AND (m.M2Date IS NOT NULL) AND (m.Deleted=0) AND (m.Archived = 0) AND (t.Deleted = 0) AND (t.Archived = 0) ORDER BY t.VideoDistance DESC";
			command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@RecordID", recordId));

			SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command);
			dataAdapter1.Fill(dataSet, "LFS_M2_TABLES");

			//--- Return results
			return dataSet;			
		}

		//
		// GetM2ReportByIDByCompanyIdByCompanies
		//     
		public TDSM2ReportByID GetM2ReportByIDByCompanyIdByCompanies(int companyId, int companies_id)
		{
			//--- Get data for M2ReportByID
			SqlConnection connection = new SqlConnection(ConnectionString);
			
			string commandText = "SELECT DISTINCT m.ID, m.COMPANY_ID, m.RecordID , m.COMPANIES_ID, c.NAME, m.Street, m.USMH, m.DSMH, m.ConfirmedSize, m.LiveLats, m.M2Date, m.VideoDoneFrom, m.ToManhole, m.CutterDescriptionDuringMeasuring, m.MeasurementType, m.MeasuredFromManhole FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID INNER JOIN LFS_M2_TABLES t ON m.ID = t.ID AND m.COMPANY_ID = t.COMPANY_ID WHERE (m.COMPANY_ID = @companyId) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.M2Date IS NOT NULL) AND (m.Deleted = 0) AND (m.Archived = 0) AND (t.Deleted = 0) AND (t.Archived = 0) ORDER BY m.RecordID";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
			TDSM2ReportByID dataSet = new TDSM2ReportByID();
			dataAdapter.Fill(dataSet, "LFS_MASTER_AREA");


			commandText = "SELECT t.ID, t.RefID, t.COMPANY_ID, t.VideoDistance, t.ClockPosition, t.LiveOrAbandoned, t.DistanceToCentreOfLateral, t.LateralDiameter, t.LateralType, t.DateTimeOpened, t.Comments, t.ReverseSetup FROM LFS_MASTER_AREA m INNER JOIN LFS_M2_TABLES t ON m.ID = t.ID AND m.COMPANY_ID = t.COMPANY_ID WHERE (m.COMPANY_ID = @companyId) AND (m.COMPANIES_ID = @COMPANIES_ID) AND (m.M2Date IS NOT NULL) AND (m.Deleted = 0) AND (m.Archived = 0) AND (t.Deleted = 0) AND (t.Archived = 0) ORDER BY t.VideoDistance DESC";
			command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@COMPANIES_ID", companies_id));

			SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command);
			dataAdapter1.Fill(dataSet, "LFS_M2_TABLES");

			//--- Return results
			return dataSet;			
		}

		//
		// GetM2ReportByIDByCompanyIdByDate
		//     
		public TDSM2ReportByID GetM2ReportByIDByCompanyIdByDate(int companyId, string date)
		{
			//--- Get data for M2ReportByID
			SqlConnection connection = new SqlConnection(ConnectionString);
			
			string commandText = "SELECT DISTINCT m.ID, m.COMPANY_ID, m.RecordID , m.COMPANIES_ID, c.NAME, m.Street, m.USMH, m.DSMH, m.ConfirmedSize, m.LiveLats, m.M2Date, m.VideoDoneFrom, m.ToManhole, m.CutterDescriptionDuringMeasuring, m.MeasurementType, m.MeasuredFromManhole FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID INNER JOIN LFS_M2_TABLES t ON m.ID = t.ID AND m.COMPANY_ID = t.COMPANY_ID WHERE (m.COMPANY_ID = @companyId) AND (m.M2Date = @M2Date) AND (m.M2Date IS NOT NULL) AND (m.Deleted = 0) AND (m.Archived = 0) AND (t.Deleted = 0) AND (t.Archived = 0) ORDER BY m.RecordID";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@M2Date", date));

			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
			TDSM2ReportByID dataSet = new TDSM2ReportByID();
			dataAdapter.Fill(dataSet, "LFS_MASTER_AREA");

			commandText = "SELECT t.ID, t.RefID, t.COMPANY_ID, t.VideoDistance, t.ClockPosition, t.LiveOrAbandoned, t.DistanceToCentreOfLateral, t.LateralDiameter, t.LateralType, t.DateTimeOpened, t.Comments, t.ReverseSetup FROM LFS_MASTER_AREA m INNER JOIN LFS_M2_TABLES t ON m.ID = t.ID AND m.COMPANY_ID = t.COMPANY_ID WHERE (m.COMPANY_ID = @companyId) AND (m.M2Date = @M2Date) AND (m.M2Date IS NOT NULL) AND (m.Deleted = 0) AND (m.Archived = 0) AND (t.Deleted = 0) AND (t.Archived = 0) ORDER BY t.VideoDistance DESC";
			command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@M2Date", date));

			SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command);
			dataAdapter1.Fill(dataSet, "LFS_M2_TABLES");

			//--- Return results
			return dataSet;			
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR WorkAhead
		///

		//
		// GetWorkAheadByCompanyId
		//     
		public TDSWorkAhead GetWorkAheadByCompanyId(int companyId)
		{
			//--- Get data for WorkAhead
			SqlConnection connection = new SqlConnection(ConnectionString);
			
			double total = 0.0F;
			string commandText = "SELECT SUM(ROUND(ScaledLength1,2)) AS SumScaled FROM LFS_MASTER_AREA m WHERE (COMPANY_ID = @companyId) AND (m.FullLengthLining = 1) AND (m.InstallDate IS NULL) AND (m.Deleted = 0) AND (m.Archived = 0)";
			SqlCommand command1 = new SqlCommand(commandText, connection);
			command1.Parameters.Add(new SqlParameter("@companyId", companyId));
			
			connection.Open();
			total = (double)command1.ExecuteScalar();
			connection.Close();

			int totalConfirmed = 0;
			string commandText2 = "SELECT SUM(ConfirmedSize) AS SumConfirmed FROM LFS_MASTER_AREA m WHERE (COMPANY_ID = @companyId) AND (m.FullLengthLining = 1) AND (m.InstallDate IS NULL) AND (m.Deleted = 0) AND (m.Archived = 0)";
			SqlCommand command2 = new SqlCommand(commandText2, connection);
			command2.Parameters.Add(new SqlParameter("@companyId", companyId));
			
			connection.Open();
			totalConfirmed = (int)command2.ExecuteScalar();
			connection.Close();
			
			commandText = "SELECT m.COMPANIES_ID, m.Size_, SUM(ROUND(m.ScaledLength1,2)) AS SumScaled, m.InstallRate, TotalAhead = '"+ total +"' , c.NAME, COUNT(m.RecordID) AS Nro, SUM(m.ConfirmedSize) AS SumConfirmed, TotalAhead2 = '"+ totalConfirmed +"' FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c ON m.COMPANIES_ID = c.COMPANIES_ID WHERE (m.COMPANY_ID = @companyId) AND (m.FullLengthLining = 1) AND (m.InstallDate IS NULL) AND (m.Deleted = 0) AND (m.Archived = 0) GROUP BY m.COMPANIES_ID, m.Size_, m.InstallRate, c.NAME ORDER BY m.COMPANIES_ID, m.Size_";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			
			SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command);

			TDSWorkAhead dataSet = new TDSWorkAhead();
			dataAdapter1.Fill(dataSet, "WorkAhead1");

			//--- Return results
			return dataSet;
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR JLinerOverviewReport
		///

		//
		// GetJLinerOverviewReportByCompanyIdCompaniesID
		//     
		public TDSJLinerOverviewReport GetJLinerOverviewReportByCompanyIDCompaniesID(int companyId, bool all_clients, int companiesId)
		{
			if ((all_clients == true) && (companiesId == 0))
			{
				//--- Get data for JLinerOverviewReport
				return GetJLinerOverviewReportByCompanyID(companyId);
			}
			else
			{
				SqlConnection connection = new SqlConnection(ConnectionString);
				TDSJLinerOverviewReport dataSet = new  TDSJLinerOverviewReport();
				
				//--- Select master data
				string commandText = "SELECT DISTINCT m.ID, m.COMPANY_ID, m.COMPANIES_ID, c.Name, m.SubArea, m.Street, m.USMH, m.DSMH, m.ConfirmedSize, m.ActualLength, m.P1Date, m.MainLined, m.BenchingIssue, m.RecordID FROM LFS_MASTER_AREA m INNER JOIN LFS_JUNCTION_LINER j ON m.ID = j.ID and m.COMPANY_ID = j.COMPANY_ID INNER JOIN COMPANIES c ON m.Company_ID = c.Company_ID and m.Companies_ID = c.Companies_ID WHERE (m.COMPANY_ID = @companyId) AND (m.COMPANIES_ID = @companiesId) AND (m.JLiner = 1) AND (m.Deleted = 0) AND (m.Archived = 0) AND (j.Deleted = 0) AND (j.Archived = 0) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@companiesId", companiesId));
				
				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
  			    dataAdapter.Fill(dataSet, "JLinerOverviewReport");

				//--- Select detail data
				commandText = "SELECT m.ID, j.RefID, m.COMPANY_ID, j.DetailID, j.MN, j.DistanceFromUSMH, j.CleanoutRequired, j.PitRequired, j.CleanoutInstalled, j.PitInstalled, j.CleanoutGrouted, j.CleanoutCored, j.PrepCompleted, j.MainConnection, j.Transition, j.ConfirmedLatSize, j.MeasuredLatLength, j.LinerOrdered, j.LinerInStock, j.LinerInstalled, j.FinalVideo, j.RestorationComplete FROM LFS_MASTER_AREA m INNER JOIN LFS_JUNCTION_LINER j ON m.ID = j.ID AND m.COMPANY_ID = j.COMPANY_ID WHERE (m.COMPANY_ID = @companyId) AND (m.COMPANIES_ID = @companiesId) AND (m.JLiner = 1) AND (m.Deleted = 0) AND (m.Archived = 0) AND (j.Deleted = 0) AND (j.Archived = 0) ORDER BY m.RecordID, j.DetailID";				
				command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@companiesId", companiesId));
				
				SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command);
				dataAdapter1.Fill(dataSet, "LFS_JUNCTION_LINER");

				//--- Return results
				return dataSet;
			}
		}
		
		//
		// GetJLinerOverviewReportByCompanyId
		//     
		public TDSJLinerOverviewReport GetJLinerOverviewReportByCompanyID(int companyId)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);
			TDSJLinerOverviewReport dataSet = new  TDSJLinerOverviewReport();
				
			//--- Select master data
			string commandText = "SELECT DISTINCT m.ID, m.COMPANY_ID, m.COMPANIES_ID, c.Name, m.SubArea, m.Street, m.USMH, m.DSMH, m.ConfirmedSize, m.ActualLength, m.P1Date, m.MainLined, m.BenchingIssue, m.RecordID FROM LFS_MASTER_AREA m INNER JOIN LFS_JUNCTION_LINER j ON m.ID = j.ID and m.COMPANY_ID = j.COMPANY_ID INNER JOIN COMPANIES c ON m.Company_ID = c.Company_ID and m.Companies_ID = c.Companies_ID WHERE (m.COMPANY_ID = @companyId) AND (m.JLiner = 1) AND (m.Deleted = 0) AND (m.Archived = 0) AND (j.Deleted = 0) AND (j.Archived = 0) ORDER BY m.RecordID";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			
			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
			dataAdapter.Fill(dataSet, "JLinerOverviewReport");

			//--- Select detail data
			commandText = "SELECT m.ID, j.RefID, m.COMPANY_ID, j.DetailID, j.MN, j.DistanceFromUSMH, j.CleanoutRequired, j.PitRequired, j.CleanoutInstalled, j.PitInstalled, j.CleanoutGrouted, j.CleanoutCored, j.PrepCompleted, j.MainConnection, j.Transition, j.ConfirmedLatSize, j.MeasuredLatLength, j.LinerOrdered, j.LinerInStock, j.LinerInstalled, j.FinalVideo, j.RestorationComplete FROM LFS_MASTER_AREA m INNER JOIN LFS_JUNCTION_LINER j ON m.ID = j.ID AND m.COMPANY_ID = j.COMPANY_ID WHERE (m.COMPANY_ID = @companyId) AND (m.JLiner = 1) AND (m.Deleted = 0) AND (m.Archived = 0) AND (j.Deleted = 0) AND (j.Archived = 0) ORDER BY m.RecordID, j.DetailID";		
			command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			
			SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command);
			dataAdapter1.Fill(dataSet, "LFS_JUNCTION_LINER");

			//--- Return results
			return dataSet;
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR JLinersReadyToLine
		///

		//
		// GetJLinersReadyToLineByCompanyIdCompaniesID
		//     
		public TDSJLinersReadyToLine GetJLinersReadyToLineByCompanyIDCompaniesID(int companyId, bool all_clients, int companiesId)
		{
			if ((all_clients == true) && (companiesId == 0))
			{
				//--- Get data for JLinersReadyToLine
				return GetJLinersReadyToLineByCompanyID(companyId);
			}
			else
			{
				SqlConnection connection = new SqlConnection(ConnectionString);
				TDSJLinersReadyToLine dataSet = new  TDSJLinersReadyToLine();
				
				//--- Select master data
				string commandText = "SELECT m.ID, m.COMPANY_ID, m.COMPANIES_ID, c.Name, m.SubArea, m.Street, m.USMH, m.DSMH, m.ConfirmedSize, m.ActualLength, m.P1Date, m.RecordID , m.TrafficControlDetails, m.Comments FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c on m.Company_ID = c.Company_ID and m.Companies_ID = c.Companies_ID WHERE (ID in ( SELECT DISTINCT ma.ID FROM LFS_MASTER_AREA ma INNER JOIN LFS_JUNCTION_LINER j ON ma.ID = j.ID and ma.COMPANY_ID = j.COMPANY_ID WHERE (ma.COMPANY_ID = @companyId) AND (ma.COMPANIES_ID = @companiesId) AND (ma.Deleted = 0) AND (ma.Archived = 0) AND (j.Deleted = 0) AND (j.Archived = 0))) ORDER BY m.RecordID";
				SqlCommand command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@companiesId", companiesId));
				
				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
				dataAdapter.Fill(dataSet, "JLinersReadyToLine");

				//--- Select detail data
				commandText = "SELECT m.ID, j.RefID, m.COMPANY_ID, j.DetailID, j.MN, j.DistanceFromUSMH, j.CleanoutInstalled, j.PitInstalled, j.PrepCompleted, j.Transition, j.ConfirmedLatSize, j.MeasuredLatLength, j.LinerInstalled, j.LinerInStock, j.Comments FROM LFS_MASTER_AREA m INNER JOIN LFS_JUNCTION_LINER j ON m.ID = j.ID AND m.COMPANY_ID = j.COMPANY_ID WHERE (m.COMPANY_ID = @companyId) AND (m.COMPANIES_ID = @companiesId) AND (m.Deleted = 0) AND (m.Archived = 0) AND (j.Deleted = 0) AND (j.Archived = 0) ORDER BY m.RecordID, j.DetailID";		
				command = new SqlCommand(commandText, connection);
				command.Parameters.Add(new SqlParameter("@companyId", companyId));
				command.Parameters.Add(new SqlParameter("@companiesId", companiesId));
				
				SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command);
				dataAdapter1.Fill(dataSet, "LFS_JUNCTION_LINER");
				
				//--- Filter data with report conditions
				FilterJLinersReadyToLine(dataSet);

				//--- Return results
				return dataSet;
			}
		}
		
		//
		// GetJLinersReadyToLineByCompanyId
		//     
		public TDSJLinersReadyToLine GetJLinersReadyToLineByCompanyID(int companyId)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);
			TDSJLinersReadyToLine dataSet = new  TDSJLinersReadyToLine();
				
			//--- Select master data
			string commandText = "SELECT m.ID, m.COMPANY_ID, m.COMPANIES_ID, c.Name, m.SubArea, m.Street, m.USMH, m.DSMH, m.ConfirmedSize, m.ActualLength, m.P1Date, m.RecordID , m.TrafficControlDetails, m.Comments FROM LFS_MASTER_AREA m INNER JOIN COMPANIES c on m.Company_ID = c.Company_ID and m.Companies_ID = c.Companies_ID WHERE (ID in ( SELECT DISTINCT ma.ID FROM LFS_MASTER_AREA ma INNER JOIN LFS_JUNCTION_LINER j ON ma.ID = j.ID and ma.COMPANY_ID = j.COMPANY_ID WHERE (ma.COMPANY_ID = @companyId) AND (ma.Deleted = 0) AND (ma.Archived = 0) AND (j.Deleted = 0) AND (j.Archived = 0))) ORDER BY m.RecordID";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			
			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
			dataAdapter.Fill(dataSet, "JLinersReadyToLine");

			//--- Select detail data
			commandText = "SELECT m.ID, j.RefID, m.COMPANY_ID, j.DetailID, j.MN, j.DistanceFromUSMH, j.CleanoutInstalled, j.PitInstalled, j.PrepCompleted, j.Transition, j.ConfirmedLatSize, j.MeasuredLatLength, j.LinerInstalled, j.LinerInStock, j.Comments FROM LFS_MASTER_AREA m INNER JOIN LFS_JUNCTION_LINER j ON m.ID = j.ID AND m.COMPANY_ID = j.COMPANY_ID WHERE (m.COMPANY_ID = @companyId) AND (m.Deleted = 0) AND (m.Archived = 0) AND (j.Deleted = 0) AND (j.Archived = 0) ORDER BY m.RecordID, j.DetailID";		
			command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			
			SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command);
			dataAdapter1.Fill(dataSet, "LFS_JUNCTION_LINER");
			
			//--- Filter data with report conditions
			FilterJLinersReadyToLine(dataSet);

			//--- Return results
			return dataSet;
		}

		//
		// FilterJLinersReadyToLine
		//
		private void FilterJLinersReadyToLine(TDSJLinersReadyToLine dataSet)
		{
			//--- Initialize
			int indexMA = 0;
			int recordsMA = dataSet.JLinersReadyToLine.Count;
			//--- Move in MASTER_AREA records
			while (recordsMA > 0)
			{
				//--- Initialize
				int numJL = 0; //rows in LFS_JUNCTION_LINER
				int numC1 = 0; //rows in LFS_JUNCTION_LINER with MeauredLatLength and LinerInStock condition
				int numC2 = 0; //rows in LFS_JUNCTION_LINER with LinerInstalled condition
				TDSJLinersReadyToLine.JLinersReadyToLineRow rowMA = dataSet.JLinersReadyToLine[indexMA];
				//--- Move in LFS_JUNCTION_LINER records
				foreach (TDSJLinersReadyToLine.LFS_JUNCTION_LINERRow lfsJunctionLinerRow in dataSet.LFS_JUNCTION_LINER)
				{
					//--- Verify condition
					if ((lfsJunctionLinerRow.ID == rowMA["ID"].ToString()) && (lfsJunctionLinerRow.COMPANY_ID.ToString() == rowMA["COMPANY_ID"].ToString()))
					{
						numJL++;
						if ((!lfsJunctionLinerRow.IsNull("MeasuredLatLength")) && (lfsJunctionLinerRow.LinerInStock == true))
						{
							numC1++;
							if (lfsJunctionLinerRow.IsNull("LinerInstalled"))
							{
								numC2++;
							}
						}
					}
				}

				//--- Move forward or delete LFS_MASTER_AREA record
				if ((numJL == numC1) && (numC2>0))
				{
					indexMA++;	
				}
				else
				{
					rowMA.Delete();
					dataSet.AcceptChanges();
				}
				recordsMA--;
			}
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS FOR JLINERSTOBUILD
		///

		//
		// GetJLinersToBuildByCompanyId
		//
		public TDSJLinersToBuild GetJLinersToBuildByCompanyId(int companyId)
		{
			//--- Get data for JLinersToBuild
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT J.ID, J.RefID, J.Company_ID, M.RecordID, J.DetailID, J.MN, M.Street, M.ConfirmedSize, J.ConfirmedLatSize, J.MeasuredLatLength FROM LFS_MASTER_AREA M INNER JOIN LFS_JUNCTION_LINER J on M.ID = J.ID AND M.COMPANY_ID = J.COMPANY_ID WHERE (M.COMPANY_ID = @companyId) AND (J.MEASUREDLATLENGTH IS NOT NULL) AND ((M.ISSUEIDENTIFIED = 0) OR ((M.ISSUEIDENTIFIED = 1) AND (M.ISSUERESOLVED = 1))) AND (M.DELETED = 0) AND (M.Archived = 0) AND (J.DELETED = 0) AND (J.Archived = 0) ORDER BY M.RecordID,J.DetailID";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));

			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			TDSJLinersToBuild dataSet = new TDSJLinersToBuild();
			dataAdapter.Fill(dataSet,"JLinersToBuild");
				
			//--- Fill table for report
			foreach (TDSJLinersToBuild.JLinersToBuildRow jLinersToBuildRow in dataSet.JLinersToBuild)
			{
				TDSJLinersToBuild.LFS_JUNCTION_LINERRow lfsJunctionLinerRow;
				
				lfsJunctionLinerRow = dataSet.LFS_JUNCTION_LINER.NewLFS_JUNCTION_LINERRow();
		
				lfsJunctionLinerRow.ID = jLinersToBuildRow.ID;
				lfsJunctionLinerRow.RefID=jLinersToBuildRow.RefID;
				lfsJunctionLinerRow.COMPANY_ID=jLinersToBuildRow.COMPANY_ID;
				lfsJunctionLinerRow.Field=jLinersToBuildRow.RecordID + " " + jLinersToBuildRow.DetailID + " - ";
				if (jLinersToBuildRow.IsNull("MN"))
				{
					lfsJunctionLinerRow.Field = lfsJunctionLinerRow.Field + "_ ";
				}
				else
				{
					lfsJunctionLinerRow.Field=lfsJunctionLinerRow.Field+jLinersToBuildRow.MN+" ";
				}
				if (jLinersToBuildRow.IsNull("Street"))
				{
					lfsJunctionLinerRow.Field=lfsJunctionLinerRow.Field+"_ ";
				}
				else
				{
					lfsJunctionLinerRow.Field=lfsJunctionLinerRow.Field+jLinersToBuildRow.Street+" ";
				}
				if (jLinersToBuildRow.IsNull("ConfirmedSize"))
				{
					lfsJunctionLinerRow.Field=lfsJunctionLinerRow.Field+"_ x ";
				}
				else
				{
					lfsJunctionLinerRow.Field=lfsJunctionLinerRow.Field+jLinersToBuildRow.ConfirmedSize.ToString()+"\" x ";
				}
				if (jLinersToBuildRow.IsNull("ConfirmedLatSize"))
				{
					lfsJunctionLinerRow.Field=lfsJunctionLinerRow.Field+"_ x ";
				}
				else
				{
					lfsJunctionLinerRow.Field=lfsJunctionLinerRow.Field+jLinersToBuildRow.ConfirmedLatSize+" x ";
				}
				if (jLinersToBuildRow.IsNull("MeasuredLatLength"))
				{
					lfsJunctionLinerRow.Field=lfsJunctionLinerRow.Field+"_ x ";
				}
				else
				{
					lfsJunctionLinerRow.Field=lfsJunctionLinerRow.Field+jLinersToBuildRow.MeasuredLatLength;
				}

				dataSet.LFS_JUNCTION_LINER.AddLFS_JUNCTION_LINERRow(lfsJunctionLinerRow);
			}

			//--- Return results
			return dataSet;
		}
	}


}
