using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LiquiForce.LFSLive.CWP.DatabaseGateway
{
	public class LoginGateway
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
		public LoginGateway()
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
		public string GetUsername(int loginId, int companyId)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT USERNAME FROM LOGIN WHERE (LOGIN_ID = @loginId) AND (COMPANY_ID = @companyId)";
			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add(new SqlParameter("@loginId", loginId));
			command.Parameters.Add(new SqlParameter("@companyId", companyId));

			connection.Open();
			string username = (string)command.ExecuteScalar();
			connection.Close();

			return username;
		}


	}
}
