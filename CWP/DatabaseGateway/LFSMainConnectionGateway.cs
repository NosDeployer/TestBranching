using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LiquiForce.LFSLive.CWP.DatabaseGateway
{
	public class LFSMainConnectionGateway
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
		public LFSMainConnectionGateway()
		{
			//--- Get the connection string
			AppSettingsReader appSettingReader = new AppSettingsReader();
			ConnectionString = appSettingReader.GetValue("ConnectionString", typeof(System.String)).ToString();
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// GetLFSMainConnectionForDropDownList
		//
		public DataSet GetLFSMainConnectionForDropDownList()
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT MainConnection FROM LFS_MAIN_CONNECTION";
			SqlCommand command = new SqlCommand(commandText, connection);
			
			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			DataSet dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "LFS_MAIN_CONNECTION");

			return dataSet;
		}

		//
		// GetLFSMainConnectionForDropDownList [overloaded]
		//
		public DataSet GetLFSMainConnectionForDropDownList(string mainConnectionItem)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT MainConnection FROM LFS_MAIN_CONNECTION";
			SqlCommand command = new SqlCommand(commandText, connection);
			
			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			DataSet dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "LFS_MAIN_CONNECTION");

			DataRow newRow = dataSet.Tables["LFS_MAIN_CONNECTION"].NewRow();
			newRow["MainConnection"] = mainConnectionItem;
			dataSet.Tables["LFS_MAIN_CONNECTION"].Rows.Add(newRow);

			return dataSet;
		}


	}
}
