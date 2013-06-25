using System;
using System.Collections;
using LiquiForce.LFSLive.CWP.DatabaseGateway;

namespace LiquiForce.LFSLive.CWP.Tools
{
	public class RecordChangeTracking
	{
		///////////////////////////////////////////////////////////////////////////
		/// PROPERTIES AND FIELDS
		/// 

		//
		// Separators
		//
		private const string columnValueSeparator = "[=]";
		private const string columnSeparator = "||";



		///////////////////////////////////////////////////////////////////////////
		/// CONSTRUCTORS
		/// 

		//
		// Default
		//
		public RecordChangeTracking()
		{
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS
		/// 

		//
		// GetChanges
		//
		public static TDSLFSRecord GetChanges(TDSLFSRecord originalData, TDSLFSRecord currentData, int currentUser)
		{
			TDSLFSRecord result = new TDSLFSRecord();
			string changes;
			string currentValue;
			string originalValue;
			DateTime changed = DateTime.Now;

			//--- Get changes from master area

			//--- ... Calculate changes
			TDSLFSRecord.LFS_MASTER_AREARow originalLfsMasterAreaRow = originalData.LFS_MASTER_AREA.FindByIDCOMPANY_ID(currentData.LFS_MASTER_AREA[0].ID, currentData.LFS_MASTER_AREA[0].COMPANY_ID);

			changes = "";
			if (originalLfsMasterAreaRow == null)
			{
				for (int i = 0; i < currentData.LFS_MASTER_AREA.Columns.Count; i++)
				{
					if (!currentData.LFS_MASTER_AREA[0].IsNull(i))
					{
						changes += originalData.LFS_MASTER_AREA.Columns[i].ColumnName + columnValueSeparator + currentData.LFS_MASTER_AREA[0][i].ToString() + columnSeparator;
					}
				}
			}
			else
			{
				for (int i = 0; i < currentData.LFS_MASTER_AREA.Columns.Count; i++)
				{
					currentValue = (currentData.LFS_MASTER_AREA[0].IsNull(i)) ? "" : currentData.LFS_MASTER_AREA[0][i].ToString();
					originalValue = (originalLfsMasterAreaRow.IsNull(i)) ? "" : originalLfsMasterAreaRow[i].ToString();
					if (currentValue != originalValue)
					{
						changes += originalData.LFS_MASTER_AREA.Columns[i].ColumnName + columnValueSeparator + currentValue + columnSeparator;
					}
				}
			}
			changes = (changes != "") ? changes.Remove(changes.LastIndexOf(columnSeparator), columnSeparator.Length) : "";

			//--- ... Add rct record to result
			if (changes != "")
			{
				TDSLFSRecord.LFS_MASTER_AREA_RCTRow lfsMasterAreaRctRow = result.LFS_MASTER_AREA_RCT.NewLFS_MASTER_AREA_RCTRow();
			
				lfsMasterAreaRctRow.ID = currentData.LFS_MASTER_AREA[0].ID;
				lfsMasterAreaRctRow.COMPANY_ID = currentData.LFS_MASTER_AREA[0].COMPANY_ID;
				lfsMasterAreaRctRow.Changes = changes;
				lfsMasterAreaRctRow.Operation = (originalLfsMasterAreaRow == null) ? "Add" : ((currentData.LFS_MASTER_AREA[0].Deleted == true) ? "Delete" : "Update");
				lfsMasterAreaRctRow.ChangedBy = currentUser;
				lfsMasterAreaRctRow.Changed = changed;

				result.LFS_MASTER_AREA_RCT.AddLFS_MASTER_AREA_RCTRow(lfsMasterAreaRctRow);
			}


			//--- Get changes from point repairs
			TDSLFSRecord.LFS_POINT_REPAIRSRow originalLfsPointRepairsRow;

			foreach (TDSLFSRecord.LFS_POINT_REPAIRSRow currentLfsPointRepairsRow in currentData.LFS_POINT_REPAIRS)
			{
				//--- ... Calculate changes
				originalLfsPointRepairsRow = originalData.LFS_POINT_REPAIRS.FindByIDRefIDCOMPANY_ID(currentLfsPointRepairsRow.ID, currentLfsPointRepairsRow.RefID, currentLfsPointRepairsRow.COMPANY_ID);

				changes = "";
				if (originalLfsPointRepairsRow == null)
				{
					for (int i = 0; i < currentData.LFS_POINT_REPAIRS.Columns.Count; i++)
					{
						if (!currentLfsPointRepairsRow.IsNull(i))
						{
							changes += currentData.LFS_POINT_REPAIRS.Columns[i].ColumnName + columnValueSeparator + currentLfsPointRepairsRow[i].ToString() + columnSeparator;
						}
					}	
				}
				else
				{
					for (int i = 0; i < currentData.LFS_POINT_REPAIRS.Columns.Count; i++)
					{
						currentValue = (currentLfsPointRepairsRow.IsNull(i)) ? "" : currentLfsPointRepairsRow[i].ToString();
						originalValue = (originalLfsPointRepairsRow.IsNull(i)) ? "" : originalLfsPointRepairsRow[i].ToString();
						if (currentValue != originalValue)
						{
							changes += currentData.LFS_POINT_REPAIRS.Columns[i].ColumnName + columnValueSeparator + currentValue + columnSeparator;
						}
					}
				}
				changes = (changes != "") ? changes.Remove(changes.LastIndexOf(columnSeparator), columnSeparator.Length) : "";

				//--- ... Add rct record to result
				if (changes != "")
				{
					TDSLFSRecord.LFS_POINT_REPAIRS_RCTRow lfsPointRepairsRctRow = result.LFS_POINT_REPAIRS_RCT.NewLFS_POINT_REPAIRS_RCTRow();

					lfsPointRepairsRctRow.ID = currentLfsPointRepairsRow.ID;
					lfsPointRepairsRctRow.RefID = currentLfsPointRepairsRow.RefID;
					lfsPointRepairsRctRow.COMPANY_ID = currentLfsPointRepairsRow.COMPANY_ID;
					lfsPointRepairsRctRow.Changes = changes;
					lfsPointRepairsRctRow.Operation = (originalLfsPointRepairsRow == null) ? "Add" : ((currentLfsPointRepairsRow.Deleted == true) ? "Delete" : "Update");
					lfsPointRepairsRctRow.ChangedBy = currentUser;
					lfsPointRepairsRctRow.Changed = changed;

					result.LFS_POINT_REPAIRS_RCT.AddLFS_POINT_REPAIRS_RCTRow(lfsPointRepairsRctRow);
				}
			}


			//--- Get changes from m2 tables
			TDSLFSRecord.LFS_M2_TABLESRow originalLfsM2TablesRow;

			foreach (TDSLFSRecord.LFS_M2_TABLESRow currentLfsM2TablesRow in currentData.LFS_M2_TABLES)
			{
				//--- ... Calculate changes
				originalLfsM2TablesRow = originalData.LFS_M2_TABLES.FindByIDRefIDCOMPANY_ID(currentLfsM2TablesRow.ID, currentLfsM2TablesRow.RefID, currentLfsM2TablesRow.COMPANY_ID);

				changes = "";
				if (originalLfsM2TablesRow == null)
				{
					for (int i = 0; i < currentData.LFS_M2_TABLES.Columns.Count; i++)
					{
						if (!currentLfsM2TablesRow.IsNull(i))
						{
							changes += currentData.LFS_M2_TABLES.Columns[i].ColumnName + columnValueSeparator + currentLfsM2TablesRow[i].ToString() + columnSeparator;
						}
					}	
				}
				else
				{
					for (int i = 0; i < currentData.LFS_M2_TABLES.Columns.Count; i++)
					{
						currentValue = (currentLfsM2TablesRow.IsNull(i)) ? "" : currentLfsM2TablesRow[i].ToString();
						originalValue = (originalLfsM2TablesRow.IsNull(i)) ? "" : originalLfsM2TablesRow[i].ToString();
						if (currentValue != originalValue)
						{
							changes += currentData.LFS_M2_TABLES.Columns[i].ColumnName + columnValueSeparator + currentValue + columnSeparator;
						}
					}
				}
				changes = (changes != "") ? changes.Remove(changes.LastIndexOf(columnSeparator), columnSeparator.Length) : "";

				//--- ... Add rct record to result
				if (changes != "")
				{
					TDSLFSRecord.LFS_M2_TABLES_RCTRow lfsM2TablesRctRow = result.LFS_M2_TABLES_RCT.NewLFS_M2_TABLES_RCTRow();

					lfsM2TablesRctRow.ID = currentLfsM2TablesRow.ID;
					lfsM2TablesRctRow.RefID = currentLfsM2TablesRow.RefID;
					lfsM2TablesRctRow.COMPANY_ID = currentLfsM2TablesRow.COMPANY_ID;
					lfsM2TablesRctRow.Changes = changes;
					lfsM2TablesRctRow.Operation = (originalLfsM2TablesRow == null) ? "Add" : ((currentLfsM2TablesRow.Deleted == true) ? "Delete" : "Update");
					lfsM2TablesRctRow.ChangedBy = currentUser;
					lfsM2TablesRctRow.Changed = changed;

					result.LFS_M2_TABLES_RCT.AddLFS_M2_TABLES_RCTRow(lfsM2TablesRctRow);
				}
			}


			//--- Get changes from junction liner
			TDSLFSRecord.LFS_JUNCTION_LINERRow originalLfsJunctionLinerRow;

			foreach (TDSLFSRecord.LFS_JUNCTION_LINERRow currentLfsJunctionLinerRow in currentData.LFS_JUNCTION_LINER)
			{
				//--- ... Calculate changes
				originalLfsJunctionLinerRow = originalData.LFS_JUNCTION_LINER.FindByIDRefIDCOMPANY_ID(currentLfsJunctionLinerRow.ID, currentLfsJunctionLinerRow.RefID, currentLfsJunctionLinerRow.COMPANY_ID);

				changes = "";
				if (originalLfsJunctionLinerRow == null)
				{
					for (int i = 0; i < currentData.LFS_JUNCTION_LINER.Columns.Count; i++)
					{
						if (!currentLfsJunctionLinerRow.IsNull(i))
						{
							changes += currentData.LFS_JUNCTION_LINER.Columns[i].ColumnName + columnValueSeparator + currentLfsJunctionLinerRow[i].ToString() + columnSeparator;
						}
					}	
				}
				else
				{
					for (int i = 0; i < currentData.LFS_JUNCTION_LINER.Columns.Count; i++)
					{
						currentValue = (currentLfsJunctionLinerRow.IsNull(i)) ? "" : currentLfsJunctionLinerRow[i].ToString();
						originalValue = (originalLfsJunctionLinerRow.IsNull(i)) ? "" : originalLfsJunctionLinerRow[i].ToString();
						if (currentValue != originalValue)
						{
							changes += currentData.LFS_JUNCTION_LINER.Columns[i].ColumnName + columnValueSeparator + currentValue + columnSeparator;
						}
					}
				}
				changes = (changes != "") ? changes.Remove(changes.LastIndexOf(columnSeparator), columnSeparator.Length) : "";

				//--- ... Add rct record to result
				if (changes != "")
				{
					TDSLFSRecord.LFS_JUNCTION_LINER_RCTRow lfsJunctionLinerRctRow = result.LFS_JUNCTION_LINER_RCT.NewLFS_JUNCTION_LINER_RCTRow();

					lfsJunctionLinerRctRow.ID = currentLfsJunctionLinerRow.ID;
					lfsJunctionLinerRctRow.RefID = currentLfsJunctionLinerRow.RefID;
					lfsJunctionLinerRctRow.COMPANY_ID = currentLfsJunctionLinerRow.COMPANY_ID;
					lfsJunctionLinerRctRow.Changes = changes;
					lfsJunctionLinerRctRow.Operation = (originalLfsJunctionLinerRow == null) ? "Add" : ((currentLfsJunctionLinerRow.Deleted == true) ? "Delete" : "Update");
					lfsJunctionLinerRctRow.ChangedBy = currentUser;
					lfsJunctionLinerRctRow.Changed = changed;

					result.LFS_JUNCTION_LINER_RCT.AddLFS_JUNCTION_LINER_RCTRow(lfsJunctionLinerRctRow);
				}
			}


			//--- Return changes
			return result;
		}

		//
		// Split
		//
		public static ArrayList Split(string columnValueItems)
		{
			ArrayList result = new ArrayList();

			int index1 = 0;
			int index2 = 0;
			while (index1 < columnValueItems.Length)
			{
				index2  = columnValueItems.IndexOf(columnSeparator, index1);
				result.Add(columnValueItems.Substring(index1, ((index2 != -1) ? index2 - index1 : columnValueItems.Length-index1)));
				index1 = (index2 != -1) ? index2 + columnSeparator.Length : columnValueItems.Length;
			}

			return result;
		}

		//
		// GetColumnName
		//
		public static string GetColumnName(string columnValueItem)
		{
			return columnValueItem.Substring(0, columnValueItem.IndexOf(columnValueSeparator));
		}

		//
		// GetValue
		//
		public static string GetValue(string columnValueItem)
		{
			int index = columnValueItem.IndexOf(columnValueSeparator) + columnValueSeparator.Length;
			return (index < columnValueItem.Length) ? columnValueItem.Substring(index, columnValueItem.Length - index) : "";
		}


	}
}
