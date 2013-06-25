using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LiquiForce.LFSLive.CWP.DatabaseGateway
{
	public class LFSDirectionsGateway
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
		public LFSDirectionsGateway()
		{
			//--- Get the connection string
			AppSettingsReader appSettingReader = new AppSettingsReader();
			ConnectionString = appSettingReader.GetValue("ConnectionString", typeof(System.String)).ToString();
		}
		


		///////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// GetLFSDirectionsForDropDownList
		//
		public DataSet GetLFSDirectionsForDropDownList()
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT Direction FROM LFS_DIRECTIONS";
			SqlCommand command = new SqlCommand(commandText, connection);
			
			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			DataSet dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "LFS_DIRECTIONS");

			return dataSet;
		}

		//
		// GetLFSDirectionsForDropDownList [overloaded]
		//
		public DataSet GetLFSDirectionsForDropDownList(string directionItem)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT Direction FROM LFS_DIRECTIONS";
			SqlCommand command = new SqlCommand(commandText, connection);
			
			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			DataSet dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "LFS_DIRECTIONS");

			DataRow newRow = dataSet.Tables["LFS_DIRECTIONS"].NewRow();
			newRow["Direction"] = directionItem;
			dataSet.Tables["LFS_DIRECTIONS"].Rows.Add(newRow);

			return dataSet;
		}


	}
}
