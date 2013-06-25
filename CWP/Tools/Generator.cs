using System;
using LiquiForce.LFSLive.CWP.DatabaseGateway;

namespace LiquiForce.LFSLive.CWP.Tools
{
	public class Generator
	{
		///////////////////////////////////////////////////////////////////////////
		/// CONSTRUCTORS
		///

		//
		// Default
		//
		public Generator()
		{

		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS
		///
		
		//		
		// GetNewLfsPointRepairsRefId
		//
		public static int GetNewLfsPointRepairsRefId(TDSLFSRecord tdsLfsRecord)
		{
			int newRefId = 0;

			foreach (TDSLFSRecord.LFS_POINT_REPAIRSRow row in tdsLfsRecord.LFS_POINT_REPAIRS)
			{
				if (newRefId < row.RefID)
				{
					newRefId = row.RefID;
				}
			}

			newRefId ++;

			return newRefId;
		}

		//
		// GetNewLfsPointRepairsDetailId
		//
		// Gets a new DetailID to insert a new lfs point repairs record
		//
		public static string GetNewLfsPointRepairsDetailId(TDSLFSRecord tdsLfsRecord)
		{
			string detailIDs = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string newDetailID;			
			int lastDetailIDIndex = -1;

			foreach (TDSLFSRecord.LFS_POINT_REPAIRSRow row in tdsLfsRecord.LFS_POINT_REPAIRS)
			{
				if (row.Deleted == false)
				{
					int rowIndex = detailIDs.IndexOf(row.DetailID);
					if (lastDetailIDIndex < rowIndex)
					{
						lastDetailIDIndex = rowIndex;
					}
				}
			}

			if (lastDetailIDIndex < 25 )
			{
				lastDetailIDIndex ++;
				newDetailID = detailIDs[lastDetailIDIndex].ToString();
			}
			else
			{
				newDetailID = "-1";
			}

			return newDetailID;
		}

		//
		// GetNewM2TablesRefId GetNewLfsPointRepairsRefId
		//
		public static int GetNewLfsM2TablesRefId(TDSLFSRecord tdsLfsRecord)
		{
			int newRefId = 0;

			foreach (TDSLFSRecord.LFS_M2_TABLESRow row in tdsLfsRecord.LFS_M2_TABLES)
			{
				if (newRefId < row.RefID)
				{
					newRefId = row.RefID;
				}
			}

			newRefId ++;

			return newRefId;
		}

		//		
		// GetNewLfsJunctionLinerRefId
		//
		public static int GetNewLfsJunctionLinerRefId(TDSLFSRecord tdsLfsRecord)
		{
			int newRefId = 0;

			foreach (TDSLFSRecord.LFS_JUNCTION_LINERRow row in tdsLfsRecord.LFS_JUNCTION_LINER)
			{
				if (newRefId < row.RefID)
				{
					newRefId = row.RefID;
				}
			}

			newRefId ++;

			return newRefId;
		}

		//
		// GetNewLfsJunctionLinerDetailId
		//
		// Gets a new DetailID to insert a new lfs juntion liner record
		//
		public static string GetNewLfsJunctionLinerDetailId(TDSLFSRecord tdsLfsRecord)
		{
			string detailIDs = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string newDetailID;			
			int lastDetailIDIndex = -1;

			foreach (TDSLFSRecord.LFS_JUNCTION_LINERRow row in tdsLfsRecord.LFS_JUNCTION_LINER)
			{
				if (row.Deleted == false)
				{
					int rowIndex = detailIDs.IndexOf(row.DetailID);
					if (lastDetailIDIndex < rowIndex)
					{
						lastDetailIDIndex = rowIndex;
					}
				}
			}

			if (lastDetailIDIndex < 25 )
			{
				lastDetailIDIndex ++;
				newDetailID = detailIDs[lastDetailIDIndex].ToString();
			}
			else
			{
				newDetailID = "-1";
			}

			return newDetailID;
		}


	}
}
