using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LiquiForce.LFSLive.CWP.DatabaseGateway
{
	public class CompaniesGateway
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
		public CompaniesGateway()
		{
			//--- Get the connection string
			AppSettingsReader appSettingReader = new AppSettingsReader();
			ConnectionString = appSettingReader.GetValue("ConnectionString", typeof(System.String)).ToString();
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// GetCompaniesForDropDownList
		//
		public DataSet GetCompaniesForDropDownList(int companyId)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

            string commandText = "SELECT COMPANIES_ID, NAME FROM LFS_RESOURCES_COMPANIES WHERE (ACTIVE = 1) AND (COMPANY_ID = @companyId) ORDER BY NAME";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));

			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "LFS_RESOURCES_COMPANIES");

			return dataSet;
		}

		//
		// GetCompaniesForDropDownList [overloaded]
		//
		public DataSet GetCompaniesForDropDownList(string companies_id, string name, int companyId)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

            string commandText = "SELECT COMPANIES_ID, NAME FROM LFS_RESOURCES_COMPANIES WHERE (ACTIVE = 1) AND (COMPANY_ID = @companyId) ORDER BY NAME";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));

			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "LFS_RESOURCES_COMPANIES");

            DataRow newRow = dataSet.Tables["LFS_RESOURCES_COMPANIES"].NewRow();
			newRow["COMPANIES_ID"] = companies_id;
			newRow["NAME"] = name;
            dataSet.Tables["LFS_RESOURCES_COMPANIES"].Rows.Add(newRow);

			return dataSet;
		}

		//
		// GetName
		//
		public string GetName(int companiesId, int companyId)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

            string commandText = "SELECT NAME FROM LFS_RESOURCES_COMPANIES WHERE (COMPANIES_ID = @companiesId) AND (COMPANY_ID = @companyId)";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companiesId", companiesId));
			command.Parameters.Add(new SqlParameter("@companyId", companyId));

			connection.Open();
			string name = (string)command.ExecuteScalar();
			connection.Close();

			return name;
		}

		//
		// GetCOMPANIES_ID
		//
		public int GetCOMPANIES_ID(int companyId, string name)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

            string commandText = "SELECT COMPANIES_ID FROM LFS_RESOURCES_COMPANIES WHERE (COMPANY_ID = @companyId) AND (NAME = @name) AND (ACTIVE = 1)";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@companyId", companyId));
			command.Parameters.Add(new SqlParameter("@name", name));

			connection.Open();
			object id = (object)command.ExecuteScalar();
			connection.Close();

			return (id != null) ? (int)id : Int32.MinValue;
		}


	}
}
