using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LiquiForce.LFSLive.CWP.DatabaseGateway
{
	public class LFSTrafficControlGateway
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
		public LFSTrafficControlGateway()
		{
			//--- Get the connection string
			AppSettingsReader appSettingReader = new AppSettingsReader();
			ConnectionString = appSettingReader.GetValue("ConnectionString", typeof(System.String)).ToString();
		}
		


		///////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// GetLFSTrafficControlForDropDownList
		//
		public DataSet GetLFSTrafficControlForDropDownList()
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT TrafficControl FROM LFS_TRAFFIC_CONTROL";
			SqlCommand command = new SqlCommand(commandText, connection);
			
			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			DataSet dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "LFS_TRAFFIC_CONTROL");

			return dataSet;
		}

		//
		// GetLFSTrafficControlForDropDownList [overloaded]
		//
		public DataSet GetLFSTrafficControlForDropDownList(string trafficControlItem)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT TrafficControl FROM LFS_TRAFFIC_CONTROL";
			SqlCommand command = new SqlCommand(commandText, connection);
			
			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			DataSet dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "LFS_TRAFFIC_CONTROL");

			DataRow newRow = dataSet.Tables["LFS_TRAFFIC_CONTROL"].NewRow();
			newRow["TrafficControl"] = trafficControlItem;
			dataSet.Tables["LFS_TRAFFIC_CONTROL"].Rows.Add(newRow);

			return dataSet;
		}


	}
}
