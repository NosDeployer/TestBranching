using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LiquiForce.LFSLive.CWP.DatabaseGateway
{
	public class LFSMasterAreaGateway
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
		public LFSMasterAreaGateway()
		{
			//--- Get the connection string
			AppSettingsReader appSettingReader = new AppSettingsReader();
			ConnectionString = appSettingReader.GetValue("ConnectionString", typeof(System.String)).ToString();
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// GetNewID
		//
		public Guid GetNewId()
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT NEWID()";
			SqlCommand command = new SqlCommand(commandText, connection);

			connection.Open();
			Guid newId = (Guid)command.ExecuteScalar();
			connection.Close();

			return newId;
		}

		//
		// GetId
		//
		public Guid GetId(string recordId, int companyId)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT ID FROM LFS_MASTER_AREA WHERE (COMPANY_ID = @companyId) AND (RecordID = @recordId)";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@recordId", recordId));

			connection.Open();
			Guid id = (Guid)command.ExecuteScalar();
			connection.Close();

			return id;
		}

		//
		// CountByRecordId
		//
		public int CountByRecordId(string recordId, int companyId)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT COUNT(*) FROM LFS_MASTER_AREA WHERE (COMPANY_ID = @companyId) AND (RecordID = @recordId)";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@recordId", recordId));

			connection.Open();
			int count = (int)command.ExecuteScalar();
			connection.Close();

			return count;
		}

		//
		// IsRecordIdInDatabase
		//
		public bool IsRecordIdInDatabase(string recordId, int companyId)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT COUNT(*) FROM LFS_MASTER_AREA WHERE (COMPANY_ID = @companyId) AND (RecordID = @recordId)";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@recordId", recordId));

			connection.Open();
			int count = (int)command.ExecuteScalar();
			connection.Close();

			return (count > 0) ? true : false;
		}

		//
		// IsRecordIDInUse
		//
		public bool IsRecordIdInUse(string recordId, int companyId)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT COUNT(*) FROM LFS_MASTER_AREA WHERE (COMPANY_ID = @companyId) AND (RecordID = @recordId) AND (Deleted = 0)";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@recordId", recordId));
			
			connection.Open();
			int count = (int)command.ExecuteScalar();
			connection.Close();

			return (count > 0) ? true : false;
		}

		//
		// IsRecordIDArchived
		//
		public bool IsRecordIdArchived(string recordId, int companyId)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT COUNT(*) FROM LFS_MASTER_AREA WHERE (COMPANY_ID = @companyId) AND (RecordID = @recordId) AND (Archived = 1)";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@recordId", recordId));
			
			connection.Open();
			int count = (int)command.ExecuteScalar();
			connection.Close();

			return (count > 0) ? true : false;
		}

		//
		// GetRecordId
		//
		public string GetRecordId(Guid id, int companyId)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT RecordID FROM LFS_MASTER_AREA WHERE (ID = @id) AND (COMPANY_ID = @companyId)";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@id", id));
			command.Parameters.Add(new SqlParameter("@companyId", companyId));

			connection.Open();
			string recordId = (string)command.ExecuteScalar();
			connection.Close();

			return recordId;
		}

		//
		// GetRecordIdsAndIDsForDropDownList
		//
		public DataSet GetRecordIdsAndIDsForDropDownList(string recordId, int companyId)
		{
			//--- Initialize dataset
			DataColumn column1 = new DataColumn();
			column1.ColumnName = "RecordID";
			DataColumn column2 = new DataColumn();
			column2.ColumnName = "ID";

			DataTable table = new DataTable();
			table.TableName = "RECORDIDS";
			table.Columns.Add(column1);
			table.Columns.Add(column2);

			DataSet dataSet = new DataSet();
			dataSet.Tables.Add(table);

			//--- Fill table
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT ID, RecordID, Deleted, Archived FROM LFS_MASTER_AREA WHERE (COMPANY_ID = @companyId) AND (RecordID = @recordId) ORDER BY Deleted DESC";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@recordId", recordId));
			command.Parameters.Add(new SqlParameter("@companyId", companyId));

			connection.Open();
			SqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				DataRow row = table.NewRow();
				
				row["RecordID"] = reader[1].ToString() + " " + (((bool)reader[2] == true) ? "(deleted)" : "") + " " + (((bool)reader[3] == true) ? "(archived)" : "");
				row["ID"] = reader[0].ToString();

				table.Rows.Add(row);
			}
			reader.Close();
			connection.Close();

			return dataSet;
		}

		//
		// GetLastRecordIdLookupFor05
		//
		public string GetLastRecordIdLookupFor05(int companyId)
		{
			//--- Execute query
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT MAX(RecordID) FROM LFS_MASTER_AREA WHERE (RecordID LIKE '06.%') AND (COMPANY_ID = @companyId) AND (Deleted = 0)";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));

			connection.Open();
			object lastId = command.ExecuteScalar();
			connection.Close();

			if (lastId != DBNull.Value) 
			{
				return lastId.ToString();
			}
			else
			{
				return " -- ";
			}
		}

        //
        // GetLastRecordIdLookupFor07
        //
        public string GetLastRecordIdLookupFor07(int companyId)
        {
            //--- Execute query
            SqlConnection connection = new SqlConnection(ConnectionString);

            string commandText = "SELECT MAX(RecordID) FROM LFS_MASTER_AREA WHERE (RecordID LIKE '07.%') AND (COMPANY_ID = @companyId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, connection);
            command.Parameters.Add(new SqlParameter("@companyId", companyId));

            connection.Open();
            object lastId = command.ExecuteScalar();
            connection.Close();

            if (lastId != DBNull.Value)
            {
                return lastId.ToString();
            }
            else
            {
                return " -- ";
            }
        }

		//
		// GetLastRecordIdLookupForBayCity
		//
		public string GetLastRecordIdLookupForBayCity(int companyId)
		{
			//--- Get last id lookup for bay city parameter
			AppSettingsReader appSettingReader = new AppSettingsReader();
			string lastIdLookupForBayCity = appSettingReader.GetValue("LastIdLookupForBayCity", typeof(System.String)).ToString();

			//--- Execute query
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT MAX(RecordID) FROM LFS_MASTER_AREA WHERE (COMPANIES_ID = @lastIdLookupForBayCity) AND (COMPANY_ID = @companyId) AND (Deleted = 0) AND (Archived = 0)";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@lastIdLookupForBayCity", Int32.Parse(lastIdLookupForBayCity)));
			command.Parameters.Add(new SqlParameter("@companyId", companyId));

			connection.Open();
			object lastId = command.ExecuteScalar();
			connection.Close();

			if (lastId != DBNull.Value) 
			{
				return lastId.ToString();
			}
			else
			{
				return " -- ";
			}
		}


	}
}
