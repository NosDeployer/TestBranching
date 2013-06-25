using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LiquiForce.LFSLive.CWP.DatabaseGateway
{
	public class LFSMeasurementTypeGateway
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
		public LFSMeasurementTypeGateway()
		{
			//--- Get the connection string
			AppSettingsReader appSettingReader = new AppSettingsReader();
			ConnectionString = appSettingReader.GetValue("ConnectionString", typeof(System.String)).ToString();
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// GetLFSMeasurementTypeForDropDownList
		//
		public DataSet GetLFSMeasurementTypeForDropDownList()
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT MeasurementType FROM LFS_MEASUREMENT_TYPE";
			SqlCommand command = new SqlCommand(commandText, connection);
			
			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			DataSet dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "LFS_MEASUREMENT_TYPE");

			return dataSet;
		}

		//
		// GetLFSMeasurementTypeForDropDownList [overloaded]
		//
		public DataSet GetLFSMeasurementTypeForDropDownList(string measurementTypeItem)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = "SELECT MeasurementType FROM LFS_MEASUREMENT_TYPE";
			SqlCommand command = new SqlCommand(commandText, connection);
			
			SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

			DataSet dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "LFS_MEASUREMENT_TYPE");

			DataRow newRow = dataSet.Tables["LFS_MEASUREMENT_TYPE"].NewRow();
			newRow["MeasurementType"] = measurementTypeItem;
			dataSet.Tables["LFS_MEASUREMENT_TYPE"].Rows.Add(newRow);

			return dataSet;
		}


	}
}
