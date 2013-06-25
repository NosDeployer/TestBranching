using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LiquiForce.LFSLive.CWP.DatabaseGateway
{
	public class LFSMHShotsGateway
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
		public LFSMHShotsGateway()
		{
			//--- Get the connection string
			AppSettingsReader appSettingReader = new AppSettingsReader();
			ConnectionString = appSettingReader.GetValue("ConnectionString", typeof(System.String)).ToString();
		}
		


		///////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// GetLFSMHShotsForDropDownList
		//
		public DataSet GetLFSMHShotsForDropDownList()
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT MHShot FROM LFS_MHSHOTS";
			SqlCommand command = new SqlCommand(commandText, connection);
			
			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			DataSet dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "LFS_MHSHOTS");

			return dataSet;
		}

		//
		// GetLFSMHShotsForDropDownList [overloaded]
		//
		public DataSet GetLFSMHShotsForDropDownList(string mhShotItem)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT MHShot FROM LFS_MHSHOTS";
			SqlCommand command = new SqlCommand(commandText, connection);
			
			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			DataSet dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "LFS_MHSHOTS");

			DataRow newRow = dataSet.Tables["LFS_MHSHOTS"].NewRow();
			newRow["MHShot"] = mhShotItem;
			dataSet.Tables["LFS_MHSHOTS"].Rows.Add(newRow);

			return dataSet;
		}


	}
}
