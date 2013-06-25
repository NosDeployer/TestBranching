using System;
using LiquiForce.LFSLive.CWP.DatabaseGateway;

namespace LiquiForce.LFSLive.CWP.Tools
{
	public class Navigator
	{
		///////////////////////////////////////////////////////////////////////////
		/// CONSTRUCTORS
		///

		//
		// Default
		//
		public Navigator()
		{
			
		}



		///////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// GetPreviousId
		//
		public static Guid GetPreviousId(TDSLFSRecordForNavigator tdsLfsRecordForNavigator, Guid currentId)
		{
			Guid prevId = currentId;

			for (int i=0; i < tdsLfsRecordForNavigator.NAVIGATOR.DefaultView.Count; i++)
			{
				if ((Guid)tdsLfsRecordForNavigator.NAVIGATOR.DefaultView[i]["ID"] == currentId)
				{
					if (i == 0)
					{
						prevId = currentId;
					}
					else
					{
						prevId = (Guid)tdsLfsRecordForNavigator.NAVIGATOR.DefaultView[i-1]["ID"];
					}

					break;
				}
			}

			return prevId;
		}

		//
		// GetNextId
		//
		public static Guid GetNextId(TDSLFSRecordForNavigator tdsLfsRecordForNavigator, Guid currentId)
		{
			Guid nextId = currentId;

			for (int i=0; i < tdsLfsRecordForNavigator.NAVIGATOR.DefaultView.Count; i++)
			{
				if ((Guid)tdsLfsRecordForNavigator.NAVIGATOR.DefaultView[i]["ID"] == currentId)
				{
					if (i == tdsLfsRecordForNavigator.NAVIGATOR.DefaultView.Count-1)
					{
						nextId = currentId;
					}
					else
					{
						nextId = (Guid)tdsLfsRecordForNavigator.NAVIGATOR.DefaultView[i+1]["ID"];
					}
					break;
				}
			}

			return nextId;
		}


	}
}
