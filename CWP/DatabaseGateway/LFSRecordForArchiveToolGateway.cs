using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LiquiForce.LFSLive.CWP.DatabaseGateway
{
	public class LFSRecordForArchiveToolGateway
	{
		///////////////////////////////////////////////////////////////////////////
		/// PROPERTIES AND FIELDS
		///
		private string ConnectionString;






		///////////////////////////////////////////////////////////////////////////
		/// CONSTRUCTORS
		///

		//
		// Default
		//
		public LFSRecordForArchiveToolGateway()
		{
			//--- Get the connection string
			AppSettingsReader appSettingReader = new AppSettingsReader();
			ConnectionString = appSettingReader.GetValue("ConnectionString", typeof(System.String)).ToString();
		}






		///////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// GetRecordsByCompanyIdRecordId()
		//
		// Returns records that match an RecordID (where RecordID like recordId%) ordered by RecordID
		// 
		public TDSLFSRecordForArchiveTool GetRecordsByCompanyIdRecordId(int companyId, string recordId)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

            string commandText = "SELECT LFS_MASTER_AREA.ID, LFS_MASTER_AREA.COMPANY_ID, LFS_MASTER_AREA.RecordID, LFS_MASTER_AREA.COMPANIES_ID, COMPANIES.NAME, LFS_MASTER_AREA.Street, LFS_MASTER_AREA.USMH, LFS_MASTER_AREA.DSMH, LFS_MASTER_AREA.Archived, CAST(0 AS BIT) AS Selected FROM LFS_MASTER_AREA INNER JOIN LFS_RESOURCES_COMPANIES AS COMPANIES ON LFS_MASTER_AREA.COMPANIES_ID = COMPANIES.COMPANIES_ID WHERE (LFS_MASTER_AREA.RecordID LIKE @recordId) AND (LFS_MASTER_AREA.COMPANY_ID = @companyId) AND (LFS_MASTER_AREA.Deleted = 0) ORDER BY LFS_MASTER_AREA.RecordID";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@recordId", recordId + "%"));
			command.Parameters.Add(new SqlParameter("@companyId", companyId));

			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			TDSLFSRecordForArchiveTool dataSet = new TDSLFSRecordForArchiveTool();
			dataAdapter.Fill(dataSet, "ARCHIVE");
			
			return dataSet;
		}



		//
		// GetRecordsByCompanyIdClient()
		//
		// Returns records that match a Client name (where Name like %client%) ordered by client, recordId
		// 
		public TDSLFSRecordForArchiveTool GetRecordsByCompanyIdClient(int companyId, string client)
		{
			//--- Prepare search condition
			string[] tokens = client.Split(new char[]{' ',',',';','.',':','-','_','\\','/'}, 50);
			string condition = null;
			for (int i=0; i<tokens.Length; i++)
			{
				if (i==0)
				{
					condition = "COMPANIES.NAME LIKE '%" + tokens[i].ToString() + "%' ";
				}
				else
				{
					condition += "AND COMPANIES.NAME LIKE '%" + tokens[i].ToString() + "%' ";
				}
			}

			//--- Execute query
			SqlConnection connection = new SqlConnection(ConnectionString);

            string commandText = "SELECT LFS_MASTER_AREA.ID, LFS_MASTER_AREA.COMPANY_ID, LFS_MASTER_AREA.RecordID, LFS_MASTER_AREA.COMPANIES_ID, COMPANIES.NAME, LFS_MASTER_AREA.Street, LFS_MASTER_AREA.USMH, LFS_MASTER_AREA.DSMH, LFS_MASTER_AREA.Archived, CAST(0 AS BIT) AS Selected FROM LFS_MASTER_AREA INNER JOIN LFS_RESOURCES_COMPANIES AS COMPANIES ON LFS_MASTER_AREA.COMPANIES_ID = COMPANIES.COMPANIES_ID WHERE (LFS_MASTER_AREA.COMPANY_ID = @companyId) AND (" + condition + ") AND (LFS_MASTER_AREA.Deleted = 0) ORDER BY COMPANIES.NAME, LFS_MASTER_AREA.RecordID";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));

			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			TDSLFSRecordForArchiveTool dataSet = new TDSLFSRecordForArchiveTool();
			dataAdapter.Fill(dataSet, "ARCHIVE");
			
			return dataSet;
		}



		//
		// GetRecordsByCompanyIdUsmh()
		//
		// Returns records that match an usmh (where usmh like usmh%) ordered by usmh
		// 
		public TDSLFSRecordForArchiveTool GetRecordsByCompanyIdUsmh(int companyId, string usmh)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

            string commandText = "SELECT LFS_MASTER_AREA.ID, LFS_MASTER_AREA.COMPANY_ID, LFS_MASTER_AREA.RecordID, LFS_MASTER_AREA.COMPANIES_ID, COMPANIES.NAME, LFS_MASTER_AREA.Street, LFS_MASTER_AREA.USMH, LFS_MASTER_AREA.DSMH, LFS_MASTER_AREA.Archived, CAST(0 AS BIT) AS Selected FROM LFS_MASTER_AREA INNER JOIN LFS_RESOURCES_COMPANIES AS COMPANIES ON LFS_MASTER_AREA.COMPANIES_ID = COMPANIES.COMPANIES_ID WHERE (LFS_MASTER_AREA.COMPANY_ID = @companyId) AND (LFS_MASTER_AREA.USMH LIKE @usmh) AND (LFS_MASTER_AREA.Deleted = 0) ORDER BY LFS_MASTER_AREA.USMH";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@usmh", usmh + "%"));
			
			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			TDSLFSRecordForArchiveTool dataSet = new TDSLFSRecordForArchiveTool();
			dataAdapter.Fill(dataSet, "ARCHIVE");
			
			return dataSet;
		}



		//
		// GetRecordsByCompanyIdDsmh()
		//
		// Returns records that match a dsmh (where dsmh like dsmh%) ordered by dsmh
		// 
		public TDSLFSRecordForArchiveTool GetRecordsByCompanyIdDsmh(int companyId, string dsmh)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

            string commandText = "SELECT LFS_MASTER_AREA.ID, LFS_MASTER_AREA.COMPANY_ID, LFS_MASTER_AREA.RecordID, LFS_MASTER_AREA.COMPANIES_ID, COMPANIES.NAME, LFS_MASTER_AREA.Street, LFS_MASTER_AREA.USMH, LFS_MASTER_AREA.DSMH, LFS_MASTER_AREA.Archived, CAST(0 AS BIT) AS Selected FROM LFS_MASTER_AREA INNER JOIN LFS_RESOURCES_COMPANIES AS COMPANIES ON LFS_MASTER_AREA.COMPANIES_ID = COMPANIES.COMPANIES_ID WHERE (LFS_MASTER_AREA.COMPANY_ID = @companyId) AND (LFS_MASTER_AREA.DSMH LIKE @dsmh) AND (LFS_MASTER_AREA.Deleted = 0) ORDER BY LFS_MASTER_AREA.DSMH";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@dsmh", dsmh + "%"));
			
			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			TDSLFSRecordForArchiveTool dataSet = new TDSLFSRecordForArchiveTool();
			dataAdapter.Fill(dataSet, "ARCHIVE");
			
			return dataSet;
		}



		//
		// GetRecordsByCompanyIdStreet()
		//
		// Returns records that match a street (where street like street%) ordered by street
		// 
		public TDSLFSRecordForArchiveTool GetRecordsByCompanyIdStreet(int companyId, string street)
		{
			//--- Prepare search condition
			string[] tokens = street.Split(new char[]{' ',',',';','.',':','-','_','\\','/'}, 50);
			string condition = null;
			for (int i=0; i<tokens.Length; i++)
			{
				if (i==0)
				{
					condition = "LFS_MASTER_AREA.Street LIKE '%" + tokens[i].ToString() + "%' ";
				}
				else
				{
					condition += "AND LFS_MASTER_AREA.Street LIKE '%" + tokens[i].ToString() + "%' ";
				}
			}

			//--- Execute query
			SqlConnection connection = new SqlConnection(ConnectionString);

            string commandText = "SELECT LFS_MASTER_AREA.ID, LFS_MASTER_AREA.COMPANY_ID, LFS_MASTER_AREA.RecordID, LFS_MASTER_AREA.COMPANIES_ID, COMPANIES.NAME, LFS_MASTER_AREA.Street, LFS_MASTER_AREA.USMH, LFS_MASTER_AREA.DSMH, LFS_MASTER_AREA.Archived, CAST(0 AS BIT) AS Selected FROM LFS_MASTER_AREA INNER JOIN LFS_RESOURCES_COMPANIES AS COMPANIES ON LFS_MASTER_AREA.COMPANIES_ID = COMPANIES.COMPANIES_ID WHERE (LFS_MASTER_AREA.COMPANY_ID = @companyId) AND (" + condition + ") AND (LFS_MASTER_AREA.Deleted = 0) ORDER BY LFS_MASTER_AREA.Street";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));

			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			TDSLFSRecordForArchiveTool dataSet = new TDSLFSRecordForArchiveTool();
			dataAdapter.Fill(dataSet, "ARCHIVE");
			
			return dataSet;
		}


	}
}
